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
using SIMA.Controladoras.Proyectos;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Proyectos
{
	public class ConsultarOC_PorOT : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string COLORDENAMIENTO = "COD_RCS";

		const string KEYFLAGLN_CO = "LN_CO";
		
		const string KEYIDPROYECTO = "COD_PROYECTO";
		const string KEYPROYECTO = "PROYECTO";
		const string KEYIDOT = "IDOT";		
		const string KEYOT = "OT";

		//Otros

		#endregion
		#region Controles

		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;

		ArrayList arrTotaliza;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"O/C",this.ToString(),"Se consultaron Ordenes de Compra",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarCabecera();
					Helper.ReestablecerPagina(this);
					this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarCartaCreditoResumendeBancosporCentro.LlenarGrilla implementation
		}

		public void LlenarCabecera()
		{
			lblTitulo.Text = Page.Request[KEYPROYECTO].ToString().ToUpper() + Utilitario.Constantes.SEPARADORLINEA + Page.Request[KEYOT].ToString().ToUpper();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}

		private DataTable ObtenerDatos()
		{
			CProyectos oCProyectos= new CProyectos();
			DataTable dtGeneral =oCProyectos.ConsultarOrdenesCompra_PorOT(Page.Request.Params[KEYIDOT].ToString());
			return dtGeneral;
		}
		private void Totaliza(DataView dv)
		{
			arrTotaliza = new ArrayList();
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_ORDENESCOMPRA.CNT_REQ_OT.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_ORDENESCOMPRA.CNT_ATE_OT.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_ORDENESCOMPRA.TOT_OCO.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_ORDENESCOMPRA.TOT_SOLES.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_ORDENESCOMPRA.CNT_RCP.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_ORDENESCOMPRA.CNT_ALM.ToString() + ")",dv.RowFilter.ToString()));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.Sort = columnaOrdenar ;
				dwGeneral.RowFilter = Helper.ObtenerFiltro();
				this.Totaliza(dwGeneral);
				grid.DataSource = dwGeneral;
				grid.CurrentPageIndex = indicePagina;
				grid.Columns[Utilitario.Constantes.POSICIONINDEXDOS].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();

				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch(Exception oException)
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}												
		}

		public void LlenarCombos()
		{
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
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
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}	
		}

		public bool ValidarFiltros()
		{
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			#region ITEM
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
		
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);			
			}	
			#endregion

			#region FOOTER
			if(e.Item.ItemType == ListItemType.Footer)
			{
				if (arrTotaliza.Count > 0)
				{
					e.Item.Cells[6].Text = Convert.ToDouble(arrTotaliza[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[7].Text = Convert.ToDouble(arrTotaliza[1]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[12].Text = Convert.ToDouble(arrTotaliza[2]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[13].Text = Convert.ToDouble(arrTotaliza[3]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[14].Text = Convert.ToDouble(arrTotaliza[4]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[15].Text = Convert.ToDouble(arrTotaliza[5]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}
			}		
			#endregion
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();				
		}
	}
}
