<%@ Page language="c#" Codebehind="PoppupImpresionDocumentosAuditoria.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.PoppupImpresionDocumentosAuditoria" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>PoppupImpresionDocumentosAuditoria</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
	<body topMargin="0">
		<DIV align="center">
			<form id="Form1" method="post" runat="server">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" border="0">
					<TR>
						<TD style="HEIGHT: 47px"></TD>
						<TD style="HEIGHT: 47px">
							<P align="center">
								<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></P>
						</TD>
						<TD style="HEIGHT: 47px"></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD>
<cc1:datagridweb id=grid runat="server" CssClass="HeaderGrilla" RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" Width="780px" PageSize="4" ShowFooter="True">
<AlternatingItemStyle CssClass="AlternateItemGrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn DataField="Organismo" SortExpression="Organismo" HeaderText="ORGANISMO">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SUBORGANISMO" SortExpression="SUBORGANISMO" HeaderText="SUB ORGANISMO">
<HeaderStyle Width="13%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Actividad" SortExpression="Actividad" HeaderText="ACCION CONTROL">
<HeaderStyle Width="13%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Periodo" SortExpression="Periodo" HeaderText="A&#209;O">
<HeaderStyle Width="2%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Observacion" SortExpression="Observacion" HeaderText="DESCRIPCION">
<HeaderStyle Width="25%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CentroOperativo" SortExpression="CentroOperativo" HeaderText="C.O.">
<HeaderStyle Width="3%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Situacion" SortExpression="Situacion" HeaderText="SITUACION">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="FechaInicio" SortExpression="FechaInicio" HeaderText="FECHA INIC." DataFormatString="{0:dd-MM-yyyy}">
<HeaderStyle Width="12%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="FechaTermino" SortExpression="FechaTermino" HeaderText="FECHA TERM." DataFormatString="{0:dd-MM-yyyy}">
<HeaderStyle Width="12%">
</HeaderStyle>
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
