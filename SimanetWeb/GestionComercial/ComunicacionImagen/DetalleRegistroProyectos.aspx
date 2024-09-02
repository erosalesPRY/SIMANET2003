<%@ Page language="c#" Codebehind="DetalleRegistroProyectos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.DetalleRegistroProyectos" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<script language="javascript">
			function controlEnable(combo, idControl)
			{
				if(combo.checked)
				{
					document.getElementById(idControl).disabled = true;
				} 
				else
				{
					document.getElementById(idControl).disabled = false;
				}
			}
		</script>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 24px"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Comercial > Consultas >Comunicacion e Imagen ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> DETALLE REGISTRO PROYECTOS CN</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<P>
							<TABLE id="Table4" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="778" border="1">
								<TR>
									<TD bgColor="#000080" colSpan="4"><asp:label id="lblDatosGenerales" runat="server" CssClass="TituloPrincipalBlanco">DATOS PRINCIPALES</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 98px; HEIGHT: 21px" bgColor="#335eb4"><asp:label id="lblNombre" runat="server" CssClass="TextoBlanco" Width="150px"> Nombre:</asp:label></TD>
									<TD width="240" bgColor="#dddddd"><asp:textbox id="txtNombre" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="200"
											Height="17px"></asp:textbox><asp:requiredfieldvalidator id="rfvNombre" runat="server" ControlToValidate="txtNombre">*</asp:requiredfieldvalidator></TD>
									<TD align="left" colSpan="1" rowSpan="10"><asp:image id="imgProyecto" runat="server" Width="370px" Height="187px" BorderColor="Transparent"
											ImageUrl="http://localhost/SimaNetWeb/imagenes/placa.gif"></asp:image><BR>
										<INPUT class="normaldetalle" id="fFoto" style="WIDTH: 100%; HEIGHT: 17px" type="file" size="42"
											name="File2" runat="server">
										<asp:CheckBox id="ckEliminarFoto" runat="server" CssClass="normalDetalle" Text="Eliminar foto"></asp:CheckBox>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 98px" bgColor="#335eb4"><asp:label id="lblIdProyecto" runat="server" CssClass="TextoBlanco" Width="150px">ID PROYECTO:</asp:label></TD>
									<TD width="240" bgColor="#f0f0f0"><asp:textbox id="txtIdProyecto" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="12"
											Height="17px"></asp:textbox><asp:requiredfieldvalidator id="rfvIdProyecto" runat="server" Width="6px" ControlToValidate="txtIdProyecto">*</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 98px" bgColor="#335eb4"><asp:label id="lbbNroProyecto" runat="server" CssClass="TextoBlanco" Width="150px">Nro. del C.O.:</asp:label></TD>
									<TD width="240" bgColor="#dddddd"><asp:textbox id="txtNroProyecto" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="12"
											Height="17px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 98px" bgColor="#335eb4"><asp:label id="lnlCO" runat="server" CssClass="TextoBlanco" Width="150px">CENTRO OPERACIONES:</asp:label></TD>
									<TD class="normalDetalle" id="CellddlCentroOperativo" width="240" bgColor="#f0f0f0"
										runat="server"><asp:dropdownlist id="ddlCentroOperativo" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 98px" bgColor="#335eb4"><asp:label id="lblMatricula" runat="server" CssClass="TextoBlanco" Width="150px"> MATRICULA:</asp:label></TD>
									<TD width="240" bgColor="#dddddd"><asp:textbox id="txtMatricula" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="20"
											Height="17px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 98px; HEIGHT: 22px" bgColor="#335eb4"><asp:label id="lblCliente" runat="server" CssClass="TextoBlanco" Width="150px"> Cliente:</asp:label></TD>
									<TD class="normaldetalle" id="CelltxtRazonSocial" width="240" bgColor="#f0f0f0" runat="server"><asp:textbox id="txtRazonSocial" runat="server" CssClass="normaldetalle" Width="210px" Height="17px"></asp:textbox><asp:imagebutton id="ibtnBuscarDependencia" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"
											CausesValidation="False"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 98px" bgColor="#335eb4"><asp:label id="lblTipoProducto" runat="server" CssClass="TextoBlanco" Width="150px">LINEA DE PRODUCTO:</asp:label></TD>
									<TD class="normalDetalle" id="CellddlTipoProducto" width="240" bgColor="#dddddd" runat="server"><asp:dropdownlist id="ddlTipoProducto" runat="server" CssClass="normaldetalle" Width="230px" Height="24px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 98px" bgColor="#335eb4"><asp:label id="lblTipoBuque" runat="server" CssClass="TextoBlanco" Width="150px">TIPO DE PRODUCTO:</asp:label></TD>
									<TD class="normalDetalle" id="CellddlTipoBuque" width="240" bgColor="#f0f0f0" runat="server"><asp:dropdownlist id="ddlTipoBuque" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 98px" bgColor="#335eb4"><asp:label id="lblSubTipo" runat="server" CssClass="TextoBlanco" Width="150px">SUB - TIPO:</asp:label></TD>
									<TD width="240" bgColor="#dddddd"><asp:textbox id="txtSubTipo" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 98px" bgColor="#335eb4"><asp:label id="lblClasficacion" runat="server" CssClass="TextoBlanco" Width="150px">CLASIFICACION:</asp:label></TD>
									<TD width="240" bgColor="#f0f0f0"><asp:textbox id="txtClasificacion" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#000080" colSpan="4"><asp:label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" Width="152px">ASPECTOS TECNICOS</asp:label></TD>
								</TR>
							</TABLE>
							<TABLE id="Table11" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="778" border="1">
								<TR>
									<TD style="WIDTH: 124px" bgColor="#335eb4"><asp:label id="lblDWT" runat="server" CssClass="TextoBlanco" Width="150px" Font-Size="XX-Small">DWT:</asp:label></TD>
									<TD width="240" bgColor="#dddddd"><asp:textbox id="txtDWT" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
									<TD style="WIDTH: 4px" bgColor="#335eb4"><asp:label id="lblArboladura" runat="server" CssClass="TextoBlanco" Width="150px">Arboladura:</asp:label></TD>
									<TD bgColor="#dddddd"><asp:textbox id="txtArboladura" runat="server" CssClass="normaldetalle" Width="220px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 124px" bgColor="#335eb4"><asp:label id="lblLightShip" runat="server" CssClass="TextoBlanco" Width="150px" Font-Size="XX-Small">LIGHT SHIP (TON):</asp:label></TD>
									<TD style="WIDTH: 173px" width="173" bgColor="#f0f0f0"><asp:textbox id="txtLightship" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
									<TD style="WIDTH: 4px" bgColor="#335eb4"><asp:label id="lblEslora" runat="server" CssClass="TextoBlanco" Width="150px">ESLORA (MTS) :</asp:label></TD>
									<TD class="normaldetalle" id="CellTxtEslora" bgColor="#f0f0f0" runat="server"><ew:numericbox id="txtEslora" runat="server" CssClass="normaldetalle" Width="220px" Height="17px"></ew:numericbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 124px" bgColor="#335eb4"><asp:label id="lblDesplazamiento" runat="server" CssClass="TextoBlanco" Width="150px" Height="2px"
											Font-Size="XX-Small">DESPLAZAMIENTO (TON):</asp:label></TD>
									<TD style="WIDTH: 173px" width="173" bgColor="#dddddd"><asp:textbox id="txtDesplazamiento" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
									<TD style="WIDTH: 4px" bgColor="#335eb4"><asp:label id="lblManga" runat="server" CssClass="TextoBlanco" Width="150px">MANGA (MTS):</asp:label></TD>
									<TD class="normaldetalle" id="CelltxtManga" bgColor="#dddddd" runat="server"><ew:numericbox id="txtManga" runat="server" CssClass="normaldetalle" Width="220px" Height="17px"></ew:numericbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 124px" bgColor="#335eb4"><asp:label id="lblCapBod" runat="server" CssClass="TextoBlanco" Width="150px" Font-Size="XX-Small">CAPACIDAD DE BODEGA:</asp:label></TD>
									<TD style="WIDTH: 173px" width="173" bgColor="#f0f0f0"><asp:textbox id="txtCapBod" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
									<TD style="WIDTH: 4px" bgColor="#335eb4"><asp:label id="lblPuntual" runat="server" CssClass="TextoBlanco" Width="150px">PUNTAL (MTS):</asp:label></TD>
									<TD class="normaldetalle" id="CelltxtPuntal" bgColor="#f0f0f0" runat="server"><ew:numericbox id="txtPuntal" runat="server" CssClass="normaldetalle" Width="220px" Height="17px"></ew:numericbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 124px" bgColor="#335eb4"><asp:label id="lblEmpuje" runat="server" CssClass="TextoBlanco" Width="150px" Height="10px"
											Font-Size="XX-Small">EMPUJE O FUERZA:</asp:label></TD>
									<TD style="WIDTH: 173px" bgColor="#dddddd"><asp:textbox id="txtEmpuje" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
									<TD style="WIDTH: 4px" bgColor="#335eb4"><asp:label id="lblCalado" runat="server" CssClass="TextoBlanco" Width="150px">CALADO (mts) :</asp:label></TD>
									<TD class="normaldetalle" id="CelltxtCalado" bgColor="#dddddd" runat="server"><ew:numericbox id="txtCalado" runat="server" CssClass="normaldetalle" Width="220px" Height="17px"></ew:numericbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 124px; HEIGHT: 16px" bgColor="#335eb4"><asp:label id="lblMaterialCasco" runat="server" CssClass="TextoBlanco" Width="150px" Height="14px"
											Font-Size="XX-Small">Material de Casco:</asp:label></TD>
									<TD class="normaldetalle" id="CellddlMaterailCasco" style="WIDTH: 173px" width="173"
										bgColor="#f0f0f0" runat="server"><asp:dropdownlist id="ddlMaterailCasco" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"></asp:dropdownlist></TD>
									<TD style="WIDTH: 4px; HEIGHT: 16px" bgColor="#335eb4"><asp:label id="lblVelocidad" runat="server" CssClass="TextoBlanco" Width="150px">VELOCIDAD:</asp:label></TD>
									<TD style="HEIGHT: 16px" bgColor="#f0f0f0"><asp:textbox id="txtVelocidad" runat="server" CssClass="normaldetalle" Width="220px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 124px" bgColor="#335eb4"><asp:label id="lblTonProcesadas" runat="server" CssClass="TextoBlanco" Width="150px" Font-Size="XX-Small">TON. PROCESADAS:</asp:label></TD>
									<TD class="normalDetalle" style="WIDTH: 173px" width="173" bgColor="#dddddd"><asp:textbox id="txtTonProcesadas" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
									<TD style="WIDTH: 4px" bgColor="#335eb4"><asp:label id="lblTripulacion" runat="server" CssClass="TextoBlanco" Width="150px">TRIPULACION:</asp:label></TD>
									<TD bgColor="#dddddd"><asp:textbox id="txtTripulacion" runat="server" CssClass="normaldetalle" Width="220px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 124px" bgColor="#335eb4"><asp:label id="lblNroBodegas" runat="server" CssClass="TextoBlanco" Width="150px" Font-Size="XX-Small">Nro. Bodegas:</asp:label></TD>
									<TD style="WIDTH: 173px" width="173" bgColor="#f0f0f0"><asp:textbox id="txtNroBodegas" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
									<TD style="WIDTH: 4px" bgColor="#335eb4"><asp:label id="lblAutonomia" runat="server" CssClass="TextoBlanco" Width="150px">Autonomía:</asp:label></TD>
									<TD bgColor="#f0f0f0"><asp:textbox id="txtAutonomia" runat="server" CssClass="normaldetalle" Width="220px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 124px" bgColor="#335eb4"><asp:label id="lblNroTanques" runat="server" CssClass="TextoBlanco" Width="150px" Height="8px"
											Font-Size="XX-Small">Nro. Tanques</asp:label></TD>
									<TD style="WIDTH: 173px" width="173" bgColor="#dddddd"><asp:textbox id="txtNroTanques" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
									<TD style="WIDTH: 4px" bgColor="#335eb4"><asp:label id="lblGenElectrica" runat="server" CssClass="TextoBlanco" Width="150px">Gen. Electrica:</asp:label></TD>
									<TD bgColor="#dddddd"><asp:textbox id="txtGenElectrica" runat="server" CssClass="normaldetalle" Width="220px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 124px" bgColor="#335eb4"><asp:label id="lblNroVontenedores" runat="server" CssClass="TextoBlanco" Width="150px" Height="4px">Nro. Contenedores:</asp:label></TD>
									<TD style="WIDTH: 173px" bgColor="#f0f0f0"><asp:textbox id="txtNroContenedores" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
									<TD bgColor="#000080" colSpan="2"><asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" Width="192px">CAP. LIQUIDOS</asp:label>&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 124px" bgColor="#335eb4"><asp:label id="lblMotor" runat="server" CssClass="TextoBlanco" Width="150px" Font-Size="XX-Small">MOTOR:</asp:label></TD>
									<TD style="WIDTH: 173px" width="173" bgColor="#dddddd"><asp:textbox id="txtMotor" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
									<TD style="WIDTH: 4px" bgColor="#335eb4"><asp:label id="lblCombustible" runat="server" CssClass="TextoBlanco" Width="150px">COMBUSTIBLE:</asp:label></TD>
									<TD bgColor="#dddddd"><asp:textbox id="txtCombustible" runat="server" CssClass="normaldetalle" Width="220px" MaxLength="200"
											Height="17px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 124px" bgColor="#335eb4"><asp:label id="lblModelo" runat="server" CssClass="TextoBlanco" Width="150px" Font-Size="XX-Small">MODELO:</asp:label></TD>
									<TD style="WIDTH: 173px" width="173" bgColor="#f0f0f0"><asp:textbox id="txtModelo" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
									<TD style="WIDTH: 4px" bgColor="#335eb4"><asp:label id="lblAgua" runat="server" CssClass="TextoBlanco" Width="150px">Agua:</asp:label></TD>
									<TD bgColor="#f0f0f0"><asp:textbox id="txtAgua" runat="server" CssClass="normaldetalle" Width="220px" MaxLength="200"
											Height="17px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 124px" bgColor="#335eb4"><asp:label id="lblPotencia" runat="server" CssClass="TextoBlanco" Width="150px">Potencia:</asp:label></TD>
									<TD style="WIDTH: 173px" width="173" bgColor="#dddddd"><asp:textbox id="txtPotencia" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
									<TD style="WIDTH: 4px" bgColor="#335eb4"><asp:label id="lblHidraulico" runat="server" CssClass="TextoBlanco" Width="150px">A. Hidraulico:</asp:label></TD>
									<TD bgColor="#dddddd"><asp:textbox id="txtAHidraulico" runat="server" CssClass="normaldetalle" Width="220px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 124px" bgColor="#335eb4"><asp:label id="lblTCombustible" runat="server" CssClass="TextoBlanco" Width="150px" Font-Size="XX-Small">T. Combustible:</asp:label></TD>
									<TD style="WIDTH: 173px" width="173" bgColor="#f0f0f0"><asp:textbox id="txttCombustible" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
									<TD style="WIDTH: 4px" bgColor="#335eb4"><asp:label id="lblLubricacion" runat="server" CssClass="TextoBlanco" Width="150px">A. Lubricacion:</asp:label></TD>
									<TD bgColor="#f0f0f0"><asp:textbox id="txtALubricacion" runat="server" CssClass="normaldetalle" Width="220px" MaxLength="100"
											Height="17px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#000080" colSpan="4"><asp:label id="lblAspectoAdministrativo" runat="server" CssClass="TituloPrincipalBlanco" Width="352px">ASPECTO ADMINISTRATIVO</asp:label></TD>
								</TR>
							</TABLE>
							<TABLE id="Table16" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="778" border="1">
								<TR>
									<TD style="WIDTH: 101px" bgColor="#335eb4"><asp:label id="lblEstado" runat="server" CssClass="TextoBlanco" Width="150px" Height="5px">Estado:</asp:label></TD>
									<TD class="normalDetalle" id="CellddlEstadoProyecto" style="WIDTH: 240px" width="240"
										bgColor="#dddddd" runat="server"><asp:dropdownlist id="ddlEstadoProyecto" runat="server" CssClass="normaldetalle" Width="230px" DESIGNTIMEDRAGDROP="1114"></asp:dropdownlist></TD>
									<TD style="WIDTH: 149px" bgColor="#335eb4"><asp:label id="lblFirmaAcuerdo" runat="server" CssClass="TextoBlanco" Width="150px" DESIGNTIMEDRAGDROP="1116">FECHA Acuerdo:</asp:label></TD>
									<TD class="normaldetalle" id="CellcalFechaFirmaAcuerdo" bgColor="#dddddd" runat="server">
										<ew:calendarpopup id="calFechaFirmaAcuerdo" runat="server" CssClass="combos" Width="200px" ImageUrl="../../imagenes/BtPU_Mas.gif"
											DESIGNTIMEDRAGDROP="1127" CalendarLocation="Bottom" AllowArbitraryText="False" ShowGoToToday="True"
											ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True" ClearDateText="Limpiar Fecha"
											GoToTodayText="Fecha de Hoy" Nullable="True" NullableLabelText=" " AutoPostBack="True">
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
									<TD style="WIDTH: 101px" bgColor="#335eb4">
										<P><asp:label id="lblDocPrincipal" runat="server" CssClass="TextoBlanco" Width="150px" Height="11px"
												Font-Size="XX-Small">DocUMENTO Principal:</asp:label></P>
									</TD>
									<TD style="WIDTH: 240px" width="240" bgColor="#f0f0f0"><asp:textbox id="txtDocPrincipal" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="200"
											Height="17px" DESIGNTIMEDRAGDROP="1143"></asp:textbox></TD>
									<TD style="WIDTH: 149px" bgColor="#335eb4"><asp:label id="lblInicioContractual" runat="server" CssClass="TextoBlanco" Width="144px" Height="12px">Inicio Contractual:</asp:label></TD>
									<TD class="normaldetalle" id="CellcalFechaInicioContractual" bgColor="#f0f0f0" runat="server"><ew:calendarpopup id="calFechaInicioContractual" runat="server" CssClass="combos" Width="200px" ImageUrl="../../imagenes/BtPU_Mas.gif"
											DESIGNTIMEDRAGDROP="1127" AutoPostBack="True" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True" Culture="Spanish (Chile)"
											ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False" CalendarLocation="Bottom">
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
									<TD style="WIDTH: 101px; HEIGHT: 8px" bgColor="#335eb4"><asp:label id="lblTipoDocumento" runat="server" CssClass="TextoBlanco" Width="150px">Tipo DE DOCUMENTO:</asp:label></TD>
									<TD class="normalDetalle" id="CellddlTipoDocumento" style="WIDTH: 240px" width="240"
										bgColor="#dddddd" runat="server"><asp:dropdownlist id="ddlTipoDocumento" runat="server" CssClass="normaldetalle" Width="230px"></asp:dropdownlist></TD>
									<TD style="WIDTH: 149px; HEIGHT: 8px" bgColor="#335eb4"><asp:label id="lblFinContractual" runat="server" CssClass="TextoBlanco" Width="150px">Fin Contractual:</asp:label></TD>
									<TD class="normaldetalle" id="CellcalFechaFinContractual" style="HEIGHT: 8px" bgColor="#dddddd"
										runat="server"><ew:calendarpopup id="calFechaFinContractual" runat="server" CssClass="combos" Width="200px" ImageUrl="../../imagenes/BtPU_Mas.gif"
											AutoPostBack="True" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha"
											PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False"
											CalendarLocation="Bottom">
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
									<TD style="WIDTH: 101px" bgColor="#335eb4"><asp:label id="lblOtroDocumento" runat="server" CssClass="TextoBlanco" Width="150px">Otro DOCUMENTO:</asp:label></TD>
									<TD style="WIDTH: 240px; HEIGHT: 24px" bgColor="#f0f0f0">
										<P><asp:textbox id="txtOtroDoc" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="200"
												Height="17px"></asp:textbox></P>
									</TD>
									<TD style="WIDTH: 149px" bgColor="#335eb4"><asp:label id="lblInicioreal" runat="server" CssClass="TextoBlanco" Width="150px">Inicio Real:</asp:label></TD>
									<TD class="normaldetalle" id="CellcalFechaInicioReal" style="HEIGHT: 24px" bgColor="#f0f0f0"
										runat="server"><ew:calendarpopup id="calFechaInicioReal" runat="server" CssClass="combos" Width="200px" ImageUrl="../../imagenes/BtPU_Mas.gif"
											AutoPostBack="True" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha"
											PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False"
											CalendarLocation="Bottom">
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
									<TD style="WIDTH: 101px; HEIGHT: 21px" bgColor="#335eb4"><asp:label id="lblOtroTipoDocumento" runat="server" CssClass="TextoBlanco" Width="150px">Tipo DE DocUMENTO:</asp:label></TD>
									<TD class="normalDetalle" id="CellddlOtroTipodocumento" style="WIDTH: 240px" width="240"
										bgColor="#dddddd" runat="server"><asp:dropdownlist id="ddlOtroTipodocumento" runat="server" CssClass="normaldetalle" Width="230px"></asp:dropdownlist></TD>
									<TD style="WIDTH: 149px; HEIGHT: 21px" bgColor="#335eb4"><asp:label id="lblPuestaQuilla" runat="server" CssClass="TextoBlanco" Width="150px" Height="6px">PUESTA de Quilla:</asp:label></TD>
									<TD class="normaldetalle" id="CellcalPuestaQuilla" style="HEIGHT: 21px" bgColor="#dddddd"
										runat="server"><ew:calendarpopup id="calPuestaQuilla" runat="server" CssClass="combos" Width="200px" ImageUrl="../../imagenes/BtPU_Mas.gif"
											AutoPostBack="True" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha"
											PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False"
											CalendarLocation="Bottom">
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
									<TD style="WIDTH: 101px" bgColor="#335eb4"><asp:label id="lblMontoContrato" runat="server" CssClass="TextoBlanco" Width="150px">PRECIO CONTRACTUAL.:</asp:label></TD>
									<TD class="normalDetalle" id="CelltxtMontoContrato" style="WIDTH: 240px" width="240"
										bgColor="#f0f0f0" runat="server"><ew:numericbox id="txtMontoContrato" runat="server" CssClass="normaldetalle" Width="230px" Height="17px"></ew:numericbox></TD>
									<TD style="WIDTH: 149px" bgColor="#335eb4"><asp:label id="lblLanzamiento" runat="server" CssClass="TextoBlanco" Width="150px">Lanzamiento:</asp:label></TD>
									<TD class="normaldetalle" id="CellcalFechaLanzamiento" bgColor="#f0f0f0" runat="server"><ew:calendarpopup id="calFechaLanzamiento" runat="server" CssClass="combos" Width="200px" ImageUrl="../../imagenes/BtPU_Mas.gif"
											AutoPostBack="True" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage"
											ShowGoToToday="True" AllowArbitraryText="False" CalendarLocation="Bottom">
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
									<TD style="WIDTH: 101px; HEIGHT: 23px" bgColor="#335eb4">
										<P><asp:label id="lblMoneda" runat="server" CssClass="TextoBlanco" Width="150px">Moneda:</asp:label></P>
									</TD>
									<TD class="normalDetalle" id="CellddlMoneda" style="WIDTH: 240px" width="240" bgColor="#dddddd"
										runat="server"><asp:dropdownlist id="ddlMoneda" runat="server" CssClass="normaldetalle" Width="230px"></asp:dropdownlist></TD>
									<TD style="WIDTH: 149px; HEIGHT: 23px" bgColor="#335eb4"><asp:label id="lblFinReal" runat="server" CssClass="TextoBlanco" Width="150px">fin Real:</asp:label></TD>
									<TD class="normaldetalle" id="CellcalFechaFinReal" style="HEIGHT: 23px" bgColor="#dddddd"
										runat="server"><ew:calendarpopup id="calFechaFinReal" runat="server" CssClass="combos" Width="200px" ImageUrl="../../imagenes/BtPU_Mas.gif"
											AutoPostBack="True" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha"
											PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False"
											CalendarLocation="Bottom">
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
									<TD style="WIDTH: 101px" bgColor="#335eb4"><asp:label id="lblJefeProyectos" runat="server" CssClass="TextoBlanco" Width="150px" Height="2px">Jefe de Proyecto:</asp:label></TD>
									<TD class="normaldetalle" id="CelltxtJefeProyectos" style="WIDTH: 240px" width="240"
										bgColor="#f0f0f0" runat="server"><asp:textbox id="txtJefeProyectos" runat="server" CssClass="normaldetalle" Width="210px" Height="17px"></asp:textbox><asp:imagebutton id="ibtBuscaJefeProyectos" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"
											CausesValidation="False"></asp:imagebutton></TD>
									<TD style="WIDTH: 149px" bgColor="#335eb4">
										<P><asp:label id="lblTermino" runat="server" CssClass="TextoBlanco" Width="150px">ENTREGA :</asp:label></P>
									</TD>
									<TD class="normaldetalle" id="CellcalFechaEntrega" bgColor="#f0f0f0" runat="server"><ew:calendarpopup id="calFechaEntrega" runat="server" CssClass="combos" Width="200px" ImageUrl="../../imagenes/BtPU_Mas.gif"
											AutoPostBack="True" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage"
											ShowGoToToday="True" AllowArbitraryText="False" CalendarLocation="Bottom">
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
									<TD style="WIDTH: 101px" bgColor="#335eb4"><asp:label id="lblFuenteObservacion" runat="server" CssClass="TextoBlanco" Width="150px">Fuente InfORMACION:</asp:label></TD>
									<TD style="WIDTH: 240px" width="240" bgColor="#dddddd"><asp:textbox id="txtFuenteInformacion" runat="server" CssClass="normaldetalle" Width="230px"
											Height="17px"></asp:textbox></TD>
									<TD style="WIDTH: 149px" bgColor="#335eb4"><asp:label id="lblEjecucion" runat="server" CssClass="TextoBlanco" Width="150px">Ejecucion (DIAS):</asp:label></TD>
									<TD class="normalDetalle" id="CelltxtTEjecucion" bgColor="#dddddd" runat="server"><asp:textbox id="txtTEjecucion" runat="server" CssClass="normaldetalle" Width="220px" Height="17px"
											ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 101px" bgColor="#335eb4"><asp:label id="lblObservacion" runat="server" CssClass="TextoBlanco" Width="150px">Observacion:</asp:label></TD>
									<TD bgColor="#f0f0f0" colSpan="3"><asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Width="100%" Height="46px"
											TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#000080" colSpan="4"><asp:label id="lblSeguridad" runat="server" CssClass="TituloPrincipalBlanco" Width="288px">INFORMACION ADICIONAL</asp:label></TD>
								</TR>
							</TABLE>
							<TABLE id="Table20" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="778" border="1">
								<TR>
									<TD bgColor="#335eb4"><asp:label id="lblPresupuesto" runat="server" CssClass="TextoBlanco" Width="150px" Height="14px">ACTA DE RECEPCION:</asp:label></TD>
									<TD class="normaldetalle" id="CellfPresupuesto" style="WIDTH: 239px" width="239" bgColor="#dddddd"
										runat="server"><INPUT class="normaldetalle" id="fPresupuesto" style="WIDTH: 192px; HEIGHT: 17px" type="file"
											size="12" name="File1" runat="server">&nbsp;<asp:hyperlink id="hlkPresupuesto" runat="server" CssClass="normalDetalle" Visible="False" Target="_blank">pr</asp:hyperlink>
										<asp:CheckBox id="ckEliminarPresupuesto" runat="server" Text="Eliminar Archivo"></asp:CheckBox></TD>
									<TD style="WIDTH: 124px" bgColor="#335eb4"><asp:label id="lblContrato" runat="server" CssClass="TextoBlanco" Width="150px">Contrato:</asp:label></TD>
									<TD class="normaldetalle" id="CellfContrato" bgColor="#dddddd" runat="server"><INPUT class="normaldetalle" id="fContrato" style="WIDTH: 176px; HEIGHT: 17px" type="file"
											size="10" name="File3" runat="server">&nbsp;<asp:hyperlink id="hlkContrato" runat="server" CssClass="normalDetalle" Visible="False" Target="_blank">co</asp:hyperlink>
										<asp:CheckBox id="ckEliminarContrato" runat="server" Text="Eliminar Archivo"></asp:CheckBox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 134px" bgColor="#335eb4"><asp:label id="lblPlano" runat="server" CssClass="TextoBlanco" Width="150px">Plano:</asp:label></TD>
									<TD class="normaldetalle" id="CellfPlano" style="WIDTH: 239px" width="239" bgColor="#f0f0f0"
										runat="server"><INPUT class="normaldetalle" id="fPlano" style="WIDTH: 192px; HEIGHT: 17px" type="file"
											size="12" name="File2" runat="server">&nbsp;<asp:hyperlink id="hlkPlano" runat="server" CssClass="normalDetalle" Visible="False" Target="_blank">pl</asp:hyperlink>
										<asp:CheckBox id="ckEliminarPlano" runat="server" Text="Eliminar Archivo"></asp:CheckBox></TD>
									<TD style="WIDTH: 124px" bgColor="#335eb4"><asp:label id="lblEspTecnica" runat="server" CssClass="TextoBlanco" Width="150px">Esp. Tecnica:</asp:label></TD>
									<TD class="normaldetalle" id="CellfEspecificaciones" bgColor="#f0f0f0" runat="server"><INPUT class="normaldetalle" id="fEspecificaciones" style="WIDTH: 176px; HEIGHT: 17px"
											type="file" size="10" name="File4" runat="server">&nbsp;<asp:hyperlink id="hlkEspecificacionTecnica" runat="server" CssClass="normalDetalle" Visible="False"
											Target="_blank">es</asp:hyperlink>
										<asp:CheckBox id="ckEliminarEspTecnica" runat="server" Text="Eliminar Archivo"></asp:CheckBox></TD>
								</TR>
							</TABLE>
							<TABLE id="Table7" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="778" border="1">
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="tblAtras" cellSpacing="0" cellPadding="0" width="76" align="left" border="0"
											runat="server">
											<TR>
												<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
											</TR>
										</TABLE>
										<INPUT id="hFoto" style="WIDTH: 16px; HEIGHT: 7px" type="hidden" size="1" name="Hidden1"
											runat="server"><INPUT id="hIdCliente" style="WIDTH: 16px; HEIGHT: 7px" type="hidden" size="1" name="hCodigo"
											runat="server"><INPUT id="hEspecificaciones" style="WIDTH: 16px; HEIGHT: 7px" type="hidden" size="1" name="Hidden1"
											runat="server"><INPUT id="hPresupuesto" style="WIDTH: 16px; HEIGHT: 7px" type="hidden" size="1" name="hPresupuesto"
											runat="server">&nbsp; <INPUT id="hContrato" style="WIDTH: 16px; HEIGHT: 7px" type="hidden" size="1" name="Hidden1"
											runat="server"><INPUT id="hPlano" style="WIDTH: 16px; HEIGHT: 7px" type="hidden" size="1" name="Hidden1"
											runat="server"><INPUT id="hIdJefeProyecto" style="WIDTH: 16px; HEIGHT: 7px" type="hidden" size="1" name="hImagen"
											runat="server"><INPUT id="hIdUnidadDependenciaCliente" style="WIDTH: 16px; HEIGHT: 7px" type="hidden"
											size="1" name="hCodigo" runat="server"><INPUT id="hNombreCliente" style="WIDTH: 16px; HEIGHT: 7px" type="hidden" size="1" name="hCodigo"
											runat="server"></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" vAlign="top" align="center"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;
										<IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
											runat="server"><asp:validationsummary id="vSum" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
								</TR>
							</TABLE>
						</P>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
