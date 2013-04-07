using System;
using System.IO;
using System.Text;
using System.Collections;

	public class ANSYSWriterEsfera : ANSYSWriter
    {
        StreamWriter sw;
        ArrayList direcciones;
        #region Constructores
        public ANSYSWriterEsfera(RSA rsaTarget) : base(rsaTarget)
        {          

        }
        #endregion

        #region Metodos Publicos
        public override void CreateANSYSBatch(bool inTheBox,bool overwrite)
        {
            string auxFileName = NombreCompleto;

            if (!overwrite)
            {
                auxFileName = auxFileName.Replace(".",this.GetUltimoNumero().ToString() + ".");
            }
			
			if (!inTheBox)
            {
				
				using (sw = File.CreateText(this.path+"//"+auxFileName))
                {
                    sw.WriteLine("/batch");
                    sw.WriteLine("/filename, "+auxFileName);

                    sw.WriteLine("/prep7");

                    //variables con los valores de las constantes
                    sw.WriteLine("epMat_Young = 3000");
                    sw.WriteLine("epMat_Poisson = 0.38");
                    sw.WriteLine("GlSph_Young = 70000");
                    sw.WriteLine("GlSph_Poisson = 0.20");

                    //definir los materiales a utilizar
                    sw.WriteLine("ET, 1, SOLID92");
                    sw.WriteLine("MPTEMP,,,,,,,,");
                    sw.WriteLine("MPTEMP, 1, 0");
                    sw.WriteLine("MPDATA, EX, 1, , epMat_Young");
                    sw.WriteLine("MPDATA, PRXY, 1, , epMat_Poisson");
                    sw.WriteLine("MPTEMP,,,,,,,,");
                    sw.WriteLine("MPTEMP, 1, 0");
                    sw.WriteLine("MPDATA, EX, 2, , GlSph_Young");
                    sw.WriteLine("MPDATA, PRXY, 2, , GlSph_Poisson");

                    sw.WriteLine("BLC4, {0}, {1}, {2}, {2}, {2}", rsa.Cubo.PuntoInicial.X, rsa.Cubo.PuntoInicial.Y, rsa.Cubo.Lado);


                    for (int i = 0; i < rsa.particulas.Length; i++)
                    {
                        sw.WriteLine("WPOFFS, {0}, {1}, {2}", rsa.particulas[i].Posicion.X, rsa.particulas[i].Posicion.Y, rsa.particulas[i].Posicion.Z);
                        sw.WriteLine("SPH4, 0, 0, {0}", ((Esfera)rsa.particulas[i]).Radio);
                        sw.WriteLine("WPCSYS,-1,0");
                        sw.WriteLine("!Modelado de la esfera numero {0}", i + 1);
                    }

                    //mallado
                    //sw.WriteLine("AESIZE,1,10,");
                    sw.WriteLine("MSHKEY,0");
                    sw.WriteLine("SMRT,2");
                    sw.WriteLine("mat, 1");
                    sw.WriteLine("VMESH, 1");
                    sw.WriteLine("mat, 2");
                    sw.WriteLine("VMESH, 2, {0}", rsa.particulas.Length + 1);

                    sw.WriteLine("WPCSYS,-1,0");
                    sw.WriteLine("/eof");
                    sw.Close();

                }
            }
            else 
            {
                using (sw = File.CreateText(this.path+"//"+auxFileName))
                {
                    sw.WriteLine("/batch");
                    sw.WriteLine("/filename, "+auxFileName);

                    sw.WriteLine("/prep7");

                    //variables con los valores de las constantes
                    sw.WriteLine("epMat_Young = 3000");
                    sw.WriteLine("epMat_Poisson = 0.38");
                    sw.WriteLine("GlSph_Young = 70000");
                    sw.WriteLine("GlSph_Poisson = 0.20");

                    //definir los materiales a utilizar
                    sw.WriteLine("ET, 1, SOLID92");
                    sw.WriteLine("MPTEMP,,,,,,,,");
                    sw.WriteLine("MPTEMP, 1, 0");
                    sw.WriteLine("MPDATA, EX, 1, , epMat_Young");
                    sw.WriteLine("MPDATA, PRXY, 1, , epMat_Poisson");
                    sw.WriteLine("MPTEMP,,,,,,,,");
                    sw.WriteLine("MPTEMP, 1, 0");
                    sw.WriteLine("MPDATA, EX, 2, , GlSph_Young");
                    sw.WriteLine("MPDATA, PRXY, 2, , GlSph_Poisson");

                    sw.WriteLine("BLC4, {0}, {1}, {2}, {2}, {2}", rsa.Cubo.PuntoInicial.X, rsa.Cubo.PuntoInicial.Y, rsa.Cubo.Lado);
                    //sw.WriteLine("WPOFFS, {0}, {1}, {2}", particulas[0].Posicion.X, particulas[0].Posicion.Y, particulas[0].Posicion.Z);
                    //sw.WriteLine("SPH4, 0, 0, {0}", ((Esfera)particulas[0]).Radio);

                    for (int i = 0; i < rsa.particulas.Length; i++)
                    {
                        sw.WriteLine("WPOFFS, {0}, {1}, {2}", rsa.particulas[i].Posicion.X, rsa.particulas[i].Posicion.Y, rsa.particulas[i].Posicion.Z);
                        sw.WriteLine("SPH4, 0 , 0 , {0}", ((Esfera)rsa.particulas[0]).Radio);
                        direcciones = rsa.DireccionesAComprobarPeriod(rsa.particulas[i]);
                        foreach (int[] direccion in direcciones)
                        {
                            sw.WriteLine("!Nuevo corrimiento");
                            sw.WriteLine("WPOFFS, {0}, {1}, {2}", direccion[0] * rsa.Cubo.Lado, direccion[1] * rsa.Cubo.Lado, direccion[2] * rsa.Cubo.Lado);
                            sw.WriteLine("SPH4, 0 , 0 , {0}", ((Esfera)rsa.particulas[0]).Radio);

                            sw.WriteLine("WPCSYS,-1,0");
                            sw.WriteLine("WPOFFS, {0}, {1}, {2}", rsa.particulas[i].Posicion.X, rsa.particulas[i].Posicion.Y, rsa.particulas[i].Posicion.Z);
                        }
                        sw.WriteLine("WPCSYS,-1,0");
                        sw.WriteLine("!Modelado de la esfera numero {0}", i + 1);
                    }

                    //mallado
                    //sw.WriteLine("AESIZE,1,10,");
                    //sw.WriteLine("MSHKEY,0");
                    //sw.WriteLine("SMRT,2");
                    //sw.WriteLine("mat, 1");
                    //sw.WriteLine("VMESH, 1");
                    //sw.WriteLine("mat, 2");
                    //sw.WriteLine("VMESH, 2, {0}", particulas.Length + 1);

                    sw.WriteLine("VINP, ALL");
                    sw.WriteLine("WPCSYS,-1,0");
                    sw.WriteLine("BLC4, {0}, {1}, {2}, {2}, {2}", rsa.Cubo.PuntoInicial.X, rsa.Cubo.PuntoInicial.Y, rsa.Cubo.Lado);
					sw.WriteLine("VSEL,ALL");
					sw.WriteLine("VOVLAP,ALL");
					//mallado
					sw.WriteLine("MSHKEY, 0");
					sw.WriteLine("MSHAPE, 1, 3D");
					sw.WriteLine("SMRT, 6");
					sw.WriteLine("VMESH, ALL");
					sw.Close();

                }                
            }
        }
        #endregion

    }

