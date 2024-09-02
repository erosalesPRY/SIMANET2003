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
using SIMA.Controladoras.Proyectos;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class PopupImpresionConsultaDeAgendaDirectorio : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		#endregion Controles

		#region Constantes
		
		//Ordenamiento
		
		//Columnas DataTable
	
		
		//Nombres de Controles
		
			
		
		//Paginas
		
												  
		//Key Session y QueryString
	


		//Otros
		const string GRILLAVACIA ="No existe ningún Proyecto.";  

		#endregion Constantes

		#region Variables			

		#endregion Variables

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{				
				try
				{
					this.ConfigurarAccesoControles();
					
					this.LlenarDatos();

					this.LlenarGrilla();

					this.Imprimir();
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
			CImpresion oCImpresion =  new CImpresion();
			DataTable dtImpresion =  oCImpresion.ObtenerDataImprimir();
			
			if(dtImpresion!=null)
			{
				DataView dwImpresion = dtImpresion.DefaultView;
				dwImpresion.Sort = oCImpresion.ObtenerColumnaOrdenamiento();
				grid.DataSource = dwImpresion;
				grid.CurrentPageIndex = oCImpresion.ObtenerIndicePagina();
			}
			else
			{
				lblResultado.Text = GRILLAVACIA;

			}
			grid.DataBind();
		}

		
		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarCombos implementation
			
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarDatos implementation

			lblTitulo.Text = CImpresion.ObtenerTituloReporte();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation

			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaDeCartasFianzas.Exportar implementation
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
			return true;
		}

		#endregion

		
	
		

		

		
	
		

	
	}
}

