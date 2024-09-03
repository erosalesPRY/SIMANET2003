<%@ Page language="c#" Codebehind="DetalleCotizacionMetales.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.InformacionFinanciera.DetalleCotizacionMetales" %>
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
					<td colSpan="1" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label>
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Cotización de Metales</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"><IMG style="WIDTH: 160px; HEIGHT: 16px" height="16" src="../../imagenes/spacer.gif" width="160"></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%">
						<TABLE id="Table2" style="WIDTH: 335px; HEIGHT: 170px" cellSpacing="1" cellPadding="1"
							width="335" align="center" border="0">
							<TR>
								<TD bgColor="#000080" colSpan="3">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Width="304px" DESIGNTIMEDRAGDROP="25"
										Height="16px">COTIZACIÓN DE METALES</asp:label></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerDetalle">
									<asp:label id="Label6" runat="server">Fecha:</asp:label></TD>
								<TD>
									<asp:Label id="lblFecha" runat="server" DESIGNTIMEDRAGDROP="114">Label</asp:Label></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="headerDetalle">
									<asp:label id="Label1" runat="server" DESIGNTIMEDRAGDROP="169">Metal:</asp:label></TD>
								<TD>
									<asp:Label id="lblMetal" runat="server" DESIGNTIMEDRAGDROP="177">Label</asp:Label></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerDetalle">
									<asp:label id="Label2" runat="server" DESIGNTIMEDRAGDROP="181">Mercado:</asp:label></TD>
								<TD>
									<asp:Label id="lblMercado" runat="server">Label</asp:Label></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="headerDetalle">
									<asp:label id="Label3" runat="server" DESIGNTIMEDRAGDROP="181">Monto:</asp:label></TD>
								<TD>
									<ew:numericbox id="nMonto" runat="server" CssClass="normaldetalle" Width="152px" MaxLength="8"
										PositiveNumber="True" PlacesBeforeDecimal="5" AutoFormatCurrency="True" DollarSign=" "></ew:numericbox></TD>
								<TD>
									<cc1:requireddomvalidator id="rdvMonto" runat="server" Width="14px" ErrorMessage="*" ControlToValidate="nMonto">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerDetalle">
									<asp:label id="Label5" runat="server"> Medida:</asp:label></TD>
								<TD>
									<asp:TextBox id="txtUnidadMed" runat="server" DESIGNTIMEDRAGDROP="233" Width="152px" CssClass="normaldetalle"></asp:TextBox></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="headerDetalle">
									<asp:label id="Label4" runat="server">Observacion:</asp:label></TD>
								<TD>
									<asp:TextBox id="txtObservacion" runat="server" Width="303px" Height="104px" TextMode="MultiLine"
										CssClass="normaldetalle"></asp:TextBox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD>
								</TD>
								<TD>
									<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="167" border="0" style="WIDTH: 167px; HEIGHT: 30px"
										align="right">
										<TR>
											<TD>
												<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton>
											</TD>
											<TD>
												<asp:imagebutton id="ibtnCancelar" runat="server" ImageUrl="../../imagenes/bt_cancelar.gif" CausesValidation="False"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="592"><IMG height="5" src="../imagenes/spacer.gif" width="592"></TD>
				</TR>
			</table>
			&nbsp;
			<cc1:domvalidationsummary id="Vresumen" runat="server" Width="160px" Height="24px" ShowMessageBox="True" DisplayMode="List"
				EnableClientScript="False"></cc1:domvalidationsummary>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
