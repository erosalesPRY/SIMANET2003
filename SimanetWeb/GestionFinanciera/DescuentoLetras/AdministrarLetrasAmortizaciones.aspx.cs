using System;
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
using MetaBuilders.WebControls;
using SIMA.SimaNetWeb.Legal;

namespace SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras
{
	public class AdministrarLetrasAmortizaciones : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  

		const string KEYIDDOCDESCLET ="idDocdescLetra";
		const string KEYIDLETDESCTDET ="idLetraDesctDet";
		const string KEYIDLETDESCTAMORTIZA ="idLetraDesctAmortiza";

		const string KEYIDTIPOLETRA = "TipoLetra";
		const string KEYNOMBRETIPOLETRA = "NombreTipoLetra";
		const string KEYIDCENTRO = "idCentro";

		const string URLLETRAAMORTIZA = "DetalleAmortizacion.aspx?";
		

		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.WebControls.Label Label12;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroReferencia;
		protected System.Web.UI.WebControls.TextBox txtNroDocumento;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.TextBox txtDatosProyecto;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTasaInteres;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdLetra;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCentro;
		protected System.Web.UI.HtmlControls.HtmlInputText txtSituacion;
		protected System.Web.UI.HtmlControls.HtmlInputText txtMoneda;
		protected System.Web.UI.HtmlControls.HtmlInputText hNumero;
		protected System.Web.UI.HtmlControls.HtmlInputText txtEntidad;
		protected System.Web.UI.HtmlControls.HtmlTextArea txtProyecto;
		protected System.Web.UI.HtmlControls.HtmlInputText txtFechaInicio;
		protected System.Web.UI.HtmlControls.HtmlInputText txtFechaVence;
		protected System.Web.UI.HtmlControls.HtmlInputText NDiasPlazo;
		protected System.Web.UI.HtmlControls.HtmlInputText nDiasVence;
		protected System.Web.UI.HtmlControls.HtmlInputText nMonto;
		protected System.Web.UI.HtmlControls.HtmlInputText nTasaInteres;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarCombos();
					this.CargarModoConsulta();
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
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception oException)
				{
					string debug = oException.Message.ToString();
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
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarLetrasAmortizaciones.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarLetrasAmortizaciones.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return ((CLetrasDescuentoAmortiza) new CLetrasDescuentoAmortiza()).AdministrarDetalleLetrasDescuentoAmortiza(Convert.ToString(Page.Request.Params[KEYIDLETDESCTDET]),
																															Convert.ToString(Utilitario.Constantes.IDDEFAULT));
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
				ibtnImprimir.Visible = true;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtLetras;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				//ibtnImprimir.Visible = false;
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
			this.CargarSituacion();
		}
		private void CargarSituacion()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoLetrasDescuento));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();			
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarLetrasAmortizaciones.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarLetrasAmortizaciones.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarLetrasAmortizaciones.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarLetrasAmortizaciones.Exportar implementation
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
			// TODO:  Add AdministrarLetrasAmortizaciones.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarLetrasAmortizaciones.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarLetrasAmortizaciones.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarLetrasAmortizaciones.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarLetrasAmortizaciones.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarLetrasAmortizaciones.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarLetrasAmortizaciones.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			LetrasDescuentoBE oLetrasDescuentoBE  = (LetrasDescuentoBE)((CLetrasDescuento) new CLetrasDescuento()).DetalleLetrasDescuento(Page.Request.Params[KEYIDDOCDESCLET].ToString(),Page.Request.Params[KEYIDLETDESCTDET].ToString());
			this.txtNroDocumento.Text =	oLetrasDescuentoBE.NroDocumento.ToString();
			this.hIdLetra.Value = oLetrasDescuentoBE.IdLetra.ToString();
			this.txtCentro.Value= oLetrasDescuentoBE.AbreviaturaCentroOperativo.ToString();
			((ListItem) this.ddlbSituacion.Items.FindByValue(oLetrasDescuentoBE.IdEstado.ToString())).Selected = true;
			this.txtSituacion.Value = oLetrasDescuentoBE.Situacion;
			this.txtProyecto.Value =  oLetrasDescuentoBE.NombreProyecto.ToString();
			this.txtDatosProyecto.Text=  oLetrasDescuentoBE.DescripcionProyecto.ToString();
			this.txtFechaInicio.Value= oLetrasDescuentoBE.FechaInicio.ToShortDateString();
			this.txtFechaVence.Value =  oLetrasDescuentoBE.FechaVencimiento.ToString().Substring(0,10);
			this.NDiasPlazo.Value = oLetrasDescuentoBE.NroDiasPlazo.ToString();
			this.nDiasVence.Value =  oLetrasDescuentoBE.NroDiasFaltantes.ToString();
			this.txtMoneda.Value= oLetrasDescuentoBE.Moneda.ToString();
			this.hNumero.Value =  oLetrasDescuentoBE.NroEntidad.ToString();
			this.txtEntidad.Value= oLetrasDescuentoBE.RazonSocial.ToString();
			this.nMonto.Value = oLetrasDescuentoBE.Monto.ToString();
			this.nTasaInteres.Value =  oLetrasDescuentoBE.TasaInteres.ToString();
			this.txtObservacion.Text =  oLetrasDescuentoBE.Observacion.ToString();
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarLetrasAmortizaciones.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarLetrasAmortizaciones.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarLetrasAmortizaciones.ValidarExpresionesRegulares implementation
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
					Helper.MostrarVentana(URLLETRAAMORTIZA,KEYIDDOCDESCLET + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDDOCDESCLET].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYIDLETDESCTDET + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaLetrasDescuentoAmortiza.idLetrasDescuento.ToString()].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRA].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYNOMBRETIPOLETRA].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYIDLETDESCTAMORTIZA + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaLetrasDescuentoAmortiza.idLetraDescuentoAmortiza.ToString()].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModoPagina.M.ToString()));
			
				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text = Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}		
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLLETRAAMORTIZA +
					KEYIDDOCDESCLET + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDDOCDESCLET].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDLETDESCTDET + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDLETDESCTDET].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRA].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYNOMBRETIPOLETRA].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModoPagina.N.ToString());
		
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	

		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());

		}
	}
}
