using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// Case of UnionType.
	/// </summary>
	public class UnionCase : IType
	{
		private string discriminantValue_;	//as a string
		private IType caseBody_;	//any type

		public UnionCase()
		{
		}
		public UnionCase(string disVal, IType body)
		{
			this.discriminantValue_ = disVal;
			this.caseBody_ = body;
		}

		/// <summary>
		/// Property to get or set discriminant value as string
		/// </summary>
		public string DiscriminantValue
		{
			get { return discriminantValue_; }
			set { discriminantValue_ = value; }
		}

		/// <summary>
		/// Property to get or set a case content as IType object
		/// </summary>
		public IType CaseBody
		{
			get { return caseBody_; }
			set { caseBody_ = value; }
		}

		/// <summary>
		/// Format a union case into XML element
		/// </summary>
		/// <returns></returns>
		public string toXmlString()
		{
			string s = "<case discriminantValue=\"" + this.discriminantValue_ + "\">";
			string s2 = caseBody_.toXmlString();
			return s + s2 + "</case>";
		}

		/// <summary>
		/// Text to show on a treeview node.
		/// </summary>
		/// <returns></returns>
		public string toNodeText()
		{
			string s = "case "+discriminantValue_+": "+caseBody_.Name;
			return s;
		}
		#region IType Members

		public string Name
		{
			get	{ return null; }
			set	{}
		}

		public bool isPrimitive
		{
			get	{ return false; }
		}

		public bool isComplex
		{
			get	{ return false;	}
		}

		public bool isUserDefined
		{
			get { return false;	}
		}

		public bool BigEndian
		{
			get	{ return false;	}
			set	{}
		}

		public bool equals(IType it)
		{
			return false;
		}

		bool BinxEd.IType.equals(string its)
		{
			return false;
		}

		#endregion
	}

	/// <summary>
	/// Summary description for UnionType.
	/// </summary>
	public class UnionType : ComplexType
	{
		private string discriminantType_;	//type name only
		private ArrayList cases_;	//list of case objects

		public UnionType() : base("union")
		{
			cases_ = new ArrayList();
		}

		/// <summary>
		/// Property to get or set the string of discriminant type.
		/// </summary>
		public string DiscriminantType
		{
			get { return discriminantType_; }
			set { this.discriminantType_ = value; }
		}

		/// <summary>
		/// Property to get array of union cases
		/// </summary>
		public ArrayList Cases
		{
			get { return cases_; }
		}

		/// <summary>
		/// Add a UnionCase instance
		/// </summary>
		/// <param name="c"></param>
		public void AddCase(UnionCase c)
		{
			cases_.Add(c);
		}

		/// <summary>
		/// Insert a case at position
		/// </summary>
		/// <param name="index"></param>
		/// <param name="c"></param>
		public void InsertCase(int index, UnionCase c)
		{
			cases_.Insert(index, c);
		}

		/// <summary>
		/// Remove a UnionCase from cases.
		/// </summary>
		/// <param name="c"></param>
		public void RemoveCase(UnionCase c)
		{
			cases_.Remove(c);
		}

		/// <summary>
		/// Remove a UnionCase from cases at the given position
		/// </summary>
		/// <param name="index"></param>
		public void RemoveCase(int index)
		{
			cases_.RemoveAt(index);
		}

		/// <summary>
		/// Method to get a UnionCase by index
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public UnionCase Case(int index)
		{
			return (UnionCase)cases_[index];
		}

		/// <summary>
		/// Format a whole union type into XML element
		/// </summary>
		/// <returns></returns>
		public override string toXmlString()
		{
			string s = "<"+Name;
			if (VarName != null && VarName.Length > 0) 
			{
				s += " varName=\""+VarName+"\">";
			} 
			else 
			{ 
				s += ">"; 
			}
			s += "<discriminant><" + discriminantType_ + "/></discriminant>";
			foreach (UnionCase c in cases_) 
			{
				s += c.toXmlString();
			}
			s += "</"+Name+">";
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
			if (VarName != null && VarName.Length > 0) 
			{
				s = VarName + " : " + s;
			}
			return s;
		}
	}
}
