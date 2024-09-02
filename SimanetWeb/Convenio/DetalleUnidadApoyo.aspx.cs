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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;

namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Aquí se Agregan y Modifican Unidades de Apoyo Ejem: FASUB
	/// Este Formulario ya paso por Refactory.
	/// </summary>
	public class DetalleUnidadApoyo : System.Web.UI.Page,IPaginaMantenimento,IPaginaBase
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
			UnidadApoyoBE oUnidadApoyoBE = new UnidadApoyoBE();
			oUnidadApoyoBE.Nombre = txtNombre.Text.ToUpper();
			oUnidadApoyoBE.Siglas = txtSiglas.Text.ToUpper();
			
			if (txtObservacion.Text != "") oUnidadApoyoBE.Observaciones = txtObservacion.Text;
 
			oUnidadApoyoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oUnidadApoyoBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.UnidadApoyo);
			oUnidadApoyoBE.IdEstado = Convert.ToInt32(Enumerados.EstadosUnidadApoyo.Activo);


			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oUnidadApoyoBE);

			if(retorno >0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEREGISTRO + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CODIGOMENSAJEUNIDADAPOYOREGISTRO),URLPRINCIPAL);
			}
		}

		public void Modificar()
		{
			UnidadApoyoBE oUnidadApoyoBE = new UnidadApoyoBE();
			oUnidadApoyoBE.IdUnidadApoyo =Convert.ToInt32(Page.Request.Params[KEYQID].ToString());
			oUnidadApoyoBE.Nombre  = txtNombre.Text; 
			oUnidadApoyoBE.Siglas = txtSiglas.Text;
			oUnidadApoyoBE.Observaciones = txtObservacion.Text;
			oUnidadApoyoBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oUnidadApoyoBE);

			if(retorno>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEMODIFICO + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CODIGOMENSAJEUNIDADAPOYOMODIFICACION),URLPRINCIPAL + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.Params[KEYQID].ToString()));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleAdministracionGestionesSecretaria.Eliminar implementation
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
			string h = Page.Request.QueryString[KEYQID].ToString();

			CMantenimientos	oCMantenimientos = new CMantenimientos();
			UnidadApoyoBE oUnidadApoyoBE = (UnidadApoyoBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID].ToString()), Enumerados.ClasesNTAD.UnidadApoyoNTAD.ToString());

			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJECONSULTA + Page.Request.QueryString[KEYQID] + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));

			if(oUnidadApoyoBE!=null)
			{
				txtNombre.Text = oUnidadApoyoBE.Nombre; 
				txtSiglas.Text = oUnidadApoyoBE.Siglas;

				if (!oUnidadApoyoBE.Observaciones.IsNull)
				txtObservacion.Text = oUnidadApoyoBE.Observaciones.ToString();		
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
		{
			
		}

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
			this.rfvNombre.ErrorMessage= Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CODIGOMENSAJEUNIDADAPOYONOMBREREQUERIDO);
			this.rfvNombre.ToolTip=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CODIGOMENSAJEUNIDADAPOYONOMBREREQUERIDO);

			this.rfvSiglas.ErrorMessage=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CODIGOMENSAJEUNIDADAPOYOSIGLASREQUERIDO);
			this.rfvSiglas.ToolTip=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CODIGOMENSAJEUNIDADAPOYOSIGLASREQUERIDO);
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

		//Key Session y QueryString
		private const string KEYQID = "IdUnidadApoyo";
		private const string KEYQIDTABLAESTADO ="IdTablaEstado";
		
		//Mensajes
		private const string MENSAJEREGISTRO="Se registró la Unidad de Apoyo Nro. ";
		private const string MENSAJEMODIFICO="Se Modificó la Unidad de Apoyo Nro. ";
		private const string MENSAJECONSULTA="Se consultó la Unidad de Apoyo Nro. ";

		//Paginas
		private const string URLPRINCIPAL="AdministracionUnidadesApoyo.aspx?";

		//Otros

		#endregion
		#region Controles
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombre;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvSiglas;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtSiglas;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		//protected System.Web.UI.WebControls.TextBox txtDescripcion;
		#endregion
		#region Eventos
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
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

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}

		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

		#endregion
	}
}
