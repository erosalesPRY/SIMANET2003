<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleAdministrarGrupoDeCentroDeCostos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DetalleAdministrarGrupoDeCentroDeCostos" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleAdministrarGrupoDeCentroDeCostos</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="100%" rowSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Grupo de Centro de Costos</asp:label><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera> Detalle de Grupo de Centro de Costos</asp:label></TD>
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
											Height="16px" Width="358px"></asp:label></TD>
								</TR>
								<TR>
									<TD class="headerDetalle" style="WIDTH: 182px; HEIGHT: 3px"><asp:label id="Label1" runat="server" Width="134px">NRO Grupo de Centro de Costos</asp:label></TD>
									<TD bgColor="#f0f0f0"><asp:textbox id="txtNroGrupoCC" runat="server" CssClass="normaldetalle" Width="64px"></asp:textbox></TD>
									<TD style="HEIGHT: 3px" bgColor="#dddddd"><cc1:requireddomvalidator id="rfvNroGCC" runat="server" ControlToValidate="txtNroGrupoCC">*</cc1:requireddomvalidator></TD>
								</TR>
								<TR>
									<TD class="headerDetalle" style="WIDTH: 182px; HEIGHT: 3px"><asp:label id="Label2" runat="server" Width="142px">NOMBRE DE GRUPO DE CENTRO DE COSTOS</asp:label></TD>
									<TD bgColor="#dddddd"><asp:textbox id="txtNombreGrupoCC" runat="server" CssClass="normaldetalle" Width="293px"></asp:textbox></TD>
									<TD style="HEIGHT: 3px" bgColor="#dddddd"><cc1:requireddomvalidator id="rfvNombreGCC" runat="server" ControlToValidate="txtNombreGrupoCC">*</cc1:requireddomvalidator></TD>
								</TR>
								<TR>
									<TD class="headerDetalle" style="WIDTH: 182px">
										<asp:label id="Label3" runat="server" Width="142px">TIPO DE PRESUPUESTO</asp:label></TD>
									<TD bgColor="#f0f0f0">
										<asp:DropDownList id="ddlbTipoPresupuesto" runat="server" CssClass="normaldetalle" Width="295px"></asp:DropDownList></TD>
									<TD bgColor="#f0f0f0">
										<cc1:requireddomvalidator id="rfvTipoPresupuesto" runat="server" ControlToValidate="ddlbTipoPresupuesto">*</cc1:requireddomvalidator></TD>
								</TR>
							</TABLE>
						</DIV>
						<DIV align="center">
							<TABLE id="Table3" style="WIDTH: 165px; HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="165"
								align="center" border="0">
								<TR>
									<TD style="HEIGHT: 17px" colSpan="3"><IMG style="WIDTH: 171px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="171"></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<P align="center"><cc1:domvalidationsummary id="vSum" runat="server" CssClass="normal" Height="40px" Width="70px" DisplayMode="List"
												EnableClientScript="False" ShowMessageBox="True"></cc1:domvalidationsummary></P>
									</TD>
								</TR>
								<TR>
									<TD><asp:imagebutton id="ibtnAceptar" runat="server" Width="86px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
									<TD><IMG style="WIDTH: 5px; HEIGHT: 8px" height="8" src="../../imagenes/spacer.gif" width="5"></TD>
									<TD><asp:imagebutton id="ibtnCancelar" runat="server" Height="22px" Width="87px" ImageUrl="../../imagenes/bt_cancelar.gif"
											CausesValidation="False"></asp:imagebutton></TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<P align="center">&nbsp;</P>
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
