<%@ Page language="c#" Codebehind="PopupImpresionAdministracionObservacionesAuditoria.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.PopupImpresionAdministracionObservacionesAuditoria" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PoppupImpresionObservacionesAuditoria</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body bottomMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<DIV align="center">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" align="center" border="0">
					<TR>
						<TD style="HEIGHT: 44px"></TD>
						<TD style="HEIGHT: 44px">
							<P align="center">
								<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></P>
						</TD>
						<TD style="HEIGHT: 44px"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 12px"></TD>
						<TD style="HEIGHT: 12px">
							<asp:label id="lblCabecera" runat="server" Font-Size="X-Small" Font-Bold="True"></asp:label></TD>
						<TD style="HEIGHT: 12px"></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD>
							<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" RowPositionEnabled="False" RowHighlightColor="#E0E0E0"
								AutoGenerateColumns="False" AllowSorting="True" PageSize="7" ShowFooter="True" Width="640px">
								<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemGrilla"></ItemStyle>
								<FooterStyle CssClass="FooterGrilla"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="Observacion" HeaderText="OBSERVACION">
										<HeaderStyle HorizontalAlign="Center" Width="50%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<FooterStyle HorizontalAlign="Left"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CentroOperativo" HeaderText="C.O.">
										<HeaderStyle Width="1%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Situacion" HeaderText="SITUACION">
										<HeaderStyle Width="12%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FechaTermino" HeaderText="FECHA TERM." DataFormatString="{0:dd-MM-yyyy}">
										<HeaderStyle Width="11%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn Visible="False">
										<HeaderStyle Width="0%"></HeaderStyle>
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
			</DIV>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
