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
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.GestionIntegrada;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Configuration;


namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for AdministrarAccionesCP.
	/// </summary>
	public class AdministrarAccionesCP : System.Web.UI.Page,IPaginaBase
	{
		#region Atributos
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtTipoAuditoria;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtAuditoria;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtTipoAccion;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtDetectadoEn;
		protected System.Web.UI.WebControls.Image imgClose;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtNroRegistro;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtFechaEmision;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtNDiasTrans;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtFechaCaducidad;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtAccionesInmediatas;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnSubir;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdEstado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdEstadoACAP;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdRowGrid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdRowGridACAP;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAccion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreArchivo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hRutaHTTP;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAccionAnexo;
		#endregion

		protected System.Web.UI.HtmlControls.HtmlInputFile FUFile;
		protected projDataGridWeb.DataGridWeb gridACAP;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellLstCRTMP;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellLstCR;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellLstCausaRaiz;
	
		const string KEYQIGRUPOCRA= "IdGRPCRA";
		const string KEYQIDESTDOGRPCR= "IdEstGRPCR";
		const string KEYQLSTCR = "LstCR";
		const string KEYQIDDESTINO="IdDestino";
		const string KEYQIDSAM = "IdSAM";
		const string KEYQIDUSUARIOEMITE= "IdUsuarioEmite";
		const string KEYQIDACCIONINMEDIATA="AccInmediata";

		private string AccionInmediata
		{
			get{return Helper.HttpUtility.HtmlDecode(Page.Request.Params[KEYQIDACCIONINMEDIATA].ToString());}
		}

		private int IdUsuarioEmite
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDUSUARIOEMITE]);}
		}
		private int IdEstadoGrupoCausaRaiz
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDESTDOGRPCR]);}
		}
		private string IdSolicitudAcciondeMejora
		{
			get{return Page.Request.Params[KEYQIDSAM];}
		}
		private string IdDestino
		{
			get{return Page.Request.Params[KEYQIDDESTINO];}
		}
		private string IdGrupoCausaRaizAccion
		{
			get{return Page.Request.Params[KEYQIGRUPOCRA];}
		}
		private string LstCausaRaiz
		{
			get{return Page.Request.Params[KEYQLSTCR];}
		}

		private string OGIRutaLocal
		{
			get{return ConfigurationSettings.AppSettings["RutaLocalOGI"].ToString();}
		}
		private string OGIRutaHttp
		{
			get{return ConfigurationSettings.AppSettings["RutaHTTPOGI"].ToString();}
		}

		bool EnebledReadOnly = false;

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
					this.LlenarDatos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Becados", this.ToString(),"Se consultó El Listado de las Capacitaciones en el Extranjero.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina();
					this.LlenarGrillaOrdenamientoPaginacion("", 0);

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
		
		string strLstCausaRaiz="";
		void ListarCausaRaiz()
		{
			DataTable dtc = (new CSAMCausaRaizAccion()).ListarTodosGrilla(this.IdGrupoCausaRaizAccion,this.LstCausaRaiz);
			int idxc =1;
			if(dtc!=null)
			{
				foreach(DataRow drc in dtc.Rows)
				{
					strLstCausaRaiz +=drc["IdCausaRaiz"].ToString()+"@" ;

					HtmlTable TBLItem =  Helper.CrearHtmlTabla(1,3,true);
					TBLItem.Border=0;
					TBLItem.Attributes["width"] ="100%";
					TBLItem.Attributes["IDCAUSARAIZ"] =drc["IdCausaRaiz"].ToString();
					TBLItem.Attributes["IDGRUPOCR"] =drc["IdGrupoCausaRaizAccion"].ToString();
					TBLItem.Attributes["IDDESTINO"] =this.IdDestino;

					TBLItem.CellSpacing=0;
					TBLItem.Style["MARGIN-TOP"]="2px";
					TBLItem.Attributes["class"] ="BaseItemInGrid";

					TBLItem.Rows[0].Cells[0].InnerText = idxc.ToString();
					TBLItem.Rows[0].Cells[0].Style["TEXT-DECORATION"]="underline";
					TBLItem.Rows[0].Cells[0].Style["CURSOR"]="Hand";
					//TBLItem.Rows[0].Cells[0].Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()]="window.alert(); AbrirVentanaCausaRaiz('" + drc["IdCausaRaiz"].ToString() + "',SIMA.Utilitario.Enumerados.ModoPagina.M)";
					TBLItem.Rows[0].Cells[0].Attributes["width"] ="80px";

					TBLItem.Rows[0].Cells[1].InnerText = drc["Descripcion"].ToString();
					//TBLItem.Rows[0].Cells[1].Attributes["noWrap"] ="noWrap";
					TBLItem.Rows[0].Cells[1].Attributes["width"] ="100%";

					HtmlImage oImg = new HtmlImage();
					oImg.Style.Add("cursor", "hand");
					oImg.Src =  Page.Request.ApplicationPath +"/imagenes/Filtro/Eliminar.png";
					//oImg.Attributes["onclick"]="Eliminar(this);";
					//if(drc["IdEstado"].ToString()!="2")
					if(this.IdEstadoGrupoCausaRaiz!=2)
					{
						//oImg.Attributes["onclick"]="Eliminar(this,'" + drc["IdCausaRaiz"].ToString() + "')";
						oImg.Attributes["onclick"]="Eliminar(this);";
					}
					else
					{
						oImg.Src =  Page.Request.ApplicationPath +"/imagenes/EvaluacionPersonal/Cerrado.png";

					}
					TBLItem.Rows[0].Cells[2].Controls.Add(oImg);

					//e.Item.Cells[6].Controls.Add(TBLItem);
					this.CellLstCR.Controls.Add(TBLItem);

					idxc++;

				}
				strLstCausaRaiz = strLstCausaRaiz.Substring(0,strLstCausaRaiz.Length-1);
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
			this.gridACAP.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridACAP_ItemDataBound);
			this.gridACAP.SelectedIndexChanged += new System.EventHandler(this.gridACAP_SelectedIndexChanged);
			this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarAccionesCP.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarAccionesCP.LlenarGrillaOrdenamiento implementation
		}
		
		DataTable ObtenerDatos()
		{
			return (new CSAMAccion()).ListarTodosGrilla(this.strLstCausaRaiz,this.IdDestino);
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.Sort         = columnaOrdenar;
				dv.RowFilter    = ((this.IdEstadoGrupoCausaRaiz==2)?"IdAccion <> '9'":"");
				gridACAP.DataSource = dv;
				gridACAP.CurrentPageIndex     = indicePagina;
			}
			else
			{
				gridACAP.DataSource = dt;
			}
			
			try
			{
				gridACAP.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				gridACAP.CurrentPageIndex = 0;
				gridACAP.DataBind();
			}						
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarAccionesCP.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			//SolicitudAccionMejoraBE oSolicitudAccionMejoraBE = (SolicitudAccionMejoraBE) (new CSolicituddeAcciondeMejora()).ListarDetalle(this.IdSolicitudAcciondeMejora);
			SolicitudAccionMejoraBE oSolicitudAccionMejoraBE = (SolicitudAccionMejoraBE) (new CSolicituddeAcciondeMejora()).ListarDetalle(this.IdSolicitudAcciondeMejora,this.IdUsuarioEmite);
			if(oSolicitudAccionMejoraBE!=null)
			{
				this.txtTipoAuditoria.Text=oSolicitudAccionMejoraBE.NombreTipoAuditoria;
				this.txtAuditoria.Text =oSolicitudAccionMejoraBE.NombreAuditoria;
				this.txtNroRegistro.Text=oSolicitudAccionMejoraBE.CodigoSAM;
				this.txtFechaEmision.Text=oSolicitudAccionMejoraBE.FechaEmision.ToShortDateString();
				this.txtTipoAccion.Text=oSolicitudAccionMejoraBE.NombreTipoAccion;
				this.txtDetectadoEn.Text=oSolicitudAccionMejoraBE.NombreDetectadoEn;
				this.txtDescripcion.Text=oSolicitudAccionMejoraBE.DescripcionHallazgo;
				this.txtNDiasTrans.Text = oSolicitudAccionMejoraBE.NroDiasTrasncurridos.ToString();
				this.txtFechaCaducidad.Text = oSolicitudAccionMejoraBE.FechaCaducidad.ToShortDateString();
				this.txtAccionesInmediatas.Text = this.AccionInmediata;//oSolicitudAccionMejoraBE.DescripcionAccionInmediata;
				this.txtAccionesInmediatas.Attributes["OLD"] = oSolicitudAccionMejoraBE.DescripcionAccionInmediata;
				this.hIdEstado.Value = oSolicitudAccionMejoraBE.IdEstado.ToString();
				if(oSolicitudAccionMejoraBE.IdEstado!=2)
				{
					imgClose.Style["display"]="none";
				}
				ListarCausaRaiz();
				CargarCausaRaizDisponibles();

				hRutaHTTP.Value = this.OGIRutaHttp;
				EnebledReadOnly  =((this.IdEstadoGrupoCausaRaiz==1)?false:true);
			}
		}

		private void CargarCausaRaizDisponibles(){
			DataTable dtc = (new CCausaRaiz()).ListarTodosGrilla(this.IdDestino);
			int idxc =1;
			if(dtc!=null)
			{
				foreach(DataRow drc in dtc.Rows)
				{
					HtmlTable TBLItem =  Helper.CrearHtmlTabla(1,3,true);
					TBLItem.Border=0;
					TBLItem.Attributes["width"] ="250px";
					TBLItem.Attributes["IDCAUSARAIZ"] =drc["IdCausaRaiz"].ToString();
					TBLItem.Attributes["IDESTADO"] =drc["IdEstado"].ToString();
					TBLItem.Attributes["IDGRPCR"] =drc["IdGrupoCausaRaizAccion"].ToString();
					TBLItem.Attributes["CONACCION"] =drc["ConAccion"].ToString();

					TBLItem.CellSpacing=0;
					TBLItem.Style["MARGIN-TOP"]="2px";
					TBLItem.Attributes["class"] ="BaseItemInGrid";

					TBLItem.Rows[0].Cells[0].InnerText = idxc.ToString();
					TBLItem.Rows[0].Cells[0].Style["TEXT-DECORATION"]="underline";
					TBLItem.Rows[0].Cells[0].Style["CURSOR"]="Hand";
					TBLItem.Rows[0].Cells[0].Attributes["width"] ="80px";

					TBLItem.Rows[0].Cells[1].InnerText = drc["Descripcion"].ToString();
					TBLItem.Rows[0].Cells[1].Attributes["width"] ="100%";

					HtmlImage oImg = new HtmlImage();
					oImg.Style.Add("cursor", "hand");
					oImg.Src =  Page.Request.ApplicationPath +"/imagenes/Filtro/Eliminar.png";
					if(drc["IdEstado"].ToString()!="2")
					{
						oImg.Attributes["onclick"]="Eliminar(this,'" + drc["IdCausaRaiz"].ToString() + "')";
					}
					else
					{
						oImg.Src =  Page.Request.ApplicationPath +"/imagenes/EvaluacionPersonal/Cerrado.png";
					}
					TBLItem.Rows[0].Cells[2].Controls.Add(oImg);
					CellLstCausaRaiz.Controls.Add(TBLItem);
					if(drc["ConAccion"].ToString()!="0")
					{
						TBLItem.Rows[0].Cells[1].Style.Add("cursor","hand");
						TBLItem.Rows[0].Cells[1].Style.Add("COLOR","#0000ff");
						TBLItem.Rows[0].Cells[1].Style.Add("TEXT-DECORATION","underline");
						TBLItem.Rows[0].Cells[1].Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()] = "Redireccionar('" + drc["IdCausaRaiz"].ToString() + "');";
					}

					idxc++;

				}
			}
		}

		public void LlenarJScript()
		{
			btnSubir.Style["display"]="none";
			this.txtAccionesInmediatas.Attributes["onblur"]="ModificarACCSAM(this)";
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarAccionesCP.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarAccionesCP.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarAccionesCP.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarAccionesCP.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarAccionesCP.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void gridACAP_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			e.Item.Cells[1].Style.Add("display","none");

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				string Modo = "M";
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.UIControls.DataGrid.CHiperLink((DataGrid)sender, e.Item.Cells[0],"");
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,"jNet.get('hIdRowGridACAP').value=this.rowIndex;jNet.get('hIdAccion').value=jNet.get(this).attr('IDACCION');");

				e.Item.Attributes["MODO"]="M";
				e.Item.Attributes["IDACCION"]=dr["IdAccion"].ToString();

				//Envio de Correo
				HtmlTable otblEnvio = (HtmlTable)e.Item.Cells[5].FindControl("tblEnviado");
				otblEnvio.Style.Add("display","none");
				if(dr["EmailEnviado"].ToString()!="0")
				{
					otblEnvio.Style.Add("display","block");
					Label oLblEnviado = (Label)e.Item.Cells[5].FindControl("LblEnviado");
					oLblEnviado.Text = dr["EmailEnviado"].ToString();
				}




				DropDownList ddl = (DropDownList) e.Item.Cells[1].FindControl("ddlTipoAccion");
				ddl.DataSource = (new CTablaTablas()).ListaTodosCombo(521);
				ddl.DataTextField="var1";
				ddl.DataValueField="codigo";
				ddl.DataBind();
				ddl.Items.Insert(0,(new ListItem("[Seleccionar..]","0")));
				ListItem lItem = ddl.Items.FindByValue(dr["IdTipoAccion"].ToString());
				if(lItem!=null){lItem.Selected=true;}
				ddl.Enabled = !EnebledReadOnly;
				ddl.Attributes["OLD"]=dr["IdTipoAccion"].ToString();
				ddl.Attributes[Utilitario.Enumerados.EventosJavaScript.OnChange.ToString()]="Agregar(this);";		

				TextBox tb = (TextBox)e.Item.Cells[2].FindControl("txtAccion");
				tb.Text = dr["Descripcion"].ToString();
				tb.Attributes["OLD"]=dr["Descripcion"].ToString();
				tb.Attributes[Utilitario.Enumerados.EventosJavaScript.OnBlur.ToString()]="Agregar(this);";		
				tb.Enabled= !EnebledReadOnly;

				tb = (TextBox)e.Item.Cells[3].FindControl("txtFechaPlazo");
				tb.Text = dr["PlazoEjecucion"].ToString();
				tb.Attributes["OLD"]=dr["PlazoEjecucion"].ToString();
				tb.Attributes[Utilitario.Enumerados.EventosJavaScript.OnBlur.ToString()]="Agregar(this);";
				tb.Enabled=  !EnebledReadOnly;

				e.Item.Cells[4].Style["PADDING-TOP"]="5px";
				e.Item.Cells[4].Attributes["Align"]="left";
				e.Item.Cells[4].Attributes["vAlign"]="top";
				e.Item.Cells[4].Attributes["OLD"]=dr["IdPersonal"].ToString();
				e.Item.Cells[4].Attributes["value"]=dr["IdPersonal"].ToString();
				e.Item.Cells[4].Attributes["Nombre"]=dr["ApellidosyNombres"].ToString();

				if((dr["IdAccion"].ToString()=="9")||(EnebledReadOnly==true))
				{
					Modo = "N";
					e.Item.Attributes["MODO"]="N";
					Image oimg =(Image) e.Item.Cells[7].FindControl("imgEliminar2");
					oimg.Style["display"]="none";

					Image oimgEnvia =(Image) e.Item.Cells[6].FindControl("btnEnviar");
					oimgEnvia.Style["display"]="none";
				}
								
				int RowSpan = Convert.ToInt32(dr["RowSpan"].ToString());
				if(RowSpan!=0)
				{
					e.Item.Cells[0].RowSpan=RowSpan;
					e.Item.Cells[0].Style["border"]="1px dotted  royalblue";
					HtmlTable ohtmlTable = Helper.CrearHtmlTabla(2,1,true);
					HtmlImage oImg = new HtmlImage();
					oImg.Src = Page.Request.ApplicationPath + "/imagenes/Navegador/aviso.gif";
					oImg.Attributes["onclick"]="MostrarVerificaciones('"+ dr["IdGrupoAccionVerificacion"].ToString() +"');";
					ohtmlTable.Rows[0].Cells[0].Controls.Add(oImg);
					ohtmlTable.Rows[1].Cells[0].InnerText = e.Item.Cells[0].Text;
					e.Item.Cells[0].Controls.Add(ohtmlTable);
				}
				else if(dr["IdGrupoAccionVerificacion"].ToString()!="0"){
					e.Item.Cells[0].Style["display"]="none";
				}
				string RegistroBE = "var RegistroBE = {IDACCION:'" + dr["IdAccion"].ToString() + "',MODO:'" + Modo + "',TIPOACCION:'" + dr["IdTipoAccion"].ToString()  + "',ACCION:'" + dr["Descripcion"].ToString() + "',FECHA:'" + dr["PlazoEjecucion"].ToString() + "',IDRESPONSABLE:'" + dr["IdPersonal"].ToString() + "',EMAIL:'" + dr["IdPersonal"].ToString() + "'};";
				e.Item.Attributes["REGBE"] = RegistroBE;
			}
		}

		private void gridACAP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnSubir_Click(object sender, System.EventArgs e)
		{
			string []arrNombre = this.hNombreArchivo.Value.ToString().Split('.');
			string Ext =arrNombre[arrNombre.Length-1];
			string SoloNombre = this.hNombreArchivo.Value.ToString().Substring(0,this.hNombreArchivo.Value.ToString().Length-(Ext.Length+1));
			string NombreArchivo =  "AA_" + hIdAccionAnexo.Value +'_'+ SoloNombre;
			Helper.SubirArchivo(this.FUFile,this.OGIRutaLocal,NombreArchivo);

			LlenarDatos();
			this.LlenarGrillaOrdenamientoPaginacion("",0);
		}
		
	}
}
