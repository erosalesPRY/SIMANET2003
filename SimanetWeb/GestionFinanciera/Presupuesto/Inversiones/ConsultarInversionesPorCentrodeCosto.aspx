<%@ Page language="c#" Codebehind="ConsultarInversionesPorCentrodeCosto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.Inversiones.ConsultarInversionesPorCentrodeCosto" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/FrameCallBack.js"></SCRIPT>
		<script>
			function MostrarDetalle(){
				window.alert("Mostrar detalle");
			}
			function Mostrar(e){
				var tblNodo= e.parentElement.parentElement.parentElement.parentElement;
				var objCell= tblNodo.parentElement;
				var NroCol = objCell.cellIndex
				
				var CRTGRID = "grid";
				var isOpen = SIMA.Utilitario.Helper.General.Treeview.Nodo.Expandir(e);
				var VER = ((isOpen==true)?"BLOCK":"NONE");
				var wAncho = ((isOpen==true)?"300px":"100%");
				
				var oGrid = $O(CRTGRID);
				var AnchoCelda = "400px";
				for(var i=1;i<=oGrid.rows.length-1;i++){
					//Cabecera
					tblNodo.rows[2].cells[0].style.display=VER;
					tblNodo.rows[2].cells[0].style.width = AnchoCelda;
					tblNodo.rows[2].cells[1].style.display=VER;
					tblNodo.rows[2].cells[1].style.width = AnchoCelda;
					tblNodo.rows[2].cells[2].style.display=VER;
					tblNodo.rows[2].cells[2].style.width = AnchoCelda;
					//Detalle
					var otbl = oGrid.rows[i].cells[NroCol].children[0];
					otbl.style.width = wAncho;
					
					otbl.rows[0].cells[0].style.display=VER;
					otbl.rows[0].cells[0].style.width = AnchoCelda;
					otbl.rows[0].cells[1].style.display=VER;
					otbl.rows[0].cells[1].style.width = AnchoCelda;
					otbl.rows[0].cells[2].style.display=VER;
					otbl.rows[0].cells[2].style.width = AnchoCelda;
					
				}
			
			}
		</script>
	</HEAD>
	<body onkeydown="if(event.keyCode==13){return false;}" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="center" width="100%" colSpan="3">
						<TABLE class="normal" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
											<asp:BoundColumn DataField="Presupuesto" HeaderText="PPTO">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="ENE">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="FEB">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="MAR">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="ABR">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="MAY">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="JUN">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="JUL">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="AGO">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="SET">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="OCT">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="NOV">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="DIC">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="AVAN">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb>
									<DIV align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></DIV>
									<asp:label id="Label1" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><INPUT id="hCodigo" style="WIDTH: 24px; HEIGHT: 14px" type="hidden" size="1" value="1"
										name="hCodigo" runat="server" DESIGNTIMEDRAGDROP="194"></TD>
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
