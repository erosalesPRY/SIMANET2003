<%@ Page language="c#" Codebehind="ConsultarRelaciondeOrdenesdeCompraPorProveedor.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.ConsultarRelaciondeOrdenesdeCompraPorProveedor" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarRelaciondeOrdenesdeCompraPorProveedor</title>
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
								<TR class="tabla" bgColor="#f5f5f5">
									<TD></TD>
									<TD align="left">
										<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
											<TR>
												<TD style="HEIGHT: 5px" width="80%" colSpan="8"><asp:label id="lblFecha" runat="server" CssClass="TextoNegroNegrita">PERIODO :</asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 87px"><asp:label id="Label4" runat="server" CssClass="TextoNegroNegrita">CONCEPTO :</asp:label></TD>
												<TD style="WIDTH: 256px" width="256" colSpan="3"><asp:label id="lblConcepto" runat="server" CssClass="TextoNegroNegrita" Width="265px">CONCEPTO :</asp:label></TD>
												<TD style="WIDTH: 77px"><asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita">PROVEEDOR :</asp:label></TD>
												<TD colSpan="3"><asp:label id="lblProveedor" runat="server" CssClass="TextoNegroNegrita" Width="286px">...</asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 87px"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif" CausesValidation="False"></asp:imagebutton></TD>
												<TD style="WIDTH: 256px" width="256" colSpan="3"><IMG id="ibtnFiltrarSeleccion" title="RazonSocial" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
														alt="Aplicar Filtro por Selección" src="../../imagenes/filtroporseleccion.jpg" runat="server">
													<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
														ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
												<TD style="WIDTH: 77px"><asp:label id="Label3" runat="server" CssClass="TextoNegroNegrita">RUC :</asp:label></TD>
												<TD colSpan="3"><asp:label id="lblRUC" runat="server" CssClass="TextoNegroNegrita" Width="286px">...</asp:label></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD></TD>
									<TD><cc1:datagridweb id="grid" runat="server" Width="100%" PageSize="15" AllowPaging="True" AllowSorting="True"
											AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" ShowFooter="True">
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
												<asp:BoundColumn DataField="Num_Doc_Ana" SortExpression="Num_Doc_Ana" HeaderText="DOC">
													<HeaderStyle Wrap="False" Width="10%" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FechaEmision" SortExpression="FechaEmision" HeaderText="FECHA">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle Wrap="False"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="SubDiario" SortExpression="SubDiario" HeaderText="SUB&lt;BR&gt;DIARIO">
													<HeaderStyle Width="2%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="DESCRIPCION">
													<HeaderStyle Width="50%"></HeaderStyle>
													<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="TotalEnSoles" SortExpression="TotalEnSoles" HeaderText="SALDO">
													<HeaderStyle Width="19.66%"></HeaderStyle>
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
