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
	/// Summary description for DetalleConsultarRegistroProyectoMM.
	/// </summary>
	public class DetalleConsultarRegistroProyectoMM : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlMaterial;
		protected System.Web.UI.WebControls.TextBox txtFuenteInformacion;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.TextBox txtIdProyecto;
		protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarDependencia;
		protected System.Web.UI.WebControls.TextBox txtRazonSocial;
		protected System.Web.UI.WebControls.DropDownList ddlTipoProducto;
		protected System.Web.UI.WebControls.DropDownList ddlTipoBuque;
		protected System.Web.UI.WebControls.TextBox txtSubTipo;
		protected System.Web.UI.WebControls.Label lblUbigeo;
		protected System.Web.UI.WebControls.RadioButton rbtExtranjero;
		protected System.Web.UI.WebControls.RadioButton rbtPeruano;
		protected System.Web.UI.WebControls.TextBox txtLocalidad;
		protected System.Web.UI.WebControls.DropDownList ddlRegion;
		protected System.Web.UI.WebControls.DropDownList ddlProvincia;
		protected System.Web.UI.WebControls.DropDownList ddlEstadoProyecto;
		protected System.Web.UI.WebControls.TextBox txtDocumentoPrincipal;
		protected System.Web.UI.WebControls.DropDownList ddlTipoDocumento;
		protected System.Web.UI.WebControls.TextBox txtOtroDocumento;
		protected System.Web.UI.WebControls.DropDownList ddlOtroTipoDocumento;
		protected System.Web.UI.WebControls.DropDownList ddlMoneda;
		protected System.Web.UI.WebControls.TextBox txtVigas;
		protected System.Web.UI.WebControls.DropDownList ddlMaterial;
		protected System.Web.UI.WebControls.TextBox txtTipoMaterial;
		protected System.Web.UI.WebControls.TextBox txtPeralte;
		protected System.Web.UI.WebControls.TextBox txtGalibo;
		protected System.Web.UI.WebControls.TextBox txtTipoRodadura;
		protected System.Web.UI.WebControls.TextBox txtBarandas;
		protected System.Web.UI.WebControls.TextBox txtEscaleras;
		protected System.Web.UI.WebControls.TextBox txtDesagues;
		protected eWorld.UI.NumericBox txtPesoNeto;
		protected eWorld.UI.NumericBox txtPesoBruto;
		protected System.Web.UI.WebControls.ImageButton ibtBuscaJefeProyectos;
		protected System.Web.UI.WebControls.TextBox txtJefeProyectos;
		protected eWorld.UI.CalendarPopup calFechaFirmaAcuerdo;
		protected eWorld.UI.CalendarPopup calFechaInicioContractual;
		protected eWorld.UI.CalendarPopup calFechaFinContractual;
		protected eWorld.UI.CalendarPopup calFechaInicioReal;
		protected eWorld.UI.CalendarPopup calFechaFinReal;
		protected eWorld.UI.CalendarPopup calFechaEntrega;
		protected System.Web.UI.WebControls.TextBox txtTEjecucion;
		protected System.Web.UI.WebControls.TextBox txtVeredas;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.HyperLink hlkPresupuesto;
		protected System.Web.UI.WebControls.HyperLink hlkEspecificacionTecnica;
		protected System.Web.UI.WebControls.Label lblEspTecnica;
		protected System.Web.UI.WebControls.HyperLink hlkPlano;
		protected System.Web.UI.WebControls.Label lblPlano;
		protected System.Web.UI.WebControls.HyperLink hlkContrato;
		protected System.Web.UI.WebControls.Label lblContrato;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlInputFile fEspecificaciones;
		protected System.Web.UI.HtmlControls.HtmlInputFile fPresupuesto;
		protected System.Web.UI.HtmlControls.HtmlInputFile fContrato;
		protected System.Web.UI.HtmlControls.HtmlInputFile fPlano;
		protected System.Web.UI.WebControls.Label lblPresupuesto;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblDatosGenerales;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.Image imgProyecto;
		protected System.Web.UI.WebControls.Label lblIdProyecto;
		protected System.Web.UI.WebControls.Label lnlCO;
		protected System.Web.UI.WebControls.Label lblCliente;
		protected System.Web.UI.WebControls.Label lblTipoProducto;
		protected System.Web.UI.WebControls.Label lblTipoBuque;
		protected System.Web.UI.WebControls.Label lblSubTipo;
		protected System.Web.UI.WebControls.Label lblTipoCliente;
		protected System.Web.UI.WebControls.Label lblLugarUno;
		protected System.Web.UI.WebControls.Label lblLugardos;
		protected System.Web.UI.WebControls.Label lblLugartres;
		protected System.Web.UI.WebControls.Label lblTituloAspectosTecnicos;
		protected System.Web.UI.WebControls.Label lblTramos;
		protected System.Web.UI.WebControls.TextBox txtTramos;
		protected System.Web.UI.WebControls.Label lblMaterial;
		protected System.Web.UI.WebControls.Label lblCapacidad;
		protected System.Web.UI.WebControls.Label lblTipoMaterial;
		protected System.Web.UI.WebControls.Label lblDimension;
		protected System.Web.UI.WebControls.Label lblPesoNeto;
		protected System.Web.UI.WebControls.Label lblPesoBruto;
		protected System.Web.UI.WebControls.Label lblEspesor;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblAspectosAdministrativos;
		protected System.Web.UI.WebControls.Label lblEstado;
		protected System.Web.UI.WebControls.Label lblJefeProyecto;
		protected System.Web.UI.WebControls.Label lblDocumentoPrincipal;
		protected System.Web.UI.WebControls.Label lblFirmaAcuerdo;
		protected System.Web.UI.WebControls.Label lblTipoDocumento;
		protected System.Web.UI.WebControls.Label lblInicioContractual;
		protected System.Web.UI.WebControls.Label lblOtroDocumento;
		protected System.Web.UI.WebControls.Label lblFinContractual;
		protected System.Web.UI.WebControls.Label lblOtroTipoDocumento;
		protected System.Web.UI.WebControls.Label lblInicioreal;
		protected System.Web.UI.WebControls.Label lblPrecioContractual;
		protected System.Web.UI.WebControls.Label lblFinReal;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblTermino;
		protected System.Web.UI.WebControls.Label lblIdMoneda;
		protected System.Web.UI.WebControls.Label lblEjecucion;
		protected System.Web.UI.WebControls.Label lblFuenteInformacion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.HtmlControls.HtmlInputFile fFoto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlTipoProducto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlTipoBuque;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellRadio;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlRegion;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlEstadoProyecto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlTipoDocumento;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlOtroTipoDocumento;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlMoneda;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCliente;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFoto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdJefeProyecto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPresupuesto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hContrato;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hEspecificaciones;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected eWorld.UI.NumericBox txtLuz;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected eWorld.UI.NumericBox txtAncho;
		protected eWorld.UI.NumericBox txtAnchoRodadura;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.HtmlControls.HtmlTableCell g;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtCimentacionSuperficial;
		protected System.Web.UI.WebControls.TextBox txtEstribos;
		protected System.Web.UI.WebControls.TextBox txtPilares;
		protected System.Web.UI.WebControls.TextBox txtApoyos;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPlano;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.TextBox txtVias;
		protected System.Web.UI.WebControls.TextBox txtSobreCarga;
		protected System.Web.UI.WebControls.TextBox txtAccesos;
		protected System.Web.UI.WebControls.TextBox txtCimentacionProfunda;
		protected System.Web.UI.HtmlControls.HtmlTable tblAtras;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaFirmaAcuerdo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaInicioContractual;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaFinContractual;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaInicioReal;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaEntrega;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaFinReal;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtPesoNeto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtPesoBruto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtPrecioContractual;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtPrecioReal;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtLuz;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtAncho;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtAnchoRodadura;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellfEspecificaciones;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellfContrato;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellfPresupuesto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellfPlano;
		protected System.Web.UI.WebControls.DropDownList dllPais;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlProvincia;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelldllPais;
		#endregion Controles

		#region Constantes
		private const string KEYIDCLIENTE ="KEYIDCLIENTE";
		private const string KEYIDREGISTROPROYECTOOTROS="IDREGISTROPROYECTOOTROS";
		private const string KEYIDUBIGEO="IDUBIGEO";
		private const string KEYIDCENTROOPERATIVO="IDCENTROOPERATIVO";
		const string ARCHIVO = "sinfoto.jpg";
		const string KEYQID ="Id";
		const int idTipoProducto = 223;
		const int idTipoMaterial = 171;
		const int idEstadoProyecto = 35;
		const int idTipoModena=1;
		const string URLBUSQUEDAENTIDAD = "../../Legal/BusquedaEntidad.aspx?";
		const string URLBUSQUEDACLIENTE = "../../General/BuscarCliente.aspx";
		const string JRETURN = " return false;";
		const string JRETURNDOS = "; return false;";
		const string SeparadorExtencion=".";
		const int TAMANOARCHIVO=5000000;
		const string SiglaProyecto="COM";
		const string FORMATOCEROS="000000";
		const string MENSAJEREGISTRO = "Se registro un proyecto MM";
		const string JMOSTRARIMAGEN = "MuestraImagen('imgProyecto',document.forms[0].fFoto,1)";
		const string JDISABLECONTROL = "controlEnable";
		const string TEXTOVER = "Ver";
		#endregion

		#region Variables
		int idTablabuque = 348;
		int idTipoDocumento = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaTipoDocumentos);
		string rutaArchivoPlano,rutaArchivoPresupuesto,rutaArchivoContrato,rutaArchivoEspecificaciones;
		private string RutaImagenServerProyecto = Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaImagenServerProyectoEjecucionTerminado);
		private string RutaImagenCarpetaProyecto =Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaImagenCarpetaProyectoEjecucionTerminado);
		string strFilename;
		string[] res;
		protected eWorld.UI.NumericBox txtPrecioContractual;
		protected eWorld.UI.NumericBox txtPrealModificado;
		protected System.Web.UI.WebControls.CheckBox ckEliminarFoto;
		protected System.Web.UI.WebControls.CheckBox ckEliminarEspTecnica;
		protected System.Web.UI.WebControls.CheckBox ckEliminarContrato;
		protected System.Web.UI.WebControls.CheckBox ckEliminarPresupuesto;
		protected System.Web.UI.WebControls.CheckBox ckEliminarPlano;
		int i;
		#endregion Variables

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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),"",Enumerados.NivelesErrorLog.I.ToString()));			
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
			this.rbtPeruano.CheckedChanged += new System.EventHandler(this.rbtPeruano_CheckedChanged);
			this.rbtExtranjero.CheckedChanged += new System.EventHandler(this.rbtExtranjero_CheckedChanged);
			this.ddlRegion.SelectedIndexChanged += new System.EventHandler(this.ddlRegion_SelectedIndexChanged);
			this.dllPais.SelectedIndexChanged += new System.EventHandler(this.dllPais_SelectedIndexChanged);
			this.calFechaInicioReal.DateChanged += new eWorld.UI.DateChangedEventHandler(this.calFechaInicioReal_DateChanged);
			this.calFechaFinReal.DateChanged += new eWorld.UI.DateChangedEventHandler(this.calFechaFinReal_DateChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleConsultarRegistroProyectoMM.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleConsultarRegistroProyectoMM.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleConsultarRegistroProyectoMM.LlenarGrillaOrdenamientoPaginacion implementation
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

			this.ddlTipoBuque.DataSource = this.llenarTipoBuque();
			ddlTipoBuque.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlTipoBuque.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlTipoBuque.DataBind();
			ddlTipoBuque.Items.Insert(0,item);

			this.ddlTipoProducto.DataSource = this.llenarTipoProducto();
			ddlTipoProducto.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlTipoProducto.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlTipoProducto.DataBind();
			ddlTipoProducto.Items.Insert(0,item);

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
			this.fFoto.Attributes.Add(Utilitario.Constantes.EVENTOONBLUR, JMOSTRARIMAGEN);
			this.ibtnBuscarDependencia.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Helper.PopupBusqueda(URLBUSQUEDACLIENTE,600,450,70,100,Utilitario.Constantes.VALORUNCHECKEDBOOL)+ JRETURNDOS);
			this.ibtBuscaJefeProyectos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,Helper.PopupBusqueda(URLBUSQUEDAENTIDAD + Utilitario.Constantes.KEYTIPOBUSQUEDAENTIDAD +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.TipoBusquedaEntidad.PE,700,700,true) +  JRETURN);
			this.ckEliminarFoto.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JDISABLECONTROL + "(this,'" + fFoto.ClientID.ToString() + "');" );
			this.ckEliminarEspTecnica.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JDISABLECONTROL + "(this,'" + fEspecificaciones.ClientID.ToString() + "');" );
			this.ckEliminarContrato.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JDISABLECONTROL + "(this,'" + fContrato.ClientID.ToString() + "');" );
			this.ckEliminarPresupuesto.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JDISABLECONTROL + "(this,'" + fPresupuesto.ClientID.ToString() + "');" );
			this.ckEliminarPlano.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JDISABLECONTROL + "(this,'" + fPlano.ClientID.ToString() + "');" );
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleConsultarRegistroProyectoMM.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleConsultarRegistroProyectoMM.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleConsultarRegistroProyectoMM.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleConsultarRegistroProyectoMM.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleConsultarRegistroProyectoMM.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			ProyectosMMBE oProyectosMMBE  = new ProyectosMMBE();
			
			if(txtAccesos.Text != String.Empty)
				oProyectosMMBE.ACCESOS = NullableString.Parse(txtAccesos.Text);

			if(txtAncho.Text != String.Empty)
			oProyectosMMBE.ANCHO = NullableDouble.Parse(txtAncho.Text);
			
			if(txtAnchoRodadura.Text != String.Empty)
				oProyectosMMBE.ANCHORODADURA = NullableDouble.Parse(txtAnchoRodadura.Text);

			if(txtApoyos.Text != String.Empty)
				oProyectosMMBE.APOYOS = NullableString.Parse(txtApoyos.Text);

			if(txtBarandas.Text != String.Empty)
				oProyectosMMBE.BARANDAS = NullableString.Parse(txtBarandas.Text);

			if(txtCimentacionProfunda.Text != String.Empty)
				oProyectosMMBE.CIMENTACIONPROFUNDA = NullableString.Parse(txtCimentacionProfunda.Text);

			if(txtCimentacionSuperficial.Text != String.Empty)
				oProyectosMMBE.CIMENTACIONSUPERFICIAL = NullableString.Parse(txtCimentacionSuperficial.Text);
            
			if(hIdCliente.Value != String.Empty)
				oProyectosMMBE.IDCLIENTE = NullableInt32.Parse(hIdCliente.Value);

			if(txtDesagues.Text != String.Empty)
				oProyectosMMBE.DESAGUES = NullableString.Parse(txtDesagues.Text);

			if(txtDocumentoPrincipal.Text != String.Empty)
				oProyectosMMBE.DOCUMENTOPRINCIPAL = NullableString.Parse(txtDocumentoPrincipal.Text);

			if(calFechaEntrega.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO.ToString())
				oProyectosMMBE.ENTREGA = NullableDateTime.Parse(calFechaEntrega.SelectedDate);

			if(txtEscaleras.Text != String.Empty)
				oProyectosMMBE.ESCALERAS = NullableString.Parse(txtEscaleras.Text);

			if(txtEstribos.Text != String.Empty)
				oProyectosMMBE.ESTRIBOS = NullableString.Parse(txtEstribos.Text);

			if(calFechaFirmaAcuerdo.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO.ToString())
				oProyectosMMBE.FECHAACUERDO = NullableDateTime.Parse(calFechaFirmaAcuerdo.SelectedDate);

			if(calFechaFinContractual.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO.ToString())
				oProyectosMMBE.FINCONTRACTUAL = NullableDateTime.Parse(calFechaFinContractual.SelectedDate);

			if(calFechaFinReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO.ToString())
				oProyectosMMBE.FINREAL = NullableDateTime.Parse(calFechaFinReal.SelectedDate);

			if(txtGalibo.Text != String.Empty)
				oProyectosMMBE.GALIBO = NullableString.Parse(txtGalibo.Text);

			oProyectosMMBE.IDCENTROOPERATIVO = NullableInt32.Parse(ddlCentroOperativo.SelectedValue);

			if(hIdCliente.Value != String.Empty)
				oProyectosMMBE.IDCLIENTE = NullableInt32.Parse(hIdCliente.Value);
			
			if(this.ddlEstadoProyecto.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oProyectosMMBE.IDESTADOPROYECTO = NullableInt32.Parse(ddlEstadoProyecto.SelectedValue);
			}

			oProyectosMMBE.IdHistorico = txtIdProyecto.Text;
			if(this.ddlTipoProducto.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oProyectosMMBE.IDLINEAPRODUCTO = NullableInt32.Parse(ddlTipoProducto.SelectedValue);
			}
			if(this.ddlMaterial.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oProyectosMMBE.IDMATERIALES = NullableInt32.Parse(ddlMaterial.SelectedValue);
			}
			if(this.ddlMoneda.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oProyectosMMBE.IDMONEDA = NullableInt32.Parse(ddlMoneda.SelectedValue);
			}
			if(hIdJefeProyecto.Value != String.Empty)
				oProyectosMMBE.IDPERSONAL = NullableInt32.Parse(hIdJefeProyecto.Value);

			if(this.ddlOtroTipoDocumento.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oProyectosMMBE.IDTIPODOCUMENTOOTROS = NullableInt32.Parse(ddlOtroTipoDocumento.SelectedValue);
			}
			if(this.ddlTipoDocumento.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oProyectosMMBE.IDTIPODOCUMENTOPRINCIPAL = NullableInt32.Parse(ddlTipoDocumento.SelectedValue);
			}
			if(this.ddlTipoBuque.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oProyectosMMBE.IDTIPOPRODUCTO = NullableInt32.Parse(ddlTipoBuque.SelectedValue);
			}
			
				oProyectosMMBE.IDUBIGEO = NullableInt32.Parse(ddlProvincia.SelectedValue);
			
			if(calFechaInicioContractual.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO.ToString())
				oProyectosMMBE.INICIOCONTRACTUAL = NullableDateTime.Parse(calFechaInicioContractual.SelectedDate);

			if(calFechaInicioReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO.ToString())
				oProyectosMMBE.INICIOREAL = NullableDateTime.Parse(calFechaInicioReal.SelectedDate);

			if(txtLocalidad.Text != String.Empty)
				oProyectosMMBE.LOCALIDAD = NullableString.Parse(txtLocalidad.Text);

			if(txtLuz.Text != String.Empty)
				oProyectosMMBE.LUZ = NullableDouble.Parse(txtLuz.Text);

			if(txtNombre.Text != String.Empty)
				oProyectosMMBE.NOMBREPROYECTO = NullableString.Parse(txtNombre.Text);

			if(txtObservaciones.Text != String.Empty)
				oProyectosMMBE.OBSERVACIONES = NullableString.Parse(txtObservaciones.Text);

			if(txtOtroDocumento.Text != String.Empty)
				oProyectosMMBE.OTRODOCUMENTO = NullableString.Parse(txtOtroDocumento.Text);

			if(txtPeralte.Text != String.Empty)
				oProyectosMMBE.PERALTEVL = NullableString.Parse(txtPeralte.Text);

			if(txtPesoBruto.Text != String.Empty)
				oProyectosMMBE.PESOBRUTO = NullableDouble.Parse(txtPesoBruto.Text);

			if(txtPesoNeto.Text != String.Empty)
				oProyectosMMBE.PESONETO = NullableDouble.Parse(txtPesoNeto.Text);

			if(txtPilares.Text != String.Empty)
				oProyectosMMBE.PILARES = NullableString.Parse(txtPilares.Text);

			
			if(txtPrecioContractual.Text != String.Empty)
				oProyectosMMBE.PRECIOCONTRACTUAL = NullableDouble.Parse(txtPrecioContractual.Text);

			if(txtPrealModificado.Text != String.Empty)
				oProyectosMMBE.PRECIOREAL = NullableDouble.Parse(txtPrealModificado.Text);

			if(txtSobreCarga.Text != String.Empty)
				oProyectosMMBE.SOBRECARGA = NullableString.Parse(txtSobreCarga.Text);

			if(txtSubTipo.Text != String.Empty)
				oProyectosMMBE.SUBTIPO = NullableString.Parse(txtSubTipo.Text);

			if(txtTipoMaterial.Text != String.Empty)
				oProyectosMMBE.TIPOMATERIAL = NullableString.Parse(txtTipoMaterial.Text);

			if(txtTipoRodadura.Text != String.Empty)
				oProyectosMMBE.TIPORODADURA = NullableString.Parse(txtTipoRodadura.Text);

			if(txtTramos.Text != String.Empty)
				oProyectosMMBE.TRAMOS = NullableString.Parse(txtTramos.Text);

			if(txtVeredas.Text != String.Empty)
				oProyectosMMBE.VEREDAS = NullableString.Parse(txtVeredas.Text);

			if(txtVias.Text != String.Empty)
				oProyectosMMBE.VIAS = NullableString.Parse(txtVias.Text);

			if(txtVigas.Text != String.Empty)
				oProyectosMMBE.VIGAS = NullableString.Parse(txtVigas.Text);

			if(txtFuenteInformacion.Text != String.Empty)
				oProyectosMMBE.FUENTEINFORMACION = NullableString.Parse(txtFuenteInformacion.Text);

			oProyectosMMBE.FechaRegistro = DateTime.Now;
			oProyectosMMBE.IdEstado = Convert.ToInt32(Enumerados.EstadoGeneral.Activo);
			oProyectosMMBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoGeneral);
			oProyectosMMBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			if(fContrato.Value!=String.Empty)
			{
				strFilename = fContrato.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oProyectosMMBE.CONTRATO = strFilename;
			}

			
			if(fEspecificaciones.Value!=String.Empty)
			{
				strFilename = fEspecificaciones.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oProyectosMMBE.ESPECIFICACIONTECNICA = strFilename;
			}

			if(fPresupuesto.Value!=String.Empty)
			{
				strFilename = fPresupuesto.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];
				
				oProyectosMMBE.PRESUPUESTO = strFilename;
			}
		
			if(fPlano.Value!=String.Empty)
			{
				strFilename = fPlano.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oProyectosMMBE.PLANO = strFilename;
			}
	
			if(fFoto.Value!=String.Empty)
			{
				strFilename = fFoto.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oProyectosMMBE.Imagen = strFilename;
			
			}
			else
			{
				oProyectosMMBE.Imagen = ARCHIVO;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oProyectosMMBE);

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
				ltlMensaje.Text = Helper.MensajeRetornoAlert("Se registró un proyecto MM","AdministrarRegistroProyectoOtros.aspx" );
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
					string path =    RutaImagenCarpetaProyecto; //@"C:\P\";
					string strFilename = myFile.FileName;

					string[] res = strFilename.Split('\\');
					int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];
							
					Helper.GuardarImagenServidor(myData,path + strFilename);
				}
				else
				{
					ltlMensaje.Text=Helper.MensajeAlert("El tamaño de la foto no debe exceder los 200 KB");
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
			ProyectosMMBE oProyectosMMBE  = new ProyectosMMBE();
			
			oProyectosMMBE.IDPROYECTOMM = Convert.ToInt32(Page.Request.QueryString[KEYQID]);

			if(txtAccesos.Text != String.Empty)
				oProyectosMMBE.ACCESOS = NullableString.Parse(txtAccesos.Text);

			if(txtAncho.Text != String.Empty)
				oProyectosMMBE.ANCHO = NullableDouble.Parse(txtAncho.Text);
			
			if(txtAnchoRodadura.Text != String.Empty)
				oProyectosMMBE.ANCHORODADURA = NullableDouble.Parse(txtAnchoRodadura.Text);

			if(txtApoyos.Text != String.Empty)
				oProyectosMMBE.APOYOS = NullableString.Parse(txtApoyos.Text);

			if(txtBarandas.Text != String.Empty)
				oProyectosMMBE.BARANDAS = NullableString.Parse(txtBarandas.Text);

			if(txtCimentacionProfunda.Text != String.Empty)
				oProyectosMMBE.CIMENTACIONPROFUNDA = NullableString.Parse(txtCimentacionProfunda.Text);

			if(txtCimentacionSuperficial.Text != String.Empty)
				oProyectosMMBE.CIMENTACIONSUPERFICIAL = NullableString.Parse(txtCimentacionSuperficial.Text);
            
			if(hIdCliente.Value != String.Empty)
				oProyectosMMBE.IDCLIENTE = NullableInt32.Parse(hIdCliente.Value);

			if(txtDesagues.Text != String.Empty)
				oProyectosMMBE.DESAGUES = NullableString.Parse(txtDesagues.Text);

			if(txtDocumentoPrincipal.Text != String.Empty)
				oProyectosMMBE.DOCUMENTOPRINCIPAL = NullableString.Parse(txtDocumentoPrincipal.Text);

			if(calFechaEntrega.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO.ToString())
				oProyectosMMBE.ENTREGA = NullableDateTime.Parse(calFechaEntrega.SelectedDate);

			if(txtEscaleras.Text != String.Empty)
				oProyectosMMBE.ESCALERAS = NullableString.Parse(txtEscaleras.Text);

			if(txtEstribos.Text != String.Empty)
				oProyectosMMBE.ESTRIBOS = NullableString.Parse(txtEstribos.Text);

			if(calFechaFirmaAcuerdo.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO.ToString())
				oProyectosMMBE.FECHAACUERDO = NullableDateTime.Parse(calFechaFirmaAcuerdo.SelectedDate);

			if(calFechaFinContractual.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO.ToString())
				oProyectosMMBE.FINCONTRACTUAL = NullableDateTime.Parse(calFechaFinContractual.SelectedDate);

			if(calFechaFinReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO.ToString())
				oProyectosMMBE.FINREAL = NullableDateTime.Parse(calFechaFinReal.SelectedDate);

			if(txtGalibo.Text != String.Empty)
				oProyectosMMBE.GALIBO = NullableString.Parse(txtGalibo.Text);

			oProyectosMMBE.IDCENTROOPERATIVO = NullableInt32.Parse(ddlCentroOperativo.SelectedValue);

			if(hIdCliente.Value != String.Empty)
				oProyectosMMBE.IDCLIENTE = NullableInt32.Parse(hIdCliente.Value);

			if(this.ddlEstadoProyecto.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oProyectosMMBE.IDESTADOPROYECTO = NullableInt32.Parse(ddlEstadoProyecto.SelectedValue);
			}
			oProyectosMMBE.IdHistorico = txtIdProyecto.Text;
			if(this.ddlTipoProducto.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oProyectosMMBE.IDLINEAPRODUCTO = NullableInt32.Parse(ddlTipoProducto.SelectedValue);
			}
			if(this.ddlMaterial.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oProyectosMMBE.IDMATERIALES = NullableInt32.Parse(ddlMaterial.SelectedValue);
			}
			if(this.ddlMoneda.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oProyectosMMBE.IDMONEDA = NullableInt32.Parse(ddlMoneda.SelectedValue);
			}
			if(hIdJefeProyecto.Value != String.Empty)
				oProyectosMMBE.IDPERSONAL = NullableInt32.Parse(hIdJefeProyecto.Value);
			if(this.ddlOtroTipoDocumento.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oProyectosMMBE.IDTIPODOCUMENTOOTROS = NullableInt32.Parse(ddlOtroTipoDocumento.SelectedValue);
			}
			if(this.ddlTipoDocumento.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oProyectosMMBE.IDTIPODOCUMENTOPRINCIPAL = NullableInt32.Parse(ddlTipoDocumento.SelectedValue);
			}
			if(this.ddlTipoBuque.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oProyectosMMBE.IDTIPOPRODUCTO = NullableInt32.Parse(ddlTipoBuque.SelectedValue);
			}
			oProyectosMMBE.IDUBIGEO = NullableInt32.Parse(ddlProvincia.SelectedValue);

			if(calFechaInicioContractual.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO.ToString())
				oProyectosMMBE.INICIOCONTRACTUAL = NullableDateTime.Parse(calFechaInicioContractual.SelectedDate);

			if(calFechaInicioReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO.ToString())
				oProyectosMMBE.INICIOREAL = NullableDateTime.Parse(calFechaInicioReal.SelectedDate);

			if(txtLocalidad.Text != String.Empty)
				oProyectosMMBE.LOCALIDAD = NullableString.Parse(txtLocalidad.Text);

			if(txtLuz.Text != String.Empty)
				oProyectosMMBE.LUZ = NullableDouble.Parse(txtLuz.Text);

			if(txtNombre.Text != String.Empty)
				oProyectosMMBE.NOMBREPROYECTO = NullableString.Parse(txtNombre.Text);

			if(txtObservaciones.Text != String.Empty)
				oProyectosMMBE.OBSERVACIONES = NullableString.Parse(txtObservaciones.Text);

			if(txtOtroDocumento.Text != String.Empty)
				oProyectosMMBE.OTRODOCUMENTO = NullableString.Parse(txtOtroDocumento.Text);

			if(txtPeralte.Text != String.Empty)
				oProyectosMMBE.PERALTEVL = NullableString.Parse(txtPeralte.Text);

			if(txtPesoBruto.Text != String.Empty)
				oProyectosMMBE.PESOBRUTO = NullableDouble.Parse(txtPesoBruto.Text);

			if(txtPesoNeto.Text != String.Empty)
				oProyectosMMBE.PESONETO = NullableDouble.Parse(txtPesoNeto.Text);

			if(txtPilares.Text != String.Empty)
				oProyectosMMBE.PILARES = NullableString.Parse(txtPilares.Text);

			if(txtPilares.Text != String.Empty)
				oProyectosMMBE.PILARES = NullableString.Parse(txtPilares.Text);
			
			if(txtPrecioContractual.Text != String.Empty)
				oProyectosMMBE.PRECIOCONTRACTUAL = NullableDouble.Parse(txtPrecioContractual.Text);

			if(txtPrealModificado.Text != String.Empty)
				oProyectosMMBE.PRECIOREAL = NullableDouble.Parse(txtPrealModificado.Text);

			if(txtSobreCarga.Text != String.Empty)
				oProyectosMMBE.SOBRECARGA = NullableString.Parse(txtSobreCarga.Text);

			if(txtSubTipo.Text != String.Empty)
				oProyectosMMBE.SUBTIPO = NullableString.Parse(txtSubTipo.Text);

			if(txtTipoMaterial.Text != String.Empty)
				oProyectosMMBE.TIPOMATERIAL = NullableString.Parse(txtTipoMaterial.Text);

			if(txtTipoRodadura.Text != String.Empty)
				oProyectosMMBE.TIPORODADURA = NullableString.Parse(txtTipoRodadura.Text);

			if(txtTramos.Text != String.Empty)
				oProyectosMMBE.TRAMOS = NullableString.Parse(txtTramos.Text);

			if(txtVeredas.Text != String.Empty)
				oProyectosMMBE.VEREDAS = NullableString.Parse(txtVeredas.Text);

			if(txtVias.Text != String.Empty)
				oProyectosMMBE.VIAS = NullableString.Parse(txtVias.Text);

			if(txtVigas.Text != String.Empty)
				oProyectosMMBE.VIGAS = NullableString.Parse(txtVigas.Text);

			if(txtFuenteInformacion.Text != String.Empty)
				oProyectosMMBE.FUENTEINFORMACION = NullableString.Parse(txtFuenteInformacion.Text);

			oProyectosMMBE.FechaActualizacion = DateTime.Now;
			oProyectosMMBE.IdEstado = Convert.ToInt32(Enumerados.EstadoGeneral.Activo);
			oProyectosMMBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoGeneral);
			oProyectosMMBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			if(!ckEliminarContrato.Checked)
			{
				if(fContrato.Value!=String.Empty )
				{
					strFilename = fContrato.PostedFile.FileName;
					res = strFilename.Split('\\');
					i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];

					oProyectosMMBE.CONTRATO = strFilename;
				}
				else
					oProyectosMMBE.CONTRATO = hContrato.Value;
			}
			else
			{
				oProyectosMMBE.CONTRATO = String.Empty;
			}

			if(!ckEliminarEspTecnica.Checked)
			{
				if(fEspecificaciones.Value!=String.Empty)
				{
					strFilename = fEspecificaciones.PostedFile.FileName;
					res = strFilename.Split('\\');
					i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];

					oProyectosMMBE.ESPECIFICACIONTECNICA = strFilename;
				}
				else
					oProyectosMMBE.ESPECIFICACIONTECNICA = hEspecificaciones.Value;
			}
			else
			{
				oProyectosMMBE.ESPECIFICACIONTECNICA = String.Empty;
			}
			if(!ckEliminarPresupuesto.Checked)
			{
				if(fPresupuesto.Value!=String.Empty)
				{
					strFilename = fPresupuesto.PostedFile.FileName;
					res = strFilename.Split('\\');
					i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];
				
					oProyectosMMBE.PRESUPUESTO = strFilename;
				}
				else
					oProyectosMMBE.PRESUPUESTO = hPresupuesto.Value;
			}
			else
			{
				oProyectosMMBE.PRESUPUESTO = String.Empty;
			}

			if(!ckEliminarPlano.Checked)
			{
				if(fPlano.Value!=String.Empty)
				{
					strFilename = fPlano.PostedFile.FileName;
					res = strFilename.Split('\\');
					i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];

					oProyectosMMBE.PLANO = strFilename;
				
				}
				else
				{
					oProyectosMMBE.PLANO = hPlano.Value;
				}
			}
			else
			{
				oProyectosMMBE.PLANO = String.Empty;
			}
	
			if(!ckEliminarFoto.Checked)
			{
				if(fFoto.Value!=String.Empty)
				{
					strFilename = fFoto.PostedFile.FileName;
					res = strFilename.Split('\\');
					i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];

					oProyectosMMBE.Imagen = strFilename;
				}
				else
				{
					strFilename = imgProyecto.ImageUrl;
					res = strFilename.Split('/');
					i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];

					oProyectosMMBE.Imagen = strFilename;	
				}
			}
			else
			{
				oProyectosMMBE.Imagen = ARCHIVO;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oProyectosMMBE);

			if (retorno == Utilitario.Constantes.VALORCONFIRMACIONREGISTRO)
			{
				if (!ckEliminarFoto.Checked && fFoto.Value!=String.Empty)
					this.GuardarImagen();
				
				if (!ckEliminarContrato.Checked && fContrato.Value!=String.Empty)
					this.GuardarDocumentoContrato(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS]));

				if (!ckEliminarEspTecnica.Checked && fEspecificaciones.Value != String.Empty)
					this.GuardarDocumentoEspecificaciones(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS]));
				
				if (!ckEliminarPlano.Checked && fPlano.Value != String.Empty)
					this.GuardarDocumentoPlano(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS]));

				if (!ckEliminarPresupuesto.Checked && fPresupuesto.Value != String.Empty)
					this.GuardarDocumentoPresupuesto(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS]));
				
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJEREGISTRO + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert("Se modificó un proyecto MM","AdministrarRegistroProyectoOtros.aspx" );
				
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleConsultarRegistroProyectoMM.Eliminar implementation
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
			rbtPeruano.Checked = true;
			ckEliminarFoto.Visible = false;
			ckEliminarEspTecnica.Visible = false;
			ckEliminarContrato.Visible = false;
			ckEliminarPresupuesto.Visible = false;
			ckEliminarPlano.Visible = false;
			HabilitarClientePeruano();
		}

		public void CargarModoModificar()
		{
			ckEliminarFoto.Visible = true;
			ckEliminarEspTecnica.Visible = true;
			ckEliminarContrato.Visible = true;
			ckEliminarPresupuesto.Visible = true;
			ckEliminarPlano.Visible = true;

			if (Page.Request.QueryString[KEYIDCLIENTE] == Utilitario.Constantes.IDCLIENTEMARINA.ToString())
				lblTermino.Text = Utilitario.Constantes.TEXTOSETIQUETAMARINA;

			tblAtras.Visible = false;

			CMantenimientos oCMantenimientos = new CMantenimientos();
			ProyectosMMBE oProyectosMMBE = (ProyectosMMBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.ProyectosMMNTAD.ToString());
			
			if(oProyectosMMBE!=null)
			{
				if (!oProyectosMMBE.NOMBREPROYECTO.IsNull )
				{
					txtNombre.Text=oProyectosMMBE.NOMBREPROYECTO.ToString();
				}
				
				txtIdProyecto.Text = oProyectosMMBE.IdHistorico.ToString();
				
				if (!oProyectosMMBE.IDCLIENTE.IsNull )
				{
					hIdCliente.Value = oProyectosMMBE.IDCLIENTE.ToString();
					CCliente oCCliente = new CCliente();
					txtRazonSocial.Text=  oCCliente.ObtenerNombreCliente(Convert.ToInt32(hIdCliente.Value));
				}

				txtSubTipo.Text=oProyectosMMBE.SUBTIPO.ToString();

				txtLocalidad.Text=oProyectosMMBE.LOCALIDAD.ToString();
				if(!oProyectosMMBE.IDUBIGEO.IsNull)
				{
					CUbigeo oCUbigeo = new CUbigeo();

					if(oProyectosMMBE.IDUBIGEO >= 700101)
					{
						HabilitarClienteExtranjero();
						rbtExtranjero.Checked = true;
						rbtPeruano.Checked = false;
					
						DataRow dr = oCUbigeo.ObtenerNombreUbigeo(Convert.ToInt32(oProyectosMMBE.IDUBIGEO));

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
					
						DataRow dr = oCUbigeo.ObtenerNombreUbigeo(Convert.ToInt32(oProyectosMMBE.IDUBIGEO));

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

				txtLuz.Text=oProyectosMMBE.LUZ.ToString();
				txtTramos.Text=oProyectosMMBE.TRAMOS.ToString();
				txtVias.Text=oProyectosMMBE.VIAS.ToString();
				txtAncho.Text=oProyectosMMBE.ANCHO.ToString();
				txtAnchoRodadura.Text=oProyectosMMBE.ANCHORODADURA.ToString();
				txtSobreCarga.Text=oProyectosMMBE.SOBRECARGA.ToString();
				txtAccesos.Text=oProyectosMMBE.ACCESOS.ToString();
				txtCimentacionSuperficial.Text=oProyectosMMBE.CIMENTACIONSUPERFICIAL.ToString();
				txtCimentacionProfunda.Text=oProyectosMMBE.CIMENTACIONPROFUNDA.ToString();
				txtEstribos.Text=oProyectosMMBE.ESTRIBOS.ToString();
				txtApoyos.Text=oProyectosMMBE.APOYOS.ToString();
				txtVigas.Text=oProyectosMMBE.VIGAS.ToString();
				txtTipoMaterial.Text=oProyectosMMBE.TIPOMATERIAL.ToString();
				txtPeralte.Text=oProyectosMMBE.PERALTEVL.ToString();
				txtGalibo.Text=oProyectosMMBE.GALIBO.ToString();
				txtTipoRodadura.Text=oProyectosMMBE.TIPORODADURA.ToString();
				txtVeredas.Text=oProyectosMMBE.VEREDAS.ToString();
				txtBarandas.Text=oProyectosMMBE.BARANDAS.ToString();
				txtEscaleras.Text=oProyectosMMBE.ESCALERAS.ToString();
				txtDesagues.Text=oProyectosMMBE.DESAGUES.ToString();
				
				if(!oProyectosMMBE.PESONETO.IsNull)
					txtPesoNeto.Text=oProyectosMMBE.PESONETO.ToString();
				
				if(!oProyectosMMBE.PESOBRUTO.IsNull)
					txtPesoBruto.Text=oProyectosMMBE.PESOBRUTO.ToString();

				txtPilares.Text=oProyectosMMBE.PILARES.ToString();
				
				if(!oProyectosMMBE.IDCENTROOPERATIVO.IsNull)
					ddlCentroOperativo.SelectedValue=oProyectosMMBE.IDCENTROOPERATIVO.ToString();
				

				if(!oProyectosMMBE.IDTIPOPRODUCTO.IsNull)
					ddlTipoBuque.SelectedValue=oProyectosMMBE.IDTIPOPRODUCTO.ToString();
				

				if(!oProyectosMMBE.IDLINEAPRODUCTO.IsNull)
					ddlTipoProducto.SelectedValue=oProyectosMMBE.IDLINEAPRODUCTO.ToString();
				

				if(!oProyectosMMBE.IDMATERIALES.IsNull)
					ddlMaterial.SelectedValue=oProyectosMMBE.IDMATERIALES.ToString();
				

				if(!oProyectosMMBE.IDESTADOPROYECTO.IsNull)
					ddlEstadoProyecto.SelectedValue=oProyectosMMBE.IDESTADOPROYECTO.ToString();
				

				if(!oProyectosMMBE.IDTIPODOCUMENTOOTROS.IsNull)
					ddlOtroTipoDocumento.SelectedValue=oProyectosMMBE.IDTIPODOCUMENTOOTROS.ToString();
				

				if(!oProyectosMMBE.IDTIPODOCUMENTOPRINCIPAL.IsNull)
					ddlTipoDocumento.SelectedValue=oProyectosMMBE.IDTIPODOCUMENTOPRINCIPAL.ToString();
				

				if(!oProyectosMMBE.IDMONEDA.IsNull)
					ddlMoneda.SelectedValue=oProyectosMMBE.IDMONEDA.ToString();
			
				txtDocumentoPrincipal.Text=oProyectosMMBE.DOCUMENTOPRINCIPAL.ToString();
				txtOtroDocumento.Text=oProyectosMMBE.OTRODOCUMENTO.ToString();
	
			

				txtFuenteInformacion.Text=oProyectosMMBE.FUENTEINFORMACION.ToString();
				txtObservaciones.Text=oProyectosMMBE.OBSERVACIONES.ToString();
				
				if (!oProyectosMMBE.IDPERSONAL.IsNull)
				{
					hIdJefeProyecto.Value= oProyectosMMBE.IDPERSONAL.ToString();
					CPersonal oCPersonal = new CPersonal();
					txtJefeProyectos.Text = oCPersonal.ObtenerNombrePersonal(Convert.ToInt32(oProyectosMMBE.IDPERSONAL));
				}
				calFechaFirmaAcuerdo.SelectedDate=Convert.ToDateTime(oProyectosMMBE.FECHAACUERDO);
				calFechaInicioContractual.SelectedDate=Convert.ToDateTime(oProyectosMMBE.INICIOCONTRACTUAL);
				calFechaFinContractual.SelectedDate=Convert.ToDateTime(oProyectosMMBE.FINCONTRACTUAL);
				calFechaInicioReal.SelectedDate=Convert.ToDateTime(oProyectosMMBE.INICIOREAL);
				calFechaFinReal.SelectedDate=Convert.ToDateTime(oProyectosMMBE.FINREAL);
				calFechaEntrega.SelectedDate=Convert.ToDateTime(oProyectosMMBE.ENTREGA);
				
				if(!oProyectosMMBE.FINREAL.IsNull && !oProyectosMMBE.INICIOREAL.IsNull )
				{
					TimeSpan dias = Convert.ToDateTime(oProyectosMMBE.FINREAL) - Convert.ToDateTime(oProyectosMMBE.INICIOREAL);
					txtTEjecucion.Text =dias.Days.ToString();
				}
				
				if (!oProyectosMMBE.PRESUPUESTO.IsNull )
				{
					rutaArchivoPresupuesto = RutaImagenServerProyecto +  "\\" +  oProyectosMMBE.PRESUPUESTO.ToString();
					hlkPresupuesto.Text = TEXTOVER;
					hlkPresupuesto.NavigateUrl = rutaArchivoPresupuesto;
					hPresupuesto.Value = oProyectosMMBE.PRESUPUESTO.ToString();
					hlkPresupuesto.Visible = true;
				}
				else
				{
					hlkPresupuesto.Visible = false;
					ckEliminarPresupuesto.Enabled = false;
				}
				if (!oProyectosMMBE.CONTRATO.IsNull)
				{
					rutaArchivoContrato = RutaImagenServerProyecto +  "\\" +  oProyectosMMBE.CONTRATO.ToString();
					hlkContrato.Text = TEXTOVER;
					hlkContrato.NavigateUrl = rutaArchivoContrato;
					hContrato.Value = oProyectosMMBE.CONTRATO.ToString();
					hlkContrato.Visible = true;
				}
				else
				{
					hlkContrato.Visible = false;
					ckEliminarContrato.Enabled = false;
				}
			
				if (!oProyectosMMBE.ESPECIFICACIONTECNICA.IsNull )
				{
					rutaArchivoEspecificaciones = RutaImagenServerProyecto +  "\\" +  oProyectosMMBE.ESPECIFICACIONTECNICA.ToString();
					hlkEspecificacionTecnica.Text = TEXTOVER;
					hlkEspecificacionTecnica.NavigateUrl = rutaArchivoEspecificaciones;
					hEspecificaciones.Value = oProyectosMMBE.ESPECIFICACIONTECNICA.ToString();
					hlkEspecificacionTecnica.Visible = true;
				}
				else
				{
					hlkEspecificacionTecnica.Visible = false;
					ckEliminarEspTecnica.Enabled = false;
				}

				if (!oProyectosMMBE.PLANO.IsNull )
				{
					rutaArchivoPlano = RutaImagenServerProyecto +  "\\" +  oProyectosMMBE.PLANO.ToString();
					hlkPlano.Text = TEXTOVER;
					hlkPlano.NavigateUrl = rutaArchivoPlano;
					hPlano.Value = oProyectosMMBE.PLANO.ToString();
					hlkPlano.Visible = true;
				}
				else
				{
					hlkPlano.Visible = false;	
					ckEliminarPlano.Enabled = false;
				}
				if (!oProyectosMMBE.Imagen.IsNull )
				{
					hFoto.Value = oProyectosMMBE.Imagen.ToString();
					imgProyecto.ImageUrl = RutaImagenServerProyecto + hFoto.Value;
				}
				else
				{
					imgProyecto.ImageUrl= RutaImagenServerProyecto + "sinfoto.jpg";
					ckEliminarFoto.Visible = false;
				}

				if(!oProyectosMMBE.PRECIOREAL.IsNull)
					txtPrealModificado.Text=oProyectosMMBE.PRECIOREAL.Value.ToString();
							
				if(!oProyectosMMBE.PRECIOCONTRACTUAL.IsNull)
					txtPrecioContractual.Text=oProyectosMMBE.PRECIOCONTRACTUAL.Value.ToString();
				

			}
		}

		public void CargarModoConsulta()
		{
			ckEliminarFoto.Visible = false;
			ckEliminarEspTecnica.Visible = false;
			ckEliminarContrato.Visible = false;
			ckEliminarPresupuesto.Visible = false;
			ckEliminarPlano.Visible = false;

			if (Page.Request.QueryString[KEYIDCLIENTE] == Utilitario.Constantes.IDCLIENTEMARINA.ToString())
				lblTermino.Text = Utilitario.Constantes.TEXTOSETIQUETAMARINA;

			CMantenimientos oCMantenimientos = new CMantenimientos();
			ProyectosMMBE oProyectosMMBE = (ProyectosMMBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.ProyectosMMNTAD.ToString());
			
			if(oProyectosMMBE!=null)
			{

				txtNombre.Text=oProyectosMMBE.NOMBREPROYECTO.ToString();
				txtIdProyecto.Text=oProyectosMMBE.IdHistorico.ToString();
				
				if (!oProyectosMMBE.IDCLIENTE.IsNull )
				{
					hIdCliente.Value = oProyectosMMBE.IDCLIENTE.ToString();
					CCliente oCCliente = new CCliente();
					txtRazonSocial.Text=  oCCliente.ObtenerNombreCliente(Convert.ToInt32(hIdCliente.Value));
				}
				else
					txtRazonSocial.Text = Utilitario.Constantes.TEXTOSINDATA;

				if (!oProyectosMMBE.SUBTIPO.IsNull )
					txtSubTipo.Text=oProyectosMMBE.SUBTIPO.ToString();
				else
					txtSubTipo.Text= Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.LOCALIDAD.IsNull)
					txtLocalidad.Text=oProyectosMMBE.LOCALIDAD.ToString();
				else
					txtLocalidad.Text= Utilitario.Constantes.TEXTOSINDATA;
				
				#region Ubigeo
				if(!oProyectosMMBE.IDUBIGEO.IsNull)
				{
					CUbigeo oCUbigeo = new CUbigeo();

					if(oProyectosMMBE.IDUBIGEO >= 700101)
					{
						HabilitarClienteExtranjero();
						rbtExtranjero.Checked = true;
						rbtPeruano.Checked = false;
					
						DataRow dr = oCUbigeo.ObtenerNombreUbigeo(Convert.ToInt32(oProyectosMMBE.IDUBIGEO));

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
					
						DataRow dr = oCUbigeo.ObtenerNombreUbigeo(Convert.ToInt32(oProyectosMMBE.IDUBIGEO));

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
	
				if(rbtExtranjero.Checked)
					CellRadio.InnerText = rbtExtranjero.Text;

				if(rbtPeruano.Checked)
					CellRadio.InnerText = rbtPeruano.Text;
				#endregion

				if(!oProyectosMMBE.LUZ.IsNull)
					txtLuz.Text=oProyectosMMBE.LUZ.ToString();
				else
					CelltxtLuz.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.TRAMOS.IsNull)
					txtTramos.Text=oProyectosMMBE.TRAMOS.ToString();
				else
					txtTramos.Text=Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.VIAS.IsNull)
					txtVias.Text=oProyectosMMBE.VIAS.ToString();
				else
					txtVias.Text=Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.ANCHO.IsNull)
					txtAncho.Text=oProyectosMMBE.ANCHO.ToString();
				else
					CelltxtAncho.InnerText = Utilitario.Constantes.TEXTOSINDATA;
				
				if(!oProyectosMMBE.ANCHORODADURA.IsNull)
					txtAnchoRodadura.Text=oProyectosMMBE.ANCHORODADURA.ToString();
				else
					CelltxtAnchoRodadura.InnerText = Utilitario.Constantes.TEXTOSINDATA;
				
				if(!oProyectosMMBE.SOBRECARGA.IsNull)
					txtSobreCarga.Text=oProyectosMMBE.SOBRECARGA.ToString();
				else
					txtSobreCarga.Text = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.ACCESOS.IsNull)
					txtAccesos.Text=oProyectosMMBE.ACCESOS.ToString();
				else
					txtAccesos.Text = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.CIMENTACIONSUPERFICIAL.IsNull)
					txtCimentacionSuperficial.Text=oProyectosMMBE.CIMENTACIONSUPERFICIAL.ToString();
				else
					txtCimentacionSuperficial.Text = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.CIMENTACIONPROFUNDA.IsNull)
					txtCimentacionProfunda.Text=oProyectosMMBE.CIMENTACIONPROFUNDA.ToString();
				else
					txtCimentacionProfunda.Text = Utilitario.Constantes.TEXTOSINDATA;
				
				if(!oProyectosMMBE.ESTRIBOS.IsNull)
					txtEstribos.Text=oProyectosMMBE.ESTRIBOS.ToString();
				else
					txtEstribos.Text = Utilitario.Constantes.TEXTOSINDATA;				
				
				if(!oProyectosMMBE.APOYOS.IsNull)
					txtApoyos.Text=oProyectosMMBE.APOYOS.ToString();
				else
					txtApoyos.Text = Utilitario.Constantes.TEXTOSINDATA;	

				if(!oProyectosMMBE.VIGAS.IsNull)
					txtVigas.Text=oProyectosMMBE.VIGAS.ToString();
				else
					txtVigas.Text = Utilitario.Constantes.TEXTOSINDATA;	

				if(!oProyectosMMBE.TIPOMATERIAL.IsNull)
					txtTipoMaterial.Text=oProyectosMMBE.TIPOMATERIAL.ToString();
				else
					txtTipoMaterial.Text = Utilitario.Constantes.TEXTOSINDATA;	

				if(!oProyectosMMBE.PERALTEVL.IsNull)
					txtPeralte.Text=oProyectosMMBE.PERALTEVL.ToString();
				else
					txtPeralte.Text = Utilitario.Constantes.TEXTOSINDATA;	

				if(!oProyectosMMBE.GALIBO.IsNull)
					txtGalibo.Text=oProyectosMMBE.GALIBO.ToString();
				else
					txtGalibo.Text = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.TIPORODADURA.IsNull)
					txtTipoRodadura.Text=oProyectosMMBE.TIPORODADURA.ToString();
				else
					txtTipoRodadura.Text = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.VEREDAS.IsNull)
					txtVeredas.Text=oProyectosMMBE.VEREDAS.ToString();
				else
					txtVeredas.Text = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.BARANDAS.IsNull)
					txtBarandas.Text=oProyectosMMBE.BARANDAS.ToString();
				else
					txtBarandas.Text = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.ESCALERAS.IsNull)
					txtEscaleras.Text=oProyectosMMBE.ESCALERAS.ToString();
				else
					txtEscaleras.Text = Utilitario.Constantes.TEXTOSINDATA;				
				
				if(!oProyectosMMBE.DESAGUES.IsNull)
					txtDesagues.Text=oProyectosMMBE.DESAGUES.ToString();
				else
					txtDesagues.Text = Utilitario.Constantes.TEXTOSINDATA;	
	
				if(!oProyectosMMBE.PESONETO.IsNull)
					txtPesoNeto.Text=oProyectosMMBE.PESONETO.ToString();
				else
					CelltxtPesoNeto.InnerText=Utilitario.Constantes.TEXTOSINDATA;
								
				if(!oProyectosMMBE.PESOBRUTO.IsNull)
					txtPesoBruto.Text=oProyectosMMBE.PESOBRUTO.ToString();
				else
					CelltxtPesoBruto.InnerText=Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.PILARES.IsNull)
					txtPilares.Text=oProyectosMMBE.PILARES.ToString();
				else
					txtPilares.Text = Utilitario.Constantes.TEXTOSINDATA;	

				if(!oProyectosMMBE.IDCENTROOPERATIVO.IsNull)
					ddlCentroOperativo.SelectedValue=oProyectosMMBE.IDCENTROOPERATIVO.ToString();
				else
					CellddlCentroOperativo.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.IDTIPOPRODUCTO.IsNull)
					ddlTipoBuque.SelectedValue=oProyectosMMBE.IDTIPOPRODUCTO.ToString();
				else
					CellddlTipoBuque.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.IDLINEAPRODUCTO.IsNull)
					ddlTipoProducto.SelectedValue=oProyectosMMBE.IDLINEAPRODUCTO.ToString();
				else
					CellddlTipoProducto.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.IDMATERIALES.IsNull)
					ddlMaterial.SelectedValue=oProyectosMMBE.IDMATERIALES.ToString();
				else
					CellddlMaterial.InnerText =Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.IDESTADOPROYECTO.IsNull)
					ddlEstadoProyecto.SelectedValue=oProyectosMMBE.IDESTADOPROYECTO.ToString();
				else
					CellddlEstadoProyecto.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.IDTIPODOCUMENTOOTROS.IsNull)
					ddlOtroTipoDocumento.SelectedValue=oProyectosMMBE.IDTIPODOCUMENTOOTROS.ToString();
				else
					CellddlOtroTipoDocumento.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.IDTIPODOCUMENTOPRINCIPAL.IsNull)
					ddlTipoDocumento.SelectedValue=oProyectosMMBE.IDTIPODOCUMENTOPRINCIPAL.ToString();
				else
					CellddlTipoDocumento.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.IDMONEDA.IsNull)
					ddlMoneda.SelectedValue=oProyectosMMBE.IDMONEDA.ToString();
				else
					CellddlMoneda.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.DOCUMENTOPRINCIPAL.IsNull)
					txtDocumentoPrincipal.Text=oProyectosMMBE.DOCUMENTOPRINCIPAL.ToString();
				else
					txtDocumentoPrincipal.Text = Utilitario.Constantes.TEXTOSINDATA;	

				if(!oProyectosMMBE.OTRODOCUMENTO.IsNull)
					txtOtroDocumento.Text=oProyectosMMBE.OTRODOCUMENTO.ToString();
				else
					txtOtroDocumento.Text = Utilitario.Constantes.TEXTOSINDATA;			
				

				
				if(!oProyectosMMBE.FUENTEINFORMACION.IsNull)
					txtFuenteInformacion.Text=oProyectosMMBE.FUENTEINFORMACION.ToString();
				else
					txtFuenteInformacion.Text = Utilitario.Constantes.TEXTOSINDATA;	
				
				if(!oProyectosMMBE.OBSERVACIONES.IsNull)
					txtObservaciones.Text=oProyectosMMBE.OBSERVACIONES.ToString();
				else
					txtObservaciones.Text = Utilitario.Constantes.TEXTOSINDATA;	

				if (!oProyectosMMBE.IDPERSONAL.IsNull)
				{
					hIdJefeProyecto.Value= oProyectosMMBE.IDPERSONAL.ToString();
					CPersonal oCPersonal = new CPersonal();
					txtJefeProyectos.Text = oCPersonal.ObtenerNombrePersonal(Convert.ToInt32(oProyectosMMBE.IDPERSONAL));
				}
				else
				{
					txtJefeProyectos.Text = Utilitario.Constantes.TEXTOSINDATA;	
				}

				if (!oProyectosMMBE.FECHAACUERDO.IsNull)
				{
					calFechaFirmaAcuerdo.Visible= false;	
					CellcalFechaFirmaAcuerdo.InnerText = oProyectosMMBE.FECHAACUERDO.Value.ToShortDateString();
				}
				else
					CellcalFechaFirmaAcuerdo.InnerText= Utilitario.Constantes.TEXTOSINDATA;	
					
				if (!oProyectosMMBE.INICIOCONTRACTUAL.IsNull)
				{
					calFechaInicioContractual.Visible= false;					
					CellcalFechaInicioContractual.InnerText = oProyectosMMBE.INICIOCONTRACTUAL.Value.ToShortDateString();
				}
				else
					CellcalFechaInicioContractual.InnerText = Utilitario.Constantes.TEXTOSINDATA;	

				if (!oProyectosMMBE.FINCONTRACTUAL.IsNull)
				{
					calFechaFinContractual.Visible= false;					
					CellcalFechaFinContractual.InnerText = oProyectosMMBE.FINCONTRACTUAL.Value.ToShortDateString();
				}
				else
					CellcalFechaFinContractual.InnerText = Utilitario.Constantes.TEXTOSINDATA;	

				if (!oProyectosMMBE.INICIOREAL.IsNull)
				{
					calFechaInicioReal.Visible= false;					
					CellcalFechaInicioReal.InnerText = oProyectosMMBE.INICIOREAL.Value.ToShortDateString();
				}
				else
					CellcalFechaInicioReal.InnerText = Utilitario.Constantes.TEXTOSINDATA;	

				if (!oProyectosMMBE.FINREAL.IsNull)
				{
					calFechaFinReal.Visible= false;					
					CellcalFechaFinReal.InnerText = oProyectosMMBE.FINREAL.Value.ToShortDateString();
				}
				else
					CellcalFechaFinReal.InnerText = Utilitario.Constantes.TEXTOSINDATA;	

				if (!oProyectosMMBE.ENTREGA.IsNull)
				{
					calFechaEntrega.Visible= false;					
					CellcalFechaEntrega.InnerText = oProyectosMMBE.ENTREGA.Value.ToShortDateString();
				}
				else
					CellcalFechaEntrega.InnerText = Utilitario.Constantes.TEXTOSINDATA;	
				
				
				if(!oProyectosMMBE.FINREAL.IsNull && !oProyectosMMBE.INICIOREAL.IsNull )
				{
					TimeSpan dias = Convert.ToDateTime(oProyectosMMBE.FINREAL) - Convert.ToDateTime(oProyectosMMBE.INICIOREAL);
					txtTEjecucion.Text =dias.Days.ToString();
				}
				else
					txtTEjecucion.Text = Utilitario.Constantes.TEXTOSINDATA;
				
				if (!oProyectosMMBE.PRESUPUESTO.IsNull )
				{
					rutaArchivoPresupuesto = RutaImagenServerProyecto +  "\\" +  oProyectosMMBE.PRESUPUESTO.ToString();
					hlkPresupuesto.Text = Convert.ToString( oProyectosMMBE.PRESUPUESTO);
					hlkPresupuesto.NavigateUrl = rutaArchivoPresupuesto;
				}
				else
					CellfPresupuesto.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if (!oProyectosMMBE.CONTRATO.IsNull)
				{
					rutaArchivoContrato = RutaImagenServerProyecto +  "\\" +  oProyectosMMBE.CONTRATO.ToString();
					hlkContrato.Text = Convert.ToString( oProyectosMMBE.CONTRATO);
					hlkContrato.NavigateUrl = rutaArchivoContrato;
				}
				else
					CellfContrato.InnerText = Utilitario.Constantes.TEXTOSINDATA;

			
				if (!oProyectosMMBE.ESPECIFICACIONTECNICA.IsNull )
				{
					rutaArchivoEspecificaciones = RutaImagenServerProyecto +  "\\" +  oProyectosMMBE.ESPECIFICACIONTECNICA.ToString();
					hlkEspecificacionTecnica.Text = Convert.ToString( oProyectosMMBE.ESPECIFICACIONTECNICA);
					hlkEspecificacionTecnica.NavigateUrl = rutaArchivoEspecificaciones;
				}
				else
					CellfEspecificaciones.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if (!oProyectosMMBE.PLANO.IsNull )
				{
					rutaArchivoPlano = RutaImagenServerProyecto +  "\\" +  oProyectosMMBE.PLANO.ToString();
					hlkContrato.Text = Convert.ToString( oProyectosMMBE.PLANO);
					hlkContrato.NavigateUrl = rutaArchivoPlano;
				}
				else
					CellfPlano.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if (!oProyectosMMBE.Imagen.IsNull )
				{
					hFoto.Value =Convert.ToString(oProyectosMMBE.Imagen);
					string RutaImagen=RutaImagenServerProyecto + oProyectosMMBE.Imagen.Value;
					imgProyecto.ImageUrl = RutaImagen;
					hFoto.Value = oProyectosMMBE.Imagen.Value;
				}
				else
				{
					imgProyecto.ImageUrl= RutaImagenServerProyecto + "sinfoto.jpg";
				}

				if(!oProyectosMMBE.PRECIOCONTRACTUAL.IsNull)
					CelltxtPrecioContractual.InnerText=oProyectosMMBE.PRECIOCONTRACTUAL.Value.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				else
					CelltxtPrecioContractual.InnerText=Utilitario.Constantes.TEXTOSINDATA;
								
				if(!oProyectosMMBE.PRECIOREAL.IsNull)
					CelltxtPrecioReal.InnerText=oProyectosMMBE.PRECIOREAL.Value.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				else
					CelltxtPrecioReal.InnerText=Utilitario.Constantes.TEXTOSINDATA;

				this.fFoto.Visible = Utilitario.Constantes.VALORUNCHECKEDBOOL;
				ibtnAceptar.Visible=false;
				ibtnCancelar.Visible=false;
				Helper.BloquearControles(this);

				tblAtras.Visible = true;
			}
		}

		public bool ValidarCampos()
		{
			if(txtNombre.Text==String.Empty)	
			{
				ltlMensaje.Text=Helper.MensajeAlert("Ingrese el nombre del proyecto");
				return false;
			}
			if(txtIdProyecto.Text==String.Empty)	
			{
				ltlMensaje.Text=Helper.MensajeAlert("Ingrese el ID del proyecto");
				return false;
			}
			if(this.ddlCentroOperativo.SelectedValue == Utilitario.Constantes.VALORSELECCIONAR)
			{
				ltlMensaje.Text=Helper.MensajeAlert("Seleccione un centro operativo");
				return false;
			}

			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleConsultarRegistroProyectoMM.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleConsultarRegistroProyectoMM.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

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
				TimeSpan dias = Convert.ToDateTime(calFechaFinReal.SelectedDate) - Convert.ToDateTime(calFechaInicioReal.SelectedDate);
				txtTEjecucion.Text =dias.Days.ToString();
			}
		}

		private void calFechaFinReal_DateChanged(object sender, System.EventArgs e)
		{
			if(calFechaFinReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO
				&& calFechaInicioReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
			{
				TimeSpan dias = Convert.ToDateTime(calFechaFinReal.SelectedDate) - Convert.ToDateTime(calFechaInicioReal.SelectedDate);
				txtTEjecucion.Text =dias.Days.ToString();
			}
		}
	}
}
