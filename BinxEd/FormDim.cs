using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BinxEd
{
	/// <summary>
	/// Summary description for FormDim.
	/// </summary>
	public class FormDim : System.Windows.Forms.Form
	{
//		private int dimCount_;

		private System.Windows.Forms.TextBox textBoxDimName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxCount;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormDim()
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
			this.textBoxDimName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxCount = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxDimName
			// 
			this.textBoxDimName.Location = new System.Drawing.Point(104, 16);
			this.textBoxDimName.Name = "textBoxDimName";
			this.textBoxDimName.Size = new System.Drawing.Size(152, 20);
			this.textBoxDimName.TabIndex = 10;
			this.textBoxDimName.Text = "typeName";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Name:";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 9;
			this.label2.Text = "Element Count";
			// 
			// textBoxCount
			// 
			this.textBoxCount.Location = new System.Drawing.Point(104, 48);
			this.textBoxCount.Name = "textBoxCount";
			this.textBoxCount.Size = new System.Drawing.Size(152, 20);
			this.textBoxCount.TabIndex = 10;
			this.textBoxCount.Text = "typeName";
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(120, 88);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(64, 24);
			this.buttonOK.TabIndex = 12;
			this.buttonOK.Text = "OK";
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(192, 88);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(64, 24);
			this.buttonCancel.TabIndex = 11;
			this.buttonCancel.Text = "Cancel";
			// 
			// FormDim
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 125);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.textBoxDimName);
			this.Controls.Add(this.textBoxCount);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Name = "FormDim";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Array Dimension";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormDim_Closing);
			this.Load += new System.EventHandler(this.FormDim_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormDim_Load(object sender, System.EventArgs e)
		{
			textBoxDimName.Text = "";
			textBoxCount.Text = "";
			textBoxCount.Enabled = true;
		}

		private bool InValidCount()
		{
			if (textBoxCount.Enabled) 
			{
				string s = textBoxCount.Text.Trim();
				if (s.Length < 1) 
				{
					MessageBox.Show(this, "Must enter an element count");
					return true;
				}
				for (int i=0; i<s.Length; i++) 
				{
					if (!Char.IsNumber(s, i)) 
					{
						return true;
					}
				}
			} 
			return false;
		}

		private void FormDim_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.DialogResult==DialogResult.OK) 
			{
				e.Cancel = InValidCount();
			}
		}

		public string DimName
		{
			get { return textBoxDimName.Text; }
		}

		public string DimCount
		{
			get { return textBoxCount.Text; }
		}
	}
}
