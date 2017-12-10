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

        private void Principal_Load(object sender, EventArgs e)
        {
            Visualizador.Visible = false;
            button28.Visible = false;

            label1.Visible = false;
            textBox1.Visible = false;
            Boton_1TextBox.Visible = false;

            label3.Visible = false;
            comboBox1.Visible = false;

            comboBox1.Items.Clear();
        }

        Consultas consultas = new Consultas();

        private void button28_Click(object sender, EventArgs e)
        {
            button28.Visible = false;
            Visualizador.Visible = false;

            label1.Visible = false;
            textBox1.Visible = false;
            Boton_1TextBox.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;
        }

        private void productosBajosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            label1.Visible = false;
            textBox1.Visible = false;
            Boton_1TextBox.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;

            try
            {
                if (consultas.productosBajos() is null)
                {
                    Visualizador.DataSource = "No hay productos bajos en Inventario";
                }
                else
                {
                    button28.Visible = true;
                    Visualizador.Visible = true;

                    Visualizador.DataSource = consultas.productosBajos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
            }
        }

        private void productosPorDepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;
            Boton_1TextBox.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;

            try
            {
                Visualizador.DataSource = consultas.productosDepartamento();

                button28.Visible = true;
                Visualizador.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
            }
        }

        private void productosNoVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;
            Boton_1TextBox.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;

            try
            {
                Visualizador.DataSource = consultas.productosNoVendidos();

                button28.Visible = true;
                Visualizador.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
            }
        }

        private void númeroDeVentasTotalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;
            Boton_1TextBox.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;

            try
            {
                Visualizador.DataSource = consultas.facturasExpedidas();

                button28.Visible = true;
                Visualizador.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
            }
        }

        private void porVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
            textBox1.Enabled = true;
            textBox1.Text = "";
            Boton_1TextBox.Visible = true;
            Boton_1TextBox.Enabled = false;
            label3.Visible = false;
            comboBox1.Visible = false;
            Visualizador.Visible = false;
            button28.Visible = false;

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
            
            if (label1.Text == "Código del Vendedor")
            {
                Boton_1TextBox.Enabled = false;
                textBox1.Enabled = false;

                try
                {
                    Visualizador.DataSource = consultas.facturasExpedidasVendedor(textBox1.Text);

                    button28.Visible = true;
                    Visualizador.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                }

            } else
            {
                if (label1.Text == "Código del Cliente")
                {
                    try
                    {
                        Visualizador.DataSource = consultas.facturasdelCliente(textBox1.Text);                       

                        button28.Visible = true;
                        Visualizador.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                    }
                } else
                {
                    if (label3.Text == "Año")
                    {
                        try
                        {
                            Visualizador.DataSource = consultas.ventasMensualesPorAño(comboBox1.SelectedText);
                            comboBox1.Enabled = false;

                            button28.Visible = true;
                            Visualizador.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
                        }
                    }
                    else
                    {
                        if (label3.Text == "Año:")
                        {
                            try
                            {
                                Visualizador.DataSource = consultas.ventasPorAñoCliente(comboBox1.SelectedText);
                                comboBox1.Enabled = false;

                                button28.Visible = true;
                                Visualizador.Visible = true;
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

                                    button28.Visible = true;
                                    Visualizador.Visible = true;
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

                                        button28.Visible = true;
                                        Visualizador.Visible = true;
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

                                            button28.Visible = true;
                                            Visualizador.Visible = true;
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

                                                button28.Visible = true;
                                                Visualizador.Visible = true;
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
            button28.Focus();
        }

        private void porClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
            textBox1.Enabled = true;
            textBox1.Text = "";
            Boton_1TextBox.Visible = true;
            Boton_1TextBox.Enabled = false;
            label3.Visible = false;
            comboBox1.Visible = false;
            Visualizador.Visible = false;
            button28.Visible = false;

            label1.Text = "Código del Cliente";
            textBox1.Focus();
        }

        private void ventasMensualesPorAñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;
            
            label3.Visible = true;
            comboBox1.Visible = true;

            Boton_1TextBox.Visible = true;
            Boton_1TextBox.Enabled = false;
            comboBox1.Enabled = true;

            Visualizador.Visible = false;
            button28.Visible = false;

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
            label1.Visible = false;
            textBox1.Visible = false;

            label3.Visible = true;
            comboBox1.Visible = true;

            Boton_1TextBox.Visible = true;
            Boton_1TextBox.Enabled = false;
            comboBox1.Enabled = true;

            Visualizador.Visible = false;
            button28.Visible = false;

            label3.Text = "Año:";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("2015");
            comboBox1.Items.Add("2016");
            comboBox1.Items.Add("2017");
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;

            label3.Visible = true;
            comboBox1.Visible = true;

            Boton_1TextBox.Visible = true;
            Boton_1TextBox.Enabled = false;
            comboBox1.Enabled = true;

            Visualizador.Visible = false;
            button28.Visible = false;

            label3.Text = " Año:";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("2015");
            comboBox1.Items.Add("2016");
            comboBox1.Items.Add("2017");
        }

        private void ventasPorDepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;

            label3.Visible = true;
            comboBox1.Visible = true;

            Boton_1TextBox.Visible = true;
            Boton_1TextBox.Enabled = false;
            comboBox1.Enabled = true;

            Visualizador.Visible = false;
            button28.Visible = false;

            label3.Text = " Año: ";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("2015");
            comboBox1.Items.Add("2016");
            comboBox1.Items.Add("2017");
        }

        private void todosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;
            Boton_1TextBox.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;

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
            label1.Visible = true;
            textBox1.Visible = true;
            textBox1.Enabled = true;
            textBox1.Text = "";
            Boton_1TextBox.Visible = true;
            Boton_1TextBox.Enabled = false;
            label3.Visible = false;
            comboBox1.Visible = false;
            Visualizador.Visible = false;
            button28.Visible = false;

            label1.Text = "Código del Producto";
            textBox1.Focus();
        }

        private void todasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;
            Boton_1TextBox.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;

            try
            {
                Visualizador.DataSource = consultas.todasFacturas();

                button28.Visible = true;
                Visualizador.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error en la conexión" + ex.ToString());
            }
        }

        private void específicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
            textBox1.Enabled = true;
            textBox1.Text = "";
            Boton_1TextBox.Visible = true;
            Boton_1TextBox.Enabled = false;
            label3.Visible = false;
            comboBox1.Visible = false;
            Visualizador.Visible = false;
            button28.Visible = false;

            label1.Text = "Folio de la Factura:";
            textBox1.Focus();
        }
    }
}
