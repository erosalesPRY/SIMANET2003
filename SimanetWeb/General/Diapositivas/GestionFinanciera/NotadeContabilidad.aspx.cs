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
	/// Summary description for NotadeContabilidad.
	/// </summary>
	public class NotadeContabilidad : System.Web.UI.Page,IPaginaBase
	{
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

			}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add NotadeContabilidad.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add NotadeContabilidad.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add NotadeContabilidad.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			}

		public void LlenarJScript()
		{
			// TODO:  Add NotadeContabilidad.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add NotadeContabilidad.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add NotadeContabilidad.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add NotadeContabilidad.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add NotadeContabilidad.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add NotadeContabilidad.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
