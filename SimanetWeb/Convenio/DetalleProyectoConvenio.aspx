<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleProyectoConvenio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.DetalleProyectoConvenio" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Simanet</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" style="OVERFLOW-X: hidden; OVERFLOW-Y: scroll; WIDTH: 100%"
		onload="ObtenerHistorial2();" onunload="SubirHistorial();">
		<FORM id="Form1" method="post" runat="server" style="Z-INDEX: 0">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR width="100%">
					<TD width="100%" valign="baseline">
						<uc1:Header id="Header1" runat="server"></uc1:Header>
					</TD>
				</TR>
				<tr>
					<TD vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Administración > Convenio</asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> DETALLE DE LA ACTIVIDAD</asp:label></TD>
				</TR>
				<TR width="100%">
					<TD width="100%" align="center">
						<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="700" border="0">
							<TR>
								<TD bgColor="#000080" align="center" colSpan="3" width="20%"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"> CONVENIO SIMA - MGP:</asp:label></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" width="20%"><asp:label id="lblNroProyecto" runat="server" CssClass="TextoBlanco"> ACTIVIDAD:</asp:label></TD>
								<TD bgColor="#f0f0f0"><ew:numericbox id="nbNroProyecto" runat="server" CssClass="normaldetalle" Width="88px" MaxLength="3"
										PositiveNumber="True" RealNumber="False"></ew:numericbox><cc1:requireddomvalidator id="rqdvProyecto" runat="server" ControlToValidate="nbNroProyecto">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" width="20%"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco">DESCRIPCION: &nbsp;</asp:label></TD>
								<TD bgColor="#dddddd"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="500px" MaxLength="1500"
										TextMode="MultiLine" Height="56px"></asp:textbox>
									<cc1:requireddomvalidator id="rqdvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" width="20%"><asp:label id="lblMonto" runat="server" CssClass="TextoBlanco">MONTO ASIGNADO (S/.)</asp:label></TD>
								<TD bgColor="#f0f0f0"><ew:numericbox id="nbMontoAsignado" runat="server" CssClass="normaldetalle" Width="120px" MaxLength="15"
										PositiveNumber="True" DecimalPlaces="3" AutoFormatCurrency="True" DollarSign=" "></ew:numericbox></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" width="20%">
									<asp:label id="Label3" runat="server" CssClass="TextoBlanco">MONTO COMPROMETIDO (S/.)</asp:label></TD>
								<TD bgColor="#dddddd">
									<ew:numericbox id="nbMontoComprometido" runat="server" CssClass="normaldetalle" PositiveNumber="True"
										MaxLength="15" Width="120px" DollarSign=" " AutoFormatCurrency="True" DecimalPlaces="3"></ew:numericbox></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" style="HEIGHT: 22px" width="20%">
									<asp:label id="Label1" runat="server" CssClass="TextoBlanco" style="Z-INDEX: 0">MONTO EJECUTADO (S/.)</asp:label></TD>
								<TD bgColor="#f0f0f0" style="HEIGHT: 22px">
									<ew:numericbox id="nbMontoEjecutado" runat="server" CssClass="normaldetalle" PositiveNumber="True"
										MaxLength="15" Width="120px" DollarSign=" " AutoFormatCurrency="True" DecimalPlaces="3" style="Z-INDEX: 0"></ew:numericbox></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" width="20%">
									<asp:label style="Z-INDEX: 0" id="Label5" runat="server" CssClass="TextoBlanco">MONTO PAGADO (/S.)</asp:label></TD>
								<TD bgColor="#dddddd">
									<ew:numericbox style="Z-INDEX: 0" id="txtMontoPagado" runat="server" CssClass="normaldetalle" PositiveNumber="True"
										MaxLength="15" Width="120px" DollarSign=" " AutoFormatCurrency="True" DecimalPlaces="3">0</ew:numericbox></TD>
							</TR>
							<TR>
								<TD class="TextoBlanco" width="20%" bgColor="#335eb4" style="HEIGHT: 2px">
									<asp:label id="lblEstado" runat="server" CssClass="TextoBlanco" style="Z-INDEX: 0">ESTADO: &nbsp;</asp:label></TD>
								<TD bgColor="#f0f0f0" style="HEIGHT: 2px">
									<asp:dropdownlist id="ddlbEstado" runat="server" CssClass="normaldetalle" style="Z-INDEX: 0"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" width="20%" style="HEIGHT: 4px"><asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco" style="Z-INDEX: 0">OBSERVACIONES: &nbsp;</asp:label></TD>
								<TD bgColor="#dddddd" style="HEIGHT: 4px"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="500px" MaxLength="2000"
										TextMode="MultiLine" Height="56px" style="Z-INDEX: 0"></asp:textbox></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" width="20%">
									<asp:label style="Z-INDEX: 0" id="Label4" runat="server" CssClass="TextoBlanco">ARCHIVO:</asp:label></TD>
								<TD><INPUT style="Z-INDEX: 0; WIDTH: 448px; HEIGHT: 22px" id="filContrato" class="normaldetalle"
										size="55" type="file" name="filContrato" runat="server"></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" width="20%">
									<asp:label style="Z-INDEX: 0" id="Label6" runat="server" CssClass="TextoBlanco">Proyecto en Ejecución :</asp:label></TD>
								<TD>
									<asp:textbox style="Z-INDEX: 0" id="txtConcepto" runat="server" CssClass="normaldetalle" MaxLength="1500"
										Width="500px" Height="57px" TextMode="MultiLine" Enabled="False"></asp:textbox>
									<asp:image style="Z-INDEX: 0" id="ibtnBuscarProyecto" runat="server" ImageUrl="../imagenes/BtPU_Mas.gif"></asp:image></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2" width="20%"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;<IMG id="ibtnAtras" style="CURSOR: hand" onclick="ReemplazaHistorial(); HistorialIrAtras();"
										alt="" src="../imagenes/bt_cancelar.gif"><INPUT id="objHistorial" type="hidden" name="objHistorial" style="WIDTH: 16px; HEIGHT: 10px"
										size="1"></TD>
							</TR>
							<TR>
								<TD width="20%" colSpan="2" align="center">
									<asp:label id="Label2" runat="server" CssClass="TextoBlanco" style="Z-INDEX: 0" Visible="False"> MONTO EN EJECUCION (S/.)</asp:label>
									<ew:numericbox id="nbMontoEnEjecucion" runat="server" CssClass="normaldetalle" PositiveNumber="True"
										MaxLength="15" Width="120px" DollarSign=" " AutoFormatCurrency="True" DecimalPlaces="3" style="Z-INDEX: 0"
										Visible="False">0</ew:numericbox>
									<ew:numericbox style="Z-INDEX: 0" id="txtAvanceFisico" runat="server" CssClass="normaldetalle"
										PositiveNumber="True" MaxLength="15" Width="120px" DollarSign=" " AutoFormatCurrency="True"
										DecimalPlaces="3" Visible="False">0</ew:numericbox></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2" width="20%"><cc1:domvalidationsummary id="DomValidationSummary1" runat="server" Width="136px" DisplayMode="List" ShowMessageBox="True"
										EnableClientScript="False"></cc1:domvalidationsummary><INPUT style="Z-INDEX: 0" id="hContrato" size="1" type="hidden" name="hContrato" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 10px" id="hIdProyecto" size="1" type="hidden"
										name="hIdProyecto" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
