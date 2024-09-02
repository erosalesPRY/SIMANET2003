<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ReceptosParametros.aspx.cs"  EnableViewState="true" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.ReceptosParametros" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>AdministrarProgramacionVisitas</title>
<meta name=GENERATOR content="Microsoft Visual Studio .NET 7.1">
<meta name=CODE_LANGUAGE content=C#>
<meta name=vs_defaultClientScript content=JavaScript>
<meta name=vs_targetSchema content=http://schemas.microsoft.com/intellisense/ie5><LINK rel=stylesheet type=text/css href="../styles.css" >
<SCRIPT language=javascript src="../js/@Import.js"></SCRIPT>

<script type=text/javascript 
src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>

<script type=text/javascript src="/SimaNetWeb/js/Menu/MenuSP.js"></script>

<script type=text/javascript src="/SimaNetWeb/js/RegEXT.js"></script>

<SCRIPT language=javascript src="../js/JQuery/js/jquery.min.js"></SCRIPT>

<SCRIPT language=javascript src="../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>

<script>
			var jSIMA = jQuery.noConflict();
			var HandleWindow;
			//Valido para el control de tipo 9
			function OnSelectedRow(NomCtrlDst,ValorCampoSelect,NomCtrlDstText,TextCampoSelect){
				var strNombreCtrl = "#"+NomCtrlDst;
				var strNombreCtrlText = "#"+NomCtrlDstText;
				
				jSIMA(strNombreCtrlText).attr("value",TextCampoSelect);
				jSIMA(strNombreCtrl).attr("value",ValorCampoSelect);
				
			}
			function Cerrar(wind){
				wind.close();
			}
			
		</script>
		<!--Script ara los Controles-->
<script>
			function CrearCtrlListItemSimple(Source,Target,e){
				if(event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.KeyReturn){
					CrearItemLst(Source,Target,e.value,e.value);
					e.value='';
					RefreshCollectionItem(jNet.get(jNet.get(Source).rows[1].cells(0)),jNet.get("X" + Target),jNet.get("H" + Target));
				}
			}
			
			
			function CrearItemLst(Source,Target,_Text,_Value){
						var HTMLTable = jNet.get((new SIMA.Utilitario.Helper.General.Html()).CrearTabla(1,2));
						IdObj = "obj" + _Value.toString().Replace(' ','');
						HTMLTable.align="left";
						HTMLTable.style.cssText="MARGIN-BOTTOM: 5px; MARGIN-LEFT: 5px";
						HTMLTable.attr("VALUE",_Value);
						HTMLTable.attr("SOURCE",Source);
						HTMLTable.attr("TARGET",Target);
						HTMLTable.attr("TEXT",_Text);
						
						HTMLTable.className="BaseItemInGrid";
						HTMLTable.border=0;
						HTMLTable.rows[0].cells[1].innerText=_Text;
						HTMLTable.rows[0].cells[1].noWrap=true;
					
					
						var oIMG = SIMA.Utilitario.Helper.General.CrearImgEliminar(1);
						oIMG.onclick=function(){
							var oTBLItem = jNet.get(this.parentNode.parentNode.parentNode.parentNode);
								Ext.MessageBox.confirm('Confirmar', 'Desea ud. remover este item del filtro ahora?', function(btn){
												if(btn=="yes"){
													var otblSOURCE = jNet.get(oTBLItem.getAttribute("SOURCE"));
													var hListOBJ = jNet.get("H" + oTBLItem.getAttribute("TARGET"));
													var xListOBJ = jNet.get("X" + oTBLItem.getAttribute("TARGET"));
													var LstItem = jNet.get(otblSOURCE.rows[1].cells(0));
													LstItem.remove(oTBLItem);
													RefreshCollectionItem(LstItem,xListOBJ,hListOBJ)
												}
											});
						}
						jNet.get(HTMLTable.rows[0].cells[1]).insert(oIMG);
						jNet.get(jNet.get(Source).rows[1].cells(0)).insert(HTMLTable);
			}
			
			function RefreshCollectionItem(oContenedor,XstrLst,HstrLst){
				var LstItem = oContenedor;
				var strLstText="";
				var strLstValue="";
				for(var child=LstItem.firstChild; child!==null; child=child.nextSibling) {
					strLstText=strLstText + child.getAttribute("TEXT") + "@";
					strLstValue = strLstValue + child.getAttribute("VALUE") + "@";
				}
				if(LstItem.firstChild==null){
					HstrLst.value ='0';
					XstrLst.value ='';
				}
				else{
					if(strLstText.length>0){
						XstrLst.value = strLstText.substring(0,strLstText.length-1);
						HstrLst.value = strLstValue.substring(0,strLstValue.length-1);
					}
				}
			}
			
			
			function CrearCtrlListItemAutoComple(Source,Target,txtFind,strDato){
				CrearItemLst(Source,Target,txtFind.value,strDato);
				txtFind.value='';
				RefreshCollectionItem(jNet.get(jNet.get(Source).rows[1].cells(0)),jNet.get("X" + Target),jNet.get("H" + Target))	;
			}
			
			
			//Buscar Los COntroles en el contenedor
			function BuscarControlsX(){
				var allCTRL = document.getElementsByClassName('X');
				for(var c=0;c<=allCTRL.length-1;c++){
					var txtTexto = allCTRL[c];
					if(txtTexto.value.length>0){
						var arrValue = 	txtTexto.value.split('@');
						var Source = txtTexto.getAttribute('SOURCE');
						var Target = txtTexto.getAttribute('TARGET');
							
						for(var i=0;i<=arrValue.length-1;i++){
							var strText=arrValue[i];
							try{
								CrearItemLst(Source,Target,strText,strText);
							}
							catch(error){
								alert(error.message);
							}
							
						}
					}
				}
			}
		
		
		</script>
</HEAD>
<BODY onkeydown="if(event.keyCode==13)return false" onunload=SubirHistorial(); 
onload=ObtenerHistorial(); bottomMargin=0 leftMargin=0 rightMargin=0 scroll=no 
topMargin=0>
<form id=Form1 method=post runat="server">
<TABLE id=Table1 border=0 cellSpacing=0 cellPadding=0 width="100%">
  <TR>
    <TD><uc1:header id=Header1 runat="server"></uc1:header></TD></TR>
  <TR>
    <TD><uc1:menu id=Menu1 runat="server"></uc1:menu></TD></TR>
  <TR>
    <TD class=commands><asp:label id=lblRutaPagina runat="server" CssClass="RutaPagina">Inicio >Gestión de Personal ></asp:label><asp:label id=lblPagina runat="server" CssClass="RutaPaginaActual"> >Listado y Reporte ></asp:label><INPUT 
      style="WIDTH: 56px; HEIGHT: 22px" id=hCrystalReport size=4 type=hidden 
       runat="server"></TD></TR>
  <TR>
    <TD style="HEIGHT: 18px" align=center></TD></TR>
  <TR>
    <TD align=center>
      <TABLE style="WIDTH: 911px; HEIGHT: 100px" id=tblContext border=0 
      cellSpacing=1 cellPadding=1 width=411 
        runat="server">
        <TR>
          <TD style="BORDER-BOTTOM: gray 1px solid" colSpan=3 align=center 
          ><asp:label style="Z-INDEX: 0" id=lblReporte runat="server" Font-Bold="True">Nombre reporte</asp:label></TD></TR>
        <TR>
          <TD 
          style="BORDER-BOTTOM: gray 1px solid; FONT-FAMILY: Arial; MARGIN-BOTTOM: 15px; FONT-SIZE: 10pt; FONT-WEIGHT: bold" 
          colSpan=3 align=center><asp:label id=Label1 runat="server" Font-Bold="True" Font-Size="10pt">PARAMETRO DEL INFORME</asp:label></TD></TR>
        <TR>
          <TD width="50%" align=left></TD>
          <TD style="PADDING-LEFT: 5px" width="50%" align=left 
          ></TD>
          <TD></TD></TR>
        <TR>
          <TD width="50%" align=left></TD>
          <TD style="PADDING-LEFT: 5px" width="50%" align=left 
          ></TD>
          <TD></TD></TR>
        <TR>
          <TD width="50%" align=left></TD>
          <TD style="PADDING-LEFT: 5px" width="50%" align=left 
          ></TD>
          <TD></TD></TR>
        <TR>
          <TD width="50%" align=left></TD>
          <TD style="PADDING-LEFT: 5px" width="50%" align=left 
          ></TD>
          <TD></TD></TR>
        <TR>
          <TD width="50%" align=left></TD>
          <TD width="50%" align=left></TD>
          <TD></TD></TR>
        <TR>
          <TD width="50%" align=left></TD>
          <TD style="PADDING-LEFT: 5px" width="50%" align=left 
          ></TD>
          <TD></TD></TR>
        <TR>
          <TD width="50%" align=left></TD>
          <TD style="PADDING-LEFT: 5px" width="50%" align=left 
          ></TD>
          <TD></TD></TR>
        <TR>
          <TD width="50%" align=left></TD>
          <TD style="PADDING-LEFT: 5px" width="50%" align=left 
          ></TD>
          <TD></TD></TR>
        <TR>
          <TD width="50%" align=left></TD>
          <TD style="PADDING-LEFT: 5px" width="50%" align=left 
          ></TD>
          <TD></TD></TR>
        <TR>
          <TD width="50%" align=left></TD>
          <TD style="PADDING-LEFT: 5px" width="50%" align=left 
          ></TD>
          <TD></TD></TR>
        <TR>
          <TD width="50%" align=left></TD>
          <TD style="PADDING-LEFT: 5px" width="50%" align=left 
          ></TD>
          <TD></TD></TR>
        <TR>
          <TD width="50%" align=left></TD>
          <TD width="50%" align=right></TD>
          <TD></TD></TR>
        <TR>
          <TD width="50%" colSpan=3 align=left>
            <TABLE id=Table2 border=0 cellSpacing=1 cellPadding=1 width="100%" 
            >
              <TR>
                <TD width="50%"><IMG style="Z-INDEX: 0; CURSOR: hand" id=ibtnAtras onclick=HistorialIrAtras(); alt="" src="../imagenes/atras.gif" ></TD>
                <TD width="50%" align=right><asp:button style="Z-INDEX: 0" id=btnVer runat="server" Text="Vista Previa"></asp:button></TD></TR></TABLE></TD></TR></TABLE></TD></TR></TABLE></form>
	<script>
		BuscarControlsX();
	</script>
		
		
	</BODY>
</HTML>
