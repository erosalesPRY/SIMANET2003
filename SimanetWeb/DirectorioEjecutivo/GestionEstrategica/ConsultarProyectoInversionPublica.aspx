<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="ConsultarProyectoInversionPublica.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica.ConsultarProyectoInversionPublica" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body style="OVERFLOW-Y: scroll; OVERFLOW-X: hidden; WIDTH: 100%" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td width="100%">
					<FORM id="Form1" method="post" runat="server">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR vAlign="baseline" align="left" bgColor="#eff7fa">
								<TD width="100%"><uc1:headerinicio id="HeaderInicio1" runat="server"></uc1:headerinicio></TD>
							</TR>
							<tr>
								<TD vAlign="top" width="100%"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
							</tr>
							<TR>
								<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio> Proyectos  ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> PROYECTOS DE INVERSION PÚBLICA</asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="775" align="center" border="0">
										<TR width="100%">
											<td>
												<table id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
													<tr>
														<td>
														</td>
													</tr>
												</table>
											</td>
										<TR>
											<TD align="center">
												<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD align="center" width="100%"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="775px" PageSize="7" RowPositionEnabled="False"
																RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
																<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
																<ItemStyle CssClass="ItemGrilla"></ItemStyle>
																<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
																<FooterStyle CssClass="FooterGrilla"></FooterStyle>
																<Columns>
																	<asp:TemplateColumn HeaderText="NRO">
																		<HeaderStyle Width="25px"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																		<ItemTemplate>
																			<asp:HyperLink id="hlkId" runat="server">Nro</asp:HyperLink>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:BoundColumn DataField="CodigoProyecto" SortExpression="CodigoProyecto" HeaderText="CODIGO">
																		<HeaderStyle Width="80px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="DESCRIPCIONABREVIADA" SortExpression="DESCRIPCIONABREVIADA" HeaderText="PROYECTO">
																		<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																		<FooterStyle HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="Financiamiento" SortExpression="Financiamiento" HeaderText="FINANCIAMIENTO">
																		<HeaderStyle Width="120px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="FechaInicio" SortExpression="FechaInicio" HeaderText="INICIO" DataFormatString="{0:dd-MM-yyyy}">
																		<HeaderStyle Width="65px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn SortExpression="PorcAvanceFisicoUltimoDirectorio" HeaderText="% ANT">
																		<HeaderStyle Width="40px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn SortExpression="PorcAvanceFisicoActual" HeaderText="% ACT">
																		<HeaderStyle Width="40px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="MontoAsignadoSoles" SortExpression="MontoAsignadoSoles" HeaderText="MONTO NS"
																		DataFormatString="{0:# ### ### ##0.00}">
																		<HeaderStyle Width="100px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
																		<FooterStyle HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
																	</asp:BoundColumn>
																	<asp:TemplateColumn HeaderText="BITAC">
																		<HeaderStyle Width="40px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																		<ItemTemplate>
																			<asp:Image id="imgBitacora" runat="server" Height="18px" ImageUrl="../imagenes/ley1.gif"></asp:Image>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																</Columns>
																<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
															</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
													</TR>
													<TR align="center">
														<TD height="6"></TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<td width="100%" colSpan="3">
																		<table id="Table14" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<tr>
																				<TD align="right"><asp:label id="lblNumeroRegistro" runat="server" CssClass="normal">NUMERO DE REGISTROS:</asp:label></TD>
																				<TD width="5"></TD>
																				<TD><asp:label id="lblDblNumeroRegistro" runat="server" CssClass="TextoAzul" Width="100%">0</asp:label></TD>
																			</tr>
																		</table>
																		<INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="hCodigo"
																			runat="server"></td>
																</TR>
																<tr>
																	<td align="center" colSpan="3" height="6"><IMG style="WIDTH: 159px; HEIGHT: 6px" height="6" src="../imagenes/spacer.gif" width="159"></td>
																</tr>
																<tr>
																	<td vAlign="bottom" align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif"></td>
																	<td align="center">
																	</td>
																	<td></td>
																</tr>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
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
