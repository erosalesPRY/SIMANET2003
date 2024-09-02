using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Reflection;


namespace SIMA.SimaNetWeb.General
{
	public class ControlPopupGrid : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl CellContextGrid;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFormula;
	
		public string CampoA{
			get{return Page.Request.Params["CA"].ToString();}
		}
		public string CampoB
		{
			get{return Page.Request.Params["CB"].ToString();}
		}
		public string CampoC
		{
			get{return Page.Request.Params["CC"].ToString();}
		}
		
		public string NomCtrlText
		{
			get{return Page.Request.Params["NomCtrlText"].ToString();}
		}


		public string NomCtrlValue
		{
			get{return Page.Request.Params["NomCtrlValue"].ToString();}
		}

		public string AssemblyInf
		{
			get{return Page.Request.Params["AsseInf"].ToString();}
		}
	
		
		public string LstCampos
		{
			get{return Page.Request.Params["lstField"].ToString();}
		}


		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{

				this.CrearGrilla();
				//this.LlenarGrilla();
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		public void CrearGrilla(){
			DataTable dtData = CallSourceDataFromAssembly();
			string []LstCampos = this.LstCampos.Replace("{","").Replace("}","").Split(';');
			HtmlTable Grid = Helper.CrearHtmlTabla(dtData.Rows.Count,LstCampos.Length);

			Grid.ID="Grid";
			int NroCell =0;
			foreach(string attr in LstCampos)
			{
				string []attrCol = attr.Split(':');
				Grid.Rows[0].Cells.Remove(Grid.Rows[0].Cells[NroCell]);
				Grid.Rows[0].Cells.Add(new HtmlTableCell("th"));
				Grid.Rows[0].Cells[NroCell].InnerText=attrCol[0].ToString();
				Grid.Rows[0].Cells[NroCell].Attributes.Add("class","HeaderGrilla");
				NroCell++;
			}

			
			int NroRow=1;
			foreach(DataRow dr in dtData.Rows){
				NroCell=0;
				foreach(string attr in LstCampos)
				{
					string []attrCol = attr.Split(':');
					Grid.Rows[NroRow].Cells[NroCell].InnerText=dr[attrCol[1].ToString()].ToString();
					Grid.Rows[NroRow].Cells[NroCell].Attributes.Add("align","left" );
				

					NroCell++;
				}
				Grid.Rows[NroRow].Attributes.Add("class",((NroRow%2==0)?"ItemGrilla":"Alternateitemgrilla"));
					
				Grid.Rows[NroRow].Attributes.Add("onmouseover","CambiarColorPasarMouse(this, true);");
				Grid.Rows[NroRow].Attributes.Add("onmouseout","CambiarColorPasarMouse(this, false);");

				string Cadena="CambiarColorSeleccion(this,'Grid','" + NroRow +"'); " ;
				string CamposA = LstCampos[0].Split(':')[1];
				string CamposB = LstCampos[1].Split(':')[1];

				string OnEvent = "OnSelectedRow('" + this.NomCtrlValue + "','" + dr[CamposA].ToString()+ "','" + this.NomCtrlText + "','" + dr[CamposB].ToString()+ "');";	

				Grid.Rows[NroRow].Attributes.Add("onclick",Cadena+OnEvent);
				
				NroRow++;
			}

		CellContextGrid.Controls.Add(Grid);
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			//DataTable dtData = CallSourceDataFromAssembly();
			/*if(dtData!=null)
			{
				grid.DataSource = dtData;
			}
			else
			{
				grid.DataSource = dtData;
			}
			grid.DataBind();*/
		}

		public DataTable CallSourceDataFromAssembly()
		{
			string []ArrAssembly = this.AssemblyInf.Split('.');
			string strMetodo =ArrAssembly[ArrAssembly.Length-1].ToString();

			ArrayList arrNameSpace = new ArrayList(ArrAssembly);
			arrNameSpace.RemoveAt(ArrAssembly.Length-1);

			string[] myStrArray =(string[]) arrNameSpace.ToArray(typeof(string));
			string strNameSpace=String.Join(".",myStrArray);

			//Elabora el asembly
			string PathAssemblyControler=Page.Request.PhysicalApplicationPath + @"bin\SIMA.Controladoras.dll";
			Assembly assembly = Assembly.LoadFile(PathAssemblyControler);

			Type type = assembly.GetType(strNameSpace);
			if (type != null)
			{
				MethodInfo methodInfo = type.GetMethod(strMetodo);
				if (methodInfo != null)
				{
					DataTable dt1=null;
					ParameterInfo[] parameters = methodInfo.GetParameters();
					object classInstance = Activator.CreateInstance(type, null);
					//if (parameters.Length == 0)
					{
						dt1=(DataTable)methodInfo.Invoke(classInstance, null);
					}
					//else
					//{
						//object[] parametersArray = new object[] {2016,2,15};
					//	object[] parametersArray = ListadeValores();
					//	dt1=(DataTable) methodInfo.Invoke(classInstance, parametersArray);
					//}
					if((dt1!=null)&&(dt1.Rows.Count>0))
					{
						return dt1;
					}

				}
			}
			return null;
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ControlPopupGrid.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ControlPopupGrid.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ControlPopupGrid.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ControlPopupGrid.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ControlPopupGrid.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ControlPopupGrid.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ControlPopupGrid.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ControlPopupGrid.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ControlPopupGrid.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ControlPopupGrid.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;			
				e.Item.Cells[0].Text= drv[this.CampoA].ToString();
				e.Item.Cells[1].Text= drv[this.CampoB].ToString();

				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,"OnSelectedRow('" + this.NomCtrlValue + "','" + drv[this.CampoC].ToString()+ "','" + this.NomCtrlText + "','" + drv[this.CampoB].ToString()+ "');");
			}
		}
	}
}
