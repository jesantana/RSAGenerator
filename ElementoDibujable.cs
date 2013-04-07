using System;
using Tao.OpenGl;
using Tao.Glut;

public abstract class ElementoDibujable
{
	public int idVisualizar;
	protected float width;
    //private double rx; // angulo de rotacion sobre el eje x
    //private double ry; // angulo de rotacion sobre el eje y
    //private double rz; // angulo de rotacion sobre el eje z

    protected double rotx;
    protected double roty;
    protected double rotz;
    public double rotangle;
	public static float[] matrix=new float[16]{1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1};

	public ElementoDibujable(float width)
	{
		this.width = width;
		idVisualizar = Gl.glGenLists(1);
	}

	
	
	public virtual int Id
	 {
		 get{return idVisualizar;}
	 }

	public virtual string GetObjName(int id)
	{
		int i=idVisualizar;
		return "";
	}
		
		

	public ElementoDibujable() : this(1.0f){}
		
	public virtual void Draw()
	{
		if(idVisualizar != 0)
		{
			Gl.glPushMatrix();
			//Gl.glMultMatrixf(matriz);
			//this.Rota(rotangle,rotx,roty,rotz);
            //this.Rota();
            //this.Rota1(this.PuntoRotacion);
			Gl.glCallList(idVisualizar);
			Gl.glPopMatrix();
		}
	}

    //public virtual void Rota()
    //{
			
    //    Gl.glTranslated(this.PuntoRotacion.X, this.PuntoRotacion.Y, this.PuntoRotacion.Z);
    //    Gl.glRotated(rx, 1, 0, 0);
    //    Gl.glRotated(ry, 0, 1, 0);
    //    Gl.glRotated(rz, 0, 0, 1);
    //    Gl.glTranslated(-this.PuntoRotacion.X, -this.PuntoRotacion.Y, -this.PuntoRotacion.Z);
    //}

	public virtual void Rota(double angle,double x,double y,double z)
	{
		Gl.glTranslated(this.PuntoRotacion.X, this.PuntoRotacion.Y, this.PuntoRotacion.Z);
        Gl.glRotated(rotangle, x, y, z);
        Gl.glTranslated(-this.PuntoRotacion.X, -this.PuntoRotacion.Y, -this.PuntoRotacion.Z);
	}

	public virtual void Rota1(Point3d punto)
	{
		Gl.glTranslated(punto.X, punto.Y,punto.Z);
		Gl.glMultMatrixf(matrix);
		Gl.glTranslated(-punto.X, -punto.Y, -punto.Z);
	}
    //public virtual void Rota(double x,double y,double z)
    //{
    //    Gl.glTranslated(this.PuntoRotacion.X, this.PuntoRotacion.Y, this.PuntoRotacion.Z);
    //    Gl.glRotated(angle, x, y, z);
    //    Gl.glTranslated(-this.PuntoRotacion.X, -this.PuntoRotacion.Y, -this.PuntoRotacion.Z);
    //}
    //public void RotateX(int direction)
    //{
    //    rx += Math.Sign(direction)*5;
    //}


    //public void RotateY(int direction)
    //{
    //    ry += Math.Sign(direction)*5;
    //}


    //public void RotateZ(int direction)
    //{
    //    rz += Math.Sign(direction)*5;
    //}

    public void VariaAnguloDeRotacion(int direction) 
    {
        rotangle =(rotangle+ Math.Sign(direction) * 5)%360;
    }

    public void PonerVectorRotacion(double x,double y,double z) 
    {
        rotx = x;
        roty = y;
        rotz = z;
    }

	public float Width
	{
		get { return width; }
		set
		{
			width = value;
			Recompile();
		}
	}

	public abstract void Recompile();
	public abstract Point3d PuntoRotacion
	{
		get;
	}

	public virtual void Destroy()
	{
		Gl.glDeleteLists(idVisualizar, 1);
	}
}

