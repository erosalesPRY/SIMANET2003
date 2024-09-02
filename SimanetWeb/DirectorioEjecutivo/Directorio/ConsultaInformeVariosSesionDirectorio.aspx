<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="ConsultaInformeVariosSesionDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio.ConsultaInformeVariosSesionDirectorio" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js?ver=Basico"></SCRIPT>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server" onkeydown="return verificarBackspace()">
			<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td>
						<uc1:Header id="Header1" runat="server"></uc1:Header></td>
				</tr>
				<tr>
					<td valign="top">
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></td>
				</tr>
				<TR>
					<TD class="Commands" vAlign="top">
						<asp:label id="Label1" runat="server" CssClass="RutaPagina">Inicio >Gestión de la Dirección ></asp:label>
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Informes</asp:label></TD>
				</TR>
				<tr>
					<td valign="top" align="center">
						<table cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
							<TR>
								<TD align="left">
									<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="100%" colSpan="3" align="left">
												<asp:label style="Z-INDEX: 0" id="lblInformesPermanentes" runat="server" CssClass="TituloPrincipalAzul"> Permanentes</asp:label></TD>
										</TR>
										<TR>
											<TD align="center" width="100%" colSpan="3">
												<cc1:datagridweb id="grid" runat="server" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
													Width="100%" AllowSorting="True" CssClass="HeaderGrilla" ShowFooter="True" PageSize="7">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO.">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Tema" SortExpression="Tema" HeaderText="ASUNTO">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="3%"></HeaderStyle>
															<ItemTemplate>
																<asp:Image id="imgDocumento" runat="server" ImageUrl="../../imagenes/ley1.gif" Height="18px"></asp:Image>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="3%"></HeaderStyle>
															<ItemTemplate>
																<asp:Image id="imgDocumento2" runat="server" ImageUrl="../../imagenes/ley1.gif" Height="18px"></asp:Image>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="3%"></HeaderStyle>
															<ItemTemplate>
																<asp:Image id="imgDocumento3" runat="server" ImageUrl="../../imagenes/ley1.gif" Height="18px"></asp:Image>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb>
											</TD>
										</TR>
										<TR>
											<TD width="100%" colSpan="3" align="center"><IMG style="Z-INDEX: 0" src="../../imagenes/spacer.gif" width="620" height="8"></TD>
										</TR>
										<TR>
											<TD width="100%" colSpan="3" align="center"><IMG style="Z-INDEX: 0" src="../../imagenes/spacer.gif" width="620" height="8"></TD>
										</TR>
										<TR>
											<TD width="100%" colSpan="3" align="left">
												<asp:label style="Z-INDEX: 0" id="lblInformesVarios" runat="server" CssClass="TituloPrincipalAzul"> Varios</asp:label></TD>
										</TR>
										<TR>
											<TD width="100%" colSpan="3" align="center">
												<cc1:datagridweb style="Z-INDEX: 0" id="gridVarios" runat="server" CssClass="HeaderGrilla" PageSize="7"
													ShowFooter="True" AllowSorting="True" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO.">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Tema" SortExpression="Tema" HeaderText="ASUNTO">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="3%"></HeaderStyle>
															<ItemTemplate>
																<asp:Image id="imgDocumento" runat="server" ImageUrl="../../imagenes/ley1.gif" Height="18px"></asp:Image>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="3%"></HeaderStyle>
															<ItemTemplate>
																<asp:Image id="imgDocumento2" runat="server" ImageUrl="../../imagenes/ley1.gif" Height="18px"></asp:Image>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="3%"></HeaderStyle>
															<ItemTemplate>
																<asp:Image id="imgDocumento3" runat="server" ImageUrl="../../imagenes/ley1.gif" Height="18px"></asp:Image>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb></TD>
										</TR>
									</TABLE>
									<IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
										style="CURSOR: hand"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 9px" type="hidden" size="1" name="hCodigo"
										runat="server">
								</TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
