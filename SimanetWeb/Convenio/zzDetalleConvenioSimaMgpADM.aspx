<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleConvenioSimaMgpADM.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.DetalleConvenioSimaMgpADM" %>
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
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="3"><uc1:headerinicio id="HeaderInicio1" runat="server"></uc1:headerinicio></td>
				</tr>
				<tr>
					<td vAlign="top" width="117" bgColor="#f6f6f6" style="WIDTH: 117px"><br>
						<P><uc1:menu id="Menu1" runat="server"></uc1:menu></P>
					</td>
					<td bgColor="#2b1700" style="WIDTH: 3px"></td>
					<td vAlign="top" width="85%">
						<TABLE id="Tablen" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="7" style="WIDTH: 7px"></td>
								<td>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td colspan="2">
												<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Convenios</asp:label>
												<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Convenio SIMA - MGP</asp:label>
											</td>
										</tr>
										<TR>
											<TD align="center" colSpan="2"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal" Width="100%">Convenio SIMA - MGP</asp:label></TD>
										</TR>
										<TR>
											<TD>
												<asp:Label id="lblNroConvenio" runat="server" CssClass="normal" Width="100%">Número de Convenio:</asp:Label></TD>
											<TD>
												<asp:TextBox id="txtNroConvenio" runat="server" CssClass="normal">2002-02</asp:TextBox></TD>
										</TR>
										<TR>
											<TD valign="top">
												<asp:Label id="lblDescripcion" runat="server" CssClass="Normal" Width="100%">Descripción:</asp:Label>
											</TD>
											<TD style="HEIGHT: 55px">
												<asp:TextBox id="txtDescripcion" runat="server" Width="100%" MaxLength="1500" Height="88px" CssClass="normal"
													TextMode="MultiLine"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD>
												<asp:Label id="lblEstadoConvenio" runat="server" CssClass="normal" Width="100%">Estado:</asp:Label></TD>
											<TD>
												<asp:DropDownList id="ddlbEstadoConvenio" runat="server" CssClass="normal"></asp:DropDownList></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 153px">
												<asp:Label id="lblFechaVencimiento" runat="server" CssClass="normal" Width="100%">Fecha de vencimiento:</asp:Label></TD>
											<TD>
												<ew:calendarpopup id="CalFechaInicio" runat="server" CssClass="combos" Width="72px" ImageUrl="../imagenes/BtPU_Mas.gif"
													ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Peru)" PadSingleDigits="True">
													<TextboxLabelStyle CssClass="normal"></TextboxLabelStyle>
													<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></WeekdayStyle>
													<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
														BackColor="#404040"></MonthHeaderStyle>
													<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Gray"
														BackColor="WhiteSmoke"></OffMonthStyle>
													<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></GoToTodayStyle>
													<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="LightGoldenrodYellow"></TodayDayStyle>
													<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="Silver"></DayHeaderStyle>
													<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="LightGray"></WeekendStyle>
													<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
														BackColor="#404040"></SelectedDateStyle>
													<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></ClearDateStyle>
													<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></HolidayStyle>
												</ew:calendarpopup></TD>
										</TR>
										<TR>
											<TD valign="top">
												<asp:Label id="lblObservaciones" runat="server" CssClass="normal" Width="100%">Observaciones:</asp:Label></TD>
											<TD>
												<asp:TextBox id="txtObservaciones" runat="server" CssClass="normal" Width="100%" MaxLength="2000"
													Height="88px" TextMode="MultiLine"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD>
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR align="center">
														<TD style="WIDTH: 175px">
															<asp:imagebutton id="ibtnAceptar" runat="server" CssClass="normal" ImageUrl="../imagenes/bt_aceptar.gif"
																AlternateText="Aceptar"></asp:imagebutton></TD>
														<TD style="WIDTH: 5px"></TD>
														<TD>
															<asp:imagebutton id="ibtnCancelar" runat="server" ImageUrl="../imagenes/bt_cancelar.gif" CausesValidation="False"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
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
