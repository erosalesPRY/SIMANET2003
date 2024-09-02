<%@ Page language="c#" Codebehind="ConsultarCartasdeCreditoporBanco.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasCredito.ConsultarCartasdeCreditoporBanco" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
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
						<TABLE class="tabla" id="TblTabs" cellSpacing="0" cellPadding="0" width="769" align="center"
							bgColor="#f5f5f5" border="0" runat="server">
							<TR>
								<TD style="WIDTH: 64px">
									<asp:label id="Label4" runat="server" CssClass="TextoNegroNegrita">CREDITO :</asp:label></TD>
								<TD style="WIDTH: 250px">
									<asp:dropdownlist id="ddlbModalidadCartaCredito" runat="server" CssClass="combos" Width="228px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 45px"><asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita">SITUACIÓN :</asp:label></TD>
								<TD>&nbsp;<asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="combos" AutoPostBack="True" Width="120px"></asp:dropdownlist>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="768" border="0"
							DESIGNTIMEDRAGDROP="26">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
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
											<asp:TemplateColumn HeaderText="SIMA CALLAO">
												<HeaderStyle Width="10%" VerticalAlign="Bottom"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																vAlign="bottom" align="center" colSpan="2">
																<asp:Label id="lblhCallao" runat="server" CssClass="HeaderGrilla" Font-Bold="True" Height="4px"
																	BorderStyle="None">SIMA-CALLAO</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="Label8" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" Font-Bold="True"
																	Height="3px" BorderStyle="None">EUROS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="50%">
																<asp:Label id="Label10" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" Font-Bold="True"
																	Height="3px" BorderStyle="None">DOLARES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="50%">
																<asp:Label id="lblMontoCallaoS" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315"
																	Width="70px" Height="12px" BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="50%">
																<asp:Label id="lblMontoCallaoD" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503"
																	Width="70px" Height="11px" BorderStyle="None">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table2" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblFMontoCallaoS" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315"
																	Width="70px" Height="12px" BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="50%">
																<asp:Label id="lblFMontoCallaoD" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="503"
																	Width="70px" Height="11px" BorderStyle="None">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="SIMA CHIMBOTE">
												<HeaderStyle Width="10%" VerticalAlign="Bottom"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="2">
																<asp:Label id="lblHChimbote" runat="server" CssClass="HeaderGrilla" Font-Bold="True" Height="3px"
																	BorderStyle="None">SIMA-CHIMBOTE</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="Label88" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" Font-Bold="True"
																	Height="3px" BorderStyle="None">EUROS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="50%">
																<asp:Label id="Label11" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" Font-Bold="True"
																	Height="3px" BorderStyle="None">DOLARES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="50%">
																<asp:Label id="lblMontoChimboteS" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315"
																	Width="70px" Height="12px">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="right" width="50%">
																<asp:Label id="lblMontoChimboteD" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503"
																	Width="70px" Height="12px">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblFMontoChimboteS" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315"
																	Width="70px" Height="12px" BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right" width="50%">
																<asp:Label id="lblFMontoChimboteD" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="503"
																	Width="70px" Height="12px" BorderStyle="None">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="SIMA IQUITOS">
												<HeaderStyle Width="10%" VerticalAlign="Bottom"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="2">
																<asp:Label id="lblHIquitos" runat="server" CssClass="HeaderGrilla" Font-Bold="True" Height="3px"
																	BorderStyle="None">SIMA-IQUITOS S.R.Ltda.</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="Label888" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" Font-Bold="True"
																	Height="3px" BorderStyle="None">EUROS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="50%">
																<asp:Label id="Label111" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" Font-Bold="True"
																	Height="3px" BorderStyle="None">DOLARES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" style="HEIGHT: 20px" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="50%">
																<asp:Label id="lblMontoIquitosS" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315"
																	Width="70px" Height="3px">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="right" width="50%">
																<asp:Label id="lblMontoIquitosD" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503"
																	Width="70px" Height="3px">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table13" style="HEIGHT: 20px" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblFMontoIquitosS" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315"
																	Width="70px" Height="3px" BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right" width="50%">
																<asp:Label id="lblFMontoIquitosD" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="503"
																	Width="70px" Height="3px" BorderStyle="None">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
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
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hidCentro" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hidCentro"
										runat="server"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server" DESIGNTIMEDRAGDROP="410"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
										runat="server" DESIGNTIMEDRAGDROP="20"></TD>
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
