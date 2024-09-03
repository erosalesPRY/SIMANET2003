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
	public class ConsultarVentasLiquidadas : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblTituloCabecera;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlTable tblCabecera;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblLN;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden ESTADO;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.HtmlControls.HtmlTextArea campo1;
		protected System.Web.UI.WebControls.Label lblPantalla;
		protected System.Web.UI.WebControls.ImageButton ibtnAbrir;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrden;
		protected System.Web.UI.WebControls.Button btnDir;
		protected System.Web.UI.WebControls.Button btnInd;
		protected System.Web.UI.WebControls.Button btnTot;
		#endregion

		#region Constantes
		private const string URLDETALLEXCEL="ExportarConsultarVentasLiquidadas.aspx";
		private const string URLDETALLE="ConsultarCostosdeProduccionDirectos.aspx?";
		private const string URLDETALLEGASTOSINDIRECTOS="ConsultarCostosdeProduccionIndirectos.aspx?";
		private const string URLDETALLELINEASERVICIO="ConsultarCostosdeProduccionDirectosDetalle.aspx?";
		private const string GRILLAVACIA="No existen registros";
		private const string MENSAJECONSULTAR="Se consulto el Detalle de Cuentas por Provisionar/Liquidar";
		private const string KEYID="KEYID";
		private const string KEYIDPERIODO="KEYIDPERIODO";
		private const string KEYIDPERIODOFILTRO="KEYIDPERIODOFILTRO";
		private const string KEYIDMES="KEYIDMES";
		private const string KEYCONCEPTO="KEYCONCEPTO";
		private const string KEYTIPOCLIENTE ="TipoCliente";
		private const string KEYMATSERMOB="KEYMATSERMOB";
		const string KEYTIPOCOSTO ="KEYTIPOCOSTO";

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
		const string KEYTIPOCLIENTEPMGP="KEYTIPOCLIENTEPMGP";
		const string URLPAGINAADMINISTRACIONORBSERVACION="DetalleAdministrarObservacionesEstadosFinancieros.aspx?";
		const string KEYQIDTIPOPROYECTOLIQUIDAR="KEYQIDTIPOPROYECTOLIQUIDAR";
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
					Helper.ReiniciarSession();
					this.LlenarDatos();
					
					this.ConfigurarAccesoControles();
					if ( Session["orden"] == null)
						Session["orden"] = hGridSort.Value;
					if ( Session["pagina"] == null)
						Session["pagina"] = hGridPagina.Value;

					this.LlenarGrillaOrdenamientoPaginacion(Session["orden"].ToString(), Convert.ToInt32(Session["pagina"].ToString()));
					this.LlenarJScript();
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.btnInd.Click += new System.EventHandler(this.btnInd_Click);
			this.btnTot.Click += new System.EventHandler(this.btnTot_Click);
			this.btnDir.Click += new System.EventHandler(this.btnDir_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarVentasLiquidadas.LlenarGrilla implementation
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
						Convert.ToInt32(Page.Request.QueryString[KEYQIDRUBRO]),
						Convert.ToInt32(Page.Request.QueryString[KEYIDPERIODOFILTRO]));
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
						Convert.ToInt32(Page.Request.QueryString[KEYQIDRUBRO]),
						Convert.ToInt32(Page.Request.QueryString[KEYIDPERIODOFILTRO]));
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
							Convert.ToInt32(Page.Request.QueryString[KEYQIDRUBRO]),
							Convert.ToInt32(Page.Request.QueryString[KEYIDPERIODOFILTRO]),
							Page.Request.QueryString[KEYTIPOCLIENTEPMGP].ToString());

						
					}
					else
					{
						return oCProyectosPorLiquidarProvisionar.ConsultarProyectosLiquidadosPorLineayCentroOperativo
							(Page.Request.QueryString[KEYIDCENTRO],
							Page.Request.QueryString[KEYLN],
							Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO]),
							Convert.ToInt32(Page.Request.QueryString[KEYIDPERIODO]),
							Convert.ToInt32(Page.Request.QueryString[KEYIDMES]),
							Convert.ToInt32(Page.Request.QueryString[KEYQIDRUBRO]),
							Convert.ToInt32(Page.Request.QueryString[KEYIDPERIODOFILTRO]),
							Page.Request.QueryString[KEYTIPOCLIENTEPMGP].ToString());
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
			DataTable dt =  ObtenerDatos();
			
			if(dt!=null)
			{
				DataView dw1 = dt.DefaultView;
				dw1.Sort = columnaOrdenar ;
				dw1.RowFilter = Helper.ObtenerFiltro(this);

				DataTable dt1 = Helper.DataViewTODataTable(dw1);

				DataView dw = dt1.DefaultView;
				this.Totalizar(dw);

				if(dw.Count>0)
				{
					Session[Constantes.EXPORTARDATOSEXCEL]=dt;
					grid.CurrentPageIndex = indicePagina;
					grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla(5,12,18);
					if(Convert.ToInt32(Session[Utilitario.Constantes.KEYQOBSERVACION])==1)
					{
						grid.Columns[11].Visible=true;
						
					}
					grid.DataSource = dw;
					grid.Columns[2].FooterText = dw.Count.ToString() + " de " + dt.Rows.Count.ToString();;

					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch(Exception oe)	
			{
				string a=oe.Message;
				grid.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarVentasLiquidadas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblLN.Text = Page.Request.QueryString[KEYCONCEPTO].ToString();
			lblPeriodo.Text = Page.Request.QueryString[KEYIDPERIODO].ToString();
			lblMes.Text = Helper.ObtenerNombreMes(Convert.ToInt32(Page.Request.QueryString[KEYIDMES].ToString()),SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();

			if(Page.Request.QueryString[KEYIDLIQUIDADO]!=null)
			{
				lblPantalla.Text = PROYECTOSPORLIQUIDAR;

				Label3.Visible=false;
				lblPeriodo.Visible=false;
				Label2.Visible=false;
				lblMes.Visible=false;
			}
		}

		public void LlenarJScript()
		{
			if(((DataTable)Session[Constantes.EXPORTARDATOSEXCEL])!=null)
				ibtnAbrir.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.PopupBusqueda(URLDETALLEXCEL,780,640));
			else
				ltlMensaje.Text = Helper.MensajeAlert("No existen datos a exportar");
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
				if(Page.Request.QueryString[KEYIDLIQUIDADO]==null)
				{
					if (Convert.ToInt32(Page.Request.QueryString[KEYID].ToString())==7 )
						e.Item.Cells[1].Text = "NRO DOC";
				}

				this.EtiquetaCabecera ( e, 5, "VAL", "Valorización");

				this.EtiquetaCabecera ( e, LBLTITDIRECTOS, "DIR (%)", "Costo Directo (%)", "btnDir");
				this.EtiquetaCabecera ( e, LBLTITINDIRECTOS, "IND (%)", "Costo Indirecto (%)", "btnInd");
				this.EtiquetaCabecera ( e, LBLTITTOTAL, "TOTAL", "Costo Total", "btnTot");

				this.EtiquetaCabecera ( e,  7,  "DIF", "Diferencia entre Valorización y Costo de Producción");
				this.EtiquetaCabecera ( e,  8, "FACT", "Total Facturado");
				this.EtiquetaCabecera ( e,  9,  "RES", "Resultado:Facturado (Venta) menos Costo de Producción");
				this.EtiquetaCabecera ( e, 10,    "%", "Porcentaje de Utilidad");
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if (Page.Request.QueryString[KEYIDCENTRO].ToString()== Utilitario.Constantes.SIMAPERU.ToString())
					e.Item.Cells[1].ToolTip = dr["DESCRIPCION"].ToString();

				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				
				if(Convert.ToInt32(Session[Utilitario.Constantes.KEYQOBSERVACION])==1)
				{
					
					e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
					e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;

					string modoPagina="";
					if(dr["observacion"].ToString()==String.Empty)
					{
						modoPagina =Enumerados.ModoPagina.N.ToString();
					}
					else
					{
						modoPagina =Enumerados.ModoPagina.M.ToString();
					}
					string tipoRegistroProyecto;
					if(Session["PROYECTOPORLIQUIDAR"]!=null)
							tipoRegistroProyecto="1";
					else
							tipoRegistroProyecto="0";

					string parametros =KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDFORMATO].ToString() +
						Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDCENTRO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDFECHA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDMES].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDPERIODO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYID + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYID].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDRUBRO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYLN + Utilitario.Constantes.SIGNOIGUAL + dr["ln"].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQOT + Utilitario.Constantes.SIGNOIGUAL + dr["ot"].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL 
						+ modoPagina
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDOBSERVACION + Utilitario.Constantes.SIGNOIGUAL + dr["idobservacion"].ToString()+
						 Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDTIPOPROYECTOLIQUIDAR + Utilitario.Constantes.SIGNOIGUAL + tipoRegistroProyecto;


					e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLPAGINAADMINISTRACIONORBSERVACION + parametros,600,400));
				}

				this.ColocarValor (e, dr,  5, "VALORIZACION");
				if(Page.Request.QueryString[KEYIDLIQUIDADO]==null)
				{
					if (Convert.ToInt32(Page.Request.QueryString[KEYID].ToString())!=7 )
						this.ColocarValoryURLDetalle ( URLDETALLE, e, dr, LBLDIRECTOS, "GASTOSDIRECTOS", "TOTAL" );
					else
						this.ColocarValoryPorcentaje ( e, dr, LBLDIRECTOS, "GASTOSDIRECTOS", "TOTAL" );
				}
				else
				{
					this.ColocarValoryURLDetalle ( URLDETALLE, e, dr, LBLDIRECTOS, "GASTOSDIRECTOS", "TOTAL" );
				}

				//this.ColocarValoryPorcentaje ( e, dr, LBLINDIRECTOS, "GASTOSINDIRECTOS", "TOTAL" );

				this.ColocarValoryURLDetalle(URLDETALLEGASTOSINDIRECTOS, e, dr, LBLINDIRECTOS, "GASTOSINDIRECTOS", "TOTAL" );

				this.ColocarValor ( e, dr, LBLTOTAL,"TOTAL");

				this.ColocarValor ( e, dr,  7, "DIFERENCIA");
				this.ColocarValor ( e, dr,  8, "FACTURADO" );

				this.ColocarValor ( e, dr,  9, "COBRADO"   );
				ColocarPorcentaje ( e, dr, 10, "COBRADO", "FACTURADO" );


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
				this.EtiquetaTotales ( e, 5, TotValorizacion );

				this.EtiquetaTotalesyPorcentaje ( e, LBLSUMDIRECTOS, TotGastoDirecto, TotGastoTotal );
				this.EtiquetaTotalesyPorcentaje ( e, LBLSUMINDIRECTOS, TotGastoIndirecto, TotGastoTotal );
				this.EtiquetaTotales ( e, LBLSUMTOTAL, TotGastoTotal );

				this.EtiquetaTotales ( e, 7, TotDiferencia );
				this.EtiquetaTotales ( e, 8, TotFacturado );
				this.EtiquetaTotales ( e, 9, TotCobrado );
				this.EtiquetaTotalesenPorcentaje ( e, 10, (TotFacturado!=0 ? TotCobrado/Math.Abs(TotFacturado)*100 : -100) );
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			Session["pagina"] = e.NewPageIndex.ToString();
			grid.CurrentPageIndex = e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Session["orden"].ToString(), e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			Session["orden"] = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(Session["orden"].ToString(), Helper.ObtenerIndicePagina());
		}

		private void Ordenar(string campo)
		{
			Session["orden"] = Helper.GenerarExpresionOrdenamiento(campo);
			this.LlenarGrillaOrdenamientoPaginacion(Session["orden"].ToString(), Helper.ObtenerIndicePagina());
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

		private void ColocarValor(System.Web.UI.WebControls.DataGridItemEventArgs e, DataRow dr, int nrocelda, string Campo)
		{
			e.Item.Cells[nrocelda].Text = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Constantes.SIVERMILES)
				? (Convert.ToDouble(dr[Campo])/Constantes.MILES).ToString(Constantes.FORMATODECIMAL5)
				:Convert.ToDouble(dr[Campo]).ToString(Constantes.FORMATODECIMAL4);

			e.Item.Cells[nrocelda].ToolTip = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Constantes.SIVERMILES)
				? Convert.ToDouble(dr[Campo]).ToString(Constantes.FORMATODECIMAL4)
				:null;
		}

		private void ColocarValoryURL(System.Web.UI.WebControls.DataGridItemEventArgs e, DataRow dr, int nrocelda, string Campo)
		{
			e.Item.Cells[nrocelda].Text = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Constantes.SIVERMILES)
				? (Convert.ToDouble(dr[Campo])/Constantes.MILES).ToString(Constantes.FORMATODECIMAL5)
				:Convert.ToDouble(dr[Campo]).ToString(Constantes.FORMATODECIMAL4);
			e.Item.Cells[nrocelda].Font.Underline = true;
			e.Item.Cells[nrocelda].ForeColor = System.Drawing.Color.Blue;

			e.Item.Cells[nrocelda].Attributes.Add(Constantes.EVENTOCLICK, Constantes.HISTORIALADELANTE + Constantes.POPUPDEESPERA + 
				Helper.MostrarVentana(URLDETALLELINEASERVICIO, 
				KEYMATSERMOB + Constantes.SIGNOIGUAL + "LNOTROSSERVICIOS" + Constantes.SIGNOAMPERSON +
				KEYTIPOCOSTO + Constantes.SIGNOIGUAL + "" + Constantes.SIGNOAMPERSON +
				KEYIDCENTRO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDCENTRO] + Constantes.SIGNOAMPERSON +
				KEYLN + Constantes.SIGNOIGUAL + dr["LN"].ToString() + Constantes.SIGNOAMPERSON +
				KEYCOD_DIV + Constantes.SIGNOIGUAL + dr["COD_DIV"].ToString() + Constantes.SIGNOAMPERSON +
				KEYNRO_VAL + Constantes.SIGNOIGUAL + dr["NRO_VAL"].ToString() + Constantes.SIGNOAMPERSON +
				KEYNRO_OTS + Constantes.SIGNOIGUAL + dr["OT"].ToString() + Constantes.SIGNOAMPERSON +
				KEYFECHA + Constantes.SIGNOIGUAL + dr["FEC_EMS"].ToString() + Constantes.SIGNOAMPERSON +
				KEYCONCEPTO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYCONCEPTO] + Constantes.SIGNOAMPERSON +
				KEYIDPERIODO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDPERIODO] + Constantes.SIGNOAMPERSON +
				KEYIDMES + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDMES] + Constantes.SIGNOAMPERSON +
				KEYCLIENTE + Constantes.SIGNOIGUAL + dr["CLIENTE"].ToString() + Constantes.SIGNOAMPERSON + 
				KEYSERVICIO + Constantes.SIGNOIGUAL + dr["SERVICIO"].ToString()));

			e.Item.Cells[nrocelda].ToolTip = (Session[KEYQNUEVOSSOLES] ==null 
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


		public void ColocarValoryURLDetalle(string pagina, System.Web.UI.WebControls.DataGridItemEventArgs e, DataRow dr, string nombrecontrol, string Campo1, string Campo2)
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

			if(Page.Request.QueryString[KEYIDLIQUIDADO]!=null)
			{
				lbl.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Constantes.HISTORIALADELANTE + Constantes.POPUPDEESPERA + 
					Helper.MostrarVentana(pagina, 
					KEYIDCENTRO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDCENTRO] + Constantes.SIGNOAMPERSON +
					KEYLN+ Constantes.SIGNOIGUAL + dr["LN"].ToString() + Constantes.SIGNOAMPERSON +
					KEYCOD_DIV + Constantes.SIGNOIGUAL + dr["COD_DIV"].ToString() + Constantes.SIGNOAMPERSON +
					KEYNRO_VAL + Constantes.SIGNOIGUAL + dr["NRO_VAL"].ToString() + Constantes.SIGNOAMPERSON +
					KEYNRO_OTS + Constantes.SIGNOIGUAL + dr["OT"].ToString() + Constantes.SIGNOAMPERSON +
					KEYFECHA + Constantes.SIGNOIGUAL + dr["FEC_EMS"].ToString() + Constantes.SIGNOAMPERSON +
					KEYCONCEPTO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYCONCEPTO] + Constantes.SIGNOAMPERSON +
					KEYIDLIQUIDADO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDLIQUIDADO] + Constantes.SIGNOAMPERSON +
					KEYIDPERIODO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDPERIODO] + Constantes.SIGNOAMPERSON +
					KEYIDMES + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDMES] + Constantes.SIGNOAMPERSON +
					KEYCLIENTE + Constantes.SIGNOIGUAL + dr["CLIENTE"].ToString() + Constantes.SIGNOAMPERSON + 
					KEYQIDFORMATO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDFORMATO].ToString() + Constantes.SIGNOAMPERSON + 
					KEYQIDRUBRO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDRUBRO].ToString() + Constantes.SIGNOAMPERSON + 
					KEYSERVICIO + Constantes.SIGNOIGUAL + dr["SERVICIO"].ToString()));
			}
			else
			{
				lbl.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Constantes.HISTORIALADELANTE + Constantes.POPUPDEESPERA + 
					Helper.MostrarVentana(pagina, 
					KEYIDCENTRO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDCENTRO] + Constantes.SIGNOAMPERSON +
					KEYLN+ Constantes.SIGNOIGUAL + dr["LN"].ToString() + Constantes.SIGNOAMPERSON +
					KEYCOD_DIV + Constantes.SIGNOIGUAL + dr["COD_DIV"].ToString() + Constantes.SIGNOAMPERSON +
					KEYNRO_VAL + Constantes.SIGNOIGUAL + dr["NRO_VAL"].ToString() + Constantes.SIGNOAMPERSON +
					KEYNRO_OTS + Constantes.SIGNOIGUAL + dr["OT"].ToString() + Constantes.SIGNOAMPERSON +
					KEYFECHA + Constantes.SIGNOIGUAL + dr["FEC_EMS"].ToString() + Constantes.SIGNOAMPERSON +
					KEYCONCEPTO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYCONCEPTO] + Constantes.SIGNOAMPERSON +
					KEYIDPERIODO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDPERIODO] + Constantes.SIGNOAMPERSON +
					KEYIDMES + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDMES] + Constantes.SIGNOAMPERSON +
					KEYQIDFORMATO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDFORMATO].ToString() + Constantes.SIGNOAMPERSON + 
					KEYQIDRUBRO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDRUBRO].ToString() + Constantes.SIGNOAMPERSON + 
					KEYCLIENTE + Constantes.SIGNOIGUAL + dr["CLIENTE"].ToString() + Constantes.SIGNOAMPERSON + 
					KEYSERVICIO + Constantes.SIGNOIGUAL + dr["SERVICIO"].ToString()));
			}
			lbl.ToolTip = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Constantes.SIVERMILES)
				? Convert.ToDouble(dr[Campo1]).ToString(Constantes.FORMATODECIMAL4)
				: null;
		}

		private void ColocarPorcentaje(System.Web.UI.WebControls.DataGridItemEventArgs e, DataRow dr, 
			int nrocelda, string Campo1, string Campo2)
		{
			if (Convert.ToDouble(dr[Campo2])==0)
			{
				e.Item.Cells[nrocelda].Text = "100";
				e.Item.Cells[nrocelda].ForeColor = System.Drawing.Color.Red;
				e.Item.Cells[nrocelda].ToolTip = "-100";
			}
			else
			{
				if (Convert.ToDouble(dr[Campo1])/Math.Abs(Convert.ToDouble(dr[Campo2])) < 0)
				{
					e.Item.Cells[nrocelda].Text = (((Convert.ToDouble(dr[Campo1])/Math.Abs(Convert.ToDouble(dr[Campo2]))))*-100).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					e.Item.Cells[nrocelda].ForeColor=System.Drawing.Color.Red;
				}
				else
				{
					e.Item.Cells[nrocelda].Text = (((Convert.ToDouble(dr[Campo1])/Convert.ToDouble(dr[Campo2])))*100).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				}

				e.Item.Cells[nrocelda].ToolTip = (Session[KEYQNUEVOSSOLES] ==null 
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

		private void EtiquetaTotales(System.Web.UI.WebControls.DataGridItemEventArgs e, int nrocelda, double Total)
		{
			e.Item.Cells[nrocelda].Font.Size = 8;
			e.Item.Cells[nrocelda].Font.Bold = true;

			e.Item.Cells[nrocelda].Text = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
				? (Total/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
				:Total.ToString(Utilitario.Constantes.FORMATODECIMAL4);

			e.Item.Cells[nrocelda].ToolTip = (Session[KEYQNUEVOSSOLES] ==null 
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


		private void EtiquetaTotalesenPorcentaje(System.Web.UI.WebControls.DataGridItemEventArgs e, int nrocelda, double Total)
		{
			e.Item.Cells[nrocelda].Font.Size = 8;
			e.Item.Cells[nrocelda].Font.Bold = true;
			double TotalOriginal = Total;
			if (Total<0)
			{
				Total = Total*-1;
				e.Item.Cells[nrocelda].ForeColor=System.Drawing.Color.Red;
			}
			e.Item.Cells[nrocelda].Text = Total.ToString(Utilitario.Constantes.FORMATODECIMAL5);
			e.Item.Cells[nrocelda].ToolTip = TotalOriginal.ToString(Utilitario.Constantes.FORMATODECIMAL4);

		}


		private void EtiquetaCabecera(System.Web.UI.WebControls.DataGridItemEventArgs e, string nombrecontrol, string texto, string tooltip, string nombreboton)
		{
			Label lbl;
			lbl = (Label) e.Item.Cells[0].FindControl(nombrecontrol);
			lbl.Font.Bold = true;
			lbl.Font.Underline = true;
			lbl.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
			lbl.Text = texto;
			lbl.ToolTip = tooltip;
			lbl.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, "__doPostBack('"+nombreboton+"','');");
		}

		private void EtiquetaCabecera(System.Web.UI.WebControls.DataGridItemEventArgs e, int nrocelda, string texto, string tooltip)
		{
			e.Item.Cells[nrocelda].ToolTip = tooltip;
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,"OT"
				,"CLIENTE"
				,"SERVICIO"
				,"VALORIZACION"
				,"DIFERENCIA"
				,"FACTURADO"
				,"COBRADO"
				);

		}

		private void btnDir_Click(object sender, System.EventArgs e)
		{
			this.Ordenar("GASTOSDIRECTOS");
		}

		private void btnInd_Click(object sender, System.EventArgs e)
		{
			this.Ordenar("GASTOSINDIRECTOS");
		}

		private void btnTot_Click(object sender, System.EventArgs e)
		{
			this.Ordenar("TOTAL");
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


	}
}
