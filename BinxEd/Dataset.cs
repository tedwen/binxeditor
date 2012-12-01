using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// Class to hold all data elements in the dataset section of a BinX document.
	/// </summary>
	public class Dataset
	{
		private ArrayList dataset_;
		private string datasetSrc_;
		private bool bigEndian_;

		public Dataset()
		{
			dataset_ = new ArrayList();
		}

		public string getBinaryFileName()
		{
			return datasetSrc_;
		}

		public void setBinaryFileName(string src)
		{
			datasetSrc_ = src;
		}

		public bool isBigEndian()
		{
			return bigEndian_;
		}

		public void setBigEndian(bool big)
		{
			bigEndian_ = big;
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

		public void add(AbstractNode node)
		{
			dataset_.Add(node);
		}

		public void remove(int index)
		{
			dataset_.RemoveAt(index);
		}

		public void remove(AbstractNode node)
		{
			dataset_.RemoveAt(node);
		}

		public void insert(int index, AbstractNode node)
		{
			dataset_.Insert(index, node);
		}
	}
}
