<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarBitacoraProyectoInversionPublica.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica.ConsultarBitacoraProyectoInversionPublica" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<table cellSpacing="0" cellPadding="0" width="580" align="center" border="0">
			<tr>
				<td width="100%">
					<FORM id="Form1" method="post" runat="server">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD vAlign="top">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<TR width="100%">
											<td>
												<table id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
													<TR>
														<TD class="TituloSecundario"><asp:label id="lblTitulo" runat="server" Width="90%" CssClass="TituloSecundario">&nbsp; BITACORA DE PROYECTOS DE INVERSIÓN PÚBLICA</asp:label></TD>
													</TR>
												</table>
											</td>
										</TR>
										<TR>
											<TD align="center">
												<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center"
													border="0">
													<TR vAlign="top" align="center">
														<TD vAlign="top" align="center" width="100%"><cc1:datagridweb id="grid" runat="server" Width="100%" CssClass="HeaderGrilla" AllowSorting="True"
																AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False">
																<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
																<ItemStyle CssClass="ItemGrilla"></ItemStyle>
																<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
																<FooterStyle CssClass="FooterGrilla"></FooterStyle>
																<Columns>
																	<asp:BoundColumn HeaderText="NRO">
																		<HeaderStyle Width="25px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="FechaBitacora" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
																		<HeaderStyle Width="65px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="DESCRIPCION" HeaderText="DESCRIPCION">
																		<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																		<FooterStyle HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
																	</asp:BoundColumn>
																</Columns>
																<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
															</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
													</TR>
													<TR align="center">
														<TD style="HEIGHT: 6px"><IMG style="WIDTH: 159px; HEIGHT: 6px" height="6" src="../imagenes/spacer.gif" width="159">
														</TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<td style="HEIGHT: 28px" width="100%" colSpan="3">
																		<table id="Table14" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<tr>
																				<TD align="right"><asp:label id="lblNumeroRegistro" runat="server" CssClass="normal">NUMERO DE REGISTROS:</asp:label></TD>
																				<TD width="5"></TD>
																				<TD><asp:label id="lblDblNumeroRegistro" runat="server" Width="100%" CssClass="TextoAzul">0</asp:label></TD>
																			</tr>
																		</table>
																	</td>
																</TR>
																<tr>
																	<td align="center" colSpan="3" height="6"><IMG style="WIDTH: 159px; HEIGHT: 6px" height="6" src="../../imagenes/spacer.gif" width="159"></td>
																</tr>
																<tr>
																	<td></td>
																	<td align="center"><asp:image id="imgCancelar" onclick="window.close()" runat="server" ImageUrl="../../imagenes/bt_cancelar.gif"></asp:image></td>
																	<td></td>
																</tr>
																<tr>
																	<td width="100%" colSpan="3"></td>
																</tr>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR align="center">
											<TD><IMG style="WIDTH: 50px; HEIGHT: 10px" height="2" src="../../imagenes/spacer.gif" width="50"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</FORM>
					<SCRIPT>
						<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
					</SCRIPT>
				</td>
			</tr>
		</table>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
