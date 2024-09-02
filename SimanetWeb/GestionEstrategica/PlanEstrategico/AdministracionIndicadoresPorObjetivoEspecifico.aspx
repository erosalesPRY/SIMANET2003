<%@ Page language="c#" Codebehind="AdministracionIndicadoresPorObjetivoEspecifico.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.AdministracionIndicadoresPorObjetivoEspecifico" %>
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
											<TD colSpan="6" rowSpan="1"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
													></asp:label></TD>
											<TD width="100%"></TD>
											<TD></TD>
										</TR>
										<TR bgColor="#f0f0f0">
											<TD width="100%"></TD>
											<TD><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
											<TD>
												<P id="P1" style="BACKGROUND-COLOR: #f0f0f0" align="right"><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></P>
											</TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="100%" RowPositionEnabled="False" ShowFooter="True"
										AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
										PageSize="7">
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

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
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
							runat="server"><INPUT id="hDescripcion" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hDescripcion"
							runat="server">&nbsp;<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/RetornarAlFormato.GIF">
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TABLE></form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
