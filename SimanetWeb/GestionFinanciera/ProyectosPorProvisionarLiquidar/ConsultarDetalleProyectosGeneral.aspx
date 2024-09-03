<%@ Page language="c#" Codebehind="ConsultarDetalleProyectosGeneral.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.ProyectosPorProvisionarLiquidar.ConsultarDetalleProyectosGeneral" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ConsultarDetalleProyectosGeneral</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="2"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="2"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands" colSpan="2"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Proyectos por Provisionar/Liquidar ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> DETALLE</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<asp:Label id="lblTitulo" runat="server" CssClass="TituloPrincipal">Proyectos por </asp:Label></TD>
				</TR>
				<TR>
					<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
							src="../../imagenes/filtroPorSeleccion.JPG">
						<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
							ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
					<TD align="right" bgColor="#f0f0f0"><IMG id="ImgImprimir" style="CURSOR: hand" onclick="oPrint = new SIMA.Utilitario.Helper.Dialogos();oPrint.VistaPrevia(this,id1,id2,id3,id4,id5);"
							alt="" src="../../imagenes/bt_imprimir.gif"></TD>
				</TR>
				<TR>
					<TD bgColor="#f0f0f0" colSpan="2">
						<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="100%" ShowFooter="True"
							RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" PageSize="7" AllowPaging="True">
<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>

<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<FooterStyle Font-Names="Nina" Font-Bold="True" HorizontalAlign="Right" ForeColor="Black" CssClass="FooterGrilla">
</FooterStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
<HeaderStyle Width="3%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="OT" SortExpression="OT" HeaderText="OT">
<HeaderStyle Font-Underline="True" Width="3%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SIT" SortExpression="SIT" HeaderText="SIT">
<HeaderStyle Font-Underline="True" Width="3%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="FECHA" SortExpression="FECHA" HeaderText="FECHA" DataFormatString="{0:dd-MM-yy}">
<HeaderStyle Width="5%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CLIENTE" SortExpression="CLIENTE" HeaderText="CLIENTE">
<HeaderStyle Font-Underline="True" Width="16%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SERVICIO" SortExpression="SERVICIO" HeaderText="SERVICIO">
<HeaderStyle Width="20%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="VALORIZACION">
<HeaderStyle Width="8%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right">
</ItemStyle>

<ItemTemplate>
<asp:Label id=lblValorizacion runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VAL</asp:Label>
</ItemTemplate>

<FooterTemplate>
<asp:Label id=lblSumValorizacion runat="server" CssClass="ItemGrillaSinColor">SUMVAL</asp:Label>
</FooterTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="COSTOS DE PRODUCCION">
<HeaderStyle Width="18%">
</HeaderStyle>

<HeaderTemplate>
										<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
											<TR>
												<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
													align="center" colSpan="3">
													<asp:Label id="lblCostosdeProduccion" runat="server" CssClass="HeaderGrilla" BorderStyle="None">COSTOS DE PRODUCCION</asp:Label></TD>
											</TR>
											<TR>
												<TD align="center" width="25%">
													<asp:Label id="Label15" runat="server" CssClass="HeaderGrilla" BorderStyle="None">DIRECTOS</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="25%">
													<asp:Label id="Label16" runat="server" CssClass="HeaderGrilla" BorderStyle="None">INDIRECTOS</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="25%">
													<asp:Label id="Label17" runat="server" CssClass="HeaderGrilla" BorderStyle="None">TOTAL</asp:Label></TD>
											</TR>
										</TABLE>
									
</HeaderTemplate>

<ItemTemplate>
										<TABLE id="Table4" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
											border="0">
											<TR>
												<TD align="right" width="33.3%">
													<asp:Label id="lblDirectos" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">DIR</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="33.3%">
													<asp:Label id="lblIndirectos" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">IND</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="33.3%">
													<asp:Label id="lblTotal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">TOTAL</asp:Label></TD>
											</TR>
										</TABLE>
									
</ItemTemplate>

<FooterTemplate>
										<TABLE id="Table8" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
											border="0">
											<TR>
												<TD align="right" width="33.3%">
													<asp:Label id="lblSumGDirectos" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">DIR</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="33.3%">
													<asp:Label id="lblSumGIndirectos" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">IND</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="33.3%">
													<asp:Label id="lblSumGTotal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">TOT</asp:Label></TD>
											</TR>
										</TABLE>
									
</FooterTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="DIFERENCIA">
<HeaderStyle Width="8%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right">
</ItemStyle>

<ItemTemplate>
<asp:Label id=lblDiferencia runat="server" CssClass="ItemGrillaSinColor">DIF</asp:Label>
</ItemTemplate>

<FooterTemplate>
<asp:Label id=lblSumDiferencia runat="server" CssClass="ItemGrillaSinColor">SUMDIF</asp:Label>
</FooterTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="FACTURADO">
<HeaderStyle Width="8%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right">
</ItemStyle>

<ItemTemplate>
										<asp:Label id="lblFacturado" runat="server" CssClass="ItemGrillaSinColor">FAC</asp:Label>
									
</ItemTemplate>

<FooterTemplate>
										<asp:Label id="lblSumFacturado" runat="server" CssClass="ItemGrillaSinColor">SUMFAC</asp:Label>
									
</FooterTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="RESULTADO">
<HeaderStyle Width="8%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right">
</ItemStyle>

<ItemTemplate>
										<asp:Label id="lblResult" runat="server" CssClass="ItemGrillaSinColor">RES</asp:Label>
									
</ItemTemplate>

<FooterTemplate>
										<asp:Label id="lblSumResult" runat="server" CssClass="ItemGrillaSinColor">SUMRES</asp:Label>
									
</FooterTemplate>
</asp:TemplateColumn>
</Columns>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<asp:label id="lblObservaciones" runat="server" CssClass="normaldetalle" Visible="False">OBSERVACIONES:</asp:label>
						<asp:textbox id="txtObservaciones" runat="server" CssClass="normalDetalle" Width="100%" Height="64px"
							TextMode="MultiLine" Visible="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="2"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
		<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<BR>
	</body>
</HTML>
