<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarEvaluacionGastosdeAdministracionGrupoCC.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.ConsultarEvaluacionGastosdeAdministracion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarEvaluacionGastosdeAdministracion</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>

		<script>
			try{
				var ParentDocument = window.parent.document.body.document;
				var tbl = ParentDocument.all["tblResumen"];		
				tbl.style.display="block";
				tbl = ParentDocument.all["tblResumenMensual"];
				tbl.style.display="none";
			}
			catch(error){
			}			
			
			
			
			
			function LLamarPaginaProcesar(){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var Parametros;
				var KEYQTIPOPRESUPUESTO = "idtp";
				var KEYQIDCENTROOPERATIVO= "idCentro";
				var KEYQIDPROCESO = "idProceso";
				var KEYQPERIODO = "Periodo";
				var Url = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionFinanciera/Presupuesto/Procesar.aspx?"; 
				with(SIMA.Utilitario.Constantes.General.Caracter){
					Parametros =KEYQTIPOPRESUPUESTO + SignoIgual.toString() + oPagina.Request.Params[KEYQTIPOPRESUPUESTO]
					+ signoAmperson.toString() 
					+ KEYQIDCENTROOPERATIVO + SignoIgual.toString() + oPagina.Request.Params[KEYQIDCENTROOPERATIVO]
					+ signoAmperson.toString()
					+ KEYQIDPROCESO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.ProcesoCallBack.ReportedeResumendeEvaluacionPresupuestal
					+ signoAmperson.toString()
					+ KEYQPERIODO + SignoIgual.toString() + oPagina.Request.Params[KEYQPERIODO];
				}
				oPagina.Response.TopRedirect(Url+ Parametros);
				PopupDeEspera();	
			}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD class="commands"><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Inicio> Gestión Financiera> Prespuesto> Resumen Evaluación Presupuestal por Grupos de Centros de Costo</asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD align="left"><cc1:datagridweb id="grid" runat="server" ShowFooter="True" PageSize="7" AllowSorting="True" AutoGenerateColumns="False"
							RowHighlightColor="#E0E0E0" Width="100%">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="CODIGO">
									<ItemTemplate>
										<asp:Label id="LblCod" runat="server">Label</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="NombreGrupo" SortExpression="NombreGrupo" HeaderText="NOMBRE">
									<HeaderStyle Width="55%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="SIMA-PERU">
									<HeaderTemplate>
										<TABLE id="Table4" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
											<TR>
												<TD style="BORDER-BOTTOM: #cccccc 1px solid" colSpan="3" align="center">
													<asp:Label id="lblEmpresa" runat="server" CssClass="headergrilla" BorderStyle="None">EVALUACION</asp:Label></TD>
											</TR>
											<TR>
												<TD width="33.33%" align="center">
													<asp:Label id="lblHPPTO" runat="server" CssClass="HeaderGrilla" BorderStyle="None">Presupuesto</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" width="33.33%" align="center">
													<asp:Label id="lblHEjecutado" runat="server" CssClass="HeaderGrilla" BorderStyle="None">Ejecutado</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" width="33.33%" align="center">
													<asp:Label id="lblHSaldo" runat="server" CssClass="HeaderGrilla" BorderStyle="None">Saldo</asp:Label></TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left">
											<TR>
												<TD class="ItemGrillaSinColor" width="33.33%" align="right">
													<asp:Label id="lblPrespuesto" runat="server">0.00</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" class="ItemGrillaSinColor" width="33.33%"
													align="right">
													<asp:Label id="lblEjecutado" runat="server">0.00</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" class="ItemGrillaSinColor" width="33.33%"
													align="right">
													<asp:Label id="lblSaldo" runat="server">0.00</asp:Label></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterTemplate>
										<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left">
											<TR>
												<TD class="ItemGrillaSinColor" width="33.33%" align="right">
													<asp:Label id="lblPrespuestoF" runat="server">0.00</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" class="ItemGrillaSinColor" width="33.33%"
													align="right">
													<asp:Label id="lblEjecutadoF" runat="server">0.00</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" class="ItemGrillaSinColor" width="33.33%"
													align="right">
													<asp:Label id="lblSaldoF" runat="server">0.00</asp:Label></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:ImageButton id="imgResumen" runat="server" ImageUrl="../../imagenes/btn_Resume.JPG" ToolTip="REPORTE DE EVALUACION PRESUPUESTAL POR NATURALEZA DE GASTO"></asp:ImageButton></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
