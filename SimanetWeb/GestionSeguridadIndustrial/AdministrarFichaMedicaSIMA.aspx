<%@ Page language="c#" Codebehind="AdministrarFichaMedicaSIMA.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarFichaMedicaSIMA" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarSCTR</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Menu/MenuSP.js"></script>
		<script type="text/javascript" src="../js/RegEXT.js"></script>
		<SCRIPT language="javascript" src="../js/JQuery/js/jquery.min.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>
		<SCRIPT>
			var jSIMA = jQuery.noConflict();
		</SCRIPT>
		<script>
										
						function txtPR_ItemDataBound(sender,e,dr){
							jNet.get('hIdPersonal').value = dr["IdPersonal"];
							jNet.get('txtApellidosyNombres').value = dr["Nombres"];
							__doPostBack('btnFiltar','');
						}

						
						function CalcularFechaVence(Fecha,Source){
							var opddlAptitud = new System.Web.UI.WebControls.DropDownList('pddlAptitud');
							var oItem = opddlAptitud.FindByText(Aptitud);
							
							jNet.get('txtFechaVence').value= (new Controladora.SeguridadIndustrial.CCCTT_ExamenMedico()).CalcularVencimiento(Fecha);
						}
						
						
						function AceptaModifica(oWind){
							var opddlAptitud = new System.Web.UI.WebControls.DropDownList('pddlAptitud');
							var oItem = opddlAptitud.ListItem();
							var strParam = jNet.get("hIdPersonal").value +';'+
											jNet.get("hPeriodo").value +';'+
											jNet.get("hIdFicha").value +';'+
											jNet.get('pCalFecha').value+';'+
											jNet.get('txtNdiasDescanso').value +';'+ 
											oItem.value;
							__doPostBack('btnModifica',strParam );
							oWind.hide();
						}
						
						function DetalleFicha(NroPR,IdPersonal,ApellidosyNombres,NroDias,Aptitud,FechaInicio,FechaVencimiento){
							PopupDeEsperaClose();
							jNet.get("ptxtNroPR").value = NroPR;
							jNet.get("hIdPersonal").value = IdPersonal;
							jNet.get("txtNdiasDescanso").value = NroDias;
							
							jNet.get("ptxtApellidosyNombres").value = ApellidosyNombres;
							jNet.get("pCalFecha").value= FechaInicio;
							jNet.get("ptxtFechaVence").value=FechaVencimiento;
							var opddlAptitud = new System.Web.UI.WebControls.DropDownList('pddlAptitud');
							var oItem = opddlAptitud.FindByText(Aptitud);
							(new System.Ext.UI.WebControls.Windows()).DetalleFromEL('MiVentana','tblDetalle','Detalle',670,130,AceptaModifica);
							
						}
						
						function EliminarFicha(IdPersonal,Periodo,IdFicha){
							Ext.MessageBox.confirm('ELIMINAR', 'Desea Ud. Hacer efectiva la eliminación de este registro ahora?', function(btn){
								if(btn=="yes"){
									__doPostBack('ibtnEliminar',IdPersonal +';'+Periodo+';'+IdFicha);
								}
							});
						}
						
						
						var oWindModal;
						function ListarRestricciones(Periodo,IdFicha){
							var KEYQPERIODO ="Periodo";
							var KEYQIDFICHA ="IdFicha";
							var KEYQIDPERMANENTE ="IdPerm";
							
							var TabDetalle=new Array();
							var idx=0;
							var strParametros= KEYQPERIODO + "=" + Periodo + "&" + KEYQIDFICHA + "="+ IdFicha;
							var URLLOCAL = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionSeguridadIndustrial/AdministrarFichaMedicaRestriccionesSIMA.aspx?" + strParametros  + "&" + KEYQIDPERMANENTE + "=1";
							TabDetalle[idx]={title : "Permanentes",autoLoad: {url: URLLOCAL, scripts : true},selected:0};
							idx++;
						
							URLLOCAL = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionSeguridadIndustrial/AdministrarFichaMedicaRestriccionesSIMA.aspx?"+ strParametros + "&" + KEYQIDPERMANENTE + "=2";
							TabDetalle[idx]={title : "No Permanentes",autoLoad: {url: URLLOCAL, scripts : true},selected:0};
							idx++;
									
							oWindModal = (new System.Ext.UI.WebControls.Windows()).DialogoTabs('RESTRICCIONES',TabDetalle,this,550,window.screen.height-150);		
							
						}
		</script>
		<script>
						var KEYQPERIODO ="Periodo";
						var KEYQIDFICHA ="IdFicha";
						var KEYQIDESTADO ="IdEst";
						var KEYQIDRESTRICCION ="IdRestr";
				
					function AgregarRestriccion(Periodo,IdFicha,IdRestriccion,oCHK){
						var IdEstado=((oCHK.checked==true)?1:0);
						var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
						var oExamenMedicoRestricionesSIMABE =new EntidadesNegocio.GestionSeguridadIndustrial.ExamenMedicoRestricionesSIMABE();
						oExamenMedicoRestricionesSIMABE.Periodo=Periodo;
						oExamenMedicoRestricionesSIMABE.IdFicha=IdFicha;
						oExamenMedicoRestricionesSIMABE.IdRestriccion=IdRestriccion;
						oExamenMedicoRestricionesSIMABE.IdEstado=IdEstado;		

						(new Controladora.SeguridadIndustrial.CCCTT_RestriccionesSIMA()).InsertarUpdate(oExamenMedicoRestricionesSIMABE);
					}
					
		</script>
	</HEAD>
	<body onkeydown="if (event.keyCode==13)return false" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%" height="100%">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label style="Z-INDEX: 0" id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de seguridad>Administración</asp:label><asp:label style="Z-INDEX: 0" id="lblPagina" runat="server" CssClass="RutaPaginaActual">>Ficha Medica></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left">
						<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="300" align="center">
							<TR>
								<TD align="center"><asp:label style="Z-INDEX: 0" id="Label4" runat="server">ADMINISTRAR FICHA MEDICA</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%">
										<TR>
											<TD class="HeaderGrilla" rowSpan="2" noWrap><asp:label style="Z-INDEX: 0" id="Label1" runat="server">NRO PR:</asp:label></TD>
											<TD vAlign="middle" rowSpan="2" align="left"><asp:textbox style="Z-INDEX: 0" id="txtPR" runat="server" CssClass="normaldetalle" Width="103px"></asp:textbox></TD>
											<TD class="HeaderGrilla" rowSpan="2" noWrap><asp:label style="Z-INDEX: 0" id="Label2" runat="server">APELLIDOS Y NOMBRES:</asp:label></TD>
											<TD rowSpan="2">
												<TABLE id="Table4" border="0" cellSpacing="1" cellPadding="1" width="300" align="left">
													<TR>
														<TD><asp:textbox style="Z-INDEX: 0" id="txtApellidosyNombres" runat="server" CssClass="normaldetalle"
																Width="300px" BackColor="#E0E0E0"></asp:textbox></TD>
														<TD></TD>
													</TR>
												</TABLE>
											</TD>
											<TD class="HeaderGrilla" rowSpan="2"><asp:label style="Z-INDEX: 0" id="Label3" runat="server">APTITUD:</asp:label></TD>
											<TD rowSpan="2"><asp:dropdownlist style="Z-INDEX: 0" id="ddlAptitud" runat="server" CssClass="normaldetalle"></asp:dropdownlist></TD>
											<TD class="HeaderGrilla" colSpan="6" align="center"><asp:label style="Z-INDEX: 0" id="Label7" runat="server">FECHA:</asp:label></TD>
											<TD rowSpan="2"><asp:imagebutton style="Z-INDEX: 0" id="imgAgregar" runat="server" Width="42px" Height="39px" ImageUrl="../imagenes/Navegador/Plus.png"></asp:imagebutton></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label5" runat="server"> INICIO:</asp:label></TD>
											<TD noWrap><asp:textbox id="txtFechaIni" runat="server" CssClass="normaldetalle" Width="96px" rel="calendar"></asp:textbox></TD>
											<TD class="HeaderGrilla" noWrap><asp:label style="Z-INDEX: 0" id="Label13" runat="server">DIAS DESCANSO:</asp:label></TD>
											<TD noWrap><span id="201" class="obs-field"><asp:textbox style="Z-INDEX: 0" id="txtDiasDescanso" runat="server" CssClass="normaldetalle"
														Width="30px" ReadOnly="false">1</asp:textbox></span></TD>
											<TD class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label6" runat="server">VENCIMIENTO:</asp:label></TD>
											<TD><asp:textbox style="Z-INDEX: 0" id="txtFechaVence" runat="server" CssClass="normaldetalle" Width="90px"
													ReadOnly="True"></asp:textbox></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center"><INPUT id="hIdFila" value="0" type="hidden" name="hIdFila" runat="server"><INPUT style="WIDTH: 57px; HEIGHT: 22px" id="hGridPaginaSort" size="4" type="hidden" name="hGridPaginaSort"
										runat="server"><INPUT style="WIDTH: 50px; HEIGHT: 22px" id="hGridPagina" value="0" size="3" type="hidden"
										name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hPeriodo" size="1" type="hidden"
										name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hIdFicha" value="0" size="1" type="hidden"
										name="hGridPagina" runat="server"><INPUT id="hIdPersonal" type="hidden" name="hIdPersonal" runat="server"></TD>
							</TR>
							<TR>
								<TD align="left">
									<TABLE id="Table5" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminaFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD></TD>
											<TD width="100%"></TD>
											<TD>
												<asp:Button style="Z-INDEX: 0" id="cmdMedicamento" runat="server" Text="Medicamento" Visible="False"></asp:Button></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="100%" Height="1px" AllowSorting="True"
										PageSize="12" AutoGenerateColumns="False" RowPositionEnabled="False" RowHighlightColor="#E0E0E0"
										AllowPaging="True" ShowFooter="True">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle Height="25px" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroPersonal" SortExpression="NroPersonal" HeaderText="NRO DOC">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ApellidosyNombres" HeaderText="APELLIDOS Y NOMBRES">
												<HeaderStyle Width="60%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreAptitud" SortExpression="NombreAptitud" HeaderText="APTITUD">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FechaInicio" HeaderText="FECHA INICIO">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroDiasDescanso" SortExpression="NroDiasDescanso" HeaderText="NRO DIAS"></asp:BoundColumn>
											<asp:BoundColumn DataField="FechaVencimiento" HeaderText="FECHA VENCIMIENTO">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<ItemTemplate>
													<asp:Image style="Z-INDEX: 0" id="imgEliminar" runat="server" ImageUrl="/SimanetWeb/imagenes/Filtro/Eliminar.gif"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD style="DISPLAY: block" id="cellOculta">
									<TABLE id="tblDetalle" border="0" cellSpacing="1" cellPadding="1" width="300">
										<TR>
											<TD class="HeaderGrilla" noWrap><asp:label style="Z-INDEX: 0" id="Label8" runat="server">NRO DOC:</asp:label></TD>
											<TD><asp:textbox style="Z-INDEX: 0" id="ptxtNroPR" runat="server" CssClass="normaldetalle" Width="103px"
													ReadOnly="True"></asp:textbox></TD>
											<TD class="HeaderGrilla" colSpan="2" noWrap><asp:label style="Z-INDEX: 0" id="Label9" runat="server">APELLIDOS Y NOMBRES:</asp:label></TD>
											<TD colSpan="4"><asp:textbox style="Z-INDEX: 0" id="ptxtApellidosyNombres" runat="server" CssClass="normaldetalle"
													Width="300px" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label10" runat="server">APTITUD:</asp:label></TD>
											<TD><asp:dropdownlist style="Z-INDEX: 0" id="pddlAptitud" runat="server" CssClass="normaldetalle"></asp:dropdownlist></TD>
											<TD class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label11" runat="server"> INICIO:</asp:label></TD>
											<TD width="150"><asp:textbox id="pCalFecha" runat="server" CssClass="normaldetalle" Width="100px" rel="calendar"></asp:textbox></TD>
											<TD class="HeaderGrilla" align="left"><asp:label style="Z-INDEX: 0" id="Label14" runat="server">DIAS DESCANSO:</asp:label></TD>
											<TD><asp:textbox id="txtNdiasDescanso" runat="server" CssClass="normaldetalle" Width="58px"></asp:textbox></TD>
											<TD class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label12" runat="server">VENCIMIENTO:</asp:label></TD>
											<TD><asp:textbox style="Z-INDEX: 0" id="ptxtFechaVence" runat="server" CssClass="normaldetalle" Width="80px"
													ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
									<asp:button id="btnModifica" runat="server" Text="Modificar"></asp:button><asp:button id="ibtnEliminar" runat="server" Text="Eliminar"></asp:button><asp:button style="Z-INDEX: 0" id="btnFiltar" runat="server" Text="Filtrar"></asp:button></TD>
							</TR>
							<TR>
								<TD style="DISPLAY: block"><IMG style="Z-INDEX: 0" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 4px" vAlign="top" align="left">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="BORDER-BOTTOM: #808080 1px dotted; PADDING-BOTTOM: 5px; HEIGHT: 20px" id="ContextSCTR"
						runat="server"></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top" align="center"></TD>
				</TR>
				<TR>
					<TD style="DISPLAY: block" align="center"></TD>
				</TR>
			</TABLE>
			<script>

			var textBoxes = Ext.DomQuery.select("input[rel=calendar]");   
			Ext.each(textBoxes, function(item, id, all){   
				var cl = new Ext.form.DateField({   
					format: 'd/m/Y',
					allowBlank : false,
					applyTo: item,
						listeners:{
							select:function(e,a,c){
									if(e.id=='ext-comp-1001'){
										CalcularFechaFin(1,'txtFechaIni');
									}
									else{
										CalcularFechaFin(2,'pCalFecha');
									}
								}
							}   
				});
			});   			
		
			jSIMA('#txtDiasDescanso').on('change keyup paste',function(e){
																		if(jNet.get('txtDiasDescanso').value.length>0){
																			CalcularFechaFin(1,'txtFechaIni');
																		}
																		else{
																			jNet.get('txtFechaVence').value='';
																		}
																	}
			);

			jSIMA('#txtNdiasDescanso').on('change keyup paste',function(e){
																		if(jNet.get('txtNdiasDescanso').value.length>0){
																			CalcularFechaFin(2,'pCalFecha');
																		}
																		else{
																			jNet.get('ptxtFechaVence').value='';
																		}
																	}
			);
			
			
			
				
			oParamCollecionBusqueda = new ParamCollecionBusqueda();
			oParamBusqueda = new ParamBusqueda();
			oParamBusqueda.Nombre='NroPersonal';
			oParamBusqueda.Texto='Porta Retrato';
			oParamBusqueda.LongitudEjecucion=1;
			oParamBusqueda.Tipo='C';
			oParamBusqueda.CampoAlterno = 'Nombres';
			oParamBusqueda.LongitudEjecucion=4;
			oParamCollecionBusqueda.Agregar(oParamBusqueda);

			oParamBusqueda = new ParamBusqueda();
			oParamBusqueda.Nombre='idProceso';
			oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarPersonalv2;
			oParamBusqueda.Tipo='Q';
			oParamCollecionBusqueda.Agregar(oParamBusqueda);
			
			oParamBusqueda = new ParamBusqueda();
			oParamBusqueda.Nombre='FieldFind';
			oParamBusqueda.Valor="NROPERSONAL";
			oParamBusqueda.Tipo='Q';
			oParamCollecionBusqueda.Agregar(oParamBusqueda);

			(new AutoBusqueda("txtPR")).Crear('/' + ApplicationPath + '/GestionFinanciera/Procesar.aspx?',oParamCollecionBusqueda);
	
			jNet.get('cellOculta').style.display="none";
				
			
			</script>
		</form>
		<SCRIPT>
			function CalcularFechaFin(Param,objFecha){
				if(jNet.get(objFecha).value.length>0){
					var strNomFecha2 = ((Param==2)?'ptxtFechaVence':'txtFechaVence');
					var strNomTxtDia = ((Param==2)?'txtNdiasDescanso':'txtDiasDescanso');
					jNet.get(strNomFecha2).value= (new Controladora.SeguridadIndustrial.CCCTT_ExamenMedico()).CalcularVencimientoPorRango(jNet.get(objFecha).value,jNet.get(strNomTxtDia).value);
				}
			}
			
			
			var IdFila= jNet.get('hIdFila').value;
			if(IdFila!=0){
				var ogrid = jNet.get('grid');
				CambiarColorSeleccion(ogrid.children[0].rows[IdFila-1]);
			}		
		</SCRIPT>
	</body>
</HTML>
