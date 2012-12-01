using System;

namespace BinxEd
{
	/// <summary>
	/// Summary description for Complex.
	/// </summary>
	public class ComplexType : IType
	{
		private string name_;
		private string varname_;	//variable name defined for this type if any
		private int blockSize_;
		private bool bigEndian_;

		public ComplexType(string name)
		{
			this.name_ = name;
		}

		public ComplexType(string tname, string vname)
		{
			this.name_ = tname;
			this.varname_ = vname;
		}

		public ComplexType(string tname, string vname, int blocksize)
		{
			this.name_ = tname;
			this.varname_ = vname;
			this.blockSize_ = blocksize;
		}

		/// <summary>
		/// Property Name of the type
		/// </summary>
		public string Name
		{
			get { return name_; }
			set { name_ = value; }
		}
		/// <summary>
		/// Property VarName as variable name
		/// </summary>
		public string VarName
		{
			get { return varname_; }
			set { varname_ = value; }
		}
		/// <summary>
		/// Property to tell if this type is a primitive type
		/// </summary>
		public bool isPrimitive
		{
			get { return false; }
		}
		/// <summary>
		/// Property to tell if this type is a complex type
		/// </summary>
		public bool isComplex
		{
			get { return true; }
		}
		/// <summary>
		/// Property to tell if this type is a user-defined type
		/// </summary>
		public virtual bool isUserDefined
		{
			get { return false; }
		}
		/// <summary>
		/// Property to get or set endianness, true=big endian, false=small endian
		/// </summary>
		public bool BigEndian
		{
			get { return bigEndian_; }
			set { bigEndian_ = value; }
		}

		/// <summary>
		/// Property to get or set block size as int.
		/// </summary>
		public int BlockSize
		{
			get { return blockSize_; }
			set { blockSize_ = value; }
		}

		public bool isStruct()
		{
			return name_.Equals("struct");
		}
		public bool isArray()
		{
			return name_.StartsWith("array");
		}
		public bool isUnion()
		{
			return name_.Equals("union");
		}
		public bool isArrayFixed()
		{
			return name_.Equals("arrayFixed");
		}
		public bool isArrayVariable()
		{
			return name_.Equals("arrayVariable");
		}
		public bool isArrayStreamed()
		{
			return name_.Equals("arrayStreamed");
		}

		/// <summary>
		/// Test whether the type name is equal to another type object
		/// </summary>
		/// <param name="it"></param>
		/// <returns></returns>
		public virtual bool equals(IType it)
		{
			return name_.Equals(it.Name);
		}

		/// <summary>
		/// Test whether the type name is equal to the given string
		/// </summary>
		/// <param name="its"></param>
		/// <returns></returns>
		public virtual bool equals(string its)
		{
			return name_.Equals(its);
		}

		/// <summary>
		/// Make XML element for this primitive type.
		/// </summary>
		/// <returns></returns>
		public virtual string toXmlString() 
		{
			return "";
		}

		/// <summary>
		/// Text to show in a treeview node.
		/// </summary>
		/// <returns></returns>
		public virtual string toNodeText()
		{
			return "";
		}
	}
}
