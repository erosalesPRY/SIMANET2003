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
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.GestionFinanciera.PrestamosBancarios
{
	/// <summary>
	/// Summary description for ConsultarPrestamosporBanco.
	/// </summary>
	public class ConsultarPrestamosporBanco : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkBanco";
		const string CONTROLTITULOTOTAL="hlkTitulo";
		const string URLDETALLE="ConsultarPrestamosporBancoDetalle.aspx?";
		const string URLDETALLEPORCENTRO="ConsultarPrestamosporCentroDetalle.aspx?";
		const string URLRESUMEDEBANCOPORCENTRO="ConsultarPrestamoBancarioResumendeBancosPorCentro.aspx?";
		
		const string URLPRINCIPAL="../../Default.aspx";
		const string COLORDENAMIENTO = "razonsocial";

		const string KEYIDESTADO = "idEstado";
		const string KEYIDENTIDADFINANCIERA = "idEF";
		const string KEYIDCENTRO = "idCentro";
		const string NOMBREENTIDAD = "Nombre";

		const string NOMBRECENTRO = "NombreCentro";

		const string CAMPO1 = "lblMontoCallaoS";
		const string CAMPO2 = "lblMontoCallaoD";
		const string CAMPO3 = "lblMontoChimboteS";
		const string CAMPO4 = "lblMontoChimboteD";
		const string CAMPO5 = "lblMontoIquitosS";
		const string CAMPO6 = "lblMontoIquitosD";
		const string CAMPO7 = "lblMontoTotalS";
		const string CAMPO8 = "lblMontoTotalD";

		const string CAMPOT1 = "lblFMontoCallaoS";
		const string CAMPOT2 = "lblFMontoCallaoD";
		const string CAMPOT3 = "lblFMontoChimboteS";
		const string CAMPOT4 = "lblFMontoChimboteD";
		const string CAMPOT5 = "lblFMontoIquitosS";
		const string CAMPOT6 = "lblFMontoIquitosD";
		const string CAMPOT7 = "lblFMontoTotalS";
		const string CAMPOT8 = "lblFMontoTotalD";
		
			
			
				

		const int PRODEDURENRO = 1;
		const string URLANTERIOR = "/SimaNetWeb/DirectorioEjecutivo/EstadosFinancieros.aspx";
		//Campos Cabeceras
		const string CAMPOH1 = "lblHCallao";
		const string CAMPOH2 = "lblHChimbote";
		const string CAMPOH3 = "lblHIquitos";

		//Otros
		const string TITULODETALLESC ="Ver detalle Sima callao";
		const string TITULODETALLESCH ="Ver detalle Sima Chimbote";
		const string TITULODETALLESI ="Ver detalle Sima Iquitos";

		const string NOMBREFOOTERCLASS ="FooterGrilla";

		const string SESSIONTOTALIZA ="Totaliza";

		//DataGrid and DataTable 
		const string COLUMNAIDENTIDADFINANCIERA ="idEntidadFinanciera";
		const string COLUMNAIDESTADO ="idEstado";

		//FIltro
		const string NOMBREBANCO ="RazonSocial";
				
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			//this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					Helper.ReestablecerPagina(this);
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.hGridPaginaSort.ServerChange += new System.EventHandler(this.hGridPaginaSort_ServerChange);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarPrestamosporBanco.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPrestamosporBanco.LlenarGrillaOrdenamiento implementation
		}
		public DataTable ObtenerDatos()
		{
			//string [] ParametrosValor={Utilitario.Constantes.IDESTADODEFAULT.ToString()};
			CPrestamoBancario oCPrestamoBancario= new CPrestamoBancario();
			DataTable dtGeneral = oCPrestamoBancario.ConsultaPrestamosporBanco(Utilitario.Constantes.IDESTADODEFAULT /*ParametrosValor*/);
			return dtGeneral;
		}
		private void GenerarResumen(DataTable dt)
		{
			if (dt!=null)
			{
				int NroResumen	 = 17;
				CResumenItem oCResumenItem = new CResumenItem();
				DataTable dtFinal1= Helper.Resumen(oCResumenItem.ObtenerConfiDataResumen(NroResumen),dt);
				Session["Totaliza"] = dtFinal1;

			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = ObtenerDatos();
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.Sort = columnaOrdenar ;
				this.GenerarResumen(dtGeneral);
				dwGeneral.RowFilter= Helper.ObtenerFiltro();
				grid.DataSource = dwGeneral;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();
				grid.CurrentPageIndex = indicePagina;
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
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}															
			// TODO:  Add ConsultarPrestamosporBanco.LlenarGrillaOrdenamientoPaginacion implementation
		}
/*	private void ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			if(ListItemType.Footer == e.Item.ItemType) 
			{ 
				e.Item.Cells[0].ColumnSpan=e.Item.Cells.Count;
				for (int i=1;i<=e.Item.Cells.Count-1;i++)
				{e.Item.Cells[i].Visible=false;}
			}
		}
*/		
		public void LlenarCombos()
		{
			// TODO:  Add ConsultarPrestamosporBanco.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarPrestamosporBanco.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarPrestamosporBanco.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPrestamosporBanco.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarPrestamosporBanco.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarPrestamosporBanco.Exportar implementation
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
			// TODO:  Add ConsultarPrestamosporBanco.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{			
			if(e.Item.ItemType == ListItemType.Header)
			{
				#region Header
				//SIMA CALLAO
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[2].FindControl(CAMPOH1),TITULODETALLESC,
						Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
						Helper.MostrarVentana(URLRESUMEDEBANCOPORCENTRO,KEYIDCENTRO +  Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCALLAO
																												+ Utilitario.Constantes.SIGNOAMPERSON
																												+ KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDESTADODEFAULT
																												+ Utilitario.Constantes.SIGNOAMPERSON
																												+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCALLAO
																												+  Utilitario.Constantes.SIGNOAMPERSON
																												+  Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModuloConsulta.Si.ToString()
																												));
				//SIMA CHIMBOTE
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[3].FindControl(CAMPOH2),TITULODETALLESCH,
						Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
						Helper.MostrarVentana(URLRESUMEDEBANCOPORCENTRO,KEYIDCENTRO +  Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCHIMBOTE
																												+ Utilitario.Constantes.SIGNOAMPERSON
																												+ KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDESTADODEFAULT
																												+ Utilitario.Constantes.SIGNOAMPERSON
																												+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCHIMBOTE
																												+  Utilitario.Constantes.SIGNOAMPERSON
																												+  Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModuloConsulta.Si.ToString()
																												));
				//SIMA IQUITOS
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[4].FindControl(CAMPOH3),TITULODETALLESI,
						Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
						Helper.MostrarVentana(URLRESUMEDEBANCOPORCENTRO,KEYIDCENTRO +  Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROIQUITOS
																												+ Utilitario.Constantes.SIGNOAMPERSON
																												+ KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDESTADODEFAULT
																												+ Utilitario.Constantes.SIGNOAMPERSON
																												+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROIQUITOS
																												+  Utilitario.Constantes.SIGNOAMPERSON
																												+  Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModuloConsulta.Si.ToString()
																												));
				#endregion
			}
			
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				#region Item
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
					Helper.MostrarVentana(URLDETALLE,KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[COLUMNAIDENTIDADFINANCIERA])
																			+  Utilitario.Constantes.SIGNOAMPERSON
																			+  KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNAIDESTADO].ToString()
																			+  Utilitario.Constantes.SIGNOAMPERSON
																			+  NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.FinColumnaPrestamoBancario.RazonSocial.ToString()]
																			+  Utilitario.Constantes.SIGNOAMPERSON
																			+  Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModuloConsulta.Si.ToString()
																			)) ;

				((Label)e.Item.Cells[2].FindControl(CAMPO1)).Text = Convert.ToDouble(dr[Enumerados.FinColumnaPrestamoBancario.MontoCallaoS.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[2].FindControl(CAMPO2)).Text = Convert.ToDouble(dr[Enumerados.FinColumnaPrestamoBancario.MontoCallaoD.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[3].FindControl(CAMPO3)).Text= Convert.ToDouble(dr[Enumerados.FinColumnaPrestamoBancario.MontoChimboteS.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[3].FindControl(CAMPO4)).Text= Convert.ToDouble(dr[Enumerados.FinColumnaPrestamoBancario.MontoChimboteD.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[4].FindControl(CAMPO5)).Text= Convert.ToDouble(dr[Enumerados.FinColumnaPrestamoBancario.MontoIquitosS.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[4].FindControl(CAMPO6)).Text= Convert.ToDouble(dr[Enumerados.FinColumnaPrestamoBancario.MontoIquitosD.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[5].FindControl(CAMPO7)).Text= Convert.ToDouble(dr[Enumerados.FinColumnaPrestamoBancario.MontoTotalS.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[5].FindControl(CAMPO8)).Text= Convert.ToDouble(dr[Enumerados.FinColumnaPrestamoBancario.MontoTotalD.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex).ToUpper();

				Helper.FiltroporSeleccionConfiguraColumna(e,grid,false);
				#endregion
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				#region Footer
				e.Item.Cells[0].ColumnSpan=2;
				e.Item.Cells[0].CssClass = NOMBREFOOTERCLASS;
				e.Item.Cells[1].Visible=false;

				DataTable dtTotal = (DataTable) Session[SESSIONTOTALIZA];

				((Label)e.Item.Cells[2].FindControl(CAMPOT1)).Text = Convert.ToDouble(dtTotal.Rows[0][Enumerados.FinColumnaPrestamoBancario.MontoCallaoS.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[2].FindControl(CAMPOT2)).Text = Convert.ToDouble(dtTotal.Rows[0][Enumerados.FinColumnaPrestamoBancario.MontoCallaoD.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[3].FindControl(CAMPOT3)).Text = Convert.ToDouble(dtTotal.Rows[0][Enumerados.FinColumnaPrestamoBancario.MontoChimboteS.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[3].FindControl(CAMPOT4)).Text = Convert.ToDouble(dtTotal.Rows[0][Enumerados.FinColumnaPrestamoBancario.MontoChimboteD.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[4].FindControl(CAMPOT5)).Text = Convert.ToDouble(dtTotal.Rows[0][Enumerados.FinColumnaPrestamoBancario.MontoIquitosS.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[4].FindControl(CAMPOT6)).Text = Convert.ToDouble(dtTotal.Rows[0][Enumerados.FinColumnaPrestamoBancario.MontoIquitosD.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[5].FindControl(CAMPOT7)).Text = Convert.ToDouble(dtTotal.Rows[0][Enumerados.FinColumnaPrestamoBancario.MontoTotalS.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[5].FindControl(CAMPOT8)).Text = Convert.ToDouble(dtTotal.Rows[0][Enumerados.FinColumnaPrestamoBancario.MontoTotalD.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				Session["Totaliza"]=null;
				#endregion
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos(),Utilitario.Constantes.SIGNOASTERISCO + NOMBREBANCO + ";Nombre de Banco");
			
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void hGridPaginaSort_ServerChange(object sender, System.EventArgs e)
		{
		
		}
	}
}
