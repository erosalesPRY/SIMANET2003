<%@ Page language="c#" Codebehind="AdministrarPeriodoUnidadesApoyo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.AdministrarPeriodoUnidadesApoyo" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc3" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 24px"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Producción ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> ADMINISTRAR PERIODOS CONVENIOS COMPOPERPAC</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center" width="100%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="600" border="0">
							<TR>
								<TD style="WIDTH: 83px"><IMG height="14" src="../imagenes/TitFiltros.gif" width="82"></TD>
								<TD style="WIDTH: 53px"></TD>
								<TD style="WIDTH: 6px"></TD>
								<TD></TD>
								<TD style="WIDTH: 81px"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD width="89" bgColor="#f5f5f5"><asp:label id="lblPeriodoInicial" runat="server" CssClass="normal"> INICIO:&nbsp;</asp:label></TD>
								<TD width="59" bgColor="#f5f5f5"><asp:dropdownlist id="ddlbPeriodoInicial" runat="server" CssClass="normal"></asp:dropdownlist></TD>
								<TD width="6" bgColor="#f5f5f5"><cc3:comparedomvalidator id="cbvPeriodos" runat="server" ControlToValidate="ddlbPeriodoFinal" ControlToCompare="ddlbPeriodoInicial"
										Type="Integer" Operator="GreaterThanEqual" Display="Dynamic">*</cc3:comparedomvalidator></TD>
								<TD width="62" bgColor="#f5f5f5"><asp:label id="lblPeriodoFinal" runat="server" CssClass="normal">FINAL:&nbsp;</asp:label></TD>
								<TD bgColor="#f5f5f5"><asp:dropdownlist id="ddlbPeriodoFinal" runat="server" CssClass="normal"></asp:dropdownlist></TD>
								<TD bgColor="#f5f5f5"><asp:button id="btnConsultar" runat="server" CssClass="normal" Text="Consultar"></asp:button></TD>
							</TR>
						</TABLE>
						<TABLE id="Table4" cellSpacing="1" cellPadding="0" width="780" border="0">
							<TR>
								<TD bgColor="#f5f5f5"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif" CausesValidation="False"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
										src="../imagenes/filtroPorSeleccion.JPG">
									<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
										ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
								<TD align="right" bgColor="#f5f5f5"><asp:imagebutton id="ibtnOrdenTrabajo" runat="server" ImageUrl="../imagenes/btnOT.gif"></asp:imagebutton><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
							</TR>
						</TABLE>
						<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD>
									<cc2:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" PageSize="5" AllowPaging="True"
										AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" ShowFooter="True">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IDPERIODOUNIDADESAPOYO" HeaderText="IDPERIODOUNIDADESAPOYO"></asp:BoundColumn>
											<asp:BoundColumn DataField="Periodo" SortExpression="Periodo" HeaderText="PERIODO">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="DESCRIPCION">
												<HeaderStyle Width="85%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc2:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#f5f5f5"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD bgColor="#f5f5f5"><asp:label id="lblObservaciones" runat="server" CssClass="normal">OBSERVACIONES</asp:label></TD>
											<TD style="WIDTH: 404px" align="right" bgColor="#f5f5f5"></TD>
											<TD vAlign="top" bgColor="#f5f5f5">&nbsp;</TD>
										</TR>
									</TABLE>
									<asp:textbox id="txtObservaciones" runat="server" CssClass="normal" Width="100%" ReadOnly="True"
										TextMode="MultiLine" Height="55px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 15px" type="hidden" size="1" name="hCodigo"
										runat="server"><INPUT id="hIndice" style="WIDTH: 16px; HEIGHT: 15px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
							</TR>
							<TR>
								<TD align="center"><cc3:domvalidationsummary id="DomValidationSummary1" runat="server" Width="91px" Height="26px" DisplayMode="List"
										EnableClientScript="False" ShowMessageBox="True"></cc3:domvalidationsummary></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
