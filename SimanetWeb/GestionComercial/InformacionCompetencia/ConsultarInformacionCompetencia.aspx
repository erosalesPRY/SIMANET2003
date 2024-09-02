<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarInformacionCompetencia.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InformacionCompetencia.ConsultarInformacionCompetencia" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarInformacionCompetencia</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="..js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form2" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<td colSpan="3"><uc1:header id="Header2" runat="server"></uc1:header></td>
				</TR>
				<tr>
					<TD colSpan="3"><uc1:menu id="Men2" runat="server"></uc1:menu></TD>
				</tr>
				<tr>
					<td vAlign="top">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TBODY>
								<tr>
									<td class="Commands" style="HEIGHT: 17px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual" Width="232px"> Registro de Información Competencia</asp:label></td>
								</tr>
								<tr>
									<td class="Commands" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> TITULO FORMULARIO</asp:label></td>
								</tr>
								<TR>
									<TD align="right"></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 20px" align="right"></TD>
								</TR>
								<TR>
									<TD align="center">
										<TABLE class="normal" id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
											<TR>
												<TD align="center" width="100%" colSpan="3">
													<TABLE id="Table4" style="WIDTH: 778px; HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="778"
														border="0">
														<TR>
															<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
															<TD bgColor="#f0f0f0"><IMG style="WIDTH: 558px; HEIGHT: 8px" height="8" src="../../imagenes/spacer.gif" width="558"></TD>
															<TD bgColor="#f0f0f0">&nbsp;</TD>
															<TD bgColor="#f0f0f0"></TD>
															<TD align="right" width="4"><IMG style="WIDTH: 5px; HEIGHT: 22px" height="22" src="../../imagenes/tab_der.gif" width="5"></TD>
														</TR>
													</TABLE>
													<cc1:datagridweb id="dgArchivoConsulta" runat="server" CssClass="HeaderGrilla" Width="780px" ShowFooter="True"
														RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True"
														AllowPaging="True" DataKeyField="IdArchivo">
														<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
														<ItemStyle CssClass="ItemGrilla"></ItemStyle>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
														<FooterStyle HorizontalAlign="Left" CssClass="FooterGrilla"></FooterStyle>
														<Columns>
															<asp:BoundColumn HeaderText="NRO.">
																<HeaderStyle Width="35px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="IdArchivo" SortExpression="IdArchivo" HeaderText="IdArchivo">
																<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn SortExpression="RUTA" HeaderText="RUTA">
																<HeaderStyle Width="50%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																<ItemTemplate>
																	<asp:HyperLink id="hlkIdArchivoConsulta" runat="server">Ruta</asp:HyperLink>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn SortExpression="DESCRIPCION" HeaderText="DESCRIPCION">
																<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																<ItemTemplate>
																	<asp:Label id="lblDescripcion" runat="server">Label</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle HorizontalAlign="Left" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													</cc1:datagridweb></TD>
											</TR>
										</TABLE>
										<P><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></P>
									</TD>
								</TR>
							</TBODY>
						</TABLE>
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
							<TR>
								<TD noWrap><IMG id="Img1" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
