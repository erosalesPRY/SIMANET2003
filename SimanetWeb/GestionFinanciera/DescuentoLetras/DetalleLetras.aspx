<%@ Page language="c#" Codebehind="DetalleLetras.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras.DetalleLetras" %>
<%@ Register TagPrefix="cc3" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script>
		function Calculo(strNombreFechaIni,strNombreFechaFin,strControlDestino)
		{
			var CarArray="-";
			var Fini = document.all[strNombreFechaIni].value; 
			var Ffin = document.all[strNombreFechaFin].value; 
			var ArrayFini = Fini.split(CarArray);
			var ArrayFfin = Ffin.split(CarArray);
			var oFini = new Date(ArrayFini[2],ArrayFini[1],ArrayFini[0]); 
			var oFfin = new Date(ArrayFfin[2],ArrayFfin[1],ArrayFfin[0]); 
			var operacion =(oFini-oFfin)/86400000; 
			document.all[strControlDestino].value =Math.abs(operacion);
			//return  Math.abs(operacion);
		}
		


		function verificarRenovacion(){ 
			var MontoLetra = $O('nMonto').value.toString().replace(',','');
			var MontoLetraCancelada = $O('nMontoCancelado').value.toString().replace(',','');
			if(parseFloat(MontoLetraCancelada)>parseFloat(MontoLetra)){
				window.alert("El monto a cancelar no puede ser mayor al monto de la Letra");
			}
			if((parseFloat(MontoLetraCancelada)>0)&&(parseFloat(MontoLetra)!=parseFloat(MontoLetraCancelada))){
				var iRetorno = confirm("Esta Letra sera cancelada por un monto menor a la de la misma,esto creara una renovación\n desea hacer efectiva la renovacion por la diferencia?");
				if(iRetorno==true){
					$doPostBack('Grabar','hPostback');
				}
			}
		}
		
		</script>
		<!--oncontextmenu="return false" -->
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" bottomMargin="0"
		leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Letras</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="774" border="0">
							<TR>
								<TD bgColor="#000080" colSpan="10"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="16px" Width="304px">DETALLE DE LETRAS</asp:label></TD>
								<TD bgColor="#000080"></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><asp:label id="Label1" runat="server" Width="100px" ToolTip="Nro del Documento de Referencia">Nro Doc:</asp:label></TD>
								<TD width="10%"><asp:textbox id="txtNroDocumento" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="15"></asp:textbox></TD>
								<TD style="WIDTH: 408px" colSpan="8"><cc1:requireddomvalidator id="rfvNroReferencia" runat="server" Width="8px" ControlToValidate="txtNroDocumento">*</cc1:requireddomvalidator></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><asp:label id="Label5" runat="server" Width="50px" ToolTip="Centro de Operaciones"> CO:</asp:label></TD>
								<TD id="CellddlbCentroOperativo" style="WIDTH: 136px" runat="server"><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Width="143px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 2px"></TD>
								<TD class="HeaderDetalle"><asp:label id="Label4" runat="server">Situación :</asp:label></TD>
								<TD id="CellddlbSituacion" style="WIDTH: 30px" colSpan="2" runat="server"><asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Width="98px"></asp:dropdownlist></TD>
								<TD class="HeaderDetalle" style="WIDTH: 82px"><asp:label id="Label6" runat="server">Moneda :</asp:label></TD>
								<TD id="CellddlbMoneda" style="WIDTH: 475px" colSpan="3" runat="server"><asp:dropdownlist id="ddlbMoneda" runat="server" CssClass="normaldetalle" Width="100%"></asp:dropdownlist></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><asp:label id="Label13" runat="server">Cliente/Proveedor :</asp:label></TD>
								<TD width="10%"><INPUT class="normaldetalle" id="hNumero" style="WIDTH: 84.88%; HEIGHT: 22px" readOnly
										type="text" size="12" name="hNumero" runat="server">
									<asp:image id="ibtnBuscarEntidad" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:image></TD>
								<TD style="WIDTH: 2px"><cc1:requireddomvalidator id="rfvProvCli" tabIndex="1" runat="server" Width="8px" ControlToValidate="hNumero">*</cc1:requireddomvalidator></TD>
								<TD class="HeaderDetalle"><asp:label id="Label14" runat="server">Razón Social :</asp:label></TD>
								<TD style="WIDTH: 756px" colSpan="6"><INPUT class="normaldetalle" id="txtEntidad" style="WIDTH: 100%; HEIGHT: 22px; BACKGROUND-COLOR: transparent"
										readOnly type="text" size="54" name="Text1" runat="server"></TD>
								<TD><INPUT id="hIdTablaEntidad" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdTablaEntidad"
										runat="server"><INPUT id="hIdEntidad" style="WIDTH: 18px; HEIGHT: 22px" type="hidden" size="1" name="hIdEntidad"
										runat="server"><INPUT id="hIdCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdCodigo"
										runat="server"></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><asp:label id="Label19" runat="server" DESIGNTIMEDRAGDROP="65">Proyecto :</asp:label></TD>
								<TD align="left" width="80%" colSpan="9">&nbsp;<TEXTAREA class="normaldetalle" id="txtProyecto" style="WIDTH: 100%; HEIGHT: 32px" rows="2"
										readOnly cols="75" runat="server"></TEXTAREA>
								</TD>
								<TD><asp:image id="ibtnBuscarProyecto" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:image></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><asp:label id="Label15" runat="server" Width="100px" ToolTip="Otros datos del Proyecto">Datos del Proy :</asp:label></TD>
								<TD width="80%" colSpan="9"><asp:textbox id="txtDatosProyecto" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
								<TD><INPUT id="hIdProyecto" style="WIDTH: 12px; HEIGHT: 22px" type="hidden" size="1" name="hIdProyecto"
										runat="server"><INPUT id="txtCliente" style="WIDTH: 11px; HEIGHT: 22px" type="hidden" size="1" name="txtCliente"
										runat="server"></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px; HEIGHT: 16px"><asp:label id="Label11" runat="server">Tipo de Trabajo :</asp:label></TD>
								<TD id="CellddlbTipoTrabajo" style="WIDTH: 136px; HEIGHT: 16px" runat="server"><asp:dropdownlist id="ddlbTipoTrabajo" runat="server" CssClass="normaldetalle" Width="143px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 2px; HEIGHT: 16px"></TD>
								<TD class="HeaderDetalle" style="HEIGHT: 16px"><asp:label id="Label18" runat="server" Width="97px">Fecha de Inicio:</asp:label></TD>
								<TD style="WIDTH: 151px; HEIGHT: 16px"><ew:calendarpopup id="CalFechaInicio" runat="server" CssClass="normaldetalle" Width="72px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CalendarLocation="Bottom" AllowArbitraryText="False" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar"
										NullableLabelText="Seleccione una fecha:" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True">
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
								<TD class="HeaderDetalle" style="WIDTH: 140px; HEIGHT: 16px" colSpan="3"><asp:label id="Label8" runat="server" Width="120px">Fecha Vencimiento :</asp:label></TD>
								<TD style="HEIGHT: 16px" colSpan="2"><ew:calendarpopup id="CalFechaVencimiento" runat="server" CssClass="normaldetalle" Width="72px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CalendarLocation="Bottom" AllowArbitraryText="False" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar"
										NullableLabelText="Seleccione una fecha:" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True">
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
								<TD style="HEIGHT: 16px"></TD>
							</TR>
							<TR class="ItemDetalle" id="FilaCalculada" runat="server">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><asp:label id="Label2" runat="server" DESIGNTIMEDRAGDROP="652">DIAS DE PLAZO:</asp:label></TD>
								<TD width="10%"><ew:numericbox id="NDiasPlazo" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="8"
										DESIGNTIMEDRAGDROP="654" ReadOnly="True" DecimalPlaces="2" PlacesBeforeDecimal="3" PositiveNumber="True"
										DollarSign=" " AutoFormatCurrency="True" TextAlign="Right" BackColor="#E0E0E0">0</ew:numericbox></TD>
								<TD style="WIDTH: 2px"></TD>
								<TD class="HeaderDetalle"><asp:label id="Label7" runat="server">DIAS QUE VENCE:</asp:label></TD>
								<TD style="WIDTH: 151px"><ew:numericbox id="nDiasVence" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="8"
										ReadOnly="True" DecimalPlaces="2" PlacesBeforeDecimal="3" PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True"
										TextAlign="Right" BackColor="#E0E0E0">0</ew:numericbox></TD>
								<TD style="WIDTH: 140px" colSpan="3"></TD>
								<TD colSpan="2"><IMG style="WIDTH: 92px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="92"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" style="WIDTH: 133px; HEIGHT: 24px"><asp:label id="Label9" runat="server" Width="123px">Monto :</asp:label></TD>
								<TD style="HEIGHT: 24px" width="10%"><ew:numericbox id="nMonto" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="15"
										DecimalPlaces="2" PlacesBeforeDecimal="8" PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True" TextAlign="Right">0</ew:numericbox></TD>
								<TD style="WIDTH: 2px; HEIGHT: 24px"><cc1:requireddomvalidator id="rfvMontoEstablecido" tabIndex="3" runat="server" Width="8px" ControlToValidate="nMonto">*</cc1:requireddomvalidator></TD>
								<TD class="HeaderDetalle" style="HEIGHT: 24px"><asp:label id="Label3" runat="server" Width="103px">Tasa de Interés :</asp:label></TD>
								<TD style="WIDTH: 151px; HEIGHT: 24px"><ew:numericbox id="nTasaInteres" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="8"
										DecimalPlaces="2" PlacesBeforeDecimal="2" PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True" TextAlign="Right">0</ew:numericbox></TD>
								<TD class="HeaderDetalle" style="WIDTH: 140px; HEIGHT: 24px" noWrap colSpan="3"><cc1:requireddomvalidator id="rfvTasaInteres" tabIndex="3" runat="server" Width="8px" ControlToValidate="nTasaInteres">*</cc1:requireddomvalidator><asp:label id="Label12" runat="server" Width="120px">MONTO CANCELADO :</asp:label></TD>
								<TD style="HEIGHT: 24px" colSpan="2"><ew:numericbox id="nMontoCancelado" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="15"
										DecimalPlaces="2" PlacesBeforeDecimal="8" PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True" TextAlign="Right">0</ew:numericbox></TD>
								<TD style="HEIGHT: 24px"></TD>
							</TR>
							<TR class="AlternateItemDetalle" runat="server">
								<TD class="HeaderDetalle" style="WIDTH: 133px"></TD>
								<TD width="10%"></TD>
								<TD style="WIDTH: 2px"></TD>
								<TD class="HeaderDetalle"></TD>
								<TD style="WIDTH: 151px"></TD>
								<TD style="WIDTH: 225px" colSpan="5"></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><asp:label id="Label10" runat="server">GARANTIA :</asp:label></TD>
								<TD align="left" width="80%" colSpan="9"><asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Height="44px" Width="100%"
										TextMode="MultiLine"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle"></TD>
								<TD width="80%" colSpan="9" rowSpan="2">
									<TABLE id="ToolBar" cellSpacing="1" cellPadding="1" width="112" align="right" border="0"
										runat="server">
										<TR>
											<TD>
												<P align="right"><IMG id="ibtnAcepta" onclick="verificarRenovacion();" alt="" src="../../imagenes/bt_aceptar.gif"></P>
											</TD>
											<TD>
												<P align="right"><IMG id="ibtnCancelar" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
														runat="server"></P>
											</TD>
										</TR>
									</TABLE>
									<INPUT id="hPostback" style="WIDTH: 56px; HEIGHT: 22px" type="hidden" size="4" runat="server">&nbsp;
								</TD>
								<TD></TD>
							</TR>
						</TABLE>
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="tblAtras" style="WIDTH: 760px; HEIGHT: 23px" cellSpacing="1" cellPadding="1"
							width="760" border="0" runat="server">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"><cc1:domvalidationsummary id="Vresumen" runat="server" Height="24px" Width="160px" DisplayMode="List" EnableClientScript="False"
							ShowMessageBox="True"></cc1:domvalidationsummary></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
