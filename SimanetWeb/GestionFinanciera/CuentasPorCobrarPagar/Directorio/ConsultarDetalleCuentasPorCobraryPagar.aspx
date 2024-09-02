<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarDetalleCuentasPorCobraryPagar.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio.ConsultarDetalleCuentasPorCobraryPagar" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/JSFrameworkSima.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" scroll="yes">
		<form id="Form1" method="post" runat="server">
			,
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="center" vAlign="top" width="100%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD align="center" vAlign="top">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD align="left" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#f0f0f0" colSpan="4">
															<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
																<TR>
																	<TD style="WIDTH: 105px">
																		<asp:label id="Label1" runat="server" CssClass="SubtituloNegrita">CONCEPTO :</asp:label></TD>
																	<TD>
																		<asp:label id="lblDescripcion" runat="server" CssClass="SubtituloNegrita"></asp:label></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 105px">
																		<asp:label id="Label2" runat="server" CssClass="SubtituloNegrita">RAZON SOCIAL :</asp:label></TD>
																	<TD>
																		<asp:label id="lblPrimario" runat="server" CssClass="SubtituloNegrita"></asp:label></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 105px">
																		<asp:label id="Label3" runat="server" CssClass="SubtituloNegrita">Nº DOCUMENTO:</asp:label></TD>
																	<TD>
																		<asp:label id="lblNroDoc" runat="server" CssClass="SubtituloNegrita"></asp:label></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
													Width="100%" PageSize="7">
													<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle Font-Names="Nina" Font-Bold="True" HorizontalAlign="Right" ForeColor="Black" CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO." FooterText="TOTAL:">
															<HeaderStyle Width="1%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Cuentacontable" HeaderText="CUENTA &lt;br&gt;CONTABLE">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NroAsiento" HeaderText="N&#186; &lt;br&gt; ASIENTO">
															<HeaderStyle Width="2%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Wrap="False"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NroEntidad" HeaderText="N&#186; &lt;br&gt;ENTIDAD">
															<HeaderStyle Width="3%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaEmision" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="4%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Descripcion" HeaderText="DESCRIPCION">
															<HeaderStyle Width="20%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Cargo" HeaderText="CARGO">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Abono" HeaderText="ABONO">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
									</TABLE>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
