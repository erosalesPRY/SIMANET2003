<%@ Page language="c#" Codebehind="ConsultarLetrasporTipoySituacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras.ConsultarLetrasporTipoySituacion" %>
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
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="right" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Letras</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="759" align="center" border="0">
							<TR>
								<TD style="WIDTH: 167px">
									<asp:label id="Label5" runat="server" CssClass="TextoNegroNegrita" Width="160px">CENTRO DE OPERACIONES :</asp:label></TD>
								<TD style="WIDTH: 432px">
									<asp:label id="lblCentro" runat="server" CssClass="TextoNegroNegrita" Width="320px"></asp:label></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 167px">
									<asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita" DESIGNTIMEDRAGDROP="96"
										Width="70px">SITUACIÓN :</asp:label></TD>
								<TD style="WIDTH: 432px">
									<asp:label id="lblSituacion" runat="server" CssClass="TextoNegroNegrita" Width="248px"></asp:label></TD>
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
											<TD style="WIDTH: 78px"><asp:imagebutton id="ibtnFiltar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
											<TD style="WIDTH: 19px"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../../imagenes/filtroporseleccion.jpg" runat="server"></TD>
											<TD style="WIDTH: 31px"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD style="WIDTH: 115px"><IMG style="WIDTH: 444px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="444"></TD>
											<TD style="WIDTH: 188px"></TD>
											<TD style="WIDTH: 187px"></TD>
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
<asp:BoundColumn DataField="NroDocumento" SortExpression="NroDocumento" HeaderText="DOCUMENTO">
<HeaderStyle VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="AbreviaturaCentroOperativo" SortExpression="AbreviaturaCentroOperativo" HeaderText="CO">
<HeaderStyle VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NombreProyecto" SortExpression="NombreProyecto" HeaderText="PROYECTO">
<HeaderStyle VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="RAZON SOCIAL">
<HeaderStyle VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="FECHA">
<HeaderTemplate>
													<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" colSpan="3">
																<asp:Label id="Label10" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">FECHA</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="33%">
																<asp:Label id="Label9" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">INICIO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="33%">
																<asp:Label id="Label8" runat="server" CssClass="HEADERGRILLA" DESIGNTIMEDRAGDROP="181" BorderStyle="None">VENCE</asp:Label></TD>
														</TR>
													</TABLE>
												
</HeaderTemplate>

<ItemTemplate>
													<TABLE id="Table7" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
														</TR>
														<TR>
															<TD align="center">
																<asp:Label id="lblFechaInicio" runat="server" CssClass="normaldetalle" Width="54px" DESIGNTIMEDRAGDROP="475" BorderStyle="None">00-00-2005</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center">
																<asp:Label id="lblFechaVence" runat="server" CssClass="normaldetalle" Width="54px" BorderStyle="None">00-00-2005</asp:Label></TD>
														</TR>
													</TABLE>
												
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="DIAS">
<HeaderTemplate>
													<TABLE id="Table2" height="100%" cellSpacing="1" cellPadding="1" width="100%" align="left"
														border="0">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" colSpan="2">
																<asp:Label id="Label2" runat="server" CssClass="HEADERGRILLA" DESIGNTIMEDRAGDROP="327" BorderStyle="None">DIAS</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center">
																<asp:Label id="Label3" runat="server" CssClass="HEADERGRILLA" ToolTip="Nro de Dias de Plazo" DESIGNTIMEDRAGDROP="342" BorderStyle="None">P</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center">
																<asp:Label id="Label4" runat="server" CssClass="HEADERGRILLA" ToolTip="Nro de Dias Restantes para su vencimiento" BorderStyle="None">V</asp:Label></TD>
														</TR>
													</TABLE>
												
</HeaderTemplate>

<ItemTemplate>
													<TABLE id="Table8" height="100%" cellSpacing="1" cellPadding="1" width="100%" align="left"
														border="0">
														<TR>
															<TD align="center">
																<asp:Label id="lblDiasPlazo" runat="server" CssClass="normaldetalle" Width="30px" BorderStyle="None">00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center">
																<asp:Label id="lblDiasFaltantes" runat="server" CssClass="normaldetalle" Width="30px" DESIGNTIMEDRAGDROP="527" BorderStyle="None">00</asp:Label></TD>
														</TR>
													</TABLE>
												
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
<HeaderStyle VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Monto" SortExpression="Monto" HeaderText="MONTO">
<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3">
									<asp:Label id="Label8" runat="server" CssClass="TituloPrincipal">DESCRIPCIÓN</asp:Label></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<asp:TextBox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="Groove"
										TextMode="MultiLine"></asp:TextBox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="768" border="0">
							<TR>
								<TD align="left"><IMG id=ibtnAtras 
            style="CURSOR: hand" onclick=HistorialIrAtras(); alt="" 
            src="../../imagenes/atras.gif"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPaginaSort"
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
