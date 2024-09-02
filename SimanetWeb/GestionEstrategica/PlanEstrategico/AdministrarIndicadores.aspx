<%@ Page language="c#" Codebehind="AdministrarIndicadores.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.AdministrarIndicadores" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>AdministrarPlanEstrategicoActividad</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" bottomMargin="0"
		leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form2" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD>
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" bgColor="#f0f0f0"
										border="0">
										<TR>
										</TR>
										<TR>
											<TD bgColor="#ffffff" colSpan="9"><asp:label id="Label5" runat="server" Width="136px" ForeColor="Navy" CssClass="TituloPrincipalBlanco">ACTIVIDAD:</asp:label><asp:label id="lblActividad" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco"></asp:label>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 28px"></TD>
											<TD colSpan="4"><asp:label id="Label1" runat="server" Width="136px" ForeColor="Navy" CssClass="TituloPrincipalBlanco">INDICADORES</asp:label></TD>
											<TD width="100%"></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 28px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
											<TD style="WIDTH: 138px"><IMG id="ibtnFiltrarSeleccion" title="Descripcion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../../imagenes/filtroporseleccion.jpg"></TD>
											<TD style="WIDTH: 9px"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD style="WIDTH: 2px"></TD>
											<TD width="100%"></TD>
											<TD><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
											<TD>
												<P id="P1" style="BACKGROUND-COLOR: #f0f0f0" align="right"><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></P>
											</TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="100%" PageSize="7" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
										AllowSorting="True" AllowPaging="True" ShowFooter="True" RowPositionEnabled="False">
<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>

<AlternatingItemStyle CssClass="AlternateItemGrilla">
</AlternatingItemStyle>

<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla">
</FooterStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO" DataFormatString="{0:###,##0.00}">
<HeaderStyle Width="2%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="INDICADOR">
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="VAR1" SortExpression="VAR1" HeaderText="UNID. MED.">
<HeaderStyle Width="12%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MES1" SortExpression="MES1" HeaderText="ENE.">
<HeaderStyle Width="3%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MES2" SortExpression="MES2" HeaderText="FEB.">
<HeaderStyle Width="3%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MES3" SortExpression="MES3" HeaderText="MAR.">
<HeaderStyle Width="3%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MES4" SortExpression="MES4" HeaderText="ABR.">
<HeaderStyle Width="3%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MES5" SortExpression="MES5" HeaderText="MAY.">
<HeaderStyle Width="3%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MES6" SortExpression="MES6" HeaderText="JUN.">
<HeaderStyle Width="3%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MES7" SortExpression="MES7" HeaderText="JUL.">
<HeaderStyle Width="3%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MES8" SortExpression="MES8" HeaderText="AGO.">
<HeaderStyle Width="3%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MES9" SortExpression="MES9" HeaderText="SET.">
<HeaderStyle Width="3%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MES10" SortExpression="MES10" HeaderText="OCT.">
<HeaderStyle Width="3%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MES11" SortExpression="MES11" HeaderText="NOV.">
<HeaderStyle Width="3%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MES12" SortExpression="MES12" HeaderText="DIC.">
<HeaderStyle Width="3%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla">
</HeaderStyle>
									</cc1:datagridweb></TD>
							<TR>
								<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
				</TR>
				<TR>
					<TD align="right">&nbsp;<INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 14px" type="hidden" size="1" name="hCodigo"
							runat="server"><INPUT id="hDescripcionActividad" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
							name="hDescripcionActividad" runat="server"> <INPUT id="hCodigoActividad" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
							runat="server"> <INPUT id="hNro" style="WIDTH: 16px; HEIGHT: 14px" type="hidden" size="1" name="hCodigo"
							runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/RetornarAlFormato.GIF">
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TABLE></form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
