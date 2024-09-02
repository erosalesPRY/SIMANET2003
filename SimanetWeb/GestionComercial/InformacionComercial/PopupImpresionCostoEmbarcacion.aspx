<%@ Page language="c#" Codebehind="PopupImpresionCostoEmbarcacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InformacionComercial.PopupImpresionCostoEmbarcacion" %>
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
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Descripcion" HeaderText="TIPO EMBARCACION">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PesoEslora" HeaderText="ESLORA" DataFormatString="{0:##.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PesoManga" HeaderText="MANGA" DataFormatString="{0:##.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PesoPuntal" HeaderText="PUNTAL" DataFormatString="{0:##.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="COEFICIENTE" HeaderText="COEFICIENTE" DataFormatString="{0:##.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PESOEMBARCACION" HeaderText="PESO ACERO" DataFormatString="{0:##.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CO" HeaderText="ASTILL. CONS." DataFormatString="{0:##.00}"></asp:BoundColumn>
											<asp:BoundColumn DataField="COSTO" HeaderText="COSTO X KG." DataFormatString="{0:##.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="COSTOAPROXIMADO" HeaderText="COSTO APROX." DataFormatString="{0:##.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MONEDA" HeaderText="M">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FECHAACTUALIZACION" HeaderText="FECHA ACTUALIZ." DataFormatString="{0:dd-MM-yyyy}">
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
