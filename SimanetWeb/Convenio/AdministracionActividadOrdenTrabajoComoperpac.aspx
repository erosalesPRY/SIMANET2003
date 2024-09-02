<%@ Page language="c#" Codebehind="AdministracionActividadOrdenTrabajoComoperpac.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.AdministracionActividadOrdenTrabajoComoperpac" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
		<script language="javascript" type="text/javascript">

			function LlenarControlesWebFormNet(ptxtDocumentoAprovacion,ptxtObservaciones)
			{
				MostrarDatosEnCajaTexto('txtDocumentoAprovacion',ptxtDocumentoAprovacion);
				MostrarDatosEnCajaTexto('txtObservaciones',ptxtObservaciones);
				return;
			}
		
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td width="100%">
					<FORM id="Form1" method="post" runat="server">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR vAlign="baseline" align="left">
								<TD width="100%"><uc1:header id="Header1" runat="server"></uc1:header></TD>
							</TR>
							<tr>
								<TD vAlign="top" width="99%"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
							</tr>
							<TR>
								<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Producción >  Administrar Periodos Convenios COMPOPERPAC > Admini strar Orden de Trabajo ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> ADMINISTRAR ACTIVIDADES</asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 12px" align="center">
									<TABLE id="Table6" style="HEIGHT: 16px" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD>
												<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> ORDEN DE TRABAJO:</asp:label></TD>
										</TR>
									</TABLE>
									<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD bgColor="#f5f5f5">
												<asp:label id="lblActividad" runat="server" CssClass="normal">ACTIVIDAD:&nbsp;</asp:label>
												<asp:dropdownlist id="ddlbActividad" runat="server" CssClass="normal" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD align="right" bgColor="#f5f5f5">
												<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton>
												<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
									<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD align="center">
												<cc1:datagridweb id="dgActividad" runat="server" CssClass="HeaderGrilla" PageSize="7" AllowSorting="True"
													AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" Width="774px"
													ShowFooter="True">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
															<HeaderStyle Width="25px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="DESCRIPCION">
															<HeaderStyle Width="120px"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
															<ItemTemplate>
																<asp:HyperLink id="hlkId" runat="server">DECRIPCION</asp:HyperLink>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="NroValorizacion" SortExpression="NroValorizacion" HeaderText="VALORIZACION">
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="UnidadNaval" SortExpression="UnidadNaval" HeaderText="UNIDAD NAVAL">
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaInicio" SortExpression="FechaInicio" HeaderText="FECHA INICIO" DataFormatString="{0:dd-MM-yyyy}">
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="FechaTermino" SortExpression="FechaTermino" HeaderText="FECHA TERMINO"
															DataFormatString="{0:dd-MM-yyyy}">
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PorcAvanceFisico" SortExpression="PorcAvanceFisico" HeaderText="A.F ( % )"
															DataFormatString="{0:###,##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoAsignado" SortExpression="MontoAsignado" HeaderText="ASIGNADO NS"
															DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoEjecutado" SortExpression="MontoEjecutado" HeaderText="EJECUTADO NS"
															DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Observaciones" HeaderText="Observaciones"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="DocumentoAprovacion" SortExpression="DocumentoAprovacion"
															HeaderText="Documento de Aprobaci&#243;n">
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR>
											<TD align="center">
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
									</TABLE>
									<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD style="WIDTH: 378px"></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 378px">
												<asp:label id="lblDocumentoAprovacion" runat="server" CssClass="normal">DOCUMENTO DE APROVACION</asp:label></TD>
											<TD>
												<asp:label id="lblObservaciones" runat="server" CssClass="normal">OBSERVACIONES:</asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 378px">
												<asp:textbox id="txtDocumentoAprovacion" runat="server" CssClass="TextoAzul" Width="376px" ReadOnly="True"
													TextMode="MultiLine" Height="45px"></asp:textbox></TD>
											<TD>
												<asp:textbox id="txtObservaciones" runat="server" CssClass="TextoAzul" Width="100%" ReadOnly="True"
													TextMode="MultiLine" Height="45px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 378px"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif"></TD>
											<TD><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" runat="server"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
				</td>
			</tr>
		</table>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
