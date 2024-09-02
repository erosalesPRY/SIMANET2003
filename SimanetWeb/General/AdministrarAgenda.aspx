<%@ Register TagPrefix="daypilot" Namespace="DayPilot.Web.Ui" Assembly="DayPilot" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministrarAgenda.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.AdministrarAgenda" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarAgenda</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jsFrameworkSima.js"></SCRIPT>
		<script>
			function MostrarDetalle(idAgenda)
			{
				var KEYQIDAGENDA = "idAgenda";
				var PathPagina = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/AdministrarDetalleAgenda.aspx?";
				var Parametros;
				with (SIMA.Utilitario.Constantes.General.Caracter)
				{
					Parametros = KEYQIDAGENDA + SignoIgual.toString() + idAgenda;
								//+ signoAmperson.toString();
				}
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				oPagina.Response.ShowDialogoOnTop(PathPagina + Parametros,800,600);
			
			
			}
			


			
		</script>
		<!--oncontextmenu="return false" -->
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<tr>
						<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
					</tr>
					<TR>
						<TD class="RutaPaginaActual" style="HEIGHT: 14px" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera> Información Financiera ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Agenda</asp:label></TD>
					</TR>
					<TR>
						<TD align="center">
							<TABLE id="Table3" style="WIDTH: 772px; HEIGHT: 26px" cellSpacing="1" cellPadding="1" width="772"
								border="0">
								<TR>
									<TD style="WIDTH: 44px"><asp:label id="Label1" runat="server" CssClass="normaldetalle">FECHA:</asp:label></TD>
									<TD><ew:calendarpopup id="CalFecha" runat="server" CssClass="normaldetalle" Width="72px" ImageUrl="../imagenes/BtPU_Mas.gif"
											CalendarLocation="Bottom" AllowArbitraryText="False" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar"
											MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:" PadSingleDigits="True"
											Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" AutoPostBack="True">
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
									<TD></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td align="center" width="100%">
							<TABLE id="Table1" style="WIDTH: 773px; HEIGHT: 26px" cellSpacing="1" cellPadding="1" width="773"
								border="0">
								<TR>
									<TD style="WIDTH: 41px"></TD>
									<TD align="left">
										<TABLE id="tblHeaderAgenda" style="WIDTH: 704px; HEIGHT: 26px" cellSpacing="0" cellPadding="0"
											width="704" align="left" border="0" runat="server">
											<TR>
												<TD class="HeaderListView" align="center" width="113">s</TD>
												<TD class="HeaderListView" align="center" width="113">s</TD>
												<TD class="HeaderListView" align="center" width="113">s</TD>
												<TD class="HeaderListView" align="center" width="113">s</TD>
												<TD class="HeaderListView" align="center" width="113">s</TD>
												<TD class="HeaderListView" align="center" width="113">s</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD vAlign="top" align="center" width="100%">
							<div id="scroll" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; OVERFLOW: auto; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; HEIGHT: 360px"
								onscroll="DayPilotCalendar_cv('ctl00_ContentPlaceHolder1_DayPilotCalendar1_ev_', this);"
								align="center"><DAYPILOT:DAYPILOTCALENDAR 
      id=DayPilotCalendar1 runat="server" 
      EndDate="2007-03-21" DataSource="<%# getData %>" HourHeight="30" 
      BeginColumnName="start" EndColumnName="end" NameColumnName="name" 
      PkColumnName="id" JavaScriptEventAction="MostrarDetalle('Event ID: {0}');" 
      TimeFormat="Clock12Hours" NonBusinessHours="AlwaysVisible" 
      Width="746"></DAYPILOT:DAYPILOTCALENDAR></div>
						</TD>
						<td></td>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="100%">
							<TABLE id="Table2" style="WIDTH: 746px; HEIGHT: 23px" cellSpacing="1" cellPadding="1" width="746"
								border="0">
								<TR>
									<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif">
										<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="AdministrarDetalleAgenda.aspx">HyperLink</asp:HyperLink></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TR></TBODY></TABLE>
	</body>
</HTML>
