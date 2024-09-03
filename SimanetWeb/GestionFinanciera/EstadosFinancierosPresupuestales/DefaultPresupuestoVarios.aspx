<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="DefaultPresupuestoVarios.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancierosPresupuestales.DefaultPresupuestoVarios" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR>
					<TD width="100%" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" style="HEIGHT: 20px" width="100%" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Estados Financieros></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> ..</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TABLE id="Table23" cellSpacing="1" cellPadding="1" width="655" border="0" height="280">
							<TR>
								<TD width="25%"></TD>
								<TD style="WIDTH: 31px">
									<asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" Width="272px" Font-Bold="True"
										ForeColor="Navy" BackColor="Transparent"> PRESUPUESTO</asp:label></TD>
								<TD align="right" width="25%"></TD>
							</TR>
							<TR>
								<TD width="25%"></TD>
								<TD style="WIDTH: 31px">
									<TABLE id="Table13" style="WIDTH: 256px; HEIGHT: 27px" cellSpacing="1" cellPadding="1"
										width="256" align="left" border="0">
										<TR>
											<TD style="WIDTH: 46px">
												<asp:label id="Label5" runat="server" CssClass="TituloPrincipalBlanco" Width="80%" ForeColor="Navy"
													BackColor="Transparent">PERIODO :</asp:label></TD>
											<TD style="WIDTH: 66px">
												<asp:dropdownlist id="ddlbPeriodo" runat="server" CssClass="combos" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD style="WIDTH: 42px">
												<asp:label id="Label4" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" BackColor="Transparent">MES :</asp:label></TD>
											<TD style="WIDTH: 78px">
												<asp:dropdownlist id="dddblMes" runat="server" CssClass="combos" AutoPostBack="True">
													<asp:ListItem Value="1">Enero</asp:ListItem>
													<asp:ListItem Value="2">Febrero</asp:ListItem>
													<asp:ListItem Value="3">Marzo</asp:ListItem>
													<asp:ListItem Value="4">Abril</asp:ListItem>
													<asp:ListItem Value="5">Mayo</asp:ListItem>
													<asp:ListItem Value="6">Junio</asp:ListItem>
													<asp:ListItem Value="7">Julio</asp:ListItem>
													<asp:ListItem Value="8">Agosto</asp:ListItem>
													<asp:ListItem Value="9">Setiembre</asp:ListItem>
													<asp:ListItem Value="10">Octubre</asp:ListItem>
													<asp:ListItem Value="11">Noviembre</asp:ListItem>
													<asp:ListItem Value="12">Diciembre</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD style="WIDTH: 42px"></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
								<TD align="right" width="25%"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 179px">
									<TABLE id="Table1" style="WIDTH: 180px; HEIGHT: 210px" cellSpacing="1" cellPadding="1"
										width="180" border="0">
										<TR>
											<TD height="50%"><IMG id="ibtnGananciasyPerdidas" onmouseover="this.src='../../imagenes/GestionFinanciera_r3_c3_f2.gif'"
													onmouseout="this.src='../../imagenes/GestionFinanciera_r3_c3.gif'" height="38" alt="" src="../../imagenes/GestionFinanciera_r3_c3.gif"
													width="171" border="0" name="GestionFinanciera_r3_c3" runat="server"></TD>
										</TR>
										<TR>
											<TD height="50%"><IMG id="ibtnFlujoCaja" onmouseover="this.src='../../imagenes/GestionFinanciera_r6_c2_f2.gif'"
													onmouseout="this.src='../../imagenes/GestionFinanciera_r6_c2.gif'" height="35" alt="" src="../../imagenes/GestionFinanciera_r6_c2.gif"
													width="171" border="0" name="GestionFinanciera_r6_c2" runat="server"></TD>
										</TR>
									</TABLE>
								</TD>
								<TD align="center" width="50%"><IMG style="WIDTH: 200px; HEIGHT: 222px" height="222" src="../../imagenes/EscudoSimaDorado3.jpg"
										width="200"></TD>
								<TD style="WIDTH: 179px">
									<TABLE id="Table2" style="WIDTH: 180px; HEIGHT: 210px" cellSpacing="1" cellPadding="1"
										width="182" border="0">
										<TR>
											<TD height="50%">
												<IMG id="ibtnBalanceGeneral" onmouseover="this.src='../../imagenes/GestionFinanciera_r10_c2_f2.gif'"
													onmouseout="this.src='../../imagenes/GestionFinanciera_r10_c2.gif'" height="45" alt=""
													src="../../imagenes/GestionFinanciera_r10_c2.gif" width="173" border="0" name="GestionFinanciera_r10_c2"
													runat="server"></TD>
										</TR>
										<TR>
											<TD height="50%"><IMG id="ibtnIngresosyEgresos" onmouseover="this.src='../../imagenes/FinancieroIquitos_r7_c10_f2.gif'"
													onmouseout="this.src='../../imagenes/FinancieroIquitos_r7_c10.gif'" height="45" alt="" src="../../imagenes/FinancieroIquitos_r7_c10.gif"
													width="173" border="0" name="GestionFinanciera_r10_c2" runat="server"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 179px"></TD>
								<TD style="WIDTH: 31px"></TD>
								<TD style="WIDTH: 179px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 179px"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
								<TD style="WIDTH: 31px"></TD>
								<TD style="WIDTH: 179px"></TD>
							</TR>
						</TABLE>
						</A></TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
