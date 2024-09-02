<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarUnidadesSubmarinas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.AdministrarUnidadesSubmarinas" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="left" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Administración Unidades de Apoyo> Administración Periodos ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración Proyectos</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 485px" vAlign="top" align="center" width="100%">
						<TABLE id="Table3" style="WIDTH: 723px; HEIGHT: 32px" cellSpacing="1" cellPadding="1" width="723"
							border="0">
							<TR>
								<TD style="HEIGHT: 17px" align="center"><asp:label id="lblTituloSecundatio" runat="server" CssClass="TituloSecundario">LISTA DE PROYECTOS  - MONTOS EN NUEVOS SOLES</asp:label><BR>
									<asp:label id="lblTitulo" runat="server" CssClass="TituloSecundario"></asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 7px" align="right" bgColor="#f5f5f5"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif" CausesValidation="False"></asp:imagebutton><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD align="center"><cc1:datagridweb id="grid" runat="server" CssClass="HearderGrilla" PageSize="5" ShowFooter="True"
										RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True"
										Width="720px">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle Height="10px" CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla" VerticalAlign="Bottom"></FooterStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="NRO" FooterText="TOTAL:">
												<HeaderStyle Width="25px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Center" VerticalAlign="Bottom"></FooterStyle>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="IDPROYECTOSUBMARINO" SortExpression="IDPROYECTOSUBMARINO"
												HeaderText="IDPROYECTOSUBMARINO"></asp:BoundColumn>
											<asp:BoundColumn DataField="Nombre" SortExpression="Nombre" HeaderText="PROYECTO">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoAsignado" SortExpression="MontoAsignado" HeaderText="ASIGNADO" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="100px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoAprobado" SortExpression="MontoAprobado" HeaderText="APROBADO" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="100px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoEjecutado" SortExpression="MontoEjecutado" HeaderText="EJECUTADO"
												DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="100px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoEnEjecucion" SortExpression="MontoEnEjecucion" HeaderText="EN EJECUCION"
												DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="100px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoComprometido" SortExpression="MontoComprometido" HeaderText="COMPROMETIDO"
												DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="100px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoSaldo" SortExpression="MontoSaldo" HeaderText="SALDO " DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="100px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" ForeColor="#FFFFFF" BackColor="#335EB4" CssClass="PagerGrilla"
											Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda">lblResultado</asp:label></TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="Label1" runat="server" CssClass="TituloSecundario">FONDOS - MONTOS EN NUEVOS SOLES</asp:label></TD>
							</TR>
							<TR>
								<TD align="right" bgColor="#f5f5f5"><asp:imagebutton id="ibtnAgregarFondo" runat="server" ImageUrl="../imagenes/bt_agregar.gif" CausesValidation="False"></asp:imagebutton><asp:imagebutton id="ibtnEliminarFondo" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD align="center"><cc1:datagridweb id="gridAsignado" runat="server" CssClass="HearderGrilla" PageSize="5" ShowFooter="True"
										RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True"
										Width="720px">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle Height="10px" CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla" VerticalAlign="Bottom"></FooterStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="NRO" FooterText="TOTAL:">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Center" VerticalAlign="Bottom"></FooterStyle>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="IDPROYECTOSUBMARINO" SortExpression="IDPROYECTOSUBMARINO"
												HeaderText="IDPROYECTOSUBMARINO"></asp:BoundColumn>
											<asp:BoundColumn DataField="Nombre" HeaderText="FONDOS">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoAsignado" HeaderText="MONTO" DataFormatString="{0:# ### ### ##0.00}">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" ForeColor="#FFFFFF" BackColor="#335EB4" CssClass="PagerGrilla"
											Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultadoAsignado" runat="server" CssClass="ResultadoBusqueda">lblResultado</asp:label></TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="lblFontoPorAsignar" runat="server" CssClass="normal">FONDO POR ASIGNAR:&nbsp;</asp:label><asp:label id="lblMontoFondoPorAsignar" runat="server" CssClass="TextoAzulNegrita" Width="80px">0&nbsp;</asp:label></TD>
							</TR>
							<TR>
								<TD align="left" bgColor="#f5f5f5">
									<TABLE id="Table5" style="WIDTH: 725px; HEIGHT: 22px" cellSpacing="1" cellPadding="1" width="725"
										border="0">
										<TR>
											<TD bgColor="#f5f5f5"><asp:label id="lblDescripcion" runat="server" CssClass="normal">DESCRIPCION:</asp:label></TD>
											<TD bgColor="#f5f5f5"><asp:label id="lblObservaciones" runat="server" CssClass="normal">OBSERVACIONES:</asp:label></TD>
										</TR>
										<TR>
											<TD><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="355px" Height="50px"
													TextMode="MultiLine"></asp:textbox></TD>
											<TD><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="355px" Height="50px"
													TextMode="MultiLine"></asp:textbox></TD>
										</TR>
									</TABLE>
									<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif"><INPUT id="hIndicePaginaGridAsignado" style="WIDTH: 20px; HEIGHT: 16px" type="hidden" size="1"
										runat="server"><INPUT id="hColumnaOrdenamientoGridAsignado" style="WIDTH: 20px; HEIGHT: 16px" type="hidden"
										size="1" runat="server"><INPUT id="hCodigo" style="WIDTH: 20px; HEIGHT: 16px" type="hidden" size="1" name="hCodigo"
										runat="server"><INPUT id="hColumnaOrdenamientoGrid" style="WIDTH: 20px; HEIGHT: 16px" type="hidden" size="1"
										runat="server"><INPUT id="hIndicePaginaGrid" style="WIDTH: 20px; HEIGHT: 16px" type="hidden" size="1"
										name="Hidden1" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			</TD></TR></TABLE></form>
		<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</BODY>
</HTML>
