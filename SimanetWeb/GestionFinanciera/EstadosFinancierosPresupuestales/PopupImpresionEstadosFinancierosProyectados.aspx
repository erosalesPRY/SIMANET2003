<%@ Register TagPrefix="uc1" TagName="ParametroContable" Src="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="PopupImpresionEstadosFinancierosProyectados.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancierosPresupuestales.PopupImpresionEstadosFinancierosProyectados" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial2();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3" align="center" class="TituloPrincipal">
						<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="3" align="center">
						<TABLE class="normal" id="Table2" cellSpacing="0" cellPadding="0" width="772" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE id="Table3" style="HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 2px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 76px" vAlign="middle">
												<asp:Label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True" DESIGNTIMEDRAGDROP="1229"
													Width="72px" ForeColor="Navy">PERIODO :</asp:Label></TD>
											<TD style="WIDTH: 58px" vAlign="middle">
												<asp:Label id="lblPeriodo" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True"
													DESIGNTIMEDRAGDROP="1231" ForeColor="Navy">Periodo :</asp:Label></TD>
											<TD vAlign="middle" align="center" width="100%" colSpan="3">
												<asp:label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True" ForeColor="Navy">EN MILES DE NUEVOS SOLES</asp:label></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<TABLE id="grid" style="BORDER-TOP-WIDTH: 1px; BORDER-RIGHT: #999999 1px solid; BORDER-BOTTOM: #999999 1px solid"
										cellSpacing="1" cellPadding="0" width="772" bgColor="buttonface" border="0" runat="server">
										<TR class="Headergrilla">
											<TD vAlign="middle" width="131" rowSpan="3" style="WIDTH: 131px">
												<asp:Label id="Label4" runat="server" Width="125px">CONCEPTO</asp:Label></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD colSpan="14" id="lblEmpresa" runat="server">SIMA PERU S.A</TD>
										</TR>
										<TR class="Headergrilla">
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD colSpan="12">REAL</TD>
											<TD style="WIDTH: 71px" align="center">PROYECTADO</TD>
											<TD vAlign="middle" rowSpan="2" runat="server" id="ColumnaTotal">TOTAL</TD>
										</TR>
										<TR class="Headergrilla">
											<TD style="DISPLAY: none">.</TD>
											<TD style="DISPLAY: none">.</TD>
											<TD style="DISPLAY: none">.</TD>
											<TD style="DISPLAY: none">.</TD>
											<TD width="85">ENE</TD>
											<TD width="85">FEB</TD>
											<TD width="85">MAR</TD>
											<TD width="85">ABR</TD>
											<TD width="85">MAY</TD>
											<TD width="85">JUN</TD>
											<TD width="85">JULI</TD>
											<TD width="85">AGO</TD>
											<TD width="85">SET</TD>
											<TD width="85">OCT</TD>
											<TD width="85">NOV</TD>
											<TD width="85">DIC</TD>
											<TD width="71" style="WIDTH: 71px">SUB</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3" align="center">
						<asp:Label id="Label2" runat="server" CssClass="TextoAzul" Font-Bold="True" Font-Size="X-Small"
							Visible="False">MES :</asp:Label>
						<asp:Label id="lblMes" runat="server" CssClass="TextoAzul" Font-Bold="True" Font-Size="X-Small"
							Visible="False">Periodo :</asp:Label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><INPUT id="objHistorial" type="hidden" name="objHistorial"></TD>
					<TD></TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
