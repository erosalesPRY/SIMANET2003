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
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	/// <summary>
	/// Summary description for GrabarFormatoRubroDetalleMovimiento.
	/// </summary>
	

	public class GrabarFormatoRubroDetalleMovimiento : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		#region Constantes
		const string PARAMETROMODO ="Modo";
		const string PARAMETROMONTO ="Monto";
		const string PARAMETROIDMES ="idMes";
		const string PARAMETROPERIODO ="Periodo";
		const string PARAMETROCENTRO ="Centro";
		const string PARAMETROIDRUBRODETALLE ="IdRubroDetalle";
		const string PARAMETROTIPOINFO ="TipoInfo";

		const int IDTABLAESTADOTIPOINFORMACION =119;
		
		#endregion Constantes


		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();					
					this.GrabarDatos();
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
		private void GrabarDatos()
		{			
			if (Page.Request.Params[PARAMETROMODO].ToString()== Utilitario.Enumerados.ModoPagina.N.ToString() /*"N"*/)
			{
				this.Agregar();
			}
			else if (Page.Request.Params[PARAMETROMODO].ToString()== Utilitario.Enumerados.ModoPagina.M.ToString() /*"M"*/)
			{
				this.Modificar();
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
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.Exportar implementation
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
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			FormatoRubroDetalleMovimientoBE oFormatoRubroDetalleMovimientoBE = new FormatoRubroDetalleMovimientoBE();

			oFormatoRubroDetalleMovimientoBE.Monto = Convert.ToDouble(Page.Request.Params[PARAMETROMONTO].ToString().Trim());
			oFormatoRubroDetalleMovimientoBE.Descripcion =String.Empty;
			oFormatoRubroDetalleMovimientoBE.IdMes = Convert.ToInt32(Page.Request.Params[PARAMETROIDMES]);
			oFormatoRubroDetalleMovimientoBE.Periodo = Convert.ToInt32(Page.Request.Params[PARAMETROPERIODO]);
			oFormatoRubroDetalleMovimientoBE.IdCentroOperativo = Convert.ToInt32(Page.Request.Params[PARAMETROCENTRO]);
			oFormatoRubroDetalleMovimientoBE.IdRubroDetalle = Convert.ToInt32(Page.Request.Params[PARAMETROIDRUBRODETALLE]);
			oFormatoRubroDetalleMovimientoBE.IdTablaTipoInformacion = IDTABLAESTADOTIPOINFORMACION;
			oFormatoRubroDetalleMovimientoBE.IdTipoInformacion = Convert.ToInt32(Page.Request.Params[PARAMETROTIPOINFO]);
			oFormatoRubroDetalleMovimientoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			CFormatoRubroDetalleMovimiento oCFormatoRubroDetalleMovimiento = new CFormatoRubroDetalleMovimiento();
			oCFormatoRubroDetalleMovimiento.Insertar(oFormatoRubroDetalleMovimientoBE);
		}
		public void Modificar()
		{
			FormatoRubroDetalleMovimientoBE oFormatoRubroDetalleMovimientoBE = new FormatoRubroDetalleMovimientoBE();
			oFormatoRubroDetalleMovimientoBE.IdRubroDetalleMovimiento = Convert.ToInt32(Page.Request.Params["idRubroMovimiento"]);
			oFormatoRubroDetalleMovimientoBE.Monto = Convert.ToDouble(Page.Request.Params[PARAMETROMONTO].ToString().Trim());
			oFormatoRubroDetalleMovimientoBE.Descripcion =String.Empty;
			oFormatoRubroDetalleMovimientoBE.IdMes = Convert.ToInt32(Page.Request.Params[PARAMETROIDMES]);
			oFormatoRubroDetalleMovimientoBE.Periodo = Convert.ToInt32(Page.Request.Params[PARAMETROPERIODO]);
			oFormatoRubroDetalleMovimientoBE.IdCentroOperativo = Convert.ToInt32(Page.Request.Params[PARAMETROCENTRO]);
			oFormatoRubroDetalleMovimientoBE.IdRubroDetalle = Convert.ToInt32(Page.Request.Params[PARAMETROIDRUBRODETALLE]);
			oFormatoRubroDetalleMovimientoBE.IdTablaTipoInformacion = IDTABLAESTADOTIPOINFORMACION;
			oFormatoRubroDetalleMovimientoBE.IdTipoInformacion = Convert.ToInt32(Page.Request.Params[PARAMETROTIPOINFO]);
			oFormatoRubroDetalleMovimientoBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			CFormatoRubroDetalleMovimiento oCFormatoRubroDetalleMovimiento = new CFormatoRubroDetalleMovimiento();
			oCFormatoRubroDetalleMovimiento.Modificar(oFormatoRubroDetalleMovimientoBE);
		}

		public void Eliminar()
		{
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add GrabarFormatoRubroDetalleMovimiento.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	}
}
