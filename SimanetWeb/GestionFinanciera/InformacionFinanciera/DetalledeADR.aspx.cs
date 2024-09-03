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
	/// Summary description for DetalledeADR.
	/// </summary>
	public class DetalledeADR : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string URLPRINCIPAL="AdminsitraciondeADR.aspx";

		const string KEYIDSTRFECHA = "strFecha";
		const string KEYIDFECHA = "Fecha";
		const string KEYIDENTIDADOTROS ="idEntidad";
		const string KEYENTIDADOTROSNOMBRE ="EntidadNombre";
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblResultado;
		private   ListItem item =  new ListItem();
		protected eWorld.UI.NumericBox nPorcCierre;
		protected eWorld.UI.NumericBox nPorcVar;
		protected eWorld.UI.NumericBox nPorcVolAcc;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rdvPorcCierre;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rdvPorcVar;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rdvVolacc;
		protected System.Web.UI.WebControls.Label lblEntidad;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label lblTitulo;
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
			this.nPorcVolAcc.TextChanged += new System.EventHandler(this.nPorcVolAcc_TextChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.ibtnCancelar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalledeADR.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalledeADR.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalledeADR.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
		}

		public void LlenarDatos()
		{
			this.lblFecha.Text = Page.Request.Params[KEYIDFECHA].ToString().Replace(Utilitario.Constantes.SEPARADORFECHA,Utilitario.Constantes.SIGNOMENOS);
			this.lblEntidad.Text= Page.Request.Params[KEYENTIDADOTROSNOMBRE].ToString();
		}

		public void LlenarJScript()
		{
			rdvPorcCierre.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEADRCAMPOREQUERIDOPORCCIERRE);
			rdvPorcCierre.ToolTip=rdvPorcCierre.ErrorMessage;
			rdvPorcVar.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEADRCAMPOREQUERIDOPORCVAR);
			rdvPorcVar.ToolTip=rdvPorcVar.ErrorMessage;
			rdvVolacc.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEADRCAMPOREQUERIDOVOLACC);
			rdvVolacc.ToolTip=rdvVolacc.ErrorMessage;
			// TODO:  Add DetalledeADR.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalledeADR.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalledeADR.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalledeADR.Exportar implementation
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
			// TODO:  Add DetalledeADR.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			ADRBE oADRBE = new ADRBE();
			oADRBE.Fecha = Convert.ToDateTime(Page.Request.Params[KEYIDFECHA]);
			oADRBE.Identidadotros = Convert.ToInt32(Page.Request.Params[KEYIDENTIDADOTROS]);
			oADRBE.Porccierre = Convert.ToDecimal(this.nPorcCierre.Text);
			oADRBE.Porcvariacion = Convert.ToDecimal(this.nPorcVar.Text);
			oADRBE.Porcvolacc = Convert.ToDecimal(this.nPorcVolAcc.Text);
			oADRBE.Idtablaestado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoADRS);
			oADRBE.Idestado = Utilitario.Constantes.IDESTADODEFAULT;
			oADRBE.Idusuarioregistro = CNetAccessControl.GetIdUser();
			
			if(((CAdrs)new CAdrs()).Insertar(oADRBE)> Utilitario.Constantes.ValorConstanteCero)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName()
														,"GestionFinanciera"
														,this.ToString()
														,"Se Inserto Item de " + "oADRBE"
														,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}

			// TODO:  Add DetalledeADR.Agregar implementation
		}

		public void Modificar()
		{
			ADRBE oADRBE = new ADRBE();
			oADRBE.Fecha = Convert.ToDateTime(Page.Request.Params[KEYIDFECHA]);
			oADRBE.Identidadotros = Convert.ToInt32(Page.Request.Params[KEYIDENTIDADOTROS]);
			oADRBE.Porccierre = Convert.ToDecimal(this.nPorcCierre.Text);
			oADRBE.Porcvariacion = Convert.ToDecimal(this.nPorcVar.Text);
			oADRBE.Porcvolacc = Convert.ToDecimal(this.nPorcVolAcc.Text);
			oADRBE.Idusuarioactualizacion = CNetAccessControl.GetIdUser();

			if(((CAdrs)new CAdrs()).Modificar(oADRBE)> Utilitario.Constantes.ValorConstanteCero)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName()
														,"GestionFinanciera"
														,this.ToString()
														,"Se modificó Item de " + "oADRBE"
														,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
			
			// TODO:  Add DetalledeADR.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DetalledeADR.Eliminar implementation
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
			// TODO:  Add DetalledeADR.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalledeADR.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			ADRBE oADRBE = (ADRBE)((CAdrs) new CAdrs()).DetalleADRS(Page.Request.Params[KEYIDSTRFECHA].ToString()
																	,Convert.ToInt32(Page.Request.Params[KEYIDENTIDADOTROS])
																	,1);

			this.nPorcCierre.Text = Convert.ToString(oADRBE.Porccierre);
			this.nPorcVar.Text = Convert.ToString(oADRBE.Porcvariacion);
			this.nPorcVolAcc.Text = Convert.ToString(oADRBE.Porcvolacc);
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalledeADR.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalledeADR.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalledeADR.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalledeADR.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.RedireccionaPaginaPrincipal();
		}
		private void RedireccionaPaginaPrincipal()
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
				ltlMensaje.Text =  Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());
			}
			catch(Exception oException)
			{
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}						
		}

		private void nPorcVolAcc_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
