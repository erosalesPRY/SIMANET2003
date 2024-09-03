<%@ Page language="c#" Codebehind="AdministrarInversionesPorCentrodeCosto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.Inversiones.AdministrarInversionesPorCentrodeCosto" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/@Import.js"></SCRIPT>
		<script>
		function ActualizarDatosOrigenRemoto(idFila,idCell,Monto) {
			var NombreObj = "grid__ctl"+ idFila +"_txtCol"+ idCell;
			$O(NombreObj).value = Monto;
			ProcesarCalculodeFormato(idCell);
		}
			function txtCol_onKeyDown(){
				ObjetoProximo(window.event.keyCode,window.event.srcElement.id);
			}
			
			function ObjetoProximo(_keyCode,objActual){
				var NombreObjProx="grid__";				
				var CarFila = "ctl";
				var CarCol = "txtCol"
				//la Posicion 2 y 3 Obtienen los datos necesarios para saltar de un obj a otro
				var arrDato = objActual.split('_');
				var Nro=0;
				var NroProx;
				try{
					switch(_keyCode){
						case 37://Izquierda
							NroProx = arrDato[3].toString().replace(CarCol,'');
							Nro = eval(parseInt(NroProx,10) -1);
							NombreObjProx = NombreObjProx + arrDato[2].toString() + "_" + CarCol + Nro;
							break;
						case 38://Arriba
							NroProx = arrDato[2].toString().replace(CarFila,'');
							Nro = eval(parseInt(NroProx,10) -1);
							NombreObjProx = NombreObjProx + CarFila + Nro + "_" +  arrDato[3].toString();
							break;
						case 39://Derecha
							NroProx = arrDato[3].toString().replace(CarCol,'');
							Nro = eval(parseInt(NroProx,10) +1);
							NombreObjProx = NombreObjProx + arrDato[2].toString() + "_" + CarCol + Nro;					
							break;
						case 40://Abajo
							NroProx = arrDato[2].toString().replace(CarFila,'');
							Nro = eval(parseInt(NroProx,10) +1);
							NombreObjProx = NombreObjProx + CarFila + Nro + "_" +  arrDato[3].toString();					
							break;
						case 13://Enter
							ObjetoProximo(39,objActual);
							break;
					}
					$O(NombreObjProx).focus();
				}
				catch(error){}
			}
			/*-----------------------------------------------------------------------------------------------------*/
			/*-----------------------------------------------------------------------------------------------------*/
			var EstadodeValorActual = false;
			function AsignarEventodeSalidayCambio()
			{
				var objgrid = $O("grid");
				for(var i=1;i<= objgrid.rows.length-1;i++)
				{
					for(var c=1;c<=12;c++){
						var objTxt = objgrid.rows[i].cells[c].children[0];
						objTxt.onblur = NewonBlur;
						objTxt.onchange = CuandoCambiaValor;
						objTxt.Tag  = c;
					}
				}
			}
			//Asigna al Objeto Numerico el Evento de cambio OnChange para detectar algun cambio en los montos
			function CuandoCambiaValor()
			{EstadodeValorActual = true;}
			
			//Evento que se desencadena al Momento de perder el foco el Obj Numerico
			function NewonBlur()
			{
				NumericBox_IE_ParseAdd(this, ' ', ',', '.');
				if (EstadodeValorActual == true)//Si se ha cambiado algun valor para que vuelva a recalcular
				{ 
					ProcesarCalculodeFormato(this.Tag);
					EstadodeValorActual = false;
				}
			}
			
			function TotalizarRubro(strFormula,Columna){
				var pos=0;
				var Signo ="";
				var Total=0;
				var totalTmp=0;
				while (strFormula.length >0){
					if (!isDigit(strFormula.charAt(pos))){
							var DataCol="";
							var stridRubro = "";
							if (strFormula.charAt(pos)=="@"){
								stridRubro = strFormula.substring(0,pos);
								DataCol= ObtenerMontodeRubro(stridRubro,Columna);
								totalTmp =Total;
								Total = Calcular(totalTmp,DataCol,Signo);
								break;							
							}
							else{
								stridRubro = strFormula.substring(0,pos);
								DataCol = ObtenerMontodeRubro(stridRubro,Columna);
								totalTmp =Total;
								Total = Calcular(totalTmp,DataCol,Signo);
								
								strFormula = strFormula.substring(pos,strFormula.length);
								Signo = strFormula.substring(0,1);
								strFormula = strFormula.substring(1,strFormula.length);
								pos=-1;	
							}
						}
						pos++;
				}
				
				return Total;
			}

			function ObtenerMontodeRubro(strIdRubro,Columna){
				var objgrid =  $O("grid");
				for(var i=1;i<= objgrid.rows.length-1;i++){
					if(parseInt(objgrid.rows[i].getAttribute("IDRUBRO"))== parseInt(strIdRubro)){
						var otxtValor = objgrid.rows[i].cells[Columna].children[0];
						var strValor = SIMA.Utilitario.Helper.General.Reemplazar(otxtValor.value,',','');
						//strValor = SIMA.Utilitario.Helper.General.Reemplazar(strValor,'.',''); 
						return parseFloat(strValor);
					}
				}
				return 0; 
			}
			
			function Calcular(Total,DataCol,Signo){
				var oTotal=0;
				if (Signo=="+"){
					oTotal = parseFloat(Total) + parseFloat(DataCol);
				}
				else if(Signo=="-"){
					oTotal = parseFloat(Total) - parseFloat(DataCol);
				}
				else{
					oTotal = parseFloat(DataCol);
				}
				return oTotal;
			}
			
			function CalculoPorPrioridad(Prioridad,Columna){
				var objgrid = $O("grid");
				var arrRowFormula = objgrid.getAttribute("FILAFORMULA").split(";");
				arrRowFormula.pop();
				
				for(var i=0;i<= arrRowFormula.length-1;i++){
					var idFila = arrRowFormula[i];
					if(parseInt(objgrid.rows[idFila].getAttribute("PRIORIDAD"))== parseInt(Prioridad)){
						var strFormula=objgrid.rows[idFila].getAttribute("FORMULA");
						var TotalData = TotalizarRubro(strFormula,Columna);
						
						var objtxt = objgrid.rows[idFila].cells[Columna].children[0];
						if (objtxt != undefined){
							objtxt.value = TotalData;
						}
					}
				}
			}	
			
			function ProcesarCalculodeFormato(Columna){
				for(var p=0;p<=8;p++){CalculoPorPrioridad(p,Columna);}
				for(var p=0;p<=8;p++){CalculoPorPrioridad(p,Columna);}
			}
			

			var KEYQIDCENTROOPERATIVO="idcop";//CentroOPerativo de la pagina de Procesos
			var KEYQIDGRUPOCC = "idGrpCC";
			var KEYQIDCENTROCOSTO ="idCC";
			var KEYQPERIODO="Periodo";
			var KEYQIDTIPOINFORMACION="idTipoInfo";
				
			//Grabar Modificaciones del formato
			function GrabarCambios(){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var objgrid = $O("grid");
				for(var c=1;c<=12;c++){
					for(var f=1;f<=objgrid.rows.length-1;f++){
						var objtxt = objgrid.rows[f].cells[c].children[0];
						var oFMTInversionesBE = new EntidadesNegocio.Presupuesto.FMTInversionesBE();
						oFMTInversionesBE.Idformato= 24;
						oFMTInversionesBE.Idreporte = 1;
						oFMTInversionesBE.Idrubro = objgrid.rows[f].getAttribute("IDRUBRO");
						oFMTInversionesBE.Idcentrooperativo = oPagina.Request.Params[KEYQIDCENTROOPERATIVO];
						oFMTInversionesBE.Idcentrocosto = oPagina.Request.Params[KEYQIDCENTROCOSTO];
						oFMTInversionesBE.Periodo = oPagina.Request.Params[KEYQPERIODO];
						oFMTInversionesBE.Idmes = c;
						oFMTInversionesBE.Idtipoinformacion = oPagina.Request.Params[KEYQIDTIPOINFORMACION];
						oFMTInversionesBE.Montomes = objtxt.value;
						try{
							(new Controladora.Presupuesto.CPresupuestoInversiones()).InsertarModificar(oFMTInversionesBE);
						}
						catch(error){}
					}
				}
				PopupDeEsperaClose();
			}
		
		</script>
	</HEAD>
	<body onkeydown="if(event.keyCode==13){return false;}" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="AsignarEventodeSalidayCambio();ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="center" width="100%" colSpan="3">
						<TABLE class="normal" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="right" width="100%" colSpan="3"><IMG id="ibtnGrabar" alt="" src="../../../imagenes/ibtnGrabar.GIF" onmousedown="PopupDeEspera();"  onclick="GrabarCambios();"></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3"><cc1:datagridweb id="grid" runat="server" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
										DataKeyField="IdRubro">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="Concepto" HeaderText="CONCEPTO">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="ENE">
												<ItemTemplate>
													<ew:numericbox id="txtCol1" runat="server" Width="64px" CssClass="normaldetalle" PlacesBeforeDecimal="15"
														TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="FEB">
												<ItemTemplate>
													<ew:numericbox id="txtCol2" runat="server" Width="64px" CssClass="normaldetalle" PlacesBeforeDecimal="15"
														TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="MAR">
												<ItemTemplate>
													<ew:numericbox id="txtCol3" runat="server" Width="64px" CssClass="normaldetalle" PlacesBeforeDecimal="15"
														TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="ABR">
												<ItemTemplate>
													<ew:numericbox id="txtCol4" runat="server" Width="64px" CssClass="normaldetalle" PlacesBeforeDecimal="15"
														TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="MAY">
												<ItemTemplate>
													<ew:numericbox id="txtCol5" runat="server" Width="64px" CssClass="normaldetalle" PlacesBeforeDecimal="15"
														TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="JUN">
												<ItemTemplate>
													<ew:numericbox id="txtCol6" runat="server" Width="64px" CssClass="normaldetalle" PlacesBeforeDecimal="15"
														TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="JUL">
												<ItemTemplate>
													<ew:numericbox id="txtCol7" runat="server" Width="64px" CssClass="normaldetalle" PlacesBeforeDecimal="15"
														TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="AGO">
												<ItemTemplate>
													<ew:numericbox id="txtCol8" runat="server" Width="64px" CssClass="normaldetalle" PlacesBeforeDecimal="15"
														TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="SET">
												<ItemTemplate>
													<ew:numericbox id="txtCol9" runat="server" Width="64px" CssClass="normaldetalle" PlacesBeforeDecimal="15"
														TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="OCT">
												<ItemTemplate>
													<ew:numericbox id="txtCol10" runat="server" Width="64px" CssClass="normaldetalle" PlacesBeforeDecimal="15"
														TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="NOV">
												<ItemTemplate>
													<ew:numericbox id="txtCol11" runat="server" Width="64px" CssClass="normaldetalle" PlacesBeforeDecimal="15"
														TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="DIC">
												<ItemTemplate>
													<ew:numericbox id="txtCol12" runat="server" Width="64px" CssClass="normaldetalle" PlacesBeforeDecimal="15"
														TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb>
									<DIV align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></DIV>
									<asp:label id="Label1" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><INPUT id="hCodigo" style="WIDTH: 24px; HEIGHT: 14px" type="hidden" size="1" value="1"
										name="hCodigo" runat="server" DESIGNTIMEDRAGDROP="194"><INPUT id="hResolucion" style="WIDTH: 24px; HEIGHT: 14px" type="hidden" size="1" value="1"
										name="hResolucion" runat="server" DESIGNTIMEDRAGDROP="194"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
