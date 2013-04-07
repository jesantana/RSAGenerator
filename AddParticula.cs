using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for AddParticula.
	/// </summary>
	public class AddParticula : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		ParticulaInfo pInfo;
		//TextBox[] texts;
		string path,pathDibujable;
		bool pressed;
		bool filled;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddParticula()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.listBox1.SelectedIndex=0;
			pInfo=new ParticulaInfo();
			filled = false;
			//texts
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label8 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(192, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(192, 64);
			this.textBox2.Name = "textBox2";
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(192, 96);
			this.textBox3.Name = "textBox3";
			this.textBox3.TabIndex = 2;
			this.textBox3.Text = "";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(192, 128);
			this.textBox4.Name = "textBox4";
			this.textBox4.TabIndex = 3;
			this.textBox4.Text = "";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(192, 160);
			this.textBox5.Name = "textBox5";
			this.textBox5.TabIndex = 4;
			this.textBox5.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Nombre";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(176, 32);
			this.label2.TabIndex = 6;
			this.label2.Text = "Nombre de la particula dibujable";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 32);
			this.label3.TabIndex = 7;
			this.label3.Text = "Nombre del Ensamblado de la Particula";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(168, 32);
			this.label4.TabIndex = 8;
			this.label4.Text = "Nombre del ensamblado de la Particula Dibujable";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 168);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(168, 32);
			this.label5.TabIndex = 9;
			this.label5.Text = "Nombre del parametro de Particula";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 200);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(160, 32);
			this.label6.TabIndex = 10;
			this.label6.Text = "Direccion de la dll del Ensamblado de la Particula";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 240);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(160, 40);
			this.label7.TabIndex = 12;
			this.label7.Text = "Direccion de la dll del Ensamblado de la Particula Dibujable";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(232, 192);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(32, 32);
			this.button1.TabIndex = 13;
			this.button1.Text = ". . .";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(232, 240);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(32, 32);
			this.button2.TabIndex = 14;
			this.button2.Text = ". . .";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.listBox1);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Location = new System.Drawing.Point(16, 288);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(280, 120);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Datos de los Parametros";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(88, 64);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(104, 40);
			this.button3.TabIndex = 2;
			this.button3.Text = "Definir datos de los parametros";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 16;
			this.listBox1.Items.AddRange(new object[] {
														  "1",
														  "2",
														  "3",
														  "4",
														  "5",
														  "6",
														  "7",
														  "8",
														  "9",
														  "10"});
			this.listBox1.Location = new System.Drawing.Point(208, 24);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(40, 20);
			this.listBox1.TabIndex = 1;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(152, 16);
			this.label8.TabIndex = 0;
			this.label8.Text = "Cantidad de parametros";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(104, 440);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(104, 32);
			this.button4.TabIndex = 16;
			this.button4.Text = "Agregar Particula";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// AddParticula
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(218)), ((System.Byte)(250)));
			this.ClientSize = new System.Drawing.Size(312, 486);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "AddParticula";
			this.ShowInTaskbar = false;
			this.Text = "AddParticula";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.AddParticula_Closing);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void button3_Click(object sender, System.EventArgs e)
		{
			int aux=listBox1.SelectedIndex+1;
			pInfo.InfoParametro=new ParametroInfo(aux);
			
			for(int i=1;i<=aux;i++)
			{
				DetalleParametro det=new DetalleParametro(i);
				det.ShowDialog();
				pInfo.InfoParametro.ListaDatosDeParametros[i-1]=new DatosDeParametroInfo(det.Nombre,det.Tipo);
				
				det.Close();
			}
			pressed=true;
		}

		public bool Lleno 
		{
			get 
			{
				return this.filled;
			}
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			if(textBox1.Text.Trim()=="" || textBox2.Text.Trim()=="" || textBox3.Text.Trim()=="" || textBox4.Text.Trim()=="" || textBox5.Text.Trim()=="" || path=="" || pathDibujable=="" || !pressed)
			{
				MessageBox.Show("Hay que llenar todos los campos");
				return;
				filled = false;
			}
			pInfo.Nombre=textBox1.Text;
			
			pInfo.NombreDibujable=textBox2.Text;
			pInfo.Ensamblado=textBox3.Text;
			pInfo.EnsambladoDibujable=textBox4.Text;
			pInfo.ParametroDeParticula=textBox5.Text;
			pInfo.Path=path;
			pInfo.PathDibujable=pathDibujable;
			filled = true;
			this.Visible=false;				
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog()==DialogResult.OK && openFileDialog1.FileName.Trim()!="")
				path=openFileDialog1.FileName;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Trim() != "")
				pathDibujable=openFileDialog1.FileName;
		}

		private void AddParticula_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || path == "" || pathDibujable == "" || !pressed)
			{
				filled = false;
			}
		}
	
		public ParticulaInfo Info
		{
			get
			{
				return this.pInfo;
			}
		}
	}
}
