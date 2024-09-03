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
using SIMA.EntidadesNegocio.GestionFinanciera;

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio
{
	public class Procesar : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		const string INDICADORDEPROCESO="IdProceso";
		const int EFDETALLEGASTOADM = 12;
		const int EFDETALLEOTRASCUENTAS = 13;


		const string KEYQIDEMPRESA = "idEmp";
		const string KEYQIDCENTRO="IdCentroOperativo";
		const string KEYQIDFECHA = "efFecha";
		const string KEYQDIGRPNG="DigGrupoNG";
		const string KEYQNUEVOSSOLES = "MILNS";

		const string KEYQCUENTA3DIG = "Cta3Dig";
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDRUBRO = "IdRubro";



		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				if (Page.Request.Params[INDICADORDEPROCESO]!=null)
				{
					this.ValidaProceso();
				}
			}		
		}

		private void ValidaProceso()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA]) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					break;
				case Enumerados.ModoPagina.M:
					break;
				case Enumerados.ModoPagina.C:
					this.CargarModoConsulta();
					break;
			}
		}


		#region Implementacion de Procesos y Llamadas PostBack
		private void EFObtenerSaldosCentrosdeCostoporNaturalezadeGasto(int idEmpresa,int idCentroOperativo,int pPeriodo,int pMes,int idGrupoNG)
		{
			DataTable dt =  ((CEstadosFinancieros) new CEstadosFinancieros()).ConsultarGastosdeAdministracionporNaturalezadeGasto5dig(idEmpresa,idCentroOperativo,pPeriodo,pMes,idGrupoNG);

			Response.Clear();
			Response.ContentType = "text/xml";
			string output="<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n";
			output += "<NaturalezaGasto>\n";
			foreach(DataRow dr in dt.Rows)
			{
				output += "  <GastosPorCC>\n";
				output += "    <NroCentroCosto>"				+ dr["NroCentroCosto"].ToString() +	"</NroCentroCosto>\n";
				output += "    <NombreCentroCosto>"				+ dr["NombreCentroCosto"].ToString() +	"</NombreCentroCosto>\n";
				output += "    <EjecucionRealDelmesActual>"		+ 
																	//((Session[KEYQNUEVOSSOLES] ==null 
																	//|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
																	//? (Convert.ToDouble(dr["EjecucionRealDelmesActual"].ToString())/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
																	Convert.ToDouble(dr["EjecucionRealDelmesActual"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4)
																+	"</EjecucionRealDelmesActual>\n";
				output += "    <PresupuestoDelMesActual>"		+ 
																	//((Session[KEYQNUEVOSSOLES] ==null 
																	//|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
																	//? (Convert.ToDouble(dr["PresupuestoDelMesActual"].ToString())/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
																	Convert.ToDouble(dr["PresupuestoDelMesActual"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4)
																+	"</PresupuestoDelMesActual>\n";
				output += "    <VariaciondelMes>"				+ ((dr["VariaciondelMes"].ToString().Substring(0,1).Equals("S")==true)
																	?dr["VariaciondelMes"].ToString()
																	:Convert.ToDouble(dr["VariaciondelMes"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL5))
																	+	"</VariaciondelMes>\n";
				output += "    <EjecucionRealAcumulado>"		+ 
																	//((Session[KEYQNUEVOSSOLES] ==null 
																	//|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
																	//? (Convert.ToDouble(dr["EjecucionRealAcumulado"].ToString())/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
																	Convert.ToDouble(dr["EjecucionRealAcumulado"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4)
																	+	"</EjecucionRealAcumulado>\n";
				output += "    <PresupuestoAcumulado>"			+ 
																	//((Session[KEYQNUEVOSSOLES] ==null 
																	//|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
																	//? (Convert.ToDouble(dr["PresupuestoAcumulado"].ToString())/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
																	Convert.ToDouble(dr["PresupuestoAcumulado"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4)
																	+	"</PresupuestoAcumulado>\n";
				output += "    <VariacionAcumulada>"			+ ((dr["VariacionAcumulada"].ToString().Substring(0,1).Equals("S")==true) 
																		?dr["VariacionAcumulada"].ToString()
																		:Convert.ToDouble(dr["VariacionAcumulada"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL5))  +	"</VariacionAcumulada>\n";

				output += "  </GastosPorCC>\n";

			}
			output += "</NaturalezaGasto>";
			Response.Write(output);
			Response.End();
		}
		#region Detalle de 5 Digitos de Otras Cuentas
		private void EFObtenerDetalledeRubroCuenta5Digidos(string pDigCta3Dig,DateTime pFecha ,int pidFormato,int pidRubro,int pidEmpresa,int pidCentroOperativo)
		{
			DataTable dt =  ((CEstadosFinancieros) new CEstadosFinancieros()).ConsultarDetalledeRubroCuenta5Digitos(pDigCta3Dig,pFecha ,pidFormato,pidRubro,pidEmpresa,pidCentroOperativo);

			Response.Clear();
			Response.ContentType = "text/xml";
			string output="<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n";
			output += "<NaturalezaGasto>\n";
			foreach(DataRow dr in dt.Rows)
			{
				output += "  <GastosPorCuenta3Dig>\n";
				output += "    <CuentaContable>"				+ dr["CuentaContable"].ToString() +	"</CuentaContable>\n";
				output += "    <NombreCuenta>"					+ dr["NombreCuenta"].ToString() +	"</NombreCuenta>\n";
				
				output += "    <EjecucionRealDelmesActual>"		+ 
									Convert.ToDouble(dr["EjecucionRealDelmesActual"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4)
								+	"</EjecucionRealDelmesActual>\n";
				output += "    <PresupuestoDelMesActual>"		+ 
									Convert.ToDouble(dr["PresupuestoDelMesActual"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4)
								+	"</PresupuestoDelMesActual>\n";
				output += "    <VariaciondelMes>"				+ ((dr["VariaciondelMes"].ToString().Substring(0,1).Equals("S")==true)
								?dr["VariaciondelMes"].ToString()
								:Convert.ToDouble(dr["VariaciondelMes"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL5))
								+	"</VariaciondelMes>\n";
				output += "    <EjecucionRealAcumulado>"		+ 
									Convert.ToDouble(dr["EjecucionRealAcumulado"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4)
								+	"</EjecucionRealAcumulado>\n";
				output += "    <PresupuestoAcumulado>"			+ 
									Convert.ToDouble(dr["PresupuestoAcumulado"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4)
								+	"</PresupuestoAcumulado>\n";
				output += "    <VariacionAcumulada>"			+ ((dr["VariacionAcumulada"].ToString().Substring(0,1).Equals("S")==true) 
								?dr["VariacionAcumulada"].ToString()
								:Convert.ToDouble(dr["VariacionAcumulada"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL5))  +	"</VariacionAcumulada>\n";
				output += "    <Observacion>"					+ dr["Observacion"].ToString() +	"</Observacion>\n";
				output += "    <IdObservacion>"					+ dr["idobservacion"].ToString() +	"</IdObservacion>\n";
				output += "  </GastosPorCuenta3Dig>\n";

			}
			output += "</NaturalezaGasto>";
			Response.Write(output);
			Response.End();
		}
		#endregion
		#endregion


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
			// TODO:  Add Procesar.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add Procesar.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add Procesar.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add Procesar.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add Procesar.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add Procesar.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add Procesar.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add Procesar.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add Procesar.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add Procesar.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add Procesar.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add Procesar.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add Procesar.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add Procesar.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add Procesar.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add Procesar.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add Procesar.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			if (Page.Request.Params[INDICADORDEPROCESO]!=null && (Convert.ToInt32(Page.Request.Params[INDICADORDEPROCESO])==EFDETALLEGASTOADM))
			{
				this.EFObtenerSaldosCentrosdeCostoporNaturalezadeGasto(Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA]), Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO]),Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year ,Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month,Convert.ToInt32(Page.Request.Params[KEYQDIGRPNG]));
			}
			else if (Page.Request.Params[INDICADORDEPROCESO]!=null && (Convert.ToInt32(Page.Request.Params[INDICADORDEPROCESO])==EFDETALLEOTRASCUENTAS))
			{
				//(pDigCta3Dig,@pFecha ,pidFormato,pidRubro,pidEmpresa,pidCentroOperativo);
				this.EFObtenerDetalledeRubroCuenta5Digidos(
														Page.Request.Params[KEYQCUENTA3DIG].ToString()
														,Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA])
														,Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])
														, Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO])
														,Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA])
														,Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO])
														);
			}

			
		}



		public bool ValidarCampos()
		{
			// TODO:  Add Procesar.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add Procesar.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add Procesar.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	}
}
