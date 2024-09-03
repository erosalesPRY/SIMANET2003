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
using System.Drawing.Printing;

namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios
{
	public class CargarNodoTipoPresupuesto : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string KEYQIDFECHA="Fecha";
		const string KEYQIDTIPOPRESUPUESTO="idTPPPto";
		const string KEYQIDNIVEL="VerNivel";

		const string KEYQIDPERIODO="QIDPERIODO";
		const string KEYQIDMES="QIDMES";
		const string KEYQIDIDNIVEL="QIDIDNIVEL";
		const string KEYQIDNODOPADRE="QIDNODOPADRE";
		const string KEYQIDCENTRO="CENTRO";
		
		//Otros
		const string VALORCONSTANTEDOS ="2";
		const string SYSTEMDOUBLE ="System.Double";
		const string EXPRESIONPERU ="PeruTotalPPtoCta - PeruTotalEjecutado";
		const string EXPRESIONIQUITOS ="IquitosTotalPPtoCta - IquitosTotalEjecutado";
		//const string KEYQIDTIPOPRESUPUESTO="QIDTIPOPRESUPUESTO";

		//DataGrid and DataTable
		const string COLUMNAIDCENTROOPERATIVO ="idCentroOperativo";
		const string COLUMNANOMBRE ="Nombre";
		const string COLUMNAIDTIPOPTOCUENTA ="idTipoPresupuestoCuenta";
		const string COLUMNAULTIMONIVEL ="UltimoNivel";
		const string COLUMNADIGCTA ="DigCta";
		const string COLUMNAPERUTOTALPPTOCTA ="PeruTotalPPtoCta";
		const string COLUMNAPERUTOTALEJECUTADO ="PeruTotalEjecutado";
		const string COLUMNAPERUSALDO ="PeruSaldo";
		const string COLUMNAIQUITOSTOTALPPTOCTA = "IquitosTotalPPtoCta";
		const string COLUMNAIQUITOSTOTALEJECUTADO ="IquitosTotalEjecutado";
		const string COLUMNAIQUITOSSALDO ="IquitosSaldo";
		const string COLUMNAIDTIPOPTO ="idTipoPresupuesto";
		
		#endregion

		#region Controles
		protected System.Web.UI.HtmlControls.HtmlInputHidden hRegistro;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarDatos();
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
					ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
				}
				catch(Exception oException)
				{
					/*
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
					ltlMensaje.Text ="window.alert('" + oException.Message.ToString() + "');";
					*/
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}

		private DataTable ObtenerDatosNivel1()
		{
			CPresupuesto oCPresupuesto = new CPresupuesto();
			DataTable tblResultado =oCPresupuesto.ConsultarTiposdePresupuestoNivel1(
				Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year)
				,Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month)
				,Page.Request.Params[KEYQIDTIPOPRESUPUESTO].ToString());

			if (tblResultado !=null)
			{
				DataColumn dc = new  DataColumn(COLUMNAPERUSALDO, Type.GetType(SYSTEMDOUBLE));
				dc.Expression = EXPRESIONPERU;
				tblResultado.Columns.Add(dc);
				DataColumn dcI = new  DataColumn(COLUMNAIQUITOSSALDO, Type.GetType(SYSTEMDOUBLE));
				dcI.Expression = EXPRESIONIQUITOS;
				tblResultado.Columns.Add(dcI);
			}
			return tblResultado;
		}
		private string ObtenerNivel1()
		{
			DataTable tblResultado = this.ObtenerDatosNivel1();
			System.Text.StringBuilder sbReg = new System.Text.StringBuilder();
			foreach(DataRow dr in tblResultado.Rows)
			{
					sbReg.Append(dr[COLUMNAIDCENTROOPERATIVO].ToString()+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//0
					sbReg.Append(dr[COLUMNANOMBRE].ToString()+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//1
					sbReg.Append(dr[COLUMNAIDTIPOPTOCUENTA].ToString()+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//2
					sbReg.Append(dr[COLUMNAULTIMONIVEL].ToString()+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//3
					sbReg.Append(dr[COLUMNADIGCTA].ToString()+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//4
					//Peru
					sbReg.Append(Convert.ToDouble(dr[COLUMNAPERUTOTALPPTOCTA]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//5
					sbReg.Append(Convert.ToDouble(dr[COLUMNAPERUTOTALEJECUTADO]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//6
					sbReg.Append(Convert.ToDouble(dr[COLUMNAPERUSALDO]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//7
					//Iquitos
					sbReg.Append(Convert.ToDouble(dr[COLUMNAIQUITOSTOTALPPTOCTA]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//8
					sbReg.Append(Convert.ToDouble(dr[COLUMNAIQUITOSTOTALEJECUTADO]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//9
					sbReg.Append(Convert.ToDouble(dr[COLUMNAIQUITOSSALDO]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//10
					sbReg.Append(dr[COLUMNAIDTIPOPTO].ToString()+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//11
					sbReg.Append(Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOARROBA + Utilitario.Constantes.SIGNOCIERRACORCHETES);
			}
			if (sbReg.ToString().Length > Utilitario.Constantes.ValorConstanteCero)
			{
				return sbReg.ToString().Substring(0,sbReg.Length- 3);
			}
			return Utilitario.Constantes.VACIO;
		}


		private DataTable ObtenerDatosNivel2()
		{
			CPresupuesto oCPresupuesto = new CPresupuesto();
			DataTable tblResultado =oCPresupuesto.ConsultarTiposdePresupuestoNivel2(
								Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year)
								,Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month)
								,Page.Request.Params[KEYQIDCENTRO].ToString()
								,Page.Request.Params[KEYQIDTIPOPRESUPUESTO].ToString());

			if (tblResultado !=null)
			{
				DataColumn dc = new  DataColumn(COLUMNAPERUSALDO, Type.GetType(SYSTEMDOUBLE));
				dc.Expression = EXPRESIONPERU;
				tblResultado.Columns.Add(dc);
				DataColumn dcI = new  DataColumn(COLUMNAIQUITOSSALDO, Type.GetType(SYSTEMDOUBLE));
				dcI.Expression = EXPRESIONIQUITOS;
				tblResultado.Columns.Add(dcI);
			}
			return tblResultado;
		}
		private string ObtenerNivel2()
		{
			DataTable tblResultado = this.ObtenerDatosNivel2();
			System.Text.StringBuilder sbReg = new System.Text.StringBuilder();
			foreach(DataRow dr in tblResultado.Rows)
			{
				sbReg.Append(dr[COLUMNAIDCENTROOPERATIVO].ToString()+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//0
				sbReg.Append(dr[COLUMNANOMBRE].ToString()+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//1
				sbReg.Append(dr[COLUMNAIDTIPOPTOCUENTA].ToString()+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//2
				sbReg.Append(dr[COLUMNAULTIMONIVEL].ToString()+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//3
				sbReg.Append(dr[COLUMNADIGCTA].ToString()+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//4
				//Peru
				sbReg.Append(Convert.ToDouble(dr[COLUMNAPERUTOTALPPTOCTA]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//5
				sbReg.Append(Convert.ToDouble(dr[COLUMNAPERUTOTALEJECUTADO]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//6
				sbReg.Append(Convert.ToDouble(dr[COLUMNAPERUSALDO]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//7
				//Iquitos
				sbReg.Append(Convert.ToDouble(dr[COLUMNAIQUITOSTOTALPPTOCTA]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//8
				sbReg.Append(Convert.ToDouble(dr[COLUMNAIQUITOSTOTALEJECUTADO]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//9
				sbReg.Append(Convert.ToDouble(dr[COLUMNAIQUITOSSALDO]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//10
				sbReg.Append(dr[COLUMNAIDTIPOPTO].ToString()+ Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.SIGNOCIERRACORCHETES);//11
				sbReg.Append(Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOARROBA + Utilitario.Constantes.SIGNOCIERRACORCHETES);
			}
			if (sbReg.ToString().Length > Utilitario.Constantes.ValorConstanteCero)
			{
				return sbReg.ToString().Substring(0,sbReg.Length- 3);
			}
			return Utilitario.Constantes.VACIO;
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
			// TODO:  Add CargarNodoTipoPresupuesto.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add CargarNodoTipoPresupuesto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add CargarNodoTipoPresupuesto.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add CargarNodoTipoPresupuesto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			if (Page.Request.Params[KEYQIDNIVEL].ToString()== Utilitario.Constantes.ValorConstanteUno.ToString())
			{
				this.hRegistro.Value = this.ObtenerNivel1();
			}
			else if (Page.Request.Params[KEYQIDNIVEL].ToString()==VALORCONSTANTEDOS)
			{
				this.hRegistro.Value = this.ObtenerNivel2();
			}


			/*
				switch(Convert.ToInt32(Page.Request.Params[KEYQIDTIPOPRESUPUESTO]))
				{
					case 0:
						this.hRegistro.Value = this.ObtenerNivel1();
						break;
					case 1:
						this.hRegistro.Value = this.ObtenerNivel2();
						break;
					case 2:
						//this.hRegistro.Value = this.ObtenerNaturalezadeGasto3Dig(1);
						break;
					default:
						break;
				}
				*/
	  }

		public void LlenarJScript()
		{
			// TODO:  Add CargarNodoTipoPresupuesto.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add CargarNodoTipoPresupuesto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add CargarNodoTipoPresupuesto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add CargarNodoTipoPresupuesto.Exportar implementation
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
			// TODO:  Add CargarNodoTipoPresupuesto.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
