using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// Summary description for ArrayType.
	/// </summary>
	public class ArrayNode : ComplexNode
	{
		private AbstractNode	element_;	//type of array element
		private DimNode			dim_;	//link to a tree of dim elements
		private AbstractNode	sizeRef_;	//type of size for variable-length arrays

		/// <summary>
		/// Construct with type name only for "arrayFixed","arrayVariable",and "arrayStreamed".
		/// </summary>
		/// <param name="typeName"></param>
		public ArrayNode(string typeName) : base(typeName)
		{
		}

		public ArrayNode(string typeName, string varName) : base(typeName, varName)
		{
		}

		public ArrayNode(string typeName, string varName, AbstractNode element) : base(typeName, varName)
		{
			element_ = element;
		}

		public bool isArrayVariable()
		{
			return getTypeName().Equals("arrayVariable");
		}

		public bool isArrayFixed()
		{
			return getTypeName().Equals("arrayFixed");
		}

		public bool isArrayStreamed()
		{
			return getTypeName().Equals("arrayStreamed");
		}

		/// <summary>
		/// get or set element (type of array data)
		/// </summary>
		public AbstractNode getElement()
		{
			return element_;
		}

		public void setElement(AbstractNode element)
		{
			element_ = element;
		}

		/// <summary>
		/// get or set sizeRef object
		/// </summary>
		public AbstractNode getSizeRef()
		{
			return sizeRef_;
		}

		public void setSizeRef(AbstractNode sizeRef)
		{
			sizeRef_ = sizeRef;
		}

		/// <summary>
		/// Property to get or set dimension object
		/// </summary>
		public DimNode getDimension()
		{
			return dim_;
		}

		public int getDimensionCount()
		{
			int count = 0;
			DimNode d = dim_;
			while (d != null) 
			{
				count ++;
				d = d.getChild();
			}
			return count;
		}

		public void setDimension(DimNode dim)
		{
			dim_ = dim;
		}

		/// <summary>
		/// Override insertChild to add only element node, dim node won't be added.
		/// </summary>
		/// <param name="child"></param>
		/// <param name="at"></param>
		public override void insertChild(AbstractNode child, int at)
		{
			if (!child.GetType().Equals(typeof(DimNode)))
			{
				setElement(child);
			} 
			else 
			{
				if (dim_ != null) 
				{
					((DimNode)child).setChild(dim_);
				}
				dim_ = (DimNode)child;
			}
		}

		public override void removeChild(int at)
		{
			//must be removing the dim child
			if (dim_ != null) 
			{
				dim_ = dim_.getChild();
			}
		}


		/// <summary>
		/// Add a dimension to the array
		/// </summary>
		/// <param name="dname">name of dimension</param>
		/// <param name="dcount">count of dimension elements</param>
		public DimNode addDimension(string dname, int dcount)
		{
			DimNode d = new DimNode(dname, dcount);
			if (dim_ == null) 
			{
				dim_ = d;
			} 
			else 
			{
				dim_.addDescendant(d);
			}
			return d;
		}

		public DimNode addDimension(string dname, string dcount)
		{
			if (dcount.Equals(""))
				dcount = "-1";
			try 
			{
				int ncount = Convert.ToInt32(dcount);
				return addDimension(dname, ncount);
			} 
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return null;
		}

		/// <summary>
		/// Format array into XML element
		/// </summary>
		/// <returns></returns>
		public override string toXmlString()
		{
			string s = "<"+getTypeName();
			string VarName = getVarName();
			if (VarName != null && VarName.Length > 0) 
			{
				s += " varName=\"" + VarName+"\"";
			}
			if (hasByteOrder())
			{
				s += " byteOrder=\"" + getByteOrder() + "\"";
			}
			if (hasBlockSize())
			{
				s += " blockSize=\"" + Convert.ToString(getBlockSize()) + "\"";
			}
			s += ">";
			if (sizeRef_ != null && isArrayVariable()) 
			{
				s += "<sizeRef>"+sizeRef_.toXmlString()+"</sizeRef>";
			}
			s += element_.toXmlString();
			s += dim_.toXmlString();
			s += "</" + getTypeName() + ">";
			return s;
		}

		/// <summary>
		/// Text to show in a treeview node.
		/// array of type [][][]...
		/// </summary>
		/// <returns></returns>
		public override string toNodeText()
		{
			string s = getTypeName();
			string VarName = getVarName();
			if (VarName != null && VarName.Length > 0) 
			{
				s = VarName + " : " + s;
			}
			if (sizeRef_ != null) 
			{
				s += "(" + sizeRef_.toNodeText() + ")";
			}
			return s;
		}

		public override ArrayList validChildTypes()
		{
			ArrayList ar = new ArrayList();
			ar.Add("dim");
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
			ArrayList props = base.getProperties();
			Property at = new Property("Array Type", 2, getTypeName());
			at.setOptions(new string[]{"arrayFixed","arrayVariable","arrayStreamed"});
			props.Add(at);
			return props;
		}

		public override void setProperty(string propertyName, string propertyValue)
		{
			base.setProperty (propertyName, propertyValue);
			if (propertyName.Equals("Array Type")) 
			{
				setTypeName(propertyValue);
				if (!propertyValue.Equals("arrayFixed"))
				{
					//check dim and set first count=0
					if (dim_ != null) 
					{
						dim_.setCount(0);
					}
				}
			}
		}

	}
}
