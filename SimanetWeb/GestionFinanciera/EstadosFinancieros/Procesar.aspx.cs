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
using SIMA.EntidadesNegocio.General;

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	public class Procesar : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
			const int LISTARFORMATOACCESOUSUARIO = 51;
			const int LISTARFORMATOACCESOUSUARIOCTRLCIERRE = 180;
			const int LISTARFORMATOPORGRUPOACCESOUSUARIOCTRLCIERRE = 287;
			const int LISTARFORMATOPORGRUPO = 288;
			const int ADMINISTRARFOMATOREPORTECOLUMNADETMOV=299;

			const string INDICADORDEPROCESO="IdProceso";
			const string KEYQIDTABLAACCESOINFORMACION= "idtblAccesoInfo";
			#region Datos que seran asignados a una entidad
				const string PROCESO ="idProceso";
				const string PERIODO="Periodo";
				const string MES="idMes";
				const string KEYQIDCENTRO = "IdCentro";
				const string KEYQIDRUBRODETALLE = "IdrubroDetalle";
				const string KEYQIDRUBRODETALLEMOVIMIENTO = "IdrubroDetalleMov";
				const string KEYQIDTIPOINFORMACION = "idTipoInfo";
				const string KEYQMONTO = "Monto";
				const string KEYQIDGRUPOFORMATO="IdGrupoFormato";
				const string KEYQIDCOLUMNA="IdCol";
				const string KEYQIDFORMATO="IdFormato";
				const string KEYQIDREPORTE = "IdReporte";
				const string KEYQIDRUBRO="IdRubro";
			#endregion

		public decimal Importe{
			get{return Convert.ToDecimal(Page.Request.Params[KEYQMONTO]);}
		}
		public int IdColumna
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDCOLUMNA]);}
		}
		public int IdFormato
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);}
		}
		public int IdReporte
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);}
		}
		public int IdRubro
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]);}
		}
		public int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[PERIODO]);}
		}
		public int IdMes
		{
			get{return Convert.ToInt32(Page.Request.Params[MES]);}
		}
		public int IdCentroOperativo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO]);}
		}
		public int IdTipoInformacion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFORMACION]);}
		}
		public int IdGrupoFormato
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOFORMATO]);}
		}

		public int Proceso{
			get{return Convert.ToInt32(Page.Request.Params[PROCESO]);}
		}
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				//int idProceso = (Convert.ToInt32(Utilitario.Enumerados.FinIndicadoresdeProceos.idMantenimientoFormatoEstadosFinancierosDetalle.ToString()))
				switch (Convert.ToInt32(Page.Request.Params[INDICADORDEPROCESO]))
				{
					case 5://Mantenimiento de Detalle de estados financieros por rubro
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA]) ;
						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.N:
								this.Agregar();
								break;
							case Enumerados.ModoPagina.M:
								this.Modificar();
								break;
						}
						
						break;
					case LISTARFORMATOACCESOUSUARIO:
						Helper.GenerarEsquemaXMLNTAD((new CFormato()).ListarAccesoSegunPrivilegioUsuario(Convert.ToInt32(Page.Request.Params[KEYQIDTABLAACCESOINFORMACION])));
						break;
					case LISTARFORMATOACCESOUSUARIOCTRLCIERRE:
						Helper.GenerarEsquemaXMLNTAD((new CFormato()).ListarAccesoSegunPrivilegioUsuarioUsuarioCtrlCierre(this.IdCentroOperativo,this.Periodo,this.IdMes, this.IdTipoInformacion));
						break;
					case LISTARFORMATOPORGRUPOACCESOUSUARIOCTRLCIERRE:
						Helper.GenerarEsquemaXMLNTAD((new CFormato()).ListarGruposFormAccesoSegunPrivilegioUsuarioUsuarioCtrlCierre(this.IdCentroOperativo,this.Periodo,this.IdMes, this.IdTipoInformacion,this.IdGrupoFormato));
						break;
					case LISTARFORMATOPORGRUPO:
						DataTable dt= (new CFormato()).ListarGruposFormAccesoSegunPrivilegioUsuarioUsuarioCtrlCierre(this.IdCentroOperativo,this.Periodo,this.IdMes, this.IdTipoInformacion,0);

						if(dt!=null)
						{
							string[]LstField={"IdGrupo","NombreGrupo"};
							int i=0;
							DataTable dtGrp = Helper.Data.GroupBy(dt,LstField,null);
							Helper.GenerarEsquemaXMLNTAD(dtGrp);
						}


						break;


				}
				//*if(this.Proceso == ADMINISTRARFOMATOREPORTECOLUMNADETMOV){ comentado 09.01.2018*/
					FormatoReporteColumnaMovimientoBE oFormatoReporteColumnaMovimientoBE= new FormatoReporteColumnaMovimientoBE();
						oFormatoReporteColumnaMovimientoBE.Periodo=this.Periodo;
						oFormatoReporteColumnaMovimientoBE.IdMes=this.IdMes;
						oFormatoReporteColumnaMovimientoBE.IdCentroOperativo=this.IdCentroOperativo;
						oFormatoReporteColumnaMovimientoBE.IdFormato=this.IdFormato;
						oFormatoReporteColumnaMovimientoBE.IdReporte=this.IdReporte;
						oFormatoReporteColumnaMovimientoBE.IdRubro=this.IdRubro;
						oFormatoReporteColumnaMovimientoBE.IdColumna=this.IdColumna;
						oFormatoReporteColumnaMovimientoBE.Valor=this.Importe;
					Helper.GenerarEsquemaXMLTAD((new Controladoras.General.CFormatoReporteColumnaMovimiento()).InsAct(oFormatoReporteColumnaMovimientoBE));

				/*}comentado 09.01.2018*/

//				if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==CTAPORPAGAR || Convert.ToInt32(Page.Request.Params[PROCESO])==CTAPORCOBRAR))
//				{
//					ObtenerDatosdeCuentasporPagar3Dig(Convert.ToInt32(Page.Request.Params[PROCESO]), Convert.ToInt32(Page.Request.Params[PERIODO]),Convert.ToInt32(Page.Request.Params[MES]),Page.Request.Params[DIGCTA].ToString());
//				}
			}
		}


		#region Implementacion de Procesos y Llamadas PostBack
		private void ObtenerDatosdeCuentasporPagar3Dig(int idDetalleMovimiento)
		{

			Response.Clear();
			Response.ContentType = "text/xml";
			string output="<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n";
			output += "<PROCESOS>\n";
			output += "  <Insertar>\n";
			output += "    <idDetalleMovimiento>" + idDetalleMovimiento.ToString()+   "</idDetalleMovimiento>\n";
			output += "  </Insertar>\n";
			output += "</PROCESOS>";
			Response.Write(output);
			Response.End();
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
			FormatoRubroDetalleMovimientoBE oFormatoRubroDetalleMovimientoBE = new FormatoRubroDetalleMovimientoBE();

			oFormatoRubroDetalleMovimientoBE.Monto = Convert.ToDouble(Page.Request.Params[KEYQMONTO]);
			oFormatoRubroDetalleMovimientoBE.Descripcion =String.Empty;
			oFormatoRubroDetalleMovimientoBE.IdMes = Convert.ToInt32(Page.Request.Params[MES]);
			oFormatoRubroDetalleMovimientoBE.Periodo = Convert.ToInt32(Page.Request.Params[PERIODO]);
			oFormatoRubroDetalleMovimientoBE.IdCentroOperativo = Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO]);
			oFormatoRubroDetalleMovimientoBE.IdRubroDetalle = Convert.ToInt32(Page.Request.Params[KEYQIDRUBRODETALLE]);
			oFormatoRubroDetalleMovimientoBE.IdTablaTipoInformacion = 119;
			oFormatoRubroDetalleMovimientoBE.IdTipoInformacion = Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFORMACION]);
			oFormatoRubroDetalleMovimientoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			CFormatoRubroDetalleMovimiento oCFormatoRubroDetalleMovimiento = new CFormatoRubroDetalleMovimiento();
			ObtenerDatosdeCuentasporPagar3Dig(oCFormatoRubroDetalleMovimiento.Insertar(oFormatoRubroDetalleMovimientoBE));
		}

		public void Modificar()
		{
			FormatoRubroDetalleMovimientoBE oFormatoRubroDetalleMovimientoBE = new FormatoRubroDetalleMovimientoBE();
			oFormatoRubroDetalleMovimientoBE.Monto = Convert.ToDouble(Page.Request.Params[KEYQMONTO]);
			oFormatoRubroDetalleMovimientoBE.Descripcion =String.Empty;
			oFormatoRubroDetalleMovimientoBE.IdMes = Convert.ToInt32(Page.Request.Params[MES]);
			oFormatoRubroDetalleMovimientoBE.Periodo = Convert.ToInt32(Page.Request.Params[PERIODO]);
			oFormatoRubroDetalleMovimientoBE.IdCentroOperativo = Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO]);
			oFormatoRubroDetalleMovimientoBE.IdRubroDetalle = Convert.ToInt32(Page.Request.Params[KEYQIDRUBRODETALLE]);
			oFormatoRubroDetalleMovimientoBE.IdRubroDetalleMovimiento = Convert.ToInt32(Page.Request.Params[KEYQIDRUBRODETALLEMOVIMIENTO]);
			oFormatoRubroDetalleMovimientoBE.IdTablaTipoInformacion = 119;
			oFormatoRubroDetalleMovimientoBE.IdTipoInformacion = Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFORMACION]);
			oFormatoRubroDetalleMovimientoBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			CFormatoRubroDetalleMovimiento oCFormatoRubroDetalleMovimiento = new CFormatoRubroDetalleMovimiento();
			ObtenerDatosdeCuentasporPagar3Dig(oCFormatoRubroDetalleMovimiento.Modificar(oFormatoRubroDetalleMovimientoBE));
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
			// TODO:  Add Procesar.CargarModoConsulta implementation
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
