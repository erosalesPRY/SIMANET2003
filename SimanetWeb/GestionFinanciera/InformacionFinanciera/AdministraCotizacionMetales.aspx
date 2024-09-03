<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="AdministraCotizacionMetales.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.InformacionFinanciera.AdministraCotizacionMetales" %>
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
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="1" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Cotización Internacional de Metales</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><IMG style="WIDTH: 301px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="301"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="tabla" id="TblTabs" cellSpacing="0" cellPadding="0"
							width="424" bgColor="#f5f5f5" border="0" runat="server">
							<TR>
								<TD >
									<asp:Label id="Label1" runat="server" CssClass="TextoBlanco" Font-Bold="True" ForeColor="Black">Fecha :</asp:Label></TD>
								<TD >
									<ew:calendarpopup id="CalFecha" runat="server" CssClass="combos" ImageUrl="../../imagenes/BtPU_Mas.gif"
										Width="82" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True"
										Height="16px">
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
								<TD ></TD>
          <TD style="HEIGHT: 21px"></TD>
								<TD style="HEIGHT: 21px">
									<P align="justify"><IMG 
            style="WIDTH: 100px; HEIGHT: 8px" height=8 
            src="../imagenes/spacer.gif" width=102></P>
								</TD>
							</TR>
							<TR>
								<TD >
									<asp:label id="Label2" runat="server" CssClass="TextoBlanco" ForeColor="Black">Mercado:</asp:label></TD>
								<TD >
									<asp:dropdownlist id="ddlbMercado" runat="server" CssClass="normaldetalle" Width="152px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 117px; HEIGHT: 16px">
										<asp:button id="btnMostrar" style="FONT-SIZE: 8pt; COLOR: #ffffcc; FONT-FAMILY: Arial Narrow; BACKGROUND-COLOR: #306898"
											runat="server" Text="Mostrar"></asp:button>
								</TD>
          <TD style="HEIGHT: 16px"></TD>
								<TD style="HEIGHT: 16px">
									<P align="justify">&nbsp;</P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE style="WIDTH: 424px; HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="424" border="0">
							<TR bgColor="#f0f0f0">
								<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
								<TD><IMG style="WIDTH: 310px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="310"></TD>
								<TD>&nbsp;</TD>
								<TD></TD>
								<TD></TD>
								<TD>
									<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
								<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
							</TR>
						</TABLE>
						<cc1:datagridweb id="grid" runat="server" Width="424px" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
							AllowSorting="True" PageSize="20">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn HeaderText="NRO">
									<HeaderStyle Width="1%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="descripcion" SortExpression="descripcion" HeaderText="MATERIA PRIMA">
									<HeaderStyle Width="70%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="montocotiza" SortExpression="montocotiza" HeaderText="Monto">
									<HeaderStyle Width="30%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
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
						<TABLE id="Table1" style="WIDTH: 432px; HEIGHT: 28px" cellSpacing="1" cellPadding="1" width="432"
							border="0">
							<TR>
								<TD><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hModo" style="WIDTH: 48px; HEIGHT: 22px" type="hidden" size="2" name="hModo"
										runat="server" DESIGNTIMEDRAGDROP="175"><INPUT id="hidMetal" style="WIDTH: 48px; HEIGHT: 22px" type="hidden" size="2" name="hidMetal"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
