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
	/// Summary description for PopupImpresionConsultarDetalleVentasReales.
	/// </summary>
	public class PopupImpresionConsultarDetalleVentasReales : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DataGrid grid;
		protected System.Web.UI.WebControls.DataGrid gridMensual;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.Label lblResultadoObservaciones;

		#endregion Controles

		#region Constantes
		
		//Key Session y QueryString
		const int CantidadCero = 0;
		const string GRILLAVACIA ="No existe ninguna Venta Ejecutada.";
		const string GRILLAOBSERVACIONESVACIA ="No existe ninguna Observacion en el Mes.";
		const string TablaImpresion0 = "VentaRealDetallada";
		const string TablaImpresion1 = "ObservacionesMensuales";
		const string KEYQSUBTITULOREPORTE = "Subtitulo";

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CImpresion oCImpresion =  new CImpresion();
			DataSet dsImpresion =  oCImpresion.ObtenerDataSetImprimir();
			
			if(dsImpresion.Tables[TablaImpresion0]!=null)
			{
				DataView dwImpresion0 = dsImpresion.Tables[TablaImpresion0].DefaultView;
				dwImpresion0.Sort = oCImpresion.ObtenerColumnaOrdenamiento();

				if(dwImpresion0.Count > CantidadCero)
				{
					grid.DataSource = dwImpresion0;
					grid.CurrentPageIndex = oCImpresion.ObtenerIndicePagina();
					lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
			}
			else
			{
				grid.DataSource = null;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
			}
			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
			}

			if(this.grid.DataSource != null)
			{
				//Grilla Observaciones
				if(dsImpresion.Tables[TablaImpresion1]!=null)
				{
					DataView dwImpresion1 = dsImpresion.Tables[TablaImpresion1].DefaultView;
					gridMensual.DataSource = dwImpresion1;
					lblResultado.Visible = false;
				}
				else
				{
					gridMensual.DataSource = null;
					lblResultadoObservaciones.Text = GRILLAOBSERVACIONESVACIA;
					lblResultadoObservaciones.Visible = true;
				}
				try
				{
					gridMensual.DataBind();
				}
				catch(Exception ex)
				{
					string a = ex.Message;
				}
			}
			else
			{
				gridMensual.DataSource = null;
				lblResultadoObservaciones.Text = GRILLAOBSERVACIONESVACIA;
				lblResultadoObservaciones.Visible = true;
				this.lblObservaciones.Visible = false;
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionConsultarDetalleVentasReales.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add PopupImpresionConsultarDetalleVentasReales.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionConsultarDetalleVentasReales.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporte()+Constantes.ESPACIO + Constantes.LINEA + Constantes.ESPACIO + Page.Request.QueryString[KEYQSUBTITULOREPORTE];
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionConsultarDetalleVentasReales.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionConsultarDetalleVentasReales.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
		 	ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionConsultarDetalleVentasReales.Exportar implementation
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
	}
}