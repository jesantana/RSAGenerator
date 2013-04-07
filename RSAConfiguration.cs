using System;
using System.Xml;
using System.Collections;
using System.Windows.Forms;
using System.Text;

public class RSAConfiguration
{
	protected XmlDocument reader;
	protected Hashtable config;

	public RSAConfiguration()
	{
		reader=new XmlDocument();
        config=new Hashtable();
		this.CargaValores();
	}

	protected void CargaValores()
	{
		float[] color=new float[4];
		XmlDocument partReader=new XmlDocument();
		reader.Load(Application.StartupPath+"\\RsaConfig.xml");
		XmlNode node = reader.SelectSingleNode("./Descriptor");
		//particulaXml
		node=node.FirstChild;
		config["particulaXml"]=node.InnerText;
		//particulaInicial
		node=node.NextSibling;
		config["particulaInicial"]=node.InnerText;
		//ladoCubo
		node=node.NextSibling;
		config["ladoCubo"]=ParseDouble(node.InnerText);
		//fraccionVolumetrica
		node=node.NextSibling;
		config["fraccionVolumetrica"]=ParseDouble(node.InnerText);
		//parametroVariable
		node=node.NextSibling;
		config["parametroVariable"]=node.InnerText;
		XmlParticulaReader part=new XmlParticulaReader((string)config["particulaXml"]);
		ParametroInfo pinfo=part.GetInfoParametros((string)config["particulaInicial"]);
		if(node.InnerText=="cantidadParticulas")
		{
			node=node.NextSibling;
			config["cantidadParticulas"]=int.Parse(node.InnerText);
			node=node.NextSibling;
			XmlNodeList xmlnod=node.SelectNodes("parametro");
			int count=xmlnod.Count;
			object[] aux=new object[count];
			for(int i=0;i<count;i++)
			{
				aux[i]=0;
			}
			config["parametros"]=aux;
		}
		else
		{
			node=node.NextSibling;
			config["cantidadParticulas"]=0;
			node=node.NextSibling;
			XmlNodeList xmlnod=node.SelectNodes("parametro");
			int count=0;
			object[] aux=new object[xmlnod.Count];
			foreach(XmlNode nod in xmlnod)
			{
				aux[count]=Parse(nod.InnerText,pinfo.ListaDatosDeParametros[count].tipo);	
				count++;
			}
			config["parametros"]=aux;
		}
		//spheresInBox
		node=node.NextSibling;
		config["spheresInBox"]=bool.Parse(node.InnerText);;
		//colorCubo
		node=node.NextSibling;
		color[0]=ParseFloat(node.SelectSingleNode("rojo").InnerText);
		color[1]=ParseFloat(node.SelectSingleNode("verde").InnerText);
		color[2]=ParseFloat(node.SelectSingleNode("azul").InnerText);
		color[3]=ParseFloat(node.SelectSingleNode("transparencia").InnerText);
		config["colorCubo"]=color;
		//colorParticulaAleatorio
		node=node.NextSibling;
		config["colorParticulaAleatorio"]=bool.Parse(node.InnerText);;
		color=new float[4];
		node=node.NextSibling;
		color[0]=ParseFloat(node.SelectSingleNode("rojo").InnerText);
		color[1]=ParseFloat(node.SelectSingleNode("verde").InnerText);
		color[2]=ParseFloat(node.SelectSingleNode("azul").InnerText);
		color[3]=ParseFloat(node.SelectSingleNode("transparencia").InnerText);
		config["colorParticulas"]=color;
		//mostrarNumeros
		node=node.NextSibling;
		config["mostrarNumeros"]=bool.Parse(node.InnerText);
		//rsaClase
		node=node.NextSibling;
		config["rsaClase"]=node.InnerText;
	}

    protected static double ParseDouble(string cad) 
    { 
		string[] result = cad.Split(new char[]{',','.'});
		
		if(result.Length==1)
		{
			return  double.Parse(result[0]);
		}
		else if(result.Length!=2 && result[0]!="0")
		{
			throw new Exception("Error al parsear un double");
		}
        return double.Parse(result[0])+double.Parse(result[1])*Math.Pow(10,-1*result[1].Length);
    }

    protected static float ParseFloat(string cad)
    {
		string[] result = cad.Split(new char[]{',','.'});
		if(result.Length==1)
		{
			return  float.Parse(result[0]);
		}
		else if(result.Length!=2 && result[0]!="0")
		{
			throw new Exception("Error al parsear un float");
		}
		return float.Parse(result[0])+float.Parse(result[1])*(float)Math.Pow(10,-1*result[1].Length);
    }

	public static object Parse(string cad,string tipo)
	{
		if(tipo=="float")return ParseFloat(cad);
		else if(tipo=="double") return ParseDouble(cad);
		else if(tipo=="int") return int.Parse(cad);
		else if(tipo=="string") return cad;
		else
		{
			throw new Exception("error");
		}
	}

    public void GuardaValores()
    {
        reader.Load(Application.StartupPath+"\\RsaConfig.xml");

        XmlElement newCd = reader.CreateElement("Descriptor");
        string aux = "<particulaXml>" + config["particulaXml"].ToString() + "</particulaXml>" +
                        "<particulaInicial>" + config["particulaInicial"].ToString() + "</particulaInicial>" +
                        "<ladoCubo>" + config["ladoCubo"].ToString() + "</ladoCubo>" +
                        "<fraccionVolumetrica>" + config["fraccionVolumetrica"].ToString() + "</fraccionVolumetrica>" +
                        "<parametroVariable>" + config["parametroVariable"].ToString() + "</parametroVariable>" +
						DecideParametro() +
                        "<spheresInBox>" + config["spheresInBox"].ToString() + "</spheresInBox>" +
                        "<colorCubo>" +
                            "<rojo>" + ((float[])config["colorCubo"])[0].ToString() + "</rojo>" +
                            "<verde>" + ((float[])config["colorCubo"])[1].ToString() + "</verde>" +
                            "<azul>" + ((float[])config["colorCubo"])[2].ToString() + "</azul>" +
                            "<transparencia>" + ((float[])config["colorCubo"])[3].ToString() + "</transparencia>" +
                        "</colorCubo>" +
                        "<colorParticulaAleatorio>" + config["colorParticulaAleatorio"].ToString() + "</colorParticulaAleatorio>" +
                        "<colorParticulas>" +
                            "<rojo>" + ((float[])config["colorParticulas"])[0].ToString() + "</rojo>" +
                            "<verde>" + ((float[])config["colorParticulas"])[1].ToString() + "</verde>" +
                            "<azul>" + ((float[])config["colorParticulas"])[2].ToString() + "</azul>" +
                            "<transparencia>" + ((float[])config["colorParticulas"])[3].ToString() + "</transparencia>" +
                        "</colorParticulas>" +
                        "<mostrarNumeros>" + config["mostrarNumeros"].ToString() + "</mostrarNumeros>" +
                        "<rsaClase>" + config["rsaClase"].ToString() + "</rsaClase>";

        newCd.InnerXml = aux;

        reader.RemoveAll();
        reader.AppendChild(newCd);
        reader.Save(Application.StartupPath+"\\RsaConfig.xml");
    }

    protected string DecideParametro()
    {
        if ((string)config["parametroVariable"] == "cantidadParticulas")
        {
			StringBuilder aux=new StringBuilder();
			int len=((object[])config["parametros"]).Length;
			for(int i=0;i<len;i++)
			{
				aux.Append("<parametro>0</parametro>");
			}

			return  "<cantidadParticulas>" + config["cantidadParticulas"] + "</cantidadParticulas>"+
			"<parametros>"+
				aux.ToString()+
			"</parametros>";
        }
        else if((string)config["parametroVariable"] == "parametros")
        {
            StringBuilder aux=new StringBuilder();
			object[] objarray=(object[])config["parametros"];
			foreach(object obj in objarray)
			{
				aux.Append("<parametro>"+obj.ToString()+"</parametro>");
			}
			return "<cantidadParticulas>0</cantidadParticulas>"+
				"<parametros>"+
					aux.ToString()+
				"</parametros>";
        }
		else throw new Exception("Error ");

    }

	public IDictionary Valores
	{
		get
		{
			return this.config;
		}
		
	}
}

