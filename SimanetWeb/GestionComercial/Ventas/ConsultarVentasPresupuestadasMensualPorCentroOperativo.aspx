<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarVentasPresupuestadasMensualPorCentroOperativo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.ConsultarVentasPresupuestadasMensualPorCentroOperativo" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
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
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"></asp:label><asp:label id="lblMensual" runat="server" CssClass="RutaPaginaActual"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:label id="lblCentroOperativo" runat="server" CssClass="Titulosecundario"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:label id="lblAño" runat="server" CssClass="Titulosecundario"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="550" border="0">
										<TR>
											<TD style="HEIGHT: 200px" align="left" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
														<TD align="right" bgColor="#f0f0f0"><IMG style="WIDTH: 580px; HEIGHT: 8px" height="8" src="../../imagenes/spacer.gif" width="580"></TD>
														<TD bgColor="#f0f0f0">
															<P align="right"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></P>
														</TD>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="dgConsulta" runat="server" CssClass="HeaderGrilla" RowHighlightColor="#E0E0E0"
													AutoGenerateColumns="False" RowPositionEnabled="False" DESIGNTIMEDRAGDROP="68" Width="780px">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="LN" HeaderText="LN" FooterText="TOTAL">
															<HeaderStyle Width="50px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="ENE" FooterText="Enero">
															<HeaderStyle Width="55px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<HeaderTemplate>
																<asp:HyperLink id="hlkbEnero" runat="server">ENE</asp:HyperLink>
															</HeaderTemplate>
															<ItemTemplate>
																<asp:Label id="lblVentasPresupuestadasEnero" runat="server" CssClass="normalDetalle">Ventas</asp:Label>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="FEB" FooterText="Febrero">
															<HeaderStyle Width="55px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<HeaderTemplate>
																<asp:HyperLink id="hlkbFebrero" runat="server">FEB</asp:HyperLink>
															</HeaderTemplate>
															<ItemTemplate>
																<asp:Label id="lblVentasPresupuestadasFebrero" runat="server" CssClass="normalDetalle">Ventas</asp:Label>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="MAR" FooterText="Marzo">
															<HeaderStyle Width="55px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<HeaderTemplate>
																<asp:HyperLink id="hlkbMarzo" runat="server">MAR</asp:HyperLink>
															</HeaderTemplate>
															<ItemTemplate>
																<asp:Label id="lblVentasPresupuestadasMarzo" runat="server" CssClass="normalDetalle">Ventas</asp:Label>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="ABR" FooterText="Abril">
															<HeaderStyle Width="55px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<HeaderTemplate>
																<asp:HyperLink id="hlkbAbril" runat="server">ABR</asp:HyperLink>
															</HeaderTemplate>
															<ItemTemplate>
																<asp:Label id="lblVentasPresupuestadasAbril" runat="server" CssClass="normalDetalle">Ventas</asp:Label>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="MAY" FooterText="Mayo">
															<HeaderStyle Width="55px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<HeaderTemplate>
																<asp:HyperLink id="hlkbMayo" runat="server">MAY</asp:HyperLink>
															</HeaderTemplate>
															<ItemTemplate>
																<asp:Label id="lblVentasPresupuestadasMayo" runat="server" CssClass="normalDetalle">Ventas</asp:Label>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="JUN" FooterText="Junio">
															<HeaderStyle Width="55px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<HeaderTemplate>
																<asp:HyperLink id="hlkbJunio" runat="server">JUN</asp:HyperLink>
															</HeaderTemplate>
															<ItemTemplate>
																<asp:Label id="lblVentasPresupuestadasJunio" runat="server" CssClass="normalDetalle">Ventas</asp:Label>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="JUL" FooterText="Julio">
															<HeaderStyle Width="55px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<HeaderTemplate>
																<asp:HyperLink id="hlkbJulio" runat="server">JUL</asp:HyperLink>
															</HeaderTemplate>
															<ItemTemplate>
																<asp:Label id="lblVentasPresupuestadasJulio" runat="server" CssClass="normalDetalle">Ventas</asp:Label>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="AGO" FooterText="Agosto">
															<HeaderStyle Width="55px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<HeaderTemplate>
																<asp:HyperLink id="hlkbAgosto" runat="server">AGO</asp:HyperLink>
															</HeaderTemplate>
															<ItemTemplate>
																<asp:Label id="lblVentasPresupuestadasAgosto" runat="server" CssClass="normalDetalle">Ventas</asp:Label>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="SET" FooterText="Setiembre">
															<HeaderStyle Width="55px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<HeaderTemplate>
																<asp:HyperLink id="hlkbSetiembre" runat="server">SET</asp:HyperLink>
															</HeaderTemplate>
															<ItemTemplate>
																<asp:Label id="lblVentasPresupuestadasSetiembre" runat="server" CssClass="normalDetalle">Ventas</asp:Label>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="OCT" FooterText="Octubre">
															<HeaderStyle Width="55px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<HeaderTemplate>
																<asp:HyperLink id="hlkbOctubre" runat="server">OCT</asp:HyperLink>
															</HeaderTemplate>
															<ItemTemplate>
																<asp:Label id="lblVentasPresupuestadasOctubre" runat="server" CssClass="normalDetalle">Ventas</asp:Label>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="NOV" FooterText="Noviembre">
															<HeaderStyle Width="55px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<HeaderTemplate>
																<asp:HyperLink id="hlkbNoviembre" runat="server">NOV</asp:HyperLink>
															</HeaderTemplate>
															<ItemTemplate>
																<asp:Label id="lblVentasPresupuestadasNoviembre" runat="server" CssClass="normalDetalle">Ventas</asp:Label>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="DIC" FooterText="Diciembre">
															<HeaderStyle Width="55px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<HeaderTemplate>
																<asp:HyperLink id="hlkbDiciembre" runat="server">DIC</asp:HyperLink>
															</HeaderTemplate>
															<ItemTemplate>
																<asp:Label id="lblVentasPresupuestadasDiciembre" runat="server" CssClass="normalDetalle">Ventas</asp:Label>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="TOTAL">
															<HeaderStyle Width="55px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<ItemTemplate>
																<asp:Label id="lblVentasPresupuestadasTotal" runat="server" CssClass="normalDetalle">Ventas</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb>
												<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center"><IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160"></TD>
							</TR>
						</TABLE>
						<IMG height="5" src="../imagenes/spacer.gif" width="592"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
