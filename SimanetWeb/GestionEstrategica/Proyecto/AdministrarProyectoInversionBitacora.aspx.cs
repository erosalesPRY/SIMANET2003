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
using SIMA.Controladoras.GestionEstrategica.Proyecto;
using SIMA.Controladoras.General;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionEstrategica.Proyecto
{
	/// <summary>
	/// Summary description for AdministrarProyectoInversionBitacora.
	/// </summary>
	public class AdministrarProyectoInversionBitacora : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.DataGrid gridBitacora;
	
		const string KEYQIDPROYECTOPERFIL="IdProyPerf";
		private int [] Aleatorio;
		private int idx=0;
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				Aleatorio=CalcularNumeros();
				try
				{
					this.LlenarGrilla();
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

		private int[] CalcularNumeros()
		{
			int[] numeros = new int[50];
			Random r = new Random();

			int auxiliar = 0;
			int contador = 0;

			for (int i = 0; i < 25; i++)
			{
				auxiliar = r.Next(1, 75);
				bool continuar = false;

				while (!continuar)
				{
					for (int j = 0; j <= contador; j++)
					{
						if (auxiliar == numeros[j])
						{
							continuar = true;
							j = contador;
						}
					}

					if (continuar)
					{
						auxiliar = r.Next(1, 75);
						continuar = false;
					}
					else
					{
						continuar = true;
						numeros[contador] = auxiliar;
						contador++;
					}                    
				}
			}

			return numeros;
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
			this.gridBitacora.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridBitacora_ItemDataBound);
			this.gridBitacora.SelectedIndexChanged += new System.EventHandler(this.gridBitacora_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt=this.ObtenerDatos();

			if(dt!=null)
			{
				gridBitacora.DataSource = dt;
			}
			else
			{
				gridBitacora.DataSource = dt;
			}
			try
			{
				gridBitacora.DataBind();
			}
			catch	
			{
				gridBitacora.CurrentPageIndex = 0;
				gridBitacora.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarProyectoInversionBitacora.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return (new CProyectoPerfilBitacora()).ListarTodosGrilla(Page.Request.Params[KEYQIDPROYECTOPERFIL].ToString());
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarProyectoInversionBitacora.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarProyectoInversionBitacora.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarProyectoInversionBitacora.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarProyectoInversionBitacora.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarProyectoInversionBitacora.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarProyectoInversionBitacora.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarProyectoInversionBitacora.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarProyectoInversionBitacora.ValidarFiltros implementation
			return false;
		}

		#endregion

		


		private void gridBitacora_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				TextBox tb = (TextBox) e.Item.Cells[0].FindControl("txtFecha");
				tb.Text = ((dr["Fecha"].ToString().Length==0)?"":Convert.ToDateTime(dr["Fecha"].ToString()).ToShortDateString());
				tb.ID = "txtFecha" + Aleatorio[idx].ToString();
				idx++;
				tb = (TextBox) e.Item.Cells[1].FindControl("txtDescripcion");
				tb.Text =dr["Descripcion"].ToString();
				e.Item.Attributes["NMODO"]=dr["IdReg"].ToString();
				e.Item.Attributes["IDBITACORA"]=dr["IdBitacora"].ToString();
				e.Item.Attributes["IDPROYECTOPERFIL"]=Page.Request.Params[KEYQIDPROYECTOPERFIL].ToString();
				e.Item.Attributes["FECHA"]=((dr["Fecha"].ToString().Length==0)?"":Convert.ToDateTime(dr["Fecha"].ToString()).ToShortDateString());
				e.Item.Attributes["DESCRIPCION"]=dr["Descripcion"].ToString();

				HtmlImage oimgElimina = (HtmlImage)e.Item.Cells[2].FindControl("imgEliminaBitacora");
				oimgElimina.Style["display"]=((dr["Fecha"].ToString().Length==0)?"none":"block");
			}

		}

		private void gridBitacora_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/*private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				TextBox txtFecha = (TextBox)e.Item.Cells[1].FindControl("txtFecha");
				txtFecha.Attributes["rel"]="calendar";
			}

		}*/
	}
}
