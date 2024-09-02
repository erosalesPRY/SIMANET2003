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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.EntidadesNegocio.GestionComercial;
using SIMA.EntidadesNegocio.General;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for DetallePasajesAereos.
	/// </summary>
	public class DetallePasajesAereos: System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblAerolinea;
		protected System.Web.UI.WebControls.DropDownList ddlbAerolinea;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvAerolinea;
		protected System.Web.UI.WebControls.Label lblOrigen;
		protected System.Web.UI.WebControls.TextBox txtOrigen;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvOrigen;
		protected System.Web.UI.WebControls.Label lblDestino;
		protected System.Web.UI.WebControls.TextBox txtDestino;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDestino;
		protected System.Web.UI.WebControls.Label lblFechaVuelo;
		protected eWorld.UI.CalendarPopup calFechaVuelo;
		protected System.Web.UI.WebControls.Label lblMonto;
		protected eWorld.UI.NumericBox nbMonto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMonto;
		protected System.Web.UI.WebControls.Label lblMoneda;
		protected System.Web.UI.WebControls.DropDownList ddlbMoneda;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMoneda;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		#endregion
		
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO PASAJE AEREO";
		const string TITULOMODOMODIFICAR = "PASAJE AEREO";

		//Key Session y QueryString
		const string KEYQID = "Id";
	
		//Paginas

		//Otros
		const int POSICIONORIGEN = 0;
		const int POSICIONDESTINO = 1;
		
		#endregion Constantes
		
		#region Variables
		
		ListItem  lItem ;
		
		#endregion
		
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
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetallePasajesAereos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePasajesAereos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePasajesAereos.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			calFechaVuelo.SelectedDate = Helper.ObtenerFechaInicioBusqueda();
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarAerolineas();
			this.llenarMoneda();
			this.ddlbAerolinea.Items.Insert(0,lItem);
			this.ddlbMoneda.Items.Insert(0,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePasajesAereos.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.rfvAerolinea.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPASAJEAEREOCAMPOREQUERIDOAEROLINEA);
			this.rfvAerolinea.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPASAJEAEREOCAMPOREQUERIDOAEROLINEA);
			this.rfvAerolinea.InitialValue = Constantes.VALORSELECCIONAR;

			this.rfvOrigen.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPASAJEAEREOCAMPOREQUERIDOORIGEN);
			this.rfvOrigen.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPASAJEAEREOCAMPOREQUERIDOORIGEN);

			this.rfvDestino.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPASAJEAEREOCAMPOREQUERIDODESTINO);
			this.rfvDestino.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPASAJEAEREOCAMPOREQUERIDODESTINO);

			this.rfvMonto.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPASAJEAEREOCAMPOREQUERIDOMONTO);
			this.rfvMonto.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPASAJEAEREOCAMPOREQUERIDOMONTO);

			this.rfvMoneda.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPASAJEAEREOCAMPOREQUERIDOMONEDA);
			this.rfvMoneda.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPASAJEAEREOCAMPOREQUERIDOMONEDA);
			this.rfvMoneda.InitialValue = Constantes.VALORSELECCIONAR;
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePasajesAereos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePasajesAereos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePasajesAereos.Exportar implementation
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
			// TODO:  Add DetallePasajesAereos.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			PASAJEAEREOBE oPASAJEAEREOBE = new PASAJEAEREOBE();
			oPASAJEAEREOBE.IDAEROLINEA = Convert.ToInt32(this.ddlbAerolinea.SelectedValue);
			oPASAJEAEREOBE.RUTA = this.txtOrigen.Text+Constantes.SEPARADORFECHA+this.txtDestino.Text;
			oPASAJEAEREOBE.FECHAVUELO = this.calFechaVuelo.SelectedDate;
			oPASAJEAEREOBE.MONTO = Convert.ToDouble(this.nbMonto.Text);
			oPASAJEAEREOBE.IDMONEDA = Convert.ToInt32(this.ddlbMoneda.SelectedValue);
			oPASAJEAEREOBE.IDTABLAMONEDA = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oPASAJEAEREOBE.IDUSUARIOREGISTRO = CNetAccessControl.GetIdUser();
			oPASAJEAEREOBE.IDTABLAESTADO = Convert.ToInt32(Enumerados.TablasTabla.EstadosPasajeAereo);
			oPASAJEAEREOBE.IDESTADO = Convert.ToInt32(Enumerados.EstadosPasajeAereo.Activo);

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oPASAJEAEREOBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró el Pasaje Aereo Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROPASAJEAEREO));
			}
		}

		public void Modificar()
		{
			PASAJEAEREOBE oPASAJEAEREOBE = new PASAJEAEREOBE();
			oPASAJEAEREOBE.IDPASAJEAEREO = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oPASAJEAEREOBE.IDAEROLINEA = Convert.ToInt32(this.ddlbAerolinea.SelectedValue);
			oPASAJEAEREOBE.RUTA = this.txtOrigen.Text+Constantes.SEPARADORFECHA+this.txtDestino.Text;
			oPASAJEAEREOBE.FECHAVUELO = this.calFechaVuelo.SelectedDate;
			oPASAJEAEREOBE.MONTO = Convert.ToDouble(this.nbMonto.Text);
			oPASAJEAEREOBE.IDMONEDA = Convert.ToInt32(this.ddlbMoneda.SelectedValue);
			oPASAJEAEREOBE.IDTABLAMONEDA = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oPASAJEAEREOBE.IDUSUARIOACTUALIZACION = CNetAccessControl.GetIdUser();
			oPASAJEAEREOBE.IDTABLAESTADO = Convert.ToInt32(Enumerados.TablasTabla.EstadosPasajeAereo);
			oPASAJEAEREOBE.IDESTADO = Convert.ToInt32(Enumerados.EstadosPasajeAereo.Modificado);

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oPASAJEAEREOBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó el Pasaje Aereo Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROPASAJEAEREO));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePasajesAereos.Eliminar implementation
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
			PASAJEAEREOBE oPASAJEAEREOBE = (PASAJEAEREOBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.PasajeAereoNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Pasaje Aereo Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oPASAJEAEREOBE!=null)
			{
				this.ddlbAerolinea.Items.FindByValue(oPASAJEAEREOBE.IDAEROLINEA.ToString()).Selected = true;
				string [] ruta = oPASAJEAEREOBE.RUTA.Split(Convert.ToChar(Constantes.SEPARADORFECHA));
				this.txtOrigen.Text = ruta[POSICIONORIGEN];
				this.txtDestino.Text = ruta[POSICIONDESTINO];
				this.calFechaVuelo.SelectedDate = oPASAJEAEREOBE.FECHAVUELO;
				this.nbMonto.Text = oPASAJEAEREOBE.MONTO.ToString(Constantes.FORMATODECIMAL4);
				this.ddlbMoneda.Items.FindByValue(oPASAJEAEREOBE.IDMONEDA.ToString()).Selected = true;
			}
		}

		public void CargarModoConsulta()
		{
			
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
			if(this.ddlbAerolinea.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPASAJEAEREOCAMPOREQUERIDOAEROLINEA));
				return false;
			}
			if(this.txtOrigen.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPASAJEAEREOCAMPOREQUERIDOORIGEN));
				return false;
			}
			if(this.txtDestino.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPASAJEAEREOCAMPOREQUERIDODESTINO));
				return false;
			}
			if(this.nbMonto.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPASAJEAEREOCAMPOREQUERIDOMONTO));
				return false;
			}
			if(this.ddlbMoneda.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPASAJEAEREOCAMPOREQUERIDOMONEDA));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(this.nbMonto.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEPASAJEAEREODATOSINCORRECTOSMONTO));
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

		/// <summary>
		/// Llena el combo de Aerolineas
		/// </summary>
		private void llenarAerolineas()
		{
			CAerolinea oCAerolinea =  new CAerolinea();
			ddlbAerolinea.DataSource = oCAerolinea.ListarTodosCombo();
			ddlbAerolinea.DataValueField=Enumerados.ColumnasAerolineas.IdAerolinea.ToString();
			ddlbAerolinea.DataTextField=Enumerados.ColumnasAerolineas.Nombre.ToString();
			ddlbAerolinea.DataBind();
		}

		private void llenarMoneda()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbMoneda.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.Moneda));
			ddlbMoneda.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbMoneda.DataTextField =Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbMoneda.DataBind();
		}
	}
}