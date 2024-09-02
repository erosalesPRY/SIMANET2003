<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultaAcercaObjetivoGeneral.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica.ConsultaAcercaObjetivoGeneral" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ConsultaAcercaObjetivoGeneral</title>
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
			<P>
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
					</TR>
					<TR>
						<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
					</TR>
					<TR>
						<TD class="commands">
							<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Estratégica > Proceso Estratégico >  Consultar Objetivos Generales >  Acerca del Objetivo General</asp:label></TD>
					</TR>
					<TR>
						<TD>
							<asp:Image id="Image1" runat="server" Width="48px" Height="16px" ImageUrl="../../imagenes/spacer.gif"></asp:Image></TD>
					</TR>
					<TR>
						<TD>
							<DIV align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalAzul">ACERCA DEL OBJETIVO GENERAL</asp:label></DIV>
						</TD>
					</TR>
					<TR>
						<TD>
							<asp:Image id="Image2" runat="server" Width="48px" Height="16px" ImageUrl="../../imagenes/spacer.gif"></asp:Image></TD>
					</TR>
					<TR>
						<TD>
							<DIV align="center"><asp:label id="lblMensaje" runat="server" CssClass="ResultadoBusqueda" Width="174px"></asp:label></DIV>
							<DIV align="center">
								<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
									<TR>
										<TD style="HEIGHT: 3px" bgColor="#f0f0f0">
											<P align="center">
												<TABLE id="Table4" borderColor="#ffffff" cellSpacing="0" cellPadding="1" width="100%" bgColor="#f0f0f0"
													border="2">
													<TR>
														<TD style="WIDTH: 19px" bgColor="#f0f0f0">
															<asp:Label id="lblCodigoObjGeneral" runat="server" CssClass="normaldetalle" Width="20px"></asp:Label></TD>
														<TD bgColor="#f0f0f0">
															<asp:Label id="lblContenidoObjGeneral" runat="server" CssClass="NormalDetalle" Width="100%"
																Height="2px"></asp:Label></TD>
													</TR>
												</TABLE>
											</P>
										</TD>
									</TR>
									<TR>
										<TD>
											<DIV align="center">
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0"
													runat="server">
													<TR>
														<TD>
															<asp:Image id="Image3" runat="server" ImageUrl="../../imagenes/spacer.gif" Height="16px" Width="48px"></asp:Image></TD>
													</TR>
													<TR>
														<TD bgColor="#000080">
															<P align="center">
																<asp:Label id="Label1" runat="server" CssClass="TituloPrincipalBlanco">FUNDAMENTO DEL OBJETIVO GENERAL</asp:Label></P>
														</TD>
													</TR>
													<TR>
														<TD bgColor="#dddddd">
															<P align="center">
																<asp:TextBox id="txtFundamento" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="Groove"
																	ReadOnly="True" Height="56px" TextMode="MultiLine"></asp:TextBox></P>
														</TD>
													</TR>
													<TR>
														<TD>
															<asp:Image id="Image4" runat="server" ImageUrl="../../imagenes/spacer.gif" Height="16px" Width="48px"></asp:Image></TD>
													</TR>
													<TR>
														<TD bgColor="#000080">
															<P align="center">
																<asp:Label id="Label2" runat="server" CssClass="TituloPrincipalBlanco">INVOLUCRADOS EN EL OBJETIVO GENERAL</asp:Label></P>
														</TD>
													</TR>
													<TR>
														<TD bgColor="#f0f0f0">
															<P align="center">
																<asp:TextBox id="txtInvolucrados" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="Groove"
																	ReadOnly="True" Height="56px" TextMode="MultiLine"></asp:TextBox></P>
														</TD>
													</TR>
													<TR>
														<TD>
															<asp:Image id="Image5" runat="server" ImageUrl="../../imagenes/spacer.gif" Height="16px" Width="48px"></asp:Image></TD>
													</TR>
													<TR>
														<TD bgColor="#000080">
															<P align="center">
																<asp:Label id="Label3" runat="server" CssClass="TituloPrincipalBlanco">REQUERIMIENTOS DEL OBJETIVO GENERAL</asp:Label></P>
														</TD>
													</TR>
													<TR>
														<TD bgColor="#dddddd">
															<P align="center">
																<asp:TextBox id="txtRequerimientos" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="Groove"
																	ReadOnly="True" Height="56px" TextMode="MultiLine"></asp:TextBox></P>
														</TD>
													</TR>
												</TABLE>
											</DIV>
											<DIV align="center">
												<DIV align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></DIV>
											</DIV>
										</TD>
									</TR>
								</TABLE>
							</DIV>
						</TD>
					</TR>
				</TABLE>
			</P>
		</form>
	</body>
</HTML>
