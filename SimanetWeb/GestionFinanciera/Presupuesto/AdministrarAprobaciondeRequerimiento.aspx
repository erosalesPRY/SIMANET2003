<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarAprobaciondeRequerimiento.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.AdministrarAprobaciondeRequerimiento" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarEvaluacionGastosdeAdministracionCC</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="AsignarEventoGrid();ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 19px">
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px">
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Inicio> Gestión Financiera> Prespuesto> Administración Requerimiento</asp:label></TD>
				</TR>
				<TR>
					<TD align="left"><cc1:datagridweb id="grid" runat="server" ShowFooter="True" Width="100%" RowHighlightColor="#E0E0E0"
							AutoGenerateColumns="False" AllowSorting="True" PageSize="7">
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<FooterStyle CssClass="HeaderGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="N&#186;">
									<HeaderStyle Width="1%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="DOC">
									<HeaderStyle Width="2%"></HeaderStyle>
								</asp:TemplateColumn>
								<asp:BoundColumn HeaderText="N&#186; DOC.">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="FECHA">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="MOTIVO">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="MONTO">
									<HeaderStyle Width="10%"></HeaderStyle>
									<HeaderTemplate>
										<TABLE id="Table2" cellSpacing="1" cellPadding="0" width="300" align="left" border="0">
											<TR>
												<TD align="center" width="100%" colSpan="2">
													<asp:Label id="Label1" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">MONTO</asp:Label></TD>
											</TR>
											<TR>
												<TD align="center" width="50%">
													<asp:Label id="Label2" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">REQUERIDO</asp:Label></TD>
												<TD align="center" width="50%">
													<asp:Label id="Label3" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">APROBADO</asp:Label></TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table4" cellSpacing="1" cellPadding="0" width="300" align="left" border="0">
											<TR class="ItemGrillaSinColor">
												<TD align="right" width="50%">
													<asp:Label id="lblMontoRequerido" runat="server">0.00</asp:Label></TD>
												<TD align="right" width="50%">
													<asp:Label id="lblMontoAprobado" runat="server">0.00</asp:Label></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn HeaderText="DESCRIPCION">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center" width="100%">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
							<TR>
								<TD width="45%"><INPUT id="hidMes" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" runat="server"
										NAME="hidMes">&nbsp;<IMG id="btnMostrarIzq" onmouseover="this.src ='../../imagenes/Navegador/ibtnAnterior.gif'"
										onmouseup="this.src ='../../imagenes/Navegador/ibtnAnterior.gif';" onmousedown="this.src ='../../imagenes/Navegador/ibtnAnteriorPress.gif';"
										onclick="ScrollColumnas('Izquierda');" onmouseout="this.src='../../imagenes/Navegador/ibtnAnterior.gif';"
										src="../../imagenes/Navegador/ibtnAnterior.gif" name="btnQuitar" style="DISPLAY: none"><IMG id="btnMostrarDer" onmouseover="this.src ='../../imagenes/Navegador/ibtnSiguiente.gif'"
										onmouseup="this.src ='../../imagenes/Navegador/ibtnSiguiente.gif';" onmousedown="this.src ='../../imagenes/Navegador/ibtnSiguientePress.gif';" onclick="this.src ='../../imagenes/Navegador/ibtnSiguientePress.gif';ScrollColumnas('Derecha');"
										onmouseout="this.src='../../imagenes/Navegador/ibtnSiguiente.gif';" src="../../imagenes/Navegador/ibtnSiguiente.gif" style="DISPLAY: none">
								</TD>
								<TD>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
