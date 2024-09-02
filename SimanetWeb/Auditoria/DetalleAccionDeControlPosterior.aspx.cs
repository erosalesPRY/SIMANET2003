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
	public class DetalleAccionDeControlPosterior: System.Web.UI.Page,IPaginaBase//,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDestino;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblCodigo;
		protected System.Web.UI.WebControls.TextBox txtCodigo;
		protected System.Web.UI.WebControls.Label lblUnidadMedida;
		protected System.Web.UI.WebControls.DropDownList ddlbUnidadMedida;
		protected System.Web.UI.WebControls.Label lblPorcentajeAvance;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
		protected System.Web.UI.WebControls.Label lblDenominacion;
		protected System.Web.UI.WebControls.TextBox txtDenominacion;
		protected System.Web.UI.WebControls.Label lblObservacion;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodoFiltro;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbAccion;
		protected System.Web.UI.WebControls.Label lblAccion;
		protected System.Web.UI.HtmlControls.HtmlTable tDetalle;
		protected System.Web.UI.WebControls.DataGrid grid;
		protected System.Web.UI.WebControls.Button btnAgregarMeta;
		protected eWorld.UI.NumericBox txtPorcentajeAvance;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCodigo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPeriodo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvUnidadMedida;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPorcentajeAvance;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDenominacion;
		protected System.Web.UI.WebControls.Label lblMetas;
		protected System.Web.UI.WebControls.Label lblCronograma;
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
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAtras;
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
			this.txtDenominacion.TextChanged += new System.EventHandler(this.txtDenominacion_TextChanged);
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

				txtPorcentajeAvance.Text = oProgramacionAuditoriaBE.PorcentajeAvance.ToString(Utilitario.Constantes.FORMATODECIMAL2);

				

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

			rfvCodigo.ErrorMessage =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDOCODIGO);
			rfvCodigo.ToolTip =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDOCODIGO);

			rfvPeriodo.ErrorMessage =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDOPERIODO);
			rfvPeriodo.ToolTip =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDOPERIODO);

			rfvUnidadMedida.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDOUNIDADMEDIDA);
			rfvUnidadMedida.ToolTip =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDOUNIDADMEDIDA);

			rfvPorcentajeAvance.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDOPORCENTAJEAVANCE);
			rfvPorcentajeAvance.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDOPORCENTAJEAVANCE);


			rfvDenominacion.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDODENOMINACION);
			rfvDenominacion.ToolTip =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDODENOMINACION);
		
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
			
			this.actualizarDataTable();

			if(oCProgramacionAuditoria.ModificarAccionControl(oProgramacionAuditoriaBE,(DataTable)Session[KEYSDT])>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se modificó la Acción Posterior Nro. " + ddlbAccion.SelectedValue + ".",Enumerados.NivelesErrorLog.I.ToString()));


				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONACCIONCONTROLPOSTERIOR),URLPRINCIPAL);
			
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
			if(txtCodigo.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDOCODIGO));
				return false;		
			}

			if(ddlbPeriodo.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDOPERIODO));
				return false;		
			}

			if(ddlbUnidadMedida.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDOUNIDADMEDIDA));
				return false;		
			}

			
			if(txtDenominacion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDODENOMINACION));
				return false;		
			}

			if(txtPorcentajeAvance.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDOPORCENTAJEAVANCE));
				return false;	
			}

			
			int acumPorcentajeAvence = 0;
		
			foreach(DataGridItem item in grid.Items)
			{
							
				eWorld.UI.NumericBox txt = (eWorld.UI.NumericBox)item.Cells[2].FindControl(CONTROLTXT);
				
				if(Convert.ToInt32(txt.Text) ==0)
				{
					ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORCAMPOREQUERIDOPORCENTAJEAVANCEMETA));
					return false;
				}
				else
				{
					acumPorcentajeAvence = acumPorcentajeAvence + Convert.ToInt32(txt.Text);
				}
			}
			

			if(acumPorcentajeAvence>100)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORDATOSINCORRECTOSPORCENTAJEAVANCEMAYOR100));
				
			}
			else
			{
				txtPorcentajeAvance.Text = acumPorcentajeAvence.ToString();
			}
			

			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(txtPorcentajeAvance.Text)))
			{
				ltlMensaje.Text =  ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONDECONTROLPOSTERIORDATOSINCORRECTOSNUMEROSPORCENTAJEAVANCE));
				return false;
			}

			return true;
		}

		#endregion

	
		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

		

		

		
		

		
		private void llenarAccionesPendientes()
		{
			CProgramacionAuditoria oCProgramacionAuditoria = new CProgramacionAuditoria();
			ddlbAccion.Items.Clear();
			ddlbAccion.DataSource = oCProgramacionAuditoria.ListarAccionControlPendientesPorPeriodo(ddlbPeriodoFiltro.SelectedValue);
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

			double porcentajeAvance = 0;

			foreach(DataGridItem item in grid.Items)
			{
				DataRow dr;
				dr = dtMetas.NewRow();
				
				dr[Enumerados.ColumnasProgramacionAuditoriaMeta.IdProgramacionAuditoriaMeta.ToString()] = Convert.ToInt32(item.Cells[0].Text);
				
				eWorld.UI.CalendarPopup cal = (eWorld.UI.CalendarPopup)item.Cells[1].FindControl(CONTROLCALENDARIO);
				dr[Enumerados.ColumnasProgramacionAuditoriaMeta.Fecha.ToString()] = cal.SelectedDate;
					
				eWorld.UI.NumericBox txt = (eWorld.UI.NumericBox)item.Cells[2].FindControl(CONTROLTXT);
				dr[Enumerados.ColumnasProgramacionAuditoriaMeta.PorcAvance.ToString()] = Convert.ToDouble(txt.Text);
				porcentajeAvance = porcentajeAvance + Convert.ToDouble(txt.Text);
				dtMetas.Rows.Add(dr);
			}
			
			txtPorcentajeAvance.Text = porcentajeAvance.ToString();

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

		

	
		

		

		private void ddlbAccion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[KEYSDT] = null;
			this.LlenarGrilla();
			

			if(ddlbAccion.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				this.LlenarDatos();
				tDetalle.Visible = true;
			}
			else
			{
				tDetalle.Visible = false;
			}
		}

		private void ddlbPeriodoFiltro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ddlbPeriodoFiltro.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				this.llenarAccionesPendientes();
			}
			else
			{
				lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
				ddlbAccion.Items.Clear();
				ddlbAccion.Items.Insert(0,lItem);
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

		private void txtDenominacion_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//this.redireccionaPaginaPrincipal();
			Page.Response.Redirect(URLANTERIOR);

		}

		private void ibtnAtras_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLANTERIOR);
		}

		
	}
}

