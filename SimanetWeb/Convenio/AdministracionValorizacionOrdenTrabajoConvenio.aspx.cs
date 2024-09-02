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
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class AdministracionValorizacionOrdenTrabajoConvenio: System.Web.UI.Page,IPaginaBase	
	{
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected projDataGridWeb.DataGridWeb dgOrdenTrabajo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblProyectoDescripcion;
		protected System.Web.UI.WebControls.TextBox txtProyectoDescripcion;
		protected System.Web.UI.WebControls.Label lblTituloSecundario;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Button btnConsultar;
		protected System.Web.UI.WebControls.Label lblEstado;
		protected System.Web.UI.WebControls.Label lblCentroOperatico;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlbEstado;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.Button btnBuscarValorizacion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroValorizacion;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		

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
			this.btnBuscarValorizacion.Click += new System.EventHandler(this.btnBuscarValorizacion_Click);
			this.ddlbEstado.SelectedIndexChanged += new System.EventHandler(this.btnConsultar_Click);
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.dgOrdenTrabajo.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgOrdenTrabajo_SortCommand);
			this.dgOrdenTrabajo.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgOrdenTrabajo_PageIndexChanged);
			this.dgOrdenTrabajo.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgOrdenTrabajo_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
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
					this.LlenarCombos();
					this.ReiniciarNroValorizacion();
				    this.LlenarDatos();
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

		
		#region Constante
		const string GRILLAVACIA="No hay ordenes de trabajo según el criterio especificado";
		const int IDESTADOVALORIZACIONORDENTRABAJOCONVENIO=94;
		const string COLORDENAMIENTO="NROVALORIZACION";
		const int CONSULTARTODO = 0;
		const int POSICIONINICIALCOMBO=0;
		const string KEYIDCENTROOPERATIVO="IdCentroOperativo";

		//KEY
		const string KEYIDPROYECTOCONVENIO="IdProyectoConvenio";
		const string KEYQTITULOPRINCIPAL="TituloPrincipal";
		const string KEYQPROYECTODESCRIPCION="Descripcion";
		const string KEYIDVALORIZACIONORDENTRABAJO="IdValorizacionOrdenTrabajo";
		const string URLIMPRESION="";
		const string KEYIDCONVENIOSIMAMGP="IdConvenioSimaMgp";
		const string KEYQNROCONVENIO="NROCONVENIO";

		const string URLPRINCIPAL="AdministracionProyectoConvenio.aspx?";
		const string URLPAGINAAGREGRAR="DetalleValorizacionOrdenTrabajoConvenio.aspx?";
		const string URLPAGINAVALOTS="DetalleValorizacionOrdenTrabajoConvenioSimaMgpADM.aspx?";

		const string CONTROLINK="hlkId";

		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		//string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		

		#endregion Constante

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarValorizacionesOrdenesTrabajoConvenioSimaMgp.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CConvenioSimaMgp oConvenioSimaMgp=new CConvenioSimaMgp();
			int IdProyectoConvenio=Convert.ToInt32(Page.Request.Params[KEYIDPROYECTOCONVENIO]);
			string pEstado=this.ddlbEstado.SelectedValue;
			int IdCentroOperativo=Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue);
			DataTable dtOrdenTrabajo=new DataTable();
			if(NullableTypes.NullableString.Parse(this.hNroValorizacion.Value).IsNull)
			{
				dtOrdenTrabajo=oConvenioSimaMgp.ConsultarOrdenesDeTrabajoDeUnProyectoDeConvenio(IdProyectoConvenio,pEstado,CONSULTARTODO,IdCentroOperativo);
			}
			else
			{
				dtOrdenTrabajo=oConvenioSimaMgp.ConsultarOrdenesDeTrabajoDeUnProyectoDeConvenioSegunNroValorizacion(IdProyectoConvenio,hNroValorizacion.Value);
			}
			this.LimpiarControlesDetalle();
			this.reiniciarCampos();
			
			if(dtOrdenTrabajo!=null)
			{
				DataView dwOrdenTrabajo = dtOrdenTrabajo.DefaultView;
				dwOrdenTrabajo.Sort = columnaOrdenar;
				dgOrdenTrabajo.DataSource = dwOrdenTrabajo;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtOrdenTrabajo,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				ibtnImprimir.Visible = true;
				lblResultado.Visible = false;
				dgOrdenTrabajo.Columns[1].FooterText = dwOrdenTrabajo.Count.ToString();
			}
			else
			{
				dgOrdenTrabajo.DataSource = dtOrdenTrabajo;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				ibtnImprimir.Visible = false;
			}
			try
			{
				dgOrdenTrabajo.DataBind();
			}
			catch	
			{
				dgOrdenTrabajo.CurrentPageIndex = 0;
				dgOrdenTrabajo.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarValorizacionesOrdenesTrabajoConvenioSimaMgp.LlenarCombos implementation

			this.LlenarEstado();
			this.CentroOperativoSima();
			Helper.SeleccionarItemCombos(this);
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text = "CONVENIO SIMA - MGP  " +  Page.Request.Params[KEYQNROCONVENIO];
			this.txtProyectoDescripcion.Text = Convert.ToString(Page.Request.Params[KEYQPROYECTODESCRIPCION]);
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
		}

		public void LlenarJScript()
		{
			this.ibtnEliminar.Attributes.Add("onclick",JSVERIFICARELIMINAR);
			this.ltlMensaje.Text="document.forms[0].elements['hCodigo'].value='';";
			this.BusquedaValorizacionScriptJava();
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarValorizacionesOrdenesTrabajoConvenioSimaMgp.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			//ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);

		}

		public void Exportar()
		{
			// TODO:  Add ConsultarValorizacionesOrdenesTrabajoConvenioSimaMgp.Exportar implementation
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
			// TODO:  Add ConsultarValorizacionesOrdenesTrabajoConvenioSimaMgp.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void LimpiarControlesDetalle()
		{
			this.txtDescripcion.Text="";
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void dgOrdenTrabajo_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				e.Item.Cells[1].ToolTip=Utilitario.Constantes.ProyectoToolTipValorizacion;
				e.Item.Cells[2].ToolTip=Utilitario.Constantes.ProyectoToolTipOrdenTrabajo;
				e.Item.Cells[3].ToolTip=Utilitario.Constantes.ProyectoToolTipAlias;
				e.Item.Cells[4].ToolTip=Utilitario.Constantes.ProyectoToolTipMontoPresupuesto;
				e.Item.Cells[5].ToolTip=Utilitario.Constantes.ProyectoToolTipUnidadDependenciNaval;
				e.Item.Cells[6].ToolTip=Utilitario.Constantes.ProyectoToolTipEstado;
				e.Item.Cells[7].ToolTip=Utilitario.Constantes.ProyectoToolTipAvancaFisicoActual;
			}
			else if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				HyperLink hlk=(HyperLink)e.Item.Cells[1].FindControl(CONTROLINK);
				hlk.Text=Helper.ObtenerIndicedeRegistro(dgOrdenTrabajo.CurrentPageIndex,dgOrdenTrabajo.PageSize,e.Item.ItemIndex);

				hlk.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				
				hlk.NavigateUrl=URLPAGINAVALOTS + KEYIDVALORIZACIONORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasValorizacionOrdenTrabajo.IdValorizacionOrdenTrabajo.ToString()].ToString() + 
				Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQNROCONVENIO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQPROYECTODESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPROYECTODESCRIPCION] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDPROYECTOCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPROYECTOCONVENIO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbCentroOperativo.SelectedValue;
			
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor=Color.Blue;

				string Cadena="";
				Cadena="AccionSeleccionFila('hCodigo','" + dr[Utilitario.Enumerados.ColumnasValorizacionOrdenTrabajo.IdValorizacionOrdenTrabajo.ToString()].ToString() + "'); "
				+ " MostrarDatosEnCajaTexto('txtDescripcion','" + Helper.LimpiarTexto(Convert.ToString(dr[Enumerados.ColumnasValorizacionOrdenTrabajo.Descripcion.ToString()])) + "');";
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Cadena);
			}
		}

		private void RedireccionarPaginaPrevia()
		{
			this.Page.Response.Redirect(URLPRINCIPAL + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] + Utilitario.Constantes.SIGNOAMPERSON + 
				KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQNROCONVENIO]);
		}

		private void reiniciarCampos()
		{
			this.hCodigo.Value="";
		}
		
		private void redireccionaPaginaAgregar(string NombrePaginaAgregar)
		{
			
			this.Page.Response.Redirect
				(
				NombrePaginaAgregar + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQNROCONVENIO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQPROYECTODESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPROYECTODESCRIPCION] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDPROYECTOCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPROYECTOCONVENIO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbCentroOperativo.SelectedValue
				);
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaCallao)==Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue))
			{
				this.redireccionaPaginaAgregar(URLPAGINAAGREGRAR);
			}
			else
			{
				this.redireccionaPaginaAgregar(URLPAGINAVALOTS);
			}
		}

		private void dgOrdenTrabajo_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void CentroOperativoSima()
		{
			ListItem lItem = new ListItem();
			CCentroOperativo oCCentroOperativo=new CCentroOperativo();
			DataTable dt=oCCentroOperativo.ListarTodosCombo();
			this.ddlbCentroOperativo.DataSource=dt;
			this.ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			this.ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Descripcion.ToString();
			this.ddlbCentroOperativo.DataBind();
			lItem=this.ddlbCentroOperativo.Items.FindByValue(Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaPeru).ToString());
			this.ddlbCentroOperativo.Items.Remove(lItem);
			lItem=this.ddlbCentroOperativo.Items.FindByValue(Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaCallao).ToString());
			if(lItem!=null)
			{
				lItem.Selected=true;
			}
		}

		private void LlenarEstado()
		{
			//Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR
			ListItem lItem = new ListItem();
			lItem.Text=Utilitario.Constantes.TEXTOTODOS;
			lItem.Value=Utilitario.Constantes.VALORTODOS;
			
			CTablaTablas oCTablaTablas=new CTablaTablas();
			DataTable dt=oCTablaTablas.ListaTodosCombo(IDESTADOVALORIZACIONORDENTRABAJOCONVENIO);
			this.ddlbEstado.DataSource=dt;
			this.ddlbEstado.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlbEstado.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			this.ddlbEstado.DataBind();
			this.ddlbEstado.Items.Insert(POSICIONINICIALCOMBO,lItem);

			//lItem.Text=Utilitario.Constantes.TEXTOSSELECCIONAR;
			//lItem.Value=Utilitario.Constantes.VALORSELECCIONAR;
			//this.ddlbEstado.Items.Add(lItem);

		}

		private void ReiniciarNroValorizacion()
		{
			this.hNroValorizacion.Value="";
		}

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Convenio Sima - MGP",this.ToString(),"Se consultó las Ordenes de Trabajo.",Enumerados.NivelesErrorLog.I.ToString()));
			Helper.ReiniciarSession();
			this.ReiniciarNroValorizacion();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void dgOrdenTrabajo_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgOrdenTrabajo.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Eliminar();
		}
		private void Eliminar()
		{
			if(!NullableTypes.NullableString.Parse(this.hCodigo.Value).IsNull)
			{
				int IdValorizacion=Convert.ToInt32(this.hCodigo.Value);
				int IdUsuario=CNetAccessControl.GetIdUser();
				this.reiniciarCampos();
				CValorizacionOrdenTrabajoConvenio oCValorizacionOrdenTrabajoConvenio=new CValorizacionOrdenTrabajoConvenio();
				int retorno=0;
				retorno=oCValorizacionOrdenTrabajoConvenio.EliminarValorizacionConvenio(IdValorizacion,IdUsuario);
				if(retorno>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Valorizacion de Convenio",this.ToString(),"Se eliminó la Valorizacion ID = " + IdValorizacion.ToString() +"." ,Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
				}
			}
			else
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
		}

		private void BusquedaValorizacionScriptJava()
		{
			//INCIO: Codigo para Capturar la Valorizacion a Buscar.
			string CadenaShowModal="";
			string UrlBusqueda="BuquedaValorizacionConvenioSimaMgp.htm";
			CadenaShowModal="var Datos=new Array();  Datos=" + 
				Helper.WindowShowModalDialogCadenaJava(UrlBusqueda,150,290,100,100);
			CadenaShowModal=CadenaShowModal + "if(Datos!=null){ document.forms[0].elements['hNroValorizacion'].value=Datos[0];} else{return false;}";

			this.btnBuscarValorizacion.Attributes.Add("OnClick",CadenaShowModal);

			//FIN: de BUSQUEDA
		}

		private void btnBuscarValorizacion_Click(object sender, System.EventArgs e)
		{
			if(!NullableTypes.NullableString.Parse(this.hNroValorizacion.Value).IsNull)
			{
				Helper.ReiniciarSession();
				this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,false),Utilitario.Constantes.INDICEPAGINADEFAULT);
			}
		}

	}
}

