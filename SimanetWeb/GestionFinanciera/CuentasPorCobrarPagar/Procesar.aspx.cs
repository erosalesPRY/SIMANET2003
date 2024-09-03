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


namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar
{
	public class Procesar : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
			const string NOMBREPROCESO ="NombreProceso";
		#region Proceso Cuentas por Pagar
			const string INDICADORDEPROCESO="IdProceso";
			/*const string PROCESOCUENTASPORPAGAR ="PCuentasporPagar";*/
			//const string PERIODO = "Periodo";
			//const string MES = "Mes";
			const int CTAPORPAGAR = 1;
			const int CTAPORCOBRAR = 2;

			//Para el Mantenimiento
		const string KEYQIDCENTRO="idCentro";
		const string KEYQPERIODO="Periodo";
		const string KEYQMES="Mes";
		const string KEYQTIPOFINFORMACION="idTipoInfo";
		const string KEYQDIGCUENTA="DigCta";
		const string KEYQMONTO = "Monto";

		#endregion

		#endregion
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
						this.Agregar();
						break;
					case Enumerados.ModoPagina.M:
						this.Modificar();
						break;
					case Enumerados.ModoPagina.C:
						this.CargarModoConsulta();
						break;
				}
		}



		#region Implementacion de Procesos y Llamadas PostBack
			private void ObtenerDatosdeCuentasporPagar3Dig(int idtipoCuenta,int pPeriodo,int pMes,string pDigitoCuenta)
			{
				DataTable dt =  ((CCuentasporPagar) new CCuentasporPagar()).ConsultarCuentasporPagarCobrar3Digitos(idtipoCuenta,pPeriodo,pMes,pDigitoCuenta);

				Response.Clear();
				Response.ContentType = "text/xml";
				string output="<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n";
				output += "<CuentasPorPagar>\n";
				foreach(DataRow dr in dt.Rows)
				{
					output += "  <CuentaPorPagar>\n";
					output += "    <Cuenta3Dig>"    + dr[Enumerados.FINColumnaResumenCuentasPorPagar.CuentaContable.ToString()] +	"</Cuenta3Dig>\n";
					output += "    <idRubros>"		+ dr[Enumerados.FINColumnaResumenCuentasPorPagar.idRubros.ToString()] +	"</idRubros>\n";
					output += "    <NombreCuenta>"	+ dr[Enumerados.FINColumnaResumenCuentasPorPagar.NombreCuenta.ToString()] +	"</NombreCuenta>\n";
					output += "    <SimaCallao>"	+ Convert.ToDouble(dr[Enumerados.FINColumnaResumenCuentasPorPagar.SimaCallao.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</SimaCallao>\n";
					output += "    <SimaChimbote>"	+ Convert.ToDouble(dr[Enumerados.FINColumnaResumenCuentasPorPagar.SimaChimbote.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</SimaChimbote>\n";
					output += "    <SimaIquitos>"	+ Convert.ToDouble(dr[Enumerados.FINColumnaResumenCuentasPorPagar.SimaIquitos.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</SimaIquitos>\n";
					output += "    <Total>"	+ Convert.ToDouble(dr["Total"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Total>\n";
					output += "  </CuentaPorPagar>\n";
				}
				output += "</CuentasPorPagar>";
				Response.Write(output);
				Response.End();
			}
		#endregion
		#region Implementacion de resultados de mantenimiento
		private int ResultadoTAD(int Resultado)
		{
			Response.Clear();
			Response.ContentType = "text/xml";
			string output="<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n";
			output += "<PROCESOS>\n";
			output += "  <Insertar>\n";
			output += "    <idResultado>" + Resultado.ToString()+   "</idResultado>\n";
			output += "  </Insertar>\n";
			output += "</PROCESOS>";
			Response.Write(output);
			Response.End();

			return Resultado;
		}
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
			switch (Convert.ToInt32(Page.Request.Params[INDICADORDEPROCESO]))
			{
				case 6://Mantenimiento de Cuentas por cobrar y pagar 3 digitos para chimbote e iquitos
					InsertarCuentasporCobraryPagar();
					break;
			}
		}
		public void Modificar()
		{
			switch (Convert.ToInt32(Page.Request.Params[INDICADORDEPROCESO]))
			{
				case 6://Mantenimiento de Cuentas por cobrar y pagar 3 digitos para chimbote e iquitos
					ModificarCuentasporCobraryPagar();
					break;
			}
			
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
			if (Page.Request.Params[INDICADORDEPROCESO]!=null && (Convert.ToInt32(Page.Request.Params[INDICADORDEPROCESO])==CTAPORPAGAR || Convert.ToInt32(Page.Request.Params[INDICADORDEPROCESO])==CTAPORCOBRAR))
			{
					ObtenerDatosdeCuentasporPagar3Dig(Convert.ToInt32(Page.Request.Params[INDICADORDEPROCESO]), Convert.ToInt32(Page.Request.Params[KEYQPERIODO]),Convert.ToInt32(Page.Request.Params[KEYQMES]),Page.Request.Params[KEYQDIGCUENTA].ToString());
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

		#region Mantenimientos
		private void InsertarCuentasporCobraryPagar()
		{
			CuentasporPagaryCobrar3DigBE oCuentasporPagaryCobrar3DigBE = new CuentasporPagaryCobrar3DigBE();
			oCuentasporPagaryCobrar3DigBE.IdTipoDato = Convert.ToInt32(Page.Request.Params[KEYQTIPOFINFORMACION]);
			oCuentasporPagaryCobrar3DigBE.IdCentroOperativo = Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO]);
			oCuentasporPagaryCobrar3DigBE.CuentaContable= Page.Request.Params[KEYQDIGCUENTA].ToString();
			oCuentasporPagaryCobrar3DigBE.Periodo= Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);
			oCuentasporPagaryCobrar3DigBE.Mes= Convert.ToInt32(Page.Request.Params[KEYQMES]);
			oCuentasporPagaryCobrar3DigBE.MontoMes= Convert.ToDecimal(Page.Request.Params[KEYQMONTO]);
			oCuentasporPagaryCobrar3DigBE.IdUsuarioRegistro= CNetAccessControl.GetIdUser();
				
			if(ResultadoTAD(((CCuentasporPagaryCobrar3Dig) new CCuentasporPagaryCobrar3Dig()).Insertar(oCuentasporPagaryCobrar3DigBE))>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Cuentas por Cobrar y Pagar 3Dig ",this.ToString(),"Se registró registro de Cuentas por cobra o pagar 3Dig" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
			}					
		}
		private void ModificarCuentasporCobraryPagar()
		{
			CuentasporPagaryCobrar3DigBE oCuentasporPagaryCobrar3DigBE = new CuentasporPagaryCobrar3DigBE();
			oCuentasporPagaryCobrar3DigBE.IdTipoDato = Convert.ToInt32(Page.Request.Params[KEYQTIPOFINFORMACION]);
			oCuentasporPagaryCobrar3DigBE.IdCentroOperativo = Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO]);
			oCuentasporPagaryCobrar3DigBE.CuentaContable= Page.Request.Params[KEYQDIGCUENTA].ToString();
			oCuentasporPagaryCobrar3DigBE.Periodo= Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);
			oCuentasporPagaryCobrar3DigBE.Mes= Convert.ToInt32(Page.Request.Params[KEYQMES]);
			oCuentasporPagaryCobrar3DigBE.MontoMes= Convert.ToDecimal(Page.Request.Params[KEYQMONTO]);
			oCuentasporPagaryCobrar3DigBE.IdUsuarioActualizacion= CNetAccessControl.GetIdUser();
					
			if(ResultadoTAD(((CCuentasporPagaryCobrar3Dig) new CCuentasporPagaryCobrar3Dig()).Modificar(oCuentasporPagaryCobrar3DigBE))>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Cuentas por Cobrar y Pagar 3Dig ",this.ToString(),"Se modifico de Cuentas por cobra o pagar 3Dig" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
			}					
		}


		#endregion




	}
}
