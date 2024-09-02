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
using SIMA.Controladoras.Secretaria.Directorio;

using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.Secretaria.Directorio;
//using SIMA.LogicaNegocio.Secretaria;
using NetAccessControl;



namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class DetalleSesionDirectorio: System.Web.UI.Page,IPaginaBase//,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDestino;
		protected eWorld.UI.NumericBox txtPorcentajeAvance2;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblNroSesion;
		protected System.Web.UI.WebControls.TextBox txtNumeroSesion;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label lblHora;
		protected System.Web.UI.WebControls.Label lblLugar;
		protected System.Web.UI.WebControls.TextBox txtLugar;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvLugar;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroSesion;
		protected eWorld.UI.TimePicker TimHora;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected eWorld.UI.CalendarPopup CalFecha;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoSesion;
		protected System.Web.UI.WebControls.Label Label2;
		protected eWorld.UI.CalendarPopup calFechaCierre;

		#endregion Controles

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA SESION DE DIRECTORIO";
		const string TITULOMODOMODIFICAR = "SESION DE DIRECTORIO";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDSESIONDIRECTORIO= "IdSesionDirectorio";
	
		//Paginas
		const string URLPRINCIPAL = "ConsultaDeAgendaDirectorio.aspx";
		const string URLDIALOGO = "../../GestionComercial/ComunicacionImagen/Dialogo.aspx";
		
		#endregion Constantes
		
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					this.LlenarJScript();
					this.VerificarSesionDefault();

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

		private void VerificarSesionDefault()
		{
			CSesionDirectorio oCSesionDirectorio = new CSesionDirectorio();
			DataTable dt = oCSesionDirectorio.ConsultarUltimaSesionDirectorio();

			if (HttpContext.Current.Session[Utilitario.Constantes.KEYSIDSESIONDIRECTORIO] == null && dt != null)
			{
				Helper.GeneraSessionParaDirectorio(dt.Rows[0][Utilitario.Constantes.IDSESIONDIRECTORIO].ToString());
			}
			else
			{
				this.AsignarSession();
			}

		}
		private void AsignarSession()
		{
			if (Page.Request.QueryString[KEYQIDSESIONDIRECTORIO] != null)
			{
				Helper.GeneraSessionParaDirectorio(Page.Request.QueryString[KEYQIDSESIONDIRECTORIO].ToString());
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

		public void LlenarCombos()
		{
			this.llenarTiposDeSesion();	
		}

		private void llenarTiposDeSesion()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();
			ddlbTipoSesion.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaTipoSesion));
			ddlbTipoSesion.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoSesion.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipoSesion.DataBind();
		}	

		public void LlenarDatos()
		{			
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
			rfvNroSesion.ErrorMessage = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJESESIONDIRECTORIOCAMPOREQUERIDONRO);
			rfvNroSesion.ToolTip = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJESESIONDIRECTORIOCAMPOREQUERIDONRO);//rfvNroSesion.ErrorMessage;

			rfvLugar.ErrorMessage = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJESESIONDIRECTORIOCAMPOREQUERIDOLUGAR);
			rfvLugar.ToolTip = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJESESIONDIRECTORIOCAMPOREQUERIDOLUGAR);//rfvLugar.ErrorMessage;

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

			SesionDirectorioBE oSesionDirectorioBE = new SesionDirectorioBE();
			oSesionDirectorioBE.NroSesionDirectorio = txtNumeroSesion.Text;
			oSesionDirectorioBE.Lugar = txtLugar.Text;
			
			DateTime fecha = new DateTime(CalFecha.SelectedDate.Year,CalFecha.SelectedDate.Month,CalFecha.SelectedDate.Day,TimHora.SelectedTime.Hour,TimHora.SelectedTime.Minute,TimHora.SelectedTime.Millisecond);
			oSesionDirectorioBE.Fecha = fecha;
			oSesionDirectorioBE.FechaCierre = calFechaCierre.SelectedDate;

			oSesionDirectorioBE.Periodo = DateTime.Now.Year;
			oSesionDirectorioBE.IdTablaTipoSesion = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaTipoSesion);
			oSesionDirectorioBE.IdTipoSesion = 	Convert.ToInt32(ddlbTipoSesion.SelectedValue);
			oSesionDirectorioBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioEstadosSesionDirectorio);
			oSesionDirectorioBE.IdEstado = Convert.ToInt32(Enumerados.EstadosSesionDirectorio.Activo);
			oSesionDirectorioBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			//SesionDirectorioLN oSesionDirectorioLN = new SesionDirectorioLN();
			//oSesionDirectorioLN.RegistrarSesionDirectorio(oSesionDirectorioBE,null,1);

			//CMantenimientos oCMantenimientos = new CMantenimientos();

			if (HttpContext.Current.Session[Utilitario.Constantes.KEYSIDSESIONDIRECTORIO] != null)
			{
				//int retorno = oSesionDirectorioLN.RegistrarSesionDirectorio(oSesionDirectorioBE,Convert.ToInt32(HttpContext.Current.Session[Utilitario.Constantes.KEYSIDSESIONDIRECTORIO]));
				int retorno = (new CSesionDirectorio()).RegistrarSesionDirectorio(oSesionDirectorioBE,Convert.ToInt32(HttpContext.Current.Session[Utilitario.Constantes.KEYSIDSESIONDIRECTORIO]));

				if(retorno>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se registró la Sesión de Directorio Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

					ltlMensaje.Text = Helper.MensajeRetornoAlert(
						Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionDirectorio.ToString()
						,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROSESIONDIRECTORIO));
				}
			}
		}

		public void Modificar()
		{
			SesionDirectorioBE oSesionDirectorioBE = new SesionDirectorioBE();
			oSesionDirectorioBE.IdSesionDirectorio = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oSesionDirectorioBE.NroSesionDirectorio = txtNumeroSesion.Text;
			oSesionDirectorioBE.Lugar = txtLugar.Text;

			DateTime fecha = new DateTime(CalFecha.SelectedDate.Year,CalFecha.SelectedDate.Month,CalFecha.SelectedDate.Day,TimHora.SelectedTime.Hour,TimHora.SelectedTime.Minute,TimHora.SelectedTime.Millisecond);
			oSesionDirectorioBE.Fecha = fecha;
			oSesionDirectorioBE.FechaCierre = calFechaCierre.SelectedDate;

			oSesionDirectorioBE.IdTablaTipoSesion = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaTipoSesion);
			oSesionDirectorioBE.IdTipoSesion = 	Convert.ToInt32(ddlbTipoSesion.SelectedValue);
			oSesionDirectorioBE.Periodo = DateTime.Now.Year;
			oSesionDirectorioBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			
			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Modificar(oSesionDirectorioBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se modificó la Sesión de Directorio Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionDirectorio.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONSESIONDIRECTORIO));
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
			SesionDirectorioBE oSesionDirectorioBE = (SesionDirectorioBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.SesionDirectorioNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se consultó el Detalle de la Sesión de Directorio Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oSesionDirectorioBE!=null)
			{
				txtLugar.Text = oSesionDirectorioBE.Lugar;
				txtNumeroSesion.Text = oSesionDirectorioBE.NroSesionDirectorio;
				CalFecha.SelectedDate = oSesionDirectorioBE.Fecha;
				CalFecha.VisibleDate = oSesionDirectorioBE.Fecha;
				TimHora.SelectedTime = oSesionDirectorioBE.Fecha;
				
				calFechaCierre.SelectedDate = oSesionDirectorioBE.FechaCierre;

				ListItem lItem;
				lItem = ddlbTipoSesion.Items.FindByValue(oSesionDirectorioBE.IdTipoSesion.ToString());
				if(lItem!=null)
				{lItem.Selected = true;}
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
			if(txtNumeroSesion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJESESIONDIRECTORIOCAMPOREQUERIDONRO));
							
				return false;		
			}

			if(txtLugar.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJESESIONDIRECTORIOCAMPOREQUERIDOLUGAR));
				
				
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
			Page.Response.Redirect(URLPRINCIPAL);
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

