<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministrarOrdendeCompra.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.OrdendeCompra.AdministrarOrdendeCompra" %>
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" bottomMargin="0"
		leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 22px" vAlign="top" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px" vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" style="HEIGHT: 22px" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Orden de Compra</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE cellSpacing="0" cellPadding="0" width="751" border="0">
							<TR bgColor="#f0f0f0">
								<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
								<TD></TD>
								<TD style="WIDTH: 138px"><IMG id="ibtnFiltrarSeleccion" title="OrdenCompra" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
										src="../../imagenes/filtroporseleccion.jpg"></TD>
								<TD style="WIDTH: 9px"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ToolTip="Eliminar Filtro.." ImageUrl="../../imagenes/filtroEliminar.GIF"></asp:imagebutton></TD>
								<TD style="WIDTH: 2px"><asp:label id="Label3" runat="server" CssClass="normaldetalle" Font-Bold="True" Width="53px"> Buscar :</asp:label></TD>
								<TD style="WIDTH: 107px" width="107"><INPUT class="InputFind" id="txtBuscar" onkeydown="BusquedaporCampoColumna(this.value);"
										title="Buscar por la Columna Seleccionada" style="BORDER-BOTTOM: #999999 1px groove; BORDER-LEFT: #999999 1px groove; WIDTH: 152px; BORDER-TOP: #999999 1px groove; BORDER-RIGHT: #999999 1px groove"
										name="txtBuscar"></TD>
								<TD style="WIDTH: 96px"><asp:imagebutton id="imgbtnImportarP" runat="server" ImageUrl="../../imagenes/btnImportaciones/btnImportarProveedores.gif"></asp:imagebutton></TD>
								<TD style="WIDTH: 267px"><asp:imagebutton id="imgbtnImportar" runat="server" ImageUrl="../../imagenes/btnImportaciones/btnImportarOrdendeCompra.gif"></asp:imagebutton></TD>
								<TD style="WIDTH: 106px"></TD>
								<TD><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif" CausesValidation="False"></asp:imagebutton></TD>
								<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
							</TR>
						</TABLE>
						<cc1:datagridweb id="grid" runat="server" Width="752px" ShowFooter="True" RowHighlightColor="#E0E0E0"
							AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn HeaderText="NRO">
									<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OrdenCompra" SortExpression="OrdenCompra" HeaderText="NRO OC">
									<HeaderStyle Width="2%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NProveedor" SortExpression="NProveedor" HeaderText="PROVEEDOR">
									<HeaderStyle Width="30%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="DESCRIPCION">
									<HeaderStyle Width="40%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
									<HeaderStyle Width="1%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MontoOC" SortExpression="MontoOC" HeaderText="VALOR">
									<HeaderStyle Width="2%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">&nbsp;<INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
							runat="server" DESIGNTIMEDRAGDROP="410"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
							name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" style="WIDTH: 761px; HEIGHT: 27px" cellSpacing="1" cellPadding="1" width="761"
							border="0">
							<TR>
								<TD><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
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
