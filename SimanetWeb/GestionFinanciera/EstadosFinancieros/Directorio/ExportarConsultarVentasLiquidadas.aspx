<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ExportarConsultarVentasLiquidadas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio.ExportarConsultarVentasLiquidadas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/JSFrameworkSima.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
				<TR id="id1">
					<TD style="HEIGHT: 24px" colSpan="3"></TD>
				</TR>
				<TR>
					<TD align="center" vAlign="top" width="100%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD align="center" vAlign="top">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD align="left" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#f0f0f0" colSpan="4">
															<asp:imagebutton id="ibtnAbrir" runat="server" ImageUrl="..\..\..\imagenes\bt_exportar.gif"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
										Width="100%" PageSize="7" ShowFooter="True" CssClass="HeaderGrilla" AllowPaging="True">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle Font-Names="Nina" Font-Bold="True" HorizontalAlign="Right" ForeColor="Black" CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="3%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="OT" SortExpression="OT" HeaderText="OT" FooterText="TOTAL:">
												<HeaderStyle Font-Underline="True" Width="3%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FEC_EMS" SortExpression="FEC_EMS" HeaderText="FECHA EMISION" DataFormatString="{0: dd-MM-yyyy}">
												<HeaderStyle Width="8%"></HeaderStyle>
												<FooterStyle HorizontalAlign="Center"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CLIENTE" SortExpression="CLIENTE" HeaderText="CLIENTE">
												<HeaderStyle Font-Underline="True" Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SERVICIO" SortExpression="SERVICIO" HeaderText="SERVICIO">
												<HeaderStyle Width="16%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="VAL">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<TR>
															<TD align="center">
																<asp:Label id="lblTituloVal" runat="server" CssClass="HeaderGrilla" BorderStyle="None">VAL</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id="lblValorizacion" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VAL</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label id="lblSumValorizacion" runat="server" CssClass="ItemGrillaSinColor">SUMVAL</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="COSTOS DE PRODUCCION">
												<HeaderStyle Width="22%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="3">&nbsp;
																<asp:Label id="lblCostosdeProduccion" runat="server" CssClass="HeaderGrilla" BorderStyle="None">COSTOS DE PRODUCCION</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="36%">
																<asp:Label id="lblDir" runat="server" CssClass="HeaderGrilla" BorderStyle="None">DIR</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="36%">
																<asp:Label id="lblInd" runat="server" CssClass="HeaderGrilla" BorderStyle="None">IND</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="28%">
																<asp:Label id="lblCostoTotal" runat="server" CssClass="HeaderGrilla" BorderStyle="None">TOT</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table4" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="36%">
																<asp:Label id="lblDirectos" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">DIR</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="36%">
																<asp:Label id="lblIndirectos" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">IND</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="28%">
																<asp:Label id="lblTotal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">TOTAL</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table8" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="36%">
																<asp:Label id="lblSumGDirectos" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">DIR</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="36%">
																<asp:Label id="lblSumGIndirectos" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">IND</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="28%">
																<asp:Label id="lblSumGTotal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">TOT</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="DIF">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<TR>
															<TD align="center">
																<asp:Label id="lblTituloDiferencia" runat="server" CssClass="HeaderGrilla" BorderStyle="None">DIF</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id="lblDiferencia" runat="server" CssClass="ItemGrillaSinColor">DIF</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label id="lblSumDiferencia" runat="server" CssClass="ItemGrillaSinColor">SUMDIF</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="FAC">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<TR>
															<TD align="center">
																<asp:Label id="lblTituloFacturado" runat="server" CssClass="HeaderGrilla" BorderStyle="None">FAC</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id="lblFacturado" runat="server" CssClass="ItemGrillaSinColor">FAC</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label id="lblSumFacturado" runat="server" CssClass="ItemGrillaSinColor">SUMFAC</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="RES">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<TR>
															<TD align="center">
																<asp:Label id="lblTituloResultado" runat="server" CssClass="HeaderGrilla" BorderStyle="None">RES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id="lblResult" runat="server" CssClass="ItemGrillaSinColor">RES</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label id="lblSumResult" runat="server" CssClass="ItemGrillaSinColor">SUMRES</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="% UTIL">
												<HeaderStyle Width="4%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<TR>
															<TD align="center">
																<asp:Label id="lblTituloPorcentaje" runat="server" CssClass="HeaderGrilla" BorderStyle="None">POR</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id="lblPorcentaje" runat="server" CssClass="ItemGrillaSinColor">%</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<asp:Label id="lblSumPorc" runat="server" CssClass="ItemGrillaSinColor">SUMPORC</asp:Label>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn Visible="False">
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemTemplate>
													<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label>
								</TD>
							</TR>
						</TABLE>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR id="id5">
								<TD vAlign="top"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
