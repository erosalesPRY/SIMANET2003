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
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio.GestionControlInstitucional;

namespace SIMA.SimaNetWeb.GestionComercial.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class DetalleAccionControlPosteriorEjecucion: System.Web.UI.Page, IPaginaMantenimento, IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblAccionCtrlPosterior;
		protected System.Web.UI.WebControls.TextBox txtAccionCtrlPosterior;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarAccionCtrlPosterior;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvAccionCtrlPosterior;
		protected System.Web.UI.WebControls.Label lblMetaProgramada;
		protected eWorld.UI.NumericBox nbMetaProgramada;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMetaProgramada;
		protected System.Web.UI.WebControls.Label lblEstadoCtrl;
		protected System.Web.UI.WebControls.DropDownList ddlbEstadoCtrl;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvEstadoCtrl;
		protected System.Web.UI.WebControls.Label lblEtapa;
		protected System.Web.UI.WebControls.DropDownList ddlbEtapa;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvEtapa;
		protected System.Web.UI.WebControls.Label lblPorcentajeAvanceTotal;
		protected eWorld.UI.NumericBox nbPorcentajeAvanceTotal;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPorcentajeAvanceTotal;
		protected System.Web.UI.WebControls.Label lblFechaInicio;
		protected eWorld.UI.CalendarPopup calFechaInicio;
		protected System.Web.UI.WebControls.Label lblFechaTermino;
		protected eWorld.UI.CalendarPopup calFechaTermino;
		protected System.Web.UI.WebControls.Label lblNroRealIntegrantesOCI;
		protected eWorld.UI.NumericBox nbNroRealIntegrantesOCI;
		protected System.Web.UI.WebControls.Label lblNroRealIntegrantesEspecialistas;
		protected eWorld.UI.NumericBox nbNroRealIntegrantesEspecialistas;
		protected System.Web.UI.WebControls.Label lblCostoRealOCI;
		protected eWorld.UI.NumericBox nbCostoRealOCI;
		protected System.Web.UI.WebControls.Label lblCostoRealEspecialistas;
		protected eWorld.UI.NumericBox nbCostoRealEspecialistas;
		protected System.Web.UI.WebControls.Label lblNumeroRealHH;
		protected eWorld.UI.NumericBox nbNumeroRealHH;
		protected System.Web.UI.WebControls.Label lblMontoExaminado;
		protected eWorld.UI.NumericBox nbMontoExaminado;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbEstadoCtrl;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbEtapa;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAccionControlPosterior;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#endregion Controles
		
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA EJECUCION DE ACCION DE CONTROL POSTERIOR";
		const string TITULOMODOMODIFICAR = "ACTUALIZACION DE EJECUCION DE ACCION DE CONTROL POSTERIOR";
		const string TITULOMODOCONSULTA = "DETALLE DE EJECUCION DE ACCION DE CONTROL POSTERIOR";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQPRG = "Prg";
		const string KEYQTIT = "Titulo";
	
		//Paginas
		const string URLPRINCIPAL = "AdministracionAccionControlPosteriorEjecucion.aspx?";
		const string URLBUSQUEDAACCIONCONTROL = "BusquedaAccionControl.aspx?";
		
		#endregion Constantes				
		
		#region Variables
		ListItem  lItem ;
		#endregion Variables		
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					
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
			this.ibtnCancelar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			AccionCtrlPosteriorEjecBE oAccionCtrlPosteriorEjecBE = new AccionCtrlPosteriorEjecBE();
			oAccionCtrlPosteriorEjecBE.IdAccionCtrlPosterior = Convert.ToInt32(this.hIdAccionControlPosterior.Value);
			oAccionCtrlPosteriorEjecBE.MetaProgramada = Convert.ToDouble(this.nbMetaProgramada.Text);
			oAccionCtrlPosteriorEjecBE.IdTablaEstadoCtrl = Convert.ToInt32(Enumerados.TablasTabla.EstadosControl);
			oAccionCtrlPosteriorEjecBE.IdEstadoCtrl = Convert.ToInt32(this.ddlbEstadoCtrl.SelectedValue);
			oAccionCtrlPosteriorEjecBE.IdTablaEtapa = Convert.ToInt32(Enumerados.TablasTabla.EtapasControl);
			oAccionCtrlPosteriorEjecBE.IdEtapa = Convert.ToInt32(this.ddlbEtapa.SelectedValue);
			oAccionCtrlPosteriorEjecBE.PorcentajeAvanceTotal = Convert.ToDouble(this.nbPorcentajeAvanceTotal.Text);
			oAccionCtrlPosteriorEjecBE.FechaInicio = this.calFechaInicio.SelectedDate;

			if(!this.calFechaTermino.SelectedDate.Equals(DateTime.MinValue))
			{
				oAccionCtrlPosteriorEjecBE.FechaTermino = this.calFechaTermino.SelectedDate;
			}
			if(this.nbNroRealIntegrantesOCI.Text != String.Empty)
			{
				oAccionCtrlPosteriorEjecBE.NroRealIntegrantesOCI = Convert.ToInt32(this.nbNroRealIntegrantesOCI.Text);
			}
			if(this.nbNroRealIntegrantesEspecialistas.Text != String.Empty)
			{
				oAccionCtrlPosteriorEjecBE.NroRealIntegrantesEspecialistas = Convert.ToInt32(this.nbNroRealIntegrantesEspecialistas.Text);
			}
			if(this.nbCostoRealOCI.Text != String.Empty)
			{
				oAccionCtrlPosteriorEjecBE.CostoRealOCI = Convert.ToDouble(this.nbCostoRealOCI.Text);
			}
			if(this.nbCostoRealEspecialistas.Text != String.Empty)
			{
				oAccionCtrlPosteriorEjecBE.CostoRealEspecialistas = Convert.ToDouble(this.nbCostoRealEspecialistas.Text);
			}
			if(this.nbNumeroRealHH.Text != String.Empty)
			{
				oAccionCtrlPosteriorEjecBE.NumeroRealHH = Convert.ToDouble(this.nbNumeroRealHH.Text);
			}
			if(this.nbMontoExaminado.Text != String.Empty)
			{
				oAccionCtrlPosteriorEjecBE.MontoExaminado = Convert.ToDouble(this.nbMontoExaminado.Text);
			}
			if(this.txtObservaciones.Text != String.Empty)
			{
				oAccionCtrlPosteriorEjecBE.Observaciones = this.txtObservaciones.Text;
			}
			oAccionCtrlPosteriorEjecBE.IdEstado = Convert.ToInt32(Enumerados.EstadoAccionControlPosteriorEjecucion.Activo);
			oAccionCtrlPosteriorEjecBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoAccionControlPosteriorEjecucion);
			oAccionCtrlPosteriorEjecBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oAccionCtrlPosteriorEjecBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Control Institucional",this.ToString(),"Se registró la Ejecucion de Accion de Control Posterior Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROACCIONCTRLPOSTERIOREJEC),URLPRINCIPAL + KEYQPRG + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQPRG].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQTIT + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQTIT].ToString());
			}
		}

		public void Modificar()
		{
			AccionCtrlPosteriorEjecBE oAccionCtrlPosteriorEjecBE = new AccionCtrlPosteriorEjecBE();
			oAccionCtrlPosteriorEjecBE.IdAccionCtrlPosteriorEjec = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oAccionCtrlPosteriorEjecBE.IdAccionCtrlPosterior = Convert.ToInt32(this.hIdAccionControlPosterior.Value);
			oAccionCtrlPosteriorEjecBE.MetaProgramada = Convert.ToDouble(this.nbMetaProgramada.Text);
			oAccionCtrlPosteriorEjecBE.IdTablaEstadoCtrl = Convert.ToInt32(Enumerados.TablasTabla.EstadosControl);
			oAccionCtrlPosteriorEjecBE.IdEstadoCtrl = Convert.ToInt32(this.ddlbEstadoCtrl.SelectedValue);
			oAccionCtrlPosteriorEjecBE.IdTablaEtapa = Convert.ToInt32(Enumerados.TablasTabla.EtapasControl);
			oAccionCtrlPosteriorEjecBE.IdEtapa = Convert.ToInt32(this.ddlbEtapa.SelectedValue);
			oAccionCtrlPosteriorEjecBE.PorcentajeAvanceTotal = Convert.ToDouble(this.nbPorcentajeAvanceTotal.Text);
			oAccionCtrlPosteriorEjecBE.FechaInicio = this.calFechaInicio.SelectedDate;

			if(!this.calFechaTermino.SelectedDate.Equals(DateTime.MinValue))
			{
				oAccionCtrlPosteriorEjecBE.FechaTermino = this.calFechaTermino.SelectedDate;
			}
			if(this.nbNroRealIntegrantesOCI.Text != String.Empty)
			{
				oAccionCtrlPosteriorEjecBE.NroRealIntegrantesOCI = Convert.ToInt32(this.nbNroRealIntegrantesOCI.Text);
			}
			if(this.nbNroRealIntegrantesEspecialistas.Text != String.Empty)
			{
				oAccionCtrlPosteriorEjecBE.NroRealIntegrantesEspecialistas = Convert.ToInt32(this.nbNroRealIntegrantesEspecialistas.Text);
			}
			if(this.nbCostoRealOCI.Text != String.Empty)
			{
				oAccionCtrlPosteriorEjecBE.CostoRealOCI = Convert.ToDouble(this.nbCostoRealOCI.Text);
			}
			if(this.nbCostoRealEspecialistas.Text != String.Empty)
			{
				oAccionCtrlPosteriorEjecBE.CostoRealEspecialistas = Convert.ToDouble(this.nbCostoRealEspecialistas.Text);
			}
			if(this.nbNumeroRealHH.Text != String.Empty)
			{
				oAccionCtrlPosteriorEjecBE.NumeroRealHH = Convert.ToDouble(this.nbNumeroRealHH.Text);
			}
			if(this.nbMontoExaminado.Text != String.Empty)
			{
				oAccionCtrlPosteriorEjecBE.MontoExaminado = Convert.ToDouble(this.nbMontoExaminado.Text);
			}
			if(this.txtObservaciones.Text != String.Empty)
			{
				oAccionCtrlPosteriorEjecBE.Observaciones = this.txtObservaciones.Text;
			}
			oAccionCtrlPosteriorEjecBE.IdEstado = Convert.ToInt32(Enumerados.EstadoAccionControlPosteriorEjecucion.Modificado);
			oAccionCtrlPosteriorEjecBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoAccionControlPosteriorEjecucion);
			oAccionCtrlPosteriorEjecBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oAccionCtrlPosteriorEjecBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Control Institucional",this.ToString(),"Se Modificó la Ejecucion de Accion de Control Posterior Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROACCIONCTRLPOSTERIOREJEC),URLPRINCIPAL + KEYQPRG + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQPRG].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQTIT + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQTIT].ToString());
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

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
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODONUEVO + Utilitario.Constantes.ESPACIO + Page.Request.QueryString[KEYQTIT].ToString().ToUpper();
			this.LlenarCombos();
		}

		public void CargarModoModificar()
		{
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR + Utilitario.Constantes.ESPACIO + Page.Request.QueryString[KEYQTIT].ToString().ToUpper();
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			AccionCtrlPosteriorEjecBE oAccionCtrlPosteriorEjecBE = (AccionCtrlPosteriorEjecBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.AccionCtrlPosteriorEjecNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Video Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oAccionCtrlPosteriorEjecBE!=null)
			{
				this.hIdAccionControlPosterior.Value = oAccionCtrlPosteriorEjecBE.IdAccionCtrlPosterior.ToString();
				CAccionCtrlPosterior oCAccionCtrlPosterior = new CAccionCtrlPosterior();
				this.txtAccionCtrlPosterior.Text = oCAccionCtrlPosterior.ObtenerDenominacionAccionControlPosterior(Convert.ToInt32(this.hIdAccionControlPosterior.Value));

				this.nbMetaProgramada.Text = oAccionCtrlPosteriorEjecBE.MetaProgramada.ToString();
				this.ddlbEstadoCtrl.Items.FindByValue(oAccionCtrlPosteriorEjecBE.IdEstadoCtrl.ToString()).Selected = true;
				this.ddlbEtapa.Items.FindByValue(oAccionCtrlPosteriorEjecBE.IdEtapa.ToString()).Selected = true;
				this.nbPorcentajeAvanceTotal.Text = oAccionCtrlPosteriorEjecBE.PorcentajeAvanceTotal.ToString();
				this.calFechaInicio.SelectedDate = oAccionCtrlPosteriorEjecBE.FechaInicio;
				if(!oAccionCtrlPosteriorEjecBE.FechaTermino.IsNull)
				{
					this.calFechaTermino.SelectedDate = Convert.ToDateTime(oAccionCtrlPosteriorEjecBE.FechaTermino);
				}
				if(!oAccionCtrlPosteriorEjecBE.NroRealIntegrantesOCI.IsNull)
				{
					this.nbNroRealIntegrantesOCI.Text = oAccionCtrlPosteriorEjecBE.NroRealIntegrantesOCI.ToString();
				}
				if(!oAccionCtrlPosteriorEjecBE.NroRealIntegrantesEspecialistas.IsNull)
				{
					this.nbNroRealIntegrantesEspecialistas.Text = oAccionCtrlPosteriorEjecBE.NroRealIntegrantesEspecialistas.ToString();
				}
				if(!oAccionCtrlPosteriorEjecBE.CostoRealOCI.IsNull)
				{
					this.nbCostoRealOCI.Text = oAccionCtrlPosteriorEjecBE.CostoRealOCI.ToString();
				}
				if(!oAccionCtrlPosteriorEjecBE.CostoRealEspecialistas.IsNull)
				{
					this.nbCostoRealEspecialistas.Text = oAccionCtrlPosteriorEjecBE.CostoRealEspecialistas.ToString();
				}
				if(!oAccionCtrlPosteriorEjecBE.NumeroRealHH.IsNull)
				{
					this.nbNumeroRealHH.Text = oAccionCtrlPosteriorEjecBE.NumeroRealHH.ToString();
				}
				if(!oAccionCtrlPosteriorEjecBE.MontoExaminado.IsNull)
				{
					this.nbMontoExaminado.Text = oAccionCtrlPosteriorEjecBE.MontoExaminado.ToString();
				}
				if(!oAccionCtrlPosteriorEjecBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oAccionCtrlPosteriorEjecBE.Observaciones.ToString();
				}
			}
		}

		public void CargarModoConsulta()
		{
			this.ibtnCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOCONSULTA + Utilitario.Constantes.ESPACIO + Page.Request.QueryString[KEYQTIT].ToString().ToUpper();
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			AccionCtrlPosteriorEjecBE oAccionCtrlPosteriorEjecBE = (AccionCtrlPosteriorEjecBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.AccionCtrlPosteriorEjecNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Video Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oAccionCtrlPosteriorEjecBE!=null)
			{
				this.hIdAccionControlPosterior.Value = oAccionCtrlPosteriorEjecBE.IdAccionCtrlPosterior.ToString();
				CAccionCtrlPosterior oCAccionCtrlPosterior = new CAccionCtrlPosterior();
				this.txtAccionCtrlPosterior.Text = oCAccionCtrlPosterior.ObtenerDenominacionAccionControlPosterior(Convert.ToInt32(this.hIdAccionControlPosterior.Value));

				this.nbMetaProgramada.Text = oAccionCtrlPosteriorEjecBE.MetaProgramada.ToString();
				this.ddlbEstadoCtrl.Items.FindByValue(oAccionCtrlPosteriorEjecBE.IdEstadoCtrl.ToString()).Selected = true;
				this.ddlbEtapa.Items.FindByValue(oAccionCtrlPosteriorEjecBE.IdEtapa.ToString()).Selected = true;
				this.nbPorcentajeAvanceTotal.Text = oAccionCtrlPosteriorEjecBE.PorcentajeAvanceTotal.ToString();
				this.calFechaInicio.SelectedDate = oAccionCtrlPosteriorEjecBE.FechaInicio;
				if(!oAccionCtrlPosteriorEjecBE.FechaTermino.IsNull)
				{
					this.calFechaTermino.SelectedDate = Convert.ToDateTime(oAccionCtrlPosteriorEjecBE.FechaTermino);
				}
				if(!oAccionCtrlPosteriorEjecBE.NroRealIntegrantesOCI.IsNull)
				{
					this.nbNroRealIntegrantesOCI.Text = oAccionCtrlPosteriorEjecBE.NroRealIntegrantesOCI.ToString();
				}
				if(!oAccionCtrlPosteriorEjecBE.NroRealIntegrantesEspecialistas.IsNull)
				{
					this.nbNroRealIntegrantesEspecialistas.Text = oAccionCtrlPosteriorEjecBE.NroRealIntegrantesEspecialistas.ToString();
				}
				if(!oAccionCtrlPosteriorEjecBE.CostoRealOCI.IsNull)
				{
					this.nbCostoRealOCI.Text = oAccionCtrlPosteriorEjecBE.CostoRealOCI.ToString();
				}
				if(!oAccionCtrlPosteriorEjecBE.CostoRealEspecialistas.IsNull)
				{
					this.nbCostoRealEspecialistas.Text = oAccionCtrlPosteriorEjecBE.CostoRealEspecialistas.ToString();
				}
				if(!oAccionCtrlPosteriorEjecBE.NumeroRealHH.IsNull)
				{
					this.nbNumeroRealHH.Text = oAccionCtrlPosteriorEjecBE.NumeroRealHH.ToString();
				}
				if(!oAccionCtrlPosteriorEjecBE.MontoExaminado.IsNull)
				{
					this.nbMontoExaminado.Text = oAccionCtrlPosteriorEjecBE.MontoExaminado.ToString();
				}
				if(!oAccionCtrlPosteriorEjecBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oAccionCtrlPosteriorEjecBE.Observaciones.ToString();
				}
			}
			Helper.BloquearControles(this);
		}

		public bool ValidarCampos()
		{
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.hIdAccionControlPosterior.Value==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDOACCIONCONTROLPOSTERIOR));
				return false;
			}
			if(this.nbMetaProgramada.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDOMETAPROGRAMADA));
				return false;
			}
			if(this.ddlbEstadoCtrl.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDOESTADO));
				return false;
			}
			if(this.ddlbEtapa.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDOETAPA));
				return false;
			}
			if(this.nbPorcentajeAvanceTotal.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDOPORCENTAJEAVANCE));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarEstados();
			this.llenarEtapas();
			this.ddlbEstadoCtrl.Items.Insert(Constantes.POSICIONCONTADOR,lItem);
			this.ddlbEtapa.Items.Insert(Constantes.POSICIONCONTADOR,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnBuscarAccionCtrlPosterior.Attributes.Add(Constantes.EVENTOCLICK, Helper.PopupBusqueda(URLBUSQUEDAACCIONCONTROL + KEYQPRG + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQPRG].ToString() + Constantes.SIGNOAMPERSON + KEYQTIT + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQTIT].ToString(),750,500,true));

			this.rfvAccionCtrlPosterior.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDOACCIONCONTROLPOSTERIOR);
			this.rfvAccionCtrlPosterior.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDOACCIONCONTROLPOSTERIOR);

			this.rfvMetaProgramada.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDOMETAPROGRAMADA);
			this.rfvMetaProgramada.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDOMETAPROGRAMADA);

			this.rfvEstadoCtrl.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDOESTADO);
			this.rfvEstadoCtrl.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDOESTADO);
			this.rfvEstadoCtrl.InitialValue = Constantes.VALORSELECCIONAR;

			this.rfvEtapa.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDOETAPA);
			this.rfvEtapa.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDOETAPA);
			this.rfvEtapa.InitialValue = Constantes.VALORSELECCIONAR;

			this.rfvPorcentajeAvanceTotal.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDOPORCENTAJEAVANCE);
			this.rfvPorcentajeAvanceTotal.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDOPORCENTAJEAVANCE);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.Exportar implementation
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
			return true;
		}

		#endregion

		private void llenarEstados()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbEstadoCtrl.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.EstadosControl));
			ddlbEstadoCtrl.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbEstadoCtrl.DataTextField =Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbEstadoCtrl.DataBind();
		}

		private void llenarEtapas()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbEtapa.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.EtapasControl));
			ddlbEtapa.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbEtapa.DataTextField =Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbEtapa.DataBind();
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

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

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPRINCIPAL + KEYQPRG + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQPRG].ToString() +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQTIT + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQTIT].ToString());
		}
	}
}