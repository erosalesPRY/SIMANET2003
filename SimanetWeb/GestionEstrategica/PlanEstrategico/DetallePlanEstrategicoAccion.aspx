<%@ Page language="c#" Codebehind="DetallePlanEstrategicoAccion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.DetallePlanEstrategicoAccion" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetallePlanEstrategicoAccion</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form2" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" borderColor="#ffffff">
				<TR>
					<TD>
						<DIV align="center"></DIV>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="820" align="center" border="0">
							<TR>
								<TD>
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="820" align="center" border="1"
										runat="server" borderColor="#ffffff">
										<TR>
											<TD colSpan="3">
												<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="99%" bgColor="#f0f0f0" border="0">
													<TR>
														<TD width="90">
															<asp:Label id="Label5" runat="server" CssClass="normaldetalle" Width="128px" ForeColor="Navy">PLAN ESTRATEGICO:</asp:Label></TD>
														<TD colSpan="2">
															<asp:label id="lblNombrePlanBase" runat="server" CssClass="normaldetalle" Width="100%"></asp:label></TD>
													</TR>
													<TR>
														<TD width="90">
															<asp:Label id="Label4" runat="server" CssClass="normaldetalle" Width="128px" ForeColor="Navy">OBJETIVO GENERAL:</asp:Label></TD>
														<TD width="90">
															<asp:label id="lblObjGral" runat="server" CssClass="normaldetalle"></asp:label></TD>
														<TD>
															<asp:label id="lblNombreObjGral" runat="server" CssClass="normaldetalle" Width="100%"></asp:label></TD>
													</TR>
													<TR>
														<TD width="90">
															<asp:Label id="Label3" runat="server" CssClass="normaldetalle" Width="128px" ForeColor="Navy">OBJETIVO ESPECÍFICO:</asp:Label></TD>
														<TD width="90">
															<asp:label id="lblObjEsp" runat="server" CssClass="normaldetalle"></asp:label></TD>
														<TD>
															<asp:label id="lblNombreObjEsp" runat="server" CssClass="normaldetalle" Width="100%"></asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 709px" bgColor="#000080" colSpan="2"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
											<TD width="5"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 158px" bgColor="#335eb4"><asp:label id="Label1" runat="server" CssClass="TextoBlanco"> Codigo</asp:label></TD>
											<TD style="WIDTH: 608px" bgColor="#f0f0f0"><asp:textbox id="txtCodigoAccion" runat="server" CssClass="NormalDetalle" BorderStyle="Groove"
													Width="250px"></asp:textbox></TD>
											<TD width="5">
												<cc2:requireddomvalidator id="rfvCodigoAccion" runat="server" ControlToValidate="txtCodigoAccion">*</cc2:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 158px" bgColor="#335eb4"><asp:label id="Label2" runat="server" CssClass="TextoBlanco"> DESCRIPCIÓN</asp:label></TD>
											<TD style="WIDTH: 608px" bgColor="#dddddd"><asp:textbox id="txtNombreAccion" runat="server" CssClass="NormalDetalle" BorderStyle="Groove"
													Width="580px"></asp:textbox></TD>
											<TD width="5">
												<cc2:requireddomvalidator id="rfvnNombreAccion" runat="server" ControlToValidate="txtNombreAccion">*</cc2:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 158px" bgColor="#335eb4">
												<asp:label id="lblLider" runat="server" CssClass="TextoBlanco" Visible="False"> AREA</asp:label></TD>
											<TD style="WIDTH: 608px" bgColor="#f0f0f0" id="CellddlbGrupoCC" runat="server" class="NormalDetalle">
												<asp:DropDownList id="ddlbGrupoCC" runat="server" CssClass="NormalDetalle" Width="512px" Visible="False"></asp:DropDownList></TD>
											<TD width="5">
												<cc2:requireddomvalidator id="rfvnGrupoCC" runat="server" Visible="False">*</cc2:requireddomvalidator></TD>
										</TR>
									</TABLE>
									<DIV align="center">
										<TABLE id="Table8" width="180" align="center" border="0" runat="server">
											<TR>
												<TD width="94"><asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"
														Height="22px"></asp:imagebutton></TD>
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
								<TD align="center"><cc2:domvalidationsummary id="vSum" runat="server" CssClass="normal" ShowMessageBox="True" DisplayMode="List"
										EnableClientScript="False"></cc2:domvalidationsummary></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><INPUT id="hidCargoLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidCargoLider"
							runat="server"><INPUT id="hIdAreaLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdAreaLider"
							runat="server"><INPUT id="hIdPersonalLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdPersonalLider"
							runat="server"><INPUT id="hNombreLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hNombreLider"
							runat="server"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
