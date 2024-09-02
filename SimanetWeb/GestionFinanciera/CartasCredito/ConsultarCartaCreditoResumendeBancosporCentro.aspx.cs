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
	public class ConsultarCartaCreditoResumendeBancosporCentro : System.Web.UI.Page,IPaginaBase
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

		
		const string URLANTERIOR = "/SimaNetWeb/DirectorioEjecutivo/EstadosFinancieros.aspx";


		//Otros
		const string CAMPO7 = "lblMontoTotalS";
		const string CAMPO8 = "lblMontoTotalD";

		const string HEADERTOTAL = "lblHTotal";
		const string CONTROLMONTOTOTALSOLES ="lblFMontoTotalS";
		const string CONTROLMONTOTOTALDOLARES ="lblFMontoTotalD";
		const string NOMBRECLASEFOOTERGRILLA="FooterGrilla";

		const string TOTALIZA ="Totaliza";

		private ASPNetDatagridDecorator m_add = new ASPNetDatagridDecorator();

		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarCartaCreditoResumendeBancosporCentro.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}

		private DataTable ObtenerDatos()
		{
			CCartaCredito oCCartaCredito = new CCartaCredito();
			DataTable dtGeneral =oCCartaCredito.ConsultarCartadeCreditoResumendeBancoPorCentro(Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]), 
																								Convert.ToInt32(Page.Request.Params[KEYIDESTADO]),
																								Convert.ToInt32(Page.Request.Params[KEYIDTIPOCREDITO]));			
			return dtGeneral;
		}
		private void Totaliza(DataView dv)
		{
			ArrayList arrTotaliza = new ArrayList();
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.FINColumnaCartaCreditoResumen.totalsoles.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.FINColumnaCartaCreditoResumen.totaldolar.ToString() + ")",dv.RowFilter.ToString()));
			Session[TOTALIZA]  =arrTotaliza;
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				//this.Totalizar(dtGeneral);
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.Sort = columnaOrdenar ;
				dwGeneral.RowFilter = Helper.ObtenerFiltro();
				this.Totaliza(dwGeneral);
				grid.DataSource = dwGeneral;
				grid.CurrentPageIndex = indicePagina;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();

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
			// TODO:  Add ConsultarCartaCreditoResumendeBancosporCentro.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarCartaCreditoResumendeBancosporCentro.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarCartaCreditoResumendeBancosporCentro.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCartaCreditoResumendeBancosporCentro.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarCartaCreditoResumendeBancosporCentro.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCartaCreditoResumendeBancosporCentro.Exportar implementation
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
			// TODO:  Add ConsultarCartaCreditoResumendeBancosporCentro.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			#region HEADER
			if(e.Item.ItemType == ListItemType.Header)
			{
				if (Page.Request.Params[NOMBRECENTRO]!=null)
				{
					((Label)e.Item.Cells[2].FindControl(HEADERTOTAL)).Text= Page.Request.Params[NOMBRECENTRO].ToString().ToUpper();
				}
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
															KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + dr["idEntidadFinanciera"].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON 
															+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDCENTRO].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON 
															+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[1].Text
															+ Utilitario.Constantes.SIGNOAMPERSON 
															+ KEYIDESTADO  + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[KEYIDESTADO].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYIDTIPOCREDITO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOCREDITO].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON 
															+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[Utilitario.Constantes.KEYMODULOCONSULTA].ToString()));
				
				
				((Label)e.Item.Cells[2].FindControl(CAMPO7)).Text= Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.totalsoles.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[2].FindControl(CAMPO8)).Text= Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.totaldolar.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				
			}	
			#endregion

			#region FOOTER
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[0].ColumnSpan=2;
				e.Item.Cells[0].CssClass = NOMBRECLASEFOOTERGRILLA;
				e.Item.Cells[1].Visible=false;
				if (Session[TOTALIZA]!=null)
				{
					((Label) e.Item.Cells[2].FindControl(CONTROLMONTOTOTALSOLES)).Text=Convert.ToDouble(((object)((ArrayList) Session[TOTALIZA])[0])).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					((Label) e.Item.Cells[2].FindControl(CONTROLMONTOTOTALDOLARES)).Text=Convert.ToDouble(((object)((ArrayList) Session[TOTALIZA])[1])).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					Session[TOTALIZA]=null;
				}
			}				
			#endregion
		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
