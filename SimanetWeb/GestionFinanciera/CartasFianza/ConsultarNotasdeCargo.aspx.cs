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
using SIMA.EntidadesNegocio.GestionFinanciera;


namespace SIMA.SimaNetWeb.GestionFinanciera.CartasFianza
{
	/// <summary>
	/// Summary description for ConsultarNotasdeCargo.
	/// </summary>
	public class ConsultarNotasdeCargo : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string OBJPARAMETROCONTABLE="ParametroCartaFza";
		const string KEYIDDETCF="idDetCF";
		const string KEYIDCARTAFZA="idCartaFza";
		const string KEYIDPERIODO="Periodo";
		const string KEYIDFECHA= "Fecha";
		
		const string COLORDENAMIENTO = "Fecha";
		const int IDTABLAESTADOCARTAFIANZA=5;
		const string GRILLAVACIA="No Existen Datos";
		const string CONTRONAME="lblTotalDolares";
		const string URLPRINCIPAL="DetalledeCartaFianza.aspx";
		const string KEYQIDCENTRO="IdCentro";
		const string MENSAJECONFIRMACIONIMPORTACION ="Importación termino con exito..";




		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtCentro;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtSituacion;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtNroFza;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtNombreMoneda;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtFechaApertura;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtFechaVencimiento;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtMontoFza;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.TextBox txtBanco;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.ImageButton imgbtnImportar;
		#endregion

		#region Variables
			
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					this.LlenarDatos();
					this.MostrarDetalle();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}		
		}

		private void MostrarDetalle()
		{
			CCartaFianza oCCartaFianza = new CCartaFianza();
			CartaFianzaBE oCartaFianzaBE = (CartaFianzaBE) oCCartaFianza.DetalleCartaFianza(Convert.ToInt32(Page.Request.Params[KEYIDDETCF]),
																							Convert.ToInt32(Page.Request.Params[KEYIDCARTAFZA]),
																							Convert.ToInt32(Page.Request.Params[KEYIDPERIODO])) ;

            
			this.txtCentro.Text = oCartaFianzaBE.Centro.ToString();
			this.txtBanco.Text= oCartaFianzaBE.NombreEntidadFinanciera.ToString();
			this.txtNroFza.Text = oCartaFianzaBE.NroFianza.ToString();
			this.txtNombreMoneda.Text = oCartaFianzaBE.Moneda.ToString();
			this.txtSituacion.Text = oCartaFianzaBE.Situacion.ToString();
			this.txtFechaApertura.Text = oCartaFianzaBE.FechaApertura.ToString().Substring(0,10).Replace("/","-");
			this.txtFechaVencimiento.Text = oCartaFianzaBE.FechaVencimiento.ToString().Substring(0,10).Replace("/","-");
			this.txtMontoFza.Text = oCartaFianzaBE.MontoCartaFza.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			Helper.BloquearControles(this);
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
			this.imgbtnImportar.Click += new System.Web.UI.ImageClickEventHandler(this.imgbtnImportar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarNotasdeCargo.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarNotasdeCargo.LlenarGrillaOrdenamiento implementation
		}

		private void GenerarResumen(DataTable dt)
		{
			if (dt!=null)
			{
				int NroResumen = 3;
				CResumenItem oCResumenItem = new CResumenItem();
				DataTable dtFinal= Helper.Resumen(oCResumenItem.ObtenerConfiDataResumen(NroResumen),dt);
				//gridResumen.DataSource =dtFinal;
			}
			else
			{
				//gridResumen.DataSource =dt;	
			}
			//gridResumen.DataBind();
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CCartaFianza oCCartaFianza = new CCartaFianza();
			DataTable dtCartaFianza = oCCartaFianza.ConsultarCartaFianzaNotadeCargo(Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO])
																					,Convert.ToInt32(Page.Request.Params[KEYIDDETCF])
																					,Convert.ToInt32(Page.Request.Params[KEYIDCARTAFZA])
																					,Convert.ToInt32(Page.Request.Params[KEYIDPERIODO]));

			if(dtCartaFianza!=null)
			{
				DataView dwCartaFianza = dtCartaFianza.DefaultView;
				//this.GenerarResumen(dtCartaFianza);
				dwCartaFianza.RowFilter = Helper.ObtenerFiltro();
				dwCartaFianza.Sort = columnaOrdenar ;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwCartaFianza.Count.ToString();

				grid.DataSource = dwCartaFianza;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtCartaFianza,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				lblResultado.Visible = false;

			}
			else
			{
				this.GenerarResumen(dtCartaFianza);
				grid.DataSource = dtCartaFianza;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch(Exception e)
			{
				string a = e.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}

			// TODO:  Add ConsultarNotasdeCargo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			
			// TODO:  Add ConsultarNotasdeCargo.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.txtMontoFza.Style[Utilitario.Constantes.ALINEAMIENTOTEXTO] = TextAlign.Right.ToString();

			// TODO:  Add ConsultarNotasdeCargo.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarNotasdeCargo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarNotasdeCargo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarNotasdeCargo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarNotasdeCargo.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}						
			// TODO:  Add ConsultarNotasdeCargo.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarNotasdeCargo.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				if (Convert.ToInt32(dr[KEYIDDETCF]) == Convert.ToInt32(Page.Request.Params[KEYIDDETCF]))
				{e.Item.BackColor = Color.LightYellow;}
				e.Item.Cells[3].Text = Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = Convert.ToDouble(e.Item.Cells[5].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				#region Helpers
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
					Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				#endregion
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		private void gridResumen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void gridResumen_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Cells[0].Text = Convert.ToDouble(e.Item.Cells[0].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}			
		
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void imgbtnImportar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				int i = ((CCartaFianza) new CCartaFianza()).ImportarCartaFianzaNotasdeCargo();
				ASPNetUtilitario.MessageBox.Show(MENSAJECONFIRMACIONIMPORTACION);
				this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
				this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
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
				ASPNetUtilitario.MessageBox.Show(oException.Message.ToString());
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}
	}
}
