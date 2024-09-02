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
using System.Reflection;
namespace SIMA.SimaNetWeb.GestionFinanciera.CartasFianza
{
	/// <summary>
	/// Summary description for ConsultarCartaFianza.
	/// </summary>
	public class ConsultarCartaFianza : System.Web.UI.Page,IPaginaBase
	{
	
		#region Constantes
		const string ALERTA = "../../imagenes/alert.gif";
		const string CONTROLIMGBUTTON = "imgCaducidad";
		const string OBJPARAMETROCONTABLE="ParametroCartaFza";
		//const int IDTABLAESTADOCARTAFIANZA=5;
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkNroFianza";		
		const string COLORDENAMIENTO = "NroCartaFianza";
		const string KEYIDDETCF = "idDetCF";
		const string KEYIDCARTAFZA = "idCartaFza";
		const string KEYIDPERIODO = "Periodo";
		const string KEYIDESTADO = "IdEstado";

		const string KEYESTADOFIANZAP = "EstadoFianzaP";

		//Paginas
		const string URLDETALLE="DetalledeCartaFianza.aspx?";
		const string URLPRINCIPAL="../../Default.aspx";
		const string URLANTERIOR = "/SimaNetWeb/DirectorioEjecutivo/EstadosFinancieros.aspx";
		const string RUTAIMGFILTRO = "/SimanetWeb/imagenes/Filtro/";

		const string LBLNRORENOVACION = "lblNroRenov";
		const string LBLFECHAINICIO = "lblFechaIni";
		const string LBLFECHARENOVACION = "lblFechaRenov";
		const string LBLFECHAVENCIMIENTO = "lblFechaVence";

		const string VARIABLEFINANCIERACARTAFIANZA = "finCF";
		const string VARIABLEESTADOCF = "finEstCF";

		const string KEYPAGINA = "PAGINA";
		const string KEYHISTORIAL = "HISTORIAL";

		//Filtro
		const string NROCARTAFIANZA ="NroCartaFianza";
		const string CENTROOPERATIVO ="Centro";
		const string BANCO ="RazonSocial";
		const string BENEFICIARIO = "Beneficiario";
		const string MONEDA ="Moneda";
		const string MONTOCARTAFIANZA = "MontoCartaFza";
		const string NROCONTRATO = "NroContrato";

		//Mensajes
		const string MENSAJECONFIRMACIONIMPORTACION ="Importación termino con exito..";
		const string MENSAJEDIASVENCIMIENTO ="Nro dias Restantes para su vencimiento";

		//Filtro VALORES
		const string NOMBREIMGSEPARADOR1 = "ImgSeparador1";
		const string NOMBREIMGSEPARADOR = "imgSeparador.gif";
		const string NOMBREIMGOPERADORLOGICO ="ImgOperadorLogico";
		const string NOMBREIMGBOTONOERADORLOGICO = "imgbtnOr.gif";
		const string NOMBREIMGSEPARADOR2 = "ImgSeparador2";
		const string NOMBRECONTROLSELECCIONCRITERIO ="ddlbOperadorCriterio";
		const string NOMBREIMGSEPARADOR3 ="ImgSeparador3";

		//Otros
		const string CTRLCONCEPTO ="txtConcepto";

		//Nuevos
		const string COLORDEN = "orden";
		const string COLCODPADRE ="codPadre";
		const string COLDESPADRE ="desPadre";

		//Datatable and Datagrid
		const string CAMPOBS ="Observacion";

		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.HyperLink hlkId;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtConcepto;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlbModalidadCartaFianza;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected projDataGridWeb.DataGridWeb gridResumen;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.PlaceHolder phFiltro;
		protected System.Web.UI.WebControls.ImageButton imgbtnImportar;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlbEstadoCartaFianza;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
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
		private void CrearControlesparaElFiltro()
		{
			const string PathImgFiltro=RUTAIMGFILTRO; //"/SimanetWeb/imagenes/Filtro/";
			//Crear Tabla
			HtmlTable tblBase = new HtmlTable();
			tblBase.Border=0;
			HtmlTableRow Fila = new HtmlTableRow();
			HtmlTableCell Celda;
			//Crea un Separador
			HtmlImage img;
			img = new  HtmlImage();
			img.ID = NOMBREIMGSEPARADOR1;
			img.Src=PathImgFiltro + NOMBREIMGSEPARADOR;

			Celda = new HtmlTableCell();
			Celda.Controls.Add(img);
			Fila.Controls.Add(Celda);
			//phFiltro.Controls.Add(img);
			//Crea el Boton de operacion logica
			img = new  HtmlImage();
			img.ID = NOMBREIMGOPERADORLOGICO;
			img.Src=PathImgFiltro + NOMBREIMGBOTONOERADORLOGICO;
			Celda = new HtmlTableCell();
			Celda.Controls.Add(img);
			Fila.Controls.Add(Celda);

			//Crea un Separador
			img = new  HtmlImage();
			img.ID = NOMBREIMGSEPARADOR2;
			img.Src=PathImgFiltro + NOMBREIMGSEPARADOR;
			Celda = new HtmlTableCell();
			Celda.Controls.Add(img);
			Fila.Controls.Add(Celda);

			//Crea el Combo de Criterios
			HtmlSelect ddlbGeneral;
			ddlbGeneral = new HtmlSelect();
			ddlbGeneral.ID=NOMBRECONTROLSELECCIONCRITERIO;
			ddlbGeneral.Items.Add(new ListItem("Que Contenga","Todo"));
			ddlbGeneral.Items.Add(new ListItem("Que Inicie con","Ini"));
			ddlbGeneral.Items.Add(new ListItem("Que Finalice con","Fin"));
			ddlbGeneral.Items.Add(new ListItem("Que Sea igual a","Igual"));
			ddlbGeneral.Items.Add(new ListItem("Que No Sea igual a","NoIgual"));
			ddlbGeneral.Items.Add(new ListItem("Que Sea Mayor que","MayorQue"));
			ddlbGeneral.Items.Add(new ListItem("Que Sea Menor que","MenorQue"));
			//phFiltro.Controls.Add(ddlbGeneral);
			Celda = new HtmlTableCell();
			Celda.Controls.Add(ddlbGeneral);
			Fila.Controls.Add(Celda);

			//Crea un Separador
			img = new  HtmlImage();
			img.ID = NOMBREIMGSEPARADOR3;
			img.Src=PathImgFiltro + NOMBREIMGSEPARADOR;
			//phFiltro.Controls.Add(img);
			Celda = new HtmlTableCell();
			Celda.Controls.Add(img);
			Fila.Controls.Add(Celda);

			//Crear el Cueadro de texto en el que se Ingresaran los valores Criterios de busqueda
			HtmlInputText txtBuscar= new HtmlInputText("Text");
			txtBuscar.Attributes.Add("class","itemdetalle");
			phFiltro.Controls.Add(txtBuscar);
			Celda = new HtmlTableCell();
			Celda.Controls.Add(txtBuscar);
			Fila.Controls.Add(Celda);

			//Crea el Combo Generico Para los Datos que se mostrara como opciones respuesta
			ddlbGeneral = new HtmlSelect();
			ddlbGeneral.ID="ddlbOpcionesRespuesta";
			ddlbGeneral.Style.Add("display","none");
			ddlbGeneral.Style.Add("width","150");
			Celda.Controls.Add(ddlbGeneral);
			Fila.Controls.Add(Celda);
			tblBase.Controls.Add(Fila);
			phFiltro.Controls.Add(tblBase);

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
			this.ddlbModalidadCartaFianza.SelectedIndexChanged += new System.EventHandler(this.ddlbModalidadCartaFianza_SelectedIndexChanged);
			this.ddlbEstadoCartaFianza.SelectedIndexChanged += new System.EventHandler(this.ddlbEstadoCartaFianza_SelectedIndexChanged);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.imgbtnImportar.Click += new System.Web.UI.ImageClickEventHandler(this.imgbtnImportar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarCartaFianza.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCartaFianza.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return ((CCartaFianza)new CCartaFianza()).ConsultarCartaFianzaEstado(Convert.ToInt32(this.ddlbModalidadCartaFianza.SelectedValue.ToString()),CNetAccessControl.GetIdUser(), Convert.ToInt32(this.ddlbEstadoCartaFianza.SelectedValue.ToString()));

		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			try
			{
				CCartaFianza oCCartaFianza = new CCartaFianza();
				DataTable dtCartaFianza = this.ObtenerDatos();

				if(dtCartaFianza!=null)
				{
					DataView dwCartaFianza = dtCartaFianza.DefaultView;
					dwCartaFianza.Sort = columnaOrdenar ;
					dwCartaFianza.RowFilter= Utilitario.Helper.ObtenerFiltro();
					grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwCartaFianza.Count.ToString();
					grid.DataSource = dwCartaFianza;
					grid.CurrentPageIndex =indicePagina;

					CImpresion oCImpresion = new CImpresion();
					oCImpresion.GuardarDataImprimirExportar(dtCartaFianza,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
					lblResultado.Visible = false;

				}
				else
				{
					grid.DataSource = dtCartaFianza;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}					
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
			
			// TODO:  Add ConsultarCartaFianza.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			//this.CargaEstadodeCartaFianza();
			this.CargarModalidadCartaFianza();
			this.LlenarEstadoCartaFianza();						
			Helper.SeleccionarItemCombos(this);
			if (Session[VARIABLEFINANCIERACARTAFIANZA] !=null)
			{
				this.ddlbModalidadCartaFianza.SelectedIndex = Convert.ToInt32(Session[VARIABLEFINANCIERACARTAFIANZA]);
			}
			
		}

		public void LlenarEstadoCartaFianza()
		{		
			ListItem item;
			CCartaFianza oCCartaFianza = new CCartaFianza();
			ddlbEstadoCartaFianza.DataSource = oCCartaFianza.ListarOpcionesCartaFianza();
			ddlbEstadoCartaFianza.DataValueField = COLCODPADRE;
			ddlbEstadoCartaFianza.DataTextField = COLDESPADRE;
			ddlbEstadoCartaFianza.DataBind();
			if(Session[VARIABLEESTADOCF] != null)
			{
				ddlbEstadoCartaFianza.SelectedIndex = Convert.ToInt32(Session[VARIABLEESTADOCF]);
			}
			else
			{
				item=ddlbEstadoCartaFianza.Items.FindByValue("17");
				if(item!=null){item.Selected = true;}
			}
		}
		private void CargaEstadodeCartaFianza()
		{
			/*CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.FinancieraEstadoCartaFianza));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();*/
		}
		private void CargarModalidadCartaFianza()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbModalidadCartaFianza.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.FinancieraModalidaddeFianza));
			ddlbModalidadCartaFianza.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbModalidadCartaFianza.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbModalidadCartaFianza.DataBind();
		}
		public void LlenarDatos()
		{
			// TODO:  Add ConsultarCartaFianza.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ddlbModalidadCartaFianza.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnChange.ToString(),Utilitario.Constantes.POPUPDEESPERA);
			//this.imgbtnImportar.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseDown.ToString(),Utilitario.Constantes.POPUPDEESPERA);
			this.imgbtnImportar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCartaFianza.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarCartaFianza.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCartaFianza.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}						

			// TODO:  Add ConsultarCartaFianza.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarCartaFianza.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void btnMostrar_Click(object sender, System.EventArgs e)
		{
			
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[2].ToolTip=Utilitario.Constantes.CENTROOPERATIVO;
				e.Item.Cells[6].ToolTip=MENSAJEDIASVENCIMIENTO;
				e.Item.Cells[7].ToolTip=Utilitario.Constantes.MONEDA;
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				string parametros = KEYIDCARTAFZA.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnaCartaFianza.idCartaFianza.ToString()]) 
																				  + Utilitario.Constantes.SIGNOAMPERSON  
																				  +	KEYIDPERIODO  +  Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnaCartaFianza.Periodo.ToString()])
																				  + Utilitario.Constantes.SIGNOAMPERSON 
																				  + KEYIDDETCF + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnaCartaFianza.idDetCF.ToString()])
																				  + Utilitario.Constantes.SIGNOAMPERSON
																				  + KEYESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlbEstadoCartaFianza.SelectedValue.ToString())
																				  + Utilitario.Constantes.SIGNOAMPERSON
																				  + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString();

				
				e.Item.Attributes.Add(KEYPAGINA,URLDETALLE + parametros);
				e.Item.Attributes.Add(KEYHISTORIAL,this.hGridPagina.ID.ToString()
					+ Utilitario.Constantes.SIGNOPUNTOYCOMA 
					+ this.hGridPaginaSort.ID.ToString());

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
						Helper.HistorialIrAdelantePersonalizado(this.hGridPagina.ID.ToString(),this.hGridPaginaSort.ID.ToString()),
						Helper.MostrarVentana(URLDETALLE,parametros));


				e.Item.Cells[8].Text = Convert.ToDouble(e.Item.Cells[8].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				((Label)e.Item.Cells[5].FindControl(LBLFECHAINICIO)).Text = dr[Enumerados.FinColumnaCartaFianzaporBanco.FechaInicio.ToString()].ToString();
				((Label)e.Item.Cells[5].FindControl(LBLFECHARENOVACION)).Text = dr[Enumerados.FinColumnaCartaFianzaporBanco.fechaRenovacion.ToString()].ToString();
				((Label)e.Item.Cells[5].FindControl(LBLFECHAVENCIMIENTO)).Text = dr[Enumerados.FinColumnaCartaFianzaporBanco.fechavencimiento.ToString()].ToString();

				if (Convert.ToInt32(e.Item.Cells[6].Text) <= 5)
				{
					e.Item.Cells[6].ForeColor = Color.Red;
				}
	
				System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[9].FindControl(CONTROLIMGBUTTON);	
					
				if (Convert.ToInt32(dr["idproyecto"])== -1)
				{
					ibtn1.ImageUrl = ALERTA;
				}
				else
				{
					ibtn1.Visible = false;
				}

				#region Helpers
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto(CTRLCONCEPTO,dr[CAMPOBS].ToString()));
					Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");
					Helper.FiltroporSeleccionConfiguraColumna((Label)e.Item.Cells[5].FindControl(LBLFECHAINICIO),Enumerados.FinColumnaCartaFianzaporBanco.FechaInicio.ToString());
					Helper.FiltroporSeleccionConfiguraColumna((Label)e.Item.Cells[5].FindControl(LBLFECHARENOVACION),Enumerados.FinColumnaCartaFianzaporBanco.fechaRenovacion.ToString());
					Helper.FiltroporSeleccionConfiguraColumna((Label)e.Item.Cells[5].FindControl(LBLFECHAVENCIMIENTO),Enumerados.FinColumnaCartaFianzaporBanco.fechavencimiento.ToString());
					
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
			hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos(),NROCARTAFIANZA
																				 ,Utilitario.Constantes.SIGNOASTERISCO + CENTROOPERATIVO + ";Centro Operativo"
																				 ,Utilitario.Constantes.SIGNOASTERISCO + BANCO + ";Banco"
																				 ,BENEFICIARIO
																				 ,Utilitario.Constantes.SIGNOASTERISCO + MONEDA + ";Moneda"
																				 ,MONTOCARTAFIANZA
																				 ,NROCONTRATO);
		}

		private void RedireccionarPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		
		}

		private void txtBuscar_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ddlbModalidadCartaFianza_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[VARIABLEFINANCIERACARTAFIANZA] = ddlbModalidadCartaFianza.SelectedIndex;
			Session[VARIABLEESTADOCF] = ddlbEstadoCartaFianza.SelectedIndex;
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void imgbtnImportar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				int retorno = 0;
				CCartaFianza oCCartaFianza = new CCartaFianza();
				retorno = oCCartaFianza.ImportarCartaFianzaYRenovaciones();
				if(retorno > 0)
				{
					ASPNetUtilitario.MessageBox.Show(MENSAJECONFIRMACIONIMPORTACION);
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
				ASPNetUtilitario.MessageBox.Show(oException.Message.ToString());
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
			/*
			try
			{
				int retorno = 0;

				int i = ((CCartaFianza) new CCartaFianza()).ImportarCartaFianza();
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
			*/
		}

		private void ddlbEstadoCartaFianza_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[VARIABLEFINANCIERACARTAFIANZA] = ddlbModalidadCartaFianza.SelectedIndex;
			Session[VARIABLEESTADOCF] = ddlbEstadoCartaFianza.SelectedIndex;
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			grid.AllowPaging = false;
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
			grid.AllowPaging = true;
			ltlMensaje.Text = "Previo()";
			/*System.Threading.Thread.Sleep(1000);
			grid.AllowPaging = true;
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
			**/
		}
	}
}
