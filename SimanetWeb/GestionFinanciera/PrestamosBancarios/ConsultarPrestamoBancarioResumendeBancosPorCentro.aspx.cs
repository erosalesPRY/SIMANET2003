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

namespace SIMA.SimaNetWeb.GestionFinanciera.PrestamosBancarios
{
	public class ConsultarPrestamoBancarioResumendeBancosPorCentro : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkBanco";
		const string CONTROLTITULOTOTAL="hlkTitulo";
		const string URLDETALLE="ConsultarPrestamosporBancoDetalle.aspx?";
		const string URLDETALLEPORCENTRO="ConsultarPrestamosporCentroDetalle.aspx?";
		const string URLRESUMEDEBANCOPORCENTRO="ConsultarPrestamoBancarioResumendeBancosPorCentro.aspx?";
		
		const string URLPRINCIPAL="../../Default.aspx";
		const string COLORDENAMIENTO = "razonsocial";

		const string KEYIDESTADO = "idEstado";
		const string KEYIDENTIDADFINANCIERA = "idEF";
		const string KEYIDCENTRO = "idCentro";
		const string NOMBREENTIDAD = "Nombre";

		const string NOMBRECENTRO = "NombreCentro";

		const string CAMPO1 = "lblMontoCallaoS";
		const string CAMPO2 = "lblMontoCallaoD";
		const string CAMPO3 = "lblMontoChimboteS";
		const string CAMPO4 = "lblMontoChimboteD";
		const string CAMPO5 = "lblMontoIquitosS";
		const string CAMPO6 = "lblMontoIquitosD";
		const string CAMPO7 = "lblMontoTotalS";
		const string CAMPO8 = "lblMontoTotalD";

		const string CAMPOT1 = "lblFMontoCallaoS";
		const string CAMPOT2 = "lblFMontoCallaoD";
		const string CAMPOT3 = "lblFMontoChimboteS";
		const string CAMPOT4 = "lblFMontoChimboteD";
		const string CAMPOT5 = "lblFMontoIquitosS";
		const string CAMPOT6 = "lblFMontoIquitosD";
		const string CAMPOT7 = "lblFMontoTotalS";
		const string CAMPOT8 = "lblFMontoTotalD";
		
		const int PRODEDURENRO = 1;
		const string URLANTERIOR = "/SimaNetWeb/DirectorioEjecutivo/EstadosFinancieros.aspx";
		//Campos Cabeceras
		const string CAMPOH1 = "lblHCallao";
		const string CAMPOH2 = "lblHChimbote";
		const string CAMPOH3 = "lblHIquitos";

		//Controles
		const string CTRLLBLHCENTRO ="lblhCentro";
		const string CTRLLBLFMONTOTOTSOLES ="lblFMontoTotalS";
		const string CTRLLBLFMONTOTOTDOLAR ="lblFMontoTotalD";

		//DataGrid and DataTable
		const string COLUMNAIDENTIDADFINANCIERA ="idEntidadFinanciera";
		const string COLUMNAIDESTADO ="idEstado";

		//Otros
		const string SESSIONTOTALIZA ="Totaliza";

		#endregion		
		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label Label2;
			protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
			protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
			protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
			protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
			protected System.Web.UI.HtmlControls.HtmlGenericControl tblModelo2;
		protected System.Web.UI.WebControls.Label lblCentro;
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
					ASPNetUtilitario.MessageBox.Show("Error de Paginación");
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarPrestamoBancarioResumendeBancosPorCentro.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPrestamoBancarioResumendeBancosPorCentro.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			CPrestamoBancario oCPrestamoBancario= new CPrestamoBancario();
			DataTable dtGeneral = oCPrestamoBancario.ConsultaPrestamosResumendeBancosporBanco(Utilitario.Constantes.IDESTADODEFAULT,Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]));
			return dtGeneral;
		}
		private void GenerarResumen(DataTable dt)
		{
			if (dt!=null)
			{
				int NroResumen	 = 22;
				CResumenItem oCResumenItem = new CResumenItem();
				DataTable dtFinal1= Helper.Resumen(oCResumenItem.ObtenerConfiDataResumen(NroResumen),dt);
				Session["Totaliza"] = dtFinal1;
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				this.GenerarResumen(dtGeneral);
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.Sort = columnaOrdenar;
				dwGeneral.RowFilter = Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();
				grid.DataSource = dwGeneral;
				grid.CurrentPageIndex = indicePagina;
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
				ibtnImprimir.Visible = false;
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
			
		}

		public void LlenarDatos()
		{
			lblCentro.Text=Page.Request.Params[NOMBREENTIDAD].ToString().ToUpper();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarPrestamoBancarioResumendeBancosPorCentro.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPrestamoBancarioResumendeBancosPorCentro.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarPrestamoBancarioResumendeBancosPorCentro.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarPrestamoBancarioResumendeBancosPorCentro.Exportar implementation
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
			// TODO:  Add ConsultarPrestamoBancarioResumendeBancosPorCentro.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{			
			if(e.Item.ItemType == ListItemType.Header)
			{
				((Label) e.Item.Cells[2].FindControl(CTRLLBLHCENTRO)).Text = Page.Request.Params[NOMBREENTIDAD].ToString();
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				#region Item
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
						Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
						Helper.MostrarVentana(URLDETALLE,KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[COLUMNAIDENTIDADFINANCIERA])
																		+  Utilitario.Constantes.SIGNOAMPERSON
																		+  KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNAIDESTADO].ToString()
																		+  Utilitario.Constantes.SIGNOAMPERSON
																		+  NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.FinColumnaPrestamoBancario.RazonSocial.ToString()]
																		+  Utilitario.Constantes.SIGNOAMPERSON
																		+  KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDCENTRO].ToString()
																		+  Utilitario.Constantes.SIGNOAMPERSON
																		+  Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[Utilitario.Constantes.KEYMODULOCONSULTA].ToString()
																		)) ;

				((Label)e.Item.Cells[2].FindControl(CAMPO7)).Text= Convert.ToDouble(dr[Enumerados.FinColumnaPrestamoBancario.MontoTotalS.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[2].FindControl(CAMPO8)).Text= Convert.ToDouble(dr[Enumerados.FinColumnaPrestamoBancario.MontoTotalD.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex).ToUpper();
				
				#endregion
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				#region Footer
				e.Item.Cells[0].ColumnSpan=2;
				e.Item.Cells[1].Visible=false;

				DataTable dtTotal = (DataTable) Session[SESSIONTOTALIZA];
				((Label)e.Item.Cells[2].FindControl(CTRLLBLFMONTOTOTSOLES)).Text = Convert.ToDouble(dtTotal.Rows[0][Enumerados.FinColumnaPrestamoBancario.MontoTotalS.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[2].FindControl(CTRLLBLFMONTOTOTDOLAR)).Text = Convert.ToDouble(dtTotal.Rows[0][Enumerados.FinColumnaPrestamoBancario.MontoTotalD.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				Session[SESSIONTOTALIZA]=null;
				#endregion
			}		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
