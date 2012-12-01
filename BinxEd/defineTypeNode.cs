using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// Summary description for defineTypeNode.
	/// </summary>
	public class DefineTypeNode : ComplexNode
	{
		private ComplexNode baseType_;	//struct, array or union possible

		public DefineTypeNode(string typeName) : base(typeName)
		{
		}

		public DefineTypeNode(string typeName, ComplexNode baseType) : base(typeName)
		{
			baseType_ = baseType;
		}

		/// <summary>
		/// Property to get or set baseType
		/// </summary>
		public ComplexNode getBaseType()
		{
			return baseType_;
		}

		public void setBaseType(ComplexNode bnode)
		{
			baseType_ = bnode;
		}

		public bool isBaseStruct()
		{
			if (baseType_ == null) return false;
			return baseType_.GetType().Equals(typeof(StructNode));
		}

		public bool isBaseUnion()
		{
			if (baseType_ == null) return false;
			return baseType_.GetType().Equals(typeof(UnionNode));
		}

		public bool isBaseArray()
		{
			if (baseType_ == null) return false;
			return baseType_.GetType().Equals(typeof(ArrayNode));
		}

		public override void setBigEndian(bool val)
		{ 
			base.setBigEndian(val);
			if (baseType_ != null) 
			{
				baseType_.setBigEndian(val); 
			}
		}
		/// <summary>
		/// Property to get or set block size for base type object
		/// TODO: necessary to put blocksize in this class?
		/// </summary>
		public override int getBlockSize()
		{
			return (baseType_==null)?0:baseType_.getBlockSize();
		}

		public override void setBlockSize(int val)
		{
			if (baseType_ != null) 
			{
				baseType_.setBlockSize( val ); 
			}
		}

		/// <summary>
		/// Make XML element for this user type.
		/// </summary>
		/// <returns></returns>
		public override string toXmlString()
		{
			if (baseType_ != null)
			{
				string s = "<defineType typeName=\""+ getTypeName() +"\">";
				s += baseType_.toXmlString();
				s += "</defineType>";
				return s;
			}
			return "";
		}

		/// <summary>
		/// Text to show in a treeview node
		/// </summary>
		/// <returns></returns>
		public override string toNodeText()
		{
			//string s = getTypeName();
			string s = "Type";
			string varName = getVarName();
			if (baseType_ != null) 
			{
				s = "Type '" + getTypeName() + "': " + baseType_.toNodeText();
			} 
			else if (varName != null && varName.Length > 0) 
			{
				s = varName + " : " + getTypeName();
			}
			return s;
		}

		public override ArrayList validChildTypes()
		{
			if (baseType_ == null)
			{
				return null;
			}
			return baseType_.validChildTypes();
		}

		public override ArrayList validSiblingTypes()
		{
			ArrayList ar = new ArrayList(1);
			ar.Add("define");
			return ar;
		}
		/*
				public override bool canDelete()
				{
					return true;
				}
		*/

		public override ArrayList getProperties()
		{
			ArrayList props = baseType_.getProperties ();
			foreach (Property p in props)
			{
				if ("varName".Equals(p.getName())) 
				{
					props.Remove(p);
					break;
				}
			}
			props.Insert(0, new Property("typeName", 1, getTypeName()));
			return props;
		}

		public override void setProperty(string propertyName, string propertyValue)
		{
			if (propertyName.Equals("typeName")) 
			{
				setTypeName(propertyValue);
			} 
			else 
			{
				baseType_.setProperty (propertyName, propertyValue);
			}
		}

	}
}
