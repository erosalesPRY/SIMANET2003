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
using SIMA.Controladoras.Personal;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto
{
	public class AdministrarTransferenciasdePartidas : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
			const string GRILLAVACIA="";
			
			const string KEYIDREQUERIMIENTO="idrqr";
			const string KEYQTIPOPRESUPUESTO="idTP";
			
			const string KEYQIDCENTROOPERATIVO="idCentroOperativo";
			const string KEYQIDGRUPOCC="idGrupoCC";
			const string KEYQIDCENTROCOSTO="IdCentroCosto";
			const string KEYIDNROCC = "NroCC";
			const string KEYIDNOMBRECC = "NombreCC";
			const string KEYQPERIODO="Periodo";
			const string KEYQMES="idMes";
			const string KEYQIDTRANSFERENCIA="idTransf";
		//Etiuwetas
			const string LBLPPTO="lblPrespuesto";
			const string LBLRQR="lblEjecutado";
			const string LBLSALDO="lblSaldo";
		#endregion
		#region Controles
			protected System.Web.UI.WebControls.Label lblPagina;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdMaestar;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.ConfigurarAccesoControles();
				Helper.ReiniciarSession();
				Helper.ReestablecerPagina(this);
				this.LlenarJScript();
				this.LlenarDatos();
				this.LlenarCombos();
				this.LlenarGrilla();
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
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Error);					
			}
			catch(Exception oException)
			{
				string msgb =oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		#region IPaginaBase Members

		private DataTable ObtenerDatos()
		{
			return ((CPresupuestoTransferencia)new  CPresupuestoTransferencia()).ConsultarTransferencia(
																									Convert.ToInt32(Page.Request.Params[KEYIDREQUERIMIENTO].ToString())
																									,Convert.ToInt32(Page.Request.Params[KEYQIDTRANSFERENCIA].ToString())
																									,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO])
																									,Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOCC])
																									,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO])
																									,Convert.ToInt32(Page.Request.Params[KEYQPERIODO])
																									,Convert.ToInt32(Page.Request.Params[KEYQMES])
																									,Convert.ToInt32(Page.Request.Params[KEYQTIPOPRESUPUESTO]));
		}
		private DataTable ObtenerCabeceraGrilla(){
			return ((CPresupuestoTransferencia)new  CPresupuestoTransferencia()).ConsultarTransferenciaCentrodecostoSolicitado(Convert.ToInt32(Page.Request.Params[KEYIDREQUERIMIENTO].ToString())
																																,Convert.ToInt32(Page.Request.Params[KEYQIDTRANSFERENCIA].ToString()));
		}

		#region Nueva rutina Columnas nuevas
		string [,]DataHead;
		private void CrearHeaderColumnas()
		{
			string []subColumnas={"PPTO","TRANS","SALD"};
			Session["TBLHEAD"]=null;
			Session["DTHEAD"]=null;
			DataTable dt = this.ObtenerCabeceraGrilla();
			if (dt!=null)
			{
				int NroColumnas = dt.Rows.Count;

				grid.Columns[2].Visible=true;
				Session["DTHEAD"]=dt;
				Session["NROCOLUMNAS"] = (NroColumnas);

				HtmlTable otbl = CrearTabla(2,(NroColumnas * 1)-1);
				otbl.Border=0;
				DataHead = new string[2,(NroColumnas * 1)];
				decimal AnchoCol = (100/(NroColumnas * 1));
				int Columna=0;
				foreach(DataRow dr in dt.Rows)
				{
					//for(int c=0;c<=1;c++)
					//int c=1;
					{
						otbl.Rows[0].Cells[Columna].Controls.Add(this.CrearEtiqueta(dr["NombreGrupoCentroCosto"].ToString(),"HeaderGrilla"));
						DataHead[0,Columna] = dr["NombreGrupoCentroCosto"].ToString();
						
						otbl.Rows[1].Cells[Columna].Controls.Add(this.CrearEtiqueta(dr["NombreCentroCosto"].ToString(),"HeaderGrilla"));
						DataHead[1,Columna] = dr["NombreCentroCosto"].ToString();
						
						/*otbl.Rows[2].Cells[Columna].Controls.Add(this.CrearEtiqueta(Utilitario.Helper.ObtenerNombreMes(Convert.ToInt32(dr["idMes"]),SIMA.Utilitario.Enumerados.TipoDatoMes.Abreviatura),"HeaderGrilla"));
						DataHead[2,Columna] = dr["idMes"].ToString();
						
						otbl.Rows[3].Cells[Columna].Controls.Add(this.CrearEtiqueta(subColumnas[c].ToString(),"HeaderGrilla"));
						*/
						otbl.Rows[1].Cells[Columna].Style.Add("BORDER-LEFT",((Columna>0)?"#cccccc 1px solid":""));
						otbl.Rows[1].Cells[Columna].Width=AnchoCol.ToString() +"%";
						
						Columna++;
					}
				}
				this.TblColSpan(otbl,0,true);
				/*this.TblColSpan(otbl,1,true);
				this.TblColSpan(otbl,2,true);*/
				/**/
				Session["TBLHEAD"] = otbl;
			}
		}
		private void TblColSpan(HtmlTable tbl,int Fila,bool Underline)
		{
			int NroColumnas=tbl.Rows[Fila].Cells.Count-1;
			int c=0;
			while(c<NroColumnas)
			{
				string strValor=DataHead[Fila,c].ToString();
				int []Config= QuiebrePorGrupo(tbl,strValor,Fila,c);
				
				tbl.Rows[Fila].Cells[c].Style.Add("BORDER-LEFT",((c>0)?"#cccccc 1px solid":""));				
				if(Underline)
				{
					tbl.Rows[Fila].Cells[c].Style.Add("BORDER-BOTTOM","#cccccc 1px solid");
				}
				tbl.Rows[Fila].Cells[c].ColSpan=((NroColumnas== Config[0])?(Config[1]+1):Config[1]);
				c=Config[0];
			}
		}

		private int []QuiebrePorGrupo(HtmlTable tbl,string strValor,int Fila,int ColIni)
		{
			int MaxCol = (tbl.Rows[Fila].Cells.Count-1);
			int []Config = new int[2];
			int ColSpan=1;
			for(int i=(ColIni+1);i<=MaxCol;i++)
			{
				string ValorCeldaActual=DataHead[Fila,i].ToString();
				if ((ValorCeldaActual!=strValor) ||(i==MaxCol))
				{
					if((i==MaxCol))
					{
						tbl.Rows[Fila].Cells[i].Style.Add("display","none");
					}
					Config[0]=i;
					Config[1]=ColSpan;
					return Config;
				}
				tbl.Rows[Fila].Cells[i].Style.Add("display","none");
				ColSpan++;
			}
			return Config;
		}
		#endregion



		
		private Label CrearEtiqueta(string Texto,string Clase)
		{
			Label lbl = new Label();
			lbl.Text = Texto;
			lbl.CssClass = Clase;
			lbl.BorderStyle= System.Web.UI.WebControls.BorderStyle.None;
			return lbl;
		}
		private HtmlTable CrearTabla(int NroFilas,int NroCol){
			HtmlTable Tabla = new HtmlTable();
			Tabla.Border=0;
			Tabla.CellPadding=0;
			Tabla.CellSpacing=0;
			Tabla.Height="100%";
			Tabla.Width="100%";
			HtmlTableRow tr;
			HtmlTableCell td;
			for(int f=0;f<=NroFilas-1;f++)
			{
				tr = new HtmlTableRow();
				for(int c=0;c<=NroCol;c++)
				{
					td = new HtmlTableCell();
					td.Align="center";
					//td.InnerText=f.ToString()+ " - "  + c.ToString();
					tr.Controls.Add(td);
				}
				Tabla.Controls.Add(tr);
			}
			return Tabla;
		}

		public void LlenarGrilla()
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				this.CrearHeaderColumnas();
				grid.DataSource = dtGeneral;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtGeneral;
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

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.LlenarGrillaOrdenamiento implementation
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarTransferenciasdePartidas.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				((Label)e.Item.Cells[0].FindControl("lblPeriodo")).Text = Helper.ObtenerNombreMes(Convert.ToInt32(Page.Request.Params[KEYQMES]),SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToString().ToUpper() + " DEL " + Page.Request.Params[KEYQPERIODO].ToString().ToUpper();
				if(Session["TBLHEAD"]!=null)
				{
					e.Item.Cells[2].Controls.Add((HtmlTable)Session["TBLHEAD"]);
				}
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Attributes.Add("CuentaContable3Dig",dr["CuentaContable3Dig"].ToString());
				e.Item.Cells[0].Controls.Add(Helper.CrearNodoRaiz(e,dr["CuentaContableGrupo"].ToString() + "-" + e.Item.Cells[0].Text,"NodeItem_OnClick" ,true));
		

				Label lbl;
				lbl = (Label)e.Item.Cells[0].FindControl(LBLPPTO);
				lbl.Text = Convert.ToDouble(dr["MontoPresupuestoMes"]).ToString(Constantes.FORMATODECIMAL4);
				lbl = (Label)e.Item.Cells[0].FindControl(LBLRQR);
				lbl.Text = Convert.ToDouble(dr["MontoRequeridoMes"]).ToString(Constantes.FORMATODECIMAL4);
				lbl = (Label)e.Item.Cells[0].FindControl(LBLSALDO);
				lbl.Text = Convert.ToDouble(dr["TotalMes"]).ToString(Constantes.FORMATODECIMAL4);
				/*crea la Tabla con columnas del los difernecte Centros de costo*/
				if(Session["DTHEAD"]!=null){
					int NroColumnas = (int)Session["NROCOLUMNAS"];
					int TotCol=(NroColumnas*1);
					e.Item.Attributes.Add("NroColumnas",TotCol.ToString());
					e.Item.Style.Add("paddingTop","0px");
					e.Item.Style.Add("paddingBottom","0px");
					e.Item.Style.Add("borderBottom","0px");

					HtmlTable tbl = this.CrearTabla(1,TotCol-1);
					tbl.Border=0;
					tbl.CellPadding=0;
					tbl.CellSpacing=0;
					DataTable dt = (DataTable)Session["DTHEAD"];
					decimal AnchoCol = (100/TotCol);
					int Columna=0;
					string []subColumnas={"P","A","S"};
					
					foreach(DataRow cdr in dt.Rows)
					{
						//for(int c=0;c<=1;c++)
						int c=1;
						{
							string NombreCampo = subColumnas[c].ToString() + cdr["idGrupoCC"].ToString() + "_" + cdr["idCentroCosto"].ToString() + "_" + cdr["idMes"].ToString();
							tbl.Rows[0].Cells[Columna].InnerText= Convert.ToDouble(dr[NombreCampo].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);
							tbl.Rows[0].Cells[Columna].Attributes.Add("class","ItemGrillaSinColor");
							tbl.Rows[0].Cells[Columna].Style.Add("height","100%");
							tbl.Rows[0].Cells[Columna].Width= AnchoCol.ToString() +"%";
							if(c==1)
							{
								tbl.Rows[0].Cells[Columna].Attributes.Add("bgColor","#ffffff");
							}
							tbl.Rows[0].Cells[Columna].Style.Add("BORDER-LEFT",((Columna>0)?"#cccccc 1px solid":""));
							tbl.Rows[0].Cells[Columna].Attributes.Add("align","right");
							tbl.Rows[0].Cells[Columna].Attributes.Add("NombreCampo",NombreCampo);
							Columna++;
						}						
					}
					e.Item.Cells[2].Controls.Add(tbl);
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}
	}
}


