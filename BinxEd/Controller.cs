using System;
using System.Windows.Forms;

namespace BinxEd
{
	/// <summary>
	/// Controller class mimicks the so-called controller in a MVC design pattern.
	/// </summary>
	public class Controller
	{
		private Form view_;
		private Document document_;
		private int typeStructCounter_, typeUnionCounter_, typeArrayCounter_;

		public Controller(Form view)
		{
			view_ = view;
			document_ = new Document();
		}

		/// <summary>
		/// Duplicate pass-through call for view-model.
		/// </summary>
		public bool isDocumentModified()
		{
			return document_.isModified();
		}

		/// <summary>
		/// Duplicate pass-through call for view-model.
		/// </summary>
		public bool isBigEndian()
		{
			return document_.isBigEndian();
		}

		/// <summary>
		/// Duplicate pass-through
		/// </summary>
		/// <param name="val"></param>
		public void setBigEndian(bool val)
		{
			document_.setBigEndian(val);
		}

		/// <summary>
		/// Duplicate pass-through call for view-model.
		/// </summary>
		public bool requireFileName()
		{
			return document_.getFilePath() == null;
		}

		/// <summary>
		/// Duplicate pass-through call
		/// </summary>
		/// <returns></returns>
		public string getDocumentFilePath()
		{
			return document_.getFilePath();
		}

		/// <summary>
		/// Duplicate pass-through call for view-model.
		/// </summary>
		/// <param name="fileName"></param>
		public void loadDocument(string fileName)
		{
			if (document_.load(fileName)) 
			{
				Validator.validate(document_.getDefinitions(), document_.getDataset());
			}
		}

		/// <summary>
		/// Duplicate pass-through call for view-model.
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="validate"></param>
		public void saveDocument(string fileName, bool validate)
		{
			document_.save(fileName);
			if (validate) 
			{
				Validator.validate(document_.getDefinitions(), document_.getDataset());
			}
		}

		public void saveDocument()
		{
			document_.save();
			Validator.validate(document_.getDefinitions(), document_.getDataset());
		}

		/// <summary>
		/// Duplicate pass-through call for view-model.
		/// </summary>
		public void clearData()
		{
			document_.clear();
		}

		/// <summary>
		/// Duplicate pass-through call
		/// </summary>
		/// <returns></returns>
		public bool isDocumentEmpty()
		{
			return document_.isEmpty();
		}

		/// <summary>
		/// Duplicate pass-through call for view-model.
		/// </summary>
		/// <returns></returns>
		public string getDatasetNodeText()
		{
			return document_.getDatasetNodeText();
		}

		/// <summary>
		/// Import all definitions from an external BinX document with duplicated types (by name) ignored.
		/// </summary>
		/// <param name="filePath"></param>
		public void importDefinitions(string filePath)
		{
			document_.getDefinitions().import(filePath);
			Validator.validate(document_.getDefinitions(), null);
		}

		/// <summary>
		/// Create a child node for the given type and add it to a parent
		/// </summary>
		/// <remarks>If type is primitive, then create directly, otherwise, call corresponding create windows.</remarks>
		/// <param name="parentNode"></param>
		/// <param name="stype"></param>
		/// <param name="svname"></param>
		private void addChildNode(DataNode parentNode, string stype, string svname)
		{
			if (stype==null || stype.Equals("")) return;

			AbstractNode childNode = null;
			if (document_.getDataTypes().isPrimitive(stype))
			{
				childNode = new PrimitiveNode(stype, svname);
			}
			else if (document_.isTypeDefined(stype))
			{
				childNode = new UseTypeNode(stype, svname);
			}
			else if (stype.Equals("struct"))
			{
				addStructTypeNode(parentNode, parentNode.Nodes.Count, false);
				return;
			}
			else if (stype.Equals("union"))
			{
				addUnionTypeNode(parentNode, parentNode.Nodes.Count, false);
				return;
			}
			else if (stype.StartsWith("array"))
			{
				addArrayTypeNode(parentNode, parentNode.Nodes.Count, false);
				return;
			}
			addChildNode(parentNode, new DataNode(childNode), parentNode.Nodes.Count);
		}

		/// <summary>
		/// Add child node to the parent at the given position. Both TreeView and document are added implicitly.
		/// </summary>
		/// <param name="parentNode">DatasetNode, StructNode, or UnionNode</param>
		/// <param name="childNode">Any data node</param>
		/// <param name="at">Position to insert the child</param>
		/// <returns></returns>
		private void addChildNode(DataNode parentNode, DataNode childNode, int at)
		{
			ComplexNode dataNode = null;
			if (parentNode.getDataNode().GetType().Equals(typeof(DefineTypeNode)))
			{
				dataNode = ((DefineTypeNode)parentNode.getDataNode()).getBaseType();
			} 
			else
			{
				dataNode = (ComplexNode)parentNode.getDataNode();
			}
			dataNode.insertChild(childNode.getDataNode(), at);
			parentNode.Nodes.Insert(at, childNode);
		}

		/// <summary>
		/// Insert a primitive data type node into the tree as the child node at the given position.
		/// </summary>
		/// <param name="parentNode">Parent node to insert a primitive node, can be StructNode or DatasetNode</param>
		/// <param name="at">Position before which the new node is to be inserted</param>
		public void addPrimitiveNode(DataNode parentNode, int at)
		{
			FormData formData = new FormData();
			formData.DataTypeSource = document_.getPrimitiveTypeNames();
			DialogResult r = DialogResult.No;
			int vi = parentNode.Nodes.Count;
			do 
			{
				string vn = "var-" + Convert.ToString(++vi);
				formData.VarName = vn;
				r = formData.ShowDialog(view_);
				if (r != DialogResult.Cancel) 
				{
					string stype = formData.SelectedType;
					string svar = formData.VarName;
					PrimitiveNode childNode = new PrimitiveNode(stype, svar);
					addChildNode(parentNode, new DataNode(childNode), at++);
					document_.setModified();
				}
			} while (r == DialogResult.Yes);
		}

		/// <summary>
		/// Insert a useType node into the tree as the child node at the given position.
		/// </summary>
		/// <param name="parentNode"></param>
		/// <param name="at"></param>
		public void addUseTypeNode(DataNode parentNode, int at)
		{
			if (document_.getDefinitions().count() <= 0) 
			{
				MessageBox.Show("No user-defined type in the Definitions section.", "Warning");
				return;
			}
			FormData formData = new FormData();
			formData.DataTypeSource = document_.getUserDefinedTypeNames();
			DialogResult r = DialogResult.No;
			int vi = parentNode.Nodes.Count;
			do 
			{
				string vn = "var-" + Convert.ToString(++vi);
				formData.VarName = vn;
				r = formData.ShowDialog(view_);
				if (r != DialogResult.Cancel) 
				{
					string stype = formData.SelectedType;
					string svar = formData.VarName;
					UseTypeNode childNode = new UseTypeNode(stype, svar);
					addChildNode(parentNode, new DataNode(childNode), at++);
					document_.setModified();
				}
			} while (r == DialogResult.Yes);
		}

		/// <summary>
		/// Add a struct data element.
		/// </summary>
		/// <param name="parentNode">parent node that contains this struct element node</param>
		/// <param name="at">position where the new struct is inserted before</param>
		public void addStructTypeNode(DataNode parentNode, int at, bool defineType)
		{
			FormStruct formStruct = new FormStruct();
			if (defineType)
			{
				formStruct.TypeName = "MyStructType-" + Convert.ToString(++typeStructCounter_);
			} 
			else 
			{
				formStruct.Text = "Build a struct element";
				formStruct.ChangeLabel("Var Name:");
				formStruct.TypeName = "myStruct-" + Convert.ToString(parentNode.Nodes.Count);	//TODO: check for duplicate name
			}
			formStruct.setDataTypeSource(document_.getTypeNames());
			DialogResult r = formStruct.ShowDialog(view_);
			if (r==DialogResult.OK) 
			{
				string varName = formStruct.TypeName;
				string blockSize = formStruct.BlockSize;
				int nBlockSize = 0;
				try 
				{
					nBlockSize = Convert.ToInt32(blockSize);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				StructNode sn = new StructNode((defineType)?"":varName, nBlockSize);
				AbstractNode aNode = sn;
				if (defineType)
				{
					aNode = new DefineTypeNode(formStruct.TypeName, sn);
				}
				DataNode dn = new DataNode(aNode);
				//collect struct members
				foreach (ListViewItem itm in formStruct.getMemberItems())
				{
					string stype = itm.Text;
					string svname = itm.SubItems[1].Text;
					if (!stype.Equals(""))
					{
						addChildNode(dn, stype, svname);
					}
				}
				addChildNode(parentNode, dn, at);
				document_.setModified();
				parentNode.ExpandAll();
			}
		}

		/// <summary>
		/// Add a union data element.
		/// </summary>
		/// <param name="parentNode">parent that contains this union element</param>
		/// <param name="at">position where the new node is inserted before</param>
		/// <param name="defineType">if true invokes a define union type window</param>
		public void addUnionTypeNode(DataNode parentNode, int at, bool defineType)
		{
			FormUnion formUnion = new FormUnion();
			if (defineType)
			{
				formUnion.TypeName = "MyUnionType-" + Convert.ToString(++typeUnionCounter_);
			} 
			else 
			{
				formUnion.Text = "Build a union element";
				formUnion.ChangeLabel("Var Name:");
				formUnion.TypeName = "myUnion-" + Convert.ToString(parentNode.Nodes.Count);	//TODO: check for duplicate name
			}
			formUnion.setDataTypeSource(document_.getTypeNames());
			DialogResult r = formUnion.ShowDialog(view_);
			if (r==DialogResult.OK)
			{
				string varName = formUnion.TypeName;
				string discriminantType = formUnion.DiscriminantType;
				string blockSize = formUnion.BlockSize;
				int nBlockSize = 0;
				try
				{
					nBlockSize = Convert.ToInt32(blockSize);
				} 
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				UnionNode un = new UnionNode((defineType)?"":varName);
				un.setDiscriminantType(discriminantType);
				if (nBlockSize > 0) 
				{
					un.setBlockSize(nBlockSize);
				}
				AbstractNode aNode = un;
				if (defineType)
				{
					aNode = new DefineTypeNode(formUnion.TypeName, un);
				}
				DataNode dn = new DataNode(aNode);

				int n = 0;
				foreach (ListViewItem itm in formUnion.getCases())
				{
					string sval = itm.Text;
					string stype = itm.SubItems[1].Text;
					string svname = itm.SubItems[2].Text;
					if (!stype.Equals(""))
					{
						//create a CaseNode
						CaseNode cn = new CaseNode(sval, null);
						//add data object as child node and case body of the case node
						DataNode dcn = new DataNode(cn);
						addChildNode(dcn, stype, svname);
						addChildNode(dn, dcn, n++);
					}
				}
				addChildNode(parentNode, dn, at);
				document_.setModified();
				parentNode.ExpandAll();
			}
		}

		/// <summary>
		/// Add an array data element.
		/// </summary>
		/// <param name="parentNode">parent node that contains this new node</param>
		/// <param name="at">position before which the new node is inserted</param>
		public void addArrayTypeNode(DataNode parentNode, int at, bool defineType)
		{
			FormArray formArray = new FormArray();
			if (!defineType)
			{
				formArray.Text = "Build an array element";
				formArray.ChangeLabel("Var Name:");
				formArray.TypeName = "myArray-" + Convert.ToString(parentNode.Nodes.Count);	//TODO: check for duplicate names
			} 
			else 
			{
				formArray.TypeName = "MyArray-" + Convert.ToString(++typeArrayCounter_);
			}
			formArray.DataTypeSource = document_.getTypeNames();
			DialogResult r = formArray.ShowDialog(view_);
			if (r == DialogResult.OK)
			{
				string varName = formArray.TypeName;
				string arrayType = formArray.ArrayTypeName;
				ArrayNode an = new ArrayNode(arrayType, (defineType)?"":varName);
				//if variable, add sizeRef
				if (formArray.ArrayType == 2)
				{
					AbstractNode data = new PrimitiveNode(formArray.SizeRef);
					an.setSizeRef( data );
				}
				AbstractNode aNode = an;
				if (defineType) 
				{
					aNode = new DefineTypeNode(formArray.TypeName, an);
				}
				DataNode dn = new DataNode(aNode);
				addChildNode(dn, formArray.DataType, "");	//element data type as first child node of array
				if (formArray.ArrayType == 3) //arrayStreamed containing only one dim
				{
					//an.addDimension("", 0);
					addChildNode(dn, new DataNode(new DimNode("", 0)), 1);	//dim as second child node of array
				}
				else	//fixed or variable
				{
					DataNode tmpNode = dn;
					foreach (ListViewItem itm in formArray.getDimensions())
					{
						string scount = itm.Text;
						string sdimname = itm.SubItems[1].Text;
						if (!scount.Equals(""))
						{
							//DataNode dNode = new DataNode(an.addDimension(sdimname, scount));
							DataNode dNode = new DataNode(new DimNode(sdimname, scount));
							addChildNode(tmpNode, dNode, 1);
							tmpNode = dNode;
						}
					}
				}
				addChildNode(parentNode, dn, at);
				document_.setModified();
				parentNode.ExpandAll();
			}
		}

		/// <summary>
		/// Add a case node to a union node.
		/// </summary>
		/// <param name="parentNode">must be a union node</param>
		/// <param name="at">position to insert the case node</param>
		public void addCaseNode(DataNode parentNode, int at)
		{
			FormCase formCase = new FormCase();
			formCase.DataTypeSource = document_.getTypeNames();
			string vname = "case-" + Convert.ToString(parentNode.Nodes.Count);
			formCase.VarName = vname;
			DialogResult r = formCase.ShowDialog(view_);
			if (r == DialogResult.OK)
			{
				string sDiscriminantVal = formCase.DiscriminantValue;
				string sBodyType = formCase.SelectedType;
				string sBodyVarName = formCase.VarName;
				CaseNode cn = new CaseNode(sDiscriminantVal, null);
				DataNode dcn = new DataNode(cn);
				addChildNode(dcn, sBodyType, sBodyVarName);
				//parentNode.Nodes.Insert(at, dcn);
				addChildNode(parentNode, dcn, at);
				parentNode.ExpandAll();
			}
		}

		/// <summary>
		/// Add a dim node to array node or another dim node, if one is available, it is replaced.
		/// </summary>
		/// <remarks>If parent node is the ArrayNode or DefineTypeNode of ArrayNode, then
		/// the new DimNode will replace the original DimNode which is then indented (demoted as the grandchild.
		/// If the parent node is a DimNode, then its child node is replaced and degraded, or if no child node
		/// exists, the new node is added as the child.</remarks>
		/// <param name="parentNode"></param>
		/// <param name="at"></param>
		public void addDimNode(DataNode parentNode, int at)
		{
			AbstractNode dNode = parentNode.getDataNode();
			if (dNode.GetType().Equals(typeof(DefineTypeNode)))
			{
				dNode = ((DefineTypeNode)dNode).getBaseType();
			}
			FormDim formDim = new FormDim();
			DialogResult r = formDim.ShowDialog(view_);
			if (r == DialogResult.OK)
			{
				string sdname = formDim.DimName;
				string scount = formDim.DimCount;
				DimNode dimNode = new DimNode(sdname, scount);
				((ComplexNode)dNode).insertChild(dimNode, 0);	//at irrelevant for array and dim node
				DataNode d = new DataNode(dimNode);
				DataNode old = (DataNode)parentNode.LastNode;
				if (old != null) 
				{
					parentNode.Nodes.Remove(old);
					d.Nodes.Add(old);
				}
				parentNode.Nodes.Add(d);
				parentNode.ExpandAll();
			}
		}

		/// <summary>
		/// Delete a selected node.
		/// </summary>
		/// <remarks>
		/// definitions and dataset: nop
		/// primitive:	delete
		/// complex:	delete
		/// useType:	delete
		/// case:		delete
		/// dim:		delete
		/// </remarks>
		/// <param name="theNode"></param>
		public void deleteNode(DataNode theNode)
		{
			DataNode parentNode = (DataNode)theNode.Parent;
			if (parentNode.getDataNode().isComplex())
			{
				ComplexNode aNode = (ComplexNode)parentNode.getDataNode();
				aNode.removeChild(parentNode.Nodes.IndexOf(theNode));
				if (theNode.getDataNode().GetType().Equals(typeof(DimNode))) 
				{
					//promote its child node if any
					DataNode childNode = (DataNode)theNode.FirstNode;
					parentNode.Nodes.Remove(theNode);
					if (childNode != null) 
					{
						parentNode.Nodes.Add(childNode);
					}
				} 
				else 
				{
					parentNode.Nodes.Remove(theNode);
				}
			}
		}

		/// <summary>
		/// Clear all data elements and create an empty document.
		/// </summary>
		/// <param name="root"></param>
		public void initializeTree(TreeNode root)
		{
			root.Nodes.Clear();
			document_.clear();
			//add definitions section node
			DefinitionsNode dn = document_.getDefinitions();
			root.Nodes.Add(new DataNode(dn));
			DatasetNode dsn = document_.getDataset();
			root.Nodes.Add(new DataNode(dsn));
			root.ExpandAll();
		}

		/// <summary>
		/// Method called by the MainForm class to populate a definition's treeview from a loaded document.
		/// </summary>
		/// <param name="root"></param>
		public void populateDataTree(TreeNode root)
		{
			root.Nodes.Clear();
			root.Nodes.Add(new DataNode(document_.getDefinitions()));
			root.Nodes.Add(new DataNode(document_.getDataset()));
			TreeNode defNode = root.Nodes[0];
			TreeNode datNode = root.Nodes[1];
			//fill in definitions
			foreach (DefineTypeNode ut in document_.getDefinitionsList())
			{
				DataNode dt = new DataNode(ut);
				defNode.Nodes.Add(dt);
				if (ut.isBaseStruct()) 
				{
					addStructNode(defNode.LastNode, (StructNode)ut.getBaseType());
				} 
				else if (ut.isBaseUnion())
				{
					addUnionNode(defNode.LastNode, (UnionNode)ut.getBaseType());
				} 
				else if (ut.isBaseArray())
				{
					addArrayNode(defNode.LastNode, (ArrayNode)ut.getBaseType());
				}
			}
			//fill in dataset
			foreach (AbstractNode it in document_.getDatasetList())
			{
				DataNode dt = new DataNode(it);
				datNode.Nodes.Add(dt);
				if (dt.isStruct()) 
				{
					addStructNode(datNode.LastNode, (StructNode)it);
				} 
				else if (dt.isUnion()) 
				{
					addUnionNode(datNode.LastNode, (UnionNode)it);
				} 
				else if (dt.isArray()) 
				{
					addArrayNode(datNode.LastNode, (ArrayNode)it);
				}
			}
			root.ExpandAll();
		}

		/// <summary>
		/// Add cases to a union node in the treeview from loaded document.
		/// </summary>
		/// <remarks>
		/// The TypeNode for UnionCase object node has null reference for DataNode.
		/// TODO: union containing arrays not supported here
		/// </remarks>
		/// <param name="node"></param>
		/// <param name="t"></param>
		protected void addUnionNode(TreeNode node, UnionNode t)
		{
			foreach (CaseNode c in t.getCases())
			{
				DataNode dt = new DataNode(c);
				node.Nodes.Add(dt);
				//node.LastNode.Text = c.toNodeText();
				AbstractNode caseBody = c.getCaseBody();
				TreeNode caseNode = node.LastNode;
				caseNode.Nodes.Add(new DataNode(caseBody));
				if (caseBody.isComplex()) 
				{
					if (caseBody.GetType().Equals(typeof(StructNode))) 
					{
						addStructNode(caseNode.LastNode, (StructNode)caseBody);
					}
					else if (caseBody.GetType().Equals(typeof(UnionNode)))
					{
						addUnionNode(caseNode.LastNode, (UnionNode)caseBody);
					}
					else if (caseBody.GetType().Equals(typeof(ArrayNode)))
					{
						addArrayNode(caseNode.LastNode, (ArrayNode)caseBody);
					}
				}
			}
		}

		/// <summary>
		/// Add array element to the array node in the treeview from loaded document.
		/// TODO: no support for array containing arrays or unions
		/// </summary>
		/// <param name="node"></param>
		/// <param name="t"></param>
		protected void addArrayNode(TreeNode node, ArrayNode t)
		{
			DataNode dt = new DataNode( t.getElement() );
			node.Nodes.Add(dt);
			if (t.getElement().isComplex()) 
			{
				ComplexNode ct = (ComplexNode)t.getElement();
				if (ct.GetType().Equals(typeof(StructNode))) 
				{
					addStructNode(node.LastNode, (StructNode)ct);
				}
				else if (ct.GetType().Equals(typeof(ArrayNode)))
				{
					addArrayNode(node.LastNode, (ArrayNode)ct);
				}
				else if (ct.GetType().Equals(typeof(UnionNode)))
				{
					addUnionNode(node.LastNode, (UnionNode)ct);
				}
			}
			// add dims
			DataNode lastNode = (DataNode)node;
			DimNode dim = t.getDimension();
			while (dim != null)
			{
				DataNode d = new DataNode(dim);
				lastNode.Nodes.Add(d);
				lastNode = d;
				dim = dim.getChild();
			}
		}

		/// <summary>
		/// Add struct members to a struct node in the treeview from loaded document.
		/// </summary>
		/// <param name="node"></param>
		/// <param name="t"></param>
		protected void addStructNode(TreeNode node, StructNode t)
		{
			foreach (AbstractNode it in t.getMembers())
			{
				DataNode dt = new DataNode(it);
				node.Nodes.Add(dt);
				if (it.isComplex()) 
				{
					if (it.GetType().Equals(typeof(StructNode)))
					{
						addStructNode(node.LastNode, (StructNode)it);
					} 
					else if (it.GetType().Equals(typeof(UnionNode)))
					{
						addUnionNode(node.LastNode, (UnionNode)it);
					} 
					else if (it.GetType().Equals(typeof(ArrayNode)))
					{
						addArrayNode(node.LastNode, (ArrayNode)it);
					}
				}
			}
		}

	}
}
