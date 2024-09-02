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
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for PoppupImpresionProgramacionActividades.
	/// </summary>
	public class PoppupImpresionProgramacionActividades : System.Web.UI.Page,IPaginaBase
	{
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Literal ltlMensaje;  
	
		const string KEYQPERIODO = "Validacion";
		const string GRILLAVACIA="No existe Registros";

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
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se consultó las Programaciones de Inspecciones.",Enumerados.NivelesErrorLog.I.ToString()));
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
			CProgramacionInspecciones oCProgramacionInspecciones=  new CProgramacionInspecciones();
			DataTable dtProgramacionInspecciones =  oCProgramacionInspecciones.ConsultarProgramacionesInspeccionesPorPeriodo(
				Convert.ToInt32(Page.Request.QueryString[KEYQPERIODO]));

			if(dtProgramacionInspecciones!=null)
			{
				DataView dwProgramacionInspecciones = dtProgramacionInspecciones.DefaultView;
				dwProgramacionInspecciones.Sort = "Organismo" ;
				dwProgramacionInspecciones.RowFilter= Utilitario.Helper.ObtenerFiltro(this);
				grid.DataSource = dwProgramacionInspecciones;
				//grid.CurrentPageIndex =indicePagina;

				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwProgramacionInspecciones.Count.ToString();

				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtProgramacionInspecciones;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
			}
			
			try
			{
				grid.DataBind();
			}
			catch (Exception a)
			{
				string b = a.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PoppupImpresionProgramacionActividades.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			
			
		}

		public void LlenarCombos()
		{
			// TODO:  Add PoppupImpresionProgramacionActividades.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text="REPORTE DE PROGRAMACION DE ACTIVIDADES";
		}

		public void LlenarJScript()
		{
			// TODO:  Add PoppupImpresionProgramacionActividades.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PoppupImpresionProgramacionActividades.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PoppupImpresionProgramacionActividades.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add PoppupImpresionProgramacionActividades.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add PoppupImpresionProgramacionActividades.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
