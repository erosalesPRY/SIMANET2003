<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleAccionCtrlPosterior.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.DetalleAccionCtrlPosterior" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table id="tabla1" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD colSpan="6"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="6"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<tr>
					<td align="center" colSpan="6">
						<TABLE id="tabla2" cellSpacing="0" cellPadding="0" width="760" border="0">
							<TR>
								<TD class="Commands" align="left" colSpan="6"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Administracion de Acciones de Control Posterior ></asp:label></TD>
							</TR>
							<TR>
								<TD class="normal" align="center" colSpan="6" height="20">
									<asp:label id="lblMensaje" runat="server" CssClass="normal"></asp:label>
									<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="760" border="1" borderColor="#ffffff">
										<TR>
											<TD style="WIDTH: 760px" width="760" bgColor="#000080" colSpan="7">
												<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Width="406px"></asp:label></TD>
										</TR>
										<TR class="AlternateItemDetalle">
											<TD style="HEIGHT: 39px" width="108" bgColor="#335eb4" rowSpan="2">
												<asp:label id="lblCodigo" runat="server" CssClass="TextoBlanco" Width="80px"> CÓDIGO :</asp:label></TD>
											<TD align="center" width="108">
												<asp:label id="lblTipoOrgano" runat="server" CssClass="TituloPrincipalBlanco" Width="80px"
													ForeColor="Navy">ORGANO</asp:label></TD>
											<TD align="center" width="108">
												<asp:label id="lblOrgInfo" runat="server" CssClass="TituloPrincipalBlanco" Width="80px" ForeColor="Navy">INFORMANTE</asp:label></TD>
											<TD align="center" width="108">
												<asp:label id="lblAno" runat="server" CssClass="TituloPrincipalBlanco" Width="80px" ForeColor="Navy">AÑO</asp:label></TD>
											<TD align="center" width="108">
												<asp:label id="lblCorrelativo" runat="server" CssClass="TituloPrincipalBlanco" Width="80px"
													ForeColor="Navy">CORRELATIVO</asp:label></TD>
											<TD width="108"></TD>
											<TD style="WIDTH: 13px" width="13"></TD>
										</TR>
										<TR class="AlternateItemDetalle">
											<TD style="HEIGHT: 16px" align="center" width="108" id="CellddlbTipOrgano" runat="server">
												<asp:dropdownlist id="ddlbTipOrgano" runat="server" CssClass="normaldetalle" Width="80px"></asp:dropdownlist></TD>
											<TD style="HEIGHT: 16px" align="center" width="108" id="CellddlbOrganoInformante" runat="server">
												<asp:dropdownlist id="ddlbOrganoInformante" runat="server" CssClass="normaldetalle" Width="80px"></asp:dropdownlist></TD>
											<TD style="HEIGHT: 16px" align="center" width="108" id="CellddlbAno" runat="server"><asp:dropdownlist id="ddlbAno" runat="server" CssClass="normaldetalle" Width="80px"></asp:dropdownlist></TD>
											<TD style="HEIGHT: 16px" align="center" width="108"><asp:textbox id="txtCorrelativo" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox></TD>
											<TD style="HEIGHT: 16px" width="108"></TD>
											<TD style="WIDTH: 13px; HEIGHT: 16px" width="13"><cc1:requireddomvalidator id="rfvCorrelativo" runat="server" ControlToValidate="txtCorrelativo">*</cc1:requireddomvalidator></TD>
										</TR>
										<TR class="ItemDetalle">
											<TD align="left" width="108" bgColor="#335eb4"><asp:label id="lblTipo" runat="server" CssClass="TextoBlanco" Width="112px">TIPO :</asp:label></TD>
											<TD align="left" width="230" id="CellddlbTipoAccionCtrlPosterior" runat="server" colSpan="2"><asp:dropdownlist id="ddlbTipoAccionCtrlPosterior" runat="server" CssClass="normaldetalle" Width="220px"></asp:dropdownlist><cc1:requireddomvalidator id="rfvTipoAccionCtrlPosterior" runat="server" ControlToValidate="ddlbTipoAccionCtrlPosterior">*</cc1:requireddomvalidator></TD>
											<TD align="left" width="108" bgColor="#335eb4" colSpan="1"><asp:label id="lblDenominacion" runat="server" CssClass="TextoBlanco" Width="112px">DENOMINACION :</asp:label></TD>
											<TD align="center" width="108" colSpan="2"><asp:textbox id="txtDenominacion" runat="server" CssClass="normal" Width="230px" MaxLength="10000"
													TextMode="MultiLine" Height="32px"></asp:textbox></TD>
											<TD style="WIDTH: 13px" width="13"><cc1:requireddomvalidator id="rfvDenominacion" runat="server" ControlToValidate="txtDenominacion">*</cc1:requireddomvalidator></TD>
										</TR>
										<TR class="AlternateItemDetalle">
											<TD align="left" width="108" bgColor="#335eb4"><asp:label id="lblObjetivo" runat="server" CssClass="TextoBlanco" Width="112px">OBJETIVO :</asp:label></TD>
											<TD align="left" width="230" colSpan="2"><asp:textbox id="txtObjetivo" runat="server" CssClass="normal" Width="220px" MaxLength="10000"
													TextMode="MultiLine" Height="32px"></asp:textbox><cc1:requireddomvalidator id="rfvObjetivo" runat="server" ControlToValidate="txtObjetivo">*</cc1:requireddomvalidator></TD>
											<TD align="left" width="108" bgColor="#335eb4"><asp:label id="lblLineamientos" runat="server" CssClass="TextoBlanco" Width="112px"> RELACIÓN CON LINEAMIENTOS :</asp:label></TD>
											<TD align="center" width="108" colSpan="2"><asp:textbox id="txtLineamientos" runat="server" CssClass="normal" Width="230px" MaxLength="10000"
													TextMode="MultiLine" Height="32px"></asp:textbox></TD>
											<TD style="WIDTH: 13px" width="13"><cc1:requireddomvalidator id="rfvLineamientos" runat="server" ControlToValidate="txtLineamientos">*</cc1:requireddomvalidator></TD>
										</TR>
										<TR class="ItemDetalle">
											<TD bgColor="#335eb4"><asp:label id="lblMonto" runat="server" CssClass="TextoBlanco" Width="112px">MONTO A SER EXAMINADO :</asp:label></TD>
											<TD align="center"><asp:textbox id="txtMontoAExaminar" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox></TD>
											<TD align="left"><cc1:requireddomvalidator id="rfvMontoAExaminar" runat="server" ControlToValidate="txtMontoAExaminar">*</cc1:requireddomvalidator></TD>
											<TD bgColor="#335eb4"><asp:label id="lblNroHH" runat="server" CssClass="TextoBlanco" Width="112px">NÚMERO DE H/H :</asp:label></TD>
											<TD align="center"><asp:textbox id="txtNroHH" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox></TD>
											<TD></TD>
											<TD><cc1:requireddomvalidator id="rfvNroHH" runat="server" ControlToValidate="txtNroHH">*</cc1:requireddomvalidator></TD>
										</TR>
										<TR class="AlternateItemDetalle">
											<TD bgColor="#335eb4" rowSpan="2"><asp:label id="lblAlcance" runat="server" CssClass="TextoBlanco" Width="112px">ALCANCE  ===> :</asp:label></TD>
											<TD align="center"><asp:label id="lblAlcanceFechDesde" runat="server" CssClass="TituloPrincipalBlanco" Width="80px"
													ForeColor="Navy">DESDE</asp:label></TD>
											<TD align="center"><asp:label id="lblAlcanceFechHasta" runat="server" CssClass="TituloPrincipalBlanco" Width="80px"
													ForeColor="Navy">HASTA</asp:label></TD>
											<TD align="left" bgColor="#335eb4" rowSpan="2"><asp:label id="lblCronograma" runat="server" CssClass="TextoBlanco" Width="112px">CRONOGRAMA ===> :</asp:label></TD>
											<TD align="center"><asp:label id="lblCronogramaFechDesde" runat="server" CssClass="TituloPrincipalBlanco" Width="80px"
													ForeColor="Navy">DESDE</asp:label></TD>
											<TD align="center"><asp:label id="lblCronogramaFechHasta" runat="server" CssClass="TituloPrincipalBlanco" Width="80px"
													ForeColor="Navy">HASTA</asp:label></TD>
											<TD></TD>
										</TR>
										<TR class="AlternateItemDetalle">
											<TD align="center"><ew:calendarpopup id="CalAlcanceDesde" runat="server" CssClass="normaldetalle" Width="72px" NullableLabelText="Seleccione una fecha:"
													MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar" GoToTodayText="Hoy :" PadSingleDigits="True"
													Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False" ImageUrl="../imagenes/BtPU_Mas.gif">
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
											<TD align="center"><ew:calendarpopup id="CalAlcanceHasta" runat="server" CssClass="normaldetalle" Width="72px" NullableLabelText="Seleccione una fecha:"
													MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar" GoToTodayText="Hoy :" PadSingleDigits="True"
													Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False" ImageUrl="../imagenes/BtPU_Mas.gif">
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
											<TD align="center"><ew:calendarpopup id="CalCronogramaDesde" runat="server" CssClass="normaldetalle" Width="72px" NullableLabelText="Seleccione una fecha:"
													MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar" GoToTodayText="Hoy :" PadSingleDigits="True"
													Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False" ImageUrl="../imagenes/BtPU_Mas.gif">
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
											<TD align="center"><ew:calendarpopup id="CalCronogramaHasta" runat="server" CssClass="normaldetalle" Width="72px" NullableLabelText="Seleccione una fecha:"
													MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar" GoToTodayText="Hoy :" PadSingleDigits="True"
													Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False" ImageUrl="../imagenes/BtPU_Mas.gif">
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
											<TD></TD>
										</TR>
										<TR class="ItemDetalle">
											<TD style="HEIGHT: 21px" bgColor="#335eb4" rowSpan="2"><asp:label id="lblIntegrantes" runat="server" CssClass="TextoBlanco" Width="112px"> INTEGRANTES ===> :</asp:label></TD>
											<TD style="HEIGHT: 21px" align="center"><asp:label id="lblAudOCI" runat="server" CssClass="TituloPrincipalBlanco" Width="90px" ForeColor="Navy">AUDITORES OCI</asp:label></TD>
											<TD style="HEIGHT: 21px" align="center"><asp:label id="lblAudEsp" runat="server" CssClass="TituloPrincipalBlanco" Width="80px" ForeColor="Navy">ESPECIALISTAS</asp:label></TD>
											<TD style="HEIGHT: 21px" align="left" bgColor="#335eb4" rowSpan="2"><asp:label id="lblCostoDirecto" runat="server" CssClass="TextoBlanco" Width="120px"> COSTO DIRECTO ===> :</asp:label></TD>
											<TD style="HEIGHT: 21px" align="center"><asp:label id="lblCostoAudOCI" runat="server" CssClass="TituloPrincipalBlanco" Width="90px"
													ForeColor="Navy">AUDITORES OCI</asp:label></TD>
											<TD style="HEIGHT: 21px" align="center"><asp:label id="lblCostoEsp" runat="server" CssClass="TituloPrincipalBlanco" Width="80px" ForeColor="Navy">ESPECIALISTAS</asp:label></TD>
											<TD style="HEIGHT: 21px"></TD>
										</TR>
										<TR class="ItemDetalle">
											<TD style="HEIGHT: 24px" align="center"><asp:textbox id="txtIntegrantesOCI" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox><cc1:requireddomvalidator id="rfvIntegrantesOCI" runat="server" ControlToValidate="txtIntegrantesOCI">*</cc1:requireddomvalidator></TD>
											<TD style="HEIGHT: 24px" align="center"><asp:textbox id="txtIntegrantesEspecialistas" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox><cc1:requireddomvalidator id="rfvIntegrantesEspecialistas" runat="server" ControlToValidate="txtIntegrantesEspecialistas">*</cc1:requireddomvalidator></TD>
											<TD style="HEIGHT: 24px" align="center"><asp:textbox id="txtCostoOCI" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox><cc1:requireddomvalidator id="rfvCostoOCI" runat="server" ControlToValidate="txtCostoOCI">*</cc1:requireddomvalidator></TD>
											<TD style="HEIGHT: 24px" align="center"><asp:textbox id="txtCostoEspecialistas" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox><cc1:requireddomvalidator id="rfvCostoEspecialistas" runat="server" ControlToValidate="txtCostoEspecialistas">*</cc1:requireddomvalidator></TD>
											<TD style="HEIGHT: 24px"></TD>
										</TR>
										<TR class="AlternateItemDetalle">
											<TD bgColor="#335eb4" rowSpan="2"><asp:label id="lblMeta" runat="server" CssClass="TextoBlanco" Width="112px">META :</asp:label></TD>
											<TD align="center"><asp:label id="lbl1erT" runat="server" CssClass="TituloPrincipalBlanco" Width="90px" ForeColor="Navy">1ER TRIMESTRE</asp:label></TD>
											<TD align="center"><asp:label id="lbl2doT" runat="server" CssClass="TituloPrincipalBlanco" Width="95px" ForeColor="Navy">2DO TRIMESTRE</asp:label></TD>
											<TD align="center"><asp:label id="lbl2erT" runat="server" CssClass="TituloPrincipalBlanco" Width="95px" ForeColor="Navy">3ER TRIMESTRE</asp:label></TD>
											<TD align="center"><asp:label id="lbl4toT" runat="server" CssClass="TituloPrincipalBlanco" Width="100px" ForeColor="Navy">4TO TRIMESTRE</asp:label></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR class="AlternateItemDetalle">
											<TD align="center"><asp:textbox id="txtMeta1erTrimestre" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox><cc1:requireddomvalidator id="rfvMeta1erTrim" runat="server" ControlToValidate="txtMeta1erTrimestre">*</cc1:requireddomvalidator></TD>
											<TD align="center"><asp:textbox id="txtMeta2doTrimestre" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox><cc1:requireddomvalidator id="rfvMeta2doTrim" runat="server" ControlToValidate="txtMeta2doTrimestre">*</cc1:requireddomvalidator></TD>
											<TD align="center"><asp:textbox id="txtMeta3erTrimestre" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox><cc1:requireddomvalidator id="rfvMeta3erTrim" runat="server" ControlToValidate="txtMeta3erTrimestre">*</cc1:requireddomvalidator></TD>
											<TD align="center"><asp:textbox id="txtMeta4toTrimestre" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox><cc1:requireddomvalidator id="rfvMeta4toTrim" runat="server" ControlToValidate="txtMeta4toTrimestre">*</cc1:requireddomvalidator></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD align="left" bgColor="#000080" colSpan="4"><asp:label id="lblTitulo1" runat="server" CssClass="TituloPrincipalBlanco" Width="406px">AREAS A SER EXAMINADAS</asp:label></TD>
											<TD align="left" bgColor="#000080" colSpan="3"><asp:checkbox id="chkTieneAreasAExaminar" runat="server" CssClass="TituloPrincipalBlanco" Text="Tiene Áreas A Examinar?"
													AutoPostBack="True"></asp:checkbox></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="7">
												<TABLE class="normal" id="Table7" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
													width="450" align="center" border="1">
													<TR id="TrCeldaAreaCritica" runat="server">
														<TD class="normal" style="WIDTH: 81px" vAlign="top" bgColor="#335eb4"><asp:label id="lblAreaCritica" runat="server" CssClass="TextoBlanco" Width="80px" Height="24px">ÁREA CRÍTICA:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtNombreAreaCritica" runat="server" CssClass="normaldetalle" Width="336px"
																MaxLength="80" ReadOnly="True"></asp:textbox><asp:imagebutton id="ibtnBuscarAreaAExaminar" runat="server" CssClass="normaldetalle" ImageUrl="../imagenes/BtPU_Mas.gif"
																CausesValidation="False"></asp:imagebutton></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" align="right" colSpan="5"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif" CausesValidation="False"></asp:imagebutton><asp:imagebutton id="ibtnModificar" runat="server" ImageUrl="../imagenes/bt_modificar.gif" CausesValidation="False"
																Visible="False"></asp:imagebutton><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif" CausesValidation="False"></asp:imagebutton></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" align="center" colSpan="5"><cc2:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="450px" Visible="False" RowHighlightColor="#E0E0E0"
																AutoGenerateColumns="False" BorderStyle="None">
																<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
																<ItemStyle CssClass="ItemGrilla"></ItemStyle>
																<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
																<FooterStyle CssClass="FooterGrilla"></FooterStyle>
																<Columns>
																	<asp:BoundColumn Visible="False" DataField="IdGrupoAreaCritica" SortExpression="IdGrupoAreaCritica"
																		HeaderText="IDGRUPO">
																		<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="IdAreaCritica" SortExpression="IdAreaCritica" HeaderText="IDAREA"></asp:BoundColumn>
																	<asp:BoundColumn DataField="NroGrupoAreaCritica" SortExpression="NroGrupoAreaCritica" HeaderText="GRUPO">
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																		<FooterStyle HorizontalAlign="Right"></FooterStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="NroAreaCritica" SortExpression="NroAreaCritica" HeaderText="AREA">
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="NombreAreaCritica" SortExpression="NombreAreaCritica" HeaderText="DENOMINACION AREA">
																		<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="Tipo"></asp:BoundColumn>
																</Columns>
																<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
															</cc2:datagridweb></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" align="center" colSpan="5"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
														<TD class="normal"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD align="right" colSpan="7">
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="1" borderColor="#ffffff">
													<TR>
														<TD><asp:imagebutton id="ibtnAceptar" runat="server" Height="22px" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
														<TD><IMG id="ibtnCancelar" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif"
																runat="server"></TD>
														<TD id="TdCeldaCancelar" runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
													</TR>
												</TABLE>
												<INPUT id="hIdGrupoAreaCritica" type="hidden" size="1" name="hIdGrupoAreaCritica" runat="server"><INPUT id="hIdAreaCritica" type="hidden" size="1" name="hIdAreaCritica" runat="server"><INPUT id="hNombreAreaCritica" type="hidden" size="1" name="hNombreAreaCritica" runat="server"><INPUT id="hNroGrupoAreaCritica" type="hidden" size="1" name="hNroGrupoAreaCritica" runat="server"><INPUT id="hNroAreaCritica" type="hidden" size="1" name="hNroAreaCritica" runat="server">
											</TD>
										</TR>
										<TR>
											<TD align="left" colSpan="7"><cc1:domvalidationsummary id="vSum" runat="server" Height="52px" EnableClientScript="False" DisplayMode="List"
													ShowMessageBox="True"></cc1:domvalidationsummary></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
