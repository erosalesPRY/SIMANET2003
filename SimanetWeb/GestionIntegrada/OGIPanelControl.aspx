<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="OGIPanelControl.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.OGIPanelControl" %>
<HTML>
	<HEAD>
		<title>Control Consulta y Seguimiento</title>
		<META content="text/html; charset=utf-8" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
			<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
			<script type="text/javascript" src="../js/RegEXT.js"></script>
			<!--<script type="text/javascript" src="../../js/RegEXT.js"></script>-->
			<style>.round { WIDTH: 30px; HEIGHT: 40px; OVERFLOW: hidden; border-radius: 50% }
	.round IMG { MIN-WIDTH: 100%; MIN-HEIGHT: 100%; DISPLAY: block }
	</style>
			<script>
			function ControldeAcciones(e,IdSAM,IdUsuarioEmite,IdDestino){
				HistorialIrAdelantePersonalizado("ddlDestino;ddlNorma;hGridPaginaSort;hGridPagina");
				var URLPAGINACONTROL = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionIntegrada/AdministrarControldeAccionesPorCausaRaiz.aspx?";
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					oPagina.Response.Redirect(URLPAGINACONTROL + SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDSAM  + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + IdSAM
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString() 
																+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDDESTINO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + IdDestino
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString() 
																+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQDESCRIPCION + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + jNet.get(e).attr("DESCRIPCION")
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString() 
																+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDUSUARIOEMITE + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdUsuarioEmite
															);
			}
			
			function grid_onClick(e){
			
			}
			
			function EliminarSAM(e,IdSAM){
				var oDataGrid = e.parentNode;
				Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro ahora?', function(btn){
					if(btn=="yes"){
						(new Controladora.OGI.CSolicitudAccionMejora()).Eliminar(IdSAM);
						oDataGrid.removeChild(e);
					}
				});
			}
			

			function EliminarDestinatario(e,IdDestino){
				var tblItem = e.parentNode.parentNode.parentNode.parentNode;
				var CellContext = tblItem.parentNode;
				Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro destinatario ahora?', function(btn){
									if(btn=="yes"){
										(new Controladora.OGI.CSAMDestino()).Eliminar(IdDestino);
										CellContext.removeChild(tblItem);
									}
								});					
			}			
			
			function VerDetalleHallazgo(e,strIdSAM){
				var KEYQIDSAM = "IdSAM";
				
				var URLPAGINABITACORA = "/" + ApplicationPath + "/GestionIntegrada/ConsultarHallazgo.aspx?";
				(new System.Ext.UI.WebControls.Windows()).Dialogo('HALLAZGO',URLPAGINABITACORA + KEYQIDSAM + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + strIdSAM,e,600,345);
			}
			
			function ListarDetalle(IdTipoNorma,IdTipoAuditoria,Periodo,Tipo,Autorizado){
				var KEYQPERIODO = "Periodo";
				var KEYQTIPONOR ="IDTIPONOR";
				var KEYTIPOAUD  ="IDTIPOAUD";
				var KEYTIPO  ="IDTIPO";
				
				var URLPAGINA= "/" + ApplicationPath + "/GestionIntegrada/CosultaySeguimientodeSolicituddeAcciondeMejora.aspx?"
								+ KEYQTIPONOR + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + IdTipoNorma
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString() 
								+ KEYTIPOAUD + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + IdTipoAuditoria
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString() 
								+ "PERIODO" + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + Periodo
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString() 
								+ KEYTIPO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + Tipo;
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString() 
								+ "AUTORIZA" + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + Autorizado
					
				HistorialIrAdelantePersonalizado("");
				
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					oPagina.Response.Redirect(URLPAGINA);
			}
			
			
			
			function Progresso(){
						Ext.MessageBox.show({msg: 'Procesando Historico de SAM, please wait...'
																					,progressText: 'Procesando información...'
																					,width:300
																					,wait:true
																					,waitConfig: {interval:100}
																					,animateTarget: 'waitButton'
																				});
																				
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
					<td bgColor="#eff7fa" height="23" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" height="22" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Integrada>AdministraciOn></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Tablero resumen registro SAM.</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center"></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR bgColor="#f0f0f0">
								<TD>
									<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD width="100%">
												<TABLE id="Table4" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
													<TR>
														<TD width="69"></TD>
														<TD></TD>
														<TD></TD>
														<TD width="100%" align="center"></TD>
														<TD></TD>
														<TD></TD>
													</TR>
												</TABLE>
											</TD>
											<TD width="100%"></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE style="Z-INDEX: 0" id="Table5" border="0" cellSpacing="1" cellPadding="1" width="689">
										<tr>
											<td>
												<table style="Z-INDEX: 0" id="Table55" border="0" cellSpacing="1" cellPadding="1" width="100%">
													<tr>
														<TD colSpan="6" align="right"><asp:button id="ibtnMostrar" runat="server" Height="16px" Width="12px" Text="Mostrar" Visible="False"></asp:button></TD>
													</tr>
													<TR class="ItemDetalle">
														<TD class="HeaderDetalle" width="15%"><asp:label id="Label5" runat="server">Año:</asp:label></TD>
														<TD height="1" width="25%"><asp:dropdownlist id="ddlAmo" runat="server" CssClass="normaldetalle" AutoPostBack="True" Height="23px"
																Width="176px"></asp:dropdownlist></TD>
														<TD height="1" width="1%"></TD>
														<TD class="HeaderDetalle" width="15%"><asp:label id="Label6" runat="server">Mes:</asp:label></TD>
														<TD height="1" width="25%"><asp:dropdownlist id="ddlmes" runat="server" CssClass="normaldetalle" Height="23px" Width="176px"
																onchange="MostrarDatos()"></asp:dropdownlist></TD>
														<TD height="1" width="13%">
															<P align="center"><IMG style="Z-INDEX: 0" id="ibtnAtras2" onclick="VerEstadisticas();" alt="" src="../imagenes/btnHistorico.jpg"><IMG style="Z-INDEX: 0; HEIGHT: 0px; VISIBILITY: hidden" src="../imagenes/spacer.gif"
																	width="100%" height="8"></P>
														</TD>
													</TR>
												</table>
											</td>
										</tr>
										<TR>
											<TD bgColor="#000080" height="30"><asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco">RESUMEN POR NORMA, TIPO DE AUDITORIA Y AÑO</asp:label></TD>
										</TR>
										<TR>
											<TD><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="100%" RowHighlightColor="#E0E0E0"
													AutoGenerateColumns="False">
													<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
													<ItemStyle Height="30px" CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="CONCEPTO" HeaderText="NORMA">
															<HeaderStyle HorizontalAlign="Center" Width="40%" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Superado" HeaderText="SUPERADO.">
															<HeaderStyle Width="2%" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Contestado" HeaderText="CONTESTADO"></asp:BoundColumn>
														<asp:BoundColumn DataField="NoContestado" HeaderText="NO CONTESTADO.">
															<HeaderStyle Width="1%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Left" VerticalAlign="Top"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="EnVerificacion" HeaderText="EN VERIFICACION"></asp:BoundColumn>
														<asp:BoundColumn DataField="Total" HeaderText="TOTAL">
															<HeaderStyle Width="1%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="RESPONSABLE">
															<HeaderStyle Width="100%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR>
											<TD height="12" vAlign="top" width="100%" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
										</TR>
										<TR>
											<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>			
		</SCRIPT>
		<script>	
				function VerEstadisticas(){	
				var URLDETALLEAREA = "/" + ApplicationPath + "/GestionIntegrada/ConsultarEstadisticasOGIPanelControl.aspx?OPNombre=Historia de registros de  SAM´s&flgDesa=&HISTORIALINI=Inicializar";						
				(new SIMA.Utilitario.Helper.Response()).ShowDialogoNoModal(URLDETALLEAREA,800,650,this);
				}
				function MostrarDatos(){
					__doPostBack('ibtnMostrar','');
				}
		</script>
	</body>
</HTML>
