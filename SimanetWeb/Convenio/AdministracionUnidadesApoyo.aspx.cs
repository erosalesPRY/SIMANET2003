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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Diagnostics; 
using System.IO;
using SIMA.EntidadesNegocio.Convenio;

namespace SIMA.SimaNetWeb.Convenio
{
	public class AdministracionUnidadesApoyo: System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		/// <summary>
		/// Aquí se permite Administrar las Unidades de Apoyo Ejem: FASUB.
		/// Este Formulario ya paso por Refactory.
		/// </summary>
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.btnPeriodo.Click += new System.Web.UI.ImageClickEventHandler(this.btnPeriodo_Click);
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
			// TODO:  Add AdministracionOrganismo.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministracionOrganismo.Modificar implementation
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

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.UnidadApoyoTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEELIMINAR + hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CODIGOMENSAJEUNIDADAPOYOELIMINAR), URLADMINISTRACION);
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					
				}
			}
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministracionOrganismo.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministracionOrganismo.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministracionOrganismo.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministracionOrganismo.CargarModoConsulta implementation
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
			// TODO:  Add AdministracionOrganismo.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			// TODO: 
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CUnidadApoyo oCUnidadApoyo= new CUnidadApoyo();
			DataTable dtUnidadApoyo = oCUnidadApoyo.ConsultarUnidadesApoyo(); 

			dtUnidadApoyo = oCUnidadApoyo.ConsultarUnidadesApoyo();

			if(dtUnidadApoyo!=null)
			{
				DataView dwUnidadApoyo = dtUnidadApoyo.DefaultView;
				dwUnidadApoyo.Sort = COLORDENAMIENTO;
				dwUnidadApoyo.RowFilter = Utilitario.Helper.ObtenerFiltro(this);

				if(dwUnidadApoyo.Count == 0)
				{
					grid.DataSource = null;
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible=true;
				}
				else
				{
					grid.DataSource = dtUnidadApoyo;
					grid.CurrentPageIndex = indicePagina;
					grid.Columns[2].FooterText = dwUnidadApoyo.Count.ToString();
					lblResultado.Visible=false;

				}
			}
			else
			{
				grid.DataSource = dtUnidadApoyo;
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
				grid.CurrentPageIndex = POSICIONINICIAL;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleGestionesSecretaria.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleGestionesSecretaria.LlenarDatos implementation
		}
		public void LlenarJScript()
		{
			btnPeriodo.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCIONFILA);
			btnPeriodo.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,JSVERIFICARELIMINAR);
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));			
		}
		public void RegistrarJScript()
		{
			// TODO:  Add DetalleGestionesSecretaria.RegistrarJScript implementation
		}
		public void Imprimir()
		{
			// TODO:  Add DetalleGestionesSecretaria.Imprimir implementation
		}
		public void Exportar()
		{
			// TODO:  Add DetalleGestionesSecretaria.Exportar implementation
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
			// TODO:  Add DetalleGestionesSecretaria.ValidarFiltros implementation
			return true;
		}

		#endregion		
		#region Constantes
		//Key Session y QueryString
		private const string URLADMINISTRARPERIODOS="AdministrarPeriodoUnidadesApoyoFasub.aspx?";
		private const string KEYQID = "IdUnidadApoyo";
		private const string KEYQIDTABLAESTADO ="IdTablaEstado";
		private const int    POSICIONFOOTERTOTAL = 1;
		private const int POSICIONCONTADOR=0;
		private const int POSICIONINICIAL=0;

		//Grilla
		private const string COLORDENAMIENTO = "NOMBRE";
		private const string GRILLAVACIA = "No existe ningún registro";
		private const string URLADMINISTRACION="AdministracionUnidadesApoyo.aspx?";
		
		//Pagina Detalle Bitacora
		private const string URLDETALLE = "DetalleUnidadApoyo.aspx?";

		//JScript
		private string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		
		//Mensajes
		private const string MENSAJECONSULTAR="Se consultó las Unidades de Apoyo.";
		private const string MENSAJEELIMINAR="Se eliminó la Unidad de Apoyo Nro. ";
		#endregion Constantes
		#region Controles
		protected System.Web.UI.WebControls.ImageButton btnPeriodo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.Label lblSubTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));			
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

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			redireccionarPagina();
		}

		private void redireccionarPagina()
		{
			Page.Response.Redirect(URLDETALLE + 
				Utilitario.Constantes.KEYMODOPAGINA +  
				Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
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

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				
				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasUnidadApoyo.IdUnidadApoyo.ToString()]) +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()));
	
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor=Color.Blue;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Utilitario.Enumerados.ColumnasUnidadApoyo.IdUnidadApoyo.ToString()].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				NROREGISTROS+=1;
			}
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			CUnidadApoyo oCUnidadApoyo = new CUnidadApoyo();
			DataTable dtUnidadApoyo = oCUnidadApoyo.ConsultarUnidadesApoyo(); 

			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(dtUnidadApoyo
				,Enumerados.ColumnasUnidadApoyo.Nombre.ToString()+";Nombre"
				,Enumerados.ColumnasUnidadApoyo.Siglas.ToString()+";Siglas");

		}
		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void btnPeriodo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionarPaginaPeriodos();

		}

		private void redireccionarPaginaPeriodos()
		{
			Response.Redirect(URLADMINISTRARPERIODOS + KEYQID + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value);
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		#endregion
		#region Variables
		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		private int NROREGISTROS=0;
		#endregion
	}
}
