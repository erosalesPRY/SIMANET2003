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
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.Utilitario;
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.GestionIntegrada;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Configuration;


namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for Procesar.
	/// </summary>
	public class Procesar : System.Web.UI.Page
	{
		const string PROCESO ="idProceso";
		const int KEYPRCELIMINAANEXO =224;
		const string KEYQPERIODO = "Periodo";
		const string KEYQIDANEXO= "IdAnexo";

		int Periodo
		{
			get{return  Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}

		int IdAnexo
		{
			get{return  Convert.ToInt32(Page.Request.Params[KEYQIDANEXO]);}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				if (Page.Request.Params[PROCESO]!=null)
				{	
					if(Convert.ToInt32(Page.Request.Params[PROCESO])== KEYPRCELIMINAANEXO)
					{
						Helper.GenerarEsquemaXMLTAD((new CAnexoAccionRecomendacion()).Eliminar(this.IdAnexo,this.Periodo));
					}
				}
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
