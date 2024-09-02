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
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionControlInstitucional;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for DetalleActividadCtrl.
	/// </summary>
	public class DetalleActividadCtrl : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblCodigo;
		protected System.Web.UI.WebControls.Label lblTipoOrgano;
		protected System.Web.UI.WebControls.Label lblOrgInfo;
		protected System.Web.UI.WebControls.Label lblAno;
		protected System.Web.UI.WebControls.Label lblCorrelativo;
		protected System.Web.UI.WebControls.DropDownList ddlbTipOrgano;
		protected System.Web.UI.WebControls.DropDownList ddlbOrganoInformante;
		protected System.Web.UI.WebControls.DropDownList ddlbAno;
		protected System.Web.UI.WebControls.TextBox txtCorrelativo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCorrelativo;
		protected System.Web.UI.WebControls.Label lblDenominacion;
		protected System.Web.UI.WebControls.TextBox txtDenominacion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDenominacion;
		protected System.Web.UI.WebControls.Label lblUnidadMedida;
		protected System.Web.UI.WebControls.DropDownList ddlbUnidadMedida;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvUnidadMedida;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.TextBox txtNroHH;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroHH;
		protected System.Web.UI.WebControls.Label lblMeta;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtMeta1erTrimestre;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMeta1erTrim;
		protected System.Web.UI.WebControls.TextBox txtMeta2doTrimestre;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMeta2doTrim;
		protected System.Web.UI.WebControls.TextBox txtMeta3erTrimestre;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMeta3erTrim;
		protected System.Web.UI.WebControls.TextBox txtMeta4toTrimestre;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMeta4toTrim;
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
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbTipOrgano;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbOrganoInformante;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbAno;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		private   ListItem item =  new ListItem();
		#endregion Controles

		#region Constantes
		const string URLPRINCIPAL = "AdministracionActividadCtrl.aspx";
		const string KEYQID  = "Id";
		const string KEYQPRG = "Prg";
		const string KEYQTIT = "Titulo";
		
		const string TITULOMODONUEVO     = "NUEVA ACTIVIDAD DE CONTROL";
		const string TITULOMODOMODIFICAR = "MODIFICAR ACTIVIDAD DE CONTROL";
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbUnidadMedida;
		const string TITULOMODOCONSULTA  = "CONSULTAR ACTIVIDAD DE CONTROL";
		#endregion Constantes
	

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

		private void CargarTipoOggano()
		{

			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbTipOrgano.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TipoOrgano));
			ddlbTipOrgano.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipOrgano.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipOrgano.DataBind();	
		}
		private void CargarOrganoInformante()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbOrganoInformante.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.OrganoInformante));
			ddlbOrganoInformante.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbOrganoInformante.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbOrganoInformante.DataBind();	
		}

		private void CargarUnidadMedida()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbUnidadMedida.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.UnidadMedida));
			ddlbUnidadMedida.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbUnidadMedida.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbUnidadMedida.DataBind();	
//			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
//			ddlbUnidadMedida.Items.Insert(0,item);
		}

		private void CargarAnos()
		{
			ListItem lItem = new ListItem(Constantes.TEXTOSSELECCIONAR,Constantes.VALORSELECCIONAR);
			ddlbAno.DataSource = Helper.ObtenerPeriodos(DateTime.Now.Year - 5,DateTime.Now.Year);
			ddlbAno.DataBind();
		}


		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{

				try
				{
					this.ConfigurarAccesoControles();
					
					Helper.ReiniciarSession();
					this.LlenarJScript();
					//this.LlenarCombos();
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}

			}
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
		}

		public void LlenarCombos()
		{
			this.CargarTipoOggano();
			this.CargarOrganoInformante();
			this.CargarUnidadMedida();
			this.CargarAnos();
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
			rfvCorrelativo.ErrorMessage  = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOCORRELATIVO);
			rfvCorrelativo.ToolTip       = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOCORRELATIVO);

			rfvDenominacion.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDODENOMINACION);
			rfvDenominacion.ToolTip      = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDODENOMINACION);

			rfvUnidadMedida.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOUNIDADMEDIDA);
			rfvUnidadMedida.ToolTip      = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOUNIDADMEDIDA);
			rfvUnidadMedida.InitialValue = Constantes.VALORSELECCIONAR;

			rfvNroHH.ErrorMessage        = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDONROHH);
			rfvNroHH.ToolTip             = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDONROHH);

			rfvMeta1erTrim.ErrorMessage  = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOMETA1ER);
			rfvMeta1erTrim.ToolTip       = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOMETA1ER);

			rfvMeta2doTrim.ErrorMessage  = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOMETA2DO);
			rfvMeta2doTrim.ToolTip       = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOMETA2DO);

			rfvMeta3erTrim.ErrorMessage  = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOMETA3ER);
			rfvMeta3erTrim.ToolTip       = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOMETA3ER);

			rfvMeta4toTrim.ErrorMessage  = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOMETA4TO);
			rfvMeta4toTrim.ToolTip       = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOMETA4TO);

		}

		public void RegistrarJScript()
		{
			// TODO:  Add implementation
		}

		public void Imprimir()
		{
			// TODO:  Add implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaDeCartasFianzas.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add implementation

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

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			ActividadCtrlBE oActividadCtrlBE = new ActividadCtrlBE();
			oActividadCtrlBE.IdTablaTipoOrgano         = Convert.ToInt32(Enumerados.TablasTabla.TipoOrgano);
			oActividadCtrlBE.IdTipoOrgano              = Convert.ToInt32(ddlbTipOrgano.SelectedValue);
			oActividadCtrlBE.IdTablaOrganoInformante   = Convert.ToInt32(Enumerados.TablasTabla.OrganoInformante);
			oActividadCtrlBE.IdOrganoInformante        = Convert.ToInt32(ddlbOrganoInformante.SelectedValue);
			oActividadCtrlBE.Ano                       = Convert.ToInt32(ddlbAno.SelectedValue);
			oActividadCtrlBE.Correlativo               = Convert.ToInt32(txtCorrelativo.Text);
			oActividadCtrlBE.IdTablaUnidadMedida       = Convert.ToInt32(Enumerados.TablasTabla.UnidadMedida);
			oActividadCtrlBE.IdUnidadMedida            = Convert.ToInt32(ddlbUnidadMedida.SelectedValue);
			oActividadCtrlBE.NroHH                     = Convert.ToDouble(txtNroHH.Text);
			oActividadCtrlBE.Meta1erTrimestre          = Convert.ToDouble(txtMeta1erTrimestre.Text);
			oActividadCtrlBE.Meta2doTrimestre          = Convert.ToDouble(txtMeta2doTrimestre.Text);
			oActividadCtrlBE.Meta3erTrimestre          = Convert.ToDouble(txtMeta3erTrimestre.Text);
			oActividadCtrlBE.Meta4toTrimestre          = Convert.ToDouble(txtMeta4toTrimestre.Text);
			oActividadCtrlBE.Denominacion              = txtDenominacion.Text.ToUpper();
			oActividadCtrlBE.Programado                = Convert.ToInt32(Page.Request.QueryString[KEYQPRG].ToString());
			oActividadCtrlBE.IdUsuarioRegistro         = CNetAccessControl.GetIdUser();
			oActividadCtrlBE.IdTablaEstado             = Convert.ToInt32(Enumerados.TablasTabla.AccionCtrlPosterior);
			oActividadCtrlBE.IdEstado                  = Convert.ToInt32(Enumerados.EstadosAccionCtrlPosterior.Activo);
			

			if(this.chkEne.Checked == true)
			{
				oActividadCtrlBE.Ene = Convert.ToInt32(this.chkEne.Checked);
			}
			if(this.chkFeb.Checked == true)
			{
				oActividadCtrlBE.Feb = Convert.ToInt32(this.chkFeb.Checked);
			}
			if(this.chkMar.Checked == true)
			{
				oActividadCtrlBE.Mar = Convert.ToInt32(this.chkMar.Checked);
			}
			if(this.chkAbr.Checked == true)
			{
				oActividadCtrlBE.Abr = Convert.ToInt32(this.chkAbr.Checked);
			}
			if(this.chkMay.Checked == true)
			{
				oActividadCtrlBE.May = Convert.ToInt32(this.chkMay.Checked);
			}
			if(this.chkJun.Checked == true)
			{
				oActividadCtrlBE.Jun = Convert.ToInt32(this.chkJun.Checked);
			}
			if(this.chkJul.Checked == true)
			{
				oActividadCtrlBE.Jul = Convert.ToInt32(this.chkJul.Checked);
			}
			if(this.chkAgo.Checked == true)
			{
				oActividadCtrlBE.Ago = Convert.ToInt32(this.chkAgo.Checked);
			}
			if(this.chkSep.Checked == true)
			{
				oActividadCtrlBE.Sep = Convert.ToInt32(this.chkSep.Checked);
			}
			if(this.chkOct.Checked == true)
			{
				oActividadCtrlBE.Oct = Convert.ToInt32(this.chkOct.Checked);
			}
			if(this.chkNov.Checked == true)
			{
				oActividadCtrlBE.Nov = Convert.ToInt32(this.chkNov.Checked);
			}
			if(this.chkDic.Checked == true)
			{
				oActividadCtrlBE.Dic = Convert.ToInt32(this.chkDic.Checked);
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oActividadCtrlBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Detalle Actividad de Ctrl.",this.ToString(),"Se registró el Detalle de la Actividad de Ctrl. Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROACTIVIDADCTRL));
			}
		}

		public void Modificar()
		{
			ActividadCtrlBE oActividadCtrlBE = new ActividadCtrlBE();
			oActividadCtrlBE.IdActividadCtrl           = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oActividadCtrlBE.IdTablaTipoOrgano         = Convert.ToInt32(Enumerados.TablasTabla.TipoOrgano);
			oActividadCtrlBE.IdTipoOrgano              = Convert.ToInt32(ddlbTipOrgano.SelectedValue);
			oActividadCtrlBE.IdTablaOrganoInformante   = Convert.ToInt32(Enumerados.TablasTabla.OrganoInformante);
			oActividadCtrlBE.IdOrganoInformante        = Convert.ToInt32(ddlbOrganoInformante.SelectedValue);
			oActividadCtrlBE.Ano                       = Convert.ToInt32(ddlbAno.SelectedValue);
			oActividadCtrlBE.Correlativo               = Convert.ToInt32(txtCorrelativo.Text);
			oActividadCtrlBE.IdTablaUnidadMedida       = Convert.ToInt32(Enumerados.TablasTabla.UnidadMedida);
			oActividadCtrlBE.IdUnidadMedida            = Convert.ToInt32(ddlbUnidadMedida.SelectedValue);
			oActividadCtrlBE.NroHH                     = Convert.ToDouble(txtNroHH.Text);
			oActividadCtrlBE.Meta1erTrimestre          = Convert.ToDouble(txtMeta1erTrimestre.Text);
			oActividadCtrlBE.Meta2doTrimestre          = Convert.ToDouble(txtMeta2doTrimestre.Text);
			oActividadCtrlBE.Meta3erTrimestre          = Convert.ToDouble(txtMeta3erTrimestre.Text);
			oActividadCtrlBE.Meta4toTrimestre          = Convert.ToDouble(txtMeta4toTrimestre.Text);
			oActividadCtrlBE.Ene                       = Convert.ToInt32(this.chkEne.Checked);
			oActividadCtrlBE.Feb                       = Convert.ToInt32(this.chkFeb.Checked);
			oActividadCtrlBE.Mar                       = Convert.ToInt32(this.chkMar.Checked);
			oActividadCtrlBE.Abr                       = Convert.ToInt32(this.chkAbr.Checked);
			oActividadCtrlBE.May                       = Convert.ToInt32(this.chkMay.Checked);
			oActividadCtrlBE.Jun                       = Convert.ToInt32(this.chkJun.Checked);
			oActividadCtrlBE.Jul                       = Convert.ToInt32(this.chkJul.Checked);
			oActividadCtrlBE.Ago                       = Convert.ToInt32(this.chkAgo.Checked);
			oActividadCtrlBE.Sep                       = Convert.ToInt32(this.chkSep.Checked);
			oActividadCtrlBE.Oct                       = Convert.ToInt32(this.chkOct.Checked);
			oActividadCtrlBE.Nov                       = Convert.ToInt32(this.chkNov.Checked);
			oActividadCtrlBE.Dic                       = Convert.ToInt32(this.chkDic.Checked);

			oActividadCtrlBE.Denominacion              = txtDenominacion.Text.ToUpper();
			oActividadCtrlBE.Programado                = Convert.ToInt32(Page.Request.QueryString[KEYQPRG].ToString());
			oActividadCtrlBE.IdUsuarioActualizacion    = CNetAccessControl.GetIdUser();
			oActividadCtrlBE.IdTablaEstado             = Convert.ToInt32(Enumerados.TablasTabla.AccionCtrlPosterior);
			oActividadCtrlBE.IdEstado                  = Convert.ToInt32(Enumerados.EstadosAccionCtrlPosterior.Modificado);
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oActividadCtrlBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Detalle Area Critica",this.ToString(),"Se modificó el Detalle del Área Crítica Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROACTIVIDADCTRL));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleCuentasBancaria.Eliminar implementation
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
			lblTitulo.Text = TITULOMODOMODIFICAR + Utilitario.Constantes.ESPACIO + Page.Request.QueryString[KEYQTIT].ToString().ToUpper();;
			this.LlenarCombos();

			CActividadCtrl oCActividadCtrl = new CActividadCtrl();

			ActividadCtrlBE oActividadCtrlBE = (ActividadCtrlBE) oCActividadCtrl.DetalleActividadCtrl(Convert.ToInt32(Page.Request.QueryString[KEYQID]));

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Detalle Actividad de Ctrl.",this.ToString(),"Se consultó el Detalle de la Actividad  de Ctrl. Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oActividadCtrlBE!=null)
			{

				item = this.ddlbTipOrgano.Items.FindByValue(oActividadCtrlBE.IdTipoOrgano.ToString());
				if(item!=null)
				{item.Selected = true;}

				item = this.ddlbOrganoInformante.Items.FindByValue(oActividadCtrlBE.IdOrganoInformante.ToString());
				if(item!=null)
				{item.Selected = true;}
				
				item = this.ddlbAno.Items.FindByValue(oActividadCtrlBE.Ano.ToString());
				if(item!=null)
				{item.Selected = true;}
				
				txtCorrelativo.Text   = oActividadCtrlBE.Correlativo.ToString();
				txtDenominacion.Text  = oActividadCtrlBE.Denominacion.ToString();

				item = this.ddlbUnidadMedida.Items.FindByValue(oActividadCtrlBE.IdUnidadMedida.ToString());
				if(item!=null)
				{item.Selected = true;}

				txtNroHH.Text = oActividadCtrlBE.NroHH.ToString();

				txtMeta1erTrimestre.Text = oActividadCtrlBE.Meta1erTrimestre.ToString();
				txtMeta2doTrimestre.Text = oActividadCtrlBE.Meta2doTrimestre.ToString();
				txtMeta3erTrimestre.Text = oActividadCtrlBE.Meta3erTrimestre.ToString();
				txtMeta4toTrimestre.Text = oActividadCtrlBE.Meta4toTrimestre.ToString();

				this.chkEne.Checked = Convert.ToBoolean(oActividadCtrlBE.Ene);
				this.chkFeb.Checked = Convert.ToBoolean(oActividadCtrlBE.Feb);
				this.chkMar.Checked = Convert.ToBoolean(oActividadCtrlBE.Mar);
				this.chkAbr.Checked = Convert.ToBoolean(oActividadCtrlBE.Abr);
				this.chkMay.Checked = Convert.ToBoolean(oActividadCtrlBE.May);
				this.chkJun.Checked = Convert.ToBoolean(oActividadCtrlBE.Jun);
				this.chkJul.Checked = Convert.ToBoolean(oActividadCtrlBE.Jul);
				this.chkAgo.Checked = Convert.ToBoolean(oActividadCtrlBE.Ago);
				this.chkSep.Checked = Convert.ToBoolean(oActividadCtrlBE.Sep);
				this.chkOct.Checked = Convert.ToBoolean(oActividadCtrlBE.Oct);
				this.chkNov.Checked = Convert.ToBoolean(oActividadCtrlBE.Nov);
				this.chkDic.Checked = Convert.ToBoolean(oActividadCtrlBE.Dic);

			}
		}

		public void CargarModoConsulta()
		{

			this.CargarModoModificar();
			this.TdCeldaCancelar.Visible        = true;
			this.ibtnCancelar.Visible           = false;
			lblTitulo.Text = TITULOMODOCONSULTA + Utilitario.Constantes.ESPACIO + Page.Request.QueryString[KEYQTIT].ToString().ToUpper();;
			Helper.BloquearControles(this);
		}

		public bool ValidarCampos()
		{
			if(this.ValidarCamposRequeridos())
			{
				return this.ValidarExpresionesRegulares();
			}
			else
			{
				return false;
			}
		}

		

		public bool ValidarCamposRequeridos()
		{
			if(txtCorrelativo.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOCORRELATIVO));
				return false;		
			}
						
			if(txtDenominacion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOCORRELATIVO));
				return false;		
			}

			if(this.ddlbUnidadMedida.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOUNIDADMEDIDA));
				return false;
			}

			if(txtNroHH.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDONROHH));
				return false;		
			}

			if(txtMeta1erTrimestre.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOMETA1ER));
				return false;		
			}

			if(txtMeta2doTrimestre.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOMETA2DO));
				return false;		
			}
			if(txtMeta3erTrimestre.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOMETA3ER));
				return false;		
			}
			if(txtMeta4toTrimestre.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACTIVIDADCTRLCAMPOREQUERIDOMETA4TO));
				return false;		
			}

			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			/*
			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(txtMontoCallao.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVADATOSINCORRECTOSNUMEROSPORCENTAJEAVANCE));
				return false;
			}
			*/
			return true;
		}

		#endregion

		#region Opciones Usuario

		#region Cancelar
		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}

		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}
		#endregion Cancelar
		#endregion Opciones Usuario

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

	}
}
