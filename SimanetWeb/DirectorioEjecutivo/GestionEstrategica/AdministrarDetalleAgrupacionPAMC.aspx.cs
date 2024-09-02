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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using SIMA.Controladoras;
namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	public class AdministrarDetalleAgrupacionPAMC : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.Label lblSeguimiento;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombre;
		protected System.Web.UI.WebControls.ImageButton btnTR;
		protected System.Web.UI.WebControls.ImageButton btnBitacora;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		#endregion
	
		#region Constantes
		const string KEYQIDPROYECTOAMC="IdProyectoAMC";
		const string COLORDENAMIENTO="Nombre";
		const string GRILLAVACIA="No existen Registros";

		const string URLDETALLE = "DetalleDetalleAgrupacionPAMC.aspx?";
		const string URLSIGUIENTENIVEL="AdministrarTerminosReferenciaPAMC.aspx?";
		const string URLBITACORAPRYAMC="../../Proyectos/AdministrarBitacoraProyectoAMC.aspx?";
		const string KEYPAMCNIVEL="KEYPAMCNIVEL";
		const string KEYNOMBREFOTO="KEYNOMBREFOTO";
		const string KEYPAMCNOMBRENIVEL="KEYPAMCNOMBRENIVEL";
		const string KEYPAMCAGRUPACION="KEYPAMCAGRUPACION";
		const string KEYPAMCDETALLEAGRUPACION = "KEYPAMCDETALLEAGRUPACION";
		private string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		#endregion

		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public DataTable ObtenerDatos()
		{
			CPAMDetalleAgrupacion oCPAMDetalleAgrupacion = new CPAMDetalleAgrupacion();
			return oCPAMDetalleAgrupacion.ListarTodosGrilla(Convert.ToInt32(Page.Request.QueryString[KEYPAMCAGRUPACION]));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtAgrupacion =  this.ObtenerDatos();
			
			if(dtAgrupacion!=null)
			{
				DataView dwAgrupacion = dtAgrupacion.DefaultView;

				dwAgrupacion.Sort = columnaOrdenar;
	
				dwAgrupacion.RowFilter = Helper.ObtenerFiltro(this);
				if(dwAgrupacion.Count>0)
				{
					grid.DataSource = dwAgrupacion;
					grid.Columns[Utilitario.Constantes.POSICIONINDEXUNO].FooterText = dwAgrupacion.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				
			}
			else
			{
				grid.DataSource = dtAgrupacion;
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
		}

		public void LlenarDatos()
		{
			lblSeguimiento.Text = Page.Request.QueryString[KEYPAMCNOMBRENIVEL]; 
		}

		public void LlenarJScript()
		{
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.btnTR.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,JSVERIFICARELIMINAR);
			this.btnTR.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCIONFILA);
			this.btnBitacora.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCIONFILA);
			this.btnBitacora.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
		}
		public void RegistrarJScript()
		{
	

		}

		public void Imprimir()
		{
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
			return true;
		}

		#endregion

		#region Eventos de la Grilla
		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
					Helper.MostrarVentana(
					URLDETALLE,
					KEYPAMCNIVEL + Utilitario.Constantes.SIGNOIGUAL +	Page.Request.QueryString[KEYPAMCNIVEL] +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYPAMCAGRUPACION + Utilitario.Constantes.SIGNOIGUAL +Page.Request.QueryString[KEYPAMCAGRUPACION] +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYPAMCDETALLEAGRUPACION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr["idDetalleAgrupacionPAMC"]) +  
					Utilitario.Constantes.SIGNOAMPERSON + 
					Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()+
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYPAMCNOMBRENIVEL + Utilitario.Constantes.SIGNOIGUAL + dr["Nombre"].ToString()
					));

				System.Web.UI.WebControls.Image ibtnArchivo = (System.Web.UI.WebControls.Image)e.Item.Cells[3].FindControl("ImgArchivo");	
				if ( dr["RutaPDF"].ToString()!= String.Empty)
				{
					ibtnArchivo.ImageUrl = "../../imagenes/ley1.gif";

					ibtnArchivo.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.PopupMostrarArchivos(
						Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTASERVERARCHIVOSPROYECTOAMC) + dr["RutaPDF"].ToString()));
				}				
				else
				{
					ibtnArchivo.ImageUrl = "../../imagenes/ley2.gif";
				}
				
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor=Color.Blue;

				Helper.SeleccionarItemGrillaOnClickMoverRaton
					(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto
					(hCodigo.ID,dr["idDetalleAgrupacionPAMC"].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto
					(hNombre.ID,dr["nombre"].ToString()));
					
				
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			HttpContext.Current.Session[Constantes.KEYSINDICEPAGINA]=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
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
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.PAMCDetalleAgrupacionTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),this.ToString(),"Se elimino" + hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
					this.LlenarGrillaOrdenamientoPaginacion("",Helper.ObtenerIndicePagina());
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
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarDatos();
					this.LlenarGrillaOrdenamientoPaginacion("",Helper.ObtenerIndicePagina());
					this.LlenarJScript();
					LogAplicativo.GrabarLogAplicativoArchivo(new 
						LogAplicativo(CNetAccessControl.GetUserName(),
						Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),this.ToString(),
						"SE INGRESO A DETALLE DE AGRUPACION",Enumerados.NivelesErrorLog.I.ToString()));			
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.btnBitacora.Click += new System.Web.UI.ImageClickEventHandler(this.btnBitacora_Click);
			this.btnTR.Click += new System.Web.UI.ImageClickEventHandler(this.btnTR_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(
				URLDETALLE +
				KEYPAMCNIVEL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYPAMCNIVEL] +
				Utilitario.Constantes.SIGNOAMPERSON +
				KEYPAMCAGRUPACION + Utilitario.Constantes.SIGNOIGUAL +	Page.Request.QueryString[KEYPAMCAGRUPACION] +
				Utilitario.Constantes.SIGNOAMPERSON +
				KEYPAMCNOMBRENIVEL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYPAMCNOMBRENIVEL] +
				Utilitario.Constantes.SIGNOAMPERSON +
				Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString()
				);
		}

		private void btnTR_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hCodigo.Value !=String.Empty)
				Response.Redirect(
					URLSIGUIENTENIVEL +
					KEYPAMCNIVEL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYPAMCNIVEL] +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYPAMCAGRUPACION + Utilitario.Constantes.SIGNOIGUAL +	Page.Request.QueryString[KEYPAMCAGRUPACION] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					KEYPAMCDETALLEAGRUPACION + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value +
					Utilitario.Constantes.SIGNOAMPERSON + 
					KEYPAMCNOMBRENIVEL + Utilitario.Constantes.SIGNOIGUAL + hNombre.Value
					);
			else
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));

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

		private void btnBitacora_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(URLBITACORAPRYAMC + KEYQIDPROYECTOAMC + 
				Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value);
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos(),
				"nombre"+";Nombre",
				"AVANCE"+";Avance"
				);
		}
	}
}
