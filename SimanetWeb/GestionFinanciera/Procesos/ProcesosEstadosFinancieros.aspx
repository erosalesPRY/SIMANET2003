<%@ Page language="c#" Codebehind="ProcesosEstadosFinancieros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Procesos.ProcesosEstadosFinancieros" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ProcesosEstadosFinancieros</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script>
		var KEYINDICADORDEPROCESO="IdProceso";
		var KEYQIDEMPRESA = "idEmp";
		var KEYQIDCENTRO = "IdCentro";
		var KEYQIDFORMATO ="idFormato";
		var PERIODO="Periodo";
		var MES="idMes";
		var KEYQMODO = "Modo";
		var MODO ="P";
		
		var DDLCENTRO = "_ctl4_ddlbCentroOperativo";
		var DDLPERIODO = "_ctl4_ddlbPeriodo";
		var DDLMES = "_ctl4_ddlbMes";
	
		var urlPaginaProceso = SIMA.Utilitario.Helper.General.ObtenerPathApp() +"/GestionFinanciera/Procesos/Procesar.aspx?";
		
		function ProcesarFormatoEstadosFinancieros(idFormato)
		{
			ObjControlesExternos = new SIMA.Utilitario.ControlesExternos();
			var oDDLCentroOperativo = ObjControlesExternos.CrearIntanciaDe(DDLCENTRO);
			var oDDLPeriodo = ObjControlesExternos.CrearIntanciaDe(DDLPERIODO);
			var oDDLMes = ObjControlesExternos.CrearIntanciaDe(DDLMES);
			
			var strListaParametros="";
			var Parametros="";
			with(SIMA.Utilitario.Constantes.General.Caracter)
			{
				Parametros = KEYINDICADORDEPROCESO  +  SignoIgual.toString() + SIMA.Utilitario.Constantes.General.ProcesoCallBack.ProcesarFormulaFormato.toString()
									+ signoAmperson.toString() 
									+ KEYQIDFORMATO +  SignoIgual.toString() + idFormato
									+ signoAmperson.toString() 
									+ KEYQIDCENTRO +  SignoIgual.toString() + oDDLCentroOperativo.options[oDDLCentroOperativo.selectedIndex].value
									+ signoAmperson.toString() 
									+ PERIODO +  SignoIgual.toString() + oDDLPeriodo.options[oDDLPeriodo.selectedIndex].value
									+ signoAmperson.toString() 
									+ MES +  SignoIgual.toString() + oDDLMes.options[oDDLMes.selectedIndex].value
									+ signoAmperson.toString() 
									+ KEYQMODO +  SignoIgual.toString() + MODO;
			}
			var strListaParametros = SIMA.Utilitario.Constantes.General.ProcesoCallBack.ProcesarFormulaFormato.toString();
			oCallBack = new SIMA.Utilitario.Helper.General.CallBack();
			oCallBack.CargarDocumentoXML(urlPaginaProceso + Parametros,strListaParametros,null);			
		}
		
		function EjecutarOpcionSeleccionada(){
			for(var i=0;i<=document.all.length-1;i++)
			{
				var objects = document.all[i];
				if (objects.type=="radio" && objects.checked)
				{
					switch(objects.value)
					{
						case "rbBalanceGeneral":
							ProcesarFormatoEstadosFinancieros(SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Codigo.BalanceGeneral);
							break;
						case "rbEstadodeGananciasyPerdidas":
							ProcesarFormatoEstadosFinancieros(SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Codigo.GananciasyPerdidas);
							break;
						case "rbFlujodeCaja":
							ProcesarFormatoEstadosFinancieros(SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Codigo.FlujodeCaja);
							break;
						case "rbIngresosyEgresos":
							ProcesarFormatoEstadosFinancieros(SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Codigo.IngresosyEgresos);
							break;
						case "rbCuentasporCobraryPagar":
							ProcesarFormatoEstadosFinancieros(SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Codigo.CtasPorCobrarPagar);
							break;
						default:
							break;
					}
					return;
				}
			}
		}




		
		SIMA.Utilitario.ControlesExternos = function(){
			this.CrearIntanciaDe = function(NombreObjecto){
				return document.parentWindow.parent.document.all[NombreObjecto];
			}
		}
		</script>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="right" border="0">
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3"><cc1:datagridweb id="grid" runat="server" PageSize="7" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0" ShowFooter="True" Width="100%">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DescripciondelGrupodeProceso" HeaderText="PROCESO">
												<HeaderStyle Width="40%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="ULTIMA EJECUCION">
												<HeaderStyle Width="60%"></HeaderStyle>
												<ItemTemplate>
													<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="WIDTH: 78px" align="center" width="78" rowSpan="4"><IMG id="imgFotoUsuario" style="BORDER-RIGHT: #0000ff 1px solid; BORDER-TOP: #0000ff 1px solid; BORDER-LEFT: #0000ff 1px solid; WIDTH: 76px; BORDER-BOTTOM: #0000ff 1px solid; HEIGHT: 88px"
																	height="88" alt="" src="file:///C:\Documents and Settings\erosales\Escritorio\5733.jpg" width="76" align="middle" runat="server"></TD>
															<TD class="HeaderDetalle" style="WIDTH: 77px; HEIGHT: 18px" vAlign="middle" width="77">
																<asp:Label id="Label1" runat="server">USUARIO</asp:Label></TD>
															<TD class="ItemDetalle" style="HEIGHT: 18px" width="90%">
																<asp:Label id="lblUsuario" runat="server">Label</asp:Label></TD>
														</TR>
														<TR>
															<TD class="HeaderDetalle" style="WIDTH: 77px" vAlign="middle" width="77">
																<asp:Label id="Label2" runat="server" Width="112px">FECHA DE PROCESO</asp:Label></TD>
															<TD class="AlternateItemDetalle" width="90%">
																<asp:Label id="lblFecha" runat="server">Label</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
