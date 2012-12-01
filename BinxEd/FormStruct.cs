using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BinxEd
{
	/// <summary>
	/// Summary description for FormStruct.
	/// </summary>
	public class FormStruct : System.Windows.Forms.Form
	{
		private string typeName_;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxTypeName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxBlockSize;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label label2;
		private EditListView listView1;
		private System.Windows.Forms.Button buttonDelItem;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormStruct()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxBlockSize = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.listView1 = new BinxEd.EditListView();
			this.buttonDelItem = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Type Name: ";
			// 
			// textBoxTypeName
			// 
			this.textBoxTypeName.Location = new System.Drawing.Point(96, 8);
			this.textBoxTypeName.Name = "textBoxTypeName";
			this.textBoxTypeName.Size = new System.Drawing.Size(176, 20);
			this.textBoxTypeName.TabIndex = 1;
			this.textBoxTypeName.Text = "MyStruct-1";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 24);
			this.label3.TabIndex = 0;
			this.label3.Text = "Block Size:";
			// 
			// textBoxBlockSize
			// 
			this.textBoxBlockSize.Location = new System.Drawing.Point(96, 40);
			this.textBoxBlockSize.Name = "textBoxBlockSize";
			this.textBoxBlockSize.Size = new System.Drawing.Size(176, 20);
			this.textBoxBlockSize.TabIndex = 3;
			this.textBoxBlockSize.Text = "0";
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(120, 224);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(72, 24);
			this.buttonOK.TabIndex = 4;
			this.buttonOK.Text = "OK";
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(200, 224);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(72, 24);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Members";
			// 
			// listView1
			// 
			this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listView1.GridLines = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.LabelWrap = false;
			this.listView1.Location = new System.Drawing.Point(16, 88);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Scrollable = false;
			this.listView1.Size = new System.Drawing.Size(256, 128);
			this.listView1.TabIndex = 6;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// buttonDelItem
			// 
			this.buttonDelItem.Location = new System.Drawing.Point(16, 224);
			this.buttonDelItem.Name = "buttonDelItem";
			this.buttonDelItem.Size = new System.Drawing.Size(24, 24);
			this.buttonDelItem.TabIndex = 7;
			this.buttonDelItem.Text = "X";
			this.buttonDelItem.Click += new System.EventHandler(this.buttonDelItem_Click);
			// 
			// FormStruct
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 263);
			this.Controls.Add(this.buttonDelItem);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.textBoxBlockSize);
			this.Controls.Add(this.textBoxTypeName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.buttonCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormStruct";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Define a struct type";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormStruct_Closing);
			this.Load += new System.EventHandler(this.FormStruct_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormStruct_Load(object sender, System.EventArgs e)
		{
			listView1.setColumnHeaders(new string[]{"Type","Variable Name"}, new int[]{150,listView1.Width-154});
			if (typeName_ != null) 
			{
				textBoxTypeName.Text = typeName_;
			}
		}

		public string TypeName
		{
			get { return textBoxTypeName.Text; }
			set { typeName_ = value; }
		}

		/// <summary>
		/// Change label1 to either "Type Name" or "Var Name".
		/// </summary>
		/// <param name="text"></param>
		public void ChangeLabel(string text)
		{
			label1.Text = text;
		}

		public string BlockSize
		{
			get { return textBoxBlockSize.Text; }
		}

		public void setDataTypeSource(string[] dataTypes)
		{
			listView1.addDataTypes(dataTypes);
		}

		public System.Windows.Forms.ListView.ListViewItemCollection getMemberItems()
		{
			return this.listView1.Items;
		}

		/// <summary>
		/// Delete the selected member.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonDelItem_Click(object sender, System.EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				foreach (ListViewItem itm in listView1.SelectedItems)
				{
					listView1.Items.Remove(itm);
				}
			}
		}

		/// <summary>
		/// Validate before closing window.
		/// </summary>
		/// <remarks>The following are validated:
		/// <ul>
		/// <li>"There must be at least one member specified</li>
		/// <li>If it is used to define a type, must give a type name</li>
		/// <li>if blocksize is empty, set it to zero</li>
		/// </ul>
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormStruct_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.DialogResult == DialogResult.Cancel) 
			{
				return;
			}
			if (listView1.Items.Count <= 0) 
			{
				MessageBox.Show(this, "At least have one member");
				e.Cancel = true;
				return;
			}
			if (label1.Text.Equals("Type Name: ")) 
			{
				if (textBoxTypeName.Text.Trim().Equals(""))
				{
					MessageBox.Show(this, "Must give a type name!");
					e.Cancel = true;
					return;
				}
			}
			if (textBoxBlockSize.Text.Trim().Equals("")) 
			{
				textBoxBlockSize.Text = "0";
			}
		}
	}
}
