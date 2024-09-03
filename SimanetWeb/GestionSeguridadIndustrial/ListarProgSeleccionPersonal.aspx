<%@ Page language="c#" Codebehind="ListarProgSeleccionPersonal.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.ListarProgSeleccionPersonal" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListarProgSeleccionPersonal</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="784" style="WIDTH: 784px; HEIGHT: 504px">
				<tr>
					<td>
						<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD>
									<asp:Label id="Label1" runat="server">Buscar</asp:Label></TD>
								<TD width="100%">
									<asp:TextBox style="Z-INDEX: 0" id="txtBuscar" runat="server" Width="100%"></asp:TextBox></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD vAlign="top" align="left">
						<div style="OVERFLOW-X:hidden; OVERFLOW-Y:auto; WIDTH:800px; HEIGHT:290px">
							<cc1:datagridweb style="Z-INDEX: 0" id="gridLst" runat="server" CssClass="HeaderGrilla" RowPositionEnabled="False"
								RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" Width="100%" PageSize="20">
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
									<asp:TemplateColumn HeaderText="FOTO"></asp:TemplateColumn>
									<asp:BoundColumn DataField="NroPersonal" HeaderText="NRO PR.">
										<HeaderStyle Width="2%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NroDNI" HeaderText="DNI">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ApellidosyNombres" HeaderText="APELLIDOS Y NOMBRES">
										<HeaderStyle Width="50%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NombreArea" HeaderText="AREA">
										<HeaderStyle Width="30%"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="NOTA">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemTemplate>
											<asp:TextBox id="txtNota" runat="server" Width="28px"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="8%"></HeaderStyle>
										<ItemTemplate>
											<IMG style="Z-INDEX: 0" id="imgAsistencia" src="../imagenes/Filtro/Aprobar.gif" runat="server">
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							</cc1:datagridweb>
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
