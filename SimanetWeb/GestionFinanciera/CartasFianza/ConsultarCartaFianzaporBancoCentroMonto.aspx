<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarCartaFianzaporBancoCentroMonto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasFianza.ConsultarCartaFianzaporBancoCentroMonto" %>
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
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Detalle de Carta Fianza por Banco</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%">
						<DIV align="center">
							<TABLE class="tabla" id="TblTabs" cellSpacing="0" cellPadding="0" width="100%" align="center"
								bgColor="#f5f5f5" border="0" runat="server">
								<TR>
									<TD style="WIDTH: 37px; HEIGHT: 16px">
										<asp:label id="Label2" runat="server" CssClass="TituloPrincipal">FIANZA   :</asp:label></TD>
									<TD vAlign="baseline">
										<asp:label id="lblSituacion" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
									<TD style="WIDTH: 60px" vAlign="baseline">
										<asp:label id="Label1" runat="server" CssClass="TituloPrincipal">BANCO   :</asp:label></TD>
									<TD vAlign="baseline">
										<asp:label id="lblEntidad" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
									<td>
										<asp:label id="Label7" runat="server" CssClass="TituloPrincipal">CENTRO   :</asp:label>
										<asp:label id="lblCO" runat="server" CssClass="TituloPrincipal"></asp:label></td>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD>
												<asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../../imagenes/filtroporseleccion.jpg" runat="server" style="Z-INDEX: 0">
												<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.." style="Z-INDEX: 0"></asp:imagebutton></TD>
											<TD style="WIDTH: 1px"></TD>
											<TD></TD>
											<TD align="left"></TD>
											<TD></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" ShowFooter="True" AllowPaging="True" AllowSorting="True"
										AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" Width="100%" PageSize="7" DESIGNTIMEDRAGDROP="59">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle HorizontalAlign="Center" Width="2%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreCentro" SortExpression="NombreCentro" HeaderText="CO">
												<HeaderStyle HorizontalAlign="Center" Width="3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="ENTIDAD FINANCIERA">
												<HeaderStyle Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Beneficiario" SortExpression="Beneficiario" HeaderText="BENEFICIARIO">
												<HeaderStyle HorizontalAlign="Center" Width="30%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="nrocartafianza" SortExpression="nrocartafianza" HeaderText="N.F">
												<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="FECHAS">
												<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-RIGHT: #cccccc 1px solid; DISPLAY: none" align="center" width="10%"
																rowSpan="2">
																<asp:Label id="Label4" runat="server" ToolTip="Numero de la Última Renovación" Width="28px"
																	Font-Bold="True">NRO<BR>U.R</asp:Label></TD>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" width="80%" colSpan="3">
																<asp:Label id="lblFechas" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None"
																	Font-Bold="True">FECHA</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="51" height="3">
																<asp:Label id="Label8" runat="server" CssClass="HeaderGrilla" ToolTip="Fecha de Apertura" DESIGNTIMEDRAGDROP="175"
																	Width="51px" BorderStyle="None" Font-Bold="True">INICIO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="51" height="3">
																<asp:Label id="Label3" runat="server" CssClass="HeaderGrilla" ToolTip="Fecha de Renovación"
																	Width="50px" BorderStyle="None" Font-Bold="True">RENOVA.</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="51" height="3">
																<asp:Label id="Label5" tabIndex="3" runat="server" CssClass="HeaderGrilla" ToolTip="Fecha de vencimiento"
																	Width="50px" BorderStyle="None" Font-Bold="True">VENCE</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD style="DISPLAY: none" vAlign="bottom" align="center" width="14%">
																<asp:Label id="lblNroRenov" runat="server" CssClass="ItemGrillaSinColor" DESIGNTIMEDRAGDROP="228"
																	Width="31px" Height="18px">0</asp:Label></TD>
															<TD vAlign="middle" align="center" width="51">
																<asp:Label id="lblFechaIni" runat="server" CssClass="normaldetalle" Width="58px" Height="12px">Label</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" vAlign="middle" align="center" width="51">
																<asp:Label id="lblFechaRenov" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="386"
																	Width="58px" Height="12px">Label</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" vAlign="middle" align="center" width="51">
																<asp:Label id="lblFechaVence" runat="server" CssClass="normaldetalle" Width="58px" Height="12px">Label</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="NroDiasFaltantes" SortExpression="NroDiasFaltantes" HeaderText="DIAS">
												<HeaderStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
												<HeaderStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoFza" SortExpression="MontoFza" HeaderText="MONTO">
												<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="EstadoCartaFianza" SortExpression="EstadoCartaFianza" HeaderText="ESTADO">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="observacion" SortExpression="observacion" HeaderText="OBSERVACION">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="INTERES" SortExpression="INTERES" HeaderText="INTERES"></asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3">
									<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
										<TR>
											<TD vAlign="top" align="center">
												<asp:label id="Label10" runat="server" CssClass="TextoNegroNegrita" style="Z-INDEX: 0">RESUMEN POR  MONEDA :</asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<cc1:datagridweb id="gridResumenMoneda" runat="server" PageSize="7" Width="168px" RowHighlightColor="#E0E0E0"
													AutoGenerateColumns="False" style="Z-INDEX: 0">
													<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
															<HeaderStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoFza" SortExpression="MontoFza" HeaderText="MONTO">
															<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="764" colSpan="3" align="left">
									<asp:Label id="Label6" runat="server" CssClass="TituloPrincipal" style="Z-INDEX: 0" Visible="False">DESCRIPCIÓN</asp:Label>
									<asp:TextBox id="txtDescripcion" runat="server" Width="765px" BorderStyle="Groove" TextMode="MultiLine"
										CssClass="normaldetalle" Height="50px" style="Z-INDEX: 0" Visible="False"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD align="left" width="764" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hGridPagina" type="hidden" name="hGridPagina" runat="server" style="WIDTH: 32px; HEIGHT: 22px"
										size="1" value="0"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label>
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
