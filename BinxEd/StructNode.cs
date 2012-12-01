using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// Data node for struct type.
	/// </summary>
	public class StructNode : ComplexNode
	{
		private ArrayList elements_;	///list of elements contained in a struct

		public StructNode() : base("struct")
		{
			elements_ = new ArrayList();
		}

		public StructNode(string vname) : base("struct", vname)
		{
			elements_ = new ArrayList();
		}

		public StructNode(string vname, int blocksize) : base("struct", vname, blocksize)
		{
			elements_ = new ArrayList();
		}

		/// <summary>
		/// Property to get number of struct members
		/// </summary>
		public int getMemberCount()
		{
			return elements_.Count;
		}

		/// <summary>
		/// Property to get array of struct members
		/// </summary>
		public ArrayList getMembers()
		{
			return elements_;
		}

		/// <summary>
		/// Method to add an instance of member as IType derived class
		/// </summary>
		/// <param name="memberType"></param>
		public override void addChild(AbstractNode memberType)
		{
			elements_.Add(memberType);
		}

		/// <summary>
		/// Method to insert an instance of member at a given position
		/// </summary>
		/// <param name="child">member object to be inserted</param>
		/// <param name="at">position to insert the member</param>
		public override void insertChild(AbstractNode child, int at)
		{
			elements_.Insert(at, child);
		}

		/// <summary>
		/// Method to remove a member from the struct
		/// </summary>
		/// <param name="index"></param>
		public override void removeChild(int index)
		{
			elements_.RemoveAt(index);
		}

		/// <summary>
		/// Method to query a member's type name by index
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public string getMemberTypeName(int index)
		{
			return ((AbstractNode)elements_[index]).getTypeName();
		}

		/// <summary>
		/// Property to return an AbstractNode object of a member by index
		/// </summary>
		public AbstractNode getMember(int index)
		{
			return (AbstractNode)elements_[index];
		}

		/// <summary>
		/// Make XML element for the struct.
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
			foreach (AbstractNode it in elements_) 
			{
				s += it.toXmlString();
			}
			return s + "</"+typeName+">";
		}

		/// <summary>
		/// Text to show in a treeview node
		/// </summary>
		/// <returns></returns>
		public override string toNodeText()
		{
			string varName = getVarName();
			string s = "struct";
			if (varName != null && varName.Length > 0) 
			{
				s = varName + " : struct";
			} 
			if (getBlockSize() > 0) 
			{
				s += " (blockSize=" + Convert.ToString(getBlockSize()) + ")";
			}
			return s;
		}

		public override ArrayList validChildTypes()
		{
			ArrayList ar = new ArrayList();
			ar.Add("any");
			return ar;
		}

		public override ArrayList validSiblingTypes()
		{
			ArrayList ar = new ArrayList(1);
			ar.Add("any");
			return ar;
		}

		public override ArrayList getProperties()
		{
			return base.getProperties ();
		}

	}
}
