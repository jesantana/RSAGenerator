using System;
using Tao.Glut;
using Tao.OpenGl;

namespace WindowsApplication1
{
	

	public class ColorDibujable:ElementoDibujable
	{
		protected float[] color;
		protected Point3d start;

		public ColorDibujable(Point3d st,float[] col)
		{
			start=st;
			color=col;
			this.Recompile();
		}

		public override void Recompile()
		{
			Gl.glDeleteLists(idVisualizar,1);
			Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
			Gl.glPushMatrix();
			Gl.glTranslated(start.X,start.Y,start.Z);
			Gl.glColor4fv(color);
			Glut.glutSolidTeapot(2.5);
			Gl.glPopMatrix();
			Gl.glEndList();
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

		public override Point3d PuntoRotacion
		{
			get
			{
				return this.start;
			}
		}

	}
}
