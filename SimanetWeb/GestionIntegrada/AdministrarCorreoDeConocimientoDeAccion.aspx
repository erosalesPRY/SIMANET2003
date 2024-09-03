<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministrarCorreoDeConocimientoDeAccion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.AdministrarCorreoDeConocimientoDeAccion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>AdministrarCorreoDeConocimientoDeAccion</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
  </HEAD>
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%" align="center"
				style="Z-INDEX: 0">
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<div id="divScroll" style="BORDER-BOTTOM-COLOR: #0033ff; BORDER-RIGHT-WIDTH: 1px; OVERFLOW-X: hidden; BORDER-TOP-COLOR: #0033ff; WIDTH: 100%; BORDER-TOP-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; HEIGHT: 420px; BORDER-RIGHT-COLOR: #0033ff; OVERFLOW: auto; BORDER-LEFT-COLOR: #0033ff; BORDER-LEFT-WIDTH: 1px">
							<asp:datagrid style="Z-INDEX: 0" id="gridLst" runat="server" Height="0px" CellSpacing="2" AutoGenerateColumns="False"
								Width="100%" BorderWidth="0px">
								<FooterStyle CssClass="FooterGrilla"></FooterStyle>
								<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemGrilla"></ItemStyle>
								<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="chkSelected" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="Responsable" HeaderText="NOMBRE Y APELLIDO">
										<HeaderStyle Width="40%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Mensaje">
										<HeaderStyle Width="40%"></HeaderStyle>
										<ItemTemplate>
											<asp:TextBox style="Z-INDEX: 0" id="txtMensajeCorreo" runat="server" Width="100%" Height="40px" CssClass="normaldetalle2" TextMode="MultiLine" BorderStyle="None"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid>
						</div>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
