using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// Abstract node to implement INode interface as a base for all type-related node classes.
	/// </summary>
	public abstract class AbstractNode : INode
	{
		private string	typeName_;
		private string	varName_;
		private	string	byteOrder_;

		public AbstractNode(string tname)
		{
			typeName_ = tname;
		}

		public AbstractNode(string tname, string vname)
		{
			typeName_ = tname;
			varName_ = vname;
		}

		protected string getByteOrder()
		{
			return byteOrder_;
		}

		protected bool hasByteOrder()
		{
			return (byteOrder_!=null) && !byteOrder_.Equals("default");
		}

		public void setByteOrder(string byteOrder)
		{
			this.byteOrder_ = byteOrder;
		}

		/// <summary>
		/// Set it virtual for DefineTypeNode to override.
		/// </summary>
		/// <param name="big"></param>
		public virtual void setBigEndian(bool big)
		{
			this.byteOrder_ = (big)?"bigEndian":"littleEndian";
		}

		/// <summary>
		/// Helper method to test whether the node is big-endian.
		/// </summary>
		/// <returns></returns>
		public bool isBigEndian()
		{
			return "bigEndian".Equals(this.byteOrder_);
		}

		#region INode Members

		public string getTypeName()
		{
			return typeName_;
		}

		public void setTypeName(string tname)
		{
			typeName_ = tname;
		}

		public string getVarName()
		{
			return varName_;
		}

		public void setVarName(string vname)
		{
			varName_ = vname;
		}

		public virtual bool isPrimitive()
		{
			return false;
		}

		public virtual bool isComplex()
		{
			return false;
		}

		public virtual bool equals(INode it)
		{
			return false;
		}

		public virtual bool equals(string its)
		{
			return false;
		}

		public virtual string toXmlString()
		{
			return null;
		}

		public virtual string toNodeText()
		{
			return null;
		}

		public virtual ArrayList validChildTypes()
		{
			return null;
		}

		public virtual ArrayList validSiblingTypes()
		{
			return null;
		}

		public virtual bool canDelete()
		{
			return true;
		}

		public virtual ArrayList getProperties()
		{
			ArrayList props = new ArrayList();
//			props.Add(new Property("typeName", 1, typeName_));	//only defineType node needs this
			props.Add(new Property("varName", 1, varName_));
			addByteOrderProperty(props);
			return props;
		}

		public virtual void setProperty(string propertyName, string propertyValue)
		{
			if (propertyName.Equals("typeName"))
			{
				this.typeName_ = propertyValue;
			} 
			else if (propertyName.Equals("varName"))
			{
				this.varName_ = propertyValue;
			} 
			else if (propertyName.Equals("byteOrder"))
			{
				this.byteOrder_ = propertyValue;
			}
		}

		#endregion

		protected void addByteOrderProperty(ArrayList props)
		{
			Property p = new Property("byteOrder", 2, byteOrder_);
			p.setOptions(new string[]{"default","bigEndian","littleEndian"});
			props.Add(p);
		}

	}
}
