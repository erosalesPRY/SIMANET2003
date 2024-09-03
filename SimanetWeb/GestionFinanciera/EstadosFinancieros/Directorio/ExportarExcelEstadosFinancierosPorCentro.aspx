<%@ Register TagPrefix="cc2" Namespace="ControlesWeb" Assembly="ControlesWeb" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ExportarExcelEstadosFinancierosPorCentro.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio.ExportarExcelEstadosFinancierosPorCentro" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../../Stylos/Temas.css" type="text/css" rel="stylesheet">
  </HEAD>
<BODY bottomMargin=0 leftMargin=0 topMargin=0 rightMargin=0 ?>
<FORM id=Form1 method=post runat="server">
	<table cellPadding="0" width="100%" align="center" border="0" cellSpacing=0>
				<TR>
					<TD align="right" colSpan="3">
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR bgColor="#f0f0f0">
								<TD align="left">
									<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
										<TR>
											<TD style="WIDTH: 52px"></TD>
											<TD style="WIDTH: 36px"></TD>
											<TD style="WIDTH: 24px"></TD>
											<TD style="WIDTH: 88px"></TD>
											<TD align="right">
												<asp:ImageButton id="ibtnAbrir" ImageUrl="..\..\..\imagenes\bt_exportar.gif" Runat="server" /></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD id='idContent'><cc1:datagridweb id="grid" runat="server" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="CONCEPTO" SortExpression="CONCEPTO" HeaderText="CONCEPTO">
												<HeaderStyle Width="25%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="EjecucionRealDelmesAnterior" HeaderText="Mes&lt;br&gt;Anterior">
												<HeaderStyle Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="DEL MES">
												<HeaderStyle Width="23.33%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="3">
																<asp:Label id="lblDelMes" runat="server" CssClass="HeaderGrilla" BorderStyle="None">FEBRERO</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="28.33%">
																<asp:Label id="lblDelMesRealH" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="Gasto real del mes">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="28.33%">
																<asp:Label id="lblDelMesPPTOH" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="Prespuesto del mes">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="20.33%">
																<asp:Label id="lblDelMesVarH" runat="server" CssClass="HeaderGrilla" BorderStyle="None">DIF.</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table6" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="28.33%">
																<asp:Label id="lblDelMesReal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="28.33%">
																<asp:Label id="lblDelMesPPTO" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="20.33%">
																<asp:Label id="lblDelMesVar" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VAR(%)</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="ACUMULADO">
												<HeaderStyle Width="23.33%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="3">
																<asp:Label id="lblAcumulado" runat="server" CssClass="HeaderGrilla" BorderStyle="None">ACUMULADO</asp:Label></TD>
														</TR>
														<TR>
															<TD noWrap align="center" width="28.33%">
																<asp:Label id="lblAcumRealHH" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="Gasto real al mes">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="center" width="28.33%">
																<asp:Label id="lblAcumPPTOHH" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="Prespuesto al mes">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="center" width="20.33%">
																<asp:Label id="lblAcumVarHH" runat="server" CssClass="HeaderGrilla" BorderStyle="None">DIF.</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table7" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="28.33%">
																<asp:Label id="lblAcumReal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="28.33%">
																<asp:Label id="lblAcumPPTO" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="20.33%">
																<asp:Label id="lblAcumVar" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VAR(%)</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="PROYECTADO ANUAL">
												<HeaderStyle Width="23.33%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="3">
																<asp:Label id="lblProyectado" runat="server" CssClass="HeaderGrilla" BorderStyle="None">VARIACION ANUAL</asp:Label></TD>
														</TR>
														<TR>
															<TD noWrap align="center" width="28.33%">
																<asp:Label id="lblProyRealH" runat="server" CssClass="HeaderGrilla" BorderStyle="None">PROY</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="center" width="28.33%">
																<asp:Label id="lblProyPPTOH" runat="server" CssClass="HeaderGrilla" BorderStyle="None">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="center" width="20.33%">
																<asp:Label id="lblProyVarH" runat="server" CssClass="HeaderGrilla" BorderStyle="None">VAR(%)</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="28.33%">
																<asp:Label id="lblProyReal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="28.33%">
																<asp:Label id="lblProyPPTO" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="20.33%">
																<asp:Label id="lblProyVar" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VAR(%)</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
	</table>
			<SCRIPT>
				SIMA.Utilitario.Error.TiempoEsperadePagina();
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
</FORM>
	</BODY>
</HTML>
