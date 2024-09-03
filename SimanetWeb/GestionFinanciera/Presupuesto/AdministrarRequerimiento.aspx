<%@ Page language="c#" Codebehind="AdministrarRequerimiento.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.AdministrarRequerimiento" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarEvaluacionGastosdeAdministracionCC</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 19px"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Inicio> Gestión Financiera> Prespuesto> Administración Requerimiento</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="tblMasterContenedor" style="HEIGHT: 2px" cellSpacing="0" cellPadding="0" width="100%"
							align="left" border="0">
							<TR id="FilaToolBar" bgColor="#f0f0f0">
								<TD style="WIDTH: 5px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
								<TD width="100%" colSpan="6">
									<TABLE id="tblToolBar" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0"
										runat="server">
										<TR>
											<TD>
												<asp:imagebutton id="ibtnFiltrar" runat="server" CausesValidation="False" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
											<TD><IMG id="ibtnFiltrarSeleccion" title="NroCartaFianza" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
													alt="Aplicar Filtro por Selección" src="../../imagenes/filtroporseleccion.jpg" runat="server"></TD>
											<TD>
												<asp:imagebutton id="ibtnEliminaFiltro" runat="server" CausesValidation="False" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD>
												<asp:label id="Label4" runat="server" CssClass="normaldetalle" Font-Bold="True" Width="53px"> Buscar :</asp:label></TD>
											<TD width="500%"><INPUT class="InputFind" id="txtBuscar" onkeydown="BusquedaporCampoColumna(this.value);"
													title="Buscar por la Columna Seleccionada" style="BORDER-RIGHT: #999999 1px groove; BORDER-TOP: #999999 1px groove; BORDER-LEFT: #999999 1px groove; WIDTH: 91.2%; BORDER-BOTTOM: #999999 1px groove; HEIGHT: 22px"
													type="text" size="1" name="txtBuscar"></TD>
											<TD width="50%">
												<asp:imagebutton id="ibtnAutorizar" runat="server" CausesValidation="False" ImageUrl="../../imagenes/Otros/ibtnTransferencia.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
								<TD align="right">
									<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif" CausesValidation="False"></asp:imagebutton></TD>
								<TD></TD>
								<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="left"><cc1:datagridweb id="grid" runat="server" PageSize="7" AllowSorting="True" AutoGenerateColumns="False"
							RowHighlightColor="#E0E0E0" Width="100%" ShowFooter="True">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="footergrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn HeaderText="N&#186;">
									<HeaderStyle Width="1%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroDocumento" SortExpression="NroDocumento" HeaderText="N&#186; DOC.">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Fecha" SortExpression="Fecha" HeaderText="FECHA">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Motivo" SortExpression="Motivo" HeaderText="MOTIVO">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="MONTO">
									<HeaderStyle Width="10%"></HeaderStyle>
									<HeaderTemplate>
										<TABLE id="Table2" cellSpacing="1" cellPadding="0" width="100%" align="left" border="0">
											<TR>
												<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" width="100%" colSpan="2">
													<asp:Label id="Label1" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">MONTO</asp:Label></TD>
											</TR>
											<TR>
												<TD align="center" width="50%">
													<asp:Label id="Label2" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">REQUERIDO</asp:Label></TD>
												<TD style="DISPLAY: none; BORDER-LEFT: #cccccc 1px solid" align="center" width="50%">
													<asp:Label id="Label3" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">APROBADO</asp:Label></TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table4" cellSpacing="1" cellPadding="0" width="100%" align="left" border="0">
											<TR class="ItemGrillaSinColor">
												<TD align="right" width="50%">
													<asp:Label id="lblMontoRequerido" runat="server">0.00</asp:Label></TD>
												<TD style="DISPLAY: none" align="right" width="50%">
													<asp:Label id="lblMontoAprobado" runat="server">0.00</asp:Label></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Descripcion" HeaderText="DESCRIPCION">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center" width="100%">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
							<TR>
								<TD width="45%"><INPUT id="hGridPagina" style="WIDTH: 15px; HEIGHT: 22px" type="hidden" size="1" value="0"
										runat="server"> <INPUT id="hGridPaginaSort" style="WIDTH: 15px; HEIGHT: 22px" type="hidden" size="1" runat="server">
								</TD>
								<TD><INPUT id="hidRQR" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" runat="server"><INPUT id="hperiodo" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
										runat="server"><INPUT id="idTipoPPto" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
										runat="server"><INPUT id="hidTransf" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
										runat="server"><INPUT id="hNroDoc" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
										runat="server"><INPUT id="hMotivo" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
