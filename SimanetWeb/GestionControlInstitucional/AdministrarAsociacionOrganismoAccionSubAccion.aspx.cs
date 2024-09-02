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
using SIMA.Controladoras.Parametros;
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for AdministrarAsociacionOrganismoAccionSubAccion.
	/// </summary>
	public class AdministrarAsociacionOrganismoAccionSubAccion : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region controles
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddblOrganismo;
		protected System.Web.UI.WebControls.DropDownList ddblSubOrganismo2;
		protected projDataGridWeb.DataGridWeb gridSubOrganismo;
		protected System.Web.UI.WebControls.DropDownList ddblSubOrganismo;
		protected System.Web.UI.WebControls.DropDownList ddblOrganismo2;
		protected System.Web.UI.WebControls.DropDownList ddblAccionControl;
		protected System.Web.UI.WebControls.DropDownList ddblSubOrganismo3;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected projDataGridWeb.DataGridWeb gridAccionControl;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCabeceraTablaTablas;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCabeceraTablaTablas2;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellOrganismo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblResultado2;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellSubOrganismo;
		protected System.Web.UI.WebControls.Literal ltlMensaje; 
		#endregion controles
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					
					this.ConfigurarAccesoControles();
					this.LlenarDatos();
					this.LlenarJScript();
					this.LlenarCombos();
					Helper.ReiniciarSession();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se consultó las Programaciones de Inspecciones.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
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
			this.ddblOrganismo.SelectedIndexChanged += new System.EventHandler(this.ddblOrganismo_SelectedIndexChanged);
			this.ddblSubOrganismo2.SelectedIndexChanged += new System.EventHandler(this.ddblSubOrganismo2_SelectedIndexChanged);
			this.gridSubOrganismo.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.gridSubOrganismo_ItemCommand);
			this.gridSubOrganismo.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridSubOrganismo_PageIndexChanged);
			this.gridSubOrganismo.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridSubOrganismo_ItemDataBound);
			this.gridAccionControl.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.gridAccionControl_ItemCommand);
			this.gridAccionControl.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridAccionControl_PageIndexChanged);
			this.gridAccionControl.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridAccionControl_ItemDataBound);
			this.ddblSubOrganismo.SelectedIndexChanged += new System.EventHandler(this.ddblSubOrganismo_SelectedIndexChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			LlenarGrillaSubOrganismos(columnaOrdenar,indicePagina);
			LlenarGrillaAccionesControl(columnaOrdenar,indicePagina);

		}

		public void LlenarCombos()
		{
			llenarOrganismos();
			llenarSubOrganismos();
			llenarAccionesControl();

		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			int retorno=0;
			CControlInstitucional oCControlInstitucional = new CControlInstitucional();

			if(ddblSubOrganismo.Enabled==false && ddblAccionControl.Enabled==false)
			{
				retorno = oCControlInstitucional.InsertarAsociacionSubOrganismoXOrganismo(Convert.ToInt32(ddblOrganismo2.SelectedValue),
					Convert.ToInt32(ddblSubOrganismo3.SelectedValue),
					Convert.ToInt32(ddblAccionControl.SelectedValue),
					Convert.ToInt32(ddblOrganismo.SelectedValue),
					Convert.ToInt32(ddblSubOrganismo2.SelectedValue));

			}
			else if(ddblSubOrganismo.Enabled==true && ddblAccionControl.Enabled==false)
			{
				retorno = oCControlInstitucional.InsertarAsociacionSubOrganismoXOrganismo(Convert.ToInt32(ddblOrganismo.SelectedValue),
					Convert.ToInt32(ddblSubOrganismo3.SelectedValue),
					Convert.ToInt32(ddblAccionControl.SelectedValue),
					-1,
					Convert.ToInt32(ddblSubOrganismo2.SelectedValue));

			}
			else if(ddblSubOrganismo.Enabled==false && ddblAccionControl.Enabled==true)
			{
				retorno = oCControlInstitucional.InsertarAsociacionSubOrganismoXOrganismo(Convert.ToInt32(ddblOrganismo2.SelectedValue),
					Convert.ToInt32(ddblSubOrganismo3.SelectedValue),
					Convert.ToInt32(ddblAccionControl.SelectedValue),
					Convert.ToInt32(ddblOrganismo.SelectedValue),
					-1);

			}
			else
			{
				retorno = oCControlInstitucional.InsertarAsociacionSubOrganismoXOrganismo(Convert.ToInt32(ddblOrganismo.SelectedValue),
					Convert.ToInt32(ddblSubOrganismo.SelectedValue),
					Convert.ToInt32(ddblAccionControl.SelectedValue),-1,-1);
			}
			if(retorno==2)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se registró el Documento Auditoria Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				
				this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
				ddblOrganismo2.Enabled=false;
			
				ddblSubOrganismo3.SelectedValue=ddblSubOrganismo2.SelectedValue;
				ddblSubOrganismo3.Enabled=false;
				
				ltlMensaje.Text = Helper.MensajeAlert("Se Asocio con exito");
			}
			else
			{
				ltlMensaje.Text = Helper.MensajeAlert("Asociacion existente, vuelva a seleccionar");
			}
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarAsociacionOrganismoAccionSubAccion.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
		private void llenarOrganismos()
		{
			CParametros oCParametros=  new CParametros();
			DataTable dt =  oCParametros.ConsultarParametrosPorTipodeTabla(316);
			if(dt!=null)
			{
				ddblOrganismo.DataSource=dt;
				ddblOrganismo.DataValueField="codigo";
				ddblOrganismo.DataTextField="descripcion";
				ddblOrganismo.DataBind();
				
				ddblOrganismo2.DataSource=dt;
				ddblOrganismo2.DataValueField="codigo";
				ddblOrganismo2.DataTextField="descripcion";
				ddblOrganismo2.DataBind();

			}
		}
		private void llenarSubOrganismos()
		{
			CParametros oCParametros=  new CParametros();
			DataTable dt =  oCParametros.ConsultarParametrosPorTipodeTabla(390);
			if(dt!=null)
			{
				ddblSubOrganismo.DataSource=dt;
				ddblSubOrganismo.DataValueField="codigo";
				ddblSubOrganismo.DataTextField="descripcion";
				ddblSubOrganismo.DataBind();
				
				ddblSubOrganismo2.DataSource=dt;
				ddblSubOrganismo2.DataValueField="codigo";
				ddblSubOrganismo2.DataTextField="descripcion";
				ddblSubOrganismo2.DataBind();
				
				ddblSubOrganismo3.DataSource=dt;
				ddblSubOrganismo3.DataValueField="codigo";
				ddblSubOrganismo3.DataTextField="descripcion";
				ddblSubOrganismo3.DataBind();


			}
		}
		private void llenarAccionesControl()
		{
			CParametros oCParametros=  new CParametros();
			DataTable dt =  oCParametros.ConsultarParametrosPorTipodeTabla(391);
			if(dt!=null)
			{
				ddblAccionControl.DataSource=dt;
				ddblAccionControl.DataValueField="codigo";
				ddblAccionControl.DataTextField="descripcion";
				ddblAccionControl.DataBind();
			

			}
		}

		private void ddblOrganismo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ddblSubOrganismo.Enabled=true;
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void ddblSubOrganismo2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ddblAccionControl.Enabled=true;
			//ddblSubOrganismo.SelectedValue=ddblSubOrganismo2.SelectedValue;
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
		}
		public void LlenarGrillaSubOrganismos(string columnaOrdenar, int indicePagina)
		{
			CControlInstitucional oCControlInstitucional = new CControlInstitucional();
			DataTable dt = oCControlInstitucional.llenarGrillaSubOrganismoXOrganismo(Convert.ToInt32(ddblOrganismo.SelectedValue));
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.Sort = columnaOrdenar ;
				gridSubOrganismo.DataSource = dw;
				gridSubOrganismo.CurrentPageIndex =indicePagina;

				gridSubOrganismo.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				gridSubOrganismo.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dw.Count.ToString();
				lblResultado.Visible=false;
				ddblOrganismo2.Visible=true;
				ddblSubOrganismo.Enabled=true;
				ddblOrganismo2.Enabled=false;
	
				
			}
			else
			{
				gridSubOrganismo.DataSource = dt;
				lblResultado.Visible=true;
				lblResultado.Text = "No existen Registros";
				ddblOrganismo2.Enabled=false;
				ddblSubOrganismo.Enabled=true;
				//CellOrganismo.InnerText=ddblOrganismo.SelectedItem.Text.ToString();

			}
			
			try
			{
				gridSubOrganismo.DataBind();
			}
			catch (Exception a)
			{
				string b = a.Message.ToString();
				gridSubOrganismo.CurrentPageIndex = 0;
				gridSubOrganismo.DataBind();
			}

		}

		public void LlenarGrillaAccionesControl(string columnaOrdenar, int indicePagina)
		{
			CControlInstitucional oCControlInstitucional = new CControlInstitucional();
			DataTable dt = oCControlInstitucional.llenarGrillaAccionControlXSubOrganismo(Convert.ToInt32(ddblSubOrganismo2.SelectedValue));
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.Sort = columnaOrdenar ;
				gridAccionControl.DataSource = dw;
				gridAccionControl.CurrentPageIndex =indicePagina;

				gridAccionControl.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				gridAccionControl.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dw.Count.ToString();
				ddblSubOrganismo3.Visible=true;
				ddblAccionControl.Enabled=true;
				lblResultado2.Visible=false;
				
				
			}
			else
			{
				gridAccionControl.DataSource = dt;
				lblResultado2.Visible=true;
				lblResultado2.Text = "No existen Registros";
				ddblSubOrganismo3.Enabled=false;
				ddblAccionControl.Enabled=true;
				//CellSubOrganismo.InnerText=ddblSubOrganismo2.SelectedItem.Text.ToString();


			}
			
			try
			{
				gridAccionControl.DataBind();
			}
			catch (Exception a)
			{
				string b = a.Message.ToString();
				gridAccionControl.CurrentPageIndex = 0;
				gridAccionControl.DataBind();
			}

		}

		private void gridSubOrganismo_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr["codigo"].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hIdCabeceraTablaTablas",dr["IdCabeceraTablaTablas"].ToString()));

				Button btn =(Button)e.Item.Cells[0].FindControl("Button1");
				btn.Text=Helper.ObtenerIndicedeRegistro(gridSubOrganismo.CurrentPageIndex,gridSubOrganismo.PageSize,e.Item.ItemIndex);
				btn.Font.Underline=true;
				btn.ForeColor= System.Drawing.Color.Blue;
				btn.Style.Add("cursor","hand");
				e.Item.Cells[0].Style.Add("cursor","hand");
				
			}	
		}

		private void gridAccionControl_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo2",dr["codigo"].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hIdCabeceraTablaTablas2",dr["IdCabeceraTablaTablas"].ToString()));

				Button btn =(Button)e.Item.Cells[0].FindControl("Button2");
				btn.Text=Helper.ObtenerIndicedeRegistro(gridAccionControl.CurrentPageIndex,gridAccionControl.PageSize,e.Item.ItemIndex);
				btn.Font.Underline=true;
				btn.ForeColor= System.Drawing.Color.Blue;
				btn.Style.Add("cursor","hand");
				e.Item.Cells[0].Style.Add("cursor","hand");
				
			}	
		}

		private void gridSubOrganismo_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,e.NewPageIndex);		
		}

		private void gridAccionControl_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,e.NewPageIndex);		
		}

		private void gridSubOrganismo_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
				ddblOrganismo2.SelectedValue=ddblOrganismo.SelectedValue;
				ddblSubOrganismo2.SelectedValue=hCodigo.Value;
				ddblOrganismo2.Enabled=true;
				ddblSubOrganismo.SelectedValue=hCodigo.Value;
				ddblSubOrganismo.Enabled=false;
				
				
					
		}

		private void gridAccionControl_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			ddblSubOrganismo3.SelectedValue=ddblSubOrganismo2.SelectedValue;
			ddblSubOrganismo3.Enabled=true;
			ddblAccionControl.SelectedValue=hCodigo2.Value;
			ddblAccionControl.Enabled=false;
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						
								this.Agregar();
							
						
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

		private void ddblSubOrganismo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ddblSubOrganismo2.SelectedValue=ddblSubOrganismo.SelectedValue;
		}

	}
}
