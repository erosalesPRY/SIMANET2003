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
using SIMA.EntidadesNegocio.General;

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using System.IO;
using Microsoft.Office.Core;
using Excel= Microsoft.Office.Interop.Excel;

namespace SIMA.SimaNetWeb.General.Diapositivas.GestionFinanciera
{
	/// <summary>
	/// Summary description for EstadoFinancieroCorporativo.
	/// </summary>
	public class EstadoFinancieroCorporativo : System.Web.UI.Page,IPaginaBase
	{
		protected projDataGridWeb.DataGridWeb grid;
	
		const string KEYQIDFORMATO="IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO ="IdRubro";
		const string KEYQPERIODO = "Periodo";
		const string IDCENTROOPERATIVO="idcop";
		const string KEYQIDTIPOINFO ="idTipoInfo";
		const string KEYQACUMULADO="Acum";

		const string KEYQIDOBJETO="IdObj";

		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreImgTrim;
		

		private int IdFormato
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);}
		}
		public int IdReporte{
			get{ return Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);}
		}

		public string IdCentroOperativo
		{
			get{return Page.Request.Params[IDCENTROOPERATIVO].ToString();}
		}

		public int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}

		public int IdTipoInformacion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO]);}
		}

		public int IdObjeto
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDOBJETO]);}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarGrilla();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera: Administrar Formatos Financieros mensualizados", this.ToString(),"Se consultó Listado de formtatos financieros",Enumerados.NivelesErrorLog.I.ToString()));
					
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt = (new  CEstadosFinancierosDirectorio()).ListarFormatoAnual(this.IdFormato,this.IdReporte, this.IdCentroOperativo ,this.Periodo,1,this.IdTipoInformacion);
			if(dt!=null)
			{
				grid.DataSource =  Helper.OrdenarFormatoEstructura(dt);
			}
			else
			{
				grid.DataSource = dt;
			}
			grid.DataBind();

			grid.ID="F"+ IdFormato.ToString()+"_"+this.IdReporte.ToString();
		}

		//HtmlTable TblNodo(

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add EstadoFinancieroCorporativo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add EstadoFinancieroCorporativo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add EstadoFinancieroCorporativo.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.hNombreImgTrim.Value = Helper.ObtenerNombreTrimestre(DateTime.Now.Month,Enumerados.TipoDatoTrimestre.SinEspacio).ToString().ToUpper();
		}

		public void LlenarJScript()
		{
			// TODO:  Add EstadoFinancieroCorporativo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add EstadoFinancieroCorporativo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add EstadoFinancieroCorporativo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add EstadoFinancieroCorporativo.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add EstadoFinancieroCorporativo.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add EstadoFinancieroCorporativo.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			int idMes = 1;
			try
			{
				for(int c=1;c<=16;c++)
				{
					if((c>=1 && c<=3)||(c>=5 && c<=7)||(c>=9 && c<=11)||(c>=13 && c<=15))
					{
						//e.Item.Cells[c].Style.Add("display","none");
						if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
						{
							DataRowView drv = (DataRowView)e.Item.DataItem;
							DataRow dr = drv.Row;			
							string NMes = Helper.ObtenerNombreMes(idMes,Enumerados.TipoDatoMes.NombreCompleto);
							e.Item.Cells[c].Text = Convert.ToDouble(dr[NMes].ToString()).ToString(Constantes.FORMATODECIMAL4);
							idMes++;
						}
					}
					else
					{
						if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
						{
							DataRowView drv = (DataRowView)e.Item.DataItem;
							DataRow dr = drv.Row;
							string NTrim = Helper.ObtenerNombreTrimestre((idMes-1),SIMA.Utilitario.Enumerados.TipoDatoTrimestre.SinEspacio).ToString();

							e.Item.Cells[c].Text = Convert.ToDouble(dr[NTrim].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);
							e.Item.Cells[c].Font.Bold=true;
							e.Item.Cells[c].Font.Size = FontUnit.Point(8);
							e.Item.Cells[c].Style.Add("BACKGROUND-COLOR","gainsboro");
							
						}
					}
				}

				if(e.Item.ItemType == ListItemType.Header)
				{
					e.Item.Cells[0].Visible=false;//para conbinar la columna 1

				}
				else if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
				{
					DataRowView drv = (DataRowView)e.Item.DataItem;
					DataRow dr = drv.Row;			

					e.Item.Cells[0].Controls.Add(ConfigConceptos(e,IdObjeto));
					
					Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				}	
			}
			catch(Exception ex)
			{
				string mMs = ex.Message;
				string h = mMs;
				int err=1;
				err++;
			}		
		}

		public HtmlTable ConfigConceptos(System.Web.UI.WebControls.DataGridItemEventArgs e,int IdObjeto){
					DataRowView drv = (DataRowView)e.Item.DataItem;
					DataRow dr = drv.Row;			

					int NroCol = (Convert.ToInt32(dr["IdNivel"].ToString())+ 2);

					HtmlTable tblNodo= Helper.CrearHtmlTabla(1,NroCol,true);
					HtmlImage oImg;
					for(int c=0;c<=NroCol-1;c++){
						oImg = new HtmlImage();
						oImg.Src="/SimaNetWeb/imagenes/tree/Blanco.gif";
						oImg.Width=5;
						tblNodo.Rows[0].Cells[c].Controls.Add(oImg);
					}
					tblNodo.Rows[0].Cells[NroCol-1].InnerText=dr["Concepto"].ToString();
					int Totalizado = Convert.ToInt32(dr["Totalizado"].ToString());
					int NroHijos = Convert.ToInt32(dr["NroHijos"].ToString());
					
					if((Totalizado==0)&&(NroHijos==0))
					{
						DiapositivaLinkBE oDiapositivaLinkBE= (DiapositivaLinkBE)(new CDiapositivaLink()).Detalle(IdObjeto,dr["IdRubro"].ToString());
						if(oDiapositivaLinkBE !=null)
						{
							e.Item.Cells[0].Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()]="snPoint.ActivarPPT(null,'Obj" + oDiapositivaLinkBE.IdObjetoLink.ToString() + "');";
							tblNodo.Rows[0].Cells[NroCol-1].Style.Add("COLOR","#3300ff");
							tblNodo.Rows[0].Cells[NroCol-1].Style.Add("TEXT-DECORATION","underline");
							tblNodo.Rows[0].Cells[NroCol-1].Style.Add("font-size","11px");
						}
						for(int cc=1;cc<=e.Item.Cells.Count-1;cc++)
						{
							e.Item.Cells[cc].Style.Add("COLOR","#000080");
							e.Item.Cells[cc].Style.Add("font-size","10px");
							e.Item.Cells[cc].Attributes.Add("align","right");
						}

					}
					else{
						tblNodo.Rows[0].Cells[NroCol-1].Style.Add("COLOR","#000080");
						tblNodo.Rows[0].Cells[NroCol-1].Style.Add("font-weight","bold");
						tblNodo.Rows[0].Cells[NroCol-1].Style.Add("font-size","12px");
						for(int cc=1;cc<=e.Item.Cells.Count-1;cc++)
						{
							e.Item.Cells[cc].Style.Add("COLOR","#000080");
							e.Item.Cells[cc].Style.Add("font-weight","bold");
							e.Item.Cells[cc].Style.Add("font-size","12px");
							e.Item.Cells[cc].Attributes.Add("align","right");
							if((Totalizado==0)&&(NroHijos!=0)){
								e.Item.Cells[cc].Text="";
							}
						}						

					}	
			return tblNodo;
		}
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
						tc.Style.Add("width","15%");
						tc.Controls.Add(new LiteralControl("CONCEPTO"));
					}
					else if((i==1)||(i==5)||(i==9)||(i==13))
					{
						string TITULO="TRIM ";
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
						tc.ID = TITULO.Replace(" ","");

						HtmlTable oHtmlTable = Helper.CrearTabla(1,2);
						oHtmlTable.Rows[0].Attributes.Add("class","HeaderGrilla");
						//oHtmlTable.Rows[0].Cells[0].Controls.Add(new LiteralControl("<IMG id='" + TITULO.Replace(" ","") + "' ColIni=" + i.ToString() + " src='/SimaNetWeb/imagenes/tree/plusCol.gif' onclick='CollapseCol(this)'>"));
						oHtmlTable.Rows[0].Cells[1].InnerText=TITULO;
						tc.Controls.Add(oHtmlTable);
						tc.ColumnSpan=4;
						tc.Attributes.Add("align","center");
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
	}
}
