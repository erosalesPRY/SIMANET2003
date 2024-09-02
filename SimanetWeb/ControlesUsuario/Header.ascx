<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Header.ascx.cs" Inherits="SIMA.SimaNetWeb.ControlesUsuario.Header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<meta http-equiv="imagetoolbar" content="no" />
<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0" bgColor="#e8f6f7">
	<TR class="clsMenu">
		<TD>
			<asp:Image id="Image1" runat="server" ImageUrl="../imagenes/header.jpg" Width="780px" Height="70px"></asp:Image></TD>
		<TD style="WIDTH: 154px"></TD>
	</TR>
</TABLE>
<img id="imgDes" src="/simanetweb/imagenes/Navegador/mant.gif" style="display:none"></>
<script>
	function removejscssfile(filename, filetype){
		var targetelement=(filetype=="js")? "script" : (filetype=="css")? "link" : "none" //determine element type to create nodelist from
		var targetattr=(filetype=="js")? "src" : (filetype=="css")? "href" : "none" //determine corresponding attribute to test for
		var allsuspects=document.getElementsByTagName(targetelement)
		for (var i=allsuspects.length; i>=0; i--){ //search backwards within nodelist for matching elements to remove
			if (allsuspects[i] && allsuspects[i].getAttribute(targetattr)!=null && allsuspects[i].getAttribute(targetattr).indexOf(filename)!=-1)
			allsuspects[i].parentNode.removeChild(allsuspects[i]) //remove element by calling parentNode.removeChild()
		}
	}
	removejscssfile("jscript.js", "js") 
	removejscssfile("General.js", "js") 
	removejscssfile("Historial.js", "js")
	//removejscssfile("@Import.js", "js")
</script>
<SCRIPT language="javascript" src="/simanetweb/js/@Import.js"></SCRIPT>
<script>
/*
	var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
	var oDataTable = new System.Data.DataTable("tblFormato");
	oDataTable = (new Controladora.General.CAccessControl()).ConsultarDatosPagina(oPagina.Request.Nombre);
	for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
		var oDataRow =oDataTable.Rows.Items[f];
		if(oDataRow.Item("EOF")==false){
			document.title = oDataRow.Item("Nombre");
		}
	}
	*/
	//window.setTimeout((new Navegabilidad()).Iniciar,500);
	window.setTimeout(LogoEnDesarrollo,100);
function LogoEnDesarrollo(){	
	var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
	var KEYQFLAGDESARROLLO = "flgDesa";
	var _Left = (window.screen.width-100);
	if((oPagina.Request.Params[KEYQFLAGDESARROLLO]!=undefined)&&(oPagina.Request.Params[KEYQFLAGDESARROLLO]=='1')){
		var oImgFLG = $O('imgDes');
		oImgFLG.style.position="absolute";
		oImgFLG.style.left = _Left + "px";
		oImgFLG.style.top = "92px";
		oImgFLG.style.display="block";
		oImgFLG.title="En desarrollo";
	}
}
//Actualiza el registro de logueo del usuario al momento de salir
window.onunload=function(){
					try{
						(new Controladora.General.CSessionApp()).InsertarActualiza();
					}
					catch(ex){
						alert(ex);
					}
				}

</script>

