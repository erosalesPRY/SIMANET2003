using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.CartasCredito
{
	/// <summary>
	/// Summary description for DetalleCartadeCredito.
	/// </summary>
	public class DetalleCartadeCredito : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string OBJPARAMETROCONTABLE="ParametroCartaCredito";
		const string GRILLAVACIA ="No existe ningún Registro.";  		
		const string KEYIDCARTACREDITO = "idCC";
		const string KEYIDPERIODO ="Periodo";
		const string KEYIDSITUACION ="Estado";
		const string KEYIDCENTRO ="IdCentro";
		const string KEYIDTIPOCREDITO = "idTipoCredito";

		//Paginas
		const string URLPRINCIPAL ="AdminsitracionDeCartadeCredito.aspx";
		const string URLPOPUPBUSQUEDA ="BuscarOrdendeCompra.aspx?";
		const string URLDETALLE="DetalleCartadeCredito.aspx?";
		const string URLBUSCARPAIS ="../../General/BuscarPais.aspx";
		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblInformeEmitido;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblObservacion;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtMoneda;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label11;
		protected eWorld.UI.NumericBox nTipoCambio;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvnMontoCC;
		protected eWorld.UI.NumericBox nMontoCC;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected eWorld.UI.NumericBox nComisionApertura;
		protected eWorld.UI.NumericBox nComisionNegociacion;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label18;
		protected eWorld.UI.NumericBox nDiasValidos;
		protected System.Web.UI.WebControls.Label lblFechaVence;
		protected eWorld.UI.NumericBox nGastos;
		protected System.Web.UI.WebControls.Label Label20;
		protected eWorld.UI.NumericBox NTotalOC;
		protected System.Web.UI.WebControls.Label Label19;
		protected eWorld.UI.NumericBox nContravalor;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroDocumento;
		protected System.Web.UI.WebControls.TextBox txtNroDocumento;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.DropDownList ddlbEntidadFinanciera;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPais;
		protected System.Web.UI.WebControls.TextBox txtPais;
		protected System.Web.UI.WebControls.TextBox txtProveedor;
		protected System.Web.UI.WebControls.TextBox txtCentroOperativo;
		protected System.Web.UI.WebControls.ImageButton imgbtnMostrarGastosOC;
		protected eWorld.UI.CalendarPopup CalFechaEmite;
		protected System.Web.UI.HtmlControls.HtmlImage imgbtnBuscar;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected eWorld.UI.NumericBox nImporte;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtDescripcionOC;
		protected System.Web.UI.HtmlControls.HtmlTableCell IdCO;
		protected System.Web.UI.WebControls.TextBox txtidCentroOperativo;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD1;
		protected System.Web.UI.WebControls.ImageButton imgBtnBuscarOrdendeCompra;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroOC;
		protected System.Web.UI.HtmlControls.HtmlInputText txtNroOrdenCompra;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbTipoCredito;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoCredito;
		private   ListItem item =  new ListItem();
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
					this.LlenarCombos();
					this.CargarModoPagina();
					Helper.CalendarioControlStyle(this.CalFechaEmite);
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
					string debug = oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
			// Put user code to initialize the page here
		}

		private void CargarSituacion()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoCartaCredito));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();			
		}
		private void CargarEntidadFinanciera()
		{
			CEntidadFinanciera oCEntidadFinanciera = new CEntidadFinanciera();
			ddlbEntidadFinanciera.DataSource = oCEntidadFinanciera.ListarTodosCombo ();
			ddlbEntidadFinanciera.DataValueField= Enumerados.ColumnasEntidadFinanciera.IdEntidadFinanciera.ToString();
			ddlbEntidadFinanciera.DataTextField=Enumerados.ColumnasEntidadFinanciera.RazonSocial.ToString();
			ddlbEntidadFinanciera.DataBind();
		}
		private DataTable ObtenerOrdendeCompra()
		{
			CCartaCredito oCCartaCredito = new CCartaCredito();			
			return oCCartaCredito.ListarOrdendeCompra(Utilitario.Constantes.IDDEFAULT,Convert.ToString(Utilitario.Constantes.IDDEFAULT), CNetAccessControl.GetIdUser());
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
			this.imgBtnBuscarOrdendeCompra.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnBuscarOrdendeCompra_Click);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			//Referencia la Control de Parametros
			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE];
			//Referencia a la Entidad de Negocio
			CartaCreditoBE oCartaCreditoBE = new CartaCreditoBE();

			oCartaCreditoBE.Periodo = Convert.ToInt32(this.hPeriodo.Value);
			oCartaCreditoBE.NroOrdenCompra = Convert.ToInt32(this.hNroOC.Value).ToString() ;

			oCartaCreditoBE.NroCDI = this.txtNroDocumento.Text;
			oCartaCreditoBE.MontoCCredito = Convert.ToDouble(this.nMontoCC.Text.ToString().Trim());
			oCartaCreditoBE.TipodeCambio = Utilitario.Constantes.ValorConstanteCero;
			oCartaCreditoBE.ComisionNegociacion = ((this.nComisionNegociacion.Text.ToString().Trim().Length>0)? Convert.ToDouble(this.nComisionNegociacion.Text.ToString().Trim()):0);
			oCartaCreditoBE.ComisionApertura= ((this.nComisionApertura.Text.Trim().ToString().Length>0)?  Convert.ToDouble(this.nComisionApertura.Text.ToString().Trim()):0);
			oCartaCreditoBE.FechaEmision = this.CalFechaEmite.SelectedDate;
			oCartaCreditoBE.NroDiasValidos = Convert.ToInt32( this.nDiasValidos.Text);

			oCartaCreditoBE.IdEntidadFinanciera = Convert.ToInt32(this.ddlbEntidadFinanciera.SelectedValue);
			
			oCartaCreditoBE.IdCentroOperativo = Convert.ToInt32(this.txtidCentroOperativo.Text);
			oCartaCreditoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oCartaCreditoBE.Observacion = this.txtObservacion.Text;
			oCartaCreditoBE.IdEstado = Convert.ToInt32(this.ddlbSituacion.SelectedValue);
			oCartaCreditoBE.IdUbigeo = Convert.ToInt32(this.hIdPais.Value);
			oCartaCreditoBE.IdTablaTipoCredito = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraModalidaddeCartaCredito);
			oCartaCreditoBE.IdTipoCredito = Convert.ToInt32(this.ddlbTipoCredito.SelectedValue);

			if(Convert.ToInt32(((CCartaCredito) new CCartaCredito()).Insertar(oCartaCreditoBE)) >0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Carta de Credito",this.ToString(),"Se registró Item de Carta de Credito" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));								
				ltlMensaje.Text = Helper.MensajeRetornoAlert
					(Helper.ObtenerValorString(
					Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(), 
					Utilitario.Mensajes.CODIGOMENSAJESECONFIRMACIONCARTACREDITOREGISTRO));
			}					
		}

		public void Modificar()
		{
			CartaCreditoBE oCartaCreditoBE =  new CartaCreditoBE();

			oCartaCreditoBE.IdCartaCredito = Convert.ToInt32(Page.Request.Params[KEYIDCARTACREDITO]);
			oCartaCreditoBE.IdPeriodo = Convert.ToInt32(Page.Request.Params[KEYIDPERIODO]);
			oCartaCreditoBE.NroCDI = this.txtNroDocumento.Text;
			oCartaCreditoBE.MontoCCredito = Convert.ToDouble(this.nMontoCC.Text.ToString().Trim());
			oCartaCreditoBE.TipodeCambio = Utilitario.Constantes.ValorConstanteCero;
			oCartaCreditoBE.ComisionNegociacion = ((this.nComisionNegociacion.Text.ToString().Trim().Length>0)? Convert.ToDouble(this.nComisionNegociacion.Text.ToString().Trim()):0);
			oCartaCreditoBE.ComisionApertura= ((this.nComisionApertura.Text.Trim().ToString().Length>0)?  Convert.ToDouble(this.nComisionApertura.Text.ToString().Trim()):0);

			
			oCartaCreditoBE.Periodo = Convert.ToInt32(this.hPeriodo.Value);
			oCartaCreditoBE.NroOrdenCompra = Convert.ToInt32(this.hNroOC.Value).ToString();
			
			
			oCartaCreditoBE.IdEntidadFinanciera = Convert.ToInt32(this.ddlbEntidadFinanciera.SelectedValue);
			oCartaCreditoBE.Moneda = this.txtMoneda.Text;
			oCartaCreditoBE.NProveedor = this.txtProveedor.Text;
			oCartaCreditoBE.IdCentroOperativo = Convert.ToInt32(this.txtidCentroOperativo.Text);
			oCartaCreditoBE.FechaEmision = this.CalFechaEmite.SelectedDate;
			oCartaCreditoBE.NroDiasValidos = Convert.ToInt32( this.nDiasValidos.Text);

			oCartaCreditoBE.Observacion = this.txtObservacion.Text;
			oCartaCreditoBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oCartaCreditoBE.IdEstado = Convert.ToInt32(this.ddlbSituacion.SelectedValue);
			oCartaCreditoBE.IdUbigeo = Convert.ToInt32(this.hIdPais.Value);
			oCartaCreditoBE.IdTablaTipoCredito = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraModalidaddeCartaCredito);
			oCartaCreditoBE.IdTipoCredito = Convert.ToInt32(this.ddlbTipoCredito.SelectedValue);
			
			if(((CCartaCredito) new CCartaCredito()).Modificar(oCartaCreditoBE) >0)
			{					
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo
					(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se modificó Item de " + 
					oCartaCreditoBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));				
				//ltlMensaje.Text = Helper.MensajeRetornoAlert();
				ltlMensaje.Text = Helper.MensajeRetornoAlert
					(Helper.ObtenerValorString(
					Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(), 
					Utilitario.Mensajes.CODIGOMENSAJESECONFIRMACIONCARTACREDITOMODIFICACION));
				
			}			
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleCartadeCredito.Eliminar implementation
		}

		public void CargarModoPagina()
		{			
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
				case Enumerados.ModoPagina.C:
					this.CargarModoModificar();
					Helper.BloquearControles(this);
					break;
			}						
		}

		public void CargarModoNuevo()
		{
			
			// TODO:  Add DetalleCartadeCredito.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			CCartaCredito oCCartaCredito = new CCartaCredito();
			CartaCreditoBE oCartaCreditoBE = (CartaCreditoBE)
						   oCCartaCredito.DetalleCartadeCredito(Convert.ToInt16(Page.Request.Params[KEYIDSITUACION]),
																Convert.ToInt16(Page.Request.Params[KEYIDCARTACREDITO]),
																Convert.ToInt16(Page.Request.Params[KEYIDPERIODO]),
																CNetAccessControl.GetIdUser(),
																Convert.ToInt16(Page.Request.Params[KEYIDTIPOCREDITO]));

			this.txtNroDocumento.Text = oCartaCreditoBE.NroCDI;
			
			
			/*selecciona la situacion del registro*/			
			item = this.ddlbSituacion.Items.FindByValue(oCartaCreditoBE.IdEstado.ToString());
			if(item!=null)
			{item.Selected = true;}
			/*selecciona la entidad financiera*/
			item = this.ddlbEntidadFinanciera.Items.FindByValue(oCartaCreditoBE.IdEntidadFinanciera.ToString());
			if(item!=null)
			{item.Selected = true;}
			/*selecciona la Orden de compra*/

			/*selecciona el Tipo de Credito*/
			item = this.ddlbTipoCredito.Items.FindByValue(oCartaCreditoBE.IdTipoCredito.ToString());
			if(item!=null)
			{item.Selected = true;}		
			

			this.hPeriodo.Value = oCartaCreditoBE.Periodo.ToString();
			this.hNroOC.Value = oCartaCreditoBE.NroOrdenCompra.ToString();
			this.txtNroOrdenCompra.Value = oCartaCreditoBE.OrdenCompra.ToString();

			this.txtMoneda.Text = oCartaCreditoBE.Moneda.ToString();
			this.txtProveedor.Text = oCartaCreditoBE.NProveedor.ToString();
			this.txtCentroOperativo.Text = oCartaCreditoBE.NombreCentroOperativo.ToString();
			this.txtidCentroOperativo.Text = Page.Request.Params[KEYIDCENTRO].ToString();
			this.CalFechaEmite.SelectedDate = Convert.ToDateTime(oCartaCreditoBE.FechaEmision);
			this.nDiasValidos.Text=oCartaCreditoBE.NroDiasValidos.ToString(); 

			this.lblFechaVence.Text=Convert.ToDateTime(oCartaCreditoBE.FechaVencimiento).ToString().Replace("/","-").Substring(0,10);
			this.nImporte.Text = oCartaCreditoBE.MontoOC.ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
			this.nGastos.Text = oCartaCreditoBE.MontoGastoOC.ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
			this.NTotalOC.Text= Convert.ToDouble(oCartaCreditoBE.MontoOC + oCartaCreditoBE.MontoGastoOC).ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
			this.nTipoCambio.Text = Convert.ToString(oCartaCreditoBE.TipodeCambio);
			this.nContravalor.Text = oCartaCreditoBE.MontoOCContraValor.ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
			//Montos Cartas de Credito
			this.nMontoCC.Text = oCartaCreditoBE.MontoCCredito.ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
			
			this.txtObservacion.Text = oCartaCreditoBE.Observacion.ToString();
			this.nComisionNegociacion.Text = oCartaCreditoBE.ComisionNegociacion.ToString();
			this.nComisionApertura.Text = oCartaCreditoBE.ComisionApertura.ToString();
			this.hIdPais.Value = oCartaCreditoBE.IdUbigeo.ToString();
			this.txtPais.Text = oCartaCreditoBE.NombrePais.ToString();
			this.txtDescripcionOC.Text = oCartaCreditoBE.DescripcionOC.ToString();
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleCartadeCredito.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleCartadeCredito.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleCartadeCredito.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleCartadeCredito.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleCartadeCredito.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleCartadeCredito.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleCartadeCredito.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.CargarSituacion();
			this.CargarEntidadFinanciera();
			this.LlenarTipo();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleCartadeCredito.LlenarDatos implementation
		}

		public void LlenarTipo()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbTipoCredito.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.FinancieraModalidaddeCartaCredito));
			ddlbTipoCredito.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoCredito.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipoCredito.DataBind();					
		}

		public void LlenarJScript()
		{
			this.txtidCentroOperativo.Style.Add(Utilitario.Constantes.DISPLAY, Utilitario.Constantes.NONE);

			rfvNroDocumento.ErrorMessage = Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECARTADECREDITOCAMPOREQUERIDONROCDI);
			rfvNroDocumento.ToolTip = rfvNroDocumento.ErrorMessage ;
			
			rfvnMontoCC.ErrorMessage = Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECARTADECREDITOCAMPOREQUERIDOMONTOCDI);
			rfvnMontoCC.ToolTip = rfvNroDocumento.ErrorMessage ;

			this.Enfocar();

			string vDialogoPais = Helper.PopupBusqueda(URLBUSCARPAIS,300,400,false);			
			this.imgbtnBuscar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,vDialogoPais.Replace("return false;",Utilitario.Constantes.VACIO));

			this.imgBtnBuscarOrdendeCompra.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),Helper.PopupBusqueda(URLPOPUPBUSQUEDA,770,415));

			this.txtNroDocumento.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí el número del documento de la carta de crédito de importación",180));
			this.ddlbTipoCredito.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí el tipo de dirección de la carta de crédito",180));
			this.ddlbEntidadFinanciera.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí la entidad financiera para la carta de crédito",180));
			this.ddlbEntidadFinanciera.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí la entidad financiera para la carta de crédito",180));
			this.imgBtnBuscarOrdendeCompra.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí el número de la orden de compra para la carta de crédito",180));
			this.imgbtnBuscar.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí el país de procedencia del producto asociado a la carta de crédito",180));
			this.CalFechaEmite.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí la fecha de emisión de la carta de crédito",180));
			this.nDiasValidos.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí los días de validez de la carta de crédito",180));
			this.nComisionApertura.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí porcentaje de la comisión de apertura",180));
			this.nComisionNegociacion.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí porcentaje de la comisión de negociación",180));
			this.txtObservacion.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí una observación asociada a la carta de crédito",180));
			this.nImporte.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí el importe de la carta de crédito de importación",180));

		}
		private void Enfocar()
		{
			txtNroDocumento.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("ddlbSituacion"));
			ddlbSituacion.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("ddlbEntidadFinanciera"));
			ddlbEntidadFinanciera.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtNroOrdenCompra"));
			txtNroOrdenCompra.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("CalFechaEmite"));
			CalFechaEmite.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nGastos"));
			nGastos.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nDiasValidos"));
			nDiasValidos.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("NTotalOC"));
			NTotalOC.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nTipoCambio"));
			nTipoCambio.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nMontoCC"));
			nMontoCC.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nComisionApertura"));
			nComisionApertura.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nComisionNegociacion"));
			nComisionNegociacion.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtObservacion"));
			//txtObservacion.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("ddlbSituacion"));

		}
		public void RegistrarJScript()
		{
			// TODO:  Add DetalleCartadeCredito.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleCartadeCredito.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleCartadeCredito.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}									
		}

		public bool ValidarFiltros()
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
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA]) ;
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
				ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
			}
			catch(Exception oException)
			{
				ASPNetUtilitario.MessageBox.Show(oException.Message.ToString());
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		
		}

		private void redireccionaPaginaPrincipal()
		{			
			string strUrlGoBack = URLPRINCIPAL + Utilitario.Constantes.SIGNOINTERROGACION + KEYIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDSITUACION].ToString();
			Page.Response.Redirect(strUrlGoBack);
		}

		private void imgBtnBuscarOrdendeCompra_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}
	}
}
