<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="PopupConsultarContratosPromotor.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Promotores.PopupConsultarContratosPromotor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PopupConsultarContratosPromotor</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD class="TituloPrincipal" colSpan="3">
						<P align="center">
							<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> CONTRATOS POR PROMOTOR</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:label id="lblNombre" runat="server" CssClass="TituloSecundario"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="550" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="550" border="0">
										<TR>
											<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="250"></TD>
											<TD bgColor="#398094"></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="550px" AllowSorting="True"
										AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False"
										ShowFooter="True" PageSize="7">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="Total">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IdContrato" HeaderText="IdContrato"></asp:BoundColumn>
											<asp:BoundColumn DataField="NROCONTRATO" SortExpression="NROCONTRATO" HeaderText="NROCONTRATO">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FECHAINICOCONTRATO" SortExpression="FECHA INICIO" HeaderText="FECHA INICIO">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FECHATERMINOCONTRATO" SortExpression="DESCRIPCIONVENTAREAL" HeaderText="FECHA TERMINO">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="56"
										Visible="False"></asp:label></TD>
							</TR>
						</TABLE>
						<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160">
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
