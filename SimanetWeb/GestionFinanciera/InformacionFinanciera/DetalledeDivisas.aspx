<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalledeDivisas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.InformacionFinanciera.DetalledeDivisas" %>
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
					<TD class="RutaPaginaActual" style="HEIGHT: 14px" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle de Divisas</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 14px" vAlign="top" width="100%"><IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table2" style="WIDTH: 295px; HEIGHT: 173px" cellSpacing="1" cellPadding="1"
							width="295" align="center" border="0">
							<TR>
								<TD bgColor="#000080" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="16px" Width="304px"
										DESIGNTIMEDRAGDROP="25">DETALLE DIVISA</asp:label></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerdetalle"><asp:label id="Label1" runat="server" DESIGNTIMEDRAGDROP="176">Divisa:</asp:label></TD>
								<TD><asp:label id="lblDivisa" runat="server">Label</asp:label></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="headerdetalle"><asp:label id="Label2" runat="server" DESIGNTIMEDRAGDROP="181">Fecha:</asp:label></TD>
								<TD><asp:label id="lblFecha" runat="server">Label</asp:label></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerdetalle"><asp:label id="Label3" runat="server" Width="103px" DESIGNTIMEDRAGDROP="182">Monto Compra:</asp:label></TD>
								<TD><ew:numericbox id="nMontoCompra" runat="server" CssClass="normaldetalle" Width="105px" MaxLength="5"
										PositiveNumber="True" PlacesBeforeDecimal="2" AutoFormatCurrency="True" DollarSign=" "></ew:numericbox></TD>
								<TD><cc1:requireddomvalidator id="rdvMontoCompra" runat="server" Width="14px" ControlToValidate="nMontoCompra"
										ErrorMessage="*">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="headerdetalle"><asp:label id="Label4" runat="server" DESIGNTIMEDRAGDROP="641">Monto Venta:</asp:label></TD>
								<TD><ew:numericbox id="nMontoVenta" runat="server" CssClass="normaldetalle" Width="105px" DESIGNTIMEDRAGDROP="710"
										MaxLength="5" PositiveNumber="True" PlacesBeforeDecimal="2" AutoFormatCurrency="True" DollarSign=" "></ew:numericbox></TD>
								<TD><cc1:requireddomvalidator id="rdvMontoVenta" runat="server" Width="14px" ControlToValidate="nMontoVenta" ErrorMessage="*">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerdetalle"><asp:label id="Label5" runat="server">Vol Acc.</asp:label></TD>
								<TD><ew:numericbox id="nVolAccion" runat="server" CssClass="normaldetalle" Width="105px" MaxLength="5"
										PositiveNumber="True" PlacesBeforeDecimal="2" AutoFormatCurrency="True" DollarSign=" " DecimalPlaces="2"></ew:numericbox></TD>
								<TD><cc1:requireddomvalidator id="rdvVolAccion" runat="server" Width="14px" ControlToValidate="nVolAccion" ErrorMessage="*">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD>
									<P align="right">&nbsp;</P>
								</TD>
								<TD>
									<P align="right">
										<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="140" align="left" border="0">
											<TR>
												<TD>
													<P align="right"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></P>
												</TD>
												<TD><asp:imagebutton id="ibtnCancelar" runat="server" ImageUrl="../../imagenes/bt_cancelar.gif" CausesValidation="False"></asp:imagebutton></TD>
											</TR>
										</TABLE>
									</P>
								</TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="592"><IMG height="5" src="../imagenes/spacer.gif" width="592"></TD>
				</TR>
			</table>
			&nbsp;
			<cc1:domvalidationsummary id="Vresumen" runat="server" Height="24px" Width="160px" EnableClientScript="False"
				DisplayMode="List" ShowMessageBox="True"></cc1:domvalidationsummary></form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
