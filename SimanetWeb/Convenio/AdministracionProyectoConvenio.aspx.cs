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
	public class AdministracionProyectoConvenio : System.Web.UI.Page, IPaginaBase
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
			this.ibtnPrograma.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnPrograma_Click_1);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.dgConvenio.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgConvenio_SortCommand);
			this.dgConvenio.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgConvenio_PageIndexChanged);
			this.dgConvenio.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConvenio_ItemDataBound);
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
			DataTable dtConvenio=this.ConsultarProyectosConvenio(Convert.ToInt32(this.Page.Request.Params[KEYIDCONVENIOSIMAMGP]));
			this.txtDescripcion.Text="";
			this.txtObservaciones.Text="";

			if(dtConvenio!=null)
			{
				DataView dwConvenio = dtConvenio.DefaultView;
				dwConvenio.Sort = columnaOrdenar;
				dgConvenio.DataSource = dwConvenio;
				dgConvenio.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla();
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
				dgConvenio.CurrentPageIndex = Utilitario.Constantes.POSICIONINDEXCERO;
				dgConvenio.DataBind();
			}
		}

		public void LlenarCombos()
		{}

		public void LlenarDatos()
		{
			if(Convert.ToInt32(Page.Request.QueryString[KEYIDIDENTIFICADOR]) == 1)
			{
				lblRutaPagina.Text = lblRutaPagina.Text + " COMOPERA>";
				lblTitulo.Text = "Administración de Convenio COMOPERAMA";
			}
			else 
				lblRutaPagina.Text = "Administracion de Convenio SIMA-MGP";

			this.lblTitulo.Text=TITULO + this.Page.Request.Params[KEYQNROCONVENIO];
		}

		public void LlenarJScript()
		{
			ibtnPrograma.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCIONFILA);
			ibtnPrograma.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
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
		//Mensajes
		private const string MENSAJECONSULTAR="Listar Convenios Sima Mgp";
		private const string GRILLAVACIA="No se encontro ningun proyecto del Convenio";
		private const string TITULO="CONVENIO SIMA - MGP ";
		private const string MENSAJEELIMINO="Se eliminó el Proyecto ID = "; 

		//Keys
		private const string KEYIDCONVENIOSIMAMGP="IdConvenioSimaMgp";
		private const string KEYQNROCONVENIO="NroConvenio";
		private const string KEYQNROPROYECTO="NroProyecto";
		private const string KEYIDPROYECTOCONVENIO="IdProyectoConvenio";
		private const string KEYQDESCRIPCION="Descripcion";
		private const string KEYIDIDENTIFICADOR= "IdIdentificador";

		private const string KEYCONVENIO= "Convenio";
		private const string KEYACTIVIDAD= "Actividad";
		//Ordenamiento
		private const string COLORDENAMIENTO="NroProyecto";

		//URL's
		private const string URLDETALLEPROYECTOCONVENIO="DetalleProyectoConvenio.aspx?";
		private const string URLPRINCIPAL="AdministracionConsultarConvenioSimaMgp.aspx?";
		private const string URLADMINISTRACIONVALORIZACIONORDENTRABAJOCONVENIO="AdministracionValorizacionOrdenTrabajoConvenio.aspx?";
		
		private const string URLPROGRAMAACTIVIDADES = "AdministracionProgramaActividades.aspx?";

		//Otros
		private const string CONTROLINK="hlkId";

		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#endregion
		#region Variables
		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected projDataGridWeb.DataGridWeb dgConvenio;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIndice;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnPrograma;
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
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.reiniciarCampos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString() ,this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,true),Utilitario.Constantes.INDICEPAGINADEFAULT);
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

		private void reiniciarCampos()
		{
			this.hCodigo.Value="";
			this.hIndice.Value="";
		}

		private DataTable ConsultarProyectosConvenio(int IdConvenioSimaMgp)
		{
			CProyectoConvenio oCProyectoConvenio=new CProyectoConvenio();
			return oCProyectoConvenio.ListarProyectoConvenio(IdConvenioSimaMgp);
		}

		private void RedireccionarPrincipal()
		{
			this.Page.Response.Redirect(URLPRINCIPAL);
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

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();
		}

		private void redireccionaPaginaAgregar()
		{
			this.Page.Response.Redirect( URLDETALLEPROYECTOCONVENIO + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQNROCONVENIO] +
				Utilitario.Constantes.SIGNOAMPERSON +
				KEYIDIDENTIFICADOR + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDIDENTIFICADOR]);	
		}
		
		private void dgConvenio_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{			
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
								
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLEPROYECTOCONVENIO,Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M.ToString() + Utilitario.Constantes.SIGNOAMPERSON + 
					KEYIDPROYECTOCONVENIO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasProyectoConvenio.IdProyectoConvenio.ToString()].ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDCONVENIOSIMAMGP] + Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQNROCONVENIO]+
					Utilitario.Constantes.SIGNOAMPERSON + 
					KEYIDIDENTIFICADOR + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDIDENTIFICADOR]
					));
				
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Utilitario.Helper.ObtenerIndicedeRegistro(dgConvenio.CurrentPageIndex,dgConvenio.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[0].ForeColor=Color.Blue;
					
				string cadena="AccionSeleccionFila('hCodigo','" + Convert.ToString(dr[Utilitario.Enumerados.ColumnasProyectoConvenio.IdProyectoConvenio.ToString()]) + "'); "
					+ " AccionSeleccionFila('hIndice','" + e.Item.ItemIndex.ToString() + "'); "
					+ " MostrarDescripcionObservaciones('txtDescripcion','txtObservaciones','"
					+ Helper.LimpiarTextoMantenerFormatoOriginal(Convert.ToString(dr[Utilitario.Enumerados.ColumnasProyectoConvenio.Descripcion.ToString()])) + "','"
					+ Helper.LimpiarTextoMantenerFormatoOriginal(Convert.ToString(dr[Utilitario.Enumerados.ColumnasProyectoConvenio.Observaciones.ToString()])) + "')";

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,cadena);
			}
		}

		private void Eliminar()
		{
			if(NullableString.Parse(this.hCodigo.Value).IsNull)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();
				int retorno;
				
				retorno=oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Utilitario.Enumerados.ClasesTAD.ProyectoConvenioTAD.ToString());
				this.reiniciarCampos();

				if(retorno>0)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEELIMINO + hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO ,Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamiento(Helper.ObtenerColumnaOrdenamiento());
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
				}
			}
		}

		private void dgConvenio_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgConvenio.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void dgConvenio_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		#endregion

		private void ibtnPrograma_Click_1(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPROGRAMAACTIVIDADES + 
				KEYIDPROYECTOCONVENIO + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value  +
				Utilitario.Constantes.SIGNOAMPERSON +
				KEYCONVENIO + Utilitario.Constantes.SIGNOIGUAL + lblTitulo.Text +
				Utilitario.Constantes.SIGNOAMPERSON +
				KEYACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL + txtDescripcion.Text);				
		}
	}
}

