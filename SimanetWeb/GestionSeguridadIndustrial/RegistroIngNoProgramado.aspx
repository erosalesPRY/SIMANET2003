<%@ Page language="c#" Codebehind="RegistroIngNoProgramado.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.RegistroIngNoProgramado" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>RegistroIngNoProgramado</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="/SimaNetWeb/js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<!--<script type="text/javascript" src="/SimaNetWeb/js/Menu/MenuSP.js"></script>-->
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<SCRIPT language="javascript" src="../js/JQuery/js/jquery.min.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>
		<SCRIPT>
                  var jSIMA = jQuery.noConflict();
		</SCRIPT>
		<script>
				var KEYQIDTIPOENTIDAD="idTipoEntidad";
				var KEYQIDTITUTIPOENTIDAD="TituloEnt";
					function txtAutorizadoPor_ItemDataBound(sender,e,dr){
						jNet.get('hIdPersonalAutoriza').value=dr["idpersonal"];
					}
					
					function txtNroDNI_ItemDataBound(sender,e,dr){
						jNet.get('txtTrabajador').value=dr["ApellidosNombres"];
					}
					function txtTrabajador_ItemDataBound(sender,e,dr){
						jNet.get('txtNroDNI').value=dr["NroDNI"];
					}
					
					
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
						var FechaYYYYMMDD = jNet.get('hFechaIniProg').value;
						var oCCTT_TrabajadorBE = new EntidadesNegocio.Personal.CCTT_TrabajadorBE();
						/*if(jNet.get('txtNroDNIReg').value.length>0){
							oCCTT_TrabajadorBE=(new AccesoDatos.NoTransacional.Personal.CCCTT_Trabajadores()).Detalle(jNet.get('txtNroDNIReg').value,FechaYYYYMMDD);
								
							if(oCCTT_TrabajadorBE!=null){//Valida si existe un registro con el nro de DNI ingresado.
								Ext.MessageBox.alert('AVISO', "El Nro de DNI " + oCCTT_TrabajadorBE.NroDNI +" que Ud esta tratando de registrar ya se existen con los datos de esta persona :<br>  "+ oCCTT_TrabajadorBE.ApellidosyNombres +" para incluirlo en su lista de personas programadas realice la búsqueda en el orden que se muestra.", function(btn){});
								return false;
							}
						}*/
						
						oCCTT_TrabajadorBE = new EntidadesNegocio.Personal.CCTT_TrabajadorBE();
						//Crea un registro en el maetro de visitas
						if(jNet.get('txtApellidoP').value.length==0){ Ext.MessageBox.alert('AVISO', "Ingresar Apellido Paterno" , function(btn){}); return false;}
						if(jNet.get('txtApellidoM').value.length==0){ Ext.MessageBox.alert('AVISO', "Ingresar Apellido Materno" , function(btn){}); return false;}
						if(jNet.get('txtNombres').value.length==0){ Ext.MessageBox.alert('AVISO', "Ingresar Nombres" , function(btn){}); return false;}

						oCCTT_TrabajadorBE.NroDNI = jNet.get('txtNroDNIReg').value.toString().Ltrim().Rtrim();
						oCCTT_TrabajadorBE.ApPaterno=jNet.get('txtApellidoP').value.toString().Ltrim().Rtrim();
						oCCTT_TrabajadorBE.ApMaterno=jNet.get('txtApellidoM').value.toString().Ltrim().Rtrim();
						oCCTT_TrabajadorBE.Nombre=jNet.get('txtNombres').value;
						oCCTT_TrabajadorBE.ApellidosyNombres=oCCTT_TrabajadorBE.ApPaterno + ' ' + oCCTT_TrabajadorBE.ApMaterno + ' ' + oCCTT_TrabajadorBE.Nombre;
	
						//oCCTT_TrabajadorBE.ApellidosyNombres=jNet.get('txtApellidoP').value.toString().Ltrim().Rtrim() + ' ' + jNet.get('txtApellidoM').value.toString().Ltrim().Rtrim() + ' ' +jNet.get('txtNombres').value.toString().Ltrim().Rtrim();
						oCCTT_TrabajadorBE.IdNacionalidad=oItemNac.value;
						try{
							var NewNroDNI=(new AccesoDatos.NoTransacional.Personal.CCCTT_TrabajadorVisita()).Insertar(oCCTT_TrabajadorBE);
						}
						catch(SIMAExcepcionDominio){
							Ext.MessageBox.alert('Validación', SIMAExcepcionDominio.toString());
						}
						
						e.hide();
					}	
									
					function ValidarCampos(){
						if(jNet.get('txtNroDNI').value.length==0){
							Ext.MessageBox.alert('Valida datos', "No se ha ingresado Nro de documento", function(btn){});
							return false;
						}
						if(jNet.get('txtTrabajador').value.length==0){
							Ext.MessageBox.alert('Valida datos', "No se ha ingresado Apellidos y nombres del trabajador o visita", function(btn){});
							return false;
						}
						if(jNet.get('hIdPersonalAutoriza').value.length==0){
							Ext.MessageBox.alert('Valida datos', "No se ha ingresado persona que autoriza el ingreso", function(btn){});
							return false;
						}
						if(jNet.get('txtMotivo').value.length==0){
							Ext.MessageBox.alert('Valida datos', "No se ha ingresado Motivo del ingreso", function(btn){});
							return false;
						}
						return true;
					}
					
					function InsertarControlIngresoArea(){
						var KEYQIDTIPOPROGRAMACION="TipoPrg";
						var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
						if(ValidarCampos()==true){
							//var oddlTipoEntidad= new System.Web.UI.WebControls.DropDownList('ddlTipoEntidad');
							//var LItem = oddlTipoEntidad.ListItem();
							
							var oCCTT_ProgramacionBE = new EntidadesNegocio.Personal.CCTT_ProgramacionBE();
								//oCCTT_ProgramacionBE.IdTipoEntidad = LItem.value;
								oCCTT_ProgramacionBE.IdTipoEntidad = oPagina.Request.Params[KEYQIDTIPOENTIDAD];
								oCCTT_ProgramacionBE.IdEntidad=jNet.get('hidEntidad').value ;
								oCCTT_ProgramacionBE.IdJefeProyecto=jNet.get('hIdPersonalAutoriza').value;
								oCCTT_ProgramacionBE.Observaciones=jNet.get('txtMotivo').value
								oCCTT_ProgramacionBE.TipoProgramacion = oPagina.Request.Params[KEYQIDTIPOPROGRAMACION];
								oCCTT_ProgramacionBE.IdLugardeTrabajo=22;//999;//Modificar
							
							var oCCTT_ProgramacionTrabajadoresContratistaBE = new EntidadesNegocio.Personal.CCTT_ProgramacionTrabajadoresContratistaBE();
							oCCTT_ProgramacionTrabajadoresContratistaBE.NroDNI = jNet.get('txtNroDNI').value;

							var Registrado=(new Controladora.Personal.CCCTT_Programacion()).RegistrarNoProg(oCCTT_ProgramacionBE,oCCTT_ProgramacionTrabajadoresContratistaBE);
							if(Registrado!="-1"){
								jSIMA.SaveClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,'NDocNoProg',Registrado);
								window.close();
							}
							else{
								Ext.MessageBox.alert('REGISTRO NO PROGRAMADO', "No es posible realizar el registro", function(btn){});
							}
						}
					}		
					
		</script>
		
		<script>
			function CreaNuevoPRV(){
				jNet.get('txtRucNew1').value='';
				jNet.get('txtRSocialNew1').value=jNet.get('txtBuscarEntidad').value;
				(new System.Ext.UI.WebControls.Windows()).DetalleFromEL('MiWindE','tblPrvCLI',"Nuevo registro",420,120,GrabarNuevoPRV_CLI);
			}
			
			function GrabarNuevoPRV_CLI(){
				var KEYQIDTIPOENTIDAD="idTipoEntidad";
				try{				
					var oEntidadExternaBE = new EntidadesNegocio.General.EntidadExternaBE();
						oEntidadExternaBE.IdTipoEndidad=IdTipoEnt;
						oEntidadExternaBE.NroRuc=jNet.get('txtRucNew1').value;
						oEntidadExternaBE.RazonSocial=jNet.get('txtRSocialNew1').value;
					
					if((oEntidadExternaBE.NroRuc.length>=11)&&(oEntidadExternaBE.RazonSocial.length>0)){
						var idEntidad=	(new Controladora.General.CProveedor()).Insertar(oEntidadExternaBE);
						if(idEntidad!=undefined){
							jNet.get('hidEntidad').value=idEntidad;
							jNet.get('txtPersonal').value=jNet.get('txtRSocialNew').value;
						}
						Ext.getCmp('MiWindE').hide();
					}
					else{
						Ext.MessageBox.show({title: 'ACCESO DATOS',msg: 'Nro de ruc o razon social no valido',buttons: Ext.MessageBox.OK,fn: function(btn){},icon:  Ext.MessageBox.QUESTION});
					}
				}
				catch(Error){
					Ext.MessageBox.show({title: 'ACCESO DATOS',msg: 'Registro ya existe:' + Error.Mensaje,buttons: Ext.MessageBox.OKCANCEL,fn: function(btn){
												Ext.getCmp('MiWindE').hide();
										},icon:  Ext.MessageBox.QUESTION});
				}
				
			}
		</script>
		
		
		<script>
			var VentaBusqueda;
			function BusquedaEnDialogo(){
				//var KEYQIDTIPOENTIDAD="idTipoEntidad";
				var KEYQCAMPO="Campo";
				var KEYQCRITERIO="Criterio";
				var KEYQIDRAZONSOCIAL="razonsocial";
				var Titulo = "";
				//var _ddlTipoEntidad = jNet.get('ddlTipoEntidad'); 
				var strCriterio = jNet.get('txtBuscarEntidad').value;
				//if(_ddlTipoEntidad.options[_ddlTipoEntidad.selectedIndex].value==0){
				Titulo = oPagina.Request.Params[KEYQIDTITUTIPOENTIDAD];
				/*if(oPagina.Request.Params[KEYQIDTIPOENTIDAD]==0){
					Titulo = "BUSCAR CLIENTE";
				}
				else if(oPagina.Request.Params[KEYQIDTIPOENTIDAD]==1){
					Titulo = "BUSCAR PROVEEDOR";
				}*/
				
				if(event.keyCode==13){
					var urlPath='/' + ApplicationPath + '/Personal/visitas/BuscarEntidadProveedorCliente.aspx?'
								//+ KEYQIDTIPOENTIDAD +'='+ _ddlTipoEntidad.options[_ddlTipoEntidad.selectedIndex].value
								+ KEYQIDTIPOENTIDAD +'='+ oPagina.Request.Params[KEYQIDTIPOENTIDAD]
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson 
								+ KEYQCAMPO + "=" +  ((strCriterio.IsNumeric()==true)?"nroproveedor": KEYQIDRAZONSOCIAL)
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson 
								+ KEYQCRITERIO +"=" + strCriterio;
					
					VentaBusqueda=(new System.Ext.UI.WebControls.Windows()).Dialogo(Titulo,urlPath,this,565,400);
				}
			}
			function SeleccionarResultado(IdEntidad,Razonsocial){
				jNet.get('hidEntidad').value = IdEntidad;
				jNet.get('txtBuscarEntidad').value=Razonsocial;
				VentaBusqueda.close();
			}
					
		</script>
</HEAD>
	<body onkeydown="if(event.keyCode==13)return false">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD><INPUT style="WIDTH: 72px; HEIGHT: 22px" id="hFechaIniProg" size="6" type="hidden" runat="server"><INPUT style="WIDTH: 56px; HEIGHT: 22px" id="hFechaTermProg" size="4" type="hidden" runat="server"></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD width="100%">
						<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD class="HeaderGrilla" noWrap><asp:label style="Z-INDEX: 0" id="Label2" runat="server">Tipo Visita:</asp:label></TD>
								<TD colSpan="3"><asp:textbox id="txtTipoVisita" runat="server" Width="456px" CssClass="normaldetalle" BorderStyle="None"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR style="DISPLAY: none" id="FEntidad">
								<TD class="HeaderGrilla" noWrap><asp:label style="Z-INDEX: 0" id="Label6" runat="server">Empresa:</asp:label></TD>
								<TD colSpan="3">
									<TABLE style="Z-INDEX: 0" id="tblB" border="0" cellSpacing="1" cellPadding="1" width="100%"
										align="left">
										<TR>
											<TD width="100%"><asp:textbox style="Z-INDEX: 0" id="txtBuscarEntidad" runat="server" Width="100%" CssClass="InputFind"></asp:textbox></TD>
											<TD><IMG style="Z-INDEX: 0" id="imgNuevoPRV" onclick="CreaNuevoPRV();" alt="" src="../imagenes/BtPU_Mas.gif"></TD>
										</TR>
									</TABLE>
								</TD>
								<TD></TD>
							</TR>
							<TR>
								<TD class="HeaderGrilla" noWrap><asp:label style="Z-INDEX: 0" id="Label3" runat="server">Nro Documento:</asp:label></TD>
								<TD width="20%"><asp:textbox style="Z-INDEX: 0" id="txtNroDNI" runat="server" Width="100%" CssClass="normaldetalle"></asp:textbox></TD>
								<TD class="HeaderGrilla" noWrap><asp:label style="Z-INDEX: 0" id="Label5" runat="server">Apellidos y Nombres:</asp:label></TD>
								<TD width="100%"><asp:textbox style="Z-INDEX: 0" id="txtTrabajador" runat="server" Width="100%" CssClass="normaldetalle"></asp:textbox></TD>
								<TD width="100%"><IMG style="Z-INDEX: 0" id="ibtnAgregarTrab3" title="Crear un nuevo trabajdor" onclick="AgregarTrabajador();"
										alt="" src="../imagenes/BtPU_Mas.gif" runat="server"></TD>
							</TR>
							<TR>
								<TD class="HeaderGrilla" noWrap><asp:label style="Z-INDEX: 0" id="Label1" runat="server">Autorizado Por:</asp:label></TD>
								<TD colSpan="3"><asp:textbox style="Z-INDEX: 0" id="txtAutorizadoPor" runat="server" Width="100%" CssClass="normaldetalle"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD class="HeaderGrilla" vAlign="top" align="left"><asp:label id="Label4" runat="server">Motivo:</asp:label></TD>
								<TD colSpan="3"><asp:textbox id="txtMotivo" runat="server" Width="100%" CssClass="normaldetalle" Height="64px"
										TextMode="MultiLine"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left"></TD>
								<TD colSpan="3">
									<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="300" align="right">
										<TR>
											<TD align="right"><IMG style="Z-INDEX: 0" id="btnAceptar" onclick="InsertarControlIngresoArea();" alt=""
													src="../imagenes/bt_aceptar.gif" runat="server"></TD>
											<TD align="right"><IMG style="Z-INDEX: 0" id="ibtnCancelar" onclick="window.close();" alt="" src="../imagenes/bt_cancelar.gif"
													runat="server"></TD>
										</TR>
									</TABLE>
									<INPUT style="WIDTH: 56px; HEIGHT: 22px" id="hidEntidad" value="0" size="4" type="hidden"
										runat="server"> <INPUT style="WIDTH: 80px; HEIGHT: 22px" id="hIdPersonalAutoriza" size="8" type="hidden"
										runat="server">
								</TD>
								<TD>									
								</TD>
							</TR>
							<tr>
								<td>
								</td>
								<TD style="DISPLAY: none" height="2" vAlign="top" width="100%" align="center">
									<TABLE style="MARGIN-TOP: 2px; MARGIN-LEFT: 2px" id="tblPrvCLI" border="0" cellSpacing="1"
										cellPadding="1" width="100%">
										<TR>
											<TD class="HeaderDetalle" noWrap><asp:label id="Label14" runat="server">Nro de R.U.C:</asp:label></TD>
											<TD><asp:textbox id="txtRucNew1" runat="server" Width="128px" MaxLength="11"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="HeaderDetalle" noWrap><asp:label id="Label7" runat="server">Razón Social:</asp:label></TD>
											<TD><asp:textbox id="txtRSocialNew1" runat="server" Width="300px" MaxLength="200"></asp:textbox></TD>
										</TR>
									</TABLE>
							</TD>
							
							<td>
							</td>
							</tr>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="DISPLAY: none">
						<TABLE style="Z-INDEX: 0; WIDTH: 440px; HEIGHT: 135px" id="tblTrabajador" border="0" cellSpacing="1"
							cellPadding="1" width="440">
							<TR>
								<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label18" runat="server">Nro DOCUMENTO:</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtNroDNIReg" runat="server" Width="152px" CssClass="normaldetalle"
										MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label19" runat="server"> APELLIDO PATERNO:</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtApellidoP" runat="server" Width="208px" CssClass="normaldetalle"
										MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label20" runat="server"> APELLIDO MATERNO:</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtApellidoM" runat="server" Width="208px" CssClass="normaldetalle"
										MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label21" runat="server">NOMBRES:</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtNombres" runat="server" Width="208px" CssClass="normaldetalle"
										MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label22" runat="server">NACIONALIDAD</asp:label></TD>
								<TD><asp:dropdownlist style="Z-INDEX: 0" id="ddlNacionalidad" runat="server" Width="208px" CssClass="normaldetalle"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
						var  FECHAINICIOPROG="FechaIniProg"
						var  FECHATERMINOPROG="FechaTermProg"
						var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
						
						
						//var _ddlTipoEntidad = $('ddlTipoEntidad'); 
						function ConfiguraBusquedaEntidad(){
							/*	var _CelltxtPersona = jNet.get('FEntidad');
								if((_ddlTipoEntidad.options[_ddlTipoEntidad.selectedIndex].value==1)||(_ddlTipoEntidad.options[_ddlTipoEntidad.selectedIndex].value==0)){
										_CelltxtPersona.style.display="block";
										var otxtBuscarEntidad = jNet.get('txtBuscarEntidad');
										otxtBuscarEntidad.focus();
								}
								else{	
										//jNet.get('hidTipoEntidad').value=5;
										jNet.get('hidEntidad').value="000000";
										_CelltxtPersona.style.display="none";
										jNet.get('txtNroDNI').focus();
								}	*/
								
								jNet.get('txtTipoVisita').value = oPagina.Request.Params[KEYQIDTITUTIPOENTIDAD];
								var _CelltxtPersona = jNet.get('FEntidad');
								if((oPagina.Request.Params[KEYQIDTIPOENTIDAD]==1)||(oPagina.Request.Params[KEYQIDTIPOENTIDAD]==0)){
										_CelltxtPersona.style.display="block";
										var otxtBuscarEntidad = jNet.get('txtBuscarEntidad');
										//otxtBuscarEntidad.focus();
								}
								else{	
										//jNet.get('hidTipoEntidad').value=5;
										jNet.get('hidEntidad').value="000000";
										_CelltxtPersona.style.display="none";
										//jNet.get('txtNroDNI').focus();
								}									
									
						}	
						
				//Configura el uadro de busqueda de clientes po proveedores
				ConfiguraBusquedaEntidad();	
											
						
				var oParamCollecionBusqueda = new ParamCollecionBusqueda();
				var oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="NroDNI";
					oParamBusqueda.Texto="Trabajador";
					oParamBusqueda.LongitudEjecucion=8;
					oParamBusqueda.CampoAlterno="ApellidosNombres";
					oParamBusqueda.Tipo="C";
				oParamCollecionBusqueda.Agregar(oParamBusqueda);
				
					oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="idProceso";
					oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.ConsultarUbicacionTrabajador;
					oParamBusqueda.Tipo="Q";
				oParamCollecionBusqueda.Agregar(oParamBusqueda);
		
				(new AutoBusqueda('txtNroDNI')).Crear( '/' + ApplicationPath + '/Personal/Procesar.aspx?',oParamCollecionBusqueda);	

				/*---------------------------------------------------------------------------------------*/
				var oParamCollecionBusqueda = new ParamCollecionBusqueda();
				var oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="ApellidosNombres";
					oParamBusqueda.Texto="Apellidos y Nombres";
					oParamBusqueda.LongitudEjecucion=7;
					oParamBusqueda.CampoAlterno="NroDNI";
					oParamBusqueda.Tipo="C";
				oParamCollecionBusqueda.Agregar(oParamBusqueda);
				
					oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="idProceso";
					oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.ConsultarUbicacionTrabajador;
					oParamBusqueda.Tipo="Q";
				oParamCollecionBusqueda.Agregar(oParamBusqueda);
		
				(new AutoBusqueda('txtTrabajador')).Crear( '/' + ApplicationPath + '/Personal/Procesar.aspx?',oParamCollecionBusqueda);	

					
				var oParamCollecionBusqueda1 = new ParamCollecionBusqueda();
						var oParamBusqueda1 = new ParamBusqueda();
							oParamBusqueda1.Nombre="Nombres";
							oParamBusqueda1.Texto="Apellidos y Nombres";
							oParamBusqueda1.LongitudEjecucion=1;
							oParamBusqueda1.Tipo="C";
							oParamBusqueda1.CampoAlterno = "NroPersonal";
							oParamBusqueda1.LongitudEjecucion=4;
						oParamCollecionBusqueda1.Agregar(oParamBusqueda1);

							oParamBusqueda1 = new ParamBusqueda();
							oParamBusqueda1.Nombre="idProceso";
							oParamBusqueda1.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarPersonal;
							oParamBusqueda1.Tipo="Q";
						oParamCollecionBusqueda1.Agregar(oParamBusqueda1);
						(new AutoBusqueda('txtAutorizadoPor')).Crear('/' + ApplicationPath + '/GestionFinanciera/Procesar.aspx?',oParamCollecionBusqueda1);
												
						
		</SCRIPT>
		
		
	</body>
</HTML>
