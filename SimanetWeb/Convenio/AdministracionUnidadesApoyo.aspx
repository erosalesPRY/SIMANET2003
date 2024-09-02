<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="AdministracionUnidadesApoyo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.AdministracionUnidadesApoyo" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Producción >  Administración ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPagina">Unidades de Apoyo</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="700" border="0">
							<TR>
								<TD align="center" colSpan="4"><asp:label id="lblSubTitulo" runat="server" CssClass="TituloPrincipal"> Administración de Unidades de Apoyo</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 350px" bgColor="#f5f5f5" colSpan="2"><asp:imagebutton id="ibtnFiltrar" runat="server" CausesValidation="False" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
										src="../imagenes/filtroPorSeleccion.JPG">
									<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
										ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
								<TD align="right" bgColor="#f5f5f5" colSpan="2"><asp:imagebutton id="btnPeriodo" runat="server" ImageUrl="../imagenes/btn_Periodos.jpg"></asp:imagebutton><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD bgColor="#f5f5f5" colSpan="4"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" PageSize="7" AllowPaging="True"
										AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" ShowFooter="True" align="center"
										Width="780px">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IDUNIDADAPOYO" SortExpression="IDUNIDADAPOYO" HeaderText="IdUnidadApoyo"></asp:BoundColumn>
											<asp:BoundColumn DataField="NOMBRE" SortExpression="NOMBRE" HeaderText="NOMBRE">
												<HeaderStyle Width="50%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SIGLAS" SortExpression="SIGLAS" HeaderText="SIGLAS">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="OBSERVACIONES" SortExpression="OBSERVACIONES" HeaderText="OBSERVACIONES">
												<HeaderStyle Width="40px"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#f5f5f5" colSpan="4">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False" DESIGNTIMEDRAGDROP="55"></asp:label></TD>
							</TR>
							<TR>
								<TD bgColor="#f5f5f5" colSpan="4"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
										runat="server"><INPUT id="hCodigo" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
							</TR>
							<TR>
								<TD bgColor="#f5f5f5" colSpan="4"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
