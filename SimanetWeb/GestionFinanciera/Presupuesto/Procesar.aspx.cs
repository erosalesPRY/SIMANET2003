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
using SIMA.EntidadesNegocio.General;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Runtime.InteropServices;


namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto
{
	/// <summary>
	/// Summary description for Procesar.
	/// </summary>
	public class Procesar : BaseGestionFinanciera
	{
		#region Constantes
			const string NOMBREPROCESO ="NombreProceso";
			#region Parametros
				const string PROCESO ="idProceso";
				const string PERIODO = "Periodo";
				const string MES = "Mes";
				const int PRESUPUESTOCENTROOPERATIVO=3;
				const int PRESUPUESTOCENTROOPERATIVONIVEL3=4;
		
				const int INVERSIONESGRUPOCENTROCOSTO=15;
				const int INVERSIONESCENTROCOSTO=16;

				const int LISTARFORMATOESTRUCTURAMOVIMIENTO= 91;

				const int KEYQINSERTAFORMATOMOVIMIENTOCENTROCOSTOITEM=94;
				const int KEYQCONSULTARRESUMENEVALUACIONPRESUPUESTAL = 106;		

				const string IDTIPOPRESUPUESTO="idtp";
				const string IDCENTROOPERATIVO="idcop";
				const string NROCENTROOPERATIVO="Nrocop";
				const string VISTAPPTOPRINCIPAL="Principales";
				const string KEYQPPTO = "VISTAPPTO";
				const string KEYQUIENLLAMA = "QLlama";


			#region Evaluacion Centros deCosto
				const int EVALUACIONPRESPUESTALDETALLECENTROCOSTOCTA5DIG=11;
				/*Sirve para Obtener la Lista de Centros de Costos*/
				const int EVALUACIONPRESPUESTALLISTARCENTROSDECOSTO=7;
				const int EVALUACIONPRESPUESTALCENTROCOSTODETALLECUENTA5DIG=8;
				const int EVALUACIONMENSUALCENTROCOSTODETALLECUENTA5DIG=29;

				const string KEYQIDGRUPOCC = "idGrpCC";
				const string KEYQNROGRUPOCC = "NroGrpCC";
				
				/**///
				const string KEYQTIPOPRESUPUESTO= "idtp";
				const string CENTROOPERATIVO = "idCentro";
	
				

				const string KEYQTIPOOPCION = "Opcion";
				/*Para el Detalle de centros de costo cuenta 5 dig*/
				const string KEYQIDCENTROCOSTO ="idCC";
				//const string KEYQNROCENTROCOSTO ="NroCC";

				const string KEYQCUENTA3DIG="Cta3Dig";
				const string KEYQMONTOPPTO="Monto";
				const string KEYQCUENTA5DIG="Cta5Dig";
				/*Inversiones*/
				const int EVALUACIONCONSULTARCENTROCOSTOPRESUPUESTOINVERSION=30;
				/*Listado de Centros de costos por grupos*/
				const int LISTARCENTROSDECOSTO=54;

			#endregion

			#region Formulacion Centros de Costo
				const int FORMULACIONPRESPUESTALCENTROCOSTODETALLECUENTA5DIG=9;
				const int FORMULACIONPRESPUESTALCENTROSDECOSTOINSACTDETALLECTA5DIG=10;
				const string KEYQIDNROGRUPOCC = "idNroGrpCC";
				const string KEYQIDNROCENTROCOSTO ="idNroCC";


			#endregion

			#region FORMATO
				const int PRESUPUESTOINVERSIONMANTENIMIENTO=31;

				const string KEYQIDDESFORMCC = "IDFMTCC";
				const string KEYQIDFORMATO = "IDFORMATO";
				const string KEYQIDREPORTE = "IDREPORTE";
				const string KEYQIDRUBRO   = "IDRUBRO";
				const string KEYQIDCENTROOPERATIVO="IDCENTROOPERATIVO";
				const string KEYQIDCENTROCOSTOINV="IDCENTROCOSTO";
				const string KEYQPERIODO="PERIODO";
				const string KEYQIDMES="IDMES";
				const string KEYQIDTIPOINFORMACION="IDTIPOINFORMACION";
				const string KEYQMONTOMES="MONTOMES";
				const string KEYQREQCC ="ReqCC";		
				const string KEYQOBSERVACION="OBSERVACION";

				const string KEYQFMTMOVCC="IDFMTMOVCC";
				const string KEYQDESCRIPCION="DESCRIPCION";	
				const int TIPODEINFORMACION=32;
				
				const int REGFORMATODETMOV=33;
				const int REGFORMATODETMOVCC=34;

				const int PRCFORMATOMOVIMIENTOOBSERVACIONES=96;
				const int PRCINSACTFORMATOMOVIMIENTOOBSERVACIONES=97;

				
			#endregion

			#region control presupuestal
				const int CONSULTARCENTROCOSTO=49;
				const int CONTROLPRESUPUESTALPORCENTROCOSTO=50;
				const string KEYQIDNROCENTROCOSTOS ="NroCC";
				
				const string KEYQIDCTA="CtaDig";

				//Reporte de Centrosa de costos
				const int REPORTEEVALUACIONPRESUPUESTOPORCENTROCOSTO=54;
				
				const int MANTENIMIENTOITEMUNISYS=121;
				const int CONSULTARESUMENPORITEMCCCTA= 124;
			#endregion

			#region Fitro del presupuesto
				const string KEYQFILTRADO ="Filtrado";
			#endregion


			#endregion
			
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==PRESUPUESTOCENTROOPERATIVO))
				{
					ObtenerDetalleporCentroOperativo(Page.Request.Params[IDTIPOPRESUPUESTO].ToString(), Convert.ToInt32(Page.Request.Params[PERIODO]),Convert.ToInt32(Page.Request.Params[MES]));
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==PRESUPUESTOCENTROOPERATIVONIVEL3))
				{
					ObtenerDetalleporCentroOperativoNivel3(Page.Request.Params[IDTIPOPRESUPUESTO].ToString(),Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO]),Convert.ToInt32(Page.Request.Params[PERIODO]),Convert.ToInt32(Page.Request.Params[MES]));
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==EVALUACIONPRESPUESTALLISTARCENTROSDECOSTO))
				{
					ObtenerListadodeCentrosdeCosto(Page.Request.Params[IDTIPOPRESUPUESTO].ToString(),Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO]),Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOCC]),Convert.ToInt32(Page.Request.Params[PERIODO]),Convert.ToInt32(Page.Request.Params[KEYQTIPOOPCION]));
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==EVALUACIONPRESPUESTALCENTROCOSTODETALLECUENTA5DIG))
				{
					
					ObtenerCentrosdeCostoDetalleCuenta5Dig(Page.Request.Params[IDTIPOPRESUPUESTO].ToString()
						,Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO])
						,Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOCC])
						,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO])
						,Convert.ToInt32(Page.Request.Params[PERIODO])
						,Convert.ToInt32(Page.Request.Params[MES])
						,Page.Request.Params[KEYQCUENTA3DIG].ToString()
						);
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==EVALUACIONMENSUALCENTROCOSTODETALLECUENTA5DIG))
				{
					Helper.GenerarEsquemaXMLNTAD((new CPresupuesto()).ConsultarEvaluacionMensualPorCentrosdeCosto5Dig(Page.Request.Params[IDTIPOPRESUPUESTO].ToString()
						,Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO])
						,Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOCC])
						,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO])
						,Convert.ToInt32(Page.Request.Params[PERIODO])
						,Page.Request.Params[KEYQCUENTA3DIG].ToString()
						));
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==FORMULACIONPRESPUESTALCENTROCOSTODETALLECUENTA5DIG))
				{
					
					ObtenerFormulacionCentrosdeCostoDetalleCuenta5Dig(Page.Request.Params[IDTIPOPRESUPUESTO].ToString()
						,Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO])
						,Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOCC])
						,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO])
						,Convert.ToInt32(Page.Request.Params[PERIODO])
						,Page.Request.Params[KEYQCUENTA3DIG].ToString()
						);
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==FORMULACIONPRESPUESTALCENTROSDECOSTOINSACTDETALLECTA5DIG))
				{//Mantenimiento del presupuesto formulacion
					this.RegistrarPresupuesto();
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==EVALUACIONPRESPUESTALDETALLECENTROCOSTOCTA5DIG))
				{
					ObtenerPrespuestoFormulacionVSEjecucionPorCentrosdeCosto5Dig(Page.Request.Params[IDTIPOPRESUPUESTO].ToString()
						,Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO])
						,Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOCC])
						,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO])
						,Convert.ToInt32(Page.Request.Params[PERIODO])
						,Convert.ToInt32(Page.Request.Params[MES])
						,Page.Request.Params[KEYQCUENTA3DIG].ToString()
						);				
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==EVALUACIONCONSULTARCENTROCOSTOPRESUPUESTOINVERSION))
				{
					Helper.GenerarEsquemaXMLNTAD((new CPresupuestoInversiones()).ConsultarCentroCostoPresupuestoInversion(Convert.ToInt32(Page.Request.Params[PERIODO])));
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==INVERSIONESGRUPOCENTROCOSTO))
				{
					Helper.GenerarEsquemaXMLNTAD((new CGrupoCentroCosto()).ListarGrupoCCPorCentroOperativo(Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO]))); 
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==INVERSIONESCENTROCOSTO))
				{
					Helper.GenerarEsquemaXMLNTAD((new CCentroCosto()).ListarCentroCostoPorGrupoCC(Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOCC]))); 
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==PRESUPUESTOINVERSIONMANTENIMIENTO))
				{
					if(Convert.ToInt32(Page.Request.Params[KEYQREQCC])==1)
					{
						FMTInversionesBE oFMTInversionesBE = new FMTInversionesBE();
						oFMTInversionesBE.Idformato = Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
						oFMTInversionesBE.Idreporte = Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);
						oFMTInversionesBE.Idrubro = Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]);
						oFMTInversionesBE.Idcentrooperativo = Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]);
						oFMTInversionesBE.Idcentrocosto = Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTOINV]);
						oFMTInversionesBE.Periodo = Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);
						oFMTInversionesBE.Idmes = Convert.ToInt32(Page.Request.Params[KEYQIDMES]);
						oFMTInversionesBE.Idtipoinformacion = Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFORMACION]);
						oFMTInversionesBE.Montomes = Convert.ToDouble(Page.Request.Params[KEYQMONTOMES]);
						Helper.GenerarEsquemaXMLTAD((new CPresupuestoInversiones()).InsertarModificar(oFMTInversionesBE));
					}
					else
					{
						FormatoDetalleMovimientoBE oFormatoDetalleMovimientoBE = new FormatoDetalleMovimientoBE();
						oFormatoDetalleMovimientoBE.IdFormato = Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
						oFormatoDetalleMovimientoBE.IdReporte = Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);
						oFormatoDetalleMovimientoBE.IdRubro = Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]);
						/* Sirve para verificar el concepto cualquiera 
						 * if(oFormatoDetalleMovimientoBE.IdRubro==27){
							oFormatoDetalleMovimientoBE.MontoMes = Convert.ToDouble(Page.Request.Params[KEYQMONTOMES]);
						}*/

						oFormatoDetalleMovimientoBE.IdCentroOperativo = Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]);
						oFormatoDetalleMovimientoBE.Periodo = Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);
						oFormatoDetalleMovimientoBE.Mes = Convert.ToInt32(Page.Request.Params[KEYQIDMES]);
						oFormatoDetalleMovimientoBE.IdTipoInformacion = Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFORMACION]);
						oFormatoDetalleMovimientoBE.IdUsuarioActualizacion =  CNetAccessControl.GetIdUser();
						oFormatoDetalleMovimientoBE.MontoAcumulado = 0;
						oFormatoDetalleMovimientoBE.MontoMes = Convert.ToDouble(Page.Request.Params[KEYQMONTOMES]);
						double imp = Convert.ToDouble(Page.Request.Params[KEYQMONTOMES].Replace("",""));
						oFormatoDetalleMovimientoBE.MontoMes=imp;

						//oFormatoDetalleMovimientoBE.Observacion = Data[3].ToString();
						Helper.GenerarEsquemaXMLTAD((new CEstadosFinancieros()).InsertarModificar(oFormatoDetalleMovimientoBE));
					}
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==PRCFORMATOMOVIMIENTOOBSERVACIONES))
				{
					Helper.GenerarEsquemaXMLNTAD((new SIMA.Controladoras.General.CFormatoDetalleMovimiento()).ConsultarObservacion(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])
						,Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE])
						,Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO])
						,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO])
						,Convert.ToInt32(Page.Request.Params[KEYQPERIODO])
						,Convert.ToInt32(Page.Request.Params[KEYQIDMES])
						,Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFORMACION])
						));
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==PRCINSACTFORMATOMOVIMIENTOOBSERVACIONES))
				{
					if(Convert.ToInt32(Page.Request.Params[KEYQREQCC])==0)
					{
						FormatoDetalleMovimientoBE oFormatoDetalleMovimientoBE = new FormatoDetalleMovimientoBE();
						oFormatoDetalleMovimientoBE.IdFormato = Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
						oFormatoDetalleMovimientoBE.IdReporte = Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);
						oFormatoDetalleMovimientoBE.IdRubro = Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]);
						oFormatoDetalleMovimientoBE.IdCentroOperativo = Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]);
						oFormatoDetalleMovimientoBE.Periodo = Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);
						oFormatoDetalleMovimientoBE.Mes = Convert.ToInt32(Page.Request.Params[KEYQIDMES]);
						oFormatoDetalleMovimientoBE.IdTipoInformacion = Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFORMACION]);
						oFormatoDetalleMovimientoBE.Observacion = Page.Request.Params[KEYQOBSERVACION].ToString();
						Helper.GenerarEsquemaXMLTAD((new SIMA.Controladoras.General.CFormatoDetalleMovimiento()).InsertarModificarObservaciones(oFormatoDetalleMovimientoBE));
					}
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==TIPODEINFORMACION))
				{
					Helper.GenerarEsquemaXMLNTAD(((CTablaTablas) new CTablaTablas()).ListarTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TipoInformacion)
						,CNetAccessControl.GetIdUser()
						,Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadodeSaldodeFormato)));
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==REGFORMATODETMOV))
				{
					FormatoDetalleMovimientoItemDescBE oFormatoDetalleMovimientoItemDescBE = new FormatoDetalleMovimientoItemDescBE();
					Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA]) ;
					switch (oModoPagina)
					{
						case Enumerados.ModoPagina.N:
							oFormatoDetalleMovimientoItemDescBE.IdFormato = Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
							oFormatoDetalleMovimientoItemDescBE.IdRubro = Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]);
							oFormatoDetalleMovimientoItemDescBE.IdCentroOperativo = Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]);
							oFormatoDetalleMovimientoItemDescBE.IdCentroCosto = Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTOINV]);
							oFormatoDetalleMovimientoItemDescBE.Periodo = Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);
							oFormatoDetalleMovimientoItemDescBE.Descripcion = Convert.ToString(Page.Request.Params[KEYQDESCRIPCION]);
							Helper.GenerarEsquemaXMLTAD((new CFormatoDetalleMovimientoItemDescCC()).Insertar(oFormatoDetalleMovimientoItemDescBE));
							break;
						case Enumerados.ModoPagina.M:
							oFormatoDetalleMovimientoItemDescBE.IdDetDesFMTCC = Convert.ToInt32(Page.Request.Params[KEYQFMTMOVCC]);
							oFormatoDetalleMovimientoItemDescBE.Descripcion = Convert.ToString(Page.Request.Params[KEYQDESCRIPCION]);
							Helper.GenerarEsquemaXMLTAD((new CFormatoDetalleMovimientoItemDescCC()).Modificar(oFormatoDetalleMovimientoItemDescBE));
							break;
					}
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==REGFORMATODETMOVCC))
				{
					
					FormatoDetalleMovimientoDescCCBE oFormatoDetalleMovimientoDescCCBE = new FormatoDetalleMovimientoDescCCBE();
					oFormatoDetalleMovimientoDescCCBE.IdDetDesFmtCC= Convert.ToInt32(Page.Request.Params[KEYQFMTMOVCC]);
					oFormatoDetalleMovimientoDescCCBE.IdMes= Convert.ToInt32(Page.Request.Params[KEYQIDMES]);
					oFormatoDetalleMovimientoDescCCBE.IdTipoInformacion= Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFORMACION]);
					oFormatoDetalleMovimientoDescCCBE.MontoMes= Convert.ToDouble(Page.Request.Params[KEYQMONTOMES]);
					Helper.GenerarEsquemaXMLTAD((new CFormatoDetalleMovimientoDescCC()).InsertarModificar(oFormatoDetalleMovimientoDescCCBE));
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==CONSULTARCENTROCOSTO))
				{
					string NombreCampo = Helper.CampoBusqueda();
					string CAMPO1="NroCentroCosto";
					string CAMPO2="NombreCentroCosto";

					Helper.AutoBusquedaResultado(((NombreCampo==CAMPO1)||(NombreCampo==CAMPO2)?
						(new CCentroCosto()).ConsultarCentrodeCostoporNroyDescripcion(Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO]) ,NombreCampo,Helper.CriterioBusqueda())
						:(new CGrupoCentroCosto().ListarGrupoCentrodeCosto(Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO]),NombreCampo,Helper.CriterioBusqueda()))
						)
						);

				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==CONTROLPRESUPUESTALPORCENTROCOSTO))
				{
					Helper.GenerarEsquemaXMLNTAD((new CPresupuestoControl()).ConsultarControlPorGrupooCentroCosto(Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO]),Convert.ToString(Page.Request.Params[KEYQNROGRUPOCC]),Convert.ToString(Page.Request.Params[KEYQIDNROCENTROCOSTOS])));
				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==REPORTEEVALUACIONPRESUPUESTOPORCENTROCOSTO))
				{
					string NroMes = Page.Request.Params[KEYQIDMES].ToString().PadLeft(2,'0');
					DataTable dtResult;
					DataTable dt = (new CPresupuestoControl()).RelacionGastosEvaluarPresupuesto(
						Convert.ToInt32(Page.Request.Params[KEYQPERIODO])
						,Convert.ToInt32(Page.Request.Params[KEYQIDMES])
						,Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO])
						,Convert.ToInt32(Page.Request.Params[KEYQIDNROCENTROCOSTOS])
						,Convert.ToInt32(Page.Request.Params[KEYQIDCTA])
						,CNetAccessControl.GetIdUser()
						);
					if(Convert.ToInt32(Page.Request.Params[KEYQFILTRADO])==1)
					{		
						DataView dv = dt.DefaultView;
						dv.RowFilter = "substring(NatCta,3,1) in ('1','3','5')";
						dtResult = Helper.DataViewTODataTable(dv);
					}
					else{
						dtResult = dt;
					}
					Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\Presupuesto\Meses\","EvaluacionPptal_Mes_" + NroMes + ".rpt",dtResult,true);

				}
				else if (Page.Request.Params[PROCESO]!=null && (Convert.ToInt32(Page.Request.Params[PROCESO])==LISTARFORMATOESTRUCTURAMOVIMIENTO))
				{
					DataTable dt =  (new  CFormatoEstructuraMovimientoCentroCosto()).ConsultarFormatoEstructuraMovimientoCentroCosto(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]),1,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]),Convert.ToInt32(Page.Request.Params[KEYQPERIODO]),Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFORMACION]),Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTOINV]));
					Helper.GenerarEsquemaXMLNTAD(Helper.OrdenarFormatoEstructura(dt));
				}
				else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQINSERTAFORMATOMOVIMIENTOCENTROCOSTOITEM)
				{

					FormatoDetalleMovimientoCentroCostoItemBE oFormatoDetalleMovimientoCentroCostoItemBE = new FormatoDetalleMovimientoCentroCostoItemBE();
					oFormatoDetalleMovimientoCentroCostoItemBE.IdDetDesFmtCC = Convert.ToInt32(Page.Request.Params[KEYQIDDESFORMCC]);
					oFormatoDetalleMovimientoCentroCostoItemBE.IdFormato = Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
					oFormatoDetalleMovimientoCentroCostoItemBE.IdReporte = Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);
					oFormatoDetalleMovimientoCentroCostoItemBE.Idrubro = Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]);
					oFormatoDetalleMovimientoCentroCostoItemBE.Idcentrooperativo = Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]);
					oFormatoDetalleMovimientoCentroCostoItemBE.Idcentrocosto = Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTOINV]);
					oFormatoDetalleMovimientoCentroCostoItemBE.Periodo = Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);
					oFormatoDetalleMovimientoCentroCostoItemBE.Idtipoinformacion = Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFORMACION]);
					Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA]) ;
					switch (oModoPagina)
					{
						case Enumerados.ModoPagina.N:
							Helper.GenerarEsquemaXMLTAD((new CFormatoDetalleMovimientoCentroCostoItem()).Insertar(oFormatoDetalleMovimientoCentroCostoItemBE));
							break;
						case Enumerados.ModoPagina.M:
							oFormatoDetalleMovimientoCentroCostoItemBE.Montomes = Convert.ToDouble(Page.Request.Params[KEYQMONTOMES]);
							oFormatoDetalleMovimientoCentroCostoItemBE.Idmes = Convert.ToInt32(Page.Request.Params[KEYQIDMES]);
							Helper.GenerarEsquemaXMLTAD((new CFormatoDetalleMovimientoCentroCostoItem()).Modificar(oFormatoDetalleMovimientoCentroCostoItemBE));
							break;
					}
						
				}		
				else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQCONSULTARRESUMENEVALUACIONPRESUPUESTAL)
				{
					string Cta = "";
					switch(Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString())
					{
						case "1":if(Page.Request.Params[CENTROOPERATIVO].ToString()=="1"){ Cta="96";}
								 else {Cta="97";} 
							break;
						case "2":Cta = "92";
							break;

					}
			
					Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\Presupuesto\Meses\"
						,"ResumenEvaluacionPptal_PorNaturaleza.rpt"
						,(new CPresupuesto()).ConsultarResumenEvaluacionPresupuestalPorNaturaleza(Convert.ToInt32(Page.Request.Params[PERIODO]),Cta)
						,false);
				}
				else if(Convert.ToInt32(Page.Request.Params[PROCESO])==MANTENIMIENTOITEMUNISYS)
				{
					PDReqAusPptBE oPDReqAusPptBE = new PDReqAusPptBE();
					Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;
					switch (oModoPagina)
					{
						case Enumerados.ModoPagina.N:
							break;
						case Enumerados.ModoPagina.M:
							oPDReqAusPptBE.CodCeo = this.NroCentroOperativo.ToString();
							oPDReqAusPptBE.NroReq = this.NroRequerimiento;
							oPDReqAusPptBE.Cod_rcs = this.CodigoRecurso;
							oPDReqAusPptBE.CntDmaAju = this.CantidadDMAAJU;
							oPDReqAusPptBE.CntDmlAju = this.CantidadDMLAJU;
							oPDReqAusPptBE.CntReqAju = this.CantidadRequerimientoAJU;
							oPDReqAusPptBE.PrcUntAju = this.PrecioUntAJU;
							oPDReqAusPptBE.UndMedAju = this.UnidaddeMedidaAJU;
							oPDReqAusPptBE.TipoRCS = this.TipoRCS;
							Helper.GenerarEsquemaXMLTAD((new CPDReqAusPpt()).Modificar(oPDReqAusPptBE));
							break;
						case Enumerados.ModoPagina.E:
							oPDReqAusPptBE.CodCeo = this.NroCentroOperativo.ToString();
							oPDReqAusPptBE.NroReq = this.NroRequerimiento;
							oPDReqAusPptBE.IdEstadoUnisys = this.IdEstadoUnisys;
							Helper.GenerarEsquemaXMLTAD((new CPDReqAusPpt()).Eliminar(oPDReqAusPptBE));
							
							break;
				
					}
				}	
					/*INICIAR UN NURVO PROCESO*/
				else if(Convert.ToInt32(Page.Request.Params[PROCESO])==CONSULTARESUMENPORITEMCCCTA)
				{
					Helper.GenerarEsquemaXMLNTAD((new CPresupuestoItemDetalleRequerimientos()).ConsultarTotalporItemCentroCostoCuenta(this.Periodo,this.NroCentroCosto,this.CuentaContable));
				}

			}
		}

		#region Mantenimiento de Presupuesto
			private void RegistrarPresupuesto()
			{
				SaldoContableBE oSaldoContableBE = new SaldoContableBE();

				oSaldoContableBE.IDCENTROOPERATIVO =this.IdCentroOperativo;
				oSaldoContableBE.NROCENTROOPERATIVO = this.NroCentroOperativo;
				oSaldoContableBE.IDGRUPOCC = this.IdGrupoCentroCosto;
				oSaldoContableBE.NROGRUPOCC = this.NroGrupoCentroCosto;
				oSaldoContableBE.IDCENTROCOSTO = this.IdCentroCosto;
				oSaldoContableBE.NROCENTROCOSTO = this.NroCentroCosto;
				oSaldoContableBE.PERIODO = this.Periodo;
				oSaldoContableBE.IDMES = this.IdMes;
				oSaldoContableBE.CUENTACONTABLE = this.CuentaContable;
				oSaldoContableBE.MONTOPRESUPUESTO= this.MontoPresupuesto;
				oSaldoContableBE.IDUSUARIOREGISTRO = CNetAccessControl.GetIdUser();
				double []MontoTotal = ((CPresupuesto) new CPresupuesto()).InsertarModificar(oSaldoContableBE);
				//if(MontoTotal>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Presupuesto formulación",this.ToString(),"Se registro monto del presupuesto correctamente" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
					//this.ObtenerMontoTotal(MontoTotal);
					Helper.GenerarEsquemaXMLTAD(MontoTotal[0].ToString()+";"+MontoTotal[1].ToString()+";"+MontoTotal[2].ToString());
				}
			}

		#region Crear respuesta 
			private void ObtenerMontoTotal(double []MontoTotal)
			{
				Response.Clear();
				Response.ContentType = "text/xml";
				string output="<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n";
				output += "<PRESUPUESTO>\n";
				output += "  <CentroCosto>\n";
				output += "    <MontoTotal1>"    + MontoTotal[0].ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoTotal1>\n";
				output += "    <MontoTotal2>"    + MontoTotal[1].ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoTotal2>\n";
				output += "    <MontoTotal3>"    + MontoTotal[2].ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoTotal3>\n";
				output += "  </CentroCosto>\n";
				output += "</PRESUPUESTO>";
				Response.Write(output);
				Response.End();
			}
		#endregion
		#endregion


		#region Implementacion de Procesos y Llamadas PostBack
		private void ObtenerDetalleporCentroOperativo(string idtipoPresupuesto,int pPeriodo,int pMes)
		{
			if (Page.Request.Params[KEYQPPTO]==VISTAPPTOPRINCIPAL)
			{
				this.GenerarDocumentoXMLDeCentroDetalleyNIvel3(((CPresupuesto) new CPresupuesto()).ConsultarDetalleEvaluacionPresupuestalporTipoPresupuesto(idtipoPresupuesto,pPeriodo,pMes));
			}
			else
			{
				this.GenerarDocumentoXMLDeCentroDetalleyNIvel3(((CPresupuesto) new CPresupuesto()).ConsultarDetalleEvaluacionPresupuestalporTipoPresupuestoAuxiliar(idtipoPresupuesto,pPeriodo,pMes));
			}
		}

		private void ObtenerDetalleporCentroOperativoNivel3(string idtipoPresupuesto,int idCentroOperativo,int pPeriodo,int pMes)
		{
			this.GenerarDocumentoXMLDeCentroDetalleyNIvel3(((CPresupuesto) new CPresupuesto()).ConsultarDetalleEvaluacionPresupuestalporTipoPresupuestoNivel3(idtipoPresupuesto,idCentroOperativo,pPeriodo,pMes));
		}
		private void GenerarDocumentoXMLDeCentroDetalleyNIvel3(DataTable dt)
		{
			Response.Clear();
			Response.ContentType = "text/xml";
			string output="<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n";
			output += "<PRESUPUESTO>\n";
			foreach(DataRow dr in dt.Rows)
			{
				output += "  <CentroOperativo>\n";
				output += "    <idTipoPresupuesto>"    + dr[Enumerados.FinColumnaPresupuestoEvaluacion.idTipoPresupuesto.ToString()] +	"</idTipoPresupuesto>\n";
				output += "    <idT>"    + dr["idT"] +	"</idT>\n";
				output += "    <idCentroOperativo>"	+ dr[Enumerados.FinColumnaPresupuestoEvaluacion.idCentroOperativo.ToString()] +	"</idCentroOperativo>\n";
				output += "    <NodoPadre>"	+ dr[Enumerados.FinColumnaPresupuestoEvaluacion.NodoPadre.ToString()] +	"</NodoPadre>\n";
				output += "    <NombreTipoPresupuestoCuenta>"	+ dr[Enumerados.FinColumnaPresupuestoEvaluacion.NombreTipoPresupuestoCuenta.ToString()] +	"</NombreTipoPresupuestoCuenta>\n";
				/*Datos de Sima Peru*/
				output += "    <MontoPresupuestadoPeru>"	+ Convert.ToDouble(dr[Enumerados.FinColumnaPresupuestoEvaluacion.MontoPresupuestadoPeru.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoPresupuestadoPeru>\n";
				output += "    <MontoEjecutadoPeru>"	+ Convert.ToDouble(dr[Enumerados.FinColumnaPresupuestoEvaluacion.MontoEjecutadoPeru.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoEjecutadoPeru>\n";
				output += "    <MontoSaldoPeru>"	+ Convert.ToDouble(dr[Enumerados.FinColumnaPresupuestoEvaluacion.MontoSaldoPeru.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoSaldoPeru>\n";
				/*Datos de Sima Iquitos*/
				output += "    <MontoPresupuestadoIquitos>"	+ Convert.ToDouble(dr[Enumerados.FinColumnaPresupuestoEvaluacion.MontoPresupuestadoIquitos.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoPresupuestadoIquitos>\n";
				output += "    <MontoEjecutadoIquitos>"	+ Convert.ToDouble(dr[Enumerados.FinColumnaPresupuestoEvaluacion.MontoEjecutadoIquitos.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoEjecutadoIquitos>\n";
				output += "    <MontoSaldoIquitos>"	+ Convert.ToDouble(dr[Enumerados.FinColumnaPresupuestoEvaluacion.MontoSaldoIquitos.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoSaldoIquitos>\n";
				output += "  </CentroOperativo>\n";
			}
			output += "</PRESUPUESTO>";
			Response.Write(output);
			Response.End();

		}
		#region Listar Centros de Costo
			private void ObtenerListadodeCentrosdeCosto(string idtipoPresupuesto,int idCentroOperativo,int idGrupoCC,int Periodo,int OtrosCentros)
			{
				//GenerarDocumentoXMLDeCentrosdeCosto(((CPresupuesto) new CPresupuesto()).ConsultarEvaluacionPrespuestalRelaciondeCentrosdeCosto(idtipoPresupuesto,idCentroOperativo,idGrupoCC,Periodo,OtrosCentros));
				Helper.GenerarEsquemaXMLNTAD(((CPresupuesto) new CPresupuesto()).ConsultarEvaluacionPrespuestalRelaciondeCentrosdeCosto(idtipoPresupuesto,idCentroOperativo,idGrupoCC,Periodo,OtrosCentros));
			}
			private void GenerarDocumentoXMLDeCentrosdeCosto(DataTable dt)
			{
				Response.Clear();
				Response.ContentType = "text/xml";
				string output="<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n";
				output += "<PRESUPUESTO>\n";
				foreach(DataRow dr in dt.Rows)
				{
					output += "  <CentroCosto>\n";
					output += "    <idCentrodeCosto>"    + dr["idCentroCosto"] +	"</idCentrodeCosto>\n";
					output += "    <NroGrupoCentroCosto>"	+ dr["NroGrupoCC"] +	"</NroGrupoCentroCosto>\n";
					output += "    <NroCentroCosto>"	+ dr["NroCC"] +	"</NroCentroCosto>\n";
					output += "    <NombreCentroCosto>"	+ dr["NombreCentroCosto"] +	"</NombreCentroCosto>\n";
					output += "    <CuentaContable>"	+ dr["NroCta"] +	"</CuentaContable>\n";
					output += "  </CentroCosto>\n";
				}
				output += "</PRESUPUESTO>";
				Response.Write(output);
				Response.End();
			}
			/*------------------------------------------------------------------------------------------------------------------*/
			private void ObtenerCentrosdeCostoDetalleCuenta5Dig(string idtipoPresupuesto,int idCentroOperativo,int idGrupoCC,int idCentroCosto,int Periodo,int Mes,string CuentaContable3Dig)
			{
				if (Page.Request.Params[KEYQPPTO].ToString()==VISTAPPTOPRINCIPAL)
				{
					GenerarDocumentoXMLDeCentrosdeCostoDetalleCuenta5Dig(((CPresupuesto) new CPresupuesto()).ConsultarEvaluacionPrespuestalPorCentrosdeCosto5Dig(idtipoPresupuesto,idCentroOperativo,idGrupoCC,idCentroCosto,Periodo,Mes,CuentaContable3Dig));
				}
				else
				{
					GenerarDocumentoXMLDeCentrosdeCostoDetalleCuenta5Dig(((CPresupuesto) new CPresupuesto()).ConsultarEvaluacionPrespuestalPorCentrosdeCosto5DigAuxiliar(idtipoPresupuesto,idCentroOperativo,idGrupoCC,idCentroCosto,Periodo,Mes,CuentaContable3Dig));
				}
			}
			private void GenerarDocumentoXMLDeCentrosdeCostoDetalleCuenta5Dig(DataTable dt)
			{
				Response.Clear();
				Response.ContentType = "text/xml";
				string output="<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n";
				output += "<PRESUPUESTO>\n";
				foreach(DataRow dr in dt.Rows)
				{
					output += "  <CentroCosto>\n";
					output += "    <CuentaContable>"    + dr["CuentaContable"].ToString() +	"</CuentaContable>\n";
					output += "    <NombreCuenta>"	+ dr["NombreCuenta"].ToString() +	"</NombreCuenta>\n";
					if ((Page.Request.Params[KEYQUIENLLAMA]!=null)&&(Page.Request.Params[KEYQUIENLLAMA].ToString()=="0"))
					{
						output += "    <MontoPresupuestado>"	+ Convert.ToDouble(dr["MontoPresupuestadoMes"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoPresupuestado>\n";
						output += "    <MontoEjecutado>"	+ Convert.ToDouble(dr["MontoEjecutadoMes"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoEjecutado>\n";
						output += "    <MontoSaldo>"	+ Convert.ToDouble(dr["MontoSaldoMes"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoSaldo>\n";
					}
					else
					{
						output += "    <MontoPresupuestado>"	+ Convert.ToDouble(dr["MontoPresupuestado"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoPresupuestado>\n";
						output += "    <MontoEjecutado>"	+ Convert.ToDouble(dr["MontoEjecutado"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoEjecutado>\n";
						output += "    <MontoSaldo>"	+ Convert.ToDouble(dr["MontoSaldo"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoSaldo>\n";
					}
					output += "  </CentroCosto>\n";
				}
				output += "</PRESUPUESTO>";
				Response.Write(output);
				Response.End();
			}
		#endregion

		#region Evaluacion
		/*------------------------------------------------------------------------------------------------------------------*/
		private void ObtenerPrespuestoFormulacionVSEjecucionPorCentrosdeCosto5Dig(string idtipoPresupuesto,int idCentroOperativo,int idGrupoCC,int idCentroCosto,int Periodo,int Mes,string CuentaContable3Dig)
		{
			GenerarDocumentoXMLObtenerPrespuestoFormulacionVSEjecucionPorCentrosdeCosto5Dig(((CPresupuesto) new CPresupuesto()).ConsultarPrespuestoFormulacionVSEjecucionPorCentrosdeCosto5Dig(idtipoPresupuesto,idCentroOperativo,idGrupoCC,idCentroCosto,Periodo,Mes,CuentaContable3Dig));
		}
		private void GenerarDocumentoXMLObtenerPrespuestoFormulacionVSEjecucionPorCentrosdeCosto5Dig(DataTable dt)
		{
			Response.Clear();
			Response.ContentType = "text/xml";
			string output="<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n";
			output += "<PRESUPUESTO>\n";
			foreach(DataRow dr in dt.Rows)
			{
				output += "  <CentroCosto>\n";
				output += "    <CuentaContable>"    + dr["CuentaContable"].ToString() +	"</CuentaContable>\n";
				output += "    <NombreCuenta>"	+ dr["NombreCuenta"].ToString() +	"</NombreCuenta>\n";
				output += "    <MontoPresupuestado>"	+ Convert.ToDouble(dr["MontoPresupuestado"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoPresupuestado>\n";
				output += "    <MontoPresupuestadoAlMes>"	+ Convert.ToDouble(dr["MontoPresupuestadoAlMes"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoPresupuestadoAlMes>\n";
				output += "    <Enero>"	+ Convert.ToDouble(dr["MontoPresupuestadoAlMes"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Enero>\n";
				output += "    <Febrero>"	+ Convert.ToDouble(dr["Febrero"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Febrero>\n";
				output += "    <Marzo>"	+ Convert.ToDouble(dr["Marzo"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Marzo>\n";
				output += "    <Abril>"	+ Convert.ToDouble(dr["Abril"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Abril>\n";
				output += "    <Mayo>"	+ Convert.ToDouble(dr["Mayo"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Mayo>\n";
				output += "    <Junio>"	+ Convert.ToDouble(dr["Junio"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Junio>\n";
				output += "    <Julio>"	+ Convert.ToDouble(dr["Julio"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Julio>\n";
				output += "    <Agosto>"	+ Convert.ToDouble(dr["Agosto"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Agosto>\n";
				output += "    <Setiembre>"	+ Convert.ToDouble(dr["Setiembre"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Setiembre>\n";
				output += "    <Octubre>"	+ Convert.ToDouble(dr["Octubre"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Octubre>\n";
				output += "    <Noviembre>"	+ Convert.ToDouble(dr["Noviembre"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Noviembre>\n";
				output += "    <Diciembre>"	+ Convert.ToDouble(dr["Diciembre"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Diciembre>\n";
				output += "    <MontoEjecucionReal>"	+ Convert.ToDouble(dr["MontoEjecucionReal"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</MontoEjecucionReal>\n";
				output += "    <VariacionAlMes>"	+ Convert.ToDouble(dr["VariacionAlMes"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</VariacionAlMes>\n";
				output += "    <SaldoPPTO>"	+ Convert.ToDouble(dr["SaldoPPTO"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</SaldoPPTO>\n";
				output += "  </CentroCosto>\n";
			}
			output += "</PRESUPUESTO>";
			Response.Write(output);
			Response.End();
		}

		#endregion

		#region Formulacion Presupuestal
		/*------------------------------------------------------------------------------------------------------------------*/
		private void ObtenerFormulacionCentrosdeCostoDetalleCuenta5Dig(string idtipoPresupuesto,int idCentroOperativo,int idGrupoCC,int idCentroCosto,int Periodo,string CuentaContable3Dig)
		{
			GenerarDocumentoXMLFormulacionDeCentrosdeCostoDetalleCuenta5Dig(((CPresupuesto) new CPresupuesto()).ConsultarFormulacionPrespuestalPorCentrosdeCosto5Dig(idtipoPresupuesto,idCentroOperativo,idGrupoCC,idCentroCosto,Periodo,CuentaContable3Dig));
		}
		private void GenerarDocumentoXMLFormulacionDeCentrosdeCostoDetalleCuenta5Dig(DataTable dt)
		{
			Response.Clear();
			Response.ContentType = "text/xml";
			string output="<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n";
			output += "<PRESUPUESTO>\n";
			foreach(DataRow dr in dt.Rows)
			{
				output += "  <CentroCosto>\n";
				output += "    <CuentaContable>"    + dr["CuentaContable"].ToString() +	"</CuentaContable>\n";
				output += "    <NombreCuenta>"	+ dr["NombreCuenta"].ToString() +	"</NombreCuenta>\n";
				output += "    <Enero>"	+ Convert.ToDouble(dr["Enero"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Enero>\n";
				output += "    <Febrero>"	+ Convert.ToDouble(dr["Febrero"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Febrero>\n";
				output += "    <Marzo>"	+ Convert.ToDouble(dr["Marzo"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Marzo>\n";
				output += "    <Abril>"	+ Convert.ToDouble(dr["Abril"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Abril>\n";
				output += "    <Mayo>"	+ Convert.ToDouble(dr["Mayo"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Mayo>\n";
				output += "    <Junio>"	+ Convert.ToDouble(dr["Junio"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Junio>\n";
				output += "    <Julio>"	+ Convert.ToDouble(dr["Julio"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Julio>\n";
				output += "    <Agosto>"	+ Convert.ToDouble(dr["Agosto"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Agosto>\n";
				output += "    <Setiembre>"	+ Convert.ToDouble(dr["Setiembre"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Setiembre>\n";
				output += "    <Octubre>"	+ Convert.ToDouble(dr["Octubre"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Octubre>\n";
				output += "    <Noviembre>"	+ Convert.ToDouble(dr["Noviembre"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Noviembre>\n";
				output += "    <Diciembre>"	+ Convert.ToDouble(dr["Diciembre"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Diciembre>\n";
				output += "    <Total>"	+ Convert.ToDouble(dr["Total"]).ToString(Utilitario.Constantes.FORMATODECIMAL4) +	"</Total>\n";
				output += "  </CentroCosto>\n";
			}
			output += "</PRESUPUESTO>";
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
	}
}
