<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalleProgramacionActividades.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.DetalleProgramacionActividades" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Simanet</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
</HEAD>
	<body style="OVERFLOW-X: hidden; OVERFLOW-Y: scroll; WIDTH: 100%" onunload="SubirHistorial();"
		onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR width="100%">
					<TD vAlign="baseline" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD style="HEIGHT: 12px" class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Administración > Convenio</asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> DETALLE PROGRAMA</asp:label></TD>
				</TR>
				<TR width="100%">
					<TD width="100%" align="center">
						<TABLE id="Table7" border="0" cellSpacing="0" cellPadding="0" width="80%">
							<TR>
								<TD bgColor="#000080" width="15%" colSpan="3" align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco">NUEVO PROGRAMA </asp:label></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" width="15%"><asp:label id="lblNroProyecto" runat="server" CssClass="TextoBlanco"> UNIDAD:</asp:label></TD>
								<TD bgColor="#f0f0f0"><asp:textbox style="Z-INDEX: 0" id="txtUnidad" runat="server" CssClass="normaldetalle" BorderStyle="Groove"
										Width="300px" MaxLength="50"></asp:textbox><cc1:requireddomvalidator id="rqdvActividad" runat="server" ControlToValidate="txtUnidad">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" width="15%"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco">NRO CASCO:</asp:label></TD>
								<TD bgColor="#dddddd"><asp:textbox style="Z-INDEX: 0" id="txtCasco" runat="server" CssClass="normaldetalle" BorderStyle="Groove"
										Width="300px" MaxLength="50"></asp:textbox><cc1:requireddomvalidator style="Z-INDEX: 0" id="rfvCasco" runat="server" ControlToValidate="txtCasco">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" width="15%"><asp:label id="lblMonto" runat="server" CssClass="TextoBlanco"> SOLICITUD DE TRABAJO</asp:label></TD>
								<TD bgColor="#f0f0f0"><asp:textbox style="Z-INDEX: 0" id="txtSt" runat="server" CssClass="normaldetalle" BorderStyle="Groove"
										Width="300px" MaxLength="50"></asp:textbox><cc1:requireddomvalidator style="Z-INDEX: 0" id="rfvSt" runat="server" ControlToValidate="txtSt">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" width="15%"><asp:label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="TextoBlanco">ORDEN DE TRABAJO</asp:label></TD>
								<TD bgColor="#dddddd"><asp:textbox style="Z-INDEX: 0" id="txtOt" runat="server" CssClass="normaldetalle" BorderStyle="Groove"
										Width="300px" MaxLength="50"></asp:textbox><cc1:requireddomvalidator style="Z-INDEX: 0" id="rfvOt" runat="server" ControlToValidate="txtOt">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 22px" bgColor="#335eb4" width="15%"><asp:label id="Label2" runat="server" CssClass="TextoBlanco"> DESCRIPCION</asp:label></TD>
								<TD style="HEIGHT: 22px" bgColor="#f0f0f0"><asp:textbox style="Z-INDEX: 0" id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="97%"
										MaxLength="1000" TextMode="MultiLine" Height="56px"></asp:textbox><cc1:requireddomvalidator style="Z-INDEX: 0" id="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" width="15%"><asp:label id="Label1" runat="server" CssClass="TextoBlanco">MONTO APROBADO (S/.)</asp:label></TD>
								<TD bgColor="#dddddd"><ew:numericbox id="nbMontoAprobado" runat="server" CssClass="normaldetalle" Width="120px" MaxLength="15"
										DecimalPlaces="3" AutoFormatCurrency="True" DollarSign=" " PositiveNumber="True"></ew:numericbox></TD>
							</TR>
							<TR>
								<TD class="TextoBlanco" bgColor="#335eb4" width="15%"><asp:label style="Z-INDEX: 0" id="Label5" runat="server" CssClass="TextoBlanco">AVANCE FISICO ACTUAL</asp:label></TD>
								<TD bgColor="#f0f0f0"><ew:numericbox id="nbAvanceFisico" runat="server" CssClass="normaldetalle" Width="120px" MaxLength="15"
										DecimalPlaces="3" AutoFormatCurrency="True" DollarSign=" " PositiveNumber="True"></ew:numericbox></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" width="15%"><asp:label id="lblEstado" runat="server" CssClass="TextoBlanco">AVANCE ECONOMICO ACTUAL</asp:label></TD>
								<TD bgColor="#dddddd"><ew:numericbox style="Z-INDEX: 0" id="nbAvanceEconomico" runat="server" CssClass="normaldetalle"
										Width="120px" MaxLength="15" DecimalPlaces="3" AutoFormatCurrency="True" DollarSign=" " PositiveNumber="True"></ew:numericbox></TD>
							</TR>
							<TR>
								<TD width="15%" colSpan="2" align="center"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;<IMG style="CURSOR: hand" id="ibtnAtras" onclick="ReemplazaHistorial(); HistorialIrAtras();"
										alt="" src="../imagenes/bt_cancelar.gif"></TD>
							</TR>
							<TR>
								<TD width="15%" colSpan="2" align="center">
									<cc2:domvalidationsummary style="Z-INDEX: 0" id="DomValidationSummary1" runat="server" Width="136px" EnableClientScript="False"
										DisplayMode="List" ShowMessageBox="True"></cc2:domvalidationsummary></TD>
							</TR>
						</TABLE>
						<INPUT id="hCodigo" type="hidden" name="hCodigo" runat="server"></TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
