<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc3" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetallePeriodoUnidadesApoyo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.DetallePeriodoUnidadesApoyo" %>
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
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 24px"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Comoperpac>  Administra Periodos COMOPERPAC ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Periodo COMOPERPAC</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center" width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="600" border="0">
							<TR>
								<TD bgColor="#000080"><asp:label id="Label11" runat="server" CssClass="TituloPrincipalBlanco">DATOS DEL PERIODO COMOPERPAC</asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="600" border="0">
							<TR>
								<TD style="WIDTH: 93px" align="right" bgColor="#335eb4"><asp:label id="lblPeriodo" runat="server" CssClass="TextoBlanco">PERIODO:</asp:label></TD>
								<TD bgColor="#f0f0f0"><ew:numericbox id="nbPeriodo" runat="server" CssClass="normaldetalle" Width="88px" MaxLength="4"
										PositiveNumber="True"></ew:numericbox></TD>
								<TD bgColor="#f0f0f0"><cc3:requireddomvalidator id="rqdvPeriodo" runat="server" ControlToValidate="nbPeriodo">*</cc3:requireddomvalidator>
									<cc3:RangeDomValidator id="ragvPeriodo" runat="server" ControlToValidate="nbPeriodo" ErrorMessage="*" MaximumValue="2050"
										MinimumValue="1845">*</cc3:RangeDomValidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 93px" align="right" bgColor="#335eb4"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco">DESCRIPCION:</asp:label></TD>
								<TD style="WIDTH: 395px" bgColor="#dddddd"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="392px" TextMode="MultiLine"
										Height="55px"></asp:textbox></TD>
								<TD bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 93px" align="right" bgColor="#335eb4"><asp:label id="Label1" runat="server" CssClass="TextoBlanco">OBSERVACIONES:</asp:label></TD>
								<TD style="WIDTH: 395px" bgColor="#f0f0f0"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="392px" TextMode="MultiLine"
										Height="55px"></asp:textbox></TD>
								<TD align="center" bgColor="#f0f0f0"></TD>
							</TR>
						</TABLE>
						<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="600" border="0">
							<TR>
								<TD align="center"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 24px" align="center"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;
									<asp:imagebutton id="ibtnCancelar" runat="server" Width="87px" Height="22px" ImageUrl="../imagenes/bt_cancelar.gif"
										CausesValidation="False"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD align="center"><cc3:domvalidationsummary id="DomValidationSummary1" runat="server" Width="91px" Height="26px" DisplayMode="List"
										EnableClientScript="False" ShowMessageBox="True"></cc3:domvalidationsummary></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
			<SCRIPT>
								<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
