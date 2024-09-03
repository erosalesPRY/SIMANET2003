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
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.IO;

namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar
{
	public class ConsultarCuentasporCobraryPagarResumen : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label Label10;
			protected System.Web.UI.WebControls.Label Label9;
			protected System.Web.UI.WebControls.Label Label8;
			protected System.Web.UI.WebControls.Label lblOrdenServicioSoles;
			protected System.Web.UI.WebControls.Label lblOrdenServicioDolares;
			protected System.Web.UI.WebControls.Label lblFMontoCallaoS1;
			protected System.Web.UI.WebControls.Label lblFMontoCallaoD2;
			protected System.Web.UI.WebControls.Label Label11;
			protected System.Web.UI.WebControls.Label Label7;
			protected System.Web.UI.WebControls.Label Label6;
			protected System.Web.UI.WebControls.Label lblOrdenesCompraSoles;
			protected System.Web.UI.WebControls.Label lblOrdenesCompraDolares;
			protected System.Web.UI.WebControls.Label lblFMontoCallaoS;
			protected System.Web.UI.WebControls.Label lblFMontoCallaoD;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label Label4;
			protected System.Web.UI.WebControls.Label Label1;
			protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		#region Constantes
			const string COLUMNAPERIODO ="Periodo";
			const string LBLALMESCALLAO="lblAlMesdeCallao";
			const string LBLALMESCHIMBOTE="lblAlMesdeChimbote";
			const string LBLALMESIQUITOS="lblAlMesdeIquitos";


			const string LBLDELMESCALLAO="lblDelMesCallao";
			const string LBLDELMESCHIMBOTE="lblDelMesChimbote";
			const string LBLDELMESIQUITOS="lblDelMesIquitos";

		

			const string PERIODO="Periodo";
			const string MES="Mes";

			const string VARIABLETOTALIZA ="Totaliza";

			const string STYLEBACKCOLOR = "background-color";
			const string COLOR = "Transparent";
			const string STYLEBORDER = "border-style";
			const string NONE = "none";
			//Constantes que seran utilizadas para subir y abrir los archivios
			const string NOMBREAPPXLS="RutaServerImagenes";
			const string NOMBREAPPSAVEXLS="RutaImagenes";
			const string Hoja="CuentasPC.xls";


		#endregion
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreControlCol;
		protected projDataGridWeb.DataGridWeb dbGridResumen;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hValoresRestaurados;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtTCVenta;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hRutaDocumento;
		protected System.Web.UI.HtmlControls.HtmlInputFile filMyFileDocumento;
		protected System.Web.UI.WebControls.Button ibtnGuardar;
		protected System.Web.UI.HtmlControls.HtmlInputButton ibtnPantallaPropuesta;

		#region Variables
			int NroFila=0;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarJScript();
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
					
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
			Helper.ReestablecerPagina(this);

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
			this.ibtnGuardar.Click += new System.EventHandler(this.ibtnGuardar_Click);
			this.dbGridResumen.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dbGridResumen_ItemDataBound);
			this.dbGridResumen.SelectedIndexChanged += new System.EventHandler(this.dbGridResumen_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ddlbPeriodo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		#region Implementacion
		#endregion
		private DataTable ObtenerDatos(int pPeriodo,int pMes)
		{
			return ((CCuentasporPagar) new CCuentasporPagar()).ConsultarCuentasporPagarCobrar(pPeriodo,pMes,Convert.ToDouble(this.txtTCVenta.Text),Convert.ToDouble(this.txtTCVenta.Text));
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarCuentasporCobraryPagarResumen.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCuentasporCobraryPagarResumen.LlenarGrillaOrdenamiento implementation
		}

		private void Totalizar(DataTable dtOrigen)
		{
			if (dtOrigen !=null)
			{
				object []RegistroTotalizador = new object[5];
				
				/*Totaliza cuentas por cobrar Callao*/
				double TotalCallao = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaResumenCuentasPorPagar.SimaCallao.ToString(),Enumerados.FINColumnaResumenCuentasPorPagar.Orden.ToString(),"2")[0]
										- Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaResumenCuentasPorPagar.SimaCallao.ToString(),Enumerados.FINColumnaResumenCuentasPorPagar.Orden.ToString(),"1")[0];
				
				
				/*Totaliza cuentas por cobrar Chimbote*/
				double TotalChimbote = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaResumenCuentasPorPagar.SimaChimbote.ToString(),Enumerados.FINColumnaResumenCuentasPorPagar.Orden.ToString(),"2")[0]
										- Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaResumenCuentasPorPagar.SimaChimbote.ToString(),Enumerados.FINColumnaResumenCuentasPorPagar.Orden.ToString(),"1")[0];
				
				/*Totaliza cuentas por cobrar Iquitos*/
				double TotalIquitos = Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaResumenCuentasPorPagar.SimaIquitos.ToString(),Enumerados.FINColumnaResumenCuentasPorPagar.Orden.ToString(),"2")[0]
										- Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaResumenCuentasPorPagar.SimaIquitos.ToString(),Enumerados.FINColumnaResumenCuentasPorPagar.Orden.ToString(),"1")[0];
				
				RegistroTotalizador[0] = "3";
				RegistroTotalizador[1]="DIFERENCIA";
				RegistroTotalizador[2] = TotalCallao;
				RegistroTotalizador[3] = TotalChimbote;
				RegistroTotalizador[4] = TotalIquitos;
				
				dtOrigen.Rows.Add(RegistroTotalizador);

			}
		}		
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos(Convert.ToInt32(Page.Request.Params[PERIODO]),Convert.ToInt32(Page.Request.Params[MES]));

			if(dt!=null)
			{
				this.Totalizar(dt);
				DataView dw = dt.DefaultView;
				
				dw.RowFilter = Helper.ObtenerFiltro();
				dw.Sort = columnaOrdenar ;
				grid.DataSource = dw;
				grid.CurrentPageIndex =indicePagina;
				/*resumen*/
				this.dbGridResumen.DataSource = dw;
			}
			else
			{
				grid.DataSource = null;
				dbGridResumen.DataSource = null;
				lblResultado.Text = "No existen Documentos por Pagar";
			}
			try
			{
				grid.DataBind();
				dbGridResumen.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
				dbGridResumen.DataBind();
			}			
		}



		public void LlenarCombos()
		{
		}

		public void LlenarDatos()
		{
			this.lblPeriodo.Text = Page.Request.Params[PERIODO].ToString();
			this.lblMes.Text = Helper.ObtenerNombreMes(Convert.ToInt32(Page.Request.Params[MES]), Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToString().ToUpper();
			this.ObtenerTipoCambio();
		}
		public void ObtenerTipoCambio()
		{
			const int idMoneda = 2;/*Dolares*/
			DataTable dtGeneral = ((Controladoras.General.CTipoCambio)  new SIMA.Controladoras.General.CTipoCambio()).ConsultarUltimoTipodeCambio(idMoneda);
			this.txtTCVenta.Text = Convert.ToDouble(dtGeneral.Rows[0]["TipoCambioVenta"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL3);
			//this.txtTCVenta.Text = Convert.ToDouble(dr["TipoCambioVenta"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL3);
		}
		public void LlenarJScript()
		{
			this.txtTCVenta.Style.Add(STYLEBACKCOLOR,COLOR);
			this.txtTCVenta.Style.Add(STYLEBORDER,NONE);


			this.hRutaDocumento.Value = System.Configuration.ConfigurationSettings.AppSettings[NOMBREAPPXLS].ToString() + Hoja; 
			//string JVALIDACIONABRIRDOCUMENTO=" if(document.forms[0].elements['hRutaDocumento'].value!='') { window.open(document.forms[0].elements['hRutaDocumento'].value,'miwin','Width=790,Height=560,scrollbars=true,top=0,left=0'); return false; } else { return false; }";
			string JVALIDACIONABRIRDOCUMENTO="AbrirArchivoXLS()";
			this.ibtnPantallaPropuesta.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JVALIDACIONABRIRDOCUMENTO);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCuentasporCobraryPagarResumen.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarCuentasporCobraryPagarResumen.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCuentasporCobraryPagarResumen.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarCuentasporCobraryPagarResumen.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarCuentasporCobraryPagarResumen.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				#region Etiqueta al Mes de 
				string NombreMes = Helper.ObtenerNombreMes(Convert.ToInt32(Page.Request.Params[MES]),Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToString().ToUpper();
				((Label) e.Item.Cells[1].FindControl(LBLALMESCALLAO)).Text = "AL MES <BR> DE" + "<BR>" + NombreMes;
				((Label) e.Item.Cells[2].FindControl(LBLALMESCHIMBOTE)).Text = "AL MES <BR> DE" + "<BR>" + NombreMes;
				((Label) e.Item.Cells[3].FindControl(LBLALMESIQUITOS)).Text = "AL MES <BR> DE" + "<BR>" + NombreMes;
				/*Del Mes*/
				int idNMes= (Convert.ToInt32(Page.Request.Params[MES])== 12)? 1:Convert.ToInt32(Page.Request.Params[MES])+1;

				string NombredelMes = Helper.ObtenerNombreMes(idNMes,Utilitario.Enumerados.TipoDatoMes.NombreCompleto);
				((Label) e.Item.Cells[1].FindControl(LBLDELMESCALLAO)).Text = "DEL MES <BR> DE" + "<BR>" + NombredelMes;
				((Label) e.Item.Cells[2].FindControl(LBLDELMESCHIMBOTE)).Text = "DEL MES <BR> DE" + "<BR>" + NombredelMes;
				((Label) e.Item.Cells[3].FindControl(LBLDELMESIQUITOS)).Text = "DEL MES <BR> DE" + "<BR>" + NombredelMes;
				#endregion
			}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				if(Convert.ToInt32(dr[Enumerados.FINColumnaResumenCuentasPorPagar.Orden.ToString()])!=3)
				{
					e.Item.Cells[0].Controls.Add(CrearNodoTreeView(e.Item.Cells[0].Text
						,Convert.ToInt32(dr[Enumerados.FINColumnaResumenCuentasPorPagar.Orden.ToString()])
						,Page.Request.Params[PERIODO].ToString()
						,Page.Request.Params[MES].ToString()
						,NroFila
						,this.txtTCVenta.Text
						));
				}

				e.Item.Attributes.Add("NodoEstado","NoCargado");
				e.Item.Attributes.Add("idFilaSVR",NroFila.ToString());

				e.Item.Cells[1].Text = Convert.ToDouble(dr[Enumerados.FINColumnaResumenCuentasPorPagar.SimaCallao.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				e.Item.Cells[2].Text = Convert.ToDouble(dr[Enumerados.FINColumnaResumenCuentasPorPagar.SimaChimbote.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				e.Item.Cells[3].Text = Convert.ToDouble(dr[Enumerados.FINColumnaResumenCuentasPorPagar.SimaIquitos.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				/*Totaliza los Centros*/
				double Total = Convert.ToDouble(dr[Enumerados.FINColumnaResumenCuentasPorPagar.SimaCallao.ToString()])
								+ Convert.ToDouble(dr[Enumerados.FINColumnaResumenCuentasPorPagar.SimaChimbote.ToString()])
								+ Convert.ToDouble(dr[Enumerados.FINColumnaResumenCuentasPorPagar.SimaIquitos.ToString()]);
				 
				e.Item.Cells[4].Text = Total.ToString(Utilitario.Constantes.FORMATODECIMAL4);


				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				if (dr[Enumerados.FINColumnaResumenCuentasPorPagar.Concepto.ToString()].ToString()== "DIFERENCIA")
				{
					e.Item.Attributes.Remove("class");
					e.Item.Attributes.Add("class","FooterGrilla");
				}

			}
		
			NroFila ++;
		}
		#region Crear Objetos tipo HTMLTABLE
			private HtmlTable CrearNodoTreeView(string Concepto,params object [] ListaParametros)
			{
				HtmlTable oHtmlTable = new HtmlTable();
				HtmlTableCell oHtmlTableCell;
				HtmlTableRow oHtmlTableRow = new HtmlTableRow();
				/*Inserta la Imagen*/
				oHtmlTableCell = new HtmlTableCell();
				oHtmlTableCell.Controls.Add(CrearImage(ListaParametros));
				oHtmlTableCell.Width = "5%";
				oHtmlTableRow.Controls.Add(oHtmlTableCell);
				/*Inserta el Texto*/
				oHtmlTableCell = new HtmlTableCell();
				oHtmlTableCell.InnerText=Concepto;
				oHtmlTableCell.Width = "95%";
				oHtmlTableRow.Controls.Add(oHtmlTableCell);
				oHtmlTable.Rows.Add(oHtmlTableRow);
				oHtmlTable.Width = "100%";
				oHtmlTable.Border=0;
				oHtmlTable.Attributes.Add("class","itemgrillasinColor");
				return oHtmlTable;
			}

			private HtmlImage CrearImage(params object [] ListaParametros)
			{
				string PathImg = HttpContext.Current.Session[Utilitario.Constantes.SPATHAPPWEB].ToString() + Utilitario.Constantes.TREEPATHIMG; 
				
				string NodeOpen = PathImg + "plus.gif";
				HtmlImage oHtmlImage = new HtmlImage();
				oHtmlImage.ID="ImgPlusMinus";
				oHtmlImage.Src = NodeOpen;
				oHtmlImage.Attributes.Add(Constantes.EVENTOCLICK,Helper.ObtenerCuentasPorPagarOCobrar3Dig(ListaParametros));
				return oHtmlImage;
			}

			private HtmlTable CrearNodoColumnas(int idCentro, int idFila,double Monto1,double Monto2,double Monto3)
			{
				HtmlTable oHtmlTable = new HtmlTable();
				oHtmlTable.ID = "tbl" + idCentro.ToString() + "F" + idFila.ToString();
				hNombreControlCol.Value=oHtmlTable.ClientID.Trim();

				oHtmlTable.Style.Add("Width","100%");
				HtmlTableCell oHtmlTableCell;
				HtmlTableRow oHtmlTableRow = new HtmlTableRow();
				/*Inserta la Imagen*/
				for(int i = 1;i<=3;i++)
				{
					oHtmlTableCell = new HtmlTableCell();
					oHtmlTableCell.Width = "33.33%";
					oHtmlTableCell.InnerText = (i==1)?Monto1.ToString(Utilitario.Constantes.FORMATODECIMAL0):(i==2)?Monto2.ToString(Utilitario.Constantes.FORMATODECIMAL0):Monto3.ToString(Utilitario.Constantes.FORMATODECIMAL0);
					if(i>1)
					{
						oHtmlTableCell.Style.Add("Display","none");
					}
					oHtmlTableCell.Align = HorizontalAlign.Right.ToString();
					oHtmlTableCell.NoWrap=true;
					oHtmlTableRow.Controls.Add(oHtmlTableCell);
				}
				oHtmlTable.Rows.Add(oHtmlTableRow);
				oHtmlTable.Width = "100%";
				oHtmlTable.Border=0;
				oHtmlTable.CellPadding=0;
				oHtmlTable.CellSpacing=0;
				oHtmlTable.Attributes.Add("class","itemgrillasinColor");
				return oHtmlTable;
			}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ddlbMes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void dbGridResumen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dbGridResumen_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				double  TotalPeru = Convert.ToDouble(dr[Enumerados.FINColumnaResumenCuentasPorPagar.SimaCallao.ToString()])
									+ Convert.ToDouble(dr[Enumerados.FINColumnaResumenCuentasPorPagar.SimaChimbote.ToString()]);
				e.Item.Cells[1].Text = TotalPeru.ToString(Utilitario.Constantes.FORMATODECIMAL0);

				double TotalIquitos = Convert.ToDouble(dr[Enumerados.FINColumnaResumenCuentasPorPagar.SimaIquitos.ToString()]);


				e.Item.Cells[2].Text = TotalIquitos.ToString(Utilitario.Constantes.FORMATODECIMAL0);

				e.Item.Cells[3].Text = (TotalPeru + TotalIquitos).ToString(Utilitario.Constantes.FORMATODECIMAL0);
			}
		}

		private void ibtnPropuesta_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		}

		private void WriteToFile(string strPath, ref byte[] Buffer)
		{
			FileStream newFile = new FileStream(strPath,FileMode.Create);
			newFile.Write(Buffer, Utilitario.Constantes.ValorConstanteCero, Buffer.Length);
			newFile.Close();
		}

		private void ibtnGuardar_Click(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));

			const int TAMANOARCHIVO=5000000;

			HttpPostedFile myFile = filMyFileDocumento.PostedFile;
			int nFileLen = myFile.ContentLength; 

			if( nFileLen > Utilitario.Constantes.ValorConstanteCero )
			{
				if(nFileLen <= TAMANOARCHIVO)
				{	
					byte[] myData = new byte[nFileLen];

					myFile.InputStream.Read(myData,Utilitario.Constantes.ValorConstanteCero, nFileLen);
					string path = System.Configuration.ConfigurationSettings.AppSettings[NOMBREAPPSAVEXLS].ToString();
					//string path = @"C:\Inetpub\wwwroot\SimaNetWeb\Archivos\";
					string strFilename = myFile.FileName;

					string[] res = strFilename.Split('\\');
					int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];

					string[] ExtencionArchivo=strFilename.Split('.');
					if(ExtencionArchivo.Length>Utilitario.Constantes.ValorConstanteUno )
					{
						strFilename= Hoja; 
					}
					WriteToFile(path + strFilename,ref myData);
				}
			}		



		}

	}
}
