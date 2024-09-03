<%@ Page language="c#" Codebehind="AdministrarFichaCovid.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarFichaCovid" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrar Ficha COVID</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="../js/RegEXT.js"></script>
		<SCRIPT type="text/javascript" src="http://simanet/SimanetJS/Ext/Ext.ux.Notify.js"></SCRIPT>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9) return false; " onunload="SubirHistorial();"
		onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0" rightMargin="0" scroll="no"
		topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de Personal ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Cuadro resumen de programación></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="1000">
							<TR>
								<TD bgColor="#000080" align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"> RESUMEN PROGRAMACIÓN</asp:label></TD>
							</TR>
							<TR>
								<TD align="left">
									<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD class="HeaderDetalle" noWrap align="left"><asp:label id="Label1" runat="server" BorderStyle="None"> NRO DOCUMENTO</asp:label></TD>
											<TD width="10%"><asp:textbox id="txtNroDoc" runat="server" CssClass="normaldetalle" rel="calendar"></asp:textbox></TD>
											<TD class="HeaderDetalle" width="10%" noWrap align="right"><asp:label style="Z-INDEX: 0" id="Label2" runat="server" BorderStyle="None">APELLIDOS Y NOMBRES</asp:label></TD>
											<TD width="100%" align="left"><asp:textbox style="Z-INDEX: 0" id="txtApellidosyNombres" runat="server" CssClass="normaldetalle"
													Width="100%"></asp:textbox></TD>
											<TD width="100%" align="left"><asp:button id="btnFind" runat="server" Text="Buscar"></asp:button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="PADDING-RIGHT: 5px" vAlign="top" align="left"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="100%" PageSize="15" Height="1px"
										AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle Height="20px" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="NroDNI" HeaderText="NRO DOCUMENTO">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ApellidosYNombres" HeaderText="APELLIDOS Y NOMBRES">
												<HeaderStyle Width="70%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="VIGENCIA">
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemTemplate>
													<asp:textbox style="Z-INDEX: 0" id="txtFechaV" runat="server" CssClass="normaldetalle" BorderStyle="None"
														rel="Calendario" Width="70px" Height="24px" BackColor="Transparent"></asp:textbox>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD bgColor="#f0f0f0" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False" DESIGNTIMEDRAGDROP="55"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="4" align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif">&nbsp;
									<INPUT style="WIDTH: 72px; HEIGHT: 23px" id="HIdTipoBusqueda" value="1" size="6" type="hidden"
										runat="server">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td style="DISPLAY: none">
						<TABLE style="Z-INDEX: 0; MARGIN-TOP: 10px; WIDTH: 272px; HEIGHT: 78px" id="tblPopup" border="0"
							cellSpacing="0" cellPadding="0" width="272">
							<TR>
								<TD></TD>
								<TD style="POSITION: relative; TOP: -10px" rowSpan="2">
									<TABLE style="BORDER-BOTTOM: darkgray 1px solid; BORDER-LEFT: darkgray 1px solid; PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; WIDTH: 47px; PADDING-RIGHT: 5px; HEIGHT: 42px; BORDER-TOP: darkgray 1px solid; BORDER-RIGHT: darkgray 1px solid; PADDING-TOP: 5px"
										id="Table8" border="0" cellSpacing="0" cellPadding="0" width="47">
										<TR>
											<TD style="PADDING-BOTTOM: 2px; PADDING-LEFT: 2px; PADDING-RIGHT: 2px; PADDING-TOP: 2px"><IMG style="Z-INDEX: 0; BORDER-BOTTOM: dimgray 1px; BORDER-LEFT: dimgray 1px; BACKGROUND-COLOR: transparent; WIDTH: 40px; TABLE-LAYOUT: auto; BORDER-TOP: dimgray 1px; BORDER-RIGHT: dimgray 1px"
													alt="" src="[FOTO]" width="40" height="45"></TD>
										</TR>
									</TABLE>
								</TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 33px" vAlign="top" align="left">
									<TABLE style="Z-INDEX: 0; HEIGHT: 39px" id="Table9" border="0" cellSpacing="0" cellPadding="0"
										width="10">
										<TR>
											<TD vAlign="top" align="left"><IMG style="Z-INDEX: 0" alt="" src="/SimaNetWeb/imagenes/Navegador/bg_widgetlisting_left.gif"></TD>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/bg_widgetlisting.gif); BACKGROUND-REPEAT: repeat-x; BACKGROUND-POSITION: left top; FONT-SIZE: 12pt; FONT-WEIGHT: bold"
												width="100%"></TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="HEIGHT: 33px" vAlign="top" width="900" align="left">
									<TABLE style="Z-INDEX: 0" id="Table10" border="0" cellSpacing="0" cellPadding="0" width="100%"
										align="left">
										<TR>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/bg_widgetlisting.gif); BACKGROUND-COLOR: whitesmoke; PADDING-LEFT: 7px; BACKGROUND-REPEAT: repeat-x; BACKGROUND-POSITION: left top; FONT-SIZE: 9pt; FONT-WEIGHT: bold"
												width="100%" align="left">[APROBADOPOR]</TD>
											<TD vAlign="top" align="left"><IMG alt="" src="/SimaNetWeb/imagenes/Navegador/bg_widgetlisting_right.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="BORDER-BOTTOM: dimgray 1px solid; HEIGHT: 2px; FONT-SIZE: 9pt" colSpan="3">
									<P style="TEXT-ALIGN: justify; FONT-SIZE: 9pt">Solicita a Ud. Sr. autorice el 
										ingreso de los representantes de la Empres y/o CIA.</P>
								</TD>
							</TR>
							<TR>
								<TD style="FONT-SIZE: 9pt; FONT-WEIGHT: bold" colSpan="3" align="center"><A href="[IRPAG]">[EMPRESA]</A></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
			<SCRIPT language="javascript" type="text/javascript">
			
				function FindForCtrl(e){
					document.getElementById('HIdTipoBusqueda').value= ((e.id=='txtNroDoc')?'1':'0');
				}
				
				function EjecutarQuery(e){					
					if(event.keyCode==13){
						__doPostBack('btnFind','Refresh');
					}
				}
				
				function ActualizaCovid(e,NroDoc){
					var NomCtrlEx='chkCExamen';
					var NomCtrlDiag='chkCDiagnostico';
					var nomObjSinUso='';
					
					var NomRelativo = e.id.substring(0,11);
					var NomCTRL = e.id.substring(11, 30);
					
					
					var rowid = e.id.replace('grid__ctl','');
						rowid = rowid.replace('_','');
						rowid = rowid.replace(NomCtrlEx,'');
						rowid = rowid.replace(NomCtrlDiag,'');
						
				
					var otxtFechaV = jNet.get('grid__ctl' + rowid + '_txtFechaV');

					try{
						var oCCTT_TrabajadorBE = new EntidadesNegocio.Personal.CCTT_TrabajadorBE();
						oCCTT_TrabajadorBE.NroDNI=NroDoc;
							if(NomCTRL=='chkCExamen'){
								NomCTRL=NomRelativo+NomCtrlDiag;
								oCCTT_TrabajadorBE.FechaVigencia = otxtFechaV.value;
								oCCTT_TrabajadorBE.ExamenCovid =0;//((e.checked==true)?1:0);
								oCCTT_TrabajadorBE.DiagnosticoCovid = 0;//((jNet.get(NomCTRL).checked==true)?1:0);
							}
							else{
								NomCTRL=NomRelativo+NomCtrlEx;
								oCCTT_TrabajadorBE.FechaVigencia = otxtFechaV.value;
								oCCTT_TrabajadorBE.ExamenCovid=	0;//((jNet.get(NomCTRL).checked==true)?1:0);
								oCCTT_TrabajadorBE.DiagnosticoCovid =0;// ((e.checked==true)?1:0);
							}
				
						(new Controladora.SeguridadIndustrial.CCCTT_AdministrarTrabajadorPatogenos()).Modificar(oCCTT_TrabajadorBE);
					}
					catch(error){
						alert("error:" + error.description);
					}
				}
			</SCRIPT>
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
									select:function(e,a,c){
											try{
												var orow;
												var rowid=0;
												var oGrid = jNet.get('grid');
												var oCCTT_TrabajadorBE = new EntidadesNegocio.Personal.CCTT_TrabajadorBE();

												rowid = (parseInt(e.id.toString().replace('ext-comp-',''))-1000)+1;
												orow = oGrid.rows[rowid];
												
												var otxtFechaV = jNet.get('grid__ctl' + (rowid+1) + '_txtFechaV');
												oCCTT_TrabajadorBE.NroDNI=otxtFechaV.attr('NRODNI');
												oCCTT_TrabajadorBE.FechaVigencia = otxtFechaV.value;
												oCCTT_TrabajadorBE.ExamenCovid =0;
												oCCTT_TrabajadorBE.DiagnosticoCovid =0;
												(new Controladora.SeguridadIndustrial.CCCTT_AdministrarTrabajadorPatogenos()).Modificar(oCCTT_TrabajadorBE);
											
											}
											catch(error){
												alert("error:" + error.description);
											}
										}
									}    
					});
				});
			}
			ConfigurarControlesFecha('Calendario');
			
		</script>
	</body>
</HTML>
