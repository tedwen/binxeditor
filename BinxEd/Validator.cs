using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Windows.Forms;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// BinX Validator class contains static methods to validate a BinX document.
	/// </summary>
	/// <remarks>
	/// The validator serves two purposes, first, it relies on XML engine to validate XML syntax against binx.xsd schema.
	/// second, it checks the BinX document for semantic-level validity. Possible validations include:
	/// <list>
	/// Order of user-defined types. A referenced type must be defined before the reference.
	/// Duplicate type names. Can't have two user-defined types that have the same type name.
	/// Duplicate variable names. Discourage use of same names for two or more variables in a group like struct.
	/// Duplicate or invalid case values. Discriminant values for each case of a union must be valid and unique.
	/// Referenced types must have been defined. This violation occurs when user deletes a defined type.
	/// </list>
	/// </remarks>
	public class Validator
	{
		private static FormErrors formErrors;
		private static string typeNameJustDefined;	//used to check reference to itself

		/// <summary>
		/// Internal validator to validate the BinX grammar and usage. It is used after opening and saving a BinX document. A error window 
		/// is popped up with error and warning messages listed for reference.
		/// </summary>
		/// <param name="defset"></param>
		/// <param name="dataset"></param>
		public static void validate(DefinitionsNode defset, DatasetNode dataset)
		{
			ArrayList report = new ArrayList();
			Hashtable defs = new Hashtable();
			//check definition section
			foreach (DefineTypeNode dt in defset.getDefinitions())
			{
				string sTypeName = dt.getTypeName();
				//check duplicate type definitions
				if (defs.Contains(sTypeName))
				{
					report.Add("Error: duplicate type name '" + sTypeName + "' at '" + dt.toNodeText() + "'.");
				} 
				else 
				{
					defs.Add(sTypeName, sTypeName);
				}
				//check defineType content
				typeNameJustDefined = sTypeName;
				checkComplexType(dt.getBaseType(), defs, report);
			}
			typeNameJustDefined = null;
			if (dataset != null) 
			{
				//check dataset section
				if (dataset.getBinaryFileName() == null || dataset.getBinaryFileName().Length < 1) 
				{
					report.Add("Warning: dataset has no binary file attached.");
				}
				if (dataset.getDataset().Count <= 0)
				{
					report.Add("Warning: dataset has no element.");
				}
				Hashtable varNames = new Hashtable();
				foreach (AbstractNode an in dataset.getDataset())
				{
					//check for duplicate varNames
					checkVarNames(an, varNames, report);
					checkUseType(an, defs, report);
				}
			}
			//show report if any
			if (report.Count > 0)
			{
				formErrors = new FormErrors();
				formErrors.addMessages(report);
				formErrors.Show();
			}
		}

		/// <summary>
		/// Check struct, union and array node for useType references, duplicate union case values.
		/// </summary>
		/// <remarks>
		/// This check should apply to the following scenarios:
		/// <list>
		/// A struct contains two or more member elements that have the same variable name
		/// A struct contains a useType as its member or member of its member which referenced a undefined type
		/// A struct contains no member element
		/// A union contains no case element
		/// A union contains two or more cases with the same discriminant value
		/// A union contains a useType element in any of the case elements that referenced a undefined type
		/// An array contains no dimension element
		/// An streamed array contains more than one dim element
		/// An variable-sized array's first dim element has a count (should be zero)
		/// A fixed array contains a dim element with a zero count (should be greater than 0)
		/// An array contains useType element that referenced a undefined type
		/// An array contains a variable-sized construct in its element or embeded descedants.
		/// </list>
		/// </remarks>
		/// <param name="dataNode"></param>
		/// <param name="defs"></param>
		/// <param name="report"></param>
		private static void checkComplexType(ComplexNode dataNode, Hashtable defs, ArrayList report)
		{
			if (dataNode.GetType().Equals(typeof(StructNode))) 
			{
				StructNode sNode = (StructNode)dataNode;
				if (sNode.getMemberCount() > 0) 
				{
					Hashtable varNames = new Hashtable();
					foreach (AbstractNode aNode in ((StructNode)dataNode).getMembers())
					{
						//check duplicate variable names as warnings
						checkVarNames(aNode, varNames, report);
						checkUseType(aNode, defs, report);
					}
				} 
				else 
				{
					//empty struct
					report.Add("Warning: struct '"+sNode.toNodeText()+"' contains no member element.");
				}
			} 
			else if (dataNode.GetType().Equals(typeof(UnionNode))) 
			{
				UnionNode uNode = (UnionNode)dataNode;
				if (uNode.getCaseCount() > 0) 
				{
					Hashtable cases = new Hashtable();
					foreach (CaseNode cNode in uNode.getCases())
					{
						//case values must be unique
						if (cases.Contains(cNode.getDiscriminantValue())) 
						{
							report.Add("Error: duplicate case value '" + cNode.getDiscriminantValue() + "' at union type '" + dataNode.toNodeText() + "'.");
						} 
						else 
						{
							cases.Add(cNode.getDiscriminantValue(), cNode);
						}
						//if case body is useType, check type defs
						checkUseType(cNode.getCaseBody(), defs, report);
					}
				} 
				else 
				{
					report.Add("Warning: union '"+uNode.toNodeText()+"' contains no case element.");
				}
			} 
			else if (dataNode.GetType().Equals(typeof(ArrayNode))) 
			{
				ArrayNode arrayNode = (ArrayNode)dataNode;
				if (arrayNode.getDimension()==null) 
				{
					report.Add("Error: Array '"+arrayNode.toNodeText()+"' has no dimension element.");
				} 
				else 
				{
					if (arrayNode.isArrayStreamed() && arrayNode.getDimensionCount()>1)
					{
						report.Add("Warning: Streamed array contains more than one dimension.");
					} 
					else if (arrayNode.isArrayFixed())
					{
						for (DimNode dn=arrayNode.getDimension(); dn!=null; dn=dn.getChild())
						{
							if (dn.count() <= 0) 
							{
								report.Add("Error: array dimension is of invalid size at '"+arrayNode.toNodeText()+"'.");
							}
						}
					} 
					else 
					{
						//first dim must be of 0 size
						DimNode dn = arrayNode.getDimension();
						if (dn.count() > 0) 
						{
							report.Add("Warning: first dimension count of a variable-sized array ignored at '"+arrayNode.toNodeText()+"'.");
						}
						for (dn=dn.getChild(); dn!=null; dn=dn.getChild())
						{
							if (dn.count() <= 0) 
							{
								report.Add("Error: array dimension is of invalid size at '"+arrayNode.toNodeText()+"'.");
							}
						}
					}
				}
				checkUseType(arrayNode.getElement(), defs, report);
				//check for variable-sized construct contained in arrays
				checkVariableConstruct(arrayNode.getElement(), report);
			}
		}

		/// <summary>
		/// Check useType node for defined-type reference, or call checkComplexType for complex node.
		/// </summary>
		/// <remarks>
		/// This check should apply to the following scenarios:
		/// <list>
		/// Wherever a useType element is found (in struct, array, union, dataset),
		/// Empty typeName attribute is given for a useType element
		/// The typeName given by the useType element is not already defined before this reference in the definitions section
		/// </list>
		/// </remarks>
		/// <param name="aNode"></param>
		/// <param name="defs"></param>
		/// <param name="report"></param>
		private static void checkUseType(AbstractNode aNode, Hashtable defs, ArrayList report)
		{
			if (aNode.GetType().Equals(typeof(UseTypeNode))) 
			{
				string sTypeName = aNode.getTypeName();
				if (sTypeName==null || sTypeName.Length < 1)
				{
					report.Add("Error: invalid type name at '" + aNode.toNodeText() + "'.");
				} 
				else if (sTypeName.Equals(typeNameJustDefined)) 
				{
					report.Add("Error: recursively referencing the type for '" + aNode.toNodeText() + "'.");
				}
				else 
				{
					if (!defs.Contains(sTypeName))
					{
						report.Add("Error: type '" + sTypeName + "' used before defined at '" + aNode.toNodeText() + "'.");
					}
				}
			} 
			else if (aNode.isComplex())
			{
				checkComplexType((ComplexNode)aNode, defs, report);
			}
		}

		/// <summary>
		/// Check for duplicate variable names.
		/// </summary>
		/// <remarks>
		/// This check should apply to the following two scenarios:
		/// <list>
		/// Two or more data elements have the same variable name in the Dataset section
		/// Two or more data elements in a struct have the same variable name
		/// </list>
		/// </remarks>
		/// <param name="aNode"></param>
		/// <param name="varNames"></param>
		/// <param name="report"></param>
		private static void checkVarNames(AbstractNode aNode, Hashtable varNames, ArrayList report)
		{
			string sVarName = aNode.getVarName();
			if (sVarName!=null && sVarName.Length > 0)
			{
				if (varNames.Contains(sVarName)) 
				{
					report.Add("Warning: duplicate variable name '" + sVarName + "' in '" + aNode.toNodeText() + "'.");
				} 
				else 
				{
					varNames.Add(sVarName, sVarName);
				}
			}
		}

		/// <summary>
		/// Check to see whether there's variable-sized construct in an array. These include arrayVariable, arrayStreamed, union, string.
		/// </summary>
		/// <remarks>
		/// This check should apply to the following scenarios:
		/// <list>
		/// Arrays contain arrayVariable, arrayStreamed, or union
		/// Arrays contain struct which contains any of the above three elements
		/// Arrays contain a number of embedded structs at least one of which contains any of the above three elements
		/// Arrays contain arrayFixed which contains one of the above as element
		/// Arrays contain a number of embedded arrayFixed any of which contains any of the above three elements
		/// </list>
		/// </remarks>
		/// <param name="node"></param>
		/// <param name="report"></param>
		private static void checkVariableConstruct(AbstractNode node, ArrayList report)
		{
			if (node.GetType().Equals(typeof(StructNode)))
			{
				foreach (AbstractNode aNode in ((StructNode)node).getMembers())
				{
					if (aNode.isComplex()) 
					{
						checkVariableConstruct(aNode, report);
					}
				}
			} 
			else if (node.GetType().Equals(typeof(UnionNode)))
			{
				report.Add("Warning: BinX library version 1.x does not support arrays containing union ["+node.toNodeText()+"].");
			} 
			else if (node.GetType().Equals(typeof(ArrayNode)))
			{
				ArrayNode aNode = (ArrayNode)node;
				if (aNode.isArrayFixed()==false) 
				{
					report.Add("Warning: BinX library version 1.x does not support arrays containing variable-sized arrays ["+aNode.toNodeText()+"].");
				} 
				else 
				{
					checkVariableConstruct(aNode.getElement(), report);
				}
			}
		}

		/// <summary>
		/// Validation through XML Schema.
		/// </summary>
		/// <param name="schemaFile"></param>
		/// <param name="docFile"></param>
		public static void Validate(string schemaFile, string docFile)
		{
			XmlSchemaCollection sc = new XmlSchemaCollection();
			sc.ValidationEventHandler += new ValidationEventHandler(ValidationHandler);
			sc.Add(null, schemaFile);

			XmlTextReader tr = new XmlTextReader(docFile);
			XmlValidatingReader vr = new XmlValidatingReader(tr);

			vr.Schemas.Add(sc);
			vr.ValidationType = ValidationType.Schema;
			vr.ValidationEventHandler += new ValidationEventHandler (ValidationHandler);

			while(vr.Read());
			MessageBox.Show(null, "Validation finished", "Info");
		}

		/// <summary>
		/// Event handler for XML Schema validator
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		public static void ValidationHandler(object sender, ValidationEventArgs args)
		{
			MessageBox.Show(null, args.Message, "Validation error");
		}
	}
}
