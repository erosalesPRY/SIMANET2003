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
using SIMA.Controladoras.GestionEstrategica.Inventario;
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.GestionEstrategica;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Runtime.InteropServices;
using System.Net;
using SIMA.Controladoras.Proyectos;


namespace SIMA.SimaNetWeb.GestionEstrategica.Inventario
{
	/// <summary>
	/// Summary description for Proceso.
	/// </summary>
	public class Proceso : System.Web.UI.Page
	{
		const string PROCESO ="idProceso";
		const string KEYQIDAREA ="idArea";
		#region Procesos
			int IDPRCCONSULTALISTADEACTIVOSPORAREA=225;
		#endregion
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				if (Page.Request.Params[PROCESO]!=null)
				{	
					if(Convert.ToInt32(Page.Request.Params[PROCESO])==IDPRCCONSULTALISTADEACTIVOSPORAREA)
					{
						Helper.GenerarEsquemaXMLNTAD((new CActivoFijoyCtaOrden()).ListarAFPorArea(Convert.ToInt32(Page.Request.Params[KEYQIDAREA].ToString())));
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

