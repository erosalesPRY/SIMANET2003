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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial
{
	/// <summary>
	/// Summary description for BusquedaPersonas.
	/// </summary>
	public class BusquedaPersonas: System.Web.UI.Page	
	{
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Button btnBuscar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblTipoPersona;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoPersona;
		protected System.Web.UI.WebControls.Label lblApellidoPaterno;
		protected System.Web.UI.WebControls.TextBox txtApellidoPaterno;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.DropDownList ddlbGrado;
		protected System.Web.UI.WebControls.Label lblGrado;
		protected System.Web.UI.WebControls.Label lblEspecialidad;
		protected System.Web.UI.WebControls.DropDownList ddlbEspecialidad;
		protected System.Web.UI.WebControls.Label lblOficial;
		protected System.Web.UI.WebControls.Label lblPersonal;
		protected System.Web.UI.WebControls.DropDownList ddlblArea;
		protected System.Web.UI.WebControls.DropDownList ddlbCargo;
		protected System.Web.UI.WebControls.Label lblArea;
		protected System.Web.UI.WebControls.Label lblCargo;
		protected System.Web.UI.WebControls.DropDownList ddlbDependencia;
		protected System.Web.UI.WebControls.DropDownList ddlbTituloCliente;
		protected System.Web.UI.WebControls.Label lblCliente;
		protected System.Web.UI.WebControls.Label lblDependencia;
		protected System.Web.UI.WebControls.Label lblTituloCliente;
		protected System.Web.UI.WebControls.Label lblTitulo;
		
					
				
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			


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

		
	}
}

