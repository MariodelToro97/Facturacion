using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Facturación
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            MessageBox.Show("                Gracias por usar eFactur. \n             Nos vemos hasta la próxima. \n\n                        Versión 1.03.98");
            Application.Exit();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Form acerca = new Acerca_de();
            acerca.Show();

            this.Hide();
        }

        public void inicio()
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

            Visualizador.Visible = false;

            button28.Visible = false;

            textBox1.Visible = false;
            
            Boton_1TextBox.Visible = false;

            comboBox1.Visible = false;
            comboBox2.Visible = false;            

            comboBox2.Items.Clear();
            comboBox1.Items.Clear();
        }

        public void sintextBox()
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

            textBox1.Visible = false;
            
            textBox1.Text = "";

            Boton_1TextBox.Visible = false;
            
            comboBox1.Visible = false;            
            comboBox2.Visible = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
        }

        public void botonConsultar()
        {
            button28.Visible = true;
            Visualizador.Visible = true;
        }

        public void unTextBox()
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";

            label1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;

            textBox1.Visible = true;
            textBox1.Enabled = true;
            textBox1.Text = "";

            Boton_1TextBox.Visible = true;
            Boton_1TextBox.Enabled = false;

            comboBox1.Visible = false;
            comboBox2.Visible = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            Visualizador.Visible = false;

            button28.Visible = false;
        }

        public void unComboBox()
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = true;

            comboBox1.Visible = true;
            comboBox2.Visible = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            Boton_1TextBox.Visible = true;
            Boton_1TextBox.Enabled = false;

            textBox1.Visible = false;

            textBox1.Text = "";

            Visualizador.Visible = false;

            button28.Visible = false;
        }

        public void dosComboBox()
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";

            label1.Visible = false;
            label2.Visible = true;
            label3.Visible = true;

            textBox1.Visible = false;

            textBox1.Text = "";

            Visualizador.Visible = false;

            button28.Visible = false;

            Boton_1TextBox.Visible = true;
            Boton_1TextBox.Enabled = false;

            comboBox1.Visible = true;
            comboBox2.Visible = true;

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            inicio();
        }

        Consultas consultas = new Consultas();

        private void button28_Click(object sender, EventArgs e)
        {
            inicio();    
        }

        private void productosBajosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sintextBox();

            try
            {
                if (consultas.productosBajos() is null)
                {
                    Visualizador.DataSource = "No hay productos bajos en Inventario";
                }
                else
                {                    
                    Visualizador.DataSource = consultas.productosBajos();
                    botonConsultar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
            }
        }

        private void productosPorDepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sintextBox();

            try
            {
                Visualizador.DataSource = consultas.productosDepartamento();
                botonConsultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
            }
        }

        private void productosNoVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sintextBox();

            try
            {
                Visualizador.DataSource = consultas.productosNoVendidos();
                botonConsultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
            }
        }

        private void númeroDeVentasTotalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sintextBox();

            try
            {
                Visualizador.DataSource = consultas.facturasExpedidas();
                botonConsultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
            }
        }

        private void porVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unTextBox();

            label1.Text = "Código del Vendedor";
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Boton_1TextBox.Enabled = true;
            } else
            {
                Boton_1TextBox.Enabled = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)(Keys.Enter)))
            {
                Boton_1TextBox.Focus();
            }
            if ((char.IsNumber(e.KeyChar)) || (e.KeyChar == ((char)(Keys.Back))))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void Boton_1TextBox_Click(object sender, EventArgs e)
        {
            Boton_1TextBox.Enabled = false;
            textBox1.Enabled = false;

            if (Boton_1TextBox.Text == "Consultar")
            {
                if (label1.Text == "Código del Vendedor")
                {
                    try
                    {
                        Visualizador.DataSource = consultas.facturasExpedidasVendedor(textBox1.Text);
                        botonConsultar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                    }

                }
                else
                {
                    if (label1.Text == "Código del Cliente")
                    {
                        try
                        {
                            Visualizador.DataSource = consultas.facturasdelCliente(textBox1.Text);
                            botonConsultar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                        }
                    }
                    else
                    {
                        if (label3.Text == "Año")
                        {
                            try
                            {
                                Visualizador.DataSource = consultas.ventasMensualesPorAño(comboBox1.SelectedText);
                                comboBox1.Enabled = false;
                                botonConsultar();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                            }
                        }
                        else
                        {
                            if (label3.Text == "Año:" && label2.Text != "Número de Quincena:" && label2.Text != "Mes:")
                            {
                                try
                                {
                                    Visualizador.DataSource = consultas.ventasPorAñoCliente(comboBox1.SelectedText);
                                    comboBox1.Enabled = false;
                                    botonConsultar();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                                }
                            }
                            else
                            {
                                if (label3.Text == " Año:")
                                {
                                    try
                                    {
                                        Visualizador.DataSource = consultas.ventasPorAñoTotal(comboBox1.SelectedText);
                                        comboBox1.Enabled = false;
                                        botonConsultar();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                                    }
                                }
                                else
                                {
                                    if (label3.Text == " Año: ")
                                    {
                                        try
                                        {
                                            Visualizador.DataSource = consultas.ventasPorDepartamento(comboBox1.SelectedText);
                                            comboBox1.Enabled = false;
                                            botonConsultar();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                                        }
                                    }
                                    else
                                    {
                                        if (label1.Text == "Código del Producto")
                                        {
                                            try
                                            {
                                                Visualizador.DataSource = consultas.productoEspecífico(textBox1.Text);
                                                botonConsultar();
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                                            }
                                        }
                                        else
                                        {
                                            if (label1.Text == "Folio de la Factura:")
                                            {
                                                try
                                                {
                                                    Visualizador.DataSource = consultas.facturaEspecífica(textBox1.Text);
                                                    botonConsultar();
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                                                }
                                            }
                                            else
                                            {
                                                if (label1.Text == "Clave del Vendedor:")
                                                {
                                                    try
                                                    {
                                                        Visualizador.DataSource = consultas.vendedorEspecifico(textBox1.Text);
                                                        botonConsultar();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                                                    }
                                                }
                                                else
                                                {
                                                    if (label1.Text == "Clave del Cliente:")
                                                    {
                                                        try
                                                        {
                                                            Visualizador.DataSource = consultas.clienteEspecifico(textBox1.Text);
                                                            botonConsultar();
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (label1.Text == "Clave del Proveedor:")
                                                        {
                                                            try
                                                            {
                                                                Visualizador.DataSource = consultas.proveedorEspecífico(textBox1.Text);
                                                                botonConsultar();
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (label3.Text == "Año:" && label2.Text == "Número de Quincena:")
                                                            {
                                                                int a, b;

                                                                a = int.Parse(comboBox1.SelectedItem.ToString());
                                                                b = int.Parse(comboBox2.SelectedItem.ToString());

                                                                try
                                                                {
                                                                    Visualizador.DataSource = consultas.nominaQuincenal(a, b);
                                                                    comboBox1.Enabled = false;
                                                                    comboBox2.Enabled = false;
                                                                    botonConsultar();
                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (label3.Text == "Año:" && label2.Text == "Mes:")
                                                                {
                                                                    try
                                                                    {
                                                                        Visualizador.DataSource = consultas.nominaMensual(int.Parse(comboBox1.SelectedItem.ToString()), (comboBox2.SelectedIndex + 1));
                                                                        comboBox1.Enabled = false;
                                                                        comboBox2.Enabled = false;
                                                                        botonConsultar();
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (Boton_1TextBox.Text == "Eliminar")
                {
                    if (label1.Text == "Clave del Vendedor:")
                    {
                        try
                        {
                            if (consultas.eliminarVendedor(textBox1.Text))
                            {
                                MessageBox.Show("Vendedor eliminado correctamente");
                                Visualizador.DataSource = consultas.todosVendedores();
                                botonConsultar();
                            }
                            else
                            {
                                MessageBox.Show("No se ha podido eliminar correctamente");
                            }                    
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                        }
                    }
                    else
                    {
                        if (label1.Text == "Clave del Cliente:")
                        {
                            try
                            {
                                if (consultas.eliminarCliente(textBox1.Text))
                                {
                                    MessageBox.Show("Cliente eliminado correctamente");
                                    Visualizador.DataSource = consultas.todosClientes();
                                    botonConsultar();
                                }
                                else
                                {
                                    MessageBox.Show("No se ha podido eliminar correctamente");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                            }
                        }
                        else
                        {
                            if (label1.Text == "Clave del Proveedor:")
                            {
                                try
                                {
                                    if (consultas.eliminarProveedor(textBox1.Text))
                                    {
                                        MessageBox.Show("Proveedor eliminado correctamente");
                                        Visualizador.DataSource = consultas.todosProveedores();
                                        botonConsultar();
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se ha podido eliminar correctamente");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                                }
                            }
                            else
                            {
                                if (label1.Text == "Clave del Producto:")
                                {
                                    try
                                    {
                                        if (consultas.eliminarProveedor(textBox1.Text))
                                        {
                                            MessageBox.Show("Producto eliminado correctamente");
                                            Visualizador.DataSource = consultas.todosProductos();
                                            botonConsultar();
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se ha podido eliminar correctamente");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            
            button28.Focus();
        }

        private void porClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unTextBox();

            label1.Text = "Código del Cliente";
            textBox1.Focus();
        }

        private void ventasMensualesPorAñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unComboBox();

            label3.Text = "Año";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("2015");
            comboBox1.Items.Add("2016");
            comboBox1.Items.Add("2017");
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) || (e.KeyChar == ((char)(Keys.Back))))
                e.Handled = true;
            else
                e.Handled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 )
            {
                Boton_1TextBox.Enabled = true;
            } else
            {
                Boton_1TextBox.Enabled = false;
            }
        }

        private void porClienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            unComboBox();

            label3.Text = "Año:";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("2015");
            comboBox1.Items.Add("2016");
            comboBox1.Items.Add("2017");
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unComboBox();

            label3.Text = " Año:";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("2015");
            comboBox1.Items.Add("2016");
            comboBox1.Items.Add("2017");
        }

        private void ventasPorDepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unComboBox();

            label3.Text = " Año: ";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("2015");
            comboBox1.Items.Add("2016");
            comboBox1.Items.Add("2017");
        }

        private void todosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            sintextBox();

            try
            {
                Visualizador.DataSource = consultas.todosProductos();

                button28.Visible = true;
                Visualizador.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
            }
        }

        private void específicoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            unTextBox();

            label1.Text = "Código del Producto";
            textBox1.Focus();
        }

        private void todasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sintextBox();

            try
            {
                Visualizador.DataSource = consultas.todasFacturas();
                botonConsultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
            }
        }

        private void específicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unTextBox();

            label1.Text = "Folio de la Factura:";
            textBox1.Focus();
        }

        private void todosLosVendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sintextBox();

            try
            {
                Visualizador.DataSource = consultas.todosVendedores();
                botonConsultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
            }
        }

        private void vendedorEspecíficoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unTextBox();

            label1.Text = "Clave del Vendedor:";
            textBox1.Focus();
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sintextBox();

            try
            {
                Visualizador.DataSource = consultas.todosClientes();
                botonConsultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
            }
        }

        private void específicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unTextBox();

            label1.Text = "Clave del Cliente:";
            textBox1.Focus();
        }

        private void todosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            sintextBox();

            try
            {
                Visualizador.DataSource = consultas.todosProveedores();
                botonConsultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
            }
        }

        private void específicoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            unTextBox();

            label1.Text = "Clave del Proveedor:";
            textBox1.Focus();
        }

        private void quincenalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dosComboBox();

            label3.Text = "Año:";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("2015");
            comboBox1.Items.Add("2016");
            comboBox1.Items.Add("2017");

            label2.Text = "Número de Quincena:";
            comboBox2.Items.Clear();

            for (int i = 1; i < 25; i++)
            {
                comboBox2.Items.Add(i);
            }
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) || (e.KeyChar == ((char)(Keys.Back))))
                e.Handled = true;
            else
                e.Handled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                Boton_1TextBox.Enabled = true;
            }
            else
            {
                Boton_1TextBox.Enabled = false;
            }
        }

        private void mensualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dosComboBox();

            label3.Text = "Año:";
            
            comboBox1.Items.Add("2015");
            comboBox1.Items.Add("2016");
            comboBox1.Items.Add("2017");

            label2.Text = "Mes:";            

            comboBox2.Items.Add("Enero");
            comboBox2.Items.Add("Febrero");
            comboBox2.Items.Add("Marzo");
            comboBox2.Items.Add("Abril");
            comboBox2.Items.Add("Mayo");
            comboBox2.Items.Add("Junio");
            comboBox2.Items.Add("Julio");
            comboBox2.Items.Add("Agosto");
            comboBox2.Items.Add("Septiembre");
            comboBox2.Items.Add("Octubre");
            comboBox2.Items.Add("Noviembre");
            comboBox2.Items.Add("Diciembre");
        }

        private void eliminarVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unTextBox();

            label1.Text = "Clave del Vendedor:";
            Boton_1TextBox.Text = "Eliminar";
        }

        private void eliminarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unTextBox();
            label1.Text = "Clave del Cliente:";
            Boton_1TextBox.Text = "Eliminar";
        }

        private void eliminarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unTextBox();
            label1.Text = "Clave del Proveedor:";
            Boton_1TextBox.Text = "Eliminar";
        }

        private void eliminarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unTextBox();
            label1.Text = "Clave del Producto:";
            Boton_1TextBox.Text = "Eliminar";
        }

        Vendedores vender = new Vendedores();
        Form vendedor = new Vendedores();

        private void darDeAltaVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vender.inicioInsertar();
           
            vendedor.Show();
            this.Hide();
        }

        private void modificarVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vender.inicioModificar();
            vendedor.Show();
            this.Hide();
           
        }

        private void realizarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form factura = new Factura();

            factura.Show();
            this.Hide();
        }

        private void darDeAltaProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Proveedores();

            Proveedores prove = new Proveedores();

            prove.ingresarinsertar();

            form.Show();
            this.Hide();
        }
    }
}
