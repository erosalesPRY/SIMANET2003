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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.Proyectos;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionComercial;
using NetAccessControl;
using System.IO;
using NullableTypes;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for DetalleRegistroProyectosOtros.
	/// </summary>
	public class DetalleRegistroProyectosOtros : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
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
			this.rbtPeruano.CheckedChanged += new System.EventHandler(this.rbtPeruano_CheckedChanged);
			this.rbtExtranjero.CheckedChanged += new System.EventHandler(this.rbtExtranjero_CheckedChanged);
			this.ddlRegion.SelectedIndexChanged += new System.EventHandler(this.ddlRegion_SelectedIndexChanged);
			this.dllPais.SelectedIndexChanged += new System.EventHandler(this.dllPais_SelectedIndexChanged);
			this.calFechaInicioReal.DateChanged += new eWorld.UI.DateChangedEventHandler(this.calFechaInicioReal_DateChanged);
			this.calFechaFinReal.DateChanged += new eWorld.UI.DateChangedEventHandler(this.calFechaFinReal_DateChanged);
			this.txtFuenteInformacion.TextChanged += new System.EventHandler(this.txtFuenteInformacion_TextChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion	

		#region Controles
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblDatosGenerales;
		protected System.Web.UI.WebControls.DropDownList ddlRegion;
		protected System.Web.UI.WebControls.DropDownList ddlProvincia;
		protected System.Web.UI.WebControls.Label lblTituloAspectosTecnicos;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		protected System.Web.UI.HtmlControls.HtmlTable tblConsulta;
		protected System.Web.UI.WebControls.Label lblPresupuesto;
		protected System.Web.UI.WebControls.Label lblPlano;
		protected System.Web.UI.WebControls.CheckBox chkPresupuesto;
		protected System.Web.UI.WebControls.CheckBox chkPlano;
		protected System.Web.UI.WebControls.HyperLink hlkPlano;
		protected System.Web.UI.WebControls.HyperLink hlkPresupuesto;
		protected System.Web.UI.WebControls.HyperLink hlkEspecificacionTecnica;
		protected System.Web.UI.WebControls.CheckBox chkEspecificaciones;
		protected System.Web.UI.WebControls.HyperLink hlkContrato;
		protected System.Web.UI.WebControls.CheckBox chkContrato;
		protected System.Web.UI.HtmlControls.HtmlInputFile fEspecificaciones;
		protected System.Web.UI.HtmlControls.HtmlInputFile fContrato;
		protected System.Web.UI.HtmlControls.HtmlInputFile fPresupuesto;
		protected System.Web.UI.HtmlControls.HtmlInputFile fPlano;
		protected System.Web.UI.WebControls.Label lblEspTecnica;
		protected System.Web.UI.WebControls.TextBox txtTramos;
		protected System.Web.UI.WebControls.TextBox txtCapacidad;
		protected System.Web.UI.WebControls.Label lblPesoBruto;
		protected System.Web.UI.WebControls.Label lblPesoNeto;
		protected System.Web.UI.WebControls.TextBox txtTipoMaterial;
		protected System.Web.UI.WebControls.Label lblTipoMaterial;
		protected System.Web.UI.WebControls.Label lblMaterial;
		protected eWorld.UI.NumericBox txtPesoNeto;
		protected eWorld.UI.NumericBox txtPesoBruto;
		protected System.Web.UI.WebControls.TextBox txtDimesion;
		protected System.Web.UI.WebControls.TextBox txtDiametro;
		protected System.Web.UI.WebControls.Label lblEspesor;
		protected System.Web.UI.WebControls.Label lblDiametro;
		protected System.Web.UI.WebControls.Label lblDimension;
		protected System.Web.UI.WebControls.Label lblCapacidad;
		protected System.Web.UI.WebControls.Label lblTramos;
		protected System.Web.UI.WebControls.DropDownList ddlMaterial;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.Label lblIdProyecto;
		protected System.Web.UI.WebControls.TextBox txtIdProyecto;
		protected System.Web.UI.WebControls.Label lnlCO;
		protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;
		protected System.Web.UI.WebControls.Label lblCliente;
		protected System.Web.UI.WebControls.TextBox txtRazonSocial;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarDependencia;
		protected System.Web.UI.WebControls.Label lblTipoProducto;
		protected System.Web.UI.WebControls.DropDownList ddlTipoProducto;
		protected System.Web.UI.WebControls.Label lblTipoBuque;
		protected System.Web.UI.WebControls.DropDownList ddlTipoBuque;
		protected System.Web.UI.WebControls.Label lblSubTipo;
		protected System.Web.UI.WebControls.TextBox txtSubTipo;
		protected eWorld.UI.CalendarPopup calFechaFirmaAcuerdo;
		protected System.Web.UI.WebControls.Label lblFirmaAcuerdo;
		protected eWorld.UI.CalendarPopup calFechaInicioContractual;
		protected System.Web.UI.WebControls.Label lblInicioContractual;
		protected System.Web.UI.WebControls.DropDownList ddlTipoDocumento;
		protected System.Web.UI.WebControls.Label lblTipoDocumento;
		protected eWorld.UI.CalendarPopup calFechaFinContractual;
		protected System.Web.UI.WebControls.Label lblFinContractual;
		protected System.Web.UI.WebControls.TextBox txtOtroDocumento;
		protected System.Web.UI.WebControls.Label lblOtroDocumento;
		protected eWorld.UI.CalendarPopup calFechaInicioReal;
		protected System.Web.UI.WebControls.Label lblInicioreal;
		protected System.Web.UI.WebControls.DropDownList ddlOtroTipoDocumento;
		protected System.Web.UI.WebControls.Label lblOtroTipoDocumento;
		protected eWorld.UI.CalendarPopup calFechaFinReal;
		protected System.Web.UI.WebControls.Label lblFinReal;
		protected System.Web.UI.WebControls.Label lblPrecioContractual;
		protected eWorld.UI.CalendarPopup calFechaEntrega;
		protected System.Web.UI.WebControls.Label lblTermino;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtTEjecucion;
		protected System.Web.UI.WebControls.Label lblEjecucion;
		protected System.Web.UI.WebControls.DropDownList ddlMoneda;
		protected System.Web.UI.WebControls.Label lblIdMoneda;
		protected System.Web.UI.WebControls.TextBox txtFuenteInformacion;
		protected System.Web.UI.WebControls.Label lblFuenteInformacion;
		protected System.Web.UI.WebControls.TextBox txtJefeProyectos;
		protected System.Web.UI.WebControls.ImageButton ibtBuscaJefeProyectos;
		protected System.Web.UI.WebControls.Label lblJefeProyecto;
		protected System.Web.UI.WebControls.DropDownList ddlEstadoProyecto;
		protected System.Web.UI.WebControls.Label lblEstado;
		protected System.Web.UI.WebControls.TextBox txtDocumentoPrincipal;
		protected System.Web.UI.WebControls.Label lblDocumentoPrincipal;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.Label lblAspectosAdministrativos;
		protected System.Web.UI.WebControls.Image imgProyecto;
		protected System.Web.UI.HtmlControls.HtmlInputFile fFoto;
		protected System.Web.UI.WebControls.Label lblContrato;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCliente;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFoto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPlano;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hEspecificaciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hContrato;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPresupuesto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdJefeProyecto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlTipoProducto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlTipoBuque;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlRegion;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlMaterial;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlEstadoProyecto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlTipoDocumento;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlOtroTipoDocumento;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlMoneda;
		protected System.Web.UI.WebControls.RadioButton rbtPeruano;
		protected System.Web.UI.WebControls.RadioButton rbtExtranjero;
		protected System.Web.UI.WebControls.Label lblTipoCliente;
		protected System.Web.UI.WebControls.Label lblLugarUno;
		protected System.Web.UI.WebControls.Label lblLugardos;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellRadio;
		protected System.Web.UI.WebControls.TextBox txtEspesor;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtLocalidad;
		protected System.Web.UI.HtmlControls.HtmlTableCell CeldacalFechaFirmaAcuerdo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaFinReal;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaEntrega;
		protected System.Web.UI.HtmlControls.HtmlTableCell CeldacalFechaInicioReal;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaInicioContractual;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaFinContractual;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtPesoNeto;
		protected System.Web.UI.HtmlControls.HtmlTableCell celltxtPesoBruto;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD1;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtPrecioContractual;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtPrecioReal;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellfEspecificaciones;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellfContrato;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellfPresupuesto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellfPlano;
		protected System.Web.UI.WebControls.Label lblUbigeo;
		protected System.Web.UI.WebControls.Label lblLugartres;
		protected System.Web.UI.WebControls.DropDownList dllPais;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlProvincia;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelldllPais;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombreBuque;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvIdProyecto;
		protected eWorld.UI.NumericBox txtPrecioContractual;
		protected eWorld.UI.NumericBox txtPrecioReal;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		#endregion

		#region Eventos
		private void rbtPeruano_CheckedChanged(object sender, System.EventArgs e)
		{
			HabilitarClientePeruano();
			rbtExtranjero.Checked = false;
		}

		private void rbtExtranjero_CheckedChanged(object sender, System.EventArgs e)
		{
			HabilitarClienteExtranjero();
			rbtPeruano.Checked = false;
		}
		
		private DataTable llenarCentroOperativo()
		{
			CCentroOperativo oCCentroOperativo = new CCentroOperativo();
			return oCCentroOperativo.ListarTodosCombo();
		}
		private DataTable llenarTipoBuque()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idTablabuque);
		}
		private DataTable llenarTipoProducto()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idTipoProducto);
		}
		private DataTable llenarMaterialCasco()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idTipoMaterial);
		}

		private DataTable llenarTipoDocumento()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idTipoDocumento);
		}
		private DataTable llenarTipoMonedas()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idTipoModena);
		}

		private DataTable llenarEstadosProyecto()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idEstadoProyecto);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					
					this.ConfigurarAccesoControles();
					this.LlenarDatos();
					this.LlenarCombos();
					this.LlenarJScript();
					this.CargarModoPagina();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));			
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

		private void HabilitarClienteExtranjero()
		{
			CUbigeo oCUbigeo = new CUbigeo();
			dllPais.DataSource = oCUbigeo.LlenarContinentes();
			dllPais.DataTextField = Enumerados.ColumnasUbigeo.NombreDepartamento.ToString();
			dllPais.DataValueField =Enumerados.ColumnasUbigeo.NombreDepartamento.ToString();
			dllPais.DataBind();

			ddlRegion.DataSource = oCUbigeo.LlenarProvincia(dllPais.SelectedValue.ToString());
			ddlRegion.DataTextField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlRegion.DataValueField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlRegion.DataBind();

			ddlRegion.DataSource = oCUbigeo.LlenarDistrito(ddlRegion.SelectedValue.ToString());
			ddlRegion.DataTextField = Enumerados.ColumnasUbigeo.NombreDistrito.ToString();
			ddlRegion.DataValueField = Enumerados.ColumnasUbigeo.IdUbigeo.ToString();
			ddlRegion.DataBind();

			lblLugarUno.Text = "Continente:";
			lblLugardos.Text = "Pais:";
			lblLugartres.Text = "Ciudad:";
		}

		private void HabilitarClientePeruano()
		{
			CUbigeo oCUbigeo = new CUbigeo();
			dllPais.DataSource = oCUbigeo.ListaDepartamentosNacional();
			dllPais.DataTextField = Enumerados.ColumnasUbigeo.NombreDepartamento.ToString();
			dllPais.DataValueField =Enumerados.ColumnasUbigeo.NombreDepartamento.ToString();
			dllPais.DataBind();

			ddlRegion.DataSource = oCUbigeo.LlenarProvincia(dllPais.SelectedValue.ToString());
			ddlRegion.DataTextField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlRegion.DataValueField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlRegion.DataBind();

			ddlProvincia.DataSource = oCUbigeo.LlenarDistrito(ddlRegion.SelectedValue.ToString());
			ddlProvincia.DataTextField = Enumerados.ColumnasUbigeo.NombreDistrito.ToString();
			ddlProvincia.DataValueField = Enumerados.ColumnasUbigeo.IdUbigeo.ToString();
			ddlProvincia.DataBind();

			lblLugarUno.Text = "Region:";
			lblLugardos.Text = "Provincia:";
			lblLugartres.Text = "Distrito:";		
		}
		
		#endregion

		#region IPaginaBase Members
		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{

		
		}

		public void LlenarCombos()
		{
			ListItem item;
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);

			this.ddlCentroOperativo.DataSource = this.llenarCentroOperativo();
			ddlCentroOperativo.DataValueField = Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlCentroOperativo.DataTextField = Enumerados.ColumnasCentroOperativo.Sigla2.ToString();
			ddlCentroOperativo.DataBind();
			ddlCentroOperativo.Items.Insert(0,item);

			this.ddlTipoProducto.DataSource = this.llenarTipoProducto();
			ddlTipoProducto.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlTipoProducto.DataTextField = Enumerados.ColumnasTablaTablas.Var1.ToString();
			ddlTipoProducto.DataBind();
			ddlTipoProducto.Items.Insert(0,item);

			this.ddlTipoBuque.DataSource = this.llenarTipoBuque();
			ddlTipoBuque.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlTipoBuque.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlTipoBuque.DataBind();
			ddlTipoBuque.Items.Insert(0,item);

			this.ddlEstadoProyecto.DataSource = this.llenarEstadosProyecto();
			ddlEstadoProyecto.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlEstadoProyecto.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlEstadoProyecto.DataBind();
			ddlEstadoProyecto.Items.Insert(0,item);

			this.ddlTipoDocumento.DataSource = this.llenarTipoDocumento();
			ddlTipoDocumento.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlTipoDocumento.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlTipoDocumento.DataBind();
			ddlTipoDocumento.Items.Insert(0,item);

			this.ddlOtroTipoDocumento.DataSource = this.llenarTipoDocumento();
			ddlOtroTipoDocumento.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlOtroTipoDocumento.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlOtroTipoDocumento.DataBind();
			ddlOtroTipoDocumento.Items.Insert(0,item);

			this.ddlMoneda.DataSource = this.llenarTipoMonedas();
			ddlMoneda.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlMoneda.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlMoneda.DataBind();
			ddlMoneda.Items.Insert(0,item);

			this.ddlMaterial.DataSource = this.llenarMaterialCasco();
			ddlMaterial.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlMaterial.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlMaterial.DataBind();
			ddlMaterial.Items.Insert(0,item);
		}

		public void LlenarDatos()
		{
			Helper.CalendarioControlStyle(this.calFechaEntrega);
			Helper.CalendarioControlStyle(this.calFechaFinContractual);
			Helper.CalendarioControlStyle(this.calFechaFinReal);
			Helper.CalendarioControlStyle(this.calFechaFirmaAcuerdo);
			Helper.CalendarioControlStyle(this.calFechaInicioContractual);
			Helper.CalendarioControlStyle(this.calFechaInicioReal);
		}

		public void LlenarJScript()
		{
			this.fFoto.Attributes.Add( Utilitario.Constantes.EVENTOONBLUR, JMOSTRARIMAGEN);
			this.ibtnBuscarDependencia.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Helper.PopupBusqueda(URLBUSQUEDACLIENTE,600,450,70,100,Utilitario.Constantes.VALORUNCHECKEDBOOL)+ JRETURNDOS);
			this.ibtBuscaJefeProyectos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,Helper.PopupBusqueda(URLBUSQUEDAENTIDAD + Utilitario.Constantes.KEYTIPOBUSQUEDAENTIDAD +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.TipoBusquedaEntidad.PE,700,700,true) +  JRETURN);

			//this.rfvNombre.ErrorMessage = Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEREQUERIMIENTOCAMPONOMBRE);
			//this.rfvNombre.ToolTip = Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEREQUERIMIENTOCAMPONOMBRE);
		}

		public void RegistrarJScript()
		{

		}

		public void Imprimir()
		{

		}

		public void Exportar()
		{

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

		#region IPaginaMantenimento Members
		public void Agregar()
		{
			RegistroProyectoOtrosBE oRegistroProyectoOtrosBE = new RegistroProyectoOtrosBE();
			
			if(txtLocalidad.Text != String.Empty)
				oRegistroProyectoOtrosBE.Localidad = NullableString.Parse(txtLocalidad.Text);			

			if(txtCapacidad.Text != String.Empty)
				oRegistroProyectoOtrosBE.Capacidad = NullableString.Parse(txtCapacidad.Text);

			if(txtDiametro.Text != String.Empty)
				oRegistroProyectoOtrosBE.Diametro = NullableString.Parse(txtDiametro.Text);

			if(txtDimesion.Text != String.Empty)
				oRegistroProyectoOtrosBE.Dimension = NullableString.Parse(txtDimesion.Text);

			if(txtDocumentoPrincipal.Text != String.Empty)
				oRegistroProyectoOtrosBE.DocumentoPrincipal = NullableString.Parse(txtDocumentoPrincipal.Text);

			if(txtEspesor.Text != String.Empty)
				oRegistroProyectoOtrosBE.Espesor = NullableString.Parse(txtEspesor.Text);

			if(calFechaFirmaAcuerdo.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoOtrosBE.FechaAcuerdo = NullableDateTime.Parse(calFechaFirmaAcuerdo.SelectedDate);
			else
				oRegistroProyectoOtrosBE.FechaAcuerdo = NullableDateTime.Null;

			if(calFechaEntrega.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoOtrosBE.FechaEntrega = NullableDateTime.Parse(calFechaEntrega.SelectedDate);
					else
				oRegistroProyectoOtrosBE.FechaEntrega = NullableDateTime.Null;

			if(calFechaFinContractual.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoOtrosBE.FechaFinContractual = NullableDateTime.Parse(calFechaFinContractual.SelectedDate);
				else
				oRegistroProyectoOtrosBE.FechaFinContractual = NullableDateTime.Null;


			if(calFechaFinReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoOtrosBE.FechaFinReal = NullableDateTime.Parse(calFechaFinReal.SelectedDate);
			else
				oRegistroProyectoOtrosBE.FechaFinReal = NullableDateTime.Null;

			if(calFechaInicioContractual.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoOtrosBE.FechaInicioContractual = NullableDateTime.Parse(calFechaInicioContractual.SelectedDate);
			else
				oRegistroProyectoOtrosBE.FechaInicioContractual = NullableDateTime.Null;

			if(calFechaInicioReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoOtrosBE.FechaInicioReal = NullableDateTime.Parse(calFechaInicioReal.SelectedDate);
			else
				oRegistroProyectoOtrosBE.FechaInicioReal = NullableDateTime.Null;

			oRegistroProyectoOtrosBE.FechaRegistro = DateTime.Now;

			if(txtFuenteInformacion.Text != String.Empty)
				oRegistroProyectoOtrosBE.FuenteInformacion = NullableString.Parse(txtFuenteInformacion.Text);

			if(this.ddlTipoBuque.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoOtrosBE.IdBuque = NullableInt32.Parse(ddlTipoBuque.SelectedValue);
			}
		
				oRegistroProyectoOtrosBE.IdCentroOperativo = NullableInt32.Parse(ddlCentroOperativo.SelectedValue);

			if(hIdCliente.Value != String.Empty)
				oRegistroProyectoOtrosBE.IdCliente = NullableInt32.Parse(hIdCliente.Value);

			oRegistroProyectoOtrosBE.IdEstado = Convert.ToInt32(Enumerados.EstadoGeneral.Activo);
			
			if(this.ddlEstadoProyecto.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoOtrosBE.IdEstadoProyecto = NullableInt32.Parse(ddlEstadoProyecto.SelectedValue);
			}

			if(hIdJefeProyecto.Value != String.Empty)
				oRegistroProyectoOtrosBE.IdJefeProyecto = NullableInt32.Parse(hIdJefeProyecto.Value);

			if(this.ddlMaterial.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoOtrosBE.IdMaterial = NullableInt32.Parse(ddlMaterial.SelectedValue);
			}
			if(this.ddlMoneda.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoOtrosBE.IdMoneda = NullableInt32.Parse(ddlMoneda.SelectedValue);
			}
			if(txtIdProyecto.Text != String.Empty)
				oRegistroProyectoOtrosBE.IdProyecto = NullableString.Parse(txtIdProyecto.Text);	
			
			oRegistroProyectoOtrosBE.IdTablaBuque = NullableInt32.Parse(Enumerados.TablasTabla.TablaBuques);	
			oRegistroProyectoOtrosBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoGeneral);	
			oRegistroProyectoOtrosBE.IdTablaEstadoProyecto =  NullableInt32.Parse(Enumerados.TablasTabla.ProyectosEstadoProyectoSegunGrupoProyecto);	
			oRegistroProyectoOtrosBE.IdTablaMaterial =   NullableInt32.Parse(idTipoMaterial);
			oRegistroProyectoOtrosBE.IdTablaMoneda =   NullableInt32.Parse(idTipoModena);
			oRegistroProyectoOtrosBE.IdTablaTipoDocumento =  NullableInt32.Parse(idTipoDocumento);
			oRegistroProyectoOtrosBE.IdTablaTipoProducto =  NullableInt32.Parse(idTipoProducto);
			
			if(this.ddlTipoDocumento.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoOtrosBE.IdTipoDocumento =  NullableInt32.Parse(ddlTipoDocumento.SelectedValue);
			}
			if(this.ddlOtroTipoDocumento.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoOtrosBE.IdTipoOtroDocumento =  NullableInt32.Parse(ddlOtroTipoDocumento.SelectedValue);
			}
			if(this.ddlTipoProducto.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoOtrosBE.IdTipoProducto = NullableInt32.Parse(ddlTipoProducto.SelectedValue);
			}
			if(ddlProvincia.SelectedValue != String.Empty)
				oRegistroProyectoOtrosBE.IdUbigeo = NullableInt32.Parse(ddlProvincia.SelectedValue);

			oRegistroProyectoOtrosBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			oRegistroProyectoOtrosBE.Nombre = txtNombre.Text;

			if(txtObservaciones.Text != String.Empty)
				oRegistroProyectoOtrosBE.Observaciones = NullableString.Parse(txtObservaciones.Text);

			if(txtOtroDocumento.Text != String.Empty)
				oRegistroProyectoOtrosBE.OtroDocumento = NullableString.Parse(txtOtroDocumento.Text);

			if(txtPesoBruto.Text != String.Empty)
				oRegistroProyectoOtrosBE.PesoBruto = NullableDouble.Parse(txtPesoBruto.Text);

			if(txtPesoNeto.Text != String.Empty)
				oRegistroProyectoOtrosBE.PesoNeto = NullableDouble.Parse(txtPesoNeto.Text);

			if(txtPrecioContractual.Text != String.Empty)
				oRegistroProyectoOtrosBE.PrecioContractual = NullableDouble.Parse(txtPrecioContractual.Text);

			if(txtPrecioReal.Text != String.Empty)
				oRegistroProyectoOtrosBE.PrecioReal = NullableDouble.Parse(txtPrecioReal.Text);
			
			if(txtSubTipo.Text != String.Empty)
				oRegistroProyectoOtrosBE.SubTipo = NullableString.Parse(txtSubTipo.Text);

			if(txtTipoMaterial.Text != String.Empty)
				oRegistroProyectoOtrosBE.TipoMaterial = NullableString.Parse(txtTipoMaterial.Text);
			
			if(txtTramos.Text != String.Empty)
				oRegistroProyectoOtrosBE.Tramos = NullableString.Parse(txtTramos.Text);

			
			if(fContrato.Value!=String.Empty)
			{
				strFilename = fContrato.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oRegistroProyectoOtrosBE.RutaContrato = strFilename;
			}

			
			if(fEspecificaciones.Value!=String.Empty)
			{
				strFilename = fEspecificaciones.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oRegistroProyectoOtrosBE.RutaEspecificacion = strFilename;
			}

			if(fPresupuesto.Value!=String.Empty)
			{
				strFilename = fPresupuesto.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];
				
				oRegistroProyectoOtrosBE.RutaPresupuesto = strFilename;
			}
		
			if(fPlano.Value!=String.Empty)
			{
				strFilename = fPlano.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oRegistroProyectoOtrosBE.RutaPlano = strFilename;
			}
	
			if(fFoto.Value!=String.Empty)
			{
				strFilename = fFoto.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oRegistroProyectoOtrosBE.RutaImagen = strFilename;
			}
			else
			{
				oRegistroProyectoOtrosBE.RutaImagen = ARCHIVO;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oRegistroProyectoOtrosBE);

			if (retorno == Utilitario.Constantes.VALORCONFIRMACIONREGISTRO)
			{
				if (fFoto.Value != String.Empty)
					this.GuardarImagen();
				
				if (fContrato.Value != String.Empty)
					this.GuardarDocumentoContrato(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS]));

				if (fEspecificaciones.Value != String.Empty)
					this.GuardarDocumentoEspecificaciones(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS]));
				
				if (fPlano.Value != String.Empty)
					this.GuardarDocumentoPlano(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS]));

				if (fPresupuesto.Value != String.Empty)
					this.GuardarDocumentoPresupuesto(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS]));
				
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJEREGISTRO + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROREGISTROPROYECTOMM));
			}
		}

		public void GuardarImagen() 
		{
			HttpPostedFile myFile = fFoto.PostedFile;
			int nFileLen = myFile.ContentLength; 
					
			if( nFileLen > Utilitario.Constantes.ValorConstanteCero)
			{
				if(nFileLen <= TAMANOARCHIVO)
				{	
					byte[] myData = new byte[nFileLen];

					myFile.InputStream.Read(myData, Utilitario.Constantes.ValorConstanteCero, nFileLen);
					string path =RutaImagenCarpetaProyecto; //@"C:\P\";
					string strFilename = myFile.FileName;

					string[] res = strFilename.Split('\\');
					int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];
							
					Helper.GuardarImagenServidor(myData,path + strFilename);
				}
			}		
		}

		public void GuardarDocumentoContrato(int IdProyecto) 
		{
			HttpPostedFile myFile = fContrato.PostedFile;
			int nFileLen = myFile.ContentLength; 

			if( nFileLen > Utilitario.Constantes.ValorConstanteCero )
			{
				if(nFileLen <= TAMANOARCHIVO)
				{	
					byte[] myData = new byte[nFileLen];

					myFile.InputStream.Read(myData,Utilitario.Constantes.ValorConstanteCero, nFileLen);
					string path = RutaImagenCarpetaProyecto;
					string strFilename = myFile.FileName;

					string[] res = strFilename.Split('\\');
					int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];

					string[] ExtencionArchivo=strFilename.Split('.');
							
					WriteToFile(path + strFilename,ref myData);
				}
			}		
		}

		public void GuardarDocumentoEspecificaciones(int IdProyecto) 
		{
			HttpPostedFile myFile = fEspecificaciones.PostedFile;
			int nFileLen = myFile.ContentLength; 

			if( nFileLen > Utilitario.Constantes.ValorConstanteCero )
			{
				if(nFileLen <= TAMANOARCHIVO)
				{	
					byte[] myData = new byte[nFileLen];

					myFile.InputStream.Read(myData,Utilitario.Constantes.ValorConstanteCero, nFileLen);
					string path = RutaImagenCarpetaProyecto;
					string strFilename = myFile.FileName;

					string[] res = strFilename.Split('\\');
					int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];

					string[] ExtencionArchivo=strFilename.Split('.');
							
					WriteToFile(path + strFilename,ref myData);
				}
			}		
		}

		public void GuardarDocumentoPlano(int IdProyecto) 
		{
			HttpPostedFile myFile = fPlano.PostedFile;
			int nFileLen = myFile.ContentLength; 

			if( nFileLen > Utilitario.Constantes.ValorConstanteCero )
			{
				if(nFileLen <= TAMANOARCHIVO)
				{	
					byte[] myData = new byte[nFileLen];

					myFile.InputStream.Read(myData,Utilitario.Constantes.ValorConstanteCero, nFileLen);
					string path = RutaImagenCarpetaProyecto;
					string strFilename = myFile.FileName;

					string[] res = strFilename.Split('\\');
					int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];

					string[] ExtencionArchivo=strFilename.Split('.');
							
					WriteToFile(path + strFilename,ref myData);
				}
			}		
		}
		
		public void GuardarDocumentoPresupuesto(int IdProyecto) 
		{
			HttpPostedFile myFile = fPresupuesto.PostedFile;
			int nFileLen = myFile.ContentLength; 

			if( nFileLen > Utilitario.Constantes.ValorConstanteCero )
			{
				if(nFileLen <= TAMANOARCHIVO)
				{	
					byte[] myData = new byte[nFileLen];

					myFile.InputStream.Read(myData,Utilitario.Constantes.ValorConstanteCero, nFileLen);
					string path = RutaImagenCarpetaProyecto;
					string strFilename = myFile.FileName;

					string[] res = strFilename.Split('\\');
					int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];

					string[] ExtencionArchivo=strFilename.Split('.');
							
					WriteToFile(path + strFilename,ref myData);
				}
			}		
		}
		
		private void WriteToFile(string strPath, ref byte[] Buffer)
		{
			FileStream newFile = new FileStream(strPath,FileMode.Create);	
			newFile.Write(Buffer, Utilitario.Constantes.ValorConstanteCero, Buffer.Length);
			newFile.Close();
		}

		public void Modificar()
		{
			RegistroProyectoOtrosBE oRegistroProyectoOtrosBE = new RegistroProyectoOtrosBE();
			
			oRegistroProyectoOtrosBE.IdRegistroProyectoOtros = Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS]);

			if(txtLocalidad.Text != String.Empty)
				oRegistroProyectoOtrosBE.Localidad = NullableString.Parse(txtLocalidad.Text);	

			if(txtCapacidad.Text != String.Empty)
				oRegistroProyectoOtrosBE.Capacidad = NullableString.Parse(txtCapacidad.Text);

			if(txtDiametro.Text != String.Empty)
				oRegistroProyectoOtrosBE.Diametro = NullableString.Parse(txtDiametro.Text);

			if(txtDimesion.Text != String.Empty)
				oRegistroProyectoOtrosBE.Dimension = NullableString.Parse(txtDimesion.Text);

			if(txtDocumentoPrincipal.Text != String.Empty)
				oRegistroProyectoOtrosBE.DocumentoPrincipal = NullableString.Parse(txtDocumentoPrincipal.Text);

			if(txtEspesor.Text != String.Empty)
				oRegistroProyectoOtrosBE.Espesor = NullableString.Parse(txtEspesor.Text);

			if(calFechaFirmaAcuerdo.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoOtrosBE.FechaAcuerdo = NullableDateTime.Parse(calFechaFirmaAcuerdo.SelectedDate);
			else
				oRegistroProyectoOtrosBE.FechaAcuerdo = NullableDateTime.Null;


			if(calFechaEntrega.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoOtrosBE.FechaEntrega = NullableDateTime.Parse(calFechaEntrega.SelectedDate);
			else
				oRegistroProyectoOtrosBE.FechaEntrega = NullableDateTime.Null;

			if(calFechaFinContractual.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoOtrosBE.FechaFinContractual = NullableDateTime.Parse(calFechaFinContractual.SelectedDate);
			else
				oRegistroProyectoOtrosBE.FechaFinContractual = NullableDateTime.Null;

			if(calFechaFinReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoOtrosBE.FechaFinReal = NullableDateTime.Parse(calFechaFinReal.SelectedDate);
			else
				oRegistroProyectoOtrosBE.FechaFinReal = NullableDateTime.Null;

			if(calFechaInicioContractual.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoOtrosBE.FechaInicioContractual = NullableDateTime.Parse(calFechaInicioContractual.SelectedDate);
			else
				oRegistroProyectoOtrosBE.FechaInicioContractual = NullableDateTime.Null;

			if(calFechaInicioReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoOtrosBE.FechaInicioReal = NullableDateTime.Parse(calFechaInicioReal.SelectedDate);
			else
				oRegistroProyectoOtrosBE.FechaInicioReal = NullableDateTime.Null;

			oRegistroProyectoOtrosBE.FechaActualizacion = DateTime.Now;

			if(txtFuenteInformacion.Text != String.Empty)
				oRegistroProyectoOtrosBE.FuenteInformacion = NullableString.Parse(txtFuenteInformacion.Text);

			if(this.ddlTipoBuque.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoOtrosBE.IdBuque = NullableInt32.Parse(ddlTipoBuque.SelectedValue);
			}
			
				oRegistroProyectoOtrosBE.IdCentroOperativo = NullableInt32.Parse(ddlCentroOperativo.SelectedValue);

			if(hIdCliente.Value != String.Empty)
				oRegistroProyectoOtrosBE.IdCliente = NullableInt32.Parse(hIdCliente.Value);

			oRegistroProyectoOtrosBE.IdEstado = Convert.ToInt32(Enumerados.EstadoGeneral.Activo);
			
			if(this.ddlEstadoProyecto.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoOtrosBE.IdEstadoProyecto = NullableInt32.Parse(ddlEstadoProyecto.SelectedValue);
			}
			if(hIdJefeProyecto.Value != String.Empty)
				oRegistroProyectoOtrosBE.IdJefeProyecto = NullableInt32.Parse(hIdJefeProyecto.Value);

			if(this.ddlMaterial.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoOtrosBE.IdMaterial = NullableInt32.Parse(ddlMaterial.SelectedValue);
			}
			if(this.ddlMoneda.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
		
				oRegistroProyectoOtrosBE.IdMoneda = NullableInt32.Parse(ddlMoneda.SelectedValue);
			}
			if(txtIdProyecto.Text != String.Empty)
				oRegistroProyectoOtrosBE.IdProyecto = NullableString.Parse(txtIdProyecto.Text);	
			
			oRegistroProyectoOtrosBE.IdTablaBuque = NullableInt32.Parse(Enumerados.TablasTabla.TablaBuques);	
			oRegistroProyectoOtrosBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoGeneral);	
			oRegistroProyectoOtrosBE.IdTablaEstadoProyecto =  NullableInt32.Parse(Enumerados.TablasTabla.ProyectosEstadoProyectoSegunGrupoProyecto);	
			oRegistroProyectoOtrosBE.IdTablaMaterial =   NullableInt32.Parse(idTipoMaterial);
			oRegistroProyectoOtrosBE.IdTablaMoneda =   NullableInt32.Parse(idTipoModena);
			oRegistroProyectoOtrosBE.IdTablaTipoDocumento =  NullableInt32.Parse(idTipoDocumento);
			oRegistroProyectoOtrosBE.IdTablaTipoProducto =  NullableInt32.Parse(idTipoProducto);
			
			if(this.ddlTipoDocumento.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoOtrosBE.IdTipoDocumento =  NullableInt32.Parse(ddlTipoDocumento.SelectedValue);
			}
			if(this.ddlOtroTipoDocumento.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoOtrosBE.IdTipoOtroDocumento =  NullableInt32.Parse(ddlOtroTipoDocumento.SelectedValue);
			}
			if(this.ddlTipoProducto.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoOtrosBE.IdTipoProducto = NullableInt32.Parse(ddlTipoProducto.SelectedValue);
			}
			
				oRegistroProyectoOtrosBE.IdUbigeo = NullableInt32.Parse(ddlProvincia.SelectedValue);

			oRegistroProyectoOtrosBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			oRegistroProyectoOtrosBE.Nombre = txtNombre.Text;

			if(txtObservaciones.Text != String.Empty)
				oRegistroProyectoOtrosBE.Observaciones = NullableString.Parse(txtObservaciones.Text);

			if(txtOtroDocumento.Text != String.Empty)
				oRegistroProyectoOtrosBE.OtroDocumento = NullableString.Parse(txtOtroDocumento.Text);

			if(txtPesoBruto.Text != String.Empty)
				oRegistroProyectoOtrosBE.PesoBruto = NullableDouble.Parse(txtPesoBruto.Text);

			if(txtPesoNeto.Text != String.Empty)
				oRegistroProyectoOtrosBE.PesoNeto = NullableDouble.Parse(txtPesoNeto.Text);

			if(txtPrecioContractual.Text != String.Empty)
				oRegistroProyectoOtrosBE.PrecioContractual = NullableDouble.Parse(txtPrecioContractual.Text);

			if(txtPrecioReal.Text != String.Empty)
				oRegistroProyectoOtrosBE.PrecioReal = NullableDouble.Parse(txtPrecioReal.Text);
			
			if(txtSubTipo.Text != String.Empty)
				oRegistroProyectoOtrosBE.SubTipo = NullableString.Parse(txtSubTipo.Text);

			if(txtTipoMaterial.Text != String.Empty)
				oRegistroProyectoOtrosBE.TipoMaterial = NullableString.Parse(txtTipoMaterial.Text);
			
			if(txtTramos.Text != String.Empty)
				oRegistroProyectoOtrosBE.Tramos = NullableString.Parse(txtTramos.Text);

			
			if(fContrato.Value!=String.Empty)
			{
				strFilename = fContrato.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oRegistroProyectoOtrosBE.RutaContrato = strFilename;
			}
			else
				oRegistroProyectoOtrosBE.RutaContrato = hContrato.Value;
			
			if(fEspecificaciones.Value!=String.Empty)
			{
				strFilename = fEspecificaciones.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oRegistroProyectoOtrosBE.RutaEspecificacion = strFilename;
			}
			else
				oRegistroProyectoOtrosBE.RutaEspecificacion = hEspecificaciones.Value;

			if(fPresupuesto.Value!=String.Empty)
			{
				strFilename = fPlano.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];
				
				oRegistroProyectoOtrosBE.RutaPresupuesto = strFilename;
			}
			else
				oRegistroProyectoOtrosBE.RutaPresupuesto = hPresupuesto.Value;
		
			if(fPlano.Value!=String.Empty)
			{
				strFilename = fPlano.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oRegistroProyectoOtrosBE.RutaPlano = strFilename;
			}
			else
				oRegistroProyectoOtrosBE.RutaPlano = hPlano.Value;
	
			if(fFoto.Value!=String.Empty)
			{
				strFilename = fFoto.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oRegistroProyectoOtrosBE.RutaImagen = strFilename;
			
			}
			else
			{
				oRegistroProyectoOtrosBE.RutaImagen = ARCHIVO;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oRegistroProyectoOtrosBE);

			if (retorno == Utilitario.Constantes.VALORCONFIRMACIONREGISTRO)
			{
				if (fFoto.Value != String.Empty)
					this.GuardarImagen();
				
				if (fContrato.Value != String.Empty)
					this.GuardarDocumentoContrato(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS]));

				if (fEspecificaciones.Value != String.Empty)
					this.GuardarDocumentoEspecificaciones(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS]));
				
				if (fPlano.Value != String.Empty)
					this.GuardarDocumentoPlano(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS]));

				if (fPresupuesto.Value != String.Empty)
					this.GuardarDocumentoPresupuesto(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS]));
				
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJEREGISTRO + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONREGISTROPROYECTOMM))+ Utilitario.Constantes.HISTORIALATRAS ;
			}

			


		}

		public void Eliminar()
		{

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
			HabilitarClientePeruano();
			rbtPeruano.Checked= true;
		}

		public void CargarModoModificar()
		{
			if (Page.Request.QueryString[KEYIDCLIENTE] == Utilitario.Constantes.IDCLIENTEMARINA.ToString())
				lblTermino.Text = Utilitario.Constantes.TEXTOSETIQUETAMARINA;

			tblConsulta.Visible = Utilitario.Constantes.VALORUNCHECKEDBOOL;

			CMantenimientos	oCMantenimientos = new CMantenimientos();
			RegistroProyectoOtrosBE oRegistroProyectoOtrosBE = (RegistroProyectoOtrosBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS]),Enumerados.ClasesNTAD.RegistroProyectoOtrosNTAD.ToString());

            txtNombre.Text =	oRegistroProyectoOtrosBE.Nombre;
			
			if (!oRegistroProyectoOtrosBE.IdProyecto.IsNull )
				txtIdProyecto.Text = oRegistroProyectoOtrosBE.IdProyecto.ToString();
			
			if(!oRegistroProyectoOtrosBE.IdUbigeo.IsNull)
			{
				CUbigeo oCUbigeo = new CUbigeo();

				if(oRegistroProyectoOtrosBE.IdUbigeo >= 700101)
				{
					HabilitarClienteExtranjero();
					rbtExtranjero.Checked = true;
					rbtPeruano.Checked = false;
					
					DataRow dr = oCUbigeo.ObtenerNombreUbigeo(Convert.ToInt32(oRegistroProyectoOtrosBE.IdUbigeo));

					dllPais.SelectedValue = dr[Enumerados.ColumnasUbigeo.NombreDepartamento.ToString()].ToString();
					
					ddlRegion.DataSource = oCUbigeo.LlenarProvincia(dllPais.SelectedValue.ToString());
					ddlRegion.DataTextField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
					ddlRegion.DataValueField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
					ddlRegion.DataBind();

					ddlRegion.SelectedValue = dr[Enumerados.ColumnasUbigeo.NombreProvincia.ToString()].ToString();

					ddlProvincia.DataSource = oCUbigeo.LlenarDistrito(ddlRegion.SelectedValue.ToString());
					ddlProvincia.DataTextField = Enumerados.ColumnasUbigeo.NombreDistrito.ToString();
					ddlProvincia.DataValueField = Enumerados.ColumnasUbigeo.IdUbigeo.ToString();
					ddlProvincia.DataBind();

					ddlProvincia.SelectedValue = dr[Enumerados.ColumnasUbigeo.IdUbigeo.ToString()].ToString();
				}
				else
				{
				
					HabilitarClientePeruano();
					rbtExtranjero.Checked = false;
					rbtPeruano.Checked = true;
					
					DataRow dr = oCUbigeo.ObtenerNombreUbigeo(Convert.ToInt32(oRegistroProyectoOtrosBE.IdUbigeo));

					dllPais.SelectedValue = dr[Enumerados.ColumnasUbigeo.NombreDepartamento.ToString()].ToString();
					
					ddlRegion.DataSource = oCUbigeo.LlenarProvincia(dllPais.SelectedValue.ToString());
					ddlRegion.DataTextField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
					ddlRegion.DataValueField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
					ddlRegion.DataBind();

					ddlRegion.SelectedValue = dr[Enumerados.ColumnasUbigeo.NombreProvincia.ToString()].ToString();

					ddlProvincia.DataSource = oCUbigeo.LlenarDistrito(ddlRegion.SelectedValue.ToString());
					ddlProvincia.DataTextField = Enumerados.ColumnasUbigeo.NombreDistrito.ToString();
					ddlProvincia.DataValueField = Enumerados.ColumnasUbigeo.IdUbigeo.ToString();
					ddlProvincia.DataBind();

					ddlProvincia.SelectedValue = dr[Enumerados.ColumnasUbigeo.IdUbigeo.ToString()].ToString();				
				}
			}
			
	

			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.M:
				{
					if (!oRegistroProyectoOtrosBE.IdCentroOperativo.IsNull )
						ddlCentroOperativo.SelectedValue = oRegistroProyectoOtrosBE.IdCentroOperativo.ToString();
					
					if (!oRegistroProyectoOtrosBE.IdTipoProducto.IsNull )
						ddlTipoProducto.SelectedValue = oRegistroProyectoOtrosBE.IdTipoProducto.ToString();

					if (!oRegistroProyectoOtrosBE.IdBuque.IsNull )
						ddlTipoBuque.SelectedValue = oRegistroProyectoOtrosBE.IdBuque.ToString();

					
					if (!oRegistroProyectoOtrosBE.IdEstadoProyecto.IsNull )
						ddlEstadoProyecto.SelectedValue = oRegistroProyectoOtrosBE.IdEstadoProyecto.ToString();

					if (!oRegistroProyectoOtrosBE.IdMaterial.IsNull )
						ddlMaterial.SelectedValue = oRegistroProyectoOtrosBE.IdMaterial.ToString();

					if (!oRegistroProyectoOtrosBE.IdTipoDocumento.IsNull )
						ddlTipoDocumento.SelectedValue = oRegistroProyectoOtrosBE.IdTipoDocumento.ToString();

					if (!oRegistroProyectoOtrosBE.IdTipoOtroDocumento.IsNull )
						ddlOtroTipoDocumento.SelectedValue = oRegistroProyectoOtrosBE.IdTipoOtroDocumento.ToString();

					if (!oRegistroProyectoOtrosBE.IdMoneda.IsNull )
						ddlMoneda.SelectedValue = oRegistroProyectoOtrosBE.IdMoneda.ToString();

					if (!oRegistroProyectoOtrosBE.PesoNeto.IsNull )
						txtPesoNeto.Text = oRegistroProyectoOtrosBE.PesoNeto.ToString();

					if (!oRegistroProyectoOtrosBE.PesoBruto.IsNull )
						txtPesoBruto.Text = oRegistroProyectoOtrosBE.PesoBruto.ToString();

					if (!oRegistroProyectoOtrosBE.PrecioContractual.IsNull )
						txtPrecioContractual.Text = oRegistroProyectoOtrosBE.PrecioContractual.Value.ToString();

					if (!oRegistroProyectoOtrosBE.PrecioReal.IsNull )
						txtPrecioReal.Text =  oRegistroProyectoOtrosBE.PrecioReal.Value.ToString();	
				

					
					if (!oRegistroProyectoOtrosBE.RutaPresupuesto.IsNull )
					{
						rutaArchivoPresupuesto = RutaImagenCarpetaProyecto +  "\\" +  oRegistroProyectoOtrosBE.RutaPresupuesto.ToString();
						hPresupuesto.Value = Convert.ToString(oRegistroProyectoOtrosBE.RutaPresupuesto);
						chkPresupuesto.Checked = true;
					}

					if (!oRegistroProyectoOtrosBE.RutaContrato.IsNull)
					{
						rutaArchivoContrato = RutaImagenCarpetaProyecto +  "\\" +  oRegistroProyectoOtrosBE.RutaContrato.ToString();
						hContrato.Value = Convert.ToString(oRegistroProyectoOtrosBE.RutaContrato);
						chkContrato.Checked = true;
					}

			
					if (!oRegistroProyectoOtrosBE.RutaEspecificacion.IsNull )
					{
						rutaArchivoEspecificaciones = RutaImagenCarpetaProyecto +  "\\" +  oRegistroProyectoOtrosBE.RutaEspecificacion.ToString();
						hEspecificaciones.Value=  Convert.ToString(oRegistroProyectoOtrosBE.RutaEspecificacion);
						chkEspecificaciones.Checked = true;
					}

					if (!oRegistroProyectoOtrosBE.RutaPlano.IsNull )
					{
						rutaArchivoPlano = RutaImagenCarpetaProyecto +  "\\" +  oRegistroProyectoOtrosBE.RutaPlano.ToString();
						hPlano.Value =	Convert.ToString(oRegistroProyectoOtrosBE.RutaPlano) ;
						chkPlano.Checked = true;
					}

					if (!oRegistroProyectoOtrosBE.RutaImagen.IsNull )
					{
						hFoto.Value =Convert.ToString( oRegistroProyectoOtrosBE.RutaImagen);
						string RutaImagen=RutaImagenServerProyecto + oRegistroProyectoOtrosBE.RutaImagen.Value;
						imgProyecto.ImageUrl = RutaImagen;
						hFoto.Value = oRegistroProyectoOtrosBE.RutaImagen.Value;
					}

					if (!oRegistroProyectoOtrosBE.IdJefeProyecto.IsNull)
					{
						hIdJefeProyecto.Value= oRegistroProyectoOtrosBE.IdJefeProyecto.ToString();
						CPersonal oCPersonal = new CPersonal();
						txtJefeProyectos.Text = oCPersonal.ObtenerNombrePersonal(Convert.ToInt32(oRegistroProyectoOtrosBE.IdJefeProyecto));
					}

					if (!oRegistroProyectoOtrosBE.IdCliente.IsNull )
					{
						hIdCliente.Value = oRegistroProyectoOtrosBE.IdCliente.ToString();
						CCliente oCCliente = new CCliente();
						txtRazonSocial.Text=  oCCliente.ObtenerNombreCliente(Convert.ToInt32(hIdCliente.Value));
					}

					if(!oRegistroProyectoOtrosBE.FechaAcuerdo.IsNull )
						calFechaFirmaAcuerdo.SelectedDate = Convert.ToDateTime(oRegistroProyectoOtrosBE.FechaAcuerdo.ToString());
			
					if(!oRegistroProyectoOtrosBE.FechaInicioContractual.IsNull )
						calFechaInicioContractual.SelectedDate = Convert.ToDateTime(oRegistroProyectoOtrosBE.FechaInicioContractual.ToString());

					if(!oRegistroProyectoOtrosBE.FechaFinContractual.IsNull )
						calFechaFinContractual.SelectedDate = Convert.ToDateTime(oRegistroProyectoOtrosBE.FechaFinContractual.ToString());

					if(!oRegistroProyectoOtrosBE.FechaInicioReal.IsNull )
						calFechaInicioReal.SelectedDate = Convert.ToDateTime(oRegistroProyectoOtrosBE.FechaInicioReal.ToString());

					if(!oRegistroProyectoOtrosBE.FechaFinReal.IsNull )
						calFechaFinReal.SelectedDate = Convert.ToDateTime(oRegistroProyectoOtrosBE.FechaFinReal.ToString());
			
					if(!oRegistroProyectoOtrosBE.FechaEntrega.IsNull )
						calFechaEntrega.SelectedDate = Convert.ToDateTime(oRegistroProyectoOtrosBE.FechaEntrega.ToString());

					if (calFechaInicioReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO
						&& calFechaFinReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
					{
						TimeSpan dias = calFechaFinReal.SelectedDate - calFechaInicioReal.SelectedDate;
						txtTEjecucion.Text = dias.Days.ToString();
			
					}

				}break;
				case Enumerados.ModoPagina.C:
				{
					if(rbtExtranjero.Checked)
						CellRadio.InnerText = rbtExtranjero.Text;

					if(rbtPeruano.Checked)
						CellRadio.InnerText = rbtPeruano.Text;

					if (!oRegistroProyectoOtrosBE.IdCentroOperativo.IsNull )
						ddlCentroOperativo.SelectedValue = oRegistroProyectoOtrosBE.IdCentroOperativo.ToString();
					else
						CellddlCentroOperativo.InnerText =  Utilitario.Constantes.TEXTOSINDATA;
					
					if (!oRegistroProyectoOtrosBE.IdTipoProducto.IsNull )
						ddlTipoProducto.SelectedValue = oRegistroProyectoOtrosBE.IdTipoProducto.ToString();
					else
						CellddlTipoProducto.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.IdBuque.IsNull )
						ddlTipoBuque.SelectedValue = oRegistroProyectoOtrosBE.IdBuque.ToString();
					else
						CellddlTipoBuque.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.IdEstadoProyecto.IsNull )
						ddlEstadoProyecto.SelectedValue = oRegistroProyectoOtrosBE.IdEstadoProyecto.ToString();
					else
						CellddlEstadoProyecto.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.IdMaterial.IsNull )
						ddlMaterial.SelectedValue = oRegistroProyectoOtrosBE.IdMaterial.ToString();
					else
						CellddlMaterial.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.IdTipoDocumento.IsNull )
						ddlTipoDocumento.SelectedValue = oRegistroProyectoOtrosBE.IdTipoDocumento.ToString();
					else
						CellddlTipoDocumento.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.IdTipoOtroDocumento.IsNull )
						ddlOtroTipoDocumento.SelectedValue = oRegistroProyectoOtrosBE.IdTipoOtroDocumento.ToString();
					else
						CellddlOtroTipoDocumento.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.IdMoneda.IsNull )
						ddlMoneda.SelectedValue = oRegistroProyectoOtrosBE.IdMoneda.ToString();
					else
						CellddlMoneda.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.FechaInicioContractual.IsNull )
					{
						calFechaInicioContractual.Visible= false;
						CellcalFechaInicioContractual.InnerText = oRegistroProyectoOtrosBE.FechaInicioContractual.Value.ToShortDateString();
					}
					else
						CellcalFechaInicioContractual.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.FechaFinContractual.IsNull )
					{
						calFechaInicioContractual.Visible= false;
						CellcalFechaFinContractual.InnerText = oRegistroProyectoOtrosBE.FechaFinContractual.Value.ToShortDateString();
					}
					else
						CellcalFechaFinContractual.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.FechaAcuerdo.IsNull )
					{
						calFechaFirmaAcuerdo.Visible= false;
						CeldacalFechaFirmaAcuerdo.InnerText = oRegistroProyectoOtrosBE.FechaAcuerdo.Value.ToShortDateString();
					}
					else
						CeldacalFechaFirmaAcuerdo.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.FechaInicioReal.IsNull )
					{
						calFechaInicioReal.Visible= false;
						CeldacalFechaInicioReal.InnerText = oRegistroProyectoOtrosBE.FechaInicioReal.Value.ToShortDateString();
					}
					else
						CeldacalFechaInicioReal.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.FechaFinReal.IsNull )
					{
						calFechaFinReal.Visible= false;
						CellcalFechaFinReal.InnerText = oRegistroProyectoOtrosBE.FechaFinReal.Value.ToShortDateString();
					}
					else
						CellcalFechaFinReal.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.FechaEntrega.IsNull )
					{
						calFechaEntrega.Visible= false;
						CellcalFechaEntrega.InnerText = oRegistroProyectoOtrosBE.FechaEntrega.Value.ToShortDateString();
					}
					else
						CellcalFechaEntrega.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.PesoNeto.IsNull )
						txtPesoNeto.Text = oRegistroProyectoOtrosBE.PesoNeto.ToString();
					else
						CelltxtPesoNeto.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.PesoBruto.IsNull )
						txtPesoBruto.Text = oRegistroProyectoOtrosBE.PesoBruto.ToString();
					else
						celltxtPesoBruto.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.PrecioContractual.IsNull )
						CelltxtPrecioContractual.InnerText = oRegistroProyectoOtrosBE.PrecioContractual.Value.ToString(Utilitario.Constantes.FORMATODECIMAL4);
					else
						CelltxtPrecioContractual.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.PrecioReal.IsNull )
						CelltxtPrecioReal.InnerText =  oRegistroProyectoOtrosBE.PrecioReal.Value.ToString(Utilitario.Constantes.FORMATODECIMAL4);	
					else
						CelltxtPrecioReal.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					
					if (!oRegistroProyectoOtrosBE.RutaPresupuesto.IsNull )
					{
						rutaArchivoPresupuesto = RutaImagenServerProyecto +  "\\" +  oRegistroProyectoOtrosBE.RutaPresupuesto.ToString();
						hlkPresupuesto.Text = oRegistroProyectoOtrosBE.RutaPresupuesto.ToString();
						hlkPresupuesto.NavigateUrl = rutaArchivoPresupuesto ;
						hlkPresupuesto.Visible = true;
					}
					else
						CellfPresupuesto.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.RutaContrato.IsNull)
					{
						rutaArchivoContrato = RutaImagenServerProyecto +  "\\" +  oRegistroProyectoOtrosBE.RutaContrato.ToString();
						hlkContrato.Text = oRegistroProyectoOtrosBE.RutaContrato.ToString();
						hlkContrato.NavigateUrl = rutaArchivoContrato ;
						hlkContrato.Visible = true;
					}
					else
						CellfContrato.InnerText = Utilitario.Constantes.TEXTOSINDATA;

			
					if (!oRegistroProyectoOtrosBE.RutaEspecificacion.IsNull )
					{
						rutaArchivoEspecificaciones = RutaImagenServerProyecto +  "\\" +  oRegistroProyectoOtrosBE.RutaEspecificacion.ToString();
						hlkEspecificacionTecnica.Text = oRegistroProyectoOtrosBE.RutaEspecificacion.ToString();
						hlkEspecificacionTecnica.NavigateUrl = rutaArchivoEspecificaciones ;
						hlkEspecificacionTecnica.Visible = true;
					}
					else
						CellfEspecificaciones.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.RutaPlano.IsNull )
					{
						rutaArchivoPlano = RutaImagenServerProyecto +  "\\" +  oRegistroProyectoOtrosBE.RutaPlano.ToString();
						hlkPlano.Text = oRegistroProyectoOtrosBE.RutaPlano.ToString();
						hlkPlano.NavigateUrl = rutaArchivoPlano ;
						hlkPlano.Visible = true;
					}
					else
						CellfPlano.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.RutaImagen.IsNull )
					{
						hFoto.Value =Convert.ToString( oRegistroProyectoOtrosBE.RutaImagen);
						string RutaImagen=RutaImagenServerProyecto + oRegistroProyectoOtrosBE.RutaImagen.Value;
						imgProyecto.ImageUrl = RutaImagen;
						hFoto.Value = oRegistroProyectoOtrosBE.RutaImagen.Value;
					}

					if (!oRegistroProyectoOtrosBE.IdJefeProyecto.IsNull)
					{
						hIdJefeProyecto.Value= oRegistroProyectoOtrosBE.IdJefeProyecto.ToString();
						CPersonal oCPersonal = new CPersonal();
						txtJefeProyectos.Text = oCPersonal.ObtenerNombrePersonal(Convert.ToInt32(oRegistroProyectoOtrosBE.IdJefeProyecto));
					}
					else
						txtJefeProyectos.Text = Utilitario.Constantes.TEXTOSINDATA;
				
					if (!oRegistroProyectoOtrosBE.IdCliente.IsNull )
					{
						hIdCliente.Value = oRegistroProyectoOtrosBE.IdCliente.ToString();
						CCliente oCCliente = new CCliente();
						txtRazonSocial.Text=  oCCliente.ObtenerNombreCliente(Convert.ToInt32(hIdCliente.Value));
					}
					else
						txtRazonSocial.Text = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.FechaInicioReal.IsNull
						&& !oRegistroProyectoOtrosBE.FechaFinReal.IsNull)
					{
						TimeSpan dias = Convert.ToDateTime(oRegistroProyectoOtrosBE.FechaFinReal) - Convert.ToDateTime(oRegistroProyectoOtrosBE.FechaInicioReal);
						txtTEjecucion.Text = dias.Days.ToString();
					}
					else
						txtTEjecucion.Text = Utilitario.Constantes.TEXTOSINDATA;

				}break;
			}

		
			if (!oRegistroProyectoOtrosBE.SubTipo.IsNull )
				txtSubTipo.Text = oRegistroProyectoOtrosBE.SubTipo.ToString();

			if (!oRegistroProyectoOtrosBE.Tramos.IsNull )
				txtTramos.Text = oRegistroProyectoOtrosBE.Tramos.ToString();

			if (!oRegistroProyectoOtrosBE.Capacidad.IsNull )
				txtCapacidad.Text = oRegistroProyectoOtrosBE.Capacidad.ToString();

			if (!oRegistroProyectoOtrosBE.Dimension.IsNull )
				txtDimesion.Text = oRegistroProyectoOtrosBE.Dimension.ToString();

			if (!oRegistroProyectoOtrosBE.Diametro.IsNull )
				txtDiametro.Text = oRegistroProyectoOtrosBE.Diametro.ToString();

			if (!oRegistroProyectoOtrosBE.Espesor.IsNull )
				txtEspesor.Text = oRegistroProyectoOtrosBE.Espesor.ToString();

			if (!oRegistroProyectoOtrosBE.TipoMaterial.IsNull )
				txtTipoMaterial.Text = oRegistroProyectoOtrosBE.TipoMaterial.ToString();
			
			if (!oRegistroProyectoOtrosBE.DocumentoPrincipal.IsNull )
				txtDocumentoPrincipal.Text = oRegistroProyectoOtrosBE.DocumentoPrincipal.ToString();			
			
			if (!oRegistroProyectoOtrosBE.OtroDocumento.IsNull )
				txtOtroDocumento.Text = oRegistroProyectoOtrosBE.OtroDocumento.ToString();			

			if (!oRegistroProyectoOtrosBE.FuenteInformacion.IsNull )
				txtFuenteInformacion.Text = oRegistroProyectoOtrosBE.FuenteInformacion.ToString();

			if (!oRegistroProyectoOtrosBE.Localidad.IsNull )
				txtLocalidad.Text=oRegistroProyectoOtrosBE.Localidad.ToString();

			if (!oRegistroProyectoOtrosBE.Observaciones.IsNull )
				txtObservaciones.Text = oRegistroProyectoOtrosBE.Observaciones.ToString();

			
		}

		private void calcularEjecucion()
		{
			if (calFechaInicioReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO
				&& calFechaFinReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
			{
			    TimeSpan dias = calFechaFinReal.SelectedDate - calFechaInicioReal.SelectedDate;
				txtTEjecucion.Text = dias.Days.ToString();
			
			}
		}

		public void CargarModoConsulta()
		{
			ibtnCancelar.Visible = Utilitario.Constantes.VALORUNCHECKEDBOOL;
			this.CargarModoModificar();
					
			this.fFoto.Visible = Utilitario.Constantes.VALORUNCHECKEDBOOL;
			chkContrato.Visible = false;
			chkPlano.Visible = false;
			chkEspecificaciones.Visible = false;
			chkPresupuesto.Visible = false;

			this.tblConsulta.Visible = true;
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
			
			if(this.ddlCentroOperativo.SelectedValue == Utilitario.Constantes.VALORSELECCIONAR)
			{
				ltlMensaje.Text=Helper.MensajeAlert("Seleccione un centro operativo");
				return false;
			}
			/*if(this.ddlTipoProducto.SelectedValue == Utilitario.Constantes.VALORSELECCIONAR)
			{
				ltlMensaje.Text=Helper.MensajeAlert("Seleccione un tipo de linea de producto");
				return false;
			}
			if(this.ddlTipoBuque.SelectedValue == Utilitario.Constantes.VALORSELECCIONAR)
			{
				ltlMensaje.Text=Helper.MensajeAlert("Seleccione un tipo de producto");
				return false;
			}
			if(this.ddlEstadoProyecto.SelectedValue == Utilitario.Constantes.VALORSELECCIONAR)
			{
				ltlMensaje.Text=Helper.MensajeAlert("Seleccione un estado de proyecto");
				return false;
            }
			if(this.ddlTipoDocumento.SelectedValue == Utilitario.Constantes.VALORSELECCIONAR)
			{
				ltlMensaje.Text=Helper.MensajeAlert("Seleccione un tipo de documento");
				return false;
			}
			if(this.ddlOtroTipoDocumento.SelectedValue == Utilitario.Constantes.VALORSELECCIONAR)
			{
				ltlMensaje.Text=Helper.MensajeAlert("Seleccione un tipo de otro documento");
				return false;
			}
			if(this.ddlMoneda.SelectedValue == Utilitario.Constantes.VALORSELECCIONAR)
			{
				ltlMensaje.Text=Helper.MensajeAlert("Seleccione un tipo de moneda");
				return false;
			}
			if(this.ddlMaterial.SelectedValue == Utilitario.Constantes.VALORSELECCIONAR)
			{
				ltlMensaje.Text=Helper.MensajeAlert("Seleccione un tipo de material");
				return false;
			}*/


			return true;
			
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		private void dllPais_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CUbigeo oCUbigeo = new CUbigeo();
			ddlRegion.DataSource = oCUbigeo.LlenarProvincia(dllPais.SelectedValue.ToString());
			ddlRegion.DataTextField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlRegion.DataValueField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlRegion.DataBind();
		}

		private void ddlRegion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CUbigeo oCUbigeo = new CUbigeo();
			ddlProvincia.DataSource = oCUbigeo.LlenarDistrito(ddlRegion.SelectedValue.ToString());
			ddlProvincia.DataTextField = Enumerados.ColumnasUbigeo.NombreDistrito.ToString();
			ddlProvincia.DataValueField = Enumerados.ColumnasUbigeo.IdUbigeo.ToString();
			ddlProvincia.DataBind();
		}

		private void calFechaInicioReal_DateChanged(object sender, System.EventArgs e)
		{
			if(calFechaFinReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO
				&& calFechaInicioReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
			{
				calcularEjecucion();
			}
		}

		private void calFechaFinReal_DateChanged(object sender, System.EventArgs e)
		{
			if(calFechaFinReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO
				&& calFechaInicioReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
			{
				calcularEjecucion();
			}
		}
		#endregion

		#region Constantes
		//Constantes
		private const string KEYIDCLIENTE ="KEYIDCLIENTE";
		int idTablabuque = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaBuques);
		int idTipoProducto = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TipoProducto);
		int idTipoMaterial = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TiposMaterial);
		int idTipoDocumento = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaTipoDocumentos);
		int idEstadoProyecto = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ProyectosEstadoProyectoSegunGrupoProyecto);
		int idTipoModena= Convert.ToInt32(Utilitario.Enumerados.TablasTabla.Moneda);

		//Jscript
		private string JMOSTRARIMAGEN = "MuestraImagen('imgProyecto',document.forms[0].fFoto,1)";
		
		//URL
		const string URLBUSQUEDACLIENTE="../../General/BuscarCliente.aspx";
		const string URLBUSQUEDAPERSONAL = "BusquedaPersonal.aspx";
		const string URLBUSQUEDAENTIDAD = "../../Legal/BusquedaEntidad.aspx?";

		//Mensajes
		const string MENSAJECONSULTAR= "Se ingreso a Detalle de registros proyectos otros";
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO PROYECTO";
		const string TITULOMODOMODIFICAR = "ACTUALIZACION DE PROYECTOS";
		const string TITULOMODOCONSULTA = "CONSULTA DE PROYECTOS";
			
		//jscript
		const string JRETURN = " return false;";
		const string JRETURNDOS = "; return false;";

		string rutaArchivoPlano,rutaArchivoPresupuesto,rutaArchivoContrato,rutaArchivoEspecificaciones;
		
		//key
		const string KEYIDREGISTROPROYECTOOTROS="IDREGISTROPROYECTOOTROS";
		const string KEYIDUBIGEO="IDUBIGEO";
		const string KEYIDCENTROOPERATIVO="IDCENTROOPERATIVO";
		const string MENSAJEREGISTRO = "Se registro un proyecto MM";
		
		//Otros
		string RutaImagenServerProyecto = Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaImagenServerProyectoEjecucionTerminado);
		string RutaImagenCarpetaProyecto = Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaImagenCarpetaProyectoEjecucionTerminado);
		const string ARCHIVO = "sinfoto.jpg";
		string strFilename;
		string[] res;
		int i;
		const string SeparadorExtencion=".";
		const int TAMANOARCHIVO=5000000;
		const string SiglaProyecto="COM";
		const string FORMATOCEROS="000000";

		private void txtFuenteInformacion_TextChanged(object sender, System.EventArgs e)
		{
		
		}
		
		
		#region Activar

		#endregion
		#endregion
	}
}
