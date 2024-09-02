<%@ Page language="c#" Codebehind="MaterPPT.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Diapositivas.MaterPPT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<HTML>
	<HEAD>
		<title>Website Horizontal Scrolling with jQuery</title>
		<meta content="text/html; charset=UTF-8" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<LINK rel="stylesheet" type="text/css" href="/SIMANETCOMPLEMENTOS/JQuery/JQueryDiapositiva/css/style.css"
			media="screen">
			<style>A {
	COLOR: #fff; TEXT-DECORATION: none
}
A:hover {
	TEXT-DECORATION: underline
}
SPAN.reference {
	POSITION: fixed; BOTTOM: 10px; FONT-SIZE: 13px; FONT-WEIGHT: bold; LEFT: 10px
}
SPAN.reference A {
	PADDING-RIGHT: 20px; COLOR: #fff; text-shadow: 1px 1px 1px #000
}
SPAN.reference A:hover {
	COLOR: #ddd; TEXT-DECORATION: none
}

.HeaderPPT {
	POSITION: fixed; BORDER-BOTTOM-COLOR: red; BORDER-TOP-COLOR: red; BORDER-RIGHT-COLOR: red; BORDER-LEFT-COLOR: red
}
.clsMenu TD {
	FILTER: Alpha(opacity=100, finishopacity=85, style=1,startx=0, starty=10, finishx=0, finishy=50)
}
</style>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0"  scroll="si">
		<!--Cabecera-->
		<div class="HeaderPPT">
			<table style="WIDTH: 1320px" border="0" cellSpacing="0" cellPadding="0" bgColor="#e8f6f7">
				<tr class="clsMenu">
					<td><asp:image id="Image1" Height="60px" Width="800px" ImageUrl="/Simanetweb/imagenes/header.jpg"
							runat="server"></asp:image></td>
				</tr>
			</table>
		</div>
		<!-- Pie de pagina-->
		<div>
			<span class="reference"><ul id="Navegador" class="nav" runat="server"></ul>
			</span>
		</div>
		<asp:placeholder id="phContexto" runat="server"></asp:placeholder>
		<!-- The JavaScript -->
		<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
		<script type="text/javascript" src="/SIMANETCOMPLEMENTOS/JQuery/JQueryDiapositiva/jquery.easing.1.3.js"></script>
		<SCRIPT language="javascript" src=  "../../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>
		
		<script type="text/javascript">
			function Resultado(Estado){
				return null;
			}
			
            $(function() {
                $('ul.nav a').bind('click',function(event){
                    var $anchor = $(this);
					var oBody=$('html, body');
					alert();
					oBody.stop().animate({scrollLeft: $($anchor.attr('href')).offset().left}
											, 1000
											,'linear'
											,function(){
												oBody.stop().animate({scrollTop: $($anchor.attr('href')).offset().top},1000);
											 }
										);
                    
                   //oBody.stop().animate({scrollTop: $($anchor.attr('href')).offset().top},1000);
                    
                    /* se accede directamente por el ID
                  $('html, body').stop().animate({
                        scrollLeft: $('#section3').offset().left
                    }, 1000,'linear');
                    
                  */  
                    event.preventDefault();
                });
                
            });
            
            function ActivarCarga(){
				$("[TIPOCRTL]").each(function(i,e){
					var Id = $(e)[0].id;
					var oContext = $("#"+Id);
					//oContext.style.cssText = "background-color:pink;font-size:55px;border:2px dashed;height:500px;width:800px;";
					oContext.css("height","100px");
					oContext.css("width","100px");
					//oContext.css("border","2px dashed");
					
					if((oContext.attr("TIPOCRTL")=='5')&&(oContext.attr("INITLOAD")=='1')){
						var URLLISTAUSUARIO =  SIMA.Utilitario.Helper.General.ObtenerPathApp()+ oContext.attr("URL");
						jNet.get(Id).load(URLLISTAUSUARIO,"",Resultado);
					}
				});
            }
            
            window.setTimeout(ActivarCarga,1000);
		</script>
	</body>
</HTML>
