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
using SIMA.Controladoras.Personal;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using SIMA.EntidadesNegocio.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Runtime.InteropServices;
using System.Net;
using SIMA.EntidadesNegocio.Personal;
using System.Globalization;
using System.Threading;
using zkemkeeper;

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for Procesar.
	/// </summary>
	public class Procesar : System.Web.UI.Page
	{
		const string KEYQIDLUGARTRABAJO="IdLugTrab";
		const string PROCESO ="idProceso";
		const string KEYQNOMBCM ="NCM";

		const int KEYQBUSCARTRABAJADOR=246;
		const int KEYQBUSCARITEMTABLAGENERAL=247;
		const int KEYQAGREGARCM=248;
		const int KEYQBUSCARTRABEXAMENMEDICO=249;
		const int KEYQVERIFICADISPONIBILIDAD=250;
		const int KEYQVERIFICADISPONIBILIDADEMEI=251;
		const int KEYQRESTRICCIONESINSERTA=252;
		const int KEYPRCBUSQUEDACIASEGUROS=58;	
		const int KEYPRCBUSQUEDAPROVEEDOR=57;
		const int KEYINSERTAPROVE_CLI=234;

		const int KEYCATALOGODIAGNOSTICO=235;
		const int KEYBUSCAPROBACION=295;

		const int KEYCALCULARVENCIMIENTO=296;
		const int KEYNOCUMPLERESTRICCIONES=297;

		const int KEYBUSCAAREAYPSEUDO=312;
		const int KEYREGPROGING=315;

		const int KEYCALULAFECHAVENCE=317;
		const int KEYQRESTRICIONESSIMA=318;
		
		const int KEYQINSACTPERSONALCAPACITACION=319;
		const int KEYQBUSCAPERSONAL = 320;
		const int KEYQANTECEDENTES=321;

		const int KEYQLISTARPROGRAMACIONESTRABAJADOR=322;
		const int KEYQINSLSTPERSONACAPACITADAS=323;
		const int KEYQINSMATASTOCK=324;
		const int KEYQELIMATASTOCK=325;

		const int KEYQBUSCARPERSONALO7=326;
		const int KEYQCLASMATPERSONA=327;
		const int KEYQINSACTKARDEXPERSONA=328;
		const int KEYQINSACTLSTMATINSTOCK=330;

		const int KEYQINSACTCONFORMIDAD=331;

		const int KEYQLISTARHUELLASTRABAJADOR=332;
		const int KEYQOBTENERHUELLARELOG=336;
		const int KEYQINSACTHUELLA=333;

		const int KEYQNROITEMCONFIRMA=334;
		const int KEYQITEMDETALLEXCODIGO=335;

		const int KEYADMPATOGENO=347;

		const int KEYLISTATIPOENTIDAD=349;
		const int KEYQAUTORIZAFERIADO=352;

		const int KEYQVERIFICAAUTORIZAFERIADO=353;
		const int KEYQLISTARAUTORIZAFERIADO=354;
		const int KEYQDATOSRELACIONADOSTRABAJADOR=355;

		/*AutoServicio*/
		const int KEYQAUTOSERVICIOSPAPELETAS=356;



		//const string KEYQDNI ="NroDNI";
		const string KEYQPERIODO ="Periodo";
		const string KEYQIDEXAMEN ="idExa";
		const string KEYQIDFICHA ="IdFicha";
		const string KEYQNOMTRAB ="NomTrab";
		const string KEYQIDESTADO ="IdEst";
		const string KEYQIDRESTRICCION ="IdRestr";
		const string KEYQIDTIPOENTIDAD ="idTipoEntidad";
		const string KEYQIDENTIDAD ="idEntidad";
		const string KEYQIDTIPOPROGRAMACION="TipoPrg";

		const string KEYQFECHAINI="FechaIni";
		const string KEYQFECHAVENCE="FechaVence";

		const string KEYQCODPERSONA="CodPers";
		const string KEYQCLASEMAT="ClasMat";

		const string KEYQNROPR="NroPR";

		private string NroPortaRetrato
		{
			get{return Page.Request.Params[KEYQNROPR].ToString();}
		}

		private int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}
		private int IdExamen
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDEXAMEN]);}
		}
		private int IdFicha
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDFICHA]);}
		}
		private string NombreCentroMedico
		{
			get{return Page.Request.Params[KEYQNOMBCM].ToString();}
		}

		private int IdEstado
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDESTADO].ToString());}
		}

		private int IdRestriccion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDRESTRICCION].ToString());}
		}

		public string CodigoPersona
		{
			get{return Page.Request.Params[KEYQCODPERSONA].ToString();}
		}

		public string ClaseMaterial
		{
			get{return Page.Request.Params[KEYQCLASEMAT].ToString();}
		}

		const string KEYQPERIODONOREST ="PeriodoNoR";
		const string KEYQIDNOREST ="IdNoR";
		const string KEYQPERIODOPRG ="PeriodoPrg";
		const string KEYQIDPROG ="NroProg";

		private int PeriodoProg
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODOPRG]);}
		}
		private int NroProg
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDPROG]);}
		}
		private int PeriodoNoRestriccion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODONOREST]);}
		}
		private int IdNoRestriccion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDNOREST]);}
		}


		const string KEYQNDIAS="Ndias";


		private DateTime FechaInicio
		{
			get
			{
				/*string []arrFecha = Page.Request.Params[KEYQFECHAINI].ToString().Split('/');
				return DateTime.Parse(arrFecha[2] +'/'+ arrFecha[0]+'/'+ arrFecha[1]);}
				*/
				return DateTime.Parse(Page.Request.Params[KEYQFECHAINI]);
			}
		}
		private DateTime FechaVence
		{
			get
			{
				return DateTime.Parse(Page.Request.Params[KEYQFECHAVENCE]);
			}
		}
		private int NroDias
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQNDIAS]);
			}
		}


		/*Para el registro de la prog desde la puerta de ing*/
		const string KEYQOBS="obs";
		public string Observaciones
		{
			get{return Page.Request.Params[KEYQOBS].ToString();}
		}
		const string KEYQIDUSUAPROB="IdPersApro";
		public int IdUsuarioaprobacion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDUSUAPROB]);}
		}
		const string KEYQTIPOENTIDAD="TipoEnt";
		public int IdTipoEntidad
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQTIPOENTIDAD]); }
		}
		public int IdEntidad
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDENTIDAD]); }
		}
		const string KEYQIDAREA="idArea";
		public int IdArea
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDAREA]);}
		}


		public int IdProceso
		{
			get{return Convert.ToInt32(Page.Request.Params[PROCESO]);}
		}

		const string KEYQSELECCION = "IdSelec";
		const string KEYQIDPERSONAL = "IdPers";
		
		const string KEYQNROPER ="NroPer";
		const string KEYQNRODNI ="NroDNI";
		const string KEYQAPPNOM ="AppNom";
		const string KEYQNOMAREA ="NomArea";

		const string KEYQEXACOVID ="ExCov";
		const string KEYQDIAGCOVID ="DIagCov";
		const string KEYQFECHVIGCOVID ="FVigCov";



		public int IdSeleccion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQSELECCION]);}
		}
		public int IdPersona
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDPERSONAL]);}
		}
		public string NroPersonal
		{
			get{return Page.Request.Params[KEYQNROPER];}
		}
		public string NroDNI
		{
			get{return Page.Request.Params[KEYQNRODNI];}
		}

		

		public string ApellidosNombres
		{
			get{return Page.Request.Params[KEYQAPPNOM];}
		}
		public string NombreArea
		{
			get{return Page.Request.Params[KEYQNOMAREA];}
		}
		

		const string KEYQIDPROGASISCAP = "IdProgAsis";
		const string KEYQIDPROGCAP = "IdProg";
		const string KEYQPERODOPROGCAP = "PeriodoProg";
		const string KEYQNOTA ="Nota";


		public string IdProgAsis
		{
			get{return Page.Request.Params[KEYQIDPROGASISCAP].ToString();}
		}

		public int IdProgCap
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDPROGCAP].ToString());}
		}
		public int PeriodoProgCap
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERODOPROGCAP].ToString());}
		}
	
		public int Nota
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQNOTA].ToString());}
		}


		//Covid
		private int Examencovid
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQEXACOVID].ToString());}
		}
		private  int DiagnosticoCov
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQDIAGCOVID].ToString());}
		}
		private  DateTime FechaVigCov
		{
			get{return Convert.ToDateTime(Page.Request.Params[KEYQFECHVIGCOVID].ToString());}
		}


		/*VARIABLE PARA STOCK DE MATERIALES*/
		const string KEYCODITEM = "CodItem";
		const string KEYQCODCEO = "CodCeo";
		const string KEYQCODALM = "CodAlm";
		const string KEYQNROVALSAL = "NroValSal";
		const string KEYQCODMAT="CodMat";
		const string KEYQCANTMAT="CantMat";
		const string KEYQIDTBLTALLA="IdTblTalla";
		const string KEYQIDTALLA="IdTalla";
		const string KEYQFECHAENT="FechaEnt";
		const string KEYCODENTREGA = "CodEnt";

		const string KEYQFECHAAUT="FechaAut";

		public string CodigoEntrega
		{
			get{return Page.Request.Params[KEYCODENTREGA].ToString();}
		}

		public string CodigoItem
		{
			get{return Page.Request.Params[KEYCODITEM].ToString();}
		}

		public string CodigoCentro
		{
			get{return Page.Request.Params[KEYQCODCEO].ToString();}
		}
		public string CodigoAlmacen
		{
			get{return Page.Request.Params[KEYQCODALM].ToString();}
		}
		public string NroValedeSalida
		{
			get{return Page.Request.Params[KEYQNROVALSAL].ToString();}
		}
		public string CodigoMaterial
		{
			get{return Page.Request.Params[KEYQCODMAT].ToString();}
		}

		public double CantidadMaterial
		{
			get{return Convert.ToDouble(Page.Request.Params[KEYQCANTMAT].ToString());}
		}

		
		public int IdTblTalla
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTBLTALLA].ToString());}
		}

		public string IdTalla
		{
			get{return Page.Request.Params[KEYQIDTALLA].ToString();}
		}
		private DateTime FechaEntrega
		{
			get
			{
				return DateTime.Parse(Page.Request.Params[KEYQFECHAENT].ToString());
			}
		}

		private DateTime FechaAutoriza
		{
			get
			{
				return DateTime.Parse(Page.Request.Params[KEYQFECHAAUT].ToString());
			}
		}

		//Constantes para huellas
		const string KEYQCODHUELLA="CodHuella";
		const string KEYQIDHUELLA="IdHuella";
		const string KEYQHUELLA1="Huella1";
		const string KEYQHUELLA2="Huella2";
		const string KEYQCALIDAD="Calidad";
		const string KEYQIDVER="IdVer";
		public string CodigoHuella
		{
			get{return Page.Request.Params[KEYQCODHUELLA].ToString();}
		}

		public int IdHuella
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDHUELLA].ToString());
			}
		}
		public string strHuellafmt1
		{
			get
			{
				return Page.Request.Params[KEYQHUELLA1].ToString();
			}
		}
		public string strHuellafmt2
		{
			get
			{
				return Page.Request.Params[KEYQHUELLA2].ToString();
			}
		}

		public string Calidad
		{
			get
			{
				return Page.Request.Params[KEYQCALIDAD].ToString();
			}
		}
		public string IdVersion
		{
			get
			{
				return Page.Request.Params[KEYQIDVER].ToString();
			}
		}

		

		const string KEYQCODAREA="IdArea";
		public string CodArea
		{
			get{return Page.Request.Params[KEYQCODAREA].ToString();}
		}

		const string KEYQIPMACHINE="IpM";
		public string IpMachine
		{
			get{return Page.Request.Params[KEYQIPMACHINE].ToString();}
		}
		const string KEYQPUERTOMACHINE="Puerto";
		public int PuertoMachine
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPUERTOMACHINE].ToString());}
		}

		const string KEYQIDORG="IdOrg";
		public int IdOrigen
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDORG].ToString());}
		}


		private void Page_Load(object sender, System.EventArgs e)
		{


			if(!Page.IsPostBack)
			{
				try
				{
					if (Page.Request.Params[PROCESO]!=null)
					{	
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQBUSCARTRABAJADOR)
						{
							Helper.AutoBusquedaResultado((new CPersonalNoAutorizado()).ConsultarTrabajadorXApellido(Helper.CriterioBusqueda()));
						}
					
						if (Convert.ToInt32(Page.Request.Params[PROCESO])==KEYPRCBUSQUEDACIASEGUROS)
						{
							const int IDTABLASEGURO = 454;
							DataView dv = (new CTablaTablas()).ListaTodosCombo(IDTABLASEGURO).DefaultView;
							dv.RowFilter = "DESCRIPCION LIKE '%" + Helper.CriterioBusqueda() + "%'";
							Helper.AutoBusquedaResultado(Helper.DataViewTODataTable(dv));
						}
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYPRCBUSQUEDAPROVEEDOR)
						{
							string st=Helper.CampoBusqueda().ToLower();
							if(st=="nroproveedor")
							{
								Helper.AutoBusquedaResultado((new CProveedor()).ConsultarProveedorXCriterio(Helper.CampoBusqueda(),Helper.CriterioBusqueda()));
							}
							else if(st=="razonsocial")
							{
								if(Page.Request.Params[KEYQIDTIPOENTIDAD].ToString()=="0")
								{
									Helper.AutoBusquedaResultado((new CCliente()).ConsultarClienteXRazonSocial(Helper.CriterioBusqueda()));
								}
								else
								{
									Helper.AutoBusquedaResultado((new CProveedor()).ConsultarProveedorXCriterio(Helper.CampoBusqueda(),Helper.CriterioBusqueda()));
								}
							}
						}
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQBUSCARITEMTABLAGENERAL)
						{
							Helper.AutoBusquedaResultado((new CTablaTablas()).ListarTodos(570,Helper.CriterioBusqueda()));
						}
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQAGREGARCM)
						{
							TablaTablas oTablaTablas = new TablaTablas();
							oTablaTablas.IdCabeceraTablaTablas = 570;
							oTablaTablas.Var1="0";
							oTablaTablas.Var2="0";
							oTablaTablas.Var3="0";
							oTablaTablas.Flg1='0';
							oTablaTablas.Flg2='0';
							oTablaTablas.Porc1=0;
							oTablaTablas.Porc2=0;
							oTablaTablas.Descripcion="";
							oTablaTablas.Observaciones=this.NombreCentroMedico;

							Helper.GenerarEsquemaXMLTAD((new CTablaTablas()).Insertar(oTablaTablas));
						}
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQBUSCARTRABEXAMENMEDICO)
						{
							Helper.AutoBusquedaResultado((new CCCTT_ExamenMedicoHistorial()).BuscarPorApellidosyNombres(Helper.CriterioBusqueda()));
						}
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQVERIFICADISPONIBILIDAD)
						{
							Helper.GenerarEsquemaXMLNTAD((new CCCTT_InduccionEvaluacion()).ListaDisponibilidadTrabajador(this.NroDNI));
						}
					
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQVERIFICADISPONIBILIDADEMEI)
						{
															
							Helper.GenerarEsquemaXMLNTAD((new CCCTT_InduccionEvaluacion()).ListarDisponibilidadTrabajadorEMEI(this.NroDNI));
						}
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQRESTRICCIONESINSERTA)
						{
							ExamenMedicoRestricionesBE oExamenMedicoRestricionesBE = new ExamenMedicoRestricionesBE();
							oExamenMedicoRestricionesBE.Periodo = this.Periodo;
							oExamenMedicoRestricionesBE.Idexamen = this.IdExamen;
							oExamenMedicoRestricionesBE.IdRestriccion = this.IdRestriccion;
							oExamenMedicoRestricionesBE.IdEstado = this.IdEstado;

							Helper.GenerarEsquemaXMLTAD((new CCCTT_ExamenMedicoRestriciones()).InsertarUpdate(oExamenMedicoRestricionesBE));
						}
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYBUSCAPROBACION)
						{
							Helper.GenerarEsquemaXMLNTAD((new CCCTT_ExamenMedico()).AprobacionPersonalContratista(this.NroDNI));
						}
					
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYCATALOGODIAGNOSTICO)
						{
							string cadena = Helper.Archivo.Leer(@"C:\SIMANETCOMPLEMENTOS\ext-3.2.1\topics-remote.php");
							Response.Clear();
							Response.ClearHeaders();
							Response.AddHeader("Content-Type", "text/plain");
							Response.Write(cadena);
							Response.Flush();
							Response.End();
						}
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYCALCULARVENCIMIENTO)
						{
							Helper.GenerarEsquemaXMLTAD((new CCCTT_ExamenMedico()).CalcularFechaVencimieto(this.FechaInicio));
						}
						else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYCALULAFECHAVENCE)
						{
							Helper.GenerarEsquemaXMLTAD((new CCCTT_ExamenMedico()).CalcularFechaVencimiento(SIMA.Utilitario.Enumerados.CalularFechaPor.Dia, this.NroDias, this.FechaInicio));
						}
						else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYNOCUMPLERESTRICCIONES)
						{
							RestriccionesNoConsiderdasBE oRestriccionesNoConsiderdasBE=new RestriccionesNoConsiderdasBE();
							oRestriccionesNoConsiderdasBE.Periodo = this.PeriodoNoRestriccion;
							oRestriccionesNoConsiderdasBE.IdNoRestriccion= this.IdNoRestriccion;
							oRestriccionesNoConsiderdasBE.PeriodoRestric= this.Periodo;
							oRestriccionesNoConsiderdasBE.IdExamenRestric= this.IdExamen;
							oRestriccionesNoConsiderdasBE.PeriodoProg= this.PeriodoProg;
							oRestriccionesNoConsiderdasBE.NroProg= this.NroProg;
							oRestriccionesNoConsiderdasBE.IdRestriccion= this.IdRestriccion;
							oRestriccionesNoConsiderdasBE.pIdEstado= this.IdEstado;

							Helper.GenerarEsquemaXMLTAD((new CCCTT_RestriccionesNoConsiderdas()).InsertarModifica(oRestriccionesNoConsiderdasBE));
						}
					
						else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYBUSCAAREAYPSEUDO)
						{
							Helper.AutoBusquedaResultado((new CArea()).ListarAreaYPseudoArea(Helper.CriterioBusqueda()));
						}
						else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYREGPROGING)
						{
							//0 Contratista  1 Visitas 2 Ingreso Por Puerta 3 Tripulante   

							CCTT_ProgramacionBE oCCTT_ProgramacionBE = new CCTT_ProgramacionBE();
							oCCTT_ProgramacionBE.IdTipoEntidad = this.IdTipoEntidad;
							oCCTT_ProgramacionBE.IdEntidad = this.IdEntidad;
							oCCTT_ProgramacionBE.IdJefeProyecto = this.IdUsuarioaprobacion;
							oCCTT_ProgramacionBE.FechaInicio= DateTime.Now;
							oCCTT_ProgramacionBE.FechaTermino=DateTime.Now;
							oCCTT_ProgramacionBE.HoraInicio= (DateTime.Now).ToShortTimeString();
							oCCTT_ProgramacionBE.HoraTermino=DateTime.Now.ToShortTimeString();
							oCCTT_ProgramacionBE.IdCIASeguros = 99;
							oCCTT_ProgramacionBE.IdLugardeTrabajo= Convert.ToInt32(Page.Request.Params[KEYQIDLUGARTRABAJO]);//ANTES 22 AHORA 999
							oCCTT_ProgramacionBE.TipoProgramacion= Convert.ToInt32(Page.Request.Params[KEYQIDTIPOPROGRAMACION]);
							oCCTT_ProgramacionBE.Observaciones= NullableTypes.NullableString.Parse(this.Observaciones);
							oCCTT_ProgramacionBE.NoProgramado=1;

							//oCCTT_ProgramacionBE.TipoProgramacion = 2;

							/*Datos del trabajador*/
							CCTT_ProgramacionTrabajadoresContratistaBE oCCTT_ProgramacionTrabajadoresContratistaBE = new CCTT_ProgramacionTrabajadoresContratistaBE();
							oCCTT_ProgramacionTrabajadoresContratistaBE.NroDNI = this.NroDNI;
							oCCTT_ProgramacionTrabajadoresContratistaBE.IdNivelEspecialidad = 0;
							oCCTT_ProgramacionTrabajadoresContratistaBE.IdEstado = 1;
							Helper.GenerarEsquemaXMLTAD((new CCCTT_Programacion()).RegistrarProgramacionSinProg(oCCTT_ProgramacionBE,oCCTT_ProgramacionTrabajadoresContratistaBE));
						}
						else if(this.IdProceso== KEYQRESTRICIONESSIMA)
						{
							ExamenMedicoRestricionesSIMABE oExamenMedicoRestricionesSIMABE= new ExamenMedicoRestricionesSIMABE();
							oExamenMedicoRestricionesSIMABE.Periodo= this.Periodo;
							oExamenMedicoRestricionesSIMABE.IdFicha = this.IdFicha;
							oExamenMedicoRestricionesSIMABE.IdRestriccion = this.IdRestriccion;
							oExamenMedicoRestricionesSIMABE.IdEstado = this.IdEstado;
							Helper.GenerarEsquemaXMLTAD((new CCCTT_FichaMedicaRestriccionesSIMA()).InsertarUpdate(oExamenMedicoRestricionesSIMABE));

						}
						else if(this.IdProceso== KEYQANTECEDENTES)
						{
							Helper.GenerarEsquemaXMLNTAD((new CCCTT_Trabajador()).ConsultaAntecedente(this.NroDNI));
						}
						else if(this.IdProceso== KEYQBUSCAPERSONAL)
						{
							Helper.AutoBusquedaResultado((new SIMA.Controladoras.Personal.CPersonal()).BuscarPersonalSIMA(Utilitario.Helper.CampoBusqueda(),Utilitario.Helper.CriterioBusqueda())) ;
							
						}
							//else if(this.IdProceso== KEYQLISTARPROGRAMACIONESTRABAJADOR)
						else if(this.IdProceso== KEYQLISTARPROGRAMACIONESTRABAJADOR)
						{
							DataTable dtc =  (new CCCTT_ProgramacionTrabajadoresContratista()).ListarProgramacionesTrabajador(this.NroDNI);
							DataTable dtCount = new DataTable();
							dtCount.Columns.Add("Count",System.Type.GetType("System.Int32"));
							DataRow dr = dtCount.NewRow();
							dr["Count"] = dtc.Rows.Count;
							dtCount.Rows.Add(dr);
							Helper.GenerarEsquemaXMLNTAD(dtCount);

						}
						else if(this.IdProceso==KEYQINSLSTPERSONACAPACITADAS)
						{
							/*Por implementar*/
							CapacitacionProgLstPerBE oCapacitacionProgLstPerBE = new CapacitacionProgLstPerBE();
							oCapacitacionProgLstPerBE.IdLstProgAsisCap = this.IdProgAsis;
							oCapacitacionProgLstPerBE.IdProgCap = this.IdProgCap;
							oCapacitacionProgLstPerBE.PeriodoProgCap = this.PeriodoProgCap;
							oCapacitacionProgLstPerBE.IdPersonal = this.IdPersona;
							oCapacitacionProgLstPerBE.pIdEstado = this.IdEstado;
							oCapacitacionProgLstPerBE.Nota = this.Nota;

							
							Helper.GenerarEsquemaXMLTAD((new CCCTT_Capacitacion_Prog_Lst_Per()).InsertarF(oCapacitacionProgLstPerBE));
							
						}
						else if(this.IdProceso== KEYQINSACTPERSONALCAPACITACION)
						{
							PersonaCapacitacionBE oPersonaCapacitacionBE = new PersonaCapacitacionBE();
							oPersonaCapacitacionBE.Periodo		= this.Periodo;
							oPersonaCapacitacionBE.IdSeleccion	= this.IdSeleccion;
							oPersonaCapacitacionBE.IdPersonal	= this.IdPersona;
							oPersonaCapacitacionBE.IdEstado		= this.IdEstado;
							oPersonaCapacitacionBE.NroPersonal	= this.NroPersonal;
							oPersonaCapacitacionBE.NroDNI		= this.NroDNI;
							oPersonaCapacitacionBE.ApellidosyNombres=this.ApellidosNombres;
							oPersonaCapacitacionBE.NombreArea	= this.NombreArea;

							DataTable dtLst =(DataTable) Session["dtLstPer"];
							DataRow []drDel = dtLst.Select("Periodo=" + Periodo.ToString() +" and IdSeleccion = " + this.IdSeleccion.ToString() + " and IdPersonal = " + this.IdPersona.ToString());

							Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;
							switch (oModoPagina)
							{
								case Enumerados.ModoPagina.E:
									if(drDel!=null)
									{
										drDel[0]["IdEstado"]=this.IdEstado;
										drDel[0].Table.AcceptChanges();
										Session["dtLstPer"]=drDel[0].Table;
									}	
									Helper.GenerarEsquemaXMLTAD("1");
									break;
								default:
									if(drDel.Length==0)
									{
										DataRow dr = dtLst.NewRow();
										dr["IdPersonal"]=oPersonaCapacitacionBE.IdPersonal;
										dr["IdSeleccion"]=oPersonaCapacitacionBE.IdSeleccion;
										dr["Periodo"]=oPersonaCapacitacionBE.Periodo;
										dr["NroPersonal"]=oPersonaCapacitacionBE.NroPersonal;
										dr["NroDNI"]=oPersonaCapacitacionBE.NroDNI;
										dr["ApellidosyNombres"]=oPersonaCapacitacionBE.ApellidosyNombres;
										dr["NombreArea"]=oPersonaCapacitacionBE.NombreArea;
										dr["IdEstado"]=1;
										dr["Modo"]="N";
									
										dtLst.Rows.Add(dr);
										dtLst.AcceptChanges();
										Session["dtLstPer"]=dtLst;
										Helper.GenerarEsquemaXMLTAD("1");
									}
									else
									{
										LogTransaccional.LanzarSIMAExcepcionDominio(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.AccesoDatos.ToString(),Utilitario.Constantes.PREFIJOCODIGOERRORTAD+ Helper.CortarTextoDerecha(5,Utilitario.Constantes.CEROS+"5000"),"Código de Error:5000"+ Utilitario.Constantes.SEPARADOR +"Registro ya existe:" + this.ApellidosNombres + Utilitario.Constantes.SEPARADOR + "Personal capacitacion:" + Utilitario.Constantes.SEPARADOR + "CONTROL DE REGISTRO DUPLICADO");
									}
									break;
							}
						}
						else if(this.IdProceso== KEYQINSMATASTOCK)
						{
							StockMaterialBE oStockMaterialBE = new StockMaterialBE();
							oStockMaterialBE.CodItem = this.CodigoItem;
							oStockMaterialBE.CodCeo = this.CodigoCentro;
							oStockMaterialBE.CodAlm = this.CodigoAlmacen;
							oStockMaterialBE.NroVsm = this.NroValedeSalida;
							oStockMaterialBE.CodMat = this.CodigoMaterial;
							oStockMaterialBE.Cantidad = this.CantidadMaterial;
							oStockMaterialBE.CodTblRel = this.IdTblTalla;
							oStockMaterialBE.IdTalla = this.IdTalla;


							Helper.GenerarEsquemaXMLTAD((new CCCTT_StockMaterialPorArea()).Insertar(oStockMaterialBE));
						}
						else if(this.IdProceso== KEYQELIMATASTOCK)
						{
							Helper.GenerarEsquemaXMLTAD((new CCCTT_StockMaterialPorArea()).Eliminar(this.CodigoItem));
						}
						else if(this.IdProceso== KEYQBUSCARPERSONALO7)
							//else if(this.IdProceso== 800)
						{
							//Helper.GenerarEsquemaXMLNTAD((new CO7Personal()).BuscarPersonal(Helper.CriterioBusqueda(),Helper.CampoBusqueda()));
							Helper.AutoBusquedaResultado((new CO7Personal()).BuscarPersonal(Helper.CriterioBusqueda(),Helper.CampoBusqueda()));
						}
						else if(this.IdProceso== KEYQCLASMATPERSONA)
						{
							Helper.GenerarEsquemaXMLNTAD((new CCCTT_KardexPersona()).ListarClase(this.CodigoPersona));
						}
						else if(this.IdProceso==KEYQINSACTKARDEXPERSONA)
						{
							StockMaterialEntregaBE oStockMaterialEntregaBE = new StockMaterialEntregaBE();
							oStockMaterialEntregaBE.CodEntrega = this.CodigoEntrega;
							oStockMaterialEntregaBE.CodTrabajador=this.CodigoPersona;
							oStockMaterialEntregaBE.CodItem=this.CodigoItem;
							oStockMaterialEntregaBE.Cantidad=this.CantidadMaterial;
							oStockMaterialEntregaBE.FechaEntrega = this.FechaEntrega;
							oStockMaterialEntregaBE.IdMatEstado = 3;
							Helper.GenerarEsquemaXMLTAD((new CCCTT_KardexPersona()).Insertar(oStockMaterialEntregaBE));
						}
						else if(this.IdProceso==KEYQINSACTCONFORMIDAD)
						{
							StockMaterialEntregaBE oStockMaterialEntregaBE = new StockMaterialEntregaBE();
							oStockMaterialEntregaBE.CodTrabajador=this.CodigoPersona;
							oStockMaterialEntregaBE.CodigoHuella=this.CodigoHuella;
							oStockMaterialEntregaBE.IdMatEstado = 1;
							Helper.GenerarEsquemaXMLTAD((new CCCTT_KardexPersona()).ActualizaEstaMat(oStockMaterialEntregaBE));
						}
						else if(this.IdProceso==KEYQINSACTLSTMATINSTOCK)
						{
							Helper.GenerarEsquemaXMLTAD((new CCCTT_StockMaterialPorArea()).InsertarAll(this.CodigoCentro,this.NroValedeSalida,this.CodigoAlmacen));

						}
						else if(this.IdProceso==KEYQLISTARHUELLASTRABAJADOR)
						{
							DataTable dth = (new CCCTT_Huella()).Listar(this.CodigoPersona);
							Helper.GenerarEsquemaXMLNTAD(dth);
						}
						else if(this.IdProceso==KEYQOBTENERHUELLARELOG)
						{
							Helper.GenerarEsquemaXMLNTAD(ObtenerHuallaReloj(this.CodigoPersona,this.IpMachine,this.PuertoMachine));
						}
						else if(this.IdProceso==KEYQINSACTHUELLA)
						{
							PersonaHuellaBE oPersonaHuellaBE = new PersonaHuellaBE();
							oPersonaHuellaBE.CodigoPersona = this.CodigoPersona;
							oPersonaHuellaBE.IdHuella=this.IdHuella;
							oPersonaHuellaBE.Huella1=this.strHuellafmt1;
							oPersonaHuellaBE.Huella2=this.strHuellafmt2;
							oPersonaHuellaBE.IdVersion = Convert.ToInt32(this.IdVersion);
							oPersonaHuellaBE.pIdEstado=1;
							oPersonaHuellaBE.IdOrigen=this.IdOrigen;

							Helper.GenerarEsquemaXMLTAD((new CCCTT_Huella()).ActInsertar(oPersonaHuellaBE));
						}
						else if(this.IdProceso==KEYQNROITEMCONFIRMA)//Nro de Items pos confirmar recpecion
						{
							DataTable dt = (new CCCTT_KardexPersona()).ListarTodosGrilla(this.CodigoPersona,this.ClaseMaterial);
							if((dt!=null)&&(dt.Rows.Count>0))
							{
								DataView dv = dt.DefaultView;
								dv.RowFilter="ID_MAT_EST=3 and COD_AUS='" + this.CodArea + "'";
								DataTable dtv = Helper.DataViewTODataTable(dv);
								Helper.GenerarEsquemaXMLTAD(dtv.Rows.Count.ToString());
							}
							else
							{
								Helper.GenerarEsquemaXMLTAD("0");
							}
							
						}
						else if(this.IdProceso==KEYQITEMDETALLEXCODIGO)//Nro de Items pos confirmar recpecion
						{
							DataTable dtM = (new CCCTT_StockMaterialPorArea()).Listar(this.CodArea);
							if((dtM!=null)&&(dtM.Rows.Count>0))
							{
								DataView dv = dtM.DefaultView;
								dv.RowFilter="COD_MAT = '" + this.CodigoMaterial + "'" ;
								DataTable dtmFind = Utilitario.Helper.DataViewTODataTable(dv);
								Helper.GenerarEsquemaXMLNTAD(dtmFind);
							}

						}
						else if(this.IdProceso==800)//Nro de Items pos confirmar recpecion
						{
							
						}
						
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYADMPATOGENO)
						{
							CCTT_TrabajadorBE oCCTT_TrabajadorBE = new CCTT_TrabajadorBE ();//(CCTT_TrabajadorBE)oBaseBE;
							oCCTT_TrabajadorBE.NroDNI = this.NroDNI;
							oCCTT_TrabajadorBE.ExamenCovid = this.Examencovid;
							oCCTT_TrabajadorBE.DiagnosticoCovid = this.DiagnosticoCov;
							oCCTT_TrabajadorBE.FechaVigCovid = this.FechaVigCov;

							//RestriccionesNoConsiderdasBE oRestriccionesNoConsiderdasBE=new RestriccionesNoConsiderdasBE();
							Helper.GenerarEsquemaXMLTAD((new CAdministrarTrabajadorPatogenos()).Modificar(oCCTT_TrabajadorBE));

						}
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYLISTATIPOENTIDAD)
						{
							Helper.GenerarEsquemaXMLNTAD((new CCCTT_Programacion()).ListarTipoEntidad());
						}
						
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQAUTORIZAFERIADO)
						{
							AutorizaIngFeriadoBE oAutorizaIngFeriadoBE= new AutorizaIngFeriadoBE();
							oAutorizaIngFeriadoBE.NroDNI = this.NroDNI;
							oAutorizaIngFeriadoBE.IdPersonalAutoriza = this.IdPersona;
							oAutorizaIngFeriadoBE.FechaAutorizada = this.FechaAutoriza;
							oAutorizaIngFeriadoBE.pIdEstado=this.IdEstado;

							Helper.GenerarEsquemaXMLTAD((new CCCTT_AutorizaFeriado()).ModificarInserta(oAutorizaIngFeriadoBE));

						}
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQVERIFICAAUTORIZAFERIADO)
						{
							Helper.GenerarEsquemaXMLNTAD((new CCCTT_AutorizaFeriado()).VerificarDiaAutorizado(this.NroDNI));
						}
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQLISTARAUTORIZAFERIADO)
						{
							Helper.GenerarEsquemaXMLNTAD((new CCCTT_AutorizaFeriado()).ListarFeriadosPorTrabajador(this.NroDNI,this.FechaInicio,this.FechaVence));
						}

						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQDATOSRELACIONADOSTRABAJADOR)
						{
							Helper.GenerarEsquemaXMLNTAD((new CCCTT_Trabajadores()).ConsultarDatosRelacionadodelTrabajador(this.NroDNI));
						}
						if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQAUTOSERVICIOSPAPELETAS)
						{
							Helper.GenerarEsquemaXMLNTAD((new SIMA.Controladoras.Personal.CPersonal()).PapeletadePermiso(this.NroPortaRetrato));
						}
					}
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					Helper.GenerarEsquemaXMLError(this.Request.Path,this.IdProceso,this.Request.QueryString.ToString(), oSIMAExcepcionDominio.Error);
				}
			}
		}

		string [,] IPandNumberMachine = new string[9,2]{	{"10.12.20.12","110"}
														   ,{"10.12.89.10","103"}
														   ,{"10.12.36.10","101"}
														   ,{"10.12.44.10","102"}
														   ,{"10.12.44.11","106"}
														   ,{"10.10.106.10","107"}
														   ,{"10.10.105.10","108"}
														   ,{"10.12.88.10","109"}
														   ,{"10.12.20.11","11"}
													   };

		DataTable ObtenerHuallaReloj(string CodigoPersonal,string ipMachine,int Puerto)
		{
			DataTable dtHuella = new DataTable();
			dtHuella.Columns.Add("COD_HUELLA");
			dtHuella.Columns.Add("COD_TRABAJADOR");
			dtHuella.Columns.Add("ID_HUELLA",System.Type.GetType("System.Int32"));
			dtHuella.Columns.Add("HUELLA_M1");
			dtHuella.Columns.Add("HUELLA_M2");
			dtHuella.Columns.Add("MODO");
			int machineNumber=1;

			for(int f=0;f<=8;f++){//Busca el MachinNumber de la ip
				if(ipMachine==IPandNumberMachine[f,0]){
					machineNumber=Convert.ToInt32(IPandNumberMachine[f,1]);
				}
			}

			string sdwEnrollNumber = string.Empty, sName = string.Empty, sPassword = string.Empty, sTmpData = string.Empty;
			int iPrivilege = 0, iTmpLength = 0, iFlag = 0, idwFingerIndex;
			bool bEnabled = false;
			bool Conectado=false;

			CZKEM objZkeeper = new CZKEMClass();
			try
			{
				Conectado = objZkeeper.Connect_Net(ipMachine,Puerto);
				if(Conectado)
				{
					if(objZkeeper.RegEvent(1,32767)){}
					objZkeeper.ReadAllUserID(machineNumber);
					objZkeeper.ReadAllTemplate(machineNumber);
					while (objZkeeper.SSR_GetAllUserInfo(machineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))
					{
						for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)//Recorre por cada unos de los dedos de las manos
						{
							if (objZkeeper.GetUserTmpExStr(machineNumber, sdwEnrollNumber, idwFingerIndex, out iFlag, out sTmpData, out iTmpLength))
							{
								if(sdwEnrollNumber==CodigoPersonal)
								{
									DataRow  dr =  dtHuella.NewRow();
									dr["COD_HUELLA"] ="";dr["COD_TRABAJADOR"] = sdwEnrollNumber;
									dr["ID_HUELLA"]=idwFingerIndex;dr["HUELLA_M1"]=sTmpData;
									dr["HUELLA_M2"]="";dr["MODO"]="N";
									dtHuella.Rows.Add(dr);
									dtHuella.AcceptChanges();
								}
							}
						}
					}
					objZkeeper.Disconnect();
				}
			}
			catch(Exception oe)
			{
				string mesg= oe.Message;
				objZkeeper.Disconnect();
				return dtHuella;
			}
			
			return dtHuella;

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
	}
}
