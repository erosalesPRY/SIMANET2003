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
using MetaBuilders.WebControls;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionComercial;
using SIMA.EntidadesNegocio.GestionComercial;
	
namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for DetalleGastosRepresentacion.
	/// </summary>
	public class DetalleGastosRepresentacion: System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.DomValidators.CustomDomValidator ctvFechaEntrega;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblOnomastico;
		protected eWorld.UI.CalendarPopup calFechaEntrega;
		protected System.Web.UI.WebControls.Label lblNombres;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarPromotor;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombres;
		protected System.Web.UI.WebControls.Label lblPresente;
		protected System.Web.UI.WebControls.DropDownList ddlbPresente;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPresente;
		protected eWorld.UI.NumericBox nbCantidad;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCantidad;
		protected System.Web.UI.WebControls.Label lblTipoDocumento;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoDocumento;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipoDocumento;
		protected System.Web.UI.WebControls.Label lblFechaDocumento;
		protected eWorld.UI.CalendarPopup calFechaDocumento;
		protected System.Web.UI.WebControls.Label lblNroDocumento;
		protected System.Web.UI.WebControls.TextBox txtDocumento;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDocumento;
		protected System.Web.UI.WebControls.Label lblMotivo;
		protected System.Web.UI.WebControls.TextBox txtMotivo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMotivo;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblCantidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCodigo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.TextBox txtPromotor;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		#endregion 

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO GASTO DE REPRESENTACION";
		const string TITULOMODOMODIFICAR = "GASTO DE REPRESENTACION";

		//Key Session y QueryString
		const string KEYQID = "Id";
	
		//Paginas
		const string URLBUSQUEDAENTIDAD = "../../Legal/BusquedaEntidad.aspx?";
		#endregion Constantes

		#region Variables
		
		#endregion Variables

		private void llenarPresente()
		{
			CPresentes oCPresente = new CPresentes();
			ddlbPresente.DataSource = oCPresente.ListarTodosCombo();
			ddlbPresente.DataValueField=Enumerados.ColumnasPresentes.IdPresenteRelacionPublica.ToString();
			ddlbPresente.DataTextField=Enumerados.ColumnasPresentes.NombreArticulo.ToString();
			ddlbPresente.DataBind();
		}

		private void llenarTipoDocumento()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbTipoDocumento.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.SecretariaTipoDocumento));
			ddlbTipoDocumento.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoDocumento.DataTextField =Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipoDocumento.DataBind();
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					this.LlenarJScript();

					Helper.ReiniciarSession();
					
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se ingresó al detalle de Gasto de Representacion.",Enumerados.NivelesErrorLog.I.ToString()));

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
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleGastosRepresentacion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleGastosRepresentacion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleGastosRepresentacion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			calFechaEntrega.SelectedDate = Helper.ObtenerFechaInicioBusqueda();
			ListItem lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarPresente();
			this.llenarTipoDocumento();
			this.ddlbPresente.Items.Insert(0,lItem);
			this.ddlbTipoDocumento.Items.Insert(0,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleGastosRepresentacion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.rfvNombres.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDONOMBRES);
			this.rfvNombres.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDONOMBRES);

			this.rfvPresente.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDOPRESENTE);
			this.rfvPresente.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDOPRESENTE);
			this.rfvPresente.InitialValue = Utilitario.Constantes.VALORSELECCIONAR;

			this.rfvCantidad.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDOCANTIDAD);
			this.rfvCantidad.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDOCANTIDAD);

			this.rfvTipoDocumento.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDOTIPODOCUMENTO);
			this.rfvTipoDocumento.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDOTIPODOCUMENTO);
			this.rfvTipoDocumento.InitialValue = Utilitario.Constantes.VALORSELECCIONAR;

			this.rfvDocumento.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDODOCUMENTO);
			this.rfvDocumento.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDODOCUMENTO);

			this.rfvMotivo.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDOMOTIVO);
			this.rfvMotivo.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDOMOTIVO);

			this.ibtnBuscarPromotor.Attributes.Add("onclick",Helper.PopupBusqueda(URLBUSQUEDAENTIDAD + Utilitario.Constantes.KEYTIPOBUSQUEDAENTIDAD +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.TipoBusquedaEntidad.P,750,500,true));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleGastosRepresentacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleGastosRepresentacion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleGastosRepresentacion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleGastosRepresentacion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleGastosRepresentacion.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			GastoRepresentacionBE oGastoRepresentacionBE = new GastoRepresentacionBE();
			oGastoRepresentacionBE.CantidadAtendida = Convert.ToInt32(this.nbCantidad.Text);
			oGastoRepresentacionBE.FechaGasto = Convert.ToDateTime(this.calFechaEntrega.SelectedDate.ToShortDateString());
			oGastoRepresentacionBE.FechaDocumento = Convert.ToDateTime(this.calFechaDocumento.SelectedDate.ToShortDateString());
			
			CMantenimientos	oCMantenimientosObtner = new CMantenimientos();
			PresenteRelacionPublicaBE oPresenteRelacionPublicaBE = (PresenteRelacionPublicaBE)oCMantenimientosObtner.ListarDetalle(Convert.ToInt32(this.ddlbPresente.SelectedValue),Enumerados.ClasesNTAD.PresenteRelacionPublicaNTAD.ToString());

			oGastoRepresentacionBE.Monto = oPresenteRelacionPublicaBE.Costo * oGastoRepresentacionBE.CantidadAtendida;
			oGastoRepresentacionBE.MotivoPresente = this.txtMotivo.Text;
			oGastoRepresentacionBE.IdTablaDocumento = Convert.ToInt32(Enumerados.TablasTabla.SecretariaTipoDocumento);
			oGastoRepresentacionBE.IdDocumento = Convert.ToInt32(this.ddlbTipoDocumento.SelectedValue);
			oGastoRepresentacionBE.IdTablaMoneda = oPresenteRelacionPublicaBE.IdTablaMoneda;
			oGastoRepresentacionBE.IdMoneda = oPresenteRelacionPublicaBE.IdMoneda;
			oGastoRepresentacionBE.NroDocumento = this.txtDocumento.Text;
			oGastoRepresentacionBE.IdPresenteRelacionPublica = oPresenteRelacionPublicaBE.IdPresenteRelacionPublica;
			oGastoRepresentacionBE.IdPromotor = Convert.ToInt32(hIdCodigo.Value);
			oGastoRepresentacionBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oGastoRepresentacionBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosGastoRepresentacion);
			oGastoRepresentacionBE.IdEstado = Convert.ToInt32(Enumerados.EstadosGastoRepresentacion.Activo);
			if(this.txtObservaciones.Text.Trim()!=String.Empty)
			{
				oGastoRepresentacionBE.Observaciones = this.txtObservaciones.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oGastoRepresentacionBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró el Gasto de Representacion Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROGASTOREPRESENTACION));
			}
		}

		public void Modificar()
		{
			GastoRepresentacionBE oGastoRepresentacionBE = new GastoRepresentacionBE();
			oGastoRepresentacionBE.IdGastoRepresentacion = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oGastoRepresentacionBE.CantidadAtendida = Convert.ToInt32(this.nbCantidad.Text);
			oGastoRepresentacionBE.FechaGasto = Convert.ToDateTime(this.calFechaEntrega.SelectedDate.ToShortDateString());
			oGastoRepresentacionBE.FechaDocumento = Convert.ToDateTime(this.calFechaDocumento.SelectedDate.ToShortDateString());
			
			CMantenimientos	oCMantenimientosObtner = new CMantenimientos();
			PresenteRelacionPublicaBE oPresenteRelacionPublicaBE = (PresenteRelacionPublicaBE)oCMantenimientosObtner.ListarDetalle(Convert.ToInt32(this.ddlbPresente.SelectedValue),Enumerados.ClasesNTAD.PresenteRelacionPublicaNTAD.ToString());

			oGastoRepresentacionBE.Monto = oPresenteRelacionPublicaBE.Costo * oGastoRepresentacionBE.CantidadAtendida;
			oGastoRepresentacionBE.MotivoPresente = this.txtMotivo.Text;
			oGastoRepresentacionBE.IdTablaDocumento = Convert.ToInt32(Enumerados.TablasTabla.SecretariaTipoDocumento);
			oGastoRepresentacionBE.IdDocumento = Convert.ToInt32(this.ddlbTipoDocumento.SelectedValue);
			oGastoRepresentacionBE.IdTablaMoneda = oPresenteRelacionPublicaBE.IdTablaMoneda;
			oGastoRepresentacionBE.IdMoneda = oPresenteRelacionPublicaBE.IdMoneda;
			oGastoRepresentacionBE.NroDocumento = this.txtDocumento.Text;
			oGastoRepresentacionBE.IdPresenteRelacionPublica = oPresenteRelacionPublicaBE.IdPresenteRelacionPublica;
			oGastoRepresentacionBE.IdPromotor = Convert.ToInt32(hIdCodigo.Value);
			oGastoRepresentacionBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oGastoRepresentacionBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosGastoRepresentacion);
			oGastoRepresentacionBE.IdEstado = Convert.ToInt32(Enumerados.EstadosGastoRepresentacion.Modificado);
			if(this.txtObservaciones.Text.Trim()!=String.Empty)
			{
				oGastoRepresentacionBE.Observaciones = this.txtObservaciones.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oGastoRepresentacionBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó el Gasto de Representación Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONGASTOREPRESENTACION));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleGastosRepresentacion.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]);

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
			GastoRepresentacionBE oGastoRepresentacionBE = (GastoRepresentacionBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.GastoRepresentacionNTAD.ToString());

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Gasto de Representacion Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oGastoRepresentacionBE!=null)
			{
				this.calFechaEntrega.SelectedDate = oGastoRepresentacionBE.FechaGasto;
				this.hIdCodigo.Value = oGastoRepresentacionBE.IdPromotor.ToString();

				CMantenimientos	oCMantenimientosObtner = new CMantenimientos();
				PromotorBE oPromotorBE = (PromotorBE)oCMantenimientosObtner.ListarDetalle(Convert.ToInt32(this.hIdCodigo.Value),Enumerados.ClasesNTAD.PromotorNTAD.ToString());
				if (oPromotorBE != null)
					this.txtPromotor.Text = oPromotorBE.RazonSocial.Value;
				
				this.ddlbPresente.Items.FindByValue(oGastoRepresentacionBE.IdPresenteRelacionPublica.ToString()).Selected = true;
				this.nbCantidad.Text = oGastoRepresentacionBE.CantidadAtendida.ToString();
				this.ddlbTipoDocumento.Items.FindByValue(oGastoRepresentacionBE.IdDocumento.ToString()).Selected = true;
				this.calFechaDocumento.SelectedDate = oGastoRepresentacionBE.FechaDocumento;
				this.txtDocumento.Text = oGastoRepresentacionBE.NroDocumento;
				this.txtMotivo.Text = oGastoRepresentacionBE.MotivoPresente;
				if(!oGastoRepresentacionBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oGastoRepresentacionBE.Observaciones.ToString();
				}
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleGastosRepresentacion.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			if(this.ValidarCamposRequeridos())
			{
				if(this.ValidarExpresionesRegulares())
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public bool ValidarCamposRequeridos()
		{
			if(txtPromotor.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDONOMBRES));
				return false;
			}
			if(ddlbPresente.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDOPRESENTE));
				return false;
			}
			if(nbCantidad.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDOCANTIDAD));
				return false;		
			}
			if(ddlbTipoDocumento.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDOTIPODOCUMENTO));
				return false;
			}
			if(txtDocumento.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDODOCUMENTO));
				return false;
			}
			if(txtMotivo.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONCAMPOREQUERIDOMOTIVO));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(nbCantidad.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEGASTOREPRESENTACIONDATOSINCORRECTOSNUMEROSCANTIDAD));
				return false;
			}
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
	}
}