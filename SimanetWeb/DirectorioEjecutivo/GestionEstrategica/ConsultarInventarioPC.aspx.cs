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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.EntidadesNegocio;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial.InventarioPC
{
	/// <summary>
	/// Summary description for ConsultarInventarioPC.
	/// </summary>
	public class ConsultarInventarioPC : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnGraficoCPUProcesador;
		protected System.Web.UI.WebControls.ImageButton ibtnGraficoCPULicenciatura;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Label lblTitulo;	
		#endregion	

		#region Constantes
		const string GRILLAVACIA ="No existe ningun valor.";
		//Paginas
		private const string URLIMPRESION="PopupImpresionInventarioPC.aspx?";
		private const string URLDETALLE="DetalleInventarioPC.aspx?";

		const string URLRCANTIDADPROCESADORPORTIPO = "../Reportes/GraficoCantidadProcesadorPorTipo.aspx";
		const string URLRCANTIDADLICENCIATURA = "../Reportes/GraficoCantidadLicenciatura.aspx";
		const string KEYIDINVENTARIOPC= "IdInventarioPC";
		const string KEYQPROCESADOR ="IDPROCESADOR";
		const string KEYQCO ="IDCENTROOPERATIVO";
		#endregion

		#region Variables
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
					//Graba	en el Log la acción	ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial- Ventas",this.ToString(),"Se	consultó los Montos de Ventas Presupuestadas.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text	= Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text	= Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					ltlMensaje.Text	= Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception	oException)
				{
					SIMAExcepcionIU	oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
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
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnGraficoCPUProcesador.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGraficoCPUProcesador_Click);
			this.ibtnGraficoCPULicenciatura.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGraficoCPULicenciatura_Click);
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
			// TODO:  Add ConsultarInventarioPC.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarInventarioPC.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CInventarioPC oCInventarioPC = new CInventarioPC();
			return oCInventarioPC.ListarInventarioPC(Convert.ToInt32(Page.Request.QueryString[KEYQCO]),Convert.ToInt32(Page.Request.QueryString[KEYQPROCESADOR]));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtInventario = this.ObtenerDatos();

			if(dtInventario!=null)
			{
				DataView dwInventario = dtInventario.DefaultView;
				dwInventario.Sort = columnaOrdenar ;
				dwInventario.RowFilter = Utilitario.Helper.ObtenerFiltro();//Helper.ObtenerFiltro(this);
				if(dwInventario.Count>0)
				{
					grid.DataSource = dwInventario;
					grid.Columns[2].FooterText = dwInventario.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
					ibtnGraficoCPUProcesador.Visible = false;
					ibtnGraficoCPULicenciatura.Visible = false;
				}
				
			}
			else
			{
				grid.DataSource = dtInventario;
				lblResultado.Text = GRILLAVACIA;
				ibtnGraficoCPUProcesador.Visible = false;
				ibtnGraficoCPULicenciatura.Visible = false;
			}
			
			try
			{
				grid.CurrentPageIndex=indicePagina;
				grid.DataBind();
			}
			catch(Exception oException)
			{
				string error = oException.Message.ToString();
				grid.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarInventarioPC.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarInventarioPC.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnGraficoCPULicenciatura.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnGraficoCPULicenciatura.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);

			this.ibtnGraficoCPUProcesador.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnGraficoCPUProcesador.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarInventarioPC.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,780,500,false,false,false,true,true);	
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarInventarioPC.Exportar implementation
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
			// TODO:  Add ConsultarInventarioPC.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
//			CMantenimientos oCMantenimientos =  new CMantenimientos();
//			DataTable dtInventarioPC =  oCMantenimientos.ListarTodosGrilla(Enumerados.ClasesNTAD.InventarioPcNTAD.ToString());
						
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,Constantes.SIGNOASTERISCO  + "PROCESADOR"+ ";Tipo de Procesador"
				,Constantes.SIGNOASTERISCO  + "RESPONSABLE"+";Responsable"
				,Constantes.SIGNOASTERISCO  + "TIPO"+";Por Tipo de PC"
				,Constantes.SIGNOASTERISCO  + "CO"+";Por Centro Operativo"
				,Constantes.SIGNOASTERISCO  + "AREA"+";Por Area"
				,Constantes.SIGNOASTERISCO  + "ESTADO"+";Tipo de Estado"
				);
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYIDINVENTARIOPC + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasInventarioPC.IDINVENTARIOPC.ToString()]) +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()));
	
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor=Color.Blue;
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasInventarioPC.IDINVENTARIOPC.ToString()].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);				
			}
		}

		
		private void ibtnGraficoCPULicenciatura_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLRCANTIDADLICENCIATURA);
		}

		private void ibtnGraficoCPUProcesador_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLRCANTIDADPROCESADORPORTIPO);
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
	}
}
