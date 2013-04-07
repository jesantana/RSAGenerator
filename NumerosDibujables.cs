using System;
using Tao.OpenGl;
using Tao.Glut;


public class NumerosDibujables:ElementoDibujable
{
	int numero;
	double[] color;
	Particula owner;
	Point3d inicio;
	protected static RSADibujable rsa;

	public NumerosDibujables(Particula container,int number,double[] col)
	{
		owner=container;
		color=col;
		numero=number;
		inicio=new Point3d(0,0,0);
		//this.Recompile();
	}

	public static void SetOwner(RSADibujable rsadib)
	{
		rsa=rsadib;
	}


	public static void DrawNumber(double x,double y,double z,int number)
	{
		Gl.glPushMatrix();
		byte[][] raster=new byte[10][];
		raster[0]=new byte[]{0x00, 0x00, 0x3c, 0x66, 0xc3, 0xe3, 0xf3, 0xdb, 0xcf, 0xc7, 0xc3, 0x66, 0x3c};
		raster[1]=new byte[]{0x00, 0x00, 0x7e, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x78, 0x38, 0x18};
		raster[2]=new byte[]{0x00, 0x00, 0xff, 0xc0, 0xc0, 0x60, 0x30, 0x18, 0x0c, 0x06, 0x03, 0xe7, 0x7e};
		raster[3]=new byte[]{0x00, 0x00, 0x7e, 0xe7, 0x03, 0x03, 0x07, 0x7e, 0x07, 0x03, 0x03, 0xe7, 0x7e};
		raster[4]=new byte[]{0x00, 0x00, 0x0c, 0x0c, 0x0c, 0x0c, 0x0c, 0xff, 0xcc, 0x6c, 0x3c, 0x1c, 0x0c};
		raster[5]=new byte[]{0x00, 0x00, 0x7e, 0xe7, 0x03, 0x03, 0x07, 0xfe, 0xc0, 0xc0, 0xc0, 0xc0, 0xff};
		raster[6]=new byte[]{0x00, 0x00, 0x7e, 0xe7, 0xc3, 0xc3, 0xc7, 0xfe, 0xc0, 0xc0, 0xc0, 0xe7, 0x7e};
		raster[7]=new byte[]{0x00, 0x00, 0x30, 0x30, 0x30, 0x30, 0x18, 0x0c, 0x06, 0x03, 0x03, 0x03, 0xff};
		raster[8]=new byte[]{0x00, 0x00, 0x7e, 0xe7, 0xc3, 0xc3, 0xe7, 0x7e, 0xe7, 0xc3, 0xc3, 0xe7, 0x7e};
		raster[9]=new byte[]{0x00, 0x00, 0x7e, 0xe7, 0x03, 0x03, 0x03, 0x7f, 0xe7, 0xc3, 0xc3, 0xe7, 0x7e};
			
		string strAux=number.ToString();	
		Gl.glRasterPos3d(x,y,z);
		for(int i=0;i<strAux.Length;i++)
		{
			Gl.glBitmap(8, 13, 0.0f, 2.0f, 10.0f, 0.0f,raster[int.Parse(strAux[i].ToString())]);
			Gl.glFlush();
		}
		Gl.glPopMatrix();
	}

	public override Point3d PuntoRotacion
	{
		get
		{
			return inicio;
		}
	}

	public override void Recompile()
	{
		Gl.glDeleteLists(idVisualizar,1);
		Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
		Gl.glPushMatrix();
		Gl.glColor3dv(color);
		
		inicio.X=owner.Posicion.X-rsa.Rsa.Cubo.Lado/2;
		inicio.Y=owner.Posicion.Y-rsa.Rsa.Cubo.Lado/2;
		inicio.Z=owner.Posicion.Z-3*rsa.Rsa.Cubo.Lado;
		
		DrawNumber(inicio.X,inicio.Y,inicio.Z,numero);
		Gl.glPopMatrix();
		Gl.glEndList();
	}
}

