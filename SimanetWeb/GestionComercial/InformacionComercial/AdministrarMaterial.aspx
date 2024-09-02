<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="AdministrarMaterial.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InformacionComercial.AdministrarMaterial" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
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
					<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Informacion Comercial > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración de Material</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
							<TR>
								<td align="center">
									<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="600" border="0">
										<TR>
											<TD align="center" colSpan="3">
												<TABLE id="Table4" style="WIDTH: 601px; HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="601"
													border="0">
													<TR>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
														<TD style="WIDTH: 115px" vAlign="middle" bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
														<TD style="WIDTH: 514px" bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="300"></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif" Visible="False"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"></TD>
														<TD bgColor="#f0f0f0"></TD>
														<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" PageSize="7" RowPositionEnabled="False"
													RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True"
													Width="600px" ShowFooter="True">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO">
															<HeaderStyle Width="5%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCI&#211;N">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Tipo" SortExpression="Tipo" HeaderText="TIPO">
															<HeaderStyle Width="15px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Medida" SortExpression="Medida" HeaderText="UM">
															<HeaderStyle Width="20%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False" DESIGNTIMEDRAGDROP="56"></asp:label></TD>
										</TR>
										<TR>
											<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
										<TR>
											<TD align="left"><INPUT id="hCodigo" style="WIDTH: 16px" type="hidden" size="1" name="hCodigo" runat="server"></TD>
										</TR>
									</TABLE>
								</td>
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
