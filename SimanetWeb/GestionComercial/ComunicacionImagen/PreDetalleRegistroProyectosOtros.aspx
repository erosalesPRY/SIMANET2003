<%@ Page language="c#" Codebehind="PreDetalleRegistroProyectosOtros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.PreDetalleRegistroProyectosOtros" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc2" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
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
			<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc2:header id="Header1" runat="server"></uc2:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Historico de Proyectos > Otros ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">DETALLE REGISTRO PROYECTO MM OTROS</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="779" border="1">
							<TR>
								<TD bgColor="#000080" colSpan="3"><asp:label id="lblDatosGenerales" runat="server" CssClass="TituloPrincipalBlanco">DATOS PRINCIPALES</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 77px" bgColor="#335eb4"><asp:label id="lblNombre" runat="server" CssClass="TextoBlanco" Width="140px"> Nombre:</asp:label></TD>
								<TD style="WIDTH: 240px" width="240" bgColor="#dddddd"><asp:textbox id="txtNombre" runat="server" CssClass="normaldetalle" Width="238px" MaxLength="100"
										Height="17px"></asp:textbox></TD>
								<TD bgColor="#dddddd" colSpan="1" rowSpan="13"><asp:image id="imgProyecto" runat="server" Width="384px" Height="263px" BorderColor="Transparent"
										ImageUrl="sinfoto.gif"></asp:image></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 77px; HEIGHT: 21px" bgColor="#335eb4"><asp:label id="lblIdProyecto" runat="server" CssClass="TextoBlanco" Width="140px">ID PROYECTO:</asp:label></TD>
								<TD style="WIDTH: 240px; HEIGHT: 21px" width="240" bgColor="#f0f0f0"><asp:textbox id="txtIdProyecto" runat="server" CssClass="normaldetalle" Width="238px" MaxLength="12"
										Height="17px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 77px" bgColor="#335eb4"><asp:label id="lnlCO" runat="server" CssClass="TextoBlanco" Width="140px">CENTRO OPERACIONES:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlCentroOperativo" style="WIDTH: 240px; HEIGHT: 22px"
									width="240" bgColor="#dddddd" runat="server"><asp:dropdownlist id="ddlCentroOperativo" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 77px" bgColor="#335eb4"><asp:label id="lblCliente" runat="server" CssClass="TextoBlanco" Width="140px"> Cliente:</asp:label></TD>
								<TD style="WIDTH: 240px" bgColor="#f0f0f0"><asp:textbox id="txtRazonSocial" runat="server" CssClass="normaldetalle" Width="218px" Height="17px"
										ReadOnly="True"></asp:textbox><asp:imagebutton id="ibtnBuscarDependencia" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CausesValidation="False" DESIGNTIMEDRAGDROP="123"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 77px; HEIGHT: 13px" bgColor="#335eb4"><asp:label id="lblTipoProducto" runat="server" CssClass="TextoBlanco" Width="140px">LINEA DE PRODUCTO:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlTipoProducto" style="WIDTH: 240px; HEIGHT: 13px"
									width="240" bgColor="#dddddd" runat="server"><asp:dropdownlist id="ddlTipoProducto" runat="server" CssClass="normaldetalle" Width="238px" Height="24px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 77px" bgColor="#335eb4"><asp:label id="lblTipoBuque" runat="server" CssClass="TextoBlanco" Width="140px">TIPO DE PRODUCTO:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlTipoBuque" style="WIDTH: 240px" width="240" bgColor="#f0f0f0"
									runat="server"><asp:dropdownlist id="ddlTipoBuque" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 77px" bgColor="#335eb4"><asp:label id="lblSubTipo" runat="server" CssClass="TextoBlanco" Width="140px">SUB - TIPO:</asp:label></TD>
								<TD style="WIDTH: 240px" width="240" bgColor="#dddddd"><asp:textbox id="txtSubTipo" runat="server" CssClass="normaldetalle" Width="238px" MaxLength="50"
										Height="17px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 387px" bgColor="#000080" colSpan="2"><asp:label id="lblUbigeo" runat="server" CssClass="TituloPrincipalBlanco">UBICACION</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 77px" bgColor="#335eb4"><asp:label id="lblTipoCliente" runat="server" CssClass="TextoBlanco" Width="140px"> PROCEDENCIA:</asp:label></TD>
								<TD id="CellRadio" style="WIDTH: 240px" width="240" bgColor="#f0f0f0" runat="server"
									class="normaldetalle"><asp:radiobutton id="rbtPeruano" runat="server" CssClass="normalDetalle" Text="NACIONAL" AutoPostBack="True"></asp:radiobutton>&nbsp;
									<asp:radiobutton id="rbtExtranjero" runat="server" CssClass="normaldetalle" Text="Extranjero" AutoPostBack="True"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 77px" bgColor="#335eb4"><asp:label id="Label3" runat="server" CssClass="TextoBlanco" Width="140px">LOCALIDAD:</asp:label></TD>
								<TD style="WIDTH: 240px" width="240" bgColor="#dddddd"><asp:textbox id="txtLocalidad" runat="server" CssClass="normaldetalle" Width="238px" MaxLength="50"
										Height="17px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="lblLugartres" runat="server" CssClass="TextoBlanco" Width="140px">provincia:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlProvincia" width="240" bgColor="#f0f0f0" runat="server"><asp:dropdownlist id="ddlProvincia" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 77px; HEIGHT: 10px" bgColor="#335eb4"><asp:label id="lblLugardos" runat="server" CssClass="TextoBlanco" Width="140px">region:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlRegion" style="WIDTH: 240px; HEIGHT: 10px" width="240"
									bgColor="#dddddd" runat="server"><asp:dropdownlist id="ddlRegion" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 77px" bgColor="#335eb4"><asp:label id="lblLugarUno" runat="server" CssClass="TextoBlanco" Width="140px">PAIS:</asp:label></TD>
								<TD class="normaldetalle" id="CelldllPais" style="WIDTH: 240px" width="240" bgColor="#f0f0f0"
									runat="server"><asp:dropdownlist id="dllPais" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
						<TABLE id="Table1" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="779" border="1">
							<TR>
								<TD bgColor="#000080" colSpan="4"><asp:label id="lblTituloAspectosTecnicos" runat="server" CssClass="TituloPrincipalBlanco">ASPECTOS TECNICOS ADMINISTRATIVOS</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 123px" bgColor="#335eb4"><asp:label id="lblTramos" runat="server" CssClass="TextoBlanco" Width="140px">Cantidad ó Tramos:</asp:label></TD>
								<TD style="WIDTH: 173px" bgColor="#dddddd"><asp:textbox id="txtTramos" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 99px" bgColor="#335eb4"><asp:label id="lblTipoMaterial" runat="server" CssClass="TextoBlanco" Width="140px">TIPO MATERIAL:</asp:label></TD>
								<TD bgColor="#dddddd"><asp:textbox id="txtTipoMaterial" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 123px" bgColor="#335eb4"><asp:label id="lblCapacidad" runat="server" CssClass="TextoBlanco" Width="140px">CAPACIDAD:</asp:label></TD>
								<TD style="WIDTH: 173px" bgColor="#f0f0f0"><asp:textbox id="txtCapacidad" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 99px" bgColor="#335eb4"><asp:label id="lblPesoNeto" runat="server" CssClass="TextoBlanco" Width="140px">Peso Neto (TON):</asp:label></TD>
								<TD bgColor="#f0f0f0" class="normalDetalle" id="CelltxtPesoNeto" runat="server"><ew:numericbox id="txtPesoNeto" runat="server" CssClass="normaldetalle" Width="238px" MaxLength="5"
										PositiveNumber="True" DecimalPlaces="2"></ew:numericbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 123px" bgColor="#335eb4"><asp:label id="lblDimension" runat="server" CssClass="TextoBlanco" Width="140px">DIMENSION:</asp:label></TD>
								<TD style="WIDTH: 173px" bgColor="#dddddd"><asp:textbox id="txtDimesion" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 99px" bgColor="#335eb4"><asp:label id="lblFirmaAcuerdo" runat="server" CssClass="TextoBlanco" Width="140px">Fecha Acuerdo:</asp:label></TD>
								<TD class="normaldetalle" id="CeldacalFechaFirmaAcuerdo" bgColor="#dddddd" runat="server"><ew:calendarpopup id="calFechaFirmaAcuerdo" runat="server" CssClass="combos" Width="218px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True" ClearDateText="Limpiar Fecha" GoToTodayText="Fecha de Hoy"
										Nullable="True" NullableLabelText=" ">
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
								<TD style="WIDTH: 123px" bgColor="#335eb4"><asp:label id="lblDiametro" runat="server" CssClass="TextoBlanco" Width="140px">diametro:</asp:label></TD>
								<TD style="WIDTH: 173px" bgColor="#f0f0f0"><asp:textbox id="txtDiametro" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 99px" bgColor="#335eb4"><asp:label id="lblInicioreal" runat="server" CssClass="TextoBlanco" Width="140px">Inicio Real:</asp:label></TD>
								<TD class="normaldetalle" id="CeldacalFechaInicioReal" bgColor="#f0f0f0" runat="server"><ew:calendarpopup id="calFechaInicioReal" runat="server" CssClass="combos" Width="218px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										AutoPostBack="True" AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True" ClearDateText="Limpiar Fecha" GoToTodayText="Fecha de Hoy"
										Nullable="True" NullableLabelText=" ">
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
								<TD style="WIDTH: 123px" bgColor="#335eb4"><asp:label id="lblEspesor" runat="server" CssClass="TextoBlanco" Width="140px">espesor:</asp:label></TD>
								<TD style="WIDTH: 173px" bgColor="#dddddd"><asp:textbox id="txtEspesor" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 99px" bgColor="#335eb4"><asp:label id="lblFinReal" runat="server" CssClass="TextoBlanco" Width="140px">fin Real:</asp:label></TD>
								<TD class="normaldetalle" id="CellcalFechaFinReal" bgColor="#dddddd" runat="server"><ew:calendarpopup id="calFechaFinReal" runat="server" CssClass="combos" Width="218px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										AutoPostBack="True" AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True" ClearDateText="Limpiar Fecha"
										GoToTodayText="Fecha de Hoy" Nullable="True" NullableLabelText=" ">
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
								<TD style="WIDTH: 123px; HEIGHT: 14px" bgColor="#335eb4"><asp:label id="lblMaterial" runat="server" CssClass="TextoBlanco" Width="140px">MATERIAL:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlMaterial" style="WIDTH: 173px; HEIGHT: 14px" bgColor="#f0f0f0"
									runat="server"><asp:dropdownlist id="ddlMaterial" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 99px; HEIGHT: 14px" bgColor="#335eb4"><asp:label id="lblTermino" runat="server" CssClass="TextoBlanco" Width="140px">ENTREGA :</asp:label></TD>
								<TD class="normaldetalle" id="CellcalFechaEntrega" style="HEIGHT: 14px" bgColor="#f0f0f0"
									runat="server"><ew:calendarpopup id="calFechaEntrega" runat="server" CssClass="combos" Width="218px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True"
										ClearDateText="Limpiar Fecha" GoToTodayText="Fecha de Hoy" Nullable="True" NullableLabelText=" ">
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
								<TD colSpan="4"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><IMG id="btnDetalle" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/detalle.gif"
										runat="server"><INPUT id="hIdCliente" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="Hidden1"
										runat="server"><INPUT id="hFoto" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="Hidden1"
										runat="server"><INPUT id="hIdJefeProyecto" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="hPresupuesto"
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
