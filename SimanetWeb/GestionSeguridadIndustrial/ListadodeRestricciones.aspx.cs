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
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for ListadodeRestricciones.
	/// </summary>
	public class ListadodeRestricciones : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.CheckBox chkRestriccion;

		const string KEYQDNI ="NroDNI";
		const string KEYQPERIODO ="Periodo";
		const string KEYQIDEXAMEN ="idExa";
		const string KEYQNOMTRAB ="NomTrab";

		const string KEYQPERIODOPRG ="PeriodoPrg";
		protected projDataGridWeb.DataGridWeb gridRestric;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblNroDoc;
		protected System.Web.UI.WebControls.Label lblApellidosyNombres;
		const string KEYQIDPROG ="NroProg";

		private string NroDNI
		{
			get{return Page.Request.Params[KEYQDNI];}
		}
		private int PeriodoEx
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}
		private int IdExamen
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDEXAMEN]);}
		}
		private int PeriodoProg
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODOPRG]);}
		}
		private int NroProg
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDPROG]);}
		}

		private string ApellidosyNombres
		{
			get{return Page.Request.Params[KEYQNOMTRAB];}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Registro de programación - CONTRATISTA", this.ToString(),"Se ingreso a la funcionalidad de  registro de Programación(Ingreso y Modificación)",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.gridRestric.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridRestric_ItemDataBound);
			this.gridRestric.SelectedIndexChanged += new System.EventHandler(this.gridRestric_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		public DataTable ObtenerDatos()
		{
			return (new CCCTT_RestriccionesNoConsiderdas()).Listar(this.PeriodoEx,this.IdExamen,this.PeriodoProg,this.NroProg);
		}
		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				gridRestric.DataSource = dt;
			}
			
			try
			{
				gridRestric.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				gridRestric.CurrentPageIndex = 0;
				gridRestric.DataBind();
			}			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ListadodeRestricciones.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ListadodeRestricciones.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ListadodeRestricciones.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblNroDoc.Text = this.NroDNI;
			this.lblApellidosyNombres.Text = this.ApellidosyNombres;
		}

		public void LlenarJScript()
		{
			// TODO:  Add ListadodeRestricciones.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ListadodeRestricciones.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ListadodeRestricciones.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ListadodeRestricciones.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ListadodeRestricciones.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ListadodeRestricciones.ValidarFiltros implementation
			return false;
		}

		#endregion
		
		private void gridRestric_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			e.Item.Cells[4].Style.Add("display","none");
			e.Item.Cells[5].Style.Add("display","none");
			e.Item.Cells[6].Style.Add("display","none");

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],gridRestric.CurrentPageIndex,gridRestric.PageSize,e.Item.ItemIndex,"");
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				System.Web.UI.WebControls.Image imgchk = (System.Web.UI.WebControls.Image)e.Item.Cells[2].FindControl("imgCHK");
				imgchk.Style.Add("display",((dr["Existe"].ToString()!="0")?"block":"none"));

				CheckBox chk = (CheckBox)e.Item.Cells[3].FindControl("chkCumple");
				chk.Checked= ((dr["Cumple"].ToString()!="0")?true:false);
				chk.Style.Add("display",((dr["Existe"].ToString()!="0")?"block":"none"));
				//chk.Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()]="CumpleConRestriccion('" + this.PeriodoEx.ToString() + "','" + this.IdExamen.ToString() + "','"+ dr["IdRestriccion"].ToString()  +"','" + this.PeriodoProg.ToString() + "','" + this.NroProg + "',this);";
			

			}		
		}

		private void gridRestric_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
