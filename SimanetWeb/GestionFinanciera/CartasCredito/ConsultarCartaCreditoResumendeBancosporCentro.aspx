<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarCartaCreditoResumendeBancosporCentro.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasCredito.ConsultarCartaCreditoResumendeBancosporCentro" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="1" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label>
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar de Cartas de Crédito</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="768" border="0"
							DESIGNTIMEDRAGDROP="26">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD><IMG height="8" src="../imagenes/spacer.gif" width="250"></TD>
											<TD>&nbsp;</TD>
											<TD style="WIDTH: 107px"></TD>
											<TD style="WIDTH: 107px"></TD>
											<TD align="right"></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" PageSize="7" ShowFooter="True" Width="100%" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle Font-Size="X-Small" Font-Bold="True" CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="razonsocial" SortExpression="razonsocial" HeaderText="ENTIDAD FINANCIERA">
												<HeaderStyle Width="25%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="TOTAL">
												<HeaderStyle Width="10%" VerticalAlign="Bottom"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table4" style="HEIGHT: 28px" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="2">
																<asp:Label id="lblHTotal" runat="server" CssClass="HeaderGrilla" Font-Bold="True" Height="3px"
																	BorderStyle="None">TOTALES</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="Label8888" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" Font-Bold="True"
																	Height="3px" BorderStyle="None">EUROS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="50%">
																<asp:Label id="Label11111" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503"
																	Font-Bold="True" Height="3px" BorderStyle="None">DOLARES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="50%">
																<asp:Label id="lblMontoTotalS" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315"
																	Width="70px" Height="3px" BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="right" width="50%">
																<asp:Label id="lblMontoTotalD" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503"
																	Width="78px" Height="3px" BorderStyle="None">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table7" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblFMontoTotalS" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315"
																	Width="75px" Height="3px" BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right" width="50%">
																<asp:Label id="lblFMontoTotalD" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="503"
																	Width="78px" Height="3px" BorderStyle="None">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px" vAlign="top" align="center" width="100%">
						<TABLE id="Table6" style="WIDTH: 766px; HEIGHT: 26px" cellSpacing="1" cellPadding="1" width="766"
							border="0">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td vAlign="top" width="592"></td>
				</tr>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
