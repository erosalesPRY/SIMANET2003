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
using SIMA.Log;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using NetAccessControl;


namespace SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion
{
	/// <summary>
	/// Summary description for ConsultarPlanGestion.
	/// </summary>
	public class ConsultarPlanGestion : System.Web.UI.Page, IPaginaBase
	{
		
		#region Controles
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras;
		protected System.Web.UI.HtmlControls.HtmlImage PG01;
		protected System.Web.UI.HtmlControls.HtmlImage PG02;
		protected System.Web.UI.HtmlControls.HtmlImage PG03;
		protected System.Web.UI.HtmlControls.HtmlImage PG04;
		protected System.Web.UI.HtmlControls.HtmlImage PG05;
		protected System.Web.UI.HtmlControls.HtmlImage PG06;
		protected System.Web.UI.HtmlControls.HtmlImage PG07;
		protected System.Web.UI.HtmlControls.HtmlImage PP17;
		protected System.Web.UI.HtmlControls.HtmlImage PP18;
		protected System.Web.UI.HtmlControls.HtmlImage PP04;
		protected System.Web.UI.HtmlControls.HtmlImage PP11;
		protected System.Web.UI.HtmlControls.HtmlImage PP13;
		protected System.Web.UI.HtmlControls.HtmlImage PP14;
		protected System.Web.UI.HtmlControls.HtmlImage PPC13;
		protected System.Web.UI.HtmlControls.HtmlImage PPC04;
		protected System.Web.UI.HtmlControls.HtmlImage PP15;
		protected System.Web.UI.HtmlControls.HtmlImage PP16;
		protected System.Web.UI.HtmlControls.HtmlImage PP12;
		protected System.Web.UI.HtmlControls.HtmlImage PA21;
		protected System.Web.UI.HtmlControls.HtmlImage PA22;
		protected System.Web.UI.HtmlControls.HtmlImage PA23;
		protected System.Web.UI.HtmlControls.HtmlImage PA24;
		protected System.Web.UI.HtmlControls.HtmlImage PA25;
		protected System.Web.UI.HtmlControls.HtmlImage PA26;
		protected System.Web.UI.HtmlControls.HtmlImage PA27;
		protected System.Web.UI.HtmlControls.HtmlImage PA28;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#endregion Controles

		#region Constantes
			const string URLCONSULTARPROCESO = "ConsultarProceso.aspx?";
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
					
					this.LlenarJScript();					

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan Gestión",this.ToString(),"Se consultó el Plan de Gestión",Enumerados.NivelesErrorLog.I.ToString()));
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
			// TODO:  Add ConsultarPlanGestion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPlanGestion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarPlanGestion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarPlanGestion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarPlanGestion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			#region Procesos de Gestion
			PG01.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PG01.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO, Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P01).ToString())));

			PG02.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PG02.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.PO2).ToString())));

			PG03.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PG03.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P03).ToString())));

			PG04.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PG04.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P04).ToString())));

			PG05.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PG05.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P05).ToString())));

			PG06.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PG06.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P06).ToString())));

			PG07.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PG07.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P07).ToString())));
			#endregion

			#region Procesos de Produccion
			PP04.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PP04.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P04).ToString())));

			PPC04.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PPC04.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P04).ToString())));

			PP13.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PP13.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P13).ToString())));

			PPC13.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PPC13.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P13).ToString())));

			PP11.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PP11.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P11).ToString())));

			PP12.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PP12.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P12).ToString())));

			PP14.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PP14.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P14).ToString())));

			PP15.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PP15.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P15).ToString())));

			PP16.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PP16.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P16).ToString())));

			PP17.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PP17.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P17).ToString())));

			PP18.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PP18.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P18).ToString())));
			#endregion

			#region Procesos de Apoyo
			PA21.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PA21.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P21).ToString())));

			PA22.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PA22.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P22).ToString())));

			PA23.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PA23.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P23).ToString())));

			PA24.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PA24.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P24).ToString())));

			PA25.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PA25.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P25).ToString())));

			PA26.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PA26.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P26).ToString())));

			PA27.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PA27.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P27).ToString())));

			PA28.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			PA28.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Convert.ToString(Helper.MostrarVentana(URLCONSULTARPROCESO,Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt16(Utilitario.Enumerados.ProcesosPlanGestion.P28).ToString())));
			#endregion
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPlanGestion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarPlanGestion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarPlanGestion.Exportar implementation
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
			// TODO:  Add ConsultarPlanGestion.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}

