<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarPlanEstrategicoAccion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica.ConsultarPlanEstrategicoAccion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarPlanEstrategicoAccion</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Estratégica > Plan Estratégico >  Despliegue de Plan Estratégico > Accion</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<P align="center"><asp:label id="lblTituloPrincipal" runat="server" CssClass="TituloPrincipalAzul">DESPLIEGUE DEL PLAN ESTRATEGICO</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalAzul">ACCION</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table6" borderColor="#ffffff" cellSpacing="0" cellPadding="1" width="100%" bgColor="#f0f0f0"
							border="2">
							<TR>
								<TD style="WIDTH: 19px" bgColor="#f0f0f0">
									<asp:label id="lblCodigoObjGeneral" runat="server" CssClass="normaldetalle" Width="70px"></asp:label></TD>
								<TD bgColor="#f0f0f0">
									<asp:label id="lblContenidoObjGeneral" runat="server" CssClass="NormalDetalle" Width="100%"
										Height="2px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 19px" bgColor="#f0f0f0">
									<asp:label id="lblCodigoEspecificos" runat="server" CssClass="normaldetalle" Width="70px"></asp:label></TD>
								<TD bgColor="#f0f0f0">
									<asp:label id="lblContenidoEspecificos" runat="server" CssClass="NormalDetalle" Width="100%"
										Height="2px"></asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD style="HEIGHT: 9px"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 9px">
									<asp:imagebutton id="ibtnFiltro" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
										src="../../imagenes/filtroPorSeleccion.JPG">
									<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
										ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD>
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
											<asp:BoundColumn HeaderText="CODIGO ACCION">
												<HeaderStyle Width="8%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCION">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="LIDER" SortExpression="LIDER" HeaderText="RESPONSABLE">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="AF" SortExpression="AF" HeaderText="AF">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="INVERSION" SortExpression="INVERSION" HeaderText="INVERSION">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD>
									<P align="center">
										<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
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
