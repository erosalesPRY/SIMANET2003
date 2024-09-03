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
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionIntegrada;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionIntegrada;
using NetAccessControl;
using System.Configuration;


namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for DetalleAuditoria.
	/// </summary>
	public class DetalleAuditoria : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCodigo;
		protected System.Web.UI.WebControls.DropDownList ddlTipoAuditoria;
		protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;
		protected System.Web.UI.WebControls.TextBox CalFechaDesde;
		protected System.Web.UI.WebControls.TextBox CalFechaHasta;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
	

		const string KEYQIDAUDITORIA="IdAudi";

		private int IdAuditoria
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDAUDITORIA]);}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarDatos();
					this.LlenarCombos();
					this.CargarModoPagina();
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
					Helper.MsgBox(oSIMAExcepcionDominio.Mensaje.ToString());					
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
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleAuditoria.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleAuditoria.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleAuditoria.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.LlenarCentroOperativo();
			this.LlenarTipoAuditoria();
		}
		void LlenarTipoAuditoria()
		{
			DataView dv = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TablaTipodeAuditoria)).DefaultView;
			dv.RowFilter="Codigo in('2','3')";
			ddlTipoAuditoria.DataSource= Helper.DataViewTODataTable(dv);
			ddlTipoAuditoria.DataTextField=Enumerados.ColumnasTablasTablas.Var1.ToString();
			ddlTipoAuditoria.DataValueField=Enumerados.ColumnasTablasTablas.Codigo.ToString();
			ddlTipoAuditoria.DataBind();
			ddlTipoAuditoria.Items.Insert(0,new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,"0")); 
		}
		void LlenarCentroOperativo(){
			ddlCentroOperativo.DataSource = (new  CCentroOperativo()).ListarTodosCombo();
			ddlCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Nombre.ToString();
			ddlCentroOperativo.DataBind();
			//ddlCentroOperativo.Items.RemoveAt(ddlCentroOperativo.Items.Count-1);
			ddlCentroOperativo.Items.Insert(0,new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,"0")); 
			string id = CNetAccessControl.GetUserIdCentroOperativo().ToString();
			ListItem Item = ddlCentroOperativo.Items.FindByValue(id);
			if(Item!=null){
				Item.Selected=true;
			}


		}
		public void LlenarDatos()
		{
			// TODO:  Add DetalleAuditoria.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			//this.ddlCentroOperativo.Enabled=false;
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleAuditoria.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleAuditoria.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleAuditoria.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleAuditoria.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleAuditoria.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			SAMAuditoriaBE	oSAMAuditoriaBE = new SAMAuditoriaBE();
			oSAMAuditoriaBE.IdTipoAuditoria = Convert.ToInt32(this.ddlTipoAuditoria.SelectedValue);
			oSAMAuditoriaBE.IdCentroOperativo = Convert.ToInt32(this.ddlCentroOperativo.SelectedValue);
			oSAMAuditoriaBE.Descripcion= this.txtDescripcion.Text;
			oSAMAuditoriaBE.FechaDesde= Convert.ToDateTime(this.CalFechaDesde.Text);
			oSAMAuditoriaBE.FechaHasta= Convert.ToDateTime(this.CalFechaHasta.Text);
			if((new CSAMAuditoria()).Insertar(oSAMAuditoriaBE)!=-1)
			{
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Modificar()
		{
			SAMAuditoriaBE	oSAMAuditoriaBE = new SAMAuditoriaBE();
			oSAMAuditoriaBE.IdAuditoria = this.IdAuditoria;
			oSAMAuditoriaBE.IdCentroOperativo = Convert.ToInt32(this.ddlCentroOperativo.SelectedValue);
			oSAMAuditoriaBE.Descripcion= this.txtDescripcion.Text;
			oSAMAuditoriaBE.FechaDesde= Convert.ToDateTime(this.CalFechaDesde.Text);
			oSAMAuditoriaBE.FechaHasta= Convert.ToDateTime(this.CalFechaHasta.Text);
			if((new CSAMAuditoria()).Modificar(oSAMAuditoriaBE)!=-1){
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleAuditoria.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					ddlTipoAuditoria.Enabled=false;
					this.CargarModoModificar();
					break;
				case Enumerados.ModoPagina.C:
					break;
				
			}				
		}

		public void CargarModoNuevo()
		{
			
			ListItem litem = ddlCentroOperativo.Items.FindByValue(CNetAccessControl.GetUserIdCentroOperativo().ToString());
			if(litem!=null){litem.Selected=true;}

		}

		public void CargarModoModificar()
		{
			SAMAuditoriaBE oSAMAuditoriaBE = (SAMAuditoriaBE) (new CSAMAuditoria()).ListarDetalle(this.IdAuditoria);
			this.txtCodigo.Text = oSAMAuditoriaBE.Codigo;
			ListItem lItem  = this.ddlTipoAuditoria.Items.FindByValue(oSAMAuditoriaBE.IdTipoAuditoria.ToString());
			if(lItem!=null){lItem.Selected=true;}

			lItem  = this.ddlCentroOperativo.Items.FindByValue(oSAMAuditoriaBE.IdCentroOperativo.ToString());
			if(lItem!=null){lItem.Selected=true;}

			this.CalFechaDesde.Text = oSAMAuditoriaBE.FechaDesde.ToShortDateString();
			this.CalFechaHasta.Text = oSAMAuditoriaBE.FechaHasta.ToShortDateString();

			this.txtDescripcion.Text = oSAMAuditoriaBE.Descripcion.ToString();

		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleAuditoria.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleAuditoria.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleAuditoria.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleAuditoria.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA]) ;
						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.N:
								this.Agregar();
								break;
							case Enumerados.ModoPagina.M:
								this.Modificar();
								break;
						}
					}
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
				Helper.MsgBox(oSIMAExcepcionDominio.Error.ToString());					
			}
			catch(Exception oException)
			{
				ASPNetUtilitario.MessageBox.Show(oException.Message.ToString());
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}						
		}
	}
}
