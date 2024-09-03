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
using SIMA.Controladoras.Legal;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Runtime.InteropServices;

namespace SIMA.SimaNetWeb.GestionFinanciera
{
	public class Procesar : System.Web.UI.Page
	{
		#region Constante
			const string PROCESO ="idProceso";
			const int TABLASFINANCIERA=35;
			const string KEYQIDMODULO = "IDMODULO";
			const int LETRASDESCUENTOACT=41;
		//Descuento de letras
			const string KEYIDENTIDADFINANCIERA = "idEF";
			const string KEYIDDOCDESCLET ="idDocdescLetra";
			const string KEYIDLETDESCTDET ="idLetraDesctDet";
			const string KEYIMPINTERES ="impInt";
			const string KEYIMPGASTO ="impGst";
		//Buscar Facturas
			const int BUSCARFATURAS=50;
			const string KEYQCRITERIO="CRITERIO";
			const string CAMPOTEXTO="cTexto";
			const string CAMPOVALOR="cValor";
			const string KEYIDTIPOLETRA = "TipoLetra";
		//Buscar Carta Fianza
		const int BUSCARFIANZA=42;
		const int BUSCARFIANZAPROYECTO=200;
		const int REPORTEFIANZASENRIEGO=52;
		const int REPORTERESUMENFIANZASENRIEGO=53;
		const int REPORTERESUMENPROYECTOSENFIANZASENRIEGO=56;
		const int REPORTERESUMENPROYECTOSDEFIANZASEMITIDAS=57;
		const int REPORTERESUMENPROYECTOSDEFIANZASEMITIDASXCANTIDAD=58;
		const int MANTENIMIENTOCARTAFIANZABITACORA=226;
		const int CONSULTARCARTAFIANZABITACORA=227;
		

		const string KEYQESTADOFZA="EstadoFza";

		const int LISTARFIANZARENOVACION=43;
		const string KEYQIDCENTRO="IdCentro";
		const string KEYQPERIODO="Periodo";
		const string KEYQIDFIANZA="idFza";
		const string KEYIDDETCF="idFzaDet";
		const string KEYQDESCRIPCION="Descrip";
		const string KEYQIDESTADO="IdEstado";

		const string KEYQIDPROYECTOCONTRATO="IdProyectoContrato";

		const int LISTARFIANZARENOVACIONCARGOS=44;
		const int CONSULTARFIANZASPORPROYECTO=45;
		const int CONSULTARPROYECTOPORCONCEPTO=46;

		
		//Facturas
		const string KEYQIDCLIENTEPROVEEDOR="IdClienteProveedor";
		const string KEYQIDMONEDA="IdMoneda";
		const string KEYQFECHA="Fecha";
		const string KEYQIDTIPO="IdTipo";
			
		//Bitacora de Fianzas
		const string KEYQIDBITACORA="IdBit";

		//Campo de busqueda
		const string KEYCAMPOFIIND="FieldFind";

		/// <summary>
		/// Para la busqueda de personal 
		const int BUSCARPERSONA=55;
		const int BUSCARPERSONALSIMA=316;
		const int RPTFIANZA=69;


		const int PRCCONSULTARTIPODECAMBIO=101;
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				if (Page.Request.Params[PROCESO]!=null)
				{
					if(Convert.ToInt32(Page.Request.Params[PROCESO])==TABLASFINANCIERA)
					{
						DataView dv = (new CTablasParametros()).ListarComboTablaTablasPorModulos(Convert.ToInt32(Page.Request.Params[KEYQIDMODULO])).DefaultView;
						string criterio = Helper.CampoBusqueda() + " like '%" + Helper.CriterioBusqueda() + "%'";
						dv.RowFilter=criterio;
						Helper.AutoBusquedaResultado(Helper.DataViewTODataTable(dv));
						//Helper.GenerarEsquemaXMLNTAD((new CTablasParametros()).ListarComboTablaTablasPorModulos(Convert.ToInt32(Page.Request.Params[KEYQIDMODULO])));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==LETRASDESCUENTOACT)
					{
						LetrasDescuentoBE oLetrasDescuentoBE = new LetrasDescuentoBE();
						oLetrasDescuentoBE.IdLetrasDescuento = Page.Request.Params[KEYIDLETDESCTDET].ToString();
						oLetrasDescuentoBE.IdDescuento = Page.Request.Params[KEYIDDOCDESCLET].ToString();
						oLetrasDescuentoBE.ImporteInteres = Convert.ToDouble(Page.Request.Params[KEYIMPINTERES].ToString());
						oLetrasDescuentoBE.ImporteGasto = Convert.ToDouble(Page.Request.Params[KEYIMPGASTO].ToString());
						//oLetrasDescuentoBE.IdLetra = hIdLetra.Value.ToString();
						
						oLetrasDescuentoBE.IdUsuarioActualizacion= CNetAccessControl.GetIdUser();
						oLetrasDescuentoBE.IdTablaEstado= Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraSituacionLetras);
						oLetrasDescuentoBE.IdEstado= 1;//En descuento de letras
						((CLetrasDescuento)new CLetrasDescuento()).Modificar(oLetrasDescuentoBE);

						DescuentoBE oDescuentoBE = (DescuentoBE) ((CDescuento) new CDescuento()).DetalleDescuento(Page.Request.Params[KEYIDDOCDESCLET].ToString(),Utilitario.Constantes.IDDEFAULT,Convert.ToInt32(Page.Request.Params[KEYIDENTIDADFINANCIERA]==null? Utilitario.Constantes.IDDEFAULT.ToString():Page.Request.Params[KEYIDENTIDADFINANCIERA]));
						string Resultado =  Convert.ToDouble(oDescuentoBE.MontoAmortiza.ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4)
							+ ";" + Convert.ToDouble(oDescuentoBE.SaldoLetra.ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4)
							+ ";" + Convert.ToDouble(oDescuentoBE.MontoDescuentoBCO.ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4)
							+ ";" + Convert.ToDouble(oDescuentoBE.MontoDesembolso.ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);
						
						Helper.GenerarEsquemaXMLTAD(Resultado);
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==BUSCARFATURAS)
					{
						DataTable dt = new DataTable();
						if(Convert.ToInt32(Page.Request.Params[KEYIDTIPOLETRA])==0)
						{
							dt= (new CFacturasEnLetras()).ListarFacturasPorCobrar(Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO]),Convert.ToInt32(Page.Request.Params[KEYQIDCLIENTEPROVEEDOR]),Convert.ToInt32(Page.Request.Params[KEYQIDMONEDA]),Helper.CriterioBusqueda());
						}
						else
						{
							dt= (new CFacturaPorPagar()).ListarFacturasPorPagar(Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO]),Convert.ToInt32(Page.Request.Params[KEYQIDCLIENTEPROVEEDOR]),Convert.ToInt32(Page.Request.Params[KEYQIDMONEDA]),Helper.CriterioBusqueda());
						}
						Helper.AutoBusquedaResultado(dt);
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==BUSCARFIANZA)
					{
						Helper.AutoBusquedaResultado((new CCartaFianza()).ConsultarCartaFianzaDetallePorNro(Helper.CampoBusqueda(),Helper.CriterioBusqueda()));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==BUSCARFIANZAPROYECTO)
					{
						Helper.AutoBusquedaResultado((new CProyectosEspeciales()).ConsultarFianzas(Helper.CriterioBusqueda(),String.Empty));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==LISTARFIANZARENOVACION)
					{
						Helper.GenerarEsquemaXMLNTAD((new CCartaFianza()).ConsultarRenovacionCartaFianza(Convert.ToInt32(Page.Request.Params[KEYQIDFIANZA]),Convert.ToInt32(Page.Request.Params[KEYQPERIODO]),1));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==LISTARFIANZARENOVACIONCARGOS)
					{
						Helper.GenerarEsquemaXMLNTAD((new CCartaFianza()).ConsultarCartaFianzaNotadeCargo(Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO])
							,Convert.ToInt32(Page.Request.Params[KEYIDDETCF])
							,Convert.ToInt32(Page.Request.Params[KEYQIDFIANZA])
							,Convert.ToInt32(Page.Request.Params[KEYQPERIODO])));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==CONSULTARFIANZASPORPROYECTO)
					{
						Helper.GenerarEsquemaXMLNTAD((new CProyectosEspeciales()).ConsultarFianzas(
							Convert.ToInt32(Page.Request.Params[KEYQIDPROYECTOCONTRATO])));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==CONSULTARPROYECTOPORCONCEPTO)
					{
						Helper.AutoBusquedaResultado((new CProyectosEspeciales()).ConsultarProyectoPorConcepto(Helper.CampoBusqueda(),Helper.CriterioBusqueda()));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==REPORTEFIANZASENRIEGO)
					{
						DataSet ds = new DataSet("sw");
						DataTable dt1 =  (new CCartaFianza()).ConsultarAnalisisCartaFianzaEnRiesgo(Page.Request.Params[KEYQESTADOFZA].ToString()).Copy();
						//dt1.TableName="CartaFianzaAnalisisyCostos_Litigio_Detalle_V";
						dt1.TableName="FINuspNTADConsultarCartaFianzaEnRiesgo;1";
						
						ds.Tables.Add(dt1);

						DataTable dt2 = (new CCartaFianza()).ConsultarAnalisisSubResumenCartaFianzaEnRiesgo(Page.Request.Params[KEYQESTADOFZA].ToString()).Copy();
						if(dt2!=null)
						{
							dt2.TableName="FINuspNTADConsultarSubResumenCartaFianzaEnRiesgo;1";
							ds.Tables.Add(dt2);
						}

						DataTable dt3 = (new CCartaFianza()).ConsultarAnalisisSubResumenTotalCartaFianzaEnRiesgo(Page.Request.Params[KEYQESTADOFZA].ToString()).Copy();
						if(dt3!=null)
						{
							dt3.TableName="FINuspNTADConsultarSubResumenTotalCartaFianzaEnRiesgo;1";
							ds.Tables.Add(Helper.DataViewTODataTable(dt3.DefaultView));
						}
						else
						{

							dt3  = new DataTable("FINuspNTADConsultarSubResumenTotalCartaFianzaEnRiesgo;1");
							ds.Tables.Add(dt3);

						}


						Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\OperacionesFinancieras\","AnalisisdeCartaFianzayDetalle.rpt",ds,true);




					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==REPORTERESUMENFIANZASENRIEGO)
					{
						Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\OperacionesFinancieras\","ResumenProyectosEnRiesgo.rpt",(new CCartaFianza().ConsultarAnalisisResumenCartaFianzaEnRiesgo(Page.Request.Params[KEYQESTADOFZA].ToString())),true);
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==REPORTERESUMENPROYECTOSENFIANZASENRIEGO)
					{
						Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\OperacionesFinancieras\","ResumenFianzaConProyectosPorCentroSituacionEstado.rpt",(new CCartaFianza().ConsultarResumendeFianzasEnRiesgoPorCentroEstadoSituacion()),true);
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==BUSCARPERSONA)
					{
						Helper.AutoBusquedaResultado((new CPersonal()).BuscarPersonalSegunPalabraClave(Helper.CriterioBusqueda()));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==BUSCARPERSONALSIMA)
					{
						Helper.AutoBusquedaResultado((new  SIMA.Controladoras.Personal.CPersonal()).BuscarPersonalSIMA(Page.Request.Params[KEYCAMPOFIIND].ToString(),Helper.CriterioBusqueda()));
					}

					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==RPTFIANZA)
					{
						Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\OperacionesFinancieras\","ReporteCartaFianza.rpt",(new CCartaFianza().ReporteCartaFianza(Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO]))),true);
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==REPORTERESUMENPROYECTOSDEFIANZASEMITIDAS)
					{
						Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\OperacionesFinancieras\","ResumenCartaFianzasEmitidas.rpt",(new CCartaFianza().ResumenCartaFianzasEmitidas()),true);
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==REPORTERESUMENPROYECTOSDEFIANZASEMITIDASXCANTIDAD)
					{
						Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\OperacionesFinancieras\","ResumenCartaFianzasEmitidasxCantidad.rpt",(new CCartaFianza().ResumenCartaFianzasEmitidasxCantidad()),true);
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==PRCCONSULTARTIPODECAMBIO)
					{
						Helper.GenerarEsquemaXMLNTAD((new CTipoCambio()).ObtenerTipodeCambio(Convert.ToInt32(Page.Request.Params[KEYQIDTIPO]),Convert.ToInt32(Page.Request.Params[KEYQIDMONEDA]),Convert.ToDateTime(Page.Request.Params[KEYQFECHA])));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==MANTENIMIENTOCARTAFIANZABITACORA)
					{
						CartaFianzaBitacoraBE oCartaFianzaBitacoraBE= new CartaFianzaBitacoraBE();
						oCartaFianzaBitacoraBE.IdBitacora = Convert.ToInt32(Page.Request.Params[KEYQIDBITACORA]);
						oCartaFianzaBitacoraBE.IdCartaFianza = Convert.ToInt32(Page.Request.Params[KEYQIDFIANZA]);
						oCartaFianzaBitacoraBE.Periodo = Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);
						oCartaFianzaBitacoraBE.Fecha = Convert.ToDateTime(Page.Request.Params[KEYQFECHA]);
						oCartaFianzaBitacoraBE.Descripcion = Convert.ToString(Page.Request.Params[KEYQDESCRIPCION]);
						oCartaFianzaBitacoraBE.pIdEstado = Convert.ToInt32(Page.Request.Params[KEYQIDESTADO]);
						int IdResult = (new CCartaFianzaBitacora()).InsertarModificar(oCartaFianzaBitacoraBE);
						Helper.GenerarEsquemaXMLTAD(IdResult);
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==CONSULTARCARTAFIANZABITACORA)
					{
						Helper.GenerarEsquemaXMLNTAD((new CCartaFianzaBitacora()).ConsultarBitacoraPorFianza(Convert.ToInt32(Page.Request.Params[KEYQPERIODO]),Convert.ToInt32(Page.Request.Params[KEYQIDFIANZA]),99));
					}


					


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
	}
}

