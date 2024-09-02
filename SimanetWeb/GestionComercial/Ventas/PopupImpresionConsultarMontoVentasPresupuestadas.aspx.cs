using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for PopupImpresionConsultarMontoVentasPresupuestadas.
	/// </summary>
	public class PopupImpresionConsultarMontoVentasPresupuestadas : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.DataGrid dgMontoPresupuestado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;

		#endregion Controles

		#region Constantes
		
		//Key Session y QueryString
		const string GRILLAVACIA ="No existe ninguna Venta Presupuestada.";
		const string TablaImpresion0 = "VentaPresupuestadaTotal";

		//Otros
		const int CantidadCero = 0;
		const string NombreGlosaTotales = "TOTAL MGP";
		const string NombreGlosaTotales1 = "TOTAL PRIV";
		
		const string NombreGlosaTotalFinal = "TOTAL FINAL";
		const int POSICIONCALLAO = 1;
		const int POSICIONCHIMBOTE = 2;
		const int POSICIONIQUITOS = 3;
		protected System.Web.UI.WebControls.Label lblSubTitulo;
		const int POSICIONTOTAL = 4;
		#endregion Constantes

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarDatos();
					this.LlenarGrilla();
					this.Imprimir();
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
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
			this.dgMontoPresupuestado.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgMontoPresupuestado_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CImpresion oCImpresion =  new CImpresion();
			DataTable dtImpresion =  oCImpresion.ObtenerDataImprimir();
			
			if(dtImpresion.Rows.Count > 0)
			{
				DataView dwImpresion0 = dtImpresion.DefaultView;
				dgMontoPresupuestado.DataSource = dwImpresion0;
				lblResultado.Visible = false;
			}
			else
			{
				dgMontoPresupuestado.DataSource = null;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
			}
			try
			{
				dgMontoPresupuestado.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionConsultarMontoVentasPresupuestadas.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add PopupImpresionConsultarMontoVentasPresupuestadas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionConsultarMontoVentasPresupuestadas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporte();
			lblSubTitulo.Text = CImpresion.ObtenerSubTituloReporte();
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionConsultarMontoVentasPresupuestadas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionConsultarMontoVentasPresupuestadas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
		 	ltlMensaje.Text  = Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionConsultarMontoVentasPresupuestadas.Exportar implementation
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
			return true;
		}

		#endregion

		private void dgMontoPresupuestado_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Cells[POSICIONCALLAO].Text = Convert.ToDouble(e.Item.Cells[POSICIONCALLAO].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[POSICIONCHIMBOTE].Text = Convert.ToDouble(e.Item.Cells[POSICIONCHIMBOTE].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[POSICIONIQUITOS].Text = Convert.ToDouble(e.Item.Cells[POSICIONIQUITOS].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[POSICIONTOTAL].Text = Convert.ToDouble(e.Item.Cells[POSICIONTOTAL].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}

			if(e.Item.Cells[Utilitario.Constantes.POSICIONCONTADORVENTASPRESUPUESTADAS].Text == NombreGlosaTotales || e.Item.Cells[Utilitario.Constantes.POSICIONCONTADORVENTASPRESUPUESTADAS].Text == NombreGlosaTotales1 || e.Item.Cells[Utilitario.Constantes.POSICIONCONTADORVENTASPRESUPUESTADAS].Text == NombreGlosaTotalFinal)
			{
				Helper.ConfigurarColorTotalesGrilla(e);
			}
		}
	}
}