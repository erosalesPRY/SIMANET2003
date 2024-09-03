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
	/// Summary description for ListadoMaterialDisponibleDeEntrega.
	/// </summary>
	public class ListadoMaterialDisponibleDeEntrega : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.TextBox txtBuscarMatEnt;
		protected System.Web.UI.WebControls.Label Label1;
		protected projDataGridWeb.DataGridWeb gridMatEnt;

		const string KEYQIDAREA="IdArea";
		protected System.Web.UI.WebControls.Label lblNombreArea;
	
		public string CodArea
		{
			get{return Page.Request.Params[KEYQIDAREA].ToString();}
		}


		const string KEYQCODPERSONA="CodPers";
		public string CodigoPersona
		{
			get{return Page.Request.Params[KEYQCODPERSONA].ToString();}
		}

		
		const string KEYQCODMAT="CodMat";
		public string CodigoMaterial
		{
			get{return ((Page.Request.Params[KEYQCODMAT]==null)?"":Page.Request.Params[KEYQCODMAT].ToString());}
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
			this.gridMatEnt.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridMatEnt_ItemCreated);
			this.gridMatEnt.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridMatEnt_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		DataTable ObtenerDatos()
		{
			//return(new CCCTT_StockMaterialEntrega()).Listar();
			return(new CCCTT_StockMaterialPorArea()).Listar(this.CodArea);
		}

		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				if(this.CodigoMaterial.Length>0)
				{
					DataView dv     = dt.DefaultView;
					dv.RowFilter    = "COD_MAT='" + this.CodigoMaterial + "'";
					gridMatEnt.DataSource = dv;
				}
				else{
					gridMatEnt.DataSource = dt;
				}
			}
			else
			{
				gridMatEnt.DataSource = dt;
			}
			
			try
			{
				gridMatEnt.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				gridMatEnt.CurrentPageIndex = 0;
				gridMatEnt.DataBind();
			}							
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ListadoMaterialDisponibleDeEntrega.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ListadoMaterialDisponibleDeEntrega.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ListadoMaterialDisponibleDeEntrega.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			EntidadesNegocio.General.AreaUsuariaBE oAreaUsuariaBE = (EntidadesNegocio.General.AreaUsuariaBE)(new CCCTT_StockMaterialPorArea()).DetalleArea("1",this.CodArea);
			lblNombreArea.Text = oAreaUsuariaBE.Nombre;
			
		}

		public void LlenarJScript()
		{
			this.txtBuscarMatEnt.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"(new System.Web.UI.WebControls.TextBoxFindInGrid(document.getElementById('txtBuscarMatEnt'),'gridMatEnt','2'));");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ListadoMaterialDisponibleDeEntrega.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ListadoMaterialDisponibleDeEntrega.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ListadoMaterialDisponibleDeEntrega.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ListadoMaterialDisponibleDeEntrega.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ListadoMaterialDisponibleDeEntrega.ValidarFiltros implementation
			return false;
		}

		#endregion


		private void gridMatEnt_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],gridMatEnt.CurrentPageIndex,gridMatEnt.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				
				e.Item.Attributes.Add(SIMA.Utilitario.Enumerados.EventosJavaScript.Ondblclick.ToString(),"DetalleMaterialDisponibledeEntrega.Ingresar('" + dr["Cod_Item"].ToString() + "','" + this.CodigoPersona + "','" + this.CodArea +"');");

			}
		}

		private void gridMatEnt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		string []titHeader = {"Nro","NRO VALE","COD MATERIAL","NOMBRE MATERIAL","TALLA","CANT<br>IN VSM."};
		private void gridMatEnt_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				
				DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
				for(int i=0;i<=gridMatEnt.Columns.Count-1;i++)
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
