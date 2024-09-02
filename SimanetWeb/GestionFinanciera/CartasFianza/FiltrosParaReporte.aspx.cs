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
using SIMA.Controladoras.Legal;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.CartasFianza
{
	/// <summary>
	/// Summary description for FiltrosParaReporte.
	/// </summary>
	public class FiltrosParaReporte : System.Web.UI.Page,IPaginaBase
	{
		string cadena;
		DataTable dt=new DataTable();
		const string SDTFIANZA="DtFianza";
		protected System.Web.UI.WebControls.ImageButton imgXLS;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar2;
		protected System.Web.UI.WebControls.ImageButton imgXLS2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList DDLSITUACION;
		protected System.Web.UI.WebControls.TextBox txtNroFianza;
		protected System.Web.UI.WebControls.DropDownList ddlproyecto;
		protected System.Web.UI.WebControls.DropDownList DDLBENEFICIARIO;
		protected System.Web.UI.WebControls.DropDownList DDLBANCO;
		protected System.Web.UI.WebControls.DropDownList ddlCentro;
		protected System.Web.UI.WebControls.DropDownList ddlTipoDoc;
		protected System.Web.UI.WebControls.DropDownList DDLORIGEN;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList DDLTIPOPROCEDEN;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		private void Page_Load(object sender, System.EventArgs e)
		
		
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//dt=this.ObtenerDatos();
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarCombos();
					//Graba en el Log la acción ejecutada
					Helper.ReestablecerPagina();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),
						"Reporte",this.ToString(), "",Enumerados.NivelesErrorLog.I.ToString()));
				
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
			this.ibtnFiltrar2.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar2_Click);
			this.imgXLS2.Click += new System.Web.UI.ImageClickEventHandler(this.imgXLS2_Click);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.imgXLS.Click += new System.Web.UI.ImageClickEventHandler(this.imgXLS_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			
				// TODO:  Add FiltrosParaReporte.LlenarGrilla implementation
		}
		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add FiltrosParaReporte.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add FiltrosParaReporte.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.CargarOrigen();
			this.CargarCentrosOperativos();
			this.CargarEntidadFinanciera();
			this.CargarBeneficiario();
			this.CargarProyecto();
			this.CargarSituacion();
			this.CargarTipoDoc();
			this.CargarTipoProcedencia();
			//this.CargarMoneda();
			//this.CargarNroFianza();
			
		}

	
		private void CargarOrigen()
		{	
			const int IDOrigen=19;
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.DDLORIGEN.DataSource = oCTablaTablas.ListaTodosCombo(IDOrigen);
			this.DDLORIGEN.DataValueField= Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.DDLORIGEN.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			this.DDLORIGEN.DataBind();	
			ListItem item = new ListItem("[SELECCIONAR]","-1");
			DDLORIGEN.Items.Insert(0,item);
		}

		
		private void CargarTipoDoc()
		{
			DataView dv = (new CTablaTablas()).ListaTodosCombo(187).DefaultView;
			dv.RowFilter="abrev in ('FZA','FZS')";
			this.ddlTipoDoc.DataSource =dv;
			this.ddlTipoDoc.DataValueField= Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlTipoDoc.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			this.ddlTipoDoc.DataBind();
			
		}
		

		private void CargarCentrosOperativos()
		{
			DataTable dtco =new  DataTable();
			CCentroOperativo oCCentroOperativo = new CCentroOperativo();
			dtco = oCCentroOperativo.ListarTodosCombo();
			this.ddlCentro.DataSource =dtco;
			this.ddlCentro.DataTextField =Enumerados.ColumnasCentroOperativo.Nombre.ToString();
			this.ddlCentro.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			this.ddlCentro.DataBind();
			ListItem item = new ListItem("[SELECCIONAR]","-1");
			ddlCentro.Items.Insert(0,item);
		}

		private void CargarEntidadFinanciera()
		{
			//DDLBANCO.DataSource=Helper.SelectDistinct(dt,Enumerados.ColumnasEntidadFinanciera.Banco.ToString(),Enumerados.ColumnasEntidadFinanciera.Cod.ToString());
			DDLBANCO.DataSource=(new CCartaFianza()).ListarCartaFianzaEntidadFinanciera();
			DDLBANCO.DataTextField=Enumerados.ColumnasEntidadFinanciera.Banco.ToString();
			DDLBANCO.DataValueField=Enumerados.ColumnasEntidadFinanciera.Cod.ToString();
			DDLBANCO.DataBind();
			ListItem item = new ListItem("[SELECCIONAR]","-1");
			DDLBANCO.Items.Insert(0,item);
		}

		private void CargarTipoProcedencia()
		{	
						
			//this.DDLTIPOPROCEDEN.DataSource =Helper.SelectDistinct(dt,"TIPOPROCEDENCIA","IdTipoProcedencia");
			this.DDLTIPOPROCEDEN.Items.Add( new ListItem("IMPORTACION","2"));
			this.DDLTIPOPROCEDEN.Items.Add( new ListItem("LOCAL","1"));
			//this.DDLTIPOPROCEDEN.DataValueField = Enumerados.ColumnasTipoProcedencia.IdTipoProcedencia.ToString();
			//this.DDLTIPOPROCEDEN.DataTextField=Enumerados.ColumnasTipoProcedencia.TipoProcedencia.ToString();
			//this.DDLTIPOPROCEDEN.DataBind();
			ListItem item = new ListItem("[SELECCIONAR]","-1");
			DDLTIPOPROCEDEN.Items.Insert(0,item);		
	
		}

		private void CargarBeneficiario()
		{
				
			//DDLBENEFICIARIO.DataSource =Helper.SelectDistinct(dt,"BENEFICIARIO","codBeneficiario");
			DDLBENEFICIARIO.DataSource =(new CCartaFianza()).ListarCartaFianzaBeneficiario();
			DDLBENEFICIARIO.DataValueField = Enumerados.ColumnasBeneficiario.codBeneficiario.ToString();
			DDLBENEFICIARIO.DataTextField=Enumerados.ColumnasBeneficiario.Beneficiario.ToString();
			DDLBENEFICIARIO.DataBind();
			ListItem item = new ListItem("[SELECCIONAR]","-1");
			DDLBENEFICIARIO.Items.Insert(0,item);
				
		}

		private void CargarProyecto()
		{
			//ddlproyecto.DataSource =Helper.SelectDistinct(dt,"NOMPROYECTO","IdProyecont");
			ddlproyecto.DataSource =(new CCartaFianza()).ListarCartaFianzaProyectos();			
			ddlproyecto.DataValueField = Enumerados.ColumnasProyecto.IdProyecont.ToString();
			ddlproyecto.DataTextField=Enumerados.ColumnasProyecto.NomProyecto.ToString();
			ddlproyecto.DataBind();
			ListItem item = new ListItem("[SELECCIONAR]","-1");
			ddlproyecto.Items.Insert(0,item);
						
		}

		private void CargarSituacion()
		{
			/*CCartaFianza oCCartaFianza=new CCartaFianza();
		  	DataTable dtcf = oCCartaFianza.ListarTodosCombo();*/
			//this.DDLSITUACION.DataSource = Helper.SelectDistinct(dt,"Descripcion","codSituacion");
			this.DDLSITUACION.DataSource =(new CCartaFianza()).ListarCartaFianzaSituacion();
			this.DDLSITUACION.DataTextField = Enumerados.ColumnasVEstadosCartaFianza.Descripcion.ToString();
			this.DDLSITUACION.DataValueField=Enumerados.ColumnasVEstadosCartaFianza.codSituacion.ToString();
			this.DDLSITUACION.DataBind();
			ListItem item = new ListItem("[SELECCIONAR]","-1");
			DDLSITUACION.Items.Insert(0,item);
		}
		
		public void LlenarDatos()
		{
			// TODO:  Add FiltrosParaReporte.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add FiltrosParaReporte.LlenarJScript implementation
			/*imgXLS2.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.PopupDeEspera() + Helper.HistorialIrAdelantePersonalizado(this.DDLORIGEN.ID.ToString(),this.DDLBANCO.ID.ToString(),this.ddlCentro.ID.ToString(),this.DDLTIPOPROCEDEN.ID.ToString(),this.DDLBENEFICIARIO.ID.ToString(),this.ddlproyecto.ID.ToString(),this.txtNroFianza.ID.ToString(),this.DDLSITUACION.ID.ToString()));
			imgXLS.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.PopupDeEspera() + Helper.HistorialIrAdelantePersonalizado(this.DDLORIGEN.ID.ToString(),this.DDLBANCO.ID.ToString(),this.ddlCentro.ID.ToString(),this.DDLTIPOPROCEDEN.ID.ToString(),this.DDLBENEFICIARIO.ID.ToString(),this.ddlproyecto.ID.ToString(),this.txtNroFianza.ID.ToString(),this.DDLSITUACION.ID.ToString()));
			ibtnFiltrar2.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.PopupDeEspera() + Helper.HistorialIrAdelantePersonalizado(this.DDLORIGEN.ID.ToString(),this.DDLBANCO.ID.ToString(),this.ddlCentro.ID.ToString(),this.DDLTIPOPROCEDEN.ID.ToString(),this.DDLBENEFICIARIO.ID.ToString(),this.ddlproyecto.ID.ToString(),this.txtNroFianza.ID.ToString(),this.DDLSITUACION.ID.ToString()));*/
			this.ibtnFiltrar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.PopupDeEspera() + Helper.HistorialIrAdelantePersonalizado(this.DDLORIGEN.ID.ToString(),this.DDLBANCO.ID.ToString(),this.ddlCentro.ID.ToString(),this.DDLTIPOPROCEDEN.ID.ToString(),this.DDLBENEFICIARIO.ID.ToString(),this.ddlproyecto.ID.ToString(),this.txtNroFianza.ID.ToString(),/*this.
			.ID.ToString(),*/this.DDLSITUACION.ID.ToString()));
			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add FiltrosParaReporte.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add FiltrosParaReporte.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add FiltrosParaReporte.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add FiltrosParaReporte.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add FiltrosParaReporte.ValidarFiltros implementation
			return false;
		}

		#endregion

		private string ObtenerCadenafiltro()
		{
			cadena="";
			string Criterio = " Origen="+"'"+DDLORIGEN.SelectedItem.Value+"'" ;
			if(Convert.ToInt32(DDLORIGEN.SelectedItem.Value)!=-1){cadena=((cadena.Length>0)? cadena + " and " + Criterio :Criterio) ;}
			Criterio=" CO="+"'"+ddlCentro.SelectedItem.Value+"'";
			if(Convert.ToInt32(ddlCentro.SelectedItem.Value) !=-1){cadena= ((cadena.Length>0)?cadena + " and " + Criterio :Criterio) ;}
			Criterio=" COD="+"'"+DDLBANCO.SelectedItem.Value+"'";
			if(Convert.ToInt32(DDLBANCO.SelectedItem.Value) !=-1){cadena= ((cadena.Length>0)?cadena + " and " + Criterio :Criterio) ;}
			Criterio=" IdTipoProcedencia="+"'"+DDLTIPOPROCEDEN.SelectedItem.Value+"'";					
			if(Convert.ToInt32(DDLTIPOPROCEDEN.SelectedItem.Value)!=-1){cadena=((cadena.Length>0)?cadena + " and " + Criterio :Criterio);}
			Criterio=" codBeneficiario="+"'"+DDLBENEFICIARIO.SelectedItem.Value+"'";			
			if(Convert.ToInt32(DDLBENEFICIARIO.SelectedItem.Value) !=-1){cadena= ((cadena.Length>0)?cadena + " and " + Criterio :Criterio) ;}
			Criterio=" IdProyecont="+"'"+ddlproyecto.SelectedItem.Value+"'";			
			if(Convert.ToInt32(ddlproyecto.SelectedItem.Value) !=-1){cadena= ((cadena.Length>0)?cadena + " and " + Criterio :Criterio) ;}
			Criterio=" NroDeFianza="+"'"+txtNroFianza.Text+"'";			
			if(txtNroFianza.Text!=""){cadena= ((cadena.Length>0)?cadena + " and " + Criterio :Criterio) ;}
			Criterio=" codSituacion="+"'"+DDLSITUACION.SelectedItem.Value+"'";			
			if(Convert.ToInt32(DDLSITUACION.SelectedItem.Value) !=-1){cadena= ((cadena.Length>0)?cadena + " and " + Criterio :Criterio) ;}
			Criterio=" IdTipoDocFin="+ this.ddlTipoDoc.SelectedValue.ToString(); 
			cadena= ((cadena.Length>0)?cadena + " and " + Criterio :Criterio);
			return cadena;

		}



		private DataTable ObtenerDatos()
		{
			//Session[SDTFIANZA]=
			return (new CCartaFianza()).ReporteCartaFianzaV2(Convert.ToInt32(this.ddlCentro.SelectedValue)
															,DDLORIGEN.SelectedItem.Value
															,DDLBANCO.SelectedItem.Value
															,DDLTIPOPROCEDEN.SelectedItem.Value
															,DDLBENEFICIARIO.SelectedItem.Value
															,ddlproyecto.SelectedItem.Value
															,txtNroFianza.Text
															,DDLSITUACION.SelectedItem.Value
															,this.ddlTipoDoc.SelectedValue.ToString());

			//return (DataTable)Session[SDTFIANZA];
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//DataTable dto=(DataTable)Session[SDTFIANZA];
			DataTable dto=ObtenerDatos();
			//if (dto!=null)
			{
				
				//DataColumn dc = new DataColumn("Seleccion",System.Type.GetType("System.Int32"));
				/*string sel=Convert.ToString(dc.ColumnName);
				if(sel!="Seleccion")
				{
                	dc.DefaultValue=((Convert.ToInt32(DDLSITUACION.SelectedItem.Value) >-1)?1:0);
					dto.Columns.Add(dc);
					int x=Convert.ToInt32(dto.Rows[2]["Seleccion"]);
				}*/
				//else
				//{
					/*dto.Columns.Remove("Seleccion");
					dc.DefaultValue=((Convert.ToInt32(DDLSITUACION.SelectedItem.Value) >-1)?1:0);
					dto.Columns.Add(dc);
					int y=Convert.ToInt32(dto.Rows[2]["Seleccion"]);
					
					*/
				//}
				/*DataView dv     = dto.DefaultView;
				dv.RowFilter    = this.ObtenerCadenafiltro();*/

				//Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\OperacionesFinancieras\","ReporteCartaFianza.rpt",Helper.DataViewTODataTable(dv),false,false,".xls");
				//Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\OperacionesFinancieras\","ReporteCartaFianza.rpt",Helper.DataViewTODataTable(dv),false,false,".pdf");
				Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\OperacionesFinancieras\","ReporteCartaFianza.rpt",dto,false,false,".pdf");
				
				
			}
			//else
			{
				//this.lblResultado.Text    = GRILLAVACIA;
			}
			
		}

		private void imgXLS_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//DataTable dto=(DataTable)Session[SDTFIANZA];
			DataTable dto=ObtenerDatos();
			if (dto!=null)
			{
				
				/*DataColumn dc = new DataColumn("Seleccion",System.Type.GetType("System.Int32"));
				dto.Columns.Remove("Seleccion");
				dc.DefaultValue=((Convert.ToInt32(DDLSITUACION.SelectedItem.Value) >-1)?1:0);
				dto.Columns.Add(dc);
				int y=Convert.ToInt32(dto.Rows[2]["Seleccion"]);
					*/

				DataView dv     = dto.DefaultView;
				//dv.RowFilter    = this.ObtenerCadenafiltro();

				try
				{
				  	DataSet dsSrc= new DataSet("Reportes");
					dsSrc.Tables.Add(Helper.DataViewTODataTable(dv));
					Helper.Archivo.GenerarReporteToXls(264,dsSrc,true);
					
				}
				catch (Exception ex)
				{		
					int i=0;	
					i++;
				}

		
			}
			else
			{
				//this.lblResultado.Text    = GRILLAVACIA;
			}		
		}

	
		private void ibtnFiltrar2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//DataTable dto=(DataTable)Session[SDTFIANZA];
			DataTable dto=ObtenerDatos();
			if (dto!=null)
			{
				
				//DataColumn dc = new DataColumn("Seleccion",System.Type.GetType("System.Int32"));
				/*string sel=Convert.ToString(dc.ColumnName);
				if(sel!="Seleccion")
				{
					dc.DefaultValue=((Convert.ToInt32(DDLSITUACION.SelectedItem.Value) >-1)?1:0);
					dto.Columns.Add(dc);
					int x=Convert.ToInt32(dto.Rows[2]["Seleccion"]);
				}*/
				//else
				//{
				/*dto.Columns.Remove("Seleccion");
				dc.DefaultValue=((Convert.ToInt32(DDLSITUACION.SelectedItem.Value) >-1)?1:0);
				dto.Columns.Add(dc);
				int y=Convert.ToInt32(dto.Rows[2]["Seleccion"]);*/
				
					
				//}
				//DataView dv     = dto.DefaultView;
				//dv.RowFilter    = this.ObtenerCadenafiltro();

				//Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\OperacionesFinancieras\","ReporteCartaFianzaB.rpt",Helper.DataViewTODataTable(dv),false,false,".xls");
				Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\OperacionesFinancieras\","ReporteCartaFianzaB.rpt",dto,false,false,".pdf");
				
			}
			else
			{
				//this.lblResultado.Text    = GRILLAVACIA;
			}
			
		}

		private void DDLORIGEN_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void imgXLS2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//DataTable dto=(DataTable)Session[SDTFIANZA];
			DataTable dto=ObtenerDatos();
			if (dto!=null)
			{
			
				/*DataColumn dc = new DataColumn("Seleccion",System.Type.GetType("System.Int32"));
				dto.Columns.Remove("Seleccion");
				dc.DefaultValue=((Convert.ToInt32(DDLSITUACION.SelectedItem.Value) >-1)?1:0);
				dto.Columns.Add(dc);
				int y=Convert.ToInt32(dto.Rows[2]["Seleccion"]);*/
					
				
				DataView dv     = dto.DefaultView;
				//dv.RowFilter    = this.ObtenerCadenafiltro();

				try
				{
					DataSet dsSrc= new DataSet("Reportes");
					dsSrc.Tables.Add(Helper.DataViewTODataTable(dv));
					Helper.Archivo.GenerarReporteToXls(470,dsSrc,true);
					
					
				}
				catch(Exception ex)
				{		
					int i=0;	
					i++;
				}

		
			}
			else
			{
				//this.lblResultado.Text    = GRILLAVACIA;
			}
		


		}

	
	



	}
}
