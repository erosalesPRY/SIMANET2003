<%@ Page language="c#" Codebehind="BusquedaPasajesAereos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.BusquedaPasajesAereos" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="730" align="center" border="0">
				<TR>
					<TD class="TituloPrincipal" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> BUSQUEDA DE PASAJES AEREOS</asp:label></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="500" bgColor="#f5f5f5"
							border="0">
							<TR bgColor="#ffffff">
								<TD class="TitFiltros"><IMG height="14" src="../imagenes/TitFiltros.gif" width="82"></TD>
								<TD class="combos"></TD>
								<TD class="combos" width="121"></TD>
								<TD class="combos" width="121"></TD>
								<TD class="combos"></TD>
								<TD class="combos" style="WIDTH: 14px" width="25"></TD>
							</TR>
							<TR>
								<TD><INPUT id="hIdPasajeAereo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdPasajeAereo"
										runat="server"><INPUT id="hRuta" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hRuta"
										runat="server"><INPUT id="hIdMoneda" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdMoneda"
										runat="server"><INPUT id="hMoneda" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hMoneda"
										runat="server"><INPUT id="hMonto" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hMonto"
										runat="server"></TD>
								<TD class="SmallFont" align="center"></TD>
								<TD class="SmallFont" align="center"></TD>
								<TD class="SmallFont" align="center"></TD>
								<TD class="SmallFont" align="center" colSpan="1"></TD>
								<TD class="SmallFont" style="WIDTH: 14px"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros" align="center">&nbsp;
									<asp:label id="lblAerolinea" runat="server" CssClass="normal"> Aerolinea</asp:label></TD>
								<TD class="combos" align="center"></TD>
								<TD class="combos" align="center" colSpan="2"><asp:label id="lblFechaVuelo" runat="server" CssClass="normal">Fecha de Vuelo</asp:label></TD>
								<TD class="combos"></TD>
								<TD class="combos" style="WIDTH: 14px"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros"><asp:dropdownlist id="ddlbAerolinea" runat="server" CssClass="normal" Width="136px"></asp:dropdownlist></TD>
								<TD class="combos">
									<cc2:requireddomvalidator id="rfvAerolinea" runat="server" ControlToValidate="ddlbAerolinea">*</cc2:requireddomvalidator></TD>
								<TD class="combos"><ew:calendarpopup id="CalFechaInicio" runat="server" CssClass="combos" Width="72px" AllowArbitraryText="False"
										ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Peru)" PadSingleDigits="True" ImageUrl="../imagenes/BtPU_Mas.gif">
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
								<TD class="combos"><ew:calendarpopup id="CalFechaFin" runat="server" CssClass="combos" Width="72px" AllowArbitraryText="False"
										ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Peru)" PadSingleDigits="True" ImageUrl="../imagenes/BtPU_Mas.gif">
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
								<TD class="combos"><cc2:comparedomvalidator id="cvFechas" runat="server" ControlToValidate="CalFechaInicio" ControlToCompare="CalFechaFin"
										Operator="LessThanEqual">*</cc2:comparedomvalidator></TD>
								<TD class="combos" style="WIDTH: 14px">
									<asp:imagebutton id="ibtnBuscar" runat="server" ImageUrl="../imagenes/bt_Buscar.GIF"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="720" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<cc1:datagridweb id="grid" runat="server" Width="720px" AllowSorting="True" AutoGenerateColumns="False"
										AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" DataKeyField="IdPasajeAereo"
										CssClass="HeaderGrilla">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="IdPasajeAereo" SortExpression="IdPasajeAereo" HeaderText="IdPasajeAereo"></asp:BoundColumn>
											<asp:BoundColumn DataField="Ruta" SortExpression="Ruta" HeaderText="RUTA"></asp:BoundColumn>
											<asp:BoundColumn DataField="Monto" SortExpression="Monto" HeaderText="MONTO"></asp:BoundColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="MONEDA"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IdMoneda" SortExpression="IdMoneda" HeaderText="IdMoneda"></asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False" DESIGNTIMEDRAGDROP="56"></asp:label></TD>
							</TR>
						</TABLE>
						<cc2:domvalidationsummary id="vSum" runat="server" CssClass="normal" Width="96px" DisplayMode="List" ShowMessageBox="True"
							EnableClientScript="False"></cc2:domvalidationsummary>
					</TD>
				</TR>
				<TR>
					<TD align="center"><IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../imagenes/spacer.gif" width="160"></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table8" width="180" border="0">
							<TR>
								<TD width="94">
									<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif" Height="22px"
										Width="87px"></asp:imagebutton></TD>
								<TD width="101"><SPAN class="normal">
										<asp:imagebutton id="ibtnCancelar" runat="server" ImageUrl="../imagenes/bt_cancelar.gif" Height="22px"
											CausesValidation="False" Width="87px"></asp:imagebutton></SPAN></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script>
		<asp:Literal id="ltlMensaje" Runat="server" EnableViewState="False"></asp:Literal>		
		
		function PonerTexto()
			{ 
				opener.document.forms[0].hIdPasajeAereo.value =document.forms[0].hIdPasajeAereo.value;
				opener.document.forms[0].txtPasajeAereo.value =document.forms[0].hRuta.value;
				opener.document.forms[0].txtMonto.value =document.forms[0].hMonto.value;
				opener.document.forms[0].txtMoneda.value =document.forms[0].hMoneda.value;
				opener.document.forms[0].hIdMoneda.value =document.forms[0].hIdMoneda.value;
				window.close();
			} 
		</script>
	</body>
</HTML>
