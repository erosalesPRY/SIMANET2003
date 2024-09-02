<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="PopupImpresionPlacaRegistroProyeectoCN.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.PopupImpresionPlacaRegistroProyeectoCN" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="tblMain" cellSpacing="0" cellPadding="0" width="600" border="0" style="HEIGHT: 360px"
				align="center" background="../../imagenes/placa.gif">
				<TR>
					<TD align="center"><BR>
						<BR>
						<asp:Label id="lblNombre" runat="server" CssClass="normaldetalle" Font-Size="X-Large"></asp:Label><BR>
						<BR>
						<TABLE id="tblPlaca" cellSpacing="0" cellPadding="0" width="600" border="0">
							<TR>
								<TD style="WIDTH: 136px; HEIGHT: 14px" align="right">
									<asp:Label id="lblCentroOperativo" runat="server" CssClass="normaldetalle">CENTRO OPERATIVO:</asp:Label></TD>
								<TD style="WIDTH: 174px; HEIGHT: 14px" align="left">
									<asp:Label id="lblTCentroOperativo" runat="server" CssClass="normaldetalle"></asp:Label></TD>
								<TD style="WIDTH: 13px; HEIGHT: 14px"></TD>
								<TD style="WIDTH: 118px; HEIGHT: 14px">
									<asp:Label id="Label2" runat="server" CssClass="normaldetalle">CAP. COMBUSTIBLE:</asp:Label></TD>
								<TD style="HEIGHT: 14px" align="left">
									<asp:Label id="lblTCapCombustible" runat="server" CssClass="normaldetalle"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 136px; HEIGHT: 17px" align="right">
									<asp:Label id="lblNroProyectoSima" runat="server" CssClass="normaldetalle">N° PROYECTO SIMA:</asp:Label></TD>
								<TD style="WIDTH: 174px; HEIGHT: 17px" align="left">
									<asp:Label id="lblTNroProyectoSima" runat="server" CssClass="normaldetalle"></asp:Label></TD>
								<TD style="WIDTH: 13px; HEIGHT: 17px">&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
								<TD style="WIDTH: 118px; HEIGHT: 17px">
									<asp:Label id="lblCapAgua" runat="server" CssClass="normaldetalle">CAP. AGUA:</asp:Label></TD>
								<TD style="HEIGHT: 17px" align="left">
									<asp:Label id="lblTCapAgua" runat="server" CssClass="normaldetalle">CAP. AGUA:</asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 136px; HEIGHT: 17px" align="right">
									<asp:Label id="lblTipodeBuque" runat="server" CssClass="normaldetalle">TIPO DE BUQUE:</asp:Label></TD>
								<TD style="WIDTH: 174px; HEIGHT: 17px" align="left">
									<asp:Label id="lblTTipoBuque" runat="server" CssClass="normaldetalle"></asp:Label></TD>
								<TD style="WIDTH: 13px; HEIGHT: 17px"></TD>
								<TD style="WIDTH: 118px; HEIGHT: 17px">
									<asp:Label id="lblEslora" runat="server" CssClass="normaldetalle">ESLORA:</asp:Label></TD>
								<TD style="HEIGHT: 17px" align="left">
									<asp:Label id="lblTEslora" runat="server" CssClass="normaldetalle"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 136px; HEIGHT: 17px" align="right">
									<asp:Label id="lblAnoFabricacion" runat="server" CssClass="normaldetalle">AÑO DE FABRICACION:</asp:Label></TD>
								<TD style="WIDTH: 174px; HEIGHT: 17px" align="left">
									<asp:Label id="lblTAnoFabricacion" runat="server" CssClass="normaldetalle"></asp:Label></TD>
								<TD style="WIDTH: 13px; HEIGHT: 17px"></TD>
								<TD style="WIDTH: 118px; HEIGHT: 17px">
									<asp:Label id="lblManga" runat="server" CssClass="normaldetalle">MANGA:</asp:Label></TD>
								<TD style="HEIGHT: 17px" align="left">
									<asp:Label id="lblTManga" runat="server" CssClass="normaldetalle"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 136px; HEIGHT: 17px" align="right">
									<asp:Label id="lblCaracteristica" runat="server" CssClass="normaldetalle">CARACTERISTICA:</asp:Label></TD>
								<TD style="WIDTH: 174px; HEIGHT: 17px" align="left">
									<asp:Label id="lblTCaracteristica" runat="server" CssClass="normaldetalle"></asp:Label></TD>
								<TD style="WIDTH: 13px; HEIGHT: 17px"></TD>
								<TD style="WIDTH: 118px; HEIGHT: 17px">
									<asp:Label id="lblPuntal" runat="server" CssClass="normaldetalle">PUNTAL:</asp:Label></TD>
								<TD style="HEIGHT: 17px" align="left">
									<asp:Label id="lblTPuntal" runat="server" CssClass="normaldetalle"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 136px; HEIGHT: 17px" align="right">
									<asp:Label id="lblDesplazamiento" runat="server" CssClass="normaldetalle">DESPLAZAMIENTO:</asp:Label></TD>
								<TD style="WIDTH: 174px; HEIGHT: 17px" align="left">
									<asp:Label id="lblTDesplazamiento" runat="server" CssClass="normaldetalle"></asp:Label></TD>
								<TD style="WIDTH: 13px; HEIGHT: 17px"></TD>
								<TD style="WIDTH: 118px; HEIGHT: 17px">
									<asp:Label id="lblCalado" runat="server" CssClass="normaldetalle">CALADO:</asp:Label></TD>
								<TD style="HEIGHT: 17px" align="left">
									<asp:Label id="lblTCalado" runat="server" CssClass="normaldetalle"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 136px; HEIGHT: 17px" align="right">
									<asp:Label id="lblMotor" runat="server" CssClass="normaldetalle">MOTOR:</asp:Label></TD>
								<TD style="WIDTH: 174px; HEIGHT: 17px" align="left">
									<asp:Label id="lblTMotor" runat="server" CssClass="normaldetalle"></asp:Label></TD>
								<TD style="WIDTH: 13px; HEIGHT: 17px"></TD>
								<TD style="WIDTH: 118px; HEIGHT: 17px">
									<asp:Label id="lblVelocidad" runat="server" CssClass="normaldetalle">VELOCIDAD:</asp:Label></TD>
								<TD style="HEIGHT: 17px" align="left">
									<asp:Label id="lblTVelocidad" runat="server" CssClass="normaldetalle"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 136px; HEIGHT: 17px" align="right">
									<asp:Label id="lblPotencia" runat="server" CssClass="normaldetalle">POTENCIA:</asp:Label></TD>
								<TD style="WIDTH: 174px; HEIGHT: 17px" align="left">
									<asp:Label id="lblTPotencia" runat="server" CssClass="normaldetalle">POTENCIA:</asp:Label></TD>
								<TD style="WIDTH: 13px; HEIGHT: 17px"></TD>
								<TD style="WIDTH: 118px; HEIGHT: 17px">
									<asp:Label id="lblDotacion" runat="server" CssClass="normaldetalle">DOTACION:</asp:Label></TD>
								<TD style="HEIGHT: 17px" align="left">
									<asp:Label id="lblTDotacion" runat="server" CssClass="normaldetalle"></asp:Label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
				<TR>
					<TD>
						<asp:Label id="lblInformacion" runat="server" CssClass="normaldetalle">( - ) .- Información Pendiente</asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label4" runat="server" CssClass="normaldetalle">( * ) .- Información No Correspondiente</asp:Label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
