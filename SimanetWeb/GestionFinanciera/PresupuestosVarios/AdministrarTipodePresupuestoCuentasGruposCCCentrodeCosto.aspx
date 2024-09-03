<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios.AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto" debug="False" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
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
			var strData;
			var pathImg = ObtenerPathAppWeb()+ "/imagenes/tree/";
			var Prefijo1="grid__ctl";
			var Prefijo2="_nMonto";
			var MontoActual=0; //Biene a ser el Monto con que se encuentra a la selda en donde se pociciona el cursor,
			
			function CargarDetalleNaturaleza5Dig(objImagen,idGrupoCta)
			{
				var URLPAGINA ="CargarNodoPresupuestoCentrodeCostoPorNaturalezadeGasto.aspx?";
				var strCadena = BuscarParametro(idGrupoCta,"QUERY");
				var idFila = BuscarParametro(idGrupoCta,"IDFILA");
				var dbgrid = document.all["grid"];
				if (dbgrid.rows[idFila].getAttribute("CARGADO")=="0")
				{
					PopupDeEspera();
					miVentana=window.showModalDialog(URLPAGINA + strCadena,window,"dialogHeight: 5px; dialogWidth: 7px;edge: Raised; center: Yes; help: no; resizable: no; status: no;");
					this.InsertarNodosHijos(dbgrid,idFila,idGrupoCta);
					this.EnumerarFilas();
					objImagen.src=pathImg + "minus.gif";
				}
				else
				{
					var arrPath = objImagen.src.split("/");
					var wOpen = ((arrPath[arrPath.length-1].toUpperCase()== ("Plus.gif").toUpperCase())?true:false);
					objImagen.src = pathImg + ((wOpen==true)?"minus.gif":"plus.gif");
					var Mostrar = ((wOpen==true)?"block":"none");
					
					this.MostrarOcultar(dbgrid,idFila,idGrupoCta,Mostrar);
				}
			}
			
			function MostrarOcultar(dbgrid,idFila,idGrupoCta,Mostrar)
			{
				for (var i=idFila+1;i<=dbgrid.rows.length-1;i++)
				{
					var strValorCta =dbgrid.rows[i].getAttribute("IDDIGCTA");
					if (strValorCta.substring(0,idGrupoCta.length) == idGrupoCta)
					{dbgrid.rows[i].style.display = Mostrar;}
					else
					{break;}
				}
			}
			
			function InsertarNodosHijos(dbgrid,idFila,idGrupoCta)
			{
					dbgrid.rows[idFila].removeAttribute("CARGADO");
					dbgrid.rows[idFila].setAttribute("CARGADO",1);
					var idFilaOrg =dbgrid.rows[idFila].getAttribute("IDFILAORG");
					var Clase = dbgrid.rows[idFila].className.toUpperCase();
					
					var idFilaRelativa=idFila;
					//Arreglos de Datos
					var Registro = strData.split('@');
					for(var i=0;i<=Registro.length-2;i++)
					{
						var Data = Registro[i].split('*');
						idFilaRelativa++;
						var oFila = dbgrid.insertRow(idFilaRelativa);
							if (Clase == "ITEMGRILLA"){oFila.className = "Alternateitemgrilla";}
							else{oFila.className = "Itemgrilla";}
							Clase = oFila.className.toUpperCase();
						
						oFila.setAttribute("IDDIGCTA",Data[0]);
						oFila.onmouseover = function(){CambiarColorPasarMouse(this, true);};
						oFila.onmouseout = function(){CambiarColorPasarMouse(this, false);};
						oFila.onclick=function(){CambiarColorSeleccion(this);};
						for(var c=0;c<=13;c++)
						{
							oCell0 = document.createElement("TD");
							if (c==0)
							{oCell0.appendChild(this.CrearNodoInterno(Data[1]));}
							else
							{
								oCell0.appendChild(CrearObjInput(idFilaRelativa,idFilaOrg,c,Data[c+1],Data[0]));
								oCell0.className ="normaldetalle";
							}
							oFila.appendChild(oCell0);
						}
						idFilaOrg ++;
					}
			}
			
			function CrearObjInput(idFilaRelativa,idFila,idCol,dbvalor,idgrpCta)
			{
				var grpCta = idgrpCta.substring(0,3);
				objInput = document.createElement("input");
				objInput.type="Text";
				objInput.maxlength="12";
				objInput.id= "p" + grpCta + "_" + Prefijo1 + idCol + Prefijo2 + idFila;
				objInput.onkeyup=function(){ValidaNro(this,idFila,idCol,grpCta);};
				//objInput.onkeyup=function(){validaInputFloat(this);};
				objInput.onblur=function(){IdentificarCeldaModificada(this,idFilaRelativa,grpCta,idCol);};
				objInput.onfocus=function(){Enfocado(this);};
				objInput.className ="normalCelda";
				objInput.width=50;
				objInput.value =FormatNumber(dbvalor, 2, true,true, true);
				//objInput.title=objInput.id;
				objInput.style.border ="1pt solid #CCCCCC";
				objInput.style.background ="Transparent";
				return objInput;
			}
			
/****************************************************************************************/
			function Enfocado(objInput)
			{
				MontoActual = parseFloat(ObtenerValorSinFormato(objInput.value));
				objInput.value = MontoActual;
				objInput.select();
			}
			function ObtenerValorSinFormato(strValor)
			{
				var mValor1 = Reemplazar(strValor," ","");
				var mValor2 = Reemplazar(mValor1," ","");
				return mValor2;
			}
			function IdentificarCeldaModificada(objInput,idFilaRelativa,grpCta,idCol,dbvalor)
			{
				var Monto = parseFloat(ObtenerValorSinFormato(objInput.value));
				if (MontoActual != parseFloat(Monto))
				{
					var dbgrid = document.all["grid"];
					dbgrid.rows[idFilaRelativa].cells(idCol).removeAttribute("MONTO");
					dbgrid.rows[idFilaRelativa].cells(idCol).setAttribute("MONTO",Monto);
					MontoActual=0;
					this.TotalizarColumna(grpCta,idCol);
				}
				objInput.value=FormatNumber(Monto, 2, true,true, true);
			}
			function ValidaNro(objInput,idFila,idCol,grpCta)
			{
				var Prefijo0 = "p" + grpCta + "_";
				var KeyTecla = event.keyCode;
				var Letra =String.fromCharCode(KeyTecla);
				var valor = objInput.value.toUpperCase();
				/*Variables para Controlar el desplazamiento*/
				var Nombreobj =objInput.id;
				var strNC = Nombreobj.replace(Prefijo0 + Prefijo1,"");
				var idFilaCol = strNC.replace("nMonto","");
				var arrIdx = idFilaCol.split('_');
				
				if (((event.keyCode >=48 && event.keyCode <=57)||(event.keyCode >=96 && event.keyCode <=105)|| event.keyCode==109)|| event.keyCode==110)
				{}
				else if (event.keyCode ==13 || event.keyCode ==40)//Flecha Abajo o Enter
				{
					var idSiguiente = (parseInt(arrIdx[1])+1);
					var NrombreObjSiguiente = Prefijo0 + Prefijo1 + arrIdx[0] + Prefijo2 + idSiguiente;
					var ObjSiguiente = document.all[NrombreObjSiguiente];
					if (ObjSiguiente !=undefined){ObjSiguiente.focus();}
				}
				else if (event.keyCode ==38)//Flecha Arriba
				{
					var idAnterior = (parseInt(arrIdx[1])-1);
					var NrombreObjAnterior = Prefijo0 + Prefijo1 + arrIdx[0] + Prefijo2 + idAnterior;
					var ObjAnterior = document.all[NrombreObjAnterior];
					if (ObjAnterior !=undefined){ObjAnterior.focus();}
				}
				else if (event.keyCode ==39)//Flecha Derecha
				{
					var idDerecha = (parseInt(arrIdx[0])+1);
					var NrombreObjDerecha = Prefijo0 + Prefijo1 + idDerecha + Prefijo2 + arrIdx[1];
					var ObjDerecha = document.all[NrombreObjDerecha];
					if (ObjDerecha !=undefined){ObjDerecha.focus();}
				}
				else if (event.keyCode ==37)//Flecha Izquierda
				{
					var idIzquierda = (parseInt(arrIdx[0])-1);
					var NrombreObjIzquierda = Prefijo0 + Prefijo1 + idIzquierda + Prefijo2 + arrIdx[1];
					var ObjIzquierda = document.all[NrombreObjIzquierda];
					if (ObjIzquierda !=undefined){ObjIzquierda.focus();}
				}
				else
				{
					objInput.value = Reemplazar(valor,Letra,"");
				}
			}
/****************************************************************************************/
			
			
			function TotalizarColumna(idGrupoCta,idCol)
			{
				var Prefijo0 = "p" + idGrupoCta + "_";
				var idFila = this.BuscarParametro(idGrupoCta,"IDFILA");
				var dbgrid = document.all["grid"];
				var TotalColumnaGrpCta =0;
				var idFilaOrg = parseInt(dbgrid.rows[idFila].getAttribute("IDFILAORG"));
				for(var i=(idFila+1);i<=dbgrid.rows.length-1;i++)
				{
					if (dbgrid.rows[i].getAttribute("IDDIGCTA").substring(0,3)== idGrupoCta)
					{
						NombreObjTxt = Prefijo0 + Prefijo1 + idCol + Prefijo2 + idFilaOrg;
						obj = document.all[NombreObjTxt];
						var Monto =ObtenerValorSinFormato(obj.value);
						TotalColumnaGrpCta	+= parseFloat(Monto);
						idFilaOrg ++;
					}
					else
					{
						break;
					}
				}
				var Monto = FormatNumber(TotalColumnaGrpCta, 2, true,true, true);
				dbgrid.rows[idFila].cells(idCol).innerText = Monto;
			}
			
			
			
			
			function BuscarParametro(idGrupoCta,TipoBusqueda)
			{
				var dbgrid = document.all["grid"];
				for(var i=1;i<=dbgrid.rows.length-1;i++)
				{
					if (dbgrid.rows[i].getAttribute("IDDIGCTA")== idGrupoCta)
					{
						if (TipoBusqueda=="QUERY")
						{
							var SIGNOIGUAL="="
							var SIGNOAMPERSON ="&"
							var KEYIDPRESUPUESTOCUENTA ="Cta"; 
							var KEYIDCENTROOPERATIVO ="centro"; 
							var KEYIDGRUPOCC ="idGrpCC";
							var KEYIDCENTROCOSTO ="idCC";
							var KEYIDPERIODO ="periodo";
							var strQuery = KEYIDPRESUPUESTOCUENTA + SIGNOIGUAL + dbgrid.rows[i].getAttribute("IDDIGCTA")
											+ SIGNOAMPERSON
											+ KEYIDCENTROOPERATIVO + SIGNOIGUAL + dbgrid.rows[i].getAttribute(KEYIDCENTROOPERATIVO)
											+ SIGNOAMPERSON
											+ KEYIDGRUPOCC + SIGNOIGUAL + dbgrid.rows[i].getAttribute(KEYIDGRUPOCC)
											+ SIGNOAMPERSON
											+ KEYIDCENTROCOSTO + SIGNOIGUAL + dbgrid.rows[i].getAttribute(KEYIDCENTROCOSTO)
											+ SIGNOAMPERSON
											+ KEYIDPERIODO + SIGNOIGUAL + dbgrid.rows[i].getAttribute(KEYIDPERIODO);
							return strQuery;
						}
						else if (TipoBusqueda=="IDFILA")
						{
							var KEYIDFILA="idFila";
							return dbgrid.rows[i].getAttribute(KEYIDFILA);
						}
					}
				}
				return "";
			}
			
			function EnumerarFilas()
			{
				var dbgrid = document.all["grid"];
				for (var i=0;i<=dbgrid.rows.length-1;i++){dbgrid.rows[i].removeAttribute("IDFILA");dbgrid.rows[i].setAttribute("IDFILA",i);}
			}


			function CrearNodoInterno(srtDescripcion)
			{
				
				var NroColumnasCrear= 3
      			var tbl = document.createElement("TABLE");
				tbl.id = "TableOne";
				tbl.border = 0;
				tbl.cellSpacing=0;
				tbl.cellPadding=0;
				tbl.align="Left";
				tbl.width="100%";
		        tblBody = document.createElement("TBODY");
			 	var oFila = document.createElement("TR");
				for(var i=0;i<=NroColumnasCrear;i++)
				{
					oCell = document.createElement("TD");
					oCell.id="TD" + i;
					oCell.align="Left";
					oCell.vAlign="top";
					if (parseInt(i)==parseInt(NroColumnasCrear))	
					{
						oCell.innerText=srtDescripcion;
						oCell.className ="ItemgrillaSinColor";
						oCell.width="100%";
						oCell.vAlign="Bottom";
						oCell.ondblclick=function(){MostrarPopupBusqueda();};
					}
					else
					{
						oCell.appendChild(this.CrearobjImagen("Blanco.gif"));
					}
					oFila.appendChild(oCell);
				}
				tblBody.appendChild(oFila);
				tbl.appendChild(tblBody);
				return tbl;
			}
			
			function CrearobjImagen(strImg)
			{
				var objImg = document.createElement("IMG");
				objImg.src = pathImg + strImg
				return objImg;
			}
			
			
			function GrabarColumnasModificadas()
			{
				var strData= "";
				var dbgrid = document.all["grid"];
				for(var i=1;i<=dbgrid.rows.length-2;i++)
				{
					if (dbgrid.rows[i].getAttribute("IDDIGCTA").length >3)
					{
						strData += dbgrid.rows[i].getAttribute("IDDIGCTA");
						for(var c=1;c<=12;c++)
						{
							if (dbgrid.rows[i].cells(c).getAttribute("MONTO") !=null)
							{
								strData +=  "*" + c + "_" + dbgrid.rows[i].cells(c).getAttribute("MONTO");
							}
						}
						strData += "@";
					}
				}
				MostrarDatosEnCajaTexto("hTrama",strData);
			}
			
			
			
			
			
			
		function validaFloat(value)
		{
			return(value.match(/^[0-9]+(,[0-9]+)*$/ ))
		}

	function validaInputFloat(oInput){
	if (! validaFloat(oInput.value) )	
	{
		alert(oInput.value + " no es un número válido!");
		try
		{
			ed.focus();
			ed.select();				
		}catch(ex){
		   /*me "como" la excepción porque se producirá 
		     en caso de que al control no se le pueda
		     pasar el foco
		   */
		}
		return(false);
	}
	return(true);
}


			
			
			
			
		</script>
		<!--
		
<script language="JavaScript">

var NS4 = (document.layers); 
var IE4 = (document.all);

var win = window;    // Con frames usar top.nombre.window;
var n   = 0;

function findInPage(str) {
	
  var txt, i, found;

  if (str == "")
    return false;

  // Find next occurance of the given string on the page, wrap around to the
  // start of the page if necessary.

  if (NS4) {

    // Look for match starting at the current point. If not found, rewind
    // back to the first match.

    if (!win.find(str))
      while(win.find(str, false, true))
        n++;
    else
      n++;

    // If not found in either direction, give message.

    if (n == 0)
      alert("Not found.");
  }

  if (IE4) {
    txt = win.document.body.createTextRange();

    // Find the nth match from the top of the page.

    for (i = 0; i <= n && (found = txt.findText(str)) != false; i++) {
      txt.moveStart("character", 1);
      txt.moveEnd("textedit");
    }

    // If found, mark it and scroll it into view.

    if (found) {
      txt.moveStart("character", -1);
      txt.findText(str);
      txt.select();
      txt.scrollIntoView();
      n++;
    }

    // Otherwise, start over at the top of the page and find first match.

    else {
      if (n > 0) {
        n = 0;
        findInPage(str);
      }

      // Not found anywhere, give message.

      else
        alert("Not found.");
    }
  }

  return false;
}




var objPopupBusqueda = window.createPopup();
function MostrarPopupBusqueda()
{
	
	var intPopupWidth = 300;
	var intPopupHeight = 104;
	var xleft=  (window.screen.width/2) - (intPopupWidth/2);
	var yTop=  (window.screen.height/2) - (intPopupHeight/2);
	objPopupBusqueda.document.body.innerHTML= TabladePresentacion();
	var oPopupBody = objPopupBusqueda.document.body;
	objPopupBusqueda.show(xleft, yTop, intPopupWidth, intPopupHeight);
}

function BuscarTextoenPaginaActual()
{
	if (event.keyCode==13)
	{
		var objtxt = document.all["txtBuscaAlgo"];
		window.alert("e");
		findInPage(objtxt.value);
	}
}
function TabladePresentacion()
{
	var strTabla="<table>";
		strTabla +="<tr>";
		strTabla +="<td><input id='txtBuscaAlgo' type='text' value='Nada' onkeydown='BuscarTextoenPaginaActual();'/>";
		strTabla +="<td>";
		strTabla +="<tr>";
		strTabla +="</table>";
		return strTabla;
}
</script>

	-->
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
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera>Presupuesto></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Presupuesto por Grupo de Centro de Costos</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="751" border="0">
							<TR>
								<TD style="WIDTH: 723px" align="left" width="723" colSpan="3"><asp:label id="lblTipoPresupuesto" runat="server" CssClass="TituloPrincipalBlanco" Width="343px"
										ForeColor="Navy" BackColor="Transparent">TIPO PRESUPUESTO</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 723px" align="left" width="723" colSpan="3"><asp:label id="lblGrupoCC" runat="server" CssClass="TituloPrincipalBlanco" Width="343px" ForeColor="Navy"
										BackColor="Transparent">GRUPO DE CENTRO DE COSTO</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 724px" align="center" width="724" colSpan="3">
									<TABLE id="Table13" cellSpacing="1" cellPadding="1" width="656" align="left" border="0"
										style="WIDTH: 656px; HEIGHT: 23px">
										<TR>
											<TD style="WIDTH: 2px"><asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" Width="80%" ForeColor="Navy"
													BackColor="Transparent" DESIGNTIMEDRAGDROP="77">PERIODO :</asp:label></TD>
											<TD style="WIDTH: 12px"><asp:label id="lblPeriodo" runat="server" CssClass="TituloPrincipalBlanco" Width="32px" ForeColor="Navy"
													BackColor="Transparent"> 2005</asp:label></TD>
											<TD style="WIDTH: 8px"></TD>
											<TD style="WIDTH: 41px"></TD>
											<TD style="WIDTH: 41px"><asp:label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" Width="119px" ForeColor="Navy"
													BackColor="Transparent">CENTRO DE COSTO :</asp:label></TD>
											<TD align="left" width="50%"><asp:dropdownlist id="ddldCentrodeCosto" runat="server" CssClass="combos" Width="355px" DESIGNTIMEDRAGDROP="40"
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
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NATURALEZA DE GASTO">
												<HeaderStyle HorizontalAlign="Center" Width="2%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="pEnero" HeaderText="ENE">
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="pFebrero" HeaderText="FEB">
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="pMarzo" HeaderText="MAR">
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="pAbril" HeaderText="ABR">
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="pMayo" HeaderText="MAY">
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="pJunio" HeaderText="JUN">
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="pJulio" HeaderText="JUL">
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="pAgosto" HeaderText="AGO">
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="pSetiembre" HeaderText="SET">
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="pOctubre" HeaderText="OCT">
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="pNoviembre" HeaderText="NOV">
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="pDiciembre" HeaderText="DIC">
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="pTotal" HeaderText="TOTAL">
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server"><INPUT id="hTrama" type="hidden" name="hTrama" runat="server"></TD>
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
