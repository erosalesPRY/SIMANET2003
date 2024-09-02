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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Controladoras.General;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio
{
	/// <summary>
	/// Summary description for DefaultAdministrarObservacionesCtasCobrarPagar.
	/// </summary>
	public class DefaultAdministrarObservacionesCtasCobrarPagar : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DropDownList ddblSubCuenta;
		protected System.Web.UI.WebControls.Label lblSubCuenta;
		protected System.Web.UI.WebControls.DropDownList ddblSubCuentaRubro;
		protected System.Web.UI.WebControls.Label lblCuentaRubro;
		protected System.Web.UI.WebControls.DropDownList ddlbConcepto;
		protected System.Web.UI.WebControls.Label lblTipoPersona;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD3;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD4;
		protected System.Web.UI.WebControls.ImageButton btnComsultar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hTabSeleccionado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarJScript();
					this.ConfigurarAccesoControles();
					//Helper.ReiniciarSession();
					LlenarCombos();
					Helper.SeleccionarItemCombos(this);
					//HidCO.Value=String.Empty;
					//this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
			this.ddlbConcepto.SelectedIndexChanged += new System.EventHandler(this.ddlbConcepto_SelectedIndexChanged);
			this.ddblSubCuentaRubro.SelectedIndexChanged += new System.EventHandler(this.ddblSubCuentaRubro_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DefaultAdministrarObservacionesCtasCobrarPagar.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DefaultAdministrarObservacionesCtasCobrarPagar.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DefaultAdministrarObservacionesCtasCobrarPagar.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			llenarConcepto();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DefaultAdministrarObservacionesCtasCobrarPagar.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DefaultAdministrarObservacionesCtasCobrarPagar.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DefaultAdministrarObservacionesCtasCobrarPagar.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DefaultAdministrarObservacionesCtasCobrarPagar.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DefaultAdministrarObservacionesCtasCobrarPagar.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DefaultAdministrarObservacionesCtasCobrarPagar.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DefaultAdministrarObservacionesCtasCobrarPagar.ValidarFiltros implementation
			return false;
		}
		private void llenarConcepto()
		{
			ListItem lItem = new ListItem("CUENTAS POR COBRAR","0");
			ListItem lItem2 = new ListItem("CUENTAS POR PAGAR","1");
			
			this.ddlbConcepto.Items.Insert(0,lItem);
			this.ddlbConcepto.Items.Insert(1,lItem2);
			ViewState["Rubro"]=0;
			ddlbConcepto.DataBind();
			llenarSubCuentaRubro();
			llenarSubCuentaComercial();
			
		
		}
		#endregion

		private void ddlbConcepto_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ddlbConcepto.SelectedValue=="0")
			{
				ViewState["Rubro"]=0;
				
				lblCuentaRubro.Text="Sub Cuenta";
				ddblSubCuentaRubro.Items.Clear();
				llenarSubCuentaRubro();
			}
			else
			{
			
				ViewState["Rubro"]=1;
				lblCuentaRubro.Text="Rubro";
				//TD3.Visible=true;
				//TD4.Visible=true;
				lblSubCuenta.Visible=true;
				ddblSubCuenta.Enabled=true;
				ddblSubCuentaRubro.Items.Clear();
				llenarRubro();
			}
		}

		private void ddblSubCuentaRubro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if( ViewState["Rubro"].ToString()!="1")
			{
				if(ddblSubCuentaRubro.SelectedValue=="1")
				{
					//TD3.Visible=true;
					//TD4.Visible=true;
					ddblSubCuenta.Items.Clear();
					lblSubCuenta.Visible=true;
					ddblSubCuenta.Enabled=true;
					llenarSubCuentaComercial();
				}
				else if(ddblSubCuentaRubro.SelectedValue=="2")
				{
					//TD3.Visible=true;
					//TD4.Visible=true;
					ddblSubCuenta.Items.Clear();
					lblSubCuenta.Visible=true;
					ddblSubCuenta.Enabled=true;
					llenarSubCuentaDiversas();
				}
				else
				{
					lblSubCuenta.Visible=true;
				
					ddblSubCuenta.Enabled=false;
					//TD3.Visible=false;
					//TD4.Visible=false;
					//this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
				}
			}
			else
			{
				if(ddblSubCuentaRubro.SelectedValue=="4")
				{
					ddblSubCuenta.Items.Clear();
					lblSubCuenta.Visible=true;
					ddblSubCuenta.Enabled=true;
					llenarSubCuentaComercialPorPagar();
				}
				else
				{
					ddblSubCuenta.Items.Clear();
					lblSubCuenta.Visible=true;
					ddblSubCuenta.Enabled=true;
					llenarRubroOtrasCuentasPorPagar();
				}
			}
		}
		private void llenarRubro()
		{
			ListItem lItem = new ListItem("COMERCIAL","4");
			ListItem lItem2 = new ListItem("OTRAS CUENTAS POR PAGAR","5");
			
			this.ddblSubCuentaRubro.Items.Insert(0,lItem);
			this.ddblSubCuentaRubro.Items.Insert(1,lItem2);
			ddblSubCuentaRubro.DataBind();
			
		}
		private void llenarSubCuentaRubro()
		{
			ListItem lItem = new ListItem("COMERCIAL","1");
			ListItem lItem2 = new ListItem("DIVERSAS","2");
			ListItem lItem3 = new ListItem("JUDICIAL","3");
			ListItem lItem4 = new ListItem("POR PROVISIONAR","6");
			ListItem lItem5= new ListItem("PROVISIONADAS","7");
						
			this.ddblSubCuentaRubro.Items.Insert(0,lItem);
			this.ddblSubCuentaRubro.Items.Insert(1,lItem2);
			this.ddblSubCuentaRubro.Items.Insert(2,lItem3);
			this.ddblSubCuentaRubro.Items.Insert(3,lItem4);
			this.ddblSubCuentaRubro.Items.Insert(4,lItem5);
			ddblSubCuentaRubro.DataBind();
		}
		private void llenarSubCuentaComercial()
		{
			ListItem lItem = new ListItem("FACTURAS","1");
			ListItem lItem2 = new ListItem("LETRAS","2");
			ListItem lItem3 = new ListItem("ANTICIPOS A PROVEEDORES","3");
		
						
			this.ddblSubCuenta.Items.Insert(0,lItem);
			this.ddblSubCuenta.Items.Insert(1,lItem2);
			this.ddblSubCuenta.Items.Insert(2,lItem3);
			ddblSubCuenta.DataBind();
			
		}
		private void llenarSubCuentaComercialPorPagar()
		{
			ListItem lItem = new ListItem("FACTURAS","11");
			ListItem lItem2 = new ListItem("LETRAS","12");
			ListItem lItem3 = new ListItem("ANTICIPOS A PROVEEDORES","13");
		
						
			this.ddblSubCuenta.Items.Insert(0,lItem);
			this.ddblSubCuenta.Items.Insert(1,lItem2);
			this.ddblSubCuenta.Items.Insert(2,lItem3);
			ddblSubCuenta.DataBind();
			
		}
		private void llenarSubCuentaDiversas()
		{
			ListItem lItem = new ListItem("APORTES ACCIONISTAS","4");
			ListItem lItem2 = new ListItem("PRESTAMOS A PERSONAL","5");
			ListItem lItem3 = new ListItem("PRESTAMOS A TERCEROS","6");
			ListItem lItem4 = new ListItem("RECLAMOS A TERCEROS","7");
			ListItem lItem5 = new ListItem("INTERESES ","8");
			ListItem lItem6 = new ListItem("OTROS ","9");
		
						
			this.ddblSubCuenta.Items.Insert(0,lItem);
			this.ddblSubCuenta.Items.Insert(1,lItem2);
			this.ddblSubCuenta.Items.Insert(2,lItem3);
			this.ddblSubCuenta.Items.Insert(3,lItem4);
			this.ddblSubCuenta.Items.Insert(4,lItem5);
			this.ddblSubCuenta.Items.Insert(5,lItem6);
			ddblSubCuenta.DataBind();
			
		}
		private void llenarRubroOtrasCuentasPorPagar()
		{
			ListItem lItem = new ListItem("TRIBUTOS","14");
			ListItem lItem2 = new ListItem("REMUNERACIONES","15");
			ListItem lItem3 = new ListItem("PRESTAMOS DE TERCEROS","16");
			ListItem lItem4 = new ListItem("RECLAMACIONES DE TERCEROS","17");
			ListItem lItem5 = new ListItem("INTERESES ","18");
			ListItem lItem6 = new ListItem("DEPOSITOS ","19");
			ListItem lItem7 = new ListItem("OTROS ","20");
		
						
			this.ddblSubCuenta.Items.Insert(0,lItem);
			this.ddblSubCuenta.Items.Insert(1,lItem2);
			this.ddblSubCuenta.Items.Insert(2,lItem3);
			this.ddblSubCuenta.Items.Insert(3,lItem4);
			this.ddblSubCuenta.Items.Insert(4,lItem5);
			
			ddblSubCuenta.DataBind();
		}

	}
}
