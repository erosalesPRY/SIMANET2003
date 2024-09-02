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
using SIMA.EntidadesNegocio.GestionFinanciera;

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using System.IO;

namespace SIMA.SimaNetWeb.General.Formato
{
	/// <summary>
	/// Summary description for AdministrarFormatoDetalleMovimientoporPeriodoItem.
	/// </summary>
	public class AdministrarFormatoDetalleMovimientoporPeriodoItem : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string KEYQIDFORMATO="idFormato";
			const string  KEYQIDRUBRO ="idRubro";
			const string  KEYQNOMBRERUBRO ="NombreRubro";
			const string  KEYQPERIODO = "Periodo";
			const string  KEYQIDGRUPOFORMATO="IdGrupoFormato";
			const string  IDCENTROOPERATIVO="idcop";
			const string  KEYQIDCENTROCOSTO ="idCC";
			const string  KEYQIDTIPOINFO ="idTipoInfo";
			const string KEYQREQCC ="ReqCC";
		#endregion


		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtBuscar;
		protected System.Web.UI.WebControls.Label lblRubro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreImgTrim;
	
		DataTable dt;
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();
					this.LlenarGrilla();
					
				}
			}
			catch(SIMAExcepcionLog oSIMAExcepcionLog)
			{
				Helper.MsgBox(oSIMAExcepcionLog.Mensaje);					
			}
			catch(SIMAExcepcionIU oSIMAExcepcionIU)
			{
				Helper.MsgBox(oSIMAExcepcionIU.Mensaje);					
			}
			catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
			{
				Helper.MsgBox(oSIMAExcepcionDominio.Mensaje);					
			}
			catch(Exception oException)
			{
				string debug = oException.Message.ToString();
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
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemCreated);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			dt = (new  CFormatoDetalleMovimientoCentroCostoItem()).ConsultarFormatoDetalleMovimientoItem(
																				Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])
																				,1
																				,Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO])
																				,Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO])
																				,((Convert.ToInt32(Page.Request.Params[KEYQREQCC])==0)?-1:Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO]))
																				,Convert.ToInt32(Page.Request.Params[KEYQPERIODO])
																				,Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO])
																				);
			grid.DataSource =  RegistrosVirtuales(dt);
			grid.DataBind();
		}
		DataTable RegistrosVirtuales(DataTable dt){
			if(dt==null){//Crear estructura
				dt = new DataTable();
				dt.Columns.Add("idDetDesFmtCC",System.Type.GetType("System.Int32"));
				dt.Columns.Add("Descripcion",System.Type.GetType("System.String"));
				for(int m=1;m<=12;m++){
					dt.Columns.Add(Helper.ObtenerNombreMes(m,Utilitario.Enumerados.TipoDatoMes.NombreCompleto),System.Type.GetType("System.Double"));
					if((m==3)||(m==6)||(m==9)||(m==12)){
						dt.Columns.Add(Helper.ObtenerNombreTrimestre(m,Utilitario.Enumerados.TipoDatoTrimestre.SinEspacio),System.Type.GetType("System.Double"));
					}
				}
			}
			for(int r=0;r<=15;r++)
			{
				object []reg={0,"",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
				dt.Rows.Add(reg);
			}
			dt.AcceptChanges();
			return dt;
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarFormatoDetalleMovimientoporPeriodoItem.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarFormatoDetalleMovimientoporPeriodoItem.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarFormatoDetalleMovimientoporPeriodoItem.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.hNombreImgTrim.Value = Helper.ObtenerNombreTrimestre(DateTime.Now.Month,Enumerados.TipoDatoTrimestre.SinEspacio).ToString().ToUpper();
			this.lblRubro.Text = Page.Request.Params[KEYQNOMBRERUBRO].ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarFormatoDetalleMovimientoporPeriodoItem.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarFormatoDetalleMovimientoporPeriodoItem.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarFormatoDetalleMovimientoporPeriodoItem.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarFormatoDetalleMovimientoporPeriodoItem.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarFormatoDetalleMovimientoporPeriodoItem.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarFormatoDetalleMovimientoporPeriodoItem.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				
				DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
				for(int i=0;i<=grid.Columns.Count-1;i++)
				{
					TableCell tc = new TableCell();
					if(i==0)
					{
						tc.RowSpan=2;
						tc.Style.Add("width","25%");
						tc.Controls.Add(new LiteralControl("CONCEPTO"));
					}
					else if((i==1)||(i==5)||(i==9)||(i==13))
					{
						string TITULO="TRIM ";

						//tc.ColumnSpan=4;
						tc.ColumnSpan=1;
						switch(i)
						{
							case 1:
								TITULO =TITULO +"I";
								break;
							case 5:
								TITULO =TITULO +"II";
								break;
							case 9:
								TITULO =TITULO +"III";
								break;
							case 13:
								TITULO =TITULO +"IV";
								break;
						}
						HtmlTable oHtmlTable = Helper.CrearTabla(1,2);
						oHtmlTable.Rows[0].Attributes.Add("class","HeaderGrilla");
						oHtmlTable.Rows[0].Cells[0].Controls.Add(new LiteralControl("<IMG id='" + TITULO.Replace(" ","") + "' ColIni=" + i.ToString() + " src='../../imagenes/tree/plusCol.gif' onclick='CollapseCol(this,this.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement,this.parentElement.parentElement.parentElement.parentElement.parentElement)'>"));
						oHtmlTable.Rows[0].Cells[1].InnerText=TITULO;
						tc.Controls.Add(oHtmlTable);
					}
					else if((i>1 && i<=4)||(i>5 && i<=8)||(i>9 && i<=12)||(i>13 && i<=16))
					{
						tc.Visible=false;
					}
					di.Cells.Add(tc);
				}
				DataGrid dg = (DataGrid)sender;
				Table t = (Table)dg.Controls[0];
				t.Rows.Add(di);
			}		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			int idMes = 1;
			for(int c=1;c<=16;c++)
			{
				if((c>=1 && c<=3)||(c>=5 && c<=7)||(c>=9 && c<=11)||(c>=13 && c<=15))
				{
					e.Item.Cells[c].Style.Add("display","none");
					if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
					{
						DataRowView drv = (DataRowView)e.Item.DataItem;
						DataRow dr = drv.Row;			
						string NMes = Helper.ObtenerNombreMes(idMes,Enumerados.TipoDatoMes.NombreCompleto);
						eWorld.UI.NumericBox nb = (eWorld.UI.NumericBox)e.Item.Cells[c].FindControl("n" + NMes);	
						nb.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,"EnfocarSiguienteCelda(this);");
						nb.Text = Convert.ToDouble(dr[NMes]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
						nb.Attributes.Add("tag",Convert.ToDouble(dr[NMes]).ToString());
						nb.Attributes.Add("idMes",idMes.ToString());
						if(idMes==DateTime.Now.Month)
						{
							e.Item.Cells[c].Style.Add("BACKGROUND-COLOR","lightgoldenrodyellow");
						}
						idMes++;
					}
				}
				else
				{
					if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
					{
						DataRowView drv = (DataRowView)e.Item.DataItem;
						DataRow dr = drv.Row;
						e.Item.Cells[c].Text = Convert.ToDouble(dr[Helper.ObtenerNombreTrimestre((idMes-1),SIMA.Utilitario.Enumerados.TipoDatoTrimestre.SinEspacio).ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
						e.Item.Cells[c].Font.Bold=true;
						e.Item.Cells[c].Font.Size = FontUnit.Point(8);
						e.Item.Attributes.Add("IDDETDESFMTCC",dr["idDetDesFmtCC"].ToString());
						e.Item.Cells[c].Style.Add("BACKGROUND-COLOR","gainsboro");
						if(Convert.ToInt32(dr["idDetDesFmtCC"])==0)
						{
							e.Item.Style.Add("display","none");
						}
						Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
					}
				}
			}

			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[0].Visible=false;//para conbinar la columna 1
			}		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
