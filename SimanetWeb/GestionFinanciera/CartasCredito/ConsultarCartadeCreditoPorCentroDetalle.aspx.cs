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
	/// Summary description for ConsultarCartadeCreditoPorCentroDetalle.
	/// </summary>
	public class ConsultarCartadeCreditoPorCentroDetalle : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		//const int IDTABLAESTADOCARTAFIANZA=5;
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkBanco";
		const string URLDETALLE="AdministrarCartaCreditoNotadeCargo.aspx?";
		const string COLORDENAMIENTO = "NombreCentro";

		const string KEYIDESTADO = "idEstado";
		const string NOMBRECENTRO = "Nombre";

		const string KEYIDCARTACREDITO = "idCC";
		const string KEYIDPERIODO ="Periodo";
		const string KEYIDSITUACION ="Estado";
		const string KEYIDCENTRO ="IdCentro";
		const string KEYIDTIPOCREDITO = "idTipoCredito";

		int AnchoBorde =0;
		string ColorBorde = "";

		const string CAMPOMONTO ="lblMontoCredito";
		const string CAMPOCARGO ="lblMontoCargo";

		const string TITULOCENTROOPERATIVO ="CENTRO OPERATIVO :";

		//Filtro
		const string BANCO = "RazonSocial";
		const string NROCARTACREDITO = "NroCDI";
		const string NROORDENCOMPRA ="NroOrdenCompra";
		const string NOMBREPROVEEDOR ="NProveedor";
		const string MONEDA = "Moneda";
		const string MONTOCARTACREDITO ="MontoCCredito";
		const string FECHAVENCIMIENTO = "FechaVencimiento";
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label LblEntidad;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label10;
		protected projDataGridWeb.DataGridWeb gridResumenMoneda;
		protected projDataGridWeb.DataGridWeb gridResumen;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCampoFiltro;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
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
			this.ibtnFiltar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.gridResumenMoneda.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumenMoneda_ItemDataBound);
			this.gridResumen.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumen_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarCartadeCreditoPorCentroDetalle.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCartadeCreditoPorCentroDetalle.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			CCartaCredito oCCartaCredito = new CCartaCredito();
			return oCCartaCredito.ConsultarCartadeCreditoPorBancoDetalle(Utilitario.Constantes.IDDEFAULT,
				Convert.ToInt32(Page.Request.Params[KEYIDCENTRO].ToString()),
				Convert.ToInt32(Page.Request.Params[KEYIDESTADO].ToString()),
				Convert.ToInt32(Page.Request.Params[KEYIDTIPOCREDITO].ToString()));
		}

		private void GenerarResumen(DataTable dt)
		{
			int NroResumen = 13;
			CResumenItem oCResumenItem = new CResumenItem();
			DataTable dtFinal= Helper.Resumen(oCResumenItem.ObtenerConfiDataResumen(NroResumen),dt);
			gridResumen.DataSource =dtFinal;
			gridResumen.DataBind();
		}
		private void GenerarResumenMoneda(DataTable dt)
		{
			int NroResumen = 12;
			CResumenItem oCResumenItem = new CResumenItem();
			DataTable dtFinal= Helper.Resumen(oCResumenItem.ObtenerConfiDataResumen(NroResumen),dt);
			gridResumenMoneda.DataSource =dtFinal;
			gridResumenMoneda.DataBind();
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				this.GenerarResumen(dtGeneral);
				this.GenerarResumenMoneda(dtGeneral);
				dwGeneral.RowFilter = Helper.ObtenerFiltro(this);
				dwGeneral.Sort = columnaOrdenar ;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();
				grid.DataSource = dwGeneral;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtGeneral,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				ibtnImprimir.Visible = true;
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
			// TODO:  Add ConsultarCartadeCreditoPorCentroDetalle.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.LblEntidad.Text =TITULOCENTROOPERATIVO + Page.Request.Params[NOMBRECENTRO].ToString();			
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarCartadeCreditoPorCentroDetalle.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCartadeCreditoPorCentroDetalle.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarCartadeCreditoPorCentroDetalle.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCartadeCreditoPorCentroDetalle.Exportar implementation
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
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Label lbl;
				lbl = (Label)e.Item.Cells[8].FindControl(CAMPOMONTO);
				lbl.Text = Convert.ToDouble(dr[Utilitario.Enumerados.FINColumnaCartaCredito.ContraValor.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				lbl = (Label)e.Item.Cells[8].FindControl(CAMPOCARGO);
				lbl.Text = Convert.ToDouble(dr[Utilitario.Enumerados.FINColumnaCartaCredito.ContraValorNota.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[6].Text = Convert.ToDouble(e.Item.Cells[6].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[7].Text = Convert.ToDouble(e.Item.Cells[7].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//e.Item.Cells[8].Text = Convert.ToDouble(e.Item.Cells[8].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[0].Font.Underline = true;
				e.Item.Cells[0].ForeColor = Color.Blue;
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYIDCARTACREDITO.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FINColumnaCartaCredito.idCartaCredito.ToString()]) 
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYIDPERIODO  +  Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FINColumnaCartaCredito.Periodo.ToString()])
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYIDSITUACION +  Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.FINColumnaCartaCredito.idEstado.ToString()].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FINColumnaCartaCredito.idCentroOperativo.ToString()])
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()));

				if (Convert.ToInt32(e.Item.Cells[10].Text) > 0 && Convert.ToInt32(e.Item.Cells[10].Text)<=5)
				{
					ColorBorde=Utilitario.Constantes.INDICADORAMBAR;
					AnchoBorde=1;
				}
				else if (Convert.ToInt32(e.Item.Cells[10].Text) > 0 && Convert.ToInt32(e.Item.Cells[10].Text)>5)
				{
					ColorBorde=Utilitario.Constantes.INDICADORBLANCO;
					AnchoBorde=0;
				}
				else
				{
					ColorBorde=Utilitario.Constantes.INDICADORROJO;
					AnchoBorde=2;
				}
				string strPopup= Utilitario.Constantes.VACIO;
				e.Item.Cells[10].Text = Utilitario.Constantes.TABLASTYLE.Replace("NOTAVALOR",e.Item.Cells[10].Text).Replace("MIBORDE",Utilitario.Constantes.BORDESTYLE).Replace("[ANCHO]",AnchoBorde.ToString()).Replace("[COLORBORDE]",ColorBorde).Replace("[EVENTO]",strPopup);



				#region Helpers
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				#endregion

			}
		}

		private void gridResumenMoneda_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void gridResumen_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Cells[3].Text = Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void ibtnFiltar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos(),Utilitario.Constantes.SIGNOASTERISCO + BANCO + "; Banco"
																				,NROCARTACREDITO + ";Nro de Carta de Crédito"
																				,NROORDENCOMPRA + ";Nro de Orden de Compra"
																				,NOMBREPROVEEDOR + ";Proveedor"
																				,Utilitario.Constantes.SIGNOASTERISCO + MONEDA + ";Moneda"
																				,MONTOCARTACREDITO + ";Monto de Carta de Crédito"
																				,FECHAVENCIMIENTO + ";Fecha de Vencimiento");
		
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}
	}
}
