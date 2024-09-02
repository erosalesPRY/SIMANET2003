<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalleUnidadApoyo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.DetalleUnidadApoyo" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
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
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands" colSpan="3"><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Inicio >Administración Unidad Apoyo ></asp:label><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina"> Registro de Unidad de Apoyo</asp:label></TD>
				</TR>
				<TR>
					<TD class="normal" colSpan="3">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
							<TR>
								<TD class="normal" bgColor="#000080" colSpan="2">
									<asp:label id="Label11" runat="server" CssClass="TituloPrincipalBlanco">DATOS DE LA OFICINA</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 20px" align="right" bgColor="#335eb4">
									<asp:label id="Label2" runat="server" CssClass="TextoBlanco" Width="38px">Nombre:</asp:label></TD>
								<TD style="HEIGHT: 20px" bgColor="#f0f0f0">
									<asp:textbox id="txtNombre" runat="server" CssClass="normaldetalle" Width="350px" BorderStyle="Groove"
										MaxLength="80"></asp:textbox>
									<cc1:requireddomvalidator id="rfvNombre" runat="server" ErrorMessage="*" ControlToValidate="txtNombre">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 18px" align="right" bgColor="#335eb4">
									<asp:label id="Label1" runat="server" CssClass="TextoBlanco" Width="38px">SIGLAS:</asp:label></TD>
								<TD style="HEIGHT: 18px" bgColor="#dddddd">
									<asp:textbox id="txtSiglas" runat="server" CssClass="normaldetalle" Width="110px" BorderStyle="Groove"
										MaxLength="10"></asp:textbox>
									<cc1:requireddomvalidator id="rfvSiglas" runat="server" ErrorMessage="*" ControlToValidate="txtSiglas">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 18px" vAlign="top" align="right" bgColor="#335eb4">
									<asp:label id="Label3" runat="server" CssClass="TextoBlanco" Width="38px">OBSERVACIONES:</asp:label></TD>
								<TD style="HEIGHT: 18px" bgColor="#f0f0f0">
									<asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Width="496px" BorderStyle="Groove"
										MaxLength="500" TextMode="MultiLine" Height="72px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2">
									<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;
									<asp:imagebutton id="ibtnCancelar" runat="server" Width="87px" Height="22px" ImageUrl="../imagenes/bt_cancelar.gif"
										CausesValidation="False"></asp:imagebutton><BR>
									<cc1:domvalidationsummary id="vSum" runat="server" Width="169px" Height="22px" DisplayMode="List" ShowMessageBox="True"
										EnableClientScript="False"></cc1:domvalidationsummary></TD>
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
