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
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio
{
	/// <summary>
	/// Summary description for AdministrarConceptoEstadosFinancieros.
	/// </summary>
	public class AdministrarConceptoEstadosFinancieros : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region controles
		protected System.Web.UI.WebControls.ImageButton imgbtnGrabar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hTramaData;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hModo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hvalida;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdRubro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hTiempoHabilitado;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		
		#region Constantes
		//Key Session y QueryString
		const string NODOSELECCIONADO="NodoSeleccionado";
		const string KEYQIDNOMBREFORMATO = "NFormato";
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDCENTRO = "IdCentro";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQRUBRONOMBRE= "RubroNombre";
		const string KEYQIDTIPOINFO= "idTipoInfo";
		const string KEYQPERIODO = "Periodo";
		const string KEYQMES = "idMes";
		
		const string CONTROLINK = "hlkConcepto";
		const string COLMONTOMES = "lbldelMes";
		const string COLMONTOACUM = "lblalMes";

		const string CONTROLIMAGE = "imgBtnDetalle";
		
		const string GRILLAVACIA="No exiets";
		const string OBJPARAMETROCONTABLE="ParametroContable";			
			
		const string  KEYQNRODIGITOSCABECERA ="NroDigCab";
		const string KEYDIGCUENTACONTABLE = "Cuenta";
		const string KEYIDEMPRESA ="idEmp";
		const string KEYIDACUMULADO ="Acumulado";
			
		const string KEYQNROCENTROOPERATIVO = "nroCentroOperativo";
			
			
		const string CTRLMONTO1 = "nMonto";
			
			
		

		//Variables de Session
		const string VARIABLESESSIONCIERRE ="Cierre";

		//Paginas		
		const string URLDETALLE = "DetalleReporteFormulaContable.aspx?";
		const string URLDETALLE1 = "AdministrarFormulaFinanciera.aspx?";			
		const string URLDETALLE2 = "AdministarFormatoRubroDetalleMovimientoporMes.aspx?";
		const string URLDETALLENOTARUBRO = "../../Editor/Editor.aspx?";
		const string URLDESCRIPCIONPERU ="ConsultaDeEstadosFinancierosPERU.aspx";
		const string URLGLOSA = "GlosaEstadosFinancieros.aspx?";
		//Otros
		const string ETIQUETAESTADOSFINANCIEROS =" Estados Financieros > ";

		//Columnas Grilla
		const string COLUMNACONCEPTO ="Concepto";
		const string COLUMNAMONTOMES ="montoMes";
		const string COLUMNAOBSERVACION ="Observacion";
		
		//Controles
		const string CONTROLIMGFORMULA ="imgFormula";
		const string CONTROLIMGBTNDESCRIPCION ="imgBtnDescripcion";

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
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
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
			this.imgbtnGrabar.Click += new System.Web.UI.ImageClickEventHandler(this.imgbtnGrabar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			
			/*Ocul el Boton de Proceso para los tipos de informacion Proyectada y Presupuestada*/
			//this.imgProcesar.Visible = (Convert.ToInt32(usc_ParametroContable.IdTipoInformacion) !=0)? false:true;

			CEstadosFinancieros oCEstadosFinancieros = new  CEstadosFinancieros();
			DataTable dtEstadoFinanciero = oCEstadosFinancieros.ConsultarConceptoDeEstadosFinancieros(Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO]));
						
					
			if(dtEstadoFinanciero!=null)
			{				
				grid.DataSource = dtEstadoFinanciero;
			
			}
			else
			{
				grid.DataSource = dtEstadoFinanciero;
				lblResultado.Text = GRILLAVACIA;

			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			imgbtnGrabar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + "return ObtenerDataModificada()");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.Agregar implementation
		}

		public void Modificar(string []Data)
		{
			string idEmpresa = Page.Request.Params[KEYIDEMPRESA].ToString();
			
			//Referencia a la Entidad de Negocio
			FormatoDetalleMovimientoBE oFormatoDetalleMovimientoBE = new FormatoDetalleMovimientoBE();

			oFormatoDetalleMovimientoBE.IdFormato = Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]); 
			oFormatoDetalleMovimientoBE.IdRubro = Convert.ToInt32(Data[1]);
			oFormatoDetalleMovimientoBE.IdUsuarioActualizacion =  CNetAccessControl.GetIdUser();
			oFormatoDetalleMovimientoBE.Observacion = Data[2].ToString();
			//oFormatoDetalleMovimientoBE.Observacion = this.txtObservacion.Text.ToString();

			CEstadosFinancieros  oCEstadosFinancieros = new CEstadosFinancieros();
			int retorno = oCEstadosFinancieros.ModificarConcepto(oFormatoDetalleMovimientoBE);
		}
		public void Modificar()
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.Modificar implementation
		}
		public void Eliminar()
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarConceptoEstadosFinancieros.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;			

				e.Item.Attributes.Add("PRIORIDAD",dr[Enumerados.ColumnasFormato.idPrioridad.ToString()].ToString());

					
				e.Item.Attributes.Add("MODO",dr[Enumerados.ColumnasFormato.Modo.ToString()].ToString());
				e.Item.Attributes.Add("IDRUBRO",dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString());
				
		

				Utilitario.Helper.ConfiguraNodosTreeview(e,1,0,dr,
					"",
					Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
					""
					);
				
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				//Descipciones
				e.Item.Attributes.Add("OBSERVACIONES",dr["concepto"].ToString());
				((System.Web.UI.WebControls.Image) e.Item.Cells[1].FindControl(CONTROLIMGBTNDESCRIPCION)).Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"EscribirDescripcionEnFila('" + dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString() + "');");
			}	
		}

		private void imgbtnGrabar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (hTramaData.Value.ToString().Length==0) {return;}
			string []sdata = hTramaData.Value.ToString().Split('@');
			for (int i=0;i<=sdata.Length-1;i++)
			{
				string []Data = sdata[i].Split('*');
				switch (Data[0].ToString())
				{
//					case "N":
//						this.Agregar(Data);
//						break;
					case "M":
						this.Modificar(Data);
						break;
				}
			}
			this.LlenarGrilla();
		}
	}
}
