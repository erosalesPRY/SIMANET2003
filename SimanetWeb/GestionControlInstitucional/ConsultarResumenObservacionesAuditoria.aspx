<%@ Page language="c#" Codebehind="ConsultarResumenObservacionesAuditoria.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Legal.ConsultarResumenObservacionesAuditoria" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 24px" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px" colSpan="3"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Legal></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Resumen de Observaciones</asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD align="left" bgColor="#000080" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
										</TR>
										<TR>
											<TD align="left" colSpan="3">
												<P align="center"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" HorizontalAlign="Center" Width="100%"
														ShowFooter="True" PageSize="15" RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False"
														AllowSorting="True">
														<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
														<ItemStyle CssClass="ItemGrilla"></ItemStyle>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
														<FooterStyle CssClass="FooterGrilla"></FooterStyle>
														<Columns>
															<asp:BoundColumn HeaderText="NRO">
																<HeaderStyle Width="1%" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="NroDocumento" SortExpression="NroDocumento" HeaderText="DOCUMENTO">
																<HeaderStyle Width="15%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="FechaDocumento" SortExpression="FechaDocumento" HeaderText="FEC. DOC."
																DataFormatString="{0:dd-MM-yyyy}">
																<HeaderStyle Width="8%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Observacion" SortExpression="Observacion" HeaderText="OBSERVACION">
																<HeaderStyle Width="25%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="pendientes" SortExpression="pendientes" HeaderText="PENDIENTE">
																<HeaderStyle Width="5%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="superados" SortExpression="PROCESO" HeaderText="PROCESO">
																<HeaderStyle Width="5%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="informado" SortExpression="informado" HeaderText="INFORMADO">
																<HeaderStyle Width="5%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="PROCESO" SortExpression="Superados" HeaderText="IMPLEMENT.">
																<HeaderStyle Width="5%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Total" SortExpression="Total" HeaderText="TOTAL">
																<HeaderStyle Width="5%"></HeaderStyle>
															</asp:BoundColumn>
														</Columns>
														<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													</cc1:datagridweb></P>
											</TD>
										</TR>
									</TABLE>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<td width="15%">&nbsp;<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></td>
								<TD vAlign="top"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
										runat="server"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hCodigo"
										runat="server"> <INPUT id="hIdTipoSeguimiento" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1"
										name="hIdTipoSeguimiento" runat="server">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TABLE></form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
