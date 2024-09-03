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
	/// Summary description for ListarMaterialPorAlmacenValedeSalida.
	/// </summary>
	public class ListarMaterialPorAlmacenValedeSalida : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{

		protected projDataGridWeb.DataGridWeb gridMat;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtNroVale;
		protected System.Web.UI.WebControls.TextBox txtFechaEmision;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.Label lblTitulo;


		const string KEYQNROVALSAL = "NroValSal";
		const string KEYQCODALM = "CodAlm";
		const string KEYQCODCEO = "CodCeo";
		const string KEYQDESVALSAL = "DesValSal";
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodCentro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroValSal;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodAlmacen;
		const string KEYQFECEMS = "FEms";


		public string NroValeSalida
		{
			get{return Page.Request.Params[KEYQNROVALSAL].ToString();}
		}
		public string CodigoAlmacen
		{
			get{return Page.Request.Params[KEYQCODALM].ToString();}
		}

		public string CodigoCentro
		{
			get{return Page.Request.Params[KEYQCODCEO].ToString();}
		}
		public string Descripcion
		{
			get{return Page.Request.Params[KEYQDESVALSAL].ToString();}
		}

		public string FechaDeEmision
		{
			get{return Page.Request.Params[KEYQFECEMS].ToString();}
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
			this.gridMat.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridMat_ItemCreated);
			this.gridMat.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridMat_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		DataTable ObtenerDatos()
		{
			return(new CCCTT_ValedeSalida()).ListarDetalle(this.CodigoCentro,this.NroValeSalida,this.CodigoAlmacen);
		}

		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.RowFilter    = Utilitario.Helper.ObtenerFiltro();
				gridMat.DataSource = dv;
			}
			else
			{
				gridMat.DataSource = dt;
			}
			
			try
			{
				gridMat.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				gridMat.CurrentPageIndex = 0;
				gridMat.DataBind();
			}								
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.txtNroVale.Text = this.NroValeSalida;
			this.txtObservacion.Text = this.Descripcion;
			this.txtFechaEmision.Text = this.FechaDeEmision;

			this.hCodCentro.Value = this.CodigoCentro;
			this.hCodAlmacen.Value = this.CodigoAlmacen;
			this.hNroValSal.Value = this.NroValeSalida;

		}

		public void LlenarJScript()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ListarMaterialPorAlmacenValedeSalida.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void gridMat_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				for(int i=0;i<=3;i++){
					e.Item.Cells[i].Visible=false;
				}
				e.Item.Cells[7].Visible=false;
			}
			else if((e.Item.ItemType == ListItemType.Item)||(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],gridMat.CurrentPageIndex,gridMat.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				if(Convert.ToInt32( dr["CantPorReg"].ToString()).Equals(0))
				{
					for(int i=0;i<=e.Item.Cells.Count-1;i++)
					{
						e.Item.Cells[i].Style.Add("text-decoration","line-through");
						e.Item.Cells[i].Style.Add("color","#696969");
					}
				}
				else
				{
					if(dr["SubDet"].ToString().Equals("1"))//Mostrar la pantalla de detalle para su registro detallado
					{
						e.Item.Attributes.Add(SIMA.Utilitario.Enumerados.EventosJavaScript.Ondblclick.ToString(),"ListarMaterialPorAlmacenValedeSalida.DetalleMaterial('" + dr["cod_aus"].ToString() + "','" + this.CodigoCentro  + "','" + this.CodigoAlmacen + "','"+ this.NroValeSalida + "','" + dr["Cod_Mat"].ToString()  + "')");
					}
					else
					{//Registrar directamente
						e.Item.Attributes.Add(SIMA.Utilitario.Enumerados.EventosJavaScript.Ondblclick.ToString(),"DetalleStockMaterialPorArea.Confirmar('" + this.CodigoCentro + "','" + this.CodigoAlmacen + "','"+ this.NroValeSalida + "','" + dr["Cod_Mat"].ToString() + "','" +  dr["CantEnVSM"].ToString() + "');");
					}
				}
				//Icono de aplicaciones
				if(dr["SUBDET"].ToString().Equals("1"))
				{
					e.Item.Cells[1].Attributes.Add("class","cellClass");
				}

				e.Item.Cells[0].ForeColor=Color.Blue;
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[4].Style.Add("background","#ffcc66");
				
				
			}
		}

		string []titHeader={"NRO","CODIGO","DESCRIPCION","UND<BR>MED.",};
		private void gridMat_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				
				DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
				for(int i=0;i<=gridMat.Columns.Count-1;i++)
				{
					TableCell tc = new TableCell();
					if((i>=0)&&(i<=3))
					{
						tc.RowSpan=2;
						tc.Controls.Add(new LiteralControl(titHeader[i]));
					}
					else if(i==4)
					{
						string TITULO="CANTIDAD";
						tc.ColumnSpan=3;
						tc.Controls.Add(new LiteralControl(TITULO));
					}
					else if((i>4 && i<=6))
					{
						tc.Visible=false;
					}
					else if(i==7){
						tc.RowSpan=2;
						tc.Controls.Add(new LiteralControl("PREC.<BR>PROM."));
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
