using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using SIMA.Utilitario;
using SIMA.Controladoras.General;


namespace SIMA.SimaNetWeb.GestionFinanciera
{
	/// <summary>
	/// Summary description for BaseGestionFinanciera.
	/// </summary>
	public class BaseGestionFinanciera:System.Web.UI.Page
	{
		public BaseGestionFinanciera()
		{}
		#region Atributos
		public int Periodo
		{
			get { return Convert.ToInt32(Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQPERIODO)); }
		}
		public int IdMes
		{
			get { return Convert.ToInt32(Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQIDMES)); }
		}
		public string CuentaContable
		{
			get { return Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQCUENTACONTABLE); }
		}
		public int IdCentroOperativo
		{
			get { return Convert.ToInt32(Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQIDCEOPE)); }
		}
		public int NroCentroOperativo
		{
			get { return Convert.ToInt32(Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQNROCEOPE)); }
		}

		public int IdGrupoCentroCosto
		{
			get { return Convert.ToInt32(Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQIDGRPCC)); }
		}
		public string NroGrupoCentroCosto
		{
			get { return Convert.ToString(Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQNROGRPCC)); }
		}

		public int IdCentroCosto
		{
			get { return Convert.ToInt32(Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQIDCC)); }
		}
		public string NroCentroCosto
		{
			get { return Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQNROCC); }
		}
		public double MontoPresupuesto
		{
			get { return Convert.ToDouble(Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQMONTOPPTO)); }
		}
		//
		public string NroRequerimiento
		{
			get { return Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQNRORQR); }
		}
		public string CodigoRecurso
		{
			get { return Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQCODRECURSO); }
		}
		public int CantidadDMAAJU
		{
			get { return Convert.ToInt32(Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQCNTDMA)); }
		}
		public int CantidadDMLAJU
		{
			get { return Convert.ToInt32(Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQCNTDML)); }
		}
		public int CantidadRequerimientoAJU
		{
			get { return Convert.ToInt32(Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQCNTRQRAJU)); }
		}
		public Double PrecioUntAJU
		{
			get { return Convert.ToDouble(Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQCNTUNTAJU).ToString()); }
		}
		public string UnidaddeMedidaAJU
		{
			get { return Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQUNIMEDAJU); }
		}
		
		public int TipoRCS
		{
			get { return Convert.ToInt32(Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQTIPORCS)); }
		}
		public int IdEstado
		{
			get { return Convert.ToInt32(Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQIDESTADO)); }
		}

		public String IdEstadoUnisys
		{
			get { return Helper.ObtenerValorParametroPagina(Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQIDESTADOUNIX); }
		}

		
		#endregion
	}
}
