<%@ Page language="c#" Codebehind="DefaultOperacionesFinancieras.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DefaultOperacionesFinancieras" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js">  </SCRIPT>
		<!--oncontextmenu="return false" -->
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR>
					<TD width="100%" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" width="100%" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Estados de Operaciones></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Operaciones</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" width="100%" colSpan="3">
						<TABLE id="Table9" style="WIDTH: 675px; HEIGHT: 314px" cellSpacing="1" cellPadding="1"
							width="675" border="0">
							<TR>
								<TD align="center" colSpan="3"><asp:label id="Label2" runat="server" CssClass="TituloPrincipalBlanco" BackColor="Transparent"
										ForeColor="Navy" Font-Bold="True" Width="211px">OPERACIONES FINANCIERAS</asp:label></TD>
							</TR>
							<TR>
								<TD align="center"></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD align="center" width="25%">
									<TABLE id="Table10" style="WIDTH: 184px; HEIGHT: 210px" cellSpacing="1" cellPadding="1"
										width="184" border="0">
										<TR>
											<TD>
												<P align="center"><IMG id="ibtnLeneadeCredito" onmouseover="this.src='../imagenes/btnLineasCredito_f2.gif'"
														style="WIDTH: 170px; CURSOR: hand; HEIGHT: 40px" onmouseout="this.src='../imagenes/btnLineasCredito.gif'"
														height="40" alt="" src="../imagenes/btnLineasCredito.gif" width="170" border="0" name="GestionFinanciera_r2_c6"
														runat="server"></P>
											</TD>
										</TR>
										<TR>
											<TD><IMG id="ibtnCartasCredito" onmouseover="this.src='../imagenes/GestionFinanciera_r2_c6_f2.gif'"
													style="CURSOR: hand" onmouseout="this.src='../imagenes/GestionFinanciera_r2_c6.gif'"
													height="40" alt="" src="../imagenes/GestionFinanciera_r2_c6.gif" width="175" border="0"
													name="GestionFinanciera_r2_c6" runat="server"></TD>
										</TR>
										<TR>
											<TD><IMG id="ibtnCartasFianzas" onmouseover="this.src='../imagenes/GestionFinanciera_r5_c6_f2.gif'"
													style="CURSOR: hand" onmouseout="this.src='../imagenes/GestionFinanciera_r5_c6.gif'"
													height="42" alt="" src="../imagenes/GestionFinanciera_r5_c6.gif" width="175" border="0"
													name="GestionFinanciera_r5_c6" runat="server"></TD>
										</TR>
										<TR>
											<TD><IMG id="ibtnPrestamosBancarios" onmouseover="this.src='../imagenes/GestionFinanciera_r9_c6_f2.gif'"
													style="CURSOR: hand" onmouseout="this.src='../imagenes/GestionFinanciera_r9_c6.gif'"
													height="37" alt="" src="../imagenes/GestionFinanciera_r9_c6.gif" width="175" border="0"
													name="GestionFinanciera_r9_c6" runat="server"></TD>
										</TR>
										<TR>
											<TD><IMG id="ibtnLetrasCambio" onmouseover="this.src='../imagenes/GestionFinanciera_r12_c6_f2.gif'"
													style="CURSOR: hand" onmouseout="this.src='../imagenes/GestionFinanciera_r12_c6.gif'"
													height="45" alt="" src="../imagenes/GestionFinanciera_r12_c6.gif" width="175" border="0"
													name="GestionFinanciera_r12_c6" runat="server"></TD>
										</TR>
									</TABLE>
								</TD>
								<TD align="center" width="50%"><IMG style="WIDTH: 200px; HEIGHT: 222px" height="222" src="../imagenes/EscudoSimaDorado3.jpg"
										width="200"></TD>
								<TD width="25%">
									<TABLE id="Table1" style="WIDTH: 180px; HEIGHT: 164px" cellSpacing="1" cellPadding="1"
										width="180" border="0">
										<TR>
											<TD><IMG id="btnCuentasBancarias" onmouseover="this.src='../imagenes/btnCuentasBancarias_f2.gif'"
													style="CURSOR: hand" onmouseout="this.src='../imagenes/btnCuentasBancarias.gif'"
													height="40" alt="" src="../imagenes/btnCuentasBancarias.gif" width="175" border="0"
													name="btnCuentasBancarias" runat="server"></TD>
										</TR>
										<TR>
											<TD><IMG id="btnValores" onmouseover="this.src='../imagenes/btnValores_f2.gif'" style="DISPLAY: none; CURSOR: hand"
													onmouseout="this.src='../imagenes/btnValores.gif'" height="40" alt="" src="../imagenes/btnValores.gif"
													width="175" border="0" name="btnValores" runat="server"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"></TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
