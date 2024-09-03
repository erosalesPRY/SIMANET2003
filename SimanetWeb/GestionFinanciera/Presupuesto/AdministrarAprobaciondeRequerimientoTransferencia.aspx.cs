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
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Controladoras.Personal;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto
{
	/// <summary>
	/// Summary description for AdministrarAprobaciondeRequerimiento.
	/// </summary>
	public class AdministrarAprobaciondeRequerimientoTransferencia : System.Web.UI.Page,IPaginaBase
	{
		const string GRILLAVACIA="No existe Datos";

		#region Constantes
		const string KEYQIDTRANSFERENCIA="idTransf";
		const string KEYQIDCUENTACONTABLE="CuentaContable";
		const string KEYQIDCUENTACONTABLENOMBRE="CuentaContableNombre";
		const string KEYQMONTOREQUERIDO="MontoRQR";
		#endregion
		#region Atributos
		private int idTrasnferencia
		{	
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTRANSFERENCIA]);}
		}
		private string Cuentacontable
		{	
			get{return Page.Request.Params[KEYQIDCUENTACONTABLE].ToString();}
		}
		private string CuentacontableNombre
		{	
			get{return Page.Request.Params[KEYQIDCUENTACONTABLENOMBRE].ToString();}
		}
		private double Montorequerido
		{	
			get{return Convert.ToDouble(Page.Request.Params[KEYQMONTOREQUERIDO].ToString().Trim());}
		}

		#endregion
		#region Controles
			protected System.Web.UI.WebControls.Label lblPagina;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hidMes;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblConceptoContable;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblMonto;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					Helper.ReestablecerPagina(this);
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarCombos();
					this.LlenarGrilla();	
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Error);					
				}
				catch(Exception oException)
				{
					string msgb =oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		private DataTable ObtenerDatos()
		{
			//return (new CPresupuestoRequerimiento()).ConsultarRequerimientos(CNetAccessControl.GetIdUser());
			return (new CPresupuestoTransferencia()).AdministrarAprobaciondeRequerimientoTransferencia(this.idTrasnferencia,this.Cuentacontable);
		}

		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			if(dt!=null)
			{
				DataView dv = dt.DefaultView;
				//dv.RowFilter = Helper.ObtenerFiltro();
				grid.DataSource = dv;
				//grid.CurrentPageIndex =indicePagina;
				lblResultado.Visible = false;
			}
			else
			{
				//this.tblToolBar.Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}		
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarAprobaciondeRequerimientoTransferencia.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarAprobaciondeRequerimientoTransferencia.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarAprobaciondeRequerimientoTransferencia.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblConceptoContable.Text = this.Cuentacontable.ToString() + " - " +  this.CuentacontableNombre.ToString();
			this.lblMonto.Text = this.Montorequerido.ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarAprobaciondeRequerimientoTransferencia.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarAprobaciondeRequerimientoTransferencia.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarAprobaciondeRequerimientoTransferencia.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarAprobaciondeRequerimientoTransferencia.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarAprobaciondeRequerimientoTransferencia.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarAprobaciondeRequerimientoTransferencia.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				//eWorld.UI.NumericBox nb;
				HtmlInputText nb;
				string []nMeses ={"ENE","FEB","MARZ","ABR","MAY","JUN","JUL","AGOS","SET","OCT","NOV","DIC"}; 

				e.Item.Attributes.Add("idCentroCosto",dr["idCentroCosto"].ToString());

				if ((Convert.ToInt32(dr["IdTipoMov"].ToString())==1)||(Convert.ToInt32(dr["IdTipoMov"].ToString())==4))
				{
					e.Item.Cells[0].Text = dr["NombreCentroCosto"].ToString();
					e.Item.Cells[0].ToolTip= dr["NroCentroCosto"].ToString() + " " + dr["idTransferencia"].ToString();

					for(int i=0;i<=nMeses.Length-1;i++)
					{
						Double Monto =  Convert.ToDouble(dr[Utilitario.Helper.ObtenerNombreMes(i+1,SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto)].ToString());
						e.Item.Cells[i+1].Text = Monto.ToString(Utilitario.Constantes.FORMATODECIMAL4);
						e.Item.Cells[i+1].Font.Bold=true;
						e.Item.Cells[i+1].Attributes.Add("align","right");
					}
				}
				else if ((Convert.ToInt32(dr["IdTipoMov"].ToString()) == 2) ||(Convert.ToInt32(dr["IdTipoMov"].ToString()) == 3))
				{
					e.Item.CssClass = "ItemGrillaEdit";
					for(int i=0;i<=nMeses.Length-1;i++)
					{
						nb = new  HtmlInputText();
						nb.ID = nMeses[i].ToString();
						nb.Style.Add("width","100%");
						nb.Style.Add("background","Transparent");
						nb.Style.Add("border","none");
						nb.Attributes.Add("class","normaldetalle");
						nb.Style.Add("border","none");
						nb.Attributes.Add("align","right");
						string NombreCampoMes = Utilitario.Helper.ObtenerNombreMes(i+1,SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto);
						Double Monto =  Convert.ToDouble(dr[NombreCampoMes].ToString());
						//Atributos
						nb.Attributes.Add("idMovTransferencia",dr["id"+ NombreCampoMes].ToString());
						nb.Attributes.Add("idTransferencia",dr["idTransferencia"].ToString());
						nb.Attributes.Add("ViejoValor",Monto.ToString());

						nb.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnKeydown.ToString(),"MoverPuntero()");
						nb.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnBlur.ToString(),"GridControl_Desenfocar()");
						nb.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnFocus.ToString(),"GridControl_Alenfocar()");
							
						nb.Value = Monto.ToString();
						e.Item.Cells[i+1].Controls.Add(nb);
					}
				}
				
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
