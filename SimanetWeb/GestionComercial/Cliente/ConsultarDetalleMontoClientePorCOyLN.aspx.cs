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
	/// Summary description for ConsultarDetalleMontoClientePorCOyLN.
	/// </summary>
	public class ConsultarDetalleMontoClientePorCOyLN : System.Web.UI.Page, IPaginaBase										
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRuta_Pagina;
		protected System.Web.UI.WebControls.Label lblPage;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnLineaNegocio;
		protected System.Web.UI.WebControls.ImageButton ibtnAstillero;
		protected System.Web.UI.WebControls.Label lblNombreRazonSocial;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb dgConsulta;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		#endregion

		#region Constantes
		
		//Paginas
		const string URLMONTOClIENTEPORLN = "ConsultarDetalleMontoClientePorLN.aspx?";
		const string URLMONTOClIENTEPORCO = "ConsultarDetalleMontoClientePorCO.aspx?";
		
		//Key Session y QueryString
		const string KEYQID = "IdCliente";
		const string KEYQNOMBRE = "RazonSocial";
		const string KEYQCO = "CentroOperativo";
		const string KEYQLN = "CodLineaNegocio";
		const string KEYQCABLN = "CabLineaNegocio";
		const string KEYFECHAINICIO = "FechaInicio";
		const string KEYFECHAFIN = "FechaFin";

		//Paginas
		const string URLIMPRESION = "PopupImpresionConsultarDetalleMontoClientePorCOyLN.aspx?";

		//Otros
		const int POSICIONINICIALCOMBO = 0;
		const string TablaImpresion0 = "VentaRelaesPorClientePorCOyLN";
		const string TablaImpresion1 = "HistoricoVentaRelaesPorClientePorCOyLN";
		const string GRILLAVACIA ="No existe ningún detalle del Cliente.";
		const string TEXTOTOTAL = "Monto";
		const int POSICIONFOOTERTOTAL =3;
		const int ANCHO = 50;
		const int MULTIPLO = 15;
		const int PosicionMonto = 3;
		const int PosicionRentabilidad = 4;
	
		#endregion

		#region Variables
		double [] montos;
		int [] anchos;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultaron Clientes por Ventas.",Enumerados.NivelesErrorLog.I.ToString()));
					
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
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.dgConsulta.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsulta_ItemDataBound);
			this.ibtnLineaNegocio.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnLineaNegocio_Click);
			this.ibtnAstillero.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAstillero_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarDetalleMontoClientePorCOyLN.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarDetalleMontoClientePorCOyLN.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataSet dsImprimir = new DataSet();

			//Grilla Detallada del Monto del Cliente
			CCliente oCCliente = new CCliente();
			DataTable dtVentasPorClientePorCOyLN =  oCCliente.ListarDetalleVentasRealesPorClientePorCOyLN(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Convert.ToInt32(Page.Request.QueryString[KEYQCO]),Convert.ToInt32(Page.Request.QueryString[KEYQLN]),Convert.ToDateTime(Page.Request.QueryString[KEYFECHAINICIO]),Convert.ToDateTime(Page.Request.QueryString[KEYFECHAFIN]));

			if(dtVentasPorClientePorCOyLN!=null)
			{
				DataTable dtImpresion = dtVentasPorClientePorCOyLN.Copy();
				dtImpresion.TableName = TablaImpresion0;

				DataView dwVentas =	dtVentasPorClientePorCOyLN.DefaultView;
				dwVentas.Sort = columnaOrdenar ;
				dwVentas.RowFilter = Helper.ObtenerFiltro(this);
				
				if(dwVentas.Count > POSICIONINICIALCOMBO)
				{
					grid.DataSource	= dwVentas;
					grid.CurrentPageIndex = indicePagina;
					Double [] x =  Helper.TotalizarDataView(dwVentas,TEXTOTOTAL);
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = x[Constantes.POSICIONCONTADOR].ToString(Utilitario.Constantes.FORMATODECIMAL4);
					lblResultado.Visible = false;
					dsImprimir.Tables.Add(dtImpresion);

				}
				else
				{
					grid.DataSource	= null;
					lblResultado.Visible = true;
					lblResultado.Text =	GRILLAVACIA;
				}			
			}
			else
			{
				grid.DataSource	= dtVentasPorClientePorCOyLN;
				lblResultado.Visible = true;
				lblResultado.Text =	GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch(Exception	ex)
			{
				string a = ex.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
	
			//Grilla Historica de Ventas 
			DataTable dtHistoricoVentasPorClientePorCOyLN = oCCliente.HistoricoMontosVentasPorClientePorCOyLN(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Convert.ToInt32(Page.Request.QueryString[KEYQCO]),Convert.ToInt32(Page.Request.QueryString[KEYQLN]));
			if(dtHistoricoVentasPorClientePorCOyLN != null)
			{
				DataTable dtImpresion1 = dtHistoricoVentasPorClientePorCOyLN.Copy();
				dtImpresion1.TableName = TablaImpresion1;

				DataView dwHistoricoVentas = dtHistoricoVentasPorClientePorCOyLN.DefaultView;
				
				if(dwHistoricoVentas.Count > POSICIONINICIALCOMBO)
				{
					dgConsulta.DataSource	= dwHistoricoVentas;
					montos = new double[dtHistoricoVentasPorClientePorCOyLN.Columns.Count];
					anchos = this.CalcularAnchos(dtHistoricoVentasPorClientePorCOyLN);
					dgConsulta.Width = this.CalcularAnchoTotal(anchos);
					dsImprimir.Tables.Add(dtImpresion1);
				}
				else
				{
					dgConsulta.DataSource	= null;
				}			
			}
			else
			{
				dgConsulta.DataSource	= dtHistoricoVentasPorClientePorCOyLN;
			}
 
			try
			{
				dgConsulta.DataBind();
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dsImprimir,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Mensajes.CODIGOTITULOVENTASREALESPORCLIENTEPORCOyLN));

			}
			catch(Exception	ex)
			{
				string a = ex.Message;
				dgConsulta.CurrentPageIndex = 0;
				dgConsulta.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarDetalleMontoClientePorCOyLN.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblNombreRazonSocial.Text = Page.Request.QueryString[KEYQNOMBRE].ToUpper();
		}

		public void LlenarJScript()
		{
			this.ibtnAstillero.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnAstillero.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE);

			this.ibtnLineaNegocio.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnLineaNegocio.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE);

		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarDetalleMontoClientePorCOyLN.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION + KEYQNOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE].ToString(),780,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarDetalleMontoClientePorCOyLN.Exportar implementation
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
			// TODO:  Add ConsultarDetalleMontoClientePorCOyLN.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnLineaNegocio_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text =  Helper.MostrarVentana(URLMONTOClIENTEPORLN, KEYQID + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQID].ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
																		   KEYQNOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE].ToString());
		}

		private void ibtnAstillero_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.MostrarVentana(URLMONTOClIENTEPORCO, KEYQID + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.QueryString[KEYQID].ToString() + Utilitario.Constantes.SIGNOAMPERSON + 
																		  KEYQNOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE].ToString());
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Cells[PosicionMonto].Text = Convert.ToDouble(e.Item.Cells[PosicionMonto].Text).ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}

		private void dgConsulta_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[Constantes.POSICIONCONTADOR].Width = anchos[Constantes.POSICIONCONTADOR];
				e.Item.Cells[Constantes.POSICIONCONTADOR].HorizontalAlign = HorizontalAlign.Left;
				for(int i=1;i<e.Item.Cells.Count;i++)
				{
					montos[i] = montos[i] + Convert.ToDouble(e.Item.Cells[i].Text);
					e.Item.Cells[i].Width = anchos[i];
					e.Item.Cells[i].HorizontalAlign = HorizontalAlign.Right;
					e.Item.Cells[i].Text = Convert.ToDouble(e.Item.Cells[i].Text).ToString(Constantes.FORMATODECIMAL4);
				}

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}

		private int[] CalcularAnchos(DataTable dt)
		{
			int [] array = new int[dt.Columns.Count];
			array[Constantes.POSICIONCONTADOR] = ANCHO;
			for(int i=1; i<dt.Columns.Count;i++)
			{
				array[i] = dt.Columns[i].ColumnName.Length;
				for(int j=0;j<dt.Rows.Count;j++)
				{
					if(dt.Rows[j][i].ToString().Length > array[i])
					{
						array[i] = dt.Rows[j][i].ToString().Length;
					}
				}
			}
			for(int k=1;k<array.Length;k++)
			{
				array[k] *= MULTIPLO;
			}
			return array;
		}

		private int CalcularAnchoTotal(int[] ancho)
		{
			int MontoTotal = 0;
			foreach(int i in ancho)
			{
				MontoTotal += i;
			}

			return MontoTotal;
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

	}
}
