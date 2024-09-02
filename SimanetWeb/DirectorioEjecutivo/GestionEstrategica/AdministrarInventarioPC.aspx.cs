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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.ManejadorTransaccion;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	/// <summary>
	/// Summary description for AdministrarInventarioPC.
	/// </summary>
	public class AdministrarInventarioPC : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridIndex;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD1;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD2;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD3;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD4;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD5;
		protected System.Web.UI.HtmlControls.HtmlGenericControl P2;
		protected System.Web.UI.HtmlControls.HtmlGenericControl P3;
		protected System.Web.UI.WebControls.ImageButton ImageButton2;
		#endregion
		
		#region Constantes
		private const string URLDETALLE="DetalleInventarioPC.aspx?";
		const string KEYIDINVENTARIOPC= "IdInventarioPC";
		const string PAGINAFILTRO = "../../../Filtros.aspx";
		private const string URLIMPRESION="PopupImpresionInventarioPC.aspx?";
		const string INDICEPAGINA = "hGridPagina";
		const string PAGINASORT = "hGridPaginaSort";
		const string ORDENAMIENTO = "PROCESADOR";
		const string GRILLAVACIA ="No hay datos";  
		const string IMAGENALERTA ="../../imagenes/alert.gif";
		const string CONTROLIMGCADUCA = "imgCaducidad";
		const string KEYQPROCESADOR ="IDPROCESADOR";
		const string KEYQCO ="IDCENTROOPERATIVO";
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				try
				{
					hGridPaginaSort.Value = ORDENAMIENTO;
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();

					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Estrategica",this.ToString(),"Se consultó Gestion Estrategica.",Enumerados.NivelesErrorLog.I.ToString()));

					Helper.ReestablecerPagina(this);
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
			this.ibtnFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltro_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.hGridPagina.Value = Utilitario.Constantes.ValorConstanteCero.ToString();
			this.hGridPaginaSort.Value = Utilitario.Constantes.VACIO;
			
			Page.Response.Redirect(URLDETALLE + Utilitario.Constantes.KEYMODOPAGINA +
				Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Transaccion oTransaccion = null;

			if(hGridIndex.Value == string.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert("Debe seleccionar un registro");
			}
			else
			{
				CInventarioPC oCInventarioPC = new CInventarioPC();

				if(oCInventarioPC.Eliminar(Convert.ToInt32(hGridIndex.Value),CNetAccessControl.GetIdUser(), oTransaccion)>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Estrategico",this.ToString(),"Se eliminó la pc del inventario: " + hGridIndex.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
				
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
						
					ltlMensaje.Text = Helper.MensajeAlert("Se ha eliminado correctamente");
				}
			}				
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarInventarioPC.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarInventarioPC.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CInventarioPC oCInventarioPC = new CInventarioPC();
			return oCInventarioPC.ListarInventarioPC(-1,-1);
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtInventario = this.ObtenerDatos();
	
			if(dtInventario!=null)
			{
				DataView dwInventario = dtInventario.DefaultView;
				dwInventario.Sort = columnaOrdenar ;
				dwInventario.RowFilter = Helper.ObtenerFiltro(this);
				if(dwInventario.Count>0)
				{
					grid.DataSource = dwInventario;
					grid.CurrentPageIndex = indicePagina;
					grid.Columns[2].FooterText = dwInventario.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				
			}
			else
			{
				grid.DataSource = dtInventario;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtInventario,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTECONTRATOS),columnaOrdenar,indicePagina);
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
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
			// TODO:  Add AdministrarInventarioPC.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarInventarioPC.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA,PAGINASORT));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarInventarioPC.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,780,500,false,false,false,true,true);	
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarInventarioPC.Exportar implementation
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
			// TODO:  Add AdministrarInventarioPC.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hGridIndex",dr[Enumerados.ColumnasInventarioPC.IDINVENTARIOPC.ToString()].ToString()));

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA,PAGINASORT) +
					Utilitario.Constantes.POPUPDEESPERA +
					Helper.MostrarVentana(URLDETALLE,
					KEYIDINVENTARIOPC + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasInventarioPC.IDINVENTARIOPC.ToString()]) +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()));
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor=Color.Blue;
			
				System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[7].FindControl(CONTROLIMGCADUCA);
				if (Convert.ToInt32(dr[Enumerados.ColumnasInventarioPC.SINCONTRATO.ToString()])!= Constantes.ValorConstanteUno)
				{
					grid.Columns[7].Visible = true;
					ibtn1.ImageUrl = IMAGENALERTA;
				}
				else
				{
					ibtn1.Visible = false;
					grid.Columns[7].Visible = false;
				}				 

				Helper.FiltroporSeleccionConfiguraColumna(e,grid);				
			}
		}

		private void ibtnFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos(),PAGINAFILTRO
				,Utilitario.Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasInventarioPC.PROCESADOR.ToString()+"; Procesador"
				,Utilitario.Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasInventarioPC.CO.ToString()+"; Centro Operativo"
				,Utilitario.Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasInventarioPC.AREA.ToString()+"; Área"
				,Utilitario.Enumerados.ColumnasInventarioPC.RESPONSABLE.ToString()+ ";Responsable"
				,Utilitario.Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasInventarioPC.TIPO.ToString()+"; Tipo");
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

	}
}
