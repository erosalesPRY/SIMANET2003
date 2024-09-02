<%@ Page language="c#" Codebehind="BusquedaOrdenTrabajo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.BusquedaOrdenTrabajo" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BusquedaOrdenTrabajo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="730" align="center" border="0">
				<TR>
					<TD class="TituloPrincipal" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> BUSQUEDA DE ORDENES DE TRABAJO</asp:label></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="500" bgColor="#f5f5f5"
							border="0">
							<TR bgColor="#ffffff">
								<TD class="TitFiltros" width="109"><IMG height="14" src="../imagenes/TitFiltros.gif" width="82"></TD>
								<TD class="combos" style="WIDTH: 152px"></TD>
								<TD class="combos" style="WIDTH: 152px"></TD>
								<TD class="combos" width="3"></TD>
								<TD class="combos" width="3"></TD>
								<TD class="combos" width="3"></TD>
								<TD class="combos"></TD>
							</TR>
							<TR>
								<TD><INPUT id="hIdValorizacionOrdenTrabajo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden"
										size="1" name="hIdValorizacionOrdenTrabajo" runat="server"> <INPUT id="hNroOt" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hNroOt"
										runat="server">
								</TD>
								<TD class="SmallFont" style="WIDTH: 152px" align="center"></TD>
								<TD class="SmallFont" style="WIDTH: 152px" align="center"></TD>
								<TD class="SmallFont" align="center"></TD>
								<TD class="SmallFont" align="center"></TD>
								<TD class="SmallFont" align="center" colSpan="1"></TD>
								<TD class="SmallFont"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros" align="center">&nbsp;
									<asp:label id="lblCentroOperativo" runat="server" CssClass="normal">Centro de Operaciones</asp:label></TD>
								<TD class="combos"></TD>
								<TD class="combos"><asp:label id="lblDivision" runat="server" CssClass="normal"> División</asp:label></TD>
								<TD class="combos"></TD>
								<TD class="combos"><asp:label id="lblnRoOt" runat="server" CssClass="normal">NroOT</asp:label></TD>
								<TD class="combos"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros"><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normal" AutoPostBack="True" Width="136px"></asp:dropdownlist></TD>
								<TD class="combos"><cc2:requireddomvalidator id="rfvCentroOperativo" runat="server" ControlToValidate="ddlbCentroOperativo">*</cc2:requireddomvalidator></TD>
								<TD class="combos"><asp:dropdownlist id="ddlbDivision" runat="server" CssClass="normal" AutoPostBack="True" Width="136px"></asp:dropdownlist></TD>
								<TD class="combos"><cc2:requireddomvalidator id="rfvDivision" runat="server" ControlToValidate="ddlbDivision">*</cc2:requireddomvalidator></TD>
								<TD class="combos"><ew:numericbox id="nbOt" runat="server" CssClass="normal" Width="136px" MaxLength="6" PositiveNumber="True"></ew:numericbox></TD>
								<TD class="combos"></TD>
								<TD class="combos"><asp:imagebutton id="btnBuscar" runat="server" ImageUrl="../imagenes/bt_Buscar.GIF"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" vAlign="top">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="730" border="0">
							<TR>
								<TD align="center" colSpan="3">
									<cc1:datagridweb id="grid" runat="server" Width="720px" DataKeyField="IdValorizacionOrdenTrabajo"
										RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False"
										AllowSorting="True" CssClass="HeaderGrilla">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="IdValorizacionOrdenTrabajo" SortExpression="IdValorizacionOrdenTrabajo"
												HeaderText="IdValorizacionOrdenTrabajo"></asp:BoundColumn>
											<asp:BoundColumn DataField="NroOrdenTrabajo" SortExpression="NroOrdenTrabajo" HeaderText="ORDEN DE TRABAJO"></asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="56"
										Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><cc2:domvalidationsummary id="vSum" runat="server" CssClass="normal" Width="96px" DisplayMode="List" ShowMessageBox="True"
										EnableClientScript="False"></cc2:domvalidationsummary></TD>
							</TR>
						</TABLE>
						<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../imagenes/spacer.gif" width="160">
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table8" width="180" border="0">
							<TR>
								<TD width="198">&nbsp;<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
								<TD width="94">
									<asp:imagebutton id="ibtnCancelar" runat="server" ImageUrl="../imagenes/bt_cancelar.gif"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
		<script>
		<asp:Literal id="ltlMensaje" Runat="server" EnableViewState="False"></asp:Literal>		
		
		function PonerTexto()
			{ 
				opener.document.forms[0].hIdValorizacionOrdenTrabajo.value =document.forms[0].hIdValorizacionOrdenTrabajo.value;
				opener.document.forms[0].txtOT.value =document.forms[0].hNroOt.value;
				window.close();
			} 
		</script>
	</body>
</HTML>
