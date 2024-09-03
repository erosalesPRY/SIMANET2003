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
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio
{
	/// <summary>
	/// Summary description for DefaultMargenporLN.
	/// </summary>
	public class DefaultMargenporLN : System.Web.UI.Page, IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.HtmlControls.HtmlTable tblResumen;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#region Constantes
		const string KEYQTIPOPRESUPUESTO ="idtp";
		const string CENTROOPERATIVO = "idCentro";
		const string KEYQCENTROOPERATIVONOMBRE = "NombreCentro";
		const string PERIODO = "Periodo";
		const string MES = "Mes";
		const string VISTAPPTOPRINCIPAL="Principales";
		const string KEYQPPTO = "VISTAPPTO";
		const string KEYQUIENLLAMA = "QLlama";
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
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
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Error);					
				}
				catch(Exception oException)
				{
					string msgb =oException.Message.ToString();
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
			// TODO:  Add DefaultMargenporLN.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DefaultMargenporLN.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DefaultMargenporLN.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DefaultMargenporLN.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblCentroOperativo.Text = Page.Request.Params[KEYQCENTROOPERATIVONOMBRE].ToString();
			lblPeriodo.Text = Page.Request.Params[PERIODO].ToString();
			lblMes.Text = Helper.ObtenerNombreMes(Convert.ToInt32(Page.Request.Params[MES]),Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
			this.CargarResumen();
		}

		private DataTable ObtenerDatos(int Opcion)
		{
			if (Page.Request.Params[KEYQPPTO].ToString()==VISTAPPTOPRINCIPAL)
			{
				return ((CPresupuesto) new  CPresupuesto()).ConsultarEvaluacionPrespuestalPorGruposdeCentrosdeCosto(
					Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
					,Convert.ToInt32(Page.Request.Params[CENTROOPERATIVO])
					,Convert.ToInt32(Page.Request.Params[PERIODO])
					,Convert.ToInt32(Page.Request.Params[MES])
					,Opcion);
			}
			else
			{
				return ((CPresupuesto) new  CPresupuesto()).ConsultarEvaluacionPrespuestalPorGruposdeCentrosdeCostoAuxiliar(
					Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
					,Convert.ToInt32(Page.Request.Params[CENTROOPERATIVO])
					,Convert.ToInt32(Page.Request.Params[PERIODO])
					,Convert.ToInt32(Page.Request.Params[MES])
					,Opcion);
			}
		}

		private void CargarResumen()
		{
			double MontoTotal =0;
			double Monto1 = 0;
			double Monto2 = 0;

			DataTable []dtResumen = new DataTable[2];
			dtResumen[0]= this.ObtenerDatos(0);
			dtResumen[1]= this.ObtenerDatos(1);

			if ( Page.Request.Params[KEYQUIENLLAMA]!=null)
			{
				Monto1 = (dtResumen[0]!=null)?(Helper.TotalizarDataView(dtResumen[0].DefaultView,"MontoPresupuestadoMes"))[0]:0;
				Monto2 = (dtResumen[1]!=null)?(Helper.TotalizarDataView(dtResumen[1].DefaultView,"MontoPresupuestadoMes"))[0]:0;
				MontoTotal = (Monto1 + Monto2);
				tblResumen.Rows[0].Cells[1].InnerText = MontoTotal.ToString(Utilitario.Constantes.FORMATODECIMAL4);

				Monto1 = (dtResumen[0]!=null)?(Helper.TotalizarDataView(dtResumen[0].DefaultView,"MontoEjecutadoMes"))[0] :0;
				Monto2 = (dtResumen[1]!=null)?(Helper.TotalizarDataView(dtResumen[1].DefaultView,"MontoEjecutadoMes"))[0]:0;
			
				MontoTotal = (Monto1 + Monto2);
				tblResumen.Rows[0].Cells[2].InnerText = MontoTotal.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				

				Monto1 = (dtResumen[0]!=null)?(Helper.TotalizarDataView(dtResumen[0].DefaultView,"MontoSaldoMes"))[0]:0;
				Monto2 = (dtResumen[1]!=null)?(Helper.TotalizarDataView(dtResumen[1].DefaultView,"MontoSaldoMes"))[0]:0;
			}
			else
			{
				Monto1 = (dtResumen[0]!=null)?(Helper.TotalizarDataView(dtResumen[0].DefaultView,"MontoPresupuestado"))[0]:0;
				Monto2 = (dtResumen[1]!=null)?(Helper.TotalizarDataView(dtResumen[1].DefaultView,"MontoPresupuestado"))[0]:0;
				MontoTotal = (Monto1 + Monto2);
				tblResumen.Rows[0].Cells[1].InnerText = MontoTotal.ToString(Utilitario.Constantes.FORMATODECIMAL4);

				Monto1 = (dtResumen[0]!=null)?(Helper.TotalizarDataView(dtResumen[0].DefaultView,"MontoEjecutado"))[0] :0;
				Monto2 = (dtResumen[1]!=null)?(Helper.TotalizarDataView(dtResumen[1].DefaultView,"MontoEjecutado"))[0]:0;
			
				MontoTotal = (Monto1 + Monto2);
				tblResumen.Rows[0].Cells[2].InnerText = MontoTotal.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				

				Monto1 = (dtResumen[0]!=null)?(Helper.TotalizarDataView(dtResumen[0].DefaultView,"MontoSaldo"))[0]:0;
				Monto2 = (dtResumen[1]!=null)?(Helper.TotalizarDataView(dtResumen[1].DefaultView,"MontoSaldo"))[0]:0;
			}

			MontoTotal = (Monto1 + Monto2);
			tblResumen.Rows[0].Cells[3].InnerText = MontoTotal.ToString(Utilitario.Constantes.FORMATODECIMAL4);
		}

		public void LlenarJScript()
		{
			// TODO:  Add DefaultMargenporLN.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DefaultMargenporLN.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DefaultMargenporLN.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DefaultMargenporLN.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DefaultMargenporLN.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DefaultMargenporLN.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
