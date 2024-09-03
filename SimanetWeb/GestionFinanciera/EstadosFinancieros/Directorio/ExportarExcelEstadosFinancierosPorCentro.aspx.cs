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
	/// Summary description for ConsultarEstadosFinancierosPorCentro.
	/// </summary>
	public class ExportarExcelEstadosFinancierosPorCentro : System.Web.UI.Page,IPaginaBase
	{
		#region Constante
			const string LBLDELMES = "lblDelMes";
			const string LBLALMES = "lblAcumulado";
			const string LBLPROY = "lblProyectado";

			const string LBLACUMREALH = "lblAcumRealHH";
			const string LBLACUMPPTOH = "lblAcumPPTOHH";

			#region otras
				
				const int IDGASTOSADM = 24;
				const int IDGASTOSADMPERU = 26;
				const int IDGASTOSVENTAS = 25;
				const int IDAPORTESORGANISMODES = 30;

				const string URLPAGINAGASTOSADMINISTRATIVOS = "ConsultarGastosdeAdministracionPorCentroOperativo.aspx?";
				const string URLPAGINAINSENTIVOPORCESE = "ConsultarInsentivoPorCese.aspx?";
				const string URLPAGINAMANODEOBRAIMPRODUCTIVA = "ConsultarManodeObraImproductiva.aspx?";
				const string URLPAGINADETALLENATURALEZADEGASTO ="ConsultarDetalledeRubroPorNaturalezadeGasto.aspx?";
				const string URLPAGINADETALLECUENTA5DIG ="ConsultarDetalledeRubroCuenta5Digitos.aspx?";
		


				const string KEYQIDEMPRESA = "idEmp";
				const string KEYIDCENTRO ="IdCentro";
				const string NOMBRECENTRO ="NombreCentro";
					
				const string NOMBRETIPOOPCION ="NombreOpcion";
				const string KEYQIDNOMBREFORMATO = "NFormato";
				const string KEYQIDFECHA = "efFecha";

				const string KEYQIDNOMBREMES = "NombreMes";
				const string KEYQESOBSERVACION="Observacion";
				
				const string COLUMNACONCEPTO = "CONCEPTO";
				const string COLUMNAIDRUBRO ="idRubro";
				const string URLFORMATORUBROMOVIMIENTOVCV ="ConsultarFormatoRubroMovimientoVCV2.aspx?";
				const string URLFORMATORUBROMOVIMIENTODES ="ConsultarFormatoRubroMovimientoDES.aspx?";
				const string URLFORMATORUBROMOVIMIENTO ="ConsultarFormatoRubroMovimiento.aspx?";

				const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
				const string KEYQIDINTERFAZ = "interfaz";
				const string KEYQIDIDTIPOINFORMACION ="idTipoInfo";
				const string KEYQVERIQUITOS ="Ver";
				const string KEYQNOMBRERUBRO ="NRubro";
				const string KEYQIDFORMATO = "IdFormato";
				const string KEYQIDREPORTE = "IdReporte";
				const string KEYQIDRUBRO = "IdRubro";
				const string KEYQIDACUMULADO = "Acumulado";
				const string KEYQIDNIVELEXPANDE = "NivelExp";
				const string KEYQIDCLASIFICACIONRUBRO = "RubroClasf";
				const string KEYQIDNUEVOFORMATO = "NuevoFormato";
				const string NODOSELECCIONADO="NodoSeleccionado";
				const string KEYQNRODIGITOS ="NroDig";
				const string KEYQDIGCUENTA = "DigCuenta";
				const string KEYQNUEVOSSOLES = "MILNS";
		        const string KEYQDESCRIPCIONOBSERVACION="DescripcionObservacion";
				const string KEYQDESCRIPCIONOBSERVACIONVENTAS="ObservacionVentas";
				const string KEYQDESCRIPCIONOBSERVACIONCOSTOS="ObservacionCostos";
			#endregion
		DataTable dtEstadoFinanciero;

		#region Label Item
			const string LBLDELMESREAL = "lblDelMesReal";
			const string LBLDELMESPPTO= "lblDelMesPPTO";
			const string LBLDELMESVAR= "lblDelMesVar";

			const string LBLACUMREAL= "lblAcumReal";
			const string LBLACUMPPTO= "lblAcumPPTO";
			const string LBLACUMVAR= "lblAcumVar";

			const string LBLPROYREAL= "lblProyReal";
			const string LBLPROYPPTO= "lblProyPPTO";
			const string LBLPROYVAR= "lblProyVar";
		#endregion



		#endregion
		#region Atributos
			protected DateTime FechaPeriodo
			{
				get
				{
					return Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year,Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month) + Utilitario.Constantes.SEPARADORFECHA + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month.ToString().PadLeft(2,'0') + Utilitario.Constantes.SEPARADORFECHA + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year.ToString());
				}
			}

		protected int idFormato
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
			}
		}
		protected string NombreFormato
		{
			get
			{
				return Page.Request.Params[KEYQIDNOMBREFORMATO].ToString();
			}
		}

		protected int idReporte
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);
			}
		}
		protected int idEmpresa
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA]);
			}
		}

		protected int idCentro
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]);
			}
		}
		protected string NombreCentroOperativo
		{
			get
			{
				return Page.Request.Params[NOMBRECENTRO].ToString();
			}
		}

		protected int NivelExpande
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDNIVELEXPANDE]);
			}
		}
		protected int idClasificacionRubro
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDCLASIFICACIONRUBRO]);
			}
		}


		#endregion

		#region Controles

			protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnAbrir;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					
					this.LlenarJScript();
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
			this.ibtnAbrir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAbrir_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CEstadosFinancieros oCEstadosFinancieros = new  CEstadosFinancieros();
			dtEstadoFinanciero = oCEstadosFinancieros.ConsultarEstadosFinancierosPorCentroOperativo(this.FechaPeriodo
																							,this.idFormato
																							,this.idReporte
																							,Utilitario.Constantes.IDDEFAULT
																							,this.idCentro
																							,this.NivelExpande
																							,this.idClasificacionRubro
																							);			
			
			if(dtEstadoFinanciero!=null)
			{
				
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
			// TODO:  Add ConsultarEstadosFinancierosPorCentro.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarEstadosFinancierosPorCentro.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarEstadosFinancierosPorCentro.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			
		}

		public void LlenarJScript()
		{
			if (this.idFormato == Utilitario.Constantes.KEYIDFORMATOFLUJODECAJA)
			{
				this.grid.Columns[4].Visible=false;
			}
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarEstadosFinancierosPorCentro.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarEstadosFinancierosPorCentro.Imprimir implementation
		}

		public void Exportar()
		{
			//export to excel
			DataGrid dg= new DataGrid();
			dg=grid;
			Response.Clear();
			Response.Buffer= true;
			Response.ContentType = "application/vnd.ms-excel";
			Response.Charset = "";
			this.EnableViewState = false;
			System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
			System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
			ClearControls(dg);
			dg.RenderControl(oHtmlTextWriter);
			Response.Write(oStringWriter.ToString());
			Response.End();
			// TODO:  Add ConsultarEstadosFinancierosPorCentro.Exportar implementation
		}
		public void ClearControls(Control control)
		{
			for (int i=control.Controls.Count -1; i>=0; i--)
			{
				ClearControls(control.Controls[i]);
			}
			if ((control is System.Web.UI.HtmlControls.HtmlImage))
			{
				control.Parent.Controls.Remove(control);
			}
			return;
		}

		
		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarEstadosFinancierosPorCentro.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarEstadosFinancierosPorCentro.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region Implementacion Usuario
		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			#region HEADER GRILLA
			if(e.Item.ItemType == ListItemType.Header)
			{
				Label lbl;
				//Nombre de Mes Anterior
				string NombreMesAnterior = ((FechaPeriodo.Month==1)?Convert.ToString(FechaPeriodo.Year-1) + "<br>":Utilitario.Constantes.VACIO) +  Helper.ObtenerNombreMes(((FechaPeriodo.Month==1)?12: FechaPeriodo.Month-1) ,Utilitario.Enumerados.TipoDatoMes.Abreviatura).ToUpper();
				#region Mes Anterios
				e.Item.Cells[1].Text = NombreMesAnterior;
				e.Item.Cells[1].ToolTip= Helper.ObtenerNombreMes(((FechaPeriodo.Month==1)?12: FechaPeriodo.Month-1),Utilitario.Enumerados.TipoDatoMes.NombreCompleto);
				e.Item.Cells[1].Font.Size=10;
				e.Item.Cells[1].Font.Bold=true;
				#endregion

				Session["ObVentas"]= dtEstadoFinanciero.Rows[0]["ObservaciondelCentro"].ToString();
				Session["ObCostos"]=dtEstadoFinanciero.Rows[7]["ObservaciondelCentro"].ToString();
				
				//Mes Actual
				#region Mes Actual
				
					
				lbl = (Label) e.Item.Cells[2].FindControl(LBLDELMES);
				lbl.Text = Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
				lbl.ToolTip = Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto);

				lbl.Font.Size = 10;
				lbl.Font.Underline=true;
				lbl.Font.Bold=true;
				
				
				/*Real , Presupuesto y porc*/
				lbl = (Label) e.Item.Cells[2].FindControl(LBLDELMESREAL+"H");
				lbl.Font.Size = 10;lbl.Font.Bold=true;
				lbl = (Label) e.Item.Cells[2].FindControl(LBLDELMESPPTO+"H");
				lbl.Font.Size = 10;lbl.Font.Bold=true;
				lbl = (Label) e.Item.Cells[2].FindControl(LBLDELMESVAR+"H");
				lbl.Font.Size = 10;lbl.Font.Bold=true;
				#endregion

				#region Acumulado
				

				lbl = (Label) e.Item.Cells[3].FindControl(LBLALMES);
				lbl.Font.Size = 10;
				lbl.Font.Bold=true;
				/*Enlace a los datos Reales*/
				lbl = (Label) e.Item.Cells[3].FindControl(LBLACUMREALH);
				lbl.Font.Size = 10;
				lbl.Font.Bold=true;
				lbl.Font.Underline=true;
				
				

				/*Enlace a los datos del Presupuesto*/
				lbl = (Label) e.Item.Cells[3].FindControl(LBLACUMPPTOH);
				lbl.Font.Size = 10;
				lbl.Font.Bold=true;
				lbl.Font.Underline=true;
								
				/*Columna de variacion Acumulada*/
				lbl = (Label) e.Item.Cells[3].FindControl(LBLACUMVAR+"HH");
				lbl.Font.Size = 10;lbl.Font.Bold=true;

				#endregion

				#region Proyectado
				lbl = (Label) e.Item.Cells[4].FindControl(LBLPROY);
				lbl.Font.Size = 10;
				lbl.Font.Bold=true;

				lbl = (Label) e.Item.Cells[3].FindControl(LBLPROYREAL+"H");
				lbl.Font.Size = 10;lbl.Font.Bold=true;
				lbl = (Label) e.Item.Cells[3].FindControl(LBLPROYPPTO+"H");
				lbl.Font.Size = 10;lbl.Font.Bold=true;
				lbl = (Label) e.Item.Cells[3].FindControl(LBLPROYVAR+"H");
				lbl.Font.Size = 10;lbl.Font.Bold=true;
				#endregion

			}
			#endregion
			#region ITEM GRILLA
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				string Pagina = String.Empty;
				string sVentana = String.Empty;
				int pidrubro = Convert.ToInt32(dr[COLUMNAIDRUBRO]);

				e.Item.Attributes.Add("OBSERVACIONES",dr["ObservaciondelCentro"].ToString());
				e.Item.Attributes.Add("NOMBRERUBRO",e.Item.Cells[0].Text);
				e.Item.Attributes.Add("IDRUBRO",dr[COLUMNAIDRUBRO].ToString());
					
				string KEYVALUECALLAO;
				if((pidrubro ==IDGASTOSADMPERU)&& ((this.idCentro == Utilitario.Constantes.KEYIDCENTROCALLAO)|| (this.idEmpresa ==Utilitario.Constantes.KEYIDCENTROPERU)))
				{
					KEYVALUECALLAO = KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROPERU.ToString();
				}
				else
				{
					KEYVALUECALLAO = KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.idCentro.ToString();
				}
					 


				e.Item.Cells[1].Text = (Session[KEYQNUEVOSSOLES] ==null 
					|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
					? (Convert.ToDouble(e.Item.Cells[1].Text)/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
					:Convert.ToDouble(e.Item.Cells[1].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);


				

				#region Establecer Montos
				Label lbl;
				lbl = (Label) e.Item.Cells[2].FindControl(LBLDELMESREAL);
				lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
					|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
					? (Convert.ToDouble(dr["EjecucionRealDelmesActual"])/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
					:Convert.ToDouble(dr["EjecucionRealDelmesActual"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				lbl = (Label) e.Item.Cells[2].FindControl(LBLDELMESPPTO);
				lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
					|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
					? (Convert.ToDouble(dr["PresupuestoDelMesActual"])/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
					:Convert.ToDouble(dr["PresupuestoDelMesActual"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				/*Diferencia del Mes*/
				lbl = (Label) e.Item.Cells[2].FindControl(LBLDELMESVAR);
				if(dr["VariaciondelMes"].ToString().Substring(0,1).Equals("S")==true)
				{
					lbl.Text = dr["VariaciondelMes"].ToString();
				}
				else
				{
					lbl.Text = ((Session[KEYQNUEVOSSOLES] ==null || Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
						? (Convert.ToDouble(dr["VariaciondelMes"])/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
						:Convert.ToDouble(dr["VariaciondelMes"]).ToString(Utilitario.Constantes.FORMATODECIMAL4)).Replace("-","");

					if(Convert.ToDouble(dr["VariaciondelMes"])<0){lbl.ForeColor=System.Drawing.Color.Red;}
				}
				


				lbl = (Label) e.Item.Cells[3].FindControl(LBLACUMREAL);
				lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
					|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
					? (Convert.ToDouble(dr["EjecucionRealAcumulado"])/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
					:Convert.ToDouble(dr["EjecucionRealAcumulado"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);


				lbl = (Label) e.Item.Cells[3].FindControl(LBLACUMPPTO);
				lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
					|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
					? (Convert.ToDouble(dr["PresupuestoAcumulado"])/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
					:Convert.ToDouble(dr["PresupuestoAcumulado"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				/*Diferencia Acumulada*/
				lbl = (Label) e.Item.Cells[3].FindControl(LBLACUMVAR);
				if(dr["VariacionAcumulada"].ToString().Substring(0,1).Equals("S")==true)
				{
					lbl.Text = dr["VariacionAcumulada"].ToString();
				}
				else
				{
					lbl.Text = ((Session[KEYQNUEVOSSOLES] ==null || Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
						? (Convert.ToDouble(dr["VariacionAcumulada"])/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
						:Convert.ToDouble(dr["VariacionAcumulada"]).ToString(Utilitario.Constantes.FORMATODECIMAL4)).Replace("-","");
							
					if(Convert.ToDouble(dr["VariacionAcumulada"])<0){lbl.ForeColor=System.Drawing.Color.Red;}
				}

				/*Proyectado*/
				lbl = (Label) e.Item.Cells[4].FindControl(LBLPROYREAL);
				lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
					|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
					? (Convert.ToDouble(dr["ProyectadoAnual"])/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
					:Convert.ToDouble(dr["ProyectadoAnual"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				lbl = (Label) e.Item.Cells[4].FindControl(LBLPROYPPTO);
				lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
					|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
					? (Convert.ToDouble(dr["PresupuestoAnual"])/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
					:Convert.ToDouble(dr["PresupuestoAnual"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				lbl = (Label) e.Item.Cells[4].FindControl(LBLPROYVAR);
				lbl.Text = dr["VariaciondelAcumulada"].ToString();
				//lbl.Text = (lbl.Text.Substring(0,1).Equals("S")==true)?lbl.Text: Convert.ToDouble(lbl.Text).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				if(lbl.Text.Substring(0,1).Equals("S")==true)
				{
					lbl.Text=dr["VariaciondelAcumulada"].ToString();
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

				if (Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdTipoLinea.ToString()]) != 0 ){e.Item.Font.Bold = true;}
				
				CEstadosFinancieros oCEstadosFinancieros = new CEstadosFinancieros();
				DataRow drConcepto= oCEstadosFinancieros.ConsultarConceptoDeEstadosFinancierosPorFormatoyRubro(Convert.ToInt32(dr["idformato"]),Convert.ToInt32(dr["idrubro"]) );
				if(drConcepto!=null)
					e.Item.Cells[0].ToolTip=drConcepto["concepto"].ToString().Replace("?","").ToUpper();

				
			}
			#endregion
		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnAbrir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Exportar();
			
		}
	}
}

