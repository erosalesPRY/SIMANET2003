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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio
{
	/// <summary>
	/// Summary description for ConsultarDetalleGastosdeAdministracionPorCentroOperativo.
	/// </summary>
	public class ConsultarDetalleGastosdeAdministracionPorCentroOperativo : System.Web.UI.Page,IPaginaMantenimento,IPaginaBase
	{
		#region controles
		protected System.Web.UI.WebControls.Label lblConcepto;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region constantes
		const string KEYQIDPERIODO = "Periodo";
		const string KEYQIDMES = "mes";
		const string KEYIDCUENTA = "Cta5Dig";
		const string KEYIDCENTRO ="idCC";


		const string KEYQIDEMPRESA = "idEmp";
		const string KEYQESOBSERVACION="Observacion";
		const string  KEYQIDCENTROOPERATIVO="IdCentroOperativo";
		const string  KEYQIDFECHA = "efFecha";
		const string  KEYQDIGRPNG="DigGrupoNG";
		const string  KEYMODOPAGINA = "Modo";
		const string  KEYQCUENTACONTABLE="CuentaContable";
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQNOMBRECUENTA="NombreCuenta";
		const string  KEYQDIDGRUPOCC="Idgrupocc";
		const string  KEYQIDCENTROCOSTO = "IdCentroCosto";
		const string  KEYQPERIODO = "periodo";
		const string KEYQIDOBSERVACION="IdObservacion";
		const string URLPAGINAADMINISTRACIONORBSERVACION="DetalleAdministrarObservacionesEstadosFinancieros.aspx?";
		const string URLDETALLEMOVIMIENTOSPORCENTROCOSTO="../../../GestionFinanciera/Presupuesto/ConsultarMovimientoMaterialesoServiciosPorCentroCosto.aspx?";
		#endregion


		#region otras
		const string KEYQNUEVOSSOLES = "MILNS";
		const string ALERTA = "../../../imagenes/alert.gif";
		const string CONTROLIMGBUTTON = "imgCaducidad";
		
		//const string KEYIDCENTRO ="IdCentro";
		const string NOMBRECENTRO ="NombreCentro";
		

		const string NOMBRETIPOOPCION ="NombreOpcion";
		const string KEYQIDNOMBREFORMATO = "NFormato";
			

		const string KEYQIDNOMBREMES = "NombreMes";
		const string COLUMNAIDRUBRO ="idRubro";


		const string KEYQNOMBRERUBRO ="NRubro";

		const string KEYQNRODIGITOS ="NroDig";
		const string KEYQDIGCUENTA = "DigCuenta";

		const string VARIABLETOTALIZA ="Totaliza";
		#endregion

		#region Labels
		const string LBLDELMESREAL = "lblDelMesReal";
		const string LBLDELMESPPTO= "lblDelMesPPTO";
		const string LBLDELMESVAR= "lblDelMesVar";

		const string LBLACUMREAL= "lblAcumReal";
		const string LBLACUMPPTO= "lblAcumPPTO";
		protected System.Web.UI.HtmlControls.HtmlTextArea campo1;
		protected System.Web.UI.WebControls.Label Label2;
		const string LBLACUMVAR= "lblAcumVar";
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();
					this.LlenarGrilla(0);
				}				
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
				string debug = oException.Message.ToString();
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
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dtEstadoFinanciero = this.ObtenerDatos();
			
			if(dtEstadoFinanciero!=null)
			{
				this.Totalizar(dtEstadoFinanciero);
				
				grid.DataSource = dtEstadoFinanciero;
				
			}
			else
			{
				grid.DataSource = dtEstadoFinanciero;


			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblConcepto.Text=Page.Request.QueryString[KEYQNOMBRECUENTA].ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarDetalleGastosdeAdministracionPorCentroOperativo.ValidarFiltros implementation
			return false;
		}

		#endregion

		private DataTable ObtenerDatos()
		{
			
			return ((CEstadosFinancieros) new  CEstadosFinancieros()).ConsultarCentroCostoGastosdeAdministracionporNaturalezadeGastoPorCuentaContable5dig(Convert.ToInt32(Page.Request.QueryString[KEYQIDEMPRESA])
				,Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO])
				,Convert.ToDateTime(Page.Request.QueryString[KEYQIDFECHA]).Year
				,Convert.ToDateTime(Page.Request.QueryString[KEYQIDFECHA]).Month
				,Convert.ToInt32(Page.Request.QueryString[KEYQDIGRPNG])
				,Convert.ToInt32(Page.Request.QueryString[KEYQCUENTACONTABLE])
				,Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO]));
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{

				Label lblmes = (Label)e.Item.Cells[1].FindControl("lblDelMes");
				lblmes.Text = Helper.ObtenerNombreMes(Convert.ToDateTime(Page.Request.QueryString[KEYQIDFECHA]).Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();

			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
								
				#region Administracion Obs.	
				if(Convert.ToInt32(Session[Utilitario.Constantes.KEYQOBSERVACION])==1)
				{
					e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
					e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
					e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;

					string modoPagina="";
					if(dr["observacion"].ToString()==String.Empty)
					{
						modoPagina =Enumerados.ModoPagina.N.ToString();
					}
					else
					{
						modoPagina =Enumerados.ModoPagina.M.ToString();
					}
					string parametros =KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDFORMATO].ToString() +
						Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCENTROOPERATIVO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQDIDGRUPOCC +  Utilitario.Constantes.SIGNOIGUAL + dr["idgrupocentrocosto"].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDCENTROCOSTO +  Utilitario.Constantes.SIGNOIGUAL + dr["idcentrocosto"].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + dr["periodo"].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDFECHA + Utilitario.Constantes.SIGNOIGUAL + Convert.ToDateTime(Page.Request.QueryString[KEYQIDFECHA]).Month.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQCUENTACONTABLE].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL 
						+ modoPagina
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDOBSERVACION + Utilitario.Constantes.SIGNOIGUAL + dr["idobservacion"].ToString();


					e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLPAGINAADMINISTRACIONORBSERVACION + parametros,600,400));
					System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[4].FindControl(CONTROLIMGBUTTON);	
					if (Convert.ToString(dr["observacion"])== String.Empty)
					{
						ibtn1.ImageUrl = ALERTA;
					}
					else
					{
						ibtn1.Visible = false;
					}
				}
				#endregion

				#region Asignacion de Montos por Columnas
				Label lbl;
				lbl = (Label) e.Item.Cells[2].FindControl(LBLDELMESREAL);
				lbl.Text = Convert.ToDouble(dr["EjecucionRealDelmesActual"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				lbl = (Label) e.Item.Cells[2].FindControl(LBLDELMESPPTO);
				lbl.Text = Convert.ToDouble(dr["PresupuestoDelMesActual"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				lbl = (Label) e.Item.Cells[2].FindControl(LBLDELMESVAR);
				lbl.Text = dr["VariaciondelMes"].ToString();
				//lbl.Text = (lbl.Text.Substring(0,1).Equals("S")==true)?lbl.Text: Convert.ToDouble(lbl.Text).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				if(lbl.Text.Substring(0,1).Equals("S")==true)
				{
					lbl.Text=dr["VariaciondelMes"].ToString();
				}
				else
				{
					if(Convert.ToDouble(lbl.Text)<0)
					{
						lbl.Text=Convert.ToDouble(Convert.ToDouble(lbl.Text)*-1).ToString();
						lbl.ForeColor=System.Drawing.Color.Red;
					}
					lbl.Text = Convert.ToDouble(lbl.Text).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				}
				lbl = (Label) e.Item.Cells[3].FindControl(LBLACUMREAL);
				lbl.Text = Convert.ToDouble(dr["EjecucionRealAcumulado"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);


				lbl = (Label) e.Item.Cells[3].FindControl(LBLACUMPPTO);
				lbl.Text = Convert.ToDouble(dr["PresupuestoAcumulado"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);


				lbl = (Label) e.Item.Cells[3].FindControl(LBLACUMVAR);
				lbl.Text = dr["VariacionAcumulada"].ToString();
				//lbl.Text = (lbl.Text.Substring(0,1).Equals("S")==true)?lbl.Text: Convert.ToDouble(lbl.Text).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				if(lbl.Text.Substring(0,1).Equals("S")==true)
				{
					lbl.Text=dr["VariacionAcumulada"].ToString();
				}
				else
				{
					if(Convert.ToDouble(lbl.Text)<0)
					{
						lbl.Text=Convert.ToDouble(Convert.ToDouble(lbl.Text)*-1).ToString();
						lbl.ForeColor=System.Drawing.Color.Red;

					}
					lbl.Text = Convert.ToDouble(lbl.Text).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				}
						
				#endregion

				string parametrosDetalleMovimiento="";

				 parametrosDetalleMovimiento =KEYQIDPERIODO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToDateTime(Page.Request.QueryString[KEYQIDFECHA]).Year.ToString() +
					Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQIDMES + Utilitario.Constantes.SIGNOIGUAL + Convert.ToDateTime(Page.Request.QueryString[KEYQIDFECHA]).Month.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 	
					+ KEYIDCUENTA +  Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQCUENTACONTABLE].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 	
					+ KEYIDCENTRO +  Utilitario.Constantes.SIGNOIGUAL +dr["idcentrocosto"].ToString();

				e.Item.Cells[1].Font.Underline=true;
				e.Item.Cells[1].ForeColor = System.Drawing.Color.Blue;
				e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentanaDialogo(URLDETALLEMOVIMIENTOSPORCENTROCOSTO + parametrosDetalleMovimiento,800,300));
				
				
			Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("campo1",dr["observacion"].ToString()));
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				const string SUBF = "F";
				ArrayList arrTotal = new ArrayList();
				arrTotal =(ArrayList) Session[VARIABLETOTALIZA];

				Label lbl;
				lbl = (Label) e.Item.Cells[2].FindControl(LBLDELMESREAL+SUBF);
				lbl.Text = Convert.ToDouble(arrTotal[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				lbl = (Label) e.Item.Cells[2].FindControl(LBLDELMESPPTO+SUBF);
				lbl.Text = Convert.ToDouble(arrTotal[1]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				lbl = (Label) e.Item.Cells[3].FindControl(LBLACUMREAL+SUBF);
				lbl.Text = Convert.ToDouble(arrTotal[2]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				lbl = (Label) e.Item.Cells[3].FindControl(LBLACUMPPTO+SUBF);
				lbl.Text = Convert.ToDouble(arrTotal[3]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

			}


		}
		private void Totalizar(DataTable dtOrigen)
		{
			if (dtOrigen !=null)
			{
				ArrayList arrTotal = new ArrayList();
				double MontoTotal = Helper.TotalizarDataView(dtOrigen.DefaultView,"EjecucionRealDelmesActual")[0];
				arrTotal.Add(MontoTotal);
				MontoTotal = Helper.TotalizarDataView(dtOrigen.DefaultView,"PresupuestoDelMesActual")[0];
				arrTotal.Add(MontoTotal);
				/**/
				MontoTotal = Helper.TotalizarDataView(dtOrigen.DefaultView,"EjecucionRealAcumulado")[0];
				arrTotal.Add(MontoTotal);
				MontoTotal = Helper.TotalizarDataView(dtOrigen.DefaultView,"PresupuestoAcumulado")[0];
				arrTotal.Add(MontoTotal);
				Session[VARIABLETOTALIZA] = arrTotal;
			}
		}

		public void LlenarGrilla(int indice)
		{
			DataTable dtEstadoFinanciero = this.ObtenerDatos();
			
			if(dtEstadoFinanciero!=null)
			{
				this.Totalizar(dtEstadoFinanciero);
				grid.DataSource = dtEstadoFinanciero;
				if(Convert.ToInt32(Session["OBSERVACION"])==1)
				{
					grid.Columns[0].Visible=true;
					grid.Columns[4].Visible=true;
				}
				grid.CurrentPageIndex=indice;
				
			}
			else
			{
				grid.DataSource = dtEstadoFinanciero;


			}
			grid.DataBind();
		}
		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			LlenarGrilla(e.NewPageIndex);
		}

		
		
	}
}
