<%@ Page language="c#" Codebehind="CronogramaPagosConvenioSimaMgp.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.CronogramaPagosConvenioSimaMgp" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<FORM id="form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD>
						<uc1:header id="Header1" runat="server"></uc1:header>
					</TD>
				</TR>
				<tr>
					<TD vAlign="top"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Convenio</asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Periodo de Unidades de Apoyo</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD><asp:label id="lblTitulo" runat="server" CssClass="TituloSecundario"> CRONOGRAMA DE PAGOS DEL CONVENIO SIMA - MGP...</asp:label></TD>
										</TR>
										<TR>
											<TD width="100%" align="center"><asp:label id="lblSubtitulo1" runat="server" CssClass="TituloSecundario">DENTRO DEL PROGRAMA</asp:label>
												<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD align="right" bgColor="#f5f5f5" colSpan=""><asp:imagebutton id="ibtnImprimir" runat="server" CausesValidation="False" Visible="False" ImageUrl="../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="dgPagoProgramado" runat="server" ShowFooter="True" AllowSorting="True" AutoGenerateColumns="False"
													RowHighlightColor="#E0E0E0" RowPositionEnabled="False" Width="780px" CssClass="HeaderGrilla"
													PageSize="7" AllowPaging="True">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="Item" FooterText="TOTAL:">
															<HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Orden" HeaderText="Orden"></asp:BoundColumn>
														<asp:BoundColumn DataField="Periodo" SortExpression="Orden" HeaderText="PERIODO">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoProgramado" SortExpression="MontoProgramado" HeaderText="PROGRAMADO"
															DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="130px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoRecibido" SortExpression="MontoProgramado" HeaderText="RECIBIDO"
															DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="130px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoPendiente" SortExpression="MontoPendiente" HeaderText="PENDIENTE"
															DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="OBSERV.">
															<HeaderStyle Width="85px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="imgObs" runat="server" ImageUrl="../imagenes/BtPU_Mas.gif"></asp:ImageButton>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb><asp:label id="lblResultado1" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD align="center" width="100%"><asp:label id="lblSubtitulo2" runat="server" CssClass="TituloSecundario">FUERA DEL PROGRAMA</asp:label>
												<cc1:datagridweb id="dgPagoNoProgramado" runat="server" ShowFooter="True" AllowSorting="True" AutoGenerateColumns="False"
													RowHighlightColor="#E0E0E0" RowPositionEnabled="False" Width="780px" CssClass="HeaderGrilla">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="Item" FooterText="TOTAL:">
															<HeaderStyle HorizontalAlign="Center" Width="70px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Orden" HeaderText="Orden"></asp:BoundColumn>
														<asp:BoundColumn DataField="Periodo" HeaderText="PERIODO">
															<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="PROGRAMADO">
															<HeaderStyle Width="130px"></HeaderStyle>
															<FooterStyle HorizontalAlign="Center" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoRecibido" HeaderText="RECIBIDO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="130px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="PENDIENTE">
															<HeaderStyle Width="147px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="OBSERV.">
															<HeaderStyle Width="85px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="imgObs" runat="server" ImageUrl="../imagenes/BtPU_Mas.gif"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb><asp:label id="lblResultado2" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<tr>
											<td align="center"><IMG style="WIDTH: 168px; HEIGHT: 2px" height="2" src="../imagenes/spacer.gif" width="168"></td>
										</tr>
										<tr>
											<td style="HEIGHT: 4px"></td>
										</tr>
										<tr>
											<td>
												<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD></TD>
														<TD align="right"><asp:label id="lblTotalRecibido" runat="server" CssClass="normal" Width="100%">TOTAL RECIBIDO NS: &nbsp;</asp:label></TD>
														<TD style="WIDTH: 147px" align="right"><asp:label id="lblDbTotalRecibido" runat="server" CssClass="TextoAzul" Width="100%">0.00</asp:label></TD>
														<TD style="WIDTH: 106px"></TD>
													</TR>
													<TR>
														<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif"></TD>
														<TD align="right"><asp:label id="lblSaldoConvenio" runat="server" CssClass="normal" Width="100%">SALDO CONVENIO NS: &nbsp;</asp:label></TD>
														<TD style="WIDTH: 147px" align="right"><asp:label id="lblDbSaldoConvenio" runat="server" CssClass="TextoAzul" Width="100%">0.00</asp:label></TD>
														<TD style="WIDTH: 106px"></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
