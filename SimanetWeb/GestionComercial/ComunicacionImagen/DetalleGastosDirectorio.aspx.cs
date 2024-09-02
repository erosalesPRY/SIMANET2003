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
using SIMA.Controladoras.Secretaria;
using SIMA.Controladoras.GestionComercial;
using SIMA.EntidadesNegocio.GestionComercial;


namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for DetalleGastosDirectorio.
	/// </summary>
	public class DetalleGastosDirectorio: System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Controles 
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.DropDownList ddlbMoneda;
		protected System.Web.UI.WebControls.Label lblMoneda;
		protected eWorld.UI.NumericBox nMonto;
		protected System.Web.UI.WebControls.Label lblMonto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtLugar;
		protected System.Web.UI.WebControls.Label lblLugar;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarCentroCosto;
		protected System.Web.UI.WebControls.TextBox txtCentroCosto;
		protected System.Web.UI.WebControls.Label lblCentroCosto;
		protected System.Web.UI.WebControls.TextBox txtNroDocumento;
		protected System.Web.UI.WebControls.Label lblDocumento;
		protected eWorld.UI.CalendarPopup calFechaDocumento;
		protected System.Web.UI.WebControls.Label lblFechaDocumento;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoDocumento;
		protected System.Web.UI.WebControls.Label lblTipoDocumento;
		protected eWorld.UI.CalendarPopup calFecha;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCentroCosto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdGrupoCentroCosto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMonto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMoneda;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvLugar;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCentroCosto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroDocumento;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipoDocumento;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		
		#region Variables
		ListItem  lItem ;
		#endregion Variables

		#region Constantes

		//Ordenamiento

		//Nombres de Controles
		
		//Paginas
		const string URLBUSQUEDACENTROCOSTO = "../BusquedaCentroCosto.aspx";
				
		//Key Session y QueryString
		const string KEYQID = "Id";

		//JScript

		//Otros
		const string TITULOMODONUEVO = "NUEVO GASTO DIRECTORIO";
		const string TITULOMODOMODIFICAR = "GASTO DIRECTORIO";		

		#endregion constantes

		private void llenarMonedas()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();
			ddlbMoneda.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.Moneda));
			ddlbMoneda.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbMoneda.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbMoneda.DataBind();			
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
			// TODO:  Add DetalleGastosDirectorio.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleGastosDirectorio.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleGastosDirectorio.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarMonedas();
			this.llenarTipoDocumento();
			this.ddlbMoneda.Items.Insert(0,lItem);
			this.ddlbTipoDocumento.Items.Insert(0,lItem);
		}
		public void LlenarDatos()
		{
			// TODO:  Add DetalleGastosDirectorio.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnBuscarCentroCosto.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDACENTROCOSTO,750,500,true));

			rfvTipoDocumento.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDOTIPODOCUMENTO);
			rfvTipoDocumento.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDOTIPODOCUMENTO);
			rfvTipoDocumento.InitialValue = Constantes.VALORSELECCIONAR;

			rfvNroDocumento.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDONRODOCUMENTO);
			rfvNroDocumento.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDONRODOCUMENTO);

			rfvCentroCosto.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDOCENTROCOSTO);
			rfvCentroCosto.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDOCENTROCOSTO);

			rfvLugar.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDOLUGAR);
			rfvLugar.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDOLUGAR);

			rfvDescripcion.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDODESCRIPCION);
			rfvDescripcion.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDODESCRIPCION);

			rfvMonto.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDOMONTO);
			rfvMonto.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDOMONTO);

			rfvMoneda.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDOMONEDA);
			rfvMoneda.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDOMONEDA);
			rfvMoneda.InitialValue = Constantes.VALORSELECCIONAR;
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleGastosDirectorio.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleGastosDirectorio.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleGastosDirectorio.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleGastosDirectorio.ConfigurarAccesoControles implementation
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
			// TODO:  Add DetalleGastosDirectorio.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnBuscarCentroCosto_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.PopupBusqueda(URLBUSQUEDACENTROCOSTO,700,700,true);
		}

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			GastoDirectorioBE oGastoDirectorioBE = new GastoDirectorioBE();
			oGastoDirectorioBE.FechaDocumento = this.calFechaDocumento.SelectedDate;
			oGastoDirectorioBE.FechaGasto = this.calFecha.SelectedDate;
			oGastoDirectorioBE.Lugar = this.txtLugar.Text;
			oGastoDirectorioBE.Monto = Convert.ToDouble(this.nMonto.Text);
			oGastoDirectorioBE.IdTablaDocumento = Convert.ToInt32(Enumerados.TablasTabla.SecretariaTipoDocumento);
			oGastoDirectorioBE.IdDocumento = Convert.ToInt32(ddlbTipoDocumento.SelectedValue);
			oGastoDirectorioBE.IdTablaMoneda = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oGastoDirectorioBE.IdMoneda = Convert.ToInt32(ddlbMoneda.SelectedValue);
			oGastoDirectorioBE.NroDocumento = this.txtNroDocumento.Text;
			oGastoDirectorioBE.IdGrupoCc = Convert.ToInt32(this.hIdGrupoCentroCosto.Value);
			oGastoDirectorioBE.IdCentroCosto = Convert.ToInt32(this.hIdCentroCosto.Value);
			oGastoDirectorioBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oGastoDirectorioBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosGastoDirectorio);
			oGastoDirectorioBE.IdEstado = Convert.ToInt32(Enumerados.EstadosGastosDirectorio.Activo);
			if(txtDescripcion.Text.Trim()!=String.Empty)
			{
				oGastoDirectorioBE.Descripcion = txtDescripcion.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oGastoDirectorioBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró el Gasto del Directorio Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROGASTODIRECTORIO));
			}
		}

		public void Modificar()
		{
			GastoDirectorioBE oGastoDirectorioBE = new GastoDirectorioBE();
			oGastoDirectorioBE.IdGastoDirectorio = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oGastoDirectorioBE.FechaDocumento = this.calFechaDocumento.SelectedDate;
			oGastoDirectorioBE.FechaGasto = this.calFecha.SelectedDate;
			oGastoDirectorioBE.Lugar = this.txtLugar.Text;
			oGastoDirectorioBE.Monto = Convert.ToDouble(this.nMonto.Text);
			oGastoDirectorioBE.IdTablaDocumento = Convert.ToInt32(Enumerados.TablasTabla.SecretariaTipoDocumento);
			oGastoDirectorioBE.IdDocumento = Convert.ToInt32(ddlbTipoDocumento.SelectedValue);
			oGastoDirectorioBE.IdTablaMoneda = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oGastoDirectorioBE.IdMoneda = Convert.ToInt32(ddlbMoneda.SelectedValue);
			oGastoDirectorioBE.NroDocumento = this.txtNroDocumento.Text;
			oGastoDirectorioBE.IdGrupoCc = Convert.ToInt32(this.hIdGrupoCentroCosto.Value);
			oGastoDirectorioBE.IdCentroCosto = Convert.ToInt32(this.hIdCentroCosto.Value);
			oGastoDirectorioBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oGastoDirectorioBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosGastoDirectorio);
			oGastoDirectorioBE.IdEstado = Convert.ToInt32(Enumerados.EstadosGastosDirectorio.Modificado);
			if(txtDescripcion.Text.Trim()!=String.Empty)
			{
				oGastoDirectorioBE.Descripcion = txtDescripcion.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oGastoDirectorioBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó el Gasto del Directorio Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROGASTODIRECTORIO));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleGastosDirectorio.Eliminar implementation
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
			GastoDirectorioBE oGastoDirectorioBE = (GastoDirectorioBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.GastoDirectorioNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Gasto del Directorio Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oGastoDirectorioBE!=null)
			{
				this.calFecha.SelectedDate = oGastoDirectorioBE.FechaGasto;
				this.ddlbTipoDocumento.Items.FindByValue(oGastoDirectorioBE.IdDocumento.ToString()).Selected = true;
				this.calFechaDocumento.SelectedDate = oGastoDirectorioBE.FechaDocumento;
				this.txtNroDocumento.Text = oGastoDirectorioBE.NroDocumento;
				this.hIdGrupoCentroCosto.Value = oGastoDirectorioBE.IdGrupoCc.ToString();
				this.hIdCentroCosto.Value = oGastoDirectorioBE.IdCentroCosto.ToString();

				CMantenimientos	oCMantenimientosObtner = new CMantenimientos();
				CCentroCosto oCCentroCosto = new CCentroCosto();
				string Nombre = oCCentroCosto.ObtenerNombreCentroCosto(Convert.ToInt32(this.hIdGrupoCentroCosto.Value),Convert.ToInt32(this.hIdCentroCosto.Value));
				this.txtCentroCosto.Text = Nombre;

				if(!oGastoDirectorioBE.Lugar.IsNull)
				{
					this.txtLugar.Text = oGastoDirectorioBE.Lugar.ToString();
				}
				if(!oGastoDirectorioBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text = oGastoDirectorioBE.Descripcion.ToString();
				}
				
				this.nMonto.Text = oGastoDirectorioBE.Monto.ToString();

				ddlbMoneda.Items.FindByValue(oGastoDirectorioBE.IdMoneda.ToString()).Selected = true;
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleGastosDirectorio.CargarModoConsulta implementation
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
			if(this.ddlbTipoDocumento.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDOTIPODOCUMENTO));
				return false;
			}
			if(this.txtNroDocumento.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDONRODOCUMENTO));
				return false;
			}
			if(this.txtCentroCosto.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDOCENTROCOSTO));
				return false;
			}
			if(this.txtLugar.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDOLUGAR));
				return false;
			}
			if(this.txtDescripcion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDODESCRIPCION));
				return false;
			}
			if(this.nMonto.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDOMONTO));
				return false;
			}
			if(this.ddlbMoneda.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIOCAMPOREQUERIDOMONEDA));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(this.nMonto.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEGASTODIRECTORIODATOSINCORRECTOSMONTO));
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

