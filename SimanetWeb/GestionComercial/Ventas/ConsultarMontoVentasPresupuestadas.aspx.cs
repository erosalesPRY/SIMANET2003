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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using System.IO;
using SIMA.EntidadesNegocio;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for ConsultarMontoVentasPresupuestadas.
	/// </summary>
	public class ConsultarMontoVentasPresupuestadas: System.Web.UI.Page ,IPaginaBase
	{

		#region Controles
		protected System.Web.UI.WebControls.Label lblVersion;
		protected System.Web.UI.WebControls.DropDownList ddlbAño;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblAño;
		protected projDataGridWeb.DataGridWeb dgConsulta;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblResultado1;
		protected System.Web.UI.WebControls.DropDownList ddlbVersion;
		#endregion

		#region	Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "Astillero";
		
		//Nombres de Controles
		const string CONTROLBL1 = "lblVentasPresupuestadasCallao";
		const string CONTROLBL2 = "lblVentasPresupuestadasChimbote";
		const string CONTROLBL3 = "lblVentasPresupuestadasIquitos";
		
		//Paginas
		const string URLDETALLE	= "ConsultarVentasPresupuestadasMensualPorCentroOperativo.aspx?";
		const string URLIMPRESION	= "PopupImpresionConsultarMontoVentasPresupuestadas.aspx";
		const string URLREPORTECONTRIBUCIONLN = "../Reportes/GraficoVentasPresupuestadasContribucionLN.aspx?";
		const string URLREPORTEVENTASPORCO= "../Reportes/GraficoVentasPresupuestadasporCO.aspx?";
		const string URLREPORTEVENTASPORTIPOCLIENTE = "../Reportes/GraficoVentasPresupuestadasporTipoCliente.aspx?";
		const string URLREPORTEVENTASACUMULADALINEANEGOCIO = "../Reportes/VentasPresupuestadaAcumuadaLineaNegocio.aspx?";		

		//Key Session y	QueryString
		const string KEYQID	= "IdCentroOperativo";
		const string CENTROOPERATIVO = "CO";
		const string VERSION = "IdVersion";
		const string ANO = "Ano";
		const string KEYQPOSICIONCOMBO = "PosicionComboCentroOperativo";
		const string KEYQPOSICIONCOMBOVERSION = "PosicionComboVersion";
		const string KEYQIDTIPO = "IdTipo";
		const string KEYFLAGPAGINA = "flagpagina";
		const string TITULOVERSION = "VERSION";
		//Monedas
		const int EUROS	= 0;
		const int SOLES	= 1;
		const int DOLARES =	2;

		//JScript
			
		//Otros
		const string GRILLAVACIA ="No existe ningúna Venta Presupuestada.";
		const string TEXTOFOOTERTOTAL =	"Total:";
		const string TITULO = "CONSULTA DE VENTAS";
		const string VENTASPRESUPUESTADAS = "PRESUPUESTADAS TOTALES EN SOLES POR LINEA DE NEGOCIO";
		const string VENTASREALES = "EJECUTADAS TOTALES EN SOLES POR LINEA DE NEGOCIO";
		const string GRILLAVACIAVENTAPRESUPUESTADA ="No existe ningúna Venta Presupuestada.";
		const string GRILLAVACIAVENTAREAL ="No existe ningúna Venta Ejecutada.";
		const string NOMBRERUTAVENTAPRESUPUESTADA = "Presupuestadas Totales Por Tipo de Sector";
		const string NOMBRERUTAVENTAREAL = "Ejecutadas Totales Por Tipo de Sector";

		const string CENTROOPERATIVOCALLAO = "SIMA CALLAO";
		const string CENTROOPERATIVOCHIMBOTE = "SIMA CHIMBOTE"; 
		const string CENTROOPERATIVOIQUITOS = "SIMA IQUITOS";

		const string NombreGlosaTotales = "TOTAL MGP";
		const string NombreGlosaTotales1 = "TOTAL PRIV";
		const string NombreGlosaTotalFinal = "TOTAL FINAL";

		const int POSICIONINICIALCOMBO = 0;
		const int POSICIONCALLAO = 1;
		const int POSICIONCHIMBOTE = 2;
		const int POSICIONIQUITOS = 3;
		const int POSICIONTOTAL = 4;
		const int PORTIPOCLIENTE = 2;
			
		const string TablaImpresion0 = "VentaPresupuestadaTotal";
		
		#endregion Constantes

		#region Variables
		ListItem item;
		#endregion

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
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
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.dgConsulta.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsulta_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
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
		
		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			DataTable dtImpresion = new DataTable();

			DataTable dtVentas = new DataTable();
			CVentasPresupuestadas oCVentasPresupuestadas = new CVentasPresupuestadas();
			CVentasReales oCVentasReales = new CVentasReales();

			if(Convert.ToInt32(ddlbAño.SelectedValue)>= DateTime.Today.Year)
			{
				dtVentas =  oCVentasPresupuestadas.ListarTodosGrillaMontosVentasPresupuestadasPorTipoCliente(Convert.ToInt32(this.ddlbAño.SelectedValue),Convert.ToInt32(this.ddlbVersion.SelectedValue));
				lblTitulo.Text = TITULO + Utilitario.Constantes.ESPACIO + VENTASPRESUPUESTADAS;
				lblPagina.Text = NOMBRERUTAVENTAPRESUPUESTADA;
			}
			else
			{
				dtVentas = oCVentasReales.ListarTodosGrillaMontosVentasRealesHistoricoPorTipoCliente(Convert.ToInt32(this.ddlbAño.SelectedValue));
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
					//dsImprimir.Tables.Add(dtImpresion);	
				}
				else
				{
					dgConsulta.DataSource	= null;
					this.lblResultado.Visible = true;
					this.ibtnImprimir.Visible = false;
					if(Convert.ToInt32(ddlbAño.SelectedValue) >= DateTime.Now.Year)
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
				if(Convert.ToInt32(ddlbAño.SelectedValue) >= DateTime.Now.Year)
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
				if(Convert.ToInt32(ddlbAño.SelectedValue) >= DateTime.Now.Year)
				{
					oCImpresion.GuardarDataImprimirExportar(dtImpresion,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEVENTASPRESUPUESTADAS),
															ddlbAño.SelectedValue.ToString() + Utilitario.Constantes.LINEA +  ddlbVersion.SelectedValue.ToString() + Utilitario.Constantes.ESPACIO + TITULOVERSION);
				}
				else
				{
					oCImpresion.GuardarDataImprimirExportar(dtImpresion,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEVENTASEJECUTADAS),
															ddlbAño.SelectedValue.ToString());
				}
			}
			catch(Exception	ex)
			{
				string a = ex.Message;
				dgConsulta.CurrentPageIndex = 0;
				dgConsulta.DataBind();
			}	
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarMontoVentasPresupuestadas.LlenarGrillaOrdenamiento implementation
		}

		public void	LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarMontoVentasPresupuestadas.LlenarGrillaOrdenamientoPaginacion implementation
		}			

		public void LlenarCombos()
		{
			this.llenarVersiones();
			this.llenarAños();
			Helper.SeleccionarItemCombos(this);
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarMontoVentasPresupuestadas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarMontoVentasPresupuestadas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarMontoVentasPresupuestadas.RegistrarJScript implementation
		}


		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,770,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarMontoVentasPresupuestadas.Exportar implementation
		}

		public void	ConfigurarAccesoControles()
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


		private void ValidarAno()
		{
			if(Convert.ToInt32(ddlbAño.SelectedValue) >= Helper.FechaSimanet.ObtenerFechaSesion().Year)
			{ddlbVersion.Enabled = true;}
			else
			{ddlbVersion.Enabled = false;}
		}

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

		private void llenarAños()
		{
			CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			ddlbAño.DataSource = oCPeriodoContable.ListarTodosPeriodo();
			ddlbAño.DataValueField="Periodo";
			ddlbAño.DataTextField="Periodo";
			ddlbAño.DataBind();
			
			//item = ddlbAño.Items.FindByText(DateTime.Now.Year.ToString());
			item = ddlbAño.Items.FindByText(Helper.FechaSimanet.ObtenerFechaSesion().Year.ToString());
			if (item !=null){item.Selected = true;}

		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void dgConsulta_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Label lbl;

				lbl = (Label)e.Item.Cells[POSICIONCALLAO].FindControl(CONTROLBL1);
				lbl.Text = Convert.ToDouble(dr[Enumerados.ColumnasVentasPresupuestadas.Callao.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			
				lbl = (Label)e.Item.Cells[POSICIONCHIMBOTE].FindControl(CONTROLBL2);
				lbl.Text = Convert.ToDouble(dr[Enumerados.ColumnasVentasPresupuestadas.Chimbote.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			
				lbl = (Label)e.Item.Cells[POSICIONIQUITOS].FindControl(CONTROLBL3);
				lbl.Text = Convert.ToDouble(dr[Enumerados.ColumnasVentasPresupuestadas.Iquitos.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);		

				e.Item.Cells[POSICIONTOTAL].Text = Convert.ToDouble(e.Item.Cells[POSICIONTOTAL].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			
				if(e.Item.Cells[Utilitario.Constantes.POSICIONCONTADORVENTASPRESUPUESTADAS].Text == NombreGlosaTotales || e.Item.Cells[Utilitario.Constantes.POSICIONCONTADORVENTASPRESUPUESTADAS].Text == NombreGlosaTotales1 || e.Item.Cells[Utilitario.Constantes.POSICIONCONTADORVENTASPRESUPUESTADAS].Text == NombreGlosaTotalFinal)
				{	
					lbl = (Label)e.Item.Cells[POSICIONCALLAO].FindControl(CONTROLBL1);
					lbl.ForeColor = Color.Black;
					lbl.Font.Size = FontUnit.Point(8);
					lbl.Font.Bold = true;

					lbl = (Label)e.Item.Cells[POSICIONCHIMBOTE].FindControl(CONTROLBL2);
					lbl.ForeColor = Color.Black;
					lbl.Font.Size = FontUnit.Point(8);
					lbl.Font.Bold = true;

					lbl = (Label)e.Item.Cells[POSICIONIQUITOS].FindControl(CONTROLBL3);
					lbl.ForeColor = Color.Black;
					lbl.Font.Size = FontUnit.Point(8);
					lbl.Font.Bold = true;

					Helper.ConfigurarColorTotalesGrilla(e);
				}
				else
				{
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				}
			}

			if(e.Item.ItemType == ListItemType.Header)
			{ 
				//Centro Operativo Callao
				e.Item.Cells[POSICIONCALLAO].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[POSICIONCALLAO].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					                                        Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.IdCentroOperativo.SimaCallao).ToString() + Utilitario.Constantes.SIGNOAMPERSON + 
																				  CENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + CENTROOPERATIVOCALLAO + Utilitario.Constantes.SIGNOAMPERSON +
												                                  Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Utilitario.Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
													                              VERSION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(this.ddlbVersion.SelectedValue).ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
																				  ANO + Utilitario.Constantes.SIGNOIGUAL + ddlbAño.SelectedValue + Utilitario.Constantes.SIGNOAMPERSON + 
																				  KEYFLAGPAGINA + Utilitario.Constantes.SIGNOIGUAL + PORTIPOCLIENTE.ToString()));

				e.Item.Cells[POSICIONCALLAO].Font.Underline=true;
				e.Item.Cells[POSICIONCALLAO].Style[Utilitario.Constantes.CURSOR] = Utilitario.Constantes.TIPOCURSORMANO;

			   //Centro Operativo Chimbote
				e.Item.Cells[POSICIONCHIMBOTE].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[POSICIONCHIMBOTE].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					                                           Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.IdCentroOperativo.SimaChimbote).ToString() + Utilitario.Constantes.SIGNOAMPERSON + 
													           CENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + CENTROOPERATIVOCHIMBOTE + Utilitario.Constantes.SIGNOAMPERSON +
													           Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Utilitario.Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
													           VERSION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(this.ddlbVersion.SelectedValue).ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
															   ANO + Utilitario.Constantes.SIGNOIGUAL + ddlbAño.SelectedValue + Utilitario.Constantes.SIGNOAMPERSON + 
															   KEYFLAGPAGINA + Utilitario.Constantes.SIGNOIGUAL + PORTIPOCLIENTE.ToString()));
				e.Item.Cells[POSICIONCHIMBOTE].Font.Underline=true;
				e.Item.Cells[POSICIONCHIMBOTE].Style[Utilitario.Constantes.CURSOR] = Utilitario.Constantes.TIPOCURSORMANO;

				//Centro Operativo Iquitos
				e.Item.Cells[POSICIONIQUITOS].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[POSICIONIQUITOS].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					                                         Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.IdCentroOperativo.SimaIquitos).ToString() + Utilitario.Constantes.SIGNOAMPERSON + 
													         CENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + CENTROOPERATIVOIQUITOS + Utilitario.Constantes.SIGNOAMPERSON +
													         Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Utilitario.Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
													         VERSION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(this.ddlbVersion.SelectedValue).ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
															 ANO + Utilitario.Constantes.SIGNOIGUAL + ddlbAño.SelectedValue + Utilitario.Constantes.SIGNOAMPERSON + 
															 KEYFLAGPAGINA + Utilitario.Constantes.SIGNOIGUAL + PORTIPOCLIENTE.ToString()));
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

			if(Convert.ToInt32(ddlbAño.SelectedValue) >= DateTime.Now.Year)
			{
				ddlbVersion.Enabled = true;
				ddlbVersion.SelectedIndex = Utilitario.Constantes.POSICIONCONTADOR;
			}
			else
			{
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
	}
}