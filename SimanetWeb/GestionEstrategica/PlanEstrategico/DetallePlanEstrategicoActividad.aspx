<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetallePlanEstrategicoActividad.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.DetallePlanEstrategicoActividad" %>
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
												<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="99%" bgColor="#f0f0f0" border="0">
													<TR>
														<TD width="90">
															<asp:Label id="Label7" runat="server" CssClass="normaldetalle" Width="128px" ForeColor="Navy">PLAN ESTRATEGICO:</asp:Label></TD>
														<TD colSpan="2">
															<asp:label id="lblNombrePlanBase" runat="server" CssClass="normaldetalle" Width="100%"></asp:label></TD>
													</TR>
													<TR>
														<TD width="90">
															<asp:Label id="Label8" runat="server" CssClass="normaldetalle" Width="128px" ForeColor="Navy">OBJETIVO GENERAL:</asp:Label></TD>
														<TD width="90">
															<asp:label id="lblObjGral" runat="server" CssClass="normaldetalle"></asp:label></TD>
														<TD>
															<asp:label id="lblNombreObjGral" runat="server" CssClass="normaldetalle" Width="100%"></asp:label></TD>
													</TR>
													<TR>
														<TD width="90">
															<asp:Label id="Label9" runat="server" CssClass="normaldetalle" Width="128px" ForeColor="Navy">OBJETIVO ESPECÍFICO:</asp:Label></TD>
														<TD width="90">
															<asp:label id="lblObjEsp" runat="server" CssClass="normaldetalle"></asp:label></TD>
														<TD>
															<asp:label id="lblNombreObjEsp" runat="server" CssClass="normaldetalle" Width="100%"></asp:label></TD>
													</TR>
													<TR>
														<TD width="90">
															<asp:Label id="Label10" runat="server" CssClass="normaldetalle" Width="128px" ForeColor="Navy">ACCIÓN:</asp:Label></TD>
														<TD width="90">
															<asp:label id="lblAccion" runat="server" CssClass="normaldetalle"></asp:label></TD>
														<TD>
															<asp:label id="lblNombreAccion" runat="server" CssClass="normaldetalle" Width="100%"></asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD bgColor="#000080" colSpan="2"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
											<TD width="5"></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4"><asp:label id="Label1" runat="server" CssClass="TextoBlanco">Codigo</asp:label></TD>
											<TD bgColor="#f0f0f0"><asp:textbox id="txtCodigoActividad" runat="server" CssClass="NormalDetalle" BorderStyle="Groove"
													Width="150px"></asp:textbox></TD>
											<TD width="5">
												<cc2:requireddomvalidator id="rfvCodigoActividad" runat="server" ControlToValidate="txtCodigoActividad">*</cc2:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4"><asp:label id="Label2" runat="server" CssClass="TextoBlanco"> DESCRIPCIÓN</asp:label></TD>
											<TD bgColor="#dddddd"><asp:textbox id="txtNombreActividad" runat="server" CssClass="NormalDetalle" BorderStyle="Groove"
													Width="616px"></asp:textbox></TD>
											<TD width="5">
												<cc2:requireddomvalidator id="rfvNombreActividad" runat="server" ControlToValidate="txtNombreActividad">*</cc2:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="lblLider" runat="server" CssClass="TextoBlanco">RESPONSABLE</asp:label></TD>
											<TD bgColor="#f0f0f0" id="CellddlbCC" runat="server" class="normaldetalle">
												<asp:textbox id="txtResponsable" runat="server" Width="616px" CssClass="NormalDetalle" BorderStyle="Groove"></asp:textbox></TD>
											<TD width="5">
												<cc2:requireddomvalidator id="rfvCC" runat="server" Visible="False">*</cc2:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="lblAF" runat="server" CssClass="TextoBlanco" Visible="False">AVANCE FISICO</asp:label></TD>
											<TD bgColor="#dddddd">
												<ew:numericbox id="txtAvanceFinanciero" runat="server" CssClass="normaldetalle" Width="100px" BorderStyle="Groove"
													MaxLength="6" PositiveNumber="True" PlacesBeforeDecimal="3" DecimalPlaces="2" Visible="False"></ew:numericbox></TD>
											<TD width="5">
												<cc2:requireddomvalidator id="rfvAvanceFinanciero" runat="server" Visible="False">*</cc2:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label4" runat="server" CssClass="TextoBlanco" Visible="False">TIPO</asp:label></TD>
											<TD bgColor="#f0f0f0" id="CellddlbRecurso" runat="server" class="normaldetalle">
												<asp:DropDownList id="ddlbRecurso" runat="server" Width="512px" CssClass="NormalDetalle" Visible="False"></asp:DropDownList></TD>
											<TD width="5">
												<cc2:requireddomvalidator id="rfvTipo" runat="server" ControlToValidate="ddlbTipo" Visible="False">*</cc2:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label6" runat="server" CssClass="TextoBlanco">Seguridad</asp:label></TD>
											<TD bgColor="#dddddd" id="CellddlbNivel" runat="server" class="normaldetalle">
												<asp:DropDownList id="ddlbNivel" runat="server" CssClass="NormalDetalle" Width="512px"></asp:DropDownList></TD>
											<TD width="5">
												<cc2:requireddomvalidator id="rfvNivel" runat="server" ControlToValidate="ddlbNivel">*</cc2:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label5" runat="server" CssClass="TextoBlanco">año</asp:label></TD>
											<TD bgColor="#f0f0f0">
												<ew:numericbox id="nPeriodo" runat="server" Width="100px" CssClass="normaldetalle" BorderStyle="Groove"
													PlacesBeforeDecimal="15" PositiveNumber="True" MaxLength="18" DollarSign=" ">2008</ew:numericbox></TD>
											<TD width="5">
												<cc2:requireddomvalidator id="rfvPeriodo" runat="server" ControlToValidate="nPeriodo">*</cc2:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label3" runat="server" CssClass="TextoBlanco" Visible="False">TIPO INVERSION</asp:label></TD>
											<TD bgColor="#f0f0f0" id="CellddlbTipo" runat="server" class="normaldetalle">
												<asp:DropDownList id="ddlbTipo" runat="server" CssClass="NormalDetalle" Width="512px" Visible="False"></asp:DropDownList></TD>
											<TD width="5">
												<cc2:requireddomvalidator id="rfvRecurso" runat="server" ControlToValidate="ddlbRecurso" Visible="False">*</cc2:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label11" runat="server" CssClass="TextoBlanco" Visible="False">RECURSO</asp:label></TD>
											<TD class="normaldetalle" id="CellddlbRcs" bgColor="#dddddd" runat="server">
												<asp:DropDownList id="ddlbRcs" runat="server" Width="512px" CssClass="NormalDetalle" Visible="False"></asp:DropDownList></TD>
											<TD width="5">
												<cc2:requireddomvalidator id="rfvRcs" runat="server" Visible="False">*</cc2:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label12" runat="server" CssClass="TextoBlanco" Visible="False">IMPORTANCIA</asp:label></TD>
											<TD class="normaldetalle" id="CellddlbImportancia" bgColor="#f0f0f0" runat="server">
												<asp:DropDownList id="ddlbImportancia" runat="server" Width="256px" CssClass="NormalDetalle" Visible="False"></asp:DropDownList></TD>
											<TD width="5"></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label13" runat="server" CssClass="TextoBlanco">PRIORIDAD</asp:label></TD>
											<TD class="normaldetalle" id="CellddlbPrioridad" bgColor="#dddddd" runat="server">
												<asp:DropDownList id="ddlbPrioridad" runat="server" Width="200px" CssClass="NormalDetalle"></asp:DropDownList></TD>
											<TD width="5">
												<cc2:requireddomvalidator id="rfvPrioridad" runat="server" ControlToValidate="ddlbPrioridad">*</cc2:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label38" runat="server" CssClass="TextoBlanco">Observaciones</asp:label></TD>
											<TD class="normaldetalle" bgColor="#f0f0f0">
												<asp:textbox id="txtObservaciones" runat="server" Width="100%" CssClass="NormalDetalle" BorderStyle="Groove"
													Height="50px" TextMode="MultiLine"></asp:textbox></TD>
											<TD width="5"></TD>
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
								<TD align="right">
									<asp:DropDownList id="ddlbCC" runat="server" Width="512px" CssClass="NormalDetalle" Visible="False"></asp:DropDownList><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/RetornarAlFormato.GIF"
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
