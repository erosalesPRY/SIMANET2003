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
using System.Drawing.Printing;


namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios
{
	/// <summary>
	/// Summary description for CargarNodosPresupuesto.
	/// </summary>
	public class CargarNodosPresupuesto : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string KEYQIDCO = "QIDCO";
		const string KEYQIDPERIODO ="QIDPERIODO";
		const string KEYQIDMES ="QIDMES";
		const string KEYQIDGRPCTA ="QIDDIGGRPCTA";
		const string KEYQIDDIGCTA ="QIDDIGCTA";
		const string KEYQIDGRPCC ="QIDGRPCC";
		const string KEYQIDCC ="QIDCC";
		const string KEYQIDNIVEL ="QIDNIVEL";
		const string KEYQIDGPRS ="QIDGPRS";

		const string KEYQIDTIPOPRESUPUESTO="idTPPPto";
		
		//URL
		const string URLPAGINASEGURIDAD="../FINSeguridad.aspx?";

		//DataGrid and DataTable
		const string COLUMNAIDGRUPOCC ="idGrupoCC";
		const string COLUMNAIDCENTROCOSTO ="idCentroCosto";
		const string COLUMNANOMBRE ="Nombre";
		const string COLUMNANROCTA ="NroCta";
		const string COLUMNATOTALPPTOCTA ="TotalPPtoCta";
		const string COLUMNATOTALEJECUTADO ="TotalEjecutado";
		const string COLUMNASALDO ="Saldo";

		//Otros
		const string TIPODOUBLE ="System.Double";
		const string EXPRESION ="TotalPPtoCta - TotalEjecutado";
		#endregion

		#region Controles
		protected System.Web.UI.HtmlControls.HtmlInputHidden hRegistro;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarDatos();
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
					/*
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
					ltlMensaje.Text ="window.alert('" + oException.Message.ToString() + "');";
					*/
					//ltlMensaje.Text ="PaginadeError();";

					
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add CargarNodosPresupuesto.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add CargarNodosPresupuesto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add CargarNodosPresupuesto.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add CargarNodosPresupuesto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			switch(Convert.ToInt32(Page.Request.Params[KEYQIDNIVEL]))
			{
				case 0:
					this.hRegistro.Value = this.ObtenerCentrodeCosto();
					break;
				case 1:
					this.hRegistro.Value = this.ObtenerNaturalezadeGasto3Dig();
					break;
				case 2:
					this.hRegistro.Value = this.ObtenerNaturalezadeGasto5Dig();
					break;
				default:
					break;
			}
			// TODO:  Add CargarNodosPresupuesto.LlenarDatos implementation
		}
		private DataTable ObtenerDatosdeCentroDeCosto()
		{
			DataTable tblResultado;
			if (Page.Request.Params[KEYQIDTIPOPRESUPUESTO].ToString()=="99")
			{
				tblResultado =((CPresupuesto) new CPresupuesto()).ConsultarPresupuestodePersonalPorCentrodeCostos(
					Convert.ToInt32(Page.Request.Params[KEYQIDCO])
					,Convert.ToInt32(Page.Request.Params[KEYQIDPERIODO])
					,Convert.ToInt32(Page.Request.Params[KEYQIDMES])
					,Convert.ToInt32(Page.Request.Params[KEYQIDGRPCC])
					,Page.Request.Params[KEYQIDDIGCTA].ToString()
					,CNetAccessControl.GetIdUser());
			}
			else
			{
				tblResultado =((CPresupuesto) new CPresupuesto()).ConsultarPresupuestoPorCentrodeCostos(
					Convert.ToInt32(Page.Request.Params[KEYQIDCO])
					,Convert.ToInt32(Page.Request.Params[KEYQIDPERIODO])
					,Convert.ToInt32(Page.Request.Params[KEYQIDMES])
					,Convert.ToInt32(Page.Request.Params[KEYQIDGRPCC])
					,Page.Request.Params[KEYQIDDIGCTA].ToString()
					,CNetAccessControl.GetIdUser());
			}

			if (tblResultado !=null)
			{
				DataColumn dc = new  DataColumn(COLUMNASALDO, Type.GetType(TIPODOUBLE));
				dc.Expression = EXPRESION;
				tblResultado.Columns.Add(dc);
			}
			return tblResultado;
		}
		private string ObtenerCentrodeCosto()
		{

			DataTable tblResultado = this.ObtenerDatosdeCentroDeCosto();

			System.Text.StringBuilder sbReg = new System.Text.StringBuilder();
			foreach(DataRow dr in tblResultado.Rows)
			{
				if ((Convert.ToDouble(dr[COLUMNATOTALPPTOCTA]) != 0) || (Convert.ToDouble(dr[COLUMNATOTALEJECUTADO]) != 0))
				{
					sbReg.Append(dr[COLUMNAIDGRUPOCC].ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA); //0
					sbReg.Append(dr[COLUMNAIDCENTROCOSTO].ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//1
					sbReg.Append(dr[COLUMNANOMBRE].ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//2
					sbReg.Append(dr[COLUMNANROCTA].ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//3 Digito de la Cuenta de Grupo
					sbReg.Append(Convert.ToDouble(dr[COLUMNATOTALPPTOCTA]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//4
					sbReg.Append(Convert.ToDouble(dr[COLUMNATOTALEJECUTADO]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//5
					sbReg.Append(Convert.ToDouble(dr[COLUMNASALDO]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//6
					sbReg.Append(Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOARROBA + Utilitario.Constantes.SIGNOCIERRACORCHETES);
				}
			}
			if (sbReg.ToString().Length > Utilitario.Constantes.ValorConstanteCero)
			{
				return sbReg.ToString().Substring(0,sbReg.Length- 4);
			}
			return Utilitario.Constantes.VACIO;
		}

		private DataTable ObtenerDatosdeNaturalezadeGasto3Dig()
		{
			CPresupuesto oCPresupuesto = new CPresupuesto();
			DataTable tblResultado;
			if (Page.Request.Params[KEYQIDTIPOPRESUPUESTO].ToString()=="99")
			{
				tblResultado =oCPresupuesto.ConsultarPresupuestodePersonalPorCentrosyNaturalezadeGasto3Dig(
																								Convert.ToInt32(Page.Request.Params[KEYQIDCO])
																								,Convert.ToInt32(Page.Request.Params[KEYQIDPERIODO])
																								,Convert.ToInt32(Page.Request.Params[KEYQIDMES])
																								,Convert.ToInt32(Page.Request.Params[KEYQIDGRPCC])
																								,Convert.ToInt32(Page.Request.Params[KEYQIDCC])
																								,Page.Request.Params[KEYQIDGRPCTA].ToString());

			}
			else
			{
				tblResultado =oCPresupuesto.ConsultarPresupuestoPorCentrosyNaturalezadeGasto3Dig(
																								Convert.ToInt32(Page.Request.Params[KEYQIDCO])
																								,Convert.ToInt32(Page.Request.Params[KEYQIDPERIODO])
																								,Convert.ToInt32(Page.Request.Params[KEYQIDMES])
																								,Convert.ToInt32(Page.Request.Params[KEYQIDGRPCC])
																								,Convert.ToInt32(Page.Request.Params[KEYQIDCC])
																								,Page.Request.Params[KEYQIDGRPCTA].ToString());
			}

			if (tblResultado !=null)
			{
				DataColumn dc = new  DataColumn(COLUMNASALDO, Type.GetType(TIPODOUBLE));
				dc.Expression = EXPRESION;
				tblResultado.Columns.Add(dc);
			}
			return tblResultado;
		}
		private string ObtenerNaturalezadeGasto3Dig()
		{
			DataTable tblResultado =this.ObtenerDatosdeNaturalezadeGasto3Dig();
			System.Text.StringBuilder sbReg = new System.Text.StringBuilder();
			foreach(DataRow dr in tblResultado.Rows)
			{
				if ((Convert.ToDouble(dr[COLUMNATOTALPPTOCTA]) != Utilitario.Constantes.ValorConstanteCero) || (Convert.ToDouble(dr[COLUMNATOTALEJECUTADO]) != Utilitario.Constantes.ValorConstanteCero))
				{
					sbReg.Append(dr[COLUMNAIDGRUPOCC].ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA); //0
					sbReg.Append(dr[COLUMNAIDCENTROCOSTO].ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//1
					sbReg.Append(dr[COLUMNANOMBRE].ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//2
					sbReg.Append(dr[COLUMNANROCTA].ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//3 Digito de la Cuenta de Grupo
					sbReg.Append(Convert.ToDouble(dr[COLUMNATOTALPPTOCTA]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//4
					sbReg.Append(Convert.ToDouble(dr[COLUMNATOTALEJECUTADO]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//5
					sbReg.Append(Convert.ToDouble(dr[COLUMNASALDO]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//6
					sbReg.Append(Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOARROBA + Utilitario.Constantes.SIGNOCIERRACORCHETES);
				}
			}
			if (sbReg.ToString().Length > Utilitario.Constantes.ValorConstanteCero)
			{
				return sbReg.ToString().Substring(0,sbReg.Length- 4);
			}
			return Utilitario.Constantes.VACIO;
		}
		private DataTable ObtenerDatosdeNaturalezadeGasto5Dig()
		{
			CPresupuesto oCPresupuesto = new CPresupuesto();
			DataTable tblResultado;
			if (Page.Request.Params[KEYQIDTIPOPRESUPUESTO].ToString()=="99")
			{
				tblResultado =oCPresupuesto.ConsultarPresupuestodePersonalPorCentrosyNaturalezadeGasto5Dig(
																								Convert.ToInt32(Page.Request.Params[KEYQIDCO])
																								,Convert.ToInt32(Page.Request.Params[KEYQIDPERIODO])
																								,Convert.ToInt32(Page.Request.Params[KEYQIDMES])
																								,Convert.ToInt32(Page.Request.Params[KEYQIDGRPCC])
																								,Convert.ToInt32(Page.Request.Params[KEYQIDCC])
																								,Page.Request.Params[KEYQIDDIGCTA].ToString()
																								,Page.Request.Params[KEYQIDGRPCTA].ToString()
																								);
			}
			else
			{
				tblResultado =oCPresupuesto.ConsultarPresupuestoPorCentrosyNaturalezadeGasto5Dig(
																								Convert.ToInt32(Page.Request.Params[KEYQIDCO])
																								,Convert.ToInt32(Page.Request.Params[KEYQIDPERIODO])
																								,Convert.ToInt32(Page.Request.Params[KEYQIDMES])
																								,Convert.ToInt32(Page.Request.Params[KEYQIDGRPCC])
																								,Convert.ToInt32(Page.Request.Params[KEYQIDCC])
																								,Page.Request.Params[KEYQIDDIGCTA].ToString()
																								,Page.Request.Params[KEYQIDGRPCTA].ToString()
																								);
			}
			if (tblResultado !=null)
			{
				DataColumn dc = new  DataColumn(COLUMNASALDO, Type.GetType(TIPODOUBLE));
				dc.Expression = EXPRESION;
				tblResultado.Columns.Add(dc);
			}
			return tblResultado;
		}
		private string ObtenerNaturalezadeGasto5Dig()
		{
			DataTable tblResultado =this.ObtenerDatosdeNaturalezadeGasto5Dig();
			System.Text.StringBuilder sbReg = new System.Text.StringBuilder();
			foreach(DataRow dr in tblResultado.Rows)
			{
				if ((Convert.ToDouble(dr[COLUMNATOTALPPTOCTA]) != Utilitario.Constantes.ValorConstanteCero) || (Convert.ToDouble(dr[COLUMNATOTALEJECUTADO]) != Utilitario.Constantes.ValorConstanteCero))
				{
					sbReg.Append(dr[COLUMNAIDGRUPOCC].ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA); //0
					sbReg.Append(dr[COLUMNAIDCENTROCOSTO].ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//1
					sbReg.Append(dr[COLUMNANOMBRE].ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//2
					sbReg.Append(dr[COLUMNANROCTA].ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//3 Digito de la Cuenta de Grupo
					sbReg.Append(Convert.ToDouble(dr[COLUMNATOTALPPTOCTA]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//4
					sbReg.Append(Convert.ToDouble(dr[COLUMNATOTALEJECUTADO]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//5
					sbReg.Append(Convert.ToDouble(dr[COLUMNASALDO]).ToString(Utilitario.Constantes.FORMATODECIMAL4)+ Utilitario.Constantes.SIGNOPUNTOYCOMA);//6
					sbReg.Append(Utilitario.Constantes.SIGNOABRECORCHETES + Utilitario.Constantes.SIGNOARROBA + Utilitario.Constantes.SIGNOCIERRACORCHETES);
				}
			}
			if (sbReg.ToString().Length > Utilitario.Constantes.ValorConstanteCero)
			{
				return sbReg.ToString().Substring(0,sbReg.Length- 4);
			}
			return Utilitario.Constantes.VACIO;
		}


		public void LlenarJScript()
		{
			// TODO:  Add CargarNodosPresupuesto.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add CargarNodosPresupuesto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add CargarNodosPresupuesto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add CargarNodosPresupuesto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{
				CNetAccessControl.LoadControls(this);
			}
			else
			{
				CNetAccessControl.RedirectPageError();
			}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add CargarNodosPresupuesto.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
