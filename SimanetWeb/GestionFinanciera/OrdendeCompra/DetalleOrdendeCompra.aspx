<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc3" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="DetalleOrdendeCompra.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.OrdendeCompra.DetalleOrdendeCompra" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<!--<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>-->
		<!--oncontextmenu="return false" -->
		<style type="text/css">
			.disabled { BACKGROUND-COLOR: #c0c0c0 }
		</style>
		<script>
			var  idCentroOperativo =0;
			function ddlbCentroOperativo_SelectedIndexChanged(e){
			
				
				try{
					idCentroOperativo =e.options[e.selectedIndex].value;
					
				}
				catch(error){
					idCentroOperativo = this.options[this.options.selectedIndex].value;
					
				}
			
				if(idCentroOperativo == 3){
				
					$O('txtNroOC').disabled = false;
					$O('txtNroOC').className ='';
				
				}
				else {
					$O('txtNroOC').disabled = true;
					$O('txtNroOC').className ='disabled';
				}
				
			}
			
		</script>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" onunload="SubirHistorial();"
		onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td bgColor="#eff7fa" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Orden de Compra</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="774">
							<TR>
								<TD bgColor="#000080" colSpan="10"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Width="304px" Height="16px">DETALLE DE ORDEN DE COMPRA</asp:label></TD>
								<TD bgColor="#000080"></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 133px" class="HeaderDetalle"><asp:label id="Label5" runat="server" Width="50px" ToolTip="Centro de Operaciones"> CO:</asp:label></TD>
								<TD style="WIDTH: 136px" id="CellddlbCentroOperativo" runat="server"><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Width="143px"></asp:dropdownlist></TD>
								<TD></TD>
								<TD class="HeaderDetalle">
									<asp:label style="Z-INDEX: 0" id="Label2" runat="server" Width="88px">NRO ORD COMP :</asp:label></TD>
								<TD style="WIDTH: 30px" id="CellddlbSituacion" colSpan="2" runat="server"><asp:textbox style="Z-INDEX: 0" id="txtNroOC" runat="server" Width="120px" Enabled="False" CssClass="disabled"
										Font-Size="XX-Small"></asp:textbox></TD>
								<TD style="WIDTH: 82px" class="HeaderDetalle"><asp:label id="Label6" runat="server">Moneda :</asp:label></TD>
								<TD style="WIDTH: 475px" id="CellddlbMoneda" colSpan="3" runat="server"><asp:dropdownlist id="ddlbMoneda" runat="server" CssClass="normaldetalle" Width="100%"></asp:dropdownlist></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 133px" class="HeaderDetalle"><asp:label id="Label13" runat="server">Proveedor :</asp:label></TD>
								<TD width="10%"><INPUT style="WIDTH: 84.88%; HEIGHT: 22px" id="hNumero" class="normaldetalle" readOnly
										size="12" name="hNumero" runat="server">
									<asp:image id="ibtnBuscarEntidad" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:image></TD>
								<TD><cc1:requireddomvalidator id="rfvProvCli" tabIndex="1" runat="server" Width="8px" ControlToValidate="hNumero">*</cc1:requireddomvalidator></TD>
								<TD class="HeaderDetalle"><asp:label id="Label14" runat="server">Razón Social :</asp:label></TD>
								<TD style="WIDTH: 756px" colSpan="6"><INPUT style="BACKGROUND-COLOR: transparent; WIDTH: 100%; HEIGHT: 22px" id="txtEntidad"
										class="normaldetalle" readOnly size="54" name="Text1" runat="server"></TD>
								<TD><INPUT style="WIDTH: 18px; HEIGHT: 22px" id="hIdEntidad" size="1" type="hidden" name="hIdEntidad"
										runat="server"></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 133px; HEIGHT: 16px" class="HeaderDetalle"><asp:label id="Label18" runat="server" Width="97px">Fecha:</asp:label></TD>
								<TD style="WIDTH: 136px; HEIGHT: 16px" id="CellddlbTipoTrabajo" runat="server"><ew:calendarpopup id="CalFecha" runat="server" CssClass="normaldetalle" Width="72px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CalendarLocation="Bottom" AllowArbitraryText="False" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:"
										PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True">
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
								<TD style="HEIGHT: 16px" class="HeaderDetalle"><asp:label id="Label9" runat="server" Width="123px">Monto :</asp:label></TD>
								<TD style="WIDTH: 151px; HEIGHT: 16px"><ew:numericbox id="nMonto" runat="server" CssClass="normaldetalle" Width="100%" TextAlign="Right"
										AutoFormatCurrency="True" DollarSign=" " PositiveNumber="True" PlacesBeforeDecimal="15" DecimalPlaces="2" MaxLength="18">0</ew:numericbox></TD>
								<TD style="WIDTH: 225px; HEIGHT: 16px" class="HeaderDetalle" colSpan="3"><asp:label id="Label1" runat="server" Width="88px">Monto GASTO :</asp:label></TD>
								<TD style="HEIGHT: 16px" colSpan="2"><ew:numericbox id="nMontoGasto" runat="server" CssClass="normaldetalle" Width="100%" TextAlign="Right"
										AutoFormatCurrency="True" DollarSign=" " PositiveNumber="True" PlacesBeforeDecimal="15" DecimalPlaces="2" MaxLength="18">0</ew:numericbox></TD>
								<TD style="HEIGHT: 16px"></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 133px" class="HeaderDetalle"><asp:label id="Label10" runat="server">DESCRIPCION :</asp:label></TD>
								<TD width="80%" colSpan="9" align="left"><asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Width="100%" Height="44px"
										TextMode="MultiLine"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle"></TD>
								<TD rowSpan="2" width="80%" colSpan="9">
									<TABLE id="ToolBar" border="0" cellSpacing="1" cellPadding="1" width="112" align="right"
										runat="server">
										<TR>
											<TD>
												<P align="right"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></P>
											</TD>
											<TD>
												<P align="right"><IMG id="ibtnCancelar" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
														runat="server"></P>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD></TD>
							</TR>
						</TABLE>
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE style="WIDTH: 760px; HEIGHT: 23px" id="tblAtras" border="0" cellSpacing="1" cellPadding="1"
							width="760" runat="server">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"><cc1:domvalidationsummary id="Vresumen" runat="server" Width="160px" Height="24px" DisplayMode="List" EnableClientScript="False"
							ShowMessageBox="True"></cc1:domvalidationsummary></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
