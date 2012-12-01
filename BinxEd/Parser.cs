using System;
using System.Xml;
using System.IO;

namespace BinxEd
{
	/// <summary>
	/// The BinX Parser.
	/// </summary>
	public class Parser
	{
		private const string sBinx = "binx";
		private const string sDefinitions = "definitions";
		private const string sDataset = "dataset";

		/// <summary>
		/// Parse a BinX document from a file and save extracted definitions and data elements in the given containers.
		/// </summary>
		/// <param name="filePath">File path and name to parse</param>
		/// <param name="definitions">Container object reference for definitions</param>
		/// <param name="dataset">Container object reference for dataset elements</param>
		/// <returns>true if successful</returns>
		public static bool load(string filePath, ref DefinitionsNode definitions, ref DatasetNode dataset)
		{
			bool bBinxDoc = false;
			try 
			{
				XmlTextReader reader = new XmlTextReader(filePath);
				while (reader.Read()) 
				{
					if (reader.NodeType == XmlNodeType.Element) 
					{
						if (bBinxDoc) 
						{
							if (reader.LocalName.Equals(sDefinitions))
							{
								//<definitions>
								loadDefinitions(reader, ref definitions);
							}
							else if (reader.LocalName.Equals(sDataset))
							{
								//<dataset>
								loadDataset(reader, ref dataset);
							}
						}
						else if (reader.LocalName.Equals(sBinx)) 
						{
							bBinxDoc = true;
						}
					}
				}
				reader.Close();
				return true;
			} 
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, "Bad XML file");
				return false;
			}
		}

		/// <summary>
		/// Load definition section only, for import defined types.
		/// </summary>
		/// <param name="filePath">BinX file to load definitions from</param>
		/// <param name="definitions">Reference to the Definitions class to hold the imported definitions</param>
		public static void loadDefinitions(string filePath, ref DefinitionsNode definitions)
		{
			bool bBinxDoc = false;
			try 
			{
				XmlTextReader reader = new XmlTextReader(filePath);
				while (reader.Read()) 
				{
					if (reader.NodeType == XmlNodeType.Element) 
					{
						if (bBinxDoc) 
						{
							if (reader.LocalName.Equals(sDefinitions))
							{
								//<definitions>
								loadDefinitions(reader, ref definitions);
							}
						}
						else if (reader.LocalName.Equals(sBinx)) 
						{
							bBinxDoc = true;
						}
					}
				}
				reader.Close();
			} 
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, "Bad XML file");
			}
		}

		/// <summary>
		/// Load definitions section.
		/// </summary>
		/// <param name="reader"></param>
		protected static void loadDefinitions(XmlTextReader reader, ref DefinitionsNode definitions)
		{
			DefineTypeNode ut = null;
			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element) 
				{
					if (reader.LocalName.Equals("defineType")) 
					{
						string sTypename = reader.GetAttribute("typeName");
						ut = new DefineTypeNode(sTypename);
					} 
					else if (reader.LocalName.Equals("struct") && ut!=null)
					{
						ut.setBaseType( LoadStruct(reader) );
					} 
					else if (reader.LocalName.Equals("union") && ut!=null)
					{
						ut.setBaseType( LoadUnion(reader) );
					} 
					else if (reader.LocalName.StartsWith("array") && ut!=null) 
					{
						ut.setBaseType( LoadArray(reader) );
					} 
				}
				else if (reader.NodeType == XmlNodeType.EndElement) 
				{
					if (reader.LocalName.Equals("defineType") && ut!=null)
					{
						definitions.addChild(ut);
						ut = null;
					}
					else if (reader.LocalName.Equals(sDefinitions)) 
					{
						return;
					}
				}
			}
		}

		/// <summary>
		/// Load dataset section from BinX document.
		/// </summary>
		/// <param name="reader"></param>
		protected static void loadDataset(XmlTextReader reader, ref DatasetNode dataset)
		{
			dataset.setBinaryFileName(reader.GetAttribute("src"));
			dataset.setBigEndian(reader.GetAttribute("byteOrder").Equals("bigEndian"));
			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element)
				{
					AbstractNode it = ParseNode(reader);
					dataset.addChild(it);
				} 
				else if (reader.NodeType==XmlNodeType.EndElement) 
				{
					if (reader.LocalName.Equals("dataset")) 
					{
						return;
					}
				}
			}
		}

		/// <summary>
		/// Load a struct block
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		protected static StructNode LoadStruct(XmlTextReader reader)
		{
			StructNode st = new StructNode();
			string varname = reader.GetAttribute("varName");
			string blocksize = reader.GetAttribute("blockSize");
			if (varname != null) 
			{
				st.setVarName( varname );
			}
			if (blocksize != null)
			{
				st.setBlockSize( Convert.ToInt32(blocksize) );
			}
			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element)
				{
					st.addChild( ParseNode(reader) );
				} 
				else if (reader.NodeType == XmlNodeType.EndElement)
				{
					if (reader.LocalName.Equals("struct"))
					{
						break;
					}
				}
			}
			return st;
		}

		/// <summary>
		/// Parse and load a union element type
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		protected static UnionNode LoadUnion(XmlTextReader reader)
		{
			string vname = reader.GetAttribute("varName");
			string blocksize = reader.GetAttribute("blockSize");
			UnionNode ut = new UnionNode();
			if (vname != null) 
			{
				ut.setVarName( vname );
			}
			if (blocksize != null)
			{
				ut.setBlockSize( Convert.ToInt32(blocksize) );
			}
			bool inDiscriminantSection = false;
			bool inCaseSection = false;
			string dv = null;
			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element)
				{
					if (reader.LocalName.Equals("discriminant"))
					{
						inDiscriminantSection = true;
					} 
					else if (reader.LocalName.Equals("case"))
					{
						inCaseSection = true;
						dv = reader.GetAttribute("discriminantValue");
					} 
					else 
					{
						AbstractNode it = ParseNode(reader);
						if (inDiscriminantSection) 
						{
							ut.setDiscriminantType( it.getTypeName() );
						} 
						else if (inCaseSection) 
						{
							CaseNode c = new CaseNode(dv, it);
							ut.addCase(c);
						}
					}
				} 
				else if (reader.NodeType == XmlNodeType.EndElement)
				{
					if (reader.LocalName.Equals("discriminant"))
					{
						inDiscriminantSection = false;
					} 
					else if (reader.LocalName.Equals("case"))
					{
						inCaseSection = false;
					}
					else if (reader.LocalName.Equals("union"))
					{
						break;
					}
				}
			}
			return ut;
		}

		/// <summary>
		/// Parse and load an array element type
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		protected static ArrayNode LoadArray(XmlTextReader reader)
		{
			string aname = reader.LocalName;
			string vname = reader.GetAttribute("varName");
			string blocksize = reader.GetAttribute("blockSize");
			ArrayNode a = new ArrayNode(aname);
			if (vname != null) 
			{
				a.setVarName( vname );
			}
			if (blocksize != null)
			{
				a.setBlockSize( Convert.ToInt32(blocksize) );
			}
			bool inSizeRefSection = false;
			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element)
				{
					if (reader.LocalName.Equals("sizeRef"))
					{
						inSizeRefSection = true;
					} 
					else if (reader.LocalName.Equals("dim"))
					{
						string dname = reader.GetAttribute("name");
						int nCount = 0;
						string indexTo = reader.GetAttribute("indexTo");
						if (indexTo == null) 
						{
							string count = reader.GetAttribute("count");
							if (count != null) 
							{
								nCount = Convert.ToInt32(count);
							}
						} 
						else 
						{
							nCount = Convert.ToInt32(indexTo) + 1;
						}
						a.addDimension(dname, nCount);
					} 
					else if (inSizeRefSection)
					{
						a.setSizeRef( ParseNode(reader) );
					} 
					else 
					{
						a.setElement( ParseNode(reader) );
					}
				} 
				else if (reader.NodeType == XmlNodeType.EndElement)
				{
					if (reader.LocalName.Equals("sizeRef"))
					{
						inSizeRefSection = false;
					} 
					else if (reader.LocalName.StartsWith("array"))
					{
						break;
					}
				}
			}
			return a;
		}

		/// <summary>
		/// Parse a node for data types (primitive, complex, useType)
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		protected static AbstractNode ParseNode(XmlTextReader reader)
		{
			AbstractNode it = null;
			string byteOrder = reader.GetAttribute("byteOrder");
			if (reader.LocalName.Equals("struct"))
			{
				it = LoadStruct(reader);
			} 
			else if (reader.LocalName.Equals("union"))
			{
				it = LoadUnion(reader);
			} 
			else if (reader.LocalName.StartsWith("array"))
			{
				it = LoadArray(reader);
			} 
			else if (reader.LocalName.Equals("useType"))
			{
				string typeName = reader.GetAttribute("typeName");
				string blockSize = reader.GetAttribute("blockSize");
				it = new UseTypeNode(typeName);
				if (blockSize != null) 
				{
					((UseTypeNode)it).setBlockSize( Convert.ToInt16(blockSize) );
				}
				string varName = reader.GetAttribute("varName");
				it.setVarName( varName );
			}
			else	//primitive
			{
				string varName = reader.GetAttribute("varName");
				it = new PrimitiveNode(reader.LocalName);
				if (varName!=null) 
				{
					it.setVarName( varName );
				}
			}
			if (byteOrder != null) 
			{
				it.setBigEndian( (byteOrder.Equals("bigEndian"))?true:false );
			}
			return it;
		}

	}
}
