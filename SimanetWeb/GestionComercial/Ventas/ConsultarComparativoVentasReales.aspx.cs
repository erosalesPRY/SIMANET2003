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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for ConsultarComparativoVentasReales.
	/// </summary>
	public class ConsultarComparativoVentasReales: System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblTipo;
		protected System.Web.UI.WebControls.DropDownList ddlbTipo;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb dgConsultaMensual;
		protected System.Web.UI.WebControls.Label lblResultadoMensual;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		
		#region Constantes
		
		//Ordenamiento

		//JScript

		//Columnas DataTable

		//Nombres de Controles
		
		//Paginas
		const string URLIMPRESION = "PopupImpresionConsultarComparativoVentasReales.aspx";
	
		//Key Session y QueryString
		
		//Otros
		const string GRILLAVACIA ="No existe ninguna Venta Ejecutada.";
		const string NombreGlosaTotales = "TOTAL";
		const string TituloMensual = "AL MES DE";
		const string TituloAcumulado = "A LOS MESES DE ENERO -";
		const string TipoMensual = "MENSUAL";
		const string TipoAcumulado = "ACUMULADO";
		const int Columna1 = 1;
		const int Columna2 = 2;
		const string TITULOPRINCIPAL = "CONSULTA DE VENTAS REALES ";
		#endregion Constantes
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					
					Helper.ReiniciarSession();

					this.LlenarJScript();

					this.LlenarCombos();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Ventas Reales Desagregadas " + this.ddlbTipo.SelectedItem.Text,Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarDatos();

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
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
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
			this.ddlbTipo.SelectedIndexChanged += new System.EventHandler(this.ddlbTipo_SelectedIndexChanged);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.dgConsultaMensual.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsultaMensual_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CVentasReales oCVentasReales = new CVentasReales();
			DataTable dtVentasMensual = new DataTable();

			if(this.ddlbTipo.SelectedItem.Text == TipoMensual)
			{
				//Mensual
				dtVentasMensual = oCVentasReales.ConsultarComparativoVentasRealesMensual(Helper.FechaSimanet.ObtenerFechaSesion());
			}
			else
			{
				//Acumulado
				dtVentasMensual = oCVentasReales.ConsultarComparativoVentasRealesAcumulado(Helper.FechaSimanet.ObtenerFechaSesion());
			}

			if(dtVentasMensual!=null)
			{
				DataView dwVentasMensual = dtVentasMensual.DefaultView;
				dgConsultaMensual.DataSource = dwVentasMensual;
				lblResultadoMensual.Visible = false;
			}
			else
			{
				dgConsultaMensual.DataSource = dtVentasMensual;
				lblResultadoMensual.Visible = true;
			}
		
			try
			{
				dgConsultaMensual.DataBind();
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtVentasMensual, "REPORTE" + this.lblTitulo.Text.Remove(0,8));
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				dgConsultaMensual.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarComparativoVentasReales.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarComparativoVentasReales.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.ddlbTipo.Items.Insert(Constantes.POSICIONCONTADOR,TipoMensual);
			this.ddlbTipo.Items.Insert(Constantes.POSICIONCONTADOR+1,TipoAcumulado);
		}

		public void LlenarDatos()
		{
			string TituloConstante = TITULOPRINCIPAL + "(" + Helper.FechaSimanet.ObtenerFechaSesion().Year.ToString() + "-" + (Helper.FechaSimanet.ObtenerFechaSesion().Year-1).ToString() + ")" + "CORRESPONDIENTE";

			CTablaTablas oCTablaTablas = new CTablaTablas();
			DataView dw = oCTablaTablas.ListaSegunCriterioFiltro(Convert.ToInt32(Enumerados.TablasTabla.Mes),Enumerados.ColumnasTablaTablas.Codigo + Constantes.SIGNOIGUAL + (Helper.FechaSimanet.ObtenerFechaSesion().Month) .ToString());
			
			if(this.ddlbTipo.SelectedItem.Text == TipoMensual)
			{
				this.lblTitulo.Text = TituloConstante + Constantes.ESPACIO + TituloMensual + Constantes.ESPACIO + dw[Convert.ToInt32(Constantes.POSICIONCONTADOR)][Enumerados.ColumnasTablaTablas.Descripcion.ToString()].ToString().ToUpper();
			}
			else
			{
				this.lblTitulo.Text = TituloConstante + Constantes.ESPACIO + TituloAcumulado + Constantes.ESPACIO + dw[Convert.ToInt32(Constantes.POSICIONCONTADOR)][Enumerados.ColumnasTablaTablas.Descripcion.ToString()].ToString().ToUpper();
			}
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarComparativoVentasReales.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarComparativoVentasReales.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarComparativoVentasReales.Exportar implementation
			
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
			return false;
		}

		#endregion

		private void dgConsultaMensual_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				if(e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaTotales))
				{
					Helper.ConfigurarColorTotalesGrilla(e);
					e.Item.Cells[Columna1].Text = Convert.ToDouble(e.Item.Cells[Columna1].Text).ToString(Constantes.FORMATODECIMAL4);
					e.Item.Cells[Columna2].Text = Convert.ToDouble(e.Item.Cells[Columna2].Text).ToString(Constantes.FORMATODECIMAL4);
				}
				else
				{
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
					e.Item.Cells[Columna1].Text = Convert.ToDouble(e.Item.Cells[Columna1].Text).ToString(Constantes.FORMATODECIMAL4);
					e.Item.Cells[Columna2].Text = Convert.ToDouble(e.Item.Cells[Columna2].Text).ToString(Constantes.FORMATODECIMAL4);
				}
			}
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ddlbTipo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Ventas Reales Desagregadas " + this.ddlbTipo.SelectedItem.Text,Enumerados.NivelesErrorLog.I.ToString()));

			this.LlenarDatos();
			this.LlenarGrilla();
		}
	}
}