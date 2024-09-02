<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministracionNormasDeControl.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Auditoria.AdministracionNormasDeControl" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" onkeydown="return verificarBackspace()" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></TD>
					</TR>
					<TR>
						<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
					</TR>
					<TR>
						<TD align="center">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" align="center" border="0">
								<TR>
									<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión de Control ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración de Normas de Control</asp:label></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3">
										<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" border="0">
											<TR>
												<TD><asp:label id="Label12" runat="server" CssClass="normal">Descripci&oacute;n:</asp:label></TD>
												<TD><INPUT id="filMyFile" style="WIDTH: 311px; HEIGHT: 22px" type="file" size="32" name="filMyFile"
														runat="server"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="left">
										<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" align="center"
											border="0">
											<TR>
												<TD align="center" colSpan="3">
													<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="550" border="0">
														<TR>
															<TD bgColor="#f0f0f0"><IMG height="22" src="../imagenes/tab_izq.gif" width="4"></TD>
															<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton></TD>
															<TD style="WIDTH: 115px" vAlign="middle"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
																	ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
															<TD bgColor="#f0f0f0"><IMG style="HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="485"></TD>
															<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
															<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
															<TD align="right" width="4"><IMG height="22" src="../imagenes/tab_der.gif" width="4"></TD>
														</TR>
													</TABLE>
													<cc1:datagridweb id="grid" runat="server" PageSize="7" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
														RowHighlightColor="#E0E0E0" RowPositionEnabled="False" Width="780px" ShowFooter="True" align="center"
														CssClass="HeaderGrilla">
														<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
														<ItemStyle CssClass="ItemGrilla"></ItemStyle>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
														<FooterStyle CssClass="FooterGrilla"></FooterStyle>
														<Columns>
															<asp:BoundColumn Visible="False" DataField="IdArchivo" SortExpression="IdArchivo" HeaderText="IdArchivo"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="RUTA">
																<HeaderStyle Width="95%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
																<ItemTemplate>
																	<asp:HyperLink id="hlkId" runat="server"></asp:HyperLink>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<asp:CheckBox id="cbxEliminar" runat="server"></asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
											</TR>
										</TABLE>
										<asp:imagebutton id="ibtnAtras" runat="server" ImageUrl="../imagenes/atras.gif" CausesValidation="False"></asp:imagebutton>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" width="780"><IMG height="5" src="../imagenes/spacer.gif" width="592"></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TR></TBODY></TABLE></FORM>
	</body>
</HTML>
