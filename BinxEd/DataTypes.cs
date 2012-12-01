using System;

namespace BinxEd
{
	/// <summary>
	/// Summary description for fixed Data Types.
	/// </summary>
	public class DataTypes
	{
		private string[] dataTypesPrimitive;
		private string[] dataTypesComplex;

		public DataTypes()
		{
			dataTypesPrimitive = new string[] {/*"bit-1",*/ "byte-8","short-16","integer-32","long-64",
												  "unsignedByte-8","unsignedShort-16","unsignedInteger-32","unsignedLong-64",
												  "character-8",/*"unicode-16","unicode-32",*/
												  "float-32","double-64",/*"extended-80","extended-96","quadruple-128",*/
			};
			dataTypesComplex = new string[] {"struct","union","array"/*,"arrayFixed","arrayVariable","arrayStreamed"*/};
		}

		public bool isPrimitive(string sType)
		{
			for (int i=0; i<dataTypesPrimitive.Length; i++) 
			{
				if (sType.Equals(dataTypesPrimitive[i])) 
				{
					return true;
				}
			}
			return false;
		}

		public bool isComplex(string sType)
		{
			for (int i=0; i<dataTypesComplex.Length; i++) 
			{
				if (sType.Equals(dataTypesComplex[i])) 
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Return arraylist of primitive types as strings
		/// </summary>
		public string[] getPrimitiveTypes()
		{
			return dataTypesPrimitive;
		}

		/// <summary>
		/// Return arraylist of complex types as strings
		/// </summary>
		public string[] getComplexTypes()
		{
			return dataTypesComplex;
		}

		public string[] getAllTypes()
		{
			string[] all = new string[dataTypesPrimitive.Length + dataTypesComplex.Length];
			int i = 0;
			for (; i<dataTypesPrimitive.Length; i++) 
			{
				all[i] = dataTypesPrimitive[i];
			}
			for (int j=0; j<dataTypesComplex.Length; j++, i++) 
			{
				all[i] = dataTypesComplex[j];
			}
			return all;
		}
	}
}
