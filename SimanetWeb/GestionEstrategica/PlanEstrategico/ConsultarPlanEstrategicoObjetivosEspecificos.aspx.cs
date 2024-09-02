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
using SIMA.Controladoras.GestionEstrategica.PlanEstrategico;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using System.Diagnostics; 

namespace SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico
{
	/// <summary>
	/// Summary description for ConsultarPlanEstrategicoObjetivosEspecificos.
	/// </summary>
	public class ConsultarPlanEstrategicoObjetivosEspecificos : System.Web.UI.Page, IPaginaBase
	{
		#region Constante
		const string GRILLAVACIA="No Existen datos Plan Estrategico";
		const string CONTROLGRILLAINDICADORES ="gridIndicadores";

		const string KEYQPLANESTRATEGICONOMBRE="PLEstrNombre";	
		const string KEYQIDPLANESTRATEGICO="idPLEstr";
		const string KEYQIDOBJETIVOGENERAL="idObjGen";
		const string KEYQCODDOBJETIVOGENERAL="CodObjGen";
		const string KEYQOBJETIVOGENERALNOMBRE="ObjGenNombre";
		const string KEYQIDOBJETIVOESPECIFICO="idObjEsp";
		const string KEYQCODOBJETIVOESPECIFICO="CodObjEsp";
		const string KEYQOBJETIVOESPECIFICONOMBRE="idObjEspNombre";
		const string KEYQIDCENTROOPERATIVO="idCentro";
		const string KEYIDCENTROOPERATIVO = "IDCENTROOPERATIVO";

		const string URLDETALLE="DetallePlanEstrategicoObjetivosEspecificos.aspx";
		const string URLACCION="ConsultarPlanEstrategicoAccion.aspx";

		const string SESSIONPERIODO = "speriodo";
		const string SESSIONTIPO = "stipo";
		const string SESSIONNIVEL = "snivel";
		const string SESSIONTI = "sti";
		const string SESSIONIMPORTANCIA = "simportancia";
		const string SESSIONPRIORIDAD = "sprioridad";

		#endregion
		#region Variables
		private ListItem item = new ListItem();
		int periodo = 0;
		int idtiprcs = 0;
		int idniv = 0;
		int idimportancia = 0;
		int prioridad = 0;
		string cadenaTipoinversion = "0";
		double TotInversion;
		#endregion

		int idPlanEstrategico
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDPLANESTRATEGICO]); }
		}

		int idObjetivoGeneral
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDOBJETIVOGENERAL]); }
		}
		string CodigoObjetivoGeneral
		{
			get{return Page.Request.Params[KEYQCODDOBJETIVOGENERAL].ToString(); }
		}
		string PlanEstrategicoNombre
		{
			get{return Page.Request.Params[KEYQPLANESTRATEGICONOMBRE].ToString(); }
		}

		string ObjetivoGeneralNombre
		{
			get{return Page.Request.Params[KEYQOBJETIVOGENERALNOMBRE].ToString(); }
		}
		int CentroOperativo
		{
			get{return int.Parse(Page.Request.Params[KEYQIDCENTROOPERATIVO].ToString());}
		}
		#region Controles

		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblPlanEstrategico;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblObjetivoGeneral;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.Label Label3;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Label lblObjGral;
		protected System.Web.UI.WebControls.DropDownList ddlbPrioridad;
		protected System.Web.UI.WebControls.DropDownList ddlbImportancia;
		protected System.Web.UI.WebControls.DropDownList ddlbAno;
		protected System.Web.UI.WebControls.DropDownList ddlbNivel;
		protected System.Web.UI.WebControls.DropDownList ddlbTi;
		protected System.Web.UI.WebControls.CheckBoxList chkListTipoInversion;
		protected System.Web.UI.WebControls.CheckBox chkTodos;
		protected System.Web.UI.WebControls.Button btnFiltrar;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void CargarPeriodos()
		{
			/*ddlbAno.DataSource = (new CPEAnoInversion()).ListarPEPeriodos(this.idPlanEstrategico);
			ddlbAno.DataValueField = "periodo";
			ddlbAno.DataTextField = "periodo";
			ddlbAno.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbAno.Items.Insert(0,item);

			if (Session[SESSIONPERIODO]!=null)
			{
				item = ddlbAno.Items.FindByValue(Session[SESSIONPERIODO].ToString());
				if(item!=null){item.Selected=true;}
			}
			else*/
				Session[SESSIONPERIODO]=periodo.ToString();
		}

		private void CargarTi()
		{
			/*ddlbTi.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaTipoRecursoACTIVIDAD));
			ddlbTi.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTi.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTi.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbTi.Items.Insert(0,item);

			if (Session[SESSIONTIPO]!=null)
			{
				item = ddlbTi.Items.FindByValue(Session[SESSIONTIPO].ToString());
				if(item!=null){item.Selected=true;}
			}
			else*/
				Session[SESSIONTIPO]=idtiprcs.ToString();
		}

		private void CargarTipo()
		{
			/*chkListTipoInversion.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaTipoACTIVIDAD));
			chkListTipoInversion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			chkListTipoInversion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			chkListTipoInversion.DataBind();
			chkListTipoInversion.RepeatLayout = RepeatLayout.Table;

			if (Session[SESSIONTI]!=null)
			{
				cadenaTipoinversion = Session[SESSIONTI].ToString();
				if (cadenaTipoinversion=="0")
				{
					chkTodos.Checked = true;
					Session[SESSIONTI]=cadenaTipoinversion;
					for (int i=0;i<chkListTipoInversion.Items.Count;i++)
						chkListTipoInversion.Items[i].Selected=true;
				}
				else
				{
					chkTodos.Checked = false;
					string []idTi = cadenaTipoinversion.Split(',');
					for (int i=0;i<idTi.Length;i++)
					{
						item = chkListTipoInversion.Items.FindByValue(idTi[i]);
						if(item!=null){item.Selected=true;}
					}
				}
			}
			else
			{
				chkTodos.Checked = true;*/
				Session[SESSIONTI]=cadenaTipoinversion;
				//				Page.RegisterClientScriptBlock("valor","<SCRIPT>chkInicialTodas();</SCRIPT>");
				/*for (int i=0;i<chkListTipoInversion.Items.Count;i++)
					chkListTipoInversion.Items[i].Selected=true;
			}*/
		}

		private void CargarNivel()
		{
			ddlbNivel.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaNivelACTIVIDAD));
			ddlbNivel.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbNivel.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbNivel.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbNivel.Items.Insert(0,item);


			if (Session[SESSIONNIVEL]!=null)
			{
				item = ddlbNivel.Items.FindByValue(Session[SESSIONNIVEL].ToString());
				if(item!=null){item.Selected=true;}
			}
			else
				Session[SESSIONNIVEL]=idniv.ToString();
		}
	
		private void CargarImportancia()
		{
			/*ddlbImportancia.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaImportanciaACTIVIDAD));
			ddlbImportancia.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbImportancia.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbImportancia.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbImportancia.Items.Insert(0,item);

			if (Session[SESSIONIMPORTANCIA]!=null)
			{
				item = ddlbImportancia.Items.FindByValue(Session[SESSIONIMPORTANCIA].ToString());
				if(item!=null){item.Selected=true;}
			}
			else*/
				Session[SESSIONIMPORTANCIA]=idimportancia.ToString();
		}

		private void CargarPrioridad()
		{
			/*for(int i=1;i<=10;i++)
				ddlbPrioridad.Items.Add(i.ToString());
			item = new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbPrioridad.Items.Insert(0,item);

			if (Session[SESSIONPRIORIDAD]!=null)
			{
				item = ddlbImportancia.Items.FindByValue(Session[SESSIONPRIORIDAD].ToString());
				if(item!=null){item.Selected=true;}
			}
			else*/
				Session[SESSIONPRIORIDAD]=prioridad.ToString();
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
//			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarCombos();
					Helper.ReestablecerPagina(this);
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarPlanEstrategicoObjetivosEspecificos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPlanEstrategicoObjetivosEspecificos.LlenarGrillaOrdenamiento implementation
		}

		public void Totalizar (DataView dwTotales)
		{
			if (dwTotales != null)
			{
				double [] aArreglo = Helper.TotalizarDataView(dwTotales,"INVERSION");
				TotInversion = aArreglo[0];
			}
		}

		private DataTable ObtenerDatos(int per, int tipo, string cadenati, int nivel, int idimportancia, int prioridad)
		{
			return (new CPEObjetivoEspecifico()).ListarTodosGrilla(this.idObjetivoGeneral,Utilitario.Constantes.FLAGDEFAULT, per, tipo, cadenati, nivel, idimportancia, prioridad);
		}
		private DataView FiltrarDatosXCentro(DataTable dt)
		{
			DataView dw = dt.DefaultView;
			string filtroXCentro = String.Empty;
			switch(CentroOperativo)
			{
				case (int)Utilitario.Enumerados.IdCentroOperativo.SimaCallao:
				{
					filtroXCentro = KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL +
						((int)Utilitario.Enumerados.IdCentroOperativo.SimaCallao).ToString();break;
				}
				case (int)Utilitario.Enumerados.IdCentroOperativo.SimaChimbote:
				{
					filtroXCentro = KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL +
						((int)Utilitario.Enumerados.IdCentroOperativo.SimaChimbote).ToString();break;
				}
				case (int)Utilitario.Enumerados.IdCentroOperativo.SimaPeru:
				{
					filtroXCentro = KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL +
						((int)Utilitario.Enumerados.IdCentroOperativo.SimaPeru).ToString() +
						" OR " + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL +
						((int)Utilitario.Enumerados.IdCentroOperativo.SimaCallao).ToString() +
						" OR " + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL +
							((int)Utilitario.Enumerados.IdCentroOperativo.SimaChimbote).ToString();break;
				}
				case (int)Utilitario.Enumerados.IdCentroOperativo.SimaIquitos:
				{
					filtroXCentro = KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL +
						((int)Utilitario.Enumerados.IdCentroOperativo.SimaIquitos).ToString();break;
				}
			}
			dw.RowFilter = filtroXCentro;
			return dw;
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			string filtro = String.Empty;
			DataTable dt = this.ObtenerDatos
				(
				Convert.ToInt32(Session[SESSIONPERIODO].ToString())
				, Convert.ToInt32(Session[SESSIONTIPO].ToString())
				, Session[SESSIONTI].ToString()
				, Convert.ToInt32(Session[SESSIONNIVEL].ToString())
				, Convert.ToInt32(Session[SESSIONIMPORTANCIA].ToString())
				, Convert.ToInt32(Session[SESSIONPRIORIDAD].ToString())
				);

			if(dt!=null)
			{
				DataView dw1 = FiltrarDatosXCentro(dt);
				if(dw1.Count > Utilitario.Constantes.ValorConstanteCero)
				{
					filtro = Helper.ObtenerFiltro();

					if(filtro.Trim() != String.Empty)
						dw1.RowFilter = "(" + dw1.RowFilter.ToString() + ") and " + filtro;
					
					DataTable dt1 = Helper.DataViewTODataTable(dw1);
					DataView dw = dt1.DefaultView;
					this.Totalizar(dw);

					dw.Sort = columnaOrdenar ;

					grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL+1].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
					grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL+2].FooterText = dw.Count.ToString();

					grid.DataSource = dw;
					grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla(7,14,21);
					grid.CurrentPageIndex = Convert.ToInt32(this.hGridPagina.Value);
					lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = dw1;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}

			}
			else
			{
				grid.DataSource = dt;
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
			this.CargarPeriodos();
			this.CargarNivel();
			this.CargarTipo();
			this.CargarTi();
			this.CargarImportancia();
			this.CargarPrioridad();
		}

		public void LlenarDatos()
		{
			lblPlanEstrategico.Text = this.PlanEstrategicoNombre;
			lblObjetivoGeneral.Text=this.ObjetivoGeneralNombre;
			lblObjGral.Text=this.CodigoObjetivoGeneral;
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarPlanEstrategicoObjetivosEspecificos.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPlanEstrategicoObjetivosEspecificos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarPlanEstrategicoObjetivosEspecificos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarPlanEstrategicoObjetivosEspecificos.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarPlanEstrategicoObjetivosEspecificos.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarPlanEstrategicoObjetivosEspecificos.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{

				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
					Helper.MostrarVentana(URLDETALLE+ Utilitario.Constantes.SIGNOINTERROGACION,KEYQIDOBJETIVOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL + dr["idObjetivoEspecifico"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDPLANESTRATEGICO + Utilitario.Constantes.SIGNOIGUAL + this.idPlanEstrategico.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDOBJETIVOGENERAL + Utilitario.Constantes.SIGNOIGUAL + this.idObjetivoGeneral.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQPLANESTRATEGICONOMBRE + Utilitario.Constantes.SIGNOIGUAL + this.PlanEstrategicoNombre
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQCODDOBJETIVOGENERAL + Utilitario.Constantes.SIGNOIGUAL +  this.CodigoObjetivoGeneral
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQOBJETIVOGENERALNOMBRE + Utilitario.Constantes.SIGNOIGUAL +  this.ObjetivoGeneralNombre
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()));
						

				Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[1],
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
					Helper.MostrarVentana(URLACCION + Utilitario.Constantes.SIGNOINTERROGACION,KEYQIDOBJETIVOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL + dr["idObjetivoEspecifico"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDPLANESTRATEGICO + Utilitario.Constantes.SIGNOIGUAL + this.idPlanEstrategico.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQOBJETIVOESPECIFICONOMBRE + Utilitario.Constantes.SIGNOIGUAL + dr["Descripcion"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQCODOBJETIVOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL +  dr["Codigo"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDOBJETIVOGENERAL + Utilitario.Constantes.SIGNOIGUAL + this.idObjetivoGeneral.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQPLANESTRATEGICONOMBRE + Utilitario.Constantes.SIGNOIGUAL + this.PlanEstrategicoNombre
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQCODDOBJETIVOGENERAL + Utilitario.Constantes.SIGNOIGUAL +  this.CodigoObjetivoGeneral
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQOBJETIVOGENERALNOMBRE + Utilitario.Constantes.SIGNOIGUAL +  this.ObjetivoGeneralNombre
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + dr["idCentroOperativo"].ToString()
					));
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				projDataGridWeb.DataGridWeb gridInd =(projDataGridWeb.DataGridWeb)e.Item.Cells[4].FindControl(CONTROLGRILLAINDICADORES);	
				DataTable dt = (new CPEIndicador()).ConsultarIndicadoresPlanOperativo(					
					Convert.ToInt32(dr[Enumerados.PlanEstrategicoColumnas.IdObjetivoEspecifico.ToString()].ToString()));

				gridInd.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridIndicadores_ItemDataBound);
				gridInd.Columns[0].ItemStyle.Width = 400;
				gridInd.Columns[1].ItemStyle.Width = 150;
				gridInd.DataSource = dt;
				gridInd.DataBind();

				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");
			}				
		}

		private void gridIndicadores_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				double Monto=0;

				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Monto = Convert.ToDouble(dr[Enumerados.PlanEstrategicoColumnas.Total.ToString()]);

				/*if (Enumerados.TipoDatosColumnas.DOUBLE.ToString() == dr[Enumerados.PlanEstrategicoColumnas.Var2.ToString()].ToString())
				{e.Item.Cells[1].Text = Monto.ToString(Utilitario.Constantes.FORMATODECIMAL4);}
				else
				{*/e.Item.Cells[1].Text = Monto.ToString(Utilitario.Constantes.FORMATODECIMAL0);//}
			}								
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro(this.ObtenerDatos(
				Convert.ToInt32(Session[SESSIONPERIODO].ToString())
				, Convert.ToInt32(Session[SESSIONTIPO].ToString())
				, Session[SESSIONTI].ToString()
				, Convert.ToInt32(Session[SESSIONNIVEL].ToString())
				, Convert.ToInt32(Session[SESSIONIMPORTANCIA].ToString())
				, Convert.ToInt32(Session[SESSIONPRIORIDAD].ToString())
				),"Codigo;Codigo","Descripcion;Descripcion","NOMBRECENTROOPERATIVO;Centro Operativo");

		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=Convert.ToInt32(this.hGridPagina.Value);
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	

		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void btnFiltrar_Click(object sender, System.EventArgs e)
		{
			// Filtro por Tipo de Inversion
			cadenaTipoinversion = "0";
			/*if (chkTodos.Checked != true)
			{
				cadenaTipoinversion = "";
				///Obtener Valores de un CheckBoxList
				for (int i=0; i< chkListTipoInversion.Items.Count; i++)
					if(chkListTipoInversion.Items[i].Selected)
						cadenaTipoinversion += Convert.ToInt32(chkListTipoInversion.Items[i].Value).ToString() + ",";
			}*/
                       
			cadenaTipoinversion = cadenaTipoinversion.TrimEnd(',');

			Session[SESSIONTI]=cadenaTipoinversion;

			// Filtro por Naturaleza
			idtiprcs = 0; //Convert.ToInt32(ddlbTi.SelectedValue=="&"?"0":ddlbTi.SelectedValue);
			Session[SESSIONTIPO]=idtiprcs.ToString();

			// Filtro por Nivel
			idniv  = Convert.ToInt32(ddlbNivel.SelectedValue=="&"?"0":ddlbNivel.SelectedValue);
			Session[SESSIONNIVEL]=idniv.ToString();

			// Filtro por Año
			periodo = 0; //Convert.ToInt32(ddlbAno.SelectedValue=="&"?"0":ddlbAno.SelectedValue);
			Session[SESSIONPERIODO]=periodo.ToString();

			// Filtro por Importancia
			idimportancia = 0; //Convert.ToInt32(ddlbImportancia.SelectedValue=="&"?"0":ddlbImportancia.SelectedValue);
			Session[SESSIONIMPORTANCIA]=idimportancia.ToString();

			// Filtro por Prioridad
			prioridad = 0; //Convert.ToInt32(ddlbPrioridad.SelectedValue=="&"?"0":ddlbPrioridad.SelectedValue);
			Session[SESSIONPRIORIDAD]=prioridad.ToString();


			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		
		}

	}
}
