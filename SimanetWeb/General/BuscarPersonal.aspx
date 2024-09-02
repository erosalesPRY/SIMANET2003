<%@ Page language="c#" Codebehind="BuscarPersonal.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.BuscarPersonal" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form2" method="post" runat="server">
			<TABLE id="Table3" cellPadding="0" width="600" align="center" border="0" scellSpacing="0">
				<TR>
					<TD class="TituloPrincipal" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> BUSQUEDA DE PERSONAL</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="94%" bgColor="#f5f5f5"
							border="0">
							<TR bgColor="#ffffff">
								<TD align="right"></TD>
								<TD colSpan="2"></TD>
							</TR>
							<TR bgColor="#ffffff">
								<TD style="HEIGHT: 14px" align="left"><IMG height="14" src="../imagenes/TitFiltros.gif" width="82"></TD>
								<TD style="HEIGHT: 14px" align="center"><INPUT id="hNombrePersonal" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
								<TD style="HEIGHT: 14px"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblPalabraBusqueda" runat="server" CssClass="normal"> Nombre del Personal:</asp:label></TD>
								<TD><asp:textbox id="txtPalabraClave" runat="server" Width="328px"></asp:textbox><cc2:requireddomvalidator id="rfvNombrePersonal" runat="server" CssClass="normal" ControlToValidate="txtPalabraClave">*</cc2:requireddomvalidator></TD>
								<TD><asp:imagebutton id="ibtnBuscar" runat="server" Width="77px" Height="22px" ImageUrl="../imagenes/bt_Buscar.GIF"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR width="100%">
					<TD align="center">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="94%" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="98%" border="0">
										<TR bgColor="#f5f5f5">
											<TD style="WIDTH: 12px"><IMG height="22" src="../imagenes/tab_izq.gif" width="4"></TD>
											<TD><IMG height="8" src="../imagenes/spacer.gif" width="150"></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="98%" PageSize="7" DataKeyField="IdPersonal" AllowSorting="True"
										AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0">
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="IdPersonal" HeaderText="Id"></asp:BoundColumn>
											<asp:BoundColumn DataField="Personal" SortExpression="Nombre" HeaderText="Personal">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<mbrsc:RowSelectorColumn HeaderText="Seleccion" SelectionMode="Single">
												<HeaderStyle Width="80px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</mbrsc:RowSelectorColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="56"
										Visible="False"></asp:label></TD>
							</TR>
							<tr>
								<td style="WIDTH: 754px" align="center"><IMG style="WIDTH: 160px; HEIGHT: 16px" height="16" src="../imagenes/spacer.gif" width="160"></td>
							</tr>
							<tr>
								<td style="WIDTH: 600px">
									<table id="Table5" cellSpacing="0" cellPadding="0" width="500" align="center" border="0">
										<tr>
											<td style="WIDTH: 400px" align="right"><asp:label id="lblNumeroCoincidencias" runat="server" CssClass="normal">Número de Coincidencias: </asp:label></td>
											<td style="WIDTH: 5px"></td>
											<td align="left"><asp:label id="lblDblNumeroCoincidencias" runat="server" CssClass="TextoAzul" Width="100%">0.00</asp:label></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td align="center"><IMG style="WIDTH: 160px; HEIGHT: 16px" height="16" src="../imagenes/spacer.gif" width="160"></td>
							</tr>
						</TABLE>
						<cc2:domvalidationsummary id="vSum" runat="server" CssClass="normal" Width="96px" EnableClientScript="False"
							ShowMessageBox="True" DisplayMode="List"></cc2:domvalidationsummary></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table8" width="500" border="0">
							<TR>
								<TD align="center"><asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;
									<SPAN class="normal">
										<asp:image id="imgCancelar" onclick="window.close()" runat="server" ImageUrl="../imagenes/bt_cancelar.gif"></asp:image></SPAN></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
			function PonerTexto()
			{ 
				opener.document.forms[0].hIdJefeProyecto.value = document.forms[0].hcodigo.value;
				opener.document.forms[0].txtJefeProyectos.value = document.forms[0].hNombrePersonal.value;

				window.close();
			} 
			
			</SCRIPT>
		</form>
	</body>
</HTML>
