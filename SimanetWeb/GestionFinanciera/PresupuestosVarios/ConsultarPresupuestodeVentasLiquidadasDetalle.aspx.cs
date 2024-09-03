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
using System.Configuration;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios
{
	/// <summary>
	/// Summary description for ConsultarPresupuestodeVentasLiquidadasDetalle.
	/// </summary>
	public class ConsultarPresupuestodeVentasLiquidadasDetalle : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes

		const string KEYIDCENTRO ="CENTRO";
		const string KEYQNOMBRERUBRO ="NRubro";
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQIDFECHA = "Fecha";
		const string KEYQIDIDTIPOINFORMACION ="idTipoInfo";		

		//Otros
		const string CTRLLBLVENTAS ="lblVentas";
		const string CTRLLBLCOSTO ="lblCosto";

		//DataGrid and DataTable
		const string COLUMNAMVENTAS ="mVentas";

		#endregion

		#region Controles
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblRubro;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarGrilla();
				}				
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
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
			}
			catch(Exception oException)
			{
				string debug = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		private DataTable  ObtenerDatos()
		{
			return ((CFormatoRubroDetalleMovimiento) new CFormatoRubroDetalleMovimiento())
				.ConsultarFormatoRubroDetalleMovimientoPorCentroVCV
				(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDIDTIPOINFORMACION])
				,Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year)
				,Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month)
				,Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]));
		}



		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			if (dt !=null)
			{
				this.grid.DataSource=dt;
			}
			else
			{
				this.grid.DataSource=dt;
			}
			this.grid.DataBind();			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadasDetalle.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadasDetalle.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadasDetalle.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadasDetalle.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadasDetalle.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadasDetalle.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadasDetalle.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadasDetalle.Exportar implementation
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
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadasDetalle.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				((Label) e.Item.Cells[1].FindControl(CTRLLBLVENTAS)).Text = Convert.ToDouble(dr[COLUMNAMVENTAS]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[1].FindControl(CTRLLBLCOSTO)).Text = Convert.ToDouble(dr[COLUMNAMVENTAS]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
