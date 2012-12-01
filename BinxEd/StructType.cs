using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// The struct type
	/// </summary>
	public class StructType : ComplexType
	{
		private ArrayList elements_;	//list of elements contained in a struct

		public StructType() : base("struct")
		{
			elements_ = new ArrayList();
		}

		public StructType(string vname) : base("struct", vname)
		{
			elements_ = new ArrayList();
		}

		public StructType(string vname, int blocksize) : base("struct", vname, blocksize)
		{
			elements_ = new ArrayList();
		}

		/// <summary>
		/// Property to get number of struct members
		/// </summary>
		public int MemberCount
		{
			get { return elements_.Count; }
		}

		/// <summary>
		/// Property to get array of struct members
		/// </summary>
		public ArrayList Members
		{
			get { return elements_; }
		}

		/// <summary>
		/// Method to add an instance of member as IType derived class
		/// </summary>
		/// <param name="memberType"></param>
		public void AddMember(IType memberType)
		{
			elements_.Add(memberType);
		}

		/// <summary>
		/// Method to insert an instance of member at a given position
		/// </summary>
		/// <param name="index">position to insert the member</param>
		/// <param name="memberType">member object to be inserted</param>
		public void InsertMember(int index, IType memberType)
		{
			elements_.Insert(index, memberType);
		}

		/// <summary>
		/// Method to remove a member from the struct
		/// </summary>
		/// <param name="index"></param>
		public void RemoveMember(int index)
		{
			elements_.RemoveAt(index);
		}

		/// <summary>
		/// Method to query a member's type name by index
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public string MemberName(int index)
		{
			return ((IType)elements_[index]).Name;
		}

		/// <summary>
		/// Property to return an IType object of a member by index
		/// </summary>
		public IType this[int index]
		{
			get
			{
				return (IType)elements_[index];
			}
		}

		/// <summary>
		/// Make XML element for the struct.
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
			if (BlockSize > 0) 
			{
				s += " (blockSize=" + Convert.ToString(BlockSize) + ")";
			}
			foreach (IType it in elements_) 
			{
				s += it.toXmlString();
			}
			return s + "</"+Name+">";
		}

		/// <summary>
		/// Text to show in a treeview node
		/// </summary>
		/// <returns></returns>
		public override string toNodeText()
		{
			string s = "struct";
			if (VarName != null && VarName.Length > 0) 
			{
				s = VarName + " : struct";
			} 
			if (BlockSize > 0) 
			{
				s += " (blockSize=" + Convert.ToString(BlockSize) + ")";
			}
			return s;
		}
	}
}
