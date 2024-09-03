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

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	/// <summary>
	/// Summary description for EstadosFinancierosPorEmpresaDetalle.
	/// </summary>
	public class EstadosFinancierosPorEmpresaDetalle : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		//Key Session y QueryString
		const string KEYQIDEMPRESA = "idEmp";
		const string KEYIDCENTRO ="IdCentro";
		const string NOMBRECENTRO ="NombreCentro";
		const string NOMBRETIPOOPCION ="NombreOpcion";
		const string KEYQIDNOMBREFORMATO = "NFormato";
		const string KEYQIDFECHA = "efFecha";



		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO = "IdRubro";
		const string  KEYQNRODIGITOS ="NroDig";
		const string KEYQDIGCUENTA = "DigCuenta";

		const string CONTROLINKRES = "hlkCuentaRes";
		const string CONTROLINK = "hlkCuenta";
		
		const string CAMPO1 = "LblAlMes";
		const string CAMPO2 = "lblDelMes";
		const string CAMPO3 = "lblPPTO";
		//Campos de Cabecera
		const string CAMPOH1 = "LblAlMesT";
		const string CAMPOH2 = "lblDelMesT";
		const string CAMPOH3 = "lblPPTOalT";
		
			

		const string CONTROLIMAGE = "imgVerDetalle";
		const string GRILLAVACIA="No existe";

		//URL
		const string URLPRINCIPAL = "EstadosFinancierosPorEmpresa.aspx?";
		const string URLCOMPARATIVO = "EstadoFinancieroAcumuladoComparativo.aspx?";
		const string URLPERIODO = "EstadoFinancierodelPeriodo.aspx?";
		const string URLEFXEMPDETALLE ="EstadosFinancierosPorEmpresaDetalle.aspx?";
		
		const string TITULOAL = "AL ";		

		const string TITULONOMBRE ="Nombre";
		const string TITULOMESANTERIOR ="AlmesAnterior";
		const string TITULOMESACTUAL ="AlmesActual";

		//Datos DataGrid y DataTable
		const string DATATABLERESUMEN ="Resumen";
		const string COLUMNACTACONTABLE="CuentaContable";
		

		//Otros
		const string SYSTEM ="System.";
		const string TEXTOTOOLTIP ="Ver detalle de Cuenta ";
		const string TEXTOTOOLTIPATRAS ="Atras";

		
		#endregion

		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label Label1;
			protected System.Web.UI.WebControls.Label lblDelMesT;
			protected System.Web.UI.WebControls.Label LblAlMesT;
			protected System.Web.UI.WebControls.Label Label2;
			protected System.Web.UI.HtmlControls.HtmlTableCell lblConcepto;
			protected System.Web.UI.HtmlControls.HtmlTableCell lblAlMes;
			protected System.Web.UI.HtmlControls.HtmlTableCell lblDelMes;
			protected projDataGridWeb.DataGridWeb grid;
		protected projDataGridWeb.DataGridWeb gridResumen;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarGrilla();
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
				ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
			}
			catch(Exception oException)
			{
				string debug = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
			// Put user code to initialize the page here
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
			this.gridResumen.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumen_ItemDataBound);
			this.gridResumen.SelectedIndexChanged += new System.EventHandler(this.gridResumen_SelectedIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			int NroDig = Convert.ToInt32(Page.Request.Params[KEYQNRODIGITOS]);
			string DigCuenta =Page.Request.Params[KEYQDIGCUENTA].ToString();

			DataTable dtEstadoFinanciero = this.ObtenerDatos(NroDig,DigCuenta);
			if(dtEstadoFinanciero!=null)
			{grid.DataSource = dtEstadoFinanciero;}
			else
			{
				grid.DataSource = dtEstadoFinanciero;
				//lblResultado.Text = GRILLAVACIA;
			}
			grid.DataBind();
			// TODO:  Add EstadosFinancierosPorEmpresaDetalle.LlenarGrilla implementation
		}
		private void ObtenerDetalle()
		{
			int NroDig = Convert.ToInt32(Page.Request.Params[KEYQNRODIGITOS]);
			string DigCuenta =Page.Request.Params[KEYQDIGCUENTA].ToString();
			ArrayList ListaData = new ArrayList();
			switch (NroDig)
			{
				case 2:
					//this.ibtnAtras.Visible=true;
					break;
				case 3:
					ListaData.Add(this.ObtenerDatos(2,DigCuenta));
					this.MostrarDetalleGrilla(ListaData);
					break;
				case 5:
					ListaData.Add(this.ObtenerDatos(2,DigCuenta.Substring(0,2)));
					ListaData.Add(this.ObtenerDatos(3,DigCuenta));
					this.MostrarDetalleGrilla(ListaData);
					break;
				case 10:
					ListaData.Add(this.ObtenerDatos(2,DigCuenta.Substring(0,2)));
					ListaData.Add(this.ObtenerDatos(3,DigCuenta.Substring(0,3)));
					ListaData.Add(this.ObtenerDatos(5,DigCuenta));
					this.MostrarDetalleGrilla(ListaData);
					break;

			}

		}
		private void MostrarDetalleGrilla(ArrayList arrlData)
		{
			DataTable tblResumen = this.CrearTabla();
			for(int i=0;i<=arrlData.Count-1;i++)
			{
				DataRow myRow = tblResumen.NewRow();
				DataTable dtnew = (DataTable) arrlData[i];
				foreach(DataColumn dc in tblResumen.Columns)
				{myRow[dc.ColumnName.ToString()] = dtnew.Rows[0][dc.ColumnName.ToString()];}
				tblResumen.Rows.Add(myRow);
			}
			gridResumen.DataSource=tblResumen;
			gridResumen.DataBind();
		}
		private DataTable CrearTabla()
		{
			DataTable tblResumen = new DataTable(DATATABLERESUMEN); 
			string []NombreCampos = {"CuentaContable","NombreCuenta","AlMesAnterior","AlMesActual"};
			string []TipodeDatos =  {"String","String","Double","Double","Double"};
			for(int i = 0;i<= NombreCampos.Length-1;i++)
			{
				DataColumn Columna = new  DataColumn();
				Columna.DataType = System.Type.GetType(SYSTEM + TipodeDatos[i].ToString() );
				Columna.ColumnName = NombreCampos[i].ToString();
				tblResumen.Columns.Add(Columna);
			}
			return tblResumen;
		}

		private DataTable ObtenerDatos(int pNroDig,string pDigCuenta)
		{
			CEstadosFinancieros oCEstadosFinancieros = new  CEstadosFinancieros();
			return oCEstadosFinancieros.ConsultarEstadosFinancierosMovimientoPorCentro
										(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA])
										,Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA])
										,Convert.ToInt32(Page.Request.Params[KEYIDCENTRO])
										,Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO])
										,Convert.ToInt32(Page.Request.QueryString[KEYQIDREPORTE])
										,Convert.ToInt32(Page.Request.QueryString[KEYQIDRUBRO])
										,pNroDig
										,pDigCuenta
										);
		}

		
		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add EstadosFinancierosPorEmpresaDetalle.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add EstadosFinancierosPorEmpresaDetalle.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add EstadosFinancierosPorEmpresaDetalle.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			//this.MuestrayOcultarColumna();
			this.MostrarDetalleRubro();
			this.ObtenerDetalle();
			// TODO:  Add EstadosFinancierosPorEmpresaDetalle.LlenarDatos implementation
		}
		private void MuestrayOcultarColumna()
		{
			if (Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA])== Utilitario.Constantes.IDEMPRESASIMAIQUITOS)
			{
				gridResumen.Columns[2].Visible = false;	
				gridResumen.Columns[3].Visible = false;	
				gridResumen.Columns[5].Visible = false;
				grid.Columns[2].Visible = false;	
				grid.Columns[3].Visible = false;	
				grid.Columns[5].Visible = false;
			}
			else if (Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA])== Utilitario.Constantes.IDEMPRESASIMAPERU)
			{
				gridResumen.Columns[4].Visible = false;
				gridResumen.Columns[5].Visible = true;
				grid.Columns[4].Visible = false;
				grid.Columns[5].Visible = true;
			}
			else if(Convert.ToInt32(Page.Request.Params[KEYIDCENTRO])== Utilitario.Constantes.KEYIDCENTROCALLAO)
			{
				gridResumen.Columns[3].Visible = false;
				gridResumen.Columns[4].Visible = false;
				gridResumen.Columns[5].Visible = false;
				grid.Columns[3].Visible = false;
				grid.Columns[4].Visible = false;
				grid.Columns[5].Visible = false;
			}
			else if(Convert.ToInt32(Page.Request.Params[KEYIDCENTRO])== Utilitario.Constantes.KEYIDCENTROCHIMBOTE)
			{
				gridResumen.Columns[2].Visible = false;
				gridResumen.Columns[4].Visible = false;
				gridResumen.Columns[5].Visible = false;
				grid.Columns[2].Visible = false;
				grid.Columns[4].Visible = false;
				grid.Columns[5].Visible = false;
			}
	}
		private void MostrarDetalleRubro()
		{
			lblPagina.Text = Page.Request.Params[NOMBRETIPOOPCION].ToString()+ Utilitario.Constantes.VACIO + Utilitario.Constantes.SIGNOMAYOR + Utilitario.Constantes.VACIO + Page.Request.Params[NOMBRECENTRO].ToString() + Utilitario.Constantes.VACIO + Utilitario.Constantes.SIGNOMAYOR + Utilitario.Constantes.VACIO + Page.Request.Params[KEYQIDNOMBREFORMATO].ToString() ;

			CEstadosFinancieros oCEstadosFinancieros = new  CEstadosFinancieros();
			DataTable dtEstadoFinanciero = oCEstadosFinancieros.ConsultarEstadosFinancierosPorEmpresaSA(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA])
																										,Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA])
																										,Convert.ToInt32(Page.Request.Params[KEYIDCENTRO])
																										,Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO])
																										,Convert.ToInt32(Page.Request.QueryString[KEYQIDREPORTE])
																										,Convert.ToInt32(Page.Request.QueryString[KEYQIDRUBRO])
																										, Utilitario.Constantes.ValorConstanteCero
																										, Utilitario.Constantes.ValorConstanteCero
																										, Utilitario.Constantes.ValorConstanteCero
																										);
			
			if(dtEstadoFinanciero!=null)
			{
				DateTime Fecha = Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA].ToString());
				this.LblAlMesT.Text = TITULOAL + DateTime.DaysInMonth(Fecha.Year,Fecha.Month-1).ToString() + Utilitario.Constantes.SEPARADORFECHA + Convert.ToString(Fecha.Month-1).PadLeft(2,'0') + Utilitario.Constantes.SEPARADORFECHA + Fecha.Year.ToString();  
				this.lblDelMesT.Text = TITULOAL + Fecha.ToShortDateString();;
				//Montos
				this.lblConcepto.InnerText =  dtEstadoFinanciero.Rows[0][TITULONOMBRE].ToString();
				this.lblAlMes.InnerText =  Convert.ToDouble(Convert.ToDouble(dtEstadoFinanciero.Rows[0][TITULOMESANTERIOR])).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				this.lblDelMes.InnerText=  Convert.ToDouble(Convert.ToDouble(dtEstadoFinanciero.Rows[0][TITULOMESACTUAL])).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}
		public void LlenarJScript()
		{
			// TODO:  Add EstadosFinancierosPorEmpresaDetalle.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add EstadosFinancierosPorEmpresaDetalle.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add EstadosFinancierosPorEmpresaDetalle.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add EstadosFinancierosPorEmpresaDetalle.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add EstadosFinancierosPorEmpresaDetalle.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{			
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[2].Text=this.LblAlMesT.Text;
				e.Item.Cells[3].Text=this.lblDelMesT.Text;
			}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				HyperLink hlk = (HyperLink)e.Item.Cells[0].FindControl(CONTROLINK);
				hlk.Text = dr[COLUMNACTACONTABLE].ToString();
				hlk.Attributes.Add(Utilitario.Constantes.EVENTOONMOUSEOVER,"subrayar" + Utilitario.Constantes.SIGNOABREPARANTESIS + Utilitario.Constantes.SIGNOCOMILLASIMPLE +  hlk.ClientID.ToString() + Utilitario.Constantes.SIGNOCOMILLASIMPLE + Utilitario.Constantes.SIGNOCIERRAPARANTESIS + Utilitario.Constantes.SIGNOPUNTOYCOMA);
				hlk.Attributes.Add(Utilitario.Constantes.EVENTOONMOUSEOUT,"subrayar" + Utilitario.Constantes.SIGNOABREPARANTESIS + Utilitario.Constantes.SIGNOCOMILLASIMPLE +  hlk.ClientID.ToString() + Utilitario.Constantes.SIGNOCOMILLASIMPLE + Utilitario.Constantes.SIGNOCIERRAPARANTESIS + Utilitario.Constantes.SIGNOPUNTOYCOMA);
				hlk.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

				int NroDig=Convert.ToInt32(Page.Request.Params[KEYQNRODIGITOS]); 
				switch (NroDig)
				{
					case 2:
						NroDig = 3;
						break;
					case 3:
						NroDig=5;
						break;
					case 5:
						NroDig=10;
						break;
				}
				hlk.ToolTip=TEXTOTOOLTIP + dr[COLUMNACTACONTABLE].ToString();
				
					hlk.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"window.location.href" + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIGNOCOMILLASIMPLE + URLEFXEMPDETALLE 
						+ KEYQIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDEMPRESA].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDCENTRO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[NOMBRECENTRO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ NOMBRETIPOOPCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[NOMBRETIPOOPCION].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQIDNOMBREFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDNOMBREFORMATO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQIDFECHA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDFECHA].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDFORMATO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQIDREPORTE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDREPORTE].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDRUBRO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQNRODIGITOS + Utilitario.Constantes.SIGNOIGUAL + NroDig.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQDIGCUENTA + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNACTACONTABLE].ToString()
						+ Utilitario.Constantes.SIGNOCOMILLASIMPLE 
						+ Utilitario.Constantes.SIGNOPUNTOYCOMA);
				
				/*Calcula el Total por Empresa  si la Empresa es Peru*/

				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text = Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}			
		
		}

		private void gridResumen_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{			
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[2].Text=this.LblAlMesT.Text;
				e.Item.Cells[3].Text=this.lblDelMesT.Text;
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				HyperLink hlk = (HyperLink)e.Item.Cells[0].FindControl(CONTROLINKRES);
				hlk.Text = dr[COLUMNACTACONTABLE].ToString();
				hlk.Attributes.Add(Utilitario.Constantes.EVENTOONMOUSEOVER,"subrayar" + Utilitario.Constantes.SIGNOABREPARANTESIS + Utilitario.Constantes.SIGNOCOMILLASIMPLE +  hlk.ClientID.ToString() + Utilitario.Constantes.SIGNOCOMILLASIMPLE + Utilitario.Constantes.SIGNOCIERRAPARANTESIS + Utilitario.Constantes.SIGNOPUNTOYCOMA);
				hlk.Attributes.Add(Utilitario.Constantes.EVENTOONMOUSEOUT,"subrayar" + Utilitario.Constantes.SIGNOABREPARANTESIS + Utilitario.Constantes.SIGNOCOMILLASIMPLE +  hlk.ClientID.ToString() + Utilitario.Constantes.SIGNOCOMILLASIMPLE + Utilitario.Constantes.SIGNOCIERRAPARANTESIS + Utilitario.Constantes.SIGNOPUNTOYCOMA);
				int NroDig = dr[COLUMNACTACONTABLE].ToString().Length;
				string DigCuenta=String.Empty;
				switch (NroDig)
				{
					case 2:
						DigCuenta=String.Empty;
						break;
					case 3:
						DigCuenta=dr[COLUMNACTACONTABLE].ToString().Substring(0,2);
						break;
					case 5:
						DigCuenta=dr[COLUMNACTACONTABLE].ToString().Substring(0,3);
						break;
				}
				hlk.ToolTip =TEXTOTOOLTIPATRAS;
				
				
				/*Calcula el Total por Empresa  si la Empresa es Peru*/
				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text = Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}			
		}

		
		private void gridResumen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
