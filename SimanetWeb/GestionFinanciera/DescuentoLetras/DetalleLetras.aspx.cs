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
using MetaBuilders.WebControls;
using SIMA.SimaNetWeb.Legal;

namespace SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras
{
	public class DetalleLetras : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
			const string OBJPARAMETROCONTABLE="ParametroDsctLetra";
			const string GRILLAVACIA ="No existe ningún Registro.";  
			const string URLBUSQUEDAENTIDAD="../../Legal/BusquedaEntidad.aspx?";
			const string URLBUSQUEDAPROYECTO="../../Legal/BusquedaProyecto.aspx";
			const string COLORDENAMIENTO = "idLetra";

			const string KEYIDDOCLET ="idDocLetra";
			const string KEYIDTIPOLETRA = "TipoLetra";
			const string KEYNOMBRETIPOLETRA = "NombreTipoLetra";
			const string KEYIDCENTRO = "idCentro";			
			const string KEYIDMODOLETRA ="MODOLETRA";
			
			string JSVERIFICARELIMINAR = "return verificarRenovacion();";

		#endregion


		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList ddlbMoneda;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvProvCli;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Image ibtnBuscarProyecto;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label3;
		protected eWorld.UI.NumericBox nTasaInteres;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.HtmlControls.HtmlInputText hNumero;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdProyecto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdEntidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTablaEntidad;
		protected System.Web.UI.HtmlControls.HtmlTable ToolBar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.TextBox txtNroDocumento;
		protected System.Web.UI.WebControls.Image ibtnBuscarEntidad;
		protected System.Web.UI.WebControls.Label Label2;
		protected eWorld.UI.NumericBox NDiasPlazo;
		protected System.Web.UI.WebControls.Label Label7;
		protected eWorld.UI.NumericBox nDiasVence;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMontoEstablecido;
		protected eWorld.UI.NumericBox nMonto;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected System.Web.UI.HtmlControls.HtmlTable tblAtras;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbSituacion;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbMoneda;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.HtmlControls.HtmlInputText txtEntidad;
		protected eWorld.UI.CalendarPopup CalFechaVencimiento;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTasaInteres;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtCliente;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroReferencia;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.HtmlControls.HtmlTextArea txtProyecto;
		protected System.Web.UI.WebControls.TextBox txtDatosProyecto;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoTrabajo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbTipoTrabajo;
		protected System.Web.UI.HtmlControls.HtmlTableRow FilaCalculada;
		protected System.Web.UI.WebControls.Label Label12;
		protected eWorld.UI.NumericBox nMontoCancelado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPostback;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
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
					this.LlenarDatos();
					this.LlenarCombos();
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
					string debug = oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
			if(this.hPostback.Value=="Grabar"){
				Aceptar();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleLetras.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleLetras.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleLetras.LlenarGrillaOrdenamientoPaginacion implementation
		}

		private void CargarCentroOperativo()
		{
			CCentroOperativo oCCentroOperativo =   new  CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarCentroOperativoAccesoSegunPrivilegioUsuario(CNetAccessControl.GetIdUser(),Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoLetras));
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Nombre.ToString();
			ddlbCentroOperativo.DataBind();
		}

		private void CargarSituacion()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraSituacionLetras));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();
			ListItem litem =  ddlbSituacion.Items.FindByValue("4");
			if(litem!=null){ddlbSituacion.Items.Remove(litem);}
		}
		private void CargarTipodeTrabajos()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbTipoTrabajo.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTipodeTrabajos));
			ddlbTipoTrabajo.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoTrabajo.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipoTrabajo.DataBind();			
		}

		

		private void CargarMoneda()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbMoneda.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.Moneda));
			ddlbMoneda.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbMoneda.DataTextField = Enumerados.ColumnasTablaTablas.Var1.ToString();
			ddlbMoneda.DataBind();			
		}


		public void LlenarCombos()
		{
			this.CargarCentroOperativo();
			this.CargarSituacion();
			this.CargarMoneda();
			this.CargarTipodeTrabajos();
		}

		public void LlenarDatos()
		{
			this.lblPagina.Text = Page.Request.Params[KEYNOMBRETIPOLETRA].ToString();
		}

		public void LlenarJScript()
		{
			if (Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA].ToString()== Utilitario.Enumerados.ModoPagina.N.ToString())
			{
				FilaCalculada.Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
			}

			rfvNroReferencia.ErrorMessage = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRANROLETRA); 
			rfvNroReferencia.ToolTip = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRANROLETRA); 

			rfvProvCli.ErrorMessage = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRAPROVEEDORCLIENTE);
			rfvProvCli.ToolTip = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRAPROVEEDORCLIENTE);

			rfvMontoEstablecido.ErrorMessage = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRAMONTOLETRA);
			rfvMontoEstablecido.ToolTip = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRAMONTOLETRA);

			rfvTasaInteres.ErrorMessage = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRATASAINTERESLETRA);
			rfvTasaInteres.ToolTip = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRATASAINTERESLETRA);

			if (Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA].ToString()== Utilitario.Enumerados.ModoPagina.C.ToString())
			{
				rfvTasaInteres.Visible=false;
				rfvProvCli.Visible=false;
				rfvMontoEstablecido.Visible=false;
				ibtnBuscarProyecto.Visible=false;
				ibtnBuscarEntidad.Visible=false;
			}
			ibtnBuscarEntidad.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAENTIDAD + KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRA].ToString() ,700,800,true));
			//ibtnBuscarEntidad.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAENTIDAD + Utilitario.Constantes.KEYTIPOBUSQUEDAENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRA].ToString() ,700,800,true));
			ibtnBuscarProyecto.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAPROYECTO,730,500,true));
			
			

			this.Enfocar();
		}

		private void Enfocar()
		{
			txtNroDocumento.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("ddlbCentroOperativo"));
			ddlbCentroOperativo.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("ddlbSituacion"));
			ddlbSituacion.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("ddlbMoneda"));
			ddlbMoneda.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("hNumero"));
			hNumero.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtEntidad"));
			txtEntidad.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtProyecto"));
			txtProyecto.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtDatosProyecto"));
			txtDatosProyecto.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("CalFechaInicio"));
			CalFechaInicio.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("CalFechaVencimiento"));
			CalFechaVencimiento.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("NDiasPlazo"));
			NDiasPlazo.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nDiasVence"));
			nDiasVence.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nMonto"));
			nMonto.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nTasaInteres"));
			nTasaInteres.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtObservacion"));
			//txtObservacion.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtNroDocumento"));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleLetras.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleLetras.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleLetras.Exportar implementation
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
			// TODO:  Add DetalleLetras.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			LetrasDBE oLetrasDBE = new LetrasDBE();
			oLetrasDBE.NroDocumento = this.txtNroDocumento.Text;
			
			oLetrasDBE.IdCentroOperativo = Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue);
			//oLetrasDBE.IdProyectoContrato = (this.hIdProyecto.Value.ToString().Trim().Length >0 )? Convert.ToInt32(this.hIdProyecto.Value):0;
			if(this.hIdProyecto.Value.ToString().Trim().Length >0)
			{
				oLetrasDBE.IdProyectoContrato = Convert.ToInt32(this.hIdProyecto.Value);
			}
				
			oLetrasDBE.DescripcionProyecto = this.txtDatosProyecto.Text;
			oLetrasDBE.IdTablaTipoLetra = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTipodeLetras);
			oLetrasDBE.IdTipoLetra = Convert.ToInt32(Page.Request.Params[KEYIDTIPOLETRA]);
			oLetrasDBE.FechaInicio = Convert.ToDateTime(this.CalFechaInicio.SelectedDate);
			oLetrasDBE.FechaVencimiento = Convert.ToDateTime(this.CalFechaVencimiento.SelectedDate);
			oLetrasDBE.IdTablaSituacion = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraSituacionLetras);
			oLetrasDBE.IdSituacion = Convert.ToInt32(this.ddlbSituacion.SelectedValue);
			oLetrasDBE.IdTablaMoneda = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.Moneda);
			oLetrasDBE.IdMoneda = Convert.ToInt32(this.ddlbMoneda.SelectedValue);
			oLetrasDBE.IdTablaTipoEntidad = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTipoEntidad);
			oLetrasDBE.IdTipoEntidad = Convert.ToInt32(this.hIdEntidad.Value);
			oLetrasDBE.IdEntidad = Convert.ToInt32(this.hIdCodigo.Value);
			oLetrasDBE.IdTablaTipoTrabajo= Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTipodeTrabajos);
			oLetrasDBE.IdTipoTrabajo= Convert.ToInt32(this.ddlbTipoTrabajo.SelectedValue);
			oLetrasDBE.Monto = Convert.ToDouble(this.nMonto.Text);
			oLetrasDBE.TasaInteres = Convert.ToDecimal(this.nTasaInteres.Text);
			oLetrasDBE.MontoCancelado = Convert.ToDouble(this.nMontoCancelado.Text);
			oLetrasDBE.Observacion = this.txtObservacion.Text;
			oLetrasDBE.IdTablaEstado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoLetras) ;
			oLetrasDBE.IdEstado = 1;
			oLetrasDBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			if(((CLetras)new CLetras()).Insertar(oLetrasDBE)>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se modificó Item de " + oLetrasDBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
			
		}

		public void Modificar()
		{
			LetrasDBE oLetrasDBE = new LetrasDBE();
			oLetrasDBE.IdLetra = Page.Request.Params[KEYIDDOCLET].ToString();
			oLetrasDBE.NroDocumento = this.txtNroDocumento.Text;
			oLetrasDBE.IdLetraOrigen ="";
			oLetrasDBE.IdCentroOperativo = Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue);
			if(this.hIdProyecto.Value.ToString().Trim().Length >0)
			{
				oLetrasDBE.IdProyectoContrato = Convert.ToInt32(this.hIdProyecto.Value);
			}
			oLetrasDBE.DescripcionProyecto = this.txtDatosProyecto.Text;
			oLetrasDBE.IdTablaTipoLetra = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTipodeLetras);
			oLetrasDBE.IdTipoLetra = Convert.ToInt32(Page.Request.Params[KEYIDTIPOLETRA]);
			oLetrasDBE.FechaInicio = Convert.ToDateTime(this.CalFechaInicio.SelectedDate);
			oLetrasDBE.FechaVencimiento = Convert.ToDateTime(this.CalFechaVencimiento.SelectedDate);
			oLetrasDBE.IdTablaSituacion = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraSituacionLetras);
			oLetrasDBE.IdSituacion = Convert.ToInt32(this.ddlbSituacion.SelectedValue);
			oLetrasDBE.IdTablaMoneda = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.Moneda);
			oLetrasDBE.IdMoneda = Convert.ToInt32(this.ddlbMoneda.SelectedValue);
			oLetrasDBE.IdTablaTipoEntidad = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTipoEntidad);
			oLetrasDBE.IdTipoEntidad = Convert.ToInt32(this.hIdEntidad.Value);
			oLetrasDBE.IdEntidad = Convert.ToInt32(this.hIdCodigo.Value.ToString());
			oLetrasDBE.IdTablaTipoTrabajo= Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTipodeTrabajos);
			oLetrasDBE.IdTipoTrabajo= Convert.ToInt32(this.ddlbTipoTrabajo.SelectedValue);
			oLetrasDBE.Monto = Convert.ToDouble(this.nMonto.Text);
			oLetrasDBE.TasaInteres = Convert.ToDecimal(this.nTasaInteres.Text);
			oLetrasDBE.MontoCancelado = Convert.ToDouble(this.nMontoCancelado.Text);
			oLetrasDBE.Observacion = this.txtObservacion.Text;
			oLetrasDBE.IdTablaEstado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoLetras) ;
			oLetrasDBE.IdEstado = 1;
			oLetrasDBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			const int SituacionCancelada = 4;
			if((Convert.ToDouble(this.nMontoCancelado.Text)!= Convert.ToDouble(this.nMonto.Text))&& (Convert.ToDouble(this.nMontoCancelado.Text)!=0))
			{
				double MontoSaldoLetra = Convert.ToDouble(this.nMonto.Text)-Convert.ToDouble(this.nMontoCancelado.Text);
				int SituacionActual = oLetrasDBE.IdSituacion;
				oLetrasDBE.IdSituacion = SituacionCancelada;
				((CLetras)new CLetras()).Modificar(oLetrasDBE);

				//Llamar a la pantalla de renovaciones popup


				//Restaura la Situacion de la Letra Original el cual deberá asumir la renovación
				/*oLetrasDBE.IdLetraOrigen = Page.Request.Params[KEYIDDOCLET].ToString();
				oLetrasDBE.IdSituacion = SituacionActual;
				oLetrasDBE.Monto =  MontoSaldoLetra;
				oLetrasDBE.MontoCancelado = 0;*/

				/*if(((CLetras)new CLetras()).Insertar(oLetrasDBE)>0)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se modificó Item de " + oLetrasDBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert();
				}*/

			}
			else if(Convert.ToDouble(this.nMontoCancelado.Text)== Convert.ToDouble(this.nMonto.Text)){
				oLetrasDBE.IdSituacion = SituacionCancelada;
				if(((CLetras)new CLetras()).Modificar(oLetrasDBE)>0)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se modificó Item de " + oLetrasDBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert();
				}				
			}
			else
			{
				if(((CLetras)new CLetras()).Modificar(oLetrasDBE)>0)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se modificó Item de " + oLetrasDBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert();
				}
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleLetras.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					if(Page.Request.Params[KEYIDMODOLETRA]!=null)
					{
						this.CargarModoModificar();
					}
					else
					{
						this.CargarModoNuevo();
					}
					this.tblAtras.Visible= false;
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					this.tblAtras.Visible= false;
					break;
				case Enumerados.ModoPagina.C:
					this.CargarModoModificar();
					if (Page.Request.Params[Utilitario.Constantes.KEYMODULOCONSULTA].ToString()== Utilitario.Enumerados.ModuloConsulta.Si.ToString())
					{
						Helper.BloquearControles(this);
						this.ibtnCancelar.Visible=false;
						this.ToolBar.Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
						this.tblAtras.Visible= true;
					}
					break;			
			}
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalleLetras.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{

			LetrasDBE oLetrasDBE = (LetrasDBE)((CLetras) new CLetras()).DetalleLetras(Page.Request.Params[KEYIDDOCLET],Utilitario.Constantes.IDDEFAULT,Utilitario.Constantes.IDDEFAULT,Utilitario.Constantes.IDDEFAULT,CNetAccessControl.GetIdUser());

			this.txtNroDocumento.Text = oLetrasDBE.NroDocumento.ToString();
		  	((ListItem)this.ddlbCentroOperativo.Items.FindByValue(oLetrasDBE.IdCentroOperativo.ToString())).Selected =true;
			this.hIdProyecto.Value = oLetrasDBE.IdProyectoContrato.ToString();
			this.txtProyecto.Value = oLetrasDBE.NombreProyecto.ToString();
			this.txtDatosProyecto.Text= oLetrasDBE.DescripcionProyecto.ToString();
			this.CalFechaInicio.SelectedDate = Convert.ToDateTime(oLetrasDBE.FechaInicio);
			this.CalFechaVencimiento.SelectedDate = Convert.ToDateTime(oLetrasDBE.FechaVencimiento);
			this.NDiasPlazo.Text = oLetrasDBE.NroDiasPlazo.ToString();
			this.nDiasVence.Text = oLetrasDBE.NroDiasFaltantes.ToString();
			((ListItem)this.ddlbSituacion.Items.FindByValue(oLetrasDBE.IdSituacion.ToString())).Selected =true;
			((ListItem)this.ddlbMoneda.Items.FindByValue(oLetrasDBE.IdMoneda.ToString())).Selected =true;
			((ListItem)this.ddlbTipoTrabajo.Items.FindByValue(oLetrasDBE.IdTipoTrabajo.ToString())).Selected =true;
			this.hIdTablaEntidad.Value = oLetrasDBE.IdTablaTipoEntidad.ToString();
			this.hIdEntidad.Value = oLetrasDBE.IdTipoEntidad.ToString();
			this.hIdCodigo.Value = oLetrasDBE.IdEntidad.ToString();
			this.hNumero.Value = oLetrasDBE.NroEntidad.ToString();
			this.txtEntidad.Value=oLetrasDBE.RazonSocial.ToString();
			this.nMonto.Text  = oLetrasDBE.Monto.ToString();
			this.nTasaInteres.Text=oLetrasDBE.TasaInteres.ToString();
			this.nMontoCancelado.Text  = oLetrasDBE.MontoCancelado.ToString();
			this.txtObservacion.Text = oLetrasDBE.Observacion.ToString();
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleLetras.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleLetras.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleLetras.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleLetras.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void Aceptar(){
			try
			{
				//if(Page.IsValid)
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
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}		
		}	
	
	
	}
}
