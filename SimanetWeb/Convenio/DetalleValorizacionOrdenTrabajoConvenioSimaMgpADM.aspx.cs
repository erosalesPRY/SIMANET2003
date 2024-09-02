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
	/// Summary description for AdmRegistrarPagosNoProgramadosConvenioSimaMgp.
	/// </summary>
	public class DetalleValorizacionOrdenTrabajoConvenioSimaMgpADM : System.Web.UI.Page, IPaginaMantenimento,IPaginaBase
	{
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblNroValorizacion;
		protected System.Web.UI.WebControls.TextBox txtNroValorizacion;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.Label lblNroOrdenTrabajo;
		protected System.Web.UI.WebControls.Label lblAlias;
		protected System.Web.UI.WebControls.Label lblUnidadNaval;
		protected System.Web.UI.WebControls.TextBox txtNroOrdenTrabajo;
		protected System.Web.UI.WebControls.TextBox txtAlias;
		protected System.Web.UI.WebControls.TextBox txtUnidadNaval;
		protected System.Web.UI.WebControls.Label lblPrecioVenta;
		protected System.Web.UI.WebControls.Label lblEstado;
		protected eWorld.UI.NumericBox nbPrecioVenta;
		protected System.Web.UI.WebControls.DropDownList ddlbEstado;
		protected System.Web.UI.WebControls.Label lblAvanceFisico;
		protected System.Web.UI.WebControls.Label lblDocumentoAprobación;
		protected System.Web.UI.WebControls.Label lblNroDocumentoAprobacion;
		protected System.Web.UI.WebControls.Label lblActaAprobación;
		protected eWorld.UI.NumericBox nbAvanceFisico;
		protected System.Web.UI.WebControls.TextBox txtDocumentoAprobacion;
		protected System.Web.UI.WebControls.TextBox txtNroDocumentoAprobacion;
		protected System.Web.UI.WebControls.CheckBox ckbActaAprovacion;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarUnidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreUnidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdUnidadDependenciaCliente;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rqdvNroValorizacion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rqdvUnidadNaval;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCliente;
		protected System.Web.UI.HtmlControls.HtmlTableRow ControlTablaFilaActaAprobacion;
		protected System.Web.UI.WebControls.Label lblFechaIncio;
		protected System.Web.UI.WebControls.Label lblFechaTermino;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected eWorld.UI.CalendarPopup CalFechaTermino;
		protected System.Web.UI.WebControls.CompareValidator cpdvFechaOrdenTrabajo;
		protected System.Web.UI.HtmlControls.HtmlTableRow ControlTablaFilaFechaInicio;
		protected System.Web.UI.HtmlControls.HtmlTableRow ControlTablaFilaFechaTermino;
		protected System.Web.UI.HtmlControls.HtmlTableRow ControlTablaFilaAvanceFisico;
		protected System.Web.UI.HtmlControls.HtmlTableRow ControlTablaFilaDocumentoAprobacion;
		protected System.Web.UI.HtmlControls.HtmlTableRow ControlTableFilaNroDocumentoAprovacion;
		protected System.Web.UI.HtmlControls.HtmlTableRow ControlTableFilaNroDocumentoReferencia;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblFechaAprobacionDocumento;
		protected eWorld.UI.CalendarPopup CalFechaAprobacionDocumento;

		ListItem item=new ListItem();

	
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


		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
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

		#region Constantes

		const string KEYIDVALORIZACIONORDENTRABAJO="IdValorizacionOrdenTrabajo";
		const string KEYIDCONVENIOSIMAMGP="IdConvenioSimaMgp";
		const string KEYIDPROYECTOCONVENIO="IdProyectoConvenio";
		const string KEYQNROCONVENIO="NroConvenio";
		const string KEYDESCRIPCIONPROYECTO="Descripcion";
		const string KEYIDCENTROOPERATIVO="IdCentroOperativo";
		const string KEYIDCLIENTE="IdCliente";
		
	
		const string URLPRINCIPAL="AdministracionValorizacionOrdenTrabajoConvenio.aspx?";
		const string URLBUSCARDEPENDENCIACLIENTE="BuscarDependenciaCliente.aspx?";

		#endregion Constantes

		#region Variables		 

		#endregion Variables

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			ValorizacionOrdenTrabajoBE oValorizacionOrdenTrabajoBE=new ValorizacionOrdenTrabajoBE();
			
			oValorizacionOrdenTrabajoBE.IdValorizacionOrdenTrabajo=Convert.ToInt32(this.Page.Request.Params[KEYIDVALORIZACIONORDENTRABAJO]);
			oValorizacionOrdenTrabajoBE.NroValorizacion=this.txtNroValorizacion.Text;
			oValorizacionOrdenTrabajoBE.IdProyectoConvenio=Convert.ToInt32(this.Page.Request.Params[KEYIDPROYECTOCONVENIO]);
			oValorizacionOrdenTrabajoBE.NroOrdenTrabajo=this.txtNroOrdenTrabajo.Text;
			oValorizacionOrdenTrabajoBE.Alias=this.txtAlias.Text;
			oValorizacionOrdenTrabajoBE.IdUnidadDependenciaCliente=Convert.ToInt32(this.hIdUnidadDependenciaCliente.Value);
			oValorizacionOrdenTrabajoBE.IdTablaEstadoValOrdTraConvenio=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ConvenioEstadoValorizacionConvenio);
			oValorizacionOrdenTrabajoBE.IdEstadoValOrdTraConvenio=Convert.ToInt32(this.ddlbEstado.SelectedValue);
			oValorizacionOrdenTrabajoBE.MontoPrecioVentaSoles=NullableDouble.Parse(this.nbPrecioVenta.Text);
			oValorizacionOrdenTrabajoBE.PorcAvanceFisicoSimanet=NullableDouble.Parse(this.nbAvanceFisico.Text);
			oValorizacionOrdenTrabajoBE.DocumentoReferenciaAprobacion=this.txtDocumentoAprobacion.Text;
			oValorizacionOrdenTrabajoBE.NroDocumentoAprobacionConvenio=this.txtNroDocumentoAprobacion.Text;
			if(this.CalFechaAprobacionDocumento.SelectedDate.ToString()!=Utilitario.Constantes.FECHAVALORENBLANCO)
			{
				oValorizacionOrdenTrabajoBE.FechaAprobacionDocumento=this.CalFechaAprobacionDocumento.SelectedDate;
			}
			oValorizacionOrdenTrabajoBE.IdTablaActaAprobacion=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ActaAprobacion);
			oValorizacionOrdenTrabajoBE.IdTablaMoneda=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.Moneda);
			oValorizacionOrdenTrabajoBE.IdMoneda=Convert.ToInt32(Utilitario.Enumerados.Moneda.NS);
			if(this.ckbActaAprovacion.Checked==false)
			{
				oValorizacionOrdenTrabajoBE.IdActaAprobacion=Convert.ToInt32(Utilitario.Enumerados.ConvenioActaAprobacion.SinActa);
			}
			else
			{
				oValorizacionOrdenTrabajoBE.IdActaAprobacion=Convert.ToInt32(Utilitario.Enumerados.ConvenioActaAprobacion.ActaFirmada);
			}
			oValorizacionOrdenTrabajoBE.Descripcion=this.txtDescripcion.Text;
			oValorizacionOrdenTrabajoBE.Observaciones=this.txtObservaciones.Text;
			oValorizacionOrdenTrabajoBE.IdUsuarioRegistro=CNetAccessControl.GetIdUser();
			oValorizacionOrdenTrabajoBE.IdCentroOperativo=Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue);
//			if(this.CalFechaInicio.SelectedDate.ToString()!=Utilitario.Constantes.FECHAVALORENBLANCO)
//			{
//				oValorizacionOrdenTrabajoBE.FechaInicioRealOrdenTrabajo=this.CalFechaInicio.SelectedDate;
//			}
//			if(this.CalFechaTermino.SelectedDate.ToString()!=Utilitario.Constantes.FECHAVALORENBLANCO)
//			{
//				oValorizacionOrdenTrabajoBE.FechaTerminoRealOrdenTrabajo=this.CalFechaTermino.SelectedDate;
//			}
			oValorizacionOrdenTrabajoBE.IdCliente=Utilitario.Constantes.IDCLIENTEMARINA;

			int retorno=0;
			CValorizacionOrdenTrabajoConvenio oCValorizacionOrdenTrabajoConvenio=new CValorizacionOrdenTrabajoConvenio();

			retorno=oCValorizacionOrdenTrabajoConvenio.InsertarValorizacion(oValorizacionOrdenTrabajoBE);
			if (retorno==Utilitario.Constantes.VALORCONFIRMACIONREGISTRO)
			{
				LogAplicativo.GrabarLogAplicativoArchivo
					(new LogAplicativo(CNetAccessControl.GetUserName(),"Convenio",this.ToString(),"Se modificó Item de " + 
					oCValorizacionOrdenTrabajoConvenio.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
				//Elabora el Query string para luego redireccionar a la pagina que invoco esta accion
				string strUrlGoBack = URLPRINCIPAL + KEYIDPROYECTOCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPROYECTOCONVENIO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQNROCONVENIO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYDESCRIPCIONPROYECTO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYDESCRIPCIONPROYECTO];

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Utilitario.Mensajes.CONVENIOREGISTROEXITOSO),strUrlGoBack.ToString());
			}
			else
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(retorno.ToString()));
			}

		}

		public void Modificar()
		{
			ValorizacionOrdenTrabajoBE oValorizacionOrdenTrabajoBE=new ValorizacionOrdenTrabajoBE();

			oValorizacionOrdenTrabajoBE.IdValorizacionOrdenTrabajo=Convert.ToInt32(this.Page.Request.Params[KEYIDVALORIZACIONORDENTRABAJO]);
			oValorizacionOrdenTrabajoBE.NroOrdenTrabajo=this.txtNroOrdenTrabajo.Text;
			oValorizacionOrdenTrabajoBE.Alias=this.txtAlias.Text;
			oValorizacionOrdenTrabajoBE.NroDocumentoAprobacionConvenio=this.txtNroDocumentoAprobacion.Text;
			if(this.CalFechaAprobacionDocumento.SelectedDate.ToString()!=Utilitario.Constantes.FECHAVALORENBLANCO)
			{
				oValorizacionOrdenTrabajoBE.FechaAprobacionDocumento=this.CalFechaAprobacionDocumento.SelectedDate;
			}
			oValorizacionOrdenTrabajoBE.Descripcion=this.txtDescripcion.Text;
			oValorizacionOrdenTrabajoBE.Observaciones=this.txtObservaciones.Text;
			oValorizacionOrdenTrabajoBE.DocumentoReferenciaAprobacion=this.txtDocumentoAprobacion.Text;
			oValorizacionOrdenTrabajoBE.IdTablaEstadoValOrdTraConvenio=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ConvenioEstadoValorizacionConvenio);
			oValorizacionOrdenTrabajoBE.IdEstadoValOrdTraConvenio=Convert.ToInt32(this.ddlbEstado.SelectedValue);
			oValorizacionOrdenTrabajoBE.PorcAvanceFisicoSimanet=NullableDouble.Parse(this.nbAvanceFisico.Text);
			oValorizacionOrdenTrabajoBE.IdTablaActaAprobacion=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ActaAprobacion);
			oValorizacionOrdenTrabajoBE.IdUsuarioActualizacion=CNetAccessControl.GetIdUser();
			if(this.CalFechaInicio.SelectedDate.ToString()!=Utilitario.Constantes.FECHAVALORENBLANCO)
			{
				oValorizacionOrdenTrabajoBE.FechaInicioRealOrdenTrabajo=this.CalFechaInicio.SelectedDate;
			}
			if(this.CalFechaTermino.SelectedDate.ToString()!=Utilitario.Constantes.FECHAVALORENBLANCO)
			{
				oValorizacionOrdenTrabajoBE.FechaTerminoRealOrdenTrabajo=this.CalFechaTermino.SelectedDate;
			}

			if(this.ckbActaAprovacion.Checked==false)
			{
				oValorizacionOrdenTrabajoBE.IdActaAprobacion=Convert.ToInt32(Utilitario.Enumerados.ConvenioActaAprobacion.SinActa);
			}
			else
			{
				oValorizacionOrdenTrabajoBE.IdActaAprobacion=Convert.ToInt32(Utilitario.Enumerados.ConvenioActaAprobacion.ActaFirmada);
			}
			
			int retorno=0;
			
			CValorizacionOrdenTrabajoConvenio oCValorizacionOrdenTrabajoConvenio=new CValorizacionOrdenTrabajoConvenio();
		
			retorno= oCValorizacionOrdenTrabajoConvenio.ModificarValorizacionSIMAC(ref oValorizacionOrdenTrabajoBE);

			if(retorno>0)
			{
				this.nbAvanceFisico.Text=NullableDouble.Parse(oValorizacionOrdenTrabajoBE.PorcAvanceFisicoSimanet).ToString();

				if(!oValorizacionOrdenTrabajoBE.IdActaAprobacion.IsNull)
				{
					int intIdActaAprobacion=Convert.ToInt32(Utilitario.Enumerados.ConvenioActaAprobacion.ActaFirmada);
					if (intIdActaAprobacion==Convert.ToInt32(oValorizacionOrdenTrabajoBE.IdActaAprobacion))
					{
						this.ckbActaAprovacion.Checked=true;
					}
					else
					{
						this.ckbActaAprovacion.Checked=false;
					}
				}

				item=this.ddlbEstado.Items.FindByValue(oValorizacionOrdenTrabajoBE.IdEstadoValOrdTraConvenio.ToString());
				if(item!=null)
				{
					item.Selected=true;
				}

				LogAplicativo.GrabarLogAplicativoArchivo
					(new LogAplicativo(CNetAccessControl.GetUserName(),"Convenio",this.ToString(),"Se modificó Item de " + 
					oCValorizacionOrdenTrabajoConvenio.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
				//Elabora el Query string para luego redireccionar a la pagina que invoco esta accion
				string strUrlGoBack = URLPRINCIPAL + KEYIDPROYECTOCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPROYECTOCONVENIO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQNROCONVENIO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYDESCRIPCIONPROYECTO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYDESCRIPCIONPROYECTO];

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONREGISTROSELECCIONADO),strUrlGoBack.ToString());
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenioSimaMgpADM.Eliminar implementation
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
			// Por este formulario solo se perimita el registro de valorizaciones y
			// Ordenes de trabajo de los centros operativos de provincia. "Chimbote e Iquitos".
			if(Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaCallao)!=Convert.ToInt32(this.Page.Request.Params[KEYIDCENTROOPERATIVO]))
			{
				ListItem lItem=new ListItem();
				lItem=this.ddlbCentroOperativo.Items.FindByValue(Convert.ToInt32(this.Page.Request.Params[KEYIDCENTROOPERATIVO]).ToString());
				if(lItem!=null)
				{
					lItem.Selected=true;
				}
			
				lItem=this.ddlbEstado.Items.FindByValue(Convert.ToInt32(Utilitario.Enumerados.ConvenioEstadoValorizacionConvenio.Valorizada).ToString());
				if(lItem!=null)
				{
					lItem.Selected=true;
				}

				this.ibtnBuscarUnidad.Visible=true;

			}
			else
			{
				this.ibtnAceptar.Visible=false;
			}
			this.ddlbEstado.Enabled=false;
			this.txtNroOrdenTrabajo.Visible=false;
			this.txtDocumentoAprobacion.Visible=false;
			this.txtNroDocumentoAprobacion.Visible=false;
			this.CalFechaAprobacionDocumento.Visible=false;
			this.ckbActaAprovacion.Visible=false;
			this.nbAvanceFisico.Visible=false;
			this.lblNroOrdenTrabajo.Visible=false;
			this.lblDocumentoAprobación.Visible=false;
			this.lblNroDocumentoAprobacion.Visible=false;
			this.lblAvanceFisico.Visible=false;
			this.lblActaAprobación.Visible=false;
			this.ControlTablaFilaActaAprobacion.Visible=false;

			this.lblFechaIncio.Visible=false;
			this.lblFechaTermino.Visible=false;
			this.CalFechaInicio.Visible=false;
			this.CalFechaTermino.Visible=false;
			this.cpdvFechaOrdenTrabajo.Visible=false;
			this.ControlTablaFilaFechaInicio.Visible=false;
			this.ControlTablaFilaFechaTermino.Visible=false;
			this.ControlTablaFilaAvanceFisico.Visible=false;
			this.ControlTablaFilaDocumentoAprobacion.Visible=false;
			this.ControlTableFilaNroDocumentoAprovacion.Visible=false;
			this.ControlTableFilaNroDocumentoReferencia.Visible=false;
		}

		public void CargarModoModificar()
		{
			ValorizacionOrdenTrabajoBE oValorizacionOrdenTrabajoBE=new ValorizacionOrdenTrabajoBE();
			CValorizacionOrdenTrabajoConvenio oCValorizacionOrdenTrabajoConvenio=new CValorizacionOrdenTrabajoConvenio();
			oValorizacionOrdenTrabajoBE=(ValorizacionOrdenTrabajoBE)oCValorizacionOrdenTrabajoConvenio.DetalleValorizacionOrdenTrabajoConvenio(Convert.ToInt32(Page.Request.Params[KEYIDVALORIZACIONORDENTRABAJO]));
			if(oValorizacionOrdenTrabajoBE!=null)
			{
				this.txtNroValorizacion.Text=oValorizacionOrdenTrabajoBE.NroValorizacion;
				if(!oValorizacionOrdenTrabajoBE.NroOrdenTrabajo.IsNull)
				{
					this.txtNroOrdenTrabajo.Text=oValorizacionOrdenTrabajoBE.NroOrdenTrabajo.ToString();
				}
				if(!oValorizacionOrdenTrabajoBE.Alias.IsNull)
				{
					this.txtAlias.Text=oValorizacionOrdenTrabajoBE.Alias.ToString();
				}
				if(!oValorizacionOrdenTrabajoBE.NombreDependenciaCliente.IsNull)
				{
					this.txtUnidadNaval.Text=oValorizacionOrdenTrabajoBE.NombreDependenciaCliente.ToString();
				}
				if(!oValorizacionOrdenTrabajoBE.MontoPrecioVentaSoles.IsNull)
				{
					this.nbPrecioVenta.Text=oValorizacionOrdenTrabajoBE.MontoPrecioVentaSoles.Value.ToString();
				}
				if(!oValorizacionOrdenTrabajoBE.PorcAvanceFisicoSimanet.IsNull)
				{
					this.nbAvanceFisico.Text=NullableString.Parse(oValorizacionOrdenTrabajoBE.PorcAvanceFisicoSimanet).ToString();
				}
				if(!oValorizacionOrdenTrabajoBE.DocumentoReferenciaAprobacion.IsNull)
				{
					this.txtDocumentoAprobacion.Text=oValorizacionOrdenTrabajoBE.DocumentoReferenciaAprobacion.ToString();
				}
				if(!oValorizacionOrdenTrabajoBE.NroDocumentoAprobacionConvenio.IsNull)
				{
					this.txtNroDocumentoAprobacion.Text=oValorizacionOrdenTrabajoBE.NroDocumentoAprobacionConvenio.ToString();
				}
				if(!oValorizacionOrdenTrabajoBE.FechaAprobacionDocumento.IsNull)
				{
					this.CalFechaAprobacionDocumento.SelectedDate=Convert.ToDateTime(oValorizacionOrdenTrabajoBE.FechaAprobacionDocumento);
				}
				if(!oValorizacionOrdenTrabajoBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text=oValorizacionOrdenTrabajoBE.Descripcion.ToString();
				}
				if(!oValorizacionOrdenTrabajoBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text=oValorizacionOrdenTrabajoBE.Observaciones.ToString();
				}
				if(!oValorizacionOrdenTrabajoBE.FechaInicioRealOrdenTrabajo.IsNull)
				{
					this.CalFechaInicio.SelectedDate=Convert.ToDateTime(oValorizacionOrdenTrabajoBE.FechaInicioRealOrdenTrabajo);
				}
				if(!oValorizacionOrdenTrabajoBE.FechaTerminoRealOrdenTrabajo.IsNull)
				{
					this.CalFechaTermino.SelectedDate=Convert.ToDateTime(oValorizacionOrdenTrabajoBE.FechaTerminoRealOrdenTrabajo);
				}
				if(!oValorizacionOrdenTrabajoBE.IdActaAprobacion.IsNull)
				{
					int intIdActaAprobacion=Convert.ToInt32(Utilitario.Enumerados.ConvenioActaAprobacion.ActaFirmada);
					if (intIdActaAprobacion==Convert.ToInt32(oValorizacionOrdenTrabajoBE.IdActaAprobacion))
					{
						this.ckbActaAprovacion.Checked=true;
					}
					else
					{
						this.ckbActaAprovacion.Checked=false;
					}
				}

				item=this.ddlbCentroOperativo.Items.FindByValue(oValorizacionOrdenTrabajoBE.IdCentroOperativo.ToString());
				if(item!=null)
				{
					item.Selected=true;
				}

				item=this.ddlbEstado.Items.FindByValue(oValorizacionOrdenTrabajoBE.IdEstadoValOrdTraConvenio.ToString());
				if(item!=null)
				{
					item.Selected=true;
				}
			}
			
			// Acceso a los Controles Segun el Centro Operativo.
			this.txtNroValorizacion.ReadOnly=true;
			this.ibtnBuscarUnidad.Visible=false;

			if(Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaCallao)==Convert.ToInt32(this.Page.Request.Params[KEYIDCENTROOPERATIVO]))
			{
			
				this.txtAlias.ReadOnly=true;
				this.nbPrecioVenta.Enabled=true;
				this.txtDocumentoAprobacion.ReadOnly=true;
				this.txtDescripcion.ReadOnly=true;
			}
			else
			{
				this.txtAlias.ReadOnly=false;
				this.nbPrecioVenta.Enabled=false;
				this.txtDocumentoAprobacion.ReadOnly=false;
				this.txtDescripcion.ReadOnly=false;
			
			}

		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenioSimaMgpADM.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			if(NullableString.Parse(txtNroValorizacion.Text).IsNull)
			{
				this.ltlMensaje.Text=Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOREQUIERONROVALORIZACION));
				return false;
			}
			if(NullableString.Parse(this.txtUnidadNaval.Text).IsNull)
			{
				this.ltlMensaje.Text=Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOREQUIEROUNIDADADEPENDENCIA));
				return false;
			}
			if((this.CalFechaInicio.SelectedDate.ToString()==Utilitario.Constantes.FECHAVALORENBLANCO)&(this.CalFechaTermino.SelectedDate.ToString()!=Utilitario.Constantes.FECHAVALORENBLANCO))
			{
				this.ltlMensaje.Text=Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.ConvenioFaltaFechaInicioValorizacion));
				return false;
			}
			if((this.CalFechaInicio.SelectedDate.ToString()!=Utilitario.Constantes.FECHAVALORENBLANCO)&(this.CalFechaTermino.SelectedDate.ToString()!=Utilitario.Constantes.FECHAVALORENBLANCO))
			{
				if(Helper.ValidarRangoFechas(this.CalFechaInicio.SelectedDate,this.CalFechaTermino.SelectedDate)==false)
				{
					this.ltlMensaje.Text=Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.ConvenioFaltaFechaTerminoMenorFechaInicio));
					return false;
				}
			}
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenioSimaMgpADM.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenioSimaMgpADM.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenioSimaMgpADM.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenioSimaMgpADM.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.CentroOperativoSima();
			this.EstadoConvenioSimaMgp();
			this.TiposMonedas();
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text="CONVENIO SIMA - MGP " +  this.Page.Request.Params[KEYQNROCONVENIO];
		}

		public void LlenarJScript()
		{
			this.ibtnBuscarUnidad.Attributes.Add("onclick",Utilitario.Helper.PopupBusqueda("../General/BuscarDependenciaCliente.aspx?IdCliente=" + Convert.ToString(Utilitario.Constantes.IDCLIENTEMARINA),600,450,false)+"; return false;");
			this.rqdvNroValorizacion.ErrorMessage=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOREQUIERONROVALORIZACION);
			this.rqdvUnidadNaval.ErrorMessage=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOREQUIEROUNIDADADEPENDENCIA);
			this.cpdvFechaOrdenTrabajo.ErrorMessage=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.ConvenioFaltaFechaTerminoMenorFechaInicio);

		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenioSimaMgpADM.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenioSimaMgpADM.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenioSimaMgpADM.Exportar implementation
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
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenioSimaMgpADM.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region MetodosPrivados
		 
		private void EstadoConvenioSimaMgp()
		{
			CTablaTablas oCTablaTablas=new CTablaTablas();
			DataTable dt=oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ConvenioEstadoValorizacionConvenio));
			this.ddlbEstado.DataSource=dt;
			this.ddlbEstado.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlbEstado.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			this.ddlbEstado.DataBind();
		}

		private void CentroOperativoSima()
		{
			CCentroOperativo oCCentroOperativo=new CCentroOperativo();
			DataTable dt=oCCentroOperativo.ListarTodosCombo();
			this.ddlbCentroOperativo.DataSource=dt;
			this.ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			this.ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Descripcion.ToString();
			this.ddlbCentroOperativo.DataBind();
		}

		private void TiposMonedas()
		{
		}

		#endregion MetodosPrivados

//		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
//		{
//			this.Page.Response.Redirect(URLPRINCIPAL + KEYIDPROYECTOCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPROYECTOCONVENIO] +
//				Utilitario.Constantes.SIGNOAMPERSON + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] + 
//				Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQNROCONVENIO] +
//				Utilitario.Constantes.SIGNOAMPERSON + KEYDESCRIPCIONPROYECTO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYDESCRIPCIONPROYECTO]);
//		}

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
