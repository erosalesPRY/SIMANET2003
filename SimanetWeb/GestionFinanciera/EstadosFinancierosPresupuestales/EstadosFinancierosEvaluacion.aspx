<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ParametroContable" Src="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="EstadosFinancierosEvaluacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancierosPresupuestales.EstadosFinancierosEvaluacion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<!--oncontextmenu="return false"-->
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="3" style="HEIGHT: 25px"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR>
					<TD width="100%" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" width="100%" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Estados Financieros Presupuestales></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Estados Financieros</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3" style="HEIGHT: 216px">
						<TABLE class="normal" id="Table2" cellSpacing="0" cellPadding="0" width="765" border="0"
							style="WIDTH: 765px; HEIGHT: 199px">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 354px">
												<asp:label id="lblPeriodo" runat="server" CssClass="TextoAzul" Font-Bold="True" DESIGNTIMEDRAGDROP="98"
													Font-Size="Small">Periodo :</asp:label></TD>
											<TD style="WIDTH: 760px" vAlign="middle"><asp:label id="lblMes" runat="server" CssClass="TextoAzul" Font-Bold="True" Font-Size="Small">Mes :</asp:label></TD>
											<TD style="WIDTH: 446px"></TD>
											<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<ITEMSTYLE CssClass="ItemGrilla"></ITEMSTYLE><HEADERSTYLE CssClass="HeaderGrilla"></HEADERSTYLE><FOOTERSTYLE CssClass="FooterGrilla"></FOOTERSTYLE><COLUMNS><ASP:TEMPLATECOLUMN HeaderText="CONCEPTO"><HEADERSTYLE Width="75%" Font-Bold="True"></HEADERSTYLE>
											<ITEMSTYLE HorizontalAlign="Left" VerticalAlign="Middle"></ITEMSTYLE>
											<ITEMTEMPLATE></ITEMTEMPLATE>
										</ASP:TEMPLATECOLUMN>
										<ASP:TEMPLATECOLUMN HeaderText="MONTO">
											<ITEMSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></ITEMSTYLE>
											<HEADERTEMPLATE></HEADERTEMPLATE>
											<ITEMTEMPLATE></ITEMTEMPLATE>
										</ASP:TEMPLATECOLUMN>
										<ASP:TEMPLATECOLUMN HeaderText="DET">
											<HEADERSTYLE Width="5%" Font-Bold="True"></HEADERSTYLE>
											<ITEMSTYLE HorizontalAlign="Center" VerticalAlign="Middle"></ITEMSTYLE>
											<ITEMTEMPLATE></ITEMTEMPLATE>
										</ASP:TEMPLATECOLUMN>
										<ASP:TEMPLATECOLUMN HeaderText="FORM">
											<HEADERSTYLE Font-Bold="True"></HEADERSTYLE>
											<ITEMSTYLE Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></ITEMSTYLE>
											<ITEMTEMPLATE></ITEMTEMPLATE>
										</ASP:TEMPLATECOLUMN>
									</COLUMNS><PAGERSTYLE CssClass="PagerGrilla" Mode="NumericPages"></PAGERSTYLE><cc1:datagridweb id="grid" runat="server" Width="100%" DataKeyField="IdRubro" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Concepto" SortExpression="Concepto" HeaderText="CONCEPTO">
												<HeaderStyle Width="60%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="ACUMULADO">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle VerticalAlign="Bottom"></ItemStyle>
												<HeaderTemplate>
													<TABLE class="HeaderGrilla" id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" width="100%" colSpan="5">
																<asp:Label id="lblhPresupuesto" runat="server" Font-Bold="True">ACUMULADO</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="26.6%">
																<asp:Label id="Label88" runat="server" Font-Bold="True" Width="76px">PRESUPUESTO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="26.6%">
																<asp:Label id="Label101" runat="server" Font-Bold="True" Width="76px">EJECUTADO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="10%">
																<asp:Label id="Label1" runat="server" Font-Bold="True" Width="20px">%</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="26.6%">
																<asp:Label id="Label3" runat="server" Font-Bold="True" Width="76px">VARIACION</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="10%">
																<asp:Label id="Label4" runat="server" Font-Bold="True" Width="20px">%</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="26.6%">
																<asp:Label id="lblMontoAcumuladoPPTO" runat="server" CssClass="ItemGrillaSinColor" Width="80px"
																	Height="12px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="26.6%">
																<asp:Label id="lblMontoAcumuladoReal" runat="server" CssClass="ItemGrillaSinColor" Width="80px"
																	Height="11px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="10%">
																<asp:Label id="lblPorcAcumuladoReal" runat="server" CssClass="ItemGrillaSinColor" Width="20px"
																	Height="11px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="26.6%">
																<asp:Label id="lblMontoAcumuladoVariacion" runat="server" CssClass="ItemGrillaSinColor" Width="80px"
																	Height="11px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="10%">
																<asp:Label id="lblPorcAcumuladoVariacion" runat="server" CssClass="ItemGrillaSinColor" Width="20px"
																	Height="11px">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="DEL MES">
												<HeaderStyle Width="20%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE class="HeaderGrilla" id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" width="100%" colSpan="5">
																<asp:Label id="lblhTitulodelMes" runat="server" Font-Bold="True">DEL MES</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="26.6%">
																<asp:Label id="lblDelMes1" runat="server" Font-Bold="True" Width="76px">PRESUPUESTO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="26.6%">
																<asp:Label id="lblDelMes2" runat="server" Font-Bold="True" Width="76px">EJECUTADO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="10%">
																<asp:Label id="lblDelMes3" runat="server" Font-Bold="True" Width="20px">%</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="26.6%">
																<asp:Label id="lblDelMes4" runat="server" Font-Bold="True" Width="76px">VARIACION</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="10%">
																<asp:Label id="lblDelMes5" runat="server" Font-Bold="True" Width="20px">%</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="26.6%">
																<asp:Label id="lblMontodelMesPPTO" runat="server" CssClass="ItemGrillaSinColor" Width="80px"
																	Height="12px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="26.6%">
																<asp:Label id="lblMontodelMesReal" runat="server" CssClass="ItemGrillaSinColor" Width="80px"
																	Height="11px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="10%">
																<asp:Label id="lblPorcdelMesReal" runat="server" CssClass="ItemGrillaSinColor" Width="20px"
																	Height="11px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="26.6%">
																<asp:Label id="lblMontodelMesVariacion" runat="server" CssClass="ItemGrillaSinColor" Width="80px"
																	Height="11px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="10%">
																<asp:Label id="lblPorcdelMesVariacion" runat="server" CssClass="ItemGrillaSinColor" Width="20px"
																	Height="11px">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
					</TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
