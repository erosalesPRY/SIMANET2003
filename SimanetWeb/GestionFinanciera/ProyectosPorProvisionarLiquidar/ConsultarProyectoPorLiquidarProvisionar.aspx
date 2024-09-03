<%@ Page language="c#" Codebehind="ConsultarProyectoPorLiquidarProvisionar.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.ProyectosPorProvisionarLiquidar.ConsultarProyectoPorLiquidarProvisionar" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<script language="javascript" type="text/javascript">

		ImagenBotonMenos=new Image(11,11);
		ImagenBotonMenos.src="/SimanetWeb/imagenes/tree/minus.gif";
		 
		ImagenBotonMas=new Image(11,11);
		ImagenBotonMas.src="/SimanetWeb/imagenes/tree/plus.gif";
		
		function DesplasarFilasGrilla(ValorAsignar)
		{
			AsignarIndiceSeleccionGrilla(ValorAsignar);
		}

		var ArrayGrupo=new Array();
		var ArrayEstado=new Array();

		
		/*
		 Los valores de las Ariables del tipo Array se generan en el servidor.
		*/
		 function AsignarIndiceSeleccionGrilla(valorAsignar,ObjetoClick)
		 {
			if(valorAsignar!='')
			{
				for(i=0;i<ArrayGrupo[valorAsignar].length;i++)
				{
					FilaSelect=ArrayGrupo[valorAsignar][i];
					objFila=document.all[FilaSelect];
					if(ArrayEstado[valorAsignar]==false)
					{
						objFila.style.display='inLine';
					}
					else
					{
						objFila.style.display='none';
					}
				}
				if(ArrayEstado[valorAsignar]==false)
				{
					ArrayEstado[valorAsignar]=true;
					ObjetoClick.src=ImagenBotonMenos.src;
				}
				else
				{
					ArrayEstado[valorAsignar]=false;
					ObjetoClick.src=ImagenBotonMas.src;
				}
			}	
		 }
		 
		 function Expandir()
		  {
			
				var patron = "grid_IdTablaFila@_ImgbtId";
				var caracter="@";
				var grilla = document.all['grid'];
			
				for(var i=1;i<=grilla.rows.length-1;i++)
				{
						
						/*var strNombre=patron.toString().Replace(carater,i.toString());
						alert(strNombre);*/
						var fila1=document.all['grid_IdTablaFila1_ImgbtId'];		
						var fila2=document.all['grid_IdTablaFila2_ImgbtId'];		
						var fila3=document.all['grid_IdTablaFila3_ImgbtId'];		
						var fila4=document.all['grid_IdTablaFila4_ImgbtId'];		
						var fila5=document.all['grid_IdTablaFila5_ImgbtId'];		
													
						fila1.onclick();	
						fila2.onclick();	
						fila3.onclick();	
						fila4.onclick();	
						fila5.onclick();	
									
				} 
				
		 }
		 
		</script>
	</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial(); Expandir();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="IdTable" style="WIDTH: 767px" cellSpacing="0" cellPadding="0" width="767" border="0">
							<TR>
								<TD align="right" width="100%" colSpan="3">
									<P align="center">
										<asp:label id="Label5" runat="server" Width="67px" CssClass="TituloPrincipalBlanco" BackColor="Transparent"
											ForeColor="Navy">PERIODO :</asp:label>
										<asp:dropdownlist id="ddlbPeriodo" runat="server" CssClass="combos" AutoPostBack="True"></asp:dropdownlist></P>
								</TD>
							</TR>
							<TR>
								<TD align="right" width="100%" colSpan="3">
									<asp:imagebutton id="ibtnAbrir" runat="server" ImageUrl="..\..\imagenes\bt_exportar.gif" Visible="False"></asp:imagebutton>
									<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<cc1:datagridweb id="grid" runat="server" ShowFooter="True" CssClass="HeaderGrilla" BorderStyle="None"
										PageSize="7" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" Width="780px">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="LINEA DE NEGOCIO">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="ImgbtId" runat="server" ImageAlign="AbsMiddle"></asp:ImageButton>
													<asp:HyperLink id="hlkId" runat="server">Proyecto</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="Cantidad" HeaderText="CANT.">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Facturado" HeaderText="VENTAS" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CostosProduccion" HeaderText="COSTO DE PRODUCCION" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Resultado" HeaderText="RESULTADO" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3"></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3"></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<cc1:datagridweb id="gridResumen" runat="server" Width="780px" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
										PageSize="7" BorderStyle="None" CssClass="HeaderGrilla" ShowFooter="True">
										<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="TIPOCLIENTE" HeaderText="TIPO CLIENTE"></asp:BoundColumn>
											<asp:BoundColumn DataField="Cantidad" HeaderText="CANT.">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Facturado" HeaderText="VENTAS" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CostosProduccion" HeaderText="COSTO DE PRODUCCION" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Resultado" HeaderText="RESULTADO" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td vAlign="top" width="592"></td>
				</tr>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
