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
using SIMA.Controladoras.Convenio;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;


namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Summary description for ConsultarPeriodoFasub.
	/// </summary>
	public class ConsultarPeriodoFasub : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltro;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblTitulo;
		#endregion

		#region Constantes
		private const string KEYSIGLAS="Siglas";
		private const string KEYPERIODO="Periodo";
		private const string KEYIDUNIDADAPOYO="IdUnidadApoyo";
		private const string URLIMPRESION="";
		private const string COLORDENAMIENTO="Periodo";
		private const int POSICIONCONTADOR=0;
		private const string URLDETALLE="ConsultarSubmarinosPorPeriodo.aspx?";
		private double acumMontoAsignado=0;		
		private double acumMontoEjecutado=0;
		private double acumMontoEnEjecucion=0;				
		private double acumMontoSaldo;
		
		const string KEYQID="IdPeriodoApoyoFasub";
		#endregion


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
			this.ibtnFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltro_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarDatos();
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
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

		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarPeriodoUnidadesApoyo.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPeriodoUnidadesApoyo.LlenarGrillaOrdenamiento implementation
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CPeriodoApoyoFasub oCPeriodoApoyoFasub=new CPeriodoApoyoFasub();
			DataTable dtPeriodoApoyoFasub = oCPeriodoApoyoFasub.ListarPeriodosApoyoFasub(Convert.ToInt32(Page.Request.QueryString[KEYIDUNIDADAPOYO])); 

			txtDescripcion.Text="";
			txtObservaciones.Text="";

			if(dtPeriodoApoyoFasub!=null)
			{
				DataView dwPeriodoApoyoFasub = dtPeriodoApoyoFasub.DefaultView;
				dwPeriodoApoyoFasub.RowFilter=Helper.ObtenerFiltro();
				dwPeriodoApoyoFasub.Sort = columnaOrdenar;
				grid.DataSource = dwPeriodoApoyoFasub;
				grid.CurrentPageIndex = indicePagina;
				lblResultado.Visible = false;
				grid.Columns[3].FooterText = dwPeriodoApoyoFasub.Count.ToString();
				indicePagina=Helper.ValidarIndicePaginacionGrilla(dwPeriodoApoyoFasub.Count,grid.PageSize,indicePagina);
			}
			else
			{
				grid.DataSource = dtPeriodoApoyoFasub;
				lblResultado.Visible = true;
			
			}
			try
			{
				grid.CurrentPageIndex=indicePagina;
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
			this.lblTitulo.Text += "-" + Page.Request.QueryString[KEYSIGLAS];
		}

		public void LlenarJScript()
		{
			
		}

		public void RegistrarJScript()
		{
		
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,700,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			
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

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ibtnFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			object[] campos={"PERIODO;PERIODO","MontoAsignado;ASIGNADO","MontoEjecutado;EJECUTADO","MontoEnEjecucion;EN EJECUCION","MontoSaldo;SALDO","Descripcion;DESCRIPCION"};
			string CamposFiltro=Utilitario.Helper.ElaborarFiltro(campos);
			this.ltlMensaje.Text=CamposFiltro;
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Helper.ObtenerIndicePagina());
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{

				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

				e.Item.Cells[POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr["IDPERIODOAPOYOFASUB"].ToString()+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYPERIODO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasPeriodoUnidadesApoyoFasub.Periodo.ToString()].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON + 
					 KEYSIGLAS + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.QueryString[KEYSIGLAS]))));


				e.Item.Cells[POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(this.grid.CurrentPageIndex,this.grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[0].ForeColor=Color.Blue;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr["IDPERIODOAPOYOFASUB"].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,this.grid);
				
				this.acumMontoAsignado += NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.MontoAsignado.ToString()],0);
				this.acumMontoEjecutado += NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.MontoEjecutado.ToString()],0);
				this.acumMontoEnEjecucion += NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.MontoEnEjecucion.ToString()],0);
				this.acumMontoSaldo += NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.MontoSaldo.ToString()],0);
			}
			else if(e.Item.ItemType == ListItemType.Footer)
			{   
			//	e.Item.Cells[3].Text = Utilitario.Constantes.TEXTOTOTAL + " " + Utilitario.Enumerados.Moneda.NS;
				e.Item.Cells[4].Text = acumMontoAsignado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = acumMontoEjecutado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[6].Text = acumMontoEnEjecucion.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[7].Text = acumMontoSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		
	}
}
