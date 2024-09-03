<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="AdministrarRegistrodeAtencion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarRegistrodeAtencion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarRegistrodeAtencion</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script>
			function txtAreaDestino_ItemDataBound(sender,e,dr){
				jNet.get("hIdArea").value=dr["IDAREA"];
				__doPostBack('ibtnAgregar','');								
			}

		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR>
					<TD vAlign="top" width="100%" align="left"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="left"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands" vAlign="top" width="100%" align="left">
						<asp:label style="Z-INDEX: 0" id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Seguridad></asp:label>
						<asp:label style="Z-INDEX: 0" id="lblPagina" runat="server" CssClass="RutaPaginaActual"> > Registro de visitas por área></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD vAlign="top" width="100%" colSpan="2" align="left"><TABLE style="HEIGHT: 32px" id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%">
										<TR>
											<TD class="HeaderDetalle" colSpan="4" noWrap>
												<asp:label style="Z-INDEX: 0" id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"
													Width="160px" Height="8px">REGISTRO DE VISITAS (CONTROL Y PERMANENCIA POR AREA)</asp:label></TD>
										</TR>
										<TR>
											<TD class="HeaderDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label23" runat="server">Area destino:</asp:label></TD>
											<TD width="60%"><asp:textbox id="txtAreaDestino" runat="server" CssClass="normalDetalle" Width="100%"></asp:textbox></TD>
											<TD class="HeaderDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label1" runat="server">FECHA:</asp:label></TD>
											<TD width="40%"><asp:textbox id="txtFecha" runat="server" CssClass="normalDetalle" Width="96px" rel="Calendario"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="2" align="right">
									<TABLE id="Table4" border="1" cellSpacing="1" cellPadding="1" width="300">
										<TR>
											<TD>
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnDiagnostico" runat="server" ImageUrl="../imagenes/Navegador/btnDiagnostico.GIF"></asp:imagebutton></TD>
											<TD>
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnMedicacion" runat="server" ImageUrl="../imagenes/Navegador/btnMedicacion.GIF"></asp:imagebutton></TD>
											<TD></TD>
											<TD>
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
									<INPUT style="Z-INDEX: 0; WIDTH: 72px; HEIGHT: 22px" id="hIdArea" size="6" type="hidden"
										name="hIdArea" runat="server"></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="2"><asp:datagrid style="Z-INDEX: 0" id="GridRegVis" runat="server" Width="100%" PageSize="60" AutoGenerateColumns="False"
										AllowSorting="True">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle Height="20px" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="APELLIDOS Y NOMBRE">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
												<ItemTemplate>
													<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%">
														<TR>
															<TD width="100%">
																<asp:textbox style="Z-INDEX: 0" id="txtTrabajador" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
															<TD>
																<asp:Image style="Z-INDEX: 0" id="imgAG" runat="server" ImageUrl="../imagenes/BtPU_Mas.gif"></asp:Image></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="MOTIVO">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
												<ItemTemplate>
													<asp:TextBox id="txtMotivo" runat="server" CssClass="normalDetalle" Height="30px" Width="100%"
														TextMode="MultiLine"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="HORA ING">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
												<ItemTemplate>
													<ew:timepicker style="Z-INDEX: 0" id="tmHoraIng" runat="server" Width="60px" ImageUrl="../imagenes/BtPU_fecha.gif"
														MinuteInterval="FiveMinutes" JavascriptOnChangeFunction="FechaSelected" PopupLocation="Bottom"
														PopupWidth="80px" ControlDisplay="TextBoxImage" NumberOfColumns="1">
														<ButtonStyle BackColor="White"></ButtonStyle>
														<TextboxLabelStyle CssClass="normaldetalle" BackColor="White"></TextboxLabelStyle>
														<ClearTimeStyle CssClass="normaldetalle" BackColor="White"></ClearTimeStyle>
														<TimeStyle Font-Size="8pt" Height="10px" ForeColor="Navy" BackColor="#FFCC66"></TimeStyle>
														<SelectedTimeStyle Font-Size="7pt" BackColor="White"></SelectedTimeStyle>
													</ew:timepicker>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="HORA SAL">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
												<ItemTemplate>
													<ew:timepicker style="Z-INDEX: 0" id="tmHoraSal" runat="server" Width="60px" ImageUrl="../imagenes/BtPU_fecha.gif"
														MinuteInterval="FiveMinutes" JavascriptOnChangeFunction="FechaSelected" PopupLocation="Bottom"
														PopupWidth="80px" ControlDisplay="TextBoxImage" NumberOfColumns="1">
														<ButtonStyle BackColor="White"></ButtonStyle>
														<TextboxLabelStyle CssClass="normaldetalle" BackColor="White"></TextboxLabelStyle>
														<ClearTimeStyle CssClass="normaldetalle" BackColor="White"></ClearTimeStyle>
														<TimeStyle Font-Size="8pt" Height="10px" ForeColor="Navy" BackColor="#FFCC66"></TimeStyle>
														<SelectedTimeStyle Font-Size="7pt" BackColor="White"></SelectedTimeStyle>
													</ew:timepicker>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="Periodo" SortExpression="Periodo" HeaderText="Prog">
												<HeaderStyle Width="2%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:image style="Z-INDEX: 0" id="imgEliminar22" runat="server" Height="20px" Width="20px"
														ImageUrl="../imagenes/Filtro/Eliminar.gif"></asp:image>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
						<INPUT style="WIDTH: 84px; HEIGHT: 22px" id="hIdsAcciones" size="8" type="hidden" name="hIdsAcciones"
							runat="server"> <INPUT style="Z-INDEX: 0; WIDTH: 90px; HEIGHT: 22px" id="hIdGrupoVerificacion" size="9"
							type="hidden" name="Hidden1" runat="server">
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center" style="DISPLAY: block">
						<TABLE id="tblTrabajador" border="5" cellSpacing="1" cellPadding="1" width="300">
							<TR>
								<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label2" runat="server">Nro DOCUMENTO:</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtNroDNI" runat="server" CssClass="normaldetalle" Width="152px"
										MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label4" runat="server"> APELLIDO PATERNO:</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtApellidoPaterno" runat="server" CssClass="normaldetalle"
										Width="478px" MaxLength="120"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" noWrap>
									<asp:label style="Z-INDEX: 0" id="Label3" runat="server"> APELLIDO MATERNO:</asp:label></TD>
								<TD>
									<asp:textbox style="Z-INDEX: 0" id="txtApellidoMaterno" runat="server" CssClass="normaldetalle"
										Width="478px" MaxLength="120"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" noWrap>
									<asp:label style="Z-INDEX: 0" id="Label5" runat="server">NOMBRES:</asp:label></TD>
								<TD>
									<asp:textbox style="Z-INDEX: 0" id="txtNombres" runat="server" CssClass="normaldetalle" Width="478px"
										MaxLength="120"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label13" runat="server">NACIONALIDAD</asp:label></TD>
								<TD><asp:dropdownlist style="Z-INDEX: 0" id="ddlNacionalidad" runat="server" CssClass="normaldetalle"
										Width="208px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="DISPLAY: none" id="CellLstCausaRaiz" vAlign="top" width="100%" align="center"
						runat="server"></TD>
				</TR>
			</table>
		</form>
		<script>
			function ConfigurarControlesFecha(Collecion){
				var textBoxes = Ext.DomQuery.select("input[rel=" + Collecion + "]");   
				Ext.each(textBoxes, function(item, id, all){   
					var cl = new Ext.form.DateField({   
						format: 'd/m/Y',
						allowBlank : false,   
						applyTo: item,
						listeners:{
							select:function(){
									__doPostBack('ibtnAgregar','');	
								}
							}
					});
				});
			}
			ConfigurarControlesFecha('Calendario');
			
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
			(new AutoBusqueda('txtAreaDestino')).Crear( '/' + ApplicationPath + '/Personal/Procesar.aspx?',oParamCollecionBusqueda);
						
			
		</script>
		<SCRIPT language="javascript" type="text/javascript">
				function CrearControlsdeBusqueda(){
					var NombreCtrl="";
					var oDataGrid = jNet.get('GridRegVis');
					for(var r=1;r<=oDataGrid.rows.length-1;r++){
						var oCell1=jNet.get(oDataGrid.rows[r].cells[1]);
						var tblObj = oCell1.childNodes[0];
						var txtSearch =  tblObj.rows[0].cells[0].childNodes[0];
						var NameTxtSearch=txtSearch.id;
						
						var IdxRow = (oDataGrid.rows[r].rowIndex+1);
						ConfiguraBusqueda(IdxRow,NameTxtSearch,"");
					}
				}
	
				
				function ConfiguraBusqueda(r,otxtSearch,TextNew){
					var FechaYYYYMMDD = ConvertYYYYmmDD(jNet.get('txtFecha').value,'/') ;
					var NombreCtrl=otxtSearch;
					var DefParametros = "var oParamCollecionBusqueda" + r + " = new ParamCollecionBusqueda();\n"
						DefParametros += " var oParamBusqueda" + r + " = new ParamBusqueda();\n";
						DefParametros += "	oParamBusqueda" + r + ".Nombre='ApellidosNombres';\n";
						DefParametros += "	oParamBusqueda" + r + ".Texto='Persona';\n";
						DefParametros += "	oParamBusqueda" + r + ".LongitudEjecucion=2;\n";
						DefParametros += "	oParamBusqueda" + r + ".Tipo='C';\n";
						DefParametros += "	oParamBusqueda" + r + ".CampoAlterno = 'NroDNI';\n";
						DefParametros += "	oParamBusqueda" + r + ".LongitudEjecucion=4;\n";
						DefParametros += " oParamCollecionBusqueda" + r + ".Agregar(oParamBusqueda" + r + ");\n";


						DefParametros += "	oParamBusqueda" + r + " = new ParamBusqueda();\n";
						DefParametros += "	oParamBusqueda" + r + ".Nombre='FechaIniProg';\n";
						DefParametros += "	oParamBusqueda" + r + ".Valor='"+ FechaYYYYMMDD + "';\n";
						DefParametros += "	oParamBusqueda" + r + ".Tipo='Q';\n";
						DefParametros += " oParamCollecionBusqueda" + r + ".Agregar(oParamBusqueda" + r + ");\n";

						DefParametros += "	oParamBusqueda" + r + " = new ParamBusqueda();\n";
						DefParametros += "	oParamBusqueda" + r + ".Nombre='idProceso';\n";
						DefParametros += "	oParamBusqueda" + r + ".Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarTrabajador;\n";
						DefParametros += "	oParamBusqueda" + r + ".Tipo='Q';\n";
						DefParametros += " oParamCollecionBusqueda" + r + ".Agregar(oParamBusqueda" + r + ");\n";

						DefParametros += "(new AutoBusqueda('" + NombreCtrl + "')).Crear('/' + ApplicationPath + '/Personal/Visitas/Proceso.aspx?',oParamCollecionBusqueda" + r + ");\n";
						
						
						var strCSrip = "function " + NombreCtrl + "_ItemDataBound(sender,e,dr){\n";
						strCSrip += " FindTxtDataSelected(sender,e,dr);\n";
						strCSrip += "}\n";
						
					
							window.execScript(DefParametros);
							window.execScript(strCSrip);
										
						
				}
				
				var arrPosition = new Array(5);
				
				
				function FindTxtDataSelected(sender,e,dr){
						var rowSelected = e.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
						
						CambiaDATATrama(rowSelected,1,dr["NroDNI"]);
						CambiaDATATrama(rowSelected,2,dr["ApellidosNombres"]);
						

					var oCCTT_ProgramacionTrabajadoresContratistaBE = new EntidadesNegocio.Personal.CCTT_ProgramacionTrabajadoresContratistaBE();
						oCCTT_ProgramacionTrabajadoresContratistaBE=(new Controladora.Personal.CCCTT_ProgramacionTrabajadoresContratista()).DetalleUbicacionTrabajador(dr["NroDNI"].toString());
						
						if(oCCTT_ProgramacionTrabajadoresContratistaBE!=null){
							var strFechTerminoYYYYMMDD = ConvertYYYYmmDD(oCCTT_ProgramacionTrabajadoresContratistaBE.FechaTermino,'-') ; 
							var strFechaHoyYYYYMMDD =  ConvertYYYYmmDD(jNet.get('txtFecha').value,'/') ;
							
							if(parseInt(strFechTerminoYYYYMMDD)>=parseInt(strFechaHoyYYYYMMDD)){
								CambiaDATATrama(rowSelected,9,oCCTT_ProgramacionTrabajadoresContratistaBE.NroProgramacion);
								CambiaDATATrama(rowSelected,10,oCCTT_ProgramacionTrabajadoresContratistaBE.Periodo);
								//Establece valor encontrado de programacion en la penultima columna
								rowSelected.cells[5].innerText = oCCTT_ProgramacionTrabajadoresContratistaBE.Periodo+ '-'+oCCTT_ProgramacionTrabajadoresContratistaBE.NroProgramacion;
							}
						}
										
						//Llamada a Metodo de actualizacion
						DATA=e.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.getAttribute("DATA");
						var idRegIng = (new Controladora.Personal.CCTT_ProgramacionTrabajadorUbicacionGPS()).InsAct(EstablecerDatos(DATA));
						CambiaDATATrama(rowSelected,0,idRegIng); //actualiza el indice

				}
				
				
				function EstablecerDatos(DATA){
					var arrData= DATA.split('@');
					var oCCTT_ProgramacionTrabajadorUbicacionGPSBE = new EntidadesNegocio.Personal.CCTT_ProgramacionTrabajadorUbicacionGPSBE();
					oCCTT_ProgramacionTrabajadorUbicacionGPSBE.IdRegIng=arrData[0];
					oCCTT_ProgramacionTrabajadorUbicacionGPSBE.NroDNI =arrData[1];
					oCCTT_ProgramacionTrabajadorUbicacionGPSBE.Fecha=document.getElementById("txtFecha").value;
					oCCTT_ProgramacionTrabajadorUbicacionGPSBE.IdArea=arrData[3];
					oCCTT_ProgramacionTrabajadorUbicacionGPSBE.HoraIng=arrData[4];
					oCCTT_ProgramacionTrabajadorUbicacionGPSBE.HoraSal=arrData[5];
					oCCTT_ProgramacionTrabajadorUbicacionGPSBE.Motivo=arrData[6];
					oCCTT_ProgramacionTrabajadorUbicacionGPSBE.Latitud=arrData[7];
					oCCTT_ProgramacionTrabajadorUbicacionGPSBE.Longitud=arrData[8];
					oCCTT_ProgramacionTrabajadorUbicacionGPSBE.NroProgramacion=arrData[9];
					oCCTT_ProgramacionTrabajadorUbicacionGPSBE.Periodo=arrData[10];
					return oCCTT_ProgramacionTrabajadorUbicacionGPSBE;
				}
				
				
				function CambiaDATATrama(row,idx,Valor){
					var strData="";
					var arrData = row.getAttribute("DATA").split('@');
					arrData[idx]=Valor;
					var Modo = arrData[arrData.length-1];
					arrData[arrData.length-1]='M';
					strData='';
					
					for(var i=0;i<=arrData.length-1;i++){
						strData = strData + arrData[i] + "@";
					}
					strData = strData.substring(0,strData.length-1);
					
					row.setAttribute("DATA",strData);
				}
				
				
				function RowDataSelected(e){
						//alert(e);
				}
				
				
				CrearControlsdeBusqueda();
						
						
						
			function FechaSelected(selTime,tbName){
				var Obj = document.getElementById(tbName);
				var rowSelected=Obj.parentNode.parentNode.parentNode;
				var Idx= ((tbName.indexOf("tmHoraIng")!=-1)?4:5);
				
				CambiaDATATrama(rowSelected,Idx,selTime);
				//Llamada a Metodo de actualizacion
				DATA=rowSelected.getAttribute("DATA");
				var idRegIng = (new Controladora.Personal.CCTT_ProgramacionTrabajadorUbicacionGPS()).InsAct(EstablecerDatos(DATA));
				CambiaDATATrama(rowSelected,0,idRegIng); //actualiza el indice
			}	

			function CambiarMotivo(e){
				var rowSelected = e.parentNode.parentNode;
				var DATA =rowSelected.getAttribute("DATA");
				var OldVal=DATA.split('@')[6];
				if(OldVal!=e.value){
					CambiaDATATrama(rowSelected,6,e.value);
					 DATA =rowSelected.getAttribute("DATA");
					var idRegIng = (new Controladora.Personal.CCTT_ProgramacionTrabajadorUbicacionGPS()).InsAct(EstablecerDatos(DATA));
					CambiaDATATrama(rowSelected,0,idRegIng); //actualiza el indice
				}
			}
		</SCRIPT>
		<script>
			//Para Agregar a un trbajador
			var btnAG;
			function AgregarTrabajador(e){
				btnAG=e;
				var oddlNacionalidad	= jNet.get( 'ddlNacionalidad');
				var oItemNac = oddlNacionalidad.options[oddlNacionalidad.selectedIndex];
				jNet.get('txtNroDNI').value ="";
				jNet.get('txtApellidoPaterno').value="";
				jNet.get('txtApellidoMaterno').value="";
				jNet.get('txtNombres').value="";
				
				(new System.Ext.UI.WebControls.Windows()).DetalleFromEL('MiWind','tblTrabajador','AGREGAR PERSONA',630,200,AceptarAccion);
			}
			
			function AceptarAccion(e){
				var rowSelected = btnAG.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
				var objTxtFind = btnAG.parentNode.parentNode.cells[0].children[0];
				
				var oddlNacionalidad	= jNet.get( 'ddlNacionalidad');
				var oItemNac = oddlNacionalidad.options[oddlNacionalidad.selectedIndex];
				//Crea un registro en el maetro de visitas
				var oCCTT_TrabajadorBE = new EntidadesNegocio.Personal.CCTT_TrabajadorBE();
				
				if(jNet.get('txtApellidoPaterno').value.length==0){ Ext.MessageBox.alert('AVISO', "No se ha ingresado apellido paterno" , function(btn){}); return false;}
				if(jNet.get('txtApellidoMaterno').value.length==0){ Ext.MessageBox.alert('AVISO', "No se ha ingresado apellido materno" , function(btn){}); return false;}
				if(jNet.get('txtNombres').value.length==0){ Ext.MessageBox.alert('AVISO', "No se ha ingresado nombres" , function(btn){}); return false;}
				
				oCCTT_TrabajadorBE.NroDNI = jNet.get('txtNroDNI').value;
				oCCTT_TrabajadorBE.ApPaterno=jNet.get('txtApellidoPaterno').value;
				oCCTT_TrabajadorBE.ApMaterno=jNet.get('txtApellidoMaterno').value;
				oCCTT_TrabajadorBE.Nombre=jNet.get('txtNombres').value;
				oCCTT_TrabajadorBE.ApellidosyNombres=oCCTT_TrabajadorBE.ApPaterno + ' ' + oCCTT_TrabajadorBE.ApMaterno + ' ' + oCCTT_TrabajadorBE.Nombre;
				oCCTT_TrabajadorBE.IdNacionalidad=oItemNac.value;
				var NewNroDNI=(new AccesoDatos.NoTransacional.Personal.CCCTT_TrabajadorVisita()).Insertar(oCCTT_TrabajadorBE);
				
				objTxtFind.value = oCCTT_TrabajadorBE.ApellidosyNombres;
				
				//Actualiza la trama del registro seleccionado
				CambiaDATATrama(rowSelected,1,NewNroDNI);
				CambiaDATATrama(rowSelected,2,oCCTT_TrabajadorBE.ApellidosyNombres);
				
				var DATA=rowSelected.getAttribute("DATA");	
				var idRegIng = (new Controladora.Personal.CCTT_ProgramacionTrabajadorUbicacionGPS()).InsAct(EstablecerDatos(DATA));
				CambiaDATATrama(rowSelected,0,idRegIng); //actualiza el indice

				e.hide();
			}
			
			//Eliminar registro
			function Eliminar(e){
				var rowSelected = e.parentNode.parentNode;
				var DATA=rowSelected.getAttribute("DATA");
				var arrData = DATA.split('@');
				Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro ahora?', function(btn){
					if(btn=="yes"){
						(new Controladora.Personal.CCTT_ProgramacionTrabajadorUbicacionGPS()).Eliminar(arrData[0]);
						__doPostBack('ibtnAgregar','');
					}
				});					

			}
			
		</script>
	</body>
</HTML>
