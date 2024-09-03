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

namespace SIMA.SimaNetWeb.GestionFinanciera.PrestamosBancarios
{
	/// <summary>
	/// Summary description for DetallePrestamoAmortiza.
	/// </summary>
	public class DetallePrestamoAmortiza : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string OBJPARAMETROCONTABLE="ParametroPrestamos";
		const string GRILLAVACIA ="No existe ningún Registro.";  

		const string URLPRINCIPAL="DetallePrestamoBancario.aspx";
		const string COLORDENAMIENTO = "IDAMORTIZA";

		const string KEYIDAMORTIZA = "idAMTZ";
		const string KEYIDPRESTAMO = "idPTM";
		const string KEYIDPERIODO ="Periodo";
		const string KEYIDSITUACION ="Estado";

		const string KEYIDCENTRO ="IdCentro";
		const string KEYIDENTIDADFINANCIERA ="IdEntidadFin";
		
		const string CMPIDAMORTIZA ="hlkIdAmortiza";
		const string CMPMONTOMORTIZA ="lblMontoAmortiza";
		const string CMPMONTOINTERES ="lblMontoInteres";

		const string TITULOCRONOGRAMAPAGO ="CRONOGRAMA DE PAGO :";

		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		private   ListItem item =  new ListItem();
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtNroPrestamo;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList ddlbMoneda;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label Label9;
		protected eWorld.UI.NumericBox nMontoPtm;
		protected System.Web.UI.WebControls.Label Label3;
		protected eWorld.UI.NumericBox txtTasaInteres;
		protected System.Web.UI.WebControls.Label Label16;
		protected eWorld.UI.NumericBox Numericbox1;
		protected System.Web.UI.WebControls.Label Label15;
		protected eWorld.UI.NumericBox nDiasPlazo;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.DropDownList ddlbModalidad;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlbEntidadFinanciera;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtConcepto;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label Label20;
		protected eWorld.UI.NumericBox nMontoAmortiza;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMontoAmortiza;
		protected System.Web.UI.WebControls.Label Label7;
		protected eWorld.UI.NumericBox nMontoInteres;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.HtmlControls.HtmlTableRow rowConceptoTitulo;
		protected System.Web.UI.HtmlControls.HtmlTableRow rowToolbar;
		protected System.Web.UI.HtmlControls.HtmlTable tblAtras;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacionAmortiza;
		protected eWorld.UI.CalendarPopup CalFechaPrestamo;
		protected eWorld.UI.CalendarPopup CalFechaVencimiento;
		protected eWorld.UI.CalendarPopup CalFechaAmortiza;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbMoneda;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbSituacion;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbModalidad;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbEntidadFinanciera;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbSituacionAmortiza;
		protected System.Web.UI.WebControls.Label Label10;
		protected eWorld.UI.CalendarPopup CalFechaPago;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMontoInteres;
		protected System.Web.UI.WebControls.CheckBox chkCancelado;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.ImageButton Imagebutton1;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlTableRow rowAmortiza2;
		protected System.Web.UI.HtmlControls.HtmlTableRow rowAmortiza1;
		protected System.Web.UI.WebControls.Label Label8;
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
					this.LlenarCombos();
					this.CargarModoConsulta();
					this.CargarModoPagina();
					this.LlenarGrillaOrdenamientoPaginacion(String.Empty,Utilitario.Constantes.INDICEPAGINADEFAULT);
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Detalle de Prestamo Amortiza.",Enumerados.NivelesErrorLog.I.ToString()));					
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
					string debug = oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}			
			// Put user code to initialize the page here
		}
		private void CargarCentroOperativo()
		{
			CCentroOperativo oCCentroOperativo =   new  CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Nombre.ToString();
			ddlbCentroOperativo.DataBind();
		}
		private void CargarEntidadFinanciera()
		{
			CEntidadFinanciera oCEntidadFinanciera = new CEntidadFinanciera();
			ddlbEntidadFinanciera.DataSource = oCEntidadFinanciera.ListarTodosCombo ();
			ddlbEntidadFinanciera.DataValueField= Enumerados.ColumnasEntidadFinanciera.IdEntidadFinanciera.ToString();
			ddlbEntidadFinanciera.DataTextField=Enumerados.ColumnasEntidadFinanciera.RazonSocial.ToString();
			ddlbEntidadFinanciera.DataBind();
		}
		private void CargarSituacion()
		{
			
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoPrestamoBancario));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();			

			//CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacionAmortiza.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadodeAmortizaciondePrestamo));
			ddlbSituacionAmortiza.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacionAmortiza.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacionAmortiza.DataBind();			

		}

		private void CargarMoneda()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbMoneda.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.Moneda));
			ddlbMoneda.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbMoneda.DataTextField = Enumerados.ColumnasTablaTablas.Var1.ToString();
			ddlbMoneda.DataBind();			
		}
		private void CargarModalidadPrestamo()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbModalidad.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraModalidaddePrestamo));
			ddlbModalidad.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbModalidad.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbModalidad.DataBind();			
		}


		private void DesactivarControles()
		{
			this.txtNroPrestamo.Enabled = false;
			this.ddlbSituacion.Enabled = false;
			this.ddlbCentroOperativo.Enabled = false;
			this.ddlbEntidadFinanciera.Enabled = false;
			this.ddlbMoneda.Enabled = false;
			this.nDiasPlazo.Enabled=false;
			this.txtTasaInteres.Enabled = false;
			this.nMontoPtm.Enabled = false;
			this.ddlbModalidad.Enabled = false;
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
			// TODO:  Add DetallePrestamoAmortiza.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePrestamoAmortiza.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePrestamoAmortiza.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.CargarCentroOperativo();
			this.CargarEntidadFinanciera();
			this.CargarSituacion();
			this.CargarMoneda();			
			this.CargarModalidadPrestamo();
			// TODO:  Add DetallePrestamoAmortiza.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePrestamoAmortiza.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvMontoAmortiza.ErrorMessage =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPRESTAMOBANCARIOAMORTIZACAMPOREQUERIDOMONTOPRESTAMO);
			rfvMontoAmortiza.ToolTip=rfvMontoAmortiza.ErrorMessage;

			rfvMontoInteres.ErrorMessage =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPRESTAMOBANCARIOAMORTIZACAMPOREQUERIDOMONTOINTERES);
			rfvMontoInteres.ToolTip=rfvMontoInteres.ErrorMessage;
			this.Enfocar();
		}
		private void Enfocar()
		{
			CalFechaAmortiza.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nMontoAmortiza"));
			nMontoAmortiza.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nMontoInteres"));
			nMontoInteres.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nMontoInteres"));
			nMontoInteres.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nTipoCambio"));
			txtObservacion.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("CalFechaAmortiza"));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePrestamoAmortiza.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePrestamoAmortiza.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePrestamoAmortiza.Exportar implementation
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
			// TODO:  Add DetallePrestamoAmortiza.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			PrestamoAmortizaBE oPrestamoAmortizaBE = new PrestamoAmortizaBE();
			oPrestamoAmortizaBE.Idprestamo = Convert.ToInt32( Page.Request.Params[KEYIDPRESTAMO]);
			oPrestamoAmortizaBE.Periodo = Convert.ToInt32( Page.Request.Params[KEYIDPERIODO]);
			oPrestamoAmortizaBE.FechaPago = Convert.ToDateTime(CalFechaPago.SelectedDate);
			oPrestamoAmortizaBE.Fechaamortiza = Convert.ToDateTime(CalFechaAmortiza.SelectedDate);
			oPrestamoAmortizaBE.Montoamortiza = Convert.ToDecimal(this.nMontoAmortiza.Text.ToString().Trim());
			oPrestamoAmortizaBE.Montointeres = Convert.ToDecimal(this.nMontoInteres.Text.ToString().Trim());
			oPrestamoAmortizaBE.TipoCambio = 0;
			oPrestamoAmortizaBE.Cancelado = ((this.chkCancelado.Checked ==true)?1:0);
			oPrestamoAmortizaBE.Idestado = Convert.ToInt32(this.ddlbSituacionAmortiza.SelectedValue);
			oPrestamoAmortizaBE.Observacion = Convert.ToString(this.txtObservacion.Text);
			oPrestamoAmortizaBE.Idusuarioregistro = CNetAccessControl.GetIdUser();

			if(((CPrestamoBancarioAmortizacion) new CPrestamoBancarioAmortizacion()).Insertar(oPrestamoAmortizaBE) > Utilitario.Constantes.ValorConstanteCero)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName()
														,"GestionFinanciera"
														,this.ToString()
														,"Se Ingreso Item de " + oPrestamoAmortizaBE.ToString()
														,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROPRESTAMOBANCARIOAMORTIZA));
			}			
		}

		public void Modificar()
		{
			//Referencia a la Entidad de Negocio
			PrestamoAmortizaBE oPrestamoAmortizaBE = new PrestamoAmortizaBE();

			oPrestamoAmortizaBE.Idamortiza = Convert.ToInt32( Page.Request.Params[KEYIDAMORTIZA]);
			oPrestamoAmortizaBE.Idprestamo = Convert.ToInt32( Page.Request.Params[KEYIDPRESTAMO]);
			oPrestamoAmortizaBE.Periodo = Convert.ToInt32( Page.Request.Params[KEYIDPERIODO]);
			oPrestamoAmortizaBE.FechaPago = Convert.ToDateTime(CalFechaPago.SelectedDate);
			oPrestamoAmortizaBE.Fechaamortiza = Convert.ToDateTime(CalFechaAmortiza.SelectedDate);
			oPrestamoAmortizaBE.Montoamortiza = Convert.ToDecimal(this.nMontoAmortiza.Text);
			oPrestamoAmortizaBE.Montointeres = Convert.ToDecimal(this.nMontoInteres.Text);
			oPrestamoAmortizaBE.TipoCambio = 0;
			oPrestamoAmortizaBE.Cancelado = ((this.chkCancelado.Checked ==true)?1:0);
			oPrestamoAmortizaBE.Idestado = Convert.ToInt32(this.ddlbSituacionAmortiza.SelectedValue);
			oPrestamoAmortizaBE.Observacion = Convert.ToString(this.txtObservacion.Text);
			oPrestamoAmortizaBE.Idusuarioactualizacion = CNetAccessControl.GetIdUser();

			CPrestamoBancarioAmortizacion OCPrestamoBancarioAmortizacion = new CPrestamoBancarioAmortizacion();
			int retorno = OCPrestamoBancarioAmortizacion.Modificar(oPrestamoAmortizaBE);
			if(retorno > Utilitario.Constantes.ValorConstanteCero)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName()
															,"GestionFinanciera",this.ToString()
															,"Se modificó Item de " + oPrestamoAmortizaBE.ToString()
															,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONPRESTAMOBANCARIOAMORTIZA));
			}			
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePrestamoAmortiza.Eliminar implementation
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
					rowToolbar.Visible=false;
					tblAtras.Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.BLOCK);
					break;
			}			
			// TODO:  Add DetallePrestamoAmortiza.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			this.rowAmortiza1.Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
			this.rowAmortiza2.Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
			this.Label8.Text =TITULOCRONOGRAMAPAGO;
		}

		public void CargarModoModificar()
		{
			CPrestamoBancarioAmortizacion oCPrestamoBancarioAmortizacion = new CPrestamoBancarioAmortizacion();

			PrestamoAmortizaBE oPrestamoAmortizaBE = (PrestamoAmortizaBE)
				oCPrestamoBancarioAmortizacion.DetallePrestamoBancarioAmortiza(Convert.ToInt32(Page.Request.Params[KEYIDPRESTAMO]),
																				Convert.ToInt32(Page.Request.Params[KEYIDPERIODO]),
																				Convert.ToInt32(Page.Request.Params[KEYIDAMORTIZA]));

			ListItem item = this.ddlbSituacionAmortiza.Items.FindByValue(oPrestamoAmortizaBE.Idestado.ToString());
			if (item!=null)
			{
				item.Selected=true;
			}
			
			this.CalFechaPago.SelectedDate = Convert.ToDateTime(oPrestamoAmortizaBE.FechaPago);
			this.CalFechaAmortiza.SelectedDate = Convert.ToDateTime(oPrestamoAmortizaBE.Fechaamortiza);
			this.nMontoAmortiza.Text = oPrestamoAmortizaBE.Montoamortiza.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			this.nMontoInteres.Text = oPrestamoAmortizaBE.Montointeres.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			this.chkCancelado.Checked = ((oPrestamoAmortizaBE.Cancelado== Utilitario.Constantes.ValorConstanteUno)?true:false);
//			this.nTipoCambio.Text = oPrestamoAmortizaBE.TipoCambio.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			this.txtObservacion.Text= oPrestamoAmortizaBE.Observacion.ToString();
			// TODO:  Add DetallePrestamoAmortiza.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			CPrestamoBancario  oCPrestamoBancario = new CPrestamoBancario();
			PrestamoBancarioBE oPrestamoBancarioBE = (PrestamoBancarioBE) 
				oCPrestamoBancario.DetallePrestamoBancario(	Convert.ToInt32(Page.Request.Params[KEYIDSITUACION]),
															Convert.ToInt32(Page.Request.Params[KEYIDPRESTAMO]),
															Convert.ToInt32(Page.Request.Params[KEYIDPERIODO]),
															CNetAccessControl.GetIdUser());

			
			item = this.ddlbCentroOperativo.Items.FindByValue(oPrestamoBancarioBE.Idcentrooperativo.ToString());
			if(item!=null)
			{item.Selected = true;}

			item = this.ddlbEntidadFinanciera.Items.FindByValue(oPrestamoBancarioBE.Identidadfinanciera.ToString());
			if(item!=null)
			{item.Selected = true;}

			item = this.ddlbSituacion.Items.FindByValue(Convert.ToString(Page.Request.Params[KEYIDSITUACION]));
			if(item!=null)
			{item.Selected = true;}

			item = this.ddlbMoneda.Items.FindByValue(Convert.ToString(oPrestamoBancarioBE.Idmoneda));
			if(item!=null)
			{item.Selected = true;}

			item = this.ddlbModalidad.Items.FindByValue(Convert.ToString(oPrestamoBancarioBE.IdModalidadPtmo));
			if(item!=null)
			{item.Selected = true;}

			this.txtNroPrestamo.Text = Convert.ToString(oPrestamoBancarioBE.Nroprestamo);
			this.txtTasaInteres.Text= oPrestamoBancarioBE.Tasainteres.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			this.nMontoPtm.Text = oPrestamoBancarioBE.Montoptmo.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			this.nDiasPlazo.Text = oPrestamoBancarioBE.Diasplazo.ToString();
			this.txtConcepto.Text = oPrestamoBancarioBE.Concepto.ToString();
			this.DesactivarControles();
			//Helper.BloquearControles(this);
			// TODO:  Add DetallePrestamoAmortiza.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetallePrestamoAmortiza.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetallePrestamoAmortiza.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetallePrestamoAmortiza.ValidarExpresionesRegulares implementation
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
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}		
		}

	}
}
