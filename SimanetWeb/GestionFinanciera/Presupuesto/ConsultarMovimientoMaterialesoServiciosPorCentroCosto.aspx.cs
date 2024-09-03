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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Drawing.Printing;

namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto
{

	public class ConsultarMovimientoMaterialesoServiciosPorCentroCosto : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string KEYQIDPERIODO = "Periodo";
			const string KEYQIDMES = "mes";
			const string KEYIDCUENTA = "Cta5Dig";
			const string KEYIDCENTRO ="idCC";

			const string GRILLAVACIA ="No existe ningún Registro.";  

			const string KEYQIDDESCNAT = "QIDDESCNAT";
			const string KEYQIDMONTO = "QIDMONTO";
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion 
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarCombos();
					
					this.LlenarGrillaOrdenamientoPaginacion("",Constantes.INDICEPAGINADEFAULT);
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
					string msgb =oException.Message.ToString();
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
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarMovimientoMaterialesoServiciosPorCentroCosto.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarMovimientoMaterialesoServiciosPorCentroCosto.LlenarGrillaOrdenamiento implementation
		}


		private DataTable ObtenerDatos()
		{
			CPresupuesto oCPresupuesto = new  CPresupuesto();
			DataTable tblResultado =oCPresupuesto.ConsultarMovimientodeMateriales
											(Convert.ToInt32(Page.Request.Params[KEYQIDPERIODO])
											,Convert.ToInt32(Page.Request.Params[KEYQIDMES])
											,Convert.ToInt32(Page.Request.Params[KEYIDCENTRO])
											,Convert.ToInt32(Page.Request.Params[KEYIDCUENTA])
											);
			return tblResultado;
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			//Session[SESSIONTBLDETMATERIALES] = this.ObtenerDatos();
			//DataTable dtGeneral = this.GenerarResumen((DataTable) Session[SESSIONTBLDETMATERIALES]); //this.ObtenerDatos();
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtGeneral;
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
			// TODO:  Add ConsultarMovimientoMaterialesoServiciosPorCentroCosto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarMovimientoMaterialesoServiciosPorCentroCosto.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarMovimientoMaterialesoServiciosPorCentroCosto.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarMovimientoMaterialesoServiciosPorCentroCosto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarMovimientoMaterialesoServiciosPorCentroCosto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarMovimientoMaterialesoServiciosPorCentroCosto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarMovimientoMaterialesoServiciosPorCentroCosto.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarMovimientoMaterialesoServiciosPorCentroCosto.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Cells[4].Text = Convert.ToDouble(e.Item.Cells[4].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				if (dr["ind_Contabiliza"].ToString()=="S")
				{
					System.Web.UI.WebControls.Image oImage = new System.Web.UI.WebControls.Image();
					oImage.ImageUrl= HttpContext.Current.Session[Utilitario.Constantes.SPATHAPPWEB].ToString() + "/Imagenes/post.gif" ;
					oImage.ToolTip = "Contabilizado";
					e.Item.Cells[8].Controls.Add(oImage);
				}
			}
		}
	}
}

