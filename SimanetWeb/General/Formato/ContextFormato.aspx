<%@ Page language="c#" Codebehind="ContextFormato.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Formato.ContextFormato" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrar Formato</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<SCRIPT language="javascript" src="../../js/JQuery/js/jquery.min.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>
		<style>.ContextImg { Z-INDEX: 3; POSITION: relative; WIDTH: 45px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 45px }
	.imgCirc { Z-INDEX: 1; POSITION: absolute; BACKGROUND-REPEAT: no-repeat; TOP: -2px; left-30: }
		</style>
		<script>
			function CargaMes(){
				 $("#HojaTrabajo").load("DetalleRubro.aspx?Modo=M&IdFormato=31&IdRubro=3");
			}
		</script>
	</HEAD>
	<body onkeypress="if((event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.KeyReturn)||(event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.keyTab)){return false;}"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0" Tag="Local">
		<form id="Form1" method="post" runat="server">
			<TABLE id="tbl" border="1" cellSpacing="1" cellPadding="1" width="100%" height="100%">
				<TR>
					<TD><INPUT id="btnMes" value="Button" type="button" onclick="CargaMes()">
						<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="DetalleRubro.aspx">HyperLink</asp:HyperLink></TD>
				</TR>
				<TR>
					<TD height="100%">
						<div id='HojaTrabajo'></div>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
