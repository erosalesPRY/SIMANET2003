<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrar Programación Trabajadores Contratista</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="/SimaNetWeb/js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script>
				var KEYQFLAGVISITA="Visita";
				var KEYVALORTEXTO="ValTexto";
				var KEYQNROPROG = "NroProg";
				var KEYQPERIODO = "Periodo";
				var KEYQDNI ="NroDNI";
				var KEYQNRORUC ="NroRuc";
				var KEYQNOMBRETRABAJADOR="NOMTRAB";
				var URLUBICACION = '/' + ApplicationPath +  "/Personal/Visitas/ConsultarUbicacionTrabajadorVisitante.aspx?";
				var KEYQIDUSUARIOREG="idUsu";
				
				var KEYQRAZONSOCIAL ="RSocial";
				var KEYQFECHAINICIO ="FInicio";
				var KEYQFECHATERMINO ="FTermino";
				
				var Ventana;
			
				var idrow=1; 
				var MENSAJE = "Trabajador ya existe en la relación de la programación de otro Contratista\n no es posible volverlo a registrar";
				var MENSAJESOLICITUD="Desea Realizar una Solicitud para Liberacion de Trabajador?";
				
				var obody;
				var odr;
				var id =1;
				var i=1;
				var x=1;
				function txtTrabajador_ItemDataBound(sender,e,dr){
					var otxtTrabajador = document.getElementById('txtTrabajador');
					var ohVerOriginal = document.getElementById('hVerOriginal');
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					if(dr["ExisteEnProg"].toString()=="SI"){
						$O('hCodigo').value  = dr["NroDNI"].toString();
						odr = dr;
						
							Ext.MessageBox.confirm(MENSAJE, function(btn){
								if(btn=="yes"){
									if(dr["NroProgramacion"].toString()!= oPagina.Request.Params[KEYQNROPROG].toString()){	
										CrearSolicitud();
									}
									else{
									
										if(dr["Periodo"].toString()!= oPagina.Request.Params[KEYQPERIODO].toString()){
											CrearSolicitud();								
										}
										else{
											$O('txtTrabajador').value=''
											Ext.MessageBox.alert('Seguridad', 'Este Trabajador ya pertenece a esta Programación', function(btn){});
										}
									}								
								}
							});											
						
						
						/*if(confirm(MENSAJE)){
							//var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
							if(dr["NroProgramacion"].toString()!= oPagina.Request.Params[KEYQNROPROG].toString()){	
								CrearSolicitud();
							}
							else{
								if(dr["Periodo"].toString()!= oPagina.Request.Params[KEYQPERIODO].toString()){CrearSolicitud();								}
								else{window.alert("Este Trabajador ya pertenece a esta Programacion.");$O('txtTrabajador').value='';}
							}
						}*/
					}
					else{
						//para el caso que no se encuentre en la misma programacion
						/*if(dr["Restringido"].toString()=="SI"){
							window.alert("Este Trabajador ya pertenece a esta Programacion.");
							return false;
						}*/
						
						
						if(oPagina.Request.Params[KEYQFLAGVISITA]==undefined){
						
								alert(ohVerOriginal.value);
								
								if(ohVerOriginal.value=="0"){
									//Pregutar si pasaron los requisitos de examen medico y evaluacion de induccion.
									var oDataTable =(new AccesoDatos.Transacional.SeguridadInsdustrial.CCTT_InduccionEvaluacionNTAD()).ListarDisponibilidadTrabajadorEMEI(dr["NroDNI"].toString());
									var oInduccionEvaluacionBE=SIMA.Utilitario.Helper.DataRowToEntity(oDataTable);
									if(oInduccionEvaluacionBE.Disponible=='NO'){
										Ext.MessageBox.alert('EVALUACIÓN DE INDUCCIÓN', 'Registro de ficha de evaluación del trabajador no esta disponible', function(btn){});
										return ;
									}
									
									if(oInduccionEvaluacionBE.Aprobado=='NO'){
										Ext.MessageBox.alert('EVALUACIÓN DE INDUCCIÓN', 'Registro de ficha de evaluación del trabajador no esta aprobado', function(btn){});
										return;
									}
									
									/*if(oInduccionEvaluacionBE.Habilitado=='NO'){
										Ext.MessageBox.alert('EXAMEN MÉDICO', 'Registro de ficha de examen médico no esta vigente', function(btn){});
										return;
									}
									*/
									if(oInduccionEvaluacionBE.DisponibleEM=='NO'){
										Ext.MessageBox.alert('EXAMEN MÉDICO', 'Registro de ficha de examen médico no esta disponible o no paso examen médico', function(btn){});
										otxtTrabajador.value='';
										return;
									}
								}
						}
						//return;
						
						
						
						//var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
						var oCCTT_ProgramacionTrabajadoresContratistaBE = new EntidadesNegocio.Personal.CCTT_ProgramacionTrabajadoresContratistaBE();
						oCCTT_ProgramacionTrabajadoresContratistaBE.NroProgramacion = oPagina.Request.Params[KEYQNROPROG];
						oCCTT_ProgramacionTrabajadoresContratistaBE.Periodo=oPagina.Request.Params[KEYQPERIODO];
						oCCTT_ProgramacionTrabajadoresContratistaBE.NroDNI = dr["NroDNI"].toString();
						oCCTT_ProgramacionTrabajadoresContratistaBE.Flag = oPagina.Request.Params[SIMA.Utilitario.Constantes.KEYMODOPAGINA];
						var idResultado = (new Controladora.Personal.CCCTT_ProgramacionTrabajadoresContratista()).Insertar(oCCTT_ProgramacionTrabajadoresContratistaBE);
						
						if(parseInt(idResultado,10)==0){
							Ext.MessageBox.alert('Seguridad', 'Ud. No cuenta con provilegios para agregar o modificar esta información', function(btn){$O('txtTrabajador').value=''});
							
						}
						else{
							//document.location.reload();
							var  parametros= KEYQNROPROG + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQNROPROG]
											+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
											+ KEYQPERIODO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQPERIODO]
											+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
											+ KEYQDNI + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual  + dr["NroDNI"].toString()
											+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
											+ KEYQNOMBRETRABAJADOR + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual  + dr["ApellidosNombres"].toString()
											+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
											+ KEYQIDUSUARIOREG + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual  + oPagina.Request.Params[KEYQIDUSUARIOREG];
						
							
							var oDataGrid = $O('grid');
							var oRow;
							var ofila=oDataGrid.rows.length;
							
								oRow = oDataGrid.insertRow();
								var ClaseFila = (((new System.Funciones()).mod(oRow.rowIndex-1,2)==0)?"ItemGrilla":"AlternateItemGrilla");
								oRow.className=ClaseFila;
								var _Col = document.createElement("TD");_Col.innerText=oRow.rowIndex;oRow.appendChild(_Col);
								_Col = document.createElement("TD");_Col.innerText=dr["NroDNI"].toString();_Col.align="left";_Col.noWrap = true;oRow.appendChild(_Col);
								/*_Col.onclick=function(){
														HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort");
														window.location.href=URLUBICACION + parametros;
														}*/
								
								_Col = document.createElement("TD");_Col.innerText=dr["ApellidosNombres"].toString();_Col.align="left";_Col.noWrap = true;oRow.appendChild(_Col);
								//Para Garga La imagen
								
								_Col = document.createElement("TD");_Col.align="center";_Col.appendChild(CreaIMGEliminar(dr["NroDNI"].toString()));oRow.appendChild(_Col);
														
							$O('txtTrabajador').value='';
							 
						}
					}
				}
				
				function CreaIMGEliminar(NroDNI){
					var oImg = document.createElement("IMG");
					
					oImg.src='/' + ApplicationPath + '/imagenes/Filtro/Eliminar.gif';
					oImg.NroDNI=NroDNI;
					
					oImg.onclick=EliminarDetalleTrabajadorProgramacion;
					return oImg;
				}
				function CrearSolicitud(){
					if(confirm(MENSAJESOLICITUD)){
						var URLSOLICITUDTRABAJADOR = '/' + ApplicationPath + '/Personal/Contratista/SolicitudLiberacionTrabajador.aspx';
						if(Ventana==undefined){
							Ventana=(new SIMA.Utilitario.Helper.Response()).ShowDialogoOnTop(URLSOLICITUDTRABAJADOR,800,400);
						}
						window.setTimeout(AgregarFila,500);$O('txtTrabajador').value='';$O('hCodigo').value='';	
					}
				}
			
				//Agregar Filas para Solicitud 
				function AgregarFila(){
				
					obody = Ventana.frames.document.body;
					
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var oRow;
					var ClaseFila= (((new System.Funciones()).mod(idrow,2)==0)?"ItemGrilla":"AlternateItemGrilla");
					var oDataGrid = obody.all["grid"];	
					var ofila=oDataGrid.rows.length;
						var datostrabajador = oDataGrid.rows[x-1].cells[0]; 
						
						if(odr["NroDNI"].toString()== datostrabajador.NroDNI){	
							window.alert("Trabajador ya esta en solicitud");
						}
						else{
							
							oRow = oDataGrid.insertRow();
							oRow.className=ClaseFila;	
							
							var _Col = oRow.insertCell();
							_Col.innerText=idrow;
							_Col.setAttribute("Periodo",odr["Periodo"]);
							_Col.setAttribute("NroProg",odr["NroProgramacion"]);
							_Col.setAttribute("NroDNI",odr["NroDNI"]);
							_Col.setAttribute("NroProgReq",oPagina.Request.Params[KEYQNROPROG]);
							_Col.setAttribute("PeriodoReq",oPagina.Request.Params[KEYQPERIODO]);
							_Col.setAttribute("UsuarioLiberacion",odr["usuarioAprobacion"]);
							_Col.setAttribute("RazonSocial",odr["idEntidad"]);
							oRow.appendChild(_Col);
							
							
							_Col = oRow.insertCell();
							_Col.innerText=odr["NroDNI"].toString();
							_Col.align="left";
							_Col.noWrap = true;                                                       
							oRow.appendChild(_Col);
							
							
							_Col = oRow.insertCell();
							_Col.innerText=odr["ApellidosNombres"].toString();
							_Col.align="left";
							_Col.noWrap = true;
							oRow.appendChild(_Col);
							
							
							_Col = oRow.insertCell();
							_Col.innerText=odr["RazonSocial"].toString();
							_Col.align="left";
							_Col.noWrap = true;
							oRow.appendChild(_Col);
										
							idrow++;
							i++;
							x++;
						}
				
					
				}
				
				function RegistrarTrabajador(){
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					
					var URLDETALLETRABAJADOR = '/' + ApplicationPath + '/Personal/Contratista/DetalleTrabajador.aspx?' 
					+ SIMA.Utilitario.Constantes.KEYMODOPAGINA 
					+ SIMA.Utilitario.Constantes.General.Caracter.SignoIgual 
					+((oPagina.Request.Params[SIMA.Utilitario.Constantes.KEYMODOPAGINA] != SIMA.Utilitario.Enumerados.ModoPagina.C.toString())? SIMA.Utilitario.Enumerados.ModoPagina.N.toString():SIMA.Utilitario.Enumerados.ModoPagina.C.toString())
					//+ SIMA.Utilitario.Enumerados.ModoPagina.N.toString()
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYQDNI + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + $O('hCodigo').value 
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYVALORTEXTO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + $O('txtTrabajador').value 
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYQNROPROG + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQNROPROG]
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYQPERIODO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQPERIODO];
					
					(new SIMA.Utilitario.Helper.Response()).ShowDialogoNoModal(URLDETALLETRABAJADOR,610,200);
				}

				function ObtenerPathPagina(NroDNI){
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var URLDETALLETRABAJADOR = '/' + ApplicationPath + '/Personal/Contratista/DetalleProgramacionTrabajadoresContratista.aspx' 
						+ SIMA.Utilitario.Constantes.General.Caracter.signoInterrogacion
						+ KEYQNROPROG + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQNROPROG]
						+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
						+ KEYQPERIODO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQPERIODO]
						+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
						+ KEYQDNI + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual  + NroDNI
						+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
						+ KEYQNRORUC + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual +  oPagina.Request.Params[KEYQNRORUC]
						+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
						+ KEYQRAZONSOCIAL + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual +  oPagina.Request.Params[KEYQRAZONSOCIAL]
						+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
						+ KEYQFECHAINICIO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual +	oPagina.Request.Params[KEYQFECHAINICIO]
						+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
						+ KEYQFECHATERMINO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQFECHATERMINO]
						+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson;
						return URLDETALLETRABAJADOR;
				}
				
				function ModificarDetalleTrabajadorProgramacion(NroDNI){
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var strPath = ObtenerPathPagina(NroDNI);
					strPath = strPath  + SIMA.Utilitario.Constantes.KEYMODOPAGINA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + SIMA.Utilitario.Enumerados.ModoPagina.M.toString();
					if(oPagina.Request.Params[SIMA.Utilitario.Constantes.KEYMODOPAGINA]!= SIMA.Utilitario.Enumerados.ModoPagina.C.toString()){
						(new SIMA.Utilitario.Helper.Response()).ShowDialogoNoModal(strPath ,550,230);
					}
				}
				function CrearImg(){
					if(document.body.tag == "remoto"){
						var oDataGrid = $O('grid');
						var oRow;
						oRow = oDataGrid.insertRow();
						
						var ClaseFila = (((new System.Funciones()).mod(oRow.rowIndex-1,2)==0)?"ItemGrilla":"AlternateItemGrilla");
						oRow.className=ClaseFila;
						var _Col = document.createElement("TD");_Col.innerText=oRow.rowIndex;oRow.appendChild(_Col);
						_Col = document.createElement("TD");_Col.innerText=document.body.DNI;_Col.align="left";_Col.noWrap = true;oRow.appendChild(_Col);
						_Col = document.createElement("TD");_Col.innerText=document.body.ApellidosNombres;_Col.align="left";_Col.noWrap = true;oRow.appendChild(_Col);
						//Para Garga La imagen
						_Col = document.createElement("TD");_Col.align="center";_Col.appendChild(CreaIMGEliminar(document.body.DNI));oRow.appendChild(_Col);
					
					}
					document.body.tag ="local";		
				}
				
				function EliminarDetalleTrabajadorProgramacion(NroDNI){
					var oimg;
					if(NroDNI==undefined){
						oimg = window.event.srcElement;
						NroDNI=oimg.NroDNI;
											
					}
					
					try{		
						oimg = window.event.srcElement;
						
						if(oimg.tagName!='IMG'){
							window.alert(oimg.tag);
							oimg= window.event.srcElement.oimg;
							NroDNI = oimg.tag;
						}
					}
					catch(error){
						
					}
					if(oimg.NroDNI!=undefined){
						NroDNI = oimg.NroDNI;
							
					}
					var ofila = oimg.parentElement.parentElement;
					
					var strPath = ObtenerPathPagina(NroDNI);
					strPath = strPath  + SIMA.Utilitario.Constantes.KEYMODOPAGINA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + SIMA.Utilitario.Enumerados.ModoPagina.E.toString()
							+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson 
							+ SIMA.Utilitario.Constantes.KEYPOSICION + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual +ofila.rowIndex;
					(new SIMA.Utilitario.Helper.Response()).ShowDialogoNoModal(strPath,550,230);
				}
				
				
				/*function OnKey(){
				 	if(event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.keyInsert){RegistrarTrabajador();}
				}*/
				function Aprobar()
				{
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var URLDETALLETRABAJADOR = '/' + ApplicationPath + '/Personal/Visitas/Proceso.aspx?'
					var KEYQACTUALIZARESTADOPROGRAMACION=1;
					var KEYQPROCESO="idProceso";
					var parametros= KEYQNROPROG + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQNROPROG]
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYQPERIODO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQPERIODO]
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYQPROCESO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + SIMA.Utilitario.Constantes.General.ProcesoCallBack.ActualizarEstadodeAprobacionProgramacion;
					
					(new SIMA.Utilitario.Helper.Response()).ShowDialogoNoModal(URLDETALLETRABAJADOR+parametros ,550,230);
					
				}
		</script>
		<SCRIPT>
			function handlepaste (elem, e) {
				var savedcontent = elem.innerHTML;
			    
			    
				if (e && e.clipboardData && e.clipboardData.getData) {// Webkit - get data from clipboard, put into editdiv, cleanup, then cancel event
					if (/text\/html/.test(e.clipboardData.types)) {
						elem.innerHTML = e.clipboardData.getData('text/html');
					}
					else if (/text\/plain/.test(e.clipboardData.types)) {
						elem.innerHTML = e.clipboardData.getData('text/plain');
					}
					else {
						elem.innerHTML = "";
					}
					waitforpastedata(elem, savedcontent);
					if (e.preventDefault) {
							e.stopPropagation();
							e.preventDefault();
					}
					return false;
				}
				else {// Everything else - empty editdiv and allow browser to paste content into it, then cleanup
					elem.innerHTML = "";
					waitforpastedata(elem, savedcontent);
					return true;
				}
			}

			function waitforpastedata (elem, savedcontent) {
				if (elem.childNodes && elem.childNodes.length > 0) {
					processpaste(elem, savedcontent);
				}
				else {
					that = {
						e: elem,
						s: savedcontent
					}
					that.callself = function () {
						waitforpastedata(that.e, that.s)
					}
					setTimeout(that.callself,20);
				}
			}

			function processpaste (elem, savedcontent) {
				var CellContext=document.getElementById("cellPaste");
				pasteddata = elem.innerHTML;
				elem.innerHTML = 'Pegar aqui la lista de trabajadores';
				CellContext.innerHTML = pasteddata;
				
				//alert(pasteddata);
				var tblCopiado;
				if(CellContext.childNodes.length>1){
					tblCopiado=CellContext.children[1];	
				}
				else{
					if(pasteddata.substring(0,2)=="<P"){
						tblCopiado=CellContext.children[0].children[0];	
					}
					else{
						tblCopiado=CellContext.children[0];	
					}
				}
				tblCopiado.border=2;
					if(tblCopiado.tagName.toString().toUpperCase()=="TABLE"){
							var rowClone =  document.createElement('tr')
							for(var c=0;c<=tblCopiado.rows[0].cells.length-1;c++){
								var oCell= document.createElement('td');
								oCell.innerText ="Col (" + c + ")";
								oCell.className='HeaderDetalle';
								rowClone.appendChild(oCell)
							}
							var tbd=tblCopiado.getElementsByTagName("tbody")[0];
							tbd.insertBefore(rowClone, tbd.firstChild);
							tblCopiado.appendChild(tbd);
					}				
				
				
				document.getElementById("ibtnFormatear").style.display="block";
				(new System.Ext.UI.WebControls.Windows()).DetalleFromEL('ValidaForm','tblFormato','valdar formato de ingreso',window.screen.width-420,550,AceptarFormato);
			}

			
			
			/*datos de la tabla */
			
			function Establecerformato(){
				var NroCellDNI = document.getElementById("txtNroColDNI").value;
				var NroCellsAPM = document.getElementById("txtNroColAPNOM").value;
				var CellContext=document.getElementById("cellPaste");
				var pasteddata = CellContext.innerHTML;
				//alert(pasteddata);
				var tblCopiado;
				if(CellContext.childNodes.length>1){
					tblCopiado=CellContext.children[1];	
				}
				else{
						if(pasteddata.substring(0,2)=="<P"){
							tblCopiado=CellContext.children[0].children[0];	
						}
						else{
							tblCopiado=CellContext.children[0];	
						}
				}
								
				if(tblCopiado.tagName.toString().toUpperCase()=="TABLE"){
						var NroFilas = tblCopiado.rows.length;
						var NroCols=tblCopiado.rows[0].cells.length;
						
						var tbl = (new SIMA.Utilitario.Helper.General.Html()).CrearTabla(NroFilas+1,3);
						tbl.id="tblListado";
						var CellCero= tbl.rows[0].cells[0];CellUno= tbl.rows[0].cells[1];CellTres= tbl.rows[0].cells[2];
						CellCero.innerText="NRO D.N.I";
						CellCero.className='HeaderDetalle';

						CellUno.innerText="APELLIDOS Y NOMBRES";
						CellUno.className='HeaderDetalle';

						CellTres.innerText="...";
						CellTres.className='HeaderDetalle';

						var ArrNrosCells = NroCellsAPM.split(',');
						var tBodySrc =tblCopiado.getElementsByTagName("tbody")[0];
						for(var f=1;f<=tblCopiado.rows.length-1;f++){
							tbl.rows[f].cells[0].innerText = tBodySrc.rows[f].cells[NroCellDNI].innerText;
							var strAPM="";
							for(var a=0;a<=ArrNrosCells.length-1;a++){
								strAPM= strAPM + tBodySrc.rows[f].cells[ArrNrosCells[a]].innerText + " " ;
							}
							tbl.rows[f].cells[1].innerText =strAPM;
							/*Crear control de verificacion*/
							var checkbox = document.createElement('input');
								checkbox.type = "checkbox";
								checkbox.name = "name";
								checkbox.value = "value";
								checkbox.checked=true;
								checkbox.id = "id" + f;
								tbl.rows[f].cells[2].appendChild(checkbox);
							
						}
						/*Remueve y oculta el boton de formato*/
						document.getElementById("cellPaste").removeChild(tblCopiado);
						document.getElementById("ibtnFormatear").style.display="none";
						document.getElementById("cellPaste").appendChild(tbl);
				}				
			}
			
			
			function AceptarFormato(){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var otblFormato=document.getElementById("tblListado");
				if(otblFormato!=undefined){
					for(var f=1;f<=otblFormato.rows.length-1;f++){
						var oCCTT_TrabajadorBE = new EntidadesNegocio.Personal.CCTT_TrabajadorBE();
						oCCTT_TrabajadorBE.NroDNI=otblFormato.rows[f].cells[0].innerText;
						oCCTT_TrabajadorBE.ApellidosyNombres=otblFormato.rows[f].cells[1].innerText;;
						oCCTT_TrabajadorBE.IdNacionalidad=1;
						oCCTT_TrabajadorBE.Periodo=oPagina.Request.Params[KEYQPERIODO].toString();
						oCCTT_TrabajadorBE.NroProgr=oPagina.Request.Params[KEYQNROPROG].toString();

						(new Controladora.Personal.CCCTT_Trabajador()).Insertar(oCCTT_TrabajadorBE);
						document.location.reload();
					}
				}
			}
			
			
			
		</SCRIPT>
	</HEAD>
	<body onkeypress="if(event.keyCode==13)return false;" onclick="CrearImg();" onunload="SubirHistorial();"
		onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0"
		tag="local">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión Seguridad Industrialnal ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> > Administración Trabajadores SCTR Contratista></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="780">
							<TR>
								<TD bgColor="#000080" align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"> DATOS DEL SCTR - CONTRATISTAS</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE style="HEIGHT: 55px" id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%"
										align="left">
										<TR class="AlternateItemDetalle">
											<TD style="WIDTH: 77px" class="HeaderDetalle"><asp:label id="Label1" runat="server">Nro R.U.C:</asp:label></TD>
											<TD style="WIDTH: 123px"><asp:label id="lblNroRuc" runat="server">Label</asp:label></TD>
											<TD style="WIDTH: 116px" class="HeaderDetalle"><asp:label id="Label2" runat="server">RAZÓN SOCIAL:</asp:label></TD>
											<TD><asp:label id="lblRazonSocial" runat="server">Label</asp:label></TD>
										</TR>
										<TR class="ItemDetalle">
											<TD style="WIDTH: 77px" class="HeaderDetalle"><asp:label id="Label3" runat="server">FECHA INICIO:</asp:label></TD>
											<TD style="WIDTH: 123px"><asp:label id="lblFechaInicio" runat="server">Label</asp:label></TD>
											<TD style="WIDTH: 116px" class="HeaderDetalle"><asp:label id="Label4" runat="server">FECHA TÉRMINO:</asp:label></TD>
											<TD><asp:label id="lblFechaTermino" runat="server">Label</asp:label></TD>
										</TR>
										<TR class="AlternateItemDetalle">
											<TD style="WIDTH: 77px" class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label7" runat="server" ToolTip="Nro SCTR">Nro SCTR:</asp:label></TD>
											<TD style="WIDTH: 123px"><asp:label style="Z-INDEX: 0" id="lblHoraIni" runat="server">Label</asp:label></TD>
											<TD style="WIDTH: 116px" class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label21" runat="server" ToolTip="ASEGURADORA"> ASEGURADORA:</asp:label></TD>
											<TD><asp:label style="Z-INDEX: 0" id="lblHoraTolerancia" runat="server">Label</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD bgColor="#000080" align="center"><asp:label id="Label5" runat="server" CssClass="TituloPrincipalBlanco">LISTA DE TRABAJADORES ASOCIADOS A UN SCTR</asp:label></TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left">
										<TR>
											<TD class="HeaderDetalle" noWrap><asp:label id="Label6" runat="server"> APELLIDOS Y NOMBRES:</asp:label></TD>
											<TD width="100%"><asp:textbox id="txtTrabajador" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
											<TD><IMG id="Img1" title="Crear un nuevo trabajdor" onclick="RegistrarTrabajador();" alt=""
													src="../../imagenes/BtPU_Mas.gif" runat="server"></TD>
										</TR>
										<TR>
											<TD style="PADDING-BOTTOM: 5px; DISPLAY: none" height="30" colSpan="3">
												<DIV id="div" class="AreaInDrag" contentEditable="true" onpaste="handlepaste(this, event)">Pegar 
													aquí la lista de trabajadores</DIV>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 10px" bgColor="#f0f0f0" align="center"><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" CssClass="HeaderGrilla" Width="100%"
										Height="1px" AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False">
										<PagerStyle Visible="False" HorizontalAlign="Center" CssClass="PagerGrilla"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroDni" SortExpression="NroDni" HeaderText="NRO DOC..">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Nombres" SortExpression="Nombres" HeaderText="APELLIDOS Y NOMBRES">
												<HeaderStyle Width="60%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemTemplate>
													<IMG style="Z-INDEX: 0" id="imgEliminar" src="../../imagenes/Filtro/Eliminar.gif" runat="server">
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False" DESIGNTIMEDRAGDROP="55"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="4" align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
										runat="server"><INPUT style="WIDTH: 16px; HEIGHT: 16px" id="hGridPagina" value="0" size="1" type="hidden"
										name="hGridPagina" runat="server"><INPUT style="WIDTH: 16px; HEIGHT: 16px" id="hGridPaginaSort" size="1" type="hidden" name="hGridPagina"
										runat="server"><INPUT style="WIDTH: 16px; HEIGHT: 16px" id="hCodigo" size="1" type="hidden" name="hCodigo"
										runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 16px" id="hFechaIniProg" size="1" type="hidden"
										runat="server" NAME="hFechaIniProg">&nbsp; <INPUT style="WIDTH: 16px; HEIGHT: 24px" id="hVerOriginal" value="0" size="1" type="hidden"
										runat="server" NAME="hVerOriginal">
								</TD>
							</TR>
						</TABLE>
						<IMG style="Z-INDEX: 0; DISPLAY: none" id="ibtnAprobar" onclick="Aprobar();HistorialIrAtras();"
							alt="" align="middle" src="../../imagenes/Aceptar.GIF" runat="server">&nbsp;
					</TD>
				</TR>
				<TR>
					<TD style="DISPLAY: none" align="center">
						<TABLE style="Z-INDEX: 0" id="tblFormato" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD><asp:label style="Z-INDEX: 0" id="Label8" runat="server">PARAMETROS DE CONFIGURACION:</asp:label></TD>
							</TR>
							<TR>
								<TD>
									<TABLE style="HEIGHT: 148px" id="Table4" border="0" cellSpacing="1" cellPadding="1" width="100%">
										<TR>
											<TD style="WIDTH: 128px" class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label11" runat="server">CAMPO:</asp:label></TD>
											<TD class="HeaderDetalle" width="100%" colSpan="2" align="center"><asp:label style="Z-INDEX: 0" id="Label12" runat="server" Height="15px">NRO COLUMNA DE REFERENCIA:</asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 128px" class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label9" runat="server">D.N.I:</asp:label></TD>
											<TD style="WIDTH: 81px" colSpan="2"><asp:textbox id="txtNroColDNI" runat="server" CssClass="normaldetalle" Width="32px">1</asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 128px" class="HeaderDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label10" runat="server">APELLIDOS Y NOMBRES:</asp:label></TD>
											<TD style="WIDTH: 81px"><asp:textbox style="Z-INDEX: 0" id="txtNroColAPNOM" runat="server" CssClass="normaldetalle" Width="80px"
													Height="25px">2</asp:textbox></TD>
											<TD style="WIDTH: 100%"><IMG id="ibtnFormatear" onclick="Establecerformato();" alt="" src="../../imagenes/Navegador/btnFormatear.jpg"></TD>
										</TR>
										<TR>
											<TD class="AreaInDrag" width="100%" colSpan="3">Si los apellidos y nombres se 
												encuentran en&nbsp;más de una&nbsp;columnas ingresar el nro de las columnas en 
												el orden que se desea unificar su contenido separados por una coma(;)</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 128px"></TD>
											<TD style="WIDTH: 81px"></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD id="cellPaste" class="AreaInDrag"></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>		
		<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<SCRIPT>
						var  FECHAINICIOPROG="FechaIniProg"
						var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
						var oParamCollecionBusqueda = new ParamCollecionBusqueda();
						var oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="ApellidosNombres";
							oParamBusqueda.Texto="Trabajador";
							oParamBusqueda.LongitudEjecucion=2;
							oParamBusqueda.CampoAlterno="NroDNI";
							oParamBusqueda.Tipo="C";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre=SIMA.Utilitario.Constantes.KEYMODOPAGINA;
							oParamBusqueda.Valor= oPagina.Request.Params[SIMA.Utilitario.Constantes.KEYMODOPAGINA];
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="idProceso";
							oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarTrabajador;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						
							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre=FECHAINICIOPROG;
							oParamBusqueda.Valor=$O('hFechaIniProg').value;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

						(new AutoBusqueda('txtTrabajador')).Crear( '/' + ApplicationPath + '/Personal/Procesar.aspx?',oParamCollecionBusqueda);
						
		</SCRIPT>
	</body>
</HTML>
