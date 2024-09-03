<%@ Page language="c#" Codebehind="ConsultarPrestamosporBanco.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PrestamosBancarios.ConsultarPrestamosporBanco" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR class="RutaPaginaActual">
					<TD vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Préstamos por Banco</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px" vAlign="top" align="center" width="100%">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="782" border="0">
							<TR>
								<TD>
									<TABLE id="Table2" style="HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 5px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 82px">
												<asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
											<TD vAlign="bottom" style="WIDTH: 112px"><IMG id="ibtnFiltrarSeleccion" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
													alt="Aplicar Filtro por Selección" src="../../imagenes/filtroporseleccion.jpg" runat="server" align="bottom" title="razonsocial">
											</TD>
											<TD style="WIDTH: 504px">
												<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG style="WIDTH: 4px; HEIGHT: 22px" height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" ShowFooter="True" Width="100%" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" DESIGNTIMEDRAGDROP="40">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle BorderStyle="Solid" CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="razonsocial" SortExpression="razonsocial" HeaderText="ENTIDAD FINANCIERA">
												<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="CALLAO">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="2">
																<asp:Label id="lblHCallao" runat="server" CssClass="HeaderGrilla" BorderStyle="None" Font-Bold="True"
																	Height="3px">SIMA-CALLAO</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="Label8" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" BorderStyle="None"
																	Font-Bold="True" Height="3px">SOLES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="50%">
																<asp:Label id="Label1" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" BorderStyle="None"
																	Font-Bold="True" Height="3px">DOLARES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblMontoCallaoS" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315"
																	Width="64px" Height="3px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="50%">
																<asp:Label id="lblMontoCallaoD" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503"
																	Width="65px" Height="3px">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterStyle VerticalAlign="Middle"></FooterStyle>
												<FooterTemplate>
													<TABLE id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblFMontoCallaoS" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315"
																	Width="64px" BorderStyle="None" Height="3px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="50%">
																<asp:Label id="lblFMontoCallaoD" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="503"
																	Width="65px" BorderStyle="None" Height="3px">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="CHIMBOTE">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table4" style="HEIGHT: 28px" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="2">
																<asp:Label id="lblHChimbote" runat="server" CssClass="HeaderGrilla" BorderStyle="None" Font-Bold="True"
																	Height="3px">SIMA-CHIMBOTE</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="Label4" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" BorderStyle="None"
																	Font-Bold="True" Height="3px">SOLES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="50%">
																<asp:Label id="Label5" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" BorderStyle="None"
																	Font-Bold="True" Height="3px">DOLARES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" style="HEIGHT: 100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblMontoChimboteS" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315"
																	Width="64px" Height="3px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="50%">
																<asp:Label id="lblMontoChimboteD" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503"
																	Width="64px" Height="3px">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterStyle VerticalAlign="Middle"></FooterStyle>
												<FooterTemplate>
													<TABLE id="Table6" style="HEIGHT: 100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblFMontoChimboteS" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315"
																	Width="64px" BorderStyle="None" Height="3px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="50%">
																<asp:Label id="lblFMontoChimboteD" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="503"
																	Width="64px" BorderStyle="None" Height="3px">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="IQUITOS">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table4" style="HEIGHT: 28px" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="2">
																<asp:Label id="lblHIquitos" runat="server" CssClass="HeaderGrilla" BorderStyle="None" Font-Bold="True"
																	Height="3px">SIMA-IQUITOS S.R.Ltda.</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="Label7" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" BorderStyle="None"
																	Font-Bold="True" Height="3px">SOLES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="50%">
																<asp:Label id="Label10" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" BorderStyle="None"
																	Font-Bold="True" Height="3px">DOLARES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblMontoIquitosS" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315"
																	Width="64px" Height="3px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="50%">
																<asp:Label id="lblMontoIquitosD" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503"
																	Width="64px" Height="3px">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterStyle VerticalAlign="Middle"></FooterStyle>
												<FooterTemplate>
													<TABLE id="Table7" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblFMontoIquitosS" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315"
																	Width="64px" BorderStyle="None" Height="3px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="50%">
																<asp:Label id="lblFMontoIquitosD" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="503"
																	Width="64px" BorderStyle="None" Height="3px">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="TOTALES">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table4" style="HEIGHT: 28px" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="2">
																<asp:Label id="Label11" runat="server" CssClass="HeaderGrilla" BorderStyle="None" Font-Bold="True"
																	Height="3px">TOTALES</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="Label12" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" BorderStyle="None"
																	Font-Bold="True" Height="3px">SOLES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="50%">
																<asp:Label id="Label13" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" BorderStyle="None"
																	Font-Bold="True" Height="3px">DOLARES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblMontoTotalS" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315"
																	Width="64px" Height="3px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="50%">
																<asp:Label id="lblMontoTotalD" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503"
																	Width="64px" Height="3px">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterStyle VerticalAlign="Middle"></FooterStyle>
												<FooterTemplate>
													<TABLE id="Table8" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblFMontoTotalS" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315"
																	Width="64px" BorderStyle="None" Height="3px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="50%">
																<asp:Label id="lblFMontoTotalD" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="503"
																	Width="64px" BorderStyle="None" Height="3px">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table9" style="HEIGHT: 28px" cellSpacing="1" cellPadding="1" width="782" border="0">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
