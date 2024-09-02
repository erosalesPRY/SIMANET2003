<%@ Page language="c#" Codebehind="ConsultarTipodeCambio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.InformacionFinanciera.ConsultarTipodeCambio" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML xmlns:mbrsc>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="1" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" style="HEIGHT: 14px" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera> Información Financiera ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Tipo de Cambio</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 14px" vAlign="top" width="100%"><IMG style="WIDTH: 160px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="160"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="743" border="0" style="WIDTH: 743px; HEIGHT: 282px">
							<TR>
								<TD vAlign="top" class="headerGRILLA" align="center" width="100%" colSpan="2">
									<asp:Label id="lblTituloTC" runat="server" Font-Size="Small" Font-Bold="True" Width="641px">Tipo de Cambio a la Fecha :</asp:Label>
									<asp:Button id="btnImportarTipoCambio" runat="server" Text="Actualizar"></asp:Button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 337px" vAlign="top" align="center">
									<asp:Calendar id="CalFecha" runat="server" Width="280px" Height="232px" NextMonthText='<IMG alt="Siguenite Mes.." src="../imagenes/AgregarB.GIF">'
										PrevMonthText='<IMG alt="Siguenite Mes.." src="../imagenes/QuitarB.gif">' CssClass="Combos"
										BorderStyle="Outset">
										<DayHeaderStyle Font-Underline="True" Font-Bold="True" CssClass="FScalendarTitles" BackColor="#DFE3EA"></DayHeaderStyle>
										<SelectedDayStyle BorderWidth="2px" ForeColor="Blue" BorderStyle="Dashed" BorderColor="Blue" BackColor="#FFFFC0"></SelectedDayStyle>
										<TitleStyle Font-Bold="True"></TitleStyle>
									</asp:Calendar></TD>
								<TD style="WIDTH: 404px" vAlign="top">
									<cc1:datagridweb id="grid" runat="server" Width="392px" PageSize="7" AllowSorting="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="MONEDA">
												<HeaderStyle Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="TipoCambioCompra" SortExpression="TipoCambioCompra" HeaderText="COMPRA">
												<HeaderStyle Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="TipoCambioVenta" SortExpression="TipoCambioVenta" HeaderText="VENTA">
												<HeaderStyle Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="TipoCambioPromedio" SortExpression="TipoCambioPromedio" HeaderText="PROMEDIO">
												<HeaderStyle Width="6%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Descripcion" SortExpression="Descripcion" HeaderText="Descripcion"></asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="746" border="0" style="WIDTH: 746px; HEIGHT: 23px">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif">
									<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="AdministrarAgenda.aspx" Visible="False">HyperLink</asp:HyperLink></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="592"><IMG height="5" src="../imagenes/spacer.gif" width="592"></TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
