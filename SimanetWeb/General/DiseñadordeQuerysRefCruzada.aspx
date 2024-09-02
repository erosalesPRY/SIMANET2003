<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DiseñadordeQuerysRefCruzada.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.DiseñadordeQuerysRefCruzada" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DiseñadordeQuerysRefCruzada</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="/SimanetWeb/js/@Import.js"></SCRIPT>
		<SCRIPT src="/SimanetWeb/js/dragdrop.js" type="text/javascript"></SCRIPT>
		<STYLE type="text/css">.DragContainer { BORDER-RIGHT: #ffff66 1px dotted; PADDING-RIGHT: 5px; BORDER-TOP: #ffff66 1px dotted; PADDING-LEFT: 5px; FLOAT: left; PADDING-BOTTOM: 0px; MARGIN: 3px; BORDER-LEFT: #ffff66 1px dotted; WIDTH: 97%; PADDING-TOP: 5px; BORDER-BOTTOM: #ffff66 1px dotted }
	.OverDragContainer { BORDER-RIGHT: #669999 2px solid; PADDING-RIGHT: 5px; BORDER-TOP: #669999 2px solid; PADDING-LEFT: 5px; FLOAT: left; PADDING-BOTTOM: 5px; MARGIN: 3px; BORDER-LEFT: #669999 2px solid; WIDTH: 100px; PADDING-TOP: 5px; BORDER-BOTTOM: #669999 2px solid; HEIGHT: 10px }
	.DragBox { BORDER-RIGHT: #000 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #000 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 10px; MARGIN-BOTTOM: 5px; PADDING-BOTTOM: 2px; BORDER-LEFT: #000 1px solid; WIDTH: 94px; CURSOR: pointer; PADDING-TOP: 2px; BORDER-BOTTOM: #000 1px solid; FONT-FAMILY: verdana, tahoma, arial; WHITE-SPACE: nowrap; BACKGROUND-COLOR: #eee }
	.OverDragBox { BORDER-RIGHT: #000 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #000 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 10px; MARGIN-BOTTOM: 5px; PADDING-BOTTOM: 2px; BORDER-LEFT: #000 1px solid; WIDTH: 94px; CURSOR: pointer; PADDING-TOP: 2px; BORDER-BOTTOM: #000 1px solid; FONT-FAMILY: verdana, tahoma, arial; BACKGROUND-COLOR: #eee }
	.DragDragBox { BORDER-RIGHT: #000 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #000 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 10px; MARGIN-BOTTOM: 5px; PADDING-BOTTOM: 2px; BORDER-LEFT: #000 1px solid; WIDTH: 94px; CURSOR: pointer; PADDING-TOP: 2px; BORDER-BOTTOM: #000 1px solid; FONT-FAMILY: verdana, tahoma, arial; BACKGROUND-COLOR: #eee }
	.miniDragBox { BORDER-RIGHT: #000 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #000 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 10px; MARGIN-BOTTOM: 5px; PADDING-BOTTOM: 2px; BORDER-LEFT: #000 1px solid; WIDTH: 94px; CURSOR: pointer; PADDING-TOP: 2px; BORDER-BOTTOM: #000 1px solid; FONT-FAMILY: verdana, tahoma, arial; BACKGROUND-COLOR: #eee }
	.OverDragContainer { BACKGROUND-COLOR: #eee }
	.OverDragBox { BACKGROUND-COLOR: #ffff99 }
	.DragDragBox { BACKGROUND-COLOR: #ffff99 }
	.DragDragBox { FILTER: alpha(opacity=50); BACKGROUND-COLOR: #ff99cc }
	LEGEND { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #666699; FONT-FAMILY: verdana, tahoma, arial }
	FIELDSET { PADDING-RIGHT: 3px; PADDING-LEFT: 3px; PADDING-BOTTOM: 3px; PADDING-TOP: 3px; HEIGHT: 82px; noWrap: }
	.History { FONT-SIZE: 10px; OVERFLOW: auto; WIDTH: 100%; FONT-FAMILY: verdana, tahoma, arial; HEIGHT: 82px }
	#DragContainer8 { BORDER-RIGHT: #669999 1px solid; BORDER-TOP: #669999 1px solid; BORDER-LEFT: #669999 1px solid; BORDER-BOTTOM: #669999 1px solid; HEIGHT: 110px }
	.miniDragBox { FLOAT: left; MARGIN: 0px 5px 5px 0px; WIDTH: 20px; HEIGHT: 20px }
		</STYLE>
		<STYLE>.imgTopLeft { BACKGROUND-POSITION: right bottom; BACKGROUND-IMAGE: url(/GestordeReportes/js/Busqueda/styles/ul.gif); BACKGROUND-REPEAT: no-repeat }
	.imgTopCenter { BACKGROUND-POSITION: center bottom; BACKGROUND-IMAGE: url(/GestordeReportes/js/Busqueda/styles/um.gif); BACKGROUND-REPEAT: repeat-x }
	.imgTopRight { BACKGROUND-POSITION: left bottom; BACKGROUND-IMAGE: url(/GestordeReportes/js/Busqueda/styles/ur.gif); BACKGROUND-REPEAT: no-repeat }
	.imgCenterLeft { BACKGROUND-POSITION: right top; BACKGROUND-IMAGE: url(/GestordeReportes/js/Busqueda/styles/ml.gif); BACKGROUND-REPEAT: repeat-y }
	.imgCenterCenter { BACKGROUND-IMAGE: url(/GestordeReportes/js/Busqueda/styles/clip_mid.GIF) }
	.imgCenterRight { BACKGROUND-POSITION: left top; BACKGROUND-IMAGE: url(/GestordeReportes/js/Busqueda/styles/mr.gif); BACKGROUND-REPEAT: repeat-y }
	.imgBottonDown { BACKGROUND-POSITION: left top; BACKGROUND-IMAGE: url(/GestordeReportes/js/Busqueda/styles/bm.gif); BACKGROUND-REPEAT: repeat-x }
		</STYLE>
		<script>
			function QryGenerador(){
				this.ContenedordeCampos = $O('DragContainer8');
				this.ContenedordeCriterios = $O('DragContainer0');
				this.ContenedordeColumnasAgrupadas = $O('DragContainer6');
				this.ContenedordeFilasAgrupadas = $O('DragContainer5');
				this.ContenedordeColumnasTotalizar = $O('DragContainer7');
				
				
				this.CamposDisponibles=function(_DataTable){
					this.CargarControles(this.ContenedordeCampos,_DataTable);
				}
				this.CamposCriterios=function(_DataTable){
					this.CargarControles(this.ContenedordeCriterios,_DataTable);
				}
				this.CamposColumnasAgrupadas=function(_DataTable){
					this.CargarControles(this.ContenedordeColumnasAgrupadas,_DataTable);
				}
				this.CamposFilasAgrupadas=function(_DataTable){
					this.CargarControles(this.ContenedordeFilasAgrupadas,_DataTable);
				}
				this.CamposTotalizadores=function(_DataTable){
					this.CargarControles(this.ContenedordeColumnasTotalizar,_DataTable);
				}
				
				this.CargarControles=function(Parent,_DataTable){
					for (f=0;f<=_DataTable.Rows.Items.length-1;f++){
						var oDataRow = _DataTable.Rows.Items[f];
						var obj_A = document.createElement("A");
						obj_A.id = oDataRow.Item("NombreColumna");
						obj_A.className="DragBox";
						obj_A.overclass="OverDragBox"; 
						obj_A.dragclass="DragDragBox";
						obj_A.innerText = oDataRow.Item("NombreColumna")
						Parent.appendChild(obj_A);
					}													
				}
			}
			
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<div class="CONTENEDOR" style="LEFT: 50px; POSITION: absolute; TOP: 150px">
				<TABLE id="tblForm" style="WIDTH: 57px; HEIGHT: 48px" cellSpacing="0" cellPadding="0" width="57"
					border="0">
					<TR>
						<TD class="imgTopLeft" style="HEIGHT: 31px"></TD>
						<TD class="imgTopCenter" style="HEIGHT: 31px" vAlign="bottom" align="center"><SPAN class="TITLEBAR" style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; LEFT: -5px; WIDTH: 138px; CURSOR: move; COLOR: #ffffff; POSITION: relative; TOP: 12px; HEIGHT: 20px; noWrap: ">SALDOS 
								CONTABLES </SPAN>
						</TD>
						<TD class="imgTopRight" style="HEIGHT: 31px" vAlign="bottom" align="left"><IMG src="../Js/Busqueda/styles/ibtnCerrar.gif"></TD>
					</TR>
					<TR>
						<TD class="imgCenterLeft"></TD>
						<TD class="imgCenterCenter" id="Demo8" style="PADDING-TOP: 10px" align="center">
							<DIV class="DragContainer" id="DragContainer8" style="WIDTH: 100px; HEIGHT: 27px" align="center"
								overclass="OverDragContainer">
							</DIV>
						</TD>
						<TD class="imgCenterRight"></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="right"><IMG src="../Js/Busqueda/styles/bl.gif"></TD>
						<TD class="imgBottonDown"></TD>
						<TD vAlign="top" align="left"><IMG src="../Js/Busqueda/styles/br.gif"></TD>
					</TR>
				</TABLE>
			</div>
			<div id="txtDemo">
				<TABLE id="Table2" height="100%" cellSpacing="1" cellPadding="0" width="100%" border="0">
					<TR>
						<TD>
							<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
					</TR>
					<TR>
						<TD>
							<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
					</TR>
					<TR>
						<TD width="100%" height="100%">
							<TABLE id="Table1" height="70%" cellSpacing="10" cellPadding="1" width="70%" align="center"
								border="1">
								<TR>
									<TD style="FILTER: alpha(style=1, opacity=100, finishOpacity=70, startX=0,finishX=0, startY=90,finishY=5); COLOR: #ffffff"
										width="100%" bgColor="#333333" colSpan="2" height="10">Arrastre aqui los campos 
										que se deberan utilizar como filtros generales
										<DIV id="Demo0" style="LEFT: 5px; WIDTH: 98%; POSITION: relative; TOP: -5px" align="left">
											<DIV class="DragContainer" id="DragContainer0" style="WIDTH: 98%; COLOR: #0000cc; HEIGHT: 24px"
												noWrap overclass="OverDragContainer">
											</DIV>
										</DIV>
									</TD>
								</TR>
								<TR>
									<TD id="Demo5" style="FILTER: alpha(style=1, opacity=100, finishOpacity=70, startX=0,finishX=0, startY=90,finishY=5); WIDTH: 122px"
										bgColor="#999966" rowSpan="2">
										<DIV class="DragContainer" id="DragContainer5" style="WIDTH: 75.71%; HEIGHT: 16px" overclass="OverDragContainer">
										</DIV>
									</TD>
									<TD id="Demo6" style="FILTER: alpha(style=1, opacity=100, finishOpacity=70, startX=0,finishX=0, startY=90,finishY=5)"
										width="80%" bgColor="appworkspace">
										<DIV class="DragContainer" id="DragContainer6" style="WIDTH: 98%; HEIGHT: 28px" overclass="OverDragContainer">
										</DIV>
									</TD>
								</TR>
								<TR>
									<TD id="Demo7" style="FILTER: alpha(style=1, opacity=100, finishOpacity=70, startX=0,finishX=0, startY=90,finishY=5)"
										bgColor="#99cccc" height="100%">
										<DIV class="DragContainer" id="DragContainer7" style="WIDTH: 98%; HEIGHT: 27px" overclass="OverDragContainer"><A class="DragBox" id="Item75" overclass="OverDragBox" dragclass="DragDragBox">Item 
												#75</A> <A class="DragBox" id="Item76" overclass="OverDragBox" dragclass="DragDragBox">
												Item #76</A> <A class="DragBox" id="Item77" overclass="OverDragBox" dragclass="DragDragBox">
												Item #77</A> <A class="DragBox" id="Item78" overclass="OverDragBox" dragclass="DragDragBox">
												Item #78</A>
										</DIV>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
				</TABLE>
			</div>
		</form>
		<script>
			(function(){
				var _QryGenerador = new QryGenerador();
				_QryGenerador.CamposDisponibles((new Controladora.General.CQRYDescribeObjeto()).DescribeTablaOVista(1,"vCentrosdeCosto"));
				_QryGenerador.CamposCriterios((new Controladora.General.CQRYDescribeObjeto()).ListarCamposDiseno(1,"vCentrosdeCosto",1));
				_QryGenerador.CamposColumnasAgrupadas((new Controladora.General.CQRYDescribeObjeto()).ListarCamposDiseno(1,"vCentrosdeCosto",2));
				_QryGenerador.CamposFilasAgrupadas((new Controladora.General.CQRYDescribeObjeto()).ListarCamposDiseno(1,"vCentrosdeCosto",3));
				_QryGenerador.CamposTotalizadores((new Controladora.General.CQRYDescribeObjeto()).ListarCamposDiseno(1,"vCentrosdeCosto",4));
				
				
			})()
		</script>
	</body>
</HTML>
