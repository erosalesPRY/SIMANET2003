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
	/// Summary description for AdministrarCapacitacionListaAsistencia.
	/// </summary>
	public class AdministrarCapacitacionListaAsistencia : System.Web.UI.Page,IPaginaBase	
	{
		protected projDataGridWeb.DataGridWeb grid;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					/*this.ConfigurarAccesoControles();
					this.LlenarCombos();*/
					this.LlenarJScript();
					this.LlenarGrilla();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Seguridad Industrial: Registro de Personal (Contratista-Visita)", this.ToString(),"Se ingreso a la funcionalidad de  registro de Personal (Contratista-Visita)",Enumerados.NivelesErrorLog.I.ToString()));
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		DataTable ObtenerDatos(){
			return (new CCCTT_PersonaCapacitacionProg()).ListarTodosGrilla();
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				grid.DataSource = dt;
				
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

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarCapacitacionListaAsistencia.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarCapacitacionListaAsistencia.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarCapacitacionListaAsistencia.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarCapacitacionListaAsistencia.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarCapacitacionListaAsistencia.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarCapacitacionListaAsistencia.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarCapacitacionListaAsistencia.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarCapacitacionListaAsistencia.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarCapacitacionListaAsistencia.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarCapacitacionListaAsistencia.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
			
				e.Item.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.Ondblclick.ToString(),"CCTT_CapacitacionProgRespUI.SeleccionarProgramacionPersonal('"  + dr["IdSeleccion"].ToString() + "','" + dr["Periodo"].ToString() + "','"  + dr["Descripcion"].ToString() + "')");
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);		

			}
		}
	}
}
