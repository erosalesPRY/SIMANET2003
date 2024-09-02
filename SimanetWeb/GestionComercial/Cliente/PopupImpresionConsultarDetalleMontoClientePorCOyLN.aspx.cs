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
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial.Cliente
{
	/// <summary>
	/// Summary description for PopupImpresionConsultarDetalleMontoClientePorCOyLN.
	/// </summary>
	public class PopupImpresionConsultarDetalleMontoClientePorCOyLN : System.Web.UI.Page
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblNombreRazonSocial;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected projDataGridWeb.DataGridWeb dgConsulta;
		#endregion
	
		#region Constantes
		//Key Session y QueryString
		const string KEYQNOMBRE = "RazonSocial";

		//Otros
		const int TablaPrincipal  = 0;
		const int TablaSecundaria = 1;
		const int CantidadCero = 0;
		const int PosicionMonto = 3;
		const int POSICIONFOOTERTOTAL = 3;
		const string TEXTOTOTAL = "Monto";
		const string GRILLAVACIA = "No existe ninguna Detalle de Monto de Cliente por Centro de Operación y Línea de Negocio";  
		#endregion

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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.dgConsulta.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsulta_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CImpresion oCImpresion =  new CImpresion();

			DataSet dsImpresion = oCImpresion.ObtenerDataSetImprimir();
			
			DataTable dtImpresion0 = dsImpresion.Tables[TablaPrincipal];
			DataTable dtImpresion1 = dsImpresion.Tables[TablaSecundaria];

			if(dtImpresion0!=null)
			{
				DataView dwImpresion0 = dtImpresion0.DefaultView;
				dwImpresion0.Sort = oCImpresion.ObtenerColumnaOrdenamiento();

				if(dwImpresion0.Count > CantidadCero)
				{
					grid.DataSource = dwImpresion0;
					Double [] x =  Helper.TotalizarDataView(dwImpresion0,TEXTOTOTAL);
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = x[Constantes.POSICIONCONTADOR].ToString(Utilitario.Constantes.FORMATODECIMAL4);
					lblResultado.Visible = false;
					grid.CurrentPageIndex = oCImpresion.ObtenerIndicePagina();
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
				grid.DataSource = dtImpresion0;
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

			if(dtImpresion1!=null)
			{
				DataView dwImpresion1 = dtImpresion1.DefaultView;
				dwImpresion1.Sort = oCImpresion.ObtenerColumnaOrdenamiento();

				if(dwImpresion1.Count > CantidadCero)
				{
					dgConsulta.DataSource = dwImpresion1;
					lblResultado.Visible = false;
					dgConsulta.CurrentPageIndex = oCImpresion.ObtenerIndicePagina();
				}
				else
				{
					dgConsulta.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
			}
			else
			{
				dgConsulta.DataSource = dtImpresion1;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
			}
			try
			{
				dgConsulta.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
			}

		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionConsultarDetalleMontoClientePorCOyLN.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add PopupImpresionConsultarDetalleMontoClientePorCOyLN.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionConsultarDetalleMontoClientePorCOyLN.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporte();
			lblNombreRazonSocial.Text = Convert.ToString(Page.Request.QueryString[KEYQNOMBRE]);
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionConsultarDetalleMontoClientePorCOyLN.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionConsultarDetalleMontoClientePorCOyLN.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionConsultarDetalleMontoClientePorCOyLN.Exportar implementation
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

		private void dgConsulta_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				for(int i=1; i<e.Item.Cells.Count; i++)
				{
					e.Item.Cells[i].HorizontalAlign = HorizontalAlign.Right;
					e.Item.Cells[i].Text = Convert.ToDouble(e.Item.Cells[i].Text).ToString(Constantes.FORMATODECIMAL4);
				}
			}

		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Cells[PosicionMonto].Text = Convert.ToDouble(e.Item.Cells[PosicionMonto].Text).ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
			}
		}
	}
}
