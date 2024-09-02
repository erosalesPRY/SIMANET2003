using System;
using System.Data;
using System.Reflection;
using System.Web;
using System.Web.UI;
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Utilitario;


namespace SIMA.SimaNetWeb.General
{
	/// <summary>
	/// Summary description for InvocaControladora.
	/// </summary>
	public class InvocaControladora
	{
		public InvocaControladora()
		{
		}
		public object[] GetParametrosInMetodo(){
			object []Params;
			DataTable dt = (new CPresentacionAssemblyParams()).Listar(Utilitario.Helper.GestionFinanciera.Params.IdObjeto);
			if((dt!=null)&&(dt.Rows.Count>0)){
				DataView dv = dt.DefaultView;
				dv.RowFilter="UseAssembly=1";
				dv.Sort="OrdenInMetodoAssembly asc";
				if(dv.Count>0){
					DataTable dtf = Utilitario.Helper.DataViewTODataTable(dv);
					Params = new object[dv.Count];
					int Position=0;
					foreach(DataRow dr in dtf.Rows)
					{
						string Valor = ((dr["Valor"].ToString().Equals("?"))? ((System.Web.UI.Page)HttpContext.Current.Handler).Request.Params[dr["Nombre"].ToString()].ToString():dr["Valor"].ToString());
						switch(Convert.ToInt32(dr["IdTipoDato"].ToString()))
						{
							case 1:
								Params[Position] = Convert.ToInt32(Valor);
								break;
							case 2:
								Params[Position] = Convert.ToString(Valor);
								break;
						}
						Position++;	
					}
					return Params;
				}
			}
			return null;
		}
		public string GetParametrosInURL(int IdObjeto)
		{
			string ParamURL="";
			DataTable dt = (new CPresentacionAssemblyParams()).Listar(IdObjeto);
			if((dt!=null)&&(dt.Rows.Count>0))
			{
				DataView dv = dt.DefaultView;
				dv.RowFilter="Valor<>'?'";
				//dv.Sort="OrdenInMetodoAssembly asc";
				if(dv.Count>0)
				{
					DataTable dtf = Utilitario.Helper.DataViewTODataTable(dv);
					foreach(DataRow dr in dtf.Rows)
					{
						ParamURL += dr["Nombre"].ToString() +"=" + dr["Valor"].ToString() + "&";
					}
					return ParamURL;
				}
			}
			return null;
		}
		
		public DataTable CallSourceDataToReportFromAssembly(string Pathdll)
		{
			object []Parametros = this.GetParametrosInMetodo();
			return CallSourceDataToReportFromAssembly(Pathdll,Parametros);

		}
		public DataTable CallSourceDataToReportFromAssembly(string Pathdll, object[] parametersArray)
		{
			
			DataSet dsGeneric= new DataSet("sw");
			string PathAssemblyControler= Pathdll;
			Assembly assembly = Assembly.LoadFile(PathAssemblyControler);
			DataTable dtAssembly =(new CPresentacionAssembly()).Listar(Utilitario.Helper.GestionFinanciera.Params.IdObjeto);
			if(dtAssembly!=null)
			{
				foreach(DataRow drAss in dtAssembly.Rows)
				{
					string strNameSpace=drAss["Namespace"].ToString();
					Type type = assembly.GetType(strNameSpace);
					if (type != null)
					{
						MethodInfo methodInfo = type.GetMethod(drAss["Metodo"].ToString());
						if (methodInfo != null)
						{
							DataTable dt1=null;
							ParameterInfo[] parameters = methodInfo.GetParameters();
							object classInstance = Activator.CreateInstance(type, null);
							if (parameters.Length == 0)
							{
								dt1=(DataTable)methodInfo.Invoke(classInstance, null);
							}
							else
							{
								dt1=(DataTable) methodInfo.Invoke(classInstance, parametersArray);
							}
							if((dt1!=null)&&(dt1.Rows.Count>0))
							{
								DataView dvASC =dt1.DefaultView;
								if(drAss["Sort"].ToString().Length>0)
								{
									dvASC.Sort=drAss["Sort"].ToString();
								}
								DataTable dtx =  Helper.DataViewTODataTable(dvASC);
								dt1.TableName=drAss["SPOrigenDatos"].ToString();
								dsGeneric.Tables.Add(dtx);
							}

						}
					}
				}
			}
			if(dsGeneric.Tables.Count==0){return null;}
			return dsGeneric.Tables[0];
		}





	}
}
