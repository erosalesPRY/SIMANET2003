<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministrarAprobaciondeRequerimientoTransferencia.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.AdministrarAprobaciondeRequerimientoTransferencia" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ConsultarEvaluacionGastosdeAdministracionCC</title>
<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../../styles.css" type=text/css rel=stylesheet >
<SCRIPT language=javascript src="../../js/@Import.js"></SCRIPT>

<script>
			var KEYQIDTRANSFERENCIA="idTransf";	
			var KEYQIDPERIODO = "Periodo";
			var KEYQIDCUENTACONTABLE = "CuentaContable";
			var KEYQIDCUENTACONTABLENOMBRE="CuentaContableNombre";
			var KEYQMONTOREQUERIDO="MontoRQR";			

			function AgregarModificar(wParametro){
				
				try{
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var oRequerimientoTransferenciaBE = new EntidadesNegocio.Presupuesto.RequerimientoTransferenciaBE();
					with(oRequerimientoTransferenciaBE){
						IdMovTransferencia = wParametro.IDREG;
						IdTransferencia = wParametro.IDTRASNFERENCIA;
						Periodo =  oPagina.Request.Params[KEYQIDPERIODO];
						IdMes = wParametro.IDMES;
						CuentaContable = oPagina.Request.Params[KEYQIDCUENTACONTABLE];
						Monto = wParametro.MONTO;
						idTipoMov = 2;
					}
					if((new Controladora.Presupuesto.CRequerimientoTransferencia()).InsertarModificar(oRequerimientoTransferenciaBE)>0){
						document.location.reload();
					}
				}
				catch(error){
						if(error instanceof SIMA.SIMAExcepcionLog){
							var oSIMAExcepcionLog = new SIMA.SIMAExcepcionLog();
							oSIMAExcepcionLog = error;
							window.alert(oSIMAExcepcionLog.Mensaje);
						}
						else if(error instanceof SIMA.SIMAExcepcionIU){
							var oSIMAExcepcionIU = new SIMA.SIMAExcepcionIU();
							oSIMAExcepcionIU=error;
							window.alert(oSIMAExcepcionIU.Mensaje);
						}
						else if(error instanceof SIMA.SIMAExcepcionDominio){
							var oSIMAExcepcionDominio = new SIMA.SIMAExcepcionDominio();
							oSIMAExcepcionDominio=error;
							window.alert("BASE DE DATOS\n" + oSIMAExcepcionDominio.Mensaje);
						}					
				}
			}
			/*--------------------------------------------------------------------------------------------------------------------------*/
			ValidarMontoATransferirMes=function(objTxt){
				var oCell = objTxt.parentElement;
				var oRow = oCell.parentElement;//Fila que contiene el monto del presupuesto
				var oDataGrid = oRow.parentElement.parentElement;
				var idxCell = oCell.cellIndex;
				var idxRow = oRow.rowIndex;
				var LastRow = oDataGrid.rows.length-1;
				var wiCentroCosto = oRow.getAttribute("idCentroCosto");
				
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var dr=ObtenerDatos(2,oPagina.Request.Params[KEYQIDTRANSFERENCIA],oPagina.Request.Params[KEYQIDCUENTACONTABLE],objTxt.value,wiCentroCosto,objTxt.getAttribute("idMovTransferencia"),idxCell);//el ultimo parametro es el mes segun la columna
				
				if(dr.Item("EOF")==false){
						for(var i=1;i<=LastRow;i++){
							var rowidCentroCosto= oDataGrid.rows[i].getAttribute("idCentroCosto");
							if(rowidCentroCosto== wiCentroCosto){
								return {NODOPADRE:i,
										ODATAGRID:oDataGrid,
										INDICADOR:dr.Item("Indicador"),
										SALDOMONTORQR:dr.Item("Saldo")
										};
							}	
						}
				}
			}			
			/*Validacion del monto a trasnferir frente al monto requerido*/
			/*--------------------------------------------------------------------------------------------------------------------------*/			
			ValidaMontoAprobacion=function(idTransferencia ,CuentaContable,MontoASumar){
				dr=ObtenerDatos(1,idTransferencia ,CuentaContable,MontoASumar,0,0,0);
				if(dr.Item("EOF")==false){
					return {INDICADOR:dr.Item("Indicador"),SALDOMONTORQR:dr.Item("SaldoMontoRequerido")};
				}
			}
			ObtenerDatos=function(TipoResultado,idTransferencia ,CuentaContable,MontoASumar,idcentroCosto,idMovTransferencia,idMes){
				var oDataTable = new System.Data.DataTable("TblRqr");
				oDataTable = (new Controladora.Presupuesto.CTransferencia()).ObtenerValidacionTransferencia(TipoResultado,idTransferencia ,CuentaContable,MontoASumar,idcentroCosto,idMovTransferencia,idMes);
				return oDataTable.Rows.Items[0];
			}
			/*--------------------------------------------------------------------------------------------------------------------------*/
			function MoverPuntero(){
				var objTxt = window.event.srcElement;
				if (event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.KeyReturn){
					if (objTxt.style.border !=""){
						//Datos que seran utilizados para totalizar el nodo
						if (objTxt.value != objTxt.ViejoValor){
							var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
							var idxCol = objTxt.parentElement.cellIndex;
							var idReg = objTxt.getAttribute("idMovTransferencia");
							var idTrans = objTxt.getAttribute("idTransferencia");
							var idTransPrincipal = oPagina.Request.Params[KEYQIDTRANSFERENCIA];
							var CuentaContable = oPagina.Request.Params[KEYQIDCUENTACONTABLE];
							var oResulSetValida =ValidarMontoATransferirMes(objTxt);//Obtiene Informacion de la fila raiz
							if(parseInt(oResulSetValida.INDICADOR)>0){
								var oValida = ValidaMontoAprobacion(idTransPrincipal,CuentaContable,objTxt.value);
									window.alert(oValida.INDICADOR);
									
								if(parseInt(oValida.INDICADOR)>0){
									var oDataGrid = oResulSetValida.ODATAGRID;
									//Actualiza el Saldo de la columna  modificada
									oDataGrid.rows[parseInt(oResulSetValida.NODOPADRE)].cells[idxCol].innerText = oResulSetValida.SALDOMONTORQR;
									AgregarModificar({IDREG:idReg,IDTRASNFERENCIA:idTrans,IDMES:idxCol,MONTO:objTxt.value});
									objTxt.ViejoValor=objTxt.value;
								}else{
									window.alert("No es posible asignar mas de lo solicitado \nPor favor modificar monto a trasnferir");
									objTxt.value=objTxt.ViejoValor;
								}
							}else{
								window.alert("No es posible registrar monto a transferir :=" + objTxt.value +"\npor que no existe saldo que transferir para este mes :=" + oResulSetValida.SALDOMONTORQR.toString());
								objTxt.value=objTxt.ViejoValor;
							}
							objTxt.style.border ="none";
							objTxt.select();							
						}
					}
					else{
						GridControl_Navegar(objTxt,SIMA.Utilitario.Enumerados.TipoEnfoque.DERECHA);
					}
				}
				else if (event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.keyUp){//Flecha Arriba
					if (objTxt.style.border ==""){
						GridControl_Navegar(objTxt,SIMA.Utilitario.Enumerados.TipoEnfoque.ARRIBA);
					}
				}				
				else if (event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.keyDown){//Flecha Abajo
					if (objTxt.style.border ==""){
						GridControl_Navegar(objTxt,SIMA.Utilitario.Enumerados.TipoEnfoque.ABAJO);
					}
				}								
				else if(event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.keyRight){//FechaDrecha
					GridControl_Navegar(objTxt,SIMA.Utilitario.Enumerados.TipoEnfoque.DERECHA);
				}
				else if(event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.keyLeft){//FechaIzquierda
					GridControl_Navegar(objTxt,SIMA.Utilitario.Enumerados.TipoEnfoque.IZQUIERDA);
				}
				else if (event.keyCode == 113){//Esta Tecla permite la edicion dela celda
					objTxt.style.border ="1.5pt inset";
				}
				else if (event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.KeyEscape){//la Tecla Escape
					objTxt.value = objTxt.ViejoValor;
					objTxt.select();
				}
				else{
					if (window.event.keyCode <= 12 || ((window.event.keyCode >= 48 && window.event.keyCode <= 57)|| (window.event.keyCode==46) || (window.event.keyCode>=96 && window.event.keyCode <=105) )){
						objTxt.style.border ="1.5pt inset";
					}
					return (window.event.keyCode <= 12 || ((window.event.keyCode >= 48 && window.event.keyCode <= 57)|| (window.event.keyCode==46) || (window.event.keyCode>=96 && window.event.keyCode <=105) ));
				}
			}
			/*--------------------------------------------------------------------------------------------------------------*/			
			GridControl_Desenfocar=function(){
				var objTxt = window.event.srcElement;
				objTxt.style.border ="none";
				objTxt.style.background="Transparent";
			}
			GridControl_Alenfocar=function(){
				var objTxt = window.event.srcElement;
				objTxt.style.border ="none";
				objTxt.style.background= "#ffffcc";
				objTxt.select();
			}
		
			
			GridControl_Navegar=function(objTxt,TipoEnfoque){
				var oCell = objTxt.parentElement;
				var oRow = oCell.parentElement;//Fila que contiene el monto del presupuesto
				var oDataGrid = oRow.parentElement.parentElement;
				var idxCell = oCell.cellIndex;
				var idxRow = oRow.rowIndex;
				var LastRow = oDataGrid.rows.length-1;
				var objEnfoque;
				//Elabora el Nombre del Objeto a enfocar
				try{
					switch(TipoEnfoque){
						case SIMA.Utilitario.Enumerados.TipoEnfoque.DERECHA:
							objEnfoque = oDataGrid.rows[idxRow].cells[idxCell+1].children[0];
							break;
						case SIMA.Utilitario.Enumerados.TipoEnfoque.IZQUIERDA:
							objEnfoque = oDataGrid.rows[idxRow].cells[idxCell-1].children[0];
							break;
						case SIMA.Utilitario.Enumerados.TipoEnfoque.ARRIBA:
							objEnfoque = oDataGrid.rows[idxRow-1].cells[idxCell].children[0];
							break;
						case SIMA.Utilitario.Enumerados.TipoEnfoque.ABAJO:
							objEnfoque = oDataGrid.rows[idxRow+1].cells[idxCell].children[0];
							break;
					}
					//Realiza el Enfoque del Objeto
				objEnfoque.focus();
				}catch(error){
					if(error.number=-2146833281){
						//Ya no existen mas obj a la derecha entoces baja una fila y se pocisiona enl primer objeto de esa fila
						try{
							switch(TipoEnfoque){
								case SIMA.Utilitario.Enumerados.TipoEnfoque.DERECHA:
									objEnfoque = oDataGrid.rows[idxRow+1].cells[1].children[0];
									break;
								case SIMA.Utilitario.Enumerados.TipoEnfoque.IZQUIERDA:
									break;
								case SIMA.Utilitario.Enumerados.TipoEnfoque.ARRIBA:
									break;
								case SIMA.Utilitario.Enumerados.TipoEnfoque.ABAJO:
									objEnfoque = oDataGrid.rows[2].cells[idxCell+1].children[0];
									break;
							}
							objEnfoque.focus();
						}catch(error){}
					}
				}				
			}
			/*--------------------------------------------------------------------------------------------------------------*/			
		</script>
</HEAD>
<body bottomMargin=0 leftMargin=0 topMargin=0 scroll=yes>
<form id=Form1 method=post runat="server">
<TABLE id=Table3 cellSpacing=1 cellPadding=1 width="100%" border=0>
  <TR>
    <TD class=commands><asp:label id=lblPagina runat="server" CssClass="RutaPaginaActual"> Inicio> Gestión Financiera> Prespuesto> Administración de Transferencia</asp:label></TD></TR>
  <TR>
    <TD>
      <TABLE id=Table2 cellSpacing=1 cellPadding=1 width="100%" align=left 
      border=0>
        <TR bgColor=#f0f0f0>
          <TD style="WIDTH: 111px"><asp:label id=Label1 runat="server" CssClass="normaldetalle">CUENTA CONTABLE:</asp:Label></TD>
          <TD style="WIDTH: 258px"><asp:label id=lblConceptoContable runat="server" CssClass="normaldetalle">CUENTA CONTABLE:</asp:Label></TD>
          <TD style="WIDTH: 132px"><asp:label id=Label3 runat="server" CssClass="normaldetalle">MONTO REQUERIDO:</asp:Label></TD>
          <TD><asp:label id=lblMonto runat="server" CssClass="normaldetalle">0.00</asp:Label></TD></TR></TABLE></TD></TR>
  <TR>
    <TD align=left><cc1:datagridweb id=grid runat="server" PageSize="7" AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" Width="100%">
							<AlternatingItemStyle CssClass="AlternateitemgrillaTree"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrillaTree"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="HeaderGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn HeaderText="CENTRO DE COSTO">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="ENE">
									<HeaderStyle Width="6.6%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="FEB">
									<HeaderStyle Width="6.6%"></HeaderStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="MAR">
									<HeaderStyle Width="6.6%"></HeaderStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="ABR">
									<HeaderStyle Width="6.6%"></HeaderStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="MAY">
									<HeaderStyle Width="6.6%"></HeaderStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="JUN">
									<HeaderStyle Width="6.6%"></HeaderStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="JUL">
									<HeaderStyle Width="6.6%"></HeaderStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="AGOS">
									<HeaderStyle Width="6.6%"></HeaderStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="SET">
									<HeaderStyle Width="6.6%"></HeaderStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="OCT">
									<HeaderStyle Width="6.6%"></HeaderStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="NOV">
									<HeaderStyle Width="6.6%"></HeaderStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="DIC">
									<HeaderStyle Width="6.6%"></HeaderStyle>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD></TR>
  <TR>
    <TD align=center width="100%">
      <TABLE id=Table1 cellSpacing=1 cellPadding=1 width="100%" align=left 
      border=0>
        <TR>
          <TD width="45%"><INPUT id=hidMes 
            style="WIDTH: 32px; HEIGHT: 22px" type=hidden size=1 name=hidMes 
             runat="server">&nbsp;<IMG onmouseup="this.src ='../../imagenes/Navegador/ibtnAnterior.gif';" onmousedown="this.src ='../../imagenes/Navegador/ibtnAnteriorPress.gif';" id=btnMostrarIzq onmouseover="this.src ='../../imagenes/Navegador/ibtnAnterior.gif'" style="DISPLAY: none"  onmouseout="this.src='../../imagenes/Navegador/ibtnAnterior.gif';" src="../../imagenes/Navegador/ibtnAnterior.gif" name=btnQuitar ><IMG onmouseup="this.src ='../../imagenes/Navegador/ibtnSiguiente.gif';" onmousedown="this.src ='../../imagenes/Navegador/ibtnSiguientePress.gif';" id=btnMostrarDer onmouseover="this.src ='../../imagenes/Navegador/ibtnSiguiente.gif'" style="DISPLAY: none" onclick="this.src ='../../imagenes/Navegador/ibtnSiguientePress.gif';" onmouseout="this.src='../../imagenes/Navegador/ibtnSiguiente.gif';" src="../../imagenes/Navegador/ibtnSiguiente.gif" > </TD>
          <TD></TD></TR></TABLE></TD></TR>
  <TR>
    <TD align=center><asp:label id=lblResultado runat="server" CssClass="ResultadoBusqueda"></asp:label></TD></TR></TABLE></FORM>
	</body>
</HTML>
