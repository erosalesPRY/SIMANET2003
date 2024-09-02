<%@ Page language="c#" Codebehind="AdministrarPeriodoUnidadesApoyoFasub.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.AdministrarPeriodoUnidadesApoyoFasub" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc3" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarPeriodoUnidadesApoyoFasub</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" onkeydown="return verificarBackspace()" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header2" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands" colSpan="3"><asp:label id="Label1" runat="server" CssClass="RutaPagina">Inicio > Producción> Administración > Unidades de Apoyo ></asp:label><asp:label id="Label2" runat="server" CssClass="RutaPaginaActual"> Periodos</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="700" border="0">
							<TR>
								<TD align="center" colSpan="4"><asp:label id="lblSubTitulo" runat="server" CssClass="TituloPrincipal"> Administración de Periodos</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 350px" bgColor="#f5f5f5" colSpan="2"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="..\imagenes\filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
										src="../imagenes/filtroPorSeleccion.JPG">
									<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
										ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
								<TD align="right" bgColor="#f5f5f5" colSpan="2"><asp:imagebutton id="ibtnProyectos" runat="server" ImageUrl="../imagenes/bt_proyectos.gif"></asp:imagebutton><asp:imagebutton id="btnAgregarPeriodo" runat="server" ImageUrl="../imagenes/btn_AgregarPeriodos.jpg"></asp:imagebutton><asp:imagebutton id="btnAnularPeriodo" runat="server" ImageUrl="../imagenes/btn_AnularPeriodos.jpg"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD bgColor="#f5f5f5" colSpan="4"><cc2:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" ShowFooter="True" Width="788px"
										PageSize="5" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IDPERIODOAPOYOFASUB" SortExpression="IDPERIODOAPOYOFASUB"
												HeaderText="IDPERIODOAPOYOFASUB"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IDUNIDADAPOYO" SortExpression="IDUNIDADAPOYO" HeaderText="IDUNIDADAPOYO"></asp:BoundColumn>
											<asp:BoundColumn DataField="PERIODO" SortExpression="PERIODO" HeaderText="PERIODO">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCION">
												<HeaderStyle Width="75%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc2:datagridweb></TD>
							<TR>
								<TD style="HEIGHT: 12px" align="center" bgColor="#f5f5f5" colSpan="4"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD bgColor="#f5f5f5" colSpan="4">
									<TABLE id="Table4" style="WIDTH: 787px; HEIGHT: 17px" cellSpacing="1" cellPadding="1" width="787"
										border="0">
										<TR>
											<TD style="WIDTH: 451px"><asp:label id="lblObservaciones" runat="server" CssClass="normal">OBSERVACIONES</asp:label></TD>
											<TD align="right"></TD>
										</TR>
									</TABLE>
									<asp:textbox id="txtObservaciones" runat="server" CssClass="normal" Width="787px" ReadOnly="True"
										TextMode="MultiLine" Height="55px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD bgColor="#f5f5f5" colSpan="4"><INPUT id="hIdPeriodoApoyoFasub" style="WIDTH: 16px; HEIGHT: 15px" type="hidden" size="1"
										value="0" name="hIdPeriodoApoyoFasub" runat="server"><INPUT id="hPeriodo" style="WIDTH: 16px; HEIGHT: 15px" type="hidden" size="1" name="hPeriodo"
										runat="server"><INPUT id="hIdUnidadApoyo" style="WIDTH: 16px; HEIGHT: 15px" type="hidden" size="1" value="0"
										name="hPeriodo" runat="server"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 15px" type="hidden" size="1" value="0"
										name="hCodigo" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 16px; HEIGHT: 15px" type="hidden" size="1" name="hOrdenGrilla"
										runat="server"></TD>
							</TR>
							<TR>
								<TD bgColor="#f5f5f5" colSpan="4"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
