<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="AdministracionObservacionesProgramacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.AdministracionObservacionesProgramacion" %>
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
		<form id="Form1" method="post" runat="server"></TD></TR><tr>
				<td></TABLE>
					<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
						<TR>
							<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
						</TR>
						<TR>
							<TD colSpan="3"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
						</TR>
						<TR>
							<TD vAlign="top">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
									<TR>
										<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >  Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración Gestiones de Programación</asp:label></TD>
									</TR>
								</TABLE>
								<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center"
									border="0">
									<TR>
										<TD vAlign="top" align="center" colSpan="3">
											<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="777" border="0">
												<TR>
													<TD class="TituloPrincipal" vAlign="top" align="center" colSpan="8"><asp:label id="lblSubTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
												</TR>
												<TR>
													<TD bgColor="#f0f0f0"></TD>
													<TD bgColor="#f0f0f0"><IMG style="WIDTH: 504px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="504"></TD>
													<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
													<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
													<TD bgColor="#f0f0f0"></TD>
													<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
													<TD bgColor="#f0f0f0"></TD>
													<TD bgColor="#f0f0f0"></TD>
													<TD style="WIDTH: 7px" align="right" width="7"><IMG style="WIDTH: 2px; HEIGHT: 25px" height="25" src="../imagenes/tab_der.gif" width="2"></TD>
												</TR>
												<TR>
													<TD vAlign="top" colSpan="9"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" ShowFooter="True" AllowPaging="True"
															AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" Width="780px" PageSize="7" >
<AlternatingItemStyle CssClass="AlternateItemGrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO.">
<HeaderStyle Width="5%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Gestion" SortExpression="Gestion" HeaderText="GESTION">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="FechaGestion" SortExpression="FechaGestion" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="DescripcionGestion" SortExpression="DescripcionGestion" HeaderText="DESCRIPCION">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
														</cc1:datagridweb></TD>
												</TR>
											</TABLE>
											<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
									</TR>
								</TABLE>
								<table width="780" align="center">
									<tr>
										<td align="left" width="700"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif">&nbsp;<INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
												name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
												runat="server">
										</td>
									</tr>
								</table>
								<INPUT id="hCodigo" style="WIDTH: 24px; HEIGHT: 6px" type="hidden" size="1" name="hCodigo"
									runat="server">
							</TD>
						</TR>
					</TABLE>
				</td>
			</tr></TABLE></form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
