<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleObservacionesAuditoria.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstituacional.DetalleObservacionesAuditoria" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script>
				

			function ObtenerDestinos(){
				var strLstDestino="";
				var oCellDestino = jNet.get('cellListDestino');
				for(var i=0;i<=oCellDestino.children.length-1;i++){
					var otblItemDestino= jNet.get(oCellDestino.children[i]);
					strLstDestino +=  otblItemDestino.attr('IDDESTINO') +';'+ otblItemDestino.id.toString().Replace('obj','')+  ';' +  otblItemDestino.rows[0].cells[0].innerText + '@';
				}
				jNet.get('hLstDetinatario').value = strLstDestino.substring(0,strLstDestino.length-1);
				/*window.alert(jNet.get('hLstDetinatario').value);*/
			}
			
			
			function ListarCtrlDestinos(){
				var LstDestinos = jNet.get('hLstDetinatario').value.toString().split('@');
				if((LstDestinos.length>0)&&(LstDestinos[0].length>0)){
					for(var i=0;i<=LstDestinos.length-1;i++){
						var arrCampos = LstDestinos[i].toString().split(';');	
						CrearCtrlDestino(arrCampos[0],arrCampos[1],arrCampos[2]);
					}
				}
			}

			function CrearCtrlDestino(IdDestino,IdArea,NombreArea){
				var HTMLTable = jNet.get((new SIMA.Utilitario.Helper.General.Html()).CrearTabla(1,2));
				IdObj = "obj" + IdArea;
				HTMLTable.align="left";
				HTMLTable.style.cssText="MARGIN-BOTTOM: 5px; MARGIN-LEFT: 5px";
				HTMLTable.attr("id",IdObj);
				HTMLTable.attr("IDDESTINO",IdDestino);
				HTMLTable.className="BaseItemInGrid";
				HTMLTable.border=0;
				HTMLTable.rows[0].cells[0].innerText=NombreArea;
				HTMLTable.rows[0].cells[0].noWrap=true;
				var oIMG = SIMA.Utilitario.Helper.General.CrearImgEliminar(1);
				oIMG.onclick=function(){
					var oTBLItem = jNet.get(this.parentNode.parentNode.parentNode.parentNode);
					if(oPagina.Request.Params[SIMA.Utilitario.Constantes.KEYMODOPAGINA]!=SIMA.Utilitario.Enumerados.ModoPagina.C){
						Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro ahora?', function(btn){
										if(btn=="yes"){
											jNet.get('cellListDestino').removeChild(oTBLItem);
											ObtenerDestinos();
										}
									});
					}
				}
				jNet.get(HTMLTable.rows[0].cells[1]).insert(oIMG);
				jNet.get('cellListDestino').insert(HTMLTable);
			}			
		
		</script>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD colSpan="3"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center">
							<TR>
								<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >  Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro Observación de Auditoría</asp:label></TD>
							</TR>
						</TABLE>
				<TR>
					<TD vAlign="top" align="center"><SPAN class="normal"></SPAN>
						<TABLE style="WIDTH: 768px; HEIGHT: 72px" id="Table3" class="normal" border="0" cellSpacing="1"
							cellPadding="1" width="768" align="center">
							<TR>
								<TD class="TituloPrincipalBlanco" bgColor="#000080" width="475" colSpan="5" align="left"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="14px"></asp:label><asp:label id="lblDatos" runat="server" CssClass="TituloPrincipalBlanco" Height="14px"></asp:label></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4"><asp:label id="Label8" runat="server" CssClass="TextoBlanco">Centro Operativo:</asp:label></TD>
								<TD class="normal" bgColor="#dddddd" colSpan="4" align="left">
									<asp:dropdownlist style="Z-INDEX: 0" id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle"
										Height="70px" Width="248px"></asp:dropdownlist>
								</TD>
								<TD class="normal" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4">
									<asp:label id="Label9" runat="server" CssClass="TextoBlanco">Situación:</asp:label></TD>
								<TD class="normal" bgColor="#f0f0f0" colSpan="4">
									<asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Height="70px" Width="248px"></asp:dropdownlist></TD>
								<TD class="normal" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4"><asp:label style="Z-INDEX: 0" id="Label2" runat="server" CssClass="TextoBlanco">AREA(S):</asp:label></TD>
								<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:textbox style="Z-INDEX: 0" id="txtBuscar" runat="server" Width="100%"></asp:textbox></TD>
								<TD class="normal" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4"><INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 23px" id="hLstDetinatario" size="1" type="hidden"
										name="Hidden1" runat="server"></TD>
								<TD style="BORDER-BOTTOM: gray 1px solid; BORDER-LEFT: gray 1px solid; PADDING-BOTTOM: 5px; PADDING-RIGHT: 5px; BORDER-TOP: gray 1px solid; BORDER-RIGHT: gray 1px solid"
									id="cellListDestino" bgColor="#ffffff" height="40" vAlign="top" width="100%" colSpan="4"
									runat="server"></TD>
								<TD class="normal" colSpan="2">&nbsp;</TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4">
									<asp:label style="Z-INDEX: 0" id="Label13" runat="server" CssClass="TextoBlanco">Responsable:</asp:label></TD>
								<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtPersonalRespo" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
								<TD class="normal" colSpan="2">
									<cc1:requireddomvalidator style="Z-INDEX: 0" id="rfvResponsable" runat="server" ControlToValidate="txtPersonalRespo">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4"><asp:label id="Label7" runat="server" CssClass="TextoBlanco">Fecha Término:</asp:label></TD>
								<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:textbox style="Z-INDEX: 0" id="calFechaTermino" runat="server" CssClass="normaldetalle"
										Width="60px" rel="calendar"></asp:textbox></TD>
								<TD class="normal" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4"><asp:label id="lblConcepto" runat="server" CssClass="TextoBlanco"> Observaciones:</asp:label></TD>
								<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Height="50px" Width="100%"
										TextMode="MultiLine" MaxLength="1500"></asp:textbox></TD>
								<TD class="normal" colSpan="2"><cc1:requireddomvalidator id="rfvObservacion" runat="server" ControlToValidate="txtObservaciones">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4"><asp:label id="Label1" runat="server" CssClass="TextoBlanco">Recomendaciones:</asp:label></TD>
								<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtRecomendaciones" runat="server" CssClass="normaldetalle" Height="50px" Width="100%"
										TextMode="MultiLine" MaxLength="1500"></asp:textbox></TD>
								<TD class="normal" colSpan="2"></TD>
							</TR>
						</TABLE>
						<TABLE id="Table7" border="0" width="630" align="center">
							<TR>
								<TD align="center"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;
									<IMG style="CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif">
								</TD>
							</TR>
						</TABLE>
						<INPUT style="WIDTH: 9px; HEIGHT: 22px" id="hIdPersonal" size="1" type="hidden" name="hIdPersonal"
							runat="server">
						<cc1:domvalidationsummary id="Vresumen" runat="server" Height="24px" Width="160px" DisplayMode="List" EnableClientScript="False"
							ShowMessageBox="True"></cc1:domvalidationsummary></TD>
				</TR>
			</TABLE>
			</TD></TR></TABLE></TD></TR></TABLE></form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<SCRIPT>
						var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
						var IdObj="";
						
						
						
						var textBoxes = Ext.DomQuery.select("input[rel=calendar]");   
						Ext.each(textBoxes, function(item, id, all){   
							var cl = new Ext.form.DateField({   
								format: 'd/m/Y',
								allowBlank : false,   
								applyTo: item   
							});
						});   
						
						
						function txtPersonalRespo_ItemDataBound(sender,e,dr){
							jNet.get('hidPersonal').value = dr["idpersonal"].toString();
						}
						function txtBuscar_ItemDataBound(sender,e,dr){
							CrearCtrlDestino('0',dr["IdArea"].toString(),dr["NombreArea"].toString());
							jNet.get('txtBuscar').value='';
							ObtenerDestinos();
						}
						
						
						
						if(oPagina.Request.Params[SIMA.Utilitario.Constantes.KEYMODOPAGINA]!=SIMA.Utilitario.Enumerados.ModoPagina.C){
							var	oParamCollecionBusqueda = new ParamCollecionBusqueda();
							var oParamBusqueda = new ParamBusqueda();
								oParamBusqueda.Nombre="NombreArea";
								oParamBusqueda.Texto="Nombre Area";
								oParamBusqueda.LongitudEjecucion=2;
								oParamBusqueda.Tipo="C";
							oParamCollecionBusqueda.Agregar(oParamBusqueda);

								oParamBusqueda = new ParamBusqueda();
								oParamBusqueda.Nombre="idProceso";
								oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarAreaenGeneralPorNombre;
								oParamBusqueda.Tipo="Q";
							oParamCollecionBusqueda.Agregar(oParamBusqueda);
							(new AutoBusqueda('txtBuscar')).Crear('/' + ApplicationPath + '/GestionIntegrada/Procesar.aspx?',oParamCollecionBusqueda);
						}
						
						//Crear los controles de areas
						ListarCtrlDestinos();
						
						//Configuracion de Busqueda para Personal
						var oParamCollecionBusqueda = new ParamCollecionBusqueda();
						var oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="Nombres";
							oParamBusqueda.Texto="Apellidos y Nombres";
							oParamBusqueda.LongitudEjecucion=1;
							oParamBusqueda.Tipo="C";
							oParamBusqueda.CampoAlterno = "NroPersonal";
							oParamBusqueda.LongitudEjecucion=4;
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="idProceso";
							oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarPersonal;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						(new AutoBusqueda('txtPersonalRespo')).Crear('/' + ApplicationPath + '/GestionFinanciera/Procesar.aspx?',oParamCollecionBusqueda);
						
						
						
						
						
						
		</SCRIPT>
	</body>
</HTML>
