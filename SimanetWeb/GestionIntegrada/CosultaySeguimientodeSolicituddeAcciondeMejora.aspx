<%@ Page language="c#" Codebehind="CosultaySeguimientodeSolicituddeAcciondeMejora.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.CosultaySeguimientodeSolicituddeAcciondeMejora" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Control Consulta y Seguimiento</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<style>.msg { BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/CorreoSend2.png); Z-INDEX: 0; POSITION: relative; WIDTH: 20px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 15px }
	.msgTotal { POSITION: absolute; TEXT-ALIGN: center; WIDTH: 18px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 18px; COLOR: navy; FONT-SIZE: 8pt; TOP: -10px; LEFT: 0px }
	.msgNoRead { BACKGROUND-IMAGE: url(/SimanetWeb/js/JQuery/imgs/Circulo.gif); POSITION: absolute; TEXT-ALIGN: center; WIDTH: 18px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 30px; COLOR: red; FONT-SIZE: 10pt; TOP: -10px; FONT-WEIGHT: bold }
		</style>
		<script>
			function ControldeAcciones(e,IdSAM,IdUsuarioEmite,IdDestino,NombreArea,FechaEnvio){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var KEYQAUTORIZA='AUTORIZA';
				var KEYQNOMAREA='NOMAREA';
				var KEYQFECHAENVIA='FENVIA';
				
				HistorialIrAdelantePersonalizado("ddlDestino;ddlNorma;hGridPaginaSort;hGridPagina");
				var URLPAGINACONTROL = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionIntegrada/AdministrarControldeAccionesPorCausaRaiz.aspx?";

				var PARAMETROS= SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDSAM  + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + IdSAM
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString() 
																+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDDESTINO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + IdDestino
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString() 
																+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQDESCRIPCION + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + jNet.get(e).attr("DESCRIPCION")
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString() 
																+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDUSUARIOEMITE + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdUsuarioEmite
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString() 
																+ KEYQNOMAREA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + NombreArea
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString() 
																+ KEYQFECHAENVIA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + FechaEnvio;
														
				//PARAMETROS = PARAMETROS + ((oPagina.Request.Params[KEYQAUTORIZA]!= undefined)? SIMA.Utilitario.Constantes.General.Caracter.signoAmperson + KEYQAUTORIZA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQAUTORIZA]:"");
				
				PARAMETROS = PARAMETROS + SIMA.Utilitario.Constantes.General.Caracter.signoAmperson + KEYQAUTORIZA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + jNet.get('hPrivilegio').value;
				
				
				oPagina.Response.Redirect(URLPAGINACONTROL + PARAMETROS);
			}
			
			function grid_onClick(e,Privilegio){
				jNet.get('hPrivilegio').value=Privilegio;
			}
			
			function EliminarSAM(e,IdSAM,Privilegio){
				jNet.get('hPrivilegio').value=Privilegio;
				
				if(jNet.get('hPrivilegio').value=='0'){Ext.MessageBox.alert('CONTROL DE SAM', 'Ud. no cuenta con autorización de administrar esta información', function(btn){}); return;}
				
				var oDataGrid = e.parentNode;
				Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro ahora?', function(btn){
					if(btn=="yes"){
						(new Controladora.OGI.CSolicitudAccionMejora()).Eliminar(IdSAM);
						oDataGrid.removeChild(e);
					}
				});
			}
			

			function EliminarDestinatario(e,IdDestino){
				if(jNet.get('hPrivilegio').value=='0'){Ext.MessageBox.alert('CONTROL DE SAM', 'Ud. no cuenta con autorización de administrar esta información', function(btn){}); return;}
				
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
			
			
			function CargarNotas(e,CodigoSAM){
				var URLSAMNOTA = '/' + ApplicationPath + "/GestionIntegrada/AdministrarMsgResponsable.aspx?";
				var KEYQIDSAMISO = "IdSamISO";
				var KEYQIDTIPONORMA = "TNorma";
				
				
				var URL = URLSAMNOTA + KEYQIDSAMISO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + e.getAttribute("IDSAMISO")
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQIDTIPONORMA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + e.getAttribute("IDTIPONORMA")
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDSAM + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodigoSAM;
				
				(new SIMA.Utilitario.Helper.Response()).ShowDialogoModal(URL,300,550,this);

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
					<TD style="HEIGHT: 22px" class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Integrada>Administración></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Consulta y Seguimiento Solicitud de Acción de Mejora</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="right" id="ContextReponsable" runat="server"></TD>
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
											<TD></TD>
											<TD width="100%">
												<TABLE id="tblFiltroCombo" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left"
													runat="server">
													<TR>
														<TD style="WIDTH: 69px"><asp:label style="Z-INDEX: 0" id="Label5" runat="server" Font-Bold="True" Font-Size="10pt">DESTINO:</asp:label></TD>
														<TD><asp:dropdownlist style="Z-INDEX: 0" id="ddlDestino" runat="server" CssClass="normaldetalle" AutoPostBack="True"
																Width="300px"></asp:dropdownlist></TD>
														<TD><asp:label style="Z-INDEX: 0" id="Label3" runat="server" Font-Bold="True" Font-Size="10pt">NORMA:</asp:label></TD>
														<TD width="100%"><asp:dropdownlist style="Z-INDEX: 0" id="ddlNorma" runat="server" CssClass="normaldetalle" AutoPostBack="True"
																Width="130px"></asp:dropdownlist><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hPrivilegio" value="0" size="1"
																type="hidden" name="hGridPagina" runat="server"></TD>
														<TD></TD>
														<TD></TD>
													</TR>
												</TABLE>
											</TD>
											<TD width="100%"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hGridPaginaSort" size="1" type="hidden"
													name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hGridPagina" value="0" size="1"
													type="hidden" name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 22px" id="hCodigo" size="1" type="hidden"
													name="hCodigo" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 22px" id="hIdSAM" size="1" type="hidden"
													name="hIdSAM" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 22px" id="hIdDestino" size="1" type="hidden"
													name="hIdDestino" runat="server"></TD>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="100%" AllowPaging="True" AllowSorting="True"
										AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" ShowFooter="True">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CodigoSAM" SortExpression="CodigoSAM" HeaderText="N&#176; de Registro">
												<HeaderStyle Width="2%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FechaEmision" SortExpression="FechaEmision" HeaderText="FECHA EMIS.">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
												<FooterStyle HorizontalAlign="Left" VerticalAlign="Top"></FooterStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="EMISOR / DESTINATARIO">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
												<ItemTemplate>
													<TABLE style="Z-INDEX: 0" id="tblER" border="0" cellSpacing="0" cellPadding="0" width="100%"
														runat="server">
														<TR>
															<TD class="headerDetalle">
																<asp:label style="Z-INDEX: 0" id="Label2" runat="server" CssClass="headerDetalle" BorderStyle="None">DE:</asp:label></TD>
															<TD class="ItemText" width="100%" noWrap>
																<asp:label style="Z-INDEX: 0" id="lblEmite" runat="server" CssClass="ItemText" BorderStyle="None">EMISOR:</asp:label></TD>
														</TR>
														<TR>
															<TD class="headerDetalle" colSpan="2">
																<asp:label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="headerDetalle" BorderStyle="None">PARA:</asp:label></TD>
														</TR>
														<TR>
															<TD colSpan="2"></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn HeaderText="NORMA">
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Hallazgo">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FuenteReporte" SortExpression="FuenteReporte" HeaderText="FUENTE">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreTipoAccion" SortExpression="NombreTipoAccion" HeaderText="ACCION">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreLugarDetectado" SortExpression="NombreLugarDetectado" HeaderText="DETECTADO EN">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemTemplate>
													<asp:image style="Z-INDEX: 0" id="imgEliminarSAM" onclick="EliminarACAP(this);" runat="server"
														ImageUrl="../imagenes/Filtro/Eliminar.gif"></asp:image>
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
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 12px" vAlign="top" width="100%" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%" align="center">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
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
		<SCRIPT>
				var odgrid = jNet.get('grid');
				for(var i=1;i<=odgrid.rows.length-1;i++){
					var otbl = jNet.get(odgrid.rows[i].cells[3].children[0]);
					var obtlDst = jNet.get(otbl.rows[2].cells[0].children[0]);
					var orowDst=obtlDst.rows[0];
					var oimgDst = orowDst.cells[2].children[0];
					
					var strFecha=orowDst.getAttribute("FECHACIERRE");
					if((strFecha!=null)&&(strFecha.toString().length>0)){
							var strPath ="/"+ApplicationPath +"/imagenes/Navegador/btnCargo.gif";
							oimgDst.src=strPath
							new Ext.ToolTip({
									target: oimgDst.id,
									title: "FECHA DE CIERRE",
									width:140,
									html: strFecha,
									trackMouse:true,
									dismissDelay: 15000 // auto hide after 15 seconds
								});						
						
					}
				}
		</SCRIPT>
	</body>
</HTML>
