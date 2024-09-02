<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="ConsultaAcuerdoSesionDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio.ConsultaAcuerdoSesionDirectorio" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" onkeydown="return verificarBackspace()" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="Commands" vAlign="top"><asp:label id="Label1" runat="server" CssClass="RutaPagina">Inicio >Gestión de la Dirección ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Acuerdos de Directorio</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center">
						<table cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
							<TR>
								<TD align="left">
									<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD align="center" width="100%" colSpan="3">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
																src="../../imagenes/filtroPorSeleccion.JPG" style="CURSOR: hand">
															<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ToolTip="Eliminar Filtro.." ImageUrl="../../imagenes/filtroEliminar.GIF"></asp:imagebutton><IMG height="8" src="../../imagenes/spacer.gif" width="200">
															<asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Width="160px" AutoPostBack="True"></asp:dropdownlist></td>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnSituacion" runat="server" ImageUrl="../../imagenes/GridView.gif" ToolTip="Cambiar Situación"
																style="Z-INDEX: 0" Visible="False"></asp:imagebutton><IMG id="ibtnSesiones" title="Bitácora de Sesiones" style="VISIBILITY: hidden; CURSOR: hand"
																alt="" src="../../imagenes/nota.gif" runat="server"></TD>
													</tr>
												</table>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" ShowFooter="True" RowHighlightColor="#E0E0E0"
													AutoGenerateColumns="False" AllowPaging="True" Width="100%" AllowSorting="True">
													<AlternatingItemStyle CssClass="AlternateItemGrillaJustificado"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrillaJustificado"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO.">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NroAcuerdoSesionDirectorio" SortExpression="NroAcuerdoSesionDirectorio"
															HeaderText="NRO. ACUERDO">
															<HeaderStyle Width="11%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaAcuerdo" SortExpression="FechaAcuerdo" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="TEMA" SortExpression="TEMA" HeaderText="ASUNTO">
															<ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Situacion" SortExpression="Situacion" HeaderText="SITUACION">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label>
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f5f5f5" border="0">
													<TR>
														<TD class="TitFiltros" style="HEIGHT: 44px" bgColor="#f5f5f5"><P align="left">
																<asp:label id="lblSituacion" runat="server" CssClass="normal">Ultima Gestión:</asp:label></P>
														</TD>
														<TD class="combos" style="HEIGHT: 44px" bgColor="#f5f5f5">
															<asp:textbox id="txtAcuerdo" runat="server" CssClass="TextoAdicional" Width="725px" Height="70px"
																TextMode="MultiLine" ReadOnly="True"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
									<IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
										style="CURSOR: hand"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 9px" type="hidden" size="1" name="hCodigo"
										runat="server"> <INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
										runat="server">
								</TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
