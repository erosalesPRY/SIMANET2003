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
using System.Reflection;
namespace SIMA.SimaNetWeb.General
{
	/// <summary>
	/// Summary description for AdministrarInterface.
	/// </summary>
	public class AdministrarInterface : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblSituacion;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlGenericControl tblModelo2;
		protected System.Web.UI.WebControls.Button btnEjecutar;
	
		string ParamArgument="";
		const string URLDETALLE="InterfaceParametros.aspx";

		private void Page_Load(object sender, System.EventArgs e)
		{
			ParamArgument=Page.Request.Params["__EVENTARGUMENT"];

			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Interface",this.ToString(),"Se consultó interfaces.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion("",0);
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
					Helper.MsgBox(oSIMAExcepcionDominio.Error.ToString());					
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
			this.hGridPaginaSort.ServerChange += new System.EventHandler(this.hGridPaginaSort_ServerChange);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarInterface.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarInterface.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt= (new CSIMA_Interfaces()).ListarInterface("");

			if(dt!=null)
			{
				grid.DataSource = dt;
				grid.CurrentPageIndex =indicePagina;
			}
			else
			{
				grid.DataSource = dt;
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
			// TODO:  Add AdministrarInterface.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarInterface.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarInterface.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarInterface.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarInterface.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarInterface.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarInterface.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarInterface.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarInterface.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarInterface.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarInterface.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarInterface.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarInterface.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarInterface.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarInterface.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarInterface.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarInterface.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarInterface.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			
		}

		private void hGridPaginaSort_ServerChange(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				//this.hModo.Value = ((Convert.ToInt32(dr[Enumerados.ColumnasProgramacionVisita.idUsuarioRegistro.ToString()])==CNetAccessControl.GetIdUser())? Utilitario.Enumerados.ModoPagina.M.ToString():Utilitario.Enumerados.ModoPagina.C.ToString());
				/*
				parametros = KEYQIDPROG + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnasProgramacionVisita.NroProgramacion.ToString()].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnasProgramacionVisita.Periodo.ToString()].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQMODO + Utilitario.Constantes.SIGNOIGUAL +"Visita"
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQIDUSUARIOREG + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnasProgramacionVisita.idUsuarioRegistro.ToString()].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + this.hModo.Value;
				*/
				

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,"EjecutarSP('"+ dr["NombreSP"].ToString() + "')");

				//				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				/*
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasProgramacionVisita.NroProgramacion.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hModo",this.hModo.Value)
					);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				*/

			}			
		}

		private void btnEjecutar_Click(object sender, System.EventArgs e)
		{
			string []oParamData = ParamArgument.Split('*');
			string []oParametros = oParamData[1].Split('@');
			(new CSIMA_Interfaces()).Ejecutar(oParamData[0].ToString(),oParametros);
		}

	

		
	}
}
