<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministrarCapacitacionListaAsistencia.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarCapacitacionListaAsistencia" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarCapacitacionListaAsistencia</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server" style="Z-INDEX: 0">
			<P>&nbsp;
				<cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" RowPositionEnabled="False" RowHighlightColor="#E0E0E0"
					AutoGenerateColumns="False" AllowSorting="True" PageSize="20" Width="100%" CssClass="HeaderGrilla">
					<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
					<ItemStyle Height="20px" CssClass="ItemGrilla"></ItemStyle>
					<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
					<FooterStyle CssClass="FooterGrilla"></FooterStyle>
					<Columns>
						<asp:BoundColumn HeaderText="NRO">
							<HeaderStyle Width="1%"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
							<FooterStyle HorizontalAlign="Left"></FooterStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="Descripcion" HeaderText="DESCRIPCION">
							<HeaderStyle Width="50%"></HeaderStyle>
							<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
						</asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
				</cc1:datagridweb></P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
		</form>
	</body>
</HTML>
