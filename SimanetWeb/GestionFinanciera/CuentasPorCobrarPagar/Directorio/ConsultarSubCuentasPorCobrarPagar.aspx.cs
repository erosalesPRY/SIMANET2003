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
	public class ConsultarSubCuentasPorCobrarPagar: System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblPrimario;
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
	
		//Paginas
		const string URLDETALLE = "ConsultarDetalleSubCuentasPorCobrarPagar.aspx?";
		const string URLAPORTESACCIONISTAS = "ConsultarCuentasporCobrarDiversasAportesAccionistas.aspx?";
		const string URLPRESTAMOSPERSONAL = "ConsultarCuentasporCobrarDiversasPrestamosaPersonal.aspx?";
		const string URLPRESTAMOSTERCEROS = "ConsultarCuentasporCobrarDiversasPrestamosaTerceros.aspx?";
		const string URLRECLAMOSTERCEROS = "ConsultarCuentasporCobrarDiversasReclamosaTerceros.aspx?";
		const string URLINTERESES = "ConsultarCuentasporCobrarDiversasIntereses.aspx?";
		const string URLOTRAS = "ConsultarCuentasporCobrarDiversasOtros.aspx?";
		const string URLLETRASCAMBIO = "ConsultarDetalleSubCuentasPorCobrarPagar.aspx?IdLetraCambio=1&";
		const string URLIMPRESION = "PopupImpresionConsultarCuentasPorPagar.aspx";
		const string URLANTICIPOSAPROVEEDORES = "ConsultarAnticipoAProveedores.aspx?";
		
				
		//Key Session y QueryString
		const string KEYQIDTIPOCUENTA = "IdTipoCuenta";
		const string KEYQIDCUENTAPORCOBRARPAGAR = "IdCuenta";
		const string KEYQIDSUBCUENTAPORCOBRARPAGAR = "IdSubCuenta";
		const string KEYQIDCENTROOPERATIVO= "IdCentroOperativo";
		const string KEYQIDLETRACAMBIO = "IdLetraCambio";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQDESCRIPCIONCUENTA = "Cuenta";
		const string KEYQDESCRIPCIONSUBCUENTA = "SubCuenta";
		const string PERIODO="Periodo";
		const string MES="Mes";
		const string KEYQFLAGDIRECTORIO= "FlagDirectorio";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminar(this.form,'cbxEliminar','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		string URLDETALLESUBCUENTA="";

		//Otros
		const string GRILLAVACIA ="No existe ninguna SubCuenta";  

		const int LETRASCAMBIOPORCOBRAR = 2;
		const int LETRASCAMBIOPORPAGAR = 12;
		const int APORTESACCIONISTAS = 4;
		const int PRESTAMOSPERSONAL = 5;
		const int PRESTAMOSTERCEROS = 6;
		const int RECLAMOSTERCEROS = 7;
		const int INTERESES = 8;
		const int OTRAS = 9;
		const int ANTICIPOSAPROVEDORES = 3;
		
		#endregion Constantes

		#region Variables			
		double acumCantidadSP;
		double acumCantidadSC;
		double acumCantidadSCH;
		double acumCantidadSI;
		double acumCantidadTotal;

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
				double[] aArreglo = Helper.TotalizarDataView(dwTotales,Enumerados.FINColumnaResumenCuentasPorPagar.MSimaCallao.ToString());
				acumCantidadSC = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,Enumerados.FINColumnaResumenCuentasPorPagar.MSimaChimbote.ToString());
				acumCantidadSCH = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,Enumerados.FINColumnaResumenCuentasPorPagar.MSimaPeru.ToString());
				acumCantidadSP = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,Enumerados.FINColumnaResumenCuentasPorPagar.MSimaIquitos.ToString());
				acumCantidadSI = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,Enumerados.FINColumnaResumenCuentasPorPagar.MTotal.ToString());
				acumCantidadTotal  = aArreglo[0];
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			this.lblPrimario.Text= Page.Request.Params[KEYQDESCRIPCION].ToString();

			CCuentasPorCobrarPagar oCCuentasPorCobrarPagar=  new CCuentasPorCobrarPagar();
			DataTable dtCuentasPorPagar;

			if (Convert.ToInt32(Page.Request.QueryString[KEYQFLAGDIRECTORIO].ToString()) == Constantes.POSICIONINDEXUNO)
			{
				dtCuentasPorPagar = oCCuentasPorCobrarPagar.ConsultarSubCuentasPorCobrarPagarPorCuentaAlCierre(
					Convert.ToInt32(Page.Request.QueryString[KEYQIDCUENTAPORCOBRARPAGAR]));
			}
			else
			{
				dtCuentasPorPagar = oCCuentasPorCobrarPagar.ConsultarSubCuentasPorCobrarPagarPorCuenta(
					Convert.ToInt32(Page.Request.QueryString[KEYQIDCUENTAPORCOBRARPAGAR]));
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

				switch (Convert.ToInt32(dr[Enumerados.FINColumnaResumenCuentasPorPagar.Id1.ToString()]))
				{
					case APORTESACCIONISTAS:
						URLDETALLESUBCUENTA = URLAPORTESACCIONISTAS;
						break;
					case PRESTAMOSPERSONAL:
						URLDETALLESUBCUENTA= URLPRESTAMOSPERSONAL;
						break;
					case PRESTAMOSTERCEROS:
						URLDETALLESUBCUENTA= URLPRESTAMOSTERCEROS;
						break;
					case RECLAMOSTERCEROS:
						URLDETALLESUBCUENTA= URLRECLAMOSTERCEROS;
						break;
					case LETRASCAMBIOPORCOBRAR:
						URLDETALLESUBCUENTA= URLLETRASCAMBIO;
						break;
					case LETRASCAMBIOPORPAGAR:
						URLDETALLESUBCUENTA= URLLETRASCAMBIO;
						break;
					case INTERESES:
						URLDETALLESUBCUENTA= URLINTERESES;
						break;
					case OTRAS:
						URLDETALLESUBCUENTA= URLOTRAS;
						break;
					case ANTICIPOSAPROVEDORES:
						URLDETALLESUBCUENTA=URLANTICIPOSAPROVEEDORES;
						break;
					default:
						URLDETALLESUBCUENTA= URLDETALLE;
						break;
				}
				
				/*if(dr["descripcion"].ToString()=="LETRAS" && Page.Request.QueryString[KEYQIDTIPOCUENTA].ToString()=="1")
				{

					e.Item.Cells[1].Font.Underline=true;
					e.Item.Cells[1].ForeColor= System.Drawing.Color.Blue;
					
				}
				else
				{*/
				e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLESUBCUENTA,KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.Params[KEYQIDTIPOCUENTA] + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDCUENTAPORCOBRARPAGAR + Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR] + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDSUBCUENTAPORCOBRARPAGAR + Utilitario.Constantes.SIGNOIGUAL + 
					dr[Enumerados.FINColumnaResumenCuentasPorPagar.Id1.ToString()].ToString() +  
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.Params[KEYQDESCRIPCION] +  Constantes.ESPACIO + Constantes.SIGNOMENOS + Constantes.ESPACIO +
					dr[Enumerados.FINColumnaResumenCuentasPorPagar.Descripcion.ToString()].ToString() +  
					Utilitario.Constantes.SIGNOAMPERSON + KEYQFLAGDIRECTORIO + 
					Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQFLAGDIRECTORIO] +  
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Constantes.SIMACALLAO +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString())+
					Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA +
					Utilitario.Constantes.SIGNOPUNTOYCOMA + 
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
				e.Item.Cells[1].Font.Underline=true;
				e.Item.Cells[1].ForeColor= System.Drawing.Color.Blue;

				e.Item.Cells[2].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLESUBCUENTA,KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.Params[KEYQIDTIPOCUENTA] + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDCUENTAPORCOBRARPAGAR + Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR] + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDSUBCUENTAPORCOBRARPAGAR + Utilitario.Constantes.SIGNOIGUAL + 
					dr[Enumerados.FINColumnaResumenCuentasPorPagar.Id1.ToString()].ToString() +  
					Utilitario.Constantes.SIGNOAMPERSON + KEYQFLAGDIRECTORIO + 
					Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQFLAGDIRECTORIO] +  
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.Params[KEYQDESCRIPCION] +  Constantes.ESPACIO + Constantes.SIGNOMENOS + Constantes.ESPACIO +
					dr[Enumerados.FINColumnaResumenCuentasPorPagar.Descripcion.ToString()].ToString() +  
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Constantes.SIMACHIMBOTE +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString())+
					Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA +
					Utilitario.Constantes.SIGNOPUNTOYCOMA + 
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
				e.Item.Cells[2].Font.Underline=true;
				e.Item.Cells[2].ForeColor= System.Drawing.Color.Blue;

				e.Item.Cells[4].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLESUBCUENTA,KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.Params[KEYQIDTIPOCUENTA] + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDCUENTAPORCOBRARPAGAR + Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR] + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDSUBCUENTAPORCOBRARPAGAR + Utilitario.Constantes.SIGNOIGUAL + 
					dr[Enumerados.FINColumnaResumenCuentasPorPagar.Id1.ToString()].ToString() +  
					Utilitario.Constantes.SIGNOAMPERSON + KEYQFLAGDIRECTORIO + 
					Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQFLAGDIRECTORIO] +  
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.Params[KEYQDESCRIPCION] +  Constantes.ESPACIO + Constantes.SIGNOMENOS + Constantes.ESPACIO +
					dr[Enumerados.FINColumnaResumenCuentasPorPagar.Descripcion.ToString()].ToString() +  
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Constantes.SIMAIQUITOS +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString())+
					Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA +
					Utilitario.Constantes.SIGNOPUNTOYCOMA + 
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
				e.Item.Cells[4].Font.Underline=true;
				e.Item.Cells[4].ForeColor= System.Drawing.Color.Blue;

				//}
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
			
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[1].Text = acumCantidadSC.ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[2].Text = acumCantidadSCH.ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text = acumCantidadSP.ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[4].Text = acumCantidadSI.ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = acumCantidadTotal.ToString(Constantes.FORMATODECIMAL4);
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
			CCuentasPorCobrarPagar oCCuentasPorCobrarPagar=  new CCuentasPorCobrarPagar();
			DataTable dtCuentasPorPagar;

			if (Convert.ToInt32(Page.Request.QueryString[KEYQFLAGDIRECTORIO].ToString()) == Constantes.POSICIONINDEXUNO)
			{
				dtCuentasPorPagar = oCCuentasPorCobrarPagar.ConsultarSubCuentasPorCobrarPagarPorCuentaAlCierre(
					Convert.ToInt32(Page.Request.QueryString[KEYQIDCUENTAPORCOBRARPAGAR]));
			}
			else
			{
				dtCuentasPorPagar = oCCuentasPorCobrarPagar.ConsultarSubCuentasPorCobrarPagarPorCuenta(
					Convert.ToInt32(Page.Request.QueryString[KEYQIDCUENTAPORCOBRARPAGAR]));
			}

			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this,dtCuentasPorPagar,"../../../Filtros.aspx"
				,"*" + Enumerados.FINColumnaResumenCuentasPorPagar.Descripcion.ToString()+";Sub-Cuenta");
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();						
		}
	}
}
