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
using NetAccessControl;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio
{
	/// <summary>
	/// Summary description for DetalleRetenciones.
	/// </summary>
	public class DetalleGestionesDirectorio : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblConcepto;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvGestion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtGestion;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected eWorld.UI.CalendarPopup CalFechaGestion;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#endregion Controles

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
		const string TITULOMODONUEVO = "NUEVA GESTION";
		const string TITULOMODOMODIFICAR = "GESTION";

		//Key Session y QueryString
		const string KEYQIDACUERDO = "IdAcuerdo";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQIDTIPOINFORME = "IdTipoInforme";
		const string KEYQID = "Id";

		//Paginas
		const string URLPRINCIPAL = "AdministracionGestionesDirectorio.aspx?";
		const string URLDIALOGO = "../../GestionComercial/ComunicacionImagen/Dialogo.aspx";

		//Otros

		#endregion Constantes

		/// <summary>
		/// </summary>

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
			//lItem = new ListItem(Constantes.TEXTOSSELECCIONAR,Constantes.VALORSELECCIONAR);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePoderes.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvGestion.ErrorMessage = Helper.ObtenerMensajesConfirmacionLegalUsuario(Mensajes.CODIGOMENSAJEGESTIONINMUEBLECAMPOREQUERIDOGESTION);
			rfvGestion.ToolTip = Helper.ObtenerMensajesConfirmacionLegalUsuario(Mensajes.CODIGOMENSAJEGESTIONINMUEBLECAMPOREQUERIDOGESTION);

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
			GestionesDirectorioBE oGestionesDirectorioBE = new GestionesDirectorioBE();

			oGestionesDirectorioBE.IdSesionDirectorio = Convert.ToInt32(Helper.RetornaSessionParaDirectorio());
			oGestionesDirectorioBE.IdAcuerdo = Convert.ToInt32(Page.Request.QueryString[KEYQIDACUERDO]);
			oGestionesDirectorioBE.IdTablaTipoInforme  = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaTipoInforme);
			oGestionesDirectorioBE.IdTipoInforme  = Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOINFORME]);
			oGestionesDirectorioBE.FechaGestion = Convert.ToDateTime(CalFechaGestion.SelectedDate);
			oGestionesDirectorioBE.Gestion = Convert.ToString(txtGestion.Text);
			if(txtDescripcion.Text.Trim()!=String.Empty)
			{
				oGestionesDirectorioBE.DescripcionGestion = txtDescripcion.Text;	
			}
			oGestionesDirectorioBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oGestionesDirectorioBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.LegalEstadoGestionInmuebles);
			oGestionesDirectorioBE.IdEstado = Convert.ToInt32(Enumerados.EstadosGestionInmuebles.Activo);
			
			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oGestionesDirectorioBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestiones Directorio",this.ToString(),"Se registró la Retencion Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionLegal.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROGESTIONINMUEBLE));
			}
		}

		public void Modificar()
		{
			GestionesDirectorioBE oGestionesDirectorioBE = new GestionesDirectorioBE();

			oGestionesDirectorioBE.IdGestion  = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oGestionesDirectorioBE.IdSesionDirectorio = Convert.ToInt32(Helper.RetornaSessionParaDirectorio());
			oGestionesDirectorioBE.IdAcuerdo = Convert.ToInt32(Page.Request.QueryString[KEYQIDACUERDO]);
			oGestionesDirectorioBE.IdTablaTipoInforme  = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaTipoInforme);
			oGestionesDirectorioBE.IdTipoInforme  = Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOINFORME]);
			oGestionesDirectorioBE.FechaGestion = Convert.ToDateTime(CalFechaGestion.SelectedDate);
			oGestionesDirectorioBE.Gestion = Convert.ToString(txtGestion.Text);
			if(txtDescripcion.Text.Trim()!=String.Empty)
			{
				oGestionesDirectorioBE.DescripcionGestion = txtDescripcion.Text;	
			}

			oGestionesDirectorioBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oGestionesDirectorioBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.LegalEstadoGestionInmuebles);
			oGestionesDirectorioBE.IdEstado = Convert.ToInt32(Enumerados.EstadosGestionInmuebles.Activo);
			

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oGestionesDirectorioBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestiones Directorio",this.ToString(),"Se modificó la Gestión Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				
				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionLegal.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONGESTIONINMUEBLE));
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
		}

		public void CargarModoModificar()
		{
			lblTitulo.Text = TITULOMODOMODIFICAR;
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			GestionesDirectorioBE oGestionesDirectorioBE = (GestionesDirectorioBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.GestionesDirectorioNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestiones Directorio",this.ToString(),"Se consultó el Detalle de la Gestión Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oGestionesDirectorioBE!=null)
			{
				CalFechaGestion.SelectedDate  = Convert.ToDateTime(oGestionesDirectorioBE.FechaGestion);
				txtGestion.Text = oGestionesDirectorioBE.Gestion.ToString();
				if(!oGestionesDirectorioBE.DescripcionGestion.IsNull)
				{
					txtDescripcion.Text = oGestionesDirectorioBE.DescripcionGestion.ToString();
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
			if(txtGestion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionLegalUsuario(Mensajes.CODIGOMENSAJEGESTIONINMUEBLECAMPOREQUERIDOGESTION));
				return false;		
			}

			return true;		
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetallePoderes.ValidarExpresionesRegulares implementation
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
			Page.Response.Redirect(URLPRINCIPAL + KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[KEYQID] + Utilitario.Constantes.SIGNOAMPERSON + 
				KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQDESCRIPCION]);
		}


		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}
		
	}
}
