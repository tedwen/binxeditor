using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// User-defined BinX type.
	/// </summary>
	public class UserType : IType
	{
		private string typeName_;	//as part of TreeNode.Text
		private string varName_;	//variable name for useType element
		private ComplexType baseType_;	//struct, array or union possible
		private bool bigEndian_;

		public UserType(string typeName)
		{
			this.typeName_ = typeName;
		}

		public UserType(string typeName, ComplexType baseType)
		{
			this.typeName_ = typeName;
			this.baseType_ = baseType;
		}

		/// <summary>
		/// Property Name of the user-defined type
		/// </summary>
		public string Name
		{
			get { return typeName_; }
			set { typeName_ = value; }
		}

		/// <summary>
		/// Property to get or set varName_
		/// </summary>
		public string VarName
		{
			get { return varName_; }
			set { varName_ = value; }
		}

		/// <summary>
		/// Property to get or set baseType
		/// </summary>
		public ComplexType BaseType
		{
			get { return baseType_; }
			set { baseType_ = value; }
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
			get { return false; }
		}
		/// <summary>
		/// Property to tell if this type is a user-defined type
		/// </summary>
		public bool isUserDefined
		{
			get { return true; }
		}
		/// <summary>
		/// Property to get or set endianness, true=big endian, false=small endian
		/// </summary>
		public bool BigEndian
		{
			get { return bigEndian_; }
			set { 
				bigEndian_ = value;
				if (baseType_ != null) 
				{
					baseType_.BigEndian = value; 
				}
			}
		}
		/// <summary>
		/// Property to get or set block size for base type object
		/// TODO: necessary to put blocksize in this class?
		/// </summary>
		public int BlockSize
		{
			get { return (baseType_==null)?0:baseType_.BlockSize; }
			set 
			{
				if (baseType_ != null) 
				{
					baseType_.BlockSize = value; 
				}
			}
		}

		/// <summary>
		/// Test whether the type name is equal to another type object
		/// </summary>
		/// <param name="it"></param>
		/// <returns></returns>
		public bool equals(IType it)
		{
			return typeName_.Equals(it.Name);
		}

		/// <summary>
		/// Test whether the type name is equal to the given string
		/// </summary>
		/// <param name="its"></param>
		/// <returns></returns>
		public bool equals(string its)
		{
			return typeName_.Equals(its);
		}

		/// <summary>
		/// Make XML element for this user type.
		/// </summary>
		/// <returns></returns>
		public string toXmlString()
		{
			if (baseType_==null) 
			{
				string s = "<useType typeName=\""+typeName_+"\"";
				if (varName_ != null && varName_.Length > 0) 
				{
					s += " varName=\""+varName_+"\"";
				}
				return s+"/>";
			} 
			else 
			{
				string s = "<defineType typeName=\""+typeName_+"\">";
				s += baseType_.toXmlString();
				s += "</defineType>";
				return s;
			}
		}

		/// <summary>
		/// Text to show in a treeview node
		/// </summary>
		/// <returns></returns>
		public string toNodeText()
		{
			string s = typeName_;
			if (baseType_ != null) 
			{
				if (baseType_.isArray()) 
				{
					s += " as " + baseType_.toNodeText();
				} 
				else 
				{
					s += " as " + baseType_.Name;
				}
			} 
			else if (varName_ != null && varName_.Length > 0) 
			{
				s = varName_ + " : " + typeName_;
			}
			return s;
		}
	}
}
