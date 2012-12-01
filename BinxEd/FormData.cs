using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BinxEd
{
	/// <summary>
	/// Summary description for FormData.
	/// </summary>
	public class FormData : System.Windows.Forms.Form
	{
		private string[] userTypes;	//reference to external instance of user-defined type strings
		private string typeToSelect;	//set by caller for default selected
		private string varName_;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxVarName;
		private System.Windows.Forms.Button buttonMore;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormData()
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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxVarName = new System.Windows.Forms.TextBox();
			this.buttonMore = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Type:";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new System.Drawing.Point(80, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(192, 21);
			this.comboBox1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 24);
			this.label2.TabIndex = 0;
			this.label2.Text = "Name:";
			// 
			// textBoxVarName
			// 
			this.textBoxVarName.Location = new System.Drawing.Point(80, 40);
			this.textBoxVarName.Name = "textBoxVarName";
			this.textBoxVarName.Size = new System.Drawing.Size(192, 20);
			this.textBoxVarName.TabIndex = 2;
			this.textBoxVarName.Text = "var1";
			// 
			// buttonMore
			// 
			this.buttonMore.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.buttonMore.Location = new System.Drawing.Point(136, 72);
			this.buttonMore.Name = "buttonMore";
			this.buttonMore.Size = new System.Drawing.Size(64, 24);
			this.buttonMore.TabIndex = 3;
			this.buttonMore.Text = "More";
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(64, 72);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(64, 24);
			this.buttonOK.TabIndex = 3;
			this.buttonOK.Text = "OK";
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(208, 72);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(64, 24);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			// 
			// FormData
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 109);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonMore);
			this.Controls.Add(this.textBoxVarName);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonOK);
			this.Name = "FormData";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Data Element";
			this.Load += new System.EventHandler(this.FormStruct_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormStruct_Load(object sender, System.EventArgs e)
		{
			comboBox1.Items.Clear();
			comboBox1.Items.AddRange(userTypes);
			if (typeToSelect==null)
			{
				try 
				{
					comboBox1.SelectedIndex = 0;
				}
				catch (Exception ex) 
				{
					Console.WriteLine(ex.Message);
				}
			} 
			else 
			{
				comboBox1.SelectedItem = typeToSelect;
			}
			if (varName_ != null) 
			{
				textBoxVarName.Text = varName_;
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

		public string SelectedType
		{
			get { return comboBox1.Text; }
			set { typeToSelect = value; }
		}

		public string VarName
		{
			get { return textBoxVarName.Text; }
			set { varName_ = value; }
		}

	}
}
