<%@ Page language="c#" Codebehind="AdministrarMsgVB.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.AdministrarMsgVB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Administrar Msg VB</title>
		<meta charset="UTF-8">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		
		<LINK rel="stylesheet" href="/SimaNetWeb/js/JQuery/css/style.css">
		<LINK rel="stylesheet" type="text/css" href="/SimaNetWeb/js/JQuery/css/css?family=Open+Sans:400,600,700">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false">
		<form id="Form1" method="post" runat="server">
			<div id="chatbox">
				<div style="Z-INDEX: 0" id="friendslist">
					<div id="topmenu"><span class="friends"></span><span class="chats"></span><span class="history"></span></div>
					<div id="friends" runat="server"></div>
				</div>
				<div id="chatview" class="p1">
					<div id="profile">
						<div id="close">
							<div class="cy"></div>
							<div class="cx"></div>
						</div>
						<p>Miro Badev</p>
						<span>miro@badev@gmail.com</span>
						<div id="IdNormaGen">NORMA ISO</div>
					</div>
					<div id="chatmessages" runat="server"><label id="LCodSAM">Dia de HOY</label>
					</div>
						<div id="sendmessage">
							<textarea id="TxtSend" onkeydown="TextoInVariable(this);" value="Escribir mensaje..." maxlength='57' ></textarea>  
							<button id="send" value="Enviar."></button><br>
					</div>
				</div>
			</div>
			<INPUT id="hRutaFoto" type="hidden" runat="server"> <INPUT id="hNroPersonalSEND" type="hidden" runat="server">
			<INPUT id="hIdUsuarioSelect" type="hidden">
			<script src="/SimaNetWeb/js/JQuery/js/jquery.min.js"></script>
			<script src="/SimaNetWeb/js/JQuery/js/index.js"></script>
			<script src="/SimaNetWeb/js/JQuery/js/JQueryPlugInSIMA.js"></script>
			<INPUT style="Z-INDEX: 0" id="hIdUsuarioRegistro" type="hidden" name="Hidden1" runat="server">
			<INPUT style="Z-INDEX: 0" id="hEmailUsrSelected" type="hidden" name="Hidden1" runat="server">
			<INPUT style="Z-INDEX: 0" id="hNombreNormaISO" type="hidden" name="Hidden1" runat="server">
		</form>
		<script>
				var Texto ="";
				function TextoInVariable(e){
					Texto =e.value;
				}
				
			
		
				$(function(){
								//Establece el nro de SAM  en la cabecera del chat
								$("#LCodSAM").html(Page.Request.Params[SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDSAM]);
						
								$("#send").click( function() {
									var UrlFoto=$("#hRutaFoto").attr("value") + $("#hNroPersonalSEND").attr("value")+".jpg";
									var HtmlMsg = "<div class='message right' >"
													+ " <IMG src='" + UrlFoto +"' >"
													+ " <div class='bubble'>"  + Texto
													+ "     <div class='corner' ></div>"
													+ "		<span>" + $.Hoy() + "</span>"
													+ " </div>"
													+"</div>";

										$("#chatmessages").append(HtmlMsg);
										
										//$("#TxtSend").attr("value",""); 
										$("textarea#TxtSend").attr("value",""); 
										
											var oSAMNotaBE = new EntidadesNegocio.OGI.SAMNotaBE();
												oSAMNotaBE.IdSamISONota="";
												oSAMNotaBE.IdSamISONotaPadre="0";
												oSAMNotaBE.IdSamISO=Page.Request.Params["IdSamISO"];
												oSAMNotaBE.Nota=Texto;
												oSAMNotaBE.IdUsuarioDestino=$("#hIdUsuarioSelect").attr("value");
												oSAMNotaBE.IdUsuarioOrigen = $("#hIdUsuarioRegistro").attr("value");
												oSAMNotaBE.NombreUsuarioDst=$("#hEmailUsrSelected").attr("value");
												oSAMNotaBE.CodigoSAM = Page.Request.Params[SIMA.Utilitario.Constantes.GestionIntegrada.KEYQIDSAM];
												oSAMNotaBE.NombreNormaISO= $("#hNombreNormaISO").attr("value");

											var strId = (new Controladora.OGI.CSAMNota()).InsertarActualiza(oSAMNotaBE)
										
											Texto="";
										   
										var divOffset = $("#chatmessages").offset().top;
										var divHeight = $("#chatmessages").height();
										$('#chatmessages').animate({scrollTop : divOffset + divHeight });
								});

								
								$(".friend").click( function(event) {
										//Usuario destino seleccionado
											//Limpia el area de Chat
											var htmlCSAM = $("#LCodSAM").html();
											$("#chatmessages").html('');
											
											var htmlTagLbl = "<label id='LCodSAM'>" + htmlCSAM + "</label>";
											$("#chatmessages").append(htmlTagLbl);
											
											
											var oImg = this.children[0];
											$("#hIdUsuarioSelect").attr("value",$(oImg).attr("IDUSUARIORESP"));
											$("#hEmailUsrSelected").attr("value",$(oImg).attr("EMAIL"));
											$("#hNombreNormaISO").attr("value",$(oImg).attr("NORMAISO"));
											
											
											var oDataTable= new System.Data.DataTable("tblNotas");
											oDataTable= (new Controladora.OGI.CSAMNota()).Listar(Page.Request.Params["IdSamISO"],$("#hIdUsuarioSelect").attr("value"));
											for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
												var dr =oDataTable.Rows.Items[f];
												if(dr.Item("EOF")==false){
													var  UrlFoto =$("#hRutaFoto").attr("value") +  dr.Item("NroPersonal")+".jpg";
													if(dr.Item("IdUsuarioRegistro")==$("#hIdUsuarioRegistro").attr("value"))
													{
														var TagUserRecive = "<div class='message right' >"
																					+ "<IMG src='" + UrlFoto  + "' >"
																					+ "<div class='bubble'>" + dr.Item("Nota")
																					+ "<div class='corner' ></div> <br>"
																					+ "		<span>" + dr.Item("Fecha") + "</span>"
																					+ "</div>"
																					+"</div>";
														
														$("#chatmessages").append(TagUserRecive);
													}
													else{
														var TagUserSend = "<div class='message'>"
															+ "<img src='" + UrlFoto + "' >"
															+ "<div class='bubble'>" + dr.Item("Nota")
															+ "		<div class='corner'></div>"
															+ "</div>"
																+ "		<span class='izq'>" + dr.Item("Fecha") + "</span>"
															+"</div>";

														$("#chatmessages").append(TagUserSend);
														//Actualiza a leido
														var oSAMNotaBE = new EntidadesNegocio.OGI.SAMNotaBE();
														oSAMNotaBE.IdSamISONota=dr.Item("IdSamISONota");
														oSAMNotaBE.IdEstadoFind=1;
														oSAMNotaBE.IdEstado=2;
														(new Controladora.OGI.CSAMNota()).ActualizaEsta(oSAMNotaBE);
																																
													}						
												
												}
											}
										//Se desplaza hacia el final del ultimo mensaje enviado
										var divOffset = $("#chatmessages").offset().top;
										var divHeight = $("#chatmessages").height();
										$('#chatmessages').animate({scrollTop : divOffset + divHeight });
								});

								
								 $("textarea[maxlength]").bind('input propertychange', function() {  
									var maxLength = $(this).attr('maxlength');  
									if ($(this).val().length > maxLength) {  
										$(this).val($(this).val().substring(0, maxLength));  
									}  
								});

								
								
								
								
								
							});
						

		
							
		</script>
	</body>
</HTML>
