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
	public class AdministrarAgrupacionPAMC : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.HtmlControls.HtmlImage Img1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombre;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.ImageButton btnProyectos;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		#endregion	

		#region Constantes

		const string MENSAJEAGRUPAMIENTO = "No puede agregar un detalle porque la agrupacion tiene agrupacion(es) relacionada(s) a esta";
		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		private string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		const string COLORDENAMIENTO="Nombre";
		const string GRILLAVACIA="No existen Registros";
		const string URL = "AdministrarAgrupacionPAMC.aspx?";
		const string URLDETALLE = "DetalleAgrupacionPAMC.aspx?";
		const string URLSIGUIENTENIVEL="AdministrarDetalleAgrupacionPAMC.aspx?";
		
		
		
		const string KEYPAMCNIVEL="KEYPAMCNIVEL";
		const string KEYPAMCNOMBRENIVEL="KEYPAMCNOMBRENIVEL";
		const string KEYPAMCAGRUPACION="KEYPAMCAGRUPACION";
		#endregion

		#region Formula

		

		private double ObtenerUltimoPorcentaje(int idAgrupamiento)
		{
			CPAMDetalleAgrupacion oCPAMDetalleAgrupacion = new CPAMDetalleAgrupacion();

			DataTable dt = oCPAMDetalleAgrupacion.ListarTodosGrilla(idAgrupamiento);
			int cantidadniveles = 0;

			double varx=0;
			double resultado=0;

			if (dt!=null)
			{
				cantidadniveles = dt.Rows.Count;
				foreach(DataRow dr in dt.Rows)
				{
					varx = 	Convert.ToDouble(dr["avance"].ToString())/cantidadniveles ;
					resultado+=varx;
				}
			}
			else
				resultado = 0;

			return resultado;
		}

		private double BuscarSubNivelesRetornoPorcentaje(int idAgrupamientoHIJO)
		{
			CPAMCAgrupamientoAgrupamiento oCPAMCAgrupacionAgrupamiento = new CPAMCAgrupamientoAgrupamiento();
			double niveles=0;

			DataTable dt = oCPAMCAgrupacionAgrupamiento.ObtenerHijoAgrupamiento
				(idAgrupamientoHIJO);

			if (dt!=null)
			{
				foreach (DataRow dr in dt.Rows)
				{
					niveles = BuscarSubNivelesRetornoPorcentaje(
						Convert.ToInt32(dr["idAgrupacionPAMC"].ToString())
						);		

					return niveles/dt.Rows.Count;
				}
			}
			else
			{
				niveles = ObtenerUltimoPorcentaje(idAgrupamientoHIJO);		
			}

			return niveles;
		}

		private double CalcularPorcentaje()
		{
			CPAMCAgrupacion oCPAMCAgrupacion = new CPAMCAgrupacion();

			double retorno = 0;

			DataTable dt = oCPAMCAgrupacion.ListarTodosGrilla
				(Convert.ToInt32(Page.Request.QueryString[KEYPAMCNIVEL]));
			
			if(dt!=null)
				foreach(DataRow dr in dt.Rows)
					retorno+= BuscarSubNivelesRetornoPorcentaje(Convert.ToInt32(dr["idAgrupacionPAMC"].ToString()))/dt.Rows.Count;

			return retorno;
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
					
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),this.ToString(),"Se ingreso a la Consulta de Nivel Agrupamiento",Enumerados.NivelesErrorLog.I.ToString()));			
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

	
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public DataTable ObtenerDatos()
		{
			CPAMCAgrupacion oCPAMCAgrupacion = new CPAMCAgrupacion();
			DataTable dt;
			dt = oCPAMCAgrupacion.ListarTodosGrilla(Convert.ToInt32(Page.Request.QueryString[KEYPAMCNIVEL]));
			
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
			
			//this.Imagebutton1.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALATRAS);
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.btnProyectos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

			btnProyectos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCIONFILA);
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

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.PAMCAgrupacionTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
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
					KEYPAMCNOMBRENIVEL + Utilitario.Constantes.SIGNOIGUAL +	dr["nombre"].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYPAMCAGRUPACION + Utilitario.Constantes.SIGNOIGUAL + dr["idAgrupacionPAMC"].ToString()
					));

				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor=Color.Blue;
				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",
					dr["idAgrupacionPAMC"].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto(hNombre.ID,
					dr["nombre"].ToString())
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
			this.btnProyectos.Click += new System.Web.UI.ImageClickEventHandler(this.btnProyectos_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

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
				KEYPAMCNIVEL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYPAMCNIVEL] +
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
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,"nombre"+";Nombre");
		}

		private void btnProyectos_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(URLSIGUIENTENIVEL +
				KEYPAMCNIVEL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYPAMCNIVEL] +
				Utilitario.Constantes.SIGNOAMPERSON + 
				KEYPAMCAGRUPACION + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value +
				Utilitario.Constantes.SIGNOAMPERSON + 
				KEYPAMCNOMBRENIVEL + Utilitario.Constantes.SIGNOIGUAL + hNombre.Value
				);
		}

	

		


	}
}
