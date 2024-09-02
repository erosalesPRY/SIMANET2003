<%@ Page language="c#" Codebehind="ConsultarNivelPAMC.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica.ConsultarNivelPAMC" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarNivelPAMC</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>		
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="left"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD align="left"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands" align="left"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPaginaActual">Inicio > Gestión Estrátegica >  Proyectos Apoyo a la Mejora de la Competitividad >  </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> CONVENIOS</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> CONSULTAR CONVENIO</asp:label><BR>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD align="left" bgColor="#f0f0f0" colSpan="3">
									<asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif" Visible="False"></asp:imagebutton>
									<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
										ToolTip="Eliminar Filtro.." Visible="False"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#f0f0f0" colSpan="3"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" RowPositionEnabled="False" RowHighlightColor="#E0E0E0"
										AllowPaging="True" PageSize="7" AutoGenerateColumns="False" ShowFooter="True" AllowSorting="True" Width="780px">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="Total:">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="nombre" SortExpression="nombre" HeaderText="CONVENIO">
												<HeaderStyle Width="80%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="avance" HeaderText="Avance %" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#f0f0f0" colSpan="3"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda">No exiten Registros</asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="3"></TD>
							</TR>
						</TABLE>
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="780" border="0">
							<TR>
								<TD bgColor="#335eb4">
									<asp:label id="lblTituloDocumentos" runat="server" CssClass="TituloPrincipalBlanco">DOCUMENTOS</asp:label></TD>
								<TD bgColor="#335eb4">
									<asp:label id="lblProyectos" runat="server" CssClass="TituloPrincipalBlanco">PROYECTOS</asp:label></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#f0f0f0">
									<cc1:datagridweb id="gridDocumentos" runat="server" CssClass="HeaderGrilla" Width="385px" AllowSorting="True"
										ShowFooter="True" AutoGenerateColumns="False" PageSize="7" RowHighlightColor="#E0E0E0" RowPositionEnabled="False"
										Height="100%">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="Total:">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="nombre" SortExpression="nombre" HeaderText="DOCUMENTOS">
												<HeaderStyle Width="80%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="ARCHIVO">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemTemplate>
													<asp:Image id="Img" runat="server" Height="18px"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><BR>
									<asp:label id="lblResultadoDocumentos" runat="server" CssClass="ResultadoBusqueda">No exiten Registros</asp:label></TD>
								<TD align="center" bgColor="#f0f0f0">
									<cc1:datagridweb id="gridProyectos" runat="server" CssClass="HeaderGrilla" Width="385px" AllowSorting="True"
										ShowFooter="True" AutoGenerateColumns="False" PageSize="7" RowHighlightColor="#E0E0E0" RowPositionEnabled="False"
										Height="100%">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="Total:">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="nombre" SortExpression="nombre" HeaderText="PROYECTOS">
												<HeaderStyle Width="80%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Archivo">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemTemplate>
													<asp:Image id="Img" runat="server" Height="18px"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb>
									<asp:label id="lblResultadoProyectos" runat="server" CssClass="ResultadoBusqueda">No exiten Registros</asp:label></TD>
							</TR>
							<TR>
								<TD align="left" bgColor="#f0f0f0"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hCodigo" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" size="1" name="Hidden3"
										runat="server"><INPUT id="hNombre" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" size="1" name="Hidden3"
										runat="server"></TD>
								<TD align="center" bgColor="#f0f0f0"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
