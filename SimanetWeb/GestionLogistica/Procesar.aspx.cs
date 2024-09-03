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
using SIMA.Controladoras.GestionLogistica;
using SIMA.Controladoras.Legal;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Runtime.InteropServices;
using SIMA.Controladoras.General;

namespace SIMA.SimaNetWeb.GestionLogistica
{
	public class Procesar : System.Web.UI.Page
	{
		#region Constante
		const string PROCESO ="idProceso";
		const int DATOPROVEEDOR=221;

		const int BUSCAPROVEEDOR=350;
		const string  KEYQIDTIPOENTIDAD="idTipoEntidad";

		const string KEYMNUFIND = "FindMnuOP";

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				if (Page.Request.Params[PROCESO]!=null)
				{
					if(Convert.ToInt32(Page.Request.Params[PROCESO])==DATOPROVEEDOR)
					{
						DataTable dt= (new CResumenOCompraOServicio()).BuscarDatosProveedor(Helper.CriterioBusqueda());
						Helper.AutoBusquedaResultado(dt);
					}
					if(Convert.ToInt32(Page.Request.Params[PROCESO])==BUSCAPROVEEDOR)
					{
						string DESC=((Page.Request.Params[KEYMNUFIND]=="itmMnu0")?"%" + Helper.CriterioBusqueda()+ "%":"X");
						string COD=((Page.Request.Params[KEYMNUFIND]=="itmMnu1")?"%" + Helper.CriterioBusqueda()+ "%":"X");
						Helper.AutoBusquedaResultado((new CEntidades()).ConsultarEntidadesPorTipo(Convert.ToInt32(Page.Request.Params[KEYQIDTIPOENTIDAD]),DESC,COD));
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
