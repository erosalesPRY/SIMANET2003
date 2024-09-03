<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministrarTransferenciasdePartidas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.AdministrarTransferenciasdePartidas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarEvaluacionGastosdeAdministracionCC</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<style>.BordeIzquierdo { BORDER-LEFT: #cccccc 1px solid }
		</style>
		<script>
			var ArrDatosRemotos = new Array();
			var KEYIDREQUERIMIENTO="idrqr";
			var KEYQIDCENTRO = "idCentroOperativo";
			var KEYQIDGRUPOCC="idGrupoCC";
			var KEYIDCC = "IdCentroCosto";
			var KEYIDNROCC = "NroCC";
			var KEYIDNOMBRECC = "NombreCC";
			var KEYIDPERIODO = "Periodo";
			var KEYIDMES = "idMes";
			var KEYQTIPOPRESUPUESTO="idTP";	
			var KEYQIDTRANSFERENCIA="idTransf";	

			function IncluirCentrosdeCosto(){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var KEYQQUIENLLAMA = "QLLAMA";
					var URLPAGINA = "AgregarCentrosdeCostosTransferencias.aspx?"
					with(SIMA.Utilitario.Constantes.General.Caracter){
						WindMostraVentaModal(URLPAGINA + KEYQQUIENLLAMA + SignoIgual + "Transfiere"
														+ signoAmperson
														+ KEYQTIPOPRESUPUESTO + SignoIgual + oPagina.Request.Params[KEYQTIPOPRESUPUESTO]
														+ signoAmperson
														+ KEYIDREQUERIMIENTO + SignoIgual + oPagina.Request.Params[KEYIDREQUERIMIENTO]
														+ signoAmperson
														+ KEYQIDCENTRO + SignoIgual + oPagina.Request.Params[KEYQIDCENTRO]
														+ signoAmperson
														+ KEYQIDGRUPOCC + SignoIgual + oPagina.Request.Params[KEYQIDGRUPOCC]
											,"",480,200);
					}					
					
					
					try{
						var oTransferenciaBE = new EntidadesNegocio.Presupuesto.TransferenciaBE();
						oTransferenciaBE.idTransferencia = oPagina.Request.Params[KEYQIDTRANSFERENCIA];
						oTransferenciaBE.idRequerimiento = oPagina.Request.Params[KEYIDREQUERIMIENTO];
						oTransferenciaBE.idCentroOperativo = ArrDatosRemotos[1];
						oTransferenciaBE.idGrupoCC = ArrDatosRemotos[2];
						oTransferenciaBE.idCentroCosto = ArrDatosRemotos[3];
						oTransferenciaBE.Periodo = oPagina.Request.Params[KEYIDPERIODO];
						oTransferenciaBE.idMes = ArrDatosRemotos[0];
						if ((new Controladora.Presupuesto.CTransferencia()).Insertar(oTransferenciaBE)>0){
							window.document.location.reload();
						}				
					}
					catch(error){
						switch(error.number){
							case -2146823279:
									window.alert("ERROR:NUMERO: " + error.number + "\nDESCRIPTCION : " + error.description);
								break;
							default:
								break;
						}
						
					}				
			}
			/*-------------------------------------------------------------------------------------------------------------------------------------------------------*/
			function NodeItem_OnClick(e){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var KEYQIDPERIODO = "Periodo";
				var KEYQIDMES = "idMes";
				var Cuenta3Dig;
				if(e==undefined){
					e = window.event.srcElement;//Objeto Imagen
				}
				
				var oNodoItem = new SIMA.Utilitario.Helper.General.Treeview.Nodo.Item();
				oNodoItem = e.getAttribute("oNodoItem");
				oDataGridFilaActual = oNodoItem.DataGridFila;
				Cuenta3Dig=oDataGridFilaActual.getAttribute("CuentaContable3Dig");
				var NroColumnas = oDataGridFilaActual.getAttribute("NroColumnas");
				var oDataTable = new System.Data.DataTable("TblRqr");
				oDataTable  = (new Controladora.Presupuesto.CRequerimientos()).ConsultarTransferenciaDetalleCta5Dig(
																													oPagina.Request.Params[KEYIDREQUERIMIENTO]
																													,oPagina.Request.Params[KEYQIDTRANSFERENCIA]
																													,oPagina.Request.Params[KEYQIDCENTRO]
																													,oPagina.Request.Params[KEYQIDGRUPOCC]
																													,oPagina.Request.Params[KEYIDCC]
																													,Cuenta3Dig
																													,oPagina.Request.Params[KEYQIDPERIODO]
																													,oPagina.Request.Params[KEYQIDMES]
																													);
				
				
																	
				for (var i=0; i <= oDataTable.Rows.Items.length-1; i++){
					dr = oDataTable.Rows.Items[i];
					if(dr.Item("EOF")==false){
						var oDataGridFilaNueva;
						oDataGridFilaNueva = SIMA.Utilitario.Helper.General.Treeview.Nodo.Adicionar(i,dr.Item("NombreCuenta").toString(),false,null,Transferencia_CuentaContable,e);
						oDataGridFilaNueva.title = dr.Item("CuentaContable5Dig").toString();
						oDataGridFilaNueva.setAttribute("CuentaContable3Dig",dr.Item("CuentaContable5Dig").toString());
						
							var oNodoItem = ObtenerNodoItem(oDataGridFilaNueva);
							var ColIndex = 0;
							/*Columna 1*/
							tblCol1 = ohtml.CrearTabla(1,3);
							tblCol1.height="100%";
							tblCol1.width="100%";
							tblCol1.className="ItemGrillaSinColor";
							tblCol1.border=0;
							tblCol1.cellSpacing=0;
							tblCol1.cellPadding=0;
							with(tblCol1.rows[0]){
								cells(0).innerText = (new SIMA.Numero(dr.Item("MontoPresupuestoMes").toString())).toString(2,true,' ');
								cells(0).width = "33.33%";
								cells(0).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
								cells(1).appendChild(CrearInputPorMes(oNodoItem,dr.Item("idMovTransferencia").toString(),dr.Item("CuentaContable5Dig").toString(),(new SIMA.Numero(dr.Item("MontoRequeridoMes").toString())).toString(2,true,' '),ColIndex));
								cells(1).width = "33.33%";
								cells(1).bgColor="#ffffcc";
								cells(1).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
								cells(2).innerText = (new SIMA.Numero(dr.Item("TotalMes").toString())).toString(2,true,' ');
								cells(2).width = "33.33%";
								cells(2).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
							}
							tblCol1.deleteRow(1);
							oDataGridFilaNueva.cells(1).appendChild(tblCol1);
							
							ColIndex++;
							
							try{
								/*Columna 2*/
								tblCol2 = ohtml.CrearTabla(1,NroColumnas);
								tblCol2.height="100%";
								tblCol2.width="100%";
								tblCol2.className="ItemGrillaSinColor";
								tblCol2.border=0;
								tblCol2.cellSpacing=0;
								tblCol2.cellPadding=0;
								var AnchoCol = (100/NroColumnas);
								
								with(tblCol2.rows[0]){
									tblField =  oDataGridFilaActual.cells(2).children[0];
									for(var c=0;c<=NroColumnas-1;c++){
										cells(c).width = AnchoCol + "%";
										cells(c).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
										//tbl.Rows[0].Cells[Columna].Attributes.Add("bgColor","#ffffff");
										var nCampo = tblField.rows[0].cells(c).getAttribute("NombreCampo");
										if(nCampo!=null){
											cells(c).setAttribute("NombreCampo",nCampo);
											if(nCampo.substring(0,1)=="A"){
												//cells(c).bgColor="#ffffff";
												cells(c).setAttribute("MontoRequerido", dr.Item("MontoRequeridoMes").toString());
												//cells(c).appendChild(CrearInputPorMes(oNodoItem,dr.Item("CuentaContable5Dig").toString(),dr.Item(nCampo).toString(),ColIndex));
												cells(c).innerText= (new SIMA.Numero(dr.Item(nCampo).toString())).toString(2,true,' ');
												ColIndex++;
											}else{
												cells(c).innerText = (new SIMA.Numero(dr.Item(nCampo).toString())).toString(2,true,' ');
											}
										}										
										if(c>0){
											cells(c).style.borderLeft = "1px #cccccc solid";
										}	
									}
								}
								tblCol2.deleteRow(1);
								oDataGridFilaNueva.cells(2).appendChild(tblCol2);
							}catch(error){
								//window.alert(error);
							}
					}
				}
				return "Cargado";//
			}
			/*-------------------------------------------------------------------------------------------------------------------------------------------------------*/
			function ObtenerNodoItem(oFilaActual)//Es utilizado para obtener informacion de nodo para luego crear los txtbox 
			{
					otblNodoRaiz = oFilaActual.cells[0].children[0];
					NroColPenultima = (otblNodoRaiz.rows[0].cells.length-2);
					oimg = otblNodoRaiz.rows[0].cells(NroColPenultima).children[0];
					oNodoItem = oimg.getAttribute("oNodoItem");
					return oNodoItem;
			}
			/*-------------------------------------------------------------------------------------------------------------------------------------------------------*/
			
			function ibtnAgregarNaturalezaGasto_OnClick(){
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var KEYQQUIENLLAMA = "QLLAMA";
					var URLPAGINA = "AgregarRequerimientoNaturalezadeGasto.aspx?";
					with(SIMA.Utilitario.Constantes.General.Caracter){
						WindMostraVentaModal(URLPAGINA + KEYQQUIENLLAMA + SignoIgual + "Transfiere"
														+ signoAmperson
														+ KEYQIDTRANSFERENCIA + SignoIgual + oPagina.Request.Params[KEYQIDTRANSFERENCIA]
											,"",480,330);
					}					

					try{
						for(var i=0;i<=ArrDatosRemotos.length-1;i++){
							var strDatos = ArrDatosRemotos[i].toString().split(';');
							var oRequerimientoNaturalezadeGastoCta3DigBE = new EntidadesNegocio.Presupuesto.RequerimientoNaturalezadeGastoCta3DigBE();
							oRequerimientoNaturalezadeGastoCta3DigBE.idTransferencia = oPagina.Request.Params[KEYQIDTRANSFERENCIA];
							oRequerimientoNaturalezadeGastoCta3DigBE.idCuentaContableGrupo = strDatos[0];
							oRequerimientoNaturalezadeGastoCta3DigBE.idEstado = strDatos[1];
							(new Controladora.Presupuesto.CRequerimientoNaturalezadeGasto()).InsertarModificar(oRequerimientoNaturalezadeGastoCta3DigBE);
						}
						window.document.location.reload();
					}
					catch(error){
						switch(error.number){
							case -2146823279:
									window.alert("ERROR:NUMERO: " + error.number + "\nDESCRIPTCION : " + error.description);
								break;
							default:
								break;
						}
						
					}
			}
		/*-------------------------------------------------------------------------------------------------------------------------------------------------------*/
			function CrearInputPorMes(oNodoItem,oidMovTransferencia,CuentaContable,Monto,NroCol){
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
				otxtNumero.idMovTransferencia = oidMovTransferencia;
				//otxtNumero.value =FormatNumber(Monto, 2, true,true, true);
				otxtNumero.value =Monto;
				otxtNumero.style.background ="Transparent";
				otxtNumero.style.border ="none";
				return 	otxtNumero;
			}
			/*-------------------------------------------------------------------------------------------------------------------------------------------------------*/
			function Actualizar_Transferencia(objTxt,oTipoMonto){
				//var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				return AgregarModificar(objTxt.getAttribute("idMovTransferencia"),objTxt.Cuenta5Dig,objTxt.value);	
			}
			/*-------------------------------------------------------------------------------------------------------------------------------------------------------*/
			/*Registra y Actualiza*/
			/*-------------------------------------------------------------------------------------------------------------------------------------------------------*/
			var KEYQIDPERIODO = "Periodo";
			
			function AgregarModificar(widMovTransferencia,wCuentaContable,wMonto){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var oRequerimientoTransferenciaBE = new EntidadesNegocio.Presupuesto.RequerimientoTransferenciaBE();
				with(oRequerimientoTransferenciaBE){
					IdMovTransferencia = widMovTransferencia;
					IdTransferencia = oPagina.Request.Params[KEYQIDTRANSFERENCIA];
					Periodo =  oPagina.Request.Params[KEYQIDPERIODO];
					IdMes = oPagina.Request.Params[KEYIDMES];
					CuentaContable = wCuentaContable;
					Monto = wMonto;
					idTipoMov = 1;//VALOR POR DEFAULT
				}
				if((new Controladora.Presupuesto.CRequerimientoTransferencia()).InsertarModificar(oRequerimientoTransferenciaBE)>0){
					document.location.reload();
				}
			}
			/*-------------------------------------------------------------------------------------------------------------------------------------------------------*/
			function MoverPuntero(){
				if (event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.KeyReturn){
					if (this.style.border !=""){
						var oCell = this.parentElement;
						var oRow = oCell.parentElement;//Fila que contiene el monto del presupuesto
						//Datos que seran utilizados para totalizar el nodo
						var oDataGridFilaNueva = oRow.parentElement.parentElement.parentElement.parentElement;
						
						var arrDato = this.id.toString().split('_');
						var TipoMonto = parseInt(arrDato[arrDato.length-1]);
						
						if (this.value != this.ViejoValor){
							if((parseInt(this.value)>=parseInt(oRow.cells(oCell.cellIndex-1).innerText)) &&(TipoMonto!=0)){//Valida que el monto a trasnferir no sea mayor al Monto del ppto asignado
								window.alert("El monto a transferir :=" + this.value
												+ "\nno puede ser mayor al monto del Presupuesto :=" + oRow.cells(oCell.cellIndex-1).innerText );
								this.value=this.ViejoValor;
								this.style.border ="none";
								this.select();
							}
							else{
								var TotalTranferir = ObtenerMontosTransferidos(oRow,oCell,this.value);
								if((parseInt(TotalTranferir)>parseInt(oCell.getAttribute("MontoRequerido")))&& (TipoMonto!=0)){
									window.alert("El total a Tranferir :=" + parseInt(TotalTranferir) 
													+ "\nno puede ser mayor al Monto requerido :=" + parseInt(oCell.getAttribute("MontoRequerido")));
										this.value=this.ViejoValor;
										this.style.border ="none";
										this.select();
								}
								else{
									if(Actualizar_Transferencia(this,TipoMonto)){								
										this.ViejoValor=this.value;
										this.style.border ="none";
										this.select();
									}
								}
							}
						}
					}
					else{
						GridControl_EnfocarCelda(this.id.toString(),SIMA.Utilitario.Enumerados.TipoEnfoque.DERECHA);
					}
				}
				else if (event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.keyUp){//Flecha Arriba
					if (this.style.border ==""){
						GridControl_EnfocarCelda(this.id.toString(),SIMA.Utilitario.Enumerados.TipoEnfoque.ARRIBA);
					}
				}				
				else if (event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.keyDown){//Flecha Abajo
					if (this.style.border ==""){
						GridControl_EnfocarCelda(this.id.toString(),SIMA.Utilitario.Enumerados.TipoEnfoque.ABAJO);
					}
				}								
				else if(event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.keyRight){//FechaDrecha
					GridControl_EnfocarCelda(this.id.toString(),SIMA.Utilitario.Enumerados.TipoEnfoque.DERECHA);
				}
				else if(event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.keyLeft){//FechaIzquierda
					GridControl_EnfocarCelda(this.id.toString(),SIMA.Utilitario.Enumerados.TipoEnfoque.IZQUIERDA);
				}
				else if (event.keyCode == 113){//Esta Tecla permite la edicion dela celda
					objTxt = document.all[this.id];
					objTxt.style.border ="1.5pt inset";
					objTxt.focus();
				}
				else if (event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.KeyEscape){//la Tecla Escape
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
			/*--------------------------------------------------------------------------------------------------------------*/
			function ObtenerMontosTransferidos(oRow,oCell,Monto){
				var Total=parseFloat(Monto);
				try{
					for(var i=0;i<=oRow.cells.length-1;i++){
						var NombreC = oRow.cells[i].getAttribute("NombreCampo");
						if(i != oCell.cellIndex){
							if(NombreC.substring(0,1)=="A"){
								var txtObj = oRow.cells[i].children[0];
								Total = Total + parseFloat(txtObj.value);
							}
						}
					}
				}catch(error){
					return Total;
				}
				return Total;
			}
			/*--------------------------------------------------------------------------------------------------------------*/
			function GridControl_EnfocarCelda(idObjeAct,TipoEnfoque){
				var arrNombre = idObjeAct.toString().split('.');
				var arrIdRowCol = arrNombre[1].toString().split('_');
				var idObjSigu = "";
				var NombreObj = "";
				//Elabora el Nombre del Objeto a enfocar
				switch(TipoEnfoque){
					case SIMA.Utilitario.Enumerados.TipoEnfoque.DERECHA:
						idObjSigu = (parseInt(arrIdRowCol[1])+1);
						NombreObj = arrNombre[0].toString() + "." + arrIdRowCol[0] + "_" + idObjSigu ;					
						break;
					case SIMA.Utilitario.Enumerados.TipoEnfoque.IZQUIERDA:
						idObjSigu = (parseInt(arrIdRowCol[1])-1);
						NombreObj = arrNombre[0].toString() + "." + arrIdRowCol[0] + "_" + idObjSigu ;					
						break;
					case SIMA.Utilitario.Enumerados.TipoEnfoque.ARRIBA:
						idObjSigu = (parseInt(arrIdRowCol[0])-1);
						NombreObj = arrNombre[0].toString() + "." + idObjSigu + "_" + arrIdRowCol[1];					
						break;
					case SIMA.Utilitario.Enumerados.TipoEnfoque.ABAJO:
						idObjSigu = (parseInt(arrIdRowCol[0])+1);
						NombreObj = arrNombre[0].toString() + "." + idObjSigu + "_" + arrIdRowCol[1];
						break;
				}
				//Realiza el Enfoque del Objeto
				try{
					var objtxtEnfocar = document.all[NombreObj];
					objtxtEnfocar.focus();
				}catch(error){
					if(error.number=-2146833281){
						//Ya no existen mas obj a la derecha entoces baja una fila y se pocisiona enl primer objeto de esa fila
						switch(TipoEnfoque){
							case SIMA.Utilitario.Enumerados.TipoEnfoque.DERECHA:
								NombreObj = arrNombre[0].toString() + "." + (parseInt(arrIdRowCol[0])+1) + "_" + "0";
								try{
									var objtxtEnfocar = document.all[NombreObj];
									objtxtEnfocar.focus();
								}catch(err){}
								break;
						}
					}
				}				
			}
			/*--------------------------------------------------------------------------------------------------------------*/
			function EstablecerAltoColumna1(){
				try{
					var ogrid = document.all["grid"];
					var otbl = ogrid.rows[0].cells[1].children[0];
					otbl.border=0;
					otbl.style.height = ogrid.rows[0].offsetHeight+"px";
					otbl.rows[1].style.height=ogrid.rows[0].offsetHeight+"px";
					otbl.rows[1].style.cells[0].height="100%";
					otbl.rows[1].style.cells[1].height="100%";
					otbl.rows[1].style.cells[2].height="100%";
				}
				catch(error){};
			}
			/*--------------------------------------------------------------------------------------------------------------*/
			function Valida_btnSolicitarCC(){
				try{
					var ogrid=document.all["grid"];
					var orow = ogrid.rows[0];
				}
				catch(error){
					var oibtnAgregar = document.all["ibtnAgregar"];
					oibtnAgregar.style.display="none";
					var oibtnAgregarNaturalezaGasto = document.all["ibtnAgregarNaturalezaGasto"];
					oibtnAgregarNaturalezaGasto.onclick();
				}
			}
			/*--------------------------------------------------------------------------------------------------------------*/
			var URLPAGINA="";
			function Transferencia_CuentaContable(){
				var KEYQMONTOREQUERIDO="MontoRQR";
				var KEYQIDCUENTACONTABLENOMBRE="CuentaContableNombre";
				var KEYQIDCUENTACONTABLE="CuentaContable";
				var oCell = window.event.srcElement;
				var oRow = oCell.parentElement.parentElement.parentElement.parentElement.parentElement;
				var txtMonto = oRow.cells[1].children[0].rows[0].cells[1].children[0];

				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				with(SIMA.Utilitario.Constantes.General.Caracter){
					URLPAGINA="AdministrarAprobaciondeRequerimientoTransferencia.aspx?"
							+ KEYQIDTRANSFERENCIA + SignoIgual +  oPagina.Request.Params[KEYQIDTRANSFERENCIA]
							+ signoAmperson
							+ KEYIDPERIODO + SignoIgual +  oPagina.Request.Params[KEYIDPERIODO]
							+ signoAmperson
							+ KEYQIDCUENTACONTABLE + SignoIgual + oRow.getAttribute("CuentaContable3Dig")
							+ signoAmperson 
							+ KEYQIDCUENTACONTABLENOMBRE + SignoIgual + oCell.innerText
							+ signoAmperson 
							+ KEYQMONTOREQUERIDO + SignoIgual + txtMonto.value;
				}
				WindMostraVentaModal(URLPAGINA,"",screen.width,430);
				
			}
		</script>
		<script>
			function ExpandirTodos(){
				var oListImg = document.getElementsByTagName("img");
				for(i=0;i<=oListImg.length-1;i++){
					var imgTree = oListImg[i];
					imgTree.ObtenerNombreImg=function(){
						var arrPath  = this.src.split('/');
						return arrPath[arrPath.length-1].toString().toUpperCase();
					}
					imgTree.Igual=function(_valor){
						return (this.ObtenerNombreImg()==_valor.toString().toUpperCase());
					}
					if(imgTree.Igual('plus.gif')){
						imgTree.onclick();
					}
				}
			}
		</script>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" bottomMargin="0"
		leftMargin="0" topMargin="0" onload="ExpandirTodos();Valida_btnSolicitarCC();EstablecerAltoColumna1();ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="tblContenedor" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR class="commands">
					<TD class="commands"><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Inicio> Gestión Financiera> Prespuesto> Transferencia Presupuestal por Centro de Costo</asp:label></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#f0f0f0"><IMG id="ibtnAgregarNaturalezaGasto" onclick="ibtnAgregarNaturalezaGasto_OnClick();"
							src="../../imagenes/Otros/ibtnAgregarNatutalezaGasto.gif" align="left">
					</TD>
				</TR>
				<TR>
					<TD align="left"><cc1:datagridweb id="grid" runat="server" ShowFooter="True" Width="100%" RowHighlightColor="#E0E0E0"
							AutoGenerateColumns="False" AllowSorting="True" PageSize="7">
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="AlternateItemGrillaTree"></AlternatingItemStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrillaTree"></ItemStyle>
							<Columns>
								<asp:BoundColumn DataField="NombreCuenta" HeaderText="NATURALEZA DE GASTO">
									<HeaderStyle Width="20%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="SIMA-PERU">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<HeaderTemplate>
										<TABLE id="Table4" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
											border="0">
											<TR>
												<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" width="100%" colSpan="3">
													<asp:Label id="lblPeriodo" runat="server" CssClass="headergrilla" BorderStyle="None">SIMA-PERU. S.A</asp:Label></TD>
											</TR>
											<TR height="100%">
												<TD align="center" width="33.33%" height="100%">
													<asp:Label id="lblHPPTO" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="PRESUPUESTO DEL MES">PPTO.</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="33.33%" height="100%">
													<asp:Label id="lblHEjecutado" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="REQUERIMIENTO">REQUER.</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="33.33%" height="100%">
													<asp:Label id="lblHSaldo" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="SALDO DEL MES">Saldo</asp:Label></TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
											border="0">
											<TR>
												<TD class="ItemGrillaSinColor" noWrap align="right" width="33.33%">
													<asp:Label id="lblPrespuesto" runat="server">0.00</asp:Label></TD>
												<TD class="ItemGrillaSinColor" style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right"
													width="33.33%" bgColor="#ffffcc">
													<asp:Label id="lblEjecutado" runat="server">0.00</asp:Label></TD>
												<TD class="ItemGrillaSinColor" style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right"
													width="33.33%">
													<asp:Label id="lblSaldo" runat="server">0.00</asp:Label></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<HeaderStyle Width="60%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:TemplateColumn>
							</Columns>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center"><IMG id="ibtnAgregar" onclick="IncluirCentrosdeCosto();" alt="" src="../../imagenes/Otros/ibtnCentroCostoSolicita.gif"
							align="left" style="DISPLAY: none"></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD id="ToolBarPersonal" align="center">&nbsp;
					</TD>
				</TR>
				<TR>
					<TD id="tdMaestar" align="right" bgColor="#ffffff" runat="server"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
