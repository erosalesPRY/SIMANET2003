<%@ Page language="c#" Codebehind="AdministrarOrdenTrabajoComoperpac.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.AdministrarOrdenTrabajoComoperpac" smartNavigation="True"%>
<%@ Register TagPrefix="cc3" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 24px"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Producción >  Administrar Periodos Convenios COMPOPERPAC</asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> ADMINISTRAR ORDENES DE TRABAJO</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center" width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
							<TR>
								<TD width="100%">
									<table id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td style="WIDTH: 454px"><asp:label id="lblTitulo" runat="server" CssClass="TituloSecundario">ORDENES DE TRABAJO DEL PERIODO...</asp:label></td>
											<td style="WIDTH: 337px"></td>
											<td align="right"></td>
										</tr>
										<tr>
											<td colSpan="3">
												<TABLE class="tabla" id="Table4" cellSpacing="0" cellPadding="0" width="600" align="center"
													bgColor="#f5f5f5">
													<TR bgColor="#ffffff">
														<TD class="TitFiltros" style="WIDTH: 253px; HEIGHT: 18px" width="253"><IMG height="14" src="../imagenes/TitFiltros.gif" width="82"></TD>
														<TD class="combos" style="WIDTH: 588px; HEIGHT: 18px"></TD>
														<td style="WIDTH: 32px; HEIGHT: 18px"></td>
														<TD class="combos" style="WIDTH: 73px; HEIGHT: 18px" width="73"></TD>
														<TD class="combos" style="WIDTH: 531px; HEIGHT: 18px"></TD>
														<TD class="combos" style="WIDTH: 28px; HEIGHT: 18px" width="28"></TD>
														<TD class="combos" style="HEIGHT: 18px" width="316"></TD>
													</TR>
													<TR bgColor="#f5f5f5">
														<TD class="TitFiltros" style="WIDTH: 253px" align="right"><asp:label id="lblPeriodoInicial" runat="server" CssClass="normal"> CENTRO OPERATIVO:&nbsp;</asp:label></TD>
														<TD style="WIDTH: 588px"><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normal" Width="100%"></asp:dropdownlist></TD>
														<td style="WIDTH: 32px"></td>
														<TD style="WIDTH: 73px" align="right"><asp:label id="lblEstado" runat="server" CssClass="normal">ESTADO:&nbsp;</asp:label></TD>
														<TD style="WIDTH: 531px"><asp:dropdownlist id="ddlbEstado" runat="server" CssClass="normal" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD style="WIDTH: 28px"></TD>
														<TD><asp:button id="btnConsultar" runat="server" CssClass="normal" Text="Consultar"></asp:button></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr height="8">
											<td width="100%" colSpan="3"></td>
										</tr>
										<tr>
											<td align="center" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
													<TR>
														<TD style="WIDTH: 6px" bgColor="#f0f0f0"><IMG height="22" src="../imagenes/tab_izq.gif" width="4"></TD>
														<TD style="WIDTH: 301px" bgColor="#f0f0f0">&nbsp;</TD>
														<TD style="WIDTH: 1px" bgColor="#f0f0f0"></TD>
														<TD vAlign="middle" align="right" bgColor="#f0f0f0"><asp:imagebutton id="ibtnListarActividades" runat="server" ImageUrl="../imagenes/btnActividad.gif"></asp:imagebutton><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
														<TD align="right" bgColor="#f0f0f0"></TD>
														<TD style="WIDTH: 6px"><IMG height="22" src="../imagenes/tab_der.gif" width="6"></TD>
													</TR>
												</TABLE>
												<cc2:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="100%" RowHighlightColor="#E0E0E0"
													AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" PageSize="5" Height="58px"
													ShowFooter="True">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
															<HeaderStyle Width="5px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn SortExpression="NroOrdenTrabajo" HeaderText="Orden">
															<HeaderStyle Width="75px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<ItemTemplate>
																<asp:HyperLink id="hlkId" runat="server">NroOT</asp:HyperLink>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="TipoCambio" HeaderText="CAMBIO NS" DataFormatString="{0:###,##0.000}">
															<HeaderStyle Width="65px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Moneda" HeaderText="MONEDA">
															<HeaderStyle Width="60px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoAsignado" SortExpression="MontoAsignado" HeaderText="ASIGNADO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="100px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Descripcion" HeaderText="DESCRIPCION">
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc2:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></td>
										</tr>
										<tr>
											<td align="left" colSpan="3"><asp:label id="lblObservaciones" runat="server" CssClass="normal">OBSERVACIONES</asp:label><IMG style="WIDTH: 160px; HEIGHT: 10px" height="1" src="../imagenes/spacer.gif" width="160"></td>
										</tr>
										<tr>
											<td colSpan="3"><asp:textbox id="txtObservaciones" runat="server" CssClass="normal" Width="100%" Height="55px"
													TextMode="MultiLine" ReadOnly="True"></asp:textbox></td>
										</tr>
										<TR>
											<TD align="left" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="ReemplazaHistorial(); HistorialIrAtras();"
													alt="" src="/SimanetWeb/imagenes/atras.gif"></TD>
										</TR>
										<tr>
											<td align="center" colSpan="3"><IMG style="WIDTH: 160px; HEIGHT: 10px" height="1" src="../imagenes/spacer.gif" width="160"></td>
										</tr>
										<tr>
											<td style="WIDTH: 454px; HEIGHT: 17px"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 15px" type="hidden" size="1" name="hCodigo"
													runat="server"></td>
											<td style="WIDTH: 337px; HEIGHT: 17px"></td>
											<td style="HEIGHT: 17px"></td>
										</tr>
									</table>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
