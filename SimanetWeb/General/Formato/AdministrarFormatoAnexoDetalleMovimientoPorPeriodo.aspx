<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="AdministrarFormatoAnexoDetalleMovimientoPorPeriodo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Formato.AdministrarFormatoAnexoDetalleMovimientoPorPeriodo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrar Formato Anexo</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<SCRIPT language="javascript" src="../../js/JQuery/js/jquery.min.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>
		<style>.ContextImg { Z-INDEX: 3; POSITION: relative; WIDTH: 45px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 45px }
	.imgCirc { Z-INDEX: 1; POSITION: absolute; BACKGROUND-REPEAT: no-repeat; TOP: -2px; left-30: }
		</style>
		<SCRIPT>
			var jSIMA = jQuery.noConflict();
			var KEYQPARAMETROS={IDFORMATO:0,IDREPORTE:0,IDCENTROOPERATIVO:0,IDCENTROCOSTO:0,PERIODO:0,IDTIPOINFORMACION:0};
			var TIPONODOPRINCIPAL=0;
			var KEYQTIPONODOPRINCIPAL="TipoNodoPrincipal";
			var NODOSELECCIONADO="NodoSeleccionado";
			var KEYQIDFORMATO="IdFormato";
			var KEYQIDREPORTE = "IdReporte";
			var KEYQIDRUBRO="IdRubro";
			var KEYQRUBRONOMBRE= "RubroNombre";
			var KEYQNOMBREFORMATO="NFormato";
			var KEYQPERIODO = "Periodo";
			var KEYQIDMES = "IdMes";
			var KEYQIDPROCESO = "idProceso";
			var IDCENTROOPERATIVO="idcop";
			var KEYQIDCENTROCOSTO ="idCC";
			var KEYQIDTIPOINFO ="idTipoInfo";
			var KEYQVERDETALLERPT ="VDT";
			var KEYQREQCC ="ReqCC";
			var KEYQNRONIVEL="NroNivel";
			var URLPAGINA ="";
			var oPagina;
			var NroRowIni = 2;
			var EstadodeValorActual = false;
			var arrRowFormula;
			var arrLstPrioridad;
			var DataGrid;
			var idxrowArriba;  
			var idxrowAbajo;  
			var idxcellDerecha;
			var arrMes;
			var idxCell=0;
			var KEYQREQCTACTABLE="ReqCtaCtable";
			var IdRubroSelect=0;
			var FormEntreRubro=0;

			var URLPAGINANOTACONTABLE =  SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/AdministrarRelacionFormatoRubroNotaContab.aspx?";
			
			var URLPAGINAFORMUALCONTABLE =  SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionFinanciera/EstadosFinancieros/AdministrarFormulaFinanciera.aspx?";
			
			var Ventana;

			/*Metodos usados de lado del servido*/
			function ObtenerRowId(e){
				TIPONODOPRINCIPAL=0;
				return e.rowIndex;
			}
			function OpcionSeleccionada(idOpcion){
				document.getElementById("hOpSelected").value=idOpcion;
			}
			function  EscribirDescripcionEnFila(idMes,objCell){
				if(parseInt(KEYQPARAMETROS.IDCENTROCOSTO,10)==1){return false;}
				
				var rowIndex = $O("hidFilaSeleccionada").value;
				var oDataTable = new System.Data.DataTable("tblMovDatosObservacion");
				oDataTable = (new Controladora.General.CFormatoDetalleMovimiento()).ConsultarObservacion(KEYQPARAMETROS.IDFORMATO
																										,KEYQPARAMETROS.IDREPORTE
																										,oDataGrid.rows[rowIndex].IDRUBRO
																										,KEYQPARAMETROS.IDCENTROOPERATIVO
																										,KEYQPARAMETROS.PERIODO
																										,idMes
																										,KEYQPARAMETROS.IDTIPOINFORMACION
																										);
				var dr =oDataTable.Rows.Items[0];
				var strData ="";
				if(dr.Item("EOF")==false){
					strData = ((dr.Item("observacion").toString().length>0)?dr.Item("observacion").toString().Replace("[men]","<").Replace("[may]",">"):"");
				}
				
				var Datos=new Array();
				//Aqui se debera de obtener los datos de observaciones de la DB
				var Datos=window.showModalDialog(SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/Editor/Editor.aspx",strData,"dialogWidth:630px;dialogHeight:400px"); 
				if(Datos!=null){ 
					var oFormatoDetalleMovimientoBE = new EntidadesNegocio.General.FormatoDetalleMovimientoBE();
					oFormatoDetalleMovimientoBE.Idformato = KEYQPARAMETROS.IDFORMATO;
					oFormatoDetalleMovimientoBE.Idreporte = KEYQPARAMETROS.IDREPORTE;
					oFormatoDetalleMovimientoBE.Idrubro = oDataGrid.rows[rowIndex].IDRUBRO;
					oFormatoDetalleMovimientoBE.Idcentrooperativo = KEYQPARAMETROS.IDCENTROOPERATIVO;
					oFormatoDetalleMovimientoBE.Periodo = KEYQPARAMETROS.PERIODO;
					oFormatoDetalleMovimientoBE.Idmes = idMes;
					oFormatoDetalleMovimientoBE.Idtipoinformacion = KEYQPARAMETROS.IDTIPOINFORMACION
					oFormatoDetalleMovimientoBE.Observacion = Datos[0].toString();
					
					if(parseInt((new Controladora.General.CFormatoDetalleMovimiento()).InsertarModificarObservaciones(oFormatoDetalleMovimientoBE),10)!=0);{
						objCell.style.cssText = "BACKGROUND-IMAGE:url(" + SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/imagenes/tree/Nota.gif);BACKGROUND-REPEAT:no-repeat;BACKGROUND-POSITION:left top";
					}
					
					
				}
			}
			/*---------------------------------------------------------------------------------------------------------------------------*/
			function AceptarAccion(){
				if(document.getElementById("hOpSelected").value==1){
					if(confirm("Desea Importar saldos del mes " + arrMes[document.getElementById("hIdMes").value-1].toString() + " ahora?...")) {
						__doPostBack('cmdImportarSaldos1',document.getElementById("hIdMes").value+";"+idxCell);
					} 
				}
				else if(document.getElementById("hOpSelected").value==2){
					if(confirm("Desea procesar el mes " + arrMes[document.getElementById("hIdMes").value-1].toString() + " ahora?...")) {
						__doPostBack('btnPrc',document.getElementById("hIdMes").value+";"+idxCell);
					} 
				}
				else if(document.getElementById("hOpSelected").value==5){
										if(confirm("Desea Exportara excel la información hasta el mes  de " + arrMes[document.getElementById("hIdMes").value-1].toString() + " ahora?...")) {
						__doPostBack('btnExportaXLS',document.getElementById("hIdMes").value+";"+idxCell);
					} 
				}
				else if(document.getElementById("hOpSelected").value==6){
					if(confirm("Desea Exportara excel la información hasta el mes  de " + arrMes[document.getElementById("hIdMes").value-1].toString() + " ahora?...")) {
						__doPostBack('btnResumenyDetalleXLS',document.getElementById("hIdMes").value+";"+idxCell);
					} 
				}
				else{
					if((document.getElementById("hOpSelected").value==3)||(document.getElementById("hOpSelected").value==4)){
							var Parametros;
							var Url = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Procesar.aspx?"; 
							with(SIMA.Utilitario.Constantes.General.Caracter){
								Parametros =KEYQIDFORMATO + SignoIgual.toString() + KEYQPARAMETROS.IDFORMATO 
								+ signoAmperson.toString() 
								+ KEYQIDREPORTE + SignoIgual.toString() + KEYQPARAMETROS.IDREPORTE
								+ signoAmperson.toString() 
								+ KEYQPERIODO + SignoIgual.toString() + KEYQPARAMETROS.PERIODO
								+ signoAmperson.toString() 
								+ IDCENTROOPERATIVO + SignoIgual.toString() + KEYQPARAMETROS.IDCENTROOPERATIVO
								+ signoAmperson.toString() 
								+ KEYQIDTIPOINFO + SignoIgual.toString() + KEYQPARAMETROS.IDTIPOINFORMACION
								+ signoAmperson.toString() 
								+ KEYQVERDETALLERPT + SignoIgual.toString() + ((document.getElementById("hOpSelected").value==3)?0:1)
								+ signoAmperson.toString() 
								+ KEYQIDMES + SignoIgual.toString() + document.getElementById("hIdMes").value
								+ signoAmperson.toString() 
								+ KEYQIDPROCESO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.ProcesoCallBack.GenerarFormatoReportedetalleCtaPorRubro;
							}
							oPagina.Response.TopRedirect(Url+ Parametros);
							PopupDeEspera();	
						}
				}
			}			
			function ProcesarCuentasCtables(IdMes,oCell){
				idxCell=oCell.cellIndex+1;
				document.getElementById("hIdMes").value=IdMes;
				document.getElementById("lblMesSeleccionado").innerText="Para el mes de :" + arrMes[document.getElementById("hIdMes").value-1];
				(new System.Ext.UI.WebControls.Windows()).DetalleFromEL('MiVentana','tblAcciones','Seleccionar',300,240,AceptarAccion);
			}
			/*---------------------------------------------------------------------------------------------------------------------------*/
			function CrearNodoAd(sText,Nivel,sClass){
			//	alert(Nivel);
				var otblHtml = SIMA.Utilitario.Helper.CrearTabla(1,Nivel+1);
					otblHtml.border = 0;
					otblHtml.cellPadding = 0;
					otblHtml.cellSpacing = 0;
					otblHtml.width = "100%";
					var ultCell = otblHtml.rows[0].cells.length-1;
					otblHtml.rows[0].className=sClass;
					otblHtml.rows[0].cells[ultCell].innerText=sText;
					otblHtml.rows[0].cells[ultCell].width = "100%";
					otblHtml.rows[0].cells[ultCell].style.cssText="PADDING-LEFT: 7px";
					otblHtml.rows[0].cells[ultCell].style.textAlign = 'left';

					for (var i=0; i <= (Nivel).length; i++){
						var oImg = document.createElement('IMG');
							oImg.src = "/"+ ApplicationPath + "/imagenes/tree/Blanco.gif";
							oImg.width = 16;
							otblHtml.rows[0].cells[i].appendChild(oImg);
					}		
					return 	otblHtml;		
			}
			
			var arrCols=["CtaContable","Enero","Febrero","Marzo","TrimI","Abril","Mayo","Junio","TrimII","Julio","Agosto","Setiembre","TrimIII","Octubre","Noviembre","Diciembre","TrimIV","Total"];
			function DetalleContablePorItem(e){
				if(e.getAttribute("Cargado")!=undefined){
					var GridBody = e.parentNode;
					var NroRegFind = e.rowIndex + e.getAttribute("NroReg");
					var DISPLAY = ((e.getAttribute("VISIBLE")=="TRUE")?"none":"block");
						for(var x=e.rowIndex+1;x<=NroRegFind;x++){
							GridBody.rows[x].style.display=DISPLAY;
						}
						e.setAttribute("VISIBLE",((DISPLAY=="none")?"FLASE":"TRUE"));
					return;
				}
				
				
				var idRubro=e.getAttribute("IDRUBRO");
				var ClassNameDefault=e.className;
				//if(Page.Request.Params[KEYQREQCTACTABLE]==1){
							var NroReg=0;
							var oDataTable = (new Controladora.General.CFormatoDetalleMovimientoCentroCostoItem()).ConsultarFormatoDetalleMovimientoCtaPorRubro(KEYQPARAMETROS.IDFORMATO,KEYQPARAMETROS.IDREPORTE,idRubro, KEYQPARAMETROS.IDCENTROOPERATIVO, KEYQPARAMETROS.IDCENTROCOSTO,KEYQPARAMETROS.PERIODO, KEYQPARAMETROS.IDTIPOINFORMACION,Page.Request.Params[KEYQREQCTACTABLE]);
							for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
								var dr =oDataTable.Rows.Items[f];
								if(dr.Item("EOF")==false){
										var trNew = e.parentNode.insertRow(e.rowIndex+1);
										trNew.setAttribute("NRONIVEL",e.getAttribute("NRONIVEL"));
										trNew.setAttribute("IDTIPOLINEA",e.getAttribute("IDTIPOLINEA"));
										trNew.setAttribute("NIVEL",e.getAttribute("NIVEL"));
										trNew.setAttribute("IDNIVEL",e.getAttribute("IDNIVEL")); 
										ClassNameDefault=((ClassNameDefault.toUpperCase()=="AlternateItemGrilla".toUpperCase())? "ItemGrilla":"AlternateItemGrilla");
										trNew.className="ItemGrillaWhite";//ClassNameDefault;
										
										for(var i=0;i<=e.cells.length-1;i++){
											var td = document.createElement("TD");
											td.style.display= e.cells[i].style.display;
											trNew.appendChild(td);
											if(i==0){
												td.Align="left";
												//td.appendChild(CrearNodoAd(dr.Item(arrCols[i]),e.getAttribute("NIVEL"),ClassNameDefault));
												td.appendChild(CrearNodoAd(dr.Item(arrCols[i]),e.getAttribute("NIVEL"),"ItemGrillaWhite"));
											}
											else{
												td.innerText= dr.Item(arrCols[i]);
												td.style.textAlign = 'right';
											}
										}
										NroReg++;
								}
							}
				/*}
				else{
					//alert('Detalle de Nota Contable');
				}*/
				e.setAttribute("Cargado",true);
				e.setAttribute("NroReg",NroReg);
				e.setAttribute("VISIBLE","TRUE");
				
			}	
			/*---------------------------------------------------------------------------------------------------------------------------*/
			function DetallePorCuenta(e){
			
			}
		</SCRIPT>
		<SCRIPT>
			function Inicializar(){
				oDataGrid = $O("grid");
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				URLPAGINA = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/DetalleRubro.aspx?";
				arrMes =["Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Setiembre","Octubre","Noviembre","Diciembre"];
				arrRowFormula = oDataGrid.getAttribute("FILAFORMULA").split(";");				
				if(arrRowFormula.length>0){arrRowFormula.pop();}
				
				var arrLstPrioridadDuplex = oDataGrid.getAttribute("LSTPRIORIDAD").split(";");
				if(arrLstPrioridadDuplex.length>0){
					arrLstPrioridadDuplex.pop(); 
					arrLstPrioridad = [];
					jSIMA.each(arrLstPrioridadDuplex, function(i, el){
														if(jSIMA.inArray(el, arrLstPrioridad ) === -1) arrLstPrioridad.push(el);
													});
					arrLstPrioridad.sort();
				}
				KEYQPARAMETROS.IDFORMATO = oPagina.Request.Params[KEYQIDFORMATO];
				KEYQPARAMETROS.IDREPORTE = oPagina.Request.Params[KEYQIDREPORTE];
				KEYQPARAMETROS.IDCENTROOPERATIVO = oPagina.Request.Params[IDCENTROOPERATIVO];
				KEYQPARAMETROS.IDCENTROCOSTO = oPagina.Request.Params[KEYQIDCENTROCOSTO];
				KEYQPARAMETROS.PERIODO = oPagina.Request.Params[KEYQPERIODO];
				KEYQPARAMETROS.IDTIPOINFORMACION = oPagina.Request.Params[KEYQIDTIPOINFO];
				var  oFDoc= $O('FDoc');
				oFDoc.onchange=function(){
					if(this.value.length>0){
						if(window.confirm("Desea ud. subir este archivo de indicadores ahora?")==true){
							(new Controladora.General.CFormato()).SubirArchivoIndicadores(this.value);
						}
					}
				}
				if(KEYQPARAMETROS.IDFORMATO !=SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Codigo.BalanceGeneral){$O('tblBuscarArchivo').style.display="none";}
			} 
			
			
			function ElaborarNiveles(Indice,arrNiveles){
				var stNivelFind="";
				for(var i=0;i<=Indice;i++){	stNivelFind += arrNiveles[i] + ".";}
				return stNivelFind.substring(0,stNivelFind.length-1);
			}	
			function RestauraNodoSeleccionado(){
				try{
					var NodoValor = oPagina.Request.Params[NODOSELECCIONADO];
					if (NodoValor!= undefined){
						var arrNiveles = NodoValor.split(".");
						var UltElemento = arrNiveles.length-1;
						var Indice=0;
						var stNivelFind =ElaborarNiveles(Indice,arrNiveles);
						for(var Fila=1;Fila<=oDataGrid.rows.length-1;Fila++){
							if (oDataGrid.rows[Fila].NRONIVEL.toString().Igual(stNivelFind)==true){
								if (Indice<UltElemento){
									var objTblNodo = oDataGrid.rows[Fila].cells(0).children[0];
									objTblNodo.Click=function(){
										var ObjImg = this.rows[0].cells[(this.rows[0].cells.length-3)].children[0];
										ObjImg.onclick();
										objTblNodo.parentElement.parentElement.onclick();
									}
									objTblNodo.Click();
									Indice++;
									stNivelFind =ElaborarNiveles(Indice,arrNiveles);
								}
							}
						}
					}
				}
				catch(error){
					TIPONODOPRINCIPAL=0;
				}
			}
			function CollapseCol(e,Cell){
				var arrPath = e.src.toString().split('/');
				var Path = SIMA.Utilitario.Helper.General.ObtenerPathApp() +"/imagenes/tree/";
				
				var Icono = ((arrPath[arrPath.length-1]=="plusCol.gif")?"minusCol.gif":"plusCol.gif");
				var vista = ((arrPath[arrPath.length-1]=="plusCol.gif")?"block":"none");
				
				//Cell.colSpan = ((arrPath[arrPath.length-1]=="plusCol.gif")?4:1);
				var PrefCell="grid__ctl1_";
				var NomCell = PrefCell+ jSIMA(e).prop("id");
				var objCell = document.getElementById(NomCell);
				objCell.colSpan = ((arrPath[arrPath.length-1]=="plusCol.gif")?4:1);
				
				e.src= Path +Icono;
				
				for(var f=1;f<=oDataGrid.rows.length-1;f++){
					for(c=parseInt(e.ColIni,10);c<=(parseInt(e.ColIni,10)+2);c++){
						var idxCell = ((f==1)?c-1:c);
						oDataGrid.rows[f].cells[idxCell].style.display=vista;
					}
				}				
			}
			function OnClickCollpase(){
				var oNPluMinus = $O('hNombreImgTrim');
				var oimg = $O(oNPluMinus.value);
				CollapseCol(oimg,oimg.parentElement.parentElement.parentElement.parentElement.parentElement);
			}
				
			/*-----------------------------------------------------------------------------------------------------------------*/
			function ModificarItems(_cellIndex){
				jSIMA.each(arrRowFormula, function (index, value) {
					ModificarItem(value,_cellIndex);
				});
			}
			function ModificarItem(idFila,_cellIndex){
				var objNB= oDataGrid.rows[idFila].cells[_cellIndex].children[0];
				//var MesCerrado= oDataGrid.rows[1].cells[_cellIndex].getAttribute('CERRADO');
					if(parseInt(oPagina.Request.Params[KEYQREQCC],10)==1){
						var oFormatoDetalleMovimientoCentroCostoBE = new EntidadesNegocio.General.FormatoDetalleMovimientoCentroCostoBE();
							oFormatoDetalleMovimientoCentroCostoBE.Idformato= KEYQPARAMETROS.IDFORMATO;
							oFormatoDetalleMovimientoCentroCostoBE.Idreporte = KEYQPARAMETROS.IDREPORTE;
							oFormatoDetalleMovimientoCentroCostoBE.Idrubro = oDataGrid.rows[idFila].IDRUBRO;
							oFormatoDetalleMovimientoCentroCostoBE.Idcentrooperativo = KEYQPARAMETROS.IDCENTROOPERATIVO;
							oFormatoDetalleMovimientoCentroCostoBE.Idcentrocosto = KEYQPARAMETROS.IDCENTROCOSTO;
							oFormatoDetalleMovimientoCentroCostoBE.Periodo = KEYQPARAMETROS.PERIODO;
							oFormatoDetalleMovimientoCentroCostoBE.Idmes = objNB.idMes;
							oFormatoDetalleMovimientoCentroCostoBE.Idtipoinformacion = KEYQPARAMETROS.IDTIPOINFORMACION;
							oFormatoDetalleMovimientoCentroCostoBE.Montomes = objNB.tag;
							(new Controladora.General.CFormatoDetalleMovimientoCentroCosto()).InsertarModificar(oFormatoDetalleMovimientoCentroCostoBE);
							//alert('Modificado');
					}
					else{//Para el Caso que el formato sea por centro de operaciones
						var oFormatoDetalleMovimientoBE = new EntidadesNegocio.General.FormatoDetalleMovimientoBE();
							oFormatoDetalleMovimientoBE.Idformato= KEYQPARAMETROS.IDFORMATO;
							oFormatoDetalleMovimientoBE.Idreporte = KEYQPARAMETROS.IDREPORTE;
							oFormatoDetalleMovimientoBE.Idrubro = oDataGrid.rows[idFila].IDRUBRO;
							oFormatoDetalleMovimientoBE.Idcentrooperativo = KEYQPARAMETROS.IDCENTROOPERATIVO;
							oFormatoDetalleMovimientoBE.Idcentrocosto = -1;
							oFormatoDetalleMovimientoBE.Periodo = KEYQPARAMETROS.PERIODO;
							oFormatoDetalleMovimientoBE.Idmes = objNB.idMes;
							oFormatoDetalleMovimientoBE.Idtipoinformacion = KEYQPARAMETROS.IDTIPOINFORMACION;
							oFormatoDetalleMovimientoBE.Montomes = objNB.tag;
							(new Controladora.General.CFormatoDetalleMovimiento()).InsertarModificar(oFormatoDetalleMovimientoBE);
					}
			}
			function RefrescaColumnadeTotalesdelaGrilla(){
				var idCentroCosto = ((parseInt(KEYQPARAMETROS.IDCENTROCOSTO,10)==1)?KEYQPARAMETROS.IDCENTROCOSTO:-1);
				var oDataTable = new System.Data.DataTable("tblMovFormatoCC");
				oDataTable = (new Controladora.General.CFormatoDetalleMovimientoCentroCosto()).ConsultarFormatoEstructuraMovimientoCentroCosto(KEYQPARAMETROS.IDFORMATO,KEYQPARAMETROS.IDCENTROOPERATIVO,KEYQPARAMETROS.PERIODO,KEYQPARAMETROS.IDTIPOINFORMACION,idCentroCosto);
				
				var rowIndex= NroRowIni;
				for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
					var dr =oDataTable.Rows.Items[f];
					if(dr.Item("EOF")==false){
						oDataGrid.rows[rowIndex].cells[4].innerText = new SIMA.Numero(parseFloat(dr.Item("TrimI"))).toString(2,true,',');
						oDataGrid.rows[rowIndex].cells[8].innerText = new SIMA.Numero(parseFloat(dr.Item("TrimII"))).toString(2,true,',');
						oDataGrid.rows[rowIndex].cells[12].innerText = new SIMA.Numero(parseFloat(dr.Item("TrimIII"))).toString(2,true,',');
						oDataGrid.rows[rowIndex].cells[16].innerText = new SIMA.Numero(parseFloat(dr.Item("TrimIV"))).toString(2,true,',');
						rowIndex++;
					}
				}																																				
																																				
			}
				function CalculoPorPrioridad(Prioridad,CellIndex){
					jSIMA("[PRIORIDAD]").each(function(i,e){
						var orowFormula = jSIMA(e)[0];
							if(parseInt(jSIMA(orowFormula).attr("PRIORIDAD"))== parseInt(Prioridad)){
								var objNB= jSIMA(orowFormula.cells[CellIndex]).children(".NumericBox");
								var strFormula=jSIMA(orowFormula).attr("FORMULA");
								strFormula = strFormula.substring(0,strFormula.length-1);
								var oFormatoFormulaRubroBE = new EntidadesNegocio.General.FormatoFormulaRubroBE();
									oFormatoFormulaRubroBE.IdFormato= KEYQPARAMETROS.IDFORMATO;
									oFormatoFormulaRubroBE.IdReporte=KEYQPARAMETROS.IDREPORTE;
									oFormatoFormulaRubroBE.IdRubro= jSIMA(orowFormula).attr("IDRUBRO");
									oFormatoFormulaRubroBE.IdCentroOperativo = KEYQPARAMETROS.IDCENTROOPERATIVO;
									oFormatoFormulaRubroBE.Periodo=KEYQPARAMETROS.PERIODO;
									oFormatoFormulaRubroBE.IdMes= jSIMA(objNB).attr("idMes");
									oFormatoFormulaRubroBE.IdTipoInformacion=KEYQPARAMETROS.IDTIPOINFORMACION;
									oFormatoFormulaRubroBE.IdTipoMonto='M';
									oFormatoFormulaRubroBE.Formula=strFormula;
									
								var TotalDB = (new Controladora.General.CFormatoFormula()).DecifrarFormula(oFormatoFormulaRubroBE);
								var TotaFormat = new SIMA.Numero(parseFloat(TotalDB)).toString(2,true,',');
									jSIMA(objNB).prop("value",TotaFormat);
									jSIMA(objNB).prop("tag",TotalDB);
									//Realiza la modificacion del importe en la BD
									ModificarItem(jSIMA(objNB).prop("rowIndex"),jSIMA(objNB).prop("cellIndex"));
							}
						});
				}			
			function ProcesarCalculo(_CellIndex){
				jSIMA.each(arrLstPrioridad, function (index, value) {
								CalculoPorPrioridad(value,_CellIndex);
					});
			}			
			/*.............................................................................................*/
			function NewonBlur(){
				//NumericBox_IE_ParseAdd(this, ' ', ',', '.');
				if (EstadodeValorActual == true){ 
					EstadodeValorActual = false;
					var txtBoxEdit = jSIMA(this);
					txtBoxEdit.prop("tag",txtBoxEdit.val());
					var cellIndex= txtBoxEdit.attr("cellIndex");
					ModificarItem(this.rowIndex,this.cellIndex);
					ProcesarCalculo(cellIndex);
					//ModificarItems(this.cellIndex);//Modifica en la base de datos todos los items de formula cambiados
					RefrescaColumnadeTotalesdelaGrilla();
				}
			}	
			/*------------------------------------------------------------------------*/
			function CuandoCambiaValor(){EstadodeValorActual = true;}
			function EnfocarSiguienteCelda(e){
				//Considerado para la navegacion hacia abajo
				oDataGrid.EnfocarAbajo=function(){
					try{
						var objNBSiguiente =  this.rows[idxrowAbajo].cells[idxcell].children[0];
						jSIMA(objNBSiguiente).focus();
					}
					catch(error){
						//window.alert(error.description);
					}
				}
				oDataGrid.EnfocarArriba=function(){
					try{
						var objNBSiguiente =  this.rows[idxrowArriba].cells[idxcell].children[0];
						//objNBSiguiente.focus();
						jSIMA(objNBSiguiente).focus();
					}
					catch(error){}
				}
				oDataGrid.EnfocarDerecha=function(){
					try{
						var objNBSiguiente =  this.rows[idxrow].cells[idxcellDerecha].children[0];
						//objNBSiguiente.focus();
						jSIMA(objNBSiguiente).focus();
					}
					catch(error){}
				}
				e.tag = e.value;
				var idxrow = e.rowIndex;
				var idxcell = e.cellIndex;  
				
				try{
					idxrowArriba = ((idxrow == NroRowIni)?NroRowIni:idxrow-1) ;  
					idxrowAbajo = ((idxrow == oDataGrid.rows.length-1)?NroRowIni:parseInt(idxrow)+1) ;  
					idxcellDerecha = 0;
					
					if(e.parentNode.cellIndex==15){idxcellDerecha=1;}
					else if((idxcell==3)||(idxcell==7)||(idxcell==11)){idxcellDerecha = parseInt(idxcell)+2;}
					else{idxcellDerecha = idxcell+1;}
						
					var idxcellIzquierda = ((e.parentNode.cellIndex==1)?1:e.parentNode.cellIndex-1);  
					//Ejecuta el desplazamiento
					
					//if (event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.KeyReturn || event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.keyDown){oDataGrid.EnfocarAbajo();}
					if (event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.keyDown){oDataGrid.EnfocarAbajo();}
					else if(event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.keyTab){oDataGrid.EnfocarDerecha();}
					else if (event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.keyUp){oDataGrid.EnfocarArriba();}
				}
				catch(error){
				}
				
			}			
			function AsignarEventodeSalidayCambio(){
				Inicializar();
				jSIMA(".NumericBox").blur(NewonBlur);
				jSIMA(".NumericBox").change(CuandoCambiaValor);
				jSIMA(".NumericBox").keydown(EnfocarSiguienteCelda);
			}
			
			function FormulaContable(e){
					var Parametros = "";
					var vAncho=940;
					var vAlto = 250;
				if(FormEntreRubro==0){alert('Concepto no configura Cta o Nota contable'); return;}
					
					with(SIMA.Utilitario.Constantes.General.Caracter){
						Parametros = KEYQIDFORMATO + SignoIgual + Page.Request.Params[KEYQIDFORMATO] 
									+ signoAmperson 
									+ KEYQIDREPORTE + SignoIgual + Page.Request.Params[KEYQIDREPORTE] 
									+ signoAmperson 
									+ KEYQNOMBREFORMATO + SignoIgual + Page.Request.Params[KEYQNOMBREFORMATO] 
									+ signoAmperson 
									+ KEYQRUBRONOMBRE + SignoIgual + "nombre"
									+ signoAmperson 
									+ KEYQIDRUBRO + SignoIgual +  IdRubroSelect
									+ signoAmperson 
									+ KEYQPERIODO+ SignoIgual + KEYQPARAMETROS.PERIODO;
					}
					var URLLoad = ((Page.Request.Params[KEYQREQCTACTABLE]=="1")?URLPAGINAFORMUALCONTABLE:URLPAGINANOTACONTABLE);
					
					if(Ventana==undefined){
						Ventana = (new SIMA.Utilitario.Helper.Response()).ShowDialogoOnTop(URLLoad + Parametros,vAncho,vAlto);
					}
					else{
						try{
							if(Ventana.document.location.href){}
						}
						catch(error){
							Ventana = (new SIMA.Utilitario.Helper.Response()).ShowDialogoOnTop(URLLoad+ Parametros,vAncho,vAlto);
						}
					}				
			}
		
			function ObtenerIdRubro(id,ConfigCta){
				IdRubroSelect = id;
				FormEntreRubro = ConfigCta;
			}
			
		
			function SetMesID(Id){
				jNet.get('hIdMes').value = Id;
				__doPostBack('btnMostrarMes',Id);
			}
		</SCRIPT>
	</HEAD>
	<body onkeypress="if((event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.KeyReturn)||(event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.keyTab)){return false;}"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0" Tag="Local">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD align="left"></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top" align="center">
						<TABLE style="WIDTH: 771px; HEIGHT: 155px" id="Table3" border="0" cellSpacing="1" cellPadding="1"
							width="771">
							<TR>
								<TD align="left">
									<TABLE id="Table4" border="0" cellSpacing="1" cellPadding="1" width="300" align="left">
										<TR>
											<TD><asp:label id="Label1" runat="server" style="Z-INDEX: 0">MES:</asp:label></TD>
											<TD><asp:dropdownlist id="ddlMesSelect" runat="server">
													<asp:ListItem Value="1">Enero</asp:ListItem>
													<asp:ListItem Value="2">Febrero</asp:ListItem>
													<asp:ListItem Value="3">Marzo</asp:ListItem>
													<asp:ListItem Value="4">Abril</asp:ListItem>
													<asp:ListItem Value="5">Mayo</asp:ListItem>
													<asp:ListItem Value="6">Junio</asp:ListItem>
													<asp:ListItem Value="7">Julio</asp:ListItem>
													<asp:ListItem Value="8">Agosto</asp:ListItem>
													<asp:ListItem Value="9">Setiembre</asp:ListItem>
													<asp:ListItem Value="10">Octubre</asp:ListItem>
													<asp:ListItem Value="11">Noviembre</asp:ListItem>
													<asp:ListItem Value="12">Diciembre</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
								<TD align="left"></TD>
							</TR>
							<TR>
								<TD>
									<asp:label style="Z-INDEX: 0" id="lblDescripcion" runat="server">descripcion:</asp:label></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="2">
									<cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="100%" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle Height="20px" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Concepto" HeaderText="CONCEPTO">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="SALDO INI">
												<HeaderStyle Width="4.3%"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox style="Z-INDEX: 0" id="NSaldoIni" runat="server" Width="104px" AutoFormatCurrency="True"
														DollarSign=" " DecimalPlaces="3" MaxLength="18" BorderStyle="None" BorderColor="Transparent"
														BackColor="Transparent" TextAlign="Right" PlacesBeforeDecimal="15" CssClass="NumericBox"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="AUMENTOS">
												<HeaderStyle Width="4.3%"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox style="Z-INDEX: 0" id="nAumentos" runat="server" Width="104px" CssClass="NumericBox"
														PlacesBeforeDecimal="15" TextAlign="Right" BackColor="Transparent" BorderColor="Transparent"
														BorderStyle="None" MaxLength="18" DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="DISMINUCIONES">
												<HeaderStyle Width="4.3%"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox style="Z-INDEX: 0" id="nDisminuciones" runat="server" Width="104px" CssClass="NumericBox"
														PlacesBeforeDecimal="15" TextAlign="Right" BackColor="Transparent" BorderColor="Transparent"
														BorderStyle="None" MaxLength="18" DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn HeaderText="SALDO FINAL">
												<HeaderStyle Width="4.3%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><IMG style="Z-INDEX: 0" id="ibtnUser" alt="" src="../../imagenes/Navegador/User.gif"
							width="30" height="30">
					</TD>
				</TR>
				<tr>
					<td style="DISPLAY: none" id="LstUser" align="center" runat="server"></td>
				</tr>
				<TR style="DISPLAY: none">
					<TD align="center">
						<TABLE id="tblAcciones" border="0" cellSpacing="2" cellPadding="1" width="300">
							<TR>
								<TD id="lblMesSeleccionado" class="headerDetalle">para ABRIL</TD>
							</TR>
							<TR>
								<TD class="BaseItemInGrid"><asp:radiobutton id="R1" runat="server" Text="Importar y procesar formato" GroupName="OPMes"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD class="BaseItemInGrid"><asp:radiobutton id="R2" runat="server" Text="Procesar formato" GroupName="OPMes"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD class="BaseItemInGrid"><asp:radiobutton id="R3" runat="server" Text="Imprimir resumen" GroupName="OPMes"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD class="BaseItemInGrid"><asp:radiobutton style="Z-INDEX: 0" id="R4" runat="server" Text="Imprimir detallado" GroupName="OPMes"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 20px" class="BaseItemInGrid"><asp:radiobutton style="Z-INDEX: 0" id="R5" runat="server" Text="Exportar a excel" GroupName="OPMes"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 20px" class="BaseItemInGrid"><asp:radiobutton style="Z-INDEX: 0" id="R6" runat="server" Text="Exportar a excel detallado" GroupName="OPMes"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD><INPUT style="WIDTH: 72px; HEIGHT: 22px" id="hOpSelected" value="0" size="6" type="hidden"
										name="hOpSelected" runat="server"></TD>
							</TR>
						</TABLE>
						<INPUT style="DISPLAY: none" id="txtDescripcion"><asp:label id="lblResultado" runat="server"></asp:label><INPUT style="WIDTH: 85px; HEIGHT: 22px" id="hidFilaSeleccionada" size="8" type="hidden"><INPUT style="WIDTH: 77px; HEIGHT: 22px" id="hNroNivel" size="7" type="hidden"><INPUT style="Z-INDEX: 0; WIDTH: 77px; HEIGHT: 22px" id="hNombreImgTrim" size="7" type="hidden"
							name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 77px; HEIGHT: 22px" id="hIdMes" value="0" size="7" type="hidden"
							name="Hidden1" runat="server">
						<asp:button style="Z-INDEX: 0" id="btnPrc" runat="server" Text="ProcesarReporte"></asp:button><asp:button style="Z-INDEX: 0" id="btnExportaXLS" runat="server" Text="xls"></asp:button><asp:button id="cmdImportarSaldos1" runat="server" Text="Button"></asp:button><asp:button style="Z-INDEX: 0" id="btnResumenyDetalleXLS" runat="server" Text="xls"></asp:button><asp:button id="btnMostrarMes" runat="server" Text="MostrarMesSeleccionado"></asp:button><asp:datagrid style="Z-INDEX: 0" id="gridPost" runat="server" AutoGenerateColumns="False" AllowSorting="True"
							PageSize="1" AllowPaging="True">
							<Columns>
								<asp:BoundColumn DataField="Codigo" SortExpression="Codigo" HeaderText="CODIGO"></asp:BoundColumn>
								<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="DESCRIPCION"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<script>
			
			jSIMA(document).ready(function() {
				RestauraNodoSeleccionado();AsignarEventodeSalidayCambio();OnClickCollpase();
			});

			jSIMA('#ibtnUser').click(function(){
				var contenido=jSIMA('#LstUser');
  					if(contenido.css("display")=="none"){ //open		
      					contenido.slideDown(250);			
      					jSIMA(this).addClass("open");
  					}
  					else{ //close		
      					contenido.slideUp(250);
      					jSIMA(this).removeClass("open");	
  					}
  			});
			</script>
		</form>
	</body>
</HTML>
