using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BinxEd
{
	/// <summary>
	/// Summary description for FormCase.
	/// </summary>
	public class FormCase : System.Windows.Forms.Form
	{
		private string varName_;
		private string[] userTypes;	//reference to external instance of user-defined type strings

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.TextBox textBoxValue;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox textBoxVarName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormCase()
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
			this.buttonOK = new System.Windows.Forms.Button();
			this.textBoxValue = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxVarName = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(120, 144);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(72, 24);
			this.buttonOK.TabIndex = 14;
			this.buttonOK.Text = "OK";
			// 
			// textBoxValue
			// 
			this.textBoxValue.Location = new System.Drawing.Point(136, 8);
			this.textBoxValue.Name = "textBoxValue";
			this.textBoxValue.Size = new System.Drawing.Size(136, 20);
			this.textBoxValue.TabIndex = 9;
			this.textBoxValue.Text = "1";
			this.textBoxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(14, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "Discriminant Value";
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(200, 144);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(72, 24);
			this.buttonCancel.TabIndex = 13;
			this.buttonCancel.Text = "Cancel";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBoxVarName);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Location = new System.Drawing.Point(16, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(256, 96);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Body Data";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 15;
			this.label4.Text = "Name:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 24);
			this.label3.TabIndex = 14;
			this.label3.Text = "Type:";
			// 
			// textBoxVarName
			// 
			this.textBoxVarName.Location = new System.Drawing.Point(64, 56);
			this.textBoxVarName.Name = "textBoxVarName";
			this.textBoxVarName.Size = new System.Drawing.Size(176, 20);
			this.textBoxVarName.TabIndex = 13;
			this.textBoxVarName.Text = "";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Items.AddRange(new object[] {
														   "byte-8",
														   "unsignedByte-8",
														   "short-16",
														   "unsignedShort-16",
														   "integer-32",
														   "unsignedInteger-32",
														   "long-64",
														   "unsignedLong-64",
														   "character-8"});
			this.comboBox1.Location = new System.Drawing.Point(64, 24);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(176, 21);
			this.comboBox1.TabIndex = 11;
			// 
			// FormCase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 181);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.textBoxValue);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonCancel);
			this.Name = "FormCase";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Union Case";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormCase_Closing);
			this.Load += new System.EventHandler(this.FormCase_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormCase_Load(object sender, System.EventArgs e)
		{
			if (varName_ != null) 
			{
				textBoxVarName.Text = varName_;
			}
			if (userTypes != null && userTypes.Length > 0) 
			{
				comboBox1.Items.Clear();
				comboBox1.Items.AddRange(userTypes);
			}
			if (comboBox1.Items.Count > 0) 
			{
				comboBox1.SelectedIndex = 0;
			}
		}

		/// <summary>
		/// Validate case value before closing input window.
		/// </summary>
		/// <remarks>
		/// Can't validate case body here as it is unknown which case it is.
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormCase_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.DialogResult==DialogResult.Yes && textBoxValue.Text.Trim().Equals(""))
			{
				MessageBox.Show(this, "Case value must not be empty");
				e.Cancel = true;
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

		public string DiscriminantValue
		{
			get { return textBoxValue.Text; }
		}

		public string SelectedType
		{
			get { return comboBox1.Text; }
		}

		public string VarName
		{
			get { return textBoxVarName.Text; }
			set { varName_ = value; }
		}
	}
}
