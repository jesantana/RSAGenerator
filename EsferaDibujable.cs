using System;
using Tao.OpenGl;
using Tao.Glut;

public class EsferaDibujable:ParticulaDibujable
{
	
	
	public EsferaDibujable(Particula p,float[] col):base(p,col)
	{
			
	}

	public EsferaDibujable(Particula p):base(p)
	{
		
	}
//	public EsferaDibujable():base(new Esfera(new Point3d(0,0,0),new ParametroDeParticula(1),new GestorComparadores()))
//	{}
	public override void DrawGeometry(int[] direccion)
	{
		Esfera esf;
        esf=(Esfera)this.particula;
		Gl.glPushMatrix();
        Gl.glTranslated(start.X+direccion[0]*owner.Rsa.Cubo.Lado,start.Y+direccion[1]*owner.Rsa.Cubo.Lado,start.Z+direccion[2]*owner.Rsa.Cubo.Lado);
        
        Glu.GLUquadric quadric=Glu.gluNewQuadric();
		Glu.gluSphere(quadric,esf.Radio,16,16);
		Glu.gluDeleteQuadric(quadric);
        Gl.glPopMatrix();

	}

	


}

