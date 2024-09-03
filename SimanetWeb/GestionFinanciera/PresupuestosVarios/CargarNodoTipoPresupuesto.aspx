<%@ Page language="c#" Codebehind="CargarNodoTipoPresupuesto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios.CargarNodoTipoPresupuesto" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CargarNodoTipoPresupuesto</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script>
			function AsignarValor()
			{
				var oWindow = window.dialogArguments;
				var hcod = document.all["hRegistro"];
				oWindow.strData=hcod.value;
			}
		</script>
	</HEAD>
	<body onload="AsignarValor();window.close();">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hRegistro" type="hidden" name="hRegistro" runat="server">
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
