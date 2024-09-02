<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetallePlanEstrategicoObjetivosGenerales.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica.DetallePlanEstrategicoObjetivosGenerales" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetallePlanEstrategicoObjetivosGenerales</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<P><uc1:menu id="Menu1" runat="server"></uc1:menu></P>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Objetivo General</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD align="center">
												<TABLE class="normal" id="Table7" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
													width="550" align="center" border="1">
													<TR>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#000080" colSpan="5"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD vAlign="top" bgColor="#335eb4" style="HEIGHT: 105px"><asp:label id="lblProyecto" runat="server" CssClass="TextoBlanco">Descripcion:</asp:label></TD>
														<TD bgColor="#f0f0f0" colSpan="4" style="HEIGHT: 105px"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" TextMode="MultiLine"
																MaxLength="4000" Width="400px" Height="100px"></asp:textbox></TD>
														<TD bgColor="#ffffff" style="HEIGHT: 105px"><cc2:requireddomvalidator id="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 14px" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblTipoObjetivo" runat="server" CssClass="TextoBlanco">Tipo de Objetivo:</asp:label></TD>
														<TD id="cellddlbTipoObjetivo" style="HEIGHT: 14px" bgColor="#dddddd" colSpan="4" runat="server"
															class="normaldetalle">
															<asp:dropdownlist id="ddlbTipoObjetivo" runat="server" CssClass="normaldetalle" Width="200px" BackColor="Transparent"></asp:dropdownlist>
															<cc2:requireddomvalidator id="rfvTipoObjetivo" runat="server" ControlToValidate="ddlbTipoObjetivo">*</cc2:requireddomvalidator>
														</TD>
														<TD style="HEIGHT: 14px" bgColor="#ffffff" colSpan="1" rowSpan="1"></TD>
													</TR>
													<TR>
													</TR>
													<TR>
														<TD id="TdCeldaCancelar" vAlign="top" colSpan="6" runat="server">
															<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
														<TD bgColor="#ffffff"></TD>
													</TR>
													<TR>
														<TD vAlign="top"></TD>
														<TD colSpan="4"></TD>
														<TD bgColor="#ffffff"></TD>
													</TR>
												</TABLE>
												<INPUT id="hIdCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdCodigo"
													runat="server">
												<cc2:domvalidationsummary id="vSum" runat="server" Height="42px" EnableClientScript="False" DisplayMode="List"
													ShowMessageBox="True"></cc2:domvalidationsummary></TD>
											<TD vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="180" border="0">
										<TR>
											<TD>
												<asp:imagebutton id="ibtnAceptar" runat="server" Height="22px" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton>
												<IMG id="ibtnCancelar" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
													runat="server"></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
