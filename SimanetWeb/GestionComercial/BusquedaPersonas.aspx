<%@ Page language="c#" Codebehind="BusquedaPersonas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.BusquedaPersonas" %>
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
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="97%" align="center" border="0">
				<TR>
					<TD class="TituloPrincipal" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> BUSQUEDA DE PERSONAS</asp:label></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="550" bgColor="#f5f5f5"
							border="0">
							<TR bgColor="#ffffff">
								<TD class="TitFiltros" width="93"><IMG height="14" src="../imagenes/TitFiltros.gif" width="82"></TD>
								<TD class="combos" width="121"></TD>
								<TD class="combos" width="121"></TD>
								<TD class="combos" width="140"></TD>
								<TD class="combos" style="WIDTH: 14px" width="25"></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD class="SmallFont" align="center"></TD>
								<TD class="SmallFont" align="center"></TD>
								<TD class="SmallFont" align="center" colSpan="1"></TD>
								<TD class="SmallFont" style="WIDTH: 14px"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros" align="center">
									<asp:label id="lblTipoPersona" runat="server" CssClass="normal">Tipo Persona</asp:label></TD>
								<TD class="combos" align="center"><asp:label id="lblApellidoPaterno" runat="server" CssClass="normal">Apellido</asp:label></TD>
								<TD class="combos" align="center">
									<asp:label id="lblNombre" runat="server" CssClass="normal">Nombre</asp:label></TD>
								<TD class="combos"></TD>
								<TD class="combos" style="WIDTH: 14px"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros"><asp:dropdownlist id="ddlbTipoPersona" runat="server" CssClass="normal" Width="136px"></asp:dropdownlist></TD>
								<TD class="combos"><asp:textbox id="txtApellidoPaterno" runat="server" Width="136px"></asp:textbox></TD>
								<TD class="combos">
									<asp:textbox id="txtNombre" runat="server" Width="136px"></asp:textbox></TD>
								<TD class="combos"></TD>
								<TD class="combos" style="WIDTH: 14px"><asp:button id="btnBuscar" runat="server" CssClass="boton" Text="Buscar"></asp:button></TD>
							</TR>
							<TR>
								<TD class="TitFiltros"></TD>
								<TD class="combos" align="center">
									<asp:label id="lblGrado" runat="server" CssClass="normal">Grado</asp:label></TD>
								<TD class="combos" align="center">
									<asp:label id="lblEspecialidad" runat="server" CssClass="normal">Especialidad</asp:label></TD>
								<TD class="combos"></TD>
								<TD class="combos" style="WIDTH: 14px"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros" align="center">
									<asp:label id="lblOficial" runat="server" CssClass="normal">Oficial</asp:label></TD>
								<TD class="combos">
									<asp:dropdownlist id="ddlbGrado" runat="server" CssClass="normal" Width="136px"></asp:dropdownlist></TD>
								<TD class="combos">
									<asp:dropdownlist id="ddlbEspecialidad" runat="server" CssClass="normal" Width="136px"></asp:dropdownlist></TD>
								<TD class="combos"></TD>
								<TD class="combos" style="WIDTH: 14px"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros" align="center"></TD>
								<TD class="combos" align="center">
									<asp:label id="lblArea" runat="server" CssClass="normal">Area</asp:label></TD>
								<TD class="combos" align="center">
									<asp:label id="lblCargo" runat="server" CssClass="normal">Cargo</asp:label></TD>
								<TD class="combos"></TD>
								<TD class="combos" style="WIDTH: 14px"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros" align="center">
									<asp:label id="lblPersonal" runat="server" CssClass="normal">Personal</asp:label></TD>
								<TD class="combos">
									<asp:dropdownlist id="ddlblArea" runat="server" CssClass="normal" Width="136px"></asp:dropdownlist></TD>
								<TD class="combos">
									<asp:dropdownlist id="ddlbCargo" runat="server" CssClass="normal" Width="136px"></asp:dropdownlist></TD>
								<TD class="combos"></TD>
								<TD class="combos" style="WIDTH: 14px"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros" align="center"></TD>
								<TD class="combos" align="center">
									<asp:label id="lblDependencia" runat="server" CssClass="normal">Dependencia</asp:label></TD>
								<TD class="combos" align="center">
									<asp:label id="lblTituloCliente" runat="server" CssClass="normal">Titulo</asp:label></TD>
								<TD class="combos"></TD>
								<TD class="combos" style="WIDTH: 14px"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros" align="center">
									<asp:label id="lblCliente" runat="server" CssClass="normal">Cliente</asp:label></TD>
								<TD class="combos">
									<asp:dropdownlist id="ddlbDependencia" runat="server" CssClass="normal" Width="136px"></asp:dropdownlist></TD>
								<TD class="combos">
									<asp:dropdownlist id="ddlbTituloCliente" runat="server" CssClass="normal" Width="136px"></asp:dropdownlist></TD>
								<TD class="combos"></TD>
								<TD class="combos" style="WIDTH: 14px"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="550" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="550" border="0">
										<TR>
											<TD bgColor="#398094"><IMG height="22" src="../imagenes/tab_izq.gif" width="4"></TD>
											<TD bgColor="#398094"><IMG height="8" src="../imagenes/spacer.gif" width="250"></TD>
											<TD bgColor="#398094"></TD>
											<TD align="right" width="4"><IMG height="22" src="../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="550px" AllowSorting="True" AutoGenerateColumns="False"
										AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False">
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="TipoPersona" SortExpression="TipoPersona" HeaderText="Tipo"></asp:BoundColumn>
											<asp:BoundColumn DataField="ApellidoPaterno" SortExpression="ApellidoPaterno" HeaderText="Apellido"></asp:BoundColumn>
											<asp:BoundColumn DataField="Nombre" SortExpression="Nombre" HeaderText="Nombre"></asp:BoundColumn>
											<asp:BoundColumn DataField="Grado" SortExpression="Grado" HeaderText="Grado"></asp:BoundColumn>
											<asp:BoundColumn DataField="Especialidad" SortExpression="Especialidad" HeaderText="Especialidad"></asp:BoundColumn>
											<asp:BoundColumn DataField="Area" SortExpression="Area" HeaderText="Area"></asp:BoundColumn>
											<asp:BoundColumn DataField="Cargo" SortExpression="Cargo" HeaderText="Cargo"></asp:BoundColumn>
											<asp:BoundColumn DataField="Dependencia" SortExpression="Dependencia" HeaderText="Dependencia"></asp:BoundColumn>
											<asp:BoundColumn DataField="Titulo" SortExpression="Titulo" HeaderText="Titulo"></asp:BoundColumn>
											<mbrsc:RowSelectorColumn HeaderText="Seleccion" SelectionMode="Single"></mbrsc:RowSelectorColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False" DESIGNTIMEDRAGDROP="56"></asp:label></TD>
							</TR>
						</TABLE>
						<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../imagenes/spacer.gif" width="160">
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table8" width="350" border="0">
							<TR>
								<TD width="139">&nbsp;</TD>
								<TD width="198">&nbsp;</TD>
								<TD width="94">
									<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
								<TD width="101"><SPAN class="normal">
										<asp:imagebutton id="ibtnCancelar" runat="server" ImageUrl="../imagenes/bt_cancelar.gif" CausesValidation="False"></asp:imagebutton></SPAN></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
