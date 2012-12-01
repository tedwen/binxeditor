using System;
using System.IO;
using System.Xml;
using System.Collections;
using System.Windows.Forms;

namespace BinxEd
{
	/// <summary>
	/// The model class for the BinX document as a container to hold all its elements, and it also provides
	/// basic operations such as loading, saving for access by the controller.
	/// </summary>
	public class Document
	{
		private DataTypes dataTypes_;

		private string filePath_;

		private const string sXMLHeader = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
		private const string sBinXHeader = "<binx xmlns=\"http://www.edikt.org/binx/2003/06/binx\">";

		private DefinitionsNode definitions_;
		private DatasetNode dataset_;

		private bool modified_; 

		public Document()
		{
			dataTypes_ = new DataTypes();
			definitions_ = new DefinitionsNode();
			dataset_ = new DatasetNode();
		}

		public Document(string sFilePath)
		{
			this.filePath_ = sFilePath;
			dataTypes_ = new DataTypes();
			definitions_ = new DefinitionsNode();
			dataset_ = new DatasetNode();
		}

		/// <summary>
		/// Property to get or set DataTypes object for primitive/complex types
		/// </summary>
		public DataTypes getDataTypes()
		{
			return this.dataTypes_;
		}

		public bool isTypeDefined(string typeName)
		{
			return definitions_.contains(typeName);
		}

		public string[] getPrimitiveTypeNames()
		{
			return dataTypes_.getPrimitiveTypes();
		}

		public string[] getUserDefinedTypeNames()
		{
			string[] defs = new string[definitions_.count()];
			int i = 0;
			foreach (DefineTypeNode tp in definitions_.getDefinitions())
			{
				defs[i++] = tp.getTypeName();
			}
			return defs; //userTypes_.getUserTypeNames();
		}

		/// <summary>
		/// Get all primitive and user-defined type names
		/// </summary>
		/// <returns></returns>
		public string[] getTypeNames()
		{
			string[] allTypes = dataTypes_.getAllTypes();
			int n = allTypes.Length + definitions_.count();
			string[] sa = new string[n];
			int i = 0;
			while (i < allTypes.Length)
			{
				sa[i] = allTypes[i];
				i ++;
			}
			foreach (DefineTypeNode tp in definitions_.getDefinitions())
			{
				sa[i++] = tp.getTypeName();
			}
			return sa;
		}

		public DefinitionsNode getDefinitions()
		{
			return definitions_;
		}

		public ArrayList getDefinitionsList()
		{
			return definitions_.getDefinitions();
		}

		public void addDefinition(DefineTypeNode node)
		{
			definitions_.addChild(node);
		}

		public void removeDefinition(int index)
		{
			definitions_.removeChild(index);
		}

		public DatasetNode getDataset()
		{
			return dataset_;
		}

		public ArrayList getDatasetList()
		{
			return dataset_.getDataset();
		}

		public void addDataset(AbstractNode node)
		{
			dataset_.addChild(node);
		}

		public void removeDataset(int index)
		{
			dataset_.removeChild(index);
		}

		/// <summary>
		/// Property to get or set modified flag
		/// </summary>
		public bool isModified()
		{
			return modified_;
		}

		public void setModified()
		{
			modified_ = true;
		}

		/// <summary>
		/// Property to get or set big endian
		/// </summary>
		public bool isBigEndian()
		{
			return dataset_.isBigEndian();
		}

		public void setBigEndian(bool big)
		{
			dataset_.setBigEndian(big);
		}

		/// <summary>
		/// Property to get filePath
		/// </summary>
		public string getFilePath()
		{
			return filePath_;
		}

		public void setFilePath(string filePath)
		{
			filePath_ = filePath;
		}

		/// <summary>
		/// Save BinX into file.
		/// </summary>
		public void save()
		{
			StreamWriter sr = File.CreateText(filePath_);
			sr.WriteLine(sXMLHeader);
			sr.WriteLine(sBinXHeader);
			if (definitions_.count() > 0) 
			{
				definitions_.save(sr);
			}
			dataset_.save(sr);
			sr.WriteLine("</binx>");
			sr.Close();
			modified_ = false;
		}

		/// <summary>
		/// Save BinX definitions and dataset into a specified file.
		/// </summary>
		/// <param name="sFilename"></param>
		public void save(string sFilename)
		{
			this.filePath_ = sFilename;
			dataset_.setBinaryFileName(filePath_);
			save();
		}

		/// <summary>
		/// Clear document content
		/// </summary>
		public void clear()
		{
			modified_ = false;
			definitions_.clear();
			dataset_.clear();
			this.filePath_ = null;
		}

		/// <summary>
		/// Load a BinX document from specified file.
		/// </summary>
		/// <param name="filepath"></param>
		/// <returns></returns>
		public bool load(string filepath)
		{
			clear();
			this.filePath_ = filepath;
			return Parser.load(filePath_, ref definitions_, ref dataset_);;
		}

		/// <summary>
		/// Make a string for the dataset text.
		/// </summary>
		/// <returns></returns>
		public string getDatasetNodeText()
		{
			return dataset_.toNodeText();
		}

		/// <summary>
		/// Whether doc contains nothing
		/// </summary>
		public bool isEmpty()
		{
			return (definitions_.count() <= 0) && (dataset_.count() <= 0);
		}
	}
}
