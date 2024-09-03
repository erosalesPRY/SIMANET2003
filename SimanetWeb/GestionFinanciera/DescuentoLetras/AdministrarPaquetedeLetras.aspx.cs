using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using MetaBuilders.WebControls;
using SIMA.SimaNetWeb.Legal;


namespace SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras
{
	/// <summary>
	/// Summary description for AdministrarPaquetedeLetras.
	/// </summary>
	public class AdministrarPaquetedeLetras : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{


		const string KEYIDDOCDESCLET ="idDocdescLetra";
		const string KEYIDLETDESCTDET ="idLetraDesctDet";
		const string KEYIDTIPOLETRA = "TipoLetra";
		const string KEYNOMBRETIPOLETRA = "NombreTipoLetra";
		const string KEYIDCENTRO = "idCentro";
		const string KEYCENTROABREV = "CentroAbrev";
		const string KEYIDMONEDA = "idMoneda";

		const string URLBUSQUEDALETRAS = "BuscarLetras.aspx?";


		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro de Descuento de Letras.";  

		/*const string KEYIDDOCDESCLET ="idDocdescLetra";
		const string KEYIDLETDESCTDET ="idLetraDesctDet";
		const string KEYIDTIPOLETRA = "TipoLetra";
		const string KEYNOMBRETIPOLETRA = "NombreTipoLetra";
		const string KEYIDCENTRO = "idCentro";*/
		
		const string KEYIDENTIDADFINANCIERA = "idEF";
		const string URLLETRASDESCUENTO = "DetallePaqueteLetrasDescuento.aspx?";
		const string URLLETRASADMAMORTIZA= "AdministrarLetrasAmortizaciones.aspx?";
		
		const string CAMPOFECHA1 = "lblFechaInicio";
		const string CAMPOFECHA2 = "lblFechaVence";

		const string CAMPODIAS1 = "lblDiasPlazo";
		const string CAMPODIAS2 = "lblDiasFaltantes";

		const string CAMPOMONTO1 = "lblImporteLetra";
		const string CAMPOMONTO2 = "nImporteInteres";
		const string CAMPOMONTO3 = "nImporteGasto";
		const string CAMPOMONTO4 = "lblImporteAbonado";

		//Columnas DataTable
		const string IDLETRA ="idLetra";
		const string NRODOCUMENTO ="NroDocumento";
		const string IDCENTROOPERATIVO ="idCentroOperativo";
		const string ABREVCENTROOPERATIVO ="AbreviaturaCentroOperativo";
		const string IDPROYECTOCONTRATO ="idProyectoContrato";
		const string NOMBREPROYECTO ="NombreProyecto";
		const string DESCRIPCIONPROYECTO ="DescripcionProyecto";
		const string IDTABLATIPOLETRA ="idTablaTipoLetra";
		const string IDTIPOLETRA ="idTipoLetra";
		const string FECHAINICIO ="FechaInicio";
		const string FECHAVENCIMIENTO ="FechaVencimiento";
		const string NRODIASPLAZO ="NroDiasPlazo";
		const string NRODIASFALTANTES ="NroDiasFaltantes";
		const string IDTABLASITUACION ="idTablaSituacion";
		const string IDSITUACION ="idSituacion";
		const string SITUACION ="Situacion";
		const string IDTABLAMONEDA ="idTablaMoneda";
		const string IDMONEDA ="idMoneda";
		const string MONEDA ="Moneda";
		const string IDTABLATIPOENTIDAD ="idTablaTipoEntidad";
		const string IDTIPOENTIDAD ="idTipoEntidad";
		const string IDENTIDAD ="idEntidad";
		const string NROENTIDAD ="NroEntidad";
		const string RAZONSOCIAL ="RazonSocial";
		const string MONTO ="Monto";
		const string TASAINTERES ="TasaInteres";
		const string OBSERVACION ="Observacion";
		const string IDTABLAESTADO ="idTablaEstado";
		const string IDESTADO ="idEstado";

		//Columnas DataGrid
		const string AMORTIZA ="Amortiza";
		const string SALDO = "Saldo";



		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtNroDocumento;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label Label12;
		protected eWorld.UI.CalendarPopup CalFechaDesembolso;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtCuentaBCO;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtMoneda;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtCentro;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtEntidadFinanciera;
		protected System.Web.UI.WebControls.Label Label16;
		protected eWorld.UI.NumericBox nMontoLetras;
		protected System.Web.UI.WebControls.Label Label20;
		protected eWorld.UI.NumericBox nMontoAmortizado;
		protected System.Web.UI.WebControls.Label Label21;
		protected eWorld.UI.NumericBox nMontoSaldo;
		protected System.Web.UI.WebControls.Label Label14;
		protected eWorld.UI.NumericBox nTasaInteres;
		protected System.Web.UI.WebControls.Label Label19;
		protected eWorld.UI.NumericBox nMontoInteresBCO;
		protected System.Web.UI.WebControls.Label Label15;
		protected eWorld.UI.NumericBox nMontoDesembolso;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtidCuentaBancoCentro;
		protected System.Web.UI.WebControls.Label lblMontoSaldo;
		protected System.Web.UI.WebControls.Label lblMontoAmortizado;
		protected System.Web.UI.WebControls.Label lblMontoLetras;
		protected System.Web.UI.WebControls.Label lblMontoDescuento;
		protected System.Web.UI.WebControls.Label lblMontoDesembolso;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label17;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.Label lblFechaInicio;
		protected System.Web.UI.WebControls.Label lblFechaVence;
		protected System.Web.UI.WebControls.Label lblDiasPlazo;
		protected System.Web.UI.WebControls.Label lblDiasFaltantes;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.Label lblMonto;
		protected System.Web.UI.WebControls.Label lblAmortiza;
		protected System.Web.UI.WebControls.Label lblSaldo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidLetraDescuento;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarCombos();
					this.CargarModoConsulta();
					this.LlenarJScript();
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(hGridPagina.Value));
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
					ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
				}
				catch(Exception oException)
				{
					string debug = oException.Message.ToString();
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
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarPaquetedeLetras.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return ((CLetrasDescuento) new CLetrasDescuento()).AdministrarDetalleLetrasDescuento(Convert.ToString(Page.Request.Params[KEYIDDOCDESCLET]),
																									Convert.ToString(Utilitario.Constantes.IDDEFAULT));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			this.LlenarGrillaOrdenamientoPaginacion(columnaOrdenar, indicePagina,this.ObtenerDatos());
		}
		
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina,DataTable dt)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			DataTable dtLetrasDsct=dt;
			if(dtLetrasDsct!=null)
			{
				DataView dwLetrasDsct= dtLetrasDsct.DefaultView;
				dwLetrasDsct.RowFilter = Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwLetrasDsct.Count.ToString();
				dwLetrasDsct.Sort = columnaOrdenar ;
				grid.DataSource = dwLetrasDsct;
				grid.CurrentPageIndex = indicePagina;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtLetrasDsct;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				//ibtnImprimir.Visible = false;
			}
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		private DataTable CrearTabla()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(IDLETRA,System.Type.GetType("System.Int32"));
			dt.Columns.Add(NRODOCUMENTO,System.Type.GetType("System.String"));
			dt.Columns.Add(IDCENTROOPERATIVO,System.Type.GetType("System.Int32"));
			dt.Columns.Add(ABREVCENTROOPERATIVO,System.Type.GetType("System.String"));
			dt.Columns.Add(IDPROYECTOCONTRATO,System.Type.GetType("System.Int32"));
			dt.Columns.Add(NOMBREPROYECTO,System.Type.GetType("System.String"));
			dt.Columns.Add(DESCRIPCIONPROYECTO,System.Type.GetType("System.String"));
			dt.Columns.Add(IDTABLATIPOLETRA,System.Type.GetType("System.Int32"));
			dt.Columns.Add(IDTIPOLETRA,System.Type.GetType("System.Int32"));
			dt.Columns.Add(FECHAINICIO,System.Type.GetType("System.String"));
			dt.Columns.Add(FECHAVENCIMIENTO,System.Type.GetType("System.String"));
			dt.Columns.Add(NRODIASPLAZO,System.Type.GetType("System.Int32"));
			dt.Columns.Add(NRODIASFALTANTES,System.Type.GetType("System.Int32"));
			dt.Columns.Add(IDTABLASITUACION,System.Type.GetType("System.Int32"));
			dt.Columns.Add(IDSITUACION,System.Type.GetType("System.Int32"));
			dt.Columns.Add(SITUACION,System.Type.GetType("System.String"));
			dt.Columns.Add(IDTABLAMONEDA,System.Type.GetType("System.Int32"));
			dt.Columns.Add(IDMONEDA,System.Type.GetType("System.Int32"));
			dt.Columns.Add(MONEDA,System.Type.GetType("System.String"));
			dt.Columns.Add(IDTABLATIPOENTIDAD,System.Type.GetType("System.Int32"));
			dt.Columns.Add(IDTIPOENTIDAD,System.Type.GetType("System.Int32"));
			dt.Columns.Add(IDENTIDAD,System.Type.GetType("System.Int32"));
			dt.Columns.Add(NROENTIDAD,System.Type.GetType("System.Int32"));
			dt.Columns.Add(RAZONSOCIAL,System.Type.GetType("System.String"));
			dt.Columns.Add(MONTO,System.Type.GetType("System.Double"));
			dt.Columns.Add(TASAINTERES,System.Type.GetType("System.Decimal"));
			dt.Columns.Add(OBSERVACION,System.Type.GetType("System.String"));
			dt.Columns.Add(IDTABLAESTADO,System.Type.GetType("System.Int32"));
			dt.Columns.Add(IDESTADO,System.Type.GetType("System.Int32"));
			return dt;
		}

		public void LlenarCombos()
		{
			this.CargarSituacion();
		}
		private void CargarSituacion()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoDescuento));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();			
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarPaquetedeLetras.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			//this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
			//this.ibtnAmortizar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
			string strpath= URLBUSQUEDALETRAS+ KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRA].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYNOMBRETIPOLETRA].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYIDDOCDESCLET + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDDOCDESCLET].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON 
				+ KEYIDMONEDA + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[KEYIDMONEDA].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYCENTROABREV  + Utilitario.Constantes.SIGNOIGUAL +  this.txtCentro.Text
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModoPagina.N.ToString();

			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(strpath,770,400,100,100,false));

			
			/*this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDALETRAS+ KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRA].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYNOMBRETIPOLETRA].ToString()
				,770,400,100,100,false));*/
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarPaquetedeLetras.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarPaquetedeLetras.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarPaquetedeLetras.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarPaquetedeLetras.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarPaquetedeLetras.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarPaquetedeLetras.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarPaquetedeLetras.Eliminar implementation
		}

		public void CargarModoPagina()
		{
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarPaquetedeLetras.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarPaquetedeLetras.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			DescuentoBE oDescuentoBE = (DescuentoBE) ((CDescuento) new CDescuento()).DetalleDescuento(Page.Request.Params[KEYIDDOCDESCLET].ToString(),Utilitario.Constantes.IDDEFAULT,Convert.ToInt32(Page.Request.Params[KEYIDENTIDADFINANCIERA]==null? Utilitario.Constantes.IDDEFAULT.ToString():Page.Request.Params[KEYIDENTIDADFINANCIERA]));
			this.txtNroDocumento.Text = oDescuentoBE.NroDescuento.ToString();
			((ListItem) this.ddlbSituacion.Items.FindByValue(oDescuentoBE.IdEstado.ToString())).Selected = true;
			this.CalFechaDesembolso.SelectedDate= Convert.ToDateTime(oDescuentoBE.FechaDesembolso);
			this.txtCuentaBCO.Text= oDescuentoBE.NroCuentaBancaria.ToString();
			this.txtidCuentaBancoCentro.Value = oDescuentoBE.IdCuentaBancariaCentro.ToString();
			this.txtMoneda.Text= oDescuentoBE.Moneda.ToString();
			this.txtCentro.Text= oDescuentoBE.NombreCentroOperativo.ToString();
			this.txtEntidadFinanciera.Text= oDescuentoBE.EntidadFinanciera.ToString();
			this.nTasaInteres.Text= oDescuentoBE.TasaInteres.ToString();
			this.nMontoInteresBCO.Text= oDescuentoBE.MontoDescuentoBCO.ToString();
			this.nMontoDesembolso.Text = oDescuentoBE.MontoDesembolso.ToString();
			this.nMontoLetras.Text= oDescuentoBE.MontodeLetras.ToString();
			this.nMontoAmortizado.Text= oDescuentoBE.MontoAmortiza.ToString();
			this.nMontoSaldo.Text= oDescuentoBE.SaldoLetra.ToString();
			this.txtObservacion.Text= oDescuentoBE.Observacion.ToString();
			//Helper.BloquearControles(this);
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarPaquetedeLetras.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarPaquetedeLetras.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarPaquetedeLetras.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
					Helper.MostrarVentana(URLLETRASDESCUENTO,KEYIDDOCDESCLET + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDDOCDESCLET].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYIDLETDESCTDET + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaLetrasDescuento.idLetrasDescuento.ToString()].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRA].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYNOMBRETIPOLETRA].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModoPagina.M.ToString()));

				//Importe de La Letra
				((Label) e.Item.Cells[4].FindControl(CAMPOMONTO1)).Text = Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaLetras.Monto.ToString()].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				//Importe de Interes
				eWorld.UI.NumericBox NBox = (eWorld.UI.NumericBox) e.Item.Cells[4].FindControl(CAMPOMONTO2);
				NBox.Text = Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaLetras.ImporteInteres.ToString()].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				NBox.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,"CalculoDesembolso(this);");

				//Importe de Gasto
				NBox = (eWorld.UI.NumericBox) e.Item.Cells[4].FindControl(CAMPOMONTO3);
				NBox.Text = Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaLetras.ImporteGasto.ToString()].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				NBox.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,"CalculoDesembolso(this);");

				//Importe de Gasto
				((Label) e.Item.Cells[4].FindControl(CAMPOMONTO4)).Text = Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaLetras.ImporteDesembolso.ToString()].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				e.Item.Attributes.Add("_IdLetrasDescuento",dr[Utilitario.Enumerados.FinColumnaLetrasDescuento.idLetrasDescuento.ToString()].ToString());
				e.Item.Attributes.Add("_ImporteLetra",dr[Utilitario.Enumerados.FinColumnaLetras.Monto.ToString()].ToString());
				e.Item.Attributes.Add("_ImporteInteres",dr[Utilitario.Enumerados.FinColumnaLetras.ImporteInteres.ToString()].ToString());
				e.Item.Attributes.Add("_ImporteGasto",dr[Utilitario.Enumerados.FinColumnaLetras.ImporteGasto.ToString()].ToString());

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hidLetraDescuento",dr[Utilitario.Enumerados.FinColumnaLetrasDescuento.idLetrasDescuento.ToString()].ToString()));
			}
		
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		}
		
		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	

		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());

		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			((CLetrasDescuento) new CLetrasDescuento()).Eliminar(Convert.ToInt32(this.hidLetraDescuento.Value),CNetAccessControl.GetIdUser()); 
			this.CargarModoConsulta();
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(hGridPagina.Value));
		}

	}
}
