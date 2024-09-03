<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarFormulaFinanciera.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.AdministrarFormulaFinanciera" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="ParametroContable" Src="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarFormulaFinanciera</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta http-equiv="Page-Enter" content="revealTrans(duration=1, transition=12)">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script>
			function AsignarValorAlaFila(idCampo)
			{
				var e = window.event.srcElement;
				switch(e.parentElement.parentElement.getAttribute("Estado"))
				{
					case "E":
							e.parentElement.parentElement.removeAttribute("Estado");
							e.parentElement.parentElement.setAttribute("Estado","M");
						break;
					case "P":
							e.parentElement.parentElement.removeAttribute("Estado");
							e.parentElement.parentElement.setAttribute("Estado","N");
						break;
				}
				//alert(e.parentElement.parentElement.rowIndex);
				//Identifica que campo fue el que realizo la edicion
				switch(parseInt(idCampo))
				{
					case 1://Matematico
						e.parentElement.parentElement.removeAttribute("CmpValMAT");
						e.parentElement.parentElement.setAttribute("CmpValMAT",e.options.value);
						break;
					case 2://Cuenta Contable
						e.parentElement.parentElement.removeAttribute("CmpValCTA");
						e.parentElement.parentElement.setAttribute("CmpValCTA",e.value);
						break;
					case 3://Logico
						e.parentElement.parentElement.removeAttribute("CmpValLOG");
						e.parentElement.parentElement.setAttribute("CmpValLOG",e.options.value);
						break;
					case 4://Estado
						e.parentElement.parentElement.removeAttribute("CmpValEST");
						e.parentElement.parentElement.setAttribute("CmpValEST",(e.checked==true)?1:0);
						break;
				}
			}
			
			function RetornarPantallaAnterior()
			{
				var NODOSELECCIONADO="NodoSeleccionado";
				ReemplazarParametrodeHistorial(NODOSELECCIONADO, (new SIMA.Utilitario.Helper.General.Pagina()).Request.Params[NODOSELECCIONADO]);
			}

			function AgregarFila(){
					var oGrid = jNet.get('gridAdm');
					var orow = oGrid.rows[oGrid.rows.length-1];
					var oGridBody = orow.parentNode;
					var oRowClon = jNet.get(orow.cloneNode(true));
					oRowClon.setAttribute("CmpValID",0);
					oRowClon.setAttribute("CmpValMAT","0");
					oRowClon.setAttribute("CmpValCTA","");//Cuenta Contable
					oRowClon.setAttribute("CmpValLOG","0");//Operador logico
					oRowClon.setAttribute("CmpValEST","1");
					oRowClon.setAttribute("Estado","P");
					oGridBody.appendChild(oRowClon);
					jNet.get(oRowClon.cells[1].children[0]).value='';
			}
			function GrabarFila(){
				var KEYQIDFORMATO="IdFormato";
				var KEYQIDREPORTE = "IdReporte";
				var KEYQIDRUBRO="IdRubro";
				var KEYQIDCOLUMNA="IdCol";
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var grid = document.all["gridAdm"];
				var ValorRegistro="";
				var NroReg = grid.rows.length-1;
				
				for(var i=1;i<=NroReg;i++){
					try{
						var AtributodeRegistro = grid.rows[i].getAttribute("Estado");
						if ((AtributodeRegistro=="M") || (AtributodeRegistro=="N")){
							ValorRegistro="";
							
							with(grid.rows[i]){
								ValorRegistro += "@" + getAttribute("CmpValID") + ";";//id del Registro
								ValorRegistro += AtributodeRegistro + ";";//Modo de edicion
								ValorRegistro += getAttribute("CmpValMAT") + ";";//OPerador matematico
								ValorRegistro += getAttribute("CmpValCTA") + ";";//Cuenta Contable
								ValorRegistro += getAttribute("CmpValLOG") + ";";//Operador logico
								ValorRegistro += getAttribute("CmpValEST");//estado del registro
								var ID = (new Controladora.General.CFormatoReporteFormulaContable()).InsAct(oPagina.Request.Params[KEYQIDFORMATO],oPagina.Request.Params[KEYQIDREPORTE],oPagina.Request.Params[KEYQIDRUBRO],oPagina.Request.Params[KEYQIDCOLUMNA],ValorRegistro);
								setAttribute("CmpValID",ID);
								setAttribute("CmpValEST","1");
								setAttribute("Estado","E");
							}
							
						}
					}
					catch(exception){
					}
				}				
				//Agregar una fila nueva
				AgregarFila();
			}
			//oncontextmenu="return false"
		</script>
	</HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==116)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR bgColor="#f0f0f0">
					<TD class="RutaPaginaActual" style="HEIGHT: 22px" align="left" colSpan="2"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Estados Financieros></asp:label><asp:label id="lblReporte" runat="server" CssClass="RutaPagina">[REPORTE]</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<TR>
								<TD align="center">
									<TABLE id="Table3" style="HEIGHT: 18px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 9px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 474px"><asp:label id="lblRubro" runat="server" CssClass="TituloPrincipal">[RUBRO]</asp:label></TD>
											<TD style="WIDTH: 646px" align="right" colSpan="3"></TD>
											<TD align="right">
												<asp:Image id="ibtnGrabarFila" runat="server" ImageUrl="../../imagenes/ibtnGrabar.GIF"></asp:Image></TD>
											<TD style="WIDTH: 4px" align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="gridAdm" runat="server" PageSize="15" Width="100%" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="OPERACION">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemTemplate>
													<asp:DropDownList id="ddblOperador" runat="server" Width="93px"></asp:DropDownList>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="CUENTA CONTABLE">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemTemplate>
&nbsp; 
<asp:TextBox id="txtCuenta" runat="server" Width="133px"></asp:TextBox>
<asp:Image id="imgBtnDetalle" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:Image>
</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="CONDICION">
												<HeaderStyle Width="50ex"></HeaderStyle>
												<ItemTemplate>
													<asp:DropDownList id="ddblCondicion" runat="server" Width="100%"></asp:DropDownList>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="EST">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemTemplate>
													<asp:CheckBox id="chkActivo" runat="server"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn HeaderText="EST">
												<HeaderStyle Width="1%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="idFormula" HeaderText="ID">
												<HeaderStyle Width="1%"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 1px" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="right"><INPUT id="hRegistro" type="hidden" name="hRegistro" runat="server"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<SCRIPT>
				//SIMA.Utilitario.Error.TiempoEsperadePagina();
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
