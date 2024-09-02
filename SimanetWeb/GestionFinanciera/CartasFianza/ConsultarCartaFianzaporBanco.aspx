<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarCartaFianzaporBanco.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasFianza.ConsultarCartaFianzaporBanco" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
	</HEAD>
	<body oncontextmenu="return true" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%" align="left"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Carta Fianza por Banco</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE style="WIDTH: 761px; HEIGHT: 8px" id="TblTabs" class="tabla" border="0" cellSpacing="0"
							cellPadding="0" width="761" bgColor="#f5f5f5" align="center" runat="server">
							<TR>
								<TD style="WIDTH: 61px"><asp:label id="Label2" runat="server" CssClass="TextoNegroNegrita"> Fianzas:</asp:label></TD>
								<TD style="WIDTH: 100px; HEIGHT: 30px"><asp:dropdownlist id="ddlbModalidadCartaFianza" runat="server" CssClass="combos" AutoPostBack="True"
										Width="100px"></asp:dropdownlist></TD>
								<td><asp:label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="TextoNegroNegrita">Estado:</asp:label></td>
								<td style="WIDTH: 140px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlbEstadoCartaFianza" runat="server" CssClass="combos" AutoPostBack="True"
										Width="140px"></asp:dropdownlist></td>
								<TD style="WIDTH: 80px"><asp:label style="Z-INDEX: 0" id="Label4" runat="server" CssClass="TextoNegroNegrita">Sub Estado:</asp:label></TD>
								<TD><asp:dropdownlist style="Z-INDEX: 0" id="ddlSubEstadoFZA" runat="server" CssClass="combos" AutoPostBack="True"
										Width="140px"></asp:dropdownlist></TD>
								<TD><asp:label style="Z-INDEX: 0" id="Label5" runat="server" CssClass="TextoNegroNegrita">Proyecto:</asp:label></TD>
								<TD><asp:dropdownlist style="Z-INDEX: 0" id="ddlProyecto" runat="server" CssClass="combos" AutoPostBack="True"
										Width="140px">
										<asp:ListItem Value="0">Todo</asp:ListItem>
										<asp:ListItem Value="1">En Litigio</asp:ListItem>
										<asp:ListItem Value="2">Otros</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" class="normal" border="0" cellSpacing="0" cellPadding="0" width="767">
							<TR>
								<TD width="100%" colSpan="3" align="center">
									<TABLE style="WIDTH: 769px" border="0" cellSpacing="0" cellPadding="0" width="769">
										<TR bgColor="#f0f0f0">
											<TD colSpan="10"><asp:imagebutton id="ibtnFiltrar" runat="server" DESIGNTIMEDRAGDROP="481" ImageUrl="../../imagenes/filtrar.gif"
													Visible="False"></asp:imagebutton><IMG style="CURSOR: hand" id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);"
													alt="Aplicar Filtro por Selección" src="../../imagenes/filtroporseleccion.jpg" runat="server">
												<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													Visible="False" ToolTip="Eliminar Filtro.."></asp:imagebutton><asp:label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="TextoNegroNegrita">Beneficiarios:</asp:label><asp:dropdownlist style="Z-INDEX: 0" id="ddlBeneficiarios" runat="server" CssClass="combos" AutoPostBack="True"
													Width="320px"></asp:dropdownlist></TD>
											<TD align="left"><asp:imagebutton style="Z-INDEX: 0" id="imgRptFianzas" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/Pdf.gif"></asp:imagebutton></TD>
											<TD align="right"><asp:imagebutton id="imgRptFianzas1" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/xls.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="769px" ShowFooter="True" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" PageSize="7">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="ENTIDAD FINANCIERA">
												<HeaderStyle Width="15%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Cant" SortExpression="Cant" HeaderText="CANT">
												<HeaderStyle Width="3%" VerticalAlign="Middle"></HeaderStyle>
												<FooterStyle VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="CALLAO">
												<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Bottom"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; WIDTH: 230px; HEIGHT: 10px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"
																colSpan="2" align="center">
																<asp:Label id="lblhCallao" runat="server" CssClass="HeaderGrilla" BorderStyle="None" Height="3px"
																	Font-Bold="True">SIMA-CALLAO</asp:Label></TD>
														</TR>
														<TR>
															<TD width="50%" align="center">
																<asp:Label id="Label8" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" BorderStyle="None"
																	Height="3px" Font-Bold="True">SOLES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" width="50%" align="center">
																<asp:Label id="Label10" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" BorderStyle="None"
																	Height="3px" Font-Bold="True">DOLARES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left"
														height="100%">
														<TR>
															<TD width="50%" align="right">
																<asp:Label id="lblMontoCallaoS" runat="server" CssClass="normaldetalle" Width="75px" DESIGNTIMEDRAGDROP="315"
																	BorderStyle="None" Height="12px">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" width="50%" align="right">
																<asp:Label id="lblMontoCallaoD" runat="server" CssClass="normaldetalle" Width="75px" DESIGNTIMEDRAGDROP="503"
																	BorderStyle="None" Height="11px">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterStyle VerticalAlign="Middle"></FooterStyle>
												<FooterTemplate>
													<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left"
														height="100%">
														<TR>
															<TD width="50%" noWrap align="right">
																<asp:Label id="lblFMontoCallaoS" runat="server" CssClass="footerGrilla" Width="75px" DESIGNTIMEDRAGDROP="315"
																	BorderStyle="None" Height="12px">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" width="50%" noWrap align="right">
																<asp:Label id="lblFMontoCallaoD" runat="server" CssClass="footerGrilla" Width="75px" DESIGNTIMEDRAGDROP="503"
																	BorderStyle="None" Height="11px">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="CHIMBOTE">
												<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Bottom"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
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
																	Height="3px" BorderStyle="None">SOLES</asp:Label></TD>
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
																<asp:Label id="lblMontoChimboteS" runat="server" CssClass="normaldetalle" Width="75px" DESIGNTIMEDRAGDROP="315"
																	Height="12px">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="right" width="50%">
																<asp:Label id="lblMontoChimboteD" runat="server" CssClass="normaldetalle" Width="75px" DESIGNTIMEDRAGDROP="503"
																	Height="12px">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterStyle VerticalAlign="Middle"></FooterStyle>
												<FooterTemplate>
													<TABLE id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblFMontoChimboteS" runat="server" CssClass="footerGrilla" Width="75px" DESIGNTIMEDRAGDROP="315"
																	Height="12px" BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right" width="50%">
																<asp:Label id="lblFMontoChimboteD" runat="server" CssClass="footerGrilla" Width="75px" DESIGNTIMEDRAGDROP="503"
																	Height="12px" BorderStyle="None">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="IQUITOS">
												<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Bottom"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
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
																	Height="3px" BorderStyle="None">SOLES</asp:Label></TD>
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
																<asp:Label id="lblMontoIquitosS" runat="server" CssClass="normaldetalle" Width="75px" DESIGNTIMEDRAGDROP="315"
																	Height="3px">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="right" width="50%">
																<asp:Label id="lblMontoIquitosD" runat="server" CssClass="normaldetalle" Width="75px" DESIGNTIMEDRAGDROP="503"
																	Height="3px">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterStyle VerticalAlign="Middle"></FooterStyle>
												<FooterTemplate>
													<TABLE id="Table6" style="HEIGHT: 20px" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblFMontoIquitosS" runat="server" CssClass="footerGrilla" Width="75px" DESIGNTIMEDRAGDROP="315"
																	Height="3px" BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right" width="50%">
																<asp:Label id="lblFMontoIquitosD" runat="server" CssClass="footerGrilla" Width="75px" DESIGNTIMEDRAGDROP="503"
																	Height="3px" BorderStyle="None">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="TOTALES">
												<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Bottom"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
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
																	Height="3px" BorderStyle="None">SOLES</asp:Label></TD>
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
																<asp:Label id="lblMontoTotalS" runat="server" CssClass="normaldetalle" Width="75px" DESIGNTIMEDRAGDROP="315"
																	Height="3px" BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="right" width="50%">
																<asp:Label id="lblMontoTotalD" runat="server" CssClass="normaldetalle" Width="75px" DESIGNTIMEDRAGDROP="503"
																	Height="3px" BorderStyle="None">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterStyle VerticalAlign="Middle"></FooterStyle>
												<FooterTemplate>
													<TABLE id="Table7" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblFMontoTotalS" runat="server" CssClass="footerGrilla" Width="75px" DESIGNTIMEDRAGDROP="315"
																	Height="3px" BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right" width="50%">
																<asp:Label id="lblFMontoTotalD" runat="server" CssClass="footerGrilla" Width="75px" DESIGNTIMEDRAGDROP="503"
																	Height="3px" BorderStyle="None">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="center"><asp:imagebutton style="Z-INDEX: 0" id="btnProyectos" runat="server" ImageUrl="../../imagenes/btnFnzaPorProyecto.jpg"
										Visible="False"></asp:imagebutton><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label><IMG style="WIDTH: 33px; HEIGHT: 12px" src="../../imagenes/spacer.gif" width="33" height="12"></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="center"><cc1:datagridweb id="gridResumen" runat="server" Width="400px" ShowFooter="True" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" PageSize="7">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="headerGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="TITULO" HeaderText="TITULO">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Bottom"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="TOTC" HeaderText="CALLAO">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="TOTCH" HeaderText="CHIMBOTE">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="TOTI" HeaderText="IQUITOS">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="TOTAL" HeaderText="TOTAL">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="center"><asp:label id="lblResultado2" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="left"><IMG style="CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hGridPagina" value="0" size="1" type="hidden"
										name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"><INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hGridPaginaSort" size="1" type="hidden" name="hGridPagina"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td vAlign="top" width="592">
						<div style="VISIBILITY: hidden" id="tblModelo2" runat="server"></div>
					</td>
				</tr>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
