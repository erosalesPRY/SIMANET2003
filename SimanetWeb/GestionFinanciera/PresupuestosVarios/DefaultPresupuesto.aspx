<%@ Page language="c#" Codebehind="DefaultPresupuesto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios.DefaultPresupuesto" %>
<%@ Register TagPrefix="cc2" Namespace="ControlesWeb" Assembly="ControlesWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
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
			var pathImg = ObtenerPathAppWeb()+ "/imagenes/tree/";
			var idFilaActual=0;
			var strData;
			var URLSUBNODOS = "CargarNodoTipoPresupuesto.aspx?";
			
			var SignoIgual = "=";
			var SignoAmperson = "&";
			var KEYQIDCENTRO="Centro";
			var KEYQIDFECHA="Fecha";
			var KEYQIDTIPOPRESUPUESTO="idTPPPto";
			var KEYQIDNIVEL="VerNivel";
			var KEYQIDDIGCTA="DigCta";
			var KEYQIDNOMBRECENTRO="NombreCentro";
			var KEYQIDNOMBREPRESUPUESTO="NombreTipoPrespuesto";
			var KEYQIDNOMBREANEXO="NombreAnexo";
			var KEYQVENTAS ="Ventas";
			
			
			//var dbgrid = document.all["grid"];
			
			function CargarSubNodos(Nombredbgrid,objImagen,idNivel)
			{
				idFilaActual = ObtenerPosicionFila(Nombredbgrid,idNivel);
				
				var dbgrid = document.all[Nombredbgrid];
				if (dbgrid.rows[idFilaActual].getAttribute("CONSULTADO")=="0")
				{
					//Llama Al Popup de espera
					PopupDeEspera();
					var strCadena = KEYQIDCENTRO + SignoIgual + dbgrid.rows[idFilaActual].getAttribute("CENTRO");
						strCadena += SignoAmperson;
						strCadena += KEYQIDFECHA + SignoIgual + dbgrid.rows[idFilaActual].getAttribute("FECHA");
						strCadena += SignoAmperson;
						strCadena += KEYQIDTIPOPRESUPUESTO + SignoIgual + dbgrid.rows[idFilaActual].getAttribute("IDTIPOPPTO");
						strCadena += SignoAmperson;
						strCadena += KEYQIDNIVEL + SignoIgual + (parseInt(dbgrid.rows[idFilaActual].getAttribute("NIVEL"))+1);
					miVentana=window.showModalDialog(URLSUBNODOS + strCadena,window,"dialogHeight: 5px; dialogWidth: 7px;edge: Raised; center: Yes; help: no; resizable: no; status: no;");
				
					this.InsertarFila(dbgrid);
					
					dbgrid.rows[idFilaActual].setAttribute("CONSULTADO","1");
					objImagen.src=pathImg + "minus.gif";
				}
				else
				{
					var arrPath = objImagen.src.split("/");
					var wOpen = ((arrPath[arrPath.length-1].toUpperCase()== ("Plus.gif").toUpperCase())?true:false);
					objImagen.src = pathImg + ((wOpen==true)?"minus.gif":"plus.gif");
					var Mostrar = ((wOpen==true)?"block":"none");
					
					this.MostrarOcultar(dbgrid,Mostrar);
				}
			}
			
			function MostrarOcultar(dbgrid,Mostrar)
			{
				for (var i=idFilaActual+1;i<=dbgrid.rows.length-2;i++)
				{
					var strValorCta =dbgrid.rows[i].getAttribute("IDNIVEL");
					var idNivel = dbgrid.rows[idFilaActual].getAttribute("IDNIVEL");
					if (strValorCta.substring(0,idNivel.length) == idNivel)
					{dbgrid.rows[i].style.display = Mostrar;}
					else
					{break;}
				}
			}
			function ObtenerPosicionFila()
			{
				var ValordeBusqueda =arguments[1];//Buscar por IdNivel
				var dbgrid = document.all[arguments[0]];
				for(var i=1;i<=dbgrid.rows.length-1;i++)
				{
					if (dbgrid.rows[i].getAttribute("idNivel")== ValordeBusqueda)//El valor a Buscar
					{return i;}
				}
				return "";
			}
			
		
			

			function InsertarFila(dbgrid)
			{
				var idNewFila=parseInt(idFilaActual);
				var arrData = strData.split("[@]");
				
				var Clase = dbgrid.rows[idFilaActual].className.toUpperCase();
				for(var idReg =0;idReg<= arrData.length-1;idReg++)
				{
					var arrRegistro =arrData[idReg].split("[;]");
					idNewFila ++;
					var oFila = dbgrid.insertRow(idNewFila);
					oFila.id = dbgrid.rows[idFilaActual].getAttribute("IDNIVEL") + "." + idNewFila;
					oFila.setAttribute("CONSULTADO",0);
					oFila.setAttribute("CENTRO",arrRegistro[0]);//Centro de Operaciones
					oFila.setAttribute("FECHA",dbgrid.rows[idFilaActual].getAttribute("FECHA"));//Fecha de Consulta
					oFila.setAttribute("IDNIVEL",dbgrid.rows[idFilaActual].getAttribute("IDNIVEL") + "." + idNewFila);//Nivel del Registro
					oFila.setAttribute("NIVEL",parseInt(dbgrid.rows[idFilaActual].getAttribute("NIVEL")) + 1);//
					oFila.setAttribute("IDTIPOPPTO",arrRegistro[2]);//Tipo de Presupuesto
					oFila.setAttribute("ULTIMONIVEL",parseInt(arrRegistro[3]));//Indicativo el cual determina si el regsitro es de ultimo nivel
					oFila.setAttribute("DIGCTA",arrRegistro[4]);//Indicativo el cual determina si el regsitro es de ultimo nivel
					oFila.setAttribute("IDPRESUPUESTO",arrRegistro[11]);//Indicativo el cual determina si el regsitro es de ultimo nivel
					//Atributos de Titulos
					oFila.setAttribute("NOMBREPRESUPUESTO",dbgrid.rows[idFilaActual].getAttribute("NOMBREPRESUPUESTO"));
					if (parseInt(dbgrid.rows[idFilaActual].getAttribute("NIVEL"))==1)
					{
						oFila.setAttribute("NOMBREANEXO",arrRegistro[1]);
						oFila.setAttribute("NOMBRECENTRO",dbgrid.rows[idFilaActual].getAttribute("NOMBRECENTRO"));
					}
					else
					{
						oFila.setAttribute("NOMBREANEXO","");
						oFila.setAttribute("NOMBRECENTRO",arrRegistro[1]);
					}
					
					
					
					//Atributos  a las Filas
					oFila.onmouseover = function(){CambiarColorPasarMouse(this, true);};
					oFila.onmouseout = function(){CambiarColorPasarMouse(this, false);};
					oFila.onclick=function(){CambiarColorSeleccion(this);};

					if (Clase == "ITEMGRILLA"){oFila.className = "Alternateitemgrilla";}
					else{oFila.className = "Itemgrilla";}
					Clase = oFila.className.toUpperCase();
					
					for(var c=0;c<=6;c++)
					{
						oCell0 = document.createElement("TD");
						if (c==0)
						{
							oCell0.appendChild(this.CrearNodoInterno(dbgrid.id,arrRegistro[1],(parseInt(dbgrid.rows[idFilaActual].getAttribute("NIVEL"))+1) ,oFila.getAttribute("ULTIMONIVEL"),oFila.getAttribute("IDNIVEL")));
						}
						else
						{
						//oCell0.className = "normalCelda";
							oCell0.align="Right";
							oCell0.vAlign="middle";
							oCell0.innerText = arrRegistro[4+c];
						}
						oFila.appendChild(oCell0);
					}
				}
			}
			
			function CrearNodoInterno(Nombredbgrid,srtDescripcion,NewNivel,UltimoNivel,IdNivelFilaNueva)
			{
      			var tbl = document.createElement("TABLE");
				tbl.id = "TableOne";
				tbl.border = 0;
				tbl.cellSpacing=0;
				tbl.cellPadding=0;
				tbl.align="Left";
				tbl.width="100%";
		        tblBody = document.createElement("TBODY");
			 	var oFila = document.createElement("TR");
			 	
			 	var NroColumnasCrear = (NewNivel+2);
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
						if (parseInt(UltimoNivel)==1)
						{
							oCell.onclick= function(){PopupDeEspera();HistorialIrAdelantePersonalizado('ddlbPeriodo','dddblMes');UrlPaginaPorGrupoyCentrodeCosto(Nombredbgrid,IdNivelFilaNueva);}
							oCell.style.color="#0000ff";
							oCell.style.textDecoration="underline";
							oCell.style.cursor='hand';
						}
					}
					else if(parseInt(i)== parseInt(NewNivel) && parseInt(UltimoNivel) !=1)
					{
						var imgPlusClose =this.CrearobjImagen("plus.gif"); 
						imgPlusClose.onclick= function(){CargarSubNodos(Nombredbgrid,this,IdNivelFilaNueva);};
						oCell.appendChild(imgPlusClose);
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

			function UrlPaginaPorGrupoyCentrodeCosto(Nombredbgrid,IdNivelFilaNueva)
			{
				PopupDeEspera();
				var URLPRESUPUESTOGRPCC = "ConsultarPresupuestoVarios.aspx?";
				var URLPRESUPUESTOBCO = "ConsultarPresupuestodeFinanciamiento.aspx?";
				var URLPRESUPUESTOVENTASLIQUIDADAS = "ConsultarPresupuestodeVentasLiquidadas.aspx?";
				var URLPRESUPUESTOINGRESOSVARIOS = "ConsultarPresupuestodeIngresosVarios.aspx?";
				
				
				idFilaActual = ObtenerPosicionFila(Nombredbgrid,IdNivelFilaNueva);
				var dbgrid = document.all[Nombredbgrid];
				
				
				var idTP =  parseInt(dbgrid.rows[idFilaActual].getAttribute("IDPRESUPUESTO"));
				
				var strCadena = KEYQIDCENTRO + SignoIgual + dbgrid.rows[idFilaActual].getAttribute("CENTRO");
					strCadena += SignoAmperson;
					strCadena += KEYQIDFECHA + SignoIgual + dbgrid.rows[idFilaActual].getAttribute("FECHA");
					strCadena += SignoAmperson;
					strCadena += KEYQIDTIPOPRESUPUESTO + SignoIgual + dbgrid.rows[idFilaActual].getAttribute("IDTIPOPPTO");
					strCadena += SignoAmperson;
					strCadena += KEYQIDDIGCTA + SignoIgual + dbgrid.rows[idFilaActual].getAttribute("DIGCTA");
					strCadena += SignoAmperson;
					strCadena += KEYQIDNOMBRECENTRO + SignoIgual + dbgrid.rows[idFilaActual].getAttribute("NOMBRECENTRO");
					strCadena += SignoAmperson;
					strCadena += KEYQIDNOMBREPRESUPUESTO + SignoIgual + dbgrid.rows[idFilaActual].getAttribute("NOMBREPRESUPUESTO");
					strCadena += SignoAmperson;
					strCadena += KEYQIDNOMBREANEXO + SignoIgual + dbgrid.rows[idFilaActual].getAttribute("NOMBREANEXO");
					//strCadena += SignoAmperson;
					//strCadena += KEYQVENTAS + SignoIgual + 1;
				
				
				switch(idTP)
				{
					case 5:
						window.location.href = URLPRESUPUESTOBCO + strCadena;
						break;
					case 100://Detalle de Ventas Liquidadas
						window.location.href = URLPRESUPUESTOVENTASLIQUIDADAS + strCadena;	
						break;
					case 101://Detalle Presupuesto de ingresos varios
						window.location.href = URLPRESUPUESTOINGRESOSVARIOS + strCadena;	
						break;
					case 102://Detalle Presupuesto de Ventas 
						
						window.location.href = URLPRESUPUESTOVENTASLIQUIDADAS + strCadena + SignoAmperson + KEYQVENTAS + SignoIgual + 1;
						//window.alert("En Construcción");
						break;
					
					default:
						window.location.href = URLPRESUPUESTOGRPCC + strCadena;
						break;
				}
				
			}
			//oncontextmenu="return false"
		</script>
	</HEAD>
	<body onkeydown="if(event.keyCode ==116){return false;}" bottomMargin="0" leftMargin="0"
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
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Presupuestos</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"><IMG style="WIDTH: 160px; HEIGHT: 8px" height="8" src="../../imagenes/spacer.gif" width="160"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="300" border="0">
							<TR>
								<TD>
									<TABLE style="HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="740" border="0">
										<TR bgColor="#f0f0f0">
											<TD>
												<TABLE id="Table13" style="WIDTH: 256px; HEIGHT: 27px" cellSpacing="1" cellPadding="1"
													width="256" align="left" border="0">
													<TR>
														<TD style="WIDTH: 46px"><asp:label id="Label5" runat="server" CssClass="TextoAzul" Width="80%">Periodo :</asp:label></TD>
														<TD style="WIDTH: 66px"><asp:dropdownlist id="ddlbPeriodo" runat="server" CssClass="combos"></asp:dropdownlist></TD>
														<TD style="WIDTH: 42px"><asp:label id="Label4" runat="server" CssClass="TextoAzul">Mes :</asp:label></TD>
														<TD style="WIDTH: 78px"><asp:dropdownlist id="dddblMes" runat="server" CssClass="combos" AutoPostBack="True">
																<asp:ListItem Value="1">Enero</asp:ListItem>
																<asp:ListItem Value="2">Febrero</asp:ListItem>
																<asp:ListItem Value="3">Marzo</asp:ListItem>
																<asp:ListItem Value="4">Abril</asp:ListItem>
																<asp:ListItem Value="5">Mayo</asp:ListItem>
																<asp:ListItem Value="6">Junio</asp:ListItem>
																<asp:ListItem Value="7">Julio</asp:ListItem>
																<asp:ListItem Value="8">Agosto</asp:ListItem>
																<asp:ListItem Value="9">Setiembre</asp:ListItem>
																<asp:ListItem Value="10">Octubre</asp:ListItem>
																<asp:ListItem Value="11">Noviembre</asp:ListItem>
																<asp:ListItem Value="12">Diciembre</asp:ListItem>
															</asp:dropdownlist></TD>
														<TD style="WIDTH: 42px"></TD>
														<TD></TD>
													</TR>
												</TABLE>
											</TD>
											<TD style="WIDTH: 88px"></TD>
											<TD></TD>
											<TD><IMG style="WIDTH: 120px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="120"></TD>
											<TD style="WIDTH: 297px"></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<asp:label id="Label2" runat="server" CssClass="TextoAzul" Width="80%" Visible="False">INGRESOS</asp:label></TD>
							</TR>
							<TR>
								<TD align="left">
									<cc1:datagridweb id="grid" runat="server" Width="740px" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
										AllowSorting="True" PageSize="7">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="NOMBRE" HeaderText="PRESUPUESTO">
												<HeaderStyle Width="30%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PeruTotalPPtoCta" HeaderText="PRESUPUESTO">
												<HeaderStyle Width="11%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PeruTotalEjecutado" HeaderText="GASTO">
												<HeaderStyle Width="11%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PeruSaldo" HeaderText="SALDO">
												<HeaderStyle Width="11%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IquitosTotalPPtoCta" HeaderText="PRESUPUESTO">
												<HeaderStyle Width="11%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IquitosTotalEjecutado" HeaderText="GASTO">
												<HeaderStyle Width="11%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IquitosSaldo" HeaderText="SALDO">
												<HeaderStyle Width="11%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="left"><IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" align="center" width="100%">
						<DIV id="divBase">
							<DIV id="divBase">
								<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="743" border="0">
									<TR>
										<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="ReemplazaHistorial();HistorialIrAtras();"
												alt="" src="../../imagenes/atras.gif">&nbsp;
										</TD>
									</TR>
								</TABLE>
							</DIV>
						</DIV>
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="592">
						<DIV id="divBase" style="VISIBILITY: hidden">&nbsp;</DIV>
					</TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			/*document.body.onkeydown=OcultarporEventoKeyDown;
			document.body.onclick=sClick;
			*/
		</SCRIPT>
		<DIV>&nbsp;</DIV>
	</body>
</HTML>
