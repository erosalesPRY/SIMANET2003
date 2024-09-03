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
	/// Summary description for DefaultCentrosdeCosto.
	/// </summary>
	public class DefaultCentrosdeCosto : System.Web.UI.Page,IPaginaBase
	{

		#region Constantes
			const string KEYQTIPOPRESUPUESTO ="idtp";
			const string CENTROOPERATIVO = "idCentro";
			const string KEYQTIPOOPCION = "Opcion";
			const string KEYQIDGRUPOCC = "idGrpCC";
			const string KEYQNOMBREGRUPOCC = "NombreGrpCC";
			const string KEYQCENTROOPERATIVONOMBRE = "NombreCentro";
			const string PERIODO = "Periodo";
			const string MES = "Mes";
			const string VISTAPPTOPRINCIPAL="Principales";
			const string KEYQPPTO = "VISTAPPTO";
			const string KEYQUIENLLAMA = "QLlama";

			const string KEYQPERIODO ="Periodo";


		#endregion


		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlTable tblResumen;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdHeader;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdMenu;
		protected System.Web.UI.HtmlControls.HtmlTableRow trPeriodo;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdCentro;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdCentro1;
		protected System.Web.UI.HtmlControls.HtmlTable tblResumenMensual;
		protected System.Web.UI.WebControls.Label lblNombreGrupoCC;
		protected System.Web.UI.WebControls.ImageButton ImgImprimir;
		protected System.Web.UI.WebControls.CheckBox chk2;
		protected System.Web.UI.WebControls.CheckBox chk1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCentroCostoSelect;
		protected System.Web.UI.WebControls.CheckBox chk3;
		protected System.Web.UI.WebControls.ImageButton imgXLS;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					if (Page.Request.Params[KEYQUIENLLAMA]!= null)
					{
						this.tdHeader.Visible=false;
						this.tdMenu.Visible=false;
						this.trPeriodo.Visible=false;
						this.tdCentro.Visible=false;
						this.tdCentro1.Visible=false;
					}

					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarCombos();
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
			this.ImgImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ImgImprimir_Click);
			this.imgXLS.Click += new System.Web.UI.ImageClickEventHandler(this.imgXLS_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DefaultCentrosdeCosto.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DefaultCentrosdeCosto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DefaultCentrosdeCosto.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DefaultCentrosdeCosto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblCentroOperativo.Text = Page.Request.Params[KEYQCENTROOPERATIVONOMBRE].ToString();
			this.lblNombreGrupoCC.Text = Page.Request.Params[KEYQNOMBREGRUPOCC].ToString();
			lblPeriodo.Text = Page.Request.Params[PERIODO].ToString();
			lblMes.Text = Helper.ObtenerNombreMes(Convert.ToInt32(Page.Request.Params[MES]),Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
			//Datos de Resumen
			this.CargarResumen();
			this.CargarResumenMensual();
		}
		private DataTable ObtenerDatos()
		{
			if (Page.Request.Params[KEYQPPTO].ToString()==VISTAPPTOPRINCIPAL)
			{
				return ((CPresupuesto) new  CPresupuesto()).ConsultarEvaluacionPrespuestalPorGruposdeCentrosdeCosto(Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
																												,Convert.ToInt32(Page.Request.Params[CENTROOPERATIVO])
																												,Convert.ToInt32(Page.Request.Params[PERIODO])
																												,Convert.ToInt32(Page.Request.Params[MES])
																												,Convert.ToInt32(Page.Request.Params[KEYQTIPOOPCION]));
			}
			else
			{
				return ((CPresupuesto) new  CPresupuesto()).ConsultarEvaluacionPrespuestalPorGruposdeCentrosdeCostoAuxiliar(Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
																															,Convert.ToInt32(Page.Request.Params[CENTROOPERATIVO])
																															,Convert.ToInt32(Page.Request.Params[PERIODO])
																															,Convert.ToInt32(Page.Request.Params[MES])
																															,Convert.ToInt32(Page.Request.Params[KEYQTIPOOPCION]));

			}
		}
		private void CargarResumen()
		{
			DataRow[] foundRows;
			foundRows= this.ObtenerDatos().Select("idGrupoCC = "+ Page.Request.Params[KEYQIDGRUPOCC].ToString()) ;

			if (Page.Request.Params[KEYQUIENLLAMA]!=null)
			{
				tblResumen.Rows[0].Cells[1].InnerText = Convert.ToDouble(foundRows[0]["MontoPresupuestadoMes"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				tblResumen.Rows[0].Cells[2].InnerText = Convert.ToDouble(foundRows[0]["MontoEjecutadoMes"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				tblResumen.Rows[0].Cells[3].InnerText = Convert.ToDouble(foundRows[0]["MontoSaldoMes"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
			else
			{
				tblResumen.Rows[0].Cells[1].InnerText = Convert.ToDouble(foundRows[0]["MontoPresupuestado"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				tblResumen.Rows[0].Cells[2].InnerText = Convert.ToDouble(foundRows[0]["MontoEjecutado"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				tblResumen.Rows[0].Cells[3].InnerText = Convert.ToDouble(foundRows[0]["MontoSaldo"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private DataTable ObtenerDatosMensual()
		{
			if (Page.Request.Params[KEYQPPTO].ToString()==VISTAPPTOPRINCIPAL)
			{
				return ((CPresupuesto) new  CPresupuesto()).ConsultarEvaluacionPrespuestalMensualPorGruposdeCentrosdeCosto(Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
					,Convert.ToInt32(Page.Request.Params[CENTROOPERATIVO])
					,Convert.ToInt32(Page.Request.Params[PERIODO])
					,Convert.ToInt32(Page.Request.Params[KEYQTIPOOPCION])
					,"real");
			}
			else
			{
				return ((CPresupuesto) new  CPresupuesto()).ConsultarEvaluacionMensualPorGruposdeCetrosdeCostoAuxiliar(Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
					,Convert.ToInt32(Page.Request.Params[CENTROOPERATIVO])
					,Convert.ToInt32(Page.Request.Params[PERIODO])
					,Convert.ToInt32(Page.Request.Params[KEYQTIPOOPCION])
					,"real");
			}
		}

		private void CargarResumenMensual()
		{
			DataRow[] foundRows;
			foundRows= this.ObtenerDatosMensual().Select("idGrupoCC = "+ Page.Request.Params[KEYQIDGRUPOCC].ToString()) ;
			for(int i=1;i<=12;i++){
				tblResumenMensual.Rows[0].Cells[i].InnerText = Convert.ToDouble(foundRows[0][Helper.ObtenerNombreMes(i,Utilitario.Enumerados.TipoDatoMes.NombreCompleto)]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}


		public void LlenarJScript()
		{
			this.ImgImprimir.Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()]=Helper.PopupDeEspera();
			imgXLS.Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()]=Helper.PopupDeEspera();
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DefaultCentrosdeCosto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DefaultCentrosdeCosto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DefaultCentrosdeCosto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DefaultCentrosdeCosto.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DefaultCentrosdeCosto.ValidarFiltros implementation
			return false;
		}

		#endregion

		bool Buscar(string Cadena,string valor){
			if(Cadena.Length==0){return false;}

			string [] arr=Cadena.Split(',');
			if(arr.Length>0){
				for(int i=0;i<=arr.Length-1;i++){
					if(arr[i].ToString()==valor){return true;}
				}
			}
			return false;
		}
		private void ImgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string Naturaleza ="";
			Naturaleza = ((Buscar(Naturaleza,"1")==false)? Naturaleza + ((Naturaleza.Length>0)?",1":"1"):"");
			Naturaleza = ((Buscar(Naturaleza,"3")==false)? Naturaleza + ((Naturaleza.Length>0)?",3":"3"):"");
			Naturaleza = ((Buscar(Naturaleza,"5")==false)? Naturaleza + ((Naturaleza.Length>0)?",5":"5"):"");

			DataTable dt1 =  (new CPresupuestoRequerimiento()).ConsultarDetalleMaterialesMesyCC(Convert.ToInt32(Page.Request.Params[KEYQPERIODO]),Convert.ToInt32(Page.Request.Params[CENTROOPERATIVO]), Convert.ToInt32(this.hIdCentroCostoSelect.Value),Naturaleza);
			if(dt1!=null)
			{
				Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\Presupuesto\","ListadeMaterialesPorCentroCostoMensual.rpt",dt1,false,true);
			}
			else{
					Helper.MsgBox("Reporte","No existen datos para este centro de costo",Utilitario.Enumerados.Ext.MessageBox.Button.OK,Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
			}
		}

		private void imgXLS_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			DataTable dto=(new CPresupuesto()).ListarPresupuestoToXLS(Convert.ToInt32(Page.Request.Params[PERIODO]),Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOCC]));
			try
			{
				DataView dv = dto.DefaultView;
				DataTable dt1 =  Helper.DataViewTODataTable(dv);
				dt1.TableName="FINuspNTADExportarPresupuestoXLS";
				DataSet dsSrc= new DataSet("Reportes");

				dsSrc.Tables.Add(dt1);
				Helper.Archivo.GenerarReporteToXls(305,dsSrc,true);

			}
			catch(Exception ex)
			{
				int i=0; 
				i++;
			}
		}
	}
}
