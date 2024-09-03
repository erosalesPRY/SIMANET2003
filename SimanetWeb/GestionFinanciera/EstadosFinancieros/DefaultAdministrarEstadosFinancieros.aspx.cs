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

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	/// <summary>
	/// Summary description for DefaultAdministrarEstadosFinancieros.
	/// </summary>
	public class DefaultAdministrarEstadosFinancieros : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.WebControls.Panel Panel;
			protected System.Web.UI.WebControls.Button btnConsultar;
			protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		#region Constantes
			const string GRILLAVACIA="No exiets";
			const string OBJPARAMETROCONTABLE="ParametroContable";			
			const string KEYIDEMPRESA ="idEmp";
		protected System.Web.UI.HtmlControls.HtmlInputHidden hTabSeleccionado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigoFormato;
		protected System.Web.UI.HtmlControls.HtmlTableCell LstBtnGrupos;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdGrupo;
			const string URLCONTROLUSUARIOPARAMETROCONTABLE = "../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx";
		#endregion

		ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable;

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.CargarControl();
			

			/*
				if(Session["CtrlGroup"]==null)
				{
					DataTable dt= (new CFormato()).ListarGruposFormAccesoSegunPrivilegioUsuarioUsuarioCtrlCierre(usc_ParametroContable.IdCentroOperativo,usc_ParametroContable.Periodo,usc_ParametroContable.Mes, usc_ParametroContable.IdTipoInformacion,0);
			
					if(dt!=null)
					{
						string[]LstField={"IdGrupo","NombreGrupo"};
						int i=0;
						DataTable dtGrp = Helper.Data.GroupBy(dt,LstField,null);
						foreach(DataRow dr in dtGrp.Rows)
						{
							HtmlTable mTbl =  Helper.CrearHtmlTabla(1,1,true);
							//mTbl.ID = "grp_"+ dr["IdGrupo"].ToString();
							mTbl.Align="left";
							mTbl.Style.Add("MARGIN-BOTTOM","5px");
							mTbl.Style.Add("MARGIN-LEFT","5px");
							mTbl.Attributes.Add("class","BaseItemInGrid");
							mTbl.Rows[0].Cells[0].InnerText = dr["NombreGrupo"].ToString();
							LstBtnGrupos.Controls.Add(mTbl);
							mTbl.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"SeleccionarGrupo(this)");
							if(i==0){this.hIdGrupo.Value = dr["IdGrupo"].ToString();}
							i++;
						}

					}
				}
			*/
		}

		private void CargarControl()
		{			
			
			if (Session[OBJPARAMETROCONTABLE + Page.Request.Params[KEYIDEMPRESA].ToString()]==null)
			{
				usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)LoadControl(URLCONTROLUSUARIOPARAMETROCONTABLE);
				usc_ParametroContable.IdEmpresa = Convert.ToInt32(Page.Request.Params[KEYIDEMPRESA]);
				//usc_ParametroContable.VerCentroOperativo = true;
				usc_ParametroContable.VerCentroOperativoTODOS = false;
				usc_ParametroContable.VerPeriodo = true;
				usc_ParametroContable.VerMes = true;
				usc_ParametroContable.VerTipoInformacion = true;
				usc_ParametroContable.VerEntidadFinanciera=false;
				Panel.Controls.Clear();
				Panel.Controls.Add(usc_ParametroContable);
				Session[OBJPARAMETROCONTABLE + Page.Request.Params[KEYIDEMPRESA].ToString()] = usc_ParametroContable;
			}
			else	//Aca entra en caso de Estado de Ganacias y Perdidas
			{
				usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE  + Page.Request.Params[KEYIDEMPRESA].ToString()];
				usc_ParametroContable.EnabledCentroOperativo=true;
				usc_ParametroContable.EnabledPeriodo=true;
				usc_ParametroContable.EnabledMes =true;				
				usc_ParametroContable.EnabledTipoInformacion=true;

				/*Ingreso de PostBack para controles*/
				//				usc_ParametroContable.AutoPostBackMes = true;
				//				usc_ParametroContable.AutoPostBackTipoInformacion=true;
				/************************************/
				Panel.Controls.Clear();
				Panel.Controls.Add(usc_ParametroContable);
				Session[OBJPARAMETROCONTABLE + Page.Request.Params[KEYIDEMPRESA].ToString()] = usc_ParametroContable;
			}
			//Cargar Grupos de formatos
			

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
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DefaultAdministrarEstadosFinancieros.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
