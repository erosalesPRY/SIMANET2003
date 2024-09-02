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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	public class AdministrarNivelPAMC : System.Web.UI.Page
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.btnComponentes.Click += new System.Web.UI.ImageClickEventHandler(this.btnComponentes_Click);
			this.ibtnDocumentos.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnDocumentos_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Controles
		protected System.Web.UI.WebControls.ImageButton ibtnDocumentos;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombre;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		#endregion
		
		#region Constantes

		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		private string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";

		const string URLDETALLE="DetalleNivelPAMC.aspx?";
		const string URLDETALLEDOCUMENTOS = "AdministrarDocumentosPAMC.aspx?";
		const string URLADMINISTRACION="AdministrarNivelPAMC.aspx?";
		
		const string URLSIGUIENTENIVEL="AdministrarAgrupacionPAMC.aspx?";
		
		const string KEYPAMCNIVEL="KEYPAMCNIVEL";
		const string KEYPAMCNOMBRENIVEL="KEYPAMCNOMBRENIVEL";
		
		const string COLORDENAMIENTO="nombre";
		protected System.Web.UI.WebControls.ImageButton btnComponentes;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		const string GRILLAVACIA="No existen Registros";
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

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.PAMCNivelTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),this.ToString(),"Se elimino" + hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
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

		#region Funcion Calcular Porcentaje
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

		private double CalcularPorcentaje(int idNivelPAMC)
		{
			CPAMCAgrupacion oCPAMCAgrupacion = new CPAMCAgrupacion();

			double retorno = 0;

			DataTable dt = oCPAMCAgrupacion.ListarTodosGrilla
				(idNivelPAMC);
			
			if(dt!=null)
				foreach(DataRow dr in dt.Rows)
					retorno+= BuscarSubNivelesRetornoPorcentaje(Convert.ToInt32(dr["idAgrupacionPAMC"].ToString()))/dt.Rows.Count;
			else
				retorno = 0;

			return retorno;
		}

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
			CMantenimientos oCMantenimientos =  new CMantenimientos();
			return oCMantenimientos.ListarTodosGrilla(Enumerados.ClasesNTAD.PAMCNivelNTAD.ToString());
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtNivel =  this.ObtenerDatos();
			
			if(dtNivel!=null)
			{
				DataView dwNivel = dtNivel.DefaultView;

				dwNivel.Sort = columnaOrdenar;

				dwNivel.RowFilter = Helper.ObtenerFiltro(this);
				if(dwNivel.Count>0)
				{
					
					grid.DataSource = dwNivel;
					grid.CurrentPageIndex = indicePagina;
					grid.Columns[Utilitario.Constantes.POSICIONINDEXUNO].FooterText = dwNivel.Count.ToString();
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
				grid.DataSource = dtNivel;
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
		}

		public void LlenarJScript()
		{
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnDocumentos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			btnComponentes.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN ,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnDocumentos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,JSVERIFICARSELECCIONFILA);
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
			btnComponentes.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,JSVERIFICARSELECCIONFILA);
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



		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,true),Helper.ObtenerIndicePagina());
					
					LogAplicativo.GrabarLogAplicativoArchivo(new 
						LogAplicativo(CNetAccessControl.GetUserName(),
						Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),
						this.ToString(),"Se ingreso a la Consulta de Nivel PAMC",
						Enumerados.NivelesErrorLog.I.ToString()));			
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
	
		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,
					KEYPAMCNIVEL + Utilitario.Constantes.SIGNOIGUAL + dr["idNivelPAMC"].ToString() +  
					Utilitario.Constantes.SIGNOAMPERSON + 
					Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()+
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYPAMCNOMBRENIVEL + Utilitario.Constantes.SIGNOIGUAL +	dr["nombre"].ToString()
					));

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto(hCodigo.ID,
					dr["idNivelPAMC"].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto(hNombre.ID,
					dr["NOMBRE"].ToString())
					);

				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor=Color.Blue;

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

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(URLDETALLE + 
				Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL +
				Enumerados.ModoPagina.N.ToString());
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

		private void ibtnDocumentos_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hCodigo.Value !=String.Empty)
				Response.Redirect(URLDETALLEDOCUMENTOS +
					KEYPAMCNIVEL + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value + 
					Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYPAMCNOMBRENIVEL + Utilitario.Constantes.SIGNOIGUAL + hNombre.Value);
			else
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,"nombre"+";Nombre"
				);
		}

		private void btnComponentes_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hCodigo.Value !=String.Empty)
			{
				Response.Redirect(URLSIGUIENTENIVEL + 
					KEYPAMCNIVEL + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYPAMCNOMBRENIVEL + Utilitario.Constantes.SIGNOIGUAL + hNombre.Value
					);
			}
			else
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
		}

	}
}
