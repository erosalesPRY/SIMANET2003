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
using SIMA.Controladoras.GestionComercial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for AdministrarVentasRealesExcel.
	/// </summary>
	public class AdministrarVentasRealesExcel : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnAbrir;
		protected System.Web.UI.WebControls.DataGrid gridReporte;
		protected System.Web.UI.WebControls.Label lblResultado;
		#endregion

		#region Constantes
		//Key Session y QueryString
		const string GRILLAVACIA = "No existe Dato para ser Mostrado.";
		#endregion Constantes
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.ConfigurarAccesoControles();
				this.LlenarGrilla();
			}
			catch(SIMAExcepcionLog oSIMAExcepcionLog)
			{
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
			}
			catch(SIMAExcepcionIU oSIMAExcepcionIU)
			{
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
			}
			catch(SIMAExcepcion oSIMAExcepcion)
			{
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcion.Mensaje);					
			}
			catch(Exception oException)
			{
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
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
			this.ibtnAbrir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAbrir_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CVentasReales oCVentasReales = new CVentasReales();
			DataTable dtVentasReporte = oCVentasReales.ConsultarMontoVentasRealaesTotalesAcumuladas();
			
			if(dtVentasReporte != null)
			{
				DataView dwVentasReporte = dtVentasReporte.DefaultView;
				this.gridReporte.DataSource = dwVentasReporte;

				try
				{
					this.gridReporte.DataBind();
				}
				catch(Exception a)
				{
					string b = a.Message.ToString();
					this.gridReporte.DataBind();
				}
			}
			else
			{
				this.gridReporte.DataSource = dtVentasReporte;
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarVentasRealesExcel.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarVentasRealesExcel.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarVentasRealesExcel.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarVentasRealesExcel.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarVentasRealesExcel.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarVentasRealesExcel.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarVentasRealesExcel.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarVentasRealesExcel.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{
				CNetAccessControl.LoadControls(this);
			}
			else
			{
				CNetAccessControl.RedirectPageError();
			}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarVentasRealesExcel.ValidarFiltros implementation
			return false;
		}

		private void ibtnAbrir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.GenerarExcelCompleto(this, this.gridReporte);
		}

		#endregion
	}
}
