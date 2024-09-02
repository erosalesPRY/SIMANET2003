<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleConsultarPromotoresPorVentas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Promotores.DetalleConsultarPromotoresPorVentas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleConsultarPromotoresPorVentas</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Comercial > Promotores </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Consulta de Promotores por Ventas</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" colSpan="3" align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> DETALLE DE PROMOTORES POR VENTAS</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="550" border="0">
										<TR>
											<TD align="center" width="100%" colSpan="3">
												<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
													<TR>
														<TD style="WIDTH: 618px" bgColor="#f0f0f0"></TD>
														<TD bgColor="#f0f0f0" align="right">
															<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton>
														</TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" PageSize="7" ShowFooter="True" AllowSorting="True" AutoGenerateColumns="False"
													AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" Width="764px" CssClass="HeaderGrilla">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="IDPROMOTOR" SortExpression="IDPROMOTOR" HeaderText="NRO" FooterText="Total:"></asp:BoundColumn>
														<asp:BoundColumn DataField="RAZONSOCIAL" SortExpression="RAZONSOCIAL" HeaderText="Promotor"></asp:BoundColumn>
														<asp:BoundColumn DataField="PAIS" SortExpression="PAIS" HeaderText="PAIS"></asp:BoundColumn>
														<asp:BoundColumn DataField="TOTAL VENTAS" SortExpression="TOTALVENTAS" HeaderText="TOTAL VENTAS"></asp:BoundColumn>
														<asp:TemplateColumn SortExpression="nro" HeaderText="NRO. CONTRATO">
															<ItemTemplate>
																<asp:HyperLink id="hlkContratos" runat="server">Contratos</asp:HyperLink>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="FECHA INICIO" SortExpression="FECHAINICIO" HeaderText="FECHA INICIO"></asp:BoundColumn>
														<asp:BoundColumn DataField="FECHA FIN" SortExpression="FECHAFIN" HeaderText="FECHA FIN"></asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="56"
													Visible="False"></asp:label>
											</TD>
										</TR>
									</TABLE>
									<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160">
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table5" style="WIDTH: 560px; HEIGHT: 66px" cellSpacing="1" cellPadding="1" width="560"
										border="1">
										<TR>
											<TD><asp:label id="lblObservaciones" runat="server" CssClass="normal">Observaciones:</asp:label></TD>
											<TD><asp:textbox id="txtTrabajoEfectuado" runat="server" CssClass="normal" Width="336px" TextMode="MultiLine"
													Height="56px"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
