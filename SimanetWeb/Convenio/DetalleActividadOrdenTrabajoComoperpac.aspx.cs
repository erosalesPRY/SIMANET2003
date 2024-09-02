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
	/// Aquí se agrega y se modifica una actividad contenida dentro de un convenio dado en un
	/// periodo.
	/// Este Formulario paso por refactoring
	/// </summary>
	public class DetalleActividadOrdenTrabajoComoperpac : System.Web.UI.Page,IPaginaMantenimento,IPaginaBase
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
			ActividadesOrdenTrabajoBE oActividadesOrdenTrabajoBE=new ActividadesOrdenTrabajoBE();

			if(!NullableDouble.Parse(this.nbNumeroVal.Text).IsNull)
			{
				oActividadesOrdenTrabajoBE.NroValorizacion=this.ddlbDivision.SelectedItem.Text + Convert.ToInt32(this.nbNumeroVal.Text).ToString(FORMATOTEXTO);
			}

			oActividadesOrdenTrabajoBE.DocumentoAprovacion=this.txtDocumentoAprobacion.Text;
			oActividadesOrdenTrabajoBE.FechaInicio=this.CalFechaIncio.SelectedDate;
			
			
			string FechaTermino=this.CalFechaTermino.SelectedDate.ToString();
			
			if(Utilitario.Constantes.FECHAVALORENBLANCO!=FechaTermino)
			{
				oActividadesOrdenTrabajoBE.FechaTermino=this.CalFechaTermino.SelectedDate;
			}
			
			oActividadesOrdenTrabajoBE.PorcAvanceFisico=NullableDouble.Parse(nbAvanceFisico.Text);
			oActividadesOrdenTrabajoBE.MontoAsignado=NullableDouble.Parse(this.nbMontoAsignado.Text);
			oActividadesOrdenTrabajoBE.MontoEjecutado=NullableDouble.Parse(this.nbMontoEjecutado.Text);
			oActividadesOrdenTrabajoBE.Documento=this.txtDocumento.Text;
			oActividadesOrdenTrabajoBE.IdTablaTipoActividad=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TipoActividadOrdenTrabajoComoperpac);
			oActividadesOrdenTrabajoBE.IdTipoActividad=Convert.ToInt32(this.Page.Request.Params[KEYQTIPOACTIVIDADORDENTRABAJO]);
			oActividadesOrdenTrabajoBE.IdOrdenTrabajoUnidadApoyo=Convert.ToInt32(this.Page.Request.Params[KEYIDORDENTRABAJOUNIDADAPOYO]);
			oActividadesOrdenTrabajoBE.IdUnidadDependenciaCliente=Convert.ToInt32(this.hIdUnidadDependenciaCliente.Value);
			oActividadesOrdenTrabajoBE.IdUsuarioRegistro=CNetAccessControl.GetIdUser();
			oActividadesOrdenTrabajoBE.IdTablaEstado=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.EstadoActividadesUnidadesApoyoComoperpac);
			oActividadesOrdenTrabajoBE.IdEstado=Convert.ToInt32(Utilitario.Enumerados.EstadoActividadesUnidadesApoyoComoperpac.Activo);
			oActividadesOrdenTrabajoBE.Descripcion=this.txtDescripcion.Text;			
			oActividadesOrdenTrabajoBE.Observaciones=this.txtObservaciones.Text;

			int retorno=Utilitario.Constantes.ValorConstanteCero;
			CActividadesOrdenTrabajo oCActividadesOrdenTrabajo=new CActividadesOrdenTrabajo();

			retorno=oCActividadesOrdenTrabajo.Insertar(oActividadesOrdenTrabajoBE);
			if(retorno>Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEREGISTRO ,Enumerados.NivelesErrorLog.I.ToString()));

				string strUrlGoBack = URLPRINCIPAL + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCENTROOPERATIVO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDESTADO] + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDORDENTRABAJOUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDORDENTRABAJOUNIDADAPOYO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQNROORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request[KEYQNROORDENTRABAJO] + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQTIPOACTIVIDADORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQTIPOACTIVIDADORDENTRABAJO];

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CONVENIOREGISTROEXITOSO),strUrlGoBack.ToString());
			}
		}

		public void Modificar()
		{
			ActividadesOrdenTrabajoBE oActividadesOrdenTrabajoBE=new ActividadesOrdenTrabajoBE();

			oActividadesOrdenTrabajoBE.IdActividadesOrdenTrabajo=Convert.ToInt32(this.Page.Request.Params[KEYIDACTIVIDADESORDENTRABAJO]);
			if(!NullableDouble.Parse(this.nbNumeroVal.Text).IsNull)
			{
				oActividadesOrdenTrabajoBE.NroValorizacion=this.ddlbDivision.SelectedItem.Text + Convert.ToInt32(this.nbNumeroVal.Text).ToString(FORMATOTEXTO);
			}
			oActividadesOrdenTrabajoBE.DocumentoAprovacion=this.txtDocumentoAprobacion.Text;
			oActividadesOrdenTrabajoBE.FechaInicio=this.CalFechaIncio.SelectedDate;

			string FechaTermino=this.CalFechaTermino.SelectedDate.ToString();
			
			if(Utilitario.Constantes.FECHAVALORENBLANCO!=FechaTermino)
			{
				oActividadesOrdenTrabajoBE.FechaTermino=this.CalFechaTermino.SelectedDate;
			}
			oActividadesOrdenTrabajoBE.PorcAvanceFisico=NullableDouble.Parse(this.nbAvanceFisico.Text);
			oActividadesOrdenTrabajoBE.MontoAsignado=NullableDouble.Parse(this.nbMontoAsignado.Text);
			oActividadesOrdenTrabajoBE.MontoEjecutado=NullableDouble.Parse(this.nbMontoEjecutado.Text);
			oActividadesOrdenTrabajoBE.Documento=this.txtDocumento.Text;
			oActividadesOrdenTrabajoBE.IdUsuarioActualizacion=CNetAccessControl.GetIdUser();
			oActividadesOrdenTrabajoBE.Descripcion=this.txtDescripcion.Text;
			oActividadesOrdenTrabajoBE.Observaciones=this.txtObservaciones.Text;

			int retorno=Utilitario.Constantes.ValorConstanteCero;
			CActividadesOrdenTrabajo oCActividadesOrdenTrabajo=new CActividadesOrdenTrabajo();
			retorno=oCActividadesOrdenTrabajo.Modificar(oActividadesOrdenTrabajoBE);

			if(retorno>Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo
					(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(), MENSAJEMODIFCO + 
					oActividadesOrdenTrabajoBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));

				string strUrlGoBack = URLPRINCIPAL + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCENTROOPERATIVO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDESTADO] + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDORDENTRABAJOUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDORDENTRABAJOUNIDADAPOYO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQNROORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request[KEYQNROORDENTRABAJO] + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQTIPOACTIVIDADORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQTIPOACTIVIDADORDENTRABAJO];

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONREGISTROSELECCIONADO),strUrlGoBack.ToString());
			}

		}

		public void Eliminar()
		{
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
			}
		}

		public void CargarModoNuevo()
		{
			lblTitulo.Text= TITULOREGISTRAR + this.Page.Request.Params[KEYQTIPOACTIVIDADDESCRIPCION] + TITULOUNION  + this.Page.Request.Params[KEYQNROORDENTRABAJO];
			
			if(Convert.ToInt32(Utilitario.Enumerados.TipoActividadOrdenTrabajoComoperpac.Trabajos)==Convert.ToInt32(this.Page.Request.Params[KEYQTIPOACTIVIDADORDENTRABAJO]))
			{
				this.lblFechaTermino.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.CalFechaTermino.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.lblDocumento.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.txtDocumento.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.lblAvanceFisico.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.nbAvanceFisico.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.lblNroValorizacion.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.ddlbDivision.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.nbNumeroVal.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.txtNroValorizacion.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
			}
			else
			{
				this.lblFechaTermino.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.CalFechaTermino.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.lblDocumento.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.txtDocumento.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.lblAvanceFisico.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.nbAvanceFisico.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.lblNroValorizacion.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.ddlbDivision.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.nbNumeroVal.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.txtNroValorizacion.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
			}

			this.ibtnBuscarUnidad.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;

		}

		public void CargarModoModificar()
		{
			lblTitulo.Text= TITULOMODIFICAR  + this.Page.Request.Params[KEYQTIPOACTIVIDADDESCRIPCION] + TITULOUNION  + this.Page.Request.Params[KEYQNROORDENTRABAJO];
			
			string id=this.Page.Request.Params[KEYIDACTIVIDADESORDENTRABAJO];
			CActividadesOrdenTrabajo oCActividadesOrdenTrabajo=new CActividadesOrdenTrabajo();
			ActividadesOrdenTrabajoBE oActividadesOrdenTrabajoBE=(ActividadesOrdenTrabajoBE)oCActividadesOrdenTrabajo.DetalleActividadesOrdenTrabajoComoperpac(Convert.ToInt32(this.Page.Request.Params[KEYIDACTIVIDADESORDENTRABAJO]));

			if(oActividadesOrdenTrabajoBE!=null)
			{
				this.txtDescripcion.Text=oActividadesOrdenTrabajoBE.Descripcion;
				if(!oActividadesOrdenTrabajoBE.DocumentoAprovacion.IsNull)
				{
					this.txtDocumentoAprobacion.Text=oActividadesOrdenTrabajoBE.DocumentoAprovacion.ToString();
				}
				this.txtUnidadNaval.Text=oActividadesOrdenTrabajoBE.NombreDependendeciaMgp;
			
				this.txtNroValorizacion.Text="";
				if(!oActividadesOrdenTrabajoBE.NroValorizacion.IsNull)
				{
					string Division;
					int NroVal;
					Division=oActividadesOrdenTrabajoBE.NroValorizacion.ToString().Substring(Utilitario.Constantes.POSICIONINDEXCERO,Utilitario.Constantes.POSICIONINDEXDOS);
					NroVal=Convert.ToInt32(oActividadesOrdenTrabajoBE.NroValorizacion.ToString().Substring(Utilitario.Constantes.POSICIONINDEXDOS,Utilitario.Constantes.POSICIONINDEXSEIS));
					this.ddlbDivision.SelectedItem.Text=Division;
					this.nbNumeroVal.Text=NroVal.ToString();
					this.txtNroValorizacion.Text=oActividadesOrdenTrabajoBE.NroValorizacion.ToString();
				}
				if(!oActividadesOrdenTrabajoBE.MontoAsignado.IsNull)
				{
					this.nbMontoAsignado.Text=oActividadesOrdenTrabajoBE.MontoAsignado.ToString();
				}
				if(!oActividadesOrdenTrabajoBE.FechaInicio.IsNull)
				{
					this.CalFechaIncio.SelectedDate=Convert.ToDateTime(oActividadesOrdenTrabajoBE.FechaInicio);
				}
				if(!oActividadesOrdenTrabajoBE.MontoEjecutado.IsNull)
				{
					this.nbMontoEjecutado.Text=oActividadesOrdenTrabajoBE.MontoEjecutado.ToString();
				}
				if(!oActividadesOrdenTrabajoBE.PorcAvanceFisico.IsNull)
				{
					this.nbAvanceFisico.Text=oActividadesOrdenTrabajoBE.PorcAvanceFisico.ToString();
				}
				if(!oActividadesOrdenTrabajoBE.FechaTermino.IsNull)
				{
					this.CalFechaTermino.SelectedDate=Convert.ToDateTime(oActividadesOrdenTrabajoBE.FechaTermino);
				}
				if(!oActividadesOrdenTrabajoBE.Documento.IsNull)
				{
					this.txtDocumento.Text=oActividadesOrdenTrabajoBE.Documento.ToString();
				}
				if(!oActividadesOrdenTrabajoBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text=oActividadesOrdenTrabajoBE.Observaciones.ToString();
				}
			}

			
			if(Convert.ToInt32(Utilitario.Enumerados.TipoActividadOrdenTrabajoComoperpac.Trabajos)==Convert.ToInt32(this.Page.Request.Params[KEYQTIPOACTIVIDADORDENTRABAJO]))
			{
				this.lblFechaTermino.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.CalFechaTermino.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.lblDocumento.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.txtDocumento.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.lblAvanceFisico.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.nbAvanceFisico.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.lblNroValorizacion.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.ddlbDivision.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.nbNumeroVal.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.txtNroValorizacion.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
			}
			else
			{
				this.lblFechaTermino.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.CalFechaTermino.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.lblDocumento.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.txtDocumento.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.lblAvanceFisico.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.nbAvanceFisico.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.lblNroValorizacion.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.ddlbDivision.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.nbNumeroVal.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
				this.txtNroValorizacion.Visible=Utilitario.Constantes.VALORCHECKEDBOOL;
			}
				
			
		}

		public void CargarModoConsulta()
		{
		}

		public bool ValidarCampos()
		{
			string FechaTermino=this.CalFechaTermino.SelectedDate.ToString();

			if(Utilitario.Constantes.FECHAVALORENBLANCO!=FechaTermino)
			{
				string Ini=this.CalFechaIncio.SelectedDate.ToShortDateString();
				DateTime FechaIncial=Convert.ToDateTime(this.CalFechaIncio.SelectedDate.ToShortDateString());
				DateTime FechaFin=Convert.ToDateTime(this.CalFechaTermino.SelectedDate.ToShortDateString());
				if(FechaIncial<=FechaFin)
				{
					return true;
				}
				else
				{
					this.ltlMensaje.Text=Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOREQUIEREFECHATERMINOACTIVIDAD));
					return false;
				}
			}
			else
			{
				return true;
			}
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
		{

		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{

		}

		public void LlenarCombos()
		{
			this.Divicion();
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
			this.ibtnBuscarUnidad.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Helper.PopupBusqueda("../General/BuscarDependenciaCliente.aspx?IdCliente=" + Convert.ToString(Utilitario.Constantes.IDCLIENTEMARINA),600,450,false)+"; return false;");
			this.rqdvDescripcion.ErrorMessage=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOREQUIEREDESCRIPCIONACTIVIDAD);
			this.rqdvUnidadNaval.ErrorMessage=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOREQUIEREDEPENDENCIANAVAL);
		}

		public void RegistrarJScript()
		{}

		public void Imprimir()
		{}

		public void Exportar()
		{}

		public void ConfigurarAccesoControles()
		{}

		public bool ValidarFiltros()
		{
			return false;
		}

		#endregion	
		#region Constantes
		//KEYs
		private const string KEYQNROORDENTRABAJO="NroOrdenTrabajo";
		private const string KEYIDORDENTRABAJOUNIDADAPOYO="IdOrdenTrabajoUnidadApoyo";
		private const string KEYIDPERIODOUNIDADESAPOYO="IdPeriodoUnidadesApoyo";
		private const string KEYQPERIODO="Periodo";
		private const string KEYIDACTIVIDADESORDENTRABAJO="IdActividadesOrdenTrabajo";
		private const string KEYIDCENTROOPERATIVO="IdCentroOperativo";
		private const string KEYIDESTADO="IdEstado";
		private const string KEYQTIPOACTIVIDADDESCRIPCION="Descripcion";
		private const string KEYQTIPOACTIVIDADORDENTRABAJO="IdTipoActividad";

		//URL's
		private const string URLPRINCIPAL="AdministracionActividadOrdenTrabajoComoperpac.aspx?";

		//Otros
		private const string FORMATOTEXTO="000000";

		//Mensajes
		private const string MENSAJEREGISTRO="Se registro una actividad de OT de un convenio";
		private const string MENSAJEMODIFCO="Se modificó la actividad de OT de un Convenio Nro.";
		private const string TITULOREGISTRAR="REGISTRAR ACTIVIDAD DE ";
		private const string TITULOUNION=" O.T: ";
		private const string TITULOMODIFICAR="MODIFICAR ACTIVIDAD DE ";
		#endregion Constantes
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblDocumentoAprobacion;
		protected System.Web.UI.WebControls.Label lblDependenciaNaval;
		protected System.Web.UI.WebControls.Label lblMontoAsignado;
		protected System.Web.UI.WebControls.Label lblFechaInicio;
		protected System.Web.UI.WebControls.Label lblMontoEjecutado;
		protected System.Web.UI.WebControls.Label lblFechaTermino;
		protected System.Web.UI.WebControls.Label lblDocumento;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDocumento;
		protected System.Web.UI.WebControls.TextBox txtDocumentoAprobacion;
		protected eWorld.UI.CalendarPopup CalFechaIncio;
		protected eWorld.UI.NumericBox nbMontoAsignado;
		protected eWorld.UI.NumericBox nbMontoEjecutado;
		protected System.Web.UI.WebControls.Label lblAvanceFisico;
		protected eWorld.UI.NumericBox nbAvanceFisico;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarUnidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreUnidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdUnidadDependenciaCliente;
		protected System.Web.UI.WebControls.TextBox txtUnidadNaval;
		protected eWorld.UI.CalendarPopup CalFechaTermino;
		protected System.Web.UI.WebControls.DropDownList ddlbDivision;
		protected eWorld.UI.NumericBox nbNumeroVal;
		protected System.Web.UI.WebControls.Label lblNroValorizacion;
		protected System.Web.UI.WebControls.TextBox txtNroValorizacion;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rqdvDescripcion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCliente;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rqdvUnidadNaval;
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
					this.LlenarCombos();
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

		private void Divicion()
		{
			CTablaTablas oCTablaTablas=new CTablaTablas();
			DataView dv=oCTablaTablas.ListaSegunCriterioFiltro(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.DivisionesOt),Utilitario.Enumerados.ColumnasTablaTablas.Flg1.ToString() + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteUno.ToString());
			this.ddlbDivision.DataSource=dv;
			this.ddlbDivision.DataValueField = Utilitario.Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlbDivision.DataTextField = Utilitario.Enumerados.ColumnasTablaTablas.Var1.ToString();
			this.ddlbDivision.DataBind();
		}

		private void RedireccionarPaginaPrincipal()
		{
			string strUrlGoBack = URLPRINCIPAL + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCENTROOPERATIVO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDESTADO] + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDORDENTRABAJOUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDORDENTRABAJOUNIDADAPOYO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQNROORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request[KEYQNROORDENTRABAJO] + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYQTIPOACTIVIDADORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQTIPOACTIVIDADORDENTRABAJO];

			this.Page.Response.Redirect(strUrlGoBack);
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

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string strUrlGoBack = URLPRINCIPAL + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCENTROOPERATIVO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDESTADO] + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDORDENTRABAJOUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDORDENTRABAJOUNIDADAPOYO] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQNROORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request[KEYQNROORDENTRABAJO] + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYQTIPOACTIVIDADORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQTIPOACTIVIDADORDENTRABAJO];

			Response.Redirect(strUrlGoBack);

		}

		#endregion
	}
}

