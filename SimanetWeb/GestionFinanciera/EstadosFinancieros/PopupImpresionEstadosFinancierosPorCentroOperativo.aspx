<%@ Page language="c#" Codebehind="PopupImpresionEstadosFinancierosPorCentroOperativo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.PopupImpresionEstadosFinancierosPorCentroOperativo" %>
<%@ Register TagPrefix="cc2" Namespace="ControlesWeb" Assembly="ControlesWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial2();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3" align="center" class="TituloPrincipal">
						<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="3" align="center">
						<TABLE class="normal" id="Table2" style="WIDTH: 770px; HEIGHT: 212px" cellSpacing="0" cellPadding="4"
							width="770" border="0">
							<TR>
								<TD style="WIDTH: 786px" align="center" width="786" colSpan="3">
									<TABLE id="Table3" style="HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 145px"></TD>
											<TD width="100%">
												<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" align="left" border="0">
													<TR>
														<TD style="WIDTH: 63px">
															<asp:label id="Label4" runat="server" CssClass="TituloPrincipalBlanco" DESIGNTIMEDRAGDROP="151"
																Font-Bold="True" ForeColor="Navy">PERIODO :</asp:label></TD>
														<TD style="WIDTH: 34px">
															<asp:label id="lblPeriodo" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True"
																ForeColor="Navy">[Periodo]</asp:label></TD>
														<TD style="WIDTH: 37px">
															<asp:label id="Label5" runat="server" CssClass="TituloPrincipalBlanco" DESIGNTIMEDRAGDROP="174"
																Font-Bold="True" ForeColor="Navy">MES :</asp:label></TD>
														<TD>
															<asp:label id="lblMes" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True" ForeColor="Navy">[Mes]</asp:label></TD>
													</TR>
												</TABLE>
											</TD>
											<TD vAlign="bottom">&nbsp;</TD>
											<TD></TD>
											<TD style="WIDTH: 209px" align="right"></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="770px" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="CONCEPTO" SortExpression="CONCEPTO" HeaderText="CONCEPTO">
												<HeaderStyle Width="30%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CallaoEjecucionRealDelmesAnterior" HeaderText="Mes&lt;br&gt;Anterior">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CallaoEjecucionRealDelmesActual" HeaderText="Mes&lt;br&gt;Actual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CallaoEjecucionRealAcumulado">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CallaoPresupuestoAnual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CallaoProyectadoAnual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ChimboteEjecucionRealDelmesAnterior">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ChimboteEjecucionRealDelmesActual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ChimboteEjecucionRealAcumulado">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ChimbotePresupuestoAnual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ChimboteProyectadoAnual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 786px" align="left" width="786" colSpan="3"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
