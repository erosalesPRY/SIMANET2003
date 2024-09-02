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
using SIMA.EntidadesNegocio.GestionEstrategica;
//using SIMA.LogicaNegocio.GerenciaEstrategica;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial.InventarioPC
{
	/// <summary>
	/// Summary description for DetalleInventarioPC.
	/// </summary>
	public class DetalleInventarioPC : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		//DataTable dtSoftware;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdJefeProyecto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdResponsable;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregarHardware;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregarSoftware;
		protected System.Web.UI.WebControls.DropDownList ddlLicencia;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.DropDownList ddlModelo;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.DropDownList ddlMarca;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DropDownList ddlDisco;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DropDownList ddlTipo;
		protected System.Web.UI.WebControls.TextBox txtCO;
		protected System.Web.UI.WebControls.TextBox txtArea;
		protected System.Web.UI.WebControls.DropDownList ddlProcesador;
		protected System.Web.UI.WebControls.Label lblDatosGenerales;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD2;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD21;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD22;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD25;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD26;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdAceptar;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdProcesador;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdAreaContenido;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdCOContenido;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdTipo;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdMemoria;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdDisco;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdMarca;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdModelo;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator8;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator9;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator10;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator11;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator12;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdAreaEtiqueta;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdCOEtiqueta;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregarProcesador;
		protected System.Web.UI.WebControls.ImageButton ibtnTipoPC;
		protected System.Web.UI.WebControls.ImageButton ibtnDisco;
		protected System.Web.UI.WebControls.ImageButton ibtnMarcaCPU;
		protected System.Web.UI.WebControls.ImageButton ibtnModeloCPU;
		protected System.Web.UI.WebControls.ImageButton ibtnLicencia;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnDestinatario;
		protected System.Web.UI.WebControls.ImageButton ibtnVerDetallePersonal;
		protected System.Web.UI.WebControls.TextBox txtJefeProyectos;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdArea;
		protected System.Web.UI.WebControls.Label lblResultado2;
		protected projDataGridWeb.DataGridWeb grid2;
		protected System.Web.UI.WebControls.Label lblResultado1;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.TextBox txtNada;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD1;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD3;
		protected System.Web.UI.WebControls.DropDownList ddlMemoria;
		protected System.Web.UI.WebControls.ImageButton ibtnMemoria;
		protected System.Web.UI.WebControls.ImageButton ibtnNuevoSoftware;
		protected System.Web.UI.WebControls.ImageButton ibtnNuevoHardware;
		protected System.Web.UI.WebControls.DropDownList ddlSoftware;
		protected System.Web.UI.WebControls.DropDownList ddlHardware;
		protected System.Web.UI.WebControls.CheckBox chkNoContratado;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		//DataTable dtHardware;
		#endregion

		#region Constantes

		//Titulos
		const string TITULOMODONUEVO = "NUEVO CLIENTE";
		const string TITULOMODOMODIFICAR = "CLIENTE";
		const string TITULOMODOCONSULTA = "DETALLES DEL CLIENTE";

		//Key Session y QueryString

		const string KEYIDINVENTARIOPC= "IdInventarioPC";
		const string FLAG = "Flag";
		const string COMBOPROCESADOR = "ddlProcesador";
		const string COMBOTIPO = "ddlTipo";
		const string COMBOMEMORIA = "ibtnMemoria";
		const string COMBODISCO = "ibtnDisco";
		const string COMBOMARCACPU = "ibtnMarcaCPU";
		const string COMBOMODELOCPU = "ibtnModeloCPU";
		const string BOTONLICENCIA = "ibtnLicencia";
		const string TXTRESPONSABLE = "txtJefeProyectos";
		const string TXTDESCRIPCION = "txtDescripcion";
		const string TXTNOMBRESOFTWARE = "txtNombreSoftware";
		const string TXTNOMBREHARDWARE = "txtNombreHardware";
		const string COMBOSOFTWARE = "ddlSoftware";
		const string COMBOLICENCIA = "ddlLicencia";
		const string COMBOHARDWARE = "ddlHardware";

		const string CLASSKEY = "class";
		const string CLASSVALUE = "normaldetalle";

		//Paginas
		const string URLADMINISTRACION = "AdministrarInventarioPC.aspx";
		const string URLDETALLEPERSONAL = "PopupDetallePersonal.aspx?";
		const string URLPARAMETROS = "../../GestionControlInstitucional/AdministrarOrganismoAccionSubAccion.aspx?";

		const string GRILLAVACIA ="No existe ningun valor.";
		const string URLBUSQUEDAENTIDAD = "../../Legal/BusquedaEntidad.aspx?";
		const string KEYQTIPOCONSULTA="TipoConsulta";

		const string INDICEPAGINA = "hGridPagina";
		const string PAGINASORT = "hGridPaginaSort";
		const string NOMBRETABLASOFTWARE = "software";
		protected System.Web.UI.HtmlControls.HtmlTable Table1;
		const string NOMBRETABLAHARDWARE = "hardware";

		//ListItem item;

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					if(ViewState[NOMBRETABLASOFTWARE] == null)
					{
						ViewState[NOMBRETABLASOFTWARE] = crearTablaSoftware();
					}

					if(ViewState[NOMBRETABLAHARDWARE] == null)
					{
						ViewState[NOMBRETABLAHARDWARE] = crearTablaHardware();
					}

					this.LlenarJScript();
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					Helper.ReestablecerPagina(this);
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
			this.ibtnAgregarProcesador.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregarProcesador_Click);
			this.ibtnVerDetallePersonal.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnVerDetallePersonal_Click);
			this.chkNoContratado.CheckedChanged += new System.EventHandler(this.chkNoContratado_CheckedChanged);
			this.ibtnTipoPC.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnTipoPC_Click);
			this.ibtnMemoria.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnMemoria_Click);
			this.ibtnDisco.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnDisco_Click);
			this.ibtnMarcaCPU.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnMarcaCPU_Click);
			this.ibtnModeloCPU.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnModeloCPU_Click);
			this.ibtnNuevoSoftware.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnNuevoSoftware_Click);
			this.ibtnNuevoHardware.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnNuevoHardware_Click);
			this.ibtnLicencia.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnLicencia_Click);
			this.ibtnAgregarSoftware.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregarSoftware_Click);
			this.ibtnAgregarHardware.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregarHardware_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound_1);
			this.grid2.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid2_ItemDataBound_1);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleInventarioPC.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleInventarioPC.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleInventarioPC.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleInventarioPC.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleInventarioPC.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnVerDetallePersonal.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,Helper.MostrarVentana(URLDETALLEPERSONAL,Enumerados.ColumnasInventarioPC.IDPERSONAL + 
				Utilitario.Constantes.SIGNOIGUAL + this.hIdResponsable.Value + Utilitario.Constantes.SIGNOAMPERSON + "IDCO=0&IDGO=0"));

			this.ibtnDestinatario.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAENTIDAD + Utilitario.Constantes.KEYTIPOBUSQUEDAENTIDAD +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.TipoBusquedaEntidad.PER.ToString(),750,500,true));

			this.ibtnAgregarProcesador.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnAgregarProcesador.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA,PAGINASORT, 
				COMBODISCO, COMBOLICENCIA, COMBOMARCACPU, COMBOMEMORIA, COMBOMODELOCPU, COMBOLICENCIA, COMBOSOFTWARE, COMBOHARDWARE,
				COMBOPROCESADOR, COMBOTIPO, TXTDESCRIPCION, TXTRESPONSABLE));

			this.ibtnTipoPC.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnTipoPC.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA,PAGINASORT, 
				COMBODISCO, COMBOLICENCIA, COMBOMARCACPU, COMBOMEMORIA, COMBOMODELOCPU, COMBOLICENCIA, COMBOSOFTWARE, COMBOHARDWARE,
				COMBOPROCESADOR, COMBOTIPO, TXTDESCRIPCION, TXTRESPONSABLE));

			this.ibtnMemoria.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnMemoria.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA,PAGINASORT, 
				COMBODISCO, COMBOLICENCIA, COMBOMARCACPU, COMBOMEMORIA, COMBOMODELOCPU, COMBOLICENCIA, COMBOSOFTWARE, COMBOHARDWARE,
				COMBOPROCESADOR, COMBOTIPO, TXTDESCRIPCION, TXTRESPONSABLE));

			this.ibtnDisco.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnDisco.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA,PAGINASORT, 
				COMBODISCO, COMBOLICENCIA, COMBOMARCACPU, COMBOMEMORIA, COMBOMODELOCPU, COMBOLICENCIA, COMBOSOFTWARE, COMBOHARDWARE,
				COMBOPROCESADOR, COMBOTIPO, TXTDESCRIPCION, TXTRESPONSABLE));

			this.ibtnMarcaCPU.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnMarcaCPU.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA,PAGINASORT, 
				COMBODISCO, COMBOLICENCIA, COMBOMARCACPU, COMBOMEMORIA, COMBOMODELOCPU, COMBOLICENCIA, COMBOSOFTWARE, COMBOHARDWARE,
				COMBOPROCESADOR, COMBOTIPO, TXTDESCRIPCION, TXTRESPONSABLE));

			this.ibtnModeloCPU.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnModeloCPU.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA,PAGINASORT, 
				COMBODISCO, COMBOLICENCIA, COMBOMARCACPU, COMBOMEMORIA, COMBOMODELOCPU, COMBOLICENCIA, COMBOSOFTWARE, COMBOHARDWARE,
				COMBOPROCESADOR, COMBOTIPO, TXTDESCRIPCION, TXTRESPONSABLE));

			this.ibtnLicencia.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnLicencia.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA,PAGINASORT, 
				COMBODISCO, COMBOLICENCIA, COMBOMARCACPU, COMBOMEMORIA, COMBOMODELOCPU, COMBOLICENCIA, COMBOSOFTWARE, COMBOHARDWARE,
				COMBOPROCESADOR, COMBOTIPO, TXTDESCRIPCION, TXTRESPONSABLE));

			this.ibtnNuevoSoftware.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnNuevoSoftware.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA,PAGINASORT, 
				COMBODISCO, COMBOLICENCIA, COMBOMARCACPU, COMBOMEMORIA, COMBOMODELOCPU, COMBOLICENCIA, COMBOSOFTWARE, COMBOHARDWARE,
				COMBOPROCESADOR, COMBOTIPO, TXTDESCRIPCION, TXTRESPONSABLE));

			this.ibtnNuevoHardware.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnNuevoHardware.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA,PAGINASORT, 
				COMBODISCO, COMBOLICENCIA, COMBOMARCACPU, COMBOMEMORIA, COMBOMODELOCPU, COMBOLICENCIA, COMBOSOFTWARE, COMBOHARDWARE,
				COMBOPROCESADOR, COMBOTIPO, TXTDESCRIPCION, TXTRESPONSABLE));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleInventarioPC.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleInventarioPC.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleInventarioPC.Exportar implementation
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
			// TODO:  Add DetalleInventarioPC.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region Tablas
		public DataTable crearTablaSoftware()
		{
			DataTable dt = new DataTable();
			dt.TableName = NOMBRETABLASOFTWARE;
			DataColumn cl = new DataColumn();

			cl = new DataColumn(Enumerados.ColumnasSoftwarePC.NOMBRESW.ToString());
			cl.DataType = System.Type.GetType("System.String");
			dt.Columns.Add(cl);

			cl = new DataColumn(Enumerados.ColumnasSoftwarePC.LICENCIA.ToString());
			cl.DataType = System.Type.GetType("System.String");
			dt.Columns.Add(cl);

			cl = new DataColumn(Enumerados.ColumnasSoftwarePC.IDTABLALICENCIA.ToString());
			cl.DataType = System.Type.GetType("System.Int32");
			dt.Columns.Add(cl);

			cl = new DataColumn(Enumerados.ColumnasSoftwarePC.IDLICENCIA.ToString());
			cl.DataType = System.Type.GetType("System.Int32");
			dt.Columns.Add(cl);

			cl = new DataColumn(Enumerados.ColumnasSoftwarePC.FLAG.ToString());
			cl.DataType = System.Type.GetType("System.Int32");
			dt.Columns.Add(cl);

			return dt;
		}


		public DataTable crearTablaHardware()
		{
			DataTable dt = new DataTable();
			dt.TableName = NOMBRETABLAHARDWARE;
			DataColumn cl = new DataColumn();

			cl = new DataColumn(Enumerados.ColumnasHardwarePC.NOMBREHW.ToString());
			cl.DataType = System.Type.GetType("System.String");
			dt.Columns.Add(cl);

			cl = new DataColumn(Enumerados.ColumnasHardwarePC.FLAG.ToString());
			cl.DataType = System.Type.GetType("System.Int32");
			dt.Columns.Add(cl);

			return dt;
		}
		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			InventarioPcBE oInventarioPcBE = new InventarioPcBE();
			oInventarioPcBE.IDTABLAPROCESADOR = Convert.ToInt32(Enumerados.TablasTabla.TipoProcesador);
			oInventarioPcBE.IDPROCESADOR = Convert.ToInt32(ddlProcesador.SelectedValue);
			oInventarioPcBE.IDTABLAMEMORIA = Convert.ToInt32(Enumerados.TablasTabla.TipoMemoria);
			oInventarioPcBE.IDMEMORIA = Convert.ToInt32(ddlMemoria.SelectedValue);
			oInventarioPcBE.IDTABLADISCO = Convert.ToInt32(Enumerados.TablasTabla.TamañoDisco);
			oInventarioPcBE.IDDISCO = Convert.ToInt32(ddlDisco.SelectedValue);
			oInventarioPcBE.IDTABLAMARCACPU = Convert.ToInt32(Enumerados.TablasTabla.MarcaCPU);
			oInventarioPcBE.IDMARCACPU = Convert.ToInt32(ddlMarca.SelectedValue);
			oInventarioPcBE.IDTABLAMODELO = NullableTypes.NullableInt32.Parse(Enumerados.TablasTabla.ModeloCPU);
			oInventarioPcBE.IDMODELO = Convert.ToInt32(ddlModelo.SelectedValue);
			oInventarioPcBE.IDTABLATIPO = Convert.ToInt32(Enumerados.TablasTabla.TablaTiposPC);
			oInventarioPcBE.IDTIPO = Convert.ToInt32(ddlTipo.SelectedValue);
			oInventarioPcBE.IDUSUARIOREGISTRO = CNetAccessControl.GetIdUser();
			oInventarioPcBE.IDTABLAESTADO = Convert.ToInt32(Enumerados.TablasTabla.TablaEstadosInventarioPC);
			oInventarioPcBE.IDESTADO = Constantes.ValorConstanteUno;
			oInventarioPcBE.DESCRIPCION = txtDescripcion.Text;

			if(chkNoContratado.Checked == true)
			{
				oInventarioPcBE.RESPONSABLE = txtJefeProyectos.Text;
				oInventarioPcBE.IDPERSONAL = Convert.ToInt32(hIdJefeProyecto.Value.ToString());
			}
			else
			{
				oInventarioPcBE.IDPERSONAL = Convert.ToInt32(hIdJefeProyecto.Value.ToString());
				oInventarioPcBE.RESPONSABLE = string.Empty;
			}

			//InventarioLN oInventarioLN = new InventarioLN();
			//int resultado = oInventarioLN.RegistroInventarioPC(oInventarioPcBE, (DataTable)ViewState["software"], (DataTable)ViewState["hardware"]);

			int resultado = (new CInventario()).RegistroInventarioPC(oInventarioPcBE, (DataTable)ViewState["software"], (DataTable)ViewState["hardware"]);
			
			if(resultado > 0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Estrategica",this.ToString(),"Se registro la PC Nro. " + Page.Request.QueryString[KEYIDINVENTARIOPC] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert("Se registro la PC", URLADMINISTRACION);
			}
			else
			{
				ltlMensaje.Text = Helper.MensajeRetornoAlert("Se registro la PC");
			}
		}

		public void Modificar()
		{
			InventarioPcBE oInventarioPcBE = new InventarioPcBE();
			oInventarioPcBE.IDINVENTARIOPC = Convert.ToInt32(Page.Request.QueryString[KEYIDINVENTARIOPC]);
			oInventarioPcBE.IDTABLAPROCESADOR = Convert.ToInt32(Enumerados.TablasTabla.TipoProcesador);
			oInventarioPcBE.IDPROCESADOR = Convert.ToInt32(ddlProcesador.SelectedValue);
			oInventarioPcBE.IDPERSONAL = Convert.ToInt32(hIdJefeProyecto.Value.ToString());
			oInventarioPcBE.IDTABLAMEMORIA = Convert.ToInt32(Enumerados.TablasTabla.TipoMemoria);
			oInventarioPcBE.IDMEMORIA = Convert.ToInt32(ddlMemoria.SelectedValue);
			oInventarioPcBE.IDTABLADISCO = Convert.ToInt32(Enumerados.TablasTabla.TamañoDisco);
			oInventarioPcBE.IDDISCO = Convert.ToInt32(ddlDisco.SelectedValue);
			oInventarioPcBE.IDTABLAMARCACPU = Convert.ToInt32(Enumerados.TablasTabla.MarcaCPU);
			oInventarioPcBE.IDMARCACPU = Convert.ToInt32(ddlMarca.SelectedValue);
			oInventarioPcBE.IDTABLAMODELO = NullableTypes.NullableInt32.Parse(Enumerados.TablasTabla.ModeloCPU);
			oInventarioPcBE.IDMODELO = Convert.ToInt32(ddlModelo.SelectedValue);
			oInventarioPcBE.IDTABLATIPO = Convert.ToInt32(Enumerados.TablasTabla.TablaTiposPC);
			oInventarioPcBE.IDTIPO = Convert.ToInt32(ddlTipo.SelectedValue);
			oInventarioPcBE.IDUSUARIOREGISTRO = CNetAccessControl.GetIdUser();
			oInventarioPcBE.DESCRIPCION = txtDescripcion.Text;
			oInventarioPcBE.RESPONSABLE = txtJefeProyectos.Text;

			//InventarioLN oInventarioLN = new InventarioLN();
			//int resultado = oInventarioLN.ModificarInventarioPC(oInventarioPcBE, (DataTable)ViewState[NOMBRETABLASOFTWARE], (DataTable)ViewState[NOMBRETABLAHARDWARE]);
			int resultado = (new CInventario()).ModificarInventarioPC(oInventarioPcBE, (DataTable)ViewState[NOMBRETABLASOFTWARE], (DataTable)ViewState[NOMBRETABLAHARDWARE]);

			if(resultado > 0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Estrategica",this.ToString(),"Se modificó la PC Nro. " + Page.Request.QueryString[KEYIDINVENTARIOPC] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert("Se modifico la PC");
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleInventarioPC.Eliminar implementation
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
			try
			{
				txtJefeProyectos.Width = Unit.Pixel(409);
				
				tdAreaContenido.ColSpan = 0;
				tdAreaEtiqueta.ColSpan = 0;
				tdCOContenido.ColSpan = 0;
				tdCOEtiqueta.ColSpan = 0;

				tdAreaContenido.RowSpan = 0;
				tdAreaEtiqueta.RowSpan = 0;
				tdCOContenido.RowSpan = 0;
				tdCOEtiqueta.RowSpan = 0;

				tdAreaContenido.Visible = false;
				tdAreaEtiqueta.Visible = false;
				tdCOContenido.Visible = false;
				tdCOEtiqueta.Visible = false;

				ibtnDestinatario.Visible = true;
				this.LlenarCombosConsulta();
				ibtnAtras.Visible = false;
			}
			catch(Exception ex)
			{
				string a = ex.Message;
			}

			// TODO:  Add DetalleInventarioPC.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			try
			{
				txtJefeProyectos.Width = Unit.Pixel(409);
				ibtnDestinatario.Visible = true;
				ibtnAtras.Visible = false;
				lblTitulo.Text="MODIFICAR DATOS DE LA PC";
				this.LlenarCombosConsulta();
			
				CInventarioPC oCInventarioPC = new CInventarioPC();
				InventarioPcBE oInventarioPcBE = (InventarioPcBE)oCInventarioPC.VerDetalleInventarioPC(Convert.ToInt32(Page.Request.QueryString[KEYIDINVENTARIOPC]));

				if(oInventarioPcBE != null)
				{
					ddlProcesador.SelectedValue = oInventarioPcBE.IDPROCESADOR.ToString();

					txtArea.Text = oInventarioPcBE.AREA.ToString();
					txtCO.Text = oInventarioPcBE.CO.ToString();
					txtDescripcion.Text = oInventarioPcBE.DESCRIPCION.ToString();
					ddlMemoria.SelectedValue = oInventarioPcBE.IDMEMORIA.ToString();

					ddlDisco.SelectedValue = oInventarioPcBE.IDDISCO.ToString();

					ddlMarca.SelectedValue = oInventarioPcBE.IDMARCACPU.ToString();

					txtJefeProyectos.Text = oInventarioPcBE.RESPONSABLE.ToString();
					this.hIdJefeProyecto.Value = oInventarioPcBE.IDPERSONAL.ToString();				

					if(oInventarioPcBE.IDPERSONAL == Constantes.ValorConstanteCero)
					{
						chkNoContratado.Checked = true;
						ibtnVerDetallePersonal.Visible = false;
						txtJefeProyectos.ReadOnly = false;
						ibtnDestinatario.Visible = false;					
					}
					else
					{
						chkNoContratado.Checked = false;
						ibtnVerDetallePersonal.Visible = false;
						txtJefeProyectos.ReadOnly = true;
						ibtnDestinatario.Visible = true;
					}


					if(oInventarioPcBE.IDMODELO!=null)
						ddlModelo.SelectedValue = oInventarioPcBE.IDMODELO.ToString();

					ddlTipo.SelectedValue = oInventarioPcBE.IDTIPO.ToString();
					this.LlenarCaracteristicas(Convert.ToInt32(oInventarioPcBE.IDINVENTARIOPC.ToString()));
				}

				grid.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				grid.DataBind();
			}
		}

		public void CargarModoConsulta()
		{
			RequiredFieldValidator1.Visible = false;
			RequiredFieldValidator10.Visible = false;
			RequiredFieldValidator11.Visible = false;
			RequiredFieldValidator12.Visible = false;
			RequiredFieldValidator2.Visible = false;
			RequiredFieldValidator5.Visible = false;
			RequiredFieldValidator8.Visible = false;
			RequiredFieldValidator9.Visible = false;
			Table1.Visible=false;
			
			try
			{
				ibtnVerDetallePersonal.Visible = true;
				tdAceptar.Visible = false;
				lblTitulo.Text="DETALLE DE LA PC";
				this.LlenarCombosConsulta();

				CInventarioPC oCInventarioPC = new CInventarioPC();
				InventarioPcBE oInventarioPcBE = (InventarioPcBE)oCInventarioPC.VerDetalleInventarioPC(Convert.ToInt32(Page.Request.QueryString[KEYIDINVENTARIOPC]));

				if(oInventarioPcBE != null)
				{
					this.hIdResponsable.Value = oInventarioPcBE.IDPERSONAL.ToString();				
					ddlProcesador.SelectedValue = oInventarioPcBE.IDPROCESADOR.ToString();
					tdProcesador.InnerText = ddlProcesador.SelectedItem.Text;

					if(Convert.ToInt32(hIdResponsable.Value) == Constantes.ValorConstanteCero)
					{
						txtJefeProyectos.Text = oInventarioPcBE.RESPONSABLESINCONTRATO.ToString();
					}
					else
					{
						txtJefeProyectos.Text = oInventarioPcBE.RESPONSABLE.ToString();
					}

					txtArea.Text = oInventarioPcBE.AREA.ToString();
					txtCO.Text = oInventarioPcBE.CO.ToString();
					txtDescripcion.Text = oInventarioPcBE.DESCRIPCION.ToString();
					ddlMemoria.SelectedValue = oInventarioPcBE.IDMEMORIA.ToString();
					tdMemoria.InnerText = ddlMemoria.SelectedItem.Text;
					tdMemoria.Style.Add(CLASSKEY, CLASSVALUE);

					ddlDisco.SelectedValue = oInventarioPcBE.IDDISCO.ToString();
					tdDisco.InnerText = ddlDisco.SelectedItem.Text;

					ddlMarca.SelectedValue = oInventarioPcBE.IDMARCACPU.ToString();
					tdMarca.InnerText = ddlMarca.SelectedItem.Text;
					
					if(oInventarioPcBE.IDMODELO!=null)
						ddlModelo.SelectedValue = oInventarioPcBE.IDMODELO.ToString();
					tdModelo.InnerText = ddlModelo.SelectedItem.Text;

					ddlTipo.SelectedValue = oInventarioPcBE.IDTIPO.ToString();
					tdTipo.InnerText = ddlTipo.SelectedItem.Text;
					this.LlenarCaracteristicas(Convert.ToInt32(oInventarioPcBE.IDINVENTARIOPC.ToString()));
					
					Helper.BloquearControles(this);
					
					chkNoContratado.Visible = false;
					ddlProcesador.Visible=false;
					txtJefeProyectos.ReadOnly=true;
					txtArea.ReadOnly=true;
					txtCO.ReadOnly=true;
					txtDescripcion.ReadOnly=true;
					ddlMemoria.Visible=false;
					ddlDisco.Visible=false;
					ddlMarca.Visible=false;
					ddlModelo.Visible=false;
					ddlTipo.Visible=false;					
					this.ibtnVerDetallePersonal.Visible=true;			
				}

				grid.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				grid.DataBind();
			}
		}

		public bool ValidarCampos()
		{
			if(this.ValidarCamposRequeridos())
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.txtJefeProyectos.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert("Debe seleccionar un responsable");
				return false;
			}
			if(this.txtDescripcion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert("Debe ingresar una descripcion");
				return false;
			}
			if(this.ddlProcesador.SelectedItem.Text==Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert("Debe seleccionar el tipo de procesador");
				return false;
			}
			if(this.ddlMemoria.SelectedItem.Text==Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert("Debe seleccionar la cantidad de memoria");
				return false;
			}
			if(this.ddlDisco.SelectedItem.Text==Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert("Debe seleccionar el tamaño del disco");
				return false;
			}
			if(this.ddlMarca.SelectedItem.Text==Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert("Debe seleccionar la marca");
				return false;
			}
			if(this.ddlModelo.SelectedItem.Text==Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert("Debe seleccionar el modelo");
				return false;
			}
			if(this.ddlTipo.SelectedItem.Text==Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert("Debe seleccionar el tipo");
				return false;
			}
			return true;
		}

		public bool ValidarSoftware()
		{
			if(this.ddlSoftware.SelectedItem.Text==Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert("Debe Ingresar un software");
				return false;
			}

			if(this.ddlLicencia.SelectedItem.Text==Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert("Debe seleccionar una licencia");
				return false;
			}

			return true;
		}
        
		public bool ValidarHardware()
		{
			if(this.ddlHardware.SelectedItem.Text==Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert("Debe Ingresar hardware");
				return false;
			}

			return true;
		}
		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleInventarioPC.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	
		#region Combos
		public void LlenarCombosConsulta()
		{
			ListItem lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			
			this.LlenarProcesador();
			this.LlenarMemoria();
			this.LlenarDisco();
			this.LlenarMarca();
			this.LlenarModelo();
			this.LlenarTipo();
			this.LlenarLicencia();
			this.LlenarComboSoftware();
			this.LlenarComboHardware();

			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.ddlProcesador.Items.Insert(Constantes.ValorConstanteCero,lItem);
					this.ddlMemoria.Items.Insert(Constantes.ValorConstanteCero,lItem);
					this.ddlDisco.Items.Insert(Constantes.ValorConstanteCero,lItem);
					this.ddlMarca.Items.Insert(Constantes.ValorConstanteCero,lItem);
					this.ddlModelo.Items.Insert(Constantes.ValorConstanteCero,lItem);
					this.ddlTipo.Items.Insert(Constantes.ValorConstanteCero,lItem);
					this.ddlLicencia.Items.Insert(Constantes.ValorConstanteCero,lItem);
					this.ddlHardware.Items.Insert(Constantes.ValorConstanteCero,lItem);
					this.ddlSoftware.Items.Insert(Constantes.ValorConstanteCero,lItem);
					break;
			}		
		}

		public void LlenarLicencia()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlLicencia.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TablaEstadosLicenciaSoftware));
			ddlLicencia.DataValueField =  Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlLicencia.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlLicencia.DataBind();
		}

		public void LlenarProcesador()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlProcesador.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TipoProcesador));
			ddlProcesador.DataValueField =  Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlProcesador.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlProcesador.DataBind();
		}
		
		public void LlenarMemoria()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlMemoria.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TipoMemoria));
			ddlMemoria.DataValueField =  Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlMemoria.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlMemoria.DataBind();
		}
		
		public void LlenarDisco()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlDisco.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TamañoDisco));
			ddlDisco.DataValueField =  Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlDisco.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlDisco.DataBind();
		}
		
		public void LlenarMarca()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlMarca.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.MarcaCPU));
			ddlMarca.DataValueField =  Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlMarca.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlMarca.DataBind();
		}
				
		public void LlenarModelo()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlModelo.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.ModeloCPU));
			ddlModelo.DataValueField =  Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlModelo.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlModelo.DataBind();
		}
				
		public void LlenarTipo()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlTipo.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TablaTiposPC));
			ddlTipo.DataValueField =  Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlTipo.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlTipo.DataBind();
		}

		public void LlenarComboSoftware()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlSoftware.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TablaSoftware));
			ddlSoftware.DataValueField =  Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlSoftware.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlSoftware.DataBind();
		}

		public void LlenarComboHardware()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlHardware.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TablaHardware));
			ddlHardware.DataValueField =  Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlHardware.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlHardware.DataBind();
		}

		#endregion

		#region Grillas
		public void LlenarCaracteristicas(int idInventario)
		{
			this.llenarSoftware(idInventario);
			this.llenarHardware(idInventario);
		}
		public void llenarSoftware(int idInventario)
		{
			CInventarioPC oCInventarioPC = new CInventarioPC();
			DataTable dtSoftware = oCInventarioPC.ListarSoftwarePC(idInventario);

			if(dtSoftware!=null)
			{
				if(Page.Request.QueryString[Constantes.KEYMODOPAGINA].ToString() == "M")
				{
					ViewState[NOMBRETABLASOFTWARE] = dtSoftware;
				}

				DataView dwSoftware = dtSoftware.DefaultView;
				//dwSoftware.Sort = columnaOrdenar ;
				dwSoftware.RowFilter = Utilitario.Helper.ObtenerFiltro();//Helper.ObtenerFiltro(this);
				if(dwSoftware.Count>0)
				{
					grid.DataSource = dwSoftware;
					grid.Columns[1].FooterText = dwSoftware.Count.ToString();
					this.lblResultado1.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado1.Visible = true;
					lblResultado1.Text = GRILLAVACIA;
				}
				
			}
			else
			{
				grid.DataSource = dtSoftware;
				lblResultado1.Text = GRILLAVACIA;
			}
			
			try
			{
				//grid.CurrentPageIndex=indicePagina;
				grid.DataBind();
			}
			catch(Exception oException)
			{
				string error = oException.Message.ToString();
				grid.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				grid.DataBind();
			}
		}

		public void llenarHardware(int idInventario)
		{
			CInventarioPC oCInventarioPC = new CInventarioPC();
			DataTable dtHardware = oCInventarioPC.ListarHardwarePC(idInventario);

			if(dtHardware!=null)
			{
				if(Page.Request.QueryString[Constantes.KEYMODOPAGINA].ToString() == "M")
				{
					ViewState[NOMBRETABLAHARDWARE] = dtHardware;
				}

				DataView dwHardware = dtHardware.DefaultView;
				//dwHardware.Sort = columnaOrdenar ;
				dwHardware.RowFilter = Utilitario.Helper.ObtenerFiltro();//Helper.ObtenerFiltro(this);
				if(dwHardware.Count>0)
				{
					grid2.DataSource = dwHardware;
					grid2.Columns[1].FooterText = dwHardware.Count.ToString();
					this.lblResultado2.Visible = false;
				}
				else
				{
					grid2.DataSource = null;
					lblResultado2.Visible = true;
					lblResultado2.Text = GRILLAVACIA;
				}
				
			}
			else
			{
				grid2.DataSource = dtHardware;
				lblResultado2.Text = GRILLAVACIA;
			}
			
			try
			{
				//grid2.CurrentPageIndex=indicePagina;
				grid2.DataBind();
			}
			catch(Exception oException)
			{
				string error = oException.Message.ToString();
				grid2.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				grid2.DataBind();
			}
		}
        		
		#endregion
		
		private void ibtnVerDetallePersonal_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string cadena = Enumerados.ColumnasInventarioPC.IDPERSONAL + 
					Utilitario.Constantes.SIGNOIGUAL + this.hIdResponsable.Value;

			ltlMensaje.Text = Helper.PopupDialogoModal(URLDETALLEPERSONAL+cadena,770,480,true);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
	
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
			}
		}

		private void grid2_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
	
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
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

		private void ibtnAgregarSoftware_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(ValidarSoftware())
			{
				CargarGridSoftware(1);
			}
		}

		public void CargarGridSoftware(int flag)
		{
			grid.DataSource = ObtenerDataSoftware(flag, (DataTable)ViewState[NOMBRETABLASOFTWARE]);
			grid.DataBind();
			grid.Columns[1].FooterText = grid.Items.Count.ToString();
		}

		public DataTable ObtenerDataSoftware(int flag, DataTable dt)
		{
			DataRow drSoftware = dt.NewRow();
			drSoftware[Enumerados.ColumnasSoftwarePC.NOMBRESW.ToString()] = ddlSoftware.SelectedItem.Text;		
			drSoftware[Enumerados.ColumnasSoftwarePC.LICENCIA.ToString()] = ddlLicencia.SelectedItem.Text;		
			drSoftware[Enumerados.ColumnasSoftwarePC.IDTABLALICENCIA.ToString()] = Convert.ToInt32(Enumerados.TablasTabla.TablaEstadosLicenciaSoftware);
            drSoftware[Enumerados.ColumnasSoftwarePC.IDLICENCIA.ToString()] = ddlLicencia.SelectedValue;
			drSoftware[Enumerados.ColumnasSoftwarePC.FLAG.ToString()] = flag;

			dt.Rows.Add(drSoftware);
			dt.AcceptChanges();

			ViewState[NOMBRETABLASOFTWARE] = dt;

		return dt;
		}

		private void ibtnAgregarHardware_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(ValidarHardware())
			{
				CargarGridHardWare(1);
			}
		}

		public void CargarGridHardWare(int flag)
		{
			grid2.DataSource = ObtenerDataHardWare(flag, (DataTable)ViewState[NOMBRETABLAHARDWARE]);
			grid2.DataBind();
			grid2.Columns[1].FooterText = grid2.Items.Count.ToString();
		}

		public DataTable ObtenerDataHardWare(int flag, DataTable dt)
		{
			DataRow drHardware = dt.NewRow();
			drHardware[Enumerados.ColumnasHardwarePC.NOMBREHW.ToString()] = ddlHardware.SelectedItem.Text;
			drHardware[Enumerados.ColumnasHardwarePC.FLAG.ToString()] = flag;

			dt.Rows.Add(drHardware);
			dt.AcceptChanges();

			ViewState[NOMBRETABLAHARDWARE] = dt;

			return dt;
		}

		private void ibtnAgregarProcesador_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPARAMETROS + 
					KEYQTIPOCONSULTA + 
					Utilitario.Constantes.SIGNOIGUAL + 
					"394");
		}

		private void ibtnTipoPC_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPARAMETROS + 
				KEYQTIPOCONSULTA + 
				Utilitario.Constantes.SIGNOIGUAL + 
				"401");		
		}

		private void ibtnMemoria_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPARAMETROS + 
				KEYQTIPOCONSULTA + 
				Utilitario.Constantes.SIGNOIGUAL + 
				"395");	
		}

		private void ibtnDisco_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPARAMETROS + 
				KEYQTIPOCONSULTA + 
				Utilitario.Constantes.SIGNOIGUAL + 
				"396");	
		}

		private void ibtnMarcaCPU_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPARAMETROS + 
				KEYQTIPOCONSULTA + 
				Utilitario.Constantes.SIGNOIGUAL + 
				"397");	
		}

		private void ibtnModeloCPU_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPARAMETROS + 
				KEYQTIPOCONSULTA + 
				Utilitario.Constantes.SIGNOIGUAL + 
				"398");	
		}

		private void ibtnLicencia_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPARAMETROS + 
				KEYQTIPOCONSULTA + 
				Utilitario.Constantes.SIGNOIGUAL + 
				"402");	
		}

		private void grid_ItemDataBound_1(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
			}
		}

		private void grid2_ItemDataBound_1(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid2.CurrentPageIndex,grid2.PageSize,e.Item.ItemIndex);
			}
		}

		private void ibtnNuevoSoftware_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPARAMETROS + 
				KEYQTIPOCONSULTA + 
				Utilitario.Constantes.SIGNOIGUAL + 
				"406");			
		}

		private void ibtnNuevoHardware_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPARAMETROS + 
				KEYQTIPOCONSULTA + 
				Utilitario.Constantes.SIGNOIGUAL + 
				"407");	
		}

		private void chkNoContratado_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkNoContratado.Checked == true)
			{			
				ibtnVerDetallePersonal.Visible = false;
				txtJefeProyectos.ReadOnly = false;
				ibtnDestinatario.Visible = false;
			}
			else
			{
				ibtnVerDetallePersonal.Visible = false;
				txtJefeProyectos.ReadOnly = true;
				ibtnDestinatario.Visible = true;				
			}
		}
	}
}
