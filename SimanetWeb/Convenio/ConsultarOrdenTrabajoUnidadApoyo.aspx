<%@ Page language="c#" Codebehind="ConsultarOrdenTrabajoUnidadApoyo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.ConsultarOrdenTrabajoUnidadApoyo" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
		<script language="javascript" type="text/javascript">
			function LlenarControlesHtml(pAprobadoTrabajo,pEjecutadoTrabajo,pEnEjecucionTrabajo,pAprobadoRepuesto,pEjecutadoRepuesto,pEnEjecucionRepuesto)
			{
				objAprobadoTrabajo=document.all["cAprobadoTrabajo"];
				objEjecutadoTrabajo=document.all["cEjecutadoTrabajo"];
				objEnEjecucionTrabajo=document.all["cEnEjecucionTrabajo"];
				objAprobadoRepuesto=document.all["cAprobadoRepuesto"];
				objEjecutadoRepuesto=document.all["cEjecutadoRepuesto"];
				objEnEjecucionRepuesto=document.all["cEnEjecucionRepuesto"];
				
				objAprobadoTrabajo.innerHTML=pAprobadoTrabajo;
				objEjecutadoTrabajo.innerHTML=pEjecutadoTrabajo;
				objEnEjecucionTrabajo.innerHTML=pEnEjecucionTrabajo;
				objAprobadoRepuesto.innerHTML=pAprobadoRepuesto;
				objEjecutadoRepuesto.innerHTML=pEjecutadoRepuesto;
				objEnEjecucionRepuesto.innerHTML=pEnEjecucionRepuesto;
				
				return;
			}
		
			function LlenarControlesWebFormNet(ptxtDescripcion,ptxtObservaciones)
			{
				MostrarDatosEnCajaTexto('txtDescripcion',ptxtDescripcion);
				MostrarDatosEnCajaTexto('txtObservaciones',ptxtObservaciones);
				return;
			}
			
			function LimpiarControlesHtml()
			{
				objAprobadoTrabajo=document.all["cAprobadoTrabajo"];
				objEjecutadoTrabajo=document.all["cEjecutadoTrabajo"];
				objEnEjecucionTrabajo=document.all["cEnEjecucionTrabajo"];
				objAprobadoRepuesto=document.all["cAprobadoRepuesto"];
				objEjecutadoRepuesto=document.all["cEjecutadoRepuesto"];
				objEnEjecucionRepuesto=document.all["cEnEjecucionRepuesto"];
				
				objAprobadoTrabajo.innerHTML='';
				objEjecutadoTrabajo.innerHTML='';
				objEnEjecucionTrabajo.innerHTML='';
				objAprobadoRepuesto.innerHTML='';
				objEjecutadoRepuesto.innerHTML='';
				objEnEjecucionRepuesto.innerHTML='';
				
				return;
			}
			
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();" style="OVERFLOW-X: hidden; OVERFLOW-Y: scroll; WIDTH: 100%">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD>
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD vAlign="top"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Periodo de Unidades de Apoyo></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Ordenes de Trabajoo</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="780" border="0">
										<tr>
											<td>
												<table id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<TD style="WIDTH: 456px; HEIGHT: 15px"><asp:label id="lblTitulo" runat="server" CssClass="TituloSecundario"> UNIDADES DE APOYO COMOPERPAC PERIODO...</asp:label></TD>
														<td style="HEIGHT: 15px" align="right"></td>
													</tr>
												</table>
											</td>
										</tr>
										<TR>
											<TD align="center" width="100%">
												<TABLE id="Table5" style="WIDTH: 100%; HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="100%"
													border="0">
													<TR>
														<TD bgColor="#f5f5f5"><IMG height="22" src="../imagenes/tab_izq.gif" width="4">
															<asp:label id="lblTituloSecundario" runat="server" CssClass="TituloSecundario"> ORDENES DE TRABAJO</asp:label></TD>
														<TD bgColor="#f5f5f5"></TD>
														<TD bgColor="#f5f5f5">&nbsp;</TD>
														<TD align="right" bgColor="#f5f5f5"><asp:imagebutton id="ibtnImprimir" runat="server" CausesValidation="False" ImageUrl="../imagenes/bt_imprimir.gif"
																Visible="False"></asp:imagebutton></TD>
														<TD align="right" width="4"><IMG height="22" src="../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="dgOrdenTrabajo" runat="server" Width="100%" RowPositionEnabled="False" RowHighlightColor="#E0E0E0"
													AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True" CssClass="HeaderGrilla" AllowPaging="True"
													PageSize="7">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="IdOrdenTrabajoUnidadApoyo" HeaderText="IdOrdenTrabajoUnidadApoyo"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
															<HeaderStyle Width="30px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn SortExpression="NroOrdenTrabajo" HeaderText="N&#186; O.T">
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<ItemTemplate>
																<asp:HyperLink id="hlkId" runat="server">OrdenTrabajo</asp:HyperLink>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="TipoCambio" HeaderText="CAMBIO" DataFormatString="{0:# ### ### ##0.000}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoAsignadoSoles" SortExpression="MontoAsignadoSoles" HeaderText="ASIGNADO NS"
															DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoAprobado" SortExpression="MontoAprobado" HeaderText="APROBADO NS"
															DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoEjecutado" SortExpression="MontoEjecutado" HeaderText="EJECUTADO NS"
															DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoEnEjecucion" SortExpression="MontoEnEjecucion" HeaderText="EN EJECUCION NS"
															DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoSaldo" SortExpression="MontoSaldo" HeaderText="SALDO NS" DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Estado" SortExpression="Estado" HeaderText="ESTADO">
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Descripcion" HeaderText="DESCRIPCION"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Observaciones" HeaderText="Observaciones"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="MontoAprobadoTrabajo" HeaderText="MontoAprobadoTrabajo"
															DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="MontoEjecutadoTrabajo" HeaderText="MontoEjecutadoTrabajo"
															DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="MontoEnEjecucionTrabajo" HeaderText="MontoEnEjecucionTrabajo"
															DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="MontoAprobadoRepuesto" HeaderText="MontoAprobadoRepuesto"
															DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="MontoEjecutadoRepuesto" HeaderText="MontoEjecutadoRepuesto"
															DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="MontoEnEjecucionRepuesto" HeaderText="MontoEnEjecucionRepuesto"
															DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<TR align="center" height="6">
											<TD><IMG style="WIDTH: 146px" height="6" src="../imagenes/spacer.gif" width="146"></TD>
										</TR>
										<TR>
											<TD align="center">
												<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR bgColor="#f5f5f5">
														<td colSpan="3"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 15px" type="hidden" size="1" name="hCodigo"
																runat="server">
														</td>
													</TR>
													<tr>
														<td width="100%" colSpan="3">
															<table id="Table8" cellSpacing="0" cellPadding="0" width="550" border="0">
																<tr>
																	<td style="WIDTH: 71px"></td>
																	<td style="WIDTH: 114px" align="center" width="114"><asp:label id="lblAprobado" runat="server" CssClass="normal">APROBADO NS</asp:label></td>
																	<td style="WIDTH: 6px"></td>
																	<td align="center" style="WIDTH: 114px"><asp:label id="lblEjecutado" runat="server" CssClass="normal">EJECUTADO NS</asp:label></td>
																	<td style="WIDTH: 1px"></td>
																	<td align="center" style="WIDTH: 114px"><asp:label id="lblEnEjecucion" runat="server" CssClass="normal" Width="100%">EN EJECUCION NS</asp:label></td>
																	<TD align="center"></TD>
																	<TD align="center"></TD>
																</tr>
																<tr>
																	<td align="left" style="WIDTH: 71px"><asp:label id="lblTrabajo" runat="server" CssClass="normal">TRABAJOS:&nbsp;</asp:label></td>
																	<td style="WIDTH: 115px" width="115">
																		<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="1">
																			<TR>
																				<TD class="TextoAzul" id="cAprobadoTrabajo" vAlign="middle" align="right" width="100%"
																					height="17">0.00</TD>
																			</TR>
																		</TABLE>
																	</td>
																	<td style="WIDTH: 6px"></td>
																	<td width="115" style="WIDTH: 115px">
																		<TABLE id="Table10" cellSpacing="1" cellPadding="1" width="100%" border="1">
																			<TR>
																				<TD class="TextoAzul" id="cEjecutadoTrabajo" vAlign="middle" align="right" width="100%"
																					height="17">0.00</TD>
																			</TR>
																		</TABLE>
																	</td>
																	<td style="WIDTH: 6px"></td>
																	<td style="WIDTH: 115px">
																		<TABLE id="Table11" cellSpacing="1" cellPadding="1" width="100%" border="1">
																			<TR>
																				<TD class="TextoAzul" id="cEnEjecucionTrabajo" vAlign="middle" align="right" width="100%"
																					height="17">0.00</TD>
																			</TR>
																		</TABLE>
																	</td>
																	<TD style="WIDTH: 6px"></TD>
																	<TD>
																		<asp:ImageButton id="ibtnTrabajo" runat="server" ImageUrl="../imagenes/BtPU_Mas.gif"></asp:ImageButton></TD>
																</tr>
																<tr>
																	<td align="left" style="WIDTH: 71px"><asp:label id="lblRepuesto" runat="server" CssClass="normal">REPUESTOS:&nbsp;</asp:label></td>
																	<td style="WIDTH: 115px" width="115">
																		<TABLE id="Table12" cellSpacing="1" cellPadding="1" width="100%" border="1">
																			<TR>
																				<TD class="TextoAzul" id="cAprobadoRepuesto" vAlign="middle" align="right" width="100%"
																					height="17">0.00</TD>
																			</TR>
																		</TABLE>
																	</td>
																	<td style="WIDTH: 6px"></td>
																	<td style="WIDTH: 115px">
																		<TABLE id="Table13" cellSpacing="1" cellPadding="1" width="100%" border="1">
																			<TR>
																				<TD class="TextoAzul" id="cEjecutadoRepuesto" vAlign="middle" align="right" width="100%"
																					height="17">0.00</TD>
																			</TR>
																		</TABLE>
																	</td>
																	<td style="WIDTH: 1px"></td>
																	<td style="WIDTH: 115px">
																		<TABLE id="Table14" cellSpacing="1" cellPadding="1" width="100%" border="1">
																			<TR>
																				<TD class="TextoAzul" id="cEnEjecucionRepuesto" vAlign="middle" align="right" width="100%"
																					height="17">0.00</TD>
																			</TR>
																		</TABLE>
																	</td>
																	<TD></TD>
																	<TD>
																		<asp:ImageButton id="ibtnRepuesto" runat="server" ImageUrl="../imagenes/BtPU_Mas.gif"></asp:ImageButton></TD>
																</tr>
															</table>
														</td>
													<TR>
														<TD><asp:label id="lblDescripcion" runat="server" CssClass="normal">DESCRIPCION:</asp:label></TD>
														<TD></TD>
														<TD><asp:label id="lblObservaciones" runat="server" CssClass="normal">OBSERVACIONES:</asp:label></TD>
													</TR>
													<TR>
														<TD width="49%"><asp:textbox id="txtDescripcion" runat="server" CssClass="TextoAzul" Width="100%" TextMode="MultiLine"
																Height="60px" ReadOnly="True"></asp:textbox></TD>
														<TD></TD>
														<td width="49%"><asp:textbox id="txtObservaciones" runat="server" CssClass="TextoAzul" Width="100%" TextMode="MultiLine"
																Height="60px" ReadOnly="True"></asp:textbox></td>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD align="center"><IMG height="6" src="../imagenes/spacer.gif" width="150"></TD>
										</TR>
										<TR>
											<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="ReemplazaHistorial(); HistorialIrAtras();"
													alt="" src="/SimanetWeb/imagenes/atras.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<script language="javascript">
				LimpiarControlesHtml();
			</script>
		</FORM>
		<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
