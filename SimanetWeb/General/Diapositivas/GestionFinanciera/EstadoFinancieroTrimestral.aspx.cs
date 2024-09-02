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


//FINuspNTADConsultarFormatoDetalleMovimiento

namespace SIMA.SimaNetWeb.General.Diapositivas.GestionFinanciera
{
	/// <summary>
	/// Summary description for EstadoFinancieroTrimestral.
	/// </summary>
	public class EstadoFinancieroTrimestral : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Panel Panel;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreImgTrim;
	
		General.Diapositivas.GestionFinanciera.HeaderFIN usc_HeaderFin;

		const string URLCONTROL= "HeaderFIN.ascx";
		protected System.Web.UI.HtmlControls.HtmlGenericControl IframeSeccion;
		string NomTrimAct="";


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
			grid.ID="F"+ Utilitario.Helper.GestionFinanciera.Params.IdFormato.ToString()+"_"+Utilitario.Helper.GestionFinanciera.Params.IdReporte.ToString()+"_"+ Utilitario.Helper.GestionFinanciera.Params.IdObjeto.ToString();		

			DataTable dt=(new  General.InvocaControladora()).CallSourceDataToReportFromAssembly(((System.Web.UI.Page) HttpContext.Current.Handler).Request.PhysicalApplicationPath + @"bin\SIMA.Controladoras.dll");

			//DataTable dt = (new  CEstadosFinancierosDirectorio()).ListarFormatoAnual(Utilitario.Helper.GestionFinanciera.Params.IdFormato,Utilitario.Helper.GestionFinanciera.Params.IdReporte, Utilitario.Helper.GestionFinanciera.Params.IdCentroOperativo ,Utilitario.Helper.GestionFinanciera.Params.Periodo,Utilitario.Helper.GestionFinanciera.Params.IdMes,Utilitario.Helper.GestionFinanciera.Params.IdTipoInformacion);
			if(dt!=null)
			{
				grid.DataSource =  Helper.OrdenarFormatoEstructura(dt);
			}
			else
			{
				grid.DataSource = dt;
			}
			grid.DataBind();

			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add EstadoFinancieroTrimestral.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add EstadoFinancieroTrimestral.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add EstadoFinancieroTrimestral.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			/******Cargar Cabecera*******************************************************************/
			usc_HeaderFin = (General.Diapositivas.GestionFinanciera.HeaderFIN)LoadControl(URLCONTROL);
			usc_HeaderFin.Titulo = Utilitario.Helper.GestionFinanciera.Params.Titulo;
			usc_HeaderFin.SubTitulo=Utilitario.Helper.GestionFinanciera.Params.SubTitulo;
			Panel.Controls.Clear();
			Panel.Controls.Add(usc_HeaderFin);
			/*************************************************************************/
			System.Web.UI.WebControls.TemplateColumn Tcolumn;
			
			int IdxMes=1;
			//for(int i=1;i<=16;i++)
			int NroCols = Helper.ObtenerNroColumnasxTrimAcum(Utilitario.Helper.GestionFinanciera.Params.IdMes,SIMA.Utilitario.Enumerados.TipoDatoTrimestre.Abreviado,true);
			for(int i=1;i<=NroCols;i++)
			{
				Tcolumn = new System.Web.UI.WebControls.TemplateColumn();
				if((i==4)||(i==8)||(i==12)||(i==16))
				{
					Tcolumn.HeaderText= Helper.ObtenerNombreTrimestre((IdxMes-1),Utilitario.Enumerados.TipoDatoTrimestre.Abreviado);
				}
				else
				{
					Tcolumn.HeaderText= Helper.ObtenerNombreMes(IdxMes,SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto);
					IdxMes++;
				}
				Tcolumn.ItemStyle.Wrap=false;
				Tcolumn.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
				grid.Columns.Add(Tcolumn);
			}
			grid.Style.Add("BORDER-COLLAPSE","collapse");

			hNombreImgTrim.Value = Helper.ObtenerNombreTrimestre(Utilitario.Helper.GestionFinanciera.Params.IdMes,SIMA.Utilitario.Enumerados.TipoDatoTrimestre.SinEspacio);
			NomTrimAct=Helper.ObtenerNombreTrimestre(Utilitario.Helper.GestionFinanciera.Params.IdMes,Utilitario.Enumerados.TipoDatoTrimestre.Abreviado);

			//Cargar la seccion de detalle
			//string Param = Page.Request.QueryString.ToString();
			//IframeSeccion.Attributes.Add("src","http://speverosales4/SimanetWeb/General/Diapositivas/GestionFinanciera/GastosGraphChart.aspx?"+ Param);
		}

		public void LlenarJScript()
		{
			//Page.RegisterStartupScript("SC","<script>OnClickCollpase();</script>");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add EstadoFinancieroTrimestral.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add EstadoFinancieroTrimestral.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add EstadoFinancieroTrimestral.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add EstadoFinancieroTrimestral.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add EstadoFinancieroTrimestral.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				string TITULO ="";
				int IdxMes=1;
				DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
				for(int i=0;i<=grid.Columns.Count-1;i++)
				{
					TableCell tc = new TableCell();
					if(i==0){
						tc.RowSpan=2;
						tc.Style.Add("width","25%");
						tc.Text="CONCEPTO";
					}
					else if((i==1)||(i==5)||(i==9)||(i==13))
					{
						TITULO = Helper.ObtenerNombreTrimestre(IdxMes,Utilitario.Enumerados.TipoDatoTrimestre.Abreviado);
						tc.ColumnSpan=1;
						tc.ID = "Cell_" + TITULO.Replace(" ","");
						string Cmll="\"";
						string img="";
						if(TITULO ==NomTrimAct)
						{
							tc.ColumnSpan=4;
							img="minusCol.gif";
						}
						else
						{
							img="plusCol.gif";
						}
						
						HtmlTable oHtmlTable = Helper.CrearTabla(1,2);
						oHtmlTable.Rows[0].Attributes.Add("class","HeaderGrilla");
						oHtmlTable.Rows[0].Cells[0].Controls.Add(new LiteralControl("<IMG id='Img_" + tc.ID + "' CellID=" +  grid.ID.ToString() + "__ctl1_" + tc.ClientID  + " ColIni=" + i.ToString() + "  src='" + Page.Request.ApplicationPath + "/imagenes/tree/" + img + "' onclick=" + Cmll + "CollapseCol(this,'" + grid.ID.ToString() + "')" +Cmll+">"));
						oHtmlTable.Rows[0].Cells[1].InnerText=TITULO;
						oHtmlTable.Rows[0].Cells[1].NoWrap=true;
						tc.Controls.Add(oHtmlTable);
					}
					else if((i>1 && i<=4)||(i>5 && i<=8)||(i>9 && i<=12)||(i>13 && i<=16))
					{
						IdxMes++;
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
			try
			{
				//for(int c=1;c<=16;c++)
				for(int c=1;c<=grid.Columns.Count-1;c++)
				{
					if((c>=1 && c<=3)||(c>=5 && c<=7)||(c>=9 && c<=11)||(c>=13 && c<=15))
					{	
						string NMes ="";
						e.Item.Cells[c].Style.Add("display","none");
						if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
						{
							DataRowView drv = (DataRowView)e.Item.DataItem;
							DataRow dr = drv.Row;			
							NMes = Helper.ObtenerNombreMes(idMes,Enumerados.TipoDatoMes.NombreCompleto);

							e.Item.Cells[c].Text = Convert.ToDouble(dr[NMes].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);
							e.Item.Cells[c].Attributes.Add("NoWrap","");

							if(idMes==Utilitario.Helper.GestionFinanciera.Params.IdMes)
							{
								HtmlTable otblitm = Helper.CrearHtmlTabla(1,2,true);
								otblitm.CellPadding=0;
								otblitm.CellSpacing=0;
								otblitm.Style.Add("HEIGHT","100%");
								otblitm.Style.Add("width","100%");
								otblitm.Rows[0].Cells[0].Style.Add("width","50%");
								otblitm.Rows[0].Cells[0].Style.Add("BACKGROUND-COLOR","yellow");
								otblitm.Rows[0].Cells[0].Style.Add("HEIGHT","20px");
								

								otblitm.Rows[0].Cells[0].InnerText=Convert.ToDouble(dr[NMes].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);
								otblitm.Rows[0].Cells[1].Style.Add("width","50%");
								otblitm.Rows[0].Cells[1].InnerText="0";
								otblitm.Rows[0].Cells[1].Style.Add("BORDER-LEFT","gainsboro 1px solid");
								otblitm.Rows[0].Cells[1].Style.Add("BACKGROUND-COLOR","lightgoldenrodyellow");
								otblitm.Rows[0].Cells[1].Style.Add("HEIGHT","20px");
								e.Item.Cells[c].Controls.Add(otblitm);
							}
						}

						if(Helper.MesInTrimestre(hNombreImgTrim.Value,idMes))
						{
							e.Item.Cells[c].Style.Add("display","block");
							if(idMes==Utilitario.Helper.GestionFinanciera.Params.IdMes){
								if(e.Item.ItemType == ListItemType.Header)
								{
									NMes = Helper.ObtenerNombreMes(Utilitario.Helper.GestionFinanciera.Params.IdMes,Enumerados.TipoDatoMes.NombreCompleto);
									HtmlTable otblHead = Helper.CrearHtmlTabla(2,2,true);
									otblHead.Style.Add("height","20");
									otblHead.Attributes.Add("align","left");
									otblHead.Border=0;
									otblHead.Style.Add("width","350px");
									otblHead.Rows[0].Cells[0].ColSpan=2;
									otblHead.Rows[0].Cells[0].NoWrap=true;
									otblHead.Rows[0].Cells[0].InnerText="MES EVALUADO";
									otblHead.Rows[0].Cells[0].Style.Add("BORDER-BOTTOM","#ffffff 1px solid");
									otblHead.Rows[0].Cells[1].Style.Add("display","none");
									otblHead.Rows[1].Cells[0].InnerText=NMes;
									otblHead.Rows[1].Cells[0].Style.Add("width","150px");
									otblHead.Rows[1].Cells[0].NoWrap=true;
									otblHead.Rows[1].Cells[1].InnerHtml=NMes + "<br>" + (Utilitario.Helper.GestionFinanciera.Params.Periodo-1).ToString();
									otblHead.Rows[1].Cells[1].Style.Add("BORDER-LEFT","#ffffff 1px solid");
									otblHead.Rows[1].Cells[1].NoWrap=true;
									otblHead.Style.Add("width","100%");
									otblHead.Rows[1].Cells[1].Style.Add("width","150px");
									e.Item.Cells[c].Controls.Add(otblHead);
								}
							}
						}
						

						idMes++;
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
							e.Item.Cells[c].Style.Add("BACKGROUND-COLOR","gainsboro");
						}
					}
					
				}

				if(e.Item.ItemType == ListItemType.Header)
				{
					e.Item.Cells[0].Visible=false;//para combinar la columna 1


				}
				else if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
				{
					DataRowView drv = (DataRowView)e.Item.DataItem;
					DataRow dr = drv.Row;			

					e.Item.Cells[0].Controls.Add((new EstadoFinancieroCorporativo()).ConfigConceptos(e,Utilitario.Helper.GestionFinanciera.Params.IdObjeto));
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

		/*-----------------------------------------------------------------------------------------------------------------------------------*/

	}
}
