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
using NullableTypes;
using MetaBuilders.WebControls;
using System.Diagnostics; 
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.General;

namespace SIMA.SimaNetWeb.General.Materiales
{
	/// <summary>
	/// Summary description for AdministrarCatalogoMaterialesFichaTecnica.
	/// </summary>
	public class AdministrarCatalogoMaterialesFichaTecnica : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtCodigo;
		protected System.Web.UI.WebControls.TextBox txtNombreIngles;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtReferencia;
		protected System.Web.UI.WebControls.TextBox txtUso;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCargar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HNombreImagen;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtNombreGenerico;
		protected System.Web.UI.WebControls.TextBox txtNombreEspecifico;
		protected System.Web.UI.HtmlControls.HtmlInputFile FUFile;
		protected System.Web.UI.WebControls.ImageButton ImgImprimir;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox txtBuscar;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					//Graba en el Log la acción ejecutada
					this.LlenarJScript();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrilla();
					Helper.ReestablecerPagina();
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}

			if((hCargar.Value!="0")&&(hCargar.Value.Length!=0))
			{
				Utilitario.Helper.SubirArchivo(this.FUFile,Helper.Configuracion.Materiales.FitaTecnica.LocalDirImgs);
				MaterialesFichaTecnicaBE oMaterialesFichaTecnicaBE = new MaterialesFichaTecnicaBE();
				oMaterialesFichaTecnicaBE.CodigoMat = this.txtCodigo.Text;
				oMaterialesFichaTecnicaBE.NomgreImg =  this.HNombreImagen.Value;
				(new SIMA.Controladoras.General.CMaterialesFichaTecnica()).Insertar(oMaterialesFichaTecnicaBE);
				
				hCargar.Value="0";
				RegisterStartupScript("Progress","<script>ProgresoUpLoad();</script>");
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
			this.ImgImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ImgImprimir_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("DES_EQU",System.Type.GetType("System.String"));
			this.grid.DataSource = dt;
			this.grid.DataBind();

		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarCatalogoMaterialesFichaTecnica.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarCatalogoMaterialesFichaTecnica.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarCatalogoMaterialesFichaTecnica.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarCatalogoMaterialesFichaTecnica.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.TextBox1.Style["display"]="none";
			this.ImgImprimir.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.HistorialIrAdelantePersonalizado("txtBuscar","txtCodigo","txtDescripcion","txtNombreGenerico","txtNombreEspecifico","txtNombreIngles","txtReferencia","txtUso")+Helper.PopupDeEspera());
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarCatalogoMaterialesFichaTecnica.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarCatalogoMaterialesFichaTecnica.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarCatalogoMaterialesFichaTecnica.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarCatalogoMaterialesFichaTecnica.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarCatalogoMaterialesFichaTecnica.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ImgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			DataSet ds = new DataSet("sw");
			DataTable dtHeader = (new CMaterialesFichaTecnica()).ListarMaterialesPorCriterios("cod_mat",this.txtCodigo.Text);
			if(dtHeader!=null){
				dtHeader.Columns.Add("BLOBData", System.Type.GetType("System.Byte[]"));
				dtHeader.Columns.Add("NOMBREINGLES2", System.Type.GetType("System.String"));
				dtHeader.Columns.Add("REFERENCIA", System.Type.GetType("System.String"));
				dtHeader.Columns.Add("NroPersonal", System.Type.GetType("System.String"));
				dtHeader.Columns.Add("ApellidosyNomobres", System.Type.GetType("System.String"));
				dtHeader.Columns.Add("CentrodeCosto", System.Type.GetType("System.String"));

				DataRow dr = dtHeader.Rows[0];
				dr["BLOBData"]= Helper.ConversionImagen(Helper.Configuracion.Materiales.FitaTecnica.LocalDirImgs + this.TextBox1.Text);
				if(this.txtNombreIngles.Text.Length>0)
				{
					string []arrNomIng = this.txtNombreIngles.Text.ToString().Split(';');
					if (arrNomIng.Length>1){ 
						dr["NOMBREINGLES"]= arrNomIng[0].ToString();
						dr["NOMBREINGLES2"]= arrNomIng[1].ToString();
					}
				}
				dr["REFERENCIA"]= this.txtReferencia.Text;
				dr["NroPersonal"]= CNetAccessControl.GetUserNroPersonal(); 
				dr["ApellidosyNomobres"]= CNetAccessControl.GetUserApellidosNombres();
				dr["CentrodeCosto"]= CNetAccessControl.GetUserNombredeCentrodeCosto();

				DataTable dt1 =  Helper.DataViewTODataTable(dtHeader.DefaultView);
				dt1.TableName="LOGuspNTADConsultadeMateriales;1";
				ds.Tables.Add(dt1);

				DataTable dt2 = Helper.DataViewTODataTable((new CMaterialesFichaTecnica()).ListarDetalleFicha(this.txtCodigo.Text).DefaultView);
				if(dt2!=null)
					{
						dt2.TableName="LOGuspNTADConsultarDetalleFichaTecnica;1";
						ds.Tables.Add(dt2);
					}

			}
			

			Helper.EjecutarReporte(@"C:\SimanetReportes\Logistica\","FichaTecnicadeMaterial.rpt",ds,false);
					/*DataTable dt1 =  Helper.DataViewTODataTable((new CCartaFianza()).ConsultarCartaFianzaDetallePorNro("nrocartafianza",txtNroCartaFianza.Text,1).DefaultView);
					dt1.TableName="FINuspNTADConsultarCartaFianzaDetallePorNro;1";
					ds.Tables.Add(dt1);
					*/


					/*DataTable dt2 = Helper.DataViewTODataTable((new CCartaFianza()).ConsultarRenovacionCartaFianza(Convert.ToInt32(this.hidCFza.Value),Convert.ToInt32(this.hPeriodo.Value)).DefaultView);
					if(dt2!=null)
					{
						dt2.TableName="FINuspNTADConsultaCartaFianzaRenovacion;1";
						ds.Tables.Add(dt2);
					}

					DataTable dt3 = (new CCartaFianza()).ConsultarCartaFianzaNotadeCargo(Convert.ToInt32(this.hidCentroOperativo.Value)
						,0
						,Convert.ToInt32(this.hidCFza.Value)
						,Convert.ToInt32(this.hPeriodo.Value));
					if(dt3!=null)
					{
						dt3.TableName="FINuspNTADConsultaCartaFianzaNota;1";
						ds.Tables.Add(Helper.DataViewTODataTable(dt3.DefaultView));
					}
					else
					{

						dt3  = new DataTable("FINuspNTADConsultaCartaFianzaNota;1");
						ds.Tables.Add(dt3);

					}
					*/
					//Helper.EjecutarReporte(@"C:\SimanetReportes\Logistica\","FichaTecnicadeMaterial.rpt",ds,false);
		}
	}
}
