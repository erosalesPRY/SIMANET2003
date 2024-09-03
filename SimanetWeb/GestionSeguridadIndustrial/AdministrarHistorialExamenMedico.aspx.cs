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
	/// Summary description for AdministrarHistorialExamenMedico.
	/// </summary>
	public class AdministrarHistorialExamenMedico : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdExamen;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblTrabajador;
		protected System.Web.UI.WebControls.ImageButton ibtnDetalle;

		const string KEYQDNI ="NroDNI";
		const string KEYQPERIODO ="Periodo";
		const string KEYQIDEXAMEN ="idExa";
		const string KEYQNOMTRAB ="NomTrab";

		const string STYLEATTR ="text-decoration";
		const string STYLEVALOR ="line-through";

		private string NroDNI
		{
			get{return Page.Request.Params[KEYQDNI];}
		}
		private string ApellidosyNombres
		{
			get{return Page.Request.Params[KEYQNOMTRAB];}
		}

		const string URLDETALLE = "DetalleExamenMedico.aspx?";
		const string URLDETALLERESTRICCIONES = "AdministrarDetalleExamenMedico.aspx?";
		
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
			this.ibtnDetalle.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnDetalle_Click);
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
			// TODO:  Add AdministrarHistorialExamenMedico.LlenarGrillaOrdenamiento implementation
		}
		
		DataTable ObtenerDatos(){
			return(new CCCTT_ExamenMedicoHistorial()).ListarTodosGrilla(this.NroDNI);
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarHistorialExamenMedico.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarHistorialExamenMedico.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTrabajador.Text=this.ApellidosyNombres;
		}

		public void LlenarJScript()
		{
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hPeriodo","hIdExamen"));
			ibtnDetalle.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hPeriodo","hIdExamen"));

			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCION);			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarHistorialExamenMedico.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarHistorialExamenMedico.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarHistorialExamenMedico.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarHistorialExamenMedico.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarHistorialExamenMedico.ValidarFiltros implementation
			return false;
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
									+ KEYQIDEXAMEN + Utilitario.Constantes.SIGNOIGUAL + dr["IdExamen"].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON 
									+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + "M";

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
												Helper.HistorialIrAdelantePersonalizado("hIdExamen","hPeriodo"),Helper.MostrarVentana(URLDETALLE,parametros));
				if(dr["IdEstado"].ToString().Equals("2"))
				{
					e.Item.Cells[1].Style.Add(STYLEATTR,STYLEVALOR);
					e.Item.Cells[2].Style.Add(STYLEATTR,STYLEVALOR);
					e.Item.Cells[3].Style.Add(STYLEATTR,STYLEVALOR);
					e.Item.Cells[4].Style.Add(STYLEATTR,STYLEVALOR);
				}
				Label lbl = (Label)e.Item.Cells[6].FindControl("lblFechaInicio");
				lbl.Text = dr["FechaInicio"].ToString();

				lbl = (Label)e.Item.Cells[6].FindControl("lblFechaVence");
				lbl.Text = dr["FechaVencimiento"].ToString();

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hPeriodo",dr["Periodo"].ToString()),Helper.MostrarDatosEnCajaTexto("hIdExamen",dr["IdExamen"].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);

			}	
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(hPeriodo.Value.Length==0)
					{
						//ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
					}
					else
					{
						if((new CCCTT_ExamenMedico()).Eliminar(this.NroDNI,Convert.ToInt32(hPeriodo.Value),Convert.ToInt32(hIdExamen.Value))>0)
						{
							LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad industrial",this.ToString(),"Se eliminó registro de examen medico." ,Enumerados.NivelesErrorLog.I.ToString()));
							//ltlMensaje.Text = "alert('" + "Se elimino un registro de examen medico" + "');document.getElementById('ibtnAtras').onclick();";
							/*ltlMensaje.Text = Helper.MensajeRetornoAlert(
								Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString()
								,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROADENDAS));*/
							this.LlenarGrilla();
						}
					}
				}
			}
			catch(SIMAExcepcionLog oSIMAExcepcionLog)
			{
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
			}
			catch(SIMAExcepcionIU oSIMAExcepcionIU)
			{
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
			}
			catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
			{
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
			}
			catch(Exception oException)
			{
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string Parametros = KEYQDNI + Utilitario.Constantes.SIGNOIGUAL + this.NroDNI
								+ Utilitario.Constantes.SIGNOAMPERSON 
								+ KEYQNOMTRAB + Utilitario.Constantes.SIGNOIGUAL +  this.ApellidosyNombres
								+ Utilitario.Constantes.SIGNOAMPERSON 
								+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString();

			Page.Response.Redirect(URLDETALLE+ Parametros,false);
		}

		private void ibtnDetalle_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(this.hPeriodo.Value.Length!=0)
			{
				string Parametros = KEYQDNI + Utilitario.Constantes.SIGNOIGUAL + this.NroDNI
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.hPeriodo.Value
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQIDEXAMEN+ Utilitario.Constantes.SIGNOIGUAL + this.hIdExamen.Value;

				Page.Response.Redirect(URLDETALLERESTRICCIONES+ Parametros,false);
			}
			else{
				Helper.MsgBox("Detalle restricciones","No se ha seleccionado registro",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.INFO);
			}
		}

	}
}
