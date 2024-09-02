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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.EntidadesNegocio.General;

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using System.IO;
using Microsoft.Office.Core;
using Excel= Microsoft.Office.Interop.Excel;


namespace SIMA.SimaNetWeb.General.Diapositivas.GestionFinanciera
{
	/// <summary>
	/// Summary description for EstadoFinancieroPorMes.
	/// </summary>
	public class EstadoFinancieroPorMes : System.Web.UI.Page,IPaginaBase
	{

		protected System.Web.UI.WebControls.Panel Panel;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreImgTrim;


		const string KEYQIDFORMATO="IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO ="IdRubro";
		const string KEYQPERIODO = "Periodo";
		const string KEYQIDMES = "IdMes";
		const string IDCENTROOPERATIVO="idcop";
		const string KEYQIDTIPOINFO ="idTipoInfo";
		const string KEYQACUMULADO="Acum";
		const string KEYTITULO="TitRep";

		const string KEYQIDOBJETO="IdObj";
		const string KEYSUBTITULO="SubTitRep";

		protected projDataGridWeb.DataGridWeb grid;

		General.Diapositivas.GestionFinanciera.HeaderFIN usc_HeaderFin;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		const string URLCONTROL= "HeaderFIN.ascx";

		public string Titulo
		{
			get{return Page.Request.Params[KEYTITULO].ToString();}
		}
		public string SubTitulo
		{
			get{return Page.Request.Params[KEYSUBTITULO].ToString().Replace("[s]"," ");}
		}

		private int IdFormato
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);}
		}
		public int IdReporte
		{
			get{ return Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);}
		}

		public string IdCentroOperativo
		{
			get{return Page.Request.Params[IDCENTROOPERATIVO].ToString();}
		}

		public int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}

		public int IdTipoInformacion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO]);}
		}
		public int IdMes
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDMES]);}
		}

		public int IdObjeto
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDOBJETO]);}
		}


		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarGrilla();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera: Administrar Formatos Financieros mensualizados", this.ToString(),"Se consultó Listado de formtatos financieros",Enumerados.NivelesErrorLog.I.ToString()));
					
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
				string debug = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
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
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemCreated);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			
			DataTable dt = (new  CEstadosFinancierosDirectorio()).ListarFormatoAnual(this.IdFormato,this.IdReporte, this.IdCentroOperativo ,this.Periodo,this.IdMes,this.IdTipoInformacion);
			if(dt!=null)
			{
				grid.DataSource =  Helper.OrdenarFormatoEstructura(dt);
			}
			else
			{
				grid.DataSource = dt;
			}
			grid.DataBind();

			grid.ID="F"+ IdFormato.ToString()+"_"+this.IdReporte.ToString();		
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add EstadoFinancieroPorMes.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add EstadoFinancieroPorMes.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add EstadoFinancieroPorMes.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			/******Cargar Cabecera*******************************************************************/
			usc_HeaderFin = (General.Diapositivas.GestionFinanciera.HeaderFIN)LoadControl(URLCONTROL);
			usc_HeaderFin.Titulo = this.Titulo;
			usc_HeaderFin.SubTitulo=this.SubTitulo;
			Panel.Controls.Clear();
			Panel.Controls.Add(usc_HeaderFin);
			/*************************************************************************/
			System.Web.UI.WebControls.TemplateColumn Tcolumn;
			for(int i=1;i<=this.IdMes;i++)
			{
				Tcolumn = new System.Web.UI.WebControls.TemplateColumn();
				Tcolumn.HeaderText= Helper.ObtenerNombreMes(i,SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto);
				Tcolumn.ItemStyle.Wrap=false;
				Tcolumn.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
				grid.Columns.Add(Tcolumn);
			}
			Tcolumn = new System.Web.UI.WebControls.TemplateColumn();
			Tcolumn.HeaderText= Helper.ObtenerNombreMes(this.IdMes,SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto);
			Tcolumn.ItemStyle.Wrap=false;
			Tcolumn.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			grid.Columns.Add(Tcolumn);

		}

		public void LlenarJScript()
		{
			// TODO:  Add EstadoFinancieroPorMes.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add EstadoFinancieroPorMes.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add EstadoFinancieroPorMes.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add EstadoFinancieroPorMes.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add EstadoFinancieroPorMes.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add EstadoFinancieroPorMes.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				
				DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
				for(int i=0;i<=grid.Columns.Count-1;i++)
				{
					TableCell tc = new TableCell();
					if((i==0)||(i==grid.Columns.Count-1))
					{
						tc.RowSpan=2;
						tc.Style.Add("width",((i==0)?"25%":"5%"));
						tc.Controls.Add(new LiteralControl(((i==0)?"CONCEPTO": (this.Periodo-1).ToString() + "<br>" + Helper.ObtenerNombreMes(this.IdMes,SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto))));
						tc.Attributes.Add("onclick","Prueba();");
					}
					else if(i==1)
					{
						tc.ColumnSpan=this.IdMes;
						tc.Controls.Add(new LiteralControl("31 de " + Helper.ObtenerNombreMes(this.IdMes,SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto) + " " + this.Periodo.ToString()));
					}
					else if(i>1 && i<=this.IdMes)
					{
						tc.Visible=false;
					}
					di.Cells.Add(tc);
				}
				DataGrid dg = (DataGrid)sender;
				Table t = (Table)dg.Controls[0];
				t.Rows.Add(di);
			}			

		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[0].Visible=false;//para conbinar la columna 1
				e.Item.Cells[grid.Columns.Count-1].Visible=false;//para conbinar la columna 1

				

				e.Item.Cells[1].Attributes.Add("onclick","Prueba();");
				e.Item.Cells[2].Attributes.Add("onclick","alert('ee');");

				
			}
			else if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;		
				for(int c=1;c<=this.IdMes;c++)
				{
					string NMes = Helper.ObtenerNombreMes(c,Enumerados.TipoDatoMes.NombreCompleto);
					e.Item.Cells[c].Text = Convert.ToDouble(dr[NMes].ToString()).ToString(Constantes.FORMATODECIMAL4);
				}
				e.Item.Cells[grid.Columns.Count-1].Text = Convert.ToDouble(dr["MesActAnoAnt"].ToString()).ToString(Constantes.FORMATODECIMAL4);
				//
				e.Item.Cells[0].Controls.Add((new EstadoFinancieroCorporativo()).ConfigConceptos(e,IdObjeto));
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				
			}
		}
	}
}
