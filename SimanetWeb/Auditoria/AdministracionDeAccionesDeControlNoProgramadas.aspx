<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministracionDeAccionesDeControlNoProgramadas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Auditoria.AdministracionDeAccionesDeControlNoProgramadas" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
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
		<form id="Form1" method="post" runat="server" onkeydown="return verificarBackspace()">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="1">
						<uc1:header id="Header2" runat="server"></uc1:header>
					</TD>
				</TR>
				<TR>
					<TD>
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión de Control ></asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración de Actividades de Control No Programadas</asp:label></TD>
							</TR>
							<TR>
								<TD align="left">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD align="center" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="550" border="0">
													<TR>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../imagenes/tab_izq.gif" width="4"></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton></TD>
														<TD style="WIDTH: 115px" vAlign="middle"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><IMG height="8" src="../imagenes/spacer.gif" width="400"></TD>
														<TD bgColor="#f0f0f0">&nbsp;</TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
														<TD align="right" width="4"><IMG height="22" src="../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" align="center" ShowFooter="True" AutoGenerateColumns="False"
													AllowSorting="True" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False"
													Width="780px" PageSize="7" DataKeyField="IdAccionControlNoProgramada" CssClass="HeaderGrilla">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="IdAccionControlNoProgramada" SortExpression="IdAccionControlNoProgramada"
															HeaderText="IdAccionControlNoProgramada"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="NRO">
															<HeaderStyle HorizontalAlign="Center" Width="5px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn SortExpression="Descripcion" HeaderText="ACCION CORRECTIVA">
															<HeaderStyle HorizontalAlign="Left" Width="250px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<ItemTemplate>
																<INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
																	runat="server">
																<asp:HyperLink id="hlkId" runat="server">Modificar</asp:HyperLink>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="Solicitante" SortExpression="Solicitante" HeaderText="SOLICITANTE">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CentroOperativo" SortExpression="CentroOperativo" HeaderText="CO">
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Area" SortExpression="Area" HeaderText="AREA">
															<HeaderStyle Width="200px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaInicio" SortExpression="FechaInicio" HeaderText="FI" DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="60px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaFin" SortExpression="FechaFin" HeaderText="FT" DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="60px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PorcAvance" SortExpression="PorcAvance" HeaderText="%" DataFormatString="{0:##}">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<mbrsc:RowSelectorColumn SelectionMode="Single">
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</mbrsc:RowSelectorColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb>
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="48"></asp:label></TD>
										</TR>
									</TABLE>
									<asp:imagebutton id="ibtnAtras" runat="server" ImageUrl="../imagenes/atras.gif" CausesValidation="False"></asp:imagebutton><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
										runat="server">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
