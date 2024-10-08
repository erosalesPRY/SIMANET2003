<%@ Page language="c#" Codebehind="ConsultarMontoVentasPresupuestadas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.ConsultarMontoVentasPresupuestadas" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
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
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gesti�n Comercial > Ventas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" align="center" colSpan="3"><TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="200" bgColor="#f5f5f5"
										border="0">
										<TR bgColor="#ffffff">
											<TD class="TitFiltros"><IMG height="14" src="../../imagenes/TitFiltros.gif" width="82"></TD>
											<TD class="combos" colSpan="2"></TD>
										</TR>
										<TR>
											<TD><IMG height="8" src="../../imagenes/spacer.gif" width="7">
												<asp:label id="lblVersion" runat="server" CssClass="normal">Versi�n</asp:label></TD>
											<TD class="SmallFont"></TD>
											<TD class="SmallFont"><asp:label id="lblA�o" runat="server" CssClass="normal">A�o</asp:label></TD>
										</TR>
										<TR>
											<TD class="TitFiltros">&nbsp;
												<asp:dropdownlist id="ddlbVersion" runat="server" CssClass="normal" BackColor="White" AutoPostBack="True"
													Width="100px"></asp:dropdownlist></TD>
											<TD class="combos"><IMG height="8" src="../../imagenes/spacer.gif" width="10"></TD>
											<TD class="combos"><asp:dropdownlist id="ddlbA�o" runat="server" CssClass="normal" Width="70px" ForeColor="Black" AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="550" border="0">
										<TR>
											<TD align="center" width="100%" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4">&nbsp;</TD>
														<TD bgColor="#f0f0f0"></TD>
														<TD bgColor="#f0f0f0"></TD>
														<TD align="right" width="200" bgColor="#f0f0f0">&nbsp;&nbsp;</TD>
														<TD style="WIDTH: 121px" align="right" width="121" bgColor="#f0f0f0"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="dgConsulta" runat="server" CssClass="HeaderGrilla" Width="780px" RowPositionEnabled="False"
													AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" PageSize="1">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="Astillero" HeaderText="LN">
															<HeaderStyle Width="20%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="CALLAO">
															<HeaderStyle Width="17%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<HeaderTemplate>
																<asp:HyperLink id="hlkbCallao" runat="server">CALLAO</asp:HyperLink>
															</HeaderTemplate>
															<ItemTemplate>
																<asp:Label id="lblVentasPresupuestadasCallao" runat="server" CssClass="normal" ForeColor="Navy">Ventas Presupuestadas</asp:Label>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="CHIMBOTE">
															<HeaderStyle Width="17%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<HeaderTemplate>
																<asp:HyperLink id="hlkbChimbote" runat="server">CHIMBOTE</asp:HyperLink>
															</HeaderTemplate>
															<ItemTemplate>
																<asp:Label id="lblVentasPresupuestadasChimbote" runat="server" CssClass="normal" ForeColor="Navy">Ventas Presupuestadas</asp:Label>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="IQUITOS">
															<HeaderStyle Width="17%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<HeaderTemplate>
																<asp:HyperLink id="hlkbIquitos" runat="server">IQUITOS</asp:HyperLink>
															</HeaderTemplate>
															<ItemTemplate>
																<asp:Label id="lblVentasPresupuestadasIquitos" runat="server" CssClass="normal" ForeColor="Navy">Ventas Presupuestadas</asp:Label>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="Total" HeaderText="TOTAL">
															<HeaderStyle Width="17%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
									</TABLE>
									<asp:label id="lblResultado1" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
