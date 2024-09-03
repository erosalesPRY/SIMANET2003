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
	/// Summary description for AdministrarFichaInduccion.
	/// </summary>
	public class AdministrarFichaInduccion : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtNroDNI;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtApellidosyNombres;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.ImageButton imgAgregar;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtFechaIni;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtFechaVence;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox ptxtNroDNI;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox ptxtApellidosyNombres;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox pCalFecha;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox ptxtFechaVence;
		protected System.Web.UI.WebControls.Button btnModifica;
		protected System.Web.UI.WebControls.Button ibtnEliminar;
		protected System.Web.UI.WebControls.Button btnFiltar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdFila;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodo;
		protected System.Web.UI.HtmlControls.HtmlTableCell ContextSCTR;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdEvaluacion;
		protected System.Web.UI.WebControls.TextBox txtNota;
		protected System.Web.UI.WebControls.TextBox ptxtNota;


		string strObj="";
		string ParamArgument="";
		private string IDREG;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtNroRegistro;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.TextBox ptxtNroRegistro;
		protected System.Web.UI.WebControls.TextBox txtRazonSocial;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.TextBox txtNroRUC;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodoProg;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroProg;

		public int Periodo
		{
			get{return Convert.ToInt32(strParam[0]);}
		}
		public int IdEvaluacion
		{
			get{return Convert.ToInt32(strParam[1]);}
		}
		public string NroDNI
		{
			get{return strParam[2].ToString();}
		}
		public int Nota
		{
			get{return Convert.ToInt32(strParam[3]);}
		}
		public bool Aprobado
		{
			get{return ((this.Nota>Helper.ObtenerNotaInduccion())?true:false) ;}
		}
		public DateTime FechaInicio
		{
			get{return DateTime.Parse(strParam[4]);}
		}
		public DateTime FechaVencimiento
		{
			get{return DateTime.Parse(strParam[5]);}
		}
		public string NroRegistro
		{
			get{return strParam[6].ToString();}
		}


		string []strParam;

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
			this.imgAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.imgAgregar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ptxtNroRegistro.TextChanged += new System.EventHandler(this.ptxtNroRegistro_TextChanged);
			this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
			this.ibtnEliminar.Click += new System.EventHandler(this.ibtnEliminar_Click);
			this.btnFiltar.Click += new System.EventHandler(this.btnFiltar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarFichaInduccion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarFichaInduccion.LlenarGrillaOrdenamiento implementation
		}
		DataTable ObtenerDatos()
		{
			return(new CCCTT_InduccionEvaluacion()).ListarInduccion(0,0,this.txtNroDNI.Text);
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
			// TODO:  Add AdministrarFichaInduccion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarFichaInduccion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarFichaInduccion.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarFichaInduccion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarFichaInduccion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarFichaInduccion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarFichaInduccion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarFichaInduccion.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				System.Web.UI.WebControls.Image oImgDEL = (System.Web.UI.WebControls.Image )e.Item.Cells[5].FindControl("imgEliminar");
				oImgDEL.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"EliminarFicha('" + dr["Periodo"].ToString() + "','" + dr["IdEvaluacion"].ToString() + "','" + dr["NroDNI"].ToString()+ "')");


				string strFunction="DetalleFicha('" + dr["NroDNI"].ToString()+ "','" + dr["ApellidosyNombres"].ToString()+ "','" + dr["Nota"].ToString()+ "','" + dr["FechaInicio"].ToString()+ "','" + dr["FechaVencimiento"].ToString() +"','" + dr["Cod_Proceso"].ToString() +"')";

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,Helper.HistorialIrAdelantePersonalizado(this.hGridPagina.ID.ToString(),this.hGridPaginaSort.ID.ToString()),strFunction);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hPeriodo",dr["Periodo"].ToString()),Helper.MostrarDatosEnCajaTexto("hIdEvaluacion",dr["IdEvaluacion"].ToString()));

				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				if(IDREG == dr["Periodo"].ToString() + "-" + dr["IdEvaluacion"].ToString())
				{
					hIdFila.Value=(e.Item.ItemIndex+1).ToString();
				}

			}
		}


		public bool ValidarCampos()
		{
			if(this.txtNroDNI.Text.Length==0)
			{
				Helper.MsgBox("Validar","No se ha ingresado Nro de DNI a registrar",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				return false;
			}
			if(this.txtFechaIni.Text.Length==0)
			{
				Helper.MsgBox("Validar","No se ha ingresado fecha de inicio",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				return false;
			}
			if(this.txtNota.Text.Length==0)
			{
				Helper.MsgBox("Validar","No se ha ingreso calificación",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				return false;
			}
			return true;
		}

		public bool ValidarCamposModificados()
		{

			if(this.txtNroRegistro.Text.Length==0)
			{
				Helper.MsgBox("Validar","No se ha ingresado Nro de registro",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				return false;
			}

			if(this.pCalFecha.Text.Length==0)
			{
				Helper.MsgBox("Validar","No se ha ingresado fecha de inicio",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				return false;
			}
			if(this.ptxtNota.Text.Length>0)
			{
				Helper.MsgBox("Validar","No se ha ingreso calificación",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				return false;
			}
			return true;
		}
		private void imgAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(ValidarCampos())
			{
				EvaluacionInduccionBE oEvaluacionInduccionBE= new EvaluacionInduccionBE();
				oEvaluacionInduccionBE.NroDNI = txtNroDNI.Text;
				oEvaluacionInduccionBE.FechaInicio = DateTime.Parse(txtFechaIni.Text);
				oEvaluacionInduccionBE.FechaVencimiento = DateTime.Parse(txtFechaVence.Text);
				oEvaluacionInduccionBE.Aprobado = ((Convert.ToInt32(this.txtNota.Text)>=Helper.ObtenerNotaInduccion())?true:false); 
				oEvaluacionInduccionBE.Nota = Convert.ToInt32(this.txtNota.Text);
				oEvaluacionInduccionBE.NroRegistro = this.txtNroRegistro.Text;
				/*Modificado:09-08-2023*/
				oEvaluacionInduccionBE.PeriodoProg = this.hPeriodoProg.Value;
				oEvaluacionInduccionBE.NroProgramacion = this.hNroProg.Value;
			
				string retorno = (new CCCTT_InduccionEvaluacion()).Insertar(oEvaluacionInduccionBE,true);
				if(retorno!="-1")
				{
					IDREG = retorno;
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad industrial",this.ToString(),"Se registró evaluacion de inducción. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
					txtNroDNI.Text="";
					txtFechaIni.Text="";
					txtFechaVence.Text="";
					txtApellidosyNombres.Text="";
					this.txtNota.Text="";
					this.txtNota.Text="";
					this.hPeriodoProg.Value="";
					this.hNroProg.Value="";
				}
			}
		}

		private void btnFiltar_Click(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}

		private void btnModifica_Click(object sender, System.EventArgs e)
		{
			strParam=ParamArgument.Split(';');
			//if(ValidarCamposModificados())
			{
				EvaluacionInduccionBE oEvaluacionInduccionBE= new EvaluacionInduccionBE();
				oEvaluacionInduccionBE.Periodo = this.Periodo;
				oEvaluacionInduccionBE.IdEvaluacion = this.IdEvaluacion;
				oEvaluacionInduccionBE.NroDNI = this.NroDNI;
				oEvaluacionInduccionBE.FechaInicio = this.FechaInicio;
				oEvaluacionInduccionBE.FechaVencimiento = this.FechaVencimiento;
				oEvaluacionInduccionBE.Aprobado =this.Aprobado;
				oEvaluacionInduccionBE.Nota = this.Nota;
				oEvaluacionInduccionBE.NroRegistro = this.NroRegistro;
			
				int retorno = (new CCCTT_InduccionEvaluacion()).Modificar(oEvaluacionInduccionBE);
				if(retorno>0)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad industrial",this.ToString(),"Se registró evaluacion de inducción. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
					ptxtNroDNI.Text="";
					ptxtApellidosyNombres.Text="";
					ptxtNota.Text="";
					pCalFecha.Text="";
					ptxtFechaVence.Text="";
					ptxtNroRegistro.Text="";
				}
			}
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.txtNroDNI.Text="";
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}

		private void ibtnEliminar_Click(object sender, System.EventArgs e)
		{
			strParam=ParamArgument.Split(';');
			if((new CCCTT_InduccionEvaluacion()).Eliminar(this.Periodo,this.IdEvaluacion)>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad",this.ToString(),"Se eliminó el Nro. " + this.Periodo.ToString() + ";" + this.IdEvaluacion.ToString() + "." ,Enumerados.NivelesErrorLog.I.ToString()));
				this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
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

		private void ptxtNroRegistro_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
