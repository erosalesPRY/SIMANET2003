<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarPromotoresPorVentas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Promotores.ConsultarPromotoresPorVentas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
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
					<TD colSpan="3">
						<DIV align="center">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
								<TR>
									<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Comercial > Promotores </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Promotores</asp:label></TD>
								</TR>
								<TR>
									<TD align="center">
										<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center"
											border="0">
											<TR>
												<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif" Visible="False"></asp:imagebutton>&nbsp;
													<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
														Visible="False"></asp:imagebutton></TD>
												<TD align="right" bgColor="#f0f0f0"><IMG style="HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="1">
													<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif" Visible="False"></asp:imagebutton></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" bgColor="#f0f0f0" colSpan="3" rowSpan="1">
													<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="0">
														<TR>
															<TD align="center"><asp:label id="lblTipoContrato" runat="server" CssClass="subtitulo">Estado de Promotor</asp:label></TD>
														</TR>
														<TR>
															<TD align="center"><asp:dropdownlist id="ddlbEstado" runat="server" CssClass="normaldetalle" AutoPostBack="True">
																	<asp:ListItem Value="1" Selected="True">Vigentes</asp:ListItem>
																	<asp:ListItem Value="0">No Vigentes</asp:ListItem>
																</asp:dropdownlist></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD vAlign="top" colSpan="4"></TD>
											</TR>
											<TR>
												<TD colSpan="4"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="100%" RowPositionEnabled="False"
														RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True"
														PageSize="7">
														<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
														<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
														<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla"></FooterStyle>
														<ItemStyle CssClass="ItemGrilla"></ItemStyle>
														<Columns>
															<asp:BoundColumn HeaderText="NRO">
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle HorizontalAlign="Left"></FooterStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="PROMOTOR" SortExpression="PROMOTOR" HeaderText="PROMOTOR">
																<HeaderStyle Width="30%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle HorizontalAlign="Left"></FooterStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="REPRESENTANTELEGAL" SortExpression="REPRESENTANTELEGAL" HeaderText="REPRESENTANTE LEGAL">
																<HeaderStyle Width="25%" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="NROCONTRATO" SortExpression="NROCONTRATO" HeaderText="NRO. CONTRATO">
																<HeaderStyle Width="10%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="FECHATERMINOCONTRATO" SortExpression="FECHATERMINOCONTRATO" HeaderText="VIGENCIA"
																DataFormatString="{0:dd-MM-yyyy}">
																<HeaderStyle Width="10%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="TOTALVENTAS" SortExpression="TOTALVENTAS" HeaderText="TOTAL VENTAS (S/.)"
																DataFormatString="{0:# ### ### ##0.00}">
																<HeaderStyle Width="12%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="RETRIBUCION" SortExpression="RETRIBUCION" HeaderText="RETRIB. ECON. ($)"
																DataFormatString="{0:# ### ### ##0.00}">
																<HeaderStyle Width="13%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																<ItemTemplate>
																	<asp:Image id="img" runat="server" Visible="False" ImageUrl="../../imagenes/CheckYes.png" Height="18px"></asp:Image>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla"></HeaderStyle>
													</cc1:datagridweb></TD>
											</TR>
											<TR>
												<TD colSpan="4"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
											</TR>
											<TR>
												<TD align="right" colSpan="4"><INPUT id="hPagina" type="hidden" value="0">&nbsp;</TD>
											</TR>
										</TABLE>
										<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
								</TR>
								<TR>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
				<TR bgColor="#5891ae">
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
		<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
