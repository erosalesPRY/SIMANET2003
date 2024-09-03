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
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras
{
	public class AdministrarDescuento : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro de Letras.";  
		const string KEYIDTIPOLETRA = "TipoLetra";
		const string KEYNOMBRETIPOLETRA = "NombreTipoLetra";

		const string KEYIDDOCDESCLET ="idDocdescLetra";
		
		const string KEYIDENTIDADFINANCIERA = "idEF";
		const string URLPAGINADETALLE = "DetalleDescuento.aspx?";
		const string URLPAGINALETRASDESCUENTO = "AdministrarPaquetedeLetras.aspx?";

		const string CAMPOTOTAL1 = "lblMontoDesembolso";
		const string CAMPOTOTAL2 = "lblMontoDescuento";
		const string CAMPOTOTAL3 = "lblMontoLetras";
		const string CAMPOTOTAL4 = "lblMontoAmortizado";
		const string CAMPOTOTAL5= "lblMontoSaldo";

		//Filtro
		const string CENTROOPERATIVO ="Centro";
		const string ENTIDADFINACIERA="EntidadFinanciera";
		const string DOCUMENTO ="NroDescuento";
		const string FECHADESEMBOLSO ="FechaDesembolso";
		const string MONEDA ="Moneda";
		const string KEYIDMONEDA = "idMoneda";		
		#endregion
		
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnLetrasenDescuento;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidDescuento;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidMoneda;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
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
					this.LlenarDatos();
					this.LlenarCombos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina(this);
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value ,Convert.ToInt32(hGridPagina.Value));
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
			this.ibtnFiltar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnLetrasenDescuento.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnLetrasenDescuento_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarDescuento.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarDescuento.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			return ((CDescuento) new CDescuento()).AdministrarDetalleDescuento(
				Convert.ToString(Utilitario.Constantes.IDDEFAULT)
				,Convert.ToInt32(Page.Request.Params[KEYIDTIPOLETRA])
				,Convert.ToInt32(Page.Request.Params[KEYIDENTIDADFINANCIERA]==null? Utilitario.Constantes.IDDEFAULT.ToString():Page.Request.Params[KEYIDENTIDADFINANCIERA]));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			DataTable dtLetras=this.ObtenerDatos();
			if(dtLetras!=null)
			{
				DataView dwLetras= dtLetras.DefaultView;
				dwLetras.RowFilter = Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwLetras.Count.ToString();
				dwLetras.Sort = columnaOrdenar ;
				grid.DataSource = dwLetras;
				grid.CurrentPageIndex = indicePagina;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtLetras;
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
			// TODO:  Add AdministrarDescuento.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblPagina.Text = Page.Request.Params[KEYNOMBRETIPOLETRA].ToString();
		}

		public void LlenarJScript()
		{			
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
			ibtnLetrasenDescuento.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarDescuento.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarDescuento.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarDescuento.Exportar implementation
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
			// TODO:  Add AdministrarDescuento.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

			Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
					Helper.MostrarVentana(URLPAGINADETALLE,KEYIDDOCDESCLET + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaDescuento.idDescuento.ToString()].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRA].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYNOMBRETIPOLETRA].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M.ToString()));

				((Label)e.Item.Cells[7].FindControl(CAMPOTOTAL1)).Text = Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaDescuento.MontoDesembolso.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[7].FindControl(CAMPOTOTAL2)).Text = Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaDescuento.MontoInteresCobradoBCO.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[7].FindControl(CAMPOTOTAL3)).Text = Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaDescuento.MontoLetras.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[7].FindControl(CAMPOTOTAL4)).Text = Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaDescuento.MontoAmortiza.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[7].FindControl(CAMPOTOTAL5)).Text = Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaDescuento.SaldoLetra.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hidDescuento",dr[Utilitario.Enumerados.FinColumnaDescuento.idDescuento.ToString()].ToString())
																,Helper.MostrarDatosEnCajaTexto("hidMoneda",dr[Utilitario.Enumerados.FinColumnaDescuento.IdMoneda.ToString()].ToString()));
				
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);

			}
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPAGINADETALLE + KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRA].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYNOMBRETIPOLETRA].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N.ToString());
		}

		private void ibtnLetrasenDescuento_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{			
			if(hidDescuento.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(), Mensajes.CODIGOMENSAJEERRORCTABANCARIASELECCIONDCTOREQUERIDO));
			}
			else
			{
				Page.Response.Redirect(URLPAGINALETRASDESCUENTO + KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRA].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYNOMBRETIPOLETRA].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDDOCDESCLET + Utilitario.Constantes.SIGNOIGUAL + hidDescuento.Value
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDMONEDA + Utilitario.Constantes.SIGNOIGUAL + this.hidMoneda.Value);
			}
		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnFiltar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro(this,ObtenerDatos(),Utilitario.Constantes.SIGNOASTERISCO + CENTROOPERATIVO + ";Centro"
																		,Utilitario.Constantes.SIGNOASTERISCO + ENTIDADFINACIERA + ";Entidad Financiera"
																		,DOCUMENTO + ";Documento"
																		,FECHADESEMBOLSO + ";Fecha Desembolso"
																		,Utilitario.Constantes.SIGNOASTERISCO + MONEDA + ";Moneda"
													);
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}
	}
}
