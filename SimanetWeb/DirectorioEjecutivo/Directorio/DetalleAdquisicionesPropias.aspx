<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalleAdquisicionesPropias.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorEjecutivo.Director.DetalleAdquisicionesPropias" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<!--<script type="text/javascript" src="/SimaNetWeb/js/Upload/mint"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Upload/si.files.js"></script>-->
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Menu/MenuSP.js"></script>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form onkeydown="return verificarBackspace()" id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="Commands" vAlign="top"><asp:label id="Label1" runat="server" CssClass="RutaPagina">Inicio > Gestión de la Dirección</asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro Adquisiciones Propias</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center">
						<table border="0" cellSpacing="0" cellPadding="0" width="800" align="center">
							<tr>
								<td class="normal" bgColor="#000080"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></td>
							</tr>
							<TR>
								<TD align="center">
									<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD>
												<TABLE id="Table3" class="normal" border="0" cellSpacing="1" cellPadding="1" width="100%"
													align="center">
													<TR>
														<TD class="normal" bgColor="#335eb4" vAlign="top"><asp:label id="lblFecha" runat="server" CssClass="TextoBlanco">Fecha:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" width="80%" colSpan="4"><ew:calendarpopup id="CalFechaAdquisicion" runat="server" CssClass="normaldetalle" Width="80px" ImageUrl="../../imagenes/BtPU_Mas.gif"
																PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar"
																MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:" DisableTextboxEntry="False" ClearDateText="Limpiar Fecha">
																<TextboxLabelStyle CssClass="NormalDetalle"></TextboxLabelStyle>
																<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="White"></WeekdayStyle>
																<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
																	BackColor="Navy"></MonthHeaderStyle>
																<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
																	BackColor="White"></OffMonthStyle>
																<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
																	BackColor="#F0F0F0"></GoToTodayStyle>
																<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
																	ForeColor="#335EB4" BackColor="LightSteelBlue"></TodayDayStyle>
																<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
																	BackColor="#335EB4"></DayHeaderStyle>
																<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
																	ForeColor="IndianRed" BackColor="White"></WeekendStyle>
																<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
																	BackColor="CornflowerBlue"></SelectedDateStyle>
																<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="White"></ClearDateStyle>
																<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="White"></HolidayStyle>
															</ew:calendarpopup></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" bgColor="#335eb4" vAlign="top" width="20%"><asp:label id="lblTema" runat="server" CssClass="TextoBlanco">Objeto:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtObjeto" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="1500"
																Height="54px" TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvObjeto" runat="server" ControlToValidate="txtObjeto">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" width="100%" colSpan="5"><asp:textbox style="Z-INDEX: 0" id="txtEntidad" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvProveedor" runat="server" ControlToValidate="LstPrvs">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD style="BORDER-BOTTOM: gray 1px solid; BORDER-LEFT: gray 1px solid; PADDING-BOTTOM: 5px; PADDING-RIGHT: 5px; HEIGHT: 34px; BORDER-TOP: gray 1px solid; BORDER-RIGHT: gray 1px solid"
															id="cellListDestino" class="normal" vAlign="top" background="#ffffff" colSpan="5"
															runat="server"></TD>
														<TD style="HEIGHT: 34px" class="normal"></TD>
													</TR>
													<TR>
														<TD style="BORDER-BOTTOM: gray 1px solid; BORDER-LEFT: gray 1px solid; PADDING-BOTTOM: 5px; PADDING-RIGHT: 5px; BORDER-TOP: gray 1px solid; BORDER-RIGHT: gray 1px solid"
															class="normal" bgColor="#335eb4" vAlign="top"><asp:label id="Label2" runat="server" CssClass="TextoBlanco">Proyecto:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtProyecto" runat="server" CssClass="normaldetalle" Width="100%" Height="54px"
																TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvProyecto" runat="server" ControlToValidate="txtProyecto">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" bgColor="#335eb4" vAlign="top"><asp:label id="Label3" runat="server" CssClass="TextoBlanco">Centro Operativo:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Width="160px"></asp:dropdownlist></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 14px" class="normal" bgColor="#335eb4" vAlign="top"><asp:label id="lblMoneda" runat="server" CssClass="TextoBlanco">Moneda:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:dropdownlist id="ddlbMoneda" runat="server" CssClass="normaldetalle" Width="160px"></asp:dropdownlist></TD>
														<TD style="HEIGHT: 14px" class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" bgColor="#335eb4" vAlign="top"><asp:label id="lblMonto" runat="server" CssClass="TextoBlanco">Monto:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><ew:numericbox id="txtMonto" runat="server" CssClass="normaldetalle" Width="120px" MaxLength="19"></ew:numericbox><asp:textbox id="LstPrvs" runat="server" Width="100%"></asp:textbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvMonto" runat="server" ControlToValidate="txtMonto">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 13px" class="normal" bgColor="#335eb4" vAlign="top"><asp:label id="Label6" runat="server" CssClass="TextoBlanco">Códido del Proceso</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtLicitaciones" runat="server" CssClass="normaldetalle" Width="184px"></asp:textbox></TD>
														<TD style="HEIGHT: 13px" class="normal"><cc1:requireddomvalidator id="rfvLicitaciones" runat="server" ControlToValidate="txtLicitaciones">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR style="DISPLAY:none">
														<TD class="normal" bgColor="#335eb4" vAlign="top"><asp:label id="Label4" runat="server" CssClass="TextoBlanco">Concurso Publico:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:TextBox style="Z-INDEX: 0" id="txtConcursoPublico" runat="server" Width="184px"></asp:TextBox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvConcursoPublico" runat="server" ControlToValidate="txtConcursoPublico">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top"></TD>
														<TD class="normal" colSpan="4"></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" colSpan="6">
															<TABLE id="Table7" border="0" cellSpacing="0" cellPadding="0" align="center" height="25">
																<TR>
																	<TD align="center">&nbsp;&nbsp;&nbsp;
																		<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;<SPAN class="normal">
																			<IMG style="CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></SPAN></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
												<cc1:domvalidationsummary id="vSum" runat="server" EnableClientScript="False" DisplayMode="List" ShowMessageBox="True"></cc1:domvalidationsummary><INPUT style="WIDTH: 9px; HEIGHT: 22px" id="hIdTablaEntidad" size="1" type="hidden" name="hIdTablaEntidad"
													runat="server"><INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hIdEntidad" size="1" type="hidden" name="hIdEntidad"
													runat="server"><INPUT style="WIDTH: 14px; HEIGHT: 22px" id="hIdCodigo" size="1" type="hidden" name="hIdCodigo"
													runat="server"><INPUT style="WIDTH: 15px; HEIGHT: 22px" id="hNumero" size="1" type="hidden" name="hNumero"
													runat="server"><INPUT style="WIDTH: 15px; HEIGHT: 22px" id="txtCliente" size="1" type="hidden" name="txtCliente"
													runat="server"></TD>
											<TD vAlign="bottom" align="center">
											</TD>
										</TR>
									</TABLE>
									<span class="normal"></span><span class="normal"></span>
								</TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<SCRIPT>
				var ProveedorBE=new Object();
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var IdObj="";
								
				var HandleWindow;
				var opMenu=1;
				function MnuOP_txtEntidad_OnClick(MnuID,Data){
					opMenu = parseInt(MnuID.replace('itmMnu',''));
					 jNet.get('txtEntidad').value='';
				}
				
				
				
		
				
				
			function txtEntidad_ItemDataBound(sender,e,dr){
				var ClassBase = "{Codigo:'" + dr["Codigo"].toString()+ "',RazonSocial:'" + dr["Descripcion"].toString()+ "'}" ;
				var oProveedorBE;
				eval("oProveedorBE =" + ClassBase + ";");
				CrearCtrlDestino(oProveedorBE);
				
				var oLstPrvs = jNet.get('LstPrvs');
				oLstPrvs.value = oLstPrvs.value + ((oLstPrvs.value.length==0)?"":";") + ClassBase;
				ListarPrv();
				jNet.get('txtEntidad').value='';
			}
			
			function ListarPrv(){
				var oLstPrvs = jNet.get('LstPrvs');
				eval("ProveedorBE = oLstPrvs.value.split(';')");
				ProveedorBE.forEach=function(){
					var oBE;
					var Me = this;
					for(i=0;i<=this.length-1;i++){
						eval("oBE=" + this[i]+";");
						CrearCtrlDestino(oBE);
					}
				}
				
				ProveedorBE.Delete=function(oBE){
					var pos=0;
					var tmpBE;
					var existe=false;
					for(i=0;i<=this.length-1;i++){
						eval("tmpBE=" + this[i]+";");
						if(tmpBE.Codigo==oBE.Codigo){
							pos=i;
							existe=true;
						}
					}
					if(existe==true){
						this.splice(pos,1);
					}
				}
				
			}
			
			
			

			var KEYQIDTIPOENTIDAD="idTipoEntidad";
			var oParamCollecionBusqueda = new ParamCollecionBusqueda();
			
			var oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="Descripcion";
					oParamBusqueda.Texto="Razon Social del Proveedor";
					oParamBusqueda.LongitudEjecucion=3;
					oParamBusqueda.Tipo="C";
					oParamBusqueda.Ancho=400;
					oParamBusqueda.CampoAlterno = "numero";
				oParamCollecionBusqueda.Agregar(oParamBusqueda);

					oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="numero";
					oParamBusqueda.Texto="R.U.C. de Proveedor";
					oParamBusqueda.LongitudEjecucion=5;
					oParamBusqueda.Tipo="C";
					oParamBusqueda.Ancho=400;
					oParamBusqueda.CampoAlterno = "Descripcion";
				oParamCollecionBusqueda.Agregar(oParamBusqueda);

					oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre=KEYQIDTIPOENTIDAD;
					oParamBusqueda.Valor=1;
					oParamBusqueda.ParaBusqueda=false;
					oParamBusqueda.Tipo="Q";
				oParamCollecionBusqueda.Agregar(oParamBusqueda);

					oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="idProceso";
					oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarProveedorLog;
					oParamBusqueda.ParaBusqueda=false;
					oParamBusqueda.Tipo="Q";
				oParamCollecionBusqueda.Agregar(oParamBusqueda);
			
			(new AutoBusqueda('txtEntidad')).CrearPopupOpcion( '/' + ApplicationPath + '/GestionLogistica/Procesar.aspx?',oParamCollecionBusqueda);		
			


			function CrearCtrlDestino(oProveedorBE){
				var HTMLTable = jNet.get((new SIMA.Utilitario.Helper.General.Html()).CrearTabla(1,3));
				IdObj = "obj" + oProveedorBE.Codigo;
				HTMLTable.align="left";
				HTMLTable.style.cssText="MARGIN-BOTTOM: 5px; MARGIN-LEFT: 5px";
				HTMLTable.attr("id",IdObj);
				HTMLTable.attr("BE",oProveedorBE);
				HTMLTable.className="BaseItemInGrid";
				HTMLTable.border=0;
				HTMLTable.rows[0].cells[0].innerText=oProveedorBE.RazonSocial;
				HTMLTable.rows[0].cells[0].noWrap=true;
				
				
				var oIMGlr =  SIMA.Utilitario.Helper.General.CrearImg('/' + ApplicationPath + '/imagenes/Navegador/SAMResponsable.png' );
				oIMGlr.onclick=function(){var oTBLItem = jNet.get(this.parentNode.parentNode.parentNode.parentNode);}
				
				jNet.get(HTMLTable.rows[0].cells[1]).insert(oIMGlr);
				
				var oIMG = SIMA.Utilitario.Helper.General.CrearImgEliminar(1);
				oIMG.onclick=function(){
					var oTBLItem = jNet.get(this.parentNode.parentNode.parentNode.parentNode);
						Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro de proveedor ahora?', function(btn){
										if(btn=="yes"){
											var oBE = oTBLItem.attr("BE");
											ProveedorBE.Delete(oBE);
											var oLstPrvs = jNet.get('LstPrvs');
											oLstPrvs.value =ProveedorBE.join(',');
											jNet.get('cellListDestino').removeChild(oTBLItem);
										}
									});
				}
				jNet.get(HTMLTable.rows[0].cells[2]).insert(oIMG);
				jNet.get('cellListDestino').insert(HTMLTable);
			}				
				
				ListarPrv();
				ProveedorBE.forEach();//Muestra la lista de proveedores
								
		</SCRIPT>
	</body>
</HTML>
