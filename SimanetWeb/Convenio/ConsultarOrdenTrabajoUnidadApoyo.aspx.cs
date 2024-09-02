using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.Convenio;
using SIMA.Controladoras.General;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Summary description for ConsultarOrdenTrabajoUnidadApoyo.
	/// </summary>
	public class ConsultarOrdenTrabajoUnidadApoyo : System.Web.UI.Page, IPaginaBase
	{
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb dgOrdenTrabajo;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Label lblTituloSecundario;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.TextBox TextBox8;
		protected System.Web.UI.WebControls.TextBox TextBox9;
		protected System.Web.UI.WebControls.Label lblTrabajo;
		protected System.Web.UI.WebControls.Label lblRepuesto;
		protected System.Web.UI.WebControls.Label lblAprobado;
		protected System.Web.UI.WebControls.Label lblEjecutado;
		protected System.Web.UI.WebControls.Label lblEnEjecucion;
		protected System.Web.UI.WebControls.ImageButton ibtnTrabajo;
		protected System.Web.UI.WebControls.ImageButton ibtnRepuesto;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	
		
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
			this.dgOrdenTrabajo.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgOrdenTrabajo_SortCommand);
			this.dgOrdenTrabajo.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgOrdenTrabajo_PageIndexChanged);
			this.dgOrdenTrabajo.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgOrdenTrabajo_ItemDataBound);
			this.dgOrdenTrabajo.SelectedIndexChanged += new System.EventHandler(this.dgOrdenTrabajo_SelectedIndexChanged);
			this.ibtnTrabajo.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnTrabajo_Click);
			this.ibtnRepuesto.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnRepuesto_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarDatos();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Convenio Sima - MGP",this.ToString(),"Se consultó las Ordenes de Trabajo.",Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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
			//this.reiniciarCampos();
		}

		#region Constantes
		const string COLORDENAMIENTO="NroOrdenTrabajo";
		const string GRILLAVACIA="No hay Ordenes de Trabajo del Periodo Consultado";

		//KEY y SESION
		const string KEYIDPERIODOUNIDADESAPOYO="IdPeriodoUnidadesApoyo";
		const string KEYQPERIODO="Periodo";
		const string KEYIDORDENTRABAJOUNIDADAPOYO="IdOrdenTrabajoUnidadApoyo";
		const string KEYQNROORDENTRABAJO="NroOrdenTrabajo";
		const string KEYQTIPOACTIVIDADORDENTRABAJO="IdTipoActividad";

		//CONTROLES
		const string CONTROLINK="hlkID";
		const string URLPRINCIPAL="ConsultarPeriodoUnidadesApoyo.aspx";
		const string URLANTERIOR="ConsultarPeriodoUnidadesApoyo.aspx?";

		//URL
		const string URLACTIVIDADORDENTRABAJOCOMOPERPAC="ActividadesOrdenTrabajoComoperpac.aspx?";

		
		#endregion

		#region Valiables		
		private double acumMontoAsignadoSoles=0;
		private double acumMontoAprobado=0;
		private double acumMontoEjecutado=0;
		private double acumMontoEnEjecucion=0;
		private double acumMontoSaldo=0;
		
		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";

		#endregion Variables

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarOrdenTrabajoUnidadApoyo.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarOrdenTrabajoUnidadApoyo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CPeriodoUnidadesApoyo oCPeriodoUnidadesApoyo = new CPeriodoUnidadesApoyo();
			DataTable dtOrdenTrabajo = oCPeriodoUnidadesApoyo.ConsultarOrdenesDeTrabajoDeUnPeriodoDeUnidadesDeApoyo(Convert.ToInt32(Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO]));
			
			this.LimpiarControlesDatos();

			if(dtOrdenTrabajo!=null)
			{
				DataView dwOrdenTrabajo = dtOrdenTrabajo.DefaultView;
				dwOrdenTrabajo.Sort = columnaOrdenar;
				dgOrdenTrabajo.DataSource = dwOrdenTrabajo;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtOrdenTrabajo,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				lblResultado.Visible = false;
				dgOrdenTrabajo.Columns[2].FooterText = dwOrdenTrabajo.Count.ToString();

			}
			else
			{
				dgOrdenTrabajo.DataSource = dtOrdenTrabajo;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				dgOrdenTrabajo.DataBind();
			}
			catch	
			{
				dgOrdenTrabajo.CurrentPageIndex = 0;
				dgOrdenTrabajo.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarOrdenTrabajoUnidadApoyo.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text="UNIDADES DE APOYO COMOPERPAC PERIODO " + Convert.ToString(this.Page.Request.Params[KEYQPERIODO]);
			this.ibtnTrabajo.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnRepuesto.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
		}

		public void LlenarJScript()
		{
			this.ibtnTrabajo.Attributes.Add("onclick",JSVERIFICARSELECCIONFILA);
			this.ibtnRepuesto.Attributes.Add("onclick",JSVERIFICARSELECCIONFILA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarOrdenTrabajoUnidadApoyo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarOrdenTrabajoUnidadApoyo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarOrdenTrabajoUnidadApoyo.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{
				CNetAccessControl.LoadControls(this);
			}
			else
			{
				
				CNetAccessControl.RedirectPageError();
				
			}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarOrdenTrabajoUnidadApoyo.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void dgOrdenTrabajo_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				CFuncionesEspeciales oCFuncionesEspeciales=new CFuncionesEspeciales();

				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				HyperLink hlk = (HyperLink)e.Item.Cells[2].FindControl(CONTROLINK);
				hlk.Text = Convert.ToString(dr[Enumerados.OrdenTrabajoUnidadApoyo.NroOrdenTrabajo.ToString()]);
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor=Color.Blue;

				string cadenaUrl;
				cadenaUrl = URLACTIVIDADORDENTRABAJOCOMOPERPAC + KEYIDORDENTRABAJOUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL +
							Convert.ToString(dr[Enumerados.OrdenTrabajoUnidadApoyo.IdOrdenTrabajoUnidadApoyo.ToString()]) + Utilitario.Constantes.SIGNOAMPERSON +
							KEYQNROORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.OrdenTrabajoUnidadApoyo.NroOrdenTrabajo.ToString()]) + Utilitario.Constantes.SIGNOAMPERSON +
							KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO] + Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO]  + Utilitario.Constantes.SIGNOAMPERSON +
							KEYQTIPOACTIVIDADORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL;

				hlk.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
				hlk.NavigateUrl=cadenaUrl + Convert.ToInt32(Enumerados.TipoActividadOrdenTrabajoComoperpac.Trabajos).ToString();
				

				string cadena="";
								cadena="LlenarControlesHtml('"
									+ Convert.ToDouble(dr[Utilitario.Enumerados.OrdenTrabajoUnidadApoyo.MontoAprobadoTrabajo.ToString()].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "','"
									+ Convert.ToDouble(dr[Utilitario.Enumerados.OrdenTrabajoUnidadApoyo.MontoEjecutadoTrabajo.ToString()].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "','"
									+ Convert.ToDouble(dr[Utilitario.Enumerados.OrdenTrabajoUnidadApoyo.MontoEnEjecucionTrabajo.ToString()].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "','"
									+ Convert.ToDouble(dr[Utilitario.Enumerados.OrdenTrabajoUnidadApoyo.MontoAprobadoRepuesto.ToString()].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "','"
									+ Convert.ToDouble(dr[Utilitario.Enumerados.OrdenTrabajoUnidadApoyo.MontoEjecutadoRepuesto.ToString()].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "','"
									+ Convert.ToDouble(dr[Utilitario.Enumerados.OrdenTrabajoUnidadApoyo.MontoEnEjecucionRepuesto.ToString()].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "'); ";

									

				cadena = cadena + " LlenarControlesWebFormNet('"
								   + Helper.LimpiarTexto(dr[Utilitario.Enumerados.OrdenTrabajoUnidadApoyo.Descripcion.ToString()].ToString()) + "','"
								   + Helper.LimpiarTexto(dr[Utilitario.Enumerados.OrdenTrabajoUnidadApoyo.Observaciones.ToString()].ToString()) + "'); ";

				cadena = cadena + " MostrarDatosEnCajaTexto('hCodigo','" + cadenaUrl + "'); ";
					
				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,cadena);
				e.Item.Cells[1].Text = Helper.ObtenerIndicedeRegistro(dgOrdenTrabajo.CurrentPageIndex,dgOrdenTrabajo.PageSize,e.Item.ItemIndex);
				

				//this.acumMontoAsignado=this.acumMontoAsignado + oCFuncionesEspeciales.EsNulo(dr[Utilitario.Enumerados.OrdenTrabajoUnidadApoyo.MontoAsignado.ToString()],0);
				this.acumMontoAsignadoSoles=this.acumMontoAsignadoSoles + NullableTypes.NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.OrdenTrabajoUnidadApoyo.MontoAsignadoSoles.ToString()],0);
				this.acumMontoAprobado=this.acumMontoAprobado + NullableTypes.NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.OrdenTrabajoUnidadApoyo.MontoAprobado.ToString()],0);
				this.acumMontoEjecutado=this.acumMontoEjecutado + NullableTypes.NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.OrdenTrabajoUnidadApoyo.MontoEjecutado.ToString()],0);
				this.acumMontoEnEjecucion=this.acumMontoEnEjecucion + NullableTypes.NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.OrdenTrabajoUnidadApoyo.MontoEnEjecucion.ToString()],0);
				this.acumMontoSaldo=this.acumMontoSaldo + NullableTypes.NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.OrdenTrabajoUnidadApoyo.MontoSaldo.ToString()],0);

				double MontoSaldo=NullableTypes.NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.OrdenTrabajoUnidadApoyo.MontoSaldo.ToString()],0);
				Helper.ColorTextoGrillaCeldaTextoValorNegativo(MontoSaldo,8,e);


			}
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				//e.Item.Cells[2].Text=Utilitario.Constantes.TEXTOTOTAL;
				//e.Item.Cells[3].Text=this.acumMontoAsignado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text=Utilitario.Constantes.TEXTOTOTAL;
				e.Item.Cells[4].Text=this.acumMontoAsignadoSoles.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text=this.acumMontoAprobado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[6].Text=this.acumMontoEjecutado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[7].Text=this.acumMontoEnEjecucion.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[8].Text=this.acumMontoSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void dgOrdenTrabajo_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());

		}

		private void LimpiarControlesDatos()
		{
			this.txtDescripcion.Text="";
			this.txtObservaciones.Text="";
		}

		private void RegresarPaginaPrevia()
		{
			this.Page.Response.Redirect(URLPRINCIPAL);
		}


		private void RedireccionarActividades(int IdTipoActividad)
		{
			this.Page.Response.Redirect(this.hCodigo.Value + IdTipoActividad.ToString());
		}

		private void reiniciarCampos()
		{
			//this.hCodigo.Value="";
		}

		private void ibtnTrabajo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.RedireccionarActividades(Convert.ToInt32(Utilitario.Enumerados.TipoActividadOrdenTrabajoComoperpac.Trabajos));
		}

		private void ibtnRepuesto_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.RedireccionarActividades(Convert.ToInt32(Utilitario.Enumerados.TipoActividadOrdenTrabajoComoperpac.CompraRepuesto));
		}

		private void dgOrdenTrabajo_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgOrdenTrabajo.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void dgOrdenTrabajo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	

	}
}