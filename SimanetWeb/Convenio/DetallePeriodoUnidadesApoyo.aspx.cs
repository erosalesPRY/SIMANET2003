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
using SIMA.EntidadesNegocio.Convenio;
using SIMA.Controladoras.Convenio;
using SIMA.Controladoras.General;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;

namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Aquí se agregar y modificar los peridos de un convenio COMOPERPAC
	/// Este formulario ya paso por refactoring
	/// </summary>
	public class DetallePeriodoUnidadesApoyo : System.Web.UI.Page, IPaginaBase,IPaginaMantenimento
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
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.ibtnCancelar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IPaginaMantenimento Members

		public void Agregar()
		{
			PeriodoUnidadesApoyoBE oPeriodoUnidadesApoyoBE=new PeriodoUnidadesApoyoBE();
			oPeriodoUnidadesApoyoBE.IdPeriodoUnidadesApoyo=Convert.ToInt32(this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO]);
			oPeriodoUnidadesApoyoBE.Periodo=Convert.ToInt32(this.nbPeriodo.Text);
			oPeriodoUnidadesApoyoBE.Descripcion=this.txtDescripcion.Text;
			oPeriodoUnidadesApoyoBE.Observaciones=this.txtObservaciones.Text;
			oPeriodoUnidadesApoyoBE.IdTablaEstado=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ConvenioEstadoPeriodoUnidadesDeApoyo);
			oPeriodoUnidadesApoyoBE.IdEstado=Convert.ToInt32(Utilitario.Enumerados.ConvenioEstadoPeriodoUnidadesDeApoyo.Activo);
			oPeriodoUnidadesApoyoBE.IdUsuarioRegistro=CNetAccessControl.GetIdUser();

			//CPeriodoUnidadesApoyo oCPeriodoUnidadesApoyo=new CPeriodoUnidadesApoyo();
			
			int retorno= Utilitario.Constantes.ValorConstanteCero;
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			 retorno = oCMantenimientos.Insertar(oPeriodoUnidadesApoyoBE);

			//retorno=oCPeriodoUnidadesApoyo.Insertar(oPeriodoUnidadesApoyoBE);
			if(retorno==Utilitario.Constantes.VALORCONFIRMACIONREGISTRO)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEREGISTRAR + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CONVENIOREGISTROEXITOSO),URLPRINCIPAL);
			}
			else
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(retorno.ToString()));
			}
		}

		public void Modificar()
		{
			PeriodoUnidadesApoyoBE oPeriodoUnidadesApoyoBE=new PeriodoUnidadesApoyoBE();
			oPeriodoUnidadesApoyoBE.IdPeriodoUnidadesApoyo=Convert.ToInt32(this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO]);
			oPeriodoUnidadesApoyoBE.Descripcion=this.txtDescripcion.Text;
			oPeriodoUnidadesApoyoBE.Observaciones=this.txtObservaciones.Text;
			oPeriodoUnidadesApoyoBE.IdUsuarioActualizacion=CNetAccessControl.GetIdUser();

			CPeriodoUnidadesApoyo oCPeriodoUnidadesApoyo=new CPeriodoUnidadesApoyo();
			
			int retorno=Utilitario.Constantes.ValorConstanteCero;
			
						
			CMantenimientos oCMantenimientos = new CMantenimientos();
			 retorno = oCMantenimientos.Modificar(oPeriodoUnidadesApoyoBE);
			//retorno=oCPeriodoUnidadesApoyo.Modificar(oPeriodoUnidadesApoyoBE);
			
			if(retorno>Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo
					(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEMODIFICAR  + 
					oCPeriodoUnidadesApoyo.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONREGISTROSELECCIONADO),URLPRINCIPAL);

			}
		}

		public void Eliminar()
		{}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
			}
		}

		public void CargarModoNuevo()
		{
		}

		public void CargarModoModificar()
		{
			this.nbPeriodo.Enabled=false;

			CPeriodoUnidadesApoyo oCPeriodoUnidadesApoyo=new CPeriodoUnidadesApoyo();
			PeriodoUnidadesApoyoBE oPeriodoUnidadesApoyoBE=(PeriodoUnidadesApoyoBE)oCPeriodoUnidadesApoyo.DetallePeriodoUnidadesApoyo(Convert.ToInt32(this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO]));

			if(oPeriodoUnidadesApoyoBE!=null)
			{
				this.nbPeriodo.Text=oPeriodoUnidadesApoyoBE.Periodo.ToString();
				if(!oPeriodoUnidadesApoyoBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text=oPeriodoUnidadesApoyoBE.Descripcion.ToString();
				}
				if(!oPeriodoUnidadesApoyoBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text=oPeriodoUnidadesApoyoBE.Observaciones.ToString();
				}
			}
		}
		public void CargarModoConsulta()
		{
		}

		public bool ValidarCampos()
		{
			return true;
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
		#region IPaginaBase Members

		public void LlenarGrilla()
		{}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{}

		public void LlenarCombos()
		{}

		public void LlenarDatos()
		{}

		public void LlenarJScript()
		{
			this.rqdvPeriodo.ErrorMessage=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOREQUIEREPERIODO);
			this.ragvPeriodo.ErrorMessage= Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CODIGOMENSAJEPERIODOAPOYOFASUBPERIOVALIDO);
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
		//Url's
		private const string URLPRINCIPAL="AdministrarPeriodoUnidadesApoyo.aspx?";
		
		//Keys
		private const string KEYIDPERIODOUNIDADESAPOYO="IdPeriodoUnidadesApoyo";

		//Otros
		private const string PERIODOMAXIMO="1950";
		private const string PERIODOMINIMO="1845";

		//Mensajes
		private const string MENSAJEERRORFECHA="No puede registrar un periodo menor al año 2000 ni mayor al ";
		private const string MENSAJEREGISTRAR="Se registró Periodo COMOPERPAC ";
		private const string MENSAJEMODIFICAR="Se modificó Periodo COMOPERPAC Nro.";
		#endregion Constantes		
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected eWorld.UI.NumericBox nbPeriodo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rqdvPeriodo;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.DomValidators.RangeDomValidator ragvPeriodo;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		#endregion
		#region Eventos
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.CargarModoPagina();
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
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA]) ;
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
		private void RedireccionarPrincipal()
			{
				this.Page.Response.Redirect(URLPRINCIPAL);
			}

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(URLPRINCIPAL);
		}




		#endregion
	}
}
