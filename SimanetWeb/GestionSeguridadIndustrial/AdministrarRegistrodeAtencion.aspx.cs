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
using SIMA.Controladoras.Personal;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.Personal;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Configuration;


namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for AdministrarRegistrodeAtencion.
	/// </summary>
	public class AdministrarRegistrodeAtencion : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.TextBox txtAreaDestino;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.DataGrid GridRegVis;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtNroDNI;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.DropDownList ddlNacionalidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdArea;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdsAcciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdGrupoVerificacion;
		protected System.Web.UI.WebControls.ImageButton ibtnDiagnostico;
		protected System.Web.UI.WebControls.ImageButton ibtnMedicacion;
		protected System.Web.UI.WebControls.TextBox txtApellidoPaterno;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtApellidoMaterno;
		protected System.Web.UI.WebControls.TextBox txtNombres;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellLstCausaRaiz;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Becados", this.ToString(),"Se consultó El Listado de las Capacitaciones en el Extranjero.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarDatos();
					this.LlenarCombos();
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
		DataTable ObtenerDatos()
		{
			string []arrFecha = this.txtFecha.Text.Split('/');
			string Fechayyyymmdd = arrFecha[arrFecha.Length-1]+arrFecha[1].ToString().PadLeft(2,'0')+arrFecha[0].ToString().PadLeft(2,'0');
			DataTable dt=(new CCCTT_ProgramacionTrabajadorUbicacionGPS()).ListarTodosGrilla(Convert.ToInt32(this.hIdArea.Value),Fechayyyymmdd);
			if(dt==null)
			{
				DataTable dt1 = new DataTable();
				dt1.Columns.Add(new DataColumn("IdRegIng",System.Type.GetType("System.String")));
				dt1.Columns.Add(new DataColumn("NroDNI",System.Type.GetType("System.String")));
				dt1.Columns.Add(new DataColumn("ApellidosyNombres",System.Type.GetType("System.String")));

				dt1.Columns.Add(new DataColumn("IdArea",System.Type.GetType("System.Int32")));
				dt1.Columns.Add(new DataColumn("HoraIng",System.Type.GetType("System.String")));
				dt1.Columns.Add(new DataColumn("HoraSal",System.Type.GetType("System.String")));

				dt1.Columns.Add(new DataColumn("Motivo",System.Type.GetType("System.String")));
				dt1.Columns.Add(new DataColumn("Latitud",System.Type.GetType("System.String")));
				dt1.Columns.Add(new DataColumn("Long",System.Type.GetType("System.String")));
				dt1.Columns.Add(new DataColumn("NroProgramacion",System.Type.GetType("System.Int32")));
				dt1.Columns.Add(new DataColumn("Periodo",System.Type.GetType("System.Int32")));
				dt1.Columns.Add(new DataColumn("Modo",System.Type.GetType("System.String")));


				NuevaFila(dt1);
				return dt1;
			}
			else
			{
				
				NuevaFila(dt);

				return dt;
			}
			
		}
		
		void NuevaFila(DataTable dt)
		{
			DataRow row = dt.NewRow();
			row["IdRegIng"] = "0";
			row["NroDNI"] = "";
			row["ApellidosyNombres"]= "";
			row["IdArea"]= this.hIdArea.Value;
			row["HoraIng"]= DateTime.Now.ToShortTimeString();
			row["HoraSal"]=  DateTime.Now.ToShortTimeString();
			row["Motivo"]= "";
			row["Latitud"]= "";
			row["Long"]= "";
			row["NroProgramacion"]= 0;
			row["Periodo"]= 0;
			row["Modo"] = "N";
			dt.Rows.Add(row);
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
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.GridRegVis.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.GridRegVis_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.RowFilter    = Utilitario.Helper.ObtenerFiltro();
				this.GridRegVis.DataSource = dv;
			}
			else
			{
				this.GridRegVis.DataSource = dt;
			}
			
			try
			{
				this.GridRegVis.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				this.GridRegVis.CurrentPageIndex = 0;
				this.GridRegVis.DataBind();
			}							
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarRegistrodeAtencion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarRegistrodeAtencion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			const int IDTABLANACIONALIDAD = 458;
			this.ddlNacionalidad.DataSource = (new CTablaTablas()).ListaTodosCombo(IDTABLANACIONALIDAD);
			this.ddlNacionalidad.DataTextField = Enumerados.ColumnasTablasTablas.Var1.ToString();
			this.ddlNacionalidad.DataValueField = Enumerados.ColumnasTablasTablas.Codigo.ToString();
			this.ddlNacionalidad.DataBind();		}

		public void LlenarDatos()
		{
			this.hIdArea.Value = CNetAccessControl.GetUserIdArea();
			this.txtAreaDestino.Text = CNetAccessControl.GetUserNombreArea();
			this.txtFecha.Text = DateTime.Now.ToShortDateString();		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarRegistrodeAtencion.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarRegistrodeAtencion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarRegistrodeAtencion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarRegistrodeAtencion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarRegistrodeAtencion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarRegistrodeAtencion.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void GridRegVis_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Attributes["DATA"] = dr["IdRegIng"].ToString()
					+"@"
					+ dr["NroDNI"].ToString()
					+"@"
					+ dr["ApellidosyNombres"].ToString()
					+"@"
					+ dr["IdArea"].ToString()
					+"@"
					+ dr["HoraIng"].ToString()
					+"@"
					+ dr["HoraSal"].ToString()
					+"@"
					+ dr["Motivo"].ToString()
					+"@"
					+ dr["Latitud"].ToString()
					+"@"
					+ dr["Long"].ToString()
					+"@"
					+ dr["NroProgramacion"].ToString()
					+"@"
					+ dr["Periodo"].ToString()
					+"@"
					+ dr["Modo"].ToString();

				//	if(dr["Modo"].ToString()!="N")
			{

				Helper.UIControls.DataGrid.CHiperLink((DataGrid)sender, e.Item.Cells[0],"");
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,"RowDataSelected(this);");

				TextBox txtAN = (TextBox)e.Item.Cells[1].FindControl("txtTrabajador");
				txtAN.Text=dr["ApellidosyNombres"].ToString();

				TextBox txtMtv = (TextBox)e.Item.Cells[1].FindControl("txtMotivo");
				txtMtv.Text=dr["Motivo"].ToString();
				txtMtv.Attributes[Utilitario.Constantes.EVENTOONBLUR.ToString()]="CambiarMotivo(this);";


				
				eWorld.UI.TimePicker tpkIng = (eWorld.UI.TimePicker)e.Item.Cells[3].FindControl("tmHoraIng");
				tpkIng.SelectedTime=Convert.ToDateTime(dr["HoraIng"].ToString());
				
				

				eWorld.UI.TimePicker tpkSal = (eWorld.UI.TimePicker)e.Item.Cells[4].FindControl("tmHoraSal");
				tpkSal.SelectedTime=Convert.ToDateTime(dr["HoraSal"].ToString());



				Image imgDel = (Image) e.Item.Cells[6].FindControl("imgEliminar22");
				imgDel.Attributes[Utilitario.Constantes.EVENTOCLICK.ToString()]="Eliminar(this)";
				imgDel.Style.Add("display",((dr["Modo"].ToString()=="N")?"none":"block"));

				//Controladora.Personal.CCTT_ProgramacionTrabajadorUbicacionGPSTAD
			}
				
				if(dr["Periodo"].ToString()=="0")
				{
					e.Item.Cells[5].Text = "Sin/Prog";
				}
				else
				{
					e.Item.Cells[5].Text = dr["Periodo"].ToString() +"-"+dr["NroProgramacion"].ToString();
				}


				Image oimg =(Image)e.Item.Cells[1].FindControl("imgAG");
				oimg.Attributes[Utilitario.Constantes.EVENTOCLICK.ToString()]="AgregarTrabajador(this)";

			
			}
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
				this.LlenarGrilla();
		}
	}
}
