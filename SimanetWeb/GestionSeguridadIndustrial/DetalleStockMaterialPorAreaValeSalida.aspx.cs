using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.Personal;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using System.Drawing;

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for DetalleStockMaterialPorAreaValeSalida.
	/// </summary>
	public class DetalleStockMaterialPorAreaValeSalida : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdEliminar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGCodItem;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hAtendidos;

		const string KEYQCODMAT="CodMat";
		const string KEYQIDAREA="IdArea";
		const string KEYIDTAB = "IdTab";
		const string KEYQMONTOVSM = "MntVSM";

		public string CodArea
		{
			get{return Page.Request.Params[KEYQIDAREA].ToString();}
		}

		public string IdTabSelected
		{
			get{return Page.Request.Params[KEYIDTAB].ToString();}
		}
		public string CodigoMaterial
		{
			get{return Page.Request.Params[KEYQCODMAT].ToString();}
		}
	
		public string ImporteTotalVSM
		{
			get{return Page.Request.Params[KEYQMONTOVSM].ToString();}
		}

		int NroReg=0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Programación Personal Contratista", this.ToString(),"Se consultó El Listado de las programaciones de los contratistas",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina();
					this.LlenarDatos();
					this.LlenarGrilla();
					
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					Helper.MsgBox(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					Helper.MsgBox(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					Helper.MsgBox(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception oException)
				{
					string msg = oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
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
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemCreated);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		DataTable ObtenerDatos()
		{
			return(new CCCTT_StockMaterialPorArea()).Listar(this.CodArea);
		}
		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.RowFilter    = "COD_MAT='" + this.CodigoMaterial + "'";
				grid.DataSource = dv;
				NroReg =  dv.Count;
			}
			else
			{
				grid.DataSource = dt;
			}
			
			try
			{
				grid.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}						
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			grid.ID = "Grid_det" + this.IdTabSelected;
			//this.txtBuscar.ID = "txt_det"+ this.IdTabSelected;
			this.hGCodItem.ID="hGCodItem_det"+this.IdTabSelected;
			this.hAtendidos.ID="hAtendidos_det"+this.IdTabSelected;
		}

		public void LlenarJScript()
		{
			this.cmdEliminar.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"DetalleStockMaterialPorArea.EliminarItemStock()");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleStockMaterialPorAreaValeSalida.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Header))
			{
			
				for(int c=0;c<=5;c++)
				{
					e.Item.Cells[c].Style.Add("display","none");
				}
			}
			if((e.Item.ItemType == ListItemType.Item)||(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Attributes.Add(SIMA.Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(), "DetalleStockMaterialPorArea.DetalleMaterialStock('" + this.CodArea  +"','" + dr["Cod_Item"].ToString() +"')");
				e.Item.Cells[0].ForeColor=Color.Blue;
				e.Item.Cells[0].Font.Underline=true;

				string  IdhCtrl = "hGCodItem_det" + this.IdTabSelected;
				string  IdhAtendidos = "hAtendidos_det" + this.IdTabSelected;
				string strLstMetod = "DetalleStockMaterialPorAreaValeSalida.SetValueControls('"+ IdhAtendidos +"','" + dr["CantAtendida"].ToString() + "');"
							  + "DetalleStockMaterialPorAreaValeSalida.SetValueControls('"+ IdhCtrl +"','" + dr["Cod_Item"].ToString() + "');"
							  + "DetalleStockMaterialPorArea.rowSelect=this;"
							  + "DetalleStockMaterialPorAreaValeSalida.NameCtrlAtendido='" + IdhAtendidos + "'";

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,strLstMetod);
				/*COLUMNA D VALE DE SALIDA*/
				e.Item.Cells[5].Style.Add("background","YELLOW");
				e.Item.Cells[6].Style.Add("background","#fff8dc");
				e.Item.Cells[8].Font.Bold=true;
				//Activa la alerta para reabastecimiento del stock
				if(Convert.ToInt32(dr["StockActual"].ToString())<=Convert.ToInt32(dr["StockMinimo"].ToString()))
				{
					e.Item.Cells[e.Item.Cells.Count-1].Attributes.Add("class","AlertaStock");
					e.Item.Cells[e.Item.Cells.Count-1].ForeColor= System.Drawing.Color.Red;
				}
				//Conteo de registros que serviran para realizar un merge de la columa CVS
				
				if(NroReg>1){
					if(e.Item.ItemIndex==0)
					{
						e.Item.Cells[5].Text = this.ImporteTotalVSM;
						e.Item.Cells[5].RowSpan= NroReg; 
					}
					else
					{
						e.Item.Cells[5].Style.Add("display","none");
					}
				}
				
			}
		}

		string []titHeader = {"Nro","NRO VALE","COD MATERIAL","NOMBRE MATERIAL","TALLA","CANT<br>IN VSM."};

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				
				DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
				for(int i=0;i<=grid.Columns.Count-1;i++)
				{
					TableCell tc = new TableCell();
					if((i>=0)&&(i<=5))
					{
						tc.RowSpan=2;
						tc.Controls.Add(new LiteralControl(titHeader[i]));
					}
					else if(i==6)
					{
						string TITULO="CANTIDAD";
						tc.ColumnSpan=3;
						tc.Controls.Add(new LiteralControl(TITULO));
					}
					else if((i>6 && i<=8))
					{
						tc.Visible=false;
					}
					di.Cells.Add(tc);
				}
				DataGrid dg = (DataGrid)sender;
				Table t = (Table)dg.Controls[0];
				t.Rows.Add(di);
			}		
		}
	}
}
