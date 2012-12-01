using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// Summary description for UnionType.
	/// </summary>
	public class UnionNode : ComplexNode
	{
		private string discriminantType_;	//type name only
		private ArrayList cases_;	//list of case objects

		public UnionNode() : base("union")
		{
			cases_ = new ArrayList();
		}

		public UnionNode(string varName) : base("union", varName)
		{
			cases_ = new ArrayList();
		}

		/// <summary>
		/// Property to get or set the string of discriminant type.
		/// </summary>
		public string getDiscriminantType()
		{
			return discriminantType_;
		}

		public void setDiscriminantType(string disType)
		{
			discriminantType_ = disType;
		}

		/// <summary>
		/// Property to get array of union cases
		/// </summary>
		public ArrayList getCases()
		{
			return cases_;
		}

		public int getCaseCount()
		{
			return cases_.Count;
		}

		/// <summary>
		/// Add a UnionCase instance
		/// </summary>
		/// <param name="c"></param>
		public void addCase(CaseNode c)
		{
			cases_.Add(c);
		}

		/// <summary>
		/// Insert a case at position
		/// </summary>
		/// <param name="index"></param>
		/// <param name="c"></param>
		public void insertCase(int index, CaseNode c)
		{
			cases_.Insert(index, c);
		}

		/// <summary>
		/// Remove a UnionCase from cases.
		/// </summary>
		/// <param name="c"></param>
//		public void removeCase(CaseNode c)
//		{
//			cases_.Remove(c);
//		}

		/// <summary>
		/// Remove a UnionCase from cases at the given position
		/// </summary>
		/// <param name="index"></param>
		public void removeCase(int index)
		{
			cases_.RemoveAt(index);
		}

		/// <summary>
		/// Same as addCase
		/// </summary>
		/// <param name="child"></param>
		public override void addChild(AbstractNode child)
		{
			addCase((CaseNode)child);
		}
		/// <summary>
		/// Same as insertCase
		/// </summary>
		/// <param name="child"></param>
		/// <param name="at"></param>
		public override void insertChild(AbstractNode child, int at)
		{
			insertCase(at, (CaseNode)child);
		}
		/// <summary>
		/// Save as removeCase
		/// </summary>
		/// <param name="at"></param>
		public override void removeChild(int at)
		{
			removeCase(at);
		}

		/// <summary>
		/// Method to get a UnionCase by index
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public CaseNode getCase(int index)
		{
			return (CaseNode)cases_[index];
		}

		/// <summary>
		/// Format a whole union type into XML element
		/// </summary>
		/// <returns></returns>
		public override string toXmlString()
		{
			string typeName = getTypeName();
			string varName = getVarName();
			string s = "<" + typeName;
			if (varName != null && varName.Length > 0) 
			{
				s += " varName=\"" + varName+"\"";
			} 
			if (hasBlockSize()) 
			{ 
				s += " blockSize=\"" + Convert.ToString(getBlockSize()) + "\"";
			}
			s += ">";
			s += "<discriminant><" + discriminantType_ + "/></discriminant>";
			foreach (CaseNode c in cases_) 
			{
				s += c.toXmlString();
			}
			s += "</"+getTypeName()+">";
			return s;
		}

		/// <summary>
		/// Text to show in a treeview node
		/// union of byte-8
		/// union cases are shown as sub-nodes in treeview
		/// </summary>
		/// <returns></returns>
		public override string toNodeText()
		{
			string s = "union of " + discriminantType_;
			string VarName = getVarName();
			if (VarName != null && VarName.Length > 0) 
			{
				s = VarName + " : " + s;
			}
			return s;
		}

		public override ArrayList validChildTypes()
		{
			ArrayList ar = new ArrayList();
			ar.Add("case");
			return ar;
		}

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
			ArrayList props = base.getProperties ();
			Property p = new Property("discriminant", 2, discriminantType_);
			p.setOptions(new string[]{"byte-8","short-16","integer-32","long-64","unsignedShort-16","unsignedInteger-32","unsignedLong-64"});
			props.Add(p);
			return props;
		}

		public override void setProperty(string propertyName, string propertyValue)
		{
			base.setProperty (propertyName, propertyValue);
			if (propertyName.Equals("discriminant")) 
			{
				this.discriminantType_ = propertyValue;
			}
		}

	}
}
