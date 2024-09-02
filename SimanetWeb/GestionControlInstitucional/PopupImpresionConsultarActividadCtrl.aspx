<%@ Page language="c#" Codebehind="PopupImpresionConsultarActividadCtrl.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.PopupImpresionConsultarActividadCtrl" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="730" align="center" border="0">
				<TR>
					<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="normal" id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="6" rowSpan="3"><asp:datagrid id="grid" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="7"
										Width="720px" CssClass="HeaderGrilla">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Codigo" HeaderText="CODIGO">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Denominacion" HeaderText="DENOMINACION">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="UNIDADMEDIDA" HeaderText="UNID. MEDIDA">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Meta1erTrimestre" HeaderText="META 1ER TRIM"></asp:BoundColumn>
											<asp:BoundColumn DataField="Meta2doTrimestre" HeaderText="META 2DO TRIM"></asp:BoundColumn>
											<asp:BoundColumn DataField="Meta3erTrimestre" HeaderText="META 3ER TRIM"></asp:BoundColumn>
											<asp:BoundColumn DataField="Meta4toTrimestre" HeaderText="META 4TO TRIM"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="E"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="F"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="M"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="A"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="M"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="J"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="J"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="A"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="S"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="O"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="N"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="D"></asp:BoundColumn>
										</Columns>
										<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
