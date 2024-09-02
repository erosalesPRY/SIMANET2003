<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="PopupImpresionInventarioImagen.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.PopupImpresionInventarioImagen" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Filtros.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="384" align="center" border="0"
				style="WIDTH: 384px; HEIGHT: 223px">
				<TR>
					<TD class="TituloPrincipal" align="center" colSpan="3">
						<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> CONSULTAR INVENTARIO</asp:label></TD>
				</TR>
				<TR>
					<TD align="left">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="648" border="0" style="WIDTH: 648px; HEIGHT: 126px">
							<TR>
								<TD>
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" ShowFooter="True" BorderStyle="Dotted"
										Width="780px" AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" PageSize="7">
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="3%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IDINVENTARIOIMAGEN" HeaderText="IDINVENTARIOIMAGEN"></asp:BoundColumn>
											<asp:BoundColumn DataField="DETALLE" SortExpression="DETALLE" HeaderText="GRUPO">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SUBGRUPO" SortExpression="SUBGRUPO" HeaderText="SUBGRUPO"></asp:BoundColumn>
											<asp:BoundColumn DataField="NOMBRE" HeaderText="NOMBRE">
												<HeaderStyle Width="27%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCION">
												<HeaderStyle Width="32%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NOMBREIDIOMA" SortExpression="NOMBREIDIOMA" HeaderText="IDIOMA"></asp:BoundColumn>
											<asp:BoundColumn DataField="UNIDADES" SortExpression="UNIDADES" HeaderText="UNIDADES"></asp:BoundColumn>
											<asp:BoundColumn DataField="Minimo" SortExpression="Minimo" HeaderText="Stock Minimo"></asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
