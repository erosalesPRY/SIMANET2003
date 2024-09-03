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
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Configuration;



namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for AdministrarFichaCovid.
	/// </summary>
	public class AdministrarFichaCovid : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.TextBox txtNroDoc;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtApellidosyNombres;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HIdTipoBusqueda;
		protected System.Web.UI.WebControls.Button btnFind;
		protected System.Web.UI.WebControls.Label lblResultado;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Page.GetPostBackEventReference(this, "MyEventArgumentName");

			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarGrilla();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Pruebas COVID", this.ToString(),"Se consultó El Listado de resumen de ingreso por area.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina();
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
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemCreated);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members


		DataTable ObtenerDatos()
		{
			string  Valor;
			Valor=((this.HIdTipoBusqueda.Value=="1")?this.txtNroDoc.Text:this.txtApellidosyNombres.Text);
			return (new CAdministrarTrabajadorPatogenos()).ListarTodosGrilla(Convert.ToInt32(this.HIdTipoBusqueda.Value),Valor);			
		}


		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();				
			try
			{
				grid.DataSource = dt;
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
			// TODO:  Add AdministrarFichaCovid.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarFichaCovid.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarFichaCovid.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarFichaCovid.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			//onfocus
			this.txtNroDoc.Attributes.Add(SIMA.Utilitario.Enumerados.EventosJavaScript.OnFocus.ToString(),"FindForCtrl(this)");
			this.txtApellidosyNombres.Attributes.Add(SIMA.Utilitario.Enumerados.EventosJavaScript.OnFocus.ToString(),"FindForCtrl(this)");

			this.txtNroDoc.Attributes.Add(SIMA.Utilitario.Enumerados.EventosJavaScript.OnKeydown.ToString(),"EjecutarQuery(this)");
			this.txtApellidosyNombres.Attributes.Add(SIMA.Utilitario.Enumerados.EventosJavaScript.OnKeydown.ToString(),"EjecutarQuery(this)");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarFichaCovid.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarFichaCovid.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarFichaCovid.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarFichaCovid.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarFichaCovid.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void btnFind_Click(object sender, System.EventArgs e)
		{			
				LlenarGrilla();
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
						tc.Controls.Add(new LiteralControl("NRO DOCUMENTO"));
					}
					else if(i==1)
					{
						tc.RowSpan=2;
						tc.Controls.Add(new LiteralControl("APELLIDOS Y NOMBRES"));
					}
					else if(i==2)
					{
						tc.RowSpan=2;
						tc.Controls.Add(new LiteralControl("VIGENCIA"));
					}
/*					else if((i==3)|| (i==4))
					{
						tc.Visible=false;						
					}*/
					di.Cells.Add(tc);
				}
				DataGrid dg = (DataGrid)sender;
				Table t = (Table)dg.Controls[0];
				t.Rows.Add(di);
		
			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

			if(e.Item.ItemType==ListItemType.Header)
			{
				for(int i=0;i<=grid.Columns.Count-1;i++)
				{
					if((i==0)||(i==1)||(i==2))
					{
						e.Item.Cells[i].Visible=false;
					}
				}
			}	
			else if((e.Item.ItemType==ListItemType.Item)||(e.Item.ItemType==ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if(dr["FechaVigencia"].ToString()=="NO AUTORIZADO")
				{
					e.Item.Cells[0].Style.Add("text-decoration","line-through");
					e.Item.Cells[1].Style.Add("text-decoration","line-through");
				}

				string NroDNI=dr["NroDNI"].ToString();

				TextBox tbx = (TextBox) e.Item.Cells[2].FindControl("txtFechaV");

				tbx.Attributes.Add("NroDNI",NroDNI);
				tbx.Text = ((dr["FechaVigencia"].ToString().Length==0)? DateTime.Now.ToShortDateString():dr["FechaVigencia"].ToString()) ;
				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

			}

		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
