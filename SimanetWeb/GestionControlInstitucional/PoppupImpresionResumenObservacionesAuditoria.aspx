<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="PoppupImpresionResumenObservacionesAuditoria.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.PoppupImpresionResumenObservacionesAuditoria" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>PoppupImpresionResumenObservacionesAuditoria</title>
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
	<body topMargin="0">
		<DIV align="center">
			<form id="Form1" method="post" runat="server">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="650" border="0">
					<TR>
						<TD style="HEIGHT: 48px"></TD>
						<TD style="HEIGHT: 48px">
							<P align="center">
								<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></P>
						</TD>
						<TD style="HEIGHT: 48px"></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD>
							<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="650px" HorizontalAlign="Center"
								ShowFooter="True" PageSize="15" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True">
<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn Visible="False" HeaderText="NRO">
<HeaderStyle Width="1%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Organismo" HeaderText="ORGANISMO" FooterText="Total:">
<HeaderStyle Width="14%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="actividad" HeaderText="ACCION DE CONTROL">
<HeaderStyle Width="28%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="periodo" HeaderText="A&#209;O">
<HeaderStyle Width="8%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SP" HeaderText="SP.">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SC" HeaderText="SC.">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SCH" HeaderText="SCH.">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SI" HeaderText="SI.">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Total" HeaderText="TOTAL">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
							</cc1:datagridweb></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD>
							<P align="center">
								<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></P>
						</TD>
						<TD></TD>
					</TR>
				</TABLE>
			</form>
		</DIV>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
