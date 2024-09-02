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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using DayPilot.Web.Ui;
using System.Globalization;
using System.Threading;


namespace SIMA.SimaNetWeb.General
{
	/// <summary>
	/// Summary description for AdministrarAgenda.
	/// </summary>
	public class AdministrarAgenda : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected DayPilot.Web.Ui.DayPilotCalendar DayPilotCalendar1;
		protected System.Web.UI.HtmlControls.HtmlTable tblHeaderAgenda;
		protected System.Web.UI.WebControls.Label Label1;
		protected eWorld.UI.CalendarPopup CalFecha;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.Label lblResultado;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
			if (!IsPostBack)
			{
				this.CalFecha.SelectedDate= Day;
				this.CalFecha.VisibleDate = Day;

				this.DayPilotCalendar1.StartDate = Day;
				this.DayPilotCalendar1.EndDate = Day.AddDays(5);
				this.EstablecerFechaCabecera();
				DataBind();
			}
		}

		private void EstablecerFechaCabecera()
		{
			this.tblHeaderAgenda.Rows[0].Cells[0].InnerText = TraducirFecha(Day);
			this.tblHeaderAgenda.Rows[0].Cells[1].InnerText = TraducirFecha(Day.AddDays(1));
			this.tblHeaderAgenda.Rows[0].Cells[2].InnerText = TraducirFecha(Day.AddDays(2));
			this.tblHeaderAgenda.Rows[0].Cells[3].InnerText = TraducirFecha(Day.AddDays(3));
			this.tblHeaderAgenda.Rows[0].Cells[4].InnerText = TraducirFecha(Day.AddDays(4));
			this.tblHeaderAgenda.Rows[0].Cells[5].InnerText = TraducirFecha(Day.AddDays(5));
		}
		private string TraducirFecha(DateTime fecha)
		{
			return fecha.ToLongDateString().Replace("Monday","Lunes")
											.Replace("Tuesday","Martes")
											.Replace("Wednesday","Miercoles")
											.Replace("Thursday","Jueves")
											.Replace("Friday","Viernes")
											.Replace("Saturday","Sabado")
											.Replace("Sunday","Domingo").Replace("January","Enero")
																		.Replace("February","Febrero")
																		.Replace("March","Marzo")
																		.Replace("April","Abril")
																		.Replace("May","Mayo")
																		.Replace("June","Junio")
																		.Replace("July","Julio")
																		.Replace("August","Agosto")
																		.Replace("September","Setiembre")
																		.Replace("October","Octubre")
																		.Replace("November","Noviembre")
																		.Replace("December","Diciembre");

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
			this.CalFecha.DateChanged += new eWorld.UI.DateChangedEventHandler(this.CalFecha_DateChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IMplementacion del Control
			protected DateTime Day
			{
				get
				{
					if (Request.Params["day"] != null)
					{
						try
						{
							return Convert.ToDateTime(Request.Params["day"]);
						}
						catch
						{
							// do nothing, continue to return today
						}
					}
					return DateTime.Now;
				}
			}

		private DataTable ObtenerDatos()
		{
			DateTime FFecha =this.DayPilotCalendar1.StartDate;
			string FechaDesde = FFecha.Year.ToString() + 
				  ((FFecha.Month.ToString().Length==1)?"0" + FFecha.Month.ToString():FFecha.Month.ToString())
				+ ((FFecha.Day.ToString().Length==1)?"0" + FFecha.Day.ToString():FFecha.Day.ToString());

			FFecha =this.DayPilotCalendar1.EndDate;
			string FechaHasta = FFecha.Year.ToString() + 
				((FFecha.Month.ToString().Length==1)?"0" + FFecha.Month.ToString():FFecha.Month.ToString())
				+ ((FFecha.Day.ToString().Length==1)?"0" + FFecha.Day.ToString():FFecha.Day.ToString());

			return ((CAgenda) new CAgenda()).ConsultarAgenda(CNetAccessControl.GetIdUser(),FechaDesde,FechaHasta);
			
		}
		protected DataTable getData
		{
			get
			{
				DataTable dt;
				dt= new DataTable();
				dt.Columns.Add("start", typeof(DateTime));
				dt.Columns.Add("end", typeof(DateTime));
				dt.Columns.Add("name", typeof(string));
				dt.Columns.Add("id", typeof(string));
	
				DataRow dr;
				DataTable dtOrigen = ObtenerDatos();
				if (dtOrigen !=null)
				{
					foreach(DataRow drOrigen in dtOrigen.Rows)
					{
						dr = dt.NewRow();
						dr["id"] = drOrigen["id"];
						dr["start"] = Convert.ToDateTime(drOrigen["FechaHoraInicio"].ToString());
						dr["end"] = Convert.ToDateTime(drOrigen["FechaHoraTermino"].ToString());
						dr["name"] = drOrigen["Asunto"].ToString();
						dt.Rows.Add(dr);

					}
				}
				return dt;
			}
		}


		#endregion


		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarAgenda.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarAgenda.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarAgenda.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarAgenda.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarAgenda.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarAgenda.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarAgenda.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarAgenda.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarAgenda.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarAgenda.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarAgenda.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void CalFecha_DateChanged(object sender, System.EventArgs e)
		{
			Page.Response.Redirect("AdministrarAgenda.aspx?day=" + CalFecha.SelectedDate);
		}
	}
}
