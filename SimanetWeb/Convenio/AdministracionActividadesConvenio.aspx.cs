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
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Aqui se administran las actividades que cada OT por tiene. Estas se clasifican segun
	/// estados.
	/// Este formulario ya paso por refactoring.
	/// </summary>
	public class AdministracionActividadesConvenio : System.Web.UI.Page, IPaginaBase , IPaginaMantenimento 
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
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnExportar_Click);
			this.dgActividad.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgActividad_SortCommand);
			this.dgActividad.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgActividad_PageIndexChanged);
			this.dgActividad.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgActividad_ItemDataBound);
			this.dgActividad.SelectedIndexChanged += new System.EventHandler(this.dgActividad_SelectedIndexChanged);
			this.txtDocumentoAprovacion.TextChanged += new System.EventHandler(this.txtDocumentoAprovacion_TextChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IPaginaMantenimento Members
		public void Agregar()
		{
		}

		public void Modificar()
		{
		}

		public void Eliminar()
		{
		}

		public void CargarModoPagina()
		{
		}

		public void CargarModoNuevo()
		{
		}

		public void CargarModoModificar()
		{
		}

		public void CargarModoConsulta()
		{
		}

		public bool ValidarCampos()
		{

			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			return false;
		}

		private void ibtnExportar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
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
				dgActividad.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
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

			lItem=this.ddlbActividad.Items.FindByValue(Convert.ToInt32(this.Page.Request.Params[KEYQTIPOACTIVIDADORDENTRABAJO]).ToString());
			if(lItem!=null)
			{
				lItem.Selected=Utilitario.Constantes.VALORCHECKEDBOOL;
			}

		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text= TITULOPAGINA + this.Page.Request.Params[KEYQNROORDENTRABAJO];
		}

		public void LlenarJScript()
		{
			
		}

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

		//KEYs
		private const string KEYQNROORDENTRABAJO="NroOrdenTrabajo";
		private const string KEYIDORDENTRABAJOUNIDADAPOYO="IdOrdenTrabajoUnidadApoyo";
		private const string KEYIDPERIODOUNIDADESAPOYO="IdPeriodoUnidadesApoyo";
		private const string KEYQPERIODO="Periodo";
		private const string KEYIDACTIVIDADESORDENTRABAJO="IdActividadesOrdenTrabajo";
		private const string KEYIDCENTROOPERATIVO="IdCentroOperativo";
		private const string KEYIDESTADO="IdEstado";
		private const string KEYQTIPOACTIVIDADDESCRIPCION="Descripcion";
		private const string KEYQTIPOACTIVIDADORDENTRABAJO="IdTipoActividad";

		//URL's
		private const string URLPRINCIPAL="AdministrarOrdenTrabajoComoperpac.aspx?";
		private const string URLDETALLEACTIVIDADORDENTRABAJOCOMOPERPAC="DetalleActividadOrdenTrabajoComoperpac.aspx?";

		//Otros
		private const string CONTROLLINK="hlkId";
		private const int VALORSUBSTRINGINICIO=0;

		//Mensajes
		private const string MENSAJECONSULTAR="Se consultó las Actividades de Ordenes de Trabajo.";
		private const string TITULOPAGINA="ADMINISTRAR ORDEN DE TRABAJO: ";
		private const string TITULOCABECERAUNO="F. INICIO";
		private const string TITULOCABECERADOS="F. TERMINO";
		private const string MENSAJEELIMINO="Se eliminó la Actividad ID = ";
 		#endregion Constantes
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblActividad;
		protected System.Web.UI.WebControls.DropDownList ddlbActividad;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected projDataGridWeb.DataGridWeb dgActividad;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblDocumentoAprovacion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDocumentoAprovacion;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblMontoSaldo;
		#endregion
		#region Variables
		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		private string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
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
					this.LlenarJScript();
					this.ReiniciaCampos();
					this.LlenarCombos();
					this.LlenarDatos();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,false),Utilitario.Constantes.INDICEPAGINADEFAULT);
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJECONSULTAR ,Enumerados.NivelesErrorLog.I.ToString()));
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

		private void ReiniciaCampos()
		{
			this.hCodigo.Value="";
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
				this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXCINCO].Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXCUATRO].HeaderText=TITULOCABECERAUNO;
				this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXCINCO].HeaderText=TITULOCABECERADOS;
				this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXSEIS].Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
			}
			else
			{
				this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXDOS].Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXCUATRO].HeaderText="FECHA";
				this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXSEIS].Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
			}

		}

		private void ColumnasNoVisibleGrilla()
		{
			this.txtObservaciones.Text="";
			this.txtDocumentoAprovacion.Text ="";
			
			this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXDOS].Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL; //NroValorizacion
			this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXCINCO].Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL; //FechaTermino,
			this.dgActividad.Columns[Utilitario.Constantes.POSICIONINDEXSEIS].Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
			this.ReiniciaCampos();

		}

		private void dgActividad_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				HyperLink hlk=(HyperLink)e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].FindControl(CONTROLLINK);
				
		
				int LongitudCadena=30;

				if(dr[Utilitario.Enumerados.ColumnasActidadesOrdenTrabajoComoperpac.Descripcion.ToString()].ToString().Length>=LongitudCadena)
				{
					hlk.Text=dr[Utilitario.Enumerados.ColumnasActidadesOrdenTrabajoComoperpac.Descripcion.ToString()].ToString().Substring(VALORSUBSTRINGINICIO,LongitudCadena) + Utilitario.Constantes.PUNTOSSUSPENSIVOS;
				}
				else
				{
					hlk.Text=dr[Utilitario.Enumerados.ColumnasActidadesOrdenTrabajoComoperpac.Descripcion.ToString()].ToString();
				}
				
				
				string strUrlGoBack = URLDETALLEACTIVIDADORDENTRABAJOCOMOPERPAC + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDACTIVIDADESORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasActidadesOrdenTrabajoComoperpac.IdActividadesOrdenTrabajo.ToString()].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCENTROOPERATIVO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDESTADO] + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDORDENTRABAJOUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDORDENTRABAJOUNIDADAPOYO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQNROORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request[KEYQNROORDENTRABAJO] + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQTIPOACTIVIDADORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbActividad.SelectedValue +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQTIPOACTIVIDADDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + this.ddlbActividad.SelectedItem.Text;

				hlk.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				hlk.NavigateUrl=strUrlGoBack;

				string Cadena="";
				Cadena="AccionSeleccionFila('hCodigo','" + Convert.ToString(dr[Utilitario.Enumerados.ColumnasActidadesOrdenTrabajoComoperpac.IdActividadesOrdenTrabajo.ToString()]) + "'); "
					+ " LlenarControlesWebFormNet('" + Helper.LimpiarTexto(Convert.ToString(dr[Enumerados.ColumnasActidadesOrdenTrabajoComoperpac.DocumentoAprovacion.ToString()])) + "','" + Helper.LimpiarTexto(Convert.ToString(dr[Enumerados.ColumnasActidadesOrdenTrabajoComoperpac.Observaciones.ToString()])) + "'); ";
				
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
			this.Page.Response.Redirect(URLPRINCIPAL + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO] + Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO] + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCENTROOPERATIVO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDESTADO]);
		}

		private void ddlbActividad_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Helper.ReiniciarSession();
			this.LlenarGrillaOrdenamiento(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,false));
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Eliminar();
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.RedirecionarPaginaAgregar();
		}

		private void RedirecionarPaginaAgregar()
		{
			string URLAGREGAR = URLDETALLEACTIVIDADORDENTRABAJOCOMOPERPAC + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N +
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCENTROOPERATIVO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDESTADO] + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDORDENTRABAJOUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDORDENTRABAJOUNIDADAPOYO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQNROORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request[KEYQNROORDENTRABAJO] + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYQTIPOACTIVIDADORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbActividad.SelectedValue + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYQTIPOACTIVIDADDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + this.ddlbActividad.SelectedItem.Text;
				
			this.Page.Response.Redirect(URLAGREGAR);
		}

		private void dgActividad_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.dgActividad.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		#endregion

		private void dgActividad_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtDocumentoAprovacion_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		
	}
}
