using System;
using Tao.OpenGl;


	public class Camara
	{
		public Camara()
		{
			
		}


		//SetPos(new Point3D(0,0,cz),new Point3D(0,0,-17),0,1,0);
		public void SetPos(Point3d start,Point3d obj,double vecx,double vecy,double vecz)
		{
		
		Gl.glLoadIdentity();
		Glu.gluLookAt(start.X,start.Y,start.Z,obj.X,obj.Y,obj.Z,vecx,vecy,vecz);
				
		}
	}

