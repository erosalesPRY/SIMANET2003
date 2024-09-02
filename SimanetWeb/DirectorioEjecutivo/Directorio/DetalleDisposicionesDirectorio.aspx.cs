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
using SIMA.EntidadesNegocio.Secretaria.Directorio;
using NetAccessControl;



namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class DetalleDisposicionesDirectorio: System.Web.UI.Page,IPaginaBase//,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblSituacion;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtNroSesion;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected eWorld.UI.CalendarPopup CalFecha;
		protected System.Web.UI.WebControls.Label lblTema;
		protected System.Web.UI.WebControls.TextBox txtDisposicion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDisposicion;
		protected System.Web.UI.WebControls.Label lblAcuerdo;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA DISPOSICION DE DIRECTORIO";
		const string TITULOMODOMODIFICAR = "DISPOSICION DE DIRECTORIO";

		//Key Session y QueryString
		const string KEYQID = "Id";		
		const string KEYQIDTIPODISPOSICION = "IdTipoDisposicion";

		//Paginas
		const string URLPRINCIPAL = "AdministracionDisposicionesDirectorio.aspx?";
		const string URLDIALOGO = "../../GestionComercial/ComunicacionImagen/Dialogo.aspx";
	
		const int PERMANENTES = 0;
		const int GENERALES = 1;

		//Otros
		const string TITULOACUERDOSPERMANENTES = "Registro Acuerdos Permanentes";
		const string TITULOPROMOTOR = "Promotor";
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtDispuestoPor;
		const string TITULODISPOSICION = "Disposición";

		#endregion Constantes
		
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					this.LlenarJScript();

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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
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

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
		}

		private void llenarSituacion()
		{
			//ListItem lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			CTablaTablas oCTablaTablas =  new CTablaTablas();
			ddlbSituacion.DataSource = oCTablaTablas.ListarTodosComboDirectorio(Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaSituacionPedidos));
			ddlbSituacion.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();
			//ddlbSituacion.Items.Insert(0,lItem);
		}

		public void LlenarCombos()
		{
			this.llenarSituacion();
			this.llenarCentroOperativo();			
		}

		private void llenarCentroOperativo()
		{
			CCentroOperativo oCCentroOperativo = new CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Sigla1.ToString();
			ddlbCentroOperativo.DataBind();
		}

		public void LlenarDatos()
		{
			if (Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPODISPOSICION]) == PERMANENTES)
			{
				lblPagina.Text = TITULOACUERDOSPERMANENTES;
			}
			else
			{
				//lblTema.Text = TITULOPROMOTOR;
				lblAcuerdo.Text = TITULODISPOSICION;
			}			
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
			rfvDisposicion.ErrorMessage = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEINFORMEVARIOSSESIONDIRECTORIOCAMPOREQUERIDOTEMA);
			rfvDisposicion.ToolTip = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEINFORMEVARIOSSESIONDIRECTORIOCAMPOREQUERIDOTEMA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultaDeCartasFianzas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaDeCartasFianzas.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultaDeCartasFianzas.ConfigurarAccesoControles implementation

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

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			DisposicionesDirectorioBE oDisposicionesDirectorioBE= new DisposicionesDirectorioBE();
			oDisposicionesDirectorioBE.IdSesionDirectorio = Convert.ToInt32(Helper.RetornaSessionParaDirectorio());
			oDisposicionesDirectorioBE.Disposicion = txtDisposicion.Text;
			oDisposicionesDirectorioBE.Solicitante = txtDispuestoPor.Text;
			oDisposicionesDirectorioBE.NroSesion = txtNroSesion.Text;
			oDisposicionesDirectorioBE.FechaDisposicion = CalFecha.SelectedDate;
			oDisposicionesDirectorioBE.IdTablaTipoDisposicion = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaTipoDisposicion);
			oDisposicionesDirectorioBE.IdTipoDisposicion = Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPODISPOSICION]);

			if(txtObservacion.Text.Trim()!=String.Empty)
			{
				oDisposicionesDirectorioBE.ObservacionDisposicion = txtObservacion.Text;
			}
			oDisposicionesDirectorioBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oDisposicionesDirectorioBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaSituacionPedidos);
			oDisposicionesDirectorioBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oDisposicionesDirectorioBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioEstadosDisposicionesDirectorio);
			oDisposicionesDirectorioBE.IdEstado = Convert.ToInt32(Enumerados.EstadosDisposicionesDirectorio.Activo);
			oDisposicionesDirectorioBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			
			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oDisposicionesDirectorioBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se registró la Disposición de Directorio Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionDirectorio.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTRODISPOSICIONDIRECTORIO));
			}
		}

		public void Modificar()
		{
			DisposicionesDirectorioBE oDisposicionesDirectorioBE = new DisposicionesDirectorioBE();

			oDisposicionesDirectorioBE.IdDisposicion = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oDisposicionesDirectorioBE.IdSesionDirectorio = Convert.ToInt32(Helper.RetornaSessionParaDirectorio());
			oDisposicionesDirectorioBE.Disposicion = txtDisposicion.Text;
			oDisposicionesDirectorioBE.Solicitante = txtDispuestoPor.Text;
			oDisposicionesDirectorioBE.NroSesion = txtNroSesion.Text;
			oDisposicionesDirectorioBE.FechaDisposicion = CalFecha.SelectedDate;
			oDisposicionesDirectorioBE.IdTablaTipoDisposicion = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaTipoDisposicion);
			oDisposicionesDirectorioBE.IdTipoDisposicion = Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPODISPOSICION]);

			if(txtObservacion.Text.Trim()!=String.Empty)
			{
				oDisposicionesDirectorioBE.ObservacionDisposicion = txtObservacion.Text;
			}
			oDisposicionesDirectorioBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oDisposicionesDirectorioBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaSituacionPedidos);
			oDisposicionesDirectorioBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oDisposicionesDirectorioBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			
			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Modificar(oDisposicionesDirectorioBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se modificó la Disposición de Directorio Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionDirectorio.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONDISPOSICIONDIRECTORIO));
			}


		}

		public void Eliminar()
		{
			// TODO:  Add DetalleCuentasBancaria.Eliminar implementation
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
			DisposicionesDirectorioBE oDisposicionesDirectorioBE = (DisposicionesDirectorioBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.DisposicionesDirectorioNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se consultó el Detalle de la Disposición de Directorio Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oDisposicionesDirectorioBE!=null)
			{
				CalFecha.SelectedDate = oDisposicionesDirectorioBE.FechaDisposicion;
				txtDisposicion.Text = oDisposicionesDirectorioBE.Disposicion;
				txtDispuestoPor.Text = oDisposicionesDirectorioBE.Solicitante;
				txtNroSesion.Text = oDisposicionesDirectorioBE.NroSesion;

				if(!oDisposicionesDirectorioBE.ObservacionDisposicion.IsNull)
				{
					txtObservacion.Text = oDisposicionesDirectorioBE.ObservacionDisposicion.ToString(); 
				}

				ListItem lItem = ddlbSituacion.Items.FindByValue(oDisposicionesDirectorioBE.IdSituacion.ToString());
				if(lItem!=null){lItem.Selected = true;}

				lItem = ddlbCentroOperativo.Items.FindByValue(oDisposicionesDirectorioBE.IdCentroOperativo.ToString());			
				if(lItem!=null){lItem.Selected = true;}

			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleCuentasBancaria.CargarModoConsulta implementation
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
			if(txtNroSesion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert("Ingrese Nro. de Sesión");
				return false;		
			}			

			if(txtDispuestoPor.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert("Ingrese Datos del Promotor de Disposición");
				return false;		
			}			

			if(txtDisposicion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEINFORMEVARIOSSESIONDIRECTORIOCAMPOREQUERIDOTEMA));
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

		/// <summary>
		/// Abre la pagina de Administracion De PlanAnual DeControl
		/// </summary>
		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL + KEYQIDTIPODISPOSICION +  Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[KEYQIDTIPODISPOSICION].ToString());
		}

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}

		private void ddlbArea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}		
	}
}

