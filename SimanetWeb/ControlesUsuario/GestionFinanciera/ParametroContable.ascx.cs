namespace SIMA.SimaNetWeb.ControlesUsuario.GestionFinanciera
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using SIMA.Controladoras.General;
	using SIMA.Controladoras.GestionFinanciera;
	using SIMA.Utilitario;
	using SIMA.SimaNetWeb.InterfacesIU;
	using NetAccessControl;

	/// <summary>
	///		Summary description for ParametroContable.
	/// </summary>
	public class ParametroContable : System.Web.UI.UserControl
	{
		#region Controles

		protected System.Web.UI.HtmlControls.HtmlTableRow trCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTableRow trPeriodo;
		protected System.Web.UI.WebControls.Label lblTipoInformación;
		protected System.Web.UI.WebControls.DropDownList ddlbMes;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label lblCentroOPerativo;
		protected System.Web.UI.HtmlControls.HtmlTableRow trTipoInformacion;
		protected System.Web.UI.HtmlControls.HtmlTableRow trEntidadFinanciera;
		protected System.Web.UI.WebControls.Label lblEntidadFinanciera;
		#endregion Controles

		protected System.Web.UI.WebControls.DropDownList ddlbTipoInformacion;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlbEntidadFinanciera;
		protected System.Web.UI.HtmlControls.HtmlTableCell trMes;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;

		private 	ListItem item =  new ListItem();
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}
		#region Enumerados
		enum VistadeCentroOperativo
		{
			TodoslosCentro =0
			,SoloCallaoyChimbote=1
			,SoloCallaoyIquitos=2
			,SoloCallaoyPeru= 3
			,SoloChimboteyIquitos=4
			,SoloIquitosyPeru=5
			,SoloChimboteyPeru=6
			,SoloPorPrivilegiosOtorgadosPorEmpresa=7
			,SoloPorPrivilegiosOtorgadosEnGeneral=8
		}
		#endregion

		#region Atributos
		private int idEmpresa;
		private int nroCentroOperativo;
		#endregion
		#region Propiedades de valores Id
		public int IdEmpresa
		{
			get	{return idEmpresa;}
			set	{this.idEmpresa = value;}
		}

		public int NroCentroOperativo
		{
			get{return nroCentroOperativo;}
			set{this.nroCentroOperativo = value;}
		}
		public int CantidadPeriodo
		{
			get{return Convert.ToInt32(ddlbPeriodo.Items.Count);}
		}
		public int IdCentroOperativo
		{
			get	{return Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue);}
			set	{this.SeleccionarItem(this.ddlbCentroOperativo,value.ToString());}
		}
		public string CentroOperativoNombre 
		{get{return this.ddlbCentroOperativo.SelectedItem.Text.ToString();}}

		public int Periodo
		{
			get {return Convert.ToInt32(this.ddlbPeriodo.SelectedValue);}
			set {this.SeleccionarItem(this.ddlbPeriodo,value.ToString());}
		}

		public int Mes
		{
			get {return Convert.ToInt32(this.ddlbMes.SelectedValue);}
			set	{this.SeleccionarItem(this.ddlbMes,value.ToString());}
		}
		public string NombreMes
		{get {return this.ddlbMes.SelectedItem.Text;}}

		public int IdTipoInformacion
		{
			get	{return Convert.ToInt32(this.ddlbTipoInformacion.SelectedValue);}
			set	{this.SeleccionarItem(this.ddlbTipoInformacion,value.ToString());}
		}
		public string TipoInformacionNombre
		{get	{return this.ddlbTipoInformacion.SelectedItem.Text.ToString();}}

		public int IdEntidadFinanciera
		{
			get{return Convert.ToInt32(this.ddlbEntidadFinanciera.SelectedValue);}
			set{this.SeleccionarItem(this.ddlbEntidadFinanciera,value.ToString());}
		}
		public string EntidadFinancieraNombre
		{get	{return this.ddlbEntidadFinanciera.SelectedItem.Text.ToString();}}

		private void SeleccionarItem(System.Web.UI.WebControls.DropDownList ddList, string Valor)
		{
			item = ddList.Items.FindByValue(Valor);
			if(item!=null)
			{item.Selected = true;}
		}
		#endregion
		#region Propiedades de Visibilidad
		public bool VerCentroOperativoCallaoChimbote
		{
			set
			{
				this.trCentroOperativo.Visible=value;
				if (value == true) this.llenarCentroOperativo(VistadeCentroOperativo.SoloCallaoyChimbote);
			}
		}
		public bool VerCentroOperativoChimboteIquitos
		{
			set
			{
				this.trCentroOperativo.Visible=value;
				if (value == true) this.llenarCentroOperativo(VistadeCentroOperativo.SoloChimboteyIquitos);
			}
		}

		public bool VerCentroOperativo
		{
			set
			{
				this.trCentroOperativo.Visible=value;
				if (value == true) this.llenarCentroOperativo((this.idEmpresa!=0)? VistadeCentroOperativo.SoloPorPrivilegiosOtorgadosPorEmpresa:VistadeCentroOperativo.TodoslosCentro);
			}
		}
		public bool VerCentroOperativoPorPrivilegiosEnGeneral
		{
			set
			{
				this.trCentroOperativo.Visible=value;
				if (value == true) this.llenarCentroOperativo(VistadeCentroOperativo.SoloPorPrivilegiosOtorgadosEnGeneral);
			}
		}

		/*Metodo creado por José Rodriguez*/
		public bool VerCentroOperativoTODOS
		{
			set
			{
				//this.trCentroOperativo.Visible=value;
				this.trCentroOperativo.Visible=true;
				if(value == true) this.llenarCentroOperativo(true);
				if(value == false) this.llenarCentroOperativo(false);
			}
		}
		public bool VerPeriodo
		{
			set
			{
				this.trPeriodo.Visible=value;
				if (value == true) this.llenarPeriodo();
			}
		}
		 
		public bool VerMes
		{
			set
			{
				this.trMes.Visible= value;
				if (value == true) this.llenarMes();
			}
		}

		public bool VerTipoInformacion
		{
			set
			{
				this.trTipoInformacion.Visible = value;
				if (value == true) this.llenarTipoInformacion();
			}
		}
		public bool VerEntidadFinanciera
		{
			set
			{
				this.trEntidadFinanciera.Visible = value;
				if (value == true) this.llenarEntidadFinanciera();
			}
		}

		
		#endregion
		#region Propiedades de AutoPostBack Controles
		public bool AutoPostBackCentroOperativo
		{
			get
			{return ddlbCentroOperativo.AutoPostBack;}
			set
			{ddlbCentroOperativo.AutoPostBack=value;}
			
		}

		public bool AutoPostBackPeriodo
		{
			get
			{return ddlbPeriodo.AutoPostBack;}
			set
			{ddlbPeriodo.AutoPostBack=value;}
		}

		public bool AutoPostBackMes
		{
			get
			{return ddlbMes.AutoPostBack;}
			set
			{ddlbMes.AutoPostBack=value;}
		}

		public bool AutoPostBackTipoInformacion
		{
			get
			{return ddlbTipoInformacion.AutoPostBack;}
			set
			{ddlbTipoInformacion.AutoPostBack=value;}
		}
		public bool AutoPostBackEntidadFinanciera
		{
			get
			{return ddlbEntidadFinanciera.AutoPostBack;}
			set
			{ddlbEntidadFinanciera.AutoPostBack=value;}
		}
		#endregion Propiedades de AutoPostBack Controles

		#region Propiedades de Activacion y Desactivacion de los controles
		public bool EnabledCentroOperativo
		{
			set
			{ddlbCentroOperativo.Enabled = value;}
		}
		public bool EnabledPeriodo
		{
			set
			{ddlbPeriodo.Enabled = value;}
		}
		public bool EnabledMes
		{
			set
			{ddlbMes.Enabled = value;}
		}
		public bool EnabledTipoInformacion
		{
			set
			{ddlbTipoInformacion.Enabled = value;}
		}
		public bool EnabledEntidadFinanciera
		{
			set
			{ddlbEntidadFinanciera.Enabled = value;}
		}

		#endregion
		#region Metodos privados de Llenado de Combos
		private void llenarCentroOperativo(VistadeCentroOperativo TipoVista)
		{
			CCentroOperativo oCCentroOperativo =   new  CCentroOperativo();
			
			if (TipoVista == VistadeCentroOperativo.SoloPorPrivilegiosOtorgadosPorEmpresa)
			{
				//Como Datos se nesecita la Empresa this.idEmpresa <>0
				ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo(this.idEmpresa,CNetAccessControl.GetIdUser(),Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadodeSaldodeFormato));
			}
			else if(TipoVista == VistadeCentroOperativo.SoloPorPrivilegiosOtorgadosEnGeneral)
			{
				ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarCentroOperativoAccesoSegunPrivilegioUsuario(CNetAccessControl.GetIdUser(),Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadodeCtasporCobraryPagar3Dig));
			}
			else
			{
				ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
			}
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Nombre.ToString();
			ddlbCentroOperativo.DataBind();

			ListItem item;
			switch(TipoVista)
			{
				case VistadeCentroOperativo.SoloCallaoyChimbote:
					item = ddlbCentroOperativo.Items.FindByValue("1");//Remueve Sima Peru Como Centro de Operaciones
					if (item !=null)
					{ddlbCentroOperativo.Items.Remove(item);}
					item = ddlbCentroOperativo.Items.FindByValue("4");//Remueve Sima Iquitos Como Centro de Operaciones
					if (item !=null)
					{ddlbCentroOperativo.Items.Remove(item);}
					break;
				case VistadeCentroOperativo.SoloCallaoyIquitos:
					item = ddlbCentroOperativo.Items.FindByValue("1");//Remueve Sima Peru Como Centro de Operaciones
					if (item !=null)
					{ddlbCentroOperativo.Items.Remove(item);}
					item = ddlbCentroOperativo.Items.FindByValue("3");//Remueve Sima Iquitos Como Centro de Operaciones
					if (item !=null)
					{ddlbCentroOperativo.Items.Remove(item);}
					break;
				case VistadeCentroOperativo.SoloCallaoyPeru:
					item = ddlbCentroOperativo.Items.FindByValue("3");//Remueve Sima Peru Como Centro de Operaciones
					if (item !=null)
					{ddlbCentroOperativo.Items.Remove(item);}
					item = ddlbCentroOperativo.Items.FindByValue("4");//Remueve Sima Iquitos Como Centro de Operaciones
					if (item !=null)
					{ddlbCentroOperativo.Items.Remove(item);}
					break;
				case VistadeCentroOperativo.SoloChimboteyIquitos:
					item = ddlbCentroOperativo.Items.FindByValue("1");//Remueve Sima Peru Como Centro de Operaciones
					if (item !=null)
					{ddlbCentroOperativo.Items.Remove(item);}
					item = ddlbCentroOperativo.Items.FindByValue("2");//Remueve Sima Iquitos Como Centro de Operaciones
					if (item !=null)
					{ddlbCentroOperativo.Items.Remove(item);}
					break;
				case VistadeCentroOperativo.SoloChimboteyPeru:
					item = ddlbCentroOperativo.Items.FindByValue("2");//Remueve Sima Peru Como Centro de Operaciones
					if (item !=null)
					{ddlbCentroOperativo.Items.Remove(item);}
					item = ddlbCentroOperativo.Items.FindByValue("4");//Remueve Sima Iquitos Como Centro de Operaciones
					if (item !=null)
					{ddlbCentroOperativo.Items.Remove(item);}
					break;
				case VistadeCentroOperativo.SoloIquitosyPeru:
					item = ddlbCentroOperativo.Items.FindByValue("2");//Remueve Sima Peru Como Centro de Operaciones
					if (item !=null)
					{ddlbCentroOperativo.Items.Remove(item);}
					item = ddlbCentroOperativo.Items.FindByValue("3");//Remueve Sima Iquitos Como Centro de Operaciones
					if (item !=null)
					{ddlbCentroOperativo.Items.Remove(item);}
					break;
			}
			/*if (this.idEmpresa==0)
			{
				ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
			}
			else
			{
				ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo(this.idEmpresa,CNetAccessControl.GetIdUser(),Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadodeSaldodeFormato));
			}*/
		}
		

		/*Metodo Creado por José Rodriguez*/
		private void llenarCentroOperativo(bool todos)
		{
			if(todos==true)
			{
				CCentroOperativo oCCentroOperativo =   new  CCentroOperativo();
				if (this.idEmpresa==0)
				{
					ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
				}
				else
				{
					//Trae Solo SIMA-PERU
					ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo(this.idEmpresa,this.nroCentroOperativo,CNetAccessControl.GetIdUser(),Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadodeSaldodeFormato));
				}
				ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
				ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Nombre.ToString();
				ddlbCentroOperativo.DataBind();		
			}
			else
			{
				CCentroOperativo oCCentroOperativo =   new  CCentroOperativo();

				this.llenarCentroOperativo((this.idEmpresa!=0)? VistadeCentroOperativo.SoloPorPrivilegiosOtorgadosPorEmpresa:VistadeCentroOperativo.TodoslosCentro);

				/*if (this.idEmpresa==0)
				{
					ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
				}
				else
				{
					ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo(this.idEmpresa,CNetAccessControl.GetIdUser(),Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadodeSaldodeFormato));
				}
				ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
				ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Nombre.ToString();
				ddlbCentroOperativo.DataBind();
				ListItem item = ddlbCentroOperativo.Items.FindByValue("1");//Remueve Sima Peru Como Centro de Operaciones
				if (item !=null)
				{ddlbCentroOperativo.Items.Remove(item);}*/
			}
			
		}

		private void llenarTipoInformacion()
		{
			ddlbTipoInformacion.DataSource = ((CTablaTablas) new CTablaTablas()).ListarTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TipoInformacion)
																								,CNetAccessControl.GetIdUser()
																								,Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadodeSaldodeFormato));
			ddlbTipoInformacion.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoInformacion.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipoInformacion.DataBind();
		}
		private void llenarMes()
		{
			CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			ddlbPeriodo.DataSource = oCPeriodoContable.ListarPeriodo();
			ddlbMes.DataSource = oCPeriodoContable.ListarMes();
			ddlbMes.DataValueField=Enumerados.Mes.idMes.ToString();
			ddlbMes.DataTextField=Enumerados.Mes.NombreMes.ToString();
			ddlbMes.DataBind();
			item = ddlbMes.Items.FindByValue(SIMA.Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Month.ToString());
			if(item!=null)
			{item.Selected = true;}
		}
		private void llenarPeriodo()
		{
			CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			ddlbPeriodo.DataSource = oCPeriodoContable.ListarPeriodo();
			ddlbPeriodo.DataValueField="Periodo";
			ddlbPeriodo.DataTextField="Periodo";
			ddlbPeriodo.DataBind();
			item = ddlbPeriodo.Items.FindByValue(SIMA.Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Year.ToString());
			if(item!=null)
			{item.Selected = true;}
		}

		private void llenarEntidadFinanciera()
		{
			CEntidadFinanciera oCEntidadFinanciera = new CEntidadFinanciera();
			ddlbEntidadFinanciera.DataSource = oCEntidadFinanciera.ListarTodosCombo ();
			ddlbEntidadFinanciera.DataValueField= Enumerados.ColumnasEntidadFinanciera.IdEntidadFinanciera.ToString();
			ddlbEntidadFinanciera.DataTextField=Enumerados.ColumnasEntidadFinanciera.RazonSocial.ToString();
			ddlbEntidadFinanciera.DataBind();
		}

		#endregion

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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public string ObtenerValores
		{
				get
				{return ddlbTipoInformacion.SelectedValue.ToString();}
								
		}
	}
}

