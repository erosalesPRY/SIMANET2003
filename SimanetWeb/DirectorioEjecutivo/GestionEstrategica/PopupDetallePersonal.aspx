<%@ Page language="c#" Codebehind="PopupDetallePersonal.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica.PopupDetallePersonal" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PopupDetallePersonal</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 51px" align="center">
						<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal">DETALLE DEL PERSONAL RESPONSABLE DE LA PC</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<P>
							<TABLE id="Table3" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="760" border="1"
								style="WIDTH: 760px; HEIGHT: 367px">
								<TR>
									<TD bgColor="#000080" colSpan="6">
										<asp:label id="lblDatos" runat="server" CssClass="TituloPrincipalBlanco">DATOS PERSONALES</asp:label></TD>
								</TR>
								<TR>
									<TD bgColor="#335eb4">
										<asp:label id="Label34" runat="server" CssClass="TextoBlanco">APEL. Y NOM. :</asp:label></TD>
									<TD style="WIDTH: 313px" bgColor="#f0f0f0" colSpan="1">
										<asp:textbox id="txtApelyNom" runat="server" CssClass="TituloPrincipalBlanco" Width="280px" ReadOnly="True"
											ForeColor="Navy"></asp:textbox></TD>
									<TD bgColor="#335eb4">
										<asp:label id="Label37" runat="server" CssClass="TextoBlanco">DNI :</asp:label></TD>
									<TD bgColor="#f0f0f0">
										<asp:textbox id="txtDni" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
									<TD bgColor="#335eb4">
										<asp:label id="Label4" runat="server" CssClass="TextoBlanco">GRADO  :</asp:label></TD>
									<TD bgColor="#f0f0f0">
										<asp:textbox id="txtGrado" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#335eb4">
										<asp:label id="Label38" runat="server" CssClass="TextoBlanco">NIVEL INST. :</asp:label></TD>
									<TD style="WIDTH: 301px" bgColor="#dddddd">
										<asp:textbox id="txtNivInst" runat="server" CssClass="normaldetalle" Width="280px" ReadOnly="True"></asp:textbox></TD>
									<TD bgColor="#335eb4">
										<asp:label id="Label36" runat="server" CssClass="TextoBlanco">FECHA NAC. :</asp:label></TD>
									<TD bgColor="#dddddd">
										<asp:textbox id="txtFechNac" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
									<TD bgColor="#335eb4">
										<asp:label id="Label48" runat="server" CssClass="TextoBlanco">EDAD :</asp:label></TD>
									<TD bgColor="#dddddd">
										<asp:textbox id="txtEdad" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#335eb4">
										<asp:label id="Label39" runat="server" CssClass="TextoBlanco">PROFESIÓN :</asp:label></TD>
									<TD style="WIDTH: 301px" bgColor="#f0f0f0">
										<asp:textbox id="txtProf" runat="server" CssClass="normaldetalle" Width="280px" ReadOnly="True"></asp:textbox></TD>
									<TD bgColor="#335eb4">
										<asp:label id="Label49" runat="server" CssClass="TextoBlanco">EST. CIV. :</asp:label></TD>
									<TD bgColor="#f0f0f0">
										<asp:textbox id="txtEstCiv" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
									<TD bgColor="#335eb4"></TD>
									<TD bgColor="#f0f0f0">
										<asp:textbox id="txtID" runat="server" Width="6px" ReadOnly="True" ForeColor="#F0F0F0" BackColor="#F0F0F0"></asp:textbox></TD>
								</TR>
								<TR>
									<TD width="100" bgColor="#000080" colSpan="6">
										<asp:label id="Label7" runat="server" CssClass="TituloPrincipalBlanco" Width="184px">DATOS DEL SERVICIO</asp:label></TD>
								</TR>
								<TR>
									<TD width="100" bgColor="#335eb4">
										<asp:label id="Label1" runat="server" CssClass="TextoBlanco" ToolTip="Numero de PortaRetrato">P.R. :</asp:label></TD>
									<TD style="WIDTH: 301px" width="301" bgColor="#f0f0f0">
										<asp:textbox id="txtPR" runat="server" CssClass="TituloPrincipalBlanco" Width="75px" ReadOnly="True"
											ForeColor="Navy"></asp:textbox></TD>
									<TD width="75" bgColor="#335eb4">
										<asp:label id="Label27" runat="server" CssClass="TextoBlanco" ToolTip="Centro de Operación">C.O.  :</asp:label></TD>
									<TD width="75" bgColor="#f0f0f0">
										<asp:textbox id="txtCo" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
									<TD width="200" colSpan="2" rowSpan="9">
										<asp:image id="imgFoto" runat="server" Width="200px" BorderColor="Transparent" Height="250px"></asp:image></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 28px" bgColor="#335eb4">
										<asp:label id="Label2" runat="server" CssClass="TextoBlanco" ToolTip="Centro de Costos">C. COSTOS :</asp:label></TD>
									<TD style="WIDTH: 301px; HEIGHT: 28px" bgColor="#dddddd">
										<asp:textbox id="txtCCosto" runat="server" CssClass="normaldetalle" Width="280px" ReadOnly="True"></asp:textbox></TD>
									<TD style="HEIGHT: 28px" bgColor="#335eb4">
										<asp:label id="Label35" runat="server" CssClass="TextoBlanco" ToolTip="Tipo de Trabajador">TIP. TRAB.  :</asp:label></TD>
									<TD style="HEIGHT: 28px" bgColor="#dddddd">
										<asp:textbox id="txtTT" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#335eb4">
										<asp:label id="Label3" runat="server" CssClass="TextoBlanco" ToolTip="Fecha de Inicio del Contrato Vigente">FECHA INICIO :</asp:label></TD>
									<TD style="WIDTH: 301px" bgColor="#f0f0f0">
										<asp:textbox id="txtFechaIng" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
									<TD bgColor="#335eb4">
										<asp:label id="Label41" runat="server" CssClass="TextoBlanco" Width="64px" ToolTip="Fecha de Cese">FECHA FIN :</asp:label></TD>
									<TD bgColor="#f0f0f0">
										<asp:textbox id="txtFechFin" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#335eb4">
										<asp:label id="Label28" runat="server" CssClass="TextoBlanco" Width="112px" ToolTip="Tiempo de Servicio Efectivo">T. SERV. (AA-MM-DD):</asp:label></TD>
									<TD style="WIDTH: 301px" bgColor="#dddddd">
										<asp:textbox id="txtTServ" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
									<TD bgColor="#335eb4">
										<asp:label id="Label5" runat="server" CssClass="TextoBlanco" Width="64px" ToolTip="Fecha de Cese o Termino de Contrato Vigente"
											Visible="False">FECHA TC :</asp:label></TD>
									<TD bgColor="#dddddd">
										<asp:textbox id="txtFTCont" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"
											Visible="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 22px" bgColor="#335eb4">
										<asp:label id="Label29" runat="server" CssClass="TextoBlanco">CARGO :</asp:label></TD>
									<TD style="WIDTH: 301px; HEIGHT: 22px" bgColor="#f0f0f0">
										<asp:textbox id="txtCargo" runat="server" CssClass="normaldetalle" Width="280px" ReadOnly="True"></asp:textbox></TD>
									<TD style="WIDTH: 301px; HEIGHT: 22px" bgColor="#335eb4">
										<asp:label id="Label42" runat="server" CssClass="TextoBlanco" ToolTip="Tipo de Contrato">T.C.  :</asp:label></TD>
									<TD style="WIDTH: 301px; HEIGHT: 22px" bgColor="#f0f0f0">
										<asp:textbox id="txtTC" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#335eb4">
										<asp:label id="Label30" runat="server" CssClass="TextoBlanco">ESPECIALIDAD :</asp:label></TD>
									<TD style="WIDTH: 301px" bgColor="#dddddd">
										<asp:textbox id="txtEsp" runat="server" CssClass="normaldetalle" Width="280px" ReadOnly="True"></asp:textbox></TD>
									<TD style="WIDTH: 301px" bgColor="#335eb4">
										<asp:label id="Label44" runat="server" CssClass="TextoBlanco" ToolTip="Grupo Ocupacional">G.O.  :</asp:label></TD>
									<TD style="WIDTH: 301px" bgColor="#dddddd" colSpan="1">
										<asp:textbox id="txtGO" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#335eb4">
										<asp:label id="Label31" runat="server" CssClass="TextoBlanco" ToolTip="Tipo de Mano de Obra">M.O. :</asp:label></TD>
									<TD style="WIDTH: 301px" bgColor="#f0f0f0">
										<asp:textbox id="txtMO" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
									<TD bgColor="#335eb4">
										<asp:label id="Label45" runat="server" CssClass="TextoBlanco">NIV. GO. :</asp:label></TD>
									<TD bgColor="#f0f0f0">
										<asp:textbox id="txtNivGO" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#335eb4">
										<asp:label id="Label32" runat="server" CssClass="TextoBlanco" ToolTip="Haber Mensual">HABER :</asp:label></TD>
									<TD style="WIDTH: 301px" bgColor="#dddddd">
										<asp:textbox id="txtHaber" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
									<TD bgColor="#335eb4">
										<asp:label id="Label33" runat="server" CssClass="TextoBlanco" ToolTip="Sobretiempo Autorizado">SOB. AUT. :</asp:label></TD>
									<TD bgColor="#dddddd">
										<asp:textbox id="txtSobAut" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#335eb4">
										<asp:label id="Label6" runat="server" CssClass="TextoBlanco" ToolTip="Estado del Trabajador">ESTADO :</asp:label></TD>
									<TD style="WIDTH: 301px" bgColor="#f0f0f0">
										<asp:Image id="imgEstado" runat="server" Height="18px"></asp:Image></TD>
									<TD bgColor="#335eb4">
										<asp:label id="Label46" runat="server" CssClass="TextoBlanco" ToolTip="SobreTiempo Acumulado">SOB. ACUM : </asp:label></TD>
									<TD bgColor="#f0f0f0">
										<asp:textbox id="txtSobAcum" runat="server" CssClass="normaldetalle" Width="75px" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
