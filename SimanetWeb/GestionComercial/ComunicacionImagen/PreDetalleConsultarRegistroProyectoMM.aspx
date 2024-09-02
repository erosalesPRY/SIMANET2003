<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="PreDetalleConsultarRegistroProyectoMM.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.PreDetalleConsultarRegistroProyectoMM" %>
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
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Historico de Proyectos > Otros ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">PRE DETALLE REGISTRO PROYECTO PUENTES</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="778" border="1">
							<TR>
								<TD bgColor="#000080"><asp:label id="lblDatosGenerales" runat="server" CssClass="TituloPrincipalBlanco">DATOS PRINCIPALES</asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table2" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="778" border="1">
							<TR>
								<TD style="WIDTH: 81px" bgColor="#335eb4"><asp:label id="lblNombre" runat="server" CssClass="TextoBlanco" Width="120px"> Nombre:</asp:label></TD>
								<TD style="WIDTH: 245px" width="245" bgColor="#dddddd" colSpan="2"><asp:textbox id="txtNombre" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"
										MaxLength="100"></asp:textbox></TD>
								<TD bgColor="#dddddd" colSpan="1" rowSpan="13"><asp:image id="imgProyecto" runat="server" Width="368px" Height="235px" BorderColor="Transparent"
										ImageUrl="../../SimaNetWeb/imagenes/sinfoto.gif"></asp:image><INPUT class="normaldetalle" id="fFoto" style="WIDTH: 357px; HEIGHT: 17px" type="file"
										size="40" name="File2" runat="server"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 21px" bgColor="#335eb4"><asp:label id="lblIdProyecto" runat="server" CssClass="TextoBlanco" Width="150px">ID PROYECTO:</asp:label></TD>
								<TD style="WIDTH: 245px; HEIGHT: 21px" width="245" bgColor="#f0f0f0" colSpan="2"><asp:textbox id="txtIdProyecto" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"
										MaxLength="12"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px" bgColor="#335eb4"><asp:label id="lnlCO" runat="server" CssClass="TextoBlanco" Width="150px">CENTRO OPERACIONES:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlCentroOperativo" style="WIDTH: 245px; HEIGHT: 22px"
									width="245" bgColor="#dddddd" colSpan="2" runat="server"><asp:dropdownlist id="ddlCentroOperativo" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px" bgColor="#335eb4"><asp:label id="lblCliente" runat="server" CssClass="TextoBlanco" Width="150px"> Cliente:</asp:label></TD>
								<TD style="WIDTH: 245px" bgColor="#f0f0f0" colSpan="2"><asp:textbox id="txtRazonSocial" runat="server" CssClass="normaldetalle" Width="218px" Height="17px"></asp:textbox><asp:imagebutton id="ibtnBuscarDependencia" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"
										DESIGNTIMEDRAGDROP="123" CausesValidation="False"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 18px" bgColor="#335eb4"><asp:label id="lblTipoProducto" runat="server" CssClass="TextoBlanco" Width="150px">LINEA DE PRODUCTO:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlTipoProducto" style="WIDTH: 245px; HEIGHT: 18px"
									width="245" bgColor="#dddddd" colSpan="2" runat="server"><asp:dropdownlist id="ddlTipoProducto" runat="server" CssClass="normaldetalle" Width="238px" Height="24px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 15px" bgColor="#335eb4"><asp:label id="lblTipoBuque" runat="server" CssClass="TextoBlanco" Width="150px">TIPO DE PRODUCTO:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlTipoBuque" style="WIDTH: 245px; HEIGHT: 15px" width="245"
									bgColor="#f0f0f0" colSpan="2" runat="server"><asp:dropdownlist id="ddlTipoBuque" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px" bgColor="#335eb4"><asp:label id="lblSubTipo" runat="server" CssClass="TextoBlanco" Width="150px">SUB - TIPO:</asp:label></TD>
								<TD style="WIDTH: 245px" width="245" bgColor="#dddddd" colSpan="2"><asp:textbox id="txtSubTipo" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"
										MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 399px" bgColor="#000080" colSpan="3"><asp:label id="lblUbigeo" runat="server" CssClass="TituloPrincipalBlanco">UBICACION</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px" bgColor="#335eb4"><asp:label id="lblTipoCliente" runat="server" CssClass="TextoBlanco" Width="150px"> PROCEDENCIA:</asp:label></TD>
								<TD class="normalDetalle" id="CellRadio" style="WIDTH: 245px" width="245" bgColor="#f0f0f0"
									colSpan="2" runat="server"><asp:radiobutton id="rbtPeruano" runat="server" CssClass="normalDetalle" AutoPostBack="True" Text="NACIONAL"></asp:radiobutton>&nbsp;
									<asp:radiobutton id="rbtExtranjero" runat="server" CssClass="normaldetalle" AutoPostBack="True" Text="Extranjero"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px" bgColor="#335eb4"><asp:label id="Label20" runat="server" CssClass="TextoBlanco" Width="150px">localidad:</asp:label></TD>
								<TD style="WIDTH: 245px" width="245" bgColor="#dddddd" colSpan="2"><asp:textbox id="txtLocalidad" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="lblLugartres" runat="server" CssClass="TextoBlanco" Width="150px">provincia:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlProvincia" width="245" bgColor="#f0f0f0" colSpan="2"
									runat="server"><asp:dropdownlist id="ddlProvincia" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px" bgColor="#335eb4"><asp:label id="lblLugardos" runat="server" CssClass="TextoBlanco" Width="150px">region:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlRegion" style="WIDTH: 245px" width="245" bgColor="#dddddd"
									colSpan="2" runat="server"><asp:dropdownlist id="ddlRegion" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px" bgColor="#335eb4"><asp:label id="lblLugarUno" runat="server" CssClass="TextoBlanco" Width="150px">PAIS:</asp:label></TD>
								<TD class="normaldetalle" id="CelldllPais" style="WIDTH: 245px" width="245" bgColor="#f0f0f0"
									colSpan="2" runat="server"><asp:dropdownlist id="dllPais" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
						<TABLE id="Table5" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="778" border="1">
							<TR>
								<TD bgColor="#000080" colSpan="4"><asp:label id="lblTituloAspectosTecnicos" runat="server" CssClass="TituloPrincipalBlanco">ASPECTOS TECNICOS</asp:label></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" style="HEIGHT: 16px"><asp:label id="Label3" runat="server" CssClass="TextoBlanco" Width="112px">LUZ (MTS):</asp:label></TD>
								<TD bgColor="#dddddd" class="normalDetalle" id="CelltxtLuz" runat="server" style="HEIGHT: 16px"><ew:numericbox id="txtLuz" runat="server" CssClass="normaldetalle" Width="238px" MaxLength="5"
										DecimalPlaces="2" PositiveNumber="True"></ew:numericbox></TD>
								<TD bgColor="#335eb4" style="HEIGHT: 16px"><asp:label id="lblMaterial" runat="server" CssClass="TextoBlanco" Width="150px">MATERIAL:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlMaterial" bgColor="#dddddd" runat="server" style="HEIGHT: 16px">
									<asp:dropdownlist id="ddlMaterial" runat="server" CssClass="normaldetalle" Width="100%" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="lblTramos" runat="server" CssClass="TextoBlanco" Width="112px">Tramos:</asp:label></TD>
								<TD bgColor="#f0f0f0"><asp:textbox id="txtTramos" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
								<TD bgColor="#335eb4"><asp:label id="Label18" runat="server" CssClass="TextoBlanco" Width="150px">PESO NETO (TON):</asp:label></TD>
								<TD bgColor="#f0f0f0" runat="server" class="normalDetalle" id="CelltxtPesoNeto"><ew:numericbox id="txtPesoNeto" runat="server" CssClass="normaldetalle" Width="220px" MaxLength="5"
										DecimalPlaces="2" PositiveNumber="True"></ew:numericbox></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="Label4" runat="server" CssClass="TextoBlanco" Width="112px">Vias:</asp:label></TD>
								<TD bgColor="#dddddd"><asp:textbox id="txtVias" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
								<TD bgColor="#335eb4"><asp:label id="lblFirmaAcuerdo" runat="server" CssClass="TextoBlanco" Width="104px">Fecha Acuerdo:</asp:label></TD>
								<TD class="normaldetalle" id="CellcalFechaFirmaAcuerdo" bgColor="#dddddd" runat="server"><ew:calendarpopup id="calFechaFirmaAcuerdo" runat="server" CssClass="combos" Width="200px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										AutoPostBack="True" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage"
										ShowGoToToday="True" AllowArbitraryText="False">
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
								<TD bgColor="#335eb4"><asp:label id="Label5" runat="server" CssClass="TextoBlanco" Width="112px">Ancho (mts):</asp:label></TD>
								<TD bgColor="#f0f0f0" class="normalDetalle" id="CelltxtAncho" runat="server"><ew:numericbox id="txtAncho" runat="server" CssClass="normaldetalle" Width="238px" MaxLength="5"
										DecimalPlaces="2" PositiveNumber="True"></ew:numericbox></TD>
								<TD bgColor="#335eb4"><asp:label id="lblInicioreal" runat="server" CssClass="TextoBlanco" Width="100px">Inicio Real:</asp:label></TD>
								<TD class="normalDetalle" id="CellcalFechaInicioReal" bgColor="#f0f0f0" runat="server"><ew:calendarpopup id="calFechaInicioReal" runat="server" CssClass="combos" Width="200px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										AutoPostBack="True" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage"
										ShowGoToToday="True" AllowArbitraryText="False">
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
								<TD bgColor="#335eb4"><asp:label id="Label6" runat="server" CssClass="TextoBlanco" Width="136px">Ancho Rodadura (mts):</asp:label></TD>
								<TD bgColor="#dddddd" class="normalDetalle" id="CelltxtAnchoRodadura" runat="server"><ew:numericbox id="txtAnchoRodadura" runat="server" CssClass="normaldetalle" Width="238px" MaxLength="5"
										DecimalPlaces="2" PositiveNumber="True"></ew:numericbox></TD>
								<TD bgColor="#335eb4"><asp:label id="lblFinReal" runat="server" CssClass="TextoBlanco" Width="100px">fin Real:</asp:label></TD>
								<TD class="normalDetalle" id="CellcalFechaFinReal" bgColor="#dddddd" runat="server"><ew:calendarpopup id="calFechaFinReal" runat="server" CssClass="combos" Width="200px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										AutoPostBack="True" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage"
										ShowGoToToday="True" AllowArbitraryText="False">
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
								<TD bgColor="#335eb4"><asp:label id="lblCapacidad" runat="server" CssClass="TextoBlanco" Width="150px">SobreCarga:</asp:label></TD>
								<TD bgColor="#f0f0f0"><asp:textbox id="txtSobreCarga" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
								<TD bgColor="#335eb4"><asp:label id="lblFechaEntrega" runat="server" CssClass="TextoBlanco" Width="100px">ENTREGA :</asp:label></TD>
								<TD class="normaldetalle" id="CellcalFechaEntrega" bgColor="#f0f0f0" runat="server"><ew:calendarpopup id="calFechaEntrega" runat="server" CssClass="combos" Width="200px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										AutoPostBack="True" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage"
										ShowGoToToday="True" AllowArbitraryText="False">
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
						<TABLE id="Table4" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="778" border="1">
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><IMG id="btnDetalle" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/detalle.gif"
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
