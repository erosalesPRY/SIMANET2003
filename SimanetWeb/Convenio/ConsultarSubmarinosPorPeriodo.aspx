<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarSubmarinosPorPeriodo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.ConsultarSubmarinosPorPeriodo" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
		<script language="javascript" src="../js/JSFrameworkSima.js"></script>
	</HEAD>
	<BODY style="OVERFLOW-Y: scroll; OVERFLOW-X: hidden; WIDTH: 100%" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD id="Region0" align="left" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD id="Region1" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Convenio></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Apoyo de Unidades Submarinas</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="720" align="center" border="0">
							<TR>
								<TD align="left" width="100%"><asp:label id="lblTitulo" runat="server" CssClass="TituloSecundario">APOYO UNIDADES</asp:label>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 678px" align="center">
									<TABLE class="normal" id="Table4" style="WIDTH: 720px" cellSpacing="0" cellPadding="0"
										width="720" border="0">
										<TR>
											<TD align="center" width="720" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="720" border="0">
													<TR>
														<TD width="140" bgColor="#f5f5f5"><IMG height="22" src="../imagenes/tab_izq.gif" width="4"></TD>
														<TD style="WIDTH: 441px" align="center" bgColor="#f5f5f5"><asp:label id="lblTituloSecundatio" runat="server" CssClass="TituloSecundario">LISTA DE PROYECTOS  - MONTOS EN NUEVOS SOLES</asp:label></TD>
														<TD align="right" width="115" bgColor="#f5f5f5"></TD>
													</TR>
													<TR id="Region2">
														<TD width="140" bgColor="#f5f5f5"></TD>
														<TD style="WIDTH: 442px" align="center" bgColor="#f5f5f5"></TD>
														<TD align="right" width="115" bgColor="#f5f5f5"><IMG id="ImgImprimir" onclick="oPrint = new SIMA.Utilitario.Helper.Dialogos();oPrint.VistaPrevia(this,Region0,Region1,Region2,Region3);"
																alt="" src="../imagenes/bt_imprimir.gif" style="CURSOR: hand"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" CssClass="HearderGrilla" PageSize="12" ShowFooter="True"
													RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True"
													AllowPaging="True" Width="720px">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle Height="10px" CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle HorizontalAlign="Right" ForeColor="Black" CssClass="FooterGrilla" VerticalAlign="Bottom"
														BackColor="#F0F0F0"></FooterStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="NRO" FooterText="TOTAL:">
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Center" VerticalAlign="Bottom"></FooterStyle>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="Nombre" HeaderText="PROYECTO">
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoAsignado" HeaderText="ASIGNADO" DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoAprobado" HeaderText="APROBADO" DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoEjecutado" HeaderText="EJECUTADO" DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoEnEjecucion" HeaderText="EN EJECUCION" DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoComprometido" HeaderText="COMPROMETIDO" DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoSaldo" HeaderText="SALDO " DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Center" ForeColor="#FFFFFF" BackColor="#335EB4" CssClass="PagerGrilla"
														Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda">lblResultado</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR id="Region3">
								<TD lign="left">
									<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="720" bgColor="#f5f5f5"
										border="0">
										<TR>
											<TD><asp:label id="lblDescripcion" runat="server" CssClass="normal">DESCRIPCION:</asp:label></TD>
											<td></td>
											<td><asp:label id="lblObservaciones" runat="server" CssClass="normal">OBSERVACIONES:</asp:label></td>
										</TR>
										<TR>
											<TD align="left"><asp:textbox id="txtDescripcion" runat="server" CssClass="normal" Width="355px" Height="50px"
													TextMode="MultiLine"></asp:textbox></TD>
											<td></td>
											<td align="right"><asp:textbox id="txtObservaciones" runat="server" CssClass="normal" Width="355px" Height="50px"
													TextMode="MultiLine"></asp:textbox></td>
										</TR>
									</TABLE>
									<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr height="5">
					<td align="center" height="5"></td>
				</tr>
			</table>
			</TD></TR></TABLE></form>
		<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</BODY>
</HTML>
