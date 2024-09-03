<%@ Page language="c#" Codebehind="ConsultarDetalleCuentasPorCobrarJudiciales.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.ConsultarDetalleCuentasPorCobrarJudiciales" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarDetalleCuentasPorCobrarJudiciales</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TBODY>
					<TR>
						<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
					</TR>
					<TR>
						<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
					</TR>
					<TR>
						<TD class="RutaPaginaActual" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Cuentas por Cobrar y Pagar > Cuentas Por Cobrar > Consultar Cuentar por Cobrar </asp:label>&nbsp;</TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<DIV align="center">
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
									<TBODY>
										<TR>
											<TD><asp:label id="Label1" runat="server" CssClass="SubtituloNegrita" Visible="False">CENTRO OPERATIVO:</asp:label><asp:label id="lblCentroOperativo" runat="server" CssClass="SubtituloNegrita"></asp:label><BR>
												<asp:label id="lblConcepto" runat="server" CssClass="SubtituloNegrita"></asp:label></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../../imagenes/filtroPorSeleccion.JPG">
												<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD align="right" bgColor="#f0f0f0">
												<asp:ImageButton id="ibtnJudicial" runat="server" ImageUrl="..\..\imagenes\Judiciales.gif"></asp:ImageButton>
												<asp:ImageButton id="ibtnProvision" runat="server" ImageUrl="..\..\imagenes\PorProvisionar.gif"></asp:ImageButton></TD>
											<TD bgColor="#f0f0f0" colSpan="1">
												<P align="right"><asp:imagebutton id="ibtnAbrir" runat="server" ImageUrl="..\..\imagenes\bt_abrir.gif"></asp:imagebutton></P>
											</TD>
										</TR>
										<TR>
											<TD colSpan="3"><cc1:datagridweb id="grid" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
													RowHighlightColor="#E0E0E0" ShowFooter="True" Width="100%">
													<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle HorizontalAlign="Right" CssClass="FooterGrillaEF"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL">
															<HeaderStyle Width="1%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SUBCUENTA" SortExpression="subcuenta" HeaderText="SUB CUENTA">
															<HeaderStyle Width="10%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="razonsocial" SortExpression="razonsocial" HeaderText="DEUDOR">
															<HeaderStyle Width="20%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="nroentidad" SortExpression="nroentidad" HeaderText="IDENT.">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="num_doc_ana" SortExpression="num_doc_ana" HeaderText="REFERENCIA">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="fecha" SortExpression="fecha" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="12%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="saldo" SortExpression="saldo" HeaderText="SALDO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="concepto" SortExpression="concepto" HeaderText="CONCEPTO">
															<HeaderStyle Width="30%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="observaciones" SortExpression="observaciones" HeaderText="OBSERVACIONES">
															<HeaderStyle Width="20%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR>
											<TD colSpan="3">
												<P align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></P>
											</TD>
										</TR>
										<TR>
											<TD colSpan="3"><asp:label id="Label3" runat="server" CssClass="normaldetalle">OBSERVACIONES</asp:label></TD>
										</TR>
										<TR>
											<TD colSpan="3"><asp:textbox id="txtObservaciones" runat="server" CssClass="normalDetalle" Width="100%" ReadOnly="True"
													Height="64px" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TBODY>
								</TABLE>
							</DIV>
							<INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
								runat="server" DESIGNTIMEDRAGDROP="410"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
								name="hGridPagina" runat="server"> <INPUT id="hCta" style="WIDTH: 16px" type="hidden" size="1" name="hCta" runat="server">
							<INPUT id="hCo" style="WIDTH: 16px" type="hidden" size="1" name="hCo" runat="server"><INPUT id="hEntidad" style="WIDTH: 16px" type="hidden" size="1" name="hEntidad" runat="server"><INPUT id="hNumDocAna" style="WIDTH: 16px" type="hidden" size="1" name="hNumDocAna" runat="server"><INPUT id="hNumAsto" style="WIDTH: 16px" type="hidden" size="1" name="hNumAsto" runat="server"><INPUT id="hMes" style="WIDTH: 16px" type="hidden" size="1" name="hMes" runat="server"><INPUT id="hPeriodo" style="WIDTH: 16px" type="hidden" size="1" name="hPeriodo" runat="server"><INPUT id="hDesc" style="WIDTH: 16px" type="hidden" size="1" name="hDesc" runat="server"><INPUT id="hAbono" style="WIDTH: 16px" type="hidden" size="1" name="hAbono" runat="server"><INPUT id="hCargo" style="WIDTH: 16px" type="hidden" size="1" name="hCargo" runat="server">
							<INPUT id="hIdProv" style="WIDTH: 16px" type="hidden" size="1" name="hIdProv" runat="server">
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<P></P>
		</TR></TBODY>
		<DIV></DIV>
		</TR></TBODY></TABLE></FORM>
	</body>
</HTML>
