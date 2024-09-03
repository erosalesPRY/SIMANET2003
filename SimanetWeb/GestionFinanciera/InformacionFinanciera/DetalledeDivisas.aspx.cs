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

namespace SIMA.SimaNetWeb.GestionFinanciera.InformacionFinanciera
{
	/// <summary>
	/// Summary description for DetalledeDivisas.
	/// </summary>
	public class DetalledeDivisas : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string URLPRINCIPAL="AdminsitraciondeDivisas.aspx";

		const string KEYIDFECHA = "Fecha";
		const string KEYIDSTRFECHA = "strFecha";
		
		const string KEYIDTIPODIVISA ="TIPODIVISA";
		const string KEYIDDIVISANOMBRE ="DivisaNombre";
		const string KEYIDDIVISA ="IDDIVISA";
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected eWorld.UI.NumericBox nMontoCompra;
		protected eWorld.UI.NumericBox nMontoVenta;
		protected eWorld.UI.NumericBox nVolAccion;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rdvMontoCompra;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rdvMontoVenta;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rdvVolAccion;
		protected System.Web.UI.WebControls.Label lblDivisa;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label lblTitulo;
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
			this.ibtnCancelar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalledeDivisas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalledeDivisas.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalledeDivisas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{}

		public void LlenarDatos()
		{
			this.lblFecha.Text = Page.Request.Params[KEYIDFECHA].ToString().Replace(Utilitario.Constantes.SEPARADORFECHA,Utilitario.Constantes.SIGNOMENOS);;
			this.lblDivisa.Text = Page.Request.Params[KEYIDDIVISANOMBRE].ToString();

			// TODO:  Add DetalledeDivisas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rdvMontoCompra.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEDIVISASCAMPOREQUERIDOMONTOCOMPRA);
			rdvMontoCompra.ToolTip = rdvMontoCompra.ErrorMessage;
			rdvMontoVenta.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEDIVISASCAMPOREQUERIDOMONTOVENTA);
			rdvMontoVenta.ToolTip=rdvMontoVenta.ErrorMessage;
			rdvVolAccion.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEDIVISASCAMPOREQUERIDOVOLACC);
			rdvVolAccion.ToolTip=rdvVolAccion.ErrorMessage;
				// TODO:  Add DetalledeDivisas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalledeDivisas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalledeDivisas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalledeDivisas.Exportar implementation
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
			// TODO:  Add DetalledeDivisas.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			DivisasBE oDivisasBE = new DivisasBE();
			oDivisasBE.Fecha = Convert.ToDateTime(Page.Request.Params[KEYIDFECHA]);
			oDivisasBE.Idtablatipodivisa = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTablaDivisas);
			oDivisasBE.Iddivisa = Convert.ToInt32(Page.Request.Params[KEYIDDIVISA]);
			oDivisasBE.Montocompra = Convert.ToDecimal(this.nMontoCompra.Text);
			oDivisasBE.Montoventa = Convert.ToDecimal(this.nMontoVenta.Text);
			oDivisasBE.VolAcc = Convert.ToDecimal(this.nVolAccion.Text);
			oDivisasBE.Idtablaestado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoDivisas);
			oDivisasBE.Idestado = Utilitario.Constantes.IDESTADODEFAULT;
			oDivisasBE.Idusuarioregistro=CNetAccessControl.GetIdUser();

			if(((CDivisas)new CDivisas()).Insertar(oDivisasBE)> Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName()
														,"GestionFinanciera"
														,this.ToString()
														,"Se Inserto Item de " + "oDivisasBE"
														,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Modificar()
		{
			DivisasBE oDivisasBE = new DivisasBE();
			oDivisasBE.Fecha = Convert.ToDateTime(Page.Request.Params[KEYIDFECHA]);
			oDivisasBE.Idtablatipodivisa = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTablaDivisas);
			oDivisasBE.Iddivisa = Convert.ToInt32(Page.Request.Params[KEYIDDIVISA]);
			oDivisasBE.Montocompra = Convert.ToDecimal(this.nMontoCompra.Text);
			oDivisasBE.Montoventa = Convert.ToDecimal(this.nMontoVenta.Text);
			oDivisasBE.VolAcc = Convert.ToDecimal(this.nVolAccion.Text);
			oDivisasBE.Idusuarioactualizacion=CNetAccessControl.GetIdUser();
			if(((CDivisas) new CDivisas()).Modificar(oDivisasBE)> Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName()
															,"GestionFinanciera"
															,this.ToString()
															,"Se modificó Item de " + "oDivisasBE"
															,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalledeDivisas.Eliminar implementation
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
			}						
			// TODO:  Add DetalledeDivisas.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalledeDivisas.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			CDivisas oCDivisas = new CDivisas();
			DivisasBE oDivisasBE = (DivisasBE)
					oCDivisas.DetalleDivisa(Convert.ToString(Page.Request.Params[KEYIDSTRFECHA])
											,Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTablaDivisas)
											,Convert.ToInt32(Page.Request.Params[KEYIDDIVISA]));
			
			this.nMontoCompra.Text = Convert.ToString(oDivisasBE.Montocompra);
			this.nMontoVenta.Text = Convert.ToString(oDivisasBE.Montoventa);
			this.nVolAccion.Text = Convert.ToString(oDivisasBE.VolAcc);
			// TODO:  Add DetalledeDivisas.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalledeDivisas.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalledeDivisas.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalledeDivisas.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalledeDivisas.ValidarExpresionesRegulares implementation
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
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
			}
			catch(Exception oException)
			{
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}				
			
		}

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.RedirecionaPaginaPrncipal();
		}
		private void RedirecionaPaginaPrncipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}
	}
}
