<%@ Page language="c#" Codebehind="ConsultarProyectosPorCentroLinea.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Proyectos.ConsultarProyectosPorCentroLinea" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td bgColor="#eff7fa" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label style="Z-INDEX: 0" id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Proyectos ></asp:label><asp:label style="Z-INDEX: 0" id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Proyectos Por LN / Centro Operativo</asp:label></TD>
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
																alt="Aplicar Filtro por Selección" src="../../imagenes/filtroporseleccion.jpg" runat="server">
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
									<cc1:datagridweb id="grid" runat="server" PageSize="7" ShowFooter="True" Width="100%" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>

<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<FooterStyle Font-Size="X-Small" Font-Bold="True" CssClass="FooterGrilla">
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
<asp:BoundColumn DataField="CENTRO_OPERATIVO" SortExpression="CENTRO_OPERATIVO" HeaderText="CO.">
<HeaderStyle Width="1%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="LIN_NEG" SortExpression="LIN_NEG" HeaderText="LN.">
<HeaderStyle Width="1%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="proyecto" SortExpression="proyecto" HeaderText="PROYECTO">
<HeaderStyle Width="25%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cliente" SortExpression="cliente" HeaderText="CLIENTE">
<HeaderStyle Width="15%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="PROGRAMADO">
<HeaderStyle Width="15%" VerticalAlign="Bottom">
</HeaderStyle>

<HeaderTemplate>
													<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"
																vAlign="top" width="100%" colSpan="3" align="center">
																<asp:Label style="Z-INDEX: 0" id="Label27" runat="server" CssClass="HeaderGrilla" Width="100%" Font-Bold="True" BorderStyle="None">PROGRAMADO</asp:Label></TD>
														</TR>
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"
																width="33%" align="center">
																<asp:Label style="Z-INDEX: 0" id="Label26" runat="server" CssClass="HeaderGrilla" Width="100%" Font-Bold="True" BorderStyle="None" Height="3px">MATERIALES</asp:Label></TD>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																width="34%" align="center">
																<asp:Label style="Z-INDEX: 0" id="Label23" runat="server" CssClass="HeaderGrilla" Width="100%" Font-Bold="True" BorderStyle="None" Height="3px">MANO DE OBRA</asp:Label></TD>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																width="33%" align="center">
																<asp:Label style="Z-INDEX: 0" id="Label22" runat="server" CssClass="HeaderGrilla" Width="100%" Font-Bold="True" BorderStyle="None" Height="3px">SERVICIOS</asp:Label></TD>
														</TR>
													</TABLE>
												
</HeaderTemplate>

<ItemTemplate>
													<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left"
														height="100%">
														<TR>
															<TD width="33%" align="right">
																<asp:Label id="lblPRO_MAT" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315" Width="99%" BorderStyle="None" Height="3px">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="34%" align="right">
																<asp:Label id="lblPRO_MOB" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503" Width="99%" BorderStyle="None" Height="3px">AL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="33%" align="right">
																<asp:Label id="lblPRO_SRV" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503" Width="99%" BorderStyle="None" Height="3px">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												
</ItemTemplate>

<FooterTemplate>
													<TABLE style="Z-INDEX: 0" id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%"
														align="left" height="100%">
														<TR>
															<TD width="33%" align="right">
																<asp:Label id="lblTPRO_MAT" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315" Width="99%" BorderStyle="None" Height="3px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="34%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblTPRO_MOB" runat="server" CssClass="footerGrilla" Width="99%" BorderStyle="None" Height="3px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="33%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblTPRO_SRV" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315" Width="99%" BorderStyle="None" Height="3px">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												
</FooterTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="EJECUTADO">
<HeaderStyle Width="30%">
</HeaderStyle>

<HeaderTemplate>
<TABLE id=Table3 border=0 cellSpacing=0 cellPadding=0 width="100%">
<TR>
<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px" colSpan=6 align=center>
<asp:Label style="Z-INDEX: 0" id=Label20 runat="server" CssClass="HeaderGrilla" Font-Bold="True" Width="100%" Height="3px" BorderStyle="None">EJECUTADO</asp:Label></TD></TR>
<TR>
<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT: #cccccc 1px solid" rowSpan=2 width="50%" colSpan=3 align=center>
<asp:Label style="Z-INDEX: 0" id=Label19 runat="server" CssClass="HeaderGrilla" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">DIRECTO</asp:Label></TD></TR>
<TR>
<TD style="BORDER-BOTTOM: 1px solid; BORDER-LEFT-WIDTH: 1px" width="50%" colSpan=4 align=center>
<asp:Label style="Z-INDEX: 0" id=Label18 runat="server" CssClass="HeaderGrilla" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">INDIRECTO</asp:Label></TD></TR>
<TR>
<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 2px; BORDER-RIGHT: #cccccc 1px solid" align=center>
<asp:Label style="Z-INDEX: 0" id=Label17 runat="server" CssClass="HeaderGrilla" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">MATERIALES</asp:Label></TD>
<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT: #cccccc 1px solid" align=center>
<asp:Label style="Z-INDEX: 0" id=Label16 runat="server" CssClass="HeaderGrilla" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">MANO DE OBRA</asp:Label></TD>
<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT: #cccccc 1px solid" align=center>
<asp:Label style="Z-INDEX: 0" id=labelll runat="server" CssClass="HeaderGrilla" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">SERVICIOS</asp:Label></TD>
<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT: #cccccc 1px solid" align=center>
<asp:Label style="Z-INDEX: 0" id=Label5 runat="server" CssClass="HeaderGrilla" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">MATERIALES</asp:Label></TD>
<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT: #cccccc 1px solid" align=center>
<asp:Label style="Z-INDEX: 0" id=Label4 runat="server" CssClass="HeaderGrilla" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">MANO DE OBRA</asp:Label></TD>
<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px" align=center>
<asp:Label style="Z-INDEX: 0" id=Label2 runat="server" CssClass="HeaderGrilla" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">SERVICIOS</asp:Label></TD></TR></TABLE>
</HeaderTemplate>

<ItemTemplate>
<TABLE style="Z-INDEX: 0" id=Table7 border=0 cellSpacing=0 cellPadding=0 width="100%">
<TR>
<TD width="15%" align=right>
<asp:Label style="Z-INDEX: 0" id=lblDIR_MAT runat="server" CssClass="normaldetalle" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">MATERIALES</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" width="20%" align=right>
<asp:Label style="Z-INDEX: 0" id=lblDIR_MOB runat="server" CssClass="normaldetalle" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">MANO DE OBRA</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" width="15%" align=right>
<asp:Label style="Z-INDEX: 0" id=lblDIR_SRV runat="server" CssClass="normaldetalle" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">SERVICIOS</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" width="15%" align=right>
<asp:Label style="Z-INDEX: 0" id=lblIND_MAT runat="server" CssClass="normaldetalle" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">MATERIALES</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" width="20%" align=right>
<asp:Label style="Z-INDEX: 0" id=lblIND_MOB runat="server" CssClass="normaldetalle" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">MANO DE OBRA</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" width="15%" align=right>
<asp:Label style="Z-INDEX: 0" id=lblIND_SRV runat="server" CssClass="normaldetalle" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">SERVICIOS</asp:Label></TD></TR></TABLE>
</ItemTemplate>

<FooterTemplate>
<TABLE style="Z-INDEX: 0" id=Table8 border=0 cellSpacing=0 cellPadding=0 width="100%">
<TR>
<TD style="BORDER-BOTTOM-COLOR: #cccccc; BORDER-RIGHT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 2px" width="15%" align=right>
<asp:Label style="Z-INDEX: 0" id=lblTDIR_MAT runat="server" CssClass="footerGrilla" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">0.00</asp:Label></TD>
<TD style="BORDER-BOTTOM-COLOR: #cccccc; BORDER-LEFT: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc" width="20%" align=right>
<asp:Label style="Z-INDEX: 0" id=lblTDIR_MOB runat="server" CssClass="footerGrilla" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">0.00</asp:Label></TD>
<TD style="BORDER-BOTTOM-COLOR: #cccccc; BORDER-LEFT: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc" width="15%" align=right>
<asp:Label style="Z-INDEX: 0" id=lblTDIR_SRV runat="server" CssClass="footerGrilla" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">0.00</asp:Label></TD>
<TD style="BORDER-BOTTOM-COLOR: #cccccc; BORDER-LEFT: #cccccc 1px solid; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT: #cccccc 1px solid" width="15%" align=right>
<asp:Label style="Z-INDEX: 0" id=lblTIND_MAT runat="server" CssClass="footerGrilla" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">0.00</asp:Label></TD>
<TD style="BORDER-LEFT: 1px solid" width="20%" align=right>
<asp:Label style="Z-INDEX: 0" id=lblTIND_MOB runat="server" CssClass="footerGrilla" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">0.00</asp:Label></TD>
<TD style="BORDER-BOTTOM-COLOR: #cccccc; BORDER-LEFT: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc" width="15%" align=right>
<asp:Label style="Z-INDEX: 0" id=lblTIND_SRV runat="server" CssClass="footerGrilla" Font-Bold="True" Width="99%" Height="3px" BorderStyle="None">0.00</asp:Label></TD></TR></TABLE>
</FooterTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="TOTALES">
<HeaderStyle Width="15%">
</HeaderStyle>

<HeaderTemplate>
													<TABLE style="Z-INDEX: 0" id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"
																vAlign="top" width="100%" colSpan="3" align="center">
																<asp:Label style="Z-INDEX: 0" id="Label99" runat="server" CssClass="HeaderGrilla" Width="100%" Font-Bold="True" BorderStyle="None">TOTAL</asp:Label></TD>
														</TR>
														<TR>
															<TD style="BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"
																width="33%" align="center">
																<asp:Label style="Z-INDEX: 0" id="Labe96" runat="server" CssClass="HeaderGrilla" Width="100%" Font-Bold="True" BorderStyle="None" Height="3px">PROGRAMADO</asp:Label></TD>
															<TD style="BORDER-BOTTOM-COLOR: #cccccc; BORDER-LEFT: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																width="34%" align="center">
																<asp:Label style="Z-INDEX: 0" id="Label97" runat="server" CssClass="HeaderGrilla" Width="100%" Font-Bold="True" BorderStyle="None" Height="3px">EJECUTADO</asp:Label></TD>
															<TD style="BORDER-BOTTOM-COLOR: #cccccc; BORDER-LEFT: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																width="33%" align="center">
																<asp:Label style="Z-INDEX: 0" id="Label98" runat="server" CssClass="HeaderGrilla" Width="100%" Font-Bold="True" BorderStyle="None" Height="3px">DIFERENCIA</asp:Label></TD>
														</TR>
													</TABLE>
												
</HeaderTemplate>

<ItemTemplate>
													<TABLE style="Z-INDEX: 0" id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%"
														align="left" height="100%">
														<TR>
															<TD width="33%" align="right">
																<asp:Label id="lblTOT_PRO" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315" Width="100%" BorderStyle="None" Height="3px">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="34%" align="right">
																<asp:Label id="lblTOT_EJE" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503" Width="100%" BorderStyle="None" Height="3px">AL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="33%" align="right">
																<asp:Label id="lblTOT_DIF" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503" Width="100%" BorderStyle="None" Height="3px">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												
</ItemTemplate>

<FooterTemplate>
													<TABLE style="Z-INDEX: 0" id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%"
														align="left" height="100%">
														<TR>
															<TD width="33%" align="right">
																<asp:Label id="lblTTOT_PRO" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315" Width="100%" BorderStyle="None" Height="3px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="34%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblTTOT_EJE" runat="server" CssClass="footerGrilla" Width="100%" BorderStyle="None" Height="3px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="33%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblTTOT_DIF" runat="server" CssClass="footerGrilla" DESIGNTIMEDRAGDROP="315" Width="100%" BorderStyle="None" Height="3px">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												
</FooterTemplate>
</asp:TemplateColumn>
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
