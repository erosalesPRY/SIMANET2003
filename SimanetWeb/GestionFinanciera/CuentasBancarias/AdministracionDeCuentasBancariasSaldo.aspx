<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministracionDeCuentasBancariasSaldo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasBancarias.AdministracionDeCuentasBancariasSaldo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<!--oncontextmenu="return false"-->
  </HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="1" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" bgColor="#eff7fa" style="HEIGHT: 1px">
						<uc1:menu id="Menu1" runat="server"></uc1:menu>
					</TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" style="HEIGHT: 3px" vAlign="top" width="100%" bgColor="#eff7fa"><asp:label id="Label2" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Cuentas Bancarias></asp:label><asp:label id="Label3" runat="server" CssClass="RutaPaginaActual"> Administración Saldos de Cuentas Bancarias</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px" vAlign="top" align="center" width="100%"><IMG height="8" src="../imagenes/spacer.gif" width="250" DESIGNTIMEDRAGDROP="205"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" align="center" width="100%">
						<TABLE class="tabla" id="TblTabs" style="WIDTH: 759px; HEIGHT: 8px" cellSpacing="0" cellPadding="0"
							width="759" bgColor="#f5f5f5" border="0" runat="server">
							<TR>
								<TD width="10">
									<asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita" DESIGNTIMEDRAGDROP="28"
										Width="48px">FECHA:</asp:label></TD>
								<TD style="WIDTH: 94px; HEIGHT: 15px">
									<ew:calendarpopup id="CalFecha" runat="server" CssClass="normaldetalle" Width="72px" CellPadding="2px"
										CalendarLocation="Bottom" Height="17px" DisableTextboxEntry="False" SelectedDate="2004-12-09"
										PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True"
										AllowArbitraryText="False" ImageUrl="../../imagenes/BtPU_Mas.gif" AutoPostBack="True">
										<TextboxLabelStyle CssClass="normal"></TextboxLabelStyle>
										<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></WeekdayStyle>
										<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="#FF8A00"></MonthHeaderStyle>
										<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Gray"
											BackColor="AntiqueWhite"></OffMonthStyle>
										<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></GoToTodayStyle>
										<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="LightGoldenrodYellow"></TodayDayStyle>
										<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="Gray"></DayHeaderStyle>
										<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="LightGray"></WeekendStyle>
										<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="#FF8A00"></SelectedDateStyle>
										<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></ClearDateStyle>
										<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></HolidayStyle>
									</ew:calendarpopup></TD>
								<TD style="WIDTH: 156px; HEIGHT: 15px">
									<asp:label id="Label4" runat="server" CssClass="TextoNegroNegrita" Width="168px">CENTRO DE OPERACIONES:</asp:label></TD>
								<TD style="HEIGHT: 15px">
									<asp:DropDownList id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Width="216px" AutoPostBack="True"></asp:DropDownList></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><TABLE id="Table9" style="WIDTH: 761px; HEIGHT: 25px" cellSpacing="0" cellPadding="0" width="761"
							border="0">
							<TR bgColor="#f0f0f0">
								<TD style="WIDTH: 4px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="8" style="WIDTH: 8px; HEIGHT: 22px"></TD>
								<TD style="WIDTH: 49px">
									<asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif" CausesValidation="False"></asp:imagebutton></TD>
								<TD style="WIDTH: 117px"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
										src="../../imagenes/filtroporseleccion.jpg"></TD>
								<TD style="WIDTH: 2px">
									<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
										ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
								<TD style="WIDTH: 32px">
									<asp:label id="Label5" runat="server" CssClass="normaldetalle" Width="53px" Font-Bold="True"> Buscar :</asp:label></TD>
								<TD width="100%">
									<INPUT class="InputFind" id="txtBuscar" onkeydown="BusquedaporCampoColumna(this.value);"
										title="Buscar por la Columna Seleccionada" style="BORDER-RIGHT: #999999 1px groove; BORDER-TOP: #999999 1px groove; BORDER-LEFT: #999999 1px groove; WIDTH: 152px; BORDER-BOTTOM: #999999 1px groove"
										type="text" size="20" name="txtBuscar">
								</TD>
								<TD style="WIDTH: 98px">
									<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
								<TD>
									<asp:imagebutton id="imgbtnImportar" runat="server" ImageUrl="../../imagenes/btnImportaciones/btnImportarSaldodeCuentaBancaria.gif"
										ToolTip="Solo se Actualizara las Cuentas Bancarias de Sima Peru y Sima Callao..."></asp:imagebutton></TD>
								<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
							</TR>
						</TABLE>
						<cc1:datagridweb id="grid" runat="server" Width="763px" PageSize="7" RowPositionEnabled="False" RowHighlightColor="#E0E0E0"
							AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowFooter="True">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle Height="25px" CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn HeaderText="NRO">
									<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CentroOperativo" SortExpression="CentroOperativo" HeaderText="CO">
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="EntidadFinanciera" SortExpression="EntidadFinanciera" HeaderText="ENTIDAD FINANCIERA">
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroCuentaBancaria" SortExpression="NroCuentaBancaria" HeaderText="NRO CUENTA BCO">
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TipoCtaBco" SortExpression="TipoCtaBco" HeaderText="TIPO">
									<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="U.M">
									<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MontoSaldo" SortExpression="MontoSaldo" HeaderText="SALDO" DataFormatString="{0:##0.00}">
									<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Observacion" SortExpression="Observacion" HeaderText="OBSERVACIONES">
									<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" align="center" width="100%">
						<DIV align="center">&nbsp;
							<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></DIV>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" align="center" width="100%"><INPUT id="hModo" style="WIDTH: 27px; HEIGHT: 22px" type="hidden" size="1" name="hModo"
							runat="server"><INPUT id="hCuenta" style="WIDTH: 22px; HEIGHT: 22px" type="hidden" size="1" name="hCuenta"
							runat="server" DESIGNTIMEDRAGDROP="214"><INPUT id="hCodigo" style="WIDTH: 30px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
							runat="server" DESIGNTIMEDRAGDROP="451"> <INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
							name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
							runat="server">
						<TABLE id="Table1" style="WIDTH: 764px; HEIGHT: 27px" cellSpacing="1" cellPadding="1" width="764"
							border="0">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif">
									<asp:literal id="Literal1" runat="server"></asp:literal></TD>
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
