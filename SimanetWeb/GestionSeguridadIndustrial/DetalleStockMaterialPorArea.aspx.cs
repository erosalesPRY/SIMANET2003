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
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using System.Drawing;


namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for DetalleStockMaterialPorArea.
	/// </summary>
	public class DetalleStockMaterialPorArea : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdAgregarVale;
		protected System.Web.UI.WebControls.TextBox txtBuscar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGCodItem;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdEntregaMaterialPorArea;

		const string KEYQIDAREA="IdArea";
		const string KEYIDTAB = "IdTab";

		public string CodArea
		{
			get{return Page.Request.Params[KEYQIDAREA].ToString();}
		}

		public string IdTabSelected
		{
			get{return Page.Request.Params[KEYIDTAB].ToString();}
		}

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
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		DataTable ObtenerDatos()
		{
			return(new CCCTT_StockMaterialPorArea()).Resumen(this.CodArea);
		}
		public void LlenarGrilla()
		{
			DataTable dt =  this.ObtenerDatos();
			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.RowFilter    = Utilitario.Helper.ObtenerFiltro();
				grid.DataSource = dv;
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
			// TODO:  Add DetalleStockMaterialPorArea.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleStockMaterialPorArea.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleStockMaterialPorArea.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			grid.ID = "Grid" + this.IdTabSelected;
			this.txtBuscar.ID = "txt"+ this.IdTabSelected;
			//this.hGCodItem.ID="hGCodItem"+this.IdTabSelected;
		}

		public void LlenarJScript()
		{
			this.cmdAgregarVale.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"DetalleStockMaterialPorArea.AgregarVSM()");
			this.cmdEntregaMaterialPorArea.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),Utilitario.Helper.HistorialIrAdelantePersonalizado("")+ ";AdministrarStockMaterialPorArea.EntregarMaterial('" + this.CodArea + "')");

			//this.cmdEliminar.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"DetalleStockMaterialPorArea.EliminarItemStock()");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleStockMaterialPorArea.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleStockMaterialPorArea.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleStockMaterialPorArea.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleStockMaterialPorArea.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleStockMaterialPorArea.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add DetalleStockMaterialPorArea.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add DetalleStockMaterialPorArea.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleStockMaterialPorArea.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add DetalleStockMaterialPorArea.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalleStockMaterialPorArea.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add DetalleStockMaterialPorArea.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleStockMaterialPorArea.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleStockMaterialPorArea.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleStockMaterialPorArea.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleStockMaterialPorArea.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Header))
			{
			
				for(int c=0;c<=4;c++)
				{
					e.Item.Cells[c].Style.Add("display","none");
				}
			}
			if((e.Item.ItemType == ListItemType.Item)||(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Attributes.Add(SIMA.Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(), Helper.HistorialIrAdelantePersonalizado("") + ";DetalleStockMaterialPorAreaValeSalida.ListarDetalle('" + this.CodArea  +"','" + dr["Cod_Mat"].ToString() +"','" + dr["CantEnVSM"].ToString() +"')");
				e.Item.Cells[0].ForeColor=Color.Blue;
				e.Item.Cells[0].Font.Underline=true;
				string  IdhCtrl = "hGCodItem" + this.IdTabSelected;
				//Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto(IdhCtrl,dr["Cod_Item"].ToString()),"DetalleStockMaterialPorArea.rowSelect=this;");
				//Helper.SeleccionarItemGrillaOnClickMoverRaton(e,"DetalleStockMaterialPorArea.rowSelect=this;");
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				/*COLUMNA D VALE DE SALIDA*/
				e.Item.Cells[4].Style.Add("background","YELLOW");
				e.Item.Cells[5].Style.Add("background","#fff8dc");
				e.Item.Cells[7].Font.Bold=true;
				if (Convert.ToInt32(dr["NroItems"].ToString())>=2)
				{
					e.Item.Cells[3].Style.Add("BACKGROUND-IMAGE","url(/simanetWeb/imagenes/Navegador/File.gif); BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: center center");
					e.Item.Cells[3].Font.Bold=true;
				}
				//Activa la alerta para reabastecimiento del stock
				if(Convert.ToInt32(dr["StockActual"].ToString())<=Convert.ToInt32(dr["StockMinimo"].ToString()))
				{
					e.Item.Cells[e.Item.Cells.Count-1].Attributes.Add("class","AlertaStock");
					e.Item.Cells[e.Item.Cells.Count-1].ForeColor= System.Drawing.Color.Red;
				}

			}
		}
		
		string []titHeader = {"Nro","COD MATERIAL","NOMBRE MATERIAL","Nro<BR>Item(s)","CANT<br>IN VSM."};

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				
				DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
				for(int i=0;i<=grid.Columns.Count-1;i++)
				{
					TableCell tc = new TableCell();
					if((i>=0)&&(i<=4))
					{
						tc.RowSpan=2;
						tc.Controls.Add(new LiteralControl(titHeader[i]));
					}
					else if(i==5)
					{
						string TITULO="CANTIDAD";
						tc.ColumnSpan=3;
						tc.Controls.Add(new LiteralControl(TITULO));
					}
					else if((i>5 && i<=7))
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

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
