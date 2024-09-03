using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.GestionIntegrada;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using SIMA.EntidadesNegocio.GestionIntegrada;
namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for ConsultarListadoSAMsparaVB.
	/// </summary>
	public class ConsultarListadoSAMsparaVB : System.Web.UI.Page,IPaginaBase
	{

		const string GRILLAVACIA="No existen datos";
		const string KEYQIDSAM = "IdSAM";
		const string URLDETALLE="/GestionIntegrada/DetalleSolicituddeAcciondeMejora.aspx?";
		const string URLCAUSARAIZ="AdministrarCausaRaiz.aspx?";
		const string URLDETALLE2="DetalleSolicituddeAcciondeMejora.aspx?";
		const string KEYQIDDESTINO="IdDestino";

		public string IdSam
		{
			get{return hIdSAM.Value;}
		}
		public string IdDestino
		{
			get{return hIdDestino.Value;}
		}



		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdRow;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdSAM;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdDestino;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidUsuarioEmite;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAccionInmediata;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdArea;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					this.LlenarJScript();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Integrada: Listado de SAMs Cerradas para VB", this.ToString(),"Se consultó El Listado de SAMs cerradas disponibles para sus VB.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina();
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));

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
					string msg = oException.Message.ToString();
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
			// TODO:  Add ConsultarListadoSAMsparaVB.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarListadoSAMsparaVB.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return (new CSolicituddeAcciondeMejora()).ListarSamsParaVB();
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();

			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.Sort         = columnaOrdenar;
				dv.RowFilter    = Utilitario.Helper.ObtenerFiltro();
				grid.DataSource = dv;

				grid.CurrentPageIndex     = indicePagina;
				this.lblResultado.Visible = false;

				/*grid.Columns[POSICIONFOOTERTOTAL].FooterText     = TEXTOFOOTERTOTAL;
				grid.Columns[POSICIONFOOTERTOTAL+1].FooterText   = dv.Count.ToString() + " de " + dt.Rows.Count.ToString();
				*/
			}
			else
			{
				grid.DataSource = dt;
				this.lblResultado.Visible = true;
				this.lblResultado.Text    = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}		
		
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarListadoSAMsparaVB.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarListadoSAMsparaVB.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnImprimir.Style.Add("display","none");
			this.ibtnImprimir.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","hGridPagina","hIdSAM","hIdDestino")+ Helper.PopupDeEspera());
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarListadoSAMsparaVB.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarListadoSAMsparaVB.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarListadoSAMsparaVB.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarListadoSAMsparaVB.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarListadoSAMsparaVB.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Label lblEmite =  (Label)e.Item.Cells[3].FindControl("lblEmite");
				lblEmite.Text = dr["AreaRemitente"].ToString();
				HtmlTable otblDestino =(HtmlTable) e.Item.Cells[3].FindControl("tblER");

				try
				{
					foreach(DataRow dri in (new CSAMDestino()).ListarTodosGrilla(dr["IdSAM"].ToString(),"0").Rows)
					{
						HtmlTable TBLItem =  Helper.CrearHtmlTabla(1,3,true);
						TBLItem.Border=0;						
						TBLItem.Attributes["class"] ="BaseItemInGrid";
						TBLItem.Style["MARGIN"]="2px";
						TBLItem.Rows[0].Cells[0].InnerText = dri["NombreArea"].ToString();
						TBLItem.Rows[0].Cells[0].Attributes["noWrap"] ="noWrap";
						TBLItem.Rows[0].Cells[0].Style.Add("cursor","hand");
						TBLItem.Rows[0].Cells[0].Style["COLOR"]="blue";
						TBLItem.Rows[0].Cells[0].Style["TEXT-DECORATION"]="underline";
						TBLItem.Rows[0].Cells[0].Attributes["DESCRIPCION"]= dri["DescripcionAccionInmediata"].ToString();
						TBLItem.Rows[0].Cells[0].Attributes["onclick"]="VerReponsableDeArea('" + dri["IdArea"].ToString() + "')";

						HtmlInputCheckBox ochkVB = new HtmlInputCheckBox();
						ochkVB.Checked = ((dri["vb"].ToString()=="0")?false:true);
						ochkVB.Attributes["onClick"]="VistoBueno(this,'" + dr["IdSAM"].ToString() +"','" + dri["IdDestino"].ToString() + "');";


						TBLItem.Rows[0].Cells[2].Controls.Add(ochkVB);
						//e.Item.Cells[4].Controls.Add(TBLItem);
						otblDestino.Rows[2].Cells[0].Controls.Add(TBLItem);


						//if((Convert.ToInt32(dri["Verificado"])==0)&&(Convert.ToInt32(dri["Contestada"])>0))
						{
							HtmlImage oImg = new HtmlImage();
							oImg.Style.Add("cursor", "hand");
							oImg.Src =  Page.Request.ApplicationPath +"/imagenes/Navegador/Respondido.png";
							oImg.Alt="Respondido";

							//Crear la nueva imagen para imprimir la sam por cada destino
							
							TBLItem.Rows[0].Cells[1].Controls.Add(CrearImgPrint(dr["IdSam"].ToString(),dri["IdDestino"].ToString()));

						}


					}
					//e.Item.Cells[4].Text =dr["DescripcionHallazgo"].ToString(); 
					string Comilla="\"";

					string Html="<img src='" + Page.Request.ApplicationPath +"/imagenes/Navegador/txt.png' onclick=" + Comilla + "VerDetalleHallazgo(this,'" +  dr["IdSAM"].ToString() + "')" + Comilla + ">";
					e.Item.Cells[5].Text=((dr["DescripcionHallazgo"].ToString().Length>170)? dr["DescripcionHallazgo"].ToString().Substring(0,170)+ Html:dr["DescripcionHallazgo"].ToString()); 
				}
				catch(Exception ex)
				{

				}


				/*Obtener la Norma ISO*/
				string htmlNNota="";
				string strISO="";
				int TotMsg =0;
				int NroMsgEnvia=0;

				DataTable dtISO= (new CSAMiso()).ListarTodosGrilla(dr["IdSAM"].ToString(),"0");
				if(dtISO!=null)
				{
					int Pos=20;

					foreach(DataRow drISO in dtISO.Rows)
					{
						string idSamISO=drISO["IdSAMISO"].ToString();
						if((drISO["idNormaISO"].ToString()!="4")&&(drISO["CLAUSULA"].ToString().Trim().Length>0)&&(drISO["CLAUSULA"].ToString()!="0"))
						{
							strISO +=  idSamISO + '*' +  drISO["idNormaISO"].ToString() + "*"+ drISO["Clausula"].ToString() + "*"+ drISO["NORMAISO_ABREV"]+'@';
						}
						else
						{
							strISO +=  idSamISO + '*' +  drISO["idNormaISO"].ToString() + "*"+ drISO["Clausula"].ToString() + "*" + drISO["NORMAISO_ABREV"] +'@';
						}
						
						int NroTotalMSG =(new CSAMNota()).ObtenerNroNotasNuevas(idSamISO,CNetAccessControl.GetIdUser(),99);

						TotMsg =TotMsg +NroTotalMSG;

						int NroMsg = (new CSAMNota()).ObtenerNroNotasNuevas(idSamISO,CNetAccessControl.GetIdUser(),1);
						if(NroMsg>0)
						{
							htmlNNota = htmlNNota + "<SPAN class='msgNoRead' style='LEFT:" + Pos + "px'>" + NroMsg.ToString() + "</SPAN>";
							Pos=Pos+20;
						}	
						NroMsgEnvia=NroMsgEnvia+Convert.ToInt32(drISO["NMsg"].ToString());
					}
				}
				string HTMLIso=(new DetalleSolicituddeAcciondeMejora()).ObtenerLstISOText(strISO,NroMsgEnvia,"CargarNotas(this,'" + dr["CodigoSAM"].ToString() + "');");

				//otblDestino.Rows[4].Cells[0].Controls.Add((new LiteralControl(HTMLIso)));

				System.Web.UI.HtmlControls.HtmlTable mHtmlTable = Helper.CrearHtmlTabla(2,1,true);

				mHtmlTable.Border=0;
			
				if(TotMsg>0)
				{
					string strMsgTot = "<div class='msg'><div style='HEIGHT: 8px'></div><SPAN class='msgTotal'>"  + TotMsg + "</SPAN>" + ((htmlNNota.Length>0)?htmlNNota +"</div>":"</div>");
					mHtmlTable.Rows[0].Cells[0].Controls.Add((new LiteralControl(strMsgTot)));
					mHtmlTable.Rows[0].Cells[0].Attributes.Add("align","right");
				}

				mHtmlTable.Rows[1].Cells[0].Controls.Add((new LiteralControl(HTMLIso)));

				
				
				e.Item.Cells[4].Controls.Add(mHtmlTable);

				//e.Item.Cells[4].Controls.Add((new LiteralControl(HTMLIso)));

				//IMG imgEliminarSAM 
				Image oImgs= (Image) e.Item.Cells[9].FindControl("imgEliminarSAM");
				if(dr["IdEstado"].ToString()=="2")
				{
					oImgs.ImageUrl =  Page.Request.ApplicationPath +"/imagenes/EvaluacionPersonal/Cerrado.png";
				}
				/*else
				{
					oImgs.Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()]="EliminarSAM(this.parentNode.parentNode,'" + dr["IdSAM"].ToString() + "');";
				}*/



				Helper.UIControls.DataGrid.CHiperLink((DataGrid)sender, e.Item.Cells[0],"HistorialIrAdelantePersonalizado('hGridPaginaSort;hGridPagina')"
					,Helper.Response.Redirec( Page.Request.ApplicationPath + URLDETALLE + KEYQIDSAM + Utilitario.Constantes.SIGNOIGUAL + dr["IdSAM"].ToString() 
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModoPagina.C.ToString(),false));

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}	
		}


		HtmlImage  CrearImgPrint(string IdSAM,string IDDestino)
		{
			HtmlImage oImgPrint = new HtmlImage();
			oImgPrint.Style.Add("cursor", "hand");
			oImgPrint.Src =  Page.Request.ApplicationPath +"/imagenes/tree/print.gif";
			//oImgPrint.Attributes["onclick"]=Helper.MostrarDatosEnCajaTexto("hIdSAM",dr["IdSam"].ToString())+";" + Helper.MostrarDatosEnCajaTexto("hIdDestino",dri["IdDestino"].ToString())+"(function(){__doPostBack('ibtnImprimir','');})();";
			oImgPrint.Attributes["onclick"]=Helper.MostrarDatosEnCajaTexto("hIdSAM",IdSAM)+";" + Helper.MostrarDatosEnCajaTexto("hIdDestino",IDDestino)  + ";"+ Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","hGridPagina","hIdSAM","hIdDestino")+ Helper.PopupDeEspera() +"(function(){__doPostBack('ibtnImprimir','');})();";
			return oImgPrint;
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
	
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro("AreaRemitente;Area del remitente","CodigoSAM;Codigo","NombreLugarDetectado;Lugar detectado");
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			(new AdministrarRescepcionSolicitudeAcciondeMejora()).VistaPreviaSAM(this.hIdSAM.Value,this.hIdDestino.Value); 
		}

		
	}
}
