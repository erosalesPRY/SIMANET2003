<%@ Page language="c#" Codebehind="ProcesaryListarEstadosFinancieros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EEFFUNISYS.ProcesaryListarEstadosFinancieros" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Estados financieros UNISYS</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="top" align="left" width="100%">
						<uc1:Header id="Header1" runat="server"></uc1:Header>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left" width="100%">
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu>
					</TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" style="HEIGHT: 22px" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Estados Financieros UNISYS</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
					</TD>
				</TR>
				<tr>
					<td>
					</td>
				</tr>
			</table>
			&nbsp;
			<TABLE style="WIDTH: 727px; HEIGHT: 132px" id="Table1" border="0" cellSpacing="1" cellPadding="1"
				width="727" align="center">
				<TR>
					<TD colSpan="3" align="center" style="FONT-WEIGHT: bold">ESTADOS FINANCIEROS</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px">
						<asp:Label id="Label1" runat="server">Año:</asp:Label></TD>
					<TD style="WIDTH: 396px">
						<asp:DropDownList id="ddlAño" runat="server"></asp:DropDownList></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px">
						<asp:Label id="Label2" runat="server">Mes:</asp:Label></TD>
					<TD style="WIDTH: 396px; HEIGHT: 40px">
						<asp:DropDownList id="ddlMes" runat="server" Width="200px"></asp:DropDownList></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px">
						<asp:Label id="Label3" runat="server">Estado Financiero:</asp:Label></TD>
					<TD style="WIDTH: 396px">
						<asp:DropDownList id="ddlFormato" runat="server" Width="392px">
							<asp:ListItem Value="0">[Seleccionar..]</asp:ListItem>
							<asp:ListItem Value="1">Balance General</asp:ListItem>
							<asp:ListItem Value="2">Estado de Ganancias y Perdidas</asp:ListItem>
						</asp:DropDownList></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="BORDER-BOTTOM: #808080 1px dotted; PADDING-LEFT: 5px; WIDTH: 161px; HEIGHT: 20px; COLOR: #ffffff; FONT-SIZE: 10pt; FONT-WEIGHT: bold"
						colSpan="3">.</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px"></TD>
					<TD style="WIDTH: 396px" align="right">
						<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="300" align="right">
							<TR>
								<TD>
									<asp:Button style="Z-INDEX: 0" id="btnProcesar" runat="server" Text="Procesar"></asp:Button></TD>
								<TD align="right">
									<asp:Button style="Z-INDEX: 0" id="btnImprimir" runat="server" Text="Vista Previa"></asp:Button></TD>
							</TR>
						</TABLE>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px"></TD>
					<TD style="WIDTH: 396px; HEIGHT: 50px" align="right"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 161px"></TD>
					<TD style="WIDTH: 396px" align="right"><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt=""
							src="../../imagenes/atras.gif"></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
