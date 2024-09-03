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
using System.Drawing;

namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for OGIPanelControl.
	/// </summary>
	public class OGIPanelControl : System.Web.UI.Page, IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList ddlAmo;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList ddlmes;
		protected System.Web.UI.WebControls.Label Label1;
		protected projDataGridWeb.DataGridWeb grid;
		public static int amo=30;
		public static int mes=40;
		protected System.Web.UI.WebControls.Button ibtnMostrar;

		
		string Comilla= Utilitario.Constantes.SIGNOCOMILLADOBLE.ToString() ;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarJScript();
					this.LlenarCombos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Integrada: Panl de control", this.ToString(),"Se consultó El Listado de las Capacitaciones en el Extranjero.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina();
					//this.LlenarGrillaOrdenamientoPaginacion("",0);
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

		private DataTable ObtenerDatos()
		{
			return (new CSolicituddeAcciondeMejora()).ListarTablero();
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
			this.ibtnMostrar.Click += new System.EventHandler(this.ibtnMostrar_Click);
			this.ddlAmo.SelectedIndexChanged += new System.EventHandler(this.ddlAmo_SelectedIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();

			if (dt!=null)
			{
				grid.DataSource = dt;
			}
			else
			{
				grid.DataSource = dt;
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

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add OGIPanelControl.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add OGIPanelControl.LlenarGrillaOrdenamientoPaginacion implementation
			DataTable dt = this.ObtenerDatos();

			if (dt!=null)
			{
				grid.DataSource = dt;
			}
			else
			{
				grid.DataSource = dt;
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
			DataTable dt =(new CSolicituddeAcciondeMejora()).LlenarComboTableroSAM("año",0);
			ddlAmo.DataSource = dt;
			ddlAmo.DataValueField="ID";
			ddlAmo.DataTextField="ID";
			ddlAmo.DataBind();
			//ddlAmo.Items.Insert(1,"2019");
			//ddlAmo.SelectedIndex=0;
			ListItem litem = ddlAmo.Items.FindByValue(DateTime.Now.Year.ToString());
			if(litem!=null){
				litem.Selected=true;
			}
			this.MostrarComboMes();
		}

		public void LlenarDatos()
		{
			lblPagina.Text= Page.Request.Params[Utilitario.Constantes.KEYNOMBREFUNCIONALIDAD].ToString();
			amo=30;
			mes=40;
		}

		public void LlenarJScript()
		{
			//this.ddlAmo.Attributes[Utilitario.Enumerados.EventosJavaScript.OnChange.ToString()]="Progresso();";
			//this.ddlmes.Attributes[Utilitario.Enumerados.EventosJavaScript.OnChange.ToString()]="Progresso();";
		}

		public void RegistrarJScript()
		{
			// TODO:  Add OGIPanelControl.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add OGIPanelControl.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add OGIPanelControl.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add OGIPanelControl.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add OGIPanelControl.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			e.Item.Cells[6].Style.Add("display","none");

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;			

				Utilitario.Helper.ConfiguraNodosTreeview(e,1,0,dr,"ListarDetalle('" + dr["IdTipoNorma"] + "','" + dr["IdTipoAuditoria"] + "','" + dr["Periodo"] +  "','4','" + dr["Autorizado"] + "');");
				
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				
					
				string strEstiloTexto = "Style="+ Comilla + "COLOR: #3300ff; TEXT-DECORATION: underline"+ Comilla;
				//IdTipoNorma,IdTipoAuditoria,Periodo,Tipo,Autorizado){

				e.Item.Cells[1].Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()] = "ListarDetalle('" + dr["IdTipoNorma"] + "','" + dr["IdTipoAuditoria"] + "','" + dr["Periodo"] +  "','1','" + dr["Autorizado"] + "');";

				e.Item.Cells[2].Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()] = "ListarDetalle('" + dr["IdTipoNorma"] + "','" + dr["IdTipoAuditoria"] + "','" + dr["Periodo"] +  "','5','" + dr["Autorizado"] + "');";

				e.Item.Cells[3].Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()] = "ListarDetalle('" + dr["IdTipoNorma"] + "','" + dr["IdTipoAuditoria"] + "','" + dr["Periodo"] +  "','2','" + dr["Autorizado"] + "');";

				e.Item.Cells[4].Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()] = "ListarDetalle('" + dr["IdTipoNorma"] + "','" + dr["IdTipoAuditoria"] + "','" + dr["Periodo"] +  "','3','" + dr["Autorizado"] + "');";

				e.Item.Cells[1].Font.Underline=true;
				e.Item.Cells[1].ForeColor = Color.Navy;

				e.Item.Cells[2].Font.Underline=true;
				e.Item.Cells[2].ForeColor = Color.Navy;

				e.Item.Cells[3].Font.Underline=true;
				e.Item.Cells[3].ForeColor = Color.Navy;

				e.Item.Cells[4].Font.Underline=true;
				e.Item.Cells[4].ForeColor = Color.Navy;

				if(dr["IdNIvel"].ToString()!="2")
				{
					e.Item.Cells[1].Font.Size = FontUnit.Point(8);
					e.Item.Cells[1].Font.Bold = true;
					e.Item.Cells[2].Font.Size = FontUnit.Point(8);
					e.Item.Cells[2].Font.Bold = true;
					e.Item.Cells[3].Font.Size = FontUnit.Point(8);
					e.Item.Cells[3].Font.Bold = true;
					e.Item.Cells[4].Font.Size = FontUnit.Point(8);
					e.Item.Cells[4].Font.Bold = true;
					e.Item.Cells[5].Font.Size = FontUnit.Point(8);
					e.Item.Cells[5].Font.Bold = true;
				}
				
				if(dr["IdNIvel"].ToString()=="0")
				{
					DataTable dtISO=(new CSAMResponsableISON()).Listar(Convert.ToInt32(dr["IdRubro"]));
					if(dtISO!=null)
					{
						foreach(DataRow drISO in dtISO.Rows)
						{
							//string ctrlImg  = "<div class=" + Comilla +"round" + Comilla + "><img src=" + Comilla + Helper.ObtenerFotoPersonal("5732") + Comilla + " style=" + Comilla +"width: 30px; height: 40px;" + Comilla + " /></div>";
							//e.Item.Cells[4].Controls.Add(new LiteralControl(ctrlImg));
							HtmlTable  htmlT =   Helper.CrearHtmlTabla(1,1);
							htmlT.Attributes["class"]="BaseItemInGrid";
							htmlT.Rows[0].Cells[0].InnerText=drISO["ApellidosyNombres"].ToString();
							e.Item.Cells[6].Controls.Add(htmlT);
						}
					}
				}	
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private DataTable ObtenerDatosHistorial()
		{
			//return (new CSolicituddeAcciondeMejora()).ListarTableroHistorial(Int32.Parse(ddlAmo.SelectedValue),Int32.Parse(ddlmes.SelectedValue));
			return (new CSolicituddeAcciondeMejora()).ListarTableroHistorial(amo,mes);

		}

		private void LlenarGrillaHistorial()
		{
			DataTable dt= new DataTable();
			try
			{
				if(Int32.Parse(ddlmes.SelectedValue)==20)
				{
					dt = this.ObtenerDatos();
				}
				else
				{
					dt = this.ObtenerDatosHistorial();
				}
			}
			catch(Exception ee){
				dt= (new CSolicituddeAcciondeMejora()).ListarTableroHistorial(amo,mes);
			}


			if (dt!=null)
			{
				grid.DataSource = dt;
			}
			else
			{
				grid.DataSource = dt;
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

		private void ibtnConsultar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Personal",this.ToString(),"Se consultó vacaciones programadas.",Enumerados.NivelesErrorLog.I.ToString()));
					amo = Int32.Parse(ddlAmo.SelectedValue);
					mes = Int32.Parse(ddlmes.SelectedValue);
					this.LlenarGrillaHistorial();
			}
			catch(SIMAExcepcionLog oSIMAExcepcionLog)
			{
				Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
			}
			catch(SIMAExcepcionIU oSIMAExcepcionIU)
			{
				Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
			}
			catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
			{
				Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
			}
			catch(Exception oException)
			{
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		private void MostrarComboMes(){
			this.ddlmes.Items.Clear();
			DataTable dt2 =(new CSolicituddeAcciondeMejora()).LlenarComboTableroSAM("mes",Int32.Parse(ddlAmo.SelectedValue));
			ddlmes.DataSource = dt2;
			ddlmes.DataValueField="ID";
			ddlmes.DataTextField="NOMBRE";
			ddlmes.DataBind();
			ddlmes.Items.Insert(0,"Seleccione ..");
			ddlmes.SelectedIndex=0;

			if(ddlmes.Items.Count<=1)
			{
				ddlmes.Enabled=false;
				//this.ibtnConsultar.Visible=false;
			}
			else{
				ddlmes.Enabled=true;
				//this.ibtnConsultar.Visible=true;
			}
		}

		private void ddlAmo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.MostrarComboMes();
			if(amo==30 && mes==40)
			{
				this.LlenarGrilla();
			}
			else
			{
				this.LlenarGrillaHistorial();
			}
		}

		private void ibtnMostrar_Click(object sender, System.EventArgs e)
		{
			try
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Personal",this.ToString(),"Se consultó vacaciones programadas.",Enumerados.NivelesErrorLog.I.ToString()));
				amo = Int32.Parse(ddlAmo.SelectedValue);
				mes = Int32.Parse(ddlmes.SelectedValue);
				this.LlenarGrillaHistorial();
			}
			catch(SIMAExcepcionLog oSIMAExcepcionLog)
			{
				Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
			}
			catch(SIMAExcepcionIU oSIMAExcepcionIU)
			{
				Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
			}
			catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
			{
				Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
			}
			catch(Exception oException)
			{
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}
	}
}
