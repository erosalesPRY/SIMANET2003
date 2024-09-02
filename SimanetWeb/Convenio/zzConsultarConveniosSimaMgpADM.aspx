<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="ConsultarConveniosSimaMgpADM.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.ConsultarConveniosSimaMgpADM" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="716" align="center" border="0" style="WIDTH: 716px; HEIGHT: 675px">
				<tr>
					<td style="HEIGHT: 5px" colSpan="3"><uc1:headerinicio id="HeaderInicio1" runat="server"></uc1:headerinicio></td>
				</tr>
				<tr>
					<td style="WIDTH: 119px; HEIGHT: 21px" vAlign="top" width="119" bgColor="#f6f6f6"><br>
						<P><uc1:menu id="Menu2" runat="server"></uc1:menu></P>
					</td>
				</tr>
				<tr>
					<td vAlign="top" width="85%">
						<TABLE id="Tablen" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td style="WIDTH: 13px" width="13"></td>
								<td>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Convenio</asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Convenios SIMA - MGP</asp:label></td>
										</tr>
										<TR>
											<TD align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal" Width="100%" Height="16px">Convenios SIMA - MGP</asp:label></TD>
										</TR>
										<TR>
											<TD colSpan="3">
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR align="center">
														<TD><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/BtPU_agregar.gif"></asp:imagebutton></TD>
														<TD><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/BtPU_borrar.gif"></asp:imagebutton></TD>
														<TD><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../imagenes/BtPU_reporte.gif"></asp:imagebutton></TD>
													</TR>
													<TR>
														<TD colSpan="3">
															<HR width="87%" SIZE="2">
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD colSpan="3">
												<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD><asp:label id="lblFiltrar" runat="server" CssClass="normal">Filtrar:</asp:label></TD>
														<TD align="right"><asp:label id="lblEstado" runat="server" CssClass="normal">Estado:</asp:label></TD>
														<TD><asp:dropdownlist id="ddlbEstadoConvenio" runat="server" CssClass="normal"></asp:dropdownlist></TD>
														<TD><asp:imagebutton id="ibtnProyecto" runat="server" CssClass="normal" AlternateText="Proyecto"></asp:imagebutton></TD>
														<TD><asp:imagebutton id="ibtnConogramaDePagos" runat="server" CssClass="normal" AlternateText="Cronograma de pagos"></asp:imagebutton></TD>
														<TD><asp:imagebutton id="ibtnConceptosPorPagar" runat="server" CssClass="normal" AlternateText="Conceptos por pagar"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD align="center" colSpan="3">
												<P><cc1:datagridweb id="dgConsultarConvenios" runat="server" Width="699px" Height="264px" AllowSorting="True"
														AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False">
														<ItemStyle CssClass="ItemGrilla"></ItemStyle>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
														<FooterStyle CssClass="FooterGrilla"></FooterStyle>
														<Columns>
															<asp:BoundColumn Visible="False" DataField="IdConvenioSimaMgp" HeaderText="IdConvenioSimaMgp"></asp:BoundColumn>
															<asp:BoundColumn DataField="NroConvenio" HeaderText="Convenio"></asp:BoundColumn>
															<asp:BoundColumn DataField="Descripcion" HeaderText="Descripcion"></asp:BoundColumn>
															<asp:BoundColumn DataField="FechaVencimiento" HeaderText="Fecha de vencimiento"></asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="Observaciones" HeaderText="Observaciones"></asp:BoundColumn>
															<mbrsc:RowSelectorColumn HeaderText="Seleccion" SelectionMode="Single"></mbrsc:RowSelectorColumn>
														</Columns>
														<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda">lblResultado</asp:label></P>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 15px"><asp:label id="lblObservaciones" runat="server" CssClass="normal">Observaciones:</asp:label></TD>
											<TD style="HEIGHT: 15px"></TD>
											<TD style="HEIGHT: 15px"></TD>
										</TR>
										<TR>
											<TD colSpan="3"><asp:textbox id="txtObservaciones" runat="server" Width="718px" Height="62px" TextMode="MultiLine"></asp:textbox></TD>
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
