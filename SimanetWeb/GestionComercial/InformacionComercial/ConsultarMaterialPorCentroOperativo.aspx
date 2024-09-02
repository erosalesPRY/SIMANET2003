<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="ConsultarMaterialPorCentroOperativo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InformacionComercial.ConsultarMaterialPorCentroOperativo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarMaterialPorCentroOperativo</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD><uc1:header style="Z-INDEX: 0" id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu style="Z-INDEX: 0" id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="Commands" colSpan="3">&nbsp;
									<asp:label id="lblRuta_Pagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Comercial > Información Comercial > </asp:label><asp:label id="lblPage" runat="server"> Consulta Material Por Centro Operativo</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" colSpan="3" align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal">CONSULTA MATERIALES POR CENTRO OPERATIVO</asp:label></TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="lblNombreCentroOperativo" runat="server" CssClass="TituloSecundario"></asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center">
									<TABLE id="Table3" class="normal" border="0" cellSpacing="0" cellPadding="0" width="550">
										<TR>
											<TD width="100%" colSpan="3" align="right">
												<TABLE id="Table2" class="tabla" border="0" cellSpacing="0" cellPadding="0" width="620"
													bgColor="#f5f5f5" align="center">
													<TR bgColor="#ffffff">
														<TD style="HEIGHT: 8px" class="combos" width="121"><IMG src="../../imagenes/TitFiltros.gif" width="82" height="14"></TD>
														<TD style="WIDTH: 169px; HEIGHT: 8px" class="combos" width="169"></TD>
														<TD style="WIDTH: 170px; HEIGHT: 8px" class="combos" width="170"></TD>
														<TD style="HEIGHT: 8px" class="combos" width="171" align="right"></TD>
													</TR>
													<TR>
														<TD></TD>
														<TD><asp:label id="lblFechaInicio" runat="server" CssClass="normal">Fecha de Inicio</asp:label><ew:calendarpopup id="CalFechaInicio" runat="server" CssClass="normaldetalle" NullableLabelText="Seleccione una fecha:"
																AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True" ImageUrl="../../imagenes/BtPU_Mas.gif" Width="72px" GoToTodayText="Hoy :"
																MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar">
																<TextboxLabelStyle CssClass="NormalDetalle"></TextboxLabelStyle>
																<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="White"></WeekdayStyle>
																<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
																	BackColor="Navy"></MonthHeaderStyle>
																<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
																	BackColor="White"></OffMonthStyle>
																<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
																	BackColor="#F0F0F0"></GoToTodayStyle>
																<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
																	ForeColor="#335EB4" BackColor="LightSteelBlue"></TodayDayStyle>
																<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
																	BackColor="#335EB4"></DayHeaderStyle>
																<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
																	ForeColor="IndianRed" BackColor="White"></WeekendStyle>
																<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
																	BackColor="CornflowerBlue"></SelectedDateStyle>
																<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="White"></ClearDateStyle>
																<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="White"></HolidayStyle>
															</ew:calendarpopup></TD>
														<TD class="Small"><asp:label id="lblFechaFin" runat="server" CssClass="normal">Fecha de Fin</asp:label><ew:calendarpopup id="CalFechaFin" runat="server" CssClass="normaldetalle" NullableLabelText="Seleccione una fecha:"
																AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True" ImageUrl="../../imagenes/BtPU_Mas.gif" Width="72px" GoToTodayText="Hoy :"
																MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar">
																<TextboxLabelStyle CssClass="NormalDetalle"></TextboxLabelStyle>
																<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="White"></WeekdayStyle>
																<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
																	BackColor="Navy"></MonthHeaderStyle>
																<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
																	BackColor="White"></OffMonthStyle>
																<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
																	BackColor="#F0F0F0"></GoToTodayStyle>
																<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
																	ForeColor="#335EB4" BackColor="LightSteelBlue"></TodayDayStyle>
																<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
																	BackColor="#335EB4"></DayHeaderStyle>
																<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
																	ForeColor="IndianRed" BackColor="White"></WeekendStyle>
																<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
																	BackColor="CornflowerBlue"></SelectedDateStyle>
																<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="White"></ClearDateStyle>
																<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="White"></HolidayStyle>
															</ew:calendarpopup></TD>
														<TD><asp:imagebutton id="ibtnConsultar" runat="server" ImageUrl="../../imagenes/ibtnConsultarCliente.gif"
																ImageAlign="Left"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 2px" class="SmallFont" bgColor="#f5f5f5" width="100%" colSpan="3"
												align="right"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD width="100%" colSpan="3" align="center"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" AllowSorting="True"
													AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" PageSize="4">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="NroCO">
															<HeaderStyle Width="10%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FchEms" SortExpression="FchEms" HeaderText="EMISION">
															<HeaderStyle Width="15%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Mat" SortExpression="Mat" HeaderText="MATERIAL">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="UndMdd" SortExpression="UndMdd" HeaderText="MEDIDA">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Dcp" SortExpression="Dcp" HeaderText="DESCRIPCION">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="StkGrv" SortExpression="StkGrv" HeaderText="STK GRV">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PrcPmdSolGrv" SortExpression="PrcPmdSolGrv" HeaderText="PRC PMD SOL GRV">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="StkExn" SortExpression="StkExn" HeaderText="STK EXN">
															<HeaderStyle Width="15%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PrcPmdSolExn" SortExpression="PrcPmdSolExn" HeaderText="PRC PMD SOL EXN">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PrcUltCmpSol" SortExpression="PrcUltCmpSol" HeaderText="PRC ULT CMP SOL">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FchUltCmp" SortExpression="FchUltCmp" HeaderText="ULTIMA COMPRA">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FchUltSda" SortExpression="FchUltSda" HeaderText="ULTIMA SALIDA">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Ubc" SortExpression="Ubc" HeaderText="UBICACION">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR>
											<TD width="100%" colSpan="3" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD width="100%" colSpan="3" align="left"><IMG style="CURSOR: hand" id="Img1" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
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
	</body>
</HTML>
