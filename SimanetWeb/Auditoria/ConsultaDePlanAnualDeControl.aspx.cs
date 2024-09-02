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
using SIMA.Controladoras.General;
using SIMA.Controladoras.Auditoria;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
namespace SIMA.SimaNetWeb.Auditoria
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class ConsultaDePlanAnualDeControl : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPeriodo;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnAtras;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		private   ListItem item =  new ListItem();

		#endregion Controles

		#region Constantes
		//Pies
		const string TEXTOFOOTERTOTAL    = "Total :";
		const int    POSICIONFOOTERTOTAL = 2;
		
		//Ordenamiento
		const string COLORDENAMIENTO = "IdProgramacionAuditoria	";

		//Columnas DataTable
	
		

		//Nombres de Controles
		const string CONTROLINK1 = "lblMes1";
		const string CONTROLINK2 = "lblMes2";
		const string CONTROLINK3 = "lblMes3";
		const string CONTROLINK4 = "lblMes4";
		const string CONTROLINK5 = "lblMes5";
		const string CONTROLINK6 = "lblMes6";
		const string CONTROLINK7 = "lblMes7";
		const string CONTROLINK8 = "lblMes8";
		const string CONTROLINK9 = "lblMes9";
		const string CONTROLINK10 = "lblMes10";
		const string CONTROLINK11 = "lblMes11";
		const string CONTROLINK12 = "lblMes12";
		
		
		//Paginas
		const string URLPRINCIPAL= "../Default.aspx";
		const string URLIMPRESION = "PopupImpresionConsultaDePlanAnualDeControl.aspx";
		const string URLFILTRO = "../Filtros.aspx";
		//Key Session y QueryString
		const string SESSIONPERIODO = "Periodo";
		//Otros
		const string GRILLAVACIA ="No existe ninguna Auditoria en Curso.";  

		//FILTRO
		const string COLUMNACODIGO = "Codigo";
		const string COLUMNADENOMINACION ="Denominacion";
		const string COLUMNAUNIDADMEDIDA ="UnidadMedida";
		const string COLUMNAPORCAVANCE ="PorcAvance";

		#endregion Constantes

		#region Variables

		
		#endregion Variables


		
		/// <summary>
		/// Llena el combo de Periodos
		/// </summary>
		private void llenarPeriodos()
		{
			ListItem lItem = new ListItem(Constantes.TEXTOSSELECCIONAR,Constantes.VALORSELECCIONAR);
			ddlbPeriodo.DataSource = Helper.ObtenerPeriodos(DateTime.Now.Year - 5,DateTime.Now.Year);
			ddlbPeriodo.DataBind();
			//ddlbPeriodo.Items.Insert(0,lItem);
		}
			
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					this.LlenarJScript();

					Helper.ReiniciarSession();

					this.LlenarCombos();

					if (Session[SESSIONPERIODO]==null)
						Session[SESSIONPERIODO] = DateTime.Now.Year.ToString();
					else
					{
						item = this.ddlbPeriodo.Items.FindByText(Session[SESSIONPERIODO].ToString());
						if(item!=null)
						{item.Selected = true;}

					}

					if(this.ValidarFiltros())
					{
						//Graba en el Log la acción ejecutada
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó el Plan Anual de Control del Periodo " + ddlbPeriodo.SelectedValue + ".",Enumerados.NivelesErrorLog.I.ToString()));
						this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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
			this.ddlbPeriodo.SelectedIndexChanged += new System.EventHandler(this.ddlbPeriodo_SelectedIndexChanged);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.ibtnAtras.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAtras_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
		}

		
		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			CProgramacionAuditoria oCProgramacionAuditoria =  new CProgramacionAuditoria();			
			DataTable dtProgramacionAuditoria =  oCProgramacionAuditoria.ConsultarProgramacionAuditoria(Session[SESSIONPERIODO].ToString());
			//this.LlenarDatos();
			
			if(dtProgramacionAuditoria!=null)
			{
				DataView dwProgramacionAuditoria = dtProgramacionAuditoria.DefaultView;
				dwProgramacionAuditoria.Sort = columnaOrdenar ;
				dwProgramacionAuditoria.RowFilter= Utilitario.Helper.ObtenerFiltro(this);
				grid.DataSource = dwProgramacionAuditoria;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtProgramacionAuditoria,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEPLANANUALCONTROL),columnaOrdenar,indicePagina);
				lblResultado.Visible = false;
				grid.Columns[1].FooterText = TEXTOFOOTERTOTAL;
				grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwProgramacionAuditoria.Count.ToString();
			}
			else
			{
				grid.DataSource = dtProgramacionAuditoria;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarCombos implementation
			this.llenarPeriodos();
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation

			string mensaje = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPERIODO);
			rfvPeriodo.ErrorMessage = mensaje;
			rfvPeriodo.ToolTip = mensaje;
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaDeCartasFianzas.Exportar implementation
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
			if(ddlbPeriodo.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPERIODO));
				return false;	
			}

			return true;
		}

		#endregion

		

		
		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[2].Text = e.Item.Cells[2].Text.ToUpper();
				e.Item.Cells[3].Text = e.Item.Cells[3].Text.ToUpper();

				ImageButton img=(ImageButton)e.Item.Cells[19].FindControl("ibtnObservacion");
				img.Attributes.Add("Onclick", Helper.MostrarVentaModalTextoHTML("ACTIVIDAD DE CONTROL: " + dr[Enumerados.ColumnasProgramacionAuditoria.Denominacion.ToString()].ToString().ToUpper(), dr[Enumerados.ColumnasProgramacionAuditoria.Observacion.ToString()].ToString().ToUpper(), 400, 600 ));
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				if(Helper.ObtenerValorBool(dr[Enumerados.ColumnasProgramacionAuditoria.FlgEnero.ToString()].ToString()))
				{
					Label lbl1 = (Label)e.Item.Cells[6].FindControl(CONTROLINK1);
					lbl1.Text = Constantes.SIGNOX;
				}
				if(Helper.ObtenerValorBool(dr[Enumerados.ColumnasProgramacionAuditoria.FlgFebrero.ToString()].ToString()))
				{
					Label lbl2 = (Label)e.Item.Cells[7].FindControl(CONTROLINK2);
					lbl2.Text = Constantes.SIGNOX;
				}
				if(Helper.ObtenerValorBool(dr[Enumerados.ColumnasProgramacionAuditoria.FlgMarzo.ToString()].ToString()))
				{
					Label lbl3 = (Label)e.Item.Cells[8].FindControl(CONTROLINK3);
					lbl3.Text = Constantes.SIGNOX;
				}
				if(Helper.ObtenerValorBool(dr[Enumerados.ColumnasProgramacionAuditoria.FlgAbril.ToString()].ToString()))
				{
					Label lbl4 = (Label)e.Item.Cells[9].FindControl(CONTROLINK4);
					lbl4.Text = Constantes.SIGNOX;
				}
				if(Helper.ObtenerValorBool(dr[Enumerados.ColumnasProgramacionAuditoria.FlgMayo.ToString()].ToString()))
				{
					Label lbl5 = (Label)e.Item.Cells[10].FindControl(CONTROLINK5);
					lbl5.Text = Constantes.SIGNOX;
				}
				if(Helper.ObtenerValorBool(dr[Enumerados.ColumnasProgramacionAuditoria.FlgJunio.ToString()].ToString()))
				{
					Label lbl6 = (Label)e.Item.Cells[11].FindControl(CONTROLINK6);
					lbl6.Text = Constantes.SIGNOX;
				}
				if(Helper.ObtenerValorBool(dr[Enumerados.ColumnasProgramacionAuditoria.FlgJulio.ToString()].ToString()))
				{
					Label lbl7 = (Label)e.Item.Cells[12].FindControl(CONTROLINK7);
					lbl7.Text = Constantes.SIGNOX;
				}
				if(Helper.ObtenerValorBool(dr[Enumerados.ColumnasProgramacionAuditoria.FlgAgosto.ToString()].ToString()))
				{
					Label lbl8 = (Label)e.Item.Cells[13].FindControl(CONTROLINK8);
					lbl8.Text = Constantes.SIGNOX;
				}
				if(Helper.ObtenerValorBool(dr[Enumerados.ColumnasProgramacionAuditoria.FlgSeptiembre.ToString()].ToString()))
				{
					Label lbl9 = (Label)e.Item.Cells[14].FindControl(CONTROLINK9);
					lbl9.Text = Constantes.SIGNOX;
				}
				if(Helper.ObtenerValorBool(dr[Enumerados.ColumnasProgramacionAuditoria.FlgOctubre.ToString()].ToString()))
				{
					Label lbl10 = (Label)e.Item.Cells[15].FindControl(CONTROLINK10);
					lbl10.Text = Constantes.SIGNOX;
				}
				if(Helper.ObtenerValorBool(dr[Enumerados.ColumnasProgramacionAuditoria.FlgNoviembre.ToString()].ToString()))
				{
					Label lbl11 = (Label)e.Item.Cells[16].FindControl(CONTROLINK11);
					lbl11.Text = Constantes.SIGNOX;
				}
				if(Helper.ObtenerValorBool(dr[Enumerados.ColumnasProgramacionAuditoria.FlgDiciembre.ToString()].ToString()))
				{
					Label lbl12 = (Label)e.Item.Cells[17].FindControl(CONTROLINK12);
					lbl12.Text = Constantes.SIGNOX;
				}

				e.Item.Cells[1].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

			}	
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
			Session[SESSIONPERIODO] = this.ddlbPeriodo.SelectedValue;
			try
			{
				Helper.ReiniciarSession();

				if(this.ValidarFiltros())
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó el Plan Anual de Control del Periodo " + ddlbPeriodo.SelectedValue + ".",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{

			CProgramacionAuditoria oCProgramacionAuditoria =  new CProgramacionAuditoria();
			DataTable dtProgramacionAuditoria =  oCProgramacionAuditoria.ConsultarProgramacionAuditoria(Session["Periodo"].ToString());

			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this
				,dtProgramacionAuditoria
				,URLFILTRO
				,COLUMNACODIGO + ";CODIGO"
				,COLUMNADENOMINACION + ";DENOMINACION"
				,Utilitario.Constantes.SIGNOASTERISCO + COLUMNAUNIDADMEDIDA + ";UM"
				,Utilitario.Constantes.SIGNOASTERISCO + COLUMNAPORCAVANCE + ";" + Utilitario.Constantes.SIGNOPORCENTAJE);
	
		}

		private void ddlbPeriodo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[SESSIONPERIODO] = this.ddlbPeriodo.SelectedValue;
			try
			{
				Helper.ReiniciarSession();

				if(this.ValidarFiltros())
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó el Plan Anual de Control del Periodo " + ddlbPeriodo.SelectedValue + ".",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		
		}

		private void ibtnAtras_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

	}
}

