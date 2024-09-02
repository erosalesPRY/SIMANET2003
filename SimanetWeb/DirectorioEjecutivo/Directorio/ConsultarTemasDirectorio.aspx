<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarTemasDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio.ConsultaTemasDirectorio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="Commands" vAlign="top"><asp:label id="Label1" runat="server" CssClass="RutaPagina">Inicio >Gestión de la Dirección ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Obligaciones del Directorio</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center">
						<table cellSpacing="0" cellPadding="0" width="770" align="center" border="0">
							<TR>
								<TD align="left">
									<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD align="center" width="100%" colSpan="3">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
																src="../../imagenes/filtroPorSeleccion.JPG" style="CURSOR: hand">
															<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ToolTip="Eliminar Filtro.." ImageUrl="../../imagenes/filtroEliminar.GIF"></asp:imagebutton><IMG height="8" src="../../imagenes/spacer.gif" width="610"></td>
														<td bgColor="#f0f0f0"><IMG id="ibtnSesiones" title="Bitácora de Sesiones" style="CURSOR: hand" alt="" src="../../imagenes/nota.gif"
																runat="server"></td>
													</tr>
												</table>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" PageSize="12" ShowFooter="True"
													AllowSorting="True" Width="100%" AllowPaging="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO.">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Sigla1" SortExpression="Sigla1" HeaderText="C.O.">
															<HeaderStyle Width="3%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Fuente" SortExpression="Fuente" HeaderText="Obligaci&#243;n">
															<HeaderStyle Width="30%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Refe" SortExpression="Refe" HeaderText="Referencia">
															<HeaderStyle Width="30%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NroAcuerdo" SortExpression="NroAcuerdo" HeaderText="NRO. ACUERDO">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaAcuerdo" SortExpression="FechaAcuerdo" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn Visible="False">
															<HeaderTemplate>
																<TABLE class="HeaderGrilla" id="Table3" cellSpacing="0" cellPadding="1" width="100%" border="1">
																	<TR>
																		<TD align="center" colSpan="2">
																			<asp:Label id="Label2" runat="server">Ultima Aprobacion</asp:Label></TD>
																	</TR>
																	<TR>
																		<TD>
																			<asp:Label id="Label3" runat="server">Acuerdo</asp:Label></TD>
																		<TD>
																			<asp:Label id="Label4" runat="server">Fecha</asp:Label></TD>
																	</TR>
																</TABLE>
															</HeaderTemplate>
															<ItemTemplate>
																<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD align="center" width="50%">
																			<asp:Label id="lblAcuerdo" runat="server" CssClass="ObjetoTemplate" Width="70px"></asp:Label></TD>
																		<TD align="center" width="50%">
																			<asp:Label id="lblFecha" runat="server" CssClass="ObjetoTemplate" Width="100%" BackColor="Transparent"></asp:Label></TD>
																	</TR>
																</TABLE>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn Visible="False">
															<HeaderStyle Width="0%"></HeaderStyle>
															<ItemTemplate>
																<asp:ImageButton id="ibtnDialogo" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="0%"></HeaderStyle>
															<ItemTemplate>
																<asp:Image id="imgDoc" runat="server" ImageUrl="../../imagenes/ley1.gif" Height="18px"></asp:Image>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
										</TR>
									</TABLE>
									<IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
										style="CURSOR: hand"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 9px" type="hidden" size="1" name="hCodigo"
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
