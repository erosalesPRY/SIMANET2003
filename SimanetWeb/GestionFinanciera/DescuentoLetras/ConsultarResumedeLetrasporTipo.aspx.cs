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
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras
{
	/// <summary>
	/// Summary description for ConsultarLetrasporTipo.
	/// </summary>
	public class ConsultarResumedeLetrasporTipo : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string GRILLAVACIA ="No existe ningún Registro.";  
//			const string KEYIDTIPOLETRA = "TipoDLetra";
//			const string KEYIDNOMBRETIPO ="NomTipo";

			const string KEYIDTIPOLETRA = "TipoLetra";
			const string KEYNOMBRETIPOLETRA = "NombreTipoLetra";

			const string KEYIDSITUACION ="Situacion";
			const string KEYIDSITUACIONDESCRIPCION ="DescSituacion";

			const string KEYIDCENTRO = "idCentro";
			const string NOMBRECENTRO = "NombreCO";

			//const string URLDETALLE = "ConsultarDescuentodeLetrasPorSituacionyCentro.aspx?";
			const string URLDETALLE = "ConsultarLetrasporTipoySituacion.aspx?";
			const string URLSITUACIONPORCENTRO = "ConsultarResumendeLetrasporTipoSituacionyCentro.aspx?";

			const string URLDETALLEDESCUENTOLETRAS = "ConsultarDescuentodeLetras.aspx?";
		

			const string CAMPO1 = "lblMontoCallaoS";
			const string CAMPO2 = "lblMontoCallaoD";
			const string CAMPO3 = "lblMontoChimboteS";
			const string CAMPO4 = "lblMontoChimboteD";
			const string CAMPO5 = "lblMontoIquitosS";
			const string CAMPO6 = "lblMontoIquitosD";
			const string CAMPO7 = "lblMontoTotalS";
			const string CAMPO8 = "lblMontoTotalD";

			const string LBLCALLAO = "lblhCallao";
			const string LBLCHIMBOTE = "lblHChimbote";
			const string LBLIQUITOS = "lblHIquitos";
		
		//Otros
			const string VARIABLESESSIONTOTALIZA ="Totaliza";
			const string VARIABLESESSIONDIRLETRA ="finDirLTRA";

		//Columnas Grilla
			const string COLUMNAMONTOCALLAOSOLES ="MontoCallaoSoles";
			const string COLUMNAMONTOCALLAODOLARES ="MontoCallaoDolar";
			const string COLUMNAMONTOCHIMBOTESOLES ="MontoChimboteSoles";
			const string COLUMNAMONTOCHIMBOTEDOLARES ="MontoChimboteDolar";
			const string COLUMNAMONTOIQUITOSSOLES ="MontoIquitosSoles";
			const string COLUMNAMONTOIQUITOSDOLARES ="MontoIquitosDolar";
			const string COLUMNAMONTOTOTALSOLES ="MontoTotalSoles";
			const string COLUMNAMONTOTOTALDOLARES ="MontoTotalDolar";

			const string COLUMNAIDSITUACION ="idSituacion";

		//Otros
			const string NOMBRECLASEFOOTER ="FooterGrilla";

		//Nuevo
		const string KEYQIDFORMATO = "IdFormato";


		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoLetra;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
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
					this.LlenarCombos();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
			this.ddlbTipoLetra.SelectedIndexChanged += new System.EventHandler(this.ddlbTipoLetra_SelectedIndexChanged);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarLetrasporTipo.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarLetrasporTipo.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			return ((CLetras)new CLetras()).ConsultarResumendeLetrasporSituacion(Convert.ToInt32(this.ddlbTipoLetra.SelectedValue));
		}
		private void Totalizar(DataTable dtOrigen)
		{
			if (dtOrigen !=null)
			{
				ArrayList arrTotal = new ArrayList();
				double []TotalCallaoS = Helper.TotalizarDataView(dtOrigen.DefaultView,"MontoCallaoSoles");
				arrTotal.Add(TotalCallaoS[0]);
				double []TotalCallaoD = Helper.TotalizarDataView(dtOrigen.DefaultView,"MontoCallaoDolar");
				arrTotal.Add(TotalCallaoD[0]);
				double []TotalChimboteS = Helper.TotalizarDataView(dtOrigen.DefaultView,"MontoChimboteSoles");
				arrTotal.Add(TotalChimboteS[0]);
				double []TotalChimboteD = Helper.TotalizarDataView(dtOrigen.DefaultView,"MontoChimboteDolar");
				arrTotal.Add(TotalChimboteD[0]);
				double []TotalIquitosS = Helper.TotalizarDataView(dtOrigen.DefaultView,"MontoIquitosSoles");
				arrTotal.Add(TotalIquitosS[0]);
				double []TotalIquitosD = Helper.TotalizarDataView(dtOrigen.DefaultView,"MontoIquitosDolar");
				arrTotal.Add(TotalIquitosD[0]);
				double []TotalTotalS = Helper.TotalizarDataView(dtOrigen.DefaultView,"MontoTotalSoles");
				arrTotal.Add(TotalTotalS[0]);
				double []TotalTotalD = Helper.TotalizarDataView(dtOrigen.DefaultView,"MontoTotalDolar");
				arrTotal.Add(TotalTotalD[0]);
				Session[VARIABLESESSIONTOTALIZA] = arrTotal;
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				this.Totalizar(dtGeneral);
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.RowFilter = Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();
				dwGeneral.Sort = columnaOrdenar ;
				grid.DataSource = dwGeneral;
				grid.CurrentPageIndex = indicePagina;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtGeneral,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = true;
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

		private void CargarTipodeLetra()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbTipoLetra.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.FinancieraTipodeLetras));
			ddlbTipoLetra.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoLetra.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipoLetra.DataBind();	
			if(Page.Request.Params[KEYQIDFORMATO]!= null)
			{
				if(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])== 18) //Ctas Por Pagar
				{
					ddlbTipoLetra.SelectedIndex = 1;
					this.ddlbTipoLetra.Enabled = false;
				}
				if(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])== 19) //Ctas Por Cobrar
				{
					ddlbTipoLetra.SelectedIndex = 0;
					this.ddlbTipoLetra.Enabled = false;
				}				
			}
			else
			{
				if (Session[VARIABLESESSIONDIRLETRA]!=null)
				{
					ddlbTipoLetra.SelectedIndex = Convert.ToInt32(Session[VARIABLESESSIONDIRLETRA]);
				}
			}
			Helper.SeleccionarItemCombos(this);
		}

		


		public void LlenarCombos()
		{
			this.CargarTipodeLetra();
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarLetrasporTipo.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarLetrasporTipo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarLetrasporTipo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarLetrasporTipo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarLetrasporTipo.Exportar implementation
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
			// TODO:  Add ConsultarLetrasporTipo.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				string QueryPrincipal =Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModuloConsulta.Si.ToString() 
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + this.ddlbTipoLetra.SelectedValue.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + this.ddlbTipoLetra.SelectedItem.Text.ToLower()
					+ Utilitario.Constantes.SIGNOAMPERSON;
				
				#region SIMA CALLAO
				Helper.ConfiguraColumnaHyperLink((Label) e.Item.Cells[2].FindControl(LBLCALLAO),"Ver detalle (Sima Callao)",
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
					Helper.MostrarVentana(URLSITUACIONPORCENTRO,QueryPrincipal
																+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCALLAO.ToString()
																+ Utilitario.Constantes.SIGNOAMPERSON
																+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCALLAO.ToString()
																));
				#endregion

				#region SIMA CHIMBOTE
				Helper.ConfiguraColumnaHyperLink((Label) e.Item.Cells[3].FindControl(LBLCHIMBOTE),"Ver detalle (Sima Chimbote)",
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
					Helper.MostrarVentana(URLSITUACIONPORCENTRO,QueryPrincipal
																+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCHIMBOTE.ToString()
																+ Utilitario.Constantes.SIGNOAMPERSON
																+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCHIMBOTE.ToString()
											));
				#endregion

				#region SIMA IQUITOS
				Helper.ConfiguraColumnaHyperLink((Label) e.Item.Cells[4].FindControl(LBLIQUITOS),"Ver detalle (Sima Iquitos)",
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
					Helper.MostrarVentana(URLSITUACIONPORCENTRO,QueryPrincipal
																+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROIQUITOS.ToString()
																+ Utilitario.Constantes.SIGNOAMPERSON
																+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROIQUITOS.ToString()
												));
				#endregion


			}			
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				((Label)e.Item.Cells[2].FindControl(CAMPO1)).Text= Convert.ToDouble(dr[COLUMNAMONTOCALLAOSOLES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[2].FindControl(CAMPO2)).Text= Convert.ToDouble(dr[COLUMNAMONTOCALLAODOLARES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				((Label)e.Item.Cells[3].FindControl(CAMPO3)).Text= Convert.ToDouble(dr[COLUMNAMONTOCHIMBOTESOLES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[3].FindControl(CAMPO4)).Text= Convert.ToDouble(dr[COLUMNAMONTOCHIMBOTEDOLARES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[4].FindControl(CAMPO5)).Text= Convert.ToDouble(dr[COLUMNAMONTOIQUITOSSOLES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[4].FindControl(CAMPO6)).Text= Convert.ToDouble(dr[COLUMNAMONTOIQUITOSDOLARES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label)e.Item.Cells[5].FindControl(CAMPO7)).Text= Convert.ToDouble(dr[COLUMNAMONTOTOTALSOLES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[5].FindControl(CAMPO8)).Text= Convert.ToDouble(dr[COLUMNAMONTOTOTALDOLARES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				
//				if (Convert.ToInt32(dr["idSituacion"])==3)
//				{
//					Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
//							Helper.HistorialIrAdelantePersonalizado("ddlbTipoLetra","hGridPagina","hGridPaginaSort"),
//							Helper.MostrarVentana(URLDETALLEDESCUENTOLETRAS,KEYIDSITUACION+ Utilitario.Constantes.SIGNOIGUAL + dr["idSituacion"].ToString()
//																			+ Utilitario.Constantes.SIGNOAMPERSON
//																			+ KEYIDSITUACIONDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[1].Text
//																			+ Utilitario.Constantes.SIGNOAMPERSON
//																			+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModuloConsulta.Si.ToString() 
//																			+ Utilitario.Constantes.SIGNOAMPERSON
//																			+ KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + this.ddlbTipoLetra.SelectedValue.ToString()
//																			+ Utilitario.Constantes.SIGNOAMPERSON
//																			+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + this.ddlbTipoLetra.SelectedItem.Text.ToLower()));
//
//				}
//				else

				{
					Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
						Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
						Helper.MostrarVentana(URLDETALLE,KEYIDSITUACION+ Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNAIDSITUACION].ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ KEYIDSITUACIONDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[1].Text
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModuloConsulta.Si.ToString() 
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + this.ddlbTipoLetra.SelectedValue.ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + this.ddlbTipoLetra.SelectedItem.Text.ToLower()));
				}
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
			#region FOOTER
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[0].ColumnSpan=2;
				e.Item.Cells[0].CssClass = NOMBRECLASEFOOTER;
				e.Item.Cells[1].Visible=false;
				ArrayList arrTotal = (ArrayList) Session[VARIABLESESSIONTOTALIZA];
				string []NombreControlLbl = {"lblFMontoCallaoS","lblFMontoCallaoD","lblFMontoChimboteS","lblFMontoChimboteD","lblFMontoIquitosS","lblFMontoIquitosD","lblFMontoTotalS","lblFMontoTotalD"};
				int []ColPoslLbl = {2,2,3,3,4,4,5,5};
				for(int i=0;i<=NombreControlLbl.Length-1;i++)
				{
					((Label) e.Item.Cells[ColPoslLbl[i]].FindControl(NombreControlLbl[i].ToString())).Text=Convert.ToDouble(arrTotal[i]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}
				Session[VARIABLESESSIONTOTALIZA]=null;
			}		
			#endregion
		}

		private void ddlbTipoLetra_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[VARIABLESESSIONDIRLETRA]=ddlbTipoLetra.SelectedIndex;
			this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	

		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());

		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
