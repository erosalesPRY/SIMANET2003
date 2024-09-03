<%@ Page language="c#" Codebehind="ConsultarClausulaPorNormaISO.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.ConsultarClausulaPorNormaISO" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarClausulaPorNormaISO</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form style="Z-INDEX: 0" id="Form1" method="post" runat="server">
			<div style="OVERFLOW-Y: scroll; HEIGHT: 540px">
				<asp:DataGrid id="gridClausula" runat="server" Width="100%" AutoGenerateColumns="False">
					<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
					<ItemStyle Height="20px" CssClass="ItemGrilla"></ItemStyle>
					<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="NormaISO" HeaderText="CLAUSULA">
							<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
						</asp:BoundColumn>
					</Columns>
				</asp:DataGrid></div>
		</form>
	</body>
</HTML>
