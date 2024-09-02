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

namespace SIMA.SimaNetWeb.GestionFinanciera.CartasFianza
{
	/// <summary>
	/// Summary description for ConsultarCartaFianzaResumendeBancosporCentro.
	/// </summary>
	public class ConsultarCartaFianzaResumendeBancosporCentro : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes

		const string KEYIDBENEFICIARIO="KEYIDBENEFICIARIO";	

		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkBanco";
		/*Parametros de envio*/
		/*bancos*/
		const string KEYIDENTIDADFINANCIERA = "idEF";
		const string KEYIDCENTRO = "idCentro";
		const string NOMBREENTIDAD = "Nombre";
		const string TIPOFIANZA = "TFianza";//Descripcion de la Modalidad Fza
		const string KEYIDTIPOFZA = "TipoFza";
		const string KEYESTADOFIANZAP = "EstadoFianzaP";
		const string KEYSUBESTADOFIANZAP = "SubEstadoFianzaP";
		const string KEYESTADOPROY = "EstProy";



		const string URLDETALLEBANCO="ConsultarCartaFianzaporBancoDetalle.aspx?";
		const string URLDETALLECENTRO="ConsultarCartaFianzaporCentroDetalle.aspx?";
		const string COLORDENAMIENTO = "RazonSocial";

		const string CAMPO1 = "lblMontoCallaoS";
		const string CAMPO2 = "lblMontoCallaoD";

		//Header
		const string LBLCALLAO = "lblhCallao";
		const string LBLCHIMBOTE = "lblHChimbote";
		const string LBLIQUITOS = "lblHIquitos";

		//Footer
		const string FLBLCALLAOSOLES = "lblFMontoCallaoS";
		const string FLBLCALLAODOLARES ="lblFMontoCallaoD";



		const string TOTALSOLES ="TOTALSOLES";
		const string TOTALDOLAR ="TOTALDOLAR";

		const string NOMBRECLASEFOOTERGRILLA ="FooterGrilla";
		const string VARIABLETOTALIZA = "Totaliza";

		const string MENSAJEERRORGENERAL ="Error de Paginación";
		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlGenericControl tblModelo2;
		protected System.Web.UI.WebControls.Label lblSituacion;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
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
					this.LlenarDatos();
					Helper.ReiniciarSession();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"CartaFianza",this.ToString(),"Se consultó las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));

					Helper.SeleccionarItemCombos(this);
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
					ASPNetUtilitario.MessageBox.Show(MENSAJEERRORGENERAL);
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
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarCartaFianzaResumendeBancosporCentro.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCartaFianzaResumendeBancosporCentro.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			CCartaFianza oCCartaFianza= new CCartaFianza();
			//return oCCartaFianza.ConsultarCartaFianzaResumenDeBancoPorCentro(Page.Request.Params[KEYIDTIPOFZA],Page.Request.Params[KEYIDCENTRO]);
			//return oCCartaFianza.ConsultarCartaFianzaResumenDeBancoPorCentro(Convert.ToInt32(Page.Request.Params[KEYIDTIPOFZA]),Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]));
			return oCCartaFianza.ConsultarCartaFianzaResumenDeBancoPorCentroPorEstado(Convert.ToInt32(Page.Request.Params[KEYIDTIPOFZA]), Convert.ToInt32(Page.Request.Params[KEYESTADOFIANZAP]), Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]), Convert.ToInt32(Page.Request.Params[KEYSUBESTADOFIANZAP]), Convert.ToInt32(Page.Request.Params[KEYESTADOPROY]),Page.Request.Params[KEYIDBENEFICIARIO]);
		}

		private void GenerarResumenMoneda(DataTable dt)
		{
			int NroResumen = 21;
			CResumenItem oCResumenItem = new CResumenItem();
			DataTable dtFinal= Helper.Resumen(oCResumenItem.ObtenerConfiDataResumen(NroResumen),dt);
			ArrayList ArrTotal = new ArrayList();
			ArrTotal.Add(Convert.ToDouble(dtFinal.Rows[0][TOTALSOLES]).ToString(Utilitario.Constantes.FORMATODECIMAL4));
			ArrTotal.Add(Convert.ToDouble(dtFinal.Rows[0][TOTALDOLAR]).ToString(Utilitario.Constantes.FORMATODECIMAL4));
			Session[VARIABLETOTALIZA] = ArrTotal;
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				this.GenerarResumenMoneda(dtGeneral);
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.Sort = columnaOrdenar;
				dwGeneral.RowFilter = Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();
				grid.DataSource = dwGeneral;
				grid.CurrentPageIndex = indicePagina;
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
			// TODO:  Add ConsultarCartaFianzaResumendeBancosporCentro.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblSituacion.Text = Page.Request.Params[TIPOFIANZA].ToString();
		}

		public void LlenarJScript()
		{
			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCartaFianzaResumendeBancosporCentro.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarCartaFianzaResumendeBancosporCentro.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCartaFianzaResumendeBancosporCentro.Exportar implementation
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
			// TODO:  Add ConsultarCartaFianzaResumendeBancosporCentro.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			e.Item.Cells[1].Style.Add("width","30%");
			Label lbl;
			if(e.Item.ItemType == ListItemType.Header)
			{
				lbl = (Label)e.Item.Cells[2].FindControl(LBLCALLAO);
				lbl.Text = Page.Request.Params[NOMBREENTIDAD].ToString().ToUpper();
			}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				lbl = (Label)e.Item.Cells[1].FindControl(CAMPO1);
				lbl.Text= Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.totalsoles.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				lbl = (Label)e.Item.Cells[1].FindControl(CAMPO2);
				lbl.Text= Convert.ToDouble(dr[Enumerados.FinColumnaCartaFianzaporBanco.totaldolar.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
					Helper.MostrarVentana(URLDETALLEBANCO,
						KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaCartaFianzaporBanco.identidadfinanciera.ToString()])
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + ((Page.Request.Params[KEYIDCENTRO]==null)?Utilitario.Constantes.VACIO:Page.Request.Params[KEYIDCENTRO].ToString())
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYIDTIPOFZA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOFZA].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[1].Text
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ TIPOFIANZA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[TIPOFIANZA].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYESTADOFIANZAP].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYSUBESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYSUBESTADOFIANZAP].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYESTADOPROY + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYESTADOPROY].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYIDBENEFICIARIO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDBENEFICIARIO].ToString()
					));

				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				#region FOOTER
				e.Item.Cells[0].ColumnSpan=2;
				e.Item.Cells[0].CssClass = NOMBRECLASEFOOTERGRILLA;
				e.Item.Cells[1].Visible=false;
					ArrayList arrTotal = (ArrayList) Session[VARIABLETOTALIZA];
					((Label) e.Item.Cells[2].FindControl(FLBLCALLAOSOLES)).Text= ((ArrayList) Session[VARIABLETOTALIZA])[0].ToString();
					((Label) e.Item.Cells[2].FindControl(FLBLCALLAODOLARES)).Text=((ArrayList) Session[VARIABLETOTALIZA])[1].ToString();
				Session[VARIABLETOTALIZA]=null;
				#endregion
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);		
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}
	}
}
