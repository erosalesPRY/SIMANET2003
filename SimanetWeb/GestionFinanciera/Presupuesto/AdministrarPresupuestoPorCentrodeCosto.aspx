<%@ Page language="c#" Codebehind="AdministrarPresupuestoPorCentrodeCosto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.AdministrarPresupuestoPorCentrodeCosto" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarEvaluacionGastosdeAdministracionCC</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<style>.opaco5Porc { FILTER: alpha(opacity=80); opacity: .8 }
	.Activo { FILTER: alpha(opacity=100); opacity: .10 }
	.FondoTablaMasterInactivo { FILTER: alpha(opacity=60); BACKGROUND: url(Imagenes/Skin1/Fondo1.jpg) left center; opacity: .6 }
	.FondoTablaMaster { BACKGROUND: url(Imagenes/Skin1/Fondo1.jpg) left center }
	.Buscar { BORDER-BOTTOM: #7b9ebd 1px solid; BORDER-LEFT: #7b9ebd 1px solid; PADDING-LEFT: 20px; WIDTH: 100%; FONT-FAMILY: Arial; BACKGROUND: url(simanetweb/imagenes/Filtro/imgBuscar.gif) white no-repeat 0px 1px; HEIGHT: 22px; COLOR: #333333; FONT-SIZE: 12px; BORDER-TOP: #7b9ebd 1px solid; BORDER-RIGHT: #7b9ebd 1px solid; PADDING-TOP: 3px }
	.FotoSeleccionada { BORDER-BOTTOM: #0000ff 1px solid; FILTER: alpha(opacity=30); BORDER-LEFT: #0000ff 1px solid; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; BORDER-TOP: #0000ff 1px solid; CURSOR: hand; BORDER-RIGHT: #0000ff 1px solid; opacity: .3 }
	.FotoNoSeleccionada { BORDER-BOTTOM: #0000ff 1px solid; BORDER-LEFT: #0000ff 1px solid; BACKGROUND-COLOR: lightsteelblue; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; BORDER-TOP: #0000ff 1px solid; CURSOR: hand; BORDER-RIGHT: #0000ff 1px solid }
		</style>
		<script>
			//Desplazamiento de las columnas de la grilla
			function ScrollColumnas(ModoDesplazo)
			{
				var oGridCtrl = document.all["grid"];
				var ohIdMes = document.all["hidMes"];
				var idMes = parseInt(ohIdMes.value);
				
				switch(ModoDesplazo)
				{
					case "Izquierda":
						if (idMes >=7)
						{
							NroColOcultar =  (idMes -6);
							for(var fila=0;fila<= oGridCtrl.rows.length-1;fila++)
							{
								oGridCtrl.rows[fila].cells(NroColOcultar).style.display="block";
								oGridCtrl.rows[fila].cells(idMes).style.display="none";
							}
							idMes = (parseInt(ohIdMes.value) -1);
							ohIdMes.value = idMes
						}
						break;
					case "Derecha":
							if (idMes<=11 && idMes>6)
							{
								idMes ++;
								NroColMostrar =  Math.abs(idMes -6);
								for(var fila=0;fila<= oGridCtrl.rows.length-1;fila++)
								{
									oGridCtrl.rows[fila].cells(idMes).style.display="block";
									oGridCtrl.rows[fila].cells(NroColMostrar).style.display="none";
								}
							}
							else if(idMes==6)
							{
								idMes++;
								for(var fila=0;fila<= oGridCtrl.rows.length-1;fila++)
								{
									oGridCtrl.rows[fila].cells(idMes).style.display="block";
									oGridCtrl.rows[fila].cells(1).style.display="none";
								}								
							}
							ohIdMes.value = idMes
						break;
				}
			}
		</script>
		<script>
				var PROCESO ="idProceso";//Indicador de Proceso 
				var KEYQTIPOPRESUPUESTO ="idtp";
				var KEYQIDCENTROOPERATIVO="idCentro";
				var NROCENTROOPERATIVO="Nrocop";
				var KEYQIDCENTROOPERATIVOP="idcop";//CentroOPerativo de la pagina de Procesos
				var KEYQCENTROOPERATIVONOMBRE = "NombreCentro";
				var KEYQIDGRUPOCC = "idGrpCC";
				var KEYQIDNROGRUPOCC = "idNroGrpCC";
				var KEYQNOMBREGRUPOCC = "NombreGrpCC";
				var KEYQIDCENTROCOSTO ="idCC";
				var KEYQIDNROCENTROCOSTO ="idNroCC";
				var KEYQPERIODO ="Periodo";
				var KEYQMES ="Mes";
				var KEYQCUENTA3DIG="Cta3Dig";
				var KEYQCUENTA5DIG="Cta5Dig";
				var KEYQMONTO="Monto";
				var KEYQNOMBRECUENTA ="NombreCuenta";
				
				var PrcTerminado=false;
				var e;
				var oNodoItem;
				
			function ObtenerDetalleaNiveldeCuenta5Dig()
			{
				//window.aler();
				PrcTerminado=false;
				//Datos del Objeto TreeviewList
				e = window.event.srcElement;//Objeto Imagen
				oNodoItem = new SIMA.Utilitario.Helper.General.Treeview.Nodo.Item();
				oNodoItem = e.getAttribute("oNodoItem");
				oDataGridFilaActual = oNodoItem.DataGridFila;
			
				//Se obtiene la relacion de cuentas contable a nivel de 5 dig;
				var PathApp = SIMA.Utilitario.Helper.General.ObtenerPathApp();
				oPagina= new SIMA.Utilitario.Helper.General.Pagina();
				
				var UrlPaginaProceso =PathApp + "/GestionFinanciera/Presupuesto/Procesar.aspx?"; 
				//var UrlDetalle =PathApp + "/GestionFinanciera/Presupuesto/ConsultarEvaluacionGastosdeAdministracionGrupoCC.aspx?"; 
				var Parametros;
				var strListaParametros;
				
				
				with (SIMA.Utilitario.Constantes.General.Caracter)
				{
					Parametros = PROCESO + SignoIgual.toString()+ SIMA.Utilitario.Constantes.General.ProcesoCallBack.FormulacionPrespuestalCentrosdeCostoDetalleCta5Dig.toString()
									+ signoAmperson.toString()
									+ KEYQTIPOPRESUPUESTO		+ SignoIgual.toString() + oPagina.Request.Params[KEYQTIPOPRESUPUESTO]
									+ signoAmperson.toString()
									+ KEYQIDCENTROOPERATIVOP	+ SignoIgual.toString() + oPagina.Request.Params[KEYQIDCENTROOPERATIVO]
									+ signoAmperson.toString()
									+ KEYQIDGRUPOCC				+ SignoIgual.toString() + oPagina.Request.Params[KEYQIDGRUPOCC]
									+ signoAmperson.toString()
									+ KEYQIDCENTROCOSTO			+ SignoIgual.toString() + oPagina.Request.Params[KEYQIDCENTROCOSTO]
									+ signoAmperson.toString()
									+ KEYQPERIODO				+ SignoIgual.toString() + oPagina.Request.Params[KEYQPERIODO]
									+ signoAmperson.toString()
									+ KEYQMES					+ SignoIgual.toString() + oPagina.Request.Params[KEYQMES]
									+ signoAmperson.toString()
									+ KEYQCUENTA3DIG			+ SignoIgual.toString() + oDataGridFilaActual.getAttribute("CuentaContable3Dig");
				}
				
				strListaParametros = SIMA.Utilitario.Constantes.General.ProcesoCallBack.FormulacionPrespuestalCentrosdeCostoDetalleCta5Dig.toString();
				/*Crea Una Instancia del Objeto PostBack*/
				oDataGrid = oNodoItem.DataGrid;
				oCallBack = new SIMA.Utilitario.Helper.General.CallBack();
				oCallBack.CargarDocumentoXML(UrlPaginaProceso + Parametros,strListaParametros,oDataGrid);
				
				MostrarDatosFormulacion();
				return "Cargado";
			}
			
			function MostrarDetalledeCuenta(){
				eImg = window.event.srcElement;
				otblNodo = eImg.parentElement.parentElement.parentElement;
				oFilaContenedora = otblNodo.parentElement.parentElement;
				
				oEvaluacionPartida5DigBE = new SIMA.EntidaddeNegocioBE.GestionFinanciera.Presupuesto.EvaluacionPartida5DigBE();
				oEvaluacionPartida5DigBE = oFilaContenedora.BaseBE;
				
				window.alert(oFilaContenedora.BaseBE);
				
				/*switch(oEvaluacionPartida5DigBE.CuentaContable.charAt(2)){
					case '1':
						DetallePorNaturalezaGastoMaterialesoServicios(oEvaluacionPartida5DigBE.CuentaContable);
						break;
					case '3':
						DetallePorNaturalezaGastoMaterialesoServicios(oEvaluacionPartida5DigBE.CuentaContable);
						break;
					case '5'://Relacion de servicios
						break;
				}*/
			}
			
			var idProcesoTmr;//Sirve para identificar el proceso para luego liquidarlo y no quede en memoria ejecutandose;
			function MostrarDatosFormulacion()
			{
				if (PrcTerminado==false){
					idProcesoTmr= setTimeout("MostrarDatosFormulacion();",50);
					window.status = PrcTerminado + "   " + oNodoItem.DataStatus;
				}
				else{
					ohtml = new SIMA.Utilitario.Helper.General.Html();
					clearInterval(idProcesoTmr);//Fuerza para terminar el proceso lanzado por el temporizador
					for(var i=0;i<= arrDataFormulacion.length-1;i++){
						oFormulacionPartida5DigBE = new SIMA.EntidaddeNegocioBE.GestionFinanciera.Presupuesto.FormulacionPartida5DigBE();
						oFormulacionPartida5DigBE = arrDataFormulacion.ObtenerEntidad(i);
						//Carga la Grilla con los elementos encontrados
						with(oFormulacionPartida5DigBE){
							var Dig = CuentaContable.toString().substr(2,1)
							oDataGridFilaNueva = SIMA.Utilitario.Helper.General.Treeview.Nodo.Adicionar(i,CuentaContable + " " + NombreCuenta,false,null,null,e);
							//oDataGridFilaNueva = SIMA.Utilitario.Helper.General.Treeview.Nodo.Adicionar(i,CuentaContable + " " + NombreCuenta,false,null,(((Dig=='2')||(Dig=='3'))? MostrarDetalledeCuenta:null),e);
							
							//oDataGridFilaNueva.setAttribute("CtaCtble",CuentaContable);
							oDataGridFilaNueva  = jNet.get(oDataGridFilaNueva);
							oDataGridFilaNueva.attr("CtaCtble",CuentaContable);
							oDataGridFilaNueva.attr("NombreCta",NombreCuenta);
							
							oDataGridFilaNueva.onmouseover = function(){
								CambiarColorPasarMouse(this, true);UbicarBtnScroll(this);
							}
							oDataGridFilaNueva.onclick =function(){
								
								jNet.get('hCtaCble5dig').value = this.attr("CtaCtble");
								
							}
							oNodoItem = ObtenerNodoItem(oDataGridFilaNueva);
							
							oDataGridFilaNueva.cells(1).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Enero,1));
							oDataGridFilaNueva.cells(1).align="right";
							oDataGridFilaNueva.cells(1).ondblclick=function(){VerDetalleItemPorMes(1,this.parentNode);}
							oDataGridFilaNueva.cells(2).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Febrero,2));
							oDataGridFilaNueva.cells(2).align="right";
							oDataGridFilaNueva.cells(2).ondblclick=function(){VerDetalleItemPorMes(2,this.parentNode);}
							oDataGridFilaNueva.cells(3).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Marzo,3));
							oDataGridFilaNueva.cells(3).align="right";
							oDataGridFilaNueva.cells(3).ondblclick=function(){VerDetalleItemPorMes(3,this.parentNode);}
							oDataGridFilaNueva.cells(4).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Abril,4));
							oDataGridFilaNueva.cells(4).ondblclick=function(){VerDetalleItemPorMes(4,this.parentNode);}
							oDataGridFilaNueva.cells(4).align="right";
							oDataGridFilaNueva.cells(5).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Mayo,5));
							oDataGridFilaNueva.cells(5).ondblclick=function(){VerDetalleItemPorMes(5,this.parentNode);}
							oDataGridFilaNueva.cells(5).align="right";
							oDataGridFilaNueva.cells(6).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Junio,6));
							oDataGridFilaNueva.cells(6).ondblclick=function(){VerDetalleItemPorMes(6,this.parentNode);}
							oDataGridFilaNueva.cells(6).align="right";
							oDataGridFilaNueva.cells(7).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Julio,7));
							oDataGridFilaNueva.cells(7).ondblclick=function(){VerDetalleItemPorMes(7,this.parentNode);}
							oDataGridFilaNueva.cells(7).align="right";
							oDataGridFilaNueva.cells(8).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Agosto,8));
							oDataGridFilaNueva.cells(8).ondblclick=function(){VerDetalleItemPorMes(8,this.parentNode);}
							oDataGridFilaNueva.cells(8).align="right";
							oDataGridFilaNueva.cells(9).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Setiembre,9));
							oDataGridFilaNueva.cells(9).ondblclick=function(){VerDetalleItemPorMes(9,this.parentNode);}
							oDataGridFilaNueva.cells(9).align="right";
							oDataGridFilaNueva.cells(10).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Octubre,10));
							oDataGridFilaNueva.cells(10).ondblclick=function(){VerDetalleItemPorMes(10,this.parentNode);}
							oDataGridFilaNueva.cells(10).align="right";
							oDataGridFilaNueva.cells(11).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Noviembre,11));
							oDataGridFilaNueva.cells(11).ondblclick=function(){VerDetalleItemPorMes(11,this.parentNode);}
							oDataGridFilaNueva.cells(11).align="right";
							oDataGridFilaNueva.cells(12).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Diciembre,12));
							oDataGridFilaNueva.cells(12).ondblclick=function(){VerDetalleItemPorMes(12,this.parentNode);}
							oDataGridFilaNueva.cells(12).align="right";
							oDataGridFilaNueva.cells(13).innerText = Total;
							oDataGridFilaNueva.cells(13).align="right";
							
						}
					}
					
					arrDataFormulacion.Remover();
					SIMA.Utilitario.Helper.General.Treeview.Nodo.Enumerar(oNodoItem.DataGrid);
					window.status = PrcTerminado;
				}
				oDataGrid = oNodoItem.DataGrid;
				oDataGrid.rows[oDataGrid.rows.length-1].className = "HeaderGrilla";
				
				ohtml = new SIMA.Utilitario.Helper.General.Html();
			}
			
			
			function VerDetalleItemPorMes(idMes,RowHtml){
				var oRow = jNet.get(RowHtml);
				var CuentaContable = oRow.attr("CtaCtble");
				var NombreCuenta = oRow.attr("NombreCta");
				
				var KEYQIDNROCENTROCOSTO ="idNroCC";//Recibe de lapagina de tabs seleccionado
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var URLPAGINA = "AdministrarPresupuestoItemDetallePorCC.aspx?"; 
				with(SIMA.Utilitario.Constantes){
					var URL = URLPAGINA + GestionFinanciera.PaginaQueryParam.KEYQPERIODO + General.Caracter.SignoIgual + oPagina.Request.Params[GestionFinanciera.PaginaQueryParam.KEYQPERIODO]
														+ General.Caracter.signoAmperson
														+ GestionFinanciera.PaginaQueryParam.KEYQIDMES + General.Caracter.SignoIgual + idMes
														+ General.Caracter.signoAmperson
														+ GestionFinanciera.PaginaQueryParam.KEYQNROGRPCC + General.Caracter.SignoIgual + oPagina.Request.Params[KEYQIDNROGRUPOCC]
														+ General.Caracter.signoAmperson
														+ GestionFinanciera.PaginaQueryParam.KEYQIDGRPCC + General.Caracter.SignoIgual + oPagina.Request.Params[KEYQIDGRUPOCC]
														+ General.Caracter.signoAmperson
														+ GestionFinanciera.PaginaQueryParam.KEYQNROCC + General.Caracter.SignoIgual + oPagina.Request.Params[KEYQIDNROCENTROCOSTO]
														+ General.Caracter.signoAmperson
														+ GestionFinanciera.PaginaQueryParam.KEYQIDCC  + General.Caracter.SignoIgual + oPagina.Request.Params[KEYQIDCENTROCOSTO]
														+ General.Caracter.signoAmperson
														+ GestionFinanciera.PaginaQueryParam.KEYQNROCEOPE + General.Caracter.SignoIgual + oPagina.Request.Params[NROCENTROOPERATIVO]
														+ General.Caracter.signoAmperson
														+ GestionFinanciera.PaginaQueryParam.KEYQIDCEOPE + General.Caracter.SignoIgual + oPagina.Request.Params[KEYQIDCENTROOPERATIVO]
														+ General.Caracter.signoAmperson
														+ GestionFinanciera.PaginaQueryParam.KEYQCUENTACONTABLE + General.Caracter.SignoIgual + CuentaContable
														+ General.Caracter.signoAmperson
														+ KEYQNOMBRECUENTA + General.Caracter.SignoIgual + NombreCuenta;
														
					oPagina.Response.ShowDialogoModal(URL,750,300,window);
					document.location.reload();
				}									
			}
			
			
			function CrearInputPorMes(oNodoItem,CuentaContable,Monto,NroCol){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				if((parseInt(oPagina.Request.Params[SIMA.Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQPERIODO],10)>2010)&& (CuentaContable.toString().substr(2,1).Equal('5')||CuentaContable.toString().substr(2,1).Equal('1')||CuentaContable.toString().substr(2,1).Equal('3'))){
					return document.createTextNode(Monto);
				}
				else{
					ohtml = new SIMA.Utilitario.Helper.General.Html();
					//Lista de Columnas por Mes
					otxtNumero = new ohtml.CrearInputNumerico();
					otxtNumero.id = "Txt_" + oNodoItem.IdNivel + "_" + NroCol;
					otxtNumero.onkeydown=MoverPuntero;
					otxtNumero.className = "normaldetalle";
					otxtNumero.style.width = "100%";
					otxtNumero.maxlength="12";
					otxtNumero.className ="normalCelda";
					otxtNumero.style.align="left";
					otxtNumero.Tag = NroCol;
					otxtNumero.ColMes = NroCol;
					otxtNumero.ColumnaInicial=1;
					otxtNumero.ColumnaFinal=12;
					
					otxtNumero.ViejoValor = Monto;
					otxtNumero.Cuenta5Dig = CuentaContable;
					//otxtNumero.value =FormatNumber(Monto, 2, true,true, true);
					otxtNumero.value =Monto;
					otxtNumero.style.background ="Transparent";
					otxtNumero.style.border ="none";
					return 	otxtNumero;
				}
			}
			
			function MoverPuntero(){
				if (event.keyCode == 13){
					if (this.style.border !=""){
						if (this.value != this.ViejoValor){
							var PathApp = SIMA.Utilitario.Helper.General.ObtenerPathApp();
							oPagina= new SIMA.Utilitario.Helper.General.Pagina();

							//Nueva implementacion
							var oSaldoContableBE = new EntidadesNegocio.Presupuesto.SaldoContableBE(); 
							oSaldoContableBE.Periodo = oPagina.Request.Params[KEYQPERIODO];
							oSaldoContableBE.idMes = this.ColMes;
							oSaldoContableBE.CuentaContable =  this.Cuenta5Dig;
							oSaldoContableBE.idCentroOperativo = oPagina.Request.Params[KEYQIDCENTROOPERATIVO];
							oSaldoContableBE.NroCentroOperativo = oPagina.Request.Params[NROCENTROOPERATIVO];
							oSaldoContableBE.idGrupoCentroCosto = oPagina.Request.Params[KEYQIDGRUPOCC];
							oSaldoContableBE.NroGrupoCentroCosto = oPagina.Request.Params[KEYQIDNROGRUPOCC];
							oSaldoContableBE.idCentroCosto = oPagina.Request.Params[KEYQIDCENTROCOSTO];
							oSaldoContableBE.NroCentroCosto = oPagina.Request.Params[KEYQIDNROCENTROCOSTO];
							oSaldoContableBE.MontoPresupuesto = this.value;
							
							var str = (new Controladora.Presupuesto.CSaldoContable()).InsertarModificar(oSaldoContableBE);
							TotalizarRubro(this.parentNode.parentNode,str.split(';'),this.ColMes);
							//Realiza la totalizacion del rubro padre
							this.ViejoValor=this.value;
							this.style.border ="none";
							this.select();
						}
					}
					else{
						if (this.NroColumnaSiguiente>=6){document.all["btnMostrarDer"].onclick();}
						objCell = this.DataGrid.rows[this.NroFilaActual].cells(this.NroColumnaSiguiente);//Despalza el Scroll hacia la derecha
						objCell.children[0].focus();
					}
				}
				//Flecha Arriba
				else if (event.keyCode == 38){
					if (this.style.border ==""){
						try{
						objCell = this.DataGrid.rows[this.NroFilaAnterior].cells(this.ColMes);
						objCell.children[0].focus();
						}
						catch(e){return true;}
					}
				}
				//Flecha a la derecha
				else if (event.keyCode == 39){
					if (this.style.border ==""){
						this.NroColumnaSiguiente=(this.NroColumnaSiguiente==0)?12:this.NroColumnaSiguiente;
						try{
							if (this.NroColumnaSiguiente>=6 && this.NroColumnaSiguiente<=11){document.all["btnMostrarDer"].onclick();}
							objCell = this.DataGrid.rows[this.NroFilaActual].cells(this.NroColumnaSiguiente);
							objCell.children[0].focus();
						}
						catch(e){return true;}

					}
				}
				//Flecha Abajo
				else if (event.keyCode == 40){
					if (this.style.border ==""){
						try{
							objCell = this.DataGrid.rows[this.NroFilaSiguente].cells(this.ColMes);
							objCell.children[0].focus();
						}
						catch(e)
						{return true;}
					}
				}
				//FechaIzquierda	
				else if(event.keyCode == 37){
						this.NroColumnaAnterior=(this.NroColumnaAnterior==0)?1:this.NroColumnaAnterior;
						try{
							if (this.NroColumnaActual<=7){document.all["btnMostrarIzq"].onclick();}
							objCell = this.DataGrid.rows[this.NroFilaActual].cells(this.NroColumnaAnterior);
							objCell.children[0].focus();
						}
						catch(e)
						{return true;}
				}
				else if (event.keyCode == 113)//Esta Tecla permite la edicion dela celda
				{
					objTxt = document.all[this.id];
					objTxt.style.border ="1.5pt inset";
					objTxt.focus();
				}
				else if (event.keyCode == 27)//la Tecla Escape
				{
					this.value = this.ViejoValor;
					this.select();
				}
				else{
					if (window.event.keyCode <= 12 || ((window.event.keyCode >= 48 && window.event.keyCode <= 57)|| (window.event.keyCode==46) || (window.event.keyCode>=96 && window.event.keyCode <=105) )){
						this.style.border ="1.5pt inset";
					}
					return (window.event.keyCode <= 12 || ((window.event.keyCode >= 48 && window.event.keyCode <= 57)|| (window.event.keyCode==46) || (window.event.keyCode>=96 && window.event.keyCode <=105) ));
				}
			}
			/*--------------------------------------------------------------*/
			/*--------------------------------------------------------------*/
			function ObtenerNodoItem(oFilaActual)//Es utilizado para obtener informacion de nodo para luego crear los txtbox 
			{
					otblNodoRaiz = oFilaActual.cells[0].children[0];
					NroColPenultima = (otblNodoRaiz.rows[0].cells.length-2);
					oimg = otblNodoRaiz.rows[0].cells(NroColPenultima).children[0];
					oNodoItem = oimg.getAttribute("oNodoItem");
					return oNodoItem;
			}
			
			/*--------------------------------------------------------------*/
			/*--------------------------------------------------------------*/
			function ObtenerIdFilaNodoPrincipal(oNodoItemPadre){
				oDataGrid = oNodoItemPadre.DataGrid;
				idNivelNodoBuscar = oNodoItemPadre.IdNivel;
				for(var i=1;i<=oDataGrid.rows.length-1;i++){
					oFila = oDataGrid.rows[i];
					if (oFila.IdNivel.substring(0,idNivelNodoBuscar.length) == idNivelNodoBuscar){
						return i;
					}
				}
			}			
			/*--------------------------------------------------------------*/
			/* Totalizar Rubro		es invocado desde el proceso callBack	*/
			/*--------------------------------------------------------------*/
			function TotalizarRubro(oFilaActual,ArrMonto,NroColumna){
				oNodoItem = ObtenerNodoItem(oFilaActual);
				oNodoItemPadre = oNodoItem.NodoPadre;
				oDataGrid = oNodoItem.DataGrid;
				idFilaResumen = ObtenerIdFilaNodoPrincipal(oNodoItemPadre);
				idFilaActual = ObtenerIdFilaNodoPrincipal(oNodoItem);
				
				oDataGrid.rows[parseInt(idFilaResumen)].cells(parseInt(NroColumna)).innerText = ArrMonto[0];
				oDataGrid.rows[parseInt(idFilaResumen)].cells(13).innerText = ArrMonto[1];
				oDataGrid.rows[parseInt(idFilaActual)].cells(13).innerText = ArrMonto[2];
			}
			/*--------------------------------------------------------------*/
			/*--------------------------------------------------------------*/
			
			
			/*Utilizados en los procesos remotos CALLBACK*/	
			var arrDataFormulacion = new Array();
			arrDataFormulacion.CargarDatos= function(oFormulacionPartida5DigBE,Estado){
				if (Estado==false){
					this[this.length] = new Array();
					this[this.length-1] = oFormulacionPartida5DigBE;
				}
				PrcTerminado = Estado
			}
			arrDataFormulacion.ObtenerEntidad = function(Indice){
				return this[Indice];
			}
			
			
			arrDataFormulacion.Remover = function(){
				try{
					Long = this.length-1;
					for (var i=0;i<=Long;i++){this.pop();} 
				}
				catch(error){}
			}

			

			var SCROLL = new Object();
			
			SCROLL.Horizontal = function(){
				this.CrearBotones=function(){
					var Ancho =10;
					ohtml = new SIMA.Utilitario.Helper.General.Html();
					var oDataGrid = document.all["grid"];
					var posObjLef = ohtml.BuscarPocisionOBJ(oDataGrid.rows[0].cells[2]);
					posObjLef[0] = (oDataGrid.rows[0].cells[0].offsetWidth-(Ancho+10));
					
					var posObjRight = ohtml.BuscarPocisionOBJ(oDataGrid.rows[0].cells(oDataGrid.rows[0].cells.length-1));
					var ofila = oDataGrid.rows[2];
					var tblScrollIzqueirda ;
					var btnImgIzq;
					var btnImgDer;
					
					btnImgIzq = document.all["btnMostrarIzq"];
					btnImgIzq.style.position="absolute";
					btnImgIzq.style.left = (posObjLef[0]) + "px";
					
					//Imagen Derecha
					btnImgDer = document.all["btnMostrarDer"];
					btnImgDer.style.position="absolute";
					btnImgDer.style.left = (posObjRight[0]) + "px";
				}
			}
			
			function UbicarBtnScroll(e){
			
				ohtml = new SIMA.Utilitario.Helper.General.Html();
				var posObj = ohtml.BuscarPocisionOBJ(e);
				var oibtnIzq =  document.getElementById("btnMostrarIzq");
				oibtnIzq.style.display="block";
				oibtnIzq.style.top = posObj[1] + "px";
				oibtnIzq.style.zIndex =100;
				//Derecha
				var oibtnDer = document.getElementById("btnMostrarDer");
				oibtnDer.style.display="block";
				oibtnDer.style.top = posObj[1] + "px";
				oibtnDer.style.zIndex =100;
				
			}
			
			function AsignarEventoGrid(){
				var oDataGrid = document.all["grid"];
				oDataGrid.onresize = function(){
					(new SCROLL.Horizontal()).CrearBotones();
				}
			}
			
				
		</script>
		<script>
		
		/*******************************************************************************************************************************************/
/*Array de Datos de Personal*/			
/*******************************************************************************************************************************************/
			var arrDataPersonal = new Array();
			arrDataPersonal.ArrTmpBase= new Array();
			arrDataPersonal.ArrFiltrado= new Array();
			arrDataPersonal.ColumnaMatriz = 5;
			
			arrDataPersonal.IncreDecre = 0;
			arrDataPersonal.PosicionUltimoElemento=0;
			
			arrDataPersonal.NroCtrlImagen =0;
			arrDataPersonal.PathFotos="";
			arrDataPersonal.Extension= ".JPG";
			arrDataPersonal.idtblLista ="tblLstPersonal";
			
			arrDataPersonal.otblImg;
			arrDataPersonal.objtblToolBar;
			arrDataPersonal.Iniciar = function(){
				try{
					arrDataPersonal.IncreDecre=0;
					arrDataPersonal.PosicionUltimoElemento=0;
					this.objtblToolBar=document.all["tblToolMaster"];
					ohData = document.all["hListadePersonal"];
					this.ObtenerDatos(ohData.value);
					this.CrearCtrlImagen();
				}
				catch(e){}
			}
			
			arrDataPersonal.ObtenerDatos=function(ostrData){
				this.PathFotos = document.all["hPathFotos"].value;
				var PatronRegistro = "[@]";
				var PatronCampo="||";
				oDataTable = ostrData.toString().split(PatronRegistro);
				oDataTable.pop(oDataTable.length);
				
				for(var i=0;i<= oDataTable.length-1;i++){
					oArrRegistro = oDataTable[i].split(PatronCampo);
					var oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
					with(oPersonalBE)
					{
						Identificador = i;
						idPersonal = oArrRegistro[0];
						NroPersonal = oArrRegistro[1];
						ApellidosyNombres = oArrRegistro[2];
						Especialidad = oArrRegistro[3];
						DNI = oArrRegistro[4];
					}
					this[this.length] = new Array();
					this[this.length-1] = oPersonalBE;
					/*Realiza unBackup del Array para luego ser restaurado*/
					this.ArrTmpBase[this.ArrTmpBase.length]= new Array();
					this.ArrTmpBase[this.ArrTmpBase.length-1] = oPersonalBE;
				}
			}
			arrDataPersonal.CrearCtrlImagen= function(){
				var AnchoBase=40;
				var AltoBase =41;
				var NroColumnas=0;
				this.NroCtrlImagen =0;
				try{
					var oimgList = document.all[this.idtblLista];
					this.objtblToolBar.rows[0].cells(this.ColumnaMatriz).removeChild(oimgList);
				}
				catch(e){}
				oPanel = this.objtblToolBar.rows[0].cells(this.ColumnaMatriz);//Esta es la celda en donde se ubicaran los objs de imagenes
				NroColumnas = Math.floor((oPanel.offsetWidth-150) /AnchoBase);
				//NroColumnas = (NroColumnas-1); //Nro de Imagenes a Mostrar
				this.NroCtrlImagen = ((parseInt(NroColumnas)>= (this.length))? (this.length):NroColumnas);
				
				oHtml = new SIMA.Utilitario.Helper.General.Html();
				otblImg = oHtml.CrearTabla(1,this.NroCtrlImagen);
				otblImg.setAttribute("UNSELECTABLE","on");
				otblImg.id=this.idtblLista;
				otblImg.border=0;
				otblImg.cellPadding=1;
				otblImg.cellSpacing=1;
				//otblImg.border = "1px ##999999 solid";
				otblImg.deleteRow(1);//Elimina una fila de mas creada  por error del metodo creartabla 
				for(var i=0;i<=this.NroCtrlImagen-1;i++){
					oimg = oHtml.CrearImagen();
					oimg.id = "img" + i;
					oimg.src = this.PathFotos + "sinfoto" + this.Extension;
					oimg.style.width = AnchoBase + "px";
					oimg.style.height = AltoBase + "px";
					oimg.hspace=1;oimg.vspace=1;
					oimg.style.border = "1px #ffffff solid";
					//otblImg.rows[0].cells(i).style.paddingLeft="8px";
					otblImg.rows[0].cells(i).style.border = "1px  DimGray solid";
					otblImg.rows[0].cells(i).appendChild(oimg);
				}
				oPanel.appendChild(otblImg);
				
				//Carga los primeros elementos de personal a la lista
				this.DesplazarImagenes(0);
				/*Nro de Persona*/
				var oLbl = document.all["Label2"];
				oLbl.innerText = "Total de Personas: (" + this.NroCtrlImagen.toString() +  " de " + this.ArrTmpBase.length.toString() + ")";
				oLbl.noWrap = false;
				if (this.ArrTmpBase.length==0){oPanel.innerText="<No existen registros de personal para este centro de costo>";}
			}

		function EfectoReflejo(oImgBase,Left,Top){
			var oHtml = new SIMA.Utilitario.Helper.General.Html();
			var Posicion= arrDataPersonal.BuscarPocision(oImgBase);
			var objImg;
			objImg =document.all["Clon" + oImgBase.id];
			if (objImg==undefined){
				objImg = oHtml.CrearImagen();
				objImg.id = "Clon" + oImgBase.id;
			}
				
				objImg.style.position="absolute";
				objImg.src=oImgBase.src;
				objImg.style.left = Posicion[0]-1;//
				objImg.style.top =  Posicion[1]+ 55 ;//oImgBase.style.top;
				objImg.style.height= oImgBase.style.height;
				objImg.style.width= (parseInt(oImgBase.style.width.toString().replace("px","")) + 3) + "px";
				objImg.style.border = "1px gray solid";
				objImg.hspace=1;objImg.vspace=1;
				objImg.style.filter="alpha(style=1, opacity=0, finishOpacity=50, startX=0, startY=10, finishX=0, finishY=80) flipH() flipV()";
				document.body.appendChild(objImg);
				
		}
			
			
			arrDataPersonal.DesplazarImagenes=function(Posicion){
				var otblImg = document.all[this.idtblLista];
				for(var i=0;i<=this.NroCtrlImagen-1;i++){
					oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
					oPersonalBE = this[i];
					var oimg = otblImg.rows[0].cells(i).children[0];
					oimg.onerror= function(event){
										this.src = SIMA.Utilitario.Constantes.ImgDefault;
									};
					oimg.src = this.PathFotos + oPersonalBE.DNI + this.Extension;
					oimg.Tag = oPersonalBE;
					oimg.className="FotoNoSeleccionada";
					this.PosicionUltimoElemento =  oPersonalBE.Identificador;
					
					EfectoReflejo(oimg);
					
					oimg.onclick = function(){
						otblMaster = document.all["Table3"];
						otblMaster.className="FondoTablaMasterInactivo";
						oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
						oPersonalBE = this.Tag;
						var URLDETALLEPERSONAL = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/Personal/DetallePersonal.aspx?";
						var KEYQLLAMADA = "QuienLLama";
						var KEYQID        = "IDCO";
						oPagina = new SIMA.Utilitario.Helper.General.Pagina();
						
						with (SIMA.Utilitario.Constantes.General.Caracter){
							var Parametros =  KEYQLLAMADA + SignoIgual.toString() + "ESTADOSFINANCIEROS" + signoAmperson.toString() + KEYQID + SignoIgual.toString() + oPersonalBE.NroPersonal;
							}
						/*Metodos Esternos*/
						//PopupDeEspera();
						(new SIMA.Grafico.Imagen.Efecto()).Click(this,50,true);
						HistorialIrAdelantePersonalizado("txtBuscar");
						/**/
						oPagina.Response.Redirect(URLDETALLEPERSONAL + Parametros);
					}
					oimg.oncopy=function(){
						return false;
					}
					oimg.oncontextmenu=function(){
						return false;
					}
					oimg.onmouseout = function(){
						this.className="FotoNoSeleccionada";
						var objtblDatos = document.all["tblDatos"];
						objtblDatos.style.display="none";
						var odivMonitor = document.all["divMonitor"];
						odivMonitor.style.display="none";						
					}
					oimg.onmouseover = function(){
						
						
					
						this.className="FotoSeleccionada";
						var odivMonitor = document.all["divMonitor"];
						odivMonitor.style.display="block";
						odivMonitor.style.width = eval(this.width+3)+"px";
						odivMonitor.style.height = eval(this.height+2)+"px";
						 var arrPos= arrDataPersonal.BuscarPocision(this);
						 odivMonitor.style.left =  (arrPos[0] + 2)+ "px";
						 odivMonitor.style.top =  (arrPos[1] + 2) + "px";
						 
						 /*Perfil y Datos*/
						 var objtblDatos = document.all["tblDatos"];
						 objtblDatos.style.display="block";
						 objtblDatos.style.left =  ((arrPos[0]/2)+ (parseInt(objtblDatos.style.width.replace("px"))/2))  + "px";
						 objtblDatos.style.top = (arrPos[1] - parseInt(objtblDatos.style.height.replace("px")))+ "px";						 
						 /**/
						 var oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
						 oPersonalBE = this.Tag;
						 /**/
						 var oimgPersonal = document.all["imgPersonal"];
						 oimgPersonal.src = this.src;
						 var olblApellidosyNombres = document.all["lblApellidosyNombres"];
						 var olblEspecilidad = document.all["LblEspecilidad"];
						 var otxtBuscar = document.all["txtBuscar"];
						 var valor =oPersonalBE.ApellidosyNombres.toString().substring(0,29);
						 var newHTML = valor.replace(otxtBuscar.value.toUpperCase(),"<a style='BORDER-RIGHT: #0000ff 1px solid; BORDER-TOP: #0000ff 1px solid; BORDER-LEFT: #0000ff 1px solid; BORDER-BOTTOM: #0000ff 1px solid; BACKGROUND-COLOR: lightsteelblue; FONT-WEIGHT: bold; COLOR: mediumblue; TEXT-DECORATION: underline'>" + otxtBuscar.value.toUpperCase() + "</a>")  + "...";
						 olblApellidosyNombres.innerHTML= newHTML;
						 olblEspecilidad.innerText = oPersonalBE.Especialidad.toString();
						 
					}
				}
			}
			
			
			
			arrDataPersonal.BuscarPocision = function (obj) {
				var curleft = curtop = 0;
				if (obj.offsetParent) {
					curleft = obj.offsetLeft;curtop = obj.offsetTop;
					while (obj = obj.offsetParent) {
						curleft += obj.offsetLeft;curtop += obj.offsetTop;
					}
				}
				return [curleft,curtop];
			}
			/*Navega */
			arrDataPersonal.Siguiente = function(){
				var otblImg = document.all[this.idtblLista];
				arrDataPersonal.IncreDecre ++;
				this.IncreDecre = (((this.PosicionUltimoElemento+1) == (this.length))? (this.IncreDecre-1):this.IncreDecre);
				for(var i=0;i<=this.NroCtrlImagen-1;i++)
				{
					var oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
					oPersonalBE = this[arrDataPersonal.IncreDecre + i];					
					this.PosicionUltimoElemento = oPersonalBE.Identificador;
					
					var oimg = otblImg.rows[0].cells(i).children[0];
					oimg.src = this.PathFotos + oPersonalBE.NroPersonal + this.Extension;
					oimg.Tag = oPersonalBE;
					oimg.className="FotoSeleccionada";			
					/*Imagenes efecto de reflejo*/
					var oimgEfe = document.all["Clon" +oimg.id];
					oimgEfe.src = oimg.src;
					setTimeout("arrDataPersonal.EfectoFade('" + ((this.NroCtrlImagen-1)- i) + "')",500);
				}
			}
			arrDataPersonal.Anterior = function(){
				var otblImg = document.all[this.idtblLista];
				arrDataPersonal.IncreDecre --;
				this.IncreDecre = ((arrDataPersonal.IncreDecre > 0)? (this.IncreDecre):0);
				for(var i=0;i<=this.NroCtrlImagen-1;i++){
					var oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
					oPersonalBE = this[arrDataPersonal.IncreDecre + i];					
					this.PosicionUltimoElemento = oPersonalBE.Identificador;
					var oimg = otblImg.rows[0].cells(i).children[0];
					oimg.src = this.PathFotos + oPersonalBE.NroPersonal + this.Extension;
					oimg.Tag = oPersonalBE;
					oimg.className="FotoSeleccionada";
					/*Imagenes efecto de reflejo*/
					var oimgEfe = document.all["Clon" +oimg.id];
					oimgEfe.src = oimg.src;					
					setTimeout("arrDataPersonal.EfectoFade('" + i + "')",500);
				}
			}
			arrDataPersonal.EfectoFade=function(idx){
				var otblImg = document.all[this.idtblLista];
				otblImg.rows[0].cells(parseInt(idx)).children[0].className="opaco5Porc";
			}
			
			arrDataPersonal.Buscar=function(e){
				//Atras Borrar 8 //	window.alert(event.keyCode);
				var odivMonitor = document.all["divMonitor"];
				odivMonitor.style.display="none";
				if (e.value.length >0){
					if (event.keyCode==8)//BackDelete
					{
						this.ArrFiltrado.Truncate();
						this.RemoverEfecto();
						this.Reestablecer();
						this.CrearCtrlImagen();
						
					}
					for(var i=0;i<=this.length-1;i++){
						var oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
						oPersonalBE = this[i];
						var Nombres = oPersonalBE.ApellidosyNombres.toString();
						if ((parseInt(Nombres.toUpperCase().indexOf(e.value.toUpperCase()))!=-1)&& (this.ArrFiltrado.Buscar(Nombres)==false)){
							this.ArrFiltrado[this.ArrFiltrado.length] = new Array();
							this.ArrFiltrado[this.ArrFiltrado.length-1] = oPersonalBE;
						}
					}
					this.RepintarImagenes();
				}
				else				
				{
					this.ArrFiltrado.Truncate();
					this.RemoverEfecto();
					this.Reestablecer();
					this.CrearCtrlImagen();
				}
			}
			
			arrDataPersonal.RepintarImagenes = function(){
				var oimgList = document.all[this.idtblLista];
				this.RemoverEfecto();//Remueve las Imagenes que poseen el efecto de reflejo
				this.objtblToolBar.rows[0].cells(this.ColumnaMatriz).removeChild(oimgList);
				//Elimina todos los Registro
				this.Refrescar();
				this.CrearCtrlImagen();
				this.ArrFiltrado.Truncate();
			}
			arrDataPersonal.RemoverEfecto=function(){
				var oimgList = document.all[this.idtblLista];
				for(var c=0;c<=oimgList.rows[0].cells.length-1;c++){
					var NombreImg = oimgList.rows[0].cells(c).children[0].id;
					var oimg = document.all["Clon" + NombreImg];
					document.body.removeChild(oimg);//Elimina las Imagenes de Reflejo
				}
			}
			
			arrDataPersonal.Truncate = function(){
				try{
					var Long = this.length-1;
					for(e=0;e<=Long;e++){this.pop();}
				}
				catch(e){}
			}
			
			arrDataPersonal.Refrescar= function(){
				this.Truncate();
				for(e=0;e<=this.ArrFiltrado.length-1;e++){
					var oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
					oPersonalBE = this.ArrFiltrado[e];
					oPersonalBE.Identificador = e;
					this[this.length] = new Array();
					this[this.length-1]=oPersonalBE;
				}
			}
			
			arrDataPersonal.Reestablecer= function(){
				var oimgList = document.all[this.idtblLista];
				this.objtblToolBar.rows[0].cells(this.ColumnaMatriz).removeChild(oimgList);			
				this.Truncate();
				for(e=0;e<=this.ArrTmpBase.length-1;e++){
					this[this.length] = new Array();
					this[this.length-1]=this.ArrTmpBase[e];
				}
			}
			
			/*Busca en el arrar Filtrado */
			arrDataPersonal.ArrFiltrado.Buscar= function(valor){
				for(var b=0;b<=arrDataPersonal.ArrFiltrado.length-1;b++){
					var oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
					oPersonalBE = arrDataPersonal.ArrFiltrado[b];
					var strNombres = oPersonalBE.ApellidosyNombres.toString();
					if (strNombres.toUpperCase() == valor.toString().toUpperCase()){return true;}
				}
				return false;
			}
			arrDataPersonal.ArrFiltrado.Truncate = function(){
				try{
					var Long = arrDataPersonal.ArrFiltrado.length-1;
					for(e=0;e<=Long;e++){arrDataPersonal.ArrFiltrado.pop();}
				}
				catch(e){}
			}
		/*Para mostrar u Ocultar la Lista de Personar del Centro de costos*/

			function MostraryOcultarListadePersonal(){
				var otblContenedor = document.all["CellContenedor"];
				var Mostrar = "";
				var olblMostrar = document.all["lblMostrar"];
				if (olblMostrar.innerText=='Mostrar Relación de Personal'){
					olblMostrar.innerText='Ocultar Relación de Personal';
					Mostrar="block";
				}
				else{
					olblMostrar.innerText='Mostrar Relación de Personal';
					Mostrar="none";
				}
				 MostrarOcultar(otblContenedor,Mostrar);
			}
			function MostrarOcultar(objContenedor,Display){
				for(var i=0;i<=objContenedor.children.length-1;i++){
					var objChild = objContenedor.children[i];
					objChild.style.display = Display;
					try{
						if(objChild.id.substring(0,3)=="img"){
							var objImgReflejo = document.all["Clon" + objChild.id];
							objImgReflejo.style.display = Display;
						}
					}
					catch(e){}
					MostrarOcultar(objChild,Display);
				}
			}
		</script>
	</HEAD>
	<body onresize="arrDataPersonal.Buscar(document.all['txtBuscar']);" onunload="SubirHistorial();"
		onload="AsignarEventoGrid();MostraryOcultarListadePersonal();try{arrDataPersonal.Iniciar();ObtenerHistorial();}catch(e){}"
		bottomMargin="0" leftMargin="0" topMargin="0" bgColor="#dcdcdc" onkeypress="if (event.keyCode==13)return false">
		<form style="Z-INDEX: 0" id="Form1" method="post" runat="server">
			<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD class="commands"><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Inicio> Gestión Financiera> Prespuesto> Administración Presupuestal por Centro de Costo</asp:label></TD>
				</TR>
				<TR>
					<TD class="commands" align="right"></TD>
				</TR>
				<TR>
					<TD align="left"><cc1:datagridweb id="grid" runat="server" PageSize="7" AllowSorting="True" AutoGenerateColumns="False"
							RowHighlightColor="#E0E0E0" Width="100%" ShowFooter="True">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="HeaderGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="NombreCuenta" HeaderText="NATURALEZA DE GASTO">
									<HeaderStyle Width="35%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Enero" HeaderText="ENERO">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Febrero" HeaderText="FEBRERO">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Marzo" HeaderText="MARZO">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Abril" HeaderText="ABRIL">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Mayo" HeaderText="MAYO">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Junio" HeaderText="JUNIO">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Julio" HeaderText="JULIO">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Agosto" HeaderText="AGOSTO">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Setiembre" HeaderText="SETIEMBRE">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Octubre" HeaderText="OCTUBRE">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Noviembre" HeaderText="NOVIEMBRE">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Diciembre" HeaderText="DICIEMBRE">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Total" HeaderText="TOTAL">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD width="100%" align="center">
						<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
							<TR>
								<TD width="45%"><INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hidMes" size="1" type="hidden" runat="server">&nbsp;<IMG style="DISPLAY: none" id="btnMostrarIzq" onmouseup="this.src ='../../imagenes/Navegador/ibtnAnterior.gif';"
										onmouseover="this.src ='../../imagenes/Navegador/ibtnAnterior.gif'" onmouseout="this.src='../../imagenes/Navegador/ibtnAnterior.gif';" onmousedown="this.src ='../../imagenes/Navegador/ibtnAnteriorPress.gif';"
										onclick="ScrollColumnas('Izquierda');" name="btnQuitar" src="../../imagenes/Navegador/ibtnAnterior.gif"><IMG style="DISPLAY: none" id="btnMostrarDer" onmouseup="this.src ='../../imagenes/Navegador/ibtnSiguiente.gif';"
										onmouseover="this.src ='../../imagenes/Navegador/ibtnSiguiente.gif'" onmouseout="this.src='../../imagenes/Navegador/ibtnSiguiente.gif';" onmousedown="this.src ='../../imagenes/Navegador/ibtnSiguientePress.gif';"
										onclick="this.src ='../../imagenes/Navegador/ibtnSiguientePress.gif';ScrollColumnas('Derecha');" src="../../imagenes/Navegador/ibtnSiguiente.gif">
									<INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hidCuentaCG" size="1" type="hidden"
										name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hCuentaContable" size="1" type="hidden"
										name="Hidden1" runat="server"> <INPUT style="Z-INDEX: 0; WIDTH: 138px; HEIGHT: 22px" id="hListadePersonal" size="17" type="hidden"
										name="hListadePersonal" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 138px; HEIGHT: 22px" id="hPathFotos" size="17" type="hidden"
										name="Hidden1" runat="server"> <INPUT style="Z-INDEX: 0; WIDTH: 138px; HEIGHT: 22px" id="hCtaCble5dig" size="17" type="hidden"
										name="Hidden1" runat="server">
								</TD>
								<TD align="right"><asp:imagebutton style="Z-INDEX: 0" id="ibtnListadoppto" runat="server" Visible="False" ImageUrl="../../imagenes/ibtnResumenppto.png"></asp:imagebutton><asp:imagebutton style="Z-INDEX: 0" id="ibtnResumen" runat="server" Visible="False" ImageUrl="../../imagenes/ibtnListadoppto.png"></asp:imagebutton></TD>
							</TR>
						</TABLE>
				<TR>
					<TD id="lblresul" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				</TD></TR>
				<TR>
					<TD style="HEIGHT: 19px" bgColor="#ffffff" align="left">
						<TABLE style="Z-INDEX: 0; WIDTH: 216px; HEIGHT: 24px" id="Table2" class="opaco5Porc" border="1"
							cellSpacing="1" cellPadding="1" width="216" align="left">
							<TR>
								<TD style="BORDER-BOTTOM: gray 1px solid; BORDER-LEFT: gray 1px solid; BACKGROUND-COLOR: lightsteelblue; PADDING-LEFT: 10px; BORDER-TOP: gray 1px solid; CURSOR: hand; BORDER-RIGHT: gray 1px solid"><asp:label id="lblMostrar" runat="server" CssClass="TituloPrincipal" Font-Size="X-Small" Font-Names="Arial"
										Font-Bold="True">Mostrar Relación de Personal </asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD id="CellContenedor" align="left">
						<TABLE style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/imgToolCenter.gif); Z-INDEX: 0; BORDER-BOTTOM: dimgray 1px solid; BORDER-LEFT: dimgray 1px solid; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; BACKGROUND-REPEAT: repeat-x; BORDER-TOP: dimgray 1px solid; BORDER-RIGHT: dimgray 1px solid"
							id="tblToolMaster" class="Alternateitemgrilla" border="0" cellSpacing="3" cellPadding="0"
							width="100%">
							<TR>
								<TD vAlign="middle" width="3%" align="left"><IMG alt="" src="/SimaNetWeb/imagenes/Navegador/ibtnPrimeroDisable.gif"></TD>
								<TD vAlign="middle" width="3%" align="left"><IMG onclick="arrDataPersonal.Anterior()" alt="" src="/SimaNetWeb/imagenes/Navegador/ibtnAnterior.gif">
								</TD>
								<TD width="5%">
									<TABLE id="Table6" border="0" cellSpacing="0" cellPadding="0" width="100" align="left">
										<TR>
											<TD noWrap><INPUT style="BACKGROUND-IMAGE: url(/SimanetWeb/imagenes/Filtro/imgBuscar.gif); WIDTH: 100%; BACKGROUND-REPEAT: no-repeat; HEIGHT: 22px"
													id="txtBuscar" class="Buscar" onkeyup="arrDataPersonal.Buscar(this);" size="14" name="txtBuscar"
													runat="server"></TD>
										</TR>
										<TR>
											<TD noWrap><asp:label id="Label2" runat="server" CssClass="TituloPrincipal" BackColor="Transparent" BorderStyle="None"
													ForeColor="Navy">...</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
								<TD vAlign="middle" width="3%" align="left"><IMG onclick="arrDataPersonal.Siguiente()" alt="" src="/SimaNetWeb/imagenes/Navegador/ibtnSiguiente.gif"></TD>
								<TD vAlign="middle" width="3%" align="left"><IMG alt="" align="left" src="/SimaNetWeb/imagenes/Navegador/ibtnUltimoDisable.gif" width="22"
										height="21">
								</TD>
								<TD style="BORDER-BOTTOM: gray 1px solid; BORDER-LEFT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-RIGHT: gray 1px solid"
									width="70%" align="center"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<div style="BORDER-BOTTOM: #0000ff 1px solid; POSITION: absolute; BORDER-LEFT: #0000ff 1px solid; BACKGROUND-COLOR: transparent; WIDTH: 48px; DISPLAY: none; HEIGHT: 20px; BORDER-TOP: #0000ff 1px solid; TOP: 280px; BORDER-RIGHT: #0000ff 1px solid; LEFT: 50px"
				id="divMonitor" class="FondoSuave"></div>
			<TABLE style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/ToolTips.gif); POSITION: absolute; WIDTH: 312px; DISPLAY: none; BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: center center; HEIGHT: 264px; TOP: 290px; LEFT: 120px"
				id="tblDatos" border="0" cellSpacing="1" cellPadding="1" width="312">
				<TR>
					<TD style="PADDING-LEFT: 15px; HEIGHT: 39px; PADDING-TOP: 10px"><asp:label id="lblApellidosyNombres" runat="server" CssClass="TituloPrincipal" ForeColor="Gray">Label</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 159px" vAlign="middle" align="center"><IMG style="BORDER-BOTTOM: gray 1px solid; BORDER-LEFT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-RIGHT: gray 1px solid"
							id="imgPersonal" class="FotoNoSeleccionada" border="0" hspace="1" alt="" vspace="1" src="file:///C:\Documents and Settings\erosales\Escritorio\ToolBarFotos\5733.jpg"
							width="128" height="154"></TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 5px; PADDING-RIGHT: 5px">
						<TABLE id="Table4" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD style="PADDING-LEFT: 12px; HEIGHT: 19px">
									<asp:label id="Label1" runat="server" CssClass="TituloPrincipal" ForeColor="Gray" BorderStyle="None"
										BackColor="Transparent">ESPECIALIDAD :</asp:label></TD>
							</TR>
							<TR>
								<TD style="PADDING-LEFT: 12px">
									<asp:label id="LblEspecilidad" runat="server" CssClass="TituloPrincipal" ForeColor="Gray" BorderStyle="None"
										BackColor="Transparent">ESPECILIDAD</asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
