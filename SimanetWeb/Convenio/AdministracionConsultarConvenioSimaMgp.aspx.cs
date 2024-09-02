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
	/// Aquí se administran los convenios que tiene SIMA con la MGP, puediendo  visualizar según su estado
	/// y Ver su Cronograma y sus los Proyectos Contenidos en el Convenio.
	/// Este formulario ya paso por Refactory
	/// </summary>
	public class AdministracionConsultarConvenioSimaMgp: System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
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
			this.ddlbEstado.SelectedIndexChanged += new System.EventHandler(this.ddlbEstado_SelectedIndexChanged);
			this.ibtnListaProyecto.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnListaProyecto_Click);
			this.ibtnCronogramaPagos.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCronogramaPagos_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.dgConvenio.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgConvenio_SortCommand);
			this.dgConvenio.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgConvenio_PageIndexChanged);
			this.dgConvenio.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConvenio_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IPaginaMantenimento Members
		public void Agregar()
		{}

		public void Modificar()
		{}

		public void Eliminar()
		{
			if(NullableString.Parse(this.hCodigo.Value).IsNull)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Utilitario.Enumerados.ClasesTAD.ConvenioSimaMgpTAD.ToString())>0)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEELIMINO + hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO ,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
				}
			}
		}
		public void CargarModoPagina()
		{}

		public void CargarModoNuevo()
		{}

		public void CargarModoModificar()
		{}

		public void CargarModoConsulta()
		{}

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

		#endregion
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministracionConsultarConvenioSimaMgp.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministracionConsultarConvenioSimaMgp.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CConvenioSimaMgp oCConvenioSimaMgp=new CConvenioSimaMgp();
			//DataTable dtConvenio=oCConvenioSimaMgp.ListarConvenioSimaMgp(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaEstadoConvenioSimaMgp),Convert.ToInt32(this.ddlbEstado.SelectedValue),Convert.ToInt32(Page.Request.QueryString[KEYIDIDENTIFICADOR]));
			DataTable dtConvenio=oCConvenioSimaMgp.ListarConvenioSimaMgp(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaEstadoConvenioSimaMgp),Convert.ToInt32(this.ddlbEstado.SelectedValue),Convert.ToInt32(hConv.Value));
			this.txtDescripcion.Text="";
			this.txtObservaciones.Text="";

			if(dtConvenio!=null)
			{
				DataView dwConvenio = dtConvenio.DefaultView;
				dwConvenio.Sort = columnaOrdenar;
				dgConvenio.DataSource = dwConvenio;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtConvenio,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				lblResultado.Visible = false;

				dgConvenio.Columns[2].FooterText = dwConvenio.Count.ToString();
			}
			else
			{
				dgConvenio.DataSource = dtConvenio;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;

			}
			try
			{
				dgConvenio.DataBind();
			}
			catch	
			{
				dgConvenio.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				dgConvenio.DataBind();
			}	
		}

		public void LlenarCombos()
		{
			CTablaTablas oCTablaTablas=new CTablaTablas();
			DataView dv=oCTablaTablas.ListaSegunCriterioFiltro(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaEstadoConvenioSimaMgp),Utilitario.Enumerados.ColumnasTablaTablas.Codigo + Utilitario.Constantes.SIGNODIFERENTEQUE + Convert.ToInt32(Utilitario.Enumerados.TablaEstadoConvenioSimaMgp.ELIMINADO).ToString());
			this.ddlbEstado.DataSource=dv;
			this.ddlbEstado.DataValueField = Utilitario.Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlbEstado.DataTextField = Utilitario.Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			this.ddlbEstado.DataBind();

			Helper.SeleccionarItemCombos(this);
		}

		public void LlenarDatos()
		{
			if(Page.Request.QueryString[KEYIDIDENTIFICADOR] != null)
				if(Convert.ToInt32(Page.Request.QueryString[KEYIDIDENTIFICADOR]) == 2)
				{
					hConv.Value = "2";
					lblTitulo.Text = "Administración de Convenios COMOPERAMA";
				}
				else if(Convert.ToInt32(Page.Request.QueryString[KEYIDIDENTIFICADOR]) == 3)
				{
					hConv.Value = "3";
					lblTitulo.Text = "Administración de Convenios DIMATEMAR";
				}
				else
				{hConv.Value = "1";}
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
			ibtnListaProyecto.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCIONFILA);
			ibtnCronogramaPagos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCIONFILA);
			ibtnListaProyecto.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnCronogramaPagos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			//ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hConv"));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministracionConsultarConvenioSimaMgp.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministracionConsultarConvenioSimaMgp.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministracionConsultarConvenioSimaMgp.Exportar implementation
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
			// TODO:  Add AdministracionConsultarConvenioSimaMgp.ValidarFiltros implementation
			return false;
		}

		#endregion
		#region Constantes

		//Ordenamiento
		private const string COLORDENAMIENTO="NroConvenio";

		//Mensajes
		private const string GRILLAVACIA="No existen registros";
		private const string MENSAJECONSULTAR="Listar Convenios Sima Mgp";
		private const string MENSAJEELIMINO="Se eliminó el Convenio ID = ";

		//KEYs
		private const string KEYIDIDENTIFICADOR= "IdIdentificador";
		private const string KEYIDCONVENIOSIMAMGP="IdConvenioSimaMgp";
		private const string KEYQNROCONVENIO="NroConvenio";
		private const string CONTROLINK="hlkId";

		//URL's
		private const string URLDETALLECONVENIOSIMAMGP = "DetalleConvenioSimaMgp.aspx?";
		private const string URLADMINISTRACIONPROYECTOCONVENIO="AdministracionProyectoConvenio.aspx?";
		private const string URLADMINISTRARCRONOGRAMAPAGOSCONVENIOSIMAMGP="AdministrarCronogramaPagosConvenioSimaMgp.aspx?";

		//Jscript
		private string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		
		#endregion Constantes
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblActividad;
		protected System.Web.UI.WebControls.DropDownList ddlbEstado;
		protected System.Web.UI.WebControls.ImageButton ibtnListaProyecto;
		protected System.Web.UI.WebControls.ImageButton ibtnCronogramaPagos;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIndice;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected projDataGridWeb.DataGridWeb dgConvenio;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hConv;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		#region Eventos
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
					this.reiniciarCampos();
					Helper.SeleccionarItemCombos(this);				
					this.LlenarDatos();
					
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,false),Helper.ObtenerIndicePagina());
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

		private void ddlbEstado_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Helper.ReiniciarSession();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,false),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void dgConvenio_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			try
			{
				if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
				{
					DataRowView drv = (DataRowView)e.Item.DataItem;
					DataRow dr = drv.Row;
				
					e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

					e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLECONVENIOSIMAMGP,Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + 
						Utilitario.Enumerados.ModoPagina.M.ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +  KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()])));
				
					e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Utilitario.Helper.ObtenerIndicedeRegistro(dgConvenio.CurrentPageIndex,dgConvenio.PageSize,e.Item.ItemIndex);
					e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Font.Underline=true;
					e.Item.Cells[0].ForeColor=Color.Blue;
					//e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hConv"));
					
					string cadena="AccionSeleccionFila('hCodigo','" + Convert.ToString(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()]) + "'); "
						+ " AccionSeleccionFila('hIndice','" + e.Item.ItemIndex.ToString() + "'); "
						+ " MostrarDescripcionObservaciones('txtDescripcion','txtObservaciones','"
						+ Helper.LimpiarTexto(Convert.ToString(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.Descripcion.ToString()])) + "','"
						+ Helper.LimpiarTexto(Convert.ToString(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.Observaciones.ToString()])) + "'); ";

					Helper.SeleccionarItemGrillaOnClickMoverRaton(e,cadena);
				}
			}
			catch(Exception ex){
				string s= ex.Message;
			}
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(Page.Request.QueryString[KEYIDIDENTIFICADOR] == null)
				Page.Response.Redirect(URLDETALLECONVENIOSIMAMGP + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
			else
				Page.Response.Redirect(URLDETALLECONVENIOSIMAMGP + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString() + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDIDENTIFICADOR + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDIDENTIFICADOR]);
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

		private void reiniciarCampos()
		{
			this.hCodigo.Value="";
			this.hIndice.Value="";
		}

		private void ibtnListaProyecto_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(!NullableString.Parse(this.hIndice.Value).IsNull)
			{
				Page.Response.Redirect(URLADMINISTRACIONPROYECTOCONVENIO + 
					KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value  +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + hIndice.Value +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDIDENTIFICADOR + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDIDENTIFICADOR]
					);
			}
			else
			{
				this.ltlMensaje.Text=Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
		}

		private void ibtnCronogramaPagos_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(!NullableString.Parse(this.hIndice.Value).IsNull)
			{
				Page.Response.Redirect(URLADMINISTRARCRONOGRAMAPAGOSCONVENIOSIMAMGP + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value  + Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + hIndice.Value );
			}
			else
			{
				this.ltlMensaje.Text=Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
		}

		private void dgConvenio_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.dgConvenio.CurrentPageIndex=e.NewPageIndex;
			HttpContext.Current.Session[Utilitario.Constantes.KEYSINDICEPAGINA] = e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void dgConvenio_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}
		#endregion
	}
}
