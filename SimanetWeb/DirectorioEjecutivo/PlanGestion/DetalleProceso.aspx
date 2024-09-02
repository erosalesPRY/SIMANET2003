<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="DetalleProceso.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion.DetalleProceso" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleProceso</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Plan de Gestión ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Procesos</asp:label></TD>
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
										<TABLE id="Table2" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="565" align="center"
											border="1" runat="server">
											<TR>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#000080" colSpan="2"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
												<TD style="WIDTH: 138px"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="Label1" runat="server" CssClass="TextoBlanco">Codigo Proceso</asp:label></TD>
												<TD bgColor="#f0f0f0"><asp:textbox id="txtCodigoProceso" runat="server" CssClass="NormalDetalle" Width="250px" BorderStyle="Groove"
														ReadOnly="True"></asp:textbox></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="Label2" runat="server" CssClass="TextoBlanco">Nombre Proceso</asp:label></TD>
												<TD bgColor="#dddddd"><asp:textbox id="txtNombreProceso" runat="server" CssClass="NormalDetalle" Width="250px" BorderStyle="Groove"></asp:textbox></TD>
												<TD><cc2:requireddomvalidator id="rfvNombreProceso" runat="server" ControlToValidate="txtNombreProceso">*</cc2:requireddomvalidator></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="lblDefinicion" runat="server" CssClass="TextoBlanco">Definición</asp:label></TD>
												<TD bgColor="#f0f0f0"><asp:textbox id="txtDefinicion" runat="server" CssClass="NormalDetalle" Width="500px" BorderStyle="Groove"
														TextMode="MultiLine" Height="40px"></asp:textbox></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="lblAlcance" runat="server" CssClass="TextoBlanco">Alcance</asp:label></TD>
												<TD bgColor="#dddddd"><asp:textbox id="txtAlcance" runat="server" CssClass="NormalDetalle" Width="500px" BorderStyle="Groove"
														TextMode="MultiLine" Height="40px"></asp:textbox></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="lblResponsable" runat="server" CssClass="TextoBlanco">Responsable</asp:label></TD>
												<TD bgColor="#f0f0f0"><asp:textbox id="txtResponsable" runat="server" CssClass="NormalDetalle" Width="250px" BorderStyle="Groove"></asp:textbox></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="lblLider" runat="server" CssClass="TextoBlanco">Lider</asp:label></TD>
												<TD bgColor="#dddddd"><asp:textbox id="txtLider" runat="server" CssClass="normaldetalle" Width="336px" BorderStyle="Groove"
														ReadOnly="True" MaxLength="80"></asp:textbox><asp:imagebutton id="ibtnBuscarLider" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
														CausesValidation="False"></asp:imagebutton></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="lblParticipantes" runat="server" CssClass="TextoBlanco">Participantes</asp:label></TD>
												<TD bgColor="#f0f0f0"><asp:textbox id="txtParticipante" runat="server" CssClass="NormalDetalle" Width="250px" BorderStyle="Groove"
														TextMode="MultiLine" Height="40px"></asp:textbox></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="lblCO" runat="server" CssClass="TextoBlanco">CO</asp:label></TD>
												<TD bgColor="#dddddd"><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="NormalDetalle" Width="250px"></asp:dropdownlist></TD>
												<TD></TD>
											</TR>
										</TABLE>
									</P>
									<TABLE id="Table8" width="180" align="center" border="0">
										<TR>
											<TD width="94"><asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD width="101"><SPAN class="normal"><asp:imagebutton id="ibtnCancelar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_cancelar.gif"
														CausesValidation="False"></asp:imagebutton></SPAN></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD></TD>
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
