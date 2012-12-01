using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BinxEd
{
	/// <summary>
	/// Summary description for FormArray.
	/// </summary>
	public class FormArray : System.Windows.Forms.Form
	{
		private string typeName_;
		private string[] userTypes;	//reference to external instance of user-defined type strings
		private int arrayType_;

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.TextBox textBoxTypeName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.RadioButton radiobuttonFixed;
		private System.Windows.Forms.RadioButton radiobuttonVariable;
		private System.Windows.Forms.RadioButton radiobuttonStreamed;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxSizeRef;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxElement;
		private System.Windows.Forms.Label label4;
		private EditListView listView1;
		private System.Windows.Forms.Button buttonDelDim;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormArray()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			arrayType_ = 1;
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
			this.buttonOK = new System.Windows.Forms.Button();
			this.textBoxTypeName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.radiobuttonFixed = new System.Windows.Forms.RadioButton();
			this.radiobuttonVariable = new System.Windows.Forms.RadioButton();
			this.radiobuttonStreamed = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxSizeRef = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxElement = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.listView1 = new BinxEd.EditListView();
			this.buttonDelDim = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(128, 248);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(72, 24);
			this.buttonOK.TabIndex = 10;
			this.buttonOK.Text = "OK";
			// 
			// textBoxTypeName
			// 
			this.textBoxTypeName.Location = new System.Drawing.Point(102, 8);
			this.textBoxTypeName.Name = "textBoxTypeName";
			this.textBoxTypeName.Size = new System.Drawing.Size(176, 20);
			this.textBoxTypeName.TabIndex = 8;
			this.textBoxTypeName.Text = "typeName";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(14, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "Type Name:";
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(208, 248);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(72, 24);
			this.buttonCancel.TabIndex = 9;
			this.buttonCancel.Text = "Cancel";
			// 
			// radiobuttonFixed
			// 
			this.radiobuttonFixed.Checked = true;
			this.radiobuttonFixed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.radiobuttonFixed.Location = new System.Drawing.Point(16, 40);
			this.radiobuttonFixed.Name = "radiobuttonFixed";
			this.radiobuttonFixed.Size = new System.Drawing.Size(56, 24);
			this.radiobuttonFixed.TabIndex = 11;
			this.radiobuttonFixed.TabStop = true;
			this.radiobuttonFixed.Text = "Fixed";
			this.radiobuttonFixed.CheckedChanged += new System.EventHandler(this.radiobuttonFixed_CheckedChanged);
			// 
			// radiobuttonVariable
			// 
			this.radiobuttonVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.radiobuttonVariable.Location = new System.Drawing.Point(104, 40);
			this.radiobuttonVariable.Name = "radiobuttonVariable";
			this.radiobuttonVariable.Size = new System.Drawing.Size(72, 24);
			this.radiobuttonVariable.TabIndex = 11;
			this.radiobuttonVariable.Text = "Variable";
			this.radiobuttonVariable.CheckedChanged += new System.EventHandler(this.radiobuttonVariable_CheckedChanged);
			// 
			// radiobuttonStreamed
			// 
			this.radiobuttonStreamed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.radiobuttonStreamed.Location = new System.Drawing.Point(200, 40);
			this.radiobuttonStreamed.Name = "radiobuttonStreamed";
			this.radiobuttonStreamed.Size = new System.Drawing.Size(80, 24);
			this.radiobuttonStreamed.TabIndex = 11;
			this.radiobuttonStreamed.Text = "Streamed";
			this.radiobuttonStreamed.CheckedChanged += new System.EventHandler(this.radiobuttonStreamed_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Enabled = false;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "SizeRef";
			// 
			// comboBoxSizeRef
			// 
			this.comboBoxSizeRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSizeRef.Enabled = false;
			this.comboBoxSizeRef.Items.AddRange(new object[] {
														   "byte-8",
														   "unsignedByte-8",
														   "short-16",
														   "unsignedShort-16",
														   "integer-32",
														   "unsignedInteger-32",
														   "long-64",
														   "unsignedLong-64"});
			this.comboBoxSizeRef.Location = new System.Drawing.Point(104, 72);
			this.comboBoxSizeRef.Name = "comboBoxSizeRef";
			this.comboBoxSizeRef.Size = new System.Drawing.Size(176, 21);
			this.comboBoxSizeRef.TabIndex = 12;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(16, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Data Type:";
			// 
			// comboBoxElement
			// 
			this.comboBoxElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxElement.Location = new System.Drawing.Point(104, 104);
			this.comboBoxElement.Name = "comboBoxElement";
			this.comboBoxElement.Size = new System.Drawing.Size(176, 21);
			this.comboBoxElement.TabIndex = 12;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 136);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 16);
			this.label4.TabIndex = 13;
			this.label4.Text = "Dimensions:";
			// 
			// listView1
			// 
			this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listView1.GridLines = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.LabelWrap = false;
			this.listView1.Location = new System.Drawing.Point(16, 152);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(264, 88);
			this.listView1.TabIndex = 14;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// buttonDelDim
			// 
			this.buttonDelDim.Location = new System.Drawing.Point(16, 248);
			this.buttonDelDim.Name = "buttonDelDim";
			this.buttonDelDim.Size = new System.Drawing.Size(24, 24);
			this.buttonDelDim.TabIndex = 15;
			this.buttonDelDim.Text = "X";
			this.buttonDelDim.Click += new System.EventHandler(this.buttonDelDim_Click);
			// 
			// FormArray
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 285);
			this.Controls.Add(this.buttonDelDim);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.comboBoxSizeRef);
			this.Controls.Add(this.radiobuttonFixed);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.textBoxTypeName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.radiobuttonVariable);
			this.Controls.Add(this.radiobuttonStreamed);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboBoxElement);
			this.Name = "FormArray";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Define Array Type";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormArray_Closing);
			this.Load += new System.EventHandler(this.FormArray_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormArray_Load(object sender, System.EventArgs e)
		{
			listView1.setColumnHeaders(new string[]{"Element Count","Dim Name"}, new int[]{150,listView1.Width-154});
			if (typeName_ != null) 
			{
				textBoxTypeName.Text = typeName_;
			}
			comboBoxSizeRef.SelectedIndex = 0;
			if (userTypes != null && userTypes.Length > 0)
			{
				comboBoxElement.Items.AddRange(userTypes);
				comboBoxElement.SelectedIndex = 0;
			}
		}

		/// <summary>
		/// Radio button checked/unchecked for arrayFixed option
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radiobuttonFixed_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radiobuttonFixed.Checked) 
			{
				arrayType_ = 1;
			}
		}

		/// <summary>
		/// Radio button checked/unchecked for arrayVariable option
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radiobuttonVariable_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radiobuttonVariable.Checked) 
			{
				comboBoxSizeRef.Enabled = true;
				label2.Enabled = true;
				arrayType_ = 2;
			} 
			else 
			{
				comboBoxSizeRef.Enabled = false;
				label2.Enabled = false;
			}
		}

		/// <summary>
		/// Radio button checked/unchecked for arrayStreamed option
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radiobuttonStreamed_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radiobuttonStreamed.Checked) 
			{
				arrayType_ = 3;
				listView1.Enabled = false;
				buttonDelDim.Enabled = false;
			} 
			else 
			{
				listView1.Enabled = true;
				buttonDelDim.Enabled = true;
			}
		}

		/// <summary>
		/// Delete a selected dimension item
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonDelDim_Click(object sender, System.EventArgs e)
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

		public int ArrayType
		{
			get { return arrayType_; }
		}

		public string ArrayTypeName
		{
			get 
			{
				switch (arrayType_) 
				{
					case 1:
						return "arrayFixed";
					case 2:
						return "arrayVariable";
					default:
						return "arrayStreamed";
				}
			}
		}

		/// <summary>
		/// Set data types array reference
		/// </summary>
		public string[] DataTypeSource
		{
			set
			{
				userTypes = value;
			}
		}

		public string SizeRef
		{
			get { return comboBoxSizeRef.Text; }
		}

		public string DataType
		{
			get { return comboBoxElement.Text; }
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
		/// Get list of dimensions as a ListViewItemCollection
		/// </summary>
		/// <returns></returns>
		public System.Windows.Forms.ListView.ListViewItemCollection getDimensions()
		{
			return this.listView1.Items;
		}

		/// <summary>
		/// Validate array content before closing the input window.
		/// </summary>
		/// <remarks>
		/// The following are validated:
		/// <list>
		/// If it is used to define a type, the type name must be given
		/// There should be at least one dimension except for streamed array
		/// All dimensions must be a positive integer except variable-sized array whose first dim is always zero
		/// </list>
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormArray_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.DialogResult==DialogResult.Cancel) 
			{
				return;
			}
			if (this.label1.Text.StartsWith("Type")) 
			{
				if (this.textBoxTypeName.Text.Trim().Equals("")) 
				{
					MessageBox.Show(this, "Must give a type name");
					e.Cancel = true;
					return;
				}
			}
			if (arrayType_ < 3 && this.listView1.Items.Count <= 0) 
			{
				MessageBox.Show(this, "Must at least one dimension");
				e.Cancel = true;
				return;
			}
			else if (arrayType_ != 3)
			{
				if (arrayType_ == 2) 
				{
					listView1.Items[0].Text = "0";
				}
				trimListView();
				foreach (ListViewItem itm in listView1.Items)
				{
					string sc = itm.Text.Trim();
					if (sc.Equals("")) 
					{
						MessageBox.Show(this, "Dim count must not be empty");
						e.Cancel = true;
						return;
					} 
					else 
					{
						for (int i=0; i<sc.Length; i++) 
						{
							if (!Char.IsNumber(sc, i)) 
							{
								MessageBox.Show(this, "Dim count must be a number");
								e.Cancel = true;
								return;
							}
						}
					}
					if (sc.Equals("0") && (arrayType_==1 || (arrayType_==2 && itm.Index>0))) 
					{
						MessageBox.Show(this, "Dim must not be zero except first dim of a variable-sized array");
						e.Cancel = true;
						return;
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
