using System;

namespace BinxEd
{
	/// <summary>
	/// Property class contains text and type attributes of a property of a data type node.
	/// </summary>
	public class Property
	{
		private string		name_;		//property name such as 'varName'
		private int			type_;		//type of input, 1=editbox, 2=combobox
		private	string		value_;		//value of input or selected item as a string
		private	string[]	options_;	//choices for combobox selection

		public Property(string sname, int stype, string val)
		{
			name_ = sname;
			type_ = stype;
			value_ = val;
		}

		public string getName()
		{
			return name_;
		}

		public bool isInputText()
		{
			return type_==1;
		}

		public bool isSelection()
		{
			return type_ == 2;
		}

		public string getValue()
		{
			return (value_==null)?"":value_;
		}

		public void setValue(string val)
		{
			this.value_ = val;
		}

		public string[] getOptions()
		{
			return options_;
		}

		public void setOptions(string[] options)
		{
			options_ = options;
		}

	}
}
