<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetallePlanEstrategicoObjetivoGeneral.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.DetallePlanEstrategicoObjetivoGeneral" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<!--oncontextmenu="return false" -->
  </HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" bottomMargin="0"
		leftMargin="0" topMargin="0" onload="SetFocusInicial('txtNroDocumento'); ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<SCRIPT language="javascript" src="../../js/wz_tooltip.js"></SCRIPT>
			<SCRIPT language="javascript" src="../../js/tip_balloon.js"></SCRIPT>
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<tr>
						<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
					</tr>
					<TR>
						<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Carta de Crédito</asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="100%">
							<TABLE id="Table1" style="WIDTH: 655px; HEIGHT: 221px" cellSpacing="1" cellPadding="1"
								width="655" border="0">
								<TR>
									<TD colSpan="3">
										<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0"
											bgColor="#f0f0f0">
											<TR>
												<TD style="WIDTH: 119px">
													<asp:Label id="Label5" runat="server" CssClass="normaldetalle" Width="128px" ForeColor="Navy">PLAN ESTRATEGICO:</asp:Label></TD>
												<TD>
													<asp:Label id="lblPlanEstrategico" runat="server" CssClass="normaldetalle" ForeColor="Navy">PLAN ESTRATEGICO:</asp:Label></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD bgColor="#000080" colSpan="3">
										<asp:Label id="Label6" runat="server" CssClass="TituloPrincipalBlanco">DETALLE OBJETIVO GENERAL</asp:Label></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD style="WIDTH: 63px" class="HeaderDetalle">
										<asp:Label id="Label1" runat="server">CODIGO:</asp:Label></TD>
									<TD style="WIDTH: 545px" width="545">
										<asp:TextBox id="txtCodigo" runat="server" CssClass="normaldetalle" Width="184px"></asp:TextBox></TD>
									<TD>
										<cc1:requireddomvalidator id="rfvnCodigo" runat="server" Width="8px" ControlToValidate="txtCodigo">*</cc1:requireddomvalidator></TD>
								</TR>
								<TR class="AlternateItemDetalle">
									<TD style="WIDTH: 63px; HEIGHT: 47px" vAlign="top" align="left" class="HeaderDetalle">
										<asp:Label id="Label2" runat="server">DESCRIPCION:</asp:Label></TD>
									<TD>
										<asp:TextBox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="534px" Height="42px"
											TextMode="MultiLine"></asp:TextBox></TD>
									<TD>
										<cc1:requireddomvalidator id="rfvnDescripcion" runat="server" Width="8px" ControlToValidate="txtDescripcion">*</cc1:requireddomvalidator></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD style="WIDTH: 63px" class="HeaderDetalle">
										<asp:Label id="Label3" runat="server">FUNDAMENTO</asp:Label></TD>
									<TD>
										<asp:TextBox id="txtFundamento" runat="server" CssClass="normaldetalle" Width="534px" Height="42px"
											TextMode="MultiLine"></asp:TextBox></TD>
									<TD></TD>
								</TR>
								<TR class="AlternateItemDetalle">
									<TD style="WIDTH: 63px" class="HeaderDetalle">
										<asp:Label id="Label4" runat="server">REQUERIMIENTO:</asp:Label></TD>
									<TD>
										<asp:TextBox id="txtRequerimiento" runat="server" CssClass="normaldetalle" Width="534px" Height="42px"
											TextMode="MultiLine"></asp:TextBox></TD>
									<TD></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD class="HeaderDetalle" style="WIDTH: 63px">TEMA:</TD>
									<TD>
										<asp:TextBox id="txtTema" runat="server" CssClass="normaldetalle" Width="534px" TextMode="MultiLine"
											Height="42px"></asp:TextBox></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras1" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
											runat="server"></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD align="center" width="100%" colSpan="3" bgColor="#ffffff">
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
						<TD vAlign="top" width="100%" align="center"><cc1:domvalidationsummary id="Vresumen" runat="server" Width="160px" Height="24px" EnableClientScript="False"
								DisplayMode="List" ShowMessageBox="True"></cc1:domvalidationsummary>
						</TD>
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
