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
using SIMA.Controladoras;
using SIMA.Controladoras.GestionLogistica;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Configuration;


namespace SIMA.SimaNetWeb.GestionLogistica
{
	/// <summary>
	/// Summary description for ConsultarResumenOCompraOservicio.
	/// </summary>
	public class ConsultarResumenOCompraOservicio : System.Web.UI.Page,IPaginaBase
	{
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlPeriodo;
		protected System.Web.UI.WebControls.DropDownList ddlMes;
		protected System.Web.UI.WebControls.TextBox txtBuscar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroRUC;
		protected System.Web.UI.WebControls.Button btnAceptar;
		const string GRILLAVACIA ="No existe ningún Registro.";  

		const string KEYIDDOCUMENTO="Documento";
		const string KEYIDESTADO="Estado";
		const string KEYIDPERIODO="Periodo";
		const string KEYIDMES="Mes";
		const string KEYIDMONEDA="Moneda";
		const string KEYIDRUC="Ruc";
		const string KEYIDTITULO="Titulo";
		const string KEYIDTOTALMONEDA="TotalMoneda";

		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.ImageButton ImgImprimir;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hLstProveedor;

		const string URLDETALLE ="ResumenPorProveedorOCompraOServicio.aspx?";


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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Becados", this.ToString(),"Se consultó El Listado de las Capacitaciones en el Extranjero.",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.ddlPeriodo.SelectedIndexChanged += new System.EventHandler(this.ddlPeriodo_SelectedIndexChanged);
			this.ddlMes.SelectedIndexChanged += new System.EventHandler(this.ddlMes_SelectedIndexChanged);
			this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
			this.ImgImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ImgImprimir_Click);
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemCreated);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CResumenOCompraOServicio oCResumenOCompraOServicio = new CResumenOCompraOServicio();
			DataTable dtResumen = oCResumenOCompraOServicio.ListarResumen(Convert.ToInt32(this.ddlPeriodo.SelectedValue),this.hNroRUC.Value,Convert.ToInt32(this.ddlMes.SelectedValue));

			if(dtResumen!=null)
			{
				grid.DataSource = dtResumen;
			}
			else
			{
				grid.DataSource = dtResumen;
			}
			
			try
			{
				grid.DataBind();
			}
			catch (Exception a)
			{
				string b = a.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}		
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarResumenOCompraOservicio.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarResumenOCompraOservicio.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			CargarPeriodo();
			CargarMes();
		}

		public void CargarPeriodo()
		{
			this.ddlPeriodo.DataSource = (new CPeriodo()).ListarTodosGrilla();
			this.ddlPeriodo.DataValueField="Periodo";
			this.ddlPeriodo.DataTextField="Periodo";
			this.ddlPeriodo.DataBind();
			this.ddlPeriodo.Items.Insert(0,new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,"0"));
			ListItem litem=this.ddlPeriodo.Items.FindByValue(DateTime.Now.Year.ToString());
			if (litem!=null)
			{
				litem.Selected=true;
			}

		}

		public void CargarMes()
		{
			(new CMes()).LlenarComboMeses(this.ddlMes);
			this.ddlMes.Items.Insert(0,new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,"0"));
			ListItem litem=this.ddlMes.Items.FindByValue(DateTime.Now.Month.ToString());
			if (litem!=null)
			{
				litem.Selected=true;
			}
		}
		public void LlenarDatos()
		{
			// TODO:  Add ConsultarResumenOCompraOservicio.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ImgImprimir.Attributes["onclick"]=Helper.HistorialIrAdelantePersonalizado("ddlPeriodo","ddlMes","hNroRUC","hLstProveedor");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarResumenOCompraOservicio.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarResumenOCompraOservicio.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarResumenOCompraOservicio.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarResumenOCompraOservicio.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarResumenOCompraOservicio.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				e.Item.Cells[0].Visible=false;
			}
			else if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				bool Total = ((dr["DOC"].ToString()=="TOT")?true:false);

				string parametros =  KEYIDPERIODO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlPeriodo.SelectedValue.ToString())
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDMES + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(this.ddlMes.SelectedValue.ToString())
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDRUC  +  Utilitario.Constantes.SIGNOIGUAL + this.hNroRUC.Value
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDDOCUMENTO.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr["DOC"]) 
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDTITULO.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr["TITULO"]) 
					+ Utilitario.Constantes.SIGNOAMPERSON
					;
	
					
					string Historial = Helper.HistorialIrAdelantePersonalizado("ddlPeriodo","ddlMes","hNroRUC","hLstProveedor");

					#region Soles Cancelado
						Label lbl = (Label)e.Item.Cells[1].FindControl("LblSCancelado");
						lbl.Text = Convert.ToDouble(dr["CANCELADO SOLES"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

						string ParamColum = KEYIDMONEDA  +  Utilitario.Constantes.SIGNOIGUAL + "SOLES"
												+ Utilitario.Constantes.SIGNOAMPERSON 
												+ KEYIDESTADO  +  Utilitario.Constantes.SIGNOIGUAL + "CAN"
												+ Utilitario.Constantes.SIGNOAMPERSON 
												+ KEYIDTOTALMONEDA  +  Utilitario.Constantes.SIGNOIGUAL + lbl.Text;
							
						if(Total==false){Helper.ConfiguraColumnaHyperLink(Enumerados.EventosJavaScript.OnClick,lbl,"Cancelado",Historial,Helper.MostrarVentana(URLDETALLE,parametros + ParamColum));}
					#endregion


					#region Soles Pendiente
						Label lb2 = (Label)e.Item.Cells[2].FindControl("LblSPendiente");
						lb2.Text = Convert.ToDouble(dr["PENDIENTE SOLES"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

											ParamColum = KEYIDMONEDA  +  Utilitario.Constantes.SIGNOIGUAL + "SOLES"
												+ Utilitario.Constantes.SIGNOAMPERSON 
												+ KEYIDESTADO  +  Utilitario.Constantes.SIGNOIGUAL + "PEN"
												+ Utilitario.Constantes.SIGNOAMPERSON 
												+ KEYIDTOTALMONEDA  +  Utilitario.Constantes.SIGNOIGUAL + lb2.Text;

						if(Total==false){Helper.ConfiguraColumnaHyperLink(Enumerados.EventosJavaScript.OnClick,lb2,"Pendiente",Historial,Helper.MostrarVentana(URLDETALLE,parametros + ParamColum));}
					#endregion

					#region Total soles
						Label lbTS = (Label)e.Item.Cells[3].FindControl("lblTotalSoles");
						lbTS.Text = Convert.ToDouble(dr["TOTAL SOLES"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

						ParamColum = KEYIDMONEDA  +  Utilitario.Constantes.SIGNOIGUAL + "SOLES"
									+ Utilitario.Constantes.SIGNOAMPERSON 
									+ KEYIDESTADO  +  Utilitario.Constantes.SIGNOIGUAL + "TODOS"
									+ Utilitario.Constantes.SIGNOAMPERSON 
									+ KEYIDTOTALMONEDA  +  Utilitario.Constantes.SIGNOIGUAL + lbTS.Text;

						if(Total==false){Helper.ConfiguraColumnaHyperLink(Enumerados.EventosJavaScript.OnClick,lbTS,"Total",Historial,Helper.MostrarVentana(URLDETALLE,parametros + ParamColum));}
					#endregion



					#region Dolares Cancelado
						Label lb4 = (Label)e.Item.Cells[4].FindControl("LblDCancelado");
						lb4.Text = Convert.ToDouble(dr["CANCELADO DOLAR"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
						
											ParamColum = KEYIDMONEDA  +  Utilitario.Constantes.SIGNOIGUAL + "DOLAR"
													+ Utilitario.Constantes.SIGNOAMPERSON 
													+ KEYIDESTADO  +  Utilitario.Constantes.SIGNOIGUAL + "CAN"
													+ Utilitario.Constantes.SIGNOAMPERSON 
													+ KEYIDTOTALMONEDA  +  Utilitario.Constantes.SIGNOIGUAL + lb4.Text ;

						if(Total==false){Helper.ConfiguraColumnaHyperLink(Enumerados.EventosJavaScript.OnClick,lb4,"Cancelado",Historial,Helper.MostrarVentana(URLDETALLE,parametros + ParamColum));}
					#endregion


					#region Dolares Pendiente
						Label lb5 = (Label)e.Item.Cells[5].FindControl("LblDPendiente");
						lb5.Text = Convert.ToDouble(dr["PENDIENTE DOLAR"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					
											ParamColum = KEYIDMONEDA  +  Utilitario.Constantes.SIGNOIGUAL + "DOLAR"
												+ Utilitario.Constantes.SIGNOAMPERSON 
												+ KEYIDESTADO  +  Utilitario.Constantes.SIGNOIGUAL + "PEN"
												+ Utilitario.Constantes.SIGNOAMPERSON 
												+ KEYIDTOTALMONEDA  +  Utilitario.Constantes.SIGNOIGUAL + lb5.Text ;

					if(Total==false){Helper.ConfiguraColumnaHyperLink(Enumerados.EventosJavaScript.OnClick,lb5,"Pendiente",Historial,Helper.MostrarVentana(URLDETALLE,parametros + ParamColum));}
					#endregion

					#region Total Dolares
						Label lbTD = (Label)e.Item.Cells[6].FindControl("lblTotalDolares");
						lbTD.Text = Convert.ToDouble(dr["TOTAL DOLAR"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

						ParamColum = KEYIDMONEDA  +  Utilitario.Constantes.SIGNOIGUAL + "DOLAR"
													+ Utilitario.Constantes.SIGNOAMPERSON 
													+ KEYIDESTADO  +  Utilitario.Constantes.SIGNOIGUAL + "TODOS"
													+ Utilitario.Constantes.SIGNOAMPERSON 
													+ KEYIDTOTALMONEDA  +  Utilitario.Constantes.SIGNOIGUAL + lbTD.Text;

						if(Total==false){Helper.ConfiguraColumnaHyperLink(Enumerados.EventosJavaScript.OnClick,lbTD,"Total",Historial,Helper.MostrarVentana(URLDETALLE,parametros + ParamColum));}
					#endregion
						
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

			}
		}

		private void ddlPeriodo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		LlenarGrilla();
		}

		private void ddlMes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		LlenarGrilla();
		}

		private void txtBuscar_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
		LlenarGrilla();
		}

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		
			if(e.Item.ItemType==ListItemType.Header)
			{
				
				DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
				for(int i=0;i<=grid.Columns.Count-1;i++)
				{
					TableCell tc = new TableCell();
					if(i==0)
					{
						tc.RowSpan=2;
						tc.Style.Add("width","25%");
						tc.Controls.Add(new LiteralControl("DOCUMENTO"));
						di.Cells.Add(tc);
					}
					else if((i==1)||(i==4))
					{
						tc.ColumnSpan=3;
						tc.Text = ((i==1)?"SOLES":"DOLARES");
						di.Cells.Add(tc);
					}
					//tc.Visible=false;
					
				}
				DataGrid dg = (DataGrid)sender;
				Table t = (Table)dg.Controls[0];
				t.Rows.Add(di);
			}
		




		}

		private void ImgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			DataTable dt = (new CResumenOCompraOServicio()).ListarDocumentos("","",Convert.ToInt32(this.ddlPeriodo.SelectedValue),Convert.ToInt32(this.ddlMes.SelectedValue),"",this.hNroRUC.Value);
			Helper.EjecutarReporte(@"C:\SimanetReportes\Logistica\","Listado-OC-OS.rpt",dt,false);
		}

		
	}
}
