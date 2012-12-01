using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// User-defined BinX type.
	/// </summary>
	public class UseTypeNode : AbstractNode
	{
		private	int	blockSize_;

		public UseTypeNode(string typeName) : base(typeName)
		{
		}

		public UseTypeNode(string typeName, string varName) : base(typeName, varName)
		{
		}

		/// <summary>
		/// Property to get or set block size as int.
		/// </summary>
		public int getBlockSize()
		{
			return blockSize_;
		}

		public void setBlockSize(int blockSize)
		{
			blockSize_ = blockSize;
		}

		/// <summary>
		/// Make XML element for this user type.
		/// </summary>
		/// <returns></returns>
		public override string toXmlString()
		{
			string typeName = getTypeName();
			string varName = getVarName();
			string s = "<useType typeName=\""+typeName+"\"";
			if (varName != null && varName.Length > 0) 
			{
				s += " varName=\""+varName+"\"";
			}
			if (hasByteOrder())
			{
				s += " byteOrder=\"" + getByteOrder() + "\"";
			}
			if (blockSize_ > 0)
			{
				s += " blockSize=\"" + Convert.ToString(blockSize_) + "\"";
			}
			return s+"/>";
		}

		/// <summary>
		/// Text to show in a treeview node
		/// </summary>
		/// <returns></returns>
		public override string toNodeText()
		{
			string typeName = getTypeName();
			string varName = getVarName();
			string s = typeName;
			if (varName != null && varName.Length > 0) 
			{
				s = varName + " : " + typeName;
			}
			return s;
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
			ArrayList props = base.getProperties ();
			props.Add(new Property("blockSize", 1, Convert.ToString(blockSize_)));
			return props;
		}

		public override void setProperty(string propertyName, string propertyValue)
		{
			base.setProperty (propertyName, propertyValue);
			if (propertyName.Equals("blockSize")) 
			{
				try 
				{
					this.blockSize_ = Convert.ToInt32(propertyValue);
				} 
				catch (Exception ex) 
				{
					Console.WriteLine(ex.Message);
				}
			}
		}

	}
}
