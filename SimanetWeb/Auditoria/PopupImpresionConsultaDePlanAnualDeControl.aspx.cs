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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.Auditoria
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class PopupImpresionConsultaDePlanAnualDeControl : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.DataGrid grid;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;

		#endregion Controles

		#region Constantes
		
		//Key Session y QueryString
		const string KEYQID = "Id";
				
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
		const string GRILLAVACIA ="No existe ninguna Auditoria en Curso.";  

		#endregion Constantes

		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarDatos();
					this.LlenarGrilla();
					this.Imprimir();
					
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcion oSIMAExcepcion)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcion.Mensaje);					
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CImpresion oCImpresion =  new CImpresion();
			DataTable dtImpresion =  oCImpresion.ObtenerDataImprimir();
			
			if(dtImpresion!=null)
			{
				DataView dwImpresion = dtImpresion.DefaultView;
				dwImpresion.Sort = oCImpresion.ObtenerColumnaOrdenamiento();
				grid.DataSource = dwImpresion;
				grid.CurrentPageIndex = oCImpresion.ObtenerIndicePagina();
			}
			else
			{
				lblResultado.Text = GRILLAVACIA;

			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporte();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
		 	ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaDeCartasFianzas.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultaDeCartasFianzas.ConfigurarAccesoControles implementation
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
			return true;
		}


		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[1].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

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
			}	
		}

					

		

		

		
	}
}

