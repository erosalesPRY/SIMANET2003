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
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for PopupImprimirRegistroProyectosMM.
	/// </summary>
	public class PopupImprimirRegistroProyectosMM : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarGrilla();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),"",Enumerados.NivelesErrorLog.I.ToString()));			
					ltlMensaje.Text=Helper.Imprimir();
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
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			DataTable dt =  oCMantenimientos.ListarTodosGrilla(Utilitario.Enumerados.ClasesNTAD.ProyectosMMNTAD.ToString());
			
			if(dt!=null)
			{
				DataView dw= dt.DefaultView;
				dw.Sort = "CLIENTE" ;
				dw.RowFilter = Utilitario.Helper.ObtenerFiltro();

				if (dw.Count == Utilitario.Constantes.ValorConstanteCero)
				{
					grid.DataSource = null; 
					
					lblResultado.Visible = true;
				}
				else
				{
					grid.DataSource = dw;
					grid.Columns[2].FooterText=dw.Count.ToString();
					lblResultado.Visible = false;
				}
			}
			else
			{
				grid.DataSource = dt;
			}
			
			try
			{
				grid.DataBind();
			}
			catch (Exception a)
			{
				string b = a.Message.ToString();
				grid.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				grid.DataBind();
			}

		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImprimirRegistroProyectosMM.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PopupImprimirRegistroProyectosMM.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImprimirRegistroProyectosMM.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add PopupImprimirRegistroProyectosMM.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImprimirRegistroProyectosMM.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImprimirRegistroProyectosMM.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add PopupImprimirRegistroProyectosMM.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add PopupImprimirRegistroProyectosMM.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add PopupImprimirRegistroProyectosMM.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add PopupImprimirRegistroProyectosMM.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
