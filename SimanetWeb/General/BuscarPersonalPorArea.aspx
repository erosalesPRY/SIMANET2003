<%@ Page language="c#" Codebehind="BuscarPersonalPorArea.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.BuscarPersonalPorArea" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="650" align="center" border="0">
				<TR>
					<TD class="TituloPrincipal" vAlign="top" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> BUSQUEDA DE PERSONAS POR AREA</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="500" bgColor="#f5f5f5"
							border="0">
							<TR bgColor="#ffffff">
								<TD class="TitFiltros"><IMG height="14" src="../imagenes/TitFiltros.gif" width="82"></TD>
								<TD class="combos" style="WIDTH: 53px" width="53"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros" align="center"><asp:label id="lblArea" runat="server" CssClass="normal">Area</asp:label></TD>
								<TD class="combos" style="WIDTH: 53px; HEIGHT: 14px" align="center"></TD>
								<TD class="combos" align="center"><asp:label id="lblApellidoPaterno" runat="server" CssClass="normal">Apellido Paterno</asp:label></TD>
								<TD class="combos" align="center"><asp:label id="lblNombre" runat="server" CssClass="normal">Nombres</asp:label></TD>
								<TD class="combos"><INPUT id="hIdPersonal" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hIdPersonal"
										runat="server"><INPUT id="hPersonal" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hPersonal"
										runat="server"><INPUT id="hIdArea" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hIdArea"
										runat="server"><INPUT id="hNombreArea" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hNombreArea"
										runat="server"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros"><asp:dropdownlist id="ddlbArea" runat="server" CssClass="normal" Width="250px"></asp:dropdownlist></TD>
								<TD class="combos" style="WIDTH: 53px"></TD>
								<TD class="combos"><asp:textbox id="txtApellidoPaterno" runat="server" Width="136px"></asp:textbox></TD>
								<TD class="combos"><asp:textbox id="txtNombre" runat="server" Width="136px"></asp:textbox></TD>
								<TD class="combos"><asp:imagebutton id="btnBuscar" runat="server" Width="87px" Height="22px" ImageUrl="../imagenes/bt_Buscar.GIF"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td vAlign="top">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="650" align="center"
							border="0">
							<TR>
								<TD vAlign="top" align="center" colSpan="3"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="650px" DataKeyField="IdPersonal"
										AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" PageSize="7">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Grado" SortExpression="Grado" HeaderText="GRADO">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Especialidad" SortExpression="Especialidad" HeaderText="ESPECIALIDAD">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ApellidoPaterno" SortExpression="ApellidoPaterno" HeaderText="APELLIDO PATERNO">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ApellidoMaterno" SortExpression="ApellidoMaterno" HeaderText="APELLIDO MATERNO">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Nombres" SortExpression="Nombres" HeaderText="NOMBRES">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="56"></asp:label></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td vAlign="top">
						<TABLE id="Table8" width="650" align="center" border="0">
							<TR>
								<TD align="center"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;
									<SPAN class="normal">
										<asp:image id="imgCancelar" onclick="window.close()" runat="server" ImageUrl="../imagenes/bt_cancelar.gif"></asp:image></SPAN></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
			function PonerTexto()
			{ 
				opener.document.forms[0].hIdPersonal.value =document.forms[0].hIdPersonal.value;								
				opener.document.forms[0].txtPersonal.value =document.forms[0].hPersonal.value;			
				window.close();
			} 
			
			function PonerTextoPromotor()
			{ 
				opener.document.forms[0].hIdPromotor.value =document.forms[0].hIdPersonal.value;
				opener.document.forms[0].txtOrigen.value =document.forms[0].hPersonal.value;
				opener.document.forms[0].hIdAreaPromotor.value =document.forms[0].hIdArea.value;
				window.close();
			}
			
			function PonerTextoPersonal()
			{
				opener.document.forms[0].hIdOficialResponsable.value =document.forms[0].hIdPersonal.value;
				opener.document.forms[0].txtOficialResponsable.value =document.forms[0].hPersonal.value;
				opener.document.forms[0].txtOrigen.value =document.forms[0].hNombreArea.value;
				window.close();
			}
			</SCRIPT>
		</form>
	</body>
</HTML>
