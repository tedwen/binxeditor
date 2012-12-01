using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// Primitive types for the BinX definition section.
	/// </summary>
	public class PrimitiveNode : AbstractNode
	{
		public PrimitiveNode(string tname) : base(tname)
		{
		}

		public PrimitiveNode(string tname, string vname) : base(tname, vname)
		{
		}

		/// <summary>
		/// Property to tell if this type is a primitive type
		/// </summary>
		public override bool isPrimitive()
		{
			return true;
		}

		/// <summary>
		/// Make XML element for this primitive type.
		/// </summary>
		/// <returns></returns>
		public override string toXmlString()
		{
			string typeName = getTypeName();
			string varName = getVarName();
			string s = "<" + typeName;
			if (varName != null && varName.Length > 0) 
			{
				s += " varName=\""+varName+"\"";
			}
			if (hasByteOrder())
			{
				s += " byteOrder=\"" + getByteOrder() + "\"";
			}
			return s + "/>";
		}

		/// <summary>
		/// Text to show in a treeview node
		/// </summary>
		/// <returns></returns>
		public override string toNodeText()
		{
			string typeName = getTypeName();
			string varName = getVarName();
			if (varName != null && varName.Length > 0) 
			{
				return varName + " : " + typeName;
			} 
			else 
			{
				return typeName;
			}
		}
/*
		public override ArrayList validChildTypes()
		{
			return null;
		}
*/
		public override ArrayList validSiblingTypes()
		{
			ArrayList ar = new ArrayList(1);
			ar.Add("any");
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
			return base.getProperties ();
		}

	}
}
