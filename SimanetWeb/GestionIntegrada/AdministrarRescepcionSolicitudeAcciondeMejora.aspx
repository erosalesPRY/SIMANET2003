<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarRescepcionSolicitudeAcciondeMejora.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.AdministrarRescepcionSolicitudeAcciondeMejora" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarRescepcionSolicitudeAcciondeMejora</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js"></script>
		<script>
			function AbrirVentanaCausaRaiz(IdCausRaiz,IdUsuarioEmite,Modo){
				var URL='/' + ApplicationPath +'/GestionIntegrada/DetalleCausaRaiz.aspx?' 
				+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDCAUSARAIZ +  SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdCausRaiz
				+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
				+ SIMA.Utilitario.Constantes.KEYMODOPAGINA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + Modo
				+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
				+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDUSUARIOEMITE + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdUsuarioEmite;
				
				(new System.Ext.UI.WebControls.Windows()).Detalle('CAUSA RAIZ',URL,this,560,180,wind_ibtn_Aceptar);
			}

			
			function wind_ibtn_Aceptar(wMindefault){
				var oSAMCausaRaizBE= new EntidadesNegocio.OGI.SAMCausaRaizBE();
				oSAMCausaRaizBE.IdCausaRaiz = Ext.get('hIdCausaRaiz').dom.value;
				oSAMCausaRaizBE.IdDestino = Ext.get('hIdDestino').dom.value;
				oSAMCausaRaizBE.Descripcion = Ext.get('txtDescripcion').dom.value;
				//oSAMCausaRaizBE.FechaEmision = Ext.get('calFecha').dom.value;			
			
				var dtCausaRaiz =(new Controladora.OGI.CSAMCausaRaiz()).Insertar(oSAMCausaRaizBE);
				//var drResult = dtCausaRaiz.Rows.Items[0];
				//orow.attr("IDCAUSARAIZ",drResult.Item('Resultado'));
				wMindefault.close();
				
				document.location.reload();				
			}
			
			function Eliminar(e,IdCausaRaiz){
				//if(jNet.get('hIdEstado').value=="2"){Ext.MessageBox.alert('SAM', 'No es posible eliminar este registro por que la Solicitud e Accion de Mejora se encuentra cerrada', function(btn){});return false;}
				var otblItem = jNet.get(e.parentNode.parentNode.parentNode.parentNode);
				var oDataGrid = otblItem.parentNode;
				Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro ahora?', function(btn){
					if(btn=="yes"){
						(new Controladora.OGI.CSAMCausaRaiz()).Eliminar(IdCausaRaiz);
						oDataGrid.removeChild(otblItem);
					}
				});					
			}
			
			function SeleccionCorreo(){
				var URL='/' + ApplicationPath +'/GestionIntegrada/AdministrarCorreoDeConocimientoDeAccion.aspx?'
				+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDSAM + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + jNet.get('hIdSAM').value
				+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
				+ SIMA.Utilitario.Constantes.GestionPersonal.KEYQIDAREA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + jNet.get('hIdArea').value; 
				(new System.Ext.UI.WebControls.Windows()).Detalle('Seleccionar Responsables',URL,this,700,500,wind_ibtn_Envio);
			}
		
			function wind_ibtn_Envio(wMindefault){
				var LstTrama = "";
				var oGridLst = jNet.get('gridLst');
				for(var i=1;i<=oGridLst.rows.length-1;i++){
					var oChk =  oGridLst.rows[i].cells[0].children[0];
					if(oChk.checked){
						var orow = jNet.get(oGridLst.rows[i]);
						var txtMsg = orow.cells[2].children[0].value;
						LstTrama +=orow.attr("IDPERSONAL") + "*" + orow.attr("EMAIL") + "*" + txtMsg + "@"
					}
				}
				
			
				
				wMindefault.close();
			}
			
			
				
			function AgregarAcciones(){
				var rowIndex = jNet.get('hIdRow').value;
				
				if(rowIndex!='0'){
					var oDataGrid = jNet.get('grid');
					var cellContext = jNet.get('tblCausaRaiz').rows[1].cells[0];
					cellContext.Remover=function(){
						var NroElement =this.children.length-1;
						for(var i=0;i<=NroElement;i++){
							var elementEL = this.children[0];
							this.removeChild(elementEL);
						}
					}
					cellContext.Remover();
					
					var ctrlLst = oDataGrid.rows[rowIndex].cells[7].children;

					for(var c=0;c<=ctrlLst.length-1;c++){
						var oCellAct = jNet.get(ctrlLst[c]);
						if((oCellAct.attr("IDESTADO")!='2')
							&&(oCellAct.attr("CONACCION")=='0')){
								var ctrlClon = jNet.get(oCellAct.cloneNode(true));
								ctrlClon.style.width="100%";
								var btn = ctrlClon.rows[0].cells[2].children[0];
								ctrlClon.rows[0].cells[2].removeChild(btn);
								//Agrega el control check
								var chk = jNet.get(document.createElement("input"));
								chk.attr('type', 'checkbox');
								jNet.get(ctrlClon.rows[0].cells[2]).insert(chk);
								//chk.checked = true;
								cellContext.appendChild(ctrlClon);
						}
						
					}
					
					//Ext.MessageBox.alert('SAM', 'Seleccionar un registro de Solicitud de Accion de Mejora', function(btn){});	
					
					(new System.Ext.UI.WebControls.Windows()).DetalleFromEL('MiVentana','tblCausaRaiz','Seleccionar la(s) causa raiz',315,510,winDet_ibtn_Aceptar);
				}
				else{
					Ext.MessageBox.alert('SAM', 'Seleccionar un registro de Solicitud de Accion de Mejora', function(btn){});	
				}
				
			}
			
			
			var URLACCIONES = '/' + ApplicationPath + "/GestionIntegrada/AdministrarAccionesCP.aspx?";
			var KEYQLSTCR = "LstCR";
			function winDet_ibtn_Aceptar(HandlerWind){
				var cellContext = jNet.get('tblCausaRaiz').rows[1].cells[0];
				cellContext.ObtenerCausaRaiz=function(){
					var LstIds = "";
					for(var c=0;c<=this.children.length-1;c++){
						var ctrl = jNet.get(this.children[c]);
						var chk = ctrl.rows[0].cells[2].children[0];
						if(chk.checked==true){
							LstIds += ctrl.attr("IDCAUSARAIZ") + "@";
						}
					}
					return ((LstIds.length==0)?"":LstIds.substring(0,LstIds.length-1));
				}
		
				Redireccionar("0","1",cellContext.ObtenerCausaRaiz(),SIMA.Utilitario.Enumerados.ModoPagina.N);
				
				HandlerWind.hide();
			}
			
			
			
			function Redireccionar(IdGRPCausRaiz,IdEstadoGRPCausRaiz,lstCausaRaiz,Modo){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				HistorialIrAdelantePersonalizado("ddlNorma;hIdRow;hGridPaginaSort;hGridPagina;hIdSAM;hIdDestino");
				var PATHURL = URLACCIONES + SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDSAM + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + jNet.get('hIdSAM').value 
											+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
											+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDDESTINO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + jNet.get('hIdDestino').value
											+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
											+ SIMA.Utilitario.Constantes.KEYMODOPAGINA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + Modo
											+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
											+ KEYQLSTCR + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + lstCausaRaiz
											+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
											+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIGRUPOCRA +  SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdGRPCausRaiz
											+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
											+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDESTDOGRPCR +  SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdEstadoGRPCausRaiz
											+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
											+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDUSUARIOEMITE + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + jNet.get('hidUsuarioEmite').value
											+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
											+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDACCIONINMEDIATA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + jNet.get('hIdAccionInmediata').value;

				oPagina.Response.Redirect(PATHURL);
			}


			function ModificarACCSAM(e){
				if(e.getAttribute("OLD")!=e.value){
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var oSolicitudAccionMejoraBE= new EntidadesNegocio.OGI.SolicitudAccionMejoraBE();
					//oSolicitudAccionMejoraBE.IdDestino = oPagina.Request.Params[SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDDESTINO];
					oSolicitudAccionMejoraBE.IdDestino = e.getAttribute("IDDESTINO");
					oSolicitudAccionMejoraBE.AccionInmediata=e.value;
					(new Controladora.OGI.CSolicitudAccionMejora()).Modificar(oSolicitudAccionMejoraBE);
					e.setAttribute("OLD",e.value);
				 }
			}


		function EnviarEmailRpt(IdSAM,IdDestino){
			Ext.MessageBox.confirm('Confirmar', 'Desea ud. ahora enviar correo de confirmación de respuesta para esta SAM?', function(btn){
						if(btn=="yes"){
							document.getElementById('hIdSAM').value =IdSAM;
							document.getElementById('hIdDestino').value =IdDestino;
							__doPostBack('btnEnviarRptSAM',IdSAM+';'+IdDestino);
						}
					});			
		
		}
		
			function VerDetalleHallazgo(e,strIdSAM){
				var KEYQIDSAM = "IdSAM";
				var URLPAGINABITACORA = "/" + ApplicationPath + "/GestionIntegrada/ConsultarHallazgo.aspx?";
				(new System.Ext.UI.WebControls.Windows()).Dialogo('HALLAZGO',URLPAGINABITACORA + KEYQIDSAM + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + strIdSAM,e,600,345);
			}
			
			function Anexar(){
			var URLPAGINABITACORA = "/" + ApplicationPath + "/GestionIntegrada/CosultaySeguimientodeSolicituddeAcciondeMejora.aspx?";
				//URLPAGINABITACORA = "http://spesrvtest4/MOSS_DatosPersonal/CumpleaniosTodos.aspx";
				alert(URLPAGINABITACORA);
				
				jQuery.ajax({
							url: URLPAGINABITACORA,
							type: 'post',
							data: 'dATA1=1&DATA2=2',
							success: function(results){
								alert(results);
								//$('#context').html(results);
							}
						});

			}
			
			
			function ListarResponsable(IdSam){
				var URLRESPONSABLE = '/' + ApplicationPath + "/GestionIntegrada/ListarResponsableSAMs.aspx?";
				var URL = URLRESPONSABLE;
				(new System.Ext.UI.WebControls.Windows()).Dialogo('Listado de responsable por area',URL,this,800,600,CerrarDialogo);
			}
			
			function CerrarDialogo(hdw){
				hdw.close();
			}
			
		</script>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" onunload="SubirHistorial();"
		onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td style="HEIGHT: 23px" bgColor="#eff7fa" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 22px" class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Integrada></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Administrar Recepción de Solicitud de Acción de Mejora</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center" style="HEIGHT: 16px"></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR bgColor="#f0f0f0">
								<TD>
									<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton></TD>
											<TD><IMG style="Z-INDEX: 0" id="ibtnFiltrarSeleccion" title="NroCDI" onclick="FiltroporSeleccion(1);"
													alt="Aplicar Filtro por Selección" src="../imagenes/filtroporseleccion.jpg"></TD>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminaFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD noWrap>
												<asp:Label id="Label5" runat="server" Font-Size="10pt" Font-Bold="True">Por Norma:</asp:Label></TD>
											<TD width="100%">
												<asp:DropDownList id="ddlNorma" runat="server" CssClass="normaldetalle" AutoPostBack="True"></asp:DropDownList></TD>
											<TD width="100%">
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
											<TD><IMG style="Z-INDEX: 0" id="btnCausaRaizAcciones" onclick="AgregarAcciones();" alt=""
													src="../imagenes/btnCorrectivoPreventivo.gif"></TD>
											<TD><IMG style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 5px" alt="" src="/SIMANETWEB/imagenes/spacer.gif"
													width="16" height="5"></TD>
											<TD><IMG style="Z-INDEX: 0" id="ibtnAgregarCausaRaiz" onclick="AbrirVentanaCausaRaiz(jNet.get('hIdDestino').value,jNet.get('hidUsuarioEmite').value,'N');"
													alt="" src="../imagenes/Filtro/ibtnAgregarCausaRaiz.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="100%" ShowFooter="True" PageSize="7"
										RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle Height="30px" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CodigoSAM" SortExpression="CodigoSAM" HeaderText="CODIGO">
												<HeaderStyle Width="2%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FechaEmision" SortExpression="FechaEmision" HeaderText="FECHA EMIS.">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="EMITE/RECIBE">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
												<ItemTemplate>
													<TABLE style="Z-INDEX: 0" id="tblER" border="0" cellSpacing="0" cellPadding="0" width="100%"
														runat="server">
														<TR>
															<TD class="headerDetalle">
																<asp:Label id="Label4" runat="server" CssClass="headerDetalle">DE:</asp:Label></TD>
															<TD class="ItemText" width="100%" noWrap>
																<asp:label style="Z-INDEX: 0" id="lblEmite" runat="server" CssClass="ItemText" BorderStyle="None">EMISOR:</asp:label></TD>
														</TR>
														<TR>
															<TD class="headerDetalle" colSpan="2">
																<asp:label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="headerDetalle" BorderStyle="None">PARA:</asp:label></TD>
														</TR>
														<TR>
															<TD colSpan="2" noWrap></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn HeaderText="NORMA">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="HALLAZGO">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="ACCION INMEDIATA">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemTemplate>
													<asp:TextBox style="Z-INDEX: 0" id="txtAccionInmediata" runat="server" CssClass="normaldetalle2"
														Width="100%" Height="100%" TextMode="MultiLine" BorderStyle="None"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="CAUSA RAIZ">
												<HeaderStyle Wrap="False"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Enviar&lt;br&gt;rpt">
												<ItemTemplate>
													<TABLE style="Z-INDEX: 0" id="Table4" border="0" cellSpacing="1" cellPadding="1">
														<TR>
															<TD>
																<TABLE style="Z-INDEX: 0" id="tblEnviado" border="0" cellSpacing="1" cellPadding="1" align="left"
																	runat="server">
																	<TR>
																		<TD>
																			<asp:Image style="Z-INDEX: 0" id="Image1" runat="server" ImageUrl="../imagenes/Navegador/CorreoSend2.png"
																				ToolTip="Nro de correo(s) enviado(s) para conocimiento."></asp:Image></TD>
																		<TD>
																			<asp:Label style="Z-INDEX: 0" id="LblEnviado" runat="server" CssClass="ItemGrillaText">(0)</asp:Label></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD>
																<asp:Image style="Z-INDEX: 0" id="btnEnviar" runat="server" ImageUrl="..//imagenes/Navegador/btnEnviar.png"
																	ToolTip="Enviar correo para conocimiento a OGI" Width="40px" Height="40px"></asp:Image></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
						<div id="myContent" class="x-hidden">
							<TABLE id="tblCausaRaiz" border="0" cellSpacing="1" cellPadding="1" width="300">
								<TR>
									<TD style="HEIGHT: 21px" bgColor="navy"><asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco">Seleccionar la(s) Causa Raiz</asp:label></TD>
								</TR>
								<TR>
									<TD bgColor="gainsboro"></TD>
								</TR>
							</TABLE>
						</div>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%" align="center">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hIdRow" value="0" size="1" type="hidden"
										name="hidCentro" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hGridPaginaSort" size="1" type="hidden"
										name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hGridPagina" value="0" size="1"
										type="hidden" name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 22px" id="hIdSAM" size="1" type="hidden"
										name="hCodigo" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hIdDestino" size="1" type="hidden"
										runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hidUsuarioEmite" size="1" type="hidden"
										name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hIdAccionInmediata" size="1" type="hidden"
										name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hIdArea" size="1" type="hidden"
										name="Hidden1" runat="server">
									<asp:Button id="btnEnviarRptSAM" runat="server" Text="Button"></asp:Button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
