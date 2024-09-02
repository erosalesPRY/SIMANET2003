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

namespace SIMA.SimaNetWeb.GestionComercial.Promotores
{
	/// <summary>
	/// Summary description for DetalleConsultarPromotoresPorVentas.
	/// </summary>
	public class DetalleConsultarPromotoresPorVentas : System.Web.UI.Page
	{

		#region Controles
		//Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.TextBox txtTrabajoEfectuado;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.HyperLink hlkContratos;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.HyperLink hlkId;
		#endregion	

		#region Constantes
		//Total de Registros 
		//Ordenamiento
		const string COLORDENAMIENTO = "IDPROMOTOR";
		const string CONTROLINK = "hlkId";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQTIPO = "Tipo";
		const string KEYQIDTIPO = "IdTipo";
		const string KEYQDESCRIPCIONTIPO="Tipo";

		//Otros
		const string GRILLAVACIA ="No existe ningún Contrato.";
		const string TEXTOFOOTERTOTAL = "Total:";
		const int POSICIONFOOTERTOTAL = 1;
		const int POSICIONINICIALCOMBO = 0;

		//JScript

		//Paginas
		const string URLDETALLE = "";
		const string URLPROYECTOS = "";
		const string URLADENDAS = "";
		const string URLPRINCIPAL = "";
		const string URLIMPRESION = "";
		#endregion

		#region Variables
			int REGISTROACTUAL;
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

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultaron Promotores por venta.",Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
					
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleConsultarPromotoresPorVentas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleConsultarPromotoresPorVentas.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			DataTable dtPromotor = new DataTable();
			CPromotores oCPromotores = new CPromotores();
			return oCPromotores.DetalleListarPromotoresPorTipo(Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPO]));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtPromotor = ObtenerDatos();
			if(dtPromotor!=null)
			{
				DataView dwPromotor = dtPromotor.DefaultView;
				dwPromotor.Sort = COLORDENAMIENTO ;
				dwPromotor.RowFilter= Utilitario.Helper.ObtenerFiltro(this);

				if (dwPromotor.Count == 0)
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
				}
				else
				{
					grid.DataSource = dwPromotor;
					grid.Columns[0].FooterText = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwPromotor.Count.ToString();
					lblResultado.Visible = false;

					CImpresion oCImpresion = new CImpresion();
					oCImpresion.GuardarDataImprimirExportar(dtPromotor,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTECONTRATOS)+ Utilitario.Constantes.ESPACIO + this.lblTitulo.Text,columnaOrdenar,indicePagina);
				}
			}
			else
			{
				grid.DataSource = dtPromotor;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
			}

			if(indicePagina==0)
			{
				REGISTROACTUAL=0;
			}
			else
			{
				REGISTROACTUAL=(indicePagina * grid.PageSize);
			}

			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;				
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleConsultarPromotoresPorVentas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleConsultarPromotoresPorVentas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DetalleConsultarPromotoresPorVentas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleConsultarPromotoresPorVentas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add DetalleConsultarPromotoresPorVentas.Exportar implementation
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

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				HyperLink hlk = (HyperLink)e.Item.Cells[1].FindControl(CONTROLINK);
				hlk.Text = Convert.ToString(dr[Enumerados.ColumnasPromotor.IdPromotor.ToString()]);
				hlk.NavigateUrl = URLDETALLE +  KEYQIDTIPO + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToInt32(dr[Enumerados.ColumnasPromotor.IdPromotor.ToString()]) +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQDESCRIPCIONTIPO + Utilitario.Constantes.SIGNOIGUAL + 
					hlk.Text;
			}	
		}
	}
}
