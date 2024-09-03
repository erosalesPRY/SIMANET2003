<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalledeRequerimiento.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.DetalledeRequerimiento" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>DetalledeRequerimiento</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script>
			function Mostrar(NombreobjID,NombreObjDescripcion){
				var txtid =  document.all[NombreobjID];
				var txtDescripcion =  document.all[NombreObjDescripcion];
				
				try{
				
					txtid.value = ArrDatosRemotos[0];
					txtDescripcion.value = ArrDatosRemotos[1];
					if(NombreobjID=="hIdGrupoCC"){
						var objCC = document.all["hidCentroCosto"];
						objCC.value="";
						objCC = document.all["txtNombreCentroCosto"];
						objCC.value="";
					}
				}
				catch(error){
					//window.alert(error.description);
				}
			}
		</script>
</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" bottomMargin="0"
		leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" style="WIDTH: 592px; HEIGHT: 235px" cellSpacing="0" cellPadding="0"
							width="592" border="0">
							<TR class="ItemDetalle">
								<TD bgColor="#000080" colSpan="4" height="24">
									<asp:label id="lblTitulo" runat="server" Width="565px" CssClass="TituloPrincipalBlanco" Height="16px"> DETALLE ADMINISTRACION DE REQUERIMIENTO</asp:label></TD>
								<TD bgColor="#000080" height="24"></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="Headerdetalle">
									<asp:Label id="Label1" runat="server">TIPO DOCUMENTO:</asp:Label></TD>
								<TD style="WIDTH: 160px">
									<asp:DropDownList id="ddlTipoDocumento" runat="server" Width="100%" CssClass="normaldetalle"></asp:DropDownList></TD>
								<TD class="Headerdetalle">
									<asp:Label id="Label2" runat="server">Nº DOCUMENTO:</asp:Label></TD>
								<TD width="150">
									<asp:TextBox id="txtNroDocumento" runat="server" CssClass="normaldetalle" Width="100%"></asp:TextBox></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="Headerdetalle">
									<asp:Label id="Label3" runat="server">FECHA:</asp:Label></TD>
								<TD style="WIDTH: 160px">
									<ew:calendarpopup id="CalFecha" runat="server" Width="76px" CssClass="normaldetalle" ShowGoToToday="True"
										ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CalendarWidth="2" DisableTextboxEntry="False" Font-Names="Arial" ForeColor="Navy" BorderStyle="None"
										CalendarLocation="Bottom" Height="22px">
										<TextboxLabelStyle CssClass="normaldetalle"></TextboxLabelStyle>
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
										<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
											BackColor="Gray"></DayHeaderStyle>
										<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="LightGray"></WeekendStyle>
										<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="#FF8A00"></SelectedDateStyle>
										<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
											BackColor="White"></ClearDateStyle>
										<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
											BackColor="White"></HolidayStyle>
									</ew:calendarpopup></TD>
								<TD class="Headerdetalle">
									<asp:Label id="Label6" runat="server" Width="116px">MONTO REQUERIDO:</asp:Label></TD>
								<TD>
									<ew:numericbox id="nMonto" runat="server" MaxLength="15" DecimalPlaces="2" DollarSign=" " AutoFormatCurrency="True"
										PositiveNumber="True" PlacesBeforeDecimal="8" Width="100%" CssClass="normaldetalle" Height="25px"
										ReadOnly="True" BackColor="Transparent">0.00</ew:numericbox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="Headerdetalle">
									<asp:Label id="lblTipoPresupuesto" runat="server">PRESUPUESTO:</asp:Label></TD>
								<TD style="WIDTH: 160px">
									<asp:DropDownList id="ddlTipoPresupuesto" runat="server" CssClass="normaldetalle" Width="100%">
										<asp:ListItem Value="1">ADMINISTRACION</asp:ListItem>
										<asp:ListItem Value="2">PRODUCCION</asp:ListItem>
									</asp:DropDownList></TD>
								<TD class="Headerdetalle"></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="Headerdetalle">
									<asp:Label id="Label7" runat="server">MOTIVO:</asp:Label></TD>
								<TD colSpan="3" width="80%">
									<asp:TextBox id="txtMotivo" runat="server" Width="100%" Height="48px" TextMode="MultiLine" CssClass="normaldetalle"></asp:TextBox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="Headerdetalle">
									<asp:Label id="Label4" runat="server">DESCRIPCION:</asp:Label></TD>
								<TD colSpan="3" width="80%">
									<asp:TextBox id="txtDescripcion" runat="server" Width="100%" Height="48px" TextMode="MultiLine"
										CssClass="normaldetalle"></asp:TextBox></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD></TD>
								<TD style="WIDTH: 160px"></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD></TD>
								<TD style="WIDTH: 160px"></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD colSpan="4">
									<TABLE id="Table3" style="WIDTH: 176px; HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="176"
										align="right" border="0">
										<TR>
											<TD align="right">
												<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD align="right"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
										</TR>
									</TABLE>
									&nbsp;
								</TD>
								<TD>&nbsp;
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
