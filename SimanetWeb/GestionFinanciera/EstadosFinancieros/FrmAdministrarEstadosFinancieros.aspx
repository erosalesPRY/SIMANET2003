<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="ParametroContable" Src="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="FrmAdministrarEstadosFinancieros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.FrmAdministrarEstadosFinancieros" %>
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
			var contador = 0;
		
			function ConfirmaGrabar() 
			{return confirm('Desea Guardar los Cambios ahora: ');}

			
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
								DataCol= ObtenerValordeRubro(stridRubro);
								totalTmp =Total;
								Total = Calcular(totalTmp,DataCol,Signo);
								break;							
							}
							else
							{
								stridRubro = strFormula.substring(0,pos);
								DataCol = ObtenerValordeRubro(stridRubro);
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
			
			function ObtenerValordeRubro(strIdRubro)
			{
				var objgrid = document.all["grid"];
				for(var i=1;i<= objgrid.rows.length-1;i++)
				{
					if(parseInt(objgrid.rows[i].getAttribute("IDRUBRO"))== parseInt(strIdRubro))
					{
						return objgrid.rows[i].getAttribute("MONTORUBRO");
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
						var objCell=  objgrid.rows[idFila].cells(5);
						var strFormula=objgrid.rows[idFila].getAttribute("FORMULA");
						var TotalData = TotalizarRubro(strFormula);
						objCell.innerText = TotalData;
						objgrid.rows[idFila].removeAttribute("MONTORUBRO");
						objgrid.rows[idFila].setAttribute("MONTORUBRO",TotalData);
					}
				}
			}
			
			var RemoteCelda=null;
			var idFilaSeleccionada=0;
			function AbrirEditordeCelda(objDelda,idFila)
			{
				//window.clipboardData.setData("Text",objDelda.innerText);
				localStorage.setItem('History',objDelda.innerText);
				
				RemoteCelda = objDelda;
				idFilaSeleccionada = (idFila-1);
				miVentana=window.showModalDialog("FormTextoEdit.aspx",window,"dialogHeight: 105px; dialogWidth: 167px;edge: Raised; center: Yes; help: no; resizable: no; status: no;");
				//Se ejecuta despues de cerrar la Ventana de dialogo
				if (document.all["chkAplicar"].checked ==true)
				{
					this.ProcesarCalculodeFormato();
				}
			}
			
			function AsignarValor(valor)
			{
				var objgrid = document.all["grid"];
				objgrid.rows[idFilaSeleccionada].removeAttribute("MONTORUBRO");
				objgrid.rows[idFilaSeleccionada].setAttribute("MONTORUBRO",valor);
				objgrid.rows[idFilaSeleccionada].cells(5).innerText = valor;
				//RemoteCelda.innerText = valor;
			}
			
			function ProcesarCalculodeFormato()
			{
				for(var p=0;p<=15;p++)
				{
					CalculoPorPrioridad(p);
				}
			}


			function ObtenerDataModificada()
			{
				if (ConfirmaGrabar())
				{
					var strData="";
					var objgrid = document.all["grid"];
					for(var i=1;i<= objgrid.rows.length-1;i++)
					{
						strData += objgrid.rows[i].getAttribute("MODO") + "*" + objgrid.rows[i].getAttribute("IDRUBRO") + "*"  + objgrid.rows[i].cells(5).innerText + "@";
					}
					MostrarDatosEnCajaTexto("hTramaData",strData);
				}
				else
				{
					window.alert("Operación Cancelada...");
					return false;
				}
				
			}

			function AbrirEditordeDetalle(pidCentro,pFormato,pidRubro,pPeriodo,pidMes,pidTipoInformacion)
			{
				var KEYQIDFORMATO = "IdFormato";
				var KEYQIDRUBRO= "IdRubro";
				var KEYQIDCENTRO = "IdCentro";
				var KEYQIDTIPOINFO= "idTipoInfo";
				var KEYQPERIODO= "Periodo";
				var KEYQMES= "IdMes";
				var querystring  = KEYQIDCENTRO + "=" + pidCentro + "&" + KEYQIDFORMATO + "=" + pFormato + "&" + KEYQIDRUBRO + "=" + pidRubro + "&" + KEYQIDTIPOINFO + "=" + pidTipoInformacion + "&" + KEYQPERIODO + "=" + pPeriodo  + "&" + KEYQMES + "=" + pidMes;
				miVentana=window.showModalDialog("AdministarFormatoRubroDetalleMovimiento.aspx?" + querystring,window,"dialogHeight: 400px; dialogWidth: 600px;edge: Raised; center: Yes; help: no; resizable: no; status: no;");
			}

		</script>
	</HEAD>
	<body onkeydown="if(event.keyCode==13){return false;}" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table style="HEIGHT: 296px" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<tr>
					<td width="100%" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR>
					<TD width="100%" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" width="100%" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Estados Financieros</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 312px" colSpan="3">
						<P align="center">
							<TABLE class="normal" id="Table2" style="WIDTH: 778px; HEIGHT: 251px" cellSpacing="0" cellPadding="0"
								width="778" border="0">
								<TR>
									<TD colSpan="3">
										<DIV align="left">
											<TABLE class="tabla" id="TblTabs" style="HEIGHT: 36px" cellSpacing="0" cellPadding="0"
												width="100%" align="left" bgColor="#f5f5f5" border="0" runat="server">
												<TR>
													<TD></TD>
													<TD style="WIDTH: 371px"><asp:panel id="Panel" runat="server" Width="376px">Panel</asp:panel>
													</TD>
													<TD vAlign="bottom" align="left"><asp:button id="btnConsultar" style="FONT-SIZE: 8pt; COLOR: #ffffcc; FONT-FAMILY: Arial Narrow; BACKGROUND-COLOR: #306898"
															runat="server" Text="Consultar"></asp:button></TD>
												</TR>
											</TABLE>
										</DIV>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 13px" align="center" width="100%" colSpan="3"></TD>
								</TR>
								<TR>
									<TD align="center" width="100%" colSpan="3">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR bgColor="#f0f0f0">
												<TD style="WIDTH: 99px"><asp:imagebutton id="imgProcesar" runat="server" DESIGNTIMEDRAGDROP="44" ImageUrl="../../imagenes/Procesar.gif"></asp:imagebutton></TD>
												<TD style="WIDTH: 14px"></TD>
												<TD width="100%">&nbsp;</TD>
												<TD style="WIDTH: 5px"></TD>
												<TD style="WIDTH: 209px"><asp:imagebutton id="imgbtnGrabar" runat="server" ImageUrl="../../imagenes/ibtnGrabar.GIF"></asp:imagebutton></TD>
												<TD></TD>
												<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
											</TR>
										</TABLE>
										<cc1:datagridweb id="grid" runat="server" Width="100%" DataKeyField="IdRubro" RowHighlightColor="#E0E0E0"
											AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle CssClass="FooterGrilla"></FooterStyle>
											<Columns>
												<asp:BoundColumn DataField="Concepto" HeaderText="CONCEPTO"></asp:BoundColumn>
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
												<asp:BoundColumn DataField="MONTOENERO" HeaderText="ENERO">
													<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="MONTOFEBRERO" HeaderText="FEBRERO"></asp:BoundColumn>
												<asp:BoundColumn DataField="MONTOMARZO" HeaderText="MARZO"></asp:BoundColumn>
												<asp:BoundColumn DataField="MONTOABRIL" HeaderText="ABRIL"></asp:BoundColumn>
												<asp:BoundColumn DataField="MONTOMAYO" HeaderText="MAYO"></asp:BoundColumn>
												<asp:BoundColumn DataField="MONTOJUNIO" HeaderText="JUNIO"></asp:BoundColumn>
												<asp:BoundColumn DataField="MONTOJULIO" HeaderText="JULIO"></asp:BoundColumn>
												<asp:BoundColumn DataField="MONTOAGOSTO" HeaderText="AGOSTO"></asp:BoundColumn>
												<asp:BoundColumn DataField="MONTOSETIEMBRE" HeaderText="SETIEMBRE"></asp:BoundColumn>
												<asp:BoundColumn DataField="MONTOOCTUBRE" HeaderText="OCTUBRE"></asp:BoundColumn>
												<asp:BoundColumn DataField="MONTONOVIEMBRE" HeaderText="NOVIEMBRE"></asp:BoundColumn>
												<asp:BoundColumn DataField="MONTODICIEMBRE" HeaderText="DICIEMBRE"></asp:BoundColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb>
										<DIV align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></DIV>
										<asp:label id="Label1" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
								</TR>
								<TR>
									<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hTramaData" style="WIDTH: 28px; HEIGHT: 22px" type="hidden" size="1" runat="server"
											DESIGNTIMEDRAGDROP="188" NAME="hTramaData"><INPUT id="hModo" style="WIDTH: 55px; HEIGHT: 22px" type="hidden" size="3" name="hModo"
											runat="server"><INPUT id="hCodigo" style="WIDTH: 24px; HEIGHT: 14px" type="hidden" size="1" value="1"
											name="hCodigo" runat="server" DESIGNTIMEDRAGDROP="194"><INPUT id="hvalida" style="WIDTH: 24px; HEIGHT: 14px" type="hidden" size="1" value="1"
											name="hvalida" runat="server"></TD>
								</TR>
							</TABLE>
						</P>
					</TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
