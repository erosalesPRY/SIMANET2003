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

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Gestion_Estrategica
{
	/// <summary>
	/// Summary description for ConsultaAlineamientoEstrategico.
	/// </summary>
	public class ConsultaAlineamientoEstrategico : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblTitulo1;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		#endregion Controles

		#region Constantes

		//Ordenamiento
		const string COLORDENAMIENTO = "IDOGENERALES";
		const int COLUMNANUMERACION = 0;

		//URLS
		const string URLDETALLEALINEAMIENTOESTRATEGICO = "DetalleConsultaAlineamientoEstrategico.aspx?";

		//INDICES
		const string KEYQIDOGENERAL = "IDOGENERALES";
		const string KEYOGENERALTEXTO = "DESCRIPCION";


		//OTROS
		const string TEXTOFOOTERTOTAL = "Total:";
		const int POSICIONFOOTERTOTAL = 1;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionEstrategica",this.ToString(),"Se consulto el Modulo Gestion Estrategico.",Enumerados.NivelesErrorLog.I.ToString()));

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
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

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

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
		
				e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLEALINEAMIENTOESTRATEGICO, 
					KEYQIDOGENERAL + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]) +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYOGENERALTEXTO + Utilitario.Constantes.SIGNOIGUAL +
					Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()])));

				#region Helpers
				e.Item.Cells[0].Text = Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]);
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Font.Underline = true;
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);	
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				#endregion
			}
		}

		#region IPaginaBase Members

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

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			CObjetivoGeneral oCObjetivoGeneral =  new CObjetivoGeneral();
			DataTable dtOGeneral =  oCObjetivoGeneral.ListarObjetivoGeneral();
			
			if(dtOGeneral!=null)
			{
				DataView dwOGeneral = dtOGeneral.DefaultView;
				grid.DataSource = dwOGeneral;
				dwOGeneral.RowFilter = Helper.ObtenerFiltro(this);

				if (dwOGeneral.Count == 0)
				{
					grid.DataSource = null; 
				}
				else
				{
					grid.DataSource = dwOGeneral;
					grid.Columns[0].FooterText = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwOGeneral.Count.ToString();
				}
			}
			else
			{
				grid.DataSource = dtOGeneral;
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

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultaAlineamientoEstrategico.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultaAlineamientoEstrategico.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultaAlineamientoEstrategico.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultaAlineamientoEstrategico.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaAlineamientoEstrategico.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaAlineamientoEstrategico.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultaAlineamientoEstrategico.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaAlineamientoEstrategico.Exportar implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultaAlineamientoEstrategico.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
