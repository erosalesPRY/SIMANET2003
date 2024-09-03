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

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	public class DetalledeMovimientoporConcepto : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		//Key Session y QueryString
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDRUBRO= "IdRubro";
		const string KEYQRUBRONOMBRE= "RubroNombre";
		const string KEYQIDCENTRO = "IdCentro";
		const string KEYQIDTIPOINFO= "idTipoInfo";
		const string KEYQPERIODO= "Periodo";
		const string KEYQMES= "IdMes";
		const string KEYIDRUBRODETALLE= "idrDetalle";

		const string GRILLAVACIA="No existe";

		const string ETIQUETAFORMATO ="FORMATO :";
		const string ETIQUETACONCEPTO ="CONCEPTO :";

		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblObservacion;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.WebControls.Label Label1;
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
			// TODO:  Add DetalledeMovimientoporConcepto.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalledeMovimientoporConcepto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalledeMovimientoporConcepto.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalledeMovimientoporConcepto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.Label1.Text = ETIQUETACONCEPTO + Page.Request.Params[KEYQRUBRONOMBRE].ToString().ToUpper();
		}

		public void LlenarJScript()
		{
			// TODO:  Add DetalledeMovimientoporConcepto.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalledeMovimientoporConcepto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalledeMovimientoporConcepto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalledeMovimientoporConcepto.Exportar implementation
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
			// TODO:  Add DetalledeMovimientoporConcepto.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			FormatoRubroDetalleBE oFormatoRubroDetalleBE = new FormatoRubroDetalleBE();
			oFormatoRubroDetalleBE.IdFormato = Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
			oFormatoRubroDetalleBE.IdRubro = Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]);
			oFormatoRubroDetalleBE.Descripcion= this.txtDescripcion.Text;
			oFormatoRubroDetalleBE.Idusuarioregistro = CNetAccessControl.GetIdUser();
			oFormatoRubroDetalleBE.Idtablaestado= Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoFormatoRubroDetalle);
			oFormatoRubroDetalleBE.Idestado= Utilitario.Constantes.IDESTADODEFAULT;
			if(((CFormatoRubroDetalle) new CFormatoRubroDetalle()).Insertar(oFormatoRubroDetalleBE) > 0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Detalle formato Rubro Movimiento",this.ToString(),"Se registró Item de Detalle formato Rubro Movimiento" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				//ltlMensaje.Text = Helper.MensajeRetornoAlert();
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Utilitario.Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(), Mensajes.CODIGOMENSAJECONFIRMACIONESTADOFINANCERODETMOVCONCEPTOREGISTRO));				
			}
		}

		public void Modificar()
		{
			FormatoRubroDetalleBE oFormatoRubroDetalleBE = new FormatoRubroDetalleBE();
			oFormatoRubroDetalleBE.IdRubroDetalle = Convert.ToInt32(Page.Request.Params[KEYIDRUBRODETALLE]);
			oFormatoRubroDetalleBE.Descripcion= this.txtDescripcion.Text;
			oFormatoRubroDetalleBE.Idusuarioactualizacion = CNetAccessControl.GetIdUser();
			oFormatoRubroDetalleBE.Idtablaestado= Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoFormatoRubroDetalle);
			oFormatoRubroDetalleBE.Idestado= Utilitario.Constantes.IDESTADODEFAULT;
			if(((CFormatoRubroDetalle) new CFormatoRubroDetalle()).Modificar(oFormatoRubroDetalleBE) > 0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Detalle formato Rubro Movimiento",this.ToString(),"Se modificó Item de Detalle formato Rubro Movimiento" + ".",Enumerados.NivelesErrorLog.I.ToString()));
				//ltlMensaje.Text = Helper.MensajeRetornoAlert();
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Utilitario.Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(), Mensajes.CODIGOMENSAJECONFIRMACIONESTADOFINANCERODETMOVCONCEPTOMODIFICACION));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalledeMovimientoporConcepto.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			//CalFechaVencimiento.SelectedDate = DateTime.Now.Date;
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
		}

		public void CargarModoNuevo()
		{
			
		}

		public void CargarModoModificar()
		{
			FormatoRubroDetalleBE oFormatoRubroDetalleBE = (FormatoRubroDetalleBE)	((CFormatoRubroDetalle) new CFormatoRubroDetalle()).DetalleFormatoRubroDetalle(
				Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO])
				,Convert.ToInt32(Page.Request.Params[KEYQPERIODO])
				,Convert.ToInt32(Page.Request.Params[KEYQMES])
				,Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO])
				,Convert.ToInt32(Page.Request.Params[KEYIDRUBRODETALLE]));

			this.txtDescripcion.Text = oFormatoRubroDetalleBE.Descripcion.ToString();

		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalledeMovimientoporConcepto.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalledeMovimientoporConcepto.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalledeMovimientoporConcepto.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalledeMovimientoporConcepto.ValidarExpresionesRegulares implementation
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
	}
}
