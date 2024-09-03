<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="AdministrarPresupuestodeFinanciamiento.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios.AdministrarPresupuestodeFinanciamiento" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<script>
			var Prefijo1="grid__ctl";
			var Prefijo2="_n";

			function ObtenerValorSinFormato(strValor)
			{
				var mValor1 = Reemplazar(strValor," ","");
				var mValor2 = Reemplazar(mValor1," ","");
				return mValor2;
			}
			
			function IdentificarCeldaModificada(objInput,idFila,idCol)
			{
				var dbgrid = document.all["grid"];
				var MontoActual =ObtenerValorSinFormato(dbgrid.rows[parseInt(idFila-1)].cells(parseInt(idCol)).getAttribute("MONTO"));
				var Monto = parseFloat(ObtenerValorSinFormato(objInput.value));
				if (parseFloat(MontoActual) != parseFloat(Monto))
				{
					dbgrid.rows[parseInt(idFila-1)].cells(parseInt(idCol)).setAttribute("MONTO",objInput.value);
					dbgrid.rows[parseInt(idFila-1)].cells(parseInt(idCol)).setAttribute("MODIFICADO","SI");
					dbgrid.rows[parseInt(idFila-1)].setAttribute("FILAMODIFICADA","SI");
				}
			}
			
			function ValidaNro(objInput)
			{
				var KeyTecla = event.keyCode;
				var Letra =String.fromCharCode(KeyTecla);
				var valor = objInput.value.toUpperCase();
				/*Variables para Controlar el desplazamiento*/
				var Nombreobj =objInput.id;

				var strNC = Nombreobj.replace(Prefijo1,"");
				var idFilaCol = strNC.replace("n","");
				var arrIdx = idFilaCol.split('_');
				
				
				
				if (event.keyCode ==13 || event.keyCode ==40)//Flecha Abajo o Enter
				{
					var idSiguiente = (parseInt(arrIdx[0])+1);
					var NrombreObjSiguiente = Prefijo1 +  idSiguiente + Prefijo2 + arrIdx[1];
					
					IdentificarCeldaModificada(objInput,arrIdx[0],arrIdx[1]);
					
					var ObjSiguiente = document.all[NrombreObjSiguiente];
					if (ObjSiguiente !=undefined){ObjSiguiente.focus();}
					//if (ObjSiguiente !=undefined){ObjSiguiente.focus();IdentificarCeldaModificada(objInput,arrIdx[0],arrIdx[1]);}
				}
				else if (event.keyCode ==38)//Flecha Arriba
				{
					var idAnterior = (parseInt(arrIdx[0])-1);
					var NrombreObjAnterior = Prefijo1 + idAnterior + Prefijo2 + arrIdx[1];
					var ObjAnterior = document.all[NrombreObjAnterior];
					//if (ObjAnterior !=undefined){ObjAnterior.focus();IdentificarCeldaModificada(objInput,arrIdx[0],arrIdx[1])}
					IdentificarCeldaModificada(objInput,arrIdx[0],arrIdx[1]);
					if (ObjAnterior !=undefined){ObjAnterior.focus();}
				}
				else if (event.keyCode ==39)//Flecha Derecha
				{
					var idDerecha = (parseInt(arrIdx[1])+1);
					var NrombreObjDerecha = Prefijo1 + arrIdx[0] + Prefijo2 + idDerecha ;
					var ObjDerecha = document.all[NrombreObjDerecha];
					//if (ObjDerecha !=undefined){ObjDerecha.focus();IdentificarCeldaModificada(objInput,arrIdx[0],arrIdx[1])}
					IdentificarCeldaModificada(objInput,arrIdx[0],arrIdx[1]);
					if (ObjDerecha !=undefined){ObjDerecha.focus();}
				}
				else if (event.keyCode ==37)//Flecha Izquierda
				{
					var idIzquierda = (parseInt(arrIdx[1])-1);
					var NrombreObjIzquierda = Prefijo1 + arrIdx[0] + Prefijo2 + idIzquierda ;
					var ObjIzquierda = document.all[NrombreObjIzquierda];
					//if (ObjIzquierda !=undefined){ObjIzquierda.focus();IdentificarCeldaModificada(objInput,arrIdx[0],arrIdx[1])}
					IdentificarCeldaModificada(objInput,arrIdx[0],arrIdx[1]);
					if (ObjIzquierda !=undefined){ObjIzquierda.focus();}
				}
			}
			
			
			function GrabarColumnasModificadas()
			{
				PopupDeEspera();
				var strData= "";
				var dbgrid = document.all["grid"];
				for(var i=1;i<=dbgrid.rows.length-2;i++)
				{
					if (dbgrid.rows[i].getAttribute("FILAMODIFICADA")!=null)
					{
						strData += dbgrid.rows[i].getAttribute("IDEF");
						for(var c=1;c<=12;c++)
						{
							if (dbgrid.rows[i].cells(c).getAttribute("MODIFICADO") =="SI")
							{
								strData +=  "*" + c + "_" + dbgrid.rows[i].cells(c).getAttribute("MONTO") + "_" + dbgrid.rows[i].cells(c).getAttribute("MONTOAMORTIZA") + "_" + dbgrid.rows[i].cells(c).getAttribute("MONTOINTERES");
							}
						}
						strData += "@";
					}
				}
				MostrarDatosEnCajaTexto("hTrama",strData);
			}
			
			
			function MostrarAmortizacioneInteres(objInput)
			{
				var Nombreobj =objInput.id;
					
				var strNC = Nombreobj.replace(Prefijo1,"");
				var idFilaCol = strNC.replace("n","");
				var arrIdx = idFilaCol.split('_');
				
				var dbgrid = document.all["grid"];
				var MontoAmortiza = dbgrid.rows[parseInt(arrIdx[0]-1)].cells(parseInt(arrIdx[1])).getAttribute("MONTOAMORTIZA");
				var MontoInteres = dbgrid.rows[parseInt(arrIdx[0]-1)].cells(parseInt(arrIdx[1])).getAttribute("MONTOINTERES");

				var URLAMORTIZAPTMO = "DialogoEditarMontoAmortizadoeInteres.aspx?";
				var KEYMONTOAMORTIZA ="ma";
				var KEYMONTOINTERES ="mi";
				var KEYNOMBREBANCO ="nb";
				var strQuery = KEYMONTOAMORTIZA + "=" + MontoAmortiza
								+ "&"
								+ KEYMONTOINTERES + "=" + MontoInteres
								+ "&"
								+ KEYNOMBREBANCO + "= BANCO " + dbgrid.rows[parseInt(arrIdx[0]-1)].getAttribute("NOMBREBCO");
								
				var ArrayMonto = new Array();
				ArrayMonto=window.showModalDialog(URLAMORTIZAPTMO + strQuery,window,"dialogWidth:470px;dialogHeight:220px"); 
				
				if(ArrayMonto!=null)
				{ 
					dbgrid.rows[parseInt(arrIdx[0]-1)].cells(parseInt(arrIdx[1])).setAttribute("MONTOAMORTIZA",ArrayMonto[0]);
					dbgrid.rows[parseInt(arrIdx[0]-1)].cells(parseInt(arrIdx[1])).setAttribute("MONTOINTERES",ArrayMonto[1]);
					dbgrid.rows[parseInt(arrIdx[0]-1)].cells(parseInt(arrIdx[1])).setAttribute("MODIFICADO","SI");
					dbgrid.rows[parseInt(arrIdx[0]-1)].setAttribute("FILAMODIFICADA","SI");
				}
			}
			
		</script>
		<!--oncontextmenu="return false"-->
	</HEAD>
	<body onkeydown="if(event.keyCode==13){return false;}" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera>Presupuesto></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Presupuesto de Financiamiento</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="751" border="0">
							<TR>
								<TD style="WIDTH: 723px" align="left" width="723" colSpan="3"><asp:label id="lblTipoPresupuesto" runat="server" CssClass="TituloPrincipalBlanco" Width="343px"
										ForeColor="Navy" BackColor="Transparent">TIPO PRESUPUESTO</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 724px" align="center" width="724" colSpan="3">
									<TABLE id="Table13" cellSpacing="1" cellPadding="1" width="656" align="left" border="0"
										style="WIDTH: 656px; HEIGHT: 23px">
										<TR>
											<TD style="WIDTH: 2px; HEIGHT: 2px"><asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" Width="80%" ForeColor="Navy"
													BackColor="Transparent" DESIGNTIMEDRAGDROP="77">PERIODO :</asp:label></TD>
											<TD style="WIDTH: 12px; HEIGHT: 2px"><asp:label id="lblPeriodo" runat="server" CssClass="TituloPrincipalBlanco" Width="32px" ForeColor="Navy"
													BackColor="Transparent"> 2005</asp:label></TD>
											<TD style="WIDTH: 41px; HEIGHT: 2px"><asp:label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" Width="163px" ForeColor="Navy"
													BackColor="Transparent">CENTRO DE OPERACIONES</asp:label></TD>
											<TD align="left" width="50%" style="HEIGHT: 2px"><asp:dropdownlist id="ddldCentrodeOperaciones" runat="server" CssClass="combos" Width="355px" DESIGNTIMEDRAGDROP="40"
													AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 2px"></TD>
											<TD style="WIDTH: 12px"></TD>
											<TD style="WIDTH: 41px">
												<asp:label id="Label2" runat="server" CssClass="TituloPrincipalBlanco" BackColor="Transparent"
													ForeColor="Navy" Width="163px">TIPO </asp:label></TD>
											<TD align="left" width="50%">
												<asp:dropdownlist id="ddldTipo" runat="server" CssClass="combos" Width="355px" DESIGNTIMEDRAGDROP="40"
													AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 12px"></TD>
											<TD style="WIDTH: 656px"><asp:imagebutton id="ibtnAgregar" runat="server" CausesValidation="False" ImageUrl="../../imagenes/ibtnGrabar.GIF"></asp:imagebutton></TD>
											<TD style="WIDTH: 382px"></TD>
											<TD style="WIDTH: 31px"></TD>
											<TD style="WIDTH: 115px"></TD>
											<TD style="WIDTH: 188px"></TD>
											<TD style="WIDTH: 187px"></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="769px" AllowSorting="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0" ShowFooter="True">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="RazonSocial" HeaderText="ENTIDADFINANCIERA">
												<HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="ENE">
												<HeaderStyle Width="52px"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="n1" runat="server" CssClass="normaldetalle" BackColor="Transparent" Width="52px"
														PlacesBeforeDecimal="15" TextAlign="Right" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="FEB">
												<HeaderStyle Width="52px"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="n2" runat="server" CssClass="normaldetalle" BackColor="Transparent" Width="52px"
														PlacesBeforeDecimal="15" TextAlign="Right" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="MAR">
												<HeaderStyle Width="52px"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="n3" runat="server" CssClass="normaldetalle" BackColor="Transparent" Width="52px"
														PlacesBeforeDecimal="15" TextAlign="Right" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="ABR">
												<HeaderStyle Width="52px"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="n4" runat="server" CssClass="normaldetalle" BackColor="Transparent" Width="52px"
														PlacesBeforeDecimal="15" TextAlign="Right" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="MAY">
												<HeaderStyle Width="52px"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="n5" runat="server" CssClass="normaldetalle" BackColor="Transparent" Width="52px"
														PlacesBeforeDecimal="15" TextAlign="Right" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="JUN">
												<HeaderStyle Width="52px"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="n6" runat="server" CssClass="normaldetalle" BackColor="Transparent" Width="52px"
														PlacesBeforeDecimal="15" TextAlign="Right" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="JUL">
												<HeaderStyle Width="52px"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="n7" runat="server" CssClass="normaldetalle" BackColor="Transparent" Width="52px"
														PlacesBeforeDecimal="15" TextAlign="Right" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="AGO">
												<HeaderStyle Width="52px"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="n8" runat="server" CssClass="normaldetalle" BackColor="Transparent" Width="52px"
														PlacesBeforeDecimal="15" TextAlign="Right" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="SET">
												<HeaderStyle Width="52px"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="n9" runat="server" CssClass="normaldetalle" BackColor="Transparent" Width="52px"
														PlacesBeforeDecimal="15" TextAlign="Right" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="OCT">
												<HeaderStyle Width="52px"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="n10" runat="server" CssClass="normaldetalle" BackColor="Transparent" Width="52px"
														PlacesBeforeDecimal="15" TextAlign="Right" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="NOV">
												<HeaderStyle Width="52px"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="n11" runat="server" CssClass="normaldetalle" BackColor="Transparent" Width="52px"
														PlacesBeforeDecimal="15" TextAlign="Right" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="DIC">
												<HeaderStyle Width="52px"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="n12" runat="server" CssClass="normaldetalle" BackColor="Transparent" Width="52px"
														PlacesBeforeDecimal="15" TextAlign="Right" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="pTotalPpto" HeaderText="TOTAL">
												<HeaderStyle Width="52px"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server"><INPUT id="hTrama" type="hidden" name="hTrama" runat="server" style="WIDTH: 64px; HEIGHT: 22px"
										size="5"></TD>
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
