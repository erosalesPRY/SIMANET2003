<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ActividadesOrdenTrabajoComoperpac.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.ActividadesOrdenTrabajoComoperpac" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
		<script language="javascript" type="text/javascript">
		
			function LimpiarControlesHtml()
			{
				objAsignado=document.all["cAsignado"];
				objEjecutado=document.all["cEjecutado"];
				objEnEjecucion=document.all["cEnEjecucion"];
				
				objAsignado.innerHTML='';
				objEjecutado.innerHTML='';
				objEnEjecucion.innerHTML='';

				return;
			}
			
			function LlenarControlesHtml(pAsignado,pEjecutado,pEnEjecucion)
			{
				objAsignado=document.all["cAsignado"];
				objEjecutado=document.all["cEjecutado"];
				objEnEjecucion=document.all["cEnEjecucion"];
				
				objAsignado.innerHTML=pAsignado;
				objEjecutado.innerHTML=pEjecutado;
				objEnEjecucion.innerHTML=pEnEjecucion;
				return;
			}
			
			function LlenarControlesWebFormNet(ptxtDescripcion,ptxtObservaciones)
			{
				MostrarDatosEnCajaTexto('txtDescripcion',ptxtDescripcion);
				MostrarDatosEnCajaTexto('txtObservaciones',ptxtObservaciones);
				return;
			}
			
			function LlenarControlTxtDocumento(ptxtDocumento)
			{
				MostrarDatosEnCajaTexto('txtDocumento',ptxtDocumento);
				return true;
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
								<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Periodo de Unidades de Apoyo></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> ACTIVIDADES DE LA O.T.</asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="775" align="center" border="0">
										<TR width="100%">
											<td>
												<table id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
													<TR>
														<TD class="TituloPrincipal" style="WIDTH: 443px" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> ORDEN DE TRABAJO:</asp:label></TD>
														<td align="right"></td>
													</TR>
												</table>
											</td>
										</TR>
										<TR>
											<TD align="center">
												<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD align="center" width="100%">
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD style="WIDTH: 7px" vAlign="middle" align="right" bgColor="#f5f5f5"><IMG height="22" src="../imagenes/tab_izq.gif" width="4"></TD>
																	<TD style="WIDTH: 75px" align="right" bgColor="#f5f5f5"><asp:label id="lblActividad" runat="server" CssClass="normal">ACTIVIDAD:&nbsp;</asp:label></TD>
																	<TD bgColor="#f5f5f5">&nbsp;
																		<asp:dropdownlist id="ddlbActividad" runat="server" CssClass="normal" AutoPostBack="True"></asp:dropdownlist></TD>
																	<TD align="right" bgColor="#f5f5f5"><asp:imagebutton id="ibtnImprimir" runat="server" Visible="False" ImageUrl="../imagenes/bt_imprimir.gif"
																			CausesValidation="False"></asp:imagebutton></TD>
																	<TD align="right" width="4"><IMG height="22" src="../imagenes/tab_der.gif" width="4"></TD>
																</TR>
															</TABLE>
															<cc1:datagridweb id="dgActividad" runat="server" CssClass="HeaderGrilla" PageSize="7" RowPositionEnabled="False"
																RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True"
																Width="780px" ShowFooter="True">
																<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
																<ItemStyle CssClass="ItemGrilla"></ItemStyle>
																<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
																<FooterStyle CssClass="FooterGrilla"></FooterStyle>
																<Columns>
																	<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
																		<HeaderStyle Width="30px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="DocumentoAprovacion" SortExpression="DocumentoAprovacion" HeaderText="DOCUMENTO DE APROBACION">
																		<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="NroValorizacion" SortExpression="NroValorizacion" HeaderText="VALORIZACION">
																		<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="UnidadNaval" SortExpression="UnidadNaval" HeaderText="UNIDAD NAVAL">
																		<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="FechaInicio" SortExpression="FechaInicio" HeaderText="FECHA INICIO" DataFormatString="{0:dd-MM-yyyy}">
																		<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="FechaTermino" SortExpression="FechaTermino" HeaderText="FECHA TERMINO"
																		DataFormatString="{0:dd-MM-yyyy}">
																		<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="PorcAvanceFisico" SortExpression="PorcAvanceFisico" HeaderText="A.F ( % )"
																		DataFormatString="{0:###,##0.00}">
																		<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="MontoAsignado" SortExpression="MontoAsignado" HeaderText="MontoAsignado"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="MontoEjecutado" SortExpression="MontoEjecutado" HeaderText="MontoEjecutado"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="MontoEnEjecucion" SortExpression="MontoEnEjecucion" HeaderText="MontoEnEjecucion"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="Documento" HeaderText="Documento"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="Descripcion" HeaderText="Descripcion"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="Observaciones" HeaderText="Observaciones"></asp:BoundColumn>
																</Columns>
																<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
															</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
													</TR>
													<TR align="center" height="6">
														<TD><IMG style="WIDTH: 159px; HEIGHT: 6px" height="6" src="../imagenes/spacer.gif" width="159">
														</TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<td width="100%" colSpan="3">
																	</td>
																</TR>
																<tr>
																	<td width="25%">
																		<table id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<tr align="right">
																				<td align="left" width="100"><asp:label id="lblMontoAsignado" runat="server" CssClass="normal" Width="100%">ASIGNADO NS:</asp:label></td>
																				<td>
																					<table id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="1">
																						<tr>
																							<td class="TextoAzul" id="cAsignado" align="right" height="17">s</td>
																						</tr>
																					</table>
																				</td>
																			</tr>
																			<tr>
																				<td align="left"><asp:label id="lblMontoEjecutado" runat="server" CssClass="normal" Width="100%"> EJECUTADO NS:</asp:label></td>
																				<td>
																					<table id="Table12" cellSpacing="0" cellPadding="0" width="100%" border="1">
																						<tr>
																							<td class="TextoAzul" id="cEjecutado" align="right" height="17">a</td>
																						</tr>
																					</table>
																				</td>
																			</tr>
																			<tr>
																				<td align="left"><asp:label id="lblEnEjecucion" runat="server" CssClass="normal" Width="100%">EN EJECUCION NS:</asp:label></td>
																				<td>
																					<table id="Table13" cellSpacing="0" cellPadding="0" width="100%" border="1">
																						<tr>
																							<td class="TextoAzul" id="cEnEjecucion" align="right" height="17">f</td>
																						</tr>
																					</table>
																				</td>
																			</tr>
																		</table>
																	</td>
																	<td></td>
																	<td vAlign="top">
																		<table id="Table15" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<tr>
																				<td><asp:label id="lblDocumento" runat="server" CssClass="normal">DOCUMENTO</asp:label></td>
																			</tr>
																			<tr>
																				<td><asp:textbox id="txtDocumento" runat="server" CssClass="TextoAzul" Width="100%" Height="43px"
																						TextMode="MultiLine" ReadOnly="True"></asp:textbox></td>
																			</tr>
																		</table>
																	</td>
																</tr>
																<tr>
																	<td width="100%" colSpan="3">
																		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<TR>
																				<TD><asp:label id="lblDescripcion" runat="server" CssClass="normal">DESCRIPCION:</asp:label></TD>
																				<TD></TD>
																				<TD><asp:label id="lblObservaciones" runat="server" CssClass="normal">OBSERVACIONES:</asp:label></TD>
																			</TR>
																			<TR>
																				<TD width="49%"><asp:textbox id="txtDescripcion" runat="server" CssClass="TextoAzul" Width="100%" Height="45px"
																						TextMode="MultiLine" ReadOnly="True"></asp:textbox></TD>
																				<TD width="2%"></TD>
																				<TD width="49%"><asp:textbox id="txtObservaciones" runat="server" CssClass="TextoAzul" Width="100%" Height="45px"
																						TextMode="MultiLine" ReadOnly="True"></asp:textbox></TD>
																			</TR>
																		</table>
																	</td>
																</tr>
															</TABLE>
															<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif">
														</TD>
													</TR>
												</TABLE>
												<IMG style="WIDTH: 50px" height="8" src="../imagenes/spacer.gif" width="50">
											</TD>
										</TR>
										<TR>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<script language="javascript" type="text/javascript">
			  LimpiarControlesHtml();
						</script>
					</FORM>
					<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
					</SCRIPT>
				</td>
			</tr>
		</table>
	</body>
</HTML>
