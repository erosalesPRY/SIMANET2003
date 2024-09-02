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
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.EntidadesNegocio.General;

using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Runtime.InteropServices;

using System.IO;
using System.Reflection;


namespace SIMA.SimaNetWeb.General
{
	/// <summary>
	/// Summary description for Procesar.
	/// </summary>
	public class Procesar : System.Web.UI.Page
	{
		#region Constante
		const string KEYQIDGRUPOCC="idGrpCC";
		const string KEYQIDUSUARIO="IdUser";
		const string KEYQREG="strrEG";
		//const string KEYQIDTABLAINFORMACION="IdTblInfo";

		const string PROCESO ="idProceso";
		const int KEYQLISTARGRUPOCENTROCOSTOPORCENTROPORTIPOPPTO=37;
		const string IDCENTROOPERATIVO="idcop";
		const string KEYQDIGCTA="DigCta";
		const int  KEYQLISTARACCESOUSUARIOCENTROCOSTODISPONIBLE=38;
		const int  KEYQLISTARACCESOUSUARIOCENTROCOSTOSSELECCIONADO=39;

		//Formatos
		const int  KEYQLISTARFORMATOS=87;	
		const int  KEYQINSERTAACTUALIZAFORMATOESTRUCTURA=88;	
		const int  KEYQINSERTAACTUALIZAFORMATOFORMULA=89;	
		const int  KEYQLISTARGRUPODECENTRODECOSTOXCENTROOPERATIVO=90;	
		const int KEYQLISTARFORMATOMOVIMIENTODESCRIPCIONITEM=92;
		const int KEYQINSERTAFORMATOMOVIMIENTODESCRIPCIONITEM=93;
		const int KEYQELIMINAFORMATO=95;
		const int KEYQLISTARFORMATODETALLECTAPORRUBRO = 239;
		const int KEYQIMPRIMIRFORMATODETALLECTAPORRUBRO = 240;
		const int KEYQGenerarProcesarFormatoFormulaCtble= 241;
		const int KEYQGenerarImportarSaldos= 242;
		const int KEYQLSTPRIVILEGIOTIPOINFO=281;
		const int KEYQINSACTPRIVILEGIOTIPOINFO=282;
		const int KEYQLSTDETALLEFORMULA=283;
		const int KEYQBUSCARNOTACONTAB=284;
		const int KEYQISNACTFORMATOREPORTENOTA=285;
		const int KEYQLSTFORMATOREPORTENOTA=286;
		const int KEYQLSTFORMATOREPORTEFORMULA=289;
		const int KEYQACTUALIZANOTAFORMULACONTAB=290;
		const int KEYQLISTANOTACONTABLEFORMULA=291;

		const int KEYQLISTANOTACONTABLE=293;

		const int KEYQFORMATOFORMCTABLE=294;

		const int KEYQLISTARFORMATOREPORTECOLUMADETALLEMOVIMIENTO=298;

		const int KEYQLISTARFORMATOGRUPO=300;

		const int KEYQFORMINTERCONEX=301;

		const int KEYQLSTFORMINTERCONEX=302;
			
		const int KEYQPROCESARFORMATOITECONEXION=305;

		const int KEYQPROCESARPRESENTACIONGRP=308;

		const int KEYQGenerarProcesarFormatoContraloria=314;

		const int KEYQINSACTSESSION=351;


		const string KEYQIDGRUPOFORMATO="IdGrupoFormato";
		const string KEYQIDFORMATO="IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO="IdRubro";
		const string KEYQIDCOLUMNA="IdCol";
		const string KEYQPERIODO = "Periodo";
		const string KEYQIDMES = "IdMes";
		const string KEYQIDCENTROCOSTO = "idCC";
		const string KEYQIDTIPOINFO = "idTipoInfo";
		const string KEYQVERDETALLERPT = "VDT";
		const string KEYQEDIT="Edit";
		const string KEYQFORMCONTAB="FContab";
		const string KEYQIDFORMATOITERCONEX="IdFormatoInt";
		const string KEYQIDREPORTEITERCONEX="IdReporteInt";
		const string KEYQIDRUBROINTERCONEX="IdRubroInt";
		const string KEYQESTADO="IdEstado";
	
		


		const string KEYQIDRUBRODESTINO="IdRubroDestino";
		const string KEYQNRONIVEL="NroNivel";
		const string KEYQNOMBRE="Nombre";
		const string KEYQNROORDEN="Orden";
		const string KEYQTIPOLINEA="TipoLinea";
		const string KEYQVERMONTO="VerMnt";
		const string KEYQPRIODIRDAD="IdPrioridad";
			
		const string KEYQTIPONODOPRINCIPAL="TipoNodoPrincipal";
		const string KEYQIDOPMAT="IdOPMat";
		const string KEYQTIPOIMPO="TipoImp";
			
		const string KEYQDESCRIPCION="Descripcion";
		const string KEYQIDNOTA="IdNota";
		const string KEYFORMULA="NotaForm";
		const string KEYIDNOTAFORMULA="IdNotaForm";
		const string KEYQREQCTACTABLE="ReqCtaCtable";
		const string KEYQACUMULADO="Acum";

		const string KEYQMSGALERTA="msgAlert";
		const string KEYQFORMULASQL="FormSQL";

		/*dIAPOSITIVAS*/
		const string KEYQIDPRESENTACION="idPresent";



		#endregion


		public string FormulaSQL
		{
			get{return ((Page.Request.Params[KEYQFORMULASQL]!=null)?Page.Request.Params[KEYQFORMULASQL]:"");}
		}
		public string strLstFormCtable
		{
			get{return Page.Request.Params[KEYQREG];}
		}
		
		public int IdOperadorMat
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDOPMAT]);}
		}
		public int IdCentroOperativo
		{
			get{return Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO]);}
		}
		public string IdNotaContableFormula
		{
			get{return Page.Request.Params[KEYIDNOTAFORMULA];}
		}
		public string IdNota
		{
			get{return Page.Request.Params[KEYQIDNOTA];}
		}
		public int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}
		public int IdMes
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDMES]);}
		}
		public int IdTipoInformacion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO]);}
		}

		public int IdFormatoInterConex
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATOITERCONEX]);}
		}
		public int IdReporteInterConex
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDREPORTEITERCONEX]);}
		}
		public int IdRubroInterConex
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDRUBROINTERCONEX].ToString());}
		}
		public string Formula
		{
			get{return Server.UrlEncode(Page.Request.Params[KEYFORMULA].ToString()).Replace("%3e",">").Replace("%3c","<");}
		}
		public string Descripcion
		{
			get{return Page.Request.Params[KEYQDESCRIPCION].ToString();}
		}


		public int IdFormato
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO].ToString());}
		}
		public int IdReporte
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE].ToString());}
		}
		public int IdRubro
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO].ToString());}
		}
		
		public int IdColumna
		{
			get{return 	Convert.ToInt32(Page.Request.Params[KEYQIDCOLUMNA].ToString());}
		}
		
		public int IdEstado
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQESTADO].ToString());}
		}
		
		public char TipoImporte
		{
			get{return Convert.ToChar(Page.Request.Params[KEYQTIPOIMPO].ToString());}
		}
		
		public int ReqCtaCtable
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQREQCTACTABLE].ToString());}
		}

		public int RecibeAlertaCierre
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQMSGALERTA].ToString());}
		}
		public int FormatoAcumulado
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQACUMULADO]);}
		}

		/*DIAPOSITIVA*/
		public int IdPresentacion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDPRESENTACION]);}
		}

		

		#region Query Generador
		const int  KEYQLISTACAMPODISPONIBLES=47;
		const int  KEYQLISTACAMPODISEÑO=48;
		const string KEYQIDQUERY = "IDQUERY";
		const string KEYQNOMBREOBJDB = "NOMBREOBJDB";
		const string KEYQIDTIPOCAMPO = "IDTIPOCMP";
		const int  PROCESOUPLOAD=48;

		#endregion
		#region Mantenimiento de la Tabla de Acceso Usuario
		const int  INSACTACCESOUSUARIOTABLA=40;
		const int INSNATURALEZAGASTO=100;
		const string KEYQIDACCESOUSUARIO="idUsuAcceso";
		const string KEYQNOMBRETABLA="NombreTbl";
		const string KEYQTABLAINFORMACION="idTblInfo";//Tabla que contiene los registro que serviran como origen para ser restrictivos en la tabla informacion
		const string KEYQID1="Id1";//registro de la tabla origen
		const string KEYQID2="Id2";//tabla que contendra la informacion de movimientos de la tabla origen
		const string KEYQID3="Id3";
		const string KEYQFLAGACCESO="flgAcceso";	
		const string KEYQIDTABLAACCESOINFORMACION= "idtblAccesoInfo";
		#endregion

		#region Formato
		const int  KEYQINDICADORESFINANCIEROS=98;
		const string KEYQARCHIVOINDICADORES="ArchIndicadores";
		#endregion

		#region MATERIALES
		const int  KEYQBUSCARMATERIAL=142;	
		const int  KEYQLISTARIMAGENDEMATERIAL=143;	
		const int  KEYQMANTENIMIENTOFICHATECNICA=144;	
		const int  KEYQLISTAFICHATECNICAESTRUCTURA= 153;
		
		const string KEYQCODMATERIAL = "CodMat";
		const string KEYQNROIMG = "NroImg";
		const string KEYQNOMBREIMG = "NomImg";
		const string KEYQRUTAUPLOADIMG = "RutaUpLoad";
		const string KEYQREF = "Ref";
		const string KEYQIDESTADO = "IdEst";
		#endregion

		#region TABLATABLAS
		const int  KEYQLISTARITEMTABLATABLAS=181;
		const string KEYQIDTABLA = "IDTABLA";
		#endregion

		
		public static int GetAnswer(int value1, int value2)
		{
			return value1 + value2;
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			#region Assembly
			/*
				int MiN=0;
				string PathAssemblyControler=Page.Request.PhysicalApplicationPath + @"bin\SIMA.SimaNetWeb.dll";
				Assembly assembly = Assembly.LoadFile(PathAssemblyControler);

				string strNameSpace="SIMA.SimaNetWeb.General.Procesar";
				Type type = assembly.GetType(strNameSpace);
				if (type != null)
				{
					MethodInfo methodInfo = type.GetMethod("GetAnswer");
					if (methodInfo != null)
					{
						ParameterInfo[] parameters = methodInfo.GetParameters();
						object classInstance = Activator.CreateInstance(type, null);
						if (parameters.Length == 0)
						{
							MiN =(int)methodInfo.Invoke(classInstance, null);
						}
						else
						{
							object[] parametersArray = new object[] {10,20};
							//object[] parametersArray = ListadeValores();
							MiN =(int) methodInfo.Invoke(classInstance, parametersArray);
						}
					}
				}
				
				Helper.GenerarEsquemaXMLTAD(MiN);

	*/
			#endregion
			if(!Page.IsPostBack)
			{
				if (Page.Request.Params[PROCESO]!=null)
				{
					#region GRUPO DE CENTROS DE COSTOS
					if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQLISTARGRUPOCENTROCOSTOPORCENTROPORTIPOPPTO)
					{
						DataTable dt = (new CGrupoCentroCosto()).ListarGrupoCCPorCentroOperativo(Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO]));
						//string Criterio = "CTACTBLEASOCIADA='" + Convert.ToString(Page.Request.Params[KEYQDIGCTA]) + "'";
						string Criterio = Helper.CampoBusqueda() +  " like '%" + Helper.CriterioBusqueda() + "%'";
						Helper.AutoBusquedaResultado(Helper.FiltrarDataTable(dt,Criterio));
					}
						#endregion
						#region cenbtro de costos por usuario acceso disponibles
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQLISTARACCESOUSUARIOCENTROCOSTODISPONIBLE)
					{
						Helper.GenerarEsquemaXMLNTAD((new CCentroCosto()).ListarAccesoUsuarioCentroCostoDisponible(Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOCC]),Convert.ToInt32(Page.Request.Params[KEYQIDUSUARIO]),Convert.ToInt32(Page.Request.Params[KEYQTABLAINFORMACION])));
					}
						#endregion
						#region cenbtro de costos por usuario acceso seleccionados
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQLISTARACCESOUSUARIOCENTROCOSTOSSELECCIONADO)
					{
						Helper.GenerarEsquemaXMLNTAD((new CCentroCosto()).ListarAccesoUsuarioCentroCostoSeleccionado(Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOCC]),Convert.ToInt32(Page.Request.Params[KEYQIDUSUARIO]),Convert.ToInt32(Page.Request.Params[KEYQTABLAINFORMACION])));
					}
						#endregion
						#region Inserta acceso usuario tabla 
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==INSACTACCESOUSUARIOTABLA)
					{
						AccesoUsuarioTablaBE oAccesoUsuarioTablaBE = new AccesoUsuarioTablaBE();
						//oAccesoUsuarioTablaBE.IdAccesoUsuarioTabla = Convert.ToInt32(Page.Request.Params[KEYQIDACCESOUSUARIO]);
						oAccesoUsuarioTablaBE.IdUsuario = Convert.ToInt32(Page.Request.Params[KEYQIDUSUARIO]);
						oAccesoUsuarioTablaBE.IdTablaNombreTabla = Convert.ToInt32(Page.Request.Params[KEYQNOMBRETABLA]);
						oAccesoUsuarioTablaBE.IdNombreTabla = Convert.ToInt32(Page.Request.Params[KEYQTABLAINFORMACION]);
						oAccesoUsuarioTablaBE.Id1 = Convert.ToInt32(Page.Request.Params[KEYQID1]);
						oAccesoUsuarioTablaBE.Id2 = Convert.ToInt32(Page.Request.Params[KEYQID2]);
						oAccesoUsuarioTablaBE.FlgAcceso = Convert.ToInt32(Page.Request.Params[KEYQFLAGACCESO]);
						Helper.GenerarEsquemaXMLTAD((new CAccesoUsuarioTabla()).InsertarModificar(oAccesoUsuarioTablaBE));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==INSNATURALEZAGASTO)
					{
						AccesoUsuarioTablaBE oAccesoUsuarioTablaBE = new AccesoUsuarioTablaBE();
					
						oAccesoUsuarioTablaBE.IdUsuario = Convert.ToInt32(Page.Request.Params[KEYQIDUSUARIO]);
						oAccesoUsuarioTablaBE.IdTablaNombreTabla = Convert.ToInt32(Page.Request.Params[KEYQNOMBRETABLA]);
						oAccesoUsuarioTablaBE.IdNombreTabla = Convert.ToInt32(Page.Request.Params[KEYQTABLAINFORMACION]);
						oAccesoUsuarioTablaBE.Id1 = Convert.ToInt32(Page.Request.Params[KEYQID1]);
						oAccesoUsuarioTablaBE.Id2 = Convert.ToInt32(Page.Request.Params[KEYQID2]);
						oAccesoUsuarioTablaBE.Id3 = Convert.ToInt32(Page.Request.Params[KEYQID3]);
						oAccesoUsuarioTablaBE.FlgAcceso = Convert.ToInt32(Page.Request.Params[KEYQFLAGACCESO]);
						Helper.GenerarEsquemaXMLTAD((new CAccesoUsuarioTabla()).InsertarNaturalezaGasto(oAccesoUsuarioTablaBE));
					}
						#endregion
						#region Listar campos de tablas disponibles
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQLISTACAMPODISPONIBLES)
					{
						Helper.GenerarEsquemaXMLNTAD((new CQRYDescribeObjeto()).DescribeTablaOVista(Convert.ToInt32(Page.Request.Params[KEYQIDQUERY]),Page.Request.Params[KEYQNOMBREOBJDB].ToString()));
					}
						#endregion
						#region  Listar campos de diseño
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQLISTACAMPODISEÑO)
					{
						Helper.GenerarEsquemaXMLNTAD((new CQRYDescribeObjeto()).ListarCamposDiseño(Convert.ToInt32(Page.Request.Params[KEYQIDQUERY]),Page.Request.Params[KEYQNOMBREOBJDB].ToString(),Convert.ToInt32(Page.Request.Params[KEYQIDTIPOCAMPO])));
					}
						#endregion 
						#region Listar campos de diseño
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQLISTACAMPODISEÑO)
					{
						Helper.GenerarEsquemaXMLNTAD((new CQRYDescribeObjeto()).ListarCamposDiseño(Convert.ToInt32(Page.Request.Params[KEYQIDQUERY]),Page.Request.Params[KEYQNOMBREOBJDB].ToString(),Convert.ToInt32(Page.Request.Params[KEYQIDTIPOCAMPO])));
					}
						#endregion 
						#region Formatos
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQLISTARFORMATOS)
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA]) ;
						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.C:
								Helper.GenerarEsquemaXMLNTAD((new CFormato()).ListarAccesoSegunPrivilegioUsuarioTabla(Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOFORMATO]),Convert.ToInt32(Page.Request.Params[KEYQIDTABLAACCESOINFORMACION]) ));
								break;
							default:
								Helper.GenerarEsquemaXMLNTAD((new CFormato()).ListarTodos(Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOFORMATO]) ));
								break;
						}
					}
						#endregion 
						#region formato estructura
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQINSERTAACTUALIZAFORMATOESTRUCTURA)
					{
						FormatoEstructuraBE  oFormatoEstructuraBE = new FormatoEstructuraBE();
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;
						switch(oModoPagina)
						{
							case Enumerados.ModoPagina.N:
								oFormatoEstructuraBE.Idformato= Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
								oFormatoEstructuraBE.Nronivel= Convert.ToString(Page.Request.Params[KEYQNRONIVEL]);
								oFormatoEstructuraBE.Nombre= Convert.ToString(Page.Request.Params[KEYQNOMBRE]);
								oFormatoEstructuraBE.Idtipolinea= Convert.ToInt32(Page.Request.Params[KEYQTIPOLINEA]);
								oFormatoEstructuraBE.Flgvermonto = Convert.ToInt32(Page.Request.Params[KEYQVERMONTO]);
								oFormatoEstructuraBE.Editable = Convert.ToInt32(Page.Request.Params[KEYQEDIT]);
								oFormatoEstructuraBE.FormulaContable = Convert.ToInt32(Page.Request.Params[KEYQFORMCONTAB]);
								oFormatoEstructuraBE.FormulaSQL= this.FormulaSQL;

								/*if(Page.Request.Params[KEYQPRIODIRDAD].ToString().Length>0)
								{
									oFormatoEstructuraBE.Idprioridad =  Convert.ToInt32(Page.Request.Params[KEYQPRIODIRDAD]);
								}*/
								oFormatoEstructuraBE.Idestado = Convert.ToInt32(Page.Request.Params[KEYQESTADO]);
								Helper.GenerarEsquemaXMLTAD((new SIMA.Controladoras.General.CFormatoEstructura()).Insertar(oFormatoEstructuraBE));
								break;
							case Enumerados.ModoPagina.M:
								if(Page.Request.Params[KEYQNOMBRE]==null)
								{
									oFormatoEstructuraBE.Idformato= Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
									oFormatoEstructuraBE.Idrubro= Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]);
									oFormatoEstructuraBE.Orden = Convert.ToInt32(Page.Request.Params[KEYQNROORDEN]);
									//oFormatoEstructuraBE.Idprioridad = Convert.ToInt32(Page.Request.Params[KEYQPRIODIRDAD]);
									oFormatoEstructuraBE.Editable = Convert.ToInt32(Page.Request.Params[KEYQEDIT]);
									oFormatoEstructuraBE.FormulaContable = Convert.ToInt32(Page.Request.Params[KEYQFORMCONTAB]);
									oFormatoEstructuraBE.FormulaSQL= this.FormulaSQL;

									Helper.GenerarEsquemaXMLTAD((new SIMA.Controladoras.General.CFormatoEstructura()).Modificar(oFormatoEstructuraBE,0));
								}
								else
								{
									oFormatoEstructuraBE.Idformato= Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
									oFormatoEstructuraBE.Idrubro= Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]);
									oFormatoEstructuraBE.Nombre= Convert.ToString(Page.Request.Params[KEYQNOMBRE]);
									oFormatoEstructuraBE.Idtipolinea= Convert.ToInt32(Page.Request.Params[KEYQTIPOLINEA]);
									oFormatoEstructuraBE.Flgvermonto = Convert.ToInt32(Page.Request.Params[KEYQVERMONTO]);
									oFormatoEstructuraBE.Editable = Convert.ToInt32(Page.Request.Params[KEYQEDIT]);
									oFormatoEstructuraBE.FormulaContable = Convert.ToInt32(Page.Request.Params[KEYQFORMCONTAB]);
									oFormatoEstructuraBE.FormulaSQL= this.FormulaSQL;
									/*if(Page.Request.Params[KEYQPRIODIRDAD].ToString().Length>0)
									{
										oFormatoEstructuraBE.Idprioridad =  Convert.ToInt32(Page.Request.Params[KEYQPRIODIRDAD]);
									}*/
									oFormatoEstructuraBE.Idestado = Convert.ToInt32(Page.Request.Params[KEYQESTADO]);
									Helper.GenerarEsquemaXMLTAD((new SIMA.Controladoras.General.CFormatoEstructura()).Modificar(oFormatoEstructuraBE));

								}
								break;
						}

					}
						#endregion

						#region formato Formula INSERT ACTUALUIZA
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQINSERTAACTUALIZAFORMATOFORMULA)
					{
						FormatoFormulaBE  oFormatoFormulaBE = new FormatoFormulaBE();
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;
						switch(oModoPagina)
						{
							case Enumerados.ModoPagina.N:
								oFormatoFormulaBE.Idformato= Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
								oFormatoFormulaBE.Idrubro= Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]);
								oFormatoFormulaBE.Idrubrodestino= Convert.ToInt32(Page.Request.Params[KEYQIDRUBRODESTINO]);
								oFormatoFormulaBE.Orden = Convert.ToInt32(Page.Request.Params[KEYQESTADO]);
								oFormatoFormulaBE.Idoperadormat = this.IdOperadorMat;
								oFormatoFormulaBE.Idestado = Convert.ToInt32(Page.Request.Params[KEYQESTADO]);
								if(oFormatoFormulaBE.Idrubro!=oFormatoFormulaBE.Idrubrodestino)
								{
									(new SIMA.Controladoras.General.CFormatoFormula()).Insertar(oFormatoFormulaBE);
									/*Actualiza las prioridades de calculo*/
									(new CFormato()).ActualizaPrioridad(oFormatoFormulaBE.Idformato);
									Helper.GenerarEsquemaXMLTAD("1");
								}
								else
								{
									Helper.GenerarEsquemaXMLTAD("-1");
								}
								break;
							case Enumerados.ModoPagina.M:
								oFormatoFormulaBE.Idformato= Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
								oFormatoFormulaBE.Idrubro= Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]);
								oFormatoFormulaBE.Idrubrodestino= Convert.ToInt32(Page.Request.Params[KEYQIDRUBRODESTINO]);
								oFormatoFormulaBE.Orden = Convert.ToInt32(Page.Request.Params[KEYQNROORDEN]);
								oFormatoFormulaBE.Idoperadormat = this.IdOperadorMat;
								oFormatoFormulaBE.Idestado = Convert.ToInt32(Page.Request.Params[KEYQESTADO]);
								if(oFormatoFormulaBE.Idrubro!=oFormatoFormulaBE.Idrubrodestino)
								{
									(new SIMA.Controladoras.General.CFormatoFormula()).Modificar(oFormatoFormulaBE);
									/*Actualiza las prioridades de calculo*/
									(new CFormato()).ActualizaPrioridad(oFormatoFormulaBE.Idformato);
									Helper.GenerarEsquemaXMLTAD("1");
								}
								else
								{
									Helper.GenerarEsquemaXMLTAD("-1");
								}
								break;
						}
						

					}
						#endregion
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQLISTARGRUPODECENTRODECOSTOXCENTROOPERATIVO)
					{
						Helper.GenerarEsquemaXMLNTAD((new CGrupoCentroCosto()).ListarGrupoCCPorCentroOperativo(Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO])));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQLISTARFORMATOMOVIMIENTODESCRIPCIONITEM)
					{
						Helper.AutoBusquedaResultado((new CFormatoDetalleMovimientoDescripcionItem()).ConsultarFormatoDetalleDescripcionItem(Helper.CriterioBusqueda()));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQINSERTAFORMATOMOVIMIENTODESCRIPCIONITEM)
					{
						FormatoDetalleMovimientoDescripcionItemBE oFormatoDetalleMovimientoDescripcionItemBE = new FormatoDetalleMovimientoDescripcionItemBE();
						oFormatoDetalleMovimientoDescripcionItemBE.Descripcion= Page.Request.Params[KEYQDESCRIPCION].ToString();
						Helper.GenerarEsquemaXMLTAD((new CFormatoDetalleMovimientoDescripcionItem()).Insertar(oFormatoDetalleMovimientoDescripcionItemBE));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQELIMINAFORMATO)
					{
						Helper.GenerarEsquemaXMLTAD((new CFormato()).Eliminar(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]),CNetAccessControl.GetIdUser())); 
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQINDICADORESFINANCIEROS)
					{
						System.Web.UI.HtmlControls.HtmlInputFile oIndicadores = new HtmlInputFile();
						oIndicadores.Value = Page.Request.Params[KEYQARCHIVOINDICADORES].ToString();
						Helper.SubirArchivo(oIndicadores,Helper.ObtenerRutaArchivosExcel(Utilitario.Constantes.EstadosFinancierosRutaCarpetaGuardarArchivoXLS),Utilitario.Constantes.NombreArchivoIndicadorFinanciero);
						Helper.GenerarEsquemaXMLTAD("1"); 
					}
						#region Materiales
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQBUSCARMATERIAL)
					{
						Helper.AutoBusquedaResultado((new CMaterialesFichaTecnica()).ListarMaterialesPorCriterios(Helper.CampoBusqueda(),Helper.CriterioBusqueda()));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQLISTARIMAGENDEMATERIAL)
					{
						Helper.GenerarEsquemaXMLNTAD((new CMaterialesFichaTecnica()).ListarImagenesPorMaterial(Page.Request.Params[KEYQCODMATERIAL]));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQLISTAFICHATECNICAESTRUCTURA)
					{
						Helper.GenerarEsquemaXMLNTAD((new CMaterialesFichaTecnica()).ListarDetalleFicha(Page.Request.Params[KEYQCODMATERIAL]));
					}

					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQMANTENIMIENTOFICHATECNICA)
					{
						MaterialesFichaTecnicaBE oMaterialesFichaTecnicaBE = new MaterialesFichaTecnicaBE();
						oMaterialesFichaTecnicaBE.CodigoMat = Page.Request.Params[KEYQCODMATERIAL];
						

						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]);
						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.N:
								oMaterialesFichaTecnicaBE.NomgreImg = Page.Request.Params[KEYQNOMBREIMG];
								Helper.GenerarEsquemaXMLTAD((new CMaterialesFichaTecnica()).Insertar(oMaterialesFichaTecnicaBE));
								break;
							case Enumerados.ModoPagina.M:
								oMaterialesFichaTecnicaBE.IdImg = Page.Request.Params[KEYQNROIMG];
								oMaterialesFichaTecnicaBE.Referencia = Page.Request.Params[KEYQREF];
								oMaterialesFichaTecnicaBE.IdEstado = Page.Request.Params[KEYQIDESTADO];
								Helper.GenerarEsquemaXMLTAD((new CMaterialesFichaTecnica()).Modificar(oMaterialesFichaTecnicaBE));

								break;
							case Enumerados.ModoPagina.E:
								oMaterialesFichaTecnicaBE.IdImg = Page.Request.Params[KEYQNROIMG];
								oMaterialesFichaTecnicaBE.Referencia = Page.Request.Params[KEYQREF];
								oMaterialesFichaTecnicaBE.IdEstado = Page.Request.Params[KEYQIDESTADO];
								Helper.GenerarEsquemaXMLTAD((new CMaterialesFichaTecnica()).Modificar(oMaterialesFichaTecnicaBE));
								break;
				
						}
					}
						#endregion
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQLISTARITEMTABLATABLAS)
					{
						Helper.GenerarEsquemaXMLNTAD((new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Page.Request.Params[KEYQIDTABLA])));
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO]) == KEYQLISTARFORMATODETALLECTAPORRUBRO)
					{
						Helper.GenerarEsquemaXMLNTAD(new CFormatoEstructuraMovimientoCentroCosto().ConsultarFormatoDetalleMovimientoCtaPorRubro(this.IdFormato, this.IdReporte, this.IdRubro, this.IdCentroOperativo, Convert.ToInt32(Page.Request.Params["idCC"]), this.Periodo, this.IdTipoInformacion,this.ReqCtaCtable));
						//Helper.GenerarEsquemaXMLNTAD(new CFormatoEstructuraMovimientoCentroCosto().ConsultarFormatoDetalleMovimientoCtaPorRubro(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]), Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]), Convert.ToInt32(Page.Request.Params["KEYQIDRUBRO"]), Convert.ToInt32(Page.Request.Params["idcop"]), Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO]), Convert.ToInt32(Page.Request.Params[KEYQPERIODO]), Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO])));
						return;
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO])== KEYQIMPRIMIRFORMATODETALLECTAPORRUBRO)
					{
						string NombreReporte = "F" +Helper.ObtenerNombreMes(Convert.ToInt32(Page.Request.Params[KEYQIDMES]),SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto)+ ".rpt";
						Helper.EjecutarReporte(@"C:\\SimanetReportes\\GestionFinanciera\\Formatos\\", NombreReporte , new CFormatoRubroDetalleMovimiento().ConsultarFormatoRubroDetalleMovimientoCta(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]), Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]), Convert.ToInt32(Page.Request.Params[KEYQPERIODO]), Convert.ToInt32(Page.Request.Params["idcop"]), Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO]), Convert.ToInt32(Page.Request.Params["VDT"])), false);
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO])== KEYQLSTPRIVILEGIOTIPOINFO)
					{
						Helper.GenerarEsquemaXMLNTAD(new CFormatoPrivilegio().ListarAccesoSegunPrivilegioUsuario(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]),Convert.ToInt32(Page.Request.Params[KEYQIDUSUARIO]),this.IdCentroOperativo));
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO])== KEYQINSACTPRIVILEGIOTIPOINFO)
					{
						FormatoPrivilegioBE oFormatoPrivilegioBE = new FormatoPrivilegioBE();
						oFormatoPrivilegioBE.IdTipoInformacion= Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO]);
						oFormatoPrivilegioBE.IdUsuario= Convert.ToInt32(Page.Request.Params[KEYQIDUSUARIO]);
						oFormatoPrivilegioBE.IdFormato= Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
						oFormatoPrivilegioBE.Acceso= Convert.ToInt32(Page.Request.Params[KEYQESTADO]);
						oFormatoPrivilegioBE.IdCentroOperativo= this.IdCentroOperativo;
						oFormatoPrivilegioBE.MsgAlert = this.RecibeAlertaCierre;

						(new CFormatoPrivilegio()).InsAct(oFormatoPrivilegioBE);
						Helper.GenerarEsquemaXMLTAD("1"); 
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO])== KEYQLSTDETALLEFORMULA)
					{
						Helper.GenerarEsquemaXMLNTAD((new CNotaContable()).ListarFormula(IdNotaContableFormula,this.IdCentroOperativo,Periodo,IdMes,this.TipoImporte,Formula));
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO])== KEYQBUSCARNOTACONTAB)
					{
						Helper.AutoBusquedaResultado((new CNotaContable()).Buscar(Helper.CriterioBusqueda()));
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO])== KEYQISNACTFORMATOREPORTENOTA)
					{
						FormatoReporteNotaContableBE oFormatoReporteNotaContableBE = new FormatoReporteNotaContableBE();
						oFormatoReporteNotaContableBE.IdFormato=this.IdFormato;
						oFormatoReporteNotaContableBE.IdReporte=this.IdReporte;
						oFormatoReporteNotaContableBE.IdRubro=this.IdRubro;
						oFormatoReporteNotaContableBE.IdNota=this.IdNota;
						oFormatoReporteNotaContableBE.IdOperadorMat = this.IdOperadorMat;
						oFormatoReporteNotaContableBE.pIdEstado=this.IdEstado;

						(new CFormatoReporteNotaContable()).InsAct(oFormatoReporteNotaContableBE);
						Helper.GenerarEsquemaXMLTAD("1"); 
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO])== KEYQLSTFORMATOREPORTENOTA)
					{
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera: Administrar Formatos Nota Contable", this.ToString(),"Se Listo las notas de contabilidad",Enumerados.NivelesErrorLog.I.ToString()));
						Helper.GenerarEsquemaXMLNTAD((new CFormatoReporteNotaContable()).Listar(this.IdFormato,this.IdReporte,this.IdRubro));

					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO])== KEYQLSTFORMATOREPORTEFORMULA)
					{
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera: Calculo en formula por Rubro", this.ToString(),"Se obtiene resultado caculado de una formula por rubro",Enumerados.NivelesErrorLog.I.ToString()));
						DataTable dt =(new CFormatoFormula()).DecifrarFormula(this.IdCentroOperativo,this.IdFormato,this.IdReporte,this.Periodo,this.IdMes,this.IdTipoInformacion,this.Formula,this.TipoImporte);
						string tot = dt.Rows[0]["ImporteTotal"].ToString();
						Helper.GenerarEsquemaXMLTAD(tot );

					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO])== KEYQACTUALIZANOTAFORMULACONTAB)
					{
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera: Actualiza data grid lsta de formula", this.ToString(),"Se actualizo datagrid",Enumerados.NivelesErrorLog.I.ToString()));
						

						Helper.GenerarEsquemaXMLTAD("1");

					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO])== KEYQLISTANOTACONTABLEFORMULA)
					{
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera: Actualiza data grid lsta de formula", this.ToString(),"Se actualizo datagrid",Enumerados.NivelesErrorLog.I.ToString()));
						Helper.GenerarEsquemaXMLNTAD((new CNotaContableFormula()).Listar(this.IdNota));
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO])== KEYQLISTANOTACONTABLE)
					{
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera: Elimina Nota Contable", this.ToString(),"Se actualizo NotaCOntable",Enumerados.NivelesErrorLog.I.ToString()));
						Helper.GenerarEsquemaXMLTAD((new CNotaContable()).Eliminar(this.IdNota));
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO])== KEYQLISTARFORMATOREPORTECOLUMADETALLEMOVIMIENTO)
					{
						Helper.GenerarEsquemaXMLNTAD((new CFormatoEstructuraMovimientoCentroCosto()).ConsultarFormatoReporteColumnaDetalleMovimientoCtaPorRubro(this.IdCentroOperativo,this.Periodo,this.IdMes,this.IdFormato,this.IdReporte,this.IdRubro,this.FormatoAcumulado));
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO])== KEYQFORMATOFORMCTABLE)
					{
						string []Datos;string ObjRegistro;
						string []ArrRegistro  = this.strLstFormCtable.ToString().Split('@');
						FormatoReporteFormulaBE oFormatoReporteFormulaBE;
						CFormatoReporteFormula oCFormatoReporteFormula;
						int retorno=0;
						for(int i = 1;i<= ArrRegistro.Length-1;i++)
						{
							string []Data = ArrRegistro[i].ToString().Split(';');
							ObjRegistro=ArrRegistro[i].ToString();
							Datos = ObjRegistro.Split(';');
							oFormatoReporteFormulaBE = new FormatoReporteFormulaBE();
							oFormatoReporteFormulaBE.Idformato = this.IdFormato;
							oFormatoReporteFormulaBE.Idreporte  = this.IdReporte;
							oFormatoReporteFormulaBE.Idrubro= this.IdRubro;

							if(this.IdColumna==0)
							{
								switch (Data[1].ToString())
								{
									case "M":
										LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera: Modifico formula contable", this.ToString(),"Se actualizo Formula Contable",Enumerados.NivelesErrorLog.I.ToString()));
										//this.Modificar(ArrRegistro[i].ToString());
										/*ObjRegistro=ArrRegistro[i].ToString();
										Datos = ObjRegistro.Split(';');*/
										//oFormatoReporteFormulaBE = new FormatoReporteFormulaBE();
										oFormatoReporteFormulaBE.IdFormula = Convert.ToInt32(Datos[0]);
										/*oFormatoReporteFormulaBE.Idformato = this.IdFormato;
										oFormatoReporteFormulaBE.Idreporte  = this.IdReporte;
										oFormatoReporteFormulaBE.Idrubro= this.IdRubro;*/
										oFormatoReporteFormulaBE.Cuentacontable = Datos[3].ToString();
										oFormatoReporteFormulaBE.Idoperadormat = Convert.ToInt32(Datos[2].ToString());
										oFormatoReporteFormulaBE.Idoperadorlog = Convert.ToInt32(Datos[4].ToString());
										oFormatoReporteFormulaBE.Idusuarioactualizacion = CNetAccessControl.GetIdUser();
										oFormatoReporteFormulaBE.Idestado = Convert.ToInt32(Datos[5].ToString());
										
										retorno = (new CFormatoReporteFormula()).Modificar(oFormatoReporteFormulaBE);
										break;
									case "N":
										LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera: Modifico ingreso contable", this.ToString(),"Se actualizo Formula Contable",Enumerados.NivelesErrorLog.I.ToString()));
										//this.Agregar(ArrRegistro[i].ToString());
										/*ObjRegistro=ArrRegistro[i].ToString();
										Datos = ObjRegistro.Split(';');*/
										//oFormatoReporteFormulaBE = new FormatoReporteFormulaBE();
										/*oFormatoReporteFormulaBE.Idformato = this.IdFormato;
										oFormatoReporteFormulaBE.Idreporte  = this.IdReporte;
										oFormatoReporteFormulaBE.Idrubro= this.IdRubro;*/
										oFormatoReporteFormulaBE.Cuentacontable = Datos[3].ToString().Trim();
										oFormatoReporteFormulaBE.Orden = Utilitario.Constantes.ValorConstanteCero;
										oFormatoReporteFormulaBE.Idtablaoperadormat = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraOperadoresMatematicos);
										oFormatoReporteFormulaBE.Idoperadormat = Convert.ToInt32(Datos[2].ToString());
										oFormatoReporteFormulaBE.Idtablaoperadorlog = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraOperadoresLogicos);
										oFormatoReporteFormulaBE.Idoperadorlog = Convert.ToInt32(Datos[4].ToString());
										oFormatoReporteFormulaBE.Idusuarioregistro = CNetAccessControl.GetIdUser();
										oFormatoReporteFormulaBE.Idtablaestado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoFormatoReporteFormula);
										oFormatoReporteFormulaBE.Idestado = Convert.ToInt32(Datos[5].ToString());
										
										retorno = (new CFormatoReporteFormula()).Insertar(oFormatoReporteFormulaBE);

										break;
									default:
										break;
								}
							}
							else
							{
								LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera: Registro cuentacontable", this.ToString(),"Se registro Columna Formula Contable",Enumerados.NivelesErrorLog.I.ToString()));
								//oFormatoReporteFormulaBE.IdFormula = Convert.ToInt32(Datos[0]);
								oFormatoReporteFormulaBE.Cuentacontable = Datos[3].ToString();
								oFormatoReporteFormulaBE.Idoperadormat = Convert.ToInt32(Datos[2].ToString());
								oFormatoReporteFormulaBE.Idoperadorlog = Convert.ToInt32(Datos[4].ToString());
								oFormatoReporteFormulaBE.Idusuarioregistro= CNetAccessControl.GetIdUser();
								oFormatoReporteFormulaBE.Idestado = Convert.ToInt32(Datos[5].ToString());
								oFormatoReporteFormulaBE.IdColumna = this.IdColumna;
								retorno = (new CFormatoReporteFormula()).InsAct(oFormatoReporteFormulaBE);
							}
							Helper.GenerarEsquemaXMLTAD(retorno.ToString());
						}					
						//Helper.GenerarEsquemaXMLTAD(retorno);
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO]) == KEYQLISTARFORMATOGRUPO)
					{
						Helper.GenerarEsquemaXMLNTAD((new  CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.GrupodeFormatos)));
					}
					
					if (Convert.ToInt32(Page.Request.Params[PROCESO]) == KEYQFORMINTERCONEX)
					{
						FormatoReporteInterconexionBE oFormatoReporteInterconexionBE = new FormatoReporteInterconexionBE();
						oFormatoReporteInterconexionBE.IdFormato = this.IdFormato;
						oFormatoReporteInterconexionBE.IdReporte = this.IdReporte;
						oFormatoReporteInterconexionBE.IdRubro = this.IdRubro;
						oFormatoReporteInterconexionBE.IdFormatoInterConex = this.IdFormatoInterConex;
						oFormatoReporteInterconexionBE.IdReporteInterConex = this.IdReporteInterConex;
						oFormatoReporteInterconexionBE.Formula = this.Formula;
						oFormatoReporteInterconexionBE.IdEstado = this.IdEstado;
						Helper.GenerarEsquemaXMLTAD((new CFormatoReporteInterconexion()).InsAct(oFormatoReporteInterconexionBE));
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO]) == KEYQLSTFORMINTERCONEX)
					{
						DataTable dt = (new CFormato()).ListarTodos(Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOFORMATO]));
						if(dt.Rows.Count>0)
						{
							DataView dv = dt.DefaultView;
							dv.RowFilter="IdFormato <>" + this.IdFormato.ToString();
							Helper.GenerarEsquemaXMLNTAD(Helper.DataViewTODataTable(dv));
						}
						else 
						{
							Helper.GenerarEsquemaXMLNTAD(null);
						}
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO]) == KEYQPROCESARFORMATOITECONEXION)
					{
						if(this.ReqCtaCtable==1)
						{
							(new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento()).ProcesarFormatoEstadosFinancierosRubros(this.IdFormato, this.IdReporte, this.IdCentroOperativo, this.Periodo, this.IdMes,this.FormatoAcumulado);
						}
						else if(this.ReqCtaCtable==2)
						{
							(new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento()).ProcesarFormatoxNotaContable(this.IdFormato, this.IdReporte, this.IdCentroOperativo, this.Periodo, this.IdMes,this.FormatoAcumulado);
						}
						else if(this.ReqCtaCtable==3)
						{
							(new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento()).ProcesarFormatoInterconexion(this.IdFormato, this.IdReporte, this.IdCentroOperativo, this.Periodo, this.IdMes,this.FormatoAcumulado);
						}
						Helper.GenerarEsquemaXMLTAD("1");
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO]) == KEYQPROCESARPRESENTACIONGRP)
					{
						Helper.GenerarEsquemaXMLNTAD((new CDispositivaGrupo()).Listar(this.IdPresentacion));
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO]) == KEYQGenerarProcesarFormatoContraloria)
					{
						DataTable dt1 =  (new CFormatoReporteColumnaMovimiento()).Listar(this.IdFormato,this.IdReporte,this.IdCentroOperativo,this.Periodo,this.IdMes);

						string NombreReporte = "Anexo"+this.IdFormato.ToString()+".rpt";
						Helper.EjecutarReporte(@"C:\\SimanetReportes\\GestionFinanciera\\Formatos\\AnexoContraloria\\", NombreReporte , dt1 , false);
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO]) == KEYQINSACTSESSION)
					{
						(new SIMA.Controladoras.Personal.CCCTT_Monitor()).InsertarActualiza(Session.SessionID,2,System.Net.Dns.GetHostName());
						Helper.GenerarEsquemaXMLTAD("1");
						return;
				     }
				


					/*if (Convert.ToInt32(Page.Request.Params[PROCESO]) == KEYQGenerarProcesarFormatoFormulaCtble)
					{
						Helper.GenerarEsquemaXMLTAD((new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento()).ProcesarFormatoEstadosFinancierosRubros(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]), Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]), Convert.ToInt32(Page.Request.Params["idcop"]), Convert.ToInt32(Page.Request.Params[KEYQPERIODO]), Convert.ToInt32(Page.Request.Params[KEYQIDMES]), 0));
						return;
					}
					if (Convert.ToInt32(Page.Request.Params[PROCESO]) == KEYQGenerarImportarSaldos)
					{
						Helper.GenerarEsquemaXMLTAD((new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento()).ImportarUnisysSaldosContables(Convert.ToInt32(Page.Request.Params["idcop"]), Convert.ToInt32(Page.Request.Params[KEYQPERIODO]), Convert.ToInt32(Page.Request.Params[KEYQIDMES])));
						return;
					}*/


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
	}
}
