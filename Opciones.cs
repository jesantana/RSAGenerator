using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for Opciones.
	/// </summary>
	public class Opciones : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.TrackBar trackBar2;
		private System.Windows.Forms.TrackBar trackBar3;
		private System.Windows.Forms.TrackBar trackBar4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
		private Scene scene;
		
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label5;
		protected float[] color;

		public Opciones(string quien,float[] col)
		{
			
			color=col;
			for(int i=0;i<4;i++)
			{
				if(color[i]<0 || color[i]>1)throw new Exception("Color Invalido");
			}
			scene = new Scene();
			scene.redraw += new EventHandler(scene_redraw);
			InitializeComponent();
			simpleOpenGlControl1.InitializeContexts();
			scene.Initialize();
			scene.Reshape(simpleOpenGlControl1.Width, simpleOpenGlControl1.Height);
			scene.element=new ColorDibujable(new Point3d(0,0,-10),color);/*new Ortoedro(new Point3D(-2,1.5,-10),4,3,2,new float[3]{0.3f,0.7f,0.9f});*/
			this.trackBar1.Value=(int)(color[0]*100);
			this.trackBar2.Value=(int)(color[1]*100);
			this.trackBar3.Value=(int)(color[2]*100);
			this.trackBar4.Value=(int)(color[3]*100);
			label5.Text="Color del Elemento "+quien;
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


		public float[] Color
		{
			get{return this.color;}
		}


		private void simpleOpenGlControl1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			this.scene.Draw();
		}

		
		private void scene_redraw(object sender, EventArgs e)
		{
			this.Refresh();
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Opciones));
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.trackBar2 = new System.Windows.Forms.TrackBar();
			this.trackBar3 = new System.Windows.Forms.TrackBar();
			this.trackBar4 = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.simpleOpenGlControl1 = new Tao.Platform.Windows.SimpleOpenGlControl();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
			this.SuspendLayout();
			// 
			// trackBar1
			// 
			this.trackBar1.LargeChange = 10;
			this.trackBar1.Location = new System.Drawing.Point(96, 40);
			this.trackBar1.Maximum = 100;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(104, 45);
			this.trackBar1.SmallChange = 5;
			this.trackBar1.TabIndex = 0;
			this.trackBar1.Tag = "0";
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// trackBar2
			// 
			this.trackBar2.LargeChange = 10;
			this.trackBar2.Location = new System.Drawing.Point(96, 88);
			this.trackBar2.Maximum = 100;
			this.trackBar2.Name = "trackBar2";
			this.trackBar2.Size = new System.Drawing.Size(104, 45);
			this.trackBar2.SmallChange = 5;
			this.trackBar2.TabIndex = 1;
			this.trackBar2.Tag = "1";
			this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.trackBar2.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// trackBar3
			// 
			this.trackBar3.LargeChange = 10;
			this.trackBar3.Location = new System.Drawing.Point(96, 136);
			this.trackBar3.Maximum = 100;
			this.trackBar3.Name = "trackBar3";
			this.trackBar3.Size = new System.Drawing.Size(104, 45);
			this.trackBar3.SmallChange = 5;
			this.trackBar3.TabIndex = 2;
			this.trackBar3.Tag = "2";
			this.trackBar3.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.trackBar3.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// trackBar4
			// 
			this.trackBar4.LargeChange = 10;
			this.trackBar4.Location = new System.Drawing.Point(96, 184);
			this.trackBar4.Maximum = 100;
			this.trackBar4.Name = "trackBar4";
			this.trackBar4.Size = new System.Drawing.Size(104, 45);
			this.trackBar4.SmallChange = 5;
			this.trackBar4.TabIndex = 3;
			this.trackBar4.Tag = "3";
			this.trackBar4.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.trackBar4.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Rojo";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Verde";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 144);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Azul";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 192);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Transparencia";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.Location = new System.Drawing.Point(136, 248);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(136, 48);
			this.button1.TabIndex = 8;
			this.button1.Text = "Aceptar";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// simpleOpenGlControl1
			// 
			this.simpleOpenGlControl1.AccumBits = ((System.Byte)(0));
			this.simpleOpenGlControl1.AutoCheckErrors = false;
			this.simpleOpenGlControl1.AutoFinish = false;
			this.simpleOpenGlControl1.AutoMakeCurrent = true;
			this.simpleOpenGlControl1.AutoSwapBuffers = true;
			this.simpleOpenGlControl1.BackColor = System.Drawing.Color.Black;
			this.simpleOpenGlControl1.ColorBits = ((System.Byte)(32));
			this.simpleOpenGlControl1.DepthBits = ((System.Byte)(16));
			this.simpleOpenGlControl1.Location = new System.Drawing.Point(224, 40);
			this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
			this.simpleOpenGlControl1.Size = new System.Drawing.Size(180, 180);
			this.simpleOpenGlControl1.StencilBits = ((System.Byte)(0));
			this.simpleOpenGlControl1.TabIndex = 9;
			this.simpleOpenGlControl1.Resize += new System.EventHandler(this.simpleOpenGlControl1_Resize_1);
			this.simpleOpenGlControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenGlControl1_Paint);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(184, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "Color del elemento";
			// 
			// Opciones
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(196)), ((System.Byte)(218)), ((System.Byte)(250)));
			this.ClientSize = new System.Drawing.Size(448, 326);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.simpleOpenGlControl1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.trackBar4);
			this.Controls.Add(this.trackBar3);
			this.Controls.Add(this.trackBar2);
			this.Controls.Add(this.trackBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Opciones";
			this.ShowInTaskbar = false;
			this.Text = "Opciones";
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleOpenGlControl1_Resize_1(object sender, System.EventArgs e)
		{
			scene.Reshape(simpleOpenGlControl1.Width, simpleOpenGlControl1.Height);
		}

		private void trackBar1_Scroll(object sender, System.EventArgs e)
		{
			TrackBar taux=(TrackBar)sender;
			color[int.Parse((string)taux.Tag)]=taux.Value/100.0f;
			//simpleOpenGlControl1.Update();
			((ColorDibujable)this.scene.element).Color=color;
			this.scene.element.Recompile();
			this.Refresh();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Visible=false;
		}
	}
}
