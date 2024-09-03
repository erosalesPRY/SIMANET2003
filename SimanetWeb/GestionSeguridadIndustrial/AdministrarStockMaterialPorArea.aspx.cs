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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using System.Drawing;

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for AdministrarStockMaterialPorArea.
	/// </summary>
	public class AdministrarStockMaterialPorArea : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hLstAreas;
		protected System.Web.UI.WebControls.Label Label1;
		protected projDataGridWeb.DataGridWeb  ItemsGrid;
	
		string demo;
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Programación Personal Contratista", this.ToString(),"Se consultó El Listado de las programaciones de los contratistas",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina();
					this.LlenarGrilla();
					string x=demo;
					//this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
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

		private void dGeneral_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		}
		private void dGeneral_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{}
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
			string lstAreas="";

			DataTable dtAccesoArea = (new CCCTT_StockMaterialPorArea()).ListarAccesoUsuarioArea();
			if((dtAccesoArea!=null) &&(dtAccesoArea.Rows.Count>0 ))
			{
				foreach(DataRow dr in dtAccesoArea.Rows)
				{
					lstAreas = lstAreas + dr["Cod_aus"].ToString() +";" + dr["nom_aus"].ToString()+"@";
				}
				hLstAreas.Value=lstAreas.Substring(0,lstAreas.Length-1);
			}
			else{
				Helper.MsgBox("ACCESOS","Solicite el acceso al area o areas que desea administrar",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
			}
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarStockMaterialPorArea.LlenarGrillaOrdenamiento implementation
		}
		DataTable ObtenerDatos()
		{
			return(new CCCTT_StockMaterialPorArea()).Listar("");
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{

			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.Sort         = columnaOrdenar;
				dv.RowFilter    = Utilitario.Helper.ObtenerFiltro();
				ItemsGrid.DataSource = dv;
				ItemsGrid.CurrentPageIndex = indicePagina;
			}
			else
			{
				ItemsGrid.DataSource = dt;
			}
			
			try
			{
				ItemsGrid.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				ItemsGrid.CurrentPageIndex = 0;
				ItemsGrid.DataBind();
			}				
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.LlenarDatos implementation
		}

		public void LlenarJScript()
		{

		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarStockMaterialPorArea.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	}
}
