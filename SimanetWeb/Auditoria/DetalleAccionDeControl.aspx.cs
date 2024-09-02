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
using SIMA.Controladoras.Auditoria;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.Auditoria;
using NetAccessControl;
using NullableTypes;





namespace SIMA.SimaNetWeb.Auditoria
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class DetalleAccionDeControl: System.Web.UI.Page,IPaginaBase//,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblAccion;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodoFiltro;
		protected System.Web.UI.WebControls.DropDownList ddlbAccion;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblCodigo;
		protected System.Web.UI.WebControls.TextBox txtCodigo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCodigo;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPeriodo;
		protected System.Web.UI.WebControls.Label lblUnidadMedida;
		protected System.Web.UI.WebControls.DropDownList ddlbUnidadMedida;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvUnidadMedida;
		protected System.Web.UI.WebControls.Label lblPorcentajeAvance;
		protected eWorld.UI.NumericBox txtPorcentajeAvance;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPorcentajeAvance;
		protected System.Web.UI.WebControls.Label lblDenominacion;
		protected System.Web.UI.WebControls.TextBox txtDenominacion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDenominacion;
		protected System.Web.UI.WebControls.Label lblObservacion;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.Label lblMontoAuditar;
		protected eWorld.UI.NumericBox txtMontoAuditar;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMontoAuditar;
		protected System.Web.UI.WebControls.Label lblCosto;
		protected eWorld.UI.NumericBox txtCosto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCosto;
		protected System.Web.UI.WebControls.Label lblNroIntegrantes;
		protected eWorld.UI.NumericBox txtNroIntegrantes;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroIntegrantes;
		protected System.Web.UI.WebControls.Label Label2;
		protected eWorld.UI.NumericBox txtNroHorasHombre;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroHorasHombre;
		protected System.Web.UI.WebControls.Label lblObjetivo;
		protected System.Web.UI.WebControls.TextBox txtObjetivo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvObjetivo;
		protected System.Web.UI.WebControls.Label lblAreasExaminar;
		protected System.Web.UI.WebControls.TextBox txtAreasExaminar;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvAreasExaminar;
		protected System.Web.UI.WebControls.Label lblLineamientos;
		protected System.Web.UI.WebControls.TextBox txtLineamientos;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvLineamientos;
		protected System.Web.UI.WebControls.Label lblSubTituloFechas;
		protected System.Web.UI.WebControls.Label lblSubTituloFechasCronograma;
		protected System.Web.UI.WebControls.Label lblFechaInicio;
		protected System.Web.UI.WebControls.Label lblFechaFin;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected eWorld.UI.CalendarPopup CalFechaFin;
		protected System.Web.UI.WebControls.Label lblFechaInicioCronograma;
		protected System.Web.UI.WebControls.Label lblFechaFinCronograma;
		protected eWorld.UI.CalendarPopup CalFechaInicioCronograma;
		protected eWorld.UI.CalendarPopup CalFechaFinCronograma;
		protected System.Web.UI.WebControls.Label lblMetas;
		protected System.Web.UI.WebControls.Label lblCronograma;
		protected System.Web.UI.WebControls.Button btnAgregarMeta;
		protected System.Web.UI.WebControls.DataGrid grid;
		protected System.Web.UI.WebControls.CheckBox cbxEnero;
		protected System.Web.UI.WebControls.CheckBox cbxFebrero;
		protected System.Web.UI.WebControls.CheckBox cbxMarzo;
		protected System.Web.UI.WebControls.CheckBox cbxAbril;
		protected System.Web.UI.WebControls.CheckBox cbxMayo;
		protected System.Web.UI.WebControls.CheckBox cbxJunio;
		protected System.Web.UI.WebControls.CheckBox cbxJulio;
		protected System.Web.UI.WebControls.CheckBox cbxAgosto;
		protected System.Web.UI.WebControls.CheckBox cbxSeptiembre;
		protected System.Web.UI.WebControls.CheckBox cbxOctubre;
		protected System.Web.UI.WebControls.CheckBox cbxNoviembre;
		protected System.Web.UI.WebControls.CheckBox cbxDiciembre;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAtras;
		protected System.Web.UI.HtmlControls.HtmlTable tDetalle;
		#endregion Controles

		#region Constantes
		
		const string CONTROLCALENDARIO = "calFecha";
		const string CONTROLTXT = "txt";
		const string CONTROLCHECKBOX = "cbxEliminar";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYSDT = "dt";
		
	
		//Paginas
		const string URLPRINCIPAL = "..\\\\Default.aspx";
		const string URLANTERIOR  = "..\\Default.aspx";
		#endregion Constantes

		ListItem lItem;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					this.LlenarJScript();

					this.llenarCombosFiltro();	

					tDetalle.Visible = false;
					
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

		
		
		/// <summary>
		/// Llena el combo de Periodo del Filtro
		/// </summary>
		private void llenarCombosFiltro()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbPeriodoFiltro.DataSource = Helper.ObtenerPeriodos(1999,DateTime.Now.Year);
			ddlbPeriodoFiltro.DataBind();
			ddlbPeriodoFiltro.Items.Insert(0,lItem);

			ddlbAccion.Items.Insert(0,lItem);

		}

		/// <summary>
		/// Llena el combo de Periodo
		/// </summary>
		private void llenarPeriodos()
		{
			
			ddlbPeriodo.DataSource = Helper.ObtenerPeriodos(1999,DateTime.Now.Year);
			ddlbPeriodo.DataBind();
			ddlbPeriodo.Items.Insert(0,lItem);

		}

		/// <summary>
		/// Llena el combo de Unidades de Medida
		/// </summary>
		private void llenarUnidadesMedida()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();
			ddlbUnidadMedida.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.AuditoriaUnidadMedidaAuditoria));
			ddlbUnidadMedida.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbUnidadMedida.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbUnidadMedida.DataBind();
			ddlbUnidadMedida.Items.Insert(0,lItem);

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
			this.ddlbPeriodoFiltro.SelectedIndexChanged += new System.EventHandler(this.ddlbPeriodoFiltro_SelectedIndexChanged);
			this.ddlbAccion.SelectedIndexChanged += new System.EventHandler(this.ddlbAccion_SelectedIndexChanged);
			this.btnAgregarMeta.Click += new System.EventHandler(this.btnAgregarMeta_Click);
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemCreated);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.ibtnCancelar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCancelar_Click);
			this.ibtnAtras.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAtras_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			grid.DataSource = dtMetas;
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);

			this.llenarPeriodos();
			this.llenarUnidadesMedida();
			
		}

		DataTable dtMetas;

		public void LlenarDatos()
		{
			
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			ProgramacionAuditoriaBE oProgramacionAuditoriaBE = (ProgramacionAuditoriaBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(ddlbAccion.SelectedValue),Enumerados.ClasesNTAD.ProgramacionAuditoriaNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó el Detalle de la Acción de Control Nro. " + ddlbAccion.SelectedValue + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oProgramacionAuditoriaBE !=null)
			{
				this.crearEstructuraDataTable();

				txtCodigo.Text = oProgramacionAuditoriaBE.Codigo;
				ddlbPeriodo.Items.FindByValue(oProgramacionAuditoriaBE.Periodo).Selected = true;
				ddlbUnidadMedida.Items.FindByValue(oProgramacionAuditoriaBE.IdUnidadMedida.ToString()).Selected = true;


				txtPorcentajeAvance.Text = oProgramacionAuditoriaBE.PorcentajeAvance.ToString();

				txtDenominacion.Text = oProgramacionAuditoriaBE.Denominacion;

				if(!oProgramacionAuditoriaBE.Observacion.IsNull)
				{
					txtObservacion.Text = oProgramacionAuditoriaBE.Observacion.Value;
				}
			
				cbxEnero.Checked = Helper.ObtenerValorBool(oProgramacionAuditoriaBE.FlgEnero);
				cbxFebrero.Checked = Helper.ObtenerValorBool(oProgramacionAuditoriaBE.FlgFebrero);
				cbxMarzo.Checked = Helper.ObtenerValorBool(oProgramacionAuditoriaBE.FlgMarzo);
				cbxAbril.Checked = Helper.ObtenerValorBool(oProgramacionAuditoriaBE.FlgAbril);
				cbxMayo.Checked = Helper.ObtenerValorBool(oProgramacionAuditoriaBE.FlgMayo);
				cbxJunio.Checked =Helper.ObtenerValorBool(oProgramacionAuditoriaBE.FlgJunio);
				cbxJulio.Checked = Helper.ObtenerValorBool(oProgramacionAuditoriaBE.FlgJulio);
				cbxAgosto.Checked = Helper.ObtenerValorBool(oProgramacionAuditoriaBE.FlgAgosto);
				cbxSeptiembre.Checked = Helper.ObtenerValorBool(oProgramacionAuditoriaBE.FlgSeptiembre);
				cbxOctubre.Checked = Helper.ObtenerValorBool(oProgramacionAuditoriaBE.FlgOctubre);
				cbxNoviembre.Checked = Helper.ObtenerValorBool(oProgramacionAuditoriaBE.FlgNoviembre);
				cbxDiciembre.Checked = Helper.ObtenerValorBool(oProgramacionAuditoriaBE.FlgDiciembre);

				txtPorcentajeAvance.Text = oProgramacionAuditoriaBE.PorcentajeAvance.ToString();

			
				if(!oProgramacionAuditoriaBE.MontoAuditar.IsNull)
				{
					txtMontoAuditar.Text = oProgramacionAuditoriaBE.MontoAuditar.Value.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}

				if(!oProgramacionAuditoriaBE.Costo.IsNull)
				{
					txtCosto.Text = oProgramacionAuditoriaBE.Costo.Value.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}

				if(!oProgramacionAuditoriaBE.NroIntegrantes.IsNull)
				{
					txtNroIntegrantes.Text = oProgramacionAuditoriaBE.NroIntegrantes.Value.ToString();
				}

				if(!oProgramacionAuditoriaBE.NroHorasHombre.IsNull)
				{
					txtNroHorasHombre.Text = oProgramacionAuditoriaBE.NroHorasHombre.Value.ToString();
				}

				if(!oProgramacionAuditoriaBE.FechaInicio.IsNull)
				{
					CalFechaInicio.VisibleDate = oProgramacionAuditoriaBE.FechaInicio.Value;
					CalFechaInicio.SelectedDate = oProgramacionAuditoriaBE.FechaInicio.Value;
				}

				if(!oProgramacionAuditoriaBE.FechaFin.IsNull)
				{
					CalFechaFin.VisibleDate = oProgramacionAuditoriaBE.FechaFin.Value;
					CalFechaFin.SelectedDate = oProgramacionAuditoriaBE.FechaFin.Value;
				}

				if(!oProgramacionAuditoriaBE.FechaInicioCronograma.IsNull)
				{
					CalFechaInicioCronograma.VisibleDate = oProgramacionAuditoriaBE.FechaInicioCronograma.Value;
					CalFechaInicioCronograma.SelectedDate = oProgramacionAuditoriaBE.FechaInicioCronograma.Value;
				}

				if(!oProgramacionAuditoriaBE.FechaFinCronograma.IsNull)
				{
					CalFechaFinCronograma.VisibleDate = oProgramacionAuditoriaBE.FechaFinCronograma.Value;
					CalFechaFinCronograma.SelectedDate = oProgramacionAuditoriaBE.FechaFinCronograma.Value;
				}

				if(!oProgramacionAuditoriaBE.Objetivo.IsNull)
				{
					txtObjetivo.Text = oProgramacionAuditoriaBE.Objetivo.Value.ToString();
				}

				if(!oProgramacionAuditoriaBE.AreasExaminar.IsNull)
				{
					txtAreasExaminar.Text = oProgramacionAuditoriaBE.AreasExaminar.Value.ToString();
				}

				if(!oProgramacionAuditoriaBE.AreasExaminar.IsNull)
				{
					txtLineamientos.Text = oProgramacionAuditoriaBE.Lineamientos.Value.ToString();
				}

				CProgramacionAuditoria oCProgramacionAuditoria = new CProgramacionAuditoria();
				dtMetas = oCProgramacionAuditoria.ListarMetasAccionControl(oProgramacionAuditoriaBE.IdProgramacionAuditoria);
				
				if(dtMetas!=null)
				{
					Session[KEYSDT] = dtMetas;
					this.LlenarGrilla();
				}


			}
			
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation

			/*rfvCodigo.ErrorMessage =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOCODIGO);
			rfvCodigo.ToolTip =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOCODIGO);

			rfvPeriodo.ErrorMessage =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOPERIODO);
			rfvPeriodo.ToolTip =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOPERIODO);

			rfvUnidadMedida.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOUNIDADMEDIDA);
			rfvUnidadMedida.ToolTip =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOUNIDADMEDIDA);

			rfvPorcentajeAvance.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOPORCENTAJEAVANCE);
			rfvPorcentajeAvance.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOPORCENTAJEAVANCE);


			rfvDenominacion.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDODENOMINACION);
			rfvDenominacion.ToolTip =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDODENOMINACION);

			rfvMontoAuditar.ErrorMessage =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOMONTOAUDITAR);
			rfvMontoAuditar.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOMONTOAUDITAR);

			rfvCosto.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOCOSTO);
			rfvCosto.ToolTip =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOCOSTO);

			rfvNroIntegrantes.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDONROINTEGRANTES);
			rfvNroIntegrantes.ToolTip =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDONROINTEGRANTES);

			rfvNroHorasHombre.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDONROHORASHOMBRE);
			rfvNroHorasHombre.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDONROHORASHOMBRE);

			rfvObjetivo.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOOBJETIVO);
			rfvObjetivo.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOOBJETIVO);

			rfvAreasExaminar.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOAREASEXAMINAR);
			rfvAreasExaminar.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOAREASEXAMINAR);

			rfvLineamientos.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOLINEAMIENTOS);
			rfvLineamientos.ToolTip =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOLINEAMIENTOS);
*/
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultaDeCartasFianzas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaDeCartasFianzas.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultaDeCartasFianzas.ConfigurarAccesoControles implementation

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
			
		}

		public void Modificar()
		{
			ProgramacionAuditoriaBE oProgramacionAuditoriaBE = new ProgramacionAuditoriaBE();
			
			oProgramacionAuditoriaBE.IdProgramacionAuditoria = Convert.ToInt32(ddlbAccion.SelectedValue);
			oProgramacionAuditoriaBE.Codigo = txtCodigo.Text;
			oProgramacionAuditoriaBE.Denominacion = txtDenominacion.Text;
			
			if(txtObservacion.Text.Trim()!=String.Empty)
			{
				oProgramacionAuditoriaBE.Observacion = txtObservacion.Text;
			}
			else
			{
				oProgramacionAuditoriaBE.Observacion = NullableString.Null; 
			}
			
			oProgramacionAuditoriaBE.IdTablaUnidadMedida = Convert.ToInt32(Enumerados.TablasTabla.AuditoriaUnidadMedidaAuditoria);
			oProgramacionAuditoriaBE.IdUnidadMedida = Convert.ToInt32(ddlbUnidadMedida.SelectedValue);
			oProgramacionAuditoriaBE.Periodo = ddlbPeriodo.SelectedValue;
			oProgramacionAuditoriaBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			
			if(txtPorcentajeAvance.Text.Trim()!=String.Empty)
			{
				oProgramacionAuditoriaBE.PorcentajeAvance = Convert.ToDouble(txtPorcentajeAvance.Text);
			}
			
			oProgramacionAuditoriaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.AuditoriaEstadoProgramacionAuditoria);
			
			if(oProgramacionAuditoriaBE.PorcentajeAvance > 0)
			{
				oProgramacionAuditoriaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosProgramacionAuditoria.Proceso);
			}
			else if(oProgramacionAuditoriaBE.PorcentajeAvance == 100)
			{
				oProgramacionAuditoriaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosProgramacionAuditoria.Ejecutada);
				
			}
			else if(oProgramacionAuditoriaBE.PorcentajeAvance == 0)
			{
				oProgramacionAuditoriaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosProgramacionAuditoria.Pendiente);
			}


			if(txtMontoAuditar.Text !=String.Empty)
			{
				oProgramacionAuditoriaBE.MontoAuditar = Convert.ToDouble(txtMontoAuditar.Text);
			}

			if(txtCosto.Text !=String.Empty)
			{
				oProgramacionAuditoriaBE.Costo  = Convert.ToDouble(txtCosto.Text);
			}

			if(txtNroIntegrantes.Text !=String.Empty)
			{
				oProgramacionAuditoriaBE.NroIntegrantes = Convert.ToInt32(txtNroIntegrantes.Text);;
			}

			if(txtNroHorasHombre.Text !=String.Empty)
			{
				oProgramacionAuditoriaBE.NroHorasHombre = Convert.ToDouble(txtNroHorasHombre.Text);
			}

			oProgramacionAuditoriaBE.FechaInicio = CalFechaInicio.SelectedDate;
			oProgramacionAuditoriaBE.FechaFin = CalFechaFin.SelectedDate;
			oProgramacionAuditoriaBE.FechaInicioCronograma = CalFechaInicioCronograma .SelectedDate;
			oProgramacionAuditoriaBE.FechaFinCronograma  = CalFechaFinCronograma .SelectedDate;
			
			if(txtObjetivo.Text!=String.Empty)
			{
				oProgramacionAuditoriaBE.Objetivo = txtObjetivo.Text;
			}

			if(txtAreasExaminar.Text!=String.Empty)
			{
				oProgramacionAuditoriaBE.AreasExaminar = txtAreasExaminar.Text;
			}

			if(txtLineamientos.Text!=String.Empty)
			{
				oProgramacionAuditoriaBE.Lineamientos = txtLineamientos.Text;
			}

			
			oProgramacionAuditoriaBE.FlgEnero = Helper.ObtenerValorString(cbxEnero.Checked);
			oProgramacionAuditoriaBE.FlgFebrero = Helper.ObtenerValorString(cbxFebrero.Checked);
			oProgramacionAuditoriaBE.FlgMarzo = Helper.ObtenerValorString(cbxMarzo.Checked);
			oProgramacionAuditoriaBE.FlgAbril = Helper.ObtenerValorString(cbxAbril.Checked);
			oProgramacionAuditoriaBE.FlgMayo = Helper.ObtenerValorString(cbxMayo.Checked);
			oProgramacionAuditoriaBE.FlgJunio = Helper.ObtenerValorString(cbxJunio.Checked);
			oProgramacionAuditoriaBE.FlgJulio = Helper.ObtenerValorString(cbxJulio.Checked);
			oProgramacionAuditoriaBE.FlgAgosto = Helper.ObtenerValorString(cbxAgosto.Checked);
			oProgramacionAuditoriaBE.FlgSeptiembre = Helper.ObtenerValorString(cbxSeptiembre.Checked);
			oProgramacionAuditoriaBE.FlgOctubre = Helper.ObtenerValorString(cbxOctubre.Checked);
			oProgramacionAuditoriaBE.FlgNoviembre = Helper.ObtenerValorString(cbxNoviembre.Checked);
			oProgramacionAuditoriaBE.FlgDiciembre = Helper.ObtenerValorString(cbxDiciembre.Checked);

			CProgramacionAuditoria oCProgramacionAuditoria = new CProgramacionAuditoria();

			//ProgramacionAuditoriaLN oProgramacionAuditoriaLN = new ProgramacionAuditoriaLN();
			
			this.actualizarDataTable();

			if(oCProgramacionAuditoria.ModificarAccionControl(oProgramacionAuditoriaBE,(DataTable)Session[KEYSDT])>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se modificó la Acción de Control Nro. " + ddlbAccion.SelectedValue + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONACCIONCONTROL),URLPRINCIPAL);
			
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleCuentasBancaria.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			
			
		}
		


		public void CargarModoNuevo()
		{
			
		}

		public void CargarModoModificar()
		{
			
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleCuentasBancaria.CargarModoConsulta implementation
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
//			if(txtCodigo.Text.Trim()==String.Empty)
//			{
//				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOCODIGO));
//				return false;		
//			}
//
//			if(ddlbPeriodo.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
//			{
//				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOPERIODO));
//				return false;		
//			}
//
//			if(ddlbUnidadMedida.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
//			{
//				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOUNIDADMEDIDA));
//				return false;		
//			}
//
//			
//			if(txtDenominacion.Text.Trim()==String.Empty)
//			{
//				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDODENOMINACION));
//				return false;		
//			}
//
//			if(txtPorcentajeAvance.Text.Trim()==String.Empty)
//			{
//				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOPORCENTAJEAVANCE));
//				return false;	
//			}
//
//			if(txtMontoAuditar.Text.Trim()==String.Empty)
//			{
//				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOMONTOAUDITAR));
//				return false;	
//			}
//
//			if(txtCosto.Text.Trim()==String.Empty)
//			{
//				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOCOSTO));
//				return false;	
//			}
//
//			if(txtNroIntegrantes.Text.Trim()==String.Empty)
//			{
//				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDONROINTEGRANTES));
//				return false;	
//			}
//
//			if(txtNroHorasHombre.Text.Trim()==String.Empty)
//			{
//				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDONROHORASHOMBRE));
//				return false;	
//			}
//
//			if(txtObjetivo.Text.Trim()==String.Empty)
//			{
//				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOOBJETIVO));
//				return false;	
//			}
//
//			if(txtAreasExaminar.Text.Trim()==String.Empty)
//			{
//				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOAREASEXAMINAR));
//				return false;	
//			}
//
//			if(txtLineamientos.Text.Trim()==String.Empty)
//			{
//				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLCAMPOREQUERIDOLINEAMIENTOS));
//				return false;	
//			}

			int acumPorcentajeAvence = 0;
			bool validacionPorcentajeAvance = false;
			
			foreach(DataGridItem item in grid.Items)
			{
							
				eWorld.UI.NumericBox txt = (eWorld.UI.NumericBox)item.Cells[2].FindControl(CONTROLTXT);
				
				if(Convert.ToInt32(txt.Text) ==0)
				{
					
					validacionPorcentajeAvance = true;
				}
				else
				{
					acumPorcentajeAvence = acumPorcentajeAvence + Convert.ToInt32(txt.Text);
				}
			}

			txtPorcentajeAvance.Text = acumPorcentajeAvence.ToString();
			
			if(validacionPorcentajeAvance)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDOPORCENTAJEAVANCEMETA));
				return false;
			}

			if(acumPorcentajeAvence>100)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORDATOSINCORRECTOSPORCENTAJEAVANCEMAYOR100));
				return false;
			}
			
			
			

			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(txtPorcentajeAvance.Text)))
			{
				ltlMensaje.Text =  ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLDATOSINCORRECTOSNUMEROSPORCENTAJEAVANCE));
				return false;
			}

			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(txtMontoAuditar.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Mensajes.CODIGOMENSAJEACCIONDECONTROLDATOSINCORRECTOSNUMEROSMONTOAUDITAR);
				return false;
			}

			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(txtCosto.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Mensajes.CODIGOMENSAJEACCIONDECONTROLDATOSINCORRECTOSNUMEROSCOSTO);
				return false;
			}

			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(txtNroIntegrantes.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Mensajes.CODIGOMENSAJEACCIONDECONTROLDATOSINCORRECTOSNUMEROSNROINTEGRANTES);
				return false;
			}

			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(txtNroHorasHombre.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Mensajes.CODIGOMENSAJEACCIONDECONTROLDATOSINCORRECTOSNUMEROSNROHORASHOMBRE);
				return false;
			}


			
			
			return true;
		}

		#endregion


		private void ReiniciarCampos()
		{
			txtAreasExaminar.Text    = Utilitario.Constantes.VACIO;
			txtCodigo.Text           = Utilitario.Constantes.VACIO;
			txtDenominacion.Text     = Utilitario.Constantes.VACIO;
			txtLineamientos.Text     = Utilitario.Constantes.VACIO;
			txtMontoAuditar.Text     = Utilitario.Constantes.VACIO;
			txtNroHorasHombre.Text   = Utilitario.Constantes.VACIO;
			txtNroIntegrantes.Text   = Utilitario.Constantes.VACIO;
			txtObjetivo.Text         = Utilitario.Constantes.VACIO;
			txtPorcentajeAvance.Text = Utilitario.Constantes.VACIO;
		}

		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

		private void llenarAccionesProceso()
		{
			CProgramacionAuditoria oCProgramacionAuditoria = new CProgramacionAuditoria();
			ddlbAccion.Items.Clear();
			ddlbAccion.DataSource = oCProgramacionAuditoria.ListarAccionControlrocesoPorPeriodo(ddlbPeriodoFiltro.SelectedValue);
			ddlbAccion.DataTextField = Enumerados.ColumnasProgramacionAuditoria.Codigo.ToString();
			ddlbAccion.DataValueField = Enumerados.ColumnasProgramacionAuditoria.IdProgramacionAuditoria.ToString();
			ddlbAccion.DataBind();
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbAccion.Items.Insert(0,lItem);
		}

		

	
		private void Eliminar(object sender, System.EventArgs e)
		{
			this.actualizarDataTable();
			dtMetas = (DataTable)Session[KEYSDT];

			CheckBox chk = (CheckBox) sender;

			double acumulador = 0;
			
			foreach(DataRow dr in dtMetas.Rows)
			{
				acumulador = acumulador + Convert.ToDouble(dr[Enumerados.ColumnasProgramacionAuditoriaMeta.PorcAvance.ToString()]) ;

				if(Convert.ToInt32(dr[Enumerados.ColumnasProgramacionAuditoriaMeta.IdProgramacionAuditoriaMeta.ToString()])== Convert.ToInt32(chk.Attributes[KEYQID]))
				{
					acumulador = acumulador - Convert.ToDouble(dr[Enumerados.ColumnasProgramacionAuditoriaMeta.PorcAvance.ToString()]);
					
					dr.Delete();
					
					Session[KEYSDT] = dtMetas;
					
				}
			}

			dtMetas.AcceptChanges();

			this.LlenarGrilla();

			txtPorcentajeAvance.Text = Convert.ToString(acumulador);
		}
		
		private void crearEstructuraDataTable()
		{
			dtMetas = new DataTable();
			dtMetas.Columns.Add(new DataColumn(Enumerados.ColumnasProgramacionAuditoriaMeta.IdProgramacionAuditoriaMeta.ToString(), typeof(int)));
			dtMetas.Columns.Add(new DataColumn(Enumerados.ColumnasProgramacionAuditoriaMeta.Fecha.ToString(), typeof(DateTime)));
			dtMetas.Columns.Add(new DataColumn(Enumerados.ColumnasProgramacionAuditoriaMeta.PorcAvance.ToString(), typeof(double)));
			Session[KEYSDT] = dtMetas;
		}

		

		private void actualizarDataTable()
		{
			dtMetas = (DataTable)Session[KEYSDT];
			dtMetas.Rows.Clear();

			foreach(DataGridItem item in grid.Items)
			{
				DataRow dr;
				dr = dtMetas.NewRow();
				
				dr[Enumerados.ColumnasProgramacionAuditoriaMeta.IdProgramacionAuditoriaMeta.ToString()] = Convert.ToInt32(item.Cells[0].Text);
				
				eWorld.UI.CalendarPopup cal = (eWorld.UI.CalendarPopup)item.Cells[1].FindControl(CONTROLCALENDARIO);
				dr[Enumerados.ColumnasProgramacionAuditoriaMeta.Fecha.ToString()] = cal.SelectedDate;
					
				eWorld.UI.NumericBox txt = (eWorld.UI.NumericBox)item.Cells[2].FindControl(CONTROLTXT);
				dr[Enumerados.ColumnasProgramacionAuditoriaMeta.PorcAvance.ToString()] = Convert.ToDouble(txt.Text);
				
				dtMetas.Rows.Add(dr);
				
			}
			dtMetas.AcceptChanges();
		}
		private void agregarFilaGrid()
		{
			DataRow dr;
			this.actualizarDataTable();
			dr = dtMetas.NewRow();
						
			dr[Enumerados.ColumnasProgramacionAuditoriaMeta.IdProgramacionAuditoriaMeta.ToString()] = new Random().Next().ToString();
			dr[Enumerados.ColumnasProgramacionAuditoriaMeta.Fecha.ToString()] = DateTime.Now;
			dr[Enumerados.ColumnasProgramacionAuditoriaMeta.PorcAvance.ToString()] = 0;

			dtMetas.Rows.Add(dr);

			dtMetas.AcceptChanges();
			Session[KEYSDT] = dtMetas;
			this.LlenarGrilla();
			
		}

		
		private void btnAgregarMeta_Click(object sender, System.EventArgs e)
		{
			this.agregarFilaGrid();
		}

		private void ddlbPeriodoFiltro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ddlbPeriodoFiltro.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				this.llenarAccionesProceso();
			}
			else
			{
				lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
				ddlbAccion.Items.Clear();
				ddlbAccion.Items.Insert(0,lItem);
				tDetalle.Visible = false;
			}
		}

		private void ddlbAccion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[KEYSDT] = null;
			this.LlenarGrilla();
			

			if(ddlbAccion.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				this.ReiniciarCampos();
				this.LlenarDatos();
				tDetalle.Visible = true;
			}
			else
			{
				tDetalle.Visible = false;
			}
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						this.Modificar();
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				CheckBox cbkEliminar = (CheckBox)e.Item.Cells[3].FindControl(CONTROLCHECKBOX);
				cbkEliminar.CheckedChanged += new EventHandler(Eliminar);
			
			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				eWorld.UI.CalendarPopup cal = (eWorld.UI.CalendarPopup)e.Item.Cells[1].FindControl(CONTROLCALENDARIO);
				cal.SelectedDate = Convert.ToDateTime(dr[Enumerados.ColumnasProgramacionAuditoriaMeta.Fecha.ToString()]);
				
				eWorld.UI.NumericBox txt = (eWorld.UI.NumericBox)e.Item.Cells[2].FindControl(CONTROLTXT);
				txt.Text = dr[Enumerados.ColumnasProgramacionAuditoriaMeta.PorcAvance.ToString()].ToString();
				txt.Attributes.Add(Utilitario.Constantes.EVENTOONBLUR,"calculaSumaMontosGrid('txt','txtPorcentajeAvance')");
				CheckBox cbkEliminar = (CheckBox)e.Item.Cells[3].FindControl(CONTROLCHECKBOX);
				cbkEliminar.Attributes.Add(KEYQID,dr[Enumerados.ColumnasProgramacionAuditoriaMeta.IdProgramacionAuditoriaMeta.ToString()].ToString());
			}	
		}

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLANTERIOR);			
		}

		private void ibtnAtras_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLANTERIOR);
		}
	}
}

