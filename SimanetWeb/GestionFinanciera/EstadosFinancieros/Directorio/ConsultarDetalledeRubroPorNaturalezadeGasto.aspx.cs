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
/*Libreria para Trabajar con excel*/
//using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio
{
	/// Application app = new Application();
	/// Microsoft.Office.Interop.Excel.Workbook libro = app.Workbooks.Add(System.Reflection.Missing.Value);


	/// Summary description for ConsultarDetalledeRubroPorNaturalezadeGasto.
	/// </summary>
	public class ConsultarDetalledeRubroPorNaturalezadeGasto : System.Web.UI.Page,IPaginaBase
	{
		#region otras
		const string KEYQNUEVOSSOLES = "MILNS";

		const string KEYQIDEMPRESA = "idEmp";
		const string KEYIDCENTRO ="IdCentro";
		const string KEYIDCENTROOPERATIVO ="IdCentroOperativo";
		const string NOMBRECENTRO ="NombreCentro";
		const string KEYQIDFECHA = "efFecha";

		const string KEYQIDNOMBREMES = "NombreMes";
		const string COLUMNAIDRUBRO ="idRubro";

		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDNOMBREFORMATO = "NFormato";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQNOMBRERUBRO ="NRubro";
		const string  KEYQPERIODO = "periodo";
		const string KEYQIDOBSERVACION="IdObservacion";
		const string URLPAGINAADMINISTRACIONORBSERVACION="DetalleAdministrarObservacionesEstadosFinancieros.aspx?";
		const string KEYQNRODIGITOS ="NroDig";
		const string KEYQDIGCUENTA = "DigCuenta";
		const string ALERTA = "../../../imagenes/alert.gif";
		const string CONTROLIMGBUTTON = "imgCaducidad";
		const string VARIABLETOTALIZA ="Totaliza";
		const string  KEYQCUENTACONTABLE="CuentaContable";
		#endregion

		#region Labels
			const string LBLDELMES = "lblDelMes";
			const string LBLDELMESREAL = "lblDelMesReal";
			const string LBLDELMESPPTO= "lblDelMesPPTO";
			const string LBLDELMESVAR= "lblDelMesVar";

			const string LBLACUMREAL= "lblAcumReal";
			const string LBLACUMPPTO= "lblAcumPPTO";
			const string LBLACUMVAR= "lblAcumVar";
		#endregion

		#region Atributos
		protected DateTime Fecha
		{
			get
			{
				return Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]);
			}
		}
		
		protected int idCentroOperativo
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYIDCENTROOPERATIVO]);
			}
		}

		protected int idEmpresa
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA]);
			}
		}
		protected int idFormato
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
			}
		}
		protected int idRubro
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]);
			}
		}

		protected string NombreRubro
		{
			get
			{
				return Page.Request.Params[KEYQNOMBRERUBRO].ToString();
			}
		}
		#endregion

		#region Controles
			protected System.Web.UI.WebControls.Label Label4;
			protected System.Web.UI.WebControls.Label lblConcepto;
			protected System.Web.UI.WebControls.Label Label3;
			protected System.Web.UI.WebControls.Label lblPeriodo;
			protected System.Web.UI.WebControls.Label Label2;
			protected System.Web.UI.WebControls.Label lblMes;
			protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlTextArea campo1;
		protected System.Web.UI.WebControls.Label Label11;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
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

		#region IPaginaBase Members


		private DataTable ObtenerDatos()
		{
			return ((CEstadosFinancieros) new  CEstadosFinancieros()).ConsultarDetalledeRubroPorNaturalezadeGasto3Dig
																											(this.Fecha
																											,this.idFormato
																											,this.idRubro
																											,this.idEmpresa
																											,this.idCentroOperativo);
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
			// TODO:  Add ConsultarDetalledeRubroPorNaturalezadeGasto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarDetalledeRubroPorNaturalezadeGasto.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarDetalledeRubroPorNaturalezadeGasto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblConcepto.Text= this.NombreRubro.ToString().ToUpper();
			this.lblPeriodo.Text = this.Fecha.Year.ToString();
			this.lblMes.Text = Helper.ObtenerNombreMes(this.Fecha.Month,SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarDetalledeRubroPorNaturalezadeGasto.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarDetalledeRubroPorNaturalezadeGasto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarDetalledeRubroPorNaturalezadeGasto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarDetalledeRubroPorNaturalezadeGasto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarDetalledeRubroPorNaturalezadeGasto.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarDetalledeRubroPorNaturalezadeGasto.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"MostrarValor(),"+ Utilitario.Constantes.CAMBIARCOLORSELECCIONGRILLAPOPUP );
				e.Item.Cells[0].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);	

				((Label) e.Item.Cells[1].FindControl(LBLDELMES)).Text=this.lblMes.Text;
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Attributes.Add("Cta3Dig",dr["CuentaContable"].ToString());
				e.Item.Cells[0].Controls.Add(Helper.CrearNodoRaiz(e,dr["CuentaContable"].ToString() + "-" + e.Item.Cells[0].Text,"ObtenerDetalleDeCentrosdeCostoPorNaturaleza" ,true));
				//Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("campo1",dr["observacion"].ToString()));
				string parametros=String.Empty;
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
					parametros =KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL +idFormato.ToString() +
						Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.idCentroOperativo.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Fecha.Year.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDFECHA + Utilitario.Constantes.SIGNOIGUAL + this.Fecha.Month.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL + this.idRubro.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + dr["CuentaContable"].ToString()
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
				/*lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
					|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
					? (Convert.ToDouble(dr["EjecucionRealDelmesActual"])/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
					:Convert.ToDouble(dr["EjecucionRealDelmesActual"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);*/
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

				lbl = (Label) e.Item.Cells[2].FindControl(LBLACUMREAL+SUBF);
				lbl.Text = Convert.ToDouble(arrTotal[2]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				lbl = (Label) e.Item.Cells[2].FindControl(LBLACUMPPTO+SUBF);
				lbl.Text = Convert.ToDouble(arrTotal[3]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

			}
		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
