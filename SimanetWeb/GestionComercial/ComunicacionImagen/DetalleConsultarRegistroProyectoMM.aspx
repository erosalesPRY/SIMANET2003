<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalleConsultarRegistroProyectoMM.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.DetalleConsultarRegistroProyectoMM" smartNavigation="True"%>
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
			<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Historico de Proyectos ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">DETALLE PUENTES</asp:label></TD>
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
								<TD style="WIDTH: 255px" bgColor="#dddddd" colSpan="2"><asp:textbox id="txtNombre" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"
										MaxLength="100"></asp:textbox></TD>
								<TD align="left" bgColor="#dddddd" colSpan="1" rowSpan="13"><asp:image id="imgProyecto" runat="server" Width="360px" Height="261px" BorderColor="Transparent"
										ImageUrl="../../SimaNetWeb/imagenes/sinfoto.gif"></asp:image><BR>
									<INPUT class="normaldetalle" id="fFoto" style="WIDTH: 357px; HEIGHT: 17px" type="file"
										size="40" name="File2" runat="server">
									<asp:CheckBox id="ckEliminarFoto" runat="server" CssClass="normalDetalle" Text="Eliminar foto"></asp:CheckBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 21px" bgColor="#335eb4"><asp:label id="lblIdProyecto" runat="server" CssClass="TextoBlanco" Width="150px">ID PROYECTO:</asp:label></TD>
								<TD style="WIDTH: 255px" bgColor="#f0f0f0" colSpan="2"><asp:textbox id="txtIdProyecto" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"
										MaxLength="12"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 10px" bgColor="#335eb4"><asp:label id="lnlCO" runat="server" CssClass="TextoBlanco" Width="150px">CENTRO OPERACIONES:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlCentroOperativo" style="WIDTH: 255px" bgColor="#dddddd"
									colSpan="2" runat="server"><asp:dropdownlist id="ddlCentroOperativo" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 3px" bgColor="#335eb4"><asp:label id="lblCliente" runat="server" CssClass="TextoBlanco" Width="150px"> Cliente:</asp:label></TD>
								<TD style="WIDTH: 255px" bgColor="#f0f0f0" colSpan="2"><asp:textbox id="txtRazonSocial" runat="server" CssClass="normaldetalle" Width="216px" Height="17px"></asp:textbox><asp:imagebutton id="ibtnBuscarDependencia" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CausesValidation="False"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 18px" bgColor="#335eb4"><asp:label id="lblTipoProducto" runat="server" CssClass="TextoBlanco" Width="150px">LINEA DE PRODUCTO:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlTipoProducto" style="WIDTH: 255px" bgColor="#dddddd"
									colSpan="2" runat="server"><asp:dropdownlist id="ddlTipoProducto" runat="server" CssClass="normaldetalle" Width="238px" Height="24px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 15px" bgColor="#335eb4"><asp:label id="lblTipoBuque" runat="server" CssClass="TextoBlanco" Width="150px">TIPO DE PRODUCTO:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlTipoBuque" style="WIDTH: 255px" bgColor="#f0f0f0"
									colSpan="2" runat="server"><asp:dropdownlist id="ddlTipoBuque" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px" bgColor="#335eb4"><asp:label id="lblSubTipo" runat="server" CssClass="TextoBlanco" Width="150px">SUB - TIPO:</asp:label></TD>
								<TD style="WIDTH: 255px" bgColor="#dddddd" colSpan="2"><asp:textbox id="txtSubTipo" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"
										MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 409px" bgColor="#000080" colSpan="3"><asp:label id="lblUbigeo" runat="server" CssClass="TituloPrincipalBlanco">UBICACION</asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 21px" bgColor="#335eb4"><asp:label id="lblTipoCliente" runat="server" CssClass="TextoBlanco" Width="150px"> DESTINO:</asp:label></TD>
								<TD class="normaldetalle" id="CellRadio" style="WIDTH: 255px" bgColor="#f0f0f0" colSpan="2"
									runat="server"><asp:radiobutton id="rbtPeruano" runat="server" CssClass="normalDetalle" AutoPostBack="True" Text="NACIONAL"></asp:radiobutton><asp:radiobutton id="rbtExtranjero" runat="server" CssClass="normaldetalle" AutoPostBack="True" Text="Extranjero"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px" bgColor="#335eb4"><asp:label id="Label20" runat="server" CssClass="TextoBlanco" Width="150px">localidad:</asp:label></TD>
								<TD style="WIDTH: 255px" width="255" bgColor="#dddddd" colSpan="2"><asp:textbox id="txtLocalidad" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 22px" bgColor="#335eb4"><asp:label id="lblLugartres" runat="server" CssClass="TextoBlanco" Width="150px">provincia:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlProvincia" style="WIDTH: 255px; HEIGHT: 22px" bgColor="#f0f0f0"
									colSpan="2" runat="server"><asp:dropdownlist id="ddlProvincia" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 14px" bgColor="#335eb4"><asp:label id="lblLugardos" runat="server" CssClass="TextoBlanco" Width="150px">region:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlRegion" style="WIDTH: 255px" bgColor="#dddddd"
									colSpan="2" runat="server"><asp:dropdownlist id="ddlRegion" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px" bgColor="#335eb4"><asp:label id="lblLugarUno" runat="server" CssClass="TextoBlanco" Width="150px">PAIS:</asp:label></TD>
								<TD class="normaldetalle" id="CelldllPais" style="WIDTH: 255px" bgColor="#f0f0f0" colSpan="2"
									runat="server"><asp:dropdownlist id="dllPais" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"
										AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
						<TABLE id="Table7" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="778" border="1">
							<TR>
								<TD bgColor="#000080" colSpan="6"><asp:label id="lblTituloAspectosTecnicos" runat="server" CssClass="TituloPrincipalBlanco">ASPECTOS TECNICOS</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px" bgColor="#335eb4"><asp:label id="Label3" runat="server" CssClass="TextoBlanco" Width="112px">LUZ (MTS):</asp:label></TD>
								<TD class="normaldetalle" id="CelltxtLuz" style="WIDTH: 248px" bgColor="#dddddd" runat="server"><ew:numericbox id="txtLuz" runat="server" CssClass="normaldetalle" Width="238px" MaxLength="5"
										DecimalPlaces="2" PositiveNumber="True"></ew:numericbox></TD>
								<TD style="WIDTH: 12px" bgColor="#000080" colSpan="3"><asp:label id="Label12" runat="server" CssClass="TituloPrincipalBlanco" Width="144px" Height="7px">Super Estructura</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px" bgColor="#335eb4"><asp:label id="lblTramos" runat="server" CssClass="TextoBlanco" Width="112px">Tramos:</asp:label></TD>
								<TD style="WIDTH: 248px" bgColor="#f0f0f0"><asp:textbox id="txtTramos" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 311px" bgColor="#335eb4"><asp:label id="Label13" runat="server" CssClass="TextoBlanco" Width="150px">Vigas:</asp:label></TD>
								<TD class="normaldetalle" id="g" style="WIDTH: 261px" bgColor="#f0f0f0" colSpan="2"
									runat="server"><asp:textbox id="txtVigas" runat="server" CssClass="normalDetalle" Width="200px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px" bgColor="#335eb4"><asp:label id="Label4" runat="server" CssClass="TextoBlanco" Width="112px">Vias:</asp:label></TD>
								<TD style="WIDTH: 248px" bgColor="#dddddd"><asp:textbox id="txtVias" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 311px" bgColor="#335eb4"><asp:label id="lblMaterial" runat="server" CssClass="TextoBlanco" Width="150px">MATERIAL:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlMaterial" style="WIDTH: 261px" bgColor="#dddddd"
									colSpan="2" runat="server"><asp:dropdownlist id="ddlMaterial" runat="server" CssClass="normaldetalle" Width="200px" Height="17px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px; HEIGHT: 23px" bgColor="#335eb4"><asp:label id="Label5" runat="server" CssClass="TextoBlanco" Width="112px">Ancho(mts):</asp:label></TD>
								<TD class="normaldetalle" id="CelltxtAncho" style="WIDTH: 248px; HEIGHT: 23px" bgColor="#f0f0f0"
									runat="server"><ew:numericbox id="txtAncho" runat="server" CssClass="normaldetalle" Width="238px" MaxLength="5"
										DecimalPlaces="2" PositiveNumber="True"></ew:numericbox></TD>
								<TD style="WIDTH: 311px; HEIGHT: 23px" bgColor="#335eb4"><asp:label id="lblTipoMaterial" runat="server" CssClass="TextoBlanco" Width="150px">TIPO MATERIAL:</asp:label></TD>
								<TD class="normaldetalle" style="WIDTH: 261px; HEIGHT: 23px" bgColor="#f0f0f0" colSpan="2"><asp:textbox id="txtTipoMaterial" runat="server" CssClass="normalDetalle" Width="200px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px" bgColor="#335eb4"><asp:label id="Label6" runat="server" CssClass="TextoBlanco" Width="136px">Ancho Rodadura(mts):</asp:label></TD>
								<TD class="normaldetalle" id="CelltxtAnchoRodadura" style="WIDTH: 248px" bgColor="#dddddd"
									runat="server"><ew:numericbox id="txtAnchoRodadura" runat="server" CssClass="normaldetalle" Width="238px" MaxLength="5"
										DecimalPlaces="2" PositiveNumber="True"></ew:numericbox></TD>
								<TD style="WIDTH: 311px" bgColor="#335eb4"><asp:label id="Label14" runat="server" CssClass="TextoBlanco" Width="150px">PERALTE VL:</asp:label></TD>
								<TD class="normaldetalle" style="WIDTH: 261px" bgColor="#dddddd" colSpan="2"><asp:textbox id="txtPeralte" runat="server" CssClass="normalDetalle" Width="200px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px; HEIGHT: 23px" bgColor="#335eb4"><asp:label id="lblCapacidad" runat="server" CssClass="TextoBlanco" Width="150px">SobreCarga:</asp:label></TD>
								<TD style="WIDTH: 248px; HEIGHT: 23px" bgColor="#f0f0f0"><asp:textbox id="txtSobreCarga" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 311px; HEIGHT: 23px" bgColor="#335eb4"><asp:label id="Label15" runat="server" CssClass="TextoBlanco" Width="150px">GALIBO:</asp:label></TD>
								<TD style="WIDTH: 261px; HEIGHT: 23px" bgColor="#f0f0f0" colSpan="2"><asp:textbox id="txtGalibo" runat="server" CssClass="normalDetalle" Width="200px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px" bgColor="#335eb4"><asp:label id="lblDimension" runat="server" CssClass="TextoBlanco" Width="150px">Accesos:</asp:label></TD>
								<TD style="WIDTH: 248px" bgColor="#dddddd"><asp:textbox id="txtAccesos" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 311px" bgColor="#335eb4"><asp:label id="lblPesoNeto" runat="server" CssClass="TextoBlanco" Width="150px">TIPO RODADURA:</asp:label></TD>
								<TD style="WIDTH: 261px" bgColor="#dddddd" colSpan="2"><asp:textbox id="txtTipoRodadura" runat="server" CssClass="normalDetalle" Width="200px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 402px; HEIGHT: 4px" bgColor="#000080" colSpan="2" rowSpan="1"><asp:label id="Label7" runat="server" CssClass="TituloPrincipalBlanco" Width="144px" Height="7px">Sub Estructura</asp:label></TD>
								<TD style="WIDTH: 311px; HEIGHT: 4px" bgColor="#335eb4"><asp:label id="lblPesoBruto" runat="server" CssClass="TextoBlanco" Width="150px" Height="6px"> vEREDAS:</asp:label></TD>
								<TD style="WIDTH: 261px; HEIGHT: 4px" bgColor="#f0f0f0" colSpan="2"><asp:textbox id="txtVeredas" runat="server" CssClass="normalDetalle" Width="200px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px; HEIGHT: 23px" bgColor="#335eb4"><asp:label id="Label11" runat="server" CssClass="TextoBlanco" Width="136px">cimentacion profunda</asp:label></TD>
								<TD style="WIDTH: 248px; HEIGHT: 23px" bgColor="#dddddd"><asp:textbox id="txtCimentacionProfunda" runat="server" CssClass="normalDetalle" Width="238px"
										MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 311px; HEIGHT: 23px" bgColor="#335eb4"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco" Width="150px">BARANDAS:</asp:label></TD>
								<TD style="WIDTH: 261px; HEIGHT: 23px" bgColor="#dddddd" colSpan="2"><asp:textbox id="txtBarandas" runat="server" CssClass="normalDetalle" Width="200px" MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px" bgColor="#335eb4"><asp:label id="Label8" runat="server" CssClass="TextoBlanco" Width="150px">cimentacion superficial</asp:label></TD>
								<TD style="WIDTH: 248px" bgColor="#f0f0f0"><asp:textbox id="txtCimentacionSuperficial" runat="server" CssClass="normalDetalle" Width="238px"
										MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 311px" bgColor="#335eb4"><asp:label id="Label16" runat="server" CssClass="TextoBlanco" Width="150px">EsCALERAS:</asp:label></TD>
								<TD style="WIDTH: 261px" bgColor="#f0f0f0" colSpan="2"><asp:textbox id="txtEscaleras" runat="server" CssClass="normalDetalle" Width="200px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px" bgColor="#335eb4"><asp:label id="Label9" runat="server" CssClass="TextoBlanco" Width="96px">estribos:</asp:label></TD>
								<TD style="WIDTH: 248px" bgColor="#dddddd"><asp:textbox id="txtEstribos" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 311px" bgColor="#335eb4"><asp:label id="Label17" runat="server" CssClass="TextoBlanco" Width="150px">DESAGUES:</asp:label></TD>
								<TD style="WIDTH: 261px" bgColor="#dddddd" colSpan="2"><asp:textbox id="txtDesagues" runat="server" CssClass="normalDetalle" Width="200px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px" bgColor="#335eb4"><asp:label id="Label10" runat="server" CssClass="TextoBlanco" Width="96px">pilares</asp:label></TD>
								<TD style="WIDTH: 248px" bgColor="#f0f0f0"><asp:textbox id="txtPilares" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 311px" bgColor="#335eb4"><asp:label id="Label18" runat="server" CssClass="TextoBlanco" Width="150px">PESO NETO (TON):</asp:label></TD>
								<TD class="normalDetalle" id="CelltxtPesoNeto" style="WIDTH: 261px" bgColor="#f0f0f0"
									colSpan="2" runat="server"><ew:numericbox id="txtPesoNeto" runat="server" CssClass="normaldetalle" Width="200px" MaxLength="5"
										DecimalPlaces="2" PositiveNumber="True"></ew:numericbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 105px" bgColor="#335eb4"><asp:label id="lblEspesor" runat="server" CssClass="TextoBlanco" Width="150px">apoyos</asp:label></TD>
								<TD style="WIDTH: 248px" bgColor="#dddddd"><asp:textbox id="txtApoyos" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 311px" bgColor="#335eb4"><asp:label id="Label19" runat="server" CssClass="TextoBlanco" Width="150px">PESO BRUTO (TON):</asp:label></TD>
								<TD class="normalDetalle" id="CelltxtPesoBruto" style="WIDTH: 261px" bgColor="#dddddd"
									colSpan="2" runat="server"><ew:numericbox id="txtPesoBruto" runat="server" CssClass="normaldetalle" Width="200px" MaxLength="5"
										DecimalPlaces="2" PositiveNumber="True"></ew:numericbox></TD>
							</TR>
						</TABLE>
						<TABLE id="Table5" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="780" border="1">
							<TR>
								<TD style="WIDTH: 428px; HEIGHT: 19px" bgColor="#000080" colSpan="6"><asp:label id="lblAspectosAdministrativos" runat="server" CssClass="TituloPrincipalBlanco"
										Width="216px">ASPECTOS ADMINISTRATIVOS</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px; HEIGHT: 25px" bgColor="#335eb4"><asp:label id="lblEstado" runat="server" CssClass="TextoBlanco" Width="150px">ESTADO:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlEstadoProyecto" style="WIDTH: 242px" bgColor="#f0f0f0"
									colSpan="2" runat="server"><asp:dropdownlist id="ddlEstadoProyecto" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 167px" bgColor="#335eb4"><asp:label id="lblJefeProyecto" runat="server" CssClass="TextoBlanco" Width="140px">JEFE DE PROYECTO:</asp:label></TD>
								<TD bgColor="#f0f0f0" colSpan="2"><asp:textbox id="txtJefeProyectos" runat="server" CssClass="normaldetalle" Width="180px"></asp:textbox><asp:imagebutton id="ibtBuscaJefeProyectos" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CausesValidation="False"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px" bgColor="#335eb4"><asp:label id="lblDocumentoPrincipal" runat="server" CssClass="TextoBlanco" Width="150px">DOCUMENTO PRINCIPAL:</asp:label></TD>
								<TD style="WIDTH: 242px" bgColor="#dddddd" colSpan="2"><asp:textbox id="txtDocumentoPrincipal" runat="server" CssClass="normalDetalle" Width="238px"
										MaxLength="100"></asp:textbox></TD>
								<TD style="WIDTH: 167px" bgColor="#335eb4"><asp:label id="lblFirmaAcuerdo" runat="server" CssClass="TextoBlanco" Width="140px">Fecha Acuerdo:</asp:label></TD>
								<TD class="normalDetalle" id="CellcalFechaFirmaAcuerdo" bgColor="#dddddd" colSpan="2"
									runat="server"><ew:calendarpopup id="calFechaFirmaAcuerdo" runat="server" CssClass="combos" Width="180px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True"
										Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False" DESIGNTIMEDRAGDROP="234"
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
								<TD style="WIDTH: 143px; HEIGHT: 23px" bgColor="#335eb4"><asp:label id="lblTipoDocumento" runat="server" CssClass="TextoBlanco" Width="150px">TIPO DOCUMENTO:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlTipoDocumento" style="WIDTH: 242px" bgColor="#f0f0f0"
									colSpan="2" runat="server"><asp:dropdownlist id="ddlTipoDocumento" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 167px" bgColor="#335eb4"><asp:label id="lblInicioContractual" runat="server" CssClass="TextoBlanco" Width="140px" Height="12px">Inicio ContracTUAL:</asp:label></TD>
								<TD class="normalDetalle" id="CellcalFechaInicioContractual" bgColor="#f0f0f0" colSpan="2"
									runat="server"><ew:calendarpopup id="calFechaInicioContractual" runat="server" CssClass="combos" Width="180px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True"
										Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False" CalendarLocation="Bottom">
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
								<TD style="WIDTH: 143px" bgColor="#335eb4"><asp:label id="lblOtroDocumento" runat="server" CssClass="TextoBlanco" Width="150px">Otro Documento:</asp:label></TD>
								<TD style="WIDTH: 242px" width="242" bgColor="#dddddd" colSpan="2"><asp:textbox id="txtOtroDocumento" runat="server" CssClass="normalDetalle" Width="238px" MaxLength="100"></asp:textbox></TD>
								<TD style="WIDTH: 167px" bgColor="#335eb4"><asp:label id="lblFinContractual" runat="server" CssClass="TextoBlanco" Width="140px">Fin Contractual:</asp:label></TD>
								<TD class="normalDetalle" id="CellcalFechaFinContractual" style="WIDTH: 208px" bgColor="#dddddd"
									colSpan="2" runat="server"><ew:calendarpopup id="calFechaFinContractual" runat="server" CssClass="combos" Width="180px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True" Culture="Spanish (Chile)"
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
								<TD style="WIDTH: 143px; HEIGHT: 16px" bgColor="#335eb4"><asp:label id="lblOtroTipoDocumento" runat="server" CssClass="TextoBlanco" Width="150px">TIPO DOCUMENTO:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlOtroTipoDocumento" style="WIDTH: 242px" bgColor="#f0f0f0"
									colSpan="2" runat="server"><asp:dropdownlist id="ddlOtroTipoDocumento" runat="server" CssClass="normaldetalle" Width="238px"
										Height="17px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 167px" bgColor="#335eb4"><asp:label id="lblInicioreal" runat="server" CssClass="TextoBlanco" Width="140px">Inicio Real:</asp:label></TD>
								<TD class="normalDetalle" id="CellcalFechaInicioReal" bgColor="#f0f0f0" colSpan="2"
									runat="server"><ew:calendarpopup id="calFechaInicioReal" runat="server" CssClass="combos" Width="180px" ImageUrl="../../imagenes/BtPU_Mas.gif"
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
								<TD style="WIDTH: 143px" bgColor="#335eb4"><asp:label id="lblPrecioContractual" runat="server" CssClass="TextoBlanco" Width="150px">PRECIO CONTRACUAL</asp:label></TD>
								<TD class="normalDetalle" id="CelltxtPrecioContractual" style="WIDTH: 242px" bgColor="#dddddd"
									colSpan="2" runat="server">
									<ew:numericbox id="txtPrecioContractual" runat="server" CssClass="normaldetalle" Width="238px"
										MaxLength="15" PositiveNumber="True" DecimalPlaces="2" AutoFormatCurrency="True" DollarSign=" "
										PlacesBeforeDecimal="11"></ew:numericbox></TD>
								<TD style="WIDTH: 167px" bgColor="#335eb4"><asp:label id="lblFinReal" runat="server" CssClass="TextoBlanco" Width="140px">fin Real:</asp:label></TD>
								<TD class="normalDetalle" id="CellcalFechaFinReal" style="WIDTH: 208px" bgColor="#dddddd"
									colSpan="2" runat="server"><ew:calendarpopup id="calFechaFinReal" runat="server" CssClass="combos" Width="180px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										AutoPostBack="True" NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True"
										Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False" CalendarLocation="Bottom">
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
								<TD style="WIDTH: 143px" bgColor="#335eb4"><asp:label id="Label1" runat="server" CssClass="TextoBlanco" Width="150px">PRECIO REAL:</asp:label></TD>
								<TD class="normalDetalle" id="CelltxtPrecioReal" style="WIDTH: 242px" bgColor="#f0f0f0"
									colSpan="2" runat="server">
									<ew:numericbox id="txtPrealModificado" runat="server" CssClass="normaldetalle" Width="238px" MaxLength="15"
										PositiveNumber="True" DecimalPlaces="2" AutoFormatCurrency="True" DollarSign=" " PlacesBeforeDecimal="11"></ew:numericbox></TD>
								<TD style="WIDTH: 167px" bgColor="#335eb4"><asp:label id="lblTermino" runat="server" CssClass="TextoBlanco" Width="140px">ENTREGA :</asp:label></TD>
								<TD class="normalDetalle" id="CellcalFechaEntrega" bgColor="#f0f0f0" colSpan="2" runat="server"><ew:calendarpopup id="calFechaEntrega" runat="server" CssClass="combos" Width="180px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										NullableLabelText=" " Nullable="True" GoToTodayText="Fecha de Hoy" ClearDateText="Limpiar Fecha" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True"
										AllowArbitraryText="False" CalendarLocation="Bottom">
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
								<TD style="WIDTH: 143px" bgColor="#335eb4"><asp:label id="lblIdMoneda" runat="server" CssClass="TextoBlanco" Width="150px">MONEDA:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlMoneda" style="WIDTH: 242px" bgColor="#dddddd"
									colSpan="2" runat="server"><asp:dropdownlist id="ddlMoneda" runat="server" CssClass="normaldetalle" Width="238px" Height="17px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 167px" bgColor="#335eb4"><asp:label id="lblEjecucion" runat="server" CssClass="TextoBlanco" Width="140px">Ejecucion (DIAS):</asp:label></TD>
								<TD class="normalDetalle" bgColor="#dddddd" colSpan="2"><asp:textbox id="txtTEjecucion" runat="server" CssClass="normaldetalle" Width="200px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px; HEIGHT: 68px" bgColor="#335eb4"><asp:label id="lblFuenteInformacion" runat="server" CssClass="TextoBlanco" Width="150px">FUENTE INFORMACION:</asp:label></TD>
								<TD class="normaldetalle" style="HEIGHT: 68px" bgColor="#f0f0f0" colSpan="5"><asp:textbox id="txtFuenteInformacion" runat="server" CssClass="normalDetalle" Width="100%" Height="62px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px" bgColor="#335eb4"><asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco" Width="150px">OBSERVACIONES</asp:label></TD>
								<TD bgColor="#dddddd" colSpan="5"><asp:textbox id="txtObservaciones" runat="server" CssClass="normalDetalle" Width="100%" Height="54px"
										TextMode="MultiLine"></asp:textbox></TD>
							</TR>
						</TABLE>
						<TABLE id="Table8" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="778" border="1">
							<TR>
								<TD bgColor="#000080" colSpan="6"><asp:label id="Label2" runat="server" CssClass="TituloPrincipalBlanco">INFORMACION ADICIONAL</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px; HEIGHT: 41px" bgColor="#335eb4"><asp:label id="lblEspTecnica" runat="server" CssClass="TextoBlanco" Width="150px">Esp. Tecnica:</asp:label></TD>
								<TD class="normalDetalle" id="CellfEspecificaciones" style="WIDTH: 371px; HEIGHT: 41px"
									bgColor="#f0f0f0" colSpan="2" runat="server"><INPUT class="normaldetalle" id="fEspecificaciones" style="WIDTH: 192px; HEIGHT: 17px"
										type="file" size="12" name="File4" runat="server">&nbsp;<asp:hyperlink id="hlkEspecificacionTecnica" runat="server" CssClass="normalDetalle" Target="_blank">es</asp:hyperlink>
									<asp:CheckBox id="ckEliminarEspTecnica" runat="server" Text="Eliminar Archivo"></asp:CheckBox></TD>
								<TD style="WIDTH: 162px; HEIGHT: 41px" bgColor="#335eb4"><asp:label id="lblPresupuesto" runat="server" CssClass="TextoBlanco" Width="150px" Height="14px">ACTA DE RECEPCION:</asp:label></TD>
								<TD class="normalDetalle" id="CellfPresupuesto" bgColor="#f0f0f0" runat="server" style="HEIGHT: 41px"><INPUT class="normaldetalle" id="fPresupuesto" style="WIDTH: 170px; HEIGHT: 17px" type="file"
										size="9" name="File1" runat="server">&nbsp;<asp:hyperlink id="hlkPresupuesto" runat="server" CssClass="normalDetalle" Target="_blank">pr</asp:hyperlink>
									<asp:CheckBox id="ckEliminarPresupuesto" runat="server" Text="Eliminar Archivo"></asp:CheckBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px" bgColor="#335eb4"><asp:label id="lblContrato" runat="server" CssClass="TextoBlanco" Width="150px">Contrato</asp:label></TD>
								<TD class="normalDetalle" id="CellfContrato" style="WIDTH: 371px" bgColor="#dddddd"
									colSpan="2" runat="server"><INPUT class="normaldetalle" id="fContrato" style="WIDTH: 192px; HEIGHT: 17px" type="file"
										size="12" name="File3" runat="server">&nbsp;<asp:hyperlink id="hlkContrato" runat="server" CssClass="normalDetalle" Target="_blank">co</asp:hyperlink>
									<asp:CheckBox id="ckEliminarContrato" runat="server" Text="Eliminar Archivo"></asp:CheckBox></TD>
								<TD style="WIDTH: 162px" bgColor="#335eb4"><asp:label id="lblPlano" runat="server" CssClass="TextoBlanco" Width="150px">Plano:</asp:label></TD>
								<TD class="normalDetalle" id="CellfPlano" bgColor="#dddddd" runat="server"><INPUT class="normaldetalle" id="fPlano" style="WIDTH: 174px; HEIGHT: 17px" type="file"
										size="9" name="File2" runat="server">&nbsp;<asp:hyperlink id="hlkPlano" runat="server" CssClass="normalDetalle" Target="_blank">pl</asp:hyperlink>
									<asp:CheckBox id="ckEliminarPlano" runat="server" Text="Eliminar Archivo"></asp:CheckBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px; HEIGHT: 45px" colSpan="6"><P align="left">
										<TABLE id="tblAtras" style="WIDTH: 80px; HEIGHT: 27px" cellSpacing="0" cellPadding="0"
											width="80" border="0" runat="server">
											<TR>
												<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
											</TR>
										</TABLE>
									</P>
								</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="6"><asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;<IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
										runat="server"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 110px" colSpan="6"></TD>
							</TR>
						</TABLE>
						<INPUT id="hIdCliente" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="Hidden1"
							runat="server"><INPUT id="hFoto" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="Hidden1"
							runat="server"><INPUT id="hIdJefeProyecto" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="hPresupuesto"
							runat="server"><INPUT id="hPresupuesto" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="hPresupuesto"
							runat="server"><INPUT id="hContrato" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="Hidden1"
							runat="server"><INPUT id="hEspecificaciones" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1"
							name="Hidden1" runat="server"><INPUT id="hPlano" style="WIDTH: 16px; HEIGHT: 12px" type="hidden" size="1" name="Hidden1"
							runat="server"></TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
