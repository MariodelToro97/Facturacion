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
    public partial class Vendedores : Form
    {
        private SqlConnection connection = new SqlConnection("Data Source=CHOMYDELTORO\\MSSQLSERVER2016;Initial Catalog=eFactur;Integrated Security=True");
        private DataSet dataSet;

        public Vendedores()
        {
            InitializeComponent();
        }

        private Boolean Mensaje;

        private void Vendedores_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'eFacturDataSet.Vendedor' Puede moverla o quitarla según sea necesario.
            this.vendedorTableAdapter.Fill(this.eFacturDataSet.Vendedor);

            lab1.Text = "RFC:";
            lab2.Text = "Nombre:";
            lab4.Text = "Sexo:";
            lab3.Text = "Fecha de Nacimiento:";
            label5.Text = "Sueldo Base Quincenal:";
            label6.Text = "Comisión por Ventas:";

            Cambio.Enabled = false;
            textBox1.Visible = false;
            label1.Visible = false;
            button1.Visible = false;

            if (Mensaje)
            {
                Cambio.Text = "Insertar";
            }
            else if (!Mensaje)
            {
                Cambio.Text = "Modificar";
                lab1.Visible = false;
                lab2.Visible = false;
                lab3.Visible = false;
                lab4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;

                label1.Visible = true;
                textBox1.Visible = true;
                button1.Visible = true;
                button1.Enabled = false;
                label1.Text = "Código del Vendedor:";

                Cambio.Visible = false;

                textboxRFC.Visible = false;
                Nombre.Visible = false;
                sexo.Visible = false;
                fechaNacimiento.Visible = false;
                sueldoBase.Visible = false;
                comision.Visible = false;
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form principal = new Principal();
            principal.Show();

            this.Hide();
        }

        public void inicioInsertar()
        {
            Mensaje = true;
        }

        public void inicioModificar()
        {
            Mensaje = false;
        }

        private void Nombre_TextChanged(object sender, EventArgs e)
        {
            if (textboxRFC.Text != "" && Nombre.Text != "" && sexo.SelectedIndex != -1 && sueldoBase.Text != "" && comision.Text != "")
            {
                Cambio.Enabled = true;
            }
            else
            {
                Cambio.Enabled = false;
            }
        }

        private void Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)(Keys.Enter)))
            {
                sexo.Focus();
            }
            if ((char.IsLetter(e.KeyChar)) || (e.KeyChar == ((char)(Keys.Back))) || (e.KeyChar == ((char)(Keys.Space))))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textboxRFC_TextChanged(object sender, EventArgs e)
        {
            if (textboxRFC.Text != "" && Nombre.Text != "" && sexo.SelectedIndex != -1 && sueldoBase.Text != "" && comision.Text != "")
            {
                Cambio.Enabled = true;
            }
            else
            {
                Cambio.Enabled = false;
            }
        }

        private void sexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textboxRFC.Text != "" && Nombre.Text != "" && sexo.SelectedIndex != -1 && sueldoBase.Text != "" && comision.Text != "")
            {
                Cambio.Enabled = true;
            }
            else
            {
                Cambio.Enabled = false;
            }
        }

        private void sueldoBase_TextChanged(object sender, EventArgs e)
        {
            if (textboxRFC.Text != "" && Nombre.Text != "" && sexo.SelectedIndex != -1 && sueldoBase.Text != "" && comision.Text != "")
            {
                Cambio.Enabled = true;
            }
            else
            {
                Cambio.Enabled = false;
            }
        }

        private void comision_TextChanged(object sender, EventArgs e)
        {
            if (textboxRFC.Text != "" && Nombre.Text != "" && sexo.SelectedIndex != -1 && sueldoBase.Text != "" && comision.Text != "")
            {
                Cambio.Enabled = true;
            }
            else
            {
                Cambio.Enabled = false;
            }
        }

        private void sueldoBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            Boolean banderaPunto = true;
            if (e.KeyChar == ((char)(Keys.Enter)))
            {
                comision.Focus();
            }

            if ((char.IsNumber(e.KeyChar)) || (e.KeyChar == ((char)(Keys.Back))))
                e.Handled = false;
            else
            {
                e.Handled = true;                
            }
        }

        private void comision_KeyPress(object sender, KeyPressEventArgs e)
        {
            Boolean banderaPunto = true;

            if (e.KeyChar == ((char)(Keys.Enter)))
            {
                comision.Focus();
            }

            if ((char.IsNumber(e.KeyChar)) || (e.KeyChar == ((char)(Keys.Back))) || e.KeyChar != 46)
                e.Handled = false;
            else
            {
                if (e.KeyChar == 46)
                {
                    if (banderaPunto)
                    {
                        banderaPunto = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }                
        }

        Consultas consultas = new Consultas();
        private void Cambio_Click(object sender, EventArgs e)
        {
            if (Cambio.Text == "Insertar")
            {
                if (int.Parse(sueldoBase.Text) < 1500 || int.Parse(sueldoBase.Text) > 5000)
                {
                    MessageBox.Show("El rango del sueldo Base debe ser entre 1500 y 5000 pesos");
                }
                else
                {
                    if (int.Parse(comision.Text) < 5 || int.Parse(comision.Text) > 10)
                    {
                        MessageBox.Show("El rango de la comisión debe ser entre 5 y 10");
                    }
                    else
                    {
                        try
                        {
                            //MessageBox.Show(fechaNacimiento.Value.ToString("dd/MM/yyyy"));
                            if (consultas.insertarVendedor(textboxRFC.Text, Nombre.Text, sexo.SelectedItem.ToString(), fechaNacimiento.Value.ToString("dd/MM/yyyy"), sueldoBase.Text, comision.Text))
                            {
                                MessageBox.Show("Vendedor insertado correctamente");

                                Form principal = new Principal();

                                principal.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Ha ocurrido algún error");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ha ocurrido algún error con la Base de Datos" + ex.ToString());
                        }
                    }
                }     
            }
            else
            {
                if (Cambio.Text == "Modificar")
                {
                    if (int.Parse(sueldoBase.Text) < 1500 || int.Parse(sueldoBase.Text) > 5000)
                    {
                        MessageBox.Show("El rango del sueldo Base debe ser entre 1500 y 5000 pesos");
                    }
                    else
                    {
                        if (int.Parse(comision.Text) < 5 || int.Parse(comision.Text) > 10)
                        {
                            MessageBox.Show("El rango de la comisión debe ser entre 5 y 10");
                        }
                        else
                        {
                            label1.Enabled = false;
                            textBox1.Enabled = false;
                            button1.Enabled = false;

                            if (consultas.actualizarVendedor(textboxRFC.Text, Nombre.Text, sexo.SelectedItem.ToString(), fechaNacimiento.Value.ToString("dd/MM/yyyy"), sueldoBase.Text, comision.Text, textBox1.Text))
                            {
                                MessageBox.Show("Se actualizó correctamente");
                            }
                            else
                            {
                                MessageBox.Show("Ocurrió algún error");
                            }
                        }
                    }
                }
            }

            Form form = new Principal();
            form.Show();
            this.Hide();
        }

        private void sexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)(Keys.Enter)))
            {
                fechaNacimiento.Focus();
            }
            e.Handled = true;
        }

        private void textboxRFC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)(Keys.Enter)))
            {
                Nombre.Focus();
            }
            if ((char.IsLetter(e.KeyChar)) || (char.IsDigit(e.KeyChar)) ||(e.KeyChar == ((char)(Keys.Back))) || (e.KeyChar == 45))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)(Keys.Enter)))
            {
                button1.Focus();
            }

            if ((char.IsNumber(e.KeyChar)) || (e.KeyChar == ((char)(Keys.Back))))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Enabled = false;
            textBox1.Enabled = false;
            button1.Enabled = false;

            Cambio.Visible = true;

            lab1.Visible = true;
            lab2.Visible = true;
            lab3.Visible = true;
            lab4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;

            textboxRFC.Visible = true;
            Nombre.Visible = true;
            sexo.Visible = true;
            fechaNacimiento.Visible = true;
            sueldoBase.Visible = true;
            comision.Visible = true;

            int clave;

            clave = Convert.ToInt32(textBox1.Text);

            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("SELECT * FROM VENDEDOR WHERE CLAVE = {0}", clave), connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Vendedor");
            connection.Close();
            textboxRFC.Text = dataSet.Tables[0].Rows[0]["rfc"].ToString().Trim();
            Nombre.Text = dataSet.Tables[0].Rows[0]["nombre"].ToString().Trim();
            sexo.Text = dataSet.Tables[0].Rows[0]["sexo"].ToString().Trim();
            fechaNacimiento.Text = dataSet.Tables[0].Rows[0]["fechaNac"].ToString().Trim();
            sueldoBase.Text = dataSet.Tables[0].Rows[0]["sueldoBaseQuincenal"].ToString().Trim();
            comision.Text = dataSet.Tables[0].Rows[0]["comisionPorVentas"].ToString().Trim();

            textBox1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
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
