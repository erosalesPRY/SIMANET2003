<%@ Page language="c#" Codebehind="AdministrarAccionesCP.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.AdministrarAccionesCP" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
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
		<script type="text/javascript" src="/SimaNetWeb/js/Upload/mint"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Upload/si.files.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<STYLE title="text/css" type="text/css">.SI-FILES-STYLIZED LABEL.cabinet { WIDTH: 95px; DISPLAY: block; BACKGROUND: url(/SimaNetWeb/imagenes/Navegador/BtnOpciones/AnexarArchivo.bmp) no-repeat 0px 0px; HEIGHT: 25px; OVERFLOW: hidden; CURSOR: hand }
	.SI-FILES-STYLIZED LABEL.cabinet INPUT.file { POSITION: relative; FILTER: progid:DXImageTransform.Microsoft.Alpha(opacity=0); WIDTH: auto; HEIGHT: 100%; opacity: 0; -moz-opacity: 0 }
	</STYLE>
		<script>
			function Agregar(e){					
				var orow;
				if(e.id.toString().indexOf("txtFechaPlazo")!=-1){
					orow =jNet.get(e.parentNode.parentNode.parentNode);
				}
				if(e.tagName.toString()=="TD"){
					orow =jNet.get(e.parentNode);
				}
				else{
					orow = jNet.get(e.parentNode.parentNode);
				}		
				
				eval(orow.attr("REGBE"));
				RegistroBE.toString=function(Clear){
					var StructData="";
					if(Clear){
						this["IDACCION"]="9";
						this["MODO"]="N";
						this["TIPOACCION"]="0"
						this["ACCION"]="";
						//this["FECHA"]=""
						this["IDRESPONSABLE"]="0";
					}
		            for (var name in this) { 
						if(name!="toString"){
							StructData = StructData + name.toString() + ":'" + this[name.toString()] + "',";
		                }
                    }  
	                StructData = "var RegistroBE = {" + StructData.substring(0,StructData.length-1) + "}";
		            return StructData.toString();					
				}
				
				var oddlTipoAccion= jNet.get(orow.cells[1].children[0]);
				var oItem = oddlTipoAccion.options[oddlTipoAccion.selectedIndex];
				var otxtAccion= jNet.get(orow.cells[2].children[0]);
				var otxtFecha = jNet.get(orow.cells[3].children[0].children[0]);
				var oCellResponable = jNet.get(orow.cells[4]);
				
				if(RegistroBE.TIPOACCION.Equal(oItem.value)
					&& RegistroBE.ACCION.Equal(otxtAccion.value)
					&& RegistroBE.FECHA.Equal(otxtFecha.value)
					&& RegistroBE.IDRESPONSABLE.Equal(oCellResponable.attr("value"))
					){
						return false;
				}
				
				
				if(RegistroBE.MODO=='N'){
						var srMsg = "Si los datos no son completados  el registro no se guardara."
						var objFind = jNet.get("txtB" + orow.rowIndex);
							/*if(otxtAccion.value.length==0){
								Ext.MessageBox.alert('SAM', 'Ingresar DESCRIPCIÓN de la ACCIÓN <br><br>'+srMsg  , function(btn){});
								otxtAccion.focus();
								return;
							}
							if(otxtFecha.value.length==0){
								Ext.MessageBox.alert('SAM', 'Ingresar FECHA de plazo<br><br>'+srMsg , function(btn){});
								otxtFecha.focus();
								return;
							}
							
							if(oCellResponable.attr("value")=="0"){
								Ext.MessageBox.alert('SAM', 'Ingresar RESPONSABLE de la ACCIÓN<br><br>'+srMsg , function(btn){});
								objFind.focus();
								return;
							}*/
				
					var oDataGrid = orow.parentNode;
					
					var oRowClon = jNet.get(orow.cloneNode(true));
					oDataGrid.appendChild(oRowClon);
					jNet.get('hIdRowGrid').value = oRowClon.rowIndex;
					
					var oCLddlTipoAccion= jNet.get(oRowClon.cells[1].children[0]);
					var oCLtxtAccion= jNet.get(oRowClon.cells[2].children[0]);oCLtxtAccion.value="";
					var oCLtxtFecha = jNet.get(oRowClon.cells[3].children[0].children[0]);
					var ctrlRemove = oRowClon.cells[3].children[0];
					
					oRowClon.cells[3].removeChild(ctrlRemove);
					jNet.get(oRowClon.cells[3]).insert(oCLtxtFecha);
					var NombreCal = "cal" + oRowClon.rowIndex;
					oCLtxtFecha.id = NombreCal;
					new Ext.form.DateField({allowBlank : false, applyTo: oCLtxtFecha,format:'d/m/Y'});   
										
					var oCLCellResponsable = jNet.get(oRowClon.cells[4]);
					oCLCellResponsable.attr("value","0");
					var otxtBusqueda = oCLCellResponsable.children[0];
					oCLCellResponsable.removeChild(otxtBusqueda);
					
					ConfiguraBusqueda(oRowClon.rowIndex ,oRowClon.cells[4],"");
					orow.cells[6].children[0].style.display="block";
					oRowClon.attr("REGBE",RegistroBE.toString(true));
					
					/*Visualiza el Boton de Correo de tomar accion*/
					var oimgEnviaEmail = jNet.get(oRowClon.cells[6].children[0]);
					oimgEnviaEmail.style.display="none";
					
				}

				

				var oSAMAccionBE= new EntidadesNegocio.OGI.SAMAccionBE();
				oSAMAccionBE.IdAccion = orow.attr("IDACCION");
				oSAMAccionBE.IdTipoAccion = oItem.value;
				oSAMAccionBE.Descripcion = otxtAccion.value;
				oSAMAccionBE.PlazoEjecucion = otxtFecha.value;
				oSAMAccionBE.IdPersonal = oCellResponable.attr("value") ;

				var IdResult =(new Controladora.OGI.CSAMAccion()).Insertar(oSAMAccionBE);
					orow.attr("IDACCION",IdResult);
					jNet.get('hIdAccion').value = IdResult;//Sirve de referencia para los anexos
				
				RegistroBE.IDACCION = IdResult;
				RegistroBE.MODO="M";
				RegistroBE.TIPOACCION=oItem.value;
				RegistroBE.ACCION=otxtAccion.value;
				RegistroBE.FECHA=otxtFecha.value;
				RegistroBE.IDRESPONSABLE=oCellResponable.attr("value");
				orow.attr("REGBE",RegistroBE.toString());

				if(IdResult!='-1'){
					var IdGrupoCausaRaizAccion = "";
					var oCtrls = jNet.get('CellLstCR').children;
						var objCtrl = jNet.get(oCtrls[0]);
						if(objCtrl.attr("IDGRUPOCR")=='0'){
							objCtrl.attr("IDGRUPOCR",(new Controladora.OGI.CSAMGrupoCausaRaizAccion()).Insertar());
						}
					IdGrupoCausaRaizAccion = objCtrl.attr("IDGRUPOCR");
					for(var c=0;c<=oCtrls.length-1;c++){
						objCtrl = jNet.get(oCtrls[c]);
						var  oSAMCausaRaizAccionBE =  new EntidadesNegocio.OGI.SAMCausaRaizAccionBE();
						oSAMCausaRaizAccionBE.IdCausaRaiz =  objCtrl.attr("IDCAUSARAIZ");
						oSAMCausaRaizAccionBE.IdAccion =IdResult;
						oSAMCausaRaizAccionBE.IdGrupoCausaRaizAccion = IdGrupoCausaRaizAccion;
						oSAMCausaRaizAccionBE.IdEstado =1;
						(new Controladora.OGI.CSAMCausaRaizAccion()).Insertar(oSAMCausaRaizAccionBE);
					}
				}					
				orow.onclick();
			}
			
			function Eliminar(e){
				e = jNet.get(e);
				//if(jNet.get('hIdEstado').value=="2"){Ext.MessageBox.alert('SAM', 'No es posible eliminar este registro por que la Solicitud e Accion de Mejora se encuentra cerrada', function(btn){});return false;}
				var orow = jNet.get(e.parentNode.parentNode);
				var oTblCR = jNet.get(orow.parentNode.parentNode);
				Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro ahora?', function(btn){
					if(btn=="yes"){
						var oDataGrid = jNet.get('gridACAP');
						for(var i=1;i<=oDataGrid.rows.length-1;i++){
							var orow= jNet.get(oDataGrid.rows[i]);
							if(orow.attr("IDACCION")!='9'){
								(new Controladora.OGI.CSAMCausaRaizAccion()).Eliminar(oTblCR.attr("IDCAUSARAIZ"),orow.attr("IDACCION"));	
							}
						}
						jNet.get('CellLstCR').removeChild(oTblCR);
					}
				});					
			}
			
			
			function EliminarACAP(e){
				//if(jNet.get('hIdEstado').value=="2"){Ext.MessageBox.alert('SAM', 'No es posible crear o modificar este registro por que la Solicitud e Accion de mejora se encuentra cerrada', function(btn){});return false;}
				//if(jNet.get('hIdEstadoACAP').value=="2"){Ext.MessageBox.alert('SAM', 'No es posible crear o modificar este registro por que la Causa Raiz  se encuentra cerrada', function(btn){}); return false;}
				var orow = jNet.get(e.parentNode.parentNode);
				var oDataGrid = orow.parentNode;
				Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro ahora.?', function(btn){
					if(btn=="yes"){
						eval(orow.attr("REGBE"));
						(new Controladora.OGI.CSAMAccion()).Eliminar(RegistroBE.IDACCION);
						oDataGrid.removeChild(orow);
					}
				});					
			}
			
			function EnviarCorreo(e){
				//var orow = jNet.get(e.parentNode.parentNode);
				var orow = jNet.get(e.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode);
				var oDataGrid = orow.parentNode;
				Ext.MessageBox.confirm('Confirmar', 'Desea ud. enviar correo de conocimiento de esta actividad ahora.?', function(btn){
					if(btn=="yes"){
						/*var splah=new Ext.LoadMask(Ext.getBody(), {msg:'Loading. Please wait...'});
						  splah.show();
						*/
						eval(orow.attr("REGBE"));
						window.setTimeout("",8000);
						var strReturn =(new Controladora.OGI.CSAMCausaRaizAccion()).EnviarCorreo(RegistroBE.IDACCION);
					}
				});			
			}
			

			var oRowClonado;
			var BusquedaVisible=false;
			
			function UltimaFilaSeleccionada(){
				var IdFilaSeleccionada = jNet.get('hIdRowGrid').value;
				if(IdFilaSeleccionada!='0'){
					var oDataGrid = jNet.get('gridACAP');
					oDataGrid.rows[IdFilaSeleccionada].onclick();
				}
			}
			
			function CrearCtrlAnexo(IdAccionAnexo,NombreFile,Estilo){
				var arrNombre = NombreFile.toString().split('.');
				var Nombre = NombreFile.toString().Replace(arrNombre[arrNombre.length-1].toString(),"");
				var HTMLTable = jNet.get((new SIMA.Utilitario.Helper.General.Html()).CrearTabla(1,3));
				IdObj = "obj" + IdAccionAnexo;
				
				HTMLTable.attr("id",IdObj);
				HTMLTable.attr("IDACCIONANEXO",IdAccionAnexo);
				HTMLTable.attr("NOMBRE",NombreFile);
				HTMLTable.className=Estilo;				
				HTMLTable.border=0;
				HTMLTable.attr("width","100px");
				
				var Extension = arrNombre[arrNombre.length-1].toString().toUpperCase();
				HTMLTable.attr("EXTENSION",Extension.toLowerCase())
				
				var oIMG = SIMA.Utilitario.Helper.General.CrearImg('/' + ApplicationPath + '/imagenes/Navegador/' + ObtenerExtension(Extension) + '.png');
				oIMG.onclick=function(){
					var oTBLItem = jNet.get(this.parentNode.parentNode.parentNode.parentNode);
					var Ext = HTMLTable.attr("EXTENSION");
					if((Ext=='jpg')||(Ext=='gif')||(Ext=='bmp')||(Ext=='png')){
						var URL='/' + ApplicationPath +'/GestionIntegrada/VistaPrevia.aspx?' + SIMA.Utilitario.Constantes.KEYQNOMBREIMGPREVIO +  SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + 'AA_' + oTBLItem.attr("IDACCIONANEXO") + '_' + oTBLItem.attr("NOMBRE");
						(new System.Ext.UI.WebControls.Windows()).Dialogo('VISTA PREVIA',URL,this,window.screen.width-100,window.screen.height-100);
					}
					else{
						(new SIMA.Utilitario.Helper.Window()).AbrirExcel(jNet.get('hRutaHTTP').value + 'AA_' + oTBLItem.attr("IDACCIONANEXO") + '_' + oTBLItem.attr("NOMBRE"));
					}
				}
				jNet.get(HTMLTable.rows[0].cells[0]).insert(oIMG);
				HTMLTable.rows[0].cells[1].innerText=Nombre;
				HTMLTable.rows[0].cells[1].noWrap=true;
				
				oIMG = SIMA.Utilitario.Helper.General.CrearImgEliminar(1);
				oIMG.onclick=function(){
					var oTBLItem = jNet.get(this.parentNode.parentNode.parentNode.parentNode);
					var oCellContext = oTBLItem.parentNode;
					if(oTBLItem.attr("IDACCIONANEXO")!='0'){
						Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este archivo ahora?', function(btn){
											if(btn=="yes"){
												(new Controladora.OGI.CSAMAccionAnexo()).Eliminar(oTBLItem.attr("IDACCIONANEXO"));
												jNet.get(oCellContext).removeChild(oTBLItem);
											}
										});					
					
					}
				}
				//Segun el estado de grupo se activa o desactiva la funcionalidad de edicion de las acciones
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				if(oPagina.Request.Params[SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDESTDOGRPCR]!='2'){
					jNet.get(HTMLTable.rows[0].cells[2]).insert(oIMG);
				}
				
				return HTMLTable;
			}
			
			
			function ListarCausaRaiz(){
					
					var cellContext = jNet.get('tblCausaRaiz').rows[0].cells[0];
					cellContext.Remover=function(){
						var NroElement =this.children.length-1;
						for(var i=0;i<=NroElement;i++){
							var elementEL = this.children[0];
							this.removeChild(elementEL);
						}
					}
					cellContext.Remover();
					
					var ctrlLst = jNet.get('CellLstCausaRaiz').children;
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
					(new System.Ext.UI.WebControls.Windows()).DetalleFromEL('MiVentana','tblCausaRaiz','Seleccionar',315,210,winDet_ibtn_Aceptar);
				
			}
						
			
			function winDet_ibtn_Aceptar(HandlerWind){
				var cellContext = jNet.get('tblCausaRaiz').rows[0].cells[0];
				var oDataGrid = jNet.get('gridACAP');
				
				cellContext.ObtenerCausaRaiz=function(){
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					
					for(var c=0;c<=this.children.length-1;c++){
						var ctrl = jNet.get(this.children[c]);
						var chk = ctrl.rows[0].cells[2].children[0];
						if(chk.checked==true){
							for(var i=1;i<=oDataGrid.rows.length-1;i++){
								if(jNet.get(oDataGrid.rows[i]).attr("IDACCION")!='9'){
									var  oSAMCausaRaizAccionBE =  new EntidadesNegocio.OGI.SAMCausaRaizAccionBE();
										oSAMCausaRaizAccionBE.IdCausaRaiz =  ctrl.attr("IDCAUSARAIZ")
										oSAMCausaRaizAccionBE.IdAccion =jNet.get(oDataGrid.rows[i]).attr("IDACCION");
										oSAMCausaRaizAccionBE.IdGrupoCausaRaizAccion=oPagina.Request.Params[SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIGRUPOCRA];
										oSAMCausaRaizAccionBE.IdEstado =1;
										(new Controladora.OGI.CSAMCausaRaizAccion()).Insertar(oSAMCausaRaizAccionBE);									
								}
							}
						}
					}
					document.location.reload();
				}
				//Ejecuta
				cellContext.ObtenerCausaRaiz();
				HandlerWind.hide();
			}
			
			function ListaAnexo(orow){
				var IdAccion = jNet.get(orow).attr("IDACCION");
				if(IdAccion!="9"){
					var oDataTable = new System.Data.DataTable();
					oDataTable = (new Controladora.OGI.CSAMAccionAnexo()).ListarTodosGrilla(IdAccion);
					for(var p=0;p<=oDataTable.Rows.Items.length-1;p++){
						var drAA=oDataTable.Rows.Items[p];
						if(drAA.Item('EOF')==false){
							var IdAccionAnexo = drAA.Item('IdAccionAnexo');
							var Nombre = drAA.Item('Nombre');
							var HtmlCtrl =CrearCtrlAnexo(IdAccionAnexo,Nombre,'BaseItemInGrid');
							jNet.get(orow.cells[5]).insert(HtmlCtrl);
						}
					}
				}					
			}
			

			function ModificarACCSAM(e){
				if(e.getAttribute("OLD")!=e.value){
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var oSolicitudAccionMejoraBE= new EntidadesNegocio.OGI.SolicitudAccionMejoraBE();
					oSolicitudAccionMejoraBE.IdDestino = oPagina.Request.Params[SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDDESTINO];
					oSolicitudAccionMejoraBE.AccionInmediata=e.value;
					(new Controladora.OGI.CSolicitudAccionMejora()).Modificar(oSolicitudAccionMejoraBE);
					e.setAttribute("OLD",e.value);
				 }
			}
			
			function MostrarVerificaciones(IdGrupoAccionVerificacion){
				var URLDETALLE = '/' + ApplicationPath + '/GestionIntegrada/ConsultarVerificacionesPorAccion.aspx' + SIMA.Utilitario.Constantes.General.Caracter.signoInterrogacion
								+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQGRPACCIONVERIFICA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdGrupoAccionVerificacion;
				(new System.Ext.UI.WebControls.Windows()).Dialogo('VERIFICACION DE OGI',URLDETALLE,this,580,405);	
			}
			
		



 /*
function checkChanges(){
	var oDataGrid = document.getElementById("gridACAP");
	
	for(var i=1;i<=gridACAP.rows.length-1;i++){
		var orow=jNet.get(gridACAP.rows[i]);
		eval(orow.attr("REGBE"));
		if(RegistroBE.IDACCION!=9){
			alert(RegistroBE.ACCION  + "  " + RegistroBE.IDRESPONSABLE + "  " + RegistroBE.MODO);
			
		}
	}
	window.history.forward();
}
*/
		
				
		</script>
</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" onunload="SubirHistorial();" 
		onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0" >
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td style="HEIGHT: 23px" bgColor="#eff7fa" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 22px" class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Integrada></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Causa Raiz - Acción Correctiva</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 27px" bgColor="#000080" width="100%" align="left"><asp:label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="TituloPrincipalBlanco">SOLICITUD DE ACCION DE MEJORA</asp:label><INPUT style="WIDTH: 48px; HEIGHT: 22px" id="hIdEstado" size="2" type="hidden" name="hIdEstado"
							runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 48px; HEIGHT: 22px" id="hIdEstadoACAP" size="2" type="hidden"
							name="Hidden2" runat="server"></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE style="HEIGHT: 72px" id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%"
							align="left">
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 114px" class="headerDetalle" noWrap><asp:label id="Label4" runat="server" CssClass="headerDetalle" BorderStyle="None">TIPO DE UDITORIA</asp:label></TD>
								<TD style="WIDTH: 117px"><asp:textbox id="txtTipoAuditoria" runat="server" CssClass="normaldetalle" BorderStyle="None"
										BackColor="Transparent" Width="120px"></asp:textbox></TD>
								<TD style="WIDTH: 100px" class="headerDetalle"><asp:label id="Label5" runat="server" CssClass="headerDetalle" BorderStyle="None">AUDITORIA</asp:label></TD>
								<TD style="WIDTH: 106px"><asp:textbox style="Z-INDEX: 0" id="txtAuditoria" runat="server" CssClass="normaldetalle" BorderStyle="None"
										BackColor="Transparent" Width="120px"></asp:textbox></TD>
								<TD style="WIDTH: 100px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label8" runat="server" CssClass="headerDetalle" BorderStyle="None">TIPO DE ACCIÓN</asp:label></TD>
								<TD style="WIDTH: 112px"><asp:textbox style="Z-INDEX: 0" id="txtTipoAccion" runat="server" CssClass="normaldetalle" BorderStyle="None"
										BackColor="Transparent" Width="120px"></asp:textbox></TD>
								<TD style="WIDTH: 95px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label9" runat="server" CssClass="headerDetalle" BorderStyle="None">DETECTADO EN</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtDetectadoEn" runat="server" CssClass="normaldetalle" BorderStyle="None"
										BackColor="Transparent" Width="120px"></asp:textbox></TD>
								<TD rowSpan="3" align="center"><asp:image style="Z-INDEX: 0" id="imgClose" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/Candado1.gif"></asp:image></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 114px" class="headerDetalle"><asp:label id="Label6" runat="server" CssClass="headerDetalle" BorderStyle="None">NRO REGISTRO</asp:label></TD>
								<TD style="WIDTH: 117px"><asp:textbox id="txtNroRegistro" runat="server" CssClass="normaldetalle" BorderStyle="None" BackColor="Transparent"
										Width="120px"></asp:textbox></TD>
								<TD style="WIDTH: 100px" class="headerDetalle" noWrap><asp:label id="Label7" runat="server" CssClass="headerDetalle" BorderStyle="None">FECHA EMISIÓN</asp:label></TD>
								<TD style="WIDTH: 106px"><asp:textbox id="txtFechaEmision" runat="server" CssClass="normaldetalle" BorderStyle="None"
										BackColor="Transparent" Width="120px"></asp:textbox></TD>
								<TD style="WIDTH: 100px" class="headerDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label11" runat="server" CssClass="headerDetalle" BorderStyle="None">NRO  DIAS TRANS.</asp:label></TD>
								<TD style="WIDTH: 112px"><asp:textbox style="Z-INDEX: 0" id="txtNDiasTrans" runat="server" CssClass="normaldetalle" BorderStyle="None"
										BackColor="Transparent" Width="120px"></asp:textbox></TD>
								<TD style="WIDTH: 95px" class="headerDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label12" runat="server" CssClass="headerDetalle" BorderStyle="None">FECHA CADUCA</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtFechaCaducidad" runat="server" CssClass="normaldetalle"
										BorderStyle="None" BackColor="Transparent" Width="120px"></asp:textbox></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 114px" class="headerDetalle" height="40"><asp:label style="Z-INDEX: 0" id="Label10" runat="server" CssClass="headerDetalle" BorderStyle="None"
										Height="15px">DESCRIPCIÓN DEL HALLAZGO</asp:label></TD>
								<TD height="40" vAlign="top" colSpan="7" align="left"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" BorderStyle="None" BackColor="Transparent"
										Width="100%" Height="40px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label13" runat="server" CssClass="headerDetalle" BorderStyle="None"
										Height="15px">ACCIONES INMEDIATAS</asp:label></TD>
								<TD colSpan="8"><asp:textbox style="Z-INDEX: 0" id="txtAccionesInmediatas" runat="server" CssClass="normaldetalle2"
										BackColor="White" Width="100%" Height="40px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD style="HEIGHT: 26px" bgColor="#000080"><asp:label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="TituloPrincipalBlanco">LISTADO DE CAUSA RAIZ QUE SERAN CUBIERTAS POR LAS SIGUIENTES ACCIONES</asp:label></TD>
							</TR>
							<TR>
								<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 3px; PADDING-RIGHT: 3px; HEIGHT: 26px"
									id="CellLstCRTMP" runat="server">
									<TABLE id="Table4" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 3px; PADDING-RIGHT: 3px; HEIGHT: 26px"
												id="CellLstCR" width="100%" runat="server"></TD>
											<TD><IMG id="btnAgregarCR" onclick="ListarCausaRaiz();" src="../imagenes/btnAgregarCausaRaiz.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 26px" bgColor="#000080"><asp:label style="Z-INDEX: 0" id="Label2" runat="server" CssClass="TituloPrincipalBlanco">ACCIONES CORRECTIVAS / PREVENTIVAS</asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 26px" colSpan="2" align="right"><LABEL class="cabinet"><INPUT style="Z-INDEX: 0" id="FUFile" class="file" size="1" type="file" name="FUFile" runat="server"></LABEL></TD>
							</TR>
							<TR>
								<TD colSpan="2"><cc1:datagridweb style="Z-INDEX: 0" id="gridACAP" runat="server" Width="100%" PageSize="20" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True">
<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<ItemStyle Height="70px" CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO">
<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn SortExpression="IdTipoAccion" HeaderText="ACCION">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>

<ItemTemplate>
													<asp:dropdownlist style="Z-INDEX: 0" id="ddlTipoAccion" runat="server" Width="108px" Height="22px"></asp:dropdownlist>
												
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="DESCRIPCION DE LA ACCION A REALIZAR">
<HeaderStyle HorizontalAlign="Left" Width="400px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>

<ItemTemplate>
<asp:textbox style="Z-INDEX: 0" id=txtAccion runat="server" CssClass="normaldetalle2" BorderStyle="None" Width="100%" Height="100%" TextMode="MultiLine"></asp:textbox>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="FECHA&lt;br&gt;PLAZO">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>

<ItemTemplate>
<asp:textbox style="Z-INDEX: 0" id=txtFechaPlazo runat="server" CssClass="normaldetalle" BorderStyle="None" Width="70px" Height="24px" rel="Calendario"></asp:textbox>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="RESPONSABLE">
<HeaderStyle Wrap="False" Width="20%">
</HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn HeaderText="ANEXOS">
<HeaderStyle Width="15%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="Para&lt;br&gt;Acci&#243;n">
<HeaderStyle Width="1%">
</HeaderStyle>

<ItemTemplate>
<TABLE style="Z-INDEX: 0" id=Table5 border=0 cellSpacing=1 cellPadding=1>
<TR>
<TD>
<TABLE id=tblEnviado border=0 cellSpacing=1 cellPadding=1 align=left runat="server">
<TR>
<TD>
<asp:Image style="Z-INDEX: 0" id=Image1 runat="server" ImageUrl="../imagenes/Navegador/CorreoSend2.png" ToolTip="Nro de correo(s) enviado(s)."></asp:Image></TD>
<TD>
<asp:Label style="Z-INDEX: 0" id=LblEnviado runat="server" CssClass="ItemGrillaText">(0)</asp:Label></TD></TR></TABLE></TD></TR>
<TR>
<TD>
<asp:Image style="Z-INDEX: 0" id=btnEnviar ondblclick=EnviarCorreo(this); runat="server" Width="40px" ImageUrl="../imagenes/Navegador/btnEnviar.png" Height="40px" ToolTip="Enviar correo para tomar acción"></asp:Image></TD></TR></TABLE>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn>
<HeaderStyle Width="1%">
</HeaderStyle>

<ItemTemplate>
													<asp:image style="Z-INDEX: 0" id="imgEliminar2" onclick="EliminarACAP(this);" runat="server" ImageUrl="../imagenes/Filtro/Eliminar.gif"></asp:image>
												
</ItemTemplate>
</asp:TemplateColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
						</TABLE>
						<TABLE accessKey="tbl" id="tblCausaRaiz" border="0" cellSpacing="1" cellPadding="1" width="300">
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="DISPLAY: none" id="CellLstCausaRaiz" vAlign="top" width="100%" align="center"
						runat="server"></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%" align="center">
							<TR>
								<TD id="CellContextBusqueda" align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"><INPUT style="WIDTH: 40px; HEIGHT: 22px" id="hIdRowGrid" value="0" size="1" type="hidden"
										name="hIdRowGrid" runat="server">
									<asp:button id="btnSubir" runat="server" Text="Subir Archivo"></asp:button><INPUT style="WIDTH: 24px; HEIGHT: 22px" id="hIdRowGridACAP" value="0" size="1" type="hidden"
										name="hIdRowGridACAP" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 22px" id="hIdAccion" value="0" size="1"
										type="hidden" name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 22px" id="hNombreArchivo" size="1" type="hidden"
										name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 22px" id="hRutaHTTP" size="1" type="hidden"
										name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 22px" id="hIdAccionAnexo" value="0" size="1"
										type="hidden" name="Hidden1" runat="server">
									<TABLE style="POSITION: absolute; DISPLAY: none; LEFT: -800px" id="tblBuscar" border="0"
										cellSpacing="1" cellPadding="1" width="100%" ROWINDEX="0">
										<TR>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
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
			function ConfigurarControlesFecha(Collecion){
				var textBoxes = Ext.DomQuery.select("input[rel=" + Collecion + "]");   
				Ext.each(textBoxes, function(item, id, all){   
					var cl = new Ext.form.DateField({   
						format: 'd/m/Y',
						allowBlank : false,   
						applyTo: item   
					});
				});
			}
			ConfigurarControlesFecha('Calendario');
			UltimaFilaSeleccionada();
		</script>
		<SCRIPT language="javascript" type="text/javascript">
			// <![CDATA[
					SI.Files.stylizeAll();
			// ]]>
			
				var oFUFile = jNet.get('FUFile');
					oFUFile.addEvent("change",function(){
						var idAccion = jNet.get('hIdAccion').value;
						if(idAccion=='9'){Ext.MessageBox.alert('SAM', 'Seleccionar Registro de accion para anexar los archivos', function(btn){});return false; }
						
						var oPagina = new SIMA.Utilitario.Helper.General.Pagina();//Permite la edicion o no del registro o los registros
						if(oPagina.Request.Params[SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDESTDOGRPCR]!='2'){
							var PathNombre=jNet.get('FUFile').value;
							var arrPath =PathNombre.split(String.fromCharCode(92));
							var NombreFile = arrPath[arrPath.length-1];
							jNet.get('hNombreArchivo').value = NombreFile;
							var oDataGrid = jNet.get('gridACAP');
							var oSAMAccionAnexoBE= new EntidadesNegocio.OGI.SAMAccionAnexoBE();
							oSAMAccionAnexoBE.IdAccion = idAccion;
							oSAMAccionAnexoBE.Nombre = NombreFile;
							var IdResult =(new Controladora.OGI.CSAMAccionAnexo()).Insertar(oSAMAccionAnexoBE);
							jNet.get('hIdAccionAnexo').value = IdResult;
							
							jNet.get(oDataGrid.rows[jNet.get('hIdRowGridACAP').value].cells[5]).insert(CrearCtrlAnexo(jNet.get('hIdAccionAnexo').value,NombreFile,'BaseItemInGrid'));
							__doPostBack('btnSubir','');
						}
					});
					
				
				function CrearControlsdeBusqueda(){
					var NombreCtrl="";
					var oDataGrid = jNet.get('gridACAP');
					for(var r=1;r<=oDataGrid.rows.length-1;r++){
						//Carga los Anexos por cada archivo
						ListaAnexo(oDataGrid.rows[r]);
						var oCell4=jNet.get(oDataGrid.rows[r].cells[4]);
						ConfiguraBusqueda(r,oCell4,oCell4.attr("Nombre"));
					}
				}
				
				function ConfiguraBusqueda(r,oCellContext,TextNew){
					var NombreCtrl = "txtB" + r;
						var Ctrl = document.createElement('Input');
						Ctrl.id = NombreCtrl;
						Ctrl.className="normaldetalle";
						Ctrl.style.width = "100%";
						//Ctrl.value = ((TextNew.length==0)?oCellContext.attr("Nombre"):"");
						Ctrl.value = TextNew;
						Ctrl.Align ="left";
						oCellContext.insert(Ctrl);
					var DefParametros = "var oParamCollecionBusqueda" + r + " = new ParamCollecionBusqueda();"
						DefParametros += " var oParamBusqueda" + r + " = new ParamBusqueda();";
						DefParametros += "	oParamBusqueda" + r + ".Nombre='Nombres';";
						DefParametros += "	oParamBusqueda" + r + ".Texto='Apellidos y Nombres';";
						DefParametros += "	oParamBusqueda" + r + ".LongitudEjecucion=1;";
						DefParametros += "	oParamBusqueda" + r + ".Tipo='C';";
						DefParametros += "	oParamBusqueda" + r + ".CampoAlterno = 'NroPersonal';";
						DefParametros += "	oParamBusqueda" + r + ".LongitudEjecucion=4;";
						DefParametros += " oParamCollecionBusqueda" + r + ".Agregar(oParamBusqueda" + r + ");";

						DefParametros += "	oParamBusqueda" + r + " = new ParamBusqueda();";
						DefParametros += "	oParamBusqueda" + r + ".Nombre='idProceso';";
						DefParametros += "	oParamBusqueda" + r + ".Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarPersonal;";
						DefParametros += "	oParamBusqueda" + r + ".Tipo='Q';";
						DefParametros += " oParamCollecionBusqueda" + r + ".Agregar(oParamBusqueda" + r + ");";

						DefParametros += "(new AutoBusqueda('" + NombreCtrl + "')).Crear('/' + ApplicationPath + '/GestionFinanciera/Procesar.aspx?',oParamCollecionBusqueda" + r + ");";
						
						
						var strCSrip = "function " + NombreCtrl + "_ItemDataBound(sender,e,dr){";
						strCSrip += "  var oDatagrid = jNet.get('gridACAP');";
						strCSrip += "  var oRowNew = jNet.get(oDatagrid.rows[" + r + "]);";
						strCSrip += "  var oCell = jNet.get(oDatagrid.rows[" + r + "].cells[4]);";
						strCSrip += "  oCell.attr('value',dr['idpersonal'].toString());";
						strCSrip += "  oCell.attr('Nombre',dr['Nombres'].toString());";
						strCSrip += "  MostrarImgEnvia(oRowNew.cells[6],'block');";
						strCSrip += "  Agregar(oCell);";
						strCSrip += "}";
						
						var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
						if(oPagina.Request.Params[SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDESTDOGRPCR]!='2'){
							window.execScript(DefParametros);
							window.execScript(strCSrip);
						}
						else{
							Ctrl.disabled="disabled";
						}						
						
				}
				
				function MostrarImgEnvia(oCellEnvia,Visibilidad){
					var oTblEnvia = oCellEnvia.children[0];
					var oimgEnvia = oTblEnvia.rows[1].cells[0].children[0];
					oimgEnvia.style.display=Visibilidad;
				}
				
				CrearControlsdeBusqueda();
						
		</SCRIPT>
	</body>
</HTML>
