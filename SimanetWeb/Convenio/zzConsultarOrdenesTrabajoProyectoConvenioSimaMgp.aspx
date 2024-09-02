<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarOrdenesTrabajoProyectoConvenioSimaMgp.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.ConsultarOrdenesTrabajoProyectoConvenioSimaMgp" %>
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
					<td colSpan="3">
						<uc1:HeaderInicio id="HeaderInicio1" runat="server"></uc1:HeaderInicio></td>
				</tr>
				<tr>
					<td vAlign="top" width="15%" bgColor="#f6f6f6">
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu><br>
						<P>&nbsp;</P>
					</td>
					<td bgColor="#2b1700"></td>
					<td vAlign="top" width="85%">
						<TABLE id="Tablen" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="12" style="WIDTH: 12px"></td>
								<td>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD colspan="3">
												<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Convenios</asp:label>
												<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Ordenes de Trabajo de un Proyecto de Convenio</asp:label></TD>
										</TR>
										<TR align="center">
											<TD colspan="3">
												<asp:Label id="lblTitulo" runat="server" CssClass="TituloPrincipal" Width="100%"> Convenio...</asp:Label></TD>
										</TR>
										<TR>
											<TD>
												<asp:Label id="lblDescripcion" runat="server" CssClass="normal" Width="100%">Proyecto</asp:Label></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD colspan="3" style="HEIGHT: 67px">
												<asp:TextBox id="TextBox1" runat="server" Width="100%" TextMode="MultiLine" Height="64px"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR align="center">
											<TD colspan="3" style="HEIGHT: 39px">
												<asp:Label id="lblTituloOrdenDeTrabajo" runat="server" CssClass="TituloSecundario" Width="100%">Valorizaciones y Ordenes de Trabajo</asp:Label></TD>
										</TR>
										<TR align="center">
											<TD>
												<asp:imagebutton id="ibtnAgregar" runat="server" CssClass="normal" ImageUrl="../imagenes/BtPU_agregar.gif"
													AlternateText="Agregar"></asp:imagebutton></TD>
											<TD>
												<asp:imagebutton id="ibtnEliminar" runat="server" CssClass="normal" ImageUrl="../imagenes/BtPU_borrar.gif"
													AlternateText="Eliminar"></asp:imagebutton></TD>
											<TD>
												<asp:imagebutton id="Imagebutton1" runat="server" CssClass="normal" ImageUrl="../imagenes/BtPU_reporte.gif"
													AlternateText="Imprimir"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR align="center">
											<TD colspan="3">
												<cc1:datagridweb id="dgConsultarConvenios" runat="server" Width="100%" Height="264px" RowPositionEnabled="False"
													RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="IdProyectoConvenio" HeaderText="IdProyectoConvenio"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="IdValorizacionOrdenTrabajo" HeaderText="IdValorizacionOrdenTrabajo"></asp:BoundColumn>
														<asp:BoundColumn DataField="NroValorizacion" HeaderText="Valorizaci&#243;n"></asp:BoundColumn>
														<asp:BoundColumn DataField="NroOrdenTrabajo" HeaderText="Orden de Trabajo"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="Unidad Dependencia"></asp:BoundColumn>
														<asp:BoundColumn DataField="Alias" HeaderText="Alias"></asp:BoundColumn>
														<asp:BoundColumn DataField="IdEstadoValorOrdenTraba" HeaderText="Estado"></asp:BoundColumn>
														<asp:BoundColumn DataField="PorcAvanceFisico" HeaderText="% Avance"></asp:BoundColumn>
														<asp:BoundColumn DataField="MontoPrecioVentaSoles" HeaderText="Presupuesto"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Descripcion" HeaderText="Descripcion"></asp:BoundColumn>
														<mbrsc:RowSelectorColumn HeaderText="Seleccion" SelectionMode="Single"></mbrsc:RowSelectorColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb>
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda">lblResultado</asp:label></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="lblObservaciones" runat="server" CssClass="normal">Descripción:</asp:label></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR align="center">
											<TD colspan="3">
												<asp:textbox id="txtObservaciones" runat="server" Width="100%" Height="62px" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
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
