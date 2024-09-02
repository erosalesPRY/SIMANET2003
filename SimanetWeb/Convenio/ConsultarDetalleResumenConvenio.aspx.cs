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
using SIMA.Controladoras.Convenio;
using SIMA.Controladoras.General;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;

namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Summary description for ConsultarDetalleResumenConvenio.
	/// </summary>
	public class ConsultarDetalleResumenConvenio : System.Web.UI.Page, IPaginaBase
	{
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb dgResumenConvenio;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label lblMontoPorCobrar;
		protected System.Web.UI.WebControls.Label lblMontoPorPagar;
		protected System.Web.UI.WebControls.Label lblCalMontoPorCobrar;
		protected System.Web.UI.WebControls.Label lblCalMontoPorPagar;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					//this.LlenarJScript();
					Helper.ReiniciarSession();
					//this.LlenarCombos();
					//this.LlenarDatos();

					//					acumMontoPorCobrar=new double[100];
					//					acumMontoPorPagar=new double[100];

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Resumen de Convenio",this.ToString(),"Resumen de Convenios",Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarGrillaOrdenamientoPaginacion(COLORDENAMIENTO,Utilitario.Constantes.INDICEPAGINADEFAULT);
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
			this.dgResumenConvenio.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgResumenConvenio_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Constantes
		const string COLORDENAMIENTO="Periodo DESC";
		//const string COLORDENAMIENTO="";
		const string GRILLAVACIA="No hay informacion de Resumen de Convenio";

		const string URLPRINCIPAL="ConsultarConvenioSimaMgpUnidadesApoyo.aspx";
		const string URLDIRECTORIO = "/SimaNetWeb/DirectorioEjecutivo/InformeDirectorio.aspx";

		//Controles
		const string CONTROLGRILLADGDATOS="dgDatos";

		#endregion Constantes

		#region Variables
		private DataTable dtDatosResumen=new DataTable();

		private double[] acumMontoPorCobrar;
		private double[] acumMontoPorPagar;

		private double TotalMontoPorCobrar=0;
		private double TotalMontoPorPagar=0;
		

		int IndexAcum=0;
		
		#endregion Variables

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarDetalleResumenConvenio.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{

		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CConvenioSimaMgp oCConvenioSimaMgp=new CConvenioSimaMgp();
			DataTable dtResumenConvenio=new DataTable();
			DataTable dtPeriodo=new DataTable();
			oCConvenioSimaMgp.ConsultarResumanenDeConvenios(ref dtPeriodo,ref dtResumenConvenio);
			
			if(dtResumenConvenio!=null)
			{
				this.dtDatosResumen=dtResumenConvenio;
			}
			if(dtPeriodo!=null)
			{
				acumMontoPorCobrar=new double[dtPeriodo.Rows.Count];
				acumMontoPorPagar=new double[dtPeriodo.Rows.Count];

				DataView dwPeriodo = dtPeriodo.DefaultView;
				dwPeriodo.Sort = columnaOrdenar;
				dgResumenConvenio.DataSource = dwPeriodo;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtPeriodo,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				ibtnImprimir.Visible = true;
				dgResumenConvenio.Columns[1].FooterText = dwPeriodo.Count.ToString();
				lblResultado.Visible = false;
			}
			else
			{
				dgResumenConvenio.DataSource = dtPeriodo;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				ibtnImprimir.Visible = false;
			}
			try
			{
				dgResumenConvenio.DataBind();
			}
			catch	
			{
				dgResumenConvenio.CurrentPageIndex = 0;
				dgResumenConvenio.DataBind();
			}				
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarDetalleResumenConvenio.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarDetalleResumenConvenio.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarDetalleResumenConvenio.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarDetalleResumenConvenio.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarDetalleResumenConvenio.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarDetalleResumenConvenio.Exportar implementation
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
			// TODO:  Add ConsultarDetalleResumenConvenio.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void dgResumenConvenio_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				projDataGridWeb.DataGridWeb dgw = (projDataGridWeb.DataGridWeb) e.Item.Cells[1].FindControl(CONTROLGRILLADGDATOS);
				this.IndexAcum = e.Item.ItemIndex;
				this.acumMontoPorCobrar[this.IndexAcum]=0;
				this.acumMontoPorPagar[this.IndexAcum]=0;
				this.LlenarGrillaSegunFiltroPeriodo(Convert.ToInt32(dr["periodo"].ToString()),dgw);
				this.TotalMontoPorCobrar = this.TotalMontoPorCobrar + this.acumMontoPorCobrar[this.IndexAcum];
				this.TotalMontoPorPagar = this.TotalMontoPorPagar + this.acumMontoPorPagar[this.IndexAcum];
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);


			}
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				this.lblCalMontoPorCobrar.Text=this.TotalMontoPorCobrar.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				this.lblCalMontoPorPagar.Text=this.TotalMontoPorPagar.ToString(Utilitario.Constantes.FORMATODECIMAL4) ;
			}
		}

		private void LlenarGrillaSegunFiltroPeriodo(int Periodo,projDataGridWeb.DataGridWeb dgGrid)
		{
			DataView dv=this.dtDatosResumen.DefaultView;
			dv.RowFilter=Utilitario.Enumerados.ColumnasResumenConvenioProcedure.Periodo.ToString() + Utilitario.Constantes.SIGNOIGUAL + Periodo;
			dv.ApplyDefaultSort=true;
			dgGrid.DataSource=dv;
			dgGrid.ItemDataBound +=new DataGridItemEventHandler(GrillaItemDataBound);
			dgGrid.DataBind();
		}
		
		private void GrillaItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv=(DataRowView)e.Item.DataItem;
				DataRow dr=drv.Row;
				e.Item.Cells[0].Width = new Unit("16%");
				e.Item.Cells[1].Width = new Unit("18%");
				e.Item.Cells[2].Width = new Unit("3%");
				e.Item.Cells[3].Wrap=true;
				e.Item.Cells[3].Width = new Unit("45%");
				e.Item.Cells[4].Width = new Unit("18%");

				if(!NullableDouble.Parse(dr[Utilitario.Enumerados.ColumnasResumenConvenioDatosGrilla.MontoPorCobrar.ToString()].ToString()).IsNull)
				{
					this.acumMontoPorCobrar[this.IndexAcum]=this.acumMontoPorCobrar[this.IndexAcum] + Convert.ToDouble(dr[Utilitario.Enumerados.ColumnasResumenConvenioDatosGrilla.MontoPorCobrar.ToString()].ToString());
				}

				if(!NullableDouble.Parse(dr[Utilitario.Enumerados.ColumnasResumenConvenioDatosGrilla.MontoPorPagar.ToString()].ToString()).IsNull)
				{
					this.acumMontoPorPagar[this.IndexAcum]=this.acumMontoPorPagar[this.IndexAcum] + Convert.ToDouble(dr[Utilitario.Enumerados.ColumnasResumenConvenioDatosGrilla.MontoPorPagar.ToString()].ToString());
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[0].Text="Sub Total";
				e.Item.Cells[1].Text=this.acumMontoPorCobrar[this.IndexAcum].ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[4].Text=this.acumMontoPorPagar[this.IndexAcum].ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void RedireccionarPaginaPrevia()
		{
			this.Page.Response.Redirect(URLPRINCIPAL);
		}

	}
}
