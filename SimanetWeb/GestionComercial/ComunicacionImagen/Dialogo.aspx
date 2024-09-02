<%@ Page language="c#" Codebehind="Dialogo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.Dialogo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Dialogo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script>
			function Cerrar()
			{
				var oWindow = window.dialogArguments;
				oWindow.HistorialIrAtras();
				window.close();
			}
		</script>
</HEAD>
	<body  onload="Cerrar();" >
		<form id="Form1" method="post" runat="server">
		</form>
	</body>
</HTML>
