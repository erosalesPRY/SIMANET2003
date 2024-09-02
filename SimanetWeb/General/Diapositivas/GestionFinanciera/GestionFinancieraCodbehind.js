function CollapseCol(e,sender){
	var arrPath = e.src.toString().split('/');
	var Path = SIMA.Utilitario.Helper.General.ObtenerPathApp() +"/imagenes/tree/";
	
	var Icono = ((arrPath[arrPath.length-1]=="plusCol.gif")?"minusCol.gif":"plusCol.gif");
	var vista = ((arrPath[arrPath.length-1]=="plusCol.gif")?"block":"none");
	var objCell = document.getElementById(e.CellID);
	
	objCell.colSpan = ((arrPath[arrPath.length-1]=="plusCol.gif")?4:1);	
	e.src= Path +Icono;
	
	var oDataGrid = document.getElementById(sender);
	var _ColIni = parseInt(e.ColIni,10);
	
	for(var f=1;f<=oDataGrid.rows.length-1;f++){
		var oRow = oDataGrid.rows[f];
		for(c=_ColIni;c<=(_ColIni+2);c++){
			var idxCell = ((f==1)?c-1:c);
			var oCell = oRow.cells[idxCell];
			oCell.style.display=vista;
		}
	}				
}

/*---------------------------------------------------------GraphChart------------------------------------------------------*/
var GraphChart=function(){
	this.GraficoBE={};
	this.ChartSource={};
	this.Render=function(write){
	
		var chart = AmCharts.makeChart( write, {
										"type": this.GraficoBE.Tipo,
										"theme": this.GraficoBE.Tema,
										"titles": this.GraficoBE.Titulo.getAll(),
										"legend": this.GraficoBE.LegendaBE,
										"dataProvider":this.GraficoBE.DataCollection.getAll(),
										"valueField":"value",
										"titleField": "text",
										"labelRadius":5,
										"outlineAlpha": 0.4,
										"depth3D": 15,
										"balloonText": this.GraficoBE.ToolTips,
										"angle": this.GraficoBE.Angulo,
										"export": {"enabled": true},
										"marginTop":0,
										"marginBottom":0,
										"backgroundColor":"#FFFFFF",
										"listeners": [{"event": "drawn","method": this.GraficoBE.EventHandle}]
										} );
		this.ChartSource=chart;
	}
}


GraphChart.DataBE=function(TITLEFIELD,VALUEFIELD){
	this.TextField=TITLEFIELD;
	this.ValueField=VALUEFIELD;
}
GraphChart.TituloBE=function(TEXT,FONTBOLD){
	this.Text=Text=TEXT;
	this.FontBold=FONTBOLD;
}

GraphChart.LegendaBE=function(MAXCOLUMN,POSICION,MARKERSIZE,MARGENTOP){
		this.MaxColumn=MAXCOLUMN;
		this.Posicion=POSICION;
		this.MarkerSize=MARKERSIZE;
		this.MargenTop=MARGENTOP;
		this.Render=function(){
			return {"horizontalGap": 5,
					"maxColumns": this.MaxColumn,
					"position":this.Posicion,
					"useGraphSettings": true,
					"markerSize": this.MarkerSize,
					"marginTop": this.MargenTop
					};
		}
}


GraphChart.GraficoBE=function(TIPO,TEMA,TITULOBE,SUBTITULO,DATACOLLECTION,TOOLTIPS,VALUEFIELDNAME,TEXTFIELDNAME,ANGULO,GRAPHCHARTLEGENDABE,EVENTHANDLE){
	this.Tipo = TIPO;
	this.Tema=TEMA;
	this.Titulo=new Array();
	this.Titulo.Add=function(oTituloBE){
		this[this.length]=new Array();
		this[this.length-1]=oTituloBE;
	}
	this.Titulo.getAll=function(){
		var TitBE=new Array();
		if(this.length>0){
			for(var t=0;t<=this.length-1;t++){
				var oTituloBE = this[t];
				TitBE[t]={"text":oTituloBE.Text,"bold":oTituloBE.FontBold};
			}
			return TitBE;
		}
		return {"text":"Sin Titulos"};
	}
	this.DataCollection=new Array();
	this.DataCollection.Add=function(oDataBE){
		this[this.length]=new Array();
		this[this.length-1]=oDataBE;
	}
	this.DataCollection.getAll=function(){
		var DataBE=new Array();
		if(this.length>0){
			for(var t=0;t<=this.length-1;t++){
				var oDataBE = this[t];
				DataBE[t]={"text":oDataBE.TextField,"value":oDataBE.ValueField};
			}
			return DataBE;
		}
		return {"text":"","value":""};
	}
	
	this.ToolTips=TOOLTIPS;
	this.Angulo=ANGULO;
	this.LegendaBE=GRAPHCHARTLEGENDABE;
	this.EventHandle=EVENTHANDLE;
}


GraphChart.Enumerado=new Object();
GraphChart.Enumerado.Tipo={
	Pie3D:"pie",
	Barra3D:"serial"
}
GraphChart.Enumerado.Legenda=new Object();
GraphChart.Enumerado.Legenda.Posicion={
	Left:"left",
	Right:"right",
	Bottom:"bottom"
}

GraphChart.Enumerado.Tema={
	Light:"light"
}

/*---------------------------------------------------------Find GraphChart------------------------------------------------------*/


