<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarDisposicionesDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio.ConsultarDisposicionesDirectorio" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
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
					<TD class="Commands" vAlign="top"><asp:label id="Label1" runat="server" CssClass="RutaPagina">Inicio >Gestión de la Dirección ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Disposiciones del Directorio</asp:label></TD>
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
															<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ToolTip="Eliminar Filtro.." ImageUrl="../../imagenes/filtroEliminar.GIF"></asp:imagebutton></td>
														<TD align="left" bgColor="#f0f0f0"></TD>
														<TD bgColor="#f0f0f0" align="right"></TD>
													</tr>
													<TR>
														<TD bgColor="#f0f0f0">
															<asp:label style="Z-INDEX: 0" id="Label2" runat="server" CssClass="TituloPrincipalAzul">Acuerdos Permanentes</asp:label></TD>
														<TD bgColor="#f0f0f0" align="left"></TD>
														<TD bgColor="#f0f0f0" align="right"></TD>
													</TR>
												</table>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" PageSize="7" ShowFooter="True"
													AllowSorting="True" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO.">
															<HeaderStyle Width="3%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NroSesion" SortExpression="NroSesion" HeaderText="NRO.SESION">
															<HeaderStyle Width="2%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaDisposicion" SortExpression="FechaDisposicion" HeaderText="FECHA"
															DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="12%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Solicitante" SortExpression="Solicitante" HeaderText="DISPUESTO POR">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Disposicion" SortExpression="Disposicion" HeaderText="DISPOSICION">
															<HeaderStyle Width="45%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="3%"></HeaderStyle>
															<ItemTemplate>
																<asp:ImageButton id="ibtnDisposicion" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label>
											</TD>
										</TR>
									</TABLE>
									<IMG style="Z-INDEX: 0" src="../../imagenes/spacer.gif" width="620" height="8">
								</TD>
							</TR>
							<TR>
								<TD align="left"><IMG style="Z-INDEX: 0" src="../../imagenes/spacer.gif" width="620" height="8"></TD>
							</TR>
							<TR>
								<TD align="left">
									<asp:label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="TituloPrincipalAzul">Disposiciones Generales</asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="2" align="left">
									<P align="center">
										<asp:label style="Z-INDEX: 0" id="lblSituacion" runat="server" CssClass="normal">Situación :</asp:label>
										<asp:dropdownlist style="Z-INDEX: 0" id="ddlbSituacion" runat="server" CssClass="normaldetalle" AutoPostBack="True"
											Width="160px"></asp:dropdownlist></P>
								</TD>
							</TR>
							<TR>
								<TD align="left">
									<cc1:datagridweb style="Z-INDEX: 0" id="gridGenerales" runat="server" CssClass="HeaderGrilla" Width="100%"
										RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True"
										PageSize="7">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO.">
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroSesion" SortExpression="NroSesion" HeaderText="NRO.SESION">
												<HeaderStyle Width="2%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FechaDisposicion" SortExpression="FechaDisposicion" HeaderText="FECHA"
												DataFormatString="{0:dd-MM-yyyy}">
												<HeaderStyle Width="12%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Solicitante" SortExpression="Solicitante" HeaderText="DISPUESTO POR">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Disposicion" SortExpression="Disposicion" HeaderText="DISPOSICION">
												<HeaderStyle Width="45%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemTemplate>
													<asp:ImageButton id="ibtnDisposicion" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="left">
									<IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
										style="Z-INDEX: 0; CURSOR: hand"><INPUT id="hCodigo" style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 9px" type="hidden" size="1"
										name="hCodigo" runat="server"></TD>
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
