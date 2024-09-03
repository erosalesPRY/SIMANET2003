<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultaDeEstadosFinancierosPERU.aspx.cs" ValidateRequest="true" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.ConsultaDeEstadosFinancierosPERU" %>
<%@ Register TagPrefix="uc1" TagName="ParametroContable" Src="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
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
							objgrid.rows[i].removeAttribute("OBSERVACIONES");
							objgrid.rows[i].setAttribute("OBSERVACIONES",Datos[0]);
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
			{return confirm('Desea Guardar los Cambios ahora: ');}

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
						strData += objgrid.rows[i].getAttribute("MODO") + "*" + objgrid.rows[i].getAttribute("IDRUBRO") + "*"  + objgrid.rows[i].getAttribute("MONTORUBRO") + "*" + strObservacion + "@";
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
		</script>
	</HEAD>
	<body onkeydown="if(event.keyCode==13){return false;}" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial();AsignarEventodeSalidayCambio();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD class="RutaPaginaActual"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Estados Financieros</asp:label></TD>
				</TR>
				<TR bgColor="#f0f0f0">
					<TD align="right"><INPUT id="chkAplicar" title="Aplicar formula" style="DISPLAY: none; WIDTH: 28px; HEIGHT: 20px"
							type="checkbox" CHECKED>
						<asp:imagebutton id="imgbtnGrabar" runat="server" ImageUrl="../../imagenes/ibtnGrabar.GIF"></asp:imagebutton></TD>
				</TR>
				<TR>
					<TD align="center"><cc1:datagridweb id="grid" runat="server" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
							DataKeyField="IdRubro">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="Concepto" HeaderText="CONCEPTO">
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn Visible="False" HeaderText="MONTO">
									<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<ew:numericbox id="nMonto" runat="server" CssClass="normaldetalle" Width="125px" PlacesBeforeDecimal="15"
											TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
											DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False" HeaderText="FORM">
									<HeaderStyle Font-Bold="True" Width="5%"></HeaderStyle>
									<ItemStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:Image id="imgFormula" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif" Visible="False"></asp:Image>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False" HeaderText="DET">
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
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center">
						<DIV align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></DIV>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="Label1" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD><INPUT id="hTramaData" style="WIDTH: 28px; HEIGHT: 22px" type="hidden" size="1" name="hTramaData"
							runat="server"><INPUT id="hModo" style="WIDTH: 55px; HEIGHT: 22px" type="hidden" size="3" name="hModo"
							runat="server"><INPUT id="hCodigo" style="WIDTH: 24px; HEIGHT: 14px" type="hidden" size="1" value="1"
							name="hCodigo" runat="server"><INPUT id="hvalida" style="WIDTH: 24px; HEIGHT: 14px" type="hidden" size="1" value="1"
							name="hvalida" runat="server"><INPUT id="hIdRubro" style="WIDTH: 26px; HEIGHT: 22px" type="hidden" size="1" name="hIdRubro"
							runat="server"></TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
