<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarDetalleResumenConvenio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.ConsultarDetalleResumenConvenio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();" style="OVERFLOW-Y: scroll; OVERFLOW-X: hidden; WIDTH: 100%">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD>
						<P>
							<uc1:Header id="Header1" runat="server"></uc1:Header></P>
					</TD>
				</TR>
				<tr>
					<TD vAlign="top"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Convenio></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> RESUMEN DE CONVENIO</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
							<TR>
								<TD align="center" width="100%">
									<TABLE id="Table4" style="HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD bgColor="#f5f5f5"><IMG height="22" src="../imagenes/tab_izq.gif" width="4"></TD>
											<TD bgColor="#f5f5f5"></TD>
											<TD bgColor="#f5f5f5">&nbsp;</TD>
											<TD bgColor="#f5f5f5" align="right"><asp:imagebutton id="ibtnImprimir" runat="server" CausesValidation="False" ImageUrl="../imagenes/bt_imprimir.gif"
													Visible="False"></asp:imagebutton></TD>
											<TD align="right" width="4"><IMG height="22" src="../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="dgResumenConvenio" runat="server" Width="100%" PageSize="14" RowPositionEnabled="False"
										RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" CssClass="HeaderGrilla"
										ShowFooter="True">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Periodo" HeaderText="PERIODO" FooterText="TOTAL:">
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="RESUMEN DE CONVENIO">
												<ItemTemplate>
													<cc1:datagridweb id="dgDatos" runat="server" AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
														RowPositionEnabled="False" PageSize="14" Width="100%" ShowFooter="True">
														<ItemStyle CssClass="ItemGrilla"></ItemStyle>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
														<FooterStyle CssClass="FooterGrilla"></FooterStyle>
														<Columns>
															<asp:BoundColumn DataField="convenio" HeaderText="CONVENIO">
																<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="MontoPorCobrar" HeaderText="POR COBRAR" DataFormatString="{0:# ### ### ##0.00}">
																<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Espacio" HeaderText="  "></asp:BoundColumn>
															<asp:BoundColumn DataField="DescripcionConcepto" HeaderText="CONCEPTO">
																<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="MontoPorPagar" HeaderText="POR PAGAR" DataFormatString="{0:# ### ### ##0.00}">
																<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
															</asp:BoundColumn>
														</Columns>
														<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													</cc1:datagridweb>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle ForeColor="#FFFFFF" BackColor="#335EB4" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR height="10" align="center">
								<TD><IMG style="WIDTH: 100px" height="8" src="../imagenes/spacer.gif" width="100">
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<td><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif"></td>
											<TD align="right"><asp:label id="lblMontoPorCobrar" runat="server" CssClass="normal">TOTAL POR COBRAR NS:&nbsp;</asp:label></TD>
											<TD><asp:label id="lblCalMontoPorCobrar" runat="server" CssClass="TextoAzul" Width="140px">0.00</asp:label></TD>
											<TD align="right"><asp:label id="lblMontoPorPagar" runat="server" CssClass="normal">TOTAL POR PAGAR NS:&nbsp;</asp:label></TD>
											<TD><asp:label id="lblCalMontoPorPagar" runat="server" CssClass="TextoAzul" Width="140px">0.00</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<tr align="center">
								<td><IMG style="WIDTH: 160px; HEIGHT: 16px" height="16" src="../imagenes/spacer.gif" width="160"></td>
							</tr>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px"></TD>
				</TR>
			</TABLE>
			</TD></TR></TABLE></FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<P></P>
	</body>
</HTML>
