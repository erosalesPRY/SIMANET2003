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
	/// Summary description for EstadosFinancierosEvaluacion.
	/// </summary>
	public class EstadosFinancierosEvaluacion : System.Web.UI.Page,IPaginaBase
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
		const string KEYQIDNOMBREMES = "NombreMes";

		const string KEYQNRODIGITOS ="NroDig";
		const string KEYQDIGCUENTA = "DigCuenta";

		const string CONTROLINK = "hlkConcepto";

		const string CAMPO1 = "lblMontoAcumuladoPPTO";
		const string CAMPO2 = "lblMontoAcumuladoReal";
		const string CAMPO3 = "lblPorcAcumuladoReal";
		const string CAMPO4 = "lblMontoAcumuladoVariacion";
		const string CAMPO5 = "lblPorcAcumuladoVariacion";

		const string CAMPO6 = "lblMontodelMesPPTO";
		const string CAMPO7 = "lblMontodelMesReal";
		const string CAMPO8 = "lblPorcdelMesReal";
		const string CAMPO9 = "lblMontodelMesVariacion";
		const string CAMPO10 = "lblPorcdelMesVariacion";

					


		const int NRODIGINI = 2;
		const int DIGCTA = 0;
			

		const string CONTROLIMAGE = "imgVerDetalle";
		const string GRILLAVACIA="No exiets";
		const string URLPRINCIPAL = "../../Default.aspx";
		const string URLCOMPARATIVO = "EstadoFinancieroAcumuladoComparativo.aspx?";
		const string URLPERIODO = "EstadoFinancierodelPeriodo.aspx?";
		const string URLANTERIORPERU = "/SimaNetWeb/DirectorioEjecutivo/FinancieroPeru.aspx?";
		const string URLANTERIORIQUITOS = "/SimaNetWeb/DirectorioEjecutivo/FinancieroIquitos.aspx?";
		

		//para los formato
		const string Comillas = "\"";
		const string EstiloLeft =  "BORDER-LEFT: #cccccc 1px solid";
		const string EstiloBottom = "BORDER-BOTTOM: #cccccc 1px solid";
		const string Estilo ="style = ";

		//Datos Grilla and DataTable
		const string TITULOCONCEPTO ="CONCEPTO";
		const string TITULOPTOPERIODOENERO ="PRESUPUESTO PERIODO  ENERO / ";
		const string TITULODEL =" DEL ";
		const string TITULOPERIODO ="PERIODO :";
		const string TITULOMES ="MES :";

		const string TITULOPTOACUMULADO ="PresupuestoAcumulado";
		const string TITULOREALACUMULADO ="RealAcumulado";
		const string TITULOVARIACIONPORCACUMULADO ="VariacionPorcAcumulado";
		const string TITULOVARIACIONACUMULADA ="VariacionAcumulada";
		const string TITULOPTOMES ="PresupuestoDelMes";
        const string TITULOREALMES ="RealdelMes";
		const string TITULOVARIACIONPORCMES ="VariacionPorcdelMes";
		const string TITULOVARIACIONMES ="VariacionDelMes";
		
		private ASPNetDatagridDecorator m_add = new ASPNetDatagridDecorator();
		#endregion

		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label lblMes;
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
					this.LlenarDatos();
					this.ColspanRowspanHeader();
					this.ValidarCampos();
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void ValidarCampos()
		{
			grid.Columns[2].Visible=(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])!= Convert.ToInt32(Utilitario.Constantes.KEYIDFORMATOBALANCEGENERAL));

		}
		private void ColspanRowspanHeader()
		{

			DateTime Fecha = Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA].ToString());

			TableCell cell = null;
			m_add.DatagridToDecorate = grid;
			ArrayList header = new ArrayList();


			cell = new TableCell();
			cell.Text = TITULOCONCEPTO;
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = TITULOPTOPERIODOENERO + Page.Request.Params[KEYQIDNOMBREMES].ToString().ToUpper() + TITULODEL + Fecha.Year.ToString();
			cell.ColumnSpan = 2;
			cell.HorizontalAlign = HorizontalAlign.Center;
			header.Add(cell);
			m_add.AddMergeHeader(header);
			
		}




		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DateTime Fecha = Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA].ToString());
			CEstadoFinancieroPresupuestal oCEstadoFinancieroPresupuestal = new CEstadoFinancieroPresupuestal();

			DataTable dtEstadoFinanciero = oCEstadoFinancieroPresupuestal.ConsultarEstadosFinancierosPresupuestalEvaluacion(
				Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE])
				,Utilitario.Constantes.IDDEFAULT
				,Convert.ToInt32(Fecha.Year)
				,Convert.ToInt32(Fecha.Month)
				,Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA])
				,Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO]));
			
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
			// TODO:  Add EstadosFinancierosEvaluacion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add EstadosFinancierosEvaluacion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			
			// TODO:  Add EstadosFinancierosEvaluacion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add EstadosFinancierosEvaluacion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			DateTime Fecha = Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA].ToString());
			this.lblPagina.Text = Page.Request.Params[KEYQIDNOMBREFORMATO].ToString();
			this.lblPeriodo.Text =TITULOPERIODO + Fecha.Year.ToString();
			this.lblMes.Text =TITULOMES + Page.Request.Params[KEYQIDNOMBREMES].ToString().ToUpper();
			//Ocultar Columnas

			// TODO:  Add EstadosFinancierosEvaluacion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add EstadosFinancierosEvaluacion.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add EstadosFinancierosEvaluacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add EstadosFinancierosEvaluacion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add EstadosFinancierosEvaluacion.Exportar implementation
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
			// TODO:  Add EstadosFinancierosEvaluacion.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			Label lbl;
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if(Convert.ToInt32(dr[Enumerados.ColumnasFormato.FlgVerMonto.ToString()]) == Utilitario.Constantes.ValorConstanteCero) 
				{
					//Otros Formatos
					lbl = (Label)e.Item.Cells[1].FindControl(CAMPO1);lbl.Text = String.Empty;
					lbl = (Label)e.Item.Cells[1].FindControl(CAMPO2);lbl.Text = String.Empty;
					lbl = (Label)e.Item.Cells[1].FindControl(CAMPO3);lbl.Text = String.Empty;
					lbl = (Label)e.Item.Cells[1].FindControl(CAMPO4);lbl.Text = String.Empty;
					lbl = (Label)e.Item.Cells[1].FindControl(CAMPO5);lbl.Text = String.Empty;
					lbl = (Label)e.Item.Cells[1].FindControl(CAMPO6);lbl.Text = String.Empty;
					lbl = (Label)e.Item.Cells[1].FindControl(CAMPO7);lbl.Text = String.Empty;
					lbl = (Label)e.Item.Cells[1].FindControl(CAMPO8);lbl.Text = String.Empty;
					lbl = (Label)e.Item.Cells[1].FindControl(CAMPO9);lbl.Text = String.Empty;
					lbl = (Label)e.Item.Cells[1].FindControl(CAMPO10);lbl.Text = String.Empty;
				}
				else
				{
					//Movimientos Acuulados
					lbl = (Label)e.Item.Cells[1].FindControl(CAMPO1);lbl.Text = Convert.ToDouble(dr[TITULOPTOACUMULADO]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					lbl = (Label)e.Item.Cells[1].FindControl(CAMPO2);lbl.Text = Convert.ToDouble(dr[TITULOREALACUMULADO]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					lbl = (Label)e.Item.Cells[1].FindControl(CAMPO3);lbl.Text = Convert.ToDouble(dr[TITULOVARIACIONPORCACUMULADO]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					lbl = (Label)e.Item.Cells[1].FindControl(CAMPO4);lbl.Text = Convert.ToDouble(dr[TITULOVARIACIONACUMULADA]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					lbl = (Label)e.Item.Cells[1].FindControl(CAMPO5);lbl.Text = String.Empty;
					//Movimientos del Mes
					lbl = (Label)e.Item.Cells[2].FindControl(CAMPO6);lbl.Text = Convert.ToDouble(dr[TITULOPTOMES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					lbl = (Label)e.Item.Cells[2].FindControl(CAMPO7);lbl.Text = Convert.ToDouble(dr[TITULOREALMES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					lbl = (Label)e.Item.Cells[2].FindControl(CAMPO8);lbl.Text = Convert.ToDouble(dr[TITULOVARIACIONPORCMES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					lbl = (Label)e.Item.Cells[2].FindControl(CAMPO9);lbl.Text = Convert.ToDouble(dr[TITULOVARIACIONMES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					lbl = (Label)e.Item.Cells[2].FindControl(CAMPO10);lbl.Text = String.Empty;
				}
				
				if (Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdTipoLinea.ToString()]) != Utilitario.Constantes.ValorConstanteCero)
				{
					e.Item.BackColor = Color.LightYellow;
					e.Item.Font.Bold = true;
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}

