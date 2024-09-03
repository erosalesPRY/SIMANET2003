<%@ Register TagPrefix="cc2" Namespace="ControlesWeb" Assembly="ControlesWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="PopupImpresionEstadosFinancieros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.PopupImpresionEstadosFinancieros" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PopupImpresionEstadosFinancieros</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<script>
			var oMiPopup = window.createPopup();
				//Dialogo de Espera
				function showPopupSolvenciaLiquidez(intPopup) 
				{
					var intPopupWidth = 342;
					var intPopupHeight = 130;
					var xleft= event.x; //(window.screen.width/2) - (intPopupWidth/2);
					var yTop=  event.y;//(window.screen.height/2) - (intPopupHeight/2);
					//oMiPopup.style.font.size=10;
					oMiPopup.document.body.innerHTML= parseInt(intPopup)==1? ppLiquidez.innerHTML:ppSolvensia.innerHTML;
					
					oMiPopup.show(xleft, yTop, intPopupWidth, intPopupHeight,document.body);
				}
				
				function ClosePopupSolvenciaLiquidez() 
				{
					if (oMiPopup.isOpen)
					{oMiPopup.hide();}
					
				}
				function ShowPopupLS(id)
				{
					if (id==1)
					{
						ppSolvensia.style.display="none";
						ppLiquidez.style.display="block";
						ppLiquidez.style.left=window.event.x;
						ppLiquidez.style.top=window.event.y;
					}
					else
					{
						ppLiquidez.style.display="none";
						ppSolvensia.style.display="block";
						ppSolvensia.style.left=window.event.x;
						ppSolvensia.style.top=window.event.y;
					}
				}
				function ClosePopupSL(id)
				{
					if (id==1)
					{
						ppLiquidez.style.display="none";
					}
					else
					{
						ppSolvensia.style.display="none";
					}
					//onclick="parent.ClosePopupSolvenciaLiquidez();"
				}
				
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TABLE class="normal" id="Table2" cellSpacing="1" cellPadding="4" width="780" border="0">
							<TR>
								<TD style="WIDTH: 786px" align="center" width="786" colSpan="3">
									<TABLE id="Table3" style="HEIGHT: 27px" cellSpacing="0" cellPadding="0" width="770" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 145px"></TD>
											<TD width="100%">
												<TABLE id="Table7" style="WIDTH: 656px; HEIGHT: 27px" cellSpacing="1" cellPadding="1" width="656"
													align="left" border="0">
													<TR>
														<TD style="WIDTH: 46px"><asp:label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="80%"
																DESIGNTIMEDRAGDROP="331" Font-Bold="True">PERIODO :</asp:label></TD>
														<TD style="WIDTH: 35px"><asp:label id="lblPeriodo" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
																Width="32px" DESIGNTIMEDRAGDROP="392" Font-Bold="True"> 2005</asp:label></TD>
														<TD style="WIDTH: 24px"><asp:label id="Label2" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Font-Bold="True">MES :</asp:label></TD>
														<TD style="WIDTH: 78px"><asp:label id="lblMes" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="80%"
																DESIGNTIMEDRAGDROP="250" Font-Bold="True">Periodo :</asp:label></TD>
														<TD style="WIDTH: 97px"></TD>
														<TD><asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="80%"
																Font-Bold="True">EN MILES DE NUEVOS SOLES</asp:label></TD>
													</TR>
												</TABLE>
											</TD>
											<TD vAlign="bottom">&nbsp;</TD>
											<TD></TD>
											<TD style="WIDTH: 209px" align="right"></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="770px" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="CONCEPTO" SortExpression="CONCEPTO" HeaderText="CONCEPTO">
												<HeaderStyle Width="30%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PeruEjecucionRealDelmesAnterior" HeaderText="Mes&lt;br&gt;Anterior">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PeruEjecucionRealDelmesActual" HeaderText="Mes&lt;br&gt;Actual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Font-Bold="True" Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PeruEjecucionRealAcumulado">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PeruPresupuestoAnual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PeruProyectadoAnual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IquitosEjecucionRealDelmesAnterior">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IquitosEjecucionRealDelmesActual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Font-Bold="True" Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IquitosEjecucionRealAcumulado">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IquitosPresupuestoAnual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IquitosProyectadoAnual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TABLE id="lblSollvenciaLiquidez" style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #999999 1px solid"
							cellSpacing="0" cellPadding="0" width="770" border="1" runat="server">
							<TR class="ItemGrilla">
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 218px; BORDER-BOTTOM: buttonface 1px solid"
									align="left">&nbsp;
									<asp:label id="lblLiquidez" runat="server" DESIGNTIMEDRAGDROP="399" Width="216px">LIQUIDEZ</asp:label></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-BOTTOM: buttonface 1px solid"
									align="right"><asp:label id="lblLiquidezMesAnteriorP" runat="server" DESIGNTIMEDRAGDROP="401" Width="76px">0.00</asp:label></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 64px; BORDER-BOTTOM: buttonface 1px solid; HEIGHT: 19px"
									align="right"><asp:label id="lblLiquidezDelMesP" runat="server" DESIGNTIMEDRAGDROP="402" Width="76px">0.00</asp:label></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 62px; BORDER-BOTTOM: buttonface 1px solid; HEIGHT: 19px"
									align="right"><asp:label id="lblLiquidezPresupuestoP" runat="server" DESIGNTIMEDRAGDROP="403" Width="76px">0.00</asp:label></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 52px; BORDER-BOTTOM: buttonface 1px solid; HEIGHT: 19px"
									align="right"><asp:label id="lblLiquidezMesAnteriorI" runat="server" DESIGNTIMEDRAGDROP="404" Width="76px">0.00</asp:label></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 38px; BORDER-BOTTOM: buttonface 1px solid; HEIGHT: 19px"
									align="right"><asp:label id="lblLiquidezDelMesI" runat="server" DESIGNTIMEDRAGDROP="405" Width="76px">0.00</asp:label></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; BORDER-BOTTOM: buttonface 1px solid"
									align="right"><asp:label id="lblLiquidezPresupuestoI" runat="server" DESIGNTIMEDRAGDROP="406" Width="76px">0.00</asp:label></TD>
							</TR>
							<TR class="AlternateItemGrilla">
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 227px; BORDER-BOTTOM: buttonface 1px solid; HEIGHT: 14px"
									align="left"><asp:label id="lblSolvencia" runat="server" Width="231px">SOLVENCIA</asp:label></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-BOTTOM: buttonface 1px solid; HEIGHT: 14px"
									align="right"><asp:label id="lblSolvenciaMesAnteriorP" runat="server" DESIGNTIMEDRAGDROP="419" Width="76px">0.00%</asp:label></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-BOTTOM: buttonface 1px solid; HEIGHT: 14px"
									align="right"><asp:label id="lblSolvenciaDelMesP" runat="server" DESIGNTIMEDRAGDROP="422" Width="76px">0.00%</asp:label></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-BOTTOM: buttonface 1px solid; HEIGHT: 14px"
									align="right"><asp:label id="lblSolvenciaPresupuestoP" runat="server" DESIGNTIMEDRAGDROP="423" Width="76px">0.00%</asp:label></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-BOTTOM: buttonface 1px solid; HEIGHT: 14px"
									align="right"><asp:label id="lblSolvenciaMesAnteriorI" runat="server" DESIGNTIMEDRAGDROP="424" Width="76px">0.00%</asp:label></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-BOTTOM: buttonface 1px solid; HEIGHT: 14px"
									align="right"><asp:label id="lblSolvenciaDelMesI" runat="server" DESIGNTIMEDRAGDROP="425" Width="76px">0.00%</asp:label></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-BOTTOM: buttonface 1px solid; HEIGHT: 14px"
									align="right"><asp:label id="lblSolvenciaPresupuestoI" runat="server" Width="76px">0.00%</asp:label></TD>
							</TR>
							<TR>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 227px; BORDER-BOTTOM: buttonface 1px solid"
									align="left"></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-BOTTOM: buttonface 1px solid"></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-BOTTOM: buttonface 1px solid"></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-BOTTOM: buttonface 1px solid"></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-BOTTOM: buttonface 1px solid"></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-BOTTOM: buttonface 1px solid"></TD>
								<TD style="BORDER-RIGHT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-BOTTOM: buttonface 1px solid"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3" align="center">
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<div id="ppLiquidez" style="DISPLAY: none; LEFT: 50px; WIDTH: 440px; POSITION: absolute; HEIGHT: 106px; BACKGROUND-COLOR: #ffffff">
							<TABLE class="normaldetalle" id="Table4" style="LEFT: 150px; WIDTH: 444px; HEIGHT: 88px"
								cellSpacing="1" cellPadding="1" width="444" border="1">
								<TR class="ItemGrilla">
									<TD style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BORDER-BOTTOM: #999999 1px solid; BACKGROUND-COLOR: #cccccc"
										vAlign="middle" align="left">
										<TABLE id="Table5" style="WIDTH: 432px; HEIGHT: 22px" cellSpacing="1" cellPadding="1" width="432"
											align="right" border="0">
											<TR class="ItemGrilla">
												<TD style="WIDTH: 415px; COLOR: navy" vAlign="middle">DEFINICIÓN DE LIQUIDEZ</TD>
												<TD vAlign="middle" align="right"><IMG id="imgClose" onmouseover="this.src='../../imagenes/tree/CloseWindowB.gif'" onclick="ClosePopupSL(1);"
														onmouseout="this.src='../../imagenes/tree/CloseWindowA.gif'" src="../../imagenes/tree/CloseWindowA.gif"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BORDER-BOTTOM: #999999 1px solid"
										align="left">
										<P align="justify">La empresa puede hacer frente a sus obligaciones de corto 
											plazo.La Liquidez se mide mediante el ratio :&nbsp;&nbsp;<FONT style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BORDER-BOTTOM: #999999 1px solid; BACKGROUND-COLOR: inactivecaptiontext"
												color="#0033ff" size="1">ACTIVO CORRIENTE / PASIVO CORRIENTE</FONT><br>
											Los límites aceptables de este ratio se fijan entre <FONT color="#0000ff">1.7</FONT>
											y <FONT color="#0000ff">1.9.</FONT> No debe ser menor a 1.</P>
									</TD>
								</TR>
							</TABLE>
						</div>
						<!---Solvensia-->
						<div id="ppSolvensia" style="DISPLAY: none; POSITION: absolute; BACKGROUND-COLOR: #ffffff">
							<TABLE class="normaldetalle" id="Table4" style="WIDTH: 342px; HEIGHT: 76px" cellSpacing="1"
								cellPadding="1" width="342" border="1">
								<TR class="ItemGrilla">
									<TD style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BORDER-BOTTOM: #999999 1px solid; BACKGROUND-COLOR: #cccccc"
										vAlign="middle" align="left">
										<TABLE id="Table5" style="WIDTH: 336px; HEIGHT: 22px" cellSpacing="1" cellPadding="1" width="336"
											align="right" border="0">
											<TR class="ItemGrilla">
												<TD style="WIDTH: 318px; COLOR: navy" vAlign="middle">DEFINICIÓN DE SOLVENCIA</TD>
												<TD vAlign="middle" align="right"><IMG id="imgClose" onmouseover="this.src='../../imagenes/tree/CloseWindowB.gif'" onclick="ClosePopupSL(0);"
														onmouseout="this.src='../../imagenes/tree/CloseWindowA.gif'" src="../../imagenes/tree/CloseWindowA.gif"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BORDER-BOTTOM: #999999 1px solid"
										align="left">
										<P align="justify">Grado de compromiso del Patrimonio frente a su Pasivo total 
											(Obligaciones) En este caso la Solvencia se mide por:&nbsp;<br>
											<FONT style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BORDER-BOTTOM: #999999 1px solid; BACKGROUND-COLOR: inactivecaptiontext"
												color="#0033ff" size="1">(PASIVO TOTAL/PATRIMONIO)*100.</FONT><br>
											El límite máximo aceptable de este ratio es de 60%.</P>
									</TD>
								</TR>
							</TABLE>
						</div>
					</TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
