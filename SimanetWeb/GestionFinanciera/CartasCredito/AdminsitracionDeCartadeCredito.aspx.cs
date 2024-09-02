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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using System.Diagnostics; 

namespace SIMA.SimaNetWeb.GestionFinanciera.CartasCredito
{
	/// <summary>
	/// Summary description for AdminsitracionDeCartadeCredito.
	/// </summary>
	public class AdminsitracionDeCartadeCredito : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string OBJPARAMETROCONTABLE="ParametroCartaCredito";
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkNroCartaCredito";
		const string URLDETALLE="DetalleCartadeCredito.aspx";
		const string URLDETALLEGASTOS="AdministrarCartaCreditoNotadeCargo.aspx?";
		const string URLPRINCIPAL="../../Default.aspx";
		const string COLORDENAMIENTO = "NroCDI";

		//QueryString
		const string KEYIDCARTACREDITO = "idCC";
		const string KEYIDPERIODO ="Periodo";
		const string KEYIDSITUACION ="Estado";
		const string KEYIDCENTRO ="IdCentro";
		const string KEYIDTIPOCREDITO = "idTipoCredito";
		

		//Otros
		const string NROCARTACREDITO = "NroCDI";
		const string NROORDENCOMPRA = "NroOrdenCompra";
		const string NROPROVEEDOR ="NProveedor";
		const string MONEDA = "Moneda";
		const string MONTOCARTECREDITO ="MontoCCredito";
		const string FECHAVENCIMIENTO ="FechaVencimiento";

		const string VARIABLETIPOCC ="finTCC";
		const string VARIABLESITUACIONCC = "finSCC";

		const string MSGTIPODCAMBIO ="Tipo de Cambio";

		//Controles
		const string CTRLSITUACION = "ddlbSituacion";

		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected projDataGridWeb.DataGridWeb gridResumen;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.WebControls.ImageButton ibtnGastos;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCentro;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlbModalidadCartaCredito;
		private   ListItem item =  new ListItem();
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					Helper.ReestablecerPagina(this);
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
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
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}		
			// Put user code to initialize the page here
		}
		private void redireccionaPaginaAgregar()
		{
			Page.Response.Redirect
				(
					URLDETALLE + Utilitario.Constantes.SIGNOINTERROGACION +  Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString()+
				    Utilitario.Constantes.SIGNOAMPERSON + KEYIDSITUACION +  Utilitario.Constantes.SIGNOIGUAL + this.ddlbSituacion.SelectedValue.ToString()
				);
			
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
			this.ddlbModalidadCartaCredito.SelectedIndexChanged += new System.EventHandler(this.ddlbModalidadCartaCredito_SelectedIndexChanged);
			this.ddlbSituacion.SelectedIndexChanged += new System.EventHandler(this.ddlbSituacion_SelectedIndexChanged);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnGastos.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGastos_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.gridResumen.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumen_ItemDataBound);
			this.gridResumen.SelectedIndexChanged += new System.EventHandler(this.gridResumen_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
		}
		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdminsitracionDeCartadeCredito.LlenarGrillaOrdenamiento implementation
		}
		private void GenerarResumen(DataTable dt)
		{
			if (dt!=null)
			{
				int NroResumen = 2;
				CResumenItem oCResumenItem = new CResumenItem();
				DataTable dtFinal= Helper.Resumen(oCResumenItem.ObtenerConfiDataResumen(NroResumen),dt);
				gridResumen.DataSource =dtFinal;
				
			}
			else
			{
				gridResumen.DataSource =dt;
			}
			gridResumen.DataBind();
		}
		private DataTable ObtenerDatos()
		{
			CCartaCredito oCCartaCredito = new CCartaCredito();
			return oCCartaCredito.AdministrarCartadeCredito(Convert.ToInt32(this.ddlbSituacion.SelectedValue.ToString()),
															Utilitario.Constantes.IDDEFAULT,
															Utilitario.Constantes.IDDEFAULT,
															CNetAccessControl.GetIdUser(),
															Convert.ToInt32(this.ddlbModalidadCartaCredito.SelectedValue.ToString()));
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtCartaCredito = this.ObtenerDatos();
			if(dtCartaCredito!=null)
			{
				DataView dwCartaCredito = dtCartaCredito.DefaultView;
				this.GenerarResumen(dtCartaCredito);
				dwCartaCredito.RowFilter = Helper.ObtenerFiltro();
				dwCartaCredito.Sort = columnaOrdenar ;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwCartaCredito.Count.ToString();
				grid.DataSource = dwCartaCredito;
				grid.CurrentPageIndex = Convert.ToInt32(this.hGridPagina.Value);
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtCartaCredito,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtCartaCredito;
				this.GenerarResumen(dtCartaCredito);
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
			LlenarTipo();
			LlenarSituacion();
			
			
		}

		public void LlenarTipo()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbModalidadCartaCredito.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.FinancieraModalidaddeCartaCredito));
			ddlbModalidadCartaCredito.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbModalidadCartaCredito.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbModalidadCartaCredito.DataBind();	
			if(Session[VARIABLETIPOCC] != null)
			{
				ddlbModalidadCartaCredito.SelectedIndex = Convert.ToInt32(Session[VARIABLETIPOCC]);
			}
		}

		public void LlenarSituacion()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.FinancieraEstadoCartaCredito));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();
			if(Session[VARIABLESITUACIONCC] != null)
			{
				ddlbSituacion.SelectedIndex = Convert.ToInt32(Session[VARIABLESITUACIONCC]);
			}												
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado(CTRLSITUACION,"hGridPagina","hGridPaginaSort"));
			ibtnGastos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado(CTRLSITUACION,"hGridPagina","hGridPaginaSort")+ ";return ValidarSeleccion();");
			this.ddlbSituacion.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnChange.ToString(),Utilitario.Constantes.POPUPDEESPERA);
		}

		public void RegistrarJScript()
		{
		}

		public void Imprimir()
		{
			// TODO:  Add AdminsitracionDeCartadeCredito.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdminsitracionDeCartadeCredito.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}									
		}

		public bool ValidarFiltros()
		{			
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[2].ToolTip=Utilitario.Constantes.CENTROOPERATIVO;
				e.Item.Cells[6].ToolTip=Utilitario.Constantes.MONEDA;
				e.Item.Cells[8].ToolTip=MSGTIPODCAMBIO;
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
						Helper.HistorialIrAdelantePersonalizado(CTRLSITUACION,"hGridPagina","hGridPaginaSort"),
						Helper.MostrarVentana(URLDETALLE+ Utilitario.Constantes.SIGNOINTERROGACION,KEYIDCARTACREDITO.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FINColumnaCartaCredito.idCartaCredito.ToString()])
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ KEYIDPERIODO  +  Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FINColumnaCartaCredito.Periodo.ToString()])
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ KEYIDSITUACION +  Utilitario.Constantes.SIGNOIGUAL + this.ddlbSituacion.SelectedValue.ToString()
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FINColumnaCartaCredito.idCentroOperativo.ToString()])
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ KEYIDTIPOCREDITO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbModalidadCartaCredito.SelectedValue.ToString()
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ Utilitario.Constantes.KEYMODULOCONSULTA +  Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModuloConsulta.No.ToString()));


				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
							Helper.MostrarDatosEnCajaTexto("hCodigo",Convert.ToString(dr[Utilitario.Enumerados.FINColumnaCartaCreditoNotadeCargo.idCartaCredito.ToString()]) 
							+ Utilitario.Constantes.SIGNOPUNTOYCOMA 
							+ Convert.ToString(dr[Utilitario.Enumerados.FINColumnaCartaCreditoNotadeCargo.periodo.ToString()]))
							+ Utilitario.Constantes.SIGNOPUNTOYCOMA 
							+ Helper.MostrarDatosEnCajaTexto("hidCentro",Convert.ToString(dr[Enumerados.FINColumnaCartaCredito.idCentroOperativo.ToString()]))
							);

				e.Item.Cells[7].Text = Convert.ToDouble(e.Item.Cells[7].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[8].Text = Convert.ToDouble(e.Item.Cells[8].Text).ToString(Utilitario.Constantes.FORMATODECIMAL7);
				e.Item.Cells[9].Text = Convert.ToDouble(e.Item.Cells[9].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");

			}			
		
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void RedireccionarPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro(this.ObtenerDatos(),NROCARTACREDITO + ";Nro de Carta de Credito"
																	   ,NROORDENCOMPRA + ";Nro de Orden de Compra"
																	   ,NROPROVEEDOR + ";Proveedor"
																	   ,Utilitario.Constantes.SIGNOASTERISCO + MONEDA + ";Moneda"
																	   ,MONTOCARTECREDITO + ";Monto Carta de Crédito"
																	   ,FECHAVENCIMIENTO + ";Fecha de Vencimiento");
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ddlbSituacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[VARIABLESITUACIONCC] = ddlbSituacion.SelectedIndex;
			Session[VARIABLETIPOCC] = ddlbModalidadCartaCredito.SelectedIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void gridResumen_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Cells[1].Text = Convert.ToDouble(e.Item.Cells[1].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text = Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void ibtnGastos_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (this.hCodigo.Value.Length > 0)
			{
				string [] Parametro = this.hCodigo.Value.ToString().Split(';');
				Page.Response.Redirect
					(
						URLDETALLEGASTOS +  Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ KEYIDCARTACREDITO .ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(Parametro[0]) 
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ KEYIDPERIODO  +  Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(Parametro[1])
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ Utilitario.Constantes.KEYMODULOCONSULTA +  Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModuloConsulta.No.ToString()
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ KEYIDSITUACION +  Utilitario.Constantes.SIGNOIGUAL + this.ddlbSituacion.SelectedValue.ToString()
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + hidCentro.Value
					);
			}
			else
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
		}

		private void gridResumen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}

		private void ddlbModalidadCartaCredito_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[VARIABLESITUACIONCC] = ddlbSituacion.SelectedIndex;
			Session[VARIABLETIPOCC] = ddlbModalidadCartaCredito.SelectedIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}
	}
}
