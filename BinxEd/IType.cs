using System;

namespace BinxEd
{
	/// <summary>
	/// interface for all type definitions
	/// </summary>
	public interface IType
	{
		/// <summary>
		/// Property Name of the type
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// Property to tell if this type is a primitive type
		/// </summary>
		bool isPrimitive
		{
			get;
		}
		/// <summary>
		/// Property to tell if this type is a complex type
		/// </summary>
		bool isComplex
		{
			get;
		}
		/// <summary>
		/// Property to tell if this type is a user-defined type
		/// </summary>
		bool isUserDefined
		{
			get;
		}
		/// <summary>
		/// Property to get or set endianness, true=big endian, false=small endian
		/// </summary>
		bool BigEndian
		{
			get;
			set;
		}

		bool equals(IType it);
		bool equals(string its);

		string toXmlString();
		string toNodeText();
	}
}
