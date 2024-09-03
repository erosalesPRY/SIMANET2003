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
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for DetalleExamenMedico.
	/// </summary>
	public class DetalleSctr : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected eWorld.UI.CalendarPopup CalFechVence;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTrabajador;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCentroMedico;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.TextBox txtNombreCM;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DropDownList ddlActitud;
		protected System.Web.UI.WebControls.DropDownList ddlToxicologico;
		protected System.Web.UI.HtmlControls.HtmlImage btnAgregarTrabajador;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label LblDisponible;
		protected System.Web.UI.WebControls.Label LblHabilitado;
		protected System.Web.UI.WebControls.TextBox txtTrabajador;
		protected System.Web.UI.WebControls.TextBox txtCentroMedico;
		protected System.Web.UI.WebControls.DropDownList ddlTipoEMO;
	}	
}