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
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.LineasdeCredito
{
	/// <summary>
	/// Summary description for ConsultarLineasdeCredito.
	/// </summary>
	public class ConsultarLineasdeCredito : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		
		const string  GRILLAVACIA="No existe";
		//Ordenamiento
		const string COLORDENAMIENTO = "nombreentidad";

		//Nombres de Controles
		const string CONTROLINK = "hlkBanco";

		//Paginas
		const string URLDETALLE = "ConsultarLineasdeCreditoporBanco.aspx?";
		const string URLPRINCIPAL = "../../Default.aspx";
		
		//Key Session y QueryString
		//const string KEYQID = "idEntidadFin";
		//const string KEYQNOMBREBCO ="NombreBco";

		const string KEYIDENTIDADFINANCIERA = "idEF";
		const string NOMBREENTIDAD = "Nombre";
		const string KEYIDESTADO = "idEstado";
		


		const string KEYQMONTO = "MntAprob";
		private ASPNetDatagridDecorator m_add = new ASPNetDatagridDecorator();

		//DataGrid and DataTable
		const string COLUMNANRO ="NRO";
		const string COLUMNAENTIDADFINANCIERA ="ENTIDAD FINANCIERA";
		const string COLUMNAMONTODOLARIZADO ="MONTOS DOLARIZADOS";
		const string COLUMNASITUACION ="SITUACIÓN";
		const string NOMBREDATATABLE ="MyDataTable";		
		const string COLUMNANOMBRE ="Nombre";
		const string COLUMNAAUTORIZADO ="Autorizado";
		const string COLUMNAUTILIZADO ="Utilizado";
		const string COLUMNADISPONIBLE ="Disponible";
		const string TEXTOTOTAL ="TOTAL :";
		const string NOMBRETIPOINT32 ="System.Int32";
		const string NOMBRETIPOSTRING ="System.String";

		//DataView
		const string COLUMNAMONTOAUTORIZDOLAR ="MontoAutorizadoEnDolar";
		const string COLUMNAUTILIZADOALCAMBIODOLAR ="UtilizadoAlCambioDelDolar";
		const string COLUMNADISPONIBLEDOLAR ="DisponibleEnDolar";

		//Otros
		const string TITULOTOTAL ="TOTAL";

		#endregion
		#region Variables
			const string TITULO="TOTAL :";
			double Autorizado=0;
			double Utilizado=0;
			double Disponible=0;

		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
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
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Constantes.INDICEPAGINADEFAULT);
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
			// Put user code to initialize the page here
		}
		private void ColspanRowspanHeader()
		{
			TableCell cell = null;
			m_add.DatagridToDecorate = grid;
			ArrayList header = new ArrayList();


			cell = new TableCell();
			cell.Text = COLUMNANRO;
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = COLUMNAENTIDADFINANCIERA;
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = COLUMNAMONTODOLARIZADO;
			cell.ColumnSpan = 3;
			cell.HorizontalAlign = HorizontalAlign.Center;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = COLUMNASITUACION;
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			m_add.AddMergeHeader(header);
			
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
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemCreated);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		public void LlenarGrillas(System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			DataTable myDataTable = new DataTable(NOMBREDATATABLE);
   
			// Declare DataColumn and DataRow variables.
			DataColumn myDataColumn;
			DataRow myDataRow;

			myDataColumn = new DataColumn();
				
			//PRIMERA COLUMNA
			myDataColumn.DataType = Type.GetType(NOMBRETIPOSTRING);
			myDataColumn.ColumnName = COLUMNANOMBRE;
			myDataTable.Columns.Add(myDataColumn);

			//SEGUNDA COLUMNA
			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType(NOMBRETIPOINT32);
			myDataColumn.ColumnName = COLUMNAAUTORIZADO;
			myDataTable.Columns.Add(myDataColumn);

			//TERCERA COLUMNA
			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType(NOMBRETIPOINT32);
			myDataColumn.ColumnName = COLUMNAUTILIZADO;
			myDataTable.Columns.Add(myDataColumn);

			//CUARTA COLUMNA
			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType(NOMBRETIPOINT32);
			myDataColumn.ColumnName = COLUMNADISPONIBLE;
			myDataTable.Columns.Add(myDataColumn);


			myDataRow = myDataTable.NewRow();
			myDataRow[COLUMNANOMBRE] = TITULO;
			myDataRow[COLUMNAAUTORIZADO] = Autorizado;
			myDataRow[COLUMNAUTILIZADO] = Utilizado;
			myDataRow[COLUMNADISPONIBLE] = Disponible;
			myDataTable.Rows.Add(myDataRow);

			e.Item.Cells[0].Text =TEXTOTOTAL;
			e.Item.Cells[0].ColumnSpan=2;
			e.Item.Cells[1].Visible = false;

			e.Item.Cells[2].Text = Convert.ToDouble(myDataTable.Rows[0][1]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			e.Item.Cells[3].Text = Convert.ToDouble(myDataTable.Rows[0][2]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			e.Item.Cells[4].Text = Convert.ToDouble(myDataTable.Rows[0][3]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			// TODO:  Add ConsultarLineasdeCredito.LlenarGrilla implementation
		}


		#region IPaginaBase Members
		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarLineasdeCredito.LlenarGrillaOrdenamiento implementation
		}
		
		private void Totaliza(DataView dv)
		{
			ArrayList arrTotal = new ArrayList();
			arrTotal.Add((double) Helper.TotalizarDataView(dv,COLUMNAMONTOAUTORIZDOLAR)[0]);
			arrTotal.Add((double) Helper.TotalizarDataView(dv,COLUMNAUTILIZADOALCAMBIODOLAR)[0]);
			arrTotal.Add((double) Helper.TotalizarDataView(dv,COLUMNADISPONIBLEDOLAR)[0]);
			Session[Utilitario.Constantes.STOTALIZAR] = arrTotal;			
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			this.ColspanRowspanHeader();
			DataTable dtGeneral = ((CLineaCredito) new CLineaCredito()).ConsultarLineadeCreditoPorBanco(Utilitario.Constantes.IDDEFAULT);
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				this.Totaliza(dwGeneral);
				dwGeneral.Sort = columnaOrdenar ;
				grid.DataSource = dwGeneral;
				ibtnImprimir.Visible = true;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				ibtnImprimir.Visible = false;
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
			
			// TODO:  Add ConsultarLineasdeCredito.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarLineasdeCredito.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarLineasdeCredito.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarLineasdeCredito.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarLineasdeCredito.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarLineasdeCredito.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarLineasdeCredito.Exportar implementation
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
			// TODO:  Add ConsultarLineasdeCredito.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			e.Item.Cells[2].Style.Add("Width","20%");
			e.Item.Cells[3].Style.Add("Width","20%");
			e.Item.Cells[4].Style.Add("Width","20%");
			e.Item.Cells[5].Style.Add("Width","20%");

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLDETALLE,KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaLineaCredito.identidadfinanciera.ToString()].ToString()
																												+ Utilitario.Constantes.SIGNOAMPERSON
																												+ KEYQMONTO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaLineaCredito.MontoAutorizadoEnDolar.ToString()].ToString()
																												+ Utilitario.Constantes.SIGNOAMPERSON
																												+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaLineaCredito.nombreentidad.ToString()].ToString()
																												+ Utilitario.Constantes.SIGNOAMPERSON
																												+ KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDESTADODEFAULT.ToString()));
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN ,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ForeColor = Color.Blue;
				
				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text = Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[4].Text = Convert.ToDouble(e.Item.Cells[4].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				e.Item.Cells[2].Text=Helper.FormateaNumeroNegativo(2,e.Item);
				e.Item.Cells[3].Text=Helper.FormateaNumeroNegativo(3,e.Item);
				e.Item.Cells[4].Text=Helper.FormateaNumeroNegativo(4,e.Item);
				
				//Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

			}	
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[0].Text =TITULOTOTAL;
				e.Item.Cells[0].ColumnSpan=2;e.Item.Cells[1].Visible=false;
				ArrayList arrTotal = (ArrayList) Session[Utilitario.Constantes.STOTALIZAR];
				e.Item.Cells[2].Text= Convert.ToDouble(arrTotal[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
				e.Item.Cells[3].Text= Convert.ToDouble(arrTotal[1]).ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
				e.Item.Cells[4].Text= Convert.ToDouble(arrTotal[2]).ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());

			}
			
		}
		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Footer) 
			{ 
				//this.LlenarGrillas(e);
			} 					
		}
	}
}
