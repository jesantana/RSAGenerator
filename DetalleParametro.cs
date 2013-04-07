using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for DetalleParametro.
	/// </summary>
	public class DetalleParametro : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		string nombre;
		string tipo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DetalleParametro(int numero)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.label1.Text="Nombre del parametro "+numero;
			this.listBox1.SelectedIndex=0;
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

		public string Nombre
		{
			get
			{
				return this.nombre;
			}
		} 

		public string Tipo
		{
			get
			{
				return this.tipo;
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nombre del parametro";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(144, 40);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(104, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Tipo del Parametro";
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 16;
			this.listBox1.Items.AddRange(new object[] {
														  "double",
														  "float",
														  "int",
														  "string"});
			this.listBox1.Location = new System.Drawing.Point(144, 72);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(96, 20);
			this.listBox1.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(80, 128);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 32);
			this.button1.TabIndex = 4;
			this.button1.Text = "Aceptar";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// DetalleParametro
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(218)), ((System.Byte)(250)));
			this.ClientSize = new System.Drawing.Size(264, 174);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "DetalleParametro";
			this.ShowInTaskbar = false;
			this.Text = "DetalleParametro";
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(textBox1.Text.Trim()=="")
			{
				MessageBox.Show("Hay que llenar todos los campos");
				return;
			}
			this.nombre=textBox1.Text;
			this.tipo=(string)listBox1.Items[listBox1.SelectedIndex];
			this.Visible=false;
		}

		
	}
}
