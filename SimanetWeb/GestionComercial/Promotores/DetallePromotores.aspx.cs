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
using SIMA.EntidadesNegocio.GestionComercial;
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;

namespace SIMA.SimaNetWeb.GestionComercial.Promotores
{
	/// <summary>
	/// Summary description for DetallePromotores.
	/// </summary>
	public class DetallePromotores: System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Controles

		protected System.Web.UI.WebControls.ValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCliente;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.TextBox txtNacionalidad;
		protected System.Web.UI.WebControls.RadioButtonList rblNacionalidad;
		protected System.Web.UI.WebControls.Label lblNacionalidad;
		#endregion

		#region Constantes

		//Titulos
		const string TITULOMODONUEVO = "NUEVO PROMOTOR";
		const string TITULOMODOMODIFICAR = "PROMOTOR";
		const string TITULOMODOCONSULTA = "DETALLES DEL PROMOTOR";

		//Otros
		const int ClienteJuridico = 3;
		const int ClienteNatural = 4;

		//Key Session y QueryString
		const string KEYQIDPROMOTOR = "Id";

		#endregion

		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblRazonSocial;
		protected System.Web.UI.WebControls.TextBox txtProveedor;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombre;
		protected System.Web.UI.WebControls.Label lblRuc;
		protected System.Web.UI.WebControls.TextBox txtIdentificacionPersonal;
		protected System.Web.UI.WebControls.Label lblPais;
		protected System.Web.UI.WebControls.Label lblUbicacion;
		protected System.Web.UI.WebControls.Label lblDireccion;
		protected System.Web.UI.WebControls.TextBox txtDireccion;
		protected System.Web.UI.WebControls.Label lblTelefono;
		protected System.Web.UI.WebControls.TextBox txtTelefono;
		protected System.Web.UI.WebControls.Label lblNroFax;
		protected System.Web.UI.WebControls.TextBox txtNroFax;
		protected System.Web.UI.WebControls.Label lblCelular;
		protected System.Web.UI.WebControls.TextBox txtCelular;
		protected System.Web.UI.WebControls.Label lblCorreoElectronico;
		protected System.Web.UI.WebControls.TextBox txtCorreoElectronico;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblTipo;
		protected System.Web.UI.WebControls.Label lblMensaje1;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellBtnAtras;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras;
		
		#region Variables 
		ListItem item;
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
			// TODO:  Add DetallePromotores.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePromotores.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePromotores.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePromotores.LlenarDatos implementation
		}


		public void LlenarJScript()
		{

			//this.rfvTipoClienteLegal.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOTIPOCLIENTELEGAL);
			//this.rfvTipoClienteLegal.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOTIPOCLIENTELEGAL);

			this.rfvNombre.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDONOMBRE);
			this.rfvNombre.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDONOMBRE);

//			this.rfvApellidoPaterno.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOAPELLIDOPATERNO);
//			this.rfvApellidoPaterno.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOAPELLIDOPATERNO);
//
//			this.rfvApellidoMaterno.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOAPELLIDOMATERNO);
//			this.rfvApellidoMaterno.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOAPELLIDOMATERNO);

			//this.rfvDocIdentidad_Ruc.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDODOCIDENTIDADRUC);
			//this.rfvDocIdentidad_Ruc.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDODOCIDENTIDADRUC);

		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePromotores.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePromotores.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePromotores.Exportar implementation
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
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			PromotorBE oPromotorBE = new PromotorBE();
			oPromotorBE.NroRUC = this.txtIdentificacionPersonal.Text;

			if(this.txtCorreoElectronico.Text.Trim() != String.Empty)
			{
				oPromotorBE.CorreoElectronico = this.txtCorreoElectronico.Text;
			}
			if(this.txtCelular.Text.Trim() != String.Empty)
			{
				oPromotorBE.Celular = this.txtCelular.Text;
			}
			if(this.txtObservaciones.Text.Trim() != String.Empty)
			{
				oPromotorBE.Observaciones = this.txtObservaciones.Text;
			}
			if(this.txtIdentificacionPersonal.Text.Trim()!=String.Empty){
				oPromotorBE.NroRUC = this.txtIdentificacionPersonal.Text;
			}

			oPromotorBE.IdUsuarioRegistrto =  CNetAccessControl.GetIdUser();
			oPromotorBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoPromotor);
			oPromotorBE.IdEstado = Convert.ToInt32(Enumerados.EstadosPromotor.Activo);

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oPromotorBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró al Promotor. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROPROMOTOR));
			}	

		}

		public void Modificar()
		{
			PromotorBE oPromotorBE = new PromotorBE();

			oPromotorBE.IdPromotor = Convert.ToInt32(Page.Request.QueryString[KEYQIDPROMOTOR]);
			oPromotorBE.NroRUC = this.txtIdentificacionPersonal.Text;
			if(this.txtCorreoElectronico.Text.Trim() != String.Empty)
			{
				oPromotorBE.CorreoElectronico = this.txtCorreoElectronico.Text;
			}
			if(this.txtCelular.Text.Trim() != String.Empty)
			{
				oPromotorBE.Celular = this.txtCelular.Text;
			}
			if(this.txtObservaciones.Text.Trim() != String.Empty)
			{
				oPromotorBE.Observaciones = this.txtObservaciones.Text;
			}

			oPromotorBE.IdUsuarioActualizacion =  CNetAccessControl.GetIdUser(); 

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oPromotorBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó al Promotor. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICOPROMOTOR));
			}	
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePromotores.Eliminar implementation
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
					this.txtProveedor.ReadOnly=true;
					CellBtnAtras.Style.Add("display","none");
					this.CargarModoModificar();
					break;
				case Enumerados.ModoPagina.C:
					this.CargarModoConsulta();
					break;
			}
		}

		public void CargarModoNuevo()
		{
			this.LlenarCombos();
			this.DesabilitarCeldas();
			ibtnAtras.Visible=false;
			lblTitulo.Text = TITULOMODONUEVO;
		}

		public void CargarModoModificar()
		{
			this.LlenarCombos();
			ibtnAtras.Visible=false;
			lblTitulo.Text = TITULOMODOMODIFICAR;

			CMantenimientos	oCMantenimientos = new CMantenimientos();
			PromotorBE oPromotorBE = (PromotorBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDPROMOTOR]),Enumerados.ClasesNTAD.PromotorNTAD.ToString());

			if(oPromotorBE != null)
			{
				txtProveedor.Text = oPromotorBE.RazonSocial.ToString();
				this.lblTipo.Text = oPromotorBE.Tipo;
				this.lblUbicacion.Text = oPromotorBE.UbicacionGeo;

				if(!oPromotorBE.NroRUC.IsNull)
				{
					txtIdentificacionPersonal.Text = oPromotorBE.NroRUC.ToString().ToUpper();
				}
				if(!oPromotorBE.Direccion.IsNull)
				{
					this.txtDireccion.Text = oPromotorBE.Direccion.ToString().ToUpper();
				}

				if(!oPromotorBE.CorreoElectronico.IsNull)
				{
					this.txtCorreoElectronico.Text = oPromotorBE.CorreoElectronico.ToString();
				}
				if(!oPromotorBE.Telefono.IsNull)
				{
					this.txtTelefono.Text = oPromotorBE.Telefono.ToString().ToUpper();
				}
				if(!oPromotorBE.Celular.IsNull)
				{
					this.txtCelular.Text = oPromotorBE.Celular.ToString().ToUpper();
				}
				if(!oPromotorBE.Fax.IsNull)
				{
					this.txtNroFax.Text = oPromotorBE.Fax.ToString().ToUpper();
				}
				if(!oPromotorBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oPromotorBE.Observaciones.ToString().ToUpper();
				}

			}
		 }

		public void CargarModoConsulta()
		{
			this.txtProveedor.ReadOnly=true;
			this.ibtnAceptar.Visible = false;
			this.ibtnCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOCONSULTA;
			this.CargarModoModificar();
			Helper.BloquearControles(this);
		}

		public bool ValidarCampos()
		{
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			/*
			if(this.rblTipoClienteLegal.SelectedIndex < 0)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOTIPOPROMOTORLEGAL));
				return false;
			}
		
			if(this.txtNombre.Text.Trim()== String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDONOMBRE));
				return false;
			}
*/
			//Si es un cliente natural
/*			if(rblTipoClienteLegal.SelectedValue == ClienteNatural.ToString())
			{
//				if(txtApellidoPaterno.Text.Trim() == String.Empty)
//				{
//					ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOAPELLIDOPATERNO));
//					return false;
//				}
//
//				if(txtApellidoMaterno.Text.Trim() == String.Empty)
//				{
//					ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOAPELLIDOMATERNO));
//					return false;
//				}
			}

			if(this.txtIdentificacionPersonal.Text.Trim()== String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDODOCIDENTIDADRUC));
				return false;
			}*/
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return false;
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



		private void DesabilitarControlesClienteJuridico()
		{
		//	this.lblNombre.Visible = false;
//			this.lblApellidoPaterno.Visible = false;
//			this.txtApellidoPaterno.Visible = false;
//			this.lblApellidoMaterno.Visible = false;
//			this.txtApellidoMaterno.Visible = false;
//			this.CellApellidoPaternolbl.Visible = false;
//			this.CellApellidoPaterno.Visible = false;
//			this.CellApellidoMaternolbl.Visible = false;
//			this.CellApellidoMaterno.Visible = false;

		}

		private void DesabilitarControlesClienteNatural()
		{
			this.lblRazonSocial.Visible = false;
		}

		private void HabilitarControlesClienteNatural()
		{
			//this.lblNombre.Visible = true;
//			this.lblApellidoPaterno.Visible = true;
//			this.txtApellidoPaterno.Visible = true;
//			this.lblApellidoMaterno.Visible = true;
//			this.txtApellidoMaterno.Visible = true;
		}


		private void DesabilitarCeldas()
		{
//			this.CellApellidoPaternolbl.Visible = false;
//			this.CellApellidoPaterno.Visible = false;
//			this.CellApellidoMaternolbl.Visible = false;
//			this.CellApellidoMaterno.Visible = false;
		}

		private void HabilitarCeldas()
		{
//			this.CellApellidoPaternolbl.Visible = true;
//			this.CellApellidoPaterno.Visible = true;
//			this.CellApellidoMaternolbl.Visible = true;
//			this.CellApellidoMaterno.Visible = true;
		}
	}
}

