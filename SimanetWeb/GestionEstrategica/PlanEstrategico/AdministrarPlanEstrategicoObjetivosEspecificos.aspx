<%@ Page language="c#" Codebehind="AdministrarPlanEstrategicoObjetivosEspecificos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.AdministrarPlanEstrategicoObjetivosEspecificos" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<STYLE>.skin0 { BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; FONT-SIZE: 10px; VISIBILITY: hidden; BORDER-LEFT: black 1px solid; WIDTH: 225px; CURSOR: default; LINE-HEIGHT: 15px; BORDER-BOTTOM: black 1px solid; FONT-FAMILY: Verdana; POSITION: absolute; BACKGROUND-COLOR: #ffffcc }
	.menuitems { PADDING-RIGHT: 10px; PADDING-LEFT: 10px }
		</STYLE>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" bottomMargin="0"
		leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
							<TR>
								<TD colSpan="8">
									<TABLE id="Table1" borderColor="#ffffff" cellSpacing="1" cellPadding="1" width="100%" border="1">
										<TR>
											<TD style="WIDTH: 129px"><asp:label id="Label1" runat="server" ForeColor="Navy" Width="128px" CssClass="TituloPrincipalBlanco">PLAN ESTRATEGICO:</asp:label></TD>
											<TD style="WIDTH: 71px"></TD>
											<TD><asp:label id="lblPlanEstrategico" runat="server" ForeColor="Navy" Width="100%" CssClass="TituloPrincipalBlanco"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 129px"><asp:label id="Label2" runat="server" ForeColor="Navy" Width="128px" CssClass="TituloPrincipalBlanco">OBJETIVO GENERAL:</asp:label></TD>
											<TD style="WIDTH: 71px"><asp:label id="lblObjGral" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco"></asp:label></TD>
											<TD><asp:label id="lblObjetivoGeneral" runat="server" ForeColor="Navy" Width="100%" CssClass="TituloPrincipalBlanco"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD colSpan="4">
									<asp:label id="Label4" runat="server" CssClass="TituloPrincipalBlanco" Width="128px" ForeColor="Navy">OBJETIVO ESPECIFICO</asp:label></TD>
								<TD style="WIDTH: 100%" width="694"></TD>
								<TD style="WIDTH: 100px"></TD>
								<TD style="WIDTH: 186px"></TD>
								<TD style="WIDTH: 186px"></TD>
								<TD style="WIDTH: 186px"></TD>
							</TR>
							<TR bgColor="#f0f0f0">
								<TD><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
								<TD style="WIDTH: 83px"><IMG id="ibtnFiltrarSeleccion" title="Descripcion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
										src="../../imagenes/filtroporseleccion.jpg"></TD>
								<TD style="WIDTH: 18px"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
										ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
								<TD style="WIDTH: 2px"><asp:label id="Label3" runat="server" Width="53px" CssClass="normaldetalle" Font-Bold="True"> Buscar :</asp:label></TD>
								<TD style="WIDTH: 100%" width="694"><INPUT class="InputFind" id="txtBuscar" onkeydown="BusquedaporCampoColumna(this.value);"
										title="Buscar por la Columna Seleccionada" style="BORDER-RIGHT: #999999 1px groove; BORDER-TOP: #999999 1px groove; BORDER-LEFT: #999999 1px groove; WIDTH: 152px; BORDER-BOTTOM: #999999 1px groove"
										type="text" size="20" name="txtBuscar"></TD>
								<td style="WIDTH: 100px"><A class="normaldetalle" href="javascript:history.go(0)">Refrescar</A></td>
								<TD style="WIDTH: 186px">
									<asp:imagebutton id="ibtnIndicadores" runat="server" ImageUrl="../../imagenes/btn_indicadores.gif"></asp:imagebutton></TD>
								<TD style="WIDTH: 186px"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif" CausesValidation="False"></asp:imagebutton></TD>
								<TD style="WIDTH: 186px">
									<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
							</TR>
						</TABLE>
						<cc1:datagridweb id="grid" runat="server" Width="100%" ShowFooter="True" PageSize="7" RowHighlightColor="#E0E0E0"
							AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
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
									<HeaderStyle Width="60%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CO" SortExpression="CO" HeaderText="CO">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="INDICADORES">
									<ItemTemplate>
										<cc1:datagridweb id="gridIndicadores" runat="server" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
											PageSize="7" CellPadding="0" ShowHeader="False">
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
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table3" style="HEIGHT: 28px" cellSpacing="1" cellPadding="1" width="100%" align="center"
							border="0">
							<TR>
								<TD align="left"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
										runat="server" DESIGNTIMEDRAGDROP="20"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server" DESIGNTIMEDRAGDROP="410"><INPUT id="hDescripcion" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hDescripcion"
										runat="server" DESIGNTIMEDRAGDROP="20"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td>
						<!--<DIV class="skin0" id="ie5menu" onclick="jumptoie5()" onmouseout="lowlightie5()" onmouseover="highlightie5()">--></td>
				</tr>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
		</SCRIPT>
	</body>
</HTML>
