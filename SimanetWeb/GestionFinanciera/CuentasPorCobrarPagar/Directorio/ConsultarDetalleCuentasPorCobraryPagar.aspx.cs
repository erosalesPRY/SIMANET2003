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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;


namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio
{
	/// <summary>
	/// Summary description for ConsultarDetalleCuentasPorCobraryPagar.
	/// </summary>
	public class ConsultarDetalleCuentasPorCobraryPagar : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string KEYQIDTIPOCUENTA = "IdTipoCuenta";
			const string KEYQIDCUENTAPORCOBRARPAGAR = "IdCuenta";
			const string KEYQIDSUBCUENTAPORCOBRARPAGAR = "IdSubCuenta";
			const string KEYQIDCENTROOPERATIVO= "IdCentroOperativo";
			const string KEYQDESCRIPCION = "Descripcion";
			const string KEYQDESCRIPCIONCUENTA = "Cuenta";
			const string KEYQDESCRIPCIONSUBCUENTA = "SubCuenta";
			const string KEYQRAZONSOCIAL="Rsocial";
			const string KEYQIDTIPOCONSULTA="tipoConsulta";
			const string KEYQNRORUC="ruc";
			const string KEYQENTIDAD = "idEntidad";
			const string KEYQNRODOCUMENTO = "Ndoc";
			const string KEYQIDAJUSTE = "idAjuste";

			const string KEYQFLAGDIRECTORIO= "FlagDirectorio";
			const string URLDETALLEXCEL="ExportarDetalleExcelAnticiposProveedores.aspx?";
			const int IDANTICIPOPROVEEDOR = 3;
			const string INTERESES="1";
			const string OTROS="2";
			const string PRESTAMOSTERCEROS="3";
			double totalAbono;
			double totalCargo;
			//Otros
			const string GRILLAVACIA ="No existe ninguna SubCuenta";  
			const string TXTOBSERVACION ="txtConcepto";  
			const string TOTALIZA ="Totaliza";
		#endregion

		#region Atributos
			protected int idCentroOperativo{get{return Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]);}}
			protected int idTipodeCuenta{get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPOCUENTA]);}}
			protected int idCuentaPosCobrarPagar{get{return Convert.ToInt32(Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR]);}}
			protected int idSubCuentaPosCobrarPagar{get{return Convert.ToInt32(Page.Request.Params[KEYQIDSUBCUENTAPORCOBRARPAGAR]);}}
			protected int idEntidad{get{return Convert.ToInt32(Page.Request.Params[KEYQENTIDAD]);}}
			protected string NroDocumento{get{return Page.Request.Params[KEYQNRODOCUMENTO].ToString();}}
			protected string Descripcion{get{return Page.Request.Params[KEYQDESCRIPCION].ToString();}}
			protected string RazonSocial{get{return Page.Request.Params[KEYQRAZONSOCIAL].ToString();}}
			protected int idAjustes{get{return Convert.ToInt32(Page.Request.Params[KEYQIDAJUSTE].ToString());}}
			protected string nroRuc{get{return Page.Request.Params[KEYQNRORUC].ToString();}}

		
		#endregion


		#region Controles

			protected System.Web.UI.WebControls.Label lblPrimario;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblNroDoc;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"CuentasPorPagar",this.ToString(),"Se consultó la Cuentas Por Pagar",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.SeleccionarItemCombos(this);
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarGrillaOrdenamientoPaginacion("",0);				
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
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception oException)
				{
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarDetalleCuentasPorCobraryPagar.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarDetalleCuentasPorCobraryPagar.LlenarGrillaOrdenamiento implementation
		}

		protected DataTable ObtenerDatos
		{
			get
			{
				if(Page.Request.QueryString[KEYQIDTIPOCONSULTA]==null)
				{
					return (new CCuentasPorCobrarPagar()).ConsultarCuentasporCobraryPagarNivel3ClientesProveedoryOtrosDetalle(
						this.idCentroOperativo
						,this.idTipodeCuenta
						,this.idCuentaPosCobrarPagar
						,this.idSubCuentaPosCobrarPagar
						,this.idEntidad
						,this.NroDocumento
						,this.idAjustes
						);
				}
				else if(Page.Request.QueryString[KEYQIDTIPOCONSULTA].ToString()==INTERESES)
				{
					return (new CCuentasPorCobrarPagar()).ConsultarDetalleCuentasDiversasIntereses(
						
						this.idTipodeCuenta
						,this.idCentroOperativo 
						,this.idCuentaPosCobrarPagar
						,this.idSubCuentaPosCobrarPagar
						,this.nroRuc
						);
				}
				else if(Page.Request.QueryString[KEYQIDTIPOCONSULTA].ToString()==OTROS)
				{
					return (new CCuentasPorCobrarPagar()).ConsultarDetalleCuentasDiversasOtros(
						
						this.idTipodeCuenta
						,this.idCentroOperativo 
						,this.idCuentaPosCobrarPagar
						,this.idSubCuentaPosCobrarPagar
						,this.nroRuc
						);
				}
				else if(Page.Request.QueryString[KEYQIDTIPOCONSULTA].ToString()==PRESTAMOSTERCEROS)
				{
					return (new CCuentasPorCobrarPagar()).ConsultarDetalleCuentasDiversasIntereses(
						
						this.idTipodeCuenta
						,this.idCentroOperativo 
						,this.idCuentaPosCobrarPagar
						,this.idSubCuentaPosCobrarPagar
						,this.nroRuc
						);
				}
				return null;
			}
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtCuentasPorPagar = this.ObtenerDatos;
			if(dtCuentasPorPagar!=null)
			{
				DataView dwCuentasPorPagar = dtCuentasPorPagar.DefaultView;
				dwCuentasPorPagar.Sort = columnaOrdenar ;
				//dwCuentasPorPagar.RowFilter = Utilitario.Helper.ObtenerFiltro();

				if (dwCuentasPorPagar.Count == 0)
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
				}
				else
				{
					//Session["EXPORTAREXCEL"]=dtCuentasPorPagar;
					if(Page.Request.QueryString[KEYQIDTIPOCONSULTA]!=null)
						grid.ShowFooter=true;
					grid.DataSource = dwCuentasPorPagar;
					grid.CurrentPageIndex =indicePagina;
					grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla(7,12,18);
					//grid.Columns[Constantes.POSICIONTOTAL].FooterText = dwCuentasPorPagar.Count.ToString();
					lblResultado.Visible = false;
				}
			}
			else
			{
				grid.DataSource = dtCuentasPorPagar;
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

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarDetalleCuentasPorCobraryPagar.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblDescripcion.Text= this.Descripcion.ToString();
			this.lblPrimario.Text = this.RazonSocial.ToString();
			this.lblNroDoc.Text = this.NroDocumento.ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarDetalleCuentasPorCobraryPagar.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarDetalleCuentasPorCobraryPagar.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarDetalleCuentasPorCobraryPagar.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarDetalleCuentasPorCobraryPagar.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarDetalleCuentasPorCobraryPagar.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarDetalleCuentasPorCobraryPagar.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Cells[6].Text= Convert.ToDouble(e.Item.Cells[6].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[7].Text= Convert.ToDouble(e.Item.Cells[7].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				if(Page.Request.QueryString[KEYQIDTIPOCONSULTA]==null)
				{
					if (e.Item.Cells[5].Text.ToString().Trim()=="TOTAL:")
					{
						e.Item.Cells[2].Text="";
						e.Item.Cells[6].Text= e.Item.Cells[7].Text;
						e.Item.Cells[6].ColumnSpan = 2;
						e.Item.Cells[6].Style.Add("align","center");
						e.Item.Cells[7].Visible=false;

						e.Item.CssClass = "FooterGrilla";
						e.Item.Font.Bold = true;
						e.Item.Font.Size = 10;
					}
					else
					{
						Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
						
					}
				}
				else
				{
					Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
					totalAbono+=Convert.ToDouble(dr["abono"]);
					totalCargo+=Convert.ToDouble(dr["cargo"]);
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				
				if(Page.Request.QueryString[KEYQIDTIPOCONSULTA]!=null)
				{
					e.Item.Cells[6].CssClass = "FooterGrilla";
					e.Item.Cells[6].Font.Bold = true;
					e.Item.Cells[6].Font.Size = 8;
					e.Item.Cells[7].CssClass = "FooterGrilla";
					e.Item.Cells[7].Font.Bold = true;
					e.Item.Cells[7].Font.Size = 8;

					e.Item.Cells[6].Text=totalCargo.ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[7].Text=totalAbono.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}
			}
		}
	}
}
