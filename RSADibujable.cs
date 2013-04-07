using System;
using Tao.OpenGl;
using Tao.Glut;

public class RSADibujable:ElementoDibujable
{
	protected RSA rsa;
	public ParticulaDibujable[] particDib;
	protected CuboDibujable cuboDib;
	protected bool spheresInBox;
    public GestorDibujables gestorDib;
    protected double[][] planosAClipear;
    protected int idVisualizarPlanesOn;
    protected int idVisualizarPlanesOff;
	public NumerosDibujables[] numdib;
	protected XmlParticulaReader xmlreader;
	protected bool aleatpart;
	protected float[] colorParticula;
	protected bool showNumber;
    protected ANSYSWriter ansyswriter;

	public RSADibujable(RSAConfiguration config,ParticulaInfo pInfo,ITracker track)
	{
		aleatpart=(bool)config.Valores["colorParticulaAleatorio"];
		showNumber=(bool)config.Valores["mostrarNumeros"];
		colorParticula=(float[])config.Valores["colorParticulas"];
		
		idVisualizarPlanesOn=Gl.glGenLists(1);
		idVisualizarPlanesOff=Gl.glGenLists(1);
        xmlreader = new XmlParticulaReader((string)config.Valores["particulaXml"]);
        //ParticulaInfo xmlInfo = pInfo;
		rsa=new GestorAlgoritmo().CreaRSA(config,pInfo,track);
//		if(((string)config.Valores["rsaClase"])=="RSAAdvanced")
//		{
//			if((((string)config.Valores["parametroVariable"])=="cantidadParticulas"))
//			{
//				rsa = new RSAAdvanced((double)config.Valores["ladoCubo"], (double)config.Valores["fraccionVolumetrica"],(int)config.Valores["cantidadParticulas"], pInfo,track);
//			}
//			else
//			{
//				if(((object[])config.Valores["parametros"]).Length!=pInfo.InfoParametro.Cantidad)throw new Exception("Error");
//                object[] auxArray=(object[])config.Valores["parametros"];
//				rsa = new RSAAdvanced((double)config.Valores["ladoCubo"], (double)config.Valores["fraccionVolumetrica"],auxArray, pInfo,track);
//			}
//		}
//		else
//		{
//			if((((string)config.Valores["parametroVariable"])=="cantidadParticulas"))
//			{
//				rsa=new RSA((double)config.Valores["ladoCubo"], (double)config.Valores["fraccionVolumetrica"],(int)config.Valores["cantidadParticulas"], pInfo,track);
//			}
//			else
//			{
//				if(((object[])config.Valores["parametros"]).Length!=pInfo.InfoParametro.Cantidad)throw new Exception("Error");
//				object[] auxArray=(object[])config.Valores["parametros"];
//				rsa = new RSA((double)config.Valores["ladoCubo"], (double)config.Valores["fraccionVolumetrica"],auxArray, pInfo,track);
//			}
//		}
        spheresInBox =(bool)config.Valores["spheresInBox"];
        gestorDib = new GestorDibujables(xmlreader);
        ParticulaDibujable.SetOwner(this);
        NumerosDibujables.SetOwner(this);
        cuboDib = new CuboDibujable(this, (float[])config.Valores["colorCubo"], new float[] { 0, 0, 0, 0 });
        planosAClipear = new double[6][] { new double[4] { 1, 0, 0, rsa.Cubo.PuntoInicial.X }, new double[4] { 0, 1, 0, rsa.Cubo.PuntoInicial.Y }, new double[4] { 0, 0, 1, rsa.Cubo.PuntoInicial.Z }, new double[4] { -1, 0, 0, rsa.Cubo.PuntoInicial.X + rsa.Cubo.Lado }, new double[4] { 0, -1, 0, rsa.Cubo.PuntoInicial.Y + rsa.Cubo.Lado }, new double[4] { 0, 0, -1, rsa.Cubo.PuntoInicial.Z + rsa.Cubo.Lado } };
        numdib = new NumerosDibujables[rsa.particulas.Length];
        ansyswriter = gestorDib.GeneraAnsysWriter(pInfo.Nombre, this.rsa);
        this.Recompile();
	}

	public virtual void ReInit(RSAConfiguration config,ParticulaInfo pInfo,ITracker track)
	{
		aleatpart=(bool)config.Valores["colorParticulaAleatorio"];
		showNumber=(bool)config.Valores["mostrarNumeros"];
		for(int i=0;i<colorParticula.Length;i++ )
			colorParticula[i]=((float[])config.Valores["colorParticulas"])[i];
		
//		idVisualizarPlanesOn=Gl.glGenLists(1);
//		idVisualizarPlanesOff=Gl.glGenLists(1);
		xmlreader.Path=(string)config.Valores["particulaXml"];
		//ParticulaInfo xmlInfo = xmlreader.GetInfoParticulas((string)config.Valores["particulaInicial"]);
		if(((string)config.Valores["rsaClase"])=="RSAAdvanced")
		{
			if((((string)config.Valores["parametroVariable"])=="cantidadParticulas"))
			{
				rsa = new RSAAdvanced((double)config.Valores["ladoCubo"], (double)config.Valores["fraccionVolumetrica"],(int)config.Valores["cantidadParticulas"], pInfo,track);
			}
			else
			{
				if(((object[])config.Valores["parametros"]).Length!=pInfo.InfoParametro.Cantidad)throw new Exception("Error");
				object[] auxArray=(object[])config.Valores["parametros"];
				rsa = new RSAAdvanced((double)config.Valores["ladoCubo"], (double)config.Valores["fraccionVolumetrica"],auxArray, pInfo,track);
			}
		}
		else
		{
			if((((string)config.Valores["parametroVariable"])=="cantidadParticulas"))
			{
				rsa=new RSA((double)config.Valores["ladoCubo"], (double)config.Valores["fraccionVolumetrica"],(int)config.Valores["cantidadParticulas"], pInfo,track);
			}
			else
			{
				if(((object[])config.Valores["parametros"]).Length!=pInfo.InfoParametro.Cantidad)throw new Exception("Error");
				object[] auxArray=(object[])config.Valores["parametros"];
				rsa = new RSA((double)config.Valores["ladoCubo"], (double)config.Valores["fraccionVolumetrica"],auxArray, pInfo,track);
			}
		}
		spheresInBox =(bool)config.Valores["spheresInBox"];
		gestorDib.Xml=xmlreader;
		ParticulaDibujable.SetOwner(this);
		NumerosDibujables.SetOwner(this);
		cuboDib.Color=(float[])config.Valores["colorCubo"];
		//planosAClipear = new double[6][] { new double[4] { 1, 0, 0, rsa.Cubo.PuntoInicial.X }, new double[4] { 0, 1, 0, rsa.Cubo.PuntoInicial.Y }, new double[4] { 0, 0, 1, rsa.Cubo.PuntoInicial.Z }, new double[4] { -1, 0, 0, rsa.Cubo.PuntoInicial.X + rsa.Cubo.Lado }, new double[4] { 0, -1, 0, rsa.Cubo.PuntoInicial.Y + rsa.Cubo.Lado }, new double[4] { 0, 0, -1, rsa.Cubo.PuntoInicial.Z + rsa.Cubo.Lado } };
		numdib = new NumerosDibujables[rsa.particulas.Length];
        ansyswriter = gestorDib.GeneraAnsysWriter(pInfo.Nombre, this.rsa);
        this.Recompile();
		
	}

	public virtual ANSYSWriter AnsysObj
	{
		get
		{
			return this.ansyswriter;
		}
	}

    public virtual void Reset() 
    {
        rsa.Reset();
        numdib = new NumerosDibujables[rsa.particulas.Length];
        this.particDib=null;
    }

	public virtual RSA Rsa
	{
		get
		{
			return this.rsa;
		}
	}

    public virtual void CrearANSYSBatch(bool inTheBox,bool overwrite) 
    {
        ansyswriter.CreateANSYSBatch(inTheBox,overwrite);
    }

	public virtual bool AplicaAlgoritmo()
	{
		bool result=this.rsa.Algoritmo();
		particDib = gestorDib.GeneraDibujables(rsa.particulas,colorParticula,aleatpart);
		for(int i=0;i<particDib.Length;i++)
		{
			numdib[i]=new NumerosDibujables(rsa.particulas[i],i+1,new double[]{1,0,0,0});
		}
		return result;
	}

    public static void DrawLetraEje(double x, double y, double z, int ejeNumero)
    {
        Gl.glPushMatrix();
        byte[][] raster = new byte[3][];
        raster[0] = new byte[] { 0x00, 0x00, 0xc3, 0x66, 0x3c, 0x18, 0x3c, 0x66, 0xc3, 0x00, 0x00, 0x00, 0x00 };
        raster[1] = new byte[] { 0xc0, 0x60, 0x60, 0x30, 0x18, 0x3c, 0x66, 0x66, 0xc3, 0x00, 0x00, 0x00, 0x00 };
        raster[2] = new byte[] { 0x00, 0x00, 0xff, 0x60, 0x30, 0x18, 0x0c, 0x06, 0xff, 0x00, 0x00, 0x00, 0x00 };


        Gl.glRasterPos3d(x, y, z);
        Gl.glBitmap(8, 13, 0.0f, 2.0f, 10.0f, 0.0f, raster[ejeNumero]);
        Gl.glFlush();

        Gl.glPopMatrix();
    }

    public double[][] PlanosAClipear
    {
        get
        {
			for(int i=0;i<3;i++)
			{
				planosAClipear[i][i]=1;
				planosAClipear[i][3]=rsa.Cubo.PuntoInicial[i];
				planosAClipear[3+i][i]=-1;
				planosAClipear[3+i][3]=rsa.Cubo.PuntoInicial[i]+rsa.Cubo.Lado;
			}

			return planosAClipear;
        }
    }
	
	public void RecompileCubo()
	{
		this.cuboDib.Recompile();
	}

	public void RecompileParticulas()
	{
			foreach (ParticulaDibujable e in particDib)
			{
				if (e != null)
				{
					e.Recompile();
				}
			}
		
	}

	public override void Recompile()
	{
		
		Gl.glDeleteLists(idVisualizar,1);
		Gl.glNewList(idVisualizar, Gl.GL_COMPILE);
		Gl.glPushMatrix();

		Gl.glLineWidth(1f);
		#region DibujaEjes
		Gl.glBegin(Gl.GL_LINES);
		Gl.glVertex3d(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2), rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado);
		Gl.glVertex3d(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2) + 1.5 * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado);

		Gl.glVertex3d(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2), rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado);
		Gl.glVertex3d(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2), rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0 + 1.5 * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado);

		Gl.glVertex3d(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2), rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado);
		Gl.glVertex3d(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2), rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado + 1.5 * rsa.Cubo.Lado);
		Gl.glEnd();
		#endregion

		#region DibujaBordes
		Gl.glDisable(Gl.GL_CULL_FACE);
		Gl.glBegin(Gl.GL_TRIANGLES);
		Gl.glVertex3d(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2) + (1.5 + 0.03) * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado);
		Gl.glVertex3d(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2) + 1.5 * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0 + 0.03 * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado);
		Gl.glVertex3d(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2) + 1.5 * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0 - 0.03 * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado);

		Gl.glVertex3d(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2), rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0 + (1.5 + 0.03) * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado);
		Gl.glVertex3d(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2) - 0.03 * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0 + (1.5) * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado);
		Gl.glVertex3d(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2) + 0.03 * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0 + (1.5) * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado);

		Gl.glVertex3d(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2), rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado + (1.5 + 0.03) * rsa.Cubo.Lado);
		Gl.glVertex3d(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2), rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0 + 0.03 * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado + 1.5 * rsa.Cubo.Lado);
		Gl.glVertex3d(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2), rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0 - 0.03 * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado + 1.5 * rsa.Cubo.Lado);


		Gl.glEnd();
		Gl.glEnable(Gl.GL_CULL_FACE);

		Gl.glLineWidth(1f);
		#endregion
		DrawLetraEje(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2) + 1.48 * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0 - 0.1 * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado, 0);
		DrawLetraEje(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2) - 0.1 * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0 + 1.48 * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado, 1);
		DrawLetraEje(rsa.Cubo.PuntoInicial.X - (rsa.Cubo.Lado / 2) - 0.1 * rsa.Cubo.Lado, rsa.Cubo.PuntoInicial.Y - rsa.Cubo.Lado / 2.0, rsa.Cubo.PuntoInicial.Z - 3 * rsa.Cubo.Lado + 1.48 * rsa.Cubo.Lado, 2);
		Gl.glPopMatrix();
		Gl.glEndList();

		cuboDib.Recompile();

		if(particDib!=null)
		{
			if (spheresInBox)
			{
				double[][] partInt = this.PlanosAClipear; 
				SetClipPlanesOn(partInt);
				SetClipPlanesOff(partInt);
			}

			foreach (ParticulaDibujable e in particDib)
			{
				if (e != null)
				{
					e.Recompile();
				}
			}
			if(showNumber)
			{
				foreach (NumerosDibujables n in numdib)
				{
					if (n != null)
					{
						n.Recompile();
					}
				}
			}
		} 
	}
	
	

	public virtual bool SpheresInBox
	{
		get{return this.spheresInBox;}
		set
		{
			spheresInBox=value;
			//this.Recompile();
		}
	}

    public override void Draw()
    {
        Gl.glPushMatrix();
        //this.Rota();
        //this.Rota(rotangle, rotx, roty, rotz);
        //Gl.glMultMatrixf(matriz);
		this.Rota1(this.PuntoRotacion);
		Gl.glCallList(idVisualizar);
		

		if(particDib!=null)
		{
			if (spheresInBox)
			{
				
				Gl.glCallList(idVisualizarPlanesOn);
			}
			
			if(showNumber)
			{
				foreach (NumerosDibujables n in numdib)
				{
					if (n != null)
					{
						n.Draw();
					}
				}
			}
        
			foreach (ParticulaDibujable e in particDib)
				if (e != null)
				{
					e.Draw();
				}
			if (spheresInBox)
			{
				
				Gl.glCallList(idVisualizarPlanesOff);
			}
		}
        cuboDib.Draw();
        Gl.glPopMatrix();
    }

    protected virtual void SetClipPlanesOn(double[][] planosInt)
    {
        int clipPlane = Gl.GL_CLIP_PLANE0;
        Gl.glNewList(idVisualizarPlanesOn, Gl.GL_COMPILE);
        Gl.glPushMatrix();
        Gl.glTranslated(cuboDib.Inicio.X, cuboDib.Inicio.Y - rsa.Cubo.Lado, cuboDib.Inicio.Z - rsa.Cubo.Lado);
        for (int i = 0; i < planosInt.Length; i++)
        {
            Gl.glEnable(clipPlane);
            Gl.glClipPlane(clipPlane++, planosInt[i]);
        }
        Gl.glPopMatrix();
        Gl.glEndList();
    }

    protected virtual void SetClipPlanesOff(double[][] planosInt)
    {
        int clipPlane = Gl.GL_CLIP_PLANE0;
        Gl.glNewList(idVisualizarPlanesOff, Gl.GL_COMPILE);
        Gl.glPushMatrix();
        for (int i = 0; i < planosInt.Length; i++)
        {
            Gl.glDisable(clipPlane++);
        }
        Gl.glPopMatrix();
        Gl.glEndList();
    }

	
	public virtual bool MuestraNumeros
	{
		get{return this.showNumber;}
		set{showNumber=value;}
	}

	public virtual bool ColorDeParticulasAleatorio
	{
		get{return aleatpart;}
		set{aleatpart=value;}
	}

	public virtual float[] ColorCubo
	{
		get
		{
			return this.cuboDib.Color;
		}
		set
		{
			this.cuboDib.Color=value;
		}
	}

	public virtual float[] ColorParticula
	{
		get
		{
			if(aleatpart)return null;
			return this.colorParticula;
		}
		set
		{
			if(aleatpart)throw new Exception("No se puede asignar una valor ahora a las particulas de color aleatorio");
			float[] colorParticula=value;
			if(particDib!=null && particDib[0]!=null)
			{
				for(int i=0;i<particDib.Length;i++)
				{
					particDib[i].Red=colorParticula[0];
					particDib[i].Green=colorParticula[1];
					particDib[i].Blue=colorParticula[2];
					particDib[i].Transparencia=colorParticula[3];
				}
			}
		}
	}

	public void PonerColorAleatorioEnParticulas()
	{
		this.aleatpart=true;
		if(particDib!=null && particDib[0]!=null)
		{
			GeneradorAleatorioUniforme gau=new GeneradorAleatorioUniforme();
			float transparencia=(float)gau.Genera(0.5,1);
			for(int i=0;i<particDib.Length;i++)
			{
				particDib[i].Red=(float)gau.Genera(0.1,1);
				particDib[i].Green=(float)gau.Genera(0.1,1);
				particDib[i].Blue=(float)gau.Genera(0.1,1);
				particDib[i].Transparencia=transparencia;
			}
		}
	}

    public override Point3d PuntoRotacion
    {
        get 
        {
            return this.cuboDib.PuntoRotacion;
        }
    }

}

