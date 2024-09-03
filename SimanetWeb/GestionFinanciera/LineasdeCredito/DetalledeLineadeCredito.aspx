<%@ Page language="c#" Codebehind="DetalledeLineadeCredito.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.LineasdeCredito.DetalledeLineadeCredito" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script>
			function ObtenerTipoCambio(Fecha,Source){
				var MiFecha;
				if(Source=="CMB"){
					var arrDate = Fecha.toString().split('-');
					MiFecha = arrDate[0].toString().LPad(2,'0') +'-'+arrDate[1].toString().LPad(2,'0') +'-'+ arrDate[2];
				}
				else{
					var arrDate = Fecha.toString().split('/');
					MiFecha = arrDate[1].toString().LPad(2,'0') +'-'+arrDate[0].toString().LPad(2,'0') +'-'+ arrDate[2];
				}
				var oddlbMoneda = new System.Web.UI.WebControls.DropDownList('ddlbMoneda');
				var item = oddlbMoneda.ListItem();
				var oDataTable = new System.Data.DataTable("tblTipoCambio");
				oDataTable = (new Controladora.General.CTipodeCambio()).ListarPorMonedayFecha(SIMA.Utilitario.Enumerados.TipoCambio.COMPRA.toString(),item.value,MiFecha);
				for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
					var dr =oDataTable.Rows.Items[f];
					if(dr.Item("EOF")==false){
						$O('nTipoCambio').value = dr.Item("TipoCambio");
					}
				}
			}
			function CambioMoneda(){
				var oCalFechaApertura = $O('CalFechaApertura');
				//window.alert(oCalFechaApertura.value);
				ObtenerTipoCambio(oCalFechaApertura.value,'CMB');
			}
		</script>
	</HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" style="HEIGHT: 400px">
				<TBODY>
					<tr>
						<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
					</tr>
					<TR>
						<TD class="RutaPaginaActual" vAlign="top" align="left" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Línea de Crédito</asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="left" width="100%"><IMG style="WIDTH: 160px; HEIGHT: 16px" height="16" src="../../imagenes/spacer.gif" width="160"></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="100%">
							<TABLE id="Table2" style="WIDTH: 473px; HEIGHT: 444px" cellSpacing="0" cellPadding="0"
								width="473" align="center" border="0" DESIGNTIMEDRAGDROP="27">
								<TR>
									<TD style="HEIGHT: 108px"></TD>
									<TD style="HEIGHT: 108px">
										<TABLE class="normal" id="Table3" cellSpacing="1" cellPadding="1" width="469" align="center"
											border="0">
											<TR>
												<TD class="normal" align="center"></TD>
												<TD class="normal" style="WIDTH: 458px" align="center"></TD>
												<TD class="normal" style="WIDTH: 458px" align="center" colSpan="6"><INPUT id="hIdLineaC" style="WIDTH: 72px; HEIGHT: 22px" type="hidden" size="6" name="hIdTablaEntidad"
														runat="server"><INPUT id="hIdPeriodo" style="WIDTH: 72px; HEIGHT: 22px" type="hidden" size="6" name="hIdTablaEntidad"
														runat="server"></TD>
											</TR>
											<TR>
												<TD class="normal" style="HEIGHT: 28px" vAlign="top"></TD>
												<TD class="normal" style="WIDTH: 109px; HEIGHT: 28px" vAlign="top"></TD>
												<TD style="HEIGHT: 28px" vAlign="middle" width="100%" colSpan="6" bgColor="#000080">
													<asp:label id="Label8" runat="server" CssClass="TituloPrincipalBlanco">LÍNEA DE CRÉDITO</asp:label></TD>
											</TR>
											<TR class="AlternateItemDetalle">
												<TD class="normal" style="HEIGHT: 3px" vAlign="top"></TD>
												<TD class="normal" style="WIDTH: 109px; HEIGHT: 3px" vAlign="top"></TD>
												<TD class="HeaderDetalle" style="WIDTH: 73px; HEIGHT: 3px" vAlign="top">
													<asp:label id="lblEmpresa" runat="server" DESIGNTIMEDRAGDROP="166">Empresa:</asp:label></TD>
												<TD class="normal" style="WIDTH: 343px; HEIGHT: 3px" colSpan="4">
													<asp:DropDownList id="ddlbEmpresa" runat="server" CssClass="normal" Width="352px" AutoPostBack="True"></asp:DropDownList></TD>
												<TD style="WIDTH: 19px; HEIGHT: 3px"></TD>
											</TR>
											<TR class="ItemDetalle">
												<TD class="normal" style="HEIGHT: 19px" vAlign="top"></TD>
												<TD class="normal" style="WIDTH: 109px; HEIGHT: 19px" vAlign="top"></TD>
												<TD class="HeaderDetalle" style="WIDTH: 73px; HEIGHT: 19px" vAlign="top">
													<asp:label id="Label10" runat="server" DESIGNTIMEDRAGDROP="55">Banco :</asp:label></TD>
												<TD class="normal" style="WIDTH: 343px; HEIGHT: 19px" colSpan="4">
													<asp:dropdownlist id="ddlbEntidadFinanciera" runat="server" CssClass="normal" DESIGNTIMEDRAGDROP="57"
														Width="352px"></asp:dropdownlist></TD>
												<TD style="WIDTH: 19px; HEIGHT: 19px"></TD>
											</TR>
											<TR class="AlternateItemDetalle">
												<TD class="normal" style="HEIGHT: 14px" vAlign="top"></TD>
												<TD class="normal" style="WIDTH: 109px; HEIGHT: 14px" vAlign="top"></TD>
												<TD class="HeaderDetalle" style="WIDTH: 73px; HEIGHT: 14px" vAlign="top">
													<asp:label id="Label6" runat="server" Width="86px">Línea de Crédito :</asp:label></TD>
												<TD class="normal" style="WIDTH: 343px; HEIGHT: 14px" colSpan="4">
													<asp:dropdownlist id="ddlbLineadeCredito" runat="server" CssClass="normal" Width="352px"></asp:dropdownlist></TD>
												<TD style="WIDTH: 19px; HEIGHT: 14px"></TD>
											</TR>
											<TR class="ItemDetalle">
												<TD class="normal" style="HEIGHT: 16px" vAlign="top"></TD>
												<TD class="normal" style="WIDTH: 109px; HEIGHT: 16px" vAlign="top"></TD>
												<TD class="HeaderDetalle" style="WIDTH: 73px; HEIGHT: 16px" vAlign="top">
													<asp:label id="Label9" runat="server">Moneda:</asp:label></TD>
												<TD class="normal" style="WIDTH: 123px; HEIGHT: 16px" colSpan="2">
													<asp:DropDownList id="ddlbMoneda" runat="server" CssClass="normal" Width="120px"></asp:DropDownList></TD>
												<TD style="WIDTH: 19px; HEIGHT: 16px" class="HeaderDetalle">
													<asp:label id="Label1" runat="server">Situación</asp:label></TD>
												<TD style="HEIGHT: 16px">
													<asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normal" Width="99%" Height="24px"></asp:dropdownlist></TD>
												<TD class="normal" style="HEIGHT: 16px"></TD>
											</TR>
											<TR class="AlternateItemDetalle">
												<TD class="normal" style="HEIGHT: 1px" vAlign="top"></TD>
												<TD class="normal" style="WIDTH: 109px; HEIGHT: 1px" vAlign="top"></TD>
												<TD class="HeaderDetalle" style="WIDTH: 73px; HEIGHT: 1px" vAlign="top">
													<asp:label id="Label3" runat="server" Width="78px">Fecha Apertura:</asp:label></TD>
												<TD class="normal" style="WIDTH: 123px; HEIGHT: 1px" colSpan="2">
													<ew:calendarpopup id="CalFechaApertura" runat="server" CssClass="combos" Width="72px" ImageUrl="../../imagenes/BtPU_Mas.gif"
														PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True"
														JavascriptOnChangeFunction="ObtenerTipoCambio">
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
												<TD style="WIDTH: 19px; HEIGHT: 1px" class="HeaderDetalle">
													<asp:label id="Label4" runat="server" DESIGNTIMEDRAGDROP="181" Width="96px">Fecha Vencimiento:</asp:label></TD>
												<TD style="WIDTH: 101px; HEIGHT: 1px">
													<ew:calendarpopup id="CalFechaVencimiento" runat="server" CssClass="combos" DESIGNTIMEDRAGDROP="102"
														Width="72px" ImageUrl="../../imagenes/BtPU_Mas.gif" PadSingleDigits="True" Culture="Spanish (Chile)"
														ControlDisplay="TextBoxImage" ShowGoToToday="True">
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
												<TD class="normal" style="HEIGHT: 1px"></TD>
											</TR>
											<TR class="ItemDetalle">
												<TD class="normal" style="HEIGHT: 18px" vAlign="top"></TD>
												<TD class="normal" style="WIDTH: 109px; HEIGHT: 18px" vAlign="top"></TD>
												<TD class="HeaderDetalle" style="WIDTH: 73px; HEIGHT: 18px" vAlign="top">
													<asp:label id="Label7" runat="server" Width="87px">Monto Autorizado:</asp:label></TD>
												<TD class="normal" style="WIDTH: 123px; HEIGHT: 18px" colSpan="2">
													<ew:numericbox id="nMontoAutorizado" runat="server" CssClass="normal" DESIGNTIMEDRAGDROP="103"
														Width="105px" PositiveNumber="True" MaxLength="15" TextAlign="Right" DollarSign=" " AutoFormatCurrency="True"
														PlacesBeforeDecimal="10" DecimalPlaces="3">0.0</ew:numericbox>
													<cc1:requireddomvalidator id="rdvMontoAutorizado" runat="server" Width="14px" ErrorMessage="*" ControlToValidate="nMontoAutorizado">*</cc1:requireddomvalidator></TD>
												<TD style="WIDTH: 19px; HEIGHT: 18px" class="HeaderDetalle">
													<asp:label id="Label11" runat="server" DESIGNTIMEDRAGDROP="158" Width="95px">Tipo de Cambio:</asp:label></TD>
												<TD style="WIDTH: 101px; HEIGHT: 18px">
													<ew:numericbox id="nTipoCambio" runat="server" CssClass="normal" Width="105px" PositiveNumber="True"
														MaxLength="10" TextAlign="Right" DollarSign=" " AutoFormatCurrency="True" PlacesBeforeDecimal="6"
														DecimalPlaces="6">0.0</ew:numericbox></TD>
												<TD class="normal" style="HEIGHT: 18px">
													<cc1:requireddomvalidator id="TipoCambio" runat="server" Width="14px" ErrorMessage="*" ControlToValidate="nTipoCambio">*</cc1:requireddomvalidator></TD>
											</TR>
											<TR class="AlternateItemDetalle">
												<TD class="normal" vAlign="top"></TD>
												<TD class="normal" style="WIDTH: 109px" vAlign="top"></TD>
												<TD class="HeaderDetalle" style="WIDTH: 73px" vAlign="top">
													<asp:label id="lblObservacion" runat="server">Observaciones:</asp:label></TD>
												<TD class="normal" style="WIDTH: 343px" colSpan="4">
													<asp:textbox id="txtObservacion" runat="server" CssClass="normal" DESIGNTIMEDRAGDROP="248" Width="352px"
														Height="54px" MaxLength="80" TextMode="MultiLine"></asp:textbox></TD>
												<TD class="normal" style="WIDTH: 26px" rowSpan="2"></TD>
											</TR>
											<TR class="ItemDetalle">
												<TD class="normal" style="WIDTH: 254px; HEIGHT: 27px"></TD>
												<TD class="normal" style="WIDTH: 109px; HEIGHT: 27px"></TD>
												<TD class="normal" style="WIDTH: 73px; HEIGHT: 27px"><SPAN class="normal">
														<asp:TextBox id="txtNroLinea" runat="server" Width="86px" ReadOnly="True" BackColor="#F0F0F0"></asp:TextBox></SPAN></TD>
												<TD class="normal" style="WIDTH: 120px; HEIGHT: 27px"><SPAN class="normal"></SPAN></TD>
												<TD class="normal" style="WIDTH: 149px; HEIGHT: 27px" align="right" colSpan="2">
													<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
												<TD style="WIDTH: 101px; HEIGHT: 27px" align="right"><SPAN class="normal"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></SPAN></TD>
											</TR>
											<TR>
												<TD class="normal" style="WIDTH: 254px; HEIGHT: 27px" align="center" colSpan="8">
													<asp:label id="lblMensaje" runat="server" CssClass="normal"></asp:label></TD>
											</TR>
										</TABLE>
										<TABLE class="gg" id="tblNota" style="WIDTH: 487px; HEIGHT: 54px" cellSpacing="1" cellPadding="1"
											width="487" border="0">
											<TR>
												<TD style="WIDTH: 30px" align="right"><IMG src="../../imagenes/post.gif"></TD>
												<TD><SPAN class="normal"><SPAN class="normal"><SPAN class="normal">
																<asp:Label id="Label5" runat="server" Width="295px" Font-Bold="True">Nota :</asp:Label></SPAN></SPAN></SPAN></TD>
											</TR>
											<TR>
												<TD colSpan="2"><SPAN class="normal"><SPAN class="normal"><SPAN class="normal"><SPAN class="normal"><SPAN class="normal">
																		<asp:Label id="Label2" runat="server" Width="464px" Height="24px">Para renovar una Línea de Crédito, de la Empresa en Una Entidad Financiera, Prímero debe de cambiar el estado de la última Línea de Crédito Renovada a (Estado:=Términada), con la finanlidad de que el Sistema Tome la Ultima Línea cuyo Estado se encuentre en Vigente o Cancelada o Vencida.................</asp:Label></SPAN></SPAN></SPAN></SPAN></SPAN></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<cc1:domvalidationsummary id="Vresumen" runat="server" Width="160px" Height="24px" ShowMessageBox="True" DisplayMode="List"
						EnableClientScript="False"></cc1:domvalidationsummary></TBODY>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
