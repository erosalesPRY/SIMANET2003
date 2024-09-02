<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleAccionDeControlPosterior.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Auditoria.DetalleAccionDeControlPosterior" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD>
						<TABLE cellSpacing="0" cellPadding="0" width="550" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión de Control ></asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle de Acciones de Control Posterior </asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="tabla" id="Table2" cellSpacing="0" cellPadding="0" width="300" bgColor="#f5f5f5"
										border="0">
										<TR>
											<TD class="SmallFont">
												<asp:label id="Label1" runat="server" CssClass="normal">Periodo</asp:label></TD>
											<TD class="SmallFont">
												<asp:label id="lblAccion" runat="server" CssClass="normal">Acción</asp:label></TD>
										</TR>
										<TR>
											<TD class="combos" style="HEIGHT: 16px">
												<asp:dropdownlist id="ddlbPeriodoFiltro" runat="server" CssClass="normal" AutoPostBack="True" Width="96px"></asp:dropdownlist></TD>
											<TD class="combos" style="HEIGHT: 16px">
												<asp:dropdownlist id="ddlbAccion" runat="server" CssClass="normal" AutoPostBack="True" Width="96px"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="left">
									<TABLE id="tDetalle" cellSpacing="0" cellPadding="0" width="550" align="center" border="0"
										runat="server" DESIGNTIMEDRAGDROP="1090">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD style="HEIGHT: 108px">
												<TABLE class="normal" id="Table3" style="WIDTH: 469px; HEIGHT: 306px" cellSpacing="0" cellPadding="0"
													width="469" align="center" border="1" borderColor="#ffffff">
													<TR>
														<TD class="normal" align="center" colSpan="6">
															<asp:label id="lblMensaje" runat="server" CssClass="normal" DESIGNTIMEDRAGDROP="162"></asp:label></TD>
													</TR>
													<TR>
														<TD class="normal" bgColor="#000080" colSpan="5">
															<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"> ACCIONES DE CONTROL POSTERIOR </asp:label></TD>
													</TR>
													<TR>
														<TD class="normal" bgColor="#335eb4">
															<asp:label id="lblCodigo" runat="server" CssClass="TextoBlanco">Codigo:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd">
															<asp:textbox id="txtCodigo" runat="server" CssClass="normaldetalle" MaxLength="15" Width="96px"></asp:textbox></TD>
														<TD class="normal" style="WIDTH: 8px">
															<cc1:RequiredDomValidator id="rfvCodigo" runat="server" ControlToValidate="txtCodigo">*</cc1:RequiredDomValidator></TD>
														<TD class="normal" bgColor="#335eb4">
															<asp:label id="lblPeriodo" runat="server" CssClass="TextoBlanco">Periodo:</asp:label></TD>
														<TD align="left" colSpan="1" bgColor="#dddddd">
															<asp:dropdownlist id="ddlbPeriodo" runat="server" CssClass="normaldetalle" Width="96px"></asp:dropdownlist></TD>
														<TD>
															<cc1:RequiredDomValidator id="rfvPeriodo" runat="server" ControlToValidate="ddlbPeriodo" InitialValue="%">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" bgColor="#335eb4">
															<asp:label id="lblUnidadMedida" runat="server" CssClass="TextoBlanco" Width="88px">Unidad de Medida:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0">
															<asp:dropdownlist id="ddlbUnidadMedida" runat="server" CssClass="normaldetalle" Width="150px"></asp:dropdownlist></TD>
														<TD class="normal" style="WIDTH: 8px">
															<cc1:RequiredDomValidator id="rfvUnidadMedida" runat="server" ControlToValidate="ddlbUnidadMedida" InitialValue="%">*</cc1:RequiredDomValidator></TD>
														<TD class="normal" bgColor="#335eb4">
															<asp:label id="lblPorcentajeAvance" runat="server" CssClass="TextoBlanco">% de Avance:</asp:label></TD>
														<TD align="left" bgColor="#f0f0f0">
															<ew:NumericBox id="txtPorcentajeAvance" runat="server" CssClass="normaldetalle" Width="50px" Enabled="False"
																TextAlign="Right"></ew:NumericBox></TD>
														<TD>
															<cc1:RequiredDomValidator id="rfvPorcentajeAvance" runat="server" ControlToValidate="txtPorcentajeAvance">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" bgColor="#335eb4">
															<asp:label id="lblDenominacion" runat="server" CssClass="TextoBlanco">Denominación:</asp:label></TD>
														<TD class="normal" colSpan="4" bgColor="#dddddd">
															<asp:textbox id="txtDenominacion" runat="server" CssClass="normaldetalle" MaxLength="1500" Width="500px"
																TextMode="MultiLine" Height="54px"></asp:textbox></TD>
														<TD class="normal">
															<cc1:RequiredDomValidator id="rfvDenominacion" runat="server" ControlToValidate="txtDenominacion">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" bgColor="#335eb4">
															<asp:label id="lblObservacion" runat="server" CssClass="TextoBlanco">Observación:</asp:label></TD>
														<TD class="normal" colSpan="4" bgColor="#f0f0f0">
															<asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" MaxLength="1500" Width="500px"
																TextMode="MultiLine" Height="54px"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" bgColor="#000080" colSpan="3" align="center">
															<asp:label id="lblMetas" runat="server" CssClass="TituloPrincipalBlanco">Metas</asp:label>
														</TD>
														<TD class="normal" bgColor="#000080" colSpan="2" align="center">
															<asp:label id="lblCronograma" runat="server" CssClass="TituloPrincipalBlanco">Cronograma de Ejecución</asp:label>
														</TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 91px" bgColor="#335eb4">
															<P>&nbsp;</P>
															<P align="center">
																<asp:Button id="btnAgregarMeta" runat="server" CausesValidation="False" Text="Agregar"></asp:Button></P>
															<P>&nbsp;</P>
														</TD>
														<TD class="normal" colSpan="2" bgColor="#dddddd">
															<div style="OVERFLOW: auto; WIDTH: 260px; HEIGHT: 70px">
																<asp:datagrid id="grid" runat="server" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True"
																	Height="88px" Width="240px" CssClass="normaldetalle">
																	<ItemStyle CssClass="ItemGrilla"></ItemStyle>
																	<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
																	<FooterStyle CssClass="FooterGrilla"></FooterStyle>
																	<Columns>
																		<asp:BoundColumn Visible="False" DataField="IdProgramacionAuditoriaMeta" SortExpression="IdProgramacionAuditoriaMeta"
																			HeaderText="IdProgramacionAuditoriaMeta"></asp:BoundColumn>
																		<asp:TemplateColumn HeaderText="FECHA">
																			<HeaderStyle Width="100%"></HeaderStyle>
																			<ItemTemplate>
																				<ew:calendarpopup id="calFecha" runat="server" CssClass="combos" Width="72px" ImageUrl="../imagenes/BtPU_Mas.gif"
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
																				</ew:calendarpopup>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="AVANCE">
																			<ItemTemplate>
																				<ew:numericbox id="txt" runat="server" CssClass="normal" Width="61px" MaxLength="3" TextAlign="Right"
																					RealNumber="False" PositiveNumber="True"></ew:numericbox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Eliminar">
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<asp:CheckBox id="cbxEliminar" runat="server" AutoPostBack="True"></asp:CheckBox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																	<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
																</asp:datagrid>
															</div>
														</TD>
														<TD colspan="2" bgColor="#dddddd">
															<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="0">
																<TR>
																	<TD>
																		<asp:checkbox id="cbxEnero" runat="server" CssClass="normaldetalle" Text="E" ToolTip="Enero"></asp:checkbox></TD>
																	<TD>
																		<asp:checkbox id="cbxFebrero" runat="server" CssClass="normaldetalle" Text="F" ToolTip="Febrero"></asp:checkbox></TD>
																	<TD>
																		<asp:checkbox id="cbxMarzo" runat="server" CssClass="normaldetalle" Text="M" ToolTip="Marzo"></asp:checkbox></TD>
																	<TD>
																		<asp:checkbox id="cbxAbril" runat="server" CssClass="normaldetalle" Text="A" ToolTip="Abril"></asp:checkbox></TD>
																	<TD>
																		<asp:checkbox id="cbxMayo" runat="server" CssClass="normaldetalle" Text="M" ToolTip="Mayo"></asp:checkbox></TD>
																	<TD>
																		<asp:checkbox id="cbxJunio" runat="server" CssClass="normaldetalle" Text="J" ToolTip="Junio"></asp:checkbox></TD>
																	<TD>
																		<asp:checkbox id="cbxJulio" runat="server" CssClass="normaldetalle" Text="J" ToolTip="Julio"></asp:checkbox></TD>
																	<TD>
																		<asp:checkbox id="cbxAgosto" runat="server" CssClass="normaldetalle" Text="A" ToolTip="Agosto"></asp:checkbox></TD>
																	<TD>
																		<asp:checkbox id="cbxSeptiembre" runat="server" CssClass="normaldetalle" Text="S" ToolTip="Septiembre"></asp:checkbox></TD>
																	<TD>
																		<asp:checkbox id="cbxOctubre" runat="server" CssClass="normaldetalle" Text="O" ToolTip="Octubre"></asp:checkbox></TD>
																	<TD>
																		<asp:checkbox id="cbxNoviembre" runat="server" CssClass="normaldetalle" Text="N" ToolTip="Noviembre"></asp:checkbox></TD>
																	<TD>
																		<asp:checkbox id="cbxDiciembre" runat="server" CssClass="normaldetalle" Text="D" ToolTip="Diciembre"></asp:checkbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="normal" align="right" colSpan="5">
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" border="1" borderColor="#ffffff">
																<TR>
																	<TD>
																		<asp:imagebutton id="ibtnAceptar" runat="server" Height="22px" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
																	<TD>
																		<asp:imagebutton id="ibtnCancelar" runat="server" Height="22px" CausesValidation="False" ImageUrl="../imagenes/bt_cancelar.gif"></asp:imagebutton></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
												<cc1:DomValidationSummary id="vSum" runat="server" Width="88px" Height="24px" EnableClientScript="False" DisplayMode="List"
													ShowMessageBox="True"></cc1:DomValidationSummary>
											</TD>
											<TD style="HEIGHT: 108px" vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
									<asp:imagebutton id="ibtnAtras" runat="server" CausesValidation="False" ImageUrl="../imagenes/atras.gif"></asp:imagebutton>
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
	</body>
</HTML>
