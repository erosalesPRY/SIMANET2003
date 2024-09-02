<%@ Page language="c#" Codebehind="ConsultarProyectosConvenioSimaMgpADM.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.ConsultarProyectosConvenioSimaMgpADM" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="3"><uc1:headerinicio id="HeaderInicio1" runat="server"></uc1:headerinicio></td>
				</tr>
				<tr>
					<td vAlign="top" width="15%" bgColor="#f6f6f6"><br>
						<P><uc1:menu id="Menu1" runat="server"></uc1:menu></P>
					</td>
					<td bgColor="#2b1700"></td>
					<td vAlign="top" width="85%">
						<TABLE id="Tablen" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="13" style="WIDTH: 13px"></td>
								<td>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD colSpan="3">
												<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Convenios
								</asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Projectos del Convenio</asp:label></TD>
										</TR>
										<tr align="center">
											<td colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal" Width="100%">Proyectos del Convenio...</asp:label></td>
										</tr>
										<TR align="center">
											<TD><asp:imagebutton id="ibtnAgregar" runat="server" CssClass="normal" ImageUrl="../imagenes/BtPU_agregar.gif"
													AlternateText="Agregar"></asp:imagebutton></TD>
											<TD><asp:imagebutton id="ibtnEliminar" runat="server" CssClass="normal" ImageUrl="../imagenes/BtPU_borrar.gif"
													AlternateText="Eliminar"></asp:imagebutton></TD>
											<TD><asp:imagebutton id="Imagebutton1" runat="server" CssClass="normal" ImageUrl="../imagenes/BtPU_reporte.gif"
													AlternateText="Imprimir"></asp:imagebutton></TD>
										</TR>
										<TR align="center">
											<TD colSpan="3">
												<HR width="85%" SIZE="2">
											</TD>
										</TR>
										<TR>
											<TD><asp:imagebutton id="ibtnAgregarOrdenTrabajo" runat="server" CssClass="normal" AlternateText="Agregar orden de trabajo"></asp:imagebutton></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR align="center">
											<TD colspan="3">
												<P>
													<cc1:datagridweb id="dgConsultarConvenios" runat="server" RowPositionEnabled="False" RowHighlightColor="#E0E0E0"
														AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" Height="264px" Width="100%">
														<ItemStyle CssClass="ItemGrilla"></ItemStyle>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
														<FooterStyle CssClass="FooterGrilla"></FooterStyle>
														<Columns>
															<asp:BoundColumn Visible="False" DataField="IdProyectoConvenio" HeaderText="IdProyectoConvenio"></asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="IdConvenioSimaMgp" HeaderText="IdConvenioSimaMgp"></asp:BoundColumn>
															<asp:BoundColumn DataField="NroConvenio" HeaderText="Nro"></asp:BoundColumn>
															<asp:BoundColumn DataField="Descripcion" HeaderText="Descripcion"></asp:BoundColumn>
															<asp:BoundColumn DataField="MontoAsignado" HeaderText="Monto Asignado S/."></asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="Observaciones" HeaderText="Observaciones"></asp:BoundColumn>
															<mbrsc:RowSelectorColumn HeaderText="Seleccion" SelectionMode="Single"></mbrsc:RowSelectorColumn>
														</Columns>
														<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													</cc1:datagridweb>
													<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda">lblResultado</asp:label></P>
											</TD>
										</TR>
										<TR>
											<TD><asp:label id="lblObservaciones" runat="server" CssClass="normal">Observaciones:</asp:label></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<tr>
											<td colspan="3">
												<asp:textbox id="txtObservaciones" runat="server" Width="100%" Height="62px" TextMode="MultiLine"></asp:textbox></td>
										</tr>
									</TABLE>
								</td>
							</tr>
						</TABLE>
					</td>
				</tr>
				<TR align="center">
					<TD bgColor="#5891ae" colSpan="3"><asp:label id="lblTexto" runat="server" CssClass="TextoFooter">© SIMA 2004</asp:label></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
