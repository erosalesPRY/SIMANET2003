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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.EntidadesNegocio.GestionEstrategica.PlanEstrategico;

namespace SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico
{
	/// <summary>
	/// Summary description for DetallePlanEstrategicoAnoInversion.
	/// </summary>
	public class DetallePlanEstrategicoAnoInversion : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCargoLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAreaLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonalLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreLider;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblNombrePlanBase;
		protected System.Web.UI.WebControls.Label lblObjGral;
		protected System.Web.UI.WebControls.Label lblNombreObjGral;
		protected System.Web.UI.WebControls.Label lblObjEsp;
		protected System.Web.UI.WebControls.Label lblNombreObjEsp;
		protected System.Web.UI.WebControls.Label lblAccion;
		protected System.Web.UI.WebControls.Label lblNombreAccion;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label5;
		protected eWorld.UI.NumericBox txtAnoInversion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvAnoInversion;
		protected System.Web.UI.WebControls.Label lblCO;
		protected eWorld.UI.NumericBox txtInversion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvInversion;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblActividad;
		protected System.Web.UI.WebControls.Label lblNombreActividad;
		protected System.Web.UI.HtmlControls.HtmlTable Table8;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras;
		#endregion
	
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO AÑO DE INVERSIÓN";
		const string TITULOMODOMODIFICAR = "MODIFICAR AÑO DE INVERSIÓN";
		const string TITULOMODOCONSULTAR = "CONSULTAR AÑO DE INVERSIÓN";

		//Key Session y QueryString
		const string NOMBREPLANBASE  = "PLEstrNombre";
		const string NOMBREOBJGRAL   = "ObjGenNombre";
		const string NOMBREOBJESP    = "idObjEspNombre";
		const string NOMBREACCION    = "ACCION";
		const string NOMBREACTIVIDAD = "ACTIVIDAD";

		const string KEYIDOBJGRAL    = "idObjGen";
		const string KEYIDOBJESP     = "idObjEsp";
		const string KEYIDACCION     = "IdAccion";
		const string KEYIDACTIVIDAD  = "IdActividad";
		const string KEYIDANOINV     = "IdAnoInversion";
		const string KEYIDGRUPOCC    = "IdGrupoCC";

		const string KEYCODOBJGRAL   = "CodObjGen";
		const string KEYCODOBJESP    = "CodObjEsp";
		const string KEYCODACCION    = "CodAccion";
		const string KEYCODACTIVIDAD = "CodActividad";

		const string KEYIDCO    = "idCentro";
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label6;
	
		//Paginas
		
		#endregion Constantes		

		#region Variables
		private ListItem item = new ListItem();
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
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
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetallePlanEstrategicoAnoInversion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePlanEstrategicoAnoInversion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePlanEstrategicoAnoInversion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetallePlanEstrategicoAnoInversion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePlanEstrategicoAnoInversion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvAnoInversion.ErrorMessage = "Debe Ingresar el Año de la Inversión";
			rfvAnoInversion.ToolTip = rfvAnoInversion.ErrorMessage;

			rfvInversion.ErrorMessage = "Debe Ingresar el Monto de la Inversión";
			rfvInversion.ToolTip = rfvInversion.ErrorMessage;
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePlanEstrategicoAnoInversion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePlanEstrategicoAnoInversion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePlanEstrategicoAnoInversion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetallePlanEstrategicoAnoInversion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetallePlanEstrategicoAnoInversion.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			PEAnoInversionBE oPEAnoInversionBE = new PEAnoInversionBE();
			oPEAnoInversionBE.IDACTIVIDAD = Convert.ToInt32(Page.Request.QueryString[KEYIDACTIVIDAD]);
			oPEAnoInversionBE.ANO = Convert.ToInt32(txtAnoInversion.Text);
			oPEAnoInversionBE.INVERSION = Convert.ToDouble(txtInversion.Text);

			oPEAnoInversionBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.TablaPEANOINVERSION);
			oPEAnoInversionBE.IdEstado = Convert.ToInt32(Enumerados.EstadosPEANOINVERSION.Activo);

			oPEAnoInversionBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			if (Convert.ToInt32((new CMantenimientos()).Insertar(oPEAnoInversionBE))>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Año Inversión",this.ToString(),"Se registró Item de Año de Inversión" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));								
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Modificar()
		{
			PEAnoInversionBE oPEAnoInversionBE = new PEAnoInversionBE();
			oPEAnoInversionBE.IDANOINVERSION = Convert.ToInt32(Page.Request.QueryString[KEYIDANOINV]);
			oPEAnoInversionBE.IDACTIVIDAD = Convert.ToInt32(Page.Request.QueryString[KEYIDACTIVIDAD]);
			oPEAnoInversionBE.ANO = Convert.ToInt32(txtAnoInversion.Text);
			oPEAnoInversionBE.INVERSION = Convert.ToDouble(txtInversion.Text);

			oPEAnoInversionBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			if (Convert.ToInt32((new CMantenimientos()).Modificar(oPEAnoInversionBE))>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Año Inversión",this.ToString(),"Se modificó Item de Año de Inversión" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePlanEstrategicoAnoInversion.Eliminar implementation
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
					this.CargarModoConsulta();
					break;
			}
		}

		public void CargarModoNuevo()
		{
			this.lblTitulo.Text = TITULOMODONUEVO;
			this.LlenarTitulos();
		}

		public void CargarDatos()
		{
			this.LlenarTitulos();
			PEAnoInversionBE oPEAnoInversionBE = (PEAnoInversionBE)(new CMantenimientos()).ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYIDANOINV].ToString()), Enumerados.ClasesNTAD.PEAnoInversionNTAD.ToString());
			txtAnoInversion.Text = Convert.ToString(oPEAnoInversionBE.ANO);
			txtInversion.Text = Convert.ToString(oPEAnoInversionBE.INVERSION);
		}

		public void CargarModoModificar()
		{
			this.lblTitulo.Text = TITULOMODOMODIFICAR;
			this.CargarDatos();
			this.ibtnAtras.Visible = false;
		}

		public void CargarModoConsulta()
		{
			this.lblTitulo.Text = TITULOMODOCONSULTAR;
			this.CargarDatos();
			Helper.BloquearControles(this);
			this.Table8.Visible = false;
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetallePlanEstrategicoAnoInversion.ValidarCampos implementation
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(txtAnoInversion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(rfvAnoInversion.ErrorMessage);
				return false;
			}

			if(txtInversion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(rfvInversion.ErrorMessage);
				return false;
			}

			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetallePlanEstrategicoAnoInversion.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void LlenarTitulos()
		{
			this.lblObjGral.Text   = Page.Request.QueryString[KEYCODOBJGRAL];
			this.lblObjEsp.Text    = Page.Request.QueryString[KEYCODOBJESP];
			this.lblAccion.Text    = Page.Request.QueryString[KEYCODACCION];
			this.lblActividad.Text = Page.Request.QueryString[KEYCODACTIVIDAD];

			this.lblNombrePlanBase.Text = Page.Request.QueryString[NOMBREPLANBASE];
			this.lblNombreObjGral.Text  = Page.Request.QueryString[NOMBREOBJGRAL];
			this.lblNombreObjEsp.Text   = Page.Request.QueryString[NOMBREOBJESP];
			this.lblNombreAccion.Text   = Page.Request.QueryString[NOMBREACCION];
			this.lblNombreActividad.Text = Page.Request.QueryString[NOMBREACTIVIDAD];
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

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

	}
}
