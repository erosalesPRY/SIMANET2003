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
using SIMA.Controladoras.GestionIntegrada;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using SIMA.EntidadesNegocio.GestionIntegrada;

namespace SIMA.SimaNetWeb.GestionIntegrada
{
	public class AdministrarResponsableSAM : System.Web.UI.Page,IPaginaBase
	{

		const string KEYQMODULO ="Personal ";
		const string KEYQCONSULTA ="Se consultó ";
		const string KEYQOPCION ="Programación de Personal Varios / Visitas";

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtPersonal;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtArea;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarJScript();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), 
						"Gestión Integrada:Asignacion de resposabilidad por area", this.ToString(),"Se ha consultado el lsitad de responsables por area",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina();
					this.LlenarGrillaOrdenamientoPaginacion("", 0);
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarResponsableSAM.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarResponsableSAM.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("ApellidosyNombres",System.Type.GetType("System.String"));
			dt.Columns.Add("NombreArea",System.Type.GetType("System.String"));
			DataRow row = dt.NewRow();
			row["ApellidosyNombres"] = "";
			row["NombreArea"] = "";
			dt.Rows.Add(row);
			dt.AcceptChanges();
			return dt;
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.Sort         = columnaOrdenar;
				grid.DataSource = dv;
				grid.CurrentPageIndex     = indicePagina;
			}
			else
			{
				grid.DataSource = dt;
			}
			grid.DataBind();
			
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarResponsableSAM.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarResponsableSAM.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarResponsableSAM.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarResponsableSAM.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarResponsableSAM.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarResponsableSAM.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarResponsableSAM.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarResponsableSAM.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
