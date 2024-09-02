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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.Proyectos;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionComercial;
using NetAccessControl;
using System.IO;
using NullableTypes;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for PopupImpresionPlacaRegistroProyeectoCN.
	/// </summary>
	public class PopupImpresionPlacaRegistroProyeectoCN : System.Web.UI.Page, IPaginaMantenimento , IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblInformacion;
		protected System.Web.UI.WebControls.Label Label4;

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.Label lblTCentroOperativo;
		protected System.Web.UI.WebControls.Label lblTCapCombustible;
		protected System.Web.UI.WebControls.Label lblNroProyectoSima;
		protected System.Web.UI.WebControls.Label lblTNroProyectoSima;
		protected System.Web.UI.WebControls.Label lblCapAgua;
		protected System.Web.UI.WebControls.Label lblTCapAgua;
		protected System.Web.UI.WebControls.Label lblTipodeBuque;
		protected System.Web.UI.WebControls.Label lblTTipoBuque;
		protected System.Web.UI.WebControls.Label lblAnoFabricacion;
		protected System.Web.UI.WebControls.Label lblTAnoFabricacion;
		protected System.Web.UI.WebControls.Label lblCaracteristica;
		protected System.Web.UI.WebControls.Label lblTCaracteristica;
		protected System.Web.UI.WebControls.Label lblMotor;
		protected System.Web.UI.WebControls.Label lblTMotor;
		protected System.Web.UI.WebControls.Label lblPotencia;
		protected System.Web.UI.WebControls.Label lblTPotencia;
		protected System.Web.UI.WebControls.Label lblEslora;
		protected System.Web.UI.WebControls.Label lblTEslora;
		protected System.Web.UI.WebControls.Label lblManga;
		protected System.Web.UI.WebControls.Label lblTManga;
		protected System.Web.UI.WebControls.Label lblPuntal;
		protected System.Web.UI.WebControls.Label lblTPuntal;
		protected System.Web.UI.WebControls.Label lblCalado;
		protected System.Web.UI.WebControls.Label lblTCalado;
		protected System.Web.UI.WebControls.Label lblVelocidad;
		protected System.Web.UI.WebControls.Label lblTVelocidad;
		protected System.Web.UI.WebControls.Label lblDotacion;
		protected System.Web.UI.WebControls.Label lblTDotacion;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblDesplazamiento;
		protected System.Web.UI.WebControls.Label lblTDesplazamiento;
		#endregion
	
		
		#region Constantes
		const string SIGLAS="SIGLA2";
		const string MENSAJECONSULTAR = "Se consulto la placa dee Registro Proyectos CN";
		const string KEYIDREGISTROPROYECTOCN="IdRegistroProyectoCN";
		int idTablabuque = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaBuques);
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

		}

		public void CargarModoPagina()
		{

		}

		public void CargarModoNuevo()
		{
	
		}

		public void CargarModoModificar()
		{
			try
			{
				CMantenimientos	oCMantenimientos = new CMantenimientos();
				RegistroProyectoCNBE oRegistroProyectoCNBE = (RegistroProyectoCNBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOCN]),Enumerados.ClasesNTAD.RegistroProyectoCNNTAD.ToString());

				if (!oRegistroProyectoCNBE.NroProyecto.IsNull )
					lblTNroProyectoSima.Text = Convert.ToString(oRegistroProyectoCNBE.IdHistorico);
				else
					lblTNroProyectoSima.Text = Utilitario.Constantes.SIGNOMENOS;
				
				lblNombre.Text = oRegistroProyectoCNBE.Nombre;

		

				if (!oRegistroProyectoCNBE.IdCentroOperativo.IsNull)
				{
					DataRow dr;
					CCentroOperativo oCCentroOperativo = new CCentroOperativo();
					dr = oCCentroOperativo.DetalleCentroOperativo(Convert.ToInt32( oRegistroProyectoCNBE.IdCentroOperativo));

					lblTCentroOperativo.Text = dr[SIGLAS].ToString();
				}
				else
					lblTCentroOperativo.Text = Utilitario.Constantes.ESPACIO +  Utilitario.Constantes.SIGNOMENOS;

			
				if (!oRegistroProyectoCNBE.IdBuque.IsNull)
				{
					CTablaTablas oCTablaTablas = new CTablaTablas();
					//string textobuque = oCTablaTablas.ObtenerDescripcionCodigo(idTablabuque,Convert.ToInt32(oRegistroProyectoCNBE.IdBuque));

					string textobuque = CTablaTablas.ObtenerDescripcionCodigo(idTablabuque,Convert.ToInt32(oRegistroProyectoCNBE.IdBuque));
					lblTTipoBuque.Text = textobuque;
				}
				else
					lblTTipoBuque.Text = Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOMENOS;



				if ( !oRegistroProyectoCNBE.FechaPuestaQuilla.IsNull )
					lblTAnoFabricacion.Text = Convert.ToDateTime(oRegistroProyectoCNBE.FechaPuestaQuilla.ToString()).Year.ToString();
				else
					lblTAnoFabricacion.Text = Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOMENOS;


				if (!oRegistroProyectoCNBE.Observaciones.IsNull)
					lblTCaracteristica.Text = Convert.ToString(oRegistroProyectoCNBE.Observaciones);
				else
					lblTCaracteristica.Text = Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOMENOS;

			
				if (!oRegistroProyectoCNBE.Desplazamiento.IsNull)
					lblTDesplazamiento.Text = Convert.ToString(oRegistroProyectoCNBE.Desplazamiento);
				else
					lblTDesplazamiento.Text = Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOMENOS;

			
				if (!oRegistroProyectoCNBE.Motor.IsNull)
					lblTMotor.Text = Convert.ToString(oRegistroProyectoCNBE.Motor);
				else
					lblTMotor.Text = Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOMENOS;


				if (!oRegistroProyectoCNBE.Potencia.IsNull)
					lblTPotencia.Text = Convert.ToString(oRegistroProyectoCNBE.Potencia);
				else
					lblTPotencia.Text = Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOMENOS;


				if (!oRegistroProyectoCNBE.Combustible.IsNull)
					lblTCapCombustible.Text= Convert.ToString(oRegistroProyectoCNBE.Combustible);
				else
					lblTCapCombustible.Text = Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOMENOS;
	
				if (!oRegistroProyectoCNBE.Agua.IsNull)
					lblTCapAgua.Text = Convert.ToString(oRegistroProyectoCNBE.Agua);
				else
					lblTCapAgua.Text = Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOMENOS;

				if (!oRegistroProyectoCNBE.Eslora.IsNull )
					lblTEslora.Text =  Convert.ToString(oRegistroProyectoCNBE.Eslora);
				else
					lblTEslora.Text = Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOMENOS;

				if (!oRegistroProyectoCNBE.Manga.IsNull)
					lblTManga.Text = Convert.ToString(oRegistroProyectoCNBE.Manga);
				else
					lblTManga.Text = Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOMENOS;

				if (!oRegistroProyectoCNBE.Puntal.IsNull )
					lblTPuntal.Text= Convert.ToString(oRegistroProyectoCNBE.Puntal);
				else
					lblTPuntal.Text= Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOMENOS;
	
				if (!oRegistroProyectoCNBE.Calado.IsNull )
					lblTCalado.Text= Convert.ToString(oRegistroProyectoCNBE.Calado);
				else
					lblTCalado.Text= Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOMENOS;
	
				if (!oRegistroProyectoCNBE.Velocidad.IsNull)
					lblTVelocidad.Text=	Convert.ToString(oRegistroProyectoCNBE.Velocidad);
				else
					lblTVelocidad.Text= Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOMENOS;

				if (!oRegistroProyectoCNBE.Tripulacion.IsNull )
					lblTDotacion.Text = Convert.ToString(oRegistroProyectoCNBE.NroBodegas);
				else
					lblTDotacion.Text= Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOMENOS;
			}
			catch(Exception e)
			{
				string error=e.Message.ToString();
			}

		}

		public void CargarModoConsulta()
		{
	
		}

		public bool ValidarCampos()
		{
			if(this.ValidarCamposRequeridos())
			{
				return this.ValidarExpresionesRegulares();
			}
			else
			{
				return false;
			}
		}

		public bool ValidarCamposRequeridos()
		{

	return true;
			
		}

		public bool ValidarExpresionesRegulares()
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
					this.CargarModoModificar();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));			
					Helper.Imprimir();
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
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{

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

	}
}
