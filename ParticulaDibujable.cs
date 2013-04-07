using System;
using Tao.OpenGl;
using Tao.Glut;
using System.Collections;

public abstract class ParticulaDibujable:ElementoDibujable
{
	protected static RSADibujable owner;
	protected float[] color;
	protected Particula particula;
	protected Point3d start;
    
	public ParticulaDibujable(Particula p,float[] col)
	{
		this.particula=p;
		color=col;
		start=new Point3d(0,0,0);
	}

	public ParticulaDibujable(Particula p)
	{
		this.particula=p;
		start=new Point3d(0,0,0);
		color=new float[4];
		GeneradorAleatorioUniforme gau=new GeneradorAleatorioUniforme();
		color[0]=(float)gau.Genera(0.1,1);
		color[1]=(float)gau.Genera(0.1,1);
		color[2]=(float)gau.Genera(0.1,1);
		color[3]=(float)gau.Genera(0.5,1);
		
	}

	public static void SetOwner(RSADibujable rsadib)
	{
		owner=rsadib;
	}

	public float[] Color
	{
		get
		{
			return this.color;
		}
		
		set
		{
			this.color=value;
			
		}
	}

	public float Red
	{
		get{return this.color[0];}
		set{color[0]=value;}
	}

	public float Green
	{
		get{return this.color[1];}
		set{color[1]=value;}
	}

	public float Blue
	{
		get{return this.color[2];}
		set{color[2]=value;}
	}

	public float Transparencia
	{
		
		get
		{
			if(this.color.Length<4)throw new Exception("No existe transparencia");
			return this.color[3];
		}
		set
		{
			if(this.color.Length<4)throw new Exception("No existe transparencia");
			color[3]=value;
		}
	}

	public override void Recompile()
	{
		UpDate();			
		Gl.glDeleteLists(idVisualizar,1);
		Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
		Gl.glPushMatrix();
		Gl.glDisable(Gl.GL_CULL_FACE);
		Gl.glColor4fv(color);
		if(owner.SpheresInBox)
		{
			ArrayList direcciones=owner.Rsa.DireccionesAComprobarPeriod(particula);            
            direcciones.Add(new int[] { 0, 0, 0 });
            foreach(int[] direccion in direcciones)
			{
				DrawGeometry(direccion);             
			}
		}
		else
		{
			DrawGeometry();
		}
		
		Gl.glEnable(Gl.GL_CULL_FACE);
		Gl.glPopMatrix();
		Gl.glEndList();
	}

	protected virtual void UpDate()
	{
		start.X=particula.Posicion.X-(owner.Rsa.Cubo.Lado/2);
		start.Y=particula.Posicion.Y-(owner.Rsa.Cubo.Lado/2);
		start.Z=particula.Posicion.Z-3*(owner.Rsa.Cubo.Lado);	
	}

	public abstract void DrawGeometry(int[] direccion);
	public void DrawGeometry()
	{
		DrawGeometry(new int[]{0,0,0});
	}

	public override Point3d PuntoRotacion
	{
		get
		{
			return start;
		}
	}
}

