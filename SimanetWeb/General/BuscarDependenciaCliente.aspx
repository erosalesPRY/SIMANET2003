<%@ Page language="c#" Codebehind="BuscarDependenciaCliente.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.BuscarDependenciaCliente" %>
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
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<script language="javascript">
				function verificarSelecc(nombreControl,mensaje1)
				{
					if(document.forms[0].elements[nombreControl].value=='')
					{
						alert (mensaje1)
						return false;
					}
					else
					{
						opener.document.forms[0].hIdCliente.value =document.forms[0].hIdCliente.value;
						opener.document.forms[0].hIdUnidadDependenciaCliente.value =document.forms[0].hCodigo.value;
						opener.document.forms[0].txtUnidadNaval.value =document.forms[0].hNombreUnidad.value;
						window.close();
					}
				}
		
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" scellSpacing="0" cellPadding="0" width="600" align="center" border="0">
				<TR>
					<TD class="TituloPrincipal" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal">BUSQUEDA DE DEPENDENCIAS DE UN CLIENTE</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="94%" bgColor="#f5f5f5"
							border="0">
							<TR bgColor="#ffffff">
								<TD align="right"><asp:label id="lblCliente" runat="server" CssClass="normal">Cliente:&nbsp;&nbsp;</asp:label></TD>
								<TD colSpan="2"><asp:label id="lblNombreCliente" runat="server" CssClass="TextoAzulNegrita">[NOMBRE DEL CLIENTE]</asp:label></TD>
							</TR>
							<TR bgColor="#ffffff">
								<TD align="left"><IMG height="14" src="../imagenes/TitFiltros.gif" width="82"></TD>
								<TD align="center"><INPUT id="hIdCliente" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hCodigo"
										runat="server"><INPUT id="hNombreUnidad" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
								<TD><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblPalabraBusqueda" runat="server" CssClass="normal">Palabra Clave de Busqueda:</asp:label></TD>
								<TD><asp:textbox id="txtPalabraClave" runat="server" Width="328px"></asp:textbox></TD>
								<TD><asp:imagebutton id="btnBuscar" runat="server" Width="77px" Height="22px" ImageUrl="../imagenes/bt_Buscar.GIF"></asp:imagebutton></TD>
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
										<TR bgcolor="#f5f5f5">
											<TD style="WIDTH: 12px"><IMG height="22" src="../imagenes/tab_izq.gif" width="4"></TD>
											<TD><IMG height="8" src="../imagenes/spacer.gif" width="150"></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="98%" PageSize="7" DataKeyField="IdUnidadDependenciaCliente"
										AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0">
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="IdUnidadDependenciaCliente" HeaderText="Id"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="70px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Nombre" SortExpression="Nombre" HeaderText="NOMBRE">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="56"></asp:label></TD>
							</TR>
							<tr>
								<td align="center" style="WIDTH: 754px"><IMG style="WIDTH: 160px; HEIGHT: 16px" height="16" src="../imagenes/spacer.gif" width="160"></td>
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
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table8" width="500" border="0">
							<TR>
								<TD align="center"><IMG id="imgAceptar" onclick="verificarSelecc('hCodigo','Debe de seleccionar una dependencia');"
										alt="" src="../imagenes/bt_aceptar.gif">&nbsp;&nbsp; <SPAN class="normal">
										<asp:image id="imgCancelar" onclick="window.close()" runat="server" ImageUrl="../imagenes/bt_cancelar.gif"></asp:image></SPAN></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
