<%@ Page language="c#" Codebehind="DetalleAdministracionIndicadoresPorObjetivoEspecifico.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.DetalleAdministracionIndicadoresPorObjetivoEspecifico" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetallePlanEstrategicoActividad</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form2" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<DIV align="center"></DIV>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="800" align="center" border="0">
							<TR>
								<TD>
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="800" align="center" border="1"
										runat="server" borderColor="#ffffff">
										<TR>
										</TR>
										<TR>
											<TD colSpan="3">
											</TD>
										</TR>
										<TR>
											<TD bgColor="#000080" colSpan="2"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
											<TD width="5"></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label13" runat="server" CssClass="TextoBlanco">Indicador</asp:label></TD>
											<TD class="normaldetalle" id="CellddlbPrioridad" bgColor="#dddddd" runat="server">
												<asp:DropDownList id="ddlbIndicador" runat="server" Width="300px" CssClass="NormalDetalle"></asp:DropDownList></TD>
											<TD width="5">
												<cc2:requireddomvalidator id="rfvIndicador" runat="server" ControlToValidate="ddlbIndicador">*</cc2:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="2">
											</TD>
											<TD width="5"></TD>
										</TR>
									</TABLE>
									<DIV align="center">
										<TABLE id="Table8" width="180" align="center" border="0" runat="server">
											<TR>
												<TD width="94">
													<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
												<TD width="101"><SPAN class="normal"><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
															runat="server"></SPAN></TD>
											</TR>
										</TABLE>
									</DIV>
								</TD>
							</TR>
							<TR>
								<TD align="right"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/RetornarAlFormato.GIF"
										runat="server"></TD>
							</TR>
							<TR>
								<TD align="center"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
