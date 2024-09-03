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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using System.Reflection;

namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios
{
	/// <summary>
	/// Summary description for ConsultarPresupuestodeFinanciamiento.
	/// </summary>
	public class ConsultarPresupuestodeFinanciamiento : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ning�n Registro.";  
		const string KEYIDTIPOPRESUPUESTO ="idTipoPresupuesto";
		const string KEYIDNOMBRETIPOPRESUPUESTO ="NombreTipoPresupuesto";
		const string KEYQIDFECHA="Fecha";
		const string KEYIDNOMBREMES ="NombreMes";

		const string KEYIDCENTRO ="CENTRO";
		const string KEYQIDNOMBRECENTRO="NombreCentro";
		const string KEYQIDNOMBREPRESUPUESTO="NombreTipoPrespuesto";
		const string KEYQIDNOMBREANEXO="NombreAnexo";

		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hTrama;
		protected System.Web.UI.WebControls.DropDownList ddldTipo;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblNombreTipoPresupuesto;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblNombreCentro;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarCombos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consult� las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
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
			this.ddldTipo.SelectedIndexChanged += new System.EventHandler(this.ddldTipo_SelectedIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarPresupuestodeFinanciamiento.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPresupuestodeFinanciamiento.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return ((CPresupuestoFinanciamiento)new CPresupuestoFinanciamiento()).ConsultarDetallePresupuestodeFinanciamiento(
																															Convert.ToInt32(Page.Request.Params[KEYIDCENTRO])
																															,Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year)
																															,Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month)
																															,Convert.ToInt32(this.ddldTipo.SelectedValue));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.Sort = columnaOrdenar ;
				grid.DataSource = dw;
				grid.CurrentPageIndex =indicePagina;
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			this.CargarPresupuestoTipoPlazos();
		}
		private void CargarPresupuestoTipoPlazos()
		{
			
			this.ddldTipo.DataSource= ((CTablaTablas)new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraPresupuestoTipoPlazo));
			ddldTipo.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddldTipo.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddldTipo.DataBind();			
		}


		public void LlenarDatos()
		{
			this.lblPeriodo.Text = Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year.ToString();
			this.lblMes.Text = Helper.ObtenerNombreMes(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToString().ToUpper();
			this.lblNombreCentro.Text = Page.Request.Params[KEYQIDNOMBRECENTRO].ToString().ToUpper();
			this.lblNombreTipoPresupuesto.Text = Page.Request.Params[KEYQIDNOMBREPRESUPUESTO].ToString().ToUpper() +  Utilitario.Constantes.ESPACIO + Page.Request.Params[KEYQIDNOMBREANEXO].ToString().ToUpper() ;
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarPresupuestodeFinanciamiento.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPresupuestodeFinanciamiento.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarPresupuestodeFinanciamiento.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarPresupuestodeFinanciamiento.Exportar implementation
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
			// TODO:  Add ConsultarPresupuestodeFinanciamiento.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ddldTipo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Cells[1].Text = Convert.ToDouble(e.Item.Cells[1].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text = Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}
	}
}
