<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="AdministracionActividadesConvenio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.AdministracionActividadesConvenio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
		<script language="javascript" type="text/javascript">

			function LlenarControlesWebFormNet(ptxtDocumentoAprovacion,ptxtObservaciones)
			{
				MostrarDatosEnCajaTexto('txtDocumentoAprovacion',ptxtDocumentoAprovacion);
				MostrarDatosEnCajaTexto('txtObservaciones',ptxtObservaciones);
				return;
			}
		
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td width="100%">
					<FORM id="Form1" method="post" runat="server">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR vAlign="baseline" align="left">
								<TD width="100%"><uc1:header id="Header1" runat="server"></uc1:header></TD>
							</TR>
							<tr>
								<TD vAlign="top" width="99%"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
							</tr>
							<TR>
								<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Producción >  Consultar Actividades del Convenio > Consultar Orden de Trabajo ></asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 12px" align="center">
									<TABLE id="Table6" style="HEIGHT: 16px" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD>
												<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal" Width="770px" Height="8px"> ORDEN DE TRABAJO</asp:label></TD>
										</TR>
									</TABLE>
									<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD bgColor="#f5f5f5">
												<asp:label id="lblActividad" runat="server" CssClass="normal">ACTIVIDAD:&nbsp;</asp:label>
												<asp:dropdownlist id="ddlbActividad" runat="server" CssClass="normal" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD align="right" bgColor="#f5f5f5">
												<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_exportar.GIF"></asp:imagebutton></TD>
										</TR>
									</TABLE>
									<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD align="center">
												<cc1:datagridweb id="dgActividad" runat="server" CssClass="HeaderGrilla" PageSize="7" AllowSorting="True"
													AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" Width="778px"
													ShowFooter="True">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn DataField="databound" HeaderText="VAL"></asp:BoundColumn>
														<asp:BoundColumn DataField="databound" ReadOnly="True" HeaderText="ALIAS"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="OT"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="SIMAC SAE">
															<HeaderStyle HorizontalAlign="Justify"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="F.INICIO"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="% AVANCE"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="F.TERMINO"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="M.APROBADO"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="M.EJECUTADO"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="M.PROCESO"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="%A.F."></asp:BoundColumn>
														<asp:BoundColumn HeaderText="AV.ECO.FINAL"></asp:BoundColumn>
													</Columns>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR>
											<TD align="center">
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
									</TABLE>
									<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD style="WIDTH: 378px"></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 378px">
												<asp:label id="lblDocumentoAprovacion" runat="server" CssClass="normal">DOCUMENTO DE APROBACION</asp:label></TD>
											<TD>
												<asp:label id="lblObservaciones" runat="server" CssClass="normal">OBSERVACIONES:</asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 378px">
												<asp:textbox id="txtDocumentoAprovacion" runat="server" CssClass="TextoAzul" Width="376px" ReadOnly="True"
													TextMode="MultiLine" Height="45px"></asp:textbox></TD>
											<TD>
												<asp:textbox id="txtObservaciones" runat="server" CssClass="TextoAzul" Width="100%" ReadOnly="True"
													TextMode="MultiLine" Height="45px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 378px"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif"></TD>
											<TD><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" runat="server"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
				</td>
			</tr>
		</table>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
