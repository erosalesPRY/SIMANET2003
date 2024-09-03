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

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.EEFFUNISYS
{
	/// <summary>
	/// Summary description for ProcesaryListarEstadosFinancieros.
	/// </summary>
	public class ProcesaryListarEstadosFinancieros : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlAño;
		protected System.Web.UI.WebControls.DropDownList ddlMes;
		protected System.Web.UI.WebControls.DropDownList ddlFormato;
		protected System.Web.UI.WebControls.Button btnProcesar;
		protected System.Web.UI.WebControls.Button btnImprimir;
		protected System.Web.UI.WebControls.Label lblResultado;
	

		ListItem item;

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarGrilla();
					this.LlenarCombos();
					Helper.ReestablecerPagina();
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
			this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
			this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ProcesaryListarEstadosFinancieros.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ProcesaryListarEstadosFinancieros.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ProcesaryListarEstadosFinancieros.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			llenarPeriodo();
			llenarMes();
		}
		private void llenarPeriodo()
		{
			CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			ddlAño.DataSource = oCPeriodoContable.ListarPeriodo();
			ddlAño.DataValueField="Periodo";
			ddlAño.DataTextField="Periodo";
			ddlAño.DataBind();
			item = ddlAño.Items.FindByValue(SIMA.Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Year.ToString());
			if(item!=null)
			{item.Selected = true;}
		}
		private void llenarMes()
		{
			CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			//ddlbPeriodo.DataSource = oCPeriodoContable.ListarPeriodo();
			ddlMes.DataSource = oCPeriodoContable.ListarMes();
			ddlMes.DataValueField=Enumerados.Mes.idMes.ToString();
			ddlMes.DataTextField=Enumerados.Mes.NombreMes.ToString();
			ddlMes.DataBind();
			item = ddlMes.Items.FindByValue(SIMA.Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Month.ToString());
			if(item!=null)
			{item.Selected = true;}
		}
		public void LlenarDatos()
		{
			// TODO:  Add ProcesaryListarEstadosFinancieros.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			btnImprimir.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.HistorialIrAdelantePersonalizado("ddlMes","ddlFormato")+Helper.PopupDeEspera());
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ProcesaryListarEstadosFinancieros.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ProcesaryListarEstadosFinancieros.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ProcesaryListarEstadosFinancieros.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ProcesaryListarEstadosFinancieros.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ProcesaryListarEstadosFinancieros.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void btnProcesar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(Convert.ToInt32(this.ddlFormato.SelectedValue)==0)
				{
					Helper.MsgBox("PROCESAR","No se ha seleccionado formarto a procesar",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
					return;
				}
				else if(Convert.ToInt32(this.ddlFormato.SelectedValue)==1)
				{
					(new CEEFF_Unisys()).Procesar(1,Convert.ToInt32(this.ddlAño.SelectedValue),Convert.ToInt32(this.ddlMes.SelectedValue),Convert.ToInt32(this.ddlFormato.SelectedValue),1,'A');
					(new CEEFF_Unisys()).Procesar(1,Convert.ToInt32(this.ddlAño.SelectedValue),Convert.ToInt32(this.ddlMes.SelectedValue),Convert.ToInt32(this.ddlFormato.SelectedValue),1,'P');
				}
				else
				{
					(new CEEFF_Unisys()).Procesar(1,Convert.ToInt32(this.ddlAño.SelectedValue),Convert.ToInt32(this.ddlMes.SelectedValue),Convert.ToInt32(this.ddlFormato.SelectedValue),1,' ');
				}
				Helper.MsgBox("PROCESAR","Se ha culminado el proceso de los estados financieros",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
			}
			catch(Exception ex){
				Helper.MsgBox("Error",ex.Message.ToString(),SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
			}

		}

		private void btnImprimir_Click(object sender, System.EventArgs e)
		{
			DataSet ds = new DataSet();
			
			if(Convert.ToInt32(this.ddlFormato.SelectedValue)==1)
			{
				
				DataTable dt1 =  Helper.DataViewTODataTable((new CEEFF_Unisys()).ListarCabecera(Convert.ToInt32(this.ddlAño.SelectedValue),Convert.ToInt32(this.ddlMes.SelectedValue)).DefaultView);
				string Nombre = "EEFF_uspNTADProcesarFormatoUNISYS_CAB;1";
				dt1.TableName=Nombre;
				ds.Tables.Add(dt1);


				DataTable dt2 =  Helper.DataViewTODataTable((new CEEFF_Unisys()).ListarDetalle(1,Convert.ToInt32(this.ddlAño.SelectedValue),Convert.ToInt32(this.ddlMes.SelectedValue),Convert.ToInt32(this.ddlFormato.SelectedValue),1,'A').DefaultView);
				Nombre = "EEFF_uspNTADProcesarFormatoUNISYS;1";
				dt2.TableName=Nombre;
				ds.Tables.Add(dt2);


				DataTable dt3 =  Helper.DataViewTODataTable((new CEEFF_Unisys()).ListarDetalle(1,Convert.ToInt32(this.ddlAño.SelectedValue),Convert.ToInt32(this.ddlMes.SelectedValue),Convert.ToInt32(this.ddlFormato.SelectedValue),1,'P').DefaultView);
				Nombre = "EEFF_uspNTADProcesarFormatoUNISYS_P;1";
				dt3.TableName=Nombre;
				ds.Tables.Add(dt3);


				Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\Contabilidad\","EEFF_Balance_General.rpt",ds,true);
			}
			else{
				DataTable dt1 =   Helper.DataViewTODataTable((new CEEFF_Unisys()).ListarDetalle(1,Convert.ToInt32(this.ddlAño.SelectedValue),Convert.ToInt32(this.ddlMes.SelectedValue),Convert.ToInt32(this.ddlFormato.SelectedValue),1,' ').DefaultView);
				string Nombre = "EEFF_uspNTADProcesarFormatoUNISYS;1";
				dt1.TableName=Nombre;
				ds.Tables.Add(dt1);

				Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\Contabilidad\","EEFFGananciasyPerdidasF.rpt",ds,true);

			}
			
		}
	}
}
