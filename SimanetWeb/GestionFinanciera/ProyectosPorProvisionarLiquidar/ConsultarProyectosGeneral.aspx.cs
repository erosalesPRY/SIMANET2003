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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionFinanciera.ProyectosPorProvisionarLiquidar
{
	public class ConsultarProyectosGeneral : System.Web.UI.Page, IPaginaBase
	{
		const string LIQUIDADO = "CON";

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			DataTable dtProyectos =  ObtenerDatos();
			
			if(dtProyectos!=null)
			{
				DataView dwProyectos = dtProyectos.DefaultView;
				dwProyectos.RowFilter = Helper.ObtenerFiltro(this);
				if(dwProyectos.Count>0)
				{
					grid.DataSource = dwProyectos;
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				
			}
			else
			{
				grid.DataSource = dtProyectos;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public DataTable ObtenerDatos()
		{
			CProyectosPorLiquidarProvisionar oCProyectosPorLiquidarProvisionar = new CProyectosPorLiquidarProvisionar();
			return oCProyectosPorLiquidarProvisionar.ConsultarProyectosPorLiquidarProvisionarGeneral();
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
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
			return true;
		}

		#endregion
		#region Constantes
		private const string MENSAJECONSULTAR="Se Consulto Proyectos Por Liquidar/Provisionar";
		private const string URLDETALLEGENERAL="ConsultarProyectoPorLiquidarProvisionar.aspx?";
		private const string GRILLAVACIA="No existen registros";
		private const string KEYIDSIT="KEYIDSIT";
		#endregion
		#region Variables
		private double Callao=0;
		private double Chimbote=0;
		private double Peru=0;
		private double Iquitos=0;
		private double Total=0;
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		#endregion
		#region Eventos
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarGrilla();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestionFinanciera.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));			
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

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
            if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if (dr[Enumerados.FINColumnaProyectosPorProvisionarLiquidar.Sit.ToString()].ToString() == LIQUIDADO)
				{
					e.Item.Cells[0].Style.Add(Constantes.CURSOR,Constantes.TIPOCURSORMANO);

					Callao+=Convert.ToDouble(dr[Enumerados.FINColumnaProyectosPorProvisionarLiquidar.SimaCallao.ToString()]);
					Chimbote+=Convert.ToDouble(dr[Enumerados.FINColumnaProyectosPorProvisionarLiquidar.SimaChimbote.ToString()]);
					Peru+=Convert.ToDouble(dr[Enumerados.FINColumnaProyectosPorProvisionarLiquidar.SimaPeru.ToString()]);
					Iquitos+=Convert.ToDouble(dr[Enumerados.FINColumnaProyectosPorProvisionarLiquidar.SimaIquitos.ToString()]);
					Total+=Convert.ToDouble(dr[Enumerados.FINColumnaProyectosPorProvisionarLiquidar.Total.ToString()]);

					e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE );

					e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
					e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor = Color.Blue;

					e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLEGENERAL,KEYIDSIT + 
						Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.FINColumnaProyectosPorProvisionarLiquidar.Sit.ToString()]
						)+
						Utilitario.Constantes.POPUPDEESPERA);
				
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				}
				else
				{
					e.Item.Visible=false;
				}
			}
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[1].Text = Callao.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[2].Text = Chimbote.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text = Peru.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[4].Text = Iquitos.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = Total.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}
		#endregion
	}
}
