<%@ Page language="c#" Codebehind="VistaPrevia.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.VistaPrevia" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>VistaPrevia</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script>
			function Mostrar(){
				window.aler();
				var oItem = new Item();
				oItem.Texto="Eddy sistema de gestion financiera sima peru";
				oItem.Left = "50px";
				oItem.Top = "50px";
				
				var oPrinter = new Printer();
				oPrinter.Header.Items.Adicionar(oItem);
				
				oHeader = new Header();
				oHeader.Items.Adicionar(oItem);

				oItem = new Item();
				oItem.Texto="Jose";
				oItem.Left = "350px";
				oItem.Top = "50px";
				oHeader.Items.Adicionar(oItem);

				oPrinter.Header.Items.Adicionar(oItem);
				

				oItem = new Item();
				oItem.Texto="SISTEMA DE GESTION FINANCIERA";
				oItem.Left = "50px";
				oItem.Top = "250px";

				
				oHeader = new Header();
				oHeader.Items.Adicionar(oItem);

				oItem = new Item();
				oItem.Texto="MODULO DE GESTION";
				oItem.Left = "350px";
				oItem.Top = "250px";
				oHeader.Items.Adicionar(oItem);


				
				
				oPrinter.Body.Agrupacion.HeaderCollections.Adicionar(oHeader);
				//oPrinter.Body.Agrupacion.HeaderCollections.Adicionar(oHeader);
				//Imprime la Cabecera
				oPrinter.Header.Print();
				oPrinter.Body.Agrupacion.HeaderCollections.Print();
			}
			
			function Printer(){
				this.Header = new Header();
				this.Body = new Body();
			}
			
			
			function Header(){//Cabecera de Página
				var Long=0;
				this.Items = new Array();
				this.Items.Adicionar=function(_Item){
					this[this.length] = new Array();
					this[this.length-1] = _Item;
					Long=this.length;
				}
				this.Print=function(){
					var _Items = this.Items;
					for(var h=0;h<=Long-1;h++){
						var _Item = new Item();
						_Item = _Items[h];
						_Item.Paint();
					}	
				}
			}
			
			function Body(){//Cuerpo de Página
				this.Agrupacion = new Agrupacion();
			}
			
			function Agrupacion(){
				this.HeaderCollections = new Array();
				this.HeaderCollections.Adicionar=function(_HeaderCollections){
					this[this.length] = new Array();
					this[this.length-1] = _HeaderCollections;
				}
				
				this.HeaderCollections.Print=function(){
					for(var i=0;i<=this.length-1;i++){
						_Header = new Header();
						_Header =  this[i];
						_Header.Print();
					}
				}
			}
			
			function Footer(){//Pie de Página
				this.Items = new Array();
				this.Items.Adicionar=function(_Item){
					this[this.length] = new Array();
					this[this.length-1] = _Item;
				}
			}
			
			function Item(TEXTO,ITEMNAME,LEFT,TOP,ANCHO,FONTSIZE,FONTBOLD,FONTNAME){
				this.Texto=TEXTO;
				this.ItemName=ITEMNAME;
				this.Left=LEFT;
				this.Top=TOP;
				this.Ancho=ANCHO;
				this.FontSize=FONTSIZE;
				this.FontBold=FONTBOLD;
				this.FontName=FONTNAME;
				this.Paint=function(){
				var objCtrl = document.createElement("input");
					objCtrl.value = this.Texto;
					objCtrl.style.position="absolute";
					objCtrl.style.left = this.Left;
					objCtrl.style.top = this.Top;
					objCtrl.style.border = "none";
					document.body.appendChild(objCtrl);
				}
			}
			
		</script>
	</HEAD>
	<body onload ="Mostrar();">
		<form id="Form1" method="post" runat="server">
		</form>
	</body>
</HTML>
