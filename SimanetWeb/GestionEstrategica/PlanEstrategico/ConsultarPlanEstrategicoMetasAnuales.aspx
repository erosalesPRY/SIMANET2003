<%@ Page language="c#" Codebehind="ConsultarPlanEstrategicoMetasAnuales.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.ConsultarPlanEstrategicoMetasAnuales" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>

<HTML>
  <HEAD>
		<title>ConsultarPlanEstrategicoBase</title>
		<meta content="False" name="vs_snapToGrid">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<STYLE>.skin0 { BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; FONT-SIZE: 10px; VISIBILITY: hidden; BORDER-LEFT: black 1px solid; WIDTH: 225px; CURSOR: default; LINE-HEIGHT: 15px; BORDER-BOTTOM: black 1px solid; FONT-FAMILY: Verdana; POSITION: absolute; BACKGROUND-COLOR: #ffffcc }
	.menuitems { PADDING-RIGHT: 10px; PADDING-LEFT: 10px }
	</STYLE>
</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" bottomMargin="0"
		leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form2" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Estratégica></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Plan Estratégico</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%" bgColor="#000080"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<cc1:datagridweb id="grid" runat="server" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
							PageSize="7" Width="840px">
<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>

<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="IDOBJETIVOGENERAL">
<HeaderStyle HorizontalAlign="Center" Width="0px" VerticalAlign="Top">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Codigo" SortExpression="Codigo">
<HeaderStyle Width="20px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="OBJETIVO ESTRATEGICO">
<HeaderStyle HorizontalAlign="Center" Width="200px" VerticalAlign="Top">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn>
<HeaderStyle Width="620px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>

<HeaderTemplate>
<TABLE id=Table4 cellSpacing=0 cellPadding=0 width=600 border=1>
<TR>
<TD class=HeaderGrilla colSpan=2>
<asp:label id=Label2 runat="server" CssClass="HeaderGrilla" Width="210px" Height="26px">Objetivos Específicos</asp:label></TD>
<TD>
<asp:label id=Label16 runat="server" CssClass="HeaderGrilla" Width="100px" Height="26px">Indicador</asp:label></TD>
<TD width="60%" colSpan=6>
<asp:label id=lblMetas runat="server" CssClass="HeaderGrilla" Width="100%" Height="26px">metas</asp:label></TD></TR>
<TR>
<TD colSpan=2></TD>
<TD></TD>
<TD>
<asp:label id=lblTotal runat="server" CssClass="headerGrilla" Width="50px" Height="20px">total</asp:label></TD>
<TD>
<asp:label id=lblAno1 runat="server" CssClass="headerGrilla" Width="50px" Height="20px">2000</asp:label></TD>
<TD>
<asp:label id=lblAno2 runat="server" CssClass="headerGrilla" Width="50px" Height="20px">2000</asp:label></TD>
<TD>
<asp:label id=lblAno3 runat="server" CssClass="headerGrilla" Width="50px" Height="20px">2000</asp:label></TD>
<TD>
<asp:label id=lblAno4 runat="server" CssClass="headerGrilla" Width="50px" Height="20px">2000</asp:label></TD>
<TD>
<asp:label id=lblAno5 runat="server" CssClass="headerGrilla" Width="50px" Height="20px">2000</asp:label></TD></TR></TABLE>
</HeaderTemplate>

<ItemTemplate>
<cc1:datagridweb id=gridObjetivosEspecificos1 runat="server" Width="620px" PageSize="7" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" CellPadding="0" ShowHeader="False">
<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>

<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="IdObjetivoEspecifico">
<HeaderStyle Width="0px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Codigo" SortExpression="Codigo">
<HeaderStyle Width="20px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="OBJETIVOS ESPECIFICOS">
<HeaderStyle Width="200px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="METAS">
<HeaderStyle Width="400px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>

<ItemTemplate>
														<cc1:datagridweb id="gridIndicadores" runat="server" Width="100%" PageSize="7" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" CellPadding="0" ShowHeader="False">
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
																<asp:BoundColumn DataField="Periodo1" DataFormatString="{0:# ### ### ### ##0}">
																	<HeaderStyle Width="15%"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Periodo2" DataFormatString="{0:# ### ### ### ##0}">
																	<HeaderStyle Width="15%"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Periodo3" DataFormatString="{0:# ### ### ### ##0}">
																	<HeaderStyle Width="15%"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Periodo4" DataFormatString="{0:# ### ### ### ##0}">
																	<HeaderStyle Width="15%"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Periodo5" DataFormatString="{0:# ### ### ### ##0}">
																	<HeaderStyle Width="15%"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
																</asp:BoundColumn>
															</Columns>
															<HeaderStyle Wrap="False" Height="26px" CssClass="HeaderGrilla"></HeaderStyle>
														</cc1:datagridweb>
														<asp:Image id="Image2" runat="server" Width="400px" Height="0px" ImageAlign="Left"></asp:Image>
													
</ItemTemplate>
</asp:TemplateColumn>
</Columns>

<HeaderStyle Height="26px" CssClass="HeaderGrilla">
</HeaderStyle>
</cc1:datagridweb>
<asp:Image id=Image1 runat="server" Width="620px" Height="0px" ImageAlign="Left"></asp:Image>
</ItemTemplate>
</asp:TemplateColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" Height="26px" CssClass="HeaderGrilla" VerticalAlign="Top">
</HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left" width="100%"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
										runat="server" DESIGNTIMEDRAGDROP="20"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server" DESIGNTIMEDRAGDROP="410"></TD>
							</TR>
							<TR>
								<TD align="left"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
		</SCRIPT>
	</body>
</HTML>
