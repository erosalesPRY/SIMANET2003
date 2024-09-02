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
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Aquí se Administran las OT de un convenio realizado en un periodo especifico
	/// el boton eliminar no se encuentra porque las oTs se manejan por estados
	/// y mediante el combo podemos visualizar los estados.
	/// Este formulario ya paso por Refactoring
	/// </summary>
	public class AdministrarOrdenTrabajoComoperpac : System.Web.UI.Page, IPaginaBase
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
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			this.ibtnListarActividades.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnListarActividades_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
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
			COrdenTrabajoUnidadApoyo oCOrdenTrabajoUnidadApoyo=new COrdenTrabajoUnidadApoyo();
			DataTable dtOt=oCOrdenTrabajoUnidadApoyo.ListarOrdenTrabajoPeriodo(Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue),Convert.ToInt32(this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO]),Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ConvenioEstadoValorizacionConvenio),Convert.ToInt32(ddlbEstado.SelectedValue));
			
			if(dtOt!=null)
			{
				DataView dwOt = dtOt.DefaultView;
				dwOt.Sort = columnaOrdenar;
				grid.DataSource = dwOt;
				grid.Columns[1].FooterText = dwOt.Count.ToString();
				lblResultado.Visible = false;

				
			}
			else
			{
				grid.DataSource = dtOt;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			
			}
			try
			{
				grid.DataBind();
			}
			catch
			{
				grid.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			this.CentroOperativoSima();
			this.LlenarEstado();
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text= TITULO + this.Page.Request.Params[KEYQPERIODO];
		}

		public void LlenarJScript()
		{
			this.ibtnListarActividades.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCIONFILA);
			this.ibtnListarActividades.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
		}

		public void RegistrarJScript()
		{}

		public void Imprimir()
		{}

		public void Exportar()
		{}

		public void ConfigurarAccesoControles()
		{}

		public bool ValidarFiltros()
		{
			return false;
		}

		#endregion
		#region Constantes

		//Mensajes
		private const string TITULO="ORDENES DE TRABAJO DEL PERIODO ";
		private const string MENSAEJECONSULTAR="Se Consulto la Administració de Orden de Trabajo";
		private const string MENSAJEELIMINAR="Se elimino la OT COMOPERPAC Nro. ";

		//Grilla
		private const string GRILLAVACIA="NO HAY REGISTROS DE ORDENES DE TRABAJO";
		private const string COLORDENAMIENTO="NROORDENTRABAJO";

		//KEYs
		private const string KEYIDPERIODOUNIDADESAPOYO="IdPeriodoUnidadesApoyo";
		private const string KEYQPERIODO="Periodo";
		private const string KEYIDCENTROOPERATIVO="IdCentroOperativo";
		private const string KEYIDESTADO="IdEstado";
		private const string KEYIDORDENTRABAJOUNIDADAPOYO="IdOrdenTrabajoUnidadApoyo";
		private const string KEYQNROORDENTRABAJO="NroOrdenTrabajo";
		private const string KEYQTIPOACTIVIDADORDENTRABAJO="IdTipoActividad";

		//URL's
		private const string URLPRINCIPAL="AdministrarPeriodoUnidadesApoyo.aspx?";
		private const string URLADMINISTRACIONACTIVIDADORDENTRABAJOCOMOPERPAC="AdministracionActividadOrdenTrabajoComoperpac.aspx?";
		private const string URLPAGINAAGREGAR="DetalleOrdenTrabajoComoperpac.aspx?";
		private const string URLADMINISTRARORDENTRABAJOCOMOPERPAC="AdministrarOrdenTrabajoComoperpac.aspx?";

		//Otros
		private const int IDESTADOVALORIZACIONORDENTRABAJOCONVENIO=94;
		private const string CONTROLINK="hlkId";
		private const int POSICIONINICIALCOMBO=0;
		#endregion Constantes
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPeriodoInicial;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.Label lblEstado;
		protected System.Web.UI.WebControls.DropDownList ddlbEstado;
		protected System.Web.UI.WebControls.Button btnConsultar;
		protected System.Web.UI.WebControls.ImageButton ibtnListarActividades;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		#endregion
		#region Variables
		//Otros
		ListItem lItem = new ListItem();

		//Jscript
		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
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
					this.ReiniciarCampos();
					this.LlenarDatos();
					this.LlenarCombos();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,true),Utilitario.Constantes.INDICEPAGINADEFAULT);
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
		
		private void ReiniciarCampos()
		{
			this.hCodigo.Value="";
			this.txtObservaciones.Text="";
		}

		private void CentroOperativoSima()
		{
			ListItem lItem = new ListItem();
			SIMA.Controladoras.General.CCentroOperativo oCCentroOperativo=new CCentroOperativo();
			DataTable dt=oCCentroOperativo.ListarTodosCombo();
			this.ddlbCentroOperativo.DataSource=dt;
			this.ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			this.ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Descripcion.ToString();
			this.ddlbCentroOperativo.DataBind();
			lItem=this.ddlbCentroOperativo.Items.FindByValue(Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaPeru).ToString());
			this.ddlbCentroOperativo.Items.Remove(lItem);
			
			string cc=this.Page.Request.Params[KEYIDCENTROOPERATIVO];
			lItem=this.ddlbCentroOperativo.Items.FindByValue(cc);
			if(lItem!=null)
			{
				lItem.Selected=true;
			}
		}

		private void LlenarEstado()
		{
			CTablaTablas oCTablaTablas=new CTablaTablas();
			string CadenaFiltro=Utilitario.Enumerados.ColumnasTablaTablas.Var1.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(Utilitario.Constantes.ValorConstanteUno);
			DataView dv=oCTablaTablas.ListaSegunCriterioFiltro(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ConvenioEstadoValorizacionConvenio),CadenaFiltro);
			this.ddlbEstado.DataSource=dv;
			this.ddlbEstado.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlbEstado.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			this.ddlbEstado.DataBind();
			string estado=this.Page.Request.Params[KEYIDESTADO];
			
			lItem=this.ddlbEstado.Items.FindByValue(estado);
			if(lItem!=null)
			{
				lItem.Selected=true;
			}
		}

		private void redireccionaPaginaAgregar(string NombrePaginaAgregar)
		{
			this.Page.Response.Redirect
				(
					NombrePaginaAgregar + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbCentroOperativo.SelectedValue + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbEstado.SelectedValue
				);
		}

		private void RedireccionarPaginaPrevia()
		{
			this.Page.Response.Redirect(URLPRINCIPAL);
		}

		private void RedireccionarPaginaAdminstrarActividades()
		{
			if(!NullableTypes.NullableString.Parse(this.hCodigo.Value).IsNull)
			{
				int indice = Convert.ToInt32(this.hCodigo.Value);
				HyperLink hlk=(HyperLink)grid.Items[indice].FindControl(CONTROLINK);
				string sNroOt=hlk.Text;
				string URLLISTAR=URLADMINISTRACIONACTIVIDADORDENTRABAJOCOMOPERPAC +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDORDENTRABAJOUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.grid.DataKeys[indice].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQNROORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + sNroOt +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbCentroOperativo.SelectedValue + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbEstado.SelectedValue +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQTIPOACTIVIDADORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.TipoActividadOrdenTrabajoComoperpac.Trabajos).ToString();
				this.Page.Response.Redirect(URLLISTAR);
			}
			else
			{
				this.ltlMensaje.Text=Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
		}

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
			Helper.ReiniciarSession();
			this.ReiniciarCampos();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,true),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				HyperLink hlk = (HyperLink)e.Item.Cells[1].FindControl(CONTROLINK);
				hlk.Text = Convert.ToString(dr[Utilitario.Enumerados.ComoperpacOrdenTrabajoUnidadApoyo.NroOrdenTrabajo.ToString()]);
				
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor=Color.Blue;

				string URLMODIFICAR=URLPAGINAAGREGAR + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDORDENTRABAJOUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ComoperpacOrdenTrabajoUnidadApoyo.IdOrdenTrabajoUnidadApoyo.ToString()].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbCentroOperativo.SelectedValue + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbEstado.SelectedValue;
				
				hlk.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				hlk.NavigateUrl=URLMODIFICAR;
				
				string cadena="AccionSeleccionFila('hCodigo',"+ e.Item.ItemIndex.ToString() +"); " +
					Helper.MostrarDatosEnCajaTexto("txtObservaciones",Convert.ToString(dr[Utilitario.Enumerados.ComoperpacOrdenTrabajoUnidadApoyo.Observaciones.ToString()]));
				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,cadena);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
			}
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar(URLPAGINAAGREGAR);
		}

		private void ibtnListarActividades_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.RedireccionarPaginaAdminstrarActividades();
		}

	

		#endregion
	}
}
