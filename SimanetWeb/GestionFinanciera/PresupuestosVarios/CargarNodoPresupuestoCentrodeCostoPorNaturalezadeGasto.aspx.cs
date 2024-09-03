using System;
using System.Data;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Drawing.Printing;

namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios
{
	public class CargarNodoPresupuestoCentrodeCostoPorNaturalezadeGasto : System.Web.UI.Page,IPaginaBase
	{
		#region Constante
			const string GRILLAVACIA ="No existe ningún Registro.";  
			const string KEYIDCENTROOPERATIVO ="centro"; 
	 
			const string KEYIDPRESUPUESTOCUENTA ="Cta";  
			const string KEYIDTIPOPRESUPUESTOCUENTA ="idTipoPresupuestoCta";  
			const string KEYIDTIPOPRESUPUESTO ="idTipoPresupuesto";
			const string KEYIDNOMBRETIPOPRESUPUESTO ="NombreTipoPresupuesto";

			const string KEYIDGRUPOCC ="idGrpCC";
			const string KEYIDCENTROCOSTO ="idCC";
			const string KEYIDNOMBREGRUPOCC ="NombreGrpCC";
			const string KEYIDPERIODO ="periodo";
			const string KEYIDMES ="idMes";
			const string KEYIDNOMBREMES ="NombreMes";

		//DataGrid and DataTable
		const string COLUMNANOMBRECTA ="NombreCuenta";

		#endregion

		#region Controles
			protected System.Web.UI.WebControls.TextBox txtTrama;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarDatos();
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
					ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
					ltlMensaje.Text= Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionIU.Error.ToString());
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add CargarNodoPresupuestoCentrodeCostoPorNaturalezadeGasto.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add CargarNodoPresupuestoCentrodeCostoPorNaturalezadeGasto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add CargarNodoPresupuestoCentrodeCostoPorNaturalezadeGasto.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add CargarNodoPresupuestoCentrodeCostoPorNaturalezadeGasto.LlenarCombos implementation
		}

		private DataTable ObtenerDatos()
		{
			return ((CPresupuesto) new CPresupuesto()).AdministrarDetallePresupuestoCuenta5Dig(
				Page.Request.Params[KEYIDPRESUPUESTOCUENTA].ToString()
				,Convert.ToInt32(Page.Request.Params[KEYIDCENTROOPERATIVO])
				,Convert.ToInt32(Page.Request.Params[KEYIDGRUPOCC])
				,Convert.ToInt32(Page.Request.Params[KEYIDCENTROCOSTO])
				,Convert.ToInt32(Page.Request.Params[KEYIDPERIODO])
				,CNetAccessControl.GetIdUser());
		}
		public void LlenarDatos()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			DataTable dt = this.ObtenerDatos();
			foreach(DataRow dr in dt.Rows)
			{
				sb.Append(dr["CuentaContable"].ToString());
				sb.Append(Utilitario.Constantes.SIGNOASTERISCO);
				sb.Append(dr[COLUMNANOMBRECTA].ToString());
				sb.Append(Utilitario.Constantes.SIGNOASTERISCO);
				string []Meses={"pEnero","pFebrero","pMarzo","pAbril","pMayo","pjunio","pjulio","pAgosto","pSetiembre","pOctubre","pNoviembre","pdiciembre","pTotal"};
				for(int i=0;i<= Meses.Length-1;i++)
				{
					sb.Append(dr[Meses[i].ToString()].ToString());
					sb.Append(Utilitario.Constantes.SIGNOASTERISCO);
				}
				sb.Append("@");
			}
			this.txtTrama.Text=sb.ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add CargarNodoPresupuestoCentrodeCostoPorNaturalezadeGasto.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add CargarNodoPresupuestoCentrodeCostoPorNaturalezadeGasto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add CargarNodoPresupuestoCentrodeCostoPorNaturalezadeGasto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add CargarNodoPresupuestoCentrodeCostoPorNaturalezadeGasto.Exportar implementation
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
			// TODO:  Add CargarNodoPresupuestoCentrodeCostoPorNaturalezadeGasto.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
