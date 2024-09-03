<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultaDeEstadosFinancieros.aspx.cs" ValidateRequest="true" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.ConsultaDeEstadosFinancieros" %>
<%@ Register TagPrefix="uc1" TagName="ParametroContable" Src="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<SCRIPT language="javascript" src="../../js/JQuery/js/jquery.min.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>
		<SCRIPT>
			var jSIMA = jQuery.noConflict();
		</SCRIPT>
		<style>.ContextImg { Z-INDEX: 3; POSITION: relative; WIDTH: 45px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 45px }
	.imgCirc { Z-INDEX: 1; POSITION: absolute; BACKGROUND-REPEAT: no-repeat; TOP: -2px; left-30: }
		</style>
		<script>
			var KEYQIDFORMATO = "IdFormato";
			var KEYPRCFORMATO ="PrcFMT";
			var KEYCTRLCIERRE ="CtrlCierre";
			//Utilizado por el editor de descripciones 
			function  EscribirDescripcionEnFila(strIdRubro){
				var objgrid = document.all["grid"];
				var strData = ObtenerValordeRubro(strIdRubro,'OBSERVACIONES');
				var Datos=new Array();
				
				Datos=window.showModalDialog(ObtenerPathAppWeb()+ "/Editor/Editor.aspx",strData,"dialogWidth:630px;dialogHeight:400px"); 
				
				if(Datos!=null){ 
					for(var i=1;i<= objgrid.rows.length-1;i++){
						if(parseInt(objgrid.rows[i].getAttribute("IDRUBRO"))== parseInt(strIdRubro)){
							var strValor = Datos[0];
							objgrid.rows[i].removeAttribute("OBSERVACIONES");
							objgrid.rows[i].setAttribute("OBSERVACIONES",strValor);
							break;
						}
					}
				}
				
			}
		
			var idObj=0;
			//Variable que contienen parte de el Nombre del Objeto numerico y sisrve para obtener un nombre de control posible
			var NombreDefault1 = "grid__ctl";
			var NombreDefault2 = "_nMonto";
			var EstadodeValorActual = false;

			function EnfocarSiguienteCelda(objthis){
				var keyEnter = 13;
				var keyTab= 9;
				var keyUp= 38;
				var keyDown= 40;
				objthis = window.event.srcElement||objthis;
				
				var NroObj = ObtenerIDdeFiladeObjNumerico(objthis.id);
				var objgrid = document.all["grid"];
				
				
				if (event.keyCode==keyEnter || event.keyCode==keyDown || event.keyCode==keyTab){
					var NroObjSiguiente = (parseInt(NroObj)+1);
					if ((NroObj-1) == objgrid.rows.length)
					{NroObjSiguiente=2;}

					var NombreObjSiguiente = NombreDefault1 + NroObjSiguiente + NombreDefault2;
					var objSiguiente = document.all[NombreObjSiguiente];
					if (objSiguiente != undefined){objSiguiente.focus();}
					
				}
				else if (event.keyCode==keyUp){
					var NroObjAnterior = (parseInt(NroObj)-1);
					var NombreObjAnterior = NombreDefault1 + NroObjAnterior + NombreDefault2;
					var objAnterior = document.all[NombreObjAnterior];
					if (objAnterior != undefined){objAnterior.focus();}
				}
			}
			
			//Asigna al Objeto Numerico el Evento de salida OnBlur			
			function AsignarEventodeSalidayCambio(){
				//var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				//var ParamPRC = oPagina.Request.Params[KEYPRCFORMATO];
				//var CtrlCierre = oPagina.Request.Params[KEYCTRLCIERRE];
				jSIMA(".NumericBox").blur(NewonBlur);
				jSIMA(".NumericBox").change(CuandoCambiaValor);
				jSIMA(".NumericBox").keydown(EnfocarSiguienteCelda);
			}
			
			//Asigna al Objeto Numerico el Evento de cambio OnChange para detectar algun cambio en los montos
			function CuandoCambiaValor()
			{EstadodeValorActual = true;}
			//Evento que se desencadena al Momento de perder el foco el Obj Numerico
			function NewonBlur(){
				//NumericBox_IE_ParseAdd(this, ' ', ',', '.');
				if (EstadodeValorActual == true)//Si se ha cambiado algun valor para que vuelva a recalcular
				{ 
					var NroObj = ObtenerIDdeFiladeObjNumerico(this.id);
					AlmacenarValorenFilaActual(document.all["grid"],NroObj,this.value);
					ProcesarCalculodeFormato();
					EstadodeValorActual = false;
				}
			}
			//Permite almacenar el Valor del Obj Numerico en la Fila Actual que se encuentra el Obj
			function AlmacenarValorenFilaActual(objgrid,idFila,nValor){
				var NuevoValor = Reemplazar(nValor,",","");
				objgrid.rows[idFila-1].removeAttribute("MONTORUBRO");
				objgrid.rows[idFila-1].setAttribute("MONTORUBRO",NuevoValor);
			}
			//Permite Obtener el Nro de Fila Actual en la cual se encuentra pocicionado el Cursor sobre el Obj Numerico
			function ObtenerIDdeFiladeObjNumerico(strNombreObjNumerico){
				var Nombre1 = Reemplazar(strNombreObjNumerico,NombreDefault1,"");
				var NroObj = Reemplazar(Nombre1,NombreDefault2,"");
				return 	NroObj;							
			}
			
			function ProcesarFormatoAlSalir(){
				if (document.all["chkAplicar"].checked ==true){this.ProcesarCalculodeFormato();}
			}
			
			function TotalizarRubro(strFormula){
				var pos=0;
				var Signo ="";
				var Total=0;
				var totalTmp=0;
				while (strFormula.length >0){
					if (!isDigit(strFormula.charAt(pos))){
							var DataCol="";
							var stridRubro = "";
							if (strFormula.charAt(pos)=="@"){
								stridRubro = strFormula.substring(0,pos);
								DataCol= ObtenerValordeRubro(stridRubro,'MONTORUBRO');
								totalTmp =Total;
								Total = Calcular(totalTmp,DataCol,Signo);
								break;							
							}
							else{
								stridRubro = strFormula.substring(0,pos);
								DataCol = ObtenerValordeRubro(stridRubro,'MONTORUBRO');
								totalTmp =Total;
								Total = Calcular(totalTmp,DataCol,Signo);
								
								strFormula = strFormula.substring(pos,strFormula.length);
								Signo = strFormula.substring(0,1);
								strFormula = strFormula.substring(1,strFormula.length);
								pos=-1;	
							}
						}
						pos++;
				}
				
				return Total;
			}
			
			function ObtenerValordeRubro(strIdRubro,STRTAG){
				var objgrid = document.all["grid"];
				for(var i=1;i<= objgrid.rows.length-1;i++){
					if(parseInt(objgrid.rows[i].getAttribute("IDRUBRO"))== parseInt(strIdRubro)){
						return objgrid.rows[i].getAttribute(STRTAG);
					}
				}
				return 0; 
			}
			
			
			function Calcular(Total,DataCol,Signo){
				var oTotal=0;
				if (Signo=="+")
				{oTotal = parseFloat(Total) + parseFloat(DataCol);}
				else if(Signo=="-")
				{oTotal = parseFloat(Total) - parseFloat(DataCol);}
				else
				{oTotal = parseFloat(DataCol);}
				return oTotal;
			}
			
			function CalculoPorPrioridad(Prioridad){
				var objgrid = document.all["grid"];
				var arrRowFormula = objgrid.getAttribute("FILAFORMULA").split(";");
				arrRowFormula.pop();
				
				for(var i=0;i<= arrRowFormula.length-1;i++){
					var idFila = arrRowFormula[i];
					if(parseInt(objgrid.rows[idFila].getAttribute("PRIORIDAD"))== parseInt(Prioridad)){
						var strFormula=objgrid.rows[idFila].getAttribute("FORMULA");
						var TotalData = TotalizarRubro(strFormula);
						
						var newidNombre = (parseInt(idFila)+1);
						var objtxt = document.all[NombreDefault1 + newidNombre + NombreDefault2];
						if (objtxt != undefined){
							objtxt.value = TotalData;
						}
						objgrid.rows[idFila].removeAttribute("MONTORUBRO");
						objgrid.rows[idFila].setAttribute("MONTORUBRO",TotalData);
					}
				}
			}
			
			
			function ProcesarCalculodeFormato(){
					for(var p=0;p<=8;p++)
					{CalculoPorPrioridad(p);}
					
					for(var p=0;p<=8;p++)
					{CalculoPorPrioridad(p);}
			}

			//Eventos para guardar la Informacion modificada
			function ConfirmaGrabar(){
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var Linea = "---------------------------------------------------------------";
				
				return confirm(oPagina.Request.Params["NFormato"].toString().toUpperCase() +"\n" + Linea + '\n Desea guardar los cambios de este formato ahora?: ');
			}

			function ObtenerDataModificada(){
				if (ConfirmaGrabar()){
					var strData="";
					var strDataPrueba="";
					var objgrid = document.all["grid"];
					for(var i=1;i<= objgrid.rows.length-1;i++){
						var V1 =Reemplazar(objgrid.rows[i].getAttribute("OBSERVACIONES"),'<','¿');
						var strObservacion =Reemplazar(V1,'>','?');
						strData += objgrid.rows[i].getAttribute("MODO") + "*" + objgrid.rows[i].getAttribute("IDRUBRO") + "*"  + objgrid.rows[i].getAttribute("MONTORUBRO") + "*" + strObservacion + "@";
					}
					MostrarDatosEnCajaTexto("hTramaData",strData);
				}
				else{
					window.alert("Operación Cancelada...");
					return false;
				}
			}
			
			
				//Popup de espera			
				var objPopupEspera = window.createPopup();
				function EFPopupDeEsperaShow(){
					var intPopupWidth = 300;
					var intPopupHeight = 104;
					var xleft=  (window.screen.width/2) - (intPopupWidth/2);
					var yTop=  (window.screen.height/2) - (intPopupHeight/2);
					objPopupEspera.document.body.innerHTML= ObtenerHtmlPopup();
					
					var oPopupBody = objPopupEspera.document.body;
					oPopupBody.style.border = "solid black 1px";
					oPopupBody.style.fontFamily = "Arial";
					oPopupBody.style.fontSize = "12px";

					objPopupEspera.show(xleft, yTop, intPopupWidth, intPopupHeight);
				}
				function EFPopupDeEsperaClose(){
					objPopupEspera.hide();
				}
				
			
			var NODOSELECCIONADO="NodoSeleccionado";
			
			function RestauraNodoSeleccionado(){
				var oDataGrid = document.all["grid"];
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var NodoValor = oPagina.Request.Params[NODOSELECCIONADO];
				if (NodoValor!= undefined){
					var arrNiveles = NodoValor.split(".");
					var UltElemento = arrNiveles.length-1;
					var Indice=0;
					var stNivelFind =ElaborarNiveles(Indice,arrNiveles);
					for(var Fila=0;Fila<=oDataGrid.rows.length-1;Fila++){
						if (oDataGrid.rows[Fila].NRONIVEL == stNivelFind){
							if (Indice<UltElemento){
								var objTblNodo = oDataGrid.rows[Fila].cells(0).children[0];
								var nroCelda = (objTblNodo.rows[0].cells.length-3);
								var ObjImg = objTblNodo.rows[0].cells(nroCelda).children[0];
								ObjImg.onclick();
								Indice++;
								stNivelFind =ElaborarNiveles(Indice,arrNiveles);
							}
						}
					}
				}
			}
			
			function ElaborarNiveles(Indice,arrNiveles){
				var stNivelFind="";
				for(var i=0;i<=Indice;i++){	stNivelFind += arrNiveles[i] + ".";}
				return stNivelFind.substring(0,stNivelFind.length-1);
			}
			
			OcultarBuscadordeArchivos=function(){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				if(oPagina.Request.Params[KEYQIDFORMATO]!= SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Codigo.BalanceGeneral){
					otblBuscarArchivo = document.all["tblBuscarArchivo"];
					otblBuscarArchivo.style.display = "none";
				}
			}
			
			var KEYIDACUMULADO ="Acumulado";
			var KEYQPERIODO = "Periodo";
			var KEYQMES = "idMes";
			var KEYQIDCENTRO = "IdCentro";
			var KEYQIDRUBRO = "IdRubro";
			var KEYQIDTIPOINFO= "idTipoInfo";
			function MostrarDetalleFormula(IdCentroOperativo,Periodo,IdMes,IdRubro,IdTipoInformacion){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var URLDETALLEFORMULAMOVIMIENTO = "ConsultarFormatoDetalleFormula.aspx" + SIMA.Utilitario.Constantes.General.Caracter.signoInterrogacion
													+ KEYQIDFORMATO +  SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQIDFORMATO]
													+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson 
													+ KEYQIDRUBRO +  SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdRubro
													+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
													+ KEYIDACUMULADO +  SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYIDACUMULADO] 
													+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
													+ KEYQIDCENTRO +  SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdCentroOperativo
													+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
													+ KEYQPERIODO  +  SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + Periodo
													+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
													+ KEYQMES  +  SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdMes
													+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
													+ KEYQIDTIPOINFO +  SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdTipoInformacion;
					
						
						var TabDetalle = [{title : 'Detalle movimiento de formula',autoLoad: {url: URLDETALLEFORMULAMOVIMIENTO, scripts : true, loadMask: false}}];
						
						(new System.Ext.UI.WebControls.Windows()).DialogoTabs('DETALLE FORMULA',TabDetalle,this,620,380);
							
			}
			
			function ErrorLoadImg(e,PathyFotos){
				try{
					e.src = PathyFotos;
				}catch(Error){
					e.src = '/SimanetWeb/imagenes/Navegador/UnChecked.png';
				}
			}			
		</script>
	</HEAD>
	<body onkeydown="if(event.keyCode==13){return false;}" onunload="SubirHistorial();" onload="OcultarBuscadordeArchivos();RestauraNodoSeleccionado();ObtenerHistorial();AsignarEventodeSalidayCambio();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR>
					<TD width="100%" colSpan="3" align="center">
						<TABLE id="Table2" class="normal" border="0" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD width="100%" colSpan="3" align="left">
									<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TR bgColor="#f5f5f5">
											<TD align="left"></TD>
											<TD>
												<TABLE id="tblBuscarArchivo" border="0" cellSpacing="1" cellPadding="1" width="300" align="left">
													<TR>
														<TD><asp:label id="Label2" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco" Width="168px">INDICADORES FINANCIEROS:</asp:label></TD>
														<TD><INPUT style="WIDTH: 294px; HEIGHT: 17px" id="filMyFileDocumento" class="normaldetalle"
																size="29" type="file" name="filMyFile" runat="server"></TD>
														<TD></TD>
													</TR>
												</TABLE>
												<asp:imagebutton style="Z-INDEX: 0" id="imgProcesar" runat="server" ImageUrl="../../imagenes/Procesar.gif"></asp:imagebutton></TD>
											<TD align="right"><asp:imagebutton id="imgbtnGrabar" runat="server" ImageUrl="../../imagenes/ibtnGrabar.GIF"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="center"><cc1:datagridweb id="grid" runat="server" Width="100%" DataKeyField="IdRubro" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Concepto" HeaderText="CONCEPTO"></asp:BoundColumn>
											<asp:BoundColumn DataField="MontoReferencia" SortExpression="MontoReferencia" HeaderText="MONTO REF"
												DataFormatString="{0:## ### ##0.00}">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="MONTO">
												<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<ew:numericbox id="nMonto" runat="server" CssClass="NumericBox" Width="125px" PlacesBeforeDecimal="15"
														TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="FORM">
												<HeaderStyle Font-Bold="True" Width="5%"></HeaderStyle>
												<ItemStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:Image id="imgFormula" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif" Visible="False"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="DET">
												<ItemTemplate>
													<asp:Image id="imgBtnDetalle" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="DESC">
												<ItemTemplate>
													<asp:Image id="imgBtnDescripcion" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb>
									<DIV align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></DIV>
									<asp:label id="Label1" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<tr>
								<td align="center"><IMG style="Z-INDEX: 0" id="ibtnUser" alt="" src="../../imagenes/Navegador/User.gif"
										width="30" height="30">
								</td>
							</tr>
							<tr>
								<td style="DISPLAY: none" id="LstUser" align="center" runat="server"></td>
							</tr>
							<TR>
								<TD width="100%" colSpan="3" align="left"><INPUT style="WIDTH: 28px; HEIGHT: 22px" id="hTramaData" size="1" type="hidden" runat="server"
										DESIGNTIMEDRAGDROP="188"><INPUT style="WIDTH: 55px; HEIGHT: 22px" id="hModo" size="3" type="hidden" name="hModo"
										runat="server" DESIGNTIMEDRAGDROP="64"><INPUT style="WIDTH: 24px; HEIGHT: 14px" id="hCodigo" value="1" size="1" type="hidden"
										name="hCodigo" runat="server" DESIGNTIMEDRAGDROP="194"><INPUT style="WIDTH: 24px; HEIGHT: 14px" id="hvalida" value="1" size="1" type="hidden"
										name="hvalida" runat="server"><INPUT style="WIDTH: 26px; HEIGHT: 22px" id="hIdRubro" size="1" type="hidden" name="hIdRubro"
										runat="server"><INPUT style="WIDTH: 26px; HEIGHT: 22px" id="hTiempoHabilitado" value="1" size="1" type="hidden"
										name="hIdRubro" runat="server"></TD>
							</TR>
						</TABLE>
						<INPUT style="WIDTH: 28px; DISPLAY: none; HEIGHT: 20px" id="chkAplicar" title="Aplicar formula"
							CHECKED type="checkbox">
					</TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
						
					
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
  						
					
					
			</SCRIPT>
		</form>
	</body>
</HTML>
