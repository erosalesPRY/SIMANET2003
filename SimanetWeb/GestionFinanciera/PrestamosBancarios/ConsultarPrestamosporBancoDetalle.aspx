<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarPrestamosporBancoDetalle.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PrestamosBancarios.ConsultarPrestamosporBancoDetalle" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"> </SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Detalle de Préstamos por Banco</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%">
						<TABLE id="Table1" style="HEIGHT: 26px" cellSpacing="1" cellPadding="1" width="772" align="center"
							border="0">
							<TR>
								<TD>
									<P align="left"><asp:label id="lblBanco" runat="server" CssClass="TituloPrincipal"></asp:label></P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE style="HEIGHT: 22px" cellSpacing="0" cellPadding="0" border="0" width="772">
							<TR bgColor="#f0f0f0">
								<TD style="WIDTH: 8px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
								<TD style="WIDTH: 72px">
									<P align="left"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></P>
								</TD>
								<TD style="WIDTH: 114px"><IMG id="ibtnFiltrarSeleccion" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
										alt="Aplicar Filtro por Selección" src="../../imagenes/filtroporseleccion.jpg" runat="server"></TD>
								<TD style="WIDTH: 483px">
									<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
										ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
								<TD><IMG style="WIDTH: 456px; HEIGHT: 9px" height="9" src="../imagenes/spacer.gif" width="456"></TD>
								<TD></TD>
								<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
							</TR>
						</TABLE>
						<cc1:datagridweb id="grid" runat="server" ShowFooter="True" PageSize="7" Width="773px" RowHighlightColor="#E0E0E0"
							AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:BoundColumn DataField="NROPRESTAMO" SortExpression="NROPRESTAMO" HeaderText="NRO">
									<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NombreCentro" SortExpression="NombreCentro" HeaderText="CO">
									<HeaderStyle HorizontalAlign="Center" Width="2%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="ENTIDAD FINANCIERA">
									<HeaderStyle Width="20%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NROPRESTAMO" SortExpression="NROPRESTAMO" HeaderText="NRO PRESTAMO">
									<HeaderStyle Width="5%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="FECHA">
									<HeaderStyle Width="10%"></HeaderStyle>
									<HeaderTemplate>
										<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
											<TR>
												<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" width="100%" colSpan="2">
													<asp:Label id="Label11" runat="server" CssClass="HeaderGrilla" BorderStyle="None" Height="6px">FECHA</asp:Label></TD>
											</TR>
											<TR>
												<TD align="center" width="50%">
													<asp:Label id="lblHFechaInicio" runat="server" CssClass="HeaderGrilla" BorderStyle="None" Height="2px">INICIO</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="50%">
													<asp:Label id="lblHFechaVence" runat="server" CssClass="HeaderGrilla" BorderStyle="None" Height="3px">VENCE</asp:Label></TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table9" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
											border="0">
											<TR>
												<TD vAlign="middle" align="center" width="50%">
													<asp:Label id="lblFechaInicio" runat="server" CssClass="normaldetalle" Width="57px" DESIGNTIMEDRAGDROP="340"
														BorderStyle="None">00-00-2005</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" vAlign="middle" align="center" width="50%">
													<asp:Label id="lblFechaVence" runat="server" CssClass="normaldetalle" Width="58px" BorderStyle="None"
														ForeColor="Navy">00-00-2005</asp:Label></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="NroDiasFaltantes" SortExpression="NroDiasFaltantes" HeaderText="DIAS">
									<HeaderStyle HorizontalAlign="Center" Width="2%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TasaInteres" SortExpression="TasaInteres" HeaderText="TEA">
									<HeaderStyle HorizontalAlign="Center" Width="2%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
									<HeaderStyle HorizontalAlign="Center" Width="2%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="TOTALES">
									<HeaderStyle HorizontalAlign="Center" Width="15%" VerticalAlign="Bottom"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<HeaderTemplate>
										<TABLE style="HEIGHT: 28px" id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%"
											align="left">
											<TR>
												<TD style="BORDER-BOTTOM: #cccccc 1px solid" width="100%" colSpan="3" align="center">
													<asp:Label id="Label10" runat="server" CssClass="HeaderGrilla" BorderStyle="None" Height="3px"
														Font-Bold="True">IMPORTE</asp:Label></TD>
											</TR>
											<TR>
												<TD vAlign="bottom" width="33%" align="center">
													<asp:Label id="lblMontoAutorizado" runat="server" CssClass="HeaderGrilla" Width="70px" DESIGNTIMEDRAGDROP="315"
														BorderStyle="None" Height="3px" Font-Bold="True">AUTORIZA</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" vAlign="bottom" width="33%" align="center">
													<asp:Label id="lblMontoAmortizado" runat="server" CssClass="HeaderGrilla" Width="70px" DESIGNTIMEDRAGDROP="503"
														BorderStyle="None" Height="3px" Font-Bold="True">AMORTIZA</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" vAlign="bottom" width="33%" align="center">
													<asp:Label id="lblSaldo" runat="server" CssClass="HeaderGrilla" Width="70px" DESIGNTIMEDRAGDROP="503"
														BorderStyle="None" Height="3px" Font-Bold="True">SALDO</asp:Label></TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left"
											height="100%">
											<TR>
												<TD width="33%" align="right">
													<asp:Label id="lblMontoPtmo" runat="server" CssClass="normaldetalle" Width="70px" DESIGNTIMEDRAGDROP="315"
														Height="14px">0.00</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" width="33%" align="right">
													<asp:Label id="lblMontoAmortiza" runat="server" CssClass="normaldetalle" Width="70px" DESIGNTIMEDRAGDROP="503"
														Height="6px">0.00</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" width="33%" align="right">
													<asp:Label id="lblMontoSaldo" runat="server" CssClass="normaldetalle" Width="70px" DESIGNTIMEDRAGDROP="503"
														Height="6px">0.00</asp:Label></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterTemplate>
										<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left"
											height="100%">
											<TR>
												<TD width="33%" align="right">
													<asp:Label id="Label7" runat="server" CssClass="normaldetalle" Width="68px" DESIGNTIMEDRAGDROP="315"
														Height="14px">0.00</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" width="33%" align="right">
													<asp:Label id="Label6" runat="server" CssClass="normaldetalle" Width="64px" DESIGNTIMEDRAGDROP="503"
														Height="6px">0.00</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" width="33%" align="right">
													<asp:Label id="Label5" runat="server" CssClass="normaldetalle" Width="64px" DESIGNTIMEDRAGDROP="503"
														Height="6px">0.00</asp:Label></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
								</asp:TemplateColumn>
							</Columns>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="776" border="0">
							<TR>
								<TD style="WIDTH: 506px" vAlign="middle">
									<P align="left"><asp:label id="Label3" runat="server" CssClass="TituloPrincipal">DESCRIPCIÓN:</asp:label></P>
								</TD>
								<TD>
									<P align="left"><asp:label id="Label4" runat="server" CssClass="TituloPrincipal">RESUMEN :</asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 500px" vAlign="top" align="left">
									<asp:textbox id="txtDescripcion" runat="server" Width="100%" Height="72px" TextMode="MultiLine"
										BorderStyle="Groove" CssClass="normaldetalle" ReadOnly="True"></asp:textbox></TD>
								<TD vAlign="top" align="left">
									<cc1:datagridweb id="gridResumen" runat="server" AllowSorting="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0" Width="100%" PageSize="2" Height="28px">
										<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
												<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="TOTALES">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; WIDTH: 230px; HEIGHT: 10px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"
																colSpan="3" align="center">
																<asp:Label id="Label9" runat="server" CssClass="HeaderGrilla" BorderStyle="None" Height="3px"
																	Font-Bold="True">IMPORTE</asp:Label></TD>
														</TR>
														<TR>
															<TD width="33%" align="center">
																<asp:Label id="Label8" runat="server" CssClass="HeaderGrilla" Width="70px" DESIGNTIMEDRAGDROP="315"
																	BorderStyle="None" Height="3px" Font-Bold="True">AUTORIZA</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" width="33%" align="center">
																<asp:Label id="Label1" runat="server" CssClass="HeaderGrilla" Width="70px" DESIGNTIMEDRAGDROP="503"
																	BorderStyle="None" Height="3px" Font-Bold="True">AMORTIZA</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" width="33%" align="center">
																<asp:Label id="Label2" runat="server" CssClass="HeaderGrilla" Width="70px" DESIGNTIMEDRAGDROP="503"
																	BorderStyle="None" Height="3px" Font-Bold="True">SALDO</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left"
														height="100%">
														<TR>
															<TD width="33%" align="right">
																<asp:Label id="lblMontoPtmo2" runat="server" CssClass="normaldetalle" Width="70px" DESIGNTIMEDRAGDROP="315"
																	Height="1px">PRESTAMO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" width="33%" align="right">
																<asp:Label id="lblMontoAmortiza2" runat="server" CssClass="normaldetalle" Width="70px" DESIGNTIMEDRAGDROP="503"
																	Height="1px">AMORTIZA</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" width="33%" align="right">
																<asp:Label id="lblMontoSaldo2" runat="server" CssClass="normaldetalle" Width="70px" DESIGNTIMEDRAGDROP="503"
																	Height="1px">SALDO</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 506px" vAlign="top" align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server"></TD>
								<TD vAlign="top" align="left"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
