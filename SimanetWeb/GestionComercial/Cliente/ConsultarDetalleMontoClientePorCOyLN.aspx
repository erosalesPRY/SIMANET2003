<%@ Page language="c#" Codebehind="ConsultarDetalleMontoClientePorCOyLN.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Cliente.ConsultarDetalleMontoClientePorCOyLN" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarDetalleMontoClientePorCOyLN</title>
		<meta content="False" name="vs_snapToGrid">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="HEIGHT: 438px" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" colSpan="3">&nbsp;
						<asp:label id="lblRuta_Pagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Comercial > Clientes > </asp:label><asp:label id="lblPage" runat="server"> Consulta Detalle de Ventas Por Cliente Por Astillero y Linea de Negocio</asp:label></TD>
				</TR>
				<TR>
					<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal">DETALLE DE VENTAS POR CLIENTE POR CENTRO DE OPERACION Y LINEA DE NEGOCIO</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px" align="center"><asp:label id="lblNombreRazonSocial" runat="server" CssClass="TituloSecundario"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="550" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<P style="BACKGROUND-COLOR: #f0f0f0" align="right"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></P>
								</TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<P align="left"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" ShowFooter="True" Width="650px"
											PageSize="5" RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False"
											AllowSorting="True">
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla"></FooterStyle>
											<Columns>
												<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL">
													<HeaderStyle HorizontalAlign="Right" Width="3%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<FooterStyle HorizontalAlign="Center"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="DESCRIPCION DEL TRABAJO">
													<HeaderStyle Width="50%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Fecha" SortExpression="Fecha" HeaderText="FECHA">
													<HeaderStyle Width="12%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Monto" SortExpression="Monto" HeaderText="MONTO">
													<HeaderStyle Width="20%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="%Rentabilidad" SortExpression="% Rentabilidad" HeaderText="% RENTABILIDAD">
													<HeaderStyle Width="15%"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></P>
								</TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3"></TD>
							</TR>
						</TABLE>
						<INPUT id="hGridPagina" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="1" value="0"
							name="hGridPagina" runat="server"><INPUT id="hGridPaginaSort" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
							runat="server"></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="normal" id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD align="center">&nbsp;</TD>
								<TD align="center">&nbsp;</TD>
								<TD align="center">&nbsp;</TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<DIV style="OVERFLOW: auto; WIDTH: 650px; HEIGHT: 99px" align="center"><cc1:datagridweb id="dgConsulta" runat="server" CssClass="HeaderGrilla" ShowFooter="True" RowPositionEnabled="False"
											RowHighlightColor="#E0E0E0" DESIGNTIMEDRAGDROP="68">
											<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla"></FooterStyle>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></DIV>
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 11px" align="center" width="100%" colSpan="3">
									<asp:imagebutton id="ibtnLineaNegocio" runat="server" ImageUrl="../../imagenes/btnLineaNegocio.gif"></asp:imagebutton>&nbsp;
									<IMG id="Img1" height="8" src="../../imagenes/spacer.gif" width="60"><IMG height="8" src="../../imagenes/spacer.gif" width="50">
									<asp:imagebutton id="ibtnAstillero" runat="server" ImageUrl="../../imagenes/btnAstillero.jpg"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 13px" align="center" width="100%" colSpan="3">&nbsp;
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" colSpan="3"><IMG id="Img2" height="8" src="../../imagenes/spacer.gif" width="60"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
						<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160">
					</TD>
				</TR>
				<TR>
					<TD align="center"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
