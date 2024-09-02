<%@ Page language="c#" Codebehind="ConsultarPlanEstrategicoAccionesTomadas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica.ConsultarPlanEstrategicoAccionesTomadas" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarPlanEstrategicoAccionesTomadas</title>
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
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Estratégica > Plan Estratégico >  Despliegue de Plan Estratégico > Acciones Tomadas</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<P align="center"><asp:label id="lblTituloPrincipal" runat="server" CssClass="TituloPrincipalAzul">DESPLIEGUE DEL PLAN ESTRATEGICO</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalAzul">ACTIVIDAD</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD>
									<P align="center">
										<TABLE id="Table4" borderColor="#ffffff" cellSpacing="0" cellPadding="1" width="100%" bgColor="#f0f0f0"
											border="2">
											<TR>
												<TD style="WIDTH: 62px" bgColor="#f0f0f0">
													<asp:label id="lblCodigoObjGeneral" runat="server" CssClass="normaldetalle" Width="70px"></asp:label></TD>
												<TD bgColor="#f0f0f0">
													<asp:label id="lblContenidoObjGeneral" runat="server" CssClass="NormalDetalle" Height="2px"
														Width="100%"></asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 62px" bgColor="#f0f0f0">
													<asp:label id="lblCodigoOE" runat="server" CssClass="normaldetalle" Width="70px"></asp:label></TD>
												<TD bgColor="#f0f0f0">
													<asp:label id="lblContenidoOE" runat="server" CssClass="NormalDetalle" Height="2px" Width="100%"></asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 62px" bgColor="#f0f0f0">
													<asp:label id="lblCodigoAccion" runat="server" CssClass="normaldetalle" Width="70px"></asp:label></TD>
												<TD bgColor="#f0f0f0">
													<asp:label id="lblContenidoAccion" runat="server" CssClass="NormalDetalle" Height="2px" Width="100%"></asp:label></TD>
											</TR>
										</TABLE>
									</P>
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 9px" align="left">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0" width="100%">
										<TR>
											<TD>
												<asp:imagebutton id="ibtnFiltro" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../../imagenes/filtroPorSeleccion.JPG">
												<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD align="right">
												<asp:imagebutton id="ibtnBitacora" runat="server" ImageUrl="../../imagenes/Bitacora.jpg"></asp:imagebutton></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="100%" RowPositionEnabled="False"
										RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True"
										ShowFooter="True" PageSize="7">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="ACTIVIDAD">
												<HeaderStyle Width="8%"></HeaderStyle>
												<ItemStyle VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCION">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="LIDER" SortExpression="LIDER" HeaderText="RESPONSABLE">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="A&#209;O" SortExpression="A&#209;O" HeaderText="A&#209;O">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="INVERSION" SortExpression="INVERSION" HeaderText="INVERSION" DataFormatString="{0:###,##0.00}">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="AF" SortExpression="AF" HeaderText="AF">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 12px">
									<P align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif">&nbsp;<INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" runat="server"><INPUT id="hDescripcionActividad" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
										name="Hidden1" runat="server"><INPUT id="hCodigoActividad" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
										runat="server"> <INPUT id="hNro" type="hidden" size="1" runat="server">
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
