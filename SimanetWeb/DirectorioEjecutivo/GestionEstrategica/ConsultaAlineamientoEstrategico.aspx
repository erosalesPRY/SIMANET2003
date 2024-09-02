<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ConsultaAlineamientoEstrategico.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Gestion_Estrategica.ConsultaAlineamientoEstrategico" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultaObjetivoGeneral</title>
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
				</TR>
				<TR>
					<TD class="commands">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Estratégica > Proceso Estratégico > Consultar  Alineamiento Estratégico</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<P align="left" style="COLOR: white">
							<asp:Image id="Image1" runat="server" Width="48px" ImageUrl="../../imagenes/spacer.gif" Height="16px"></asp:Image></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<asp:Label id="lblTitulo1" runat="server" CssClass="TituloPrincipalAzul">ALINEAMIENTO ESTRATEGICO</asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="782" border="0" align="center">
							<TR>
								<TD style="HEIGHT: 1px">
									<P align="center">
										<asp:Label id="lblTitulo" runat="server" CssClass="TituloPrincipalAzul">OBJETIVOS GENERALES</asp:Label></P>
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 1px">
									<asp:Image id="Image2" runat="server" Height="16px" ImageUrl="../../imagenes/spacer.gif" Width="48px"></asp:Image></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 70px" vAlign="top"><ALTERNATINGITEMSTYLE CssClass="AlternateItemGrilla">
										<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" RowPositionEnabled="False"
											RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True"
											ShowFooter="True" PageSize="7">
											<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla"></FooterStyle>
											<Columns>
												<asp:BoundColumn DataField="IDOGENERALES" HeaderText="NRO">
													<HeaderStyle Width="2%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCION">
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left"></FooterStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb>
									</ALTERNATINGITEMSTYLE><ITEMSTYLE CssClass="ItemGrilla"></ITEMSTYLE><HEADERSTYLE CssClass="HeaderGrilla" HorizontalAlign="Center"></HEADERSTYLE><FOOTERSTYLE CssClass="FooterGrilla" HorizontalAlign="Right"></FOOTERSTYLE><COLUMNS>
										<ASP:BOUNDCOLUMN HeaderText="NRO" DataField="IDOGENERALES">
											<HEADERSTYLE Width="2%"></HEADERSTYLE>
											<ITEMSTYLE HorizontalAlign="Center" VerticalAlign="Middle"></ITEMSTYLE>
											<FOOTERSTYLE HorizontalAlign="Left"></FOOTERSTYLE>
										</ASP:BOUNDCOLUMN>
										<ASP:BOUNDCOLUMN HeaderText="DESCRIPCION" DataField="DESCRIPCION" SortExpression="DESCRIPCION">
											<ITEMSTYLE HorizontalAlign="Left" VerticalAlign="Middle"></ITEMSTYLE>
											<FOOTERSTYLE HorizontalAlign="Left"></FOOTERSTYLE>
										</ASP:BOUNDCOLUMN>
									</COLUMNS><PAGERSTYLE CssClass="PagerGrilla" Mode="NumericPages"></PAGERSTYLE></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 1px">
									<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif">
								</TD>
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
