using System;

namespace BinxEd
{
	/// <summary>
	/// Primitive types for the BinX definition section.
	/// </summary>
	public class PrimitiveType : IType
	{
		private string name_;		//type name itself, like byte-8, long-64
		private string varname_;	//variable name defined for this type if any
		private bool bigEndian_;

		public PrimitiveType(string name)
		{
			this.name_ = name;
		}
		public PrimitiveType(string name, string vname)
		{
			this.name_ = name;
			this.varname_ = vname;
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
			get { return true; }
		}
		/// <summary>
		/// Property to tell if this type is a complex type
		/// </summary>
		public bool isComplex
		{
			get { return false; }
		}
		/// <summary>
		/// Property to tell if this type is a user-defined type
		/// </summary>
		public bool isUserDefined
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
		/// Test whether the type name is equal to another type object
		/// </summary>
		/// <param name="it"></param>
		/// <returns></returns>
		public bool equals(IType it)
		{
			return name_.Equals(it.Name);
		}

		/// <summary>
		/// Test whether the type name is equal to the given string
		/// </summary>
		/// <param name="its"></param>
		/// <returns></returns>
		public bool equals(string its)
		{
			return name_.Equals(its);
		}

		/// <summary>
		/// Make XML element for this primitive type.
		/// </summary>
		/// <returns></returns>
		public string toXmlString()
		{
			if (varname_ == null || varname_.Length < 1) 
			{
				return "<"+name_+"/>";
			}
			else 
			{
				return "<"+name_+" varName=\""+varname_+"\"/>";
			}
		}

		/// <summary>
		/// Text to show in a treeview node
		/// </summary>
		/// <returns></returns>
		public string toNodeText()
		{
			if (varname_ != null && varname_.Length > 0) 
			{
				return varname_ + " : " + name_;
			} 
			else 
			{
				return name_;
			}
		}
	}
}
