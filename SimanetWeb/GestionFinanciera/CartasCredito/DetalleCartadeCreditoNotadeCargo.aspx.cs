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
	/// Summary description for DetalleCartadeCreditoNotadeCargo.
	/// </summary>
	public class DetalleCartadeCreditoNotadeCargo : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
			const string KEYIDNOTACREDITO="idNotaC";
			const string KEYIDCARTACREDITO = "idCC";
			const string KEYIDPERIODO ="Periodo";
			const string URLPRINCIPAL =  "AdministrarCartaCreditoNotadeCargo.aspx?";
			const string KEYIDMONEDA ="IdMoneda";
		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblInformeEmitido;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label11;
		protected eWorld.UI.NumericBox nTipoCambio;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.HtmlControls.HtmlTableCell IdCO;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.DropDownList ddlbMoneda;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMonto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvnMontoInteres;
		protected eWorld.UI.NumericBox nMonto;
		protected eWorld.UI.NumericBox nMontoInteres;
		protected System.Web.UI.WebControls.TextBox txtConcepto;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected eWorld.UI.CalendarPopup CalFechaCancelacion;
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
					this.CargarModoPagina();
					Helper.CalendarioControlStyle(this.CalFechaCancelacion);
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
			// TODO:  Add DetalleCartadeCreditoNotadeCargo.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleCartadeCreditoNotadeCargo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleCartadeCreditoNotadeCargo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.LlenarSituacion();
			this.LlenarMoneda();
			// TODO:  Add DetalleCartadeCreditoNotadeCargo.LlenarCombos implementation
		}
		private void LlenarSituacion()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.FinancieraEstadoCartaCreditoNotas));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();			
		}

		private void LlenarMoneda()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbMoneda.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.Moneda));
			ddlbMoneda.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbMoneda.DataTextField = Enumerados.ColumnasTablaTablas.Var2.ToString();
			ddlbMoneda.DataBind();			
		}
		public void LlenarDatos()
		{
			// TODO:  Add DetalleCartadeCreditoNotadeCargo.LlenarDatos implementation
		}

		public void LlenarJScript()
		{			
			rfvMonto.ErrorMessage = Helper.ObtenerMensajesErrorGestionFinancieraUsuario(Mensajes.CODIGOMENSAJESEERRORCARTACREDITOMONTOAMORTIZACION);
			rfvMonto.ToolTip = rfvMonto.ErrorMessage;
			
			rfvnMontoInteres.ErrorMessage = Helper.ObtenerMensajesErrorGestionFinancieraUsuario(Mensajes.CODIGOMENSAJESEERRORCARTACREDITOINTERESAMORTIZACION);
			rfvnMontoInteres.ToolTip = rfvnMontoInteres.ErrorMessage;

			this.Enfocar();
		}
		private void Enfocar()
		{
			CalFechaCancelacion.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("ddlbSituacion"));
			ddlbSituacion.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("ddlbMoneda"));
			ddlbMoneda.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nMonto"));
			nMonto.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nMontoInteres"));
			nMontoInteres.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nTipoCambio"));
			nTipoCambio.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtConcepto"));			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleCartadeCreditoNotadeCargo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleCartadeCreditoNotadeCargo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleCartadeCreditoNotadeCargo.Exportar implementation
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

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			//Referencia a la Entidad de Negocio
			CartaCreditoNotadeCargoBE oCartaCreditoNotadeCargoBE= new CartaCreditoNotadeCargoBE();
			oCartaCreditoNotadeCargoBE.IdCartaCredito = Convert.ToInt32(Page.Request.Params[KEYIDCARTACREDITO]);
			oCartaCreditoNotadeCargoBE.Periodo = Convert.ToInt32(Page.Request.Params[KEYIDPERIODO]);
			oCartaCreditoNotadeCargoBE.FechaCancelacion = Convert.ToDateTime(this.CalFechaCancelacion.SelectedDate);
			oCartaCreditoNotadeCargoBE.IdTablaestado = Convert.ToInt32(Enumerados.TablasTabla.FinancieraEstadoCartaCreditoNotas);
			oCartaCreditoNotadeCargoBE.IdEstado = Convert.ToInt32(this.ddlbSituacion.SelectedValue);
			oCartaCreditoNotadeCargoBE.IdTablaMoneda = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oCartaCreditoNotadeCargoBE.IdMoneda = Convert.ToInt32(this.ddlbMoneda.SelectedValue);
			oCartaCreditoNotadeCargoBE.Monto = Convert.ToDecimal(this.nMonto.Text);
			oCartaCreditoNotadeCargoBE.MontoInteres = Convert.ToDecimal(this.nMontoInteres.Text);
			oCartaCreditoNotadeCargoBE.TipoCambio = Convert.ToDecimal(this.nTipoCambio.Text);
			oCartaCreditoNotadeCargoBE.Concepto = Convert.ToString(this.txtConcepto.Text);
			oCartaCreditoNotadeCargoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			if(((CCartaCreditoNotadeCargo) new CCartaCreditoNotadeCargo()).Insertar(oCartaCreditoNotadeCargoBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Carta de Credito",this.ToString(),"Se registró una nota de cargo" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJESECONFIRMACIONNOTADECARGOREGISTRO));
			}					
		}

		public void Modificar()
		{
			CartaCreditoNotadeCargoBE oCartaCreditoNotadeCargoBE= new CartaCreditoNotadeCargoBE();
			oCartaCreditoNotadeCargoBE.IdNotaCredito= Convert.ToInt32(Page.Request.Params[KEYIDNOTACREDITO]);
			oCartaCreditoNotadeCargoBE.IdCartaCredito = Convert.ToInt32(Page.Request.Params[KEYIDCARTACREDITO]);
			oCartaCreditoNotadeCargoBE.Periodo = Convert.ToInt32(Page.Request.Params[KEYIDPERIODO]);
			oCartaCreditoNotadeCargoBE.FechaCancelacion = Convert.ToDateTime(this.CalFechaCancelacion.SelectedDate);
			oCartaCreditoNotadeCargoBE.IdTablaestado = Convert.ToInt32(Enumerados.TablasTabla.FinancieraEstadoCartaCreditoNotas);
			oCartaCreditoNotadeCargoBE.IdEstado = Convert.ToInt32(this.ddlbSituacion.SelectedValue);
			oCartaCreditoNotadeCargoBE.IdTablaMoneda = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oCartaCreditoNotadeCargoBE.IdMoneda = Convert.ToInt32(this.ddlbMoneda.SelectedValue);
			oCartaCreditoNotadeCargoBE.Monto = Convert.ToDecimal(this.nMonto.Text);
			oCartaCreditoNotadeCargoBE.MontoInteres = Convert.ToDecimal(this.nMontoInteres.Text);
			oCartaCreditoNotadeCargoBE.TipoCambio = Convert.ToDecimal(this.nTipoCambio.Text);
			oCartaCreditoNotadeCargoBE.Concepto = Convert.ToString(this.txtConcepto.Text);
			oCartaCreditoNotadeCargoBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			if(((CCartaCreditoNotadeCargo) new CCartaCreditoNotadeCargo()).Modificar(oCartaCreditoNotadeCargoBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Carta de Credito",this.ToString(),"Se modificó una nota de cargo" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));				
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJESECONFIRMACIONNOTADECARGOMODIFICACION));
			}								
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleCartadeCreditoNotadeCargo.Eliminar implementation
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
			((ListItem) this.ddlbMoneda.Items.FindByText(Page.Request.Params[KEYIDMONEDA].ToString())).Selected=true;
		}

		public void CargarModoModificar()
		{
			CCartaCreditoNotadeCargo oCCartaCreditoNotadeCargo = new CCartaCreditoNotadeCargo();
			
			CartaCreditoNotadeCargoBE oCartaCreditoNotadeCargoBE = (CartaCreditoNotadeCargoBE)
				oCCartaCreditoNotadeCargo.DetalleCartaCreditoNotadeCargoBE(Convert.ToInt32(Page.Request.Params[KEYIDNOTACREDITO]),
																			Convert.ToInt32(Page.Request.Params[KEYIDCARTACREDITO]),
																			Convert.ToInt32(Page.Request.Params[KEYIDPERIODO]));			

			this.CalFechaCancelacion.SelectedDate = Convert.ToDateTime(oCartaCreditoNotadeCargoBE.FechaCancelacion);
			this.nMonto.Text = oCartaCreditoNotadeCargoBE.Monto.ToString();
			this.nMontoInteres.Text = oCartaCreditoNotadeCargoBE.MontoInteres.ToString();
			this.nTipoCambio.Text = oCartaCreditoNotadeCargoBE.TipoCambio.ToString();
			this.txtConcepto.Text = oCartaCreditoNotadeCargoBE.Concepto.ToString();
			ListItem item;
			item = this.ddlbSituacion.Items.FindByValue(oCartaCreditoNotadeCargoBE.IdEstado.ToString());
			if(item!=null)
			{item.Selected = true;}
			item = this.ddlbMoneda.Items.FindByValue(oCartaCreditoNotadeCargoBE.IdMoneda.ToString());
			if(item!=null)
			{item.Selected = true;}				
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleCartadeCreditoNotadeCargo.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleCartadeCreditoNotadeCargo.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleCartadeCreditoNotadeCargo.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleCartadeCreditoNotadeCargo.ValidarExpresionesRegulares implementation
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
