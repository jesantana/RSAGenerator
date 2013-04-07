using System;
using System.Collections;
using System.Reflection;

public class GestorDibujables
{
    //protected Hashtable nombreDibujables;
    protected Assembly assem;
	protected XmlParticulaReader pinfo;
	protected ParticulaInfo tempInfo;
	

    public GestorDibujables(XmlParticulaReader infoParticle) 
    {
        pinfo=infoParticle;
		
				
		//nombreDibujables = new Hashtable();
	
    }

	public XmlParticulaReader Xml
	{
		get
		{
			return pinfo;
		}
		set
		{
			pinfo=value;
		}
	}

    public virtual ParticulaDibujable[] GeneraDibujables(Particula[] particula,float[] color,bool aleat) 
    {
        ArrayList result=new ArrayList();
        for (int i = 0; i < particula.Length; i++) 
        {
			if(particula[i]==null)return (ParticulaDibujable[])result.ToArray(Type.GetType("ParticulaDibujable")); 
            try
            {
				if(tempInfo==null || tempInfo.Nombre!=particula[i].GetType().Name)
				{
					tempInfo=pinfo.GetInfoParticulas(particula[i].GetType().Name);
				}
				
            }
            catch (Exception ex) { throw new Exception("Error al Generar Particulas Dibujables"); }
            assem=GestorEnsamblados.GetAssemblyByName(tempInfo.EnsambladoDibujable,tempInfo.PathDibujable);
			if(aleat)
			{
				result.Add((ParticulaDibujable)assem.CreateInstance(tempInfo.NombreDibujable, true, BindingFlags.CreateInstance, null, new object[] {particula[i]}, null, null));
			}
			else
			{
				result.Add((ParticulaDibujable)assem.CreateInstance(tempInfo.NombreDibujable, true, BindingFlags.CreateInstance, null, new object[] {particula[i], color}, null, null));
			}
						
        }
        return (ParticulaDibujable[])result.ToArray(Type.GetType("ParticulaDibujable")); 
    }

    public virtual ANSYSWriter GeneraAnsysWriter(string particulaName,RSA owner) 
    {
        ANSYSWriter ansysReturn = null;
        tempInfo = pinfo.GetInfoParticulas(particulaName);
        assem = GestorEnsamblados.GetAssemblyByName(tempInfo.EnsambladoDibujable, tempInfo.PathDibujable);
        ansysReturn=(ANSYSWriter)assem.CreateInstance(tempInfo.AnsysWriterName, true, BindingFlags.CreateInstance, null, new object[] {owner}, null, null);
        return ansysReturn;
    }

   
}

