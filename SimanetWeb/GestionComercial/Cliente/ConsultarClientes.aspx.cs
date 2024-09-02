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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial.Cliente
{
	/// <summary>
	/// Summary description for ConsultarClientes.
	/// </summary>
	public class ConsultarClientes : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblCantClientes;
		protected System.Web.UI.WebControls.TextBox txtCantClientes;
		protected System.Web.UI.WebControls.ImageButton ibtnCuadroSatis;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hopcion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hRangoFecha;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.DropDownList ddlbPais;
		protected System.Web.UI.WebControls.Label lblPais;
		protected System.Web.UI.WebControls.DropDownList ddlbActividad;
		protected System.Web.UI.WebControls.DropDownList ddlbProducto;
		protected System.Web.UI.WebControls.Label lblProducto;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected System.Web.UI.WebControls.Label lblFechaInicio;
		protected eWorld.UI.CalendarPopup CalFechaFin;
		protected System.Web.UI.WebControls.Label lblFechaFin;
		protected System.Web.UI.WebControls.CheckBox ckbExclusion;
		protected System.Web.UI.WebControls.TextBox txtRazonSocial;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.CheckBox ckbSI;
		protected System.Web.UI.WebControls.CheckBox ckbSCH;
		protected System.Web.UI.WebControls.CheckBox ckbSC;
		protected System.Web.UI.WebControls.Label lblAstillero;
		protected System.Web.UI.WebControls.CheckBox ckbSV;
		protected System.Web.UI.WebControls.CheckBox ckbMM;
		protected System.Web.UI.WebControls.CheckBox ckbAE;
		protected System.Web.UI.WebControls.CheckBox ckbRN;
		protected System.Web.UI.WebControls.CheckBox ckbCN;
		protected System.Web.UI.WebControls.Label lblLineaNegocio;
		protected System.Web.UI.WebControls.ImageButton ibtnConsultar;
		protected System.Web.UI.WebControls.ImageButton ibtnConsultarTodosClientes;
		protected System.Web.UI.WebControls.Label lblActividad;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltroConsulta;
		protected System.Web.UI.WebControls.CheckBox chkTipoComercial;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region Constantes
		//Paginas
		const string URLIMPRESION      = "PopupImpresionConsultarCliente.aspx";
		const string URLDETALLEClIENTE = "ConsultaDetalleCliente.aspx?";
		const string URLDETALLEMONTO   = "ConsultarDetalleMontoCliente.aspx?";
	
		//Key Session y QueryString
		const string KEYQID = "IdCliente";
		const string KEYQNOMBRE = "RazonSocial";
		
		//Otros
		const string GRILLAVACIA ="No existe ningun Cliente."; 
		const string TEXTOTOTAL = "Monto";
		const string CLASIFICACION = "Sin Clasificar";
		const string DEFAULTANO = "01/01/0001";
		const int PosicionNro = 0;
		const int PosicionRazonSocial = 2;
		const int PosicionMonto = 3;
		const int PosicionUtilidad = 4;
		const int PosicionClasificacion = 5;
		const int PosicionClasificacionDataTable = 4;
		const int POSICIONFOOTERTOTAL =3;
		const string COMBOPAIS = "ddlbPais";
		const string COMBOACTIVIDAD = "ddlbActividad";
		const string COMBOPRODUCTO = "ddlbProducto";
		const string CALENDARIOFECHAINICIO = "CalFechaInicio";
		const string CALENDARIOFECHAFIN = "CalFechaFin"; 
		const string CAJATEXTORAZONSOCIAL = "txtRazonSocial";
		const string CHECKBOXSC = "ckbSC";
		const string CHECKBOXSCH = "ckbSCH";
	    const string CHECKBOXSI = "ckbSI";
		const string CHECKBOXCN = "ckbCN";
		const string CHECKBOXRN = "ckbRN";
		const string CHECKBOXAE = "ckbAE";
	    const string CHECKBOXMM = "ckbMM";
		const string CHECKBOXSV = "ckbSV";
		const string INDICEPAGINA = "hGridPagina";
		const string PAGINASORT = "hGridPaginaSort";
		const string TIPOOPCION = "hopcion";
		const string RANGOFECHA = "hRangoFecha";
		#endregion Constantes
		
		#region Variables
		private  ListItem  lItem ;
		private  ListItem  lItem1 ;
		private int Flag = 1;
		private string FlagTodos = "1";
		private string FlagPorFiltros = "2";
		private int TipoActividad = -1;
		private int TipoProducto = -1;
		private int Pais = -1;
		private int exclusion = -1;
		private string rangofecha = "-1";
		private DateTime RangoFecha1;
		private DateTime RangoFecha2;
		private int callao = -1;
		private int chimbote = -1;
		private int iquitos = -1;
		private int cn = -1;
		private int rn = -1;
		private int ae = -1;
		private int mm = -1;
		private int ss = -1;
		private int CANTELIMINAR = 10;
		private int ValorDefault = -1;
		private string FechaDefault = "01/01/1996";
		#endregion Variables
	
		private void Page_Load(object sender, System.EventArgs e) 
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					this.EstadoControles();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultaron Clientes por Compra.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
			this.ckbSC.CheckedChanged += new System.EventHandler(this.ckbSC_CheckedChanged);
			this.ibtnConsultar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnConsultar_Click);
			this.ibtnEliminarFiltroConsulta.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltroConsulta_Click);
			this.ibtnConsultarTodosClientes.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnConsultarTodosClientes_Click);
			this.chkTipoComercial.CheckedChanged += new System.EventHandler(this.chkTipoComercial_CheckedChanged);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarClientes.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarClientes.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtCliente = new DataTable();

			dtCliente = this.ConsultarCliente();

			if(dtCliente != null)
			{
				DataView dwCliente = dtCliente.DefaultView;
				dwCliente.Sort = columnaOrdenar ;
				dwCliente.RowFilter = Helper.ObtenerFiltro(this);
			
				if (dwCliente.Count == 0)
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
					ibtnImprimir.Visible = false;
					ibtnFiltrar.Visible = false;
					ibtnFiltrarSeleccion.Visible = false;
					ibtnEliminarFiltro.Visible = false;
					txtCantClientes.Text = Utilitario.Constantes.VACIO;
				}
				else
				{
					grid.DataSource = dwCliente;
					grid.CurrentPageIndex = indicePagina;
					Double [] x =  Helper.TotalizarDataView(dwCliente,TEXTOTOTAL);
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = x[Constantes.POSICIONCONTADOR].ToString(Utilitario.Constantes.FORMATODECIMAL4);
					txtCantClientes.Text = dwCliente.Count.ToString();
					txtCantClientes.Style[Constantes.ALINEAMIENTOTEXTO] = TextAlign.Right.ToString();
					lblResultado.Visible = false;
					ibtnImprimir.Visible = true;
					grid.Columns[2].FooterText=dwCliente.Count.ToString();
				}

				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwCliente.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTELISTARTODOSCLIENTES),columnaOrdenar,indicePagina);
			
			}
			else
			{
				grid.DataSource = dtCliente;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
				ibtnImprimir.Visible = false;
				ibtnFiltrar.Visible = false;
				ibtnEliminarFiltro.Visible = false;
				txtCantClientes.Text = Utilitario.Constantes.VACIO;
			}

			try
			{
				grid.DataBind();
			}
			catch(Exception ex)	
			{
				string a = ex.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}

		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			lItem1 = new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.VALORTODOS);
			this.llenarPais();
			this.LlenarActividad(); 
			this.LlenarProducto();

			this.ddlbPais.Items.Insert(0,lItem);
			this.ddlbPais.Items.Insert(1,lItem1);
			this.ddlbActividad.Items.Insert(0,lItem);
			this.ddlbActividad.Items.Insert(1,lItem1);
			this.ddlbProducto.Items.Insert(0,lItem);
			this.ddlbProducto.Items.Insert(1,lItem1);
		}
		 
		public void EstadoControles()
		{
			Helper.ReestablecerPagina(this);
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarClientes.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarClientes.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarClientes.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarClientes.Exportar implementation
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
			if(!Helper.ValidarRangoFechas(CalFechaInicio.SelectedDate,CalFechaFin.SelectedDate))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJERANGOFECHAS));
				return false;
			}
			else if(Convert.ToString(CalFechaInicio.SelectedDate).Remove(CANTELIMINAR,Convert.ToString(CalFechaInicio.SelectedDate).Length - CANTELIMINAR) == DEFAULTANO && Convert.ToString(CalFechaFin.SelectedDate).Remove(CANTELIMINAR,Convert.ToString(CalFechaFin.SelectedDate).Length - CANTELIMINAR) != DEFAULTANO )
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Utilitario.Mensajes.CODIGOMENSAJEFECHAINICIAL));
				return false;
			}
			else if(Convert.ToString(CalFechaFin.SelectedDate).Remove(CANTELIMINAR,Convert.ToString(CalFechaFin.SelectedDate).Length - CANTELIMINAR) == DEFAULTANO && Convert.ToString(CalFechaInicio.SelectedDate).Remove(CANTELIMINAR,Convert.ToString(CalFechaInicio.SelectedDate).Length - CANTELIMINAR) != DEFAULTANO)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Utilitario.Mensajes.CODIGOMENSAJEFECHAFINAL));
				return false;
			}
			else
			{
				return true;
			}
		}

		#endregion

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}


		#region LlenarPais
		private void llenarPais()
		{
			CUbigeo oCUbigeo = new CUbigeo();
			ddlbPais.DataSource = oCUbigeo.ListaTodosCombo();
			ddlbPais.DataValueField = Enumerados.ColumnasUbigeo.IdUbigeo.ToString();
			ddlbPais.DataTextField =Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlbPais.DataBind();

		}
		#endregion

		#region LlenarActividad
		private void LlenarActividad()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbActividad.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TablaActividadCliente));
			ddlbActividad.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbActividad.DataTextField  = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbActividad.DataBind();
			
		}
		#endregion

		#region LlenarProducto
		private void LlenarProducto()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbProducto.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TipoProducto));
			ddlbProducto.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbProducto.DataTextField  = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbProducto.DataBind();
			
		}
		#endregion

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ConsultarCliente(),
				Enumerados.GeneralCliente.RazonSocial.ToString()+ ";" + Enumerados.GeneralCliente.RazonSocial.ToString(),
				Enumerados.GeneralCliente.Monto.ToString()      + ";" + Enumerados.GeneralCliente.Monto.ToString(),
				Utilitario.Constantes.SIGNOASTERISCO + Enumerados.GeneralCliente.Clasificacion.ToString() + ";" + Enumerados.GeneralCliente.Clasificacion.ToString());
		}


		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnConsultar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(this.ValidarFiltros())
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Comercial",this.ToString(),"Se consultó a los clientes segun criterio dee filtro.",Enumerados.NivelesErrorLog.I.ToString()));
					this.hopcion.Value = FlagPorFiltros;
					this.hGridPagina.Value = Utilitario.Constantes.POSICIONCONTADOR.ToString();
					this.hGridPaginaSort.Value = Utilitario.Constantes.VACIO;
					this.hRangoFecha.Value = Utilitario.Constantes.FUERADERANGO.ToString();
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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


		private DataTable ConsultarCliente()
		{
			CCliente oCCliente = new CCliente();
			
			if(ddlbActividad.SelectedValue != Constantes.VALORSELECCIONAR)
				TipoActividad = Convert.ToInt32(ddlbActividad.SelectedValue);
				
			if(ddlbProducto.SelectedValue != Constantes.VALORSELECCIONAR)
				TipoProducto = Convert.ToInt32(ddlbProducto.SelectedValue);
			
			if(ddlbPais.SelectedValue != Constantes.VALORSELECCIONAR)
			{
				Pais = Convert.ToInt32(ddlbPais.SelectedValue);

				if(Pais == Utilitario.Constantes.PERU)
				{
					Pais = Utilitario.Constantes.NACIONAL;
				}
				else if(Pais == Utilitario.Constantes.NOPERU)
				{
					Pais = Utilitario.Constantes.EXTRANJERO;
				}
			}

			if (ckbExclusion.Checked)
				exclusion = this.Flag;

			if(Convert.ToString(CalFechaInicio.SelectedDate).Remove(CANTELIMINAR,Convert.ToString(CalFechaInicio.SelectedDate).Length - CANTELIMINAR) != DEFAULTANO && Convert.ToString(CalFechaFin.SelectedDate).Remove(CANTELIMINAR,Convert.ToString(CalFechaFin.SelectedDate).Length - CANTELIMINAR) != DEFAULTANO )
			{
				this.hRangoFecha.Value = Flag.ToString();
				RangoFecha1 = Convert.ToDateTime(CalFechaInicio.SelectedDate);
				RangoFecha2 = Convert.ToDateTime(CalFechaFin.SelectedDate);

			}
			//Centros Operativos
			if(ckbSC.Checked)
				callao = Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaCallao);
		
			if(ckbSCH.Checked)
				chimbote = Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaChimbote);
				
			if(ckbSI.Checked)
				iquitos = Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaIquitos);

			//Lineas de Negocio
			if(ckbCN.Checked)
				cn = Convert.ToInt32(Utilitario.Enumerados.LineaNegocio.ConstruccionesNavales);
		
			if(ckbRN.Checked)
				rn = Convert.ToInt32(Utilitario.Enumerados.LineaNegocio.ReparacionesNavales);
						
			if(ckbAE.Checked)
				ae = Convert.ToInt32(Utilitario.Enumerados.LineaNegocio.ArmasElectronica);
				
			if(ckbMM.Checked)
				mm = Convert.ToInt32(Utilitario.Enumerados.LineaNegocio.MetalMecanico);

			if(ckbSV.Checked)
				ss = Convert.ToInt32(Utilitario.Enumerados.LineaNegocio.Servicios);

			string RazonSocial = Convert.ToString(txtRazonSocial.Text.Trim()) ;


			if(this.hopcion.Value == FlagTodos ) //Todos los clientes 
			{
				return oCCliente.ObtenerClientesPorCriterioFiltros(ValorDefault,ValorDefault,ValorDefault,ValorDefault,Convert.ToDateTime(FechaDefault),
					   Convert.ToDateTime(FechaDefault),ValorDefault,ValorDefault,ValorDefault,ValorDefault,ValorDefault,ValorDefault,ValorDefault,ValorDefault,ValorDefault, Utilitario.Constantes.VACIO);
			}
			else if(this.hopcion.Value == FlagPorFiltros)
			{
				if(TipoActividad == ValorDefault && TipoProducto == ValorDefault && Pais == ValorDefault && Convert.ToInt32(this.hRangoFecha.Value) == ValorDefault && RangoFecha1.ToString().Remove(CANTELIMINAR,RangoFecha1.ToString().Length - CANTELIMINAR) == DEFAULTANO && 
					RangoFecha2.ToString().Remove(CANTELIMINAR,RangoFecha2.ToString().Length - CANTELIMINAR) == DEFAULTANO && exclusion == ValorDefault && callao == ValorDefault && chimbote == ValorDefault && iquitos == ValorDefault &&
					cn == ValorDefault && rn == ValorDefault && ae == ValorDefault && mm == ValorDefault && ss == ValorDefault && RazonSocial == Utilitario.Constantes.VACIO)
				{
					return null;

				}
				else
				{
					if(this.hRangoFecha.Value == rangofecha)
					{
						return oCCliente.ObtenerClientesPorCriterioFiltros(TipoActividad,TipoProducto,Pais,Convert.ToInt32(this.hRangoFecha.Value),
							   Convert.ToDateTime(FechaDefault), Convert.ToDateTime(FechaDefault), exclusion,
							   callao,chimbote,iquitos,
							   cn,rn,ae,mm,ss,RazonSocial);
					}
					else
					{
						return oCCliente.ObtenerClientesPorCriterioFiltros(TipoActividad,TipoProducto,Pais,Convert.ToInt32(this.hRangoFecha.Value),
							   RangoFecha1, RangoFecha2, exclusion,
							   callao,chimbote,iquitos,
							   cn,rn,ae,mm,ss,RazonSocial);
					}	
				}
			}
			else
			{
				return null;
			}
			
		}


		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();

			if(chkTipoComercial.Checked==true)
			{
				LlenarGrillaPorTipoComercial(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
			}
			else
			{	
				this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);

			}
		}


		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			if(chkTipoComercial.Checked==true)
			{
				LlenarGrillaPorTipoComercial(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
			}
			else
			{	
				this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
			}
		}


		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[PosicionNro].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				if(this.hopcion.Value == FlagTodos)
				{
					e.Item.Cells[PosicionNro].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA,PAGINASORT,TIPOOPCION,RANGOFECHA) + Utilitario.Constantes.POPUPDEESPERA +
																	 Helper.MostrarVentana(URLDETALLEClIENTE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(dr[Enumerados.ColumnasCliente.IdCliente.ToString()])+ Utilitario.Constantes.SIGNOAMPERSON +
																	 Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()));
				}
				else
				{
					e.Item.Cells[PosicionNro].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.HistorialIrAdelantePersonalizado(COMBOPAIS,COMBOACTIVIDAD,COMBOPRODUCTO,CALENDARIOFECHAFIN,CALENDARIOFECHAFIN,CAJATEXTORAZONSOCIAL,CHECKBOXSC,CHECKBOXSCH,CHECKBOXSI,CHECKBOXCN,CHECKBOXRN,CHECKBOXAE,CHECKBOXMM,CHECKBOXSV,INDICEPAGINA,PAGINASORT,TIPOOPCION,RANGOFECHA) + Utilitario.Constantes.POPUPDEESPERA + 
																	 Helper.MostrarVentana(URLDETALLEClIENTE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(dr[Enumerados.ColumnasCliente.IdCliente.ToString()])+ Utilitario.Constantes.SIGNOAMPERSON +
																						   Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()));

				}
																										  
				e.Item.Cells[PosicionNro].Font.Underline = true;
				e.Item.Cells[PosicionNro].ForeColor = System.Drawing.Color.Blue;
				
		
				e.Item.Cells[PosicionMonto].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.HistorialIrAdelantePersonalizado(COMBOPAIS,COMBOACTIVIDAD,COMBOPRODUCTO,CALENDARIOFECHAFIN,CALENDARIOFECHAFIN,CAJATEXTORAZONSOCIAL,CHECKBOXSC, CHECKBOXSCH,CHECKBOXSI,CHECKBOXCN,CHECKBOXRN,CHECKBOXAE,CHECKBOXMM,CHECKBOXSV,INDICEPAGINA,PAGINASORT,TIPOOPCION,RANGOFECHA) + Utilitario.Constantes.SIGNOPUNTOYCOMA + 
																							  Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLDETALLEMONTO,KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnasCliente.IdCliente.ToString()]) + Utilitario.Constantes.SIGNOAMPERSON +
																													KEYQNOMBRE + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnasCliente.RazonSocial.ToString()]) ));
				e.Item.Cells[PosicionMonto].Font.Underline = true;
				e.Item.Cells[PosicionMonto].ForeColor = System.Drawing.Color.Blue;
				e.Item.Cells[PosicionMonto].Text = Convert.ToDouble(e.Item.Cells[PosicionMonto].Text).ToString(Constantes.FORMATODECIMAL4);

				e.Item.Cells[PosicionUtilidad].Text = Convert.ToDouble(e.Item.Cells[PosicionUtilidad].Text).ToString(Constantes.FORMATODECIMAL4);

				if(dr[PosicionClasificacionDataTable].ToString()== Utilitario.Constantes.VACIO)
				{
					e.Item.Cells[PosicionClasificacion].Text = CLASIFICACION.ToString();
				}
								
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}


		private void ibtnConsultarTodosClientes_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Comercial",this.ToString(),"Se consultó a todos los clientes .",Enumerados.NivelesErrorLog.I.ToString()));
				this.hopcion.Value = FlagTodos;
				this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));

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


		private void ibtnEliminarFiltroConsulta_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.hGridPagina.Value = Utilitario.Constantes.POSICIONCONTADOR.ToString();
			this.hGridPaginaSort.Value = Utilitario.Constantes.VACIO;
			this.hopcion.Value = Utilitario.Constantes.POSICIONDEFAULT.ToString();
			this.hRangoFecha.Value = Utilitario.Constantes.FUERADERANGO.ToString();
			this.LimpiarControles();
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}


		public void LimpiarControles()
		{
			this.ddlbPais.SelectedItem.Text = Utilitario.Constantes.TEXTOSSELECCIONAR;
			this.ddlbActividad.SelectedItem.Text = Utilitario.Constantes.TEXTOSSELECCIONAR;
			this.ddlbProducto.SelectedItem.Text = Utilitario.Constantes.TEXTOSSELECCIONAR;
			this.CalFechaInicio.Text = Utilitario.Constantes.TEXTOSSELECCIONAR;
			this.CalFechaFin.Text = Utilitario.Constantes.TEXTOSSELECCIONAR;
			this.txtRazonSocial.Text = Utilitario.Constantes.VACIO;
			this.ckbSC.Checked = false;
			this.ckbSCH.Checked = false;
			this.ckbSI.Checked = false;
			this.ckbCN.Checked = false;
			this.ckbRN.Checked = false;
			this.ckbAE.Checked = false;
			this.ckbMM.Checked = false;
			this.ckbSV.Checked = false;
		}

		private void chkTipoComercial_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkTipoComercial.Checked==true)
			{
				LlenarGrillaPorTipoComercial(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
			}
			else
			{	
				this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
			}
		}

		private void LlenarGrillaPorTipoComercial(string columnaOrdenar, int indicePagina)
		{
			CCliente oCCliente = new CCliente();
			DataTable dt = new DataTable();

			dt = oCCliente.ObtenerClientesPorTipoComercial();
			if(dt!=null)
			{
				DataView dwCliente = dt.DefaultView;
				dwCliente.Sort = columnaOrdenar;
				dwCliente.RowFilter = Utilitario.Helper.ObtenerFiltro();

				if(dwCliente.Count > 0)
				{
					grid.DataSource = dwCliente;
					grid.CurrentPageIndex = indicePagina;
					txtCantClientes.Text = dwCliente.Count.ToString();
					txtCantClientes.Style[Constantes.ALINEAMIENTOTEXTO] = TextAlign.Right.ToString();
					lblResultado.Visible = false;
					ibtnImprimir.Visible = true;
			
					Double [] x =  Helper.TotalizarDataView(dwCliente,TEXTOTOTAL);
				}
				else
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					txtCantClientes.Text = Utilitario.Constantes.VACIO;
					lblResultado.Visible = true;
					ibtnImprimir.Visible = false;
				}

				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwCliente.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTELISTARTODOSCLIENTES),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
				txtCantClientes.Text = Utilitario.Constantes.VACIO;
				lblResultado.Visible = true;
				ibtnImprimir.Visible = false;
			}
			
			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}

		}

		private void ckbSC_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
