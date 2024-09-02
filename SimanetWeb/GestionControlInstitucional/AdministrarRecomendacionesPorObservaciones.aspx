<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarRecomendacionesPorObservaciones.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.AdministrarRecomendacionesPorObservaciones" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarRecomendacionesPorObservaciones</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script>
				function MsgEliminar(){
					if(jNet.get("hIdAnio").value.length!=0){
						Ext.MessageBox.confirm('Eliminar Recomendacion', 'Desea ud eliminar este registro ahora?'
												, function(btn){
													if(btn=='yes'){
														__doPostBack('ibtnEliminar','');
													}
												});
					}
					else{
						Ext.MessageBox.show({title: "SELECCIONAR",msg: "Ud. no ha seleccionado registro a ser eliminado",buttons: Ext.MessageBox.OK,fn: function(){},icon:  Ext.MessageBox.INFO});
					}
				}
		</script>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" onunload="SubirHistorial();"
		onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td style="HEIGHT: 23px" bgColor="#eff7fa" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 22px" class="RutaPaginaActual" vAlign="top" width="100%">
						<asp:label style="Z-INDEX: 0" id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >  Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Recomendaciones</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center"></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="922" style="WIDTH: 922px">
							<TR bgColor="#f0f0f0">
								<TD bgColor="#000080">&nbsp;
									<asp:label style="Z-INDEX: 0" id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label>
								</TD>
							</TR>
							<TR>
								<TD bgColor="#000080"><IMG style="Z-INDEX: 0; WIDTH: 142px; HEIGHT: 8px" src="../imagenes/spacer.gif" width="142"
										height="8"></TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table4" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD vAlign="top" align="left">
												<asp:label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="TituloPrincipalBlanco" BackColor="White"
													ForeColor="Navy">OBSERVACION:</asp:label></TD>
											<TD width="100%">
												<asp:label style="Z-INDEX: 0" id="LblObservacion" runat="server" CssClass="Normal" ForeColor="Black">OBSERVACION:</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left"
										style="Z-INDEX: 0">
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD width="100%"></TD>
											<TD>
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnAgregar" runat="server" CausesValidation="False" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
											<TD><IMG style="Z-INDEX: 0" id="ibtnEliminarJS" onclick="MsgEliminar()" alt="" src="../imagenes/bt_eliminar.gif"></TD>
											<TD>
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnAcciones" runat="server" CausesValidation="False" ImageUrl="../imagenes/btnAccion.jpg"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="100%" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Fecha" HeaderText="FECHA">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Observacion" SortExpression="Observacion" HeaderText="RECOMENDACION">
												<HeaderStyle Width="40%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Situacion" SortExpression="Situacion" HeaderText="Situacion">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PorcAvance" HeaderText="% Avance">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb>
								</TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="925" align="center"
							style="WIDTH: 925px; HEIGHT: 38px">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hGridPaginaSort" size="1" type="hidden"
										name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hGridPagina" value="0" size="1"
										type="hidden" name="hGridPagina" runat="server"><INPUT style="WIDTH: 24px; HEIGHT: 22px" id="hIdRecomendacion" size="1" type="hidden" runat="server"><INPUT style="WIDTH: 24px; HEIGHT: 22px" id="hIdAnio" value="0" size="1" type="hidden"
										runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 22px" id="hDescripcionRecom" size="1" type="hidden"
										name="hDescripcionRecom" runat="server">
									<asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
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
