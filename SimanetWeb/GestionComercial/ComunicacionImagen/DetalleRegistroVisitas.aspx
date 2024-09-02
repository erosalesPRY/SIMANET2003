<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleRegistroVisitas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.DetalleRegistroVisitas" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="top" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD vAlign="top" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" vAlign="top" width="100%" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Registro de Registro de Visitas</asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left" width="100%" colSpan="3"><INPUT id="hIdCodigo" type="hidden" size="1" name="hIdCodigo" runat="server"><INPUT id="hIdOrigen" type="hidden" size="1" name="hIdOrigen" runat="server"><INPUT id="hIdTablaOrigen" type="hidden" size="1" name="hIdTablaOrigen" runat="server"><INPUT id="hIdPersonal" type="hidden" size="1" name="hIdPersonal" runat="server"><INPUT id="hIdResponsableVisita" type="hidden" size="1" name="hIdResponsableVisita" runat="server"></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="500" align="center" border="0">
										<TR>
											<TD vAlign="top" align="center">
												<TABLE class="normal" id="Table7" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
													width="450" align="center" border="1">
													<TR>
														<TD class="normal" align="left" bgColor="#000080" colSpan="5"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
														<TD class="normal" align="left"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblNombreEntidad" runat="server" CssClass="TextoBlanco"> Nombres:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtEntidad" runat="server" CssClass="normaldetalle" ReadOnly="True" Width="336px"
																MaxLength="200"></asp:textbox><asp:imagebutton id="ibtnBuscarEntidad" runat="server" CssClass="normaldetalle" CausesValidation="False"
																ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:imagebutton></TD>
														<TD class="normal"><cc2:requireddomvalidator id="rfvNombreEntidad" runat="server" ControlToValidate="txtEntidad">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblFechaVisita" runat="server" CssClass="TextoBlanco">Fecha Visita:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><ew:calendarpopup id="calFechaVisita" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
																PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True">
																<TextboxLabelStyle CssClass="normal"></TextboxLabelStyle>
																<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="White"></WeekdayStyle>
																<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="#FF8A00"></MonthHeaderStyle>
																<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Gray"
																	BackColor="AntiqueWhite"></OffMonthStyle>
																<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="White"></GoToTodayStyle>
																<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="LightGoldenrodYellow"></TodayDayStyle>
																<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="Gray"></DayHeaderStyle>
																<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="LightGray"></WeekendStyle>
																<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="#FF8A00"></SelectedDateStyle>
																<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="White"></ClearDateStyle>
																<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="White"></HolidayStyle>
															</ew:calendarpopup></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblHoraEntrada" runat="server" CssClass="TextoBlanco"> Hora Entrada:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><ew:timepicker id="tpHoraEntrada" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
																ControlDisplay="TextBoxImage">
																<ButtonStyle CssClass="normal"></ButtonStyle>
																<TextboxLabelStyle CssClass="normal"></TextboxLabelStyle>
																<ClearTimeStyle CssClass="normal" BackColor="White"></ClearTimeStyle>
																<TimeStyle CssClass="normal" BackColor="White"></TimeStyle>
																<SelectedTimeStyle CssClass="normal" BackColor="White"></SelectedTimeStyle>
															</ew:timepicker></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="Label1" runat="server" CssClass="TextoBlanco">Hora Salida:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><ew:timepicker id="tpHoraSalida" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
																ControlDisplay="TextBoxImage">
																<ButtonStyle CssClass="normal"></ButtonStyle>
																<TextboxLabelStyle CssClass="normal"></TextboxLabelStyle>
																<ClearTimeStyle CssClass="normal" BackColor="White"></ClearTimeStyle>
																<TimeStyle CssClass="normal" BackColor="White"></TimeStyle>
																<SelectedTimeStyle CssClass="normal" BackColor="White"></SelectedTimeStyle>
															</ew:timepicker></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblSeEntregoRegalo" runat="server" CssClass="TextoBlanco">Regalo?:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:checkbox id="chkSeEntregoRegalo" runat="server" CssClass="normaldetalle"></asp:checkbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco">Descripcion:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="336px" MaxLength="2000"
																TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco">Observaciones:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="336px" MaxLength="2000"
																TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" align="left" bgColor="#000080" colSpan="3"><asp:label id="Label2" runat="server" CssClass="TituloPrincipalBlanco">RESPONSABLE(S) DE VISITAS</asp:label></TD>
														<TD class="normal" vAlign="top" align="right" bgColor="#000080" colSpan="2"><asp:checkbox id="chkTieneResponsables" runat="server" CssClass="TituloPrincipalBlanco" Text="Tiene Responsables?"
																AutoPostBack="True"></asp:checkbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" align="center" colSpan="5"><asp:radiobuttonlist id="rblTipoResponsable" runat="server" CssClass="normaldetalle" AutoPostBack="True"
																RepeatDirection="Horizontal">
																<asp:ListItem Value="1" Selected="True">Registrado</asp:ListItem>
																<asp:ListItem Value="0">No Registrado</asp:ListItem>
															</asp:radiobuttonlist></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblNombreResponsable" runat="server" CssClass="TextoBlanco">Responsable:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtPersonal" runat="server" CssClass="normaldetalle" ReadOnly="True" Width="336px"
																MaxLength="80"></asp:textbox><asp:imagebutton id="ibtnBuscarPersonal" runat="server" CssClass="normaldetalle" CausesValidation="False"
																ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:imagebutton></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblCargoResponsable" runat="server" CssClass="TextoBlanco">Cargo:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:dropdownlist id="ddlbCargoResponsable" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
														<TD class="normal"><cc2:requireddomvalidator id="rfvCargoResponsable" runat="server" ControlToValidate="ddlbCargoResponsable"
																Enabled="False">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblDescripcionResponsable" runat="server" CssClass="TextoBlanco">Descripcion:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtDescripcionResponsable" runat="server" CssClass="normaldetalle" Width="336px"
																MaxLength="2000" TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblObservacionesResponsable" runat="server" CssClass="TextoBlanco">Observaciones:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtObservacionesResponsable" runat="server" CssClass="normaldetalle" Width="336px"
																MaxLength="2000" TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" align="right" colSpan="5"><asp:imagebutton id="ibtnAgregar" runat="server" CausesValidation="False" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton><asp:imagebutton id="ibtnModificar" runat="server" CausesValidation="False" ImageUrl="../../imagenes/bt_modificar.gif"></asp:imagebutton><asp:imagebutton id="ibtnEliminar" runat="server" CausesValidation="False" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" align="center" colSpan="5"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="450px" Visible="False" BorderStyle="None"
																AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
																<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
																<ItemStyle CssClass="ItemGrilla"></ItemStyle>
																<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
																<FooterStyle CssClass="FooterGrilla"></FooterStyle>
																<Columns>
																	<asp:BoundColumn Visible="False" DataField="IdResponsableVisita">
																		<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="NombreResponsable" SortExpression="NombreResponsable">
																		<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="IdPersonal"></asp:BoundColumn>
																	<asp:BoundColumn DataField="Nombre" HeaderText="NOMBRE">
																		<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="IdTablaCargoResponsable"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="IdCargoResponsable" SortExpression="IdCargoResponsable">
																		<ItemStyle HorizontalAlign="Left"></ItemStyle>
																		<FooterStyle HorizontalAlign="Right"></FooterStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="Cargo" HeaderText="CARGO">
																		<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="Descripcion" HeaderText="DESCRIPCION"></asp:BoundColumn>
																	<asp:BoundColumn DataField="Observaciones" HeaderText="OBSERVACIONES"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="Tipo"></asp:BoundColumn>
																</Columns>
																<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
															</cc1:datagridweb></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" align="center" colSpan="5"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
														<TD class="normal"></TD>
													</TR>
												</TABLE>
												<cc2:domvalidationsummary id="vSum" runat="server" ShowMessageBox="True" DisplayMode="List" EnableClientScript="False"></cc2:domvalidationsummary></TD>
											<TD vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
									<TABLE id="Table8" width="180" border="0">
										<TR>
											<TD><asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
													runat="server"></TD>
											<TD id="TdCeldaCancelar" runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
