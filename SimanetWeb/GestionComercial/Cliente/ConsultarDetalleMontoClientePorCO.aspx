<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarDetalleMontoClientePorCO.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Cliente.ConsultarDetalleMontoClientePorCO" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarDetalleMontoClientePorCO</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" colSpan="3">&nbsp;
						<asp:Label id="lblRuta_Pagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Comercial > Clientes > </asp:Label>
						<asp:Label id="lblPage" runat="server"> Consulta Detalle de Ventas Por Cliente Por Centro de Operacion</asp:Label></TD>
				</TR>
				<TR>
					<TD class="TituloPrincipal" colSpan="3" align="center">
						<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> DETALLE DE VENTAS POR CLIENTE POR CENTRO DE OPERACION</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" style="HEIGHT: 19px">
						<asp:label id="lblNombreRazonSocial" runat="server" CssClass="TituloSecundario"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="tabla" id="Table2" cellSpacing="0" cellPadding="0" width="650" bgColor="#f5f5f5"
							border="0">
							<TR bgColor="#ffffff">
								<TD class="combos" width="121"><IMG height="14" src="../../imagenes/TitFiltros.gif" width="82"></TD>
								<TD class="combos" style="WIDTH: 169px" width="169"></TD>
								<TD class="combos" width="171"></TD>
								<TD class="combos" width="171" colSpan="2" align="right"></TD>
							</TR>
							<TR>
								<TD class="SmallFont" align="right">
									<asp:imagebutton id="ibtnGraficoBarraTipoClientePorCO" runat="server" ImageUrl="../../imagenes/bar.jpg"
										Height="20px" Visible="False" ToolTip="Ventas Presupuestada por Tipo de Cliente"></asp:imagebutton></TD>
								<TD class="SmallFont" width="169">
									<asp:label id="lblFechaInicio" runat="server" CssClass="normal">Fecha de Inicio</asp:label>
									<ew:calendarpopup id="CalFechaInicio" runat="server" CssClass="normaldetalle" AllowArbitraryText="False"
										ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True"
										ImageUrl="../../imagenes/BtPU_Mas.gif" Width="72px" NullableLabelText="Seleccione una fecha:"
										GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar">
										<TextboxLabelStyle CssClass="NormalDetalle"></TextboxLabelStyle>
										<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></WeekdayStyle>
										<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="Navy"></MonthHeaderStyle>
										<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="White"></OffMonthStyle>
										<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
											BackColor="#F0F0F0"></GoToTodayStyle>
										<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
											ForeColor="#335EB4" BackColor="LightSteelBlue"></TodayDayStyle>
										<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="#335EB4"></DayHeaderStyle>
										<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
											ForeColor="IndianRed" BackColor="White"></WeekendStyle>
										<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="CornflowerBlue"></SelectedDateStyle>
										<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></ClearDateStyle>
										<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></HolidayStyle>
									</ew:calendarpopup></TD>
								<TD class="SmallFont">
									<asp:label id="lblFechaFin" runat="server" CssClass="normal">Fecha de Fin</asp:label>
									<ew:calendarpopup id="CalFechaFin" runat="server" CssClass="normaldetalle" AllowArbitraryText="False"
										ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True"
										ImageUrl="../../imagenes/BtPU_Mas.gif" Width="72px" NullableLabelText="Seleccione una fecha:"
										GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar">
										<TextboxLabelStyle CssClass="NormalDetalle"></TextboxLabelStyle>
										<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></WeekdayStyle>
										<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="Navy"></MonthHeaderStyle>
										<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="White"></OffMonthStyle>
										<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
											BackColor="#F0F0F0"></GoToTodayStyle>
										<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
											ForeColor="#335EB4" BackColor="LightSteelBlue"></TodayDayStyle>
										<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="#335EB4"></DayHeaderStyle>
										<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
											ForeColor="IndianRed" BackColor="White"></WeekendStyle>
										<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="CornflowerBlue"></SelectedDateStyle>
										<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></ClearDateStyle>
										<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></HolidayStyle>
									</ew:calendarpopup></TD>
								<TD class="SmallFont" align="right">
									<asp:imagebutton id="ibtnConsultar" runat="server" CssClass="boton" ImageUrl="../../imagenes/ibtnConsultarCliente.gif"
										ImageAlign="Left"></asp:imagebutton></TD>
								<TD class="SmallFont" align="right">
									<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
							</TR>
						</TABLE>
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="650" border="0">
							<TR>
								<TD align="center" bgColor="#f5f5f5" style="HEIGHT: 12px">&nbsp;</TD>
								<TD align="center" bgColor="#f5f5f5" style="HEIGHT: 12px">&nbsp;</TD>
								<TD align="right" bgColor="#f5f5f5" style="HEIGHT: 12px">&nbsp;</TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<DIV>
										<DIV style="OVERFLOW: auto; WIDTH: 650px; HEIGHT: 99px" align="center">
											<cc1:datagridweb id="dgConsulta" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="68" ShowFooter="True"
												RowPositionEnabled="False" RowHighlightColor="#E0E0E0">
												<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
												<ItemStyle CssClass="ItemGrilla"></ItemStyle>
												<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
												<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla"></FooterStyle>
												<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
											</cc1:datagridweb></DIV>
									</DIV>
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 11px" align="center" width="100%" colSpan="3">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><IMG id="Img1" height="8" src="../../imagenes/spacer.gif" width="85"></TD>
							</TR>
						</TABLE>
						<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160">
					</TD>
				</TR>
				<TR>
					<TD align="center"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
