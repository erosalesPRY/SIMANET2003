<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarCartaFianzaResumendeBancosporCentro.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasFianza.ConsultarCartaFianzaResumendeBancosporCentro" %>
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
					<TD class="RutaPaginaActual" vAlign="top" align="left" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Carta Fianza Resumen de Bancos por Centro</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="767" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE class="tabla" id="TblTabs" style="HEIGHT: 8px" cellSpacing="0" cellPadding="0" width="760"
										bgColor="#f5f5f5" border="0" runat="server">
										<TR>
											<TD style="WIDTH: 37px; HEIGHT: 1px">
												<P align="right"><asp:label id="Label2" runat="server" CssClass="TituloPrincipal">FIANZA  :</asp:label></P>
											</TD>
											<TD style="HEIGHT: 1px"><asp:label id="lblSituacion" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE style="WIDTH: 769px" cellSpacing="0" cellPadding="0" width="769" border="0">
										<TR bgColor="#f0f0f0">
											<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD><asp:imagebutton id="ibtnFiltrar" runat="server" DESIGNTIMEDRAGDROP="481" ImageUrl="../../imagenes/filtrar.gif" Visible="False"></asp:imagebutton></TD>
											<TD style="WIDTH: 117px"><IMG id="ibtnFiltrarSeleccion" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
													alt="Aplicar Filtro por Selección" src="../../imagenes/filtroporseleccion.jpg" runat="server"></TD>
											<TD style="WIDTH: 374px"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD style="WIDTH: 374px"></TD>
											<TD style="WIDTH: 374px">&nbsp;&nbsp;<IMG height="8" src="../imagenes/spacer.gif" width="250"></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" DESIGNTIMEDRAGDROP="262" PageSize="7" AllowPaging="True"
										AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" ShowFooter="True"
										Width="769px">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%" VerticalAlign="Middle"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="ENTIDAD FINANCIERA">
												<HeaderStyle Width="15%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="CALLAO">
												<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Bottom"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px" align="center" width="100%"
																colSpan="2">
																<asp:Label id="lblhCallao" runat="server" CssClass="HeaderGrilla" BorderStyle="None" Height="3px" Font-Bold="True">SIMA-CALLAO</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="Label8" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" BorderStyle="None" Height="3px" Font-Bold="True">SOLES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="50%">
																<asp:Label id="Label10" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" BorderStyle="None" Height="3px" Font-Bold="True">DOLARES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="50%" height="100%">
																<asp:Label id="lblMontoCallaoS" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315" Width="72px" Height="3px">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="right" width="50%">
																<asp:Label id="lblMontoCallaoD" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503" Width="73px" Height="3px">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table2" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="50%" height="100%">
																<asp:Label id="lblFMontoCallaoS" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315" Width="72px" BorderStyle="None" Height="3px">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right" width="50%">
																<asp:Label id="lblFMontoCallaoD" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="503" Width="73px" BorderStyle="None" Height="3px">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label><IMG style="WIDTH: 33px; HEIGHT: 12px" height="12" src="../../imagenes/spacer.gif" width="33"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 11px" align="center" width="100%" colSpan="3"></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td vAlign="top" width="592">
						<div id="tblModelo2" style="VISIBILITY: hidden" runat="server"></div>
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
