<%@ Page language="c#" Codebehind="PPTListarPaginacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Diapositivas.PPTListarPaginacion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>PPTListarPaginacion</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<asp:placeholder id="phContexto" runat="server"></asp:placeholder>		
		</form>
		<script>
			var NroPagSelecc=$.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,snPoint.Grupo.NombreGrupoSelec);			
			var NomDiapositiva=$.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,snPoint.Grupo.NombreGrupoSelec+"D");			
			if(NroPagSelecc!=null){
			//	alert(NomDiapositiva);
				snPoint.ActivarPPT(document.getElementById(NroPagSelecc),NomDiapositiva);
			}
		</script>
	</body>
</HTML>
