<%@ Page language="c#" Codebehind="ConsultarPlanEstrategicoActividad.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.ConsultarPlanEstrategicoActividad" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarPlanEstrategicoActividad</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
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
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD>
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" bgColor="#f0f0f0"
										border="0">
										<TR>
										</TR>
										<TR>
											<TD bgColor="#ffffff" colSpan="9">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="2" borderColor="#ffffff">
													<TR>
														<TD style="WIDTH: 62px; HEIGHT: 17px">
															<asp:Label id="Label2" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="128px">PLAN ESTRATEGICO:</asp:Label></TD>
														<TD style="WIDTH: 62px; HEIGHT: 17px"><asp:label id="lblPlanBase" runat="server" CssClass="TituloPrincipalBlanco" Width="70px" ForeColor="Navy"></asp:label></TD>
														<TD style="HEIGHT: 17px"><asp:label id="lblNombrePlanBase" runat="server" CssClass="TituloPrincipalBlanco" Height="2px"
																Width="100%" ForeColor="Navy"></asp:label></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 139px" width="139">
															<asp:Label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="128px">OBJETIVO GENERAL:</asp:Label></TD>
														<TD width="100"><asp:label id="lblObjGral" runat="server" CssClass="TituloPrincipalBlanco" Width="70px" ForeColor="Navy"></asp:label></TD>
														<TD><asp:label id="lblNombreObjGral" runat="server" CssClass="TituloPrincipalBlanco" Height="2px"
																Width="100%" ForeColor="Navy"></asp:label></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 139px" width="139">
															<asp:Label id="Label4" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="136px">OBJETIVO ESPECIFICO:</asp:Label></TD>
														<TD width="100"><asp:label id="lblObjEsp" runat="server" CssClass="TituloPrincipalBlanco" Width="70px" ForeColor="Navy"></asp:label></TD>
														<TD><asp:label id="lblNombreObjEsp" runat="server" CssClass="TituloPrincipalBlanco" Height="2px"
																Width="100%" ForeColor="Navy"></asp:label></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 139px" width="139">
															<asp:Label id="Label5" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="136px">ACCIÓN:</asp:Label></TD>
														<TD width="100">
															<asp:label id="lblAccion" runat="server" CssClass="TituloPrincipalBlanco" Width="70px" ForeColor="Navy"></asp:label></TD>
														<TD>
															<asp:label id="lblNombreAccion" runat="server" CssClass="TituloPrincipalBlanco" Width="100%"
																Height="2px" ForeColor="Navy"></asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 28px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
											<TD style="WIDTH: 138px"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../../imagenes/filtroporseleccion.jpg" title="Descripcion"></TD>
											<TD style="WIDTH: 9px"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD style="WIDTH: 2px">
												<asp:label id="Label14" runat="server" CssClass="normaldetalle" Width="53px" Font-Bold="True"> Buscar :</asp:label></TD>
											<TD width="100%"><INPUT class="InputFind" id="txtBuscar" onkeydown="BusquedaporCampoColumna(this.value);"
													title="Buscar por la Columna Seleccionada" style="BORDER-RIGHT: #999999 1px groove; BORDER-TOP: #999999 1px groove; BORDER-LEFT: #999999 1px groove; WIDTH: 152px; BORDER-BOTTOM: #999999 1px groove"
													type="text" size="20" name="txtBuscar"></TD>
											<TD style="WIDTH: 186px">
												<asp:label id="Label6" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco">SEGURIDAD</asp:label></TD>
											<TD>
												<asp:dropdownlist id="ddlbNivel" runat="server" CssClass="NormalDetalle" DESIGNTIMEDRAGDROP="103"></asp:dropdownlist></TD>
											<TD>
												<P id="P1" style="BACKGROUND-COLOR: #f0f0f0" align="right">
													<asp:Button id="btnFiltrar" runat="server" Text="Aplicar Filtro" CssClass="normaldetalle"></asp:Button></P>
											</TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="100%" RowPositionEnabled="False" ShowFooter="True"
										AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
										PageSize="7">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" DataFormatString="{0:###,##0.00}">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CODIGO" SortExpression="CODIGO" HeaderText="CODIGO">
												<HeaderStyle Width="8%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCI&#211;N">
												<HeaderStyle Width="35%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RESPONSABLE" SortExpression="RESPONSABLE" HeaderText="RESPONSABLE">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PERIODO" SortExpression="PERIODO" HeaderText="ANO">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NIV" SortExpression="NIV" HeaderText="NIVEL">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Indicadores">
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
										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb>
								</TD>
							<TR>
								<TD align="center">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label>
								</TD>
							</TR>
				</TR>
				<TR>
					<TD align="left">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="70%" border="0">
							<TR>
								<TD colSpan="7">
									<asp:label id="Label11" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco" Visible="False">FILTROS</asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label7" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco" Visible="False">TIPO DE INVERSIÓN</asp:label></TD>
								<TD vAlign="top">
									<asp:label id="Label10" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco" Visible="False">NATURALEZA</asp:label></TD>
								<TD vAlign="top"></TD>
								<TD vAlign="top">
									<asp:label id="Label1" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco" Visible="False">AÑO</asp:label></TD>
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
					<TD align="right">&nbsp;<INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 14px" type="hidden" size="1" name="hCodigo"
							runat="server"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
							name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
							runat="server" DESIGNTIMEDRAGDROP="410"><INPUT id="hDescripcionActividad" type="hidden" size="1" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
							NAME="hDescripcionActividad"> <INPUT id="hCodigoActividad" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
							runat="server"> <INPUT id="hNro" style="WIDTH: 16px; HEIGHT: 14px" type="hidden" size="1" name="hCodigo"
							runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/RetornarAlFormato.GIF">
					</TD>
				</TR>
			</TABLE>
			</TD> </TR> </TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
