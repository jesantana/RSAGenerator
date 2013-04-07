using System;
using System.Reflection;

public class GestorAlgoritmo
{
	public GestorAlgoritmo()
	{
			
	}

	public virtual RSA CreaRSA(RSAConfiguration config,ParticulaInfo pInfo,ITracker track)
	{
		Assembly partAssembly = GestorEnsamblados.GetAssemblyByName((string)config.Valores["rsaClase"],/*config.Valores["rsaEnsamblado"]*/ "TES1.dll");
				
		RSA result=null;
		try
		{
			if((((string)config.Valores["parametroVariable"])=="cantidadParticulas"))
			{
				result=(RSA)partAssembly.CreateInstance((string)config.Valores["rsaClase"],true,BindingFlags.CreateInstance,null,new object[]{(double)config.Valores["ladoCubo"], (double)config.Valores["fraccionVolumetrica"],(int)config.Valores["cantidadParticulas"], pInfo,track},null,null);
			}
			else
			{
				if(((object[])config.Valores["parametros"]).Length!=pInfo.InfoParametro.Cantidad)throw new Exception("Error");
				object[] auxArray=(object[])config.Valores["parametros"];
				result=(RSA)partAssembly.CreateInstance((string)config.Valores["rsaClase"],true,BindingFlags.CreateInstance,null,new object[]{(double)config.Valores["ladoCubo"], (double)config.Valores["fraccionVolumetrica"],auxArray, pInfo,track},null,null);
			}
		}
		catch(Exception e){throw new Exception("Error al crear particula en Gestor de Creacion");}
		if(result==null)throw new Exception("Error al crear particula en Gestor de Creacion");
		return result;
	}
}

