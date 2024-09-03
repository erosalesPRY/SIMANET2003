<%@ Page language="c#" Codebehind="ConsultarPresupuestodeVentasLiquidadasDetalle.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios.ConsultarPresupuestodeVentasLiquidadasDetalle" %>
<%@ Register TagPrefix="cc2" Namespace="ControlGridScroll" Assembly="ControlGridScroll" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix=avg Assembly=ControlGridScroll Namespace=ControlGridScroll %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DETALLE DE CONCEPTO</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="15" topMargin="0" onload="ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" style="WIDTH: 736px; HEIGHT: 155px" cellSpacing="0" cellPadding="0"
							width="736" border="0">
							<TR>
								<TD style="WIDTH: 764px" align="center" width="764" colSpan="3">
									<TABLE style="HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD style="WIDTH: 19px" colSpan="7">
												<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
													<TR>
														<TD><asp:label id="Label1" runat="server" Height="8px" CssClass="TituloPrincipal">CONCEPTO   :</asp:label></TD>
														<TD><asp:label id="lblRubro" runat="server" Height="16px" CssClass="TituloPrincipal" Width="343px"></asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="735px" AutoGenerateColumns="False" DESIGNTIMEDRAGDROP="59">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="descripcion" SortExpression="descripcion" HeaderText="CONCEPTO">
												<HeaderStyle Width="60%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="MOVIMIENTOS">
												<HeaderTemplate>
													<TABLE id="Table4" height="100%" cellSpacing="1" cellPadding="1" width="100%" align="left"
														border="0">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" colSpan="4">
																<asp:Label id="Label14" runat="server" CssClass="HeaderGrilla" Height="3px" Font-Bold="True"
																	BorderStyle="None">SIMA-IQUITOS SR.L.tda.</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" height="40">
																<asp:Label id="Label11" runat="server" CssClass="HeaderGrilla" Width="82px" Font-Bold="True"
																	BorderStyle="None">VENTAS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" height="40">
																<asp:Label id="Label10" runat="server" CssClass="HeaderGrilla" Width="82px" Font-Bold="True"
																	BorderStyle="None">COSTOS</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" height="100%" cellSpacing="1" cellPadding="1" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right">
																<asp:Label id="lblVentas" runat="server" CssClass="normaldetalle" Width="79px" Height="12px">Label</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="right">
																<asp:Label id="lblCosto" runat="server" CssClass="normaldetalle" Width="82px" Height="12px">Label</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Visible="False" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
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
