<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="FlitrosReportePresupuesto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.FlitrosReportePresupuesto" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FiltrosParaReporte</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Menu/MenuSP.js"></script>
		<script type="text/javascript" src="../../js/RegEXT.js"></script>
		<script>
				
		function ElaboraSTRGrupoCC(){
			var _objLstChkGRP = jNet.get("objLstChkGRP");
			var _objLstChkCC = jNet.get("objLstChkCC");
			_objLstChkGRP.value="";
			_objLstChkCC.value="";
			var oGridGrp = jNet.get('gridGRP');
			for(var i=1;i<=oGridGrp.rows.length-2;i++){
				var ochk = oGridGrp.rows[i].cells[3].children[0];
				if(ochk.checked==true){
					_objLstChkGRP.value = _objLstChkGRP.value  + oGridGrp.rows[i].cells[4].innerText +";";
				}
			}
			__doPostBack('btnLstCC','');
		}
		
		function ElaboraLstCC(){
			var _objLstChkCC = jNet.get("objLstChkCC");
			_objLstChkCC.value="";
			var ogridCC= jNet.get('gridCC');
			for(var i=1;i<=ogridCC.rows.length-2;i++){
				var ochk = ogridCC.rows[i].cells[3].children[0];
				if(ochk.checked==true){
					_objLstChkCC.value = _objLstChkCC.value  + ogridCC.rows[i].cells[4].innerText +";";
				}
			}
			__doPostBack('btnActNat','');
		}

		

		</script>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD><uc1:header style="Z-INDEX: 0" id="Header1" runat="server"></uc1:header>
						<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD><uc1:menu style="Z-INDEX: 0" id="Menu1" runat="server"></uc1:menu></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="2" width="90%">
										<TR>
											<TD class="TituloPrincipalBlanco" bgColor="#000080" width="100%" colSpan="6" align="center"><asp:imagebutton style="Z-INDEX: 0" id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/ibtnResumenppto.png"
													Height="23px" Width="90px" ToolTip="Seleccionar Naturaleza de la Operación" BackColor="Lime" BorderStyle="None" Visible="False"></asp:imagebutton><asp:label style="Z-INDEX: 0" id="Label6" runat="server" CssClass="TItuloPrincipalBlanco">FILTROS PARA REPORTE</asp:label></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 0px" width="15%" colSpan="4"></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 45px" colSpan="4" align="center">
												<TABLE id="Table6" border="1" cellSpacing="1" cellPadding="1" width="400">
													<TR>
														<TD class="HeaderDetalle" vAlign="middle" colSpan="2" align="center"><asp:label style="Z-INDEX: 0" id="Label1" runat="server" Width="336px">PARÁMETROS:</asp:label></TD>
													</TR>
													<TR>
														<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label7" runat="server">PERIODO:</asp:label></TD>
														<TD width="300"><asp:dropdownlist style="Z-INDEX: 0" id="ddlbPeriodo" runat="server" Width="100%" CssClass="normaldetalle"
																AutoPostBack="True"></asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD class="HeaderDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label3" runat="server">TIPO PRESUPUESTO:</asp:label></TD>
														<TD><asp:dropdownlist style="Z-INDEX: 0" id="ddlbTipoPPto" runat="server" Width="100%" CssClass="normaldetalle"
																AutoPostBack="True"></asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD class="HeaderDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label4" runat="server">CENTRO OPERATIVO:</asp:label></TD>
														<TD><asp:dropdownlist style="Z-INDEX: 0" id="ddlbCentroOperativo" runat="server" Width="100%" CssClass="normaldetalle"
																AutoPostBack="True"></asp:dropdownlist></TD>
													</TR>
													<TR style="DISPLAY: none">
														<TD class="HeaderDetalle" noWrap>&nbsp; <INPUT style="Z-INDEX: 0; WIDTH: 144px; HEIGHT: 22px" id="objLstChkGRP" size="18" runat="server"></TD>
														<TD><asp:button style="Z-INDEX: 0" id="btnLstCC" runat="server" Text="ListarCC"></asp:button><asp:button style="Z-INDEX: 0" id="btnActNat" runat="server" Text="ListrCC"></asp:button><INPUT style="Z-INDEX: 0; WIDTH: 120px; HEIGHT: 23px" id="objLstChkCC" size="14" name="Hidden2"
																runat="server"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD colSpan="4" align="center">
												<TABLE id="Table5" border="0" cellSpacing="1" cellPadding="1" width="300">
													<TR>
														<TD colSpan="2">
															<TABLE style="WIDTH: 376px; DISPLAY: none; HEIGHT: 40px" id="tblBtns" border="0" cellSpacing="1"
																cellPadding="1" width="376" align="right" runat="server">
																<TR>
																	<TD><asp:button id="btnPosGrupoCC" runat="server" Text="Informe por Grupo"></asp:button></TD>
																	<TD align="right"><asp:button id="btnPosNaturaleza" runat="server" Width="158px" Text="Por Naturaleza de gasto"></asp:button></TD>
																	<TD></TD>
																	<TD><asp:imagebutton style="Z-INDEX: 0" id="imgXLS" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/xls.gif"
																			ToolTip="Exportar resultados a Excel"></asp:imagebutton></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD><asp:label style="Z-INDEX: 0" id="Label2" runat="server">GRUPOS</asp:label></TD>
														<TD noWrap><asp:label id="Label5" runat="server">CENTROS DE COSTO</asp:label></TD>
													</TR>
													<TR>
														<TD vAlign="top" width="50%" align="left"><asp:datagrid style="Z-INDEX: 0" id="gridGRP" runat="server" Height="62px" Width="500px" ShowFooter="True"
																AutoGenerateColumns="False">
																<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
																<ItemStyle CssClass="itemGrilla"></ItemStyle>
																<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
																<Columns>
																	<asp:BoundColumn DataField="NroGrupoCentroCosto" HeaderText="COD">
																		<HeaderStyle Width="2%"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="NombreGrupoCentroCosto" HeaderText="NOMBRE">
																		<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="75%"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="Total" HeaderText="IMPORTE">
																		<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Right"></ItemStyle>
																		<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
																	</asp:BoundColumn>
																	<asp:TemplateColumn>
																		<HeaderStyle Width="2%"></HeaderStyle>
																		<ItemTemplate>
																			<asp:CheckBox id="chkGrp" runat="server"></asp:CheckBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:BoundColumn DataField="IdGrupoCentroCosto" HeaderText="IDGRPCC"></asp:BoundColumn>
																</Columns>
															</asp:datagrid></TD>
														<TD vAlign="top" width="50%" align="left"><asp:datagrid style="Z-INDEX: 0" id="gridCC" runat="server" Height="62px" Width="500px" ShowFooter="True"
																AutoGenerateColumns="False">
																<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
																<ItemStyle CssClass="itemGrilla"></ItemStyle>
																<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
																<Columns>
																	<asp:BoundColumn DataField="NroCentroCosto" HeaderText="COD">
																		<HeaderStyle Width="2%"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="NombreCentroCosto" HeaderText="NOMBRE">
																		<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="75%"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="Total" HeaderText="IMPORTE">
																		<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Right"></ItemStyle>
																		<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
																	</asp:BoundColumn>
																	<asp:TemplateColumn>
																		<HeaderStyle Width="2%"></HeaderStyle>
																		<ItemTemplate>
																			<asp:CheckBox id="chkGrp" runat="server"></asp:CheckBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:BoundColumn DataField="IdCentroCosto" HeaderText="IDCC"></asp:BoundColumn>
																</Columns>
															</asp:datagrid></TD>
													</TR>
													<TR>
														<TD vAlign="top" width="50%" align="left"></TD>
														<TD vAlign="top" width="50%" align="left"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD colSpan="4" align="center"><asp:datagrid id="grid" runat="server" Height="62px" Width="700px" ShowFooter="True" AutoGenerateColumns="False">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="itemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="NatCta" HeaderText="CUENTA">
															<HeaderStyle Width="2%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NaturalezaGasto" HeaderText="NATURALEZA GASTO">
															<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="75%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="pptoActual" HeaderText="IMPORTE">
															<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="2%"></HeaderStyle>
															<ItemTemplate>
																<asp:CheckBox id="chkCuenta" runat="server"></asp:CheckBox>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:datagrid></TD>
										</TR>
										<TR>
											<TD colSpan="4" align="center"><asp:label style="Z-INDEX: 0" id="Label8" runat="server">La selección de Centros de costos  y Naturaleza de gasto solo afecta únicamnte al reporte  Por Naturaleza</asp:label></TD>
										</TR>
									</TABLE>
									<INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 22px" id="hPeriodo" size="1" type="hidden"
										runat="server"> <IMG style="Z-INDEX: 0" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" align="left"
										src="../../imagenes/atras.gif"> <INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 22px" id="hTipoPresupuesto" size="1" type="hidden"
										name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 22px" id="hIdCentroOperativo" size="1" type="hidden"
										name="Hidden1" runat="server"> <INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 22px" id="hIdCentroCosto" size="1" type="hidden"
										name="Hidden1" runat="server">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="middle" align="center"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
		</SCRIPT>
		<SCRIPT>
					
		</SCRIPT>
	</body>
</HTML>
