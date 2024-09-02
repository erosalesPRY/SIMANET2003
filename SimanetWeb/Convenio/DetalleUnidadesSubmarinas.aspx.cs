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
	/// Summary description for DetalleUnidadesSubmarinas.
	/// </summary>
	public class DetalleUnidadesSubmarinas : System.Web.UI.Page,IPaginaMantenimento,IPaginaBase
	{
		#region Contrales
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.WebControls.Label lblNombreProyecto;
		protected System.Web.UI.WebControls.TextBox txtNombreProyecto;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblMontoAsignado;
		protected System.Web.UI.WebControls.Label lblMontoEjecutado;
		protected System.Web.UI.WebControls.Label lblMontoEnEjecucion;
		protected System.Web.UI.WebControls.Label lblMontoComprometido;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected eWorld.UI.NumericBox nbMontoAsignado;
		protected eWorld.UI.NumericBox nbMontoEjecutado;
		protected eWorld.UI.NumericBox nbMontoEnEjecucion;
		protected eWorld.UI.NumericBox nbMontoComprometido;
		
		protected System.Web.UI.HtmlControls.HtmlTableRow ControlTablaFilaMontoEjecutado;
		protected System.Web.UI.HtmlControls.HtmlTableRow ControlTablaFilaMontoEnEjecucion;
		protected System.Web.UI.HtmlControls.HtmlTableRow ControlTablaFilaMontoComprometido;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator RqdvNombreProyecto;
		protected System.Web.UI.WebControls.Label lblDescripcion;
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
					this.LlenarCombos();
					this.LlenarDatos();
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

		#region Constantes
		const string KEYIDUNIDADAPOYO="IdUnidadApoyo";
		const string KEYIDPERIODOUNIDADESAPOYOFASUB ="IdPeriodoApoyoFasub";
		const string KeyIdProyectoSubmarino="IdProyectoSubmarino";
		const string KeyIdTipoRegistro="IdTipoRegistro";
		//const string MensajeErrorFasub="Falta especificar el Nombre"; //"UDCE00021"

		const string ConstCodigoOrdenamientoGrid="hCodigoOrdenamientoGrid";
		const string ConsthCodigoIndicePaginaGrid="hCodigoIndicePaginaGrid";

		//URL.
		const string URLPRINCIPALADMI="AdministrarUnidadesSubmarinas.aspx";

		#endregion Constantes

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			int IdTipoRegistro=Convert.ToInt32(this.Page.Request.Params[KeyIdTipoRegistro]);
			
			ApoyoUnidadesFasubBE oApoyoUnidadesFasubBE=new ApoyoUnidadesFasubBE();

			oApoyoUnidadesFasubBE.Nombre=this.txtNombreProyecto.Text;
			oApoyoUnidadesFasubBE.MontoAsignado=NullableDouble.Parse(this.nbMontoAsignado.Text);
			oApoyoUnidadesFasubBE.MontoEjecutado=NullableDouble.Parse(this.nbMontoEjecutado.Text);
			oApoyoUnidadesFasubBE.MontoEnEjecucion=NullableDouble.Parse(this.nbMontoEnEjecucion.Text);
			oApoyoUnidadesFasubBE.MontoComprometido=NullableDouble.Parse(this.nbMontoComprometido.Text);
			oApoyoUnidadesFasubBE.IdTipoRegistro=IdTipoRegistro;
			oApoyoUnidadesFasubBE.IdUsuarioRegistro=CNetAccessControl.GetIdUser();
			oApoyoUnidadesFasubBE.Descripcion=NullableString.Parse(this.txtDescripcion.Text);
			oApoyoUnidadesFasubBE.Observaciones=NullableString.Parse(this.txtObservaciones.Text);
			oApoyoUnidadesFasubBE.IdPeriodoApoyoFasub = Convert.ToInt32(Page.Request.QueryString[KEYIDPERIODOUNIDADESAPOYOFASUB]);
			oApoyoUnidadesFasubBE.IdUnidadApoyo = Convert.ToInt32(Page.Request.QueryString[KEYIDUNIDADAPOYO]);

			CApoyoUnidadesFasub oCApoyoUnidadesFasub=new CApoyoUnidadesFasub();
			int retorno=0;
			retorno=oCApoyoUnidadesFasub.Insertar(oApoyoUnidadesFasubBE);
			if(retorno>0)
			{
				//string strUrlGoBack =URLPRINCIPALADMI;
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Utilitario.Mensajes.CONVENIOREGISTROEXITOSO));
			}
		}

		public void Modificar()
		{
			int IdProyectoSubMarino=Convert.ToInt32(this.Page.Request.Params[KeyIdProyectoSubmarino]);
			ApoyoUnidadesFasubBE oApoyoUnidadesFasubBE=new ApoyoUnidadesFasubBE();

			oApoyoUnidadesFasubBE.IdProyectoSubmarino=IdProyectoSubMarino;
			oApoyoUnidadesFasubBE.Nombre=this.txtNombreProyecto.Text;
			oApoyoUnidadesFasubBE.MontoAsignado=NullableDouble.Parse(this.nbMontoAsignado.Text);
			oApoyoUnidadesFasubBE.MontoEjecutado=NullableDouble.Parse(this.nbMontoEjecutado.Text);
			oApoyoUnidadesFasubBE.MontoEnEjecucion=NullableDouble.Parse(this.nbMontoEnEjecucion.Text);
			oApoyoUnidadesFasubBE.MontoComprometido=NullableDouble.Parse(this.nbMontoComprometido.Text);
			oApoyoUnidadesFasubBE.IdUsuarioActualizacion=CNetAccessControl.GetIdUser();
			oApoyoUnidadesFasubBE.Descripcion=NullableString.Parse(this.txtDescripcion.Text);
			oApoyoUnidadesFasubBE.Observaciones=NullableString.Parse(this.txtObservaciones.Text);
			
			oApoyoUnidadesFasubBE.IdUnidadApoyo = Convert.ToInt32(Page.Request.QueryString[KEYIDUNIDADAPOYO]);

			CApoyoUnidadesFasub oCApoyoUnidadesFasub=new CApoyoUnidadesFasub();
			int retorno=0;
			retorno=oCApoyoUnidadesFasub.Modificar(oApoyoUnidadesFasubBE);
			if(retorno>0)
			{
				//string strUrlGoBack =URLPRINCIPALADMI + "?" + ConstCodigoOrdenamientoGrid + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[ConstCodigoOrdenamientoGrid] + Utilitario.Constantes.SIGNOAMPERSON + ConsthCodigoIndicePaginaGrid + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[ConsthCodigoIndicePaginaGrid];
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONREGISTROSELECCIONADO));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleUnidadesSubmarinas.Eliminar implementation
		}

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
				case Enumerados.ModoPagina.C:
					this.CargarModoConsulta();
					break;
			}
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalleUnidadesSubmarinas.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			int IdProyectoFasub=Convert.ToInt32(this.Page.Request.Params[KeyIdProyectoSubmarino]);
			CApoyoUnidadesFasub oCApoyoUnidadesFasub=new CApoyoUnidadesFasub();
			ApoyoUnidadesFasubBE oApoyoUnidadesFasubBE=(ApoyoUnidadesFasubBE)oCApoyoUnidadesFasub.DetalleProyectoSubMarino(IdProyectoFasub);

			this.txtNombreProyecto.Text=oApoyoUnidadesFasubBE.Nombre;
			if(!oApoyoUnidadesFasubBE.MontoAsignado.IsNull)
			{
				this.nbMontoAsignado.Text=Convert.ToDouble(oApoyoUnidadesFasubBE.MontoAsignado).ToString();
			}
			if(!oApoyoUnidadesFasubBE.MontoEjecutado.IsNull)
			{
				this.nbMontoEjecutado.Text=Convert.ToDouble(oApoyoUnidadesFasubBE.MontoEjecutado).ToString();
			}
			if(!oApoyoUnidadesFasubBE.MontoEnEjecucion.IsNull)
			{
				this.nbMontoEnEjecucion.Text=Convert.ToDouble(oApoyoUnidadesFasubBE.MontoEnEjecucion).ToString();
			}
			if(!oApoyoUnidadesFasubBE.MontoComprometido.IsNull)
			{
				this.nbMontoComprometido.Text=Convert.ToDouble(oApoyoUnidadesFasubBE.MontoComprometido).ToString();
			}
			if(!oApoyoUnidadesFasubBE.Descripcion.IsNull)
			{
				this.txtDescripcion.Text=oApoyoUnidadesFasubBE.Descripcion.Value.ToString();
			}
			if(!oApoyoUnidadesFasubBE.Observaciones.IsNull)
			{
				this.txtObservaciones.Text=oApoyoUnidadesFasubBE.Observaciones.Value.ToString();
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleUnidadesSubmarinas.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			/*if(NullableString.Parse(this.txtNombreProyecto.Text).IsNull)
			{
				this.ltlMensaje.Text=Helper.MensajeAlert(MensajeErrorFasub);
				return false;
			}*/
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleUnidadesSubmarinas.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleUnidadesSubmarinas.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleUnidadesSubmarinas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleUnidadesSubmarinas.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleUnidadesSubmarinas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleUnidadesSubmarinas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.ControlesVisiblesSegunTipoRegistro();
		}

		public void LlenarJScript()
		{
			this.RqdvNombreProyecto.ErrorMessage=Helper.ObtenerMensajesErrorConvenioUsuario(Utilitario.Mensajes.CODIGOMENSAJEUNIDADAPOYONOMBREREQUERIDO);
			this.RqdvNombreProyecto.ToolTip=Helper.ObtenerMensajesErrorConvenioUsuario(Utilitario.Mensajes.CODIGOMENSAJEUNIDADAPOYONOMBREREQUERIDO);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleUnidadesSubmarinas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleUnidadesSubmarinas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleUnidadesSubmarinas.Exportar implementation
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
			// TODO:  Add DetalleUnidadesSubmarinas.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ControlesVisiblesSegunTipoRegistro()
		{
			if(this.Page.Request.Params[KeyIdTipoRegistro].ToString()==Convert.ToInt32(Utilitario.Enumerados.ApoyoUnidadSubMarinoTipoProyectos.PartidaAsignada).ToString())
			{
				this.ControlTablaFilaMontoEjecutado.Visible=false;
				this.nbMontoEjecutado.Visible=false;
				this.ControlTablaFilaMontoEnEjecucion.Visible=false;
				this.nbMontoEnEjecucion.Visible=false;
				this.ControlTablaFilaMontoComprometido.Visible=false;
				this.nbMontoComprometido.Visible=false;
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
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}
	}
}
