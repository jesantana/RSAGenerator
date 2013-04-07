using System;
using Tao.OpenGl;
using Tao.Glut;

public class CuboDibujable:ElementoDibujable
{
	protected RSADibujable owner;
	protected float[] color;
	protected float[] colorBorde;
	protected Point3d start;
	protected Point3d puntoRotacion;

	public CuboDibujable(RSADibujable container,float[] col,float[] colBorde)
	{
		this.color=col;
		this.colorBorde=colBorde;
		this.owner=container;
		start=new Point3d(0,0,0);
		puntoRotacion=new Point3d(0,0,0);
		//this.Recompile();
		
	}

	public virtual float[] Color
	{
		get{return this.color;}
		set
		{
			this.color=value;
			
		}
	}

	public virtual float[] ColorBorde
	{
		get{return this.colorBorde;}
		set
		{
			this.colorBorde=value;
			
		}
	}

	
	public override void Recompile()
	{
		this.UpDate();
		double ancho=owner.Rsa.Cubo.Lado;
		
		Gl.glDeleteLists(idVisualizar,1);
		Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
		Gl.glPushMatrix();

        Gl.glTranslated(start.X + ancho / 2.0, start.Y - ancho / 2.0, start.Z - ancho / 2.0);
		Gl.glScaled(ancho,ancho,ancho);
		Gl.glColor3fv(colorBorde);
		//Gl.glLineWidth(2.0f);
		Glut.glutWireCube(1);
		//Gl.glLineWidth(1.0f);
			
		Gl.glColor4fv(color);
		Glut.glutSolidCube(1);
			
		Gl.glPopMatrix();
		Gl.glEndList();
	}

	public override Point3d PuntoRotacion
	{
		get
		{
			return this.puntoRotacion;
		}
	}
	
	//ver aqui
	public Point3d Inicio
	{
		get{return this.start;}
	}
	
	public double Ancho
	{
		get{return owner.Rsa.Cubo.Lado;}
	}

	protected void UpDate()
	{
		double ancho=owner.Rsa.Cubo.Lado;

		start.X=owner.Rsa.Cubo.PuntoInicial.X-(owner.Rsa.Cubo.Lado/2);
		start.Y=owner.Rsa.Cubo.PuntoInicial.Y+owner.Rsa.Cubo.Lado/2.0;
		start.Z=owner.Rsa.Cubo.PuntoInicial.Z-3*owner.Rsa.Cubo.Lado+owner.Rsa.Cubo.Lado;
		puntoRotacion.X=start.X+ancho/2.0;
		puntoRotacion.Y=start.Y-ancho/2.0;
		puntoRotacion.Z=start.Z-ancho/2.0;
	}
 
}

