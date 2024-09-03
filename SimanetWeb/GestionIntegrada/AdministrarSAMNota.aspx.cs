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
using SIMA.Controladoras.GestionIntegrada;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.GestionIntegrada;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Configuration;

namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for AdministrarSAMNota.
	/// </summary>
	public class AdministrarSAMNota : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.HtmlControls.HtmlTableCell CellLstCausaRaiz;
		protected System.Web.UI.WebControls.DataGrid Grid;

		const string KEYQIDSAMISO = "IdSamISO";
		const string KEYQIDTIPONORMA = "TNorma";

		
		public string IdSamISO
		{
			get{return Page.Request.Params[KEYQIDSAMISO].ToString();}
		}
		public int IdTipoNorma
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPONORMA].ToString());}
		}


	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Integrada: Administrar Becados", this.ToString(),"Se consultó El Listado de las Capacitaciones en el Extranjero.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarDatos();
					this.LlenarGrilla();
					this.LlenarJScript();

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
					string msg = oException.Message.ToString();
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


		private DataTable ListarResponsable()
		{
			return (new CSAMResponsableISON()).Listar(this.IdTipoNorma);
		}

		private DataTable ObtenerDatos()
		{
			return null;//(new CSAMNota()).Listar(this.IdSamISO);
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();

			if (dt!=null)
			{
				Grid.DataSource = dt;
				//this.lblResultado.Visible = false;
			}
			else
			{
				Grid.DataSource = dt;
				//this.lblResultado.Visible = true;
				//this.lblResultado.Text    = GRILLAVACIA;
			}
			
			try
			{
				Grid.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				Grid.DataBind();
			}				
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarSAMNota.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarSAMNota.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarSAMNota.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarSAMNota.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarSAMNota.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarSAMNota.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarSAMNota.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarSAMNota.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarSAMNota.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarSAMNota.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
