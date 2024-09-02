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

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class PopupImpresionConsultarPresentesOtorgadosPorTipoPersona : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DataGrid grid;

		#endregion Controles

		#region Constantes
		
		//Key Session y QueryString
		const string KEYQPOSICIONCOMBO = "KEYPOSICIONCOMBO";
		
		//Otros
		const string COLORDENAMIENTO = "NombreClientePersonal";
		const int POSICIONINICIALCOMBO = 0;
		const int CantidadCero = 0;
		const string GRILLAVACIA ="No existe ningun Presente Otorgado con los filtros seleccionados.";
		const int ColumnaCentroOperativo = 0;
		const int ColumnaCargo = 1;
		const int ColumnaGrado = 2;
		const int ColumnaTelefono = 4;

		#endregion Constantes

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
				catch(SIMAExcepcion oSIMAExcepcion)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcion.Mensaje);					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
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

				if(dwImpresion.Count > CantidadCero)
				{
					grid.DataSource = dwImpresion;
					lblResultado.Visible = false;
					grid.CurrentPageIndex = oCImpresion.ObtenerIndicePagina();

					if(Page.Request.QueryString[KEYQPOSICIONCOMBO] == Convert.ToInt32(Enumerados.TiposOrigenVistaEntidad.Cliente).ToString())
					{
						this.OcultarColumnasCliente();
					}
					else if(Page.Request.QueryString[KEYQPOSICIONCOMBO] == Convert.ToInt32(Enumerados.TiposOrigenVistaEntidad.Personal).ToString())
					{
						this.OcultarColumnasPersonal();
					}
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
			}
			else
			{
				grid.DataSource = dtImpresion;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionConsultarPresentesOtorgadosPorTipoPersona.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add PopupImpresionConsultarPresentesOtorgadosPorTipoPersona.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionConsultarPresentesOtorgadosPorTipoPersona.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporte();
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionConsultarPresentesOtorgadosPorTipoPersona.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionConsultarPresentesOtorgadosPorTipoPersona.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
		 	ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionConsultarPresentesOtorgadosPorTipoPersona.Exportar implementation
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

		private void OcultarColumnasCliente()
		{
			grid.Columns[ColumnaCentroOperativo].Visible = false;
			grid.Columns[ColumnaCargo].Visible = false;
			grid.Columns[ColumnaGrado].Visible = false;
		}

		private void OcultarColumnasPersonal()
		{
			grid.Columns[ColumnaTelefono].Visible = false;
		}
	}
}