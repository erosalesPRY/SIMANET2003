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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionControlInstitucional;
using NetAccessControl;
using System.IO;

namespace SIMA.SimaNetWeb.GestionControlInstituacional
{
	/// <summary>
	/// Summary description for DetallePoderes.
	/// </summary>
	public class DetalleProgramacionActividades : System.Web.UI.Page, IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtNroDocumento;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoDocumento;
		protected System.Web.UI.WebControls.Label Label4;
		protected eWorld.UI.CalendarPopup CalFechaDocumento;
		protected System.Web.UI.WebControls.Label Label6;
		protected eWorld.UI.CalendarPopup calFechaInicio;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtAsunto;
		protected System.Web.UI.WebControls.Label lblConcepto;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroDocumento;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvAsunto;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected eWorld.UI.CalendarPopup calFechaTermino;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlbOrganismo;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.HtmlControls.HtmlInputFile flArchivoReferencia;
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
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA PROGRAMACION";
		const string TITULOMODOMODIFICAR = "PROGRAMACION";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYIDCO = "CentroOperativo";

		//Paginas
		//const string URLBUSQUEDAENTIDAD = "../Legal/BusquedaEntidad.aspx";

		#endregion Constantes

		string PathArchivoReferencia="";
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

		private void llenarTipoInspeccion()
		{
			CTablaTablas oCTablasTablas = new CTablaTablas();
			ddlbTipoDocumento.DataSource= oCTablasTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.UnidadMedida));
			ddlbTipoDocumento.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipoDocumento.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString ();
			ddlbTipoDocumento.DataBind();
		}

		private void llenarTipoSituacion()
		{
			CTablaTablas oCTablasTablas = new CTablaTablas();
			ddlbSituacion.DataSource= oCTablasTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TipoSituacion));
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

		private void LlenarPeriodoContable()
		{
			CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			ddlbPeriodo.DataSource = oCPeriodoContable.ListarPeriodo();
			ddlbPeriodo.DataValueField="Periodo";
			ddlbPeriodo.DataTextField="Periodo";
			ddlbPeriodo.DataBind();

//			ListItem item;
//			item = ddlbPeriodo.Items.FindByText(DateTime.Now.Year.ToString());
//			if (item !=null){item.Selected = true;}
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Constantes.TEXTOSSELECCIONAR,Constantes.VALORSELECCIONAR);
			this.LlenarPeriodoContable();
			this.llenarCentroOperativo();
			this.llenarTipoInspeccion();
			this.llenarTipoSituacion();
			this.llenarOrganismoAuditor();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePoderes.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvNroDocumento.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEPROGRAMACIONCAMPOREQUERIDONRODOCUMENTO);
			rfvNroDocumento.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEPROGRAMACIONCAMPOREQUERIDONRODOCUMENTO);

			rfvAsunto.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEPROGRAMACIONCAMPOREQUERIDOASUNTO);
			rfvAsunto.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEPROGRAMACIONCAMPOREQUERIDOASUNTO);
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
			ProgramacionInspeccionesBE oProgramacionInspeccionesBE= new  ProgramacionInspeccionesBE();
			oProgramacionInspeccionesBE.ExtFile = Helper.ObtenerArchivoExtension(this.flArchivoReferencia.PostedFile.FileName.ToString())[1].ToString();
			oProgramacionInspeccionesBE.NroDocumento = txtNroDocumento.Text;
			oProgramacionInspeccionesBE.IdTablaTipoInspeccion = Convert.ToInt32(Enumerados.TablasTabla.UnidadMedida);
			oProgramacionInspeccionesBE.IdTipoInspeccion = Convert.ToInt32(ddlbTipoDocumento.SelectedValue);
			oProgramacionInspeccionesBE.FechaDocumento = Convert.ToDateTime(CalFechaDocumento.SelectedDate);	
			oProgramacionInspeccionesBE.FechaInicio = Convert.ToDateTime(calFechaInicio.SelectedDate);	

			if(calFechaTermino.SelectedDate.ToString() != Constantes.FECHAVALORENBLANCO)
			{
				oProgramacionInspeccionesBE.FechaTermino = Convert.ToDateTime(calFechaTermino.SelectedDate);	
			}

			oProgramacionInspeccionesBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oProgramacionInspeccionesBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.TipoSituacion);
			oProgramacionInspeccionesBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oProgramacionInspeccionesBE.IdTablaOrganismo = Convert.ToInt32(Enumerados.TablasTabla.OrganismosAuditores);
			oProgramacionInspeccionesBE.IdOrganismo = Convert.ToInt32(ddlbOrganismo.SelectedValue);
			oProgramacionInspeccionesBE.AsuntoDocumento = txtAsunto.Text;	

			if(txtObservaciones.Text.Trim()!=String.Empty)
			{
				oProgramacionInspeccionesBE.ObservacionDocumento = txtObservaciones.Text;	
			}
			oProgramacionInspeccionesBE.Periodo = Convert.ToInt32(ddlbPeriodo.SelectedValue);	
			oProgramacionInspeccionesBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.ProgramacionInspecciones);
			oProgramacionInspeccionesBE.IdEstado = Convert.ToInt32(Enumerados.EstadosProgramacionInspecciones.Activo);
			oProgramacionInspeccionesBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oProgramacionInspeccionesBE);

			if(retorno>0)
			{
				//Guardar el Archivo
				PathArchivoReferencia = System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.RUTAUPLOAD].ToString(); 
				Helper.SubirArchivo(flArchivoReferencia,PathArchivoReferencia,"OCI_" + retorno.ToString());
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se registró la Programación Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROPROGRAMACION));
			}
		}

		public void Modificar()
		{
			
			ProgramacionInspeccionesBE oProgramacionInspeccionesBE = new  ProgramacionInspeccionesBE();
			oProgramacionInspeccionesBE.ExtFile = Helper.ObtenerArchivoExtension(this.flArchivoReferencia.PostedFile.FileName.ToString())[1].ToString();

			oProgramacionInspeccionesBE.IdProgramacion = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oProgramacionInspeccionesBE.NroDocumento = txtNroDocumento.Text;
			oProgramacionInspeccionesBE.IdTablaTipoInspeccion = Convert.ToInt32(Enumerados.TablasTabla.UnidadMedida);
			oProgramacionInspeccionesBE.IdTipoInspeccion = Convert.ToInt32(ddlbTipoDocumento.SelectedValue);
			oProgramacionInspeccionesBE.FechaDocumento = Convert.ToDateTime(CalFechaDocumento.SelectedDate);	
			oProgramacionInspeccionesBE.FechaInicio = Convert.ToDateTime(calFechaInicio.SelectedDate);	

			if(calFechaTermino.SelectedDate.ToString() != Constantes.FECHAVALORENBLANCO)
			{
				oProgramacionInspeccionesBE.FechaTermino = Convert.ToDateTime(calFechaTermino.SelectedDate);	
			}

			oProgramacionInspeccionesBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oProgramacionInspeccionesBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.TipoSituacion);
			oProgramacionInspeccionesBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oProgramacionInspeccionesBE.IdTablaOrganismo = Convert.ToInt32(Enumerados.TablasTabla.OrganismosAuditores);
			oProgramacionInspeccionesBE.IdOrganismo = Convert.ToInt32(ddlbOrganismo.SelectedValue);
			oProgramacionInspeccionesBE.AsuntoDocumento = txtAsunto.Text;	

			if(txtObservaciones.Text.Trim()!=String.Empty)
			{
				oProgramacionInspeccionesBE.ObservacionDocumento = txtObservaciones.Text;	
			}
			oProgramacionInspeccionesBE.Periodo = Convert.ToInt32(ddlbPeriodo.SelectedValue);

			oProgramacionInspeccionesBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.ProgramacionInspecciones);
			oProgramacionInspeccionesBE.IdEstado = Convert.ToInt32(Enumerados.EstadosProgramacionInspecciones.Activo);
			oProgramacionInspeccionesBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oProgramacionInspeccionesBE)>0)
			{
				PathArchivoReferencia = System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.RUTAUPLOAD].ToString(); 
				Helper.SubirArchivo(flArchivoReferencia,PathArchivoReferencia,"OCI_" + oProgramacionInspeccionesBE.IdProgramacion.ToString());
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se modificó La Programación Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONPROGRAMACION));
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
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			ProgramacionInspeccionesBE oProgramacionInspeccionesBE = (ProgramacionInspeccionesBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.ProgramacionInspeccionesNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se consultó el Detalle de la Programación Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oProgramacionInspeccionesBE!=null)
			{
				txtNroDocumento.Text = oProgramacionInspeccionesBE.NroDocumento.ToString();
				ddlbTipoDocumento.Items.FindByValue(oProgramacionInspeccionesBE.IdTipoInspeccion.ToString()).Selected = true;				
				CalFechaDocumento.SelectedDate  = Convert.ToDateTime(oProgramacionInspeccionesBE.FechaDocumento);
				calFechaInicio.SelectedDate  = Convert.ToDateTime(oProgramacionInspeccionesBE.FechaInicio);

				if(oProgramacionInspeccionesBE.FechaTermino.ToString() != Constantes.FECHAVALORENBLANCO)
				{
					calFechaTermino.SelectedDate  = Convert.ToDateTime(oProgramacionInspeccionesBE.FechaTermino);
				}

				ddlbPeriodo.Items.FindByValue(oProgramacionInspeccionesBE.Periodo.ToString()).Selected = true;								
				ddlbCentroOperativo.Items.FindByValue(oProgramacionInspeccionesBE.IdCentroOperativo.ToString()).Selected = true;
				ddlbSituacion.Items.FindByValue(oProgramacionInspeccionesBE.IdSituacion.ToString()).Selected = true;				
				ddlbOrganismo.Items.FindByValue(oProgramacionInspeccionesBE.IdOrganismo.ToString()).Selected = true;				
				txtAsunto.Text = oProgramacionInspeccionesBE.AsuntoDocumento.ToString();	

				if(!oProgramacionInspeccionesBE.ObservacionDocumento.IsNull)
				{
					txtObservaciones.Text  = oProgramacionInspeccionesBE.ObservacionDocumento.Value.ToString();
				}
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
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEPROGRAMACIONCAMPOREQUERIDONRODOCUMENTO));
				return false;	
			}
			
			if(txtAsunto.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEPROGRAMACIONCAMPOREQUERIDOASUNTO));
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

	}
}
