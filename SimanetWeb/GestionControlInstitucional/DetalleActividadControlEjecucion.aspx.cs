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
	public class DetalleActividadControlEjecucion: System.Web.UI.Page, IPaginaMantenimento, IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblActividadCtrl;
		protected System.Web.UI.WebControls.TextBox txtActividadCtrl;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarActividadCtrl;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvActividadCtrl;
		protected System.Web.UI.WebControls.Label lblRutaFisica;
		protected eWorld.UI.NumericBox nbMetaProgramada;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMetaProgramada;
		protected System.Web.UI.WebControls.Label lblPorcentajeAvanceProgramado;
		protected eWorld.UI.NumericBox nbPorcentajeAvanceProgramado;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPorcentajeAvanceProgramado;
		protected System.Web.UI.WebControls.Label lblNroUnidadesEjecutadas;
		protected eWorld.UI.NumericBox nbNroUnidadesEjecutadas;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroUnidadesEjecutadas;
		protected System.Web.UI.WebControls.Label lblPorcentajeAvanceEjecutado;
		protected eWorld.UI.NumericBox nbPorcentajeAvanceEjecutado;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPorcentajeAvanceEjecutado;
		protected System.Web.UI.WebControls.Label lblEstadoCtrl;
		protected System.Web.UI.WebControls.DropDownList ddlbEstadoCtrl;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvEstadoCtrl;
		protected System.Web.UI.WebControls.Label lblCronograma;
		protected System.Web.UI.WebControls.CheckBox chkEne;
		protected System.Web.UI.WebControls.CheckBox chkFeb;
		protected System.Web.UI.WebControls.CheckBox chkMar;
		protected System.Web.UI.WebControls.CheckBox chkAbr;
		protected System.Web.UI.WebControls.CheckBox chkMay;
		protected System.Web.UI.WebControls.CheckBox chkJun;
		protected System.Web.UI.WebControls.CheckBox chkJul;
		protected System.Web.UI.WebControls.CheckBox chkAgo;
		protected System.Web.UI.WebControls.CheckBox chkSep;
		protected System.Web.UI.WebControls.CheckBox chkOct;
		protected System.Web.UI.WebControls.CheckBox chkNov;
		protected System.Web.UI.WebControls.CheckBox chkDic;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbEstadoCtrl;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdActividadCtrl;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#endregion Controles
		
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO EJECUCION DE ACTIVIDAD DE CONTROL";
		const string TITULOMODOMODIFICAR = "ACTUALIZACION DE EJECUCION DE ACTIVIDAD DE CONTROL";
		const string TITULOMODOCONSULTA = "DETALLE DE EJECUCION DE ACTIVIDAD DE CONTROL";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQPRG = "Prg";
		const string KEYQTIT = "Titulo";
	
		//Paginas
		const string URLPRINCIPAL = "AdministracionActividadControlEjecucion.aspx?";
		const string URLBUSQUEDAACTIVIDADCONTROL = "BusquedaActividadControl.aspx?";
		
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
			ActividadCtrlEjecBE oActividadCtrlEjecBE = new ActividadCtrlEjecBE();
			oActividadCtrlEjecBE.IdActividadCtrl = Convert.ToInt32(this.hIdActividadCtrl.Value);
			oActividadCtrlEjecBE.NroMetaProgramada = Convert.ToDouble(this.nbMetaProgramada.Text);
			oActividadCtrlEjecBE.PorcentajeAvanceProgramado = Convert.ToDouble(this.nbPorcentajeAvanceProgramado.Text);
			oActividadCtrlEjecBE.NroUnidadesEjecutadas = Convert.ToInt32(this.nbNroUnidadesEjecutadas.Text);
			oActividadCtrlEjecBE.PorcentajeAvanceEjecutado = Convert.ToDouble(this.nbPorcentajeAvanceEjecutado.Text);
			oActividadCtrlEjecBE.IdTablaEstadoCtrl = Convert.ToInt32(Enumerados.TablasTabla.EstadosControl);
			oActividadCtrlEjecBE.IdEstadoCtrl = Convert.ToInt32(this.ddlbEstadoCtrl.SelectedValue);

			if(this.chkEne.Checked == true)
			{
				oActividadCtrlEjecBE.FlgEne = Convert.ToInt32(this.chkEne.Checked);
			}
			if(this.chkFeb.Checked == true)
			{
				oActividadCtrlEjecBE.FlgFeb = Convert.ToInt32(this.chkFeb.Checked);
			}
			if(this.chkMar.Checked == true)
			{
				oActividadCtrlEjecBE.FlgMar = Convert.ToInt32(this.chkMar.Checked);
			}
			if(this.chkAbr.Checked == true)
			{
				oActividadCtrlEjecBE.FlgAbr = Convert.ToInt32(this.chkAbr.Checked);
			}
			if(this.chkMay.Checked == true)
			{
				oActividadCtrlEjecBE.FlgMay = Convert.ToInt32(this.chkMay.Checked);
			}
			if(this.chkJun.Checked == true)
			{
				oActividadCtrlEjecBE.FlgJun = Convert.ToInt32(this.chkJun.Checked);
			}
			if(this.chkJul.Checked == true)
			{
				oActividadCtrlEjecBE.FlgJul = Convert.ToInt32(this.chkJul.Checked);
			}
			if(this.chkAgo.Checked == true)
			{
				oActividadCtrlEjecBE.FlgAgo = Convert.ToInt32(this.chkAgo.Checked);
			}
			if(this.chkSep.Checked == true)
			{
				oActividadCtrlEjecBE.FlgSep = Convert.ToInt32(this.chkSep.Checked);
			}
			if(this.chkOct.Checked == true)
			{
				oActividadCtrlEjecBE.FlgOct = Convert.ToInt32(this.chkOct.Checked);
			}
			if(this.chkNov.Checked == true)
			{
				oActividadCtrlEjecBE.FlgNov = Convert.ToInt32(this.chkNov.Checked);
			}
			if(this.chkDic.Checked == true)
			{
				oActividadCtrlEjecBE.FlgDic = Convert.ToInt32(this.chkDic.Checked);
			}
			if(this.txtObservaciones.Text != String.Empty)
			{
				oActividadCtrlEjecBE.Observaciones = this.txtObservaciones.Text;
			}
			oActividadCtrlEjecBE.IdEstado = Convert.ToInt32(Enumerados.EstadoActividadControlEjecucion.Activo);
			oActividadCtrlEjecBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoActividadControlEjecucion);
			oActividadCtrlEjecBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oActividadCtrlEjecBE);

			if(retorno > Constantes.POSICIONCONTADOR)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Control Institucional",this.ToString(),"Se registró la Ejecucion de Accion de Control Posterior Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROACTIVIDADCTRLEJEC),URLPRINCIPAL + KEYQPRG + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQPRG].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQTIT + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQTIT].ToString());
			}
		}

		public void Modificar()
		{
			ActividadCtrlEjecBE oActividadCtrlEjecBE = new ActividadCtrlEjecBE();
			oActividadCtrlEjecBE.IdActividadCtrlEjec = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oActividadCtrlEjecBE.IdActividadCtrl = Convert.ToInt32(this.hIdActividadCtrl.Value);
			oActividadCtrlEjecBE.NroMetaProgramada = Convert.ToDouble(this.nbMetaProgramada.Text);
			oActividadCtrlEjecBE.PorcentajeAvanceProgramado = Convert.ToDouble(this.nbPorcentajeAvanceProgramado.Text);
			oActividadCtrlEjecBE.NroUnidadesEjecutadas = Convert.ToInt32(this.nbNroUnidadesEjecutadas.Text);
			oActividadCtrlEjecBE.PorcentajeAvanceEjecutado = Convert.ToDouble(this.nbPorcentajeAvanceEjecutado.Text);
			oActividadCtrlEjecBE.IdTablaEstadoCtrl = Convert.ToInt32(Enumerados.TablasTabla.EstadosControl);
			oActividadCtrlEjecBE.IdEstadoCtrl = Convert.ToInt32(this.ddlbEstadoCtrl.SelectedValue);
			oActividadCtrlEjecBE.FlgEne = Convert.ToInt32(this.chkEne.Checked);
			oActividadCtrlEjecBE.FlgFeb = Convert.ToInt32(this.chkFeb.Checked);
			oActividadCtrlEjecBE.FlgMar = Convert.ToInt32(this.chkMar.Checked);
			oActividadCtrlEjecBE.FlgAbr = Convert.ToInt32(this.chkAbr.Checked);
			oActividadCtrlEjecBE.FlgMay = Convert.ToInt32(this.chkMay.Checked);
			oActividadCtrlEjecBE.FlgJun = Convert.ToInt32(this.chkJun.Checked);
			oActividadCtrlEjecBE.FlgJul = Convert.ToInt32(this.chkJul.Checked);
			oActividadCtrlEjecBE.FlgAgo = Convert.ToInt32(this.chkAgo.Checked);
			oActividadCtrlEjecBE.FlgSep = Convert.ToInt32(this.chkSep.Checked);
			oActividadCtrlEjecBE.FlgOct = Convert.ToInt32(this.chkOct.Checked);
			oActividadCtrlEjecBE.FlgNov = Convert.ToInt32(this.chkNov.Checked);
			oActividadCtrlEjecBE.FlgDic = Convert.ToInt32(this.chkDic.Checked);
			if(this.txtObservaciones.Text != String.Empty)
			{
				oActividadCtrlEjecBE.Observaciones = this.txtObservaciones.Text;
			}
			oActividadCtrlEjecBE.IdEstado = Convert.ToInt32(Enumerados.EstadoActividadControlEjecucion.Modificado);
			oActividadCtrlEjecBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoActividadControlEjecucion);
			oActividadCtrlEjecBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oActividadCtrlEjecBE);

			if(retorno > Constantes.POSICIONCONTADOR)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Control Institucional",this.ToString(),"Se modificó la Ejecucion de Accion de Control Posterior Nro. " + oActividadCtrlEjecBE.IdActividadCtrlEjec.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROACTIVIDADCTRLEJEC),URLPRINCIPAL + KEYQPRG + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQPRG].ToString() +
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
			ActividadCtrlEjecBE oActividadCtrlEjecBE = (ActividadCtrlEjecBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.ActividadCtrlEjecNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Video Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oActividadCtrlEjecBE!=null)
			{
				this.hIdActividadCtrl.Value = oActividadCtrlEjecBE.IdActividadCtrl.ToString();
				CActividadCtrl oCActividadCtrl = new CActividadCtrl();
				this.txtActividadCtrl.Text = oCActividadCtrl.ObtenerDenominacionActividadControl(Convert.ToInt32(this.hIdActividadCtrl.Value));

				this.nbMetaProgramada.Text = oActividadCtrlEjecBE.NroMetaProgramada.ToString();
				this.nbPorcentajeAvanceProgramado.Text = oActividadCtrlEjecBE.PorcentajeAvanceProgramado.ToString();
				this.nbNroUnidadesEjecutadas.Text = oActividadCtrlEjecBE.NroUnidadesEjecutadas.ToString();
				this.nbPorcentajeAvanceEjecutado.Text = oActividadCtrlEjecBE.PorcentajeAvanceEjecutado.ToString();
				this.ddlbEstadoCtrl.Items.FindByValue(oActividadCtrlEjecBE.IdEstadoCtrl.ToString()).Selected = true;
				this.chkEne.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgEne);
				this.chkFeb.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgFeb);
				this.chkMar.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgMar);
				this.chkAbr.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgAbr);
				this.chkMay.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgMay);
				this.chkJun.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgJun);
				this.chkJul.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgJul);
				this.chkAgo.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgAgo);
				this.chkSep.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgSep);
				this.chkOct.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgOct);
				this.chkNov.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgNov);
				this.chkDic.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgDic);
				if(!oActividadCtrlEjecBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oActividadCtrlEjecBE.Observaciones.ToString();
				}
			}
		}

		public void CargarModoConsulta()
		{
			this.ibtnCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOCONSULTA + Utilitario.Constantes.ESPACIO + Page.Request.QueryString[KEYQTIT].ToString().ToUpper();
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			ActividadCtrlEjecBE oActividadCtrlEjecBE = (ActividadCtrlEjecBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.ActividadCtrlEjecNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Video Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oActividadCtrlEjecBE!=null)
			{
				this.hIdActividadCtrl.Value = oActividadCtrlEjecBE.IdActividadCtrl.ToString();
				CActividadCtrl oCActividadCtrl = new CActividadCtrl();
				this.txtActividadCtrl.Text = oCActividadCtrl.ObtenerDenominacionActividadControl(Convert.ToInt32(this.hIdActividadCtrl.Value));

				this.nbMetaProgramada.Text = oActividadCtrlEjecBE.NroMetaProgramada.ToString();
				this.nbPorcentajeAvanceProgramado.Text = oActividadCtrlEjecBE.PorcentajeAvanceProgramado.ToString();
				this.nbNroUnidadesEjecutadas.Text = oActividadCtrlEjecBE.NroUnidadesEjecutadas.ToString();
				this.nbPorcentajeAvanceEjecutado.Text = oActividadCtrlEjecBE.PorcentajeAvanceEjecutado.ToString();
				this.ddlbEstadoCtrl.Items.FindByValue(oActividadCtrlEjecBE.IdEstadoCtrl.ToString()).Selected = true;
				this.chkEne.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgEne);
				this.chkFeb.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgFeb);
				this.chkMar.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgMar);
				this.chkAbr.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgAbr);
				this.chkMay.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgMay);
				this.chkJun.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgJun);
				this.chkJul.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgJul);
				this.chkAgo.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgAgo);
				this.chkSep.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgSep);
				this.chkOct.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgOct);
				this.chkNov.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgNov);
				this.chkDic.Checked = Convert.ToBoolean(oActividadCtrlEjecBE.FlgDic);
				if(!oActividadCtrlEjecBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oActividadCtrlEjecBE.Observaciones.ToString();
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
			if(this.hIdActividadCtrl.Value==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOACCIONCTRL));
				return false;
			}
			if(this.nbMetaProgramada.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOMETAPROGRAMADA));
				return false;
			}
			if(this.nbPorcentajeAvanceProgramado.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOPORCENTAJEAVANCEPROGRAMADO));
				return false;
			}
			if(this.nbNroUnidadesEjecutadas.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOUNIDADESEJECUTADAS));
				return false;
			}
			if(this.nbPorcentajeAvanceEjecutado.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOPORCENTAJEAVANCEEJECUTADO));
				return false;
			}
			if(this.ddlbEstadoCtrl.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOESTADO));
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
			this.ddlbEstadoCtrl.Items.Insert(0,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnBuscarActividadCtrl.Attributes.Add(Constantes.EVENTOCLICK, Helper.PopupBusqueda(URLBUSQUEDAACTIVIDADCONTROL + KEYQPRG + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQPRG].ToString() + Constantes.SIGNOAMPERSON + KEYQTIT + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQTIT].ToString(),750,500,true));

			this.rfvActividadCtrl.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOACCIONCTRL);
			this.rfvActividadCtrl.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOACCIONCTRL);

			this.rfvMetaProgramada.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOMETAPROGRAMADA);
			this.rfvMetaProgramada.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOMETAPROGRAMADA);

			this.rfvPorcentajeAvanceProgramado.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOPORCENTAJEAVANCEPROGRAMADO);
			this.rfvPorcentajeAvanceProgramado.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOPORCENTAJEAVANCEPROGRAMADO);

			this.rfvNroUnidadesEjecutadas.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOUNIDADESEJECUTADAS);
			this.rfvNroUnidadesEjecutadas.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOUNIDADESEJECUTADAS);

			this.rfvPorcentajeAvanceEjecutado.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOPORCENTAJEAVANCEEJECUTADO);
			this.rfvPorcentajeAvanceEjecutado.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOPORCENTAJEAVANCEEJECUTADO);

			this.rfvEstadoCtrl.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOESTADO);
			this.rfvEstadoCtrl.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLEJECCAMPOREQUERIDOESTADO);
			this.rfvEstadoCtrl.InitialValue = Constantes.VALORSELECCIONAR;
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