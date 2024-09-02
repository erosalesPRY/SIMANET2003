<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarResumenRendicionCuentas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Proyectos.ConsultarResumenRendicionCuentas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td bgColor="#eff7fa" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Proyectos ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Resumen - Rendición Cuentas Pendientes</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" class="normal" border="0" cellSpacing="0" cellPadding="0" width="768"
							DESIGNTIMEDRAGDROP="26">
							<TR>
								<TD width="100%" colSpan="3" align="center">
									<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" PageSize="7" ShowFooter="True" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" Width="100%">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle Font-Size="X-Small" Font-Bold="True" CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="moneda" SortExpression="moneda" HeaderText="TIPO DE MONEDA">
												<HeaderStyle Width="25%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="SIMA CALLAO">
												<HeaderStyle Width="10%" VerticalAlign="Bottom"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; WIDTH: 230px; HEIGHT: 10px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"
																vAlign="bottom" colSpan="2" align="center">
																<asp:Label id="lblhCallao" runat="server" CssClass="HeaderGrilla" Font-Bold="True" Height="4px"
																	BorderStyle="None">SIMA-CALLAO</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left"
														height="100%">
														<TR>
															<TD width="50%" align="center">
																<asp:Label id="lblMontoCallaoS" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315"
																	Width="70px" Height="12px" BorderStyle="None">DEL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left"
														height="100%">
														<TR>
															<TD width="50%" noWrap align="center">
																<asp:Label id="lblFMontoCallaoS" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315"
																	Width="70px" Height="12px" BorderStyle="None">DEL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="SIMA CHIMBOTE">
												<HeaderStyle Width="10%" VerticalAlign="Bottom"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; WIDTH: 230px; HEIGHT: 10px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"
																colSpan="2" align="center">
																<asp:Label id="lblHChimbote" runat="server" CssClass="HeaderGrilla" Font-Bold="True" Height="3px"
																	BorderStyle="None">SIMA-CHIMBOTE</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left"
														height="100%">
														<TR>
															<TD width="50%" align="center">
																<asp:Label id="lblMontoChimboteS" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315"
																	Width="70px" Height="12px">DEL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left"
														height="100%">
														<TR>
															<TD width="50%" noWrap align="center">
																<asp:Label id="lblFMontoChimboteS" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315"
																	Width="70px" Height="12px" BorderStyle="None">DEL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="SIMA IQUITOS">
												<HeaderStyle Width="10%" VerticalAlign="Bottom"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; WIDTH: 230px; HEIGHT: 10px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"
																colSpan="2" align="center">
																<asp:Label id="lblHIquitos" runat="server" CssClass="HeaderGrilla" Font-Bold="True" Height="3px"
																	BorderStyle="None">SIMA-IQUITOS S.R.Ltda.</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE style="HEIGHT: 20px" id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%"
														align="left">
														<TR>
															<TD width="50%" align="center">
																<asp:Label id="lblMontoIquitosS" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315"
																	Width="70px" Height="3px">DEL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE style="HEIGHT: 20px" id="Table13" border="0" cellSpacing="0" cellPadding="0" width="100%"
														align="left">
														<TR>
															<TD width="50%" noWrap align="center">
																<asp:Label id="lblFMontoIquitosS" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315"
																	Width="70px" Height="3px" BorderStyle="None">DEL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="TOTAL">
												<HeaderStyle Width="10%" VerticalAlign="Bottom"></HeaderStyle>
												<HeaderTemplate>
													<TABLE style="HEIGHT: 28px" id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%"
														align="left">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; WIDTH: 230px; HEIGHT: 10px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"
																colSpan="2" align="center">
																<asp:Label id="lblHTotal" runat="server" CssClass="HeaderGrilla" Font-Bold="True" Height="3px"
																	BorderStyle="None">TOTALES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left"
														height="100%">
														<TR>
															<TD width="50%" align="center">
																<asp:Label id="lblMontoTotalS" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315"
																	Width="70px" Height="3px" BorderStyle="None">DEL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table7" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left"
														height="100%">
														<TR>
															<TD width="50%" noWrap align="center">
																<asp:Label id="lblFMontoTotalS" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315"
																	Width="75px" Height="3px" BorderStyle="None">DEL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px" vAlign="top" width="100%" align="center">
						<TABLE style="WIDTH: 766px; HEIGHT: 26px" id="Table6" border="0" cellSpacing="1" cellPadding="1"
							width="766">
							<TR>
								<TD align="left"><IMG style="CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hidCentro" size="1" type="hidden" name="hidCentro"
										runat="server"><INPUT style="WIDTH: 16px; HEIGHT: 22px" id="hCodigo" size="1" type="hidden" name="hCodigo"
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
