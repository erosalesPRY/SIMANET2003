<%@ Page language="c#" Codebehind="BusquedaAccionControl.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.BusquedaAccionControl" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BusquedaPromotores</title>
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
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="610" align="center" border="0">
				<TR>
					<TD class="TituloPrincipal" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="550" bgColor="#f5f5f5"
							border="0">
							<TR bgColor="#ffffff">
								<TD class="TitFiltros"><IMG height="14" src="../imagenes/TitFiltros.gif" width="82"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros" align="left">&nbsp;<INPUT id="hIdAccionControlPosterior" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
										name="hIdAccionControlPosterior" runat="server"><INPUT id="hAccionControlPosterior" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
										name="hAccionControlPosterior" runat="server"></TD>
								<TD class="combos"></TD>
								<TD class="combos"><asp:label id="lblDescripcion" runat="server" CssClass="normal">Denominacion de la Accion</asp:label></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros"></TD>
								<TD class="combos"></TD>
								<TD class="combos"><asp:textbox id="txtDenominacion" runat="server" CssClass="normal" Width="370px"></asp:textbox></TD>
								<TD class="combos"><cc2:requireddomvalidator id="rfvDenominacion" runat="server" CssClass="normal" ControlToValidate="txtDenominacion">*</cc2:requireddomvalidator></TD>
								<TD class="combos"><asp:imagebutton id="btnBuscar" runat="server" ImageUrl="../imagenes/bt_Buscar.GIF"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="550" border="0">
							<TR>
								<TD align="center" colSpan="3"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="600px" AllowSorting="True"
										AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" DataKeyField="IdAccionCtrlPosterior">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="IdAccionCtrlPosterior"></asp:BoundColumn>
											<asp:BoundColumn DataField="Denominacion" SortExpression="Denominacion" HeaderText="DENOMINACION"></asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False" DESIGNTIMEDRAGDROP="56"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><cc2:domvalidationsummary id="vSum" runat="server" CssClass="normal" Width="96px" EnableClientScript="False"
										ShowMessageBox="True" DisplayMode="List"></cc2:domvalidationsummary></TD>
							</TR>
						</TABLE>
						<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../imagenes/spacer.gif" width="160">
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table8" width="180" border="0">
							<TR>
								<TD width="198">&nbsp;<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../imagenes/bt_aceptar.gif"
										Height="22px"></asp:imagebutton></TD>
								<TD width="94"><asp:image id="imgCancelar" runat="server" Width="87px" ImageUrl="../imagenes/bt_cancelar.gif"
										Height="22px"></asp:image></TD>
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
				opener.document.forms[0].hIdAccionControlPosterior.value =document.forms[0].hIdAccionControlPosterior.value;
				opener.document.forms[0].txtAccionCtrlPosterior.value =document.forms[0].hAccionControlPosterior.value;
				window.close();
			} 
		</script>
	</body>
</HTML>
