using System;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.IO;


	public abstract class ANSYSWriter
    {
        #region Declaracion de variables
        protected RSA rsa;
		protected string path;
		protected string fileName;
		protected int fileCount;
        protected bool datosParametro;
        
        //protected Particula[] particulas;
        #endregion

        public ANSYSWriter(RSA rsaTarget)
        {
            rsa = rsaTarget;
			if(!Directory.Exists(Application.StartupPath+"\\ANSYSOut"))
				Directory.CreateDirectory(Application.StartupPath+"\\ANSYSOut");
			path=Application.StartupPath+"\\ANSYSOut";
			fileName="batch.txt";
			datosParametro=true;
        }

		public virtual string Ruta
		{
			get
			{
				return path;
			}
			set
			{
				path=value;
			}
		}

		public virtual bool AgregarDatosDeParametro
		{
			get
			{
				return datosParametro;
			}
			set
			{
				datosParametro=value;
			}
		}

		public virtual string NombreArchivo
		{
			get
			{
				return fileName;
			}
			set
			{
				fileName=value;
			}
		}

        public virtual string NombreCompleto
        {
            get
            {
                string aux = fileName;
                if (datosParametro)
                {
                    aux = aux.Replace(".", "Fracc" + rsa.FraccionVolumetrica.ToString().Replace(".", "") + "CantPart" + rsa.CantidadDeParticulas.ToString() + ".");
                }

                //if (!overwrite)
                //{
                //    aux = aux.Replace(".", "Num" + this.GetUltimoNumero().ToString() + ".");
                //}
                return aux;
            }
        }

        protected bool EsNumerico(string cad) 
        {
            if (cad.Length == 0) return false;
            for (int i = 0; i < cad.Length; i++) 
            {
                if (!char.IsNumber(cad[i])) return false;
            }
            return true;
        }

        protected virtual int GetUltimoNumero()
		{
			int max=-1;
			DirectoryInfo di=new DirectoryInfo(path);
			FileInfo[] fi=di.GetFiles();
            string complName = NombreCompleto;
            string filewoext=complName.Remove(complName.LastIndexOf("."),complName.Length-complName.LastIndexOf("."));
			foreach(FileInfo fileInf in fi)
			{
				if(fileInf.Name.StartsWith(filewoext))
				{
					string auxcad=fileInf.Name.Remove(0,filewoext.Length);
					auxcad=auxcad.Remove(auxcad.LastIndexOf("."),auxcad.Length-auxcad.LastIndexOf("."));
                    //auxcad = auxcad.Remove(auxcad.Length - 3);
                    if (EsNumerico(auxcad))
                    {
                        int x = int.Parse(auxcad);
                        if (x > max)
                        {
                            max = x;
                        }
                    }
				}
			}
			return ++max;
		}

        public abstract void CreateANSYSBatch(bool inTheBox,bool overwrite);
          
	}

