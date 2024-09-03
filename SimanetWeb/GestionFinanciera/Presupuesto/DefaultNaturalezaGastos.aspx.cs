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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.EntidadesNegocio.General;

namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto
{
	/// <summary>
	/// Summary description for DefaultNaturalezaGastos.
	/// </summary>
	public class DefaultNaturalezaGastos : System.Web.UI.Page, IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;

		const string GRILLAVACIA="No existe Datos";
		const string CONTROCHECKBOX = "cbxNaturaleza";

		const string KEYQIDACCESOUSUARIO="idRegistro";
		const string KEYQIDUSUARIO = "idUsuario";
		const string KEYQNOMBRETABLA="NombreTbl";
		const string KEYQTABLAINFORMACION="idTblInfo";//Tabla que contiene los registro que serviran como origen para ser restrictivos en la tabla informacion
		const string KEYQID1="idCentroCosto";//registro de la tabla origen
		const string KEYQID2="Id2";//tabla que contendra la informacion de movimientos de la tabla origen
		const string KEYQID3="Id3";
		const string KEYQFLAGACCESO="flgAcceso";

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					Helper.ReestablecerPagina(this);
					//this.LlenarJScript();
					//this.LlenarDatos();
					//this.LlenarCombos();
					this.LlenarGrillaOrdenamientoPaginacion(String.Empty,Constantes.INDICEPAGINADEFAULT);	
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
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Error);					
				}
				catch(Exception oException)
				{
					string msgb =oException.Message.ToString();
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DefaultNaturalezaGastos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DefaultNaturalezaGastos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				//this.TotalPresupuesto(dtGeneral);
				grid.DataSource = dtGeneral;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtGeneral;
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
		private DataTable ObtenerDatos()
		{
			
				return ((CPresupuesto)new  CPresupuesto()).ConsultarNaturalezaGastos(2009,Convert.ToInt32(Page.Request.Params[KEYQIDUSUARIO]),Convert.ToInt32(Page.Request.Params[KEYQID1]));
								
		}
		public void LlenarCombos()
		{
			// TODO:  Add DefaultNaturalezaGastos.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DefaultNaturalezaGastos.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DefaultNaturalezaGastos.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DefaultNaturalezaGastos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DefaultNaturalezaGastos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DefaultNaturalezaGastos.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DefaultNaturalezaGastos.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DefaultNaturalezaGastos.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if(Convert.ToInt32(dr["Flag"].ToString())== 1)
				{
					CheckBox cbxAgregar =(CheckBox)e.Item.FindControl(CONTROCHECKBOX);
					cbxAgregar.Checked = true;
				}

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}	
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					this.Agregar();
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
		public void Agregar()
		{
			foreach(DataGridItem dgItem in grid.Items)
			{
				
				CheckBox cbxAgregar =(CheckBox)dgItem.Cells[2].FindControl(CONTROCHECKBOX);
				
				AccesoUsuarioTablaBE oAccesoUsuarioTablaBE = new AccesoUsuarioTablaBE();
			
				oAccesoUsuarioTablaBE.IdUsuario = Convert.ToInt32(Page.Request.Params[KEYQIDUSUARIO]);
				oAccesoUsuarioTablaBE.IdTablaNombreTabla = 176;
				oAccesoUsuarioTablaBE.IdNombreTabla = 282;
				oAccesoUsuarioTablaBE.Id1 = Convert.ToInt32(Page.Request.Params[KEYQID1]);
				oAccesoUsuarioTablaBE.Id2 = 45;
				oAccesoUsuarioTablaBE.Id3 = Convert.ToInt32(dgItem.Cells[0].Text.ToString());

				if(cbxAgregar.Checked)
				{
					
					oAccesoUsuarioTablaBE.FlgAcceso = 1;
					if(Convert.ToInt32((new CAccesoUsuarioTabla()).InsertarNaturalezaGasto(oAccesoUsuarioTablaBE)) >0)
					{
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Naturaleza Gastos",this.ToString(),"Se registró Item de AccesoUsuarioTabla" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
						ltlMensaje.Text = Helper.MensajeRetornoAlert();
						
					}			
				}
				else
				{
					oAccesoUsuarioTablaBE.FlgAcceso = 0;
					if(Convert.ToInt32((new CAccesoUsuarioTabla()).InsertarNaturalezaGasto(oAccesoUsuarioTablaBE)) >0)
					{
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Naturaleza Gastos",this.ToString(),"Se registró Item de AccesoUsuarioTabla" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
						ltlMensaje.Text = Helper.MensajeRetornoAlert();
						
					}			
				}
			}
			Helper.CerrarVentana();
		}

	}
}
