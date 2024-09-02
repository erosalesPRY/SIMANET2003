<%@ Page language="c#" Codebehind="AdministrarComponentes.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.Proyecto.AdministrarComponentes" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarComponentes</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%" height="100%">
				<TR>
					<TD vAlign="top" align="left">
						<div style="WIDTH: 100%; HEIGHT: 450px; OVERFLOW: auto; TOP: 48px"><asp:datagrid id="gridComponente" runat="server" Width="100%" AutoGenerateColumns="False" style="Z-INDEX: 0">
								<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemGrilla"></ItemStyle>
								<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="DESCRIPCION">
										<HeaderStyle Width="95%"></HeaderStyle>
										<ItemTemplate>
											<asp:TextBox onblur="GrabarComponente(this);" id="txtDescripcion" runat="server" Width="100%"
												Height="63px" TextMode="MultiLine"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<IMG id="imgEliminaComponente" onclick="EliminarComponente(this);" src="../../imagenes/Filtro/Eliminar.gif"
												runat="server">
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></div>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script>
		
			function GrabarComponente(e){
				var orow;
				orow =jNet.get(e.parentNode.parentNode);
				if(e.value==orow.attr("DESCRIPCION")){return false;}
				orow.attr("DESCRIPCION",e.value);
				
				if(orow.attr("NMODO")!='1'){
					var oProyectoPerfilComponenteBE = new EntidadesNegocio.Estrategica.ProyectoPerfilComponenteBE();
					oProyectoPerfilComponenteBE.IdComponente= orow.attr("IDCOMPONENTE")
					oProyectoPerfilComponenteBE.IdProyectoPerfil = orow.attr("IDPROYECTOPERFIL");
					oProyectoPerfilComponenteBE.Descripcion = orow.attr("DESCRIPCION");
					oProyectoPerfilComponenteBE.IdEstado = 1;
					
					orow.attr("IDCOMPONENTE",(new AccesoDatos.Transacional.Estrategica.CProyectoPerfilComponente()).Insertar(oProyectoPerfilComponenteBE));
					orow.cells[1].childNodes[0].style.display="block";
				}
			}

			function EliminarComponente(e){
				var orow = e.parentNode.parentNode;
				var oDataGrid = orow.parentNode;
				orow = jNet.get(orow);
				Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro ahora?', function(btn){
					if(btn=="yes"){
						var oProyectoPerfilComponenteBE = new EntidadesNegocio.Estrategica.ProyectoPerfilComponenteBE();
							oProyectoPerfilComponenteBE.IdComponente= orow.attr("IDCOMPONENTE")
							oProyectoPerfilComponenteBE.IdProyectoPerfil = orow.attr("IDPROYECTOPERFIL");
							oProyectoPerfilComponenteBE.Descripcion = orow.attr("DESCRIPCION");
							oProyectoPerfilComponenteBE.IdEstado = 0;
							(new AccesoDatos.Transacional.Estrategica.CProyectoPerfilComponente()).Insertar(oProyectoPerfilComponenteBE);
							//Remover la fila
							oDataGrid.removeChild(orow);
					}
				});				
			}
		</script>
	</body>
</HTML>
