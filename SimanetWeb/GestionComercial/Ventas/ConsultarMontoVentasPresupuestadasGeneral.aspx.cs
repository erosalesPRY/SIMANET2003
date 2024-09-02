using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.EntidadesNegocio;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for ConsultarMontoVentasPresupuestadasGeneral.
	/// </summary>
	public class ConsultarMontoVentasPresupuestadasGeneral : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnGraficoVentaPresupuestadaCOSinCompararVentas;
		protected System.Web.UI.WebControls.ImageButton ibtnGraficoVentaPresupuestadaTorta;
		protected System.Web.UI.WebControls.ImageButton ibtnGraficoVentaPresupuestadaCO;
		protected System.Web.UI.WebControls.ImageButton ibtnGraficoBarraTipoCliente;
		protected System.Web.UI.WebControls.ImageButton ibtnGraficoBarraPorLineaNegocio;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblVersion;
		protected System.Web.UI.WebControls.Label lblAño;
		protected System.Web.UI.WebControls.DropDownList ddlbAño;
		protected System.Web.UI.WebControls.DropDownList ddlbVersion;
		protected projDataGridWeb.DataGridWeb dgConsulta;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnTipoCliente;
		protected System.Web.UI.WebControls.Label lblResultado1;
		#endregion

		#region	Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "Astillero";
		//Paginas
		const string URLDETALLE	= "ConsultarVentasPresupuestadasMensualPorCentroOperativo.aspx?";
		const string URLIMPRESION	= "PopupImpresionConsultarMontoVentasPresupuestadasGeneral.aspx";
		const string URLREPORTEVENTASPRESUPUESTADASPORTIPOCLIENTE= "ConsultarMontoVentasPresupuestadas.aspx";
		const string URLREPORTECONTRIBUCIONLN = "../Reportes/GraficoVentasPresupuestadasContribucionLN.aspx?";
		const string URLREPORTEVENTASPORCO= "../Reportes/GraficoVentasPresupuestadasporCO.aspx?";
		const string URLREPORTEVENTASPORTIPOCLIENTE = "../Reportes/GraficoVentasPresupuestadasporTipoCliente.aspx?";
		const string URLREPORTEVENTASACUMULADALINEANEGOCIO = "../Reportes/VentasPresupuestadaAcumuadaLineaNegocio.aspx?";
		const string URLREPORTEVENTASPORCOSINCOMPARARVENTAS = "../Reportes/GraficoVentasPresupuestadasporCOSinCompararConVentas.aspx?";

		
		const string URLREPORTEPRESUPUESTOVSVENTASPORPERIODO= "ConsultarAnalisisVentasRealesVSPresupuesto.aspx?";
	
		//Key Session y	QueryString
		const string KEYQID	= "IdCentroOperativo";
		const string CENTROOPERATIVO = "CO";
		const string VERSION = "IdVersion";
		const string ANO = "Ano";
		const string KEYQPOSICIONCOMBO = "PosicionComboCentroOperativo";
		const string KEYQPOSICIONCOMBOVERSION = "PosicionComboVersion";
		const string KEYQIDTIPO = "IdTipo";
		const string KEYFLAGPAGINA = "flagpagina";

		//Monedas
		const int EUROS	= 0;
		const int SOLES	= 1;
		const int DOLARES =	2;

		//JScript
			
		//Otros
		const string GRILLAVACIAVENTAPRESUPUESTADA ="No existe ningúna Venta Presupuestada.";
		const string GRILLAVACIAVENTAREAL ="No existe ningúna Venta Ejecutada.";
		const string NOMBRERUTAVENTAPRESUPUESTADA = "Presupuestadas Totales";
		const string NOMBRERUTAVENTAREAL = "Ejecutadas Totales";
		const string TITULO = "CONSULTA DE VENTAS";
		const string TEXTOFOOTERTOTAL =	"Total:";

		const string CENTROOPERATIVOCALLAO = "SIMA-CALLAO";
		const string CENTROOPERATIVOCHIMBOTE = "SIMA-CHIMBOTE"; 
		const string CENTROOPERATIVOIQUITOS = "SIMA-IQUITOS S.R.LTDA";

		const string NombreGlosaTotal = "TOTAL";
		const string VENTASPRESUPUESTADAS = "PRESUPUESTADAS TOTALES EN SOLES";
		const string VENTASREALES = "EJECUTADAS TOTALES EN SOLES";
		const int POSICIONINICIALCOMBO = 0;
		const int POSICIONLINEANEGOCIO = 0;
		const int POSICIONCALLAO = 1;
		const int POSICIONCHIMBOTE = 2;
		const int POSICIONIQUITOS = 3;
		const int POSICIONTOTAL = 4;
		const int PORLN = 1;
		const int MESDICIEMBRE = 12;
		const string TITULOVERSION = "VERSION";
	
		const string TablaImpresion0 = "VentaPresupuestadaTotal";
		
		#endregion Constantes
		protected System.Web.UI.WebControls.ImageButton ibtnGraphPrevupVSVentas;
		
		#region Variables
		ListItem item;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					this.LlenarJScript();
					//Graba	en el Log la acción	ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial- Ventas",this.ToString(),"Se	consultó los Montos de Ventas Presupuestadas.",Enumerados.NivelesErrorLog.I.ToString()));
					this.ValidarAno();
					this.LlenarGrilla();
					
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text	= Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text	= Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					ltlMensaje.Text	= Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception	oException)
				{
					SIMAExcepcionIU	oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
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
			this.ddlbVersion.SelectedIndexChanged += new System.EventHandler(this.ddlbVersion_SelectedIndexChanged);
			this.ddlbAño.SelectedIndexChanged += new System.EventHandler(this.ddlbAño_SelectedIndexChanged);
			this.ibtnGraficoBarraPorLineaNegocio.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGraficoBarraPorLineaNegocio_Click);
			this.ibtnGraficoBarraTipoCliente.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGraficoBarraTipoCliente_Click);
			this.ibtnGraficoVentaPresupuestadaCO.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGraficoVentaPresupuestadaCO_Click);
			this.ibtnGraficoVentaPresupuestadaTorta.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGraficoVentaPresupuestadaTorta_Click);
			this.ibtnGraficoVentaPresupuestadaCOSinCompararVentas.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGraficoVentaPresupuestadaCOSinCompararVentas_Click);
			this.ibtnGraphPrevupVSVentas.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGraphPrevupVSVentas_Click);
			this.ibtnTipoCliente.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnTipoCliente_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.dgConsulta.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsulta_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dtImpresion = new DataTable();

			DataTable dtVentas = new DataTable();
			CVentasPresupuestadas oCVentasPresupuestadas = new CVentasPresupuestadas();
			CVentasReales oCVentasReales = new CVentasReales();

			if(Convert.ToInt32(ddlbAño.SelectedValue) >= Helper.FechaSimanet.ObtenerFechaSesion().Year)
			{
				dtVentas =  oCVentasPresupuestadas.ListarTodosGrillaMontosVentasPorLineaNegocio(Convert.ToInt32(this.ddlbAño.SelectedValue),Convert.ToInt32(this.ddlbVersion.SelectedValue));
				lblTitulo.Text = TITULO + Utilitario.Constantes.ESPACIO + VENTASPRESUPUESTADAS;
				lblPagina.Text = NOMBRERUTAVENTAPRESUPUESTADA;
			}
			else
			{
				dtVentas = oCVentasReales.ListarTodosGrillaMontosVentasRealesHistoricoPorLineaNegocio(Convert.ToInt32(this.ddlbAño.SelectedValue));
				lblTitulo.Text = TITULO + Utilitario.Constantes.ESPACIO + VENTASREALES;
				lblPagina.Text = NOMBRERUTAVENTAREAL;
			}

			if(dtVentas!=null)
			{
				dtImpresion = dtVentas.Copy();
				dtImpresion.TableName = TablaImpresion0;

				DataView dwVentas =	dtVentas.DefaultView;
				
				if(dwVentas.Count > POSICIONINICIALCOMBO)
				{
					dgConsulta.DataSource	= dwVentas;
					lblResultado.Visible = false;
					this.ibtnImprimir.Visible = true;
				}
				else
				{
					dgConsulta.DataSource	= null;
					this.lblResultado.Visible = true;
					this.ibtnImprimir.Visible = false;
					if(Convert.ToInt32(ddlbAño.SelectedValue) >= DateTime.Now.Year || Helper.FechaSimanet.ObtenerFechaSesion().Month == MESDICIEMBRE)
					{
						lblResultado.Text =	GRILLAVACIAVENTAPRESUPUESTADA;
					}
					else
					{
						lblResultado.Text =	GRILLAVACIAVENTAREAL;
					}
				}			
			}
			else
			{
				dgConsulta.DataSource	= dtVentas;
				lblResultado.Visible = true;
				this.ibtnImprimir.Visible = false;
				if(Convert.ToInt32(ddlbAño.SelectedValue) >= DateTime.Now.Year || Helper.FechaSimanet.ObtenerFechaSesion().Month == MESDICIEMBRE)
				{
					lblResultado.Text =	GRILLAVACIAVENTAPRESUPUESTADA;
				}
				else
				{
					lblResultado.Text =	GRILLAVACIAVENTAREAL;
				}
			}
			
			try
			{
				dgConsulta.DataBind();
				CImpresion oCImpresion = new CImpresion();
				if(Convert.ToInt32(ddlbAño.SelectedValue) >= Helper.FechaSimanet.ObtenerFechaSesion().Year)
				{
					oCImpresion.GuardarDataImprimirExportar(dtImpresion,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEVENTASPRESUPUESTADASGENERAL),
															ddlbAño.SelectedValue.ToString() + Utilitario.Constantes.LINEA +  ddlbVersion.SelectedValue.ToString() + Utilitario.Constantes.ESPACIO + TITULOVERSION );
				}
				else
				{
					oCImpresion.GuardarDataImprimirExportar(dtImpresion,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEVENTASEJECUTADASGENERAL),
															ddlbAño.SelectedValue.ToString());
				}
			}
			catch(Exception	ex)
			{
				string a = ex.Message;
				dgConsulta.CurrentPageIndex = Utilitario.Constantes.POSICIONCONTADOR;
				dgConsulta.DataBind();
			}	
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarMontoVentasPresupuestadasGeneral.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarMontoVentasPresupuestadasGeneral.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.llenarVersiones();
			this.llenarAnos();
			Helper.SeleccionarItemCombos(this);
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarMontoVentasPresupuestadasGeneral.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnGraficoVentaPresupuestadaTorta.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnGraficoVentaPresupuestadaTorta.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);

			this.ibtnGraficoVentaPresupuestadaCO.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnGraficoVentaPresupuestadaCO.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);

			this.ibtnGraficoBarraTipoCliente.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnGraficoBarraTipoCliente.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);

			this.ibtnGraficoBarraPorLineaNegocio.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);	
			this.ibtnGraficoBarraPorLineaNegocio.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);

			this.ibtnTipoCliente.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnTipoCliente.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);

			this.ibtnGraficoVentaPresupuestadaCOSinCompararVentas.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnGraficoVentaPresupuestadaCOSinCompararVentas.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			
			this.ibtnGraphPrevupVSVentas.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnGraphPrevupVSVentas.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);			

		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarMontoVentasPresupuestadasGeneral.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,770,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarMontoVentasPresupuestadasGeneral.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{
				CNetAccessControl.LoadControls(this);
			}
			else
			{
				CNetAccessControl.RedirectPageError();
			}
		}

		public bool ValidarFiltros()
		{
			return false;
		}

		#endregion

		private void llenarVersiones()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbVersion.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.VersionesVentasPresupuestadas));
			ddlbVersion.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbVersion.DataTextField =Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbVersion.DataBind();

			CVentasPresupuestadas oCVentasPresupuestadas = new CVentasPresupuestadas();
			this.ddlbVersion.Items.FindByValue(oCVentasPresupuestadas.ObtenerUltimaVersion(Helper.FechaSimanet.ObtenerFechaSesion().Year).ToString()).Selected = true;
		}

		private void llenarAnos()
		{
			#region Obtener años de la tabla de	PeriodoContable
			//CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			//ddlbAño.DataSource = oCPeriodoContable.ListarTodosPeriodo();
			//ddlbAño.DataValueField="Periodo";
			//ddlbAño.DataTextField="Periodo";
			//ddlbAño.DataBind();
			#endregion

			int indice = 0;
			for(int i = Utilitario.Constantes.ANOMINIMA; i <= DateTime.Today.Year + 5; i++)
			{
				ddlbAño.Items.Insert(indice,i.ToString());
				indice++;
			}

			item = ddlbAño.Items.FindByText(Helper.FechaSimanet.ObtenerFechaSesion().Year.ToString());
			if (item !=null){item.Selected = true;}

		}

		private void ValidarAno()
		{
			if(Convert.ToInt32(ddlbAño.SelectedValue) >= Helper.FechaSimanet.ObtenerFechaSesion().Year)
			{ddlbVersion.Enabled = true;}
			else
			{ddlbVersion.Enabled = false;}
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ibtnTipoCliente_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLREPORTEVENTASPRESUPUESTADASPORTIPOCLIENTE);
		}


		private void dgConsulta_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Cells[POSICIONCALLAO].Text = Convert.ToDouble(e.Item.Cells[POSICIONCALLAO].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[POSICIONCHIMBOTE].Text = Convert.ToDouble(e.Item.Cells[POSICIONCHIMBOTE].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[POSICIONIQUITOS].Text = Convert.ToDouble(e.Item.Cells[POSICIONIQUITOS].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[POSICIONTOTAL].Text = Convert.ToDouble(e.Item.Cells[POSICIONTOTAL].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				if(e.Item.Cells[POSICIONLINEANEGOCIO].Text == NombreGlosaTotal)
				{	
					Helper.ConfigurarColorTotalesGrilla(e);
				}
				else
				{
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				}
				Helper.FiltroporSeleccionConfiguraColumna(e,dgConsulta);
			}

			if(e.Item.ItemType == ListItemType.Header)
			{ 
				//Centro Operativo Callao
				e.Item.Cells[POSICIONCALLAO].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[POSICIONCALLAO].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
															Helper.MostrarVentana(URLDETALLE, KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.IdCentroOperativo.SimaCallao).ToString() + Utilitario.Constantes.SIGNOAMPERSON + 
															                                  CENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + CENTROOPERATIVOCALLAO + Utilitario.Constantes.SIGNOAMPERSON +
																							  Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Utilitario.Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
																							  VERSION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(this.ddlbVersion.SelectedValue).ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
																							  ANO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbAño.SelectedValue + Utilitario.Constantes.SIGNOAMPERSON + 
																							  KEYFLAGPAGINA + Utilitario.Constantes.SIGNOIGUAL + PORLN.ToString()));

				e.Item.Cells[POSICIONCALLAO].Font.Underline=true;
				e.Item.Cells[POSICIONCALLAO].Style[Utilitario.Constantes.CURSOR] = Utilitario.Constantes.TIPOCURSORMANO;

				//Centro Operativo Chimbote
				e.Item.Cells[POSICIONCHIMBOTE].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[POSICIONCHIMBOTE].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
															  Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.IdCentroOperativo.SimaChimbote).ToString() + Utilitario.Constantes.SIGNOAMPERSON + 
																					           CENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + CENTROOPERATIVOCHIMBOTE + Utilitario.Constantes.SIGNOAMPERSON +
																					           Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Utilitario.Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
																					           VERSION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(this.ddlbVersion.SelectedValue).ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
																							   ANO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbAño.SelectedValue + Utilitario.Constantes.SIGNOAMPERSON + 
																							   KEYFLAGPAGINA + Utilitario.Constantes.SIGNOIGUAL + PORLN.ToString()));
				e.Item.Cells[POSICIONCHIMBOTE].Font.Underline=true;
				e.Item.Cells[POSICIONCHIMBOTE].Style[Utilitario.Constantes.CURSOR] = Utilitario.Constantes.TIPOCURSORMANO;

				//Centro Operativo Iquitos
				e.Item.Cells[POSICIONIQUITOS].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[POSICIONIQUITOS].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
														     Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.IdCentroOperativo.SimaIquitos).ToString() + Utilitario.Constantes.SIGNOAMPERSON + 
																							  CENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + CENTROOPERATIVOIQUITOS + Utilitario.Constantes.SIGNOAMPERSON +
																							  Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Utilitario.Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
																							  VERSION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(this.ddlbVersion.SelectedValue).ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
																							  ANO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbAño.SelectedValue + Utilitario.Constantes.SIGNOAMPERSON + 
																							  KEYFLAGPAGINA + Utilitario.Constantes.SIGNOIGUAL + PORLN.ToString()));
				e.Item.Cells[POSICIONIQUITOS].Font.Underline=true;
				e.Item.Cells[POSICIONIQUITOS].Style[Utilitario.Constantes.CURSOR] = Utilitario.Constantes.TIPOCURSORMANO;

			}
		
		}
	
		private void ddlbVersion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblTitulo.Text = Utilitario.Constantes.ESPACIO;
			this.CargarSegunFiltro();
			
		}
		
		private void ddlbAño_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblTitulo.Text = Utilitario.Constantes.ESPACIO;
			lblPagina.Text = Utilitario.Constantes.ESPACIO;

			if(Convert.ToInt32(ddlbAño.SelectedValue) >= Helper.FechaSimanet.ObtenerFechaSesion().Year)
			{
				//this.ibtnGraficoVentaPresupuestadaCOSinCompararVentas.Visible = true;
				this.ddlbVersion.Enabled = true;
				this.ddlbVersion.SelectedIndex = Utilitario.Constantes.POSICIONCONTADOR;
			}
			else
			{
				//this.ibtnGraficoVentaPresupuestadaCOSinCompararVentas.Visible = false;
				ddlbVersion.Enabled = false;
			}
			this.LlenarGrilla();
			
		}

		private bool ValidarCampos()
		{
			return true;
		}

		private void CargarSegunFiltro()
		{
			if(this.ValidarCampos())
			{
				this.LlenarGrilla();	
			}
		}

		private void ibtnGraficoVentaPresupuestadaTorta_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(Convert.ToInt32(ddlbAño.SelectedValue) >= DateTime.Now.Year)
			{
				Page.Response.Redirect(URLREPORTECONTRIBUCIONLN + VERSION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(this.ddlbVersion.SelectedValue).ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
									   ANO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbAño.SelectedValue);
			}
			else
			{
				Page.Response.Redirect(URLREPORTECONTRIBUCIONLN + ANO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbAño.SelectedValue);
			}
		}

		private void ibtnGraficoVentaPresupuestadaCO_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(Convert.ToInt32(ddlbAño.SelectedValue) >= DateTime.Now.Year)
			{
				Page.Response.Redirect(URLREPORTEVENTASPORCO + VERSION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(this.ddlbVersion.SelectedValue).ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
								       ANO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbAño.SelectedValue);
			}
			else
			{
				Page.Response.Redirect(URLREPORTEVENTASPORCO + ANO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbAño.SelectedValue);
			}
		}

		private void ibtnGraficoBarraTipoCliente_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(Convert.ToInt32(ddlbAño.SelectedValue) >= DateTime.Now.Year)
			{
				Page.Response.Redirect(URLREPORTEVENTASPORTIPOCLIENTE + VERSION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(this.ddlbVersion.SelectedValue).ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
					                   ANO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbAño.SelectedValue);
			}
			else
			{
				Page.Response.Redirect(URLREPORTEVENTASPORTIPOCLIENTE + ANO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbAño.SelectedValue);
			}
		}

		private void ibtnGraficoBarraPorLineaNegocio_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLREPORTEVENTASACUMULADALINEANEGOCIO + VERSION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(this.ddlbVersion.SelectedValue).ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
									ANO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbAño.SelectedValue);
		}

		private void ibtnGraficoVentaPresupuestadaCOSinCompararVentas_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLREPORTEVENTASPORCOSINCOMPARARVENTAS + VERSION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(this.ddlbVersion.SelectedValue).ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
				ANO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbAño.SelectedValue);
		}

		private void ibtnGraphPrevupVSVentas_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLREPORTEPRESUPUESTOVSVENTASPORPERIODO + VERSION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(this.ddlbVersion.SelectedValue).ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
				ANO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbAño.SelectedValue);
		
		}
	}
}
