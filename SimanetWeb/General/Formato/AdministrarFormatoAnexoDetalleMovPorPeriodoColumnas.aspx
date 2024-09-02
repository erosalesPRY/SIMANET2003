<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministrarFormatoAnexoDetalleMovPorPeriodoColumnas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Formato.AdministrarFormatoAnexoDetalleMovPorPeriodoColumnas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrar Formato Anexo</title>
		<meta name="vs_showGrid" content="False">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<SCRIPT language="javascript" src="../../js/JQuery/js/jquery.min.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>
		<style>.ContextImg {
	Z-INDEX: 3; POSITION: relative; WIDTH: 45px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 45px
}
.imgCirc {
	Z-INDEX: 1; POSITION: absolute; BACKGROUND-REPEAT: no-repeat; TOP: -2px; left-30: 
}
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
			var KEYQACUMULADO="Acum";
			var KEYQIDCOLUMNA="IdCol";
			var KEYQIDPROCESO = "idProceso";
			var IDCENTROOPERATIVO="idcop";
			var KEYQIDCENTROCOSTO ="idCC";
			var KEYQIDTIPOINFO ="idTipoInfo";
			var KEYQVERDETALLERPT ="VDT";
			var KEYQREQCC ="ReqCC";
			var KEYQNRONIVEL="NroNivel";
			var URLPAGINA ="";
			var oPagina;
			var NroMaxColumn=0;
			var NroRowIni = 1;
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
				/*if(document.getElementById("hOpSelected").value==1){
					if(confirm("Desea Importar saldos del mes " + arrMes[document.getElementById("hIdMes").value-1].toString() + " ahora?...")) {
						__doPostBack('cmdImportarSaldos1',document.getElementById("hIdMes").value+";"+idxCell);
					} 
				}
				else */if(document.getElementById("hOpSelected").value==2){
					if(confirm("Desea procesar el mes " + arrMes[document.getElementById("hIdMes").value-1].toString() + " ahora?...")) {
						__doPostBack('btnPrc',document.getElementById("hIdMes").value+";"+idxCell);
					} 
				}/*
				else if(document.getElementById("hOpSelected").value==5){
					alert("En COnstrucción"); return;
										if(confirm("Desea Exportara excel la información hasta el mes  de " + arrMes[document.getElementById("hIdMes").value-1].toString() + " ahora?...")) {
						__doPostBack('btnExportaXLS',document.getElementById("hIdMes").value+";"+idxCell);
					} 
				}
				else if(document.getElementById("hOpSelected").value==6){
					alert("En COnstrucción"); return;
					if(confirm("Desea Exportara excel la información hasta el mes  de " + arrMes[document.getElementById("hIdMes").value-1].toString() + " ahora?...")) {
						__doPostBack('btnResumenyDetalleXLS',document.getElementById("hIdMes").value+";"+idxCell);
					} 
				}
				else{*/
					else if((document.getElementById("hOpSelected").value==3)||(document.getElementById("hOpSelected").value==4)){
						 HistorialIrAdelante();
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
								+ KEYQIDPROCESO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.ProcesoCallBack.GenerarFormatoReporteContraloria;
							}
							
							//alert(Url+ Parametros);
							
							oPagina.Response.TopRedirect(Url+ Parametros);
							PopupDeEspera();
						}
				/*}*/
			}			
			function ProcesarCuentasCtables(){
				(new System.Ext.UI.WebControls.Windows()).DetalleFromEL('MiVentana','tblAcciones','Seleccionar',300,250,AceptarAccion);
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
							//var oDataTable = (new Controladora.General.CFormatoDetalleMovimientoCentroCostoItem()).ConsultarFormatoDetalleMovimientoCtaPorRubro(KEYQPARAMETROS.IDFORMATO,KEYQPARAMETROS.IDREPORTE,idRubro, KEYQPARAMETROS.IDCENTROOPERATIVO, KEYQPARAMETROS.IDCENTROCOSTO,KEYQPARAMETROS.PERIODO, KEYQPARAMETROS.IDTIPOINFORMACION,Page.Request.Params[KEYQREQCTACTABLE]);
							var oDataTable = (new Controladora.General.CFormatoReporteColumnaMovimiento()).ListarDetalleCtaPorRubro(KEYQPARAMETROS.IDCENTROOPERATIVO,KEYQPARAMETROS.PERIODO,document.getElementById("hIdMes").value,KEYQPARAMETROS.IDFORMATO,KEYQPARAMETROS.IDREPORTE,idRubro, Page.Request.Params[KEYQACUMULADO]);
							
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
												td.appendChild(CrearNodoAd(dr.Item("CuentaContable") +"-"+ dr.Item("NombreCuenta")  ,e.getAttribute("NIVEL"),"ItemGrillaWhite"));
											}
											else{
												var CellNodo = e.cells[i];
												td.innerText= dr.Item(CellNodo.getAttribute("NomCol"));
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
			function DetalleColumna(IdColumna){
				var vAncho=940;
				var vAlto = 250;
				var URLDETALLECOLUMNA=SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/DetalleColumna.aspx?" + KEYQIDCOLUMNA  +"=" + IdColumna + "&" + SIMA.Utilitario.Constantes.KEYMODOPAGINA +"="+SIMA.Utilitario.Enumerados.ModoPagina.M;
				Ventana = (new SIMA.Utilitario.Helper.Response()).ShowDialogoOnTop(URLDETALLECOLUMNA ,vAncho,vAlto);
			}
		</SCRIPT>
		<SCRIPT>
			function Inicializar(){
				oDataGrid = $O("grid");
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				URLPAGINA = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/DetalleRubro.aspx?";
				arrMes =["Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Setiembre","Octubre","Noviembre","Diciembre"];
				
				NroMaxColumn = oDataGrid.getAttribute("NROMAXCOLUMN");
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
			} 
			
			
			/*-----------------------------------------------------------------------------------------------------------------*/
			function ModificarItem(idFila,_cellIndex){
				var objNB= oDataGrid.rows[idFila].cells[_cellIndex].children[0];
					var oFormatoReporteColumnaMovimientoBE = new EntidadesNegocio.Presupuesto.FormatoReporteColumnaMovimientoBE();
					oFormatoReporteColumnaMovimientoBE.Periodo = KEYQPARAMETROS.PERIODO;
					oFormatoReporteColumnaMovimientoBE.IdMes = jNet.get('hIdMes').attr('value');
					oFormatoReporteColumnaMovimientoBE.IdCentroOperativo = KEYQPARAMETROS.IDCENTROOPERATIVO;
					oFormatoReporteColumnaMovimientoBE.IdFormato = KEYQPARAMETROS.IDFORMATO;
					oFormatoReporteColumnaMovimientoBE.IdReporte = KEYQPARAMETROS.IDREPORTE;
					oFormatoReporteColumnaMovimientoBE.IdRubro = oDataGrid.rows[idFila].IDRUBRO;
					oFormatoReporteColumnaMovimientoBE.IdColumna = jNet.get(objNB).attr('idCol');
					oFormatoReporteColumnaMovimientoBE.Valor= jNet.get(objNB).attr('tag');								
					(new Controladora.Personal.CFormatoReporteColumnaDetalleMovimiento()).InsAct(oFormatoReporteColumnaMovimientoBE);
			}

			function ProcesarCalculo(_CellIndex){
				jSIMA.each(arrLstPrioridad, function (index, value) {
								//CalculoPorPrioridad(value,_CellIndex);
					});
			}
				
			/*.............................................................................................*/
			function NewonBlur(){
				//NumericBox_IE_ParseAdd(this, ' ', ',', '.');
				if (EstadodeValorActual == true){ 
					EstadodeValorActual = false;
					var txtBoxEdit = jSIMA(this);
					if(txtBoxEdit.prop("idTipCol").toString().Equal("2")){
						txtBoxEdit.prop("tag",txtBoxEdit.val());
						ModificarItem(txtBoxEdit[0].parentNode.parentNode.rowIndex,txtBoxEdit[0].parentNode.cellIndex);
						__doPostBack('btnRefresh','');
						
					}
					else{
						txtBoxEdit.attr("value",txtBoxEdit.prop("tag"));
					}
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
						
						var objNBSiguiente =  this.rows[idxrow].cells[idxcellDerecha-1].children[0];
						jSIMA(objNBSiguiente).focus();
					}
					catch(error){}
				}
				
				e = event.srcElement||this;
				e=jNet.get(e);
				if(e.attr("idTipCol").toString().Equal("2")){
					e.attr('tag',e.attr('value'));
				}
				/*var idxrow = e.rowIndex;
				var idxcell = e.cellIndex;  */
				
				var idxrow = e.parentNode.parentNode.rowIndex;
				var idxcell = e.parentNode.cellIndex;  
				
				try{
					idxrowArriba = ((idxrow == NroRowIni)?NroRowIni:idxrow-1) ;  
					idxrowAbajo = ((idxrow == oDataGrid.rows.length-1)?NroRowIni:parseInt(idxrow)+1) ;  
					idxcellDerecha = 0;
					
					if(e.parentNode.cellIndex==NroMaxColumn){idxcellDerecha=1;}
					else{idxcellDerecha = e.parentNode.cellIndex+1;}
						
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
				jSIMA(".NumericBox").unbind("keypress");//Remueve el evento
				jSIMA(".NumericBox").unbind("blur");//Remueve el evento
				jSIMA(".NumericBox").blur(NewonBlur);
				jSIMA(".NumericBox").unbind("change");
				jSIMA(".NumericBox").change(CuandoCambiaValor);
				jSIMA(".NumericBox").unbind("keydown");
				jSIMA(".NumericBox").keydown(EnfocarSiguienteCelda);
			}
			
			function FormulaContable(e,IdColumna){
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
									+ KEYQPERIODO+ SignoIgual + KEYQPARAMETROS.PERIODO
									+ signoAmperson 
									+ KEYQIDCOLUMNA + SignoIgual + IdColumna ;
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
		onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0" Tag="Local">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD align="left"></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top" align="center">
						<TABLE id="Table3" border="0" cellSpacing="0" borderColorLight="#0" cellPadding="0">
							<TR>
								<TD colSpan="2" align="left">
									<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left">
										<TR>
											<TD style="BORDER-BOTTOM: #808080 1px dotted; PADDING-BOTTOM: 5px; HEIGHT: 20px"><asp:label id="Label1" runat="server">MES:</asp:label></TD>
											<TD style="BORDER-BOTTOM: #808080 1px dotted; PADDING-BOTTOM: 5px; HEIGHT: 20px" width="100%"><asp:dropdownlist style="Z-INDEX: 0" id="ddlMesSelect" runat="server" Width="150px">
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
									&nbsp;
								</TD>
							</TR>
							<TR>
								<TD><asp:label style="Z-INDEX: 0" id="lblDescripcion" runat="server">DESCRIPCION:</asp:label></TD>
								<TD><asp:image style="Z-INDEX: 0" id="ImgProcesar" runat="server" ImageUrl="/SimanetWeb/imagenes/Navegador/Ejecutar.png"></asp:image></TD>
							</TR>
							<TR>
								<TD colSpan="2" align="center"><asp:placeholder id="PlaceHGrid" runat="server"></asp:placeholder></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 32px" align="center"><IMG style="Z-INDEX: 0" id="ibtnUser" alt="" src="../../imagenes/Navegador/User.gif"
							width="30" height="30">
					</TD>
				</TR>
				<tr>
					<td style="DISPLAY: none" id="LstUser" align="center" runat="server"></td>
				</tr>
				<TR style="DISPLAY: none">
					<TD align="center">
						<TABLE id="tblAcciones" border="0" cellSpacing="2" cellPadding="1" width="300">
							<TBODY>
								<TR>
									<TD id="lblMesSeleccionado" class="headerDetalle">para ABRIL</TD>
								</TR>
								<!--<TR>
									<TD class="BaseItemInGrid"><asp:radiobutton id="R1" runat="server" GroupName="OPMes" Text="Importar y procesar formato"></asp:radiobutton></TD>
								</TR>-->
								<TR>
									<TD class="BaseItemInGrid"><asp:radiobutton id="R2" runat="server" Text="Procesar formato" GroupName="OPMes"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD class="BaseItemInGrid"><asp:radiobutton id="R3" runat="server" Text="Imprimir resumen" GroupName="OPMes"></asp:radiobutton></TD>
								</TR>
								<!--<TR>
									<TD class="BaseItemInGrid"><asp:radiobutton style="Z-INDEX: 0" id="R4" runat="server" GroupName="OPMes" Text="Imprimir detallado"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 20px" class="BaseItemInGrid"><asp:radiobutton style="Z-INDEX: 0" id="R5" runat="server" GroupName="OPMes" Text="Exportar a excel"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 0px" class="BaseItemInGrid"><asp:radiobutton style="Z-INDEX: 0" id="R6" runat="server" GroupName="OPMes" Text="Exportar a excel detallado"></asp:radiobutton></TD>
								</TR>-->
								<TR>
									<TD><INPUT style="WIDTH: 72px; HEIGHT: 22px" id="hOpSelected" value="0" size="6" type="hidden"
											name="hOpSelected" runat="server"></TD>
								</TR>
				</TR>
			</TABLE>
			<INPUT style="DISPLAY: none" id="txtDescripcion"><asp:label id="lblResultado" runat="server"></asp:label><INPUT style="WIDTH: 85px; HEIGHT: 22px" id="hidFilaSeleccionada" size="8" type="hidden"><INPUT style="WIDTH: 77px; HEIGHT: 22px" id="hNroNivel" size="7" type="hidden"><INPUT style="Z-INDEX: 0; WIDTH: 77px; HEIGHT: 22px" id="hNombreImgTrim" size="7" type="hidden"
				name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 77px; HEIGHT: 22px" id="hIdMes" value="0" size="7" type="hidden"
				name="Hidden1" runat="server">
			<asp:button style="Z-INDEX: 0" id="btnPrc" runat="server" Text="ProcesarReporte"></asp:button><asp:button style="Z-INDEX: 0" id="btnRefresh" runat="server" Text="Refresh"></asp:button><asp:button style="Z-INDEX: 0" id="btnExportaXLS" runat="server" Text="xls"></asp:button><asp:button id="cmdImportarSaldos1" runat="server" Text="Button"></asp:button><asp:button style="Z-INDEX: 0" id="btnResumenyDetalleXLS" runat="server" Text="xls"></asp:button><asp:button id="btnMostrarMes" runat="server" Width="116px" Text="MostrarMesSeleccionado"></asp:button></TD></TR></TBODY></TABLE>
			<script>
			
			jSIMA(document).ready(function() {
				
				//RestauraNodoSeleccionado();
				AsignarEventodeSalidayCambio();
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
