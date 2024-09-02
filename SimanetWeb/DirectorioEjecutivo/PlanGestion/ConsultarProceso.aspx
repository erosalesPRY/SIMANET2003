<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarProceso.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion.ConsultarProceso" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarProceso</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Plan de Gestión ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta de Procesos</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:Image id="Image1" runat="server" Width="72px" Height="16px" ImageUrl="../../imagenes/spacer.gif"></asp:Image></TD>
				</TR>
				<TR>
					<TD>
						<P align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalAzul">DESARROLLO DEL PROCESO</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Image id="Image2" runat="server" Width="72px" Height="16px" ImageUrl="../../imagenes/spacer.gif"></asp:Image></TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center"></DIV>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="922" align="center" border="0"
							style="WIDTH: 922px; HEIGHT: 306px">
							<TR>
								<TD>
									<P align="left">
										<TABLE id="Table2" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="550" align="center"
											border="1" runat="server">
											<TR>
												<TD style="WIDTH: 138px" bgColor="#f0f0f0"><asp:label id="lblProceso" runat="server" CssClass="normaldetalle"></asp:label></TD>
												<TD bgColor="#f0f0f0"><asp:label id="lblNombreProceso" runat="server" CssClass="normaldetalle"></asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px"></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="lblDefinicion" runat="server" CssClass="TextoBlanco">Definición</asp:label></TD>
												<TD bgColor="#f0f0f0"><asp:textbox id="txtDefinicion" runat="server" CssClass="NormalDetalle" TextMode="MultiLine"
														Height="40px" BorderStyle="Groove" Width="450px" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="lblAlcance" runat="server" CssClass="TextoBlanco">Alcance</asp:label></TD>
												<TD bgColor="#dddddd"><asp:textbox id="txtAlcance" runat="server" CssClass="NormalDetalle" TextMode="MultiLine" Height="40px"
														BorderStyle="Groove" Width="450px" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="lblResponsable" runat="server" CssClass="TextoBlanco">Responsable</asp:label></TD>
												<TD bgColor="#f0f0f0"><asp:textbox id="txtResponsable" runat="server" CssClass="NormalDetalle" BorderStyle="Groove"
														Width="450px" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="lblLider" runat="server" CssClass="TextoBlanco">Lider</asp:label></TD>
												<TD bgColor="#dddddd"><asp:textbox id="txtLider" runat="server" CssClass="NormalDetalle" BorderStyle="Groove" Width="450px"
														ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="lblParticipantes" runat="server" CssClass="TextoBlanco">Participantes</asp:label></TD>
												<TD bgColor="#f0f0f0"><asp:textbox id="txtParticipante" runat="server" CssClass="NormalDetalle" TextMode="MultiLine"
														Height="40px" BorderStyle="Groove" Width="450px" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="lblCO" runat="server" CssClass="TextoBlanco">CO</asp:label></TD>
												<TD bgColor="#dddddd"><asp:textbox id="txtCentroOperativo" runat="server" CssClass="NormalDetalle" BorderStyle="Groove"
														Width="250px" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px">
													<P align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></P>
												</TD>
												<TD>
													<P align="right"><IMG id="ibtnSubproceso" style="CURSOR: hand" alt="" src="../../imagenes/btnSubprocesos.jpg"
															name="ibtnSubproceso" runat="server"></P>
												</TD>
											</TR>
										</TABLE>
									</P>
									<P align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<TR>
											<TD style="WIDTH: 17px">
												<P align="left">&nbsp;</P>
											</TD>
											<TD>
												<P align="right">&nbsp;</P>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
