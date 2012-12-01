using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// Summary description for Definitions.
	/// </summary>
	public class Definitions
	{
		private ArrayList	definitions_;

		public Definitions()
		{
			definitions_ = new ArrayList();
		}

		public void clear()
		{
			definitions_.Clear();
		}

		public ArrayList getDefinitions()
		{
			return definitions_;
		}

		public int count()
		{
			return definitions_.Count;
		}

		public void add(DefineTypeNode node)
		{
			definitions_.Add(node);
		}

		public void remove(int index)
		{
			definitions_.RemoveAt(index);
		}

		public void remove(DefineTypeNode node)
		{
			definitions_.Remove(node);
		}

		public bool contains(DefineTypeNode node)
		{
			return definitions_.Contains(node);
		}

		public int indexOf(DefineTypeNode node)
		{
			return definitions_.IndexOf(node);
		}

		public void save(StreamWriter sw)
		{
		}

		public void import(string filepath)
		{
			Definitions exdefs = new Definitions();
			Parser.load(filepath, ref exdefs, null);
			//TODO: check duplicate typeNames
			definitions_.AddRange(exdefs);
		}
	}
}
