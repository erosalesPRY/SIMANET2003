<%@ Page language="c#" Codebehind="ConsultarProyectos_PorProveedor.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Proyectos.ConsultarProyectos_PorProveedor" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" onunload="SubirHistorial();"
		onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td bgColor="#eff7fa" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label style="Z-INDEX: 0" id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Proyectos ></asp:label><asp:label style="Z-INDEX: 0" id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Proyectos Por Proveedor</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" class="normal" border="0" cellSpacing="0" cellPadding="0" width="100%"
							DESIGNTIMEDRAGDROP="26">
							<TR>
								<TD width="100%" colSpan="3" align="center">
									<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD>
												<TABLE style="Z-INDEX: 0" id="Table9" border="0" cellSpacing="0" cellPadding="0" width="100%">
													<TR>
														<TD width="200"></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD width="200">&nbsp;</TD>
														<TD>
															<asp:label style="Z-INDEX: 0" id="Label8" runat="server" CssClass="normaldetalle" Width="80px"
																Font-Bold="True"> Razón Social:</asp:label>
															<asp:TextBox id="txtProveedor" runat="server" Width="300px"></asp:TextBox>
															<asp:imagebutton style="Z-INDEX: 0" id="btnBuscar" runat="server" ImageUrl="../../imagenes/bt_Buscar.GIF"
																Height="22px" Width="80px"></asp:imagebutton>
															<asp:imagebutton style="Z-INDEX: 0" id="imgExportar" runat="server" Width="80px" Height="22px" ImageUrl="../../imagenes/bt_exportar.GIF"
																Visible="False"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
											<TD></TD>
											<TD></TD>
											<TD align="right"></TD>
											<TD width="4" align="right"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" PageSize="15" ShowFooter="True" Width="100%" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle Font-Bold="True" CssClass="footerGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="COD_PRV" SortExpression="COD_PRV" HeaderText="PROVEEDOR">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RAZON_SOCIAL" SortExpression="RAZON_SOCIAL" HeaderText="RAZON SOCIAL">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ORDEN_SERVICIO" SortExpression="ORDEN_SERVICIO" HeaderText="O/S">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="EST_OSE" SortExpression="EST_OSE" HeaderText="ESTADO O/S">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="OT" SortExpression="OT" HeaderText="OT">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="COD_SRV" SortExpression="COD_SRV" HeaderText="COD. SERVICIO">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DES_SER" SortExpression="DES_SER" HeaderText="SERVICIO">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IMPORTE_OSE" SortExpression="IMPORTE_OSE" HeaderText="IMPORTE" DataFormatString="{0:###,##0.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="COD_MON_OSE" SortExpression="COD_MON_OSE" HeaderText="MONEDA">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="TIP_DOC_PAG" SortExpression="TIP_DOC_PAG" HeaderText="DOC.">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NRO_DOC_PAG" SortExpression="NRO_DOC_PAG" HeaderText="NRO. DOC">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="COD_MON_DOC_PAG" SortExpression="COD_MON_DOC_PAG" HeaderText="MONEDA">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="EMS_DOC_PAG" SortExpression="EMS_DOC_PAG" HeaderText="FEC.EMIS." DataFormatString="{0:dd-MM-yyyy}">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="EST_DOC_PAG" SortExpression="EST_DOC_PAG" HeaderText="ESTADO">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FEC_RCP" SortExpression="FEC_RCP" HeaderText="FEC.RECEPC." DataFormatString="{0:dd-MM-yyyy}">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table6" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD align="left"><IMG style="CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
						<INPUT style="Z-INDEX: 0; WIDTH: 15px; HEIGHT: 22px" id="hGridPagina" value="0" size="1"
							type="hidden" name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 15px; HEIGHT: 22px" id="hGridPaginaSort" size="1" type="hidden"
							name="hOrdenGrilla" runat="server">
					</TD>
				</TR>
				<tr>
					<td vAlign="top" width="592"></td>
				</tr>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
