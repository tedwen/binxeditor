using System;
using System.IO;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// Class for node of dataset. It's not a data type.
	/// </summary>
	public class DatasetNode : ComplexNode
	{
		private ArrayList dataset_;
		private string datasetSrc_;

		public DatasetNode() : base("dataset")
		{
			dataset_ = new ArrayList();
			setBigEndian(false);
		}

		public string getBinaryFileName()
		{
			return datasetSrc_;
		}

		public void setBinaryFileName(string src)
		{
			datasetSrc_ = src;
		}

		public ArrayList getDataset()
		{
			return dataset_;
		}

		public int count()
		{
			return dataset_.Count;
		}

		public void clear()
		{
			dataset_.Clear();
		}

		public override void insertChild(AbstractNode child, int at)
		{
			dataset_.Insert(at, child);
		}

		public override void removeChild(int at)
		{
			dataset_.RemoveAt(at);
		}

		public override void addChild(AbstractNode node)
		{
			dataset_.Add(node);
		}

		public void save(StreamWriter sw)
		{
			sw.WriteLine(this.toXmlString());
			foreach (AbstractNode it in dataset_)
			{
				string s = it.toXmlString();
				sw.WriteLine(s);
			}
			sw.WriteLine("</dataset>");
		}

		/// <summary>
		/// Format a whole union type into XML element
		/// </summary>
		/// <returns></returns>
		public override string toXmlString()
		{
			string s = "<dataset";
			if (datasetSrc_ != null && datasetSrc_.Length > 0) 
			{
				s += " src=\"" + datasetSrc_ + "\"";
			}
			s += " byteOrder=\"" + getByteOrder() + "\">";
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
			string s = "Dataset";
			if (datasetSrc_ != null && datasetSrc_.Length > 0)
			{
				s += " in file:" + datasetSrc_;
			}
			s += " [" + getByteOrder() + "]";
			return s;
		}

		public override ArrayList validChildTypes()
		{
			ArrayList ar = new ArrayList();
			ar.Add("any");
			return ar;
		}
/*
		public override ArrayList validSiblingTypes()
		{
			return null;
		}
*/
		public override bool canDelete()
		{
			return false;
		}

		public override ArrayList getProperties()
		{
			ArrayList props = new ArrayList();
			props.Add(new Property("src", 1, datasetSrc_));
			addByteOrderProperty(props);
			return props;
		}

		public override void setProperty(string propertyName, string propertyValue)
		{
			//base.setProperty (propertyName, propertyValue);
			if (propertyName.Equals("src")) 
			{
				this.datasetSrc_ = propertyValue;
			} 
			else if (propertyName.Equals("byteOrder")) 
			{
				setBigEndian(propertyValue.Equals("bigEndian"));
			}
		}

	}
}
