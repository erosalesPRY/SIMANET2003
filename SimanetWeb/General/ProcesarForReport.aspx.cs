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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Controladoras.Personal;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.EntidadesNegocio.Personal;
using SIMA.EntidadesNegocio.General;



using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Runtime.InteropServices;


namespace SIMA.SimaNetWeb.General
{
	public class ProcesarForReport : System.Web.UI.Page
	{
		const string PROCESO ="idProceso";
		const int KEYQIDBUSCARPROVEEDOR=1;
		const int KEYQIDBUSCARTRABAJADOR=2;
		const int KEYQIDBUSCARMES=3;

		private int IdProceso
		{
			get{return Convert.ToInt32(Page.Request.Params[PROCESO]); }
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				if (Page.Request.Params[PROCESO]!=null)
				{
					if (this.IdProceso==KEYQIDBUSCARPROVEEDOR)
					{
						Helper.AutoBusquedaResultado((new CProveedor()).ConsultarProveedorXCriterio("RAZONSOCIAL",Helper.CriterioBusqueda()));
					}
					else if (this.IdProceso==KEYQIDBUSCARTRABAJADOR)
					{
						Helper.AutoBusquedaResultado((new CCCTT_Trabajadores()).ListarTrabajadorPorCriterio(Helper.CampoBusqueda(),Helper.CriterioBusqueda()));
					}
					else if (this.IdProceso==KEYQIDBUSCARMES)
					{
						Helper.AutoBusquedaResultado((new CPeriodo()).ListarMesesxPeriodo(Helper.CriterioBusqueda()));
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

