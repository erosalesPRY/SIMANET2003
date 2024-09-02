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
using SIMA.EntidadesNegocio.GestionControlInstitucional;
using NetAccessControl;
using System.IO;

namespace SIMA.SimaNetWeb.GestionControlInstituacional
{
	/// <summary>
	/// Summary description for DetallePoderes.
	/// </summary>
	public class DetalleControlInterno : System.Web.UI.Page, IPaginaBase
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
		protected System.Web.UI.WebControls.TextBox txtEntidad;
		protected System.Web.UI.WebControls.Image ibtnBuscar;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtAsunto;
		protected System.Web.UI.WebControls.Label lblConcepto;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTablaEntidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdEntidad;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroDocumento;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvOrganismo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvAsunto;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNumero;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected eWorld.UI.CalendarPopup calFechaTermino;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtSituacionActual;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvSituacionActual;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
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
		const string TITULOMODONUEVO = "NUEVO CONTROL";
		const string TITULOMODOMODIFICAR = "CONTROL";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYIDCO = "CentroOperativo";

		//Paginas
		const string URLBUSQUEDAENTIDAD = "../Legal/BusquedaEntidad.aspx";
		const string URLBUSQUEDAPERSONAL = "../Legal/BusquedaPersonal.aspx?";

		#endregion Constantes
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

		private void llenarTipoDocumento()
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
			this.llenarTipoDocumento();
			this.llenarTipoSituacion();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePoderes.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvNroDocumento.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDONRODOCUMENTO);
			rfvNroDocumento.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDONRODOCUMENTO);

			rfvOrganismo.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOORGANISMO);
			rfvOrganismo.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOORGANISMO);

			/*rfvRepresentante.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOREPRESENTANTE);
			rfvRepresentante.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOREPRESENTANTE);*/

			rfvAsunto.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOASUNTO);
			rfvAsunto.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOASUNTO);

			rfvSituacionActual.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOSITUACIONACTUAL);
			rfvSituacionActual.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOSITUACIONACTUAL);

			ibtnBuscar.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAENTIDAD,600,350,true));
			/*ibtnBuscarPersonal.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(
				URLBUSQUEDAPERSONAL + KEYIDCO + Utilitario.Constantes.SIGNOIGUAL + ddlbCentroOperativo.SelectedValue,700,500,true));*/
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

		/*private void WriteToFile(string strPath, ref byte[] Buffer)
		{
			// Create a file
			FileStream newFile = new FileStream(strPath,FileMode.Create);	

			// Write data to the file
			newFile.Write(Buffer, 0, Buffer.Length);

			// Close file
			newFile.Close();
		}*/

		/*public void GuardarContrato() 
		{
			HttpPostedFile myFile = filContrato.PostedFile;
			int nFileLen = myFile.ContentLength; 
					
			if( nFileLen > 0 )
			{
				if(nFileLen <= 5000000)
				{	
					byte[] myData = new byte[nFileLen];

					myFile.InputStream.Read(myData, 0, nFileLen);
					//string path = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.RUTAIMAGENES);
					string path = Helper.ObtenerRutaImagenes(Constantes.RUTAIMAGENES);
					string strFilename = myFile.FileName;

					string[] res = strFilename.Split('\\');
					int i=res.GetUpperBound(0);
					strFilename = res[i];
							
					WriteToFile(path + strFilename,ref myData);	
				}
			}		
		}*/
		#region IPaginaMantenimento Members

		public void Agregar()
		{
			ControlInternoBE oControlInternoBE= new  ControlInternoBE();
			oControlInternoBE.NroDocumento = txtNroDocumento.Text;
			oControlInternoBE.IdTablaTipoDocumento = Convert.ToInt32(Enumerados.TablasTabla.UnidadMedida);
			oControlInternoBE.IdTipoDocumento = Convert.ToInt32(ddlbTipoDocumento.SelectedValue);
			oControlInternoBE.FechaDocumento = Convert.ToDateTime(CalFechaDocumento.SelectedDate);	
			oControlInternoBE.FechaInicio = Convert.ToDateTime(calFechaInicio.SelectedDate);	

			if(calFechaTermino.SelectedDate.ToString() != Constantes.FECHAVALORENBLANCO)
			{
				oControlInternoBE.FechaTermino = Convert.ToDateTime(calFechaTermino.SelectedDate);	
			}

			oControlInternoBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.TipoSituacion);
			oControlInternoBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oControlInternoBE.IdTablaEntidad  = Convert.ToInt32(hIdTablaEntidad.Value);
			oControlInternoBE.IdEntidad  = Convert.ToInt32(hIdEntidad.Value);
			oControlInternoBE.IdOrganismo = Convert.ToInt32(hIdCodigo.Value);
			oControlInternoBE.AsuntoDocumento = txtAsunto.Text;	

			if(txtObservaciones.Text.Trim()!=String.Empty)
			{
				oControlInternoBE.ObservacionDocumento = txtObservaciones.Text;	
			}

			//oControlInternoBE.Representante = txtRepresentante.Text;	
			oControlInternoBE.SituacionActual = txtSituacionActual.Text;	
			oControlInternoBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.ControlInterno);
			oControlInternoBE.IdEstado = Convert.ToInt32(Enumerados.EstadosControlInterno.Activo);
			oControlInternoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oControlInternoBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se registró el Documento Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROCONTROL));
			}
		}

		public void Modificar()
		{
			ControlInternoBE oControlInternoBE = new  ControlInternoBE();

			oControlInternoBE.IdDocumentoControl = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oControlInternoBE.NroDocumento = txtNroDocumento.Text;
			oControlInternoBE.IdTablaTipoDocumento = Convert.ToInt32(Enumerados.TablasTabla.UnidadMedida);
			oControlInternoBE.IdTipoDocumento = Convert.ToInt32(ddlbTipoDocumento.SelectedValue);
			oControlInternoBE.FechaDocumento = Convert.ToDateTime(CalFechaDocumento.SelectedDate);	
			oControlInternoBE.FechaInicio = Convert.ToDateTime(calFechaInicio.SelectedDate);	

			if(calFechaTermino.SelectedDate.ToString() != Constantes.FECHAVALORENBLANCO)
			{
				oControlInternoBE.FechaTermino = Convert.ToDateTime(calFechaTermino.SelectedDate);	
			}
			
			oControlInternoBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.TipoSituacion);
			oControlInternoBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oControlInternoBE.IdTablaEntidad  = Convert.ToInt32(hIdTablaEntidad.Value);
			oControlInternoBE.IdEntidad  = Convert.ToInt32(hIdEntidad.Value);
			oControlInternoBE.IdOrganismo = Convert.ToInt32(hIdCodigo.Value);
			oControlInternoBE.AsuntoDocumento = txtAsunto.Text;	

			if(txtObservaciones.Text.Trim()!=String.Empty)
			{
				oControlInternoBE.ObservacionDocumento = txtObservaciones.Text;	
			}

			//oControlInternoBE.Representante = txtRepresentante.Text;	
			oControlInternoBE.SituacionActual = txtSituacionActual.Text;	
			oControlInternoBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.ControlInterno);
			oControlInternoBE.IdEstado = Convert.ToInt32(Enumerados.EstadosControlInterno.Activo);
			oControlInternoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oControlInternoBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se modificó el Documento Control Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONCONTROL));
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
			ControlInternoBE oControlInternoBE = (ControlInternoBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.ControlInstitucionalNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se consultó el Detalle del Documento Control Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oControlInternoBE!=null)
			{
				txtNroDocumento.Text = oControlInternoBE.NroDocumento.ToString();
				ddlbTipoDocumento.Items.FindByValue(oControlInternoBE.IdTipoDocumento.ToString()).Selected = true;				
				CalFechaDocumento.SelectedDate  = Convert.ToDateTime(oControlInternoBE.FechaDocumento);
				calFechaInicio.SelectedDate  = Convert.ToDateTime(oControlInternoBE.FechaInicio);

				if(oControlInternoBE.FechaTermino.ToString() != Constantes.FECHAVALORENBLANCO)
				{
					calFechaTermino.SelectedDate  = Convert.ToDateTime(oControlInternoBE.FechaTermino);
				}
				
				ddlbSituacion.Items.FindByValue(oControlInternoBE.IdSituacion.ToString()).Selected = true;				
				txtEntidad.Text = oControlInternoBE.Organismo.ToString();
				hIdTablaEntidad.Value = oControlInternoBE.IdTablaEntidad.ToString();
				hIdEntidad.Value = oControlInternoBE.IdEntidad.ToString();
				hIdCodigo.Value = oControlInternoBE.IdOrganismo.ToString();
				txtAsunto.Text = oControlInternoBE.AsuntoDocumento.ToString();	

				if(!oControlInternoBE.ObservacionDocumento.IsNull)
				{
					txtObservaciones.Text  = oControlInternoBE.ObservacionDocumento.Value.ToString();
				}

				//txtRepresentante.Text = oControlInternoBE.Representante.ToString();	
				txtSituacionActual.Text = oControlInternoBE.SituacionActual.ToString();	
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
			
			if(txtEntidad.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOORGANISMO));
				return false;	
			}

//			if(txtRepresentante.Text.Trim()==String.Empty)
//			{
//				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOREPRESENTANTE));
//				return false;	
//			}

			if(txtAsunto.Text.Trim()==String.Empty)
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

	}
}
