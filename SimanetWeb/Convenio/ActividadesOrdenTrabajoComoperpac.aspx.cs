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
	/// Aquí
	/// </summary>
	/// 
	public class ActividadesOrdenTrabajoComoperpac : System.Web.UI.Page, IPaginaBase
	{
	
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
			this.ddlbActividad.SelectedIndexChanged += new System.EventHandler(this.ddlbActividad_SelectedIndexChanged);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.dgActividad.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgActividad_SortCommand);
			this.dgActividad.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgActividad_PageIndexChanged);
			this.dgActividad.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgActividad_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IPaginaBase Members
		public void LlenarGrilla()
		{}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CPeriodoUnidadesApoyo oCPeriodoUnidadesApoyo = new CPeriodoUnidadesApoyo();
			DataTable dtActividad = oCPeriodoUnidadesApoyo.ConsultarActividadUnidadesDeApoyoComoperpac(Convert.ToInt32(Page.Request.Params[KEYIDORDENTRABAJOUNIDADAPOYO]),Convert.ToInt32(this.ddlbActividad.SelectedValue));
			
			this.ColumnaVisibleGrillaTipoActividad(Convert.ToInt32(this.ddlbActividad.SelectedValue));
			if(dtActividad!=null)
			{
				DataView dwActividad = dtActividad.DefaultView;
				dwActividad.Sort = columnaOrdenar;
				dgActividad.DataSource = dwActividad;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtActividad,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				lblResultado.Visible = false;
				
				dgActividad.Columns[1].FooterText = dwActividad.Count.ToString();
			}
			else
			{
				dgActividad.DataSource = dtActividad;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;

			}
			try
			{
				dgActividad.DataBind();
			}
			catch	
			{
				dgActividad.CurrentPageIndex = Utilitario.Constantes.POSICIONINDEXCERO;
				dgActividad.DataBind();
			}		
		}

		public void LlenarCombos()
		{
			CTablaTablas oCTablaTablas=new CTablaTablas();
			ListItem lItem=new ListItem();
			DataTable dt=oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TipoActividadOrdenTrabajoComoperpac));
			this.ddlbActividad.DataSource=dt;
			this.ddlbActividad.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlbActividad.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			this.ddlbActividad.DataBind();
			lItem=this.ddlbActividad.Items.FindByValue(this.Page.Request.Params[KEYQTIPOACTIVIDADORDENTRABAJO]);
			if(lItem!=null)
			{
				lItem.Selected=true;
			}
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text= MENSAJETITULO + Convert.ToString(this.Page.Request.Params[KEYQNROORDENTRABAJO]);
		}

		public void LlenarJScript()
		{}
		public void RegistrarJScript()
		{}

		public void Imprimir()
		{}

		public void Exportar()
		{}

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
		#region Constantes

		//Grilla.
		private const string GRILLAVACIA="No hay datos de la Actividad Actual Seleccionada";
		private const string COLORDENAMIENTO="DocumentoAprovacion";

		//Keys
		private const string KEYQNROORDENTRABAJO="NroOrdenTrabajo";
		private const string KEYIDORDENTRABAJOUNIDADAPOYO="IdOrdenTrabajoUnidadApoyo";
		private const string KEYIDPERIODOUNIDADESAPOYO="IdPeriodoUnidadesApoyo";
		private const string KEYQPERIODO="Periodo";
		private const string KEYQTIPOACTIVIDADORDENTRABAJO="IdTipoActividad";
		
		//URL' s
		private const string URLPRINCIPAL="ConsultarOrdenTrabajoUnidadApoyo.aspx?";

		//Mensajes
		private const string MENSAEJECONSULTAR="Se consultó las Actividades de Ordenes de Trabajo.";
		private const string MENSAJETITULO="ORDEN DE TRABAJO: ";


		#endregion Constantes
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblMontoSaldo;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblActividad;
		protected System.Web.UI.WebControls.DropDownList ddlbActividad;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb dgActividad;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblMontoAsignado;
		protected System.Web.UI.WebControls.Label lblMontoEjecutado;
		protected System.Web.UI.WebControls.Label lblEnEjecucion;
		protected System.Web.UI.WebControls.Label lblDocumento;
		protected System.Web.UI.WebControls.TextBox txtDocumento;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblDocumentoAprovacion;
		protected System.Web.UI.WebControls.TextBox txtDocumentoAprovacion;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		#endregion
		#region Eventos
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					this.LlenarDatos();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAEJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));
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

		private string RetonarNumeroFormateado(string CadenaNumerica ,string CadenaFormatoDecimal,string RetornarValor)
		{
			if(!NullableDouble.Parse(CadenaNumerica).IsNull)
			{
				return Convert.ToDouble(CadenaNumerica).ToString(CadenaFormatoDecimal);
			}
			else
			{
				return RetornarValor;
			}
		}

		private void ColumnaVisibleGrillaTipoActividad(int pIdTipoActividad)
		{
			this.ColumnasNoVisibleGrilla();

			if(pIdTipoActividad==Convert.ToInt32(Enumerados.TipoActividadOrdenTrabajoComoperpac.Trabajos))
			{
				this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXCINCO].Visible=true;
				this.lblDocumento.Visible=true;
				this.txtDocumento.Visible=true;
				this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXCUATRO].HeaderText="Inicio";
				this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXCINCO].HeaderText="Termino";
				this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXSEIS].Visible=true;
			}
			else
			{
				this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXDOS].Visible=true;
				this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXCUATRO].HeaderText="Fecha";
				this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXSEIS].Visible=false;
			}

	    }

		private void ColumnasNoVisibleGrilla()
		{
			this.txtDocumento.Text="";
			this.txtObservaciones.Text="";
			this.txtDescripcion.Text="";
			
			this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXDOS].Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL; //NroValorizacion
			this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXCINCO].Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL; //FechaTermino,
			this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXSEIS].Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
			this.lblDocumento.Visible= Utilitario.Constantes.VALORUNCHECKEDBOOL;
			this.txtDocumento.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;

     		//1:  DocumentoAprovacion,	//4:  FechaInicio,	//6:  PorcAvanceFisico,
			//7:  MontoAsignado, //8:  MontoEjecutado,	//9:  MontoEnEjecucion,
			//10: Documento, //11: Descripcion,	//12: Observaciones

		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{}
	
		private void dgActividad_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[0].ForeColor=Color.Blue;

				string Cadena="";
				string pMontoAsignado="";
				string pMontoEjecutado="";
				string pMontoEnEjecucion="";

				pMontoAsignado=RetonarNumeroFormateado(Convert.ToString(dr[Enumerados.ColumnasActidadesOrdenTrabajoComoperpac.MontoAsignado.ToString()]),Utilitario.Constantes.FORMATODECIMAL4,"");
				pMontoEjecutado=RetonarNumeroFormateado(Convert.ToString(dr[Enumerados.ColumnasActidadesOrdenTrabajoComoperpac.MontoEjecutado.ToString()]),Utilitario.Constantes.FORMATODECIMAL4,"");
				pMontoEnEjecucion=RetonarNumeroFormateado(Convert.ToString(dr[Enumerados.ColumnasActidadesOrdenTrabajoComoperpac.MontoEnEjecucion.ToString()]),Utilitario.Constantes.FORMATODECIMAL4,"");

				Cadena="LlenarControlesHtml('" + pMontoAsignado + "','" + pMontoEjecutado + "','" + pMontoEnEjecucion + "'); ";
				Cadena=Cadena + " LlenarControlesWebFormNet('" + Helper.LimpiarTexto(Convert.ToString(dr[Enumerados.ColumnasActidadesOrdenTrabajoComoperpac.Descripcion.ToString()])) + "','" + Helper.LimpiarTexto(Convert.ToString(dr[Enumerados.ColumnasActidadesOrdenTrabajoComoperpac.Observaciones.ToString()])) + "'); ";
				
				if(Convert.ToInt32(this.ddlbActividad.SelectedValue)==Convert.ToInt32(Enumerados.TipoActividadOrdenTrabajoComoperpac.Trabajos))
				{
					Cadena=Cadena + " LlenarControlTxtDocumento('" + Helper.LimpiarTexto(Convert.ToString(dr[Enumerados.ColumnasActidadesOrdenTrabajoComoperpac.Documento.ToString()])) +  "'); ";
				}

				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Text = Helper.ObtenerIndicedeRegistro(dgActividad.CurrentPageIndex,dgActividad.PageSize,e.Item.ItemIndex);
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Cadena);

			}
		}

		private void dgActividad_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void RedireccionarPaginaPrevia()
		{
			this.Page.Response.Redirect(URLPRINCIPAL + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO] + Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO]);
		}

		private void dgActividad_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			Helper.ReiniciarSession();
			dgActividad.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void ddlbActividad_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Helper.ReiniciarSession();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,false),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}
		#endregion
	}
}
