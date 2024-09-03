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

namespace SIMA.SimaNetWeb.GestionFinanciera.ProyectosPorProvisionarLiquidar
{
	public class ConsultarDetalleProyectosGeneral : System.Web.UI.Page, IPaginaBase
	{
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IPaginaBase Members
		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public DataTable ObtenerDatos()
		{
			CProyectosPorLiquidarProvisionar oCProyectosPorLiquidarProvisionar = new CProyectosPorLiquidarProvisionar();

			if(Page.Request.QueryString[KEYIDPERIOD0]==null)
				return oCProyectosPorLiquidarProvisionar.ConsultarProyectosPorLiquidarProvisionarPorLineaNegocioDetalle(Page.Request.QueryString[KEYIDSIT],Page.Request.QueryString[KEYIDLN]);
			else
				return null;
			// Aqui Adjuntas tu parte Miguel y descomentas todo
			//else
			//	return oCProyectosPorLiquidarProvisionar.ConsultarProyectosPorLiquidarProvisionarPorLineaNegocioDetalle(Page.Request.QueryString[KEYIDSIT],Page.Request.QueryString[KEYIDLN],	return oCProyectosPorLiquidarProvisionar.ConsultarProyectosPorLiquidarProvisionarPorLineaNegocioDetalle(Page.Request.QueryString[KEYIDSIT],Convert.ToInt32(Page.Request.QueryString[KEYIDPERIODO]));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtProyectos =  ObtenerDatos();
			
			if(dtProyectos!=null)
			{
				DataView dwProyectos = dtProyectos.DefaultView;
				dwProyectos.Sort = columnaOrdenar ;
				this.Totalizar(dwProyectos);
				dwProyectos.RowFilter = Helper.ObtenerFiltro(this);
				if(dwProyectos.Count>0)
				{
					grid.CurrentPageIndex = indicePagina;
					grid.DataSource = dwProyectos;
					grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla();
					grid.Columns[1].FooterText = dwProyectos.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
			}
			else
			{
				grid.DataSource = dtProyectos;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
		}

		public void LlenarDatos()
		{
			if(Page.Request.QueryString[KEYIDSIT] == "PEN")
				lblTitulo.Text = lblTitulo.Text + " Provisionar en " + Page.Request.QueryString[KEYIDLN];
			else
				lblTitulo.Text = lblTitulo.Text + " Provisionar en " + Page.Request.QueryString[KEYIDLN];
		}

		public void LlenarJScript()
		{
		}

		public void RegistrarJScript()
		{
	

		}

		public void Imprimir()
		{
		}

		public void Exportar()
		{
			
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{
				CNetAccessControl.LoadControls(this);
			}
			else
			{
				CNetAccessControl.RedirectPageError();
			}
		}

		public bool ValidarFiltros()
		{
			return true;
		}

		#endregion
		#region Constantes
		const string KEYQNUEVOSSOLES = "MILNS";
		private const string GRILLAVACIA="No existen registros";
		private const string MENSAJECONSULTAR="Se consulto el Detalle de Cuentas por Provisionar/Liquidar";
		private const string KEYIDSIT="KEYIDSIT";
		private const string KEYIDLN="KEYIDLN";
		private const string KEYIDPERIOD0="KEYIDPERIOD0";

		#region Label Item
		const string LBLVALORIZACION = "lblValorizacion";
		const string LBLDIFERENCIA   = "lblDiferencia";
		const string LBLFACTURADO    = "lblFacturado";
		const string LBLRESULTADO    = "lblResult";

		const string LBLDIRECTOS     = "lblDirectos";
		const string LBLINDIRECTOS   = "lblIndirectos";
		const string LBLTOTAL        = "lblTotal";

		const string LBLSUMDIRECTOS   = "lblSumGDirectos";
		const string LBLSUMINDIRECTOS = "lblSumGIndirectos";
		const string LBLSUMTOTAL      = "lblSumGTotal";

		const string LBLSUMVALORIZACION = "lblSumValorizacion";
		const string LBLSUMDIFERENCIA   = "lblSumDiferencia";
		const string LBLSUMFACTURADO    = "lblSumFacturado";
		const string LBLSUMRESULTADO    = "lblSumResult";

		#endregion
		#endregion
		#region Variables
		double TotValorizacion;
		double TotGastoDirecto;
		double TotGastoIndirecto;
		double TotGastoTotal;
		double TotDiferencia;
		double TotFacturado;
		double TotCobrado;
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		#endregion
		#region Eventos
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarDatos();
					this.ConfigurarAccesoControles();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));			
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

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(ObtenerDatos()
				,"OT" + ";OT"
				,"FECHA" + ";FECHA"
				,"SIT" + ";SIT"
				,"CLIENTE" + ";CLIENTE"
				,"SERVICIO" + ";SERVICIO"
				);
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;

				this.ColocarValor(e,dr,LBLVALORIZACION,"VALORIZACION",Utilitario.Constantes.SIVERMILES);

				this.ColocarValor(e,dr,LBLDIRECTOS,"GASTOSDIRECTOS",Utilitario.Constantes.SIVERMILES);
				this.ColocarValor(e,dr,LBLINDIRECTOS,"GASTOSINDIRECTOS",Utilitario.Constantes.SIVERMILES);
				this.ColocarValor(e,dr,LBLTOTAL,"TOTAL",Utilitario.Constantes.SIVERMILES);

				this.ColocarValor(e,dr,LBLDIFERENCIA,"DIFERENCIA",Utilitario.Constantes.SIVERMILES);
				this.ColocarValor(e,dr,LBLFACTURADO,"FACTURADO",Utilitario.Constantes.SIVERMILES);
				this.ColocarValor(e,dr,LBLRESULTADO,"COBRADO",Utilitario.Constantes.SIVERMILES);


				//Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto(txtObservaciones.ID,dr["Observaciones"].ToString()));
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				this.EtiquetaTotales(e, LBLSUMVALORIZACION, TotValorizacion);
				this.EtiquetaTotales(e, LBLSUMDIRECTOS, TotGastoDirecto);
				this.EtiquetaTotales(e, LBLSUMINDIRECTOS, TotGastoIndirecto);
				this.EtiquetaTotales(e, LBLSUMTOTAL, TotGastoTotal);
				this.EtiquetaTotales(e, LBLSUMDIFERENCIA, TotDiferencia);
				this.EtiquetaTotales(e, LBLSUMFACTURADO, TotFacturado);
				this.EtiquetaTotales(e, LBLSUMRESULTADO, TotCobrado);
			}
		}

		public void Totalizar (DataView dwTotales)
		{
			if (dwTotales != null)
			{
				double [] aArreglo = Helper.TotalizarDataView(dwTotales,"VALORIZACION");
				TotValorizacion = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"GASTOSDIRECTOS");
				TotGastoDirecto = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"GASTOSINDIRECTOS");
				TotGastoIndirecto = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"TOTAL");
				TotGastoTotal = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"DIFERENCIA");
				TotDiferencia= aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"FACTURADO");
				TotFacturado = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"COBRADO");
				TotCobrado = aArreglo[0];

			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.grid.CurrentPageIndex=e.NewPageIndex;
			HttpContext.Current.Session[Constantes.KEYSINDICEPAGINA] = e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}
		private void ColocarValor(System.Web.UI.WebControls.DataGridItemEventArgs e, DataRow dr, string nombrecontrol, string Campo, string verMiles)
		{
			Label lbl;
			lbl = (Label) e.Item.Cells[0].FindControl(nombrecontrol);
			if (verMiles!=null)
				
				lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
					|| Session[KEYQNUEVOSSOLES].ToString() == verMiles)
					? (Convert.ToDouble(dr[Campo])/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
					:Convert.ToDouble(dr[Campo]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
			else
			{
				if (dr[Campo].ToString().Substring(0,1)=="S") 
					lbl.Text = dr[Campo].ToString();
				else
					lbl.Text = Convert.ToDouble(dr[Campo]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void EtiquetaTotales(System.Web.UI.WebControls.DataGridItemEventArgs e, string nombrecontrol, double Total)
		{
			Label lbl;
			lbl = (Label) e.Item.Cells[0].FindControl(nombrecontrol);
			lbl.Font.Size = 8;
			lbl.Font.Bold = true;
			lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
				? (Total/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
				:Total.ToString(Utilitario.Constantes.FORMATODECIMAL4);
		}
		#endregion
	}
}
