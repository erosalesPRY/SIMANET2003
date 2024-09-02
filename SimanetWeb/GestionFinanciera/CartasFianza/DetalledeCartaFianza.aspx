<%@ Page language="c#" Codebehind="DetalledeCartaFianza.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasFianza.DetalledeCartaFianza" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc3" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Fainanciera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Renovación de Carta Fianza</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="771" border="0">
							<TR>
								<TD style="WIDTH: 85px; HEIGHT: 15px" bgColor="#000080" colSpan="8"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="8px" Width="304px">DETALLE CARTA FIANZA</asp:label></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 91px; HEIGHT: 25px"><asp:label id="Label2" runat="server">Nro Fianza :</asp:label></TD>
								<TD style="WIDTH: 188px; HEIGHT: 25px"><asp:textbox id="txtNroFza" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 6px; HEIGHT: 25px"></TD>
								<TD class="HeaderDetalle" style="WIDTH: 32px; HEIGHT: 25px"><asp:label id="Label11" runat="server">Situación :</asp:label></TD>
								<TD style="WIDTH: 173px; HEIGHT: 25px" colSpan="2"><asp:textbox id="txtSituacion" runat="server" CssClass="normaldetalle" Width="175px" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox></TD>
								<TD class="HeaderDetalle" style="HEIGHT: 25px"><asp:label id="Label3" runat="server">Moneda:</asp:label></TD>
								<TD style="HEIGHT: 25px"><asp:textbox id="txtNombreMoneda" runat="server" CssClass="normaldetalle" Width="175px" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 91px"><asp:label id="Label1" runat="server" ToolTip="Centro de Operaciones"> CO:</asp:label></TD>
								<TD style="WIDTH: 188px"><asp:textbox id="txtCentro" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 6px"></TD>
								<TD class="HeaderDetalle" style="WIDTH: 32px"><asp:label id="Label8" runat="server" ToolTip="Entidad Financiera">EF :</asp:label></TD>
								<TD style="WIDTH: 173px" colSpan="2"><asp:textbox id="txtBanco" runat="server" CssClass="normaldetalle" Width="175px" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox></TD>
								<TD class="HeaderDetalle"><asp:label id="Label4" runat="server" Width="90px">Nro Contrato :</asp:label></TD>
								<TD bgColor="#f0f0f0"><asp:textbox id="txtNroContrato" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR class="ItemDetalle" style="DISPLAY: none">
								<TD class="HeaderDetalle" style="WIDTH: 91px; HEIGHT: 26px"><asp:label id="Label5" runat="server">Concepto:</asp:label></TD>
								<TD style="HEIGHT: 26px" colSpan="7"><asp:textbox id="txtConcepto" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 91px; HEIGHT: 26px"><asp:label id="Label7" runat="server">Beneficiario:</asp:label></TD>
								<TD style="HEIGHT: 26px" colSpan="7" bgColor="#f0f0f0"><asp:textbox id="txtBeneficiario" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" style="WIDTH: 91px; HEIGHT: 36px"><asp:label id="lblProyectoA" runat="server">Proyecto:</asp:label></TD>
								<TD style="HEIGHT: 36px" colSpan="7" bgColor="#f0f0f0"><asp:textbox id="txtProyecto" runat="server" CssClass="normaldetalle" Height="32px" Width="100%"
										BorderStyle="Groove" ReadOnly="True" TextMode="MultiLine" style="Z-INDEX: 0"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 85px" bgColor="#000080" colSpan="8"><asp:label id="Label9" runat="server" CssClass="TituloPrincipalBlanco" Height="16px" Width="304px">RENOVACIONES</asp:label></TD>
							</TR>
						</TABLE>
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="770" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 84px"></TD>
											<TD style="WIDTH: 102px"></TD>
											<TD style="WIDTH: 66px"></TD>
											<TD style="WIDTH: 417px"><IMG style="WIDTH: 424px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="424"></TD>
											<TD></TD>
											<TD>
												<asp:imagebutton id="imgbtnImportar" runat="server" ImageUrl="../../imagenes/btnImportaciones/btnImportarCartaFianzaRenovaciones.gif"
													Visible="False"></asp:imagebutton></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="100%" PageSize="8" AllowPaging="True" AllowSorting="True"
										AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" ShowFooter="True">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:TemplateColumn SortExpression="idDetCF" HeaderText="NRO">
												<HeaderStyle Width="1%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:HyperLink id="hlkidItem" runat="server" ForeColor="Blue">Nro</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="FechaApertura" SortExpression="FechaApertura" HeaderText="FECHA&lt;BR&gt;RENOVACION">
												<HeaderStyle HorizontalAlign="Center" Width="8%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FechaVencimiento" SortExpression="FechaVencimiento" HeaderText="FECHA&lt;BR&gt;VENCIMIENTO">
												<HeaderStyle Width="8%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
												<HeaderStyle Width="8%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoCartaFza" SortExpression="MontoCartaFza" HeaderText="MONTO">
												<HeaderStyle Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="EstadoFza" SortExpression="EstadoFza" HeaderText="SIT.">
												<HeaderStyle Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoCargo" SortExpression="MontoCargo" HeaderText="CARGOS">
												<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Concepto" HeaderText="CONCEPTO">
												<HeaderStyle Width="45%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><INPUT id="hGridPagina" style="WIDTH: 48px; HEIGHT: 22px" type="hidden" size="2" value="0"
										name="hGridPagina" runat="server"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server"><INPUT id="hIdProyecto" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server"></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;<IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
