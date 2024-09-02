<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministracionValorizacionOrdenTrabajoConvenio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.AdministracionValorizacionOrdenTrabajoConvenio" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
		<script language="javascript" type="text/Jscript">
		function AbrirVentaBusqueda()
		{
			var Datos=new Array();
			Datos=window.showModalDialog("BuquedaValorizacionConvenioSimaMgp.htm","","dialogHeight: 100px; dialogWidth: 300px; dialogTop: 150px; dialogLeft: 150px; edge: Raised; center: Yes; help: Yes; resizable: No; status: Yes;");
			if(Datos!=null){ alert(Datos[0]);}else{ alert('No Hay Valorizacion');}
		}
		</script>
	</HEAD>
	<body style="OVERFLOW-Y: scroll; OVERFLOW-X: hidden; WIDTH: 100%" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="baseline" width="100%">
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<tr>
					<TD vAlign="top" align="left" width="100%"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Convenio>Proyecto ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Valorizaciones</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="770" align="center" border="0">
							<TR>
								<td>
									<table id="Table6" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<tr>
											<TD class="TituloPrincipal" style="WIDTH: 451px" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal" DESIGNTIMEDRAGDROP="30"> CONVENIO SIMA - MGP...</asp:label><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 15px" type="hidden" size="1" name="hCodigo"
													runat="server"><INPUT id="hNroValorizacion" style="WIDTH: 16px; HEIGHT: 15px" type="hidden" size="1" name="hCodigo"
													runat="server"></TD>
											<td align="right"></td>
										</tr>
									</table>
								</td>
							</TR>
							<TR>
								<TD align="center" width="100%">
									<TABLE class="tabla" id="Table5" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f5f5f5"
										border="0">
										<tr>
											<td colSpan="6"><asp:label id="lblProyectoDescripcion" runat="server" CssClass="normal">PROYECTO:</asp:label></td>
										</tr>
										<tr>
											<td colSpan="6"><asp:textbox id="txtProyectoDescripcion" runat="server" CssClass="normal" ReadOnly="True" Width="100%"
													TextMode="MultiLine"></asp:textbox></td>
										</tr>
										<tr>
											<td bgColor="#ffffff" colSpan="6"><asp:label id="lblTituloSecundario" runat="server" CssClass="TituloSecundario"> VALORIZACIONES:&nbsp;</asp:label><asp:button id="btnBuscarValorizacion" runat="server" CssClass="normal" Width="110px" Text="Buscar Valorización"></asp:button></td>
										</tr>
										<TR>
											<TD width="288" vAlign="top" style="WIDTH: 288px"><asp:label id="lblCentroOperatico" runat="server" CssClass="normal" Width="128px">CENTRO DE OPERACION:</asp:label><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normal" Width="150px"></asp:dropdownlist></TD>
											<TD><asp:label id="lblEstado" runat="server" CssClass="normal">ESTADO:&nbsp;</asp:label><asp:dropdownlist id="ddlbEstado" runat="server" CssClass="normal" AutoPostBack="True"></asp:dropdownlist><asp:button id="btnConsultar" runat="server" CssClass="normal" Text="Consultar"></asp:button></TD>
											<TD style="WIDTH: 23px" align="left"></TD>
											<TD></TD>
											<TD align="right"></TD>
											<TD align="right"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif" Visible="False"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center">
									<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD vAlign="top" align="center" width="100%"><cc1:datagridweb id="dgOrdenTrabajo" runat="server" CssClass="HeaderGrilla" Width="100%" PageSize="8"
													RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True">
													<SelectedItemStyle BackColor="#66FFFF"></SelectedItemStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="NRO" FooterText="TOTAL:">
															<HeaderStyle Width="30px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<ItemTemplate>
																<asp:HyperLink id="hlkId" runat="server">Nro</asp:HyperLink>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="NroValorizacion" SortExpression="NroValorizacion" HeaderText="VALORIZACION">
															<HeaderStyle Width="80px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NroOrdenTrabajo" SortExpression="NroOrdenTrabajo" HeaderText="TRABAJO">
															<HeaderStyle Width="80px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Alias" SortExpression="Alias" HeaderText="ALIAS">
															<HeaderStyle Width="80px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoPrecioVentaSoles" SortExpression="MontoPrecioVentaSoles" HeaderText="PRESUPUESTO NS"
															DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="110px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="UnidadNaval" SortExpression="UnidadNaval" HeaderText="UNIDAD NAVAL">
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Estado" SortExpression="Estado" HeaderText="ESTADO">
															<HeaderStyle Width="90px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PorcAvanceFisico" SortExpression="PorcAvanceFisico" HeaderText="% ACT"
															DataFormatString="{0:##0.00}">
															<HeaderStyle Width="80px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<TR align="center">
											<TD><IMG style="WIDTH: 160px" height="6" src="../imagenes/spacer.gif" width="160">
											</TD>
										</TR>
										<TR>
											<TD>
												<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td style="WIDTH: 319px" align="right"></td>
														<TD style="WIDTH: 197px" align="right"></TD>
														<TD align="left"></TD>
													</tr>
													<TR>
														<TD style="WIDTH: 319px"><asp:label id="lblDescripcion" runat="server" CssClass="normal">DESCRIPCION:</asp:label></TD>
														<TD style="WIDTH: 197px"></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD colSpan="3"><asp:textbox id="txtDescripcion" runat="server" CssClass="TextoAzul" ReadOnly="True" Width="100%"
																TextMode="MultiLine" Height="60px"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
						<IMG height="8" src="../imagenes/spacer.gif" width="120"></TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
