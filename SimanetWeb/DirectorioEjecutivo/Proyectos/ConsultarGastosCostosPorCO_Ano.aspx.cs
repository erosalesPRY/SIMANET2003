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
	public class ConsultarGastosCostosPorCO_Ano : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string KEYIDCENTRO ="IdCentro";
		const string KEYANO ="Ano";
		const string KEYCENTRO ="Centro";

		#endregion
		#region Controles

		ArrayList arrTotalizaCD;
		ArrayList arrTotalizaCI;
		ArrayList arrTotalizaGAP;
		ArrayList arrTotalizaGAC;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblResultado1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblResultado2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblResultado3;
		protected projDataGridWeb.DataGridWeb grid1;
		protected projDataGridWeb.DataGridWeb grid2;
		protected projDataGridWeb.DataGridWeb grid3;
		protected System.Web.UI.WebControls.Label lblPrincipal;


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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Resumen de Gastos y Costos",this.ToString(),"Se consultaron Resumen de Costos y Gastos",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarCabecera();
					Helper.ReestablecerPagina(this);
					
					this.LlenarGrillaCuenta91();
					this.LlenarGrillaCuenta92();
					this.LlenarGrillaCuenta96();
					this.LlenarGrillaCuenta97();
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid1_ItemDataBound);
			this.grid2.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid2_ItemDataBound);
			this.grid3.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid3_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
		}

		public void LlenarCabecera()
		{
			lblPrincipal.Text = "RESUMEN COMPARATIVO DE GASTOS POR AÑO";
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}

		private DataTable ObtenerDatosCuenta91()
		{
			CProyectos oCProyectos= new CProyectos();
			DataTable dtGeneral =oCProyectos.ConsultarCostosGastosPorCtaMayor_Anos(
				Page.Request.Params[KEYIDCENTRO].ToString(),
				Convert.ToInt32(Page.Request.Params[KEYANO].ToString()), Convert.ToInt32(Utilitario.Enumerados.INTCuentasMayores.C91));
			return dtGeneral;
		}

		private DataTable ObtenerDatosCuenta92()
		{
			CProyectos oCProyectos= new CProyectos();
			DataTable dtGeneral =oCProyectos.ConsultarCostosGastosPorCtaMayor_Anos(
				Page.Request.Params[KEYIDCENTRO].ToString(),
				Convert.ToInt32(Page.Request.Params[KEYANO].ToString()), Convert.ToInt32(Utilitario.Enumerados.INTCuentasMayores.C92));
			return dtGeneral;
		}

		private DataTable ObtenerDatosCuenta96()
		{
			CProyectos oCProyectos= new CProyectos();
			DataTable dtGeneral =oCProyectos.ConsultarCostosGastosPorCtaMayor_Anos(
				Page.Request.Params[KEYIDCENTRO].ToString(),
				Convert.ToInt32(Page.Request.Params[KEYANO].ToString()), Convert.ToInt32(Utilitario.Enumerados.INTCuentasMayores.C96));
			return dtGeneral;
		}

		private DataTable ObtenerDatosCuenta97()
		{
			CProyectos oCProyectos= new CProyectos();
			DataTable dtGeneral =oCProyectos.ConsultarCostosGastosPorCtaMayor_Anos(
				Page.Request.Params[KEYIDCENTRO].ToString(),
				Convert.ToInt32(Page.Request.Params[KEYANO].ToString()), Convert.ToInt32(Utilitario.Enumerados.INTCuentasMayores.C97));
			return dtGeneral;
		}

		private void TotalizaCD(DataView dv)
		{
			arrTotalizaCD = new ArrayList();
			arrTotalizaCD.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO1.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaCD.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO2.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaCD.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO3.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaCD.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO4.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaCD.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO5.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaCD.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO6.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaCD.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO7.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaCD.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO8.ToString() + ")",dv.RowFilter.ToString()));
		}

		private void TotalizaCI(DataView dv)
		{
			arrTotalizaCI = new ArrayList();
			arrTotalizaCI.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO1.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaCI.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO2.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaCI.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO3.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaCI.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO4.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaCI.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO5.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaCI.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO6.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaCI.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO7.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaCI.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO8.ToString() + ")",dv.RowFilter.ToString()));
		}

		private void TotalizaGP(DataView dv)
		{
			arrTotalizaGAP = new ArrayList();
			arrTotalizaGAP.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO1.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaGAP.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO2.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaGAP.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO3.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaGAP.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO4.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaGAP.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO5.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaGAP.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO6.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaGAP.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO7.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaGAP.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO8.ToString() + ")",dv.RowFilter.ToString()));
		}

		private void TotalizaGC(DataView dv)
		{
			arrTotalizaGAC = new ArrayList();
			arrTotalizaGAC.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO1.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaGAC.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO2.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaGAC.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO3.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaGAC.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO4.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaGAC.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO5.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaGAC.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO6.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaGAC.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO7.ToString() + ")",dv.RowFilter.ToString()));
			arrTotalizaGAC.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_CostosGastos.ANO8.ToString() + ")",dv.RowFilter.ToString()));
		}

		public void LlenarGrillaCuenta91()
		{
			DataTable dtGeneral = this.ObtenerDatosCuenta91();
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				this.TotalizaCD(dwGeneral);
				grid.DataSource = dwGeneral;
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

		public void LlenarGrillaCuenta92()
		{
			DataTable dtGeneral = this.ObtenerDatosCuenta92();
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				this.TotalizaCI(dwGeneral);
				grid1.DataSource = dwGeneral;
				grid1.Columns[Utilitario.Constantes.POSICIONINDEXDOS].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();

				lblResultado.Visible = false;

			}
			else
			{
				grid1.DataSource = dtGeneral;
				lblResultado1.Visible = true;
				lblResultado1.Text = GRILLAVACIA;
			}
			try
			{
				grid1.DataBind();
			}
			catch(Exception oException)
			{
				grid1.CurrentPageIndex = 0;
				grid1.DataBind();
			}												
		}

		public void LlenarGrillaCuenta96()
		{
			DataTable dtGeneral = this.ObtenerDatosCuenta96();
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				this.TotalizaGP(dwGeneral);
				grid2.DataSource = dwGeneral;
				grid2.Columns[Utilitario.Constantes.POSICIONINDEXDOS].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();

				lblResultado2.Visible = false;

			}
			else
			{
				grid2.DataSource = dtGeneral;
				lblResultado2.Visible = true;
				lblResultado2.Text = GRILLAVACIA;
			}
			try
			{
				grid2.DataBind();
			}
			catch(Exception oException)
			{
				grid2.CurrentPageIndex = 0;
				grid2.DataBind();
			}												
		}

		public void LlenarGrillaCuenta97()
		{
			DataTable dtGeneral = this.ObtenerDatosCuenta97();
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				this.TotalizaGC(dwGeneral);
				grid3.DataSource = dwGeneral;
				grid3.Columns[Utilitario.Constantes.POSICIONINDEXDOS].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();

				lblResultado3.Visible = false;

			}
			else
			{
				grid3.DataSource = dtGeneral;
				lblResultado3.Visible = true;
				lblResultado3.Text = GRILLAVACIA;
			}
			try
			{
				grid3.DataBind();
			}
			catch(Exception oException)
			{
				grid3.CurrentPageIndex = 0;
				grid3.DataBind();
			}												
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
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
			#region Header
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[1].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 7).ToString();
				e.Item.Cells[2].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 6).ToString();
				e.Item.Cells[3].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 5).ToString();
				e.Item.Cells[4].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 4).ToString();
				e.Item.Cells[5].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 3).ToString();
				e.Item.Cells[6].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 2).ToString();
				e.Item.Cells[7].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 1).ToString();
				e.Item.Cells[8].Text = Page.Request[KEYANO].ToString();
			}			
			#endregion

			#region FOOTER
			if(e.Item.ItemType == ListItemType.Footer)
			{
				if (arrTotalizaCD.Count > 0)
				{
					e.Item.Cells[1].Text = Convert.ToDouble(arrTotalizaCD[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[2].Text = Convert.ToDouble(arrTotalizaCD[1]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[3].Text = Convert.ToDouble(arrTotalizaCD[2]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[4].Text = Convert.ToDouble(arrTotalizaCD[3]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[5].Text = Convert.ToDouble(arrTotalizaCD[4]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[6].Text = Convert.ToDouble(arrTotalizaCD[5]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[7].Text = Convert.ToDouble(arrTotalizaCD[6]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[8].Text = Convert.ToDouble(arrTotalizaCD[7]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}
			}		
			#endregion
		}

		private void grid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			#region Header
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[1].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 7).ToString();
				e.Item.Cells[2].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 6).ToString();
				e.Item.Cells[3].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 5).ToString();
				e.Item.Cells[4].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 4).ToString();
				e.Item.Cells[5].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 3).ToString();
				e.Item.Cells[6].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 2).ToString();
				e.Item.Cells[7].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 1).ToString();
				e.Item.Cells[8].Text = Page.Request[KEYANO].ToString();
			}			
			#endregion

			#region FOOTER
			if(e.Item.ItemType == ListItemType.Footer)
			{
				if (arrTotalizaCI.Count > 0)
				{
					e.Item.Cells[1].Text = Convert.ToDouble(arrTotalizaCI[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[2].Text = Convert.ToDouble(arrTotalizaCI[1]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[3].Text = Convert.ToDouble(arrTotalizaCI[2]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[4].Text = Convert.ToDouble(arrTotalizaCI[3]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[5].Text = Convert.ToDouble(arrTotalizaCI[4]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[6].Text = Convert.ToDouble(arrTotalizaCI[5]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[7].Text = Convert.ToDouble(arrTotalizaCI[6]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[8].Text = Convert.ToDouble(arrTotalizaCI[7]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}
			}		
			#endregion		
		}

		private void grid2_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			#region Header
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[1].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 7).ToString();
				e.Item.Cells[2].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 6).ToString();
				e.Item.Cells[3].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 5).ToString();
				e.Item.Cells[4].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 4).ToString();
				e.Item.Cells[5].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 3).ToString();
				e.Item.Cells[6].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 2).ToString();
				e.Item.Cells[7].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 1).ToString();
				e.Item.Cells[8].Text = Page.Request[KEYANO].ToString();
			}			
			#endregion

			#region FOOTER
			if(e.Item.ItemType == ListItemType.Footer)
			{
				if (arrTotalizaGAP.Count > 0)
				{
					e.Item.Cells[1].Text = Convert.ToDouble(arrTotalizaGAP[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[2].Text = Convert.ToDouble(arrTotalizaGAP[1]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[3].Text = Convert.ToDouble(arrTotalizaGAP[2]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[4].Text = Convert.ToDouble(arrTotalizaGAP[3]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[5].Text = Convert.ToDouble(arrTotalizaGAP[4]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[6].Text = Convert.ToDouble(arrTotalizaGAP[5]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[7].Text = Convert.ToDouble(arrTotalizaGAP[6]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[8].Text = Convert.ToDouble(arrTotalizaGAP[7]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}
			}		
			#endregion				
		}

		private void grid3_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			#region Header
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[1].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 7).ToString();
				e.Item.Cells[2].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 6).ToString();
				e.Item.Cells[3].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 5).ToString();
				e.Item.Cells[4].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 4).ToString();
				e.Item.Cells[5].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 3).ToString();
				e.Item.Cells[6].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 2).ToString();
				e.Item.Cells[7].Text = Convert.ToString(Convert.ToInt32(Page.Request[KEYANO].ToString()) - 1).ToString();
				e.Item.Cells[8].Text = Page.Request[KEYANO].ToString();
			}			
			#endregion

			#region FOOTER
			if(e.Item.ItemType == ListItemType.Footer)
			{
				if (arrTotalizaGAC.Count > 0)
				{
					e.Item.Cells[1].Text = Convert.ToDouble(arrTotalizaGAC[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[2].Text = Convert.ToDouble(arrTotalizaGAC[1]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[3].Text = Convert.ToDouble(arrTotalizaGAC[2]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[4].Text = Convert.ToDouble(arrTotalizaGAC[3]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[5].Text = Convert.ToDouble(arrTotalizaGAC[4]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[6].Text = Convert.ToDouble(arrTotalizaGAC[5]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[7].Text = Convert.ToDouble(arrTotalizaGAC[6]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[8].Text = Convert.ToDouble(arrTotalizaGAC[7]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}
			}		
			#endregion						
		}
	}
}
