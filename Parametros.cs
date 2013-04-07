using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for Parametros.
	/// </summary>
	public class Parametros : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private RSAConfiguration config;
		private ParametroInfo pInfo;
		private System.Windows.Forms.Button button1;
		private object[] val;
		private Label[] labels;
		private TextBox[] text;

		public Parametros(RSAConfiguration configuration,ParametroInfo partInfo,object[] valores)
		{
			config=configuration;
			pInfo=partInfo;
			val=valores;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			InitMycontrols();
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
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(20, 128);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "Aceptar";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Parametros
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(196)), ((System.Byte)(218)), ((System.Byte)(250)));
			this.ClientSize = new System.Drawing.Size(168, 294);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Parametros";
			this.ShowInTaskbar = false;
			this.Text = "Parametros";
			this.ResumeLayout(false);

		}
		#endregion

		#region MyControls
		private void InitMycontrols()
		{
			labels=new Label[pInfo.Cantidad];
			text=new TextBox[pInfo.Cantidad];
			this.SuspendLayout();
			int i=0;
			for(i=0;i<pInfo.Cantidad;i++)
			{
				labels[i]=new Label();
				text[i]=new TextBox();
				//
				//labels
				//
				labels[i].Location = new System.Drawing.Point(20, 20+i*50);
				labels[i].Name = "label1"+i.ToString();
				labels[i].Text = pInfo.ListaDatosDeParametros[i].nombre;
				labels[i].Size = new System.Drawing.Size(100, 15);
				// 
				// textBox1
				// 
				text[i].Location = new System.Drawing.Point(20,40+i*50);
				text[i].Name = "textBox1"+i.ToString();
				text[i].Text = val[i].ToString();
				text[i].Size = new System.Drawing.Size(100, 20);
				this.Controls.Add(labels[i]);
				this.Controls.Add(text[i]);
			}
			this.ResumeLayout(false);
			this.button1.Top=20+i*50;
			this.ClientSize = new System.Drawing.Size(this.ClientSize.Width, 20+i*50+20+this.button1.Height);
		}
		#endregion

		public object[] Valores
		{
			get
			{
				return this.val;
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<pInfo.Cantidad;i++)
			{
				val[i]=RSAConfiguration.Parse(text[i].Text,pInfo.ListaDatosDeParametros[i].tipo);
			}
			this.Visible=false;
		}
	}
}


