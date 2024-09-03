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

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for AdministrarHistorialInduccionSI.
	/// </summary>
	public class AdministrarHistorialInduccionSI : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento		
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblTrabajador;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdevaluacion;

		const string KEYQDNI ="NroDNI";
		const string KEYQPERIODO ="Periodo";
		const string KEYQIDEVALUACION ="idEva";
		const string KEYQNOMTRAB ="NomTrab";

		const string KEYQPERIODOEM ="PeriodoEM";
		const string KEYQIDEXAMENEM ="idExaEM";
		

		const string STYLEATTR ="text-decoration";
		const string STYLEVALOR ="line-through";

		private string NroDNI
		{
			get{return Page.Request.Params[KEYQDNI];}
		}

		private int PeriodoEM
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODOEM]);}
		}

		private int IdExamenEM
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDEXAMENEM]);}
		}


		private string ApellidosyNombres
		{
			get{return Page.Request.Params[KEYQNOMTRAB];}
		}

		const string URLDETALLE = "DetalleEvaluacionInduccionSI.aspx?";
		string JSVERIFICARSELECCION = "return verificarSeleccionRb('hPeriodo','debe seleccionar un registro');";
		


		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Programación Personal Contratista", this.ToString(),"Se consultó El Listado de las programaciones de los contratistas",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina();
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
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				string parametros =KEYQDNI + Utilitario.Constantes.SIGNOIGUAL + this.NroDNI
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + dr["Periodo"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDEVALUACION + Utilitario.Constantes.SIGNOIGUAL + dr["Idevaluacion"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + "M";

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado("hIdevaluacion","hPeriodo"),Helper.MostrarVentana(URLDETALLE,parametros));



				if(dr["Aprobado"].ToString().Equals("0"))
				{
					e.Item.Cells[1].Style.Add(STYLEATTR,STYLEVALOR);
				}

				Label lbl = (Label)e.Item.Cells[3].FindControl("lblFechaInicio");
				lbl.Text = dr["FechaInicio"].ToString();

				lbl = (Label)e.Item.Cells[3].FindControl("lblFechaVence");
				lbl.Text = dr["FechaVencimiento"].ToString();

				CheckBox chk =(CheckBox)e.Item.Cells[2].FindControl("ChkAprobado");
				chk.Checked = ((dr["Aprobado"].ToString()=="1")?true:false);

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hPeriodo",dr["Periodo"].ToString()),Helper.MostrarDatosEnCajaTexto("hIdevaluacion",dr["Idevaluacion"].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);

			}	
		}

		

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarHistorialInduccionSI.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarHistorialInduccionSI.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarHistorialInduccionSI.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarHistorialInduccionSI.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarHistorialInduccionSI.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarHistorialInduccionSI.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarHistorialInduccionSI.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarHistorialInduccionSI.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarHistorialInduccionSI.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarHistorialInduccionSI.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		#region IPaginaBase Members

		DataTable ObtenerDatos()
		{
			return(new CCCTT_InduccionEvaluacion()).ListarTodosGrilla(this.NroDNI);
		}
		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
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
			// TODO:  Add AdministrarHistorialInduccionSI.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarHistorialInduccionSI.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarHistorialInduccionSI.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTrabajador.Text=this.ApellidosyNombres;
		}

		public void LlenarJScript()
		{
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hPeriodo","hIdevaluacion"));
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCION);	
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarHistorialInduccionSI.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarHistorialInduccionSI.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarHistorialInduccionSI.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarHistorialInduccionSI.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarHistorialInduccionSI.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string Parametros = KEYQDNI + Utilitario.Constantes.SIGNOIGUAL + this.NroDNI
				+ Utilitario.Constantes.SIGNOAMPERSON 
				+ KEYQNOMTRAB + Utilitario.Constantes.SIGNOIGUAL +  this.ApellidosyNombres
				+ Utilitario.Constantes.SIGNOAMPERSON 
				+ KEYQPERIODOEM + Utilitario.Constantes.SIGNOIGUAL +  this.PeriodoEM
				+ Utilitario.Constantes.SIGNOAMPERSON 
				+ KEYQIDEXAMENEM + Utilitario.Constantes.SIGNOIGUAL +  this.IdExamenEM
				+ Utilitario.Constantes.SIGNOAMPERSON 
				+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString();

			Page.Response.Redirect(URLDETALLE+ Parametros,false);
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
						this.eliminar();
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


		void eliminar()
		{
			if(hPeriodo.Value.Length==0)
			{
				Helper.MsgBox("No se ha seleccionado registro a ser eliminado");
			}
			else
			{
				if((new CCCTT_InduccionEvaluacion()).Eliminar(Convert.ToInt32(hPeriodo.Value),Convert.ToInt32(hIdevaluacion.Value))>0)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Personal",this.ToString(),"Se eliminó el Nro. " + hPeriodo.Value + ";" + hIdevaluacion.Value + "." ,Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrilla();
				}
			}

		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
	
}

