using System;
using System.Collections;
using System.Windows.Forms;

namespace BinxEd
{
	/// <summary>
	/// DataNode is a derived class from TreeNode, and is associated with an AbstractNode data object.
	/// </summary>
	public class DataNode : TreeNode
	{
		private AbstractNode dataNode_;

		public DataNode()
		{
		}

		public DataNode(AbstractNode dataNode)
		{
			this.dataNode_ = dataNode;
			this.Text = dataNode.toNodeText();
			this.ImageIndex = this.SelectedImageIndex = getImageIndex(dataNode);
		}

		/// <summary>
		/// Get image index for the node based on data type.
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		private int getImageIndex(AbstractNode node)
		{
			Type t = node.GetType();
			if (t==typeof(DefinitionsNode)) 
			{
				return 2;
			} 
			else if (t==typeof(DatasetNode)) 
			{
				return 3;
			}
			else if (t==typeof(PrimitiveNode))
			{
				return 4;
			}
			else if (t==typeof(StructNode))
			{
				return 5;
			}
			else if (t==typeof(ArrayNode))
			{
				return 6;
			} 
			else if (t==typeof(UnionNode)) 
			{
				return 7;
			}
			else if (t==typeof(UseTypeNode))
			{
				return 8;
			}
			else if (t==typeof(DefineTypeNode))
			{
				Type tb = ((DefineTypeNode)node).getBaseType().GetType();
				if (tb==typeof(StructNode)) 
				{
					return 5;
				}
				else if (tb==typeof(ArrayNode)) 
				{
					return 6;
				} 
				else if (tb==typeof(UnionNode)) 
				{
					return 7;
				}
			} 
			else if (t==typeof(DimNode))
			{
				return 9;
			}
			else if (t==typeof(CaseNode))
			{
				return 10;
			}
			return 0;
		}

		public AbstractNode getDataNode()
		{
			return dataNode_;
		}
		
		public void setDataNode(AbstractNode val)
		{
			dataNode_ = val;
			this.Text = dataNode_.toNodeText();
		}

		public bool isPrimitive()
		{
			return (dataNode_==null)?false:dataNode_.isPrimitive();
		}

		public bool isComplex()
		{
			return (dataNode_==null)?false:dataNode_.isComplex();
		}

		public bool isTypeDef()
		{
			return (dataNode_!=null)?dataNode_.GetType().Equals(typeof(DefineTypeNode)):false;
		}

		public bool isTypeUse()
		{
			return (dataNode_!=null)?dataNode_.GetType().Equals(typeof(UseTypeNode)):false;
		}
		
		public bool isDefinitions()
		{
			return (dataNode_!=null)?dataNode_.GetType().Equals(typeof(DefinitionsNode)):false;
		}
		
		public bool isDataset()
		{
			return dataNode_.GetType().Equals(typeof(DatasetNode));
		}
		
		public bool isStruct()
		{
			if (dataNode_ != null) 
			{
				if (dataNode_.GetType().Equals(typeof(DefineTypeNode))) 
				{
					return ((DefineTypeNode)dataNode_).getBaseType().GetType().Equals(typeof(StructNode));
				}
				return dataNode_.GetType().Equals(typeof(StructNode));
			}
			return false;
		}

		public bool isUnion()
		{
			if (dataNode_ != null) 
			{
				if (dataNode_.GetType().Equals(typeof(DefineTypeNode))) 
				{
					return ((DefineTypeNode)dataNode_).getBaseType().GetType().Equals(typeof(UnionNode));
				}
				return dataNode_.GetType().Equals(typeof(UnionNode));
			}
			return false;
		}

		public bool isArray()
		{
			if (dataNode_ != null) 
			{
				if (dataNode_.GetType().Equals(typeof(DefineTypeNode))) 
				{
					return ((DefineTypeNode)dataNode_).getBaseType().GetType().Equals(typeof(ArrayNode));
				}
				return dataNode_.GetType().Equals(typeof(ArrayNode));
			}
			return false;
		}

		/// <summary>
		/// Update text to be displayed on the tree node with the text from the Data node.
		/// </summary>
		public void updateText()
		{
			if (dataNode_ != null) 
			{
				this.Text = dataNode_.toNodeText();
			}
		}

		/// <summary>
		/// Test whether this node can be deleted, used to determine delete menu availability.
		/// </summary>
		/// <returns></returns>
		public bool canDelete()
		{
			return (dataNode_!=null)?dataNode_.canDelete():false;
		}

		/// <summary>
		/// Get a list of possible child node types for this node.
		/// </summary>
		/// <returns></returns>
		public ArrayList validChildTypes()
		{
			return (dataNode_!=null)?dataNode_.validChildTypes():null;
		}
		
		/// <summary>
		/// Get a list of possible sibling node types (struct,etc) for this node.
		/// </summary>
		/// <returns></returns>
		public ArrayList validSiblingTypes()
		{
			return (dataNode_!=null)?dataNode_.validSiblingTypes():null;
		}

		/// <summary>
		/// Get array list of properties for the data node.
		/// </summary>
		/// <returns></returns>
		public ArrayList getProperties()
		{
			if (dataNode_ != null) 
			{
				return dataNode_.getProperties();
			}
			return new ArrayList();
		}

		public void setProperty(string propertyName, string propertyValue)
		{
			if (dataNode_ != null) 
			{
				dataNode_.setProperty(propertyName, propertyValue);
			}
		}
	}
}
