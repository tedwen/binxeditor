using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BinxEd
{
	/// <summary>
	/// Summary description for FormUnion.
	/// </summary>
	public class FormUnion : System.Windows.Forms.Form
	{
		private string typeName_;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxTypeName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxDisType;
		private System.Windows.Forms.TextBox textBoxBlockSize;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private EditListView listView1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonDelCase;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormUnion()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxTypeName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxDisType = new System.Windows.Forms.ComboBox();
			this.textBoxBlockSize = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.listView1 = new BinxEd.EditListView();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonDelCase = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Type Name:";
			// 
			// textBoxTypeName
			// 
			this.textBoxTypeName.Location = new System.Drawing.Point(104, 8);
			this.textBoxTypeName.Name = "textBoxTypeName";
			this.textBoxTypeName.Size = new System.Drawing.Size(176, 20);
			this.textBoxTypeName.TabIndex = 1;
			this.textBoxTypeName.Text = "typeName";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Discriminant";
			// 
			// comboBoxDisType
			// 
			this.comboBoxDisType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDisType.Items.AddRange(new object[] {
														   "byte-8",
														   "unsignedByte-8",
														   "short-16",
														   "unsignedShort-16",
														   "integer-32",
														   "unsignedInteger-32",
														   "long-64",
														   "unsignedLong-64",
														   "character-8"});
			this.comboBoxDisType.Location = new System.Drawing.Point(104, 40);
			this.comboBoxDisType.Name = "comboBoxDisType";
			this.comboBoxDisType.Size = new System.Drawing.Size(176, 21);
			this.comboBoxDisType.TabIndex = 2;
			// 
			// textBoxBlockSize
			// 
			this.textBoxBlockSize.Location = new System.Drawing.Point(104, 72);
			this.textBoxBlockSize.Name = "textBoxBlockSize";
			this.textBoxBlockSize.Size = new System.Drawing.Size(176, 20);
			this.textBoxBlockSize.TabIndex = 5;
			this.textBoxBlockSize.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 24);
			this.label3.TabIndex = 4;
			this.label3.Text = "Block Size:";
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(128, 240);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(72, 24);
			this.buttonOK.TabIndex = 6;
			this.buttonOK.Text = "OK";
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(208, 240);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(72, 24);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Cancel";
			// 
			// listView1
			// 
			this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listView1.GridLines = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.LabelWrap = false;
			this.listView1.Location = new System.Drawing.Point(16, 120);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(264, 112);
			this.listView1.TabIndex = 7;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Cases:";
			// 
			// buttonDelCase
			// 
			this.buttonDelCase.Location = new System.Drawing.Point(16, 240);
			this.buttonDelCase.Name = "buttonDelCase";
			this.buttonDelCase.Size = new System.Drawing.Size(24, 24);
			this.buttonDelCase.TabIndex = 9;
			this.buttonDelCase.Text = "X";
			this.buttonDelCase.Click += new System.EventHandler(this.buttonDelCase_Click);
			// 
			// FormUnion
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 277);
			this.Controls.Add(this.buttonDelCase);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.textBoxBlockSize);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboBoxDisType);
			this.Controls.Add(this.textBoxTypeName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonCancel);
			this.Name = "FormUnion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Define Union Type";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormUnion_Closing);
			this.Load += new System.EventHandler(this.FormUnion_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormUnion_Load(object sender, System.EventArgs e)
		{
			listView1.setColumnHeaders(new string[]{"Value","Type","VarName"}, new int[]{50,150,listView1.Width-204});
			if (typeName_ != null) 
			{
				textBoxTypeName.Text = typeName_;
			}
			comboBoxDisType.SelectedIndex = 0;
		}

		/// <summary>
		/// Delete the selected case.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonDelCase_Click(object sender, System.EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				foreach (ListViewItem itm in listView1.SelectedItems)
				{
					listView1.Items.Remove(itm);
				}
			}
		}

		public string TypeName
		{
			get { return textBoxTypeName.Text; }
			set { typeName_ = value; }
		}

		public string DiscriminantType
		{
			get { return comboBoxDisType.Text; }
		}

		public string BlockSize
		{
			get { return (textBoxBlockSize.Text.Trim().Equals(""))?"0":textBoxBlockSize.Text; }
		}

		/// <summary>
		/// Change label1 to either "Type Name" or "Var Name".
		/// </summary>
		/// <param name="text"></param>
		public void ChangeLabel(string text)
		{
			label1.Text = text;
		}

		/// <summary>
		/// Set combobox list of data types
		/// </summary>
		/// <param name="dataTypes"></param>
		public void setDataTypeSource(string[] dataTypes)
		{
			listView1.addDataTypes(dataTypes);
		}

		/// <summary>
		/// Get list of union cases as a ListViewItemCollection
		/// </summary>
		/// <returns></returns>
		public System.Windows.Forms.ListView.ListViewItemCollection getCases()
		{
			return this.listView1.Items;
		}

		/// <summary>
		/// Validate before closing the window.
		/// </summary>
		/// <remarks>
		/// The following are validated:
		/// <list>
		/// If it is used to define a type, a type name must be given
		/// there must be at least one case
		/// no case should be of empty value
		/// there should be no duplicate case values
		/// only the last case can be void (of no specific case body type)
		/// </list>
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormUnion_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.DialogResult == DialogResult.Cancel) 
			{
				return;
			}
			if (label1.Text.Equals("Type Name:")) 
			{
				if (textBoxTypeName.Text.Trim().Equals(""))
				{
					MessageBox.Show(this, "Must give a type name");
					e.Cancel = true;
					return;
				}
			}
			if (listView1.Items.Count <= 0) 
			{
				MessageBox.Show(this, "At least one case");
				e.Cancel = true;
			} 
			else 
			{
				trimListView();
				//check each case for empty value, duplicate value, no case body
				Hashtable vals = new Hashtable();
				foreach (ListViewItem itm in listView1.Items)
				{
					string sval = itm.Text.Trim();
					if (sval.Equals("")) 
					{
						MessageBox.Show("Case value must not be empty");
						e.Cancel = true;
						break;
					}
					if (vals.Contains(sval)) 
					{
						MessageBox.Show("Cannot have duplicate case values");
						e.Cancel = true;
						break;
					} 
					else 
					{
						vals.Add(sval, sval);
					}
					if (itm.SubItems[1].Text.Trim().Equals("")) 
					{
						if (itm.Index < listView1.Items.Count-1) 
						{
							MessageBox.Show("Only last case can be void");
							e.Cancel = true;
							break;
						}
					}
				}
			}
		}

		/// <summary>
		/// Remove blank items at the end of the dimension list.
		/// </summary>
		private void trimListView()
		{
			for (int i=listView1.Items.Count-1; i>0; i--)
			{
				ListViewItem itm = listView1.Items[i];
				if (itm.Text.Trim().Equals("") && itm.SubItems[1].Text.Trim().Equals("")) 
				{
					listView1.Items.Remove(itm);
				}
			}
		}
	}
}
