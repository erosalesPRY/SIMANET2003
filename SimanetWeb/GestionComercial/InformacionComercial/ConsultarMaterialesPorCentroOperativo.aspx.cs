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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial.InformacionComercial
{
	/// <summary>
	/// Summary description for ConsultarMaterialesPorCentroOperativo.
	/// </summary>
	public class ConsultarMaterialesPorCentroOperativo : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRuta_Pagina;
		protected System.Web.UI.WebControls.Label lblPage;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.Label lblFechaInicio;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected System.Web.UI.WebControls.Label lblFechaFin;
		protected eWorld.UI.CalendarPopup CalFechaFin;
		protected System.Web.UI.WebControls.ImageButton ibtnConsultar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region Constantes
		
		//Paginas
		const string URLPRINCIPAL = "../Default.aspx";
		
		//Key Session y QueryString
		const string KEYFECHAINICIO = "FechaInicio";
		const string KEYFECHAFIN = "FechaFin";
		
		//Otros
		const int POSICIONINICIALCOMBO = 0;
		const string TablaImpresion0 = "MaterialesPorCentroOperativo";
		const string GRILLAVACIA ="No existe ningún Material.";
		const string DEFAULTANO = "01/01/";
		const string NombreGlosaTotales = "TOTAL";
		const int PosicionFchEms		= 0;
		const int PosicionMat			= 1;
		const int PosicionUndMdd		= 2;
		const int PosicionDcp			= 3;

		const int PosicionGrv			= 4;
		const int PosicionStkGrv		= 4;
		const int PosicionPrcPmdSolGrv	= 5;

		const int PosicionExo			= 5;
		const int PosicionStkExo		= 6;
		const int PosicionPrcPmdSolExo	= 7;

		const int PosicionUltCmp		= 6;
		const int PosicionPrcUltCmpSol	= 8;
		const int PosicionFchUltCmp		= 9;

		const int PosicionFchUltSda		= 7;
		const int PosicionUbc			= 8;

		const String CampoStkGrv = "lblStkGrvS";
		const String CampoPrcPmdSolGrv = "lblPrcPmdSolGrvS";
		const String CampoStkExo = "lblStkExoS";
		const String CampoPrcPmdSolExo = "lblPrcPmdSolExoS";
		const String CampoPrcUltCmpSol = "lblPrcUltCmpSolS";
		const String CampoFchUltCmp = "lblFchUltCmpS";
		
		const String NombreStkGrv			= "STOCK_GRAVADO";
		const String NombrePrcPmdSolGrv	= "PRC_PMD_SOLES_GRA";
		const String NombreStkExo			= "STOCK_EXONERADO";
		const String NombrePrcPmdSolExo	= "PRC_PMD_SOLES_EXO";
		const String NombrePrcUltCmpSol	= "PRC_ULT_COMPRA_SOLES";
		const String NombreFchUltCmp		= "FEC_ULT_COMPRA";

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					CalFechaInicio.SelectedDate = Convert.ToDateTime(DEFAULTANO + DateTime.Today.Year.ToString());
					CalFechaInicio.SelectedDate = Convert.ToDateTime(DEFAULTANO + "1997");
					CalFechaFin.SelectedDate = DateTime.Today.Date;

					this.ConfigurarAccesoControles();
					
					Helper.ReiniciarSession();
					//this.LlenarGrilla();
					//this.LlenarJScript();
					//this.EstadoControles();
					//this.LlenarDatos();
					//LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultaron Materiales por Centro Operativo.",Enumerados.NivelesErrorLog.I.ToString()));
					//this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento() ,Constantes.INDICEPAGINADEFAULT);
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
					ltlMensaje.Text = Helper.MensajeAlert(((string) oSIMAExcepcionDominio.Mensaje));					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
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
			this.ibtnConsultar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnConsultar_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dtImpresion = new DataTable();

			DataTable dtMaterialesPorCentroOperativo = new DataTable();
			CMaterial oCMaterial = new CMaterial();

			dtMaterialesPorCentroOperativo =  oCMaterial.ConsultarMaterialesPorCentroOperativo(Convert.ToDateTime(CalFechaInicio.SelectedDate),Convert.ToDateTime(CalFechaFin.SelectedDate));

			if(dtMaterialesPorCentroOperativo!=null)
			{
				dtImpresion = dtMaterialesPorCentroOperativo.Copy();
				dtImpresion.TableName = TablaImpresion0;

				DataView dwMateriales =	dtMaterialesPorCentroOperativo.DefaultView;
				
				if(dwMateriales.Count > POSICIONINICIALCOMBO)
				{
					grid.DataSource	= dwMateriales;
					lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource	= null;
					lblResultado.Visible = true;
					lblResultado.Text =	GRILLAVACIA;
				}			
			}
			else
			{
				grid.DataSource	= dtMaterialesPorCentroOperativo;
				lblResultado.Visible = true;
				lblResultado.Text =	GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtImpresion,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Mensajes.CODIGOTITULOVENTASREALESPORCLIENTE));
			}
			catch(Exception	ex)
			{
				string a = ex.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}	
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		// TODO:  Add ConsultarDetalleMontoCliente.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtImpresion = new DataTable();

			DataTable dtMaterialesPorCentroOperativo = new DataTable();
			CMaterial oCMaterial = new CMaterial();

			dtMaterialesPorCentroOperativo =  oCMaterial.ConsultarMaterialesPorCentroOperativo(Convert.ToDateTime(CalFechaInicio.SelectedDate),Convert.ToDateTime(CalFechaFin.SelectedDate));

			if(dtMaterialesPorCentroOperativo!=null)
			{
				dtImpresion = dtMaterialesPorCentroOperativo.Copy();
				dtImpresion.TableName = TablaImpresion0;

				DataView dwMateriales =	dtMaterialesPorCentroOperativo.DefaultView;
				
				if(dwMateriales.Count > POSICIONINICIALCOMBO)
				{
					grid.DataSource	= dwMateriales;
					lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource	= null;
					lblResultado.Visible = true;
					lblResultado.Text =	GRILLAVACIA;
				}			
			}
			else
			{
				grid.DataSource	= dtMaterialesPorCentroOperativo;
				lblResultado.Visible = true;
				lblResultado.Text =	GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtImpresion,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Mensajes.CODIGOTITULOVENTASREALESPORCLIENTE));
			}
			catch(Exception	ex)
			{
				string a = ex.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}	
		}
		public void LlenarCombos()
		{
		// TODO:  Add ConsultarDetalleMontoCliente.LlenarCombos implementation		
		}
		public void EstadoControles()
		{
			Helper.SeleccionarItemCombos(this);
		}
		public void LlenarDatos()
		{
		
		}
	
		public void LlenarJScript()
		{
		// TODO:  Add ConsultarDetalleMontoCliente.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
		// TODO:  Add ConsultarDetalleMontoCliente.RegistrarJScript implementation
		}

		/// <summary>
		/// Imprime los datos
		/// </summary>
		public void Imprimir()
		{
		
		}

		public void Exportar()
		{
		// TODO:  Add ConsultarDetalleMontoCliente.Exportar implementation
		}

		/// <summary>
		/// Configura las controles del formulario web en base a los privilegios del perfil
		/// </summary>
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

		/// <summary>
		/// Valida los filtros a emplear
		/// </summary>
		public bool ValidarFiltros()
		{
			if(CalFechaInicio.SelectedDate.Year < Utilitario.Constantes.ANOMINIMA)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEVALIDACIONFECHAINICIO));
				return false;
			}
			else if (CalFechaFin.SelectedDate.Year >  DateTime.Today.Year)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEVALIDACIONFECHATERMINOCONFECHAACTUAL));
				return false;
			}
			else if(!Helper.ValidarRangoFechas(CalFechaInicio.SelectedDate,CalFechaFin.SelectedDate))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEVALIDACIONFECHATERMINO));
				return false;	
			}

			return true;
		}
	
		#endregion

		private void ibtnConsultar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(this.ValidarFiltros())
			{
				this.LlenarGrilla();

				try
				{
					CalFechaInicio.SelectedDate = Convert.ToDateTime(DEFAULTANO + DateTime.Today.Year.ToString());
					CalFechaInicio.SelectedDate = Convert.ToDateTime(DEFAULTANO + "1997");
					CalFechaFin.SelectedDate = DateTime.Today.Date;

					//this.LlenarGrilla();
					//this.LlenarJScript();
					//this.EstadoControles();
					//this.LlenarDatos();
					//LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultaron Materiales por Centro Operativo.",Enumerados.NivelesErrorLog.I.ToString()));
					//this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento() ,Constantes.INDICEPAGINADEFAULT);
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
					ltlMensaje.Text = Helper.MensajeAlert(((string) oSIMAExcepcionDominio.Mensaje));					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}

			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Label lbl;
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if((DBNull.Value.Equals(e.Item.Cells[PosicionFchEms])))
				{
					e.Item.Cells[PosicionFchEms].Text = "";
				}
				else{
					e.Item.Cells[PosicionFchEms].Text = Convert.ToDateTime(e.Item.Cells[PosicionFchEms].Text).ToString(Constantes.FORMATOFECHA3);
				}
				
				e.Item.Cells[PosicionMat].Text = Convert.ToString(e.Item.Cells[PosicionMat].Text);
			
				e.Item.Cells[PosicionUndMdd].Text = Convert.ToString(e.Item.Cells[PosicionUndMdd].Text);

				e.Item.Cells[PosicionDcp].Text = Convert.ToString(e.Item.Cells[PosicionDcp].Text);

				lbl = (Label)e.Item.Cells[PosicionGrv].FindControl(NombreStkGrv);
				if((DBNull.Value.Equals(dr[PosicionStkGrv])))
				{
					lbl.Text = "";
				}
				else{
					lbl.Text = Convert.ToDouble(dr[PosicionStkGrv]).ToString(Constantes.FORMATODECIMAL3);
				}
				
				lbl = (Label)e.Item.Cells[PosicionGrv].FindControl(NombrePrcPmdSolGrv);
				if((DBNull.Value.Equals(dr[PosicionPrcPmdSolGrv])))
				{
					lbl.Text = "";
				}
				else
				{
					lbl.Text = Convert.ToDouble(dr[PosicionPrcPmdSolGrv]).ToString(Constantes.FORMATODECIMAL6);
				}

				lbl = (Label)e.Item.Cells[PosicionExo].FindControl(NombreStkExo);
				if((DBNull.Value.Equals(dr[PosicionStkExo])))
				{
					lbl.Text = "";
				}
				else
				{
					lbl.Text = Convert.ToDouble(dr[PosicionStkExo]).ToString(Constantes.FORMATODECIMAL3);
				}
				
				lbl = (Label)e.Item.Cells[PosicionExo].FindControl(NombrePrcPmdSolExo);
				if((DBNull.Value.Equals(dr[PosicionPrcPmdSolExo])))
				{
					lbl.Text = "";
				}
				else
				{
					lbl.Text = Convert.ToDouble(dr[PosicionPrcPmdSolExo]).ToString(Constantes.FORMATODECIMAL6);
				}

				lbl = (Label)e.Item.Cells[PosicionUltCmp].FindControl(NombrePrcUltCmpSol);
				if((DBNull.Value.Equals(dr[PosicionPrcUltCmpSol])))
				{
					lbl.Text = "";
				}
				else
				{
					lbl.Text = Convert.ToDouble(dr[PosicionPrcUltCmpSol]).ToString(Constantes.FORMATODECIMAL6);
				}
				
				lbl = (Label)e.Item.Cells[PosicionUltCmp].FindControl(NombreFchUltCmp);
				if((DBNull.Value.Equals(dr[PosicionFchUltCmp])))
				{
					lbl.Text = "";
				}
				else
				{
					lbl.Text = Convert.ToDateTime(dr[PosicionFchUltCmp]).ToString(Constantes.FORMATOFECHA3);
				}

				if((DBNull.Value.Equals(e.Item.Cells[PosicionFchUltSda])))
				{
					e.Item.Cells[PosicionFchUltSda].Text = "";
				}
				else
				{
					e.Item.Cells[PosicionFchUltSda].Text = Convert.ToDateTime(e.Item.Cells[PosicionFchUltSda].Text).ToString(Constantes.FORMATOFECHA3);
				}

				e.Item.Cells[PosicionUbc].Text = Convert.ToString(e.Item.Cells[PosicionUbc].Text);

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
			
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnAtras_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		}
	}
}
