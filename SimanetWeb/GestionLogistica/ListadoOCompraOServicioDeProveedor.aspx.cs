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
using SIMA.Controladoras.GestionLogistica;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Configuration;


namespace SIMA.SimaNetWeb.GestionLogistica
{
	/// <summary>
	/// Summary description for ListadoOCompraOServicioDeProveedor.
	/// </summary>
	public class ListadoOCompraOServicioDeProveedor : System.Web.UI.Page, IPaginaBase
	{
		protected projDataGridWeb.DataGridWeb grid;
		const string KEYIDDOCUMENTO="Documento";
		const string KEYIDESTADO="Estado";
		const string KEYIDPERIODO="Periodo";
		const string KEYIDMES="Mes";
		const string KEYIDMONEDA="Moneda";
		const string KEYIDRUC="Ruc";
		const string KEYIDTITULO="Titulo";
		const string KEYIDRAZONSOCIAL="Razon";
		const string KEYIDIMPORTE="Importe";
		const string KEYIDTOTALMONEDA="TotalMoneda";


		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label LblAño;
		protected System.Web.UI.WebControls.Label Lbl;
		protected System.Web.UI.WebControls.Label LblEstado;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label LblProveedor;
		protected System.Web.UI.WebControls.Label LblImporte;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label LblMoneda;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label LblTotal;
		protected System.Web.UI.WebControls.Label LblDocumento;
		protected System.Web.UI.WebControls.Label LblMes;
		protected System.Web.UI.WebControls.Label Label1;
		
		private string Documento
		{
			get{return (Page.Request.Params[KEYIDDOCUMENTO]); }
		}
		private string Estado
		{
			get{return (Page.Request.Params[KEYIDESTADO]); }
		}
		private int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYIDPERIODO]); }
		}
		private int Mes
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYIDMES]); }
		}
		private string Moneda
		{
			get{return (Page.Request.Params[KEYIDMONEDA]); }
		}
		private string Ruc
		{
			get{return (Page.Request.Params[KEYIDRUC]); }
		}
		private string Titulo
		{
			get{return (Page.Request.Params[KEYIDTITULO]); }
		}
		private string Razon
		{
			get{return (Page.Request.Params[KEYIDRAZONSOCIAL]); }
		}
		private string Importe
		{
			get{return (Page.Request.Params[KEYIDIMPORTE]); }
		}
		private string TotalMoneda
		{
			get{return (Page.Request.Params[KEYIDTOTALMONEDA]); }
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
					this.LlenarDatos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Becados", this.ToString(),"Se consultó El Listado de las Capacitaciones en el Extranjero.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina();
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

		public void LlenarGrilla()
		{
			CResumenOCompraOServicio oCResumenOCompraOServicio = new CResumenOCompraOServicio();
			DataTable dtResumen = oCResumenOCompraOServicio.ListarOC_OS(this.Documento,this.Estado,this.Periodo,this.Mes,this.Moneda,this.Ruc);

			if(dtResumen!=null)
			{
				grid.DataSource = dtResumen;

			}
			else
			{
				grid.DataSource = dtResumen;
			}
			
			try
			{
				grid.DataBind();
			}
			catch (Exception a)
			{
				string b = a.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
			if(this.Estado=="PEN")
			{
				grid.Columns[4].Visible=false;
				grid.Columns[9].Visible=false;
			}
			else if(this.Estado=="CAN"){
				grid.Columns[2].Visible=false;
				grid.Columns[3].Visible=false;
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ListadoOCompraOServicioDeProveedor.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ListadoOCompraOServicioDeProveedor.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ListadoOCompraOServicioDeProveedor.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.LblDocumento.Text=this.Titulo;
			this.LblMoneda.Text=this.Moneda;
			this.LblEstado.Text=this.Estado;
			this.LblAño.Text=this.Periodo.ToString();
			this.LblMes.Text= Helper.ObtenerNombreMes(this.Mes,SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto);
			this.LblProveedor.Text=this.Razon.ToString().Replace("[A]","&");
			this.LblImporte.Text=this.Importe;
			this.LblTotal.Text=this.TotalMoneda;
		}

		public void LlenarJScript()
		{
			// TODO:  Add ListadoOCompraOServicioDeProveedor.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ListadoOCompraOServicioDeProveedor.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ListadoOCompraOServicioDeProveedor.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ListadoOCompraOServicioDeProveedor.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ListadoOCompraOServicioDeProveedor.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ListadoOCompraOServicioDeProveedor.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		TableCell ocell=null;
		int RowSpan =1;
		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				e.Item.Cells[0].Visible=false;
			}
			else if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				e.Item.Cells[9].Text = Convert.ToDouble(e.Item.Cells[9].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4); 

					if(ocell==null)
					{
						ocell = e.Item.Cells[0];
					}
					else{
						if(ocell.Text!=e.Item.Cells[0].Text)
						{
							ocell.RowSpan=RowSpan;
							ocell = e.Item.Cells[0];
							RowSpan=1;
						}
						else
						{
							e.Item.Cells[0].Visible=false;
							RowSpan ++;		
						}
				}
			}
		}

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
				for(int i=0;i<=grid.Columns.Count-1;i++)
				{
					TableCell tc = new TableCell();
					if(i==0)
					{
						tc.RowSpan=2;
						//tc.Style.Add("width","25%");
						tc.Controls.Add(new LiteralControl("OC/OS"));
						di.Cells.Add(tc);
					}
					else if(i==1)
					{
						tc.ColumnSpan=9;
						tc.Text = "DATOS DE LA FACTURA";
						di.Cells.Add(tc);
					}
				}
				DataGrid dg = (DataGrid)sender;
				Table t = (Table)dg.Controls[0];
				t.Rows.Add(di);
			}
		}
	}
}
