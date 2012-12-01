using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace BinxEd
{
	/// <summary>
	/// PropertyView is a derived class of the ListView control class with addition of text box and combobox editing.
	/// </summary>
	/// <remarks>
	/// To use this class, place a ListView control on the window form and modify the form code to replace the variable 
	/// declaration and object creation.
	/// 
	/// private PropertyView myListView_;
	/// ...
	/// myListView_ = new PropertyView();
	/// 
	/// and in the Form_Load event handler, add:
	/// 
	/// myListView_.setProperties(dataNode.getProperties());
	/// </remarks>
	public class PropertyView : ListView 
	{
		public delegate void PropertyUpdateEvent(string propertyName, string propertyValue);
		public event PropertyUpdateEvent PropertyUpdateHandler;

		private ArrayList propList_;
		private ListViewItem lvItem_;
		private int mx_, my_; 
		private System.Windows.Forms.TextBox  editBox_ = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.ComboBox comboBox_ = new System.Windows.Forms.ComboBox();
		
		public PropertyView()
		{
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FullRowSelect = true;
			this.GridLines = true ;
			//this.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.LabelEdit = false;
			this.LabelWrap = false;
			this.MultiSelect = false;
			//this.Scrollable = false;
			this.Name = "listView1";
			this.Size = new System.Drawing.Size(0,0);
			this.TabIndex = 0;
			this.View = System.Windows.Forms.View.Details;
			this.MouseDown += new MouseEventHandler(PropertyView_MouseDown);
			this.DoubleClick +=new EventHandler(PropertyView_DoubleClick);
			this.Columns.Add("Name", 100, HorizontalAlignment.Left);
			this.Columns.Add("Value", this.Width - 104, HorizontalAlignment.Left);

			editBox_.Size  = new System.Drawing.Size(0,0);
			editBox_.Location = new System.Drawing.Point(0,0);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.editBox_});			
			editBox_.KeyPress += new KeyPressEventHandler(editBox__KeyPress);
			editBox_.LostFocus += new EventHandler(editBox__LostFocus);
			editBox_.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			editBox_.BackColor = Color.LightYellow; 
			editBox_.BorderStyle = BorderStyle.None;
			editBox_.Text = "";
			editBox_.Hide();

			comboBox_.Size  = new System.Drawing.Size(0,0);
			comboBox_.Location = new System.Drawing.Point(0,0);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.comboBox_});
			comboBox_.SelectedIndexChanged += new EventHandler(comboBox__SelectedIndexChanged);
			comboBox_.LostFocus += new EventHandler(comboBox__LostFocus);
			comboBox_.KeyPress += new KeyPressEventHandler(comboBox__KeyPress);
			comboBox_.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			comboBox_.BackColor = Color.LightYellow; 
			comboBox_.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox_.Hide();
		}

		/// <summary>
		/// Set property list for a node.
		/// </summary>
		/// <param name="props"></param>
		public void setProperties(ArrayList props)
		{
			this.propList_ = props;
			this.Items.Clear();
			foreach (Property prop in props)
			{
				ListViewItem it = this.Items.Add(prop.getName());
				it.SubItems.Add(prop.getValue());
			}
		}
		
		private void addSelections(string[] items)
		{
			this.comboBox_.Items.Clear();
			this.comboBox_.Items.AddRange(items);
		}

		private void comboBox__SelectedIndexChanged(object sender, EventArgs e)
		{
			int x = comboBox_.SelectedIndex;
			if (x >= 0)
			{
				string selectedItemText = comboBox_.Items[x].ToString();
				if (!selectedItemText.Equals(lvItem_.SubItems[1].Text)) 
				{
					lvItem_.SubItems[1].Text = selectedItemText;
					UpdateProperty(lvItem_.Text, selectedItemText);
				}
			}
		}

		private void comboBox__LostFocus(object sender, EventArgs e)
		{
			comboBox_.Hide();			
		}

		private void comboBox__KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13 || e.KeyChar == 27)
			{
				comboBox_.Hide();
			}
		}
	
		private void editBox__KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13) 
			{
				unloadEditBox();
			}
			if (e.KeyChar == 27) 
			{
				editBox_.Hide();
			}
		}

		private void editBox__LostFocus(object sender, EventArgs e)
		{
			unloadEditBox();
		}

		private void unloadEditBox()
		{
			string sEditText = editBox_.Text;
			if (!sEditText.Equals(lvItem_.SubItems[1].Text)) 
			{
				lvItem_.SubItems[1].Text = sEditText;
				UpdateProperty(lvItem_.Text, sEditText);
			}
			editBox_.Hide();
		}

		private void PropertyView_MouseDown(object sender, MouseEventArgs e)
		{
			mx_ = e.X;
			my_ = e.Y;
		}

		private void PropertyView_DoubleClick(object sender, EventArgs e)
		{
			lvItem_ = this.GetItemAt(mx_, my_);
			if (lvItem_ != null) 
			{
				int x1 = this.Columns[0].Width + 2;
				if (mx_ >= x1) 
				{
					int x2 = x1 + this.Columns[1].Width;
					int r = lvItem_.Index;
					Property prop = (Property)propList_[r];
					if ( prop.isSelection() ) 
					{
						addSelections(prop.getOptions());
						comboBox_.Size  = new System.Drawing.Size(x2 - x1 , lvItem_.Bounds.Height);
						comboBox_.Location = new System.Drawing.Point(x1 , lvItem_.Bounds.Top);
						comboBox_.Show() ;
						comboBox_.Text = lvItem_.SubItems[1].Text;
						comboBox_.SelectAll() ;
						comboBox_.Focus();
					}
					else
					{
						editBox_.Size  = new System.Drawing.Size(x2 - x1 , lvItem_.Bounds.Height - 2);
						editBox_.Location = new System.Drawing.Point(x1 , lvItem_.Bounds.Top);
						editBox_.Show() ;
						editBox_.Text = lvItem_.SubItems[1].Text;
						editBox_.SelectAll() ;
						editBox_.Focus();
					}
				}
			}
		}
		
		public void ResizeView(Size size)
		{
			int size1 = this.Columns[0].Width;
			this.Columns[1].Width = size.Width - size1;
		}

		/// <summary>
		/// Call external event handler if set by the object creator.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="propertyValue"></param>
		protected void UpdateProperty(string propertyName, string propertyValue)
		{
			if (PropertyUpdateHandler != null) 
			{
				PropertyUpdateHandler(propertyName, propertyValue);
			}
		}

	}
}
