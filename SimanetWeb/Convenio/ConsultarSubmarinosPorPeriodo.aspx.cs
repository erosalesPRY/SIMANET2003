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
using SIMA.Controladoras.Convenio;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;

namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Summary description for ConsultarSubmarinosPorPeriodo.
	/// </summary>
	public class ConsultarSubmarinosPorPeriodo : System.Web.UI.Page, IPaginaBase
	{
		#region
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblTituloSecundatio;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		#endregion

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
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Constantes
		//QueryString
		const string KEYQIDPERIODOAPOYOFASUB = "IdPeriodoApoyoFasub";
		const string KEYSIGLAS="Siglas";
		const string KEYPERIODO="Periodo";
		//Otros
		const string COLORDENAMIENTO="IdProyectoSubmarino";
		const string GRILLAVACIA="NO SE ENCONTRO NINGUN PROYECTO DE APOYO UNIDADES ";
		#endregion Contantes

		#region Variables
		private  double acumMontoAsignado=0;
		private  double acumMontoAprobado=0;
		private  double acumMontoEjecutado=0;
		private  double acumMontoEnEjecucion=0;
		private  double acumMontoComprometido=0;
		private  double acumMontoSaldo=0;

		#endregion Variables

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
		
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,true),Utilitario.Constantes.INDICEPAGINADEFAULT);

				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcion oSIMAExcepcion)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcion.Mensaje);					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarSubmarinosPorPeriodo.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarSubmarinosPorPeriodo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = new DataTable();
			DataTable dtSaldo = new DataTable();
			this.RetornaDataTableSubMarinos(ref dt,ref dtSaldo);
			string[] Columnas = new string[] {Enumerados.ApoyoUnidadSubMarinoColumnas.MontoAsignado.ToString(),
											   Enumerados.ApoyoUnidadSubMarinoColumnas.MontoAprobado.ToString(),
											   Enumerados.ApoyoUnidadSubMarinoColumnas.MontoEjecutado.ToString(),
											   Enumerados.ApoyoUnidadSubMarinoColumnas.MontoEnEjecucion.ToString(),
											   Enumerados.ApoyoUnidadSubMarinoColumnas.MontoComprometido.ToString(),
											   Enumerados.ApoyoUnidadSubMarinoColumnas.MontoSaldo.ToString()
										   };
			CFuncionesEspeciales OCFuncionesEspeciales=new CFuncionesEspeciales();

			this.LimpiarControlesWeb();
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.Sort = columnaOrdenar ;
			
				grid.DataSource = dw;
				grid.Columns[1].FooterText = dw.Count.ToString();
				//ibtnImprimir.Visible = true;
				lblResultado.Visible = false;



				if(dw.Count>0)
				{
					foreach(DataRowView drW in dw)
					{
					
						acumMontoAsignado= acumMontoAsignado +Convert.ToDouble(drW[2]);
						acumMontoAprobado=acumMontoAprobado + Convert.ToDouble(drW[3]);
						acumMontoEjecutado= acumMontoEjecutado + Convert.ToDouble(drW[4]);
						acumMontoEnEjecucion=acumMontoEnEjecucion + Convert.ToDouble(drW[5]);
						acumMontoComprometido=acumMontoComprometido+ Convert.ToDouble(drW[6]);
						acumMontoSaldo=acumMontoSaldo + Convert.ToDouble(drW[7]);
					}
				}

			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA + Page.Request.QueryString[KEYSIGLAS];
				//ibtnImprimir.Visible = false;
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
			// TODO:  Add ConsultarSubmarinosPorPeriodo.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarSubmarinosPorPeriodo.LlenarDatos implementation
			lblTitulo.Text+= " -" + Page.Request.QueryString[KEYSIGLAS] + "-" + Page.Request.QueryString[KEYPERIODO]; 
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarSubmarinosPorPeriodo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarSubmarinosPorPeriodo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarSubmarinosPorPeriodo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarSubmarinosPorPeriodo.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarSubmarinosPorPeriodo.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarSubmarinosPorPeriodo.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void LimpiarControlesWeb()
		{
			this.txtDescripcion.Text="";
			this.txtObservaciones.Text="";
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[0].Text=Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				string cadena="";

				cadena=Helper.MostrarDatosEnCajaTexto(this.txtDescripcion.ID.ToString(),dr[Enumerados.ApoyoUnidadSubMarinoColumnas.Descripcion.ToString()].ToString()) + 
					" ; " +Helper.MostrarDatosEnCajaTexto(this.txtObservaciones.ID.ToString(),dr[Enumerados.ApoyoUnidadSubMarinoColumnas.Observaciones.ToString()].ToString());
					
								
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,cadena);


			}	
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				
			
				//e.Item.Cells[1].Text = "TOTAL:";
				e.Item.Cells[2].Text = acumMontoAsignado.ToString("# ### ### ##0.00");
				e.Item.Cells[3].Text = acumMontoAprobado.ToString("# ### ### ##0.00");
				e.Item.Cells[4].Text = acumMontoEjecutado.ToString("# ### ### ##0.00");
				e.Item.Cells[5].Text = acumMontoEnEjecucion.ToString("# ### ### ##0.00");
				e.Item.Cells[6].Text = acumMontoComprometido.ToString("# ### ### ##0.00");
				e.Item.Cells[7].Text = acumMontoSaldo.ToString("# ### ### ##0.00");
			}
		}

		private string CadenaHtmlFooterGrillaColumna(string TextoMontoSaldo,string TextoMontoAcumulado)
		{
			string Cadena="<table width=100%><tr align='Right' class='FooterGrilla'><td width=100%>" + TextoMontoSaldo + "</td></tr><tr  align='Right' class='FooterGrilla'><td width=100%>"+ TextoMontoAcumulado +"</td></tr></table>";
			return Cadena;
		}

		private void RetornaDataTableSubMarinos(ref DataTable dtItemGrilla, ref DataTable dtItemSaldo)
		{
			CApoyoUnidadSubMarina oCApoyoUnidadSubMarina=new CApoyoUnidadSubMarina();
			DataTable  dt = oCApoyoUnidadSubMarina.ConsultarProyectosApoyoUnidadSubmarino(Convert.ToInt32(Page.Request.QueryString[KEYQIDPERIODOAPOYOFASUB]));

			DataView dw=dt.DefaultView;
			dw.RowFilter = Enumerados.ApoyoUnidadSubMarinoColumnas.IdProyectoSubmarino.ToString() + Utilitario.Constantes.SIGNODIFERENTEQUE + "1000";
			if(dw.Count>0)
			{
				dtItemGrilla = Helper.DataViewTODataTable(dw);
			}
			else
			{
				dtItemGrilla=null;
			}

			dw.RowFilter = "";
			dw.RowFilter = Enumerados.ApoyoUnidadSubMarinoColumnas.IdProyectoSubmarino.ToString() + Utilitario.Constantes.SIGNOIGUAL + "1000";
			if(dw.Count>0)
			{
				dtItemSaldo=Helper.DataViewTODataTable(dw);
			}
			else
			{
				dtItemSaldo=null;
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}
	}
}
