using System;

namespace BinxEd
{
	/// <summary>
	/// Define a Dimension class for ArrayType
	/// </summary>
	public class Dimension
	{
		private string name_;		//name of dimension
		private long count_;		//=indexTo + 1
		private Dimension child_;	//embedded dim

		public Dimension(string name, long count)
		{
			this.name_ = name;
			this.count_ = count;
		}

		/// <summary>
		/// Property to get or set the name of the dimension
		/// </summary>
		public string Name
		{
			get { return this.name_; }
			set { this.name_ = value; }
		}

		/// <summary>
		/// Property to get or set the count parameter for the dimension
		/// </summary>
		public long Count
		{
			get { return this.count_; }
			set { this.count_ = value; }
		}

		/// <summary>
		/// Property to get child dimension
		/// </summary>
		public Dimension Child
		{
			get { return this.child_; }
			set { this.child_ = value; }
		}

		/// <summary>
		/// Property to check whether this dimension has a child
		/// </summary>
		public bool HasChild
		{
			get { return this.child_ != null; }
		}

		/// <summary>
		/// Add a Dimension node to the leaf (lowest child)
		/// </summary>
		/// <param name="d"></param>
		public void AddDescendant(Dimension d)
		{
			Dimension p = this;
			while (p.HasChild) 
			{
				p = p.Child;
			}
			p.Child = d;
		}

		/// <summary>
		/// Format a stack of dim elements in a hierarchy
		/// </summary>
		/// <returns></returns>
		public string toXmlString()
		{
			string s = "<dim";
			if (name_ != null && name_.Length > 0) 
			{
				s += " name=\""+name_+"\"";
			}
			if (count_>0) 
			{
				s += " indexTo=\""+Convert.ToString(count_-1)+"\"";
			}
			s += ">";
			if (child_ != null) 
			{
				s += child_.toXmlString();
			}
			s += "</dim>";
			return s;
		}
	}

	/// <summary>
	/// Summary description for ArrayType.
	/// </summary>
	public class ArrayType : ComplexType
	{
		private IType element_;	//type of array element
		private Dimension dim_;	//link to a tree of dim elements
		private IType sizeRef_;	//type of size for variable-length arrays

		public ArrayType(string name) : base(name)
		{
		}

		/// <summary>
		/// Property to get or set element (type of array data)
		/// </summary>
		public IType Element
		{
			get { return element_; }
			set { element_ = value; }
		}

		/// <summary>
		/// Property to get or set sizeRef object
		/// </summary>
		public IType SizeRef
		{
			get { return sizeRef_; }
			set { sizeRef_ = value; }
		}

		/// <summary>
		/// Property to get or set dimension object
		/// </summary>
		public Dimension Dim
		{
			get { return dim_; }
			set { dim_ = value; }
		}

		/// <summary>
		/// Add a dimension to the array
		/// </summary>
		/// <param name="dname">name of dimension</param>
		/// <param name="dcount">count of dimension elements</param>
		public void AddDimension(string dname, long dcount)
		{
			Dimension d = new Dimension(dname, dcount);
			if (dim_ == null) 
			{
				dim_ = d;
			} 
			else 
			{
				dim_.AddDescendant(d);
			}
		}

		/// <summary>
		/// Format array into XML element
		/// </summary>
		/// <returns></returns>
		public override string toXmlString()
		{
			string s = "<"+Name;
			if (VarName != null && VarName.Length > 0) 
			{
				s += " varName=\""+VarName+"\"";
			}
			s += ">";
			if (sizeRef_ != null && isArrayVariable()) 
			{
				s += "<sizeRef>"+sizeRef_.toXmlString()+"</sizeRef>";
			}
			s += element_.toXmlString();
			s += dim_.toXmlString();
			s += "</"+Name+">";
			return s;
		}

		/// <summary>
		/// Text to show in a treeview node.
		/// array of type [][][]...
		/// </summary>
		/// <returns></returns>
		public override string toNodeText()
		{
			string s = Name;
			if (VarName != null && VarName.Length > 0) 
			{
				s = VarName + " : " + s;
			}
			if (sizeRef_ != null) 
			{
				s += "(" + sizeRef_.toNodeText() + ")";
			}
			for (Dimension d = dim_; d != null; d = d.Child) 
			{
				long cn = d.Count;
				if (cn > 0) 
				{
					s += "[" + Convert.ToString(cn) + "]";
				} 
				else 
				{
					s += "[]";
				}
			}
			return s;
		}
	}
}
