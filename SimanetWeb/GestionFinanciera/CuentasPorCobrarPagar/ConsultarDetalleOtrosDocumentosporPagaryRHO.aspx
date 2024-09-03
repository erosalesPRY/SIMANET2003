<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarDetalleOtrosDocumentosporPagaryRHO.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.ConsultarDetalleOtrosDocumentosporPagaryRHO" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarDetalleOtrosDocumentosporPagaryRHO</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" bottomMargin="0"
		leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" style="HEIGHT: 19px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Documentos por Pagar</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="782" align="center" border="0">
								<TR>
									<TD style="HEIGHT: 16px"></TD>
									<TD>
										<TABLE id="Table5" style="HEIGHT: 37px" cellSpacing="1" cellPadding="1" width="100%" align="left"
											bgColor="#f5f5f5" border="0">
											<TR>
												<TD width="162" style="WIDTH: 162px">
													<asp:Label id="Label4" runat="server" CssClass="TextoNegroNegrita">CONCEPTO :</asp:Label></TD>
												<TD width="67" colSpan="4" style="WIDTH: 67px">
													<asp:Label id="lblConcepto" runat="server" CssClass="TextoNegroNegrita" Width="644px">Label</asp:Label></TD>
												<TD style="WIDTH: 119px" width="119"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 162px" width="162">
													<asp:Label id="Label1" runat="server" CssClass="TextoNegroNegrita">CUENTA :</asp:Label></TD>
												<TD style="WIDTH: 67px" width="67" colSpan="4">
													<asp:Label id="lblCuenta" runat="server" CssClass="TextoNegroNegrita" Width="585px">Label</asp:Label></TD>
												<TD style="WIDTH: 119px" width="119"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 16px"></TD>
									<TD>
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD style="WIDTH: 54px"><IMG id="ibtnFiltrarSeleccion" title="RazonSocial" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
														alt="Aplicar Filtro por Selección" src="../../imagenes/filtroporseleccion.jpg" runat="server"></TD>
												<TD style="WIDTH: 25px">
													<P align="left"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
															ToolTip="Eliminar Filtro.."></asp:imagebutton></P>
												</TD>
												<TD style="WIDTH: 21px">
													<P align="left"><asp:label id="Label2" runat="server" CssClass="normaldetalle" Font-Bold="True" Width="51px"> Buscar :</asp:label></P>
												</TD>
												<TD style="WIDTH: 63px" align="right"><INPUT class="InputFind" id="txtBuscar" onkeydown="BusquedaporCampoColumna(this.value);"
														title="NroFactura" style="BORDER-RIGHT: #999999 1px groove; BORDER-TOP: #999999 1px groove; BORDER-LEFT: #999999 1px groove; WIDTH: 152px; BORDER-BOTTOM: #999999 1px groove"
														type="text" size="20" name="Text1"></TD>
												<TD width="80%"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD></TD>
									<TD align="center"><cc1:datagridweb id="grid" runat="server" Width="100%" ShowFooter="True" RowHighlightColor="#E0E0E0"
											AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" PageSize="15">
											<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle CssClass="FooterGrillaEF"></FooterStyle>
											<Columns>
												<asp:BoundColumn HeaderText="NRO">
													<HeaderStyle Width="1%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Dist" SortExpression="Dist" HeaderText="NRO RUC">
													<HeaderStyle Width="5%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="RAZON SOCIAL">
													<HeaderStyle Width="25%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="SaldoSoles" SortExpression="SaldoSoles" HeaderText="MONTO">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD>
									</TD>
								</TR>
								<TR>
									<TD></TD>
									<TD>
										<P align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD></TD>
									<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center"><INPUT id="hGridPagina" style="WIDTH: 15px; HEIGHT: 22px" type="hidden" size="1" value="0"
								name="hGridPagina" runat="server"><INPUT id="hGridPaginaSort" style="WIDTH: 15px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
								runat="server"></P>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
