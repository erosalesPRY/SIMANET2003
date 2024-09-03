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
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using System.Drawing;


namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for AdministraFichaMedica.
	/// </summary>
	public class AdministraFichaMedica : System.Web.UI.Page,IPaginaBase	
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.ImageButton imgAgregar;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtNroDNI;
		protected System.Web.UI.WebControls.TextBox txtApellidosyNombres;
		protected System.Web.UI.WebControls.DropDownList ddlAptitud;
		protected System.Web.UI.WebControls.TextBox txtFechaVence;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.Button btnFiltar;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox ptxtNroDNI;
		protected System.Web.UI.WebControls.TextBox ptxtApellidosyNombres;
		protected System.Web.UI.WebControls.DropDownList pddlAptitud;
		protected System.Web.UI.WebControls.TextBox ptxtFechaVence;
		protected System.Web.UI.WebControls.Button btnModifica;
		protected System.Web.UI.WebControls.Button ibtnEliminar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdExamen;
		protected System.Web.UI.WebControls.TextBox pCalFecha;
		protected System.Web.UI.HtmlControls.HtmlTableCell ContextSCTR;
		protected System.Web.UI.WebControls.TextBox txtFechaIni;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdFila;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;

		private string IDREG;
		string strObj="";
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		string ParamArgument="";

		private void Page_Load(object sender, System.EventArgs e)
		{
			strObj=Page.Request.Params["__EVENTTARGET"];
			ParamArgument=Page.Request.Params["__EVENTARGUMENT"];

			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Programación Personal Contratista", this.ToString(),"Se consultó El Listado de las programaciones de los contratistas",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.ddlAptitud.SelectedIndexChanged += new System.EventHandler(this.ddlAptitud_SelectedIndexChanged);
			this.imgAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.imgAgregar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
			this.ibtnEliminar.Click += new System.EventHandler(this.ibtnEliminar_Click);
			this.btnFiltar.Click += new System.EventHandler(this.btnFiltar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministraFichaMedica.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministraFichaMedica.LlenarGrillaOrdenamiento implementation
		}
		DataTable ObtenerDatos()
		{
			return(new CCCTT_ExamenMedico()).ListaFicha(0,0,this.txtNroDNI.Text);
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
				grid.CurrentPageIndex = indicePagina;
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
			DataTable dtAptitud = (new SIMA.Controladoras.General.CTablaTablas()).ListaItemTablas(572);
			this.ddlAptitud.DataSource=dtAptitud;
			this.ddlAptitud.DataTextField="Descripcion";
			this.ddlAptitud.DataValueField="Codigo";
			this.ddlAptitud.DataBind();
			this.ddlAptitud.Items.Insert(0,(new ListItem("Seleccionar","0")));

			this.pddlAptitud.DataSource=dtAptitud ;
			this.pddlAptitud.DataTextField="Descripcion";
			this.pddlAptitud.DataValueField="Codigo";
			this.pddlAptitud.DataBind();		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministraFichaMedica.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.txtFechaIni.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnBlur.ToString(),"CalcularFechaFin('1','txtFechaIni')");
			this.pCalFecha.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnBlur.ToString(),"CalcularFechaFin('2','pCalFecha')");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministraFichaMedica.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministraFichaMedica.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministraFichaMedica.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministraFichaMedica.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministraFichaMedica.ValidarFiltros implementation
			return false;
		}

		#endregion


		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				//TextBox txtID =(TextBox) e.Item.Cells[7].FindControl("txtID");
				//txtID.Text = dr["Periodo"].ToString() + "-" + dr["IdExamen"].ToString();

				System.Web.UI.WebControls.Image oImgDEL = (System.Web.UI.WebControls.Image )e.Item.Cells[5].FindControl("imgEliminar");
				oImgDEL.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"EliminarFicha('" + dr["NroDNI"].ToString()+ "','" + dr["Periodo"].ToString() + "','" + dr["IdExamen"].ToString() + "')");

				if(dr["IdAptitud"].ToString().Equals("2"))
				{
					e.Item.Cells[3].ForeColor=Color.Blue;
					e.Item.Cells[3].Font.Underline=true;
					e.Item.Cells[3].Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"ListarRestricciones('" + dr["Periodo"].ToString() + "','" + dr["IdExamen"].ToString() + "')");
				}
				string strFunction="DetalleFicha('" + dr["NroDNI"].ToString()+ "','" + dr["ApellidosyNombres"].ToString()+ "','" + dr["NombreAptitud"].ToString() + "','" + dr["FechaInicio"].ToString()+ "','" + dr["FechaVencimiento"].ToString() +"')";

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,Helper.HistorialIrAdelantePersonalizado(this.hGridPagina.ID.ToString(),this.hGridPaginaSort.ID.ToString()),strFunction);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hPeriodo",dr["Periodo"].ToString()),Helper.MostrarDatosEnCajaTexto("hIdExamen",dr["IdExamen"].ToString()));

				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				if(IDREG == dr["Periodo"].ToString() + "-" + dr["IdExamen"].ToString())
				{
					hIdFila.Value=(e.Item.ItemIndex+1).ToString();
				}

			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Helper.ObtenerIndicePagina());
		
		}

		private void btnFiltar_Click(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}
		public bool ValidarCampos()
		{
			if(this.txtNroDNI.Text.Length==0){
				Helper.MsgBox("Validar","No se ha ingresado Nro de DNI a registrar",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				return false;
			}
			if(this.txtFechaIni.Text.Length==0)
			{
				Helper.MsgBox("Validar","No se ha ingresado fecha de inicio",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				return false;
			}
			if(this.ddlAptitud.SelectedValue=="0")
			{
				Helper.MsgBox("Validar","No se ha seleccionado la Aptitud",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				return false;
			}
			return true;
		}

		private void imgAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(ValidarCampos())
			{
				ExamenMedicoBE oExamenMedicoBE = new ExamenMedicoBE();

				oExamenMedicoBE.NroDni= this.txtNroDNI.Text;
				oExamenMedicoBE.IdCM= 1;
				oExamenMedicoBE.FechaInicio= DateTime.Parse(this.txtFechaIni.Text);
				oExamenMedicoBE.FechaVencimiento= DateTime.Parse(this.txtFechaVence.Text);
				oExamenMedicoBE.IdTipoEMO= 1;
				oExamenMedicoBE.IdAptitud= Convert.ToInt32(this.ddlAptitud.SelectedValue);
				oExamenMedicoBE.IdToxicologico= 1;

				string retorno = (new CCCTT_ExamenMedico()).InsertarF(oExamenMedicoBE);
				if(retorno!="-1")
				{
					IDREG = retorno;
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad industrial",this.ToString(),"Se registró examen medico. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));

					this.txtNroDNI.Text="";
					this.txtApellidosyNombres.Text="";
					this.txtFechaIni.Text="";
					this.txtFechaVence.Text="";
					this.ddlAptitud.SelectedIndex=0;
					if(oExamenMedicoBE.IdAptitud==2)
					{
						string []arrID=retorno.Split('-');
						Helper.JavaScript.RegistrarScript("Restric","ListarRestricciones('" + arrID[0] + "','" + arrID[1] + "');");
					}
			

				}
			}
		}

		private void btnModifica_Click(object sender, System.EventArgs e)
		{
			string []strParam=ParamArgument.Split(';');

			ExamenMedicoBE oExamenMedicoBE = new ExamenMedicoBE();
			oExamenMedicoBE.NroDni= strParam[0];
			oExamenMedicoBE.Periodo= Convert.ToInt32(strParam[1]);
			oExamenMedicoBE.IdExamen= Convert.ToInt32(strParam[2]);
			oExamenMedicoBE.IdCM= 1;
			oExamenMedicoBE.FechaInicio= DateTime.Parse(strParam[3]);
			oExamenMedicoBE.FechaVencimiento= DateTime.Parse(strParam[4]);
			oExamenMedicoBE.IdTipoEMO= 1;
			oExamenMedicoBE.IdAptitud= Convert.ToInt32(strParam[5]);
			oExamenMedicoBE.IdToxicologico= 1;

			int retorno = (new CCCTT_ExamenMedico()).Modificar(oExamenMedicoBE);
			if(retorno>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad industrial",this.ToString(),"Se registró examen medico. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
				this.ptxtNroDNI.Text="";
				this.ptxtApellidosyNombres.Text="";
				//this.pCalFechaInicio.SelectedDate=DateTime.Now;
				this.ptxtFechaVence.Text="";
			}

		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnEliminar_Click(object sender, System.EventArgs e)
		{
			try
			{
				string []arrParam = ParamArgument.Split(';');
				if((new CCCTT_ExamenMedico()).Eliminar(arrParam[0],Convert.ToInt32(arrParam[1]),Convert.ToInt32(arrParam[2]))>0)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad industrial",this.ToString(),"Se eliminó registro de examen medico." ,Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}		
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.txtNroDNI.Text="";
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}

		private void ddlAptitud_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		
	}
}
