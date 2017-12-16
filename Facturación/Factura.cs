using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturación
{
    public partial class Factura : Form
    {
        private SqlConnection connection = new SqlConnection("Data Source=CHOMYDELTORO\\MSSQLSERVER2016;Initial Catalog=eFactur;Integrated Security=True");
        private DataSet dataSet;

        public Factura()
        {
            InitializeComponent();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) || (e.KeyChar == ((char)(Keys.Back))))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) || (e.KeyChar == ((char)(Keys.Back))))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form principal = new Principal();
            principal.Show();

            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1 )
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'eFacturDataSet.Factura' Puede moverla o quitarla según sea necesario.
            this.facturaTableAdapter.Fill(this.eFacturDataSet.Factura);
            // TODO: esta línea de código carga datos en la tabla 'eFacturDataSet.Producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter.Fill(this.eFacturDataSet.Producto);
            // TODO: esta línea de código carga datos en la tabla 'eFacturDataSet.Cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter.Fill(this.eFacturDataSet.Cliente);
            // TODO: esta línea de código carga datos en la tabla 'eFacturDataSet.Vendedor' Puede moverla o quitarla según sea necesario.
            this.vendedorTableAdapter.Fill(this.eFacturDataSet.Vendedor);
            button1.Enabled = false;

            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;

            textBox1.Visible = false;
            textBox2.Visible = false;

            comboBox5.Visible = false;

            button3.Visible = false;
            button4.Visible = false;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) || (e.KeyChar == ((char)(Keys.Back))))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) || (e.KeyChar == ((char)(Keys.Back))))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        Consultas consultas = new Consultas();

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.ToUpper();

            if (textBox3.Text.ToString().Equals("CONTADO") || textBox3.Text.ToString().Equals("CRÉDITO"))
            {
                try
                {
                    button3.Visible = true;
                    button4.Visible = true;
                    button1.Enabled = false;
                    button2.Enabled = false;

                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;

                    textBox1.Visible = true;
                    textBox2.Visible = true;

                    comboBox5.Visible = true;

                    textBox3.Enabled = false;
                    comboBox2.Enabled = false;
                    comboBox3.Enabled = false;

                    int a, b;

                    a = Convert.ToInt32(comboBox2.SelectedValue.ToString());
                    b = Convert.ToInt32(comboBox3.SelectedValue.ToString());

                    if (consultas.insertarFactura(textBox3.Text.ToString(), a, b))
                    {
                        MessageBox.Show("Factura insertada de forma Correcta");

                        connection.Open();
                        SqlCommand command = new SqlCommand("Select MAX(folio) as folio From Factura; ", connection);
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet, "Factura");
                        connection.Close();
                        textBox1.Text = dataSet.Tables[0].Rows[0]["folio"].ToString().Trim();
                        textBox1.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error en la inserción");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error con la Base de Datos" + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Usted ingreso la forma de pago errónea y puede causar conflicto\n Favor de corregir dicho problema\n CONTADO   CRÉDITO");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form principal = new Principal();
            principal.Show();

            this.Hide();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex != -1 && textBox2.Text != "")
            {
                button3.Enabled = true;
            } 
            else
            {
                button3.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex != -1 && textBox2.Text != "")
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int folio, codigo, cantidad;

                folio = Convert.ToInt32(textBox1.Text);
                codigo = Convert.ToInt32(comboBox5.SelectedValue.ToString());
                cantidad = Convert.ToInt32(textBox2.Text);

                if (consultas.registrarDetalle(folio, codigo, cantidad))
                {
                    MessageBox.Show("Detalle insertado correctamemte");
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("No se pudo insertar el Detalle");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error con la Base de Datos" + ex.ToString());
            }

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) || (e.KeyChar == ((char)(Keys.Back))))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}
