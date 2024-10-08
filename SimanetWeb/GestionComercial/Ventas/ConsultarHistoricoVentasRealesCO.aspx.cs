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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for ConsultarHistoricoVentasRealesCO.
	/// </summary>
	public class ConsultarHistoricoVentasRealesCO: System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb dgConsulta;
		protected projDataGridWeb.DataGridWeb dgConsultaLN;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnGraficoBarraPorCOyLN;
		protected System.Web.UI.WebControls.Image imgExposicion;
		#endregion

		#region Constantes
		
		//Ordenamiento

		//JScript

		//Columnas DataTable

		//Nombres de Controles

		//Paginas
		const string URLIMPRESION = "PopupImpresionConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.aspx";
		const string URLHISTORICOVENTASEJECUTADASPORCOYLN = "../Reportes/GraficoHistoricoVentasEjecutadasPorCOyLN.aspx?";
	
		//Key Session y QueryString
				
		//Otros
		const string GRILLAVACIA ="No existe ninguna Venta Ejecutada y ninguna Venta Presupuestada.";
		const string NombreGlosaTotales = "TOTAL";

		//Nombre de Archivos
		const string Exposicion = "Exposicion_2006.ppt";
		
		#endregion Constantes

		#region Variables
		const int ANCHO = 70;
		const int MULTIPLO = 8;
		const string GLOSATOTAL ="TOTAL";
		double [] montos;
		int [] anchos;
		double [] montosLN;
		int [] anchosLN;
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
					//Graba en el Log la acci�n ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consulto el Historico de las Ventas Reales por Centro Operativo",Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarGrilla();
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
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.ibtnGraficoBarraPorCOyLN.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGraficoBarraPorCOyLN_Click);
			this.dgConsulta.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsulta_ItemDataBound);
			this.dgConsulta.SelectedIndexChanged += new System.EventHandler(this.dgConsulta_SelectedIndexChanged);
			this.dgConsultaLN.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsultaLN_ItemDataBound);
			this.dgConsultaLN.SelectedIndexChanged += new System.EventHandler(this.dgConsultaLN_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			//Grilla CO
			CVentasReales oCVentasReales =  new CVentasReales();
			DataTable dtVentas =  oCVentasReales.ConsultarHistoricoVentasRealesPorCentroOperativo(Helper.FechaSimanet.ObtenerFechaSesion().Year);

			if(dtVentas!=null)
			{
				DataView dwVentas = dtVentas.DefaultView;
				dgConsulta.DataSource = dwVentas;
				montos = new double[dtVentas.Columns.Count];
				anchos = this.CalcularAnchos(dtVentas);
				dgConsulta.Width = this.CalcularAnchoTotal(anchos);
			}
			else
			{
				dgConsulta.DataSource = dtVentas;
			}
			
			try
			{
				dgConsulta.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				dgConsulta.CurrentPageIndex = 0;
				dgConsulta.DataBind();
			}

			//Grilla LN
			oCVentasReales =  new CVentasReales();
			DataTable dtVentasLN =  oCVentasReales.ConsultarHistoricoVentasDesagregadoPorLineaNegocio(Helper.FechaSimanet.ObtenerFechaSesion().Year);
			
			if(dtVentasLN!=null)
			{
				DataView dwVentasLN = dtVentasLN.DefaultView;
				dgConsultaLN.DataSource = dwVentasLN;
				lblResultado.Visible = false;
				montosLN = new double[dtVentasLN.Columns.Count];
				anchosLN = this.CalcularAnchos(dtVentasLN);
				dgConsultaLN.Width = this.CalcularAnchoTotal(anchosLN);
			}
			else
			{
				dgConsultaLN.DataSource = dtVentasLN;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				dgConsultaLN.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				dgConsultaLN.CurrentPageIndex = 0;
				dgConsultaLN.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarHistoricoVentasRealesCO.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarHistoricoVentasRealesCO.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarHistoricoVentasRealesCO.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarHistoricoVentasRealesCO.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnGraficoBarraPorCOyLN.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnGraficoBarraPorCOyLN.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);

			if(Exposicion != Utilitario.Constantes.VACIO)
			{
				this.imgExposicion.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(
					Helper.ObtenerRutaImagenes(Utilitario.Constantes.RUTASERVERARCHIVOSGERENCIACOMERCIAL) + Exposicion));

				this.imgExposicion.Attributes.Add(Utilitario.Constantes.EVENTOONMOUSEOVER,"CambiarColorPasarMouse(this, true);");
			}
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarHistoricoVentasRealesCO.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarHistoricoVentasRealesCO.Exportar implementation
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
			return false;
		}

		#endregion

		private void dgConsulta_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[Constantes.POSICIONCONTADOR].Width = anchos[Constantes.POSICIONCONTADOR];
				e.Item.Cells[Constantes.POSICIONCONTADOR].HorizontalAlign = HorizontalAlign.Left;
				for(int i=1;i<e.Item.Cells.Count;i++)
				{
					montos[i] = montos[i] + Convert.ToDouble(e.Item.Cells[i].Text);
					e.Item.Cells[i].Width = anchos[i];
					e.Item.Cells[i].HorizontalAlign = HorizontalAlign.Right;
					e.Item.Cells[i].Text = Convert.ToDouble(e.Item.Cells[i].Text).ToString(Constantes.FORMATODECIMAL4);
				}

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = GLOSATOTAL;
				e.Item.Cells[Constantes.POSICIONCONTADOR].Width = anchos[Constantes.POSICIONCONTADOR];
				e.Item.Cells[Constantes.POSICIONCONTADOR].HorizontalAlign = HorizontalAlign.Left;
				for(int i=1;i<e.Item.Cells.Count;i++)
				{
					e.Item.Cells[i].Text = montos[i].ToString(Constantes.FORMATODECIMAL4);
					e.Item.Cells[i].Width = anchos[i];
					e.Item.Cells[i].HorizontalAlign = HorizontalAlign.Right;
				}
				Helper.ConfigurarColorTotalesGrilla(e);
			}
		}

		private void dgConsultaLN_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[Constantes.POSICIONCONTADOR].Width = anchos[Constantes.POSICIONCONTADOR];
				e.Item.Cells[Constantes.POSICIONCONTADOR].HorizontalAlign = HorizontalAlign.Left;
				for(int i=1;i<e.Item.Cells.Count;i++)
				{
					e.Item.Cells[i].Width = anchos[i];
					e.Item.Cells[i].HorizontalAlign = HorizontalAlign.Right;
					e.Item.Cells[i].Text = Convert.ToDouble(e.Item.Cells[i].Text).ToString(Constantes.FORMATODECIMAL4);
				}

				if(e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaTotales))
				{
					Helper.ConfigurarColorTotalesGrilla(e);
				}
				else
				{
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				}
			}
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private int[] CalcularAnchos(DataTable dt)
		{
			int [] array = new int[dt.Columns.Count];
			array[Constantes.POSICIONCONTADOR] = ANCHO;
			for(int i=1;i<dt.Columns.Count;i++)
			{
				array[i] = dt.Columns[i].ColumnName.Length;
				for(int j=0;j<dt.Rows.Count;j++)
				{
					if(dt.Rows[j][i].ToString().Length > array[i])
					{
						array[i] = dt.Rows[j][i].ToString().Length;
					}
				}
			}
			for(int k=1;k<array.Length;k++)
			{
				array[k] *= MULTIPLO;
			}
			return array;
		}

		private int CalcularAnchoTotal(int[] ancho)
		{
			int MontoTotal = 0;
			foreach(int i in ancho)
			{
				MontoTotal += i;
			}

			return MontoTotal;
		}

		private void ibtnGraficoBarraPorCOyLN_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLHISTORICOVENTASEJECUTADASPORCOYLN);
		}

		private void dgConsultaLN_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dgConsulta_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}