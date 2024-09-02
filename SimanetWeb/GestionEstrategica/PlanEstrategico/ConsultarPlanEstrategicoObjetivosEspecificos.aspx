<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="ConsultarPlanEstrategicoObjetivosEspecificos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.ConsultarPlanEstrategicoObjetivosEspecificos" %>
<HTML>
	<HEAD>
		<title>ConsultarPlanEstrategicoObjetivosEspecificos</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<STYLE>.skin0 { BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; FONT-SIZE: 10px; VISIBILITY: hidden; BORDER-LEFT: black 1px solid; WIDTH: 225px; CURSOR: default; LINE-HEIGHT: 15px; BORDER-BOTTOM: black 1px solid; FONT-FAMILY: Verdana; POSITION: absolute; BACKGROUND-COLOR: #ffffcc }
	.menuitems { PADDING-RIGHT: 10px; PADDING-LEFT: 10px }
		</STYLE>
		<SCRIPT>
			function chkTodas(miCheckBoxListName) 
			{ 
				var i =0; 
				var sigue = true; 
				while (sigue) 
				{ 
					var chk= document.getElementById(miCheckBoxListName + "_" + i);
					if (chk != null) 
						chk.checked = document.getElementById("chkTodos").checked; 
					else 
						sigue = false; 
					i++; 
				} 
			} 
		</SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form2" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE style="HEIGHT: 24px" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD colSpan="8" rowSpan="1">
									<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1" borderColor="#ffffff">
										<TR>
											<TD style="WIDTH: 129px">
												<asp:Label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" Width="128px" ForeColor="Navy">PLAN ESTRATEGICO:</asp:Label></TD>
											<TD style="WIDTH: 71px"></TD>
											<TD>
												<asp:Label id="lblPlanEstrategico" runat="server" CssClass="TituloPrincipalBlanco" Width="100%"
													ForeColor="Navy"></asp:Label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 129px">
												<asp:Label id="Label2" runat="server" CssClass="TituloPrincipalBlanco" Width="128px" ForeColor="Navy">OBJETIVO GENERAL:</asp:Label></TD>
											<TD style="WIDTH: 71px">
												<asp:label id="lblObjGral" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"></asp:label></TD>
											<TD>
												<asp:Label id="lblObjetivoGeneral" runat="server" CssClass="TituloPrincipalBlanco" Width="100%"
													ForeColor="Navy"></asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR bgColor="#f0f0f0">
								<TD><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
								<TD><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
										src="../../imagenes/filtroporseleccion.jpg" title="Descripcion"></TD>
								<TD><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
										ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
								<TD>
									<asp:label id="Label3" runat="server" CssClass="normaldetalle" Width="53px" Font-Bold="True"> Buscar :</asp:label></TD>
								<TD width="100%"><INPUT class="InputFind" id="txtBuscar" onkeydown="BusquedaporCampoColumna(this.value);"
										title="Buscar por la Columna Seleccionada" style="BORDER-RIGHT: #999999 1px groove; BORDER-TOP: #999999 1px groove; BORDER-LEFT: #999999 1px groove; WIDTH: 152px; BORDER-BOTTOM: #999999 1px groove"
										type="text" size="20" name="txtBuscar"></TD>
								<TD>
									<asp:label id="Label6" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco">SEGURIDAD</asp:label></TD>
								<TD>&nbsp;
									<asp:dropdownlist id="ddlbNivel" runat="server" CssClass="NormalDetalle"></asp:dropdownlist></TD>
								<TD>
									<asp:Button id="btnFiltrar" runat="server" Text="Aplicar Filtro" CssClass="normaldetalle"></asp:Button></TD>
								<TD></TD>
							</TR>
						</TABLE>
						<cc1:datagridweb id="grid" runat="server" Width="100%" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
							RowHighlightColor="#E0E0E0" PageSize="7" ShowFooter="True">
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="NRO">
									<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Codigo" SortExpression="Codigo" HeaderText="CODIGO">
									<HeaderStyle Width="3%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCION">
									<HeaderStyle Width="50%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CO" SortExpression="CO" HeaderText="CO">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Indicadores">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<cc1:datagridweb id="gridIndicadores" runat="server" Width="100%" PageSize="7" RowHighlightColor="#E0E0E0"
											AutoGenerateColumns="False" CellPadding="0" ShowHeader="False">
											<PagerStyle CssClass="PagerGrilla" Wrap="False" Mode="NumericPages"></PagerStyle>
											<AlternatingItemStyle Wrap="False" CssClass="Alternateitemgrilla"></AlternatingItemStyle>
											<EditItemStyle Wrap="False"></EditItemStyle>
											<FooterStyle Wrap="False" CssClass="FooterGrilla"></FooterStyle>
											<SelectedItemStyle Wrap="False"></SelectedItemStyle>
											<ItemStyle Wrap="False" CssClass="ItemGrilla"></ItemStyle>
											<Columns>
												<asp:BoundColumn DataField="DESCRIPCION" HeaderText="INDICADOR">
													<HeaderStyle Width="40%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn HeaderText="Total">
													<HeaderStyle Width="15%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
											<HeaderStyle Wrap="False" Height="26px" CssClass="HeaderGrilla"></HeaderStyle>
										</cc1:datagridweb>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<HeaderStyle Height="26px" CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" align="center" width="100%"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left" width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="70%" border="0">
							<TR>
								<TD colSpan="7">
									<asp:label id="Label10" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco" Visible="False">FILTROS</asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label7" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco" Visible="False">TIPO DE INVERSIÓN</asp:label></TD>
								<TD vAlign="top">
									<asp:label id="Label5" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco" Visible="False">NATURALEZA</asp:label></TD>
								<TD vAlign="top"></TD>
								<TD vAlign="top">
									<asp:label id="Label4" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco" Visible="False">AÑO</asp:label></TD>
								<TD vAlign="top">
									<asp:label id="Label8" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco" Visible="False">IMPORTANCIA</asp:label></TD>
								<TD vAlign="top">
									<asp:label id="Label9" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco" Visible="False">PRIORIDAD</asp:label></TD>
								<TD vAlign="top" rowSpan="2"></TD>
							</TR>
							<TR>
								<TD>
									<asp:checkbox id="chkTodos" onclick="chkTodas('chkListTipoInversion')" runat="server" CssClass="NormalDetalle"
										Font-Bold="True" Text="Todos" Visible="False"></asp:checkbox>
									<asp:checkboxlist id="chkListTipoInversion" runat="server" CssClass="NormalDetalle" CellPadding="0"
										CellSpacing="0" Visible="False"></asp:checkboxlist></TD>
								<TD vAlign="top">
									<asp:dropdownlist id="ddlbTi" runat="server" CssClass="NormalDetalle" Visible="False"></asp:dropdownlist></TD>
								<TD vAlign="top"></TD>
								<TD vAlign="top">
									<asp:dropdownlist id="ddlbAno" runat="server" CssClass="NormalDetalle" Visible="False"></asp:dropdownlist></TD>
								<TD vAlign="top">
									<asp:dropdownlist id="ddlbImportancia" runat="server" CssClass="NormalDetalle" Visible="False"></asp:dropdownlist></TD>
								<TD vAlign="top">
									<asp:dropdownlist id="ddlbPrioridad" runat="server" CssClass="NormalDetalle" Visible="False"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<TR>
								<TD align="right"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
										runat="server" DESIGNTIMEDRAGDROP="20"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server" DESIGNTIMEDRAGDROP="410"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td>
						<!--<DIV class="skin0" id="ie5menu" onclick="jumptoie5()" onmouseout="lowlightie5()" onmouseover="highlightie5()">-->
					</td>
				</tr>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
		</SCRIPT>
	</body>
</HTML>
