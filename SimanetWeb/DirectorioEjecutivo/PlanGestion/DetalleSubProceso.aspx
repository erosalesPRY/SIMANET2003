<%@ Page language="c#" Codebehind="DetalleSubProceso.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion.DetalleSubProceso" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleSubProceso</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Plan de Gestión ></asp:label>
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de SubProcesos</asp:label></TD>
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
					<TD>
						<asp:Image id="Image1" runat="server" Width="48px" Height="24px" ImageUrl="../../imagenes/spacer.gif"></asp:Image></TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center"></DIV>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="300" align="center" border="0">
							<TR>
								<TD style="HEIGHT: 233px">
									<P align="left">
										<TABLE id="Table2" style="WIDTH: 295px; HEIGHT: 170px" borderColor="#ffffff" cellSpacing="0"
											cellPadding="0" width="295" align="center" border="1" runat="server">
											<TR>
											</TR>
											<TR>
												<TD style="WIDTH: 514px" colSpan="2" rowSpan="1" bgColor="#f0f0f0">
													<asp:label id="lblProceso" runat="server" CssClass="normaldetalle"></asp:label>
													<asp:label id="lblNombreProceso" runat="server" CssClass="normaldetalle"></asp:label></TD>
												<TD style="WIDTH: 138px"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 514px" bgColor="#000080" colSpan="2">
													<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
												<TD style="WIDTH: 138px"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4">
													<asp:label id="Label1" runat="server" CssClass="TextoBlanco">Codigo SubProceso</asp:label></TD>
												<TD bgColor="#f0f0f0" style="WIDTH: 450px">
													<asp:textbox id="txtCodigoSubProceso" runat="server" CssClass="NormalDetalle" Width="250px" BorderStyle="Groove"
														ReadOnly="True"></asp:textbox></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4">
													<asp:label id="Label2" runat="server" CssClass="TextoBlanco">Nombre SubProceso</asp:label></TD>
												<TD bgColor="#dddddd" style="WIDTH: 315px">
													<asp:textbox id="txtNombreSubProceso" runat="server" CssClass="NormalDetalle" Width="250px" BorderStyle="Groove"></asp:textbox></TD>
												<TD>
													<cc2:requireddomvalidator id="rfvNombreProceso" runat="server" ControlToValidate="txtNombreSubProceso">*</cc2:requireddomvalidator></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4">
													<asp:label id="lblAE" runat="server" CssClass="TextoBlanco">AE</asp:label></TD>
												<TD bgColor="#f0f0f0" style="WIDTH: 315px">
													<ew:numericbox id="txtAvanceEconomica" runat="server" CssClass="normaldetalle" Width="100px" PositiveNumber="True"
														MaxLength="6" BorderStyle="Groove"></ew:numericbox></TD>
												<TD>
													<cc2:RangeDomValidator id="RangeDomValidator1" runat="server" ControlToValidate="txtAvanceEconomica" ErrorMessage="Ingrese valores de 0 a 100"
														MinimumValue="00.00" MaximumValue="100.00">*</cc2:RangeDomValidator></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4">
													<asp:label id="lblAF" runat="server" CssClass="TextoBlanco">AF</asp:label></TD>
												<TD bgColor="#dddddd" style="WIDTH: 315px">
													<ew:numericbox id="txtAvanceFinanciero" runat="server" CssClass="normaldetalle" BorderStyle="Groove"
														Width="100px" PositiveNumber="True" MaxLength="6"></ew:numericbox></TD>
												<TD>
													<cc2:RangeDomValidator id="RangeDomValidator2" runat="server" ControlToValidate="txtAvanceFinanciero" ErrorMessage="Ingrese valores de 0 a 100"
														MinimumValue="00.00" MaximumValue="100.00">*</cc2:RangeDomValidator></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4">
													<asp:label id="lblResponsable" runat="server" CssClass="TextoBlanco">Responsable</asp:label></TD>
												<TD style="WIDTH: 315px" bgColor="#dddddd">
													<asp:textbox id="txtResponsable" runat="server" CssClass="NormalDetalle" BorderStyle="Groove"
														Width="100px"></asp:textbox></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4">
													<asp:label id="lblLider" runat="server" CssClass="TextoBlanco">Lider</asp:label></TD>
												<TD bgColor="#f0f0f0" style="WIDTH: 315px">
													<asp:textbox id="txtLider" runat="server" CssClass="NormalDetalle" Width="250px" BorderStyle="Groove"
														Height="48px" TextMode="MultiLine"></asp:textbox></TD>
												<TD>
													<P align="right">
														<asp:imagebutton id="ibtnBuscarLider" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
															CausesValidation="False"></asp:imagebutton></P>
												</TD>
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
											<TD width="94">
												<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD width="101"><SPAN class="normal">
													<asp:imagebutton id="ibtnCancelar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_cancelar.gif"
														CausesValidation="False"></asp:imagebutton></SPAN></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<cc2:domvalidationsummary id="vSum" runat="server" CssClass="normal" EnableClientScript="False" DisplayMode="List"
										ShowMessageBox="True"></cc2:domvalidationsummary></TD>
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
	</body>
</HTML>
