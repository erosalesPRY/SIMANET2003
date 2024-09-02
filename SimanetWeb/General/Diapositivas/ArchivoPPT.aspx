<%@ Page language="c#" Codebehind="ArchivoPPT.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Diapositivas.ArchivoPPT" %>
<!DOCTYPE html>
<HTML>
	<HEAD id="Head">
		<title>Diapositiva</title>
		<meta charset="utf-8">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<LINK rel="stylesheet" type="text/css" href="/SIMANETCOMPLEMENTOS/JQuery/easyui/easyui.css">
		<script type="text/javascript" src="/SIMANETCOMPLEMENTOS/JQuery/easyui/jquery.min.js"></script>
		<script type="text/javascript" src="/SIMANETCOMPLEMENTOS/JQuery/easyui/jquery.easyui.min.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/JQuery/js/JQueryPlugInSIMA.js"></script>
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<style>.Header { BACKGROUND-IMAGE: url(/simanetweb/imagenes/header.jpg); Z-INDEX: 2; POSITION: fixed; TEXT-ALIGN: center; FILTER: Alpha(opacity=100, finishopacity=85, style=1,startx=0, starty=10, finishx=0, finishy=50); PADDING-BOTTOM: 0px; BACKGROUND-COLOR: #e8f6f7; PADDING-LEFT: 0px; WIDTH: 100%; PADDING-RIGHT: 0px; DISPLAY: block; BACKGROUND-REPEAT: no-repeat; HEIGHT: 65px; TOP: 0px; PADDING-TOP: 0px; LEFT: 0px }
	.Fother { Z-INDEX: 4; POSITION: fixed; WIDTH: 100%; BOTTOM: 0px; DISPLAY: block; BACKGROUND: white; HEIGHT: 65px; LEFT: 0px }
	.Fother TABLEs { MARGIN-TOP: 0px; WIDTH: 85% }
	.Diapositiva { MARGIN-TOP: 65px; WIDTH: 98%; BOTTOM: 60px; FLOAT: left; HEIGHT: 100%; MARGIN-LEFT: 10px; text-shadow: 1px 1px 2px #f0f0f0 }
		</style>
		<style>.Pag { BACKGROUND-IMAGE: url(/SimanetWeb/imagenes/PagNro.png); WIDTH: 23px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 23px; FONT-SIZE: 11px; PADDING-TOP: 3px }
	.PagSelec { BACKGROUND-IMAGE: url(/SimanetWeb/imagenes/PagSelect.png); WIDTH: 24px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 23px; COLOR: black; FONT-SIZE: 11px; FONT-WEIGHT: bold; PADDING-TOP: 3px }
	.PanelGRP { BORDER-BOTTOM: #99bbe8 1px dotted; BORDER-LEFT: #99bbe8 1px dotted; WHITE-SPACE: nowrap; HEIGHT: 50px; OVERFLOW: auto; BORDER-TOP: #99bbe8 1px dotted; CURSOR: default; BORDER-RIGHT: #99bbe8 1px dotted }
	.PanelLeft { BORDER-LEFT: #99bbe8 1px dotted; WHITE-SPACE: nowrap; HEIGHT: 50px; OVERFLOW: auto; CURSOR: default }
		</style>
		<style>
	.ItemPPT { BORDER-BOTTOM: #99bbe8 1px dotted; BORDER-LEFT: #99bbe8 1px dotted; FONT: 11px tahoma,arial,sans-serif; BACKGROUND: #dfe8f6; HEIGHT: 15px; COLOR: #15428b; BORDER-TOP: #99bbe8 1px dotted; CURSOR: default; BORDER-RIGHT: #99bbe8 1px dotted }
	.ItemPPTSelecc { BORDER-BOTTOM: blue 1px dotted; BORDER-LEFT: blue 1px dotted; FONT: 11px tahoma,arial,sans-serif; BACKGROUND: #ffcc66; HEIGHT: 15px; COLOR: #15428b; BORDER-TOP: blue 1px dotted; CURSOR: default; BORDER-RIGHT: blue 1px dotted }
		</style>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<div class="Header"></div>
		<div class="Fother">
			<table border="0" width="100%" align="left">
				<tr>
					<td width="5%">&nbsp;<IMG id="ibtnAtras" alt="" src="/SimanetWeb/imagenes/ibtnAtras.gif" onclick="HistorialIrAtras();">
					</td>
					<td class="PanelLeft">
						<table border="0" width="100%" align="left">
							<tr>
								<td class="paginations" id="ToolPag" width="100%" align="left" runat="server" vAlign="bottom">
								</td>
							</tr>
							<tr>
								<td id="Paginas" class="pagination" width="80%" align="left" vAlign="top">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</div>
		<asp:placeholder id="phContexto" runat="server"></asp:placeholder>
		<asp:placeholder id="phControls" runat="server"></asp:placeholder>
		<INPUT id="hPPTActive" size="1" type="hidden" runat="server" NAME="hPPTActive"><INPUT style="Z-INDEX: 0" id="hNroGrupoyPag" size="1" type="hidden" name="hNroPag" runat="server">
		<INPUT id="hLibJs" type="hidden" runat="server"> 
		<!--<SCRIPT language="javascript" src="../../js/JQuery/js/jquery.min.js"></SCRIPT>-->
		<!--<script type="text/javascript" src="/SIMANETCOMPLEMENTOS/JQuery/JQueryDiapositiva/jquery.easing.1.3.js"></script>-->
		<!--<SCRIPT language="javascript" src="../../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>-->
		<script type="text/javascript">
			/*-------------------------------------------------------------------------------------------------------------------------------------------*/
			/*Registrar Js In Html*/
			var PathFile = Caracter.Oblicua.toString() + ApplicationPath + Caracter.Oblicua.toString() + jNet.get('hLibJs').value;
			include(PathFile,{dom:false});
			/*-------------------------------------------------------------------------------------------------------------------------------------------*/
			var KEYQIDPRESENTACION="idPresent";
			var KEYQIDOBJETO="IdObjeto";
			
			function Resultado(Estado){
				return null;
			}
		
            function ActivarCarga(){
				$("[TIPOCRTL]").each(function(i,e){
					var Id = $(e)[0].id;
					var oContext = $("#"+Id);
					if((oContext.attr("TIPOCRTL")=='5')&&(oContext.attr("INITLOAD")=='1')){
						oContext.load(snPoint.ElaboraUrl(oContext.attr("URL")));
						oContext.attr("CARGADO","1");
					}																	
				});
            }
            
            window.setTimeout(ActivarCarga,1000);
        
        
        
			var snPoint= new Object();
			snPoint.ColletionsPPT="";
			snPoint.ElaboraUrl=function(WebFormPath){
				var URLLISTAUSUARIO =  SIMA.Utilitario.Helper.General.ObtenerPathApp()+ WebFormPath;
					URLLISTAUSUARIO = URLLISTAUSUARIO.Replace(' ','[s]');
				return URLLISTAUSUARIO;
			}
			snPoint.PreLoading=function(NomCtrl){
				var oImg = jNet.get(new SIMA.Utilitario.Helper.General.CrearImg(SIMA.Utilitario.Helper.General.ObtenerPathApp() + '/imagenes/Tabs/cargando.gif'));
				oImg.css("width","60px");
				oImg.css("height","60px");
				oImg.css("align","center");
				oImg.css("Valign","center");
				jNet.get(NomCtrl).insert(oImg);
			}
			snPoint.ActivarPPT=function(e,NomCtrlSecc){
				var NroPagSelecc=$.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,snPoint.Grupo.NombreGrupoSelec);
				if(NroPagSelecc!=null){
					$("#" + NroPagSelecc).attr("class","ItemPPT");
				}
				
				if(e!=null){
					$.SaveClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,snPoint.Grupo.NombreGrupoSelec,e.id);
					$(e).attr("class","ItemPPTSelecc")
				};
				
				if((snPoint.ColletionsPPT!=undefined)&&(snPoint.ColletionsPPT.length>0)){
															$.each(snPoint.ColletionsPPT, function(i, e){
																								var NomObjPPT = "Obj"+e;
																								var obj = $("#"+NomObjPPT);
																								var Encotrado = NomCtrlSecc.toString().Equal(NomObjPPT);
																								obj.css("display",((Encotrado)?"block":"none"));	
																								if(Encotrado){
																									//Carga la pagina asociada a la PPT
																									 obj.children("[TIPOCRTL]").each(function(e,oChild){
																												var objCurrent=$(oChild);
																												if((objCurrent.attr("TIPOCRTL")=='5')&&(objCurrent.attr("CARGADO")=="0")){
																													/*objCurrent.load(snPoint.ElaboraUrl(objCurrent.attr("URL")));
																													oChild.setAttribute("CARGADO","1");*/
																													var urlLoad=snPoint.ElaboraUrl(objCurrent.attr("URL"));
																													var NomDiapositiva="#" + oChild.id;
																													snPoint.PreLoading(oChild.id);//Imagen de precarga
																													
																													$(NomDiapositiva).load(urlLoad, function(response, status, xhr) {
																																						if(status == "error") {
																																							var msg = "Sorry but there was an error: ";
																																							$(NomDiapositiva).html( msg + xhr.status + " " + xhr.statusText );
																																						}
																																						else if(status =="success"){
																																							alert(status);
																																						}
																																					}
																																			);
																													oChild.setAttribute("CARGADO","1");
																												}
																											});
																									//Guarda la diapositiva activa
																									$.SaveClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,snPoint.Grupo.NombreGrupoSelec+"D",NomObjPPT);
																									
																									//Ubica la posicion a 0 de la diapositiva a mostrar
																									$("html, body").animate({ scrollTop: 0 }, "slow");
																									obj.fadeIn(1000, function() {var s='';/*alert(this.id);*/});
																								}																						
																							}
																						);
														}		
			}
			
			snPoint.Grupo=new Object();
			snPoint.Grupo.Crear=function(){
				
			}
			
			snPoint.Grupo.LoadPPts=function(oBasedef){
				/*Obtiene informacion del tabs seleccionado*/
				var oGrupoBE = new GrupoBE();
					oGrupoBE = ((oBasedef==null)?this.Tag:oBasedef);
					//Inicia la carga de la paginación
					snPoint.Grupo.LoadPaginacion(oGrupoBE.IdGrupo);
					
				var URLPresentacion=SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Diapositivas/PPTListarPaginacion.aspx?";
				var Parametros = KEYQIDPRESENTACION + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + Page.Request.Params[KEYQIDPRESENTACION]
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQIDOBJETO  +  SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + oGrupoBE.IdObjeto;
																/*+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ oGrupoBE.ParamGeneral; 			*/
				
				//$("#Paginas").load(URLPresentacion+Parametros);	
				$("#Paginas").load(URLPresentacion+Parametros, function(response, status, xhr) {
																		if(status == "error") {
																			var msg = "Sorry but there was an error: ";
																			$( "#Paginas" ).html( msg + xhr.status + " " + xhr.statusText );
																		}
																		else if(status =="success"){
																			//alert(URLPresentacion);
																		}
																	});


				
				
			}
			
			
			snPoint.OcultarAlls=function(){//Oculta todas las ppts activas
					$("[TIPOCRTL]").each(function(i,e){
														var obj = $(e);
														if(obj.attr("TIPOCRTL")=="2"){
															var idObjPPT = obj[0].id;
															obj.css("display","none");	
															//obj.fadeOut();
														}
													});
			}
			snPoint.Grupo.NombreGrupoSelec = "";
			snPoint.Grupo.LoadPaginacion=function(IdGrupo){
				/*Oculta Todas las Diapositivas*/
				snPoint.OcultarAlls();
				//Crea la nueva colleccion de dispositivas segun el grupo
				var NomCtrGrp = 'GrpH'+IdGrupo;
				snPoint.Grupo.NombreGrupoSelec =NomCtrGrp;
				snPoint.ColletionsPPT= $('#'+NomCtrGrp).val().split(";");
			}
			
            
        function GrupoBE(IDGRUPO,NOMBRE,IDOBJETO,PARAMGENERAL){
			this.IdGrupo=IDGRUPO;
			this.Nombre=NOMBRE;
			this.IdObjeto=IDOBJETO;
			this.ParamGeneral=PARAMGENERAL;
        }
        
        //
        
        var oTab;
        var oGrupoDefaultBE=null;
		function CargarFormato(){
			var IdGrupoDefault=0;
			
			
			var oDataTable = (new Controladora.General.CDispositivaGrupo()).Listar(Page.Request.Params[KEYQIDPRESENTACION]);
			
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					try{
						var PathApp = SIMA.Utilitario.Helper.General.ObtenerPathApp();
						var oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip(document.all["ToolPag"]);
						oTabStrip.PathImagen=PathApp + "/Imagenes/Tabs/";
						oTabStrip.TipoInterfaz = SIMA.Utilitario.Helper.General.Tabs.TipoInterfaz.SoloParaParametros;
							for(f=0;f<=oDataTable.Rows.Items.length-1;f++){
								var oDataRow = new System.Data.DataRow();
									oDataRow =oDataTable.Rows.Items[f];
									if(oDataRow.Item("EOF")==false){
										var oGrupoBE=new GrupoBE(oDataRow.Item("IdGrupo"),oDataRow.Item("Descripcion"),oDataRow.Item("IdObjeto"),oDataRow.Item("ParamGeneral"));
										
										//if(f==0){IdGrupoDefault=oDataRow.Item("IdGrupo");}
										var oTab = new SIMA.Utilitario.Helper.General.Tab();
										var strTitulo=oDataRow.Item("Descripcion");
										oTab.Texto = strTitulo;
										oTab.ToolTips = "";
										oTab.Tag = oGrupoBE;
										oTab.EventHandle=snPoint.Grupo.LoadPPts;
										oTabStrip.Tabs.Adicionar(oTab);
										//Establece por default
										if(f==0){oGrupoDefaultBE=oGrupoBE;}
									}
							}
						
						oTabStrip.RepintarTabs();
						oTabStrip.Tabs.Tab(0).Click();
						snPoint.Grupo.LoadPPts(oGrupoDefaultBE);//AL momento de Cargar por defecto
						//window.setTimeout(function(){oTabStrip.Tabs.Tab(0).Click();},200);
					}
					catch(error){
						alert(error);
					}			
				//Inicia la seleccion del tab
				//snPoint.Grupo.LoadPaginacion(IdGrupoDefault);
			}
			CargarFormato();            
            
						            
            
		</script>
	</body>
</HTML>
