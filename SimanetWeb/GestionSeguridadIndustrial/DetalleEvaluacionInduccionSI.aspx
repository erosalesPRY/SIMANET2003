<%@ Page language="c#" Codebehind="DetalleEvaluacionInduccionSI.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.DetalleEvaluacionInduccionSI" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrar Programación Trabajadores Contratista</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="/SimaNetWeb/js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script>
				function txtTrabajador_ItemDataBound(sender,e,dr){
					var otxtTrabajador= document.getElementById("txtTrabajador");
					var ohNroDNI = document.getElementById("hNroDNI");
					var Disponible = dr["Disponible"].toString();
					var Habilitado = dr["Habilitado"].toString();
					
					if((Disponible=='SI')&&(Habilitado=='SI')){
						ohNroDNI.value = dr["NroDNI"].toString();
					}
					else if((Disponible=='SI')&&(Habilitado=='NO')){
						var strFecha ='\n \n INICIO:'+ dr["FechaInicio"].toString() + '  VENCIMIENTO:'+ dr["FechaVencimiento"].toString();
						 Ext.MessageBox.alert('EXAMEN MEDICO', 'Registro de ficha medica del trabajador no se encuentra habilitado \n ya sea por que aun no entra en vigencia o se encuentra vencida :='+ strFecha  , function(btn){});
						 otxtTrabajador.value='';
					}
					else if((Disponible=='NO')&&(Habilitado=='SI')){
						 Ext.MessageBox.alert('EXAMEN MEDICO', 'Registro de ficha medica del trabajador no se encuentra disponible', function(btn){});
						 otxtTrabajador.value='';
					}
					else if((Disponible=='NO')&&(Habilitado=='NO')){
						 Ext.MessageBox.alert('EXAMEN MEDICO', 'Registro de ficha medica del trabajador aun no entra en vigencia o se encuentra vencida \n o no se encuentra disponible ', function(btn){});
						 otxtTrabajador.value='';
					}
					var strApellidosNombres = otxtTrabajador.value;
				}
		</script>
	</HEAD>
	<body onkeypress="if(event.keyCode==13)return false;" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD>
						<uc1:Header id="Header1" runat="server"></uc1:Header>
					</TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu>
					</TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de seguridad></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> > Detalle examen medico historia></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE style="WIDTH: 812px; HEIGHT: 200px" id="Table2" border="0" cellSpacing="5" cellPadding="5"
							width="812">
							<TR>
								<TD align="center" style="HEIGHT: 41px" bgColor="#000080">
									<asp:label style="Z-INDEX: 0" id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"
										Height="16px" Width="301px">DETALLE EVALUACION INDUCCION</asp:label></TD>
							</TR>
							<TR>
								<TD align="left" vAlign="top">
									<TABLE style="Z-INDEX: 0" id="Table4" border="0" cellSpacing="1" cellPadding="1" width="100%"
										align="left">
										<TR>
											<TD class="HeaderGrilla" noWrap>
												<asp:Label id="Label1" runat="server" CssClass="HeaderGrilla" Height="8px">Apellidos y Nombres</asp:Label></TD>
											<TD width="100%" colSpan="3">
												<asp:TextBox id="txtTrabajador" runat="server" CssClass="normaldetalle" Width="100%"></asp:TextBox></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderGrilla" align="left">
												<asp:Label style="Z-INDEX: 0" id="Label3" runat="server" Height="8px">FECHA INICIO:</asp:Label></TD>
											<TD>
												<ew:calendarpopup style="Z-INDEX: 0" id="CalFechaInicio" runat="server" CssClass="normaldetalle" Width="60px"
													SelectedDate="2009-06-15" ImageUrl="../imagenes/BtPU_Mas.gif" AllowArbitraryText="False" GoToTodayText="Hoy :"
													MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:"
													ClearDateText="Limpiar Fecha" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)"
													PadSingleDigits="True" JavascriptOnChangeFunction="ValidaFechaConFechaSeguro">
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
											<TD class="HeaderGrilla" noWrap>
												<asp:Label style="Z-INDEX: 0" id="Label4" runat="server" Height="8px">FECHA VENCIMIENTO:</asp:Label></TD>
											<TD>
												<ew:calendarpopup style="Z-INDEX: 0" id="CalFechVence" runat="server" CssClass="normaldetalle" Width="60px"
													JavascriptOnChangeFunction="ValidaFechaConFechaSeguro" PadSingleDigits="True" Culture="Spanish (Chile)"
													ControlDisplay="TextBoxImage" ShowGoToToday="True" ClearDateText="Limpiar Fecha" NullableLabelText="Seleccione una fecha:"
													MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar" GoToTodayText="Hoy :" AllowArbitraryText="False"
													ImageUrl="../imagenes/BtPU_Mas.gif" SelectedDate="2009-06-15">
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
										</TR>
										<TR>
											<TD class="HeaderGrilla">
												<asp:Label style="Z-INDEX: 0" id="Label2" runat="server" Height="8px">ESTADO:</asp:Label></TD>
											<TD>
												<asp:CheckBox id="chkAprobado" runat="server" CssClass="normaldetalle" Text="APROBADO"></asp:CheckBox></TD>
											<TD class="HeaderGrilla">
												<asp:Label style="Z-INDEX: 0" id="Label6" runat="server" Height="8px">NOTA:</asp:Label></TD>
											<TD>
												<ew:numericbox style="Z-INDEX: 0" id="nNota" runat="server" CssClass="normaldetalle" Width="60px"
													DollarSign=" " AutoFormatCurrency="True" PositiveNumber="True" MaxLength="10" TextAlign="Right">0</ew:numericbox></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" width="1%" align="right" height="100%">
									<TABLE style="WIDTH: 182px; HEIGHT: 30px" id="Table3" border="0" cellSpacing="1" cellPadding="1"
										width="182">
										<TR>
											<TD>
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnAceptar" runat="server" Height="22px" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt=""
													src="../imagenes/bt_cancelar.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD bgColor="#f0f0f0" align="center"><INPUT style="WIDTH: 30px; HEIGHT: 22px" id="hNroDNI" size="1" type="hidden" runat="server"></TD>
							</TR>
							<TR>
								<TD colSpan="4" align="left" style="DISPLAY: none"><INPUT style="WIDTH: 24px; HEIGHT: 22px" id="hIdTrabajador" size="1" type="hidden" runat="server"
										NAME="hIdTrabajador"><INPUT style="WIDTH: 24px; HEIGHT: 22px" id="hIdCentroMedico" size="1" type="hidden" runat="server"
										NAME="hIdCentroMedico">
									<TABLE style="Z-INDEX: 0; WIDTH: 424px; HEIGHT: 34px" id="WDetalleCM" border="0">
										<tr>
											<td class="HeaderGrilla">
												<asp:Label style="Z-INDEX: 0" id="Label5" runat="server" CssClass="HeaderGrilla" Height="8px">Nombre Centro Medico:</asp:Label>
											</td>
										</tr>
										<TR>
											<TD>
												<asp:TextBox id="txtNombreCM" runat="server" Width="100%"></asp:TextBox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="DISPLAY: block" align="center"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<SCRIPT>
		
						var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
						var oParamCollecionBusqueda = new ParamCollecionBusqueda();
						var oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="ApellidosyNombres";
							oParamBusqueda.Texto="Trabajador";
							oParamBusqueda.LongitudEjecucion=2;
							oParamBusqueda.CampoAlterno="NroDNI";
							oParamBusqueda.Tipo="C";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);


							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="idProceso";
							oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarTrabajadorExamenMedico;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

						(new AutoBusqueda('txtTrabajador')).Crear( '/' + ApplicationPath + '/GestionSeguridadIndustrial/Procesar.aspx?',oParamCollecionBusqueda);
					
							
						
							
												
						
		</SCRIPT>
	</body>
</HTML>
