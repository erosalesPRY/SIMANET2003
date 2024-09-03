<%@ Register TagPrefix="cc2" Namespace="ControlesWeb" Assembly="ControlesWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarPresupuestoVarios.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios.ConsultarPresupuestoVarios" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<script>
			var UltimoNivel = 3;
			var pathImg = "/SimaNetWeb/imagenes/tree/";
			var strData;
			var Fila;//Fila que se desea expandir o mostrar u ocultar datos
			var objImgPlusMinus;
			var idSubNivel=0;
			
			//Relacionado y utilizado del lado del servidor
			function FilaSeleccionada(objthis)
			{Fila =objthis.getAttribute("IDFILA");}
			
			function OpenClose(objImg,objImgFolder)
			{
				var arrData = objImg.src.split("/");
				var wOpen = ((arrData[arrData.length-1].toUpperCase()== ("Plus.gif").toUpperCase())?true:false);
				objImg.src = pathImg + ((wOpen==true)?"Minus.gif":"plus.gif");
				objImgFolder.src = pathImg + ((wOpen==true)?"Open.gif":"Close.gif");
				var Mostrar = ((wOpen==true)?"block":"none");
				var dbgrid = document.all["grid"];
				if(parseInt(dbgrid.rows[Fila].getAttribute("CONSULTADO"))==0) //Presunta si este nodo ya fue consultado en la Base de datos
				{
					this.StyloFilaSeleccionada(dbgrid.rows[Fila],wOpen);
					PopupDeEspera();
					this.DialogodeProceso();
					if (strData.length>0)
					{this.InsertarFila(Fila);}
				}
				else
				{
					this.StyloFilaSeleccionada(dbgrid.rows[Fila],wOpen);
					//this.MostrarOcultarNodo(Mostrar);
					this.MostrarOcultar(Mostrar,wOpen);
				}
			}
			//valores de Parametros que determinar el Query string  de la Pagina a ser invocada
			var QIDCO;
			var QIDPERIODO;
			var QIDMES;
			var QIDDIGCTA;
			var QIDDIGGRPCTA;
			var QIDGRPCC;
			var QIDCC;
			var QIDNIVEL;
			var QIDGPRS;
			var QIDTIPOPRESUPUESTO;
			
			function ObtenerParametrosSQL()
			{
				var dbgrid = document.all["grid"];
				QIDCO = dbgrid.rows[Fila].getAttribute("CO");
				QIDPERIODO = dbgrid.rows[Fila].getAttribute("PERIODO");
				QIDMES = dbgrid.rows[Fila].getAttribute("MES");
				QIDDIGGRPCTA= dbgrid.rows[Fila].getAttribute("DIGGRPCTA");
				QIDDIGCTA = dbgrid.rows[Fila].getAttribute("DIGCTA");
				QIDGRPCC = dbgrid.rows[Fila].getAttribute("GRPCC");
				QIDNIVEL = dbgrid.rows[Fila].getAttribute("NIVEL");
				QIDGPRS = dbgrid.rows[Fila].getAttribute("GPERSONAL");
				QIDCC = dbgrid.rows[Fila].getAttribute("CC");
				QIDTIPOPRESUPUESTO = QueryStringObtenerValordeParametro('idTPPPto');//Funcion que se encuenta en l JS General
				
			}		
				
			function DialogodeProceso()
			{
				strData="";
				this.ObtenerParametrosSQL();
				var strQuery = "QIDCO="+ QIDCO 
								+"&QIDPERIODO=" + QIDPERIODO 
								+ "&QIDMES=" + QIDMES 
								+ "&QIDDIGGRPCTA=" + QIDDIGGRPCTA
								+ "&QIDDIGCTA=" + QIDDIGCTA 
								+ "&QIDGRPCC=" + QIDGRPCC
								+ "&QIDCC=" + QIDCC
								+ "&QIDNIVEL=" + QIDNIVEL
								+ "&QIDGPRS=" + QIDGPRS
								+ "&idTPPPto=" + QIDTIPOPRESUPUESTO;
								
				miVentana=window.showModalDialog("CargarNodosPresupuesto.aspx?" + strQuery,window,"dialogHeight: 1px; dialogWidth: 1px;edge: Raised; center: Yes; help: no; resizable: yes; status: no;");
			}

			//Permite Cambiar el Estylo de la Fila Seleccionada
			function StyloFilaSeleccionada(objFila,wOpen)
			{
				objFila.style.fontWeight=((wOpen==true)?"bold":"normal");
				objFila.style.fontSize= ((wOpen==true)?"11":"10");
				//objFila.style.backgroundImage = ((wOpen==true)?"url(" + pathImg + "ItemSeleccion.gif)":""); 
				//objFila.style.backgroundRepeat ="repeat-x";
				//objFila.style.color = ((wOpen==true)?"white":"#000080");
				
				var objColTexto = document.all["td" + objFila.getAttribute("IDNIVEL")];
				objColTexto.style.fontWeight=((wOpen==true)?"bold":"normal");
				objColTexto.style.fontSize= ((wOpen==true)?"11":"10");
				objColTexto.style.color = objFila.style.color;
			}
			
			function InsertarFila(idFila)
			{
				var idNewFila=parseInt(idFila);
				idSubNivel=0;
				var dbgrid = document.all["grid"];
				//PARA VERIFICAR SI EL NODO YA HA CARGADO DATOS
				dbgrid.rows[idFila].removeAttribute("CONSULTADO");
				dbgrid.rows[idFila].setAttribute("CONSULTADO",1);
				
				var idNivel = dbgrid.rows[idFila].getAttribute("IDNIVEL");
				var Nivel= dbgrid.rows[idFila].getAttribute("NIVEL");
				var arrData = strData.split("[@]");
				
				var Clase = dbgrid.rows[idFila].className.toUpperCase();
				
				for(var idReg =0;idReg<= arrData.length-1;idReg++)
				{
					var arrRegistro =arrData[idReg].split(";");
					idSubNivel ++;
					idNewFila ++;
					//var oFila = dbgrid.insertRow(parseInt(idFila)+1);
					var oFila = dbgrid.insertRow(idNewFila);
					oFila.setAttribute("CONSULTADO",0);
					oFila.setAttribute("IDNIVEL",idNivel + "." + idSubNivel);
					oFila.setAttribute("NIVEL",(parseInt(Nivel)+ 1));
					//Parametros de Consultas
					oFila.setAttribute("CO",QIDCO);
					oFila.setAttribute("PERIODO",QIDPERIODO);
					oFila.setAttribute("MES",QIDMES);
					oFila.setAttribute("DIGGRPCTA",arrRegistro[3])//Digito de la Cuenta
					oFila.setAttribute("DIGCTA",QIDDIGCTA);
					oFila.setAttribute("GRPCC",QIDGRPCC);
					oFila.setAttribute("CC",arrRegistro[1]);
					oFila.setAttribute("GPERSONAL",QIDGPRS);
					//oFila.onmouseover = function(){FilaSeleccionada(this);};
					oFila.onmouseover = function(){FilaSeleccionada(this);CambiarColorPasarMouse(this, true);};
					oFila.onmouseout = function(){CambiarColorPasarMouse(this, false);};
					oFila.onclick=function(){CambiarColorSeleccion(this);};

				
					//oFila.className = ((idReg % 2 == 0)? ((dbgrid.rows[Fila].className.toUpperCase()== ("Itemgrilla").toUpperCase())?"Alternateitemgrilla":"Itemgrilla"):"Alternateitemgrilla");
					
					if (Clase == "ITEMGRILLA"){oFila.className = "Alternateitemgrilla";}
					else{oFila.className = "Itemgrilla";}
					Clase = oFila.className.toUpperCase();

					
					this.CrearColumnas(oFila,(parseInt(Nivel)+ 1),(idNivel + "." + idSubNivel),arrRegistro);
				}
				this.EnumerarFilas();
			}
			function CrearColumnas(objFila,intNivel,stridNivel,arrRegistro)
			{
					oCell0 = document.createElement("TD");
					
					//oCell0.appendChild(this.CrearNodoInterno(intNivel,stridNivel,arrRegistro[2]));
					oCell0.appendChild(this.CrearNodoInterno(intNivel,stridNivel,arrRegistro));
					objFila.appendChild(oCell0);
					oCell1 = document.createElement("TD");
					oCell1.innerText=arrRegistro[4];//oFila.getAttribute("IDNIVEL");
					oCell1.align="Right";
					oCell1.vAlign="middle";
					objFila.appendChild(oCell1);
					oCell2 = document.createElement("TD");
					oCell2.innerText=arrRegistro[5];
					oCell2.align="Right";
					oCell2.vAlign="middle";
					objFila.appendChild(oCell2);
					oCell3 = document.createElement("TD");
					oCell3.innerText=arrRegistro[6];
					oCell3.align="Right";
					oCell3.vAlign="middle";
					objFila.appendChild(oCell3);
			}
			
			function EnumerarFilas()
			{
				var dbgrid = document.all["grid"];
				for (var i=0;i<=dbgrid.rows.length-1;i++){dbgrid.rows[i].removeAttribute("IDFILA");dbgrid.rows[i].setAttribute("IDFILA",i);}
			}
			function CrearNodoInterno(NivelTab,idNivel,arrRegistro)
			{
				
				var Nrocol =2;
				var NroColumnasCrear= parseInt(Nrocol) + parseInt(NivelTab);
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
					switch (parseInt(i))	
					{
						case parseInt(NroColumnasCrear):
							oCell.id = "td" + idNivel;
							oCell.innerText=arrRegistro[2];
							oCell.className ="ItemgrillaSinColor";
							oCell.width="100%";
							oCell.vAlign="Bottom";
							
							if (parseInt(NivelTab) == parseInt(UltimoNivel) && parseInt(arrRegistro[5]) !=0 && (QIDDIGGRPCTA=='1' || QIDDIGGRPCTA=='3'))//Asigna evento solo aquellos que cumplan con la condicion
							{
								oCell.onclick= function(){PopupDeEspera();MostrarDetalledeMovimientos(arrRegistro[3],QIDDIGGRPCTA,arrRegistro[2],arrRegistro[5]);}
								oCell.style.color="#0000ff";
								oCell.style.textDecoration="underline";
								oCell.style.cursor='hand';
							}
							break;
						case (parseInt(NroColumnasCrear) - 1):
							var strNombImg =  ((parseInt(NivelTab) == parseInt(UltimoNivel))?"search.gif":"Close.gif");
							oCell.appendChild(CrearobjImagen(strNombImg,2,idNivel,NivelTab));
							oCell.style.display="none";
							break;
						case (parseInt(NroColumnasCrear) - 2):
							var strNombImg =  ((parseInt(NivelTab) == parseInt(UltimoNivel))? "Blanco.gif":"Plus.gif");
							oCell.appendChild(CrearobjImagen(strNombImg,1,idNivel,NivelTab));
							break;
						default:
							oCell.appendChild(CrearobjImagen("Blanco.gif",0,idNivel,NivelTab));
							break;
					}
					oFila.appendChild(oCell);
				}
				tblBody.appendChild(oFila);
				tbl.appendChild(tblBody);
				return tbl;
			}
			
			function CrearobjImagen(strImg,intEvento,idNivel,NivelTab)
			{
				var objImg = document.createElement("IMG");
				objImg.src = pathImg + strImg
				if (parseInt(intEvento) ==1)
				{
					objImg.id = "imgPlusMinus_" + idNivel;
					if (parseInt(NivelTab) != parseInt(UltimoNivel))
					{objImg.onclick= function(){OpenCloseB(this);}}
				}
				else if(parseInt(intEvento) ==2)
				{
					objImg.id = "imgOpenClose_" + idNivel;
				}
				return objImg;
			}
			function OpenCloseB(objimg)
			{
				var arrImg = objimg.id.split("_");
				var objImgOC = document.all["imgOpenClose_" + arrImg[1]];
				this.OpenClose(objimg,objImgOC);
			}
			
			//Funciones para Mostrar Detalle de Ultimo Nivel
			function MostrarDetalledeMovimientos(strCuenta,idGrupoCuenta,DescripcionNaturaleza,Monto)
			{
				switch (parseInt(idGrupoCuenta))
				{
					case 1://Movimiento de Materiales
						this.MostrarMovimientoporCuenta5Dig(strCuenta,DescripcionNaturaleza,Monto);
						break;
					case 3://Sumnistros Diversos
						this.MostrarMovimientoporCuenta5Dig(strCuenta,DescripcionNaturaleza,Monto);
						break;
					default:
						break;
				}
			}
			function MostrarMovimientoporCuenta5Dig(strCuenta,DescripcionNaturaleza,Monto)
			{
				var dbgrid = document.all["grid"];
				var strQuery = "QIDPERIODO=" + dbgrid.rows[Fila].getAttribute("PERIODO");
					strQuery += "&QIDMES=" + dbgrid.rows[Fila].getAttribute("MES");
					strQuery += "&QIDCUENTA=" + strCuenta;
					strQuery += "&QIDGRPCC=" + dbgrid.rows[Fila].getAttribute("GRPCC");
					strQuery += "&QIDCC=" + dbgrid.rows[Fila].getAttribute("CC");
					strQuery += "&QIDDESCNAT=" + DescripcionNaturaleza;
					strQuery += "&QIDMONTO=" + Monto;
					
				window.showModalDialog("ConsultarMovimientodeMateriales.aspx?" + strQuery,"MiVentana","dialogHeight: 385px; dialogWidth: 775px;edge: Raised; center: Yes; help: no; resizable: no; status: no;");
			}
			
			
			
			function MostrarOcultar(Mostrar,wOpen)
			{
				var dbgrid = document.all["grid"];
				var NivelAct = (parseInt(dbgrid.rows[Fila].getAttribute("NIVEL"))+1);
				var idNivel = dbgrid.rows[Fila].getAttribute("IDNIVEL");
				
				for(var i=(parseInt(Fila)+1);i<= dbgrid.rows.length-1;i++)
				{
					var idNiv = dbgrid.rows[i].getAttribute("IDNIVEL");
					if (wOpen==true)
					{
						if (parseInt(dbgrid.rows[i].getAttribute("NIVEL"))==parseInt(NivelAct) && idNiv.substring(0,idNivel.length) == idNivel)
						{dbgrid.rows[i].style.display="block";}
					}
					else
					{
						if (idNiv.substring(0,idNivel.length) == idNivel)
						{
							dbgrid.rows[i].style.display="none";
							if (parseInt(UltimoNivel) > parseInt(dbgrid.rows[i].getAttribute("NIVEL")))
							{
								var objImg = document.all["imgPlusMinus_" + idNiv];
								objImg.src = pathImg + "plus.gif";
								var objImgFolder = document.all["imgOpenClose_" + idNiv];
								objImgFolder.src = pathImg + "Close.gif";
								this.StyloFilaSeleccionada(dbgrid.rows[i],false);
							}
						}
					}
				}
			}
			
			
			

			
			
			//oncontextmenu="return false"
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Presupuestos</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="740" border="0" height="100%">
							<TR bgColor="#f0f0f0">
								<TD style="WIDTH: 132px">
									<asp:label id="Label1" runat="server" CssClass="TextoBlanco" ForeColor="Navy" Font-Bold="True"
										Width="144px">CENTRO DE OPERACIONES :</asp:label></TD>
								<TD>
									<asp:label id="lblNombreCentro" runat="server" CssClass="TextoBlanco" ForeColor="Navy" Font-Bold="True"
										Width="536px"></asp:label></TD>
							</TR>
							<TR bgColor="#f0f0f0">
								<TD style="WIDTH: 132px">
									<asp:label id="Label2" runat="server" CssClass="TextoBlanco" ForeColor="Navy" Font-Bold="True"
										Width="144px">PRESUPUESTO :</asp:label></TD>
								<TD>
									<asp:label id="lblNombreTipoPresupuesto" runat="server" CssClass="TextoBlanco" ForeColor="Navy"
										Font-Bold="True" Width="552px"></asp:label></TD>
							</TR>
							<TR bgColor="#f0f0f0">
								<TD style="WIDTH: 132px" colSpan="2">
									<TABLE id="Table13" style="WIDTH: 200px; HEIGHT: 16px" cellSpacing="1" cellPadding="1"
										width="200" align="left" border="0">
										<TR>
											<TD style="WIDTH: 46px">
												<asp:label id="Label5" runat="server" CssClass="TextoBlanco" ForeColor="Navy" Font-Bold="True"
													Width="80%">Periodo :</asp:label></TD>
											<TD style="WIDTH: 33px">
												<asp:label id="lblPeriodo" runat="server" CssClass="TextoBlanco" ForeColor="Navy" Font-Bold="True"
													Width="80%">[periodo]</asp:label></TD>
											<TD style="WIDTH: 42px">
												<asp:label id="Label4" runat="server" CssClass="TextoBlanco" ForeColor="Navy" Font-Bold="True">Mes :</asp:label></TD>
											<TD style="WIDTH: 78px">
												<asp:label id="lblMes" runat="server" CssClass="TextoBlanco" ForeColor="Navy" Font-Bold="True"
													Width="72px">[mes]</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 295px" vAlign="top" align="center" width="100%">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="300" border="0">
							<TR>
								<TD>
									<cc1:datagridweb id="grid" runat="server" Width="740px" PageSize="7" AllowSorting="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0" ShowFooter="True">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Nombre" HeaderText="GRUPOS &lt;br&gt;CENTROS DE COSTOS &lt;br&gt;Y &lt;br&gt; NATURALEZA DE GASTO">
												<HeaderStyle Width="40%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="TotalPPtoCta" HeaderText="PRESUPUESTO">
												<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="TotalEjecutado" HeaderText="EJECUTADO">
												<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Saldo" HeaderText="SALDO">
												<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="left"><IMG style="WIDTH: 160px; HEIGHT: 16px" height="16" src="../../imagenes/spacer.gif" width="160"></TD>
							</TR>
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<tr>
					<td>
						<div id="divBase" style="VISIBILITY: hidden">
						</div>
					</td>
				</tr>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			/*document.body.onkeydown=OcultarporEventoKeyDown;
			document.body.onclick=sClick;
			*/
		</SCRIPT>
		<DIV></DIV>
	</body>
</HTML>
