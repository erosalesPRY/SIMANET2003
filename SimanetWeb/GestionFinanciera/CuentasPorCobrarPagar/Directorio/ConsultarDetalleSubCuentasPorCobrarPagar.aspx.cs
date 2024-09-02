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
using NetAccessControl;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Controladoras.General;
using NullableTypes;

namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio
{
	/// <summary>
	/// Summary description for ConsultarCuentasPorPagar.
	/// </summary>
	public class ConsultarDetalleSubCuentasPorCobrarPagar: System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblPrimario;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label Label1;  
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "Cliente";
	
		//Paginas
		//const string URLDETALLE = "ConsultarDetalleCuentasPorPagarOtros.aspx?";
		const string URLIMPRESION = "PopupImpresionConsultarCuentasPorPagar.aspx";
				
		//Key Session y QueryString
		const string KEYQIDTIPOCUENTA = "IdTipoCuenta";
		const string KEYQIDCUENTAPORCOBRARPAGAR = "IdCuenta";
		const string KEYQIDSUBCUENTAPORCOBRARPAGAR = "IdSubCuenta";
		const string KEYQIDCENTROOPERATIVO= "IdCentroOperativo";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQDESCRIPCIONCUENTA = "Cuenta";
		const string KEYQDESCRIPCIONSUBCUENTA = "SubCuenta";
		const string KEYQIDLETRACAMBIO = "IdLetraCambio";
		const string KEYQFLAGDIRECTORIO= "FlagDirectorio";
		
		const string KEYQENTIDAD = "idEntidad";
		const string KEYQRAZONSOCIAL="Rsocial";
		const string KEYQNRODOCUMENTO = "Ndoc";
		const string URLPAGINADETALLE = "ConsultarDetalleCuentasPorCobraryPagar.aspx?";
		const string KEYQIDAJUSTE = "idAjuste";
		const string URLDETALLEXCEL="ExportarDetalleExcel.aspx?";
		const int IDANTICIPOPROVEEDOR = 3;
		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminar(this.form,'cbxEliminar','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";

		//Otros
		const string GRILLAVACIA ="No existe ninguna SubCuenta";  
		const string PROVEEDOR="PROVEEDOR";  
		const string CLIENTE ="CLIENTE";
		const string CUENTAPORCOBRAR="0";
		const string NRORUC="Ruc. : ";

		const string CONTROLTEXTO="txtDescripcion";

		#endregion Constantes
		protected System.Web.UI.WebControls.ImageButton ibtnAbrir;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPathPagDetalle;

		#region Variables			
		NullableDouble acumCantidadTotal;
		#endregion Variables
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					//Graba en el Log la acción ejecutada
					
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"CuentasPorPagar",this.ToString(),"Se consultó la Cuentas Por Pagar",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.SeleccionarItemCombos(this);
					
					this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));				
					this.LlenarJScript();
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public DataTable ObtenerDatos()
		{
			CCuentasPorCobrarPagar oCCuentasPorCobrarPagar=  new CCuentasPorCobrarPagar();
			DataTable dtCuentasPorPagar;

			if (Convert.ToInt32(Page.Request.QueryString[KEYQFLAGDIRECTORIO].ToString()) == Utilitario.Constantes.POSICIONINDEXUNO)
			{
				return dtCuentasPorPagar = dtCuentasPorPagar = 
					oCCuentasPorCobrarPagar.ConsultarDetalleSubCuentaPorCobrarPagarAlCierre(
					Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]),
					Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOCUENTA]),				
					Convert.ToInt32(Page.Request.QueryString[KEYQIDCUENTAPORCOBRARPAGAR]),				
					Convert.ToInt32(Page.Request.QueryString[KEYQIDSUBCUENTAPORCOBRARPAGAR]));
			}
			else
			{
				return dtCuentasPorPagar = 
					oCCuentasPorCobrarPagar.ConsultarDetalleSubCuentaPorCobrarPagar(
					Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]),
					Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOCUENTA]),				
					Convert.ToInt32(Page.Request.QueryString[KEYQIDCUENTAPORCOBRARPAGAR]),				
					Convert.ToInt32(Page.Request.QueryString[KEYQIDSUBCUENTAPORCOBRARPAGAR]));
			}
		}

		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{

		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			this.lblPrimario.Text= Page.Request.Params[KEYQDESCRIPCION].ToString();

			if(Page.Request.QueryString[KEYQIDTIPOCUENTA] == CUENTAPORCOBRAR)
			{
				grid.Columns[1].HeaderText = Convert.ToInt32(Page.Request.Params[KEYQIDSUBCUENTAPORCOBRARPAGAR])==IDANTICIPOPROVEEDOR? PROVEEDOR:CLIENTE;
			}
			else
			{grid.Columns[1].HeaderText = PROVEEDOR;}

			if(Page.Request.QueryString[KEYQIDLETRACAMBIO] != null)
			{
				grid.Columns[2].HeaderText = "NRO. LETRA";
				grid.Columns[3].HeaderText = "FECHA GIRO";
				grid.Columns[5].Visible =true;
			}

			DataTable dtCuentasPorPagar = this.ObtenerDatos();

			if(dtCuentasPorPagar!=null)
			{
				dtCuentasPorPagar = Helper.TablePersonalizado(dtCuentasPorPagar,"FechaEmision");

				DataView dwCuentasPorPagar = dtCuentasPorPagar.DefaultView;
				dwCuentasPorPagar.Sort = columnaOrdenar ;
				dwCuentasPorPagar.RowFilter = Utilitario.Helper.ObtenerFiltro();

				if (dwCuentasPorPagar.Count == 0)
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
				}
				else
				{
					grid.DataSource = dwCuentasPorPagar;
					Session["EXPORTAREXCEL"]=dtCuentasPorPagar;
					grid.CurrentPageIndex =indicePagina;
					grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwCuentasPorPagar.Count.ToString();

					this.Totalizar(dwCuentasPorPagar);
					lblResultado.Visible = false;
				}
			}
			else
			{
				grid.DataSource = dtCuentasPorPagar;
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

		private void Totalizar(DataView dwTotales)
		{
			if (dwTotales !=null)
			{
				CFuncionesEspeciales oCFuncionesEspeciales=new CFuncionesEspeciales();
				acumCantidadTotal = NullableDouble.Parse(oCFuncionesEspeciales.CalcularMontosTotalesDataFile(dwTotales,Enumerados.FINColumnaResumenCuentasPorPagar.TotalEnSoles.ToString()));
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			
			string parametros =KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL+ Page.Request.Params[KEYQDESCRIPCION].ToString()+
				Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL+ Page.Request.Params[KEYQIDTIPOCUENTA].ToString()+
				Utilitario.Constantes.SIGNOAMPERSON + KEYQIDSUBCUENTAPORCOBRARPAGAR + Utilitario.Constantes.SIGNOIGUAL+ Page.Request.Params[KEYQIDSUBCUENTAPORCOBRARPAGAR].ToString()+
				Utilitario.Constantes.SIGNOAMPERSON + KEYQFLAGDIRECTORIO + Utilitario.Constantes.SIGNOIGUAL+ Page.Request.Params[KEYQFLAGDIRECTORIO].ToString();

			if(Page.Request.Params[KEYQIDLETRACAMBIO]!=null)
					parametros = parametros + Utilitario.Constantes.SIGNOAMPERSON + KEYQIDLETRACAMBIO + Utilitario.Constantes.SIGNOIGUAL+ Page.Request.Params[KEYQIDLETRACAMBIO].ToString();
			
			ibtnAbrir.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLDETALLEXCEL+parametros,780,640));
			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
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


		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{e.Item.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				//e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);


				string Parametros  = KEYQIDCENTROOPERATIVO  + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[KEYQIDCENTROOPERATIVO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQRAZONSOCIAL + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[1].Text
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDTIPOCUENTA  + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[KEYQIDTIPOCUENTA].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDCUENTAPORCOBRARPAGAR  + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDSUBCUENTAPORCOBRARPAGAR  + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[KEYQIDSUBCUENTAPORCOBRARPAGAR].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQENTIDAD + Utilitario.Constantes.SIGNOIGUAL +  dr["idEntidad"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQNRODOCUMENTO + Utilitario.Constantes.SIGNOIGUAL +  dr["num_doc_ana"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQDESCRIPCION].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
                    + KEYQIDAJUSTE + Utilitario.Constantes.SIGNOIGUAL + dr["idAjuste"].ToString();

				
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,Helper.PopupDialogoModal(URLPAGINADETALLE + Parametros ,700,300,false));
				
				e.Item.ToolTip = dr[Enumerados.FINColumnaResumenCuentasPorPagar.NroRuc.ToString()].ToString();

				TextBox txt=(TextBox)e.Item.Cells[6].FindControl(CONTROLTEXTO);	
				txt.Text =dr["concepto"].ToString(); //NRORUC + dr[Enumerados.FINColumnaResumenCuentasPorPagar.Descripcion.ToString()].ToString();

					Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("txtObservaciones",
					dr[Enumerados.FINColumnaResumenCuentasPorPagar.Observacion.ToString()].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				double monto = NullableIsNull.IsNullDouble(acumCantidadTotal,Utilitario.Constantes.POSICIONINDEXCERO);
				e.Item.Cells[4].Text = monto.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}		
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			DataTable dtCuentasPorPagar= this.ObtenerDatos();

			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this,dtCuentasPorPagar,"../../../Filtros.aspx"
				,Enumerados.FINColumnaResumenCuentasPorPagar.RazonSocial.ToString() + ";Cliente"
				,Enumerados.FINColumnaResumenCuentasPorPagar.NroRuc.ToString() + ";Nro. Ruc"
				,Enumerados.FINColumnaResumenCuentasPorPagar.Num_Doc_Ana.ToString() + ";Factura"
				,Enumerados.FINColumnaResumenCuentasPorPagar.FechaEmision.ToString() + ";Fecha"
				,Enumerados.FINColumnaResumenCuentasPorPagar.TotalEnSoles.ToString() + ";Saldo"
				,Enumerados.FINColumnaResumenCuentasPorPagar.Descripcion.ToString()+ ";Concepto");
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();						
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
