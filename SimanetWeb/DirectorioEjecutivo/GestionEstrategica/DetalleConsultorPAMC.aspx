<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleConsultorPAMC.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica.DetalleConsultorPAMC" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleConsultorPAMC</title>
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
					<TD>
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands">
						<asp:label id="lblRuta" runat="server" CssClass="RutaPaginaActual">Inicio > Gestión Estrátegica >  Proyectos Apoyo a la Mejora de la Competitividad > Nivel >  Agrupación >  Detalle Agrup. >  T.R. ></asp:label>
						<asp:label id="lblPaginaActual" runat="server" CssClass="RutaPaginaActual">DETALLE T.D.R.</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="780" border="1">
							<TR>
								<TD width="150" bgColor="#000080" colSpan="3">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco">DATOS PRINCIPALES</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 42px" width="42" bgColor="#335eb4">
									<asp:label id="lblNombre" runat="server" CssClass="TextoBlanco" Width="120px">NOMBRE CORTO:</asp:label></TD>
								<TD style="WIDTH: 768px" bgColor="#f0f0f0">
									<asp:textbox id="txtNombre" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="200"></asp:textbox></TD>
								<TD bgColor="#f0f0f0">
									<cc2:RequiredDomValidator id="rfvNombre" runat="server" ControlToValidate="txtNombre">*</cc2:RequiredDomValidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 42px" width="42" bgColor="#335eb4">
									<asp:label id="lblNombreLargo" runat="server" CssClass="TextoBlanco" Width="120px"> ESPECIALIDAD:</asp:label></TD>
								<TD style="WIDTH: 768px" bgColor="#dddddd">
									<asp:textbox id="txtNombreLargo" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="200"></asp:textbox></TD>
								<TD bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 42px" width="42" bgColor="#335eb4">
									<asp:label id="Label1" runat="server" CssClass="TextoBlanco" Width="120px">NRO. EXPOSICION:</asp:label></TD>
								<TD style="WIDTH: 768px" bgColor="#f0f0f0">
									<ew:NumericBox id="txtNroExposicion" runat="server" CssClass="normalDetalle" Width="100%" PositiveNumber="True"
										RealNumber="False"></ew:NumericBox></TD>
								<TD bgColor="#f0f0f0"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 42px" vAlign="top" width="42" bgColor="#335eb4">
									<asp:label id="lblCurriculum" runat="server" CssClass="TextoBlanco" Width="120px">CURRICULUM:</asp:label></TD>
								<TD style="WIDTH: 768px" bgColor="#dddddd"><INPUT class="normaldetalle" id="filMyFile" style="WIDTH: 94.64%; HEIGHT: 17px" type="file"
										size="82" name="File2" runat="server">
									<asp:CheckBox id="chkEstado" runat="server" CssClass="normalDetalle" Width="24px" Enabled="False"
										Text=" "></asp:CheckBox></TD>
								<TD bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 42px" vAlign="top" width="42" bgColor="#335eb4">
									<asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco" Width="120px">DESCRIPCION:</asp:label></TD>
								<TD style="WIDTH: 768px" bgColor="#f0f0f0">
									<asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="2000"
										Height="32px" TextMode="MultiLine"></asp:textbox></TD>
								<TD bgColor="#f0f0f0"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 42px" vAlign="top" width="42" bgColor="#335eb4">
									<asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco" Width="120px">OBSERVACIONES:</asp:label></TD>
								<TD style="WIDTH: 768px" bgColor="#dddddd">
									<asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="2000"
										Height="42px" TextMode="MultiLine"></asp:textbox></TD>
								<TD bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center" colSpan="3">
									<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"><BR>
									<cc2:DomValidationSummary id="vSum" runat="server" DisplayMode="List" ShowMessageBox="True" EnableClientScript="False"></cc2:DomValidationSummary><INPUT id="hFila" style="WIDTH: 15px; HEIGHT: 22px" type="hidden" size="1" name="hFila"
										runat="server"></TD>
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
