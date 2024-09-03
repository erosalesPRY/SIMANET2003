<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleAdministrarCentroDeCostos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DetalleAdministrarCentroDeCostos" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleAdministrarCentroDeCostos</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Centro de Costos</asp:label><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera> Detalle de Centro de Costos</asp:label></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center">
							<TABLE id="Table2" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="300" align="center"
								border="0">
								<TR>
									<TD bgColor="#000080" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" DESIGNTIMEDRAGDROP="25"
											Height="16px" Width="441px"></asp:label></TD>
								</TR>
								<TR>
									<TD class="headerDetalle" style="WIDTH: 95px"><asp:label id="lblNroCC" runat="server" Width="157px">NRO de Centro de Costos</asp:label></TD>
									<TD bgColor="#dddddd"><asp:textbox id="txtNROCC" runat="server" CssClass="normaldetalle" Width="69px"></asp:textbox></TD>
									<TD bgColor="#dddddd"><cc1:requireddomvalidator id="rfvNroCC" runat="server" ControlToValidate="txtNROCC">*</cc1:requireddomvalidator></TD>
								</TR>
								<TR>
									<TD class="headerDetalle" style="WIDTH: 95px"><asp:label id="lblNROCuenta" runat="server" Width="142px">NRO Cuenta</asp:label></TD>
									<TD bgColor="#f0f0f0"><asp:textbox id="txtNROCuenta" runat="server" CssClass="normaldetalle" Width="68px"></asp:textbox></TD>
									<TD bgColor="#f0f0f0"><cc1:requireddomvalidator id="rfvNroCta" runat="server" ControlToValidate="txtNROCuenta">*</cc1:requireddomvalidator></TD>
								</TR>
								<TR>
									<TD class="headerDetalle" style="WIDTH: 95px"><asp:label id="lblNombreCC" runat="server" Width="111px">NOMBRE DE CENTRO DE COSTOS</asp:label></TD>
									<TD bgColor="#dddddd"><asp:textbox id="txtNombreCC" runat="server" CssClass="normaldetalle" Width="274px"></asp:textbox></TD>
									<TD bgColor="#dddddd"><cc1:requireddomvalidator id="rfvNombreCC" runat="server" ControlToValidate="txtNombreCC">*</cc1:requireddomvalidator></TD>
								</TR>
								<TR>
									<TD class="headerDetalle" style="WIDTH: 95px">
										<asp:label id="lblAnexo" runat="server" Width="111px">ANEXO</asp:label></TD>
									<TD bgColor="#dddddd">
										<ew:NumericBox id="txtAnexo" runat="server" CssClass="normaldetalle" Width="67px" MaxLength="4"></ew:NumericBox></TD>
									<TD bgColor="#dddddd"></TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center">
							<TABLE id="Table3" style="WIDTH: 186px; HEIGHT: 104px" cellSpacing="0" cellPadding="0"
								width="186" align="center" border="0">
								<TR>
									<TD><IMG style="WIDTH: 171px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="171"></TD>
								</TR>
								<TR>
									<TD>
										<P align="center"><cc1:domvalidationsummary id="vSum" runat="server" CssClass="normal" Height="40px" Width="70px" DisplayMode="List"
												ShowMessageBox="True" EnableClientScript="False"></cc1:domvalidationsummary></P>
									</TD>
								</TR>
								<TR>
									<TD><asp:imagebutton id="ibtnAceptar" runat="server" Width="86px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton><IMG style="WIDTH: 5px; HEIGHT: 8px" height="8" src="../../imagenes/spacer.gif" width="5">
										<asp:imagebutton id="ibtnCancelar" runat="server" Height="22px" Width="87px" ImageUrl="../../imagenes/bt_cancelar.gif"
											CausesValidation="False"></asp:imagebutton></TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
		<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
