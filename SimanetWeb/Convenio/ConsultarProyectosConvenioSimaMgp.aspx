<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarProyectosConvenioSimaMgp.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.ConsultarProyectosConvenioSimaMgp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<! Begin Smooth Blend Pages IN and OUT -->
		<META content="BlendTrans(Duration=0.4)" http-equiv="Page-Enter">
		<META content="BlendTrans(Duration=0.4)" http-equiv="Site-Exit">
		<! End Smooth Blend Pages IN and OUT -->
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<!--<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>-->
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<base target="_self">
	</HEAD>
	<BODY style="OVERFLOW-X: hidden; OVERFLOW-Y: scroll; WIDTH: 100%" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<script type="text/javascript" src="../amcolumn/swfobject.js"></script>
			<table cellPadding="0" width="100%" align="center" border="0" id="Table1" cellSpacing="0">
				<TR>
					<TD align="left" width="100%">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Convenio></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Actividades del Convenio</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD align="left" width="100%">
									<TABLE class="tabla" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR width="100%">
											<td width="100%" colSpan="6">
											</td>
										</TR>
										<TR bgColor="#f5f5f5">
											<TD colSpan="6" align="left">
												<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD style="HEIGHT: 18px">
															<asp:label id="Label1" runat="server" CssClass="normaldetalle"> CONVENIO:</asp:label>
															<asp:textbox style="Z-INDEX: 0" id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="100%"
																ReadOnly="True" TextMode="MultiLine" Height="30px"></asp:textbox></TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table7" border="0" cellSpacing="0" cellPadding="0" width="40%">
																<TR>
																	<TD>
																		<P align="center">
																			<asp:label style="Z-INDEX: 0" id="Label4" runat="server" CssClass="normaldetalle">MARCO</asp:label></P>
																	</TD>
																	<TD>
																		<P align="center">
																			<asp:label style="Z-INDEX: 0" id="Label5" runat="server" CssClass="normaldetalle">PAGADO</asp:label></P>
																	</TD>
																	<TD>
																		<P align="center">
																			<asp:label style="Z-INDEX: 0" id="Label6" runat="server" CssClass="normaldetalle">EJECUTADO SIMA</asp:label></P>
																	</TD>
																	<TD>
																		<P align="center">
																			<asp:label style="Z-INDEX: 0" id="Label7" runat="server" CssClass="normaldetalle">CONTRA CARTA FIANZA</asp:label></P>
																	</TD>
																</TR>
																<TR>
																	<TD>
																		<P align="center">
																			<asp:textbox style="Z-INDEX: 0" id="txtMarco" runat="server" CssClass="normaldetalle" Width="90px"
																				ReadOnly="True"></asp:textbox></P>
																	</TD>
																	<TD>
																		<P align="center">
																			<asp:textbox style="Z-INDEX: 0" id="txtPagado" runat="server" CssClass="normaldetalle" Width="90px"
																				ReadOnly="True"></asp:textbox></P>
																	</TD>
																	<TD>
																		<P align="center">
																			<asp:textbox style="Z-INDEX: 0" id="txtEjecutado" runat="server" CssClass="normaldetalle" Width="90px"
																				ReadOnly="True"></asp:textbox></P>
																	</TD>
																	<TD>
																		<P align="center">
																			<asp:textbox style="Z-INDEX: 0" id="txtCartaFianza" runat="server" CssClass="normaldetalle" Width="90px"
																				ReadOnly="True"></asp:textbox></P>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="left">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD align="center" width="100%" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#f5f5f5" colSpan="4" align="center">
															<asp:label style="Z-INDEX: 0" id="lblTituloSecundatio" runat="server" CssClass="TituloSecundario"> RESUMEN CONVENIO:</asp:label>&nbsp;
															<asp:label style="Z-INDEX: 0" id="lblTitulo" runat="server" CssClass="TituloSecundario"> CONVENIOS COMOPERPAC</asp:label></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="dgProyectoConvenioSimaMgp" runat="server" CssClass="HearderGrilla" Width="100%"
													ShowFooter="True" RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
													AllowSorting="True" PageSize="7">
													<PagerStyle HorizontalAlign="Center" ForeColor="White" BackColor="#335EB4" CssClass="PagerGrilla"
														Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla" VerticalAlign="Bottom"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="IdProyectoConvenio" HeaderText="IdProyectoConvenio"></asp:BoundColumn>
														<asp:TemplateColumn SortExpression="NroProyecto" HeaderText="NRO" FooterText="TOTAL:">
															<HeaderStyle Width="1%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Center" VerticalAlign="Bottom"></FooterStyle>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCION">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoAsignado" SortExpression="MontoAsignado" HeaderText="ASIGNADO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoAprobado" SortExpression="MontoAprobado" HeaderText="APROBADO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoPagado" SortExpression="MontoPagado" HeaderText="PAGADO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoEjecutado" SortExpression="MontoEjecutado" HeaderText="TERMINADO"
															DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoEnEjecucion" SortExpression="MontoEnEjecucion" HeaderText="EN EJECUCION"
															DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="avanceFisico" SortExpression="avanceFisico" HeaderText="AVANCE F&#205;SICO"
															DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="montosaldo" SortExpression="montosaldo" HeaderText="SALDO POR APROBAR"
															DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn Visible="False">
															<HeaderStyle Width="1%"></HeaderStyle>
															<ItemTemplate>
																<asp:Image style="Z-INDEX: 0" id="imgContrato" runat="server" Height="18px" ImageUrl="../imagenes/ley1.gif"></asp:Image>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="3%"></HeaderStyle>
															<ItemTemplate>
																<asp:Image style="Z-INDEX: 0" id="imgAct" runat="server" Height="18px" ImageUrl="../imagenes/nota.gif"></asp:Image>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:Image style="Z-INDEX: 0" id="imgFicha" runat="server" Height="18px" Visible="False" ImageUrl="../imagenes/GridView.gif"
																	ToolTip="Ficha Técnica"></asp:Image>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<HeaderStyle Height="10px" CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda">lblResultado</asp:label></TD>
										</TR>
									</TABLE>
									<asp:label style="Z-INDEX: 0" id="Label2" runat="server" CssClass="normaldetalle">OBSERVACIONES:</asp:label>
								</TD>
							</TR>
							<TR>
								<TD align="left">
									<asp:textbox style="Z-INDEX: 0" id="txtObservacionesConvenio" runat="server" CssClass="normaldetalle"
										Width="100%" ReadOnly="True" TextMode="MultiLine" Height="50px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="left"><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt=""
										src="../imagenes/atras.gif"></TD>
							</TR>
							<TR>
								<TD align="left">
									<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f5f5f5"
										border="0">
										<TR>
											<TD style="VISIBILITY: hidden"><asp:hyperlink id="hlkRecibido" runat="server" Font-Size="XX-Small">RECIBIDO NS</asp:hyperlink></TD>
											<TD width="10"></TD>
											<TD></TD>
											<td></td>
											<td><asp:label id="lblObservaciones" runat="server" CssClass="normal" Visible="False">OBSERVACIONES:</asp:label></td>
										</TR>
										<TR>
											<TD vAlign="top" style="TEXT-ALIGN: right; VISIBILITY: hidden"><asp:label id="lblDbRecibido" runat="server" CssClass="TextoAzulNegrita" Width="90px">0.00</asp:label></TD>
											<TD></TD>
											<TD rowSpan="3"></TD>
											<td rowspan="3"></td>
											<td rowSpan="3" style="VISIBILITY: hidden"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="700px" ReadOnly="True"
													TextMode="MultiLine" Height="54px"></asp:textbox></td>
										</TR>
										<TR>
											<TD style="VISIBILITY: hidden"><asp:label id="lblPorCobrar" runat="server" CssClass="normal">Por Cobrar NS</asp:label></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD vAlign="top" style="TEXT-ALIGN: right; VISIBILITY: hidden" align="left"><asp:label id="lblDbPorCobrar" runat="server" CssClass="TextoAzulNegrita" Width="90px" BorderStyle="None">0.00</asp:label></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<asp:label style="Z-INDEX: 0" id="lblDescripcion" runat="server" CssClass="normal" Visible="False">DESCRIPCION:</asp:label>
					</TD>
				</TR>
				<tr height="5">
					<td height="5" style="VISIBILITY: hidden"><asp:textbox id="txtDescripcionProyecto" runat="server" CssClass="normaldetalle" Width="310px"
							ReadOnly="True" TextMode="MultiLine" Height="54px" style="Z-INDEX: 0"></asp:textbox><asp:label id="lblEstado" runat="server" CssClass="normal" style="Z-INDEX: 0">ESTADO:&nbsp;</asp:label><asp:textbox id="txtEstado" runat="server" CssClass="normaldetalle" ReadOnly="True" style="Z-INDEX: 0"></asp:textbox><asp:label id="lblSituacionEconomica" runat="server" CssClass="normal" style="Z-INDEX: 0">SITUACION ECONOMICA:&nbsp;</asp:label><asp:textbox id="txtSituacionEconomica" runat="server" CssClass="normaldetalle" ReadOnly="True"
							style="Z-INDEX: 0"></asp:textbox><asp:label id="lblFechaVencimiento" runat="server" CssClass="normal" style="Z-INDEX: 0">VENCIMIENTO:&nbsp;</asp:label><asp:textbox id="txtFechaVencimiento" runat="server" CssClass="normaldetalle" ReadOnly="True"
							style="Z-INDEX: 0"></asp:textbox></td>
				</tr>
			</table>
			</TD></TR></TABLE>
		</form>
		<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</BODY>
</HTML>
