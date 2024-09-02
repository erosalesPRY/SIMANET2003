<%@ Page language="c#" Codebehind="PoppupImpresionProgramacionActividades.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.PoppupImpresionProgramacionActividades" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PoppupImpresionProgramacionActividades</title>
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bottomMargin="0" topMargin="0">
		<DIV align="center">
			<form id="Form1" method="post" runat="server">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" border="0">
					<TR>
						<TD style="HEIGHT: 43px"></TD>
						<TD style="HEIGHT: 43px">
							<P align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></P>
						</TD>
						<TD style="HEIGHT: 43px"></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD><cc1:datagridweb id="grid" runat="server" ShowFooter="True" PageSize="7" Width="740px" AllowSorting="True"
								AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" CssClass="HeaderGrilla">
								<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemGrilla"></ItemStyle>
								<FooterStyle CssClass="FooterGrilla"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="Organismo" HeaderText="ORGANISMO">
										<HeaderStyle Width="12%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<FooterStyle HorizontalAlign="Left"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AsuntoDocumento" HeaderText="ASUNTO">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CentroOperativo" HeaderText="C.O.">
										<HeaderStyle Width="1%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Situacion" HeaderText="SITUACION">
										<HeaderStyle Width="15%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FechaInicio" HeaderText="FECHA INIC." DataFormatString="{0:dd-MM-yyyy}">
										<HeaderStyle Width="12%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FechaTermino" HeaderText="FECHA TERM." DataFormatString="{0:dd-MM-yyyy}">
										<HeaderStyle Width="9%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn Visible="False">
										<HeaderStyle Width="3%"></HeaderStyle>
										<ItemTemplate>
											<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
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
