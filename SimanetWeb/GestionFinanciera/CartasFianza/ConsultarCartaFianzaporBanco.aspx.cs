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
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.General;

//using Microsoft.Office.Core;
using Excel= Microsoft.Office.Interop.Excel;




namespace SIMA.SimaNetWeb.GestionFinanciera.CartasFianza
{
	/// <summary>
	/// Summary description for ConsultarCartaFianzaporBanco.
	/// </summary>
	public class ConsultarCartaFianzaporBanco : System.Web.UI.Page,IPaginaBase
	{
		
		#region Constantes
		//QueryString Adicional
		const string KEYIDBENEFICIARIO="KEYIDBENEFICIARIO";

		//const int IDTABLAESTADOCARTAFIANZA=5;
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkBanco";
		/*Parametros de envio*/
		/*bancos*/
		const string KEYIDENTIDADFINANCIERA = "idEF";
		const string KEYIDCENTRO = "idCentro";
		const string NOMBREENTIDAD = "Nombre";
		/*Centros*/
		const string NOMBRECENTRO = "NombreCO";

		/*TipoMoneda*/
		const string KEYQIDTIPOMONEDA = "IdTipoMoneda";
		const string TIPOSOLES = "1";
		const string TIPODOLARES = "2";

		/*Tipo Fianza*/
		const string TIPOFIANZA = "TFianza";
		

		const string KEYIDTIPOFZA = "TipoFza";
		const string KEYESTADOFIANZAP = "EstadoFianzaP";
		const string KEYSUBESTADOFIANZAP = "SubEstadoFianzaP";
		const string KEYESTADOPROY = "EstProy";

		//Paginas
		const string URLDETALLEBANCO="ConsultarCartaFianzaporBancoDetalle.aspx?";
		//const string URLDETALLECENTRO="ConsultarCartaFianzaporCentroDetalle.aspx?";
		const string URLDETALLECENTRO="ConsultarCartaFianzaResumendeBancosporCentro.aspx?";
		const string URLDETALLECENTROBANCOMONTO ="ConsultarCartaFianzaporBancoCentroMonto.aspx?";
		
//		const string URLPRINCIPAL="../../Default.aspx";
		const string COLORDENAMIENTO = "RazonSocial";
		const int PRODEDURENRO = 1;
		
		const string CAMPO1 = "lblMontoCallaoS";
		const string CAMPO2 = "lblMontoCallaoD";
		const string CAMPO3 = "lblMontoChimboteS";
		const string CAMPO4 = "lblMontoChimboteD";
		const string CAMPO5 = "lblMontoIquitosS";
		const string CAMPO6 = "lblMontoIquitosD";
		const string CAMPO7 = "lblMontoTotalS";
		const string CAMPO8 = "lblMontoTotalD";

		const string LBLCALLAO = "lblhCallao";
		const string LBLCHIMBOTE = "lblHChimbote";
		const string LBLIQUITOS = "lblHIquitos";

		//Otros
		const string VARIABLECARTAFIANZA ="finDirCF";
		const string VARIABLEESTADOCF = "finEstCF";
		const string VARIABLESUBESTADOCF = "finSubEstCF";
		const string VARIABLEPROYECTOCF = "ProyCF";
		const string VARIABLEBENEFICIARIOCF = "BENEFCF";

		const string VARIABLETOTALIZA ="Totaliza";
		const string NOMBRECLASEFOOTERGRILLA ="FooterGrilla";

		//Filtro
		const string BANCO ="RazonSocial";

		//Variables QueryString
		const string KEYQMOSTRARTODO = "MostrarTodo";
		const string VALORSI = "SI";
		const string VALORNO = "NO";
		const string KEYQIDUSUARIO = "IdUsuario";


		//Nuevos
		const string COLORDEN = "orden";
		const string COLCODPADRE ="codPadre";
		const string COLDESPADRE ="desPadre";

		const string TEXTOTOTAL = "Total:";
		#endregion

		#region Variables
		string VALOR = String.Empty;
		int cantSubTotal = 0;
		#endregion Variables
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlbModalidadCartaFianza;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.HtmlControls.HtmlGenericControl tblModelo2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbEstadoCartaFianza;
		protected projDataGridWeb.DataGridWeb gridResumen;
		protected System.Web.UI.WebControls.Label lblResultado2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlBeneficiarios;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.WebControls.ImageButton btnProyectos;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList ddlProyecto;
		protected System.Web.UI.WebControls.DropDownList ddlSubEstadoFZA;
		protected System.Web.UI.WebControls.ImageButton imgRptFianzas1;
		protected System.Web.UI.WebControls.ImageButton imgRptFianzas;
	
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion


	
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if(!Page.IsPostBack)
			{
				try
				{
					//Registrar Evento
					//this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);

					
					

					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"CartaFianza",this.ToString(),"Se consultó las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));

					Helper.SeleccionarItemCombos(this);
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,0);
					//Helper.CrearContextMenuPopup(this,grid);
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
					ASPNetUtilitario.MessageBox.Show("Error de Paginación");
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
			this.ddlbModalidadCartaFianza.SelectedIndexChanged += new System.EventHandler(this.ddlbModalidadCartaFianza_SelectedIndexChanged);
			this.ddlbEstadoCartaFianza.SelectedIndexChanged += new System.EventHandler(this.ddlbEstadoCartaFianza_SelectedIndexChanged);
			this.ddlSubEstadoFZA.SelectedIndexChanged += new System.EventHandler(this.ddlSubEstadoFZA_SelectedIndexChanged);
			this.ddlProyecto.SelectedIndexChanged += new System.EventHandler(this.ddlProyecto_SelectedIndexChanged);
			this.ddlBeneficiarios.SelectedIndexChanged += new System.EventHandler(this.ddlBeneficiarios_SelectedIndexChanged);
			this.imgRptFianzas.Click += new System.Web.UI.ImageClickEventHandler(this.imgRptFianzas_Click);
			this.imgRptFianzas1.Click += new System.Web.UI.ImageClickEventHandler(this.imgRptFianzas1_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.btnProyectos.Click += new System.Web.UI.ImageClickEventHandler(this.Imagebutton1_Click);
			this.gridResumen.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridResumen_PageIndexChanged);
			this.gridResumen.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumen_ItemDataBound_1);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarCartaFianzaporBanco.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCartaFianzaporBanco.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			CCartaFianza oCCartaFianza= new CCartaFianza();			
			
			if(ddlBeneficiarios.SelectedValue == Utilitario.Constantes.VALORTODOS)
				return oCCartaFianza.ConsultarCartaFianzaPorBancoPorEstado(Convert.ToInt32(ddlbModalidadCartaFianza.SelectedValue.ToString())
																		,Convert.ToInt32(ddlbEstadoCartaFianza.SelectedValue.ToString())
																		,Convert.ToInt32(ddlSubEstadoFZA.SelectedValue.ToString())
																		,Convert.ToInt32(ddlProyecto.SelectedValue.ToString()));
			else
			{

				return oCCartaFianza.ConsultarCartaFianzaPorBancoPorEstado(Convert.ToInt32(ddlbModalidadCartaFianza.SelectedValue.ToString())
																			,Convert.ToInt32(ddlbEstadoCartaFianza.SelectedValue.ToString())
																			,Convert.ToInt32(ddlSubEstadoFZA.SelectedValue.ToString())
																			,Convert.ToInt32(ddlProyecto.SelectedValue.ToString())
																			,this.ddlBeneficiarios.SelectedValue
																		  );
			}
		}
		private void Totalizar(DataTable dtOrigen)
		{
			if (dtOrigen !=null)
			{
				ArrayList arrTotal = new ArrayList();
				double []TotalCallaoS = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FinColumnaCartaFianzaporBanco.callaosoles.ToString());
				arrTotal.Add(TotalCallaoS[0]);
				double []TotalCallaoD = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FinColumnaCartaFianzaporBanco.callaodolar.ToString());
				arrTotal.Add(TotalCallaoD[0]);
				double []TotalChimboteS = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FinColumnaCartaFianzaporBanco.chimbotesoles.ToString());
				arrTotal.Add(TotalChimboteS[0]);
				double []TotalChimboteD = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FinColumnaCartaFianzaporBanco.chimbotedolar.ToString());
				arrTotal.Add(TotalChimboteD[0]);
				double []TotalIquitosS = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FinColumnaCartaFianzaporBanco.iquitossoles.ToString());
				arrTotal.Add(TotalIquitosS[0]);
				double []TotalIquitosD = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FinColumnaCartaFianzaporBanco.iquitosdolar.ToString());
				arrTotal.Add(TotalIquitosD[0]);
				double []TotalTotalS = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FinColumnaCartaFianzaporBanco.totalsoles.ToString());
				arrTotal.Add(TotalTotalS[0]);
				double []TotalTotalD = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FinColumnaCartaFianzaporBanco.totaldolar.ToString());
				arrTotal.Add(TotalTotalD[0]);
				object [] rowTotaliza = {999,"TOTAL GENERAL",TotalCallaoS[0],TotalCallaoD[0],TotalChimboteS[0],TotalChimboteD[0],TotalIquitosS[0],TotalIquitosD[0],TotalTotalS[0],TotalTotalD[0]};
				arrTotal.Add(rowTotaliza[0]);
				Session[VARIABLETOTALIZA] = arrTotal;
			}
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			
			gridResumen.DataSource=null;
			gridResumen.DataBind();
			if(dtGeneral!=null)
			{
				this.GenerarResumen(dtGeneral);
				this.Totalizar(dtGeneral);

				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.Sort = columnaOrdenar ;
				dwGeneral.RowFilter = Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();
				grid.DataSource = dwGeneral;
				grid.CurrentPageIndex = indicePagina;
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
			catch(Exception e)	
			{
				string a = e.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}			
		}

		public void GenerarResumen(DataTable dtG)
		{
			
			if (dtG !=null)
			{
				ArrayList arrTotal = new ArrayList();
				double []TotalCallaoS = Helper.TotalizarDataView(dtG.DefaultView,"CantCallao");
				arrTotal.Add(TotalCallaoS[0]);
				double []TotalChimboteS = Helper.TotalizarDataView(dtG.DefaultView,"CantChimbote");
				arrTotal.Add(TotalChimboteS[0]);
				double []TotalIquitosS = Helper.TotalizarDataView(dtG.DefaultView,"CantIquitos");
				arrTotal.Add(TotalIquitosS[0]);
				double []TotalTotalS = Helper.TotalizarDataView(dtG.DefaultView,"Cant");
				arrTotal.Add(TotalTotalS[0]);
				
				DataTable dtResumen= new DataTable("Resumen");
				dtResumen.Columns.Add(new DataColumn("Titulo",typeof(String)));
				dtResumen.Columns.Add(new DataColumn("TotC",typeof(Int32)));
				dtResumen.Columns.Add(new DataColumn("TotCh",typeof(Int32)));
				dtResumen.Columns.Add(new DataColumn("TotI",typeof(Int32)));
				dtResumen.Columns.Add(new DataColumn("Total",typeof(Int32)));

				object []orow={"TOTAL",TotalCallaoS[0],TotalChimboteS[0],TotalIquitosS[0],TotalTotalS[0]};
				dtResumen.Rows.Add(orow);

				gridResumen.DataSource = dtResumen;
				gridResumen.DataBind();
				lblResultado2.Visible = false;

			}
			gridResumen.DataBind();
		}

		public void LlenarCombos()
		{
			this.LlenarFianzas();
			this.LlenarEstadoCartaFianza();		
			this.LlenarBeneficiarios();
		}

		public void LlenarBeneficiarios()
		{
			CCartaFianza oCCartaFianza = new CCartaFianza();
			ddlBeneficiarios.DataSource= oCCartaFianza.ConsultarBeneficiariosPorBanco(Convert.ToInt32(ddlbModalidadCartaFianza.SelectedValue.ToString())
				,Convert.ToInt32(ddlbEstadoCartaFianza.SelectedValue.ToString()),Convert.ToInt32(this.ddlSubEstadoFZA.SelectedValue),Convert.ToInt32(this.ddlProyecto.SelectedValue));
			ddlBeneficiarios.DataValueField = "id";
			ddlBeneficiarios.DataTextField = "Beneficiario";
			ddlBeneficiarios.DataBind();

			/*ListItem oListItem=new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.VALORTODOS);
			ddlBeneficiarios.Items.Insert(0,oListItem);*/
			if((Session[VARIABLEBENEFICIARIOCF]!=null)&&(ddlBeneficiarios.Items.Count>0 )){
				ddlBeneficiarios.SelectedIndex = Convert.ToInt32(Session[VARIABLEBENEFICIARIOCF]);
			}
		}

		public void LlenarFianzas()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbModalidadCartaFianza.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.FinancieraModalidaddeFianza));
			ddlbModalidadCartaFianza.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbModalidadCartaFianza.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbModalidadCartaFianza.DataBind();
			if (Session[VARIABLECARTAFIANZA] !=null)
			{
				ddlbModalidadCartaFianza.SelectedIndex = Convert.ToInt32(Session[VARIABLECARTAFIANZA]); 
			}			
			this.ibtnFiltrarSeleccion.Visible=false;
		}


		public void LlenarEstadoCartaFianza()
		{
			ListItem item;
			CCartaFianza oCCartaFianza = new CCartaFianza();
			ddlbEstadoCartaFianza.DataSource = oCCartaFianza.ListarOpcionesCartaFianza();
			ddlbEstadoCartaFianza.DataValueField = COLCODPADRE;
			ddlbEstadoCartaFianza.DataTextField = COLDESPADRE;
			ddlbEstadoCartaFianza.DataBind();
			if(Session[VARIABLEESTADOCF] != null)
			{
				ddlbEstadoCartaFianza.SelectedIndex = Convert.ToInt32(Session[VARIABLEESTADOCF]);
			}
			else
			{
				item=ddlbEstadoCartaFianza.Items.FindByValue("1");
				if(item!=null){item.Selected = true;}
			}

			if(Session[VARIABLEPROYECTOCF]!=null){
				ddlProyecto.SelectedIndex = Convert.ToInt32(Session[VARIABLEPROYECTOCF]);
			}

			CargaSubEstadoFZA();
		}

		public void CargaSubEstadoFZA(){
			ddlSubEstadoFZA.DataSource = (new CCartaFianza()).ListarSubOpcionesCartaFianza(Convert.ToInt32(ddlbEstadoCartaFianza.SelectedValue));
			ddlSubEstadoFZA.DataValueField = "IdSubGrupo";
			ddlSubEstadoFZA.DataTextField = "NombreSubGrupo";
			ddlSubEstadoFZA.DataBind();
		//	ListItem litem;
			if(Session[VARIABLESUBESTADOCF] != null)
			{
				ddlSubEstadoFZA.SelectedIndex = Convert.ToInt32(Session[VARIABLESUBESTADOCF]);
			}
		}
		public void LlenarDatos()
		{
			// TODO:  Add ConsultarCartaFianzaporBanco.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ddlbModalidadCartaFianza.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnChange.ToString(),Utilitario.Constantes.POPUPDEESPERA);

			this.btnProyectos.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(), Utilitario.Constantes.HISTORIALADELANTE + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			this.ddlbEstadoCartaFianza.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnChange.ToString(),Utilitario.Constantes.POPUPDEESPERA);
			this.ddlBeneficiarios.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnChange.ToString(),Utilitario.Constantes.POPUPDEESPERA);

			imgRptFianzas.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","ddlbModalidadCartaFianza","ddlbEstadoCartaFianza","ddlSubEstadoFZA","ddlProyecto","ddlBeneficiarios"));	
			imgRptFianzas1.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","ddlbModalidadCartaFianza","ddlbEstadoCartaFianza","ddlSubEstadoFZA","ddlProyecto","ddlBeneficiarios"));	
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCartaFianzaporBanco.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarCartaFianzaporBanco.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCartaFianzaporBanco.Exportar implementation
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
			// TODO:  Add ConsultarCartaFianzaporBanco.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//e.Item.Cells[0].Style.Add("width","15%");			
			if(e.Item.ItemType == ListItemType.Header)
			{
				#region HEADER
				/*Detalle de Sima Callao*/
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[2].FindControl(LBLCALLAO),"Ver Información de Sima-Callao",
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
					Helper.MostrarVentana(URLDETALLECENTRO,KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCALLAO.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDTIPOFZA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbModalidadCartaFianza.SelectedValue.ToString())
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCALLAO.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbEstadoCartaFianza.SelectedValue.ToString())
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ TIPOFIANZA + Utilitario.Constantes.SIGNOIGUAL + this.ddlbModalidadCartaFianza.SelectedItem.Text
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYSUBESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + this.ddlSubEstadoFZA.SelectedValue.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYESTADOPROY + Utilitario.Constantes.SIGNOIGUAL + ddlProyecto.SelectedValue 
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDBENEFICIARIO + Utilitario.Constantes.SIGNOIGUAL + this.ddlBeneficiarios.SelectedValue ));
				
				/*Detalle de Sima Chimbote*/
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[3].FindControl(LBLCHIMBOTE),"Ver detalle (Sima Chimbote)",
						Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
						Helper.MostrarVentana(URLDETALLECENTRO,KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCHIMBOTE.ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYIDTIPOFZA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbModalidadCartaFianza.SelectedValue.ToString())
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCHIMBOTE.ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbEstadoCartaFianza.SelectedValue.ToString())
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ TIPOFIANZA + Utilitario.Constantes.SIGNOIGUAL + this.ddlbModalidadCartaFianza.SelectedItem.Text
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYSUBESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + this.ddlSubEstadoFZA.SelectedValue.ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYESTADOPROY + Utilitario.Constantes.SIGNOIGUAL + ddlProyecto.SelectedValue
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYIDBENEFICIARIO + Utilitario.Constantes.SIGNOIGUAL + this.ddlBeneficiarios.SelectedValue));

				/*Detalle de Sima Iquitos*/
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[4].FindControl(LBLIQUITOS),"Ver detalle (Sima Iquitos)",
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
					Helper.MostrarVentana(URLDETALLECENTRO,KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROIQUITOS.ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYIDTIPOFZA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbModalidadCartaFianza.SelectedValue.ToString())
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROIQUITOS.ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbEstadoCartaFianza.SelectedValue.ToString())
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ TIPOFIANZA + Utilitario.Constantes.SIGNOIGUAL + this.ddlbModalidadCartaFianza.SelectedItem.Text
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYSUBESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + this.ddlSubEstadoFZA.SelectedValue.ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYESTADOPROY + Utilitario.Constantes.SIGNOIGUAL + ddlProyecto.SelectedValue
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYIDBENEFICIARIO + Utilitario.Constantes.SIGNOIGUAL + this.ddlBeneficiarios.SelectedValue));

				e.Item.Cells[0].ToolTip = "Nombre de Entidad Financiera";
				e.Item.Cells[1].ToolTip = "Cantidad de Documentos Por Banco";
				#endregion

			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				#region ITEM
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				

				((Label)e.Item.Cells[2].FindControl(CAMPO1)).Text=Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.callaosoles.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[2].FindControl(CAMPO2)).Text=Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.callaodolar.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				

				((Label)e.Item.Cells[3].FindControl(CAMPO3)).Text= Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.chimbotesoles.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[3].FindControl(CAMPO4)).Text= Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.chimbotedolar.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				((Label)e.Item.Cells[4].FindControl(CAMPO5)).Text= Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.iquitossoles.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[4].FindControl(CAMPO6)).Text= Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.iquitosdolar.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				((Label)e.Item.Cells[5].FindControl(CAMPO7)).Text= Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.totalsoles.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[5].FindControl(CAMPO8)).Text= Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.totaldolar.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				e.Item.Height=3;
				
				if(Page.Request.Params[KEYQMOSTRARTODO]==null)
				{
					VALOR = VALORNO;
				}
				else
				{
					VALOR = VALORSI;
				}
				
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort",ddlBeneficiarios.ID.ToString())
					+ Helper.MostrarVentana(URLDETALLEBANCO,KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaCartaFianzaporBanco.identidadfinanciera.ToString()])
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYIDTIPOFZA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbModalidadCartaFianza.SelectedValue.ToString())
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[0].Text
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYQMOSTRARTODO + Utilitario.Constantes.SIGNOIGUAL + VALOR
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYQIDUSUARIO + Utilitario.Constantes.SIGNOIGUAL + CNetAccessControl.GetIdUser().ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbEstadoCartaFianza.SelectedValue.ToString())
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ TIPOFIANZA + Utilitario.Constantes.SIGNOIGUAL + this.ddlbModalidadCartaFianza.SelectedItem.Text
															+ Utilitario.Constantes.SIGNOAMPERSON 
															+ KEYIDBENEFICIARIO + Utilitario.Constantes.SIGNOIGUAL + ddlBeneficiarios.SelectedValue
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYSUBESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + this.ddlSubEstadoFZA.SelectedValue.ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYESTADOPROY + Utilitario.Constantes.SIGNOIGUAL + ddlProyecto.SelectedValue
														));
				e.Item.Cells[0].Font.Underline = true;
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;				

				/*Hiperlink SIMA-CALLAO Soles*/
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[2].FindControl(CAMPO1),"Ver Información Soles Sima-Callao",
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort",ddlBeneficiarios.ID.ToString()),
					Helper.MostrarVentana(URLDETALLECENTROBANCOMONTO, KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCALLAO.ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYIDTIPOFZA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbModalidadCartaFianza.SelectedValue.ToString())
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaCartaFianzaporBanco.identidadfinanciera.ToString()])
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaCartaFianzaporBanco.RazonSocial.ToString()])																		
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCALLAO
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQMOSTRARTODO + Utilitario.Constantes.SIGNOIGUAL + VALOR
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQIDUSUARIO + Utilitario.Constantes.SIGNOIGUAL + CNetAccessControl.GetIdUser().ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbEstadoCartaFianza.SelectedValue.ToString())
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ TIPOFIANZA + Utilitario.Constantes.SIGNOIGUAL + this.ddlbModalidadCartaFianza.SelectedItem.Text
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQIDTIPOMONEDA + Utilitario.Constantes.SIGNOIGUAL + TIPOSOLES 
																		+ Utilitario.Constantes.SIGNOAMPERSON 
																		+ KEYIDBENEFICIARIO + Utilitario.Constantes.SIGNOIGUAL + ddlBeneficiarios.SelectedValue
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYSUBESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + this.ddlSubEstadoFZA.SelectedValue.ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYESTADOPROY + Utilitario.Constantes.SIGNOIGUAL + ddlProyecto.SelectedValue
																		));

				((Label)e.Item.Cells[2].FindControl(CAMPO1)).ForeColor = System.Drawing.Color.Blue;
				
				/*Hiperlink SIMA-CALLAO Dolares*/
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[2].FindControl(CAMPO2),"Ver Información Dolares Sima-Callao",
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort",ddlBeneficiarios.ID.ToString()),
					Helper.MostrarVentana(URLDETALLECENTROBANCOMONTO, KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCALLAO.ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYIDTIPOFZA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbModalidadCartaFianza.SelectedValue.ToString())
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaCartaFianzaporBanco.identidadfinanciera.ToString()])
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaCartaFianzaporBanco.RazonSocial.ToString()])																		
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCALLAO
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQMOSTRARTODO + Utilitario.Constantes.SIGNOIGUAL + VALOR
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQIDUSUARIO + Utilitario.Constantes.SIGNOIGUAL + CNetAccessControl.GetIdUser().ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbEstadoCartaFianza.SelectedValue.ToString())
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ TIPOFIANZA + Utilitario.Constantes.SIGNOIGUAL + this.ddlbModalidadCartaFianza.SelectedItem.Text
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQIDTIPOMONEDA + Utilitario.Constantes.SIGNOIGUAL + TIPODOLARES
																		+ Utilitario.Constantes.SIGNOAMPERSON 
																		+ KEYIDBENEFICIARIO + Utilitario.Constantes.SIGNOIGUAL + ddlBeneficiarios.SelectedValue
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYSUBESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + this.ddlSubEstadoFZA.SelectedValue.ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYESTADOPROY + Utilitario.Constantes.SIGNOIGUAL + ddlProyecto.SelectedValue));

				((Label)e.Item.Cells[2].FindControl(CAMPO2)).ForeColor = System.Drawing.Color.Blue;				

				/*Hiperlink SIMA-CHIMBOTE Soles*/
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[3].FindControl(CAMPO3),"Ver Información Soles Sima-Chimbote",
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort",ddlBeneficiarios.ID.ToString()),
					Helper.MostrarVentana(URLDETALLECENTROBANCOMONTO, KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCHIMBOTE.ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYIDTIPOFZA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbModalidadCartaFianza.SelectedValue.ToString())
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaCartaFianzaporBanco.identidadfinanciera.ToString()])
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaCartaFianzaporBanco.RazonSocial.ToString()])																		
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCHIMBOTE
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQMOSTRARTODO + Utilitario.Constantes.SIGNOIGUAL + VALOR
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQIDUSUARIO + Utilitario.Constantes.SIGNOIGUAL + CNetAccessControl.GetIdUser().ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbEstadoCartaFianza.SelectedValue.ToString())
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ TIPOFIANZA + Utilitario.Constantes.SIGNOIGUAL + this.ddlbModalidadCartaFianza.SelectedItem.Text
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQIDTIPOMONEDA + Utilitario.Constantes.SIGNOIGUAL + TIPOSOLES 
																		+ Utilitario.Constantes.SIGNOAMPERSON 
																		+ KEYIDBENEFICIARIO + Utilitario.Constantes.SIGNOIGUAL + ddlBeneficiarios.SelectedValue
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYSUBESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + this.ddlSubEstadoFZA.SelectedValue.ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYESTADOPROY + Utilitario.Constantes.SIGNOIGUAL + ddlProyecto.SelectedValue));

				((Label)e.Item.Cells[3].FindControl(CAMPO3)).ForeColor = System.Drawing.Color.Blue;				

				/*Hiperlink SIMA-CHIMBOTE Dolares*/
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[3].FindControl(CAMPO4),"Ver Información Dolares Sima-Chimbote",
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort",ddlBeneficiarios.ID.ToString()),
					Helper.MostrarVentana(URLDETALLECENTROBANCOMONTO, KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCHIMBOTE.ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYIDTIPOFZA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbModalidadCartaFianza.SelectedValue.ToString())
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaCartaFianzaporBanco.identidadfinanciera.ToString()])
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaCartaFianzaporBanco.RazonSocial.ToString()])																		
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCHIMBOTE
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQMOSTRARTODO + Utilitario.Constantes.SIGNOIGUAL + VALOR
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQIDUSUARIO + Utilitario.Constantes.SIGNOIGUAL + CNetAccessControl.GetIdUser().ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbEstadoCartaFianza.SelectedValue.ToString())
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ TIPOFIANZA + Utilitario.Constantes.SIGNOIGUAL + this.ddlbModalidadCartaFianza.SelectedItem.Text
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQIDTIPOMONEDA + Utilitario.Constantes.SIGNOIGUAL + TIPODOLARES 
																		+ Utilitario.Constantes.SIGNOAMPERSON 
																		+ KEYIDBENEFICIARIO + Utilitario.Constantes.SIGNOIGUAL + ddlBeneficiarios.SelectedValue
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYSUBESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + this.ddlSubEstadoFZA.SelectedValue.ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYESTADOPROY + Utilitario.Constantes.SIGNOIGUAL + ddlProyecto.SelectedValue));

				((Label)e.Item.Cells[3].FindControl(CAMPO4)).ForeColor = System.Drawing.Color.Blue;								

				/*Hiperlink SIMA-IQUITOS Soles*/
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[4].FindControl(CAMPO5),"Ver Información Soles Sima-Iquitos",
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort",ddlBeneficiarios.ID.ToString()),
					Helper.MostrarVentana(URLDETALLECENTROBANCOMONTO, KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROIQUITOS.ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYIDTIPOFZA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbModalidadCartaFianza.SelectedValue.ToString())
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaCartaFianzaporBanco.identidadfinanciera.ToString()])
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaCartaFianzaporBanco.RazonSocial.ToString()])																		
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROIQUITOS
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQMOSTRARTODO + Utilitario.Constantes.SIGNOIGUAL + VALOR
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQIDUSUARIO + Utilitario.Constantes.SIGNOIGUAL + CNetAccessControl.GetIdUser().ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbEstadoCartaFianza.SelectedValue.ToString())
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ TIPOFIANZA + Utilitario.Constantes.SIGNOIGUAL + this.ddlbModalidadCartaFianza.SelectedItem.Text
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQIDTIPOMONEDA + Utilitario.Constantes.SIGNOIGUAL + TIPOSOLES 
																		+ Utilitario.Constantes.SIGNOAMPERSON 
																		+ KEYIDBENEFICIARIO + Utilitario.Constantes.SIGNOIGUAL + ddlBeneficiarios.SelectedValue
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYSUBESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + this.ddlSubEstadoFZA.SelectedValue.ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYESTADOPROY + Utilitario.Constantes.SIGNOIGUAL + ddlProyecto.SelectedValue));

				((Label)e.Item.Cells[4].FindControl(CAMPO5)).ForeColor = System.Drawing.Color.Blue;				

				/*Hiperlink SIMA-IQUITOS Dolares*/
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[4].FindControl(CAMPO6),"Ver Información Dolares Sima-Iquitos",
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort",ddlBeneficiarios.ID.ToString()),
					Helper.MostrarVentana(URLDETALLECENTROBANCOMONTO, KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROIQUITOS.ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYIDTIPOFZA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbModalidadCartaFianza.SelectedValue.ToString())
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaCartaFianzaporBanco.identidadfinanciera.ToString()])
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaCartaFianzaporBanco.RazonSocial.ToString()])																		
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROIQUITOS
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQMOSTRARTODO + Utilitario.Constantes.SIGNOIGUAL + VALOR
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQIDUSUARIO + Utilitario.Constantes.SIGNOIGUAL + CNetAccessControl.GetIdUser().ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbEstadoCartaFianza.SelectedValue.ToString())
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ TIPOFIANZA + Utilitario.Constantes.SIGNOIGUAL + this.ddlbModalidadCartaFianza.SelectedItem.Text
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYQIDTIPOMONEDA + Utilitario.Constantes.SIGNOIGUAL + TIPODOLARES 
																		+ Utilitario.Constantes.SIGNOAMPERSON 
																		+ KEYIDBENEFICIARIO + Utilitario.Constantes.SIGNOIGUAL + ddlBeneficiarios.SelectedValue
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYSUBESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + this.ddlSubEstadoFZA.SelectedValue.ToString()
																		+ Utilitario.Constantes.SIGNOAMPERSON
																		+ KEYESTADOPROY + Utilitario.Constantes.SIGNOIGUAL + ddlProyecto.SelectedValue					));

				((Label)e.Item.Cells[4].FindControl(CAMPO6)).ForeColor = System.Drawing.Color.Blue;				

								
				//Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				e.Item.Cells[0].ToolTip = dr[BANCO].ToString();

				#endregion
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				#region FOOTER
				e.Item.Cells[0].ColumnSpan=2;
				e.Item.Cells[0].CssClass = NOMBRECLASEFOOTERGRILLA;
				e.Item.Cells[1].Visible=false;

				ArrayList arrTotal = (ArrayList) Session[VARIABLETOTALIZA];
				string []NombreControlLbl = {"lblFMontoCallaoS","lblFMontoCallaoD","lblFMontoChimboteS","lblFMontoChimboteD","lblFMontoIquitosS","lblFMontoIquitosD","lblFMontoTotalS","lblFMontoTotalD"};
				int []ColPoslLbl = {2,2,3,3,4,4,5,5};
				for(int i=0;i<=NombreControlLbl.Length-1;i++)
				{
					((Label) e.Item.Cells[ColPoslLbl[i]].FindControl(NombreControlLbl[i].ToString())).Text=Convert.ToDouble(arrTotal[i]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}

				Session[VARIABLETOTALIZA]=null;
				#endregion
			}
		
		}
		private HtmlTable CrearTabla(int NroFilas,string []strData,string Alineado)
		{
			HtmlTable tabla = new HtmlTable();
			HtmlTableRow Fila;
			HtmlTableCell Columna;
			for(int nFila=0;nFila<=NroFilas;nFila++)
			{
				Fila = new HtmlTableRow();
				for(int nCol = 0;nCol<=strData.Length-1;nCol++)
				{
					Columna = new HtmlTableCell();
					Columna.InnerText=strData[nCol].ToString();
					Columna.Align = Alineado;
					Fila.Cells.Add(Columna);
				}
				tabla.Rows.Add(Fila);
			}
			tabla.Width="100%";
			tabla.CellPadding=0;
			tabla.CellSpacing=0;
			return tabla;
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ddlbModalidadCartaFianza_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[VARIABLEPROYECTOCF]=null;
			Session[VARIABLESUBESTADOCF]=null;
			Session[VARIABLEBENEFICIARIOCF]=null;
			Session[VARIABLEESTADOCF]=null;

			this.LlenarEstadoCartaFianza();		
			LlenarBeneficiarios();
			
			Session[VARIABLECARTAFIANZA]=ddlbModalidadCartaFianza.SelectedIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
	}	

		private void ibtnCancela_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}

		private void gridResumen_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Label lbl;
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				HyperLink hlk = (HyperLink)e.Item.Cells[0].FindControl(CONTROLINK);
				hlk.Text = Convert.ToString(dr[Enumerados.FinColumnaCartaFianzaporBanco.razonsocial.ToString()]);

				lbl = (Label)e.Item.Cells[1].FindControl(CAMPO1);
				lbl.Text= Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.callaosoles.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				lbl = (Label)e.Item.Cells[1].FindControl(CAMPO2);
				lbl.Text= Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.callaodolar.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL5);

				lbl = (Label)e.Item.Cells[2].FindControl(CAMPO3);
				lbl.Text= Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.chimbotesoles.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				lbl = (Label)e.Item.Cells[2].FindControl(CAMPO4);
				lbl.Text= Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.chimbotedolar.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL5);


				lbl = (Label)e.Item.Cells[3].FindControl(CAMPO5);
				lbl.Text= Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.iquitossoles.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				lbl = (Label)e.Item.Cells[3].FindControl(CAMPO6);
				lbl.Text= Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.iquitosdolar.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL5);

				lbl = (Label)e.Item.Cells[4].FindControl(CAMPO7);
				lbl.Text= Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.totalsoles.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				lbl = (Label)e.Item.Cells[4].FindControl(CAMPO8);
				lbl.Text= Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.totaldolar.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}			
		}

		private void ibtnFiltar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos(),
															Utilitario.Constantes.SIGNOASTERISCO + BANCO + ";Banco");
		
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);		
		}

		private void ddlbEstadoCartaFianza_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[VARIABLEPROYECTOCF]=null;
			Session[VARIABLESUBESTADOCF]=null;
			Session[VARIABLEBENEFICIARIOCF]=null;
			Session[VARIABLECARTAFIANZA]=ddlbModalidadCartaFianza.SelectedIndex;
			Session[VARIABLEESTADOCF]=ddlbEstadoCartaFianza.SelectedIndex;
			
			CargaSubEstadoFZA();
			LlenarBeneficiarios();
			
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}



		private void gridResumen_ItemDataBound_1(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			/*
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				cantSubTotal +=  Convert.ToInt32(e.Item.Cells[5].Text);
			}

			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[1].Text = TEXTOTOTAL;
				e.Item.Cells[5].Text = cantSubTotal.ToString();
			}*/			
		}

		private void gridResumen_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			//GenerarResumen();
		}

		private void ddlBeneficiarios_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[VARIABLEBENEFICIARIOCF]= this.ddlBeneficiarios.SelectedIndex;
			LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,0);
		}

		private void Imagebutton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ConsultarCartaFianzaporProyecto.aspx");
		}

		private void ddlSubEstadoFZA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[VARIABLEPROYECTOCF]=null;
			Session[VARIABLEBENEFICIARIOCF]=null;

			LlenarBeneficiarios();
			/*Session[VARIABLECARTAFIANZA]=ddlbModalidadCartaFianza.SelectedIndex;
			Session[VARIABLEESTADOCF]=ddlbEstadoCartaFianza.SelectedIndex;*/
			Session[VARIABLESUBESTADOCF]=ddlSubEstadoFZA.SelectedIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void ddlProyecto_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[VARIABLEBENEFICIARIOCF]=null;
			LlenarBeneficiarios();
			//Session[VARIABLECARTAFIANZA]=ddlbModalidadCartaFianza.SelectedIndex;
			//Session[VARIABLEESTADOCF]=ddlbEstadoCartaFianza.SelectedIndex;
			//Session[VARIABLESUBESTADOCF]=ddlSubEstadoFZA.SelectedIndex;
			Session[VARIABLEPROYECTOCF] = ddlProyecto.SelectedIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);

		}

		private void imgRptFianzas1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			#region Carta Fianza Detalle y resumen
				try
				{
					DataTable df = Helper.DataViewTODataTable((new ConsultarCartaFianzaporBancoDetalle()).CargarDatosCF(ddlBeneficiarios.SelectedValue,"0",0,Convert.ToInt32(this.ddlbModalidadCartaFianza.SelectedValue.ToString()),Convert.ToInt32(this.ddlbEstadoCartaFianza.SelectedValue.ToString()),Convert.ToInt32(this.ddlSubEstadoFZA.SelectedValue.ToString()),Convert.ToInt32(ddlProyecto.SelectedValue)).DefaultView);
			
					DataSet dsSrc= new DataSet("Reportes");
					dsSrc.Tables.Add(df);

					DataTable dtt= this.ObtenerDatos();
					string []CGrp = new string[]{"Titulo"};
					string []TGrp = new string[]{"CallaoSoles","CallaoDolar","ChimboteSoles","ChimboteDolar","IquitosSoles","IquitosDolar","TotalSoles","TotalDolar","Cant","CantCallao","CantChimbote","CantIquitos"};

					DataTable dtTot =Helper.Data.GroupBy(dtt,CGrp ,TGrp );
					dtTot.Columns.Add("Orden",System.Type.GetType("System.Int32"));
					dtTot.Columns.Add("RazonSocial",System.Type.GetType("System.String"));

					dtTot.Rows[0]["Orden"]=2;
					dtTot.Rows[0]["RazonSocial"]="TOTAL GENERAL:";
					dtTot.AcceptChanges();

					dtt.ImportRow(dtTot.Rows[0]);
			
					DataView dvTT = dtt.DefaultView;
					dvTT.Sort="Orden asc";

					dsSrc.Tables.Add(Helper.DataViewTODataTable(dvTT));


					Helper.Archivo.GenerarReporteToXls(20,dsSrc);
				}
				catch(Exception ex)
				{
					int i=0; 
					i++;
				}
				#endregion
				
		}

	
		private DataTable rptDetalleFianzas(){
			return (new CCartaFianza()).ConsultarCartaFianzaPorBancoDetalle2("0",0,Convert.ToInt32(this.ddlbModalidadCartaFianza.SelectedValue.ToString()), Convert.ToInt32(this.ddlbEstadoCartaFianza.SelectedValue.ToString()), Convert.ToInt32(this.ddlSubEstadoFZA.SelectedValue), Convert.ToInt32(ddlProyecto.SelectedValue));
		}

		private void imgRptFianzas_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			DataSet ds = new DataSet("sw1");
			#region Carta Fianza Detalle y resumen
			try
			{
				DataTable dt1 =  Helper.DataViewTODataTable((new ConsultarCartaFianzaporBancoDetalle()).CargarDatosCF(ddlBeneficiarios.SelectedValue,"0",0,Convert.ToInt32(this.ddlbModalidadCartaFianza.SelectedValue.ToString()),Convert.ToInt32(this.ddlbEstadoCartaFianza.SelectedValue.ToString()),Convert.ToInt32(this.ddlSubEstadoFZA.SelectedValue.ToString()),Convert.ToInt32(ddlProyecto.SelectedValue)).DefaultView);
				dt1.TableName="FINuspNTADConsultarCartaFzaporBancoporEstado2;1";
				ds.Tables.Add(dt1);

				//Resumen
				DataTable dt2 = Helper.DataViewTODataTable(this.ObtenerDatos().DefaultView);
				if(dt2!=null)
				{
					dt2.TableName="FINuspNTADConsultarCartaFzaporBancoPorEstado;1";
					ds.Tables.Add(dt2);
				}
				Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\OperacionesFinancieras\","ReporteCartaFianzaDetallePorBancoA.rpt",ds,false,false,".pdf");
			}
			catch(Exception ex)
			{
				int i=0; 
				i++;
			}
			#endregion
		}


	}
}
