<%@ Page language="c#" Codebehind="PreDetalleRegistroProyectosCN.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.PreDetalleRegistroProyectosCN" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="COMMANDS"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Historico de Proyectos > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">PRE DETALLE REGISTRO PROYECTO CN</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table4" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="780" border="1">
							<TR>
								<TD bgColor="#000080" colSpan="3">
									<asp:label id="lblDatosGenerales" runat="server" CssClass="TituloPrincipalBlanco">DATOS PRINCIPALES</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 50px" bgColor="#335eb4">
									<asp:label id="lblNombre" runat="server" CssClass="TextoBlanco" Width="150px"> Nombre:</asp:label></TD>
								<TD style="WIDTH: 230px" bgColor="#f0f0f0">
									<asp:textbox id="txtNombre" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"
										MaxLength="200"></asp:textbox></TD>
								<TD align="center" colSpan="1" rowSpan="11">
									<asp:image id="imgProyecto" runat="server" Width="381px" Height="208px" ImageUrl="http://localhost/SimaNetWeb/imagenes/placa.gif"
										BorderColor="Transparent"></asp:image></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 50px" bgColor="#335eb4">
									<asp:label id="lblIdProyecto" runat="server" CssClass="TextoBlanco" Width="150px">ID PROYECTO:</asp:label></TD>
								<TD style="WIDTH: 230px" bgColor="#dddddd">
									<asp:textbox id="txtIdProyecto" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"
										MaxLength="12"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 50px" bgColor="#335eb4">
									<asp:label id="lbbNroProyecto" runat="server" CssClass="TextoBlanco" Width="150px">Nro. del C.O.:</asp:label></TD>
								<TD style="WIDTH: 230px" bgColor="#f0f0f0">
									<asp:textbox id="txtNroProyecto" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="12"
										Height="17px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 50px; HEIGHT: 18px" bgColor="#335eb4">
									<asp:label id="lnlCO" runat="server" CssClass="TextoBlanco" Width="150px">CENTRO OPERACIONES:</asp:label></TD>
								<TD class="normalDetalle" id="CellddlCentroOperativo" style="WIDTH: 230px; HEIGHT: 18px"
									bgColor="#dddddd" runat="server">
									<asp:dropdownlist id="ddlCentroOperativo" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 50px; HEIGHT: 11px" bgColor="#335eb4">
									<asp:label id="lblMatricula" runat="server" CssClass="TextoBlanco" Width="150px"> MATRICULA:</asp:label></TD>
								<TD style="WIDTH: 230px; HEIGHT: 11px" bgColor="#f0f0f0">
									<asp:textbox id="txtMatricula" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"
										MaxLength="20"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 50px; HEIGHT: 4px" bgColor="#335eb4">
									<asp:label id="lblCliente" runat="server" CssClass="TextoBlanco" Width="150px"> Cliente:</asp:label></TD>
								<TD class="normaldetalle" id="CelltxtRazonSocial" style="WIDTH: 230px" bgColor="#dddddd"
									runat="server">
									<asp:textbox id="txtRazonSocial" runat="server" CssClass="normaldetalle" Width="210px" Height="17px"></asp:textbox>
									<asp:imagebutton id="ibtnBuscarDependencia" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CausesValidation="False"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 50px" bgColor="#335eb4">
									<asp:label id="lblTipoProducto" runat="server" CssClass="TextoBlanco" Width="150px">LINEA DE PRODUCTO:</asp:label></TD>
								<TD class="normalDetalle" id="CellddlTipoProducto" style="WIDTH: 230px" bgColor="#f0f0f0"
									runat="server">
									<asp:dropdownlist id="ddlTipoProducto" runat="server" CssClass="normaldetalle" Width="230px" Height="24px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 50px; HEIGHT: 4px" bgColor="#335eb4">
									<asp:label id="lblTipoBuque" runat="server" CssClass="TextoBlanco" Width="150px">TIPO DE PRODUCTO:</asp:label></TD>
								<TD class="normalDetalle" id="CellddlTipoBuque" style="WIDTH: 230px; HEIGHT: 4px" bgColor="#dddddd"
									runat="server">
									<asp:dropdownlist id="ddlTipoBuque" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 50px" bgColor="#335eb4">
									<asp:label id="lblSubTipo" runat="server" CssClass="TextoBlanco" Width="150px">SUB - TIPO:</asp:label></TD>
								<TD style="WIDTH: 230px" bgColor="#f0f0f0">
									<asp:textbox id="txtSubTipo" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"
										MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 50px" bgColor="#335eb4">
									<asp:label id="lblClasficacion" runat="server" CssClass="TextoBlanco" Width="150px">CLASIFICACION:</asp:label></TD>
								<TD style="WIDTH: 230px" bgColor="#dddddd">
									<asp:textbox id="txtClasificacion" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"
										MaxLength="100"></asp:textbox></TD>
							</TR>
						</TABLE>
						<TABLE id="Table11" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="780" border="1">
							<TR>
								<TD bgColor="#000080" colSpan="4">
									<asp:label id="lblAspectosTecnicos" runat="server" CssClass="TituloPrincipalBlanco">ASPECTOS TECNICOS ADMINISTRATIVOS</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 130px" bgColor="#335eb4">
									<asp:label id="lblDWT" runat="server" CssClass="TextoBlanco" Width="150px" Font-Size="XX-Small">DWT:</asp:label></TD>
								<TD style="WIDTH: 229px" bgColor="#f0f0f0">
									<asp:textbox id="txtDWT" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"
										MaxLength="100"></asp:textbox></TD>
								<TD style="WIDTH: 92px" bgColor="#335eb4">
									<asp:label id="lblManga" runat="server" CssClass="TextoBlanco" Width="150px">MANGA (MTS):</asp:label></TD>
								<TD class="normalDetalle" id="CelltxtManga" bgColor="#f0f0f0" runat="server">
									<ew:numericbox id="txtManga" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"></ew:numericbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 130px" bgColor="#335eb4">
									<asp:label id="lblDesplazamiento" runat="server" CssClass="TextoBlanco" Width="150px" Height="2px"
										Font-Size="XX-Small">DESPLAZAMIENTO (TON):</asp:label></TD>
								<TD style="WIDTH: 229px" bgColor="#dddddd">
									<asp:textbox id="txtDesplazamiento" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"
										MaxLength="100"></asp:textbox></TD>
								<TD style="WIDTH: 92px" bgColor="#335eb4">
									<asp:label id="lblPuntual" runat="server" CssClass="TextoBlanco" Width="150px">PUNTAL (MTS):</asp:label></TD>
								<TD id="cELLtxtPuntal" bgColor="#dddddd" runat="server" class="normalDetalle">
									<ew:numericbox id="txtPuntal" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"></ew:numericbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 130px; HEIGHT: 20px" bgColor="#335eb4">
									<asp:label id="lblCapBod" runat="server" CssClass="TextoBlanco" Width="150px" Font-Size="XX-Small">CAPACIDAD DE BODEGA:</asp:label></TD>
								<TD style="WIDTH: 229px; HEIGHT: 20px" bgColor="#f0f0f0">
									<asp:textbox id="txtCapBod" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"
										MaxLength="100"></asp:textbox></TD>
								<TD style="WIDTH: 92px; HEIGHT: 20px" bgColor="#335eb4">
									<asp:label id="lblVelocidad" runat="server" CssClass="TextoBlanco" Width="150px">VELOCIDAD:</asp:label></TD>
								<TD style="HEIGHT: 20px" bgColor="#f0f0f0">
									<asp:textbox id="txtVelocidad" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"
										MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 130px" bgColor="#335eb4">
									<asp:label id="lblEmpuje" runat="server" CssClass="TextoBlanco" Width="150px" Height="10px"
										Font-Size="XX-Small">EMPUJE O FUERZA:</asp:label></TD>
								<TD style="WIDTH: 229px" bgColor="#dddddd">
									<asp:textbox id="txtEmpuje" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"
										MaxLength="100"></asp:textbox></TD>
								<TD style="WIDTH: 92px" bgColor="#335eb4">
									<asp:label id="lblFirmaAcuerdo" runat="server" CssClass="TextoBlanco" Width="93px">fECHA Acuerdo:</asp:label></TD>
								<TD class="normaldetalle" id="CellcalFechaFirmaAcuerdo" bgColor="#dddddd" runat="server">
									<ew:calendarpopup id="calFechaFirmaAcuerdo" runat="server" CssClass="combos" Width="210px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)"
										PadSingleDigits="True" ClearDateText="Limpiar Fecha" GoToTodayText="Fecha de Hoy" Nullable="True"
										NullableLabelText=" " AutoPostBack="True">
										<TextboxLabelStyle CssClass="normaldetalle"></TextboxLabelStyle>
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
							</TR>
							<TR>
								<TD style="WIDTH: 130px" bgColor="#335eb4">
									<asp:label id="lblMaterialCasco" runat="server" CssClass="TextoBlanco" Width="150px" Height="14px"
										Font-Size="XX-Small">Material de Casco:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlMaterailCasco" style="WIDTH: 229px" bgColor="#f0f0f0"
									runat="server">
									<asp:dropdownlist id="ddlMaterailCasco" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 92px" bgColor="#335eb4">
									<asp:label id="lblInicioreal" runat="server" CssClass="TextoBlanco" Width="104px">PUESTA DE QUILLA:</asp:label></TD>
								<TD class="normaldetalle" id="CellcalPuestaQuilla" bgColor="#f0f0f0" runat="server">
									<ew:calendarpopup id="calPuestaQuilla" runat="server" CssClass="combos" Width="210px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)"
										PadSingleDigits="True" ClearDateText="Limpiar Fecha" GoToTodayText="Fecha de Hoy" Nullable="True"
										NullableLabelText=" " AutoPostBack="True">
										<TextboxLabelStyle CssClass="normaldetalle"></TextboxLabelStyle>
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
							</TR>
							<TR>
								<TD style="WIDTH: 130px" bgColor="#335eb4">
									<asp:label id="lblTonProcesadas" runat="server" CssClass="TextoBlanco" Width="150px" Font-Size="XX-Small">TON. PROCESADAS:</asp:label></TD>
								<TD class="normaldetalle" style="WIDTH: 229px" bgColor="#dddddd">
									<asp:textbox id="txtTonProcesadas" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"
										MaxLength="100"></asp:textbox></TD>
								<TD style="WIDTH: 92px" bgColor="#335eb4">
									<asp:label id="lblFinReal" runat="server" CssClass="TextoBlanco" Width="56px">LANZAMIENTO:</asp:label></TD>
								<TD class="normaldetalle" id="CellcalFechaLanzamiento" bgColor="#dddddd" runat="server">
									<ew:calendarpopup id="calFechaLanzamiento" runat="server" CssClass="combos" Width="210px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)"
										PadSingleDigits="True" ClearDateText="Limpiar Fecha" GoToTodayText="Fecha de Hoy" Nullable="True"
										NullableLabelText=" " AutoPostBack="True">
										<TextboxLabelStyle CssClass="normaldetalle"></TextboxLabelStyle>
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
							</TR>
							<TR>
								<TD style="WIDTH: 130px" bgColor="#335eb4">
									<asp:label id="lblEslora" runat="server" CssClass="TextoBlanco" Width="150px">ESLORA (MTS) :</asp:label></TD>
								<TD class="normalDetalle" id="CelltxtEslora" style="WIDTH: 229px" bgColor="#f0f0f0"
									runat="server">
									<ew:numericbox id="txtEslora" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"></ew:numericbox></TD>
								<TD style="WIDTH: 92px" bgColor="#335eb4">
									<P>
										<asp:label id="lblTermino" runat="server" CssClass="TextoBlanco" Width="72px">ENTREGA :</asp:label></P>
								</TD>
								<TD class="normaldetalle" id="CellcalFechaEntrega" bgColor="#f0f0f0" runat="server">
									<ew:calendarpopup id="calFechaEntrega" runat="server" CssClass="combos" Width="210px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)"
										PadSingleDigits="True" ClearDateText="Limpiar Fecha" GoToTodayText="Fecha de Hoy" Nullable="True"
										NullableLabelText=" " AutoPostBack="True">
										<TextboxLabelStyle CssClass="normaldetalle"></TextboxLabelStyle>
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
							</TR>
						</TABLE>
						<TABLE id="Table2" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="780" border="1">
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><IMG id="btnDetalle" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/detalle.gif"
										runat="server"><INPUT id="hIdCliente" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="Hidden1"
										runat="server"><INPUT id="hFoto" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="Hidden1"
										runat="server"></TD>
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
