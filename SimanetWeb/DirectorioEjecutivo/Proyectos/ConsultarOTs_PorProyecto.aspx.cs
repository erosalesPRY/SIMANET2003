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
	public class ConsultarOTs_PorProyecto : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string URLCONSULTAR_OC ="ConsultarOC_PorOT.aspx?";
		const string URLCONSULTAR_OS ="ConsultarOS_PorOT.aspx?";
		const string COLORDENAMIENTO = "OT";

		const string KEYIDPROYECTO = "COD_PROYECTO";
		const string KEYPROYECTO = "PROYECTO";
		const string KEYIDOT = "IDOT";
		const string KEYOT = "OT";
		const string KEYLINEA = "Linea";
		//Otros
		const string CAMPO_PRO_MAT = "lblPRO_MAT";
		const string CAMPO_PRO_MOB = "lblPRO_MOB";
		const string CAMPO_PRO_SRV = "lblPRO_SRV";

		const string CAMPO_DIR_MAT = "lblDIR_MAT";
		const string CAMPO_DIR_MOB = "lblDIR_MOB";
		const string CAMPO_DIR_SRV = "lblDIR_SRV";

		const string CAMPO_IND_MAT = "lblIND_MAT";
		const string CAMPO_IND_MOB = "lblIND_MOB";
		const string CAMPO_IND_SRV = "lblIND_SRV";

		const string CAMPO_TOT_PRO = "lblTOT_PRO";
		const string CAMPO_TOT_EJE = "lblTOT_EJE";
		const string CAMPO_TOT_DIF = "lblTOT_DIF";

		const string CONTROLMONTOTOTAL_PRO_MAT = "lblTPRO_MAT";
		const string CONTROLMONTOTOTAL_PRO_MOB = "lblTPRO_MOB";
		const string CONTROLMONTOTOTAL_PRO_SRV = "lblTPRO_SRV";

		const string CONTROLMONTOTOTAL_DIR_MAT = "lblTDIR_MAT";
		const string CONTROLMONTOTOTAL_DIR_MOB = "lblTDIR_MOB";
		const string CONTROLMONTOTOTAL_DIR_SRV = "lblTDIR_SRV";

		const string CONTROLMONTOTOTAL_IND_MAT = "lblTIND_MAT";
		const string CONTROLMONTOTOTAL_IND_MOB = "lblTIND_MOB";
		const string CONTROLMONTOTOTAL_IND_SRV = "lblTIND_SRV";

		const string CONTROLMONTOTOTAL_PRO = "lblTTOT_PRO";
		const string CONTROLMONTOTOTAL_EJE = "lblTTOT_EJE";
		const string CONTROLMONTOTOTAL_DIF = "lblTTOT_DIF";

		const string TOTALIZA ="Totaliza";

		#endregion
		#region Controles

		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.Label Label8;
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Proyectos",this.ToString(),"Se consultó Órdenes de Trabajo Directorio",Enumerados.NivelesErrorLog.I.ToString()));
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
			lblTitulo.Text = Page.Request[KEYPROYECTO].ToString().ToUpper();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}

		private DataTable ObtenerDatos()
		{
			CProyectos oCProyectos= new CProyectos();
			DataTable dtGeneral;

			if (Page.Request.Params[KEYIDPROYECTO].ToString() == Utilitario.Constantes.SIGNOLINEAVERTICAL)
			{
				dtGeneral=oCProyectos.ConsultarOTs_PorLinea(Page.Request.Params[KEYLINEA].ToString());		
			}
			else
			{
				dtGeneral=oCProyectos.ConsultarOTsPorProyecto(Page.Request.Params[KEYIDPROYECTO].ToString());		
			}
			return dtGeneral;
		}
		private void Totaliza(DataView dv)
		{
			arrTotaliza = new ArrayList();
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_PRY_OT_SEDES.PROG_MAT.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_PRY_OT_SEDES.PROG_MOB.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_PRY_OT_SEDES.PROG_SRV.ToString() + ")",dv.RowFilter.ToString()));
			
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_PRY_OT_SEDES.DIR_MAT.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_PRY_OT_SEDES.DIR_MOB.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_PRY_OT_SEDES.DIR_SRV.ToString() + ")",dv.RowFilter.ToString()));

			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_PRY_OT_SEDES.IND_MAT.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_PRY_OT_SEDES.IND_MOB.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_PRY_OT_SEDES.IND_SRV.ToString() + ")",dv.RowFilter.ToString()));

			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_PRY_OT_SEDES.TOT_PRO.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_PRY_OT_SEDES.TOT_EJE.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_PRY_OT_SEDES.TOT_DIF.ToString() + ")",dv.RowFilter.ToString()));
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

				grid.Columns[Utilitario.Constantes.POSICIONINDEXTRES].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				grid.Columns[Utilitario.Constantes.POSICIONINDEXCUATRO].FooterText = dwGeneral.Count.ToString();

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
				e.Item.Cells[8].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.MostrarVentana(URLCONSULTAR_OC,
					KEYPROYECTO + Utilitario.Constantes.SIGNOIGUAL + Page.Request[KEYPROYECTO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYIDOT + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.INTColumna_PRY_OT_SEDES.OT.ToString()].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYOT + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.INTColumna_PRY_OT_SEDES.DES_OT.ToString()].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[Utilitario.Constantes.KEYMODULOCONSULTA].ToString()));
				e.Item.Cells[8].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","hGridPagina","txtBuscar"));

				e.Item.Cells[9].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.MostrarVentana(URLCONSULTAR_OS,
					KEYPROYECTO + Utilitario.Constantes.SIGNOIGUAL + Page.Request[KEYPROYECTO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYIDOT + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.INTColumna_PRY_OT_SEDES.OT.ToString()].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYOT + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.INTColumna_PRY_OT_SEDES.DES_OT.ToString()].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[Utilitario.Constantes.KEYMODULOCONSULTA].ToString()));
				e.Item.Cells[9].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","hGridPagina","txtBuscar"));

				((Label)e.Item.Cells[5].FindControl(CAMPO_PRO_MAT)).Text= 
					Convert.ToDouble((Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.PROG_MAT.ToString()])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				((Label)e.Item.Cells[5].FindControl(CAMPO_PRO_MAT)).ToolTip = 
					Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.PROG_MAT.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[5].FindControl(CAMPO_PRO_MOB)).Text= 
					Convert.ToDouble((Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.PROG_MOB.ToString()])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				((Label)e.Item.Cells[5].FindControl(CAMPO_PRO_MOB)).ToolTip = 
					Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.PROG_MOB.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[5].FindControl(CAMPO_PRO_SRV)).Text= 
					Convert.ToDouble((Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.PROG_SRV.ToString()])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				((Label)e.Item.Cells[5].FindControl(CAMPO_PRO_SRV)).ToolTip = 
					Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.PROG_SRV.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				//((Label)e.Item.Cells[5].FindControl(CAMPO_PRO_MOB)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.PROG_MOB.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//((Label)e.Item.Cells[5].FindControl(CAMPO_PRO_SRV)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.PROG_SRV.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);				


				((Label)e.Item.Cells[6].FindControl(CAMPO_DIR_MAT)).Text= 
					Convert.ToDouble((Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.DIR_MAT.ToString()])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				((Label)e.Item.Cells[6].FindControl(CAMPO_DIR_MAT)).ToolTip = 
					Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.DIR_MAT.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[6].FindControl(CAMPO_DIR_MOB)).Text= 
					Convert.ToDouble((Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.DIR_MOB.ToString()])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				((Label)e.Item.Cells[6].FindControl(CAMPO_DIR_MOB)).ToolTip = 
					Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.DIR_MOB.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[6].FindControl(CAMPO_DIR_SRV)).Text= 
					Convert.ToDouble((Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.DIR_SRV.ToString()])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				((Label)e.Item.Cells[6].FindControl(CAMPO_DIR_SRV)).ToolTip = 
					Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.DIR_SRV.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				//((Label)e.Item.Cells[6].FindControl(CAMPO_DIR_MAT)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.DIR_MAT.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//((Label)e.Item.Cells[6].FindControl(CAMPO_DIR_MOB)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.DIR_MOB.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//((Label)e.Item.Cells[6].FindControl(CAMPO_DIR_SRV)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.DIR_SRV.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[6].FindControl(CAMPO_IND_MAT)).Text= 
					Convert.ToDouble((Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.IND_MAT.ToString()])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				((Label)e.Item.Cells[6].FindControl(CAMPO_IND_MAT)).ToolTip = 
					Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.IND_MAT.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[6].FindControl(CAMPO_IND_MOB)).Text= 
					Convert.ToDouble((Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.IND_MOB.ToString()])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				((Label)e.Item.Cells[6].FindControl(CAMPO_IND_MOB)).ToolTip = 
					Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.IND_MOB.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[6].FindControl(CAMPO_IND_SRV)).Text= 
					Convert.ToDouble((Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.IND_SRV.ToString()])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				((Label)e.Item.Cells[6].FindControl(CAMPO_IND_SRV)).ToolTip = 
					Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.IND_SRV.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				//((Label)e.Item.Cells[6].FindControl(CAMPO_IND_MAT)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.IND_MAT.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//((Label)e.Item.Cells[6].FindControl(CAMPO_IND_MOB)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.IND_MOB.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//((Label)e.Item.Cells[6].FindControl(CAMPO_IND_SRV)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.IND_SRV.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[7].FindControl(CAMPO_TOT_PRO)).Text= 
					Convert.ToDouble((Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.TOT_PRO.ToString()])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				((Label)e.Item.Cells[7].FindControl(CAMPO_TOT_PRO)).ToolTip = 
					Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.TOT_PRO.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[7].FindControl(CAMPO_TOT_EJE)).Text= 
					Convert.ToDouble((Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.TOT_EJE.ToString()])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				((Label)e.Item.Cells[7].FindControl(CAMPO_TOT_EJE)).ToolTip = 
					Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.TOT_EJE.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[7].FindControl(CAMPO_TOT_DIF)).Text= 
					Convert.ToDouble((Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.TOT_DIF.ToString()])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				((Label)e.Item.Cells[7].FindControl(CAMPO_TOT_DIF)).ToolTip = 
					Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.TOT_DIF.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				//((Label)e.Item.Cells[7].FindControl(CAMPO_TOT_PRO)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.TOT_PRO.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//((Label)e.Item.Cells[7].FindControl(CAMPO_TOT_EJE)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.TOT_EJE.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//((Label)e.Item.Cells[7].FindControl(CAMPO_TOT_DIF)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_PRY_OT_SEDES.TOT_DIF.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);			
			}	
			#endregion

			#region FOOTER
			if(e.Item.ItemType == ListItemType.Footer)
			{
				if (arrTotaliza.Count > 0)
				{
					((Label)e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_PRO_MAT)).Text= 
						Convert.ToDouble((Convert.ToDouble(arrTotaliza[0])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label)e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_PRO_MAT)).ToolTip = 
						Convert.ToDouble(arrTotaliza[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					((Label)e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_PRO_MOB)).Text= 
						Convert.ToDouble((Convert.ToDouble(arrTotaliza[1])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label)e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_PRO_MOB)).ToolTip = 
						Convert.ToDouble(arrTotaliza[1]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					((Label)e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_PRO_SRV)).Text= 
						Convert.ToDouble((Convert.ToDouble(arrTotaliza[2])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label)e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_PRO_SRV)).ToolTip = 
						Convert.ToDouble(arrTotaliza[2]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					//((Label) e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_PRO_MAT)).Text=Convert.ToDouble(arrTotaliza[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					//((Label) e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_PRO_MOB)).Text=Convert.ToDouble(arrTotaliza[1]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					//((Label) e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_PRO_SRV)).Text=Convert.ToDouble(arrTotaliza[2]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					((Label)e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_DIR_MAT)).Text= 
						Convert.ToDouble((Convert.ToDouble(arrTotaliza[3])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label)e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_DIR_MAT)).ToolTip = 
						Convert.ToDouble(arrTotaliza[3]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					((Label)e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_DIR_MOB)).Text= 
						Convert.ToDouble((Convert.ToDouble(arrTotaliza[4])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label)e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_DIR_MOB)).ToolTip = 
						Convert.ToDouble(arrTotaliza[4]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					((Label)e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_DIR_SRV)).Text= 
						Convert.ToDouble((Convert.ToDouble(arrTotaliza[5])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label)e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_DIR_SRV)).ToolTip = 
						Convert.ToDouble(arrTotaliza[5]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					//((Label) e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_DIR_MAT)).Text=Convert.ToDouble(arrTotaliza[3]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					//((Label) e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_DIR_MOB)).Text=Convert.ToDouble(arrTotaliza[4]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					//((Label) e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_DIR_SRV)).Text=Convert.ToDouble(arrTotaliza[5]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					((Label)e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_IND_MAT)).Text= 
						Convert.ToDouble((Convert.ToDouble(arrTotaliza[6])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label)e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_IND_MAT)).ToolTip = 
						Convert.ToDouble(arrTotaliza[6]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					((Label)e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_IND_MOB)).Text= 
						Convert.ToDouble((Convert.ToDouble(arrTotaliza[7])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label)e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_IND_MOB)).ToolTip = 
						Convert.ToDouble(arrTotaliza[7]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					((Label)e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_IND_SRV)).Text= 
						Convert.ToDouble((Convert.ToDouble(arrTotaliza[8])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label)e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_IND_SRV)).ToolTip = 
						Convert.ToDouble(arrTotaliza[8]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					//((Label) e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_IND_MAT)).Text=Convert.ToDouble(arrTotaliza[6]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					//((Label) e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_IND_MOB)).Text=Convert.ToDouble(arrTotaliza[7]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					//((Label) e.Item.Cells[6].FindControl(CONTROLMONTOTOTAL_IND_SRV)).Text=Convert.ToDouble(arrTotaliza[8]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					((Label)e.Item.Cells[7].FindControl(CONTROLMONTOTOTAL_PRO)).Text= 
						Convert.ToDouble((Convert.ToDouble(arrTotaliza[9])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label)e.Item.Cells[7].FindControl(CONTROLMONTOTOTAL_PRO)).ToolTip = 
						Convert.ToDouble(arrTotaliza[9]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					((Label)e.Item.Cells[7].FindControl(CONTROLMONTOTOTAL_EJE)).Text= 
						Convert.ToDouble((Convert.ToDouble(arrTotaliza[10])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label)e.Item.Cells[7].FindControl(CONTROLMONTOTOTAL_EJE)).ToolTip = 
						Convert.ToDouble(arrTotaliza[10]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					((Label)e.Item.Cells[7].FindControl(CONTROLMONTOTOTAL_DIF)).Text= 
						Convert.ToDouble((Convert.ToDouble(arrTotaliza[11])/Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label)e.Item.Cells[7].FindControl(CONTROLMONTOTOTAL_DIF)).ToolTip = 
						Convert.ToDouble(arrTotaliza[11]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					//((Label) e.Item.Cells[7].FindControl(CONTROLMONTOTOTAL_PRO)).Text=Convert.ToDouble(arrTotaliza[9]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					//((Label) e.Item.Cells[7].FindControl(CONTROLMONTOTOTAL_EJE)).Text=Convert.ToDouble(arrTotaliza[10]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					//((Label) e.Item.Cells[7].FindControl(CONTROLMONTOTOTAL_DIF)).Text=Convert.ToDouble(arrTotaliza[11]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
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
