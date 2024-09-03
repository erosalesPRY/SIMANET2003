<%@ Page language="c#" Codebehind="DocPrevio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DocPrevio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>DocPrevio</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<script type="text/javascript">
<!-- gueltig fuer Netscape ab Version 6, Mozilla, Internet Explorer ab Version 4

var dragobjekt = null;
var dragx = 0;
var dragy = 0;

var posx = 0;
var posy = 0;

function draginit() {
	document.onmousemove = drag;
	document.onmouseup = dragstop;
	var oldlayerposleft = 0;//document.getElementById('einser').style.left;
	var oldlayerpostop = 0;//document.getElementById('einser').style.top;
}
var iniDrag;
var obj;
function dragstart(element) {
	iniDrag="SI";
	obj = element;
	dragobjekt = element;
	dragx = posx - dragobjekt.offsetLeft;
	dragy = posy - dragobjekt.offsetTop;
}

var Arriba=0;
var Izquierda=0;
function dragstop() {
	dragobjekt=null;
	if (iniDrag=="SI")
	{
		Arriba=obj.style.top;
		Izquiera=obj.style.left;
		var arrParametro =obj.id.replace("DIV","").split("@");
		//Propiedades(arrParametro[0],arrParametro[1]);
	}
	iniDrag="NO";
	//document.getElementById("hValorConfirma").setAttribute("value","NO");		
}

function drag(ereignis) 
{
	posx = document.all ? window.event.clientX : ereignis.pageX;
	posy = document.all ? window.event.clientY : ereignis.pageY;
	if(dragobjekt != null) {
		dragobjekt.style.left = (posx - dragx) + "px";
		dragobjekt.style.top = (posy - dragy) + "px";
		dragobjekt.style.cursor = "move";
	}
}
	function Propiedades(idRep,id)
	{
		window.open("DocPrevioObjPropiedad.aspx?Modo=N&idRep="+ idRep + "&" + "idItem="+ id + "&TOP=" + Arriba,"MiWin","Width=380,Height=470,scrollbars=no");
	}

//-->
		</script>
</HEAD>
	<body onload="draginit()" bottomMargin="5" leftMargin="5" topMargin="5" rightMargin="5">
		<form id="Form1" method="post" runat="server">
			&nbsp;
			<asp:Button id="Button1" runat="server" Text="Button"></asp:Button><SELECT style="LEFT: 150px; VISIBILITY: hidden; POSITION: absolute; TOP: 150px">
				<OPTION selected></OPTION>
			</SELECT>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
