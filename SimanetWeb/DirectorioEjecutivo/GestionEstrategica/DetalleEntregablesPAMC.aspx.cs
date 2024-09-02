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
	public class DetalleEntregablesPAMC : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
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
			this.rdbTerminado.CheckedChanged += new System.EventHandler(this.rdbTerminado_CheckedChanged);
			this.rdbInconcluso.CheckedChanged += new System.EventHandler(this.rdbInconcluso_CheckedChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IPaginaMantenimento Members
		public void Agregar()
		{
			PAMCEntregablesTerminoReferenciaBE oPAMCEntregablesTerminoReferenciaBE = new
				PAMCEntregablesTerminoReferenciaBE();

			if(txtDescripcion.Text !=String.Empty)
				oPAMCEntregablesTerminoReferenciaBE.Descripcion  = NullableString.Parse(txtDescripcion.Text);
			
			if(txtObservacion.Text !=String.Empty)
				oPAMCEntregablesTerminoReferenciaBE.Observaciones  = NullableString.Parse(txtObservacion.Text);

			
			if(txtNroExposicion.Text != String.Empty)
				oPAMCEntregablesTerminoReferenciaBE.NroExposicion = NullableInt32.Parse(txtNroExposicion.Text);

			if(rdbTerminado.Checked == true && rdbInconcluso.Checked == false )
				oPAMCEntregablesTerminoReferenciaBE.FlgTerminado = Utilitario.Constantes.ValorConstanteUno;
			else if (rdbTerminado.Checked == false && rdbInconcluso.Checked == true )
				oPAMCEntregablesTerminoReferenciaBE.FlgTerminado = Utilitario.Constantes.ValorConstanteCero;

            oPAMCEntregablesTerminoReferenciaBE.Nombre  = txtNombre.Text;

			if(calFechaVencimiento.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
				oPAMCEntregablesTerminoReferenciaBE.FechaCumplimiento = calFechaVencimiento.SelectedDate;


			oPAMCEntregablesTerminoReferenciaBE.FechaRegistro = DateTime.Now;
			oPAMCEntregablesTerminoReferenciaBE.IdConsultorPAMC = Convert.ToInt32(Page.Request.QueryString[KEYPAMCCONSULTORES]);
			
			oPAMCEntregablesTerminoReferenciaBE.IdEstado = Convert.ToInt32(Enumerados.EstadoGeneral.Activo);
			oPAMCEntregablesTerminoReferenciaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoGeneral);

			oPAMCEntregablesTerminoReferenciaBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
				
			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oPAMCEntregablesTerminoReferenciaBE);

			if(retorno>=Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Enumerados.NombresdeModulo.GestiónComercial.ToString() ,this.ToString(), "Se registro un Nivel" + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROPROCESO)) + Utilitario.Constantes.HISTORIALATRAS;
			}
		}

		public void Modificar()
		{
			PAMCEntregablesTerminoReferenciaBE oPAMCEntregablesTerminoReferenciaBE = new
				PAMCEntregablesTerminoReferenciaBE();

			if(txtNroExposicion.Text != String.Empty)
				oPAMCEntregablesTerminoReferenciaBE.NroExposicion = NullableInt32.Parse(txtNroExposicion.Text);

			if(txtDescripcion.Text !=String.Empty)
				oPAMCEntregablesTerminoReferenciaBE.Descripcion  = NullableString.Parse(txtDescripcion.Text);
			
			if(txtObservacion.Text !=String.Empty)
				oPAMCEntregablesTerminoReferenciaBE.Observaciones  = NullableString.Parse(txtObservacion.Text);

			if(rdbTerminado.Checked == true && rdbInconcluso.Checked == false )
				oPAMCEntregablesTerminoReferenciaBE.FlgTerminado = Utilitario.Constantes.ValorConstanteUno;
			else if (rdbTerminado.Checked == false && rdbInconcluso.Checked == true )
				oPAMCEntregablesTerminoReferenciaBE.FlgTerminado = Utilitario.Constantes.ValorConstanteCero;

			oPAMCEntregablesTerminoReferenciaBE.Nombre  = txtNombre.Text;

			oPAMCEntregablesTerminoReferenciaBE.FechaRegistro = DateTime.Now;
			oPAMCEntregablesTerminoReferenciaBE.IdConsultorPAMC = Convert.ToInt32(Page.Request.QueryString[KEYPAMCCONSULTORES]);

			
			if(calFechaVencimiento.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
				oPAMCEntregablesTerminoReferenciaBE.FechaCumplimiento = calFechaVencimiento.SelectedDate;
			
			oPAMCEntregablesTerminoReferenciaBE.IdEstado = Convert.ToInt32(Enumerados.EstadoGeneral.Activo);
			oPAMCEntregablesTerminoReferenciaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoGeneral);

			oPAMCEntregablesTerminoReferenciaBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
				
			oPAMCEntregablesTerminoReferenciaBE.IdEntregablesTerminosReferenciasPAMC = Convert.ToInt32(Page.Request.QueryString[KEYPAMCENTREGABLE]);

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oPAMCEntregablesTerminoReferenciaBE);

			if(retorno>=Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Enumerados.NombresdeModulo.GestiónComercial.ToString() ,this.ToString(), "Se registro un Nivel" + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
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

			PAMCEntregablesTerminoReferenciaBE oPAMCEntregablesTerminoReferenciaBE = (PAMCEntregablesTerminoReferenciaBE)oCMantenimientos.ListarDetalle(
				Convert.ToInt32(Page.Request.QueryString[KEYPAMCENTREGABLE]),Enumerados.ClasesNTAD.PAMCEntregablesTerminoReferenciaNTAD.ToString());

			if(oPAMCEntregablesTerminoReferenciaBE!=null)
			{
				txtNombre.Text = oPAMCEntregablesTerminoReferenciaBE.Nombre.ToString();
				txtDescripcion.Text = oPAMCEntregablesTerminoReferenciaBE.Descripcion.ToString();
				txtObservacion.Text = oPAMCEntregablesTerminoReferenciaBE.Observaciones.ToString();

				if(!oPAMCEntregablesTerminoReferenciaBE.FechaCumplimiento.IsNull)
					calFechaVencimiento.SelectedDate = Convert.ToDateTime(oPAMCEntregablesTerminoReferenciaBE.FechaCumplimiento);

				if(oPAMCEntregablesTerminoReferenciaBE.FlgTerminado == Utilitario.Constantes.ValorConstanteCero)
				{
					rdbInconcluso.Checked = true;
					rdbTerminado.Checked = false;
				}
				else
				{
					rdbInconcluso.Checked = false;
					rdbTerminado.Checked = true;
				}

				txtNroExposicion.Text = oPAMCEntregablesTerminoReferenciaBE.NroExposicion.ToString();
			}
		}

		public void CargarModoConsulta()
		{
		}

		public bool ValidarCampos()
		{
			if(rdbInconcluso.Checked == false && rdbTerminado.Checked == false)
				return Utilitario.Constantes.VALORUNCHECKEDBOOL;

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
			this.rfvNombre.ErrorMessage = MENSAJEERRORNOMBRE;
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
		#region Constantes
		const string KEYPAMCNIVEL="KEYPAMCNIVEL";
		const string KEYPAMCNOMBRENIVEL="KEYPAMCNOMBRENIVEL";
		const string KEYPAMCAGRUPACION="KEYPAMCAGRUPACION";
		const string KEYPAMCDETALLEAGRUPACION = "KEYPAMCDETALLEAGRUPACION";
		const string KEYPAMCTERMINOREFERENCIA="KEYPAMCTERMINOREFERENCIA";
		const string KEYPAMCCONSULTORES = "KEYPAMCCONSULTORES";
		const string KEYPAMCENTREGABLE= "KEYPAMCENTREGABLE";

		const string MENSAJEERRORNOMBRE = "Tiene que ingresar un Nombre para el Entregable";
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.Label lblTitulodos;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombre;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblTerminado;
		protected System.Web.UI.WebControls.RadioButton rdbTerminado;
		protected System.Web.UI.WebControls.RadioButton rdbInconcluso;
		protected System.Web.UI.WebControls.Label lblFechaVecimiento;
		protected eWorld.UI.CalendarPopup calFechaVencimiento;
		protected System.Web.UI.WebControls.Label Label1;
		protected eWorld.UI.NumericBox txtNroExposicion;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		#endregion		
		#region Eventos
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
						this.ToString(),"SE INGRESO AL DETALLE DE ENTREGABLES PAMC",
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

		#endregion

		private void rdbTerminado_CheckedChanged(object sender, System.EventArgs e)
		{
			rdbInconcluso.Checked = false;
		}

		private void rdbInconcluso_CheckedChanged(object sender, System.EventArgs e)
		{
			rdbTerminado.Checked = false;
		}
	}
}
