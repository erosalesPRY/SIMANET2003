<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarCartaFianzaporProyecto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasFianza.ConsultarCartaFianzaporProyecto" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/ScrollingGrid.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<script language="JavaScript" type="text/javascript" src="../../js/wz_tooltip.js"></script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR id="idx1">
					<TD colSpan="2"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR id="idx2">
					<TD colSpan="2"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left" colSpan="2" class="RutaPaginaActual">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera> Consultar Cartas Fianzas ></asp:label>
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Consultar Carta Fianza Por Proyecto</asp:label>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" colSpan="2">
						<asp:label id="lblTiutlo" runat="server" CssClass="tituloprincipal">Cartas Fianzas por Proyectos</asp:label><BR>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD vAlign="middle" bgColor="#f0f0f0">
									<asp:label id="Label2" runat="server" CssClass="TextoNegroNegrita"> Fianzas:</asp:label>&nbsp;
									<asp:dropdownlist id="ddlbModalidadCartaFianza" runat="server" CssClass="combos" AutoPostBack="True"
										Width="180px"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;
									<asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita">Estado:</asp:label>&nbsp;
									<asp:dropdownlist id="ddlbEstadoCartaFianza" runat="server" CssClass="combos" AutoPostBack="True"
										Width="180px"></asp:dropdownlist></TD>
								<TD align="right" bgColor="#f0f0f0"><IMG id="ImgImprimir" style="CURSOR: hand" onclick="oPrint = new SIMA.Utilitario.Helper.Dialogos();oPrint.VistaPrevia(this,idx1,idx2,idx3,idx4,idx5);"
										alt="" src="../../imagenes/bt_imprimir.gif"></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#f0f0f0" colSpan="2">
									<asp:panel id="Panel1" runat="server"></asp:panel>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda">No existen Registros</asp:label></TD>
							</TR>
							<TR>
								<TD bgColor="#f0f0f0" colSpan="2"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
