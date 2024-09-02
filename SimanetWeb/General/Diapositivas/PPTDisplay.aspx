<%@ Page language="c#" Codebehind="PPTDisplay.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Diapositivas.PPTDisplay" %>
<!DOCTYPE html>
<HTML>
	<HEAD>
		<title>Diapositiva</title>
		<meta charset="utf-8">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<LINK rel="stylesheet" type="text/css" href="/SIMANETCOMPLEMENTOS/JQuery/easyui/easyui.css">
		<LINK rel="stylesheet" type="text/css" href="/SIMANETCOMPLEMENTOS/JQuery/easyui/icon.css">
		<script type="text/javascript" src="/SIMANETCOMPLEMENTOS/JQuery/easyui/jquery.min.js"></script>
		<script type="text/javascript" src="/SIMANETCOMPLEMENTOS/JQuery/easyui/jquery.easyui.min.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/JQuery/js/JQueryPlugInSIMA.js"></script>
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<style>.Header { BACKGROUND-IMAGE: url(/simanetweb/imagenes/header.jpg); Z-INDEX: 2; POSITION: fixed; TEXT-ALIGN: center; FILTER: Alpha(opacity=100, finishopacity=85, style=1,startx=0, starty=10, finishx=0, finishy=50); PADDING-BOTTOM: 0px; BACKGROUND-COLOR: #e8f6f7; PADDING-LEFT: 0px; WIDTH: 100%; PADDING-RIGHT: 0px; DISPLAY: block; BACKGROUND-REPEAT: no-repeat; HEIGHT: 65px; TOP: 0px; PADDING-TOP: 0px; LEFT: 0px }
	.Fother { Z-INDEX: 4; POSITION: fixed; WIDTH: 100%; BOTTOM: 0px; DISPLAY: block; BACKGROUND: #dfdfdf; HEIGHT: 70px; LEFT: 0px }
	.Fother TABLEs { MARGIN-TOP: 0px; WIDTH: 85% }
	.Diapositiva { MARGIN-TOP: 65px; WIDTH: 98%; BOTTOM: 60px; FLOAT: left; HEIGHT: 100%; MARGIN-LEFT: 10px; text-shadow: 1px 1px 2px #f0f0f0 }
		</style>
		<style>.Pag { BACKGROUND-IMAGE: url(/SimanetWeb/imagenes/PagNro.png); WIDTH: 23px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 23px; FONT-SIZE: 11px; PADDING-TOP: 3px }
	.PagSelec { BACKGROUND-IMAGE: url(/SimanetWeb/imagenes/PagSelect.png); WIDTH: 24px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 23px; COLOR: black; FONT-SIZE: 11px; FONT-WEIGHT: bold; PADDING-TOP: 3px }
	.PanelGRP { BORDER-BOTTOM: #99bbe8 1px dotted; BORDER-LEFT: #99bbe8 1px dotted; WHITE-SPACE: nowrap; HEIGHT: 50px; OVERFLOW: auto; BORDER-TOP: #99bbe8 1px dotted; CURSOR: default; BORDER-RIGHT: #99bbe8 1px dotted }
	.PanelLeft { BORDER-LEFT: #99bbe8 1px dotted; WHITE-SPACE: nowrap; HEIGHT: 50px; OVERFLOW: auto; CURSOR: default }
		</style>
		<style>.pagination-info { DISPLAY: none }
		</style>
		<style type="text/css">
		.tooltip { BORDER-BOTTOM: #000000 1px dotted; POSITION: relative; OUTLINE-STYLE: none; COLOR: #000000; CURSOR: help; TEXT-DECORATION: none }
		.tooltip SPAN { POSITION: absolute; MARGIN-LEFT: -999em }
		.tooltip:hover SPAN { Z-INDEX: 99; POSITION: absolute; WIDTH: 250px; FONT-FAMILY: Calibri, Tahoma, Geneva, sans-serif; MARGIN-LEFT: 0px; TOP: 2em; LEFT: 1em; -webkit-box-shadow: 5px 5px rgba(0, 0, 0, 0.1); -moz-box-shadow: 5px 5px rgba(0, 0, 0, 0.1); -moz-border-radius: 5px; -webkit-border-radius: 5px; border-radius: 5px 5px; box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.1) }
		.tooltip:hover IMG { POSITION: absolute; BORDER-RIGHT-WIDTH: 0px; MARGIN: -10px 0px 0px -55px; FLOAT: left; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px }
		.tooltip:hover EM { PADDING-BOTTOM: 0.6em; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; DISPLAY: block; FONT-FAMILY: Candara, Tahoma, Geneva, sans-serif; FONT-SIZE: 1.2em; FONT-WEIGHT: bold; PADDING-TOP: 0.2em }
		.classic { PADDING-BOTTOM: 0.8em; PADDING-LEFT: 1em; PADDING-RIGHT: 1em; PADDING-TOP: 0.8em }
		.custom { PADDING-BOTTOM: 0.8em; PADDING-LEFT: 2em; PADDING-RIGHT: 0.8em; PADDING-TOP: 0.5em }
		* HTML A:hover { BACKGROUND: none transparent scroll repeat 0% 0% }
		.classic { BORDER-BOTTOM: #ffad33 1px solid; BORDER-LEFT: #ffad33 1px solid; BACKGROUND: #ffffaa; BORDER-TOP: #ffad33 1px solid; BORDER-RIGHT: #ffad33 1px solid }
		.critical { BORDER-BOTTOM: #ff3334 1px solid; BORDER-LEFT: #ff3334 1px solid; BACKGROUND: #ffccaa; BORDER-TOP: #ff3334 1px solid; BORDER-RIGHT: #ff3334 1px solid }
		.help { BORDER-BOTTOM: #2bb0d7 1px solid; BORDER-LEFT: #2bb0d7 1px solid; BACKGROUND: #9fdaee; BORDER-TOP: #2bb0d7 1px solid; BORDER-RIGHT: #2bb0d7 1px solid }
		.info { BORDER-BOTTOM: #2bb0d7 1px solid; BORDER-LEFT: #2bb0d7 1px solid; BACKGROUND: #9fdaee; BORDER-TOP: #2bb0d7 1px solid; BORDER-RIGHT: #2bb0d7 1px solid }
		.warning { BORDER-BOTTOM: #ffad33 1px solid; BORDER-LEFT: #ffad33 1px solid; BACKGROUND: #ffffaa; BORDER-TOP: #ffad33 1px solid; BORDER-RIGHT: #ffad33 1px solid }
		</style>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<div class="Header"></div>
		<div class="Fother">
			<table border="0" width="100%" align="left">
				<tr>
					<td width="5%">&nbsp;<IMG id="ibtnAtras" alt="" src="/SimanetWeb/imagenes/ibtnAtras.gif">
					</td>
					<td id="GrpPPT" width="45%" noWrap runat="server"><INPUT id="txtInfo">
					</td>
					<td class="PanelLeft">
						<table border="0" width="100%" align="left">
							<tr>
								<td class="paginations" id="ToolPag" width="100%" align="left" runat="server" vAlign="bottom">
								</td>
							</tr>
							<tr>
								<td id="Paginas" class="pagination" width="80%" align="left" vAlign="top">
									<div style="BORDER-BOTTOM: #ccc 1px solid; BORDER-LEFT: #ccc 1px solid; BACKGROUND: #efefef; BORDER-TOP: #ccc 1px solid; BORDER-RIGHT: #ccc 1px solid"
										id="pp"></div>
								</td>
							</tr>
						</table>
					</td>
					<TD>
					</TD>
				</tr>
			</table>
		</div>
		<asp:placeholder id="phContexto" runat="server"></asp:placeholder>
		<asp:placeholder id="phControls" runat="server"></asp:placeholder>
		<INPUT id="hPPTActive" size="1" type="hidden" runat="server"><INPUT style="Z-INDEX: 0" id="hNroGrupoyPag" size="1" type="hidden" name="hNroPag" runat="server">
		<!--<SCRIPT language="javascript" src="../../js/JQuery/js/jquery.min.js"></SCRIPT>-->
		<!--<script type="text/javascript" src="/SIMANETCOMPLEMENTOS/JQuery/JQueryDiapositiva/jquery.easing.1.3.js"></script>-->
		<SCRIPT language="javascript" src="../../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>
		<script type="text/javascript">
			var KEYQIDPRESENTACION="idPresent";
			function Resultado(Estado){
				return null;
			}
			
            $(function() {
				/*Habilita el evento click de cada paginacion*/
               $('td.pagination a').bind('click',function(event){
                    var btnPag =  $(this);
					var oBody=$('html, body');
					var IdPPT = btnPag.attr('href');
                });
            });
  
            
            function ActivarCarga(){
				$("[TIPOCRTL]").each(function(i,e){
					var Id = $(e)[0].id;
					var oContext = $("#"+Id);
					if((oContext.attr("TIPOCRTL")=='5')&&(oContext.attr("INITLOAD")=='1')){
						var URLLISTAUSUARIO =  SIMA.Utilitario.Helper.General.ObtenerPathApp()+ oContext.attr("URL");
						$( "#"+Id ).load(URLLISTAUSUARIO);
					}																	
				});
            }
            
            window.setTimeout(ActivarCarga,1000);
        
        
        
			var snPoint= new Object();
			snPoint.ColletionsPPT="";
			snPoint.ActivarPPT=function(NomCtrlSecc){
				if((snPoint.ColletionsPPT!=undefined)&&(snPoint.ColletionsPPT.length>0)){
															$.each(snPoint.ColletionsPPT, function(i, e){
																								var NomObjPPT = "Obj"+e;
																								var obj = $("#"+NomObjPPT);
																								var Encotrado = NomCtrlSecc.toString().Equal(NomObjPPT);
																								obj.css("display",((Encotrado)?"block":"none"));	
																								if(Encotrado){
																									//Ubica la posicion a 0 de la diapositiva a mostrar
																									$("html, body").animate({ scrollTop: 0 }, "slow");
																									obj.fadeIn(1000, function() {var s='';/*alert(this.id);*/});
																								}																						
																							}
																						);
														}		
			}
			
			snPoint.ActivarSeccion=function(IdObjeto){
				snPoint.ActivarPPT(IdObjeto);
			}
			snPoint.Grupo=new Object();
			snPoint.Grupo.Crear=function(){
				
			}
			
			snPoint.Grupo.LoadPPts=function(){
				/*Obtiene informacion del tabs seleccionado*/
				var oGrupoBE = new GrupoBE();
					oGrupoBE = this.Tag;
					//Inicia la carga de la paginación
					snPoint.Grupo.LoadPaginacion(oGrupoBE.IdGrupo);
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
				
				//$('#txtInfo').val($('#'+NomCtrGrp).val());
				
				/*Crea paginación por Grupo*/
				$('#pp').pagination({
					total: snPoint.ColletionsPPT.length,
					pageSize:1,
					layout:['sep','first','prev','links','next','last','sep','refresh'],
					onSelectPage: function(pageNumber, pageSize){
										//Almacena el Nro de Pagina seleccionado
										$.SaveClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,snPoint.Grupo.NombreGrupoSelec,(pageNumber));				
										$(this).pagination('loading');
											var NomCtrlSecc="Obj"+snPoint.ColletionsPPT[pageNumber-1];
											//Activa la PPT segun indice de la página
											snPoint.ActivarPPT(NomCtrlSecc);									
										$(this).pagination('loaded');
										
								},
					buttons: [{
						iconCls:'icon-add',
						handler:function(){alert('add')}
					},'-',{
						iconCls:'icon-save',
						handler:function(){alert('save')}
					},'-']
				});
				
				//$('#pp').pagination('refresh');
				/*Activa la pagina por default*/
				var NroPagSelecc=$.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,snPoint.Grupo.NombreGrupoSelec);
				NroPagSelecc = (((NroPagSelecc==undefined)||(NroPagSelecc.length==0))?1:NroPagSelecc);
				$('#pp').pagination('select',NroPagSelecc);
			}
			
            
        function GrupoBE(IDGRUPO,NOMBRE){
			this.IdGrupo=IDGRUPO;
			this.Nombre=NOMBRE;
        }
        
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
										var oGrupoBE=new GrupoBE(oDataRow.Item("IdGrupo"),oDataRow.Item("Descripcion"));
										if(f==0){IdGrupoDefault=oDataRow.Item("IdGrupo");}
										var oTab = new SIMA.Utilitario.Helper.General.Tab();
										oTab.Texto = oDataRow.Item("Descripcion");
										oTab.ToolTips = "";
										oTab.Tag = oGrupoBE;
										oTab.EventHandle=snPoint.Grupo.LoadPPts;
										oTabStrip.Tabs.Adicionar(oTab);
									}
							}
						
						oTabStrip.RepintarTabs();
						oTabStrip.Tabs.Tab(0).Click(0);
					}
					catch(error){
						alert(error);
					}			
				//Inicia la seleccion del tab
				snPoint.Grupo.LoadPaginacion(IdGrupoDefault);
			}
			CargarFormato();            
            
						            
            
		</script>
	</body>
</HTML>
