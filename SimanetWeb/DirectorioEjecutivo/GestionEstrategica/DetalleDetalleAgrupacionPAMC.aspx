<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="DetalleDetalleAgrupacionPAMC.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica.DetalleDetalleAgrupacionPAMC" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleDetalleAgrupacionPAMC</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPaginaActual">Inicio > Gestión Estrátegica >  Proyectos Apoyo a la Mejora de la Competitividad > Nivel >  Agrupación ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">DETALLE PROYECTOS</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" style="WIDTH: 752px; HEIGHT: 515px" borderColor="#ffffff" cellSpacing="1"
							cellPadding="1" width="752" border="1">
							<TR>
								<TD bgColor="#000080" colSpan="4"><asp:label id="lblTitulodos" runat="server" CssClass="TituloPrincipalBlanco">DATOS PRINCIPALES</asp:label></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="lblNombreDocumento" runat="server" CssClass="TextoBlanco" Width="150px">NOMBRE:</asp:label></TD>
								<TD style="WIDTH: 738px" bgColor="#dddddd"><asp:textbox id="txtNombre" runat="server" CssClass="normaldetalle" Width="576px" MaxLength="500"></asp:textbox><cc2:requireddomvalidator id="rfvNombre" runat="server" ControlToValidate="txtNombre">*</cc2:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="lblSituacionActual" runat="server" CssClass="TextoBlanco" Width="150px">SITUACION ACTUAL</asp:label></TD>
								<TD style="WIDTH: 738px" bgColor="#f5f5f5"><asp:textbox id="txtSituacionActual" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="2000"
										Height="110px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 15px" bgColor="#335eb4"><asp:label id="lblRuta" runat="server" CssClass="TextoBlanco" Width="100px">RUTA de pdf:</asp:label></TD>
								<TD style="WIDTH: 739px; HEIGHT: 15px" bgColor="#dddddd"><INPUT class="normaldetalle" id="filMyFile" style="WIDTH: 100%; HEIGHT: 17px" type="file"
										size="22" name="File2" runat="server"></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="Label2" runat="server" CssClass="TextoBlanco" Width="150px">NRO. EXPOSICION:</asp:label></TD>
								<TD style="WIDTH: 739px" bgColor="#f5f5f5"><ew:numericbox id="txtNroExposicion" runat="server" CssClass="normalDetalle" Width="100%" PositiveNumber="True"
										RealNumber="False"></ew:numericbox></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="lblCentroOperativo" runat="server" CssClass="TextoBlanco" Width="150px">CENTRO OPERATIVO:</asp:label></TD>
								<TD bgColor="#dddddd" colSpan="3"><asp:dropdownlist id="ddlCentroOperativo" runat="server" CssClass="normaldetalle" Width="100%"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="Label1" runat="server" CssClass="TextoBlanco" Width="150px">DESCRIPCION:</asp:label></TD>
								<TD bgColor="#f5f5f5" colSpan="3"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="2000"
										Height="53px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco" Width="150px">OBSERVACIONES:</asp:label></TD>
								<TD bgColor="#dddddd" colSpan="3"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="2000"
										Height="56px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="4"><asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"><BR>
									<cc2:domvalidationsummary id="vSum" runat="server" Width="477px" EnableClientScript="False" ShowMessageBox="True"
										DisplayMode="List" EnableViewState="False"></cc2:domvalidationsummary><BR>
									<INPUT id="hIdObjetivoGeneral" style="WIDTH: 13px; HEIGHT: 22px" type="hidden" size="1"
										runat="server"> <INPUT id="hIdObjetivoEspecifico" style="WIDTH: 13px; HEIGHT: 22px" type="hidden" size="1"
										runat="server"><INPUT id="hFoto" style="WIDTH: 13px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
										runat="server"><INPUT id="hFila" style="WIDTH: 13px; HEIGHT: 22px" type="hidden" size="1" name="Hidden2"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</FORM>
	</body>
</HTML>
