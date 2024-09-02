<%@ Page language="c#" Codebehind="AdmRegistrarProgramaPagosConvenio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.AdmRegistrarProgramaPagosConvenio" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD vAlign="top"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" style="WIDTH: 871px; HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Administración >  Convenios SIMA - MGP >  Administrar Cronogramas por  Convenio ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> DETALLE PROGRAMA DE PAGOS</asp:label></TD>
				</TR>
				<TR width="100%">
					<TD vAlign="top" align="center">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD><asp:label id="lblTitulo" runat="server" CssClass="TituloSecundario"> CONVENIO SIMA MGP...</asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblTituloSecundario" runat="server" CssClass="TituloSecundario">REGISTRO CRONOGRAMA DE PAGOS</asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD style="WIDTH: 150px" bgColor="#f5f5f5"><asp:label id="lblPeriodo" runat="server" CssClass="TextoAzul">PERIODO:&nbsp;</asp:label><ew:numericbox id="nbPeriodo" runat="server" CssClass="normal" Width="80px" RealNumber="False"
										PositiveNumber="True" MaxLength="4"></ew:numericbox><asp:rangevalidator id="rdvPeriodo" runat="server" MaximumValue="2050" MinimumValue="2000" ControlToValidate="nbPeriodo">*</asp:rangevalidator><asp:requiredfieldvalidator id="rqdvPeriodo" runat="server" ControlToValidate="nbPeriodo">*</asp:requiredfieldvalidator></TD>
								<TD style="WIDTH: 146px" bgColor="#f5f5f5"><asp:label id="lblMes" runat="server" CssClass="TextoAzul">MES:&nbsp;</asp:label>&nbsp;<asp:dropdownlist id="ddltMeses" runat="server" Width="104px" Height="16px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 257px" bgColor="#f5f5f5"><asp:label id="lblMontoProgramado" runat="server" CssClass="TextoAzul">MONTO PROGRAMADO NS:&nbsp;</asp:label><ew:numericbox id="nbMonto" runat="server" CssClass="normal" Width="100px" PositiveNumber="True"
										MaxLength="15" DecimalPlaces="3" PlacesBeforeDecimal="12"></ew:numericbox></TD>
								<TD bgColor="#f5f5f5"><asp:label id="lblMontoCobrado" runat="server" CssClass="TextoAzul">MONTO COBRADO NS:&nbsp;</asp:label><ew:numericbox id="nbMontoCobrado" runat="server" CssClass="normal" Width="100px" PositiveNumber="True"
										MaxLength="15" DecimalPlaces="3" PlacesBeforeDecimal="12"></ew:numericbox><asp:requiredfieldvalidator id="rqdvMonto" runat="server" ControlToValidate="nbMonto">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px" bgColor="#f5f5f5"><asp:label id="lblObservaciones" runat="server" CssClass="TextoAzul">OBSERVACIONES: </asp:label></TD>
								<TD style="WIDTH: 146px" bgColor="#f5f5f5"></TD>
								<TD style="WIDTH: 257px" bgColor="#f5f5f5"></TD>
								<TD bgColor="#f5f5f5"></TD>
							</TR>
						</TABLE>
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD bgColor="#f5f5f5"><asp:textbox id="txtObservaciones" runat="server" CssClass="normal" Width="100%" MaxLength="2000"
										Height="70px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD bgColor="#f5f5f5"></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif"></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left"><IMG id="ibtnAtras1" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 15px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center">
									<cc1:domvalidationsummary id="DomValidationSummary1" runat="server" Width="136px" DisplayMode="List" ShowMessageBox="True"></cc1:domvalidationsummary></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<P></P>
	</body>
</HTML>
