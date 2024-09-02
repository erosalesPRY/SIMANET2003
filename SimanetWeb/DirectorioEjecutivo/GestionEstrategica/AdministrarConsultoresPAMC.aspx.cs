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
	/// <summary>
	/// Summary description for AdministrarConsultoresPAMC.
	/// </summary>
	public class AdministrarConsultoresPAMC : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
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
			this.btnEntregables.Click += new System.Web.UI.ImageClickEventHandler(this.btnEntregables_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlImage Img1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.ImageButton btnEntregables;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombre;
		#endregion

		const string COLORDENAMIENTO="nombrecorto";
		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public DataTable ObtenerDatos()
		{
			CPAMCConsultor oCPAMCConsultor = new CPAMCConsultor();
			DataTable dt;
			dt = oCPAMCConsultor.ListarTodosGrilla(Convert.ToInt32(Page.Request.QueryString[KEYPAMCTERMINOREFERENCIA]));
			return dt;
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
			lblTitulo.Text = Page.Request.QueryString[KEYPAMCNOMBRENIVEL]; 
		}

		public void LlenarJScript()
		{
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.btnEntregables.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			btnEntregables.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCIONFILA);
			this.ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,JSVERIFICARELIMINAR);
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

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.PAMCConsultorTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
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
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarGrillaOrdenamientoPaginacion("",Helper.ObtenerIndicePagina());
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),this.ToString(),"Se ingreso a la Administracion de Consultores",Enumerados.NivelesErrorLog.I.ToString()));			
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

		


		#region Constantes
		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		private string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		const string URLDETALLE = "DetalleConsultorPAMC.aspx?";
		const string URLSIGUIENTENIVEL="AdministrarEntregablePAMC.aspx?";
		const string KEYPAMCNIVEL="KEYPAMCNIVEL";
		const string KEYPAMCNOMBRENIVEL="KEYPAMCNOMBRENIVEL";
		const string KEYPAMCAGRUPACION="KEYPAMCAGRUPACION";
		const string KEYPAMCDETALLEAGRUPACION = "KEYPAMCDETALLEAGRUPACION";
		const string KEYPAMCCONSULTORES = "KEYPAMCCONSULTORES";
		const string KEYPAMCTERMINOREFERENCIA="KEYPAMCTERMINOREFERENCIA";
		const string GRILLAVACIA="No existen registros";
		#endregion

		#region Metodos de Grilla
		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
			
					Helper.MostrarVentana(URLDETALLE,
					Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()+
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYPAMCTERMINOREFERENCIA + Utilitario.Constantes.SIGNOIGUAL +	dr["idTerminoReferenciaPAMC"].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYPAMCNOMBRENIVEL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYPAMCNOMBRENIVEL] +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYPAMCCONSULTORES + Utilitario.Constantes.SIGNOIGUAL + dr["idConsultor"]
					));

				System.Web.UI.WebControls.Image ibtnArchivo = (System.Web.UI.WebControls.Image)e.Item.Cells[2].FindControl("ImgArchivo");	
				if ( dr["rutaCurriculum"].ToString()!= "SIN DATA")
				{
					ibtnArchivo.ImageUrl = "../../imagenes/ley1.gif";

					ibtnArchivo.Attributes.Add(Utilitario.Constantes.EVENTOCLICK.ToString(),
						Helper.PopupMostrarArchivos(
						Helper.ObtenerRutaPDFs ( Utilitario.Constantes.RUTASERVERARCHIVOSPROYECTOAMC) + dr["rutaCurriculum"].ToString()
						));
				}
				else
				{
					ibtnArchivo.ImageUrl = "../../imagenes/ley2.gif";
				}

				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor=Color.Blue;
				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto(hCodigo.ID,
					dr["idConsultor"].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto(hNombre.ID,
					dr["NombreCorto"].ToString())
					);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			HttpContext.Current.Session[Constantes.KEYSINDICEPAGINA]=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		#endregion

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
			Response.Redirect(URLDETALLE  + 
				Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString() +
				Utilitario.Constantes.SIGNOAMPERSON + 
				KEYPAMCTERMINOREFERENCIA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYPAMCTERMINOREFERENCIA]+
				Utilitario.Constantes.SIGNOAMPERSON + 
				KEYPAMCNIVEL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYPAMCNIVEL] +
				Utilitario.Constantes.SIGNOAMPERSON +
				KEYPAMCDETALLEAGRUPACION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYPAMCDETALLEAGRUPACION] +
				Utilitario.Constantes.SIGNOAMPERSON +
				KEYPAMCNOMBRENIVEL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYPAMCNOMBRENIVEL]
				);
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		}

		private void btnEntregables_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(URLSIGUIENTENIVEL +
				KEYPAMCNIVEL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYPAMCNIVEL] +
				Utilitario.Constantes.SIGNOAMPERSON + 
				KEYPAMCAGRUPACION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYPAMCAGRUPACION]  +
				Utilitario.Constantes.SIGNOAMPERSON + 
				KEYPAMCDETALLEAGRUPACION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYPAMCDETALLEAGRUPACION]  +
				Utilitario.Constantes.SIGNOAMPERSON + 
				KEYPAMCTERMINOREFERENCIA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYPAMCTERMINOREFERENCIA]  +
				Utilitario.Constantes.SIGNOAMPERSON + 
				KEYPAMCCONSULTORES + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value +
				Utilitario.Constantes.SIGNOAMPERSON + 
				KEYPAMCNOMBRENIVEL + Utilitario.Constantes.SIGNOIGUAL + hNombre.Value
				);
		}


	

	
	}
}
