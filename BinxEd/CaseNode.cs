using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// Case of UnionType.
	/// </summary>
	public class CaseNode : ComplexNode
	{
		private string discriminantValue_;	//as a string
		private AbstractNode caseBody_;	//any type

		public CaseNode(string disVal, AbstractNode body) : base("case")
		{
			this.discriminantValue_ = disVal;
			this.caseBody_ = body;
		}

		/// <summary>
		/// Property to get or set discriminant value as string
		/// </summary>
		public string getDiscriminantValue()
		{
			return discriminantValue_;
		}

		/// <summary>
		/// get a case content as IType object
		/// </summary>
		public AbstractNode getCaseBody()
		{
			return caseBody_;
		}

		/// <summary>
		/// Overrided method actually to set the case body node.
		/// </summary>
		/// <param name="child"></param>
		/// <param name="at"></param>
		public override void insertChild(AbstractNode child, int at)
		{
			caseBody_ = child;
		}

		/// <summary>
		/// Format a union case into XML element
		/// </summary>
		/// <returns></returns>
		public override string toXmlString()
		{
			string s = "<case discriminantValue=\"" + this.discriminantValue_ + "\">";
			string s2 = caseBody_.toXmlString();
			return s + s2 + "</case>";
		}

		/// <summary>
		/// Text to show on a treeview node.
		/// </summary>
		/// <returns></returns>
		public override string toNodeText()
		{
			string s = "case "+discriminantValue_+":"; //+caseBody_.getTypeName();
			return s;
		}

/*		public override ArrayList validChildTypes()
		{
			return null;
		}
*/
		public override ArrayList validSiblingTypes()
		{
			ArrayList ar = new ArrayList(1);
			ar.Add("case");
			return ar;
		}

/* this is default		
 * public override bool canDelete()
		{
			return true;
		}*/

		public override ArrayList getProperties()
		{
			ArrayList props = new ArrayList();
			props.Add(new Property("value", 1, discriminantValue_));
			return props;
		}

		public override void setProperty(string propertyName, string propertyValue)
		{
			//base.setProperty (propertyName, propertyValue);
			if (propertyName.Equals("name"))
			{
				this.discriminantValue_ = propertyValue;
			}
		}


	}
}
