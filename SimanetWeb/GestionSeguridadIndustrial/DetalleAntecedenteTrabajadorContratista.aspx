<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleAntecedenteTrabajadorContratista.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.DetalleAntecedenteTrabajadorContratista" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Detalle antecedentes trabajador contratista</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="/SimaNetWeb/js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Menu/MenuSP.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Upload/mint"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Upload/si.files.js"></script>
		<STYLE title="text/css" type="text/css">.SI-FILES-STYLIZED LABEL.cabinet { WIDTH: 79px; DISPLAY: block; BACKGROUND: url(/SimaNetWeb/imagenes/Navegador/BtnOpciones/UpLoad.gif) no-repeat 0px 0px; HEIGHT: 28px; OVERFLOW: hidden; CURSOR: pointer }
	.SI-FILES-STYLIZED LABEL.cabinet INPUT.file { POSITION: relative; FILTER: progid:DXImageTransform.Microsoft.Alpha(opacity=0); WIDTH: auto; HEIGHT: 100%; opacity: 0; -moz-opacity: 0 }
		</STYLE>
		<script>
				function txtTrabajador_ItemDataBound(sender,e,dr){
					//document.getElementById("hIdTrab").value = dr["NroDNI"];
					jNet.get('txtNroDNI').value=dr["NroDNI"];
					
				}
				function txtNroDNI_ItemDataBound(sender,e,dr){
					jNet.get('txtTrabajador').value = dr["ApellidosNombres"];
				}
				function txtJefe_ItemDataBound(sender,e,dr){
					jNet.get('hIdJefe').value = dr["NroDNI"];
				}

				function txtPersonaInterviene_ItemDataBound(sender,e,dr){
					jNet.get('hIdPerInterviene').value = dr["NroDNI"];
				}
				function txtFamiliar_ItemDataBound(sender,e,dr){
					jNet.get('hIdFamiliar').value = dr["NroPersonal"];
				}
				
				function txtArea_ItemDataBound(sender,e,dr){
					jNet.get('hIdArea').value = dr["IdArea"].toString();
				}
				function txtContratista_ItemDataBound(sender,e,dr){
					jNet.get('hIdProveedor').value=dr["IDPROVEEDOR"];
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
				
				
			var HandleWindow;
			var opMenu=0;
			function MnuOP_txtContratista_OnClick(MnuID,Data){
				opMenu = parseInt(MnuID.replace('itmMnu',''))+1;
			}

			Ext.onReady(function(){
				Ext.QuickTips.init();
			});				
			
			
			function AgregarTrabajador(){
				jNet.get('txtNroDNIReg').value="";
				jNet.get('txtApellidoP').value="";
				jNet.get('txtApellidoM').value="";
				jNet.get('txtNombres').value="";
				
				(new System.Ext.UI.WebControls.Windows()).DetalleFromEL('MiWind','tblTrabajador','CREAR REGISTRO DE PERSONA',500,200,AceptarAccion);
			}
			
			function AceptarAccion(e){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var oddlNacionalidad	= jNet.get('ddlNacionalidad');
				var oItemNac = oddlNacionalidad.options[oddlNacionalidad.selectedIndex];
				//Verificar si el Nro de DNI Ya Existe
				var FechaYYYYMMDD = jNet.get('hFecha').value;
				var oCCTT_TrabajadorBE = new EntidadesNegocio.Personal.CCTT_TrabajadorBE();
				if(jNet.get('txtNroDNIReg').value.length>0){
					oCCTT_TrabajadorBE=(new AccesoDatos.NoTransacional.Personal.CCCTT_Trabajadores()).Detalle(jNet.get('txtNroDNIReg').value,FechaYYYYMMDD);
						
					if(oCCTT_TrabajadorBE!=null){//Valida si existe un registro con el nro de DNI ingresado.
						Ext.MessageBox.alert('AVISO', "El Nro de DNI " + oCCTT_TrabajadorBE.NroDNI +" que Ud esta tratando de registrar ya se existen con los datos de esta persona :<br>  "+ oCCTT_TrabajadorBE.ApellidosyNombres +" para incluirlo en su lista de personas programadas realice la búsqueda en el orden que se muestra.", function(btn){});
						return false;
					}
				}
				
				oCCTT_TrabajadorBE = new EntidadesNegocio.Personal.CCTT_TrabajadorBE();
				//Crea un registro en el maetro de visitas
				if(jNet.get('txtApellidoP').value.length==0){ Ext.MessageBox.alert('AVISO', "Ingresar Apellido Paterno" , function(btn){}); return false;}
				if(jNet.get('txtApellidoM').value.length==0){ Ext.MessageBox.alert('AVISO', "Ingresar Apellido Materno" , function(btn){}); return false;}
				if(jNet.get('txtNombres').value.length==0){ Ext.MessageBox.alert('AVISO', "Ingresar Nombres" , function(btn){}); return false;}

				oCCTT_TrabajadorBE.NroDNI = jNet.get('txtNroDNI').value;
				oCCTT_TrabajadorBE.ApPaterno=jNet.get('txtApellidoP').value;
				oCCTT_TrabajadorBE.ApMaterno=jNet.get('txtApellidoM').value;
				oCCTT_TrabajadorBE.Nombre=jNet.get('txtNombres').value;
	
				oCCTT_TrabajadorBE.ApellidosyNombres=jNet.get('txtApellidoP').value.toString().Ltrim().Rtrim() + ' ' + jNet.get('txtApellidoM').value.toString().Ltrim().Rtrim() + ' ' +jNet.get('txtNombres').value.toString().Ltrim().Rtrim();
				oCCTT_TrabajadorBE.IdNacionalidad=oItemNac.value;
				var NewNroDNI=(new AccesoDatos.NoTransacional.Personal.CCCTT_TrabajadorVisita()).Insertar(oCCTT_TrabajadorBE);
				
				e.hide();
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
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de seguridad></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> > Antecedente></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 446px" align="center">
						<TABLE style="WIDTH: 812px; HEIGHT: 200px" id="Table2" border="0" cellSpacing="0" cellPadding="0"
							width="812">
							<TR>
								<TD style="HEIGHT: 41px" bgColor="#000080" align="center"><asp:label style="Z-INDEX: 0" id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"
										Width="314px" Height="8px"> DETALLE DE ANTECEDENTE</asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 41px" align="left">
									<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="811" align="left">
										<TR>
											<TD style="WIDTH: 142px"></TD>
											<TD></TD>
											<TD></TD>
											<TD><INPUT style="Z-INDEX: 0; WIDTH: 20px; HEIGHT: 22px" id="hIdArea" size="9" type="hidden"
													name="Hidden1" runat="server"></TD>
											<TD><INPUT style="Z-INDEX: 0; WIDTH: 20px; HEIGHT: 22px" id="hIdPerInterviene" size="9" type="hidden"
													name="Hidden1" runat="server"></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 142px" class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label3" runat="server" Height="8px">FECHA :</asp:label></TD>
											<TD noWrap><ew:calendarpopup style="Z-INDEX: 0" id="CalFecha" runat="server" CssClass="normaldetalle" Width="60px"
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
											<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label9" runat="server" Height="8px">HORA:</asp:label></TD>
											<TD noWrap><ew:timepicker style="Z-INDEX: 0" id="tmHora" runat="server" Width="70px" ControlDisplay="TextBoxImage"
													ImageUrl="../imagenes/BtPU_fecha.gif" CellSpacing="2px" PopupLocation="Bottom" PopupWidth="555px"
													NumberOfColumns="10" PopupHeight="300px" MinuteInterval="OneMinute">
													<ButtonStyle BackColor="White"></ButtonStyle>
													<TextboxLabelStyle CssClass="normaldetalle" BackColor="White"></TextboxLabelStyle>
													<ClearTimeStyle CssClass="normaldetalle" BackColor="White"></ClearTimeStyle>
													<TimeStyle Font-Size="8pt" ForeColor="Navy" BackColor="White"></TimeStyle>
													<SelectedTimeStyle Font-Size="7pt" Font-Bold="True" ForeColor="Black" BorderColor="Lime" BackColor="#FFFF80"></SelectedTimeStyle>
												</ew:timepicker></TD>
											<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label8" runat="server" Height="8px">TIPO ANTECEDENTE:</asp:label></TD>
											<TD colSpan="2"><asp:dropdownlist style="Z-INDEX: 0" id="ddlTipoAntecedente" runat="server" CssClass="normaldetalle"
													Width="100%"></asp:dropdownlist></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 142px" class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label5" runat="server" Height="8px">PERSONA QUE INTERVIENE:</asp:label></TD>
											<TD colSpan="6" align="left">
												<TABLE style="Z-INDEX: 0" id="Table7" border="0" cellSpacing="1" cellPadding="1" width="100%">
													<TR>
														<TD width="100%"><asp:textbox style="Z-INDEX: 0" id="txtPersonaInterviene" runat="server" CssClass="normaldetalle"
																Width="100%"></asp:textbox></TD>
														<TD><IMG style="Z-INDEX: 0" id="ibtnAgregarTrab" title="Crear un nuevo trabajdor" onclick="AgregarTrabajador();"
																alt="" src="../imagenes/BtPU_Mas.gif" runat="server"></TD>
													</TR>
												</TABLE>
											</TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 27px" class="HeaderDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label7" runat="server" Height="8px"> PUNTO DE INTERVENCION:</asp:label></TD>
											<TD style="HEIGHT: 27px" colSpan="5"><asp:textbox style="Z-INDEX: 0" id="txtArea" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
											<TD style="HEIGHT: 27px" class="HeaderDetalle"><asp:checkbox style="Z-INDEX: 0" id="chkCritica" runat="server" Text="Crítica"></asp:checkbox></TD>
											<TD style="HEIGHT: 27px"></TD>
											<TD style="HEIGHT: 27px"></TD>
											<TD style="HEIGHT: 27px"></TD>
										</TR>
										<TR>
											<TD class="HeaderDetalle" colSpan="6" align="left"><asp:label style="Z-INDEX: 0" id="Label6" runat="server" Height="8px">DATOS DEL INTERVENIDO</asp:label></TD>
											<TD rowSpan="6" align="center"><asp:image style="Z-INDEX: 0" id="oImgFoto" runat="server" Width="200px" Height="202px" ImageUrl="/SimanetWeb/imagenes/Navegador/UserActivo.gif"
													BorderColor="Gray"></asp:image></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label1" runat="server" Height="8px">APELLIDOS Y NOMBRES:</asp:label></TD>
											<TD colSpan="3">
												<TABLE style="Z-INDEX: 0" id="Table6" border="0" cellSpacing="1" cellPadding="1" width="100%">
													<TR>
														<TD width="100%"><asp:textbox style="Z-INDEX: 0" id="txtTrabajador" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
														<TD><IMG style="Z-INDEX: 0" id="ibtnAgregarTrab3" title="Crear un nuevo trabajdor" onclick="AgregarTrabajador();"
																alt="" src="../imagenes/BtPU_Mas.gif" runat="server"></TD>
													</TR>
												</TABLE>
											</TD>
											<TD class="HeaderDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label10" runat="server" Height="8px">NRO DOCUMENTO:</asp:label></TD>
											<TD vAlign="top" align="left"><asp:textbox style="Z-INDEX: 0" id="txtNroDNI" runat="server" CssClass="normaldetalle"></asp:textbox></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderDetalle" colSpan="6"><asp:label style="Z-INDEX: 0" id="Label11" runat="server" Height="8px">DATOS DE FAMILIARES:</asp:label></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label12" runat="server" Height="8px">DATOS DEL FAMILIAR</asp:label></TD>
											<TD vAlign="top" colSpan="3" align="left"><asp:textbox style="Z-INDEX: 0" id="txtFamiliar" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
											<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label13" runat="server" Height="8px">PARENTESCO:</asp:label></TD>
											<TD><asp:dropdownlist style="Z-INDEX: 0" id="ddlParentesco" runat="server" CssClass="normaldetalle" Width="100%"></asp:dropdownlist></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderDetalle" colSpan="6"><asp:label style="Z-INDEX: 0" id="Label14" runat="server" Height="8px">VINCULO LABORAL:</asp:label></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label2" runat="server" Height="8px">EMPRESA RAZON SOCIAL:</asp:label></TD>
											<TD vAlign="top" colSpan="3" align="left"><asp:textbox style="Z-INDEX: 0" id="txtContratista" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
											<TD class="HeaderDetalle"><asp:checkbox style="Z-INDEX: 0" id="chkContratista" runat="server" Text="Contratista"></asp:checkbox></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label15" runat="server" Height="8px">JEFE, DIRECTO:</asp:label></TD>
											<TD colSpan="5">
												<TABLE id="Table5" border="0" cellSpacing="1" cellPadding="1" width="100%">
													<TR>
														<TD width="100%"><asp:textbox style="Z-INDEX: 0" id="txtJefe" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
														<TD><IMG style="Z-INDEX: 0" id="ibtnAgregarTrab2" title="Crear un nuevo trabajdor" onclick="AgregarTrabajador();"
																alt="" src="../imagenes/BtPU_Mas.gif" runat="server"></TD>
													</TR>
												</TABLE>
											</TD>
											<TD vAlign="top" align="center"><LABEL class="cabinet"><INPUT id="FUFile" class="file" size="1" type="file" name="FUFile" runat="server"></LABEL>
												<INPUT style="Z-INDEX: 0; WIDTH: 47px; HEIGHT: 22px" id="hIdJefe" size="2" type="hidden"
													runat="server"> <INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hCargar" value="0" size="1" type="hidden"
													name="hCargar" runat="server"> <INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hGrabarFoto" value="0" size="1"
													type="hidden" name="hCargar" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hNroRecarga" value="0" size="1"
													type="hidden" name="hCargar" runat="server"></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label16" runat="server" Height="8px">EVENTO CRITICO:</asp:label></TD>
											<TD colSpan="5"><asp:textbox style="Z-INDEX: 0" id="txtEventoCritico" runat="server" CssClass="normaldetalle"
													Width="100%" Height="60px" TextMode="MultiLine"></asp:textbox></TD>
											<TD class="HeaderDetalle"><asp:checkbox style="Z-INDEX: 0" id="chkIngPermitido" runat="server" Text="Ingreso permitido"></asp:checkbox></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label4" runat="server" Height="8px">OBSERVACIONES:</asp:label></TD>
											<TD colSpan="5"><asp:textbox style="Z-INDEX: 0" id="txtObservacion" runat="server" CssClass="normaldetalle" Width="100%"
													Height="56px" TextMode="MultiLine"></asp:textbox></TD>
											<TD><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hIdTrab" size="1" type="hidden"
													name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hIdProveedor" size="1" type="hidden"
													runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 22px" id="hIdFamiliar" size="1" type="hidden"
													name="Hidden1" runat="server" value="0"><INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 22px" id="hUpload" value="0" size="1" type="hidden"
													name="Hidden1" runat="server"></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label17" runat="server" CssClass="headerDetalle" Width="120px"
													BorderStyle="None">Doc. Referencia:</asp:label></TD>
											<TD style="BORDER-BOTTOM: gray 1px solid; BORDER-LEFT: gray 1px solid; PADDING-BOTTOM: 5px; PADDING-RIGHT: 5px; BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: right top; BORDER-TOP: gray 1px solid; BORDER-RIGHT: gray 1px solid"
												id="cellListAnexos" bgColor="#ffffff" colSpan="5"></TD>
											<TD><LABEL class="cabinet"><INPUT style="Z-INDEX: 0" id="fAnexo" class="file" size="1" type="file" name="FUFile" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hCarga2" value="0" size="1" type="hidden"
														name="hCargar2" runat="server"></LABEL> <INPUT style="Z-INDEX: 0; WIDTH: 31px; HEIGHT: 23px" id="hLstAnexo" size="1" type="hidden"
													name="Hidden1" runat="server"> <INPUT style="Z-INDEX: 0; WIDTH: 65px; HEIGHT: 23px" id="hNombreArchivoUP" size="5" type="hidden"
													name="Hidden1" runat="server">
												<asp:button id="btnSubir" runat="server" Text="Button"></asp:button><INPUT style="Z-INDEX: 0; WIDTH: 31px; HEIGHT: 23px" id="hLstAnexoDel" size="1" type="hidden"
													name="hLstAnexoDel" runat="server">
											</TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD colSpan="5"></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="PADDING-LEFT: 5px" vAlign="top" align="left"></TD>
											<TD colSpan="5"><INPUT style="Z-INDEX: 0; WIDTH: 47px; HEIGHT: 22px" id="hPathHttpTmp" size="2" type="hidden"
													name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 47px; HEIGHT: 22px" id="hPathLocalTmp" size="2" type="hidden"
													name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 65px; HEIGHT: 23px" id="hFecha" size="5" type="hidden"
													name="Hidden1" runat="server">
												<asp:button style="Z-INDEX: 0" id="btnCargarFoto" runat="server" Text="Button"></asp:button></TD>
											<TD>
												<TABLE style="Z-INDEX: 0; WIDTH: 182px; HEIGHT: 30px" id="Table3" border="0" cellSpacing="1"
													cellPadding="1" width="182">
													<TR>
														<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnAceptar" runat="server" Height="22px" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
														<TD><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt=""
																src="../imagenes/bt_cancelar.gif"></TD>
													</TR>
												</TABLE>
											</TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD><INPUT style="Z-INDEX: 0; WIDTH: 47px; HEIGHT: 22px" id="hPathFileHttpTmp" size="2" type="hidden"
													name="Hidden1" runat="server"></TD>
											<TD><INPUT style="Z-INDEX: 0; WIDTH: 47px; HEIGHT: 22px" id="hPathFileLocalTmp" size="2" type="hidden"
													name="Hidden1" runat="server"></TD>
											<TD><INPUT style="Z-INDEX: 0; WIDTH: 47px; HEIGHT: 22px" id="hPathFileHttpFinal" size="2" type="hidden"
													name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 47px; HEIGHT: 22px" id="hIdUsuario" size="2" type="hidden"
													name="Hidden1" runat="server"></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="DISPLAY: none" align="center">
						<TABLE style="Z-INDEX: 0; WIDTH: 440px; HEIGHT: 135px" id="tblTrabajador" border="0" cellSpacing="1"
							cellPadding="1" width="440">
							<TR>
								<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label18" runat="server">Nro DOCUMENTO:</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtNroDNIReg" runat="server" CssClass="normaldetalle" Width="152px"
										MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label19" runat="server"> APELLIDO PATERNO:</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtApellidoP" runat="server" CssClass="normaldetalle" Width="208px"
										MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label20" runat="server"> APELLIDO MATERNO:</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtApellidoM" runat="server" CssClass="normaldetalle" Width="208px"
										MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label21" runat="server">NOMBRES:</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtNombres" runat="server" CssClass="normaldetalle" Width="208px"
										MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label22" runat="server">NACIONALIDAD</asp:label></TD>
								<TD><asp:dropdownlist style="Z-INDEX: 0" id="ddlNacionalidad" runat="server" CssClass="normaldetalle"
										Width="208px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
			<SCRIPT language="javascript" type="text/javascript">
			// <![CDATA[
					SI.Files.stylizeAll();
			// ]]>
			
			var IdObj="";
			
			var oFUFile = jNet.get('FUFile');
			oFUFile.addEvent("change",function(){
				if(jNet.get("txtNroDNI").value.toString().length>0){
					var arrNOMBREIMG = this.value.toString().split(String.fromCharCode(92));
					var ArrExtImg = arrNOMBREIMG[arrNOMBREIMG.length-1].split('.');
					var ExtImg=ArrExtImg[ArrExtImg.length-1];
					if(ExtImg.Igual('jpg')|| ExtImg.Igual('gif')){
						jNet.get('hCargar').value="1";//Controla el efecto de carga
						jNet.get('hGrabarFoto').value="1";//Sirve para verificar si hubo nueva carga de imagen
						__doPostBack('btnCargarFoto',arrNOMBREIMG);
					}
					else{
						Ext.MessageBox.alert('Estado', 'No esta permitido almacenar este tipo de archivo\\n por favor seleccionar un archivo Imagen', function(btn){});
					}
				}
				else{
						Ext.MessageBox.alert('Estado', 'No es posible almacenar esta imagen, se deberá ingresar  el Nro de documento de la persona intervenida', function(btn){});
				}
			});
			
			
			
		var ofAnexo = jNet.get('fAnexo');
			ofAnexo.addEvent("change",function(){
							var PathNombre=jNet.get('fAnexo').value;
							var arrPath =PathNombre.split(String.fromCharCode(92));
							var NombreFile = arrPath[arrPath.length-1];
							jNet.get('hNombreArchivoUP').value = NombreFile;
							CrearCtrlAnexo('0',NombreFile,'BaseItemInGridRed');
							ObtenerAnexos();
								__doPostBack('btnSubir','');						
				
			});		
			
			
			function ListarCtrlAnexos(){
				var LstAnexo= jNet.get('hLstAnexo').value.toString().split('@');
				if((LstAnexo.length>0)&&(LstAnexo[0].length>0)){
					for(var i=0;i<=LstAnexo.length-1;i++){
						var arrCampos = LstAnexo[i].toString().split(';');	
						CrearCtrlAnexo(arrCampos[0],arrCampos[1],'BaseItemInGrid');
					}
				}
			}

			function CrearCtrlAnexo(IdAnexo,NombreFile,Estilo){
				var arrNombre = NombreFile.toString().split('.');
				var Nombre = NombreFile.toString().Replace(arrNombre[arrNombre.length-1].toString(),"");
				var HTMLTable = jNet.get((new SIMA.Utilitario.Helper.General.Html()).CrearTabla(1,3));
				IdObj = "obj" + IdAnexo;
				HTMLTable.align="left";
				HTMLTable.style.cssText="MARGIN-BOTTOM: 5px; MARGIN-LEFT: 5px";
				HTMLTable.attr("id",IdObj);
				HTMLTable.attr("IDANEXO",IdAnexo);
				HTMLTable.attr("NOMBRE",NombreFile);
				HTMLTable.className=Estilo;				
				HTMLTable.border=0;
				HTMLTable.attr("width","100px");
				
				var arrNombre = NombreFile.split('.');
				var Extension = arrNombre[arrNombre.length-1].toString().toUpperCase();
				HTMLTable.attr("EXTENSION",Extension.toLowerCase())
				
				var oIMG = SIMA.Utilitario.Helper.General.CrearImg('/' + ApplicationPath + '/imagenes/Navegador/' + ObtenerExtension(Extension) + '.png');
				oIMG.onclick=function(){
					var oTBLItem = jNet.get(this.parentNode.parentNode.parentNode.parentNode);
					var Ext = HTMLTable.attr("EXTENSION");
					
					//var RutaFile=jNet.get('hPathFileHttpFinal').value + HTMLTable.attr("NOMBRE") ;
					if((Ext=='jpg')||(Ext=='gif')||(Ext=='bmp')||(Ext=='png')){
						var URL='/' + ApplicationPath +'/GestionSeguridadIndustrial/VistaPrevia.aspx?' + SIMA.Utilitario.Constantes.KEYQNOMBREIMGPREVIO +  SIMA.Utilitario.Constantes.General.Caracter.SignoIgual +  oTBLItem.attr("IDANEXO")+'_'+oTBLItem.attr("NOMBRE");
						(new System.Ext.UI.WebControls.Windows()).Dialogo('VISTA PREVIA',URL,this,window.screen.width-100,window.screen.height-100);
					}
					else{
						var strRutaHTTP = ((oTBLItem.attr("IDANEXO")=="0")?jNet.get('hPathFileHttpTmp').value + jNet.get('hIdUsuario').value + oTBLItem.attr("NOMBRE")
																			:jNet.get('hPathFileHttpFinal').value +  oTBLItem.attr("IDANEXO")+'_'+ oTBLItem.attr("NOMBRE"));
						(new SIMA.Utilitario.Helper.Window()).AbrirExcel(strRutaHTTP);
					}
				}
				jNet.get(HTMLTable.rows[0].cells[0]).insert(oIMG);
				HTMLTable.rows[0].cells[1].innerText=Nombre;
				HTMLTable.rows[0].cells[1].noWrap=true;
				oIMG = SIMA.Utilitario.Helper.General.CrearImgEliminar(1);
				oIMG.onclick=function(){
					var oTBLItem = jNet.get(this.parentNode.parentNode.parentNode.parentNode);
					if(oTBLItem.attr("IDANEXO")!='0'){
						Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este archivo ahora?', function(btn){
											if(btn=="yes"){
												var strLstAnexo =  oTBLItem.attr('IDANEXO') +';'+ oTBLItem.attr('NOMBRE');
												var objAnexoDel = jNet.get('hLstAnexoDEL');
												if(objAnexoDel.value.lenght>0){
													objAnexoDel.value = "@" + strLstAnexo;
												}
												else{
													 jNet.get('hLstAnexoDEL').value  =  strLstAnexo;
												}
												 
												jNet.get('cellListAnexos').removeChild(oTBLItem);
												ObtenerAnexos();//Actualiza la Lista de Control de anexos
											}
										});					
					
					}
				}
				jNet.get(HTMLTable.rows[0].cells[2]).insert(oIMG);
				jNet.get('cellListAnexos').insert(HTMLTable);
			}
			
			function ObtenerAnexos(){
				var strLstAnexo="";
				var ocellListAnexos = jNet.get('cellListAnexos');
				for(var i=0;i<=ocellListAnexos.children.length-1;i++){
					var otblItemAnexo= jNet.get(ocellListAnexos.children[i]);
					strLstAnexo+=  otblItemAnexo.attr('IDANEXO') +';'+ otblItemAnexo.attr('NOMBRE') + '@';
				}
				jNet.get('hLstAnexo').value = strLstAnexo.substring(0,strLstAnexo.length-1);
			}

			
		

				
			
			</SCRIPT>
			<SCRIPT>
		
						var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
						/*-----------------------------------------------------------------------*/
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
					
							
						oParamCollecionBusqueda = new ParamCollecionBusqueda();
						var oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="NroDNI";
							oParamBusqueda.Texto="Trabajador";
							oParamBusqueda.LongitudEjecucion=2;
							oParamBusqueda.CampoAlterno="ApellidosNombres";
							oParamBusqueda.Tipo="C";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						
							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="idProceso";
							oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.ConsultarUbicacionTrabajador;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
				
						(new AutoBusqueda('txtNroDNI')).Crear( '/' + ApplicationPath + '/Personal/Procesar.aspx?',oParamCollecionBusqueda);		

					/*-----------------------------------------------------------------------*/
					
						oParamCollecionBusqueda = new ParamCollecionBusqueda();
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

						(new AutoBusqueda('txtJefe')).Crear( '/' + ApplicationPath + '/GestionSeguridadIndustrial/Procesar.aspx?',oParamCollecionBusqueda);
					
					/*-----------------------------------------------------------------------*/
					
							oParamCollecionBusqueda = new ParamCollecionBusqueda();
							oParamBusqueda = new ParamBusqueda();
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

						(new AutoBusqueda("txtPersonaInterviene")).Crear( '/' + ApplicationPath + '/GestionSeguridadIndustrial/Procesar.aspx?',oParamCollecionBusqueda);
						
					
					
					/*-----------------------------------------------------------------------*/
					
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

						(new AutoBusqueda("txtFamiliar")).Crear('/' + ApplicationPath + '/GestionFinanciera/Procesar.aspx?',oParamCollecionBusqueda);
						
					
					
					
					
					
							
					var KEYQIDTIPOENTIDAD="idTipoEntidad";
						oParamCollecionBusqueda = new ParamCollecionBusqueda();
						oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre="RAZONSOCIAL";
						oParamBusqueda.Texto="Razon Social del Proveedor";
						oParamBusqueda.LongitudEjecucion=5;
						oParamBusqueda.Tipo="C";
						oParamBusqueda.Ancho=100;
						oParamBusqueda.CampoAlterno = "NROPROVEEDOR";
					oParamCollecionBusqueda.Agregar(oParamBusqueda);
				
						oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre="NROPROVEEDOR";
						oParamBusqueda.Texto="R.U.C. de Proveedor";
						oParamBusqueda.LongitudEjecucion=5;
						oParamBusqueda.Tipo="C";
						oParamBusqueda.Ancho=100;
						oParamBusqueda.CampoAlterno = "RAZONSOCIAL";
					oParamCollecionBusqueda.Agregar(oParamBusqueda);

						oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre=KEYQIDTIPOENTIDAD;
						oParamBusqueda.Valor=1;
						oParamBusqueda.ParaBusqueda=false;
						oParamBusqueda.Tipo="Q";
					oParamCollecionBusqueda.Agregar(oParamBusqueda);

						oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre="idProceso";
						oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarProveedorRSocialORuc;
						oParamBusqueda.ParaBusqueda=false;
						oParamBusqueda.Tipo="Q";
					oParamCollecionBusqueda.Agregar(oParamBusqueda);
				
				(new AutoBusqueda('txtContratista')).CrearPopupOpcion( '/' + ApplicationPath + '/Personal/Procesar.aspx?',oParamCollecionBusqueda);



				//Configuracion de Busqueda para Areas
					oParamCollecionBusqueda = new ParamCollecionBusqueda();
					oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="NombreArea";
					oParamBusqueda.Texto="Area";
					oParamBusqueda.LongitudEjecucion=1;
					oParamBusqueda.CampoAlterno = "NroArea";
					oParamBusqueda.Tipo="C";
					oParamBusqueda.LongitudEjecucion=2;
				oParamCollecionBusqueda.Agregar(oParamBusqueda);

					oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="idProceso";
					oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarAreayPseudoArea;
					oParamBusqueda.Tipo="Q";
				oParamCollecionBusqueda.Agregar(oParamBusqueda);
				(new AutoBusqueda('txtArea')).Crear('/' + ApplicationPath + '/GestionSeguridadIndustrial/Procesar.aspx?',oParamCollecionBusqueda);
					
												

				ListarCtrlAnexos();
				//Efecto de Carga
				if(jNet.get('hCargar').value=='1'){
				//	ProgresoUpLoad();
					jNet.get('hCargar').value='0';
				}
				
			</SCRIPT>
		</form>
	</body>
</HTML>
