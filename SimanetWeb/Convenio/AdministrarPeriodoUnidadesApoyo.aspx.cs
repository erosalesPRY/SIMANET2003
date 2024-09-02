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
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Aqui se administran los Convenios COMOPERPAC que se dan por periodos, al igual
	/// que los proyectos normal estos convenios contiene una o varias OT.
	/// Este formulario ya paso por refactoring
	/// </summary>
	public class AdministrarPeriodoUnidadesApoyo : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento 
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnOrdenTrabajo.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnOrdenTrabajo_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
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
			if(hCodigo.Value.Length==Utilitario.Constantes.ValorConstanteCero)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionConvenioUsuario(Mensajes.CODIGOMENSAJEUNIDADAPOYOELIMINAR));
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.PeriodoUnidadesApoyoTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEELIMINAR + hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
					//ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CODIGOMENSAJECONVENIOCOMOPERPACELIMINAR), URLADMINISTRARPERIODOUNIDADESAPOYO);
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					
				}
			}
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
			// TODO:  Add AdministracionOrganismo.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministracionOrganismo.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			return false;
		}

		#endregion
		#region IPaginaBase Members
		public void LlenarGrilla()
		{	}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{	}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CPeriodoUnidadesApoyo oCPeriodoUnidadesApoyo=new CPeriodoUnidadesApoyo();
			int PeriodoInicial=Convert.ToInt32(ddlbPeriodoInicial.SelectedItem.Text);
			int PeriodoFinal=Convert.ToInt32(ddlbPeriodoFinal.SelectedItem.Text);

			DataTable dtPeriodo = oCPeriodoUnidadesApoyo.ListarPeriodoUnidadesApoyo(PeriodoInicial,PeriodoFinal);

			if(dtPeriodo!=null)
			{
				DataView dwPeriodo = dtPeriodo.DefaultView;
				dwPeriodo.Sort = COLORDENAMIENTO;
				dwPeriodo.RowFilter = Utilitario.Helper.ObtenerFiltro(this);

				if(dwPeriodo.Count == Utilitario.Constantes.ValorConstanteCero)
				{
					grid.DataSource = null;
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible=true;
				}
				else
				{
					grid.DataSource = dtPeriodo;
					grid.CurrentPageIndex = indicePagina;
					lblResultado.Visible=false;

					grid.Columns[2].FooterText = dwPeriodo.Count.ToString();

				}
			}
			else
			{
				grid.DataSource = dtPeriodo;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
			}

			try
			{
				grid.CurrentPageIndex = indicePagina;
				grid.DataBind();
			}
			catch(Exception e)
			{
				string a = e.Message;
				grid.CurrentPageIndex = Utilitario.Constantes.POSICIONINDEXCERO;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			this.LlenarPeriodos();
			if(NullableIsNull.IsNullBoolean(this.Page.Request.Params[Utilitario.Constantes.KeyQPaginaValorInicial])==false)
			{
				ListItem lItem = new ListItem();
				lItem=ddlbPeriodoInicial.Items.FindByText(this.SeleccionPeriodoInicial(PERIODOBASE));
				if(lItem!=null)
				{
					lItem.Selected=true;
				}
			}
			else
			{
				Helper.SeleccionarItemCombos(this);
			}
		}

		public void LlenarDatos()
		{}

		public void LlenarJScript()
		{
			cbvPeriodos.ErrorMessage=Helper.ObtenerMensajesConfirmacionConvenioUsuario(Mensajes.CODIGOMENSAJEUNIDADAPOYOCOMOPERPACPERIODO);
			this.ibtnOrdenTrabajo.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCIONFILA);
			this.ibtnOrdenTrabajo.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,JSVERIFICARELIMINAR);
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

		//Ordenamiento
		private const string COLORDENAMIENTO="Periodo";

		//Mensajes
		private const string GRILLAVACIA="NO HAY REGISTROS";
		private const string MENSAJEELIMINAR="Se eliminó el Periodo COMOPERPAC Nro. ";

		//Controles
		private const string CONTROLINK="hlkId";

		//URL
		private const string URLDETALLEPERIODOUNIDADESAPOYO="DetallePeriodoUnidadesApoyo.aspx?";
		private const string URLADMINISTRARORDENTRABAJOCOMOPERPAC="AdministrarOrdenTrabajoComoperpac.aspx?";
		private const string URLADMINISTRARPERIODOUNIDADESAPOYO="AdministrarPeriodoUnidadesApoyo.aspx?";

		//Keys
		private const string KEYIDPERIODOUNIDADESAPOYO="IdPeriodoUnidadesApoyo";
		private const string KEYIDORDENTRABAJOUNIDADAPOYO="IdOrdenTrabajoUnidadApoyo";
		private	const string KEYQPERIODO="Periodo";
		private const string KEYIDCENTROOPERATIVO="IdCentroOperativo";
		private const string KEYIDESTADO="IdEstado";

		//Otros
		private const int PERIODOBASE=2000;
		private const int VALORADICIONALPERIODOINICIO=1;
		private const int VALORDIFERENCIAL=4;
		private const int PERIODOINICIAL=1845;
		private const int PERIODOFINAL=2050;
		

		#endregion Constantes		
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblPeriodoInicial;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodoInicial;
		protected System.Web.UI.WebControls.DomValidators.CompareDomValidator cbvPeriodos;
		protected System.Web.UI.WebControls.Label lblPeriodoFinal;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodoFinal;
		protected System.Web.UI.WebControls.Button btnConsultar;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.ImageButton ibtnOrdenTrabajo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIndice;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		#endregion
		#region Variables
		//Jscript
		private string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";

		//Otros
		private int PIDCENTROOPERATIVO=Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaCallao);
		private int PESTADOORDENTRABAJOCOMOPERPAC=Convert.ToInt32(Utilitario.Enumerados.ConvenioEstadoValorizacionConvenio.EnEjecucion);
		#endregion		
		#region Eventos
		private void RedireccionarPaginaAdminstrarOrdeneTrabajo()
		{
			if(!NullableString.Parse(this.hIndice.Value).IsNull)
			{
				string sPeriodo=hIndice.Value;

				this.Page.Response.Redirect(URLADMINISTRARORDENTRABAJOCOMOPERPAC + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value  + Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + hIndice.Value +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.PIDCENTROOPERATIVO.ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.PESTADOORDENTRABAJOCOMOPERPAC.ToString());
			}
			else
			{
				this.ltlMensaje.Text=Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.RedireccionarPaginaAgregar();
		}

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
			Helper.ReiniciarSession();
			this.ReiniciarControles();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,false),Utilitario.Constantes.INDICEPAGINADEFAULT);

		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLEPERIODOUNIDADESAPOYO,Utilitario.Constantes.KEYMODOPAGINA + 
					Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL +
					dr[Utilitario.Enumerados.ColumnasPeriodoUnidadesApoyo.IdPeriodoUnidadesApoyo.ToString()].ToString()));
	
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Font.Underline=true;
e.Item.Cells[0].ForeColor=Color.Blue;

				string Cadena="AccionSeleccionFila('hCodigo','"+ Convert.ToString(dr[Utilitario.Enumerados.ColumnasPeriodoUnidadesApoyo.IdPeriodoUnidadesApoyo.ToString()]) + "'); "
				//	+ " AccionSeleccionFila('hIndice','"+ e.Item.ItemIndex.ToString() + "'); "
					+ " AccionSeleccionFila('hIndice','"+ Convert.ToString(dr[Utilitario.Enumerados.ColumnasPeriodoUnidadesApoyo.Periodo.ToString()])+ "'); "
					+ " MostrarDatosEnCajaTexto('txtObservaciones','" + Helper.LimpiarTexto(dr[Utilitario.Enumerados.ColumnasPeriodoUnidadesApoyo.Observaciones.ToString()].ToString()) + "');"; 


				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Cadena);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			int PeriodoInicial=Convert.ToInt32(ddlbPeriodoInicial.SelectedItem.Text);
			int PeriodoFinal=Convert.ToInt32(ddlbPeriodoFinal.SelectedItem.Text);

			CPeriodoUnidadesApoyo oCPeriodoUnidadesApoyo = new CPeriodoUnidadesApoyo();
			DataTable dtPeriodo = oCPeriodoUnidadesApoyo.ListarPeriodoUnidadesApoyo(PeriodoInicial,PeriodoFinal);

			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(dtPeriodo
				,Utilitario.Enumerados.ColumnasPeriodoUnidadesApoyoFasub.Periodo.ToString() +";" + Utilitario.Enumerados.ColumnasPeriodoUnidadesApoyoFasub.Periodo.ToString() 
				,Utilitario.Enumerados.ColumnasPeriodoUnidadesApoyoFasub.Descripcion.ToString() +";" + Utilitario.Enumerados.ColumnasPeriodoUnidadesApoyoFasub.Descripcion.ToString());
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.ReiniciarControles();
					this.LlenarCombos();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,false),Utilitario.Constantes.INDICEPAGINADEFAULT);
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

		private string SeleccionPeriodoInicial(int pPeriodoInicial)
		{
			int SeleccionPeriodoInicial;
			if((DateTime.Now.Year-VALORDIFERENCIAL)<=pPeriodoInicial)
			{
				SeleccionPeriodoInicial=pPeriodoInicial;
			}
			else
			{
				SeleccionPeriodoInicial=DateTime.Now.Year-VALORDIFERENCIAL;
			}

			return SeleccionPeriodoInicial.ToString();
		}

		private void LlenarPeriodos()
		{
			ddlbPeriodoInicial.DataSource = Helper.ObtenerPeriodos(PERIODOINICIAL,DateTime.Now.Year+VALORADICIONALPERIODOINICIO);
			ddlbPeriodoInicial.DataBind();
			ddlbPeriodoInicial.SelectedValue=this.SeleccionPeriodoInicial(PERIODOBASE);
			ddlbPeriodoFinal.DataSource=Helper.ObtenerPeriodos(PERIODOINICIAL,PERIODOFINAL);
			ddlbPeriodoFinal.DataBind();
		}

		private void RedireccionarPaginaAgregar()
		{

			this.Page.Response.Redirect(URLDETALLEPERIODOUNIDADESAPOYO + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.PIDCENTROOPERATIVO.ToString() +
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.PESTADOORDENTRABAJOCOMOPERPAC.ToString());
		}

		private void ReiniciarControles()
		{
			this.hCodigo.Value="";
			this.hIndice.Value="";
			this.txtObservaciones.Text="";
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void ibtnOrdenTrabajo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.RedireccionarPaginaAdminstrarOrdeneTrabajo();
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					this.Eliminar();
				}
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
		#endregion
	}
}
