using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// Interface for all nodes.
	/// </summary>
	public interface INode
	{
		/// <summary>
		/// Property Name of the type
		/// </summary>
		string getTypeName();
		void setTypeName(string tname);
		string getVarName();
		void setVarName(string vname);

		/// <summary>
		/// Property to tell if this type is a primitive type
		/// </summary>
		bool isPrimitive();

		/// <summary>
		/// Property to tell if this type is a complex type
		/// </summary>
		bool isComplex();

		bool equals(INode it);
		bool equals(string its);

		string toXmlString();
		string toNodeText();

		ArrayList validChildTypes();
		ArrayList validSiblingTypes();
		bool canDelete();

		ArrayList getProperties();
		void setProperty(string propertyName, string propertyValue);

	}
}
