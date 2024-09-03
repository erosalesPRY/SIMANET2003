<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleExamenMedico.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.DetalleExamenMedico" %>
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
					document.getElementById("hIdTrabajador").value = dr["NroDNI"];
				}
				function txtCentroMedico_ItemDataBound(sender,e,dr){
					document.getElementById("hIdCentroMedico").value = dr["CODIGO"];
				}
				
				function AddCentroMedico(){
					document.getElementById('txtNombreCM').value = document.getElementById('txtCentroMedico').value.toString().toUpperCase();
					(new System.Ext.UI.WebControls.Windows()).DetalleFromEL('MiVentana','WDetalleCM','Agregar centro medico',440,140,AceptarCM);
				}
				function AceptarCM(){
						var idOP=(new Controladora.General.CTablaTablas()).Insertar(document.getElementById('txtNombreCM').value);
						 document.getElementById('hIdCentroMedico').value= idOP;
						Ext.getCmp('MiVentana').hide();
				}
				
				
				function RegistrarTrabajador(){
					var KEYVALORTEXTO="ValTexto";
					var KEYQDNI ="NroDNI";
					var KEYQORIGEN="ORG"
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					
					if(oPagina.Request.Params[SIMA.Utilitario.Constantes.KEYMODOPAGINA].toString()==SIMA.Utilitario.Enumerados.ModoPagina.N){
						var URLDETALLETRABAJADOR = '/' + ApplicationPath + '/Personal/Contratista/DetalleTrabajador.aspx?' 
								+ SIMA.Utilitario.Constantes.KEYMODOPAGINA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + SIMA.Utilitario.Enumerados.ModoPagina.N.toString()
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQDNI + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + ""
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYVALORTEXTO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + document.getElementById("txtTrabajador").value
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQORIGEN + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + "EXAMENMEDICO";
						
							(new SIMA.Utilitario.Helper.Response()).ShowDialogoNoModal(URLDETALLETRABAJADOR,610,200);
					}
				}
				
				function MostrarTrabajadorAgregado(){
					if(document.body.tag == "remoto"){
						document.getElementById("hIdTrabajador").value =document.body.DNI;
						document.getElementById("txtTrabajador").value =document.body.ApellidosNombres;
					}
					document.body.tag ="local";		
				}
				
				function ValidaRespuesta(btn){
					alert(btn);
				}
		</script>
	</HEAD>
	<body onkeypress="if(event.keyCode==13)return false;" onclick="MostrarTrabajadorAgregado();"
		onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
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
										Height="8px" Width="160px">DETALLE EXAMEN MEDICO</asp:label></TD>
							</TR>
							<TR>
								<TD align="left" vAlign="top">
									<TABLE style="Z-INDEX: 0" id="Table4" border="0" cellSpacing="1" cellPadding="1" width="100%"
										align="left">
										<TR>
											<TD class="HeaderGrilla" noWrap>
												<asp:Label id="Label1" runat="server" CssClass="HeaderGrilla" Height="8px">Apellidos y Nombres</asp:Label></TD>
											<TD width="100%" colSpan="5">
												<asp:TextBox id="txtTrabajador" runat="server" CssClass="normaldetalle" Width="100%"></asp:TextBox></TD>
											<TD></TD>
											<TD><IMG style="Z-INDEX: 0" id="btnAgregarTrabajador" title="Crear un nuevo proveedor" onclick="RegistrarTrabajador();"
													alt="" src="../imagenes/BtPU_Mas.gif" runat="server"></TD>
										</TR>
										<TR>
											<TD class="HeaderGrilla" align="left">
												<asp:Label style="Z-INDEX: 0" id="Label2" runat="server" Height="8px">CENTRO MEDICO</asp:Label></TD>
											<TD colSpan="5">
												<asp:TextBox style="Z-INDEX: 0" id="txtCentroMedico" runat="server" CssClass="normaldetalle"
													Width="100%"></asp:TextBox></TD>
											<TD></TD>
											<TD><IMG style="Z-INDEX: 0" id="btnCentroMedico" title="Crear un nuevo centro medico" onclick="AddCentroMedico();"
													alt="" src="../imagenes/BtPU_Mas.gif"></TD>
										</TR>
										<TR>
											<TD class="HeaderGrilla" align="left">
												<asp:Label style="Z-INDEX: 0" id="Label7" runat="server" Height="8px">TIPO EMO:</asp:Label></TD>
											<TD colSpan="5">
												<asp:DropDownList id="ddlTipoEMO" runat="server" CssClass="normaldetalle" Width="100%"></asp:DropDownList></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderGrilla" align="left">
												<asp:Label style="Z-INDEX: 0" id="Label8" runat="server" Height="8px">APTITUD:</asp:Label></TD>
											<TD width="50%">
												<asp:DropDownList style="Z-INDEX: 0" id="ddlActitud" runat="server" CssClass="normaldetalle" Width="100%"></asp:DropDownList></TD>
											<TD class="HeaderGrilla" align="left">
												<asp:Label style="Z-INDEX: 0" id="Label9" runat="server" Height="8px">TOXICOLOGICO:</asp:Label></TD>
											<TD width="50%">
												<asp:DropDownList style="Z-INDEX: 0" id="ddlToxicologico" runat="server" CssClass="normaldetalle"
													Width="100%"></asp:DropDownList></TD>
											<TD class="HeaderGrilla">
												<asp:Label style="Z-INDEX: 0" id="Label10" runat="server" Height="8px">HABILITADO:</asp:Label></TD>
											<TD>
												<asp:Label style="Z-INDEX: 0" id="LblHabilitado" runat="server" CssClass="normaldetalle" Height="8px"
													Font-Bold="True"></asp:Label></TD>
											<TD></TD>
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
													PadSingleDigits="True" JavascriptOnChangeFunction="ValidaFechaConFechaSeguro" DisableTextboxEntry="False">
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
													ImageUrl="../imagenes/BtPU_Mas.gif" SelectedDate="2009-06-15" DisableTextboxEntry="False">
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
											<TD class="HeaderGrilla">
												<asp:Label style="Z-INDEX: 0" id="Label6" runat="server" Height="8px">DISPONIBLE:</asp:Label></TD>
											<TD>
												<asp:Label style="Z-INDEX: 0" id="LblDisponible" runat="server" CssClass="normaldetalle" Height="8px"
													Font-Bold="True"></asp:Label></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderGrilla"></TD>
											<TD></TD>
											<TD class="HeaderGrilla"></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
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
								<TD bgColor="#f0f0f0" align="center"></TD>
							</TR>
							<TR>
								<TD colSpan="4" align="left" style="DISPLAY: none"><INPUT style="WIDTH: 24px; HEIGHT: 22px" id="hIdTrabajador" size="1" type="hidden" runat="server"><INPUT style="WIDTH: 24px; HEIGHT: 22px" id="hIdCentroMedico" size="1" type="hidden" runat="server">
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
							oParamBusqueda.Nombre="ApellidoyNombres";
							oParamBusqueda.Texto="Trabajador";
							oParamBusqueda.LongitudEjecucion=2;
							oParamBusqueda.CampoAlterno="NroDNI";
							oParamBusqueda.Tipo="C";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);


							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="idProceso";
							oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarTrabajadorCCTT;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

						(new AutoBusqueda('txtTrabajador')).Crear( '/' + ApplicationPath + '/GestionSeguridadIndustrial/Procesar.aspx?',oParamCollecionBusqueda);
					
							
						//Configuracion de Busqueda para Areas
						var oParamCollecionBusqueda = new ParamCollecionBusqueda();
						var oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="Descripcion";
							oParamBusqueda.Texto="Centro Medico";
							oParamBusqueda.LongitudEjecucion=1;
							oParamBusqueda.CampoAlterno = "Codigo";
							oParamBusqueda.Tipo="C";
							oParamBusqueda.LongitudEjecucion=2;
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="idProceso";
							oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarItemTablaGeneral;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						(new AutoBusqueda('txtCentroMedico')).Crear('/' + ApplicationPath + '/GestionSeguridadIndustrial/Procesar.aspx?',oParamCollecionBusqueda);							
							
							
												
						
		</SCRIPT>
		<SCRIPT language="javascript" src="/SimaNetWeb/js/@Import.js"></SCRIPT>
	</body>
</HTML>
