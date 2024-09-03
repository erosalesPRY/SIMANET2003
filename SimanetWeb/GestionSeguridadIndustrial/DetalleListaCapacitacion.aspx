<%@ Page language="c#" Codebehind="DetalleListaCapacitacion.aspx.cs"   AutoEventWireup="true"    Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.DetalleListaCapacitacion" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
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
				var ListarProgSeleccionPersonal=Object();
							
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var KEYQPERIODO = "Periodo";
				var KEYQSELECCION = "IdSelec";


				function txtNroDNI_ItemDataBound(sender,e,dr){
					//jNet.get('txtApellidosyNombres').value=dr["ApellidosNombres"];
					//__doPostBack('btnFiltar','');
				}


				function txtTrabajador_ItemDataBound(sender,e,dr){
					document.getElementById("hIdTrabajador").value = dr["NroDNI"];
				}
				
				function txtApellidos_ItemDataBound(sender,e,dr){
					try{
						ListarProgSeleccionPersonal.Agregar(PersonaCapacitacionBE(dr,2));
					}
					catch(SIMAExcepcionDominio){
						Ext.MessageBox.alert('Validación', 'PAGINA:' + SIMAExcepcionDominio.Pagina +'</br>PARAMETROS:'+ SIMAExcepcionDominio.Parametros +'</br>PROCESO:'+ SIMAExcepcionDominio.Proceso +'</br>MENSAJE:'+SIMAExcepcionDominio.Mensaje);
					}
					jNet.get('txtApellidos').value='';
					__doPostBack('btnPost','');
				}
				
				function txtPR_ItemDataBound(sender,e,dr){
					try{
						ListarProgSeleccionPersonal.Agregar(PersonaCapacitacionBE(dr,1));
					}
					catch(SIMAExcepcionDominio){
						Ext.MessageBox.alert('Validación', 'PAGINA:' + SIMAExcepcionDominio.Pagina +'</br>PARAMETROS:'+ SIMAExcepcionDominio.Parametros +'</br>PROCESO:'+ SIMAExcepcionDominio.Proceso +'</br>MENSAJE:'+SIMAExcepcionDominio.Mensaje);
					}
					jNet.get('txtApellidos').value='';
					__doPostBack('btnPost','');
				}
				
				function PersonaCapacitacionBE(dr,Field){
					var oPersonaCapacitacionBE = new EntidadesNegocio.GestionSeguridadIndustrial.PersonaCapacitacionBE();
					if(oPagina.Request.Params[SIMA.Utilitario.Constantes.KEYMODOPAGINA]==SIMA.Utilitario.Enumerados.ModoPagina.N){
						oPersonaCapacitacionBE.Periodo = 0;
						oPersonaCapacitacionBE.IdSeleccion = 0;
					}
					else{
						oPersonaCapacitacionBE.Periodo = oPagina.Request.Params[KEYQPERIODO];
						oPersonaCapacitacionBE.IdSeleccion = oPagina.Request.Params[KEYQSELECCION];
					}
					var ID = ((Field==1)?"IdPersonal":"idpersonal");
					oPersonaCapacitacionBE.IdPersonal = dr[ID];
					oPersonaCapacitacionBE.NroPersonal = dr["NroPersonal"];
					oPersonaCapacitacionBE.NroDNI = dr["NroDocIdentidad"];
					oPersonaCapacitacionBE.ApellidosyNombres= dr["Nombres"];
					oPersonaCapacitacionBE.NombreArea= dr["NombreArea"];
					oPersonaCapacitacionBE.IdEstado = 1;	
					
					return	oPersonaCapacitacionBE;
				}
				
				
				
				
				ListarProgSeleccionPersonal.Agregar = function(oPersonaCapacitacionBE){
															(new Controladora.SeguridadIndustrial.CCCTT_PersonalCapacitacion()).InsertarActualiza(oPersonaCapacitacionBE);
													  }
				ListarProgSeleccionPersonal.Eliminar = function(oPersonaCapacitacionBE){
															(new Controladora.SeguridadIndustrial.CCCTT_PersonalCapacitacion()).Eliminar(oPersonaCapacitacionBE);
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
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de seguridad></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> > Detalle Lista disponible></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE style="WIDTH: 812px; HEIGHT: 200px" id="Table2" border="0" cellSpacing="5" cellPadding="5"
							width="812">
							<TR>
								<TD style="HEIGHT: 41px" bgColor="#000080" align="center"><asp:label style="Z-INDEX: 0" id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"
										Height="21px" Width="305px">DETALLE PERSONAL DISPONIBLE CAPACITACION</asp:label></TD>
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
											<TD class="HeaderGrilla" align="left"><asp:label style="Z-INDEX: 0" id="Label2" runat="server" Height="8px"> FECHA:</asp:label></TD>
											<TD colSpan="5"><ew:calendarpopup style="Z-INDEX: 0" id="CalFechaInicio" runat="server" CssClass="normaldetalle" Width="60px"
													DisableTextboxEntry="False" JavascriptOnChangeFunction="ValidaFechaConFechaSeguro" PadSingleDigits="True"
													Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" ClearDateText="Limpiar Fecha"
													NullableLabelText="Seleccione una fecha:" MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar"
													GoToTodayText="Hoy :" AllowArbitraryText="False" ImageUrl="../imagenes/BtPU_Mas.gif" SelectedDate="2009-06-15">
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
										<TR>
											<TD class="HeaderGrilla" align="left"><asp:label style="Z-INDEX: 0" id="Label7" runat="server" Height="8px"> MOTIVO:</asp:label></TD>
											<TD colSpan="5"><asp:textbox style="Z-INDEX: 0" id="txtMotivo" runat="server" CssClass="normaldetalle" Height="72px"
													Width="100%" TextMode="MultiLine"></asp:textbox></TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD height="100%" vAlign="top" width="1%" align="right"><INPUT id="hIdPersonal" type="hidden"></TD>
							</TR>
							<TR>
								<TD height="100%" vAlign="top" width="1%" align="left">
									<TABLE id="Table5" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD noWrap class=HeaderGrilla>
<asp:label style="Z-INDEX: 0" id=Label6 runat="server" CssClass="HeaderGrilla" Height="8px">Nro DNI.:</asp:label></TD>
											<TD width="20%">
<asp:textbox style="Z-INDEX: 0" id=txtNroDNI runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
											<TD noWrap class=HeaderGrilla><asp:label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="HeaderGrilla" Height="8px">Nro Porta Retrato:</asp:label></TD>
											<TD width="20%"><asp:textbox style="Z-INDEX: 0" id="txtPR" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
                <TD class=HeaderGrilla noWrap><asp:label style="Z-INDEX: 0" id="Label4" runat="server" CssClass="HeaderGrilla" Height="8px">Apellidos y Nombres:</asp:label></TD>
                <TD width="80%"><asp:textbox style="Z-INDEX: 0" id="txtApellidos" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD id="LstUser" height="100%" vAlign="top" width="1%" align="right" runat="server"></TD>
							</TR>
							<TR>
								<TD height="100%" vAlign="top" width="1%" align="right"><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" CssClass="HeaderGrilla" Width="100%"
										RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" PageSize="20">
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
											<asp:BoundColumn DataField="NroPersonal" HeaderText="NRO PR.">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroDNI" HeaderText="DNI">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ApellidosyNombres" HeaderText="APELLIDOS Y NOMBRES">
												<HeaderStyle Width="50%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreArea" HeaderText="AREA">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemTemplate>
													<IMG style="Z-INDEX: 0" id="imgAsistencia" src="../imagenes/Filtro/Aprobar.gif" runat="server">
												</ItemTemplate>
											</asp:TemplateColumn>
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
								<TD bgColor="#f0f0f0" align="center">
									<asp:Button id="btnPost" runat="server" Text="Post"></asp:Button></TD>
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
		</form>
		<SCRIPT>
					var oParamCollecionBusqueda = new ParamCollecionBusqueda();
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

						(new AutoBusqueda("txtApellidos")).Crear('/' + ApplicationPath + '/GestionFinanciera/Procesar.aspx?',oParamCollecionBusqueda);		
						
						oParamCollecionBusqueda = new ParamCollecionBusqueda();
						oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre='NroPersonal';
						oParamBusqueda.Texto='Nro Personal';
						oParamBusqueda.LongitudEjecucion=1;
						oParamBusqueda.Tipo='C';
						oParamBusqueda.CampoAlterno = 'Nombres';
						oParamBusqueda.LongitudEjecucion=4;
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

						oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre='idProceso';
						oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscaPersonaSIMA;
						oParamBusqueda.Tipo='Q';
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

						(new AutoBusqueda("txtPR")).Crear('/' + ApplicationPath + '/GestionSeguridadIndustrial/Procesar.aspx?',oParamCollecionBusqueda);		
						
						
						/*Configura la busqueda de personas ajenas al maestro de personal*/
						
								var oParamCollecionBusqueda1 = new ParamCollecionBusqueda();
								var oParamBusqueda1 = new ParamBusqueda();
									oParamBusqueda1.Nombre="NroDNI";
									oParamBusqueda1.Texto="Trabajador";
									oParamBusqueda1.LongitudEjecucion=2;
									oParamBusqueda1.CampoAlterno="ApellidosNombres";
									oParamBusqueda1.Tipo="C";
								oParamCollecionBusqueda1.Agregar(oParamBusqueda1);
								
									oParamBusqueda1 = new ParamBusqueda();
									oParamBusqueda1.Nombre="idProceso";
									oParamBusqueda1.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.ConsultarUbicacionTrabajador;
									oParamBusqueda1.Tipo="Q";
								oParamCollecionBusqueda1.Agregar(oParamBusqueda1);
						
								(new AutoBusqueda('txtNroDNI')).Crear( '/' + ApplicationPath + '/Personal/Procesar.aspx?',oParamCollecionBusqueda1);		
													
						
						
						
						
							
							
					/*actual*/		
					var params = KEYQPERIODO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQPERIODO]
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQSELECCION + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQSELECCION];
					
					var URLLISTA = '/' + ApplicationPath + '/GestionSeguridadIndustrial/ListarProgSeleccionPersonal.aspx?';
					function Resultado(Estado){};
					//jNet.get("LstUser").load(URLLISTA ,params,Resultado);
							
						
		
					
					ListarProgSeleccionPersonal.EliminarPersona = function(e,IdPersonal){
					
						var oPersonaCapacitacionBE = new EntidadesNegocio.GestionSeguridadIndustrial.PersonaCapacitacionBE();
							oPersonaCapacitacionBE.Periodo = ((oPagina.Request.Params[KEYQPERIODO]==undefined)?'0':oPagina.Request.Params[KEYQPERIODO]);
							oPersonaCapacitacionBE.IdSeleccion = ((oPagina.Request.Params[KEYQSELECCION]==undefined)?'0':oPagina.Request.Params[KEYQSELECCION]);
							oPersonaCapacitacionBE.IdPersonal = IdPersonal;
							oPersonaCapacitacionBE.NroPersonal= e.cells[1].innerText;
							oPersonaCapacitacionBE.NroDNI = e.cells[2].innerText;
							oPersonaCapacitacionBE.ApellidosyNombres=e.cells[3].innerText;
							oPersonaCapacitacionBE.NombreArea=e.cells[4].innerText;
						var IdEstado = jNet.get(e).attr("IDESTADO");
							oPersonaCapacitacionBE.IdEstado = ((IdEstado==1)?0:1);
						try{
							ListarProgSeleccionPersonal.Eliminar(oPersonaCapacitacionBE);
						}
						catch(SIMAExcepcionDominio){
							Ext.MessageBox.alert('Validación', 'PAGINA:' + SIMAExcepcionDominio.Pagina +'</br>PARAMETROS:'+ SIMAExcepcionDominio.Parametros +'</br>PROCESO:'+ SIMAExcepcionDominio.Proceso +'</br>MENSAJE:'+SIMAExcepcionDominio.Mensaje);
						}
						__doPostBack('btnPost','');
						//jNet.get("LstUser").load(URLLISTA ,params,Resultado);
					}
					
						
		</SCRIPT>
	</body>
</HTML>
