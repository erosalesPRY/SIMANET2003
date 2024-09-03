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
	/// Summary description for ListarMaterialesPorPersona.
	/// </summary>
	public class ListarMaterialesPorPersona : System.Web.UI.Page,IPaginaBase
	{
		protected projDataGridWeb.DataGridWeb gridMat;
		const string KEYQCODPERSONA="CodPers";
		const string KEYQCLASEMAT="ClasMat";

		public string CodigoPersona{
			get{return Page.Request.Params[KEYQCODPERSONA].ToString();}
		}
		public string ClaseMaterial
		{
			get{return Page.Request.Params[KEYQCLASEMAT].ToString();}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
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
					this.LlenarDatos();

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
			this.gridMat.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridMat_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		DataTable ObtenerDatos()
		{
			return(new CCCTT_KardexPersona()).ListarTodosGrilla(this.CodigoPersona,this.ClaseMaterial);
		}

		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.RowFilter    = Utilitario.Helper.ObtenerFiltro();
				gridMat.DataSource = dv;
			}
			else
			{
				gridMat.DataSource = dt;
			}
			
			try
			{
				gridMat.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				gridMat.CurrentPageIndex = 0;
				gridMat.DataBind();
			}										
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ListarMaterialesPorPersona.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ListarMaterialesPorPersona.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ListarMaterialesPorPersona.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.gridMat.ID = "grid"+ this.ClaseMaterial;
		}

		public void LlenarJScript()
		{
			// TODO:  Add ListarMaterialesPorPersona.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ListarMaterialesPorPersona.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ListarMaterialesPorPersona.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ListarMaterialesPorPersona.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ListarMaterialesPorPersona.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ListarMaterialesPorPersona.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void gridMat_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item)||(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],gridMat.CurrentPageIndex,gridMat.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				e.Item.Cells[0].Attributes.Add(SIMA.Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"DetalleMaterialDisponibledeEntrega.Modificar('" + this.CodigoPersona + "','" + this.ClaseMaterial + "','" + dr["Cod_Entrega"].ToString() + "','" + dr["Cod_Item"].ToString() + "');");
				e.Item.Cells[0].ForeColor=Color.Blue;
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[6].Style.Add("background","#ffcc66");

				System.Web.UI.WebControls.Image oimg = (System.Web.UI.WebControls.Image)e.Item.Cells[9].FindControl("imgEliminar");
				//Devoluciones
				if(dr["Id_Mat_Est"].ToString().Equals("2"))
				{
					e.Item.Cells[1].Attributes.Add("class","cellClass");
					for(int i=0;i<=e.Item.Cells.Count-1;i++)
					{
						e.Item.Cells[i].Style.Add("text-decoration","line-through");
						e.Item.Cells[i].Style.Add("color","#696969");
					}
				}
				else	if(dr["Id_Mat_Est"].ToString().Equals("1")) //recibido
				{
						oimg.ImageUrl =    Request.ApplicationPath.ToString() + "/imagenes/Navegador/HuellaAprobada.gif";
				}
				/*else	if(dr["Id_Mat_Est"].ToString().Equals("3")) //Confirmacion de recibido
				{
					oimg.ImageUrl =    Request.ApplicationPath.ToString() + "/imagenes/Filtro/aprobar.gif";
				}*/
				else
				{
					//funcionalidad para deshabilitar la devolución
					oimg.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"ListarMaterialesPorPersona.Eliminar('" + dr["Cod_Entrega"].ToString() + "');");
					e.Item.Attributes.Add(SIMA.Utilitario.Enumerados.EventosJavaScript.Ondblclick.ToString(),"DetalleMaterialDisponibledeEntrega.Devolucion('" + dr["Cod_Entrega"].ToString() + "','" + dr["Cantidad"].ToString() + "');");
				}
				
			}
		}
		
		

	}
}
