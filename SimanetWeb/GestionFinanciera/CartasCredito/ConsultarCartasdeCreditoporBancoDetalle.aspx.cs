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


namespace SIMA.SimaNetWeb.GestionFinanciera.CartasCredito
{
	/// <summary>
	/// Summary description for ConsultarCartasdeCreditoporBancoDetalle.
	/// </summary>
	public class ConsultarCartasdeCreditoporBancoDetalle : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		//const int IDTABLAESTADOCARTAFIANZA=5;
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkBanco";
		const string URLPRINCIPAL="ConsultarCartasdeCreditoporBanco.aspx";
		const string URLANTERIOR="ConsultarCartasdeCreditoporBanco.aspx?";
		const string URLDETALLE="AdministrarCartaCreditoNotadeCargo.aspx?";
		const string URLDETALLENOTACARGO="";
		const string COLORDENAMIENTO = "NombreCentro";

		const string KEYIDESTADO = "idEstado";
		const string KEYIDENTIDADFINANCIERA = "idEF";
		const string NOMBREENTIDAD = "Nombre";

		const string KEYIDCARTACREDITO = "idCC";
		const string KEYIDPERIODO ="Periodo";
		const string KEYIDSITUACION ="Estado";
		const string KEYIDCENTRO ="IdCentro";
		const string KEYIDTIPOCREDITO = "idTipoCredito";
	
		const string CAMPO1 ="lblFechaInicio";
		const string CAMPO2 ="lblFechaVence";

		const string CAMPOMNT1 ="lblImporteOrigen";
		const string CAMPOMNT2 ="lblImporteDolarizado";

		const string CAMPOMNT3 ="lblFImporteDolarizado";

		//Otros
		const string TITULOBANCO ="BANCO :";
		const string COLUMNAOBSERVACION ="Observacion";
		const string TOTALIZA ="Totaliza";

		//Filtro
		const string CENTROOPERATIVO ="NombreCentro";
		const string NROCARTACREDITO ="NroCDI";
		const string NROORDENCOMPRA ="NroOrdenCompra";
		const string PORVEEEDOR ="NProveedor";
		const string MONEDA ="Moneda";
        const string MONTOCARTACREDITO ="MontoCCredito";
		const string FECHAVENCIMIENTO ="FechaVencimiento";

		//Header Grilla
		const string NOMBRECENTROOPERACIONES ="Centro de Operaciones";
		const string NOMBREOC ="Orden de Compra";
		const string NOMBRETIPOCAMBIO ="Tipo de Cambio";

		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCampoFiltro;
		protected projDataGridWeb.DataGridWeb gridResumenMoneda;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label LblEntidad;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
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
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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
					ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(oSIMAExcepcionDominio.Error.ToString());					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}		
			// Put user code to initialize the page here
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
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.gridResumenMoneda.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumenMoneda_ItemDataBound);
			this.gridResumenMoneda.SelectedIndexChanged += new System.EventHandler(this.gridResumenMoneda_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarCartasdeCreditoporBancoDetalle.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCartasdeCreditoporBancoDetalle.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			int idBanco =((Page.Request.Params[KEYIDENTIDADFINANCIERA]==null)? Utilitario.Constantes.IDDEFAULT: Convert.ToInt32(Page.Request.Params[KEYIDENTIDADFINANCIERA]));
			int idCentro =((Page.Request.Params[KEYIDCENTRO]==null)? Utilitario.Constantes.IDDEFAULT: Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]));
			grid.Columns[2].Visible = (idBanco ==Utilitario.Constantes.IDDEFAULT);
			grid.Columns[1].Visible = (idCentro ==Utilitario.Constantes.IDDEFAULT);
			CCartaCredito oCCartaCredito = new CCartaCredito();
			return oCCartaCredito.ConsultarCartadeCreditoPorBancoDetalle(idBanco,
																			idCentro,
																			Convert.ToInt32(Page.Request.Params[KEYIDESTADO].ToString()),
																			Convert.ToInt32(Page.Request.Params[KEYIDTIPOCREDITO].ToString()));
        }
		private void TotalizarContravalor(DataView dtv)
		{
			Session[TOTALIZA] = Convert.ToDouble((object) dtv.Table.Compute("Sum(" + Enumerados.FINColumnaCartaCredito.MontoCCreditoContraValor.ToString() + ")",dtv.RowFilter.ToString()));
		}

		private void GenerarResumenMoneda(DataView dv)
		{
			//int NroResumen = 6; Anulado
			int NroResumen = 11;
			CResumenItem oCResumenItem = new CResumenItem();			
			DataTable dtFinal= Helper.Resumen(oCResumenItem.ObtenerConfiDataResumen(NroResumen),dv);
			gridResumenMoneda.DataSource =dtFinal;
			gridResumenMoneda.DataBind();
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.RowFilter = Helper.ObtenerFiltro();
				this.TotalizarContravalor(dwGeneral);
				this.GenerarResumenMoneda(dwGeneral);
				dwGeneral.Sort = columnaOrdenar ;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();
				grid.DataSource = dwGeneral;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtGeneral,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtGeneral;
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
			// TODO:  Add ConsultarCartasdeCreditoporBancoDetalle.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.LblEntidad.Text =TITULOBANCO + Page.Request.Params[NOMBREENTIDAD].ToString();			
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarCartasdeCreditoporBancoDetalle.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCartasdeCreditoporBancoDetalle.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarCartasdeCreditoporBancoDetalle.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCartasdeCreditoporBancoDetalle.Exportar implementation
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

		private void RedirecionarPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}


		private void RedireccionarPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

		private void ibtnFiltar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos(),Utilitario.Constantes.SIGNOASTERISCO + CENTROOPERATIVO + "; Centro Operativo"
																				,NROCARTACREDITO + ";Nro de Carta de Crédito"
																				,NROORDENCOMPRA + ";Nro de Orden de Compra"
																				,PORVEEEDOR + ";Proveedor"
																				,Utilitario.Constantes.SIGNOASTERISCO + MONEDA + ";Moneda"
																				,MONTOCARTACREDITO + ";Monto de Carta de Crédito"
																				,FECHAVENCIMIENTO + ";Fecha de Vencimiento");
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			#region HEADER
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[1].ToolTip=NOMBRECENTROOPERACIONES;
				e.Item.Cells[4].ToolTip=NOMBREOC;
				e.Item.Cells[8].ToolTip=MONEDA;
				e.Item.Cells[9].ToolTip=NOMBRETIPOCAMBIO;
			}
			#endregion
			#region ITEM
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
						Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
						Helper.MostrarVentana(URLDETALLE,KEYIDCARTACREDITO.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FINColumnaCartaCredito.idCartaCredito.ToString()]) 
														+ Utilitario.Constantes.SIGNOAMPERSON 
														+ KEYIDPERIODO  +  Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FINColumnaCartaCredito.Periodo.ToString()])
														+ Utilitario.Constantes.SIGNOAMPERSON 
														+ KEYIDSITUACION +  Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDESTADO].ToString()/*dr[Enumerados.FINColumnaCartaCredito.idEstado.ToString()].ToString()*/
														+ Utilitario.Constantes.SIGNOAMPERSON 
														+ KEYIDTIPOCREDITO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOCREDITO].ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FINColumnaCartaCredito.idCentroOperativo.ToString()])
														+ Utilitario.Constantes.SIGNOAMPERSON 
														+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON 
														+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[Utilitario.Constantes.KEYMODULOCONSULTA].ToString()
														));
				

				if (Convert.ToInt32(e.Item.Cells[7].Text)<=5)
				{
					e.Item.Cells[7].ForeColor = Color.Red;
				}
				((Label) e.Item.Cells[6].FindControl(CAMPO1)).Text = dr[Enumerados.FINColumnaCartaCredito.FechaEmision.ToString()].ToString();
				((Label) e.Item.Cells[6].FindControl(CAMPO2)).Text = dr[Enumerados.FINColumnaCartaCredito.FechaVencimiento.ToString()].ToString();

				((Label) e.Item.Cells[10].FindControl(CAMPOMNT1)).Text = Convert.ToDouble(dr[Enumerados.FINColumnaCartaCredito.MontoCCredito.ToString()].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[10].FindControl(CAMPOMNT2)).Text = Convert.ToDouble(dr[Enumerados.FINColumnaCartaCredito.MontoCCreditoContraValor.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				#region Helpers
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("txtDescripcion",dr[COLUMNAOBSERVACION].ToString()));
					Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				#endregion

			}
			#endregion
			#region FOOTER
				if(e.Item.ItemType == ListItemType.Footer)
				{
					
					e.Item.Cells[0].ColumnSpan=((Page.Request.Params[KEYIDCENTRO]!=null && Page.Request.Params[KEYIDENTIDADFINANCIERA]!=null)? 8: 9);
					e.Item.Cells[10].Visible = true;
					((Label) e.Item.Cells[10].FindControl(CAMPOMNT3)).Font.Bold=true;

					((Label) e.Item.Cells[10].FindControl(CAMPOMNT3)).Font.Size= 8;
					((Label) e.Item.Cells[10].FindControl(CAMPOMNT3)).Text = Convert.ToDouble(((Session[TOTALIZA]!=null)? Session[TOTALIZA]:0)).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}
			#endregion
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void gridResumenMoneda_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}
		private void gridResumenMoneda_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


	}
}
