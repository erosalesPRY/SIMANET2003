<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="PopupConsultarConvenioSimaMgpUnidadesApoyo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.PopupConsultarConvenioSimaMgpUnidadesApoyo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>PopupConsultarConvenioSimaMgpUnidadesApoyo</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="730" align="center" border="0">
				<TR>
					<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><ALTERNATINGITEMSTYLE CssClass="Alternateitemgrilla"></ALTERNATINGITEMSTYLE><ITEMSTYLE CssClass="ItemGrilla"></ITEMSTYLE><HEADERSTYLE CssClass="HeaderGrilla"></HEADERSTYLE><FOOTERSTYLE CssClass="FooterGrilla"></FOOTERSTYLE><COLUMNS><ASP:BOUNDCOLUMN DataField="TipoProyecto"><ITEMSTYLE HorizontalAlign="Right"></ITEMSTYLE>
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN DataField="CantidadCallao" HeaderText="CANT">
								<HEADERSTYLE Width="35px"></HEADERSTYLE>
								<ITEMSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></ITEMSTYLE>
								<FOOTERSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></FOOTERSTYLE>
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN DataField="MontoPrecioVentaSolesCallao" HeaderText="MONTO" DataFormatString="{0:# ### ### ##0.00}">
								<HEADERSTYLE Width="110px"></HEADERSTYLE>
								<ITEMSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></ITEMSTYLE>
								<FOOTERSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></FOOTERSTYLE>
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN DataField="CantidadChimbote" HeaderText="CANT">
								<HEADERSTYLE Width="35px"></HEADERSTYLE>
								<ITEMSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></ITEMSTYLE>
								<FOOTERSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></FOOTERSTYLE>
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN DataField="MontoPrecioVentaSolesChimbote" HeaderText="MONTO" DataFormatString="{0:# ### ### ##0.00}">
								<HEADERSTYLE Width="110px"></HEADERSTYLE>
								<ITEMSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></ITEMSTYLE>
								<FOOTERSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></FOOTERSTYLE>
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN DataField="CantidadIquitos" HeaderText="CANT">
								<HEADERSTYLE Width="35px"></HEADERSTYLE>
								<ITEMSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></ITEMSTYLE>
								<FOOTERSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></FOOTERSTYLE>
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN DataField="MontoPrecioVentaSolesIquitos" HeaderText="MONTO" DataFormatString="{0:# ### ### ##0.00}">
								<HEADERSTYLE Width="110px"></HEADERSTYLE>
								<ITEMSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></ITEMSTYLE>
								<FOOTERSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></FOOTERSTYLE>
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN DataField="CantidadTotal" HeaderText="CANT">
								<HEADERSTYLE Width="35px"></HEADERSTYLE>
								<ITEMSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></ITEMSTYLE>
								<FOOTERSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></FOOTERSTYLE>
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN DataField="MontoPrecioVentaTotal" HeaderText="MONTO" DataFormatString="{0:# ### ### ##0.00}">
								<HEADERSTYLE Width="110px"></HEADERSTYLE>
								<ITEMSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></ITEMSTYLE>
								<FOOTERSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></FOOTERSTYLE>
							</ASP:BOUNDCOLUMN>
						</COLUMNS><PAGERSTYLE CssClass="PagerGrilla" Mode="NumericPages" Visible="False"></PAGERSTYLE><cc1:datagridweb id="grid" runat="server" ShowFooter="True" BorderStyle="None" RowHighlightColor="#E0E0E0"
							AllowSorting="True" PageSize="7" Width="780px" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="NroConvenio" HeaderText="CONVENIO">
									<HeaderStyle HorizontalAlign="Center" Width="9%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MontoAsignado" HeaderText="ASIGNADO" DataFormatString="{0:# ### ### ##0.00}">
									<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MontoAprovado" HeaderText="APROBADO" DataFormatString="{0:# ### ### ##0.00}">
									<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MontoEjecutado" HeaderText="EJECUTADO" DataFormatString="{0:# ### ### ##0.00}">
									<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MontoEnEjecucion" HeaderText="EN EJECUCION" DataFormatString="{0:# ### ### ##0.00}">
									<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MontoComprometido" HeaderText="COMPROMETIDO" DataFormatString="{0:# ### ### ##0.00}">
									<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MontoSaldo" HeaderText="SALDO" DataFormatString="{0:# ### ### ##0.00}">
									<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MontoPorCobrar" HeaderText="POR COBRAR" DataFormatString="{0:# ### ### ##0.00}">
									<HeaderStyle Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="normal" id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="6" rowSpan="3"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
						<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../imagenes/spacer.gif" width="160">
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblTitulo1" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><cc1:datagridweb id="grid1" runat="server" ShowFooter="True" BorderStyle="None" RowHighlightColor="#E0E0E0"
							AllowSorting="True" PageSize="7" Width="780px" AutoGenerateColumns="False">
<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn DataField="Etiqueta">
<HeaderStyle HorizontalAlign="Right" Width="10%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MontoAsignado" HeaderText="ASIGNADO" DataFormatString="{0:# ### ### ##0.00}">
<HeaderStyle Width="16%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MontoAprobado" HeaderText="APROBADO" DataFormatString="{0:# ### ### ##0.00}">
<HeaderStyle Width="16%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MontoEjecutado" HeaderText="EJECUTADO" DataFormatString="{0:# ### ### ##0.00}">
<HeaderStyle Width="15%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MontoEnEjecucion" HeaderText="EN EJECUCION" DataFormatString="{0:# ### ### ##0.00}">
<HeaderStyle Width="15%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MontoComprometido" HeaderText="COMPROMETIDO" DataFormatString="{0:# ### ### ##0.00}">
<HeaderStyle Width="15%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MontoSaldo" HeaderText="SALDO" DataFormatString="{0:# ### ### ##0.00}">
<HeaderStyle Width="13%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle">
</FooterStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblResultado1" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
