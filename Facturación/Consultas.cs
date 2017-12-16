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
            SqlCommand command = new SqlCommand(String.Format("Select count(*) as 'Facturas del Cliente' From Factura Where claveCliente = {0} Group By claveCliente", cliente), connection);
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

        public DataTable todosVendedores()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From Vendedor", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Vendedor");
            connection.Close();
            return dataSet.Tables["Vendedor"];
        }

        public DataTable vendedorEspecifico(String clave)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("Select * From Vendedor Where clave = {0}", clave), connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Vendedor");
            connection.Close();
            return dataSet.Tables["Vendedor"];
        }

        public DataTable todosClientes()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from Cliente", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Cliente");
            connection.Close();
            return dataSet.Tables["Cliente"];
        }

        public DataTable clienteEspecifico(String clave)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("Select * From Cliente Where clave = {0}", clave), connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Vendedor");
            connection.Close();
            return dataSet.Tables["Vendedor"];
        }

        public DataTable todosProveedores()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from Proveedores", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Proveedor");
            connection.Close();
            return dataSet.Tables["Proveedor"];
        }

        public DataTable proveedorEspecífico(String clave)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("Select * from Proveedores Where Clave = {0}",clave), connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Proveedor");
            connection.Close();
            return dataSet.Tables["Proveedor"];
        }

        public DataTable nominaQuincenal(int año, int quincena)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("nominaQuincenal", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Quincena", SqlDbType.Int).Value = quincena;
            command.Parameters.Add("@Año", SqlDbType.Int).Value = año;
            command.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Nomina");
            connection.Close();
            return dataSet.Tables["Nomina"];
        }

        public DataTable nominaMensual(int año, int Mes)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("nominaMensual2", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Año", SqlDbType.Int).Value = año;
            command.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes;
            command.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Nomina");
            connection.Close();
            return dataSet.Tables["Nomina"];
        }

        public bool eliminarVendedor(String clave)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("Delete From Vendedor Where Clave = {0}", clave), connection);
            int filasafectadas = command.ExecuteNonQuery();
            connection.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool eliminarCliente(String clave)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("Delete From Cliente Where Clave = {0}", clave), connection);
            int filasafectadas = command.ExecuteNonQuery();
            connection.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool eliminarProveedor(String clave)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("Delete From Proveedores Where Clave = {0}", clave), connection);
            int filasafectadas = command.ExecuteNonQuery();
            connection.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool eliminarProducto(String clave)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("Delete From Producto Where codigo = {0}", clave), connection);
            int filasafectadas = command.ExecuteNonQuery();
            connection.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool insertarVendedor(String rfc, String nombre, String sexo, String fecha, String sueldo, String comision)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("insert into Vendedor values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", new String[] { rfc, nombre, sexo, fecha, sueldo, comision}), connection);
            int filasafectadas = command.ExecuteNonQuery();
            connection.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool actualizarVendedor(String rfc, String nombre, String sexo, String fecha, String sueldo, String comision, String clave)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("actualizarVendedor", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@clave", SqlDbType.Int).Value = clave;
            command.Parameters.Add("@rfc", SqlDbType.VarChar).Value = rfc;
            command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
            command.Parameters.Add("@sexo", SqlDbType.Char).Value = sexo;
            command.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
            command.Parameters.Add("@sueldoBase", SqlDbType.Money).Value = sueldo;
            command.Parameters.Add("@comision", SqlDbType.Decimal).Value = comision;
            int filasafectadas = command.ExecuteNonQuery();            
            connection.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool insertarFactura(String formaPago, int claveVendedor, int claveCliente)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("registrarFactura", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@formaPago", SqlDbType.VarChar).Value = formaPago;
            command.Parameters.Add("@claveCliente", SqlDbType.Int).Value = claveCliente;
            command.Parameters.Add("@claveVendedor", SqlDbType.Int).Value = claveVendedor;
            int filasafectadas = command.ExecuteNonQuery();
                        
            connection.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool registrarDetalle(int folio, int codigoProducto, int cantidad)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("registrarDetalle", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@folioFactura", SqlDbType.Int).Value = folio;
            command.Parameters.Add("@codigoProducto", SqlDbType.Int).Value = codigoProducto;
            command.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
            int filasafectadas = command.ExecuteNonQuery();

            connection.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }
    }
}