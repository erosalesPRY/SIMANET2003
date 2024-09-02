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
	/// Summary description for ConsultarVentasRealesDesagregadaMensualPorCentroOperativo.
	/// </summary>
	public class ConsultarVentasRealesDesagregadaMensualPorCentroOperativo: System.Web.UI.Page,IPaginaBase
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
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.Label lblResultadoObservaciones;
		protected projDataGridWeb.DataGridWeb dgObservaciones;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		#endregion
		
		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "OBSERVACION";

		//JScript

		//Columnas DataTable

		//Nombres de Controles
		
		//Paginas
		const string URLIMPRESION = "PopupImpresionConsultarVentasRealesDesagregadaMensualPorCentroOperativo.aspx?";
	
		//Key Session y QueryString
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQNOMBRE = "Nombre";
		const string KEYTIPOIMPRESION = "TipoImpresion";
		
		//Otros
		const string GRILLAVACIA ="No existe ninguna Venta Colocada.";
		const string NombreGlosaTotales = "T";
		const string TituloConstante = "CONSULTA DE VENTAS COLOCADAS TOTALES CORRESPONDIENTE";
		const string TituloMensual = "AL MES DE";
		const string TituloAcumulado = "A LOS MESES DE ENERO -";
		const string TipoMensual = "MENSUAL";
		const string TipoAcumulado = "ACUMULADO";
		const string GRILLAOBSERVACIONESVACIA ="No existe ninguna Observacion en el Mes.";
		const string TablaImpresion0 = "VentaRealDetalladaDesagregada";
		const string TablaImpresion1 = "ObservacionesVentaRealDetalladaDesagregadaMensuales";
		const int Columna1 = 1;
		const int Columna2 = 2;
		const string TOTALCO = "totalco";
		const string PPTO = "ppto";
		const int ENERO = 1;
		const int DICIEMBRE = 12;
		
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
			this.dgObservaciones.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgObservaciones_PageIndexChanged);
			this.dgObservaciones.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgObservaciones_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarVentasRealesDesagregadaMensualPorCentroOperativo.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarVentasRealesDesagregadaMensualPorCentroOperativo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataSet dsImprimir = new DataSet();

			CVentasReales oCVentasReales = new CVentasReales();
			DataTable dtVentasMensual = new DataTable();
			
			if(this.ddlbTipo.SelectedItem.Text == TipoMensual)
			{
				//MENSUAL
				if(Page.Request.QueryString[KEYQIDCENTROOPERATIVO] != null)
				{
					dtVentasMensual =  oCVentasReales.ConsultarVentasRealesPorCentroOperativoDesagregadoMensual(Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]), Helper.FechaSimanet.ObtenerFechaSesion());
				}
				else
				{
					dtVentasMensual =  oCVentasReales.ConsultarVentasRealesDesagregadasSimaPeruMensual(Helper.FechaSimanet.ObtenerFechaSesion());
				}
				this.txtObservacion.Text = Utilitario.Constantes.VACIO;
			}
			else
			{
				//ACUMULADO
				if(Page.Request.QueryString[KEYQIDCENTROOPERATIVO] != null)
				{
//					int mes = DateTime.Today.Month;
//					int ano;
//					if(mes == ENERO)
//					{
//						ano = DateTime.Today.Year - 1 ;
//						mes = DICIEMBRE;
//					}
//					else
//					{
//						ano =  DateTime.Today.Year;
//						mes = mes -1;
//					}
					DateTime FechaSesion = Helper.FechaSimanet.ObtenerFechaSesion();
					int mes = FechaSesion.Month;
					int ano = FechaSesion.Year;

					dtVentasMensual =  oCVentasReales.ConsultarVentasRealesPorCentroOperativoDesagregadoAcumulado(Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]),ano,mes);
					this.txtObservacion.Text = Utilitario.Constantes.VACIO;
					lblResultadoObservaciones.Visible = false;
					lblObservaciones.Visible = false;
				}
				else
				{
					dtVentasMensual =  oCVentasReales.ConsultarVentasRealesDesagregadasSimaPeruAcumulado();
				}
			}

			if(dtVentasMensual!=null)
			{
				DataView dwVentasMensual = dtVentasMensual.DefaultView;
				dgConsultaMensual.DataSource = dwVentasMensual;
				lblResultadoMensual.Visible = false;

				DataTable dtImpresion =  Helper.DataViewTODataTable(dwVentasMensual);
				dtImpresion.TableName = TablaImpresion0;
				dsImprimir.Tables.Add(dtImpresion);
			}
			else
			{
				dgConsultaMensual.DataSource = dtVentasMensual;
				lblResultadoMensual.Visible = true;
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

			if (ddlbTipo.SelectedValue == TipoAcumulado )
			{
				LlenarObservacionesAcumuladas(); 
			}
			else if (ddlbTipo.SelectedValue == TipoMensual )
			{
				LlenarObservacionesMensuales(); 
			}
		
			CImpresion oCImpresion = new CImpresion();
			oCImpresion.GuardarDataImprimirExportar(dsImprimir,"REPORTE"+this.lblTitulo.Text.Remove(0,8)+Constantes.ESPACIO+Constantes.LINEA+Constantes.ESPACIO+this.lblCentroOperativo.Text);
		}

		public void LlenarCombos()
		{
			this.ddlbTipo.Items.Insert(Constantes.POSICIONCONTADOR,TipoMensual);
			this.ddlbTipo.Items.Insert(Constantes.POSICIONCONTADOR+1,TipoAcumulado);
		}

		public void LlenarDatos()
		{
			this.lblCentroOperativo.Text = Page.Request.QueryString[KEYQNOMBRE];

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
			// TODO:  Add ConsultarVentasRealesDesagregadaMensualPorCentroOperativo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarVentasRealesDesagregadaMensualPorCentroOperativo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION+KEYTIPOIMPRESION+Constantes.SIGNOIGUAL+TipoAcumulado,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarVentasRealesDesagregadaMensualPorCentroOperativo.Exportar implementation
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

		private void LlenarObservacionesMensuales()
		{
			CVentasReales oCVentasReales = new CVentasReales();
			DataTable dtVentasMensual = new DataTable();

			if(Page.Request.QueryString[KEYQIDCENTROOPERATIVO] != null /*&& this.ddlbTipo.SelectedItem.Text == TipoMensual*/)
			{
				int tipoObservacion = 1;
				DataTable dtObservacionesVentas =  oCVentasReales.ConsultarObservacionesVentasRealesPorMesPorCentroOperativo(Helper.FechaSimanet.ObtenerFechaSesion().Month, Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]), Helper.FechaSimanet.ObtenerFechaSesion().Year, tipoObservacion);
			
				if(dtObservacionesVentas!=null)
				{						
						this.txtObservacion.Text = dtObservacionesVentas.Rows[0][Convert.ToString(Utilitario.Enumerados.ColumnasObservacionesMensualesVentas.OBSERVACION)].ToString();
				}
			}
			else
			{
				this.txtObservacion.Text = Utilitario.Constantes.VACIO;
				lblResultadoObservaciones.Visible = false;
				lblObservaciones.Visible = false;
			}
		}


		private void LlenarObservacionesAcumuladas()
		{
			CVentasReales oCVentasReales = new CVentasReales();
			DataTable dtVentasMensual = new DataTable();

			if(Page.Request.QueryString[KEYQIDCENTROOPERATIVO] != null /*&& this.ddlbTipo.SelectedItem.Text == TipoMensual*/)
			{
				int tipoObservacion = 2;
				DataTable dtObservacionesVentas =  oCVentasReales.ConsultarObservacionesVentasRealesAcumuladaPorAnoCentroOperativo(Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]), Helper.FechaSimanet.ObtenerFechaSesion().Year,  Helper.FechaSimanet.ObtenerFechaSesion().Month,tipoObservacion);
			
				if(dtObservacionesVentas!=null)
				{						
					this.txtObservacion.Text = dtObservacionesVentas.Rows[0][Utilitario.Enumerados.ColumnasObservacionesMensualesVentas.OBSERVACION.ToString()].ToString();
						
				}
			}
			else
			{
				this.txtObservacion.Text = Utilitario.Constantes.VACIO;
				lblResultadoObservaciones.Visible = false;
				lblObservaciones.Visible = false;
			}
		}

		private void dgConsultaMensual_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if (Convert.ToDouble(dr[TOTALCO]) <= Utilitario.Constantes.POSICIONINDEXCERO && 	Convert.ToDouble(dr[PPTO]) <= Utilitario.Constantes.POSICIONINDEXCERO)
				{
					e.Item.Visible = false;
				}
				else
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
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ddlbTipo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//Graba en el Log la acción ejecutada
			
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Observaciones de Venta Real " + this.ddlbTipo.SelectedItem.Text,Enumerados.NivelesErrorLog.I.ToString()));

			this.LlenarDatos();

			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void dgObservaciones_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(dgObservaciones.CurrentPageIndex,dgObservaciones.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}

		private void dgObservaciones_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgObservaciones.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}
	}
}