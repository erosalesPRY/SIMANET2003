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
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio.GestionEstrategica;
using System.IO;
using NullableTypes;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	public class DetalleTerminosReferenciaPAMC : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombre;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblRuta;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		#endregion
	
		#region Constantes
		const string URLDETALLE = "DetalleTerminosReferenciaPAMC.aspx?";
		const string URLSIGUIENTENIVEL="AdministrarEntregablePAMC.aspx.aspx?";
		const string KEYPAMCNIVEL="KEYPAMCNIVEL";
		const string KEYPAMCNOMBRENIVEL="KEYPAMCNOMBRENIVEL";
		const string KEYPAMCAGRUPACION="KEYPAMCAGRUPACION";
		const string KEYPAMCDETALLEAGRUPACION = "KEYPAMCDETALLEAGRUPACION";
		protected System.Web.UI.WebControls.Label lblNombreLargo;
		protected System.Web.UI.WebControls.TextBox txtNombreLargo;
		protected System.Web.UI.WebControls.Label Label1;
		protected eWorld.UI.NumericBox txtNroExposicion;
		const string KEYPAMCTERMINOREFERENCIA="KEYPAMCTERMINOREFERENCIA";
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.CargarModoPagina();
					this.LlenarJScript();

					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo
						(CNetAccessControl.GetUserName(),
						Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),
						this.ToString(),"Se ingreso a Detalle Agrupacion",
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
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		#region IPaginaMantenimento Members
		public void Agregar()
		{
			PAMCTerminoReferenciaBE oPAMCTerminoReferenciaBE = new PAMCTerminoReferenciaBE();

			oPAMCTerminoReferenciaBE.Nombre = txtNombre.Text;

			if(txtNombreLargo.Text!=String.Empty)
				oPAMCTerminoReferenciaBE.Nombrelargo = txtNombreLargo.Text;

			if(txtDescripcion.Text!=String.Empty)
				oPAMCTerminoReferenciaBE.Descripcion = txtDescripcion.Text;

			if(txtObservaciones.Text!=String.Empty)
				oPAMCTerminoReferenciaBE.Observaciones= txtObservaciones.Text;

			if(txtNroExposicion.Text !=String.Empty)
				oPAMCTerminoReferenciaBE.NroExposicion = NullableInt32.Parse(txtNroExposicion.Text);

			oPAMCTerminoReferenciaBE.IdEstado = Convert.ToInt32(Enumerados.EstadoGeneral.Activo);
			oPAMCTerminoReferenciaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoGeneral);

			oPAMCTerminoReferenciaBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oPAMCTerminoReferenciaBE.IdDetalleAgrupacionPAMC = Convert.ToInt32(Page.Request.QueryString[KEYPAMCDETALLEAGRUPACION]);

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oPAMCTerminoReferenciaBE);

			if(retorno>=Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Enumerados.NombresdeModulo.GestiónComercial.ToString() ,this.ToString(), "Se registro un T.R." + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROPROCESO)) + Utilitario.Constantes.HISTORIALATRAS;
			}
		}

		public void Modificar()
		{
			PAMCTerminoReferenciaBE oPAMCTerminoReferenciaBE = new PAMCTerminoReferenciaBE();

			oPAMCTerminoReferenciaBE.Nombre = txtNombre.Text;

			if(txtNombreLargo.Text!=String.Empty)
				oPAMCTerminoReferenciaBE.Nombrelargo = txtNombreLargo.Text;

			if(txtDescripcion.Text!=String.Empty)
				oPAMCTerminoReferenciaBE.Descripcion = txtDescripcion.Text;

			if(txtObservaciones.Text!=String.Empty)
				oPAMCTerminoReferenciaBE.Observaciones= txtObservaciones.Text;

			if(txtNroExposicion.Text !=String.Empty)
				oPAMCTerminoReferenciaBE.NroExposicion = NullableInt32.Parse(txtNroExposicion.Text);

			oPAMCTerminoReferenciaBE.IdEstado = Convert.ToInt32(Enumerados.EstadoGeneral.Activo);
			oPAMCTerminoReferenciaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoGeneral);

			oPAMCTerminoReferenciaBE.IdTerminoReferenciaPAMC = Convert.ToInt32(Page.Request.QueryString[KEYPAMCTERMINOREFERENCIA]);

			
			oPAMCTerminoReferenciaBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oPAMCTerminoReferenciaBE.IdDetalleAgrupacionPAMC = Convert.ToInt32(Page.Request.QueryString[KEYPAMCDETALLEAGRUPACION]);


			 
			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oPAMCTerminoReferenciaBE);

			if(retorno>=Utilitario.Constantes.ValorConstanteCero)
			{

				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Enumerados.NombresdeModulo.GestiónComercial.ToString() ,this.ToString(), "Se modifico un T.R." + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICARPROCESO)) + Utilitario.Constantes.HISTORIALATRAS;
			}
			
		}

		public void Eliminar()
		{
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
				case Enumerados.ModoPagina.C:
					this.CargarModoConsulta();
					break;
			}
		}

		public void CargarModoNuevo()
		{
		}

		public void CargarModoModificar()
		{
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			PAMCTerminoReferenciaBE oPAMCTerminoReferenciaBE = (PAMCTerminoReferenciaBE)oCMantenimientos.ListarDetalle(
				Convert.ToInt32(Page.Request.QueryString[KEYPAMCDETALLEAGRUPACION]),Enumerados.ClasesNTAD.PAMCTerminoReferenciaNTAD.ToString());

			if(oPAMCTerminoReferenciaBE!=null)
			{
				txtNombre.Text = oPAMCTerminoReferenciaBE.Nombre.ToString();
				txtDescripcion.Text = oPAMCTerminoReferenciaBE.Descripcion.ToString();
				txtObservaciones.Text = oPAMCTerminoReferenciaBE.Observaciones.ToString();
				txtNombreLargo.Text = oPAMCTerminoReferenciaBE.Nombrelargo.ToString();
				txtNroExposicion.Text = oPAMCTerminoReferenciaBE.NroExposicion.ToString();
			}
		}

		public void CargarModoConsulta()
		{
		}

		public bool ValidarCampos()
		{
			return Utilitario.Constantes.VALORCHECKEDBOOL;
		}

		public bool ValidarCamposRequeridos()
		{
				
			return Utilitario.Constantes.VALORCHECKEDBOOL;
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
		}

		#endregion

		#region IPaginaBase Members
		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
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
			this.rfvNombre.ErrorMessage = "Tiene que ingresar un Nombre para la Agrupación";
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

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(this.ValidarCampos())
				{
					Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;
					switch (oModoPagina)
					{
						case Enumerados.ModoPagina.N:
							this.Agregar();
							break;
						case Enumerados.ModoPagina.M:
							this.Modificar();
							break;
					}
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

	}
}
