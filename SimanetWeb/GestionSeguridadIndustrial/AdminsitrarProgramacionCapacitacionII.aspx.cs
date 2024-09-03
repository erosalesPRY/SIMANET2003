using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.Personal;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.Personal;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Configuration;

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for AdminsitrarProgramacionCapacitacionII.
	/// </summary>
	public class AdminsitrarProgramacionCapacitacionII : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtApellidos;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.Button btnBuscar;
		protected System.Web.UI.WebControls.Button btnEliminar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnEliminarProg;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
	
		string URLDETALLE="DetalleProgramacionCapacitacionII.aspx?";
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonal;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdProgCap;
		const string KEYQGRPROGACAP ="IdGrpprgCap";


		private void Page_Load(object sender, System.EventArgs e)
		{
			Page.GetPostBackEventReference(this, "MyEventArgumentName");
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Seguridad Industrial: Personal - Capacitación", this.ToString(),"Se consultó El Listado de personas capacitadas.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarDatos();
					this.LlenarCombos();
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
					this.LlenarJScript();

				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					Helper.MsgBox(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					Helper.MsgBox(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					Helper.MsgBox(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception oException)
				{
					string msg = oException.Message.ToString();
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
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdminsitrarProgramacionCapacitacionII.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdminsitrarProgramacionCapacitacionII.LlenarGrillaOrdenamiento implementation
		}
		DataTable ObtenerDatos()
		{
			return(new CCCTT_Grp_Capacitacion_Prog()).ListarTodosGrilla("0",Convert.ToInt32(this.hIdPersonal.Value));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.Sort         = columnaOrdenar;
				dv.RowFilter    = Utilitario.Helper.ObtenerFiltro();
				grid.DataSource = dv;
				grid.CurrentPageIndex     = indicePagina;
				
			}
			else
			{
				grid.DataSource = dt;
			}
			
			try
			{
				grid.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}						
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdminsitrarProgramacionCapacitacionII.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdminsitrarProgramacionCapacitacionII.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(this.hGridPagina.ID.ToString(),this.hGridPaginaSort.ID.ToString()));
			this.btnBuscar.Style.Add("display","none");
			this.btnEliminar.Style.Add("display","none");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdminsitrarProgramacionCapacitacionII.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdminsitrarProgramacionCapacitacionII.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdminsitrarProgramacionCapacitacionII.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdminsitrarProgramacionCapacitacionII.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdminsitrarProgramacionCapacitacionII.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLDETALLE+Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N.ToString(),false);
			
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
					string parametros = Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQGRPROGACAP +  Utilitario.Constantes.SIGNOIGUAL  + dr["IdGrpProgCap"].ToString();
					Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
													Helper.HistorialIrAdelantePersonalizado(this.hGridPagina.ID.ToString(),this.hGridPaginaSort.ID.ToString())
													,Helper.MostrarVentana(URLDETALLE,parametros)
													);

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hIdProgCap",dr["IdGrpProgCap"].ToString()));

				//Lista las areas responsable de cada capacitacion
				DataTable dtr=(new CCTT_CapacitacionProgResp()).ListarTodosGrilla(dr["IdGrpProgCap"].ToString());

				foreach(DataRow drr in dtr.Rows)
				{
					System.Web.UI.HtmlControls.HtmlTable mHtmlTable = Helper.CrearHtmlTabla(1,1,true);
					mHtmlTable.Border=0;
					mHtmlTable.Attributes["class"] ="BaseItemInGrid";
					mHtmlTable.Rows[0].Cells[0].InnerText=drr["NombreAreaResponsable"].ToString();
					mHtmlTable.Rows[0].Cells[0].Attributes["noWrap"] ="noWrap";
					mHtmlTable.Rows[0].Cells[0].Style.Add("cursor","hand");
					mHtmlTable.Rows[0].Cells[0].Style["COLOR"]="blue";
					mHtmlTable.Rows[0].Cells[0].Style["TEXT-DECORATION"]="underline";
					mHtmlTable.Rows[0].Cells[0].Attributes.Add(SIMA.Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"AdminsitrarProgramacionCapacitacionIIUI.ListarPersonalAsistencia('" + dr["Periodo"].ToString() +"','" + dr["IdSeleccion"].ToString() +"','" + drr["IdProgCap"].ToString() +"','" + drr["PeriodoProgCap"].ToString() +"','" + drr["RequiereEvaluacion"].ToString() +"')");
					
					//mHtmlTable.Rows[0].Cells[0].Controls.Add( (new ListarProgSeleccionPersonal()).HtmlImgPersonal(drr["NroDNI"].ToString(),((e.Item.ItemType == ListItemType.Item)?"EfectCircularItem.gif":"EfectCircularAlter.gif"),40,40));

					e.Item.Cells[3].Controls.Add(mHtmlTable);
				}

			}
		}

		private void btnBuscar_Click(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}

		private void btnEliminar_Click(object sender, System.EventArgs e)
		{
			(new CCCTT_Grp_Capacitacion_Prog()).Eliminar(hIdProgCap.Value);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}
	}
}
