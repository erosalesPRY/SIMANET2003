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
	/// Summary description for AdministrarVerificacionesPorAcciones.
	/// </summary>
	public class AdministrarVerificacionesPorAcciones : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.HtmlControls.HtmlTableCell CellLstCausaRaiz;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdsAcciones;
	
		const string KEYQGRPACCIONVERIFICA = "IdGRPAV";
		protected System.Web.UI.WebControls.DataGrid GridVerifica;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdGrupoVerificacion;
		const string KEYQLSTACCIONES = "LstAcciones";
		
		const string KEYQIMGELIMINAR="imgEliminar22";
		const string KEYQAUTORIZA="AUTORIZA";
		bool Autorizado;

		string IdGrupoAccionVerificacion
		{
			get{return Page.Request.Params[KEYQGRPACCIONVERIFICA].ToString();}
		}
		string IdLstAcciones
		{
			get{return Page.Request.Params[KEYQLSTACCIONES].ToString();}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Integrada: Administrar Verificaciones", this.ToString(),"Se consultó El Listado de las verificaciones por cada Acción Corectiva i/o Preventiva.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarDatos();
					this.LlenarGrilla();
					this.LlenarJScript();

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
			this.GridVerifica.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.GridVerifica_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		DataTable ObtenerDatos(){
			return (new CSAMVerificacion()).ListarTodosGrilla(this.IdGrupoAccionVerificacion);
		}
		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.RowFilter    = Utilitario.Helper.ObtenerFiltro();
				this.GridVerifica.DataSource = dv;
			}
			else
			{
				this.GridVerifica.DataSource = dt;
			}
			
			try
			{
				this.GridVerifica.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				this.GridVerifica.CurrentPageIndex = 0;
				this.GridVerifica.DataBind();
			}						
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarVerificacionesPorAcciones.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarVerificacionesPorAcciones.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarVerificacionesPorAcciones.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.hIdsAcciones.Value = this.IdLstAcciones;
			this.hIdGrupoVerificacion.Value = this.IdGrupoAccionVerificacion;
			Autorizado=false;
			if(Page.Request.Params[KEYQAUTORIZA]!=null){Autorizado=((Page.Request.Params[KEYQAUTORIZA].Equals("0"))?true:false);}
		}

		public void LlenarJScript()
		{
			string script = "var oGridVerifica = jNet.get('GridVerifica');\n";
			script += "for(var i=1;i<=oGridVerifica.rows.length-1;i++){\n";
			script += "	var otxtfecha = oGridVerifica.rows[i].cells[1].children[0];\n";
			script += "	otxtfecha.id='txtFecha' + i;\n";
			script += "	new Ext.form.DateField({allowBlank : false,applyTo: otxtfecha,format:'d/m/Y',width:70});\n";
			script += "}\n";

			Helper.JavaScript.RegistrarScript(script);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarVerificacionesPorAcciones.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarVerificacionesPorAcciones.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarVerificacionesPorAcciones.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarVerificacionesPorAcciones.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarVerificacionesPorAcciones.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void GridVerifica_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{


				string Modo = "M";
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.UIControls.DataGrid.CHiperLink((DataGrid)sender, e.Item.Cells[0],"");
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);


				string DATA = dr["IdVerificacion"].ToString()
								+ Utilitario.Constantes.SIGNOARROBA
								+ dr["Fecha"].ToString()
								+ Utilitario.Constantes.SIGNOARROBA
								+ dr["AccionTomada"].ToString()
								+ Utilitario.Constantes.SIGNOARROBA
								+ dr["Observacion"].ToString();

				e.Item.Attributes["DATA"]=DATA;

				e.Item.Attributes["MODO"]="M";
				e.Item.Attributes["IDVERIFICACION"]=dr["IdVerificacion"].ToString();

				TextBox tb = (TextBox)e.Item.Cells[1].FindControl("txtFechaV");
				tb.ReadOnly=Autorizado;
				tb.Text = dr["Fecha"].ToString();
				tb.Attributes["OLD"]=dr["Fecha"].ToString();
				tb.Attributes[Utilitario.Enumerados.EventosJavaScript.OnBlur.ToString()]="AgregarVerificacion(this);";

				tb = (TextBox)e.Item.Cells[2].FindControl("txtVerificacionV");
				tb.ReadOnly=Autorizado;
				tb.Text = dr["AccionTomada"].ToString();
				tb.Attributes["OLD"]=dr["AccionTomada"].ToString();
				tb.Attributes[Utilitario.Enumerados.EventosJavaScript.OnBlur.ToString()]="AgregarVerificacion(this);";

				tb = (TextBox)e.Item.Cells[3].FindControl("txtObservacionesV");
				tb.ReadOnly=Autorizado;
				tb.Text = dr["Observacion"].ToString();
				tb.Attributes["OLD"]=dr["Observacion"].ToString();
				tb.Attributes[Utilitario.Enumerados.EventosJavaScript.OnBlur.ToString()]="AgregarVerificacion(this);";

				Image oImg = (Image)e.Item.Cells[4].FindControl(KEYQIMGELIMINAR);
				oImg.Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()] = "EliminarVerificacion(this);";


				if(dr["IdVerificacion"].ToString()=="9")
				{
					Modo = "N";
					e.Item.Attributes["MODO"]="N";
					Image oimg =(Image) e.Item.Cells[4].FindControl(KEYQIMGELIMINAR);
					oimg.Style["display"]="none";
				}

				string RegistroBE = "var RegistroBE = {IDVERIFICACION:'" + dr["IdVerificacion"].ToString() + "',MODO:'" + Modo + "',VERIFICACION:'" + dr["AccionTomada"].ToString() + "',OBSERVACION:'" + dr["Observacion"].ToString() + "',FECHA:'" + dr["Fecha"].ToString() + "'};";
				e.Item.Attributes["REGBE"] = RegistroBE;

			}		
		}
	}
}
