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


namespace SIMA.SimaNetWeb.GestionFinanciera.Procesos
{
	/// <summary>
	/// Summary description for Procesos.
	/// </summary>
	public class Procesar : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string INDICADORDEPROCESO="IdProceso";
		#region Datos que seran asignados a una entidad
		const string KEYQPERIODO="Periodo";
		const string KEYQMES="idMes";
		const string KEYQIDEMPRESA = "idEmp";
		const string KEYQIDCENTRO = "IdCentro";
		const string KEYQIDFORMATO ="idFormato";
		const string KEYQIDRUBRODETALLE = "IdrubroDetalle";
		const string KEYQIDRUBRODETALLEMOVIMIENTO = "IdrubroDetalleMov";
		const string KEYQIDTIPOINFORMACION = "idTipoInfo";
		const string KEYQMONTO = "Monto";
		const string KEYQIDFECHA= "Fecha";
		
		#endregion
		#endregion

		#region Atributos
		protected int pPeriodo
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);
			}
		}
		protected int pMes
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQMES]);
			}
		}

		protected int idCentroOperativo
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO]);
			}
		}

		protected int idEmpresa
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA]);
			}
		}
		protected int idFormato
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
			}
		}
		protected int idProceso
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[INDICADORDEPROCESO]);
			}
		}

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA]) ;
				switch (oModoPagina)
				{
					case Enumerados.ModoPagina.P:
						this.Procesos();
						break;
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
			// TODO:  Add Procesar.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add Procesar.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add Procesar.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add Procesar.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add Procesar.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add Procesar.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add Procesar.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add Procesar.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add Procesar.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add Procesar.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add Procesar.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members
		public void Procesos()
		{
				this.EntregaResultado();
		}
		public void EntregaResultado()
		{
			switch(this.idProceso)
			{
				case 14:
					this.CrearXMLResultado(((CFormatoReporteFormula) new CFormatoReporteFormula()).ProcesarFormulaFormato(CNetAccessControl.GetIdUser(),this.idFormato,1,this.idCentroOperativo,this.pPeriodo,this.pMes,0));
					break;
				default:
					break;
			}
		}

		private void CrearXMLResultado(int Resultado)
		{
			Response.Clear();
			Response.ContentType = "text/xml";
			string output="<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n";
			output += "<GestionFinanciera>\n";
			output += "  <Proceso>\n";
			output += "    <Resultado>"				+ ((Resultado ==1)?"CORRECTO":"ERROR")  +	"</Resultado>\n";
			output += "  </Proceso>\n";
			output += "</GestionFinanciera>";
			Response.Write(output);
			Response.End();
		}
		public void Agregar()
		{
			// TODO:  Add Procesar.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add Procesar.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add Procesar.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add Procesar.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add Procesar.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add Procesar.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add Procesar.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add Procesar.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add Procesar.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add Procesar.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	}
}
