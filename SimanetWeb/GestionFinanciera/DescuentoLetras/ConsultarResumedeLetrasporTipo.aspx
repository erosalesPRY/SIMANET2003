<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarResumedeLetrasporTipo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras.ConsultarResumedeLetrasporTipo" %>
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
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" align="left" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Fainanciera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Letras ></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="300" border="0">
							<TR>
								<TD align="left">
									<TABLE id="Table3" style="WIDTH: 424px; HEIGHT: 27px" cellSpacing="1" cellPadding="1" width="424"
										align="left" border="0">
										<TR>
											<TD style="WIDTH: 38px"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="16px" ForeColor="Black"
													Width="32px">TIPO :</asp:label></TD>
											<TD><asp:dropdownlist id="ddlbTipoLetra" runat="server" CssClass="combos" Width="238px" AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE cellSpacing="0" cellPadding="0" width="769" border="0">
										<TR bgColor="#f0f0f0">
											<TD><IMG src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD></TD>
											<TD style="WIDTH: 117px"><IMG id="ibtnFiltrarSeleccion" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
													alt="Aplicar Filtro por Selección" src="../../imagenes/filtroporseleccion.jpg" runat="server"></TD>
											<TD style="WIDTH: 374px"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD style="WIDTH: 374px"></TD>
											<TD><IMG height="8" src="../imagenes/spacer.gif" width="250"></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="769px" ShowFooter="True" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" PageSize="7">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="3%" VerticalAlign="Middle"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Situacion" SortExpression="Situacion" HeaderText="SITUACION">
												<HeaderStyle Width="30%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="CALLAO">
												<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Bottom"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="2">
																<asp:Label id="lblhCallao" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None"
																	Font-Bold="True">SIMA-CALLAO</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="Label8" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None"
																	Font-Bold="True">SOLES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="50%">
																<asp:Label id="Label10" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None"
																	Font-Bold="True">DOLARES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="50%">
																<asp:Label id="lblMontoCallaoS" runat="server" CssClass="normaldetalle" Width="64px" Height="3px"
																	BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="50%">
																<asp:Label id="lblMontoCallaoD" runat="server" CssClass="normaldetalle" Width="65px" Height="3px"
																	BorderStyle="None">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblFMontoCallaoS" runat="server" CssClass="footerGrilla" Width="64px" Height="3px"
																	BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="50%">
																<asp:Label id="lblFMontoCallaoD" runat="server" CssClass="footerGrilla" Width="65px" Height="3px"
																	BorderStyle="None">AL MES</asp:Label></TD>
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
																<asp:Label id="lblHChimbote" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None"
																	Font-Bold="True">SIMA-CHIMBOTE</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="Label88" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None"
																	Font-Bold="True">SOLES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="50%">
																<asp:Label id="Label11" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None"
																	Font-Bold="True">DOLARES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="50%">
																<asp:Label id="lblMontoChimboteS" runat="server" CssClass="normaldetalle" Width="64px" Height="3px"
																	BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="50%">
																<asp:Label id="lblMontoChimboteD" runat="server" CssClass="normaldetalle" Width="64px" Height="3px"
																	BorderStyle="None">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table6" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblFMontoChimboteS" runat="server" CssClass="footerGrilla" Width="64px" Height="3px"
																	BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="50%">
																<asp:Label id="lblFMontoChimboteD" runat="server" CssClass="footerGrilla" Width="64px" Height="3px"
																	BorderStyle="None">AL MES</asp:Label></TD>
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
																<asp:Label id="lblHIquitos" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None"
																	Font-Bold="True">SIMA-IQUITOS S.R.Ltda.</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="Label888" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None"
																	Font-Bold="True">SOLES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="50%">
																<asp:Label id="Label111" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None"
																	Font-Bold="True">DOLARES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="50%">
																<asp:Label id="lblMontoIquitosS" runat="server" CssClass="normaldetalle" Width="64px" Height="3px">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="50%">
																<asp:Label id="lblMontoIquitosD" runat="server" CssClass="normaldetalle" Width="64px" Height="3px">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table7" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblFMontoIquitosS" runat="server" CssClass="footerGrilla" Width="64px" Height="3px"
																	BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="50%">
																<asp:Label id="lblFMontoIquitosD" runat="server" CssClass="footerGrilla" Width="64px" Height="3px"
																	BorderStyle="None">AL MES</asp:Label></TD>
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
																<asp:Label id="lblHTotal" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None"
																	Font-Bold="True">TOTALES</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="Label8888" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None"
																	Font-Bold="True">SOLES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="50%">
																<asp:Label id="Label11111" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None"
																	Font-Bold="True">DOLARES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="50%">
																<asp:Label id="lblMontoTotalS" runat="server" CssClass="normaldetalle" Width="64px" Height="12px">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="50%">
																<asp:Label id="lblMontoTotalD" runat="server" CssClass="normaldetalle" Width="64px" Height="12px">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table8" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%">
																<asp:Label id="lblFMontoTotalS" runat="server" CssClass="footerGrilla" Width="64px" Height="12px"
																	BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="50%">
																<asp:Label id="lblFMontoTotalD" runat="server" CssClass="footerGrilla" Width="64px" Height="12px"
																	BorderStyle="None">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
										align="left"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
