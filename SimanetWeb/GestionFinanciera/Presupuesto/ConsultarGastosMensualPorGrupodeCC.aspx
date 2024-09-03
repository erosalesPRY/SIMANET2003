<%@ Page language="c#" Codebehind="ConsultarGastosMensualPorGrupodeCC.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.ConsultarGastosMensualPorGrupodeCC" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarEvaluacionGastosdeAdministracion</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>

		<script>
			var KEYQTIPOPRESUPUESTO ="idtp";
			var KEYQIDCENTROOPERATIVO="idCentro";
			var KEYQCENTROOPERATIVONOMBRE = "NombreCentro";
			var KEYQDIGCTA = "digCta";
			var KEYQTIPOOPCION = "Opcion";
			var KEYTIPOINFORMACION = "TipoInfo";
						
			var KEYQPERIODO = "Periodo";
			var KEYQMES = "Mes";
			var KEYQMODO = "Modo";
			var KEYQPPTO = "VISTAPPTO";
			var KEYQVISTA="Vista";
			
			function Resumen(){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var Parametros;
				var Url = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionFinanciera/Presupuesto/ConsultarResumenPorCentroCosto.aspx?"; 
				with(SIMA.Utilitario.Constantes.General.Caracter)
				{
				
					 Parametros =KEYQTIPOPRESUPUESTO + SignoIgual.toString() + oPagina.Request.Params[KEYQTIPOPRESUPUESTO]
					+ signoAmperson.toString() 
					+ KEYQPPTO + SignoIgual.toString() + oPagina.Request.Params[KEYQPPTO]
					+ signoAmperson.toString()
					+ KEYQIDCENTROOPERATIVO + SignoIgual.toString() + oPagina.Request.Params[KEYQIDCENTROOPERATIVO]
					+ signoAmperson.toString()
					+ KEYQCENTROOPERATIVONOMBRE + SignoIgual.toString() + oPagina.Request.Params[KEYQCENTROOPERATIVONOMBRE]
					+ signoAmperson.toString()
					+ KEYQPERIODO + SignoIgual.toString() + oPagina.Request.Params[KEYQPERIODO]
					+ signoAmperson.toString()
					+ KEYQMES + SignoIgual.toString() + oPagina.Request.Params[KEYQMES]
					+ signoAmperson.toString()
					+ KEYQMODO + SignoIgual.toString() + oPagina.Request.Params[KEYQMODO]
					+ signoAmperson.toString();
					//+ KEYTIPOINFORMACION + SignoIgual.toString() + oPagina.Request.Params[KEYTIPOINFORMACION]
					//+ signoAmperson.toString();
					
				}
				switch(oPagina.Request.Params[KEYTIPOINFORMACION])
				{
					case 'ppto':
						oPagina.Response.TopRedirect(Url+ Parametros + KEYTIPOINFORMACION + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + "ppto" );
						break;
					case 'real':
						oPagina.Response.TopRedirect(Url+ Parametros + KEYTIPOINFORMACION + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + "real"); //Solo Gastos indirectos
						break;
					default:
						break;
				}
			}
			
		</script>
	</HEAD>
	<body onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD class="commands"><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Inicio> Gestión Financiera> Prespuesto> Resumen Evaluación Presupuestal por Grupos de Centros de Costo</asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD align="left"><cc1:datagridweb id="grid" runat="server" Width="100%" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
							AllowSorting="True" PageSize="7">
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:Label id="lblCod" runat="server">Label</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="NombreGrupo" SortExpression="NombreGrupo" HeaderText="NOMBRE">
									<HeaderStyle Width="20%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Enero" HeaderText="ENE">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Febrero" HeaderText="FEB">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Marzo" HeaderText="MAR">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Abril" HeaderText="ABR">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Mayo" HeaderText="MAY">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Junio" HeaderText="JUN">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Julio" HeaderText="JUL">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Agosto" HeaderText="AGO">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Setiembre" HeaderText="SET">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Octubre" HeaderText="OCT">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Noviembre" HeaderText="NOV">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Diciembre" HeaderText="DIC">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<HeaderStyle Height="24px" CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><IMG id="imgResumen" alt="" src="../../imagenes/btn_Resume.JPG" onclick = "Resumen();"></TD>
				</TR>
			</TABLE>
		</form>
		<script>
			/*var ParentDocument = window.parent.document.body.document;
			var idx=0;
			var _AnchoCol=0;
			
			var Collecion= new Enumerator($O("grid").rows[0].cells);
			for(Collecion.moveFirst(); !Collecion.atEnd(); Collecion.moveNext()){
				if(parseInt(Collecion.item().CellIndex,10) <=1){
					_AnchoCol = ((5 + _AnchoCol) + parseInt(Collecion.item().offsetWidth,10));				
				}
				else{
					ParentDocument.all["tblResumenMensual"].rows[0].cells[idx].width = _AnchoCol +"px";
					_AnchoCol = parseInt(Collecion.item().offsetWidth,10);				
					idx ++;
				}
			}
			ParentDocument.all["tblResumenMensual"].rows[0].cells[idx].width = _AnchoCol +"px";
			delete Collecion;
			Collecion = null;			
			*/
					
		</script>
	</body>
</HTML>
