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
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionIntegrada;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionIntegrada;
using NetAccessControl;
using System.Configuration;
using System.IO;
using System.Web.Mail;

namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for DetalleSolicituddeAcciondeMejora.
	/// </summary>
	public class DetalleSolicituddeAcciondeMejora : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles

		#endregion

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtNroRegistro;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlDetectadoEn;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hLstClausulas;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hLstDetinatario;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DropDownList ddlTipoAuditoria;
		protected System.Web.UI.WebControls.TextBox txtBuscar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hLstAnexo;
		protected System.Web.UI.WebControls.Button btnSubir;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hRutaHTTP;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdSAM;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreArchivoUP;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAuditoria;
		protected System.Web.UI.HtmlControls.HtmlTableCell cellListDestino;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlTableCell cellListAnexos;
		protected System.Web.UI.HtmlControls.HtmlInputFile FUFile;
		protected System.Web.UI.WebControls.TextBox calFechaEmite;
		protected System.Web.UI.WebControls.DropDownList ddlTipoAccion;
		protected System.Web.UI.WebControls.DropDownList ddlAuditoria;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HEst_Prc;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hRutaFotos;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtArticulo;
		protected System.Web.UI.HtmlControls.HtmlTable tblBtns;


		private string OGIRutaLocalTMP
		{
			get{return ConfigurationSettings.AppSettings["RutaLocalOGITMP"].ToString();}
		}
		private string OGIRutaHttp
		{
			get{return ConfigurationSettings.AppSettings["RutaHTTPOGI"].ToString();}
		}
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			//OGIuspNTADConsultarSAMRecibidas
			if(!Page.IsPostBack)
			{
				try
				{

					Session["Grabando"]="0";
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarCombos();
					this.CargarModoPagina();
					this.LlenarGrilla();
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
					Helper.MsgBox(oSIMAExcepcionDominio.Mensaje.ToString());					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			
			this.grid.DataSource=(new CSAMiso()).ListarTodosGrilla(Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora,"0");
			this.grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleSolicituddeAcciondeMejora.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleSolicituddeAcciondeMejora.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.LlenarTipoAuditoria();
			this.LlenarTipoAccion();
			this.LlenarDetectadoEn();
		}
		void LlenarTipoAuditoria(){
			ddlTipoAuditoria.DataSource= (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TablaTipodeAuditoria));
			ddlTipoAuditoria.DataTextField=Enumerados.ColumnasTablasTablas.Var1.ToString();
			ddlTipoAuditoria.DataValueField=Enumerados.ColumnasTablasTablas.Codigo.ToString();
			ddlTipoAuditoria.DataBind();
			ddlTipoAuditoria.Items.Insert(0,new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,"0")); 
		}
		void LlenarTipoAccion()
		{
			ddlTipoAccion.DataSource= (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TablaTipodeAccion));
			ddlTipoAccion.DataTextField=Enumerados.ColumnasTablasTablas.Var1.ToString();
			ddlTipoAccion.DataValueField=Enumerados.ColumnasTablasTablas.Codigo.ToString();
			ddlTipoAccion.DataBind();
			ddlTipoAccion.Items.Insert(0,new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,"0")); 

		}
		void LlenarDetectadoEn()
		{
			ddlDetectadoEn.DataSource= (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TablaDetectadoEn));
			ddlDetectadoEn.DataTextField=Enumerados.ColumnasTablasTablas.Var1.ToString();
			ddlDetectadoEn.DataValueField=Enumerados.ColumnasTablasTablas.Codigo.ToString();
			ddlDetectadoEn.DataBind();
			ddlDetectadoEn.Items.Insert(0,new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,"0")); 
		}

		public void LlenarDatos()
		{
			//this.hRutaFotos.Value=Utilitario.Helper.ObtenerRutaFotoPersonal();
			hRutaHTTP.Value = this.OGIRutaHttp;
			try
			{
				this.hIdSAM.Value = Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora;
			}
			catch(Exception ex){}
		}

		public void LlenarJScript()
		{
			btnSubir.Style["display"]="none";
			this.ddlTipoAuditoria.Attributes[Utilitario.Constantes.EVENTOONCHANGE.ToString()]="LlenarAuditoria();";
			this.ddlAuditoria.Attributes[Utilitario.Constantes.EVENTOONCHANGE.ToString()]="ObtenerIDAuditoria();";
			this.ibtnAceptar.Attributes[Utilitario.Constantes.EVENTOCLICK.ToString()]="PopupDeEspera();";
			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleSolicituddeAcciondeMejora.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleSolicituddeAcciondeMejora.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleSolicituddeAcciondeMejora.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleSolicituddeAcciondeMejora.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleSolicituddeAcciondeMejora.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			SolicitudAccionMejoraBE oSolicitudAccionMejoraBE = new SolicitudAccionMejoraBE();
			oSolicitudAccionMejoraBE.FechaEmision = Convert.ToDateTime(this.calFechaEmite.Text);
			oSolicitudAccionMejoraBE.DescripcionHallazgo = this.txtDescripcion.Text;
			oSolicitudAccionMejoraBE.IdTipoAccion = Convert.ToInt32(this.ddlTipoAccion.SelectedValue);
			oSolicitudAccionMejoraBE.IdDetectadoEn = Convert.ToInt32(this.ddlDetectadoEn.SelectedValue);
			oSolicitudAccionMejoraBE.IdTipoAuditoria = Convert.ToInt32(this.ddlTipoAuditoria.SelectedValue);
			oSolicitudAccionMejoraBE.IdAuditoria = (((oSolicitudAccionMejoraBE.IdTipoAuditoria==2)||(oSolicitudAccionMejoraBE.IdTipoAuditoria==3))?Convert.ToInt32(this.hIdAuditoria.Value):0);

			string HtmlEmail = Helper.Archivo.Leer(Helper.Archivo.RutaArchivoCorreo + "SAMGenerada.aspx");
			
			HtmlEmail = HtmlEmail.Replace("[QUIENENVIA]",CNetAccessControl.GetUserApellidosNombres());
			HtmlEmail = HtmlEmail.Replace("[IMG]", System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.RUTAFOTOSP].ToString() + CNetAccessControl.GetUserNroDocIdent() + ".jpg");
			HtmlEmail = HtmlEmail.Replace("[FECHA]",this.calFechaEmite.Text);
			HtmlEmail = HtmlEmail.Replace("[ACCION]",this.ddlTipoAccion.Items[this.ddlTipoAccion.SelectedIndex].Text);
			HtmlEmail = HtmlEmail.Replace("[DETECTADO]",this.ddlDetectadoEn.Items[this.ddlDetectadoEn.SelectedIndex].Text);
			HtmlEmail = HtmlEmail.Replace("[DESCRIPCION]",this.txtDescripcion.Text);
			HtmlEmail = HtmlEmail.Replace("[LSTDESTINOS]",ObtenerLstDestinatarioText());
			HtmlEmail = HtmlEmail.Replace("[LSNORMA]",ObtenerLstISOText(this.hLstClausulas.Value.ToString()));

			string LstValores=(new CSolicituddeAcciondeMejora()).InsertarSAM(oSolicitudAccionMejoraBE,ObtenerLstISO(),ObtenerLstDestinatario(),ObtenerLstAnexos());
			if(LstValores.Length>0)
			{
				EmailSendOGIAPP(LstValores,HtmlEmail);

			}
			ltlMensaje.Text = Helper.MensajeRetornoAlert();
		}

		public string ObtenerLstISOText(string lstISO,int NroMsg,string EventClick)
		{
			tbld="";
			string []LstISO = lstISO.ToString().Split('@');
			for(int l=0;l<=LstISO.Length-1;l++)
			{
				if(LstISO[l].Length!=0)
				{
					string []LstCampo = LstISO[l].ToString().Split('*');
					if((LstCampo[2].ToString() !="0")&&(LstCampo[2].ToString().Length>0))
					{
						string Script= ((EventClick.Length>0)? "onclick=" + Utilitario.Constantes.SIGNOCOMILLADOBLE + "javascript:" + EventClick + Utilitario.Constantes.SIGNOCOMILLADOBLE:"");
						string TextDecor = ((EventClick.Length>0)? "text-decoration: underline;cursor:hand;" :"") ;

						tbld += "<tr><td style='PADDING-LEFT: 5px;PADDING-RIGHT: 5px;" + TextDecor + "' noWrap IDSAMISO ='" + LstCampo[0].ToString() + "' IDTIPONORMA ='" + LstCampo[1].ToString() + " '  class='" + ((NroMsg>0)?"BaseItemInGridMsg": "BaseItemInGrid") + " ' " +  Script + ">"+ LstCampo[3].ToString() + "</td></tr>";
					}
				}
			}
			tbld = "<table >"+ tbld .ToString() + "</table>";
			return tbld;

		}

		public string ObtenerLstISOText(string lstISO)
		{
			return ObtenerLstISOText(lstISO,0,"");
		}


		ArrayList ObtenerLstISO()
		{
			ArrayList arrISO = new ArrayList();
			string []LstISO = this.hLstClausulas.Value.ToString().Split('@');
			for(int l=0;l<=LstISO.Length-1;l++)
			{
				if(LstISO[l].Length!=0)
				{
					string []LstCampo = LstISO[l].ToString().Split('*');
					
					SAMISOBE oSAMISOBE = new SAMISOBE();
					oSAMISOBE.IdSAM = Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora;
					oSAMISOBE.IdSAMISO = LstCampo[0].ToString();
					oSAMISOBE.IdNormaISO = Convert.ToInt32(LstCampo[1]);
					oSAMISOBE.Clausula = LstCampo[2];
					oSAMISOBE.Descripcion  = ((oSAMISOBE.IdNormaISO.ToString().Equals("4")==true)?this.txtArticulo.Text:"");
					oSAMISOBE.pIdEstado = Convert.ToInt32(LstCampo[5]);
					arrISO.Add(oSAMISOBE);
				}
			}
			return arrISO;
		}

		ArrayList ObtenerLstDestinatario()
		{
			ArrayList arrDESTINO = new ArrayList();
			string []LstDestino = this.hLstDetinatario.Value.ToString().Split('@');
			for(int l=0;l<=LstDestino.Length-1;l++)
			{
				if(LstDestino[l].Length!=0)
				{
					string []LstCampo = LstDestino[l].ToString().Split(';');
					SAMDestinoBE oSAMDestinoBE = new SAMDestinoBE();
					oSAMDestinoBE.IdSAM= Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora;
					oSAMDestinoBE.IdDestino= LstCampo[0].ToString(); 
					oSAMDestinoBE.IdArea= Convert.ToInt32(LstCampo[1]); 
					
					arrDESTINO.Add(oSAMDestinoBE);
				}
			}
			return arrDESTINO;
		}

		string ObtenerIdAreaDestino()
		{
			string ListDestino="";
			string []LstDestino = this.hLstDetinatario.Value.ToString().Split('@');
			for(int l=0;l<=LstDestino.Length-1;l++)
			{
				if(LstDestino[l].Length!=0)
				{
					string []LstCampo = LstDestino[l].ToString().Split(';');
					ListDestino +=LstCampo[1] +";";
				}
			}
			return ListDestino;
		}

		string tbld;
		string ObtenerLstDestinatarioText()
		{
			

			tbld="";
			ArrayList arrDESTINO = new ArrayList();
			string []LstDestino = this.hLstDetinatario.Value.ToString().Split('@');
			for(int l=0;l<=LstDestino.Length-1;l++)
			{
				if(LstDestino[l].Length!=0)
				{
					string []LstCampo = LstDestino[l].ToString().Split(';');
				//	tbld += "<table border='0' cellspacing='0'><tr><td noWrap class='BaseItemInGrid'  style=" + Comilla + "COLOR: #15428b; FONT-SIZE: 10px" + Comilla + " >" + LstCampo[2].ToString() + "</td></tr></table>";
					tbld += "<table class='BaseItemInGrid'><tr><td noWrap>"+ LstCampo[2].ToString() + "</td></tr></table>";
				}
			}
			return tbld;
		}


		ArrayList ObtenerLstAnexos()
		{
			ArrayList arrANEXO= new ArrayList();
			string []LstAnexos = this.hLstAnexo.Value.ToString().Split('@');
			for(int l=0;l<=LstAnexos.Length-1;l++)
			{
				if(LstAnexos[l].Length!=0)
				{
					string []LstCampo = LstAnexos[l].ToString().Split(';');
					SAMAnexosBE oSAMAnexosBE = new SAMAnexosBE();
					oSAMAnexosBE.IdSAM = Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora;
					oSAMAnexosBE.Nombre= LstCampo[1].ToString(); 
					arrANEXO.Add(oSAMAnexosBE);
				}
			}
			return arrANEXO;
		}

		public void Modificar()
		{
			SolicitudAccionMejoraBE oSolicitudAccionMejoraBE = new SolicitudAccionMejoraBE();
			oSolicitudAccionMejoraBE.IdSAM = Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora;
			oSolicitudAccionMejoraBE.FechaEmision = Convert.ToDateTime(this.calFechaEmite.Text);
			oSolicitudAccionMejoraBE.DescripcionHallazgo = this.txtDescripcion.Text;
			oSolicitudAccionMejoraBE.IdTipoAccion = Convert.ToInt32(this.ddlTipoAccion.SelectedValue);
			oSolicitudAccionMejoraBE.IdDetectadoEn = Convert.ToInt32(this.ddlDetectadoEn.SelectedValue);
			oSolicitudAccionMejoraBE.IdTipoAuditoria = Convert.ToInt32(this.ddlTipoAuditoria.SelectedValue);

			string HtmlEmail = Helper.Archivo.Leer(Helper.Archivo.RutaArchivoCorreo + "SAMGenerada.aspx");
			HtmlEmail = HtmlEmail.Replace("[QUIENENVIA]",CNetAccessControl.GetUserApellidosNombres());
			HtmlEmail = HtmlEmail.Replace("[IMG]", System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.RUTAFOTOSP].ToString() + CNetAccessControl.GetUserNroDocIdent() + ".jpg");
			HtmlEmail = HtmlEmail.Replace("[FECHA]",this.calFechaEmite.Text);
			HtmlEmail = HtmlEmail.Replace("[ACCION]",this.ddlTipoAccion.Items[this.ddlTipoAccion.SelectedIndex].Text);
			HtmlEmail = HtmlEmail.Replace("[DETECTADO]",this.ddlDetectadoEn.Items[this.ddlDetectadoEn.SelectedIndex].Text);
			HtmlEmail = HtmlEmail.Replace("[DESCRIPCION]",this.txtDescripcion.Text);
			HtmlEmail = HtmlEmail.Replace("[LSTDESTINOS]",ObtenerLstDestinatarioText());
			HtmlEmail = HtmlEmail.Replace("[LSNORMA]",ObtenerLstISOText(this.hLstClausulas.Value.ToString()));

			string LstValores=(new CSolicituddeAcciondeMejora()).ModificarSAM(oSolicitudAccionMejoraBE,ObtenerLstISO(),ObtenerLstDestinatario(),ObtenerLstAnexos());
			EmailSendOGIAPP(LstValores,HtmlEmail);
			
			ltlMensaje.Text = Helper.MensajeRetornoAlert();
		}

		void EmailSendOGIAPP(string LstValores,string HtmlEmail){
			if(LstValores.Length>0)
			{
				string []arrDatos = LstValores.Split('*');
				HtmlEmail = HtmlEmail.Replace("[SAM]",arrDatos[1].ToString());
				string []LstEmails=arrDatos[0].Split('?');
				string LstEmailsPara=LstEmails[0];
				//Elabora la lista con los reponsables de las areas involucradas
				string LstEmailsCC="";
				if(LstEmails.Length==2)
				{
					LstEmailsCC=LstEmails[1];
				}
				else
				{
					for(int l=1;((l<=LstEmails.Length-1));l++){
						if(LstEmails[l].Length>0)
						{
							LstEmailsCC +=LstEmails[l].ToString() +";";
						}
					}
				}
				if(LstEmailsCC.Length>0){
					if(LstEmailsCC.Substring(LstEmailsCC.Length-1,1).Equals(";"))
					{
						LstEmailsCC = LstEmailsCC.Substring(0,LstEmailsCC.Length-1);
					}
				}

				Helper.EnviarCorreo(CNetAccessControl.GetUserName(),"GENERACION DE SAM",LstEmailsPara,LstEmailsCC,HtmlEmail,true);
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleSolicituddeAcciondeMejora.Eliminar implementation
		}

		bool ddlActivo=true;
		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.ddlTipoAuditoria.Enabled=false;
					this.ddlAuditoria.Enabled=false;
					this.CargarModoModificar();
					break;
				case Enumerados.ModoPagina.C:
					ddlActivo=false;
					this.CargarModoModificar();
					this.CargarModoConsulta();
					break;
				
			}				
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalleSolicituddeAcciondeMejora.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			SolicitudAccionMejoraBE oSolicitudAccionMejoraBE = (SolicitudAccionMejoraBE) ((Page.Request.Params["Modo"]=="C")?(new CSolicituddeAcciondeMejora()).ListarDetalle(Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora,0): (new CSolicituddeAcciondeMejora()).ListarDetalle(Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora));
			ListItem item  = ddlTipoAuditoria.Items.FindByValue(oSolicitudAccionMejoraBE.IdTipoAuditoria.ToString());
			if(item!=null){
				item.Selected=true;
			}

			txtNroRegistro.Text = oSolicitudAccionMejoraBE.CodigoSAM;
			calFechaEmite.Text = oSolicitudAccionMejoraBE.FechaEmision.ToShortDateString();
			txtDescripcion.Text = oSolicitudAccionMejoraBE.DescripcionHallazgo;

			item  = ddlTipoAccion.Items.FindByValue(oSolicitudAccionMejoraBE.IdTipoAccion.ToString());
			if(item!=null){item.Selected=true;}

			item  = ddlDetectadoEn.Items.FindByValue(oSolicitudAccionMejoraBE.IdDetectadoEn.ToString());
			if(item!=null){item.Selected=true;}

			hIdAuditoria.Value=oSolicitudAccionMejoraBE.IdAuditoria.ToString();

			

			CtrlDestino(Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora);
			CtrlAnexos(Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora);
			//Verificar si la SAM esta cerrada
			if(oSolicitudAccionMejoraBE.IdEstado==2){
				CtrlNoEditables();
			}
		}
		
		void CtrlNoEditables()
		{
			ddlTipoAuditoria.Enabled=false;
			ddlAuditoria.Enabled=false;
			txtBuscar.ReadOnly=true;
			calFechaEmite.ReadOnly=true;
			ddlTipoAccion.Enabled=false;
			ddlDetectadoEn.Enabled=false;
			txtDescripcion.ReadOnly=true;
			FUFile.Style["display"]="none";
			this.ibtnAceptar.Style["display"]="none";
		}

		void CtrlDestino(string IdSAM){
			try
			{
				foreach(DataRow dri in (new CSAMDestino()).ListarTodosGrilla(IdSAM,"0").Rows)
				{
					hLstDetinatario.Value += dri["IdDestino"].ToString() + ";" + dri["IdArea"].ToString()+ ";" + dri["NombreArea"].ToString() + "@";
				}	
				hLstDetinatario.Value =hLstDetinatario.Value.ToString().Substring(0,hLstDetinatario.Value.ToString().Length-1);

			}
			catch(Exception ex){}
		}

		void CtrlAnexos(string IdSAM)
		{
			try
			{
				foreach(DataRow dri in (new CSAMAnexo()).ListarTodosGrilla(IdSAM).Rows)
				{
					hLstAnexo.Value += dri["IdAnexo"].ToString() +';'+dri["Nombre"].ToString() +'@';
				}
				hLstAnexo.Value = hLstAnexo.Value .ToString().Substring(0,hLstAnexo.Value.ToString().Length-1);
			}
			catch(Exception ex){}
		}

		public void CargarModoConsulta()
		{
			this.ibtnAceptar.Style["display"]="none";
			//this.ContextFile.Style["display"]="none";
			this.txtBuscar.Style["display"]="none";

			CtrlNoEditables();
		}

		public bool ValidarCampos()
		{
			if(this.hLstClausulas.Value.ToString().Length==0)
			{
				Helper.MsgBox("SAM","No se ha seleccionado clausula alguna para este doc SAM.",Enumerados.Ext.MessageBox.Button.OK,Enumerados.Ext.MessageBox.Icon.QUESTION);
				return false;
			}

			if(this.ddlTipoAuditoria.SelectedValue=="0")
			{
				Helper.MsgBox("SAM","No se ha seleccionado el tipo de Auditoria",Enumerados.Ext.MessageBox.Button.OK,Enumerados.Ext.MessageBox.Icon.QUESTION);
				return false;
			}

			if(this.hLstDetinatario.Value.Length==0)
			{
				Helper.MsgBox("SAM","Se debe de ingresar como minimo un destinatario",Enumerados.Ext.MessageBox.Button.OK,Enumerados.Ext.MessageBox.Icon.QUESTION);
				return false;
			}
			if(this.calFechaEmite.Text.Length==0)
			{
				Helper.MsgBox("SAM","Ingresar fecha de emisión",Enumerados.Ext.MessageBox.Button.OK,Enumerados.Ext.MessageBox.Icon.QUESTION);
				return false;
			}
			if(this.ddlTipoAccion.SelectedValue=="0")
			{
				Helper.MsgBox("SAM","Seleccionar un tipo de acción",Enumerados.Ext.MessageBox.Button.OK,Enumerados.Ext.MessageBox.Icon.QUESTION);
				return false;
			}
			if(this.ddlDetectadoEn.SelectedValue=="0")
			{
				Helper.MsgBox("SAM","Seleccionar lugar de detección",Enumerados.Ext.MessageBox.Button.OK,Enumerados.Ext.MessageBox.Icon.QUESTION);
				return false;
			}

			if(this.txtDescripcion.Text.Length==0)
			{
				Helper.MsgBox("SAM","Ingresar la descripción de la solicitud.",Enumerados.Ext.MessageBox.Button.OK,Enumerados.Ext.MessageBox.Icon.QUESTION);
				return false;
			}

			

			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleSolicituddeAcciondeMejora.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleSolicituddeAcciondeMejora.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		
		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				//if(HEst_Prc.Value=="0")
				{
					HEst_Prc.Value="1";
					if(Page.IsValid)
					{
						if(this.ValidarCampos())
						{
							tblBtns.Style.Add("display","none");
							Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA]) ;
							switch (oModoPagina)
							{
								case Enumerados.ModoPagina.N:
									this.Agregar();
									break;
								case Enumerados.ModoPagina.M:
									this.Modificar();
									break;
							}
						}
					}
				}
				//else{
			//		Page.RegisterStartupScript("msgSave","<script>Ext.MessageBox.alert('Guardando información', 'Un momento por favor el sistema esta guradando la información...', function(btn){});</script>");
			//	}
			}
			catch(SIMAExcepcionLog oSIMAExcepcionLog)
			{
				Session["Grabando"]="0";
				Helper.MsgBox(oSIMAExcepcionLog.Mensaje);					
			}
			catch(SIMAExcepcionIU oSIMAExcepcionIU)
			{
				Session["Grabando"]="0";
				Helper.MsgBox(oSIMAExcepcionIU.Mensaje);					
			}
			catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
			{
				Session["Grabando"]="0";
				Helper.MsgBox(oSIMAExcepcionDominio.Error.ToString());					
			}
			catch(Exception oException)
			{
				Session["Grabando"]="0";
				ASPNetUtilitario.MessageBox.Show(oException.Message.ToString());
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}				
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				if(dr["Links"].ToString().Length>0)
				{
					e.Item.Cells[0].Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]="javascript:(new SIMA.Utilitario.Helper.Window()).AbrirAchivo('" + dr["Links"].ToString() + "');";
					e.Item.Cells[0].Style.Add("COLOR","3300ff");
					e.Item.Cells[0].Style.Add("TEXT-DECORATION","underline");
				}
				e.Item.Attributes["IDISO"]=dr["IdNormaIso"].ToString();
				e.Item.Attributes["IDSAMISO"]=dr["IdSAMISO"].ToString();
				e.Item.Attributes["NORMAISO"]=dr["NormaISO"].ToString();
				e.Item.Attributes["DESCRIPCION"]=dr["Descripcion"].ToString();
				e.Item.Attributes["IDESTADO"]="1";

				e.Item.Cells[1].Attributes["IDCLAUSULA"]=dr["Clausula"].ToString();
				

				if(dr["IdNormaIso"].ToString()=="4") 
				{
					this.txtArticulo.Text = dr["Descripcion"].ToString();
				}

				Image imgBtn = (Image)e.Item.Cells[2].FindControl("imgBtn");
				imgBtn.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"ListarClausula('" +  (e.Item.ItemIndex+1).ToString() + "','" + dr["IdNormaIso"].ToString() + "','" + dr["NormaISO"].ToString() + "')");

				Image imgBtnEli = (Image)e.Item.Cells[3].FindControl("imgBtnEliminar");
				string CodClausula=dr["Clausula"].ToString();

				if((CodClausula=="0")||(CodClausula.Length==0))
				{
					imgBtnEli.Style.Add("display","none");
				}
				else
				{
					imgBtnEli.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"EliminarClausula(this.parentNode.parentNode);");
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

					/*DropDownList ddl = (DropDownList) e.Item.Cells[1].FindControl("ddlClausula");
					ddl.Attributes[Utilitario.Enumerados.EventosJavaScript.OnChange.ToString()]="ObtenerClausulas(this);";
					DataTable dtIso =(new CSAMiso()).ListarTodosGrilla(Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora,dr["IdNormaIso"].ToString()); 
					DataView dvISO = dtIso.DefaultView;
					dvISO.RowFilter="Estado <>0";
					ddl.DataSource = Helper.DataViewTODataTable(dvISO);
					ddl.DataValueField="IdNormaIso";
					ddl.DataTextField="NormaISO";
					ddl.DataBind();

					string Clausula=dr["Clausula"].ToString();
					//ddl.Items.Insert(0,(new ListItem("Seleccionar..",((dr["IdNormaIso"].ToString()=="4")?"202":"0"))));
					ddl.Items.Insert(0,(new ListItem("Seleccionar..","0")));
					ListItem lItem = ddl.Items.FindByValue(Clausula);
					if(lItem!=null){lItem.Selected=true;}
					ddl.Enabled=ddlActivo;
				
				*/

				
			}
		}

		private void btnSubir_Click(object sender, System.EventArgs e)
		{
			string []arrNombre = this.hNombreArchivoUP.Value.ToString().Split('.');
			string Ext =arrNombre[arrNombre.Length-1];
			string SoloNombre = this.hNombreArchivoUP.Value.ToString().Substring(0,this.hNombreArchivoUP.Value.ToString().Length-(Ext.Length+1));
			string NombreArchivo = CNetAccessControl.GetIdUser().ToString() + SoloNombre;
			Helper.SubirArchivo(this.FUFile,this.OGIRutaLocalTMP,NombreArchivo);
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		
	}
}
