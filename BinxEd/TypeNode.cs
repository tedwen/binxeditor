using System;
using System.Windows.Forms;

namespace BinxEd
{
	/// <summary>
	/// TypeNode is a wrapper for a TreeNode linking to an IType data object.
	/// </summary>
	public class TypeNode : TreeNode
	{
		private IType dataNode_;
		private StructType container_;	//struct, or null for root

		public TypeNode()
		{
		}

		public TypeNode(IType dataNode)
		{
			this.dataNode_ = dataNode;
			this.Text = dataNode.toNodeText();
		}

		public TypeNode(IType dataNode, StructType container)
		{
			this.dataNode_ = dataNode;
			this.container_ = container;
		}

		public IType DataNode
		{
			get { return dataNode_; }
			set 
			{
				dataNode_ = value;
				this.Text = dataNode_.toNodeText();
			}
		}

		public StructType Container
		{
			get { return container_; }
			set { container_ = value; }
		}

		public bool isPrimitive
		{
			get { return (dataNode_==null)?false:dataNode_.isPrimitive; }
		}

		public bool isComplex
		{
			get { return (dataNode_==null)?false:dataNode_.isComplex; }
		}

		public bool isUserDefined
		{
			get { return (dataNode_==null)?false:dataNode_.isUserDefined; }
		}

		public bool isStruct()
		{
			if (dataNode_ != null) 
			{
				if (dataNode_.isUserDefined) 
				{
					return ((UserType)dataNode_).BaseType.isStruct();
				}
				if (dataNode_.isComplex) 
				{
					return ((ComplexType)dataNode_).isStruct();
				}
			}
			return false;
		}

		public bool isUnion()
		{
			if (dataNode_ != null) 
			{
				if (dataNode_.isUserDefined) 
				{
					return ((UserType)dataNode_).BaseType.isUnion();
				}
				if (dataNode_.isComplex) 
				{
					return ((ComplexType)dataNode_).isUnion();
				}
			}
			return false;
		}

		public bool isArray()
		{
			if (dataNode_ != null) 
			{
				if (dataNode_.isUserDefined) 
				{
					return ((UserType)dataNode_).BaseType.isArray();
				}
				if (dataNode_.isComplex) 
				{
					return ((ComplexType)dataNode_).isArray();
				}
			}
			return false;
		}
	}
}
