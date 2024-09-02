<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalleRegistroProyectosOtros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.DetalleRegistroProyectosOtros" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 24px"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Historico de Proyectos > Otros ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">DETALLE REGISTRO PROYECTO MM OTROS</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="780" border="1">
							<TR>
								<TD bgColor="#000080"><asp:label id="lblDatosGenerales" runat="server" CssClass="TituloPrincipalBlanco">DATOS PRINCIPALES</asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table2" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="780" border="1">
							<TR>
								<TD style="WIDTH: 144px" bgColor="#335eb4"><asp:label id="lblNombre" runat="server" CssClass="TextoBlanco" Width="140px"> Nombre:</asp:label></TD>
								<TD width="245" bgColor="#dddddd"><asp:textbox id="txtNombre" runat="server" CssClass="normaldetalle" Width="233px" Height="17px"
										MaxLength="100"></asp:textbox>
									<cc2:RequiredDomValidator id="rfvNombreBuque" runat="server" ControlToValidate="txtNombre" ErrorMessage="Ingrese el nombre del proyecto">*</cc2:RequiredDomValidator></TD>
								<TD align="left" bgColor="#dddddd" colSpan="1" rowSpan="13"><asp:image id="imgProyecto" runat="server" Width="384px" Height="246px" ImageUrl="sinfoto.gif"
										BorderColor="Transparent"></asp:image><BR>
									<INPUT class="normaldetalle" id="fFoto" style="WIDTH: 376px; HEIGHT: 17px" type="file"
										size="43" name="File2" runat="server"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px; HEIGHT: 21px" bgColor="#335eb4">
									<asp:label id="lblIdProyecto" runat="server" CssClass="TextoBlanco" Width="140px">ID PROYECTO:</asp:label></TD>
								<TD width="245" bgColor="#f0f0f0">
									<asp:textbox id="txtIdProyecto" runat="server" CssClass="normaldetalle" Width="232px" MaxLength="12"
										Height="17px"></asp:textbox>
									<cc2:RequiredDomValidator id="rfvIdProyecto" runat="server" ControlToValidate="txtIdProyecto" ErrorMessage="Ingrese el ID del proyecto">*</cc2:RequiredDomValidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px" bgColor="#335eb4">
									<asp:label id="lnlCO" runat="server" CssClass="TextoBlanco" Width="140px">CENTRO OPERACIONES:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlCentroOperativo" style="WIDTH: 245px; HEIGHT: 22px"
									width="245" bgColor="#dddddd" runat="server">
									<asp:dropdownlist id="ddlCentroOperativo" runat="server" CssClass="normaldetalle" Width="236px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px" bgColor="#335eb4">
									<asp:label id="lblCliente" runat="server" CssClass="TextoBlanco" Width="140px"> Cliente:</asp:label></TD>
								<TD bgColor="#f0f0f0">
									<asp:textbox id="txtRazonSocial" runat="server" CssClass="normaldetalle" Width="216px" Height="17px"
										ReadOnly="True"></asp:textbox>
									<asp:imagebutton id="ibtnBuscarDependencia" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CausesValidation="False" DESIGNTIMEDRAGDROP="123"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px; HEIGHT: 13px" bgColor="#335eb4">
									<asp:label id="lblTipoProducto" runat="server" CssClass="TextoBlanco" Width="140px">LINEA DE PRODUCTO:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlTipoProducto" style="WIDTH: 245px; HEIGHT: 13px"
									width="245" bgColor="#dddddd" runat="server">
									<asp:dropdownlist id="ddlTipoProducto" runat="server" CssClass="normaldetalle" Width="236px" Height="24px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px" bgColor="#335eb4">
									<asp:label id="lblTipoBuque" runat="server" CssClass="TextoBlanco" Width="140px">TIPO DE PRODUCTO:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlTipoBuque" style="WIDTH: 245px" width="245" bgColor="#f0f0f0"
									runat="server">
									<asp:dropdownlist id="ddlTipoBuque" runat="server" CssClass="normaldetalle" Width="236px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px" bgColor="#335eb4">
									<asp:label id="lblSubTipo" runat="server" CssClass="TextoBlanco" Width="140px">SUB - TIPO:</asp:label></TD>
								<TD style="WIDTH: 245px" width="245" bgColor="#dddddd">
									<asp:textbox id="txtSubTipo" runat="server" CssClass="normaldetalle" Width="236px" MaxLength="50"
										Height="17px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 389px" bgColor="#000080" colSpan="2"><asp:label id="lblUbigeo" runat="server" CssClass="TituloPrincipalBlanco">UBICACION</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px" bgColor="#335eb4"><asp:label id="lblTipoCliente" runat="server" CssClass="TextoBlanco" Width="140px"> DESTINO:</asp:label></TD>
								<TD class="normalDetalle" id="CellRadio" width="245" bgColor="#f0f0f0" runat="server"><asp:radiobutton id="rbtPeruano" runat="server" CssClass="normalDetalle" AutoPostBack="True" Text="NACIONAL"></asp:radiobutton>&nbsp;
									<asp:radiobutton id="rbtExtranjero" runat="server" CssClass="normaldetalle" AutoPostBack="True" Text="Extranjero"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px" bgColor="#335eb4"><asp:label id="Label3" runat="server" CssClass="TextoBlanco" Width="140px">LOCALIDAD:</asp:label></TD>
								<TD width="245" bgColor="#dddddd"><asp:textbox id="txtLocalidad" runat="server" CssClass="normaldetalle" Width="236px" Height="17px"
										MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px; HEIGHT: 20px" bgColor="#335eb4"><asp:label id="lblLugartres" runat="server" CssClass="TextoBlanco" Width="140px">provincia:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlProvincia" width="245" bgColor="#f0f0f0" runat="server"><asp:dropdownlist id="ddlProvincia" runat="server" CssClass="normaldetalle" Width="236px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 146px" bgColor="#335eb4"><asp:label id="lblLugardos" runat="server" CssClass="TextoBlanco" Width="140px">region:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlRegion" width="245" bgColor="#dddddd" runat="server"><asp:dropdownlist id="ddlRegion" runat="server" CssClass="normaldetalle" Width="236px" Height="17px"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 146px" bgColor="#335eb4"><asp:label id="lblLugarUno" runat="server" CssClass="TextoBlanco" Width="140px">PAIS:</asp:label></TD>
								<TD class="normaldetalle" id="CelldllPais" width="245" bgColor="#f0f0f0" runat="server">
									<asp:dropdownlist id="dllPais" runat="server" CssClass="normaldetalle" Width="236px" Height="17px"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
						<TABLE id="Table7" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="780" border="1">
							<TR>
								<TD bgColor="#000080" colSpan="6"><asp:label id="lblTituloAspectosTecnicos" runat="server" CssClass="TituloPrincipalBlanco">ASPECTOS TECNICOS</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25px; HEIGHT: 14px" bgColor="#335eb4"><asp:label id="lblTramos" runat="server" CssClass="TextoBlanco" Width="140px">Cantidad ó Tramos:</asp:label></TD>
								<TD style="HEIGHT: 14px" width="245" bgColor="#dddddd"><asp:textbox id="txtTramos" runat="server" CssClass="normalDetalle" Width="236px" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 12px; HEIGHT: 14px" bgColor="#335eb4"><asp:label id="lblMaterial" runat="server" CssClass="TextoBlanco" Width="140px">MATERIAL:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlMaterial" bgColor="#dddddd" runat="server"><asp:dropdownlist id="ddlMaterial" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25px; HEIGHT: 23px" bgColor="#335eb4"><asp:label id="lblCapacidad" runat="server" CssClass="TextoBlanco" Width="140px">CAPACIDAD:</asp:label></TD>
								<TD width="245" bgColor="#f0f0f0"><asp:textbox id="txtCapacidad" runat="server" CssClass="normalDetalle" Width="236px" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 12px; HEIGHT: 23px" bgColor="#335eb4"><asp:label id="lblTipoMaterial" runat="server" CssClass="TextoBlanco" Width="140px">TIPO MATERIAL:</asp:label></TD>
								<TD bgColor="#f0f0f0"><asp:textbox id="txtTipoMaterial" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25px" bgColor="#335eb4"><asp:label id="lblDimension" runat="server" CssClass="TextoBlanco" Width="140px">DIMENSION:</asp:label></TD>
								<TD width="245" bgColor="#dddddd"><asp:textbox id="txtDimesion" runat="server" CssClass="normalDetalle" Width="236px" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 12px" bgColor="#335eb4"><asp:label id="lblPesoNeto" runat="server" CssClass="TextoBlanco" Width="140px">Peso Neto (TON):</asp:label></TD>
								<TD class="normalDetalle" id="CelltxtPesoNeto" bgColor="#dddddd" runat="server"><ew:numericbox id="txtPesoNeto" runat="server" CssClass="normaldetalle" Width="238px" MaxLength="5"
										DecimalPlaces="2" PositiveNumber="True"></ew:numericbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25px" bgColor="#335eb4"><asp:label id="lblDiametro" runat="server" CssClass="TextoBlanco" Width="140px">diametro:</asp:label></TD>
								<TD width="245" bgColor="#f0f0f0"><asp:textbox id="txtDiametro" runat="server" CssClass="normalDetalle" Width="236px" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 12px" bgColor="#335eb4"><asp:label id="lblPesoBruto" runat="server" CssClass="TextoBlanco" Width="140px">Peso Bruto (TON):</asp:label></TD>
								<TD class="normalDetalle" id="celltxtPesoBruto" bgColor="#f0f0f0" runat="server"><ew:numericbox id="txtPesoBruto" runat="server" CssClass="normaldetalle" Width="238px" MaxLength="5"
										DecimalPlaces="2" PositiveNumber="True"></ew:numericbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25px" bgColor="#335eb4"><asp:label id="lblEspesor" runat="server" CssClass="TextoBlanco" Width="140px">espesor:</asp:label></TD>
								<TD width="245" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtEspesor" runat="server" CssClass="normalDetalle" Width="236px" MaxLength="50"></asp:textbox></TD>
							</TR>
						</TABLE>
						<TABLE id="Table5" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="780" border="1">
							<TR>
								<TD style="WIDTH: 428px" bgColor="#000080" colSpan="6"><asp:label id="lblAspectosAdministrativos" runat="server" CssClass="TituloPrincipalBlanco"
										Width="216px">ASPECTOS ADMINISTRATIVOS</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 75px; HEIGHT: 27px" bgColor="#335eb4"><asp:label id="lblEstado" runat="server" CssClass="TextoBlanco" Width="140px">ESTADO:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlEstadoProyecto" width="245" bgColor="#dddddd" runat="server"><asp:dropdownlist id="ddlEstadoProyecto" runat="server" CssClass="normaldetalle" Width="236px" Height="17px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 50px; HEIGHT: 27px" bgColor="#335eb4"><asp:label id="lblJefeProyecto" runat="server" CssClass="TextoBlanco" Width="140px">JEFE DE PROYECTO:</asp:label></TD>
								<TD style="HEIGHT: 27px" bgColor="#dddddd"><asp:textbox id="txtJefeProyectos" runat="server" CssClass="normaldetalle" Width="218px" ReadOnly="True"></asp:textbox><asp:imagebutton id="ibtBuscaJefeProyectos" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CausesValidation="False"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 75px" bgColor="#335eb4"><asp:label id="lblDocumentoPrincipal" runat="server" CssClass="TextoBlanco" Width="140px">DOCUMENTO PRINCIPAL:</asp:label></TD>
								<TD width="245" bgColor="#f0f0f0"><asp:textbox id="txtDocumentoPrincipal" runat="server" CssClass="normalDetalle" Width="236px"
										MaxLength="100"></asp:textbox></TD>
								<TD style="WIDTH: 50px" bgColor="#335eb4"><asp:label id="lblFirmaAcuerdo" runat="server" CssClass="TextoBlanco" Width="140px">Fecha Acuerdo:</asp:label></TD>
								<TD class="normalDetalle" id="CeldacalFechaFirmaAcuerdo" bgColor="#f0f0f0" runat="server"><ew:calendarpopup id="calFechaFirmaAcuerdo" runat="server" CssClass="combos" Width="218px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CalendarLocation="Bottom" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage"
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
								<TD style="WIDTH: 75px; HEIGHT: 20px" bgColor="#335eb4"><asp:label id="lblTipoDocumento" runat="server" CssClass="TextoBlanco" Width="140px">TIPO DOCUMENTO:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlTipoDocumento" width="245" bgColor="#dddddd" runat="server"><asp:dropdownlist id="ddlTipoDocumento" runat="server" CssClass="normaldetalle" Width="236px" Height="17px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 50px" bgColor="#335eb4"><asp:label id="lblInicioContractual" runat="server" CssClass="TextoBlanco" Width="140px" Height="12px">Inicio ContracTUAL:</asp:label></TD>
								<TD class="normalDetalle" id="CellcalFechaInicioContractual" bgColor="#dddddd" runat="server"><ew:calendarpopup id="calFechaInicioContractual" runat="server" CssClass="combos" Width="218px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CalendarLocation="Bottom" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage"
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
								<TD style="WIDTH: 75px" bgColor="#335eb4"><asp:label id="lblOtroDocumento" runat="server" CssClass="TextoBlanco" Width="140px">Otro Documento:</asp:label></TD>
								<TD width="245" bgColor="#f0f0f0"><asp:textbox id="txtOtroDocumento" runat="server" CssClass="normalDetalle" Width="236px" MaxLength="100"></asp:textbox></TD>
								<TD style="WIDTH: 50px" bgColor="#335eb4"><asp:label id="lblFinContractual" runat="server" CssClass="TextoBlanco" Width="140px">Fin Contractual:</asp:label></TD>
								<TD class="normalDetalle" id="CellcalFechaFinContractual" bgColor="#f0f0f0" runat="server"><ew:calendarpopup id="calFechaFinContractual" runat="server" CssClass="combos" Width="218px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CalendarLocation="Bottom" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage"
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
								<TD style="WIDTH: 75px" bgColor="#335eb4"><asp:label id="lblOtroTipoDocumento" runat="server" CssClass="TextoBlanco" Width="140px">TIPO DOCUMENTO:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlOtroTipoDocumento" width="245" bgColor="#dddddd"
									runat="server"><asp:dropdownlist id="ddlOtroTipoDocumento" runat="server" CssClass="normaldetalle" Width="236px"
										Height="17px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 50px" bgColor="#335eb4"><asp:label id="lblInicioreal" runat="server" CssClass="TextoBlanco" Width="140px">Inicio Real:</asp:label></TD>
								<TD class="normalDetalle" id="CeldacalFechaInicioReal" bgColor="#dddddd" runat="server"><ew:calendarpopup id="calFechaInicioReal" runat="server" CssClass="combos" Width="218px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										AutoPostBack="True" CalendarLocation="Bottom" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True" Culture="Spanish (Chile)"
										ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False">
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
								<TD style="WIDTH: 75px" bgColor="#335eb4"><asp:label id="lblPrecioContractual" runat="server" CssClass="TextoBlanco" Width="140px">PRECIO CONTRACUAL</asp:label></TD>
								<TD class="normalDetalle" id="CelltxtPrecioContractual" style="WIDTH: 244px" bgColor="#f0f0f0"
									runat="server">
									<ew:numericbox id="txtPrecioContractual" runat="server" CssClass="normaldetalle" Width="238px"
										MaxLength="15" PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="11" DollarSign=" "
										AutoFormatCurrency="True"></ew:numericbox></TD>
								<TD style="WIDTH: 50px" bgColor="#335eb4"><asp:label id="lblFinReal" runat="server" CssClass="TextoBlanco" Width="140px">fin Real:</asp:label></TD>
								<TD class="normalDetalle" id="CellcalFechaFinReal" bgColor="#f0f0f0" runat="server"><ew:calendarpopup id="calFechaFinReal" runat="server" CssClass="combos" Width="218px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										AutoPostBack="True" CalendarLocation="Bottom" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True" Culture="Spanish (Chile)"
										ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False">
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
								<TD style="WIDTH: 75px" bgColor="#335eb4"><asp:label id="Label1" runat="server" CssClass="TextoBlanco" Width="140px">PRECIO REAL:</asp:label></TD>
								<TD class="normalDetalle" id="CelltxtPrecioReal" width="245" bgColor="#dddddd" runat="server">
									<ew:numericbox id="txtPrecioReal" runat="server" CssClass="normaldetalle" Width="238px" MaxLength="15"
										PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="11" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox></TD>
								<TD style="WIDTH: 50px" bgColor="#335eb4"><asp:label id="lblTermino" runat="server" CssClass="TextoBlanco" Width="140px">ENTREGA :</asp:label></TD>
								<TD class="normalDetalle" id="CellcalFechaEntrega" bgColor="#dddddd" runat="server"><ew:calendarpopup id="calFechaEntrega" runat="server" CssClass="combos" Width="218px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CalendarLocation="Bottom" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage"
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
								<TD style="WIDTH: 75px" bgColor="#335eb4"><asp:label id="lblIdMoneda" runat="server" CssClass="TextoBlanco" Width="140px">MONEDA:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlMoneda" width="245" bgColor="#f0f0f0" runat="server"><asp:dropdownlist id="ddlMoneda" runat="server" CssClass="normaldetalle" Width="236px" Height="17px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 50px" bgColor="#335eb4"><asp:label id="lblEjecucion" runat="server" CssClass="TextoBlanco" Width="140px">Ejecucion (DIAS):</asp:label></TD>
								<TD class="normaldetalle" bgColor="#f0f0f0"><asp:textbox id="txtTEjecucion" runat="server" CssClass="normaldetalle" Width="238px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 75px" bgColor="#335eb4"><asp:label id="lblFuenteInformacion" runat="server" CssClass="TextoBlanco" Width="140px">FUENTE INFORMACION:</asp:label></TD>
								<TD width="245" bgColor="#dddddd"><asp:textbox id="txtFuenteInformacion" runat="server" CssClass="normalDetalle" Width="236px"
										Height="54px" TextMode="MultiLine"></asp:textbox></TD>
								<TD style="WIDTH: 50px" bgColor="#335eb4" rowSpan="2"><asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco" Width="140px">OBSERVACIONES</asp:label></TD>
								<TD bgColor="#dddddd" colSpan="1" rowSpan="2"><asp:textbox id="txtObservaciones" runat="server" CssClass="normalDetalle" Width="238px" Height="54px"
										TextMode="MultiLine"></asp:textbox></TD>
							</TR>
						</TABLE>
						<TABLE id="Table8" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="780" border="1">
							<TR>
								<TD bgColor="#000080" colSpan="6"><asp:label id="Label2" runat="server" CssClass="TituloPrincipalBlanco">INFORMACION ADICIONAL</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px" bgColor="#335eb4"><asp:label id="lblEspTecnica" runat="server" CssClass="TextoBlanco" Width="140px">Esp. Tecnica:</asp:label></TD>
								<TD class="normalDetalle" id="CellfEspecificaciones" width="245" bgColor="#f0f0f0" runat="server"><INPUT class="normaldetalle" id="fEspecificaciones" style="WIDTH: 184px; HEIGHT: 17px"
										type="file" size="11" name="File4" runat="server">
									<asp:checkbox id="chkEspecificaciones" runat="server" CssClass="normaldetalle" Width="24px" Height="16px"
										Text=" " Enabled="False"></asp:checkbox><asp:hyperlink id="hlkEspecificacionTecnica" runat="server" CssClass="normalDetalle" Visible="False">es</asp:hyperlink></TD>
								<TD bgColor="#335eb4"><asp:label id="lblPresupuesto" runat="server" CssClass="TextoBlanco" Width="140px" Height="14px">Presupuesto:</asp:label></TD>
								<TD class="normalDetalle" id="CellfPresupuesto" width="238" bgColor="#f0f0f0" runat="server"><INPUT class="normaldetalle" id="fPresupuesto" style="WIDTH: 184px; HEIGHT: 17px" type="file"
										size="11" name="File1" runat="server">
									<asp:checkbox id="chkPresupuesto" runat="server" CssClass="normaldetalle" Width="24px" Height="16px"
										Text=" " Enabled="False"></asp:checkbox><asp:hyperlink id="hlkPresupuesto" runat="server" CssClass="normalDetalle" Visible="False">pr</asp:hyperlink></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px" bgColor="#335eb4"><asp:label id="lblContrato" runat="server" CssClass="TextoBlanco" Width="140px">Contrato</asp:label></TD>
								<TD class="normalDetalle" id="CellfContrato" width="245" bgColor="#dddddd" runat="server"><INPUT class="normaldetalle" id="fContrato" style="WIDTH: 184px; HEIGHT: 17px" type="file"
										size="11" name="File3" runat="server">
									<asp:checkbox id="chkContrato" runat="server" CssClass="normaldetalle" Width="24px" Height="16px"
										Text=" " Enabled="False"></asp:checkbox><asp:hyperlink id="hlkContrato" runat="server" CssClass="normalDetalle" Visible="False">co</asp:hyperlink></TD>
								<TD bgColor="#335eb4"><asp:label id="lblPlano" runat="server" CssClass="TextoBlanco" Width="140px">Plano:</asp:label></TD>
								<TD class="normalDetalle" id="CellfPlano" width="238" bgColor="#dddddd" runat="server"><INPUT class="normaldetalle" id="fPlano" style="WIDTH: 184px; HEIGHT: 17px" type="file"
										size="11" name="File2" runat="server">
									<asp:checkbox id="chkPlano" runat="server" CssClass="normaldetalle" Width="24px" Height="16px"
										Text=" " Enabled="False"></asp:checkbox><asp:hyperlink id="hlkPlano" runat="server" CssClass="normalDetalle" Visible="False">pl</asp:hyperlink></TD>
							</TR>
						</TABLE>
						<TABLE id="tblConsulta" borderColor="black" width="780" border="0" runat="server">
							<TR>
								<TD id="TdCeldaCancelar" runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif">&nbsp;
								</TD>
							</TR>
						</TABLE>
						<INPUT id="hContrato" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="Hidden1"
							runat="server"><INPUT id="hIdJefeProyecto" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="hPresupuesto"
							runat="server"><INPUT id="hFoto" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="Hidden1"
							runat="server"><asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;<IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
							runat="server"> <INPUT id="hIdCliente" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="Hidden1"
							runat="server"><INPUT id="hPresupuesto" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="hPresupuesto"
							runat="server"><INPUT id="hEspecificaciones" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1"
							name="Hidden1" runat="server"><INPUT id="hPlano" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="Hidden1"
							runat="server"><BR>
						<cc2:domvalidationsummary id="vSum" runat="server" EnableClientScript="False" DisplayMode="List" ShowMessageBox="True"></cc2:domvalidationsummary>
						<BR>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
