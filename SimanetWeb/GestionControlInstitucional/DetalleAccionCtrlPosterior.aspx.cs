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
	/// Summary description for DetalleAccionCtrlPosterior.
	/// </summary>
	public class DetalleAccionCtrlPosterior : System.Web.UI.Page, IPaginaMantenimento, IPaginaBase
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
		protected System.Web.UI.WebControls.Label lblTipo;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoAccionCtrlPosterior;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipoAccionCtrlPosterior;
		protected System.Web.UI.WebControls.Label lblDenominacion;
		protected System.Web.UI.WebControls.TextBox txtDenominacion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDenominacion;
		protected System.Web.UI.WebControls.Label lblObjetivo;
		protected System.Web.UI.WebControls.TextBox txtObjetivo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvObjetivo;
		protected System.Web.UI.WebControls.Label lblLineamientos;
		protected System.Web.UI.WebControls.TextBox txtLineamientos;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvLineamientos;
		protected System.Web.UI.WebControls.Label lblMonto;
		protected System.Web.UI.WebControls.TextBox txtMontoAExaminar;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMontoAExaminar;
		protected System.Web.UI.WebControls.TextBox txtNroHH;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroHH;
		protected System.Web.UI.WebControls.Label lblAlcance;
		protected System.Web.UI.WebControls.Label lblCronograma;
		protected eWorld.UI.CalendarPopup CalAlcanceDesde;
		protected eWorld.UI.CalendarPopup CalAlcanceHasta;
		protected eWorld.UI.CalendarPopup CalCronogramaDesde;
		protected eWorld.UI.CalendarPopup CalCronogramaHasta;
		protected System.Web.UI.WebControls.Label lblIntegrantes;
		protected System.Web.UI.WebControls.TextBox txtIntegrantesOCI;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvIntegrantesOCI;
		protected System.Web.UI.WebControls.TextBox txtIntegrantesEspecialistas;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvIntegrantesEspecialistas;
		protected System.Web.UI.WebControls.TextBox txtCostoOCI;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCostoOCI;
		protected System.Web.UI.WebControls.TextBox txtCostoEspecialistas;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCostoEspecialistas;
		protected System.Web.UI.WebControls.Label lblMeta;
		protected System.Web.UI.WebControls.TextBox txtMeta1erTrimestre;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMeta1erTrim;
		protected System.Web.UI.WebControls.TextBox txtMeta2doTrimestre;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMeta2doTrim;
		protected System.Web.UI.WebControls.TextBox txtMeta3erTrimestre;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMeta3erTrim;
		protected System.Web.UI.WebControls.TextBox txtMeta4toTrimestre;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMeta4toTrim;
		protected System.Web.UI.WebControls.Label lblTitulo1;
		protected System.Web.UI.WebControls.CheckBox chkTieneAreasAExaminar;
		protected System.Web.UI.WebControls.Label lblAreaCritica;
		protected System.Web.UI.WebControls.TextBox txtNombreAreaCritica;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarAreaAExaminar;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnModificar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdGrupoAreaCritica;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAreaCritica;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreAreaCritica;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroGrupoAreaCritica;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroAreaCritica;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		protected System.Web.UI.WebControls.Label lblNroHH;
		protected System.Web.UI.WebControls.Label lblAlcanceFechDesde;
		protected System.Web.UI.WebControls.Label lblAlcanceFechHasta;
		protected System.Web.UI.WebControls.Label lblCronogramaFechDesde;
		protected System.Web.UI.WebControls.Label lblCronogramaFechHasta;
		protected System.Web.UI.WebControls.Label lblAudOCI;
		protected System.Web.UI.WebControls.Label lblAudEsp;
		protected System.Web.UI.WebControls.Label lblCostoDirecto;
		protected System.Web.UI.WebControls.Label lblCostoAudOCI;
		protected System.Web.UI.WebControls.Label lblCostoEsp;
		protected System.Web.UI.WebControls.Label lbl1erT;
		protected System.Web.UI.WebControls.Label lbl2doT;
		protected System.Web.UI.WebControls.Label lbl2erT;
		protected System.Web.UI.WebControls.Label lbl4toT;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbTipOrgano;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbOrganoInformante;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbAno;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbTipoAccionCtrlPosterior;
		protected System.Web.UI.HtmlControls.HtmlTableRow TrCeldaAreaCritica;
		private   ListItem item =  new ListItem();
		#endregion Controles

		#region Constantes
		//Paginas
		const string URLPRINCIPAL = "AdministracionAccionCtrlPosterior.aspx";
		const string URLBUSQUEDAAREACRITICA = "BusquedaAreaAExaminar.aspx";

		//Key Session y QueryString
		const string KEYQID  = "Id";
		const string KEYQPRG = "Prg";
		const string KEYQTIT = "Titulo";
		const string KEYQDATATABLE = "DataTable";
		const string KEYQCONTADOR = "Contador";
		const string KEYQCODIGOINICIAL = "CodigoInicial";
		const string KEYQREGELIMGRUPOAREACRITICA = "RegElimGrupo";
		const string KEYQREGELIMAREACRITICA = "RegElimArea";
		const string KEYQCONTADORREGISTROSELIMINADOS = "ContadorRegistrosEliminados";

		
		//Titulos 
		const string TITULOMODONUEVO     = "NUEVA ACCIÓN DE CONTROL POSTERIOR";
		const string TITULOMODOMODIFICAR = "MODIFICAR ACCIÓN DE CONTROL POSTERIOR";
		const string TITULOMODOCONSULTA  = "CONSULTAR ACCIÓN DE CONTROL POSTERIOR";

		//Otros
		const string NombreDataTable = "TablaAreasAExaminar";
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";

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
			this.chkTieneAreasAExaminar.CheckedChanged += new System.EventHandler(this.chkTieneAreasAExaminar_CheckedChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnModificar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnModificar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
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

		private void CargarTipoAccionPosterior()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbTipoAccionCtrlPosterior.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TipoAccionPosterior));
			ddlbTipoAccionCtrlPosterior.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoAccionCtrlPosterior.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipoAccionCtrlPosterior.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbTipoAccionCtrlPosterior.Items.Insert(0,item);
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
					this.CrearDataTable();
					Helper.ReiniciarSession();
					this.LlenarJScript();
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
			this.CargarTipoAccionPosterior();
			this.CargarAnos();
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
			this.ibtnBuscarAreaAExaminar.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAAREACRITICA,750,500,true));

			rfvCorrelativo.ErrorMessage              = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOCORRELATIVO);
			rfvCorrelativo.ToolTip                   = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOCORRELATIVO);

			rfvDenominacion.ErrorMessage             = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDODENOMINACION);
			rfvDenominacion.ToolTip                  = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDODENOMINACION);

			rfvTipoAccionCtrlPosterior.ErrorMessage  = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOTIPOACCION);
			rfvTipoAccionCtrlPosterior.ToolTip       = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOTIPOACCION);
			rfvTipoAccionCtrlPosterior.InitialValue  = Constantes.VALORSELECCIONAR;

			rfvLineamientos.ErrorMessage             = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOLINEAMIENTOS);
			rfvLineamientos.ToolTip                  = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOLINEAMIENTOS);

			rfvObjetivo.ErrorMessage                 = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOOBJETIVO);
			rfvObjetivo.ToolTip                      = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOOBJETIVO);

			rfvMontoAExaminar.ErrorMessage           = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOMONTO);
			rfvMontoAExaminar.ToolTip                = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOMONTO);

			rfvNroHH.ErrorMessage                    = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDONROHH);
			rfvNroHH.ToolTip                         = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDONROHH);

			rfvIntegrantesOCI.ErrorMessage           = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDONROAUDOCI);
			rfvIntegrantesOCI.ToolTip                = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDONROAUDOCI);

			rfvIntegrantesEspecialistas.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDONROAUDESP);
			rfvIntegrantesEspecialistas.ToolTip      = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDONROAUDESP);

			rfvCostoOCI.ErrorMessage                 = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOCOSTOAUDOCI);
			rfvCostoOCI.ToolTip                      = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOCOSTOAUDOCI);

			rfvCostoEspecialistas.ErrorMessage       = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOCOSTOAUDESP);
			rfvCostoEspecialistas.ToolTip            = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOCOSTOAUDESP);

			rfvMeta1erTrim.ErrorMessage              = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOMETA1ER);
			rfvMeta1erTrim.ToolTip                   = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOMETA1ER);

			rfvMeta2doTrim.ErrorMessage              = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOMETA2DO);
			rfvMeta2doTrim.ToolTip                   = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOMETA2DO);

			rfvMeta3erTrim.ErrorMessage              = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOMETA3ER);
			rfvMeta3erTrim.ToolTip                   = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOMETA3ER);

			rfvMeta4toTrim.ErrorMessage              = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOMETA4TO);
			rfvMeta4toTrim.ToolTip                   = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOMETA4TO);

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
			AccionCtrlPosteriorBE oAccionCtrlPosteriorBE= new AccionCtrlPosteriorBE();

			oAccionCtrlPosteriorBE.IdTablaTipoOrgano         = Convert.ToInt32(Enumerados.TablasTabla.TipoOrgano);
			oAccionCtrlPosteriorBE.IdTipoOrgano              = Convert.ToInt32(ddlbTipOrgano.SelectedValue);
			oAccionCtrlPosteriorBE.IdTablaOrganoInformante   = Convert.ToInt32(Enumerados.TablasTabla.OrganoInformante);
			oAccionCtrlPosteriorBE.IdOrganoInformante        = Convert.ToInt32(ddlbOrganoInformante.SelectedValue);
			oAccionCtrlPosteriorBE.Ano                       = Convert.ToInt32(ddlbAno.SelectedValue);
			oAccionCtrlPosteriorBE.Correlativo               = Convert.ToInt32(txtCorrelativo.Text);
			oAccionCtrlPosteriorBE.IdTablaTipoAccionPosterior= Convert.ToInt32(Enumerados.TablasTabla.TipoAccionPosterior);
			oAccionCtrlPosteriorBE.IdTipoAccionPosterior     = Convert.ToInt32(ddlbTipoAccionCtrlPosterior.SelectedValue);
			oAccionCtrlPosteriorBE.MontoAExaminar            = Convert.ToDouble(txtMontoAExaminar.Text);
			oAccionCtrlPosteriorBE.AlcanceDesde              = CalAlcanceDesde.SelectedDate;
			oAccionCtrlPosteriorBE.AlcanceHasta              = CalAlcanceHasta.SelectedDate;
			oAccionCtrlPosteriorBE.CronogramaDesde           = CalCronogramaDesde.SelectedDate;
			oAccionCtrlPosteriorBE.CronogramaHasta           = CalCronogramaHasta.SelectedDate;
			oAccionCtrlPosteriorBE.LineamientosPoliticaCGR   = txtLineamientos.Text.ToUpper();
			oAccionCtrlPosteriorBE.IntegrantesOCI            = Convert.ToInt32(txtIntegrantesOCI.Text);
			oAccionCtrlPosteriorBE.IntegrantesEspecialistas  = Convert.ToInt32(txtIntegrantesEspecialistas.Text);
			oAccionCtrlPosteriorBE.CostoDirectoOCI           = Convert.ToDouble(txtCostoOCI.Text);
			oAccionCtrlPosteriorBE.CostoDirectoEspecialistas = Convert.ToDouble(txtCostoEspecialistas.Text);
			oAccionCtrlPosteriorBE.NroHH                     = Convert.ToDouble(txtNroHH.Text);
			oAccionCtrlPosteriorBE.Meta1erTrimestre          = Convert.ToDouble(txtMeta1erTrimestre.Text);
			oAccionCtrlPosteriorBE.Meta2doTrimestre          = Convert.ToDouble(txtMeta2doTrimestre.Text);
			oAccionCtrlPosteriorBE.Meta3erTrimestre          = Convert.ToDouble(txtMeta3erTrimestre.Text);
			oAccionCtrlPosteriorBE.Meta4toTrimestre          = Convert.ToDouble(txtMeta4toTrimestre.Text);
			oAccionCtrlPosteriorBE.Denominacion              = txtDenominacion.Text.ToUpper();
			oAccionCtrlPosteriorBE.Objetivo                  = txtObjetivo.Text.ToUpper();
			oAccionCtrlPosteriorBE.Programado                = Convert.ToInt32(Page.Request.QueryString[KEYQPRG].ToString());
			oAccionCtrlPosteriorBE.IdUsuarioRegistro         = CNetAccessControl.GetIdUser();
			oAccionCtrlPosteriorBE.IdTablaEstado             = Convert.ToInt32(Enumerados.TablasTabla.AccionCtrlPosterior);
			oAccionCtrlPosteriorBE.IdEstado                  = Convert.ToInt32(Enumerados.EstadosAccionCtrlPosterior.Activo);
			
			CAccionCtrlPosterior oCAccionCtrlPosterior = new CAccionCtrlPosterior();
			int retorno;

			retorno = oCAccionCtrlPosterior.RegistrarAccionCtrlPosterior(oAccionCtrlPosteriorBE, (DataTable)ViewState[KEYQDATATABLE]);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Detalle de Acción de Ctrl. Posterior",this.ToString(),"Se registró el Detalle de la Accion de Ctrl. Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROACCIONCTRLPOSTERIOR));
			}
		}

		public void Modificar()
		{
			AccionCtrlPosteriorBE oAccionCtrlPosteriorBE= new AccionCtrlPosteriorBE();

			oAccionCtrlPosteriorBE.IdAccionCtrlPosterior     = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oAccionCtrlPosteriorBE.IdTablaTipoOrgano         = Convert.ToInt32(Enumerados.TablasTabla.TipoOrgano);
			oAccionCtrlPosteriorBE.IdTipoOrgano              = Convert.ToInt32(ddlbTipOrgano.SelectedValue);
			oAccionCtrlPosteriorBE.IdTablaOrganoInformante   = Convert.ToInt32(Enumerados.TablasTabla.OrganoInformante);
			oAccionCtrlPosteriorBE.IdOrganoInformante        = Convert.ToInt32(ddlbOrganoInformante.SelectedValue);
			oAccionCtrlPosteriorBE.Ano                       = Convert.ToInt32(ddlbAno.SelectedValue);
			oAccionCtrlPosteriorBE.Correlativo               = Convert.ToInt32(txtCorrelativo.Text);
			oAccionCtrlPosteriorBE.IdTablaTipoAccionPosterior= Convert.ToInt32(Enumerados.TablasTabla.TipoAccionPosterior);
			oAccionCtrlPosteriorBE.IdTipoAccionPosterior     = Convert.ToInt32(ddlbTipoAccionCtrlPosterior.SelectedValue);
			oAccionCtrlPosteriorBE.MontoAExaminar            = Convert.ToDouble(txtMontoAExaminar.Text);
			oAccionCtrlPosteriorBE.AlcanceDesde              = CalAlcanceDesde.SelectedDate;
			oAccionCtrlPosteriorBE.AlcanceHasta              = CalAlcanceHasta.SelectedDate;
			oAccionCtrlPosteriorBE.CronogramaDesde           = CalCronogramaDesde.SelectedDate;
			oAccionCtrlPosteriorBE.CronogramaHasta           = CalCronogramaHasta.SelectedDate;
			oAccionCtrlPosteriorBE.LineamientosPoliticaCGR   = txtLineamientos.Text.ToUpper();
			oAccionCtrlPosteriorBE.IntegrantesOCI            = Convert.ToInt32(txtIntegrantesOCI.Text);
			oAccionCtrlPosteriorBE.IntegrantesEspecialistas  = Convert.ToInt32(txtIntegrantesEspecialistas.Text);
			oAccionCtrlPosteriorBE.CostoDirectoOCI           = Convert.ToDouble(txtCostoOCI.Text);
			oAccionCtrlPosteriorBE.CostoDirectoEspecialistas = Convert.ToDouble(txtCostoEspecialistas.Text);
			oAccionCtrlPosteriorBE.NroHH                     = Convert.ToDouble(txtNroHH.Text);
			oAccionCtrlPosteriorBE.Meta1erTrimestre          = Convert.ToDouble(txtMeta1erTrimestre.Text);
			oAccionCtrlPosteriorBE.Meta2doTrimestre          = Convert.ToDouble(txtMeta2doTrimestre.Text);
			oAccionCtrlPosteriorBE.Meta3erTrimestre          = Convert.ToDouble(txtMeta3erTrimestre.Text);
			oAccionCtrlPosteriorBE.Meta4toTrimestre          = Convert.ToDouble(txtMeta4toTrimestre.Text);
			oAccionCtrlPosteriorBE.Denominacion              = txtDenominacion.Text.ToUpper();
			oAccionCtrlPosteriorBE.Objetivo                  = txtObjetivo.Text.ToUpper();
			oAccionCtrlPosteriorBE.Programado                = Convert.ToInt32(Page.Request.QueryString[KEYQPRG].ToString());
			oAccionCtrlPosteriorBE.IdUsuarioActualizacion    = CNetAccessControl.GetIdUser();
			oAccionCtrlPosteriorBE.IdTablaEstado             = Convert.ToInt32(Enumerados.TablasTabla.AccionCtrlPosterior);
			oAccionCtrlPosteriorBE.IdEstado                  = Convert.ToInt32(Enumerados.EstadosAccionCtrlPosterior.Modificado);
			
			CAccionCtrlPosterior oCAccionCtrlPosterior = new CAccionCtrlPosterior();
			int retorno;

			retorno = oCAccionCtrlPosterior.ModificarRegistroAccionCtrlPosterior(oAccionCtrlPosteriorBE, (DataTable)ViewState[KEYQDATATABLE],((int[])ViewState[KEYQREGELIMGRUPOAREACRITICA]), ((int[])ViewState[KEYQREGELIMAREACRITICA]),Convert.ToInt32(ViewState[KEYQCODIGOINICIAL]));
			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Detalle Area Critica",this.ToString(),"Se modificó el Detalle del Área Crítica Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROACCIONCTRLPOSTERIOR));
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
			this.HabilitaAreaAExaminar(false);
			this.LlenarCombos();
		}

		public void CargarModoModificar()
		{
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR + Utilitario.Constantes.ESPACIO + Page.Request.QueryString[KEYQTIT].ToString().ToUpper();;
			this.LlenarCombos();
			
			CAccionCtrlPosterior oCAccionCtrlPosterior = new CAccionCtrlPosterior();

			AccionCtrlPosteriorBE oAccionCtrlPosteriorBE = (AccionCtrlPosteriorBE) oCAccionCtrlPosterior.DetalleAccionCtrlPosterior(Convert.ToInt32(Page.Request.QueryString[KEYQID]));

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Detalle Accion Ctrl Posterior",this.ToString(),"Se consultó el Detalle de la Accion de Ctrl. Posterior Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oAccionCtrlPosteriorBE!=null)
			{
				item = this.ddlbTipOrgano.Items.FindByValue(oAccionCtrlPosteriorBE.IdTipoOrgano.ToString());
				if(item!=null)
				{item.Selected = true;}

				item = this.ddlbOrganoInformante.Items.FindByValue(oAccionCtrlPosteriorBE.IdOrganoInformante.ToString());
				if(item!=null)
				{item.Selected = true;}
				
				item = this.ddlbAno.Items.FindByValue(oAccionCtrlPosteriorBE.Ano.ToString());
				if(item!=null)
				{item.Selected = true;}
				
				txtCorrelativo.Text   = oAccionCtrlPosteriorBE.Correlativo.ToString();
				txtDenominacion.Text  = oAccionCtrlPosteriorBE.Denominacion.ToString();

				item = this.ddlbTipoAccionCtrlPosterior.Items.FindByValue(oAccionCtrlPosteriorBE.IdTipoAccionPosterior.ToString());
				if(item!=null)
				{item.Selected = true;}

				txtMontoAExaminar.Text = oAccionCtrlPosteriorBE.MontoAExaminar.ToString();
				txtObjetivo.Text       = oAccionCtrlPosteriorBE.Objetivo.ToString();

				CalAlcanceDesde.VisibleDate      = oAccionCtrlPosteriorBE.AlcanceDesde;
				CalAlcanceDesde.SelectedDate     = oAccionCtrlPosteriorBE.AlcanceDesde;

				CalAlcanceHasta.VisibleDate      = oAccionCtrlPosteriorBE.AlcanceHasta;
				CalAlcanceHasta.SelectedDate     = oAccionCtrlPosteriorBE.AlcanceHasta;

				CalCronogramaDesde.VisibleDate   = oAccionCtrlPosteriorBE.CronogramaDesde;
				CalCronogramaDesde.SelectedDate  = oAccionCtrlPosteriorBE.CronogramaDesde;

				CalCronogramaHasta.VisibleDate   = oAccionCtrlPosteriorBE.CronogramaHasta;
				CalCronogramaHasta.SelectedDate  = oAccionCtrlPosteriorBE.CronogramaHasta;

				txtLineamientos.Text             = oAccionCtrlPosteriorBE.LineamientosPoliticaCGR;
				txtIntegrantesOCI.Text           = oAccionCtrlPosteriorBE.IntegrantesOCI.ToString();
				txtIntegrantesEspecialistas.Text = oAccionCtrlPosteriorBE.IntegrantesEspecialistas.ToString();
				txtNroHH.Text                    = oAccionCtrlPosteriorBE.NroHH.ToString();

				txtCostoOCI.Text           = oAccionCtrlPosteriorBE.CostoDirectoOCI.ToString();
				txtCostoEspecialistas.Text = oAccionCtrlPosteriorBE.CostoDirectoEspecialistas.ToString();

				txtMeta1erTrimestre.Text = oAccionCtrlPosteriorBE.Meta1erTrimestre.ToString();
				txtMeta2doTrimestre.Text = oAccionCtrlPosteriorBE.Meta2doTrimestre.ToString();
				txtMeta3erTrimestre.Text = oAccionCtrlPosteriorBE.Meta3erTrimestre.ToString();
				txtMeta4toTrimestre.Text = oAccionCtrlPosteriorBE.Meta4toTrimestre.ToString();

				CAreasAExaminar oCAreasAExaminar = new CAreasAExaminar();
				DataTable dt = oCAreasAExaminar.ListarAreasAExaminar(oAccionCtrlPosteriorBE.IdAccionCtrlPosterior);

				if(dt != null)
				{
					dt.PrimaryKey = new DataColumn[2]{dt.Columns[Enumerados.ColumnasAreasAExaminar.IdGrupoAreaCritica.ToString()],
													  dt.Columns[Enumerados.ColumnasAreasAExaminar.IdAreaCritica.ToString()]};
					this.chkTieneAreasAExaminar.Checked = true;
					this.HabilitaAreaAExaminar(true);
					this.ActualizarGrilla(dt);
				}
				else
				{
					this.chkTieneAreasAExaminar.Checked = false;
					this.HabilitaAreaAExaminar(false);
					this.CrearDataTable();
				}
				ViewState[KEYQCODIGOINICIAL]           = oCAreasAExaminar.ObtenerCantidadPorRegistroAccionCtrlPosterior(oAccionCtrlPosteriorBE.IdAccionCtrlPosterior);
				ViewState[KEYQCONTADOR]                = ViewState[KEYQCODIGOINICIAL];
				ViewState[KEYQREGELIMGRUPOAREACRITICA] = new int [Convert.ToInt32(ViewState[KEYQCONTADOR])-1];
				ViewState[KEYQREGELIMAREACRITICA]      = new int [Convert.ToInt32(ViewState[KEYQCONTADOR])-1];
				ViewState[KEYQCONTADORREGISTROSELIMINADOS] = 0;


			}
		}

		public void CargarModoConsulta()
		{

			this.CargarModoModificar();
			this.TdCeldaCancelar.Visible        = true;
			this.ibtnCancelar.Visible           = false;
			lblTitulo.Text                      = TITULOMODOCONSULTA + Utilitario.Constantes.ESPACIO + Page.Request.QueryString[KEYQTIT].ToString().ToUpper();;
			Helper.BloquearControles(this);
			this.chkTieneAreasAExaminar.Visible = false;
			this.TrCeldaAreaCritica.Visible     = false;
			this.grid.Enabled                   = true;
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
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOCORRELATIVO));
				return false;		
			}
						
			if(this.ddlbTipoAccionCtrlPosterior.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOTIPOACCION));
				return false;
			}

			if(txtDenominacion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDODENOMINACION));
				return false;		
			}

			if(txtObjetivo.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOOBJETIVO));
				return false;		
			}

			if(txtLineamientos.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOLINEAMIENTOS));
				return false;		
			}

			if(txtMontoAExaminar.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOMONTO));
				return false;		
			}

			if(txtNroHH.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDONROHH));
				return false;		
			}

			if(txtIntegrantesOCI.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDONROAUDOCI));
				return false;		
			}

			if(txtIntegrantesEspecialistas.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDONROAUDESP));
				return false;		
			}

			if(txtCostoOCI.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOCOSTOAUDOCI));
				return false;		
			}

			if(txtCostoEspecialistas.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOCOSTOAUDOCI));
				return false;		
			}

			if(txtMeta1erTrimestre.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOMETA1ER));
				return false;		
			}

			if(txtMeta2doTrimestre.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOMETA2DO));
				return false;		
			}
			if(txtMeta3erTrimestre.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOMETA3ER));
				return false;		
			}
			if(txtMeta4toTrimestre.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOMETA4TO));
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


		private void CrearDataTable()
		{
			DataTable dt = new DataTable("DataTableAreasAExaminar");
			dt.Columns.Add(Enumerados.ColumnasAreasAExaminar.IdGrupoAreaCritica.ToString());
			dt.Columns.Add(Enumerados.ColumnasAreasAExaminar.IdAreaCritica.ToString());
			dt.Columns.Add(Enumerados.ColumnasAreasAExaminar.NroGrupoAreaCritica.ToString());
			dt.Columns.Add(Enumerados.ColumnasAreasAExaminar.NroAreaCritica.ToString());
			dt.Columns.Add(Enumerados.ColumnasAreasAExaminar.NombreAreaCritica.ToString());
			dt.Columns.Add(Enumerados.ColumnasAreasAExaminar.Tipo.ToString());
			ViewState[KEYQDATATABLE] = dt;
			ViewState[KEYQCONTADOR]  = 1;
			dt.PrimaryKey = new DataColumn[2]{dt.Columns[Enumerados.ColumnasAreasAExaminar.IdGrupoAreaCritica.ToString()],
											  dt.Columns[Enumerados.ColumnasAreasAExaminar.IdAreaCritica.ToString()]};
		}

		private void HabilitaAreaAExaminar(bool valor)
		{
			this.txtNombreAreaCritica.Enabled    = valor;
			this.ibtnBuscarAreaAExaminar.Enabled = valor;
			this.grid.Enabled                    = valor;
			this.ibtnAgregar.Visible             = valor;
			this.ibtnEliminar.Visible            = valor;
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(this.ValidarCamposResponsables())
			{
				DataTable dt = ((DataTable)ViewState[KEYQDATATABLE]).Copy();
				int contador = Convert.ToInt32(ViewState[KEYQCONTADOR]);
				DataRow dr = dt.NewRow();

				Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

				switch (oModoPagina)
				{
					case Enumerados.ModoPagina.N:
					{
						dr.ItemArray = new object [5] {
													Convert.ToInt32(this.hIdGrupoAreaCritica.Value),
													Convert.ToInt32(this.hIdAreaCritica.Value),
												    this.hNroGrupoAreaCritica.Value.ToString(),
												    this.hNroAreaCritica.Value.ToString(),
													this.hNombreAreaCritica.Value.ToString()};
						break;
					}
					case Enumerados.ModoPagina.M:
					{
						dr.ItemArray = new object [6] {
													Convert.ToInt32(this.hIdGrupoAreaCritica.Value),
													Convert.ToInt32(this.hIdAreaCritica.Value),
													this.hNroGrupoAreaCritica.Value.ToString(),
													this.hNroAreaCritica.Value.ToString(),
													this.hNombreAreaCritica.Value.ToString(),
													Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Agregar)};
						break;
					}
				}
			
				dt.Rows.Add(dr);
				ViewState[KEYQCONTADOR] = ++contador;
				this.ActualizarGrilla(dt);
				this.LimpiarCamposAreasAExaminar();
			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTextoManteniendoMayusculaMinuscula("hIdGrupoAreaCritica",dr[Enumerados.ColumnasAreasAExaminar.IdGrupoAreaCritica.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTextoManteniendoMayusculaMinuscula("hIdAreaCritica",dr[Enumerados.ColumnasAreasAExaminar.IdAreaCritica.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTextoManteniendoMayusculaMinuscula("hNombreAreaCritica",dr[Enumerados.ColumnasAreasAExaminar.NombreAreaCritica.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTextoManteniendoMayusculaMinuscula("hNroGrupoAreaCritica",dr[Enumerados.ColumnasAreasAExaminar.NroGrupoAreaCritica.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTextoManteniendoMayusculaMinuscula("hNroAreaCritica",dr[Enumerados.ColumnasAreasAExaminar.NroAreaCritica.ToString()].ToString())
					);
			}
		}

		private void ibtnModificar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
//			try
//			{
//				if(this.hIdResponsableVisita.Value.Length==0)
//				{
//					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
//				}
//				else
//				{
//					if(this.ValidarCamposResponsables())
//					{
//						DataTable dt = ((DataTable)ViewState[KEYQDATATABLE]).Copy();
//						if(this.rblTipoResponsable.SelectedIndex == 0)
//						{
//							Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;
//
//							switch (oModoPagina)
//							{
//								case Enumerados.ModoPagina.N:
//								{
//									dt.Rows.Find(this.hIdResponsableVisita.Value).ItemArray = new object [9] {
//																												 Convert.ToInt32(this.hIdResponsableVisita.Value),
//																												 Constantes.VACIO,
//																												 Convert.ToInt32(this.hIdPersonal.Value),
//																												 this.txtPersonal.Text,
//																												 Convert.ToInt32(Enumerados.TablasTabla.CargoResponsablesVisitas),
//																												 Convert.ToInt32(this.ddlbCargoResponsable.SelectedValue),
//																												 this.ddlbCargoResponsable.SelectedItem.Text,
//																												 this.txtDescripcionResponsable.Text,
//																												 this.txtObservacionesResponsable.Text};
//									break;
//								}
//								case Enumerados.ModoPagina.M:
//								{
//									dt.Rows.Find(this.hIdResponsableVisita.Value).ItemArray = new object [10] {
//																												  Convert.ToInt32(this.hIdResponsableVisita.Value),
//																												  Constantes.VACIO,
//																												  Convert.ToInt32(this.hIdPersonal.Value),
//																												  this.txtPersonal.Text,
//																												  Convert.ToInt32(Enumerados.TablasTabla.CargoResponsablesVisitas),
//																												  Convert.ToInt32(this.ddlbCargoResponsable.SelectedValue),
//																												  this.ddlbCargoResponsable.SelectedItem.Text,
//																												  this.txtDescripcionResponsable.Text,
//																												  this.txtObservacionesResponsable.Text,
//																												  Convert.ToInt32(ViewState[KEYQCODIGOINICIAL])>Convert.ToInt32(this.hIdResponsableVisita.Value)?Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Modificar):Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Agregar)};
//									break;
//								}
//							}
//							
//							this.ActualizarGrilla(dt);
//							this.LimpiarCamposResponsables();
//						}
//						else
//						{
//							Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;
//
//							switch (oModoPagina)
//							{
//								case Enumerados.ModoPagina.N:
//								{
//									dt.Rows.Find(this.hIdResponsableVisita.Value).ItemArray = new object [9] {
//																												 Convert.ToInt32(this.hIdResponsableVisita.Value),
//																												 this.txtPersonal.Text,
//																												 0,
//																												 this.txtPersonal.Text,
//																												 Convert.ToInt32(Enumerados.TablasTabla.CargoResponsablesVisitas),
//																												 Convert.ToInt32(this.ddlbCargoResponsable.SelectedValue),
//																												 this.ddlbCargoResponsable.SelectedItem.Text,
//																												 this.txtDescripcionResponsable.Text,
//																												 this.txtObservacionesResponsable.Text};
//									break;
//								}
//								case Enumerados.ModoPagina.M:
//								{
//									dt.Rows.Find(this.hIdResponsableVisita.Value).ItemArray = new object [10] {
//																												  Convert.ToInt32(this.hIdResponsableVisita.Value),
//																												  this.txtPersonal.Text,
//																												  0,
//																												  this.txtPersonal.Text,
//																												  Convert.ToInt32(Enumerados.TablasTabla.CargoResponsablesVisitas),
//																												  Convert.ToInt32(this.ddlbCargoResponsable.SelectedValue),
//																												  this.ddlbCargoResponsable.SelectedItem.Text,
//																												  this.txtDescripcionResponsable.Text,
//																												  this.txtObservacionesResponsable.Text,
//																												  Convert.ToInt32(ViewState[KEYQCODIGOINICIAL])>Convert.ToInt32(this.hIdResponsableVisita.Value)?Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Modificar):Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Agregar)};
//									break;
//								}
//							}
//							
//							this.ActualizarGrilla(dt);
//							this.LimpiarCamposResponsables();
//						}
//					}
//				}
//			}
//			catch(Exception ex)
//			{
//				string a = ex.Message;
//				this.LimpiarCamposResponsables();
//			}
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(this.hIdAreaCritica.Value.Length==0)
				{
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
				}
				else
				{
					DataTable dt = ((DataTable)ViewState[KEYQDATATABLE]).Copy();
					object[] valores = new object[2]{this.hIdGrupoAreaCritica.Value, this.hIdAreaCritica.Value};
					dt.Rows.Find(valores).Delete();
					dt.AcceptChanges();
					if(Page.Request.QueryString[Constantes.KEYMODOPAGINA].ToString() == Enumerados.ModoPagina.M.ToString())
					{
						if(this.hIdAreaCritica.Value != Constantes.VACIO)
						{
							int contador = Convert.ToInt32(ViewState[KEYQCONTADORREGISTROSELIMINADOS]);
							((int[])ViewState[KEYQREGELIMGRUPOAREACRITICA])[contador]  = Convert.ToInt32(this.hIdGrupoAreaCritica.Value);
							((int[])ViewState[KEYQREGELIMAREACRITICA])[contador]       = Convert.ToInt32(this.hIdAreaCritica.Value);
							ViewState[KEYQCONTADORREGISTROSELIMINADOS] = ++contador;
						}
					}
					this.ActualizarGrilla(dt);
					this.LimpiarCamposAreasAExaminar();
				}
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				this.LimpiarCamposAreasAExaminar();
			}
		}

		private void LimpiarCamposAreasAExaminar()
		{
			this.txtNombreAreaCritica.Text  = Constantes.VACIO;
			this.hIdGrupoAreaCritica.Value  = Constantes.VACIO;
			this.hIdAreaCritica.Value       = Constantes.VACIO;
			this.hNroGrupoAreaCritica.Value = Constantes.VACIO;
			this.hNroAreaCritica.Value      = Constantes.VACIO;
			this.hNombreAreaCritica.Value   = Constantes.VACIO;
		}

		private bool ValidarCamposResponsables()
		{
			if(this.hIdAreaCritica.Value == String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIORCAMPOREQUERIDOAREACRITICA));
				return false;
			}
			return true;
		}

		private void ActualizarGrilla(DataTable dt)
		{
			ViewState[KEYQDATATABLE] = dt;

			if(ViewState[KEYQDATATABLE] != null)
			{
				this.grid.DataSource = dt;
				this.grid.Visible = true;
			}
			else
			{
				this.grid.DataSource = null;
				this.grid.Visible = false;
			}
			this.grid.DataBind();
		}

		private void OcultarCamposAreasAExaminar()
		{
			this.txtNombreAreaCritica.Visible = false;
			this.ibtnBuscarAreaAExaminar.Visible = false;
		}

		private void chkTieneAreasAExaminar_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.chkTieneAreasAExaminar.Checked == true)
			{
				this.HabilitaAreaAExaminar(true);
			}
			else
			{
				this.HabilitaAreaAExaminar(false);
			}

		}


	}
}
