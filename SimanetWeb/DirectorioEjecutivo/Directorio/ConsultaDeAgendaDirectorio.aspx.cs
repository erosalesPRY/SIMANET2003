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
using SIMA.Utilitario;
using SIMA.EntidadesNegocio.Secretaria.Directorio;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using SIMA.Controladoras.Secretaria.Directorio;
using System.Text;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class ConsultaDeAgendaDirectorio : System.Web.UI.Page
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblHora;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblLugar;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblNroSesion;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnBitacoraSesiones;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnLecturaActas;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnInformes;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnInformesDirectorEjecutivo;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnPedidos;
		protected System.Web.UI.WebControls.Label lblLugar1;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPosicionRegistro;
		#endregion Controles
		

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "IdSesionDirectorio";

		//Nombres de Controles
		const string CONTROLINK = "hlkId";
		const string CONTROCHECKBOX = "cbxEliminar";
		
		//Paginas
		const string URLSESIONES = "ConsultaSesionDirectorio.aspx";
		const string URLACTAS = "ConsultaActaSesionDirectorio.aspx";
		const string URLCONSULTAINFORMESDIRECTORES= "ConsultaInformeDirectoresSesionDirectorio.aspx";
		const string URLADMINISTRACIONINFORMESDIRECTORES= "AdministracionInformeDirectoresSesionDirectorio.aspx";

		const string URLINFORMESDIRECTORIO = "../InformeDirectorio.aspx";

		const string URLCONSULTAPEDIDOS = "ConsultaPedidoSesionDirectorio.aspx";
		const string URLADMINISTRACIONPEDIDOS = "AdministracionPedidoSesionDirectorio.aspx";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDSESION = "IdSesionDirectorio";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
			
		//Otros
		const string GRILLAVACIA ="No existe ninguna Sesión de Directorio.";  

		#endregion Constantes

		#region Variables
		#endregion Variables
		
					
		/// <summary>
		/// Elimina las Sesiones de Directorio seleccionadas
		/// </summary>
		private void eliminar()
		{
		}

		/// <summary>
		/// Limpia los valores ocultos
		/// </summary>
		private void reiniciarCampos()
		{
			//this.hCodigo.Value = "";

		}

		private void VerificarPerfil()
		{
			/*if(CNetAccessControl.GetIdProfile() == Utilitario.Constantes.PERFILDIRECTOREJECUTIVO)
			{
				ibtnInformes.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				ibtnInformes.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLCONSULTAINFORMESDIRECTORES,""));

				ibtnPedidos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				ibtnPedidos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLCONSULTAPEDIDOS,""));
			}
			else
			{*/
				ibtnInformes.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				ibtnInformes.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLADMINISTRACIONINFORMESDIRECTORES,"")
						+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

				ibtnPedidos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				ibtnPedidos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLADMINISTRACIONPEDIDOS,"")
						+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
			//}
		}

		private void ListarValoresSesion()
		{
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			SesionDirectorioBE oSesionDirectorioBE= (SesionDirectorioBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Helper.RetornaSessionParaDirectorio()),Enumerados.ClasesNTAD.SesionDirectorioNTAD.ToString());

			lblNroSesion.Text = oSesionDirectorioBE.NroSesionDirectorio;

			string [] aLugar = oSesionDirectorioBE.Lugar.Split('(');
			
			lblLugar.Text = aLugar[0].ToString().ToUpper();
			if(aLugar.Length > 1) 
			{
				lblLugar1.Text = "(" + aLugar[1].ToString().ToUpper();
			}
			//lblLugar.Text = oSesionDirectorioBE.Lugar;
			lblFecha.Text = oSesionDirectorioBE.Fecha.ToString(Utilitario.Constantes.FORMATOFECHA4);
			lblHora.Text = oSesionDirectorioBE.Fecha.ToString(Utilitario.Constantes.FORMATOHORA);
		}
		private void VerificarSesionDefault()
		{
			CSesionDirectorio oCSesionDirectorio = new CSesionDirectorio();
			DataTable dt = oCSesionDirectorio.ConsultarUltimaSesionDirectorio();

			if (HttpContext.Current.Session[Utilitario.Constantes.KEYSIDSESIONDIRECTORIO] == null && dt != null)
			{
				Helper.GeneraSessionParaDirectorio(dt.Rows[0][Utilitario.Constantes.IDSESIONDIRECTORIO].ToString());
			}
			else
			{
				this.AsignarSession();
			}
		}
		private void AsignarSession()
		{
			if (Page.Request.QueryString[KEYQIDSESION] != null)
			{
				Helper.GeneraSessionParaDirectorio(Page.Request.QueryString[KEYQIDSESION].ToString());
			}
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarDatos();
					
					this.LlenarJScript();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se consultó las Sesiones de Directorio.",Enumerados.NivelesErrorLog.I.ToString()));
					
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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

			this.reiniciarCampos();

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.VerificarSesionDefault();
			this.ListarValoresSesion();
			this.VerificarPerfil();
		}

		public void LlenarJScript()
		{
			ibtnBitacoraSesiones.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnBitacoraSesiones.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLSESIONES,"")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			ibtnLecturaActas.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnLecturaActas.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLACTAS,"")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			ibtnInformesDirectorEjecutivo.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnInformesDirectorEjecutivo.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLINFORMESDIRECTORIO,"")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
		}

		public void Imprimir()
		{
		}

		public void Exportar()
		{
			
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultaDeCartasFianzas.ConfigurarAccesoControles implementation

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

		/// <summary>
		/// Abre la Pagina para Agregar una Cuenta Bancaria
		/// </summary>
		private void redireccionaPaginaAgregar()
		{
		}

		private void imgAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();
		}

		private void imgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		
		private void imgExportarExcel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Exportar();
		}

		private void imgEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					this.eliminar();
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

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();										
		}
	}
}

