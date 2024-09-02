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
	public class DetallePlanAnualDeControl: System.Web.UI.Page,IPaginaBase//,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblObservacion;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPorcentajeAvance;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCodigo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDenominacion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvObservacion;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPeriodo;
		protected System.Web.UI.WebControls.CheckBox cbxEnero;
		protected System.Web.UI.WebControls.CheckBox cbxFebrero;
		protected System.Web.UI.WebControls.CheckBox cbxMarzo;
		protected System.Web.UI.WebControls.CheckBox cbxAbril;
		protected System.Web.UI.WebControls.CheckBox cbxMayo;
		protected System.Web.UI.WebControls.CheckBox cbxJunio;
		protected System.Web.UI.WebControls.CheckBox cbxJulio;
		protected System.Web.UI.WebControls.CheckBox cbxSeptiembre;
		protected System.Web.UI.WebControls.CheckBox cbxOctubre;
		protected System.Web.UI.WebControls.CheckBox cbxNoviembre;
		protected System.Web.UI.WebControls.CheckBox cbxDiciembre;
		protected System.Web.UI.WebControls.CheckBox cbxAgosto;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDestino;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.Label lblCodigo;
		protected System.Web.UI.WebControls.TextBox txtCodigo;
		protected System.Web.UI.WebControls.Label lblUnidadMedida;
		protected System.Web.UI.WebControls.DropDownList ddlbUnidadMedida;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvUnidadMedida;
		protected System.Web.UI.WebControls.Label lblPorcentajeAvance;
		protected eWorld.UI.NumericBox txtPorcentajeAvance;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
		protected System.Web.UI.WebControls.Label lblDenominacion;
		protected System.Web.UI.WebControls.TextBox txtDenominacion;
		
		protected System.Web.UI.WebControls.Label lblMetas;
		#endregion Controles

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO PLAN ANUAL DE CONTROL";
		const string TITULOMODOMODIFICAR = "PLAN ANUAL DE CONTROL";

		//Key Session y QueryString
		const string KEYQID = "Id";
	
		//Paginas
		const string URLPRINCIPAL = "AdministracionDePlanAnualDeControl.aspx";
		#endregion Constantes
		
		#region Variables
		ListItem lItem;
#endregion

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
			this.rfvPeriodo.Init += new System.EventHandler(this.rfvPeriodo_Init);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.ibtnCancelar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);

			this.llenarPeriodos();
			this.llenarUnidadesMedida();
			
		}

		public void LlenarDatos()
		{
			

			
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
			
			rfvCodigo.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPLANANUALCONTROLCAMPOREQUERIDOCODIGO);
			rfvCodigo.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPLANANUALCONTROLCAMPOREQUERIDOCODIGO);

			rfvPeriodo.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPLANANUALCONTROLCAMPOREQUERIDOPERIODO);
			rfvPeriodo.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPLANANUALCONTROLCAMPOREQUERIDOPERIODO);

			rfvUnidadMedida.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPLANANUALCONTROLCAMPOREQUERIDOUNIDADMEDIDA);
			rfvUnidadMedida.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPLANANUALCONTROLCAMPOREQUERIDOUNIDADMEDIDA);

			rfvDenominacion.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPLANANUALCONTROLCAMPOREQUERIDODENOMINACION);
			rfvDenominacion.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPLANANUALCONTROLCAMPOREQUERIDODENOMINACION);
			
			rfvPorcentajeAvance.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPLANANUALCONTROLCAMPOREQUERIDOPORCENTAJEAVANCE);
			rfvPorcentajeAvance.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPLANANUALCONTROLCAMPOREQUERIDOPORCENTAJEAVANCE);


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
			ProgramacionAuditoriaBE oProgramacionAuditoriaBE = new ProgramacionAuditoriaBE();
			oProgramacionAuditoriaBE.Codigo = txtCodigo.Text;
			oProgramacionAuditoriaBE.Denominacion = txtDenominacion.Text;
			oProgramacionAuditoriaBE.IdTablaUnidadMedida = Convert.ToInt32(Enumerados.TablasTabla.AuditoriaUnidadMedidaAuditoria);
			oProgramacionAuditoriaBE.IdUnidadMedida = Convert.ToInt32(ddlbUnidadMedida.SelectedValue);
			oProgramacionAuditoriaBE.Periodo = ddlbPeriodo.SelectedValue;
			oProgramacionAuditoriaBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			if(txtObservacion.Text.Trim()!=String.Empty)
			{
				oProgramacionAuditoriaBE.Observacion = txtObservacion.Text;
			}
			

			if(txtPorcentajeAvance.Text.Trim()!=String.Empty)
			{
				oProgramacionAuditoriaBE.PorcentajeAvance = Convert.ToDouble(txtPorcentajeAvance.Text);
			}
			

			oProgramacionAuditoriaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.AuditoriaEstadoProgramacionAuditoria);
			oProgramacionAuditoriaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosProgramacionAuditoria.Pendiente);
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


			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oProgramacionAuditoriaBE);
			
			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se registró la Actividad de Control Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROPLANANUALCONTROL),URLPRINCIPAL);
			
			}
		}

		public void Modificar()
		{

			ProgramacionAuditoriaBE oProgramacionAuditoriaBE = new ProgramacionAuditoriaBE();
			oProgramacionAuditoriaBE.IdProgramacionAuditoria = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
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

			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oProgramacionAuditoriaBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se modificó la Actividad de Control Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONPLANANUALCONTROL),URLPRINCIPAL);
			
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleCuentasBancaria.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

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
			lblTitulo.Text = TITULOMODONUEVO;
			this.LlenarCombos();
			txtPorcentajeAvance.Text = "0";
			txtPorcentajeAvance.Enabled = false;
		}

		public void CargarModoModificar()
		{
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			ProgramacionAuditoriaBE oProgramacionAuditoriaBE = (ProgramacionAuditoriaBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.ProgramacionAuditoriaNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó el Detalle de la Actividad de Control Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
			
			if(oProgramacionAuditoriaBE!=null)
			{			

				txtCodigo.Text = oProgramacionAuditoriaBE.Codigo;
				ddlbPeriodo.Items.FindByValue(oProgramacionAuditoriaBE.Periodo).Selected = true;
				ddlbUnidadMedida.Items.FindByValue(oProgramacionAuditoriaBE.IdUnidadMedida.ToString()).Selected = true;


				txtPorcentajeAvance.Text = oProgramacionAuditoriaBE.PorcentajeAvance.ToString();

				if(oProgramacionAuditoriaBE.PorcentajeAvance < 100)
				{
					ibtnAceptar.Visible = true;
				}
				else
				{
					ibtnAceptar.Visible = false;
				}
			
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
			}
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
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPLANANUALCONTROLCAMPOREQUERIDOCODIGO));
				return false;		
			}

			if(ddlbPeriodo.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPLANANUALCONTROLCAMPOREQUERIDOPERIODO));
				return false;		
			}

			if(ddlbUnidadMedida.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPLANANUALCONTROLCAMPOREQUERIDOUNIDADMEDIDA));
				return false;	
			}

			
			if(txtDenominacion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPLANANUALCONTROLCAMPOREQUERIDODENOMINACION));
				return false;	
			}

			if(txtPorcentajeAvance.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPLANANUALCONTROLCAMPOREQUERIDOPORCENTAJEAVANCE));
				return false;		
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(txtPorcentajeAvance.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPLANANUALCONTROLDATOSINCORRECTOSNUMEROSPORCENTAJEAVANCE));
				return false;
			}
			
			
			return true;
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		/// <summary>
		/// Abre la pagina de Administracion De PlanAnual DeControl
		/// </summary>
		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}


		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}

		private void rfvPeriodo_Init(object sender, System.EventArgs e)
		{
		
		}

		
	}
}

