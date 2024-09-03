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
using SIMA.Controladoras.General;

namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for AdministrarRescepcionSolicitudeAcciondeMejora.
	/// </summary>
	public class AdministrarRescepcionSolicitudeAcciondeMejora : System.Web.UI.Page,IPaginaBase
	{

		const string GRILLAVACIA="No existen datos";
		const string KEYQIDSAM = "IdSAM";
		const string URLDETALLE="/GestionIntegrada/DetalleSolicituddeAcciondeMejora.aspx?";
		const string URLCAUSARAIZ="AdministrarCausaRaiz.aspx?";
		const string URLDETALLE2="DetalleSolicituddeAcciondeMejora.aspx?";
		const string KEYQIDDESTINO="IdDestino";
		const int IDTABLANORMAISO=522;

		public string IdSam{
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
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.ImageButton btnCausaRaiz;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdDestino;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdSAM;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdRow;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidUsuarioEmite;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAccionInmediata;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdArea;
		protected System.Web.UI.WebControls.Button btnEnviarRptSAM;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList ddlNorma;
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
					this.LlenarCombos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Integrada: Administrar recepción de SAMs", this.ToString(),"Se consultó El Listado de SAMs emitidas al area donde se origino el hallazgo.",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.ddlNorma.SelectedIndexChanged += new System.EventHandler(this.ddlNorma_SelectedIndexChanged);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemCreated);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.btnEnviarRptSAM.Click += new System.EventHandler(this.btnEnviarRptSAM_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarRescepcionSolicitudeAcciondeMejora.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarRescepcionSolicitudeAcciondeMejora.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return (new CSAMDestino()).ListarTodosGrillaA(Convert.ToInt32(this.ddlNorma.SelectedValue));
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
			DataTable dt = (new CTablaTablas()).ListaItemTablas(IDTABLANORMAISO);
			DataView dv = dt.DefaultView;
			dv.RowFilter="var2='0'";
			this.ddlNorma.DataSource= Helper.DataViewTODataTable(dv);
			this.ddlNorma.DataTextField="abrev";
			this.ddlNorma.DataValueField="codigo";
			this.ddlNorma.DataBind();
			this.ddlNorma.Items.Insert(0,(new ListItem("Todos...","0")));
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarRescepcionSolicitudeAcciondeMejora.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			btnEnviarRptSAM.Style.Add("DISPLAY","NONE");
			this.ibtnImprimir.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.HistorialIrAdelantePersonalizado("ddlNorma","hIdRow","hGridPaginaSort","hGridPagina","hIdSAM","hIdDestino","hidUsuarioEmite","hIdAccionInmediata","hIdArea")+Helper.PopupDeEspera());
			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarRescepcionSolicitudeAcciondeMejora.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarRescepcionSolicitudeAcciondeMejora.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarRescepcionSolicitudeAcciondeMejora.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarRescepcionSolicitudeAcciondeMejora.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarRescepcionSolicitudeAcciondeMejora.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.UIControls.DataGrid.CHiperLink((DataGrid)sender, e.Item.Cells[0],"HistorialIrAdelantePersonalizado('ddlNorma;hGridPaginaSort;hGridPagina')"
					,Helper.Response.Redirec( Page.Request.ApplicationPath + URLDETALLE + KEYQIDSAM + Utilitario.Constantes.SIGNOIGUAL + dr["IdSAM"].ToString() 
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModoPagina.C.ToString(),false));



				//Hallazgo=dr["DescripcionHallazgo"].ToString();

				Label lblEmite =  (Label)e.Item.Cells[3].FindControl("lblEmite");
				lblEmite.Text = dr["AreaEmisor"].ToString();
				HtmlTable otblDestino =(HtmlTable) e.Item.Cells[3].FindControl("tblER");
				otblDestino.Rows[2].Cells[0].Attributes.Add("Class","BaseItemInGrid");
				otblDestino.Rows[2].Cells[0].InnerText = dr["NombreAreaDestino"].ToString();


				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hIdDestino",dr["IdDestino"].ToString())
																,Helper.MostrarDatosEnCajaTexto("hIdSAM",dr["IdSAM"].ToString())
																,Helper.MostrarDatosEnCajaTexto("hIdAccionInmediata",dr["DescripcionAccionInmediata"].ToString())
																,Helper.MostrarDatosEnCajaTexto("hIdArea",dr["IdArea"].ToString())
																,"jNet.get('hIdRow').value=this.rowIndex;jNet.get('hidUsuarioEmite').value = '" + dr["UsuarioEmisor"].ToString() + "'");



				//Obtiene la Norma ISO
				string HTMLIso=(new CosultaySeguimientodeSolicituddeAcciondeMejora()).strNormaISO(dr["IdSAM"].ToString());
				e.Item.Cells[4].Controls.Add((new LiteralControl(HTMLIso)));


				string Comilla="\"";
				string Html="<img src='" + Page.Request.ApplicationPath +"/imagenes/Navegador/txt.png' onclick=" + Comilla + "VerDetalleHallazgo(this,'" +  dr["IdSAM"].ToString() + "')" + Comilla + ">";
				e.Item.Cells[5].Text=((dr["DescripcionHallazgo"].ToString().Length>170)? dr["DescripcionHallazgo"].ToString().Substring(0,170)+ Html:dr["DescripcionHallazgo"].ToString()); 


				//e.Item.Attributes[Utilitario.Enumerados.EventosJavaScript.Ondblclick.ToString()]="ListarResponsable('" + dr["IdSAM"].ToString() + "');";


				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");

				TextBox txt  = (TextBox) e.Item.Cells[7].FindControl("txtAccionInmediata");
				txt.Text = dr["DescripcionAccionInmediata"].ToString();
				txt.Attributes["onblur"]="ModificarACCSAM(this)";
				txt.Attributes["OLD"]=dr["DescripcionAccionInmediata"].ToString();
				txt.Attributes["IDDESTINO"]=dr["IdDestino"].ToString();
				
				string IdEstado=dr["IdEstado"].ToString();
				//btnEnviar


				//Envio de Correo
				HtmlTable otblEnvio = (HtmlTable)e.Item.Cells[8].FindControl("tblEnviado");
				otblEnvio.Style.Add("display","none");
				if(dr["EMailEnviado"].ToString()!="0")
				{
					otblEnvio.Style.Add("display","block");
					Label oLblEnviado = (Label)e.Item.Cells[8].FindControl("LblEnviado");
					oLblEnviado.Text = dr["EMailEnviado"].ToString();
				}


				Image oIMgSend  = (Image) e.Item.Cells[8].FindControl("btnEnviar");
				if(IdEstado=="2")
				{
					oIMgSend.ImageUrl=Page.Request.ApplicationPath +"/imagenes/EvaluacionPersonal/Cerrado.png";
					oIMgSend.Width=15;
					oIMgSend.Height=20;
					oIMgSend.ToolTip="Cerrado";
					otblEnvio.Style.Add("display","none");
				}
				else
				{
					oIMgSend.Attributes[Utilitario.Enumerados.EventosJavaScript.Ondblclick.ToString()]= "EnviarEmailRpt('" + dr["IdSAM"].ToString() + "','" + dr["IdDestino"].ToString() + "');";
				}

			//Listado de Causa Raiz
			DataTable dtc = (new CCausaRaiz()).ListarTodosGrilla(dr["IdDestino"].ToString());
				int idxc =1;
				if(dtc!=null){
					//Crear los grupos
					DataTable dtd = Helper.SelectDistinct(dtc,"IdGrupoCausaRaizAccion");
						
						foreach(DataRow drc in dtd.Select("IdGrupoCausaRaizAccion <> '0'"))
						{
							HtmlTable TBLGRP =  Helper.CrearHtmlTabla(1,1,true);
							TBLGRP.Style["MARGIN"]="2px";
							//BORDER-BOTTOM: dimgray 1px solid; BORDER-LEFT: dimgray 1px solid; BORDER-TOP: dimgray 1px solid; BORDER-RIGHT: dimgray 1px solid
							TBLGRP.Style["BORDER"]="dimgray 1px solid;";
							TBLGRP.ID = drc["IdGrupoCausaRaizAccion"].ToString();
							TBLGRP.Border=0;
							TBLGRP.Attributes["width"] ="250px";

							/*HtmlImage oImg = new HtmlImage();
							oImg.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]="AgruparCR();";
							oImg.Src = Page.Request.ApplicationPath + "/Imagenes/Navegador/ibtnAgruparCR.gif";
							TBLGRP.Rows[0].Cells[0].Controls.Add(oImg);
							TBLGRP.Rows[0].Cells[0].Align = "right";
							*/
							
							e.Item.Cells[7].Controls.Add(TBLGRP);
							foreach(DataRow dr1 in dtc.Select("IdGrupoCausaRaizAccion='" + drc["IdGrupoCausaRaizAccion"].ToString() + "'"))
							{
								TBLGRP.Rows[0].Cells[0].Controls.Add(CrearTblCausaRaiz(dr1,idxc,dr));
								idxc++;
							}

							
						}
						idxc=1;
						foreach(DataRow dr1 in dtc.Select("IdGrupoCausaRaizAccion='0'"))
						{
							e.Item.Cells[7].Controls.Add(CrearTblCausaRaiz(dr1,idxc,dr));
							idxc++;
						}
				}
			}				
		}

		HtmlTable CrearTblCausaRaiz(DataRow drc,int idxc,DataRow dr){

			HtmlTable TBLItem =  Helper.CrearHtmlTabla(1,4,true);
			TBLItem.Border=0;
			TBLItem.Attributes["width"] ="250px";
			TBLItem.Attributes["IDCAUSARAIZ"] =drc["IdCausaRaiz"].ToString();
						
			TBLItem.Attributes["IDGRPCR"] =drc["IdGrupoCausaRaizAccion"].ToString();

			TBLItem.Attributes["IDESTADO"] =drc["IdEstado"].ToString();
			TBLItem.Attributes["CONACCION"] =drc["ConAccion"].ToString();

			TBLItem.CellSpacing=0;
			TBLItem.Style["MARGIN-TOP"]="2px";
			TBLItem.Attributes["class"] ="BaseItemInGrid";

			TBLItem.Rows[0].Cells[0].InnerText = idxc.ToString();
			TBLItem.Rows[0].Cells[0].Style["TEXT-DECORATION"]="underline";
			TBLItem.Rows[0].Cells[0].Style["CURSOR"]="Hand";
			TBLItem.Rows[0].Cells[0].Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()]="AbrirVentanaCausaRaiz('" + drc["IdCausaRaiz"].ToString() + "','" + dr["UsuarioEmisor"].ToString() + "',SIMA.Utilitario.Enumerados.ModoPagina.M)";
			//TBLItem.Rows[0].Cells[0].Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()]="AbrirVentanaCausaRaiz('" + drc["IdGrupoCausaRaizAccion"].ToString() + "','" + dr["UsuarioEmisor"].ToString() + "',SIMA.Utilitario.Enumerados.ModoPagina.M)";
			TBLItem.Rows[0].Cells[0].Attributes["width"] ="80px";

			TBLItem.Rows[0].Cells[1].InnerText = ((drc["Descripcion"].ToString().Length>100)?drc["Descripcion"].ToString().Substring(0,100)+"...":drc["Descripcion"].ToString());
			TBLItem.Rows[0].Cells[1].Attributes["width"] ="100%";


			HtmlImage oImg = new HtmlImage();
			oImg.Style.Add("cursor", "hand");
			oImg.Src =  Page.Request.ApplicationPath +"/imagenes/Navegador/Anexar.png";
			oImg.Width=15;
			oImg.Height=15;
			oImg.Style.Add("display","NONE");

			TBLItem.Rows[0].Cells[2].Controls.Add(oImg);
			oImg.Attributes["onclick"]="Anexar(this,'" + drc["IdCausaRaiz"].ToString() + "')";

			oImg = new HtmlImage();
			oImg.Style.Add("cursor", "hand");
			oImg.Src =  Page.Request.ApplicationPath +"/imagenes/Filtro/Eliminar.png";

			if(drc["IdEstadoGrupoCausaRaizAccion"].ToString()!="2")
			{
				oImg.Attributes["onclick"]="Eliminar(this,'" + drc["IdCausaRaiz"].ToString() + "')";
			}
			else
			{
				oImg.Src =  Page.Request.ApplicationPath +"/imagenes/EvaluacionPersonal/Cerrado.png";
			}
			TBLItem.Rows[0].Cells[3].Controls.Add(oImg);
			if(drc["ConAccion"].ToString()!="0")
			{
				TBLItem.Rows[0].Cells[1].Style.Add("cursor","hand");
				TBLItem.Rows[0].Cells[1].Style.Add("COLOR","#0000ff");
				TBLItem.Rows[0].Cells[1].Style.Add("TEXT-DECORATION","underline");
				TBLItem.Rows[0].Cells[1].Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()] = "jNet.get('hidUsuarioEmite').value ='" + dr["UsuarioEmisor"].ToString() + "' ; jNet.get('hIdSAM').value = '" + dr["IdSAM"].ToString() + "';jNet.get('hIdDestino').value = '"+ dr["IdDestino"].ToString() +"';jNet.get('hIdAccionInmediata').value='"+ dr["DescripcionAccionInmediata"].ToString() + "';PopupDeEspera();Redireccionar('" + drc["IdGrupoCausaRaizAccion"].ToString() + "','" + drc["IdEstadoGrupoCausaRaizAccion"].ToString() + "','" + drc["IdCausaRaiz"].ToString() + "',SIMA.Utilitario.Enumerados.ModoPagina.M);";
			}
			return TBLItem;
		}
		
		
		
		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos(),"CodigoSAM;Codigo"
																,Utilitario.Constantes.SIGNOASTERISCO + "NombreDetectadoEn;Detectado en:"
																,"AreaEmisor;Emitido por:"
																,"DescripcionHallazgo;Descripcion del hallazgo"
																,Utilitario.Constantes.SIGNOASTERISCO + "NombreAccionCorrectiva;Tipo de Accion"
																);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));

		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
			this.ddlNorma.SelectedIndex=0;
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
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

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		public string ObtenerLstISOText(string IdSAM)
		{
			string tbld="";
			DataTable dt=(new CSAMiso()).ListarTodosGrilla(IdSAM,"0");
			if(dt!=null){
				foreach(DataRow dr in dt.Rows){
					if((dr["Clausula"].ToString()!="0")&& (dr["Clausula"].ToString().Length>0))
					{
						tbld += "<tr><td style='PADDING-LEFT: 5px;PADDING-RIGHT: 5px;' noWrap class='BaseItemInGrid'>"+ dr["NormaISO"].ToString() + "</td></tr>";
					}
				}
			}
			tbld = "<table >"+ tbld .ToString() + "</table>";
			return tbld;
		}


		private void btnEnviarRptSAM_Click(object sender, System.EventArgs e)
		{
			string LstEmails ="";
			DataTable dt =(new CSAMDestino()).ListarResponsableOGI(this.hIdSAM.Value,this.hIdDestino.Value);
			if(dt!=null)
			{
				foreach(DataRow dr in dt.Rows)
				{
					LstEmails = LstEmails + dr["EmailResponsable"].ToString()+";";
				}
				LstEmails=((LstEmails.Length>0)?LstEmails.Substring(0,LstEmails.Length-1):LstEmails);

				SolicitudAccionMejoraBE oSolicitudAccionMejoraBE = (SolicitudAccionMejoraBE)(new CSolicituddeAcciondeMejora()).ListarDetalle(this.hIdSAM.Value,0);
				string HtmlEmail = Helper.Archivo.Leer(Helper.Archivo.RutaArchivoCorreo + "SAMRespondida.aspx");
			
				HtmlEmail = HtmlEmail.Replace("[QUIENENVIA]",CNetAccessControl.GetUserApellidosNombres());
				HtmlEmail = HtmlEmail.Replace("[IMG]", System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.RUTAFOTOSP].ToString() + CNetAccessControl.GetUserNroDocIdent() + ".jpg");
				HtmlEmail = HtmlEmail.Replace("[FECHA]", oSolicitudAccionMejoraBE.FechaEmision.ToShortDateString());
				HtmlEmail = HtmlEmail.Replace("[ACCION]",oSolicitudAccionMejoraBE.NombreTipoAccion);
				HtmlEmail = HtmlEmail.Replace("[DETECTADO]",oSolicitudAccionMejoraBE.NombreDetectadoEn);
				HtmlEmail = HtmlEmail.Replace("[DESCRIPCION]",oSolicitudAccionMejoraBE.DescripcionHallazgo);
				HtmlEmail = HtmlEmail.Replace("[SAM]",oSolicitudAccionMejoraBE.CodigoSAM);
				HtmlEmail = HtmlEmail.Replace("[LSNORMA]",ObtenerLstISOText(this.hIdSAM.Value));

				Helper.EnviarCorreo(CNetAccessControl.GetUserName(),"RESPUESTA DE SAM",LstEmails,HtmlEmail);
				//Actualiza contador de envio de respuesta
				(new CSAMDestino()).ActEnvioCorreo(this.hIdDestino.Value);
				this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
			}
		}


		string Hallazgo="";
		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			/*if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{

				DataGridItem di = new DataGridItem(e.Item.ItemIndex+1,0,e.Item.ItemType);
				di.CssClass="ItemGrillaText";
				TableCell tc = new TableCell();
				tc.ColumnSpan=grid.Columns.Count;
				tc.HorizontalAlign= System.Web.UI.WebControls.HorizontalAlign.Left;
				tc.Controls.Add(new LiteralControl(Hallazgo));
				di.Cells.Add(tc);


				DataGrid dg = (DataGrid)sender;
				Table t = (Table)dg.Controls[0];
			
				t.Rows.Add(di);
				
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				DataGridItem di = new DataGridItem(e.Item.ItemIndex+1,0,e.Item.ItemType);
				di.CssClass="ItemGrillaText";
				TableCell tc = new TableCell();
				tc.ColumnSpan=grid.Columns.Count;
				tc.HorizontalAlign= System.Web.UI.WebControls.HorizontalAlign.Left;
				tc.Controls.Add(new LiteralControl(Hallazgo));
				di.Cells.Add(tc);


				DataGrid dg = (DataGrid)sender;
				Table t = (Table)dg.Controls[0];
				t.Rows.Add(di);
				
         
			}*/
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			VistaPreviaSAM(this.IdSam,this.IdDestino);

		}

		public void VistaPreviaSAM(string pIdSAM,string pIdDestino){
			DataTable dtGen;

			DataSet ds = new DataSet("sw");
			DataTable dt1 =  Helper.DataViewTODataTable((new CSolicituddeAcciondeMejora()).ListarReporte(pIdSAM,pIdDestino).DefaultView);
			dt1.TableName="OGIuspNTADReporteSAM;1";
			ds.Tables.Add(dt1);

			dtGen=(new CCausaRaiz()).ListarReporte(pIdSAM,pIdDestino);
			
			if(dtGen!=null)
			{
				DataTable dt2 = Helper.DataViewTODataTable(dtGen.DefaultView);
				dt2.TableName="OGIuspNTADReporteSAMCausaRaiz;1";
				ds.Tables.Add(dt2);
			}
			else
			{
				//dtGen  = new DataTable("OGIuspNTADReporteSAMCausaRaiz;1");
				dtGen  =ObtenerEstructura(1);
				dtGen.TableName="OGIuspNTADReporteSAMCausaRaiz;1";
				ds.Tables.Add(dtGen);
			}

			dtGen=(new CSAMCausaRaizAccion()).ListarReporte(pIdSAM,pIdDestino);
			
			if(dtGen!=null)
			{
				DataTable dt3 = Helper.DataViewTODataTable(dtGen.DefaultView);
				dt3.TableName="OGIuspNTADReporteSAMAcciones;1";
				ds.Tables.Add(Helper.DataViewTODataTable(dt3.DefaultView));
			}
			else
			{
				dtGen  =ObtenerEstructura(2);
				dtGen.TableName="OGIuspNTADReporteSAMAcciones;1";
				//dtGen  = new DataTable("OGIuspNTADReporteSAMAcciones;1");
				ds.Tables.Add(dtGen);

			}

			dtGen=(new CSAMAccionVerificacion()).ListarReporte(pIdSAM,pIdDestino);
			if(dtGen!=null)
			{
				DataTable dt4 = Helper.DataViewTODataTable(dtGen.DefaultView);
				dt4.TableName="OGIuspNTADReporteSAMVerificaciones;1";
				ds.Tables.Add(Helper.DataViewTODataTable(dt4.DefaultView));
			}
			else
			{
				//dtGen  = new DataTable("OGIuspNTADReporteSAMVerificaciones;1");
				dtGen  =ObtenerEstructura(3);
				dtGen.TableName="OGIuspNTADReporteSAMVerificaciones;1";
				ds.Tables.Add(dtGen);

			}

			Helper.EjecutarReporte(@"C:\SimanetReportes\OGI\","rptSAM.rpt",ds,false);
		}


		DataTable ObtenerEstructura(int NroRep){
			DataTable dtx=new DataTable();
			switch(NroRep){
				case 1:
					dtx.Columns.Add("NroIdCausaRaiz",System.Type.GetType("System.Int32"));
					dtx.Columns.Add("NroCausaRaizAccion",System.Type.GetType("System.Int32"));
					dtx.Columns.Add("IdSam",System.Type.GetType("System.String"));
					dtx.Columns.Add("IdDestino",System.Type.GetType("System.String"));
					dtx.Columns.Add("IdCausaRaiz",System.Type.GetType("System.String"));
					dtx.Columns.Add("Descripcion",System.Type.GetType("System.String"));
					break;
				case 2:
					dtx.Columns.Add("NroIdDestino",System.Type.GetType("System.Int32"));
					dtx.Columns.Add("NroIdCausaRaiz",System.Type.GetType("System.Int32"));
					dtx.Columns.Add("IdSam",System.Type.GetType("System.String"));
					dtx.Columns.Add("IdDestino",System.Type.GetType("System.String"));
					dtx.Columns.Add("IdCausaRaiz",System.Type.GetType("System.String"));
					dtx.Columns.Add("IdAccion",System.Type.GetType("System.String"));
					dtx.Columns.Add("PlazoEjecucion",System.Type.GetType("System.String"));
					dtx.Columns.Add("Descripcion",System.Type.GetType("System.String"));
					dtx.Columns.Add("ApellidosyNombres",System.Type.GetType("System.String"));

					break;
				case 3:
					dtx.Columns.Add("IdCausaRaizAccion",System.Type.GetType("System.Int32"));
					dtx.Columns.Add("Nro",System.Type.GetType("System.Int32"));
					dtx.Columns.Add("IdSam",System.Type.GetType("System.String"));
					dtx.Columns.Add("IdDestino",System.Type.GetType("System.String"));
					dtx.Columns.Add("IdCausaAccion",System.Type.GetType("System.String"));
					dtx.Columns.Add("IdCausaRaiz",System.Type.GetType("System.String"));
					dtx.Columns.Add("IdAccion",System.Type.GetType("System.String"));
					dtx.Columns.Add("IdVerificacion",System.Type.GetType("System.String"));
					dtx.Columns.Add("Descripcion",System.Type.GetType("System.String"));
					dtx.Columns.Add("Fecha",System.Type.GetType("System.String"));
					dtx.Columns.Add("AccionTomada",System.Type.GetType("System.String"));
					dtx.Columns.Add("Observacion",System.Type.GetType("System.String"));
					break;

			}
			return dtx;
		}

		private void ddlNorma_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));

		}

	}
}
