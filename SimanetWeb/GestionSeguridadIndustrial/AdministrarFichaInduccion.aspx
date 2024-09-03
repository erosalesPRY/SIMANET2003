<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="AdministrarFichaInduccion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarFichaInduccion" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarFichaInduccion</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Menu/MenuSP.js"></script>
		<script type="text/javascript" src="../js/RegEXT.js"></script>
		<script>
			function txtNroDNI_ItemDataBound(sender,e,dr){
				//Verificar antecedentes
				FindAntecedentes(dr);
			}
			
			function FindAntecedentes(dr){
					var oCCTT_TrabajadorBE=new EntidadesNegocio.Personal.CCTT_TrabajadorBE();
						oCCTT_TrabajadorBE = (new AccesoDatos.NoTransacional.Personal.CCCTT_Trabajadores()).Antecedentes(dr['NroDNI']);
						if((oCCTT_TrabajadorBE!=null)&&(oCCTT_TrabajadorBE.Antecedente=='0')){
							
							var srtHTML = "<TABLE border='0'  style='WIDTH: 480px; HEIGHT: 175px'>"
										+ "		<TR><TD width='100%' align='center'><IMG style='Z-INDEX: 0; WIDTH: 87px' align='middle' src='http://simanet/SIMANETCOMPLEMENTOS/Seguridad/ImgFinal/" + oCCTT_TrabajadorBE.NroDNI + ".jpg' width='87' height='200'></TD></TR>"
										+ "		<TR><TD style='FONT-SIZE: 20pt; FONT-WEIGHT: bold' align='center'>" + oCCTT_TrabajadorBE.ApellidosyNombres + "</TD></TR>"
										+ "		<TR><TD style='PADDING-LEFT: 5px; HEIGHT: 20px; FONT-SIZE: 10pt; BORDER-TOP: #808080 1px dotted' align='center'>No esta permitido el ingreso por infracciones comentidas a la institución</TD></TR>"
										+ "</TABLE>";

							Ext.MessageBox.confirm('Confirmar', srtHTML, function(btn){
											if(btn=="yes"){
													jNet.get('txtApellidosyNombres').value=dr["ApellidosNombres"];
													var oDataTable = (new AccesoDatos.NoTransacional.Personal.CCCTT_Trabajadores()).ListarDatosRelacionados(dr['NroDNI']);
													
													oDataTable.forEach(function(oDataRow){
																					if(oDataRow.Item("EOF")==false){
																						jNet.get('txtNroRUC').value=oDataRow.Item("NroRuc").toString();
																						jNet.get('txtRazonSocial').value=oDataRow.Item("RazonSocial").toString();
																						jNet.get('hPeriodoProg').value=oDataRow.Item("Periodo").toString();
																						jNet.get('hNroProg').value=oDataRow.Item("NroProgramacion").toString();

																					}
																				});
																				
													__doPostBack('btnFiltar','');											
												
											}
										});		
						}
						else{
									jNet.get('txtApellidosyNombres').value=dr["ApellidosNombres"];
									var oDataTable = (new AccesoDatos.NoTransacional.Personal.CCCTT_Trabajadores()).ListarDatosRelacionados(dr['NroDNI']);
													
													oDataTable.forEach(function(oDataRow){
																					if(oDataRow.Item("EOF")==false){
																						jNet.get('txtNroRUC').value=oDataRow.Item("NroRuc").toString();
																						jNet.get('txtRazonSocial').value=oDataRow.Item("RazonSocial").toString();
																						jNet.get('hPeriodoProg').value=oDataRow.Item("Periodo").toString();
																						jNet.get('hNroProg').value=oDataRow.Item("NroProgramacion").toString();

																					}
																				});
																				
													__doPostBack('btnFiltar','');										
						
						}		
			}
			
			
						
			function CalcularFechaVence(Fecha,Source){
				jNet.get('txtFechaVence').value= (new Controladora.SeguridadIndustrial.CCCTT_ExamenMedico()).CalcularVencimiento(Fecha);
			}
			
			function AceptaModifica(oWind){
				var strParam =	jNet.get("hPeriodo").value +';'+
								jNet.get("hIdEvaluacion").value +';'+
								jNet.get("ptxtNroDNI").value +';'+
								jNet.get("ptxtNota").value  +';'+
								jNet.get('pCalFecha').value +';'+
								jNet.get('ptxtFechaVence').value +';'+
								jNet.get('ptxtNroRegistro').value;
								
				__doPostBack('btnModifica',strParam );
				oWind.hide();
			}			
			
			function DetalleFicha(NroDNI,ApellidosyNombres,Nota,FechaInicio,FechaVencimiento,NroRegistro){
				PopupDeEsperaClose();
				jNet.get("ptxtNroRegistro").value = NroRegistro;
				jNet.get("ptxtNroDNI").value = NroDNI;
				jNet.get("ptxtApellidosyNombres").value = ApellidosyNombres;
				jNet.get("ptxtNota").value= Nota;
				jNet.get("pCalFecha").value= FechaInicio;
				jNet.get("ptxtFechaVence").value=FechaVencimiento;
				
				window.setTimeout((new System.Ext.UI.WebControls.Windows()).DetalleFromEL('MiVentana','tblDetalle','Detalle',605,220,AceptaModifica),3000);
							
			}	
			
			function EliminarFicha(Periodo,IdEvaluacion,NroDNI){
				Ext.MessageBox.confirm('ELIMINAR', 'Desea Ud. Hacer efectiva la eliminación de este registro ahora?', function(btn){
					if(btn=="yes"){
						__doPostBack('ibtnEliminar',Periodo+';'+IdEvaluacion +';'+ NroDNI );
					}
				});
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
					<TD class="commands"><asp:label style="Z-INDEX: 0" id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de seguridad>Administración</asp:label><asp:label style="Z-INDEX: 0" id="lblPagina" runat="server" CssClass="RutaPaginaActual">>Ficha de Inducción></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left">
						<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="300" align="center">
							<TR>
								<TD align="center"><asp:label style="Z-INDEX: 0" id="Label4" runat="server">ADMINISTRAR FICHA DE INDUCCION</asp:label></TD>
							</TR>
							<TR>
								<TD align="left">
									<TABLE id="Table5" border="0" cellSpacing="1" cellPadding="1" width="300" align="left">
										<TR>
											<TD class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label13" runat="server">NRO REG:</asp:label></TD>
											<TD><asp:textbox id="txtNroRegistro" runat="server" Width="210px"></asp:textbox></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%">
										<TR>
											<TD class="HeaderGrilla" rowSpan="2" noWrap><asp:label style="Z-INDEX: 0" id="Label1" runat="server">NRO DOC:</asp:label></TD>
											<TD style="WIDTH: 161px" vAlign="middle" rowSpan="2" align="left"><asp:textbox style="Z-INDEX: 0" id="txtNroDNI" runat="server" CssClass="normaldetalle" Width="103px"></asp:textbox></TD>
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
											<TD class="HeaderGrilla" rowSpan="2"><asp:label style="Z-INDEX: 0" id="Label3" runat="server">NOTA:</asp:label></TD>
											<TD rowSpan="2"><asp:textbox id="txtNota" runat="server"></asp:textbox></TD>
											<TD class="HeaderGrilla" colSpan="4" align="center"><asp:label style="Z-INDEX: 0" id="Label7" runat="server">FECHA:</asp:label></TD>
											<TD rowSpan="2"><asp:imagebutton style="Z-INDEX: 0" id="imgAgregar" runat="server" Width="42px" ImageUrl="../imagenes/Navegador/Plus.png"
													Height="39px"></asp:imagebutton></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label5" runat="server"> INICIO:</asp:label></TD>
											<TD noWrap><asp:textbox id="txtFechaIni" runat="server" CssClass="normaldetalle" Width="96px" rel="calendar"></asp:textbox></TD>
											<TD class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label6" runat="server">VENCIMIENTO:</asp:label></TD>
											<TD><asp:textbox id="txtFechaVence" runat="server" CssClass="normaldetalle" Width="80px" ReadOnly="True"></asp:textbox></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderGrilla" colSpan="12">
												<asp:label style="Z-INDEX: 0" id="Label15" runat="server">EMPRESA RELACIONADA:</asp:label></TD>
										</TR>
										<TR>
											<TD class="HeaderGrilla">
												<asp:label style="Z-INDEX: 0" id="Label16" runat="server">NRO RUC:</asp:label></TD>
											<TD colSpan="2" noWrap>
												<asp:textbox style="Z-INDEX: 0" id="txtNroRUC" runat="server" Width="100%" CssClass="normaldetalle"
													BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></TD>
											<TD noWrap></TD>
											<TD class="HeaderGrilla" noWrap>
												<asp:label style="Z-INDEX: 0" id="Label17" runat="server">RAZÓN SOCIAL:</asp:label></TD>
											<TD colSpan="6" noWrap><asp:textbox style="Z-INDEX: 0" id="txtRazonSocial" runat="server" Width="100%" CssClass="normaldetalle"
													BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></TD>
											<TD noWrap></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center"><INPUT id="hIdFila" value="0" type="hidden" name="hIdFila" runat="server"><INPUT style="WIDTH: 57px; HEIGHT: 22px" id="hGridPaginaSort" size="4" type="hidden" name="hGridPaginaSort"
										runat="server"><INPUT style="WIDTH: 50px; HEIGHT: 22px" id="hGridPagina" value="0" size="3" type="hidden"
										name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hPeriodo" size="1" type="hidden"
										runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hIdEvaluacion" value="0" size="1"
										type="hidden" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hPeriodoProg" value="0" size="1"
										type="hidden" name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hNroProg" value="0" size="1" type="hidden"
										name="Hidden1" runat="server"></TD>
							</TR>
							<TR>
								<TD align="left"><asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminaFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
										ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="100%" Height="1px" ShowFooter="True"
										AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" AutoGenerateColumns="False"
										PageSize="12" AllowSorting="True">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle Height="25px" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroDNI" SortExpression="NroDNI" HeaderText="NRO DOC">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ApellidosyNombres" HeaderText="APELLIDOS Y NOMBRES">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroRuc" HeaderText="NRO RUC">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RazonSocial" HeaderText="RAZON SOCIAL">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Nota" HeaderText="NOTA">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Aprobado" HeaderText="APROBADO"></asp:BoundColumn>
											<asp:BoundColumn DataField="FechaInicio" HeaderText="FECHA INICIO">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
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
								<TD style="DISPLAY: block; HEIGHT: 124px" id="cellOculta">
									<TABLE id="tblDetalle" border="0" cellSpacing="1" cellPadding="1" width="300">
										<TR>
											<TD class="HeaderGrilla" noWrap><asp:label style="Z-INDEX: 0" id="Label14" runat="server">NRO REG:</asp:label></TD>
											<TD><asp:textbox style="Z-INDEX: 0" id="ptxtNroRegistro" runat="server" CssClass="normaldetalle"
													Width="103px"></asp:textbox></TD>
											<TD colSpan="2" noWrap></TD>
											<TD colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="HeaderGrilla" noWrap><asp:label style="Z-INDEX: 0" id="Label8" runat="server">NRO DOC:</asp:label></TD>
											<TD><asp:textbox style="Z-INDEX: 0" id="ptxtNroDNI" runat="server" CssClass="normaldetalle" Width="103px"
													ReadOnly="True"></asp:textbox></TD>
											<TD class="HeaderGrilla" colSpan="2" noWrap><asp:label style="Z-INDEX: 0" id="Label9" runat="server">APELLIDOS Y NOMBRES:</asp:label></TD>
											<TD colSpan="2"><asp:textbox style="Z-INDEX: 0" id="ptxtApellidosyNombres" runat="server" CssClass="normaldetalle"
													Width="300px" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label10" runat="server">NOTA:</asp:label></TD>
											<TD><asp:textbox id="ptxtNota" runat="server" Width="103px"></asp:textbox></TD>
											<TD class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label11" runat="server"> INICIO:</asp:label></TD>
											<TD width="150"><asp:textbox id="pCalFecha" runat="server" CssClass="normaldetalle" Width="100px" rel="calendar"></asp:textbox></TD>
											<TD class="HeaderGrilla" align="left"><asp:label style="Z-INDEX: 0" id="Label12" runat="server">VENCIMIENTO:</asp:label></TD>
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
			
			
				var oParamCollecionBusqueda = new ParamCollecionBusqueda();
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
			
				jNet.get('cellOculta').style.display="none";
				
			
			</script>
		</form>
		<SCRIPT>
		
		
			function CalcularFechaFin(Param,objFecha){
				var strNomFecha2 = ((Param==2)?'ptxtFechaVence':'txtFechaVence');
				jNet.get(strNomFecha2).value= (new Controladora.SeguridadIndustrial.CCCTT_ExamenMedico()).CalcularVencimiento(jNet.get(objFecha).value);
			}
			
			var IdFila= jNet.get('hIdFila').value;
			if(IdFila!=0){
				var ogrid = jNet.get('grid');
				CambiarColorSeleccion(ogrid.children[0].rows[IdFila-1]);
			}		
					
			
		</SCRIPT>
	</body>
</HTML>
