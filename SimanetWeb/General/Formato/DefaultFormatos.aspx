<%@ Page language="c#" Codebehind="DefaultFormatos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Formato.DefaultFormatos" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>DefaultAdministrarEstadosFinancieros</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js">  </SCRIPT>
		<script>
			var KEYQIDFORMATO="IdFormato";
			var KEYQPERIODO = "Periodo";
			var KEYQIDGRUPOFORMATO="IdGrupoFormato";
			var KEYQIDREPORTE = "IdReporte";
			var KEYQREQCTATABLE="ReqCta";
			var KEYQACUMULADO="Acum";
			var KEYQIDTIPOFORMATO ="IdTipForm";
			function FormatoBE(INDEX,IDREPORTE,CODIGO,NOMBRE,IDTIPOFORMATO,REQCTACTABLE){
				this.Index=INDEX;
				this.IdReporte=IDREPORTE;
				this.Codigo=CODIGO;
				this.Nombre=NOMBRE;
				this.IdTipoFormato = IDTIPOFORMATO
				this.ReqCtaCtable = REQCTACTABLE;

			}
			function TabSeleccionado(){
				var oFormatoBE = new FormatoBE();
				oFormatoBE = this.Tag;
				var _hTabSeleccionado = $O("hTabSeleccionado");
				var _hCodigoFormato = $O("hCodigoFormato");
				var _hIdReporte = $O("hIdReporte");
				_hCodigoFormato.value=oFormatoBE.Codigo;
				_hTabSeleccionado.value = oFormatoBE.Index;
				_hIdReporte.value = oFormatoBE.IdReporte;
			}
			function Tab_Editable(){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var oFormatoBE = new FormatoBE();
					oFormatoBE = this.Tag;
					if(this.Modo=="M"){
						var URLDETALLE = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/DetalleFormato.aspx?" 
										+ KEYQIDFORMATO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oFormatoBE.Codigo
										+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
										+ KEYQIDREPORTE + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oFormatoBE.IdReporte
										+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
										+ SIMA.Utilitario.Constantes.KEYMODOPAGINA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + SIMA.Utilitario.Enumerados.ModoPagina.M
										+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
										+ KEYQIDGRUPOFORMATO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQIDGRUPOFORMATO];
						oPagina.Response.ShowDialogoNoModal(URLDETALLE,600,310);
					}
					else{
						if(confirm("desea ud eliminar este formato ahora?")==true){
							(new Controladora.General.CFormato()).Eliminar(oFormatoBE.Codigo);
							document.location.reload();
						}
					}
					
			}
			
			function Formato(){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var URLDETALLE = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/DetalleFormato.aspx?" 
				var URLCOPIARFORMATO=SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/CopiarFormato.aspx?";
				this.Copiar=function(){				
					var Parametros = KEYQIDFORMATO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + $O("hCodigoFormato").value
									+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
									+ KEYQIDGRUPOFORMATO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQIDGRUPOFORMATO]
									+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
									+ KEYQIDREPORTE + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual +  $O("hIdReporte").value;
									
																
					oPagina.Response.ShowDialogoNoModal(URLCOPIARFORMATO+Parametros,640,310);
				}
				/*-------------------------------------------------------------------------------------------------------------------------------------------------*/				
				this.Crear=function(){
					var Parametros=SIMA.Utilitario.Constantes.KEYMODOPAGINA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + SIMA.Utilitario.Enumerados.ModoPagina.N
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQIDGRUPOFORMATO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQIDGRUPOFORMATO];
					oPagina.Response.ShowDialogoNoModal(URLDETALLE+Parametros,620,310);
				}
				/*-------------------------------------------------------------------------------------------------------------------------------------------------*/
				this.Load=function(){
					var oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip($O("divContenedor"));
					oTabStrip.PathImagen= SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/Imagenes/Tabs/";
					var Parametros;
					///var pidReporte =1;
					var URLFORMATOS = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/AdministrarFormatoEstructura.aspx?";
					var Existe=false;
						with(SIMA.Utilitario.Constantes.General.Caracter){
						//	Parametros = "IdReporte" + SignoIgual.toString() + pidReporte;
							var oDataTable = new System.Data.DataTable("tblFormato");
							oDataTable = (new Controladora.General.CFormato()).ListarTodos(oPagina.Request.Params[KEYQIDGRUPOFORMATO],oPagina.Request.Params[SIMA.Utilitario.Constantes.KEYMODOPAGINA]);
							
							for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
									var oDataRow =oDataTable.Rows.Items[f];
									if(oDataRow.Item("EOF")==false){
										Existe=true;
										var oFormatoBE = new FormatoBE();
										oFormatoBE.Index=f;
										oFormatoBE.IdReporte = oDataRow.Item("idReporte");
										oFormatoBE.Codigo = oDataRow.Item("idFormato");
										oFormatoBE.Nombre = oDataRow.Item("Nombre");
										oFormatoBE.IdTipoFormato = oDataRow.Item("IdTipoFormato");
										oFormatoBE.ReqCtaCtable = oDataRow.Item("ReqCtaCtable");
										
										
										var ParametrosFormato = "IdReporte" + SignoIgual.toString() + oFormatoBE.IdReporte
																+ signoAmperson.toString() + KEYQIDFORMATO + SignoIgual.toString() + oFormatoBE.Codigo 
																+ signoAmperson.toString() + "NFormato" + SignoIgual.toString() +  oFormatoBE.Nombre 
																+ signoAmperson.toString() + KEYQPERIODO + SignoIgual.toString() +  $O('hPeriodo').value
																+ signoAmperson.toString() + KEYQREQCTATABLE+ SignoIgual.toString() +  oDataRow.Item("ReqCtaCtable")
																+ signoAmperson.toString() + KEYQACUMULADO + SignoIgual.toString() +  oDataRow.Item("Acumulado")
																+ signoAmperson.toString() + KEYQIDTIPOFORMATO + SignoIgual.toString() +  oDataRow.Item("IdTipoFormato")
																+ signoAmperson.toString() + KEYQIDGRUPOFORMATO + SignoIgual + oPagina.Request.Params[KEYQIDGRUPOFORMATO];
																
										
										//oTab = new SIMA.Utilitario.Helper.General.Tab(oFormatoBE.Nombre,URLFORMATOS + Parametros +ParametrosFormato ,"Administrar " + oFormatoBE.Nombre);
										oTab = new SIMA.Utilitario.Helper.General.Tab(oFormatoBE.Nombre,URLFORMATOS + ParametrosFormato ,"Administrar " + oFormatoBE.Nombre);
										oTab.Tag = oFormatoBE;
										oTab.Editable=true;
										oTab.EventHandle = TabSeleccionado;						
										oTabStrip.Tabs.Adicionar(oTab);
									}
							}							
							if(Existe==true){
								var objTabSeleccionado = $O("hTabSeleccionado");
								oTabStrip.RepintarTabs();
								oTabStrip.Tabs.Tab(((objTabSeleccionado.value.length==0)?0:objTabSeleccionado.value)).Click();
							}	
					}
				}
				/*-------------------------------------------------------------------------------------------------------------------------------------------------*/

			}
			//Crea una instancia de la clase formato
			var oFormato = new Formato();
			
		
		</script>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="oFormato.Load();ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Estados Financieros</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" style="HEIGHT: 73px" cellSpacing="1" cellPadding="1" width="60%" border="0">
							<TR>
								<TD align="left" width="100%">
									<DIV align="left">
										<TABLE style="Z-INDEX: 0" id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%"
											align="left">
											<TR>
												<TD><INPUT style="Z-INDEX: 0; WIDTH: 112px; HEIGHT: 24px" id="ibtnNuevo" onclick="oFormato.Crear();"
														value="Nuevo formato" type="button"></TD>
												<TD></TD>
												<TD><INPUT style="Z-INDEX: 0" id="ibtnCopiarFormato" value="Copiar Formato" type="button" onclick="oFormato.Copiar();"></TD>
												<TD width="100%">
													<asp:Label id="lblGrupoFormato" runat="server" Font-Bold="True" Font-Size="Medium">Label</asp:Label></TD>
											</TR>
										</TABLE>
									</DIV>
								</TD>
							</TR>
							<TR>
								<TD id="divContenedor" style="HEIGHT: 20px" align="left" width="100%" class="TextoNegroNegrita"></TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hTabSeleccionado" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" runat="server"
										NAME="hTabSeleccionado"><INPUT id="hCodigoFormato" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
										runat="server"></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
						<INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
							name="hGridPaginaSort" runat="server"> <INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hPeriodo" value="0" size="1" type="hidden"
							name="hPeriodo" runat="server"> 
      <INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id=hIdReporte value=0 
      size=1 type=hidden name=hPeriodo runat="server">
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
