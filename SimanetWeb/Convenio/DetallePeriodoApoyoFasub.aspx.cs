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
using SIMA.EntidadesNegocio.General;
using SIMA.EntidadesNegocio.Convenio;
using SIMA.Controladoras.General;
using SIMA.Controladoras.Convenio;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;

namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Aquí se muestra el Detalle del Periodo, este formulario permite Agregar periodos
	/// desde 1845 hasta el 2050
	/// Este formulario ya paso por Refactory
	/// </summary>
	public class DetallePeriodoApoyoFasub : System.Web.UI.Page, IPaginaBase,IPaginaMantenimento
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
			PeriodoApoyoFasubBE oPeriodoApoyoFasubBE = new PeriodoApoyoFasubBE();
			oPeriodoApoyoFasubBE.IdUnidadApoyo = Convert.ToInt32(Page.Request.Params[KEYIDUNIDADAPOYO]);
			oPeriodoApoyoFasubBE.Periodo = Convert.ToInt32(nbPeriodo.Text);
			
			if (txtDescripcion.Text != "") oPeriodoApoyoFasubBE.Descripcion = txtDescripcion.Text;
			if (txtObservaciones.Text != "") oPeriodoApoyoFasubBE.Observaciones = txtObservaciones.Text;
			oPeriodoApoyoFasubBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oPeriodoApoyoFasubBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.PeriodoApoyoFasub);
			oPeriodoApoyoFasubBE.IdEstado = Convert.ToInt32(Enumerados.EstadosPeriodoUnidadesApoyoFasub.Activo);

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oPeriodoApoyoFasubBE);

			if(retorno > Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEREGISTRO  + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString()
					,Mensajes.CODIGOMENSAJEPERIODOAPOYOFASUBREGISTRO), URLADMINISTRARPERIODOUNIDADESAPOYOFASUB + KEYIDUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDUNIDADAPOYO].ToString());
			}
		}

		public void Modificar()
		{
			PeriodoApoyoFasubBE oPeriodoApoyoFasubBE= new PeriodoApoyoFasubBE();
			oPeriodoApoyoFasubBE.IdUnidadApoyo = Convert.ToInt32(Page.Request.Params[KEYIDUNIDADAPOYO].ToString());
			oPeriodoApoyoFasubBE.IdPeriodoApoyoFasub = Convert.ToInt32(Page.Request.Params[KEYIDPERIODOUNIDADESAPOYOFASUB].ToString());
			oPeriodoApoyoFasubBE.Periodo = Convert.ToInt32(nbPeriodo.Text); 
			oPeriodoApoyoFasubBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			oPeriodoApoyoFasubBE.Descripcion = txtDescripcion.Text;
			oPeriodoApoyoFasubBE.Observaciones = txtObservaciones.Text;


			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oPeriodoApoyoFasubBE);

			if(retorno>Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(), MENSAJEMODIFICO  + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO.ToString(),Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString()
					,Mensajes.CODIGOMENSAJEPERIODOAPOYOFASUBMODIFICACION),URLADMINISTRARPERIODOUNIDADESAPOYOFASUB + KEYIDUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDUNIDADAPOYO].ToString());
			}
		}
		public void Eliminar()
		{		}

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
			this.lblTitulo.Text= TITULOMODONUEVO;
		}

		public void CargarModoModificar()
		{
			this.lblTitulo.Text=TITULOMODOMODIFICAR;

			CPeriodoApoyoFasub oCPeriodoApoyoFasub = new CPeriodoApoyoFasub();
			PeriodoApoyoFasubBE oPeriodoApoyoFasubBE =(PeriodoApoyoFasubBE) oCPeriodoApoyoFasub.ListarDetalle(Convert.ToInt32(this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYOFASUB ]),Convert.ToInt32(this.Page.Request.Params[KEYIDUNIDADAPOYO]));


			if(oPeriodoApoyoFasubBE!=null)
			{
				nbPeriodo.Text = oPeriodoApoyoFasubBE.Periodo.ToString();
				if(!oPeriodoApoyoFasubBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text=oPeriodoApoyoFasubBE.Descripcion.ToString();
				}
				if(!oPeriodoApoyoFasubBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text=oPeriodoApoyoFasubBE.Observaciones.ToString();
				}
			}
		}

		public void CargarModoConsulta()
		{}

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
			this.rqdvPeriodo.ErrorMessage = Helper.ObtenerMensajesErrorConvenioUsuario(Utilitario.Mensajes.CODIGOMENSAJEPERIODOAPOYOFASUBPERIODOREQUERIDO);
			this.rqdvPeriodo.ToolTip = Helper.ObtenerMensajesErrorConvenioUsuario(Utilitario.Mensajes.CODIGOMENSAJEPERIODOAPOYOFASUBPERIODOREQUERIDO);
 			this.cmpvPeriodo.ErrorMessage = Helper.ObtenerMensajesErrorConvenioUsuario(Utilitario.Mensajes.CODIGOMENSAJEPERIODOAPOYOFASUBPERIOVALIDO);
			this.cmpvPeriodo.ToolTip = Helper.ObtenerMensajesErrorConvenioUsuario(Utilitario.Mensajes.CODIGOMENSAJEPERIODOAPOYOFASUBPERIOVALIDO);
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

		//URL's
		private const string URLADMINISTRARPERIODOUNIDADESAPOYOFASUB = "AdministrarPeriodoUnidadesApoyoFasub.aspx?";

		//Key Session y QueryString
		private const string KEYIDPERIODOUNIDADESAPOYOFASUB ="IdPeriodoApoyoFasub";
		private const string KEYIDUNIDADAPOYO="IdUnidadApoyo";
		private const string KEYQPERIODO = "Periodo";
		private const string KEYIDCENTROOPERATIVO = "IdCentroOperativo";
		private const string KEYIDESTADO = "IdEstado";
		private const string KEYQID="IdUnidadApoyo";

		//Mensajes
		private const string MENSAJEREGISTRO="Se registró el Periodo Nro. ";
		private const string MENSAJEMODIFICO="Se Modificó el Periodo Nro. ";
		private const string TITULOMODONUEVO="REGISTRAR DETALLE PERIODO DE UNIDADES DE APOYO";
		private const string TITULOMODOMODIFICAR="MANTENIMIENTO DETALLE PERIODO DE UNIDADES DE APOYO";
	
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblNroProyecto;
		protected eWorld.UI.NumericBox nbPeriodo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rqdvPeriodo;
		protected System.Web.UI.WebControls.DomValidators.RangeDomValidator cmpvPeriodo;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblEstado;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
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
				//ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(oSIMAExcepcionDominio.Error.Substring(16,5)));
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);
			}
			catch(Exception oException)
			{
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}

		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLADMINISTRARPERIODOUNIDADESAPOYOFASUB + KEYIDUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDUNIDADAPOYO].ToString());
		}

		#endregion									
	}
}
