using System;
using System.Collections;
using System.Xml;
using System.Xml.XPath;
using System.Text;
using System.Windows.Forms;

public class XmlParticulaReader
{
    protected string xmlPath;
    protected XmlDocument reader;

    public XmlParticulaReader(string path)
    {
        xmlPath = path;
        reader = new XmlDocument();
    }

	public string Path
	{
		get
		{
			return xmlPath;
		}
		set
		{
			xmlPath=value;
		}
	}

    public virtual string[] GetNombreParticulas()
    {
        ArrayList result = new ArrayList();
        reader.Load(Application.StartupPath+"\\"+xmlPath);
        XmlNodeList nombreParticulas = reader.SelectNodes("./*/*/nombre");
        foreach (XmlNode node in nombreParticulas)
        {
            result.Add(node.FirstChild.InnerText);
        }
        return (string[])result.ToArray("".GetType());
		
    }

	public virtual ParticulaInfo[] GetParticulas()
	{
		ArrayList result = new ArrayList();
		reader.Load(Application.StartupPath+"\\"+xmlPath);
		XmlNodeList nombreParticulas = reader.SelectNodes("./*/*");
		ParticulaInfo xpartInfo = new ParticulaInfo();
		foreach (XmlNode node in nombreParticulas)
		{
			XmlNode auxNode = node.SelectSingleNode("nombre");
			//Nombre
			xpartInfo.Nombre = auxNode.InnerText;
			auxNode = node.SelectSingleNode("nombreDibujable");
			//Nombre Dibujable
			xpartInfo.NombreDibujable = auxNode.InnerText;
			auxNode = node.SelectSingleNode("path");
			//Path
			xpartInfo.Path = auxNode.InnerText;
            ////Parametros
            //xpartInfo.InfoParametro = new ParametroInfo();
            //auxNode = node.SelectSingleNode("parametros/cantidad"); ;
            ////Cantidad
            //xpartInfo.InfoParametro.Cantidad = int.Parse(auxNode.InnerText);
            //auxNode = null;
			//Ensamblado
			auxNode = node.SelectSingleNode("nEnsamblado");
			xpartInfo.Ensamblado=auxNode.InnerText;
			//Ensamblado
			auxNode = node.SelectSingleNode("nEnsambladoDibujable");
			xpartInfo.EnsambladoDibujable=auxNode.InnerText;
			//path Dibujable
			auxNode = node.SelectSingleNode("pathDibujable");
			xpartInfo.PathDibujable=auxNode.InnerText;
            //Parametro de Particula
            auxNode = node.SelectSingleNode("nombreParametro");
            xpartInfo.ParametroDeParticula = auxNode.InnerText;
            //ANSYS WRITER
            auxNode = node.SelectSingleNode("ansysWriterClase");
            xpartInfo.AnsysWriterName = auxNode.InnerText;
			auxNode=null;
            xpartInfo.InfoParametro = GetInfoParametros(xpartInfo.Nombre);


			result.Add(xpartInfo);
		}
		return (ParticulaInfo[])result.ToArray(xpartInfo.GetType());
		
	}

    public virtual ParticulaInfo GetInfoParticulas(string particula)
    {
        ParticulaInfo xpartInfo = new ParticulaInfo();
        reader.Load(Application.StartupPath+"\\"+xmlPath);
        XmlNode node = reader.SelectSingleNode("./*/particula[nombre='" + particula + "']");


        XmlNode auxNode = node.SelectSingleNode("nombre");
        //Nombre
        xpartInfo.Nombre = auxNode.InnerText;
        auxNode = node.SelectSingleNode("nombreDibujable");
        //Nombre Dibujable
        xpartInfo.NombreDibujable = auxNode.InnerText;
        auxNode = node.SelectSingleNode("path");
        //Path
        xpartInfo.Path = auxNode.InnerText;
        ////Parametros
        //xpartInfo.InfoParametro = new ParametroInfo();
        //auxNode = node.SelectSingleNode("parametros/cantidad"); ;
        ////Cantidad
        //xpartInfo.InfoParametro.Cantidad = int.Parse(auxNode.InnerText);
        //Ensamblado
		auxNode = node.SelectSingleNode("nEnsamblado");
		xpartInfo.Ensamblado=auxNode.InnerText;
		//Ensamblado
		auxNode = node.SelectSingleNode("nEnsambladoDibujable");
		xpartInfo.EnsambladoDibujable=auxNode.InnerText;
		//path Dibujable
		auxNode = node.SelectSingleNode("pathDibujable");
		xpartInfo.PathDibujable=auxNode.InnerText;
        //Parametro de Particula
        auxNode = node.SelectSingleNode("nombreParametro");
        xpartInfo.ParametroDeParticula = auxNode.InnerText;
        //ANSYS WRITER
        auxNode = node.SelectSingleNode("ansysWriterClase");
        xpartInfo.AnsysWriterName = auxNode.InnerText;
        auxNode=null;

        xpartInfo.InfoParametro = GetInfoParametros(particula);
        return xpartInfo;
    }

    public virtual void UpdateInfoParticula(string particula, ParticulaInfo updateInfo)
    {

       
        reader.Load(Application.StartupPath+"\\"+xmlPath);

        XmlNode oldCd;
        oldCd = reader.SelectSingleNode("/particulas/particula[nombre='" + particula + "']");
        if (oldCd != null)
        {
            XmlElement newCd = reader.CreateElement("particula");

            newCd.InnerXml = "<nombre>" + updateInfo.Nombre + "</nombre>" +
            "<nombreDibujable>" + updateInfo.NombreDibujable + "</nombreDibujable>" +
            "<path>" + updateInfo.Path + "</path>" +
            ParametrosXmlCode(updateInfo)+
			"<nEnsamblado>"+updateInfo.Ensamblado+"</nEnsamblado>"+
			"<nEnsambladoDibujable>"+updateInfo.EnsambladoDibujable+"</nEnsambladoDibujable>"+
			"<pathDibujable>"+updateInfo.PathDibujable+"</pathDibujable>"+
            "<nombreParametro>"+updateInfo.ParametroDeParticula+"</nombreParametro>"+
             "<ansysWriterClase>"+updateInfo.AnsysWriterName+"</ansysWriterClase>";


            reader.SelectSingleNode("/particulas").ReplaceChild(newCd, oldCd);

            //save the output to a file
            reader.Save(Application.StartupPath+"\\"+xmlPath);
        }
    }

    protected string ParametrosXmlCode(ParticulaInfo xpart)
    {
        StringBuilder result = new StringBuilder();
        result.Append("<parametros>");
    for (int i = 0; i < xpart.InfoParametro.Cantidad; i++) 
    {
        result .Append( "<datoParametro>" +
                  "<nombre>" + xpart.InfoParametro.ListaDatosDeParametros[i].nombre + "</nombre>" +
                  "<tipo>" + xpart.InfoParametro.ListaDatosDeParametros[i].tipo + "</tipo>"+
                  "</datoParametro>");
    }
    result.Append("</parametros>");
    return result.ToString();
    }

    public virtual void InsertInfoParticula(ParticulaInfo pinfo)
    {
        reader.Load(Application.StartupPath+"\\"+xmlPath);

        XmlElement newCd = reader.CreateElement("particula");

        newCd.InnerXml = "<nombre>" + pinfo.Nombre + "</nombre>" +
        "<nombreDibujable>" + pinfo.NombreDibujable + "</nombreDibujable>" +
        "<path>" + pinfo.Path + "</path>" +
        ParametrosXmlCode(pinfo)+
		"<nEnsamblado>"+pinfo.Ensamblado+"</nEnsamblado>"+
		"<nEnsambladoDibujable>"+pinfo.EnsambladoDibujable+"</nEnsambladoDibujable>"+
        "<pathDibujable>" + pinfo.PathDibujable + "</pathDibujable>" +
            "<nombreParametro>" + pinfo.ParametroDeParticula + "</nombreParametro>"+
             "<ansysWriterClase></ansysWriterClase>";

        XmlNode particulas = reader.SelectSingleNode("/particulas");
        particulas.AppendChild(newCd);
        reader.Save(Application.StartupPath+"\\"+xmlPath);
    }

    public virtual ParametroInfo GetInfoParametros(string particula) 
    {
        reader.Load(Application.StartupPath+"\\"+xmlPath);
        XmlNodeList oldCd;
        oldCd = reader.SelectNodes("/particulas/particula[nombre='" + particula + "']/parametros/*");
        ParametroInfo result = new ParametroInfo(oldCd.Count);
        int i=0;
        foreach (XmlNode nod in oldCd) 
        {
            result.ListaDatosDeParametros[i++] = new DatosDeParametroInfo(nod.SelectSingleNode("nombre").InnerXml, nod.SelectSingleNode("tipo").InnerXml);
            
         }
        return result;
    
    }
}

