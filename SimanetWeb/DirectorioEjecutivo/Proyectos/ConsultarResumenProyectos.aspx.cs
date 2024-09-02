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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Proyectos
{
	public class ConsultarResumenProyectos : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		//const int IDTABLAESTADOCARTAFIANZA=5;
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkLinea";
		
		//const string URLDETALLEPORBANCO="ConsultarCartasdeCreditoporBancoDetalle.aspx?";
		const string URLPROYECTOSPORCENTRO="ConsultarProyectosPorCentroLinea.aspx?";
		const string URLCONSULTAROTS="ConsultarOTs_PorProyecto.aspx?";
		
		const string KEYFLAGLN_CO = "LN_CO";
		const string KEYIDLINEA = "idLinea";
		const string KEYIDCENTRO ="IdCentro";
		const string KEYLINEA = "Linea";
		const string KEYCENTRO ="Centro";
		const string KEYIDPROYECTO = "COD_PROYECTO";
		const string KEYPROYECTO = "PROYECTO";

		const string CAMPO1 = "lblMontoCallaoS";
		const string CAMPO3 = "lblMontoChimboteS";
		const string CAMPO5 = "lblMontoIquitosS";
		const string CAMPO7 = "lblMontoTotalS";
		const string TOTALIZA ="Totaliza";

		const string CONTROLHCALLAO = "lblhCallao";
		const string CONTROLHCHIMBOTE ="lblHChimbote";
		const string CONTROLHIQUITOS = "lblHIquitos";

		//Otros
		const string COLUMNALINEA ="linea";
		const string NOMBRECLASEFOOTERGRILLA ="FooterGrilla";

		const string MSGVERDTSC ="Ver detalle Sima-Callao";
		const string MSGVERDTSCH ="Ver detalle Sima-Chimbote";
		const string MSGVERDTSI ="Ver detalle Sima-Iquitos";

		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlbModalidadCartaCredito;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCentro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		ArrayList arrTotal;
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Proyectos-SIMA",this.ToString(),"Se consultó Resumen Proyectos.",Enumerados.NivelesErrorLog.I.ToString()));
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
			DataTable dt = oCProyectos.ConsultarResumenProyectos();

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
				//Session[TOTALIZA] = arrTotal;
			}
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				this.Totalizar(dtGeneral);
				DataView dwGeneral = dtGeneral.DefaultView;
				//dwGeneral.Sort = columnaOrdenar ;
				//dwGeneral.RowFilter = Helper.ObtenerFiltro();
				grid.DataSource = dwGeneral;
				grid.CurrentPageIndex = indicePagina;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + " " + dwGeneral.Count.ToString();

				/*CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtGeneral,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);*/
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
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarCartasdeCreditoporBanco.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarCartasdeCreditoporBanco.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCartasdeCreditoporBanco.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarCartasdeCreditoporBanco.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCartasdeCreditoporBanco.Exportar implementation
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
			// TODO:  Add ConsultarCartasdeCreditoporBanco.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			#region Header
			if(e.Item.ItemType == ListItemType.Header)
			{
				//SIMA CALLAO
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[2].FindControl(CONTROLHCALLAO),MSGVERDTSC,
					Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
					Helper.MostrarVentana(URLPROYECTOSPORCENTRO,KEYIDCENTRO +  Utilitario.Constantes.SIGNOIGUAL + "1"
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCALLAO
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYIDLINEA  + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Constantes.VACIO
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYFLAGLN_CO + Utilitario.Constantes.SIGNOIGUAL + "CO"
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
					));
				//SIMA CHIMBOTE
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[2].FindControl(CONTROLHCHIMBOTE),MSGVERDTSCH,
					Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
					Helper.MostrarVentana(URLPROYECTOSPORCENTRO,KEYIDCENTRO +  Utilitario.Constantes.SIGNOIGUAL + "2"
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCHIMBOTE
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYIDLINEA  + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Constantes.VACIO
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYFLAGLN_CO + Utilitario.Constantes.SIGNOIGUAL + "CO"
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
					));

				//SIMA IQUITOS
				Helper.ConfiguraColumnaHyperLink((Label)e.Item.Cells[2].FindControl(CONTROLHIQUITOS),MSGVERDTSI,
					Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
					Helper.MostrarVentana(URLPROYECTOSPORCENTRO,KEYIDCENTRO +  Utilitario.Constantes.SIGNOIGUAL + "3"
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROIQUITOS
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYIDLINEA  + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Constantes.VACIO
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYFLAGLN_CO + Utilitario.Constantes.SIGNOIGUAL + "CO"
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

				if (dr["lin_neg"].ToString() == "GD")
				{
					e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.MostrarVentana(URLCONSULTAROTS,
						KEYIDPROYECTO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIGNOLINEAVERTICAL + Utilitario.Constantes.SIGNOAMPERSON +
						KEYPROYECTO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIGNOLINEAVERTICAL + Utilitario.Constantes.SIGNOAMPERSON +
						KEYCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.VACIO + Utilitario.Constantes.SIGNOAMPERSON +
						KEYLINEA + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[1].Text + Utilitario.Constantes.SIGNOAMPERSON  +
						Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
						));
				}
				else
				{
					e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.MostrarVentana(URLPROYECTOSPORCENTRO,
						KEYLINEA + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[1].Text
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYIDLINEA  + Utilitario.Constantes.SIGNOIGUAL +  dr["lin_neg"].ToString()  
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.VACIO
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYFLAGLN_CO + Utilitario.Constantes.SIGNOIGUAL + "LN"
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
						));
				}

				e.Item.Cells[1].Font.Underline=true;	
				e.Item.Cells[1].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hCodigo"));
			
				((Label)e.Item.Cells[2].FindControl(CAMPO1)).Text=  Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.callao.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[3].FindControl(CAMPO3)).Text=  Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.chimbote.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[4].FindControl(CAMPO5)).Text=  Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.iquitos.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[5].FindControl(CAMPO7)).Text=  Convert.ToDouble(dr[Enumerados.FINColumnaCartaCreditoResumen.total.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}	
			#endregion

			#region FOOTER
			if (e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[0].ColumnSpan=2;
				e.Item.Cells[0].CssClass = NOMBRECLASEFOOTERGRILLA;
				e.Item.Cells[1].Visible=false;

				//ArrayList arrTotal = (ArrayList) Session[TOTALIZA];
				string []NombreControlLbl = {"lblFMontoCallaoS","lblFMontoChimboteS","lblFMontoIquitosS","lblFMontoTotalS"};
				int []ColPoslLbl = {2,3,4,5};
				for(int i=0;i<=NombreControlLbl.Length-1;i++)
				{
					((Label) e.Item.Cells[ColPoslLbl[i]].FindControl(NombreControlLbl[i].ToString())).Text= Convert.ToDouble(arrTotal[i]).ToString(Utilitario.Constantes.FORMATODECIMAL4);;
				}
				//Session[TOTALIZA]=null;
			}
			#endregion
			
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}


		private void RedireccionarPaginaPrincipal()
		{
		}
	}
}
