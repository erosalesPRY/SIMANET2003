<%@ Page language="c#" Codebehind="DetalledeADR.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.InformacionFinanciera.DetalledeADR" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
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
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle de ADRS en New York</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"><IMG style="WIDTH: 160px; HEIGHT: 16px" height="16" src="../../imagenes/spacer.gif" width="160"></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%">
						<TABLE id="Table2" style="WIDTH: 335px; HEIGHT: 48px" cellSpacing="1" cellPadding="1" width="335"
							align="center" border="0">
							<TR>
								<TD bgColor="#000080" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="16px" Width="304px"
										DESIGNTIMEDRAGDROP="25">DETALLE ADRS EN NEW YORK</asp:label></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerDetalle"><asp:label id="Label1" runat="server" DESIGNTIMEDRAGDROP="176">Entidad:</asp:label></TD>
								<TD><asp:label id="lblEntidad" runat="server" DESIGNTIMEDRAGDROP="114">Label</asp:label></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="headerDetalle"><asp:label id="Label2" runat="server" DESIGNTIMEDRAGDROP="181">Fecha:</asp:label></TD>
								<TD><asp:label id="lblFecha" runat="server">Label</asp:label></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerDetalle"><asp:label id="Label3" runat="server" DESIGNTIMEDRAGDROP="182">Cierre US$:</asp:label></TD>
								<TD><ew:numericbox id="nPorcCierre" runat="server" CssClass="normaldetalle" Width="105px" MaxLength="5"
										PositiveNumber="True" PlacesBeforeDecimal="2" AutoFormatCurrency="True" DollarSign=" " DecimalPlaces="2"></ew:numericbox></TD>
								<TD><cc1:requireddomvalidator id="rdvPorcCierre" runat="server" Width="14px" ControlToValidate="nPorcCierre" ErrorMessage="*">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="headerDetalle"><asp:label id="Label4" runat="server" DESIGNTIMEDRAGDROP="641"> Var(%):</asp:label></TD>
								<TD><ew:numericbox id="nPorcVar" runat="server" CssClass="normaldetalle" Width="105px" DESIGNTIMEDRAGDROP="710"
										MaxLength="5" PositiveNumber="True" PlacesBeforeDecimal="2" AutoFormatCurrency="True" DollarSign=" "
										DecimalPlaces="2"></ew:numericbox></TD>
								<TD><cc1:requireddomvalidator id="rdvPorcVar" runat="server" Width="14px" ControlToValidate="nPorcVar" ErrorMessage="*">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerDetalle"><asp:label id="Label5" runat="server">Vol Acc.</asp:label></TD>
								<TD><ew:numericbox id="nPorcVolAcc" runat="server" CssClass="normaldetalle" Width="105px" MaxLength="5"
										PositiveNumber="True" PlacesBeforeDecimal="2" AutoFormatCurrency="True" DollarSign=" " DecimalPlaces="2"></ew:numericbox></TD>
								<TD><cc1:requireddomvalidator id="rdvVolacc" runat="server" Width="14px" ControlToValidate="nPorcVolAcc" ErrorMessage="*">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD colSpan="2">
									<TABLE id="Table1" style="WIDTH: 143px; HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="143"
										align="right" border="0">
										<TR>
											<TD><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD><asp:imagebutton id="ibtnCancelar" runat="server" ImageUrl="../../imagenes/bt_cancelar.gif" CausesValidation="False"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
								<TD colSpan="3"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" width="592"><IMG height="5" src="../imagenes/spacer.gif" width="592"></td>
				</tr>
			</table>
			<cc1:domvalidationsummary id="Vresumen" runat="server" Height="24px" Width="160px" EnableClientScript="False"
				DisplayMode="List" ShowMessageBox="True"></cc1:domvalidationsummary>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
