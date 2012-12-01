using System;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// Summary description for UserTypes.
	/// </summary>
	public class UserTypes
	{
		private ArrayList userTypes_;

		public UserTypes()
		{
			userTypes_ = new ArrayList();
		}

		/// <summary>
		/// Test whether the given type string exists in the complex data type array.
		/// </summary>
		/// <param name="typeName">name of user-defined type</param>
		/// <returns>true if typeName is already defined</returns>
		public bool isTypeDefined(string typeName)
		{
			return userTypes_.Contains(typeName);
		}

		/// <summary>
		/// Add a user-defined type string to complexType array.
		/// </summary>
		/// <param name="typeName">name of user-defined type</param>
		public void add(string typeName)
		{
			if (!userTypes_.Contains(typeName)) 
			{
				userTypes_.Add(typeName);
			}
		}

		/// <summary>
		/// Remove a user's type from the list
		/// </summary>
		/// <param name="index"></param>
		public void remove(int index)
		{
			if (index >= 0 && index < userTypes_.Count) 
			{
				userTypes_.RemoveAt(index);
			}
			// else raise an exception
		}

		/// <summary>
		/// Clear all items from the types array
		/// </summary>
		public void clear()
		{
			userTypes_.Clear();
		}

		/// <summary>
		/// Return string[] array of strings of user-defined types
		/// </summary>
		/// <returns>array of strings</returns>
		public string[] getUserTypeNames()
		{
			return (string[])userTypes_.ToArray(typeof(string));
		}

		/// <summary>
		/// Property get number of items in userTypes
		/// </summary>
		public int count()
		{
			return userTypes_.Count;
		}

		public string getTypeName(int index)
		{
			return (string)userTypes_[index];
		}
	}
}
