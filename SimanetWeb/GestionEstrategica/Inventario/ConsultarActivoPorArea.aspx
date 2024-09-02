<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarActivoPorArea.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.Inventario.ConsultarActivoPorArea" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Upload/mint"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Upload/si.files.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Menu/MenuSP.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<STYLE title="text/css" type="text/css">.SI-FILES-STYLIZED LABEL.cabinet { WIDTH: 95px; DISPLAY: block; BACKGROUND: url(/SimaNetWeb/imagenes/Navegador/BtnOpciones/AnexarArchivo.bmp) no-repeat 0px 0px; HEIGHT: 25px; OVERFLOW: hidden; CURSOR: hand }
	.SI-FILES-STYLIZED LABEL.cabinet INPUT.file { POSITION: relative; FILTER: progid:DXImageTransform.Microsoft.Alpha(opacity=0); WIDTH: auto; HEIGHT: 100%; opacity: 0; -moz-opacity: 0 }
		</STYLE>
		<script>
							
				function txtBuscarArea_ItemDataBound(sender,e,dr){
					jNet.get('hIdArea').value=dr["IDAREA"].toString();
					var oDataTable = new System.Data.DataTable("tblGrupoCC");
					oDataTable=(new Controladora.Estrategica.CActivoFijoyCtaOrden()).ListarAFPorArea(dr["IDAREA"].toString());
					/*Cragar la Grilla*/
					oDataGrid = new DataGrid($O('grid'));
					oDataGrid.DataSource = oDataTable;
					oDataGrid.EventHandleItemDataBound =grid_ItemDataBound;
					oDataGrid.DataBind();

				}

				function grid_ItemDataBound(sender,e){
					var dr = e.Item.DataItem;
					if(dr.Item("EOF")==false){
							e.Item.cells(0).innerText=e.Item.rowIndex;
							e.Item.cells(1).innerText=dr.Item("GrupoActivo");
							e.Item.cells(1).noWrap = true;
							e.Item.cells(1).align = "left";
							e.Item.cells(2).innerText=dr.Item("cod_bien");
							e.Item.cells(2).align = "left";
							e.Item.cells(3).innerText=dr.Item("des_bien");
							e.Item.cells(3).noWrap = true;
							e.Item.cells(3).align = "left";
							e.Item.cells(4).innerText=dr.Item("Vida_util_trb");

							e.Item.cells(5).innerText=dr.Item("Fec_fac_bien").toString();
							e.Item.cells(5).align = "Left";
							e.Item.cells(5).noWrap = true;							
							
							e.Item.cells(6).innerText=new SIMA.Numero(parseFloat(dr.Item("cst_org_bien"))).toString(2,true,' ');
							e.Item.cells(6).align = "right";
							e.Item.cells(6).noWrap = true;
							
							e.Item.cells(7).innerText=new SIMA.Numero(parseFloat(dr.Item("Dep_Acum"))).toString(2,true,' ');
							e.Item.cells(7).align = "right";
							e.Item.cells(7).noWrap = true;

							e.Item.cells(8).innerText=new SIMA.Numero(parseFloat(dr.Item("valorNeto"))).toString(2,true,' ');
							e.Item.cells(8).align = "right";
							e.Item.cells(8).noWrap = true;

							SIMA.Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
							
					}
				}
		</script>
	</HEAD>
	<body onkeypress="if (event.keyCode==13)return false" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="tblCabeceraPrint" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr id="Cabecera">
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr id="FilaMenu">
					<td vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 21px" class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Estratégica></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar de Activos por área</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE style="WIDTH: 974px; HEIGHT: 136px" id="Table2" border="0" cellSpacing="0" cellPadding="0"
							width="974" align="center">
							<TR>
								<TD width="100%" colSpan="4" noWrap align="right">
									<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD>
												<TABLE style="WIDTH: 112px; HEIGHT: 30px" id="Table3" border="0" cellSpacing="1" cellPadding="1"
													width="112" align="left">
													<TR>
														<TD><IMG style="Z-INDEX: 0" alt="" src="../../imagenes/Navegador/xls.gif"></TD>
														<TD width="100%" style="CURSOR:hand"><asp:label id="lblLinkFile" onclick="VerFile()" runat="server" ForeColor="DarkBlue" Font-Underline="True"
																Font-Bold="True" Font-Size="X-Small">Ver Archivo</asp:label></TD>
													</TR>
												</TABLE>
											</TD>
											<TD></TD>
											<TD align="right"><LABEL class="cabinet"><INPUT style="Z-INDEX: 0" id="FUFile" class="file" size="1" type="file" name="FUFile" runat="server"></LABEL></TD>
											<TD width="100%" align="right">
												<INPUT style="Z-INDEX: 0; WIDTH: 65px; HEIGHT: 23px" id="hNombreArchivoUP" size="5" type="hidden"
													name="hNombreArchivoUP" runat="server"> <input style="Z-INDEX: 0; WIDTH: 72px; HEIGHT: 22px" size="6" type="hidden" name="__EVENTTARGET">
												<input style="Z-INDEX: 0; WIDTH: 71px; HEIGHT: 22px" size="6" type="hidden" name="__EVENTARGUMENT">
												<INPUT style="Z-INDEX: 0; WIDTH: 65px; HEIGHT: 23px" id="hPatFile" size="5" type="hidden"
													name="hPatFile" runat="server" value="/SIMANETCOMPLEMENTOS/Estrategica/SustentoInversion.xls">
											</TD>
											<TD align="right"><asp:imagebutton style="Z-INDEX: 0" id="ImgImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
									&nbsp;</TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="4" noWrap align="left"><asp:label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="normal" Font-Bold="True"
										Font-Size="X-Small" Width="224px" Height="8px">INGRESE NOMBRE DE AREA A BUSCAR</asp:label><INPUT style="WIDTH: 40px; HEIGHT: 22px" id="hIdArea" size="1" type="hidden" runat="server"></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="4" noWrap><asp:textbox id="txtBuscarArea" runat="server" Width="971px" Height="17px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 167px; HEIGHT: 10px" bgColor="#000080" colSpan="4"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Width="224px" Height="8px">LISTADO DE RECURSO POR AREA:</asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 10px" width="100%" colSpan="4"><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="100%" PageSize="9" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Wrap="False" Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="CLASIFICACION">
												<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="CODIGO BIEN">
												<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="NOMBRE DEL BIEN">
												<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="VIDA UTIL&lt;BR&gt; EN MESES">
												<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="FECHA COMPRA">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="COSTO ORIGEN">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="DEPR.&lt;BR&gt;ACUM.">
												<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="VALOR NETO">
												<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 167px; HEIGHT: 10px" colSpan="4"><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt=""
										src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
						<asp:button style="Z-INDEX: 0" id="btnSubir" runat="server" Text="Subir"></asp:button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" width="100%" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
				
						//Configuracion de Busqueda para Areas
						var oParamCollecionBusqueda = new ParamCollecionBusqueda();
						var oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="NombreArea";
							oParamBusqueda.Texto="Area";
							oParamBusqueda.LongitudEjecucion=1;
							oParamBusqueda.CampoAlterno = "NroArea";
							oParamBusqueda.Tipo="C";
							oParamBusqueda.LongitudEjecucion=2;
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="idProceso";
							oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarArea;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						(new AutoBusqueda('txtBuscarArea')).Crear('/' + ApplicationPath + '/Personal/Procesar.aspx?',oParamCollecionBusqueda);
						
						
						//Muestra la Cartfa Fianza que fue consultada y vista en previo del reporte
						if($O('txtBuscarArea').value.length>0){
							var oDataTable = new System.Data.DataTable("tblGrupoCC");
								oDataTable=(new Controladora.Estrategica.CActivoFijoyCtaOrden()).ListarAFPorArea(jNet.get('hIdArea').value);
								/*Cragar la Grilla*/
								oDataGrid = new DataGrid($O('grid'));
								oDataGrid.DataSource = oDataTable;
								oDataGrid.EventHandleItemDataBound =grid_ItemDataBound;
								oDataGrid.DataBind();
						}				
		</SCRIPT>
		<SCRIPT language="javascript" type="text/javascript"> 
		<!--
			function __doPostBack(eventTarget, eventArgument) {
				var theform;
				if (window.navigator.appName.toLowerCase().indexOf("microsoft") > -1) {
					theform = document.Form1;
				}
				else {
					theform = document.forms["Form1"];
				}
				theform.__EVENTTARGET.value = eventTarget.split("$").join(":");
				theform.__EVENTARGUMENT.value = eventArgument;
				theform.submit();
			}
		// -->
		</SCRIPT>
		<SCRIPT language="javascript" type="text/javascript">
			// <![CDATA[
					SI.Files.stylizeAll();
			// ]]>
			
				var oFUFile = jNet.get('FUFile');
					oFUFile.addEvent("change",function(){
							var PathNombre=jNet.get('FUFile').value;
							var arrPath =PathNombre.split(String.fromCharCode(92));
							var NombreFile = arrPath[arrPath.length-1];
							var arrExt = NombreFile.split('.');
							
							
							var extF = arrExt[arrExt.length-1].toUpperCase();
							if(extF=="XLS"){
								jNet.get('hNombreArchivoUP').value = NombreFile;
								__doPostBack('btnSubir','');
							}
							else{
								Ext.MessageBox.alert('Estrategica', 'Solo esta permitido subir archivos con extension .XLS', function(btn){});
							}
					});
					
					
					function VerFile(){
						(new SIMA.Utilitario.Helper.Window()).AbrirExcel(jNet.get('hPatFile').value);
					}
		</SCRIPT>
	</body>
</HTML>
