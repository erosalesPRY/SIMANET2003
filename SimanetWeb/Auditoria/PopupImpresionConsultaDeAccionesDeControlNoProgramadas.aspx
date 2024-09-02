<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="PopupImpresionConsultaDeAccionesDeControlNoProgramadas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Auditoria.PopupImpresionConsultaDeAccionesDeControlNoProgramadas" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
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
											<asp:BoundColumn DataField="IdAccionControlNoProgramada" SortExpression="IdAccionControlNoProgramada"
												HeaderText="NRO">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="ACCION CORRECTIVA">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Solicitante" SortExpression="Solicitante" HeaderText="SOLICITANTE"></asp:BoundColumn>
											<asp:BoundColumn DataField="CentroOperativo" SortExpression="CentroOperativo" HeaderText="CO">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Area" SortExpression="Area" HeaderText="AREA">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FechaInicio" SortExpression="FechaInicio" HeaderText="FI" DataFormatString="{0:dd-MM-yyyy}">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FechaFin" SortExpression="FechaFin" HeaderText="FT" DataFormatString="{0:dd-MM-yyyy}">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PorcAvance" SortExpression="PorcAvance" HeaderText="%" DataFormatString="{0:#0.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
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
