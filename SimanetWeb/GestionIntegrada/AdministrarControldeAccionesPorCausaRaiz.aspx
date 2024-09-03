<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministrarControldeAccionesPorCausaRaiz.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.AdministrarControldeAccionesPorCausaRaiz" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrar Control de Acciones por Causa Raiz</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Controles/DragAndDrop/MuchikDragDrop.js"></script>
		<script>
			var URLVERIFICACION = '/' + ApplicationPath + "/GestionIntegrada/AdministrarVerificacionesPorAcciones.aspx?";
			var OBJCELGRPCR;
			function CargarAccionesPorCausaRaiz(e){
				OBJCELGRPCR = e||window.event.srcElement;  
				var orow = OBJCELGRPCR.parentNode;
				//window.aler(OBJCELGRPCR);
				var objCR = jNet.get(orow.cells[1].children[0]);
				var LstIdCausaRaiz=objCR.attr("IDCAUSARAIZ");
				var CellAcciones = jNet.get('CellAcciones');
				jNet.get('hNGrpCR').value = e.parentNode.parentNode.parentNode.id;
				CellAcciones.Limpiar=function(){
					var Count=this.children.length-1;
					for(var c=0;c<=Count;c++){
						var ctrH = this.children[0];
						this.removeChild(ctrH);
					}
				}
				CellAcciones.Limpiar();
				
				var IntIdRow=1;
				var oDataTable1 = new System.Data.DataTable();
				var oDataTable2 = new System.Data.DataTable();
				oDataTable1 = (new Controladora.OGI.CSAMAccion()).ListarAccionesPorVerificar(LstIdCausaRaiz,1);
				for(var p=0;p<=oDataTable1.Rows.Items.length-1;p++){
					var dr=oDataTable1.Rows.Items[p];
					if((dr.Item('EOF')==false)&&(dr.Item('IdGrupoAccionVerificacion')!='0')){
						CellAcciones.insert(CrearCtrlGrupo(dr,IntIdRow));
						IntIdRow++;
					}
				}
				//ubicacion de los 
				
				oDataTable2 = (new Controladora.OGI.CSAMAccion()).ListarAccionesPorVerificar(LstIdCausaRaiz,2);
				for(var p=0;p<=oDataTable2.Rows.Items.length-1;p++){
					var dr=oDataTable2.Rows.Items[p];
					if((dr.Item('EOF')==false)&&(dr.Item('IdGrupoAccionVerificacion')!='0')){
						var oGrpContext = jNet.get("Grp" + dr.Item('IdGrupoAccionVerificacion'));
						jNet.get(oGrpContext.rows[0].cells[1]).insert(CrearCtrlContenedorAcciones(dr,false));
						CellAcciones.insert(oGrpContext);
						IntIdRow++;
					}
					else{
						CellAcciones.insert(CrearCtrlContenedorAcciones(dr,true));
					}
				}
				
			}
			
	
			function CrearCtrlGrupo(dr,IdRow){
				var HTMLTable = jNet.get((new SIMA.Utilitario.Helper.General.Html()).CrearTabla(1,3));
				IdObj = "Grp" + dr.Item('IdGrupoAccionVerificacion');
				HTMLTable.id=IdObj;
				HTMLTable.attr("IDGRUPOACCIONVERIFICACION",dr.Item('IdGrupoAccionVerificacion'));
				HTMLTable.attr("CONTENEDOR","on");
				HTMLTable.border=0;
				HTMLTable.rows[0].onmouseover=function(){CambiarColorPasarMouse(this, true);};
				HTMLTable.rows[0].onmouseout=function(){CambiarColorPasarMouse(this, false);};
				
				
				
				HTMLTable.rows[0].cells[0].style.cssText ="COLOR: #3300ff;TEXT-DECORATION: underline;BORDER-RIGHT: dimgray 1px solid;";
				HTMLTable.rows[0].onclick=function(){CambiarColorSeleccion(this);};
				HTMLTable.rows[0].cells[0].align="center";
				HTMLTable.rows[0].cells[0].style.cursor="hand";
				HTMLTable.rows[0].cells[0].style.width="50px";
				HTMLTable.rows[0].cells[0].innerText=IdRow;
				HTMLTable.rows[0].cells[0].onclick=function(){
						var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
						var KEYQAUTORIZA='AUTORIZA';
						//Obtener el Listado de Acciones 
						var oTBL = jNet.get(this.parentNode.parentNode.parentNode);
						var CollectAccion = oTBL.rows[0].cells[1].children;
						var LstAcciones="";
						for(var i=0;i<=CollectAccion.length-1;i++){
							CollectAccion[i].border=0;
							var objAccion = CollectAccion[i].rows[0].cells[0].children[0];
							LstAcciones +=objAccion.id.replace("Grp","") +"@";
						}
						LstAcciones  = LstAcciones.substring(0,LstAcciones.length-1);
						var IdGrpAccionVerificacion = oTBL.attr("IDGRUPOACCIONVERIFICACION");
						var URL = URLVERIFICACION + SIMA.Utilitario.Constantes.GestionIntegrada.KEYQGRPACCIONVERIFICA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdGrpAccionVerificacion
									+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
									+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQLSTACCIONES + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + LstAcciones;
						
						URL= URL + ((oPagina.Request.Params[KEYQAUTORIZA]!= undefined)? SIMA.Utilitario.Constantes.General.Caracter.signoAmperson + KEYQAUTORIZA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQAUTORIZA]:"");
						
						(new System.Ext.UI.WebControls.Windows()).Dialogo('Verificación de la Acción Tomada (Eficacia)',URL,this,800,400,CerrarDialogo);
				}	
				HTMLTable.rows[0].cells[1].style.cssText="PADDING: 5px;";
				HTMLTable.style.cssText="BORDER: dimgray 1px solid;PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px;PADDING-TOP: 5px;MARGIN-TOP: 5px;";
				HTMLTable.attr("width","100%");
				//Columna indicador de cierre del grupo de verificacion
				
				
				//alert(dr.Item('IdEstadoGrupoAV'));
				
//				var oImg = (new SIMA.Utilitario.Helper.General.Html()).CrearImagen( '/' + ApplicationPath +	"/imagenes/Navegador/" + ((dr.Item('IdEstadoGrupoAV')=='2')? "Checked.png":"UnChecked.png"));
				var oImg = (new SIMA.Utilitario.Helper.General.Html()).CrearImagen( '/' + ApplicationPath +	"/imagenes/Navegador/" + ((dr.Item('IdEstado')=='2')? "Checked.png":"UnChecked.png"));
				
				
				
				
				oImg.style.width="50px";
				oImg.style.height="60px";
				
				var oCellEstado = jNet.get(HTMLTable.rows[0].cells[2]);
				oCellEstado.align="left";
				oCellEstado.style.width="50px";
				oCellEstado.vAlign="center";
				oCellEstado.insert(oImg);
				
				
				
				return HTMLTable;
			}

			function CerrarDialogo(HandleWind){
				var oTbl = jNet.get(jNet.get('hNGrpCR').value);
				oTbl.rows[0].cells[0].onclick();
				HandleWind.close();
			}


			function CrearCtrlContenedorAcciones(dr,onDrag){
				var StyloTitulo = "COLOR: black; FONT-SIZE: 10pt; FONT-WEIGHT: bold";
				var HTMLTable = jNet.get((new SIMA.Utilitario.Helper.General.Html()).CrearTabla(1,3));
				IdObj = "Acc" + dr.Item('IdAccion');
				
				HTMLTable.attr("id",IdObj);
				HTMLTable.attr("IDGRUPOACCIONVERIFICACION",dr.Item('IdGrupoAccionVerificacion').toString());
				HTMLTable.attr("IDACCION",dr.Item('IdAccion'));
				HTMLTable.border=0;
				HTMLTable.className='BaseItemInGridUnselect';
				HTMLTable.attr("width","100%");

				var oCellCero = jNet.get(HTMLTable.rows[0].cells[0]);
				oCellCero.style.width="80%";
				oCellCero.style.height="100%";
				oCellCero.align = "left";
				oCellCero.vAlign = "top";
				
				oCellCero.insert(CrearCtrlAcciones(dr,onDrag));
				
				var oCellUno = jNet.get(HTMLTable.rows[0].cells[1]);
				oCellUno.style.width="20%";
				oCellUno.vAlign="top";
				oCellUno.align="left";
				//Carga de los Anexos
					var oDataTable = new System.Data.DataTable();
					oDataTable = (new Controladora.OGI.CSAMAccionAnexo()).ListarTodosGrilla(dr.Item('IdAccion'));
					for(var p=0;p<=oDataTable.Rows.Items.length-1;p++){
						var drAA=oDataTable.Rows.Items[p];
						if(drAA.Item('EOF')==false){
							var IdAccionAnexo = drAA.Item('IdAccionAnexo');
							var Nombre = drAA.Item('Nombre');
							//var HtmlCtrl =CrearCtrlAnexo(IdAccionAnexo,Nombre,'BaseItemInGrid');
							var HtmlCtrl =CrearCtrlAnexo(IdAccionAnexo,Nombre,'BaseItemInGridUnselect');
							oCellUno.insert(HtmlCtrl);
						}
					}
					
					//dr.Item('IdGrupoAccionVerificacion')
					
				//Establece el Boton Eliminar
				oIMG = SIMA.Utilitario.Helper.General.CrearImgEliminar();
				oIMG.style.height = '20px';
				oIMG.style.width = '20px';

				oIMG.onclick=function(){
					if(ValidaAutorizacion()==0){return;}
				
					var oTBLItem = jNet.get(this.parentNode.parentNode.parentNode.parentNode);
					var oCellContext = oTBLItem.parentNode;
						Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este los registros de verificaciones ahora?', function(btn){
											if(btn=="yes"){
												(new Controladora.OGI.CSAMAccionVerificacion()).Eliminar(oTBLItem.attr("IDACCION"),oTBLItem.attr("IDGRUPOACCIONVERIFICACION"));
												//jNet.get(oCellContext).removeChild(oTBLItem);
												
												//alert(oTBLItem.innerHTML);
												
												OBJCELGRPCR.onclick();
											}
										});					
					
				}
				var oCellDos = jNet.get(HTMLTable.rows[0].cells[2]);
				oCellDos.attr("width","10px");
				oCellDos.insert(oIMG);
				
				return HTMLTable;
			}


			function CrearCtrlAcciones(dr,onDrag){
				var StyloTitulo = "COLOR: black; FONT-SIZE: 10pt; FONT-WEIGHT: bold";
				var HTMLTable = jNet.get((new SIMA.Utilitario.Helper.General.Html()).CrearTabla(2,8));
				IdObj = "Grp" + dr.Item('IdAccion');
				HTMLTable.attr("id",IdObj);
				HTMLTable.border=0;
				HTMLTable.attr("CTR","ON");
				HTMLTable.className='BaseItemInGridGroup';
				HTMLTable.style.width="100%";
				HTMLTable.style.height="100%";
				HTMLTable.attr("IDGRUPOACCIONVERIFICACION",dr.Item('IdGrupoAccionVerificacion').toString());
				HTMLTable.attr("IDACCION",dr.Item('IdAccion').toString());
				
				//HTMLTable.rows[0].cells[0].innerText = "FOTO";
				var oCellCero=jNet.get(HTMLTable.rows[0].cells[0]);
				oCellCero.rowSpan=2;
				oCellCero.align="center";
				oCellCero.vAlign="middle";
				oCellCero.insert(CrearFoto(dr.Item('NroPersonal').toString(),onDrag));
				HTMLTable.rows[1].cells[0].style.display="none";

				HTMLTable.rows[0].cells[1].innerText = "RESPONSABLE :";
				HTMLTable.rows[0].cells[1].style.cssText =StyloTitulo;
				HTMLTable.rows[0].cells[2].innerText = dr.Item('ApellidosyNombres');
				HTMLTable.rows[0].cells[2].noWrap=true;
				
				
				HTMLTable.rows[0].cells[3].innerText = "ACCION :";
				HTMLTable.rows[0].cells[3].style.cssText =StyloTitulo;
				HTMLTable.rows[0].cells[4].innerText = dr.Item('NombreTipoAccion');
				HTMLTable.rows[0].cells[4].noWrap=true;
				
				HTMLTable.rows[0].cells[5].innerText = "PLAZO :";
				HTMLTable.rows[0].cells[5].style.cssText =StyloTitulo;
				HTMLTable.rows[0].cells[6].innerText = dr.Item('PlazoEjecucion');
				HTMLTable.rows[0].cells[6].noWrap=true;

				
				HTMLTable.rows[1].cells[1].innerText = dr.Item('Descripcion');
				HTMLTable.rows[1].cells[1].vAlign="top";
				HTMLTable.rows[1].cells[1].align="left";
				HTMLTable.rows[1].cells[1].colSpan = 6;
				HTMLTable.rows[1].cells[2].style.display="none";HTMLTable.rows[1].cells[3].style.display="none";HTMLTable.rows[1].cells[4].style.display="none";HTMLTable.rows[1].cells[5].style.display="none";HTMLTable.rows[1].cells[6].style.display="none";
				
				HTMLTable.rows[0].cells[6].style.width="80%"
				HTMLTable.rows[1].cells[1].style.height="100%"
				//Cellda para la aprobacion de la accion
				HTMLTable.rows[0].cells[7].width=50;
				HTMLTable.rows[0].cells[7].rowSpan = 2;
				HTMLTable.rows[1].cells[7].style.display="none";
				
				var chk = jNet.get(document.createElement("input"));
					chk.attr('type', 'checkbox');
					chk.attr('IDACCIONVERIFICACION',dr.Item('IdAccionVerificacion'));
					chk.onclick=function(){
						//Valida Autorizacion
						if(ValidaAutorizacion()==0){this.checked =(this.checked==this.checked);return;}
						
						var oTbl = jNet.get(this.parentNode.parentNode.parentNode.parentNode);
						var Aprobado =((this.checked==true)?2:1);
						//(new Controladora.OGI.CSAMAccionVerificacion()).ActualizaEstado(oTbl.attr('IDACCIONVERIFICACION'),Aprobado);
						(new Controladora.OGI.CSAMAccionVerificacion()).ActualizaEstado(oTbl.attr('IDGRUPOACCIONVERIFICACION'),oTbl.attr('IDACCION'),Aprobado);
						
						var otblGRPCR = jNet.get(jNet.get('hNGrpCR').value);
						var oImg = otblGRPCR.rows[0].cells[2].children[0];
						if(Aprobado==1){
							oImg.src =  '/' + ApplicationPath +	"/imagenes/Navegador/OpenRed.jpg";
						}
						else{
							var Cerrar=true;
							var ObjColl = jNet.get('CellAcciones').children;
							for(var c=0;c<=ObjColl.length-1;c++){
								var obj = ObjColl[c];
									var lstCtrl = obj.rows[0].cells[1].children;
									for(var i=0;i<=lstCtrl.length-1;i++){
										var tbl =lstCtrl[i];
										var tblIn = tbl.rows[0].cells[0].children[0];
										var chk = tblIn.rows[0].cells[7].children[0];
										if(chk.checked==false){Cerrar=false;}
									}
							}
							//
							if(Cerrar==true){
								oImg.src =  '/' + ApplicationPath +	"/imagenes/Navegador/Cerrado2.jpg";
							}
						}
						
					}
					jNet.get(HTMLTable.rows[0].cells[7]).insert(chk);
					chk.checked = ((dr.Item('IdEstado')=='1')?false:true);
					chk.style.display=((dr.Item('IdGrupoAccionVerificacion').toString()=='0')?"none":"block");
					
				return HTMLTable;
			}
			
			function CrearFoto(NroPR,onDrag){
				var HTMLTable = jNet.get((new SIMA.Utilitario.Helper.General.Html()).CrearTabla(1,1));
				HTMLTable.width=60;
				HTMLTable.height=60;
				HTMLTable.border=0;
				
				var NombreFoto ="";
				if(NroPR.toString().Equal('')==true){
					NombreFoto = "/SimaNetWeb/imagenes/spacer.gif";
				}
				else{
					NombreFoto = jNet.get('hPathFotos').value + NroPR.toString() + '.jpg';
				}
				var oImg = (new SIMA.Utilitario.Helper.General.Html()).CrearImagen(NombreFoto);
				oImg.id = NroPR;
				oImg.style.cssText = "border-radius: 60%; box-shadow: 0px 0px 15px #000; -moz-transition: all 1s; -webkit-transition: all 1s; -o-transition: all 1s;width:45px;height:45px";
				
				if(onDrag==true){
					(new Muchick.DragAndDrop()).SetearControl(oImg,"CTR");
				}
				var oCellCero = jNet.get(HTMLTable.rows[0].cells[0]);
				oCellCero.style.cssText="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/BordeIMG.gif); BACKGROUND-POSITION-X: left; BACKGROUND-REPEAT: no-repeat";
				oCellCero.align="left";
				oCellCero.vAlign="top";
				oCellCero.insert(oImg);
				return HTMLTable;
			}


			function ValidaAutorizacion(){
				var KEYQAUTORIZA='AUTORIZA';
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				if(oPagina.Request.Params[KEYQAUTORIZA]!= undefined){
					if(oPagina.Request.Params[KEYQAUTORIZA]=='0'){
						Ext.MessageBox.alert('CONTROL DE SAM', 'Ud. no cuenta con autorización de administrar esta información', function(btn){});
						return 0;
					}
				}
				return 1;
			}

			function AccionesDisponibles(){
				if(ValidaAutorizacion()==0){return;}
				
				var CellAcciones = jNet.get('CellAcciones');
					var cellContext = jNet.get('tblAcciones').rows[1].cells[0];
					cellContext.Remover=function(){
						var NroElement =this.children.length-1;
						for(var i=0;i<=NroElement;i++){
							var elementEL = this.children[0];
							this.removeChild(elementEL);
						}
					}
					cellContext.Remover();
					
					var ctrlLst = CellAcciones.children;
					
					for(var c=0;c<=ctrlLst.length-1;c++){
						var oTblAccion = jNet.get(ctrlLst[c]);
						if(oTblAccion.attr("IDGRUPOACCIONVERIFICACION")=='0'){
							var ctrlClon = jNet.get(oTblAccion.rows[0].cells[0].children[0].cloneNode(true));
							ctrlClon.border=0;
							ctrlClon.style.width="100%";
							
							/*var oCell = document.createElement("TD");
							jNet.get(ctrlClon.rows[0]).insert(oCell);
							//Agrega el control check
							var chk = jNet.get(document.createElement("input"));
							chk.attr('type', 'checkbox');
							jNet.get(ctrlClon.rows[0].cells[8]).insert(chk);
							ctrlClon.rows[0].cells[8].rowSpan=2;
							*/
							ctrlClon.rows[0].cells[7].children[0].style.display="block";
							cellContext.appendChild(ctrlClon);
							
						}
					}
					(new System.Ext.UI.WebControls.Windows()).DetalleFromEL('MiVentana','tblAcciones','Seleccionar',680,410,win_ibtn_Aceptar);
			}

			function win_ibtn_Aceptar(HandlerWind){
				var LstAcciones="";
				var oCtrl = jNet.get('tblAcciones').rows[1].cells[0].children;
				for(var i=0;i<= oCtrl.length-1;i++){
					var obj = jNet.get(oCtrl[i]);
					var chk = obj.rows[0].cells[7].children[0];
					if(chk.checked==true){
						LstAcciones += obj.attr("IDACCION") +'@';
					}
				}
				
				if(LstAcciones.length>0){
					LstAcciones = LstAcciones.substring(0,LstAcciones.length-1);
					var Url = URLVERIFICACION +  SIMA.Utilitario.Constantes.GestionIntegrada.KEYQGRPACCIONVERIFICA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + '0'
											+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
											+ SIMA.Utilitario.Constantes.GestionIntegrada.KEYQLSTACCIONES + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + LstAcciones;

					(new System.Ext.UI.WebControls.Windows()).Dialogo('LISTADO DE VERIFICACIONES',Url,this,800,400,onWindowClose);

				}
				HandlerWind.hide();
			}
			
			function onWindowClose(HandlerWind){
				HandlerWind.close();
				//Selecciona el Grupo de causa raiz seleccionado
				OBJCELGRPCR.onclick();
			}
		
			function GrabarVerificacion(e){
				var rowSelected = e.parentNode.parentNode;
				var DATA = rowSelected.getAttribute("DATA");
				var ObjName = e.id;
				
				//alert(ObjName);
				
				/*switch(ObjName){
					case "txtVerificacionV":
						alert("VERI");
						
						break;
						
				}*/
				
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
			
			
			
			function AgregarVerificacion(e){	
				var orow;
				if(e.id.toString().indexOf("txtFecha")!=-1){
					orow =jNet.get(e.parentNode.parentNode.parentNode);
					//orow =jNet.0.0.0.0.get(e.parentNode.parentNode);
				}
				else{
					orow = jNet.get(e.parentNode.parentNode);
				}				
				
				eval(orow.attr("REGBE"));
				RegistroBE.toString=function(Clear){
					var StructData="";
					if(Clear){
						this["IDVERIFICACION"]="9";
						this["MODO"]="N";
						this["VERIFICACION"]="";
						this["OBSERVACION"]=""; 
					}
		            for (var name in this) { 
						if(name!="toString"){
							StructData = StructData + name.toString() + ":'" + this[name.toString()] + "',";
		                }
                    }  
	                StructData = "var RegistroBE = {" + StructData.substring(0,StructData.length-1) + "}";
		            return StructData.toString();					
				}
				
				var otxtFecha = jNet.get(orow.cells[1].children[0].children[0]);
				//var otxtFecha = jNet.get(orow.cells[1].children[0]);
				var otxtVerificacion = jNet.get(orow.cells[2].children[0]);
				var otxtObservaciones = jNet.get(orow.cells[3].children[0]);
				var oImg = jNet.get(orow.cells[4].children[0]);

				
				if(RegistroBE.VERIFICACION.Equal(otxtVerificacion.value)
					&& RegistroBE.OBSERVACION.Equal(otxtObservaciones.value)
					&& RegistroBE.FECHA.Equal(otxtFecha.value)
					){
						return false;
				}
			
				if(orow.attr("MODO")=='N'){
					var oDataGrid = orow.parentNode;
					orow.attr("MODO","M");
					var oRowClon = jNet.get(orow.cloneNode(true));
					oDataGrid.appendChild(oRowClon);
					
					var oClontxtFecha = jNet.get(oRowClon.cells[1].children[0].children[0]);
					var ctrlRemove = oRowClon.cells[1].children[0];
					oRowClon.cells[1].removeChild(ctrlRemove);
					
					jNet.get(oRowClon.cells[1]).insert(oClontxtFecha);
					var NombreCal = "cal" + oRowClon.rowIndex;
					oClontxtFecha.id = NombreCal;
					new Ext.form.DateField({allowBlank : false, applyTo: oClontxtFecha,format:'d/m/Y'});   
					var oClontxtVerificacion = jNet.get(oRowClon.cells[2].children[0]);
					var oClontxtObservaciones = jNet.get(oRowClon.cells[3].children[0]);
					oClontxtVerificacion.value="";
					oClontxtObservaciones.value="";

					orow.cells[3].children[0].style.display="block";
					oRowClon.attr("REGBE",RegistroBE.toString(true));
				}
				
				var oSAMVerificacionBE= new EntidadesNegocio.OGI.SAMVerificacionBE();
				oSAMVerificacionBE.Fecha = otxtFecha.value;
				oSAMVerificacionBE.AccionTomada = otxtVerificacion.value;
				oSAMVerificacionBE.Observacion = otxtObservaciones.value;
				oSAMVerificacionBE.IdVerificacion = orow.attr("IDVERIFICACION");
				
				var IdVerificacion =(new Controladora.OGI.CSAMVerificacion()).Insertar(oSAMVerificacionBE);
				
				if(IdVerificacion!='-1'){
					orow.attr("IDVERIFICACION",IdVerificacion);
					oImg.style.display="block";
					
					RegistroBE.IDVERIFICACION = IdVerificacion;
					RegistroBE.MODO="M";
					RegistroBE.VERIFICACION=otxtVerificacion.value;
					RegistroBE.OBSERVACION=otxtObservaciones.value;
					RegistroBE.FECHA=otxtFecha.value;
					orow.attr("REGBE",RegistroBE.toString());
					
					var IdGrupoAccionVerificacion = jNet.get('hIdGrupoVerificacion').value;
					IdGrupoAccionVerificacion= ((IdGrupoAccionVerificacion=='0')?(new Controladora.OGI.CSAMGrupoAccionVerificacion()).Insertar():IdGrupoAccionVerificacion);
					jNet.get('hIdGrupoVerificacion').value=IdGrupoAccionVerificacion;
					
					var ArrLstAccion = jNet.get('hIdsAcciones').value.toString().split('@');
					for(var a=0;a<=ArrLstAccion.length-1;a++){
						var oSAMAccionVerificacionBE=new EntidadesNegocio.OGI.SAMAccionVerificacionBE();
							oSAMAccionVerificacionBE.IdAccion=ArrLstAccion[a];
							oSAMAccionVerificacionBE.IdVerificacion=IdVerificacion;
							oSAMAccionVerificacionBE.IdGrupoAccionVerificacion = IdGrupoAccionVerificacion;
							oSAMAccionVerificacionBE.IdEstado=1;
						(new Controladora.OGI.CSAMAccionVerificacion()).Insertar(oSAMAccionVerificacionBE);
					}
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
				oIMG.style.width="20px";
				oIMG.style.height="20px";
				
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
				
				return HTMLTable;
			}
			
			function EliminarVerificacion(e){
				if(ValidaAutorizacion()==0){return;}
				var orow = jNet.get(e.parentNode.parentNode);
				var oDataGrid = orow.parentNode;
				Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro ahora?', function(btn){
					if(btn=="yes"){
						
						(new Controladora.OGI.CSAMVerificacion()).Eliminar(orow.attr("IDVERIFICACION"));
						oDataGrid.removeChild(orow);
					}
				});
			}
			
		function DragEnd_Events(Source, Target) {
			var vTarget= FindControl(Target,"CONTENEDOR");
			var IdGrupoAccionVerificacion = vTarget.id.toString().replace("Grp","");
			var IdAccion =jNet.get(Source).attr('IDACCION');
			var oDataTable = new System.Data.DataTable();
			oDataTable = (new Controladora.OGI.CSAMVerificacion()).ListarTodos(IdGrupoAccionVerificacion);
			for(var p=0;p<=oDataTable.Rows.Items.length-1;p++){
					var dr=oDataTable.Rows.Items[p];
					if(dr.Item('EOF')==false){
						var oSAMAccionVerificacionBE=new EntidadesNegocio.OGI.SAMAccionVerificacionBE();
							oSAMAccionVerificacionBE.IdAccion=IdAccion;
							oSAMAccionVerificacionBE.IdVerificacion=dr.Item('IdVerificacion');
							oSAMAccionVerificacionBE.IdGrupoAccionVerificacion = IdGrupoAccionVerificacion;
							oSAMAccionVerificacionBE.IdEstado=1;
						(new Controladora.OGI.CSAMAccionVerificacion()).Insertar(oSAMAccionVerificacionBE);
						//Actualiza la visualizacion de las acciones segun ultimo grupo seleccionado
					}
			}
			OBJCELGRPCR.onclick();
		}

		/*Region Eventos del object DRAGDROP*/
        function DragStart_Event(Source){
	        //var oCard = $O('Card');
	       // oCard.contentEditable=false;
        }
        var ObjSourceSelected;
        function Click_Event(Source){
            if(Source.id.toString().indexOf('ctrl')>-1){
                ObjSourceSelected = Source;
            }
        }
        function Drag_Event(Source){
			//window.alert(Source.tagName);
        }
        function KeyDown_Event(e,Source){
            /*if(Perferico.Teclado.KeyCodeIs(e,Perferico.Teclado.Key.Enter)){
		        var _DATA =  (new Formulario()).Data(Source);
		        if(_DATA.TIPO!=0){
		            _DATA.TEXTO = Source.value;
		            _DATA.SetType(true);//Realiza los cambios de los atributos de l Objeto y almacena de forma permanente en la BD;
		        }
		   }*/
        }
        
        function EnviaRespuesta(){
			if(ValidaAutorizacion()==0){return;}
			
			var KEYQIDSAM='IdSAM';
			var KEYQIDSAMDESTINO='IdDestino';
			var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
			if(oPagina.Request.Params[KEYQIDSAM]!=undefined){
				Ext.MessageBox.confirm('Confirmar', 'Desea ud. enviar el correo para conocimiento de verificación realizadas  ahora?', function(btn){
					if(btn=="yes"){
						(new Controladora.OGI.CSAMNTAD()).EnviaCorreoRptVerificacion(oPagina.Request.Params[KEYQIDSAM],oPagina.Request.Params[KEYQIDSAMDESTINO]);
						Ext.MessageBox.alert('CONTROL DE SAM', 'Se envió correo informativo de las verificaciones por cada acción', function(btn){});
					}
				});								
			}
        }
        
		</script>
		<style>IMG {
	WIDTH: 80px; HEIGHT: 80px; MARGIN-RIGHT: 10px; -webkit-box-shadow: 0 0 3px #333; -moz-box-shadow: 0 0 3px #333; box-shadow: 0 0 3px #333; -moz-transform: rotate(-4deg); -webkit-transform: rotate(-4deg); transform: rotate(-4deg)
}
		</style>
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
					<TD style="HEIGHT: 22px" class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Integrada></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Control de Acciones por Causa Raíz</asp:label></TD>
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
							<TR>
								<TD style="WIDTH: 114px" class="headerDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label15" runat="server" CssClass="headerDetalle" Width="128px"
										BorderStyle="None">DESTINO:</asp:label></TD>
								<TD colSpan="5"><asp:textbox style="Z-INDEX: 0" id="txtDestino" runat="server" CssClass="normaldetalle" Width="100%"
										BorderStyle="None" BackColor="Transparent"></asp:textbox></TD>
								<TD style="WIDTH: 95px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label16" runat="server" CssClass="headerDetalle" Width="128px"
										BorderStyle="None">FECHA RESPUESTA:</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtFechaRespuesta" runat="server" CssClass="normaldetalle"
										Width="120px" BorderStyle="None" BackColor="Transparent"></asp:textbox></TD>
								<TD align="center"></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 114px" class="headerDetalle" noWrap><asp:label id="Label4" runat="server" CssClass="headerDetalle" Width="128px" BorderStyle="None">FUENTE DEL REPORTE:</asp:label></TD>
								<TD style="WIDTH: 117px"><asp:textbox id="txtTipoAuditoria" runat="server" CssClass="normaldetalle" Width="120px" BorderStyle="None"
										BackColor="Transparent"></asp:textbox></TD>
								<TD style="WIDTH: 100px" class="headerDetalle"><asp:label id="Label5" runat="server" CssClass="headerDetalle" BorderStyle="None">AUDITORIA</asp:label></TD>
								<TD style="WIDTH: 106px"><asp:textbox style="Z-INDEX: 0" id="txtAuditoria" runat="server" CssClass="normaldetalle" Width="120px"
										BorderStyle="None" BackColor="Transparent"></asp:textbox></TD>
								<TD style="WIDTH: 100px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label8" runat="server" CssClass="headerDetalle" BorderStyle="None">TIPO DE ACCIÓN</asp:label></TD>
								<TD style="WIDTH: 112px"><asp:textbox style="Z-INDEX: 0" id="txtTipoAccion" runat="server" CssClass="normaldetalle" Width="120px"
										BorderStyle="None" BackColor="Transparent"></asp:textbox></TD>
								<TD style="WIDTH: 95px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label9" runat="server" CssClass="headerDetalle" BorderStyle="None">DETECTADO EN</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtDetectadoEn" runat="server" CssClass="normaldetalle" Width="100%"
										BorderStyle="None" BackColor="Transparent"></asp:textbox></TD>
								<TD rowSpan="3" align="center"></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 114px" class="headerDetalle"><asp:label id="Label6" runat="server" CssClass="headerDetalle" BorderStyle="None">NRO REGISTRO</asp:label></TD>
								<TD style="WIDTH: 117px"><asp:textbox id="txtNroRegistro" runat="server" CssClass="normaldetalle" Width="120px" BorderStyle="None"
										BackColor="Transparent"></asp:textbox></TD>
								<TD style="WIDTH: 100px" class="headerDetalle" noWrap><asp:label id="Label7" runat="server" CssClass="headerDetalle" BorderStyle="None">FECHA EMISIÓN</asp:label></TD>
								<TD style="WIDTH: 106px"><asp:textbox id="txtFechaEmision" runat="server" CssClass="normaldetalle" Width="120px" BorderStyle="None"
										BackColor="Transparent"></asp:textbox></TD>
								<TD style="WIDTH: 100px" class="headerDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label11" runat="server" CssClass="headerDetalle" BorderStyle="None">NRO  DIAS TRANS.</asp:label></TD>
								<TD style="WIDTH: 112px"><asp:textbox style="Z-INDEX: 0" id="txtNDiasTrans" runat="server" CssClass="normaldetalle" Width="120px"
										BorderStyle="None" BackColor="Transparent"></asp:textbox></TD>
								<TD style="WIDTH: 95px" class="headerDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label12" runat="server" CssClass="headerDetalle" BorderStyle="None">FECHA CADUCA</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtFechaCaducidad" runat="server" CssClass="normaldetalle"
										Width="120px" BorderStyle="None" BackColor="Transparent"></asp:textbox></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 114px" class="headerDetalle" height="40"><asp:label style="Z-INDEX: 0" id="Label10" runat="server" CssClass="headerDetalle" BorderStyle="None"
										Height="15px">DESCRIPCIÓN DEL HALLAZGO</asp:label></TD>
								<TD height="40" vAlign="top" colSpan="7" align="left"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="None"
										BackColor="Transparent" Height="40px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 114px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label13" runat="server" CssClass="headerDetalle" BorderStyle="None"
										Height="15px">ACCIONES INMEDIATAS</asp:label></TD>
								<TD colSpan="8"><asp:textbox style="Z-INDEX: 0" id="txtAccionesInmediatas" runat="server" CssClass="normaldetalle"
										Width="100%" BorderStyle="None" BackColor="Transparent" Height="40px" TextMode="MultiLine" ReadOnly="True"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD style="HEIGHT: 26px" bgColor="#000080"><asp:label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="TituloPrincipalBlanco">•	CAUSA RAIZ (De estimarlo, puede emplearse herramientas estadísticas para identificar la causa raíz)</asp:label></TD>
							</TR>
							<TR>
								<TD style="PADDING-BOTTOM: 3px; PADDING-RIGHT: 3px; HEIGHT: 26px" id="CellLstCR" runat="server"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 26px" bgColor="#000080"><asp:label style="Z-INDEX: 0" id="Label2" runat="server" CssClass="TituloPrincipalBlanco">ACCIONES CORRECTIVAS / PREVENTIVAS</asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 26px" id="Tool" width="100%" colSpan="2" align="right"><INPUT id="btnVerificacion" onclick="AccionesDisponibles();" value="Verificación" type="button"></TD>
							</TR>
							<TR>
								<TD id="CellAcciones" colSpan="2" align="left"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="right">
						<TABLE style="DISPLAY: block" id="Table4" border="0" cellSpacing="1" cellPadding="1" align="right">
							<TR>
								<TD style="FONT-FAMILY: Arial; FONT-SIZE: 10px">ENVIAR RESPUESTA</TD>
								<TD><IMG style="Z-INDEX: 0; WIDTH: 40px; HEIGHT: 48px" id="btnEnviar" onclick="EnviaRespuesta()"
										alt="" src="..//imagenes/Navegador/btnEnviar.png" width="40" height="48"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="left"><IMG style="Z-INDEX: 0; WIDTH: 40px; HEIGHT: 39px" id="Img1" onclick="HistorialIrAtras();"
							alt="" src="../imagenes/atras.gif" width="40" height="39">&nbsp; <INPUT style="Z-INDEX: 0" id="hPathFotos" type="hidden" runat="server"><INPUT style="Z-INDEX: 0" id="hNGrpCR" type="hidden" name="Hidden1" runat="server"></TD>
				</TR>
				<TR>
					<TD style="DISPLAY: none" id="CellLstCausaRaiz" vAlign="top" width="100%" align="center"
						runat="server"></TD>
				</TR>
				<TR>
					<TD style="DISPLAY: none" vAlign="top" width="100%" align="center">
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
						<TABLE id="tblAcciones" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD style="HEIGHT: 27px" bgColor="#000080"><asp:label style="Z-INDEX: 0" id="Label14" runat="server" CssClass="TituloPrincipalBlanco">ACCIONES C/ P DISPONIBLES</asp:label></TD>
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
			function ConfigurarControlesFecha(Collecion){
				var textBoxes = Ext.DomQuery.select("input[rel=" + Collecion + "]");   
				Ext.each(textBoxes, function(item, id, all){   
					var cl = new Ext.form.DateField({   
						format: 'd-m-Y',
						allowBlank : false,   
						applyTo: item   
					});
				});
			}
			ConfigurarControlesFecha('Calendario');
			//UltimaFilaSeleccionada();
		</script>
	</body>
</HTML>
