<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalledeMovimientoporConcepto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.DetalledeMovimientoporConcepto" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%">
						<asp:label id="Label2" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Cuentas Bancarias></asp:label>
						<asp:label id="Label4" runat="server" CssClass="RutaPaginaActual"> Administración de Detalle de Movimientos por concepto</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="650" border="0" style="WIDTH: 650px; HEIGHT: 160px">
							<TR>
								<TD bgColor="#f5f5f5" colSpan="3">
									<asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" Width="384px" ForeColor="Black"
										Font-Bold="True">CONCEPTO :</asp:label></TD>
							</TR>
							<TR>
								<TD bgColor="#000080" colSpan="3">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="16px" Width="376px">DETALLE ADMINISTRACION DE MOVIMIENTOS POR CONCEPTO</asp:label></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" width="10%">
									<asp:label id="lblObservacion" runat="server">DESCRIPCION :</asp:label></TD>
								<TD>
									<asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Height="54px" Width="100%"
										MaxLength="255" TextMode="MultiLine"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD></TD>
								<TD>
									<TABLE id="Table2" style="WIDTH: 185px; HEIGHT: 16px" cellSpacing="1" cellPadding="1" width="185"
										align="right" border="0">
										<TR>
											<TD>
												<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
													align="right" runat="server"></TD>
										</TR>
									</TABLE>
								</TD>
								<TD></TD>
							</TR>
							<TR>
								<TD colSpan="3">
									<asp:label id="lblMensaje" runat="server" CssClass="normal"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="85%"></TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
		<P>
			<cc1:domvalidationsummary id="Vresumen" runat="server" Height="24px" Width="160px" ShowMessageBox="True" DisplayMode="List"
				EnableClientScript="False"></cc1:domvalidationsummary></P>
	</body>
</HTML>
