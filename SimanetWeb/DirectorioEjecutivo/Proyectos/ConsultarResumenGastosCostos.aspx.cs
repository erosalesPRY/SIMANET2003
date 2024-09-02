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
using SIMA.Controladoras.General;
using SIMA.Controladoras.Proyectos;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Proyectos
{
	public class ConsultarResumenGastosCostos : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkLinea";
		
		const string URLPROYECTOSPORCENTRO_MES="ConsultarGastosCostosPorCO.aspx?";
		const string URLPROYECTOSPORCENTRO_ANO="ConsultarGastosCostosPorCO_Ano.aspx?";
		
		const string KEYIDCENTRO ="IdCentro";
		const string KEYCENTRO ="Centro";
		const string KEYANO ="Ano";

		const string CAMPO1 = "lblMontoCallaoS";
		const string CAMPO3 = "lblMontoChimboteS";
		const string CAMPO5 = "lblMontoIquitosS";
		const string CAMPO7 = "lblMontoTotalS";
		const string TOTALIZA ="Totaliza";

		const string CONTROLHCALLAO_MES = "lblSC_MES";
		const string CONTROLHCALLAO_ANO = "lblSC_ANO";
		const string CONTROLHCHIMBOTE_MES = "lblSCH_MES";
		const string CONTROLHCHIMBOTE_ANO = "lblSCH_ANO";
		const string CONTROLHIQUITOS_MES = "lblSI_MES";
		const string CONTROLHIQUITOS_ANO = "lblSI_ANO";

		//Otros
		const string COLUMNALINEA ="linea";
		const string NOMBRECLASEFOOTERGRILLA ="FooterGrilla";

		const string MSGVERDTSC_MES ="Ver Comparativo por Meses Sima-Callao";
		const string MSGVERDTSC_ANO ="Ver Comparativo por Años Sima-Callao";
		const string MSGVERDTSCH_MES ="Ver Comparativo por Meses Sima-Chimbote";
		const string MSGVERDTSCH_ANO ="Ver Comparativo por Años Sima-Chimbote";
		const string MSGVERDTSI_MES ="Ver Comparativo por Meses Sima-Iquitos";
		const string MSGVERDTSI_ANO ="Ver Comparativo por Años Sima-Iquitos";

		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		ListItem item;

		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCentro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;

		ArrayList arrTotal;
		double PorcIndirectoSC1;
		double PorcIndirectoSC2;
		double PorcIndirectoSCH1;
		double PorcIndirectoSCH2;
		double PorcIndirectoSI1;
		double PorcIndirectoSI2;
		double PorcIndirectoTOT1;
		protected System.Web.UI.WebControls.DropDownList ddlbAño;
		protected System.Web.UI.WebControls.Label lblAño;
		double PorcIndirectoTOT2;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gastos y Costos SIMA",this.ToString(),"Se consultó Resumen Proyectos.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion("",Utilitario.Constantes.INDICEPAGINADEFAULT);
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
			// Put user code to initialize the page here
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
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ddlbAño.SelectedIndexChanged += new System.EventHandler(this.ddlbAño_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarCartasdeCreditoporBanco.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCartasdeCreditoporBanco.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			CProyectos oCProyectos= new CProyectos();
			DataTable dt = oCProyectos.ConsultarResumenCostosGastos(Convert.ToInt32(ddlbAño.SelectedValue));

			if(dt != null)
			{
				DataColumn clT;
				clT = new DataColumn("total", typeof(double),"Callao + Chimbote + Iquitos");
				dt.Columns.Add(clT);
			}
			return dt;
		}
		private void Totalizar(DataTable dtOrigen)
		{
			if (dtOrigen !=null)
			{
				arrTotal = new ArrayList();
				double []TotalCallao = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.INT_ProyectosColumnas.callao.ToString());
				arrTotal.Add(TotalCallao[0]);
				double []TotalChimbote = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.INT_ProyectosColumnas.chimbote.ToString());
				arrTotal.Add(TotalChimbote[0]);
				double []TotalIquitos = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.INT_ProyectosColumnas.iquitos.ToString());
				arrTotal.Add(TotalIquitos[0]);
				double []TotalTotal = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.INT_ProyectosColumnas.total.ToString());
				arrTotal.Add(TotalTotal[0]);
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				this.Totalizar(dtGeneral);
				DataView dwGeneral = dtGeneral.DefaultView;
				grid.DataSource = dwGeneral;
				grid.CurrentPageIndex = indicePagina;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + " " + dwGeneral.Count.ToString();

				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = true;
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
			this.llenarAños();
		}

		private void llenarAños()
		{
			CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			ddlbAño.DataSource = oCPeriodoContable.ListarTodosPeriodo();
			ddlbAño.DataValueField="Periodo";
			ddlbAño.DataTextField="Periodo";
			ddlbAño.DataBind();
			
			item = ddlbAño.Items.FindByText(Helper.FechaSimanet.ObtenerFechaSesion().Year.ToString());
			if (item !=null){item.Selected = true;}
		}

		public void LlenarDatos()
		{
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
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}	
		}

		public bool ValidarFiltros()
		{
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			#region Header
			if(e.Item.ItemType == ListItemType.Header)
			{
				//SIMA CALLAO
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[2].FindControl(CONTROLHCALLAO_MES),MSGVERDTSC_MES,
					Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
					Helper.MostrarVentana(URLPROYECTOSPORCENTRO_MES,KEYIDCENTRO +  Utilitario.Constantes.SIGNOIGUAL + "1"
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCALLAO
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYANO + Utilitario.Constantes.SIGNOIGUAL + ddlbAño.SelectedValue
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
					));

				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[2].FindControl(CONTROLHCALLAO_ANO),MSGVERDTSC_ANO,
					Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
					Helper.MostrarVentana(URLPROYECTOSPORCENTRO_ANO,KEYIDCENTRO +  Utilitario.Constantes.SIGNOIGUAL + "1"
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCALLAO
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYANO + Utilitario.Constantes.SIGNOIGUAL + ddlbAño.SelectedValue
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
					));

				//SIMA CHIMBOTE
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[3].FindControl(CONTROLHCHIMBOTE_MES),MSGVERDTSCH_MES,
					Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
					Helper.MostrarVentana(URLPROYECTOSPORCENTRO_MES,KEYIDCENTRO +  Utilitario.Constantes.SIGNOIGUAL + "2"
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCHIMBOTE
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYANO + Utilitario.Constantes.SIGNOIGUAL + ddlbAño.SelectedValue
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
					));

				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[3].FindControl(CONTROLHCHIMBOTE_ANO),MSGVERDTSCH_ANO,
					Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
					Helper.MostrarVentana(URLPROYECTOSPORCENTRO_ANO,KEYIDCENTRO +  Utilitario.Constantes.SIGNOIGUAL + "2"
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCHIMBOTE
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYANO + Utilitario.Constantes.SIGNOIGUAL + ddlbAño.SelectedValue
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
					));

				//SIMA IQUITOS
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[4].FindControl(CONTROLHIQUITOS_MES),MSGVERDTSI_MES,
					Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
					Helper.MostrarVentana(URLPROYECTOSPORCENTRO_MES,KEYIDCENTRO +  Utilitario.Constantes.SIGNOIGUAL + "3"
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROIQUITOS
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYANO + Utilitario.Constantes.SIGNOIGUAL + ddlbAño.SelectedValue
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
					));

				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[4].FindControl(CONTROLHIQUITOS_ANO),MSGVERDTSI_ANO,
					Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
					Helper.MostrarVentana(URLPROYECTOSPORCENTRO_ANO,KEYIDCENTRO +  Utilitario.Constantes.SIGNOIGUAL + "3"
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROIQUITOS
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYANO + Utilitario.Constantes.SIGNOIGUAL + ddlbAño.SelectedValue
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
					));

			}			
			#endregion

			#region ITEM
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				if (e.Item.Cells[0].Text == "1")
				{
					PorcIndirectoSC1 = Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.callao.ToString()]);
					PorcIndirectoSCH1 = Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.chimbote.ToString()]);
					PorcIndirectoSI1 = Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.iquitos.ToString()]);
					PorcIndirectoTOT1 = Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.total.ToString()]);
				}

				if (e.Item.Cells[0].Text == "2")
				{
					PorcIndirectoSC2 = Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.callao.ToString()]);
					PorcIndirectoSCH2 = Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.chimbote.ToString()]);
					PorcIndirectoSI2 = Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.iquitos.ToString()]);
					PorcIndirectoTOT2 = Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.total.ToString()]);
				}

				((Label)e.Item.Cells[2].FindControl(CAMPO1)).Text=  Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.callao.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[3].FindControl(CAMPO3)).Text=  Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.chimbote.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[4].FindControl(CAMPO5)).Text=  Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.iquitos.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[5].FindControl(CAMPO7)).Text=  Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.total.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				if (e.Item.Cells[0].Text == "3")
				{
					((Label)e.Item.Cells[2].FindControl(CAMPO1)).Text =  Convert.ToDouble((PorcIndirectoSC2*100)/PorcIndirectoSC1).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					((Label)e.Item.Cells[3].FindControl(CAMPO3)).Text =  Convert.ToDouble((PorcIndirectoSCH2*100)/PorcIndirectoSC1).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					((Label)e.Item.Cells[4].FindControl(CAMPO5)).Text =  Convert.ToDouble((PorcIndirectoSI2*100)/PorcIndirectoSI1).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					((Label)e.Item.Cells[5].FindControl(CAMPO7)).Text =  Convert.ToDouble((PorcIndirectoTOT2*100)/PorcIndirectoTOT1).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}	
			#endregion

			#region FOOTER
			if (e.Item.ItemType == ListItemType.Footer)
			{
				string []NombreControlLbl = {"lblFMontoCallaoS","lblFMontoChimboteS","lblFMontoIquitosS","lblFMontoTotalS"};
				for(int i=0;i<=NombreControlLbl.Length-1;i++)
				{
					((Label) e.Item.Cells[i+1].FindControl(NombreControlLbl[i].ToString())).Text= Convert.ToDouble(arrTotal[i]).ToString(Utilitario.Constantes.FORMATODECIMAL4);;
				}
			}
			#endregion
			
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void ddlbAño_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion("",Utilitario.Constantes.INDICEPAGINADEFAULT);		
		}
	}
}
