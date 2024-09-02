<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarPlanEstrategicoObjetivoGeneral.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.ConsultarPlanEstrategicoObjetivoGeneral" %>

<HTML>
  <HEAD>
		<title>ConsultarPlanEstrategicoObjetivoGeneral</title>
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<BODY onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" bottomMargin="0"
		leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<STYLE>.skin0 { BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; FONT-SIZE: 10px; VISIBILITY: hidden; BORDER-LEFT: black 1px solid; WIDTH: 225px; CURSOR: default; LINE-HEIGHT: 15px; BORDER-BOTTOM: black 1px solid; FONT-FAMILY: Verdana; POSITION: absolute; BACKGROUND-COLOR: #ffffcc }
	.menuitems { PADDING-RIGHT: 10px; PADDING-LEFT: 10px }
	</STYLE>
		<SCRIPT>
			function ValidarSeleccion()
			{
				if (document.all["hidCentro"].value.length==0)
				{
					window.alert("Seleccionar registro..");
					return false;
				}
				return true;
			}
			
			function Mostrardg()
			{
				var odatagrid = document.all["grid1"];
				odatagrid.style.display = "block";
			}

			function Ocultardg()
			{
				var odatagrid = document.all["grid1"];
				odatagrid.style.display = "none";
			}
			
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
		<form id="Form2" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr id="id1">
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr id="id2">
					<td style="HEIGHT: 23px" vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR id="id3">
					<TD class="RutaPaginaActual" style="HEIGHT: 22px" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Estrategica></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Objetivos Generales</asp:label></TD>
				</TR>
				<TR id="id9">
					<TD vAlign="top" align="center" width="100%">
						<TABLE style="HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR id="id4">
								<TD style="WIDTH: 28px" colSpan="3"><asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" Width="128px" ForeColor="Navy">PLAN ESTRATEGICO:</asp:label></TD>
								<TD style="WIDTH: 9px" colSpan="4"><asp:label id="lblPlanEstrategico" runat="server" CssClass="TituloPrincipalBlanco" Width="384px"
										ForeColor="Navy">PLAN ESTRATEGICO:</asp:label></TD>
								<TD>
									<asp:label id="Label6" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy">SEGURIDAD</asp:label></TD>
								<TD>
									<asp:dropdownlist id="ddlbNivel" runat="server" CssClass="NormalDetalle"></asp:dropdownlist></TD>
								<TD align="right" width="4">
									<asp:Button id="btnFiltrar" runat="server" Text="Aplicar Filtro" CssClass="normaldetalle"></asp:Button></TD>
							</TR>
							<TR id="id5" bgColor="#f0f0f0">
								<TD style="WIDTH: 28px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
								<TD><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
								<TD style="WIDTH: 138px"><IMG id="ibtnFiltrarSeleccion" title="Descripcion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
										src="../../imagenes/filtroporseleccion.jpg"></TD>
								<TD style="WIDTH: 9px"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
										ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
								<TD style="WIDTH: 2px"><asp:label id="Label3" runat="server" CssClass="normaldetalle" Width="53px" Font-Bold="True"> Buscar :</asp:label></TD>
								<TD width="100%"><INPUT class="InputFind" id="txtBuscar" onkeydown="BusquedaporCampoColumna(this.value);"
										title="Buscar por la Columna Seleccionada" style="BORDER-RIGHT: #999999 1px groove; BORDER-TOP: #999999 1px groove; BORDER-LEFT: #999999 1px groove; WIDTH: 152px; BORDER-BOTTOM: #999999 1px groove"
										type="text" size="20" name="txtBuscar"></TD>
								<TD style="WIDTH: 186px"></TD>
								<TD></TD>
								<TD></TD>
								<TD align="right"><IMG id="ImgImprimir" style="CURSOR: hand" onclick="Mostrardg();oPrint = new SIMA.Utilitario.Helper.Dialogos();oPrint.VistaPrevia(this,id1,id2,id3,id4,id5,id6,id7,id8,id9);Ocultardg();"
										alt="" src="../../imagenes/bt_imprimir.gif"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
							</TR>
						</TABLE>
						<cc1:datagridweb id="grid" runat="server" Width="100%" ShowFooter="True" PageSize="7" RowHighlightColor="#E0E0E0"
							AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>

<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO">
<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Codigo" SortExpression="Codigo" HeaderText="CODIGO">
<HeaderStyle Width="3%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCION">
<HeaderStyle Width="66%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="FUNDAMENTO" SortExpression="FUNDAMENTO" HeaderText="FUNDAMENTO">
<HeaderStyle Width="30%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="REQUERIMIENTO" SortExpression="REQUERIMIENTO" HeaderText="REQUERIMIENTO">
<HeaderStyle Width="20%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TEMA" SortExpression="TEMA" HeaderText="TEMA">
<HeaderStyle Width="30%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle Height="26px" CssClass="HeaderGrilla">
</HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR id="id6">
					<TD vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR id="id7">
					<TD vAlign="top" align="left" width="100%">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="70%" border="0">
							<TR>
								<TD colSpan="7"><asp:label id="Label2" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Visible="False">FILTROS</asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label7" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Visible="False">TIPO DE INVERSIÓN</asp:label></TD>
								<TD vAlign="top">
									<asp:label id="Label5" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Visible="False">NATURALEZA</asp:label></TD>
								<TD vAlign="top"></TD>
								<TD vAlign="top">
									<asp:label id="Label4" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Visible="False">AÑO</asp:label></TD>
								<TD vAlign="top">
									<asp:label id="Label8" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Visible="False">IMPORTANCIA</asp:label></TD>
								<TD vAlign="top">
									<asp:label id="Label9" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Visible="False">PRIORIDAD</asp:label></TD>
								<TD vAlign="top" rowSpan="2"></TD>
							</TR>
							<TR>
								<TD>
									<asp:checkbox id="chkTodos" onclick="chkTodas('chkListTipoInversion')" runat="server" CssClass="NormalDetalle"
										Font-Bold="True" Text="Todos" Visible="False"></asp:checkbox>
									<asp:checkboxlist id="chkListTipoInversion" runat="server" CssClass="NormalDetalle" CellSpacing="0"
										CellPadding="0" Visible="False"></asp:checkboxlist></TD>
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
					<TD vAlign="top" align="left" width="100%">
						<cc1:datagridweb id="grid1" runat="server" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
							PageSize="7">
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="CODIGO">
									<ItemTemplate>
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
											<TR>
												<TD align="center" width="10%">
													<asp:Label id="lblOG" runat="server" CssClass="ItemGrilla" ForeColor="Navy" BorderStyle="None">OG</asp:Label></TD>
												<TD align="center" width="15%">
													<asp:Label id="lblOE" runat="server" CssClass="ItemGrilla" ForeColor="Navy" BorderStyle="None">OE</asp:Label></TD>
												<TD align="center" width="20%">
													<asp:Label id="lblACC" runat="server" CssClass="ItemGrilla" ForeColor="Navy" BorderStyle="None">ACC</asp:Label></TD>
												<TD align="center" width="55%">
													<asp:Label id="lblACT" runat="server" CssClass="ItemGrilla" ForeColor="Navy" BorderStyle="None">ACT</asp:Label></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="DESCRIPCION" HeaderText="DESCRIPCION">
									<HeaderStyle Width="80%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<HeaderStyle Height="26px" CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR id="id8">
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
										runat="server" DESIGNTIMEDRAGDROP="20"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server" DESIGNTIMEDRAGDROP="410"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</BODY>
</HTML>
