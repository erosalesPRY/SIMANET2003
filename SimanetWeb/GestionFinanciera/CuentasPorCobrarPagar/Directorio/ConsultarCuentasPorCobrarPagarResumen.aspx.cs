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
using NetAccessControl;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.Controladoras.GestionFinanciera;

namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio
{
	/// <summary>
	/// Summary description for ConsultarCuentasPorPagar.
	/// </summary>
	public class ConsultarCuentasPorCobrarPagarResumen: System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblMes;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "Cliente";
		const string PERIODO="Periodo";
		const string MES="Mes";
	
		//Paginas
		const string URLDETALLE = "ConsultarCuentasPorCobrarPagar.aspx?";
		const string URLIMPRESION = "PopupImpresionConsultarCuentasPorPagar.aspx";
				
		//Key Session y QueryString
		const string KEYQFLAGDIRECTORIO= "FlagDirectorio";
		const string KEYQIDTIPOCUENTA= "IdTipoCuenta";
		const string KEYQIDCUENTAPORCOBRARPAGAR = "IdCuenta";
		const string KEYQIDSUBCUENTAPORCOBRARPAGAR = "IdSubCuenta";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQDESCRIPCIONTIPOCUENTA = "TipoCuenta";
		const string KEYQDESCRIPCIONCUENTA = "Cuenta";
		const string KEYQDESCRIPCIONSUBCUENTA = "SubCuenta";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminar(this.form,'cbxEliminar','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
			
		//Otros
		const string GRILLAVACIA ="No existe ninguna Cuenta";  

		const int CUENTAPORCOBRAR = 0;
		const int CUENTAPORPAGAR = 1;

		#endregion Constantes

		#region Variables			
		double acumPorCobrarSP, acumPorCobrarSC, acumPorCobrarSCH, acumPorCobrarSI, acumPorCobrarTotal;
		double acumPorPagarSP, acumPorPagarSC, acumPorPagarSCH, acumPorPagarSI, acumPorPagarTotal;

		#endregion Variables
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"CuentasPorPagar",this.ToString(),"Se consultó la Cuentas Por Pagar",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.SeleccionarItemCombos(this);
					
					this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));				
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
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}

		private void Totalizar(DataView dwTotales)
		{
			if (dwTotales !=null)
			{
				double[] aArreglo = Helper.TotalizarDataView(dwTotales,
					Enumerados.FINColumnaResumenCuentasPorPagar.SimaCallao.ToString(),
					Enumerados.FINColumnaResumenCuentasPorPagar.idTipoCta.ToString(),CUENTAPORCOBRAR);
				acumPorCobrarSC = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,
				Enumerados.FINColumnaResumenCuentasPorPagar.SimaChimbote.ToString(),
				Enumerados.FINColumnaResumenCuentasPorPagar.idTipoCta.ToString(),CUENTAPORCOBRAR);
				acumPorCobrarSCH = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,				
					Enumerados.FINColumnaResumenCuentasPorPagar.SimaPeru.ToString(),
					Enumerados.FINColumnaResumenCuentasPorPagar.idTipoCta.ToString(),CUENTAPORCOBRAR);
				acumPorCobrarSP = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,
					Enumerados.FINColumnaResumenCuentasPorPagar.SimaIquitos.ToString(),
					Enumerados.FINColumnaResumenCuentasPorPagar.idTipoCta.ToString(),CUENTAPORCOBRAR);
				acumPorCobrarSI = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,
					Enumerados.FINColumnaResumenCuentasPorPagar.Total.ToString(),
					Enumerados.FINColumnaResumenCuentasPorPagar.idTipoCta.ToString(),CUENTAPORCOBRAR);
				acumPorCobrarTotal  = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,
					Enumerados.FINColumnaResumenCuentasPorPagar.SimaCallao.ToString(),
					Enumerados.FINColumnaResumenCuentasPorPagar.idTipoCta.ToString(),CUENTAPORPAGAR);
				acumPorPagarSC = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,
					Enumerados.FINColumnaResumenCuentasPorPagar.SimaChimbote.ToString(),
					Enumerados.FINColumnaResumenCuentasPorPagar.idTipoCta.ToString(),CUENTAPORPAGAR);
				acumPorPagarSCH = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,				
					Enumerados.FINColumnaResumenCuentasPorPagar.SimaPeru.ToString(),
					Enumerados.FINColumnaResumenCuentasPorPagar.idTipoCta.ToString(),CUENTAPORPAGAR);
				acumPorPagarSP = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,
					Enumerados.FINColumnaResumenCuentasPorPagar.SimaIquitos.ToString(),
					Enumerados.FINColumnaResumenCuentasPorPagar.idTipoCta.ToString(),CUENTAPORPAGAR);
				acumPorPagarSI = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,
					Enumerados.FINColumnaResumenCuentasPorPagar.Total.ToString(),
					Enumerados.FINColumnaResumenCuentasPorPagar.idTipoCta.ToString(),CUENTAPORPAGAR);
				acumPorPagarTotal  = aArreglo[0];
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			this.lblPeriodo.Text = Page.Request.Params[PERIODO].ToString();
			this.lblMes.Text = Helper.ObtenerNombreMes(Convert.ToInt32(Page.Request.Params[MES]), 
								Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToString().ToUpper();

			CCuentasporPagar oCCuentasporPagar=  new CCuentasporPagar();
			DataTable dtCuentasPorPagar;  

			if (Convert.ToInt32(Page.Request.QueryString[KEYQFLAGDIRECTORIO].ToString()) == Constantes.POSICIONINDEXUNO)
			{
				dtCuentasPorPagar = 
					oCCuentasporPagar.ConsultarCuentasporPagarCobrarAlCierre();
			}
			else
			{
				dtCuentasPorPagar = 
					oCCuentasporPagar.ConsultarCuentasporPagarCobrar(Convert.ToInt32(Page.Request.Params[PERIODO]),
					Convert.ToInt32(Page.Request.Params[MES]),
					Constantes.POSICIONINDEXCERO, Constantes.POSICIONINDEXCERO);
			}

			if(dtCuentasPorPagar!=null)
			{
				DataView dwCuentasPorPagar = dtCuentasPorPagar.DefaultView;
				dwCuentasPorPagar.Sort = columnaOrdenar ;
				dwCuentasPorPagar.RowFilter = Utilitario.Helper.ObtenerFiltro();

				if (dwCuentasPorPagar.Count == 0)
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
				}
				else
				{
					grid.DataSource = dwCuentasPorPagar;
					grid.CurrentPageIndex =indicePagina;
					//grid.Columns[Constantes.POSICIONFOOTERTOTAL].FooterText = Constantes.TEXTOFOOTERTOTAL;
					//grid.Columns[Constantes.POSICIONTOTAL].FooterText = dwCuentasPorPagar.Count.ToString();

					this.Totalizar(dwCuentasPorPagar);

					//CImpresion oCImpresion = new CImpresion();
					//oCImpresion.GuardarDataImprimirExportar(dtCuentasPorPagar,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTECuentasPorPagar),columnaOrdenar,indicePagina);
					lblResultado.Visible = false;
				}
			}
			else
			{
				grid.DataSource = dtCuentasPorPagar;
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
			// TODO:  Add ConsultaDeCartasFianzas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{

		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			
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


		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				
				
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,PERIODO + 
					Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[PERIODO].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON +
					MES + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[MES].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL + 
					dr[Enumerados.FINColumnaResumenCuentasPorPagar.idTipoCta.ToString()].ToString() +  
					Utilitario.Constantes.SIGNOAMPERSON + KEYQFLAGDIRECTORIO + 
					Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQFLAGDIRECTORIO] +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + 
					dr[Enumerados.FINColumnaResumenCuentasPorPagar.Concepto.ToString()].ToString() +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString())+
					Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA +
					Utilitario.Constantes.SIGNOPUNTOYCOMA + 
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
			
			if(e.Item.ItemType == ListItemType.Footer)
			{
				double Monto=0;
				Monto = acumPorCobrarSC - acumPorPagarSC;
				e.Item.Cells[1].Text = Monto.ToString(Constantes.FORMATODECIMAL4);

				Monto = acumPorCobrarSCH - acumPorPagarSCH;
				e.Item.Cells[2].Text = Monto.ToString(Constantes.FORMATODECIMAL4);

				Monto = acumPorCobrarSP - acumPorPagarSP;
				e.Item.Cells[3].Text = Monto.ToString(Constantes.FORMATODECIMAL4);

				Monto = acumPorCobrarSI - acumPorPagarSI;
				e.Item.Cells[4].Text = Monto.ToString(Constantes.FORMATODECIMAL4);

				Monto = acumPorCobrarTotal - acumPorPagarTotal;
				e.Item.Cells[5].Text = Monto.ToString(Constantes.FORMATODECIMAL4);
			}		
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			CCuentasporPagar oCCuentasporPagar=  new CCuentasporPagar();
			DataTable dtCuentasPorPagar;  
			if (Convert.ToInt32(Page.Request.QueryString[KEYQFLAGDIRECTORIO].ToString()) == Constantes.POSICIONINDEXUNO)
			{
				dtCuentasPorPagar = 
					oCCuentasporPagar.ConsultarCuentasporPagarCobrarAlCierre();
			}
			else
			{
				dtCuentasPorPagar = 
					oCCuentasporPagar.ConsultarCuentasporPagarCobrar(Convert.ToInt32(Page.Request.Params[PERIODO]),
					Convert.ToInt32(Page.Request.Params[MES]),
					Constantes.POSICIONINDEXCERO, Constantes.POSICIONINDEXCERO);
			}

			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this,dtCuentasPorPagar,"../../../Filtros.aspx"
				,"*" + Enumerados.FINColumnaResumenCuentasPorPagar.Concepto.ToString()+";Concepto");
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();						
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
