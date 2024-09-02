<%@ Page language="c#" Codebehind="PopupImpresionTarifaEmbarcacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InformacionComercial.PopupImpresionTarifaEmbarcacion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="97%" align="center" border="0">
				<TR>
					<TD class="Commands" style="HEIGHT: 11px" colSpan="3"></TD>
				</TR>
				<TR>
					<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="normal" id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="6" rowSpan="3"><asp:datagrid id="grid" runat="server" ShowFooter="True" AllowPaging="True" AutoGenerateColumns="False"
										PageSize="7" Width="670px">
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DESCRIPCIONTRABAJO" HeaderText="DESCRIPCION">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Descripcion" HeaderText="DETALLE" DataFormatString="{0:##.00}">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Embarcacion" HeaderText="TIPO DE EMBARCACION">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Costo" HeaderText="COSTO" DataFormatString="{0:##.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MONEDA" HeaderText="M">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
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
