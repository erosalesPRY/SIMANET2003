<%@ Page language="c#" Codebehind="ConsultarActividadesConvenio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.ConsultarActividadesConvenio" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<! Begin Smooth Blend Pages IN and OUT -->
		<META content="BlendTrans(Duration=0.4)" http-equiv="Page-Enter">
		<META content="BlendTrans(Duration=0.4)" http-equiv="Site-Exit">
		<! End Smooth Blend Pages IN and OUT -->
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();" style="OVERFLOW-X: hidden; OVERFLOW-Y: scroll; WIDTH: 100%">
		<FORM id="Form2" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<TD>
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</tr>
				<tr>
					<TD vAlign="top"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<tr>
					<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Convenio ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Actividades del Convenio > Detalle Ordenes de Trabajo</asp:label></TD>
				</tr>
				<tr>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="720" border="0">
							<TR>
								<TD align="center" width="100%">
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD bgColor="#f5f5f5">
												<asp:imagebutton id="ibtnFiltro" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="/SimanetWeb/imagenes/filtroporseleccion.jpg">
												<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="/SimanetWeb/imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD bgColor="#f5f5f5"></TD>
											<TD bgColor="#f5f5f5">&nbsp;</TD>
											<TD align="right" bgColor="#f5f5f5"><asp:imagebutton id="ibtnExportar" runat="server" CausesValidation="False" ImageUrl="../imagenes/bt_exportar.GIF"
													Visible="False" ToolTip="Exportar Archivo a Excel"></asp:imagebutton></TD>
											<TD align="right" width="4"><IMG height="22" src="../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" PageSize="9" ShowFooter="True" Width="100%" RowPositionEnabled="False"
										RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True"
										CssClass="HeaderGrilla">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="Act" SortExpression="ACT" HeaderText="ACT"></asp:BoundColumn>
											<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCION" FooterText="TOTAL:">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="VAL" SortExpression="VAL" HeaderText="VAL">
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="OT" SortExpression="OT" HeaderText="OT">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RN" SortExpression="RN" HeaderText="RN"></asp:BoundColumn>
											<asp:BoundColumn DataField="LN" SortExpression="LN" HeaderText="LN"></asp:BoundColumn>
											<asp:BoundColumn DataField="JEP" SortExpression="JEP" HeaderText="JEP"></asp:BoundColumn>
											<asp:BoundColumn DataField="UNIDAD" SortExpression="UNIDAD" HeaderText="UNIDAD"></asp:BoundColumn>
											<asp:BoundColumn DataField="APROBADO" SortExpression="APROBADO" HeaderText="APROBADO" DataFormatString="{0:# ### ### ##0.00}">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="F_INICIO" SortExpression="F_INICIO" HeaderText="F_INICIO"></asp:BoundColumn>
											<asp:BoundColumn DataField="EJECUTADO" SortExpression="EJECUTADO" HeaderText="EJECUTADO" DataFormatString="{0:# ### ### ##0.00}">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="EN PROCESO" SortExpression="EN PROCESO" HeaderText="EN PROCESO" DataFormatString="{0:# ### ### ##0.00}">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="AUTORIZADO" SortExpression="AUTORIZADO" HeaderText="AUTORIZADO"></asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<tr>
								<td width="100%">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="49%"><asp:label id="lblDescripcion" runat="server" CssClass="normal">DESCRIPCION:</asp:label></TD>
											<td width="2%"></td>
											<td width="49%"><asp:label id="lblObservaciones" runat="server" CssClass="normal">OBSERVACIONES:</asp:label></td>
										</TR>
										<TR>
											<TD width="49%"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="100%" TextMode="MultiLine"
													Height="60px"></asp:textbox></TD>
											<td width="2%"></td>
											<td width="49%"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="100%" TextMode="MultiLine"
													Height="60px"></asp:textbox></td>
										</TR>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td height="6" align="center"><IMG style="WIDTH: 100px" height="6" src="../imagenes/spacer.gif" width="100"></td>
							</tr>
							<tr>
								<td><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif"></td>
							</tr>
						</TABLE>
					</TD>
				</tr>
				<TR>
					<TD align="center"></TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
