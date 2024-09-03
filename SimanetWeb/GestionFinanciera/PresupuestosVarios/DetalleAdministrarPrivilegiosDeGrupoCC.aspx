<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="DetalleAdministrarPrivilegiosDeGrupoCC.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PresupuestosVarios.DetalleAdministrarPrivilegiosDeGrupoCC" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleAdministrarPrivilegiosDeGrupoCC</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Administrar Privilegios de Grupo de Centro de Costos > Detalle Administracion</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 488px" colSpan="3">
						<DIV align="center">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="300" align="center" border="0">
								<TR>
									<TD style="WIDTH: 448px" bgColor="#000080" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" DESIGNTIMEDRAGDROP="25"
											Height="16px" Width="358px"></asp:label></TD>
								</TR>
								<TR>
									<TD class="headerDetalle" style="WIDTH: 154px"><asp:label id="Label1" runat="server" Width="134px">NRO Grupo de Centro de Costos</asp:label></TD>
									<TD bgColor="#f0f0f0"><asp:textbox id="txtNroGrupoCC" runat="server" CssClass="normaldetalle" Width="64px" BackColor="WhiteSmoke"
											ReadOnly="True" BorderStyle="Groove"></asp:textbox></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD class="headerDetalle" style="WIDTH: 154px"><asp:label id="Label2" runat="server" Width="142px">NOMBRE DE GRUPO DE CENTRO DE COSTOS</asp:label></TD>
									<TD bgColor="#dddddd"><asp:textbox id="txtNombreGrupoCC" runat="server" CssClass="normaldetalle" Width="293px" BackColor="WhiteSmoke"
											ReadOnly="True" BorderStyle="Groove"></asp:textbox></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD class="headerDetalle" style="WIDTH: 154px"><asp:label id="Label3" runat="server" Width="142px">TIPO DE PRESUPUESTO</asp:label></TD>
									<TD bgColor="#f0f0f0"><asp:dropdownlist id="ddlbTipoPresupuestoo" runat="server" CssClass="normaldetalle" Width="295px"
											BackColor="WhiteSmoke" Enabled="False"></asp:dropdownlist></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 448px" colSpan="3">
										<P align="left">&nbsp;</P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 448px" colSpan="3">
										<P align="right">
											<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="300" border="0">
												<TR>
													<TD style="WIDTH: 157px" bgColor="#000080"><asp:label id="Label5" runat="server" CssClass="TituloPrincipalBlanco" Width="224px">Lista de Usuarios</asp:label></TD>
													<TD bgColor="#f0f0f0"><IMG style="WIDTH: 40px; HEIGHT: 8px" height="8" src="../../imagenes/spacer.gif" width="40"></TD>
													<TD bgColor="#000080"><asp:label id="Label6" runat="server" CssClass="TituloPrincipalBlanco" Width="223px">Usuarios Asignados</asp:label></TD>
												</TR>
											</TABLE>
										</P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 448px" colSpan="3">
										<P align="right">&nbsp;</P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 448px" colSpan="3">
										<P align="center">
											<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="300" border="0">
												<TR>
													<TD bgColor="#f0f0f0"><asp:listbox id="lstListaUsuarios" runat="server" CssClass="normaldetalle" Height="100px" Width="227px"></asp:listbox></TD>
													<TD>
														<P>
															<TABLE id="Table5" style="WIDTH: 34px; HEIGHT: 66px" cellSpacing="0" cellPadding="0" width="34"
																border="0">
																<TR>
																	<TD align="center"></TD>
																</TR>
																<TR>
																	<TD align="center"><asp:button id="btnAñadir" runat="server" Text=">>"></asp:button></TD>
																</TR>
																<TR>
																	<TD align="center"><asp:button id="btnQuitar" runat="server" Text="<<"></asp:button></TD>
																</TR>
															</TABLE>
														</P>
														<P>&nbsp;</P>
													</TD>
													<TD bgColor="#f0f0f0"><asp:listbox id="lstListaUsuariosAsignados" runat="server" CssClass="normaldetalle" Height="98px"
															Width="227px"></asp:listbox></TD>
												</TR>
											</TABLE>
										</P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 448px" colSpan="3">
										<P align="right">
											<TABLE id="Table3" style="WIDTH: 172px; HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="172"
												border="0">
												<TR>
													<TD style="WIDTH: 209px">
														<P align="right"><asp:imagebutton id="ibtnAceptar" runat="server" Width="86px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></P>
													</TD>
													<TD>
														<P align="right"><asp:imagebutton id="ibtnCancelar" runat="server" Height="22px" Width="87px" ImageUrl="../../imagenes/bt_cancelar.gif"
																CausesValidation="False"></asp:imagebutton></P>
													</TD>
												</TR>
											</TABLE>
										</P>
									</TD>
								</TR>
							</TABLE>
							<P align="right">&nbsp;</P>
							<P align="right">&nbsp;</P>
							<P align="right">&nbsp;</P>
							<P align="right">&nbsp;</P>
						</DIV>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
		<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
