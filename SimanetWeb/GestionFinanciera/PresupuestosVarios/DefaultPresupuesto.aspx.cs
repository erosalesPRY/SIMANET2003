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
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Drawing.Printing;


namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios
{
	/// <summary>
	/// Summary description for DefaultPresupuesto.
	/// </summary>
	public class DefaultPresupuesto : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string KEYQIDTIPOPRESUPUESTO = "TipoPreupuesto";

		const string KEYQIDFECHA = "efFecha";
		const string KEYQIDNOMBREMES = "NombreMes";
		const string KEYQIDNIVELRESUMEN = "NivelResumen";
		const string KEYQIDPPERSONAL = "idpPersonal";
		const string CUENTASCC = "ctaGrpCC";
		const string NOMBREPRESUPUESTO = "NomPresup";

		const string KEYIDCENTRO ="IdCentro";
		const string NOMBRECENTRO ="NombreCentro";

		//string ColBlanco = "<TD><IMG src='../../imagenes/tree/Blanco.gif'></TD>";
		string tblNodoRaiz ="<TABLE class='ItemGrillaSinColor' cellSpacing='0' cellPadding='0' width='100%' border='0'><TR>[COLBLANCO]<TD><IMG src='../../imagenes/tree/plus.gif' id=[IMGPM] onclick=" + Utilitario.Constantes.SIGNOCOMILLADOBLE + "OpenClose([PARAMETROS]);" + Utilitario.Constantes.SIGNOCOMILLADOBLE + "></TD><TD style ='display:none'><IMG id=[IMGFOLDER] src='../../imagenes/tree/Close.gif'></TD><TD id=[IDCOL] width='100%' style='[ESTILO]'>[Texto]</TD></TR></TABLE>";
		//string tblNodoHijo ="<TABLE class='ItemGrillaSinColor' cellSpacing='0' cellPadding='0' width='100%' border='0'><TR>[COLBLANCO]<TD><IMG src='../../imagenes/tree/Blanco.gif'></TD><TD><IMG src='../../imagenes/tree/Blanco.gif'></TD><TD><IMG src='../../imagenes/tree/xpMyDoc.gif'></TD><TD width='100%' [EVENTO] style='COLOR: #0000ff; TEXT-DECORATION: underline'> [Texto]</TD></TR></TABLE>";
		//string strStyle="FONT-WEIGHT: bold; FONT-SIZE: 7pt; FONT-STYLE: normal; FONT-FAMILY: Arial";



			const string GRILLAVACIA ="No existe ningún Registro.";  
			const string URLPAGINAPRESUPUESTO = "ConsultarPresupuestoVarios.aspx?";

			int Fila=1;
			DateTime FechaPeriodo;

		//Campos en Columnas
		const string CAMPOP1 = "lblPresupuestoP";
		const string CAMPOP2 = "lblRealP";
		const string CAMPOP3 = "lblSaldoP";

		const string CAMPOI1 = "lblPresupuestoI";
		const string CAMPOI2 = "lblRealI";
		const string CAMPOI3 = "lblSaldoI";

		//Otros
		const string TITULOTIPOSPTO ="TIPOS DE PRESUPUESTO";
		const string VALORLTDA = "LTDA";
		const string VALORLtda = "Ltda";
		const string SYSTEMDOUBLE ="System.Double";
		const string EXPRESSIONPERU ="PeruTotalPPtoCta - PeruTotalEjecutado";
		const string EXPRESSIONIQUITOS ="IquitosTotalPPtoCta - IquitosTotalEjecutado";
		const string EXPRESSIONORDENAMIENTO ="Orden ASC";
		const string TITULOPTO ="TOTAL PRESUPUESTO";
		const string NOMBRECLASEFOOTER ="footerGrilla";
		const string IMGPLUS ="/imagenes/tree/plus.gif";
		const string ESTILOFONT ="font";
		const string ESTILOBOLD ="bold";
		const string SCRIPTITEMGRILLASINCOlOR ="itemgrillasinColor";

		//DataGrid and DataTable
		const string COLUMNAPERUSALDO ="PeruSaldo";
		const string COLUMNAIQUITOSALDO ="IquitosSaldo";
		const string COLUMNAIDTIPOPTO ="idTipoPresupuesto";
		const string COLUMNAORDEN ="Orden";
		const string COLUMNANOMBRE ="NOMBRE";
		const string COLUMNAPERUTOTALEJECUTADO ="PeruTotalEjecutado";
		const string COLUMNAPERUTOTALPPTOCTA ="PeruTotalPPtoCta";
		const string COLUMNAIQUITOSTOTALEJECUTADO ="IquitosTotalEjecutado";
		const string COLUMNAIQUITOSTOTALPPTOCTA ="IquitosTotalPPtoCta";
		const string COLUMNAPERIODO ="Periodo";
		const string COLUMNAULTIMONIVEL ="UltimoNivel";
		#endregion

		#region Constroles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label lblResultado;
			
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		
			protected System.Web.UI.WebControls.Label Label5;
			protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
			protected System.Web.UI.WebControls.Label Label4;
			protected System.Web.UI.WebControls.DropDownList dddblMes;
			protected projDataGridWeb.DataGridWeb grid;

			protected System.Web.UI.WebControls.Label Label2;
		#endregion

		private ASPNetDatagridDecorator m_add = new ASPNetDatagridDecorator();
		
		private ASPNetDatagridDecorator m_add2 = new ASPNetDatagridDecorator();
		
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
					this.ColspanRowspanHeader1();
					//this.ColspanRowspanHeader2();
					this.LlenarGrillaOrdenamientoPaginacion(String.Empty,Constantes.INDICEPAGINADEFAULT);	
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
					string msgb =oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
			// Put user code to initialize the page here
		}
		private void ColspanRowspanHeader1()
		{
			TableCell cell = null;
			m_add.DatagridToDecorate = grid;
			ArrayList header = new ArrayList();


			cell = new TableCell();
			cell.Text = TITULOTIPOSPTO;
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			cell = new TableCell();
			cell.Text =  Utilitario.Constantes.KEYIDNOMBRECENTROPERU.ToString().ToUpper();
			cell.ColumnSpan = 3;
			cell.HorizontalAlign = HorizontalAlign.Center;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = Utilitario.Constantes.KEYIDNOMBRECENTROIQUITOS.ToString().ToUpper().Replace(VALORLTDA,VALORLtda);
			cell.ColumnSpan = 3;
			cell.HorizontalAlign = HorizontalAlign.Center;
			header.Add(cell);

			m_add.AddMergeHeader(header);
			
		}
		private void ColspanRowspanHeader2()
		{
//			TableCell cell = null;
//			m_add2.DatagridToDecorate = gridEgresos;
//			ArrayList header = new ArrayList();
//
//
//			cell = new TableCell();
//			cell.Text = "TIPOS DE PRESUPUESTO";
//			cell.RowSpan = 2;
//			cell.VerticalAlign = VerticalAlign.Middle;
//			header.Add(cell);
//
//			cell = new TableCell();
//			cell.Text =  Utilitario.Constantes.KEYIDNOMBRECENTROPERU.ToString().ToUpper();
//			cell.ColumnSpan = 3;
//			cell.HorizontalAlign = HorizontalAlign.Center;
//			header.Add(cell);
//
//			cell = new TableCell();
//			cell.Text = Utilitario.Constantes.KEYIDNOMBRECENTROIQUITOS.ToString().ToUpper().Replace("LTDA","Ltda");
//			cell.ColumnSpan = 3;
//			cell.HorizontalAlign = HorizontalAlign.Center;
//			header.Add(cell);
//
//			m_add2.AddMergeHeader(header);
			
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
			this.ddlbPeriodo.SelectedIndexChanged += new System.EventHandler(this.ddlbPeriodo_SelectedIndexChanged);
			this.dddblMes.SelectedIndexChanged += new System.EventHandler(this.dddblMes_SelectedIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DefaultPresupuesto.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DefaultPresupuesto.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			CPresupuesto oCPresupuesto = new  CPresupuesto();
			DataTable tblResultado =oCPresupuesto.ConsultarTiposdePresupuesto(
																				Convert.ToInt32(ddlbPeriodo.SelectedValue)
																				,Convert.ToInt32(dddblMes.SelectedValue));
			if (tblResultado != null)
			{
				DataColumn dc = new  DataColumn(COLUMNAPERUSALDO, Type.GetType(SYSTEMDOUBLE));
				dc.Expression = EXPRESSIONPERU;
				tblResultado.Columns.Add(dc);
				DataColumn dcI = new  DataColumn(COLUMNAIQUITOSALDO, Type.GetType(SYSTEMDOUBLE));
				dcI.Expression = EXPRESSIONIQUITOS;
				tblResultado.Columns.Add(dcI);
			}
			return tblResultado;
		}

		private DataView TotalPresupuesto(DataTable dt)
		{
			DataRow dr = dt.NewRow();
			dr[COLUMNAIDTIPOPTO] = 80;
			dr[COLUMNAORDEN] = 3;
			dr[COLUMNANOMBRE]=TITULOPTO;
			dr[COLUMNAPERUTOTALEJECUTADO]=(Helper.TotalizarDataView(dt.DefaultView,COLUMNAPERUTOTALEJECUTADO,"Resultados","0"))[0];
			dr[COLUMNAPERUTOTALPPTOCTA]=(Helper.TotalizarDataView(dt.DefaultView,COLUMNAPERUTOTALPPTOCTA,"Resultados","0"))[0];
			dr[COLUMNAIQUITOSTOTALEJECUTADO]=(Helper.TotalizarDataView(dt.DefaultView,COLUMNAIQUITOSTOTALEJECUTADO,"Resultados","0"))[0];
			dr[COLUMNAIQUITOSTOTALPPTOCTA]=(Helper.TotalizarDataView(dt.DefaultView,COLUMNAIQUITOSTOTALPPTOCTA,"Resultados","0"))[0];

			dt.Rows.Add(dr);
			dt.DefaultView.Sort=EXPRESSIONORDENAMIENTO;
			return dt.DefaultView;
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.TotalPresupuesto(this.ObtenerDatos()).Table;
			if(dtGeneral!=null)
			{
				grid.DataSource = dtGeneral;
				//gridEgresos.DataSource = dtGeneral;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtGeneral;
				//gridEgresos.DataSource = dtGeneral;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
				//gridEgresos.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
				//gridEgresos.DataBind();
			}
			// TODO:  Add DefaultPresupuesto.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.LlenarPeriodoContable();
		}
		private void LlenarPeriodoContable()
		{
			CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			ddlbPeriodo.DataSource = oCPeriodoContable.ListarPeriodo();
			ddlbPeriodo.DataValueField=COLUMNAPERIODO;
			ddlbPeriodo.DataTextField=COLUMNAPERIODO;
			ddlbPeriodo.DataBind();
			if((Page.Request.Params[Utilitario.Constantes.KeyQPaginaValorInicial] != null)  && Page.Request.Params[Utilitario.Constantes.KeyQPaginaValorInicial].ToString() == Utilitario.Constantes.KeyQPaginaValor)
			{
				this.SeleccionarCombos(DateTime.Now.Date);
			}	
			else
			{
				if (Page.Request.Params[KEYQIDFECHA]!=null)
				{
					this.SeleccionarCombos(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]));
					this.ddlbPeriodo.Enabled = false;
					this.dddblMes.Enabled = false;
				}
				else
				{
					Helper.SeleccionarItemCombos(this);
				}
			}
		}
		private void SeleccionarCombos(DateTime Fecha)
		{
			ListItem item;
			item = ddlbPeriodo.Items.FindByText(Fecha.Year.ToString());
			if (item !=null){item.Selected = true;}

			item = dddblMes.Items.FindByValue(Fecha.Month.ToString());
			if (item !=null){item.Selected = true;}
		}

		public void LlenarDatos()
		{
			// TODO:  Add DefaultPresupuesto.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			//ddlbPeriodo.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnChange.ToString(),Utilitario.Constantes.POPUPDEESPERA);
			dddblMes.Attributes.Add(Utilitario.Constantes.EVENTOONCHANGE,Utilitario.Constantes.POPUPDEESPERA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DefaultPresupuesto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DefaultPresupuesto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DefaultPresupuesto.Exportar implementation
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
			// TODO:  Add DefaultPresupuesto.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add DefaultPresupuesto.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add DefaultPresupuesto.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DefaultPresupuesto.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add DefaultPresupuesto.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DefaultPresupuesto.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add DefaultPresupuesto.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DefaultPresupuesto.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DefaultPresupuesto.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DefaultPresupuesto.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DefaultPresupuesto.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void dddblMes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.ColspanRowspanHeader1();
			this.ColspanRowspanHeader2();
			this.LlenarGrillaOrdenamientoPaginacion(String.Empty,Constantes.INDICEPAGINADEFAULT);
		}

		private void ddlbPeriodo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			this.ColspanRowspanHeader1();
//			this.ColspanRowspanHeader2();
//			this.LlenarGrillaOrdenamientoPaginacion("",Constantes.INDICEPAGINADEFAULT);
		}
		private void GeneraFecha()
		{FechaPeriodo = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(this.ddlbPeriodo.SelectedValue),Convert.ToInt32(this.dddblMes.SelectedValue)) + "/" + this.dddblMes.SelectedValue.PadLeft(2,'0') + "/" + this.ddlbPeriodo.SelectedValue.ToString());}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				this.GeneraFecha();

				e.Item.Attributes.Add("CONSULTADO",Utilitario.Constantes.ValorConstanteCero.ToString());
				e.Item.Attributes.Add("IDFILA",Fila.ToString());
				e.Item.Attributes.Add("IDNIVEL",dr[COLUMNAIDTIPOPTO].ToString());
				e.Item.Attributes.Add("IDTIPOPPTO",dr[COLUMNAIDTIPOPTO].ToString());
				e.Item.Attributes.Add("FECHA",FechaPeriodo.ToShortDateString());
				e.Item.Attributes.Add("NIVEL",Utilitario.Constantes.ValorConstanteCero.ToString());
				e.Item.Attributes.Add("ULTIMONIVEL",dr[COLUMNAULTIMONIVEL].ToString());
				e.Item.Attributes.Add("CENTRO",Utilitario.Constantes.ValorConstanteCero.ToString());
				e.Item.Attributes.Add("NOMBREPRESUPUESTO",dr[COLUMNANOMBRE].ToString());
				e.Item.Attributes.Add("NOMBRECENTRO",String.Empty);
				e.Item.Attributes.Add("NOMBREANEXO",String.Empty);


				if (dr["UltimoNivel"].ToString()=="0")
				{
					e.Item.Cells[0].Controls.Add(this.CrearTablaNodoRaiz("grid",dr["Nombre"].ToString(),dr["idTipoPresupuesto"].ToString()));
				}
				
				//Formato numerico
				e.Item.Cells[1].Text=Convert.ToDouble(e.Item.Cells[1].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[2].Text=Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text=Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[4].Text=Convert.ToDouble(e.Item.Cells[4].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text=Convert.ToDouble(e.Item.Cells[5].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[6].Text=Convert.ToDouble(e.Item.Cells[6].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				if (dr["idTipoPresupuesto"].ToString()=="80"){e.Item.CssClass = NOMBRECLASEFOOTER;}
				//Solo se conseidera esta seccion si este modulo es llamada desde los estados financieros
			}
			Fila ++;
		}

		private HtmlTable CrearTablaNodoRaiz(string NombredbGrid,string Descripcion,string idNivel)
		{
			HtmlTable tbl = new HtmlTable();
			HtmlTableRow Fila = new HtmlTableRow();
			HtmlImage imagen;
			HtmlTableCell Celda;

			Celda = new HtmlTableCell();
			imagen = new HtmlImage();imagen.Src =Session[Utilitario.Constantes.SPATHAPPWEB].ToString() + IMGPLUS;
			imagen.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"CargarSubNodos('" + NombredbGrid + "',this,'" + idNivel + "')");
			Celda.Controls.Add(imagen);
			Fila.Controls.Add(Celda);

			Celda = new HtmlTableCell();
			Celda.InnerText = Descripcion;
			Celda.NoWrap=true;
			Celda.Style.Add(ESTILOFONT,ESTILOBOLD);
			
			Fila.Controls.Add(Celda);
			Fila.Attributes.Add("Class",SCRIPTITEMGRILLASINCOlOR);
			tbl.Controls.Add(Fila);
			
			return tbl;
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
