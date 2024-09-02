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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.CartasCredito
{
	/// <summary>
	/// Summary description for AdministrarCartaCreditoNotadeCargo.
	/// </summary>
	public class AdministrarCartaCreditoNotadeCargo : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
			const string KEYIDNOTACREDITO="idNotaC";
			const string KEYIDCARTACREDITO = "idCC";
			const string KEYIDPERIODO ="Periodo";
			const string URLDETALLE = "DetalleCartadeCreditoNotadeCargo.aspx?";
			
			const string KEYIDSITUACION ="Estado";
			const string KEYIDCENTRO ="IdCentro";
			const string KEYIDMONEDA ="IdMoneda";
			const string KEYIDTIPOCREDITO = "idTipoCredito";
			
		const string GRILLAVACIA="No existen Cargos para esta Carta de Crédito";

		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnAdicionar;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.TextBox txtidCentroOperativo;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.Label lblObservacion;
		protected eWorld.UI.NumericBox nComisionNegociacion;
		protected System.Web.UI.WebControls.Label Label13;
		protected eWorld.UI.NumericBox nComisionApertura;
		protected System.Web.UI.WebControls.Label Label12;
		protected eWorld.UI.NumericBox nMontoCC;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label lblFechaVence;
		protected System.Web.UI.WebControls.Label Label4;
		protected eWorld.UI.NumericBox nDiasValidos;
		protected System.Web.UI.WebControls.Label Label17;
		protected eWorld.UI.CalendarPopup CalFechaEmite;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.TextBox txtPais;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.ImageButton imgbtnMostrarGastosOC;
		protected System.Web.UI.WebControls.TextBox txtDescripcionOC;
		protected System.Web.UI.WebControls.Label Label15;
		protected eWorld.UI.NumericBox nContravalor;
		protected eWorld.UI.NumericBox nTipoCambio;
		protected eWorld.UI.NumericBox NTotalOC;
		protected eWorld.UI.NumericBox nGastos;
		protected eWorld.UI.NumericBox nImporte;
		protected System.Web.UI.WebControls.TextBox txtProveedor;
		protected System.Web.UI.WebControls.TextBox txtCentroOperativo;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtMoneda;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DropDownList ddlbOrdenCompra;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbEntidadFinanciera;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtNroDocumento;
		protected System.Web.UI.WebControls.Label lblInformeEmitido;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPais;
		protected System.Web.UI.HtmlControls.HtmlTableCell IdCO;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbEntidadFinanciera;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbOrdenCompra;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbSituacion;
		protected System.Web.UI.WebControls.Label Label2;
		private   ListItem item =  new ListItem();
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					this.CargarModoPagina();
					Helper.CalendarioControlStyle(this.CalFechaEmite);
					this.LlenarJScript();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarGrillaOrdenamientoPaginacion(Utilitario.Constantes.VACIO,Utilitario.Constantes.INDICEPAGINADEFAULT);
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
			this.ibtnAdicionar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAdicionar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarCartaCreditoNotadeCargo.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarCartaCreditoNotadeCargo.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			CCartaCreditoNotadeCargo oCCartaCreditoNotadeCargo = new CCartaCreditoNotadeCargo();
			return oCCartaCreditoNotadeCargo.AdministrarCartadeCreditoNotadeCargo(Utilitario.Constantes.IDDEFAULT ,Convert.ToInt32(Page.Request.Params[KEYIDCARTACREDITO]),Convert.ToInt32(Page.Request.Params[KEYIDPERIODO]));
			
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtCartaCredito = this.ObtenerDatos();
			if(dtCartaCredito!=null)
			{
				DataView dwCartaCredito = dtCartaCredito.DefaultView;
				//this.GenerarResumen(dtCartaCredito);
				dwCartaCredito.RowFilter = Helper.ObtenerFiltro();
				dwCartaCredito.Sort = columnaOrdenar ;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + " " + dwCartaCredito.Count.ToString();
				grid.DataSource = dwCartaCredito;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtCartaCredito,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtCartaCredito;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
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

		public void LlenarCombos()
		{
			this.CargarSituacion();
			this.CargarEntidadFinanciera();
			this.CargaOrdendeCompra();			
		}
		private void CargarSituacion()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoCartaCredito));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();			
		}
		private void CargarEntidadFinanciera()
		{
			CEntidadFinanciera oCEntidadFinanciera = new CEntidadFinanciera();
			ddlbEntidadFinanciera.DataSource = oCEntidadFinanciera.ListarTodosCombo ();
			ddlbEntidadFinanciera.DataValueField= Enumerados.ColumnasEntidadFinanciera.IdEntidadFinanciera.ToString();
			ddlbEntidadFinanciera.DataTextField=Enumerados.ColumnasEntidadFinanciera.RazonSocial.ToString();
			ddlbEntidadFinanciera.DataBind();
		}
		private DataTable ObtenerOrdendeCompra()
		{
			CCartaCredito oCCartaCredito = new CCartaCredito();
			return oCCartaCredito.ListarOrdendeCompra(Utilitario.Constantes.IDDEFAULT,Convert.ToString(Utilitario.Constantes.IDDEFAULT),CNetAccessControl.GetIdUser());			
		}
		private void CargaOrdendeCompra()
		{
			ListItem item;
			DataTable dtOrdenCompra = this.ObtenerOrdendeCompra();
			this.ddlbOrdenCompra.DataSource = dtOrdenCompra;
			this.ddlbOrdenCompra.DataValueField = Utilitario.Enumerados.FINOrdenCompra.idPeriodo.ToString();
			this.ddlbOrdenCompra.DataTextField = Utilitario.Enumerados.FINOrdenCompra.OrdenCompra.ToString();
			this.ddlbOrdenCompra.DataBind();
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.ddlbOrdenCompra.Items.Insert(0,item);
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarCartaCreditoNotadeCargo.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnAdicionar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarCartaCreditoNotadeCargo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarCartaCreditoNotadeCargo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarCartaCreditoNotadeCargo.Exportar implementation
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
			// TODO:  Add AdministrarCartaCreditoNotadeCargo.ValidarFiltros implementation
			return false;
		}

		#endregion

	

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;				
				string mModo =((Page.Request.Params[Utilitario.Constantes.KEYMODULOCONSULTA].ToString() == Utilitario.Enumerados.ModuloConsulta.No.ToString())? Utilitario.Enumerados.ModoPagina.M.ToString():Utilitario.Enumerados.ModoPagina.C.ToString());

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
						Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
						Helper.MostrarVentana(URLDETALLE, 
											KEYIDNOTACREDITO + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.FINColumnaCartaCreditoNotadeCargo.idNotaCredito.ToString()]
											+ Utilitario.Constantes.SIGNOAMPERSON
											+ KEYIDCARTACREDITO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDCARTACREDITO].ToString()
											+ Utilitario.Constantes.SIGNOAMPERSON
											+ KEYIDPERIODO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDPERIODO].ToString()
											+ Utilitario.Constantes.SIGNOAMPERSON
											+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + mModo
											+ Utilitario.Constantes.SIGNOAMPERSON
											+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[Utilitario.Constantes.KEYMODULOCONSULTA].ToString()
											));

				#region Helpers
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				#endregion

			}		
		}
		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarCartaCreditoNotadeCargo.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarCartaCreditoNotadeCargo.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarCartaCreditoNotadeCargo.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Utilitario.Enumerados.ModoPagina)System.Enum.Parse(typeof(Utilitario.Enumerados.ModoPagina),Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
				case Enumerados.ModoPagina.C:
					this.CargarModoModificar();
					Helper.BloquearControles(this);
					if (Page.Request.Params[Utilitario.Constantes.KEYMODULOCONSULTA].ToString()== Utilitario.Enumerados.ModuloConsulta.No.ToString())
					{
						this.ibtnAdicionar.Visible = true;
						this.LlenarJScript();
					}
					break;
			}					
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarCartaCreditoNotadeCargo.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			
			CartaCreditoBE oCartaCreditoBE = (CartaCreditoBE)
				((CCartaCredito)new CCartaCredito()).DetalleCartadeCredito(Convert.ToInt32(Page.Request.Params[KEYIDSITUACION]),
																			Convert.ToInt32(Page.Request.Params[KEYIDCARTACREDITO]),
																			Convert.ToInt32(Page.Request.Params[KEYIDPERIODO]),
																			CNetAccessControl.GetIdUser(),
																			Convert.ToInt32(Page.Request.Params[KEYIDTIPOCREDITO]));

			this.txtNroDocumento.Text = oCartaCreditoBE.NroCDI;	
			
			/*selecciona la situacion del registro*/			
			item = this.ddlbSituacion.Items.FindByValue(oCartaCreditoBE.IdEstado.ToString());
			if(item!=null)
			{item.Selected = true;}
			/*selecciona la entidad financiera*/
			item = this.ddlbEntidadFinanciera.Items.FindByValue(oCartaCreditoBE.IdEntidadFinanciera.ToString());
			if(item!=null)
			{item.Selected = true;}
			/*selecciona la Orden de compra*/
			item = this.ddlbOrdenCompra.Items.FindByText(oCartaCreditoBE.OrdenCompra.ToString());
			if(item!=null)

			{item.Selected = true;}
			this.txtMoneda.Text = oCartaCreditoBE.Moneda.ToString();
			this.txtProveedor.Text = oCartaCreditoBE.NProveedor.ToString();
			this.txtCentroOperativo.Text = oCartaCreditoBE.NombreCentroOperativo.ToString();
			this.txtidCentroOperativo.Text = Page.Request.Params[KEYIDCENTRO].ToString();			
			this.CalFechaEmite.SelectedDate = Convert.ToDateTime(oCartaCreditoBE.FechaEmision);
			this.nDiasValidos.Text=oCartaCreditoBE.NroDiasValidos.ToString(); 

			this.lblFechaVence.Text=Convert.ToDateTime(oCartaCreditoBE.FechaVencimiento).ToString().Replace("/","-").Substring(0,10);
			this.nImporte.Text = oCartaCreditoBE.MontoOC.ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
			this.nGastos.Text = oCartaCreditoBE.MontoGastoOC.ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
			this.NTotalOC.Text= Convert.ToDouble(oCartaCreditoBE.MontoOC + oCartaCreditoBE.MontoGastoOC).ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
			this.nTipoCambio.Text = Convert.ToString(oCartaCreditoBE.TipodeCambio);
			this.nContravalor.Text = oCartaCreditoBE.MontoOCContraValor.ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());

			//Montos Cartas de Credito
			this.nMontoCC.Text = oCartaCreditoBE.MontoCCredito.ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
			
			this.txtObservacion.Text = oCartaCreditoBE.Observacion.ToString();
			this.nComisionNegociacion.Text = oCartaCreditoBE.ComisionNegociacion.ToString();
			this.nComisionApertura.Text = oCartaCreditoBE.ComisionApertura.ToString();
			this.hIdPais.Value = oCartaCreditoBE.IdUbigeo.ToString();
			this.txtPais.Text = oCartaCreditoBE.NombrePais.ToString();
			this.txtDescripcionOC.Text = oCartaCreditoBE.DescripcionOC.ToString();

		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarCartaCreditoNotadeCargo.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarCartaCreditoNotadeCargo.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarCartaCreditoNotadeCargo.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarCartaCreditoNotadeCargo.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void ibtnAdicionar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLDETALLE + KEYIDCARTACREDITO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDCARTACREDITO].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYIDPERIODO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDPERIODO].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYIDMONEDA + Utilitario.Constantes.SIGNOIGUAL +  txtMoneda.Text
				);		
		
		}
	}
}
