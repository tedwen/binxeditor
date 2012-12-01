using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// Complex is a base class for all nodes that can contain child nodes.
	/// </summary>
	public class ComplexNode : AbstractNode
	{
		private int blockSize_;

		public ComplexNode(string tname) : base(tname)
		{
		}

		public ComplexNode(string tname, string vname) : base(tname, vname)
		{
		}

		public ComplexNode(string tname, string vname, int blocksize) : base(tname, vname)
		{
			this.blockSize_ = blocksize;
		}

		/// <summary>
		/// Property to tell if this type is a complex type
		/// </summary>
		public override bool isComplex()
		{
			return true;
		}

		protected bool hasBlockSize()
		{
			return blockSize_ > 0;
		}

		/// <summary>
		/// Property to get or set block size as int.
		/// </summary>
		public virtual int getBlockSize()
		{
			return blockSize_;
		}

		public virtual void setBlockSize(int blockSize)
		{
			blockSize_ = blockSize;
		}

		public virtual void addChild(AbstractNode child)
		{
		}

		public virtual void insertChild(AbstractNode child, int at)
		{
		}

		public virtual void removeChild(int at)
		{
		}

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
