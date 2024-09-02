using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;


namespace SIMA.SimaNetWeb.General.Formato
{
	/// <summary>
	/// Summary description for CopiarFormato.
	/// </summary>
	public class CopiarFormato : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles
			const string KEYQIDFORMATO="IdFormato";
			const string KEYQIDREPORTE = "IdReporte";
			const string KEYQIDGRUPOFORMATO="IdGrupoFormato";
		#endregion


		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblFormato;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlGrupoFormato;
		protected System.Web.UI.WebControls.ImageButton ibtnGrabar;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();
					this.CargarModoPagina();
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
					string debug = oException.Message.ToString();
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
			this.ibtnGrabar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGrabar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add CopiarFormato.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add CopiarFormato.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add CopiarFormato.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			ListItem item;
			this.ddlGrupoFormato.DataSource=(new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.GrupodeFormatos));
			this.ddlGrupoFormato.DataTextField = Enumerados.ColumnasTablasTablas.Var1.ToString();
			this.ddlGrupoFormato.DataValueField = Enumerados.ColumnasTablasTablas.Codigo.ToString();			
			this.ddlGrupoFormato.DataBind();
			item =  this.ddlGrupoFormato.Items.FindByValue(Page.Request.Params[KEYQIDGRUPOFORMATO].ToString());
			if(item!=null){
				item.Selected = true;
				this.ddlGrupoFormato.Items.Remove(item);
			}
			item = new ListItem("[Seleccionar....]","0");
			this.ddlGrupoFormato.Items.Insert(0,item);

		}

		public void LlenarDatos()
		{
			this.CargarModoModificar();
		}

		public void LlenarJScript()
		{
			// TODO:  Add CopiarFormato.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add CopiarFormato.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add CopiarFormato.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add CopiarFormato.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add CopiarFormato.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add CopiarFormato.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add CopiarFormato.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add CopiarFormato.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add CopiarFormato.Eliminar implementation
		}

		public void CargarModoPagina()
		{
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add CopiarFormato.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			FormatoBE oFormatoBE = (FormatoBE)(new CFormato()).DetalleFormato(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]),Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]));
			this.lblFormato.Text = oFormatoBE.Nombre;
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add CopiarFormato.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			return Convert.ToInt32(this.ddlGrupoFormato.SelectedValue) !=0;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add CopiarFormato.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add CopiarFormato.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void ibtnGrabar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						FormatoBE oFormatoBE = new  FormatoBE();
						oFormatoBE.Idformato = Convert.ToInt32( Page.Request.Params[KEYQIDFORMATO]);
						oFormatoBE.IdgrupoDestino = Convert.ToInt32(this.ddlGrupoFormato.SelectedValue);
						if((new CFormato()).Copiar(oFormatoBE)>0)
						{
							LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Formato",this.ToString(),"Se registró una copia de formato Nro" + oFormatoBE.Idformato.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
							Helper.CerrarVentana();
						}
					}
					else{
						Helper.MsgBox("No es posible realizar una copia\nno se ha seleccionado un grupo de formato destino");
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
				Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
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
