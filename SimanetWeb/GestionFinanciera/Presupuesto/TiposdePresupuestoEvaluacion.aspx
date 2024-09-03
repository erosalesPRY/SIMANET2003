<%@ Page language="c#" Codebehind="TiposdePresupuestoEvaluacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.TiposdePresupuestoEvaluacion" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TiposdePresupuestoEvaluacion</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="../../js/RegEXT.js"></script>
		<script>
			function CargarTabs()
			{
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip(document.all["divContenedor"]);
				oTabStrip.PathImagen= SIMA.Utilitario.Helper.General.ObtenerPathApp()+ "/Imagenes/Tabs/";
				
				var NOMBRECTRLPERIODO = "ddlbPeriodo";
				var NOMBRECTRLMES = "dddblMes";
				var NOMBRECTRLHTABSELECT = "hidTabSelect";
				/*-------------------------------------------------------------------------*/
				var KEYQPERIODO ="Periodo";
				var KEYQMES ="Mes";
				var KEYVALORINICIAL = "PaginaValorIncial"
				var KEYQPPTO = "VISTAPPTO";
				var KEYQTABSELECT = "tabSelect";
				var KEYQMODO="Modo";
				var KEYQVISTA="Vista";
				
				/*-------------------------------------------------------------------------*/
				 oddlbPeriodo = $O(NOMBRECTRLPERIODO);
				 odddblMes = $O(NOMBRECTRLMES);
				 ohidTabSelect = $O(NOMBRECTRLHTABSELECT);
				 
				/*-------------------------------------------------------------------------*/
				var oddlVista = $O("ddlVista");
				with(SIMA.Utilitario.Constantes.General.Caracter)
				{
					urlPagina = SIMA.Utilitario.Helper.General.ObtenerPathApp()+ "/GestionFinanciera/Presupuesto/ConsultarResumeEvaluacionPresupuestal.aspx?";
					Parametros = KEYVALORINICIAL + SignoIgual.toString() + oPagina.Request.Params[KEYVALORINICIAL]
								+ signoAmperson.toString()
								+ KEYQPERIODO + SignoIgual + oddlbPeriodo.options[oddlbPeriodo.selectedIndex].value
								+ signoAmperson.toString() 
								+ KEYQMES + SignoIgual + odddblMes.options[odddblMes.selectedIndex].value
								+ signoAmperson.toString()
								+ KEYQTABSELECT + SignoIgual + ohidTabSelect.value
								+ signoAmperson.toString()
								+ KEYQMODO + SignoIgual +  oPagina.Request.Params[KEYQMODO]
								+ signoAmperson.toString()
								+ KEYQVISTA + SignoIgual +  oddlVista.options[oddlVista.selectedIndex].value
								+ signoAmperson.toString();
									
					var ArrData = ["Principales","Auxiliares"];
					var ArrDataUrl=[urlPagina + Parametros + KEYQPPTO + SignoIgual + "Principales" + signoAmperson.toString()
									,urlPagina + Parametros + KEYQPPTO + SignoIgual + "Auxiliares" + signoAmperson.toString()
								   ];
					var ArrDataTollTips = ["",""];
					for (var i=0;i<=ArrData.length-1;i++)
					{
						oTab = new SIMA.Utilitario.Helper.General.Tab(ArrData[i],ArrDataUrl[i],ArrDataTollTips[i]);
						oTab.EventHandle = ObtenerTabSeleccionado;
						oTab.Tag = i;
						oTabStrip.Tabs.Adicionar(oTab);
					}
					oTabStrip.RepintarTabs();
					
					var objHTabSelecionado = $O("hidTabSelect");
					idxSeleccionado = ((objHTabSelecionado.value.toString().length==0)?0:objHTabSelecionado.value);
					oTabStrip.Tabs.Tab(idxSeleccionado).Click();
				}
			}
			
			function ObtenerTabSeleccionado(){
				var objHTabSelecionado = $O("hidTabSelect");
				objHTabSelecionado.value = this.Tag;
				//HistorialIrAdelantePersonalizado("hidTabSelect");
			}
		</script>
	</HEAD>
	<body onunload="HistorialIrAdelantePersonalizado('hidTabSelect'); SubirHistorial();" onload="CargarTabs();ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="tblPrincipal" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td id="CellHeader" width="100%" runat="server"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td id="CellMenu" bgColor="#eff7fa" vAlign="top" width="100%" runat="server"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Presupuestos</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE style="HEIGHT: 94px" id="Table1" border="0" cellSpacing="1" cellPadding="1" width="730">
							<TR>
								<TD width="100%" align="left">
									<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 34px; DISPLAY: none"><asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita" Width="80%">VISTA :</asp:label></TD>
											<TD style="WIDTH: 85px; DISPLAY: none"><asp:dropdownlist id="ddlVista" runat="server" CssClass="combos" Width="88px">
													<asp:ListItem Value="Acumulado">Acumulado</asp:ListItem>
													<asp:ListItem Value="Mensualizado">Mensualizado</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD style="WIDTH: 34px"><asp:label id="Label5" runat="server" CssClass="TextoNegroNegrita" Width="80%">PERIODO :</asp:label></TD>
											<TD style="WIDTH: 70px"><asp:dropdownlist id="ddlbPeriodo" runat="server" CssClass="combos"></asp:dropdownlist></TD>
											<TD style="WIDTH: 31px"><asp:label id="Label4" runat="server" CssClass="TextoNegroNegrita">MES :</asp:label></TD>
											<TD style="WIDTH: 98px"><asp:dropdownlist id="dddblMes" runat="server" CssClass="combos">
													<asp:ListItem Value="1">Enero</asp:ListItem>
													<asp:ListItem Value="2">Febrero</asp:ListItem>
													<asp:ListItem Value="3">Marzo</asp:ListItem>
													<asp:ListItem Value="4">Abril</asp:ListItem>
													<asp:ListItem Value="5">Mayo</asp:ListItem>
													<asp:ListItem Value="6">Junio</asp:ListItem>
													<asp:ListItem Value="7">Julio</asp:ListItem>
													<asp:ListItem Value="8">Agosto</asp:ListItem>
													<asp:ListItem Value="9">Setiembre</asp:ListItem>
													<asp:ListItem Value="10">Octubre</asp:ListItem>
													<asp:ListItem Value="11">Noviembre</asp:ListItem>
													<asp:ListItem Value="12">Diciembre</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD style="WIDTH: 386px"><asp:button style="BACKGROUND-COLOR: #306898; FONT-FAMILY: Arial Narrow; COLOR: #ffffcc; FONT-SIZE: 8pt"
													id="btnConsultar" runat="server" Text="Consultar"></asp:button></TD>
											<TD>
												<asp:button style="Z-INDEX: 0; BACKGROUND-COLOR: #306898; FONT-FAMILY: Arial Narrow; COLOR: #ffffcc; FONT-SIZE: 8pt"
													id="cmdPartidas123" runat="server" Text="Obtener Nat 1,3,5"></asp:button></TD>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="imgXLS" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/xls.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD id="divContenedor" width="100%" align="left">...</TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hidTabSelect" size="1" type="hidden" runat="server">
									<INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hGridPaginaSort" value="0" size="1" type="hidden"
										name="hGridPaginaSort" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" width="100%" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
