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
using SIMA.Controladoras.GestionComercial;
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
	/// Summary description for ConsultarPresupuestodeVentasLiquidadas.
	/// </summary>
	public class ConsultarPresupuestodeVentasLiquidadas : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string KEYIDTIPOPRESUPUESTO ="idTipoPresupuesto";
		const string KEYIDNOMBRETIPOPRESUPUESTO ="NombreTipoPresupuesto";
		const string KEYFECHA="Fecha";
		const string KEYIDNOMBREMES ="NombreMes";

		const string KEYIDCENTRO ="CENTRO";
		const string KEYQVENTAS="VENTAS";

		const string KEYQIDNOMBRECENTRO="NombreCentro";
		const string KEYQIDNOMBREPRESUPUESTO="NombreTipoPrespuesto";
		const string KEYQIDNOMBREANEXO="NombreAnexo";
	
		const string URLDETALLE="ConsultarPresupuestodeVentasLiquidadasDetalle.aspx?";

		const string KEYQVERIQUITOS ="Ver";
		const string KEYQNOMBRERUBRO ="NRubro";
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQIDIDTIPOINFORMACION ="idTipoInfo";

		//DataGrid and DataTable
		const string COLUMNAIDRUBRO ="idRubro";

		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblNombreTipoPresupuesto;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblNombreCentro;
		protected System.Web.UI.WebControls.Label Label1;
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Utilitario.Constantes.VACIO,Utilitario.Constantes.ValorConstanteCero);
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadas.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			if(Page.Request.Params[KEYQVENTAS]== Utilitario.Constantes.ValorConstanteUno.ToString())
			{
				CPresupuesto oCPresupuesto = new CPresupuesto();
				return oCPresupuesto.ConsultarDetallePresupuestoVentas(
																		Convert.ToInt32(Page.Request.Params[KEYIDCENTRO])
																		,this.lblPeriodo.Text);
		
			}
			else
			{
				return ((CPresupuestoVentasLiquidadas)new CPresupuestoVentasLiquidadas()).ConsultarPresupuestodeVentasLiquidadas(
																																Convert.ToInt32(Page.Request.Params[KEYIDCENTRO])
																																,Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYFECHA]).Year)
																																,Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYFECHA]).Month));
			}
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
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblPeriodo.Text = Convert.ToDateTime(Page.Request.Params[KEYFECHA]).Year.ToString();
			this.lblMes.Text = Helper.ObtenerNombreMes(Convert.ToDateTime(Page.Request.Params[KEYFECHA]).Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToString().ToUpper();
			this.lblNombreCentro.Text = Page.Request.Params[KEYQIDNOMBRECENTRO].ToString().ToUpper();
			this.lblNombreTipoPresupuesto.Text = Page.Request.Params[KEYQIDNOMBREPRESUPUESTO].ToString().ToUpper() +  Utilitario.Constantes.ESPACIO + Page.Request.Params[KEYQIDNOMBREANEXO].ToString().ToUpper() ;
			this.lblPagina.Text="Consultar Presupuesto de Ventas";
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadas.Exportar implementation
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
			// TODO:  Add ConsultarPresupuestodeVentasLiquidadas.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Cells[1].Text = Convert.ToDouble(e.Item.Cells[1].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text = Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				
				if(Page.Request.Params[KEYQVENTAS]!= Utilitario.Constantes.ValorConstanteUno.ToString())
				{
					 string Parametros = KEYQNOMBRERUBRO + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[0].Text
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDFORMATOESTADODEGANACIASYPERDIDAS.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNAIDRUBRO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYFECHA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYFECHA].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQIDIDTIPOINFORMACION + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteCero.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDCENTRO].ToString();

					Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[0],
						Helper.PopupDialogoModal(URLDETALLE + Parametros,800,300,false));

				}

				
				

			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
