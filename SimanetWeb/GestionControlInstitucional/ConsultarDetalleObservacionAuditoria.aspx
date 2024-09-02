<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarDetalleObservacionAuditoria.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.ConsultarDetalleObservacionAuditoria" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="top" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD vAlign="top" colSpan="3"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<td vAlign="top">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD style="HEIGHT: 461px"></TD>
								<TD style="HEIGHT: 461px" align="center"></TD>
								<TD vAlign="top" align="center">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<TR>
											<TD class="Commands" vAlign="top" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >  Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro Observación de Auditoría</asp:label></TD>
										</TR>
									</TABLE>
									<TABLE id="Table5" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="752" border="1">
										<TR>
											<TD bgColor="#000080" colSpan="9"><asp:dropdownlist id="ddlbTipoJuicio" runat="server" CssClass="normal" Visible="False" Height="36px"
													Enabled="False" Width="2px"></asp:dropdownlist></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="lblConcepto" runat="server" CssClass="TextoBlanco"> Descripción:</asp:label></TD>
											<TD bgColor="#dddddd" colSpan="8">
												<asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="647px" Height="50px"
													BackColor="Transparent" BorderWidth="0px" ReadOnly="True" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label2" runat="server" CssClass="TextoBlanco">C.O.</asp:label></TD>
											<TD bgColor="#f0f0f0" colSpan="8">
												<asp:textbox id="txtCentroOperativo" runat="server" CssClass="normaldetalle" BackColor="Transparent"
													BorderWidth="0px" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label7" runat="server" CssClass="TextoBlanco">Fecha Término:</asp:label></TD>
											<TD bgColor="#dddddd" colSpan="8"><asp:textbox id="txtFechaTermino" runat="server" CssClass="normaldetalle" ReadOnly="True" BorderWidth="0px"
													BackColor="Transparent"></asp:textbox></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label9" runat="server" CssClass="TextoBlanco">Situación:</asp:label></TD>
											<TD bgColor="#f0f0f0" colSpan="8">
												<asp:textbox id="txtSituacion" runat="server" CssClass="normaldetalle" BackColor="Transparent"
													BorderWidth="0px" MaxLength="200" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label5" runat="server" CssClass="TextoBlanco">Responsable:</asp:label></TD>
											<TD bgColor="#dddddd" colSpan="8">
												<asp:textbox id="txtPersonal" runat="server" CssClass="normaldetalle" Width="100%" BackColor="Transparent"
													BorderWidth="0px" MaxLength="200" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label1" runat="server" CssClass="TextoBlanco">Recomendacion:</asp:label></TD>
											<TD bgColor="#dddddd" colSpan="8">
												<asp:textbox id="txtRecomendacion" runat="server" CssClass="normaldetalle" Width="647px" Height="50px"
													TextMode="MultiLine" ReadOnly="True" BorderWidth="0px" BackColor="Transparent"></asp:textbox></TD>
										</TR>
										<TR>
											<TD colSpan="9">
												<cc2:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="100%" AutoGenerateColumns="False"
													AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" PageSize="3" ShowFooter="True"
													AllowSorting="True">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Documento" SortExpression="Documento" HeaderText="DOCUMENTO">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaAccion" SortExpression="FechaAccion" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="ObservacionAccion" SortExpression="ObservacionAccion" HeaderText="BITACORA DE GESTION">
															<HeaderStyle Width="31%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="OPINION" SortExpression="OPINION" HeaderText="OPINION OCI">
															<HeaderStyle Width="31%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="ARCH">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemTemplate>
																<asp:Image id="imgContrato" runat="server" Height="18px" ImageUrl="../imagenes/ley1.gif"></asp:Image>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc2:datagridweb></TD>
										</TR>
										<TR>
											<TD colSpan="9">
												<P align="center">
													<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></P>
											</TD>
										</TR>
									</TABLE>
									<TABLE id="Table7" width="752" border="0">
										<TR>
											<TD vAlign="top" align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"
													style="CURSOR: hand">
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
