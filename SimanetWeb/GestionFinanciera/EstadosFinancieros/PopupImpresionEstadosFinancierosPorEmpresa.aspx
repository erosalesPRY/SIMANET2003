<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="ParametroContable" Src="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx" %>
<%@ Page language="c#" Codebehind="PopupImpresionEstadosFinancierosPorEmpresa.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.PopupImpresionEstadosFinancierosPorEmpresa" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
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
						<TABLE class="normal" id="Table2" cellSpacing="1" cellPadding="4" width="773" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 302px">
												<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" align="left" border="0">
													<TR>
														<TD style="WIDTH: 63px">
															<asp:label id="Label4" runat="server" CssClass="TituloPrincipalBlanco" DESIGNTIMEDRAGDROP="151"
																Font-Bold="True" ForeColor="Navy">PERIODO :</asp:label></TD>
														<TD style="WIDTH: 34px">
															<asp:label id="lblPeriodo" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True"
																ForeColor="Navy">[Periodo]</asp:label></TD>
														<TD style="WIDTH: 26px">
															<asp:label id="Label5" runat="server" CssClass="TituloPrincipalBlanco" DESIGNTIMEDRAGDROP="174"
																Font-Bold="True" ForeColor="Navy">MES :</asp:label></TD>
														<TD>
															<asp:label id="lblMes" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True" DESIGNTIMEDRAGDROP="132"
																ForeColor="Navy">[Mes]</asp:label></TD>
													</TR>
												</TABLE>
											</TD>
											<TD style="WIDTH: 1px"></TD>
											<TD vAlign="bottom">&nbsp;</TD>
											<TD>
												<asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True" ForeColor="Navy">EN MILES DE NUEVOS SOLES</asp:label></TD>
											<TD style="WIDTH: 209px" align="right"><IMG style="WIDTH: 110px; HEIGHT: 16px" height="16" src="../../imagenes/spacer.gif" width="110"></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<TABLE id="grid" style="BORDER-TOP-WIDTH: 1px; BORDER-RIGHT: #999999 1px solid; BORDER-BOTTOM: #999999 1px solid"
										cellSpacing="1" cellPadding="1" width="772" bgColor="buttonface" border="0" runat="server">
										<TR class="HeaderGrilla">
											<TD vAlign="middle" width="135" rowSpan="3" style="WIDTH: 135px">
												<asp:Label id="Label2" runat="server" Width="128px">CONCEPTO</asp:Label></TD>
											<TD style="DISPLAY: none" colSpan="2"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD colSpan="15">
												<asp:Label id="lblCentro" runat="server">Label</asp:Label></TD>
										</TR>
										<TR class="HeaderGrilla">
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD vAlign="middle" width="85" rowSpan="2">PPTO</TD>
											<TD colSpan="12">REAL</TD>
											<TD vAlign="middle" width="85" rowSpan="2">TOT</TD>
											<TD vAlign="middle" width="85" rowSpan="2">SAL</TD>
										</TR>
										<TR class="HeaderGrilla">
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD width="85">ENE</TD>
											<TD width="85">FEB</TD>
											<TD width="85">MAR</TD>
											<TD width="85">ABR</TD>
											<TD width="85">MAY</TD>
											<TD width="85">JUN</TD>
											<TD width="85">JUL</TD>
											<TD width="85">AGO</TD>
											<TD width="85">SET</TD>
											<TD width="85">OCT</TD>
											<TD width="85">NOV</TD>
											<TD width="85">DIC</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="ReemplazaHistorial();HistorialIrAtras();"
										alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3" align="center"><INPUT id="objHistorial" type="hidden" name="objHistorial"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
