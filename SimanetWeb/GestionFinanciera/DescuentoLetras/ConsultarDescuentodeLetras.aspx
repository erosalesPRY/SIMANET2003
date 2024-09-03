<%@ Page language="c#" Codebehind="ConsultarDescuentodeLetras.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras.ConsultarDescuentodeLetras" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
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
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Descuento de Letras</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"></TD>
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
											<TD style="WIDTH: 115px"><IMG style="WIDTH: 331px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="331"></TD>
											<TD style="WIDTH: 188px"></TD>
											<TD style="WIDTH: 187px"></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" PageSize="7" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0" ShowFooter="True" Width="765px">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Centro" SortExpression="Centro" HeaderText="CO">
												<HeaderStyle Width="2%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="EntidadFinanciera" SortExpression="EntidadFinanciera" HeaderText="ENTIDAD FINANCIERA">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroDescuento" SortExpression="NroDescuento" HeaderText="DOCUMENTO">
												<HeaderStyle Width="3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FechaDesembolso" SortExpression="FechaDesembolso" HeaderText="FD">
												<HeaderStyle HorizontalAlign="Center" Width="12%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CantidadLetras" SortExpression="CantidadLetras" HeaderText="CANT">
												<HeaderStyle Width="1%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
												<HeaderStyle Width="1%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="IMPORTE">
												<HeaderStyle Width="50%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" colSpan="5">
																<asp:Label id="Label1" runat="server" CssClass="headergrilla" DESIGNTIMEDRAGDROP="86" BorderStyle="None">IMPORTE</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="20%">
																<asp:Label id="Label2" runat="server" CssClass="headergrilla" ToolTip="Monto que el Banco Desembolsa al Solicitante"
																	DESIGNTIMEDRAGDROP="87" BorderStyle="None">DESEMBOLSO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="20%">
																<asp:Label id="Label3" runat="server" CssClass="headergrilla" ToolTip="Interés Cobrado por el Banco"
																	DESIGNTIMEDRAGDROP="88" BorderStyle="None">INTERES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="20%">
																<asp:Label id="Label4" runat="server" CssClass="headergrilla" ToolTip="Monto de la Letra o Conjunto de Letras a ser descontadas"
																	BorderStyle="None">LETRAS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="20%">
																<asp:Label id="Label5" runat="server" CssClass="headergrilla" BorderStyle="None">AMORTIZADO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="20%">
																<asp:Label id="Label6" runat="server" CssClass="headergrilla" ToolTip="Saldo del Descuento"
																	BorderStyle="None">SALDO</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="20%">
																<asp:Label id="lblMontoDesembolso" runat="server" CssClass="normaldetalle">0.0</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="right" width="20%">
																<asp:Label id="lblMontoDescuento" runat="server" CssClass="normaldetalle">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="right" width="20%">
																<asp:Label id="lblMontoLetras" runat="server" CssClass="normaldetalle">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="right" width="20%">
																<asp:Label id="lblMontoAmortizado" runat="server" CssClass="normaldetalle">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="right" width="20%">
																<asp:Label id="lblMontoSaldo" runat="server" CssClass="normaldetalle">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="768" border="0">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPaginaSort"
										runat="server"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="56"><INPUT id="hidDescuento" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hidDescuento"
										runat="server"></TD>
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
