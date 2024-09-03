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
using SIMA.Controladoras.Personal;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using System.Drawing;


namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for AdministrarFichaMedicaSIMA.
	/// </summary>
	public class AdministrarFichaMedicaSIMA : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtApellidosyNombres;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlAptitud;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.ImageButton imgAgregar;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtFechaIni;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtFechaVence;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.DropDownList pddlAptitud;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox pCalFecha;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox ptxtFechaVence;
		protected System.Web.UI.WebControls.Button btnModifica;
		protected System.Web.UI.WebControls.Button ibtnEliminar;
		protected System.Web.UI.WebControls.Button btnFiltar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdFila;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodo;
		protected System.Web.UI.HtmlControls.HtmlTableCell ContextSCTR;
	
		
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonal;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtDiasDescanso;
		protected System.Web.UI.WebControls.TextBox txtPR;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdFicha;
		protected System.Web.UI.WebControls.TextBox ptxtNroPR;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.TextBox txtNdiasDescanso;
		protected System.Web.UI.WebControls.TextBox ptxtApellidosyNombres;

		string ParamArgument="";
		private string IDREG;
		string strObj="";

		const string KEYQPR ="NroPR";
		const string KEYQPERIODO ="Periodo";
		const string KEYQIDFICHA ="IdFicha";
		protected System.Web.UI.WebControls.Button cmdMedicamento;
		const string KEYQNOMTRAB ="NomTrab";


		private void Page_Load(object sender, System.EventArgs e)
		{
			strObj=Page.Request.Params["__EVENTTARGET"];
			ParamArgument=Page.Request.Params["__EVENTARGUMENT"];

            Page.GetPostBackEventReference(this, "MyEventArgumentName");

			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Programación Personal Contratista", this.ToString(),"Se consultó El Listado de las programaciones de los contratistas",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina();
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
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
			this.imgAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.imgAgregar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
			this.ibtnEliminar.Click += new System.EventHandler(this.ibtnEliminar_Click);
			this.btnFiltar.Click += new System.EventHandler(this.btnFiltar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.LlenarGrillaOrdenamiento implementation
		}
		DataTable ObtenerDatos()
		{
			int idPersonal = ((this.hIdPersonal.Value.Length==0)?0:Convert.ToInt32(this.hIdPersonal.Value));
			return(new CCCTT_FichaMedicaTSima()).ListaFicha(0,0,idPersonal);
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.Sort         = columnaOrdenar;
				dv.RowFilter    = Utilitario.Helper.ObtenerFiltro();
				grid.DataSource = dv;
				grid.CurrentPageIndex = indicePagina;
			}
			else
			{
				grid.DataSource = dt;
			}
			
			try
			{
				grid.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}		
		}

		public void LlenarCombos()
		{
			DataTable dtAptitud = (new SIMA.Controladoras.General.CTablaTablas()).ListaItemTablas(572);
			this.ddlAptitud.DataSource=dtAptitud;
			this.ddlAptitud.DataTextField="Descripcion";
			this.ddlAptitud.DataValueField="Codigo";
			this.ddlAptitud.DataBind();
			this.ddlAptitud.Items.Insert(0,(new ListItem("Seleccionar","0")));

			this.pddlAptitud.DataSource=dtAptitud ;
			this.pddlAptitud.DataTextField="Descripcion";
			this.pddlAptitud.DataValueField="Codigo";
			this.pddlAptitud.DataBind();		
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarFichaMedicaSIMA.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void btnFiltar_Click(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}

		private void imgAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(ValidarCampos())
			{
				ExamenMedicoSIMABE oExamenMedicoSIMABE = new ExamenMedicoSIMABE();

				oExamenMedicoSIMABE.NroPR= this.txtPR.Text;
				oExamenMedicoSIMABE.IdPersonal= Convert.ToInt32(this.hIdPersonal.Value);
				oExamenMedicoSIMABE.NroDias= Convert.ToInt32(this.txtDiasDescanso.Text);

				oExamenMedicoSIMABE.IdCM= 1;
				oExamenMedicoSIMABE.FechaInicio= DateTime.Parse(this.txtFechaIni.Text);
				oExamenMedicoSIMABE.FechaVencimiento= DateTime.Parse(this.txtFechaVence.Text);
				oExamenMedicoSIMABE.IdTipoEMO= 1;
				oExamenMedicoSIMABE.IdAptitud= Convert.ToInt32(this.ddlAptitud.SelectedValue);
				oExamenMedicoSIMABE.IdToxicologico= 1;

				string retorno = (new CCCTT_FichaMedicaTSima()).Insertar(oExamenMedicoSIMABE);
				if(retorno!="-1")
				{
					IDREG = retorno;
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad industrial",this.ToString(),"Se registró examen medico. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));

					this.txtPR.Text="";
					this.txtApellidosyNombres.Text="";
					this.txtFechaIni.Text="";
					this.txtFechaVence.Text="";
					this.ddlAptitud.SelectedIndex=0;
					if(oExamenMedicoSIMABE.IdAptitud==2)
					{
						string []arrID=retorno.Split('-');
						Helper.JavaScript.RegistrarScript("Restric","ListarRestricciones('" + arrID[0] + "','" + arrID[1] + "');");
					}
			

				}
			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				System.Web.UI.WebControls.Image oImgDEL = (System.Web.UI.WebControls.Image )e.Item.Cells[5].FindControl("imgEliminar");
				oImgDEL.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"EliminarFicha('" + dr["IdPersonal"].ToString()+ "','" + dr["Periodo"].ToString() + "','" + dr["IdFicha"].ToString() + "')");

				if(dr["IdAptitud"].ToString().Equals("2"))
				{
					e.Item.Cells[3].ForeColor=Color.Blue;
					e.Item.Cells[3].Font.Underline=true;
					e.Item.Cells[3].Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"ListarRestricciones('" + dr["Periodo"].ToString() + "','" + dr["IdFicha"].ToString() + "')");
				}
				string strFunction="DetalleFicha('" + dr["IdPersonal"].ToString()+ "','" + dr["NroPersonal"].ToString()+ "','" + dr["ApellidosyNombres"].ToString()+ "','" + dr["NroDiasDescanso"].ToString()+ "','" + dr["NombreAptitud"].ToString() + "','" + dr["FechaInicio"].ToString()+ "','" + dr["FechaVencimiento"].ToString() +"')";

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,Helper.HistorialIrAdelantePersonalizado(this.hGridPagina.ID.ToString(),this.hGridPaginaSort.ID.ToString()),strFunction);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hPeriodo",dr["Periodo"].ToString()),Helper.MostrarDatosEnCajaTexto("hIdFicha",dr["IdFicha"].ToString()));

				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				if(IDREG == dr["Periodo"].ToString() + "-" + dr["IdFicha"].ToString())
				{
					hIdFila.Value=(e.Item.ItemIndex+1).ToString();
				}

			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Helper.ObtenerIndicePagina());
		}

		private void btnModifica_Click(object sender, System.EventArgs e)
		{
			string []strParam=ParamArgument.Split(';');

			ExamenMedicoSIMABE oExamenMedicoSIMABE = new ExamenMedicoSIMABE();
			oExamenMedicoSIMABE.IdPersonal = Convert.ToInt32(strParam[0]);
			oExamenMedicoSIMABE.Periodo= Convert.ToInt32(strParam[1]);
			oExamenMedicoSIMABE.IdFicha= Convert.ToInt32(strParam[2]);
			oExamenMedicoSIMABE.IdCM= 1;
			oExamenMedicoSIMABE.FechaInicio= DateTime.Parse(strParam[3]);
			oExamenMedicoSIMABE.NroDias= Convert.ToInt32(strParam[4]);
			oExamenMedicoSIMABE.IdTipoEMO= 1;
			oExamenMedicoSIMABE.IdAptitud= Convert.ToInt32(strParam[5]);
			oExamenMedicoSIMABE.IdToxicologico= 1;

			int retorno = (new CCCTT_FichaMedicaTSima()).Modificar(oExamenMedicoSIMABE);
			if(retorno>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad industrial",this.ToString(),"Se registró examen medico. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
				this.ptxtNroPR.Text="";
				this.ptxtApellidosyNombres.Text="";
				//this.pCalFechaInicio.SelectedDate=DateTime.Now;
				this.ptxtFechaVence.Text="";
			}
		}

		private void ibtnEliminar_Click(object sender, System.EventArgs e)
		{
			try
			{
				string []arrParam = ParamArgument.Split(';');
				
				if((new CCCTT_FichaMedicaTSima()).Eliminar(Convert.ToInt32(arrParam[1]),Convert.ToInt32(arrParam[2]))>0)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad industrial",this.ToString(),"Se eliminó registro de examen medico." ,Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}		
		}
	}
}
