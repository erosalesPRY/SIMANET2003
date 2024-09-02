using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SIMA.SimaNetWeb.General.Diapositivas
{
	public class Parametros : System.Web.UI.Page
	{
		public Parametros()
		{}

		#region Constantes de parametros
			const string KEYQIDFORMATO="IdFormato";
			const string KEYQIDREPORTE = "IdReporte";
			const string KEYQIDRUBRO ="IdRubro";
			const string KEYQPERIODO = "Periodo";
			const string KEYQIDMES = "IdMes";
			const string IDCENTROOPERATIVO="idcop";
			const string KEYQIDTIPOINFO ="idTipoInfo";
			const string KEYQACUMULADO="Acum";
			const string KEYQIDOBJETO="IdObj";
			const string PROCESO ="idProceso";
			const string KEYQLSTCONCEPTO="LstCon";
		#endregion
	
		
		public string ListConceptos
		{
			get{return Page.Request.Params[KEYQLSTCONCEPTO].ToString();}
		}

		public int IdProceso
		{
			get{return Convert.ToInt32(Page.Request.Params[PROCESO]);}
		}

		public int IdFormato
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);}
		}
		public int IdReporte
		{
			get{ return Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);}
		}

		public string IdCentroOperativo
		{
			get{return Page.Request.Params[IDCENTROOPERATIVO].ToString();}
		}

		public int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}

		public int IdTipoInformacion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO]);}
		}
		public int IdMes
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDMES]);}
		}

		public int IdObjeto
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDOBJETO]);}
		}
	}
}
