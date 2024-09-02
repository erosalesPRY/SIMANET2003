<%@ Page language="c#" Codebehind="DetallePlanEstrategicoBase.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.DetallePlanEstrategicoBase" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" onload="SetFocusInicial('txtNroDocumento'); ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<SCRIPT language="javascript" src="../../js/wz_tooltip.js"></SCRIPT>
			<SCRIPT language="javascript" src="../../js/tip_balloon.js"></SCRIPT>
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<tr>
						<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
					</tr>
					<TR>
						<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Plan Estratégico</asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="100%">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="458" border="0">
								<TR>
									<TD align="left" bgColor="#000080" colSpan="6">
										<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="16px" Width="304px">DETALLE PLAN ESTRATEGICO</asp:label></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD align="center" colSpan="6" class="HeaderDetalle" style="TEXT-ALIGN: center">
										<asp:Label id="Label1" runat="server">PERIODO</asp:Label></TD>
								</TR>
								<TR class="AlternateItemDetalle">
									<TD style="HEIGHT: 22px" class="HeaderDetalle">
										<asp:Label id="Label3" runat="server">INICIAL:</asp:Label></TD>
									<TD style="WIDTH: 144px; HEIGHT: 22px">
										<ew:calendarpopup id="CalFechaInicio" runat="server" CssClass="normaldetalle" Width="64px" ImageUrl="../../imagenes/BtPU_Mas.gif"
											PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True"
											CalendarLocation="Bottom" AllowArbitraryText="False" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar"
											MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:">
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
									<TD style="HEIGHT: 22px"></TD>
									<TD style="HEIGHT: 22px" class="HeaderDetalle">
										<asp:Label id="Label2" runat="server">FINAL:</asp:Label></TD>
									<TD style="HEIGHT: 22px">
										<ew:calendarpopup id="CalFechaFinal" runat="server" CssClass="normaldetalle" Width="70px" ImageUrl="../../imagenes/BtPU_Mas.gif"
											PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True"
											CalendarLocation="Bottom" AllowArbitraryText="False" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar"
											MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:">
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
									<TD style="HEIGHT: 22px"></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD align="left" colSpan="6" class="HeaderDetalle">
										<asp:Label id="Label4" runat="server">DESCRIPCION DEL PLAN</asp:Label>
										<cc1:requireddomvalidator id="rfvnDescripcion" runat="server" Width="8px" ControlToValidate="txtDescripcion">*</cc1:requireddomvalidator></TD>
								</TR>
								<TR class="AlternateItemDetalle">
									<TD style="HEIGHT: 80px" vAlign="top" align="left" colSpan="6">
										<asp:TextBox id="txtDescripcion" runat="server" Height="80px" Width="100%" TextMode="MultiLine"
											CssClass="normaldetalle"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD colSpan="6"><IMG id="ibtnAtras1" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
											runat="server"></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD colSpan="6" bgColor="#ffffff">
										<TABLE id="Table2" style="WIDTH: 182px; HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="182"
											align="center" border="0" runat="server">
											<TR>
												<TD width="50%">
													<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
												<TD width="50%"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" width="100%" align="center"><cc1:domvalidationsummary id="Vresumen" runat="server" Width="160px" Height="24px" EnableClientScript="False"
								DisplayMode="List" ShowMessageBox="True"></cc1:domvalidationsummary>
						</TD>
					</TR>
				</TBODY>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TBODY></TABLE>
	</body>
</HTML>
