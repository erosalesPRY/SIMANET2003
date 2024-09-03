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

namespace SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras
{
	/// <summary>
	/// Summary description for AdministrarLetrasRenovaciones.
	/// </summary>
	public class AdministrarLetrasRenovaciones : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string GRILLAVACIA ="No existe ningún Registro de Renovación de Letras .";  
			const string KEYIDDOCLET ="idDocLetra";
		#endregion
		#region Controles
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label Label5;
			protected System.Web.UI.WebControls.Label Label6;
			protected System.Web.UI.WebControls.Label Label7;
			protected System.Web.UI.WebControls.Label lblMontoLetra;
			protected System.Web.UI.WebControls.Label lblSaldo;
			protected eWorld.UI.NumericBox nMonto;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.WebControls.Label Label1;
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
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarCombos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					//Helper.ReestablecerPagina(this);
					this.LlenarGrillaOrdenamientoPaginacion("",0);
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
			// TODO:  Add AdministrarLetrasRenovaciones.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarLetrasRenovaciones.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return ((CLetrasRenovacion) new CLetrasRenovacion()).AdministrarRenovaciondeLetras(Page.Request.Params[KEYIDDOCLET].ToString());
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtLetras=this.ObtenerDatos();
			if(dtLetras!=null)
			{
				DataView dwLetras= dtLetras.DefaultView;
				dwLetras.RowFilter = Helper.ObtenerFiltro();
				//grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwLetras.Count.ToString();
				dwLetras.Sort = columnaOrdenar ;
				grid.DataSource = dwLetras;
				grid.CurrentPageIndex = indicePagina;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtLetras;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string msg = ex.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarLetrasRenovaciones.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarLetrasRenovaciones.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarLetrasRenovaciones.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarLetrasRenovaciones.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarLetrasRenovaciones.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarLetrasRenovaciones.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarLetrasRenovaciones.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarLetrasRenovaciones.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
