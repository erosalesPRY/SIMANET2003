<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="PopupImpresionAdministracionInformeVariosSesionDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio.PopupImpresionAdministracionInformeVariosSesionDirectorio" %>
<%@ Register TagPrefix="uc1" TagName="FooterImpresion" Src="../../ControlesUsuario/FooterImpresion.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server" onkeydown="return verificarBackspace()">
			<TABLE class="xsolid" id="Table1" cellSpacing="0" cellPadding="0" width="725" align="center"
				border="0">
				<TR>
					<TD align="center" class="TituloPrincipal"><asp:label id="lblTitulo" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="xsolid" align="center">
									<cc1:datagridweb id="grid" runat="server" DataKeyField="IdInformeVariosSesionDirecto" AllowPaging="True"
										AutoGenerateColumns="False" Width="689px" PageSize="7">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="IdInformeVariosSesionDirecto" SortExpression="IdInformeVariosSesionDirecto"
												HeaderText="IdInformeVariosSesionDirecto"></asp:BoundColumn>
											<asp:BoundColumn DataField="IdInformeVariosSesionDirecto" SortExpression="IdInformeVariosSesionDirecto"
												HeaderText="NRO. INFORME">
												<HeaderStyle Width="13%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Fecha" SortExpression="Fecha" HeaderText="FECHA" DataFormatString="{0:dd/MM/yyyy}">
												<HeaderStyle Width="15%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Tema" SortExpression="Tema" HeaderText="TEMA">
												<HeaderStyle Width="35%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Detalle" SortExpression="Detalle" HeaderText="DETALLE">
												<HeaderStyle Width="35%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="lblResultado" runat="server" Visible="False" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
