<%@ Page language="c#" Codebehind="AdministrarSAMNota.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.AdministrarSAMNota" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrar Notas</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD width="100%" colSpan="2">
									<asp:datagrid style="Z-INDEX: 0" id="Grid" runat="server" Width="100%" AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle Height="60px" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="FECHA">
												<HeaderStyle Width="9%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
												<ItemTemplate>
													<asp:textbox style="Z-INDEX: 0" id="txtFechaV" runat="server" Width="70px" rel="Calendario" CssClass="normaldetalle"
														Height="24px" BorderStyle="None"></asp:textbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="VERIFICACION">
												<HeaderStyle Width="40%"></HeaderStyle>
												<ItemTemplate>
													<asp:textbox style="Z-INDEX: 0" id="txtVerificacionV" runat="server" Width="100%" CssClass="normaldetalle2"
														Height="100%" BorderStyle="None" TextMode="MultiLine"></asp:textbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="OBSERVACION">
												<HeaderStyle Width="40%"></HeaderStyle>
												<ItemTemplate>
													<asp:textbox style="Z-INDEX: 0" id="txtObservacionesV" runat="server" Width="100%" CssClass="normaldetalle2"
														Height="100%" BorderStyle="None" TextMode="MultiLine"></asp:textbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemTemplate>
													<asp:image style="Z-INDEX: 0" id="imgEliminar22" runat="server" Width="20px" ImageUrl="../imagenes/Filtro/Eliminar.gif"
														Height="20px"></asp:image>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
						&nbsp;
					</TD>
				</TR>
				<TR>
					<TD style="DISPLAY: none" id="CellLstCausaRaiz" vAlign="top" width="100%" align="center"
						runat="server"></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
