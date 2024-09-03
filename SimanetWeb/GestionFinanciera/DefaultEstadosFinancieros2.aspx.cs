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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionFinanciera;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionFinanciera
{
	/// <summary>
	/// Summary description for DefaultEstadosFinancieros2.
	/// </summary>
	public class DefaultEstadosFinancieros2 : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputText Text1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl myContent;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles	
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();			
					this.EstadosAuxiliales();
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}			
			
		}
		private void EstadosAuxiliales()
		{
		/*	obout_ASPTreeView_Pro_NET.Tree oTree;
			oTree = new obout_ASPTreeView_Pro_NET.Tree();
			oTree.TreeIcons_Path = "imagenes/tree/";
			//string tabla ="<table width='1000px' border=1 cellSpacing='0' cellPadding='0' style='FONT-SIZE: 10pt;FONT-FAMILY: Arial'><tr> <td width='30%'> Sistema</td> <td>Enero</td> <td>Febrero </td><td>Marzo </td><td>Abril</td><td>Mayo </td><td>junio </td><td>Julio </td><td>Agosto </td><td>Setimbre </td><td>Octubre </td><td> Noviembre </td><td>Diciembre </td>  </tr> </table>";

			oTree.Add("", "root", "Auxiliares", null, "book.gif", null);

			oTree.Add("root", "EFACC", "Cuentas por Cobrar", null, null, null);
			oTree.Add("root", "EFACP", "Cuentas por Pagar", null, null, null);
			oTree.Add("root", "EFAGA", "Gastos de Adminsitración", null, null, null);
			oTree.Add("root", "EFACTP", "Costos de Producción", null, null, null);
			oTree.Add("EFACTP", "EFACTP1", "Directos", null, null, null);
			oTree.Add("EFACTP", "EFACTP2", "Indirectos", null, null, null);
			oTree.Add("root", "EFIV", "Inversiones", null, null, null);
			oTree.Add("EFIV", "EFIV1", "Gastos no Ligados a Proyectos", null, null, null);
			oTree.Add("EFIV", "EFIV2", "Proyectos", null, null, null);


			//Write treeview to your page.
			string  strTree = oTree.HTML();
			int Long = 341;
			lblTreeAux.Text =strTree.Substring(1,((DateTime.Now.Year >=2005)? (strTree.Length -Long):strTree.Length-1));
			*/
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
			// TODO:  Add DefaultEstadosFinancieros2.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DefaultEstadosFinancieros2.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DefaultEstadosFinancieros2.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DefaultEstadosFinancieros2.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DefaultEstadosFinancieros2.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DefaultEstadosFinancieros2.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DefaultEstadosFinancieros2.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DefaultEstadosFinancieros2.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DefaultEstadosFinancieros2.Exportar implementation
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
			// TODO:  Add DefaultEstadosFinancieros2.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
