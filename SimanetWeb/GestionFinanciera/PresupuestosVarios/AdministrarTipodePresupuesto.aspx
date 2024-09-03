<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministrarTipodePresupuesto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios.AdministrarTipodePresupuesto" %>
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
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Presupuesto por Tipo</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="602" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE id="Table13" style="WIDTH: 144px; HEIGHT: 27px" cellSpacing="1" cellPadding="1"
										width="144" align="left" border="0">
										<TR>
											<TD style="WIDTH: 66px">
												<asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" Width="80%" ForeColor="Navy"
													BackColor="Transparent">PERIODO :</asp:label></TD>
											<TD style="WIDTH: 66px">
												<asp:dropdownlist id="ddlbPeriodo" runat="server" CssClass="combos"></asp:dropdownlist></TD>
											<TD style="WIDTH: 42px">
												<asp:label id="Label2" runat="server" CssClass="TituloPrincipalBlanco" BackColor="Transparent"
													ForeColor="Navy">MES :</asp:label></TD>
											<TD style="WIDTH: 78px">
												<asp:dropdownlist id="dddblMes" runat="server" CssClass="combos" AutoPostBack="True">
													<asp:ListItem Value="1">Enero</asp:ListItem>
													<asp:ListItem Value="2">Febrero</asp:ListItem>
													<asp:ListItem Value="3">Marzo</asp:ListItem>
													<asp:ListItem Value="4">Abril</asp:ListItem>
													<asp:ListItem Value="5">Mayo</asp:ListItem>
													<asp:ListItem Value="6">Junio</asp:ListItem>
													<asp:ListItem Value="7">Julio</asp:ListItem>
													<asp:ListItem Value="8">Agosto</asp:ListItem>
													<asp:ListItem Value="9">Setiembre</asp:ListItem>
													<asp:ListItem Value="10">Octubre</asp:ListItem>
													<asp:ListItem Value="11">Noviembre</asp:ListItem>
													<asp:ListItem Value="12">Diciembre</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE style="HEIGHT: 25px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 12px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 78px"></TD>
											<TD style="WIDTH: 19px"></TD>
											<TD style="WIDTH: 31px"></TD>
											<TD style="WIDTH: 115px"><IMG style="WIDTH: 368px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="368"></TD>
											<TD style="WIDTH: 188px">
												<asp:imagebutton id="imgbtnImportarP" runat="server" ImageUrl="../../imagenes/btnImportaciones/btnImportarPresupuesto.gif"></asp:imagebutton></TD>
											<TD style="WIDTH: 187px">
												<asp:imagebutton id="imgbtnImportar" runat="server" ImageUrl="../../imagenes/btnImportaciones/btnImportarSaldosContables.gif"></asp:imagebutton></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="100%" ShowFooter="True" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NOMBRE" HeaderText="TIPO DE PRESUPUESTO">
												<HeaderStyle Width="20%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="PRESUPUESTO">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-RIGHT: #cccccc 1px solid; DISPLAY: none" align="center" width="10%"
																rowSpan="2">
																<asp:Label id="Label7" runat="server" Width="28px" ToolTip="Numero de la Última Renovación"
																	Font-Bold="True">NRO<BR>U.R</asp:Label></TD>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" width="80%" colSpan="3">
																<asp:Label id="lblFechas" runat="server" CssClass="HeaderGrilla" Font-Bold="True" BorderStyle="None"
																	Height="3px">IMPORTE</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="33%" height="3">
																<asp:Label id="Label8" runat="server" CssClass="HeaderGrilla" Width="51px" DESIGNTIMEDRAGDROP="175"
																	Font-Bold="True" BorderStyle="None">PRESUPUESTO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="33%" height="3">
																<asp:Label id="Label6" runat="server" CssClass="HeaderGrilla" Width="50px" Font-Bold="True"
																	BorderStyle="None">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="33%" height="3">
																<asp:Label id="Label5" tabIndex="3" runat="server" CssClass="HeaderGrilla" Width="50px" Font-Bold="True"
																	BorderStyle="None">SALDO</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD style="DISPLAY: none" vAlign="bottom" align="center" width="14%">
																<asp:Label id="lblNroRenov" runat="server" CssClass="ItemGrillaSinColor" Width="31px" DESIGNTIMEDRAGDROP="228"
																	Height="18px">0</asp:Label></TD>
															<TD vAlign="middle" noWrap align="right" width="33%">
																<asp:Label id="lblPresupuesto" runat="server" CssClass="normaldetalle" Width="58px" Height="12px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" vAlign="middle" noWrap align="right" width="33%">
																<asp:Label id="lblReal" runat="server" CssClass="normaldetalle" Width="58px" DESIGNTIMEDRAGDROP="386"
																	Height="12px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" vAlign="middle" noWrap align="right" width="33%">
																<asp:Label id="lblSaldo" runat="server" CssClass="normaldetalle" Width="58px" Height="12px">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="690" border="0" style="WIDTH: 690px; HEIGHT: 28px">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
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
