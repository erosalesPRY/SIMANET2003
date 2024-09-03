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
	/// Summary description for ListarValedeSalidaDisponibles.
	/// </summary>
	public class ListarValedeSalidaDisponibles : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento	
	{
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtBuscarVSM;

		const string KEYQIDAREA="IdArea";
		public string CodArea
		{
			get{return Page.Request.Params[KEYQIDAREA].ToString();}
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
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemCreated);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		DataTable ObtenerDatos()
		{
			return(new CCCTT_ValedeSalida()).ListarEncabezado(this.CodArea,DateTime.Now.Year.ToString());
		}

		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.RowFilter    = Utilitario.Helper.ObtenerFiltro();
				grid.DataSource = dv;
			}
			else
			{
				grid.DataSource = dt;
			}
			
			try
			{
				grid.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}						
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ListarValedeSalidaDisponibles.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ListarValedeSalidaDisponibles.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ListarValedeSalidaDisponibles.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{

			}
			else if((e.Item.ItemType == ListItemType.Item)||(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				string CallForms = "ListarMaterialPorAlmacenValedeSalida.Materiales('" + dr["Cod_ceo"].ToString() + "','" + dr["Cod_Alm"].ToString() + "','" + dr["Nro_VSM"].ToString() + "','"+ dr["des_vsm"].ToString()+"','"+ dr["fec_ems"].ToString()+"');";
				e.Item.Cells[0].Attributes.Add(SIMA.Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),CallForms);
				e.Item.Cells[0].ForeColor=Color.Blue;
				e.Item.Cells[0].Font.Underline=true;

				e.Item.Cells[7].Style.Add("background","#ffcc66");

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				
				DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
				for(int i=0;i<=grid.Columns.Count-1;i++)
				{
					TableCell tc = new TableCell();
					if(i==0)
					{
						string TITULO="VALE DE SALIDA";
						tc.ColumnSpan=5;
						tc.Controls.Add(new LiteralControl(TITULO));
					}
					else if((i==5))
					{
						tc.ColumnSpan=3;
						tc.Controls.Add(new LiteralControl("CANTIDAD"));
					}
					else if((i>0 && i<=4)||(i>5&&i<=7))
					{
						tc.Visible=false;
					}
					di.Cells.Add(tc);
				}
				DataGrid dg = (DataGrid)sender;
				Table t = (Table)dg.Controls[0];
				t.Rows.Add(di);
			}		
		}
	}
}
