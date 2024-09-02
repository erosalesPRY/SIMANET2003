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
using SIMA.Controladoras.GestionLogistica;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Proyectos
{
	public class ConsultarResumenCentroCostos : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  
	
		const string URL_OC="ConsultarOC_PorCC.aspx?";
		const string URL_OS="ConsultarOS_PorCC.aspx?";

		const string KEYIDCENTRO ="IdCentro";
		const string KEYCENTRO ="Centro";

		double CAMPO1 = 0;
		double CAMPO2 = 0;
		double CAMPO3 = 0;

		//Otros
		const string COLUMNALINEA ="linea";
		const string NOMBRECLASEFOOTERGRILLA ="FooterGrilla";

		const string MSGVERDT_OC ="Ver Órdenes de Compra";
		const string MSGVERDT_OS ="Ver Órdenes de Servicio";

		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlbModalidadCartaCredito;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCentro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		ArrayList arrTotal;
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
					this.LlenarCombos();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Centros Costo-SIMA",this.ToString(),"Se consultó Resumen Centros de Costo.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion("",Utilitario.Constantes.INDICEPAGINADEFAULT);
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
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}
		private DataTable ObtenerDatos()
		{
			CResumenOCompraOServicio oCResumenOCompraOServicio= new CResumenOCompraOServicio();
			DataTable dt = oCResumenOCompraOServicio.ConsultarResumenOrdenes_PorCC();
			return dt;
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.Sort = columnaOrdenar ;
				grid.DataSource = dwGeneral;
				grid.CurrentPageIndex = indicePagina;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				grid.Columns[1].FooterText = dwGeneral.Count.ToString();

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

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			#region ITEM
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				e.Item.Cells[2].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.MostrarVentana(URL_OC,
					KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + dr["COD_CC"].ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					KEYCENTRO + Utilitario.Constantes.SIGNOIGUAL + dr["NOM_COD_CC"].ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
					));

				e.Item.Cells[3].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.MostrarVentana(URL_OS,
					KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + dr["COD_CC"].ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					KEYCENTRO + Utilitario.Constantes.SIGNOIGUAL + dr["NOM_COD_CC"].ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
					));

				e.Item.Cells[2].Font.Underline=true;	
				e.Item.Cells[2].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[2].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hCodigo"));

				e.Item.Cells[3].Font.Underline=true;	
				e.Item.Cells[3].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[3].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hCodigo"));
			
				CAMPO1 += Convert.ToDouble(dr["OC"]);
				CAMPO2 += Convert.ToDouble(dr["OS"]);
				CAMPO3 += Convert.ToDouble(dr["TOTAL"]);

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}	
			#endregion

			#region FOOTER
			if (e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[2].Text = CAMPO1.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text = CAMPO2.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[4].Text = CAMPO3.ToString(Utilitario.Constantes.FORMATODECIMAL4);

				//e.Item.Cells[0].CssClass = NOMBRECLASEFOOTERGRILLA;
			}
			#endregion
			
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}


		private void RedireccionarPaginaPrincipal()
		{
		}
	}
}
