<%@ Page language="c#" Codebehind="ListarFormatosAgrupados.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Diapositivas.GestionFinanciera.ListarFormatosAgrupados" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ListarFormatosAgrupados</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel=stylesheet type=text/css href="../../../styles.css" >
		<SCRIPT language="javascript" src="../../../js/@Import.js"></SCRIPT>
		
  </HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table5" border="0" cellSpacing="1" cellPadding="1" width="800">
				<TR>
					<TD id="TabContext">ss</TD>
				</TR>
				<TR>
					<TD id="TabContext2">sss</TD>
				</TR>			
			</TABLE>		
		</form>
		<script>
			function MostrarDetalle(){
				//alert();
			}
			function CargarFormato(){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					try{
						var PathApp = SIMA.Utilitario.Helper.General.ObtenerPathApp();
						var oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip(document.all["TabContext"]);
						oTabStrip.PathImagen=PathApp + "/Imagenes/Tabs/";
						oTabStrip.TipoInterfaz = SIMA.Utilitario.Helper.General.Tabs.TipoInterfaz.SoloParaParametros;
						
						oTab = new SIMA.Utilitario.Helper.General.Tab();
						oTab.Texto = "Estados GP!";
						oTab.ToolTips = "Estado de resultados";
						oTab.Tag = "1";
						oTab.EventHandle=MostrarDetalle;
						oTabStrip.Tabs.Adicionar(oTab);

						oTab = new SIMA.Utilitario.Helper.General.Tab();
						oTab.Texto = "Balance General!";
						oTab.ToolTips = "Estado de balance";
						oTab.Tag = "2";
						oTab.EventHandle=MostrarDetalle;
						oTabStrip.Tabs.Adicionar(oTab);									
									
						
						
						
						var oTabStrip2= new SIMA.Utilitario.Helper.General.TabStrip(document.all["TabContext2"]);
						oTabStrip2.PathImagen=PathApp + "/Imagenes/Tabs/";
						oTabStrip2.TipoInterfaz = SIMA.Utilitario.Helper.General.Tabs.TipoInterfaz.SoloParaParametros;
						
						oTab = new SIMA.Utilitario.Helper.General.Tab();
						oTab.Texto = "Estados GP!";
						oTab.ToolTips = "Estado de resultados";
						oTab.Tag = "1";
						oTab.EventHandle=MostrarDetalle;
						oTabStrip2.Tabs.Adicionar(oTab);

						oTab = new SIMA.Utilitario.Helper.General.Tab();
						oTab.Texto = "Balance General!";
						oTab.ToolTips = "Estado de balance";
						oTab.Tag = "2";
						oTab.EventHandle=MostrarDetalle;
						oTabStrip2.Tabs.Adicionar(oTab);									
						
						
						oTabStrip.RepintarTabs();
						//oTabStrip.Tabs.Tab(stbIndex).Click();
						
						oTabStrip2.RepintarTabs();
						//oTabStrip2.Tabs.Tab(0).Click();
						
						
					}
					catch(error){
					}			
			}
			CargarFormato();
		</script>
	</body>
</HTML>
