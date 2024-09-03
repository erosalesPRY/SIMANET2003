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
	/// Summary description for ConsultarEvaluacionGastosdeAdministracionCC.
	/// </summary>
	public class ConsultarEvaluacionGastosdeAdministracionCC : System.Web.UI.Page,IPaginaBase
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
		const string KEYQMES ="Mes";
		const string VISTAPPTOPRINCIPAL="Principales";
		const string KEYQPPTO = "VISTAPPTO";
		const string KEYQUIENLLAMA = "QLlama";

		//
		const string LBLMONTOPPTO = "lblPrespuesto";
		const string LBLMONTOEJECUTADO = "lblEjecutado";
		const string LBLMONTOSALDO = "lblSaldo";
		const string LBLCENTRO = "lblEmpresa";

		
		const string SESSTOTALIZA = "Totaliza";
		#endregion
		#region Controles
			protected System.Web.UI.WebControls.Label lblPagina;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hListadePersonal;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPathFotos;
		protected System.Web.UI.WebControls.Label lblApellidosyNombres;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label LblEspecilidad;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtBuscar;
		protected System.Web.UI.WebControls.Label lblMostrar;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//PERuspNTADConsDetallePlantaActual 'CCH',1,883,'', null
			//return oCPersonal.ConsultarDetallePlantaActual(flag,Convert.ToInt32(Page.Request.QueryString[KEYQID]),Convert.ToInt32(Page.Request.QueryString[KEYQID1]), Page.Request.QueryString[KEYQCADENA].ToString());

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
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarEvaluacionGastosdeAdministracionCC.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarEvaluacionGastosdeAdministracionCC.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			if (Page.Request.Params[KEYQPPTO].ToString()==VISTAPPTOPRINCIPAL)
			{
				return ((CPresupuesto)new  CPresupuesto()).ConsultarEvaluacionPrespuestalPorCentrosdeCosto3Dig(
																												Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
																												,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO])
																												,Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOCC])
																												,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO])
																												,Convert.ToInt32(Page.Request.Params[KEYQPERIODO])
																												,Convert.ToInt32(Page.Request.Params[KEYQMES]));
			}
			else
			{
				return ((CPresupuesto)new  CPresupuesto()).ConsultarEvaluacionPrespuestalPorCentrosdeCosto3DigAuxiliar(
																													Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
																													,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO])
																													,Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOCC])
																													,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO])
																													,Convert.ToInt32(Page.Request.Params[KEYQPERIODO])
																													,Convert.ToInt32(Page.Request.Params[KEYQMES]));

			}
		}
		private void TotalPresupuesto(DataTable dt)
		{
			ArrayList arrTotal = new ArrayList();
			if ((Page.Request.Params[KEYQUIENLLAMA]!=null)&& (Page.Request.Params[KEYQUIENLLAMA].ToString()=="0"))
			{
				arrTotal.Add((Helper.TotalizarDataView(dt.DefaultView,"MontoPresupuestadoMes"))[0]);
				arrTotal.Add((Helper.TotalizarDataView(dt.DefaultView,"MontoEjecutadoMes"))[0]);
				arrTotal.Add((Helper.TotalizarDataView(dt.DefaultView,"MontoSaldoMes"))[0]);
			}
			else
			{
				arrTotal.Add((Helper.TotalizarDataView(dt.DefaultView,"MontoPresupuestado"))[0]);
				arrTotal.Add((Helper.TotalizarDataView(dt.DefaultView,"MontoEjecutado"))[0]);
				arrTotal.Add((Helper.TotalizarDataView(dt.DefaultView,"MontoSaldo"))[0]);
			}
			Session[SESSTOTALIZA]=arrTotal;
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				this.TotalPresupuesto(dtGeneral);
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
			// TODO:  Add ConsultarEvaluacionGastosdeAdministracionCC.LlenarCombos implementation
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
		public void LlenarDatos()
		{
			this.hPathFotos.Value = Helper.ObtenerRutaImagenes(Utilitario.Constantes.RUTAFOTOS);
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
			//this.hListadePersonal.Value = this.hListadePersonal.Value.Substring(1,(this.hListadePersonal.Value.Length
		}

		public void LlenarJScript()
		{
			this.lblMostrar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"MostraryOcultarListadePersonal()");
			this.lblMostrar.Attributes.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarEvaluacionGastosdeAdministracionCC.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarEvaluacionGastosdeAdministracionCC.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarEvaluacionGastosdeAdministracionCC.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarEvaluacionGastosdeAdministracionCC.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarEvaluacionGastosdeAdministracionCC.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				//((Label)e.Item.Cells[0].FindControl(LBLMONTOPPTO)).Text = Page.Request.Params[KEYQCENTROOPERATIVONOMBRE].ToString().ToUpper();
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Attributes.Add("CuentaContable3Dig",dr["CuentaContable3Dig"].ToString());
				e.Item.Cells[0].Controls.Add(Helper.CrearNodoRaiz(e,dr["CuentaContableGrupo"].ToString() + "-" + e.Item.Cells[0].Text,"ObtenerDetalleaNiveldeCuenta5Dig" ,true));

				Label lbl;
				lbl = (Label)e.Item.Cells[0].FindControl(LBLMONTOPPTO);
				lbl.Text = (((Page.Request.Params[KEYQUIENLLAMA]!=null)&&(Page.Request.Params[KEYQUIENLLAMA].ToString()=="0"))? 
					Convert.ToDouble(dr["MontoPresupuestadoMes"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) 
					:Convert.ToDouble(dr["MontoPresupuestado"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4));

				lbl = (Label)e.Item.Cells[0].FindControl(LBLMONTOEJECUTADO);
				lbl.Text = (((Page.Request.Params[KEYQUIENLLAMA]!=null)&&(Page.Request.Params[KEYQUIENLLAMA].ToString()=="0"))? 
					Convert.ToDouble(dr["MontoEjecutadoMes"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4)
					:Convert.ToDouble(dr["MontoEjecutado"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4));
				
				lbl = (Label)e.Item.Cells[0].FindControl(LBLMONTOSALDO);
				lbl.Text = (((Page.Request.Params[KEYQUIENLLAMA]!=null)&&(Page.Request.Params[KEYQUIENLLAMA].ToString()=="0"))? 
					Convert.ToDouble(dr["MontoSaldoMes"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4)
					:Convert.ToDouble(dr["MontoSaldo"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4));

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[0].Text = "TOTAL :";
				ArrayList arrTotal = (ArrayList)Session[SESSTOTALIZA];
				Label lbl;
				lbl = (Label)e.Item.Cells[0].FindControl(LBLMONTOPPTO+"F");
				lbl.Text = Convert.ToDouble(arrTotal[0]).ToString(Constantes.FORMATODECIMAL4);
				lbl = (Label)e.Item.Cells[0].FindControl(LBLMONTOEJECUTADO+"F");
				lbl.Text = Convert.ToDouble(arrTotal[1]).ToString(Constantes.FORMATODECIMAL4);
				lbl = (Label)e.Item.Cells[0].FindControl(LBLMONTOSALDO+"F");
				lbl.Text = Convert.ToDouble(arrTotal[2]).ToString(Constantes.FORMATODECIMAL4);
				Session[SESSTOTALIZA]=null;
				
			}
		}

	}
}
