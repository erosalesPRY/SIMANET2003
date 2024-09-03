<%@ Page language="c#" Codebehind="ConsultarEstadosFinancierosPorCentro.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio.ConsultarEstadosFinancierosPorCentro" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="ControlesWeb" Assembly="ControlesWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/FrameCallBack.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js">  </SCRIPT>
		<script>
				
				var KEYQNOMBRERUBRO = "NRubro";
				var KEYQIDFORMATO = "IdFormato";
				var KEYQIDRUBRO = "IdRubro";
				var KEYQIDFECHA = "efFecha";
				var KEYQIDEMPRESA = "idEmp";
				var KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
				var KEYQIDIDTIPOINFORMACION ="idTipoInfo";
				var KEYQIDINTERFAZ = "interfaz";
				var NODOSELECCIONADO="NodoSeleccionado";

			function  MostrarDescripciondeRubro()
			{
				var URLDETALLECONCEPTO = "/GestionFinanciera/EstadosFinancieros/Directorio/ConsultarFormatoRubroMovimientoVCV2.aspx?";
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var e = window.event.srcElement
				var tblNodo =e.parentElement.parentElement.parentElement;//tblNodo
				var FilaPrincipal = tblNodo.parentElement.parentElement;

				var strData = FilaPrincipal.getAttribute("OBSERVACIONES");
				var NombreRubro = FilaPrincipal.getAttribute("NOMBRERUBRO");
				var idRubro = FilaPrincipal.getAttribute("IDRUBRO");
				var Parametros="";
				
				with(SIMA.Utilitario.Constantes.General.Caracter)
				{
					Parametros = KEYQIDFORMATO + SignoIgual.toString() + oPagina.Request.Params[KEYQIDFORMATO]
								+ signoAmperson.toString() 
								+ KEYQIDRUBRO + SignoIgual.toString() + idRubro
								+ signoAmperson.toString() 
								+ KEYQNOMBRERUBRO + SignoIgual.toString() +  NombreRubro
								+ signoAmperson.toString() 
								+ KEYQIDFECHA + SignoIgual.toString() +  oPagina.Request.Params[KEYQIDFECHA]
								+ signoAmperson.toString() 
								+ KEYQIDCENTROOPERATIVO + SignoIgual.toString() +  oPagina.Request.Params["IdCentro"]
								+ signoAmperson.toString() 
								+ KEYQIDIDTIPOINFORMACION + SignoIgual.toString() +  '0'
								+ signoAmperson.toString() 
								+ KEYQIDINTERFAZ + SignoIgual.toString() +  '0';
				}
				
				var Datos=new Array();
				//Datos=window.showModalDialog(ObtenerPathAppWeb()+ "/Editor/Editor.aspx",strData,"dialogWidth:630px;dialogHeight:400px"); 
				Datos=window.showModalDialog(ObtenerPathAppWeb()+ URLDETALLECONCEPTO + Parametros ,strData,"dialogWidth:630px;dialogHeight:400px"); 
			}
			
			function ObtenerParametros(strParametros)
			{
				var e = window.event.srcElement
				var tblNodo =e.parentElement.parentElement.parentElement;//tblNodo
				var FilaPrincipal = tblNodo.parentElement.parentElement;
				
				return strParametros + FilaPrincipal.getAttribute("NRONIVEL");
			}

			
			/*Permitira restaurar el nodo selecconado*/
			function RestauraNodoSeleccionado()
			{
				var oDataGrid = document.all["grid"];
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var NodoValor = oPagina.Request.Params[NODOSELECCIONADO];
				if (NodoValor!= undefined)
				{
					var arrNiveles = NodoValor.split(".");
					var UltElemento = arrNiveles.length-1;
					var Indice=0;
					var stNivelFind =ElaborarNiveles(Indice,arrNiveles);
					for(var Fila=0;Fila<=oDataGrid.rows.length-1;Fila++)
					{
						if (oDataGrid.rows[Fila].NRONIVEL == stNivelFind)
						{
							if (Indice<UltElemento)
							{
								var objTblNodo = oDataGrid.rows[Fila].cells(0).children[0];
								var nroCelda = (objTblNodo.rows[0].cells.length-3);
								var ObjImg = objTblNodo.rows[0].cells(nroCelda).children[0];
								ObjImg.onclick();
								Indice++;
								stNivelFind =ElaborarNiveles(Indice,arrNiveles);
							}
						}
					}
				}
			}
			
			function ElaborarNiveles(Indice,arrNiveles)
			{
				var stNivelFind="";
				for(var i=0;i<=Indice;i++){	stNivelFind += arrNiveles[i] + ".";}
				return stNivelFind.substring(0,stNivelFind.length-1);
			}	
			function ABRIR()
			{
				var a = document.getElementById("idContent").innerHTML;
				var frog = window.open("","wildebeast","width=300,height=300,scrollbars=1,resizable=1")
				var html = '';
				html += a ;

				//variable name of window must be included for all three of the following methods so that
				//javascript knows not to write the string to this window, but instead to the new window

				frog.document.open()
				frog.document.write(html);
				frog.document.close()

			}
		
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="RestauraNodoSeleccionado();ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<script language="JavaScript" src="../../../js/wz_tooltip.js" type="text/javascript"></script>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="right" colSpan="3">
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR bgColor="#f0f0f0">
								<TD align="left">
									<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
										<TR>
											<TD style="WIDTH: 52px"></TD>
											<TD style="WIDTH: 36px"></TD>
											<TD style="WIDTH: 24px"></TD>
											<TD style="WIDTH: 88px"></TD>
											<TD align="right"><asp:imagebutton id="ibtnAbrir" ImageUrl="..\..\..\imagenes\bt_abrir.gif" Runat="server"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 52px"><asp:label id="Label3" runat="server" Font-Bold="True" Width="80%" ForeColor="Navy" CssClass="TituloPrincipalBlanco">PERIODO :</asp:label></TD>
											<TD style="WIDTH: 36px"><asp:label id="lblPeriodo" runat="server" Font-Bold="True" Width="32px" ForeColor="Navy" CssClass="TituloPrincipalBlanco"> 2005</asp:label></TD>
											<TD style="WIDTH: 24px"><asp:label id="Label2" runat="server" Font-Bold="True" ForeColor="Navy" CssClass="TituloPrincipalBlanco">MES :</asp:label></TD>
											<TD style="WIDTH: 88px"><asp:label id="lblMes" runat="server" Font-Bold="True" Width="80%" ForeColor="Navy" CssClass="TituloPrincipalBlanco">Periodo :</asp:label></TD>
											<TD align="center"><asp:label id="lblTitulo" runat="server" Font-Bold="True" Width="373px" ForeColor="Navy" CssClass="TituloPrincipalBlanco">EN MILES DE NUEVOS SOLES</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD id="idContent"><cc1:datagridweb id="grid" runat="server" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="CONCEPTO" SortExpression="CONCEPTO" HeaderText="CONCEPTO">
												<HeaderStyle Width="25%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="EjecucionRealDelmesAnterior" HeaderText="Mes&lt;br&gt;Anterior">
												<HeaderStyle Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="DEL MES">
												<HeaderStyle Width="23.33%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="3">
																<asp:Label id="lblDelMes" runat="server" CssClass="HeaderGrilla" BorderStyle="None">FEBRERO</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="28.33%">
																<asp:Label id="lblDelMesRealH" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="Gasto real del mes">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="28.33%">
																<asp:Label id="lblDelMesPPTOH" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="Prespuesto del mes">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="20.33%">
																<asp:Label id="lblDelMesVarH" runat="server" CssClass="HeaderGrilla" BorderStyle="None">DIF.</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table6" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="28.33%">
																<asp:Label id="lblDelMesReal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="28.33%">
																<asp:Label id="lblDelMesPPTO" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="20.33%">
																<asp:Label id="lblDelMesVar" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VAR(%)</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="ACUMULADO">
												<HeaderStyle Width="23.33%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="3">
																<asp:Label id="lblAcumulado" runat="server" CssClass="HeaderGrilla" BorderStyle="None">ACUMULADO</asp:Label></TD>
														</TR>
														<TR>
															<TD noWrap align="center" width="28.33%">
																<asp:Label id="lblAcumRealHH" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="Gasto real al mes">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="center" width="28.33%">
																<asp:Label id="lblAcumPPTOHH" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="Prespuesto al mes">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="center" width="20.33%">
																<asp:Label id="lblAcumVarHH" runat="server" CssClass="HeaderGrilla" BorderStyle="None">DIF.</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table7" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="28.33%">
																<asp:Label id="lblAcumReal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="28.33%">
																<asp:Label id="lblAcumPPTO" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="20.33%">
																<asp:Label id="lblAcumVar" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VAR(%)</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="PROYECTADO ANUAL">
												<HeaderStyle Width="23.33%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="3">
																<asp:Label id="lblProyectado" runat="server" CssClass="HeaderGrilla" BorderStyle="None">VARIACION ANUAL</asp:Label></TD>
														</TR>
														<TR>
															<TD noWrap align="center" width="28.33%">
																<asp:Label id="lblProyRealH" runat="server" CssClass="HeaderGrilla" BorderStyle="None">PROY</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="center" width="28.33%">
																<asp:Label id="lblProyPPTOH" runat="server" CssClass="HeaderGrilla" BorderStyle="None">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="center" width="20.33%">
																<asp:Label id="lblProyVarH" runat="server" CssClass="HeaderGrilla" BorderStyle="None">VAR(%)</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="28.33%">
																<asp:Label id="lblProyReal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="28.33%">
																<asp:Label id="lblProyPPTO" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="20.33%">
																<asp:Label id="lblProyVar" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VAR(%)</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="ObservaciondelCentro"></asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
						</TABLE>
						<asp:hyperlink id="lnkHistor" runat="server" Width="63px" ForeColor="Navy" CssClass="TituloPrincipalBlanco"
							Target="_blank">Histórico</asp:hyperlink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</TD>
				</TR>
			</table>
			<SCRIPT>
				SIMA.Utilitario.Error.TiempoEsperadePagina();
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
