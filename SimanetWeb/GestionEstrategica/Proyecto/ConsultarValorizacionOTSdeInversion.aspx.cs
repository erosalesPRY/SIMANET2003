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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionEstrategica.PlanEstrategico;
using SIMA.Controladoras.GestionEstrategica.Proyecto;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.EntidadesNegocio.GestionEstrategica;
using SIMA.Controladoras.Proyectos;
using System.Configuration;

namespace SIMA.SimaNetWeb.GestionEstrategica.Proyecto
{
	/// <summary>
	/// Summary description for ConsultarValorizacionOTSdeInversion.
	/// </summary>
	public class ConsultarValorizacionOTSdeInversion : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.TextBox txtNroValorizacion;
		protected System.Web.UI.WebControls.TextBox txtNroOTs;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DataGrid gridManoObra;
		protected System.Web.UI.WebControls.DataGrid gridServicios;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtTotalMOB;
		protected System.Web.UI.WebControls.TextBox txtTotalSer;
		protected System.Web.UI.WebControls.TextBox txtTotalMat;
		protected System.Web.UI.WebControls.DataGrid gridMateriales;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtRTotalMOB;
		protected System.Web.UI.WebControls.TextBox txtRTotalSer;
		protected System.Web.UI.WebControls.TextBox txtRTotalMat;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
			
		const string KEYQCODIGOPC="CodPC";
		private string CodigoPC
		{
			get{return Page.Request.Params[KEYQCODIGOPC].ToString();}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
					this.LlenarJScript();
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}					// Put user code to initialize the page here
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
			this.gridMateriales.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridMateriales_ItemCreated);
			this.gridMateriales.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridMateriales_ItemDataBound);
			this.gridServicios.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridServicios_ItemCreated);
			this.gridServicios.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridServicios_ItemDataBound);
			this.gridManoObra.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridManoObra_ItemCreated);
			this.gridManoObra.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridManoObra_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		string val1,val2;

		public void LlenarGrillaMateriales()
		{
			val1 = this.txtTotalMat.Text.Trim().Replace(".","").Replace(" ","");
			val2 = this.txtRTotalMat.Text.Trim().Replace(".","").Replace(" ","");

			if( Convert.ToInt32(val1)==0 &&  Convert.ToInt32(val2)==0) return;

			DataTable dt=(new CProyectoValorizacionyOTs()).ListarMaterialesValorizacionOTs(this.txtNroValorizacion.Text);

			gridMateriales.DataSource = dt;
			try
			{
				gridMateriales.DataBind();
			}
			catch	
			{
				gridMateriales.DataBind();
			}		
		}
		public void LlenarGrillaManodeObra()
		{
			val1 = this.txtTotalMOB.Text.Trim().Replace(".","").Replace(" ","");
			val2 = this.txtRTotalMOB.Text.Trim().Replace(".","").Replace(" ","");
			if( Convert.ToInt32(val1)==0 &&  Convert.ToInt32(val2)==0) return;

			DataTable dt=(new CProyectoValorizacionyOTs()).ListarManodeObraValorizacionOTs(this.txtNroValorizacion.Text);
			gridManoObra.DataSource = dt;
			try
			{
				gridManoObra.DataBind();
			}
			catch	
			{
				gridManoObra.DataBind();
			}		
		}

		public void LlenarGrillaServicios()
		{
			val1 = this.txtTotalSer.Text.Trim().Replace(".","").Replace(" ","");
			val2 = this.txtRTotalSer.Text.Trim().Replace(".","").Replace(" ","");
			if( Convert.ToInt32(val1)==0 &&  Convert.ToInt32(val2)==0) return;

			DataTable dt=(new CProyectoValorizacionyOTs()).ListarServiciosValorizacionOTs(this.txtNroValorizacion.Text);
			gridServicios.DataSource = dt;
			try
			{
				gridServicios.DataBind();
			}
			catch	
			{
				gridServicios.DataBind();
			}		
		}

		public void LlenarGrilla()
		{
			LlenarGrillaMateriales();
			LlenarGrillaManodeObra();
			LlenarGrillaServicios();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarValorizacionOTSdeInversion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarValorizacionOTSdeInversion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarValorizacionOTSdeInversion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			ProyectoValorizacionOtsBE oProyectoValorizacionOtsBE = (ProyectoValorizacionOtsBE)(new CProyectoValorizacionyOTs()).ListarDetalleValorizacionOTs(this.CodigoPC);
			this.txtNroValorizacion.Text = oProyectoValorizacionOtsBE.NroValorzacion;
			this.txtNroOTs.Text = oProyectoValorizacionOtsBE.NroOTs;
			this.txtDescripcion.Text = oProyectoValorizacionOtsBE.Descripcion;
			this.txtFecha.Text = oProyectoValorizacionOtsBE.Fecha;
			/*TotalValorizacion*/
			this.txtTotalMOB.Text = oProyectoValorizacionOtsBE.TotalValMOB.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			this.txtTotalMat.Text = oProyectoValorizacionOtsBE.TotalValMAT.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			this.txtTotalSer.Text = oProyectoValorizacionOtsBE.TotalValSER.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			/*TotalReal*/
			this.txtRTotalMOB.Text = oProyectoValorizacionOtsBE.TotalRealMOB.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			this.txtRTotalMat.Text = oProyectoValorizacionOtsBE.TotalRealMAT.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			this.txtRTotalSer.Text = oProyectoValorizacionOtsBE.TotalRealSER.ToString(Utilitario.Constantes.FORMATODECIMAL4);
		}

		public void LlenarJScript()
		{
			this.txtRTotalMat.Style["text-align"]="right";
			this.txtRTotalMOB.Style["text-align"]="right";
			this.txtRTotalSer.Style["text-align"]="right";

			this.txtTotalMat.Style["text-align"]="right";
			this.txtTotalMOB.Style["text-align"]="right";
			this.txtTotalSer.Style["text-align"]="right";

			this.Label8.Style["text-align"]="center";
			this.Label9.Style["text-align"]="center";
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarValorizacionOTSdeInversion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarValorizacionOTSdeInversion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarValorizacionOTSdeInversion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarValorizacionOTSdeInversion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarValorizacionOTSdeInversion.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void gridMateriales_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				/*e.Item.Cells[0].Visible=false;
				e.Item.Cells[1].Visible=false;
				e.Item.Cells[2].Visible=false;*/
			}
			else if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//e.Item.Cells[3].Text = Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void gridServicios_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				/*e.Item.Cells[0].Visible=false;
				e.Item.Cells[1].Visible=false;
				e.Item.Cells[2].Visible=false;*/
			}
			else if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//e.Item.Cells[3].Text = Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}

		}

		private void gridManoObra_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				/*e.Item.Cells[0].Visible=false;
				e.Item.Cells[1].Visible=false;
				e.Item.Cells[2].Visible=false;*/
			}
			else if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text = Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//e.Item.Cells[4].Text = Convert.ToDouble(e.Item.Cells[4].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}

		}

		
		private void gridManoObra_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			/*if(e.Item.ItemType==ListItemType.Header)
			{
				DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
				for(int i=0;i<=gridMateriales.Columns.Count-1;i++)
				{
					TableCell tc = new TableCell();
					if((i == 0)||(i == 1)||(i == 2))
					{
						tc.RowSpan=2;
						tc.Text = ((i==0)?"CODIGO":((i==1)?"DESCRIPCION":"ESTIMACION"));
						di.Cells.Add(tc);
					}
					else if(i==3)
					{
						tc.ColumnSpan=2;
						tc.Text="IMPORTE OT.";
						di.Cells.Add(tc);
					}
				}
				DataGrid dg = (DataGrid)sender;
				Table t = (Table)dg.Controls[0];
				t.Rows.Add(di);
			}	*/			
		}

		private void gridServicios_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			/*if(e.Item.ItemType==ListItemType.Header)
			{
				DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
				for(int i=0;i<=gridServicios.Columns.Count-1;i++)
				{
					TableCell tc = new TableCell();
					if((i == 0)||(i == 1)||(i == 2))
					{
						tc.RowSpan=2;
						tc.Text = ((i==0)?"CODIGO":((i==1)?"DESCRIPCION":"ESTIMACION"));
						di.Cells.Add(tc);
					}
					else if(i==3)
					{
						tc.ColumnSpan=2;
						tc.Text="IMPORTE OT.";
						di.Cells.Add(tc);
					}
				}
				DataGrid dg = (DataGrid)sender;
				Table t = (Table)dg.Controls[0];
				t.Rows.Add(di);
			}	*/			
		}

		private void gridMateriales_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			/*if(e.Item.ItemType==ListItemType.Header)
			{
				DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
				for(int i=0;i<=gridMateriales.Columns.Count-1;i++)
				{
					TableCell tc = new TableCell();
					if((i == 0)||(i == 1)||(i == 2))
					{
						tc.RowSpan=2;
						tc.Text = ((i==0)?"CODIGO":((i==1)?"DESCRIPCION":"ESTIMACION"));
						di.Cells.Add(tc);
					}
					else if(i==3)
					{
						tc.ColumnSpan=2;
						tc.Text="IMPORTE OT.";
						di.Cells.Add(tc);
					}
				}
				DataGrid dg = (DataGrid)sender;
				Table t = (Table)dg.Controls[0];
				t.Rows.Add(di);
			}	*/			
		}
		
	}
}
