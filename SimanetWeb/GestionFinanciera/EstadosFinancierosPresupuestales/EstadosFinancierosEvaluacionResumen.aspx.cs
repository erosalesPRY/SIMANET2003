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

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancierosPresupuestales
{
	/// <summary>
	/// Summary description for EstadosFinancierosEvaluacionResumen.
	/// </summary>
	public class EstadosFinancierosEvaluacionResumen : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		//Key Session y QueryString
		const string KEYQIDEMPRESA = "idEmp";
		const string KEYQIDCENTRO = "idCentro";
		const string NOMBRECENTRO ="NombreCentro";
		//Tipo de Opcion Contable o Presupuestal
		const string KEYIDTIPOOPCION ="idOpcion";
		const string NOMBRETIPOOPCION ="NombreOpcion";
		const string KEYQIDFECHA = "efFecha";

		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDNOMBREFORMATO = "NFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQIDPERIDO = "Periodo";
		const string KEYQIDMES = "Mes";
		const string KEYQIDNOMBREMES = "NombreMes";

		const string KEYQNRODIGITOS ="NroDig";
		const string KEYQDIGCUENTA = "DigCuenta";

		const string CONTROLINK = "hlkConcepto";

		const string CAMPO1 = "lblMontoAcumuladoPPTO";
		const string CAMPO2 = "lblMontodelMesPPTO";
		const string CAMPO3 = "lblMontoAcumuladoReal";
		const string CAMPO4 = "lblMontoDelMesReal";
		const string CAMPO5 = "lblMontoAcumuladoVar";
		const string CAMPO6 = "lblMontoDelMesVar";

					

		//Campos de Cabecera
		const string CAMPOH1 = "LblAlMesT";
		const string CAMPOH2 = "lblDelMesT";
		const string CAMPOH3 = "lblPPTOalT";
		const int NRODIGINI = 2;
		const int DIGCTA = 0;
			

		const string CONTROLIMAGE = "imgVerDetalle";
		const string GRILLAVACIA="No existe";

		//URL
		const string URLDETALLECOMPARATIVO = "EstadosFinancierosEvaluacion.aspx?";
		const string URLFORMATOFORMULACION = "EstadosFinancierosFormulacion.aspx?";

		//DataGrid and DataTable
		const string TITULOCONCEPTO ="CONCEPTO";
		const string TITULOPTOPERIODOENERO ="PRESUPUESTO PERIODO  ENERO / ";
		const string TITULODEL =" DEL ";

		const string TITULOPROYDICIEMBRE ="PROYECTADO DICIEMBRE ";

		//Otros
		const string PERIODO ="Periodo";

		private ASPNetDatagridDecorator m_add = new ASPNetDatagridDecorator();
		#endregion
		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label Label1;
			protected System.Web.UI.WebControls.Label Label2;
			protected System.Web.UI.WebControls.DropDownList dddblMes;
			protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlbEmpresa;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					
					this.LlenarDatos();
					this.LlenarGrilla();
				}				
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
			// Put user code to initialize the page here
		}

		private void ColspanRowspanHeader()
		{

			DateTime Fecha = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(this.ddlbPeriodo.SelectedValue.ToString()) ,Convert.ToInt32(this.dddblMes.SelectedValue.ToString())).ToString() + Utilitario.Constantes.SEPARADORFECHA + this.dddblMes.SelectedValue.ToString().PadLeft(2,'0') + Utilitario.Constantes.SEPARADORFECHA + this.ddlbPeriodo.SelectedValue.ToString().PadLeft(2,'0'));
			TableCell cell = null;
			m_add.DatagridToDecorate = grid;
			ArrayList header = new ArrayList();


			cell = new TableCell();
			cell.Text = TITULOCONCEPTO;
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = TITULOPTOPERIODOENERO + this.dddblMes.SelectedItem.Text.ToUpper() + TITULODEL + Fecha.Year.ToString();
			cell.ColumnSpan = 5;
			cell.HorizontalAlign = HorizontalAlign.Center;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = String.Empty;
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = TITULOPROYDICIEMBRE + Fecha.Year.ToString() ;
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
			this.ddlbPeriodo.SelectedIndexChanged += new System.EventHandler(this.ddlbPeriodo_SelectedIndexChanged);
			this.dddblMes.SelectedIndexChanged += new System.EventHandler(this.dddblMes_SelectedIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			this.ColspanRowspanHeader();

			CEstadoFinancieroPresupuestal oCEstadoFinancieroPresupuestal = new CEstadoFinancieroPresupuestal();

			DataTable dtEstadoFinanciero = oCEstadoFinancieroPresupuestal.ConsultarEstadosFinancierosPresupuestalEvaluacionResumen(
				Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE])
				,Utilitario.Constantes.IDDEFAULT
				,Convert.ToInt32(this.ddlbPeriodo.SelectedValue)
				,Convert.ToInt32(this.dddblMes.SelectedValue)
				,Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA])
				,Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO]));
				///,this.ddlbEmpresa.SelectedValue.ToString());
			
			if(dtEstadoFinanciero!=null)
			{
				grid.DataSource = dtEstadoFinanciero;
			}
			else
			{
				grid.DataSource = dtEstadoFinanciero;
				//lblResultado.Text = GRILLAVACIA;

			}
			grid.DataBind();			
			// TODO:  Add EstadosFinancierosEvaluacionResumen.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add EstadosFinancierosEvaluacionResumen.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add EstadosFinancierosEvaluacionResumen.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.LlenarPeriodoContable();
			// TODO:  Add EstadosFinancierosEvaluacionResumen.LlenarCombos implementation
		}
		private void LlenarPeriodoContable()
		{
			CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			ddlbPeriodo.DataSource = oCPeriodoContable.ListarPeriodo();
			ddlbPeriodo.DataValueField=PERIODO;
			ddlbPeriodo.DataTextField=PERIODO;
			ddlbPeriodo.DataBind();
			if((Page.Request.Params[Utilitario.Constantes.KeyQPaginaValorInicial] != null)  && Page.Request.Params[Utilitario.Constantes.KeyQPaginaValorInicial].ToString() == Utilitario.Constantes.KeyQPaginaValor)
			{
				ListItem item;
				item = ddlbPeriodo.Items.FindByText(DateTime.Now.Year.ToString());
				if (item !=null){item.Selected = true;}

				item = dddblMes.Items.FindByValue(DateTime.Now.Month.ToString());
				if (item !=null){item.Selected = true;}
			}	
			else
			{
				Helper.SeleccionarItemCombos(this);
			}
			
		}
		public void LlenarDatos()
		{
			lblPagina.Text = Page.Request.Params[NOMBRETIPOOPCION].ToString() + Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOMAYOR +  Page.Request.Params[NOMBRECENTRO].ToString() + Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOMAYOR + Utilitario.Constantes.ESPACIO +  Page.Request.Params[KEYQIDNOMBREFORMATO].ToString();
			// TODO:  Add EstadosFinancierosEvaluacionResumen.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add EstadosFinancierosEvaluacionResumen.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add EstadosFinancierosEvaluacionResumen.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add EstadosFinancierosEvaluacionResumen.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add EstadosFinancierosEvaluacionResumen.Exportar implementation
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
			// TODO:  Add EstadosFinancierosEvaluacionResumen.ValidarFiltros implementation
			return false;
		}

		#endregion
		private string  ParametrosPaginaDesviacion(DateTime Fecha)
		{
			//DateTime Fecha = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(this.ddlbPeriodo.SelectedValue.ToString()) ,Convert.ToInt32(this.dddblMes.SelectedValue.ToString())).ToString() + "/" + this.dddblMes.SelectedValue.ToString().PadLeft(2,'0') + "/" + this.ddlbPeriodo.SelectedValue.ToString().PadLeft(2,'0'));
			string qryPagina = KEYQIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDEMPRESA].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDCENTRO].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[NOMBRECENTRO].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYIDTIPOOPCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOOPCION].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ NOMBRETIPOOPCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[NOMBRETIPOOPCION].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ Utilitario.Constantes.KeyQPaginaValorInicial + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KeyQPaginaValor
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDFORMATO].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDREPORTE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDREPORTE].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDNOMBREFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDNOMBREFORMATO].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDNOMBREMES + Utilitario.Constantes.SIGNOIGUAL + this.dddblMes.SelectedItem.Text.ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDFECHA + Utilitario.Constantes.SIGNOIGUAL + Fecha.ToShortDateString();

			return qryPagina;

		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				DateTime Fecha = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(this.ddlbPeriodo.SelectedValue),Convert.ToInt32(this.dddblMes.SelectedValue)) + Utilitario.Constantes.SEPARADORFECHA +  Convert.ToInt32(this.dddblMes.SelectedValue) + Utilitario.Constantes.SEPARADORFECHA + Convert.ToInt32(this.ddlbPeriodo.SelectedValue));

				e.Item.Cells[1].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLFORMATOFORMULACION,this.ParametrosPaginaDesviacion(Fecha)));


				e.Item.Cells[2].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[2].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				e.Item.Cells[2].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLDETALLECOMPARATIVO,this.ParametrosPaginaDesviacion(Fecha)));
			}
			
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if(Convert.ToInt32(dr[Enumerados.ColumnasFormato.FlgVerMonto.ToString()]) == Utilitario.Constantes.ValorConstanteCero) 
				{
					e.Item.Cells[1].Text = String.Empty;
					e.Item.Cells[2].Text = String.Empty;
					e.Item.Cells[3].Text = String.Empty;
					e.Item.Cells[4].Text = String.Empty;
					e.Item.Cells[5].Text = String.Empty;
					e.Item.Cells[6].Text = String.Empty;
					e.Item.Cells[7].Text = String.Empty;
				}
				else
				{
					e.Item.Cells[1].Text = Convert.ToDouble(e.Item.Cells[1].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[3].Text = Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL5)  + Utilitario.Constantes.SIGNOPORCENTAJE;
					e.Item.Cells[4].Text = Convert.ToDouble(e.Item.Cells[4].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[5].Text = Convert.ToDouble(e.Item.Cells[5].Text).ToString(Utilitario.Constantes.FORMATODECIMAL5)  + Utilitario.Constantes.SIGNOPORCENTAJE;
					e.Item.Cells[7].Text = Convert.ToDouble(e.Item.Cells[7].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}
				
				if (Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdTipoLinea.ToString()]) != Utilitario.Constantes.ValorConstanteCero)
				{
					e.Item.BackColor = Color.LightYellow;
					e.Item.Font.Bold = true;
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}

		private void ddlbPeriodo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.ColspanRowspanHeader();
			this.LlenarGrilla();
		}

		private void dddblMes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.ColspanRowspanHeader();
			this.LlenarGrilla();
		}

		private void ddlbEmpresa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrilla();
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
