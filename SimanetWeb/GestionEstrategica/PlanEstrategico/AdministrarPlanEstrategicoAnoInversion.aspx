<%@ Page language="c#" Codebehind="AdministrarPlanEstrategicoAnoInversion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.AdministrarPlanEstrategicoAnoInversion" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarPlanEstrategicoAnoInversiond</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form2" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" style="HEIGHT: 20px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Estratégica > Plan Estratégico >  Administrar Año Inversión ></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="2"
							borderColor="#ffffff">
							<TR>
								<TD style="HEIGHT: 9px">
									<TABLE id="Table4" cellSpacing="0" cellPadding="1" width="100%" border="2" borderColor="#ffffff">
										<TR>
											<TD style="WIDTH: 62px">
												<asp:Label id="Label2" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="128px">PLAN ESTRATEGICO:</asp:Label></TD>
											<TD style="WIDTH: 62px"><asp:label id="lblPlanBase" runat="server" CssClass="TituloPrincipalBlanco" Width="70px" ForeColor="Navy"></asp:label></TD>
											<TD><asp:label id="lblNombrePlanBase" runat="server" CssClass="TituloPrincipalBlanco" Height="2px"
													Width="100%" ForeColor="Navy"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 62px">
												<asp:Label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="128px">OBJETIVO GENERAL:</asp:Label></TD>
											<TD style="WIDTH: 62px"><asp:label id="lblObjGral" runat="server" CssClass="TituloPrincipalBlanco" Width="70px" ForeColor="Navy"></asp:label></TD>
											<TD><asp:label id="lblNombreObjGral" runat="server" CssClass="TituloPrincipalBlanco" Height="2px"
													Width="100%" ForeColor="Navy"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 62px">
												<asp:Label id="Label4" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="136px">OBJETIVO ESPECIFICO:</asp:Label></TD>
											<TD style="WIDTH: 62px"><asp:label id="lblObjEsp" runat="server" CssClass="TituloPrincipalBlanco" Width="70px" ForeColor="Navy"></asp:label></TD>
											<TD><asp:label id="lblNombreObjEsp" runat="server" CssClass="TituloPrincipalBlanco" Height="2px"
													Width="100%" ForeColor="Navy"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 62px">
												<asp:Label id="Label5" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="136px">ACCIÓN:</asp:Label></TD>
											<TD style="WIDTH: 62px">
												<asp:label id="lblAccion" runat="server" CssClass="TituloPrincipalBlanco" Width="70px" ForeColor="Navy"></asp:label></TD>
											<TD>
												<asp:label id="lblNombreAccion" runat="server" CssClass="TituloPrincipalBlanco" Width="100%"
													Height="2px" ForeColor="Navy"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 62px">
												<asp:Label id="Label6" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="136px">ACTIVIDAD:</asp:Label></TD>
											<TD style="WIDTH: 62px">
												<asp:label id="lblActividad" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
													Width="70px"></asp:label></TD>
											<TD>
												<asp:label id="lblNombreActividad" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
													Width="100%" Height="2px"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table2" borderColor="#ffffff" cellSpacing="1" cellPadding="1" width="780" border="1">
										<TR>
											<TD align="center">
												<TABLE style="HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR bgColor="#f0f0f0">
														<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
														<TD><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
														<TD style="WIDTH: 138px"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
																src="../../imagenes/filtroporseleccion.jpg" title="Descripcion"></TD>
														<TD style="WIDTH: 9px"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
														<TD style="WIDTH: 2px">
															<asp:label id="Label1" runat="server" CssClass="normaldetalle" Width="53px" Font-Bold="True"> Buscar :</asp:label></TD>
														<TD width="100%"><INPUT class="InputFind" id="txtBuscar" onkeydown="BusquedaporCampoColumna(this.value);"
																title="Buscar por la Columna Seleccionada" style="BORDER-RIGHT: #999999 1px groove; BORDER-TOP: #999999 1px groove; BORDER-LEFT: #999999 1px groove; WIDTH: 152px; BORDER-BOTTOM: #999999 1px groove"
																type="text" size="20" name="txtBuscar"></TD>
														<TD style="WIDTH: 186px"></TD>
														<TD><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
														<TD>
															<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
														<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" Width="780px" PageSize="7" RowHighlightColor="#E0E0E0"
													AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowFooter="True" RowPositionEnabled="False">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO" DataFormatString="{0:###,##0.00}">
															<HeaderStyle Width="2%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="INVERSION" SortExpression="INVERSION" HeaderText="INVERSION" DataFormatString="{0:###,##0.00}">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="ANO" SortExpression="ANO" HeaderText="A&#209;O">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb></TD>
										</TR>
									</TABLE>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label>
								</TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif">&nbsp;<INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 14px" type="hidden" size="1" name="hCodigo"
										runat="server"><INPUT id="hDescripcionActividad" type="hidden" size="1" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
										NAME="hDescripcionActividad"> <INPUT id="hCodigoActividad" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
										runat="server"> <INPUT id="hNro" style="WIDTH: 16px; HEIGHT: 14px" type="hidden" size="1" name="hCodigo"
										runat="server">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
