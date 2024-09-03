<%@ Page language="c#" Codebehind="DetalleProgramacionCapacitacionII.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.DetalleProgramacionCapacitacionII" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleProgramacionCapacitacionII</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="/SimaNetWeb/js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script>
			function txtArea_ItemDataBound(sender,e,dr){
				jNet.get("hidArea").value=dr["IDAREA"];
				jNet.get("hNombreArea").value=dr["IDAREA"];
				//alert(jNet.get("CalFechaInicio").value);
			}
			
			function txtCapacitador_ItemDataBound(sender,e,dr){
				jNet.get('hIdCapacitador').value = dr["idpersonal"];
			}
			
			var CCTT_CapacitacionProgRespUI= new Object();
			
			CCTT_CapacitacionProgRespUI.WindowsProgSeleccion;
			CCTT_CapacitacionProgRespUI.Eliminar=function(idArea){
				__doPostBack('btnEliminar',idArea);	
			}
			CCTT_CapacitacionProgRespUI.ListarProgPersonal=function(){
				var URL='/' + ApplicationPath +'/GestionSeguridadIndustrial/AdministrarCapacitacionListaAsistencia.aspx';
				CCTT_CapacitacionProgRespUI.WindowsProgSeleccion= (new System.Ext.UI.WebControls.Windows()).Dialogo('PROGRAMACIONES DISPONIBLES',URL,this,300,400);
			}
			CCTT_CapacitacionProgRespUI.SeleccionarProgramacionPersonal =function(idSelccion,Periodo,Descripcion){
				jNet.get('hIdSeleccion').value = idSelccion;
				jNet.get('hPeriodoSeleccion').value = Periodo;
				jNet.get('txtProgSelec').value = Descripcion;
				CCTT_CapacitacionProgRespUI.WindowsProgSeleccion.close();
			}
			
			
		</script>
	</HEAD>
	<body onkeypress="if(event.keyCode==13)return false;" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de seguridad></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> >Programación de capacitación></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE style="WIDTH: 1102px" id="Table2" border="0" cellSpacing="5" cellPadding="5" width="1102">
							<TR>
								<TD style="HEIGHT: 41px" bgColor="#000080" align="center"><asp:label style="Z-INDEX: 0" id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"
										Width="305px" Height="21px"> PROGRAMACION DE CAPACITACION</asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left">
									<TABLE style="Z-INDEX: 0" id="Table4" border="0" cellSpacing="1" cellPadding="1" width="100%"
										align="left">
										<TR>
											<TD class="HeaderGrilla" noWrap><asp:label id="Label1" runat="server" CssClass="HeaderGrilla" Height="8px"> Nro Prog.</asp:label></TD>
											<TD width="100%" colSpan="5"><asp:textbox id="txtNroProg" runat="server" CssClass="normaldetalle" Width="96px"></asp:textbox></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderGrilla" noWrap>
												<asp:label style="Z-INDEX: 0" id="Label13" runat="server" CssClass="HeaderGrilla" Height="8px">TIPO:</asp:label></TD>
											<TD width="100%" colSpan="5">
												<asp:DropDownList id="ddlTipo" runat="server" CssClass="normaldetalle" Width="100%"></asp:DropDownList></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderGrilla" align="left"><asp:label style="Z-INDEX: 0" id="Label7" runat="server" Height="8px"> ASUNTO:</asp:label></TD>
											<TD colSpan="5"><asp:textbox style="Z-INDEX: 0" id="txtMotivo" runat="server" CssClass="normaldetalle" Width="100%"
													Height="72px" TextMode="MultiLine"></asp:textbox></TD>
											<TD><INPUT style="WIDTH: 67px; HEIGHT: 22px" id="hIdSeleccion" value="0" size="5" type="hidden"
													runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 67px; HEIGHT: 22px" id="hPeriodoSeleccion" value="0" size="5"
													type="hidden" name="Hidden1" runat="server"></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderGrilla" align="left"><asp:label style="Z-INDEX: 0" id="Label9" runat="server" Height="8px">SELECCION PERSONAL:</asp:label></TD>
											<TD colSpan="5"><asp:textbox id="txtProgSelec" runat="server" CssClass="normaldetalle" Width="100%" Height="50px"
													TextMode="MultiLine" ReadOnly="True"></asp:textbox></TD>
											<TD><IMG style="Z-INDEX: 0" id="imgSeleccPersonal" title="Seleccionar Programa de personal disponible"
													onclick="CCTT_CapacitacionProgRespUI.ListarProgPersonal();" alt="" src="../imagenes/BtPU_Mas.gif"
													runat="server"></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD height="100%" vAlign="top" width="1%" align="right"><INPUT style="Z-INDEX: 0; WIDTH: 44px; HEIGHT: 22px" id="hIdCapacitador" size="2" type="hidden"
										name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 44px; HEIGHT: 22px" id="hNombreArea" size="2" type="hidden"
										name="Hidden1" runat="server"><INPUT style="WIDTH: 44px; HEIGHT: 22px" id="hidArea" size="2" type="hidden" runat="server"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 29px" height="29" vAlign="top" width="1%" align="left"><asp:label style="Z-INDEX: 0" id="Label11" runat="server" Width="584px" Height="21px" Font-Bold="True">AREAS QUE BRINDARAN CAPACITACION</asp:label></TD>
							</TR>
							<TR>
								<TD id="LstUser" height="100%" vAlign="top" width="1%" align="right" runat="server">
									<TABLE style="BORDER-BOTTOM: dimgray 1px solid; BORDER-LEFT: dimgray 1px solid; BORDER-TOP: dimgray 1px solid; BORDER-RIGHT: dimgray 1px solid"
										id="tblDetalle" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD class="HeaderGrilla" rowSpan="2"><asp:label style="Z-INDEX: 0" id="Label2" runat="server">AREA:</asp:label></TD>
											<TD class="HeaderGrilla" rowSpan="2"><asp:label style="Z-INDEX: 0" id="Label10" runat="server">CAPACITADOR:</asp:label></TD>
											<TD class="HeaderGrilla" rowSpan="2" align="center"><asp:label style="Z-INDEX: 0" id="Label12" runat="server">Requiere evaluación</asp:label></TD>
											<TD class="HeaderGrilla" colSpan="2" align="center"><asp:label style="Z-INDEX: 0" id="Label8" runat="server">FECHA:</asp:label></TD>
											<TD class="HeaderGrilla" rowSpan="2" width="60%"><asp:label style="Z-INDEX: 0" id="Label6" runat="server">HORA INICIO:</asp:label></TD>
											<TD rowSpan="3"><asp:imagebutton style="Z-INDEX: 0" id="imgAgregar" runat="server" Width="42px" Height="39px" ImageUrl="../imagenes/Navegador/Plus.png"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label3" runat="server">INICIO:</asp:label></TD>
											<TD class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label4" runat="server">TERMINO:</asp:label></TD>
										</TR>
										<TR>
											<TD width="50%"><asp:textbox style="Z-INDEX: 0" id="txtArea" runat="server" Width="100%"></asp:textbox></TD>
											<TD width="50%"><asp:textbox style="Z-INDEX: 0" id="txtCapacitador" runat="server" Width="100%"></asp:textbox></TD>
											<TD vAlign="middle" noWrap align="center"><asp:checkbox style="Z-INDEX: 0" id="chkRequiereEva" runat="server" Text=" "></asp:checkbox></TD>
											<TD noWrap><ew:calendarpopup style="Z-INDEX: 0" id="CalFechaInicio" runat="server" CssClass="normaldetalle" Width="60px"
													ImageUrl="../imagenes/BtPU_Mas.gif" AllowArbitraryText="False" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar"
													MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:" ClearDateText="Limpiar Fecha"
													ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True">
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
											<TD noWrap><ew:calendarpopup style="Z-INDEX: 0" id="calFechaTermino" runat="server" CssClass="normaldetalle"
													Width="60px" ImageUrl="../imagenes/BtPU_Mas.gif" AllowArbitraryText="False" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar"
													MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:" ClearDateText="Limpiar Fecha"
													ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True">
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
											<TD noWrap><ew:timepicker style="Z-INDEX: 0" id="tmHoraInicio" runat="server" Width="70px" ImageUrl="../imagenes/BtPU_fecha.gif"
													ControlDisplay="TextBoxImage" PopupWidth="140px" PopupLocation="Bottom" CellSpacing="2px">
													<ButtonStyle BackColor="White"></ButtonStyle>
													<TextboxLabelStyle CssClass="normaldetalle" BackColor="White"></TextboxLabelStyle>
													<ClearTimeStyle CssClass="normaldetalle" BackColor="White"></ClearTimeStyle>
													<TimeStyle Font-Size="8pt" ForeColor="Navy" BackColor="#E0E0E0"></TimeStyle>
													<SelectedTimeStyle Font-Size="7pt" BackColor="White"></SelectedTimeStyle>
												</ew:timepicker></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD height="100%" vAlign="top" width="1%" align="right"><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" CssClass="HeaderGrilla" Width="100%"
										PageSize="20" AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle Height="20px" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreAreaResponsable" HeaderText="AREA">
												<HeaderStyle Width="25%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ApellidosyNombresCapacitador" HeaderText="CAPACITADOR">
												<HeaderStyle Width="25%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="REQ&lt;BR&gt;EVALUA">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemTemplate>
													<asp:CheckBox id="chkReqEva" runat="server" Text=" " Enabled="False"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="FechaInicio" HeaderText="FECHA INICIO">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FechaFin" HeaderText="FECHA TERMINO">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="HoraInicio" HeaderText="HORA INI">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemTemplate>
													<IMG style="Z-INDEX: 0" id="imgEliminar" src="../imagenes/Filtro/Eliminar.gif" runat="server">
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD height="100%" vAlign="top" width="1%" align="right">
									<TABLE style="WIDTH: 182px; HEIGHT: 30px" id="Table3" border="0" cellSpacing="1" cellPadding="1"
										width="182">
										<TR>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnAceptar" runat="server" Height="22px" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt=""
													src="../imagenes/bt_cancelar.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD bgColor="#f0f0f0" align="center"><asp:button id="btnEliminar" runat="server" Text="Eliminar"></asp:button></TD>
							</TR>
							<TR>
								<TD style="DISPLAY: none" colSpan="4" align="left"><INPUT style="WIDTH: 24px; HEIGHT: 22px" id="hIdTrabajador" size="1" type="hidden" name="hIdTrabajador"
										runat="server"><INPUT style="WIDTH: 24px; HEIGHT: 22px" id="hIdCentroMedico" size="1" type="hidden" name="hIdCentroMedico"
										runat="server">
									<TABLE style="Z-INDEX: 0; WIDTH: 424px; HEIGHT: 34px" id="WDetalleCM" border="0">
										<tr>
											<td class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label5" runat="server" CssClass="HeaderGrilla" Height="8px">Nombre Centro Medico:</asp:label></td>
										</tr>
										<TR>
											<TD><asp:textbox id="txtNombreCM" runat="server" Width="100%"></asp:textbox></TD>
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
			<script>
					//Configuracion de Busqueda para Areas
						var oParamCollecionBusqueda = new ParamCollecionBusqueda();
						var oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="NombreArea";
							oParamBusqueda.Texto="Area";
							oParamBusqueda.LongitudEjecucion=1;
							oParamBusqueda.CampoAlterno = "NroArea";
							oParamBusqueda.Tipo="C";
							oParamBusqueda.LongitudEjecucion=2;
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="idProceso";
							oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarArea;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						(new AutoBusqueda('txtArea')).Crear( '/' + ApplicationPath + '/Personal/Procesar.aspx?',oParamCollecionBusqueda);
						
						
						oParamCollecionBusqueda = new ParamCollecionBusqueda();
						oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre='Nombres';
						oParamBusqueda.Texto='Apellidos y Nombres';
						oParamBusqueda.LongitudEjecucion=1;
						oParamBusqueda.Tipo='C';
						oParamBusqueda.CampoAlterno = 'NroPersonal';
						oParamBusqueda.LongitudEjecucion=4;
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

						oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre='idProceso';
						oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarPersonal;
						oParamBusqueda.Tipo='Q';
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

						(new AutoBusqueda("txtCapacitador")).Crear('/' + ApplicationPath + '/GestionFinanciera/Procesar.aspx?',oParamCollecionBusqueda);		
						
						
			</script>
		</form>
		<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
