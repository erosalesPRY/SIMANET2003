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


namespace SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras
{
	public class ConsultarResumendeLetrasporTipoSituacionyCentro : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string KEYIDTIPOLETRA = "TipoLetra";
		const string KEYNOMBRETIPOLETRA = "NombreTipoLetra";
		const string KEYIDCENTRO = "idCentro";
		const string NOMBRECENTRO = "NombreCO";
		const string URLDETALLE = "ConsultarLetrasporTipoySituacion.aspx?";
		const string KEYIDSITUACION ="Situacion";
		const string KEYIDSITUACIONDESCRIPCION ="DescSituacion";

		const string CAMPO7 = "lblMontoTotalS";
		const string CAMPO8 = "lblMontoTotalD";

		const string LBLCALLAO = "lblhCallao";
		const string LBLCHIMBOTE = "lblHChimbote";
		const string LBLIQUITOS = "lblHIquitos";

		const string MONTOTOTALSOLES ="MontoTotalS";
		const string MONTOTOTALDOLARES ="MontoTotalD";

		const string VARIABLESESSIONTOTALIZA ="Totaliza";

		//Otros
		const string ETIQUETATIPO ="TIPO : ";
		const string NOMBRECLASEFOOTER ="FooterGrilla";

		//Nombre Controles
		const string ETIQUETAHTOTAL ="lblHTotal";
		const string ETIQUETAMONTOTOTALSOLES ="lblFMontoTotalS";
		const string ETIQUETAMONTOTOTALDOLARES ="lblFMontoTotalD";

		#endregion


		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
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
					this.LlenarDatos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
			// TODO:  Add ConsultarResumendeLetrasporTipoSituacionyCentro.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarResumendeLetrasporTipoSituacionyCentro.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			return ((CLetras) new CLetras()).ConsultarResumendeLetrasporSituacionyCentro(Convert.ToInt32(Page.Request.Params[KEYIDTIPOLETRA]),
																							Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]));
		}
		private void Totalizar(DataTable dtOrigen)
		{
			if (dtOrigen !=null)
			{
				ArrayList arrTotal = new ArrayList();
				double []TotalTotalS = Helper.TotalizarDataView(dtOrigen.DefaultView,MONTOTOTALSOLES);
				arrTotal.Add(TotalTotalS[0]);
				double []TotalTotalD = Helper.TotalizarDataView(dtOrigen.DefaultView,MONTOTOTALDOLARES);
				arrTotal.Add(TotalTotalD[0]);
				Session[VARIABLESESSIONTOTALIZA] = arrTotal;
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				this.Totalizar(dtGeneral);
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.RowFilter = Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();
				dwGeneral.Sort = columnaOrdenar ;
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
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarResumendeLetrasporTipoSituacionyCentro.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = ETIQUETATIPO + Page.Request.Params[KEYNOMBRETIPOLETRA].ToString().ToUpper();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarResumendeLetrasporTipoSituacionyCentro.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarResumendeLetrasporTipoSituacionyCentro.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarResumendeLetrasporTipoSituacionyCentro.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarResumendeLetrasporTipoSituacionyCentro.Exportar implementation
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
			// TODO:  Add ConsultarResumendeLetrasporTipoSituacionyCentro.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				((Label) e.Item.Cells[2].FindControl(ETIQUETAHTOTAL)).Text=Page.Request.Params[NOMBRECENTRO].ToString().ToUpper();
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
					Helper.MostrarVentana(URLDETALLE,KEYIDSITUACION+ Utilitario.Constantes.SIGNOIGUAL + dr["idSituacion"].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ KEYIDSITUACIONDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[1].Text
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[Utilitario.Constantes.KEYMODULOCONSULTA.ToString()] 
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRA].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYNOMBRETIPOLETRA].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDCENTRO].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[NOMBRECENTRO].ToString()
											));

				((Label)e.Item.Cells[2].FindControl(CAMPO7)).Text= Convert.ToDouble(dr[MONTOTOTALSOLES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[2].FindControl(CAMPO8)).Text= Convert.ToDouble(dr[MONTOTOTALDOLARES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
			#region FOOTER
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[0].ColumnSpan=2;
				e.Item.Cells[0].CssClass = NOMBRECLASEFOOTER;
				e.Item.Cells[1].Visible=false;
				ArrayList arrTotal = (ArrayList) Session[VARIABLESESSIONTOTALIZA];

				((Label) e.Item.Cells[2].FindControl(ETIQUETAMONTOTOTALSOLES)).Text = Convert.ToDouble(((ArrayList) Session[VARIABLESESSIONTOTALIZA])[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[2].FindControl(ETIQUETAMONTOTOTALDOLARES)).Text = Convert.ToDouble(((ArrayList) Session[VARIABLESESSIONTOTALIZA])[1]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				Session[VARIABLESESSIONTOTALIZA]=null;
			}		
			#endregion
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	

		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());

		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
