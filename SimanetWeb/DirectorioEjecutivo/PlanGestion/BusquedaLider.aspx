<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="BusquedaLider.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion.BusquedaLider" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BusquedaLider</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="610" align="center" border="0">
				<TR>
					<TD class="TituloPrincipal" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> BUSQUEDA DE LIDER</asp:label></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="550" bgColor="#f5f5f5"
							border="0">
							<TR bgColor="#ffffff">
								<TD class="TitFiltros"><IMG height="14" src="../../imagenes/TitFiltros.gif" width="82"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros" align="left">&nbsp;<INPUT id="hidCargoLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidCargoLider"
										runat="server"><INPUT id="hIdAreaLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdAreaLider"
										runat="server"><INPUT id="hIdPersonalLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdPersonalLider"
										runat="server"><INPUT id="hNombreLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hNombreLider"
										runat="server"></TD>
								<TD class="combos"></TD>
								<TD class="combos">
									<asp:label id="Label1" runat="server" CssClass="normal">Grupo Centro de Costo</asp:label></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros" style="HEIGHT: 1px" align="left"></TD>
								<TD class="combos" style="HEIGHT: 1px"></TD>
								<TD class="combos" style="HEIGHT: 1px">
									<asp:dropdownlist id="ddlbGrupoCentroCosto" runat="server" CssClass="NormalDetalle" Width="370px"></asp:dropdownlist></TD>
								<TD class="combos" style="HEIGHT: 1px"></TD>
								<TD class="combos" style="HEIGHT: 1px"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros"></TD>
								<TD class="combos"></TD>
								<TD class="combos">
									<asp:label id="lblDescripcion" runat="server" CssClass="normal">Nombre del Lider</asp:label></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros"></TD>
								<TD class="combos"></TD>
								<TD class="combos">
									<asp:textbox id="txtLider" runat="server" CssClass="NormalDetalle" Width="370px" BorderStyle="Solid"></asp:textbox></TD>
								<TD class="combos">
									<cc2:requireddomvalidator id="rfvGrado" runat="server" CssClass="normal" ControlToValidate="txtLider">*</cc2:requireddomvalidator></TD>
								<TD class="combos">
									<asp:imagebutton id="btnBuscar" runat="server" ImageUrl="../../imagenes/bt_Buscar.GIF"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD class="TitFiltros"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="550" border="0">
							<TR>
								<TD align="center" colSpan="3"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="600px" PageSize="7" AllowSorting="True"
										AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" DataKeyField="IDGRUPOCC">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="IDGRUPOCC"></asp:BoundColumn>
											<asp:BoundColumn DataField="AREACA" SortExpression="AREACA" HeaderText="AREA - CARGO">
												<HeaderStyle Width="60%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NOMBRE" HeaderText="LIDER">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="56"
										Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><cc2:domvalidationsummary id="vSum" runat="server" CssClass="normal" Width="96px" EnableClientScript="False"
										ShowMessageBox="True" DisplayMode="List"></cc2:domvalidationsummary></TD>
							</TR>
						</TABLE>
						<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160">
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table8" width="180" border="0">
							<TR>
								<TD width="198">&nbsp;
									<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"
										Height="22px"></asp:imagebutton></TD>
								<TD width="94"><asp:imagebutton id="ibtnCancelar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_cancelar.gif"
										Height="22px"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script>
		<asp:Literal id="ltlMensaje" Runat="server" EnableViewState="False"></asp:Literal>		
		
		function PonerTexto()
			{ 
				opener.document.forms[0].hidCargoLider.value	=document.forms[0].hidCargoLider.value;
				opener.document.forms[0].hIdAreaLider.value		=document.forms[0].hIdAreaLider.value;
				opener.document.forms[0].hIdPersonalLider.value =document.forms[0].hIdPersonalLider.value;
				opener.document.forms[0].txtLider.value			=document.forms[0].hNombreLider.value;
				window.close();
			} 
		</script>
	</body>
</HTML>
