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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionControlInstitucional;
using NetAccessControl;
using System.IO;

namespace SIMA.SimaNetWeb.GestionControlInstituacional
{
	/// <summary>
	/// Summary description for .
	/// </summary>
	public class DetalleDocumentosAuditoria : System.Web.UI.Page, IPaginaBase
	{
		protected System.Web.UI.WebControls.Literal ltlMensaje;
	
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
			this.ddlbOrganismo.SelectedIndexChanged += new System.EventHandler(this.ddlbOrganismo_SelectedIndexChanged);
			this.ddblSubOrganismo.SelectedIndexChanged += new System.EventHandler(this.ddblSubOrganismo_SelectedIndexChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO DOCUMENTO";
		const string TITULOMODOMODIFICAR = "DOCUMENTO";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDDOCUMENTOAUDITORIA = "IdDocumentoAuditoria";

		//Paginas
		const string URLBUSQUEDAPERSONAL = "../Legal/BusquedaPersonal.aspx?";

		#endregion Constantes
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.DropDownList ddlbOrganismo;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtNroDocumento;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroDocumento;
		protected System.Web.UI.WebControls.Label Label4;
		protected eWorld.UI.CalendarPopup CalFechaDocumento;
		protected System.Web.UI.WebControls.Label Label6;
		protected eWorld.UI.CalendarPopup calFechaInicio;
		protected System.Web.UI.WebControls.Label Label7;
		protected eWorld.UI.CalendarPopup calFechaTermino;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label lblConcepto;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvObservacion;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtSituacionActual;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvSituacionActual;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonal;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlbActividad;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.DropDownList ddblSubOrganismo;
		/// <summary>
		/// Llena el combo de Tipo Accion
		/// </summary>
		ListItem lItem;

		private void llenarCentroOperativo()
		{
			CCentroOperativo oCCentroOperativo= new CCentroOperativo();
			ddlbCentroOperativo.DataSource= oCCentroOperativo.ListarTodosCombo();
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Sigla2.ToString();
			ddlbCentroOperativo.DataBind();
		}

		private void llenarTipoSituacion()
		{
			CTablaTablas oCTablasTablas = new CTablaTablas();
			ddlbSituacion.DataSource= oCTablasTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TipoSituacionObservacion));
			ddlbSituacion.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString ();
			ddlbSituacion.DataBind();
		}
		private void llenarOrganismoAuditor()
		{
			CTablaTablas oCTablasTablas = new CTablaTablas();
			ddlbOrganismo.DataSource= oCTablasTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.OrganismosAuditores));
			ddlbOrganismo.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbOrganismo.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString ();
			ddlbOrganismo.DataBind();
		}
		private void llenarSubOrganismos()
		{
			CControlInstitucional oCControlInstitucional = new CControlInstitucional();
			DataTable dt = oCControlInstitucional.llenarGrillaSubOrganismoXOrganismo(Convert.ToInt32(ddlbOrganismo.SelectedValue));
			ddblSubOrganismo.DataSource=dt;
			ddblSubOrganismo.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddblSubOrganismo.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString ();
			ddblSubOrganismo.DataBind();
		}
		private void llenarActividades()
		{
			CControlInstitucional oCControlInstitucional = new CControlInstitucional();
			DataTable dt = oCControlInstitucional.llenarGrillaAccionControlXSubOrganismo(Convert.ToInt32(ddblSubOrganismo.SelectedValue));
			ddlbActividad.DataSource=dt;
			ddlbActividad.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbActividad.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString ();
			ddlbActividad.DataBind();
		}
		

	

		/*private void llenarEntidadAuditora()
		{
			CTablaTablas oCTablasTablas = new CTablaTablas();
			ddlbEntidadAuditora.DataSource= oCTablasTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.EntidadAuditora));
			ddlbEntidadAuditora.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbEntidadAuditora.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString ();
			ddlbEntidadAuditora.DataBind();
		}*/

		private void LlenarPeriodoContable()
		{
			CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			ddlbPeriodo.DataSource = oCPeriodoContable.ListarPeriodoDocumentoAuditoria();
			ddlbPeriodo.DataValueField="Periodo";
			ddlbPeriodo.DataTextField="Periodo";
			ddlbPeriodo.DataBind();

			/*ListItem item;
			item = ddlbPeriodo.Items.FindByText(DateTime.Now.Year.ToString());
			if (item !=null){item.Selected = true;}*/
		}

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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetallePoderes.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePoderes.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePoderes.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Constantes.TEXTOSSELECCIONAR,Constantes.VALORSELECCIONAR);
			this.llenarCentroOperativo();
			this.llenarTipoSituacion();
			this.llenarOrganismoAuditor();
			llenarSubOrganismos();
			this.llenarActividades();
			//this.llenarEntidadAuditora();
			this.LlenarPeriodoContable();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePoderes.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvNroDocumento.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDONRODOCUMENTO);
			rfvNroDocumento.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDONRODOCUMENTO);

			/*rfvNroObservacion.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDONROOBSERVACION);
			rfvNroObservacion.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDONROOBSERVACION);*/

			//rfvResponsable.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDORESPONSABLE);
			//rfvResponsable.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDORESPONSABLE);

			rfvObservacion.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOOBSERVACION);
			rfvObservacion.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOOBSERVACION);

			rfvSituacionActual.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOSITUACIONACTUAL);
			rfvSituacionActual.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOSITUACIONACTUAL);

			//ibtnBuscarPersonal.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAPERSONAL,700,500,true));
			ibtnAceptar.Attributes.Add(Constantes.EVENTOCLICK,Constantes.EVENTOVALIDATORONSUBMIT);	
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePoderes.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePoderes.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePoderes.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetallePoderes.ConfigurarAccesoControles implementation
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
			// TODO:  Add DetallePoderes.ValidarFiltros implementation
			return true;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			DocumentosAuditoriaBE oDocumentosAuditoriaBE= new  DocumentosAuditoriaBE();
			oDocumentosAuditoriaBE.IdTablaOrganismo = Convert.ToInt32(Enumerados.TablasTabla.OrganismosAuditores);
			oDocumentosAuditoriaBE.IdOrganismo = Convert.ToInt32(ddlbOrganismo.SelectedValue);
			oDocumentosAuditoriaBE.IdTablaSubOrganismo = 390;
			oDocumentosAuditoriaBE.IdSubOrganismo = Convert.ToInt32(ddblSubOrganismo.SelectedValue);

			oDocumentosAuditoriaBE.IdTablaActividad = 391;
			oDocumentosAuditoriaBE.IdActividad = Convert.ToInt32(ddlbActividad.SelectedValue);
			//oDocumentosAuditoriaBE.IdTablaEntidadAuditora = Convert.ToInt32(Enumerados.TablasTabla.EntidadAuditora);
			//oDocumentosAuditoriaBE.IdEntidadAuditora = Convert.ToInt32(ddlbEntidadAuditora.SelectedValue);
			oDocumentosAuditoriaBE.NroDocumento = txtNroDocumento.Text;
			oDocumentosAuditoriaBE.FechaDocumento = Convert.ToDateTime(CalFechaDocumento.SelectedDate);	
			oDocumentosAuditoriaBE.FechaInicio = Convert.ToDateTime(calFechaInicio.SelectedDate);	

			if(calFechaTermino.SelectedDate.ToString() != Constantes.FECHAVALORENBLANCO)
			{
				oDocumentosAuditoriaBE.FechaTermino = Convert.ToDateTime(calFechaTermino.SelectedDate);	
			}

			oDocumentosAuditoriaBE.Periodo = ddlbPeriodo.SelectedValue;
			oDocumentosAuditoriaBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.TipoSituacionObservacion);
			oDocumentosAuditoriaBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oDocumentosAuditoriaBE.Observacion = txtObservaciones.Text;		
			oDocumentosAuditoriaBE.SituacionActual = txtSituacionActual.Text;		
			oDocumentosAuditoriaBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			//oDocumentosAuditoriaBE.IdPersonal = Convert.ToInt32(hIdPersonal.Value);

			oDocumentosAuditoriaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoDocumentoAuditora);
			oDocumentosAuditoriaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosDocumentoAuditoria.Activo);
			oDocumentosAuditoriaBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oDocumentosAuditoriaBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se registró el Documento Auditoria Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTRODOCUMENTOAUDITORIA));
			}
		}

		public void Modificar()
		{
			DocumentosAuditoriaBE oDocumentosAuditoriaBE = new  DocumentosAuditoriaBE();

			oDocumentosAuditoriaBE.IdDocumentoAuditoria = Convert.ToInt32(Page.Request.QueryString[KEYQIDDOCUMENTOAUDITORIA]);
			oDocumentosAuditoriaBE.IdTablaOrganismo = Convert.ToInt32(Enumerados.TablasTabla.OrganismosAuditores);
			oDocumentosAuditoriaBE.IdOrganismo = Convert.ToInt32(ddlbOrganismo.SelectedValue);
			oDocumentosAuditoriaBE.IdTablaSubOrganismo = 390;
			oDocumentosAuditoriaBE.IdSubOrganismo = Convert.ToInt32(ddblSubOrganismo.SelectedValue);
			oDocumentosAuditoriaBE.IdTablaActividad = 391;//Convert.ToInt32(Enumerados.TablasTabla.TipoActividad);
			oDocumentosAuditoriaBE.IdActividad = Convert.ToInt32(ddlbActividad.SelectedValue);
			//oDocumentosAuditoriaBE.IdTablaEntidadAuditora = Convert.ToInt32(Enumerados.TablasTabla.EntidadAuditora);
			//oDocumentosAuditoriaBE.IdEntidadAuditora = Convert.ToInt32(ddlbEntidadAuditora.SelectedValue);
			oDocumentosAuditoriaBE.NroDocumento = txtNroDocumento.Text;
			oDocumentosAuditoriaBE.FechaDocumento = Convert.ToDateTime(CalFechaDocumento.SelectedDate);	
			oDocumentosAuditoriaBE.FechaInicio = Convert.ToDateTime(calFechaInicio.SelectedDate);	

			if(calFechaTermino.SelectedDate.ToString() != Constantes.FECHAVALORENBLANCO)
			{
				oDocumentosAuditoriaBE.FechaTermino = Convert.ToDateTime(calFechaTermino.SelectedDate);	
			}

			oDocumentosAuditoriaBE.Periodo = ddlbPeriodo.SelectedValue;
			oDocumentosAuditoriaBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.TipoSituacionObservacion);
			oDocumentosAuditoriaBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oDocumentosAuditoriaBE.Observacion = txtObservaciones.Text;		
			oDocumentosAuditoriaBE.SituacionActual = txtSituacionActual.Text;		
			oDocumentosAuditoriaBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			//oDocumentosAuditoriaBE.IdPersonal = Convert.ToInt32(hIdPersonal.Value);

			oDocumentosAuditoriaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoDocumentoAuditora);
			oDocumentosAuditoriaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosDocumentoAuditoria.Activo);
			oDocumentosAuditoriaBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oDocumentosAuditoriaBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se modificó el Documento Auditoria Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONDOCUMENTOAUDITORIA));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePoderes.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

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
			lblTitulo.Text = TITULOMODONUEVO;
			this.LlenarCombos();
		}

		public void CargarModoModificar()
		{
			lblTitulo.Text = TITULOMODOMODIFICAR;
			//llenarCombosModificar();
			this.llenarCentroOperativo();
			llenarOrganismoAuditor();
			this.llenarTipoSituacion();
			this.LlenarPeriodoContable();
			CTablaTablas oCTablasTablas = new CTablaTablas();
			ddblSubOrganismo.DataSource= oCTablasTablas.ListaTodosCombo(390);
					
			ddblSubOrganismo.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddblSubOrganismo.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddblSubOrganismo.DataBind();
			
			
			ddlbActividad.DataSource=oCTablasTablas.ListaTodosCombo(391);
			ddlbActividad.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbActividad.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbActividad.DataBind();

			CMantenimientos	oCMantenimientos = new CMantenimientos();
			DocumentosAuditoriaBE oDocumentosAuditoriaBE = (DocumentosAuditoriaBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDDOCUMENTOAUDITORIA]),Enumerados.ClasesNTAD.DocumentosAuditoriaNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se consultó el Detalle del Documento Auditoria Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oDocumentosAuditoriaBE!=null)
			{
				//ddlbOrganismo.Items.FindByValue(oDocumentosAuditoriaBE.IdOrganismo.ToString()).Selected = true;		
				//ddblSubOrganismo.Items.FindByValue(oDocumentosAuditoriaBE.IdSubOrganismo.ToString()).Selected = true;	
				ListItem item = ddlbOrganismo.Items.FindByValue(oDocumentosAuditoriaBE.IdOrganismo.ToString());
				if(item!=null)item.Selected = true;		
				
				item = ddblSubOrganismo.Items.FindByValue(oDocumentosAuditoriaBE.IdSubOrganismo.ToString());
				if(item!=null)item.Selected = true;		

				try
				{
					ddlbActividad.Items.FindByValue(oDocumentosAuditoriaBE.IdActividad.ToString()).Selected = true;				
				}
				catch(Exception ex){

				}
				//ddlbEntidadAuditora.Items.FindByValue(oDocumentosAuditoriaBE.IdEntidadAuditora.ToString()).Selected = true;				
				txtNroDocumento.Text = oDocumentosAuditoriaBE.NroDocumento.ToString();
				CalFechaDocumento.SelectedDate  = Convert.ToDateTime(oDocumentosAuditoriaBE.FechaDocumento);
				calFechaInicio.SelectedDate  = Convert.ToDateTime(oDocumentosAuditoriaBE.FechaInicio);

				if(oDocumentosAuditoriaBE.FechaTermino.ToString() != Constantes.FECHAVALORENBLANCO)
				{
					calFechaTermino.SelectedDate  = Convert.ToDateTime(oDocumentosAuditoriaBE.FechaTermino);
				}
				
				ddlbPeriodo.Items.FindByValue(oDocumentosAuditoriaBE.Periodo.ToString()).Selected = true;				
				ddlbSituacion.Items.FindByValue(oDocumentosAuditoriaBE.IdSituacion.ToString()).Selected = true;				
				txtObservaciones.Text = oDocumentosAuditoriaBE.Observacion.ToString();
				txtSituacionActual.Text = oDocumentosAuditoriaBE.SituacionActual.ToString();
				ddlbCentroOperativo.Items.FindByValue(oDocumentosAuditoriaBE.IdCentroOperativo.ToString()).Selected = true;				
				//txtPersonal.Text = oDocumentosAuditoriaBE.Personal.ToString();
				//hIdPersonal.Value = oDocumentosAuditoriaBE.IdPersonal.ToString();
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetallePoderes.CargarModoConsulta implementation
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
			if(txtNroDocumento.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDONRODOCUMENTO));
				return false;	
			}
			
			/*if(txtNroObservacion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDONROOBSERVACION));
				return false;	
			}*/

//			if(txtPersonal.Text.Trim()==String.Empty)
//			{
//				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDORESPONSABLE));
//				return false;	
//			}

			if(txtObservaciones.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOOBSERVACION));
				return false;	
			}

			if(txtSituacionActual.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOSITUACIONACTUAL));
				return false;	
			}

			return true;		
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
		}

		#endregion


		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		private void redireccionaPaginaPrincipal()
		{
			//Page.Response.Redirect(URLPRINCIPAL);
		}


		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}

		private void ddlbOrganismo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			llenarSubOrganismos();
			ddblSubOrganismo.Enabled=true;
		}

		private void ddblSubOrganismo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			llenarActividades();
			ddlbActividad.Enabled=true;
			ibtnAceptar.Visible=true;
		}
		private void llenarCombosModificar()
		{
			
			CTablaTablas oCTablasTablas = new CTablaTablas();
			ddblSubOrganismo.DataSource= oCTablasTablas.ListaTodosCombo(390);
					
			ddblSubOrganismo.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddblSubOrganismo.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString ();
			ddblSubOrganismo.DataBind();
			
			
			ddlbActividad.DataSource=oCTablasTablas.ListaTodosCombo(391);
			ddlbActividad.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbActividad.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString ();
		
		}

	}
}
