using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for AcercaDe.
	/// </summary>
	public class AcercaDe : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AcercaDe()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AcercaDe));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(24, 128);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "RSA Generator ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 168);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(160, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Versión 1.0";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(296, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(232, 32);
			this.label3.TabIndex = 2;
			this.label3.Text = "Julio Enrique Santana Lora                   Reyder Cruz de La Osa";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(296, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(232, 32);
			this.label4.TabIndex = 3;
			this.label4.Text = "Universidad de la Habana                           2007 ";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(80)), ((System.Byte)(80)));
			this.button1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(200, 208);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(136, 48);
			this.button1.TabIndex = 4;
			this.button1.Text = "Aceptar";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(96, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(312, 80);
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// AcercaDe
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(196)), ((System.Byte)(218)), ((System.Byte)(250)));
			this.ClientSize = new System.Drawing.Size(536, 266);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "AcercaDe";
			this.ShowInTaskbar = false;
			this.Text = "AcercaDe";
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
