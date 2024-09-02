<%@ Page language="c#" Codebehind="ConsultarOC_PorOT.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Proyectos.ConsultarOC_PorOT" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" onunload="SubirHistorial();"
		onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td bgColor="#eff7fa" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label style="Z-INDEX: 0" id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Proyectos ></asp:label><asp:label style="Z-INDEX: 0" id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Ordenes de Compra Por OT</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" class="normal" border="0" cellSpacing="0" cellPadding="0" width="100%"
							DESIGNTIMEDRAGDROP="26">
							<TR>
								<TD width="100%" colSpan="3" align="center">
									<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TR bgColor="#f0f0f0">
											<TD><IMG src="../../imagenes/tab_izq.gif" width="4" height="22">
												<asp:label style="Z-INDEX: 0" id="lblTitulo" runat="server" CssClass="SubTituloNegrita"></asp:label></TD>
											<TD></TD>
											<TD>&nbsp;</TD>
											<TD align="right"></TD>
											<TD width="4" align="right"></TD>
										</TR>
										<TR>
											<TD>
												<TABLE style="Z-INDEX: 0" id="Table9" border="0" cellSpacing="0" cellPadding="0" width="100%">
													<TR>
														<TD width="200"></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD width="200"><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnFiltrarSeleccion" title="RazonSocial" onclick="FiltroporSeleccion(1);"
																alt="Aplicar Filtro por Selecci�n" src="../../imagenes/filtroporseleccion.jpg" runat="server">
															<asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminaFiltro" runat="server" ToolTip="Eliminar Filtro.."
																ImageUrl="../../imagenes/filtroEliminar.GIF"></asp:imagebutton></TD>
														<TD>
															<asp:label style="Z-INDEX: 0" id="Label8" runat="server" CssClass="normaldetalle" Width="51px"
																Font-Bold="True"> Buscar :</asp:label><INPUT style="Z-INDEX: 0; BORDER-BOTTOM: #999999 1px groove; BORDER-LEFT: #999999 1px groove; WIDTH: 172px; BORDER-TOP: #999999 1px groove; BORDER-RIGHT: #999999 1px groove"
																onkeydown="BusquedaporCampoColumna(this.value);" id="txtBuscar" class="InputFind" size="23" name="Text1"></TD>
													</TR>
												</TABLE>
											</TD>
											<TD></TD>
											<TD></TD>
											<TD align="right"></TD>
											<TD width="4" align="right"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" PageSize="15" ShowFooter="True" Width="100%" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>

<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<FooterStyle Font-Bold="True" CssClass="footerGrilla">
</FooterStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO">
<HeaderStyle Width="1%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="actividad" SortExpression="actividad" HeaderText="ACTIVIDAD">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="DES_RCS" SortExpression="DES_RCS" HeaderText="RECURSO">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CNT_DML" SortExpression="CNT_DML" HeaderText="DIM. LARGO">
<HeaderStyle VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CNT_DMA" SortExpression="CNT_DMA" HeaderText="DIM. ANCHO">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="UND_MED" SortExpression="UND_MED" HeaderText="UNID.MED.">
<HeaderStyle Width="3%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CNT_REQ_OT" SortExpression="CNT_REQ_OT" HeaderText="CANT. REQUERIDA">
<ItemStyle HorizontalAlign="Right">
</ItemStyle>

<FooterStyle HorizontalAlign="Right">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CNT_ATE_OT" SortExpression="CNT_ATE_OT" HeaderText="CANT.ATENDIDA">
<ItemStyle HorizontalAlign="Right">
</ItemStyle>

<FooterStyle HorizontalAlign="Right">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NRO_OCO" SortExpression="NRO_OCO" HeaderText="O/C">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="COD_PRV" SortExpression="COD_PRV" HeaderText="PROVEEDOR">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="FEC_EMS" SortExpression="FEC_EMS" HeaderText="FECHA O/C" DataFormatString="{0:dd-MM-yyyy}">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="COD_MON" SortExpression="COD_MON" HeaderText="MONEDA">
<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TOT_OCO" SortExpression="TOT_OCO" HeaderText="IMPORTE TOTAL">
<ItemStyle HorizontalAlign="Right">
</ItemStyle>

<FooterStyle HorizontalAlign="Right">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TOT_SOLES" SortExpression="TOT_SOLES" HeaderText="IMPORTE TOTAL S/.">
<ItemStyle HorizontalAlign="Right">
</ItemStyle>

<FooterStyle HorizontalAlign="Right">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CNT_RCP" SortExpression="CNT_RCP" HeaderText="CANT. RECEPC.">
<ItemStyle HorizontalAlign="Right">
</ItemStyle>

<FooterStyle HorizontalAlign="Right">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CNT_ALM" SortExpression="CNT_ALM" HeaderText="CANT.ALMAC.">
<ItemStyle HorizontalAlign="Right">
</ItemStyle>

<FooterStyle HorizontalAlign="Right">
</FooterStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table6" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD align="left"><IMG style="CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
						<INPUT style="Z-INDEX: 0; WIDTH: 15px; HEIGHT: 22px" id="hGridPagina" value="0" size="1"
							type="hidden" name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 15px; HEIGHT: 22px" id="hGridPaginaSort" size="1" type="hidden"
							name="hOrdenGrilla" runat="server">
					</TD>
				</TR>
				<tr>
					<td vAlign="top" width="592"></td>
				</tr>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
