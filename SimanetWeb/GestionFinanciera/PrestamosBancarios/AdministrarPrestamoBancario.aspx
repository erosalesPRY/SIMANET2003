<%@ Page language="c#" Codebehind="AdministrarPrestamoBancario.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PrestamosBancarios.AdministrarPrestamoBancario" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
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
		onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td style="HEIGHT: 3px" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa" style="HEIGHT: 2px"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" width="900" class="RutaPaginaActual"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Préstamo Bancario</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px" vAlign="top" width="100%"></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE class="tabla" id="TblTabs" style="WIDTH: 769px; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
							width="769" align="center" bgColor="#f5f5f5" border="0" runat="server">
							<TR>
								<TD style="WIDTH: 2px">
									<asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita" Width="45px">SITUACIÓN :</asp:label></TD>
								<TD style="WIDTH: 7px">
									<asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="combos" Width="152px" AutoPostBack="True"></asp:dropdownlist>
								</TD>
								<TD style="WIDTH: 43px"><INPUT id="hCodigo" style="BORDER-BOTTOM: #000000 1px solid; BORDER-LEFT: #000000 1px solid; WIDTH: 18px; HEIGHT: 22px; BORDER-TOP: #000000 1px solid; BORDER-RIGHT: #000000 1px solid"
										type="hidden" size="1" name="hCodigo" runat="server" DESIGNTIMEDRAGDROP="1071"></TD>
								<TD style="WIDTH: 47px"><IMG style="WIDTH: 505px; HEIGHT: 7px" height="7" src="../../imagenes/spacer.gif" width="505"
										DESIGNTIMEDRAGDROP="314"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 7px" vAlign="top" width="800"><IMG style="WIDTH: 505px; HEIGHT: 7px" height="7" src="../../imagenes/spacer.gif" width="505"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" style="WIDTH: 772px; HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="772"
							border="0">
							<TR bgColor="#f0f0f0">
								<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
								<TD style="WIDTH: 92px">
									<asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
								<TD style="WIDTH: 134px">
									<IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
										src="../../imagenes/filtroporseleccion.jpg" runat="server"></TD>
								<TD style="WIDTH: 28px">
									<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
										ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
								<TD style="WIDTH: 22px">
									<asp:label id="Label10" runat="server" CssClass="normaldetalle" Width="53px" Font-Bold="True"> Buscar :</asp:label></TD>
								<TD style="WIDTH: 844px"><INPUT class="InputFind" id="txtBuscar" onkeydown="BusquedaporCampoColumna(this.value);"
										title="Buscar por la Columna Seleccionada" style="BORDER-BOTTOM: #999999 1px groove; BORDER-LEFT: #999999 1px groove; WIDTH: 152px; BORDER-TOP: #999999 1px groove; BORDER-RIGHT: #999999 1px groove"
										name="txtBuscar"></TD>
								<TD style="WIDTH: 197px">
									<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif" CausesValidation="False"></asp:imagebutton></TD>
								<TD>
									<asp:imagebutton id="ibtnAmortizar" runat="server" ImageUrl="../../imagenes/ibtnCronogramadePago.GIF"
										CausesValidation="False"></asp:imagebutton></TD>
								<TD></TD>
								<TD align="right" width="4"><IMG style="WIDTH: 4px; HEIGHT: 22px" height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
							</TR>
						</TABLE>
						<cc1:datagridweb id="grid" runat="server" Width="771px" PageSize="7" AllowPaging="True" AllowSorting="True"
							AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" ShowFooter="True">
<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO">
<HeaderStyle HorizontalAlign="Left" Width="1%" VerticalAlign="Middle">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Centro" SortExpression="Centro" HeaderText="CO">
<HeaderStyle HorizontalAlign="Center" Width="2%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Banco" SortExpression="Banco" HeaderText="ENTIDAD FINANCIERA">
<HeaderStyle HorizontalAlign="Center" Width="8%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="nroprestamo" SortExpression="nroprestamo" HeaderText="DOCUMENTO">
<HeaderStyle HorizontalAlign="Center" Width="4%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Center" VerticalAlign="Middle">
</FooterStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="FECHA">
<HeaderStyle Width="3%">
</HeaderStyle>

<HeaderTemplate>
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
											<TR>
												<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
													align="center" width="100%" colSpan="3">
													<asp:Label id="Label15" runat="server" CssClass="HeaderGrilla" Font-Bold="True" BorderStyle="None" Height="3px">FECHA</asp:Label></TD>
											</TR>
											<TR>
												<TD id="Td1" align="center" width="50%">
													<asp:Label id="Label14" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" Font-Bold="True" BorderStyle="None" Height="3px">INICIO</asp:Label></TD>
												<TD id="Td2" style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="50%">
													<asp:Label id="Label13" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" Font-Bold="True" BorderStyle="None" Height="3px">VENCE</asp:Label></TD>
											</TR>
										</TABLE>
									
</HeaderTemplate>

<ItemTemplate>
										<TABLE id="Table7" height="18" cellSpacing="0" cellPadding="0" width="100%" align="left"
											border="0">
											<TR>
												<TD id="Td3" align="center" width="50%">
													<asp:Label id="lblFechaInicio" runat="server" CssClass="normaldetalle" Width="57px">00-00-2000</asp:Label></TD>
												<TD id="Td4" style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="50%">
													<asp:Label id="lblFechaVence" runat="server" CssClass="normaldetalle" Width="57px" Height="0px">00-00-2000</asp:Label></TD>
											</TR>
										</TABLE>
									
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="NroDiasFaltantes" SortExpression="NroDiasFaltantes" HeaderText="DIAS">
<HeaderStyle HorizontalAlign="Center" Width="2%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Right">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TasaInteres" SortExpression="TasaInteres" HeaderText="TEA">
<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="1%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Center" VerticalAlign="Middle">
</FooterStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="IMPORTES">
<HeaderStyle Width="8%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom">
</ItemStyle>

<HeaderTemplate>
										<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
											<TR>
												<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
													align="center" width="100%" colSpan="3">
													<asp:Label id="Label9" runat="server" CssClass="HeaderGrilla" Font-Bold="True" BorderStyle="None" Height="3px">IMPORTE</asp:Label></TD>
											</TR>
											<TR>
												<TD id="tdHAjustadaP" align="center" width="32%">
													<asp:Label id="Label8" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" Font-Bold="True" BorderStyle="None" Height="3px">AUTORIZA</asp:Label></TD>
												<TD id="tdHHistoricoP" style="BORDER-RIGHT: #cccccc 1px solid; BORDER-LEFT: #cccccc 1px solid; WIDTH: 230px; HEIGHT: 10px"
													align="center" width="32%">
													<asp:Label id="LblHHistoricoP" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" Font-Bold="True" BorderStyle="None" Height="3px">AMORTIZA</asp:Label></TD>
												<TD id="tdHPPTOP" align="center" width="32%">
													<asp:Label id="Label3" runat="server" CssClass="HeaderGrilla" Font-Bold="True" BorderStyle="None" Height="3px">SALDO</asp:Label></TD>
											</TR>
										</TABLE>
									
</HeaderTemplate>

<ItemTemplate>
										<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
											border="0">
											<TR>
												<TD id="tdIAjustadaP" noWrap align="right" width="32%">
													<asp:Label id="lblMontoPrestamo" runat="server" CssClass="normaldetalle" Width="68px">0.0</asp:Label></TD>
												<TD id="tdIHistoricoP" style="BORDER-RIGHT: #cccccc 1px solid; BORDER-LEFT: #cccccc 1px solid; WIDTH: 230px; HEIGHT: 10px"
													align="right" width="32%">
													<asp:Label id="lblMontoAmortizado" runat="server" CssClass="normaldetalle" Width="76px" Height="0px">0.0</asp:Label></TD>
												<TD id="tdIPPTOP" noWrap align="right" width="32%">
													<asp:Label id="lblMontoSaldo" runat="server" CssClass="normaldetalle" Width="64px" Height="0px">0.0</asp:Label></TD>
											</TR>
										</TABLE>
									
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="MontoInteres" SortExpression="MontoInteres" HeaderText="MONTO INTERES">
<HeaderStyle HorizontalAlign="Center" Width="3%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table3" style="WIDTH: 770px; HEIGHT: 22px" cellSpacing="1" cellPadding="1" width="770"
							align="center" border="0">
							<TR>
								<TD width="8%">
									<asp:Label id="Label2" runat="server" CssClass="TextoAzul" Font-Bold="True">Concepto</asp:Label></TD>
								<TD style="HEIGHT: 5px">
									<asp:TextBox id="txtConcepto" runat="server" CssClass="normal" Width="100%" Height="16px" TextMode="MultiLine"
										EnableViewState="False" ReadOnly="True" BorderStyle="Groove"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD width="8%" colSpan="2"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server" DESIGNTIMEDRAGDROP="410"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="771" border="0" align="center">
							<TR bgcolor="#f0f0f0">
								<TD style="WIDTH: 329px; HEIGHT: 8px">
									<asp:Label id="Label11" runat="server" CssClass="TextoNegroNegrita">RESUMEN POR CENTRO OPERATIVO Y MONEDA :</asp:Label></TD>
								<TD style="HEIGHT: 8px">
									<asp:Label id="Label12" runat="server" CssClass="TextoNegroNegrita">RESUMEN POR BANCO Y MONEDA:</asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 329px" align="left">
									<cc1:datagridweb id="gridResumen1" runat="server" Width="100%" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
										AllowSorting="True" AllowPaging="True" PageSize="5" CssClass="Grid">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Centro" SortExpression="Centro" HeaderText="CO">
												<HeaderStyle HorizontalAlign="Center" Width="20%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
												<HeaderStyle HorizontalAlign="Center" Width="30%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="IMPORTES">
												<HeaderStyle Width="50%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table4" style="WIDTH: 230px; HEIGHT: 28px" cellSpacing="0" cellPadding="0" width="230"
														align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="3">
																<asp:Label id="Label9" runat="server" CssClass="HeaderGrilla" Font-Bold="True" BorderStyle="None">MONTO</asp:Label></TD>
														</TR>
														<TR>
															<TD id="tdHAjustadaP" align="center" width="32%">
																<asp:Label id="Label8" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" Font-Bold="True" BorderStyle="None">AUTORIZA</asp:Label></TD>
															<TD id="tdHHistoricoP" style="BORDER-RIGHT: #cccccc 1px solid; BORDER-LEFT: #cccccc 1px solid; WIDTH: 230px; HEIGHT: 10px"
																align="center" width="32%">
																<asp:Label id="LblHHistoricoP" runat="server" CssClass="HeaderGrilla" Font-Bold="True" BorderStyle="None">AMORTIZA</asp:Label></TD>
															<TD id="tdHPPTOP" align="center" width="32%">
																<asp:Label id="Label3" runat="server" CssClass="HeaderGrilla" Font-Bold="True" BorderStyle="None">SALDO</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" style="WIDTH: 230px" height="100%" cellSpacing="0" cellPadding="0" width="230"
														align="left" border="0" DESIGNTIMEDRAGDROP="81">
														<TR>
															<TD id="tdIAjustadaP" vAlign="middle" align="right" width="32%">
																<asp:Label id="lblMontoPrestamo" runat="server" CssClass="normaldetalle" Width="68px">0.0</asp:Label></TD>
															<TD id="tdIHistoricoP" style="BORDER-RIGHT: #cccccc 1px solid; BORDER-LEFT: #cccccc 1px solid; WIDTH: 230px; HEIGHT: 10px"
																vAlign="middle" align="right" width="32%">
																<asp:Label id="lblMontoAmortizado" runat="server" CssClass="normaldetalle" Width="76px" Height="0px">0.0</asp:Label></TD>
															<TD id="tdIPPTOP" vAlign="middle" align="right" width="32%">
																<asp:Label id="lblMontoSaldo" runat="server" CssClass="normaldetalle" Width="64px" Height="0px">0.0</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
								<TD align="left">
									<cc1:datagridweb id="gridResumen2" runat="server" CssClass="Grid" Width="100%" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" PageSize="5">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Banco" SortExpression="Banco" HeaderText="ENTIDAD FINANCIERA">
												<HeaderStyle HorizontalAlign="Center" Width="40%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
												<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="IMPORTES">
												<HeaderStyle Width="50%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table4" style="WIDTH: 230px; HEIGHT: 28px" cellSpacing="0" cellPadding="0" width="230"
														align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="3">
																<asp:Label id="Label7" runat="server" CssClass="HeaderGrilla" Font-Bold="True" BorderStyle="None">MONTO</asp:Label></TD>
														</TR>
														<TR>
															<TD id="tdHAjustadaP" align="center" width="32%">
																<asp:Label id="Label6" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" Font-Bold="True" BorderStyle="None">AUTORIZA</asp:Label></TD>
															<TD id="tdHHistoricoP" style="BORDER-RIGHT: #cccccc 1px solid; BORDER-LEFT: #cccccc 1px solid; WIDTH: 230px; HEIGHT: 10px"
																align="center" width="32%">
																<asp:Label id="Label5" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" Font-Bold="True" BorderStyle="None">AMORTIZA</asp:Label></TD>
															<TD id="tdHPPTOP" align="center" width="32%">
																<asp:Label id="Label4" runat="server" CssClass="HeaderGrilla" Font-Bold="True" BorderStyle="None">SALDO</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" style="WIDTH: 230px" height="100%" cellSpacing="0" cellPadding="0" width="230"
														align="left" border="0" DESIGNTIMEDRAGDROP="81">
														<TR>
															<TD id="tdIAjustadaP" vAlign="middle" noWrap align="right" width="32%">
																<asp:Label id="lblMontoPrestamo2" runat="server" CssClass="normaldetalle" Width="68px">0.0</asp:Label></TD>
															<TD id="tdIHistoricoP" style="BORDER-RIGHT: #cccccc 1px solid; BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px"
																vAlign="middle" noWrap align="right">
																<asp:Label id="lblMontoAmortizado2" runat="server" CssClass="normaldetalle" Width="76px" Height="0px">0.0</asp:Label></TD>
															<TD id="tdIPPTOP" vAlign="middle" noWrap align="right" width="32%">
																<asp:Label id="lblMontoSaldo2" runat="server" CssClass="normaldetalle" Width="64px" Height="0px">0.0</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR bgcolor="#f0f0f0">
								<TD style="WIDTH: 329px"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 329px"></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table6" style="WIDTH: 776px; HEIGHT: 27px" cellSpacing="1" cellPadding="1" width="776"
							align="center" border="0">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</table></TD></TR>
			<TR bgColor="#5891ae">
				<TD align="center" width="592" bgColor="#5891ae" style="HEIGHT: 5px"></TD>
			</TR></TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
