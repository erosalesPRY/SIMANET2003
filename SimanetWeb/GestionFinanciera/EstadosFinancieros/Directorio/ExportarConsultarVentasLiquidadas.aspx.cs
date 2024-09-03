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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;


namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio
{
	/// <summary>
	/// Summary description for ConsultarVentasLiquidadas.
	/// </summary>
	public class ExportarConsultarVentasLiquidadas : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.HtmlControls.HtmlTextArea campo1;
		protected System.Web.UI.WebControls.ImageButton ibtnAbrir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region Constantes
		private const string GRILLAVACIA="No existen registros";
		private const string MENSAJECONSULTAR="Se consulto el Detalle de Cuentas por Provisionar/Liquidar";
		private const string KEYID="KEYID";
		private const string KEYIDPERIODO="KEYIDPERIODO";
		private const string KEYIDMES="KEYIDMES";
		private const string KEYCONCEPTO="KEYCONCEPTO";
		private const string KEYTIPOCLIENTE ="TipoCliente";

		private const string PROYECTOSPORLIQUIDAR ="PROYECTOS POR LIQUIDAR";

		const string KEYIDCENTRO ="IdCentro";
		const string KEYIDCENTROOPERATIVO ="IdCentroOperativo";
		const string KEYQFLAGDIRECTORIO= "FlagDirectorio";
		const string KEYLN ="LN";
		const string KEYQOT ="OT";
		const string KEYCOD_DIV = "KEYCOD_DIV";
		const string KEYNRO_VAL = "NRO_VAL";
		const string KEYNRO_OTS = "NRO_OTS";
		const string KEYCLIENTE = "KEYCLIENTE";
		const string KEYSERVICIO = "KEYSERVICIO";
		const string KEYFECHA = "KEYFECHA";
		const string ALERTA = "../../../imagenes/alert.gif";
		const string CONTROLIMGBUTTON = "imgCaducidad";
		const string KEYQIDOBSERVACION="IdObservacion";
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQIDFECHA = "efFecha";
		const string  KEYQPERIODO = "periodo";

		//********
		//Para Proyecto Liquidado
		private const string KEYIDLIQUIDADO="IdProyectoLiquidado";
		//********

		const string KEYQNUEVOSSOLES = "MILNS";

		#region Label Item
		const string LBLTITVALORIZACION = "lblTituloVal";
		const string LBLTITDIFERENCIA   = "lblTituloDiferencia";
		const string LBLTITFACTURADO    = "lblTituloFacturado";
		const string LBLTITRESULTADO    = "lblTituloResultado";
		const string LBLTITPORCENTAJE   = "lblTituloPorcentaje";


		const string LBLVALORIZACION = "lblValorizacion";
		const string LBLDIFERENCIA   = "lblDiferencia";
		const string LBLFACTURADO    = "lblFacturado";
		const string LBLRESULTADO    = "lblResult";
		const string LBLPORCENTAJE   = "lblPorcentaje";

		const string LBLTITDIRECTOS   = "lblDir";
		const string LBLTITINDIRECTOS = "lblInd";
		const string LBLTITTOTAL      = "lblCostoTotal";

		const string LBLDIRECTOS     = "lblDirectos";
		const string LBLINDIRECTOS   = "lblIndirectos";
		const string LBLTOTAL        = "lblTotal";

		const string LBLSUMDIRECTOS   = "lblSumGDirectos";
		const string LBLSUMINDIRECTOS = "lblSumGIndirectos";
		const string LBLSUMTOTAL      = "lblSumGTotal";

		const string LBLSUMVALORIZACION = "lblSumValorizacion";
		const string LBLSUMDIFERENCIA   = "lblSumDiferencia";
		const string LBLSUMFACTURADO    = "lblSumFacturado";
		const string LBLSUMRESULTADO    = "lblSumResult";
		const string LBLSUMPORCENTAJE    = "lblSumPorc";

		#endregion

		#endregion

		#region Variables
		double TotValorizacion;
		double TotGastoDirecto;
		double TotGastoIndirecto;
		double TotGastoTotal;
		double TotDiferencia;
		double TotFacturado;
		double TotCobrado;

		#endregion

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarGrilla();

					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestionFinanciera.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));			
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
			this.ibtnAbrir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAbrir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			if(((DataTable)Session[Constantes.EXPORTARDATOSEXCEL])!=null)
			{
				this.Totalizar(((DataTable)Session[Constantes.EXPORTARDATOSEXCEL]).DefaultView);				
				grid.DataSource=((DataTable)Session[Constantes.EXPORTARDATOSEXCEL]);
				grid.Columns[2].FooterText=((DataTable)Session[Constantes.EXPORTARDATOSEXCEL]).Rows.Count.ToString();

				try
				{
					grid.DataBind();
				}
				catch	
				{
					grid.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
					grid.DataBind();
				}
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarVentasLiquidadas.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			if(Page.Request.QueryString[KEYTIPOCLIENTE]!=null)
			{
				CProyectosPorLiquidarProvisionar oCProyectosPorLiquidarProvisionar = new CProyectosPorLiquidarProvisionar();

				if(Convert.ToInt32(Page.Request.QueryString[KEYQFLAGDIRECTORIO]) == Constantes.POSICIONINDEXUNO)
				{
					return oCProyectosPorLiquidarProvisionar.ConsultarProyectosLiquidadosPorLinea_CentroOperativo_TipoClienteAlCierre(
						Convert.ToInt32(Page.Request.QueryString[KEYIDCENTRO]),
						Page.Request.QueryString[KEYLN],
						Page.Request.QueryString[KEYTIPOCLIENTE],
						Convert.ToDateTime(Page.Request.QueryString[KEYQIDFECHA]),
						Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO]),
						Convert.ToInt32(Page.Request.QueryString[KEYIDPERIODO]),
						Convert.ToInt32(Page.Request.QueryString[KEYIDMES]),
						Convert.ToInt32(Page.Request.QueryString[KEYQIDRUBRO]),2007);
				}
				else
				{
					return oCProyectosPorLiquidarProvisionar.ConsultarProyectosLiquidadosPorLinea_CentroOperativo_TipoCliente(
						Convert.ToInt32(Page.Request.QueryString[KEYIDCENTRO]),
						Page.Request.QueryString[KEYLN],
						Page.Request.QueryString[KEYTIPOCLIENTE],
						Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO]),
						Convert.ToInt32(Page.Request.QueryString[KEYIDPERIODO]),
						Convert.ToInt32(Page.Request.QueryString[KEYIDMES]),
						Convert.ToInt32(Page.Request.QueryString[KEYQIDRUBRO]),2007);
				}
			}
			else
			{
				if(Page.Request.QueryString[KEYIDLIQUIDADO]!=null)
				{
					CProyectosPorLiquidarProvisionar oCProyectosPorLiquidarProvisionar = new CProyectosPorLiquidarProvisionar();

					if(Convert.ToInt32(Page.Request.QueryString[KEYQFLAGDIRECTORIO])==Constantes.POSICIONINDEXUNO)
					{
						return oCProyectosPorLiquidarProvisionar.ConsultarProyectosLiquidadosPorLineayCentroOperativoAlCierre
							(Page.Request.QueryString[KEYIDCENTRO],
							Page.Request.QueryString[KEYLN],
							Convert.ToDateTime(Page.Request.QueryString[KEYQIDFECHA]),
							Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO]),
							Convert.ToInt32(Page.Request.QueryString[KEYIDPERIODO]),
							Convert.ToInt32(Page.Request.QueryString[KEYIDMES]),
							Convert.ToInt32(Page.Request.QueryString[KEYQIDRUBRO]),2007,"" );
					}
					else
					{
						return oCProyectosPorLiquidarProvisionar.ConsultarProyectosLiquidadosPorLineayCentroOperativo
							(Page.Request.QueryString[KEYIDCENTRO],
							Page.Request.QueryString[KEYLN],
							Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO]),
							Convert.ToInt32(Page.Request.QueryString[KEYIDPERIODO]),
							Convert.ToInt32(Page.Request.QueryString[KEYIDMES]),
							Convert.ToInt32(Page.Request.QueryString[KEYQIDRUBRO]),2007,"");
					}
				}
				else
				{
					CEstadosFinancieros oCEstadosFinancieros = new CEstadosFinancieros();
					return oCEstadosFinancieros.ConsultarVentasLiquidadas
						(Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]),
						Convert.ToInt32(Page.Request.QueryString[KEYID]), 
						Convert.ToInt32(Page.Request.QueryString[KEYIDPERIODO]),
						Convert.ToInt32(Page.Request.QueryString[KEYIDMES]),
						Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO]),
						Convert.ToInt32(Page.Request.QueryString[KEYQIDRUBRO]));
				}

			}
		}

		public void Totalizar (DataView dwTotales)
		{
			if (dwTotales != null)
			{
				double [] aArreglo = Helper.TotalizarDataView(dwTotales,"VALORIZACION");
				TotValorizacion = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"GASTOSDIRECTOS");
				TotGastoDirecto = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"GASTOSINDIRECTOS");
				TotGastoIndirecto = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"TOTAL");
				TotGastoTotal = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"DIFERENCIA");
				TotDiferencia= aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"FACTURADO");
				TotFacturado = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"COBRADO");
				TotCobrado = aArreglo[0];

			}
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarVentasLiquidadas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarVentasLiquidadas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarVentasLiquidadas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarVentasLiquidadas.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			//			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			//			{
			//				CNetAccessControl.LoadControls(this);
			//			}
			//			else
			//			{
			//				CNetAccessControl.RedirectPageError();
			//			}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarVentasLiquidadas.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				this.EtiquetaCabecera ( e, LBLTITVALORIZACION, "VAL", "Valorización");
				this.EtiquetaCabecera ( e, LBLTITDIFERENCIA  , "DIF", "Diferencia entre Valorización y Costo de Producción");
				this.EtiquetaCabecera ( e, LBLTITFACTURADO, "FACT", "Total Facturado");
				this.EtiquetaCabecera ( e, LBLTITRESULTADO, "RES", "Resultado:Facturado (Venta) menos Costo de Producción");
				this.EtiquetaCabecera ( e, LBLTITPORCENTAJE, "%", "Porcentaje de Utilidad");

				this.EtiquetaCabecera ( e, LBLTITDIRECTOS, "DIR (%)", "Costo Directo (%)");
				this.EtiquetaCabecera ( e, LBLTITINDIRECTOS, "IND (%)", "Costo Indirecto (%)");
				this.EtiquetaCabecera ( e, LBLTITTOTAL, "TOTAL", "Costo Total");
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;


				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				
				this.ColocarValor(e,dr,LBLVALORIZACION,"VALORIZACION");

				this.ColocarValoryURLDetalle ( e, dr, LBLDIRECTOS, "GASTOSDIRECTOS", "TOTAL" );
				this.ColocarValoryPorcentaje ( e, dr, LBLINDIRECTOS, "GASTOSINDIRECTOS", "TOTAL" );
				this.ColocarValor ( e, dr, LBLTOTAL,"TOTAL");

				this.ColocarValor ( e, dr, LBLDIFERENCIA, "DIFERENCIA" );
				this.ColocarValor ( e, dr, LBLFACTURADO, "FACTURADO" );
				this.ColocarValor ( e, dr, LBLRESULTADO, "COBRADO" );

				this.ColocarPorcentaje ( e, dr, LBLPORCENTAJE, "COBRADO", "FACTURADO" );
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("campo1",dr["observacion"].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				if(Convert.ToInt32(Session["OBSERVACION"])==1)
					
				{
					System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[11].FindControl(CONTROLIMGBUTTON);	
					if (Convert.ToString(dr["observacion"])== String.Empty)
					{
						ibtn1.ImageUrl = ALERTA;
					}
					else
					{
						ibtn1.Visible = false;
					}
				}

			}

			if(e.Item.ItemType == ListItemType.Footer)
			{
				this.EtiquetaTotales ( e, LBLSUMVALORIZACION, TotValorizacion );
				this.EtiquetaTotalesyPorcentaje ( e, LBLSUMDIRECTOS, TotGastoDirecto, TotGastoTotal );
				this.EtiquetaTotalesyPorcentaje ( e, LBLSUMINDIRECTOS, TotGastoIndirecto, TotGastoTotal );
				this.EtiquetaTotales ( e, LBLSUMTOTAL, TotGastoTotal );
				this.EtiquetaTotales ( e, LBLSUMDIFERENCIA, TotDiferencia );
				this.EtiquetaTotales ( e, LBLSUMFACTURADO, TotFacturado );
				this.EtiquetaTotales ( e, LBLSUMRESULTADO, TotCobrado );
				this.EtiquetaTotalesenPorcentaje ( e, LBLSUMPORCENTAJE, TotCobrado/Math.Abs(TotFacturado)*100 );
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
		}

		private void ColocarValor(System.Web.UI.WebControls.DataGridItemEventArgs e, DataRow dr, string nombrecontrol, string Campo)
		{
			Label lbl;
			lbl = (Label) e.Item.Cells[0].FindControl(nombrecontrol);
			lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Constantes.SIVERMILES)
				? (Convert.ToDouble(dr[Campo])/Constantes.MILES).ToString(Constantes.FORMATODECIMAL5)
				:Convert.ToDouble(dr[Campo]).ToString(Constantes.FORMATODECIMAL4);

			lbl.ToolTip = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Constantes.SIVERMILES)
				? Convert.ToDouble(dr[Campo]).ToString(Constantes.FORMATODECIMAL4)
				:null;
		}

		private void ColocarValoryPorcentaje(System.Web.UI.WebControls.DataGridItemEventArgs e, DataRow dr, string nombrecontrol, string Campo1, string Campo2 )
		{
			Label lbl;
			lbl = (Label) e.Item.Cells[0].FindControl(nombrecontrol);
			lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Constantes.SIVERMILES)
				? (Convert.ToDouble(dr[Campo1])/Constantes.MILES).ToString(Constantes.FORMATODECIMAL5)
				:Convert.ToDouble(dr[Campo1]).ToString(Constantes.FORMATODECIMAL4);

			double porc = new double();
			porc = Convert.ToDouble(dr[Campo1])==0 
				? 0
				: Convert.ToDouble(dr[Campo1])/Convert.ToDouble(dr[Campo2]) * 100;

			lbl.Text = lbl.Text +  " (" + porc.ToString(Constantes.FORMATODECIMAL5)  + " )";

			lbl.ToolTip = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Constantes.SIVERMILES)
				? Convert.ToDouble(dr[Campo1]).ToString(Utilitario.Constantes.FORMATODECIMAL4)
				:null;
		}


		public void ColocarValoryURLDetalle(System.Web.UI.WebControls.DataGridItemEventArgs e, DataRow dr, string nombrecontrol, string Campo1, string Campo2)
		{

			Label lbl;
			lbl = (Label) e.Item.Cells[0].FindControl(nombrecontrol);
			lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Constantes.SIVERMILES)
				? (Convert.ToDouble(dr[Campo1])/Constantes.MILES).ToString(Constantes.FORMATODECIMAL5)
				:Convert.ToDouble(dr[Campo1]).ToString(Constantes.FORMATODECIMAL4);
			
			double porc = new double();
			porc = Convert.ToDouble(dr[Campo1])==0 
				? 0
				: Convert.ToDouble(dr[Campo1])/Convert.ToDouble(dr[Campo2]) * 100;

			lbl.Text = lbl.Text +  " (" + porc.ToString(Constantes.FORMATODECIMAL5)  + " )";

			lbl.Font.Underline = true;
			lbl.ForeColor = System.Drawing.Color.Blue;

			lbl.ToolTip = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Constantes.SIVERMILES)
				? Convert.ToDouble(dr[Campo1]).ToString(Constantes.FORMATODECIMAL4)
				: null;
		}


		private void ColocarPorcentaje(System.Web.UI.WebControls.DataGridItemEventArgs e, DataRow dr, 
			string nombrecontrol, string Campo1, string Campo2)
		{
			Label lbl;
			lbl = (Label) e.Item.Cells[0].FindControl(nombrecontrol);

			if (Convert.ToDouble(dr[Campo2])==0)
			{
				lbl.Text = "100";
				lbl.ForeColor=System.Drawing.Color.Red;
			}
			else
			{
				if (Convert.ToDouble(dr[Campo1])/Math.Abs(Convert.ToDouble(dr[Campo2])) < 0)
				{
					//				lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
					//					|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
					//					? (((Math.Round(Convert.ToDouble(dr[Campo1])/Utilitario.Constantes.MILES)/
					//					Math.Round(Convert.ToDouble(dr[Campo2])/Utilitario.Constantes.MILES)))*-100).ToString(Utilitario.Constantes.FORMATODECIMAL5)
					//					:(((Convert.ToDouble(dr[Campo1])/Convert.ToDouble(dr[Campo2])))*100).ToString(Utilitario.Constantes.FORMATODECIMAL5);

					lbl.Text = (((Convert.ToDouble(dr[Campo1])/Math.Abs(Convert.ToDouble(dr[Campo2]))))*-100).ToString(Utilitario.Constantes.FORMATODECIMAL5);

					lbl.ForeColor=System.Drawing.Color.Red;
				}
				else
				{
					//				lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
					//					|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
					//					? (((Math.Round(Convert.ToDouble(dr[Campo1])/Utilitario.Constantes.MILES)/
					//					Math.Round(Convert.ToDouble(dr[Campo2])/Utilitario.Constantes.MILES)))*100).ToString(Utilitario.Constantes.FORMATODECIMAL5)
					//					:(((Convert.ToDouble(dr[Campo1])/Convert.ToDouble(dr[Campo2])))*100).ToString(Utilitario.Constantes.FORMATODECIMAL5);

					lbl.Text = (((Convert.ToDouble(dr[Campo1])/Convert.ToDouble(dr[Campo2])))*100).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				}

				lbl.ToolTip = (Session[KEYQNUEVOSSOLES] ==null 
					|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
					? (((Convert.ToDouble(dr[Campo1])/Convert.ToDouble(dr[Campo2])))*100).ToString(Utilitario.Constantes.FORMATODECIMAL4)
					: null;
			}
		}

		private void EtiquetaTotales(System.Web.UI.WebControls.DataGridItemEventArgs e, string nombrecontrol, double Total)
		{
			Label lbl;
			lbl = (Label) e.Item.Cells[0].FindControl(nombrecontrol);
			lbl.Font.Size = 8;
			lbl.Font.Bold = true;
			lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
				? (Total/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
				:Total.ToString(Utilitario.Constantes.FORMATODECIMAL4);

			lbl.ToolTip = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
				? Total.ToString(Utilitario.Constantes.FORMATODECIMAL4)
				: null;

		}

		private void EtiquetaTotalesyPorcentaje(System.Web.UI.WebControls.DataGridItemEventArgs e, string nombrecontrol, double Total1, double Total2)
		{
			Label lbl;
			lbl = (Label) e.Item.Cells[0].FindControl(nombrecontrol);
			lbl.Font.Size = 8;
			lbl.Font.Bold = true;
			lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
				? (Total1/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
				:Total1.ToString(Utilitario.Constantes.FORMATODECIMAL4);

			double porc = new double();
			porc = Convert.ToDouble(Total1)==0 
				? 0
				: Total1/Total2 * 100;

			lbl.Text = lbl.Text +  " (" + porc.ToString(Constantes.FORMATODECIMAL5)  + " )";

			lbl.ToolTip = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
				? Total1.ToString(Utilitario.Constantes.FORMATODECIMAL4)
				: null;

		}


		private void EtiquetaTotalesenPorcentaje(System.Web.UI.WebControls.DataGridItemEventArgs e, string nombrecontrol, double Total)
		{
			Label lbl;
			lbl = (Label) e.Item.Cells[0].FindControl(nombrecontrol);
			lbl.Font.Size = 8;
			lbl.Font.Bold = true;
			double TotalOriginal = Total;
			if (Total<0)
			{
				Total = Total*-1;
				lbl.ForeColor=System.Drawing.Color.Red;
			}
			lbl.Text = Total.ToString(Utilitario.Constantes.FORMATODECIMAL5);
			lbl.ToolTip = TotalOriginal.ToString(Utilitario.Constantes.FORMATODECIMAL4);

		}


		private void EtiquetaCabecera(System.Web.UI.WebControls.DataGridItemEventArgs e, string nombrecontrol, string texto, string tooltip)
		{
			Label lbl;
			lbl = (Label) e.Item.Cells[0].FindControl(nombrecontrol);
			lbl.Font.Bold = true;
			lbl.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
			lbl.Text = texto;
			lbl.ToolTip = tooltip;
		}

		private void ibtnAbrir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.GenerarExcelCompleto(this,grid);		
		}

	}
}
