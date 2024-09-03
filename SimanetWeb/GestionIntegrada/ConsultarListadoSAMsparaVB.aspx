<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarListadoSAMsparaVB.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.ConsultarListadoSAMsparaVB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
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
		<style>.msg {
						BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/CorreoSend2.png); Z-INDEX: 0; POSITION: relative; WIDTH: 20px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 15px
					}
					.msgTotal {
						POSITION: absolute; TEXT-ALIGN: center; WIDTH: 18px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 18px; COLOR: navy; FONT-SIZE: 8pt; TOP: -10px; LEFT: 0px
					}
					.msgNoRead {
						BACKGROUND-IMAGE: url(/SimanetWeb/js/JQuery/imgs/Circulo.gif); POSITION: absolute; TEXT-ALIGN: center; WIDTH: 18px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 30px; COLOR: red; FONT-SIZE: 10pt; TOP: -10px; FONT-WEIGHT: bold
					}
		</style>
		<script>
			function VistoBueno(e,idSam,idDestino){
				//Aquie debe de actualizar el estado de la sam para cada area destino
				var VB = ((e.checked==true)?1:0);
				var oImg="<img src='../imagenes/Navegador/btnEnviar.png' width='20px' height='30px' ></img>";
				var strText="Desea ud. realizar el cierre definitivo  de este documento ahora? <br>Se enviará el correo " + oImg + " para conocimiento de cierre al area responsable de area";

					Ext.MessageBox.confirm('Confirmar',strText, function(btn){
						if(btn=="yes"){
							(new Controladora.OGI.CSAMDestino()).ActualizarVB(idSam,idDestino,VB);
							(new Controladora.OGI.CSAMNTAD()).EnviaCorreoRpt(idSam,idDestino);
							Ext.MessageBox.alert('CONTROL DE SAM', 'Se envió correo informativo de SITUACION de la SAM', function(btn){});
						}
						else{
							e.checked=false;
						}
					});								
			
			}
			
			function VerDetalleHallazgo(e,strIdSAM){
				var KEYQIDSAM = "IdSAM";
				var URLPAGINABITACORA = "/" + ApplicationPath + "/GestionIntegrada/ConsultarHallazgo.aspx?";
				(new System.Ext.UI.WebControls.Windows()).Dialogo('HALLAZGO',URLPAGINABITACORA + KEYQIDSAM + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + strIdSAM,e,600,345);
			}
			
			function VerReponsableDeArea(IdArea){
				var KEYQIDAREA = "IdArea";
				var URLRESPONSABLE = '/' + ApplicationPath + "/GestionIntegrada/ListarResponsablePorArea.aspx?";
				var URL = URLRESPONSABLE + KEYQIDAREA  + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdArea;
				(new System.Ext.UI.WebControls.Windows()).Dialogo('Listado de responsable por area',URL,this,800,400,CerrarDialogo);
			}
			function CerrarDialogo(HandleWind){
				HandleWind.close();
			}
			
			
			
			
			
			
			function CargarNotas(e,CodigoSAM,NombreNormaISO){
				var URLSAMNOTA = '/' + ApplicationPath + "/GestionIntegrada/AdministrarMsgVB.aspx?";
				var KEYQIDSAMISO = "IdSamISO";
				var KEYQIDTIPONORMA = "TNorma";
				
				var URL = URLSAMNOTA + KEYQIDSAMISO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + e.getAttribute("IDSAMISO")
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQIDTIPONORMA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + e.getAttribute("IDTIPONORMA")
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDSAM + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodigoSAM;
				
				(new SIMA.Utilitario.Helper.Response()).ShowDialogoModal(URL,300,550,this);

			}
			
			function CerrarDialogo(HandleWind){
				HandleWind.close();
			}
		</script>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" onunload="SubirHistorial();"
		onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form style="Z-INDEX: 0" id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td style="HEIGHT: 23px" bgColor="#eff7fa" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 22px" class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Integrada></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Solicitud de mejora para su VB</asp:label></TD>
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
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton></TD>
											<TD></TD>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminaFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD></TD>
											<TD width="100%"><asp:imagebutton style="Z-INDEX: 0" id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
											<TD width="100%"></TD>
											<TD></TD>
											<TD><IMG style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 5px" alt="" src="/SIMANETWEB/imagenes/spacer.gif"
													width="16" height="5"></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" AllowPaging="True" AllowSorting="True"
										AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" ShowFooter="True" Width="100%">
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
													<asp:image style="Z-INDEX: 0" id="imgEliminarSAM" runat="server" ImageUrl="../imagenes/Filtro/Eliminar.gif"></asp:image>
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
										name="hIdDestino" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hidUsuarioEmite" size="1" type="hidden"
										name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hIdAccionInmediata" size="1" type="hidden"
										name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hIdArea" size="1" type="hidden"
										name="Hidden1" runat="server">
								</TD>
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
