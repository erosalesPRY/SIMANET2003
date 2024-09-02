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
	public class ConsultarCartasdeCreditoporBanco : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		//const int IDTABLAESTADOCARTAFIANZA=5;
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkBanco";
		const string URLDETALLEPORBANCO="ConsultarCartasdeCreditoporBancoDetalle.aspx?";
		const string URLRESUMENDEBANCOSPORCENTRO="ConsultarCartaCreditoResumendeBancosporCentro.aspx?";
		const string URLPRINCIPAL="../../Default.aspx";

		const string COLORDENAMIENTO = "razonsocial";

		const string KEYIDESTADO = "idEstado";
		const string KEYIDENTIDADFINANCIERA = "idEF";
		const string NOMBREENTIDAD = "Nombre";
		const string KEYIDCENTRO ="IdCentro";
		const string NOMBRECENTRO ="Nombre";

		const string KEYIDTIPOCREDITO = "idTipoCredito";
	

		//URL
		const string URLANTERIOR = "/SimaNetWeb/DirectorioEjecutivo/EstadosFinancieros.aspx";


		const string CAMPO1 = "lblMontoCallaoS";
		const string CAMPO2 = "lblMontoCallaoD";
		const string CAMPO3 = "lblMontoChimboteS";
		const string CAMPO4 = "lblMontoChimboteD";
		const string CAMPO5 = "lblMontoIquitosS";
		const string CAMPO6 = "lblMontoIquitosD";
		const string CAMPO7 = "lblMontoTotalS";
		const string CAMPO8 = "lblMontoTotalD";

		const string TOTALIZA ="Totaliza";
		const string CONTROLHCALLAO = "lblhCallao";
		const string CONTROLHCHIMBOTE ="lblHChimbote";
		const string CONTROLHIQUITOS = "lblHIquitos";

		//Otros
		const string COLUMANIDENTIDADFINANCIERA ="idEntidadFinanciera";
		const string NOMBRECLASEFOOTERGRILLA ="FooterGrilla";

		const string MSGVERDTSC ="Ver detalle Sima callao";
		const string MSGVERDTSCH ="Ver detalle Sima Chimbote";
		const string MSGVERDTSI ="Ver detalle Sima Iquitos";

		const string VARIABLETIPOCC ="finTCC";
		const string VARIABLESITUACIONCC = "finSCC";

		#endregion
		#region Variables			

		private ASPNetDatagridDecorator m_add = new ASPNetDatagridDecorator();
		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlbModalidadCartaCredito;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCentro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
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
					this.LlenarCombos();
					//this.ColspanRowspanHeader();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
					//this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Convert.ToInt32(this.hGridPagina.Value));
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
		private void ColspanRowspanHeader()
		{
			TableCell cell = null;
			m_add.DatagridToDecorate = grid;
			ArrayList header = new ArrayList();


			cell = new TableCell();
			cell.Text = "NRO";
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = "BANCOS";
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = "CANT";
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			
			cell = new TableCell();
			cell.Text = "MONTOS DOLARIZADOS";
			cell.ColumnSpan = 4;
			cell.HorizontalAlign = HorizontalAlign.Center;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			m_add.AddMergeHeader(header);
			
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
			// TODO:  Add ConsultarCartasdeCreditoporBanco.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCartasdeCreditoporBanco.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
				CCartaCredito oCCartaCredito = new CCartaCredito();
				//DataTable dtGeneral =oCCartaCredito.ConsultarCartadeCreditoPorBanco(Utilitario.Constantes.IDESTADODEFAULT);
				DataTable dtGeneral = oCCartaCredito.ConsultarCartadeCreditoPorBanco(Convert.ToInt32(this.ddlbSituacion.SelectedValue), 
																					Convert.ToInt32(this.ddlbModalidadCartaCredito.SelectedValue));

			if(dtGeneral != null)
			{
				DataColumn clT;
				clT = new DataColumn("totalsoles", typeof(double),"Callaosoles + ChimboteSoles + IquitosSoles");
				dtGeneral.Columns.Add(clT);
				clT = new DataColumn("totaldolar", System.Type.GetType("System.Double"),"Callaodolar + Chimbotedolar + Iquitosdolar");
				dtGeneral.Columns.Add(clT);
			}
			return dtGeneral;
		}
		private void Totalizar(DataTable dtOrigen)
		{
			if (dtOrigen !=null)
			{
				ArrayList arrTotal = new ArrayList();
				double []TotalCallaoS = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaCartaCreditoResumen.callaosoles.ToString());
				arrTotal.Add(TotalCallaoS[0]);
				double []TotalCallaoD = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaCartaCreditoResumen.callaodolar.ToString());
				arrTotal.Add(TotalCallaoD[0]);
				double []TotalChimboteS = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaCartaCreditoResumen.chimbotesoles.ToString());
				arrTotal.Add(TotalChimboteS[0]);
				double []TotalChimboteD = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaCartaCreditoResumen.chimbotedolar.ToString());
				arrTotal.Add(TotalChimboteD[0]);
				double []TotalIquitosS = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaCartaCreditoResumen.iquitossoles.ToString());
				arrTotal.Add(TotalIquitosS[0]);
				double []TotalIquitosD = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaCartaCreditoResumen.iquitosdolar.ToString());
				arrTotal.Add(TotalIquitosD[0]);
				double []TotalTotalS = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaCartaCreditoResumen.totalsoles.ToString());
				arrTotal.Add(TotalTotalS[0]);
				double []TotalTotalD = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaCartaCreditoResumen.totaldolar.ToString());
				arrTotal.Add(TotalTotalD[0]);
				//object [] rowTotaliza = {999,"TOTAL GENERAL",TotalCallaoS[0],TotalCallaoD[0],TotalChimboteS[0],TotalChimboteD[0],TotalIquitosS[0],TotalIquitosD[0],TotalTotalS[0],TotalTotalD[0]};
				//arrTotal.Add(rowTotaliza[0]);
				Session[TOTALIZA] = arrTotal;
			}
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				this.Totalizar(dtGeneral);
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.Sort = columnaOrdenar ;
				dwGeneral.RowFilter = Helper.ObtenerFiltro();
				grid.DataSource = dwGeneral;
				grid.CurrentPageIndex = indicePagina;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + " " + dwGeneral.Count.ToString();

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
			// TODO:  Add ConsultarCartasdeCreditoporBanco.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarCartasdeCreditoporBanco.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCartasdeCreditoporBanco.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarCartasdeCreditoporBanco.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCartasdeCreditoporBanco.Exportar implementation
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
			// TODO:  Add ConsultarCartasdeCreditoporBanco.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			#region Header
			if(e.Item.ItemType == ListItemType.Header)
			{
				//SIMA CALLAO
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[2].FindControl(CONTROLHCALLAO),MSGVERDTSC,
						Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
						Helper.MostrarVentana(URLRESUMENDEBANCOSPORCENTRO,KEYIDCENTRO +  Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCALLAO
																									+ Utilitario.Constantes.SIGNOAMPERSON
																									+ KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbSituacion.SelectedValue.ToString() /*Utilitario.Constantes.IDESTADODEFAULT*/
																									+ Utilitario.Constantes.SIGNOAMPERSON
																									+ KEYIDTIPOCREDITO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbModalidadCartaCredito.SelectedValue.ToString()
																									+ Utilitario.Constantes.SIGNOAMPERSON 	
																									+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCALLAO
																									+ Utilitario.Constantes.SIGNOAMPERSON 
																									+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
																									));
				//SIMA CHIMBOTE
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[3].FindControl(CONTROLHCHIMBOTE),MSGVERDTSCH,
						Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
						Helper.MostrarVentana(URLRESUMENDEBANCOSPORCENTRO,KEYIDCENTRO +  Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCHIMBOTE
																			+ Utilitario.Constantes.SIGNOAMPERSON
																			+ KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbSituacion.SelectedValue.ToString() /*Utilitario.Constantes.IDESTADODEFAULT*/
																			+ Utilitario.Constantes.SIGNOAMPERSON
																			+ KEYIDTIPOCREDITO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbModalidadCartaCredito.SelectedValue.ToString()
																			+ Utilitario.Constantes.SIGNOAMPERSON
																			+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCHIMBOTE
																			+ Utilitario.Constantes.SIGNOAMPERSON 
																			+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
																			));
				//SIMA IQUITOS
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[4].FindControl(CONTROLHIQUITOS),MSGVERDTSI,
						Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
						Helper.MostrarVentana(URLRESUMENDEBANCOSPORCENTRO,KEYIDCENTRO +  Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROIQUITOS
																			+ Utilitario.Constantes.SIGNOAMPERSON
																			+ KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbSituacion.SelectedValue.ToString() /*Utilitario.Constantes.IDESTADODEFAULT*/
																			+ Utilitario.Constantes.SIGNOAMPERSON
																			+ KEYIDTIPOCREDITO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbModalidadCartaCredito.SelectedValue.ToString()			
																			+ Utilitario.Constantes.SIGNOAMPERSON
																			+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROIQUITOS
																			+ Utilitario.Constantes.SIGNOAMPERSON 
																			+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
																			));




			}			
			#endregion

			#region ITEM
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
					Helper.MostrarVentana(URLDETALLEPORBANCO,
															KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMANIDENTIDADFINANCIERA].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON 
															+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[1].Text
															+ Utilitario.Constantes.SIGNOAMPERSON 
															+ KEYIDESTADO  + Utilitario.Constantes.SIGNOIGUAL +  this.ddlbSituacion.SelectedValue.ToString() /*Utilitario.Constantes.IDESTADODEFAULT*/
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYIDTIPOCREDITO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbModalidadCartaCredito.SelectedValue.ToString()			
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
															));
				
				
				

				((Label)e.Item.Cells[2].FindControl(CAMPO1)).Text=Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.callaosoles.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[2].FindControl(CAMPO2)).Text=Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.callaodolar.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				

				((Label)e.Item.Cells[3].FindControl(CAMPO3)).Text= Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.chimbotesoles.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[3].FindControl(CAMPO4)).Text= Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.chimbotedolar.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				((Label)e.Item.Cells[4].FindControl(CAMPO5)).Text= Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.iquitossoles.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[4].FindControl(CAMPO6)).Text= Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.iquitosdolar.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				((Label)e.Item.Cells[5].FindControl(CAMPO7)).Text= Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.totalsoles.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[5].FindControl(CAMPO8)).Text= Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.totaldolar.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				
			}	
			#endregion

			#region FOOTER
			if (e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[0].ColumnSpan=2;
				e.Item.Cells[0].CssClass = NOMBRECLASEFOOTERGRILLA;
				e.Item.Cells[1].Visible=false;

				ArrayList arrTotal = (ArrayList) Session[TOTALIZA];
				string []NombreControlLbl = {"lblFMontoCallaoS","lblFMontoCallaoD","lblFMontoChimboteS","lblFMontoChimboteD","lblFMontoIquitosS","lblFMontoIquitosD","lblFMontoTotalS","lblFMontoTotalD"};
				int []ColPoslLbl = {2,2,3,3,4,4,5,5};
				for(int i=0;i<=NombreControlLbl.Length-1;i++)
				{
					((Label) e.Item.Cells[ColPoslLbl[i]].FindControl(NombreControlLbl[i].ToString())).Text=Convert.ToDouble(arrTotal[i]).ToString(Utilitario.Constantes.FORMATODECIMAL4);					
				}
				Session[TOTALIZA]=null;
			}
			#endregion
			
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}


		private void RedireccionarPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

		private void ddlbModalidadCartaCredito_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[VARIABLESITUACIONCC] = ddlbSituacion.SelectedIndex;
			Session[VARIABLETIPOCC] = ddlbModalidadCartaCredito.SelectedIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void ddlbSituacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[VARIABLESITUACIONCC] = ddlbSituacion.SelectedIndex;
			Session[VARIABLETIPOCC] = ddlbModalidadCartaCredito.SelectedIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	
		}
	}
}
