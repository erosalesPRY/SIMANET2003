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
using SIMA.EntidadesNegocio.GestionControlInstitucional;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for PoppupImpresionObservacionesAuditoria.
	/// </summary>
	public class PopupImpresionAdministracionObservacionesAuditoria : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;  
		protected System.Web.UI.WebControls.Label lblCabecera;
		protected projDataGridWeb.DataGridWeb grid;

		int IDORGANISMO;
		int IDSITUACION;
		int IDCENTROOPERATIVO;
		int IDPERIODO;
		
		const string GRILLAVACIA ="No existe ninguna Observación.";

		const string KEYQID = "Id";
		const string KEYQIDDOCUMENTOAUDITORIA = "IdDocumentoAuditoria";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQIDORGANISMO = "IdOrganismo";
		const string KEYQIDSITUACION = "IdSituacion";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQIDTIPOSEGUIMIENTO ="IdTipoSeguimiento";
	
		const string KEYQIDPERIODO = "IdPeriodo";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					
					this.ConfigurarAccesoControles();
					
					this.LlenarJScript();

					Helper.ReiniciarSession();

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
			/*lblTitulo.Text=" REPORTE DE OBSERVACIONES DE AUDITORIA";
			CImpresion oCImpresion =  new CImpresion();
			DataTable dtImpresion =  oCImpresion.ObtenerDataImprimir();
			
			if(dtImpresion!=null)
			{
				DataView dwImpresion = dtImpresion.DefaultView;
				//dwImpresion.Sort = oCImpresion.ObtenerColumnaOrdenamiento();
				grid.DataSource = dwImpresion;
				//grid.CurrentPageIndex = oCImpresion.ObtenerIndicePagina();
			}
			else
			{
				lblResultado.Text = GRILLAVACIA;

			}
			grid.DataBind();*/

			lblTitulo.Text=" REPORTE DE OBSERVACIONES DE AUDITORIA";
			lblCabecera.Text=Page.Request.QueryString[KEYQDESCRIPCION].ToString();
			if (Page.Request.QueryString[KEYQIDSITUACION] !=null)
			{
				IDSITUACION = Convert.ToInt32(Session["IDSITUACION"]);
			}
			else
			{
				//IDSITUACION = Convert.ToInt32(Session["IDSITUACION"]);
				IDSITUACION=-1;
			}

			if (Page.Request.QueryString[KEYQIDORGANISMO] !=null)
			{
				IDORGANISMO = Convert.ToInt32(Page.Request.QueryString[KEYQIDORGANISMO]);
			}
			else
			{
				IDORGANISMO = -1;
			}

			if (Page.Request.QueryString[KEYQIDCENTROOPERATIVO] !=null)
			{
				IDCENTROOPERATIVO = Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]);
			}
			else
			{
				IDCENTROOPERATIVO= -1;
			}

			if (Page.Request.QueryString[KEYQIDPERIODO] !=null)
			{
				IDPERIODO = Convert.ToInt32(Page.Request.QueryString[KEYQIDPERIODO]);
			}
			else
			{
				IDPERIODO= -1;
			}

			CObservacionesAuditoria oCObservacionesAuditoria=  new CObservacionesAuditoria();
			DataTable dtObservacionesAuditoria =  oCObservacionesAuditoria.ConsultarObservacionesAuditoria
				(Convert.ToInt32(Page.Request.QueryString[KEYQIDDOCUMENTOAUDITORIA]),IDSITUACION, 
				IDORGANISMO, IDCENTROOPERATIVO, IDPERIODO,Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOSEGUIMIENTO]));

			if(dtObservacionesAuditoria!=null)
			{
				DataView dwObservacionesAuditoria = dtObservacionesAuditoria.DefaultView;
				dwObservacionesAuditoria.Sort = "Observacion" ;
				dwObservacionesAuditoria.RowFilter= Utilitario.Helper.ObtenerFiltro(this);
				grid.DataSource = dwObservacionesAuditoria;

				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwObservacionesAuditoria.Count.ToString();
			}
			else
			{
				grid.DataSource = dtObservacionesAuditoria;
				lblResultado.Text = GRILLAVACIA;
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
			// TODO:  Add PoppupImpresionObservacionesAuditoria.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PoppupImpresionObservacionesAuditoria.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PoppupImpresionObservacionesAuditoria.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add PoppupImpresionObservacionesAuditoria.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add PoppupImpresionObservacionesAuditoria.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PoppupImpresionObservacionesAuditoria.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PoppupImpresionObservacionesAuditoria.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add PoppupImpresionObservacionesAuditoria.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add PoppupImpresionObservacionesAuditoria.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
