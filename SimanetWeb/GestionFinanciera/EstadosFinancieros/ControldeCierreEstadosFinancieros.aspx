<%@ Page language="c#" Codebehind="ControldeCierreEstadosFinancieros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.ControldeCierreEstadosFinancieros" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="ParametroContable" Src="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>

		<script>
			var contador = 0;
			function ConfirmaGrabar() 
			{ 
				if (confirm('Desea Guardar los Cambios ahora: '))
				{
					ObtenerEstados();
					return true;
				}
				else
				{
					return false;
				}
			}
			
			function EstablecerEstado(idEstado,idFila)
			{
				var objgrid = document.all["grid"];
				objgrid.rows(idFila).removeAttribute("ESTADO");
				objgrid.rows[idFila].setAttribute("ESTADO",idEstado);
			}
			
			function ObtenerEstados()
			{
				var strTrama="";
				var objgrid = document.all["grid"];
				for (var i=1;i<= objgrid.rows.length-1;i++)
				{
					strTrama += objgrid.rows[i].getAttribute("MODO")
								+ ";" 
								+ objgrid.rows[i].getAttribute("IDMES")
								+ ";"
								+ objgrid.rows[i].getAttribute("ESTADO") + "@";
				}
				MostrarDatosEnCajaTexto("hModo",strTrama);
			}
		</script>
</HEAD>
	<body onkeydown="if(event.keyCode==13){return false;}" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table style="HEIGHT: 296px" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<tr>
					<td width="100%" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR>
					<TD width="100%" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" width="100%" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Control de Cierre  Estados Financieros</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 312px" colSpan="3">
						<P align="center">
							<TABLE class="normal" id="Table2" style="WIDTH: 287px; HEIGHT: 251px" cellSpacing="0" cellPadding="0"
								width="287" border="0">
								<TR>
									<TD colSpan="3">
										<DIV align="left">
											<TABLE class="tabla" id="TblTabs" style="HEIGHT: 36px" cellSpacing="0" cellPadding="0"
												width="100%" align="left" bgColor="#f5f5f5" border="0" runat="server">
												<TR>
													<TD></TD>
													<TD style="WIDTH: 184px"><asp:panel id="Panel" runat="server" Width="335px">Panel</asp:panel>
													</TD>
													<TD vAlign="bottom" align="left"><asp:button id="btnConsultar" style="FONT-SIZE: 8pt; COLOR: #ffffcc; FONT-FAMILY: Arial Narrow; BACKGROUND-COLOR: #306898"
															runat="server" Text="Consultar"></asp:button></TD>
												</TR>
											</TABLE>
										</DIV>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 13px" align="center" width="100%" colSpan="3"></TD>
								</TR>
								<TR>
									<TD align="center" width="100%" colSpan="3">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR bgColor="#f0f0f0">
												<TD></TD>
												<TD style="WIDTH: 418px"></TD>
												<TD style="WIDTH: 850px" width="850">&nbsp;<IMG 
                  style="WIDTH: 308px; HEIGHT: 16px" height=16 
                  src="../../imagenes/spacer.gif" width=308></TD>
												<TD style="WIDTH: 791px"></TD>
												<TD style="WIDTH: 209px"><asp:imagebutton id="imgbtnGrabar" runat="server" ImageUrl="../../imagenes/ibtnGrabar.GIF"></asp:imagebutton></TD>
												<TD align="right"></TD>
												<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
											</TR>
										</TABLE>
										<cc1:datagridweb id="grid" runat="server" Width="399px" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
											<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle CssClass="FooterGrilla"></FooterStyle>
											<Columns>
												<asp:BoundColumn DataField="NombreMes" SortExpression="NombreMes" HeaderText="MES">
													<HeaderStyle Width="80%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="EST">
													<HeaderStyle Width="20%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<ItemTemplate>
														<asp:CheckBox id="chkEstado" runat="server"></asp:CheckBox>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb>
										<DIV align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></DIV></TD>
								</TR>
								<TR>
									<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hModo" style="WIDTH: 55px; HEIGHT: 22px" type="hidden" size="3" name="hModo"
											runat="server"></TD>
								</TR>
							</TABLE>
						</P>
					</TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
