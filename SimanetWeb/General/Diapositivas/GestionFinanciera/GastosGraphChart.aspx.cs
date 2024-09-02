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
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.EntidadesNegocio.General;

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using System.IO;
using Microsoft.Office.Core;
using Excel= Microsoft.Office.Interop.Excel;


namespace SIMA.SimaNetWeb.General.Diapositivas.GestionFinanciera
{
	/// <summary>
	/// Summary description for GastosGraphChart.
	/// </summary>
	public class GastosGraphChart : System.Web.UI.Page,IPaginaBase
	{
		const string KEYQIDFORMATO="IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO ="IdRubro";
		const string KEYQPERIODO = "Periodo";
		const string KEYQIDMES = "IdMes";
		const string IDCENTROOPERATIVO="idcop";
		const string KEYQIDTIPOINFO ="idTipoInfo";
		const string KEYQACUMULADO="Acum";
		const string KEYQIDOBJETO="IdObj";

		private int IdFormato
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);}
		}
		public int IdReporte
		{
			get{ return Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);}
		}

		public string IdCentroOperativo
		{
			get{return Page.Request.Params[IDCENTROOPERATIVO].ToString();}
		}

		public int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}

		public int IdTipoInformacion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO]);}
		}
		public int IdMes
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDMES]);}
		}

		public int IdObjeto
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDOBJETO]);}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarGrilla();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera: Administrar Formatos Financieros mensualizados", this.ToString(),"Se consultó Listado de formtatos financieros",Enumerados.NivelesErrorLog.I.ToString()));
					
				}
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
				string debug = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
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
			/*string strIn  ="(1,6,9,19,28)";
			grid.ID="R1"+ IdFormato.ToString()+"_"+this.IdReporte.ToString()+"_"+ this.IdObjeto.ToString();		
			DataTable dt = (new  CEstadosFinancierosDirectorio()).ListarFormatoAnual(this.IdFormato,this.IdReporte, "2" ,this.Periodo,this.IdMes,this.IdTipoInformacion);
			if(dt!=null)
			{
				DataView dv = dt.DefaultView;
				dv.RowFilter="IdRubro in" + strIn ;
				grid.DataSource =  dv;
			}
			else
			{
				grid.DataSource = dt;
			}
			grid.DataBind();*/
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GastosGraphChart.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GastosGraphChart.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add GastosGraphChart.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add GastosGraphChart.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add GastosGraphChart.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GastosGraphChart.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add GastosGraphChart.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add GastosGraphChart.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add GastosGraphChart.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add GastosGraphChart.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}

		private void grid2_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}
	}
}
