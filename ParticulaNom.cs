using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for Particula.
	/// </summary>
	public class ParticulaNom : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public ParticulaNom(string[] names,int selected)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			for(int i=0;i<names.Length;i++)
				this.listBox1.Items.Add(names[i]);
			this.listBox1.SelectedIndex=selected;
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 16;
			this.listBox1.Location = new System.Drawing.Point(16, 16);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(144, 148);
			this.listBox1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.Location = new System.Drawing.Point(176, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 32);
			this.button1.TabIndex = 1;
			this.button1.Text = "Aceptar";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ParticulaNom
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(218)), ((System.Byte)(250)));
			this.ClientSize = new System.Drawing.Size(288, 182);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listBox1);
			this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ParticulaNom";
			this.Text = "Particula";
			this.ResumeLayout(false);

		}
		#endregion

		public string ParticulaSeleccionada
		{
			get
			{
				return this.listBox1.SelectedItem.ToString();
			}
		}
		
		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Visible=false;		
		}
	}
}
