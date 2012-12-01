using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// Summary description for DimNode.
	/// </summary>
	public class DimNode : ComplexNode
	{
		private string name_;		//name of dimension
		private int count_;		//=indexTo + 1
		private DimNode child_;	//embedded dim

		public DimNode(string name, int count) : base("dim")
		{
			this.name_ = name;
			this.count_ = count;
			this.child_ = null;
		}

		public DimNode(string name, string scount) : base("dim")
		{
			this.name_ = name;
			try 
			{
				this.count_ = Convert.ToInt32(scount);
			} 
			catch (Exception ex) 
			{
				Console.WriteLine(ex.Message);
			}
			this.child_ = null;
		}

		/// <summary>
		/// Property to get or set the name of the dimension
		/// </summary>
		public string getDimName()
		{
			return this.name_;
		}

		public void setDimName(string name)
		{
			this.name_ = name;
		}

		/// <summary>
		/// Property to get or set the count parameter for the dimension
		/// </summary>
		public int count()
		{
			return this.count_;
		}

		public void setCount(int count)
		{
			this.count_ = count;
		}

		/// <summary>
		/// Property to get child dimension
		/// </summary>
		public DimNode getChild()
		{
			return this.child_;
		}

		public void setChild(DimNode node)
		{
			this.child_ = node;
		}

		/// <summary>
		/// Property to check whether this dimension has a child
		/// </summary>
		public bool hasChild()
		{
			return this.child_ != null;
		}

		/// <summary>
		/// Add or replace a child DimNode to this one, demote its child if available.
		/// </summary>
		/// <remarks>A DimNode can have only one child DimNode node. When this DimNode already has a child DimNode,
		/// the new child DimNode is set as the only child node and the old child node becomes the child node of the
		/// added child node (grandchild of this node). Note that if the given child node already has a child node,
		/// it will be lost in this case.</remarks>
		/// <param name="child"></param>
		public override void addChild(AbstractNode child)
		{
			if (child.GetType().Equals(typeof(DimNode)))
			{
				DimNode c = this.child_;
				this.child_ = (DimNode)child;
				if (c != null) 
				{
					this.child_.setChild(c);
				}
			}
		}

		/// <summary>
		/// Insert child DimNode as the only child node with position ignored, same as addChild.
		/// </summary>
		/// <param name="child"></param>
		/// <param name="at">ignored here</param>
		public override void insertChild(AbstractNode child, int at)
		{
			addChild(child);
//			if (child.GetType().Equals(typeof(DimNode)))
//			{
//				setChild((DimNode)child);
//			}
		}

		/// <summary>
		/// Remove the only child node and promote the child's child node.
		/// </summary>
		/// <param name="at">ignored here</param>
		public override void removeChild(int at)
		{
			DimNode d = this.child_;
			if (d != null) 
			{
				this.child_ = d.getChild();
			}
		}


		/// <summary>
		/// Add a Dimension node to the leaf (lowest child)
		/// </summary>
		/// <param name="d"></param>
		public void addDescendant(DimNode d)
		{
			if (child_ != null) 
			{
				child_.addDescendant(d);
			} 
			else 
			{
				child_ = d;
			}
		}

		/// <summary>
		/// Format a stack of dim elements in a hierarchy
		/// </summary>
		/// <returns></returns>
		public override string toXmlString()
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
				Console.WriteLine("DimNode.toXmlString {0}", s);
				s += child_.toXmlString();
			}
			s += "</dim>";
			return s;
		}

		/// <summary>
		/// Format a string for display in the document treeview.
		/// </summary>
		/// <returns></returns>
		public override string toNodeText()
		{
			string s = "Dimension";
			if (name_ != null && name_.Length > 0)
			{
				s += " " + name_;
			}
			if (count_ > 0)
			{
				s += " [" + Convert.ToString(count_) + "]";
			}
			return s;
		}


		public override ArrayList validChildTypes()
		{
			ArrayList ar = new ArrayList();
			ar.Add("dim");
			return ar;
		}
/*
		public override ArrayList validSiblingTypes()
		{
			return null;
		}

		public override bool canDelete()
		{
			return true;
		}
*/

		public override ArrayList getProperties()
		{
			ArrayList props = new ArrayList();
			props.Add(new Property("name", 1, name_));
			props.Add(new Property("count", 1, Convert.ToString(count_)));
			return props;
		}

		public override void setProperty(string propertyName, string propertyValue)
		{
			//base.setProperty (propertyName, propertyValue);
			if (propertyName.Equals("name")) 
			{
				this.name_ = propertyValue;
			} 
			else if (propertyName.Equals("count")) 
			{
				try 
				{
					this.count_ = Convert.ToInt32(propertyValue);
				} 
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}

	}
}
