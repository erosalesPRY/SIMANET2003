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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Drawing;
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for DetalleMaterialValedeSalidaxTalla.
	/// </summary>
	public class DetalleMaterialValedeSalidaxTalla : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCodMat;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtDesMat;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtCantEnVSM;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodItem;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodCeo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroAlmacen;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroValeSalida;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hModo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCantReg;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodTblTalla;

		const string KEYQIDAREA="IdArea";
		const string KEYQCODCEO = "CodCeo";
		const string KEYQCODALM = "CodAlm";
		const string KEYQNROVALSAL = "NroValSal";
		const string KEYQCODMAT="CodMat";
		const string KEYCODITEM = "CodItem";
		protected projDataGridWeb.DataGridWeb gridTalla;
		protected System.Web.UI.WebControls.Label Label4;

		public string CodigoCentro
		{
			get{return Page.Request.Params[KEYQCODCEO].ToString();}
		}
		public string CodigoAlmacen
		{
			get{return Page.Request.Params[KEYQCODALM].ToString();}
		}

		public string NroValeSalida
		{
			get{return Page.Request.Params[KEYQNROVALSAL].ToString();}
		}

		public string CodigoMaterial
		{
			get{return Page.Request.Params[KEYQCODMAT].ToString();}
		}

		public string CodigoItem
		{
			get{return ((Page.Request.Params[KEYCODITEM]==null)?"": Page.Request.Params[KEYCODITEM].ToString());}
		}
		public string CodArea
		{
			get{return Page.Request.Params[KEYQIDAREA].ToString();}
		}
	
		double CantPorRegistrar;

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
					this.CargarModoPagina();
					
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
			this.gridTalla.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridTalla_ItemCreated);
			this.gridTalla.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridTalla_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			hCodItem.Value = this.CodigoItem;
			hCodCeo.Value=this.CodigoCentro;
			hNroAlmacen.Value=this.CodigoAlmacen;
			hNroValeSalida.Value=this.NroValeSalida;
		}

		public void LlenarJScript()
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.ValidarFiltros implementation
			return false;
		}

		#endregion

		void CargarTBLs(int IdTbl)
		{
			gridTalla.DataSource= (new CCCTT_ValedeSalida()).ListarDetalleSubClasificacion(IdTbl.ToString(),this.CodArea,this.CodigoCentro,this.NroValeSalida,this.CodigoAlmacen,this.CodigoMaterial);
			gridTalla.DataBind();
		}

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			this.hModo.Value = Page.Request.QueryString[Constantes.KEYMODOPAGINA].ToString();
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.LlenarDatos();
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
			}						
		}

		

		public void CargarModoNuevo()
		{
			StockMaterialBE oStockMaterialBE = (StockMaterialBE)(new CCCTT_ValedeSalida()).DetalleMaterial(this.CodigoCentro,this.NroValeSalida,this.CodigoAlmacen,this.CodigoMaterial);
			this.txtCodMat.Text = oStockMaterialBE.CodMat;
			this.txtDesMat.Text = oStockMaterialBE.DescripcionMat;
			this.txtCantEnVSM.Text	= oStockMaterialBE.CantEntregada.ToString();
			this.hCantReg.Value = oStockMaterialBE.CantRegistrada.ToString();
			this.hCodTblTalla.Value=oStockMaterialBE.CodTblRel.ToString();
			CantPorRegistrar=oStockMaterialBE.CantPorReg;

			this.CargarTBLs(oStockMaterialBE.CodTblRel);
		}

		public void CargarModoModificar()
		{
			/*StockMaterialBE oStockMaterialBE = (StockMaterialBE)(new CCCTT_StockMaterialPorArea()).DetalleMaterialStock(this.CodArea,this.CodigoItem);
			this.txtCodMat.Text = oStockMaterialBE.CodMat;
			this.txtDesMat.Text = oStockMaterialBE.DescripcionMat;
			this.txtCantEnVSM.Text= oStockMaterialBE.CantEnVSM.ToString();
			this.hCantReg.Value = oStockMaterialBE.CantRegistrada.ToString();
			this.hCodTblTalla.Value=oStockMaterialBE.CodTblRel.ToString();
			this.CargarTBLs(oStockMaterialBE.CodTblRel);

			//ListItem litem = this.ddlTalla.Items.FindByValue(oStockMaterialBE.IdTalla.ToString());
			//if(litem!=null){litem.Selected=true;}

			hCodItem.Value = oStockMaterialBE.CodItem;
			hCodCeo.Value=oStockMaterialBE.CodCeo;
			hNroAlmacen.Value=oStockMaterialBE.CodAlm;
			hNroValeSalida.Value=oStockMaterialBE.NroVsm;
			//bLOQUEA LA EDICION SI EL MATERIAL YA CUENTA CON INFORMACION DE ATENCION
			if(oStockMaterialBE.CantAtendida>0)
			{
			
			}*/
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleMaterialValedeSalidaxTalla.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void gridTalla_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Header))
			{
				e.Item.Cells[0].Style.Add("display","none");
				e.Item.Cells[1].Style.Add("display","none");
			}
			if((e.Item.ItemType == ListItemType.Item)||(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],gridTalla.CurrentPageIndex,gridTalla.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				e.Item.Cells[1].Font.Bold=true;
				e.Item.Cells[1].Attributes.Add("IDTALLA",dr["COD_ITEM"].ToString());
			}
			else if(e.Item.ItemType == ListItemType.Footer){
				e.Item.Cells[0].Font.Bold=true;
				e.Item.Cells[0].Text="POR REGISTRAR:";
				e.Item.Cells[0].ColumnSpan=3;
				e.Item.Cells[1].Style.Add("DISPLAY","none");
				e.Item.Cells[2].Style.Add("DISPLAY","none");
				
				e.Item.Cells[3].Text=CantPorRegistrar.ToString();
				e.Item.Cells[3].Font.Bold=true;
			}
		}
		
		string []titHeader = {"Nro","DESCRIPCION"};
		private void gridTalla_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				
				DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
				for(int i=0;i<=gridTalla.Columns.Count-1;i++)
				{
					TableCell tc = new TableCell();
					if((i>=0)&&(i<=1))
					{
						tc.RowSpan=2;
						tc.Controls.Add(new LiteralControl(titHeader[i]));
					}
					else if(i==2)
					{
						string TITULO="CANTIDAD";
						tc.ColumnSpan=2;
						tc.Controls.Add(new LiteralControl(TITULO));
					}
					else if((i==3))
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
