<%@ Page language="c#" Codebehind="AdministrarConceptoEstadosFinancieros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio.AdministrarConceptoEstadosFinancieros" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/FrameCallBack.js"></SCRIPT>
		<script>
			//Utilizado por el editor de descripciones 
			function  EscribirDescripcionEnFila(strIdRubro)
			{
				var objgrid = document.all["grid"];
				var strData = ObtenerValordeRubro(strIdRubro,'OBSERVACIONES');
				var Datos=new Array();
				
				Datos=window.showModalDialog(ObtenerPathAppWeb()+ "/Editor/Editor.aspx",strData,"dialogWidth:630px;dialogHeight:400px"); 
				
				if(Datos!=null)
				{ 
					for(var i=1;i<= objgrid.rows.length-1;i++)
					{
						if(parseInt(objgrid.rows[i].getAttribute("IDRUBRO"))== parseInt(strIdRubro))
						{
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

			function EnfocarSiguienteCelda(objthis)
			{
				var keyEnter = 13;
				var keyTab= 9;
				var keyUp= 38;
				var keyDown= 40;
				var NroObj = ObtenerIDdeFiladeObjNumerico(objthis.id);
				var objgrid = document.all["grid"];
				
				
				if (event.keyCode==keyEnter || event.keyCode==keyDown || event.keyCode==keyTab)
				{
					var NroObjSiguiente = (parseInt(NroObj)+1);
					if ((NroObj-1) == objgrid.rows.length)
					{NroObjSiguiente=2;}

					var NombreObjSiguiente = NombreDefault1 + NroObjSiguiente + NombreDefault2;
					var objSiguiente = document.all[NombreObjSiguiente];
					if (objSiguiente != undefined){objSiguiente.focus();}
					
				}
				else if (event.keyCode==keyUp)
				{
					var NroObjAnterior = (parseInt(NroObj)-1);
					var NombreObjAnterior = NombreDefault1 + NroObjAnterior + NombreDefault2;
					var objAnterior = document.all[NombreObjAnterior];
					if (objAnterior != undefined){objAnterior.focus();}
				}
			}
			
			//Asigna al Objeto Numerico el Evento de salida OnBlur			
			function AsignarEventodeSalidayCambio()
			{
				var objgrid = document.all["grid"];
				for(var i=2;i<= objgrid.rows.length-1;i++)
				{
					var objSiguiente = document.all[NombreDefault1 + i + NombreDefault2];
					if (objSiguiente!= undefined)
					{
						objSiguiente.onblur =NewonBlur;
						objSiguiente.onchange = CuandoCambiaValor;
					}
				}
			}
			//Asigna al Objeto Numerico el Evento de cambio OnChange para detectar algun cambio en los montos
			function CuandoCambiaValor()
			{EstadodeValorActual = true;}
			//Evento que se desencadena al Momento de perder el foco el Obj Numerico
			function NewonBlur()
			{
				NumericBox_IE_ParseAdd(this, ' ', ',', '.');
				if (EstadodeValorActual == true)//Si se ha cambiado algun valor para que vuelva a recalcular
				{ 
					var NroObj = ObtenerIDdeFiladeObjNumerico(this.id);
					AlmacenarValorenFilaActual(document.all["grid"],NroObj,this.value);
					ProcesarCalculodeFormato();
					EstadodeValorActual = false;
				}
			}
			//Permite almacenar el Valor del Obj Numerico en la Fila Actual que se encuentra el Obj
			function AlmacenarValorenFilaActual(objgrid,idFila,nValor)
			{
				var NuevoValor = Reemplazar(nValor,",","");
				objgrid.rows[idFila-1].removeAttribute("MONTORUBRO");
				objgrid.rows[idFila-1].setAttribute("MONTORUBRO",NuevoValor);
			}
			//Permite Obtener el Nro de Fila Actual en la cual se encuentra pocicionado el Cursor sobre el Obj Numerico
			function ObtenerIDdeFiladeObjNumerico(strNombreObjNumerico)
			{
				var Nombre1 = Reemplazar(strNombreObjNumerico,NombreDefault1,"");
				var NroObj = Reemplazar(Nombre1,NombreDefault2,"");
				return 	NroObj;							
			}
			
			function ProcesarFormatoAlSalir()
			{
				if (document.all["chkAplicar"].checked ==true){this.ProcesarCalculodeFormato();}
			}
			
			function TotalizarRubro(strFormula)
			{
				var pos=0;
				var Signo ="";
				var Total=0;
				var totalTmp=0;
				while (strFormula.length >0)
				{
					if (!isDigit(strFormula.charAt(pos)))
						{
							var DataCol="";
							var stridRubro = "";
							if (strFormula.charAt(pos)=="@")
							{
								stridRubro = strFormula.substring(0,pos);
								DataCol= ObtenerValordeRubro(stridRubro,'MONTORUBRO');
								totalTmp =Total;
								Total = Calcular(totalTmp,DataCol,Signo);
								break;							
							}
							else
							{
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
			
			function ObtenerValordeRubro(strIdRubro,STRTAG)
			{
				var objgrid = document.all["grid"];
				for(var i=1;i<= objgrid.rows.length-1;i++)
				{
					if(parseInt(objgrid.rows[i].getAttribute("IDRUBRO"))== parseInt(strIdRubro))
					{
						return objgrid.rows[i].getAttribute(STRTAG);
					}
				}
				return 0; 
			}
			
			
			function Calcular(Total,DataCol,Signo)
			{
				var oTotal=0;
				if (Signo=="+")
				{oTotal = parseFloat(Total) + parseFloat(DataCol);}
				else if(Signo=="-")
				{oTotal = parseFloat(Total) - parseFloat(DataCol);}
				else
				{oTotal = parseFloat(DataCol);}
				return oTotal;
			}
			
			function CalculoPorPrioridad(Prioridad)
			{
				var objgrid = document.all["grid"];
				var arrRowFormula = objgrid.getAttribute("FILAFORMULA").split(";");
				arrRowFormula.pop();
				
				for(var i=0;i<= arrRowFormula.length-1;i++)
				{
					var idFila = arrRowFormula[i];
					if(parseInt(objgrid.rows[idFila].getAttribute("PRIORIDAD"))== parseInt(Prioridad))
					{
						var strFormula=objgrid.rows[idFila].getAttribute("FORMULA");
						var TotalData = TotalizarRubro(strFormula);
						
						var newidNombre = (parseInt(idFila)+1);
						var objtxt = document.all[NombreDefault1 + newidNombre + NombreDefault2];
						if (objtxt != undefined)
						{
							objtxt.value = TotalData;
						}
						objgrid.rows[idFila].removeAttribute("MONTORUBRO");
						objgrid.rows[idFila].setAttribute("MONTORUBRO",TotalData);
					}
				}
			}
			
			
			function ProcesarCalculodeFormato()
			{
					for(var p=0;p<=8;p++)
					{CalculoPorPrioridad(p);}
					
					for(var p=0;p<=8;p++)
					{CalculoPorPrioridad(p);}
			}

			//Eventos para guardar la Informacion modificada
			function ConfirmaGrabar() 
			{
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var Linea = "---------------------------------------------------------------";
				
				return confirm(oPagina.Request.Params["NFormato"].toString().toUpperCase() +"\n" + Linea + '\n Desea guardar los cambios de este formato ahora?: ');
			}

			function ObtenerDataModificada()
			{
				if (ConfirmaGrabar())
				{
					var strData="";
					var strDataPrueba="";
					var objgrid = document.all["grid"];
					for(var i=1;i<= objgrid.rows.length-1;i++)
					{
						var V1 =Reemplazar(objgrid.rows[i].getAttribute("OBSERVACIONES"),'<','¿');
						var strObservacion =Reemplazar(V1,'>','?');
						//strData += objgrid.rows[i].getAttribute("MODO") + "*" + objgrid.rows[i].getAttribute("IDRUBRO") + "*"  + objgrid.rows[i].cells(5).innerText + "*" + strObservacion + "@";
						strData += objgrid.rows[i].getAttribute("MODO") + "*" + objgrid.rows[i].getAttribute("IDRUBRO") + "*"  + strObservacion + "@";
					}
					MostrarDatosEnCajaTexto("hTramaData",strData);
				}
				else
				{
					window.alert("Operación Cancelada...");
					return false;
				}
				
			}
			
			
				//Popup de espera			
				var objPopupEspera = window.createPopup();
				function EFPopupDeEsperaShow()
				{
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
				function EFPopupDeEsperaClose()
				{
					objPopupEspera.hide();
				}
				
			
			var NODOSELECCIONADO="NodoSeleccionado";
			
			function RestauraNodoSeleccionado()
			{
				var oDataGrid = document.all["grid"];
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var NodoValor = oPagina.Request.Params[NODOSELECCIONADO];
				if (NodoValor!= false)
				{
					var arrNiveles = NodoValor.split(".");
					var UltElemento = arrNiveles.length-1;
					var Indice=0;
					var stNivelFind =ElaborarNiveles(Indice,arrNiveles);
					for(var Fila=0;Fila<=oDataGrid.rows.length-1;Fila++)
					{
						if (oDataGrid.rows[Fila].NRONIVEL == stNivelFind)
						{
							if (Indice<UltElemento)
							{
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
			
			function ElaborarNiveles(Indice,arrNiveles)
			{
				var stNivelFind="";
				for(var i=0;i<=Indice;i++){	stNivelFind += arrNiveles[i] + ".";}
				return stNivelFind.substring(0,stNivelFind.length-1);
			}

		</script>
	</HEAD>
	<body onkeydown="if(event.keyCode==13){return false;}" bottomMargin="0" leftMargin="0"
		topMargin="0" rightMargin="0" onload="RestauraNodoSeleccionado();ObtenerHistorial();AsignarEventodeSalidayCambio();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3" align="center" width="100%">
						<TABLE class="normal" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="left" width="100%" colSpan="3">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f5f5f5">
											<TD align="left"></TD>
											<TD><INPUT id="chkAplicar" title="Aplicar formula" style="DISPLAY: none; WIDTH: 28px; HEIGHT: 20px"
													type="checkbox" CHECKED></TD>
											<TD align="right">
												<asp:imagebutton id="imgbtnGrabar" runat="server" ImageUrl="../../../imagenes/ibtnGrabar.GIF"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<cc1:datagridweb id="grid" runat="server" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
										DataKeyField="IdRubro">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="nombre" HeaderText="CONCEPTO"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="CONC">
												<ItemTemplate>
													<asp:Image id="imgBtnDescripcion" runat="server" ImageUrl="../../../imagenes/BtPU_Mas.gif"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb>
									<DIV align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></DIV>
									<asp:label id="Label1" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><INPUT id="hTramaData" style="WIDTH: 28px; HEIGHT: 22px" type="hidden" size="1" runat="server"
										DESIGNTIMEDRAGDROP="188" NAME="hTramaData"><INPUT id="hModo" style="WIDTH: 55px; HEIGHT: 22px" type="hidden" size="3" name="hModo"
										runat="server" DESIGNTIMEDRAGDROP="64"><INPUT id="hCodigo" style="WIDTH: 24px; HEIGHT: 14px" type="hidden" size="1" value="1"
										name="hCodigo" runat="server" DESIGNTIMEDRAGDROP="194"><INPUT id="hvalida" style="WIDTH: 24px; HEIGHT: 14px" type="hidden" size="1" value="1"
										name="hvalida" runat="server"><INPUT id="hIdRubro" style="WIDTH: 26px; HEIGHT: 22px" type="hidden" size="1" name="hIdRubro"
										runat="server"><INPUT id="hTiempoHabilitado" style="WIDTH: 26px; HEIGHT: 22px" type="hidden" size="1"
										name="hIdRubro" runat="server" value="1"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
