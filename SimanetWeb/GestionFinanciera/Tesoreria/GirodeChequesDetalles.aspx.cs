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

//using Microsoft.Office.Core;
using Excel= Microsoft.Office.Interop.Excel;

namespace SIMA.SimaNetWeb.GestionFinanciera.Tesoreria
{

	/// </summary>
	public class GirodeChequesDetalles: System.Web.UI.Page
	{
		
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.WebControls.Label lblruc;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
					
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
			            		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
							
				try
				{
					//Registrar Evento
					//this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
											
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Tesoreria",this.ToString(),"Se consultó las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));
								
					Helper.SeleccionarItemCombos(this);
					this.LlenarGrillaCheques(hCodigo.Value,0);
					//Helper.CrearContextMenuPopup(this,grid);
					this.LlenarCombos();
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
					ASPNetUtilitario.MessageBox.Show("Error de Paginación");
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
					                       
				}	
			}			

		}

		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}

		public void LlenarGrillaCheques(string columnaOrdenar, int indicePagina)
		{
						
		}

		public class WebForm1 : System.Web.UI.Page
		{
	

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
//			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		}
		
		public void LlenarCombos()
		{
		
		}
		
		public void LlenarDatos()
		{
				// TODO:  Add GirodeChequesDetalles.LlenarDatos implementation
		}
		
		public void LlenarJScript()
		{
		
		}
		
		public void ConfigurarAccesoControles()
        {

		}
		
		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarGirodeChequesDetalles.ValidarFiltros implementation
			return false;
		}

//		private DataTable ObtenerDatos()
//		{
//			return false
//			
//		}

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
		/// 

		#endregion
				
	}

}

