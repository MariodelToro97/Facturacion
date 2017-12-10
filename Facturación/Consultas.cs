using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Facturación
{
    internal class Consultas
    {
        private SqlConnection connection = new SqlConnection("Data Source=CHOMYDELTORO\\MSSQLSERVER2016;Initial Catalog=eFactur;Integrated Security=True");
        private DataSet dataSet;

        public DataTable productosBajos()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select nombre From Producto Where existencia <= minimo", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Producto");
            connection.Close();
            return dataSet.Tables["Producto"];
        }

        public DataTable productosDepartamento()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select P.nombre, D.nombre as 'Departamento' From Producto as P inner join Departamento as D on P.idDpto = D.id Order By D.nombre", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "productosDepartamento");
            connection.Close();
            return dataSet.Tables["productosDepartamento"];
        }

        public DataTable productosNoVendidos()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From dbo.reporteProductosNoVendidos()", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "productosNoVendidos");
            connection.Close();
            return dataSet.Tables["productosNoVendidos"];
        }

        public DataTable facturasExpedidas()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select dbo.totalFacturasExpedidas() as 'Total Facturas'", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "facturasExpedidas");
            connection.Close();
            return dataSet.Tables["facturasExpedidas"];
        }

        public DataTable facturasExpedidasVendedor(String vendedor)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("Select dbo.facturasExpedidadVendedor({0}) as 'Total Facturas'",vendedor), connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "facturasExpedidas");
            connection.Close();
            return dataSet.Tables["facturasExpedidas"];
        }

        public DataTable facturasdelCliente(String cliente)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("Select count(*) as 'Facturas del Cliente' From Factura Where claveCliente = {0}Group By claveCliente", cliente), connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "facturasCliente");
            connection.Close();
            return dataSet.Tables["facturasCliente"];
        }

        public DataTable ventasMensualesPorAño(String año)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("Select * from dbo.ventasMensuales_X_Año({0});", año), connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "facturasCliente");
            connection.Close();
            return dataSet.Tables["facturasCliente"];
        }

        public DataTable ventasPorAñoCliente(String año)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("select * From dbo.compras_X_Año({0}); ", año), connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "facturasCliente");
            connection.Close();
            return dataSet.Tables["facturasCliente"];
        }

        public DataTable ventasPorAñoTotal(String año)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("Select SUM(total) as 'Ventas Totales' From Factura Where YEAR(fechaEmision) = {0} Group By YEAR(fechaEmision)", año), connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "facturasCliente");
            connection.Close();
            return dataSet.Tables["facturasCliente"];
        }

        public DataTable ventasPorDepartamento(String año)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("Select D.nombre, SUM(DF.importe) * 1.16 as 'Ventas Totales' From Factura as F inner join DetalleFactura as DF on F.folio = Df.folioFactura inner join Producto as P on DF.codigoProducto = P.codigo inner join Departamento as D on P.idDpto = D.id Where Year(F.fechaEmision) = {0} Group By D.nombre", año), connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "facturasDepartamento");
            connection.Close();
            return dataSet.Tables["facturasDepartamento"];
        }

        public DataTable todosProductos()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From Producto", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Productos");
            connection.Close();
            return dataSet.Tables["Productos"];
        }

        public DataTable productoEspecífico(String codigo)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("Select * from Producto where codigo = {0}",codigo), connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Productos");
            connection.Close();
            return dataSet.Tables["Productos"];
        }

        public DataTable productosPorDepartamento()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select P.nombre, D.nombre From Producto as P inner join Departamento as D on P.idDpto = D.id Order By D.nombre; ", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Productos");
            connection.Close();
            return dataSet.Tables["Productos"];
        }

        public DataTable todasFacturas()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From Factura ", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Facturas");
            connection.Close();
            return dataSet.Tables["Facturas"];
        }

        public DataTable facturaEspecífica(String folio)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("Select * From Factura Where folio = {0}", folio), connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Facturas");
            connection.Close();
            return dataSet.Tables["Facturas"];
        }
    }
}