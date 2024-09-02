<%@ Page language="c#" Codebehind="ConsultarRegistroProyectoCN.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.ConsultarRegistroProyectoCN" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Consulta de Proyectos Construccion Naval</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal">CONSULTAR REGISTRO DE PROYECTOS CN</asp:label>
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD align="center">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD style="WIDTH: 231px" bgColor="#f0f0f0"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../../imagenes/filtroPorSeleccion.JPG">
												<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD align="right" bgColor="#f0f0f0"><asp:imagebutton id="ibtnPlaca" runat="server" ImageUrl="../../imagenes/btnPlaca.gif" CausesValidation="False"></asp:imagebutton><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" PageSize="15" Width="780px" AllowPaging="True"
										AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False"
										ShowFooter="True">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="Total:">
												<HeaderStyle Wrap="False" Width="5px"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
												<FooterStyle Wrap="False"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="idHistorico" SortExpression="idHistorico" HeaderText="ID PROYECTO">
												<HeaderStyle Wrap="False" Width="78px"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
												<FooterStyle Wrap="False"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Nombre" SortExpression="Nombre" HeaderText="NOMBRE">
												<HeaderStyle Wrap="False" Width="220px"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
												<FooterStyle Wrap="False"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="LINEAPRODUCTO" SortExpression="LINEAPRODUCTO" HeaderText="LINEA DE PRODUCTO">
												<HeaderStyle Wrap="False" Width="78px"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
												<FooterStyle Wrap="False"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="BUQUE" SortExpression="BUQUE" HeaderText="TIPO DE PRODUCTO">
												<HeaderStyle Width="80px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="razonsocial" SortExpression="razonsocial" HeaderText="CLIENTE">
												<HeaderStyle Wrap="False" Width="210px"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
												<FooterStyle Wrap="False"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="fechafirmaacuerdo" SortExpression="fechafirmaacuerdo"
												HeaderText="FECHA ACUERDO" DataFormatString="{0:dd-MM-yyyy}">
												<HeaderStyle Wrap="False" Width="78px"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
												<FooterStyle Wrap="False"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CO" SortExpression="CO" HeaderText="C.O">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 12px" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="Hidden1" style="WIDTH: 16px; HEIGHT: 14px" type="hidden" size="1" name="Hidden1"
										runat="server"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 16px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"> <INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 14px" type="hidden" size="1" name="hCodigo"
										runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 16px; HEIGHT: 14px" type="hidden" size="1" name="hOrdenGrilla"
										runat="server"><INPUT id="hPagina" style="WIDTH: 16px; HEIGHT: 14px" type="hidden" size="1" name="hOrdenGrilla"
										runat="server"></TD>
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
