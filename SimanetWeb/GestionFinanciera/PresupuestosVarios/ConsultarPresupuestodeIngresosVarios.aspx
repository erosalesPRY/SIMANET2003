<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarPresupuestodeIngresosVarios.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios.ConsultarPresupuestodeIngresosVarios" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<!--oncontextmenu="return false"-->
	</HEAD>
	<body onkeydown="if(event.keyCode==13){return false;}" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera>Presupuesto></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Presupuesto de Ingresos Varios</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="520" border="0">
							<TR>
								<TD style="WIDTH: 724px" align="center" width="724" colSpan="3">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 132px">
												<asp:label id="Label1" runat="server" CssClass="TextoBlanco" Width="144px" ForeColor="Navy"
													Font-Bold="True">CENTRO DE OPERACIONES :</asp:label></TD>
											<TD>
												<asp:label id="lblNombreCentro" runat="server" CssClass="TextoBlanco" Width="360px" ForeColor="Navy"
													Font-Bold="True"></asp:label></TD>
										</TR>
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 132px">
												<asp:label id="Label2" runat="server" CssClass="TextoBlanco" Width="144px" ForeColor="Navy"
													Font-Bold="True">PRESUPUESTO :</asp:label></TD>
											<TD>
												<asp:label id="lblNombreTipoPresupuesto" runat="server" CssClass="TextoBlanco" Width="368px"
													ForeColor="Navy" Font-Bold="True"></asp:label></TD>
										</TR>
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 132px" colSpan="2">
												<TABLE id="Table13" style="WIDTH: 200px; HEIGHT: 16px" cellSpacing="1" cellPadding="1"
													width="200" align="left" border="0">
													<TR>
														<TD style="WIDTH: 46px">
															<asp:label id="Label5" runat="server" CssClass="TextoBlanco" Width="80%" ForeColor="Navy" Font-Bold="True">Periodo :</asp:label></TD>
														<TD style="WIDTH: 33px">
															<asp:label id="lblPeriodo" runat="server" CssClass="TextoBlanco" Width="80%" ForeColor="Navy"
																Font-Bold="True">[periodo]</asp:label></TD>
														<TD style="WIDTH: 42px">
															<asp:label id="Label4" runat="server" CssClass="TextoBlanco" ForeColor="Navy" Font-Bold="True">Mes :</asp:label></TD>
														<TD style="WIDTH: 78px">
															<asp:label id="lblMes" runat="server" CssClass="TextoBlanco" Width="72px" ForeColor="Navy"
																Font-Bold="True">[mes]</asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<cc1:datagridweb id="grid" runat="server" Width="526px" ShowFooter="True" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Ingresos" HeaderText="INGRESOS">
												<HeaderStyle HorizontalAlign="Center" Width="40%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Presupuesto" HeaderText="PRESUPUESTO">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Ejecutado" HeaderText="REAL">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Saldo" HeaderText="SALDO">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
