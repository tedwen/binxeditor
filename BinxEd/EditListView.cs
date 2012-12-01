using System;
using System.Windows.Forms;
using System.Drawing;

namespace BinxEd
{
	/// <summary>
	/// EditListView is a derived class of the ListView control class with addition of text box and combobox editing.
	/// </summary>
	/// <remarks>
	/// To use this class,  place a ListView control on the window form and modify the form code to replace the variable 
	/// declaration and object creation.
	/// private EditListView myListView_;
	/// myListView_ = new EditListView();
	/// ...
	/// myListView_.addDataTypes(document_.getDataTypes());
	/// myListView_.setColumnHeaders(new string[]{"Type","Variable Name"}, new int[]{100,60});
	/// </remarks>
	public class EditListView : ListView 
	{
		private ListViewItem lvItem_;
		private string subItemText_ ;
		private int subItemSelected_ = 0 ; 
		private System.Windows.Forms.TextBox  editBox_ = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.ComboBox comboBox_ = new System.Windows.Forms.ComboBox();
		
		private ColumnHeader[] columnHeaders_;

		public EditListView()
		{
			//this.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FullRowSelect = false;
			this.GridLines = true ;
			this.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.LabelEdit = false;
			this.LabelWrap = false;
			this.MultiSelect = false;
			//this.Scrollable = false;
			this.Name = "listView1";
			this.Size = new System.Drawing.Size(0,0);
			this.TabIndex = 0;
			this.View = System.Windows.Forms.View.Details;
			this.MouseDown += new MouseEventHandler(EditListView_MouseDown);
			
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
		}
		
		public void addDataTypes(string[] items)
		{
			this.comboBox_.Items.AddRange(items);
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
		
		public void setColumnHeaders(string[] headerText, int[] headerWidth)
		{
			int headers = headerText.Length;
			columnHeaders_ = new ColumnHeader[headers];
			for (int i=0; i<headers; i++)
			{
				columnHeaders_[i] = new ColumnHeader();
				columnHeaders_[i].Text = headerText[i];
				columnHeaders_[i].Width = headerWidth[i];
			}
			this.Columns.AddRange(columnHeaders_);
		}			

		private ListViewItem addItemWithSubItems(string itemText)
		{
			ListViewItem lvi = this.Items.Add(itemText);
			for (int i=1; i<this.columnHeaders_.Length; i++)
			{
				lvi.SubItems.Add("");
			}
			return lvi;
		}

		private void EditListView_MouseDown(object sender, MouseEventArgs e)
		{
			int mx = e.X;
			lvItem_ = this.GetItemAt(2, e.Y);
			if (lvItem_==null)
			{
				if (this.Items.Count <= 0)
				{
					lvItem_ = addItemWithSubItems("");
				}
				else if (!this.Items[this.Items.Count-1].Text.Equals(""))
				{
					lvItem_ = addItemWithSubItems("");
				}
				else
				{
					lvItem_ = this.Items[this.Items.Count-1];
				}
			}

			int x1 = 0 ; 
			int x2 = this.Columns[0].Width ;
			subItemSelected_ = 0;
			if (mx >= x2) 
			{
				for (int i=1; i < this.Columns.Count; i++)
				{
					x1 = x2;
					x2 += this.Columns[i].Width;
					if (mx < x2) 
					{
						subItemSelected_ = i ;
						break; 
					}
				}
			}
			x1 += 2;
			subItemText_ = lvItem_.SubItems[subItemSelected_].Text ;
			string colName = this.Columns[subItemSelected_].Text ;
			if ( colName.Equals("Type") ) 
			{
				comboBox_.Size  = new System.Drawing.Size(x2 - x1 , lvItem_.Bounds.Height - 2);
				comboBox_.Location = new System.Drawing.Point(x1 , lvItem_.Bounds.Top);
				comboBox_.Show() ;
				comboBox_.Text = subItemText_;
				comboBox_.SelectAll() ;
				comboBox_.Focus();
			}
			else
			{
				editBox_.Size  = new System.Drawing.Size(x2 - x1 , lvItem_.Bounds.Height);
				editBox_.Location = new System.Drawing.Point(x1 , lvItem_.Bounds.Top);
				editBox_.Show() ;
				editBox_.Text = subItemText_;
				editBox_.SelectAll() ;
				editBox_.Focus();
			}
		}

		private void editBox__KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13) 
			{
				lvItem_.SubItems[subItemSelected_].Text = editBox_.Text;
				editBox_.Hide();
			} 
			else if (e.KeyChar == 27) 
			{
				editBox_.Hide();
			}
		}

		private void editBox__LostFocus(object sender, EventArgs e)
		{
			lvItem_.SubItems[subItemSelected_].Text = editBox_.Text;
			editBox_.Hide();
		}

		private void comboBox__SelectedIndexChanged(object sender, EventArgs e)
		{
			int x = comboBox_.SelectedIndex;
			if (x >= 0)
			{
				lvItem_.SubItems[subItemSelected_].Text = comboBox_.Items[x].ToString();
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
	}
}
