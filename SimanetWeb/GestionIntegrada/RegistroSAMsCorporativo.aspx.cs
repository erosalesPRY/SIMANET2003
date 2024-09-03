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
using SIMA.Controladoras.General;


namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for RegistroSAMsCorporativo.
	/// </summary>
	public class RegistroSAMsCorporativo : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList ddlDestino;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlNorma;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlTableCell ContextReponsable;
		protected System.Web.UI.HtmlControls.HtmlTable tblFiltroCombo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPrivilegio;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdSAM;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdDestino;
		protected System.Web.UI.WebControls.Literal ltlMensaje;



		const string GRILLAVACIA="No existen datos";
		const string KEYQIDSAM = "IdSAM";
		const string KEYQPERIODO = "Periodo";
		const string KEYQTIPONOR ="IDTIPONOR";
		const string KEYTIPOAUD  ="IDTIPOAUD";
		const string KEYAUTORIZA  ="AUTORIZA";
		const string KEYQSUPNOSUP = "SupNoSup";
		
		int Privilegio=0;
		string htmlNNota="";
		int TotMsg =0;

		const string URLDETALLE="/GestionIntegrada/DetalleSolicituddeAcciondeMejora.aspx?";
		const int IDTABLANORMAISO=522;
		DataTable dtGeneral=null;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Integrada: CosultaySeguimientodeSolicituddeAcciondeMejora.aspx", this.ToString(),"Se ha consultado el listado de SAM del Centro que pertenece el usuario para su control y Seguimiento",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina();
					this.LlenarDatos();
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
			this.ddlDestino.SelectedIndexChanged += new System.EventHandler(this.ddlDestino_SelectedIndexChanged);
			this.ddlNorma.SelectedIndexChanged += new System.EventHandler(this.ddlNorma_SelectedIndexChanged);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add RegistroSAMsCorporativo.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add RegistroSAMsCorporativo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarDatos()
		{
			Session["dtSAMCorp"] = this.ObtenerDatos();
		}

		private DataTable ObtenerDatos()
		{
			string Filtro="";
			if(Page.Request.Params[KEYQTIPONOR]!=null)
			{
				//Oculta la visualizacion de los controles de filtro adicional
				this.tblFiltroCombo.Attributes["style"]="display:none";

				DataTable dt =  (new CSolicituddeAcciondeMejora()).ListarDatosGrillaCorporativo("0",0,Convert.ToInt32(Page.Request.Params[KEYQTIPONOR]),Convert.ToInt32(this.ddlDestino.SelectedValue));
				DataView dv = dt.DefaultView;
					
				if((Page.Request.Params[KEYTIPOAUD]!=null)&&(Page.Request.Params[KEYTIPOAUD].Length>0))
				{
					if((Page.Request.Params[KEYQPERIODO]!=null)&&(Page.Request.Params[KEYQPERIODO].Length>0))
					{
						Filtro = "IdTipoAuditoria="+ Page.Request.Params[KEYTIPOAUD].ToString() + " and Periodo="+ Page.Request.Params[KEYQPERIODO].ToString() ;	
					}
					else
					{
						Filtro = "IdTipoAuditoria="+ Page.Request.Params[KEYTIPOAUD].ToString() ;
						if(Page.Request.Params[KEYQSUPNOSUP]!=null)
						{
							Filtro = "IdTipoAuditoria="+ Page.Request.Params[KEYTIPOAUD].ToString() +" and IdEstado= " + Page.Request.Params[KEYQSUPNOSUP];
						}
						
						
					}
					if((Page.Request.Params[KEYQSUPNOSUP]!=null)&&(Page.Request.Params[KEYQSUPNOSUP].Length>0))
					{
						string SupNoSup =Page.Request.Params[KEYQSUPNOSUP];
						Filtro=Filtro + " and IdEstado= " + SupNoSup;
					}
					dv.RowFilter=Filtro;

					return Helper.DataViewTODataTable(dv);

				}
				else
				{
					//return (new CSolicituddeAcciondeMejora()).ListarDatosGrilla("0",0,Convert.ToInt32(Page.Request.Params[KEYQTIPONOR]),Convert.ToInt32(this.ddlDestino.SelectedValue));
					if(Page.Request.Params[KEYQSUPNOSUP]!=null)
					{
						Filtro="IdEstado=" + Page.Request.Params[KEYQSUPNOSUP];
						dv.RowFilter=Filtro;
					}

					return Helper.DataViewTODataTable(dv);
				}
			}
			else
			{
				return (new CSolicituddeAcciondeMejora()).ListarDatosGrillaCorporativo("0",0,Convert.ToInt32(this.ddlNorma.SelectedValue),Convert.ToInt32(this.ddlDestino.SelectedValue));
			}
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
			DataTable dt = (new CTablaTablas()).ListaItemTablas(IDTABLANORMAISO);
			DataView dv = dt.DefaultView;
			dv.RowFilter="var2='0'";
			this.ddlNorma.DataSource= Helper.DataViewTODataTable(dv);
			this.ddlNorma.DataTextField="abrev";
			this.ddlNorma.DataValueField="codigo";
			this.ddlNorma.DataBind();
			this.ddlNorma.Items.Insert(0,(new ListItem("Todos...","0")));

			
			ddlDestino.DataSource = (new CSAMDestino()).ListarAreadeCentrosPorUsuarioCoorporativo();
			ddlDestino.DataTextField="NombreAreayCentro";
			ddlDestino.DataValueField="IdArea";
			ddlDestino.DataBind();
			this.ddlDestino.Items.Insert(0,(new ListItem("Todos...","0")));
		}

	

		public void LlenarJScript()
		{
			// TODO:  Add RegistroSAMsCorporativo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add RegistroSAMsCorporativo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add RegistroSAMsCorporativo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add RegistroSAMsCorporativo.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add RegistroSAMsCorporativo.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add RegistroSAMsCorporativo.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
					
				//Norma ISO
				htmlNNota="";
				string HTMLIso=strNormaISO(dr["IdSAM"].ToString(),dr["CodigoSAM"].ToString());
				//e.Item.Cells[4].Controls.Add((new LiteralControl(HTMLIso)));
				System.Web.UI.HtmlControls.HtmlTable mHtmlTable = Helper.CrearHtmlTabla(2,1,true);
				mHtmlTable.Border=0;
			
				/*if(htmlNNota.Length>0)
				{
					mHtmlTable.Rows[0].Cells[0].Controls.Add((new LiteralControl(htmlNNota)));
					mHtmlTable.Rows[0].Cells[0].Attributes.Add("align","right");
				}*/


				if(TotMsg>0)
				{
					string strMsgTot = "<div class='msg'><div style='HEIGHT: 8px'></div><SPAN class='msgTotal'>"  + TotMsg + "</SPAN>" + ((htmlNNota.Length>0)?htmlNNota +"</div>":"</div>");
					mHtmlTable.Rows[0].Cells[0].Controls.Add((new LiteralControl(strMsgTot)));
					mHtmlTable.Rows[0].Cells[0].Attributes.Add("align","right");
				}



				mHtmlTable.Rows[1].Cells[0].Controls.Add((new LiteralControl(HTMLIso)));

				

				e.Item.Cells[4].Controls.Add(mHtmlTable);



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
						//TBLItem.Rows[0].Cells[0].Attributes["title"] = dri["EmailFecha"].ToString();
						TBLItem.Rows[0].Cells[0].Attributes["noWrap"] ="noWrap";
						TBLItem.Rows[0].Cells[0].Style.Add("cursor","hand");
						TBLItem.Rows[0].Cells[0].Style["COLOR"]="blue";
						TBLItem.Rows[0].Cells[0].Style["TEXT-DECORATION"]="underline";
						TBLItem.Rows[0].Cells[0].Attributes["DESCRIPCION"]= dri["DescripcionAccionInmediata"].ToString();
						TBLItem.Rows[0].Cells[0].Attributes["onclick"]="grid_onClick(this,'" + Privilegio.ToString() + "');ControldeAcciones(this,'" + dr["IdSAM"].ToString() + "','" + dr["IdUsuarioRegistro"].ToString() + "','" + dri["IdDestino"].ToString() + "','" + dri["Nombrearea"].ToString() + "','" + dri["EmailFecha"].ToString() + "')";

						HtmlImage oImg = new HtmlImage();
						oImg.Style.Add("cursor", "hand");
						//oImg.Src =  Page.Request.ApplicationPath +"/imagenes/EvaluacionPersonal/" + ((Convert.ToInt32(dri["IdEstado"].ToString())==1)?"Nota.png":"Cerrado.png");
						oImg.Src =  ((Convert.ToInt32(dri["IdEstado"].ToString())==1)?Page.Request.ApplicationPath +"/imagenes/Filtro/Eliminar.png":Page.Request.ApplicationPath +"/imagenes/EvaluacionPersonal/Cerrado.png") ;
						oImg.ID="imgStatus"+dri["IdDestino"].ToString();
						//oImg.Alt=dri["FechaVB"].ToString();
						TBLItem.Rows[0].Attributes["FECHACIERRE"]=dri["FechaVB"].ToString();
						//TBLItem.Border=4;

						if(dri["IdEstado"].ToString()!="2")
						{
							if((Convert.ToInt32(dri["Verificado"])==0)&&(Convert.ToInt32(dri["Contestada"])>0))
							{
								oImg.Src =  Page.Request.ApplicationPath +"/imagenes/Navegador/Respondido.png";
								oImg.Alt="Respondido";

								//Crear la nueva imagen para imprimir la sam por cada destino
							
								TBLItem.Rows[0].Cells[1].Controls.Add(CrearImgPrint(dr["IdSam"].ToString(),dri["IdDestino"].ToString()));

							}
							else if(Convert.ToInt32(dri["Verificado"])>=1)
							{
								oImg.Src =  Page.Request.ApplicationPath +"/imagenes/Navegador/EnVerificacion.png";
								oImg.Alt="En proceso de verificación";
								
								//	oImg.Attributes["onclick"]="EliminarDestinatario(this,'" + dri["IdDestino"].ToString() + "')";
								TBLItem.Rows[0].Cells[1].Controls.Add(CrearImgPrint(dr["IdSam"].ToString(),dri["IdDestino"].ToString()));
							}
							else
							{
								oImg.Attributes["onclick"]="EliminarDestinatario(this,'" + dri["IdDestino"].ToString() + "')";
							}
						}


						TBLItem.Rows[0].Cells[2].Controls.Add(oImg);
						//e.Item.Cells[4].Controls.Add(TBLItem);
						otblDestino.Rows[2].Cells[0].Controls.Add(TBLItem);

					}
					//e.Item.Cells[4].Text =dr["DescripcionHallazgo"].ToString(); 
					string Comilla="\"";

					string Html="<img src='" + Page.Request.ApplicationPath +"/imagenes/Navegador/txt.png' onclick=" + Comilla + "VerDetalleHallazgo(this,'" +  dr["IdSAM"].ToString() + "')" + Comilla + ">";
					e.Item.Cells[5].Text=((dr["DescripcionHallazgo"].ToString().Length>170)? dr["DescripcionHallazgo"].ToString().Substring(0,170)+ Html:dr["DescripcionHallazgo"].ToString()); 
				}
				catch(Exception ex)
				{
					int p =0;
					p++;
				}
				

				//IMG imgEliminarSAM 
				Image oImgs= (Image) e.Item.Cells[9].FindControl("imgEliminarSAM");
				if(dr["IdEstado"].ToString()=="2")
				{
					oImgs.ImageUrl =  Page.Request.ApplicationPath +"/imagenes/EvaluacionPersonal/Cerrado.png";
				}
				else
				{
					oImgs.Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()]="EliminarSAM(this.parentNode.parentNode,'" + dr["IdSAM"].ToString() + "','" + Privilegio.ToString() + "');";
					oImgs.Style.Add("display","none");
				}

				Helper.UIControls.DataGrid.CHiperLink((DataGrid)sender, e.Item.Cells[0],"HistorialIrAdelantePersonalizado('hGridPaginaSort;hGridPagina')"
					,Helper.Response.Redirec( Page.Request.ApplicationPath + URLDETALLE + KEYQIDSAM + Utilitario.Constantes.SIGNOIGUAL + dr["IdSAM"].ToString() 
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModoPagina.C.ToString(),false));

				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,"grid_onClick(this,'" + Privilegio.ToString() + "');");

				//Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");

			}				
		}



		public string strNormaISO(string IdSAM)
		{
			return strNormaISO(IdSAM,"");
		}
		public string strNormaISO(string IdSAM,string CodigoSAM)
		{
			int NroMsgEnvia=0;
			/*Metodo tambien usado en el form: AdministrarRescepcionSolicitudeAcciondeMejora.aspx*/
			Privilegio=0;
			string strISO="";
			DataTable dtISO= (new CSAMiso()).ListarTodosGrilla(IdSAM,"0");
			TotMsg=0;
			if(dtISO!=null)
			{
				int Pos=20;
				foreach(DataRow drISO in dtISO.Rows)
				{
					if((drISO["idNormaISO"].ToString()!="4")&&(drISO["CLAUSULA"].ToString().Trim().Length>0)&&(drISO["CLAUSULA"].ToString()!="0"))
					{
						strISO +=  drISO["IdSAMISO"].ToString() + '*' +  drISO["idNormaISO"].ToString() + "*"+ drISO["Clausula"].ToString() + "*"+ drISO["NORMAISO_ABREV"]+'@';
					}
					else
					{
						strISO +=  drISO["IdSAMISO"].ToString() + '*' +  drISO["idNormaISO"].ToString() + "*"+ drISO["Clausula"].ToString() + "*" + drISO["NORMAISO_ABREV"] +'@';
					}
					if(drISO["Privilegio"].ToString()=="1"){Privilegio=1;}

					NroMsgEnvia = NroMsgEnvia+ Convert.ToInt32(drISO["NMsg"].ToString());

					
					int NroTotalMSG =(new CSAMNota()).ObtenerNroNotasNuevas(drISO["IdSAMISO"].ToString(),CNetAccessControl.GetIdUser(),99);

					TotMsg =TotMsg +NroTotalMSG;

					int NroMsg = (new CSAMNota()).ObtenerNroNotasNuevas(drISO["IdSAMISO"].ToString(),CNetAccessControl.GetIdUser(),1);
					if(NroMsg>0)
					{
						htmlNNota = htmlNNota + "<SPAN class='msgNoRead' style='LEFT:" + Pos + "px'>" + NroMsg.ToString() + "</SPAN>";
						Pos=Pos+20;
					}	



				}
			}
			string HTMLIso="";
			if(CodigoSAM.Length==0)
			{
				HTMLIso=(new DetalleSolicituddeAcciondeMejora()).ObtenerLstISOText(strISO);
			}
			else
			{
				HTMLIso=(new DetalleSolicituddeAcciondeMejora()).ObtenerLstISOText(strISO,NroMsgEnvia,"CargarNotas(this,'" + CodigoSAM + "');");
			}
			
			return HTMLIso;
		}

		HtmlImage  CrearImgPrint(string IdSAM,string IDDestino)
		{
			HtmlImage oImgPrint = new HtmlImage();
			oImgPrint.Style.Add("cursor", "hand");
			oImgPrint.Src =  Page.Request.ApplicationPath +"/imagenes/tree/print.gif";
			//oImgPrint.Attributes["onclick"]=Helper.MostrarDatosEnCajaTexto("hIdSAM",dr["IdSam"].ToString())+";" + Helper.MostrarDatosEnCajaTexto("hIdDestino",dri["IdDestino"].ToString())+"(function(){__doPostBack('ibtnImprimir','');})();";
			oImgPrint.Attributes["onclick"]=Helper.HistorialIrAdelantePersonalizado("ddlDestino","ddlNorma","hGridPaginaSort","hGridPagina") + Helper.MostrarDatosEnCajaTexto("hIdSAM",IdSAM)+";" + Helper.MostrarDatosEnCajaTexto("hIdDestino",IDDestino)+"(function(){__doPostBack('ibtnImprimir','');})();";
			
			return oImgPrint;
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
			this.ddlDestino.SelectedIndex=0;
			this.ddlNorma.SelectedIndex=0;
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}
		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			(new AdministrarRescepcionSolicitudeAcciondeMejora()).VistaPreviaSAM(this.hIdSAM.Value,this.hIdDestino.Value); 
		}

		private void ddlNorma_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}

		private void ddlDestino_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			DataTable dt = (DataTable)Session["dtSAMCorp"];
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(dt
				,Utilitario.Constantes.SIGNOASTERISCO + "AreaRemitente;Area del remitente"
				,"CodigoSAM;Codigo"
				,Utilitario.Constantes.SIGNOASTERISCO + "EstadoSAM;ESTADO"
				,Utilitario.Constantes.SIGNOASTERISCO + "NombreLugarDetectado;Lugar detectado"
				,Utilitario.Constantes.SIGNOASTERISCO + "FuenteReporte;Fuente del reporte"
				,Utilitario.Constantes.SIGNOASTERISCO + "NombreTipoAccion;Tipo de Acción");

			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}


	}
}
