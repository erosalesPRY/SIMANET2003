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
	/// Summary description for ConsultarGastosdeAdministracionPorCentroOperativo.
	/// </summary>
	public class ConsultarGastosdeAdministracionPorCentroOperativo : System.Web.UI.Page,IPaginaBase
	{


		#region otras
			const string KEYQNUEVOSSOLES = "MILNS";

			const string KEYQIDEMPRESA = "idEmp";
			const string KEYIDCENTRO ="IdCentroOperativo";
			const string NOMBRECENTRO ="NombreCentro";
			const string KEYQIDFECHA = "efFecha";
			const string KEYQIDOBSERVACION="IdObservacion";
			const string KEYQDESCRIPCIONOBSERVACION="DescripcionObservacion";

			const string NOMBRETIPOOPCION ="NombreOpcion";
			const string KEYQIDNOMBREFORMATO = "NFormato";
			
			const string KEYQIDFORMATO = "IdFormato";
			const string  KEYQPERIODO = "periodo";
			const string KEYQIDRUBRO = "IdRubro";
			const string KEYQIDNOMBREMES = "NombreMes";
			const string COLUMNAIDRUBRO ="idRubro";
			const string URLPAGINAADMINISTRACIONORBSERVACION="DetalleAdministrarObservacionesEstadosFinancieros.aspx?";
			const string  KEYQCUENTACONTABLE="CuentaContable";
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
			const string LBLACUMVAR= "lblAcumVar";
		const string ALERTA = "../../../imagenes/alert.gif";
		const string CONTROLIMGBUTTON = "imgCaducidad";
		#endregion
		#region Controles
			protected System.Web.UI.WebControls.Label Label3;
			protected System.Web.UI.WebControls.Label lblPeriodo;
			protected System.Web.UI.WebControls.Label Label2;
			protected System.Web.UI.WebControls.Label lblMes;
			protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblConcepto;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.HtmlControls.HtmlTextArea campo1;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion



		protected int Periodo
		{
			get
			{
				return Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year;
			}
		}
		protected DateTime FechaPeriodo
		{
			get
			{
				return Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year,Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month) + Utilitario.Constantes.SEPARADORFECHA + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month.ToString().PadLeft(2,'0') + Utilitario.Constantes.SEPARADORFECHA + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year.ToString());
			}
		}
		protected int idMes
		{
			get
			{
				return Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month;
			}
		}

		protected int idCentroOperativo
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]);
			}
		}

		protected int idEmpresa
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA]);
			}
		}
		protected string NombreRubro
		{
			get
			{
				return Page.Request.Params[KEYQNOMBRERUBRO].ToString();
			}
		}

		

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
					this.LlenarGrilla();
					
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		#region IPaginaBase Members

		private DataTable ObtenerDatos()
		{
			return ((CEstadosFinancieros) new  CEstadosFinancieros()).ConsultarGastosdeAdministracionPorCentrodeCosto3Dig
																														(this.idEmpresa
																														,this.idCentroOperativo
																														,this.Periodo
																														,this.idMes
																														,Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO])
																														,Convert.ToInt32(Page.Request.QueryString[KEYQIDRUBRO]));			
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

		public void LlenarGrilla()
		{
			DataTable dtEstadoFinanciero = this.ObtenerDatos();
			
			if(dtEstadoFinanciero!=null)
			{
				this.Totalizar(dtEstadoFinanciero);
				if(Convert.ToInt32(Session[Utilitario.Constantes.KEYQOBSERVACION])==1)
				{
					
					grid.Columns[3].Visible=true;
				}
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
			// TODO:  Add ConsultarGastosdeAdministracionPorCentroOperativo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarGastosdeAdministracionPorCentroOperativo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarGastosdeAdministracionPorCentroOperativo.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblConcepto.Text = this.NombreRubro.ToUpper();
			this.lblPeriodo.Text = this.Periodo.ToString();
			this.lblMes.Text= Helper.ObtenerNombreMes(this.idMes,SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarGastosdeAdministracionPorCentroOperativo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarGastosdeAdministracionPorCentroOperativo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarGastosdeAdministracionPorCentroOperativo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarGastosdeAdministracionPorCentroOperativo.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarGastosdeAdministracionPorCentroOperativo.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarGastosdeAdministracionPorCentroOperativo.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string parametros="";
			if(e.Item.ItemType == ListItemType.Header)
			{
				//lblDelMes
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"MostrarValor('"+Session["DETALLEOBS"].ToString().Trim()+"'),"+ Utilitario.Constantes.CAMBIARCOLORSELECCIONGRILLAPOPUP );
				e.Item.Cells[0].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);	

				Label lblmes = (Label)e.Item.Cells[1].FindControl("lblDelMes");
				lblmes.Text = Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
				
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				//e.Item.Attributes.Add("CuentaContable3Dig",dr["CuentaContable3Dig"].ToString());
				e.Item.Attributes.Add("idGrupoNG",dr["idCuentaContableGrupo"].ToString());
				e.Item.Cells[0].Controls.Add(Helper.CrearNodoRaiz(e,dr["CuentaContableGrupo"].ToString() + "-" + e.Item.Cells[0].Text,"ObtenerDetalleDeCentrosdeCostoPorNaturaleza" ,true));
				
				#region admObservaciones
				if(Convert.ToInt32(Session[Utilitario.Constantes.KEYQOBSERVACION])==1)
				{
					

					string modoPagina="";
					if(dr["observacion"].ToString()==String.Empty)
					{
						modoPagina =Enumerados.ModoPagina.N.ToString();
					}
					else
					{
						modoPagina =Enumerados.ModoPagina.M.ToString();
					}
					 parametros =KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDFORMATO].ToString() +
						Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + this.idCentroOperativo.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Periodo.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDFECHA + Utilitario.Constantes.SIGNOIGUAL + this.idMes.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDRUBRO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + dr["CuentaContableGrupo"].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL 
						+ modoPagina
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDOBSERVACION + Utilitario.Constantes.SIGNOIGUAL + dr["idobservacion"].ToString();

					
					System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[3].FindControl(CONTROLIMGBUTTON);	
					
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
					lbl = (Label) e.Item.Cells[1].FindControl(LBLDELMESREAL);
					lbl.Text = Convert.ToDouble(dr["EjecucionRealDelmesActual"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					if(Convert.ToInt32(Session[Utilitario.Constantes.KEYQOBSERVACION])==1)
					{
						
						lbl.Font.Underline=true;
						lbl.ForeColor = System.Drawing.Color.Blue;
						lbl.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLPAGINAADMINISTRACIONORBSERVACION + parametros,500,400));
					}
					lbl = (Label) e.Item.Cells[1].FindControl(LBLDELMESPPTO);
					lbl.Text = Convert.ToDouble(dr["PresupuestoDelMesActual"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);



					lbl = (Label) e.Item.Cells[1].FindControl(LBLDELMESVAR);
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
					lbl = (Label) e.Item.Cells[2].FindControl(LBLACUMREAL);
					lbl.Text = Convert.ToDouble(dr["EjecucionRealAcumulado"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);


					lbl = (Label) e.Item.Cells[2].FindControl(LBLACUMPPTO);
					lbl.Text = Convert.ToDouble(dr["PresupuestoAcumulado"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);


					lbl = (Label) e.Item.Cells[2].FindControl(LBLACUMVAR);
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

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("campo1",dr["observacion"].ToString()));
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				const string SUBF = "F";
				ArrayList arrTotal = new ArrayList();
				arrTotal =(ArrayList) Session[VARIABLETOTALIZA];

				Label lbl;
				lbl = (Label) e.Item.Cells[1].FindControl(LBLDELMESREAL+SUBF);
				lbl.Text = Convert.ToDouble(arrTotal[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				lbl = (Label) e.Item.Cells[1].FindControl(LBLDELMESPPTO+SUBF);
				lbl.Text = Convert.ToDouble(arrTotal[1]).ToString(Utilitario.Constantes.FORMATODECIMAL4);



				/*lbl = (Label) e.Item.Cells[1].FindControl(LBLDELMESVAR);
				lbl.Text = dr["VariaciondelMes"].ToString();
				lbl.Text = (lbl.Text.Substring(0,1).Equals("S")==true)?lbl.Text: Convert.ToDouble(lbl.Text).ToString(Utilitario.Constantes.FORMATODECIMAL5);
*/

				lbl = (Label) e.Item.Cells[2].FindControl(LBLACUMREAL+SUBF);
				lbl.Text = Convert.ToDouble(arrTotal[2]).ToString(Utilitario.Constantes.FORMATODECIMAL4);


				lbl = (Label) e.Item.Cells[2].FindControl(LBLACUMPPTO+SUBF);
				lbl.Text = Convert.ToDouble(arrTotal[3]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

/*
				lbl = (Label) e.Item.Cells[2].FindControl(LBLACUMVAR);
				lbl.Text = dr["VariacionAcumulada"].ToString();
				lbl.Text = (lbl.Text.Substring(0,1).Equals("S")==true)?lbl.Text: Convert.ToDouble(lbl.Text).ToString(Utilitario.Constantes.FORMATODECIMAL5);

*/
			}
		}
	}
}
