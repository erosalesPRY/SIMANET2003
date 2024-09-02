<%@ Page language="c#" Codebehind="ConsultarCartaFianza.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasFianza.ConsultarCartaFianza" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<!--		<STYLE type="text/css">A:hover { TEXT-DECORATION: underline }
	.U { BORDER-RIGHT: #999999 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: #999999 1px solid; PADDING-LEFT: 1px; Z-INDEX: 100; LEFT: 0px; VISIBILITY: visible; PADDING-BOTTOM: 1px; OVERFLOW: visible; BORDER-LEFT: #999999 1px solid; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: #999999 1px solid; WHITE-SPACE: nowrap; POSITION: absolute; TOP: 0px; BACKGROUND-COLOR: #f5f5f5; LAYER-BACKGROUND-COLOR: #e9f2f8 }
	.W { PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 1px; PADDING-TOP: 1px }
	.V { PADDING-RIGHT: 0px; BORDER-TOP: #999999 1px solid; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; HEIGHT: 1px }
	.y { PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 1px; COLOR: #8d8d8d; PADDING-TOP: 1px }
	.P { PADDING-RIGHT: 4px; PADDING-LEFT: 4px; CURSOR: hand }
	.T { BORDER-RIGHT: #336699 1px solid; PADDING-RIGHT: 0px; BORDER-TOP: #336699 1px solid; PADDING-LEFT: 0px; BORDER-LEFT: #336699 1px solid; CURSOR: hand; BORDER-BOTTOM: #336699 1px solid; BACKGROUND-COLOR: #e9f2f8 }
	.X { BORDER-RIGHT: #336699 1px solid; PADDING-RIGHT: 0px; BORDER-TOP: #336699 1px solid; PADDING-LEFT: 0px; BORDER-LEFT: #336699 1px solid; BORDER-BOTTOM: #336699 1px solid; BACKGROUND-COLOR: #c1cdd8 }
		</STYLE>
		oncontextmenu="return false" 
-->
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<script>
			/*function LoadPaginaDetalle()
			{
				var grilla = document.all["grid"];
				if(grilla.rows.length==4)
				{
					var strlista = grilla.rows[1].getAttribute("HISTORIAL");
					HistorialIrAdelantePersonalizado(strlista);
					window.location.href = grilla.rows[1].getAttribute("PAGINA");
				}
			}*/
			
			function VistaPrevia(e)
			{
				oHtml = new SIMA.Utilitario.Helper.General.Html();
				/*Crea el titulo principal del reporte*/
				ohtmlFuente = oHtml.CrearFuente();
				with (ohtmlFuente)
				{
					innerText = "CARTA FIANZA";
					setAttribute("face","arial"); 
					setAttribute("size","4");
					setAttribute("color","black");
				}
				/*Crea la Cabecera y agrega un Objeto de tipo Font*/
				oCabecera = new SIMA.Utilitario.Helper.CabeceraPagina();
				oCabecera.CenterTop(ohtmlFuente);

				oPrinter = new SIMA.Utilitario.Helper.Prints();
				oPrinter.htmlTablaContenedora= document.all["tblCabeceraPrint"];
				oPrinter.ConfigurarCabecera(oCabecera);
				oPrinter.VistaPrevia(e,Cabecera,FilaMenu,FilaToolBar,CeldaAbajo);
			}
			function MostrarHtml()
			{
				var Comilla = String.fromCharCode(34);
				var objGrid = document.all["grid"];
				
				photoWin = window.open( "", "photo", "width=600,height=800,status,scrollbars=yes,resizable, screenX=20,screenY=40,left=20,top=40"); 
				// wrote content to window 
				photoWin.document.write('<html><head><title> prueba</title>')
				photoWin.document.write('<LINK href=' +  Comilla + '../../styles.css' +  Comilla + ' type=' +  Comilla + 'text/css' +  Comilla + ' rel=' +  Comilla + 'stylesheet' +  Comilla + '>');
				photoWin.document.write('</head>');
				photoWin.document.write('<BODY bottomMargin=0 leftMargin=0 topMargin=0 rightMargin=0>');
				photoWin.document.write('<div style=' + Comilla + 'BORDER-RIGHT: #999999 1px solid; PADDING-RIGHT: 20px; BORDER-TOP: #999999 1px solid; PADDING-LEFT: 20px; PADDING-BOTTOM: 20px; MARGIN: 2px; BORDER-LEFT: #999999 1px solid; PADDING-TOP: 20px; BORDER-BOTTOM: #999999 1px solid' + Comilla + '>');
				photoWin.document.write('<table>' + objGrid.innerHTML.toString() + '</table>');
				photoWin.document.write('</div>');
				//photoWin.document.write('<table>' + strHtml + '</table>');
				photoWin.document.write('</body></html>'); 
				photoWin.document.close(); 
				photoWin.focus(); 
			}
			
		</script>
	</HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" id="tblCabeceraPrint">
				<tr id="Cabecera">
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr id="FilaMenu">
					<td vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Carta Fianza</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="tbl" cellSpacing="1" cellPadding="1" width="830" border="0">
							<TR>
								<TD>
									<TABLE style="Z-INDEX: 0; WIDTH: 744px; HEIGHT: 16px" id="TblTabs" class="tabla" border="0"
										cellSpacing="0" cellPadding="0" width="744" bgColor="#f5f5f5" align="left" runat="server">
										<TR>
											<TD align="left">
												<asp:label id="Label2" runat="server" CssClass="TextoNegroNegrita"> Fianzas:</asp:label></TD>
											<TD align="left">
												<asp:dropdownlist id="ddlbModalidadCartaFianza" runat="server" CssClass="combos" AutoPostBack="True"
													Width="228px"></asp:dropdownlist></TD>
											<TD align="left">
												<asp:label id="Label4" runat="server" CssClass="TextoNegroNegrita">Estado:</asp:label></TD>
											<TD align="left">
												<asp:dropdownlist id="ddlbEstadoCartaFianza" runat="server" CssClass="combos" AutoPostBack="True"
													Width="228px"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="tblMasterContenedor" style="WIDTH: 740px; HEIGHT: 2px" cellSpacing="0" cellPadding="0"
										width="740" border="0">
										<TR id="FilaToolBar" bgColor="#f0f0f0">
											<TD style="WIDTH: 5px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 88px"><asp:imagebutton id="ibtnFiltrar" runat="server" DESIGNTIMEDRAGDROP="62" ImageUrl="../../imagenes/filtrar.gif"
													CausesValidation="False"></asp:imagebutton></TD>
											<TD style="WIDTH: 114px"><IMG id="ibtnFiltrarSeleccion" title="NroCartaFianza" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
													alt="Aplicar Filtro por Selección" src="../../imagenes/filtroporseleccion.jpg" runat="server"></TD>
											<TD style="WIDTH: 35px"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													CausesValidation="False" ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD style="WIDTH: 41px"><asp:label id="Label1" runat="server" CssClass="normaldetalle" Width="53px" Font-Bold="True"> Buscar :</asp:label></TD>
											<TD width="100%"><INPUT class="InputFind" id="txtBuscar" onkeydown="BusquedaporCampoColumna(this.value);"
													title="Buscar por la Columna Seleccionada" style="BORDER-BOTTOM: #999999 1px groove; BORDER-LEFT: #999999 1px groove; WIDTH: 100%; BORDER-TOP: #999999 1px groove; BORDER-RIGHT: #999999 1px groove"
													size="32"></TD>
											<TD width="100%"><asp:imagebutton id="imgbtnImportar" runat="server" ImageUrl="../../imagenes/btnImportaciones/btnImportarCartaFianza.gif"></asp:imagebutton></TD>
											<TD width="100%"></TD>
											<TD><IMG id="ImgImprimir" onclick="VistaPrevia(this);" alt="" src="../../imagenes/bt_imprimir.gif"></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="100%" ShowFooter="True" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" PageSize="9">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroCartaFianza" SortExpression="NroCartaFianza" HeaderText="NRO FZA">
												<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Centro" SortExpression="Centro" HeaderText="CO">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="ENTIDAD FINANCIERA">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Beneficiario" SortExpression="Beneficiario" HeaderText="BENEFICIARIO">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="FECHA">
												<HeaderTemplate>
													<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left">
														<TR>
															<TD style="DISPLAY: none; BORDER-RIGHT: #cccccc 1px solid" rowSpan="2" width="10%" align="center">
																<asp:Label id="Label7" runat="server" Width="28px" ToolTip="Numero de la Última Renovación"
																	Font-Bold="True">NRO<BR>U.R</asp:Label></TD>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; HEIGHT: 10px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"
																width="80%" colSpan="3" align="center">
																<asp:Label id="lblFechas" runat="server" CssClass="HeaderGrilla" Font-Bold="True" BorderStyle="None"
																	Height="3px">FECHA</asp:Label></TD>
														</TR>
														<TR>
															<TD height="3" width="51" align="center">
																<asp:Label id="Label8" runat="server" CssClass="HeaderGrilla" Width="51px" DESIGNTIMEDRAGDROP="175"
																	ToolTip="Fecha de Apertura" Font-Bold="True" BorderStyle="None">INICIO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" height="3" width="51" align="center">
																<asp:Label id="Label6" runat="server" CssClass="HeaderGrilla" Width="50px" ToolTip="Fecha de Renovación"
																	Font-Bold="True" BorderStyle="None">RENOVA.</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" height="3" width="51" align="center">
																<asp:Label id="Label5" tabIndex="3" runat="server" CssClass="HeaderGrilla" Width="50px" ToolTip="Fecha de vencimiento"
																	Font-Bold="True" BorderStyle="None">VENCE</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table6" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left"
														height="100%">
														<TR>
															<TD style="DISPLAY: none" vAlign="bottom" width="14%" align="center">
																<asp:Label id="lblNroRenov" runat="server" CssClass="ItemGrillaSinColor" Width="31px" DESIGNTIMEDRAGDROP="228"
																	Height="18px">0</asp:Label></TD>
															<TD vAlign="middle" width="51" align="center">
																<asp:Label id="lblFechaIni" runat="server" CssClass="normaldetalle" Width="58px" Height="12px">Label</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" vAlign="middle" width="51" align="center">
																<asp:Label id="lblFechaRenov" runat="server" CssClass="normaldetalle" Width="58px" DESIGNTIMEDRAGDROP="386"
																	Height="12px">Label</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" vAlign="middle" width="51" align="center">
																<asp:Label id="lblFechaVence" runat="server" CssClass="normaldetalle" Width="58px" Height="12px">Label</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="NroDiasFaltantes" SortExpression="NroDiasFaltantes" HeaderText="DIAS">
												<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoCartaFza" SortExpression="MontoCartaFza" HeaderText="MONTO">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<ItemTemplate>
													<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 16px" align="left">
									<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
										<TR>
											<TD style="WIDTH: 50px" vAlign="top"><asp:label id="Label3" runat="server" CssClass="TextoNegroNegrita"> Concepto:</asp:label></TD>
											<TD><asp:textbox id="txtConcepto" runat="server" CssClass="normal" Width="100%" Height="32px" TextMode="MultiLine"
													EnableViewState="False" ReadOnly="True" BorderStyle="Groove"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD noWrap align="left" id="CeldaAbajo"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server"><INPUT type="button" value="Button" onclick="MostrarHtml();" style="DISPLAY: none">
									<asp:Button id="Button2" runat="server" Text="Imprimir" Visible="False"></asp:Button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" align="center" width="100%"><asp:placeholder id="phFiltro" runat="server"></asp:placeholder><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label>
						<font face="verdana" size="1" style="FONT-WEIGHT: bold"></font>
					</TD>
					<td>
						<div style="BORDER-BOTTOM: #999999 1px solid; BORDER-LEFT: #999999 1px solid; PADDING-BOTTOM: 10px; MARGIN: 5px; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; BORDER-TOP: #999999 1px solid; BORDER-RIGHT: #999999 1px solid; PADDING-TOP: 10px">
						</div>
					</td>
				</TR>
			</table>
			<!--
			<div class="U" id="tblPopup" style="LEFT: 0px; BACKGROUND-IMAGE: url(C:\Documents and Settings\sima\Escritorio\Iconos\FranjaMenu.gif); VISIBILITY: hidden; WIDTH: 314px; BACKGROUND-REPEAT: repeat-y; POSITION: absolute; TOP: 350px; HEIGHT: 72px"
				onmouseout="FlagPopupAct=false;">
				<table id="tblPopup1" width="100%" align="left">
					<TR>
						<TD class="W" id="btnFiltros" onmouseover="oPopupMenu.MouseOver(this);" onclick="FiltroporSeleccion(2);oPopupMenu.Click();"
							onmouseout="oPopupMenu.MouseOut(this);"><IMG alt="Filtro por Seleccion" hspace="1" src="C:\Documents and Settings\sima\Escritorio\Iconos\btnFiltroPorSeleccion.gif"
								align="absBottom" border="0"> Filtro por Seleccion
						</TD>
					</TR>
					<TR>
						<TD class="V"><IMG height="1" src="Imagenes/spacer.gif" width="1"></TD>
					</TR>
					<TR>
						<TD>
							<table cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
								<tr>
									<td width="10%">Filtro:
									</td>
									<td class="W" id="tdbtnOperador" onmouseover="oPopupMenu.MouseOver(this);" onclick="AparienciaBtnFiltro(1);FlagPopupAct=true;MenuContext(oPopupMenu.NombretblPopupOperador);"
										onmouseout="oPopupMenu.MouseOut(this);" width="10%"><IMG src="C:\Documents and Settings\sima\Escritorio\Iconos\btnFiltroPopup.gif" align="absMiddle">
									</td>
									<td id="Operador" width="50%">igual a&nbsp;
									</td>
									<td width="30%">
										<INPUT id="txtvalor" tabIndex="10" type="text" onmouseout="FlagPopupAct=true;" onkeydown="ElaboraQueryFiltro();"
											onclick="FlagPopupAct =true;OcultarSubMenuPopup();" style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BORDER-BOTTOM: #999999 1px solid">
									</td>
								</tr>
							</table>
						</TD>
					</TR>
					<TR>
						<TD class="V"><img height="1" src="Imagenes/spacer.gif" width="1"></TD>
					</TR>
					<TR>
						<TD class="W" onmouseover="oPopupMenu.MouseOver(this);" onclick="EliminarFiltro();oPopupMenu.Click();"
							onmouseout="oPopupMenu.MouseOut(this);"><IMG alt="Eliminar" hspace="1" src="C:\Documents and Settings\sima\Escritorio\Iconos\btnFiltroQuitar.gif"
								align="absMiddle" border="0"> Quitar&nbsp;Filtro&nbsp;<INPUT id="txtvalorCriterio" style="WIDTH: 46px; HEIGHT: 14px" type="hidden" size="2" name="txtvalorCriterio"></TD>
					</TR>
				</table>
			</div>
			<div class="U" id="tblPopupOperador" style="LEFT: 0px; BACKGROUND-IMAGE: url(C:\Documents and Settings\sima\Escritorio\Iconos\FranjaMenu.gif); VISIBILITY: hidden; WIDTH: 168px; BACKGROUND-REPEAT: repeat-y; POSITION: absolute; TOP: 80px; HEIGHT: 182px">
				<TABLE id="tblPopupOperador1" width="100%" align="left">
					<TR>
						<TD class="W" id="Td1" onmouseover="oPopupMenu.MouseOver(this);" onclick="AsignarOperador('que Contenga','que contenga');"
							onmouseout="oPopupMenu.MouseOut(this);">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;que 
							contenga</TD>
					</TR>
					<TR>
						<TD class="W" onmouseover="oPopupMenu.MouseOver(this);" style="HEIGHT: 20px" onclick="AsignarOperador('que inicie con','que inicie con');"
							onmouseout="oPopupMenu.MouseOut(this);">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; que 
							inicie con</TD>
					</TR>
					<TR>
						<TD class="W" onmouseover="oPopupMenu.MouseOver(this);" onclick="AsignarOperador('que finalice con','que finalice con');"
							onmouseout="oPopupMenu.MouseOut(this);">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; que 
							finalice con</TD>
					</TR>
					<TR>
						<TD class="W" onmouseover="oPopupMenu.MouseOver(this);" onclick="AsignarOperador('igual','=');"
							onmouseout="oPopupMenu.MouseOut(this);">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; igual
						</TD>
					</TR>
					<TR>
						<TD class="W" onmouseover="oPopupMenu.MouseOver(this);" onclick="AsignarOperador('mayor que','>');"
							onmouseout="oPopupMenu.MouseOut(this);">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; mayor 
							que</TD>
					</TR>
					<TR>
						<TD class="W" onmouseover="oPopupMenu.MouseOver(this);" onclick="AsignarOperador('mayor o igual que','>=');"
							onmouseout="oPopupMenu.MouseOut(this);">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; mayor o 
							igual que a</TD>
					</TR>
					<TR>
						<TD class="W" onmouseover="oPopupMenu.MouseOver(this);" onclick="AsignarOperador('menor que','<');"
							onmouseout="oPopupMenu.MouseOut(this);">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; menor 
							que</TD>
					</TR>
					<TR>
						<TD class="W" onmouseover="oPopupMenu.MouseOver(this);" onclick="AsignarOperador('menor o igual que','<=');"
							onmouseout="oPopupMenu.MouseOut(this);">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; menor o 
							igual que</TD>
					</TR>
				</TABLE>
			</div>
			--></form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
			/*document.body.onkeydown=OcultarporEventoKeyDown;
			document.body.onclick=sClick;
			*/
		</SCRIPT>
		<DIV></DIV>
	</body>
</HTML>
