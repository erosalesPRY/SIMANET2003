<%@ Page language="c#" Codebehind="ConsultarLineasdeCreditoporBanco.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.LineasdeCredito.ConsultarLineasdeCreditoporBanco" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<!--oncontextmenu="return false" -->
  </HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Detalle de Línea de Crédito por Banco</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><IMG style="WIDTH: 160px; HEIGHT: 8px" height="8" src="../../imagenes/spacer.gif" width="160"
							DESIGNTIMEDRAGDROP="160"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" style="HEIGHT: 358px" cellSpacing="0" cellPadding="0"
							width="100%" border="0">
							<TR>
								<TD>
									<TABLE id="Table4" style="WIDTH: 405px; HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="400"
										border="0">
										<TR bgColor="#f0f0f0">
											<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 246px"><IMG style="WIDTH: 286px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="286"></TD>
											<TD style="WIDTH: 18px">&nbsp;</TD>
											<TD style="WIDTH: 14px"></TD>
											<TD></TD>
											<TD><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="gridResumen" runat="server" Width="405px" AllowPaging="True" AllowSorting="True"
										AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" PageSize="2">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle Font-Bold="True" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="nombreentidad" HeaderText="ENTIDAD FINANCIERA">
												<HeaderStyle Font-Bold="True" Width="50%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoAutorizadoEnDolar" HeaderText="AUTORIZADO EN DOLARES">
												<HeaderStyle Font-Bold="True" Width="18%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="UtilizadoAlCambioDelDolar" HeaderText="UTILIZADO AL CAMBIO DOLARES">
												<HeaderStyle Font-Bold="True" Width="18%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DisponibleEnDolar" HeaderText="DISPONIBLE EN  DOLARES">
												<HeaderStyle Font-Bold="True" Width="18%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
								<TD style="HEIGHT: 13px"></TD>
								<TD style="WIDTH: 1px; HEIGHT: 13px"></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE style="HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD><asp:label id="Label5" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True" ForeColor="Black">MOVIMIENTO DE LINEA DE CREDITO</asp:label></TD>
											<TD align="right" width="4"><IMG style="HEIGHT: 22px" height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<div id="div-datagrid" style="WIDTH: 100%; HEIGHT: 200px" align=left>
										<cc1:datagridweb id="grid" runat="server" Width="761px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
											RowHighlightColor="#E0E0E0" PageSize="7">
											<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
											<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
											<FooterStyle CssClass="headergrilla"></FooterStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<Columns>
												<asp:BoundColumn DataField="moneda" SortExpression="moneda" HeaderText="U.M">
													<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle Font-Bold="True"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="tc" SortExpression="tc" HeaderText="TC"></asp:BoundColumn>
												<asp:TemplateColumn HeaderText="C/CREDITO">
													<ItemStyle VerticalAlign="Bottom"></ItemStyle>
													<HeaderTemplate>
														<TABLE id="Table6" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
															border="0">
															<TR>
																<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 480px; BORDER-BOTTOM: #ffffff 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																	align="center" colSpan="2">
																	<asp:Label id="lblHCC" runat="server" CssClass="HEADERGRILLA" Width="10px" Font-Bold="True" 
 BorderStyle="None">C/Credito</asp:Label></TD>
															</TR>
															<TR>
																<TD align="center" width="50%">
																	<asp:Label id="lblCOrg" runat="server" CssClass="HEADERGRILLA" Width="58px" Font-Bold="True" 
 BorderStyle="None">M.  Origen.</asp:Label></TD>
																<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="50%">
																	<asp:Label id="lblCDlr" runat="server" CssClass="HEADERGRILLA" Width="58px" Font-Bold="True" 
 BorderStyle="None">DOLARIZADO</asp:Label></TD>
															</TR>
														</TABLE>
													</HeaderTemplate>
													<ItemTemplate>
														<TABLE id="tblCCredito" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
															border="0">
															<TR>
																<TD align="right" width="50%">
																	<asp:Label id="lblMontoCCR" runat="server" CssClass="normaldetalle" Width="83px" BorderStyle="None" 
 Height="2px">0.00</asp:Label></TD>
																<TD style="BORDER-LEFT: buttonface 1px solid" align="right" width="50%">
																	<asp:Label id="lblMontoCCCV" runat="server" CssClass="normaldetalle" Width="83px" BorderStyle="None" 
 Height="10px">0.00</asp:Label></TD>
															</TR>
														</TABLE>
													</ItemTemplate>
													<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="C/FIANZA">
													<ItemStyle VerticalAlign="Bottom"></ItemStyle>
													<HeaderTemplate>
														<TABLE id="Table6" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
															border="0">
															<TR>
																<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 480px; BORDER-BOTTOM: #ffffff 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																	align="center" colSpan="2">
																	<asp:Label id="lblCF" runat="server" CssClass="HEADERGRILLA" DESIGNTIMEDRAGDROP="410" Width="10px" 
 Font-Bold="True" BorderStyle="None">C/Fianza</asp:Label></TD>
															</TR>
															<TR>
																<TD align="center" width="50%">
																	<asp:Label id="lblCFOrg" runat="server" CssClass="HEADERGRILLA" Width="58px" Font-Bold="True" 
 BorderStyle="None">M.  Origen.</asp:Label></TD>
																<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="50%">
																	<asp:Label id="lblCFDlr" runat="server" CssClass="HEADERGRILLA" Width="58px" Font-Bold="True" 
 BorderStyle="None">DOLARIZADO</asp:Label></TD>
															</TR>
														</TABLE>
													</HeaderTemplate>
													<ItemTemplate>
														<TABLE id="tblCFianza" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
															border="0">
															<TR>
																<TD align="right" width="50%">
																	<asp:Label id="lblMontoCFR" runat="server" CssClass="normaldetalle" Width="83px" BorderStyle="None" 
 Height="2px">0.00</asp:Label></TD>
																<TD style="BORDER-LEFT: buttonface 1px solid" align="right" width="50%">
																	<asp:Label id="lblMontoCFCV" runat="server" CssClass="normaldetalle" Width="83px" Height="2px">0.00</asp:Label></TD>
															</TR>
														</TABLE>
													</ItemTemplate>
													<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="PRESTAMOS">
													<ItemStyle VerticalAlign="Bottom"></ItemStyle>
													<HeaderTemplate>
														<TABLE id="Table6" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
															border="0">
															<TR>
																<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 480px; BORDER-BOTTOM: #ffffff 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																	align="center" colSpan="2">
																	<asp:Label id="lblptmo" runat="server" CssClass="HEADERGRILLA" DESIGNTIMEDRAGDROP="423" Width="10px" 
 Font-Bold="True" BorderStyle="None">Préstamo</asp:Label></TD>
															</TR>
															<TR>
																<TD align="center" width="50%">
																	<asp:Label id="lblPOrg" runat="server" CssClass="HEADERGRILLA" Width="58px" Font-Bold="True" 
 BorderStyle="None">M.  Origen.</asp:Label></TD>
																<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="50%">
																	<asp:Label id="lblPDlr" runat="server" CssClass="HEADERGRILLA" Width="58px" Font-Bold="True" 
 BorderStyle="None">DOLARIZADO</asp:Label></TD>
															</TR>
														</TABLE>
													</HeaderTemplate>
													<ItemTemplate>
														<TABLE id="tblPto" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
															border="0">
															<TR>
																<TD align="right" width="50%">
																	<asp:Label id="lblMontoCPR" runat="server" CssClass="normaldetalle" Width="83px" BorderStyle="None" 
 Height="10px">0.00</asp:Label></TD>
																<TD style="BORDER-LEFT: buttonface 1px solid" align="right" width="50%">
																	<asp:Label id="lblMontoCPCV" runat="server" CssClass="normaldetalle" Width="83px" BorderStyle="None" 
 Height="10px">0.00</asp:Label></TD>
															</TR>
														</TABLE>
													</ItemTemplate>
													<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="D/LETRAS">
													<ItemStyle VerticalAlign="Bottom"></ItemStyle>
													<HeaderTemplate>
														<TABLE id="Table6" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
															border="0">
															<TR>
																<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 480px; BORDER-BOTTOM: #ffffff 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																	align="center" colSpan="2">
																	<asp:Label id="lblDL" runat="server" CssClass="HEADERGRILLA" Width="10px" Font-Bold="True" 
 BorderStyle="None">D/Letras</asp:Label></TD>
															</TR>
															<TR>
																<TD align="center" width="50%">
																	<asp:Label id="lblDLOrg" runat="server" CssClass="HEADERGRILLA" Width="58px" Font-Bold="True" 
 BorderStyle="None">M.  Origen.</asp:Label></TD>
																<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="50%">
																	<asp:Label id="lblDLDlr" runat="server" CssClass="HEADERGRILLA" Width="58px" Font-Bold="True" 
 BorderStyle="None">DOLARIZADO</asp:Label></TD>
															</TR>
														</TABLE>
													</HeaderTemplate>
													<ItemTemplate>
														<TABLE id="Table7" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
															border="0">
															<TR>
																<TD align="right" width="50%">
																	<asp:Label id="lblMontoCLR" runat="server" CssClass="normaldetalle" Width="83px" BorderStyle="None" 
 Height="2px">0.00</asp:Label></TD>
																<TD style="BORDER-LEFT: buttonface 1px solid" align="right" width="50%">
																	<asp:Label id="lblMontoCLCV" runat="server" CssClass="normaldetalle" Width="83px" BorderStyle="None" 
 Height="10px">0.00</asp:Label></TD>
															</TR>
														</TABLE>
													</ItemTemplate>
													<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
												</asp:TemplateColumn>
											</Columns>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										</cc1:datagridweb></div>
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5px" align="center" width="100%" colSpan="3"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
