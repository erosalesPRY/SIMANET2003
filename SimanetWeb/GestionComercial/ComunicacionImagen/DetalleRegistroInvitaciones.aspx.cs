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
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio.GestionComercial;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for DetalleRegistroInvitaciones.
	/// </summary>
	public class DetalleRegistroInvitaciones: System.Web.UI.Page, IPaginaMantenimento, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.RadioButtonList rblTipoPersona;
		protected System.Web.UI.WebControls.Label lblNombrePersona;
		protected System.Web.UI.WebControls.TextBox txtPersonal;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarPersonal;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombrePersona;
		protected System.Web.UI.WebControls.Label lblGradoCargo;
		protected System.Web.UI.WebControls.TextBox txtGradoCargo;
		protected System.Web.UI.WebControls.Label lblFechaLanzamiento;
		protected eWorld.UI.CalendarPopup calFechaLanzamiento;
		protected System.Web.UI.WebControls.Label lblNombreBuque;
		protected System.Web.UI.WebControls.TextBox txtNombreBuque;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarBuque;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombreBuque;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonal;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdBuque;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles
		
		#region Constantes
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO REGISTRO DE INVITACION";
		const string TITULOMODOMODIFICAR = "ACTUALIZACION DE REGISTRO DE INVITACION";
		const string TITULOMODOCONSULTA = "DETALLE DE REGISTRO DE INVITACION";

		//Key Session y QueryString
		const string KEYQID = "Id";
	
		//Paginas
		const string URLBUSQUEDABUQUE = "../BusquedaBuque.aspx";
		const string URLBUSQUEDAPERSONAL = "../../Legal/BusquedaPersonal.aspx";

		//Otros
		const int REGISTRADO   = 0;
		const int NOREGISTRADO = 1;
		#endregion Constantes
		
		#region Variables		
		#endregion Variables		
		
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
			this.rblTipoPersona.SelectedIndexChanged += new System.EventHandler(this.rblTipoPersona_SelectedIndexChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			RegistroInvitacionesBE oRegistroInvitacionesBE = new RegistroInvitacionesBE();
			if(this.rblTipoPersona.SelectedIndex == Constantes.POSICIONCONTADOR)
			{
				if(this.hIdPersonal.Value.Trim()!=String.Empty)
				{
					oRegistroInvitacionesBE.IdPersonal = Convert.ToInt32(this.hIdPersonal.Value);
				}
			}
			else
			{
				if(this.txtPersonal.Text.Trim()!=String.Empty)
				{
					oRegistroInvitacionesBE.NombrePersona = this.txtPersonal.Text;
				}
				if(this.txtGradoCargo.Text.Trim()!=String.Empty)
				{
					oRegistroInvitacionesBE.GradoCargoPersona = this.txtGradoCargo.Text;
				}
			}
			oRegistroInvitacionesBE.FechaLanzamiento = this.calFechaLanzamiento.SelectedDate;
			oRegistroInvitacionesBE.IdBuque = Convert.ToInt32(this.hIdBuque.Value);
			oRegistroInvitacionesBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oRegistroInvitacionesBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosRegistroInvitacion);
			oRegistroInvitacionesBE.IdEstado = Convert.ToInt32(Enumerados.EstadosRegistroInvitacion.Activo);
			if(this.txtDescripcion.Text.Trim()!=String.Empty)
			{
				oRegistroInvitacionesBE.Descripcion = this.txtDescripcion.Text;
			}
			if(this.txtObservaciones.Text.Trim()!=String.Empty)
			{
				oRegistroInvitacionesBE.Observaciones = this.txtObservaciones.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oRegistroInvitacionesBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró el Registro de Invitacion Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROREGISTROINVITACION));
			}
		}

		public void Modificar()
		{
			RegistroInvitacionesBE oRegistroInvitacionesBE = new RegistroInvitacionesBE();
			oRegistroInvitacionesBE.IdRegistroInvitaciones = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			if(this.rblTipoPersona.SelectedIndex == Constantes.POSICIONCONTADOR)
			{
				if(this.hIdPersonal.Value.Trim()!=String.Empty)
				{
					oRegistroInvitacionesBE.IdPersonal = Convert.ToInt32(this.hIdPersonal.Value);
				}
			}
			else
			{
				if(this.txtPersonal.Text.Trim()!=String.Empty)
				{
					oRegistroInvitacionesBE.NombrePersona = this.txtPersonal.Text;
				}
				if(this.txtGradoCargo.Text.Trim()!=String.Empty)
				{
					oRegistroInvitacionesBE.GradoCargoPersona = this.txtGradoCargo.Text;
				}
			}
			oRegistroInvitacionesBE.FechaLanzamiento = this.calFechaLanzamiento.SelectedDate;
			oRegistroInvitacionesBE.IdBuque = Convert.ToInt32(this.hIdBuque.Value);
			oRegistroInvitacionesBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oRegistroInvitacionesBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosRegistroInvitacion);
			oRegistroInvitacionesBE.IdEstado = Convert.ToInt32(Enumerados.EstadosRegistroInvitacion.Modificado);
			if(this.txtDescripcion.Text.Trim()!=String.Empty)
			{
				oRegistroInvitacionesBE.Descripcion = this.txtDescripcion.Text;
			}
			if(this.txtObservaciones.Text.Trim()!=String.Empty)
			{
				oRegistroInvitacionesBE.Observaciones = this.txtObservaciones.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oRegistroInvitacionesBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó el Registro de Invitaciones Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROREGISTROINVITACION));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.Eliminar implementation
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
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODONUEVO;
		}

		public void CargarModoModificar()
		{
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			RegistroInvitacionesBE oRegistroInvitacionesBE = (RegistroInvitacionesBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.RegistroInvitacionesNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Registro de Invitaciones Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oRegistroInvitacionesBE!=null)
			{
				if(!oRegistroInvitacionesBE.IdPersonal.IsNull)
				{
					this.hIdPersonal.Value = oRegistroInvitacionesBE.IdPersonal.ToString();
					CPersonal oCPersonal = new CPersonal();
					this.txtPersonal.Text = oCPersonal.ObtenerNombrePersonal(Convert.ToInt32(this.hIdPersonal.Value));
					this.rblTipoPersona.SelectedIndex = 0;
					this.txtPersonal.ReadOnly = true;
					this.ibtnBuscarPersonal.Visible = true;
					this.txtGradoCargo.Visible = false;
				}
				else
				{
					this.txtPersonal.Text = oRegistroInvitacionesBE.NombrePersona.ToString();
					this.txtGradoCargo.Text = oRegistroInvitacionesBE.GradoCargoPersona.ToString();
					this.rblTipoPersona.SelectedIndex = 1;
					this.txtPersonal.ReadOnly = false;
					this.ibtnBuscarPersonal.Visible = false;
					this.txtGradoCargo.Visible = true;
				}
				this.calFechaLanzamiento.SelectedDate = oRegistroInvitacionesBE.FechaLanzamiento;
				this.hIdBuque.Value = oRegistroInvitacionesBE.IdBuque.ToString();
				CBuque oCBuque = new CBuque();
				this.txtNombreBuque.Text = oCBuque.ObtenerNombreBuque(Convert.ToInt32(this.hIdBuque.Value));
				if(!oRegistroInvitacionesBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text = oRegistroInvitacionesBE.Descripcion.ToString();
				}
				if(!oRegistroInvitacionesBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oRegistroInvitacionesBE.Observaciones.ToString();
				}
			}
		}

		public void CargarModoConsulta()
		{
			lblTitulo.Text = TITULOMODOCONSULTA;
			this.ibtnCancelar.Visible = false;
			this.rblTipoPersona.Visible = false;
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			RegistroInvitacionesBE oRegistroInvitacionesBE = (RegistroInvitacionesBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.RegistroInvitacionesNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Registro de Invitaciones Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oRegistroInvitacionesBE!=null)
			{
				if(!oRegistroInvitacionesBE.IdPersonal.IsNull)
				{
					this.hIdPersonal.Value = oRegistroInvitacionesBE.IdPersonal.ToString();
					CPersonal oCPersonal = new CPersonal();
					this.txtPersonal.Text = oCPersonal.ObtenerNombrePersonal(Convert.ToInt32(this.hIdPersonal.Value));
					this.rblTipoPersona.SelectedIndex = 0;
					this.txtPersonal.ReadOnly = true;
					this.ibtnBuscarPersonal.Visible = true;
					this.txtGradoCargo.Visible = false;
				}
				else
				{
					this.txtPersonal.Text = oRegistroInvitacionesBE.NombrePersona.ToString();
					this.txtGradoCargo.Text = oRegistroInvitacionesBE.GradoCargoPersona.ToString();
					this.rblTipoPersona.SelectedIndex = 1;
					this.txtPersonal.ReadOnly = false;
					this.ibtnBuscarPersonal.Visible = false;
					this.txtGradoCargo.Visible = true;
				}
				this.calFechaLanzamiento.SelectedDate = oRegistroInvitacionesBE.FechaLanzamiento;
				this.hIdBuque.Value = oRegistroInvitacionesBE.IdBuque.ToString();
				CBuque oCBuque = new CBuque();
				this.txtNombreBuque.Text = oCBuque.ObtenerNombreBuque(Convert.ToInt32(this.hIdBuque.Value));
				if(!oRegistroInvitacionesBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text = oRegistroInvitacionesBE.Descripcion.ToString();
				}
				if(!oRegistroInvitacionesBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oRegistroInvitacionesBE.Observaciones.ToString();
				}
			}
			Helper.BloquearControles(this);
		}

		public bool ValidarCampos()
		{
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.txtPersonal.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREGISTROINVITACIONCAMPOREQUERIDOPERSONA));
				return false;
			}
			if(this.txtNombreBuque.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREGISTROINVITACIONCAMPOREQUERIDOBUQUE));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleRegistroInvitaciones.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleRegistroInvitaciones.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleRegistroInvitaciones.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleRegistroInvitaciones.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleRegistroInvitaciones.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.rfvNombrePersona.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREGISTROINVITACIONCAMPOREQUERIDOPERSONA);
			this.rfvNombrePersona.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREGISTROINVITACIONCAMPOREQUERIDOPERSONA);

			this.rfvNombreBuque.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREGISTROINVITACIONCAMPOREQUERIDOBUQUE);
			this.rfvNombreBuque.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREGISTROINVITACIONCAMPOREQUERIDOBUQUE);

			this.ibtnBuscarPersonal.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAPERSONAL,750,500,true));
			this.ibtnBuscarBuque.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDABUQUE,750,500,true));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleRegistroInvitaciones.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleRegistroInvitaciones.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleRegistroInvitaciones.Exportar implementation
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

		private void rblTipoPersona_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.rblTipoPersona.SelectedIndex == REGISTRADO)
			{
				this.ConfigurarCamposPersonalRegistrado();
			}
			else if(this.rblTipoPersona.SelectedIndex == NOREGISTRADO)
			{
				this.ConfigurarCamposPersonalNoRegistrado();
			}
		}

		private void ConfigurarCamposPersonalRegistrado()
		{
			this.txtPersonal.ReadOnly = true;
			this.ibtnBuscarPersonal.Visible = true;
			this.txtGradoCargo.Visible = false;
			this.LimpiarCampos();
		}

		private void ConfigurarCamposPersonalNoRegistrado()
		{
			this.txtPersonal.ReadOnly = false;
			this.ibtnBuscarPersonal.Visible = false;
			this.txtGradoCargo.Visible = true;
			this.LimpiarCampos();
		}

		private void LimpiarCampos()
		{
			this.txtPersonal.Text = Constantes.VACIO;
			this.txtGradoCargo.Text = Constantes.VACIO;
			this.hIdPersonal.Value = Constantes.VACIO;
		}
	}
}