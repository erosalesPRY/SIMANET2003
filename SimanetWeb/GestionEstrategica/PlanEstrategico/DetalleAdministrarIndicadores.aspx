<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalleAdministrarIndicadores.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.DetalleAdministrarIndicadores" %>
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
											<TD bgColor="#335eb4">
												<asp:label id="Label1" runat="server" CssClass="TextoBlanco" Visible="False">Orden</asp:label></TD>
											<TD class="normaldetalle" bgColor="#dddddd">
												<ew:numericbox id="numOrden" runat="server" CssClass="normaldetalle" Width="80px" DollarSign=" "
													MaxLength="18" PositiveNumber="True" PlacesBeforeDecimal="15" BorderStyle="Groove" Visible="False">0</ew:numericbox></TD>
											<TD width="5"></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="2">
												<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="75%" border="1">
													<TR>
														<TD align="center" bgColor="#335eb4" colSpan="2">
															<asp:label id="Label34" runat="server" CssClass="TextoBlanco">I TRIMESTRE</asp:label></TD>
														<TD align="center" bgColor="#335eb4" colSpan="2">
															<asp:label id="Label35" runat="server" CssClass="TextoBlanco">II TRIMESTRE</asp:label></TD>
														<TD align="center" bgColor="#335eb4" colSpan="2">
															<asp:label id="Label36" runat="server" CssClass="TextoBlanco">III TRIMESTRE</asp:label></TD>
														<TD align="center" bgColor="#335eb4" colSpan="2">
															<asp:label id="Label37" runat="server" CssClass="TextoBlanco">IV TRIMESTRE</asp:label></TD>
													</TR>
													<TR>
														<TD bgColor="#335eb4">
															<asp:label id="Label14" runat="server" CssClass="TextoBlanco">Ene.</asp:label></TD>
														<TD>
															<ew:numericbox id="numEne" runat="server" CssClass="normaldetalle" Width="80px" BorderStyle="Groove"
																PlacesBeforeDecimal="15" PositiveNumber="True" MaxLength="18" DollarSign=" ">0</ew:numericbox></TD>
														<TD bgColor="#335eb4">
															<asp:label id="Label17" runat="server" CssClass="TextoBlanco">Abr.</asp:label></TD>
														<TD>
															<ew:numericbox id="numAbr" runat="server" CssClass="normaldetalle" Width="80px" BorderStyle="Groove"
																PlacesBeforeDecimal="15" PositiveNumber="True" MaxLength="18" DollarSign=" ">0</ew:numericbox></TD>
														<TD bgColor="#335eb4">
															<asp:label id="Label20" runat="server" CssClass="TextoBlanco">Jul.</asp:label></TD>
														<TD>
															<ew:numericbox id="numJul" runat="server" CssClass="normaldetalle" Width="80px" BorderStyle="Groove"
																PlacesBeforeDecimal="15" PositiveNumber="True" MaxLength="18" DollarSign=" ">0</ew:numericbox></TD>
														<TD bgColor="#335eb4">
															<asp:label id="Label23" runat="server" CssClass="TextoBlanco">Oct.</asp:label></TD>
														<TD>
															<ew:numericbox id="numOct" runat="server" CssClass="normaldetalle" Width="80px" BorderStyle="Groove"
																PlacesBeforeDecimal="15" PositiveNumber="True" MaxLength="18" DollarSign=" ">0</ew:numericbox></TD>
													</TR>
													<TR>
														<TD bgColor="#335eb4">
															<asp:label id="Label15" runat="server" CssClass="TextoBlanco">Feb.</asp:label></TD>
														<TD>
															<ew:numericbox id="numFeb" runat="server" CssClass="normaldetalle" Width="80px" BorderStyle="Groove"
																PlacesBeforeDecimal="15" PositiveNumber="True" MaxLength="18" DollarSign=" ">0</ew:numericbox></TD>
														<TD bgColor="#335eb4">
															<asp:label id="Label18" runat="server" CssClass="TextoBlanco">May.</asp:label></TD>
														<TD>
															<ew:numericbox id="numMay" runat="server" CssClass="normaldetalle" Width="80px" BorderStyle="Groove"
																PlacesBeforeDecimal="15" PositiveNumber="True" MaxLength="18" DollarSign=" ">0</ew:numericbox></TD>
														<TD bgColor="#335eb4">
															<asp:label id="Label21" runat="server" CssClass="TextoBlanco">Ago.</asp:label></TD>
														<TD>
															<ew:numericbox id="numAgo" runat="server" CssClass="normaldetalle" Width="80px" BorderStyle="Groove"
																PlacesBeforeDecimal="15" PositiveNumber="True" MaxLength="18" DollarSign=" ">0</ew:numericbox></TD>
														<TD bgColor="#335eb4">
															<asp:label id="Label24" runat="server" CssClass="TextoBlanco">Nov.</asp:label></TD>
														<TD>
															<ew:numericbox id="numNov" runat="server" CssClass="normaldetalle" Width="80px" BorderStyle="Groove"
																PlacesBeforeDecimal="15" PositiveNumber="True" MaxLength="18" DollarSign=" ">0</ew:numericbox></TD>
													</TR>
													<TR>
														<TD bgColor="#335eb4">
															<asp:label id="Label16" runat="server" CssClass="TextoBlanco">Mar.</asp:label></TD>
														<TD>
															<ew:numericbox id="numMar" runat="server" CssClass="normaldetalle" Width="80px" BorderStyle="Groove"
																PlacesBeforeDecimal="15" PositiveNumber="True" MaxLength="18" DollarSign=" ">0</ew:numericbox></TD>
														<TD bgColor="#335eb4">
															<asp:label id="Label19" runat="server" CssClass="TextoBlanco">Jun.</asp:label></TD>
														<TD>
															<ew:numericbox id="numJun" runat="server" CssClass="normaldetalle" Width="80px" BorderStyle="Groove"
																PlacesBeforeDecimal="15" PositiveNumber="True" MaxLength="18" DollarSign=" ">0</ew:numericbox></TD>
														<TD bgColor="#335eb4">
															<asp:label id="Label22" runat="server" CssClass="TextoBlanco">Set.</asp:label></TD>
														<TD>
															<ew:numericbox id="numSet" runat="server" CssClass="normaldetalle" Width="80px" BorderStyle="Groove"
																PlacesBeforeDecimal="15" PositiveNumber="True" MaxLength="18" DollarSign=" ">0</ew:numericbox></TD>
														<TD bgColor="#335eb4">
															<asp:label id="Label25" runat="server" CssClass="TextoBlanco">Dic.</asp:label></TD>
														<TD>
															<ew:numericbox id="numDic" runat="server" CssClass="normaldetalle" Width="80px" BorderStyle="Groove"
																PlacesBeforeDecimal="15" PositiveNumber="True" MaxLength="18" DollarSign=" ">0</ew:numericbox></TD>
													</TR>
													<TR>
														<TD></TD>
														<TD></TD>
														<TD></TD>
														<TD></TD>
														<TD bgColor="#335eb4" colSpan="2">
															<asp:label id="Label39" runat="server" CssClass="TextoBlanco"> Total:</asp:label></TD>
														<TD bgColor="#335eb4" colSpan="2">
															<asp:label id="lblTotal" runat="server" CssClass="TextoBlanco">0</asp:label></TD>
													</TR>
												</TABLE>
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
