<%@ Page language="c#" Codebehind="AdminsitraciondeDivisas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.InformacionFinanciera.AdminsitraciondeDivisas" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
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
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="1" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label>
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Adminsitración de Divisas</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="tabla" id="TblTabs" style="WIDTH: 470px; HEIGHT: 41px" cellSpacing="0" cellPadding="0"
							width="470" bgColor="#f5f5f5" border="0" runat="server">
							<TR bgColor="#ffffff">
								<TD class="TitFiltros" style="WIDTH: 79px; HEIGHT: 19px" width="79"><IMG height="14" src="../../imagenes/TitFiltros.gif" width="82"></TD>
								<TD class="combos" style="WIDTH: 59px; HEIGHT: 19px" width="59"></TD>
								<TD style="WIDTH: 117px"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 16px"></TD>
								<TD style="WIDTH: 59px; HEIGHT: 16px">
									<asp:Label id="Label1" runat="server" CssClass="Combos" Font-Bold="True">Fecha :</asp:Label></TD>
								<TD style="WIDTH: 117px; HEIGHT: 16px">
									<ew:calendarpopup id="CalFecha" runat="server" CssClass="combos" ShowGoToToday="True" ControlDisplay="TextBoxImage"
										Culture="Spanish (Chile)" PadSingleDigits="True" Width="72px" ImageUrl="../../imagenes/BtPU_Mas.gif">
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
								<TD style="HEIGHT: 16px">
									<P align="justify">
										<asp:button id="btnMostrar" style="FONT-SIZE: 8pt; COLOR: #ffffcc; FONT-FAMILY: Arial Narrow; BACKGROUND-COLOR: #306898"
											runat="server" Text="Mostrar"></asp:button></P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><IMG height="8" src="../imagenes/spacer.gif" width="250"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE style="WIDTH: 468px; HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="468" border="0">
							<TR bgColor="#f0f0f0">
								<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
								<TD><IMG height="8" src="../imagenes/spacer.gif" width="342" DESIGNTIMEDRAGDROP="202" style="WIDTH: 342px; HEIGHT: 8px"></TD>
								<TD>&nbsp;</TD>
								<TD></TD>
								<TD></TD>
								<TD>
									<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
								<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
							</TR>
						</TABLE>
						<cc1:datagridweb id="grid" runat="server" Width="469px" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
							AllowSorting="True" AllowPaging="True">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn HeaderText="NRO">
									<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NombreDivisa" SortExpression="NombreDivisa" HeaderText="DIVISA">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn SortExpression="montocompra" HeaderText="COMPRA">
									<HeaderStyle Width="3%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:Label id="LblMontoCompra" runat="server">MontoCompra</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="montoventa" HeaderText="VENTA">
									<HeaderStyle Width="3%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:Label id="lblMontoVenta" runat="server">MontoVenta</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="volacc" HeaderText="VOL (Acc)">
									<HeaderStyle Width="3%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:Label id="lblVolAcc" runat="server">VolAcc</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" style="WIDTH: 475px; HEIGHT: 26px" cellSpacing="1" cellPadding="1" width="475"
							border="0">
							<TR>
								<TD><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td vAlign="top" width="592">
						<IMG height="5" src="../imagenes/spacer.gif" width="592"></td>
				</tr>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
