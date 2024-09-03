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
	/// Summary description for DetalleCotizacionMetales.
	/// </summary>
	public class DetalleCotizacionMetales : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkEntidad";
		const string URLPRINCIPAL="AdministraCotizacionMetales.aspx";
		const string COLORDENAMIENTO = "descripcion";

		const string KEYIDFECHA = "Fecha";
		
		const string KEYIDMETAL = "idMetal";
		const string KEYIDMERCADO = "idMercado";
		const string KEYMETALDESCRIPCION = "Metaldescrip";
		const string KEYMERCADODESCRIPCION = "Mercadodescrip";


		#endregion 
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtUnidadMed;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected eWorld.UI.NumericBox nMonto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rdvMonto;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label lblMetal;
		protected System.Web.UI.WebControls.Label lblMercado;
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
			// TODO:  Add DetalleCotizacionMetales.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleCotizacionMetales.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleCotizacionMetales.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
		}
		public void LlenarDatos()
		{
			this.lblFecha.Text = Page.Request.Params[KEYIDFECHA].ToString().Replace(Utilitario.Constantes.SEPARADORFECHA,Utilitario.Constantes.SIGNOMENOS);;
			this.lblMetal.Text = Page.Request.Params[KEYMETALDESCRIPCION ].ToString();
			this.lblMercado.Text = Page.Request.Params[KEYMERCADODESCRIPCION].ToString();
		}

		public void LlenarJScript()
		{
			rdvMonto.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJECOTIZAMETALCAMPOREQUERIDOMONTO);
			rdvMonto.ToolTip = rdvMonto.ErrorMessage;
			// TODO:  Add DetalleCotizacionMetales.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleCotizacionMetales.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleCotizacionMetales.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleCotizacionMetales.Exportar implementation
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
			// TODO:  Add DetalleCotizacionMetales.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			CotizaMetalesBE oCotizaMetalesBE = new CotizaMetalesBE();
			oCotizaMetalesBE.Fecha=Convert.ToDateTime(Page.Request.Params[KEYIDFECHA]);
			oCotizaMetalesBE.Idtablamercado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraMercados);
			oCotizaMetalesBE.Idmercado = Convert.ToInt32(Page.Request.Params[KEYIDMERCADO]);
			oCotizaMetalesBE.Idtablametales = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraMetales);
			oCotizaMetalesBE.Idmetal = Convert.ToInt32(Page.Request.Params[KEYIDMETAL]);
			oCotizaMetalesBE.Montocotiza = Convert.ToDecimal(this.nMonto.Text);
			oCotizaMetalesBE.Unidaddesc = this.txtUnidadMed.Text;
			oCotizaMetalesBE.Observacion = this.txtObservacion.Text;
			oCotizaMetalesBE.Idusuarioregistro=CNetAccessControl.GetIdUser();
			
			if(((CCotizaMetales) new CCotizaMetales()).Insertar(oCotizaMetalesBE)> Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName()
														,"GestionFinanciera"
														,this.ToString()
														,"Se Ingreso Item de " + "oCotizaMetalesBE",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Modificar()
		{
			/*parametros de Criterios en el Where*/
			CotizaMetalesBE oCotizaMetalesBE = new CotizaMetalesBE();
			oCotizaMetalesBE.Fecha=Convert.ToDateTime(Page.Request.Params[KEYIDFECHA]);
			oCotizaMetalesBE.Idtablamercado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraMercados);
			oCotizaMetalesBE.Idmercado = Convert.ToInt32(Page.Request.Params[KEYIDMERCADO]);
			oCotizaMetalesBE.Idtablametales = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraMetales);
			oCotizaMetalesBE.Idmetal = Convert.ToInt32(Page.Request.Params[KEYIDMETAL]);
			/*Datos a Ser Actualizados*/
			//oCotizaMetalesBE.Idmercado = Convert.ToInt32(Page.Request.Params[KEYIDMERCADO]);
			//oCotizaMetalesBE.Idmetal = Convert.ToInt32(Page.Request.Params[KEYIDMETAL]);
			oCotizaMetalesBE.Montocotiza = Convert.ToDecimal(this.nMonto.Text);
			oCotizaMetalesBE.Unidaddesc = this.txtUnidadMed.Text;
			oCotizaMetalesBE.Observacion = this.txtObservacion.Text;
			oCotizaMetalesBE.Idusuarioactualizacion=CNetAccessControl.GetIdUser();
			if(((CCotizaMetales) new CCotizaMetales()).Modificar(oCotizaMetalesBE)> Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName()
														,"GestionFinanciera"
														,this.ToString()
														,"Se modificó Item de " + "oCotizaMetalesBE",Enumerados.NivelesErrorLog.I.ToString()));
				//ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONCOTIZAMETAL),strUrlGoBack.ToString());
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleCotizacionMetales.Eliminar implementation
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
			// TODO:  Add DetalleCotizacionMetales.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalleCotizacionMetales.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{			
			CCotizaMetales oCCotizaMetales = new CCotizaMetales();

			CotizaMetalesBE oCotizaMetalesBE = (CotizaMetalesBE)
				oCCotizaMetales.DetalleCotizaMetales(Convert.ToDateTime(Page.Request.Params[KEYIDFECHA])
				,Convert.ToInt32(Page.Request.Params[KEYIDMERCADO])
				,Convert.ToInt32(Page.Request.Params[KEYIDMETAL]));
						
			this.txtObservacion.Text=oCotizaMetalesBE.Observacion.ToString();
			this.txtUnidadMed.Text=oCotizaMetalesBE.Unidaddesc.ToString();
			this.nMonto.Text = Convert.ToString(oCotizaMetalesBE.Montocotiza);			
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleCotizacionMetales.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleCotizacionMetales.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleCotizacionMetales.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleCotizacionMetales.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.RedirecionaPaginaPrincipal();
		}
		private void RedirecionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

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
