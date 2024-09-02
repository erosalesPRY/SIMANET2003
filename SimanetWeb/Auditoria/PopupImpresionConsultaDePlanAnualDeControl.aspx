<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="PopupImpresionConsultaDePlanAnualDeControl.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Auditoria.PopupImpresionConsultaDePlanAnualDeControl" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server" onkeydown="return verificarBackspace()">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="97%" align="center" border="0">
				<TR>
					<TD class="Commands" style="HEIGHT: 11px" colSpan="3"></TD>
				</TR>
				<TR>
					<TD class="TituloPrincipal" align="center" colSpan="3">
						<asp:Label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:Label></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="normal" id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="6" rowSpan="3">
									<asp:datagrid id="grid" runat="server" AutoGenerateColumns="False" AllowPaging="True">
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="IdProgramacionAuditoria" SortExpression="IdProgramacionAuditoria"></asp:BoundColumn>
											<asp:BoundColumn DataField="IdProgramacionAuditoria" SortExpression="IdProgramacionAuditoria" HeaderText="NRO">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Codigo" SortExpression="Codigo" HeaderText="CODIGO">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Denominacion" SortExpression="Denominacion" HeaderText="DENOMINACION">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Observacion" SortExpression="Observacion" HeaderText="OBSERVACION">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="UnidadMedida" SortExpression="UnidadMedida" HeaderText="UM"></asp:BoundColumn>
											<asp:TemplateColumn SortExpression="FlgEnero" HeaderText="E">
												<ItemTemplate>
													<asp:Label id="lblMes1" runat="server" Font-Bold="True"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn SortExpression="FlgFebrero" HeaderText="F">
												<ItemTemplate>
													<asp:Label id="lblMes2" runat="server" Font-Bold="True"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn SortExpression="FlgMarzo" HeaderText="M">
												<ItemTemplate>
													<asp:Label id="lblMes3" runat="server" Font-Bold="True"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn SortExpression="FlgAbril" HeaderText="A">
												<ItemTemplate>
													<asp:Label id="lblMes4" runat="server" Font-Bold="True"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn SortExpression="FlgMayo" HeaderText="M">
												<ItemTemplate>
													<asp:Label id="lblMes5" runat="server" Font-Bold="True"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn SortExpression="FlgJunio" HeaderText="J">
												<ItemTemplate>
													<asp:Label id="lblMes6" runat="server" Font-Bold="True"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn SortExpression="FlgJulio" HeaderText="J">
												<ItemTemplate>
													<asp:Label id="lblMes7" runat="server" Font-Bold="True"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn SortExpression="FlgAgosto" HeaderText="A">
												<ItemTemplate>
													<asp:Label id="lblMes8" runat="server" Font-Bold="True"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn SortExpression="FlgSetiembre" HeaderText="S">
												<ItemTemplate>
													<asp:Label id="lblMes9" runat="server" Font-Bold="True"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn SortExpression="FlgOctubre" HeaderText="O">
												<ItemTemplate>
													<asp:Label id="lblMes10" runat="server" Font-Bold="True"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn SortExpression="FlgNoviembre" HeaderText="N">
												<ItemTemplate>
													<asp:Label id="lblMes11" runat="server" Font-Bold="True"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn SortExpression="FlgDiciembre" HeaderText="D">
												<ItemTemplate>
													<asp:Label id="lblMes12" runat="server" Font-Bold="True"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="PorcAvance" SortExpression="PorcAvance" HeaderText="%" DataFormatString="{0:#0.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Visible="False" CssClass="PagerGrilla"></PagerStyle>
									</asp:datagrid>
									<asp:Label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:Label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
