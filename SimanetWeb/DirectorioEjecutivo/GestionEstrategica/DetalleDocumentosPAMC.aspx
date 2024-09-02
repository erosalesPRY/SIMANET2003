<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleDocumentosPAMC.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica.DetalleDocumentosPAMC" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleDocumentosPAMC</title>
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
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPaginaActual">Inicio > Gestión Estrátegica >  Proyectos Apoyo a la Mejora de la Competitividad >  Nivel ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">DETALLE DOCUMENTOS</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table4" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="780" border="1">
							<TR>
								<TD bgColor="#000080" colSpan="3"><asp:label id="lblTituloDocumentos" runat="server" CssClass="TituloPrincipalBlanco">DOCUMENTOS</asp:label></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="lblNombreDocumento" runat="server" CssClass="TextoBlanco" Width="120px">NOMBRE:</asp:label></TD>
								<TD bgColor="#dddddd"><asp:textbox id="txtNombreDocumento" runat="server" CssClass="normaldetalle" Width="655px" MaxLength="500"></asp:textbox></TD>
								<TD bgColor="#dddddd"><cc2:requireddomvalidator id="rfvNombre" runat="server" ControlToValidate="txtNombreDocumento">*</cc2:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="lblRuta" runat="server" CssClass="TextoBlanco" Width="120px">RUTA:</asp:label></TD>
								<TD bgColor="#dddddd"><INPUT class="normaldetalle" id="filMyFile" style="WIDTH: 655px; HEIGHT: 17px" type="file"
										size="24" name="File2" runat="server"></TD>
								<TD bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="lblTipoDocumento" runat="server" CssClass="TextoBlanco" Width="120px">TIPO DE DOCUMENTO:</asp:label></TD>
								<TD bgColor="#dddddd"><asp:dropdownlist id="ddlTipoDocumento" runat="server" CssClass="normaldetalle" Width="655px"></asp:dropdownlist></TD>
								<TD bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 20px" vAlign="middle" bgColor="#335eb4"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco" Width="120px">DESCRIPCION:</asp:label></TD>
								<TD style="HEIGHT: 20px" bgColor="#dddddd"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="655px" MaxLength="2000"
										Height="48px" TextMode="MultiLine"></asp:textbox></TD>
								<TD style="HEIGHT: 20px" bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 20px" bgColor="#335eb4"><asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco" Width="120px">OBSERVACIONES:</asp:label></TD>
								<TD style="HEIGHT: 20px" bgColor="#dddddd"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="655px" MaxLength="2000"
										Height="56px" TextMode="MultiLine"></asp:textbox></TD>
								<TD style="HEIGHT: 20px" bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton><INPUT id="hFoto" style="WIDTH: 10px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
										runat="server"> <IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
							</TR>
						</TABLE>
						<cc2:domvalidationsummary id="vSum" runat="server" EnableClientScript="False" ShowMessageBox="True" DisplayMode="List"
							EnableViewState="False"></cc2:domvalidationsummary></TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</FORM>
	</body>
</HTML>
