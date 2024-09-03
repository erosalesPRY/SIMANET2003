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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto
{
	/// <summary>
	/// Summary description for AdministrarPresupuestoPorCentrodeCosto.
	/// </summary>
	public class AdministrarPresupuestoPorCentrodeCosto : System.Web.UI.Page,IPaginaBase
	{
		#region constantes
			const string GRILLAVACIA="No existe Datos";
			const string PROCESO ="idProceso";//Indicador de Proceso 
			const string KEYQTIPOPRESUPUESTO ="idtp";
			const string KEYQIDCENTROOPERATIVO="idCentro";
			const string KEYQIDCENTROOPERATIVOP="idcop";//CentroOPerativo de la pagina de Procesos
			const string KEYQCENTROOPERATIVONOMBRE = "NombreCentro";
			const string KEYQIDGRUPOCC = "idGrpCC";
			const string KEYQIDCENTROCOSTO ="idCC";	
			const string KEYQPERIODO ="Periodo";

			const string SESSTOTALIZA = "Totaliza";
		#endregion

		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidMes;
		protected System.Web.UI.WebControls.ImageButton ibtnResumen;
		protected System.Web.UI.WebControls.ImageButton ibtnListadoppto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCuentaCG;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCuentaContable;
		protected System.Web.UI.WebControls.Label lblMostrar;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtBuscar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hListadePersonal;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPathFotos;
		protected System.Web.UI.WebControls.Label LblEspecilidad;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblApellidosyNombres;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCtaCble5dig;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.ConfigurarAccesoControles();
				Helper.ReiniciarSession();
				Helper.ReestablecerPagina(this);
				this.LlenarJScript();
				this.LlenarDatos();
				this.LlenarCombos();
				this.LlenarGrillaOrdenamientoPaginacion(String.Empty,Constantes.INDICEPAGINADEFAULT);	
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
			this.ibtnListadoppto.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnListadoppto_Click);
			this.ibtnResumen.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnResumen_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarPresupuestoPorCentrodeCosto.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarPresupuestoPorCentrodeCosto.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			CPresupuesto oCPresupuesto = new  CPresupuesto();
			DataTable tblResultado =oCPresupuesto.ConsultarFormulacionPrespuestalPorCentrosdeCosto3Dig(
																Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
																,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO])
																,Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOCC])
																,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO])
																,Convert.ToInt32(Page.Request.Params[KEYQPERIODO])
																);
			return tblResultado;
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				//this.TotalPresupuesto(dtGeneral);
				grid.DataSource = dtGeneral;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtGeneral;
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
			// TODO:  Add AdministrarPresupuestoPorCentrodeCosto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			int idMes;
			idMes = DateTime.Now.Month <6?6:DateTime.Now.Month;
			this.hidMes.Value = idMes.ToString();//Convert.ToInt32(SIMA.Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Month.ToString());
			//Obtiene la actualizacion del presupuesto a nivel de item
			int Periodo = Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);
			//int Prc=(new CPeriodo()).EstadoProcesoPeriodoPPTO(Convert.ToInt32(Periodo));
			/*if(Prc==1){
				(new CPresupuesto()).ImportarRequerimientoPorItemCentroCosto(Periodo);
			}*/

			this.hPathFotos.Value =  System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.RUTAFOTOSP].ToString();

			string Serparador = "[@]";
			this.hListadePersonal.Value ="";
			DataTable dt =  ObtenerDatosdePersonal();
			if (dt!=null)
			{
				foreach(DataRow dr in dt.Rows)
				{
					this.hListadePersonal.Value += dr["idPersonal"].ToString()
						+ "||" + dr["NroPersonal"].ToString()
						+ "||" + dr["Apellidos"].ToString() + " " + dr["Nombres"].ToString()
						+  "||" + dr["Cargo"].ToString()
						+  "||" + dr["NroDocIdentidad"].ToString()
						+ Serparador;
				}
			}
		}
		private DataTable ObtenerDatosdePersonal()
		{
			//PERuspNTADConsDetallePlantaActual 'CCH',1,883,'', null
			string flag="CCH";
			Controladoras.Personal.CPersonal oCPersonal = new Controladoras.Personal.CPersonal();
			DataTable dt= oCPersonal.ConsultarDetallePlantaActual(flag
				,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO])
				,Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROCOSTO])
				,Page.Request.QueryString[KEYQIDCENTROCOSTO].ToString());

			DataTable dtt = new DataTable();
			if(dt!=null)
			{
				string TipManoObra = ((Convert.ToInt32(Page.Request.Params[KEYQTIPOPRESUPUESTO])==1)?"ADM":"IND");
				DataView dv = dt.DefaultView;
				dv.RowFilter="TIPOMANOOBRA='" + TipManoObra + "'";
				dtt= Helper.DataViewTODataTable(dv);
			}
			else
			{
				dtt = null;
			}

			return dtt;
		}
		public void LlenarJScript()
		{
			this.ibtnResumen.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupDeEspera() + Helper.HistorialIrAdelantePersonalizado(this.hidMes.ID.ToString()));
			this.ibtnListadoppto.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupDeEspera() + Helper.HistorialIrAdelantePersonalizado(this.hCuentaContable.ID.ToString(),this.hidCuentaCG.ID.ToString()));
			this.lblMostrar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"MostraryOcultarListadePersonal()");
			this.lblMostrar.Attributes.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarPresupuestoPorCentrodeCosto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarPresupuestoPorCentrodeCosto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarPresupuestoPorCentrodeCosto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarPresupuestoPorCentrodeCosto.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarPresupuestoPorCentrodeCosto.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			int idMes = Convert.ToInt32(this.hidMes.Value);
			if (idMes >=7)
			{
				int NroColOcultar =  (idMes -6);
				for(int i=1;i<= NroColOcultar;i++)
				{
					e.Item.Cells[i].Style.Add("display","none");
				}
				
				if (idMes<12)
				{
					for(int i=(idMes+1);i<=12;i++)
					{
						e.Item.Cells[i].Style.Add("display","none");
					}
				}
			}
			else
			{
				for(int i=7;i<=12;i++)
				{
					e.Item.Cells[i].Style.Add("display","none");
				}
			}


			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Attributes.Add("CuentaContable3Dig",dr["CuentaContable3Dig"].ToString());
				e.Item.Cells[0].Controls.Add(Helper.CrearNodoRaiz(e,dr["CuentaContableGrupo"].ToString() + "-" + e.Item.Cells[0].Text,"ObtenerDetalleaNiveldeCuenta5Dig" ,true));
				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hidCuentaCG",dr["CuentaContableGrupo"].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCuentaContable",dr["CuentaContable3Dig"].ToString())
					);

				
				e.Item.Attributes.Add(Utilitario.Constantes.EVENTOONMOUSEOVER,"CambiarColorPasarMouse(this, true);UbicarBtnScroll(this);");
				for(int i=1;i<=12;i++)
				{
					e.Item.Cells[i].Text = Convert.ToDouble(e.Item.Cells[i].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}
				e.Item.Cells[13].Text = Convert.ToDouble(e.Item.Cells[13].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}		
			if(e.Item.ItemType == ListItemType.Footer)
			{
				string []ArrTitleFooter = new string[] {"NATURALEZA DE GASTO", "ENERO", "FEBRERO","MARZO","ABRIL","MAYO","JUNIO","JULIO","AGOSTO","SETIEMBRE","OCTUBRE","NOVIEMBRE","DICIEMBRE","TOTAL"};
				for(int i=0;i<=ArrTitleFooter.Length-1;i++)
				{
					e.Item.Cells[i].Text =ArrTitleFooter[i].ToString();
				}
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnResumen_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			int idCentroCosto = Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO]);
			DataTable dt = (new CPresupuesto()).RelacionMontoPresupuestalAño(Convert.ToInt32(Page.Request.Params[KEYQPERIODO]),Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]));
			DataView dv = dt.DefaultView;
			dv.RowFilter = "idCentroCosto ="+ "'"+idCentroCosto+"'";
			
			Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\Presupuesto\Meses\"
				,"RelacionMontoPresupuestalAño.rpt"
				, Helper.DataViewTODataTable(dv)
				,true);
		}

		private void ibtnListadoppto_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(this.hidCuentaCG.Value =="" && this.hCuentaContable.Value =="")
			{
				Helper.MsgBox("Seleccione Cuenta Contable");
			}
			else
			{
				int idCentroCosto = Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO]);
				string CtaCon = hCuentaContable.Value.Substring(0,2);
				Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\Presupuesto\Meses\"
					,"RelacionResumenMontoPresupuestalAño.rpt"
					, (new CPresupuesto()).ResumenPPtalPorCentroCostos(Convert.ToInt32(Page.Request.Params[KEYQPERIODO]),CtaCon,idCentroCosto)
					,true);
			}
		}

		private void ImgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			/*string Naturaleza = ((this.chk1.Checked==true&&this.chk2.Checked==true)?"1,3":((this.chk1.Checked==true)?"1":"3"));
			DataTable dt1 =  (new CPresupuestoRequerimiento()).ConsultarDetalleMaterialesMesyCC(Convert.ToInt32(Page.Request.Params[KEYQPERIODO]),Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]), Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO]),Naturaleza);
			Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\Presupuesto\","ListadeMaterialesPorCentroCostoMensual.rpt",dt1,true);*/
		}
	}
}


