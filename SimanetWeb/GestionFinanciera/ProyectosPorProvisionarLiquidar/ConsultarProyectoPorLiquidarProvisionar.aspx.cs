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

namespace SIMA.SimaNetWeb.GestionFinanciera.ProyectosPorProvisionarLiquidar
{
	public class ConsultarProyectoPorLiquidarProvisionar : System.Web.UI.Page, IPaginaBase
	{
		#region Constantes
		private const string MENSAJECONSULTAR = "Se Consulto el Detalle de Cuentas por Liquidar/Provisionar";
		private const string URLDETALLE="../EstadosFinancieros/Directorio/ConsultarVentasLiquidadas.aspx?";
		private const string KEYIDLIQUIDADO="IdProyectoLiquidado";
		private const string KEYIDCENTRO="IdCentro";
		private const string KEYLN ="LN";
		private const string KEYTIPOCLIENTE ="TipoCliente";
		const string KEYTIPOCLIENTEPMGP="KEYTIPOCLIENTEPMGP";
		private const string KEYIDPERIODO="KEYIDPERIODO";
		private const string KEYIDPERIODOFILTRO="KEYIDPERIODOFILTRO";
		private const string KEYIDMES="KEYIDMES";
		private const string KEYCONCEPTO="KEYCONCEPTO";
		private	const string KEYQIDFECHA = "efFecha";
		private	const string KEYQFLAGDIRECTORIO= "FlagDirectorio";
		private const string GRILLAVACIA="No existen registros";
		private const string KEYQIDFORMATO = "IdFormato";
		private const string KEYQIDRUBRO = "IdRubro";
		private const string KEYID="KEYID";

		private const string idtabla="IdTablaFila";
		private const string JSCRIPTTRES=" ArrayGrupo[";
		private const string JSCRIPCUATRO=" ArrayEstado[";
		private const string JSCRIPTCINCO=" AsignarIndiceSeleccionGrilla('";
		private const string JSCRIPTSEIS="',this);";
		private const string JPALABRAVAR="var ";
		private const string JSCRIPTDOS=" =new Array(); ";
		private const string ARRAYORDEN="ArrayOrden";
		private const string PALABRASTYLE="style";
		private const string PALABRADISPLAY="display: none";
		private const string ESPACIOSTML="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" ;
		private const string COLORDENAMIENTO = "Id";

		private const int PARAMETROIMPRESIONANCHO=800;
		private const int PARAMETROIMPRESIONALTO=400;
		private const string CONTROLINK="hlkId";
		private const string CONTROLIMGEN="ImgbtId";
		DataTable dtAnos;

		#endregion
		
		#region Variables
		private string CadenaJavaScript=Utilitario.Constantes.VACIO;
		private string NombreArray=Utilitario.Constantes.VACIO;
		private int IndiceArray=Utilitario.Constantes.ValorConstanteCero;
		private string CadenaAsignarArray=Utilitario.Constantes.VACIO;
		private int IndiceGrupo=Utilitario.Constantes.ValorConstanteCero;
		private string URLIMAGENES="../../imagenes/tree/plus.gif";
		private string JSCRIPTUNO=" return false;";

		private int Cantidad=0;
		private double CostoProduccion=0;
		private double Facturado=0;
		private double Resultado=0;

		string IdTablaRow = Utilitario.Constantes.VACIO;
		#endregion
		
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlTable IdCabezaTabla;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnAbrir;
		protected projDataGridWeb.DataGridWeb gridResumen;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblResultado;
		#endregion
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
			this.ddlbPeriodo.SelectedIndexChanged += new System.EventHandler(this.ddlbPeriodo_SelectedIndexChanged);
			this.ibtnAbrir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAbrir_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.gridResumen.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumen_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			if(Convert.ToInt32(Session[Utilitario.Constantes.KEYQOBSERVACION])==1)
			{
				Session["PROYECTOPORLIQUIDAR"]=1;// CUANDO ENTRO POR PROYECTOS POR LIQUIDAR
			}
			else
				Session["PROYECTOPORLIQUIDAR"]=null;

			DataTable dtGeneral = this.ObtenerDatos();
			DataTable dtImpresion = new DataTable();
			
			if(dtGeneral!=null)
			{
				dtImpresion = dtGeneral.Copy();
				DataView dwGeneral = dtGeneral.DefaultView;
				grid.DataSource = dwGeneral;
				lblResultado.Visible = Constantes.VALORUNCHECKEDBOOL;
				this.ibtnImprimir.Visible = Utilitario.Constantes.VALORUNCHECKEDBOOL;
				//this.ibtnImprimir.Visible = Constantes.VALORCHECKEDBOOL;
			}
			else
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = Utilitario.Constantes.VALORCHECKEDBOOL;
				this.IdCabezaTabla.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				lblResultado.Text = GRILLAVACIA;
				this.ibtnImprimir.Visible = Utilitario.Constantes.VALORUNCHECKEDBOOL;

			}
			try
			{
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtImpresion,"Consultar Proyectos Por Liquidar",Utilitario.Constantes.VACIO);
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				grid.DataBind();
			}	

			LlenarGrillaResumen();
			/*DataTable dtProyectos =  ObtenerDatos();
			
			if(dtProyectos!=null)
			{
				DataView dwProyectos = dtProyectos.DefaultView;
				dwProyectos.RowFilter = Helper.ObtenerFiltro(this);
				if(dwProyectos.Count>0)
				{
					grid.DataSource = dwProyectos;
					grid.Columns[2].FooterText = dwProyectos.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				
			}
			else
			{
				grid.DataSource = dtProyectos;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.DataBind();
			}*/
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public DataTable ObtenerDatos()
		{
			CProyectosPorLiquidarProvisionar oCProyectosPorLiquidarProvisionar = new CProyectosPorLiquidarProvisionar();
			if (Convert.ToInt32(Page.Request.QueryString[KEYQFLAGDIRECTORIO]) == Constantes.POSICIONINDEXUNO)
			{
				return oCProyectosPorLiquidarProvisionar.ConsultarProyectosLiquidadosPorCentroOperativoAlCierre(
					Convert.ToInt32(Page.Request.QueryString[KEYIDCENTRO]),
					Convert.ToDateTime(Page.Request.QueryString[KEYQIDFECHA]),
					Convert.ToInt32(ddlbPeriodo.SelectedValue)
					);
			}
			else
			{
				return oCProyectosPorLiquidarProvisionar.ConsultarProyectosLiquidadosPorCentroOperativo(
					Convert.ToInt32(Page.Request.QueryString[KEYIDCENTRO]),
					Convert.ToInt32(ddlbPeriodo.SelectedValue));
			}
		}
		public DataTable ObtenerDatosResumen()
		{
			CProyectosPorLiquidarProvisionar oCProyectosPorLiquidarProvisionar = new CProyectosPorLiquidarProvisionar();
			if (Convert.ToInt32(Page.Request.QueryString[KEYQFLAGDIRECTORIO]) == Constantes.POSICIONINDEXUNO)
			{
				return oCProyectosPorLiquidarProvisionar.ConsultarResumenProyectosPorLiquidarProvisionarPorLineaNegocioDetalleAlCierre(
					Convert.ToInt32(Page.Request.QueryString[KEYIDCENTRO]),
					Convert.ToDateTime(Page.Request.QueryString[KEYQIDFECHA]),
					Convert.ToInt32(ddlbPeriodo.SelectedValue)
					);
			}
			else
			{
				return oCProyectosPorLiquidarProvisionar.ConsultarResumenProyectosPorLiquidarProvisionarPorLineaNegocioDetalle(
					Convert.ToInt32(Page.Request.QueryString[KEYIDCENTRO]),
					Convert.ToInt32(ddlbPeriodo.SelectedValue));
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			
		}

		public void LlenarCombos()
		{
			CProyectosPorLiquidarProvisionar oCProyectosPorLiquidarProvisionar = new CProyectosPorLiquidarProvisionar();
			if (Convert.ToInt32(Page.Request.QueryString[KEYQFLAGDIRECTORIO]) == Constantes.POSICIONINDEXUNO)
			{
				 dtAnos=oCProyectosPorLiquidarProvisionar.ConsultarProyectosLiquidadosPorCentroOperativoAniosAlCierre(Convert.ToInt32(Page.Request.QueryString[KEYIDCENTRO]),Convert.ToDateTime(Page.Request.QueryString[KEYQIDFECHA]));
			}
			else
			{
				dtAnos=oCProyectosPorLiquidarProvisionar.ConsultarProyectosLiquidadosPorCentroOperativoAnios(Convert.ToInt32( Page.Request.QueryString[KEYIDCENTRO]));
			}
				if(dtAnos!=null)
			{
				ddlbPeriodo.DataSource=dtAnos;
				ddlbPeriodo.DataValueField="periodo";
				ddlbPeriodo.DataTextField="periodo";
				ddlbPeriodo.DataBind();

				ListItem litem= new ListItem("-Todos-","0");
				ddlbPeriodo.Items.Insert(0,litem);
			}
			else
			{
				ListItem litem= new ListItem("-Todos-","0");
				ddlbPeriodo.Items.Insert(0,litem);
			}

			if((Page.Request.Params[Utilitario.Constantes.KeyQPaginaValorInicial] != null)  && Page.Request.Params[Utilitario.Constantes.KeyQPaginaValorInicial].ToString() == Utilitario.Constantes.KeyQPaginaValor)
			{
				ListItem item;
				item = ddlbPeriodo.Items.FindByText(SIMA.Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Year.ToString());
				if (item !=null){item.Selected = true;}

				
			}	
			else
			{
				Helper.SeleccionarItemCombos(this);
			}
		}

		public void LlenarDatos()
		{
			/*if(Page.Request.QueryString[KEYIDSIT] == "PEN")
				lblTitulo.Text = lblTitulo.Text  + " Provisionar por Línea de Negocio";
			else
				lblTitulo.Text = lblTitulo.Text  + " Liquidar por Línea de Negocio";*/
		}

		public void LlenarJScript()
		{
		}

		public void RegistrarJScript()
		{
	

		}

		public void Imprimir()
		{
			//ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,PARAMETROIMPRESIONANCHO,PARAMETROIMPRESIONALTO,Utilitario.Constantes.VALORUNCHECKEDBOOL,Utilitario.Constantes.VALORUNCHECKEDBOOL,Utilitario.Constantes.VALORUNCHECKEDBOOL,Utilitario.Constantes.VALORCHECKEDBOOL,Utilitario.Constantes.VALORCHECKEDBOOL);
		}

		public void Exportar()
		{
			
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
			return true;
		}

		#endregion
		
		protected DateTime FechaPeriodo
		{
			get
			{
				return Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year,Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month) + Utilitario.Constantes.SEPARADORFECHA + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month.ToString().PadLeft(2,'0') + Utilitario.Constantes.SEPARADORFECHA + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year.ToString());
			}
		} 

		#region Eventos
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.InicializarVariables();
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					//Helper.ReestablecerPagina(this);
					this.LlenarCombos();
					this.LlenarGrilla();
					this.HacerNoVisiblesFilasDeGrilla();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));
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

					ltlMensaje.Text = Helper.MensajeAlert(oException.Message.ToString());					

					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);

		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{			
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				HyperLink hlk = (HyperLink)e.Item.Cells[Utilitario.Constantes.ValorConstanteCero].FindControl(CONTROLINK);
				hlk.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

				e.Item.ID= idtabla + dr[Enumerados.FINColumnaProyectosPorLiquidar.Id.ToString()].ToString();
				IdTablaRow = e.Item.ID;
				ImageButton img=(ImageButton)e.Item.Cells[Constantes.ValorConstanteCero].FindControl(CONTROLIMGEN);

				if(dr[Enumerados.FINColumnaProyectosPorLiquidar.Id.ToString()].ToString().Length==Constantes.ValorConstanteUno)
				{
					Cantidad+=Convert.ToInt32(dr[Enumerados.FINColumnaProyectosPorLiquidar.Cantidad.ToString()]);
					Resultado+=Convert.ToDouble(dr[Enumerados.FINColumnaProyectosPorLiquidar.Resultado.ToString()]);
					Facturado+=Convert.ToDouble(dr[Enumerados.FINColumnaProyectosPorLiquidar.Facturado.ToString()]);
					CostoProduccion+=Convert.ToDouble(dr[Enumerados.FINColumnaProyectosPorLiquidar.CostosProduccion.ToString()]);

					hlk.Attributes.Add(Constantes.EVENTOCLICK,Constantes.POPUPDEESPERA);
					hlk.Text =dr[Utilitario.Enumerados.FINColumnaProyectosPorLiquidar.DescripcionLN.ToString()].ToString();
					hlk.NavigateUrl = URLDETALLE + KEYLN + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.FINColumnaProyectosPorProvisionarLiquidar.LN.ToString()] + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDFECHA + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDFECHA] + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQFLAGDIRECTORIO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQFLAGDIRECTORIO] + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDLIQUIDADO + Constantes.SIGNOIGUAL + Constantes.IDDEFAULT.ToString() + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDPERIODO + Constantes.SIGNOIGUAL + FechaPeriodo.Year.ToString() + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDPERIODOFILTRO + Constantes.SIGNOIGUAL +ddlbPeriodo.SelectedValue + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDMES + Constantes.SIGNOIGUAL + FechaPeriodo.Month.ToString() + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYCONCEPTO + Constantes.SIGNOIGUAL + dr[Enumerados.FINColumnaProyectosPorLiquidar.DescripcionLN.ToString()] +
						Constantes.SIGNOAMPERSON + KEYQIDFORMATO + 
						Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDFORMATO] +
						Constantes.SIGNOAMPERSON + KEYQIDRUBRO + 
						Constantes.SIGNOIGUAL + Page.Request.QueryString["RubroClasf"] +
						Constantes.SIGNOAMPERSON +
						KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDCENTRO]+
						Constantes.SIGNOAMPERSON + 
						KEYTIPOCLIENTEPMGP + Constantes.SIGNOIGUAL + ""+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYID + Utilitario.Constantes.SIGNOIGUAL + "1";

					IndiceArray=Utilitario.Constantes.ValorConstanteCero;
					NombreArray=ARRAYORDEN + IndiceGrupo.ToString();

					CadenaJavaScript=CadenaJavaScript + JPALABRAVAR + NombreArray +JSCRIPTDOS ;
					CadenaAsignarArray=CadenaAsignarArray + JSCRIPTTRES + IndiceGrupo.ToString() + 
						Utilitario.Constantes.SIGNOCIERRACORCHETES + Utilitario.Constantes.SIGNOIGUAL + 
						NombreArray + Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SIGNOPUNTOYCOMA + 
						Utilitario.Constantes.ESPACIO;
					CadenaAsignarArray=CadenaAsignarArray + JSCRIPCUATRO + IndiceGrupo.ToString() +"]=false; ";
					
					string Cadena=JSCRIPTCINCO + IndiceGrupo.ToString() +JSCRIPTSEIS;
					img.ImageUrl=URLIMAGENES;
					img.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Cadena +JSCRIPTUNO );

					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
					
					IndiceGrupo=IndiceGrupo+ Utilitario.Constantes.ValorConstanteUno;
				}
				else
				{
					hlk.Attributes.Add(Constantes.EVENTOCLICK,Constantes.POPUPDEESPERA);
					hlk.Text =/*ESPACIOSTML +*/ dr[Utilitario.Enumerados.FINColumnaProyectosPorLiquidar.TipoCliente.ToString()].ToString();
					hlk.NavigateUrl = URLDETALLE + KEYLN + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.FINColumnaProyectosPorProvisionarLiquidar.LN.ToString()] + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYTIPOCLIENTE + Constantes.SIGNOIGUAL + 
						dr[Enumerados.FINColumnaProyectosPorLiquidar.TipoCliente.ToString()].ToString().Trim().Substring(0,1) + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDFECHA + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDFECHA] + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQFLAGDIRECTORIO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQFLAGDIRECTORIO] + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDLIQUIDADO + Constantes.SIGNOIGUAL + Constantes.IDDEFAULT.ToString() + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDPERIODO + Constantes.SIGNOIGUAL + FechaPeriodo.Year.ToString() + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDPERIODOFILTRO + Constantes.SIGNOIGUAL +ddlbPeriodo.SelectedValue + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDMES + Constantes.SIGNOIGUAL + FechaPeriodo.Month.ToString() + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYCONCEPTO + Constantes.SIGNOIGUAL + 
						dr[Enumerados.FINColumnaProyectosPorLiquidar.DescripcionLN.ToString()] + 
						Constantes.ESPACIO + Constantes.SIGNOMENOS + Constantes.ESPACIO +
						dr[Enumerados.FINColumnaProyectosPorLiquidar.TipoCliente.ToString()] +
						Constantes.SIGNOAMPERSON + KEYQIDFORMATO + 
						Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDFORMATO] +
						Constantes.SIGNOAMPERSON + KEYQIDRUBRO + 
						Constantes.SIGNOIGUAL + Page.Request.QueryString["RubroClasf"] +
						Constantes.SIGNOAMPERSON +
						KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDCENTRO]	+ 
						Constantes.SIGNOAMPERSON + 
						KEYTIPOCLIENTEPMGP + Constantes.SIGNOIGUAL + ""+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYID + Utilitario.Constantes.SIGNOIGUAL + "1";


					e.Item.Attributes.Add(PALABRASTYLE,PALABRADISPLAY);

					img.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;

					CadenaJavaScript=CadenaJavaScript + NombreArray + Utilitario.Constantes.SIGNOABRECORCHETES + 
						IndiceArray + Utilitario.Constantes.SIGNOCIERRACORCHETES  + 
						Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIGNOCOMILLASIMPLE  + 
						this.grid.ID + Utilitario.Constantes.SIGNOUNDERLINE  + IdTablaRow + 
						Utilitario.Constantes.SIGNOCOMILLASIMPLE + Utilitario.Constantes.SIGNOPUNTOYCOMA  + 
						Utilitario.Constantes.ESPACIO;
					IndiceArray=IndiceArray + Utilitario.Constantes.ValorConstanteUno;
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				}
			}
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[1].Text = Cantidad.ToString();
				e.Item.Cells[2].Text = Facturado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text = CostoProduccion.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[4].Text = Resultado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void HacerNoVisiblesFilasDeGrilla()
		{
			string CadenaJava=CadenaJavaScript + CadenaAsignarArray;
			this.ltlMensaje.Text=CadenaJava;
		}

		private void InicializarVariables()
		{
			CadenaJavaScript=Utilitario.Constantes.VACIO;
			NombreArray=Utilitario.Constantes.VACIO;
			IndiceArray=Utilitario.Constantes.ValorConstanteCero;
			CadenaAsignarArray=Utilitario.Constantes.VACIO;
			IndiceGrupo=Utilitario.Constantes.ValorConstanteCero;
		}

		#endregion

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();		
		}

		private void ibtnAbrir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.GenerarExcelCompleto(this,grid);
		}
		private void LlenarGrillaResumen()
		{
			DataTable dtGeneral = this.ObtenerDatosResumen();
			DataTable dtImpresion = new DataTable();
			
			if(dtGeneral!=null)
			{
				dtImpresion = dtGeneral.Copy();
				DataView dwGeneral = dtGeneral.DefaultView;
				gridResumen.DataSource = dwGeneral;
				//lblResultado.Visible = Constantes.VALORUNCHECKEDBOOL;
				//this.ibtnImprimir.Visible = Utilitario.Constantes.VALORUNCHECKEDBOOL;
				//this.ibtnImprimir.Visible = Constantes.VALORCHECKEDBOOL;
			}
			else
			{
				gridResumen.DataSource = null;
				//lblResultado.Visible = Utilitario.Constantes.VALORCHECKEDBOOL;
				//this.IdCabezaTabla.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				//lblResultado.Text = GRILLAVACIA;
				//this.ibtnImprimir.Visible = Utilitario.Constantes.VALORUNCHECKEDBOOL;

			}
			try
			{
				//CImpresion oCImpresion = new CImpresion();
				//oCImpresion.GuardarDataImprimirExportar(dtImpresion,"Consultar Proyectos Por Liquidar",Utilitario.Constantes.VACIO);
				gridResumen.DataBind();
			}
			catch	
			{
				gridResumen.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				gridResumen.DataBind();
			}	

		}

		private void ddlbPeriodo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.LlenarGrilla();
				HacerNoVisiblesFilasDeGrilla();
			}
			catch
			{

			}
		}

		private void gridResumen_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{			
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				string parametros= KEYLN + Utilitario.Constantes.SIGNOIGUAL + 
					"" + Utilitario.Constantes.SIGNOAMPERSON +
					KEYTIPOCLIENTEPMGP + Constantes.SIGNOIGUAL + 
					dr[Enumerados.FINColumnaProyectosPorLiquidar.TipoCliente.ToString()].ToString().Trim() + 
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDFECHA + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDFECHA] + 
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYQFLAGDIRECTORIO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQFLAGDIRECTORIO] + 
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDLIQUIDADO + Constantes.SIGNOIGUAL + Constantes.IDDEFAULT.ToString() + 
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDPERIODO + Constantes.SIGNOIGUAL + FechaPeriodo.Year.ToString() + 
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDPERIODOFILTRO + Constantes.SIGNOIGUAL +ddlbPeriodo.SelectedValue + 
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDMES + Constantes.SIGNOIGUAL + FechaPeriodo.Month.ToString() + 
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYCONCEPTO + Constantes.SIGNOIGUAL + 
					"" + 
					Constantes.ESPACIO + Constantes.SIGNOMENOS + Constantes.ESPACIO +
					dr[Enumerados.FINColumnaProyectosPorLiquidar.TipoCliente.ToString()] +
					Constantes.SIGNOAMPERSON + KEYQIDFORMATO + 
					Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDFORMATO] +
					Constantes.SIGNOAMPERSON + KEYQIDRUBRO + 
					Constantes.SIGNOIGUAL + Page.Request.QueryString["RubroClasf"] +
					Constantes.SIGNOAMPERSON +
					KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDCENTRO]+
					Utilitario.Constantes.SIGNOAMPERSON 	+
					KEYID + Utilitario.Constantes.SIGNOIGUAL + "1";

				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE+ Utilitario.Constantes.POPUPDEESPERA);
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLDETALLE,parametros));
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ForeColor=System.Drawing.Color.Blue;
				e.Item.Cells[0].Style.Add(Utilitario.Constantes.CURSOR,"hand");
				
			}
		
		}
	}
}
