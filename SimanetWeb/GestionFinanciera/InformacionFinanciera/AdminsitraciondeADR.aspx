<%@ Page language="c#" Codebehind="AdminsitraciondeADR.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.InformacionFinanciera.AdminsitraciondeADR" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
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
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="1" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración de ADRS</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><IMG style="WIDTH: 301px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="301"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="tabla" id="TblTabs" cellSpacing="0" cellPadding="0" width="489" bgColor="#f5f5f5"
							border="0" runat="server">
							<TR>
								<TD style="WIDTH: 59px; HEIGHT: 16px">
									<asp:Label id="Label1" runat="server" CssClass="TEXTOBLANCO" Font-Bold="True" ForeColor="Black">FECHA :</asp:Label></TD>
								<TD style="WIDTH: 117px; HEIGHT: 16px">
									<ew:calendarpopup id="CalFecha" runat="server" CssClass="combos" ShowGoToToday="True" ControlDisplay="TextBoxImage"
										Culture="Spanish (Chile)" PadSingleDigits="True" Width="72px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										AutoPostBack="True">
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
									<P align="justify">&nbsp;</P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE style="WIDTH: 488px; HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="488" border="0">
							<TR bgColor="#f0f0f0">
								<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
								<TD><IMG style="WIDTH: 383px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="383"></TD>
								<TD>&nbsp;</TD>
								<TD></TD>
								<TD></TD>
								<TD>
									<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
								<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
							</TR>
						</TABLE>
						<cc1:datagridweb id="grid" runat="server" Width="489px" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
							AllowSorting="True" AllowPaging="True">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn HeaderText="NRO">
									<HeaderStyle Width="1%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NombreEntidad" SortExpression="NombreEntidad" HeaderText="ENTIDAD">
									<HeaderStyle Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn SortExpression="porccierre" HeaderText="CIERRE US$.">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:Label id="LblPorcCierre" runat="server">MontoCompra</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="porcvariacion" HeaderText="VAR (%)">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:Label id="LblPorcVar" runat="server">MontoVenta</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="porcvolacc" HeaderText="VOL (Acc)">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:Label id="lblPorcVolAcc" runat="server">VolAcc</asp:Label>
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
						<TABLE id="Table1" style="WIDTH: 496px; HEIGHT: 26px" cellSpacing="1" cellPadding="1" width="496"
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
