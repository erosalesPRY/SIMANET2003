<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetallePlanEstrategicoObjetivosEspecificos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.DetallePlanEstrategicoObjetivosEspecificos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" onload="SetFocusInicial('txtNroDocumento'); ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<SCRIPT language="javascript" src="../../js/wz_tooltip.js"></SCRIPT>
			<SCRIPT language="javascript" src="../../js/tip_balloon.js"></SCRIPT>
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD vAlign="top" align="center" width="100%">
							<TABLE id="Table1" style="WIDTH: 807px; HEIGHT: 206px" cellSpacing="1" cellPadding="1"
								width="807" border="0" bgcolor="#f0f0f0">
								<TR>
									<TD colSpan="3">
										<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
											<TR>
												<TD style="WIDTH: 119px">
													<asp:Label id="Label5" runat="server" CssClass="normaldetalle" Width="128px" ForeColor="Navy">PLAN ESTRATEGICO:</asp:Label></TD>
												<TD>
													<asp:Label id="lblPlanEstrategico" runat="server" CssClass="normaldetalle" ForeColor="Navy">PLAN ESTRATEGICO:</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 119px">
													<asp:Label id="Label4" runat="server" CssClass="normaldetalle" Width="128px" ForeColor="Navy">OBJETIVO GENERAL:</asp:Label></TD>
												<TD>
													<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="WIDTH: 49px">
																<asp:Label id="lblCodObjGeneral" runat="server" CssClass="normaldetalle" Width="48px" ForeColor="Navy">00000</asp:Label></TD>
															<TD width="100%">
																<asp:Label id="lblObjetivoGeneral" runat="server" CssClass="normaldetalle" Width="598px" ForeColor="Navy">OBJETIVO GENERAL:</asp:Label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD bgColor="#000080" colSpan="3"><asp:label id="Label6" runat="server" CssClass="TituloPrincipalBlanco">DETALLE OBJETIVO ESPECIFICO</asp:label></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD class="HeaderDetalle" style="WIDTH: 63px"><asp:label id="Label1" runat="server">CODIGO:</asp:label></TD>
									<TD style="WIDTH: 338px"><asp:textbox id="txtCodigo" runat="server" CssClass="normaldetalle"></asp:textbox></TD>
									<TD>
										<cc1:requireddomvalidator id="rfvnCodigo" runat="server" Width="8px" ControlToValidate="txtCodigo">*</cc1:requireddomvalidator></TD>
								</TR>
								<TR class="AlternateItemDetalle">
									<TD class="HeaderDetalle" style="WIDTH: 63px; HEIGHT: 47px" vAlign="top" align="left"><asp:label id="Label2" runat="server">DESCRIPCION:</asp:label></TD>
									<TD style="WIDTH: 338px; HEIGHT: 47px"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" TextMode="MultiLine"
											Height="42px" Width="669px"></asp:textbox></TD>
									<TD style="HEIGHT: 47px">
										<cc1:requireddomvalidator id="rfvnDescripcion" runat="server" Width="8px" ControlToValidate="txtDescripcion">*</cc1:requireddomvalidator></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD class="HeaderDetalle" style="WIDTH: 63px"><asp:label id="Label3" runat="server" Width="112px">CENTRO OPERATIVO:</asp:label></TD>
									<TD style="WIDTH: 338px" class="normaldetalle" id="CellddlCentroOperativo" runat="server"><asp:dropdownlist id="ddlCentroOperativo" runat="server" CssClass="normaldetalle" Width="272px"></asp:dropdownlist></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD class="HeaderDetalle" style="WIDTH: 63px">
										<asp:label id="Label7" runat="server" Width="112px">Ver Total:</asp:label></TD>
									<TD class="normaldetalle" style="WIDTH: 338px">
										<asp:CheckBox id="chkTotalVisible" runat="server" Checked="True"></asp:CheckBox></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD align="right" width="100%" colSpan="3" bgColor="#ffffff"><IMG id="ibtnAtras1" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/RetornarAlFormato.GIF"
											runat="server"></TD>
								</TR>
								<TR class="AlternateItemDetalle">
									<TD align="right" width="100%" colSpan="3" bgColor="#ffffff">
										<TABLE id="Table2" style="WIDTH: 182px; HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="182"
											align="center" border="0" runat="server">
											<TR>
												<TD width="50%">
													<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
												<TD width="50%"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="100%"><cc1:domvalidationsummary id="Vresumen" runat="server" Height="24px" Width="160px" ShowMessageBox="True" DisplayMode="List"
								EnableClientScript="False"></cc1:domvalidationsummary></TD>
					</TR>
				</TBODY>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TBODY></TABLE>
	</body>
</HTML>
