<%@ Page language="c#" Codebehind="CuentaBancariaCentroOperativo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasBancarias.CuentaBancariaCentroOperativo" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CuentaBancariaCentroOperativo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<SCRIPT language="JavaScript">
<!--
var singleSelect = true;
var sortSelect = true;
var sortPick = true;

function initIt()
 {
  var selectList = document.getElementById("SelectList");
  var pickList = document.getElementById("PickList");
  var pickOptions = pickList.options;
  pickOptions[0] = null; 
  selectList.focus();
 }

function addIt() 
{
  var selectList = document.getElementById("SelectList");
  var selectIndex = selectList.selectedIndex;
  var selectOptions = selectList.options;
  var pickList = document.getElementById("PickList");
  var pickOptions = pickList.options;
  var pickOLength = pickOptions.length;
  if (selectIndex > -1) 
	{
    pickOptions[pickOLength] = new Option(selectList[selectIndex].text);
    pickOptions[pickOLength].value = selectList[selectIndex].value;
    pickOptions[pickOLength].style.color="blue";
    var strValText = selectList[selectIndex].text;
    if (singleSelect) 
		{
			selectOptions[selectIndex] = null;
		}
  }
}



// Deletes an item from the picklist
function delIt() {
  var selectList = document.getElementById("SelectList");
  var selectOptions = selectList.options;
  var selectOLength = selectOptions.length;
  var pickList = document.getElementById("PickList");
  var pickIndex = pickList.selectedIndex;
  var pickOptions = pickList.options;
  if (pickIndex > -1) {
    // If single selection, replace the item in the select list
    if (singleSelect) {
      selectOptions[selectOLength] = new Option(pickList[pickIndex].text);
      selectOptions[selectOLength].value = pickList[pickIndex].value;
    }
    pickOptions[pickIndex] = null;
    if (singleSelect && sortSelect) {
      var tempText;
      var tempValue;
      // Re-sort the select list
      while (selectOLength > 0 && selectOptions[selectOLength].value < selectOptions[selectOLength-1].value) {
        tempText = selectOptions[selectOLength-1].text;
        tempValue = selectOptions[selectOLength-1].value;
        selectOptions[selectOLength-1].text = selectOptions[selectOLength].text;
        selectOptions[selectOLength-1].value = selectOptions[selectOLength].value;
        selectOptions[selectOLength-1].style.color="red";
        selectOptions[selectOLength].text = tempText;
        selectOptions[selectOLength].value = tempValue;
        selectOLength = selectOLength - 1;
      }
    }
    
  }
}

function MostrarDetalleCtaBco(ListboxOP)
{
	LimpiarObjectos();
	var ArrayDatos=ListboxOP.value.split(";");
	MostrarDatosEnCajaTexto("txtTipoCtaBco",ArrayDatos[2]);
	MostrarDatosEnCajaTexto("txtMoneda",ArrayDatos[3]);
	MostrarDatosEnCajaTexto("txtFechaApertura",ArrayDatos[4]);	
}
function MostrarDetalleCtaBcoPorCentro(ListboxOP)
{
	LimpiarObjectos();
	var ArrayDatos=ListboxOP.value.split(";");
	
	MostrarDatosEnCajaTexto("txtTipoCtaBco",ArrayDatos[2]);	
	MostrarDatosEnCajaTexto("txtMoneda",ArrayDatos[3]);	
	MostrarDatosEnCajaTexto("txtFechaApertura",ArrayDatos[4]);	
	SeleccionarListElemento("ddlbCentroOperativoAdm",ArrayDatos[5]);
	SeleccionarListElemento("ddlbSituacion",ArrayDatos[6]);
	
}

function SeleccionarListElemento(ObjetoNombre,Valor)
{
	var selectLista = document.getElementById(ObjetoNombre);
	for(var i=0; i<=selectLista.options.length;i++)
	{
		if (Valor==0)
		{
			selectLista.selectedIndex = 0;
			return;
		}
		if(selectLista.options[i].value == Valor)
		{
			selectLista.selectedIndex = i;
			return;
		}
	}
}

function CambiarValorTrama(ObjetoNombre,Indice)
{
	//window.alert(document.Form1.PickList.options[document.Form1.PickList.selectedIndex].value);
	var LstObjeto = document.getElementById(ObjetoNombre);
	var ArrayDatos=document.Form1.PickList.options[document.Form1.PickList.selectedIndex].value.split(";");
	/*REALIZA LOS CAMBIOS SEGUN VALOR SELECCIONADO*/
	ArrayDatos[Indice] =  LstObjeto.options[LstObjeto.selectedIndex].value;
	if(ArrayDatos[ArrayDatos.length-1] == "C")
	{
		ArrayDatos[ArrayDatos.length-1] ="M";
	}
	var strNewTrama="";
	for(var i=0;i<=ArrayDatos.length-1;i++)
	{
		var strTramaTmp = ArrayDatos[i];	
		strNewTrama = strNewTrama + strTramaTmp + ";";
	}
	document.Form1.PickList.options[document.Form1.PickList.selectedIndex].value = strNewTrama.substring(0,strNewTrama.length-1);
	document.Form1.PickList.options[document.Form1.PickList.selectedIndex].style.color ="blue";
	//window.alert(document.Form1.PickList.options[document.Form1.PickList.selectedIndex].value);
	//ObtenerTramas();
}
function LimpiarObjectos()
{
	MostrarDatosEnCajaTexto("hIdCtaBco","");
	MostrarDatosEnCajaTexto("txtTipoCtaBco","");
	MostrarDatosEnCajaTexto("txtMoneda","");
	MostrarDatosEnCajaTexto("txtFechaApertura","");
	document.Form1.ddlbCentroOperativoAdm.selectedIndex = 0;
	document.Form1.ddlbSituacion.selectedIndex = 0;
}
function ObtenerTramas()
{
	/*Obtiene la Trama de los Registros que fueron Adicionados o Modificados */
	var strTramaFinal="";
	MostrarDatosEnCajaTexto("txtTramaRegModificadoNuevo",strTramaFinal);
	for(var i=0;i<=document.Form1.PickList.options.length-1;i++)
	{
		var strValor = document.Form1.PickList.options[i].value;
		var ArrayValor = strValor.split(";");
		if ((ArrayValor[ArrayValor.length-1]=="M") ||(ArrayValor[ArrayValor.length-1]=="N"))
		{
			strTramaFinal = strTramaFinal + strValor + "@"; 
		}
	}
	if (strTramaFinal.length > 0 )
	{
		MostrarDatosEnCajaTexto("txtTramaRegModificadoNuevo",strTramaFinal.substring(0,strTramaFinal.length-1));
	}
	strTramaFinal="";
	MostrarDatosEnCajaTexto("txtTramaRegEliminados",strTramaFinal);
	/*obtiene la trama de aquellos registros que fueros eliminados o quitados del Centro Seleccionado*/
	for(var i=0;i<=document.Form1.SelectList.options.length-1;i++)
	{
		var strValor = document.Form1.SelectList.options[i].value;
		var ArrayValor = strValor.split(";");
		if ((ArrayValor[ArrayValor.length-1]=="C"))
		{
			strTramaFinal = strTramaFinal + strValor + "@"; 
		}
	}
	if (strTramaFinal.length > 0 )
	{
		MostrarDatosEnCajaTexto("txtTramaRegEliminados",strTramaFinal.substring(0,strTramaFinal.length-1));
	}
	
}
-->
		</SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" onload="ObtenerHistorial();" onunload="SubirHistorial();"
		bottomMargin="0" leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" style="HEIGHT: 49px">
				<tr>
					<td colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR>
					<TD colSpan="1"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Cuenta Bancaria por Centro Operativo</asp:label></TD>
				</TR>
				<TR>
					<TD><IMG style="WIDTH: 160px; HEIGHT: 16px" height="16" src="../../imagenes/spacer.gif" width="160"></TD>
				</TR>
				<TR>
					<TD>
						<TABLE style="HEIGHT: 491px" cellSpacing="0" cellPadding="0" width="477" align="center"
							border="0">
							<TR>
								<TD style="HEIGHT: 431px" align="center">
									<TABLE class="normal" id="Table1" style="WIDTH: 654px; HEIGHT: 412px" cellSpacing="0" cellPadding="0"
										width="654" border="0">
										<TR>
											<TD style="WIDTH: 2px; HEIGHT: 377px"></TD>
											<TD style="WIDTH: 671px; HEIGHT: 377px">
												<DIV align="center">
													<TABLE style="WIDTH: 504px; HEIGHT: 379px" cellSpacing="0" cellPadding="2" align="center"
														border="0">
														<TR>
															<TD style="WIDTH: 470px" align="left" bgColor="#000080" colSpan="4">
																<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Width="458px" Height="16px">DETALLE ADMINISTRACION DE CUENTAS BANCARIAS POR CENTRO OPERATIVO</asp:label></TD>
														</TR>
														<TR class="AlternateItemDetalle">
															<TD style="WIDTH: 470px" align="center" colSpan="3" class="HeaderDetalle">
																<asp:label id="Label1" runat="server">Entidad Financiera (Banco)</asp:label>
															</TD>
															<TD style="WIDTH: 3px" align="center"></TD>
														</TR>
														<TR class="ItemDetalle">
															<TD align="left" colSpan="3">
																<asp:dropdownlist id="ddlbEntidadFinanciera" runat="server" CssClass="normaldetalle" Width="100%"></asp:dropdownlist></TD>
															<TD style="WIDTH: 3px; HEIGHT: 10px" align="left"></TD>
														</TR>
														<TR class="AlternateItemDetalle">
															<TD class="HeaderDetalle" style="WIDTH: 265px; HEIGHT: 17px">
																<asp:label id="Label4" runat="server">Centro De Operación :</asp:label></TD>
															<TD style="WIDTH: 265px; HEIGHT: 17px" colSpan="2">
																<asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Width="100%"></asp:dropdownlist></TD>
															<TD style="WIDTH: 213px; HEIGHT: 17px">
																<P align="right">
																	<asp:button id="btnMostrar" runat="server" Text="Mostrar"></asp:button></P>
															</TD>
														</TR>
														<TR class="ItemDetalle">
															<TD class="HeaderDetalle" style="WIDTH: 181px; HEIGHT: 9px">
																<asp:label id="Label2" runat="server" Width="193px" DESIGNTIMEDRAGDROP="514">Cuentas Bancarias Disponibles</asp:label></TD>
															<TD style="WIDTH: 39px; HEIGHT: 9px"></TD>
															<TD class="HeaderDetalle" style="WIDTH: 213px; HEIGHT: 9px">
																<asp:label id="Label3" runat="server">Cuentas Bancarias Asignadas</asp:label></TD>
															<TD style="WIDTH: 3px; HEIGHT: 9px"></TD>
														</TR>
														<TR class="AlternateItemDetalle">
															<TD style="WIDTH: 181px; HEIGHT: 92px"><SELECT class="normaldetalle" id="SelectList" style="WIDTH: 221px; HEIGHT: 86px" size="5"
																	name="SelectList" runat="server">
																	<OPTION value="1;AHORROS;SOLES;01/01/2005">Selection 01</OPTION>
																	<OPTION value="2;AHORROS;SOLES;03/01/2005">Selection 02</OPTION>
																	<OPTION value="3;CTA CTE;SOLES;01/01/2000">Selection 03</OPTION>
																	<OPTION value="4;CTA CTE;DOLARES;06/01/2001">Selection 04</OPTION>
																	<OPTION value="5;AHORROS;SOLES;01/01/2002">Selection 05</OPTION>
																	<OPTION value="6;CTA CTE;DOLARES;08/01/2003">Selection 06</OPTION>
																	<OPTION value="7;AHORROS;SOLES;01/01/2004">Selection 07</OPTION>
																	<OPTION value="8;AHORROS;EUROS;09/01/2005">Selection 08</OPTION>
																	<OPTION value="9;AHORROS;SOLES;01/01/2006">Selection 09</OPTION>
																	<OPTION value="10;CTA CTE;SOLES;01/01/2007">Selection 10</OPTION>
																</SELECT>
															</TD>
															<TD style="WIDTH: 39px; HEIGHT: 92px">
																<P align="center"></INPUT>
																	<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="20" border="0">
																		<TR>
																			<TD><IMG onmouseup="this.src='../../imagenes/AgregarC.GIF';" onmousedown="this.src='../../imagenes/Agregar.GIF';"
																					id="btnAgregar" onmouseover="this.src='../../imagenes/AgregarB.GIF';" onclick="addIt();"
																					onmouseout="this.src='../../imagenes/AgregarA.GIF';" src="../../imagenes/AgregarA.GIF"
																					name="btnAgregar"></TD>
																		</TR>
																		<TR>
																			<TD><IMG onmouseup="this.src='../../imagenes/QuitarC.GIF';" onmousedown="this.src='../../imagenes/Quitar.GIF';"
																					id="btnQuitar" onmouseover="this.src='../../imagenes/QuitarB.GIF';" onclick="delIt();"
																					onmouseout="this.src='../../imagenes/QuitarA.GIF';" src="../../imagenes/QuitarA.GIF"
																					name="btnQuitar"></TD>
																		</TR>
																	</TABLE>
																</P>
															</TD>
															<TD style="WIDTH: 213px; HEIGHT: 92px"><SELECT class="normaldetalle" id="PickList" style="WIDTH: 215px; HEIGHT: 86px" size="5"
																	name="PickList" runat="server"></SELECT>
															</TD>
															<TD style="WIDTH: 3px; HEIGHT: 92px"></TD>
														</TR>
														<TR class="ItemDetalle">
															<TD style="WIDTH: 470px" colSpan="4" bgColor="#000080">
																<asp:label id="Label5" runat="server" CssClass="TituloPrincipalBlanco" Width="359px" Font-Bold="True">DATOS COMPLEMENTARIO DE LA CUENTA BANCARIA</asp:label></TD>
														</TR>
														<TR class="AlternateItemDetalle">
															<TD style="HEIGHT: 18px" width="1500" colSpan="3">
																<TABLE id="Table2" style="WIDTH: 476px; HEIGHT: 12px" cellSpacing="1" cellPadding="1" width="476"
																	align="left" border="0">
																	<TR>
																		<TD style="WIDTH: 109px" class="HeaderDetalle">
																			<asp:label id="Label6" runat="server" DESIGNTIMEDRAGDROP="2481" Height="8px" Width="53px">Tipo Cta</asp:label></TD>
																		<TD style="WIDTH: 46px">
																			<asp:textbox id="txtTipoCtaBco" runat="server" CssClass="normaldetalle" Width="54px" BorderStyle="Groove"
																				ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
																		<TD style="WIDTH: 40px" class="HeaderDetalle">
																			<asp:label id="Label7" runat="server" DESIGNTIMEDRAGDROP="790">Moneda</asp:label></TD>
																		<TD style="WIDTH: 133px">
																			<asp:textbox id="txtMoneda" runat="server" CssClass="normaldetalle" Width="120px" BorderStyle="Groove"
																				ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
																		<TD style="WIDTH: 108px" class="HeaderDetalle">
																			<asp:label id="Label8" runat="server" Width="96px">Fecha Apertura</asp:label></TD>
																		<TD style="WIDTH: 1px">
																			<asp:textbox id="txtFechaApertura" runat="server" CssClass="normaldetalle" Width="68px" BorderStyle="Groove"
																				ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
																	</TR>
																</TABLE>
															</TD>
															<TD style="WIDTH: 3px; HEIGHT: 18px"><INPUT id="hIdCtaBco" style="WIDTH: 10px; HEIGHT: 22px" type="hidden" size="1" runat="server"></TD>
														</TR>
														<TR class="ItemDetalle">
															<TD vAlign="top" colSpan="2" style="WIDTH: 265px">
																<DIV align="left">
																	<TABLE class="gg" id="tblNota" style="WIDTH: 251px; HEIGHT: 56px" cellSpacing="1" cellPadding="1"
																		width="251" align="left" border="0">
																		<TR>
																			<TD style="WIDTH: 30px; HEIGHT: 18px" align="right" class="HeaderDetalle"><IMG src="../../imagenes/post.gif"></TD>
																			<TD style="HEIGHT: 18px" class="HeaderDetalle">
																				<asp:Label id="Label12" runat="server" Width="190px" Font-Bold="True">Nota :</asp:Label></TD>
																		</TR>
																		<TR>
																			<TD colSpan="2"><SPAN class="normal"><SPAN class="normal"><SPAN class="normal"><SPAN class="normal"><SPAN class="normal">
																									<asp:Label id="Label11" runat="server" Width="240px" Height="13px"> Para que una Cuenta Bancaria este asociada a un      Centro, por favor Definir quién Administra dicha Cuenta, con la Opción. Administrado por y Definir su Estado, Seleccionando Estado de la Cuenta :</asp:Label></SPAN></SPAN></SPAN></SPAN></SPAN></TD>
																		</TR>
																	</TABLE>
																</DIV>
															</TD>
															<TD style="WIDTH: 213px; HEIGHT: 4px">
																<TABLE id="Table4" style="WIDTH: 216px; HEIGHT: 95px" cellSpacing="1" cellPadding="1" width="216"
																	align="left" border="0">
																	<TR>
																		<TD colSpan="2" class="HeaderDetalle">
																			<asp:label id="Label10" runat="server" Width="132px">Administrado por:</asp:label></TD>
																	</TR>
																	<TR>
																		<TD colSpan="2"><SELECT class="combos" id="ddlbCentroOperativoAdm" style="WIDTH: 212px" runat="server"></SELECT></TD>
																	</TR>
																	<TR>
																		<TD colSpan="2" class="HeaderDetalle">
																			<asp:label id="Label9" runat="server" Width="137px">Estado de la Cuenta</asp:label></TD>
																	</TR>
																	<TR>
																		<TD colSpan="2"><SELECT class="combos" id="ddlbSituacion" style="WIDTH: 212px" name="Select1" runat="server"></SELECT></TD>
																	</TR>
																</TABLE>
															</TD>
															<TD style="WIDTH: 3px; HEIGHT: 4px"><INPUT id="hIdCentroOrg" style="WIDTH: 36px; HEIGHT: 22px" type="hidden" size="1" runat="server"><INPUT id="txtTramaRegModificadoNuevo" style="WIDTH: 38px; HEIGHT: 22px" type="hidden"
																	size="1" name="Hidden1" runat="server"><INPUT id="txtTramaRegEliminados" style="WIDTH: 50px; HEIGHT: 22px" type="hidden" size="3"
																	name="Hidden2" runat="server"></TD>
														</TR>
														<TR class="AlternateItemDetalle">
															<TD vAlign="top" colSpan="3" align="right" width="1500">
																<TABLE id="Table5" style="WIDTH: 185px; HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="185"
																	align="right" border="0">
																	<TR>
																		<TD>
																			<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
																		<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
																	</TR>
																</TABLE>
															</TD>
															<TD style="WIDTH: 3px; HEIGHT: 1px"></TD>
														</TR>
													</TABLE>
												</DIV>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 681px" align="center" width="681" colSpan="3">
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
										</TR>
									</TABLE>
									<INPUT id="hCodigo" style="WIDTH: 111px; HEIGHT: 22px" type="hidden" size="13" name="hIdTablaEntidad"
										runat="server"> <IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
				</tr>
			</table>
			</TD></TR>
			<TR bgColor="#5891ae">
				<TD align="center" width="592" bgColor="#5891ae"></TD>
			</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
