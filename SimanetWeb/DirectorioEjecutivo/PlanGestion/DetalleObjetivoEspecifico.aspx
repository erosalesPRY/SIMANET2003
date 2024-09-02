<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalleObjetivoEspecifico.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion.DetalleObjetivoEspecifico" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleObjetivoEspecifico</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Plan de Gestión ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Objetivos</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<P align="left"><INPUT id="hidCargoLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidCargoLider"
								runat="server"><INPUT id="hIdAreaLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdAreaLider"
								runat="server"><INPUT id="hIdPersonalLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdPersonalLider"
								runat="server"><INPUT id="hNombreLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hNombreLider"
								runat="server"></P>
					</TD>
				</TR>
				<TR>
					<TD><asp:image id="Image1" runat="server" Width="48px" Height="24px" ImageUrl="../../imagenes/spacer.gif"></asp:image></TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center"></DIV>
						<TABLE id="Table3" style="WIDTH: 617px; HEIGHT: 360px" cellSpacing="0" cellPadding="0"
							width="617" align="center" border="0">
							<TR>
								<TD style="HEIGHT: 233px">
									<P align="left">
										<TABLE id="Table2" style="WIDTH: 495px; HEIGHT: 214px" borderColor="#ffffff" cellSpacing="0"
											cellPadding="0" width="495" align="center" border="1" runat="server">
											<TR>
											</TR>
											<TR>
											</TR>
											<TR>
												<TD style="WIDTH: 445px" colSpan="2">
													<TABLE id="Table4" style="WIDTH: 504px; HEIGHT: 36px" borderColor="#ffffff" cellSpacing="0"
														cellPadding="0" width="504" bgColor="#f0f0f0" border="3">
														<TR>
															<TD style="WIDTH: 31px"><asp:label id="lblProceso" runat="server" CssClass="normaldetalle"></asp:label></TD>
															<TD><asp:label id="lblNombreProceso" runat="server" CssClass="normaldetalle"></asp:label></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 31px"><asp:label id="lblSubProceso" runat="server" CssClass="normaldetalle"></asp:label></TD>
															<TD><asp:label id="lblNombreSubProceso" runat="server" CssClass="normaldetalle"></asp:label></TD>
														</TR>
													</TABLE>
												</TD>
												<TD style="WIDTH: 138px"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 444px" bgColor="#000080" colSpan="2"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
												<TD style="WIDTH: 138px"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 857px" bgColor="#335eb4"><asp:label id="Label1" runat="server" CssClass="TextoBlanco">OE Codigo</asp:label></TD>
												<TD style="WIDTH: 387px" bgColor="#f0f0f0"><asp:textbox id="txtCodigoOE" runat="server" CssClass="NormalDetalle" Width="250px" BorderStyle="Groove"
														ReadOnly="True"></asp:textbox></TD>
												<TD>
													<P align="left">&nbsp;</P>
												</TD>
											</TR>
											<TR>
												<TD style="WIDTH: 857px" bgColor="#335eb4"><asp:label id="Label2" runat="server" CssClass="TextoBlanco">OE Nombre</asp:label></TD>
												<TD style="WIDTH: 387px" bgColor="#dddddd"><asp:textbox id="txtNombreOE" runat="server" CssClass="NormalDetalle" Width="423px" BorderStyle="Groove"></asp:textbox></TD>
												<TD><cc2:requireddomvalidator id="rfvNombreProceso" runat="server" ControlToValidate="txtNombreOE">*</cc2:requireddomvalidator></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 857px" bgColor="#335eb4"><asp:label id="lblAE" runat="server" CssClass="TextoBlanco">AE</asp:label></TD>
												<TD style="WIDTH: 387px" bgColor="#f0f0f0"><ew:numericbox id="txtAvanceEconomica" runat="server" CssClass="normaldetalle" Width="100px" BorderStyle="Groove"
														PositiveNumber="True" MaxLength="6"></ew:numericbox></TD>
												<TD><cc2:rangedomvalidator id="RangeDomValidator1" runat="server" ControlToValidate="txtAvanceEconomica" ErrorMessage="Ingrese valores de 0 a 100"
														MinimumValue="00.00" MaximumValue="100.00">*</cc2:rangedomvalidator></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 857px" bgColor="#335eb4"><asp:label id="lblAF" runat="server" CssClass="TextoBlanco">AF</asp:label></TD>
												<TD style="WIDTH: 387px" bgColor="#dddddd"><ew:numericbox id="txtAvanceFinanciero" runat="server" CssClass="normaldetalle" Width="100px" BorderStyle="Groove"
														PositiveNumber="True" MaxLength="6"></ew:numericbox></TD>
												<TD><cc2:rangedomvalidator id="RangeDomValidator2" runat="server" ControlToValidate="txtAvanceFinanciero" ErrorMessage="Ingrese valores de 0 a 100"
														MinimumValue="00.00" MaximumValue="100.00">*</cc2:rangedomvalidator></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 857px" bgColor="#335eb4"><asp:label id="lblLider" runat="server" CssClass="TextoBlanco">Lider</asp:label></TD>
												<TD style="WIDTH: 387px" bgColor="#dddddd"><asp:textbox id="txtLider" runat="server" CssClass="NormalDetalle" Width="423px" Height="40px"
														BorderStyle="Groove" TextMode="MultiLine"></asp:textbox></TD>
												<TD><asp:imagebutton id="ibtnBuscarLider" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
														CausesValidation="False"></asp:imagebutton></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 857px" bgColor="#335eb4"><asp:label id="lblCO" runat="server" CssClass="TextoBlanco">CO</asp:label></TD>
												<TD style="WIDTH: 387px" bgColor="#dddddd"><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="NormalDetalle" Width="250px"></asp:dropdownlist></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 857px" bgColor="#335eb4"><asp:label id="lblOG" runat="server" CssClass="TextoBlanco">Plan Estratégico</asp:label></TD>
												<TD style="WIDTH: 387px" bgColor="#dddddd"><asp:dropdownlist id="ddlbObjetivoGenerales" runat="server" CssClass="NormalDetalle" Width="423px"></asp:dropdownlist></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 857px" bgColor="#335eb4"><asp:label id="Label3" runat="server" CssClass="TextoBlanco">SubProceso</asp:label></TD>
												<TD style="WIDTH: 387px" bgColor="#dddddd"><asp:dropdownlist id="ddlbSubProceso" runat="server" CssClass="NormalDetalle" Width="423px"></asp:dropdownlist></TD>
												<TD></TD>
											</TR>
											<TR>
											</TR>
											<TR>
											</TR>
											<TR>
											</TR>
											<TR>
											</TR>
										</TABLE>
									</P>
									<TABLE id="Table8" width="180" align="center" border="0">
										<TR>
											<TD width="94"><asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD width="101"><SPAN class="normal">&nbsp; <IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
														runat="server"></SPAN></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center"><cc2:domvalidationsummary id="vSum" runat="server" CssClass="normal" Width="542px" EnableClientScript="False"
										DisplayMode="List" ShowMessageBox="True"></cc2:domvalidationsummary></TD>
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
