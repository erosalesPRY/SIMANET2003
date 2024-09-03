<%@ Page language="c#" Codebehind="AdministrarCronogramadePago.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PrestamosBancarios.AdministrarCronogramadePago" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
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
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="right" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera>Préstamos Cronograma de Pago></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Cronograma de Pago</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="759" align="center" border="0">
							<TR>
								<TD style="WIDTH: 55px"><asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita" Width="80px">SITUACIÓN :</asp:label></TD>
								<TD style="WIDTH: 224px"></TD>
								<TD>
									<P align="justify">&nbsp;</P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="764" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE style="HEIGHT: 25px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 12px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 78px"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../../imagenes/filtroporseleccion.jpg" runat="server"></TD>
											<TD style="WIDTH: 19px"></TD>
											<TD style="WIDTH: 31px"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD style="WIDTH: 35px">
												<asp:label id="Label5" runat="server" CssClass="normaldetalle" Width="53px" Font-Bold="True"> Buscar :</asp:label></TD>
											<TD style="WIDTH: 746px"><INPUT class="InputFind" id="txtBuscar" onkeydown="BusquedaporCampoColumna(this.value);"
													title="Buscar por la Columna Seleccionada" style="BORDER-RIGHT: #999999 1px groove; BORDER-TOP: #999999 1px groove; BORDER-LEFT: #999999 1px groove; WIDTH: 152px; BORDER-BOTTOM: #999999 1px groove"
													type="text" size="20" name="txtBuscar"></TD>
											<TD style="WIDTH: 187px"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif" CausesValidation="False"></asp:imagebutton></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="765px" ShowFooter="True" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" PageSize="7">
<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO"></asp:BoundColumn>
<asp:BoundColumn DataField="FechaVencimiento" SortExpression="FechaVencimiento" HeaderText="VENCIMIENTO">
<HeaderStyle VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="DIAS">
<HeaderTemplate>
<TABLE id=Table2 height="100%" cellSpacing=1 cellPadding=1 width="100%" align=left border=0>
<TR>
<TD style="BORDER-BOTTOM: #cccccc 1px solid" align=center colSpan=2>
<asp:Label id=Label2 runat="server" CssClass="HEADERGRILLA" DESIGNTIMEDRAGDROP="327" BorderStyle="None">DIAS</asp:Label></TD></TR>
<TR>
<TD align=center>
<asp:Label id=Label3 runat="server" CssClass="HEADERGRILLA" ToolTip="Nro de Dias de Plazo" DESIGNTIMEDRAGDROP="342" BorderStyle="None">P</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=center>
<asp:Label id=Label4 runat="server" CssClass="HEADERGRILLA" ToolTip="Nro de Dias Restantes para su vencimiento" BorderStyle="None">V</asp:Label></TD></TR></TABLE>
</HeaderTemplate>

<ItemTemplate>
<TABLE id=Table8 height="100%" cellSpacing=1 cellPadding=1 width="100%" align=left border=0>
<TR>
<TD align=center>
<asp:Label id=lblDiasPlazo runat="server" CssClass="normaldetalle" Width="30px" BorderStyle="None">00</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=center>
<asp:Label id=lblDiasFaltantes runat="server" CssClass="normaldetalle" Width="30px" DESIGNTIMEDRAGDROP="527" BorderStyle="None">00</asp:Label></TD></TR></TABLE>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn HeaderText="NRO&lt;BR&gt;AMORT."></asp:BoundColumn>
<asp:TemplateColumn HeaderText="FECHA">
<HeaderTemplate>
<TABLE id=Table9 height="100%" cellSpacing=1 cellPadding=1 width="100%" align=left border=0>
<TR>
<TD style="BORDER-BOTTOM: #cccccc 1px solid" align=center colSpan=4>
<asp:Label id=Label6 runat="server" CssClass="HEADERGRILLA" BorderStyle="None">IMPORTE</asp:Label></TD></TR>
<TR>
<TD align=center width="33%">
<asp:Label id=Label7 runat="server" CssClass="HEADERGRILLA" BorderStyle="None">AMORTIZADO</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=center width="33%">
<asp:Label id=Label11 runat="server" CssClass="HEADERGRILLA" BorderStyle="None">SALDO</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=center width="33%">
<asp:Label id=Label12 runat="server" CssClass="HEADERGRILLA" BorderStyle="None">INTERES</asp:Label></TD></TR></TABLE>
</HeaderTemplate>

<ItemTemplate>
<TABLE id=Table11 height="100%" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD align=right width="33%">
<asp:Label id=lblAmortizado runat="server" CssClass="normaldetalle" Width="54px" BorderStyle="None">0.00</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=right width="33%">
<asp:Label id=lblSaldo runat="server" CssClass="normaldetalle" Width="54px" BorderStyle="None">0.00</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=right width="33%">
<asp:Label id=lblInteres runat="server" CssClass="normaldetalle" Width="54px" DESIGNTIMEDRAGDROP="475" BorderStyle="None">0.00</asp:Label></TD></TR></TABLE>
</ItemTemplate>
</asp:TemplateColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="768" border="0">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPaginaSort"
										runat="server"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
