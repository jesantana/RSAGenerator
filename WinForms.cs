using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for WinForms.
	/// </summary>
	public class WinForms : System.Windows.Forms.Form,ITracker		
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
		private System.Windows.Forms.TabControl uiTab1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox editBox1;
		private System.Windows.Forms.TextBox editBox2;
		private System.Windows.Forms.TextBox editBox3;
		private System.Windows.Forms.TextBox editBox5;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RichTextBox editBox4;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox numericEditBox1;
		private System.Windows.Forms.TextBox numericEditBox2;
		private System.Windows.Forms.TextBox numericEditBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.StatusBar uiStatusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.ComponentModel.IContainer components;

		private bool fraccChanged;
		private bool modified;
		private Scene scene;
		private RSAConfiguration config;
		private System.Windows.Forms.CheckBox checkBox1;
		private XmlParticulaReader reader;
		private int mousex;
		private int mousey;
		private bool pressed;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.RadioButton radioButton7;
		private System.Windows.Forms.RadioButton radioButton8;
		private System.Windows.Forms.TextBox textBox2;
		private System.DirectoryServices.DirectorySearcher directorySearcher1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.CheckBox checkBox3;
		private bool pressedR;

		[DllImport("user32.dll")]
		public static extern void SetCursorPos(int x,int y);
		[DllImport("user32.dll")]
		public static extern void GetCursorPos(ref Point point);

		public Point GetCursorPosFromOGL() 
		{
			Point p=new Point();
			WinForms.GetCursorPos(ref p);
			return this.simpleOpenGlControl1.PointToClient(p);
		}

		public WinForms()
		{
			modified=false;
			scene = new Scene();
			scene.redraw += new EventHandler(scene_redraw);
			InitializeComponent();
			if(Screen.PrimaryScreen.Bounds.Width==800 &&Screen.PrimaryScreen.Bounds.Height==600)
			{
				this.WindowState=FormWindowState.Maximized;
			}
			this.uiStatusBar1.Panels[0].Width=this.uiTab1.Location.X+uiTab1.Width;
			

			simpleOpenGlControl1.InitializeContexts();
			scene.Initialize();
			scene.Reshape(simpleOpenGlControl1.Width, simpleOpenGlControl1.Height);
			config=new RSAConfiguration();
			reader=new XmlParticulaReader((string)config.Valores["particulaXml"]);
			ParametroInfo pInfo=reader.GetInfoParametros((string)config.Valores["particulaInicial"]);
			//			varPar=(object[])config.Valores["parametros"];
			//			for(int i=0;i<pInfo.Cantidad;i++)
			//			{
			//				varPar[i]=0;
			//			}
			scene.element=new RSADibujable(config, reader.GetInfoParticulas((string)config.Valores["particulaInicial"]),this);
			textBox1.Text=((RSADibujable)scene.element).AnsysObj.Ruta;
			textBox2.Text=((RSADibujable)scene.element).AnsysObj.NombreArchivo;
			Init();
//			this.progressBar1.Location=this.uiStatusBar1.Location;
//			this.progressBar1.Left=this.uiTab1.Location.X+uiTab1.Width;
//			this.progressBar1.Top-=this.progressBar1.Height;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(WinForms));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.uiTab1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.editBox4 = new System.Windows.Forms.RichTextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.editBox5 = new System.Windows.Forms.TextBox();
			this.editBox3 = new System.Windows.Forms.TextBox();
			this.editBox2 = new System.Windows.Forms.TextBox();
			this.editBox1 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.numericEditBox2 = new System.Windows.Forms.TextBox();
			this.numericEditBox1 = new System.Windows.Forms.TextBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.button5 = new System.Windows.Forms.Button();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.button6 = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.numericEditBox3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.button3 = new System.Windows.Forms.Button();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.button8 = new System.Windows.Forms.Button();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.button7 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.simpleOpenGlControl1 = new Tao.Platform.Windows.SimpleOpenGlControl();
			this.uiStatusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
			this.uiTab1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.groupBox9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(336, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(459, 99);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(196)), ((System.Byte)(218)), ((System.Byte)(250)));
			this.pictureBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(-8, 0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(347, 66);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox2.TabIndex = 3;
			this.pictureBox2.TabStop = false;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2,
																					  this.menuItem7});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem6,
																					  this.menuItem5});
			this.menuItem1.Text = "Archivo";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 0;
			this.menuItem6.Text = "Guardar Coordenadas";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 1;
			this.menuItem5.Text = "Salir";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem3,
																					  this.menuItem4});
			this.menuItem2.Text = "Opciones";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.Text = "Cambiar Particula";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "Agregar Definición de Particula";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 2;
			this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem8,
																					  this.menuItem9});
			this.menuItem7.Text = "Ayuda";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 0;
			this.menuItem8.Text = "Temas de Ayuda";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 1;
			this.menuItem9.Text = "Acerca de RSA Generator";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// uiTab1
			// 
			this.uiTab1.Controls.Add(this.tabPage1);
			this.uiTab1.Controls.Add(this.tabPage2);
			this.uiTab1.Controls.Add(this.tabPage3);
			this.uiTab1.Controls.Add(this.tabPage4);
			this.uiTab1.ImageList = this.imageList1;
			this.uiTab1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.uiTab1.Location = new System.Drawing.Point(8, 112);
			this.uiTab1.Name = "uiTab1";
			this.uiTab1.SelectedIndex = 0;
			this.uiTab1.Size = new System.Drawing.Size(368, 384);
			this.uiTab1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(196)), ((System.Byte)(218)), ((System.Byte)(250)));
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.button2);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.progressBar1);
			this.tabPage1.ImageIndex = 2;
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(360, 355);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Generar";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.editBox4);
			this.groupBox2.Location = new System.Drawing.Point(8, 152);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(352, 184);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Descripcion de la Generacion de Particulas";
			// 
			// editBox4
			// 
			this.editBox4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(218)), ((System.Byte)(250)));
			this.editBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.editBox4.Location = new System.Drawing.Point(8, 24);
			this.editBox4.Name = "editBox4";
			this.editBox4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.editBox4.Size = new System.Drawing.Size(336, 152);
			this.editBox4.TabIndex = 0;
			this.editBox4.Text = "";
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(80)), ((System.Byte)(80)));
			this.button2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.White;
			this.button2.ImageIndex = 4;
			this.button2.ImageList = this.imageList1;
			this.button2.Location = new System.Drawing.Point(248, 80);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(112, 56);
			this.button2.TabIndex = 10;
			this.button2.Text = "Limpiar";
			this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(80)), ((System.Byte)(80)));
			this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.ImageIndex = 3;
			this.button1.ImageList = this.imageList1;
			this.button1.Location = new System.Drawing.Point(248, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 56);
			this.button1.TabIndex = 9;
			this.button1.Text = "Generar";
			this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.editBox5);
			this.groupBox1.Controls.Add(this.editBox3);
			this.groupBox1.Controls.Add(this.editBox2);
			this.groupBox1.Controls.Add(this.editBox1);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(8, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(240, 120);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Parametros Iniciales";
			// 
			// editBox5
			// 
			this.editBox5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(218)), ((System.Byte)(250)));
			this.editBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.editBox5.Location = new System.Drawing.Point(136, 88);
			this.editBox5.Name = "editBox5";
			this.editBox5.ReadOnly = true;
			this.editBox5.Size = new System.Drawing.Size(96, 20);
			this.editBox5.TabIndex = 11;
			this.editBox5.Text = "";
			// 
			// editBox3
			// 
			this.editBox3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(218)), ((System.Byte)(250)));
			this.editBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.editBox3.Location = new System.Drawing.Point(136, 64);
			this.editBox3.Name = "editBox3";
			this.editBox3.ReadOnly = true;
			this.editBox3.Size = new System.Drawing.Size(96, 20);
			this.editBox3.TabIndex = 10;
			this.editBox3.Text = "";
			// 
			// editBox2
			// 
			this.editBox2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(218)), ((System.Byte)(250)));
			this.editBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.editBox2.Location = new System.Drawing.Point(136, 40);
			this.editBox2.Name = "editBox2";
			this.editBox2.ReadOnly = true;
			this.editBox2.Size = new System.Drawing.Size(96, 20);
			this.editBox2.TabIndex = 9;
			this.editBox2.Text = "";
			// 
			// editBox1
			// 
			this.editBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(218)), ((System.Byte)(250)));
			this.editBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.editBox1.Location = new System.Drawing.Point(136, 16);
			this.editBox1.Name = "editBox1";
			this.editBox1.ReadOnly = true;
			this.editBox1.Size = new System.Drawing.Size(96, 20);
			this.editBox1.TabIndex = 8;
			this.editBox1.Text = "";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(16, 88);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 16);
			this.label8.TabIndex = 6;
			this.label8.Text = "Lado del cubo";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(16, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Tipo de Particula";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Cantidad de Particulas";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Fraccion Volumetrica";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(8, 336);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(352, 16);
			this.progressBar1.TabIndex = 7;
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(196)), ((System.Byte)(218)), ((System.Byte)(250)));
			this.tabPage2.Controls.Add(this.numericEditBox2);
			this.tabPage2.Controls.Add(this.numericEditBox1);
			this.tabPage2.Controls.Add(this.groupBox8);
			this.tabPage2.Controls.Add(this.button5);
			this.tabPage2.Controls.Add(this.groupBox7);
			this.tabPage2.Controls.Add(this.groupBox6);
			this.tabPage2.Controls.Add(this.groupBox5);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.ImageIndex = 0;
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(360, 355);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Parametros";
			// 
			// numericEditBox2
			// 
			this.numericEditBox2.Location = new System.Drawing.Point(168, 40);
			this.numericEditBox2.Name = "numericEditBox2";
			this.numericEditBox2.Size = new System.Drawing.Size(136, 20);
			this.numericEditBox2.TabIndex = 20;
			this.numericEditBox2.Text = "";
			// 
			// numericEditBox1
			// 
			this.numericEditBox1.Location = new System.Drawing.Point(168, 8);
			this.numericEditBox1.Name = "numericEditBox1";
			this.numericEditBox1.Size = new System.Drawing.Size(136, 20);
			this.numericEditBox1.TabIndex = 19;
			this.numericEditBox1.Text = "";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.radioButton6);
			this.groupBox8.Controls.Add(this.radioButton5);
			this.groupBox8.Location = new System.Drawing.Point(8, 261);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(344, 51);
			this.groupBox8.TabIndex = 18;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Variante del Algoritmo a Usar para Generar";
			// 
			// radioButton6
			// 
			this.radioButton6.Checked = true;
			this.radioButton6.Location = new System.Drawing.Point(200, 24);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.TabIndex = 1;
			this.radioButton6.TabStop = true;
			this.radioButton6.Text = "RSA Avanzado";
			// 
			// radioButton5
			// 
			this.radioButton5.Location = new System.Drawing.Point(16, 24);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.TabIndex = 0;
			this.radioButton5.Text = "RSA Clasico";
			// 
			// button5
			// 
			this.button5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(80)), ((System.Byte)(80)));
			this.button5.ForeColor = System.Drawing.Color.White;
			this.button5.Location = new System.Drawing.Point(48, 320);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(256, 24);
			this.button5.TabIndex = 17;
			this.button5.Text = "Aplicar Cambios";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.button6);
			this.groupBox7.Enabled = false;
			this.groupBox7.Location = new System.Drawing.Point(184, 165);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(168, 72);
			this.groupBox7.TabIndex = 16;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Otros Parametros fijo";
			// 
			// button6
			// 
			this.button6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(80)), ((System.Byte)(80)));
			this.button6.ForeColor = System.Drawing.Color.White;
			this.button6.Location = new System.Drawing.Point(8, 24);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(152, 40);
			this.button6.TabIndex = 1;
			this.button6.Text = "Cambiar valor a los parametros ";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.numericEditBox3);
			this.groupBox6.Controls.Add(this.label6);
			this.groupBox6.Location = new System.Drawing.Point(8, 165);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(168, 72);
			this.groupBox6.TabIndex = 15;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Numero de Particulas Fijo";
			// 
			// numericEditBox3
			// 
			this.numericEditBox3.Location = new System.Drawing.Point(8, 48);
			this.numericEditBox3.Name = "numericEditBox3";
			this.numericEditBox3.Size = new System.Drawing.Size(112, 20);
			this.numericEditBox3.TabIndex = 1;
			this.numericEditBox3.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(120, 16);
			this.label6.TabIndex = 0;
			this.label6.Text = "Numero de particulas";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.radioButton4);
			this.groupBox5.Controls.Add(this.radioButton3);
			this.groupBox5.Location = new System.Drawing.Point(8, 77);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(344, 80);
			this.groupBox5.TabIndex = 14;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Parametros Variables";
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(8, 48);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(320, 24);
			this.radioButton4.TabIndex = 8;
			this.radioButton4.Text = "Tener fijo  parametros y variar el numero de particulas";
			// 
			// radioButton3
			// 
			this.radioButton3.Checked = true;
			this.radioButton3.Location = new System.Drawing.Point(8, 24);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(320, 24);
			this.radioButton3.TabIndex = 7;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Tener Fijo el numero de particulas y variar parametros";
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 37);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(144, 23);
			this.label5.TabIndex = 12;
			this.label5.Text = "Fraccion Volumetrica";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(152, 23);
			this.label4.TabIndex = 11;
			this.label4.Text = "Longitud del Lado del Cubo";
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(196)), ((System.Byte)(218)), ((System.Byte)(250)));
			this.tabPage3.Controls.Add(this.groupBox4);
			this.tabPage3.Controls.Add(this.groupBox3);
			this.tabPage3.ImageIndex = 1;
			this.tabPage3.Location = new System.Drawing.Point(4, 23);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(360, 357);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Graficos";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.button4);
			this.groupBox4.Location = new System.Drawing.Point(28, 277);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(304, 64);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Opciones Visuales del Cubo";
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(80)), ((System.Byte)(80)));
			this.button4.ForeColor = System.Drawing.Color.White;
			this.button4.Location = new System.Drawing.Point(16, 24);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(264, 24);
			this.button4.TabIndex = 0;
			this.button4.Text = "Abrir Dialogo de Personalizar Color de Cubo";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.checkBox2);
			this.groupBox3.Controls.Add(this.button3);
			this.groupBox3.Controls.Add(this.radioButton2);
			this.groupBox3.Controls.Add(this.radioButton1);
			this.groupBox3.Location = new System.Drawing.Point(28, 29);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(304, 224);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Opciones Visuales de Particulas";
			// 
			// checkBox2
			// 
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Location = new System.Drawing.Point(8, 144);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(272, 16);
			this.checkBox2.TabIndex = 3;
			this.checkBox2.Text = "Numerar las Particulas";
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(80)), ((System.Byte)(80)));
			this.button3.ForeColor = System.Drawing.Color.White;
			this.button3.Location = new System.Drawing.Point(16, 192);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(264, 24);
			this.button3.TabIndex = 2;
			this.button3.Text = "Abrir Dialogo de Pesonalizar Color de Particula";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// radioButton2
			// 
			this.radioButton2.Checked = true;
			this.radioButton2.Location = new System.Drawing.Point(8, 72);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(272, 24);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Personalizar Color de Particula";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(8, 32);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(272, 24);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "Poner un Color Aleatorio a cada particula";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// tabPage4
			// 
			this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(196)), ((System.Byte)(218)), ((System.Byte)(250)));
			this.tabPage4.Controls.Add(this.button8);
			this.tabPage4.Controls.Add(this.groupBox9);
			this.tabPage4.Controls.Add(this.button7);
			this.tabPage4.Controls.Add(this.textBox1);
			this.tabPage4.Controls.Add(this.label7);
			this.tabPage4.ImageIndex = 5;
			this.tabPage4.Location = new System.Drawing.Point(4, 23);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(360, 357);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "ANSYS";
			// 
			// button8
			// 
			this.button8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(80)), ((System.Byte)(80)));
			this.button8.ForeColor = System.Drawing.Color.White;
			this.button8.Location = new System.Drawing.Point(104, 312);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(128, 32);
			this.button8.TabIndex = 4;
			this.button8.Text = "Aceptar";
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.checkBox3);
			this.groupBox9.Controls.Add(this.label9);
			this.groupBox9.Controls.Add(this.textBox2);
			this.groupBox9.Controls.Add(this.radioButton8);
			this.groupBox9.Controls.Add(this.radioButton7);
			this.groupBox9.Location = new System.Drawing.Point(16, 112);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(304, 192);
			this.groupBox9.TabIndex = 3;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Opciones del Archivo a Guardar";
			// 
			// checkBox3
			// 
			this.checkBox3.Checked = true;
			this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox3.Location = new System.Drawing.Point(16, 88);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(264, 32);
			this.checkBox3.TabIndex = 4;
			this.checkBox3.Text = "Agregar al nombre datos de los Parametros de la Generacion";
			this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 136);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(136, 16);
			this.label9.TabIndex = 3;
			this.label9.Text = "Nombre del archivo";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(16, 160);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(272, 20);
			this.textBox2.TabIndex = 2;
			this.textBox2.Text = "batch.txt";
			// 
			// radioButton8
			// 
			this.radioButton8.Location = new System.Drawing.Point(16, 48);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.Size = new System.Drawing.Size(256, 16);
			this.radioButton8.TabIndex = 1;
			this.radioButton8.Text = "Generar nuevos Archivos en cada corrida";
			// 
			// radioButton7
			// 
			this.radioButton7.Checked = true;
			this.radioButton7.Location = new System.Drawing.Point(16, 24);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size(256, 16);
			this.radioButton7.TabIndex = 0;
			this.radioButton7.TabStop = true;
			this.radioButton7.Text = "Sobre-escribir el Archivo Generado";
			// 
			// button7
			// 
			this.button7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(80)), ((System.Byte)(80)));
			this.button7.ForeColor = System.Drawing.Color.White;
			this.button7.Location = new System.Drawing.Point(320, 56);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(32, 24);
			this.button7.TabIndex = 2;
			this.button7.Text = ". . .";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 56);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(304, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(280, 24);
			this.label7.TabIndex = 0;
			this.label7.Text = "Ruta de los archivos Batch de Ansys Generados";
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
			this.simpleOpenGlControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.simpleOpenGlControl1.Location = new System.Drawing.Point(384, 112);
			this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
			this.simpleOpenGlControl1.Size = new System.Drawing.Size(396, 340);
			this.simpleOpenGlControl1.StencilBits = ((System.Byte)(0));
			this.simpleOpenGlControl1.TabIndex = 5;
			this.simpleOpenGlControl1.Resize += new System.EventHandler(this.simpleOpenGlControl1_Resize);
			this.simpleOpenGlControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl1_MouseUp);
			this.simpleOpenGlControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenGlControl1_Paint);
			this.simpleOpenGlControl1.MouseEnter += new System.EventHandler(this.simpleOpenGlControl1_MouseEnter);
			this.simpleOpenGlControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl1_MouseMove);
			this.simpleOpenGlControl1.MouseLeave += new System.EventHandler(this.simpleOpenGlControl1_MouseLeave);
			this.simpleOpenGlControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl1_MouseDown);
			// 
			// uiStatusBar1
			// 
			this.uiStatusBar1.Location = new System.Drawing.Point(0, 514);
			this.uiStatusBar1.Name = "uiStatusBar1";
			this.uiStatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																							this.statusBarPanel1,
																							this.statusBarPanel2});
			this.uiStatusBar1.ShowPanels = true;
			this.uiStatusBar1.Size = new System.Drawing.Size(792, 22);
			this.uiStatusBar1.TabIndex = 6;
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel1.Text = "Listo";
			this.statusBarPanel1.Width = 388;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel2.Width = 388;
			// 
			// checkBox1
			// 
			this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox1.Location = new System.Drawing.Point(552, 456);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(224, 24);
			this.checkBox1.TabIndex = 8;
			this.checkBox1.Text = "Ver Tipo \"Spheres in Box\"";
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// WinForms
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(198)), ((System.Byte)(216)), ((System.Byte)(250)));
			this.ClientSize = new System.Drawing.Size(792, 536);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.uiStatusBar1);
			this.Controls.Add(this.simpleOpenGlControl1);
			this.Controls.Add(this.uiTab1);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "WinForms";
			this.Text = "RSA Generator";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.WinForms_Closing);
			this.uiTab1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

//		private void SetTrack(object state)
//		{
//			ITrackeable tracker=((RSADibujable)scene.element).Rsa;
//			this.uiStatusBar1.Panels[1].ProgressBarValue=tracker.ValorPorCiento;
//		}

		private void Init()
		{
			editBox1.Text=Math.Round(((RSADibujable)scene.element).Rsa.FraccionVolumetrica,6).ToString();
			editBox2.Text=((RSADibujable)scene.element).Rsa.CantidadDeParticulas.ToString();
			editBox3.Text=((RSADibujable)scene.element).Rsa.InfoParticula.Nombre;
			checkBox1.Checked=((RSADibujable)scene.element).SpheresInBox;
			numericEditBox1.Text=((double)config.Valores["ladoCubo"]).ToString();;
			numericEditBox2.Text=((RSADibujable)scene.element).Rsa.FraccionVolumetrica.ToString();;
			radioButton3.Checked=((string)config.Valores["parametroVariable"]=="cantidadParticulas");
			radioButton4.Checked=!radioButton3.Checked;
			numericEditBox3.Text=((RSADibujable)scene.element).Rsa.CantidadDeParticulas.ToString();
			//numericEditBox4.Text=((RSADibujable)scene.element).Rsa.
			editBox5.Text=((double)config.Valores["ladoCubo"]).ToString();
			radioButton5.Checked=((string)config.Valores["rsaClase"]=="RSA");
			radioButton6.Checked=!radioButton5.Checked;
			fraccChanged=radioButton4.Checked;
		}

		private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
		{
			if(radioButton3.Checked)
			{
				groupBox6.Enabled=true;
				groupBox7.Enabled=false;
			}
			else
			{
				groupBox6.Enabled=false;
				groupBox7.Enabled=true;
			}
		}

		[STAThread]
		static void Main() 
		{
			Application.Run(new WinForms());
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			button3.Visible=!button3.Visible;
			if(radioButton2.Checked)
				((RSADibujable)scene.element).ColorDeParticulasAleatorio=false;
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(radioButton1.Checked)
			{
				((RSADibujable)scene.element).ColorDeParticulasAleatorio=false;
				((RSADibujable)scene.element).PonerColorAleatorioEnParticulas();
				scene.element.Recompile();
				this.Refresh();
			}
		}

		private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			if(checkBox2.Checked)
			{
				((RSADibujable)scene.element).MuestraNumeros=true;
			}
			else
			{
				((RSADibujable)scene.element).MuestraNumeros=false;
			}
			//scene.element.Recompile();
			this.Refresh();
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			Opciones o=new Opciones("Cubo",((RSADibujable)scene.element).ColorCubo);
			o.ShowDialog();
			float[] arrayColor=o.Color;
			o.Close();
			((RSADibujable)scene.element).ColorCubo=arrayColor;
			this.Refresh();
			scene.element.Recompile();
			this.Refresh();
			//scene.element.Recompile();
			//this.Refresh();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			float[] arrayColor=null;
			if(((RSADibujable)scene.element).ColorDeParticulasAleatorio)
			{
				arrayColor=new float[] { 0.7f, 0.3f, 0.0f, 0.65f };
			}
			else
			{
				arrayColor=((RSADibujable)scene.element).ColorParticula;	
			}
			Opciones o=new Opciones(((RSADibujable)scene.element).Rsa.InfoParticula.Nombre,arrayColor);
			o.ShowDialog();
			arrayColor=o.Color;
			o.Close();
			((RSADibujable)scene.element).ColorParticula=arrayColor;
			this.Refresh();
			scene.element.Recompile();
			this.Refresh();
			//scene.element.Recompile();
			//this.Refresh();
		}

		private void simpleOpenGlControl1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			this.scene.Draw();
		}

		private void simpleOpenGlControl1_Resize(object sender, System.EventArgs e)
		{
			scene.Reshape(simpleOpenGlControl1.Width, simpleOpenGlControl1.Height);
		}

		private void scene_redraw(object sender, EventArgs e)
		{
			this.Refresh();
		}

		


		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			string[] part=reader.GetNombreParticulas();
			int actPart=0;
			for(int i=0;i<part.Length;i++)
			{
				if(part[i]==(string)config.Valores["particulaInicial"])
					actPart=i;
			}
			
			ParticulaNom pnom=new ParticulaNom(part,actPart);
			pnom.ShowDialog();
			if((string)config.Valores["particulaInicial"]!=pnom.ParticulaSeleccionada)
			{
				modified=true;
				config.Valores["particulaInicial"]=pnom.ParticulaSeleccionada;
			}
			
			pnom.Close();
			Clear();
			((RSADibujable)scene.element).ReInit(config,reader.GetInfoParticulas((string)config.Valores["particulaInicial"]),this);
			Init();

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				int time=Environment.TickCount;
				button1.Enabled=false;
				this.Cursor=Cursors.WaitCursor;
				this.uiStatusBar1.Panels[0].Text="Generando...";
				bool response=((RSADibujable)this.scene.element).AplicaAlgoritmo();
				Particula[] partic=((RSADibujable)scene.element).Rsa.particulas;
				if(!response)
					editBox4.ForeColor=Color.Red;
				editBox4.AppendText("#                X                Y                Z\n");
				for(int i=0;i<partic.Length;i++)
				{
					editBox4.AppendText(i + 1 + "    " + Math.Round(partic[i].Posicion.X,8) + "    " + Math.Round(partic[i].Posicion.Y,8) + "    " + Math.Round(partic[i].Posicion.Z,8)+"\n");
				}
				if(response==true)
				{
					editBox4.AppendText("Algoritmo Aplicado Eficientemente\n");
					editBox4.AppendText("Lograda Fraccion Volumetrica de: "+((RSADibujable)scene.element).Rsa.FraccionVolumetrica.ToString());
				}
				else
				{
					editBox4.AppendText("El algoritmo durante esta corrida no fue capaz de alcanzar la fraccion deseada\n");
					editBox4.AppendText(((RSADibujable)scene.element).Rsa.MensajeDeFallo);
				}
				scene.element.Recompile();
				this.Cursor=Cursors.Default;
				this.uiStatusBar1.Panels[0].Text="Esta generación tomo "+((Environment.TickCount-time)/1000.0)+" segundos";
				this.Refresh();
				this.progressBar1.Value=0;
				if(response)
					((RSADibujable)this.scene.element).CrearANSYSBatch(checkBox1.Checked,radioButton7.Checked);
				
				
			}
			catch(Exception ex1)
			{
				MessageBox.Show("Ha ocurrido un error: "+ex1.Message);
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			Clear();
		}

		private void Clear()
		{
			try
			{
				((RSADibujable)this.scene.element).Reset();
				editBox4.Clear();
				editBox4.ForeColor=Color.Black;
				scene.element.Recompile();
				this.uiStatusBar1.Panels[0].Text="Listo";
				this.Refresh();
				button1.Enabled=true;
				this.progressBar1.Value=0;
			}
			catch(Exception ex1)
			{
				MessageBox.Show("Ha ocurrido un error: "+ex1.Message);
			}
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			Parametros par=new Parametros(config,reader.GetInfoParametros((string)config.Valores["particulaInicial"]),(object[])config.Valores["parametros"]);
			par.ShowDialog();
			config.Valores["parametros"]=par.Valores;
			par.Close();
			fraccChanged=true;
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			try
			{
				config.Valores["ladoCubo"]=RSAConfiguration.Parse(numericEditBox1.Text,"double");
				config.Valores["fraccionVolumetrica"]=RSAConfiguration.Parse(numericEditBox2.Text,"double");
				if(radioButton3.Checked)
				{
					config.Valores["parametroVariable"]="cantidadParticulas";
					config.Valores["cantidadParticulas"]=RSAConfiguration.Parse(numericEditBox3.Text,"int");;
					fraccChanged=false;
				}
				else
				{
					config.Valores["parametroVariable"]="parametros";
				}
				config.Valores["spheresInBox"]=checkBox1.Checked;
				config.Valores["colorParticulaAleatorio"]=radioButton1.Checked;
				config.Valores["mostrarNumeros"]=checkBox2.Checked;
				config.Valores["colorParticulas"]=((RSADibujable)scene.element).ColorParticula;
				config.Valores["colorCubo"]=((RSADibujable)scene.element).ColorCubo;
				if(radioButton5.Checked)
				{
					config.Valores["rsaClase"]="RSA";
				}
				else if(radioButton6.Checked)
				{
					config.Valores["rsaClase"]="RSAAdvanced";
				}
				modified=true;
				Clear();
				((RSADibujable)scene.element).ReInit(config,reader.GetInfoParticulas((string)config.Valores["particulaInicial"]),this);
				if(fraccChanged)
				{
					config.Valores["fraccionVolumetrica"]=((RSADibujable)scene.element).Rsa.FraccionVolumetrica;
					//fraccChanged=false;
					MessageBox.Show("Cambios aplicados satisfactoriamente. La fraccion de volumen quedo finalmente en : "+((RSADibujable)scene.element).Rsa.FraccionVolumetrica);
				}
				else
					MessageBox.Show("Cambios aplicados satisfactoriamente");
				Init();
			}
			catch(Exception ex1)
			{
				MessageBox.Show("Ha ocurrido un error: "+ex1.Message);
			}
		}
		#region ITracker Members

		public virtual void SetPorCiento(int valor)
		{
			this.progressBar1.Value=valor;
		}

		#endregion

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(checkBox1.Checked)
			{
				((RSADibujable)scene.element).SpheresInBox=true;
			}
			else
			{
				((RSADibujable)scene.element).SpheresInBox=false;
			}
			scene.element.Recompile();
			this.Refresh();
		}

		private void WinForms_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(modified)
			{
				DialogResult result=MessageBox.Show("¿Desea guardar la configuracion actual para que sea la predeterminda cuando reinicie la aplicacion?","Guardar",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
				if(DialogResult.Yes==result)
					config.GuardaValores();
				else if(result==DialogResult.Cancel)
				{
					e.Cancel=true;
				}
			}
		}

		private void simpleOpenGlControl1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button==MouseButtons.Left)
			{
				mousex=e.X;
				mousey=e.Y;
				pressed=true;
				scene.startDrag(new Point(e.X,e.Y));
			}
			else if(e.Button==MouseButtons.Right)
			{
				mousex=e.X;
				mousey=e.Y;
				pressedR=true;
				this.simpleOpenGlControl1.Cursor=Cursors.NoMoveVert;
			}
		}

		private void simpleOpenGlControl1_MouseEnter(object sender, System.EventArgs e)
		{
			ResetOGL();
		}

		private void simpleOpenGlControl1_MouseLeave(object sender, System.EventArgs e)
		{
			ResetOGL();
		}

		private void simpleOpenGlControl1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(pressed)
			{
				Point p=this.GetCursorPosFromOGL();
				scene.drag(p);
				ElementoDibujable.matrix=scene.matrix;
				this.Refresh();
				
			}
			else if (pressedR)
			{
				int rotx=Math.Abs(this.GetCursorPosFromOGL().Y-mousey)>10?Math.Sign(this.GetCursorPosFromOGL().Y-mousey):0;
				if(rotx>0){scene.BackCamera();}
				else if (rotx<0){scene.ForwCamera();}
				this.Refresh();
					
			}
		}

		private void simpleOpenGlControl1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ResetOGL();
		}

		public void ResetOGL()
		{
			pressed=false;
			pressedR=false;
			this.simpleOpenGlControl1.Cursor=Cursors.Hand;
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			AddParticula apart=new AddParticula();
			apart.ShowDialog();
			if (apart.Lleno)
			{
				reader.InsertInfoParticula(apart.Info);
				MessageBox.Show("Definicion de nueva particula agregada satisfactoriamente");
			}
			apart.Close();
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			if(((RSADibujable)scene.element).Rsa.particulas[0]!=null)
			{
				if(saveFileDialog1.ShowDialog()==DialogResult.OK && saveFileDialog1.FileName.Trim()!="")
				{
					FileStream fs=new FileStream(saveFileDialog1.FileName,FileMode.Create);
					StreamWriter bw=new StreamWriter(fs);
					Particula[] parti=((RSADibujable)scene.element).Rsa.particulas;
					bw.WriteLine("#             X             Y             Z");
					for(int i=0;i<parti.Length;i++)
					{
					
						bw.WriteLine(i + 1 + "    " + Math.Round(parti[i].Posicion.X, 8) + "    " + Math.Round(parti[i].Posicion.Y, 8) + "    " + Math.Round(parti[i].Posicion.Z, 8));
					}
					bw.Close();
					MessageBox.Show("Guardado Correctamente");
				}
				else
				{
					MessageBox.Show("Debe especificarse un nombre para el archivo a guardar");
				}
			}
			else
					MessageBox.Show("Debe realizarse una generación para poer guardar las coordenadas");
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			Environment.Exit(0);
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog fb=new FolderBrowserDialog();
			if(fb.ShowDialog()==DialogResult.OK)
			{
				textBox1.Text=fb.SelectedPath;
			}
			else
			{
				MessageBox.Show("Debe localizar una ruta");
			}
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			((RSADibujable)scene.element).AnsysObj.Ruta=textBox1.Text;
			((RSADibujable)scene.element).AnsysObj.NombreArchivo=textBox2.Text;
			MessageBox.Show("Cambios efectuados al generador de fichero batch de ANSYS");
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			new AcercaDe().ShowDialog();
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			if(File.Exists(Application.StartupPath+"//rsaHelp.chm"))
				Help.ShowHelp(this,Application.StartupPath+"//rsaHelp.chm");
			else
				MessageBox.Show("Error: El archivo de ayuda rsaHelp.chm esta perdido...");
		}

		private void checkBox3_CheckedChanged(object sender, System.EventArgs e)
		{
			((RSADibujable)scene.element).AnsysObj.AgregarDatosDeParametro=checkBox3.Checked;
		}

	}
}
