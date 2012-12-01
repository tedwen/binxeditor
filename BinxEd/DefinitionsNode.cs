using System;
using System.IO;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// Node type for definitions element. No corresponding data type for this.
	/// </summary>
	public class DefinitionsNode : ComplexNode
	{
		private ArrayList	definitions_;

		public DefinitionsNode() : base("definitions")
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

		public override void addChild(AbstractNode child)
		{
			if (child.GetType().Equals(typeof(DefineTypeNode))) 
			{
				definitions_.Add(child);
			}
		}

		public override void insertChild(AbstractNode child, int at)
		{
			definitions_.Insert(at, child);
		}

		public override void removeChild(int at)
		{
			definitions_.RemoveAt(at);
		}

		public bool contains(DefineTypeNode node)
		{
			return definitions_.Contains(node);
		}

		public bool contains(string typeName)
		{
			foreach (DefineTypeNode dt in definitions_)
			{
				if (typeName.Equals(dt.getTypeName()))
				{
					return true;
				}
			}
			return false;
		}

		public int indexOf(DefineTypeNode node)
		{
			return definitions_.IndexOf(node);
		}

		public void save(StreamWriter sw)
		{
			sw.WriteLine("<definitions>");
			foreach (AbstractNode it in definitions_)
			{
				string s = it.toXmlString();
				sw.WriteLine(s);
			}
			sw.WriteLine("</definitions>");
		}

		/// <summary>
		/// Use parser to load a BinX document and merge all definitions from it. Note there may be duplicate type names after merge.
		/// </summary>
		/// <param name="filepath"></param>
		public void import(string filepath)
		{
			DefinitionsNode exdefs = new DefinitionsNode();
			Parser.loadDefinitions(filepath, ref exdefs);

			foreach (DefineTypeNode tp in exdefs.getDefinitions())
			{
				definitions_.Add(tp);
			}
//			definitions_.AddRange(exdefs.getDefinitions());
		}

		/// <summary>
		/// Format a whole union type into XML element
		/// </summary>
		/// <returns></returns>
		public override string toXmlString()
		{
			return "<definitions>";
		}

		/// <summary>
		/// Text to show in a treeview node
		/// union of byte-8
		/// union cases are shown as sub-nodes in treeview
		/// </summary>
		/// <returns></returns>
		public override string toNodeText()
		{
			return "Definitions";
		}

		public override ArrayList validChildTypes()
		{
			ArrayList ar = new ArrayList();
			ar.Add("define");
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
			return new ArrayList();	//empty properties
		}

	}
}
