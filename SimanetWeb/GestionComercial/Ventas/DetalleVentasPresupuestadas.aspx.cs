using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
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
using eWorld.UI;
using System.Reflection;

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for DetalleVentasPresupuestadas.
	/// </summary>
	public class DetalleVentasPresupuestadas: System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles
		
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblProyecto;
		protected System.Web.UI.WebControls.TextBox txtProyecto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvProyecto;
		protected System.Web.UI.WebControls.RadioButtonList rblTipoPromotor;
		protected System.Web.UI.WebControls.Label lblCliente;
		protected System.Web.UI.WebControls.TextBox txtCliente;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarCliente;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCliente;
		protected System.Web.UI.WebControls.Label lblSector;
		protected System.Web.UI.WebControls.DropDownList ddlbSector;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCentroOperativo;
		protected System.Web.UI.WebControls.Label lblLineaNegocio;
		protected System.Web.UI.WebControls.DropDownList ddlbLineaNegocio;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvLineaNegocio;
		protected System.Web.UI.WebControls.Label lblMonto;
		protected eWorld.UI.NumericBox nMonto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMonto;
		protected System.Web.UI.WebControls.Label lblMoneda;
		protected System.Web.UI.WebControls.DropDownList ddlbMoneda;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMoneda;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected eWorld.UI.CalendarPopup calFecha;
		protected System.Web.UI.WebControls.Label lblVersion;
		protected System.Web.UI.WebControls.DropDownList ddlbVersion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvVersion;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCodigo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbSector;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbLineaNegocio;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbMoneda;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbVersion;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellibtnCancelar;

		#endregion

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA VENTA PRESUPUESTADA";
		const string TITULOMODOMODIFICAR = "VENTA PRESUPUESTADA";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDPRESENTE = "IdPresente";
		const string KEYQCANTIDAD = "Cantidad";
		const string KEYSINDICEMES = "indiceMes";
		const string KEYQNOMBREMES = "NombreMes";
		const string KEYQNOMBRE = "Nombre";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string CENTROOPERATIVO = "CO";

	
		//Paginas
		const string URLBUSQUEDAENTIDAD = "../../Legal/BusquedaEntidad.aspx?";
		
		const int LineaNegocioReparacionesIndustriales = 3;
		const int LineaNegocioArmasElectronica = 1;

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
			this.rblTipoPromotor.SelectedIndexChanged += new System.EventHandler(this.rblTipoPromotor_SelectedIndexChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleVentasPresupuestadas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleVentasPresupuestadas.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleVentasPresupuestadas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarCentrosOperativos();
			this.llenarLineaNegocio();
			this.llenarMoneda();
			this.llenarSector();
			this.llenarVersiones();
			this.ddlbLineaNegocio.Items.Insert(0,lItem);
			this.ddlbCentroOperativo.Items.Insert(0,lItem);
			this.ddlbMoneda.Items.Insert(0,lItem);
			this.ddlbVersion.Items.Insert(0,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleVentasPresupuestadas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnBuscarCliente.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAENTIDAD + Utilitario.Constantes.KEYTIPOBUSQUEDAENTIDAD +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.TipoBusquedaEntidad.C,700,700,true));

			this.rfvProyecto.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOPROYECTO);
			this.rfvProyecto.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOPROYECTO);

			this.rfvCliente.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOCLIENTE);
			this.rfvCliente.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOCLIENTE);

			this.rfvCentroOperativo.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOCENTROPERATIVO);
			this.rfvCentroOperativo.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOCENTROPERATIVO);
			this.rfvCentroOperativo.InitialValue = Constantes.VALORSELECCIONAR;

			this.rfvLineaNegocio.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOLINEANEGOCIO);
			this.rfvLineaNegocio.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOLINEANEGOCIO);
			this.rfvLineaNegocio.InitialValue = Constantes.VALORSELECCIONAR;

			this.rfvMonto.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOMONTO);
			this.rfvMonto.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOMONTO);

			this.rfvMoneda.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOMONEDA);
			this.rfvMoneda.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOMONEDA);
			this.rfvMoneda.InitialValue = Constantes.VALORSELECCIONAR;

			this.rfvVersion.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOVERSION);
			this.rfvVersion.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOVERSION);
			this.rfvVersion.InitialValue = Constantes.VALORSELECCIONAR;
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleVentasPresupuestadas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleVentasPresupuestadas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleVentasPresupuestadas.Exportar implementation
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
			// TODO:  Add DetalleVentasPresupuestadas.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			VENTAPRESUPUESTADABE oVENTAPRESUPUESTADABE = new VENTAPRESUPUESTADABE();

			if(this.rblTipoPromotor.SelectedIndex == 0)
			{
				oVENTAPRESUPUESTADABE.IDCLIENTE = Convert.ToInt32(this.hIdCodigo.Value);
			}

			else
			{
				oVENTAPRESUPUESTADABE.NOMBRECLIENTE = this.txtCliente.Text;
				oVENTAPRESUPUESTADABE.IDTABLATIPOCLIENTE = Convert.ToInt32(Enumerados.TablasTabla.TipoCliente);
				oVENTAPRESUPUESTADABE.IDTIPOCLIENTE = Convert.ToInt32(this.ddlbSector.SelectedValue);
			}

			oVENTAPRESUPUESTADABE.DESCRIPCIONPROYECTO = this.txtProyecto.Text;
			oVENTAPRESUPUESTADABE.FECHAPRESUPUESTO = NullableTypes.NullableDateTime.Parse(this.calFecha.SelectedDate.ToShortDateString());
			oVENTAPRESUPUESTADABE.MONTO = Convert.ToDouble(this.nMonto.Text);
			oVENTAPRESUPUESTADABE.IDTABLAVERSION = Convert.ToInt32(Enumerados.TablasTabla.VersionesVentasPresupuestadas);
			oVENTAPRESUPUESTADABE.IDVERSION = Convert.ToInt32(this.ddlbVersion.SelectedValue);
			oVENTAPRESUPUESTADABE.IDTABLALINEANEGOCIO = Convert.ToInt32(Enumerados.TablasTabla.LineasNegocio);
			oVENTAPRESUPUESTADABE.IDLINEANEGOCIO = Convert.ToInt32(this.ddlbLineaNegocio.SelectedValue);
			oVENTAPRESUPUESTADABE.IDTABLAMONEDA = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oVENTAPRESUPUESTADABE.IDMONEDA = Convert.ToInt32(this.ddlbMoneda.SelectedValue);
			oVENTAPRESUPUESTADABE.IDCENTROOPERATIVO = Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue);
			oVENTAPRESUPUESTADABE.IDUSUARIOREGISTRO = CNetAccessControl.GetIdUser();
			oVENTAPRESUPUESTADABE.IDTABLAESTADO = Convert.ToInt32(Enumerados.TablasTabla.EstadosVentasPresupuestadas);
			oVENTAPRESUPUESTADABE.IDESTADO = Convert.ToInt32(Enumerados.EstadosVentasPresupuestadas.Activo);
			if(txtDescripcion.Text.Trim()!=String.Empty)
			{
				oVENTAPRESUPUESTADABE.DESCRIPCION = this.txtDescripcion.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oVENTAPRESUPUESTADABE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró la Venta Presupuestada. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROVENTASPRESUPUESTADAS));
			}
		}

		public void Modificar()
		{
			VENTAPRESUPUESTADABE oVENTAPRESUPUESTADABE = new VENTAPRESUPUESTADABE();

			oVENTAPRESUPUESTADABE.IDVENTAPRESUPUESTADA = Convert.ToInt32(Page.Request.QueryString[KEYQID]);

			if(this.rblTipoPromotor.SelectedIndex == 0)
			{
				oVENTAPRESUPUESTADABE.IDCLIENTE = Convert.ToInt32(this.hIdCodigo.Value);
			}

			else
			{
				oVENTAPRESUPUESTADABE.NOMBRECLIENTE = this.txtCliente.Text;
				oVENTAPRESUPUESTADABE.IDTABLATIPOCLIENTE = Convert.ToInt32(Enumerados.TablasTabla.TipoCliente);
				oVENTAPRESUPUESTADABE.IDTIPOCLIENTE = Convert.ToInt32(this.ddlbSector.SelectedValue);
			}

			oVENTAPRESUPUESTADABE.DESCRIPCIONPROYECTO = this.txtProyecto.Text;
			oVENTAPRESUPUESTADABE.FECHAPRESUPUESTO = NullableTypes.NullableDateTime.Parse(this.calFecha.SelectedDate.ToShortDateString());
			oVENTAPRESUPUESTADABE.MONTO = Convert.ToDouble(this.nMonto.Text);
			oVENTAPRESUPUESTADABE.IDTABLAVERSION = Convert.ToInt32(Enumerados.TablasTabla.VersionesVentasPresupuestadas);
			oVENTAPRESUPUESTADABE.IDVERSION = Convert.ToInt32(this.ddlbVersion.SelectedValue);
			oVENTAPRESUPUESTADABE.IDTABLALINEANEGOCIO = Convert.ToInt32(Enumerados.TablasTabla.LineasNegocio);
			oVENTAPRESUPUESTADABE.IDLINEANEGOCIO = Convert.ToInt32(this.ddlbLineaNegocio.SelectedValue);
			oVENTAPRESUPUESTADABE.IDTABLAMONEDA = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oVENTAPRESUPUESTADABE.IDMONEDA = Convert.ToInt32(this.ddlbMoneda.SelectedValue);
			oVENTAPRESUPUESTADABE.IDCENTROOPERATIVO = Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue);
			oVENTAPRESUPUESTADABE.IDUSUARIOACTUALIZACION = CNetAccessControl.GetIdUser();
			oVENTAPRESUPUESTADABE.IDTABLAESTADO = Convert.ToInt32(Enumerados.TablasTabla.EstadosVentasPresupuestadas);
			oVENTAPRESUPUESTADABE.IDESTADO = Convert.ToInt32(Enumerados.EstadosVentasPresupuestadas.Modificado);

			if(txtDescripcion.Text.Trim()!=String.Empty)
			{
				oVENTAPRESUPUESTADABE.DESCRIPCION = this.txtDescripcion.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oVENTAPRESUPUESTADABE);
			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó la Venta Presupuestada Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROVENTASPRESUPUESTADAS));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleVentasPresupuestadas.Eliminar implementation
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
			this.LlenarCombos();
		}

		public void CargarModoModificar()
		{
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			VENTAPRESUPUESTADABE oVENTAPRESUPUESTADABE = (VENTAPRESUPUESTADABE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.VentasPresupuestadasNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle de la Venta Presupuestada Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oVENTAPRESUPUESTADABE!=null)
			{
				this.txtProyecto.Text = oVENTAPRESUPUESTADABE.DESCRIPCIONPROYECTO;

				if(!oVENTAPRESUPUESTADABE.IDCLIENTE.IsNull)
				{
					this.hIdCodigo.Value = oVENTAPRESUPUESTADABE.IDCLIENTE.Value.ToString();

					CCliente oCCliente = new CCliente();
					string NombreCliente = oCCliente.ObtenerNombreCliente(Convert.ToInt32(this.hIdCodigo.Value));
					this.txtCliente.Text = NombreCliente;

					this.lblSector.Visible = false;
					this.ddlbSector.Visible = false;
					this.txtCliente.ReadOnly = true;
					this.ibtnBuscarCliente.Visible = true;
					this.rblTipoPromotor.SelectedIndex = 0;
				}
				else
				{
					this.txtCliente.Text = oVENTAPRESUPUESTADABE.NOMBRECLIENTE.Value.ToString();
					this.ddlbSector.Items.FindByValue(oVENTAPRESUPUESTADABE.IDTIPOCLIENTE.ToString()).Selected = true;
					this.lblSector.Visible = true;
					this.ddlbSector.Visible = true;
					this.txtCliente.ReadOnly = false;
					this.ibtnBuscarCliente.Visible = false;
					this.rblTipoPromotor.SelectedIndex = 1;
				}

				this.ddlbCentroOperativo.Items.FindByValue(oVENTAPRESUPUESTADABE.IDCENTROOPERATIVO.ToString()).Selected = true;
				this.ddlbLineaNegocio.Items.FindByValue(oVENTAPRESUPUESTADABE.IDLINEANEGOCIO.ToString()).Selected = true;
				this.nMonto.Text = oVENTAPRESUPUESTADABE.MONTO.ToString();
				this.ddlbMoneda.Items.FindByValue(oVENTAPRESUPUESTADABE.IDMONEDA.ToString()).Selected = true;
				this.calFecha.SelectedDate = oVENTAPRESUPUESTADABE.FECHAPRESUPUESTO.Value;
				this.ddlbVersion.Items.FindByValue(oVENTAPRESUPUESTADABE.IDVERSION.ToString()).Selected = true;
				
				if(!oVENTAPRESUPUESTADABE.DESCRIPCION.IsNull)
				{
					this.txtDescripcion.Text = oVENTAPRESUPUESTADABE.DESCRIPCION.ToString();
				}
			}
		}

		public void CargarModoConsulta()
		{
			CellibtnCancelar.Visible = false;

			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			VENTAPRESUPUESTADABE oVENTAPRESUPUESTADABE = (VENTAPRESUPUESTADABE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.VentasPresupuestadasNTAD.ToString());
			
			//Graba en el Log la acción ejecutada

			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle de la Venta Presupuestada Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oVENTAPRESUPUESTADABE!=null)
			{
				this.txtProyecto.Text = oVENTAPRESUPUESTADABE.DESCRIPCIONPROYECTO;

				if(!oVENTAPRESUPUESTADABE.IDCLIENTE.IsNull)
				{
					this.hIdCodigo.Value = oVENTAPRESUPUESTADABE.IDCLIENTE.Value.ToString();

					CCliente oCCliente = new CCliente();
					string NombreCliente = oCCliente.ObtenerNombreCliente(Convert.ToInt32(this.hIdCodigo.Value));
					this.txtCliente.Text = NombreCliente;

					this.lblSector.Visible = false;
					this.ddlbSector.Visible = false;
					this.ibtnBuscarCliente.Visible = true;
					this.rblTipoPromotor.SelectedIndex = 0;
				}
				else
				{
					this.txtCliente.Text = oVENTAPRESUPUESTADABE.NOMBRECLIENTE.Value.ToString();
					this.ddlbSector.Items.FindByValue(oVENTAPRESUPUESTADABE.IDTIPOCLIENTE.ToString()).Selected = true;
					
					this.lblSector.Visible = true;
					this.ddlbSector.Visible = true;

					this.ibtnBuscarCliente.Visible = false;
					this.rblTipoPromotor.SelectedIndex = 1;
				}

				this.ddlbCentroOperativo.Items.FindByValue(oVENTAPRESUPUESTADABE.IDCENTROOPERATIVO.ToString()).Selected = true;
				this.ddlbLineaNegocio.Items.FindByValue(oVENTAPRESUPUESTADABE.IDLINEANEGOCIO.ToString()).Selected = true;
				
				this.nMonto.TextAlign = HorizontalAlignment.Right;
				this.nMonto.Text = oVENTAPRESUPUESTADABE.MONTO.ToString(Constantes.FORMATODECIMAL4);
				this.nMonto.Enabled = false;

				this.ddlbMoneda.Items.FindByValue(oVENTAPRESUPUESTADABE.IDMONEDA.ToString()).Selected = true;
				
				this.calFecha.SelectedDate = oVENTAPRESUPUESTADABE.FECHAPRESUPUESTO.Value;

				this.ddlbVersion.Items.FindByValue(oVENTAPRESUPUESTADABE.IDVERSION.ToString()).Selected = true;
				
				if(!oVENTAPRESUPUESTADABE.DESCRIPCION.IsNull)
				{
					this.txtDescripcion.Text = oVENTAPRESUPUESTADABE.DESCRIPCION.ToString();
					this.txtDescripcion.ReadOnly = true;
				}
			}
			Helper.BloquearControles(this);
		}

		public bool ValidarCampos()
		{
			if(this.ValidarCamposRequeridos())
			{
				if(this.ValidarExpresionesRegulares())
				{
					return this.ValidarLineaNegocio();
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
			if(this.txtProyecto.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOPROYECTO));
				return false;
			}
			if(this.txtCliente.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOCLIENTE));
				return false;
			}
			if(this.ddlbCentroOperativo.SelectedItem.Text==Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOCENTROPERATIVO));
				return false;
			}
			if(this.ddlbLineaNegocio.SelectedItem.Text==Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOLINEANEGOCIO));
				return false;
			}
			if(this.nMonto.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOMONTO));
				return false;
			}
			if(this.ddlbMoneda.SelectedItem.Text==Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOMONEDA));
				return false;
			}
			if(this.ddlbVersion.SelectedItem.Text==Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADACAMPOREQUERIDOVERSION));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(this.nMonto.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADADATOSINCORRECTOSMONTO));
				return false;
			}
			return true;
		}

		#endregion

		public bool ValidarLineaNegocio()
		{
			if(this.ddlbCentroOperativo.SelectedValue != Convert.ToInt32(Enumerados.IdCentroOperativo.SimaCallao).ToString() && this.ddlbLineaNegocio.SelectedValue == LineaNegocioArmasElectronica.ToString())
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEVENTAPRESUPUESTADADATOSINCORRECTOSLINEANEGOCIO));
				return false;
			}
			return true;
		}

		private void llenarCentrosOperativos()
		{
			CCentroOperativo oCCentroOperativo =  new CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarCentroOperativoAccesoSegunPrivilegioUsuario(CNetAccessControl.GetIdUser(), Convert.ToInt32(Enumerados.TablasTabla.EstadosVentasPresupuestadas));
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Nombre.ToString();
			ddlbCentroOperativo.DataBind();
			this.ddlbCentroOperativo.Items.RemoveAt(Constantes.POSICIONCONTADOR);
		}

		private void llenarSector()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbSector.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TipoCliente));
			ddlbSector.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSector.DataTextField =Enumerados.ColumnasTablaTablas.Var2.ToString();
			ddlbSector.DataBind();
			int [] remover = {5,4,3,2};
			foreach(int a in remover)
			{
				this.ddlbSector.Items.RemoveAt(a);
			}
		}

		private void llenarLineaNegocio()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbLineaNegocio.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.LineasNegocio));
			ddlbLineaNegocio.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbLineaNegocio.DataTextField =Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbLineaNegocio.DataBind();
		}

		private void llenarMoneda()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbMoneda.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.Moneda));
			ddlbMoneda.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbMoneda.DataTextField =Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbMoneda.DataBind();
		}

		private void llenarVersiones()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbVersion.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.VersionesVentasPresupuestadas));
			ddlbVersion.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbVersion.DataTextField =Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbVersion.DataBind();
		}

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

		private void rblTipoPromotor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.txtCliente.Text = String.Empty;
			if(this.rblTipoPromotor.SelectedIndex == 1)
			{
				this.lblSector.Visible = true;
				this.ddlbSector.Visible = true;
				this.ibtnBuscarCliente.Visible = false;
				this.txtCliente.ReadOnly = false;
			}
			else
			{
				this.lblSector.Visible = false;
				this.ddlbSector.Visible = false;
				this.ibtnBuscarCliente.Visible = true;
				this.txtCliente.ReadOnly = true;
			}
		}
	}
}