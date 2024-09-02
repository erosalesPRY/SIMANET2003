<%@ Page language="c#" Codebehind="AdministraciondeCuentaBancaria.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasBancarias.AdministraciondeCuentaBancaria" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="Label2" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Cuentas Bancarias></asp:label><asp:label id="Label3" runat="server" CssClass="RutaPaginaActual"> Administración (Cuentas Bancarias)</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="tabla" id="TblTabs" cellSpacing="0" cellPadding="0" width="551" align="center"
							bgColor="#f5f5f5" border="0" runat="server">
							<TR>
								<TD style="WIDTH: 361px; HEIGHT: 14px" colSpan="2"><asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" Width="184px" Font-Bold="True"
										ForeColor="Black">Entidad Financiera :</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 361px; HEIGHT: 3px" colSpan="2"><DIV align="left">
										<TABLE id="Table2" style="WIDTH: 279px; HEIGHT: 24px" cellSpacing="0" cellPadding="0" width="279"
											align="left" border="0">
											<TR>
												<TD style="WIDTH: 149px; HEIGHT: 2px" colSpan="2"><asp:dropdownlist id="ddlbEntidadFinanciera" runat="server" Width="280px" CssClass="combos" AutoPostBack="True"></asp:dropdownlist></TD>
												<TD style="HEIGHT: 2px">
													<P align="right">&nbsp;</P>
												</TD>
											</TR>
										</TABLE>
										<P align="left">&nbsp;</P>
									</DIV>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="549" border="0" style="WIDTH: 549px; HEIGHT: 321px">
							<TR>
								<TD align="center">
									<TABLE id="Table9" style="HEIGHT: 25px" cellSpacing="0" cellPadding="0" width="100%"
										border="0">
										<TR bgColor="#f0f0f0">
											<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 90px"><asp:imagebutton id="ibtnFiltar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
                <TD style="WIDTH: 205px" vAlign=middle><IMG 
                  id=ibtnFiltrarSeleccion onclick=FiltroporSeleccion(1); 
                  alt="Aplicar Filtro por Selección" 
                  src="../../imagenes/filtroporseleccion.jpg"></TD>
											<TD style="WIDTH: 205px" vAlign="middle"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD style="WIDTH: 99px" vAlign="middle">
												<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif" CausesValidation="False"></asp:imagebutton></TD>
											<TD style="WIDTH: 19px"><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
											<TD><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif" CausesValidation="False"></asp:imagebutton></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="100%" PageSize="7" AllowPaging="True" AllowSorting="True"
										AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" ShowFooter="True">
<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle Height="25px" CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn SortExpression="NroCuentaBancaria" HeaderText="CUENTA BANCARIA">
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>

<ItemTemplate>
													<asp:HyperLink id="hlkCuentaBancaria" runat="server">Cuenta Bancaria</asp:HyperLink>
												
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="Centro" SortExpression="Centro" HeaderText="CO"></asp:BoundColumn>
<asp:BoundColumn DataField="TipoCtaBco" SortExpression="TipoCtaBco" HeaderText="TIPO">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="U.M">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Right">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Situacion" SortExpression="Situacion" HeaderText="SITUACION">
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<mbrsc:RowSelectorColumn HeaderText="Seleccion" SelectionMode="Single">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>
</mbrsc:RowSelectorColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center"><INPUT id="hCodigo" style="WIDTH: 74px; HEIGHT: 22px" type="hidden" size="7" name="hCodigo"
										runat="server" DESIGNTIMEDRAGDROP="480"><INPUT id="hCuenta" style="WIDTH: 74px; HEIGHT: 22px" type="hidden" size="7" name="hCuenta"
										runat="server" DESIGNTIMEDRAGDROP="70"></TD>
							</TR>
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
