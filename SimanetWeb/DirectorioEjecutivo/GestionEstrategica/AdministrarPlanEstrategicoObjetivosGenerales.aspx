<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="AdministrarPlanEstrategicoObjetivosGenerales.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica.AdministrarPlanEstrategicoObjetivosGenerales" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarPlanEstrategicoObjetivosGenerales</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
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
					<TD class="Commands">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Estratégica > Plan Estratégico >  Despliegue de Plan Estratégico > Administrar Objetivos Generales</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<asp:Label id="Label1" runat="server" CssClass="TituloPrincipalAzul">DESPLIEGUE DEL PLAN ESTRATEGICO</asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<asp:Label id="lblTitulo" runat="server" CssClass="TituloPrincipalAzul">OBJETIVOS GENERALES</asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD align="left" style="WIDTH: 496px; HEIGHT: 3px">
									<asp:label id="lblPeriodo" runat="server" CssClass="normal">PERIODO:</asp:label>
									<asp:dropdownlist id="dllVisibilidad" runat="server" CssClass="NormalDetalle" AutoPostBack="True"
										Width="100px"></asp:dropdownlist>
								</TD>
								<TD style="HEIGHT: 3px" align="right">
									<asp:ImageButton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:ImageButton>
									<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2" style="HEIGHT: 12px"><ALTERNATINGITEMSTYLE CssClass="AlternateItemGrillaJustificado">
										<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="100%" RowPositionEnabled="False"
											RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True"
											ShowFooter="True" PageSize="7">
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
											<AlternatingItemStyle CssClass="AlternateItemGrillaJustificado"></AlternatingItemStyle>
											<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla"></FooterStyle>
											<ItemStyle CssClass="ItemGrillaJustificado"></ItemStyle>
											<Columns>
												<asp:BoundColumn HeaderText="NRO">
													<HeaderStyle Width="2%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn HeaderText="OG">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCION">
													<ItemStyle VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="TIPOOBJETIVO" SortExpression="TIPO" HeaderText="TIPO">
													<HeaderStyle Width="20%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left" VerticalAlign="Top"></FooterStyle>
												</asp:BoundColumn>
											</Columns>
											<HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla"></HeaderStyle>
										</cc1:datagridweb>
										<BR>
										<asp:Label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:Label>
									</ALTERNATINGITEMSTYLE><ITEMSTYLE CssClass="ItemGrillaJustificado"></ITEMSTYLE><HEADERSTYLE CssClass="HeaderGrilla" HorizontalAlign="Center"></HEADERSTYLE><FOOTERSTYLE CssClass="FooterGrilla" HorizontalAlign="Right"></FOOTERSTYLE><COLUMNS>
										<ASP:BOUNDCOLUMN HeaderText="NRO" DataField="IDOGENERALES">
											<HEADERSTYLE Width="2%"></HEADERSTYLE>
											<ITEMSTYLE HorizontalAlign="Center" VerticalAlign="Middle"></ITEMSTYLE>
											<FOOTERSTYLE HorizontalAlign="Left"></FOOTERSTYLE>
										</ASP:BOUNDCOLUMN>
										<ASP:BOUNDCOLUMN HeaderText="OG" DataField="OG">
											<HEADERSTYLE Width="10%"></HEADERSTYLE>
											<ITEMSTYLE HorizontalAlign="Center" VerticalAlign="Middle"></ITEMSTYLE>
										</ASP:BOUNDCOLUMN>
										<ASP:BOUNDCOLUMN HeaderText="DESCRIPCION" DataField="DESCRIPCION" SortExpression="DESCRIPCION">
											<ITEMSTYLE VerticalAlign="Middle"></ITEMSTYLE>
											<FOOTERSTYLE HorizontalAlign="Left"></FOOTERSTYLE>
										</ASP:BOUNDCOLUMN>
										<ASP:BOUNDCOLUMN HeaderText="TIPO" DataField="TIPOOG">
											<HEADERSTYLE Width="25%"></HEADERSTYLE>
											<ITEMSTYLE HorizontalAlign="Center" VerticalAlign="Middle"></ITEMSTYLE>
											<FOOTERSTYLE HorizontalAlign="Left" VerticalAlign="Top"></FOOTERSTYLE>
										</ASP:BOUNDCOLUMN>
									</COLUMNS><PAGERSTYLE CssClass="PagerGrilla" Mode="NumericPages"></PAGERSTYLE></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 496px"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hcodigo" type="hidden" size="1" name="hcodigo" runat="server"></TD>
								<TD></TD>
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
