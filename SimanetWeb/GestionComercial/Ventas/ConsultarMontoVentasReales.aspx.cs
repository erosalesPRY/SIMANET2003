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
	/// Summary description for ConsultarMontoVentasReales.
	/// </summary>
	public class ConsultarMontoVentasReales: System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#endregion
		
		#region Constantes
		
		//Ordenamiento

		//JScript

		//Columnas DataTable

		//Nombres de Controles
		const string TOTALSOLESCALLAO = "lblVentasRealesCallao";
		const string TOTALSOLESCHIMBOTE = "lblVentasRealesChimbote";
		const string TOTALSOLESIQUITOS = "lblVentasRealesIquitos";
		
		//Paginas
		const string URLDETALLE = "ConsultarVentasRealesMensualPorCentroOperativo.aspx?";
		const string URLIMPRESION = "PopupImpresionMontoVentasReales.aspx";
		const string URLCOMPARARVENTAS = "ConsultarVentasRealesVsVentasPresupuestadas.aspx";
		const string URLVENTASDESAGREGADAMENSUAL = "ConsultarVentasRealesDesagregadaMensual.aspx";
		const string URLVENTASDESAGREGADAMENSUALPORCENTROOPERATIVO = "ConsultarVentasRealesDesagregadaMensualPorCentroOperativo.aspx?";
		const string URLCOMPARATIVOVENTASREALES = "ConsultarComparativoVentasReales.aspx";
		const string URLREPORTETORTA = "../Reportes/GraficoVentasRealesCorporativas.aspx";
		const string URLREPORTEBARRAPERIODO = "../Reportes/GraficoComparativoPorPeriodos.aspx";
		const string URLREPORTEBARRALINEANEGOCIO = "../Reportes/GraficoComparativoPorLineaNegocio.aspx";
		const string URLVENTASREALESCONPROMOTORVSSINPROMOTOR = "ConsultarVentasRealesConPromotorVsSinPromotor.aspx";

		const string URLREPORTEPIEVENTASLINEASDENEGOCIOACUMULADAS = "../Reportes/GraficoVentasAcumuladasporLineadeNegocio.aspx";
		
	
		//Key Session y QueryString
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQNOMBRE = "Nombre";
		
		//Otros
		const string GRILLAVACIA ="No existe ninguna Venta Real.";

		const string Callao = "SIMA-CALLAO";
		const string Chimbote = "SIMA-CHIMBOTE";
		const string Iquitos = "SIMA-IQUITOS S.R.LTDA.";
		const string Peru = "SIMA-PERÚ";

		const int PosicionAvance = 0;
		const int PosicionItemCallao = 1;
		const int PosicionItemChimbote = 2;
		const int PosicionItemIquitos = 3;
		const int PosicionTotal = 4;

		const string TablaImpresion0 = "VentaReal";
		const string TablaImpresion1 = "VentaRealMensual";
		const string TablaImpresion2 = "VentaRealAnual";
		protected projDataGridWeb.DataGridWeb dgAvanceAcumulado;
		protected System.Web.UI.WebControls.Label lblAvanceAcumulado;

		const string NombreGlosaTotalesOtro = "TOTAL";
		protected projDataGridWeb.DataGridWeb dgConsultaAnual;
		protected System.Web.UI.WebControls.Label lblResultadoAnual;
		protected projDataGridWeb.DataGridWeb dgConsulta;
		protected System.Web.UI.WebControls.Label lblResultadoMensual;
		protected System.Web.UI.WebControls.ImageButton ibtnGraficoBarraLineaNegocio;
		protected System.Web.UI.WebControls.ImageButton ibtnGraficoBarraPeriodo;
		protected System.Web.UI.WebControls.ImageButton ibtnGraficoVentaRealTorta;
		protected System.Web.UI.WebControls.ImageButton ibtnGraficoVentaRealAcumuladaTorta;
		protected System.Web.UI.WebControls.ImageButton ibtnPorcentajePromotor;
		protected System.Web.UI.WebControls.ImageButton ibtnComparativoVentaReal;
		protected System.Web.UI.WebControls.ImageButton ibtnCompararVentasPresupuestadas;
		protected projDataGridWeb.DataGridWeb dgConsultaMensual;
		protected System.Web.UI.WebControls.Label lblAvanceProyectadoAnual;
		protected projDataGridWeb.DataGridWeb dgAvanceProyectadoAnual;
		const string NombreGlosaTotales = "AVANCE";

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

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron los Montos de las Ventas Reales",Enumerados.NivelesErrorLog.I.ToString()));

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
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.ibtnGraficoBarraLineaNegocio.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGraficoBarraLineaNegocio_Click);
			this.ibtnGraficoBarraPeriodo.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGraficoBarraPeriodo_Click);
			this.ibtnGraficoVentaRealTorta.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGraficoVentaRealTorta_Click);
			this.ibtnGraficoVentaRealAcumuladaTorta.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGraficoVentaRealAcumuladaTorta_Click);
			this.ibtnPorcentajePromotor.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCompararVentasPresupuestadas_Click);
			this.ibtnComparativoVentaReal.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnComparativoVentaReal_Click);
			this.ibtnCompararVentasPresupuestadas.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnPorcentajePromotor_Click);
			this.dgConsultaMensual.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsultaMensual_ItemDataBound);
			this.dgAvanceAcumulado.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgAvanceAcumulado_ItemDataBound);
			this.dgConsulta.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsulta_ItemDataBound);
			this.dgConsultaAnual.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsultaAnual_ItemDataBound);
			this.dgAvanceProyectadoAnual.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgAvanceProyectadoAnual_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			DataSet dsImprimir = new DataSet();

			//Grilla Linea Negocio
			CVentasReales oCVentasReales = new CVentasReales();
			DataTable dtVentas =  oCVentasReales.ConsultarMontoVentasRealesPorLineaNegocio(Helper.FechaSimanet.ObtenerFechaSesion());
		
			if(dtVentas!=null)
			{
				DataTable dtImpresion0 = dtVentas.Copy();
				dtImpresion0.TableName = TablaImpresion0;

				DataView dwVentas = dtVentas.DefaultView;

				dgConsulta.DataSource = dwVentas;
				lblResultado.Visible = false;

				dsImprimir.Tables.Add(dtImpresion0);
			}
			else
			{
				dgConsultaMensual.DataSource = dtVentas;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
		
			try
			{
				dgConsulta.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				dgConsulta.DataBind();
			}

			//Grilla Avance Mensual
			DataTable dtVentasMensual =  oCVentasReales.ConsultarAvanceMensualVentasReales(Helper.FechaSimanet.ObtenerFechaSesion());
		
			if(dtVentasMensual!=null)
			{
				DataTable dtImpresion1 = dtVentasMensual.Copy();
				dtImpresion1.TableName = TablaImpresion1;

				DataView dwVentasMensual = dtVentasMensual.DefaultView;

				dgConsultaMensual.DataSource = dwVentasMensual;
				lblResultadoMensual.Visible = false;

				dsImprimir.Tables.Add(dtImpresion1);
			}
			else
			{
				dgConsultaMensual.DataSource = dtVentasMensual;
				lblResultadoMensual.Visible = true;
				lblResultadoMensual.Text = GRILLAVACIA;
			}
		
			try
			{
				dgConsultaMensual.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				dgConsultaMensual.DataBind();
			}

			//Grilla Avance Acumulado
			DataTable dtVentasAcumulado =  oCVentasReales.ConsultarAvanceAcumuladoVentasReales(Helper.FechaSimanet.ObtenerFechaSesion());
		
			if(dtVentasAcumulado!=null)
			{
				DataTable dtImpresion2 = dtVentasAcumulado.Copy();
				dtImpresion2.TableName = TablaImpresion2;

				DataView dwVentasAcumulado = dtVentasAcumulado.DefaultView;

				dgConsultaAnual.DataSource = dwVentasAcumulado;
				dgAvanceAcumulado.DataSource = dwVentasAcumulado;
				dgAvanceProyectadoAnual.DataSource = dwVentasAcumulado;

				lblResultadoAnual.Visible = false;
				lblAvanceAcumulado.Visible = false;
				lblAvanceProyectadoAnual.Visible = false;

				dsImprimir.Tables.Add(dtImpresion2);
			}
			else
			{
				dgConsultaAnual.DataSource = dtVentasAcumulado;
				dgAvanceAcumulado.DataSource = dtVentasAcumulado;
				dgAvanceProyectadoAnual.DataSource = dtVentasAcumulado;

				lblResultadoAnual.Visible = true;
				lblAvanceAcumulado.Visible = true;
				lblAvanceProyectadoAnual.Visible = true;

				lblResultadoAnual.Text = GRILLAVACIA;
				lblAvanceAcumulado.Text = GRILLAVACIA;
				lblAvanceProyectadoAnual.Text = GRILLAVACIA;
			}
		
			try
			{
				dgConsultaAnual.DataBind();
				dgAvanceAcumulado.DataBind();
				dgAvanceProyectadoAnual.DataBind();

				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dsImprimir,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEVENTASREALESTOTALES));
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				dgConsultaAnual.DataBind();
				dgAvanceAcumulado.DataBind();
				dgAvanceProyectadoAnual.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarMontoVentasReales.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarMontoVentasReales.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarMontoVentasReales.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			DataView dw = oCTablaTablas.ListaSegunCriterioFiltro(Convert.ToInt32(Enumerados.TablasTabla.Mes),Enumerados.ColumnasTablaTablas.Codigo + Constantes.SIGNOIGUAL + (Helper.FechaSimanet.ObtenerFechaSesion().Month) .ToString());
			this.lblTitulo.Text += Constantes.ESPACIO + dw[Convert.ToInt32(Constantes.POSICIONCONTADOR)][Enumerados.ColumnasTablaTablas.Descripcion.ToString()].ToString().ToUpper() + Constantes.ESPACIO + Constantes.LINEA + Constantes.ESPACIO + Helper.FechaSimanet.ObtenerFechaSesion().Year.ToString();
		}

		public void LlenarJScript()
		{
			this.ibtnCompararVentasPresupuestadas.Attributes.Add(Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnCompararVentasPresupuestadas.Attributes.Add(Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnComparativoVentaReal.Attributes.Add(Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnComparativoVentaReal.Attributes.Add(Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnPorcentajePromotor.Attributes.Add(Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnPorcentajePromotor.Attributes.Add(Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnGraficoBarraLineaNegocio.Attributes.Add(Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnGraficoBarraLineaNegocio.Attributes.Add(Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnGraficoBarraPeriodo.Attributes.Add(Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnGraficoBarraPeriodo.Attributes.Add(Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnGraficoVentaRealTorta.Attributes.Add(Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnGraficoVentaRealTorta.Attributes.Add(Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnGraficoVentaRealAcumuladaTorta.Attributes.Add(Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarMontoVentasReales.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarMontoVentasReales.Exportar implementation
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
				if(e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaTotales) || e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaTotalesOtro))
				{
					Helper.ConfigurarColorTotalesGrilla(e);
				}
				else
				{
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
					e.Item.Cells[PosicionItemCallao].Text = Convert.ToDouble(e.Item.Cells[PosicionItemCallao].Text).ToString(Constantes.FORMATODECIMAL4);
					e.Item.Cells[PosicionItemChimbote].Text = Convert.ToDouble(e.Item.Cells[PosicionItemChimbote].Text).ToString(Constantes.FORMATODECIMAL4);
					e.Item.Cells[PosicionItemIquitos].Text = Convert.ToDouble(e.Item.Cells[PosicionItemIquitos].Text).ToString(Constantes.FORMATODECIMAL4);
					e.Item.Cells[PosicionTotal].Text = Convert.ToDouble(e.Item.Cells[PosicionTotal].Text).ToString(Constantes.FORMATODECIMAL4);
				}
			}
			if (e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[PosicionAvance].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[PosicionAvance].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLVENTASDESAGREGADAMENSUAL,Constantes.VACIO) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
				e.Item.Cells[PosicionAvance].Font.Underline=true;
				e.Item.Cells[PosicionAvance].Style[Constantes.CURSOR] = Constantes.TIPOCURSORMANO;
				e.Item.Cells[PosicionAvance].ToolTip = "Ventas Ejecutadas Desagregada Corporativa";

				e.Item.Cells[PosicionItemCallao].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[PosicionItemCallao].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLVENTASDESAGREGADAMENSUALPORCENTROOPERATIVO,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.IdCentroOperativo.SimaCallao).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Callao) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
				e.Item.Cells[PosicionItemCallao].Font.Underline=true;
				e.Item.Cells[PosicionItemCallao].Style[Constantes.CURSOR] = Constantes.TIPOCURSORMANO;
				e.Item.Cells[PosicionItemCallao].ToolTip = "Ventas Ejecutadas Desagregada De Callao";

				e.Item.Cells[PosicionItemChimbote].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[PosicionItemChimbote].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLVENTASDESAGREGADAMENSUALPORCENTROOPERATIVO,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.IdCentroOperativo.SimaChimbote).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Chimbote) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
				e.Item.Cells[PosicionItemChimbote].Font.Underline=true;
				e.Item.Cells[PosicionItemChimbote].Style[Constantes.CURSOR] = Constantes.TIPOCURSORMANO;
				e.Item.Cells[PosicionItemChimbote].ToolTip = "Ventas Ejecutadas Desagregada De Chimbote";

				e.Item.Cells[PosicionItemIquitos].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[PosicionItemIquitos].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLVENTASDESAGREGADAMENSUALPORCENTROOPERATIVO,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.IdCentroOperativo.SimaIquitos).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Iquitos) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
				e.Item.Cells[PosicionItemIquitos].Font.Underline=true;
				e.Item.Cells[PosicionItemIquitos].Style[Constantes.CURSOR] = Constantes.TIPOCURSORMANO;
				e.Item.Cells[PosicionItemIquitos].ToolTip = "Ventas Ejecutadas Desagregada De Iquitos";

				e.Item.Cells[PosicionTotal].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[PosicionTotal].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLVENTASDESAGREGADAMENSUALPORCENTROOPERATIVO,KEYQNOMBRE + Constantes.SIGNOIGUAL + Peru) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
				e.Item.Cells[PosicionTotal].Font.Underline=true;
				e.Item.Cells[PosicionTotal].Style[Constantes.CURSOR] = Constantes.TIPOCURSORMANO;
				e.Item.Cells[PosicionTotal].ToolTip = "Ventas Ejecutadas Desagregada De Perú";
			}
		}

		private void dgConsultaAnual_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				if (e.Item.ItemIndex == 2 || e.Item.ItemIndex == 3 || e.Item.ItemIndex == 8) 
				{
					if(e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaTotales) || e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaTotalesOtro))
					{
						Utilitario.Helper.ConfigurarColorTotalesGrilla(e);
					}
					else
					{
						Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
						e.Item.Cells[PosicionItemCallao].Text = Convert.ToDouble(e.Item.Cells[PosicionItemCallao].Text).ToString(Constantes.FORMATODECIMAL4);
						e.Item.Cells[PosicionItemChimbote].Text = Convert.ToDouble(e.Item.Cells[PosicionItemChimbote].Text).ToString(Constantes.FORMATODECIMAL4);
						e.Item.Cells[PosicionItemIquitos].Text = Convert.ToDouble(e.Item.Cells[PosicionItemIquitos].Text).ToString(Constantes.FORMATODECIMAL4);
						e.Item.Cells[PosicionTotal].Text = Convert.ToDouble(e.Item.Cells[PosicionTotal].Text).ToString(Constantes.FORMATODECIMAL4);
					}
				}
				else
				{
					e.Item.Visible =false;
				}
			}
			if (e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[PosicionItemCallao].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[PosicionItemCallao].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.IdCentroOperativo.SimaCallao).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Callao) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
				e.Item.Cells[PosicionItemCallao].Font.Underline=true;
				e.Item.Cells[PosicionItemCallao].Style[Constantes.CURSOR] = Constantes.TIPOCURSORMANO;
				e.Item.Cells[PosicionItemCallao].ToolTip = "Ventas Ejecutadas Por Meses De Callao";

				e.Item.Cells[PosicionItemChimbote].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[PosicionItemChimbote].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.IdCentroOperativo.SimaChimbote).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Chimbote) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
				e.Item.Cells[PosicionItemChimbote].Font.Underline=true;
				e.Item.Cells[PosicionItemChimbote].Style[Constantes.CURSOR] = Constantes.TIPOCURSORMANO;
				e.Item.Cells[PosicionItemChimbote].ToolTip = "Ventas Ejecutadas Por Meses De Chimbote";

				e.Item.Cells[PosicionItemIquitos].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[PosicionItemIquitos].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.IdCentroOperativo.SimaIquitos).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Iquitos) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
				e.Item.Cells[PosicionItemIquitos].Font.Underline=true;
				e.Item.Cells[PosicionItemIquitos].Style[Constantes.CURSOR] = Constantes.TIPOCURSORMANO;
				e.Item.Cells[PosicionItemIquitos].ToolTip = "Ventas Ejecutadas Por Meses De Iquitos";

				/*e.Item.Cells[PosicionItemCallao].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[PosicionItemCallao].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.IdCentroOperativo.SimaCallao).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Callao) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
				e.Item.Cells[PosicionItemCallao].Font.Underline=true;
				e.Item.Cells[PosicionItemCallao].Style[Constantes.CURSOR] = Constantes.TIPOCURSORMANO;
				e.Item.Cells[PosicionItemCallao].ToolTip = "Ventas Ejecutadas Por Meses De Callao";

				e.Item.Cells[PosicionItemChimbote].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[PosicionItemChimbote].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.IdCentroOperativo.SimaChimbote).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Chimbote) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
				e.Item.Cells[PosicionItemChimbote].Font.Underline=true;
				e.Item.Cells[PosicionItemChimbote].Style[Constantes.CURSOR] = Constantes.TIPOCURSORMANO;
				e.Item.Cells[PosicionItemChimbote].ToolTip = "Ventas Ejecutadas Por Meses De Chimbote";

				e.Item.Cells[PosicionItemIquitos].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[PosicionItemIquitos].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.IdCentroOperativo.SimaIquitos).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Iquitos) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
				e.Item.Cells[PosicionItemIquitos].Font.Underline=true;
				e.Item.Cells[PosicionItemIquitos].Style[Constantes.CURSOR] = Constantes.TIPOCURSORMANO;
				e.Item.Cells[PosicionItemIquitos].ToolTip = "Ventas Ejecutadas Por Meses De Iquitos";*/
			}
		}

		private void dgConsulta_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				if(e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaTotales) || e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaTotalesOtro))
				{
					Utilitario.Helper.ConfigurarColorTotalesGrilla(e);
				}
				else
				{
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				}

				e.Item.Cells[PosicionItemCallao].Text = Convert.ToDouble(e.Item.Cells[PosicionItemCallao].Text).ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[PosicionItemChimbote].Text = Convert.ToDouble(e.Item.Cells[PosicionItemChimbote].Text).ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[PosicionItemIquitos].Text = Convert.ToDouble(e.Item.Cells[PosicionItemIquitos].Text).ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[PosicionTotal].Text = Convert.ToDouble(e.Item.Cells[PosicionTotal].Text).ToString(Constantes.FORMATODECIMAL4);
			}
		}

		private void ibtnCompararVentasPresupuestadas_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLCOMPARARVENTAS);
		}

		private void ibtnComparativoVentaReal_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLCOMPARATIVOVENTASREALES);
		}

		private void ibtnGraficoVentaRealTorta_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLREPORTETORTA);
		}

		private void ibtnGraficoBarraPeriodo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLREPORTEBARRAPERIODO);
		}

		private void ibtnGraficoBarraLineaNegocio_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLREPORTEBARRALINEANEGOCIO);
		}

		private void ibtnPorcentajePromotor_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLVENTASREALESCONPROMOTORVSSINPROMOTOR);
		}

		private void ibtnGraficoVentaRealAcumuladaTorta_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLREPORTEPIEVENTASLINEASDENEGOCIOACUMULADAS);
		}

		private void dgAvanceAcumulado_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				if (e.Item.ItemIndex == 1 || e.Item.ItemIndex == 3 || e.Item.ItemIndex == 4) 
				{
					if(e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaTotales) || e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaTotalesOtro))
					{
						Utilitario.Helper.ConfigurarColorTotalesGrilla(e);
					}
					else
					{
						Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
						e.Item.Cells[PosicionItemCallao].Text = Convert.ToDouble(e.Item.Cells[PosicionItemCallao].Text).ToString(Constantes.FORMATODECIMAL4);
						e.Item.Cells[PosicionItemChimbote].Text = Convert.ToDouble(e.Item.Cells[PosicionItemChimbote].Text).ToString(Constantes.FORMATODECIMAL4);
						e.Item.Cells[PosicionItemIquitos].Text = Convert.ToDouble(e.Item.Cells[PosicionItemIquitos].Text).ToString(Constantes.FORMATODECIMAL4);
						e.Item.Cells[PosicionTotal].Text = Convert.ToDouble(e.Item.Cells[PosicionTotal].Text).ToString(Constantes.FORMATODECIMAL4);
					}
				}
				else
				{
					e.Item.Visible =false;
				}
			}
		}

		private void dgAvanceProyectadoAnual_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				if (e.Item.ItemIndex == 2 || e.Item.ItemIndex == 5 || e.Item.ItemIndex == 7) 
				{
					if(e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaTotales) || e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaTotalesOtro))
					{
						Utilitario.Helper.ConfigurarColorTotalesGrilla(e);
					}
					else
					{
						Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
						e.Item.Cells[PosicionItemCallao].Text = Convert.ToDouble(e.Item.Cells[PosicionItemCallao].Text).ToString(Constantes.FORMATODECIMAL4);
						e.Item.Cells[PosicionItemChimbote].Text = Convert.ToDouble(e.Item.Cells[PosicionItemChimbote].Text).ToString(Constantes.FORMATODECIMAL4);
						e.Item.Cells[PosicionItemIquitos].Text = Convert.ToDouble(e.Item.Cells[PosicionItemIquitos].Text).ToString(Constantes.FORMATODECIMAL4);
						e.Item.Cells[PosicionTotal].Text = Convert.ToDouble(e.Item.Cells[PosicionTotal].Text).ToString(Constantes.FORMATODECIMAL4);
					}
				}
				else
				{
					e.Item.Visible =false;
				}
			}		
		}
	}
}