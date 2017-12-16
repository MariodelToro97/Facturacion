using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturación
{
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        Boolean muestra;

        private void Proveedores_Load(object sender, EventArgs e)
        {
            if (muestra)
            {
                label5.Visible = false;
                textBox5.Visible = false;

                button1.Text = "Insertar";
            }
            else 
            {
                label5.Visible = true;
                textBox5.Visible = true;

                Nombre.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;

                button1.Text = "Modificar";
            }
        }        

        public void ingresarinsertar()
        {
            muestra = true;
        }

        public void ingresarModificar()
        {
            muestra = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) || (e.KeyChar == ((char)(Keys.Back))))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) || (e.KeyChar == ((char)(Keys.Back))) || (e.KeyChar == 45))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void Nombre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) || (e.KeyChar == ((char)(Keys.Back))) || (e.KeyChar == ((char)(Keys.Space))))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void regresar_Click(object sender, EventArgs e)
        {
            Form prin = new Principal();

            prin.Show();
            this.Hide();
        }
    }
}
