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
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using System.Configuration;

namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for AdministrarAccionesPorRecomendacion.
	/// </summary>
	public class AdministrarAccionesPorRecomendacion : System.Web.UI.Page,IPaginaBase
	{
		const string GRILLAVACIA ="No existe ningún regsitistro de acciones para esta recomendacion.";  

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Label LblObservacion;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label LblRecomendacion;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		const string KEYQDESCRIPCIONDOC = "DesDoc";

		const string KEYQIDOBSERVACION = "IdObservacion";
		const string KEYQDESCRIPCION = "Descripcion";

		const string KEYQIDRECOMENDACION = "IdRecomendacion";
		const string KEYQPERIODO = "Periodo";
		const string KEYQDESCRIPCIONRECOMENDACION = "DescRecomendacion";


		const string KEYQIDACCIONRECOMENDACION = "IdAccRec";
		protected System.Web.UI.HtmlControls.HtmlInputHidden hRutaHTTP;
		const string URLDETALLE="DetalleAccionesPorRecomendacion.aspx?";

		


		#region Propiedades de pagina adiciopnal

			private string DescripcionDocumento
			{
				get{return Convert.ToString(Page.Request.Params[KEYQDESCRIPCIONDOC]);}
			}

		
			private int IdObservacion
			{
				get{return Convert.ToInt32(Page.Request.Params[KEYQIDOBSERVACION]);}
			}
			private string DescripcionObservacion
			{
				get{return Convert.ToString(Page.Request.Params[KEYQDESCRIPCION]);}
			}

			private int Periodo
			{
				get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
			}
			private int IdRecomendacion
			{
				get{return Convert.ToInt32(Page.Request.Params[KEYQIDRECOMENDACION]);}
			}
			private string DescripcionRecomendacion
			{
				get{return Convert.ToString(Page.Request.Params[KEYQDESCRIPCIONRECOMENDACION]);}
			}

		#endregion

		private string OCIRutaHTTP
		{
			get{return ConfigurationSettings.AppSettings["RutaHTTPOCI"].ToString();}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Legal",this.ToString(),"Se consultó los ControlInterno Embargados.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarAccionesPorRecomendacion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarAccionesPorRecomendacion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt =(new CAccionRecomendacion()).ConsultarAccionRecomendaciones(this.IdRecomendacion,this.Periodo,0);

			if(dt!=null)
			{
				grid.DataSource = dt;
				grid.CurrentPageIndex =indicePagina;
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
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

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarAccionesPorRecomendacion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text = this.DescripcionDocumento;
			this.LblObservacion.Text = this.DescripcionObservacion;
			this.LblRecomendacion.Text = this.DescripcionRecomendacion;
			this.hRutaHTTP.Value = this.OCIRutaHTTP;
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Style["display"]="none";
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarAccionesPorRecomendacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarAccionesPorRecomendacion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarAccionesPorRecomendacion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarAccionesPorRecomendacion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarAccionesPorRecomendacion.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLDETALLE + KEYQIDOBSERVACION + Utilitario.Constantes.SIGNOIGUAL +  this.IdObservacion
									+ Utilitario.Constantes.SIGNOAMPERSON 
									+ KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL +  this.DescripcionObservacion
									+ Utilitario.Constantes.SIGNOAMPERSON 
									+ KEYQIDRECOMENDACION + Utilitario.Constantes.SIGNOIGUAL +  this.IdRecomendacion
									+ Utilitario.Constantes.SIGNOAMPERSON 
									+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL +  this.Periodo
									+ Utilitario.Constantes.SIGNOAMPERSON 
									+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModoPagina.N.ToString()
									);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hCodigo",dr["IdAccion"].ToString()));

				Helper.UIControls.DataGrid.CHiperLink((DataGrid)sender, e.Item.Cells[0]
														,"HistorialIrAdelantePersonalizado('hGridPaginaSort;hGridPagina')"
														,Helper.Response.Redirec(Page.Request.ApplicationPath +"/GestionControlInstitucional/"+ URLDETALLE 
														+ KEYQIDRECOMENDACION + Utilitario.Constantes.SIGNOIGUAL + this.IdRecomendacion.ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON 
														+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Periodo.ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON 
														+ KEYQDESCRIPCIONRECOMENDACION + Utilitario.Constantes.SIGNOIGUAL + this.DescripcionRecomendacion
														+ Utilitario.Constantes.SIGNOAMPERSON 
														+ KEYQIDOBSERVACION + Utilitario.Constantes.SIGNOIGUAL +  this.IdObservacion.ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON  
														+ KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + this.DescripcionObservacion
														+ Utilitario.Constantes.SIGNOAMPERSON  
														+ KEYQIDACCIONRECOMENDACION + Utilitario.Constantes.SIGNOIGUAL + dr["IdAccion"].ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON 
														+ KEYQDESCRIPCIONDOC+ Utilitario.Constantes.SIGNOIGUAL + this.DescripcionDocumento
														+ Utilitario.Constantes.SIGNOAMPERSON 
														+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModoPagina.M.ToString(),false)
														);

				

				DataTable dt = (new CAccionRecomendacion()).ConsultarAnexoAccionRecomendaciones(this.Periodo,Convert.ToInt32(dr["IdAccion"].ToString()),0);
				if(dt!=null)
				{
					foreach(DataRow dri in dt.Rows)
					{
						string NombreArchivo = dri["Archivo"].ToString();
						string []ArrExt = NombreArchivo.Split('.');
						string Ext=ArrExt[ArrExt.Length-1];
						string  Icono="";

						//LstAnexos += dr["IdAnexo"].ToString()+ ";" + dr["Archivo"].ToString() +"@";
						HtmlTable TBLItem =  Helper.CrearHtmlTabla(1,3,true);
						TBLItem.Attributes["IDANEXO"]= dri["IdAnexo"].ToString();
						TBLItem.Attributes["IDACCION"]= dr["IdAccion"].ToString();
						TBLItem.Attributes["PERIODO"]= this.Periodo.ToString();
						TBLItem.Attributes["NOMBRE"]= NombreArchivo;
						TBLItem.Attributes["EXTENSION"]= Ext;
						TBLItem.Border=0;						
						TBLItem.Attributes["class"] ="BaseItemInGrid";
						TBLItem.Style["MARGIN"]="2px";

						TBLItem.Rows[0].Cells[1].InnerText = NombreArchivo.Substring(0,NombreArchivo.Length-(Ext.Length+1));
						TBLItem.Rows[0].Cells[1].Attributes["noWrap"] ="noWrap";
						TBLItem.Rows[0].Cells[1].Style.Add("cursor","hand");
						TBLItem.Rows[0].Cells[1].Style["COLOR"]="blue";
						TBLItem.Rows[0].Cells[0].Style["TEXT-DECORATION"]="underline";
						//TBLItem.Rows[0].Cells[0].Attributes["DESCRIPCION"]= dri["DescripcionAccionInmediata"].ToString();
						//TBLItem.Rows[0].Cells[0].Attributes["onclick"]="ControldeAcciones(this,'" + dr["IdSAM"].ToString() + "','" + dr["IdUsuarioRegistro"].ToString() + "','" + dri["IdDestino"].ToString() + "')";

						if(Ext.ToUpper().Equals("DOC")||Ext.ToUpper().Equals("XLS")||Ext.ToUpper().Equals("PPT")||Ext.ToUpper().Equals("PDF"))
						{
							Icono=Ext.ToString()+".gif";
						}
						else
						{
							Icono="Otros.gif";
						}
						HtmlImage oImg = new HtmlImage();
						oImg.Style.Add("cursor", "hand");

						oImg.Src =  Page.Request.ApplicationPath +"/imagenes/Navegador/" + Icono;
						oImg.Attributes["onclick"]="AbrirDocumento(this)";
						TBLItem.Rows[0].Cells[0].Controls.Add(oImg);


						oImg = new HtmlImage();
						oImg.Style.Add("cursor", "hand");
						oImg.Src =  Page.Request.ApplicationPath +"/imagenes/Filtro/Eliminar.png";
						oImg.Attributes["onclick"]="Eliminar(this)";
						TBLItem.Rows[0].Cells[2].Controls.Add(oImg);

						e.Item.Cells[4].Controls.Add(TBLItem);


					}
				}




			}				
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			(new CAccionRecomendacion()).Eliminar(Convert.ToInt32(this.hCodigo.Value),this.Periodo);
			this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
			
		}
	}
}
