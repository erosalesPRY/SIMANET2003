<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="PopupImpresionConsultarDetalleVentasPresupuestadas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.PopupImpresionConsultarDetalleVentasPresupuestadas" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PopupImpresionConsultarDetalleVentasPresupuestadas</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<DIV align="center">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" align="center" border="0">
					<TR>
						<TD>
							<P align="center" class="TituloPrincipal">
								<asp:Label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:Label></P>
						</TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD>
							<asp:DataGrid id="grid" runat="server" CssClass="HeaderGrilla" AutoGenerateColumns="False" Width="720px"
								PageSize="7" AllowPaging="True" ShowFooter="True">
								<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemGrilla"></ItemStyle>
								<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
								<FooterStyle CssClass="FooterGrilla"></FooterStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="IdVenta" HeaderText="IDVENTA">
										<HeaderStyle Width="1%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SECTOR" HeaderText="SECTOR">
										<HeaderStyle Width="6%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LN" HeaderText="LN">
										<HeaderStyle Width="2%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RAZONSOCIAL" HeaderText="CLIENTE">
										<HeaderStyle Width="34%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PROYECTO" HeaderText="PROYECTO">
										<HeaderStyle Width="34%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MONTO" HeaderText="MONTO">
										<HeaderStyle Width="13%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FECHA" HeaderText="FECHA">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Visible="False" CssClass="PagerGrilla"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
					<TR>
						<TD>
							<P align="center">
								<asp:Label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:Label></P>
						</TD>
					</TR>
					<TR>
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
